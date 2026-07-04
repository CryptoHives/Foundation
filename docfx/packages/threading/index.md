# CryptoHives.Foundation.Threading Package

## Overview

The Threading package provides pooled, `ValueTask`-based async synchronization primitives for .NET applications where high-throughput workloads make per-waiter allocations matter. They're meant to complement the existing async synchronization libraries for .NET, not replace them.

Most popular async synchronization libraries allocate a `Task` and/or `TaskCompletionSource` per waiter, and cancellation handling often adds more. `ValueTask` and `IValueTaskSource`, introduced a few years ago, make it possible to build low-allocation primitives that can be pooled and reused instead. This library is what came out of the Keepers of the CryptoHives digging into that approach. More primitives may get added as the need comes up.

## Core Guarantees

- **Pooled primitives** — synchronization objects backed by object pools
- **`ValueTask`-based** — low-allocation async operations
- **Thread-safe** — every operation is safe under concurrent access, using interlocked state transitions
- **Drop-in replacement** — swap the namespace to migrate from other popular libraries
- **Cancellation support** — full `CancellationToken` support across all primitives
- **Timeout support** — optional timeout parameters on every lock acquisition method
- **Configurable continuations** — control synchronous vs. asynchronous continuation execution
- **Custom object pools** — supply your own for fine-grained control
- **Optional analyzers** — Roslyn analyzers that catch common `ValueTask` misuse at compile time

## Installation

```bash
dotnet add package CryptoHives.Foundation.Threading
```

> **Note:** This package does not include [Threading Analyzers](../threading.analyzers/index.md) automatically.

## Namespaces

### Async Synchronization Primitives

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;
```

### Pooling Infrastructure

```csharp
using CryptoHives.Foundation.Threading.Pools;
```

## Classes

### Synchronization Primitives

| Class | Description | Documentation |
|-------|-------------|---------------|
| [AsyncLock](asynclock.md) | Pooled async mutual exclusion lock | [Details](asynclock.md) |
| [AsyncAutoResetEvent](asyncautoresetevent.md) | Pooled async auto-reset event (one waiter per signal) | [Details](asyncautoresetevent.md) |
| [AsyncManualResetEvent](asyncmanualresetevent.md) | Pooled async manual-reset event (all waiters per signal) | [Details](asyncmanualresetevent.md) |
| [AsyncSemaphore](asyncsemaphore.md) | Pooled async semaphore with configurable permit count | [Details](asyncsemaphore.md) |
| [AsyncCountdownEvent](asynccountdownevent.md) | Pooled async countdown event (signals when count reaches zero) | [Details](asynccountdownevent.md) |
| [AsyncBarrier](asyncbarrier.md) | Pooled async barrier (synchronizes multiple participants) | [Details](asyncbarrier.md) |
| [AsyncReaderWriterLock](asyncreaderwriterlock.md) | Pooled async reader-writer lock (multiple readers or single writer) | [Details](asyncreaderwriterlock.md) |

### Pooling Support Classes

| Class | Description | Namespace |
|-------|-------------|-----------|
| `IGetPooledManualResetValueTaskSource<T>` | Interface to get pooled `IValueTaskSource<T>` implementations (providers return `PooledManualResetValueTaskSource<T>` instances) | `CryptoHives.Foundation.Threading.Pools` |
| `ManualResetValueTaskSource<T>` | Abstract base for pooled `IValueTaskSource<T>` implementations | `CryptoHives.Foundation.Threading.Pools` |
| `PooledManualResetValueTaskSource<T>` | Pooled `IValueTaskSource<T>` implementation with automatic pool return | `CryptoHives.Foundation.Threading.Pools` |
| `LocalManualResetValueTaskSource<T>` | Object-local `IValueTaskSource<T>` without pool integration | `CryptoHives.Foundation.Threading.Pools` |
| `PooledValueTaskSourceObjectPolicy<T>` | Object pool policy for `PooledManualResetValueTaskSource<T>` | `CryptoHives.Foundation.Threading.Pools` |
| `ValueTaskSourceObjectPool<T>` | Specialized provider that implements `IGetPooledManualResetValueTaskSource<T>` and returns pooled task sources | `CryptoHives.Foundation.Threading.Pools` |
| `ValueTaskSourceObjectPools` | Static helper with shared pool instances and constants | `CryptoHives.Foundation.Threading.Pools` |

## Known Issues and Caveats

1. **Await a `ValueTask` exactly once.** A second `await` or `AsTask()` call may throw `InvalidOperationException`.
2. **Use `AsTask()` at most once, and only when you actually need a `Task`.** Beyond the same `InvalidOperationException` risk, it also adds a `Task` allocation under contention.
3. **Pool exhaustion.** Under extreme concurrency with many waiters, the pool can run dry. Watch usage patterns and adjust, or supply a custom pool if needed.
4. **Always await.** If a `ValueTask` or `Task` waiter isn't awaited, its underlying `IValueTaskSource` never makes it back to the pool — that's a leak.

## Performance Characteristics

- Synchronization objects are backed by object pools to keep GC pressure down.
- `ValueTask`-based operations avoid heap allocation on the fast path.
- Uncontended access uses lock-free atomic operations.
- Continuations run via `RunContinuationsAsynchronously` by default, to avoid deadlocks.

Not every primitive here beats its popular-library equivalent in every scenario — most of the time it does, but there are exceptions. `AsyncManualResetEvent`, for instance, pays for one `IValueTaskSource` per waiter because a single `ValueTask` can't be awaited by more than one caller. A `Task`-based implementation can let every waiter share the same underlying `Task`/`TaskCompletionSource` instead.

See the [Benchmarks overview](benchmarks.md) for numbers. Raw run reports live under `tests/Threading/BenchmarkDotNet.Artifacts/results/`.

## Quick Examples

### AsyncLock

```csharp
private readonly AsyncLock _lock = new AsyncLock();

