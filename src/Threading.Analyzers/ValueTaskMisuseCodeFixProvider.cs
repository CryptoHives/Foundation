// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Simplification;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Provides code fixes for ValueTask misuse patterns detected by <see cref="ValueTaskMisuseAnalyzer"/>.
/// </summary>
/// <remarks>
/// A fix is only offered where it produces code that compiles: an <c>await</c> only inside an
/// <see langword="async"/> function, and a type change only where every use of the declaration can be
/// rewritten with it.
/// </remarks>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ValueTaskMisuseCodeFixProvider))]
[Shared]
public sealed class ValueTaskMisuseCodeFixProvider : CodeFixProvider
{
    /// <inheritdoc/>
    public override ImmutableArray<string> FixableDiagnosticIds { get; } = ImmutableArray.Create(
        DiagnosticIds.MultipleAwait,
        DiagnosticIds.BlockingGetResult,
        DiagnosticIds.StoredInField,
        DiagnosticIds.DirectResultAccess,
        DiagnosticIds.AsTaskStoredBeforeSignal,
        DiagnosticIds.NotConsumed);

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
            RegisterFixes(context, model, root.FindNode(diagnostic.Location.SourceSpan), diagnostic);
        }
    }

    private static void RegisterFixes(CodeFixContext context, SemanticModel model, SyntaxNode node, Diagnostic diagnostic)
    {
        bool inAsync = IsInAsyncFunction(node);

        switch (diagnostic.Id)
        {
            case DiagnosticIds.MultipleAwait:
                RegisterMultipleAwaitFixes(context, model, node, diagnostic);
                break;

            case DiagnosticIds.BlockingGetResult:
                if (inAsync)
                {
                    Register(context, diagnostic, "Convert to await", "ConvertToAwait",
                        c => ConvertGetResultToAwaitAsync(context.Document, node, c));
                }

                Register(context, diagnostic, "Use AsTask() before GetAwaiter().GetResult()", "WrapWithAsTask",
                    c => WrapWithAsTaskAsync(context.Document, node, c));
                break;

            case DiagnosticIds.StoredInField:
                if (CanChangeFieldType(model, node, context.CancellationToken))
                {
                    Register(context, diagnostic, "Change type to Task and use AsTask()", "ChangeToTask",
                        c => ChangeFieldTypeToTaskAsync(context.Document, node, c));
                }

                break;

            case DiagnosticIds.DirectResultAccess:
                if (inAsync)
                {
                    Register(context, diagnostic, "Convert to await", "ConvertResultToAwait",
                        c => ConvertResultToAwaitAsync(context.Document, node, c));
                }

                Register(context, diagnostic, "Use AsTask().Result", "UseAsTaskResult",
                    c => UseAsTaskResultAsync(context.Document, node, c));
                break;

            case DiagnosticIds.AsTaskStoredBeforeSignal:
                if (node is VariableDeclaratorSyntax { Parent: VariableDeclarationSyntax declaration } &&
                    (declaration.Type.IsVar || declaration.Variables.Count == 1))
                {
                    Register(context, diagnostic, "Await ValueTask directly for better performance", "AwaitDirectly",
                        c => ConvertStoredAsTaskToDirectAwaitAsync(context.Document, node, c));
                }

                break;

            case DiagnosticIds.NotConsumed:
                if (inAsync)
                {
                    Register(context, diagnostic, "Add await", "AddAwait",
                        c => AddAwaitAsync(context.Document, node, c));
                }

                Register(context, diagnostic, "Explicitly discard with _ =", "AddDiscard",
                    c => AddDiscardAsync(context.Document, node, c));
                break;
        }
    }

    private static void Register(
        CodeFixContext context,
        Diagnostic diagnostic,
        string title,
        string equivalenceKey,
        System.Func<CancellationToken, Task<Document>> createChangedDocument)
        => context.RegisterCodeFix(CodeAction.Create(title, createChangedDocument, equivalenceKey), diagnostic);

    private static void RegisterMultipleAwaitFixes(CodeFixContext context, SemanticModel model, SyntaxNode node, Diagnostic diagnostic)
    {
        VariableDeclaratorSyntax? declarator = FindLocalDeclarator(model, node, context.CancellationToken);
        if (declarator?.Initializer is null || declarator.Parent is not VariableDeclarationSyntax declaration)
        {
            return;
        }

        // Retyping the declaration would retype every declarator in it, so it is only done for one.
        if (declaration.Type.IsVar || declaration.Variables.Count == 1)
        {
            Register(context, diagnostic, "Convert to AsTask() at declaration", "ConvertToAsTask",
                c => ConvertToAsTaskAtDeclarationAsync(context.Document, declarator, c));
        }

        Register(context, diagnostic, "Use Preserve() for safe consumption", "UsePreserve",
            c => UsePreserveAsync(context.Document, declarator, c));
    }

    /// <summary>
    /// Whether the nearest enclosing function is <see langword="async"/>, so an <c>await</c> may be
    /// introduced at <paramref name="node"/>.
    /// </summary>
    private static bool IsInAsyncFunction(SyntaxNode node)
    {
        foreach (SyntaxNode ancestor in node.AncestorsAndSelf())
        {
            switch (ancestor)
            {
                case AnonymousFunctionExpressionSyntax function:
                    return function.AsyncKeyword.IsKind(SyntaxKind.AsyncKeyword);
                case LocalFunctionStatementSyntax local:
                    return local.Modifiers.Any(SyntaxKind.AsyncKeyword);
                case MethodDeclarationSyntax method:
                    return method.Modifiers.Any(SyntaxKind.AsyncKeyword);
                case MemberDeclarationSyntax:
                    return false;
            }
        }

        return false;
    }

    private static VariableDeclaratorSyntax? FindLocalDeclarator(SemanticModel model, SyntaxNode node, CancellationToken cancellationToken)
    {
        IdentifierNameSyntax? identifier = node as IdentifierNameSyntax
            ?? node.DescendantNodesAndSelf().OfType<IdentifierNameSyntax>().FirstOrDefault();
        if (identifier is null || model.GetSymbolInfo(identifier, cancellationToken).Symbol is not ILocalSymbol local)
        {
            return null;
        }

        return local.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax(cancellationToken) as VariableDeclaratorSyntax;
    }

    /// <summary>
    /// <c>expression.Name()</c>, parenthesizing the receiver where precedence needs it; the simplifier
    /// removes parentheses that turn out to be unnecessary.
    /// </summary>
    private static InvocationExpressionSyntax Call(ExpressionSyntax receiver, string name)
        => SyntaxFactory.InvocationExpression(
            SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                Parenthesize(receiver.WithoutTrivia()),
                SyntaxFactory.IdentifierName(name)))
            .WithTriviaFrom(receiver);

    private static ExpressionSyntax Parenthesize(ExpressionSyntax expression)
        => SyntaxFactory.ParenthesizedExpression(expression).WithAdditionalAnnotations(Simplifier.Annotation);

    /// <summary>
    /// The shortest spelling of <paramref name="type"/> at <paramref name="position"/>, carrying the trivia
    /// of the type it replaces.
    /// </summary>
    private static TypeSyntax MinimalType(ITypeSymbol type, SemanticModel model, int position, TypeSyntax replacing)
        => SyntaxFactory.ParseTypeName(type.ToMinimalDisplayString(model, position)).WithTriviaFrom(replacing);

    /// <summary>
    /// <c>Task</c> for <c>ValueTask</c> and <c>Task&lt;T&gt;</c> for <c>ValueTask&lt;T&gt;</c>.
    /// </summary>
    private static ITypeSymbol? TaskTypeFor(ITypeSymbol? valueTaskType, Compilation compilation)
    {
        if (valueTaskType is not INamedTypeSymbol named)
        {
            return null;
        }

        if (!named.IsGenericType)
        {
            return compilation.GetTypeByMetadataName("System.Threading.Tasks.Task");
        }

        return compilation.GetTypeByMetadataName("System.Threading.Tasks.Task`1")?.Construct(named.TypeArguments[0]);
    }

    private static async Task<Document> ConvertToAsTaskAtDeclarationAsync(Document document, VariableDeclaratorSyntax declarator, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        SemanticModel? model = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
        if (root is null || model is null || declarator.Initializer is null ||
            declarator.Parent is not VariableDeclarationSyntax declaration)
        {
            return document;
        }

        VariableDeclaratorSyntax newDeclarator = declarator.WithInitializer(
            declarator.Initializer.WithValue(Call(declarator.Initializer.Value, "AsTask")));

        if (declaration.Type.IsVar)
        {
            return document.WithSyntaxRoot(root.ReplaceNode(declarator, newDeclarator));
        }

        ITypeSymbol? taskType = TaskTypeFor(model.GetTypeInfo(declaration.Type, cancellationToken).Type, model.Compilation);
        if (taskType is null)
        {
            return document;
        }

        VariableDeclarationSyntax newDeclaration = declaration
            .WithType(MinimalType(taskType, model, declaration.SpanStart, declaration.Type))
            .WithVariables(SyntaxFactory.SingletonSeparatedList(newDeclarator));

        return document.WithSyntaxRoot(root.ReplaceNode(declaration, newDeclaration));
    }

    private static async Task<Document> UsePreserveAsync(Document document, VariableDeclaratorSyntax declarator, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null || declarator.Initializer is null)
        {
            return document;
        }

        VariableDeclaratorSyntax newDeclarator = declarator.WithInitializer(
            declarator.Initializer.WithValue(Call(declarator.Initializer.Value, "Preserve")));

        return document.WithSyntaxRoot(root.ReplaceNode(declarator, newDeclarator));
    }

    private static async Task<Document> ConvertGetResultToAwaitAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null || FindGetResultCall(node) is not (InvocationExpressionSyntax invocation, MemberAccessExpressionSyntax getAwaiterAccess))
        {
            return document;
        }

        ExpressionSyntax awaitExpression = Parenthesize(SyntaxFactory.AwaitExpression(getAwaiterAccess.Expression.WithoutTrivia()))
            .WithTriviaFrom(invocation);

        return document.WithSyntaxRoot(root.ReplaceNode(invocation, awaitExpression));
    }

    private static async Task<Document> WrapWithAsTaskAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        if (root is null || FindGetResultCall(node) is not (InvocationExpressionSyntax, MemberAccessExpressionSyntax getAwaiterAccess))
        {
            return document;
        }

        // Task has its own ConfigureAwait, so a configured ValueTask converts before the call.
        ExpressionSyntax valueTask = getAwaiterAccess.Expression is InvocationExpressionSyntax {
            Expression: MemberAccessExpressionSyntax { Name.Identifier.Text: "ConfigureAwait" } configure
        }
            ? configure.Expression
            : getAwaiterAccess.Expression;

        return document.WithSyntaxRoot(root.ReplaceNode(valueTask, Call(valueTask, "AsTask")));
    }

    /// <summary>
    /// The <c>x.GetAwaiter().GetResult()</c> call at or around <paramref name="node"/>, with the
    /// <c>x.GetAwaiter</c> member access whose receiver is the ValueTask.
    /// </summary>
    private static (InvocationExpressionSyntax Invocation, MemberAccessExpressionSyntax GetAwaiterAccess)? FindGetResultCall(SyntaxNode node)
    {
        InvocationExpressionSyntax? invocation = node.AncestorsAndSelf().OfType<InvocationExpressionSyntax>().FirstOrDefault();
        if (invocation?.Expression is MemberAccessExpressionSyntax { Name.Identifier.Text: "GetResult" } getResult &&
            getResult.Expression is InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax getAwaiterAccess })
        {
            return (invocation, getAwaiterAccess);
        }

        return null;
    }

    /// <summary>
    /// The field fix changes the declared type and every assignment to the field, so it is only offered
    /// where all of them are in this document: a private field of a type declared in one part, declared
    /// on its own.
    /// </summary>
    private static bool CanChangeFieldType(SemanticModel model, SyntaxNode node, CancellationToken cancellationToken)
        => node is VariableDeclaratorSyntax { Parent: VariableDeclarationSyntax { Variables.Count: 1, Parent: FieldDeclarationSyntax } } declarator &&
            model.GetDeclaredSymbol(declarator, cancellationToken) is IFieldSymbol { DeclaredAccessibility: Accessibility.Private } field &&
            field.ContainingType.DeclaringSyntaxReferences.Length == 1;

    private static async Task<Document> ChangeFieldTypeToTaskAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        SemanticModel? model = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
        if (root is null || model is null ||
            node is not VariableDeclaratorSyntax { Parent: VariableDeclarationSyntax declaration } declarator ||
            model.GetDeclaredSymbol(declarator, cancellationToken) is not IFieldSymbol field)
        {
            return document;
        }

        ITypeSymbol? taskType = TaskTypeFor(field.Type, model.Compilation);
        if (taskType is null)
        {
            return document;
        }

        // Every ValueTask stored into the field now has to be converted on the way in.
        var converted = new List<SyntaxNode>();
        if (declarator.Initializer is not null)
        {
            converted.Add(declarator.Initializer.Value);
        }

        foreach (AssignmentExpressionSyntax assignment in root.DescendantNodes().OfType<AssignmentExpressionSyntax>())
        {
            if (assignment.IsKind(SyntaxKind.SimpleAssignmentExpression) &&
                SymbolEqualityComparer.Default.Equals(model.GetSymbolInfo(assignment.Left, cancellationToken).Symbol, field))
            {
                converted.Add(assignment.Right);
            }
        }

        TypeSyntax newType = MinimalType(taskType, model, declaration.SpanStart, declaration.Type);

        SyntaxNode newRoot = root.ReplaceNodes(
            converted.Append(declaration.Type),
            (original, rewritten) => original == declaration.Type
                ? newType
                : Call((ExpressionSyntax)rewritten, "AsTask"));

        return document.WithSyntaxRoot(newRoot);
    }

    private static async Task<Document> ConvertResultToAwaitAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        MemberAccessExpressionSyntax? memberAccess = node.AncestorsAndSelf().OfType<MemberAccessExpressionSyntax>()
            .FirstOrDefault(m => m.Name.Identifier.Text == "Result");
        if (root is null || memberAccess is null)
        {
            return document;
        }

        ExpressionSyntax awaitExpression = Parenthesize(SyntaxFactory.AwaitExpression(memberAccess.Expression.WithoutTrivia()))
            .WithTriviaFrom(memberAccess);

        return document.WithSyntaxRoot(root.ReplaceNode(memberAccess, awaitExpression));
    }

    private static async Task<Document> UseAsTaskResultAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        MemberAccessExpressionSyntax? memberAccess = node.AncestorsAndSelf().OfType<MemberAccessExpressionSyntax>()
            .FirstOrDefault(m => m.Name.Identifier.Text == "Result");
        if (root is null || memberAccess is null)
        {
            return document;
        }

        return document.WithSyntaxRoot(root.ReplaceNode(
            memberAccess.Expression,
            Call(memberAccess.Expression, "AsTask")));
    }

    private static async Task<Document> ConvertStoredAsTaskToDirectAwaitAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        SemanticModel? model = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
        if (root is null || model is null ||
            node is not VariableDeclaratorSyntax { Parent: VariableDeclarationSyntax declaration } declarator ||
            declarator.Initializer?.Value is not InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax asTask })
        {
            return document;
        }

        VariableDeclaratorSyntax newDeclarator = declarator.WithInitializer(
            declarator.Initializer.WithValue(asTask.Expression.WithTriviaFrom(declarator.Initializer.Value)));

        if (declaration.Type.IsVar)
        {
            return document.WithSyntaxRoot(root.ReplaceNode(declarator, newDeclarator));
        }

        ITypeSymbol? valueTaskType = model.GetTypeInfo(asTask.Expression, cancellationToken).Type;
        if (valueTaskType is null)
        {
            return document;
        }

        VariableDeclarationSyntax newDeclaration = declaration
            .WithType(MinimalType(valueTaskType, model, declaration.SpanStart, declaration.Type))
            .WithVariables(SyntaxFactory.SingletonSeparatedList(newDeclarator));

        return document.WithSyntaxRoot(root.ReplaceNode(declaration, newDeclaration));
    }

    private static async Task<Document> AddAwaitAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        InvocationExpressionSyntax? invocation = node as InvocationExpressionSyntax
            ?? node.AncestorsAndSelf().OfType<InvocationExpressionSyntax>().FirstOrDefault();
        if (root is null || invocation is null)
        {
            return document;
        }

        AwaitExpressionSyntax awaitExpression = SyntaxFactory.AwaitExpression(invocation.WithoutTrivia())
            .WithTriviaFrom(invocation);

        return document.WithSyntaxRoot(root.ReplaceNode(invocation, awaitExpression));
    }

    /// <summary>
    /// <c>_ = Call()</c> in place of the call, which works the same as a statement and as the body of an
    /// expression-bodied lambda or member.
    /// </summary>
    private static async Task<Document> AddDiscardAsync(Document document, SyntaxNode node, CancellationToken cancellationToken)
    {
        SyntaxNode? root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
        InvocationExpressionSyntax? invocation = node as InvocationExpressionSyntax
            ?? node.AncestorsAndSelf().OfType<InvocationExpressionSyntax>().FirstOrDefault();
        if (root is null || invocation is null)
        {
            return document;
        }

        AssignmentExpressionSyntax discardAssignment = SyntaxFactory.AssignmentExpression(
                SyntaxKind.SimpleAssignmentExpression,
                SyntaxFactory.IdentifierName("_"),
                invocation.WithoutTrivia())
            .WithTriviaFrom(invocation);

        return document.WithSyntaxRoot(root.ReplaceNode(invocation, discardAssignment));
    }
}
