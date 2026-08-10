# AsyncKeyedLock&lt;TKey&gt; Class

A pooled per-key async exclusive lock. Operations on different keys run fully concurrently; operations on the same key are serialized.

## Namespace

```csharp
CryptoHives.Foundation.Threading.Async.Pooled
```

## Syntax

```csharp
public sealed class AsyncKeyedLock<TKey> where TKey : notnull
```

## Overview

`AsyncKeyedLock<TKey>` gives each key its own exclusive lock without requiring you to create, track and tear down one lock object per key. A `ConcurrentDictionary` maps each key to an entry holding that key's lock state, and entries are recycled rather than discarded, so a workload that keeps returning to the same keys allocates nothing at all after the first pass.

It is **not** recursive: a caller that already holds a key and asks for it again will deadlock, exactly as with `AsyncLock`.

Unlike *striped* keyed locks, which hash keys onto a fixed number of shared locks, every key here gets genuine isolation. Two unrelated keys can never block each other, whatever their hash codes.

## Benefits

- **Zero-allocation fast path**: An uncontended acquisition of an already-mapped key completes synchronously with no heap allocation - neither the entry nor the dictionary node.
- **Zero-allocation contended path**: Acquisition introduces no `await` boundary of its own, so a queued waiter costs no state-machine box.
- **True per-key isolation**: Distinct keys never contend, unlike striped implementations.
- **Entry recycling**: A released key stays mapped as an *idle* entry, so repeated lock/release cycles on the same key are free.
- **ValueTask-Based**: Returns `ValueTask<Releaser>` for minimal allocation.
- **RAII Pattern**: Uses a value-type releaser implementing `IDisposable`/`IAsyncDisposable`.
- **Cancellation and timeout support**: Both optional, and neither costs anything until an acquisition actually has to wait.

## Constructor

```csharp
public AsyncKeyedLock(
    IEqualityComparer<TKey>? comparer = null,
    IGetPooledManualResetValueTaskSource<Releaser>? pool = null,
    int maxIdleEntries = DefaultMaxIdleEntries,
    int maxRetainedWaiters = DefaultMaxRetainedWaiters)
```

| Parameter | Description |
|-----------|-------------|
| `comparer` | Optional key comparer. Supplying one forfeits the devirtualized `EqualityComparer<TKey>.Default` fast path. |
| `pool` | Optional custom pool for ValueTaskSource instances. |
| `maxIdleEntries` | Idle entries retained for reuse. Bounds **key cardinality**. Default 128. |
| `maxRetainedWaiters` | Waiter objects retained for reuse. Bounds **simultaneous contention**. Default 128. |

> **Note:** the default waiter pool is shared process-wide per closed `TKey`, so every `AsyncKeyedLock<string>` in the process draws on one budget. Passing `maxRetainedWaiters` is also what gives an instance its own pool.

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Count` | `int` | Number of keys currently held or awaited. |

## Methods

### LockAsync

```csharp
public ValueTask<Releaser> LockAsync(TKey key, CancellationToken cancellationToken = default)
```

Acquires the lock for `key`, waiting if another caller holds it.

```csharp
private readonly AsyncKeyedLock<string> _locksByAccount = new();

public async Task TransferAsync(string accountId, CancellationToken ct)
{
    using (await _locksByAccount.LockAsync(accountId, ct).ConfigureAwait(false))
    {
        // Only one operation per accountId; other accounts proceed in parallel
        await ApplyTransferAsync(accountId).ConfigureAwait(false);
    }
}
```

Throws `ArgumentNullException` if `key` is `null`, and `OperationCanceledException` if the token is cancelled before the key is acquired.

### LockAsync (timeout)

```csharp
public ValueTask<Releaser> LockAsync(TKey key, TimeSpan timeout, CancellationToken cancellationToken = default)
```

As above, but gives up after `timeout` and throws `TimeoutException`. Pass `Timeout.InfiniteTimeSpan` to wait indefinitely.

| Scenario | Timer allocated? |
|----------|------------------|
| Key immediately available | No |
| `Timeout.InfiniteTimeSpan` | No |
| `TimeSpan.Zero` and key held | No (immediate exception) |
| Finite positive timeout | Yes — one instance, disposed on await |

A negative timeout other than `Timeout.InfiniteTimeSpan` throws `ArgumentOutOfRangeException`.

Both the zero-timeout and cancellation checks happen *after* a retry inside the lock, so a zero-timeout caller gets the same second chance every other caller does rather than giving up on a key the holder may have released in between. A caller passing both a cancelled token and a zero timeout receives `OperationCanceledException`, which carries the token, rather than a `TimeoutException` that describes neither.

### TryLock

```csharp
public bool TryLock(TKey key, out Releaser releaser)
```

Attempts to acquire `key` without waiting. Returns `false` and `default(Releaser)` if the key is held; the `false` path releases its administrative reference, so a failed attempt leaves no trace.

```csharp
if (_locksByKey.TryLock(id, out var releaser))
{
    using (releaser)
    {
        // Acquired without waiting
    }
}
```

### IsInUse

```csharp
public bool IsInUse(TKey key)
```

Returns `true` when `key` is currently held or awaited. Returns `false` for a key whose entry is merely cached for reuse. This is a best-effort diagnostic snapshot, not a value to synchronize on — it can change immediately after being read.

### Allocation Behavior

The lock is allocation-free while a workload fits inside two caps, and degrades gracefully — not catastrophically — past either.

| Cap | Bounds | Past the cap |
|-----|--------|--------------|
| `maxIdleEntries` | **key cardinality** — the keys hot at the same time | Each acquisition of an unmapped key takes over the least recently idled entry and allocates a fresh dictionary node (~48 B/key). The entry itself is still reused. |
| `maxRetainedWaiters` | **simultaneous contention** — waiters queued at one moment, summed across all keys | Each waiter beyond the cap is allocated and then discarded rather than returned to the pool. |

A released key stays mapped as an *idle* entry rather than being torn down, which is what makes the common case free — and also why `maxIdleEntries` should span the *hot* key set rather than the total number of distinct keys ever seen. Retention is bounded by the keys actually used, so a generous cap costs a lock with few keys nothing.

Each entry supplies one waiter itself and the pool covers the rest, so a lock with 4 keys and 100 waiters behind each needs 396 pooled waiters — at the default, such a burst allocates on 268 of them.

```csharp
// Sized to the workload: ~2000 hot tenants, up to ~500 waiters queued at peak
private readonly AsyncKeyedLock<string> _locksByTenant =
    new(maxIdleEntries: 2048, maxRetainedWaiters: 512);
