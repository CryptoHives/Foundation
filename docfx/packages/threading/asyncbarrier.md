# AsyncBarrier

A pooled, allocation-free async barrier that synchronizes multiple participants using ValueTask-based waiters.

## Overview

`AsyncBarrier` is an async-compatible barrier synchronization primitive. It allows a fixed number of participants to synchronize at a barrier point, releasing all of them when the last participant arrives. The barrier automatically resets for the next phase.

## Usage

### Basic Usage

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

private readonly AsyncBarrier _barrier = new AsyncBarrier(3);

public async Task ParticipantWorkAsync(int participantId, CancellationToken ct)
{
    // Phase 1
    await DoPhase1WorkAsync(participantId);
    Console.WriteLine($"Participant {participantId} completed phase 1");

    // Wait for all participants
    await _barrier.SignalAndWaitAsync(ct);

    // Phase 2 - all participants continue together
    await DoPhase2WorkAsync(participantId);
    Console.WriteLine($"Participant {participantId} completed phase 2");
}
```

### Parallel Processing Phases

```csharp
public async Task ProcessInPhasesAsync(int workerCount, CancellationToken ct)
{
    var barrier = new AsyncBarrier(workerCount);
    var tasks = new Task[workerCount];

    for (int i = 0; i < workerCount; i++)
    {
        int workerId = i;
        tasks[i] = Task.Run(async () =>
        {
            // Load data
            await LoadDataAsync(workerId);
            await barrier.SignalAndWaitAsync(ct);

            // Process data (all workers have loaded)
            await ProcessDataAsync(workerId);
            await barrier.SignalAndWaitAsync(ct);

            // Save results (all workers have processed)
            await SaveResultsAsync(workerId);
        }, ct);
    }

    await Task.WhenAll(tasks);
}
```

## Constructor

```csharp
public AsyncBarrier(
    int participantCount,
    bool runContinuationAsynchronously = true,
    int defaultEventQueueSize = 0,
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

| Parameter | Description |
|-----------|-------------|
| `participantCount` | The number of participants. Must be greater than zero. |
| `runContinuationAsynchronously` | If true (default), continuations run on the thread pool. |
| `defaultEventQueueSize` | Initial capacity for the waiter queue. |
| `pool` | Optional custom pool for ValueTaskSource instances. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `ParticipantCount` | `int` | Gets the total number of participants. |
| `RemainingParticipants` | `int` | Gets the number of participants still needed. |
| `CurrentPhase` | `long` | Gets the current phase number. |
| `RunContinuationAsynchronously` | `bool` | Gets or sets whether continuations run asynchronously. |

## Methods

### SignalAndWaitAsync

```csharp
public ValueTask SignalAndWaitAsync(CancellationToken cancellationToken = default)
```

Signals the barrier and waits for all participants to arrive.

### AddParticipant / AddParticipants

```csharp
public long AddParticipant()
public long AddParticipants(int participantCount)
```

Dynamically adds participants to the barrier.

### RemoveParticipant / RemoveParticipants

```csharp
public void RemoveParticipant()
public void RemoveParticipants(int participantCount)
```

Dynamically removes participants from the barrier. If remaining participants reaches zero, all waiters are released.

## Performance

- **O(1)** signal operation for non-final participant
- **O(n)** broadcast when last participant signals
- **Zero allocations** when last participant signals with no waiters
- Automatic phase reset after each release

## Cancellation Behavior

When a waiting participant is cancelled:
- The participant count is restored
- Other participants continue waiting
- The barrier remains in a consistent state

## See Also

- [AsyncCountdownEvent](asynccountdownevent.md)
- [AsyncManualResetEvent](asyncmanualresetevent.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
