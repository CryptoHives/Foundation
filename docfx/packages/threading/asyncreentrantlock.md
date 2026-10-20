# AsyncReentrantLock Class

An async exclusive lock that a nested call on the same logical async flow can re-acquire without deadlocking.

**Namespace:** `CryptoHives.Foundation.Threading.Async.Pooled` · [API reference](xref:CryptoHives.Foundation.Threading.Async.Pooled.AsyncReentrantLock)

> **Experimental.** The type ships in the package but is marked `[Experimental("CHTEXP001")]` on .NET 8 and later, so using it is a compile error until you opt in with `#pragma warning disable CHTEXP001` or `<NoWarn>$(NoWarn);CHTEXP001</NoWarn>`. It works and is tested, but it has not had the allocation and pooling work the other primitives have had, and its API may change. Prefer [`AsyncLock`](asynclock.md) wherever the locked region can be narrowed, or released before calling out.

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
flow A (top level)  →  holds nothing  →  takes depth 0
  └─ nested call    →  holds 0        →  takes depth 1
       └─ nested    →  holds 0, 1     →  takes depth 2

flow B (unrelated)  →  holds nothing  →  waits for depth 0   ← still excluded
```

A flow can only reach depth `N` while an ancestor holds depth `N - 1`. Depth 0 is a single exclusive lock, so only one tree of nested calls is active at a time. **Siblings still serialize**: if a holder runs `await Task.WhenAll(NestedA(), NestedB())` and both re-acquire, both target depth 1 and serialize on it.

### Holders that have gone away

Each depth has a generation number, which is bumped when the holder disposes its releaser. A flow remembers the generation of every depth it nested under. Before acquiring, it checks each of them. If any ancestor has released, for example the parent of a fire-and-forget `Task.Run` child that has already returned, the flow targets the lowest depth whose holder is gone, as an ordinary acquisition. It checks again once it holds that depth, and if an ancestor released during the wait, it gives the depth back and retries lower down.

### The lock stays held while nested holders run

Disposing a releaser ends the hold at once for nesting purposes: no new call can nest under it. The depth itself, though, stays taken while any call nested under it still holds the next depth, and the last one out frees it. A chain of such releases unwinds together. So a fire-and-forget child that is inside the lock when its parent leaves finishes as part of the parent's hold, and nobody from outside gets in until it is done.

## Constructor

```csharp
public AsyncReentrantLock()
```

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
- `TimeoutException`: the timeout elapsed before the lock could be acquired.
- `OperationCanceledException`: the operation was cancelled through the token.
- `ArgumentOutOfRangeException`: `timeout` is negative and not `Timeout.InfiniteTimeSpan`.

There is no `TryLock` and no synchronous API.

## Pitfalls

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

### Nesting is a real acquisition

A nested `LockAsync` can wait, but only on concurrent siblings at the same depth, including children the caller started itself. If a holder starts a child that takes the lock and then nests while the child holds it, the holder waits for the child.

### Don't detach work that takes the lock

A `Task.Run` that isn't awaited inherits the depth of its parent, so where it runs depends on timing:

- if it acquires while the parent still holds the lock, it nests and serializes with the parent's other nested calls;
- if the parent has already released, it waits for the lock like any top-level caller;
- if it still holds a nested depth when the parent releases, the parent carries on, but the lock stays held until the child releases, so a child that never finishes keeps the lock held for good.

A nested holder runs alongside its parent's own code, which holds only the outer depth. Await everything the holder started, or detach the work with `ExecutionContext.SuppressFlow()` so it always acquires as a top-level caller.

### Depths are never reclaimed

Each depth reached creates one internal lock that lives as long as the instance does. Unbounded recursion under the lock grows that table without limit.

## Performance

Each acquisition reads and writes an `AsyncLocal`, allocates two small objects and checks the generation of every ancestor depth, on top of the underlying `AsyncLock` acquisition. A contended acquisition also allocates an async state machine. `AsyncReentrantLockBenchmark` measures the uncontended overhead against `AsyncLock`, and `AsyncReentrantLockNestedDepthBenchmark` measures cost against nesting depth.

## See Also

- [Threading Package Overview](index.md)
- [AsyncLock](asynclock.md) - Non-reentrant async mutual exclusion lock
- [AsyncKeyedLock](asynckeyedlock.md) - Per-key async exclusion; distinct keys never block each other
- [AsyncReaderWriterLock](asyncreaderwriterlock.md) - Async reader-writer lock
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
