// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Internal;

using CryptoHives.Foundation.Threading.Pools;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

using SpinLock = CryptoHives.Foundation.Threading.Internal.SpinLock;

/// <summary>
/// Measures the two quantities the <see cref="SpinLock"/> contention policy trades off against each
/// other: what one spin costs, and what the critical sections being spun on cost.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="SpinLockLatencyTests"/> shows that a waiter is not parked. This fixture answers the
/// question that justifies the tuning in the first place: <see cref="SpinLock.Sleep1Threshold"/> is a
/// count, and a count only means something once it is converted into wall-clock time. Timing a single
/// spin turns the budget into the window it actually buys, and timing the guarded bodies shows how much
/// of that window a real acquisition needs.
/// </para>
/// <para>
/// <b>What is timed.</b> <see cref="SpinLock.SpinOnce"/> is the lock's own backoff step, called by
/// <c>EnterCore</c> between two failed attempts to acquire. It is timed directly rather than
/// reconstructed, because the two supported target families take materially different code paths -
/// <c>SpinWait.SpinOnce(int)</c> where it exists, a hand-driven backoff where it does not - and a
/// reconstruction would silently measure only one of them.
/// </para>
/// <para>
/// <b>Shape of the curve.</b> The cost of a spin is not constant, which is the whole point of measuring
/// it rather than assuming it. The first iterations are a handful of <c>pause</c> instructions and cost
/// nanoseconds; the spin duration then doubles on each iteration until the framework's yield threshold,
/// after which every iteration is a <c>Thread.Yield</c> or <c>Thread.Sleep(0)</c> costing a scheduler
/// round-trip. So <see cref="ReportSpinCostAcrossTheBackoffCurve"/> reports the marginal cost at points
/// along the curve, not one average that would describe neither end of it.
/// </para>
/// <para>
/// <b>Caveat on the yield region.</b> These measurements are taken on a thread with no one to yield to.
/// A yield with a runnable peer on the same core costs whatever that peer does before it comes back,
/// so the tail of the curve is a floor, not a typical value. That is the correct floor for the question
/// being asked - it bounds how quickly the budget can be burned through - and the contended case is what
/// <see cref="SpinLockLatencyTests"/> measures instead.
/// </para>
/// <para>
/// The fixture is <see cref="NonParallelizableAttribute">non-parallelizable</see>: it measures
/// nanosecond-scale operations on a single thread, and a fixture running beside it would preempt the
/// measurement loop. A <see cref="MeasurementGate"/> extends that exclusion across the
/// per-target-framework test processes that <c>dotnet test</c> runs in parallel.
/// </para>
/// </remarks>
[TestFixture]
[NonParallelizable]
public class SpinLockSpinCostTests
{
    private MeasurementGate? _gate;

    [OneTimeSetUp]
    public void AcquireMeasurementGate()
        => _gate = MeasurementGate.Acquire();

    [OneTimeTearDown]
    public void ReleaseMeasurementGate()
        => _gate?.Dispose();

    /// <summary>
    /// Measurement batches per data point. The median is reported, so one preempted batch cannot move
    /// the result.
    /// </summary>
    private const int MeasurementRounds = 7;

    /// <summary>
    /// Ceiling on the auto-calibrated repetition count, so a data point cannot run away if the machine
    /// is slow enough that batches never reach the resolvable duration.
    /// </summary>
    private const int MaxRepetitions = 1 << 24;

    /// <summary>
    /// Timers created per measured batch. Fixed rather than auto-calibrated because every repetition
    /// allocates a live timer, and the point of the row is the order of magnitude, not a tight figure.
    /// </summary>
    private const int TimerCreationBatch = 1_000;

    /// <summary>
    /// Ceiling on the cost of a single spin. The first iterations of the backoff are a few <c>pause</c>
    /// instructions, so this has three orders of magnitude of headroom; it exists to catch a spin step
    /// that has started doing something it should not, such as sleeping.
    /// </summary>
    private const double MaxSingleSpinNanoseconds = 1_000.0;

    /// <summary>
    /// Ceiling on the guarded body of a critical section. The bodies this lock guards are a few field
    /// accesses and a linked-list splice, so this is a loose bound whose purpose is to fail if the claim
    /// on <see cref="SpinLock"/> - that its critical sections are nanosecond-scale - ever stops holding.
    /// </summary>
    private const double MaxCriticalSectionNanoseconds = 1_000.0;

    /// <summary>
    /// How much finer than one park the mean spin has to be, taken over the whole budget. The measured
    /// ratio is around a thousand; the assertion is set at ten so it states the design property - that
    /// the backoff escalates in steps far smaller than the cliff it replaces - without being a
    /// throughput test in disguise.
    /// </summary>
    private const double MinParkToSpinRatio = 10.0;

