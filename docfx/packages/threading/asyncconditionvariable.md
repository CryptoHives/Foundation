# AsyncConditionVariable

## Overview

`AsyncConditionVariable` is the async equivalent of `Monitor.Wait` / `Monitor.Pulse`. It pairs with an [`AsyncLock`](asynclock.md) and gives a task the ability to wait until a condition protected by that lock becomes true, without blocking a thread.

A wait atomically releases the lock, suspends, and re-acquires the lock before returning — on **every** return path, including cancellation and timeout.

## Namespace

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;
```

## Class Declaration

```csharp
public sealed class AsyncConditionVariable : IResettable
```

## Key Features

- **Pairs with `AsyncLock`**: the lock is released while suspended and re-acquired before the wait returns
- **Lock held on every return path**: cancellation and timeout re-acquire the lock before the exception propagates, so an enclosing `using` block always releases a lock it owns
- **Signals are never swallowed**: a wait that has consumed a signal completes successfully even if the token is cancelled afterwards
- **Pooled waiters**: the first concurrent waiter uses an instance-local `IValueTaskSource<bool>`, further waiters come from a pool
- **Cancellation support**: full `CancellationToken` support; allocation-free registration on .NET 6.0+
- **Timeout support**: direct `WaitAsync(AsyncLock, TimeSpan)` overload — no `Task` conversion required
- **Bound to one lock**: a second lock passed to the same instance is rejected rather than silently corrupting both

## Known Issues

- The wait is an `async` method and therefore boxes a state machine when it suspends: it awaits the signal and then the re-acquisition of the lock. Removing that allocation requires transferring a signalled waiter directly into the lock's own wait queue, which is a planned change. Every other allocation on the path is already pooled away.

## Constructor

```csharp
public AsyncConditionVariable(
    bool runContinuationAsynchronously = true,
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

### Parameters

- `runContinuationAsynchronously`: Controls whether continuations are forced to run asynchronously after a signal (default: `true`)
- `pool`: Optional custom source provider implementing `IGetPooledManualResetValueTaskSource<bool>`

## Properties

### WaiterCount

```csharp
public int WaiterCount { get; }
```

The number of tasks currently queued waiting for a signal.

### RunContinuationAsynchronously

```csharp
public bool RunContinuationAsynchronously { get; set; }
```

- `true` (default): continuations queue to the thread pool, so the signaling thread is not hijacked
- `false`: continuations may execute synchronously on the signaling thread

## Methods

### WaitAsync

```csharp
public ValueTask WaitAsync(AsyncLock asyncLock, CancellationToken cancellationToken = default)
```

Releases `asyncLock`, waits for a signal, then re-acquires `asyncLock` before returning.

**Preconditions**: the caller must hold `asyncLock`.

**Throws**:

- `ArgumentNullException` — `asyncLock` is `null`
- `SynchronizationLockException` — the lock is not held on entry
- `InvalidOperationException` — this instance has already been used with a different `AsyncLock`
- `OperationCanceledException` — the token was cancelled **before** a signal was received

All of these leave the caller holding the lock: the validation failures never release it, and the cancellation path re-acquires it before the exception propagates.

### WaitAsync (timeout)

```csharp
public ValueTask WaitAsync(AsyncLock asyncLock, TimeSpan timeout, CancellationToken cancellationToken = default)
```

The same, bounded by `timeout`.

**Parameters**:

- `timeout` — the maximum time to wait **for the signal**; the subsequent lock re-acquisition is not bounded by it. `Timeout.InfiniteTimeSpan` waits indefinitely and allocates no timer. `TimeSpan.Zero` always throws `TimeoutException`: a condition variable holds no state that a zero-length wait could observe.

**Throws**: additionally `TimeoutException` if the timeout elapses first, and `ArgumentOutOfRangeException` if `timeout` is negative and not `Timeout.InfiniteTimeSpan`. The lock is re-acquired before `TimeoutException` propagates.

**Allocation notes**:

| Scenario | Timer allocated? |
|---|---|
| `Timeout.InfiniteTimeSpan` | No |
| `TimeSpan.Zero` | No (immediate exception, the slot is never occupied) |
| Finite positive timeout | Yes — one instance, disposed on await |

### Signal

```csharp
public void Signal()
```

Wakes one waiting task. **If no task is waiting, the signal is lost** — a condition variable stores no state. This is why the predicate must be re-checked in a loop.

### SignalAll

```csharp
public void SignalAll()
```

Wakes every waiting task. A signal with no waiters is likewise lost.

### TryReset

```csharp
public bool TryReset()
```

Implements `IResettable` so the instance can be returned to a `DefaultObjectPool<AsyncConditionVariable>`.

**Behavior**:

- Returns `false` if the internal spin lock is held, if waiters are queued, or if a completed waiter has not observed its result yet
- Otherwise clears the lock binding, restores `RunContinuationAsynchronously` to its default and returns `true`

## Cancellation semantics

Cancellation and timeout bound the **wait for a signal**, not the re-acquisition of the lock. Once a waiter has been signalled, it has consumed that signal, and the wait completes successfully even if the token is cancelled while it is still queued behind the lock.

Reporting cancellation at that point would throw the signal away: the woken waiter would fail, no other waiter would be woken in its place, and a producer/consumer pipeline would stall. A caller that must observe cancellation promptly does so in its own predicate loop, which is where the token belongs:

```csharp
using (await _lock.LockAsync(ct))
{
    while (!Ready)
    {
        ct.ThrowIfCancellationRequested();   // observed here
        await _cv.WaitAsync(_lock, ct);      // only fails if not signalled
    }
}
```

## Usage Example

Waiting for a shared resource to reach a specific state. This is deliberately *not* a queue: the
condition is an arbitrary state protected by the lock, not "an item is available" — something a
`Channel<T>` has no way to express. `SendAsync` re-checks the predicate in a `while` loop before
every wait and does the actual work only after releasing the lock; nothing is ever processed while
`_lock` is held.

```csharp
private readonly AsyncLock _lock = new();
private readonly AsyncConditionVariable _ready = new();
private ConnectionState _state = ConnectionState.Disconnected;

// The reconnect loop is the only writer of _state.
private async Task ReconnectLoopAsync(CancellationToken ct)
{
    while (!ct.IsCancellationRequested)
    {
        try
        {
            await ConnectAsync(ct).ConfigureAwait(false);

            using (await _lock.LockAsync(ct).ConfigureAwait(false))
            {
                _state = ConnectionState.Ready;
                _ready.SignalAll();   // every caller waiting for readiness wakes up
            }

            await RunUntilDisconnectedAsync(ct).ConfigureAwait(false);
        }
        finally
        {
            using (await _lock.LockAsync(CancellationToken.None).ConfigureAwait(false))
                _state = ConnectionState.Disconnected;
        }
    }
}

// Any caller can wait for the connection to become ready before using it.
public async Task<T> SendAsync<T>(Func<Task<T>> operation, CancellationToken ct)
{
    using (await _lock.LockAsync(ct).ConfigureAwait(false))
    {
        while (_state != ConnectionState.Ready)
            await _ready.WaitAsync(_lock, ct).ConfigureAwait(false);
    }

    return await operation().ConfigureAwait(false);   // outside the lock
}
```

## Best Practices

### ✓ DO: Re-check the predicate in a `while` loop

A condition variable signals that something *may* have changed. It does not hand over ownership of the change.

### ✓ DO: Hold the lock when signalling if the predicate is being changed

Publish the state change and signal inside the same critical section, so a consumer cannot miss it.

### ✓ DO: Use one condition variable per condition

Two conditions sharing an instance means every signal wakes the wrong waiter half the time. Several instances may share one `AsyncLock`.

### ✗ DON'T: Call `WaitAsync` without holding the lock

It throws `SynchronizationLockException`. Releasing a lock the caller does not own would hand it to an unrelated waiter and the corruption would surface much later.

### ✗ DON'T: Use one instance with two different locks

The second lock is rejected with `InvalidOperationException`. Bind a second condition variable instead.

### ✗ DON'T: Rely on a signal reaching a waiter that has not queued yet

Use [`AsyncManualResetEvent`](asyncmanualresetevent.md) when the notification has to persist.

## See Also

- [Threading Package Overview](index.md)
- [AsyncLock](asynclock.md) - The lock a condition variable pairs with
- [AsyncManualResetEvent](asyncmanualresetevent.md) - Latching notification that is not lost
- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncExchange](asyncexchange.md) - Two-party value rendezvous
- [AsyncSemaphore](asyncsemaphore.md) - Async semaphore primitive
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
