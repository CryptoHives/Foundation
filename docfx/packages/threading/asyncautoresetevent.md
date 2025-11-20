# AsyncAutoResetEvent Class

A pooled async auto-reset event for coordinating tasks where only one waiter is released per signal.

## Namespace

```csharp
CryptoHives.Foundation.Threading.Async.Pooled
```

## Inheritance

`Object` ? **`AsyncAutoResetEvent`**

## Implements

- `IDisposable`

## Syntax

```csharp
public sealed class AsyncAutoResetEvent : IDisposable
```

## Overview

`AsyncAutoResetEvent` is the async equivalent of `AutoResetEvent`. Each call to `Set()` releases exactly one waiting task. It uses pooled `IValueTaskSource` instances to minimize allocations, making it ideal for producer-consumer patterns and task coordination scenarios.

## Benefits

- **One-at-a-Time**: Each `Set()` releases exactly ONE waiter
- **Pooled Task Sources**: Minimal allocations through object pooling
- **ValueTask-Based**: Returns `ValueTask` for efficient async operations
- **Cancellation Support**: Supports `CancellationToken` for timeout and cancellation
- **High Performance**: Optimized for high-frequency signaling

## Constructors

| Constructor | Description |
|-------------|-------------|
| `AsyncAutoResetEvent(bool initialState)` | Creates an event in the specified initial state (true = signaled, false = non-signaled) |

## Methods

### Set

```csharp
public void Set()
```

Signals the event, releasing **one** waiting task. If no tasks are waiting, the next task to call `WaitAsync()` will complete immediately.

### WaitAsync

```csharp
public ValueTask WaitAsync(CancellationToken cancellationToken = default)
```

Asynchronously waits for the event to be signaled.

**Parameters**:
- `cancellationToken` - Optional cancellation token

**Returns**: A `ValueTask` that completes when the event is signaled.

**Throws**:
- `OperationCanceledException` - If the operation is canceled

### Dispose

```csharp
public void Dispose()
```

Releases all resources used by the event.

## Usage Examples

### Basic Producer-Consumer

```csharp
private readonly AsyncAutoResetEvent _itemAvailable = new(false);
private readonly Queue<string> _queue = new();

public void Produce(string item)
{
    _queue.Enqueue(item);
    _itemAvailable.Set(); // Release one consumer
}

public async Task<string> ConsumeAsync(CancellationToken ct = default)
{
    await _itemAvailable.WaitAsync(ct);
  return _queue.Dequeue();
}
```

### With Initial State

```csharp
// Start in signaled state - first waiter proceeds immediately
var readyEvent = new AsyncAutoResetEvent(initialState: true);

// Start in non-signaled state - waiters must wait for Set()
var workEvent = new AsyncAutoResetEvent(initialState: false);
```

### Sequential Task Execution

```csharp
private readonly AsyncAutoResetEvent _canProceed = new(true);

public async Task<T> ExecuteSequentiallyAsync<T>(Func<Task<T>> operation)
{
  await _canProceed.WaitAsync();
    
    try
    {
        return await operation();
    }
    finally
    {
        _canProceed.Set(); // Allow next task
    }
}
```

## Thread Safety

? **Thread-safe**. All public methods are thread-safe and can be called concurrently.

## Performance Characteristics

- **Set()**: O(1) to signal one waiter
- **WaitAsync()**: O(1) when signaled, otherwise enqueues waiter
- **Memory**: Minimal allocations due to pooled task sources

## Behavior

### Auto-Reset Behavior

After each `Set()` call:
1. If waiters exist: Release **one** waiter, event returns to non-signaled state
2. If no waiters: Event becomes signaled, next `WaitAsync()` completes immediately and resets

```csharp
var evt = new AsyncAutoResetEvent(false);

// No waiters
evt.Set(); // Event is now signaled

// Next wait completes immediately
await evt.WaitAsync(); // Completes synchronously, event resets

// Subsequent waits block
await evt.WaitAsync(); // Blocks until next Set()
```

## Best Practices

### ? DO: Use for Producer-Consumer

