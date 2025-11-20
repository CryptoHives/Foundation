# CryptoHives.Foundation.Threading Package

The Threading package provides high-performance, pooled async synchronization primitives for .NET applications.

## Overview

This package contains async synchronization primitives that use object pooling to minimize allocations in high-throughput scenarios. All synchronization primitives leverage `ValueTask` and `IValueTaskSource` for efficient async operations.

## Key Features

- **Pooled Primitives**: Synchronization objects backed by object pools
- **ValueTask-based**: Low-allocation async operations
- **High Performance**: Optimized for concurrent access patterns
- **Thread-safe**: All operations are thread-safe

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
1. RunContinuationsAsynchronously is by default true. In rare cases perf degradation may occur if the ValueTask is not immediately awaited (see benchmarks).
3. **Pool Exhaustion**: In extreme high-throughput scenarios with many waiters, the pool may exhaust. Monitor and adjust usage patterns accordingly.
4. Always await a ValueTask or AsTask() waiter primitive, or the ValueTaskSource is not returned to the pool.

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
- ValueTask-based APIs avoid Task allocations when operations complete synchronously
- Minimal allocation overhead for async state machines

### High Throughput

- Optimized for high-contention scenarios
- Lock-free operations where possible
- Efficient wake-up mechanisms

### Compatibility

- Works with async/await patterns
- Cancellation token support
- ConfigureAwait support

## Performance Characteristics

- **AsyncLock**: O(1) acquire when uncontended, FIFO queue for waiters
- **AsyncAutoResetEvent**: O(1) Set/Wait, single waiter release
- **AsyncManualResetEvent**: O(n) Set, O(1) Reset, broadcast to all n waiters

## Best Practices

1. **Reuse instances**: Create synchronization primitives once and reuse them
2. **Use cancellation**: Always pass CancellationToken for long waits
3. **Avoid holding locks**: Keep critical sections as short as possible
4. **Dispose properly**: Dispose instances when done to release pooled resources
5. **ConfigureAwait(false)**: Use in library code to avoid context capture

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