public async Task AccessSharedResourceAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct))
    {
        // Critical section - only one task at a time
        await ModifySharedStateAsync();
    }
}
```

### AsyncAutoResetEvent

```csharp
private readonly AsyncAutoResetEvent _event = new AsyncAutoResetEvent(false);

// Producer
public async Task ProduceAsync()
{
    await ProduceItemAsync();
    _event.Set(); // Signal one waiter
}

// Consumer
public async Task ConsumeAsync(CancellationToken ct)
{
    await _event.WaitAsync(ct); // Wait for signal
    await ProcessItemAsync();
}
```

### AsyncManualResetEvent

```csharp
private readonly AsyncManualResetEvent _event = new AsyncManualResetEvent(false);

// Controller
public void SignalReady()
{
    _event.Set(); // Signal all waiters
}

// Worker
public async Task WaitForReadyAsync(CancellationToken ct)
{
    await _event.WaitAsync(ct); // Multiple tasks can wait
    await DoWorkAsync();
}
```

### AsyncSemaphore

```csharp
private readonly AsyncSemaphore _semaphore = new AsyncSemaphore(3);

// Limited concurrent access
public async Task AccessLimitedResourceAsync(CancellationToken ct)
{
    await _semaphore.WaitAsync(ct);
    try
    {
        // Max 3 concurrent tasks can access this section
        await AccessResourceAsync();
    }
    finally
    {
        _semaphore.Release();
    }
}
```

### AsyncCountdownEvent

```csharp
private readonly AsyncCountdownEvent _countdown = new AsyncCountdownEvent(3);

// Coordinator
public async Task WaitForWorkersAsync(CancellationToken ct)
{
    await _countdown.WaitAsync(ct);
    // All workers have signaled
}

// Worker
public void WorkerCompleted()
{
    _countdown.Signal();
}
```

### AsyncBarrier

```csharp
private readonly AsyncBarrier _barrier = new AsyncBarrier(3);

// Participant
public async Task ParticipantWorkAsync(CancellationToken ct)
{
    await DoPhase1WorkAsync();
    await _barrier.SignalAndWaitAsync(ct); // Wait for all participants
    await DoPhase2WorkAsync();
}
```

### AsyncReaderWriterLock

```csharp
private readonly AsyncReaderWriterLock _rwLock = new AsyncReaderWriterLock();

// Reader
public async Task ReadAsync(CancellationToken ct)
{
    using (await _rwLock.ReaderLockAsync(ct))
    {
        // Multiple readers can hold the lock concurrently
        await ReadDataAsync();
    }
}

// Writer
public async Task WriteAsync(CancellationToken ct)
{
    using (await _rwLock.WriterLockAsync(ct))
    {
        // Exclusive access
        await WriteDataAsync();
    }
}
```

## Timeout Support

Every synchronization primitive accepts an optional timeout, so you can attempt a non-blocking acquire or build timeout-based retry logic instead of waiting indefinitely:

```csharp
// Non-blocking attempt using TimeSpan.Zero
try
{
    using (await _lock.LockAsync(TimeSpan.Zero))
    {
        await DoWorkAsync();
    }
}
catch (TimeoutException)
{
    // Lock not immediately available
}
```

```csharp
// Timeout-based acquisition with retry
private readonly AsyncLock _lock = new AsyncLock();

