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

## Constructors

| Constructor | Description |
|-------------|-------------|
| `AsyncLock()` | Creates a new async lock in the unlocked state |

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

- [AsyncAutoResetEvent](asyncautoresetevent.md)
- [AsyncManualResetEvent](asyncmanualresetevent.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
