# AsyncManualResetEvent Class

A pooled async manual-reset event for coordinating tasks where all waiters are released per signal.

## Namespace

```csharp
CryptoHives.Foundation.Threading.Async.Pooled
```

## Inheritance

`Object` ? **`AsyncManualResetEvent`**

## Implements

- `IDisposable`

## Syntax

```csharp
public sealed class AsyncManualResetEvent : IDisposable
```

## Overview

`AsyncManualResetEvent` is the async equivalent of `ManualResetEvent`. When signaled via `Set()`, it releases **all** waiting tasks and remains signaled until explicitly reset via `Reset()`. It uses pooled `IValueTaskSource` instances to minimize allocations, making it ideal for broadcast notifications and initialization scenarios.

## Benefits

- **Broadcast Signal**: `Set()` releases **all** waiters simultaneously
- **Persistent State**: Remains signaled until explicitly reset
- **Pooled Task Sources**: Minimal allocations through object pooling
- **ValueTask-Based**: Returns `ValueTask` for efficient async operations
- **Cancellation Support**: Supports `CancellationToken` for timeout and cancellation
- **State Query**: `IsSet` property to check current state

## Constructors

| Constructor | Description |
|-------------|-------------|
| `AsyncManualResetEvent(bool initialState)` | Creates an event in the specified initial state (true = signaled, false = non-signaled) |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `IsSet` | `bool` | Gets whether the event is currently in the signaled state |

## Methods

### Set

```csharp
public void Set()
```

Signals the event, releasing **all** waiting tasks. The event remains signaled until `Reset()` is called.

### Reset

```csharp
public void Reset()
```

Resets the event to the non-signaled state. New waiters will block until `Set()` is called again.

### WaitAsync

```csharp
public ValueTask WaitAsync(CancellationToken cancellationToken = default)
```

Asynchronously waits for the event to be signaled. Completes immediately if already signaled.
Due to the implementation of ValueTask, every waiter needs a pooled ValueTaskSource. Hence all O(n) objects need to be signaled on Set() compared to a Task based implementation which only signals a single Task shared with all waiters.

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

### Basic Broadcasting

```csharp
private readonly AsyncManualResetEvent _ready = new(false);

// Multiple waiters
var task1 = _ready.WaitAsync().AsTask();
var task2 = _ready.WaitAsync().AsTask();
var task3 = _ready.WaitAsync().AsTask();

// Signal all at once
_ready.Set();

// All tasks complete
await Task.WhenAll(task1, task2, task3);
```

### Lazy Initialization

```csharp
private readonly AsyncManualResetEvent _initialized = new(false);
private MyService? _service;

public async Task<MyService> GetServiceAsync()
{
    if (_service == null)
    {
        _service = await InitializeServiceAsync();
        _initialized.Set(); // Signal all waiters
    }
    else
    {
        await _initialized.WaitAsync(); // Wait if initialization in progress
    }
  
    return _service;
}
```

### Service Startup Coordination

```csharp
private readonly AsyncManualResetEvent _allServicesReady = new(false);

public async Task InitializeAsync()
{
    await Task.WhenAll(
        InitializeDatabaseAsync(),
        InitializeCacheAsync(),
        InitializeApiAsync()
    );
    
    _allServicesReady.Set(); // Signal all waiting services
}

public async Task WaitForStartupAsync()
{
    await _allServicesReady.WaitAsync();
}
```

## Thread Safety

? **Thread-safe**. All public methods are thread-safe and can be called concurrently.

## Performance Characteristics

- **Set()**: O(n) where n is number of waiters (releases all)
- **Reset()**: O(1)
- **WaitAsync()**: O(1) when signaled, otherwise enqueues waiter
- **Memory**: Minimal allocations due to pooled task sources

## Behavior

### Manual-Reset Behavior

Once set, the event remains signaled:

```csharp
var evt = new AsyncManualResetEvent(false);

// Set the event
evt.Set();

// Multiple waiters all complete immediately
await evt.WaitAsync(); // Completes
await evt.WaitAsync(); // Completes
await evt.WaitAsync(); // Completes

// Event still signaled - must manually reset
evt.Reset();

// Now waiters block again
await evt.WaitAsync(); // Blocks until next Set()
```

## Best Practices

### DO: Use for Broadcasting

```csharp
// Good: Signal multiple waiters
private readonly AsyncManualResetEvent _dataAvailable = new(false);

public void PublishData(Data data)
{
    _publishedData = data;
    _dataAvailable.Set(); // All subscribers notified
}

public async Task SubscribeAsync()
{
    await _dataAvailable.WaitAsync();
    ProcessData(_publishedData);
}
```

### DO: Use for Initialization

