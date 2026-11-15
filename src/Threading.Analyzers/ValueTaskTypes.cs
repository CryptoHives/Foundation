// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Threading.Analyzers;

using Microsoft.CodeAnalysis;

/// <summary>
/// The task types the analyzers reason about, resolved once per compilation and compared as symbols.
/// </summary>
internal sealed class ValueTaskTypes
{
    private ValueTaskTypes(Compilation compilation, INamedTypeSymbol valueTask)
    {
        ValueTask = valueTask;
        ValueTaskOfT = compilation.GetTypeByMetadataName("System.Threading.Tasks.ValueTask`1");
        Task = compilation.GetTypeByMetadataName("System.Threading.Tasks.Task");
        TaskOfT = compilation.GetTypeByMetadataName("System.Threading.Tasks.Task`1");
        ConfiguredValueTaskAwaitable = compilation.GetTypeByMetadataName("System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable");
        ConfiguredValueTaskAwaitableOfT = compilation.GetTypeByMetadataName("System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable`1");
    }

    public INamedTypeSymbol ValueTask { get; }

    public INamedTypeSymbol? ValueTaskOfT { get; }

    public INamedTypeSymbol? Task { get; }

    public INamedTypeSymbol? TaskOfT { get; }

    public INamedTypeSymbol? ConfiguredValueTaskAwaitable { get; }

    public INamedTypeSymbol? ConfiguredValueTaskAwaitableOfT { get; }

    /// <summary>
    /// The types of <paramref name="compilation"/>, or <see langword="null"/> where it has no
    /// <c>ValueTask</c> and there is nothing to analyze.
    /// </summary>
    public static ValueTaskTypes? Create(Compilation compilation)
    {
        INamedTypeSymbol? valueTask = compilation.GetTypeByMetadataName("System.Threading.Tasks.ValueTask");
        return valueTask is null ? null : new ValueTaskTypes(compilation, valueTask);
    }

    /// <summary>
    /// <c>ValueTask</c> or any <c>ValueTask&lt;T&gt;</c>.
    /// </summary>
    public bool IsValueTask(ITypeSymbol? type)
        => Is(type, ValueTask, ValueTaskOfT);

    /// <summary>
    /// <c>Task</c> or any <c>Task&lt;T&gt;</c>.
    /// </summary>
    public bool IsTask(ITypeSymbol? type)
        => Is(type, Task, TaskOfT);

    /// <summary>
    /// What <c>ValueTask.ConfigureAwait</c> returns.
    /// </summary>
    public bool IsConfiguredValueTask(ITypeSymbol? type)
        => Is(type, ConfiguredValueTaskAwaitable, ConfiguredValueTaskAwaitableOfT);

    private static bool Is(ITypeSymbol? type, INamedTypeSymbol? nonGeneric, INamedTypeSymbol? generic)
        => type is INamedTypeSymbol named &&
            (SymbolEqualityComparer.Default.Equals(named, nonGeneric) ||
             SymbolEqualityComparer.Default.Equals(named.OriginalDefinition, generic));
}
