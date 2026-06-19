# AsyncReaderWriterLock

A pooled, allocation-free async reader-writer lock that supports multiple concurrent readers or a single exclusive writer using ValueTask-based waiters with cancellation tokens.

## Overview

`AsyncReaderWriterLock` is an async-compatible reader-writer lock. It allows multiple readers to enter the lock concurrently, but only one writer can hold the lock exclusively. Writers are prioritized over readers to prevent writer starvation. One upgradeable reader at a time can share access with multiple other readers. Once the
upgradeable reader is upgraded to writer, it may have to wait until all readers release the lock. An upgradeable reader may release the lock while still upgraded writers are queued for write access.

```
┌─────────────────────────────────────────────────────────────────────────────┐
│    ------------                                                             │
│    |          | <-----> READERS                                             │
│    |          | <-----> UPGRADEABLE READER + READERS                        │
│    |   IDLE   | <-----> UPGRADEABLE READER -----> UPGRADED WRITER --\       │
│    | NO LOCKS |         ^                                           |       │
│    |          |         |------- DEMOTE TO UPGRADEABLE READER    <--/       │
│    |          | <--------------- DEMOTE TO IDLE WITHOUT READER   <--/       │
│    |          | <-----> WRITER                                              │
│    ------------                                                             │
└─────────────────────────────────────────────────────────────────────────────┘
```

## Usage

### Basic Usage

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

private readonly AsyncReaderWriterLock _rwLock = new AsyncReaderWriterLock();

// Reader
public async Task<Data> ReadDataAsync(CancellationToken ct)
{
    using (await _rwLock.ReaderLockAsync(ct))
    {
        // Multiple readers can hold the lock concurrently
        return await FetchDataAsync();
    }
}

// Writer
public async Task WriteDataAsync(Data data, CancellationToken ct)
{
    using (await _rwLock.WriterLockAsync(ct))
    {
        // Exclusive access - no other readers or writers
        await SaveDataAsync(data);
    }
}

// Upgradeable reader
public async Task UpdateIfNeededAsync(CancellationToken ct)
{
    using (var upgradeable = await _rwLock.UpgradeableReaderLockAsync(ct))
    {
        if (NeedsUpdate())
        {
            using (await upgradeable.UpgradeToWriterLockAsync(ct))
            {
                await SaveDataAsync();
            }
        }
    }
}
```

### Cache Pattern

```csharp
private readonly AsyncReaderWriterLock _cacheLock = new AsyncReaderWriterLock();
private Dictionary<string, object> _cache = new();

public async Task<T> GetOrAddAsync<T>(string key, Func<Task<T>> factory, CancellationToken ct)
{
    // Try to read first
    using (await _cacheLock.ReaderLockAsync(ct))
    {
        if (_cache.TryGetValue(key, out var cached))
        {
            return (T)cached;
        }
    }

    // Need to write
    using (await _cacheLock.WriterLockAsync(ct))
    {
        // Double-check after acquiring write lock
        if (_cache.TryGetValue(key, out var cached))
        {
            return (T)cached;
        }

        var value = await factory();
        _cache[key] = value;
        return value;
    }
}
```

## Constructor

```csharp
public AsyncReaderWriterLock(
    bool runContinuationAsynchronously = true,
    IGetPooledManualResetValueTaskSource<Releaser>? pool = null)
```

| Parameter | Description |
|-----------|-------------|
| `runContinuationAsynchronously` | If true (default), continuations run on the thread pool. |
| `pool` | Optional custom pool for ValueTaskSource instances used by both readers and writers. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsReadLockHeld` | `bool` | Gets whether one or more readers currently hold the lock. |
| `IsWriteLockHeld` | `bool` | Gets whether the lock is currently held by a writer. |
| `IsUpgradeableReadLockHeld` | `bool` | Gets whether the lock is currently held by an upgradeable reader. |
| `IsUpgradedWriterLockHeld` | `bool` | Gets whether an upgradeable reader is currently upgraded to writer mode. |
| `CurrentReaderCount` | `int` | Gets the number of readers holding the lock. |
| `WaitingWriterCount` | `int` | Gets the number of writers waiting. |
| `WaitingReaderCount` | `int` | Gets the number of readers waiting. |
| `WaitingUpgradeableReaderCount` | `int` | Gets the number of upgradeable readers waiting. |
| `WaitingUpgradedWritersCount` | `int` | Gets the number of upgrade requests waiting for exclusive access. |
| `RunContinuationAsynchronously` | `bool` | Gets or sets whether continuations run asynchronously. |

