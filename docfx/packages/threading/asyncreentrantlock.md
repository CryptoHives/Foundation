# AsyncReentrantLock Class

An async exclusive lock that a nested call on the same logical async flow can re-acquire without deadlocking.

**Namespace:** `CryptoHives.Foundation.Threading.Async.Pooled` · [API reference](xref:CryptoHives.Foundation.Threading.Async.Pooled.AsyncReentrantLock)

> **Experimental.** The type ships in the package but is marked `[Experimental("CHTEXP001")]` on .NET 8 and later, so using it is a compile error until you opt in with `#pragma warning disable CHTEXP001` or `<NoWarn>$(NoWarn);CHTEXP001</NoWarn>`. It works and is tested, but unlike the other primitives it allocates on every acquisition (see [Performance and memory](#performance-and-memory)), and its API may change. Prefer [`AsyncLock`](asynclock.md) wherever the locked region can be narrowed, or released before calling out.

## Overview

[`AsyncLock`](asynclock.md) is not reentrant: a method that holds it and calls another method that takes it deadlocks. `Monitor` (`lock`) is reentrant, so synchronous code does this all the time, often unnoticed, and a straight port to async deadlocks on the first nested call. `AsyncReentrantLock` covers the cases where restructuring isn't an option:

- porting `lock`-based code to async;
- layered public APIs, where one locked method calls another;
- recursive algorithms under a lock;
- callbacks and events invoked from inside a held region that call back into the locked API.

```csharp
private readonly AsyncReentrantLock _lock = new();

public async Task AddAsync(Item item, CancellationToken ct)
{
    using (await _lock.LockAsync(ct).ConfigureAwait(false))
    {
        _items.Add(item);
        await RebalanceAsync(ct).ConfigureAwait(false);   // re-acquires: no deadlock
    }
}

public async Task RebalanceAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct).ConfigureAwait(false))
    {
        // ...
    }
}
```

## How it works

`Monitor` counts recursive entries by the owning thread, so a nested entry does no synchronization. That doesn't carry over to async code: there's no owning thread, and the naive equivalent ("this flow already holds it, so skip") breaks mutual exclusion as soon as a holder starts two concurrent children. Both children inherit the "already held" flag, and both run inside the region at once.

`AsyncReentrantLock` never skips an acquisition. It keeps **one real `AsyncLock` per nesting depth**, and an `AsyncLocal` records which depths the calling flow holds:

```
 depth   gen   held by          waiting
 ┌─────┬─────┬──────────┐
 │  0  │  7  │ A        │ ◀──── B       unrelated caller: still excluded
 │  1  │  3  │ A.1      │ ◀──── A.2     sibling of A.1: serializes
 │  2  │  1  │ A.1.1    │
 │  3  │  0  │ (free)   │
 └─────┴─────┴──────────┘
   one AsyncLock per depth

 A.1.1's AsyncLocal claims:   (2, gen 1) → (1, gen 3) → (0, gen 7)
```

A flow can only reach depth `N` while an ancestor holds depth `N - 1`. Depth 0 is a single exclusive lock, so only one tree of nested calls is active at a time. **Siblings still serialize**: if a holder runs `await Task.WhenAll(NestedA(), NestedB())` and both re-acquire, both target depth 1 and serialize on it.

```
 time ──────────────────────────────────────────────────────▶        depth
 A       ██████████████████████████████████████┤                       0
 A.1        ████████┤                                                  1
 A.2        ░░░░░░░░███████████████┤                                   1
 A.2.1                 ███████┤                                        2
 B       ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░█████████┤             0

 █ holds   ░ waits   ┤ releases
```

### Holders that have gone away

Each depth has a generation number, which is bumped when the holder disposes its releaser. A flow remembers the generation of every depth it nested under. Before acquiring, it looks for the deepest of them that is still held and nests one above it. If none is, for example in a fire-and-forget `Task.Run` child whose parent has already returned, it acquires depth 0 like any top-level caller. Once it holds the depth, it checks again that the depth it nested under is still held, and if that holder released during the wait, it gives the depth back and retries.

```
 LockAsync()                            Releaser.Dispose() at depth d
   │                                      │
   ├─ deepest live claim (d, g)?          ├─ gen[d]++: claims on d go stale
   │    a claim is live while depth d     ├─ restore the flow's AsyncLocal
   │    is taken and its gen is still g   │
   │      found → target d + 1            └─ depth d + 1 taken?
   │      none  → target 0                      no  → free d, then each depth
   │                                                  below whose holder already
   ├─ await depth[target]                             released
   │                                            yes → leave d taken; the last
   ├─ parent claim still live?                        one out above frees it
   │      no  → free target, retry
   │      yes → push (target, gen)
   │
   └─ return Releaser
```

### The lock stays held while nested holders run

Disposing a releaser ends the hold at once for the parent's flow, which no longer counts as holding the lock. Calls already nested under it keep their place and can nest further. The depth itself, though, stays taken while any call nested under it still holds the next depth, and the last one out frees it. A chain of such releases unwinds together. So a fire-and-forget child that is inside the lock when its parent leaves finishes as part of the parent's hold, and nobody from outside gets in until it is done.

```
 time ──────────────────────────────────────────────────────▶        depth
 A       █████████████┤ released; depth 0 stays taken                  0
 F          ███████████████████████┤ frees 1, then 0                   1
 B         ░░░░░░░░░░░░░░░░░░░░░░░░░██████████┤                        0
 G                       ░░░░░░░░░░░░░░░░░░░░░░█████┤                  0

 F  fire-and-forget child of A, inside the lock before A released
 G  fire-and-forget child of A that asks after A released: its claim is
    stale, so it queues at depth 0 like any outside caller
```

## Constructor

```csharp
public AsyncReentrantLock(
    int defaultDepthLocksCapacity = DefaultDepthLocksCapacity,   // 4
    int maxDepthLocksCapacity = MaxDepthLocksCapacity)           // 32
```

| Parameter | Description |
|-----------|-------------|
| `defaultDepthLocksCapacity` | Initial capacity of the depth table; it grows on demand up to `maxDepthLocksCapacity`. At least 4. |
| `maxDepthLocksCapacity` | Maximum nesting depth. A call that would nest deeper throws `InvalidOperationException`. At least 4, and not below `defaultDepthLocksCapacity`. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `DepthsCreated` | `int` | The number of distinct nesting depths this instance has reached. Diagnostic only. |

## Methods

### LockAsync

```csharp
public ValueTask<Releaser> LockAsync(CancellationToken cancellationToken = default)
public ValueTask<Releaser> LockAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
```

Acquires the lock, or the next depth if the calling flow already holds it. Dispose the returned `Releaser` to release, either with `using` or with `await using`.

**Throws**:
- `TimeoutException`: the timeout elapsed before the lock could be acquired. If the holder the call nested under releases during the wait, the call retries with a fresh timeout, so the total wait can exceed `timeout`.
- `OperationCanceledException`: the operation was cancelled through the token.
- `ArgumentOutOfRangeException`: `timeout` is negative and not `Timeout.InfiniteTimeSpan`.
- `InvalidOperationException`: the call would nest deeper than the maximum depth set at construction.

### LockLeafAsync

```csharp
public ValueTask<Releaser> LockLeafAsync(CancellationToken cancellationToken = default)
public ValueTask<Releaser> LockLeafAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
```

Acquires the lock at the same depth `LockAsync` would, so siblings at that depth still serialize with it and a parent's release still waits for it, but without recording the hold for further nesting. That skips the `AsyncLocal` write and the per-acquisition allocations. Use it for innermost regions that never call back into the lock: a `LockAsync` or `LockLeafAsync` call made inside a leaf hold deadlocks, as with `AsyncLock`. Throws the same exceptions as `LockAsync`.

There is no `TryLock` and no synchronous API.

## Pitfalls

A started child task and its parent are peers: both run code under the same hold. So either take the lock around every access to the protected state rather than relying on an outer hold, or don't take the lock in child tasks that are still running when the parent touches that state.

### Don't wrap `LockAsync` in an `async` method

Depth is tracked through `ExecutionContext`. When an `async` method returns, any `AsyncLocal` value it set is discarded, so a wrapper like the one below takes the lock but hides the hold from its caller. The caller's next nested acquisition then deadlocks:

```csharp
// Bad: the caller no longer counts as holding the lock
private async ValueTask<AsyncReentrantLock.Releaser> EnterAsync()
    => await _lock.LockAsync().ConfigureAwait(false);

// Good: return the ValueTask itself
private ValueTask<AsyncReentrantLock.Releaser> EnterAsync()
    => _lock.LockAsync();
```

The [CryptoHives.Foundation.Threading.Analyzers](../threading.analyzers/index.md) package reports this as [CHT013](../threading.analyzers/CHT013.md).

### Guard the resource where it is used

A lock can do two jobs: keep a compound operation atomic against other callers, or guard a resource on every access. Reentrancy serves only the first. A child that nests into the lock is part of its parent's operation, so it does not exclude the parent's own code. Code that touches the resource directly while a child is inside runs alongside that child:

```csharp
using (await _lock.LockAsync(ct).ConfigureAwait(false))
{
    Task child = Task.Run(() => WriteAsync(ct));   // WriteAsync takes _lock: nests
    _file.Write(header);                           // not excluded from the child
    await child.ConfigureAwait(false);
}
```

Take the lock where the resource is touched, so every access acquires it, including the parent's own:

```csharp
private async Task WriteHeaderAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct).ConfigureAwait(false))   // nests, serializes with the child
    {
        _file.Write(header);
    }
}
```

When the resource needs exclusion of its own, a separate [`AsyncLock`](asynclock.md) around it is the alternative. Take the two locks in the same order everywhere, this one first, so they cannot deadlock against each other.

### Nesting is a real acquisition

A nested `LockAsync` can wait, but only on concurrent siblings at the same depth, including children the caller started itself. If a holder starts a child that takes the lock and then nests while the child holds it, the holder waits for the child. A hold taken with `LockLeafAsync` cannot be nested into at all.

### Acquire one at a time per flow

Await each `LockAsync` before starting the next one on the same flow, and dispose releasers in reverse order. Each acquisition records what the flow held before it and restores that on dispose, so overlapping or out-of-order acquisitions leave the flow with a wrong view of what it holds, and a later nested call can deadlock. Concurrent tasks are not affected: each has its own copy of that state.

### Detached work that takes the lock depends on timing

A `Task.Run` that isn't awaited inherits the depth of its parent, so where it runs depends on timing:

- if it acquires while the parent still holds the lock, it nests and serializes with the parent's other nested calls;
- if the parent has already released, it waits for the lock like any top-level caller;
- if it still holds a nested depth when the parent releases, the parent carries on, but the lock stays held until the child releases, so a child that never finishes keeps the lock held for good.

A nested holder runs alongside its parent's own code, which holds only the outer depth. Where that matters, await everything the holder started, or detach the work with `ExecutionContext.SuppressFlow()` so it always acquires as a top-level caller.

### Depths are never reclaimed

Each depth reached creates one internal lock that lives as long as the instance does. Recursion under the lock grows that table up to the maximum depth set at construction (32 by default), after which `LockAsync` throws `InvalidOperationException`.

## Performance and memory

`AsyncReentrantLock` is **not allocation-free**, unlike the other primitives in this package. The waiter queue underneath is still the pooled `AsyncLock`. The cost comes from tracking reentrancy through an `AsyncLocal`, which no pooling can remove: the flow has to carry a new value to every call nested inside it.

### What an acquisition allocates

| Path | `LockAsync` | `LockLeafAsync` | `AsyncLock` |
|------|-------------|-----------------|-------------|
| Uncontended | Two small objects (the flow's state and its claim), plus a new `ExecutionContext` when the acquisition writes the `AsyncLocal`, and usually another when the release restores it | Nothing | Nothing |
| Contended | As above, plus an async state machine | An async state machine | Nothing (pooled waiter) |
| Contended with a timeout | As above, plus a timer | As above, plus a timer | A timer |
| The parent releases during the wait | Another pass through the queue | Another pass through the queue | Not applicable |

The cost of an `AsyncLocal` write depends on the runtime and on how many other `AsyncLocal` values the flow already carries.

### Time

Besides the `AsyncLock` acquisition, every call reads the `AsyncLocal`, walks the flow's claims to the deepest one still held, and rechecks that claim once it holds the depth. Release checks whether the next depth is still taken. These are a few reads and interlocked operations, and the walk is usually one step long. It grows only when the flow carries claims whose holders have released.

If nothing else in the flow uses `AsyncLocal`, the first acquisition gives it a non-default `ExecutionContext`. Every `await`, `Task.Run` and timer inside the hold then captures and restores that context, which the runtime otherwise skips.

### Memory

- **The depth table only grows.** Each depth reached keeps one `AsyncLock` for the lifetime of the instance, up to the maximum depth. See [Depths are never reclaimed](#depths-are-never-reclaimed).
- **Captured contexts keep claims alive.** A timer, a cancellation callback or a long-running task started inside the hold captures the `ExecutionContext`, and with it the flow's state and claim chain. These are a few small objects, and they don't keep the lock held, but they live until that capture is released.

### Choosing

- On hot paths, prefer [`AsyncLock`](asynclock.md): take it once at the public entry point and call private methods that assume it is held, rather than re-acquiring in each layer.
- Use `LockLeafAsync` for innermost regions that never call back into the lock. When uncontended it costs what `AsyncLock` costs.
- Keep `AsyncReentrantLock` for code where reentrancy can't be designed out, such as ported `lock` code, callbacks into the locked API or recursion.

`AsyncReentrantLockBenchmark` measures the uncontended overhead against `AsyncLock`, and `AsyncReentrantLockNestedDepthBenchmark` measures cost against nesting depth.

## See Also

- [Threading Package Overview](index.md)
- [AsyncLock](asynclock.md) - Non-reentrant async mutual exclusion lock
- [AsyncKeyedLock](asynckeyedlock.md) - Per-key async exclusion; distinct keys never block each other
- [AsyncReaderWriterLock](asyncreaderwriterlock.md) - Async reader-writer lock
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
