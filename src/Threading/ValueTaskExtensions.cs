// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading;

using System.Threading.Tasks;

/// <summary>
/// Extension methods for <see cref="ValueTask"/> and <see cref="ValueTask{TResult}"/> 
/// to enable safe consumption patterns.
/// </summary>
public static class ValueTaskExtensions
{
#if NETFRAMEWORK || NETSTANDARD2_0
    /// <summary>
    /// Preserves the ValueTask for safe multiple consumption by converting it to a Task
    /// if it hasn't already completed.
    /// </summary>
    /// <param name="valueTask">The ValueTask to preserve.</param>
    /// <returns>
    /// A Task that can be safely awaited multiple times.
    /// If the ValueTask is already completed, returns a completed Task to avoid allocation.
    /// </returns>
    /// <remarks>
    /// <para>
    /// Use this method when you need to consume a ValueTask multiple times or pass it to
    /// methods that may consume it multiple times. This provides a safe pattern that:
    /// </para>
    /// <list type="bullet">
    /// <item><description>Avoids double-consumption issues with IValueTaskSource-backed ValueTasks</description></item>
    /// <item><description>Minimizes allocations by checking if already completed first</description></item>
    /// <item><description>Returns a Task that can be safely stored, passed, or awaited multiple times</description></item>
    /// </list>
    /// <para>
    /// Note: On .NET Core 2.1+, .NET 5+, and .NET Standard 2.1+, use the built-in 
    /// <see cref="ValueTask.Preserve"/> method instead, which returns a <see cref="ValueTask"/> 
    /// that can be awaited multiple times.
    /// </para>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code>
    /// ValueTask vt = SomeAsyncOperation();
    /// Task t = vt.Preserve();
    /// 
    /// // Now safe to await multiple times
    /// await t;
    /// await t;
    /// 
    /// // Or pass to methods expecting Task
    /// await Task.WhenAll(t, otherTask);
    /// </code>
    /// </remarks>
    public static Task Preserve(this ValueTask valueTask)
    {
        if (valueTask.IsCompletedSuccessfully)
        {
            return Task.CompletedTask;
        }

        return valueTask.AsTask();
    }

    /// <summary>
    /// Preserves the ValueTask for safe multiple consumption by converting it to a Task
    /// if it hasn't already completed.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="valueTask">The ValueTask to preserve.</param>
    /// <returns>
    /// A Task that can be safely awaited multiple times.
    /// If the ValueTask is already completed successfully, returns a completed Task with the result.
    /// </returns>
    /// <remarks>
    /// <para>
    /// Use this method when you need to consume a ValueTask multiple times or pass it to
    /// methods that may consume it multiple times. This provides a safe pattern that:
    /// </para>
    /// <list type="bullet">
    /// <item><description>Avoids double-consumption issues with IValueTaskSource-backed ValueTasks</description></item>
    /// <item><description>Minimizes allocations by checking if already completed first</description></item>
    /// <item><description>Returns a Task that can be safely stored, passed, or awaited multiple times</description></item>
    /// </list>
    /// <para>
    /// Note: On .NET Core 2.1+, .NET 5+, and .NET Standard 2.1+, use the built-in 
    /// <see cref="ValueTask{TResult}.Preserve"/> method instead, which returns a 
    /// <see cref="ValueTask{TResult}"/> that can be awaited multiple times.
    /// </para>
    /// <para>
    /// Example usage:
    /// </para>
    /// <code>
    /// ValueTask&lt;int&gt; vt = SomeAsyncOperation();
    /// Task&lt;int&gt; t = vt.Preserve();
    /// 
    /// // Now safe to await multiple times
    /// int result1 = await t;
    /// int result2 = await t;
    /// 
    /// // Or pass to methods expecting Task
    /// await Task.WhenAll(t, otherTask);
    /// </code>
    /// </remarks>
    public static Task<TResult> Preserve<TResult>(this ValueTask<TResult> valueTask)
    {
        if (valueTask.IsCompletedSuccessfully)
        {
            return Task.FromResult(valueTask.Result);
        }

        return valueTask.AsTask();
    }
#endif

    /// <summary>
    /// Safely awaits a ValueTask with ConfigureAwait(false).
    /// </summary>
    /// <param name="valueTask">The ValueTask to await.</param>
    /// <returns>A configured ValueTask awaitable.</returns>
    /// <remarks>
    /// This is a convenience method equivalent to <c>valueTask.ConfigureAwait(false)</c>
    /// but with a more discoverable name for library authors who always want to avoid
    /// capturing the synchronization context.
    /// </remarks>
    public static System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable AwaitWithoutContext(this ValueTask valueTask)
    {
        return valueTask.ConfigureAwait(false);
    }

    /// <summary>
    /// Safely awaits a ValueTask with ConfigureAwait(false).
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="valueTask">The ValueTask to await.</param>
    /// <returns>A configured ValueTask awaitable.</returns>
    /// <remarks>
    /// This is a convenience method equivalent to <c>valueTask.ConfigureAwait(false)</c>
    /// but with a more discoverable name for library authors who always want to avoid
    /// capturing the synchronization context.
    /// </remarks>
    public static System.Runtime.CompilerServices.ConfiguredValueTaskAwaitable<TResult> AwaitWithoutContext<TResult>(this ValueTask<TResult> valueTask)
    {
        return valueTask.ConfigureAwait(false);
    }
}
