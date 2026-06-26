# AsyncManualResetEvent

## Overview

`AsyncManualResetEvent` is a pooled async version of `ManualResetEvent` that uses `ValueTask` to minimize memory allocations. It provides async signaling by reusing pooled `IValueTaskSource` instances. Unlike `AsyncAutoResetEvent`, it releases **all** waiting threads when signaled and remains signaled until explicitly reset.

## Namespace

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;
```

## Class Declaration

```csharp
public sealed class AsyncManualResetEvent : IResettable
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
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

### Parameters

- `set`: The initial state of the event (default: `false`).
- `runContinuationAsynchronously`: Controls whether continuations are forced to run asynchronously (default: `true`).
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
- `true` (default): Continuations are forced to the thread pool, preventing the signaling thread from being blocked.
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

### WaitAsync (timeout)

```csharp
public ValueTask WaitAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
```

Asynchronously waits for the event to be set, or throws `OperationCanceledException` if the timeout elapses first.

**Parameters**:
- `timeout` — The maximum time to wait. Pass `Timeout.InfiniteTimeSpan` to wait indefinitely (delegates to `WaitAsync()` without allocating a `TimeProvider`).

**Returns**: A `ValueTask` that completes when the event is set.

**Throws**:
- `OperationCanceledException` — If the timeout elapses before the event is set.
- `ArgumentOutOfRangeException` — If `timeout` is negative and not equal to `Timeout.InfiniteTimeSpan`.

**Allocation notes**:

| Scenario | TimeProvider allocated? |
|---|---|
| Event already signaled | No |
| `Timeout.InfiniteTimeSpan` | No |
| `TimeSpan.Zero` and not set | No (immediate exception) |
| Finite positive timeout | Yes — one instance, disposed on await |

**Examples**:

```csharp
// Preferred: direct timeout await — no Task conversion
await _event.WaitAsync(TimeSpan.FromSeconds(5));

// Previously required — now unnecessary:
// await _event.WaitAsync().AsTask().WaitAsync(TimeSpan.FromSeconds(5));

// Infinite timeout delegates to WaitAsync() — no CTS allocation
await _event.WaitAsync(Timeout.InfiniteTimeSpan);
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

### TryReset

```csharp
public bool TryReset()
```

Implements `IResettable` to allow returning this instance to a `DefaultObjectPool<AsyncManualResetEvent>`.

**Behavior**:
- Attempts to acquire the internal spin lock. If the lock is already held (a concurrent `Set()` or `WaitAsync()` is in progress), the method returns `false` immediately and the pool discards the instance.
- If the lock is acquired and waiters are currently queued, the method returns `false` — the instance is still in active use and must not be recycled.
- If the lock is acquired and no waiters are queued, the signaled flag and options are reset to initial defaults and the local waiter is reset; the method returns `true`.

**Thread Safety**: `TryReset()` is safe to call concurrently with other operations. It will simply return `false` if the instance is in use.

**Example**:

```csharp
// Using AsyncManualResetEvent with an object pool
var pool = new DefaultObjectPool<AsyncManualResetEvent>(
    new DefaultPooledObjectPolicy<AsyncManualResetEvent>());

var ev = pool.Get();
try
{
    await ev.WaitAsync(ct);
}
finally
{
    pool.Return(ev); // calls TryReset() internally
}
```

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

## Benchmark Results

The following benchmarks compare `AsyncManualResetEvent` against popular alternatives including `Nito.AsyncEx.AsyncManualResetEvent` and reference `TaskCompletionSource`-based implementations.

### Set/Reset Cycle Benchmark

Measures the performance of rapid uncontended Set/Reset cycles. No surprises here except for Nito and Refimpl which expose some memory allocations, probably for a TaskCompletionSource instance.

[!INCLUDE[Set Reset Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asyncmanualresetevent-setreset.md)]

### Set Then Wait Benchmark

Measures the pattern where the event is set before waiters arrive (synchronous completion path). Again no surprises here; all implementations complete synchronously but Nito and Refimpl require allocations.

[!INCLUDE[Set Then Wait Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asyncmanualresetevent-setthenw.md)]

### Wait Then Set Benchmark

Measures the pattern where waiters are queued before the event is signaled (asynchronous completion path). The pooled implementation shows strong performance here without allocations, especially when a cancellation token is provided. 
Nito and Refimpl again show higher allocation counts due to TaskCompletionSource usage. In the tests for non cancellable tokens, Nito is ahead of the pack because it can share a single TaskCompletionSource with all waiters, but falls back when real cancellable tokens are used.

[!INCLUDE[Wait Then Set Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asyncmanualresetevent-waitthenset.md)]

### Benchmark Analysis

**Key Findings:**
1. **Per-Waiter Overhead**: Unlike `Task`-based implementations where all waiters share a single `TaskCompletionSource`, each waiter in the pooled implementation requires its own `IValueTaskSource`. This is an inherent trade-off of the `ValueTask` model, but other implementations only leverage this advantage when non cancellable tokens are used. With cancellable tokens, they also require per-waiter instances and fall back in perf and allocations.

2. **Pool Mitigation**: The object pool effectively mitigates allocation overhead. The local waiter optimization ensures the first queued waiter incurs no allocation.

3. **Synchronous Fast Path**: When the event is already signaled, `WaitAsync()` completes synchronously with zero allocations and without entering the lock.

4. **Set() Performance**: For broadcasts to many waiters, the overhead of signaling each `IValueTaskSource` individually may be higher than a single shared `Task`. Consider the trade-off based on your use case.

**When to Choose AsyncManualResetEvent:**
- Initialization patterns where you wait for a one-time signal
- Scenarios with few concurrent waiters or where cancellable tokens are widely used
- Memory-sensitive applications where the pooling benefits outweigh per-waiter overhead

**When to Consider Alternatives:**
- Broadcasting to many concurrent waiters where a shared `Task` would be more efficient
- Scenarios where `ValueTask` restrictions are inconvenient

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

### ✓ DO: Use `WaitAsync(TimeSpan)` for timed waits

```csharp
try
{
    await _event.WaitAsync(TimeSpan.FromSeconds(10));
    ProcessData();
}
catch (OperationCanceledException)
{
    HandleTimeout();
}
```

## Common Patterns

(See examples in this file and `asyncautoresetevent.md` for additional patterns.)

## See Also

- [Threading Package Overview](index.md)
- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncReaderWriterLock](asyncreaderwriterlock.md) - Async reader-writer lock
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [AsyncCountdownEvent](asynccountdownevent.md) - Async countdown event
- [AsyncBarrier](asyncbarrier.md) - Async barrier synchronization primitive
- [AsyncSemaphore](asyncsemaphore.md) - Async semaphore primitive
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
