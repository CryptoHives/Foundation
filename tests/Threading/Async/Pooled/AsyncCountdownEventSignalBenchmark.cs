// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
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
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[Description("Measures the performance of countdown event signal operations.")]
[NonParallelizable]
[BenchmarkCategory("AsyncCountdownEvent")]
public class AsyncCountdownEventSignalBenchmark : AsyncCountdownEventBaseBenchmark
{
    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 10 },
    };

    public AsyncCountdownEventSignalBenchmark() { }

    public AsyncCountdownEventSignalBenchmark(int participateCount)
    {
        ParticipantCount = participateCount;
    }

    /// <summary>
    /// Benchmark for standard CountdownEvent.
    /// </summary>
    [Test]
    [Repeat(10)]
    [Benchmark]
    public void SignalAndWaitCountdownEventStandard()
    {
        _countdownStandard.Reset();
        for (int i = 0; i < ParticipantCount; i++)
        {
            _countdownStandard.Signal();
        }
        _countdownStandard.Wait(_cancellationToken);
    }

    /// <summary>
    /// Benchmark for pooled async countdown event.
    /// </summary>
    [Test]
    [Repeat(10)]
    [Benchmark(Baseline = true)]
    public async Task SignalAndWaitPooledAsync()
    {
        _countdownPooled.Reset();
        for (int i = 0; i < ParticipantCount; i++)
        {
            _countdownPooled.Signal();
        }
        await _countdownPooled.WaitAsync(_cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Benchmark for pooled async countdown event.
    /// </summary>
    [Test]
    [Repeat(10)]
    [Benchmark]
    public async Task WaitAndSignalPooledAsync()
    {
        _countdownPooled.Reset();
        ValueTask valueTask = _countdownPooled.WaitAsync(_cancellationToken);
        for (int i = 0; i < ParticipantCount; i++)
        {
            _countdownPooled.Signal();
        }
        await valueTask.ConfigureAwait(false);
    }

#if !SIGNASSEMBLY
    /// <summary>
    /// Benchmark for Nito.AsyncEx async countdown event.
    /// </summary>
    [Test]
    public async Task SignalAndWaitNitoAsync()
    {
        Task task = _countdownNitoAsync.WaitAsync(_cancellationToken);
        for (int i = 0; i < ParticipantCount; i++)
        {
            _countdownNitoAsync.Signal();
        }
        await task.ConfigureAwait(false);
    }
#endif

    /// <summary>
    /// Benchmark for reference implementation async countdown event.
    /// </summary>
    [Test]
    [Repeat(10)]
    [Benchmark]
    public async Task SignalAndWaitRefImplAsync()
    {
        _countdownRefImp.Reset();
        Task task = _countdownRefImp.WaitAsync();
        for (int i = 0; i < ParticipantCount; i++)
        {
            _countdownRefImp.Signal();
        }
        await task.ConfigureAwait(false);
    }
}
