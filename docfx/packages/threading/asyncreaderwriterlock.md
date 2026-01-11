# AsyncReaderWriterLock

A pooled, allocation-free async reader-writer lock that supports multiple concurrent readers or a single exclusive writer using ValueTask-based waiters with cancellation tokens.

## Overview

`AsyncReaderWriterLock` is an async-compatible reader-writer lock. It allows multiple readers to enter the lock concurrently, but only one writer can hold the lock exclusively. Writers are prioritized over readers to prevent writer starvation.

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
    int defaultEventQueueSize = 0,
    IGetPooledManualResetValueTaskSource<Releaser>? pool = null)
```

| Parameter | Description |
|-----------|-------------|
| `runContinuationAsynchronously` | If true (default), continuations run on the thread pool. |
| `defaultEventQueueSize` | Initial capacity for waiter queues. |
| `pool` | Optional custom pool for ValueTaskSource instances used by both readers and writers. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsReaderLockHeld` | `bool` | Gets whether any readers hold the lock. |
| `IsWriterLockHeld` | `bool` | Gets whether a writer holds the lock. |
| `CurrentReaderCount` | `int` | Gets the number of readers holding the lock. |
| `WaitingWriterCount` | `int` | Gets the number of writers waiting. |
| `WaitingReaderCount` | `int` | Gets the number of readers waiting. |
| `RunContinuationAsynchronously` | `bool` | Gets or sets whether continuations run asynchronously. |

## Methods

### ReaderLockAsync

```csharp
public ValueTask<Releaser> ReaderLockAsync(CancellationToken cancellationToken = default)
```

Asynchronously acquires a reader lock. Multiple readers can hold the lock concurrently.

### WriterLockAsync

```csharp
public ValueTask<Releaser> WriterLockAsync(CancellationToken cancellationToken = default)
```

Asynchronously acquires a writer lock. Only one writer can hold the lock.

## Releaser

Both methods return a `Releaser` struct that implements `IDisposable` and `IAsyncDisposable`:

```csharp
using (await _rwLock.ReaderLockAsync())
{
    // Lock is held here
}
// Lock is automatically released
```

## Fairness and Priority

- **Writer Priority**: New readers are queued behind waiting writers to prevent writer starvation
- **Reader Batching**: When a writer releases, all waiting readers are released together
- **FIFO Writers**: Waiting writers are released in order

## Performance

- **O(1)** reader acquisition when no writers are waiting/holding
- **O(1)** writer acquisition when lock is free
- **O(n)** reader batch release when writer releases
- **Zero allocations** on the fast path (uncontended)

## Benchmark Results

The following benchmarks compare `AsyncReaderWriterLock` against `ReaderWriterLockSlim`, `Nito.AsyncEx.AsyncReaderWriterLock` and a reference implementation.
TODO: Currently benchmarks are only available on uncontended scenarios to measure the overhead of a single lock acquisition and release.

### Reader Lock Benchmark

Measures the performance of acquiring and releasing reader locks.

[!INCLUDE[Reader Lock Benchmark](benchmarks/asyncreaderwriterlock-reader.md)]

### Writer Lock Benchmark

Measures the performance of acquiring and releasing writer locks.

[!INCLUDE[Writer Lock Benchmark](benchmarks/asyncreaderwriterlock-writer.md)]

### Benchmark Analysis

**Key Findings:**

1. **Reader Performance**: Uncontended reader lock acquisition is extremely fast with zero allocations. Multiple concurrent readers can proceed without blocking each other.

2. **Writer Priority**: The writer-priority design prevents starvation but may impact reader throughput when writers are frequently waiting.

3. **Memory Efficiency**: One pool for readers and writers allow fine-tuned pool sizing based on workload characteristics.

4. **Releaser Struct**: The value-type `Releaser` ensures no allocation for the lock handle itself, only for the `IValueTaskSource` when contention occurs.

**When to Choose AsyncReaderWriterLock:**

- Read-heavy workloads with occasional writes
- Cache implementations with read/write patterns
- Document or configuration stores

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
