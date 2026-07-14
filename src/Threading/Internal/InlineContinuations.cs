// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Internal;

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;

/// <summary>
/// Guards synchronous (inline) continuation execution against unbounded recursion.
/// </summary>
/// <remarks>
/// <para>
/// When a waiter is completed with <c>RunContinuationsAsynchronously == false</c>, its continuation
/// runs inline on the completing thread. That continuation may itself complete the next waiter
/// (e.g. a released lock waiter immediately releases the lock again), nesting one stack frame per
/// waiter — for a long chain this overflows the stack.
/// </para>
/// <para>
/// The guard counts the inline completion depth per thread. Below <see cref="MaxInlineDepth"/>
/// the continuation runs inline; beyond it, the completion falls back to the thread pool,
/// cutting the recursion while preserving the synchronous fast path for shallow chains.
/// </para>
/// <para>
/// The depth counter lives in a non-generic class so the thread-static access compiles to the
/// inlined fast pattern instead of the shared-generics runtime helper.
/// </para>
/// </remarks>
internal static class InlineContinuations
{
    /// <summary>
    /// The maximum number of nested inline completions per thread before
    /// falling back to the thread pool.
    /// </summary>
    internal const int MaxInlineDepth = 32;

    [ThreadStatic]
    private static int t_inlineDepth;

    /// <summary>
    /// Completes the core with a result, running the continuation inline when allowed
    /// by the core's configuration and the current inline completion depth.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void SetResult<T>(ref ManualResetValueTaskSourceCore<T> core, T result)
    {
        if (core.RunContinuationsAsynchronously)
        {
            core.SetResult(result);
            return;
        }

        if (t_inlineDepth >= MaxInlineDepth)
        {
            // Too deep: force this completion onto the thread pool to cut the recursion.
            core.RunContinuationsAsynchronously = true;
            core.SetResult(result);
            return;
        }

        t_inlineDepth++;
        try
        {
            core.SetResult(result);
        }
        finally
        {
            t_inlineDepth--;
        }
    }

    /// <summary>
    /// Completes the core with an exception, running the continuation inline when allowed
    /// by the core's configuration and the current inline completion depth.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void SetException<T>(ref ManualResetValueTaskSourceCore<T> core, Exception ex)
    {
        if (core.RunContinuationsAsynchronously)
        {
            core.SetException(ex);
            return;
        }

        if (t_inlineDepth >= MaxInlineDepth)
        {
            // Too deep: force this completion onto the thread pool to cut the recursion.
            core.RunContinuationsAsynchronously = true;
            core.SetException(ex);
            return;
        }

        t_inlineDepth++;
        try
        {
            core.SetException(ex);
        }
        finally
        {
            t_inlineDepth--;
        }
    }
}
