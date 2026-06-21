// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Provides a code fix for <see cref="DiagnosticIds.SemaphoreSlimAsAsyncLock"/> (CHT009)
/// that replaces <c>new SemaphoreSlim(1, 1)</c> with <c>new AsyncLock()</c> and adds the
/// required <c>using</c> directive.
/// </summary>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(SemaphoreSlimAsAsyncLockCodeFixProvider))]
[Shared]
public sealed class SemaphoreSlimAsAsyncLockCodeFixProvider : CodeFixProvider
{
    private const string AsyncLockNamespace = "CryptoHives.Foundation.Threading.Async.Pooled";
    private const string AsyncLockTypeName = "AsyncLock";

    /// <inheritdoc/>
    public override ImmutableArray<string> FixableDiagnosticIds =>
        ImmutableArray.Create(DiagnosticIds.SemaphoreSlimAsAsyncLock);

    /// <inheritdoc/>
    public override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

    /// <inheritdoc/>
    public override async Task RegisterCodeFixesAsync(CodeFixContext context)
    {
        var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return;
        }

        var diagnostic = context.Diagnostics.First();
        var node = root.FindNode(diagnostic.Location.SourceSpan);

        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Replace with AsyncLock",
                createChangedDocument: ct => ReplaceWithAsyncLockAsync(context.Document, node, ct),
                equivalenceKey: "ReplaceWithAsyncLock"),
            diagnostic);
    }

    private static async Task<Document> ReplaceWithAsyncLockAsync(
        Document document,
        SyntaxNode node,
        CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        // Build `new AsyncLock()` with matching trivia.
        var asyncLockCreation = SyntaxFactory.ObjectCreationExpression(
                SyntaxFactory.IdentifierName(AsyncLockTypeName))
            .WithArgumentList(SyntaxFactory.ArgumentList())
            .WithLeadingTrivia(node.GetLeadingTrivia())
            .WithTrailingTrivia(node.GetTrailingTrivia());

        SyntaxNode newRoot;

        // When the creation sits inside a variable declaration, also update the declared type
        // (unless it is `var`).
        var variableDeclaration = node
            .AncestorsAndSelf()
            .OfType<VariableDeclarationSyntax>()
            .FirstOrDefault();

        if (variableDeclaration is not null && !variableDeclaration.Type.IsVar)
        {
            var newType = SyntaxFactory.IdentifierName(AsyncLockTypeName)
                .WithLeadingTrivia(variableDeclaration.Type.GetLeadingTrivia())
                .WithTrailingTrivia(variableDeclaration.Type.GetTrailingTrivia());

            // Replace creation expression and type in one pass.
            newRoot = root
                .ReplaceNodes(
                    new SyntaxNode[] { (SyntaxNode)variableDeclaration.Type, node },
                    (original, _) => original == variableDeclaration.Type
                        ? (SyntaxNode)newType
                        : asyncLockCreation);
        }
        else
        {
            newRoot = root.ReplaceNode(node, asyncLockCreation);
        }

        // Add `using CryptoHives.Foundation.Threading.Async.Pooled;` if not present.
        newRoot = EnsureUsingDirective(newRoot, AsyncLockNamespace);

        return document.WithSyntaxRoot(newRoot);
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

        var newUsing = SyntaxFactory.UsingDirective(
                SyntaxFactory.ParseName(" " + namespaceName))
            .WithTrailingTrivia(SyntaxFactory.ElasticCarriageReturnLineFeed);

        // Insert after the last existing using directive, or at the top of the file.
        if (compilationUnit.Usings.Count > 0)
        {
            var lastUsing = compilationUnit.Usings.Last();
            var newUsings = compilationUnit.Usings.Add(newUsing);
            return compilationUnit.WithUsings(newUsings);
        }

        return compilationUnit.AddUsings(newUsing);
    }
}
