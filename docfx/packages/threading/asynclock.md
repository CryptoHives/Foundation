# AsyncLock Class

A pooled async mutual exclusion lock for coordinating access to shared resources.

## Namespace

```csharp
CryptoHives.Foundation.Threading.Async.Pooled
```

## Syntax

```csharp
public sealed class AsyncLock
```

## Overview

`AsyncLock` provides async mutual exclusion, similar to `SemaphoreSlim(1,1)` but optimized for the common async locking pattern. It returns a small value-type releaser that implements `IDisposable`/`IAsyncDisposable` so the lock can be released with a `using` pattern. The implementation uses pooled `IValueTaskSource` instances to minimize allocations in high-throughput scenarios and a local reusable waiter to avoid allocations for the first queued waiter.

## Benefits

- **Zero-allocation fast path**: When the lock is uncontended the operation completes synchronously without heap allocations.
- **Pooled Task Sources**: Reuses `IValueTaskSource<AsyncLockReleaser>` instances from an object pool when waiters are queued.
- **ValueTask-Based**: Returns `ValueTask<AsyncLockReleaser>` for minimal allocation when the lock is available.
- **RAII Pattern**: Uses disposable lock handles for automatic release.
- **Cancellation Support (optimized)**: Supports `CancellationToken` for queued waiters; on .NET 6+ registration uses `UnsafeRegister` with a static delegate to reduce execution-context capture and per-registration overhead.
- **High Performance**: Optimized for both uncontended and contended scenarios while keeping allocations low.

## Constructor

```csharp
public AsyncLock(
    int defaultEventQueueSize = 0,
    IGetPooledManualResetValueTaskSource<Releaser>? pool = null)
```

| Parameter | Description |
|-----------|-------------|
| `defaultEventQueueSize` | Initial capacity for the waiter queue. Defaults to an internal value when 0. |
| `pool` | Optional custom pool for ValueTaskSource instances. |

> **Note:** Unlike other primitives in this library, `AsyncLock` always runs continuations asynchronously (hardcoded to `true`). This prevents potential deadlocks in common lock usage patterns.

## Methods

### LockAsync

```csharp
public ValueTask<AsyncLockReleaser> LockAsync(CancellationToken cancellationToken = default)
```

Asynchronously acquires the lock. Returns a disposable that releases the lock when disposed.

**Parameters**:
- `cancellationToken` - Optional cancellation token; only observed if the lock cannot be acquired immediately.

**Returns**: A `ValueTask<AsyncLockReleaser>` that completes when the lock is acquired. Dispose the result to release the lock.

**Notes on allocations and cancellation**:
- The **fast path** (uncontended) completes synchronously and performs no heap allocations.
- The implementation maintains a **local waiter** instance that serves the first queued waiter without allocating. Subsequent waiters use instances obtained from the configured object pool; if the pool is exhausted a new instance is allocated.
- Passing a `CancellationToken` will register a callback when the waiter is queued. On .NET 6+ the code uses `UnsafeRegister` together with a static delegate and a small struct context to minimize capture and reduce allocation/ExecutionContext overhead. Even so, cancellation registrations and creating `Task` objects for pre-cancelled tokens may allocate; prefer avoiding cancellation tokens unless necessary for the scenario.

**Throws**:
- `OperationCanceledException` - If the operation is canceled via the cancellation token.

## Thread Safety

**Thread-safe**. All public methods are thread-safe and can be called concurrently from multiple threads.

## Performance Characteristics

- **Uncontended Lock**: O(1), synchronous completion (no allocation)
- **Contended Lock**: O(1) to enqueue waiter; waiter instances are reused from the object pool (allocation only if pool is exhausted)
- **Lock Release**: O(1) to signal next waiter
- **Memory**: Minimal allocations due to pooled task sources and local waiter reuse

## Benchmark Results

The benchmarks compare various `AsyncLock` implementations:

- PooledAsyncLock: The pooled implementation from this library
- RefImplAsyncLock: The reference implementation from Stephen Toub's blog, which does not support cancellation tokens
- NitoAsyncLock: The implementation from the Nito.AsyncEx library
- NeoSmartAsyncLock: The implementation from the NeoSmart.AsyncLock library
- AsyncNonKeyedLocker: An implementation from the AsyncKeyedLock.AsyncNonKeyedLocker library which uses SemaphoreSlim internally
- SemaphoreSlim: The .NET built-in synchronization primitive

### Single Lock Benchmark

