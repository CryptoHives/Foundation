// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Benchmarks.Pooled.AsyncConditionVariable;

#pragma warning disable CA2012 // Use ValueTasks correctly

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks the cost of one producer/consumer hand-off through a condition variable: the signal,
/// the wait, and the lock release and re-acquisition that a condition variable performs around it.
/// </summary>
/// <remarks>
/// <para>
/// <b>Test scenario:</b> A consumer holds the lock and waits on the condition variable until an item
/// is available; a producer takes the lock, publishes an item and signals. <see cref="Iterations"/>
/// items travel through the pair per operation. The consumer re-checks its predicate in a
/// <c>while</c> loop, which is the only correct way to use a condition variable and also makes the
/// benchmark independent of how many signals happen to arrive before a waiter is queued.
/// </para>
/// <para>
/// <b>Compared variants:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource
/// over the reference AsyncLock.</description></item>
/// <item><description><b>Pooled:</b> This library, over <c>AsyncLock</c>.</description></item>
/// <item><description><b>Pooled (timed):</b> The same, with every wait arming a timeout that never
/// elapses, so the difference is what a timer per wait costs.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> <c>AsyncConditionVariable</c> over Nito's
/// <c>AsyncLock</c>. Replaced by the reference implementation when the assembly is signed.</description></item>
/// </list>
/// <para>
/// The pooled waiter itself is allocation-free, but the wait is an <see langword="async"/> method
/// that awaits the signal and then the lock, so the allocation column shows one state machine box
/// per suspended wait rather than zero.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures a producer/consumer hand-off through a condition variable and its lock.")]
[NonParallelizable]
[BenchmarkCategory("AsyncConditionVariable")]
public class AsyncConditionVariableProducerConsumerBenchmark : AsyncConditionVariableBaseBenchmark
{
    private int _itemsPooled;
    private int _itemsRefImp;
    private int _itemsNitoAsync;

    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 10 },
    };

    public AsyncConditionVariableProducerConsumerBenchmark() { }

    public AsyncConditionVariableProducerConsumerBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    /// <summary>
    /// Baseline: the TaskCompletionSource-based reference implementation.
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("ProducerConsumer", "RefImpl")]
    public async Task RefImplProducerConsumerAsync()
    {
        _itemsRefImp = 0;

        Task consumer = Task.Run(async () => {
            using (await _lockRefImp.LockAsync().ConfigureAwait(false))
            {
                for (int i = 0; i < Iterations; i++)
                {
                    while (_itemsRefImp == 0)
                    {
                        await _conditionRefImp.WaitAsync().ConfigureAwait(false);
                    }

                    _itemsRefImp--;
                }
            }
        });

        for (int i = 0; i < Iterations; i++)
        {
            using (await _lockRefImp.LockAsync().ConfigureAwait(false))
            {
                _itemsRefImp++;
                _conditionRefImp.Notify();
            }
        }

        await consumer.ConfigureAwait(false);
    }

    /// <summary>
    /// This library's pooled condition variable over its pooled lock.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("ProducerConsumer", "Pooled")]
    public async Task PooledProducerConsumerAsync()
    {
        _itemsPooled = 0;

        Task consumer = Task.Run(async () => {
            using (await _lockPooled.LockAsync(_cancellationToken).ConfigureAwait(false))
            {
                for (int i = 0; i < Iterations; i++)
                {
                    while (_itemsPooled == 0)
                    {
                        await _conditionPooled.WaitAsync(_lockPooled, _cancellationToken).ConfigureAwait(false);
                    }

                    _itemsPooled--;
                }
            }
        });

        for (int i = 0; i < Iterations; i++)
        {
            using (await _lockPooled.LockAsync(_cancellationToken).ConfigureAwait(false))
            {
                _itemsPooled++;
                _conditionPooled.Signal();
            }
        }

        await consumer.ConfigureAwait(false);
    }

    /// <summary>
    /// The same, with a timeout that never elapses, so the delta is the cost of arming and
    /// disposing a timer per wait.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("ProducerConsumer", "Pooled (timed)")]
    public async Task PooledTimedProducerConsumerAsync()
    {
        _itemsPooled = 0;

        Task consumer = Task.Run(async () => {
            using (await _lockPooled.LockAsync(_cancellationToken).ConfigureAwait(false))
            {
                for (int i = 0; i < Iterations; i++)
                {
                    while (_itemsPooled == 0)
                    {
                        await _conditionPooled.WaitAsync(_lockPooled, TimeSpan.FromMinutes(5), _cancellationToken).ConfigureAwait(false);
                    }

                    _itemsPooled--;
                }
            }
        });

        for (int i = 0; i < Iterations; i++)
        {
            using (await _lockPooled.LockAsync(_cancellationToken).ConfigureAwait(false))
            {
                _itemsPooled++;
                _conditionPooled.Signal();
            }
        }

        await consumer.ConfigureAwait(false);
    }

    /// <summary>
    /// Nito.AsyncEx, whose condition variable is bound to its lock at construction.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("ProducerConsumer", "Nito.AsyncEx")]
    public async Task NitoAsyncProducerConsumerAsync()
    {
        _itemsNitoAsync = 0;

        Task consumer = Task.Run(async () => {
            using (await _lockNitoAsync.LockAsync().ConfigureAwait(false))
            {
                for (int i = 0; i < Iterations; i++)
                {
                    while (_itemsNitoAsync == 0)
                    {
                        await _conditionNitoAsync.WaitAsync().ConfigureAwait(false);
                    }

                    _itemsNitoAsync--;
                }
            }
        });

        for (int i = 0; i < Iterations; i++)
        {
            using (await _lockNitoAsync.LockAsync().ConfigureAwait(false))
            {
                _itemsNitoAsync++;
                _conditionNitoAsync.Notify();
            }
        }

        await consumer.ConfigureAwait(false);
    }
}