## Methods

### ReaderLockAsync

```csharp
public ValueTask<Releaser> ReaderLockAsync(CancellationToken cancellationToken = default)
```

Asynchronously acquires a reader lock. Multiple readers can hold the lock concurrently.

### ReaderLockAsync (timeout)

```csharp
public ValueTask<Releaser> ReaderLockAsync(TimeSpan timeout)
```

Asynchronously acquires a reader lock, or throws `OperationCanceledException` if the timeout elapses first.

**Throws**: `OperationCanceledException` if the timeout elapses, `ArgumentOutOfRangeException` if `timeout` is negative and not `Timeout.InfiniteTimeSpan`.

### UpgradeableReaderLockAsync

```csharp
public ValueTask<Releaser> UpgradeableReaderLockAsync(CancellationToken cancellationToken = default)
```

Asynchronously acquires an upgradeable reader lock. One upgradeable reader can coexist with other readers and may later be promoted to a writer lock.

### UpgradeableReaderLockAsync (timeout)

```csharp
public ValueTask<Releaser> UpgradeableReaderLockAsync(TimeSpan timeout)
```

Asynchronously acquires an upgradeable reader lock, or throws `OperationCanceledException` if the timeout elapses first.

**Throws**: `OperationCanceledException` if the timeout elapses, `ArgumentOutOfRangeException` if `timeout` is negative and not `Timeout.InfiniteTimeSpan`.

### WriterLockAsync

```csharp
public ValueTask<Releaser> WriterLockAsync(CancellationToken cancellationToken = default)
```

Asynchronously acquires a writer lock. Only one writer can hold the lock.

### WriterLockAsync (timeout)

```csharp
public ValueTask<Releaser> WriterLockAsync(TimeSpan timeout)
```

Asynchronously acquires a writer lock, or throws `OperationCanceledException` if the timeout elapses first.

**Throws**: `OperationCanceledException` if the timeout elapses, `ArgumentOutOfRangeException` if `timeout` is negative and not `Timeout.InfiniteTimeSpan`.

**Allocation notes for all timeout overloads**:

| Scenario | CancellationTokenSource allocated? |
|---|---|
| Lock immediately available | No |
| `Timeout.InfiniteTimeSpan` | No |
| `TimeSpan.Zero` and contested | No (immediate exception) |
| Finite positive timeout | Yes — one instance, disposed on await |

**Example**:

```csharp
try
{
    using (await _rwLock.ReaderLockAsync(TimeSpan.FromSeconds(5)))
    {
        return await ReadDataAsync();
    }
}
catch (OperationCanceledException)
{
    HandleTimeout();
}
```

## Releaser

All lock-acquisition methods return a `Releaser` struct that implements `IDisposable` and `IAsyncDisposable`:

```csharp
using (await _rwLock.ReaderLockAsync())
{
    // Lock is held here
}
// Lock is automatically released
```

When the `Releaser` originated from `UpgradeableReaderLockAsync`, it also exposes:

```csharp
public ValueTask<Releaser> UpgradeToWriterLockAsync(CancellationToken cancellationToken = default)
```

This upgrades the currently held upgradeable reader to an exclusive writer lock.

## Fairness and Priority

- **Writer Priority**: New readers are queued behind waiting writers to prevent writer starvation
- **Reader Batching**: When a writer releases, all waiting readers are released together
- **FIFO Readers and Writers**: Waiting writers and readers are released in order

## Performance

- **O(1)** reader acquisition with fast path when no writers are waiting/holding
- **O(1)** writer acquisition with fast path when lock is free
- **O(n)** reader batch release when writer releases
- **Zero allocations** on the fast path (uncontended) and contended path, unless the ObjectPool is exhausted. A custom pool can be provided to satisfy specific needs.

## Benchmark Results

The following benchmarks compare `AsyncReaderWriterLock` against `ReaderWriterLockSlim`, `Nito.AsyncEx.AsyncReaderWriterLock`, `Proto.Promises.Threading.AsyncReaderWriterLock`, `Microsoft.VisualStudio.Threading.AsyncReaderWriterLock`, and a reference implementation. Not all implementations support every lock mode; the set of compared implementations varies per benchmark.

### Reader Lock Benchmark

Measures the performance of acquiring and releasing reader locks with varying numbers of nested acquisitions. At the lowest iteration count (Iterations = 0), the pooled implementation achieves lower latency than Proto.Promises; from Iterations = 1 onward, Proto.Promises achieves lower per-operation latency, reflecting a lower per-lock-call overhead at the cost of a slightly higher fixed invocation overhead. Both operate with zero allocations. Nito.AsyncEx allocates per acquisition. VS.Threading allocates per acquisition and shows substantially higher latency at all iteration counts.