```csharp
// Good: Coordinate service startup
private readonly AsyncManualResetEvent _started = new(false);

public async Task StartAsync()
{
    await InitializeAsync();
    _started.Set(); // All waiting requests can proceed
}

public async Task HandleRequestAsync()
{
    await _started.WaitAsync(); // Wait for startup
    // Process request...
}
```

### DO: Reset After Broadcasting

```csharp
// Good: Reset for next batch
private readonly AsyncManualResetEvent _batchReady = new(false);

public async Task ProcessBatchAsync()
{
    while (true)
    {
        await _batchReady.WaitAsync();
  
        // Process batch
        ProcessCurrentBatch();

        // Reset for next batch
        _batchReady.Reset();
    }
}
```

### DON'T: Use for One-at-a-Time

```csharp
// Bad: All waiters get released
var evt = new AsyncManualResetEvent(false);

for (int i = 0; i < 10; i++)
{
    _ = ProcessItemAsync(evt); // All will run simultaneously!
}

evt.Set(); // Releases ALL 10 tasks at once

// Better: Use AsyncAutoResetEvent for one-at-a-time
```

### DON'T: Forget to Reset

```csharp
// Bad: Event stays signaled forever
public void SignalCompletion()
{
    _completionEvent.Set();
    // Forgot to reset! All future waiters complete immediately
}

// Good: Reset when appropriate
public async Task SignalAndResetAsync()
{
    _completionEvent.Set();
    await Task.Delay(100); // Let waiters proceed
    _completionEvent.Reset(); // Reset for next operation
}
```

## Common Patterns

### Barrier Pattern

```csharp
public class AsyncBarrier
{
    private readonly int _participantCount;
    private readonly AsyncManualResetEvent _barrierReached = new(false);
    private int _arrivedCount;
    
    public AsyncBarrier(int participantCount)
    {
        _participantCount = participantCount;
    }
    
    public async Task SignalAndWaitAsync()
    {
        int arrived = Interlocked.Increment(ref _arrivedCount);
        
        if (arrived == _participantCount)
        {
            _barrierReached.Set(); // Release all
        }
        else
        {
            await _barrierReached.WaitAsync();
        }
        
        // Reset when all have passed
        if (Interlocked.Decrement(ref _arrivedCount) == 0)
        {
            _barrierReached.Reset();
        }
    }
}
```

### Gate Pattern

```csharp
public class AsyncGate
{
    private readonly AsyncManualResetEvent _open = new(true);
    
    public void Open() => _open.Set();
    
    public void Close() => _open.Reset();
    
    public async Task WaitForOpenAsync()
    {
        await _open.WaitAsync();
    }
}

// Usage
var gate = new AsyncGate();

// Close gate
gate.Close();

// All workers wait
await gate.WaitForOpenAsync();

// Open gate - all proceed
gate.Open();
```

### Phased Execution

```csharp
private readonly AsyncManualResetEvent _phase1 = new(false);
private readonly AsyncManualResetEvent _phase2 = new(false);

public async Task ExecutePhase1Async()
{
    await DoWorkAsync();
    _phase1.Set();
}

public async Task ExecutePhase2Async()
{
    await _phase1.WaitAsync(); // Wait for phase 1
    await DoWorkAsync();
    _phase2.Set();
}

public async Task ExecutePhase3Async()
{
    await _phase2.WaitAsync(); // Wait for phase 2
    await DoWorkAsync();
}
```

### Countdown Event

```csharp
public class AsyncCountdownEvent
{
    private readonly AsyncManualResetEvent _completed = new(false);
    private int _count;
    
    public AsyncCountdownEvent(int initialCount)
    {
        _count = initialCount;
        if (_count == 0) _completed.Set();
    }
    
    public void Signal(int signalCount = 1)
    {
        if (Interlocked.Add(ref _count, -signalCount) == 0)
        {
            _completed.Set();
        }
    }
    
    public async Task WaitAsync()
    {
        await _completed.WaitAsync();
    }
}
```

## Comparison with Alternatives

| Feature | AsyncManualResetEvent | AsyncAutoResetEvent | ManualResetEventSlim |
|---------|----------------------|---------------------|---------------------|
| Waiters per signal | All | One | All |
| Auto-reset | ? No | ? Yes | ? No |
| Async support | ? Yes | ? Yes | ? No |
| Pooled allocations | ? Yes | ? Yes | N/A |
| ValueTask support | ? Yes | ? Yes | N/A |
| Use case | Broadcasting | Producer-consumer | Sync code only |

## Disposal

Always dispose when done:

```csharp
public class MyService : IDisposable
{
    private readonly AsyncManualResetEvent _event = new(false);
    
    public void Dispose()
    {
        _event?.Dispose();
    }
}
```

## See Also

- [AsyncAutoResetEvent](asyncautoresetevent.md)
- [AsyncLock](asynclock.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
