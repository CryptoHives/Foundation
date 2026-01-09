# AsyncBarrier

A pooled, allocation-free async barrier that synchronizes multiple participants using ValueTask-based waiters.

## Overview

`AsyncBarrier` is an async-compatible barrier synchronization primitive. It allows a fixed number of participants to synchronize at a barrier point, releasing all of them when the last participant arrives. The barrier automatically resets for the next phase.

This implementation follows the same semantics as the .NET `System.Threading.Barrier` class but provides async support with `ValueTask`-based waiters.

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

### With Post-Phase Action

```csharp
// Create barrier with post-phase action
private readonly AsyncBarrier _barrier = new AsyncBarrier(3, b =>
{
    Console.WriteLine($"Phase {b.CurrentPhase} completed by all participants");
});

public async Task ParticipantWorkAsync(int participantId, CancellationToken ct)
{
    await DoPhase1WorkAsync(participantId);
    await _barrier.SignalAndWaitAsync(ct);
    // Post-phase action runs before participants are released
    await DoPhase2WorkAsync(participantId);
}
```

### Handling Post-Phase Exceptions

```csharp
var barrier = new AsyncBarrier(3, b =>
{
    if (b.CurrentPhase == 2)
    {
        throw new InvalidOperationException("Phase 2 failed");
    }
});

try
{
    await barrier.SignalAndWaitAsync(ct);
}
catch (BarrierPostPhaseException ex)
{
    // All participants receive the same exception
    Console.WriteLine($"Post-phase action failed: {ex.InnerException?.Message}");
}
```

### Dynamic Participant Management

```csharp
// Start with 3 participants
var barrier = new AsyncBarrier(3);

// Add 2 more participants
barrier.AddParticipants(2);
Console.WriteLine($"Participants: {barrier.ParticipantCount}"); // 5

// Remove 1 participant
barrier.RemoveParticipant();
Console.WriteLine($"Participants: {barrier.ParticipantCount}"); // 4
```

## Constructors

### AsyncBarrier(int, bool, int, IGetPooledManualResetValueTaskSource<bool>?)

```csharp
public AsyncBarrier(
    int participantCount,
    bool runContinuationAsynchronously = true,
    int defaultEventQueueSize = 0,
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

Creates a barrier without a post-phase action.

### AsyncBarrier(int, Action<AsyncBarrier>?, bool, int, IGetPooledManualResetValueTaskSource<bool>?)

```csharp
public AsyncBarrier(
    int participantCount,
    Action<AsyncBarrier>? postPhaseAction,
    bool runContinuationAsynchronously = true,
    int defaultEventQueueSize = 0,
    IGetPooledManualResetValueTaskSource<bool>? pool = null)
