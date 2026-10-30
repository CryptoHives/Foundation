// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Provides a code fix for <see cref="DiagnosticIds.SemaphoreSlimAsAsyncLock"/> (CHT009)
/// that replaces <c>new SemaphoreSlim(1, 1)</c> with <c>new AsyncLock()</c>, rewrites each
/// <c>await WaitAsync(); try { … } finally { Release(); }</c> into <c>using (await LockAsync()) { … }</c>,
/// and adds the required <c>using</c> directive.
/// </summary>
/// <remarks>
/// The fix is only offered when every use of the semaphore is such a pair, all in this document.
/// Anything else - a synchronous <c>Wait()</c>, a timeout overload, <c>CurrentCount</c>, a release
/// outside a <c>finally</c> - has no <c>AsyncLock</c> equivalent the fix could write.
/// </remarks>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(SemaphoreSlimAsAsyncLockCodeFixProvider))]
[Shared]
public sealed class SemaphoreSlimAsAsyncLockCodeFixProvider : CodeFixProvider
{
    private const string AsyncLockNamespace = "CryptoHives.Foundation.Threading.Async.Pooled";
    private const string AsyncLockTypeName = "AsyncLock";

    /// <inheritdoc/>
    public override ImmutableArray<string> FixableDiagnosticIds { get; } =
        ImmutableArray.Create(DiagnosticIds.SemaphoreSlimAsAsyncLock);

