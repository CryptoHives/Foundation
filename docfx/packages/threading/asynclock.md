# AsyncLock Class

A pooled async mutual exclusion lock for coordinating access to shared resources.

## Namespace

```csharp
CryptoHives.Foundation.Threading.Async.Pooled
```

## Syntax

```csharp
public sealed class AsyncLock : IResettable
```

## Overview

`AsyncLock` provides async mutual exclusion, similar to `SemaphoreSlim(1,1)` but optimized for the common async locking pattern. It returns a small value-type releaser that implements `IDisposable`/`IAsyncDisposable` so the lock can be released with a `using` pattern. The implementation uses pooled `IValueTaskSource` instances to minimize allocations in high-throughput scenarios and a local reusable waiter to avoid allocations for the first queued waiter.

## Benefits

- **Zero-allocation fast path**: When the lock is uncontended the operation completes synchronously without heap allocations.
- **Pooled Task Sources**: Reuses `IValueTaskSource<Releaser>` instances from an object pool when waiters are queued.
- **ValueTask-Based**: Returns `ValueTask<Releaser>` for minimal allocation when the lock is available.
- **RAII Pattern**: Uses disposable lock handles for automatic release.
- **Cancellation Support (optimized)**: Supports `CancellationToken` for queued waiters; on .NET 6+ registration uses `UnsafeRegister` with a static delegate to reduce execution-context capture and per-registration overhead.
- **High Performance**: Optimized for both uncontended and contended scenarios while keeping allocations low.

## Constructor

```csharp
public AsyncLock(
    IGetPooledManualResetValueTaskSource<Releaser>? pool = null)
```

| Parameter | Description |
|-----------|-------------|
| `pool` | Optional custom pool for ValueTaskSource instances. |

> **Note:** Unlike other primitives in this library, `AsyncLock` always runs continuations asynchronously (hardcoded to `true`). This prevents potential deadlocks in common lock usage patterns.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsTaken` | `bool` | Gets whether the lock is currently held by a caller or queued handoff. |

## Methods

### LockAsync

```csharp
public ValueTask<Releaser> LockAsync(CancellationToken cancellationToken = default)
```

Asynchronously acquires the lock. Returns a disposable that releases the lock when disposed.

**Parameters**:
- `cancellationToken` - Optional cancellation token; only observed if the lock cannot be acquired immediately.

**Returns**: A `ValueTask<Releaser>` that completes when the lock is acquired. Dispose the result to release the lock.

**Notes on allocations and cancellation**:
- The **fast path** (uncontended) completes synchronously and performs no heap allocations.
- The implementation maintains a **local waiter** instance that serves the first queued waiter without allocating. Subsequent waiters use instances obtained from the configured object pool; if the pool is exhausted a new instance is allocated.
- Passing a `CancellationToken` will register a callback when the waiter is queued. On .NET 6+ the code uses `UnsafeRegister` together with a static delegate and a small struct context to minimize capture and reduce allocation/ExecutionContext overhead. Even so, cancellation registrations and creating `Task` objects for pre-cancelled tokens may allocate; prefer avoiding cancellation tokens unless necessary for the scenario.

**Throws**:
- `OperationCanceledException` - If the operation is canceled via the cancellation token.

### LockAsync (timeout)

```csharp
public ValueTask<Releaser> LockAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
```

Asynchronously acquires the lock, or throws `OperationCanceledException` if the timeout elapses before the lock becomes available.

**Parameters**:
- `timeout` — The maximum time to wait. Pass `Timeout.InfiniteTimeSpan` to wait indefinitely (delegates to `LockAsync()` without allocating a `TimeProvider`).

**Returns**: A `ValueTask<Releaser>` that completes when the lock is acquired. Dispose the result to release the lock.

**Throws**:
- `OperationCanceledException` — If the timeout elapses before the lock can be acquired.
- `ArgumentOutOfRangeException` — If `timeout` is negative and not equal to `Timeout.InfiniteTimeSpan`.

**Allocation notes**:

| Scenario | TimeProvider allocated? |
|---|---|
| Lock immediately available | No |
| `Timeout.InfiniteTimeSpan` | No |
| `TimeSpan.Zero` and locked | No (immediate exception) |
| Finite positive timeout | Yes — one instance, disposed on await |

**Example**:

```csharp
try
{
    using (await _lock.LockAsync(TimeSpan.FromSeconds(2)))
    {
        await DoWorkAsync();
    }
}
catch (OperationCanceledException)
{
    // Could not acquire lock within 2 seconds
    HandleTimeout();
}
```

### Allocation Behavior

Immediate acquisitions are completely allocation-free using atomic operations. When the lock is contended, waiting without a timeout is allocation-free on .NET 6.0+ (using `UnsafeRegister` for cancellation), while older frameworks may allocate for cancellation registration. Specifying a finite timeout allocates a timer that is automatically disposed when the operation completes. Exception and task allocations occur only if a timeout actually elapses or cancellation is triggered; successful acquisitions are otherwise allocation-free. Pooled `IValueTaskSource<Releaser>` instances are reused to minimize allocation pressure across repeated lock operations.

```csharp
public bool TryReset()
```

Implements `IResettable` to allow returning this instance to a `DefaultObjectPool<AsyncLock>`.

**Behavior**:
- Attempts to acquire the internal spin lock. If the lock is already held by a concurrent operation, the method returns `false` immediately and the pool discards the instance.
- If the lock is acquired but the logical lock is currently held (`IsTaken == true`) or waiters are queued, the method returns `false` — the instance is still in active use and must not be recycled.
- Otherwise the local waiter is reset and the method returns `true`.

**Thread Safety**: `TryReset()` is safe to call concurrently with other operations. It will simply return `false` if the instance is in use.

**Example**:

```csharp
// Using AsyncLock with an object pool
var pool = new DefaultObjectPool<AsyncLock>(
    new DefaultPooledObjectPolicy<AsyncLock>());

