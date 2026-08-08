// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

#pragma warning disable CA2012 // Use ValueTasks correctly
#pragma warning disable CA1062 // Validate arguments of public methods

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring the waiter side of an async countdown event, and the cost of signalling one
/// count at a time versus in bulk.
/// </summary>
/// <remarks>
/// <para>
/// <c>AsyncCountdownEventSignalBenchmark</c> measures the signalling side with a single waiter. This
/// class covers the two things that leaves out: several waiters released together by the final signal,
/// and <c>Signal(int)</c>, which drops the count to zero in one call rather than N. Those are different
/// code paths - one wakes a queue, the other decides only once whether the queue should be woken - and
/// only the second is reachable through the existing benchmarks.
/// </para>
/// <para>
/// <b>Test scenario:</b> Reset the event, queue <see cref="WaiterCount"/> waiters, then drive the count
/// to zero and drain them.
/// </para>
/// <para>
/// <b>Compared variants:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (signal each) (baseline):</b> <see cref="ParticipantCount"/> individual
/// <c>Signal()</c> calls, the shape the existing benchmark uses.</description></item>
/// <item><description><b>Pooled (signal bulk):</b> one <c>Signal(int)</c> call for the whole count.</description></item>
/// <item><description><b>Pooled (timed waiters):</b> the same as the baseline, but every waiter arms a
/// timeout, so the difference is what a timer per waiter costs.</description></item>
/// <item><description><b>CountdownEvent (System):</b> the framework primitive, for scale. Its waiters block
/// threads rather than queueing continuations, so absolute times are not comparable - the shape across
/// <see cref="WaiterCount"/> is.</description></item>
/// </list>
/// <para>
/// The timeout used never elapses, so what it measures is arming and disposing a timer rather than
/// handling an expiry. A timeout costs nothing until an operation actually queues, which is why the
/// timed variant lives here - on the waiter side - and not on the signalling benchmark.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures countdown event waiters released together, and bulk versus individual signalling.")]
[NonParallelizable]
[BenchmarkCategory("AsyncCountdownEvent")]
public class AsyncCountdownEventWaitersBenchmark : AsyncCountdownEventBaseBenchmark
{
    private ValueTask[] _valueTasks = Array.Empty<ValueTask>();
    private Task[] _tasks = Array.Empty<Task>();

    private volatile int _counter;

    public static readonly object[] FixtureArgs = {
        new object[] { 1, 1 },
        new object[] { 1, 10 },
        new object[] { 10, 1 },
        new object[] { 10, 10 },
    };

    /// <summary>
    /// How many waiters are queued before the count reaches zero, i.e. how many are released at once.
    /// </summary>
    [Params(1, 10)]
    public int WaiterCount { get; set; } = 10;

    public AsyncCountdownEventWaitersBenchmark() { }

    public AsyncCountdownEventWaitersBenchmark(int participantCount, int waiterCount)
    {
        ParticipantCount = participantCount;
        WaiterCount = waiterCount;
    }

    public override void GlobalSetup()
    {
        base.GlobalSetup();
        _valueTasks = new ValueTask[WaiterCount];
        _tasks = new Task[WaiterCount];
    }

    /// <summary>
    /// Baseline: queue the waiters, then signal the count down one at a time.
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Waiters", "Pooled (signal each)")]
    public async Task WaitersSignalEachPooledAsync()
    {
        _countdownPooled.Reset();

        for (int i = 0; i < WaiterCount; i++)
        {
            _valueTasks[i] = _countdownPooled.WaitAsync(_cancellationToken);
        }

        for (int i = 0; i < ParticipantCount; i++)
        {
            _countdownPooled.Signal();
        }

        for (int i = 0; i < WaiterCount; i++)
        {
            await _valueTasks[i].ConfigureAwait(false);
        }

        unchecked { _counter++; }
    }

    /// <summary>
    /// The same, but the whole count is signalled in one call. Only the final decrement can release the
    /// queue, so this measures how much of the per-signal cost is bookkeeping that a bulk call avoids.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Waiters", "Pooled (signal bulk)")]
    public async Task WaitersSignalBulkPooledAsync()
    {
        _countdownPooled.Reset();

        for (int i = 0; i < WaiterCount; i++)
        {
            _valueTasks[i] = _countdownPooled.WaitAsync(_cancellationToken);
        }

        _countdownPooled.Signal(ParticipantCount);

        for (int i = 0; i < WaiterCount; i++)
        {
            await _valueTasks[i].ConfigureAwait(false);
        }

        unchecked { _counter++; }
    }

    /// <summary>
    /// The baseline shape with every waiter arming a timeout that never elapses, so the delta is the
    /// cost of a timer per queued waiter.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Waiters", "Pooled (timed waiters)")]
    public async Task WaitersTimedPooledAsync()
    {
        _countdownPooled.Reset();

        for (int i = 0; i < WaiterCount; i++)
        {
            _valueTasks[i] = _countdownPooled.WaitAsync(CancellationType.NonElapsingTimeout, _cancellationToken);
        }

        for (int i = 0; i < ParticipantCount; i++)
        {
            _countdownPooled.Signal();
        }

        for (int i = 0; i < WaiterCount; i++)
        {
            await _valueTasks[i].ConfigureAwait(false);
        }

        unchecked { _counter++; }
    }

    /// <summary>
    /// The framework countdown event, for scale. Its waiters block threads, so absolute times are not
    /// comparable with the pooled variants.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Waiters", "System", "CountdownEvent")]
    public async Task WaitersSignalEachStandardAsync()
    {
        _countdownStandard.Reset();

        for (int i = 0; i < WaiterCount; i++)
        {
            _tasks[i] = Task.Run(() => _countdownStandard.Wait(_cancellationToken));
        }

        for (int i = 0; i < ParticipantCount; i++)
        {
            _countdownStandard.Signal();
        }

        for (int i = 0; i < WaiterCount; i++)
        {
            await _tasks[i].ConfigureAwait(false);
        }

        unchecked { _counter++; }
    }
}
