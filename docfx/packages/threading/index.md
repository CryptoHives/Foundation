# CryptoHives.Foundation.Threading Package

## Overview

The Threading package provides high-performance, pooled async synchronization primitives for .NET applications with high throughput workloads, where many small memory allocations matter. All synchronization primitives leverage `ValueTask` and pooled `IValueTaskSource` for efficient async operations. They are not meant to replace but to complement existing popular async libraries.

There are already a number of popular async synchronization libraries available for .NET, but many of these incur significant memory allocations under high contention due to per-waiter `Task` and `TaskCompletionSource` allocations or cancellation handling.
In recent years, the introduction of `ValueTask` and `IValueTaskSource` has enabled the creation of low-allocation async primitives that can be pooled and reused to minimize allocations in high-throughput scenarios.
This library is the result of the research done by the *Keepers of the CryptoHives* into building efficient, pooled async synchronization primitives that leverage these modern .NET features.
By demand, more primitives might be added in the future.

## Key Features

- **Pooled Primitives**: Synchronization objects backed by object pools
- **ValueTask-based**: Low-allocation async operations
- **High Performance**: Optimized for concurrent access patterns
- **Thread-safe**: All operations are thread-safe
- **Ease of use**: Drop-in replacement to replace other popular libraries by changing the namespace
- **Cancellation support**: Full `CancellationToken` support across all primitives
- **Configurable continuations**: Control synchronous vs asynchronous continuation execution
- **Custom ObjectPools**: Supply your own object pools for fine-grained control
- **Included Analyzers**: Roslyn analyzers automatically detect common ValueTask misuse patterns

## Installation

```bash
dotnet add package CryptoHives.Foundation.Threading
```

> **Note:** This package includes [Threading Analyzers](../threading.analyzers/index.md) automatically. The analyzers are transitive, so any project that references a project using this package will also benefit from the ValueTask misuse detection at compile time.

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

## ⚠️ Known Issues and Caveats

1. Strictly only **await a ValueTask once**. An additional await or AsTask() may throw an `InvalidOperationException`.
2. Strictly only **use AsTask() once**, and only if you have to. An additional await or AsTask() may throw an `InvalidOperationException`. Adds also a Task allocation on contention.
3. **RunContinuationsAsynchronously** is by default enabled. In rare cases perf degradation may occur if the Task derived from a ValueTask is not immediately awaited (see benchmarks).
4. **Pool Exhaustion**: In extreme high-throughput scenarios with many waiters, the pool may exhaust. Monitor and adjust usage patterns accordingly. Use a custom pool if necessary.
5. Always await a ValueTask or AsTask() waiter primitive, or the `IValueTaskSource` is not returned to the pool.
6. **AsTask() Performance Warning**: When `RunContinuationAsynchronously=true` (default), storing the result of `AsTask()` before signaling causes severe performance degradation (10x-100x slower). Always await `ValueTask` directly when possible.

## Benchmarks

Microbenchmarks and contention tests with a discussion of the performance characteristics are available to validate performance and allocation characteristics.

Please be aware that not all new replacement classes behave better than existing popular implementations in all scenarios; But most of the time they do.

For example the `AsyncManualResetEvent` implementation has an overhead of a `IValueTaskSource` per waiter, because `ValueTask` cannot be awaited by multiple instances. In contrast to a Task-based implementation all waiters can share the same wake-up Task and `TaskCompletionSource`.

See the Benchmarks overview:

- [Benchmarks Overview](benchmarks.md)

Run reports are stored under:
- `tests/Threading/BenchmarkDotNet.Artifacts/results/`

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

## Benefits

### Reduced Allocations

- Reuses `IValueTaskSource` instances from object pools
- ValueTask-based APIs avoid Task allocations when operations complete synchronously
- Best case: zero allocation overhead for async state machines
- On latest .NET versions cancellation token registration is allocation free

### High Throughput

- Optimized for high-contention scenarios
- Lock-free operations where possible
- Configurable continuation scheduling

### Compatibility

- Drop in replacement of existing libraries by changing namespace
- Works with async/await patterns
- Cancellation token support
- ConfigureAwait support

## Performance Characteristics

- **AsyncLock**: O(1) acquire when uncontended, FIFO queue for waiters
- **AsyncAutoResetEvent**: O(1) Set/Wait, FIFO queue for single waiter release
- **AsyncManualResetEvent**: O(n) Set broadcast to all n waiters, O(1) Reset

## Best Practices

1. **Determine benefits**: Are pooled primitives and ValueTask beneficial for your workload?
2. **Reuse instances**: Create synchronization primitives once and reuse them
3. **Do not reuse ValueTask**: Always await or AsTask() only once per ValueTask instance
4. **Always Await ValueTask and Task**: If not awaited, resources are not returned to the pool
5. **Avoid holding locks**: Keep critical sections as short as possible
6. **Use cancellation**: Always pass CancellationToken for long waits
7. **ConfigureAwait(false)**: Use in library code to avoid context capture
8. **Avoid AsTask() before signaling**: When `RunContinuationAsynchronously=true`, this causes severe performance degradation

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

You can provide a custom provider that implements `IGetPooledManualResetValueTaskSource<T>` for fine-grained control over pool behavior. The built-in `ValueTaskSourceObjectPool<T>` implements this interface and can be used directly.

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

The `ManualResetValueTaskSource<T>` abstract base class provides:
- `Version` property for versioning support
- `RunContinuationsAsynchronously` property to control continuation scheduling
- `CancellationToken` and `CancellationTokenRegistration` for cancellation support
- `SetResult()` and `SetException()` for completion
- `TryReset()` for pool reuse

The `PooledManualResetValueTaskSource<T>` sealed implementation:
- Automatically returns to pool after `GetResult()` is called
- Integrates with `IResettable` for pool compatibility
- Manages cancellation token registration lifecycle

## See Also

- [Threading Analyzers](../threading.analyzers/index.md) - Roslyn analyzers for detecting ValueTask misuse
- [Memory Package](../memory/index.md)
- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncManualResetEvent](asyncmanualresetevent.md) - Manual-reset event variant
- [AsyncReaderWriterLock](asyncreaderwriterlock.md) - Async reader-writer lock
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [AsyncCountdownEvent](asynccountdownevent.md) - Async countdown event
- [AsyncBarrier](asyncbarrier.md) - Async barrier synchronization primitive
- [AsyncSemaphore](asyncsemaphore.md) - Async semaphore primitive
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
