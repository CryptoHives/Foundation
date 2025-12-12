# AsyncReaderWriterLock

A pooled, allocation-free async reader-writer lock that supports multiple concurrent readers or a single exclusive writer using ValueTask-based waiters.

## Overview

`AsyncReaderWriterLock` is an async-compatible reader-writer lock. It allows multiple readers to hold the lock concurrently, but only one writer can hold the lock exclusively. Writers are prioritized over new readers to prevent writer starvation.

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
    IGetPooledManualResetValueTaskSource<Releaser>? readerPool = null,
    IGetPooledManualResetValueTaskSource<Releaser>? writerPool = null)
```

| Parameter | Description |
|-----------|-------------|
| `runContinuationAsynchronously` | If true (default), continuations run on the thread pool. |
| `defaultEventQueueSize` | Initial capacity for waiter queues. |
| `readerPool` | Optional custom pool for reader ValueTaskSource instances. |
| `writerPool` | Optional custom pool for writer ValueTaskSource instances. |

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

## Comparison with ReaderWriterLockSlim

| Feature | AsyncReaderWriterLock | ReaderWriterLockSlim |
|---------|----------------------|---------------------|
| Async support | Native | None |
| Allocation overhead | Minimal (pooled) | None (sync) |
| Writer priority | Yes | Configurable |
| Cancellation | Full support | None |

## See Also

- [AsyncLock](asynclock.md)
- [AsyncSemaphore](asyncsemaphore.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