This benchmark measures the performance of acquiring and releasing a single lock in an uncontended scenario.
In order to understand the impact of moving from a `lock` or `Interlocked` implementation to an async lock, the `InterlockedIncrement`, `lock` and .NET 9 `Lock` with `EnterScope()` are also measured with a integer increment as workload.
The benchmark shows both throughput (operations per second) and allocations per operation.
The new .NET 9 `Lock` primitive shows slighlty better performance than the well known lock on an object, but `AsyncLock` remains competitive due to the fast path implementation with Interlocked variable based state.

[!INCLUDE[Single Lock Benchmark](benchmarks/asynclock-single.md)]

### Multiple Concurrent Lock Benchmark

This benchmark measures performance under contention with multiple concurrent lock requests (iterations).
The benchmark shows both throughput (operations per second) and allocations per operation. Zero iterations duplicates the uncontended scenario.
It is noticable that all implementations except the pooled one require memory allocations on contention, as long as the ValueTask is not converted to Task.
The only implementation that slightly outperforms the pooled `AsyncLock` with a default cancellation token is the `SemaphoreSlim`, but at the cost of memory allocations on every lock acquisition.

[!INCLUDE[Multiple Lock Benchmark](benchmarks/asynclock-multiple.md)]

### Benchmark Analysis

**Key Findings:**

1. **Uncontended Performance**: `AsyncLock` performs comparably to or better than `SemaphoreSlim` in uncontended scenarios due to the optimized fast path that avoids allocations entirely.

2. **Memory Efficiency**: The pooled `IValueTaskSource` approach significantly reduces allocations compared to `TaskCompletionSource`-based implementations. This is especially beneficial in high-throughput scenarios.

3. **Contended Scenarios**: Under contention, the local waiter optimization ensures the first queued waiter incurs no allocation, while subsequent waiters benefit from pool reuse. Only `SemaphoreSlim` slightly outperforms in throughput with a non cancellable token but always at the cost of allocations.

4. **ValueTask Advantage**: Returning `ValueTask<Releaser>` instead of `Task` allows always allocation free completion.

**When to Choose AsyncLock:**

- High-throughput scenarios where lock acquisition is frequent
- Memory-sensitive applications where allocation pressure matters
- Scenarios where locks are typically contended or allocation free cancellation support is needed

## Best Practices

### DO: Use the using pattern to ensure lock release and await the result directly

```csharp
// Good: Minimal time holding lock
public async Task UpdateAsync(Data newData)
{
    // Prepare outside lock
    var processed = await PrepareDataAsync(newData);

    // using ensures lock is released
    using (await _lock.LockAsync())
    {
        _data = processed;
    }
}
```

### DO: Keep critical sections short

```csharp
// Good: Minimal time holding lock
using (await _lock.LockAsync())
{
    _data = processed;
}
```

### DO: Prefer avoiding CancellationToken for hot-path locks

Cancellation registrations allocate a small control structure. For hot-path code, omit the token when possible, or perform an early `cancellationToken.IsCancellationRequested` check before calling `LockAsync` to avoid allocations from `Task.FromCanceled`.

### DO: Configure a larger pool under high contention

If you expect many concurrent waiters, provide a custom object pool with a larger retention size so allocations are avoided when the pool can satisfy requests.

### DON'T: Create new locks repeatedly

```csharp
// Bad: Creating new lock each time
public async Task OperationAsync()
{
    var lock = new AsyncLock(); // Don't do this!
    using (await lock.LockAsync())
    {
        // Work...
    }
}
```

### DON'T: Hold the lock during long-running operations

```csharp
// Bad: Holding lock during slow operation
using (await _lock.LockAsync())
{
    await SlowDatabaseQueryAsync(); // Don't hold lock!
}
```

### DON'T: Nest locks (may deadlock)

```csharp
// Bad: Risk of deadlock
using (await _lock1.LockAsync())
{
    using (await _lock2.LockAsync()) // Deadlock risk!
    {
        // Work...
    }
}
```

## See Also

- [Threading Package Overview](index.md)
- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncManualResetEvent](asyncmanualresetevent.md) - Manual-reset event variant
- [AsyncReaderWriterLock](asyncreaderwriterlock.md) - Async reader-writer lock
- [AsyncCountdownEvent](asynccountdownevent.md) - Async countdown event
- [AsyncBarrier](asyncbarrier.md) - Async barrier synchronization primitive
- [AsyncSemaphore](asyncsemaphore.md) - Async semaphore primitive
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
