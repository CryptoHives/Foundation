# AsyncAutoResetEvent

## Overview

`AsyncAutoResetEvent` is a pooled async version of `AutoResetEvent` that uses `ValueTask` to minimize memory allocations in high-throughput scenarios. It provides allocation-free async signaling by reusing pooled `IValueTaskSource` instances.

## Namespace

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;
```

## Class Declaration

```csharp
public sealed class AsyncAutoResetEvent
```

## Key Features

- **Zero-allocation waits**: Uses pooled `IValueTaskSource<bool>` instances
- **ValueTask-based API**: Low-allocation async operations
- **Cancellation support**: Full `CancellationToken` support
- **Thread-safe**: All operations are thread-safe
- **FIFO queue**: Waiters are released in first-in-first-out order

## Constructor

```csharp
public AsyncAutoResetEvent(
    bool initialState = false, 
    bool runContinuationAsynchronously = true, 
    int defaultEventQueueSize = 0, 
    ObjectPool<PooledManualResetValueTaskSource<bool>>? pool = null)
```

### Parameters

- `initialState`: The initial state of the event (default: `false`)
- `runContinuationAsynchronously`: Controls whether continuations are forced to run asynchronously (default: `true`)
- `defaultEventQueueSize`: The default waiter queue capacity (default: `8`)
- `pool`: Optional custom object pool for `IValueTaskSource` instances

## Properties

### IsSet

```csharp
public bool IsSet { get; }
```

Gets whether this event is currently in the signaled state.

### RunContinuationAsynchronously

```csharp
public bool RunContinuationAsynchronously { get; set; }
```

Controls how continuations are executed when the event is signaled:
- `true` (default): Continuations queue to the thread pool, preventing the signaling thread from being blocked
- `false`: Continuations may execute synchronously on the signaling thread

**Performance Warning**: When `true`, storing `AsTask()` results before signaling causes severe performance degradation (10x-100x slower).

## Methods

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

**Important**: The returned `ValueTask` can only be awaited or converted to `Task` **once**. Additional attempts throw `InvalidOperationException`.

**Examples**:

```csharp
private readonly AsyncAutoResetEvent _event = new();

// GOOD: Direct await
await _event.WaitAsync(cancellationToken);

// GOOD: Single AsTask() with multiple awaits
Task t = _event.WaitAsync().AsTask();
await t;
await t;  // OK - awaiting Task multiple times is fine

// BAD: Multiple ValueTask awaits
ValueTask vt = _event.WaitAsync();
await vt;
await vt;  // Throws InvalidOperationException!

// BAD: Storing AsTask() before Set() when RunContinuationAsynchronously=true
Task slow = _event.WaitAsync().AsTask();  // Stored before Set()
_event.Set();
await slow;  // 10x-100x slower!
```

### Set

```csharp
public void Set()
```

Signals the event, releasing **one** waiting thread. If no threads are waiting, the event enters the signaled state, allowing the next `WaitAsync()` call to complete immediately.

### SetAll

```csharp
public void SetAll()
```

Signals all currently waiting threads. If no threads are waiting, the event enters the signaled state.

**Note**: Unlike `Set()`, this releases all queued waiters instead of just one.

## Usage Examples

### Basic Producer-Consumer

```csharp
private readonly AsyncAutoResetEvent _itemAvailable = new(false);
private readonly Queue<WorkItem> _queue = new();
private readonly object _queueLock = new();

// Producer
public void Produce(WorkItem item)
{
    lock (_queueLock)
    {
        _queue.Enqueue(item);
    }
    _itemAvailable.Set(); // Release one consumer
}

// Consumer
public async Task<WorkItem> ConsumeAsync(CancellationToken ct)
{
    await _itemAvailable.WaitAsync(ct);
    
    lock (_queueLock)
    {
        return _queue.Dequeue();
    }
}
```

### Task Coordination

```csharp
private readonly AsyncAutoResetEvent _signal = new();

