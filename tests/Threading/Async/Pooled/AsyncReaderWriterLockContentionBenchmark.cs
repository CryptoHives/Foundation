// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CHT003 // ValueTask stored in field
#pragma warning disable VSTHRD012 // Provide JoinableTaskFactory where allowed
#pragma warning disable CA2012 // Use ValueTasks correctly

namespace Threading.Tests.Async.Pooled;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System.Threading.Tasks;

/// <summary>
/// Benchmarks measuring contention performance when readers, writers and an upgradeable reader
/// all compete for the same <see cref="AsyncReaderWriterLock"/> simultaneously.
/// </summary>
/// <remarks>
/// <para>
/// This benchmark suite evaluates how different reader-writer lock implementations handle
/// mixed contention between concurrent reader, writer and upgradeable reader requests.
/// </para>
/// <para>
/// <b>Test scenario:</b> While holding a writer lock, queue <see cref="Iterations"/> reader
/// requests, one upgradeable reader request, and one additional writer request. After releasing
/// the outer writer lock, all readers and the upgradeable reader are granted concurrently.
/// Once they are all released, the additional writer is granted.
/// </para>
/// <para>
/// <b>Compared implementations:</b>
/// </para>
/// <list type="bullet">
/// <item><description><b>Pooled (baseline):</b> Allocation-free async implementation using pooled IValueTaskSource.</description></item>
/// <item><description><b>VS.Threading:</b> Third-party async library with custom awaitable reader-writer lock.</description></item>
/// </list>
/// <para>
/// <b>Key metrics:</b> Execution time and memory allocations under mixed lock-type contention,
/// with varying numbers of concurrent reader waiters (controlled by <see cref="Iterations"/>).
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(FixtureArgs))]
[Config(typeof(ThreadingConfig))]
[NonParallelizable]
[BenchmarkCategory("AsyncReaderWriterLock")]
public class AsyncReaderWriterLockContentionBenchmark : AsyncReaderWriterLockBaseBenchmark
{
    private ValueTask<AsyncReaderWriterLock.Releaser>[]? _rwLockPooledReaderHandles;
    private ValueTask<AsyncReaderWriterLock.Releaser> _rwLockPooledUpgradeableHandle;
    private ValueTask<AsyncReaderWriterLock.Releaser> _rwLockPooledWriterHandle;

    private Task<Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser>[]? _rwlockVSThreadingReaderHandles;
    private Task<Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser>[]? _rwlockVSThreadingAdditionalHandles;

    public static readonly object[] FixtureArgs = {
        new object[] { 1 },
        new object[] { 5 },
        new object[] { 10 },
    };

    [Params(1, 5, 10)]
    public int Iterations { get; set; } = 5;

    public AsyncReaderWriterLockContentionBenchmark() { }

    public AsyncReaderWriterLockContentionBenchmark(int iterations)
    {
        Iterations = iterations;
    }

    public override void GlobalCleanup()
    {
        base.GlobalCleanup();
    }

    private static async Task<Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser> ReadLockVSAsync(
        Microsoft.VisualStudio.Threading.AsyncReaderWriterLock rwLock)
        => await rwLock.ReadLockAsync();

    private static async Task<Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser> UpgradeableReadLockVSAsync(
        Microsoft.VisualStudio.Threading.AsyncReaderWriterLock rwLock)
        => await rwLock.UpgradeableReadLockAsync();

    private static async Task<Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser> WriteLockVSAsync(
        Microsoft.VisualStudio.Threading.AsyncReaderWriterLock rwLock)
        => await rwLock.WriteLockAsync();

    // ─── Pooled ────────────────────────────────────────────────────────────────

    [Test]
    public Task ContentionPooledTestAsync()
    {
        PooledGlobalSetup();
        return ContentionPooledAsync();
    }

    [GlobalSetup(Target = nameof(ContentionPooledAsync))]
    public void PooledGlobalSetup()
    {
        base.GlobalSetup();
        _rwLockPooledReaderHandles = new ValueTask<AsyncReaderWriterLock.Releaser>[Iterations];
    }

    /// <summary>
    /// Benchmark for pooled async reader-writer lock under mixed reader/writer/upgradeable reader contention.
    /// </summary>
    [Benchmark(Baseline = true)]
    [BenchmarkCategory("Contention", "Pooled")]
    public async Task ContentionPooledAsync()
    {
        using (await _rwLockPooled.WriterLockAsync().ConfigureAwait(false))
        {
            for (int i = 0; i < Iterations; i++)
            {
                _rwLockPooledReaderHandles![i] = _rwLockPooled.ReaderLockAsync();
            }
            _rwLockPooledUpgradeableHandle = _rwLockPooled.UpgradeableReaderLockAsync();
            _rwLockPooledWriterHandle = _rwLockPooled.WriterLockAsync();
        }

        using (await _rwLockPooledWriterHandle.ConfigureAwait(false)) { }
        using (await _rwLockPooledUpgradeableHandle.ConfigureAwait(false)) { }
        for (int i = 0; i < Iterations; i++)
        {
            using (await _rwLockPooledReaderHandles![i].ConfigureAwait(false)) { }
        }
    }

    // ─── VS.Threading ──────────────────────────────────────────────────────────

    [Test]
    public Task ContentionVSThreadingTestAsync()
    {
        VSThreadingGlobalSetup();
        return ContentionVSThreadingAsync();
    }

    [GlobalSetup(Target = nameof(ContentionVSThreadingAsync))]
    public void VSThreadingGlobalSetup()
    {
        base.GlobalSetup();
        _rwlockVSThreadingReaderHandles = new Task<Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser>[Iterations];
        _rwlockVSThreadingAdditionalHandles = new Task<Microsoft.VisualStudio.Threading.AsyncReaderWriterLock.Releaser>[2];
    }

    /// <summary>
    /// Benchmark for VS.Threading async reader-writer lock under mixed contention.
    /// </summary>
    [Benchmark]
    [BenchmarkCategory("Contention", "VS.Threading")]
    public async Task ContentionVSThreadingAsync()
    {
        using (await _rwLockVSThreading.WriteLockAsync())
        {
            for (int i = 0; i < Iterations; i++)
            {
                _rwlockVSThreadingReaderHandles![i] = ReadLockVSAsync(_rwLockVSThreading);
            }
            _rwlockVSThreadingAdditionalHandles![0] = UpgradeableReadLockVSAsync(_rwLockVSThreading);
            _rwlockVSThreadingAdditionalHandles![1] = WriteLockVSAsync(_rwLockVSThreading);
        }

        for (int i = 0; i < Iterations; i++)
        {
            using (await _rwlockVSThreadingReaderHandles![i].ConfigureAwait(false)) { }
        }
        using (await _rwlockVSThreadingAdditionalHandles![0].ConfigureAwait(false)) { }
        using (await _rwlockVSThreadingAdditionalHandles![1].ConfigureAwait(false)) { }
    }
}

