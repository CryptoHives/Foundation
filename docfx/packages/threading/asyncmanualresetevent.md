# AsyncManualResetEvent

## Overview

`AsyncManualResetEvent` is a pooled async version of `ManualResetEvent` that uses `ValueTask` to minimize memory allocations. It provides async signaling by reusing pooled `IValueTaskSource` instances. Unlike `AsyncAutoResetEvent`, it releases **all** waiting threads when signaled and remains signaled until explicitly reset.

## Namespace

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;
```

## Class Declaration

```csharp
public sealed class AsyncManualResetEvent
```

## Key Features

- **Broadcast signaling**: Releases **all** waiting threads when set
- **Persistent state**: Remains signaled until explicitly reset
- **ValueTask-based API**: Low-allocation async operations
- **Cancellation support**: Full `CancellationToken` support
- **Thread-safe**: All operations are thread-safe
- **Pooled task sources**: Reuses `IValueTaskSource` instances to minimize allocations

## Constructor

```csharp
public AsyncManualResetEvent(
    bool set = false, 
    bool runContinuationAsynchronously = true, 
    int defaultEventQueueSize = 0, 
    ObjectPool<PooledManualResetValueTaskSource<bool>>? pool = null)
```

### Parameters

- `set`: The initial state of the event (default: `false`)
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
- `InvalidOperationException` - If the awaiter was already called

**Important**: The returned `ValueTask` can only be awaited or converted to `Task` **once**. Additional attempts throw `InvalidOperationException`.

**Note**: Due to the implementation, every waiter needs a pooled `IValueTaskSource`. Hence all O(n) objects need to be signaled on `Set()` compared to a Task-based implementation which only signals a single Task shared with all waiters.

**Examples**:

```csharp
private readonly AsyncManualResetEvent _event = new();

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

Signals the event, releasing **all** waiting threads. The event remains in the signaled state until `Reset()` is called.

**Behavior**:
- All current waiters are released immediately
- All future `WaitAsync()` calls complete immediately until `Reset()` is called
- If already set, this method does nothing

### Reset

```csharp
public void Reset()
```

Resets the event to the non-signaled state.

**Behavior**:
- Future `WaitAsync()` calls will wait until `Set()` is called again

## Usage Examples

### Basic Initialization Signal

```csharp
private readonly AsyncManualResetEvent _initialized = new(false);

// Initialization thread
public async Task InitializeAsync()
{
    await PerformInitializationAsync();
    _initialized.Set(); // Release all waiting threads
}

// Worker threads
public async Task DoWorkAsync(CancellationToken ct)
{
    await _initialized.WaitAsync(ct); // Wait for initialization
    await ProcessAsync();
}
```

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

### Start/Stop Control

```csharp
private readonly AsyncManualResetEvent _running = new(false);

public void Start()
{
    _running.Set(); // Allow all workers to run
}

public void Stop()
{
    _running.Reset(); // Stop all workers
}

public async Task WorkerAsync(CancellationToken ct)
{
    while (!ct.IsCancellationRequested)
    {
        await _running.WaitAsync(ct); // Wait until started
        await DoWorkAsync();
    }
}
```

### Barrier for Multiple Tasks

```csharp
private readonly AsyncManualResetEvent _barrier = new(false);

public async Task CoordinatedWorkAsync(int workerId, CancellationToken ct)
{
    // Phase 1: Prepare
    await PrepareAsync(workerId);
    
    // Wait for all workers to finish Phase 1
    await _barrier.WaitAsync(ct);
    
    // Phase 2: Execute (after all workers are ready)
    await ExecuteAsync(workerId);
}

// Controller
public void ReleaseAllWorkers()
{
    _barrier.Set(); // Release all waiting workers at once
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

public async Task WaitForStartupAsync(CancellationToken ct = default)
{
    await _allServicesReady.WaitAsync(ct);
}
```

### Graceful Shutdown

```csharp
public class Service
{
    private readonly AsyncManualResetEvent _shutdownRequested = new(false);
    private readonly List<Task> _workers = new();

    public void Start(int workerCount)
    {
        for (int i = 0; i < workerCount; i++)
        {
            _workers.Add(WorkerLoopAsync(i, CancellationToken.None));
        }
    }

    private async Task WorkerLoopAsync(int id, CancellationToken ct)
    {
        while (true)
        {
            // Check if shutdown requested
            if (_shutdownRequested.IsSet)
            {
                break;
            }

            await ProcessWorkItemAsync(id, ct);
        }
    }

    public async Task ShutdownAsync()
    {
        _shutdownRequested.Set(); // Signal all workers to stop
        await Task.WhenAll(_workers); // Wait for all workers to complete
    }
}
```

## Thread Safety

✓ **Thread-safe**. All public methods are thread-safe and can be called concurrently.

## Performance Characteristics

- **Set()**: O(n) where n is the number of waiters (must signal all)
- **Reset()**: O(1) operation
- **WaitAsync()**: O(1) when signaled, otherwise enqueues waiter
- **Memory**: Allocates one `IValueTaskSource` per waiter (unlike Task-based implementations that share a single Task)