    /// <summary>
    /// Spin counts at which the backoff curve is sampled. The last entry is one short of
    /// <see cref="SpinLock.Sleep1Threshold"/>, which is the last iteration before a park is permitted, so
    /// the reported window is the whole spin budget and nothing else.
    /// </summary>
    private static readonly int[] SpinCheckpoints =
        [1, 2, 4, 8, 10, 16, 20, 32, 64, 128, SpinLock.Sleep1Threshold - 1];

    /// <summary>Spins available before the lock is first permitted to park.</summary>
    private const int BudgetSpins = SpinLock.Sleep1Threshold - 1;

    /// <summary>Consumes loop results so nothing being measured can be optimised away.</summary>
    private static volatile int _sink;

    /// <summary>
    /// Reports what one spin costs at each point along the backoff curve, and the wall-clock window the
    /// whole spin budget buys.
    /// </summary>
    /// <remarks>
    /// The table is the deliverable. A single number would misrepresent a curve whose ends differ by two
    /// orders of magnitude, and the cumulative column is what converts
    /// <see cref="SpinLock.Sleep1Threshold"/> from a count into a duration.
    /// </remarks>
    [Test, CancelAfter(120_000)]
    public void ReportSpinCostAcrossTheBackoffCurve()
    {
        double granularityMs = PlatformTimer.MeasureSleep1GranularityMilliseconds();
        PlatformTimer.ReportGranularity(granularityMs);
        PlatformTimer.ReportConfiguration();

        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"{"  Thread.SpinWait(1)",-34} {MeasurePauseNanoseconds(),14:N2} ns");

        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine(
            $"Cost of one SpinLock.SpinOnce, uncontended (median of {MeasurementRounds} batches):");
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"{"spins",8}{"cumulative us",18}{"marginal ns/spin",20}");

        double previousNanoseconds = 0.0;
        int previousSpins = 0;
        double budgetNanoseconds = 0.0;

        foreach (int spins in SpinCheckpoints)
        {
            double cumulativeNanoseconds = MeasureSpinBurstNanoseconds(spins);
            double marginalNanoseconds =
                (cumulativeNanoseconds - previousNanoseconds) / (spins - previousSpins);

            TestContext.Out.WriteLine(
                $"{spins,8}{cumulativeNanoseconds / 1_000.0,18:N3}{marginalNanoseconds,20:N1}");

            previousNanoseconds = cumulativeNanoseconds;
            previousSpins = spins;
            budgetNanoseconds = cumulativeNanoseconds;
        }

        double granularityNanoseconds = granularityMs * 1_000_000.0;

        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine("Spin budget:");
        TestContext.Out.WriteLine($"{"  budget",-34} {BudgetSpins,14:N0} spins before a park is permitted");
        TestContext.Out.WriteLine($"{"  window bought",-34} {budgetNanoseconds / 1_000.0,14:N2} us");
        TestContext.Out.WriteLine($"{"  cost of one park instead",-34} {granularityMs * 1_000.0,14:N2} us");
        TestContext.Out.WriteLine(
            $"{"  whole budget vs one park",-34} {granularityNanoseconds / budgetNanoseconds,14:N1} x cheaper");

        Assert.Pass();
    }

    /// <summary>
    /// Asserts that one spin costs what a handful of instructions costs.
    /// </summary>
    /// <remarks>
    /// This is the assertion the rest of the contention policy rests on. If a single step of the backoff
    /// were expensive, raising <see cref="SpinLock.Sleep1Threshold"/> from the framework's twenty to two
    /// hundred would not be avoiding a latency cliff, it would be building a longer one.
    /// </remarks>
    [Test, CancelAfter(60_000)]
    public void OneSpinCostsNanosecondsNotMicroseconds()
    {
        double singleSpinNanoseconds = MeasureSpinBurstNanoseconds(1);

        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"{"one spin",-34} {singleSpinNanoseconds,14:N2} ns");
        TestContext.Out.WriteLine($"{"  budget",-34} {MaxSingleSpinNanoseconds,14:N2} ns");
        PlatformTimer.ReportConfiguration();

        Assert.That(
            singleSpinNanoseconds,
            Is.LessThan(MaxSingleSpinNanoseconds),
            $"One spin measured {singleSpinNanoseconds:N1} ns. The first iterations of the backoff are a " +
            "few pause instructions; anything near a microsecond means the step is blocking.");
    }

    /// <summary>
    /// Asserts that the backoff escalates in steps far finer than the park it exists to replace.
    /// </summary>
    /// <remarks>
    /// Expressed as a ratio against the platform's measured <c>Thread.Sleep(1)</c> granularity rather
    /// than an absolute bound, so it means the same thing on Windows - where a park is roughly 15.6 ms -
    /// and on platforms where it is closer to a millisecond.
    /// </remarks>
    [Test, CancelAfter(120_000)]
    public void SpinGranularityIsFinerThanTheParkItReplaces()
    {
        double granularityMs = PlatformTimer.MeasureSleep1GranularityMilliseconds();
        double budgetNanoseconds = MeasureSpinBurstNanoseconds(BudgetSpins);
        double meanSpinNanoseconds = budgetNanoseconds / BudgetSpins;
        double parkNanoseconds = granularityMs * 1_000_000.0;
        double ratio = parkNanoseconds / meanSpinNanoseconds;

        PlatformTimer.ReportGranularity(granularityMs);
        PlatformTimer.ReportConfiguration();
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"{"mean spin over the budget",-34} {meanSpinNanoseconds,14:N1} ns");
        TestContext.Out.WriteLine($"{"one park",-34} {parkNanoseconds,14:N1} ns");
        TestContext.Out.WriteLine($"{"ratio",-34} {ratio,14:N1} x");
        TestContext.Out.WriteLine($"{"  budget",-34} {MinParkToSpinRatio,14:N1} x");

        Assert.That(
            ratio,
            Is.GreaterThan(MinParkToSpinRatio),
            $"A park costs {parkNanoseconds:N0} ns and the mean spin {meanSpinNanoseconds:N0} ns, a ratio " +
            $"of only {ratio:N1}. The backoff is supposed to escalate in steps far smaller than the cliff " +
            "it replaces.");
    }

    /// <summary>
    /// Reports how long the lock is actually held, and asserts that the bodies on the primitives' normal
    /// paths are the nanosecond-scale the contention policy on <see cref="SpinLock"/> claims.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A waiter waits for the guarded body, not for the whole <c>Enter</c>/<c>Exit</c> round trip, so the
    /// bodies are timed unguarded as well as guarded. Differencing the two alone would not work here: the
    /// bodies turn out to be smaller than the run-to-run spread on the lock itself, so the difference is
    /// noise while the direct measurement is not.
    /// </para>
    /// <para>
    /// <b>These are floors, not typical values.</b> A tight loop over one queue node keeps every line in
    /// L1 and every branch predicted, which a real acquisition does not. The figures bound how short the
    /// critical sections can be, and that is the direction the contention policy needs: they establish
    /// that the guarded work is orders of magnitude below one spin, so a waiter that spins is trading a
    /// nanosecond-scale wait against a nanosecond-scale spin.
    /// </para>
    /// <para>
    /// <b>The timeout path is the outlier, and is deliberately excluded from the assertions.</b> Every
    /// <c>*Async(TimeSpan, …)</c> overload in the library creates its timeout timer while holding this
    /// lock. That body allocates and takes the runtime's own timer-queue lock, and measures around two
    /// orders of magnitude above the others - still comfortably inside the spin budget on an idle
    /// machine, but it is the one guarded body whose cost is not bounded by this library, since it
    /// depends on a lock and a data structure shared with every other timer in the process. It is
    /// reported rather than asserted because it is a property of the callers, not of the lock; the row
    /// exists so the deviation is visible rather than assumed away.
    /// </para>
    /// </remarks>
    [Test, CancelAfter(120_000)]
    public void GuardedCriticalSectionIsNanosecondScale()
    {
        double lockOnlyNanoseconds = Measure(RunEmptyCriticalSection);
        double releaseBodyNanoseconds = Measure(RunReleaseBody);
        double handoffBodyNanoseconds = Measure(RunWaiterHandoffBody);
        double releaseNanoseconds = Measure(RunReleaseCriticalSection);
        double handoffNanoseconds = Measure(RunWaiterHandoffCriticalSection);
        double timerNanoseconds = MeasureTimerCreationNanoseconds();

        PlatformTimer.ReportConfiguration();
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"Time spent inside the lock (median of {MeasurementRounds} batches):");
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"{"workload",-38}{"body ns",12}{"with lock ns",14}");
        TestContext.Out.WriteLine($"{"Enter + Exit, nothing guarded",-38}{0.0,12:N1}{lockOnlyNanoseconds,14:N1}");
        TestContext.Out.WriteLine($"{"release with no waiters",-38}{releaseBodyNanoseconds,12:N1}{releaseNanoseconds,14:N1}");
        TestContext.Out.WriteLine($"{"waiter handoff (enqueue + dequeue)",-38}{handoffBodyNanoseconds,12:N1}{handoffNanoseconds,14:N1}");
        TestContext.Out.WriteLine($"{"timeout timer creation",-38}{timerNanoseconds,12:N1}{"not asserted",14}");
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"{"  budget for a body",-38}{MaxCriticalSectionNanoseconds,12:N1}");

        using (Assert.EnterMultipleScope())
        {
            Assert.That(
                releaseBodyNanoseconds,
                Is.LessThan(MaxCriticalSectionNanoseconds),
                "The uncontended release path should be a queue-length check and a store.");

            Assert.That(
                handoffBodyNanoseconds,
                Is.LessThan(MaxCriticalSectionNanoseconds),
                "A waiter handoff should be two splices of an intrusive linked list.");
        }
    }

    /// <summary>
    /// Times <paramref name="spins"/> consecutive spins from a fresh backoff state, as the median of
    /// several auto-calibrated batches.
    /// </summary>
    /// <remarks>
    /// The state is reset for every burst because the cost of a spin depends on how many have already
    /// happened; timing spins from a shared, ever-advancing state would measure only the yield region.
    /// </remarks>
    private static double MeasureSpinBurstNanoseconds(int spins)
    {
        int repetitions = CalibrateRepetitions(spins);
        double[] rounds = new double[MeasurementRounds];

        for (int i = 0; i < rounds.Length; i++)
        {
            rounds[i] = PlatformTimer.ToNanoseconds(RunSpinBurst(spins, repetitions)) / repetitions;
        }

        Array.Sort(rounds);
        return rounds[rounds.Length / 2];
    }

    /// <summary>
    /// Grows the batch size until one batch spans enough counter ticks to be resolvable, and returns it.
    /// </summary>
    /// <remarks>
    /// The high performance counter ticks at 100 ns on Windows, which is an order of magnitude coarser
    /// than the operation being timed, so a single spin cannot be measured directly - only a batch large
    /// enough to dwarf the counter's resolution. Running the calibration first also gets the loop jitted
    /// and the caches warm before the measured batches start.
    /// </remarks>
    private static int CalibrateRepetitions(int spins)
    {
        int repetitions = 1;
        while (repetitions < MaxRepetitions && RunSpinBurst(spins, repetitions) < MinBatchTicks)
        {
            repetitions *= 2;
        }

        return repetitions;
    }

    /// <summary>Same calibrate-then-median protocol, for the critical-section workloads.</summary>
    private static double Measure(Func<int, long> workload)
    {
        int repetitions = 1;
        while (repetitions < MaxRepetitions && workload(repetitions) < MinBatchTicks)
        {
            repetitions *= 2;
        }

        double[] rounds = new double[MeasurementRounds];
        for (int i = 0; i < rounds.Length; i++)
        {
            rounds[i] = PlatformTimer.ToNanoseconds(workload(repetitions)) / repetitions;
        }

        Array.Sort(rounds);
        return rounds[rounds.Length / 2];
    }

    /// <summary>Counter ticks a batch has to span - about a millisecond - to be worth timing.</summary>
    private static long MinBatchTicks => Math.Max(1L, Stopwatch.Frequency / 1_000L);

    /// <summary>Ticks taken by <paramref name="repetitions"/> bursts of <paramref name="spins"/> spins.</summary>
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long RunSpinBurst(int spins, int repetitions)
    {
        long start = Stopwatch.GetTimestamp();

        for (int r = 0; r < repetitions; r++)
        {
            var spinWait = new SpinWait();
            int spinCount = 0;

            for (int i = 0; i < spins; i++)
            {
                SpinLock.SpinOnce(ref spinWait, ref spinCount);
            }

            _sink = spinCount;
        }

        return Stopwatch.GetTimestamp() - start;
    }

    /// <summary>Ticks taken by <paramref name="repetitions"/> uncontended <c>Thread.SpinWait(1)</c> calls.</summary>
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long RunPause(int repetitions)
    {
        long start = Stopwatch.GetTimestamp();

        for (int i = 0; i < repetitions; i++)
        {
            Thread.SpinWait(1);
        }

        return Stopwatch.GetTimestamp() - start;
    }

    /// <summary>Cost of the primitive the whole backoff is built out of.</summary>
    private static double MeasurePauseNanoseconds()
        => Measure(RunPause);

    /// <summary>Lock overhead with nothing in the critical section: the floor the workloads sit on.</summary>
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long RunEmptyCriticalSection(int repetitions)
    {
        var spinLock = new SpinLock();
        long start = Stopwatch.GetTimestamp();

        for (int i = 0; i < repetitions; i++)
        {
            spinLock.Enter();
            spinLock.Exit();
        }

        return Stopwatch.GetTimestamp() - start;
    }

    /// <summary>
    /// The uncontended release path of the async primitives: check whether anyone is queued, and if not
    /// drop the held flag.
    /// </summary>
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long RunReleaseCriticalSection(int repetitions)
    {
        var spinLock = new SpinLock();
        var waiters = new WaiterQueue<bool>();
        int taken = 1;

        long start = Stopwatch.GetTimestamp();

        for (int i = 0; i < repetitions; i++)
        {
            spinLock.Enter();
            if (waiters.Count == 0)
            {
                taken = 0;
            }

            spinLock.Exit();
            _sink = taken;
        }

        return Stopwatch.GetTimestamp() - start;
    }

    /// <summary>The same release path with the lock taken out, to time the guarded body on its own.</summary>
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long RunReleaseBody(int repetitions)
    {
        var waiters = new WaiterQueue<bool>();
        int taken = 1;

        long start = Stopwatch.GetTimestamp();

        for (int i = 0; i < repetitions; i++)
        {
            if (waiters.Count == 0)
            {
                taken = 0;
            }

            _sink = taken;
        }

        return Stopwatch.GetTimestamp() - start;
    }

    /// <summary>
    /// The contended path: a waiter is spliced into the intrusive queue and the next one is spliced back
    /// out. This is the longest body any of the primitives runs under the lock on its normal path.
    /// </summary>
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long RunWaiterHandoffCriticalSection(int repetitions)
    {
        var spinLock = new SpinLock();
        var waiters = new WaiterQueue<bool>();
        var waiter = new LocalManualResetValueTaskSource<bool>(new object());

        long start = Stopwatch.GetTimestamp();

        for (int i = 0; i < repetitions; i++)
        {
            spinLock.Enter();
            waiters.Enqueue(waiter);
            _sink = waiters.Count;
            _ = waiters.Dequeue();
            spinLock.Exit();
        }

        return Stopwatch.GetTimestamp() - start;
    }

    /// <summary>The same handoff with the lock taken out, to time the guarded body on its own.</summary>
    [MethodImpl(MethodImplOptions.NoInlining)]
    private static long RunWaiterHandoffBody(int repetitions)
    {
        var waiters = new WaiterQueue<bool>();
        var waiter = new LocalManualResetValueTaskSource<bool>(new object());

        long start = Stopwatch.GetTimestamp();

        for (int i = 0; i < repetitions; i++)
        {
            waiters.Enqueue(waiter);
            _sink = waiters.Count;
            _ = waiters.Dequeue();
        }

        return Stopwatch.GetTimestamp() - start;
    }

    /// <summary>
    /// Times <c>TimeProvider.System.CreateTimer</c>, which every <c>*Async(TimeSpan, …)</c> overload in
    /// the library calls while holding the spin lock.
    /// </summary>
    /// <remarks>
    /// Deliberately not auto-calibrated: each repetition allocates a live timer, so the batch is fixed
    /// and small. The timers are disposed outside the timed region, because the critical section only
    /// creates them - charging disposal to it would overstate the cost being reported.
    /// </remarks>
    private static double MeasureTimerCreationNanoseconds()
    {
        var timers = new ITimer[TimerCreationBatch];
        var callback = new TimerCallback(static _ => { });
        double[] rounds = new double[MeasurementRounds];

        // A finite due time, as the library passes. An infinite one is never inserted into the runtime's
        // timer queue at all, so it would measure an allocation and miss the queue lock entirely. The
        // value is far enough out that nothing fires while the measurement runs.
        TimeSpan dueTime = TimeSpan.FromMinutes(10);

        // One unmeasured round to jit the path and warm the runtime's timer queue.
        for (int round = -1; round < rounds.Length; round++)
        {
            long start = Stopwatch.GetTimestamp();

            for (int i = 0; i < timers.Length; i++)
            {
                timers[i] = TimeProvider.System.CreateTimer(
                    callback, null, dueTime, Timeout.InfiniteTimeSpan);
            }

            long ticks = Stopwatch.GetTimestamp() - start;

            for (int i = 0; i < timers.Length; i++)
            {
                timers[i].Dispose();
            }

            if (round >= 0)
            {
                rounds[round] = PlatformTimer.ToNanoseconds(ticks) / timers.Length;
            }
        }

        Array.Sort(rounds);
        return rounds[rounds.Length / 2];
    }
}
