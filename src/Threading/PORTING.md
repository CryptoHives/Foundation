# CryptoHives.Foundation.Threading — Guide for LLM Agents

Machine-readable usage + porting guide for coding assistants. All APIs below are verified
against the shipped source. Do not invent members. Human-oriented docs live in `README.md`.

- **Package:** `CryptoHives.Foundation.Threading`
- **Primitive namespace:** `CryptoHives.Foundation.Threading.Async.Pooled`
- **Companion analyzer (install separately):** `CryptoHives.Foundation.Threading.Analyzers`
- **What it is:** allocation-free async synchronization primitives that return
  `ValueTask`/`ValueTask<T>` instead of `Task`, backed by pooled `IValueTaskSource<T>`.

---

## When to use / what to replace

Use these when an `await` must happen inside a critical section, or to remove
`Task`/`TaskCompletionSource<T>` allocations from hot paths.

| Existing code | Replace with | Caveat |
|---|---|---|
| `lock (obj) { … }` around code that needs to `await` | `AsyncLock` + `using (await l.LockAsync())` | **Not reentrant.** Pure-sync `lock` blocks stay `lock`. |
| `SemaphoreSlim(1, 1)` as a mutex | `AsyncLock` | Analyzer flags this (CHT009). |
| `SemaphoreSlim(n, …)` for concurrency limiting | `AsyncSemaphore(n)` | No bool-returning `WaitAsync(timeout)` — see below. |
| `ManualResetEventSlim` / TCS gate awaited async | `AsyncManualResetEvent` | |
| `AutoResetEvent` (async) | `AsyncAutoResetEvent` | Releases exactly one waiter per `Set()`. |
| `CountdownEvent` (async) | `AsyncCountdownEvent` | |
| `Barrier` (async) | `AsyncBarrier` | |
| `ReaderWriterLockSlim` (async) | `AsyncReaderWriterLock` | |
| `Nito.AsyncEx.AsyncLock`, `NeoSmart.AsyncLock`, single-key `AsyncKeyedLock` | `AsyncLock` | Verify no reentrancy. |

---

## Verified API surface

```csharp
// AsyncLock — NOT reentrant. Release only by disposing the Releaser.
sealed class AsyncLock {
    AsyncLock();
    ValueTask<Releaser> LockAsync(CancellationToken cancellationToken = default);
    ValueTask<Releaser> LockAsync(TimeSpan timeout, CancellationToken cancellationToken = default);
    bool IsTaken { get; }
    readonly struct Releaser : IDisposable, IAsyncDisposable; // Dispose() releases the lock
}

// AsyncSemaphore
sealed class AsyncSemaphore {
    AsyncSemaphore(int initialCount, bool runContinuationAsynchronously = true, …);
    ValueTask WaitAsync(CancellationToken cancellationToken = default);
    ValueTask WaitAsync(TimeSpan timeout, CancellationToken cancellationToken = default);
    void Release();
    void Release(int releaseCount);
    int CurrentCount { get; }
}

// AsyncManualResetEvent / AsyncAutoResetEvent
new AsyncManualResetEvent(initialState: false);  // Set() releases ALL waiters, stays set until Reset()
new AsyncAutoResetEvent(initialState: false);    // Set() releases ONE waiter, auto-resets
//   .Set(); .Reset(); ValueTask WaitAsync(CancellationToken); ValueTask WaitAsync(TimeSpan, CancellationToken);

// AsyncReaderWriterLock — using (await rw.ReaderLockAsync(ct)) / (await rw.WriterLockAsync(ct))
```

`timeout` overloads throw `TimeoutException` when the time elapses (`TimeSpan.Zero` throws
immediately if unavailable; `Timeout.InfiniteTimeSpan` waits forever). Cancellation throws
`OperationCanceledException`. The `CancellationToken` is only observed if the primitive
cannot complete synchronously.

---

## Canonical patterns

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

private readonly AsyncLock _lock = new();
public async Task DoWorkAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct).ConfigureAwait(false))
        await ModifySharedStateAsync().ConfigureAwait(false);
}

private readonly AsyncSemaphore _sem = new(4);
public async Task FetchAsync(CancellationToken ct)
{
    await _sem.WaitAsync(ct).ConfigureAwait(false);
    try { await CallServiceAsync().ConfigureAwait(false); }
    finally { _sem.Release(); }
}
```

---

## Hard rules (the `ValueTask` contract — enforced by the analyzer)

1. **Await each returned `ValueTask` exactly once.** A second `await` or `AsTask()` throws
   `InvalidOperationException` (CHT001/CHT004).
2. **Never store a `ValueTask` in a field** (CHT003) or **capture it in a lambda/closure**
   (CHT010). Await it locally.
3. **Never block on it**: no `.Result` (CHT005), no `.GetAwaiter().GetResult()` (CHT002).
4. **Never pass it to `Task.WhenAll`/`WhenAny`** (CHT006) — call `.AsTask()` once first, or
   restructure.
5. **Always await or discard** every returned `ValueTask`/`Releaser` (CHT008), otherwise the
   pooled source never returns to the pool.
6. **`AsyncLock` is not reentrant** — re-acquiring on the same call stack deadlocks. If the
   source lock was reentrant, do **not** port it; flag it for human review.
7. There is **no** `SemaphoreSlim`-style `bool WaitAsync(timeout)`. Rewrite
   `if (await sem.WaitAsync(timeout))` to try/catch `TimeoutException` or use a token.

---

## Porting procedure

1. Add `CryptoHives.Foundation.Threading` and the `…Threading.Analyzers` package.
2. Swap primitives per the table above; keep the `using`-based release pattern.
3. Build and drive every `CHT001`–`CHT010` diagnostic to zero (do not suppress without human
   approval). Run existing tests.
4. Report: `file:line` → old type → new type; plus any reentrant locks / bool-timeout waits
   left unported for human review.

Full cross-package porting guide: <https://cryptohives.github.io/Foundation/porting-to-cryptohives.html>
