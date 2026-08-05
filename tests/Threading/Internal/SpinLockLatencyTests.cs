// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Internal;

using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;

using SpinLock = CryptoHives.Foundation.Threading.Internal.SpinLock;

/// <summary>
/// Latency tests proving the contention policy documented on <see cref="SpinLock"/>: a waiter blocked on
/// the lock is never parked on the scheduler-quantum timer.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="SpinWait.SpinOnce()"/>'s default backoff escalates to <c>Thread.Sleep(1)</c> after about
/// twenty spins, and sleeps again on every call after that. On Windows <c>Thread.Sleep(1)</c> does not
/// sleep one millisecond - it rounds up to the system scheduler quantum, roughly 15.6 ms. For a lock whose
/// critical sections are measured in nanoseconds that turns contention into a latency cliff: a waiter
/// stops paying for the critical section it is waiting on and starts paying a whole quantum instead.
/// </para>
/// <para>
/// <b>Method.</b> These tests do not free-run threads against the lock and measure what happens. A
/// free-running loop measures the wrong thing: the thread that releases the lock still owns its cache line
/// exclusively and never backs off, so it re-acquires immediately and convoys thousands of uncontended
/// acquisitions while its peers sit deep in backoff. The resulting distribution is bimodal, dominated by
/// re-acquisitions by the same thread, and is identical for both backoffs - it says nothing about either.
/// </para>
/// <para>
/// Instead each round is a controlled handoff. One holder thread takes the lock, releases a set of waiter
/// threads that are already spinning hot on a gate, holds the lock for a known duration, and then releases
/// it. Every waiter is therefore guaranteed to block, and its acquisition latency has a known expected
/// value: the holder's critical section, plus a handoff. Latencies are taken with
/// <see cref="Stopwatch.GetTimestamp"/> - the high performance counter, <c>QueryPerformanceCounter</c> on
/// Windows - and the assertion is that they track the critical section rather than snapping to the
/// quantum grid.
/// </para>
/// <para>
/// The quantum is not hard-coded to 15.6 ms: the platform's real <c>Thread.Sleep(1)</c> granularity is
/// measured first, so the same assertions are meaningful on Linux and macOS, where it is closer to a
/// millisecond.
/// </para>
/// <para>
/// <b>Envelope.</b> The spin budget is finite by design - see the safety-valve paragraph on
/// <see cref="SpinLock"/> - so the claim is scoped to critical sections of the length the library actually
/// produces. <see cref="ReportHandoffLatencyAcrossCriticalSectionLengths"/> maps the whole curve for both
/// backoffs, including the point where each one runs out of budget and starts parking. That the tuned lock
/// eventually parks too, at a critical section thousands of times longer than any it guards, is the
/// designed behaviour and is reported rather than asserted.
/// </para>
/// <para>
/// The fixture is <see cref="NonParallelizableAttribute">non-parallelizable</see> because it measures
/// wall-clock latency and needs a free core per thread; running it alongside other fixtures would
/// oversubscribe the machine and inject preemption stalls that have nothing to do with the lock. That
/// attribute only orders fixtures within one assembly, so a <see cref="MeasurementGate"/> extends the
/// same exclusion across the per-target-framework test processes that <c>dotnet test</c> runs in
/// parallel - without it, three copies of this fixture spin a thread per core simultaneously and it
/// fails on the preemption that causes.
/// </para>
/// </remarks>
[TestFixture]
[NonParallelizable]
public class SpinLockLatencyTests
{
    private MeasurementGate? _gate;

    [OneTimeSetUp]
    public void AcquireMeasurementGate()
        => _gate = MeasurementGate.Acquire();

    [OneTimeTearDown]
    public void ReleaseMeasurementGate()
        => _gate?.Dispose();

    /// <summary>
    /// Fraction of the measured <c>Thread.Sleep(1)</c> granularity at which a wait is treated as having
    /// been parked rather than spun. Half a quantum is not reachable by spinning and yielding, so anything
    /// at or above it - over and above the critical section actually being waited on - is evidence of a
    /// sleep.
    /// </summary>
    private const double QuantumBandFraction = 0.5;

    /// <summary>
    /// Floor for the quantum band, in milliseconds. Where the platform's own <c>Sleep(1)</c> granularity
    /// is already close to one millisecond, half of it is too tight to distinguish from an ordinary
    /// scheduling hiccup; this keeps the band honest without weakening it on Windows.
    /// </summary>
    private const double MinQuantumBandMilliseconds = 2.0;

