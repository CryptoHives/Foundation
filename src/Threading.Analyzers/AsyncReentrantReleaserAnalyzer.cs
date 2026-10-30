// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Immutable;

/// <summary>
/// Detects <see langword="async"/> methods, local functions and lambdas that return an
/// <c>AsyncReentrantLock.Releaser</c>, which hides the hold from the caller and deadlocks its next
/// nested acquisition.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class AsyncReentrantReleaserAnalyzer : DiagnosticAnalyzer
{
    private const string LockNamespace = "CryptoHives.Foundation.Threading.Async.Pooled";
    private const string LockTypeName = "AsyncReentrantLock";
    private const string ReleaserTypeName = "Releaser";
    private const string TasksNamespace = "System.Threading.Tasks";

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(DiagnosticDescriptors.AsyncReentrantReleaserReturnedFromAsync);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterSyntaxNodeAction(AnalyzeMethod, SyntaxKind.MethodDeclaration);
        context.RegisterSyntaxNodeAction(AnalyzeLocalFunction, SyntaxKind.LocalFunctionStatement);
        context.RegisterSyntaxNodeAction(
            AnalyzeAnonymousFunction,
            SyntaxKind.ParenthesizedLambdaExpression,
            SyntaxKind.SimpleLambdaExpression,
            SyntaxKind.AnonymousMethodExpression);
    }

    private static void AnalyzeMethod(SyntaxNodeAnalysisContext context)
    {
        var method = (MethodDeclarationSyntax)context.Node;
        if (!method.Modifiers.Any(SyntaxKind.AsyncKeyword))
        {
            return;
        }

        if (context.SemanticModel.GetDeclaredSymbol(method, context.CancellationToken) is IMethodSymbol symbol)
        {
            Report(context, symbol, method.Identifier.GetLocation(), method.Identifier.Text);
        }
    }

    private static void AnalyzeLocalFunction(SyntaxNodeAnalysisContext context)
    {
        var local = (LocalFunctionStatementSyntax)context.Node;
        if (!local.Modifiers.Any(SyntaxKind.AsyncKeyword))
        {
            return;
        }

        if (context.SemanticModel.GetDeclaredSymbol(local, context.CancellationToken) is IMethodSymbol symbol)
        {
            Report(context, symbol, local.Identifier.GetLocation(), local.Identifier.Text);
        }
    }

    private static void AnalyzeAnonymousFunction(SyntaxNodeAnalysisContext context)
    {
        var function = (AnonymousFunctionExpressionSyntax)context.Node;
        if (!function.AsyncKeyword.IsKind(SyntaxKind.AsyncKeyword))
        {
            return;
        }

        if (context.SemanticModel.GetSymbolInfo(function, context.CancellationToken).Symbol is IMethodSymbol symbol)
        {
            Report(context, symbol, function.AsyncKeyword.GetLocation(), "async lambda");
        }
    }

    private static void Report(SyntaxNodeAnalysisContext context, IMethodSymbol method, Location location, string name)
    {
        if (!ReturnsReleaserTask(method.ReturnType))
        {
            return;
        }

        context.ReportDiagnostic(Diagnostic.Create(
            DiagnosticDescriptors.AsyncReentrantReleaserReturnedFromAsync,
            location,
            name));
    }

    private static bool ReturnsReleaserTask(ITypeSymbol returnType)
    {
        if (returnType is not INamedTypeSymbol { IsGenericType: true, TypeArguments.Length: 1 } task ||
            task.Name is not ("Task" or "ValueTask") ||
            task.ContainingNamespace?.ToDisplayString() != TasksNamespace)
        {
            return false;
        }

        return task.TypeArguments[0] is INamedTypeSymbol {
            Name: ReleaserTypeName,
            ContainingType: { Name: LockTypeName, ContainingType: null } lockType
        } && lockType.ContainingNamespace?.ToDisplayString() == LockNamespace;
    }
}
