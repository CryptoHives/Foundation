# AsyncCountdownEvent

A pooled, allocation-free async countdown event that signals when a count reaches zero using ValueTask-based waiters.

## Overview

`AsyncCountdownEvent` is an async-compatible countdown synchronization primitive. It allows one or more tasks to wait until a specified number of signals have been received. It uses pooled `IValueTaskSource` instances to minimize allocations.

## Usage

### Basic Usage

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

private readonly AsyncCountdownEvent _countdown = new AsyncCountdownEvent(3);

// Coordinator waits for all workers
public async Task WaitForWorkersAsync(CancellationToken ct)
{
    await _countdown.WaitAsync(ct);
    Console.WriteLine("All workers completed!");
}

// Each worker signals when done
public void WorkerCompleted()
{
    _countdown.Signal();
}
```

### Fan-Out/Fan-In Pattern

```csharp
public async Task ProcessBatchAsync(IEnumerable<Item> items, CancellationToken ct)
{
    var itemList = items.ToList();
    var countdown = new AsyncCountdownEvent(itemList.Count);

    foreach (var item in itemList)
    {
        _ = Task.Run(async () =>
        {
            await ProcessItemAsync(item, ct);
            countdown.Signal();
        }, ct);
    }

    await countdown.WaitAsync(ct);
    Console.WriteLine("All items processed!");
}
```

### Signal and Wait

```csharp
public async Task ParticipantWorkAsync(CancellationToken ct)
{
    await DoWorkAsync();
    await _countdown.SignalAndWaitAsync(ct);
    // All participants have completed
}
```

## Constructor

```csharp
public AsyncCountdownEvent(
    int initialCount,
    bool runContinuationAsynchronously = true,
    int defaultEventQueueSize = 0,
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

| Parameter | Description |
|-----------|-------------|
| `initialCount` | The initial count. Must be greater than zero. |
| `runContinuationAsynchronously` | If true (default), continuations run on the thread pool. |
| `defaultEventQueueSize` | Initial capacity for the waiter queue. |
| `pool` | Optional custom pool for ValueTaskSource instances. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `CurrentCount` | `int` | Gets the current count remaining. |
| `InitialCount` | `int` | Gets the initial count. |
| `IsSet` | `bool` | Gets whether the count has reached zero. |
| `RunContinuationAsynchronously` | `bool` | Gets or sets whether continuations run asynchronously. |

## Methods

### WaitAsync

```csharp
public ValueTask WaitAsync(CancellationToken cancellationToken = default)
```

Asynchronously waits for the countdown to reach zero.

### Signal

```csharp
public void Signal()
public void Signal(int signalCount)
```

Decrements the countdown by one or more.

### SignalAndWaitAsync

```csharp
public ValueTask SignalAndWaitAsync(CancellationToken cancellationToken = default)
```

Signals the countdown and waits for it to reach zero.

### AddCount

```csharp
public void AddCount()
public void AddCount(int signalCount)
```

Increments the countdown.

### TryAddCount

```csharp
public bool TryAddCount(int signalCount = 1)
```

Attempts to increment the countdown. Returns false if already set.

### Reset

```csharp
public void Reset(int count = 0)
```

Resets the countdown to the specified count, or to the initial count if not specified.

## Performance

- **O(1)** signal and wait operations
- **O(n)** broadcast to all waiters when count reaches zero
- **Zero allocations** when count reaches zero with no waiters
- Pooled ValueTaskSource instances for waiters

## Benchmark Results

The following benchmarks compare `AsyncCountdownEvent` against `Nito.AsyncEx.AsyncCountdownEvent` and reference implementations.

### Signal Operation Benchmark

Measures the performance of signaling and waiting on the countdown event.

[!INCLUDE[Countdown Event Benchmark](benchmarks/asynccountdownevent-signal.md)]

### Benchmark Analysis

**Key Findings:**

1. **Signal Performance**: The `Signal()` operation is O(1) until the final signal triggers the broadcast to all waiters.

2. **Memory Efficiency**: Pooled `IValueTaskSource` instances reduce allocation pressure in repeated countdown cycles (e.g., using `Reset()` to reuse the countdown).

3. **Broadcast Overhead**: When the count reaches zero, all waiters are signaled individually. For scenarios with many waiters, consider the trade-off compared to shared `Task`-based approaches.

4. **SignalAndWaitAsync**: This combined operation is optimized for the common pattern where a participant signals and then waits for others.

**When to Choose AsyncCountdownEvent:**

- Fan-out/fan-in coordination patterns
- Batch processing with parallel workers
- Scenarios where the countdown is frequently reset and reused

## See Also

- [AsyncBarrier](asyncbarrier.md)
- [AsyncManualResetEvent](asyncmanualresetevent.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