    /// <summary>
    /// Fraction of handoffs permitted to land in the quantum band regardless. A waiter can be descheduled
    /// by the operating system through no fault of the lock, so a hard zero would be a flake.
    /// </summary>
    private const double QuantumBandOutlierTolerance = 0.002;

    /// <summary>Absolute floor for the outlier allowance, so short runs are not hair-triggered.</summary>
    private const int MinQuantumBandOutlierAllowance = 3;

    /// <summary>Handoff rounds per probe. Each round produces one sample per waiter.</summary>
    private const int Rounds = 400;

    /// <summary>
    /// Handoff rounds per probe for the diagnostic sweep. Lower than <see cref="Rounds"/> because the
    /// sweep deliberately includes configurations that park: at a quantum per round those would otherwise
    /// dominate the runtime of the whole fixture.
    /// </summary>
    private const int ReportRounds = 60;

    /// <summary>Rounds run before measurement starts, to get the loop jitted and the threads settled.</summary>
    private const int WarmupRounds = 50;

    /// <summary>
    /// Ceiling on the waiter count. The holder needs a core of its own, and every waiter needs one to spin
    /// on; oversubscribing would measure the scheduler rather than the lock.
    /// </summary>
    private const int MaxWaiters = 8;

    /// <summary>
    /// Critical-section lengths, in microseconds, at which the lock is asserted to hold the line. The
    /// library's own critical sections are a handful of instructions - tens of nanoseconds - so even the
    /// longest of these is orders of magnitude beyond what it has to absorb in practice, and all three sit
    /// well inside the spin budget mapped by
    /// <see cref="ReportHandoffLatencyAcrossCriticalSectionLengths"/>.
    /// </summary>
    private static readonly double[] AssertedHoldMicroseconds = [0.0, 1.0, 10.0];

    /// <summary>
    /// Critical-section lengths, in microseconds, mapped by
    /// <see cref="ReportHandoffLatencyAcrossCriticalSectionLengths"/>. The tail entries sit outside the
    /// envelope on purpose, to show where each backoff runs out of spin budget.
    /// </summary>
    private static readonly double[] ReportedHoldMicroseconds = [0.0, 1.0, 10.0, 50.0, 200.0, 1_000.0];

    /// <summary>
    /// Critical-section length used for the head-to-head against the framework's default backoff. It has
    /// to be long enough to exhaust the default twenty-spin budget - with a negligible critical section the
    /// default never escalates and there is no cliff to demonstrate - while staying inside this lock's own
    /// budget. Ten microseconds is the first measured point where the two separate cleanly;
    /// <see cref="ReportHandoffLatencyAcrossCriticalSectionLengths"/> shows the margin either side.
    /// </summary>
    private const double CliffComparisonHoldMicroseconds = 10.0;

    /// <summary>
    /// Multiple of the critical section that a handoff is allowed to cost before it is treated as no
    /// longer tracking the critical section at all. Only applied on top of an absolute floor, since a
    /// negligible critical section has no meaningful multiple.
    /// </summary>
    private const double HandoffOverheadFactor = 4.0;

    /// <summary>
    /// Absolute headroom, in milliseconds, allowed on top of the critical section before a handoff counts
    /// as parked. Comfortably above any spin-and-yield handoff and comfortably below half a quantum.
    /// </summary>
    private const double HandoffHeadroomMilliseconds = 1.0;

    private static int WaiterCount => Math.Max(2, Math.Min(Environment.ProcessorCount - 1, MaxWaiters));

