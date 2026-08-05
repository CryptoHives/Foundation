// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Internal;

using System.Runtime.CompilerServices;
using System.Threading;

/// <summary>
/// A lightweight, non reentrant spin lock for
/// internal use in the threading libraries.
/// </summary>
/// <remarks>
/// <para>
/// <b>Contention policy:</b> every critical section this lock guards across the library is short,
/// synchronous and bounded - no <see langword="await"/> ever happens while it is held - so a waiter is
/// expected to get in after a handful of spins or yields. The waiting strategy is tuned for exactly that
/// shape.
/// </para>
/// <para>
/// In particular, <see cref="SpinWait.SpinOnce()"/>'s default behaviour is deliberately <em>not</em> used:
/// it escalates to <see cref="Thread.Sleep(int)"/> with an argument of 1 after about 20 spins, and every
/// call after that sleeps again. On Windows <c>Thread.Sleep(1)</c> does not sleep one millisecond - it
/// may round up to the system scheduler quantum, roughly 15.6 ms. For a lock whose critical sections are
/// measured in nanoseconds that turns contention into a latency cliff rather than a gradual slowdown.
/// </para>
/// <para>
/// Instead the escalation threshold is raised to <see cref="Sleep1Threshold"/>, far beyond what a healthy
/// contended acquisition of a nanosecond-scale critical section should ever need. Below it the lock
/// spins and then yields (<c>Thread.Yield</c>/<c>Thread.Sleep(0)</c>), which hands the core to the lock
/// holder without ever parking the waiter for a whole quantum. The threshold is retained rather than
/// disabled outright (<c>SpinOnce(-1)</c>) purely as a safety valve: this is a general-purpose library
/// that may run on a single-core container or with the holder descheduled by a long GC pause, and in
/// those genuinely pathological cases backing off is better than yielding forever.
/// </para>
/// </remarks>
internal struct SpinLock
{
    /// <summary>
    /// Number of spin iterations before <see cref="Thread.Sleep(int)"/> with an argument of 1 - and with
    /// it the scheduler-quantum penalty described in the type remarks - is permitted as a last resort.
    /// The framework default is 20; the critical sections guarded here are orders of magnitude shorter
    /// than that default is tuned for, so this deliberately sits well above any healthy contention.
    /// </summary>
    /// <remarks>
    /// Internal rather than private so the spin-cost tests can convert this budget into the wall-clock
    /// window it actually buys, rather than restating the number and drifting from it.
    /// </remarks>
    internal const int Sleep1Threshold = 200;

#if !NET5_0_OR_GREATER
    /// <summary>
    /// <see cref="SpinWait"/>'s own built-in escalation point - the spin count at which it starts using
    /// <see cref="Thread.Sleep(int)"/> with an argument of 1 on every subsequent call. Below this the
    /// framework's tuning is exactly what we want; at and above it we take the backoff over by hand.
    /// </summary>
    private const int FrameworkSleep1Threshold = 20;

    /// <summary>How often a yield is replaced by <c>Thread.Sleep(0)</c>, matching SpinWait's own ratio.</summary>
    private const int Sleep0EveryHowManyYields = 5;
#endif

    private volatile int _state;

    public SpinLock()
        => _state = 0;

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public bool TryEnter()
        => Interlocked.Exchange(ref _state, 1) == 0;

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public void Enter()
    {
        if (!TryEnter())
        {
            EnterCore();
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void EnterCore()
    {
        var spinWait = new SpinWait();
        int spinCount = 0;
        do
        {
            SpinOnce(ref spinWait, ref spinCount);
        } while (!TryEnter());
    }

    /// <summary>
    /// One iteration of this lock's backoff curve: the step a waiter takes between two failed attempts
    /// to acquire.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Extracted from <see cref="EnterCore"/>, and internal rather than private, so the spin-cost tests
    /// can time exactly the step the lock takes on every target framework instead of a replica of it -
    /// the two targets take materially different code paths, so a replica would be measuring the wrong
    /// one half of the time.
    /// </para>
    /// <para>
    /// On targets with the <c>SpinOnce(int)</c> overload this is a straight delegation: the overload
    /// keeps the runtime's own spin/yield tuning (including its single-processor special case) while
    /// moving the <c>Thread.Sleep(1)</c> cliff to a value tuned for the Async primitives. Elsewhere the
    /// overload does not exist, so the framework's own <see cref="SpinWait"/> is driven for as long as
    /// it is safe to - which is exactly up to the point where it would start sleeping a quantum - and
    /// only beyond that is the backoff driven by hand. Reusing <see cref="SpinWait"/> below that point
    /// keeps the runtime's processor-count-aware spin durations and yield/<c>Sleep(0)</c> ratio rather
    /// than reimplementing them.
    /// </para>
    /// </remarks>
    /// <param name="spinWait">The framework spin state.</param>
    /// <param name="spinCount">
    /// Iterations elapsed, counted separately from <see cref="SpinWait.Count"/> because that property
    /// stops advancing once this stops calling <see cref="SpinWait.SpinOnce()"/>.
    /// </param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void SpinOnce(ref SpinWait spinWait, ref int spinCount)
    {
        spinCount++;
#if NET5_0_OR_GREATER
        spinWait.SpinOnce(Sleep1Threshold);
#else
        if (spinWait.Count < FrameworkSleep1Threshold)
        {
            spinWait.SpinOnce();
            return;
        }

        // Budget is expressed against the total spin count so this matches the NET5_0_OR_GREATER path,
        // where SpinOnce(Sleep1Threshold) counts from zero rather than from the handover.
        if (spinCount >= Sleep1Threshold)
        {
            Thread.Sleep(1);
            spinWait.Reset();
            spinCount = 0;
        }
        else if ((spinCount % Sleep0EveryHowManyYields) == 0)
        {
            // Sleep(0) yields to any ready thread of equal priority, including on other cores;
            // Thread.Yield() only considers the current processor. Alternating covers both.
            Thread.Sleep(0);
        }
        else
        {
            Thread.Yield();
        }
#endif
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal void Exit()
        => _state = 0;
}
