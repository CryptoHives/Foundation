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
using System.Diagnostics;

/// <summary>
/// Analyzer that detects common ValueTask misuse patterns.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class ValueTaskMisuseAnalyzer : DiagnosticAnalyzer
{
#if DEBUG
    /// <summary>
    /// Set to true and rebuild to launch debugger when analyzer initializes.
    /// This allows attaching to the analyzer during Visual Studio or build execution.
    /// </summary>
    /// <remarks>
    /// Debug steps:
    /// 1. Set this to true
    /// 2. Rebuild the analyzer
    /// 3. Open target project in Visual Studio or run dotnet build
    /// 4. Debugger prompt will appear - attach with the analyzer solution
    /// </remarks>
    private const bool LaunchDebuggerOnInitialize = false;
#endif

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
        if (context is null)
        {
            throw new ArgumentNullException(nameof(context));
        }

#if DEBUG
        // Launch debugger if constant is set to true (for troubleshooting analyzer issues)
        if (LaunchDebuggerOnInitialize && !Debugger.IsAttached)
        {
            Debugger.Launch();
        }

        // Log analyzer initialization to debug output (visible in Output window with DebugView)
        Debug.WriteLine($"[ValueTaskMisuseAnalyzer] Initialize called at {DateTime.Now:HH:mm:ss.fff}");
#endif

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

        SemanticModel semanticModel = context.SemanticModel;
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

        SemanticModel semanticModel = context.SemanticModel;
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

        SemanticModel semanticModel = context.SemanticModel;

        // For lambdas, we need to detect captured ValueTask variables from outer scopes
        // Any usage of such captured variables is potentially unsafe since:
        // 1. The lambda could be invoked multiple times
        // 2. The variable may have been consumed before the lambda executes
        var tracker = new ValueTaskUsageTracker(context, semanticModel, isClosure: true);

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
        SemanticModel semanticModel = context.SemanticModel;

        foreach (VariableDeclaratorSyntax variable in fieldDeclaration.Declaration.Variables)
        {
            TypeInfo typeInfo = semanticModel.GetTypeInfo(fieldDeclaration.Declaration.Type, context.CancellationToken);

            // Use IsValueTaskType which already excludes arrays
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
        SemanticModel semanticModel = context.SemanticModel;

        // Only check auto-properties with backing fields
        if (propertyDeclaration.AccessorList is null)
        {
            return;
        }

        bool hasGetter = false;
        bool hasSetter = false;
        foreach (AccessorDeclarationSyntax accessor in propertyDeclaration.AccessorList.Accessors)
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
            TypeInfo typeInfo = semanticModel.GetTypeInfo(propertyDeclaration.Type, context.CancellationToken);

            // Use IsValueTaskType which already excludes arrays
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

        // Arrays of ValueTask are allowed - they are used to collect multiple pending operations
        // before awaiting them sequentially (e.g., in benchmarks or batch processing scenarios)
        if (type is IArrayTypeSymbol)
        {
            return false;
        }

        string typeName = type.ToDisplayString();
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
        private readonly HashSet<ISymbol> _preservedVariables;
        private readonly bool _isClosure;

        public ValueTaskUsageTracker(SyntaxNodeAnalysisContext context, SemanticModel semanticModel, bool isClosure = false)
        {
            _context = context;
            _semanticModel = semanticModel;
            _usages = new Dictionary<ISymbol, ValueTaskUsage>(SymbolEqualityComparer.Default);
            _preservedVariables = new HashSet<ISymbol>(SymbolEqualityComparer.Default);
            _isClosure = isClosure;
        }

        public void AnalyzeBlock(BlockSyntax block)
        {
            foreach (StatementSyntax statement in block.Statements)
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
                        foreach (VariableDeclaratorSyntax variable in usingStatement.Declaration.Variables)
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
                    foreach (CatchClauseSyntax catchClause in tryStatement.Catches)
                    {
                        AnalyzeBlock(catchClause.Block);
                    }
                    if (tryStatement.Finally is not null)
                    {
                        AnalyzeBlock(tryStatement.Finally.Block);
                    }
                    break;
                case ForStatementSyntax forStatement:
                    if (forStatement.Declaration is not null)
                    {
                        foreach (VariableDeclaratorSyntax variable in forStatement.Declaration.Variables)
                        {
                            if (variable.Initializer is not null)
                            {
                                AnalyzeExpressionRecursive(variable.Initializer.Value, isConsumed: false);
                            }
                        }
                    }
                    if (forStatement.Condition is not null)
                    {
                        AnalyzeExpressionRecursive(forStatement.Condition, isConsumed: true);
                    }
                    AnalyzeStatement(forStatement.Statement);
                    break;
                case DoStatementSyntax doStatement:
                    AnalyzeStatement(doStatement.Statement);
                    AnalyzeExpressionRecursive(doStatement.Condition, isConsumed: true);
                    break;
                case SwitchStatementSyntax switchStatement:
                    AnalyzeExpressionRecursive(switchStatement.Expression, isConsumed: true);
                    foreach (SwitchSectionSyntax section in switchStatement.Sections)
                    {
                        foreach (StatementSyntax sectionStatement in section.Statements)
                        {
                            AnalyzeStatement(sectionStatement);
                        }
                    }
                    break;
                case LockStatementSyntax lockStatement:
                    AnalyzeExpressionRecursive(lockStatement.Expression, isConsumed: true);
                    AnalyzeStatement(lockStatement.Statement);
                    break;
            }
        }

        private void AnalyzeLocalDeclaration(LocalDeclarationStatementSyntax localDeclaration)
        {
            foreach (VariableDeclaratorSyntax variable in localDeclaration.Declaration.Variables)
            {
                if (variable.Initializer is null)
                {
                    continue;
                }

                TypeInfo typeInfo = _semanticModel.GetTypeInfo(variable.Initializer.Value, _context.CancellationToken);

                // Track ValueTask variables for multiple consumption detection
                if (IsValueTaskType(typeInfo.Type))
                {
                    ISymbol? symbol = _semanticModel.GetDeclaredSymbol(variable, _context.CancellationToken);
                    if (symbol is not null)
                    {
                        // Check if this variable is initialized with Preserve() call
                        // If so, it's safe to await multiple times
                        if (IsPreserveCall(variable.Initializer.Value))
                        {
                            _preservedVariables.Add(symbol);
                            // Track the source ValueTask as consumed by Preserve()
                            TrackPreserveSourceUsage(variable.Initializer.Value);
                            // Don't analyze the initializer further to avoid double-counting
                            continue;
                        }
                        else
                        {
                            _usages[symbol] = new ValueTaskUsage();
                        }
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
            ExpressionSyntax expression = expressionStatement.Expression;

            // Check for discarded ValueTask
            if (expression is InvocationExpressionSyntax invocation)
            {
                TypeInfo typeInfo = _semanticModel.GetTypeInfo(invocation, _context.CancellationToken);
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
                        SymbolInfo symbolInfo = _semanticModel.GetSymbolInfo(fieldAccess, _context.CancellationToken);
                        if (symbolInfo.Symbol is IFieldSymbol fieldSymbol)
                        {
                            TypeInfo rightTypeInfo = _semanticModel.GetTypeInfo(assignment.Right, _context.CancellationToken);
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
            ExpressionSyntax operand = awaitExpression.Expression;

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
                    TypeInfo typeInfo = _semanticModel.GetTypeInfo(getAwaiterAccess.Expression, _context.CancellationToken);
                    if (IsValueTaskType(typeInfo.Type))
                    {
                        // Don't warn if the ValueTask was preserved (safe to call GetResult on preserved ValueTask)
                        // This includes both stored preserved variables and inline Preserve() calls
                        if (!IsPreservedVariable(getAwaiterAccess.Expression) && !IsPreserveCall(getAwaiterAccess.Expression))
                        {
                            var diagnostic = Diagnostic.Create(
                                DiagnosticDescriptors.BlockingGetResult,
                                invocation.GetLocation(),
                                GetExpressionName(getAwaiterAccess.Expression));
                            _context.ReportDiagnostic(diagnostic);
                        }

                        TrackUsageFromExpression(getAwaiterAccess.Expression);
                    }
                }

                // Check for AsTask() call
                if (IsAsTaskCall(invocation))
                {
                    ExpressionSyntax baseExpression = memberAccess.Expression;
                    TypeInfo typeInfo = _semanticModel.GetTypeInfo(baseExpression, _context.CancellationToken);
                    if (IsValueTaskType(typeInfo.Type))
                    {
                        TrackUsageFromExpression(baseExpression);
                    }
                }

                // Check for Preserve() call - track source usage
                if (IsPreserveCall(invocation))
                {
                    ExpressionSyntax baseExpression = memberAccess.Expression;
                    TypeInfo typeInfo = _semanticModel.GetTypeInfo(baseExpression, _context.CancellationToken);
                    if (IsValueTaskType(typeInfo.Type))
                    {
                        TrackUsageFromExpression(baseExpression);
                    }
                }
            }

            // Check for passing ValueTask to potentially unsafe methods
            CheckUnsafeMethodArguments(invocation);

            // Recursively analyze arguments
            foreach (ArgumentSyntax argument in invocation.ArgumentList.Arguments)
            {
                AnalyzeExpressionRecursive(argument.Expression, isConsumed: false);
            }
        }

        private void CheckUnsafeMethodArguments(InvocationExpressionSyntax invocation)
        {
            SymbolInfo symbolInfo = _semanticModel.GetSymbolInfo(invocation, _context.CancellationToken);
            if (symbolInfo.Symbol is not IMethodSymbol methodSymbol)
            {
                return;
            }

            string methodName = methodSymbol.Name;
            string? containingType = methodSymbol.ContainingType?.ToDisplayString();

            // Check for Task.WhenAll, Task.WhenAny, Task.WaitAll, Task.WaitAny, etc.
            bool isUnsafeMethod = (containingType == "System.Threading.Tasks.Task" &&
                                   (methodName == "WhenAll" || methodName == "WhenAny" ||
                                    methodName == "WaitAll" || methodName == "WaitAny")) ||
                                  (containingType == "System.Threading.Tasks.ValueTask" &&
                                   (methodName == "WhenAll" || methodName == "WhenAny"));

            if (isUnsafeMethod)
            {
                foreach (ArgumentSyntax argument in invocation.ArgumentList.Arguments)
                {
                    TypeInfo typeInfo = _semanticModel.GetTypeInfo(argument.Expression, _context.CancellationToken);
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
                TypeInfo typeInfo = _semanticModel.GetTypeInfo(memberAccess.Expression, _context.CancellationToken);
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
            SymbolInfo symbolInfo = _semanticModel.GetSymbolInfo(identifier, _context.CancellationToken);
            if (symbolInfo.Symbol is null)
            {
                return;
            }

            TypeInfo typeInfo = _semanticModel.GetTypeInfo(identifier, _context.CancellationToken);
            if (!IsValueTaskType(typeInfo.Type))
            {
                return;
            }

            // If this variable holds a preserved ValueTask, it's safe to use multiple times
            if (_preservedVariables.Contains(symbolInfo.Symbol))
            {
                return;
            }

            // In a closure (lambda/local function), any usage of a captured ValueTask variable
            // from an outer scope is potentially unsafe because:
            // 1. The closure might be invoked multiple times
            // 2. The ValueTask may have been consumed before the closure executes
            // Check if this is a captured variable (not declared in the current scope)
            if (_isClosure && !_usages.ContainsKey(symbolInfo.Symbol))
            {
                // Check if the captured variable was initialized with Preserve() in the outer scope
                // by examining its declaration
                if (IsCapturedPreservedVariable(symbolInfo.Symbol))
                {
                    return;
                }

                // This is a captured variable from outer scope - flag it as potential misuse
                var diagnostic = Diagnostic.Create(
                    DiagnosticDescriptors.MultipleAwait,
                    identifier.GetLocation(),
                    identifier.Identifier.Text);
                _context.ReportDiagnostic(diagnostic);
                return;
            }

            if (_usages.TryGetValue(symbolInfo.Symbol, out ValueTaskUsage? usage))
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

        private bool IsCapturedPreservedVariable(ISymbol symbol)
        {
            // Check if the symbol is a local variable that was initialized with Preserve()
            if (symbol is ILocalSymbol localSymbol)
            {
                // Get the declaring syntax reference
                foreach (var syntaxReference in localSymbol.DeclaringSyntaxReferences)
                {
                    var syntax = syntaxReference.GetSyntax(_context.CancellationToken);
                    if (syntax is VariableDeclaratorSyntax variableDeclarator &&
                        variableDeclarator.Initializer is not null)
                    {
                        // Check if the initializer is a Preserve() call
                        if (IsPreserveCall(variableDeclarator.Initializer.Value))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void TrackUsageFromExpression(ExpressionSyntax expression)
        {
            if (expression is IdentifierNameSyntax identifier)
            {
                TrackUsage(identifier);
            }
        }

        private void TrackPreserveSourceUsage(ExpressionSyntax preserveCall)
        {
            // preserveCall is the Preserve() invocation, we need to find the source ValueTask
            if (preserveCall is InvocationExpressionSyntax invocation &&
                invocation.Expression is MemberAccessExpressionSyntax memberAccess)
            {
                TrackUsageFromExpression(memberAccess.Expression);
            }
        }

        private bool IsPreservedVariable(ExpressionSyntax expression)
        {
            if (expression is IdentifierNameSyntax identifier)
            {
                SymbolInfo symbolInfo = _semanticModel.GetSymbolInfo(identifier, _context.CancellationToken);
                if (symbolInfo.Symbol is not null)
                {
                    return _preservedVariables.Contains(symbolInfo.Symbol);
                }
            }
            return false;
        }

        private static bool IsAsTaskCall(InvocationExpressionSyntax invocation)
        {
            return invocation.Expression is MemberAccessExpressionSyntax memberAccess &&
                   memberAccess.Name.Identifier.Text == "AsTask" &&
                   invocation.ArgumentList.Arguments.Count == 0;
        }

        private static bool IsPreserveCall(ExpressionSyntax expression)
        {
            return expression is InvocationExpressionSyntax invocation &&
                   invocation.Expression is MemberAccessExpressionSyntax memberAccess &&
                   memberAccess.Name.Identifier.Text == "Preserve" &&
                   invocation.ArgumentList.Arguments.Count == 0;
        }

        private static string GetExpressionName(ExpressionSyntax expression)
        {
            return expression switch {
                IdentifierNameSyntax identifier => identifier.Identifier.Text,
                InvocationExpressionSyntax invocation => GetInvocationName(invocation),
                MemberAccessExpressionSyntax memberAccess => memberAccess.Name.Identifier.Text,
                _ => expression.ToString()
            };
        }

        private static string GetInvocationName(InvocationExpressionSyntax invocation)
        {
            return invocation.Expression switch {
                IdentifierNameSyntax identifier => identifier.Identifier.Text + "()",
                MemberAccessExpressionSyntax memberAccess => memberAccess.Name.Identifier.Text + "()",
                _ => invocation.ToString()
            };
        }

        private sealed class ValueTaskUsage
        {
            public int UsageCount { get; set; }
        }
    }
}
