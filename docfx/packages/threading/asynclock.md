# AsyncLock Class

A pooled async mutual exclusion lock for coordinating access to shared resources.

## Namespace

```csharp
CryptoHives.Foundation.Threading.Async.Pooled
```

## Inheritance

`Object` ? **`AsyncLock`**

## Implements

- `IDisposable`

## Syntax

```csharp
public sealed class AsyncLock : IDisposable
```

## Overview

`AsyncLock` provides async mutual exclusion, similar to `SemaphoreSlim(1,1)` but optimized for the common async locking pattern. It uses pooled `IValueTaskSource` instances to minimize allocations in high-throughput scenarios, making it suitable for hot-path code that requires thread-safe access to shared resources.

## Benefits

- **Pooled Task Sources**: Reuses `IValueTaskSource<IDisposable>` instances from object pool
- **ValueTask-Based**: Returns `ValueTask<IDisposable>` for minimal allocation when lock is available
- **RAII Pattern**: Uses disposable lock handles for automatic release
- **Cancellation Support**: Supports `CancellationToken` for timeout and cancellation
- **High Performance**: Optimized for low contention scenarios

## Constructors

| Constructor | Description |
|-------------|-------------|
| `AsyncLock()` | Creates a new async lock in the unlocked state |

## Methods

### LockAsync

```csharp
public ValueTask<IDisposable> LockAsync(CancellationToken cancellationToken = default)
```

Asynchronously acquires the lock. Returns a disposable that releases the lock when disposed.

**Parameters**:
- `cancellationToken` - Optional cancellation token

**Returns**: A `ValueTask<IDisposable>` that completes when the lock is acquired. Dispose the result to release the lock.

**Throws**:
- `OperationCanceledException` - If the operation is canceled via the cancellation token

### Dispose

```csharp
public void Dispose()
```

Releases all resources used by the lock. Should be called when the lock is no longer needed.

## Usage Examples

### Basic Usage

```csharp
private readonly AsyncLock _lock = new();

public async Task AccessSharedResourceAsync()
{
    using (await _lock.LockAsync())
    {
        // Critical section - only one task at a time
  await ModifySharedStateAsync();
    }
}
```

### With Cancellation

```csharp
private readonly AsyncLock _lock = new();

public async Task AccessWithTimeoutAsync(CancellationToken ct)
{
    using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
  cts.CancelAfter(TimeSpan.FromSeconds(5));
  
try
    {
using (await _lock.LockAsync(cts.Token))
        {
   await DoWorkAsync(ct);
        }
    }
    catch (OperationCanceledException)
    {
        // Timeout or cancellation
    }
}
```

### Protecting Shared State

```csharp
public class SafeCounter
{
    private readonly AsyncLock _lock = new();
    private int _value;
    
    public async Task<int> IncrementAsync()
    {
    using (await _lock.LockAsync())
   {
    await Task.Delay(10); // Simulate async work
         return ++_value;
      }
    }
 
 public async Task<int> GetValueAsync()
    {
using (await _lock.LockAsync())
        {
return _value;
  }
    }
}
```

## Thread Safety

? **Thread-safe**. All public methods are thread-safe and can be called concurrently from multiple threads.

## Performance Characteristics

- **Uncontended Lock**: O(1), synchronous completion (no allocation)
- **Contended Lock**: O(1) to enqueue waiter
- **Lock Release**: O(1) to signal next waiter
- **Memory**: Minimal allocations due to pooled task sources

## Best Practices

### ? DO: Reuse Lock Instances

```csharp
// Good: Reuse the same lock instance
public class MyService
{
    private readonly AsyncLock _lock = new();
    
    public async Task Operation1Async()
    {
        using (await _lock.LockAsync())
  {
      // Work...
        }
    }
    
    public async Task Operation2Async()
    {
   using (await _lock.LockAsync())
        {
         // Work...
      }
    }
}
```

### ? DO: Use CancellationToken

```csharp
// Good: Support cancellation
public async Task ProcessAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct))
    {
      await DoWorkAsync(ct);
    }
}
```

### ? DO: Keep Critical Sections Short

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

### ? DON'T: Create New Locks Repeatedly

```csharp
// Bad: Creating new lock each time
public async Task OperationAsync()
{
    using var lock = new AsyncLock(); // Don't do this!
    using (await lock.LockAsync())
    {
// Work...
    }
}
```

### ? DON'T: Hold Lock During Long Operations

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
 var result = await SlowApiCallAsync();
    
    using (await _lock.LockAsync())
    {
 // Only critical update
        _cache = result;
    }
}
```

### ? DON'T: Nest Locks (Deadlock Risk)

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

## Common Patterns

### Thread-Safe Dictionary

```csharp
public class SafeDictionary<TKey, TValue> where TKey : notnull
{
    private readonly AsyncLock _lock = new();
 private readonly Dictionary<TKey, TValue> _dict = new();
  
    public async Task<TValue?> GetAsync(TKey key, CancellationToken ct = default)
    {
      using (await _lock.LockAsync(ct))
        {
            return _dict.TryGetValue(key, out var value) ? value : default;
 }
    }
    
    public async Task SetAsync(TKey key, TValue value, CancellationToken ct = default)
    {
  using (await _lock.LockAsync(ct))
        {
            _dict[key] = value;
        }
 }
}
```

### Lazy Async Initialization

```csharp
public class LazyAsync<T>
{
    private readonly AsyncLock _lock = new();
    private readonly Func<Task<T>> _factory;
    private T? _value;
    private bool _initialized;
    
    public LazyAsync(Func<Task<T>> factory) => _factory = factory;
    
    public async Task<T> GetValueAsync(CancellationToken ct = default)
    {
        if (_initialized) return _value!;
        
        using (await _lock.LockAsync(ct))
{
            if (!_initialized)
      {
    _value = await _factory();
             _initialized = true;
         }
     }
        
        return _value!;
    }
}
```

## Comparison with Alternatives

| Feature | AsyncLock | SemaphoreSlim(1,1) | lock() |
|---------|-----------|-------------------|--------|
| Async support | ? Yes | ? Yes | ? No |
| ValueTask support | ? Yes | ? No (Task only) | N/A |
| Pooled allocations | ? Yes | ? No | N/A |
| Cancellation | ? Yes | ? Yes | ? No |
| Overhead | Low | Medium | Lowest (sync only) |
| Use case | Async hot paths | General async | Sync code only |

## Disposal

Always dispose `AsyncLock` when done:

```csharp
public class MyService : IDisposable
{
    private readonly AsyncLock _lock = new();
    
    public void Dispose()
    {
        _lock?.Dispose();
    }
}
```

## See Also

- [AsyncAutoResetEvent](asyncautoresetevent.md)
- [AsyncManualResetEvent](asyncmanualresetevent.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