## Manual-Reset Behavior

The event remains in the signaled state after `Set()` until explicitly reset:

```csharp
var evt = new AsyncManualResetEvent(false);

// Signal the event
evt.Set();

// All current and future waiters complete immediately
await evt.WaitAsync(); // Completes immediately
await evt.WaitAsync(); // Completes immediately
await evt.WaitAsync(); // Completes immediately

// Reset the event
evt.Reset();

// Now future waiters must wait
await evt.WaitAsync(); // Blocks until next Set()
```

## Best Practices

### ✓ DO: Use for Initialization Signals

```csharp
// Good: Signal when service is ready
public class DataService
{
    private readonly AsyncManualResetEvent _ready = new(false);
    
    public async Task InitializeAsync()
    {
        await LoadDataAsync();
        _ready.Set(); // Release all waiting callers
    }
    
    public async Task<Data> GetDataAsync(CancellationToken ct)
    {
        await _ready.WaitAsync(ct); // Wait until initialized
        return GetData();
    }
}
```

### ✓ DO: Use for Broadcasting

```csharp
// Good: Release all waiting threads simultaneously
private readonly AsyncManualResetEvent _startSignal = new(false);

public async Task[] StartAllWorkersAsync(int count)
{
    var workers = new Task[count];
    for (int i = 0; i < count; i++)
    {
        workers[i] = WorkerAsync(i);
    }
    
    _startSignal.Set(); // Release all workers at once
    return workers;
}

private async Task WorkerAsync(int id)
{
    await _startSignal.WaitAsync(); // Wait for start signal
    await DoWorkAsync(id);
}
```

### ✓ DO: Reset After Broadcasting

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

### ✗ DON'T: Use for One-at-a-Time Signaling

```csharp
// Bad: Releases ALL waiters, not just one
var evt = new AsyncManualResetEvent(false);

var task1 = evt.WaitAsync();
var task2 = evt.WaitAsync();

evt.Set(); // Both tasks complete!

// Better: Use AsyncAutoResetEvent for one-at-a-time
```

### ✗ DON'T: Forget to Reset

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
    
    public async Task WaitForOpenAsync(CancellationToken ct = default)
    {
        await _open.WaitAsync(ct);
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
    
    public async Task WaitAsync(CancellationToken ct = default)
    {
        await _completed.WaitAsync(ct);
    }
}
```

### One-Time Initialization

```csharp
public class LazyAsyncService
{
    private readonly AsyncManualResetEvent _initialized = new(false);
    private Data? _data;
    
    public async Task InitializeAsync()
    {
        if (_initialized.IsSet)
        {
            return; // Already initialized
        }
        
        _data = await LoadDataAsync();
        _initialized.Set();
    }
    
    public async Task<Data> GetDataAsync(CancellationToken ct)
    {
        await _initialized.WaitAsync(ct);
        return _data!;
    }
}
```

### Pauseable Background Worker

```csharp
public class PauseableWorker
{
    private readonly AsyncManualResetEvent _resume = new(true);
    
    public void Pause()
    {
        _resume.Reset();
    }
    
    public void Resume()
    {
        _resume.Set();
    }
    
    public async Task WorkAsync(CancellationToken ct)
    {
        while (!ct.IsCancellationRequested)
        {
            await _resume.WaitAsync(ct); // Pause if reset
            await ProcessItemAsync();
        }
    }
}
```

### Multi-Phase Execution

```csharp
public class PhaseCoordinator
{
    private readonly AsyncManualResetEvent _phase1Complete = new(false);
    private readonly AsyncManualResetEvent _phase2Complete = new(false);
    
    public async Task Worker1Async()
    {
        await Phase1WorkAsync();
        _phase1Complete.Set();
        
        await _phase2Complete.WaitAsync();
        await Phase3WorkAsync();
    }
    
    public async Task Worker2Async()
    {
        await _phase1Complete.WaitAsync();
        await Phase2WorkAsync();
        _phase2Complete.Set();
    }
}
```

## Performance Considerations

**Trade-off**: `AsyncManualResetEvent` requires one `IValueTaskSource` per waiter, which means more overhead when many waiters are signaled compared to a Task-based implementation that can share a single `Task` instance. However, the pooling mechanism reduces allocations when waiters are released and the sources are returned to the pool.

**When to use**:
- When broadcasting to relatively few waiters
- When minimizing allocations is critical
- When waiters are short-lived
- When initialization signaling is needed

**When to avoid**:
- When broadcasting to hundreds or thousands of waiters
- When Task-based implementations provide better performance for your specific scenario

## Benchmarks

See [Benchmarks](benchmarks.md#asyncmanualresetevent-benchmarks) for detailed performance comparisons.

## See Also

- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [Benchmarks](benchmarks.md) - Detailed performance comparisons

---

© 2025 The Keepers of the CryptoHives