    /// <summary>
    /// Asserts that a blocked waiter pays for the critical section it is waiting on, and never for the
    /// timer quantum.
    /// </summary>
    /// <param name="holdMicroseconds">How long the holder keeps the lock, in microseconds.</param>
    [Test, CancelAfter(120_000)]
    [TestCaseSource(nameof(AssertedHoldMicroseconds))]
    public void WaiterLatencyTracksTheCriticalSectionNotTheTimerQuantum(double holdMicroseconds)
    {
        RequireEnoughProcessors();

        double granularityMs = MeasureSleep1GranularityMilliseconds();
        double bandMs = QuantumBandLowerBound(granularityMs);

        var box = new TunedSpinLockBox();
        HandoffStats stats = RunHandoffProbe("SpinLock", holdMicroseconds, box.Enter, box.Exit, bandMs);

        ReportGranularity(granularityMs, bandMs);
        Report(stats, bandMs);

        double expectedCeilingMs = ExpectedHandoffCeilingMilliseconds(holdMicroseconds);
        int allowance = OutlierAllowance(stats.SampleCount);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(
                stats.ParkedCount,
                Is.LessThanOrEqualTo(allowance),
                $"{stats.ParkedCount:N0} of {stats.SampleCount:N0} handoffs of a " +
                $"{holdMicroseconds:N1} us critical section cost at least {bandMs:F2} ms on top of it, which is " +
                $"only reachable by parking on the {granularityMs:F2} ms timer.");

            Assert.That(
                stats.P99Milliseconds,
                Is.LessThan(expectedCeilingMs),
                $"99% of handoffs should cost about the {holdMicroseconds:N1} us critical section being waited " +
                $"on, not {stats.P99Milliseconds * 1000.0:N1} us.");
        }
    }

    /// <summary>
    /// Runs the tuned lock and a control lock using the framework's default <see cref="SpinWait"/> backoff
    /// through the same handoff probe, and asserts that the tuned lock avoids a cliff the control hits.
    /// </summary>
    /// <remarks>
    /// The comparative assertions are conditional on the control actually demonstrating the cliff on this
    /// machine, which makes the test self-calibrating rather than platform-specific: where
    /// <c>Thread.Sleep(1)</c> really costs a quantum the control collapses and the tuned lock must beat it
    /// by a wide margin; where it does not, there is no cliff to avoid and only the unconditional bound
    /// applies.
    /// </remarks>
    [Test, CancelAfter(120_000)]
    public void DefaultSpinWaitBackoffParksWhereSpinLockDoesNot()
    {
        RequireEnoughProcessors();

        double granularityMs = MeasureSleep1GranularityMilliseconds();
        double bandMs = QuantumBandLowerBound(granularityMs);

        var control = new DefaultSpinWaitLockBox();
        HandoffStats controlStats = RunHandoffProbe(
            "SpinWait default", CliffComparisonHoldMicroseconds, control.Enter, control.Exit, bandMs);

        var tuned = new TunedSpinLockBox();
        HandoffStats tunedStats = RunHandoffProbe(
            "SpinLock", CliffComparisonHoldMicroseconds, tuned.Enter, tuned.Exit, bandMs);

        ReportGranularity(granularityMs, bandMs);
        Report(controlStats, bandMs);
        Report(tunedStats, bandMs);

        Assert.That(
            tunedStats.ParkedCount,
            Is.LessThanOrEqualTo(OutlierAllowance(tunedStats.SampleCount)),
            $"{tunedStats.ParkedCount:N0} of {tunedStats.SampleCount:N0} handoffs reached the {bandMs:F2} ms band.");

        if (controlStats.ParkedRatio <= QuantumBandOutlierTolerance)
        {
            TestContext.Out.WriteLine();
            TestContext.Out.WriteLine(
                "  Note: the default SpinWait backoff did not exhibit the quantum cliff on this platform " +
                $"({controlStats.ParkedRatio:P2} of handoffs parked, Sleep(1) granularity {granularityMs:F2} ms), " +
                "so only the unconditional bound was asserted.");
            return;
        }

        using (Assert.EnterMultipleScope())
        {
            Assert.That(
                tunedStats.ParkedRatio,
                Is.LessThan(controlStats.ParkedRatio),
                $"The default backoff parked on {controlStats.ParkedRatio:P2} of handoffs of the same " +
                $"{CliffComparisonHoldMicroseconds:N0} us critical section, SpinLock on {tunedStats.ParkedRatio:P2}.");

            Assert.That(
                tunedStats.P99Milliseconds,
                Is.LessThan(controlStats.P99Milliseconds),
                "The tuned backoff should have a lower tail than one that parks on the timer.");
        }
    }

    /// <summary>
    /// Maps handoff latency against critical-section length for both backoffs, documenting where each one
    /// runs out of spin budget and starts parking.
    /// </summary>
    /// <remarks>
    /// Diagnostic rather than behavioural: the longest entries deliberately sit outside the envelope the
    /// lock is tuned for. The table is the point - it is what makes the spin budget an observed quantity
    /// rather than an assumed one.
    /// </remarks>
    [Test, CancelAfter(300_000)]
    public void ReportHandoffLatencyAcrossCriticalSectionLengths()
    {
        RequireEnoughProcessors();

        double granularityMs = MeasureSleep1GranularityMilliseconds();
        double bandMs = QuantumBandLowerBound(granularityMs);

        ReportGranularity(granularityMs, bandMs);
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"Handoff latency vs critical-section length ({WaiterCount} waiters, {ReportRounds} rounds):");
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine(
            $"{"backoff",-18}{"held us",10} {"p50 us",12} {"p99 us",12} {"max us",12} {"parked",10}");

        foreach (double holdMicroseconds in ReportedHoldMicroseconds)
        {
            var control = new DefaultSpinWaitLockBox();
            ReportRow(RunHandoffProbe("SpinWait default", holdMicroseconds, control.Enter, control.Exit, bandMs, ReportRounds));

            var tuned = new TunedSpinLockBox();
            ReportRow(RunHandoffProbe("SpinLock", holdMicroseconds, tuned.Enter, tuned.Exit, bandMs, ReportRounds));
        }

        Assert.Pass();
    }

    /// <summary>
    /// Reports the platform's real <c>Thread.Sleep(1)</c> granularity, which is the cost the lock's
    /// contention policy exists to avoid.
    /// </summary>
    /// <remarks>
    /// This is a diagnostic, not a behavioural assertion: it only fails if the high performance counter
    /// itself is unusable, in which case every other measurement in the fixture would be meaningless.
    /// </remarks>
    [Test, CancelAfter(30_000)]
    public void ReportPlatformTimerGranularity()
    {
        double granularityMs = MeasureSleep1GranularityMilliseconds();
        double bandMs = QuantumBandLowerBound(granularityMs);

        ReportGranularity(granularityMs, bandMs);

        Assert.That(
            granularityMs,
            Is.GreaterThan(0.0),
            "Thread.Sleep(1) measured as instantaneous - the high performance counter is not usable.");
    }

    /// <summary>
    /// Runs <see cref="Rounds"/> controlled handoffs and records how long each waiter was blocked.
    /// </summary>
    /// <remarks>
    /// Every round the holder takes the lock <em>before</em> opening the gate, so each waiter is guaranteed
    /// to find it held and to block. The gate is a plain counter the waiters spin on rather than an event,
    /// so no waiter is ever asleep in the kernel when its round starts - a wake-up would cost more than the
    /// handoff being measured.
    /// </remarks>
    /// <param name="name">Display name of the lock under test.</param>
    /// <param name="holdMicroseconds">How long the holder keeps the lock.</param>
    /// <param name="enter">Acquires the lock.</param>
    /// <param name="exit">Releases the lock.</param>
    /// <param name="quantumBandMilliseconds">Excess latency at or above which a handoff counts as parked.</param>
    /// <param name="rounds">Measured handoff rounds.</param>
    private static HandoffStats RunHandoffProbe(
        string name,
        double holdMicroseconds,
        Action enter,
        Action exit,
        double quantumBandMilliseconds,
        int rounds = Rounds)
    {
        int waiterCount = WaiterCount;
        int totalRounds = WarmupRounds + rounds;
        long holdTicks = (long)(holdMicroseconds * Stopwatch.Frequency / 1_000_000.0);

        var state = new HandoffState();
        long[][] samples = new long[waiterCount][];
        var waiters = new Thread[waiterCount];

        for (int w = 0; w < waiterCount; w++)
        {
            samples[w] = new long[rounds];
        }

        for (int w = 0; w < waiterCount; w++)
        {
            int index = w;
            waiters[w] = new Thread(() => {
                long[] local = samples[index];

                for (int round = 1; round <= totalRounds; round++)
                {
                    // Spin hot on the gate: an event wait would put this thread in the kernel and the
                    // wake-up would dwarf the handoff being measured.
                    while (Volatile.Read(ref state.Round) < round)
                    {
                        Thread.SpinWait(1);
                    }

                    long before = Stopwatch.GetTimestamp();
                    enter();
                    long acquired = Stopwatch.GetTimestamp();
                    exit();

                    if (round > WarmupRounds)
                    {
                        local[round - WarmupRounds - 1] = acquired - before;
                    }

                    Interlocked.Increment(ref state.Completed);
                }
            }) {
                IsBackground = true,
                Name = $"{name} waiter {index}"
            };
            waiters[w].Start();
        }

        for (int round = 1; round <= totalRounds; round++)
        {
            Volatile.Write(ref state.Completed, 0);

            // Take the lock before opening the gate, so every waiter is guaranteed to block on it.
            enter();
            Volatile.Write(ref state.Round, round);

            if (holdTicks > 0)
            {
                BusyWait(holdTicks);
            }

            exit();

            // Drain the round. Spinning rather than waiting keeps the waiters hot for the next one.
            while (Volatile.Read(ref state.Completed) < waiterCount)
            {
                Thread.SpinWait(1);
            }
        }

        for (int w = 0; w < waiterCount; w++)
        {
            waiters[w].Join();
        }

        return HandoffStats.Create(name, waiterCount, holdMicroseconds, samples, rounds, quantumBandMilliseconds);
    }

    /// <summary>Busy-waits for the given number of high performance counter ticks without ever sleeping.</summary>
    private static void BusyWait(long ticks)
    {
        long deadline = Stopwatch.GetTimestamp() + ticks;
        while (Stopwatch.GetTimestamp() < deadline)
        {
            Thread.SpinWait(1);
        }
    }

    private static double MeasureSleep1GranularityMilliseconds()
        => PlatformTimer.MeasureSleep1GranularityMilliseconds();

    /// <summary>
    /// Excess latency, over and above the critical section being waited on, at or above which a handoff can
    /// only be explained by having been parked on the timer.
    /// </summary>
    private static double QuantumBandLowerBound(double granularityMilliseconds)
        => Math.Max(MinQuantumBandMilliseconds, granularityMilliseconds * QuantumBandFraction);

    /// <summary>
    /// Latency a healthy handoff of the given critical section should stay under: the critical section
    /// itself, plus whichever of a fixed headroom or a multiple of it is larger.
    /// </summary>
    private static double ExpectedHandoffCeilingMilliseconds(double holdMicroseconds)
    {
        double holdMs = holdMicroseconds / 1000.0;
        return holdMs + Math.Max(HandoffHeadroomMilliseconds, holdMs * HandoffOverheadFactor);
    }

    private static int OutlierAllowance(int sampleCount)
        => Math.Max(MinQuantumBandOutlierAllowance, (int)(sampleCount * QuantumBandOutlierTolerance));

    private static void RequireEnoughProcessors()
    {
        if (Environment.ProcessorCount < 3)
        {
            Assert.Ignore(
                "A controlled handoff needs a core for the holder and one per waiter. With fewer, a waiter " +
                "cannot spin without starving the holder, and backing off is the correct behaviour.");
        }
    }

    private static double ToMilliseconds(double ticks)
        => PlatformTimer.ToMilliseconds(ticks);

    private static void ReportGranularity(double granularityMs, double bandMs)
    {
        PlatformTimer.ReportGranularity(granularityMs);
        TestContext.Out.WriteLine($"{"  parked-handoff band",-34} {bandMs,14:F3} ms over the critical section");
        PlatformTimer.ReportConfiguration();
    }

    private static void Report(HandoffStats stats, double bandMs)
    {
        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine(
            $"{stats.Name}: {stats.WaiterCount} waiters blocked on a {stats.HoldMicroseconds:N1} us " +
            $"critical section, {stats.SampleCount:N0} handoffs");
        TestContext.Out.WriteLine($"{"  mean",-34} {stats.MeanMilliseconds * 1000.0,14:N2} us");
        TestContext.Out.WriteLine($"{"  p50",-34} {stats.P50Milliseconds * 1000.0,14:N2} us");
        TestContext.Out.WriteLine($"{"  p90",-34} {stats.P90Milliseconds * 1000.0,14:N2} us");
        TestContext.Out.WriteLine($"{"  p99",-34} {stats.P99Milliseconds * 1000.0,14:N2} us");
        TestContext.Out.WriteLine($"{"  max",-34} {stats.MaxMilliseconds * 1000.0,14:N2} us");
        TestContext.Out.WriteLine($"{"  parked (>= hold + band)",-34} {stats.ParkedCount,14:N0} ({stats.ParkedRatio:P2})");
        TestContext.Out.WriteLine($"{"  band",-34} {bandMs * 1000.0,14:N0} us");
    }

    private static void ReportRow(HandoffStats stats)
        => TestContext.Out.WriteLine(
            $"{stats.Name,-18}{stats.HoldMicroseconds,10:N0} {stats.P50Milliseconds * 1000.0,12:N2} " +
            $"{stats.P99Milliseconds * 1000.0,12:N2} {stats.MaxMilliseconds * 1000.0,12:N1} " +
            $"{stats.ParkedRatio,10:P2}");

    /// <summary>Shared, mutable state driving the handoff rounds. A class so every thread sees one copy.</summary>
    private sealed class HandoffState
    {
        /// <summary>Round the holder has opened. Waiters spin until this reaches their round number.</summary>
        public int Round;

        /// <summary>Waiters that have completed the current round.</summary>
        public int Completed;
    }

    /// <summary>
    /// Aggregated result of one handoff probe.
    /// </summary>
    /// <remarks>
    /// A class rather than a <see langword="readonly"/> <see langword="struct"/> only because <c>init</c>
    /// accessors need an <c>IsExternalInit</c> polyfill on the .NET Framework target, and one probe result
    /// per configuration is not worth carrying one for.
    /// </remarks>
    private sealed class HandoffStats
    {
        public string Name { get; set; } = string.Empty;
        public int WaiterCount { get; set; }
        public double HoldMicroseconds { get; set; }
        public int SampleCount { get; set; }
        public double MeanMilliseconds { get; set; }
        public double P50Milliseconds { get; set; }
        public double P90Milliseconds { get; set; }
        public double P99Milliseconds { get; set; }
        public double MaxMilliseconds { get; set; }
        public int ParkedCount { get; set; }
        public double ParkedRatio { get; set; }

        public static HandoffStats Create(
            string name,
            int waiterCount,
            double holdMicroseconds,
            long[][] samples,
            int rounds,
            double quantumBandMilliseconds)
        {
            int total = waiterCount * rounds;
            long[] all = new long[total];
            double sum = 0.0;

            for (int w = 0; w < waiterCount; w++)
            {
                Array.Copy(samples[w], 0, all, w * rounds, rounds);
                for (int i = 0; i < rounds; i++)
                {
                    sum += samples[w][i];
                }
            }

            Array.Sort(all);

            // A handoff counts as parked only if it cost the critical section plus a further half quantum:
            // the wait for the critical section itself is what the waiter is there for.
            double parkedThresholdMs = (holdMicroseconds / 1000.0) + quantumBandMilliseconds;
            long parkedTicks = (long)(parkedThresholdMs * Stopwatch.Frequency / 1000.0);
            int parked = total - LowerBound(all, parkedTicks);

            return new HandoffStats {
                Name = name,
                WaiterCount = waiterCount,
                HoldMicroseconds = holdMicroseconds,
                SampleCount = total,
                MeanMilliseconds = ToMilliseconds(sum / total),
                P50Milliseconds = Percentile(all, 0.50),
                P90Milliseconds = Percentile(all, 0.90),
                P99Milliseconds = Percentile(all, 0.99),
                MaxMilliseconds = ToMilliseconds(all[total - 1]),
                ParkedCount = parked,
                ParkedRatio = (double)parked / total,
            };
        }

        private static double Percentile(long[] sorted, double percentile)
            => ToMilliseconds(sorted[(int)(percentile * (sorted.Length - 1))]);

        /// <summary>Index of the first element of <paramref name="sorted"/> that is at least <paramref name="value"/>.</summary>
        private static int LowerBound(long[] sorted, long value)
        {
            int lo = 0;
            int hi = sorted.Length;
            while (lo < hi)
            {
                int mid = lo + ((hi - lo) / 2);
                if (sorted[mid] < value)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid;
                }
            }

            return lo;
        }
    }

    /// <summary>
    /// Holds the lock under test in a field so the probe can drive it through delegates. The lock is a
    /// mutable struct; a class field gives every thread a reference to the same instance.
    /// </summary>
    private sealed class TunedSpinLockBox
    {
        private SpinLock _spinLock = new();

        public void Enter() => _spinLock.Enter();

        public void Exit() => _spinLock.Exit();
    }

    /// <summary>
    /// Control lock: the same test-and-set loop driven by <see cref="SpinWait.SpinOnce()"/>'s default
    /// backoff, which is exactly what <see cref="SpinLock"/> looked like before the contention policy was
    /// introduced. It exists to demonstrate, on the machine running the test, that the quantum cliff is
    /// real rather than assumed.
    /// </summary>
    private sealed class DefaultSpinWaitLockBox
    {
        private volatile int _state;

        public void Enter()
        {
            if (Interlocked.Exchange(ref _state, 1) == 0)
            {
                return;
            }

            var spinWait = new SpinWait();
            do
            {
                spinWait.SpinOnce();
            } while (Interlocked.Exchange(ref _state, 1) != 0);
        }

        public void Exit() => _state = 0;
    }
}
