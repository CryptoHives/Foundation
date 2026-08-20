## 🛡️ CryptoHives Open Source Initiative 🐝

An open, community-driven collection of cryptography and performance libraries for the .NET ecosystem, maintained by **The Keepers of the CryptoHives**.

---

## 🧵 CryptoHives.Foundation.Threading

[![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)

Pooled async synchronization primitives for .NET, built to keep `Task` and `TaskCompletionSource<T>` allocations off the hot path.

## 🧱 Classes

### Synchronization Primitives

Namespace: `CryptoHives.Foundation.Threading.Async.Pooled`

| Class | Description | 
|-------|-------------|
| [AsyncLock](https://cryptohives.github.io/Foundation/packages/threading/asynclock.html) | Pooled async mutual exclusion lock
| [AsyncKeyedLock&lt;TKey&gt;](https://cryptohives.github.io/Foundation/packages/threading/asynckeyedlock.html) | Pooled per-key async exclusive lock (different keys never block each other)
| [AsyncAutoResetEvent](https://cryptohives.github.io/Foundation/packages/threading/asyncautoresetevent.html) | Pooled async auto-reset event (one waiter per signal)
| [AsyncManualResetEvent](https://cryptohives.github.io/Foundation/packages/threading/asyncmanualresetevent.html) | Pooled async manual-reset event (all waiters per signal)
| [AsyncSemaphore](https://cryptohives.github.io/Foundation/packages/threading/asyncsemaphore.html) | Pooled async semaphore with configurable permit count
| [AsyncCountdownEvent](https://cryptohives.github.io/Foundation/packages/threading/asynccountdownevent.html) | Pooled async countdown event (signals when count reaches zero)
| [AsyncBarrier](https://cryptohives.github.io/Foundation/packages/threading/asyncbarrier.html) | Pooled async barrier (synchronizes multiple participants)
| [AsyncReaderWriterLock](https://cryptohives.github.io/Foundation/packages/threading/asyncreaderwriterlock.html) | Pooled async reader-writer lock (multiple readers or single writer)

All primitives are backed by `ObjectPool<T>` and return `ValueTask<T>`, which keeps per-operation allocations out of high-throughput code paths.

### Pooling Support Classes

Namespace: `CryptoHives.Foundation.Threading.Pools`

| Class | Description | Namespace |
|-------|-------------|-----------|
| `IGetPooledManualResetValueTaskSource<T>` | Interface for obtaining pooled `IValueTaskSource<T>` implementations (providers return `PooledManualResetValueTaskSource<T>` instances)
| `ManualResetValueTaskSource<T>` | Abstract base for pooled `IValueTaskSource<T>` implementations 
| `PooledManualResetValueTaskSource<T>` | Pooled `IValueTaskSource<T>` implementation with automatic pool return 
| `LocalManualResetValueTaskSource<T>` | Object-local `IValueTaskSource<T>` without pool integration 
| `PooledValueTaskSourceObjectPolicy<T>` | Object pool policy for `PooledManualResetValueTaskSource<T>` 
| `ValueTaskSourceObjectPool<T>` | Specialized provider that implements `IGetPooledManualResetValueTaskSource<T>` and returns pooled task sources
| `ValueTaskSourceObjectPools` | Static helper with shared pool instances and constants

> **Note:** This package no longer bundles [CryptoHives.Foundation.Threading.Analyzers](https://www.nuget.org/packages/CryptoHives.Foundation.Threading.Analyzers) automatically. Install it separately if you want the Roslyn analyzers alongside the Threading library.

---

## ✨ Key Features

- **Pooled primitives** — synchronization objects backed by `Microsoft.Extensions.ObjectPool`
- **`ValueTask`-based APIs** — minimal to no allocations thanks to object pooling; pooled primitives retain a bounded number of objects, so allocation-free behaviour holds while the workload fits the pool (see [Sizing the caches](#sizing-the-caches) for `AsyncKeyedLock<TKey>`, the one primitive where the bound is worth sizing deliberately)
- **`CancellationToken` support** — full cancellation across all primitives, allocation-free on modern .NET
- **`ConfigureAwait` support** — works naturally with `.ConfigureAwait(false)` in library code
- **Timeouts** — every lock acquisition method accepts a timeout; a timed-out wait throws `TimeoutException`, a cancelled one throws `OperationCanceledException`
- **Configurable continuations** — control whether continuations run synchronously or asynchronously
- **Custom pools** — supply your own `IGetPooledManualResetValueTaskSource<T>` (or `ObjectPool<T>`) for fine-grained control
- **Drop-in replacement** — swap the namespace, keep the same `using`-based patterns
- **Optional analyzers** — ValueTask misuse caught at compile time via the separate `Threading.Analyzers` package

---

## 📥 Installation

```bash
dotnet add package CryptoHives.Foundation.Threading
```

---

## 💡 Quick Examples

### Mutual Exclusion — `AsyncLock`

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

private readonly AsyncLock _lock = new();

public async Task DoWorkAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct).ConfigureAwait(false))
    {
        // Critical section — only one task at a time
        await ModifySharedStateAsync().ConfigureAwait(false);
    }
}
```

### Per-Key Exclusion — `AsyncKeyedLock<TKey>`

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

#### Sizing the caches

`AsyncKeyedLock<TKey>` is allocation-free while a workload fits inside two caps, and degrades
gracefully — not catastrophically — past either. Both default to `128`.

| Cap | Bounds | Past the cap |
|-----|--------|--------------|
| `maxIdleEntries` | **key cardinality** — the keys that are hot at the same time | Each acquisition of an unmapped key takes over the least recently idled entry and allocates a fresh dictionary node (~48 B/key). The entry itself is still reused. |
| `maxRetainedWaiters` | **simultaneous contention** — waiters queued at one moment, summed across all keys | Each waiter beyond the cap is allocated and then discarded rather than returned to the pool. |

A released key stays mapped as an *idle* entry rather than being torn down, so locking and releasing
the same key repeatedly allocates **nothing at all**. That is what makes the common case free — and
it is also why `maxIdleEntries` should span the hot key set rather than the total number of distinct
keys ever seen. Retention is bounded by the keys actually used, so a generous cap costs a lock with
few keys nothing.

Each entry supplies one waiter itself and the pool covers the rest, so a lock with 4 keys and 100
waiters behind each needs 396 pooled waiters — at the default, such a burst allocates on 268 of them.

```csharp
// Sized to the workload: ~2000 hot tenants, up to ~500 waiters queued at peak
private readonly AsyncKeyedLock<string> _locksByTenant =
    new(maxIdleEntries: 2048, maxRetainedWaiters: 512);
```

> **Note:** the default waiter pool is shared process-wide per closed `TKey`, so every
> `AsyncKeyedLock<string>` in the process draws on one budget. Passing `maxRetainedWaiters` is also
> what gives an instance a private pool.

### Producer-Consumer — `AsyncAutoResetEvent`

```csharp
private readonly AsyncAutoResetEvent _itemReady = new(initialState: false);
private readonly Queue<Item> _queue = new();

// Producer
public void Enqueue(Item item)
{
    _queue.Enqueue(item);
    _itemReady.Set(); // Releases exactly one waiter
}

// Consumer
public async Task<Item> DequeueAsync(CancellationToken ct)
{
    await _itemReady.WaitAsync(ct).ConfigureAwait(false);
    return _queue.Dequeue();
}
```

### Broadcast — `AsyncManualResetEvent`

```csharp
private readonly AsyncManualResetEvent _ready = new(set: false);

public async Task InitializeAsync()
{
    await LoadConfigurationAsync().ConfigureAwait(false);
    _ready.Set(); // All waiters are released at once
}

public async Task UseServiceAsync(CancellationToken ct)
{
    await _ready.WaitAsync(ct).ConfigureAwait(false);
    // Service is initialized
}
```

### Bounded Concurrency — `AsyncSemaphore`

```csharp
private readonly AsyncSemaphore _semaphore = new(initialCount: 4);

public async Task FetchAsync(CancellationToken ct)
{
    await _semaphore.WaitAsync(ct).ConfigureAwait(false);
    try
    {
        await CallExternalServiceAsync().ConfigureAwait(false);
    }
    finally
    {
        _semaphore.Release();
    }
}
```

### Read-Write Separation — `AsyncReaderWriterLock`

```csharp
private readonly AsyncReaderWriterLock _rwLock = new();

public async Task<Data> ReadAsync(CancellationToken ct)
{
    using (await _rwLock.ReaderLockAsync(ct).ConfigureAwait(false))
        return _cache.Get();
}

public async Task WriteAsync(Data data, CancellationToken ct)
{
    using (await _rwLock.WriterLockAsync(ct).ConfigureAwait(false))
        _cache.Set(data);
}
```

### Custom Pool

```csharp
using CryptoHives.Foundation.Threading.Pools;

var policy = new PooledValueTaskSourceObjectPolicy<bool>();
var pool   = new ValueTaskSourceObjectPool<bool>(policy, maximumRetained: 64);

var evt = new AsyncAutoResetEvent(
    initialState: false,
    runContinuationAsynchronously: true,
    pool: pool);
```

---

## 📋 ValueTask Contract

1. **Await a `ValueTask` exactly once.** A second `await` or `AsTask()` call may throw `InvalidOperationException`.
2. **Avoid calling `AsTask()` before the primitive signals.** With `RunContinuationsAsynchronously=true` (the default), storing the result of `AsTask()` too early causes a severe performance hit. Await the `ValueTask` directly wherever you can.
3. **Always await or discard a waiter.** If it's left unconsumed, the underlying `IValueTaskSource` never makes it back to the pool.

The separate **Threading.Analyzers** package enforces these rules at compile time.

---

## 📚 Documentation

| Resource | Link |
|----------|------|
| Full package documentation | [cryptohives.github.io/Foundation/packages/threading](https://cryptohives.github.io/Foundation/packages/threading/index.html) |
| API reference | [cryptohives.github.io/…/api/…Threading.Async.Pooled](https://cryptohives.github.io/Foundation/api/CryptoHives.Foundation.Threading.Async.Pooled.html) |
| Benchmarks | [cryptohives.github.io/Foundation/packages/threading/benchmarks](https://cryptohives.github.io/Foundation/packages/threading/benchmarks.html) |
| Threading.Analyzers | [cryptohives.github.io/Foundation/packages/threading.analyzers](https://cryptohives.github.io/Foundation/packages/threading.analyzers/index.html) |
| Source repository | [github.com/CryptoHives/Foundation](https://github.com/CryptoHives/Foundation) |

---

## 🚨 Security Policy

If you discover a vulnerability, please don't open a public issue — follow the process on the [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md) instead.

---

## ⚖️ License

MIT — © 2026 The Keepers of the CryptoHives
