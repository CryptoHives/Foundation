// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

/// <summary>
/// Analyzer that detects common ValueTask misuse patterns.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class ValueTaskMisuseAnalyzer : DiagnosticAnalyzer
{
    /// <inheritdoc/>
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(
        DiagnosticDescriptors.MultipleAwait,
        DiagnosticDescriptors.BlockingGetResult,
        DiagnosticDescriptors.StoredInField,
        DiagnosticDescriptors.MultipleAsTask,
        DiagnosticDescriptors.DirectResultAccess,
        DiagnosticDescriptors.PassedToUnsafeMethod,
        DiagnosticDescriptors.AsTaskStoredBeforeSignal,
        DiagnosticDescriptors.NotConsumed);

    /// <inheritdoc/>
    public override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
        context.EnableConcurrentExecution();

        context.RegisterSyntaxNodeAction(AnalyzeMethodBody, SyntaxKind.MethodDeclaration);
        context.RegisterSyntaxNodeAction(AnalyzeLocalFunction, SyntaxKind.LocalFunctionStatement);
        context.RegisterSyntaxNodeAction(AnalyzeLambda, SyntaxKind.ParenthesizedLambdaExpression);
        context.RegisterSyntaxNodeAction(AnalyzeLambda, SyntaxKind.SimpleLambdaExpression);
        context.RegisterSyntaxNodeAction(AnalyzeFieldDeclaration, SyntaxKind.FieldDeclaration);
        context.RegisterSyntaxNodeAction(AnalyzePropertyDeclaration, SyntaxKind.PropertyDeclaration);
    }

    private static void AnalyzeMethodBody(SyntaxNodeAnalysisContext context)
    {
        var methodDeclaration = (MethodDeclarationSyntax)context.Node;
        if (methodDeclaration.Body is null && methodDeclaration.ExpressionBody is null)
        {
            return;
        }

        var semanticModel = context.SemanticModel;
        var tracker = new ValueTaskUsageTracker(context, semanticModel);

        if (methodDeclaration.Body is not null)
        {
            tracker.AnalyzeBlock(methodDeclaration.Body);
        }
        else if (methodDeclaration.ExpressionBody is not null)
        {
            tracker.AnalyzeExpression(methodDeclaration.ExpressionBody.Expression);
        }
    }

    private static void AnalyzeLocalFunction(SyntaxNodeAnalysisContext context)
    {
        var localFunction = (LocalFunctionStatementSyntax)context.Node;
        if (localFunction.Body is null && localFunction.ExpressionBody is null)
        {
            return;
        }

        var semanticModel = context.SemanticModel;
        var tracker = new ValueTaskUsageTracker(context, semanticModel);

        if (localFunction.Body is not null)
        {
            tracker.AnalyzeBlock(localFunction.Body);
        }
        else if (localFunction.ExpressionBody is not null)
        {
            tracker.AnalyzeExpression(localFunction.ExpressionBody.Expression);
        }
    }

    private static void AnalyzeLambda(SyntaxNodeAnalysisContext context)
    {
        ExpressionSyntax? body = null;
        BlockSyntax? block = null;

        if (context.Node is ParenthesizedLambdaExpressionSyntax parenthesizedLambda)
        {
            if (parenthesizedLambda.Block is not null)
            {
                block = parenthesizedLambda.Block;
            }
            else if (parenthesizedLambda.ExpressionBody is not null)
            {
                body = parenthesizedLambda.ExpressionBody;
            }
        }
        else if (context.Node is SimpleLambdaExpressionSyntax simpleLambda)
        {
            if (simpleLambda.Block is not null)
            {
                block = simpleLambda.Block;
            }
            else if (simpleLambda.ExpressionBody is not null)
            {
                body = simpleLambda.ExpressionBody;
            }
        }

        if (block is null && body is null)
        {
            return;
        }

        var semanticModel = context.SemanticModel;
        var tracker = new ValueTaskUsageTracker(context, semanticModel);

        if (block is not null)
        {
            tracker.AnalyzeBlock(block);
        }
        else if (body is not null)
        {
            tracker.AnalyzeExpression(body);
        }
    }

    private static void AnalyzeFieldDeclaration(SyntaxNodeAnalysisContext context)
    {
        var fieldDeclaration = (FieldDeclarationSyntax)context.Node;
        var semanticModel = context.SemanticModel;

        foreach (var variable in fieldDeclaration.Declaration.Variables)
        {
            var typeInfo = semanticModel.GetTypeInfo(fieldDeclaration.Declaration.Type, context.CancellationToken);
            if (IsValueTaskType(typeInfo.Type))
            {
                var diagnostic = Diagnostic.Create(
                    DiagnosticDescriptors.StoredInField,
                    variable.GetLocation(),
                    variable.Identifier.Text);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }

    private static void AnalyzePropertyDeclaration(SyntaxNodeAnalysisContext context)
    {
        var propertyDeclaration = (PropertyDeclarationSyntax)context.Node;
        var semanticModel = context.SemanticModel;

        // Only check auto-properties with backing fields
        if (propertyDeclaration.AccessorList is null)
        {
            return;
        }

        bool hasGetter = false;
        bool hasSetter = false;
        foreach (var accessor in propertyDeclaration.AccessorList.Accessors)
        {
            if (accessor.Kind() == SyntaxKind.GetAccessorDeclaration && accessor.Body is null && accessor.ExpressionBody is null)
            {
                hasGetter = true;
            }
            if (accessor.Kind() == SyntaxKind.SetAccessorDeclaration && accessor.Body is null && accessor.ExpressionBody is null)
            {
                hasSetter = true;
            }
        }

        if (hasGetter && hasSetter)
        {
            var typeInfo = semanticModel.GetTypeInfo(propertyDeclaration.Type, context.CancellationToken);
            if (IsValueTaskType(typeInfo.Type))
            {
                var diagnostic = Diagnostic.Create(
                    DiagnosticDescriptors.StoredInField,
                    propertyDeclaration.GetLocation(),
                    propertyDeclaration.Identifier.Text);
                context.ReportDiagnostic(diagnostic);
            }
        }
    }

    private static bool IsValueTaskType(ITypeSymbol? type)
    {
        if (type is null)
        {
            return false;
        }

        var typeName = type.ToDisplayString();
        return typeName == "System.Threading.Tasks.ValueTask" ||
               typeName.StartsWith("System.Threading.Tasks.ValueTask<", StringComparison.Ordinal);
    }

    /// <summary>
    /// Tracks ValueTask usage within a scope to detect multiple consumption.
    /// </summary>
    private sealed class ValueTaskUsageTracker
    {
        private readonly SyntaxNodeAnalysisContext _context;
        private readonly SemanticModel _semanticModel;
        private readonly Dictionary<ISymbol, ValueTaskUsage> _usages;

        public ValueTaskUsageTracker(SyntaxNodeAnalysisContext context, SemanticModel semanticModel)
        {
            _context = context;
            _semanticModel = semanticModel;
            _usages = new Dictionary<ISymbol, ValueTaskUsage>(SymbolEqualityComparer.Default);
        }

        public void AnalyzeBlock(BlockSyntax block)
        {
            foreach (var statement in block.Statements)
            {
                AnalyzeStatement(statement);
            }
        }

        public void AnalyzeExpression(ExpressionSyntax expression)
        {
            AnalyzeExpressionRecursive(expression, isConsumed: true);
        }

        private void AnalyzeStatement(StatementSyntax statement)
        {
            switch (statement)
            {
                case LocalDeclarationStatementSyntax localDeclaration:
                    AnalyzeLocalDeclaration(localDeclaration);
                    break;
                case ExpressionStatementSyntax expressionStatement:
                    AnalyzeExpressionStatement(expressionStatement);
                    break;
                case ReturnStatementSyntax returnStatement when returnStatement.Expression is not null:
                    AnalyzeExpressionRecursive(returnStatement.Expression, isConsumed: true);
                    break;
                case IfStatementSyntax ifStatement:
                    AnalyzeIfStatement(ifStatement);
                    break;
                case WhileStatementSyntax whileStatement:
                    AnalyzeExpressionRecursive(whileStatement.Condition, isConsumed: true);
                    AnalyzeStatement(whileStatement.Statement);
                    break;
                case ForEachStatementSyntax forEachStatement:
                    AnalyzeExpressionRecursive(forEachStatement.Expression, isConsumed: true);
                    AnalyzeStatement(forEachStatement.Statement);
                    break;
                case BlockSyntax block:
                    AnalyzeBlock(block);
                    break;
                case UsingStatementSyntax usingStatement:
                    if (usingStatement.Declaration is not null)
                    {
                        foreach (var variable in usingStatement.Declaration.Variables)
                        {
                            if (variable.Initializer is not null)
                            {
                                AnalyzeExpressionRecursive(variable.Initializer.Value, isConsumed: true);
                            }
                        }
                    }
                    if (usingStatement.Expression is not null)
                    {
                        AnalyzeExpressionRecursive(usingStatement.Expression, isConsumed: true);
                    }
                    if (usingStatement.Statement is not null)
                    {
                        AnalyzeStatement(usingStatement.Statement);
                    }
                    break;
                case TryStatementSyntax tryStatement:
                    AnalyzeBlock(tryStatement.Block);
                    foreach (var catchClause in tryStatement.Catches)
                    {
                        AnalyzeBlock(catchClause.Block);
                    }
                    if (tryStatement.Finally is not null)
                    {
                        AnalyzeBlock(tryStatement.Finally.Block);
                    }
                    break;
            }
        }

        private void AnalyzeLocalDeclaration(LocalDeclarationStatementSyntax localDeclaration)
        {
            foreach (var variable in localDeclaration.Declaration.Variables)
            {
                if (variable.Initializer is null)
                {
                    continue;
                }

                var typeInfo = _semanticModel.GetTypeInfo(variable.Initializer.Value, _context.CancellationToken);
                
                // Track ValueTask variables for multiple consumption detection
                if (IsValueTaskType(typeInfo.Type))
                {
                    var symbol = _semanticModel.GetDeclaredSymbol(variable, _context.CancellationToken);
                    if (symbol is not null)
                    {
                        _usages[symbol] = new ValueTaskUsage(variable.GetLocation());
                    }

                    // Check if initialized with AsTask() call pattern that's stored
                    if (variable.Initializer.Value is InvocationExpressionSyntax invocation &&
                        IsAsTaskCall(invocation))
                    {
                        var diagnostic = Diagnostic.Create(
                            DiagnosticDescriptors.AsTaskStoredBeforeSignal,
                            variable.GetLocation());
                        _context.ReportDiagnostic(diagnostic);
                    }
                }

                // Always analyze the initializer expression for other patterns
                AnalyzeExpressionRecursive(variable.Initializer.Value, isConsumed: false);
            }
        }

        private void AnalyzeExpressionStatement(ExpressionStatementSyntax expressionStatement)
        {
            var expression = expressionStatement.Expression;

            // Check for discarded ValueTask
            if (expression is InvocationExpressionSyntax invocation)
            {
                var typeInfo = _semanticModel.GetTypeInfo(invocation, _context.CancellationToken);
                if (IsValueTaskType(typeInfo.Type))
                {
                    // ValueTask returned but not awaited or stored
                    var diagnostic = Diagnostic.Create(
                        DiagnosticDescriptors.NotConsumed,
                        invocation.GetLocation(),
                        GetExpressionName(invocation));
                    _context.ReportDiagnostic(diagnostic);
                }
            }

            AnalyzeExpressionRecursive(expression, isConsumed: expression is AwaitExpressionSyntax);
        }

        private void AnalyzeIfStatement(IfStatementSyntax ifStatement)
        {
            AnalyzeExpressionRecursive(ifStatement.Condition, isConsumed: true);
            AnalyzeStatement(ifStatement.Statement);
            if (ifStatement.Else is not null)
            {
                AnalyzeStatement(ifStatement.Else.Statement);
            }
        }

        private void AnalyzeExpressionRecursive(ExpressionSyntax expression, bool isConsumed)
        {
            switch (expression)
            {
                case AwaitExpressionSyntax awaitExpression:
                    AnalyzeAwaitExpression(awaitExpression);
                    break;

                case InvocationExpressionSyntax invocation:
                    AnalyzeInvocation(invocation);
                    break;

                case MemberAccessExpressionSyntax memberAccess:
                    AnalyzeMemberAccess(memberAccess);
                    break;

                case IdentifierNameSyntax identifier:
                    if (isConsumed)
                    {
                        TrackUsage(identifier);
                    }
                    break;

                case AssignmentExpressionSyntax assignment:
                    AnalyzeExpressionRecursive(assignment.Right, isConsumed: false);
                    // Check if assigning ValueTask to field
                    if (assignment.Left is MemberAccessExpressionSyntax fieldAccess)
                    {
                        var symbolInfo = _semanticModel.GetSymbolInfo(fieldAccess, _context.CancellationToken);
                        if (symbolInfo.Symbol is IFieldSymbol fieldSymbol)
                        {
                            var rightTypeInfo = _semanticModel.GetTypeInfo(assignment.Right, _context.CancellationToken);
                            if (IsValueTaskType(rightTypeInfo.Type))
                            {
                                var diagnostic = Diagnostic.Create(
                                    DiagnosticDescriptors.StoredInField,
                                    assignment.GetLocation(),
                                    fieldSymbol.Name);
                                _context.ReportDiagnostic(diagnostic);
                            }
                        }
                    }
                    break;

                case ConditionalExpressionSyntax conditional:
                    AnalyzeExpressionRecursive(conditional.Condition, isConsumed: true);
                    AnalyzeExpressionRecursive(conditional.WhenTrue, isConsumed);
                    AnalyzeExpressionRecursive(conditional.WhenFalse, isConsumed);
                    break;

                case ParenthesizedExpressionSyntax parenthesized:
                    AnalyzeExpressionRecursive(parenthesized.Expression, isConsumed);
                    break;
            }
        }

        private void AnalyzeAwaitExpression(AwaitExpressionSyntax awaitExpression)
        {
            var operand = awaitExpression.Expression;

            // Track direct await of variable
            if (operand is IdentifierNameSyntax identifier)
            {
                TrackUsage(identifier);
            }
            // Track await of configured value task
            else if (operand is InvocationExpressionSyntax configureAwait &&
                     configureAwait.Expression is MemberAccessExpressionSyntax memberAccess &&
                     memberAccess.Name.Identifier.Text == "ConfigureAwait")
            {
                if (memberAccess.Expression is IdentifierNameSyntax configuredIdentifier)
                {
                    TrackUsage(configuredIdentifier);
                }
                else
                {
                    AnalyzeExpressionRecursive(memberAccess.Expression, isConsumed: true);
                }
            }
            else
            {
                AnalyzeExpressionRecursive(operand, isConsumed: true);
            }
        }

        private void AnalyzeInvocation(InvocationExpressionSyntax invocation)
        {
            // Check for GetAwaiter().GetResult() pattern
            if (invocation.Expression is MemberAccessExpressionSyntax memberAccess)
            {
                if (memberAccess.Name.Identifier.Text == "GetResult" &&
                    memberAccess.Expression is InvocationExpressionSyntax getAwaiterCall &&
                    getAwaiterCall.Expression is MemberAccessExpressionSyntax getAwaiterAccess &&
                    getAwaiterAccess.Name.Identifier.Text == "GetAwaiter")
                {
                    // Check if the base expression is a ValueTask
                    var typeInfo = _semanticModel.GetTypeInfo(getAwaiterAccess.Expression, _context.CancellationToken);
                    if (IsValueTaskType(typeInfo.Type))
                    {
                        var diagnostic = Diagnostic.Create(
                            DiagnosticDescriptors.BlockingGetResult,
                            invocation.GetLocation(),
                            GetExpressionName(getAwaiterAccess.Expression));
                        _context.ReportDiagnostic(diagnostic);

                        TrackUsageFromExpression(getAwaiterAccess.Expression);
                    }
                }

                // Check for AsTask() call
                if (IsAsTaskCall(invocation))
                {
                    var baseExpression = memberAccess.Expression;
                    var typeInfo = _semanticModel.GetTypeInfo(baseExpression, _context.CancellationToken);
                    if (IsValueTaskType(typeInfo.Type))
                    {
                        TrackUsageFromExpression(baseExpression);
                    }
                }
            }

            // Check for passing ValueTask to potentially unsafe methods
            CheckUnsafeMethodArguments(invocation);

            // Recursively analyze arguments
            foreach (var argument in invocation.ArgumentList.Arguments)
            {
                AnalyzeExpressionRecursive(argument.Expression, isConsumed: false);
            }
        }

        private void CheckUnsafeMethodArguments(InvocationExpressionSyntax invocation)
        {
            var symbolInfo = _semanticModel.GetSymbolInfo(invocation, _context.CancellationToken);
            if (symbolInfo.Symbol is not IMethodSymbol methodSymbol)
            {
                return;
            }

            var methodName = methodSymbol.Name;
            var containingType = methodSymbol.ContainingType?.ToDisplayString();

            // Check for Task.WhenAll, Task.WhenAny, etc.
            bool isUnsafeMethod = (containingType == "System.Threading.Tasks.Task" &&
                                   (methodName == "WhenAll" || methodName == "WhenAny")) ||
                                  (containingType == "System.Threading.Tasks.ValueTask" &&
                                   (methodName == "WhenAll" || methodName == "WhenAny"));

            if (isUnsafeMethod)
            {
                foreach (var argument in invocation.ArgumentList.Arguments)
                {
                    var typeInfo = _semanticModel.GetTypeInfo(argument.Expression, _context.CancellationToken);
                    if (IsValueTaskType(typeInfo.Type))
                    {
                        var diagnostic = Diagnostic.Create(
                            DiagnosticDescriptors.PassedToUnsafeMethod,
                            argument.GetLocation(),
                            methodName);
                        _context.ReportDiagnostic(diagnostic);
                    }
                }
            }
        }

        private void AnalyzeMemberAccess(MemberAccessExpressionSyntax memberAccess)
        {
            // Check for direct .Result access
            if (memberAccess.Name.Identifier.Text == "Result")
            {
                var typeInfo = _semanticModel.GetTypeInfo(memberAccess.Expression, _context.CancellationToken);
                if (IsValueTaskType(typeInfo.Type))
                {
                    var diagnostic = Diagnostic.Create(
                        DiagnosticDescriptors.DirectResultAccess,
                        memberAccess.GetLocation(),
                        GetExpressionName(memberAccess.Expression));
                    _context.ReportDiagnostic(diagnostic);

                    TrackUsageFromExpression(memberAccess.Expression);
                }
            }

            AnalyzeExpressionRecursive(memberAccess.Expression, isConsumed: false);
        }

        private void TrackUsage(IdentifierNameSyntax identifier)
        {
            var symbolInfo = _semanticModel.GetSymbolInfo(identifier, _context.CancellationToken);
            if (symbolInfo.Symbol is null)
            {
                return;
            }

            var typeInfo = _semanticModel.GetTypeInfo(identifier, _context.CancellationToken);
            if (!IsValueTaskType(typeInfo.Type))
            {
                return;
            }

            if (_usages.TryGetValue(symbolInfo.Symbol, out var usage))
            {
                usage.UsageCount++;
                if (usage.UsageCount > 1)
                {
                    var diagnostic = Diagnostic.Create(
                        DiagnosticDescriptors.MultipleAwait,
                        identifier.GetLocation(),
                        identifier.Identifier.Text);
                    _context.ReportDiagnostic(diagnostic);
                }
            }
        }

        private void TrackUsageFromExpression(ExpressionSyntax expression)
        {
            if (expression is IdentifierNameSyntax identifier)
            {
                TrackUsage(identifier);
            }
        }

        private static bool IsAsTaskCall(InvocationExpressionSyntax invocation)
        {
            return invocation.Expression is MemberAccessExpressionSyntax memberAccess &&
                   memberAccess.Name.Identifier.Text == "AsTask" &&
                   invocation.ArgumentList.Arguments.Count == 0;
        }

        private static string GetExpressionName(ExpressionSyntax expression)
        {
            return expression switch
            {
                IdentifierNameSyntax identifier => identifier.Identifier.Text,
                InvocationExpressionSyntax invocation => GetInvocationName(invocation),
                MemberAccessExpressionSyntax memberAccess => memberAccess.Name.Identifier.Text,
                _ => expression.ToString()
            };
        }

        private static string GetInvocationName(InvocationExpressionSyntax invocation)
        {
            return invocation.Expression switch
            {
                IdentifierNameSyntax identifier => identifier.Identifier.Text + "()",
                MemberAccessExpressionSyntax memberAccess => memberAccess.Name.Identifier.Text + "()",
                _ => invocation.ToString()
            };
        }

        private sealed class ValueTaskUsage
        {
            public Location DeclarationLocation { get; }
            public int UsageCount { get; set; }

            public ValueTaskUsage(Location declarationLocation)
            {
                DeclarationLocation = declarationLocation;
                UsageCount = 0;
            }
        }
    }
}
