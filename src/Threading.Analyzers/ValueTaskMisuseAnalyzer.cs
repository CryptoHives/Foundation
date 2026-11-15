// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.FlowAnalysis;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;

/// <summary>
/// Analyzer that detects common ValueTask misuse patterns.
/// </summary>
/// <remarks>
/// Consumption (CHT001) and capture (CHT010) are tracked as data flow over each function's control flow
/// graph, so a ValueTask consumed once on each of two branches is fine while one consumed once inside a
/// loop is not. The remaining rules look at single operations or declarations.
/// </remarks>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class ValueTaskMisuseAnalyzer : DiagnosticAnalyzer
{
    private static readonly ImmutableArray<DiagnosticDescriptor> s_supportedDiagnostics = ImmutableArray.Create(
        DiagnosticDescriptors.MultipleAwait,
        DiagnosticDescriptors.BlockingGetResult,
        DiagnosticDescriptors.StoredInField,
        DiagnosticDescriptors.DirectResultAccess,
        DiagnosticDescriptors.AsTaskStoredBeforeSignal,
        DiagnosticDescriptors.NotConsumed,
        DiagnosticDescriptors.CapturedInClosure);

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

            start.RegisterSyntaxNodeAction(c => AnalyzeField(c, types), SyntaxKind.FieldDeclaration);
            start.RegisterSymbolAction(c => AnalyzeProperty(c, types), SymbolKind.Property);
            start.RegisterOperationAction(c => AnalyzeExternalFieldAssignment(c, types), OperationKind.SimpleAssignment);
            start.RegisterOperationAction(c => AnalyzeGetResult(c, types), OperationKind.Invocation);
            start.RegisterOperationAction(c => AnalyzeResult(c, types), OperationKind.PropertyReference);
            start.RegisterOperationAction(c => AnalyzeExpressionStatement(c, types), OperationKind.ExpressionStatement);
            start.RegisterOperationBlockAction(c => AnalyzeConsumption(c, types));
            start.RegisterSyntaxNodeAction(c => AnalyzeLocalDeclaration(c, types), SyntaxKind.LocalDeclarationStatement);
        });
    }

    // ── CHT003: ValueTask stored in a field or auto-property ──────────────────

    private static void AnalyzeField(SyntaxNodeAnalysisContext context, ValueTaskTypes types)
    {
        var declaration = (FieldDeclarationSyntax)context.Node;
        if (!types.IsValueTask(context.SemanticModel.GetTypeInfo(declaration.Declaration.Type, context.CancellationToken).Type))
        {
            return;
        }

        bool isReadOnly = declaration.Modifiers.Any(SyntaxKind.ReadOnlyKeyword);

        foreach (VariableDeclaratorSyntax declarator in declaration.Declaration.Variables)
        {
            // A completed value is safe to consume any number of times, so a readonly field holding one
            // is a cache, not a hazard.
            if (isReadOnly && declarator.Initializer is not null &&
                IsReusableValueTask(context.SemanticModel, declarator.Initializer.Value, context.CancellationToken))
            {
                continue;
            }

            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.StoredInField, declarator.GetLocation(), declarator.Identifier.Text));
        }
    }

    private static void AnalyzeProperty(SymbolAnalysisContext context, ValueTaskTypes types)
    {
        var property = (IPropertySymbol)context.Symbol;
        if (property.IsAbstract || property.ContainingType.TypeKind == TypeKind.Interface || !types.IsValueTask(property.Type))
        {
            return;
        }

        foreach (SyntaxReference reference in property.DeclaringSyntaxReferences)
        {
            if (reference.GetSyntax(context.CancellationToken) is PropertyDeclarationSyntax { AccessorList: { } accessors } declaration &&
                accessors.Accessors.Any(a => a.IsKind(SyntaxKind.GetAccessorDeclaration) && IsAuto(a)) &&
                accessors.Accessors.Any(a => a.Kind() is SyntaxKind.SetAccessorDeclaration or SyntaxKind.InitAccessorDeclaration && IsAuto(a)))
            {
                context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.StoredInField, declaration.GetLocation(), property.Name));
            }
        }

        static bool IsAuto(AccessorDeclarationSyntax accessor) => accessor.Body is null && accessor.ExpressionBody is null;
    }

    /// <summary>
    /// A field declared in this compilation is reported at its declaration; one declared elsewhere can
    /// only be reported where a ValueTask is stored into it.
    /// </summary>
    private static void AnalyzeExternalFieldAssignment(OperationAnalysisContext context, ValueTaskTypes types)
    {
        var assignment = (ISimpleAssignmentOperation)context.Operation;
        if (assignment.Target is IFieldReferenceOperation { Field: { DeclaringSyntaxReferences.Length: 0 } field } &&
            types.IsValueTask(WithoutConversions(assignment.Value).Type))
        {
            context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.StoredInField, assignment.Syntax.GetLocation(), field.Name));
        }
    }

    // ── CHT002: GetAwaiter().GetResult() ─────────────────────────────────────

    private static void AnalyzeGetResult(OperationAnalysisContext context, ValueTaskTypes types)
    {
        var invocation = (IInvocationOperation)context.Operation;
        if (invocation.TargetMethod.Name != "GetResult" ||
            WithoutConversions(invocation.Instance) is not IInvocationOperation { TargetMethod.Name: "GetAwaiter", Instance: { } awaitable })
        {
            return;
        }

        IOperation valueTask = WithoutConversions(awaitable);
        if (types.IsConfiguredValueTask(valueTask.Type) &&
            valueTask is IInvocationOperation { TargetMethod.Name: "ConfigureAwait", Instance: { } configured })
        {
            valueTask = WithoutConversions(configured);
        }

        if (!types.IsValueTask(valueTask.Type) ||
            IsPreserveCall(valueTask) ||
            IsPreservedLocal(valueTask, context.CancellationToken) ||
            IsGuardedByCompletionCheck(invocation.SemanticModel!, invocation.Syntax, valueTask.Syntax, context.CancellationToken))
        {
            return;
        }

        context.ReportDiagnostic(Diagnostic.Create(
            DiagnosticDescriptors.BlockingGetResult,
            invocation.Syntax.GetLocation(),
            GetExpressionName(valueTask.Syntax)));
    }

    // ── CHT005: .Result ───────────────────────────────────────────────────────

    private static void AnalyzeResult(OperationAnalysisContext context, ValueTaskTypes types)
    {
        var reference = (IPropertyReferenceOperation)context.Operation;
        if (reference.Property.Name != "Result" || reference.Instance is not { } instance || !types.IsValueTask(instance.Type))
        {
            return;
        }

        // Safe in the completing branch of a guard:
        //   if (vt.IsCompletedSuccessfully) { _ = vt.Result; }
        //   vt.IsCompletedSuccessfully ? vt.Result : fallback
        if (IsGuardedByCompletionCheck(reference.SemanticModel!, reference.Syntax, instance.Syntax, context.CancellationToken))
        {
            return;
        }

        context.ReportDiagnostic(Diagnostic.Create(
            DiagnosticDescriptors.DirectResultAccess,
            reference.Syntax.GetLocation(),
            GetExpressionName(instance.Syntax)));
    }

    // ── CHT008: ValueTask result dropped ──────────────────────────────────────

    /// <summary>
    /// A call whose ValueTask is the whole statement, including the implicit statement of an
    /// expression-bodied lambda or member that returns nothing.
    /// </summary>
    private static void AnalyzeExpressionStatement(OperationAnalysisContext context, ValueTaskTypes types)
    {
        var statement = (IExpressionStatementOperation)context.Operation;
        if (statement.Operation is IInvocationOperation invocation && types.IsValueTask(invocation.Type))
        {
            context.ReportDiagnostic(Diagnostic.Create(
                DiagnosticDescriptors.NotConsumed,
                invocation.Syntax.GetLocation(),
                GetExpressionName(invocation.Syntax)));
        }
    }

    // ── CHT001 / CHT010: consumption data flow ───────────────────────────────

    private static void AnalyzeConsumption(OperationBlockAnalysisContext context, ValueTaskTypes types)
    {
        var reported = new HashSet<Location>();
        var roots = new HashSet<IOperation>();

        foreach (IOperation block in context.OperationBlocks)
        {
            IOperation root = block;
            while (root.Parent is not null)
            {
                root = root.Parent;
            }

            if (!roots.Add(root))
            {
                continue;
            }

            ControlFlowGraph? graph = root switch {
                IMethodBodyOperation body => ControlFlowGraph.Create(body, context.CancellationToken),
                IConstructorBodyOperation body => ControlFlowGraph.Create(body, context.CancellationToken),
                IBlockOperation body => ControlFlowGraph.Create(body, context.CancellationToken),
                IFieldInitializerOperation initializer => ControlFlowGraph.Create(initializer, context.CancellationToken),
                IPropertyInitializerOperation initializer => ControlFlowGraph.Create(initializer, context.CancellationToken),
                _ => null,
            };

            if (graph is not null)
            {
                AnalyzeGraph(context, types, graph, context.OwningSymbol, reported);
            }
        }
    }

    /// <summary>
    /// Runs the consumption flow over <paramref name="graph"/>, then over the graph of every lambda and
    /// local function inside it, each of which owns its own locals and captures the rest.
    /// </summary>
    private static void AnalyzeGraph(
        OperationBlockAnalysisContext context,
        ValueTaskTypes types,
        ControlFlowGraph graph,
        ISymbol owner,
        HashSet<Location> reported)
    {
        new ConsumptionFlow(context, types, graph, owner, reported).Run();

        foreach (BasicBlock block in graph.Blocks)
        {
            foreach (IOperation operation in OperationsOf(block))
            {
                foreach (IFlowAnonymousFunctionOperation function in operation.DescendantsAndSelf().OfType<IFlowAnonymousFunctionOperation>())
                {
                    AnalyzeGraph(context, types, graph.GetAnonymousFunctionControlFlowGraph(function, context.CancellationToken), function.Symbol, reported);
                }
            }
        }

        foreach (IMethodSymbol localFunction in graph.LocalFunctions)
        {
            AnalyzeGraph(context, types, graph.GetLocalFunctionControlFlowGraph(localFunction, context.CancellationToken), localFunction, reported);
        }
    }

    private static IEnumerable<IOperation> OperationsOf(BasicBlock block)
        => block.BranchValue is null ? block.Operations : block.Operations.Append(block.BranchValue);

    /// <summary>
    /// Forward data flow of how often each ValueTask local or parameter has been consumed on the way to
    /// each point. Counts merge by taking the higher, so a second consumption on any one path is
    /// reported, and loops run to a fixpoint, so a consumption inside a loop of a value assigned outside
    /// it is a second one on the next iteration.
    /// </summary>
    private sealed class ConsumptionFlow
    {
        /// <summary>The value was produced by <c>Preserve()</c> and may be consumed any number of times.</summary>
        private const int Preserved = -1;

        private readonly OperationBlockAnalysisContext _context;
        private readonly ValueTaskTypes _types;
        private readonly ControlFlowGraph _graph;
        private readonly ISymbol _owner;
        private readonly HashSet<Location> _reported;
        private readonly Dictionary<ISymbol, int>?[] _in;
        private readonly Dictionary<int, List<int>> _handlersByTryBlock = new Dictionary<int, List<int>>();
        private readonly Dictionary<ControlFlowRegion, Dictionary<ISymbol, int>> _finallyExits = new Dictionary<ControlFlowRegion, Dictionary<ISymbol, int>>();
        private readonly Dictionary<ControlFlowRegion, List<int>> _destinationsThroughFinally = new Dictionary<ControlFlowRegion, List<int>>();
        private readonly Dictionary<CaptureId, List<IOperation>> _captures = new Dictionary<CaptureId, List<IOperation>>();
        private bool _report;

        public ConsumptionFlow(OperationBlockAnalysisContext context, ValueTaskTypes types, ControlFlowGraph graph, ISymbol owner, HashSet<Location> reported)
        {
            _context = context;
            _types = types;
            _graph = graph;
            _owner = owner;
            _reported = reported;
            _in = new Dictionary<ISymbol, int>?[graph.Blocks.Length];
        }

        public void Run()
        {
            IndexHandlers(_graph.Root);
            IndexCaptures();

            var initial = new Dictionary<ISymbol, int>(SymbolEqualityComparer.Default);
            if (_owner is IMethodSymbol method)
            {
                foreach (IParameterSymbol parameter in method.Parameters)
                {
                    if (_types.IsValueTask(parameter.Type))
                    {
                        initial[parameter] = 0;
                    }
                }
            }

            _in[0] = initial;
            var pending = new Queue<int>();
            var queued = new bool[_graph.Blocks.Length];
            Enqueue(pending, queued, 0);

            while (pending.Count > 0)
            {
                int ordinal = pending.Dequeue();
                queued[ordinal] = false;
                BasicBlock block = _graph.Blocks[ordinal];

                Dictionary<ISymbol, int> state = Copy(_in[ordinal]);
                Transfer(block, state);

                foreach (int destination in Successors(block, state))
                {
                    if (MergeInto(destination, state))
                    {
                        Enqueue(pending, queued, destination);
                    }
                }

                // An exception can leave a try block at any point, so its handlers see every state the
                // block passes through.
                if (_handlersByTryBlock.TryGetValue(ordinal, out List<int>? handlers))
                {
                    foreach (int handler in handlers)
                    {
                        bool changed = MergeInto(handler, _in[ordinal]!);
                        changed |= MergeInto(handler, state);
                        if (changed)
                        {
                            Enqueue(pending, queued, handler);
                        }
                    }
                }

                if (block.FallThroughSuccessor is { Semantics: ControlFlowBranchSemantics.StructuredExceptionHandling } &&
                    block.EnclosingRegion.Kind == ControlFlowRegionKind.Finally)
                {
                    ControlFlowRegion finallyRegion = block.EnclosingRegion;
                    if (Merge(GetOrAdd(_finallyExits, finallyRegion), state) &&
                        _destinationsThroughFinally.TryGetValue(finallyRegion, out List<int>? destinations))
                    {
                        foreach (int destination in destinations)
                        {
                            if (MergeInto(destination, state))
                            {
                                Enqueue(pending, queued, destination);
                            }
                        }
                    }
                }
            }

            // With the fixpoint reached, replay every block once more and report what it consumes twice.
            _report = true;
            for (int ordinal = 0; ordinal < _graph.Blocks.Length; ordinal++)
            {
                if (_in[ordinal] is { } entry && _graph.Blocks[ordinal].IsReachable)
                {
                    Transfer(_graph.Blocks[ordinal], Copy(entry));
                }
            }
        }

        private static void Enqueue(Queue<int> pending, bool[] queued, int ordinal)
        {
            if (!queued[ordinal])
            {
                queued[ordinal] = true;
                pending.Enqueue(ordinal);
            }
        }

        private static Dictionary<ISymbol, int> Copy(Dictionary<ISymbol, int>? state)
            => state is null
                ? new Dictionary<ISymbol, int>(SymbolEqualityComparer.Default)
                : new Dictionary<ISymbol, int>(state, SymbolEqualityComparer.Default);

        private static TValue GetOrAdd<TValue>(Dictionary<ControlFlowRegion, TValue> map, ControlFlowRegion region)
            where TValue : new()
        {
            if (!map.TryGetValue(region, out TValue? value))
            {
                value = new TValue();
                map[region] = value;
            }

            return value;
        }

        private bool MergeInto(int ordinal, Dictionary<ISymbol, int> state)
        {
            if (_in[ordinal] is null)
            {
                _in[ordinal] = Copy(state);
                return true;
            }

            return Merge(_in[ordinal]!, state);
        }

        /// <summary>
        /// Raises each count in <paramref name="target"/> to the one in <paramref name="source"/>.
        /// </summary>
        private static bool Merge(Dictionary<ISymbol, int> target, Dictionary<ISymbol, int> source)
        {
            bool changed = false;
            foreach (KeyValuePair<ISymbol, int> entry in source)
            {
                if (!target.TryGetValue(entry.Key, out int count) || entry.Value > count)
                {
                    target[entry.Key] = entry.Value;
                    changed = true;
                }
            }

            return changed;
        }

        /// <summary>
        /// The blocks control reaches next. A branch that leaves through <c>finally</c> blocks also
        /// carries whatever those blocks consume, now and as their exit state grows.
        /// </summary>
        private IEnumerable<int> Successors(BasicBlock block, Dictionary<ISymbol, int> state)
        {
            foreach (ControlFlowBranch? branch in new[] { block.FallThroughSuccessor, block.ConditionalSuccessor })
            {
                if (branch?.Destination is not { } destination)
                {
                    continue;
                }

                foreach (ControlFlowRegion finallyRegion in branch.FinallyRegions)
                {
                    List<int> destinations = GetOrAdd(_destinationsThroughFinally, finallyRegion);
                    if (!destinations.Contains(destination.Ordinal))
                    {
                        destinations.Add(destination.Ordinal);
                    }

                    if (_finallyExits.TryGetValue(finallyRegion, out Dictionary<ISymbol, int>? exit))
                    {
                        Merge(state, exit);
                    }
                }

                yield return destination.Ordinal;
            }
        }

        /// <summary>
        /// Maps each block of a try region to the first block of each of its handlers, which control
        /// reaches by an exception rather than by a branch.
        /// </summary>
        private void IndexHandlers(ControlFlowRegion region)
        {
            if (region.Kind is ControlFlowRegionKind.TryAndCatch or ControlFlowRegionKind.TryAndFinally)
            {
                ControlFlowRegion tryRegion = region.NestedRegions[0];
                for (int handler = 1; handler < region.NestedRegions.Length; handler++)
                {
                    int entry = region.NestedRegions[handler].FirstBlockOrdinal;
                    for (int ordinal = tryRegion.FirstBlockOrdinal; ordinal <= tryRegion.LastBlockOrdinal; ordinal++)
                    {
                        if (!_handlersByTryBlock.TryGetValue(ordinal, out List<int>? handlers))
                        {
                            handlers = new List<int>();
                            _handlersByTryBlock[ordinal] = handlers;
                        }

                        handlers.Add(entry);
                    }
                }
            }

            foreach (ControlFlowRegion nested in region.NestedRegions)
            {
                IndexHandlers(nested);
            }
        }

        /// <summary>
        /// Maps each flow capture to the values the branches leading to it store, so <c>c ? vt : other</c>
        /// consumes <c>vt</c> where the result is consumed.
        /// </summary>
        private void IndexCaptures()
        {
            foreach (BasicBlock block in _graph.Blocks)
            {
                foreach (IFlowCaptureOperation capture in block.Operations.SelectMany(o => o.DescendantsAndSelf()).OfType<IFlowCaptureOperation>())
                {
                    if (!_captures.TryGetValue(capture.Id, out List<IOperation>? values))
                    {
                        values = new List<IOperation>();
                        _captures[capture.Id] = values;
                    }

                    values.Add(WithoutConversions(capture.Value));
                }
            }
        }

        private void Transfer(BasicBlock block, Dictionary<ISymbol, int> state)
        {
            foreach (IOperation operation in block.Operations)
            {
                Visit(operation, state);
            }

            if (block.BranchValue is { } branchValue)
            {
                Visit(branchValue, state);

                // `return vt;` hands the ValueTask on, which is a consumption here.
                if (block.FallThroughSuccessor?.Semantics == ControlFlowBranchSemantics.Return)
                {
                    Consume(WithoutConversions(branchValue), state);
                }
            }
        }

        /// <summary>
        /// Visits operands before the operation that uses them, matching evaluation order.
        /// </summary>
        private void Visit(IOperation operation, Dictionary<ISymbol, int> state)
        {
            foreach (IOperation child in operation.ChildOperations)
            {
                Visit(child, state);
            }

            switch (operation)
            {
                case IAwaitOperation awaitOperation:
                    IOperation awaited = WithoutConversions(awaitOperation.Operation);
                    if (awaited is IInvocationOperation { TargetMethod.Name: "ConfigureAwait", Instance: { } configured })
                    {
                        awaited = WithoutConversions(configured);
                    }

                    Consume(awaited, state);
                    break;

                case IInvocationOperation { TargetMethod.Name: "AsTask" or "Preserve" or "GetAwaiter", Instance: { } instance }:
                    Consume(WithoutConversions(instance), state);
                    break;

                case IPropertyReferenceOperation { Property.Name: "Result", Instance: { } instance }:
                    Consume(WithoutConversions(instance), state);
                    break;

                case ISimpleAssignmentOperation assignment when TrackedSymbol(assignment.Target) is { } assigned:
                    state[assigned] = IsPreserveCall(WithoutConversions(assignment.Value)) ? Preserved : 0;
                    break;

                case IArgumentOperation { Parameter.RefKind: RefKind.Out or RefKind.Ref } argument when TrackedSymbol(argument.Value) is { } passed:
                    state[passed] = 0;
                    break;
            }
        }

        /// <summary>
        /// The ValueTask local or parameter <paramref name="operation"/> refers to, owned or captured.
        /// </summary>
        private ISymbol? TrackedSymbol(IOperation operation)
        {
            ISymbol? symbol = operation switch {
                ILocalReferenceOperation local => local.Local,
                IParameterReferenceOperation parameter => parameter.Parameter,
                _ => null,
            };

            return symbol is not null && _types.IsValueTask(operation.Type) ? symbol : null;
        }

        private void Consume(IOperation operation, Dictionary<ISymbol, int> state)
        {
            if (operation is IFlowCaptureReferenceOperation reference)
            {
                if (_captures.TryGetValue(reference.Id, out List<IOperation>? values))
                {
                    foreach (IOperation value in values)
                    {
                        Consume(value, state);
                    }
                }

                return;
            }

            if (TrackedSymbol(operation) is not { } symbol)
            {
                return;
            }

            // Declared outside this lambda or local function: whether it was consumed before the closure
            // runs, or by an earlier run of it, is out of sight here.
            if (!SymbolEqualityComparer.Default.Equals(symbol.ContainingSymbol, _owner))
            {
                if (!IsPreservedLocal(operation, _context.CancellationToken))
                {
                    Report(DiagnosticDescriptors.CapturedInClosure, operation, symbol);
                }

                return;
            }

            state.TryGetValue(symbol, out int count);
            if (count == Preserved)
            {
                return;
            }

            if (count >= 1)
            {
                Report(DiagnosticDescriptors.MultipleAwait, operation, symbol);
            }

            state[symbol] = Math.Min(count + 1, 2);
        }

        private void Report(DiagnosticDescriptor descriptor, IOperation operation, ISymbol symbol)
        {
            Location location = operation.Syntax.GetLocation();
            if (_report && _reported.Add(location))
            {
                _context.ReportDiagnostic(Diagnostic.Create(descriptor, location, symbol.Name));
            }
        }
    }

    // ── CHT007: AsTask() stored, other work, then awaited ─────────────────────

    /// <summary>
    /// Reports CHT007 for <c>Task t = vt.AsTask();</c> whose only use is a single <c>await t</c> that
    /// comes after other statements in the same block. A Task consumed more than once is the ordinary
    /// conversion idiom, and the one CHT001's own fix produces, so it is left alone.
    /// </summary>
    private static void AnalyzeLocalDeclaration(SyntaxNodeAnalysisContext context, ValueTaskTypes types)
    {
        var declaration = (LocalDeclarationStatementSyntax)context.Node;
        if (declaration.Parent is not BlockSyntax block)
        {
            return;
        }

        foreach (VariableDeclaratorSyntax variable in declaration.Declaration.Variables)
        {
            if (IsAsTaskAwaitedLater(context.SemanticModel, types, block, declaration, variable, context.CancellationToken))
            {
                context.ReportDiagnostic(Diagnostic.Create(DiagnosticDescriptors.AsTaskStoredBeforeSignal, variable.GetLocation()));
            }
        }
    }

    private static bool IsAsTaskAwaitedLater(
        SemanticModel model,
        ValueTaskTypes types,
        BlockSyntax block,
        LocalDeclarationStatementSyntax declaration,
        VariableDeclaratorSyntax variable,
        CancellationToken cancellationToken)
    {
        if (variable.Initializer?.Value is not InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax { Name.Identifier.Text: "AsTask" } asTask, ArgumentList.Arguments.Count: 0 } ||
            !types.IsValueTask(model.GetTypeInfo(asTask.Expression, cancellationToken).Type) ||
            model.GetDeclaredSymbol(variable, cancellationToken) is not { } local)
        {
            return false;
        }

        string name = variable.Identifier.Text;
        IdentifierNameSyntax? only = null;
        foreach (IdentifierNameSyntax identifier in block.DescendantNodes().OfType<IdentifierNameSyntax>())
        {
            if (identifier.Identifier.Text != name ||
                !SymbolEqualityComparer.Default.Equals(model.GetSymbolInfo(identifier, cancellationToken).Symbol, local))
            {
                continue;
            }

            if (only is not null)
            {
                return false;
            }

            only = identifier;
        }

        if (only is null)
        {
            return false;
        }

        SyntaxNode awaited = only;
        if (only.Parent is MemberAccessExpressionSyntax { Name.Identifier.Text: "ConfigureAwait" } configure &&
            configure.Expression == only &&
            configure.Parent is InvocationExpressionSyntax configureCall)
        {
            awaited = configureCall;
        }

        if (awaited.Parent is not AwaitExpressionSyntax await)
        {
            return false;
        }

        StatementSyntax? awaitStatement = null;
        for (SyntaxNode? node = await.Parent; node is not null && node != block; node = node.Parent)
        {
            if (node is AnonymousFunctionExpressionSyntax or LocalFunctionStatementSyntax)
            {
                return false;
            }

            if (node is StatementSyntax statement && statement.Parent == block)
            {
                awaitStatement = statement;
            }
        }

        return awaitStatement is not null &&
            block.Statements.IndexOf(awaitStatement) - block.Statements.IndexOf(declaration) >= 2;
    }

    // ── Shared helpers ────────────────────────────────────────────────────────

    private static IOperation WithoutConversions(IOperation? operation)
    {
        while (operation is IConversionOperation conversion)
        {
            operation = conversion.Operand;
        }

        return operation!;
    }

    private static bool IsPreserveCall(IOperation operation)
        => operation is IInvocationOperation { TargetMethod.Name: "Preserve", Arguments.Length: 0, Instance: not null };

    /// <summary>
    /// Whether <paramref name="operation"/> reads a local declared with a <c>Preserve()</c> initializer,
    /// which may be consumed any number of times wherever it is read.
    /// </summary>
    private static bool IsPreservedLocal(IOperation operation, CancellationToken cancellationToken)
    {
        if (operation is not ILocalReferenceOperation { Local: { } local })
        {
            return false;
        }

        foreach (SyntaxReference reference in local.DeclaringSyntaxReferences)
        {
            if (reference.GetSyntax(cancellationToken) is VariableDeclaratorSyntax {
                Initializer.Value: InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax { Name.Identifier.Text: "Preserve" }, ArgumentList.Arguments.Count: 0 }
            })
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Whether <paramref name="expression"/> produces a ValueTask that is already complete and not backed
    /// by an <c>IValueTaskSource</c>: <c>default</c>, <c>CompletedTask</c>, <c>FromResult</c>, or a
    /// constructor taking a result or a <c>Task</c>.
    /// </summary>
    private static bool IsReusableValueTask(SemanticModel model, ExpressionSyntax expression, CancellationToken cancellationToken)
    {
        switch (expression)
        {
            case LiteralExpressionSyntax literal when literal.IsKind(SyntaxKind.DefaultLiteralExpression):
            case DefaultExpressionSyntax:
                return true;

            case MemberAccessExpressionSyntax { Name.Identifier.Text: "CompletedTask" }:
            case InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax { Name.Identifier.Text: "FromResult" } }:
                return true;

            case BaseObjectCreationExpressionSyntax creation when creation.ArgumentList is { Arguments.Count: 1 } arguments:
                ITypeSymbol? argumentType = model.GetTypeInfo(arguments.Arguments[0].Expression, cancellationToken).Type;
                return argumentType is not null &&
                    argumentType.Name != "IValueTaskSource" &&
                    !argumentType.AllInterfaces.Any(i => i.Name == "IValueTaskSource");

            default:
                return false;
        }
    }

    /// <summary>
    /// Returns true when <paramref name="startNode"/> is textually enclosed in a guarded branch
    /// that guarantees the ValueTask identified by <paramref name="valueTaskExpression"/> is already
    /// complete.  Two guard shapes are recognised:
    /// <list type="bullet">
    ///   <item><c>if (vt.IsCompletedSuccessfully) { /* startNode here */ }</c> – then-branch of an if</item>
    ///   <item><c>vt.IsCompletedSuccessfully ? /* startNode here */ : …</c> – WhenTrue of a ternary</item>
    /// </list>
    /// The else/WhenFalse branches are never considered guarded.
    /// </summary>
    private static bool IsGuardedByCompletionCheck(SemanticModel model, SyntaxNode startNode, SyntaxNode valueTaskExpression, CancellationToken cancellationToken)
    {
        if (valueTaskExpression is not IdentifierNameSyntax identifier ||
            model.GetSymbolInfo(identifier, cancellationToken).Symbol is not { } symbol)
        {
            return false;
        }

        SyntaxNode? child = startNode;
        for (SyntaxNode? node = startNode.Parent; node is not null; child = node, node = node.Parent)
        {
            if (node is IfStatementSyntax ifStatement &&
                child == ifStatement.Statement &&
                IsCompletionPropertyCheck(model, ifStatement.Condition, symbol, cancellationToken))
            {
                return true;
            }

            if (node is ConditionalExpressionSyntax conditional &&
                child == conditional.WhenTrue &&
                IsCompletionPropertyCheck(model, conditional.Condition, symbol, cancellationToken))
            {
                return true;
            }

            if (node is MemberDeclarationSyntax or LocalFunctionStatementSyntax or AnonymousFunctionExpressionSyntax)
            {
                break;
            }
        }

        return false;
    }

    private static bool IsCompletionPropertyCheck(SemanticModel model, ExpressionSyntax condition, ISymbol valueTaskSymbol, CancellationToken cancellationToken)
    {
        while (condition is ParenthesizedExpressionSyntax parenthesized)
        {
            condition = parenthesized.Expression;
        }

        return condition is MemberAccessExpressionSyntax { Name.Identifier.Text: "IsCompletedSuccessfully" or "IsCompleted" } memberAccess &&
            SymbolEqualityComparer.Default.Equals(model.GetSymbolInfo(memberAccess.Expression, cancellationToken).Symbol, valueTaskSymbol);
    }

    private static string GetExpressionName(SyntaxNode expression)
        => expression switch {
            IdentifierNameSyntax identifier => identifier.Identifier.Text,
            InvocationExpressionSyntax { Expression: IdentifierNameSyntax identifier } => identifier.Identifier.Text + "()",
            InvocationExpressionSyntax { Expression: MemberAccessExpressionSyntax memberAccess } => memberAccess.Name.Identifier.Text + "()",
            MemberAccessExpressionSyntax memberAccess => memberAccess.Name.Identifier.Text,
            _ => expression.ToString()
        };
}