```

## Thread Safety

**Thread-safe**. All public methods are thread-safe and can be called concurrently from multiple threads.

## Performance Characteristics

- **Uncontended acquisition of a mapped key**: O(1), synchronous completion, no allocation
- **Uncontended acquisition of an unmapped key**: O(1), plus one dictionary node when the idle cache is full
- **Contended acquisition**: O(1) to enqueue; waiters come from the pool
- **Release**: O(1) to signal the next waiter for that key
- **Bookkeeping**: every acquire and release briefly takes one administrative lock, so its contention scales with total instance throughput rather than with per-key demand

## Benchmark Results

Six benchmark classes cover the keyed lock, comparing against `AsyncKeyedLock` (third-party), `KeyedSemaphores`, `Dao.IndividualLock`, `AsyncUtilities`, and a reference implementation of Theodor Zoulias's "AsyncDuplicateLock" pattern.

Striped variants appear in the reports for scale but are **not** like-for-like: they alias distinct keys onto shared locks and so do not provide per-key isolation.

| Scenario | Result |
|----------|--------|
| `TryLock`, uncontended | Fastest measured, and the only zero-allocation entry |
| `LockAsync`, uncontended single key | Fastest non-striped, zero allocation |
| Many distinct keys within the idle cache | Zero allocation where others allocate per key |
| Contended, one key, waiters queued | Several times faster than the field, zero allocation up to the waiter cap |
| Working set above `maxIdleEntries` | Loses its allocation advantage; pays a dictionary node per acquisition |
| Many threads, disjoint keys | The administrative lock serializes; a sharded variant is planned |

See [Benchmarks](benchmarks.md) for the full reports and [Benchmark Trends](benchmark-trends/index.html) for history.

## Best Practices

### DO: Use the using pattern and await the result directly

```csharp
using (await _locks.LockAsync(key).ConfigureAwait(false))
{
    // Critical section for this key
}
```

### DO: Size the caches to the workload

Set `maxIdleEntries` to the set of keys hot at one time, and `maxRetainedWaiters` to the peak number of waiters queued at one time. The defaults suit a few hundred keys with modest contention.

### DO: Use `TryLock` when a missed acquisition is acceptable

It never waits and never allocates, which makes it well suited to opportunistic work that can be skipped or retried later.

### DON'T: Create a new lock instance per operation

```csharp
// WRONG - each call gets its own registry, so nothing is actually serialized
public async Task ProcessAsync(string key)
{
    var locks = new AsyncKeyedLock<string>();
    using (await locks.LockAsync(key).ConfigureAwait(false)) { }
}
```

Hold one instance for the lifetime of the component that owns the resource.

### DON'T: Re-enter the same key

```csharp
// WRONG - deadlocks; the lock is not recursive
using (await _locks.LockAsync(key).ConfigureAwait(false))
{
    using (await _locks.LockAsync(key).ConfigureAwait(false)) { }
}
```

### DON'T: Hold a key across long-running work

The critical section should be short. Holding a key across a network call serializes every caller of that key for the duration.

## See Also

- [Threading Package Overview](index.md)
- [AsyncLock](asynclock.md) - Non-keyed async mutual exclusion lock
- [AsyncSemaphore](asyncsemaphore.md) - Async semaphore primitive
- [AsyncReaderWriterLock](asyncreaderwriterlock.md) - Async reader-writer lock
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
