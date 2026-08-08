// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Formatting;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Provides code fixes for <see cref="DiagnosticIds.RedundantAsyncForwarding"/> (CHT011), which removes
/// the <see langword="async"/> modifier and returns the awaited <c>ValueTask</c> directly, and for
/// <see cref="DiagnosticIds.AsyncWrapperBoxesStateMachine"/> (CHT012), which pools the state machine box.
/// </summary>
/// <remarks>
/// <para>
/// The two fixes differ in how complete they are. CHT011's is exact: the async machinery was buying
/// nothing, and removing it leaves equivalent code.
/// </para>
/// <para>
/// CHT012's is a mitigation, not a cure. The thorough fix is to relocate the cleanup that forces the
/// await boundary, which is a change to the awaited operation's own design and cannot be derived
/// mechanically. Pooling the box is offered because it is a legitimate one-line improvement that is not
/// widely known - but it only recycles boxes used in sequence and cannot reduce peak live objects, so it
/// helps little when many callers suspend at once. The action title says so, and the fix is only offered
/// when the compilation actually has the pooling builder.
/// </para>
/// </remarks>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AsyncValueTaskBoxingCodeFixProvider))]
[Shared]
public sealed class AsyncValueTaskBoxingCodeFixProvider : CodeFixProvider
{
    private const string CompilerServicesNamespace = "System.Runtime.CompilerServices";
    private const string PoolingBuilder = "PoolingAsyncValueTaskMethodBuilder";

    /// <inheritdoc/>
    public override ImmutableArray<string> FixableDiagnosticIds =>
        ImmutableArray.Create(
            DiagnosticIds.RedundantAsyncForwarding,
            DiagnosticIds.AsyncWrapperBoxesStateMachine);

