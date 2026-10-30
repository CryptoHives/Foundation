// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

/// <summary>
/// Detects <see langword="async"/> methods returning <c>ValueTask</c> whose only job is to await and
/// forward a single inner <c>ValueTask</c>, where the state machine the compiler generates is either
/// pure overhead (CHT011) or a heap allocation the surrounding cleanup is paying for (CHT012).
/// </summary>
/// <remarks>
/// <para>
/// Both rules describe the same underlying cost. An async method's builder boxes its state machine the
/// first time the method suspends; when the method does nothing but forward one ValueTask, that box is
/// bought for nothing the caller could not have had by returning the inner ValueTask itself.
/// </para>
/// <para>
/// They are split because the remedies differ in kind. CHT011 fires when nothing stands in the way, so
/// the fix is mechanical and can be applied automatically. CHT012 fires when cleanup wraps the await -
/// the async machinery is genuinely load-bearing there, and removing it takes a redesign the analyzer
/// cannot perform or even prove is possible. Reporting them under one ID would force a single severity
/// on two very different asks.
/// </para>
/// </remarks>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class AsyncValueTaskBoxingAnalyzer : DiagnosticAnalyzer
{
    private static readonly ImmutableArray<DiagnosticDescriptor> s_supportedDiagnostics = ImmutableArray.Create(
        DiagnosticDescriptors.RedundantAsyncForwarding,
        DiagnosticDescriptors.AsyncWrapperBoxesStateMachine);

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => s_supportedDiagnostics;

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterCompilationStartAction(start => {
            ValueTaskTypes? types = ValueTaskTypes.Create(start.Compilation);
            if (types is null)
            {
                return;
            }

            start.RegisterSyntaxNodeAction(c => AnalyzeMethod(c, types), SyntaxKind.MethodDeclaration);
            start.RegisterSyntaxNodeAction(c => AnalyzeLocalFunction(c, types), SyntaxKind.LocalFunctionStatement);
        });
    }

    private static void AnalyzeMethod(SyntaxNodeAnalysisContext context, ValueTaskTypes types)
    {
        var method = (MethodDeclarationSyntax)context.Node;
        Analyze(context, types, method, method.Modifiers, method.AttributeLists, method.Body, method.ExpressionBody, method.Identifier.Text);
    }

    private static void AnalyzeLocalFunction(SyntaxNodeAnalysisContext context, ValueTaskTypes types)
    {
        var local = (LocalFunctionStatementSyntax)context.Node;
        Analyze(context, types, local, local.Modifiers, local.AttributeLists, local.Body, local.ExpressionBody, local.Identifier.Text);
    }

    private static void Analyze(
        SyntaxNodeAnalysisContext context,
        ValueTaskTypes types,
        SyntaxNode declaration,
        SyntaxTokenList modifiers,
        SyntaxList<AttributeListSyntax> attributeLists,
        BlockSyntax? body,
        ArrowExpressionClauseSyntax? expressionBody,
        string name)
    {
        if (!modifiers.Any(SyntaxKind.AsyncKeyword))
        {
            return;
        }

        // An explicit builder means the author has already made a deliberate decision about how this
        // method's state machine is allocated. Re-reporting would be noise, and would let the CHT012 fix
        // stack its attribute on a method that already has one.
        if (HasAsyncMethodBuilderAttribute(attributeLists))
        {
            return;
        }

        // Iterators suspend for reasons unrelated to the awaited operation, and their machinery cannot be
        // elided at all.
        if (modifiers.Any(SyntaxKind.PartialKeyword) || (body is null && expressionBody is null))
        {
            return;
        }

        if (context.SemanticModel.GetDeclaredSymbol(declaration, context.CancellationToken) is not IMethodSymbol symbol)
        {
            return;
        }

        if (!types.IsValueTask(symbol.ReturnType))
        {
            return;
        }

        SyntaxNode bodyNode = (SyntaxNode?)body ?? expressionBody!;

        // Nested lambdas and local functions compile into their own state machines, so their awaits say
        // nothing about this one.
        List<SyntaxNode> ownNodes = bodyNode
            .DescendantNodes(descendIntoChildren: node => !IsSeparateAsyncScope(node, bodyNode))
            .ToList();

        // `await foreach` and `await using` suspend too, without an await expression to show for it.
        if (ownNodes.Any(IsImplicitAwait))
        {
            return;
        }

        List<AwaitExpressionSyntax> awaits = ownNodes.OfType<AwaitExpressionSyntax>().ToList();
        if (awaits.Count != 1)
        {
            return;
        }

        AwaitExpressionSyntax await = awaits[0];

        // Only a forwarded ValueTask can be returned in place of the wrapper, and only one of exactly the
        // returned type: awaiting a Task would change the returned type, a ValueTask<int> forwarded from a
        // ValueTask<long> method relies on a conversion only the await performs, and awaiting something
        // already converted (AsTask, Preserve) means the caller asked for different semantics.
        if (!IsValueTaskExpression(context.SemanticModel, await.Expression, symbol.ReturnType, context.CancellationToken))
        {
            return;
        }

        if (!IsForwardedResult(await, SymbolEqualityComparer.Default.Equals(symbol.ReturnType, types.ValueTask)))
        {
            return;
        }

        // Any other return would still be a plain value once the method is no longer async.
        if (ownNodes.OfType<ReturnStatementSyntax>().Any(r => r.Expression != await))
        {
            return;
        }

        // Everything above establishes "this method forwards exactly one ValueTask". What separates the
        // two diagnostics is only whether cleanup stands between that and a direct return.
        DiagnosticDescriptor descriptor = HasEnclosingCleanup(await, bodyNode)
            ? DiagnosticDescriptors.AsyncWrapperBoxesStateMachine
            : DiagnosticDescriptors.RedundantAsyncForwarding;

        context.ReportDiagnostic(Diagnostic.Create(
            descriptor,
            GetReportLocation(declaration),
            name));
    }

    /// <summary>
    /// Whether the declaration already carries <c>[AsyncMethodBuilder]</c>, matched by syntax so the
    /// check costs nothing on the overwhelming majority of methods that have no attributes at all.
    /// </summary>
    private static bool HasAsyncMethodBuilderAttribute(SyntaxList<AttributeListSyntax> attributeLists)
    {
        foreach (AttributeListSyntax list in attributeLists)
        {
            foreach (AttributeSyntax attribute in list.Attributes)
            {
                string identifier = attribute.Name switch {
                    QualifiedNameSyntax qualified => qualified.Right.Identifier.Text,
                    SimpleNameSyntax simple => simple.Identifier.Text,
                    _ => string.Empty,
                };

                if (identifier is "AsyncMethodBuilder" or "AsyncMethodBuilderAttribute")
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Whether <paramref name="node"/> starts an async scope of its own, whose awaits belong to a
    /// different state machine than the one being analyzed.
    /// </summary>
    private static bool IsSeparateAsyncScope(SyntaxNode node, SyntaxNode bodyNode)
        => !ReferenceEquals(node, bodyNode)
            && node is AnonymousFunctionExpressionSyntax or LocalFunctionStatementSyntax;

    private static bool IsImplicitAwait(SyntaxNode node)
        => node switch {
            CommonForEachStatementSyntax forEach => forEach.AwaitKeyword.IsKind(SyntaxKind.AwaitKeyword),
            UsingStatementSyntax usingStatement => usingStatement.AwaitKeyword.IsKind(SyntaxKind.AwaitKeyword),
            LocalDeclarationStatementSyntax local => local.AwaitKeyword.IsKind(SyntaxKind.AwaitKeyword),
            _ => false,
        };

    /// <summary>
    /// Whether the awaited result is handed straight back to the caller, rather than being stored,
    /// inspected or combined with anything.
    /// </summary>
    private static bool IsForwardedResult(AwaitExpressionSyntax await, bool returnsNonGeneric)
    {
        SyntaxNode? parent = await.Parent;

        // ValueTask<T>: the await must be the returned expression, in either body form.
        if (parent is ReturnStatementSyntax or ArrowExpressionClauseSyntax)
        {
            return true;
        }

        // Non-generic ValueTask has no result to return, so a bare `await X();` is the forwarding shape -
        // provided nothing follows it.
        return returnsNonGeneric && parent is ExpressionStatementSyntax statement && IsLastInBody(statement);
    }

    /// <summary>
    /// Whether nothing in the method runs after <paramref name="statement"/>: it is last in the method
    /// body, or last in a <c>try</c> or <c>using</c> block that is itself last in the body. A trailing
    /// statement inside an if or loop is not the end of the method.
    /// </summary>
    private static bool IsLastInBody(StatementSyntax statement)
    {
        if (statement.Parent is not BlockSyntax block || !ReferenceEquals(block.Statements.LastOrDefault(), statement))
        {
            return false;
        }

        return block.Parent switch {
            MethodDeclarationSyntax or LocalFunctionStatementSyntax => true,
            TryStatementSyntax tryStatement => tryStatement.Block == block && IsLastInBody(tryStatement),
            UsingStatementSyntax usingStatement => IsLastInBody(usingStatement),
            _ => false,
        };
    }

    /// <summary>
    /// Whether cleanup wraps the await, which is what makes the async machinery load-bearing: the
    /// handler has to run after the awaited operation settles, and only an await boundary orders it that
    /// way.
    /// </summary>
    private static bool HasEnclosingCleanup(AwaitExpressionSyntax await, SyntaxNode bodyNode)
    {
        for (SyntaxNode? node = await.Parent; node is not null && !ReferenceEquals(node, bodyNode.Parent); node = node.Parent)
        {
            switch (node)
            {
                case TryStatementSyntax:
                case UsingStatementSyntax:
                    return true;
                case LocalDeclarationStatementSyntax local when local.UsingKeyword != default:
                    return true;
                default:
                    break;
            }
        }

        // A `using` declaration anywhere earlier in the body also produces a finally around the await.
        return bodyNode
            .DescendantNodes(descendIntoChildren: node => !IsSeparateAsyncScope(node, bodyNode))
            .OfType<LocalDeclarationStatementSyntax>()
            .Any(local => local.UsingKeyword != default);
    }

    private static Location GetReportLocation(SyntaxNode declaration)
        => declaration switch {
            MethodDeclarationSyntax method => method.Identifier.GetLocation(),
            LocalFunctionStatementSyntax local => local.Identifier.GetLocation(),
            _ => declaration.GetLocation(),
        };

    /// <summary>
    /// Whether the expression is of exactly <paramref name="returnType"/>, a ValueTask the caller has
    /// already checked, seeing through a trailing <c>ConfigureAwait</c> - which returns a
    /// configured-awaitable struct rather than the ValueTask itself, but does not change what is being
    /// forwarded.
    /// </summary>
    private static bool IsValueTaskExpression(SemanticModel model, ExpressionSyntax expression, ITypeSymbol returnType, System.Threading.CancellationToken cancellationToken)
    {
        ExpressionSyntax unwrapped = expression;

        if (unwrapped is InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax member }
            && member.Name.Identifier.Text == "ConfigureAwait")
        {
            unwrapped = member.Expression;
        }

        return SymbolEqualityComparer.Default.Equals(model.GetTypeInfo(unwrapped, cancellationToken).Type, returnType);
    }
}
