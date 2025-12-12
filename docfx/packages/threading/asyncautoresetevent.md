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
- **Cancellation support**: Full `CancellationToken` support for queued waiters
- **Thread-safe**: All operations are thread-safe
- **FIFO queue**: Waiters are released in first-in-first-out order

## Constructor

```csharp
public AsyncAutoResetEvent(
    bool initialState = false, 
    bool runContinuationAsynchronously = true, 
    int defaultEventQueueSize = 0, 
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

### Parameters

- `initialState`: The initial state of the event (default: `false`)
- `runContinuationAsynchronously`: Controls whether continuations are forced to run asynchronously (default: `true`)
- `defaultEventQueueSize`: The default waiter queue capacity (default: `8` when 0 is supplied)
- `pool`: Optional custom source provider implementing `IGetPooledManualResetValueTaskSource<bool>` which supplies pooled `PooledManualResetValueTaskSource<bool>` instances (helps avoid allocations under contention). You may pass a `ValueTaskSourceObjectPool<bool>` or a custom provider that implements the interface.

## Properties

### IsSet

```csharp
public bool IsSet { get; }
```

Gets whether this event is currently in the signaled state. A successful `WaitAsync()` consumes the signal (auto-reset semantics) and returns `false` after a wait consumes the signal.

### RunContinuationAsynchronously

```csharp
public bool RunContinuationAsynchronously { get; set; }
```

Controls how continuations are executed when the event is signaled:
- `true` (default): Continuations queue to the thread pool, preventing the signaling thread from being blocked
- `false`: Continuations may execute synchronously on the signaling thread

**Performance Warning**: When `true`, storing `AsTask()` results before signaling causes severe performance degradation (10x-100x slower) because the underlying value task source must create a `Task` wrapper that forces asynchronous completion.

> Note: The implementation exposes an internal property `InternalWaiterInUse` used by tests to detect whether the fast-path local waiter is currently held. This is not part of the public API surface for consumers.

## Methods

### WaitAsync

```csharp
public ValueTask WaitAsync(CancellationToken cancellationToken = default)
```

Asynchronously waits for the event to be signaled.

**Behavior**:
- If the event is currently signaled the call returns a completed `ValueTask` (synchronous, zero-allocation) and the event is immediately reset.
- Otherwise the call enqueues a pooled waiter and returns a `ValueTask` that completes when signaled.

**Parameters**:
- `cancellationToken` - Optional cancellation token. If the token is already cancelled, the method returns a canceled `ValueTask`. When a waiter is queued, the token is registered and a later cancellation will complete that waiter with an `OperationCanceledException`.

**Returns**: A `ValueTask` that completes when the event is signaled.

**Throws**:
- `OperationCanceledException` - If the operation is canceled via the cancellation token while queued

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

Signals the event, releasing **one** waiting waiter if any are queued. If no waiters are queued the event is set to a signaled state so that the next `WaitAsync()` completes synchronously.

### SetAll

```csharp
public void SetAll()
```

Signals all currently queued waiters. If no waiters are queued the event becomes signaled so that the next `WaitAsync()` completes synchronously. This method is useful when broadcasting a single notification to all waiters.

### (Internal) Reset

The implementation provides an internal `Reset()` helper used in tests/benchmarks to clear the signaled flag. Consumers typically do not call a reset on an auto-reset event since each `Set()` releases a single waiter.

## Cancellation Notes

- Cancellation is supported for queued waiters. The token is only registered when the waiter is enqueued (fast-path avoids registration). When cancelled, the waiter completes with an `OperationCanceledException` and is removed from the internal queue.
- Avoid passing cancellation tokens for hot-path uncontended waits to minimize allocation overhead from token registration. If a token is already canceled before calling `WaitAsync`, the method returns a canceled `ValueTask` (which may allocate a `Task` wrapper on some frameworks).

## Thread Safety

✓ **Thread-safe**. All public methods are thread-safe and can be called concurrently.

## Performance Characteristics

- **Set()**: O(1) operation
- **SetAll()**: O(n) for n waiters
- **WaitAsync()**: O(1) when signaled, otherwise enqueues waiter
- **Memory**: Zero allocations when waiters can be satisfied from the local waiter or the configured pool; allocations happen only when the pool is exhausted or when cancellation registrations/Task wrappers are required.

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

### ✓ DO: Always await `ValueTask` directly when possible

```csharp
// Good: Direct await
await _event.WaitAsync();

// Good: Immediate AsTask()
await _event.WaitAsync().AsTask();
```

### ✓ DO: Use a custom pool when high contention is expected

Provide a larger object pool to avoid temporary allocations when many waiters are queued simultaneously.

### ✗ DON'T: Store `AsTask()` Before Signaling (when `RunContinuationAsynchronously == true`)

Storing the `Task` result of `AsTask()` before `Set()` forces an asynchronous completion path that can be much slower. Prefer awaiting the `ValueTask` directly.

### ✗ DON'T: Await `ValueTask` Multiple Times

```csharp
ValueTask vt = _event.WaitAsync();
await vt;
await vt; // throws InvalidOperationException
```

## Common Patterns

(Examples omitted - see `asyncmanualresetevent.md` for manual-reset patterns and broadcasting examples.)

## Benchmarks

See [Benchmarks](benchmarks.md#asyncautoresetevent-benchmarks) for detailed performance comparisons.

## See Also

- [AsyncManualResetEvent](asyncmanualresetevent.md) - Manual-reset event variant
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [Benchmarks](benchmarks.md) - Detailed performance comparisons

---

© 2025 The Keepers of the CryptoHives
