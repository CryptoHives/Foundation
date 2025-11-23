# CryptoHives.Foundation.Threading Package

## Overview

The Threading package provides high-performance, pooled async synchronization primitives for .NET applications with high throughput workloads, where many small memory allocations matter. All synchronization primitives leverage `ValueTask` and pooled `IValueTaskSource` for efficient async operations. They are not meant to replace but to complement existing popular async libraries.

There are already a number of popular async synchronization libraries available for .NET, but many of these incur significant memory allocations under high contention due to per-waiter `Task` and `TaskCompletionSource` allocations.
In recent years, the introduction of `ValueTask` and `IValueTaskSource` has enabled the creation of low-allocation async primitives that can be pooled and reused to minimize allocations in high-throughput scenarios.
This library is the result of the research done by the Keepers of the CryptoHives into building efficient, pooled async synchronization primitives that leverage these modern .NET features.
By demand, more might be added in the future.

## Key Features

- **Pooled Primitives**: Synchronization objects backed by object pools
- **ValueTask-based**: Low-allocation async operations
- **High Performance**: Optimized for concurrent access patterns
- **Thread-safe**: All operations are thread-safe
- **Ease of use**: Drop in replacemnet to replace other popular libraries by changing the namespace

## Installation

```bash
dotnet add package CryptoHives.Foundation.Threading
```

## Namespace

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;
```

## Classes

### Synchronization Primitives

| Class | Description | Documentation |
|-------|-------------|---------------|
| [AsyncLock](asynclock.md) | Pooled async mutual exclusion lock | [Details](asynclock.md) |
| [AsyncAutoResetEvent](asyncautoresetevent.md) | Pooled async auto-reset event | [Details](asyncautoresetevent.md) |
| [AsyncManualResetEvent](asyncmanualresetevent.md) | Pooled async manual-reset event | [Details](asyncmanualresetevent.md) |

### Internal Support Classes

| Class | Description |
|-------|-------------|
| ManualResetValueTaskSource&lt;T&gt; | Abstract base for pooled task sources |
| PooledManualResetValueTaskSource&lt;T&gt; | Pooled IValueTaskSource implementation |
| LocalManualResetValueTaskSource&lt;T&gt; | Object-local task source |
| PooledValueTaskSourceObjectPolicy&lt;T&gt; | Object pool policy for task sources |

## ⚠️ Known Issues and Caveats

1. Strictly only **await a ValueTask once**. An additional await or AsTask() may throw an InvalidOperationException.
2. Strictly only **use AsTask() once**, and only if you have to. An additional await or AsTask() may throw an InvalidOperationException.
1. **RunContinuationsAsynchronously** is by default enabled. In rare cases perf degradation may occur if the Task derived from a ValueTask is not immediately awaited (see benchmarks).
3. **Pool Exhaustion**: In extreme high-throughput scenarios with many waiters, the pool may exhaust. Monitor and adjust usage patterns accordingly.
4. Always await a ValueTask or AsTask() waiter primitive, or the IValueTaskSource is not returned to the pool.

## Benchmarks

Microbenchmarks and contention tests with a discussion of the performance characteristics are available to validate performance and allocation characteristics.

Please be aware that not all new replacement classes behave better than existing popular implementations in all scenarios; 
For example the `AsyncManualResetEvent` implementation has an overhead of a IValueTaskSource per waiter, because ValueTask cannot be awaited by multiple instances. In contrary to a Task based implementation all waiters can share the same wake up Task and TaskCompletionSource.

See the Benchmarks overview:

- [Benchmarks Overview](benchmarks.md)

Run reports are available under:
- `tests/Threading/BenchmarkDotNet.Artifacts/results/`

## Quick Examples

### AsyncLock

```csharp
private readonly AsyncLock _lock = new AsyncLock();

public async Task AccessSharedResourceAsync()
{
    using (await _lock.LockAsync())
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
public async Task ConsumeAsync()
{
    await _event.WaitAsync(); // Wait for signal
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
public async Task WaitForReadyAsync()
{
    await _event.WaitAsync(); // Multiple tasks can wait
    await DoWorkAsync();
}
```

## Benefits

### Reduced Allocations

- Reuses `IValueTaskSource` instances from object pools
- ValueTask-based APIs avoid Task allocations when operations complete asynchronously
- Best case no allocation overhead for async state machines

### High Throughput

- Optimized for high-contention scenarios
- Lock-free operations where possible

### Compatibility

- Works with async/await patterns
- Cancellation token support
- ConfigureAwait support

## Performance Characteristics

- **AsyncLock**: O(1) acquire when uncontended, FIFO queue for waiters
- **AsyncAutoResetEvent**: O(1) Set/Wait, FIFO queue for single waiter release
- **AsyncManualResetEvent**: O(n) Set broadcast to all n waiters, O(1) Reset

## Best Practices

1. **Determine benefits**: Are pooled primitives and ValueTask beneficial for your workload?
1. **Reuse instances**: Create synchronization primitives once and reuse them
2. **Do not reuse ValueTask**: Always await or AsTask() only once per ValueTask instance
3. **Always Await ValueTask and Task**: If not awaited, resources are not returned to the pool
3. **Avoid holding locks**: Keep critical sections as short as possible
4. **Dispose properly**: Dispose instances when done to release pooled resources
5. **Use cancellation**: Always pass CancellationToken for long waits (planned)
6. **ConfigureAwait(false)**: Use in library code to avoid context capture

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

public async Task UseServiceAsync()
{
    await _initialized.WaitAsync();
    // Service is now initialized
}
```

### Rate Limiting

```csharp
private readonly AsyncLock _rateLimiter = new AsyncLock();

public async Task<T> RateLimitedOperationAsync<T>(Func<Task<T>> operation)
{
    using (await _rateLimiter.LockAsync())
    {
        await Task.Delay(100); // Rate limit
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
| Performance | Optimized | Standard |

## See Also

- [API Reference](../../api/CryptoHives.Foundation.Threading.Async.Pooled.html)
- [Memory Package](../memory/index.md)

---

© 2025 The Keepers of the CryptoHives