// Worker 1
public async Task Worker1Async()
{
    await DoWork1();
    _signal.Set();  // Signal Worker 2
}

// Worker 2
public async Task Worker2Async(CancellationToken ct)
{
    await _signal.WaitAsync(ct);  // Wait for Worker 1
    await DoWork2();
}
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

### Throttled Processing

```csharp
private readonly AsyncAutoResetEvent _throttle = new(initialState: true);

public async Task ProcessAsync(CancellationToken ct)
{
    await _throttle.WaitAsync(ct);
    
    try
    {
        await PerformOperationAsync();
    }
    finally
    {
        await Task.Delay(100);  // Throttle delay
        _throttle.Set();
    }
}
```

## Thread Safety

✓ **Thread-safe**. All public methods are thread-safe and can be called concurrently.

## Performance Characteristics

- **Set()**: O(1) operation
- **SetAll()**: O(n) for n waiters
- **WaitAsync()**: O(1) when signaled, otherwise enqueues waiter
- **Memory**: Zero allocations when waiters can be satisfied from pool

## Auto-Reset Behavior

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

### ✓ DO: Use for Producer-Consumer

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

### ✓ DO: Always Await ValueTask

```csharp
// Good: Direct await
await _event.WaitAsync();

// Good: Immediate AsTask()
await _event.WaitAsync().AsTask();
```

### ✓ DO: Use Cancellation Tokens

```csharp
// Good: Support cancellation
await _event.WaitAsync(cancellationToken);
```

### ✗ DON'T: Use for Broadcasting

```csharp
// Bad: Only one waiter gets signaled
var evt = new AsyncAutoResetEvent(false);

// Multiple waiters
var task1 = evt.WaitAsync();
var task2 = evt.WaitAsync();
var task3 = evt.WaitAsync();

evt.Set(); // Only ONE task completes!

// Better: Use SetAll() to release all waiters
evt.SetAll(); // All tasks complete

// Or use AsyncManualResetEvent for broadcasting
```

### ✗ DON'T: Store AsTask() Before Signaling

```csharp
// Bad: Causes 10x-100x performance degradation
Task t = _event.WaitAsync().AsTask();
_event.Set();
await t;  // Much slower!

// Good: Await directly or AsTask() after Set()
await _event.WaitAsync();
```

### ✗ DON'T: Await ValueTask Multiple Times

```csharp
// Bad: Throws InvalidOperationException
ValueTask vt = _event.WaitAsync();
await vt;
await vt;  // Exception!

// Good: Convert to Task for multiple awaits
Task t = _event.WaitAsync().AsTask();
await t;
await t;  // OK
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
    
    public async Task<T> ExecuteAsync<T>(Func<Task<T>> operation, CancellationToken ct = default)
    {
        await _throttle.WaitAsync(ct);
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
    
    public async Task<List<T>> GetBatchAsync(CancellationToken ct = default)
    {
        await _batchReady.WaitAsync(ct);
        
        lock (_batch)
        {
            var result = new List<T>(_batch);
            _batch.Clear();
            return result;
        }
    }
}
```

## Benchmarks

See [Benchmarks](benchmarks.md#asyncautoresetevent-benchmarks) for detailed performance comparisons.

### Quick Summary (on .NET 10.0)

- **Set**: ~4 ns (no allocations)
- **WaitAsync (signaled)**: ~11 ns (no allocations)
- **WaitAsync (not signaled, no contention)**: ~25-31 ns (no allocations without cancellation token)
- **Under contention (100 iterations)**: ~3,300 ns vs ~2,900 ns (RefImpl) with ~6KB vs ~9.6KB allocations

## See Also

- [AsyncManualResetEvent](asyncmanualresetevent.md) - Manual-reset event variant
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [Benchmarks](benchmarks.md) - Detailed performance comparisons

---

© 2025 The Keepers of the CryptoHives