```

Creates a barrier with an optional post-phase action.

| Parameter | Description |
|-----------|-------------|
| `participantCount` | The number of participants. Must be greater than zero. |
| `postPhaseAction` | An action to execute after each phase when all participants have arrived. If this action throws, all participants receive a `BarrierPostPhaseException`. |
| `runContinuationAsynchronously` | If true (default), continuations run on the thread pool. |
| `defaultEventQueueSize` | Initial capacity for the waiter queue. |
| `pool` | Optional custom pool for ValueTaskSource instances. |

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `ParticipantCount` | `int` | Gets the total number of participants in the barrier. Changes when participants are added or removed. |
| `ParticipantsRemaining` | `int` | Gets the number of participants that haven't yet signaled in the current phase. |
| `CurrentPhase` | `long` | Gets the current phase number. Increments each time the barrier is released. |
| `RunContinuationAsynchronously` | `bool` | Gets or sets whether continuations run asynchronously. |

## Methods

### SignalAndWaitAsync

```csharp
public ValueTask SignalAndWaitAsync(CancellationToken cancellationToken = default)
```

Signals the barrier and waits for all participants to arrive.

**Throws:**
- `InvalidOperationException` - If more participants signal than the total number of registered participants.
- `BarrierPostPhaseException` - If the post-phase action throws an exception.

### AddParticipant / AddParticipants

```csharp
public long AddParticipant()
public long AddParticipants(int participantCount)
```

Dynamically adds participants to the barrier. Returns the phase number when the participant(s) are added.

**Throws:**
- `ArgumentOutOfRangeException` - If `participantCount` is less than 1.
- `InvalidOperationException` - If adding participants would cause an overflow.

### RemoveParticipant / RemoveParticipants

```csharp
public void RemoveParticipant()
public void RemoveParticipants(int participantCount)
```

Dynamically removes participants from the barrier. If the remaining participants reaches zero (and there are still registered participants), all waiters are released and the barrier advances to the next phase.

**Throws:**
- `ArgumentOutOfRangeException` - If `participantCount` is less than 1.
- `InvalidOperationException` - If there are not enough participants to remove.
- `BarrierPostPhaseException` - If the post-phase action throws an exception during phase advancement.

## Post-Phase Action

The post-phase action is an optional callback that is executed after all participants have signaled but before they are released. This is useful for:

- Logging phase completion
- Validating intermediate results
- Preparing for the next phase

**Important:** The `CurrentPhase` property still reflects the phase number *before* increment when the post-phase action is called.

If the post-phase action throws an exception:
1. The exception is wrapped in a `BarrierPostPhaseException`
2. All waiting participants receive this exception
3. The phase still advances
4. The barrier continues to function normally for subsequent phases

## Performance

- **O(1)** signal operation for non-final participant
- **O(n)** broadcast when last participant signals
- **Zero allocations** when last participant signals with no waiters
- Automatic phase reset after each release

## Benchmark Results

The following benchmarks compare `AsyncBarrier` against `Nito.AsyncEx.AsyncBarrier` and reference implementations.

### Signal and Wait Benchmark

Measures the performance of the `SignalAndWaitAsync` operation across multiple participants.

[!INCLUDE[Barrier Benchmark](benchmarks/asyncbarrier-signalandwait.md)]

### Benchmark Analysis

**Key Findings:**

1. **Per-Phase Efficiency**: The barrier automatically resets after each phase, allowing efficient multi-phase synchronization without manual reset.

2. **Participant Scaling**: Performance scales linearly with participant count due to the O(n) broadcast when the last participant signals.

3. **Memory Efficiency**: Pooled `IValueTaskSource` instances reduce allocation pressure for waiters, especially beneficial in scenarios with many barrier phases.

4. **Cancellation Handling**: Proper participant count restoration on cancellation ensures the barrier remains consistent, though cancellation in barrier scenarios should be used carefully.

**When to Choose AsyncBarrier:**

- Multi-phase parallel algorithms
- Iterative computations where workers must synchronize between phases
- Pipeline processing with synchronized stages

**Design Considerations:**

- Unlike `System.Threading.Barrier`, this implementation is async-native
- The pooled approach benefits scenarios with many phases
- Dynamic participant changes (`AddParticipant`/`RemoveParticipant`) allow flexible coordination patterns

## Cancellation Behavior

When a waiting participant is cancelled:
- The participant's `ParticipantsRemaining` count is restored
- Other participants continue waiting
- The barrier remains in a consistent state

## Comparison with System.Threading.Barrier

| Feature | AsyncBarrier | System.Threading.Barrier |
|---------|--------------|--------------------------|
| Async support | Native `ValueTask` | None (blocking only) |
| Post-phase action | `Action<AsyncBarrier>` | `Action<Barrier>` |
| BarrierPostPhaseException | Yes | Yes |
| Allocation overhead | Minimal (pooled) | None (sync) |
| Cancellation | Full support | Full support |
| Dynamic participants | Yes | Yes |

## See Also

- [AsyncCountdownEvent](asynccountdownevent.md)
- [AsyncManualResetEvent](asyncmanualresetevent.md)
- [Threading Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