var lk = pool.Get();
try
{
    using (await lk.LockAsync(ct))
    {
        // critical section
    }
}
finally
{
    pool.Return(lk); // calls TryReset() internally
}
```

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
- ProtoPromiseAsyncLock: The implementation from the Proto.Promises.Threading library
- RefImplAsyncLock: The reference implementation from Stephen Toub's blog, which does not support cancellation tokens
- NitoAsyncLock: The implementation from the Nito.AsyncEx library
- NeoSmartAsyncLock: The implementation from the NeoSmart.AsyncLock library
- AsyncNonKeyedLocker: An implementation from the AsyncKeyedLock.AsyncNonKeyedLocker library which uses SemaphoreSlim internally
- SemaphoreSlim: The .NET built-in synchronization primitive
- VS.Threading AsyncSemaphore: The Microsoft.VisualStudio.Threading semaphore used as a lock-compatible baseline

### Single Lock Benchmark

This benchmark measures the performance of acquiring and releasing a single lock in an uncontended scenario.
In order to understand the impact of moving from a `lock` or `Interlocked` implementation to an async lock, the `InterlockedIncrement`, `lock` and .NET 9 `Lock` with `EnterScope()` are also measured with a integer increment as workload.
The benchmark shows both throughput (operations per second) and allocations per operation. ProtoPromise is currently a strong uncontended competitor and can beat the pooled implementation on raw throughput, while the pooled implementation stays allocation-free and keeps the same API shape and cancellation behavior used throughout this library. VS.Threading is also included as a semaphore-based comparison point, but in the published uncontended results it trails both ProtoPromise and the pooled implementation.
The new .NET 9 `Lock` primitive shows slighlty better performance than the well known lock on an object, but `AsyncLock` remains competitive due to the fast path implementation with Interlocked variable based state.

[!INCLUDE[Single Lock Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asynclock-single.md)]

### Multiple Concurrent Lock Benchmark

This benchmark measures performance under contention with multiple concurrent lock requests (iterations).
The benchmark shows both throughput (operations per second) and allocations per operation. Zero iterations duplicates the uncontended scenario.
It is noticable that all implementations except the pooled one and ProtoPromise require memory allocations on contention, as long as the `ValueTask` is not converted to `Task`.
ProtoPromise is particularly competitive here and can outperform the pooled `AsyncLock` in several low- and mid-contention cases, especially when comparing pure throughput. The pooled implementation still distinguishes itself by combining allocation-free `ValueTask` usage with built-in cancellation support and predictable behavior when integrated with the rest of this library. VS.Threading is included as another real-world baseline, but its semaphore-based path is slower and allocates under contention in the published results.

[!INCLUDE[Multiple Lock Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asynclock-multiple.md)]

### Benchmark Analysis

**Key Findings:**

1. **Uncontended Performance**: `AsyncLock` performs comparably to or better than `SemaphoreSlim` in uncontended scenarios due to the optimized fast path that avoids allocations entirely.

2. **Memory Efficiency**: The pooled `IValueTaskSource` approach significantly reduces allocations compared to `TaskCompletionSource`-based implementations. This is especially beneficial in high-throughput scenarios.

3. **Contended Scenarios**: Under contention, the local waiter optimization ensures the first queued waiter incurs no allocation, while subsequent waiters benefit from pool reuse. ProtoPromise can outperform the pooled implementation in several published throughput measurements, while `SemaphoreSlim` is also competitive in some cases but always at the cost of allocations.

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

### DO: Use `LockAsync(TimeSpan)` to bound wait time

```csharp
try
{
    using (await _lock.LockAsync(TimeSpan.FromSeconds(5)))
    {
        _data = await FetchAsync();
    }
}
catch (OperationCanceledException)
{
    HandleTimeout();
}
```

### DON'T: Create new locks repeatedly

```csharp
// Bad: Creating new lock each time
public async Task OperationAsync()
{
    var lock = new AsyncLock(); // Don't do this!
    Task.Run(async ()=> await Work(lock));
    Task.Run(async ()=> await Work(lock));
}

public async Task Work(AsyncLock lock)
{
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