    /// <inheritdoc/>
    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    /// <inheritdoc/>
    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        SyntaxNode? root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return;
        }

        Diagnostic diagnostic = context.Diagnostics.First();
        SyntaxNode node = root.FindNode(diagnostic.Location.SourceSpan);

        SyntaxNode? declaration = node.FirstAncestorOrSelf<MethodDeclarationSyntax>() as SyntaxNode
            ?? node.FirstAncestorOrSelf<LocalFunctionStatementSyntax>();

        if (declaration is null)
        {
            return;
        }

        if (diagnostic.Id == DiagnosticIds.RedundantAsyncForwarding)
        {
            context.RegisterCodeFix(
                CodeAction.Create(
                    title: "Remove async and return the ValueTask directly",
                    createChangedDocument: ct => RemoveAsyncForwardingAsync(context.Document, declaration, ct),
                    equivalenceKey: nameof(DiagnosticIds.RedundantAsyncForwarding)),
                diagnostic);

            return;
        }

        // CHT012. Only worth offering where the builder exists - it is .NET 6+, and on older targets the
        // attribute would simply fail to compile.
        SemanticModel? model = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);
        if (model is null || !HasPoolingBuilder(model.Compilation))
        {
            return;
        }

        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Pool the state machine box (helps only when suspensions do not overlap)",
                createChangedDocument: ct => ApplyPoolingBuilderAsync(context.Document, declaration, ct),
                equivalenceKey: nameof(DiagnosticIds.AsyncWrapperBoxesStateMachine)),
            diagnostic);
    }

    private static bool HasPoolingBuilder(Compilation compilation)
        => compilation.GetTypeByMetadataName($"{CompilerServicesNamespace}.{PoolingBuilder}") is not null
            || compilation.GetTypeByMetadataName($"{CompilerServicesNamespace}.{PoolingBuilder}`1") is not null;

    /// <summary>
    /// Adds <c>[AsyncMethodBuilder(typeof(PoolingAsyncValueTaskMethodBuilder&lt;&gt;))]</c> to the
    /// declaration, choosing the generic or non-generic builder to match the return type.
    /// </summary>
    private static async Task<Document> ApplyPoolingBuilderAsync(
        Document document,
        SyntaxNode declaration,
        CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        SemanticModel? model = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
        if (root is null || model is null)
        {
            return document;
        }

        if (model.GetDeclaredSymbol(declaration, cancellationToken) is not IMethodSymbol symbol)
        {
            return document;
        }

        bool generic = symbol.ReturnType is INamedTypeSymbol { IsGenericType: true };

        // typeof(PoolingAsyncValueTaskMethodBuilder<>) for ValueTask<T>, or the non-generic builder for
        // a bare ValueTask.
        TypeSyntax builderType = generic
            ? SyntaxFactory.GenericName(SyntaxFactory.Identifier(PoolingBuilder))
                .WithTypeArgumentList(SyntaxFactory.TypeArgumentList(
                    SyntaxFactory.SingletonSeparatedList<TypeSyntax>(SyntaxFactory.OmittedTypeArgument())))
            : SyntaxFactory.IdentifierName(PoolingBuilder);

        AttributeSyntax attribute = SyntaxFactory
            .Attribute(SyntaxFactory.IdentifierName("AsyncMethodBuilder"))
            .WithArgumentList(SyntaxFactory.AttributeArgumentList(
                SyntaxFactory.SingletonSeparatedList(
                    SyntaxFactory.AttributeArgument(SyntaxFactory.TypeOfExpression(builderType)))));

        SyntaxNode? updated = AddAttribute(declaration, attribute);
        if (updated is null)
        {
            return document;
        }

        SyntaxNode newRoot = root.ReplaceNode(declaration, updated);
        newRoot = EnsureCompilerServicesUsing(newRoot);

        return document.WithSyntaxRoot(newRoot);
    }

    /// <summary>
    /// Prepends an attribute list, moving the declaration's leading trivia onto it so documentation
    /// comments and indentation stay above the attribute rather than between it and the method.
    /// </summary>
    private static SyntaxNode? AddAttribute(SyntaxNode declaration, AttributeSyntax attribute)
    {
        // Annotated for formatting so the host lays the attribute out using the document's own
        // conventions - notably its line endings - rather than whatever this code hardcodes.
        AttributeListSyntax list = SyntaxFactory
            .AttributeList(SyntaxFactory.SingletonSeparatedList(attribute))
            .WithAdditionalAnnotations(Formatter.Annotation);

        switch (declaration)
        {
            case MethodDeclarationSyntax method:
            {
                SyntaxTriviaList leading = method.GetLeadingTrivia();
                return method
                    .WithLeadingTrivia(SyntaxFactory.TriviaList())
                    .WithAttributeLists(method.AttributeLists.Insert(0, list.WithLeadingTrivia(leading)));
            }

            case LocalFunctionStatementSyntax local:
            {
                SyntaxTriviaList leading = local.GetLeadingTrivia();
                return local
                    .WithLeadingTrivia(SyntaxFactory.TriviaList())
                    .WithAttributeLists(local.AttributeLists.Insert(0, list.WithLeadingTrivia(leading)));
            }

            default:
                return null;
        }
    }

    private static SyntaxNode EnsureCompilerServicesUsing(SyntaxNode root)
    {
        if (root is not CompilationUnitSyntax unit)
        {
            return root;
        }

        if (unit.Usings.Any(u => u.Name?.ToString() == CompilerServicesNamespace))
        {
            return unit;
        }

        // Elastic trivia rather than a hardcoded newline, so the formatter substitutes the line ending
        // the rest of the document uses.
        UsingDirectiveSyntax directive = SyntaxFactory
            .UsingDirective(SyntaxFactory.ParseName(CompilerServicesNamespace))
            .WithTrailingTrivia(SyntaxFactory.ElasticCarriageReturnLineFeed)
            .WithAdditionalAnnotations(Formatter.Annotation);

        return unit.WithUsings(unit.Usings.Add(directive));
    }

    private static async Task<Document> RemoveAsyncForwardingAsync(
        Document document,
        SyntaxNode declaration,
        CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        SyntaxNode? rewritten = declaration switch {
            MethodDeclarationSyntax method => RewriteMethod(method),
            LocalFunctionStatementSyntax local => RewriteLocalFunction(local),
            _ => null,
        };

        return rewritten is null ? document : document.WithSyntaxRoot(root.ReplaceNode(declaration, rewritten));
    }

    private static MethodDeclarationSyntax? RewriteMethod(MethodDeclarationSyntax method)
    {
        SyntaxTokenList modifiers = RemoveAsyncModifier(method.Modifiers);

        if (method.ExpressionBody is not null)
        {
            ArrowExpressionClauseSyntax? body = RewriteExpressionBody(method.ExpressionBody);
            return body is null ? null : method.WithModifiers(modifiers).WithExpressionBody(body);
        }

        BlockSyntax? block = RewriteBlock(method.Body);
        return block is null ? null : method.WithModifiers(modifiers).WithBody(block);
    }

    private static LocalFunctionStatementSyntax? RewriteLocalFunction(LocalFunctionStatementSyntax local)
    {
        SyntaxTokenList modifiers = RemoveAsyncModifier(local.Modifiers);

        if (local.ExpressionBody is not null)
        {
            ArrowExpressionClauseSyntax? body = RewriteExpressionBody(local.ExpressionBody);
            return body is null ? null : local.WithModifiers(modifiers).WithExpressionBody(body);
        }

        BlockSyntax? block = RewriteBlock(local.Body);
        return block is null ? null : local.WithModifiers(modifiers).WithBody(block);
    }

    /// <summary>
    /// Drops the <see langword="async"/> keyword, moving any leading trivia it carried onto whatever
    /// modifier now comes first so the declaration keeps its comments and indentation.
    /// </summary>
    private static SyntaxTokenList RemoveAsyncModifier(SyntaxTokenList modifiers)
    {
        int index = modifiers.IndexOf(SyntaxKind.AsyncKeyword);
        if (index < 0)
        {
            return modifiers;
        }

        SyntaxTriviaList leading = modifiers[index].LeadingTrivia;
        SyntaxTokenList without = modifiers.RemoveAt(index);

        if (index == 0 && without.Count > 0)
        {
            return without.Replace(without[0], without[0].WithLeadingTrivia(leading));
        }

        return without;
    }

    private static ArrowExpressionClauseSyntax? RewriteExpressionBody(ArrowExpressionClauseSyntax expressionBody)
    {
        ExpressionSyntax? forwarded = Unwrap(expressionBody.Expression);
        return forwarded is null ? null : expressionBody.WithExpression(forwarded);
    }

    private static BlockSyntax? RewriteBlock(BlockSyntax? block)
    {
        if (block is null || block.Statements.Count == 0)
        {
            return null;
        }

        StatementSyntax last = block.Statements[block.Statements.Count - 1];

        switch (last)
        {
            // ValueTask<T>: `return await X();` becomes `return X();`
            case ReturnStatementSyntax { Expression: not null } returnStatement:
            {
                ExpressionSyntax? forwarded = Unwrap(returnStatement.Expression);
                return forwarded is null
                    ? null
                    : block.ReplaceNode(returnStatement, returnStatement.WithExpression(forwarded));
            }

            // Non-generic ValueTask: a trailing `await X();` becomes `return X();`
            case ExpressionStatementSyntax expressionStatement:
            {
                ExpressionSyntax? forwarded = Unwrap(expressionStatement.Expression);
                if (forwarded is null)
                {
                    return null;
                }

                ReturnStatementSyntax replacement = SyntaxFactory
                    .ReturnStatement(forwarded)
                    .WithTriviaFrom(expressionStatement);

                return block.ReplaceNode(expressionStatement, replacement);
            }

            default:
                return null;
        }
    }

    /// <summary>
    /// Turns <c>await X().ConfigureAwait(false)</c> into <c>X()</c>.
    /// </summary>
    /// <remarks>
    /// The <c>ConfigureAwait</c> call is dropped rather than preserved, and deliberately so: it
    /// configured how <em>this</em> method resumed, and after the rewrite this method no longer resumes
    /// at all. The caller makes that choice when it awaits the returned ValueTask.
    /// </remarks>
    private static ExpressionSyntax? Unwrap(ExpressionSyntax expression)
    {
        if (expression is not AwaitExpressionSyntax await)
        {
            return null;
        }

        ExpressionSyntax inner = await.Expression;

        if (inner is InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax member }
            && member.Name.Identifier.Text == "ConfigureAwait")
        {
            inner = member.Expression;
        }

        return inner.WithTriviaFrom(await);
    }
}
