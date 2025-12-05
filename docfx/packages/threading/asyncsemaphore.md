# AsyncSemaphore

A pooled, allocation-free async semaphore that limits concurrent access using ValueTask-based waiters.

## Overview

`AsyncSemaphore` is an async-compatible semaphore that allows a configurable number of concurrent operations. It uses pooled `IValueTaskSource` instances to minimize allocations in high-throughput scenarios.

## Usage

### Basic Usage

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

private readonly AsyncSemaphore _semaphore = new AsyncSemaphore(3);

public async Task AccessLimitedResourceAsync(CancellationToken ct)
{
    await _semaphore.WaitAsync(ct);
    try
    {
        // Max 3 concurrent tasks can access this section
        await AccessResourceAsync();
    }
    finally
    {
        _semaphore.Release();
    }
}
```

### Rate Limiting

```csharp
private readonly AsyncSemaphore _rateLimiter = new AsyncSemaphore(5);

public async Task<T> RateLimitedOperationAsync<T>(Func<Task<T>> operation, CancellationToken ct)
{
    await _rateLimiter.WaitAsync(ct);
    try
    {
        return await operation();
    }
    finally
    {
        _rateLimiter.Release();
    }
}
```

## Constructor

```csharp
public AsyncSemaphore(
    int initialCount,
    bool runContinuationAsynchronously = true,
    int defaultEventQueueSize = 0,
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

| Parameter | Description |
|-----------|-------------|
| `initialCount` | The initial number of available permits. Must be non-negative. |
| `runContinuationAsynchronously` | If true (default), continuations run on the thread pool. |
| `defaultEventQueueSize` | Initial capacity for the waiter queue. |
| `pool` | Optional custom pool for ValueTaskSource instances. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `CurrentCount` | `int` | Gets the current number of available permits. |
| `RunContinuationAsynchronously` | `bool` | Gets or sets whether continuations run asynchronously. |

## Methods

### WaitAsync

```csharp
public ValueTask WaitAsync(CancellationToken cancellationToken = default)
```

Asynchronously waits to acquire a permit from the semaphore.

### Release

```csharp
public void Release()
public void Release(int releaseCount)
```

Releases one or more permits back to the semaphore.

## Performance

- **O(1)** acquisition when permits are available
- **FIFO** queue for waiters when no permits are available
- **Zero allocations** on the fast path (uncontended)
- Pooled ValueTaskSource instances for waiters

## Comparison with SemaphoreSlim

| Feature | AsyncSemaphore | SemaphoreSlim |
|---------|----------------|---------------|
| Allocation overhead | Minimal (pooled) | Higher (per wait) |
| ValueTask support | Native | Via WaitAsync |
| Cancellation | Full support | Full support |
| Performance | Optimized | Standard |

## See Also

- [AsyncLock](asynclock.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