    /// <inheritdoc/>
    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    /// <inheritdoc/>
    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        SyntaxNode? root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        SemanticModel? model = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);
        if (root is null || model is null)
        {
            return;
        }

        foreach (Diagnostic diagnostic in context.Diagnostics)
        {
            Conversion? conversion = Plan(root, model, root.FindNode(diagnostic.Location.SourceSpan), context.CancellationToken);
            if (conversion is null)
            {
                continue;
            }

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: "Replace with AsyncLock",
                    createChangedDocument: ct => Task.FromResult(context.Document.WithSyntaxRoot(Apply(root, conversion))),
                    equivalenceKey: "ReplaceWithAsyncLock"),
                diagnostic);
        }
    }

    /// <summary>
    /// What the fix rewrites: the creation, the declared type, and each wait statement with the
    /// <c>try</c> that follows it.
    /// </summary>
    private sealed class Conversion
    {
        public Conversion(SyntaxNode creation, TypeSyntax declaredType, List<ExpressionStatementSyntax> waits)
        {
            Creation = creation;
            DeclaredType = declaredType;
            Waits = waits;
        }

        public SyntaxNode Creation { get; }

        public TypeSyntax DeclaredType { get; }

        public List<ExpressionStatementSyntax> Waits { get; }
    }

    private static Conversion? Plan(SyntaxNode root, SemanticModel model, SyntaxNode creation, CancellationToken cancellationToken)
    {
        ISymbol? semaphore = creation.Parent switch {
            EqualsValueClauseSyntax { Parent: VariableDeclaratorSyntax declarator } => model.GetDeclaredSymbol(declarator, cancellationToken),
            AssignmentExpressionSyntax assignment when assignment.Right == creation => model.GetSymbolInfo(assignment.Left, cancellationToken).Symbol,
            _ => null,
        };

        bool contained = semaphore switch {
            ILocalSymbol => true,
            IFieldSymbol field => field.DeclaredAccessibility == Accessibility.Private && field.ContainingType.DeclaringSyntaxReferences.Length == 1,
            _ => false,
        };

        // The declared type changes, so the declaration must declare nothing else.
        if (!contained ||
            semaphore!.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax(cancellationToken) is not VariableDeclaratorSyntax {
                Parent: VariableDeclarationSyntax { Variables.Count: 1 } declaration
            })
        {
            return null;
        }

        var waits = new List<ExpressionStatementSyntax>();
        var releases = new HashSet<SyntaxNode>();

        foreach (IdentifierNameSyntax reference in root.DescendantNodes().OfType<IdentifierNameSyntax>())
        {
            if (reference.Identifier.Text != semaphore.Name ||
                !SymbolEqualityComparer.Default.Equals(model.GetSymbolInfo(reference, cancellationToken).Symbol, semaphore))
            {
                continue;
            }

            // The assignment the diagnostic is on.
            if (reference.Parent is AssignmentExpressionSyntax assignment && assignment.Left == reference && assignment.Right == creation)
            {
                continue;
            }

            // The release of a pair already matched from its wait, which comes first in the document.
            if (releases.Contains(reference))
            {
                continue;
            }

            if (TryMatchWait(model, semaphore, reference, cancellationToken) is not (ExpressionStatementSyntax wait, IdentifierNameSyntax release))
            {
                return null;
            }

            waits.Add(wait);
            releases.Add(release);
        }

        return new Conversion(creation, declaration.Type, waits);
    }

    /// <summary>
    /// Matches <c>await s.WaitAsync([ct])[.ConfigureAwait(x)];</c> followed directly by
    /// <c>try { … } finally { s.Release(); }</c>, where <paramref name="reference"/> is the wait's <c>s</c>.
    /// </summary>
    private static (ExpressionStatementSyntax Wait, IdentifierNameSyntax Release)? TryMatchWait(
        SemanticModel model,
        ISymbol semaphore,
        IdentifierNameSyntax reference,
        CancellationToken cancellationToken)
    {
        if (reference.Parent is not MemberAccessExpressionSyntax { Name.Identifier.Text: "WaitAsync" } waitAccess ||
            waitAccess.Expression != reference ||
            waitAccess.Parent is not InvocationExpressionSyntax waitCall ||
            waitCall.ArgumentList.Arguments.Count > 1)
        {
            return null;
        }

        if (waitCall.ArgumentList.Arguments.Count == 1 &&
            model.GetTypeInfo(waitCall.ArgumentList.Arguments[0].Expression, cancellationToken).Type?.Name != nameof(CancellationToken))
        {
            return null;
        }

        SyntaxNode awaited = waitCall;
        if (waitCall.Parent is MemberAccessExpressionSyntax { Name.Identifier.Text: "ConfigureAwait" } configure &&
            configure.Parent is InvocationExpressionSyntax configureCall)
        {
            awaited = configureCall;
        }

        if (awaited.Parent is not AwaitExpressionSyntax { Parent: ExpressionStatementSyntax { Parent: BlockSyntax block } wait })
        {
            return null;
        }

        int index = block.Statements.IndexOf(wait);
        if (index + 1 >= block.Statements.Count ||
            block.Statements[index + 1] is not TryStatementSyntax { Catches.Count: 0, Finally.Block.Statements: { Count: 1 } finallyStatements } ||
            finallyStatements[0] is not ExpressionStatementSyntax {
                Expression: InvocationExpressionSyntax {
                    ArgumentList.Arguments.Count: 0,
                    Expression: MemberAccessExpressionSyntax { Name.Identifier.Text: "Release", Expression: IdentifierNameSyntax release }
                }
            } ||
            !SymbolEqualityComparer.Default.Equals(model.GetSymbolInfo(release, cancellationToken).Symbol, semaphore))
        {
            return null;
        }

        return (wait, release);
    }

    private static SyntaxNode Apply(SyntaxNode root, Conversion conversion)
    {
        var waitsByBlock = conversion.Waits
            .GroupBy(w => (BlockSyntax)w.Parent!)
            .ToDictionary(g => g.Key, g => new HashSet<int>(g.Select(w => g.Key.Statements.IndexOf(w))));

        var targets = new List<SyntaxNode> { conversion.Creation, conversion.DeclaredType };
        targets.AddRange(waitsByBlock.Keys);

        SyntaxNode newRoot = root.ReplaceNodes(targets, (original, rewritten) => {
            if (original == conversion.Creation)
            {
                return SyntaxFactory.ObjectCreationExpression(SyntaxFactory.IdentifierName(AsyncLockTypeName))
                    .WithArgumentList(SyntaxFactory.ArgumentList())
                    .WithTriviaFrom(rewritten);
            }

            if (original == conversion.DeclaredType)
            {
                return conversion.DeclaredType.IsVar
                    ? rewritten
                    : SyntaxFactory.IdentifierName(AsyncLockTypeName).WithTriviaFrom(rewritten);
            }

            return RewriteBlock((BlockSyntax)rewritten, waitsByBlock[(BlockSyntax)original]);
        });

        return EnsureUsingDirective(newRoot, AsyncLockNamespace);
    }

    /// <summary>
    /// Replaces each wait statement and the <c>try</c> after it with one <c>using</c> statement whose
    /// body is the <c>try</c> block. Indexes refer to the original block, whose statement count the
    /// rewrite of nested blocks does not change.
    /// </summary>
    private static BlockSyntax RewriteBlock(BlockSyntax block, HashSet<int> waitIndexes)
    {
        var statements = new List<StatementSyntax>();

        for (int i = 0; i < block.Statements.Count; i++)
        {
            if (!waitIndexes.Contains(i))
            {
                statements.Add(block.Statements[i]);
                continue;
            }

            var wait = (ExpressionStatementSyntax)block.Statements[i];
            var tryStatement = (TryStatementSyntax)block.Statements[++i];

            var awaitExpression = (AwaitExpressionSyntax)wait.Expression;
            SimpleNameSyntax waitName = awaitExpression.DescendantNodes().OfType<MemberAccessExpressionSyntax>()
                .First(m => m.Name.Identifier.Text == "WaitAsync").Name;

            ExpressionSyntax lockExpression = awaitExpression
                .ReplaceNode(waitName, SyntaxFactory.IdentifierName("LockAsync").WithTriviaFrom(waitName))
                .WithoutTrivia();

            statements.Add(SyntaxFactory.UsingStatement(declaration: null, expression: lockExpression, statement: tryStatement.Block)
                .WithLeadingTrivia(wait.GetLeadingTrivia())
                .WithTrailingTrivia(tryStatement.GetTrailingTrivia())
                .WithAdditionalAnnotations(Formatter.Annotation));
        }

        return block.WithStatements(SyntaxFactory.List(statements));
    }

    /// <summary>
    /// Adds a <c>using</c> directive for <paramref name="namespaceName"/> to the compilation unit
    /// when no equivalent directive already exists.
    /// </summary>
    private static SyntaxNode EnsureUsingDirective(SyntaxNode root, string namespaceName)
    {
        if (root is not CompilationUnitSyntax compilationUnit)
        {
            return root;
        }

        // Check top-level usings first.
        bool alreadyPresent = compilationUnit.Usings
            .Any(u => u.Name?.ToString() == namespaceName);

        if (!alreadyPresent)
        {
            // Also check file-scoped namespace usings.
            alreadyPresent = compilationUnit.Members
                .OfType<FileScopedNamespaceDeclarationSyntax>()
                .Any(ns => ns.Usings.Any(u => u.Name?.ToString() == namespaceName));
        }

        if (!alreadyPresent)
        {
            // Also check block-scoped namespace usings.
            alreadyPresent = compilationUnit.Members
                .OfType<NamespaceDeclarationSyntax>()
                .Any(ns => ns.Usings.Any(u => u.Name?.ToString() == namespaceName));
        }

        if (alreadyPresent)
        {
            return root;
        }

        // Two things are needed for the formatter to supply the document's own line ending here, and
        // neither is sufficient alone. The annotation, because CodeAction's post processing formats
        // annotated nodes only. And ElasticLineFeed rather than ElasticCarriageReturnLineFeed,
        // because the formatter leaves a "\r\n" it is asked to shorten to "\n" alone - so the CRLF
        // spelling is elastic only in the direction that happens to match Windows, and inserts a
        // lone CRLF line into an LF document. "\n" is rewritten in both directions.
        var newUsing = SyntaxFactory.UsingDirective(
                SyntaxFactory.ParseName(" " + namespaceName))
            .WithTrailingTrivia(SyntaxFactory.ElasticLineFeed)
            .WithAdditionalAnnotations(Formatter.Annotation);

        // Insert after the last existing using directive, or at the top of the file.
        if (compilationUnit.Usings.Count > 0)
        {
            var newUsings = compilationUnit.Usings.Add(newUsing);
            return compilationUnit.WithUsings(newUsings);
        }

        return compilationUnit.AddUsings(newUsing);
    }
}
