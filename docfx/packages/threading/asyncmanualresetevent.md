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
- **Cancellation support**: Full `CancellationToken` support for queued waiters
- **Thread-safe**: All operations are thread-safe
- **Pooled task sources**: Reuses `IValueTaskSource` instances to minimize allocations

## Constructor

```csharp
public AsyncManualResetEvent(
    bool set = false, 
    bool runContinuationAsynchronously = true, 
    int defaultEventQueueSize = 0, 
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

### Parameters

- `set`: The initial state of the event (default: `false`).
- `runContinuationAsynchronously`: Controls whether continuations are forced to run asynchronously (default: `true`).
- `defaultEventQueueSize`: The default waiter queue capacity (when `0` the implementation uses an internal default, typically `8`).
- `pool`: Optional custom source provider implementing `IGetPooledManualResetValueTaskSource<bool>` which supplies pooled `PooledManualResetValueTaskSource<bool>` instances (helps avoid allocations under contention). You may pass a `ValueTaskSourceObjectPool<bool>` or a custom provider that implements the interface.

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
- `true` (default): Continuations are queued to the thread pool, preventing the signaling thread from being blocked.
- `false`: Continuations may execute synchronously on the signaling thread.

**Performance Warning**: When `true`, converting returned `ValueTask` instances to `Task` via `AsTask()` before signaling may force asynchronous completion paths and cause severe performance degradation (often 10x-100x slower).

> Note: The implementation exposes an internal property `InternalWaiterInUse` used by tests to detect whether the fast-path local waiter is currently held. This is not part of the public API surface for consumers.

## Methods

### WaitAsync

```csharp
public ValueTask WaitAsync(CancellationToken cancellationToken = default)
```

Asynchronously waits for the event to be signaled.

**Behavior**:
- If the event is signaled the call returns a completed `ValueTask` (synchronous, zero-allocation).
- Otherwise the call enqueues a pooled waiter and returns a `ValueTask` that completes when `Set()` is called.

**Parameters**:
- `cancellationToken` - Optional cancellation token. If the token is already cancelled, the method returns a canceled `ValueTask`. When a waiter is queued, the token is registered and a later cancellation will complete that waiter with an `OperationCanceledException` and remove it from the internal queue.

**Returns**: A `ValueTask` that completes when the event is signaled.

**Throws**:
- `OperationCanceledException` - If the operation is canceled via the cancellation token while queued
- `InvalidOperationException` - If a returned `ValueTask` instance is awaited more than once (ValueTask usage restriction)

**Important**: The returned `ValueTask` can only be awaited or converted to `Task` **once**. Additional attempts throw `InvalidOperationException`.

**Examples**:

```csharp
// Direct await (recommended)
await _event.WaitAsync(ct);

// Single AsTask() with multiple awaits (allowed for Task)
Task t = _event.WaitAsync().AsTask();
await t;
await t;  // OK - Task may be awaited multiple times

// BAD: Multiple ValueTask awaits
ValueTask vt = _event.WaitAsync();
await vt;
await vt;  // Throws InvalidOperationException!
```

### Set

```csharp
public void Set()
```

Signals the event, releasing **all** waiting threads. The event remains in the signaled state until `Reset()` is called.

**Behavior**:
- All current waiters are released immediately.
- All future `WaitAsync()` calls complete immediately until `Reset()` is called.
- When `RunContinuationAsynchronously` is `false`, continuations may run synchronously on the signaling thread.

### Reset

```csharp
public void Reset()
```

Resets the event to the non-signaled state.

**Behavior**:
- Future `WaitAsync()` calls will wait until `Set()` is called again.

## Cancellation Notes

- Cancellation is supported for queued waiters. The token is only registered when the waiter is enqueued (fast-path avoids registration). When cancelled, the waiter completes with an `OperationCanceledException` and is removed from the internal queue.
- Avoid passing cancellation tokens for hot-path uncontended waits to minimize allocation overhead from token registration. If a token is already canceled before calling `WaitAsync`, the method returns a canceled `ValueTask` (which may allocate a `Task` wrapper on some frameworks).

## Thread Safety

✓ **Thread-safe**. All public methods are thread-safe and can be called concurrently.

## Performance Characteristics

- **Set()**: O(n) where n is the number of waiters (must signal all)
- **Reset()**: O(1) operation
- **WaitAsync()**: O(1) when signaled, otherwise enqueues waiter
- **Memory**: Allocates one `IValueTaskSource` per waiter (unlike Task-based implementations that share a single `Task`). When a pool is provided, allocations are avoided when the pool can supply instances. The implementation also provides a local reusable waiter to avoid allocations for the first queued waiter.

## Best Practices

### ✓ DO: Use for Initialization Signals

```csharp
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
var start = new AsyncManualResetEvent(false);

var workers = Enumerable.Range(0, 10).Select(async i => {
    await start.WaitAsync();
    await DoWorkAsync(i);
}).ToArray();

start.Set();
await Task.WhenAll(workers);
```

### ✓ DO: Use a custom pool when high contention is expected

Provide a larger object pool to avoid temporary allocations when many waiters are queued simultaneously.

### ✓ DO: Always await `ValueTask` directly when possible

```csharp
// Good: Direct await
await _event.WaitAsync();

// Good: Immediate AsTask()
await _event.WaitAsync().AsTask();
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

### ✗ DON'T: Store `AsTask()` Before Signaling (when `RunContinuationAsynchronously == true`)

Storing the `Task` result of `AsTask()` before `Set()` forces an asynchronous completion path that can be much slower. Prefer awaiting the `ValueTask` directly.

### ✗ DON'T: Await `ValueTask` Multiple Times

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

(See examples in this file and `asyncautoresetevent.md` for additional patterns.)

## Benchmarks

See [Benchmarks](benchmarks.md#asyncmanualresetevent-benchmarks) for detailed performance comparisons.

## See Also

- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [Benchmarks](benchmarks.md) - Detailed performance comparisons

---

© 2025 The Keepers of the CryptoHives
