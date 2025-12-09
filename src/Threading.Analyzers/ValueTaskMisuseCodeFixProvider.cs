// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Editing;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Provides code fixes for ValueTask misuse patterns detected by <see cref="ValueTaskMisuseAnalyzer"/>.
/// </summary>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ValueTaskMisuseCodeFixProvider))]
[Shared]
public sealed class ValueTaskMisuseCodeFixProvider : CodeFixProvider
{
    /// <inheritdoc/>
    public override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(
        DiagnosticIds.MultipleAwait,
        DiagnosticIds.BlockingGetResult,
        DiagnosticIds.StoredInField,
        DiagnosticIds.MultipleAsTask,
        DiagnosticIds.DirectResultAccess,
        DiagnosticIds.AsTaskStoredBeforeSignal,
        DiagnosticIds.NotConsumed);

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
        var diagnosticSpan = diagnostic.Location.SourceSpan;
        var node = root.FindNode(diagnosticSpan);

        switch (diagnostic.Id)
        {
            case DiagnosticIds.MultipleAwait:
                RegisterMultipleAwaitFixes(context, root, node, diagnostic);
                break;

            case DiagnosticIds.BlockingGetResult:
                RegisterBlockingGetResultFixes(context, root, node, diagnostic);
                break;

            case DiagnosticIds.StoredInField:
                RegisterStoredInFieldFixes(context, root, node, diagnostic);
                break;

            case DiagnosticIds.MultipleAsTask:
                RegisterMultipleAsTaskFixes(context, root, node, diagnostic);
                break;

            case DiagnosticIds.DirectResultAccess:
                RegisterDirectResultAccessFixes(context, root, node, diagnostic);
                break;

            case DiagnosticIds.AsTaskStoredBeforeSignal:
                RegisterAsTaskStoredFixes(context, root, node, diagnostic);
                break;

            case DiagnosticIds.NotConsumed:
                RegisterNotConsumedFixes(context, root, node, diagnostic);
                break;
        }
    }

    private static void RegisterMultipleAwaitFixes(CodeFixContext context, SyntaxNode root, SyntaxNode node, Diagnostic diagnostic)
    {
        // Fix 1: Convert to AsTask() at declaration
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Convert to AsTask() at declaration",
                createChangedDocument: c => ConvertToAsTaskAtDeclarationAsync(context.Document, node, c),
                equivalenceKey: "ConvertToAsTask"),
            diagnostic);

        // Fix 2: Use Preserve() extension method
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Use Preserve() for safe consumption",
                createChangedDocument: c => UsePreserveAsync(context.Document, node, c),
                equivalenceKey: "UsePreserve"),
            diagnostic);
    }

    private static void RegisterBlockingGetResultFixes(CodeFixContext context, SyntaxNode root, SyntaxNode node, Diagnostic diagnostic)
    {
        // Fix 1: Convert to await
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Convert to await",
                createChangedDocument: c => ConvertGetResultToAwaitAsync(context.Document, node, c),
                equivalenceKey: "ConvertToAwait"),
            diagnostic);

        // Fix 2: Use AsTask().GetAwaiter().GetResult() if blocking is necessary
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Use AsTask() before GetAwaiter().GetResult()",
                createChangedDocument: c => WrapWithAsTaskAsync(context.Document, node, c),
                equivalenceKey: "WrapWithAsTask"),
            diagnostic);
    }

    private static void RegisterStoredInFieldFixes(CodeFixContext context, SyntaxNode root, SyntaxNode node, Diagnostic diagnostic)
    {
        // Fix: Change field type to Task
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Change type to Task and use AsTask()",
                createChangedDocument: c => ChangeFieldTypeToTaskAsync(context.Document, node, c),
                equivalenceKey: "ChangeToTask"),
            diagnostic);
    }

    private static void RegisterMultipleAsTaskFixes(CodeFixContext context, SyntaxNode root, SyntaxNode node, Diagnostic diagnostic)
    {
        // Fix: Store AsTask() result in variable
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Store AsTask() result in a variable",
                createChangedDocument: c => StoreAsTaskResultAsync(context.Document, node, c),
                equivalenceKey: "StoreAsTask"),
            diagnostic);
    }

    private static void RegisterDirectResultAccessFixes(CodeFixContext context, SyntaxNode root, SyntaxNode node, Diagnostic diagnostic)
    {
        // Fix 1: Convert to await
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Convert to await",
                createChangedDocument: c => ConvertResultToAwaitAsync(context.Document, node, c),
                equivalenceKey: "ConvertResultToAwait"),
            diagnostic);

        // Fix 2: Use AsTask().Result
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Use AsTask().Result",
                createChangedDocument: c => UseAsTaskResultAsync(context.Document, node, c),
                equivalenceKey: "UseAsTaskResult"),
            diagnostic);
    }

    private static void RegisterAsTaskStoredFixes(CodeFixContext context, SyntaxNode root, SyntaxNode node, Diagnostic diagnostic)
    {
        // Fix: Await ValueTask directly
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Await ValueTask directly for better performance",
                createChangedDocument: c => ConvertStoredAsTaskToDirectAwaitAsync(context.Document, node, c),
                equivalenceKey: "AwaitDirectly"),
            diagnostic);
    }

    private static void RegisterNotConsumedFixes(CodeFixContext context, SyntaxNode root, SyntaxNode node, Diagnostic diagnostic)
    {
        // Fix 1: Add await
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Add await",
                createChangedDocument: c => AddAwaitAsync(context.Document, node, c),
                equivalenceKey: "AddAwait"),
            diagnostic);

        // Fix 2: Discard with _ =
        context.RegisterCodeFix(
            CodeAction.Create(
                title: "Explicitly discard with _ =",
                createChangedDocument: c => AddDiscardAsync(context.Document, node, c),
                equivalenceKey: "AddDiscard"),
            diagnostic);
    }

    private static async Task<Document> ConvertToAsTaskAtDeclarationAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
        if (semanticModel is null)
        {
            return document;
        }

        // Find the variable declaration
        var identifier = node as IdentifierNameSyntax ?? node.DescendantNodesAndSelf().OfType<IdentifierNameSyntax>().FirstOrDefault();
        if (identifier is null)
        {
            return document;
        }

        var symbolInfo = semanticModel.GetSymbolInfo(identifier, cancellationToken);
        if (symbolInfo.Symbol is not ILocalSymbol localSymbol)
        {
            return document;
        }

        var syntaxReference = localSymbol.DeclaringSyntaxReferences.FirstOrDefault();
        if (syntaxReference is null)
        {
            return document;
        }

        var declaringSyntax = await syntaxReference.GetSyntaxAsync(cancellationToken).ConfigureAwait(false);
        if (declaringSyntax is not VariableDeclaratorSyntax variableDeclarator ||
            variableDeclarator.Initializer is null)
        {
            return document;
        }

        // Add .AsTask() to the initializer
        var newInitializer = SyntaxFactory.InvocationExpression(
            SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                variableDeclarator.Initializer.Value,
                SyntaxFactory.IdentifierName("AsTask")));

        var newVariableDeclarator = variableDeclarator.WithInitializer(
            variableDeclarator.Initializer.WithValue(newInitializer));

        // Also change the type to Task if it's explicit
        if (variableDeclarator.Parent is VariableDeclarationSyntax declaration &&
            declaration.Type is not null &&
            !declaration.Type.IsVar)
        {
            var typeInfo = semanticModel.GetTypeInfo(variableDeclarator.Initializer.Value, cancellationToken);
            TypeSyntax newType;
            if (typeInfo.Type is INamedTypeSymbol namedType && namedType.IsGenericType)
            {
                var typeArg = namedType.TypeArguments.First();
                newType = SyntaxFactory.GenericName("Task")
                    .WithTypeArgumentList(SyntaxFactory.TypeArgumentList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.ParseTypeName(typeArg.ToDisplayString()))));
            }
            else
            {
                newType = SyntaxFactory.ParseTypeName("Task");
            }

            var newDeclaration = declaration.WithType(newType).WithVariables(
                SyntaxFactory.SingletonSeparatedList(newVariableDeclarator));

            root = root.ReplaceNode(declaration, newDeclaration);
        }
        else
        {
            root = root.ReplaceNode(variableDeclarator, newVariableDeclarator);
        }

        return document.WithSyntaxRoot(root);
    }

    private static async Task<Document> UsePreserveAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
        if (semanticModel is null)
        {
            return document;
        }

        // Find the variable declaration
        var identifier = node as IdentifierNameSyntax ?? node.DescendantNodesAndSelf().OfType<IdentifierNameSyntax>().FirstOrDefault();
        if (identifier is null)
        {
            return document;
        }

        var symbolInfo = semanticModel.GetSymbolInfo(identifier, cancellationToken);
        if (symbolInfo.Symbol is not ILocalSymbol localSymbol)
        {
            return document;
        }

        var syntaxReference = localSymbol.DeclaringSyntaxReferences.FirstOrDefault();
        if (syntaxReference is null)
        {
            return document;
        }

        var declaringSyntax = await syntaxReference.GetSyntaxAsync(cancellationToken).ConfigureAwait(false);
        if (declaringSyntax is not VariableDeclaratorSyntax variableDeclarator ||
            variableDeclarator.Initializer is null)
        {
            return document;
        }

        // Add .Preserve() to the initializer
        var newInitializer = SyntaxFactory.InvocationExpression(
            SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                variableDeclarator.Initializer.Value,
                SyntaxFactory.IdentifierName("Preserve")));

        var newVariableDeclarator = variableDeclarator.WithInitializer(
            variableDeclarator.Initializer.WithValue(newInitializer));

        root = root.ReplaceNode(variableDeclarator, newVariableDeclarator);
        return document.WithSyntaxRoot(root);
    }

    private static async Task<Document> ConvertGetResultToAwaitAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        // Find the GetAwaiter().GetResult() invocation
        var invocation = node.AncestorsAndSelf().OfType<InvocationExpressionSyntax>().FirstOrDefault();
        if (invocation?.Expression is not MemberAccessExpressionSyntax memberAccess ||
            memberAccess.Name.Identifier.Text != "GetResult")
        {
            return document;
        }

        if (memberAccess.Expression is not InvocationExpressionSyntax getAwaiterCall ||
            getAwaiterCall.Expression is not MemberAccessExpressionSyntax getAwaiterAccess)
        {
            return document;
        }

        // Create await expression
        var awaitExpression = SyntaxFactory.AwaitExpression(getAwaiterAccess.Expression)
            .WithLeadingTrivia(invocation.GetLeadingTrivia())
            .WithTrailingTrivia(invocation.GetTrailingTrivia());

        root = root.ReplaceNode(invocation, awaitExpression);
        return document.WithSyntaxRoot(root);
    }

    private static async Task<Document> WrapWithAsTaskAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        // Find the GetAwaiter().GetResult() invocation
        var invocation = node.AncestorsAndSelf().OfType<InvocationExpressionSyntax>().FirstOrDefault();
        if (invocation?.Expression is not MemberAccessExpressionSyntax memberAccess ||
            memberAccess.Name.Identifier.Text != "GetResult")
        {
            return document;
        }

        if (memberAccess.Expression is not InvocationExpressionSyntax getAwaiterCall ||
            getAwaiterCall.Expression is not MemberAccessExpressionSyntax getAwaiterAccess)
        {
            return document;
        }

        // Wrap the ValueTask with AsTask()
        var asTaskCall = SyntaxFactory.InvocationExpression(
            SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                getAwaiterAccess.Expression,
                SyntaxFactory.IdentifierName("AsTask")));

        var newGetAwaiterAccess = getAwaiterAccess.WithExpression(asTaskCall);
        var newGetAwaiterCall = getAwaiterCall.WithExpression(newGetAwaiterAccess);
        var newMemberAccess = memberAccess.WithExpression(newGetAwaiterCall);
        var newInvocation = invocation.WithExpression(newMemberAccess);

        root = root.ReplaceNode(invocation, newInvocation);
        return document.WithSyntaxRoot(root);
    }

    private static async Task<Document> ChangeFieldTypeToTaskAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
        if (semanticModel is null)
        {
            return document;
        }

        // Handle field declaration
        if (node is VariableDeclaratorSyntax variableDeclarator &&
            variableDeclarator.Parent is VariableDeclarationSyntax declaration &&
            declaration.Parent is FieldDeclarationSyntax)
        {
            var typeInfo = semanticModel.GetTypeInfo(declaration.Type, cancellationToken);
            TypeSyntax newType;

            if (typeInfo.Type is INamedTypeSymbol namedType && namedType.IsGenericType)
            {
                var typeArg = namedType.TypeArguments.First();
                newType = SyntaxFactory.GenericName("Task")
                    .WithTypeArgumentList(SyntaxFactory.TypeArgumentList(
                        SyntaxFactory.SingletonSeparatedList(
                            SyntaxFactory.ParseTypeName(typeArg.ToDisplayString()))));
            }
            else
            {
                newType = SyntaxFactory.ParseTypeName("Task");
            }

            var newDeclaration = declaration.WithType(newType);
            root = root.ReplaceNode(declaration, newDeclaration);
            return document.WithSyntaxRoot(root);
        }

        return document;
    }

    private static async Task<Document> StoreAsTaskResultAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        // This is complex refactoring - for now, just add a comment suggesting manual fix
        return document;
    }

    private static async Task<Document> ConvertResultToAwaitAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        var memberAccess = node.AncestorsAndSelf().OfType<MemberAccessExpressionSyntax>()
            .FirstOrDefault(m => m.Name.Identifier.Text == "Result");

        if (memberAccess is null)
        {
            return document;
        }

        var awaitExpression = SyntaxFactory.AwaitExpression(memberAccess.Expression)
            .WithLeadingTrivia(memberAccess.GetLeadingTrivia())
            .WithTrailingTrivia(memberAccess.GetTrailingTrivia());

        root = root.ReplaceNode(memberAccess, awaitExpression);
        return document.WithSyntaxRoot(root);
    }

    private static async Task<Document> UseAsTaskResultAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        var memberAccess = node.AncestorsAndSelf().OfType<MemberAccessExpressionSyntax>()
            .FirstOrDefault(m => m.Name.Identifier.Text == "Result");

        if (memberAccess is null)
        {
            return document;
        }

        // Wrap with AsTask()
        var asTaskCall = SyntaxFactory.InvocationExpression(
            SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                memberAccess.Expression,
                SyntaxFactory.IdentifierName("AsTask")));

        var newMemberAccess = SyntaxFactory.MemberAccessExpression(
            SyntaxKind.SimpleMemberAccessExpression,
            asTaskCall,
            SyntaxFactory.IdentifierName("Result"));

        root = root.ReplaceNode(memberAccess, newMemberAccess);
        return document.WithSyntaxRoot(root);
    }

    private static async Task<Document> ConvertStoredAsTaskToDirectAwaitAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        // Find the variable declaration with AsTask()
        var variableDeclarator = node.AncestorsAndSelf().OfType<VariableDeclaratorSyntax>().FirstOrDefault();
        if (variableDeclarator?.Initializer?.Value is InvocationExpressionSyntax invocation &&
            invocation.Expression is MemberAccessExpressionSyntax memberAccess &&
            memberAccess.Name.Identifier.Text == "AsTask")
        {
            // Remove the AsTask() call
            var newInitializer = variableDeclarator.Initializer.WithValue(memberAccess.Expression);
            var newDeclarator = variableDeclarator.WithInitializer(newInitializer);

            // Update type to ValueTask if explicit
            if (variableDeclarator.Parent is VariableDeclarationSyntax declaration &&
                !declaration.Type.IsVar)
            {
                var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
                if (semanticModel is not null)
                {
                    var typeInfo = semanticModel.GetTypeInfo(memberAccess.Expression, cancellationToken);
                    if (typeInfo.Type is not null)
                    {
                        var newType = SyntaxFactory.ParseTypeName(typeInfo.Type.ToDisplayString());
                        var newDeclaration = declaration.WithType(newType).WithVariables(
                            SyntaxFactory.SingletonSeparatedList(newDeclarator));
                        root = root.ReplaceNode(declaration, newDeclaration);
                        return document.WithSyntaxRoot(root);
                    }
                }
            }

            root = root.ReplaceNode(variableDeclarator, newDeclarator);
            return document.WithSyntaxRoot(root);
        }

        return document;
    }

    private static async Task<Document> AddAwaitAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        var invocation = node as InvocationExpressionSyntax ??
                         node.AncestorsAndSelf().OfType<InvocationExpressionSyntax>().FirstOrDefault();

        if (invocation is null)
        {
            return document;
        }

        var awaitExpression = SyntaxFactory.AwaitExpression(invocation)
            .WithLeadingTrivia(invocation.GetLeadingTrivia())
            .WithTrailingTrivia(invocation.GetTrailingTrivia());

        root = root.ReplaceNode(invocation, awaitExpression);
        return document.WithSyntaxRoot(root);
    }

    private static async Task<Document> AddDiscardAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null)
        {
            return document;
        }

        var expressionStatement = node.AncestorsAndSelf().OfType<ExpressionStatementSyntax>().FirstOrDefault();
        if (expressionStatement is null)
        {
            return document;
        }

        // Create: _ = expression;
        var discardAssignment = SyntaxFactory.AssignmentExpression(
            SyntaxKind.SimpleAssignmentExpression,
            SyntaxFactory.IdentifierName("_"),
            expressionStatement.Expression);

        var newStatement = SyntaxFactory.ExpressionStatement(discardAssignment)
            .WithLeadingTrivia(expressionStatement.GetLeadingTrivia())
            .WithTrailingTrivia(expressionStatement.GetTrailingTrivia());

        root = root.ReplaceNode(expressionStatement, newStatement);
        return document.WithSyntaxRoot(root);
    }
}
