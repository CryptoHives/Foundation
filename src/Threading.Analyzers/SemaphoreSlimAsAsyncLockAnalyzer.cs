// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;

/// <summary>
/// Analyzer that detects <c>new SemaphoreSlim(1, 1)</c> used as an async-compatible exclusive lock
/// and suggests replacing it with <c>AsyncLock</c>.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class SemaphoreSlimAsAsyncLockAnalyzer : DiagnosticAnalyzer
{
    private const string SemaphoreSlimFullName = "System.Threading.SemaphoreSlim";

    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(DiagnosticDescriptors.SemaphoreSlimAsAsyncLock);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        if (context is null)
        {
            throw new System.ArgumentNullException(nameof(context));
        }

        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterSyntaxNodeAction(
            AnalyzeObjectCreation,
            SyntaxKind.ObjectCreationExpression,
            SyntaxKind.ImplicitObjectCreationExpression);
    }

    private static void AnalyzeObjectCreation(SyntaxNodeAnalysisContext context)
    {
        // Resolve the two integer arguments from either `new SemaphoreSlim(1, 1)`
        // or `new(1, 1)` (target-typed new).
        ArgumentListSyntax? argumentList;
        Location diagnosticLocation;
        string symbolName;

        if (context.Node is ObjectCreationExpressionSyntax objectCreation)
        {
            // Skip if the type name is not SemaphoreSlim — fast syntactic pre-filter.
            if (!IsSemaphoreSlimTypeName(objectCreation.Type))
            {
                return;
            }

            argumentList = objectCreation.ArgumentList;
            diagnosticLocation = objectCreation.GetLocation();
            symbolName = GetDeclarationName(context.Node) ?? "semaphore";
        }
        else if (context.Node is ImplicitObjectCreationExpressionSyntax implicitCreation)
        {
            argumentList = implicitCreation.ArgumentList;
            diagnosticLocation = implicitCreation.GetLocation();
            symbolName = GetDeclarationName(context.Node) ?? "semaphore";
        }
        else
        {
            return;
        }

        if (argumentList is null || argumentList.Arguments.Count != 2)
        {
            return;
        }

        // Semantic check: ensure the constructed type is System.Threading.SemaphoreSlim.
        var typeInfo = context.SemanticModel.GetTypeInfo(context.Node, context.CancellationToken);
        if (typeInfo.Type is not INamedTypeSymbol typeSymbol ||
            typeSymbol.ToDisplayString() != SemaphoreSlimFullName)
        {
            return;
        }

        // Verify both arguments are compile-time constant 1.
        if (!IsConstantOne(context.SemanticModel, argumentList.Arguments[0].Expression, context.CancellationToken) ||
            !IsConstantOne(context.SemanticModel, argumentList.Arguments[1].Expression, context.CancellationToken))
        {
            return;
        }

        context.ReportDiagnostic(Diagnostic.Create(
            DiagnosticDescriptors.SemaphoreSlimAsAsyncLock,
            diagnosticLocation,
            symbolName));
    }

    private static bool IsSemaphoreSlimTypeName(TypeSyntax type)
    {
        return type switch {
            IdentifierNameSyntax id => id.Identifier.Text == "SemaphoreSlim",
            QualifiedNameSyntax q => q.Right.Identifier.Text == "SemaphoreSlim",
            AliasQualifiedNameSyntax a => a.Name.Identifier.Text == "SemaphoreSlim",
            _ => false
        };
    }

    private static bool IsConstantOne(SemanticModel model, ExpressionSyntax expression, System.Threading.CancellationToken ct)
    {
        var constant = model.GetConstantValue(expression, ct);
        return constant.HasValue && constant.Value is int value && value == 1;
    }

    /// <summary>
    /// Walks up the syntax tree to find the variable or field name that holds the
    /// <c>SemaphoreSlim</c> instance, for use in the diagnostic message.
    /// </summary>
    private static string? GetDeclarationName(SyntaxNode node)
    {
        // variable declarator:  SemaphoreSlim _sem = new SemaphoreSlim(1, 1);
        if (node.Parent is EqualsValueClauseSyntax { Parent: VariableDeclaratorSyntax declarator })
        {
            return declarator.Identifier.Text;
        }

        // assignment expression:  _sem = new SemaphoreSlim(1, 1);
        if (node.Parent is AssignmentExpressionSyntax assignment &&
            assignment.Right == node)
        {
            return assignment.Left.ToString();
        }

        return null;
    }
}
