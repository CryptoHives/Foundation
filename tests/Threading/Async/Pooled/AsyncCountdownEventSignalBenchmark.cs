// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using CryptoHives.Foundation.Threading.Async.Pooled;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

#if SIGNASSEMBLY
using NitoAsyncEx = RefImpl;
#else
using NitoAsyncEx = Nito.AsyncEx;
#endif

/// <summary>
/// Benchmarks measuring countdown event signal and wait performance.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates the performance of async countdown events
/// when multiple signals are made and waiters are released.
/// </para>
/// <para>
/// <b>Test scenario:</b> Signal countdown multiple times until completion, then wait.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>CountdownEvent:</b> .NET built-in synchronous countdown event.</description></item>
/// <item><description><b>Pooled:</b> Allocation-free async implementation using pooled IValueTaskSource.</description></item>
/// <item><description><b>Nito.AsyncEx:</b> Third-party async library with Task-based countdown.</description></item>
/// <item><description><b>RefImpl (baseline):</b> Reference implementation using TaskCompletionSource and Task.</description></item>
/// </list>
/// </remarks>
[TestFixture]
[MemoryDiagnoser(displayGenColumns: false)]
[Orderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared)]
[HideColumns("Namespace", "Error", "StdDev", "Median", "RatioSD", "AllocRatio")]
[Description("Measures the performance of countdown event signal operations.")]
[NonParallelizable]
[BenchmarkCategory("AsyncCountdownEvent")]
public class AsyncCountdownEventSignalBenchmark : AsyncCountdownEventBaseBenchmark
{
    private volatile int _counter;

    /// <summary>
    /// Benchmark for standard CountdownEvent.
    /// </summary>
    [Test]
    [Benchmark]
    public void SignalAndWaitCountdownEventStandard()
    {
        var countdown = new CountdownEvent(_participantCount);
        for (int i = 0; i < _participantCount; i++)
        {
            countdown.Signal();
        }
        countdown.Wait();
        unchecked { _counter++; }
        countdown.Dispose();
    }

    /// <summary>
    /// Benchmark for pooled async countdown event.
    /// </summary>
    [Test]
    [Benchmark(Baseline = true)]
    public async Task SignalAndWaitPooledAsync()
    {
        var countdown = new AsyncCountdownEvent(_participantCount);
        for (int i = 0; i < _participantCount; i++)
        {
            countdown.Signal();
        }
        await countdown.WaitAsync().ConfigureAwait(false);
        unchecked { _counter++; }
    }

#if !SIGNASSEMBLY
    /// <summary>
    /// Benchmark for Nito.AsyncEx async countdown event.
    /// </summary>
    [Test]
    [Benchmark]
    public async Task SignalAndWaitNitoAsync()
    {
        var countdown = new NitoAsyncEx.AsyncCountdownEvent(_participantCount);
        for (int i = 0; i < _participantCount; i++)
        {
            countdown.Signal();
        }
        await countdown.WaitAsync().ConfigureAwait(false);
        unchecked { _counter++; }
    }
#endif

    /// <summary>
    /// Benchmark for reference implementation async countdown event.
    /// </summary>
    [Test]
    [Benchmark]
    public async Task SignalAndWaitRefImplAsync()
    {
        var countdown = new RefImpl.AsyncCountdownEvent(_participantCount);
        for (int i = 0; i < _participantCount; i++)
        {
            countdown.Signal();
        }
        await countdown.WaitAsync().ConfigureAwait(false);
        unchecked { _counter++; }
    }
}
