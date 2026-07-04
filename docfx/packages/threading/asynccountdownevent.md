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
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

| Parameter | Description |
|-----------|-------------|
| `initialCount` | The initial count. Must be greater than zero. |
| `runContinuationAsynchronously` | If true (default), continuations are forced to run on the thread pool. |
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

### WaitAsync (timeout)

```csharp
public ValueTask WaitAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
```

Asynchronously waits for the countdown to reach zero, or throws `TimeoutException` if the timeout elapses first.

**Parameters**:
- `timeout` — The maximum time to wait. Pass `Timeout.InfiniteTimeSpan` to wait indefinitely.

**Returns**: A `ValueTask` that completes when the count reaches zero.

**Throws**:
- `TimeoutException` — If the timeout elapses before the count reaches zero.
- `OperationCanceledException` — If the operation is canceled via the cancellation token.
- `ArgumentOutOfRangeException` — If `timeout` is negative and not equal to `Timeout.InfiniteTimeSpan`.

**Allocation notes**:

| Scenario | TimeProvider allocated? |
|---|---|
| Count already zero | No |
| `Timeout.InfiniteTimeSpan` | No |
| `TimeSpan.Zero` and count non-zero | No (immediate exception) |
| Finite positive timeout | Yes — one instance, disposed on await |

**Example**:

```csharp
try
{
    await _countdown.WaitAsync(TimeSpan.FromSeconds(30));
    ProcessResults();
}
catch (TimeoutException)
{
    HandleTimeout();
}
```

### Allocation Behavior

Immediate acquisitions are completely allocation-free using atomic operations. When the countdown is contended, waiting without a timeout is allocation-free on .NET 6.0+ (using `UnsafeRegister` for cancellation), while older frameworks may allocate for cancellation registration. Specifying a finite timeout allocates a timer that is automatically disposed when the operation completes. Exception and task allocations occur only if a timeout actually elapses or cancellation is triggered; successful acquisitions are otherwise allocation-free. Pooled `IValueTaskSource<bool>` instances are reused to minimize allocation pressure across repeated lock operations.

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

The following benchmarks compare `AsyncCountdownEvent` against `CountdownEvent`, `Proto.Promises.Threading.AsyncCountdownEvent`, `Nito.AsyncEx.AsyncCountdownEvent` and reference implementations.

### Signal Operation Benchmark

Measures the performance of signaling and waiting on the countdown event.
The standard implementation does not support `Task`-based waiters, while `AsyncCountdownEvent` uses pooled `IValueTaskSource` instances. Hence the tests run only uncontested for standard implementations.
ProtoPromise is included as an additional comparison point and is faster than the pooled implementation in the published `SignalAndWait` results, while the pooled implementation is much faster in the published `WaitAndSignal` scenario.
Only the pooled `AsyncCountdownEvent` is benchmarked in a contested and a uncontested scenario to proof that no memory allocations occur.
The Nito.Async implementation can not be benchmarked due to its internal design which doesn't allow to Reset the event, a new allocation for the AsyncCountdownEvent were necessary for each run so it was left out of contest.

[!INCLUDE[Countdown Event Benchmark](benchmarks/windows-x64-amd-ryzen-5-7600x/asynccountdownevent-signal.md)]

### Benchmark Analysis

**Key Findings:**

1. **Signal Performance**: The `Signal()` operation is O(1) until the final signal triggers the broadcast to all waiters. ProtoPromise currently leads the published `SignalAndWait` microbenchmark, while the pooled implementation performs better in the `WaitAndSignal` pattern.

2. **Memory Efficiency**: Pooled `IValueTaskSource` instances reduce allocation pressure in repeated countdown cycles (e.g., using `Reset()` to reuse the countdown). CancellationTokens do not add memory allocations.

3. **Broadcast Overhead**: When the count reaches zero, all waiters are signaled individually. For scenarios with many waiters, consider the trade-off compared to shared `Task`-based approaches.

4. **SignalAndWaitAsync**: This combined operation is optimized for the common pattern where a participant signals and then waits for others.

**When to Choose AsyncCountdownEvent:**

- Fan-out/fan-in coordination patterns
- Batch processing with parallel workers
- Scenarios where the countdown is frequently reset and reused

## Best Practices

### ✓ DO: Use `WaitAsync(TimeSpan)` to bound fan-in waits

```csharp
var countdown = new AsyncCountdownEvent(workers.Length);
foreach (var w in workers)
{
    _ = Task.Run(async () => { await w.RunAsync(); countdown.Signal(); });
}

try
{
    await countdown.WaitAsync(TimeSpan.FromMinutes(1));
}
catch (TimeoutException)
{
    HandleTimeout();
}
```

## See Also

- [Threading Package Overview](index.md)
- [AsyncAutoResetEvent](asyncautoresetevent.md) - Auto-reset event variant
- [AsyncManualResetEvent](asyncmanualresetevent.md) - Manual-reset event variant
- [AsyncReaderWriterLock](asyncreaderwriterlock.md) - Async reader-writer lock
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [AsyncBarrier](asyncbarrier.md) - Async barrier synchronization primitive
- [AsyncSemaphore](asyncsemaphore.md) - Async semaphore primitive
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
