// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Immutable;
using System.Linq;

/// <summary>
/// Detects <see langword="async"/> methods, local functions and lambdas that return an
/// <c>AsyncReentrantLock.Releaser</c>, which hides the hold from the caller and deadlocks its next
/// nested acquisition.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class AsyncReentrantReleaserAnalyzer : DiagnosticAnalyzer
{
    private const string LockFullName = "CryptoHives.Foundation.Threading.Async.Pooled.AsyncReentrantLock";

    private static readonly ImmutableArray<DiagnosticDescriptor> s_supportedDiagnostics =
        ImmutableArray.Create(DiagnosticDescriptors.AsyncReentrantReleaserReturnedFromAsync);

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
            INamedTypeSymbol? releaser = start.Compilation.GetTypeByMetadataName(LockFullName)?.GetTypeMembers("Releaser").FirstOrDefault();
            if (types is null || releaser is null)
            {
                return;
            }

            var target = new Target(types, releaser);
            start.RegisterSyntaxNodeAction(c => AnalyzeMethod(c, target), SyntaxKind.MethodDeclaration);
            start.RegisterSyntaxNodeAction(c => AnalyzeLocalFunction(c, target), SyntaxKind.LocalFunctionStatement);
            start.RegisterSyntaxNodeAction(
                c => AnalyzeAnonymousFunction(c, target),
                SyntaxKind.ParenthesizedLambdaExpression,
                SyntaxKind.SimpleLambdaExpression,
                SyntaxKind.AnonymousMethodExpression);
        });
    }

    /// <summary>
    /// <c>Task&lt;Releaser&gt;</c> and <c>ValueTask&lt;Releaser&gt;</c> of this compilation.
    /// </summary>
    private sealed class Target
    {
        private readonly ValueTaskTypes _types;
        private readonly INamedTypeSymbol _releaser;

        public Target(ValueTaskTypes types, INamedTypeSymbol releaser)
        {
            _types = types;
            _releaser = releaser;
        }

        public bool Matches(ITypeSymbol returnType)
            => returnType is INamedTypeSymbol { TypeArguments.Length: 1 } task &&
                (_types.IsTask(task) || _types.IsValueTask(task)) &&
                SymbolEqualityComparer.Default.Equals(task.TypeArguments[0], _releaser);
    }

    private static void AnalyzeMethod(SyntaxNodeAnalysisContext context, Target target)
    {
        var method = (MethodDeclarationSyntax)context.Node;
        if (!method.Modifiers.Any(SyntaxKind.AsyncKeyword))
        {
            return;
        }

        if (context.SemanticModel.GetDeclaredSymbol(method, context.CancellationToken) is IMethodSymbol symbol)
        {
            Report(context, target, symbol, method.Identifier.GetLocation(), method.Identifier.Text);
        }
    }

    private static void AnalyzeLocalFunction(SyntaxNodeAnalysisContext context, Target target)
    {
        var local = (LocalFunctionStatementSyntax)context.Node;
        if (!local.Modifiers.Any(SyntaxKind.AsyncKeyword))
        {
            return;
        }

        if (context.SemanticModel.GetDeclaredSymbol(local, context.CancellationToken) is IMethodSymbol symbol)
        {
            Report(context, target, symbol, local.Identifier.GetLocation(), local.Identifier.Text);
        }
    }

    private static void AnalyzeAnonymousFunction(SyntaxNodeAnalysisContext context, Target target)
    {
        var function = (AnonymousFunctionExpressionSyntax)context.Node;
        if (!function.AsyncKeyword.IsKind(SyntaxKind.AsyncKeyword))
        {
            return;
        }

        if (context.SemanticModel.GetSymbolInfo(function, context.CancellationToken).Symbol is IMethodSymbol symbol)
        {
            Report(context, target, symbol, function.AsyncKeyword.GetLocation(), "async lambda");
        }
    }

    private static void Report(SyntaxNodeAnalysisContext context, Target target, IMethodSymbol method, Location location, string name)
    {
        if (target.Matches(method.ReturnType))
        {
            context.ReportDiagnostic(Diagnostic.Create(
                DiagnosticDescriptors.AsyncReentrantReleaserReturnedFromAsync,
                location,
                name));
        }
    }
}