```csharp
// Good: One item per signal
public class WorkQueue<T>
{
    private readonly ConcurrentQueue<T> _items = new();
    private readonly AsyncAutoResetEvent _itemReady = new(false);
    
    public void Enqueue(T item)
    {
        _items.Enqueue(item);
        _itemReady.Set(); // Signal one consumer
    }
    
    public async Task<T> DequeueAsync(CancellationToken ct = default)
    {
        await _itemReady.WaitAsync(ct);
        _items.TryDequeue(out var item);
        return item;
    }
}
```

### DO: Use for Sequential Execution

```csharp
// Good: Ensure sequential execution
private readonly AsyncAutoResetEvent _gate = new(true);

public async Task ProcessAsync(Data data)
{
    await _gate.WaitAsync();
    try
    {
        await ProcessDataAsync(data);
    }
    finally
    {
        _gate.Set();
}
}
```

### DON'T: Use for Broadcasting

```csharp
// Bad: Only one waiter gets signaled
var evt = new AsyncAutoResetEvent(false);

// Multiple waiters
var task1 = evt.WaitAsync();
var task2 = evt.WaitAsync();
var task3 = evt.WaitAsync();

evt.Set(); // Only ONE task completes!

// Better: Use AsyncManualResetEvent for broadcasting
```

### DON'T: Signal More Times Than Needed

```csharp
// Bad: Extra signals are wasted if no waiters
for (int i = 0; i < 100; i++)
{
    evt.Set(); // If no waiters, this is wasted
}

// Better: Signal only when needed
if (hasWaiters)
{
    evt.Set();
}
```

## Common Patterns

### Throttling

```csharp
public class Throttler
{
    private readonly AsyncAutoResetEvent _throttle = new(true);
    private readonly Timer _timer;
    
    public Throttler(TimeSpan interval)
    {
        _timer = new Timer(_ => _throttle.Set(), null, interval, interval);
    }
    
    public async Task<T> ExecuteAsync<T>(Func<Task<T>> operation)
    {
        await _throttle.WaitAsync();
        return await operation();
    }
}
```

### Ping-Pong

```csharp
private readonly AsyncAutoResetEvent _ping = new(true);
private readonly AsyncAutoResetEvent _pong = new(false);

public async Task PingAsync()
{
    await _ping.WaitAsync();
    Console.WriteLine("Ping");
    _pong.Set();
}

public async Task PongAsync()
{
    await _pong.WaitAsync();
    Console.WriteLine("Pong");
    _ping.Set();
}
```

### Batch Processing

```csharp
public class BatchProcessor<T>
{
    private readonly List<T> _batch = new();
    private readonly AsyncAutoResetEvent _batchReady = new(false);
    private readonly int _batchSize;
    
    public void Add(T item)
    {
        lock (_batch)
        {
            _batch.Add(item);
            if (_batch.Count >= _batchSize)
            {
                _batchReady.Set();
            }
        }
    }
    
    public async Task<List<T>> GetBatchAsync()
    {
        await _batchReady.WaitAsync();
        
        lock (_batch)
        {
            var result = new List<T>(_batch);
            _batch.Clear();
            return result;
        }
    }
}
```

## Comparison with Alternatives

| Feature | AsyncAutoResetEvent | AsyncManualResetEvent | SemaphoreSlim(1) |
|---------|--------------------|-----------------------|------------------|
| Waiters per signal | One | All | One |
| Auto-reset | ? Yes | ? No | ? Yes |
| Pooled allocations | ? Yes | ? Yes | ? No |
| ValueTask support | ? Yes | ? Yes | ? No |
| Use case | Producer-consumer | Broadcasting | Limiting concurrency |

## Disposal

Always dispose when done:

```csharp
public class MyService : IDisposable
{
    private readonly AsyncAutoResetEvent _event = new(false);
    
    public void Dispose()
    {
        _event?.Dispose();
    }
}
```

## See Also

- [AsyncManualResetEvent](asyncmanualresetevent.md)
- [AsyncLock](asynclock.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
