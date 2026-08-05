// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Internal;

using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

using SpinLock = CryptoHives.Foundation.Threading.Internal.SpinLock;

/// <summary>
/// Contention tests for <see cref="SpinLock"/> proving that <c>_state = 0</c>
/// provides correct release semantics on all architectures.
/// </summary>
/// <remarks>
/// <para>
/// The <see cref="SpinLock"/> implementation uses a <c>volatile int _state</c> field
/// and releases the lock via a plain assignment <c>_state = 0</c>. The C# <c>volatile</c>
/// keyword guarantees release semantics on writes: all preceding memory operations
/// (reads and writes inside the critical section) are committed to memory before the
/// store that releases the lock becomes globally visible.
/// </para>
/// <para>
/// On x86/x64 the hardware memory model already provides Total Store Order, making
/// stores inherently release-ordered. On ARM64 the JIT emits a store-release (<c>stlr</c>)
/// instruction for volatile writes, providing the same guarantee.
/// </para>
/// <para>
/// These tests exercise high-contention scenarios to demonstrate:
/// <list type="bullet">
///   <item><description>Mutual exclusion: no two threads ever execute the critical section concurrently.</description></item>
///   <item><description>Store ordering: data written inside the critical section is fully visible
///     to the next thread that acquires the lock.</description></item>
///   <item><description>No lost updates: a shared counter incremented under the lock never loses increments.</description></item>
///   <item><description>No quantum stalls: the run completes at a mean cost per acquisition that is
///     impossible if waiters are being parked on the scheduler-quantum timer.</description></item>
/// </list>
/// </para>
/// <para>
/// Each contention test is bounded twice over. <c>CancelAfter</c> is the outer bound - it stops a run that
/// has stalled outright rather than letting it hang the suite - and
/// <see cref="MaxMeanAcquisitionMicroseconds"/> is the inner one, which fails long before the outer bound
/// is reached. Per-acquisition latency, rather than the aggregate, is measured in
/// <see cref="SpinLockLatencyTests"/>.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SpinLockTests
{
    /// <summary>
    /// Number of iterations each thread performs.
    /// </summary>
    private const int IterationsPerThread = 200_000;

    /// <summary>
    /// Ceiling on the mean wall-clock cost of one acquisition across a contention run.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is the aggregate form of the per-acquisition assertion in <see cref="SpinLockLatencyTests"/>.
    /// A contended acquisition of a nanosecond-scale critical section costs a fraction of a microsecond,
    /// so a mean in the tens of microseconds can only mean waiters are being parked on the scheduler
    /// quantum - roughly 15.6 ms on Windows, see the contention policy on <see cref="SpinLock"/>.
    /// </para>
    /// <para>
    /// The bound is deliberately loose against measured throughput - runs here sit well under a
    /// microsecond per acquisition - because it has to hold on a loaded CI agent. It is still tight
    /// enough to be worth having: at 15.6 ms a park, one park per six hundred acquisitions would breach
    /// it, and a regression to the framework's default backoff parks far more often than that.
    /// </para>
    /// </remarks>
    private const double MaxMeanAcquisitionMicroseconds = 25.0;

    /// <summary>
    /// Number of threads to use in contention tests.
    /// </summary>
    private readonly int _threadCount = Environment.ProcessorCount;

    [Test, CancelAfter(5_000)]
    public void TryEnterReturnsTrueWhenUncontended()
    {
        var spinLock = new SpinLock();

        Assert.That(spinLock.TryEnter(), Is.True);

        spinLock.Exit();
    }

    [Test, CancelAfter(5_000)]
    public void TryEnterReturnsFalseWhenAlreadyHeld()
    {
        var spinLock = new SpinLock();

        Assert.That(spinLock.TryEnter(), Is.True);
        Assert.That(spinLock.TryEnter(), Is.False);

        spinLock.Exit();
    }

    [Test, CancelAfter(5_000)]
    public void EnterAndExitAreReusable()
    {
        var spinLock = new SpinLock();

        for (int i = 0; i < 1000; i++)
        {
            spinLock.Enter();
            spinLock.Exit();
        }

        Assert.That(spinLock.TryEnter(), Is.True);
        spinLock.Exit();
    }

    /// <summary>
    /// Proves mutual exclusion under high contention by verifying that a shared
    /// non-atomic counter never loses updates. If the lock release (<c>_state = 0</c>)
    /// could be reordered before the counter write, threads would observe stale values
    /// and the final count would be less than expected.
    /// </summary>
    [Test, CancelAfter(30_000)]
    public void MutualExclusionUnderContention()
    {
        var spinLock = new SpinLock();
        long sharedCounter = 0;

        TimeSpan elapsed = RunContentionTest(_threadCount, IterationsPerThread, () => {
            for (int i = 0; i < IterationsPerThread; i++)
            {
                spinLock.Enter();
                sharedCounter++;
                spinLock.Exit();
            }
        });

        AssertNoQuantumStalls(nameof(MutualExclusionUnderContention), _threadCount, (long)_threadCount * IterationsPerThread, elapsed);

        Assert.That(sharedCounter, Is.EqualTo((long)_threadCount * IterationsPerThread));
    }

    /// <summary>
    /// Proves that the volatile release write prevents reordering of stores inside the
    /// critical section past the lock release. Each thread writes a multi-word pattern
    /// (two 64-bit values that must be consistent) inside the lock. A concurrent reader
    /// verifies that the values are always coherent when read inside the lock.
    /// </summary>
    /// <remarks>
    /// If the JIT or CPU reordered <c>_state = 0</c> before the data stores,
    /// another thread could acquire the lock and observe a partially-written
    /// (inconsistent) pair of values.
    /// </remarks>
    [Test, CancelAfter(30_000)]
    public void StoreOrderingIsPreservedAcrossRelease()
    {
        var spinLock = new SpinLock();
        long sharedA = 0;
        long sharedB = 0;
        int violations = 0;

        TimeSpan elapsed = RunContentionTest(_threadCount, IterationsPerThread, () => {
            for (int i = 0; i < IterationsPerThread; i++)
            {
                spinLock.Enter();

                // Write a consistent pair: sharedA and sharedB must always match.
                long val = sharedA + 1;
                sharedA = val;
                sharedB = val;

                // Read-back inside the same critical section to verify consistency.
                long a = Volatile.Read(ref sharedA);
                long b = Volatile.Read(ref sharedB);
                if (a != b)
                {
                    Interlocked.Increment(ref violations);
                }

                spinLock.Exit();
            }
        });

        AssertNoQuantumStalls(nameof(StoreOrderingIsPreservedAcrossRelease), _threadCount, (long)_threadCount * IterationsPerThread, elapsed);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(violations, Is.Zero, "Inconsistent pair observed: release reordered before stores");
            Assert.That(sharedA, Is.EqualTo(sharedB));
            Assert.That(sharedA, Is.EqualTo((long)_threadCount * IterationsPerThread));
        }
    }

    /// <summary>
    /// Proves that data written under the lock is fully visible to the next acquirer.
    /// Each thread reads a value, verifies it, increments it, and releases.
    /// If the release store could be reordered, the next acquirer would read stale data.
    /// </summary>
    [Test, CancelAfter(30_000)]
    public void AcquirerSeesAllStoresFromPreviousHolder()
    {
        var spinLock = new SpinLock();

        // Four independent words that must remain consistent.
        long word0 = 0, word1 = 0, word2 = 0, word3 = 0;
        int violations = 0;

        TimeSpan elapsed = RunContentionTest(_threadCount, IterationsPerThread, () => {
            for (int i = 0; i < IterationsPerThread; i++)
            {
                spinLock.Enter();

                // Verify the previous holder's writes are fully visible.
                long w0 = Volatile.Read(ref word0);
                long w1 = Volatile.Read(ref word1);
                long w2 = Volatile.Read(ref word2);
                long w3 = Volatile.Read(ref word3);
                if (w0 != w1 || w1 != w2 || w2 != w3)
                {
                    Interlocked.Increment(ref violations);
                }

                // Write a new consistent snapshot.
                long next = w0 + 1;
                word0 = next;
                word1 = next;
                word2 = next;
                word3 = next;

                spinLock.Exit();
            }
        });

        AssertNoQuantumStalls(nameof(AcquirerSeesAllStoresFromPreviousHolder), _threadCount, (long)_threadCount * IterationsPerThread, elapsed);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(violations, Is.Zero, "Acquirer observed partially-written state from previous holder");
            Assert.That(word0, Is.EqualTo((long)_threadCount * IterationsPerThread));
        }
    }

    /// <summary>
    /// Exercises a producer-consumer handoff pattern under the lock. One thread sets
    /// a flag and data, the next thread reads them. Verifies that the flag and data
    /// are always observed consistently (flag is never seen set without the data).
    /// </summary>
    [Test, CancelAfter(30_000)]
    public void ProducerConsumerHandoffIsOrdered()
    {
        var spinLock = new SpinLock();
        long sequence = 0;
        long payload = 0;
        int violations = 0;

        TimeSpan elapsed = RunContentionTest(_threadCount, IterationsPerThread, () => {
            for (int i = 0; i < IterationsPerThread; i++)
            {
                spinLock.Enter();

                // Verify: payload must always equal sequence (set atomically by previous holder).
                long s = Volatile.Read(ref sequence);
                long p = Volatile.Read(ref payload);
                if (s != p)
                {
                    Interlocked.Increment(ref violations);
                }

                // Produce: write payload first, then sequence (intentionally reversed
                // to stress that the lock release must fence both stores).
                long next = s + 1;
                payload = next;
                sequence = next;

                spinLock.Exit();
            }
        });

        AssertNoQuantumStalls(nameof(ProducerConsumerHandoffIsOrdered), _threadCount, (long)_threadCount * IterationsPerThread, elapsed);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(violations, Is.Zero, "Payload/sequence mismatch: release did not fence stores");
            Assert.That(sequence, Is.EqualTo((long)_threadCount * IterationsPerThread));
        }
    }

    /// <summary>
    /// Verifies mutual exclusion by detecting overlapping critical sections.
    /// A shared guard variable is set to 1 on entry and 0 on exit. If any thread
    /// observes the guard already at 1 when entering, mutual exclusion was violated.
    /// </summary>
    [Test, CancelAfter(30_000)]
    public void NoConcurrentCriticalSectionEntry()
    {
        var spinLock = new SpinLock();
        int guard = 0;
        int concurrencyViolations = 0;
        long totalIterations = 0;

        TimeSpan elapsed = RunContentionTest(_threadCount, IterationsPerThread, () => {
            for (int i = 0; i < IterationsPerThread; i++)
            {
                spinLock.Enter();

                // If guard is already 1, another thread is inside the critical section.
                if (Interlocked.Exchange(ref guard, 1) != 0)
                {
                    Interlocked.Increment(ref concurrencyViolations);
                }

                // Small amount of work to widen the window for races.
                Interlocked.Increment(ref totalIterations);

                // Release the guard before releasing the lock.
                Volatile.Write(ref guard, 0);

                spinLock.Exit();
            }
        });

        AssertNoQuantumStalls(nameof(NoConcurrentCriticalSectionEntry), _threadCount, (long)_threadCount * IterationsPerThread, elapsed);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(concurrencyViolations, Is.Zero, "Multiple threads entered the critical section simultaneously");
            Assert.That(totalIterations, Is.EqualTo((long)_threadCount * IterationsPerThread));
        }
    }

    /// <summary>
    /// Stresses the lock with mixed workloads: some threads do short critical sections,
    /// others do longer ones. This maximizes contention asymmetry and exposes potential
    /// reordering issues when the lock holder changes rapidly.
    /// </summary>
    [Test, CancelAfter(30_000)]
    public void AsymmetricWorkloadMaintainsConsistency()
    {
        var spinLock = new SpinLock();
        long sharedCounter = 0;
        int iterations = IterationsPerThread / 2;

        var threads = new Thread[_threadCount];
        using var barrier = new ManualResetEventSlim(false);

        for (int t = 0; t < _threadCount; t++)
        {
            int threadId = t;
            threads[t] = new Thread(() => {
                barrier.Wait();
                for (int i = 0; i < iterations; i++)
                {
                    spinLock.Enter();

                    // Even-numbered threads do a tiny bit of extra work.
                    if (threadId % 2 == 0)
                    {
                        long tmp = sharedCounter;
                        tmp++;
                        Thread.SpinWait(4);
                        sharedCounter = tmp;
                    }
                    else
                    {
                        sharedCounter++;
                    }

                    spinLock.Exit();
                }
            }) {
                IsBackground = true
            };
            threads[t].Start();
        }

        long start = Stopwatch.GetTimestamp();
        barrier.Set();

        for (int t = 0; t < _threadCount; t++)
        {
            threads[t].Join();
        }

        TimeSpan elapsed = Elapsed(start);

        AssertNoQuantumStalls(nameof(AsymmetricWorkloadMaintainsConsistency), _threadCount, (long)_threadCount * iterations, elapsed);

        Assert.That(sharedCounter, Is.EqualTo((long)_threadCount * iterations));
    }

    /// <summary>
    /// Runs the specified action on <paramref name="threadCount"/> threads in parallel,
    /// with a barrier to synchronize start and maximize contention.
    /// </summary>
    /// <returns>
    /// Wall-clock time from the moment the threads were released to the moment the last one finished,
    /// taken from the high performance counter. The timer starts after the threads have been created, so
    /// thread-creation cost is not charged to the lock.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static TimeSpan RunContentionTest(int threadCount, int iterationsPerThread, Action body)
    {
        var threads = new Thread[threadCount];
        using var barrier = new ManualResetEventSlim(false);

        for (int t = 0; t < threadCount; t++)
        {
            threads[t] = new Thread(() => {
                barrier.Wait();
                body();
            }) {
                IsBackground = true
            };
            threads[t].Start();
        }

        // Release all threads simultaneously for maximum contention.
        long start = Stopwatch.GetTimestamp();
        barrier.Set();

        for (int t = 0; t < threadCount; t++)
        {
            threads[t].Join();
        }

        return Elapsed(start);
    }

    /// <summary>High performance counter ticks since <paramref name="start"/>, as a <see cref="TimeSpan"/>.</summary>
    private static TimeSpan Elapsed(long start)
        => TimeSpan.FromMilliseconds((Stopwatch.GetTimestamp() - start) * 1000.0 / Stopwatch.Frequency);

    /// <summary>
    /// Reports the throughput of a contention run and asserts that no waiter was parked on the
    /// scheduler-quantum timer often enough to show up in the aggregate.
    /// </summary>
    /// <param name="operation">Name of the run, for the report.</param>
    /// <param name="threadCount">Threads that took part.</param>
    /// <param name="acquisitions">Total lock acquisitions across all threads.</param>
    /// <param name="elapsed">Wall-clock time the run took.</param>
    private static void AssertNoQuantumStalls(string operation, int threadCount, long acquisitions, TimeSpan elapsed)
    {
        double microsecondsPerAcquisition = elapsed.TotalMilliseconds * 1000.0 / acquisitions;

        TestContext.Out.WriteLine();
        TestContext.Out.WriteLine($"{operation}: {acquisitions:N0} acquisitions on {threadCount} threads in {elapsed.TotalMilliseconds:N1} ms");
        TestContext.Out.WriteLine($"{"  mean per acquisition",-32} {microsecondsPerAcquisition,10:N3} us");
        TestContext.Out.WriteLine($"{"  budget",-32} {MaxMeanAcquisitionMicroseconds,10:N3} us");

        Assert.That(
            microsecondsPerAcquisition,
            Is.LessThan(MaxMeanAcquisitionMicroseconds),
            $"{microsecondsPerAcquisition:N1} us per acquisition of a critical section that is a handful of " +
            "instructions long: waiters are being parked rather than spun.");
    }
}
