// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

#pragma warning disable CA2012 // Use ValueTasks correctly

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Base class for benchmarking and testing different implementations of AsyncExchange.
/// </summary>
/// <remarks>
/// The BCL has no two-party exchanger, so the comparison is against a TaskCompletionSource-based
/// reference implementation of the same rendezvous rather than against another library.
/// </remarks>
public abstract class AsyncExchangeBaseBenchmark
{
    private protected AsyncExchange<int> _exchangePooled;
    private protected RefImpl.AsyncExchange<int> _exchangeRefImp;
    private protected CancellationTokenSource _cancellationTokenSource;
    private protected CancellationToken _cancellationToken;

    /// <summary>
    /// How many exchanges are performed per operation.
    /// </summary>
    [Params(1, 10)]
    public int Iterations { get; set; } = 10;

    /// <summary>
    /// Global Setup for benchmarks and tests.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _exchangePooled = new AsyncExchange<int>();
        _exchangeRefImp = new RefImpl.AsyncExchange<int>();
        _cancellationTokenSource = new CancellationTokenSource();
        _cancellationToken = _cancellationTokenSource.Token;
    }

    /// <summary>
    /// Global cleanup for benchmarks and tests.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
    }
}

/// <summary>
/// Benchmarks the two-party rendezvous: one party arrives and suspends, the second arrives and
/// completes both.
/// </summary>
/// <remarks>
/// <para>
/// <b>Test scenario:</b> Both calls are issued from the same thread, so the first always occupies
/// the slot and the second always pairs with it. That is the shape the primitive is built for, and
/// it keeps the measurement free of scheduling noise: no thread pool hand-off happens before the
/// pairing, only after it, when the first party's continuation is resumed.
/// </para>
/// <para>
/// <b>Compared variants:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource,
/// which allocates a source and a task per suspended party.</description></item>
/// <item><description><b>Pooled:</b> This library. The first party uses the instance-local value task
/// source, so a rendezvous with no concurrent second slot allocates nothing.</description></item>
/// <item><description><b>Pooled (cancellable):</b> The same with a cancellation token that never
/// fires, which on .NET 6.0+ registers without allocating.</description></item>
/// <item><description><b>Pooled (timed):</b> The same with a timeout that never elapses, so the
/// difference is what a timer per waiting party costs.</description></item>
/// </list>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures a two-party rendezvous through an async exchange.")]
[NonParallelizable]
[BenchmarkCategory("AsyncExchange")]
public class AsyncExchangeRendezvousBenchmark : AsyncExchangeBaseBenchmark
{
    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 10 },
    };

    public AsyncExchangeRendezvousBenchmark() { }

    public AsyncExchangeRendezvousBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    /// <summary>
    /// Baseline: the TaskCompletionSource-based reference implementation.
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Rendezvous", "RefImpl")]
    public async Task RefImplRendezvousAsync()
    {
        for (int i = 0; i < Iterations; i++)
        {
            Task<int> first = _exchangeRefImp.ExchangeAsync(i);
            Task<int> second = _exchangeRefImp.ExchangeAsync(i + 1);

            await first.ConfigureAwait(false);
            await second.ConfigureAwait(false);
        }
    }

    /// <summary>
    /// This library's pooled exchange.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Rendezvous", "Pooled")]
    public async Task PooledRendezvousAsync()
    {
        for (int i = 0; i < Iterations; i++)
        {
            ValueTask<int> first = _exchangePooled.ExchangeAsync(i);
            ValueTask<int> second = _exchangePooled.ExchangeAsync(i + 1);

            await first.ConfigureAwait(false);
            await second.ConfigureAwait(false);
        }
    }

    /// <summary>
    /// The same with a cancellation token that never fires.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Rendezvous", "Pooled (cancellable)")]
    public async Task PooledCancellableRendezvousAsync()
    {
        for (int i = 0; i < Iterations; i++)
        {
            ValueTask<int> first = _exchangePooled.ExchangeAsync(i, _cancellationToken);
            ValueTask<int> second = _exchangePooled.ExchangeAsync(i + 1, _cancellationToken);

            await first.ConfigureAwait(false);
            await second.ConfigureAwait(false);
        }
    }

    /// <summary>
    /// The same with a timeout that never elapses, so the delta is the cost of arming and
    /// disposing a timer for the party that waits.
    /// </summary>
    [Test]
    [Benchmark]
    [BenchmarkCategory("Rendezvous", "Pooled (timed)")]
    public async Task PooledTimedRendezvousAsync()
    {
        for (int i = 0; i < Iterations; i++)
        {
            ValueTask<int> first = _exchangePooled.ExchangeAsync(i, TimeSpan.FromMinutes(5), _cancellationToken);
            ValueTask<int> second = _exchangePooled.ExchangeAsync(i + 1, TimeSpan.FromMinutes(5), _cancellationToken);

            await first.ConfigureAwait(false);
            await second.ConfigureAwait(false);
        }
    }
}