public async Task<bool> TryAcquireWithRetryAsync(TimeSpan timeout, int maxRetries, CancellationToken ct)
{
    for (int i = 0; i < maxRetries; i++)
    {
        try
        {
            using (await _lock.LockAsync(timeout, ct))
            {
                return await PerformWorkAsync();
            }
        }
        catch (TimeoutException) when (i < maxRetries - 1)
        {
            // Timeout occurred, retry
            continue;
        }
    }
    return false; // All retries exhausted
}
```

## Performance Characteristics by Primitive

- **AsyncLock**: O(1) acquire when uncontended, FIFO queue for waiters
- **AsyncAutoResetEvent**: O(1) Set/Wait, FIFO queue for single waiter release
- **AsyncManualResetEvent**: O(n) Set broadcast to all n waiters, O(1) Reset

## Best Practices

1. Confirm pooled primitives and `ValueTask` actually help your workload before switching — they shine under high throughput, less so at low concurrency (see the architecture caveats above).
2. Create synchronization primitives once and reuse them rather than constructing per call.
3. Await or call `AsTask()` on each `ValueTask` exactly once — never both, never twice.
4. Always await a `ValueTask`/`Task` waiter; otherwise its resources never return to the pool.
5. Keep critical sections short — don't hold a lock across unrelated work.
6. Pass a `CancellationToken` for any wait that could be long — the check is nearly free.
7. Use `ConfigureAwait(false)` in library code to avoid capturing the sync context.
8. Don't call `AsTask()` before the primitive signals when `RunContinuationAsynchronously=true` — it causes a severe performance hit.

## Common Patterns

### Producer-Consumer

```csharp
private readonly AsyncAutoResetEvent _itemAvailable = new AsyncAutoResetEvent(false);
private readonly Queue<Item> _queue = new();

public async Task ProducerAsync(Item item)
{
    _queue.Enqueue(item);
    _itemAvailable.Set();
}

public async Task<Item> ConsumerAsync(CancellationToken ct)
{
    await _itemAvailable.WaitAsync(ct);
    return _queue.Dequeue();
}
```

### Async Initialization

```csharp
private readonly AsyncManualResetEvent _initialized = new AsyncManualResetEvent(false);

public async Task InitializeAsync()
{
    await DoInitializationAsync();
    _initialized.Set();
}

public async Task UseServiceAsync(CancellationToken ct)
{
    await _initialized.WaitAsync(ct);
    // Service is now initialized
}
```

### Rate Limiting

```csharp
private readonly AsyncLock _rateLimiter = new AsyncLock();

public async Task<T> RateLimitedOperationAsync<T>(Func<Task<T>> operation, CancellationToken ct)
{
    using (await _rateLimiter.LockAsync(ct))
    {
        await Task.Delay(100, ct); // Rate limit
        return await operation();
    }
}
```

## Comparison with Standard Library

| Feature | Threading Package | System.Threading |
|---------|-------------------|------------------|
| Allocation overhead | Minimal (pooled) | Higher (per operation) |
| ValueTask support | Yes | Partial |
| Pooling | Built-in | Manual |
| Performance | Optimized for high-throughput | Standard |
| Cancellation | Full support | Varies |

## Advanced: Custom Pooling

You can supply your own provider implementing `IGetPooledManualResetValueTaskSource<T>` for fine-grained control over pool behavior. The built-in `ValueTaskSourceObjectPool<T>` already implements this interface and can be used directly.

```csharp
using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;

// Create a custom pool provider (ValueTaskSourceObjectPool implements IGetPooledManualResetValueTaskSource<T>)
var customPolicy = new PooledValueTaskSourceObjectPolicy<bool>();
var customPool = new ValueTaskSourceObjectPool<bool>(customPolicy, maximumRetained: 64);

// Use custom provider with event
var evt = new AsyncAutoResetEvent(
    initialState: false,
    runContinuationAsynchronously: true,
    pool: customPool); // accepts any IGetPooledManualResetValueTaskSource<bool>
```

## ValueTaskSource Details

`ManualResetValueTaskSource<T>` (abstract base) provides:
- `Version` for versioning support
- `RunContinuationsAsynchronously` to control continuation scheduling
- `CancellationToken` and `CancellationTokenRegistration` for cancellation support
- `SetResult()` / `SetException()` for completion
- `TryReset()` for pool reuse

`PooledManualResetValueTaskSource<T>` (sealed implementation):
- Returns to the pool automatically after `GetResult()` is called
- Integrates with `IResettable` for pool compatibility
- Manages the cancellation token registration lifecycle

## See Also

- [Threading Analyzers](../threading.analyzers/index.md) — Roslyn analyzers for detecting ValueTask misuse
- [Memory Package](../memory/index.md)
- [AsyncAutoResetEvent](asyncautoresetevent.md)
- [AsyncManualResetEvent](asyncmanualresetevent.md)
- [AsyncReaderWriterLock](asyncreaderwriterlock.md)
- [AsyncLock](asynclock.md)
- [AsyncCountdownEvent](asynccountdownevent.md)
- [AsyncBarrier](asyncbarrier.md)
- [AsyncSemaphore](asyncsemaphore.md)
- [Benchmarks](benchmarks.md)

---

© 2026 The Keepers of the CryptoHives
