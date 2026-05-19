## 🛡️ CryptoHives Open Source Initiative 🐝

An open, community-driven cryptography and performance library collection for the .NET ecosystem,
developed and maintained by **The Keepers of the CryptoHives**.

---

## CryptoHives.Foundation.Threading

[![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)

High-performance, pooled async synchronization primitives for .NET — designed to eliminate `Task` and `TaskCompletionSource<T>` allocations on the hot path.

All primitives are backed by `ObjectPool<T>` and return `ValueTask<T>` to minimize per-operation allocations in high-throughput scenarios.

> **Included:** This package automatically bundles [CryptoHives.Foundation.Threading.Analyzers](https://www.nuget.org/packages/CryptoHives.Foundation.Threading.Analyzers) — Roslyn analyzers that detect common `ValueTask` misuse patterns at compile time, applied transitively to all consumers.

---

## 📦 Installation

```bash
dotnet add package CryptoHives.Foundation.Threading
```

---

## ✨ Key Features

- **Pooled primitives** — synchronization objects backed by `Microsoft.Extensions.ObjectPool`
- **`ValueTask`-based APIs** — avoid `Task` allocations when operations complete synchronously
- **`CancellationToken` support** — full cancellation across all primitives, allocation-free on modern .NET
- **`ConfigureAwait` support** — works naturally with `.ConfigureAwait(false)` in library code
- **Configurable continuations** — control synchronous vs. asynchronous continuation scheduling
- **Custom pools** — supply your own `IGetPooledManualResetValueTaskSource<T>` for fine-grained control
- **Drop-in replacement** — change namespace, keep the same `using`-based patterns
- **Included analyzers** — ValueTask misuse caught at compile time

---

## 🚀 Quick Examples

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
private readonly AsyncManualResetEvent _ready = new(initialState: false);

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

## ⚠️ ValueTask Contract

1. **Await a `ValueTask` exactly once** — multiple `await` or `AsTask()` calls may throw `InvalidOperationException`.
2. **Avoid `AsTask()` before signaling** — when `RunContinuationsAsynchronously=true` (the default), storing the result of `AsTask()` before the primitive is signaled causes severe performance degradation. Await the `ValueTask` directly wherever possible.
3. **Always await or discard** — if a waiter is not consumed, the underlying `IValueTaskSource` is not returned to the pool.

The included **Threading.Analyzers** enforce these rules automatically at compile time.

---

## 📚 Documentation

| Resource | Link |
|----------|------|
| Full package documentation | [cryptohives.github.io/Foundation/packages/threading](https://cryptohives.github.io/Foundation/packages/threading/index.html) |
| API reference | [cryptohives.github.io/Foundation/api](https://cryptohives.github.io/Foundation/api/index.html) |
| Benchmarks | [cryptohives.github.io/Foundation/packages/threading/benchmarks](https://cryptohives.github.io/Foundation/packages/threading/benchmarks.html) |
| Threading.Analyzers | [cryptohives.github.io/Foundation/packages/threading.analyzers](https://cryptohives.github.io/Foundation/packages/threading.analyzers/index.html) |
| Source repository | [github.com/CryptoHives/Foundation](https://github.com/CryptoHives/Foundation) |

---

## 🔐 Security Policy

If you discover a vulnerability, **please do not open a public issue.**
Follow the guidelines on the [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md).

---

## ⚖️ License

MIT — © 2026 The Keepers of the CryptoHives
