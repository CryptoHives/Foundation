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
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

| Parameter | Description |
|-----------|-------------|
| `initialCount` | The initial number of available permits. Must be non-negative. |
| `runContinuationAsynchronously` | If true (default), continuations run on the thread pool. |
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

## Benchmark Results

The following benchmarks compare `AsyncSemaphore` against `SemaphoreSlim`, `Nito.AsyncEx.AsyncSemaphore` and a Task based reference implementation.
TODO: Currently benchmarks are only available on uncontended scenarios to measure the overhead of a semaphore acquisition and release.

### Single Wait/Release Benchmark

Measures the performance of acquiring and releasing a single permit.

[!INCLUDE[Semaphore Benchmark](benchmarks/asyncsemaphore-single.md)]

### Benchmark Analysis

**Key Findings:**

1. **Fast Path Performance**: When permits are available, `AsyncSemaphore` completes synchronously with zero allocations, providing excellent performance for uncontended scenarios.

2. **Contention Handling**: Under contention, the pooled `IValueTaskSource` approach reduces allocation pressure compared to `SemaphoreSlim.WaitAsync()`.

3. **Memory Efficiency**: The local waiter optimization ensures the first queued waiter incurs no allocation, with subsequent waiters benefiting from pool reuse.

4. **ValueTask Advantage**: Returning `ValueTask` instead of `Task` avoids allocations when permits are immediately available.

**When to Choose AsyncSemaphore:**

- Rate limiting scenarios with frequent permit acquisition
- Connection pooling where semaphore operations are hot paths
- High-throughput scenarios where allocation pressure matters

**Comparison with SemaphoreSlim:**

`SemaphoreSlim` is a mature, well-tested synchronization primitive in the .NET BCL. Choose `AsyncSemaphore` when:
- You need lower allocation overhead in high-frequency scenarios
- Your application is allocation-sensitive
- You want consistent `ValueTask`-based APIs across your codebase

## Comparison with SemaphoreSlim

| Feature | AsyncSemaphore | SemaphoreSlim |
|---------|----------------|---------------|
| Allocation overhead | Minimal (pooled) | Higher (per wait) |
| ValueTask support | Native | Via WaitAsync |
| Cancellation | Full support | Full support |
| Performance | Optimized | Standard |

## See Also

- [Threading Package Overview](index.md)
- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncManualResetEvent](asyncmanualresetevent.md) - Manual-reset event variant
- [AsyncReaderWriterLock](asyncreaderwriterlock.md) - Async reader-writer lock
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [AsyncCountdownEvent](asynccountdownevent.md) - Async countdown event
- [AsyncBarrier](asyncbarrier.md) - Async barrier synchronization primitive
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
