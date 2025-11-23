# AsyncLock Class

A pooled async mutual exclusion lock for coordinating access to shared resources.

## Namespace

```csharp
CryptoHives.Foundation.Threading.Async.Pooled
```

## Inheritance

`Object` ? **`AsyncLock`**

## Syntax

```csharp
public sealed class AsyncLock
```

## Overview

`AsyncLock` provides async mutual exclusion, similar to `SemaphoreSlim(1,1)` but optimized for the common async locking pattern. Takes advantage of `IDisposable` implemented in the `AsyncLockReleaser` to release the lock after use. It uses pooled `IValueTaskSource` instances to minimize allocations in high-throughput scenarios, making it suitable for hot-path code that requires thread-safe access to shared resources.

## Benefits

- **Pooled Task Sources**: Reuses `IValueTaskSource<AsyncLockReleaser>` instances from object pool
- **ValueTask-Based**: Returns `ValueTask<AsyncLockReleaser>` for minimal allocation when lock is available
- **RAII Pattern**: Uses disposable lock handles for automatic release
- **Cancellation Support**: (planned) Supports `CancellationToken` for timeout and cancellation
- **High Performance**: Optimized for high and low contention scenarios

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
- `cancellationToken` - Optional cancellation token

**Returns**: A `ValueTask<AsyncLockReleaser>` that completes when the lock is acquired. Dispose the result to release the lock.

**Throws**:
- `OperationCanceledException` - If the operation is canceled via the cancellation token

## Thread Safety

**Thread-safe**. All public methods are thread-safe and can be called concurrently from multiple threads.

## Performance Characteristics

- **Uncontended Lock**: O(1), synchronous completion (no allocation)
- **Contended Lock**: O(1) to enqueue waiter allocated from the ObjectPool, allocation only if ObjectPool is exhausted
- **Lock Release**: O(1) to signal next waiter
- **Memory**: Minimal allocations due to pooled task sources

## Best Practices

### DO: Use using pattern to ensure lock release, await result directly

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

### DO: Keep Critical Sections Short

```csharp
// Good: Minimal time holding lock
public async Task UpdateAsync(Data newData)
{
    // Prepare outside lock
    var processed = await PrepareDataAsync(newData);
    
    // Only critical update inside lock
    using (await _lock.LockAsync())
    {
        _data = processed;
    }
}
```

### DON'T: Create New Locks Repeatedly

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

### DON'T: Hold Lock During Long Operations

```csharp
// Bad: Holding lock during slow operation
public async Task ProcessAsync()
{
    using (await _lock.LockAsync())
    {
        await SlowDatabaseQueryAsync(); // Don't hold lock!
        await SlowApiCallAsync(); // Don't hold lock!
    }
}

// Good: Minimize lock duration
public async Task ProcessAsync()
{
    var data = await SlowDatabaseQueryAsync();
    var result = SlowApiCallAsync();
    
    using (await _lock.LockAsync())
    {
        // Only critical update
        _cache = await result;
    }
}
```

### DON'T: Nest Locks (may deadlock)

```csharp
// Bad: Risk of deadlock
using (await _lock1.LockAsync())
{
    using (await _lock2.LockAsync()) // Deadlock risk!
    {
        // Work...
    }
}

// Better: Use single lock or careful ordering
```

## See Also

- [AsyncAutoResetEvent](asyncautoresetevent.md)
- [AsyncManualResetEvent](asyncmanualresetevent.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