[!INCLUDE[Reader Lock Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asyncreaderwriterlock-reader.md)]

### Writer Lock Benchmark

Measures the performance of acquiring and releasing a single writer lock. Proto.Promises achieves lower uncontended latency than the pooled implementation, with both operating at zero allocations. Nito.AsyncEx allocates per acquisition. VS.Threading allocates per acquisition and shows substantially higher latency.

[!INCLUDE[Writer Lock Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asyncreaderwriterlock-writer.md)]

### Upgradeable Reader Lock Benchmark

Measures the performance of acquiring an upgradeable reader lock in combination with varying numbers of additional reader locks. At the lowest iteration count (Iterations = 0), the pooled implementation is marginally faster; Proto.Promises achieves lower per-operation latency as the number of additional reader locks increases. Both operate with zero allocations. VS.Threading allocates per acquisition and shows substantially higher latency across all iteration counts.

[!INCLUDE[Upgradeable Reader Lock Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asyncreaderwriterlock-upgradeablereader.md)]

### Upgraded Writer Lock Benchmark

Measures the performance of acquiring an upgradeable reader lock, holding additional reader locks concurrently, then upgrading to an exclusive writer lock. The pooled implementation is marginally faster at the lowest iteration count (Iterations = 0); Proto.Promises achieves lower per-operation latency as the number of held reader locks increases. Both operate with zero allocations. VS.Threading allocates proportionally to the number of held reader locks and shows substantially higher latency across all configurations.

[!INCLUDE[Upgraded Writer Lock Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asyncreaderwriterlock-upgradedwriter.md)]

### Benchmark Analysis

**Key Findings:**

1. **Reader and upgradeable reader performance**: At a single acquisition per call, the pooled implementation has a slight latency advantage. As the number of lock operations per call increases, Proto.Promises achieves lower per-operation latency in both the reader and upgradeable reader benchmarks, with zero allocations in both cases.

2. **Writer and upgraded writer performance**: For single-operation writer lock acquisition, Proto.Promises achieves lower uncontended latency than the pooled implementation. The same pattern holds for the upgraded writer benchmark: the pooled implementation is marginally faster at minimal load, while Proto.Promises achieves lower per-operation latency as the number of additionally held reader locks increases. Both implementations operate with zero allocations.

3. **Writer priority**: The writer-priority design prevents writer starvation but may reduce reader throughput when writers are frequently queued.

4. **Memory efficiency**: A shared pool for readers, upgradeable readers, and writers allows fine-tuned pool sizing. The pooled implementation maintains zero allocations across all published benchmarks, matching Proto.Promises. Nito.AsyncEx allocates per acquisition in the reader and writer benchmarks. VS.Threading allocates per acquisition in all benchmarks, with memory usage growing proportionally to the number of concurrently held locks.

5. **Releaser struct**: The value-type `Releaser` produces no allocation for the lock handle itself. Allocations occur only for the pooled `IValueTaskSource` when the pool is exhausted under sustained contention.

**When to Choose AsyncReaderWriterLock:**

- Read-heavy workloads with occasional writes
- Cache implementations with read/write patterns
- Document or configuration stores

## Best Practices

### ✓ DO: Use timeout overloads to bound lock-wait time

```csharp
try
{
    using (await _rwLock.WriterLockAsync(TimeSpan.FromSeconds(5)))
    {
        await SaveDataAsync();
    }
}
catch (OperationCanceledException)
{
    HandleTimeout();
}
```

**Design Trade-offs:**

- Writer priority may reduce reader throughput under write-heavy loads
- Consider `AsyncLock` for simpler mutex-style locking
- For read-only scenarios, no lock is needed

## Comparison with ReaderWriterLockSlim

| Feature | AsyncReaderWriterLock | ReaderWriterLockSlim |
|---------|----------------------|---------------------|
| Async support | Native | None |
| Allocation overhead | Minimal (pooled) | None (sync) |
| Writer priority | Yes | Configurable |
| Cancellation | Full support | None |

## See Also

- [Threading Package Overview](index.md)
- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncManualResetEvent](asyncmanualresetevent.md) - Manual-reset event variant
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [AsyncCountdownEvent](asynccountdownevent.md) - Async countdown event
- [AsyncBarrier](asyncbarrier.md) - Async barrier synchronization primitive
- [AsyncSemaphore](asyncsemaphore.md) - Async semaphore primitive
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
