# AsyncExchange&lt;T&gt;

## Overview

`AsyncExchange<T>` is a two-party rendezvous: two tasks meet at the exchange, each hands over a value, and each receives the other's. It is the async counterpart of Java's `Exchanger<V>`, which the BCL has no equivalent of.

The first caller to arrive occupies the exchange's single slot and suspends. The second caller pairs with it, completing both parties — the arriving one synchronously, without ever suspending.

## Namespace

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;
```

## Class Declaration

```csharp
public sealed class AsyncExchange<T> : IResettable
```

## Key Features

- **Allocation-free rendezvous**: the waiting party uses an instance-local `IValueTaskSource<T>`; concurrent parties fall back to a pooled source
- **The arriving party never suspends**: it takes the waiting party's value and returns a completed `ValueTask<T>`
- **Cancellation support**: full `CancellationToken` support; allocation-free registration on .NET 6.0+
- **Timeout support**: direct `ExchangeAsync(T, TimeSpan)` overload, including `TimeSpan.Zero` as a try-exchange
- **Thread-safe**: all operations are thread-safe

## Constructor

```csharp
public AsyncExchange(
    bool runContinuationAsynchronously = true,
    IGetPooledManualResetValueTaskSource<T>? pool = null)
```

### Parameters

- `runContinuationAsynchronously`: When `true` (default), the waiting party's continuation is forced to the thread pool, so the arriving party's thread is not hijacked
- `pool`: Optional custom source provider. When omitted a shared pool per closed `T` is used, the same technique as `ArrayPool<T>.Shared`

## Properties

### HasWaiter

```csharp
public bool HasWaiter { get; }
```

Whether a party is currently waiting for a counterpart.

### RunContinuationAsynchronously

```csharp
public bool RunContinuationAsynchronously { get; set; }
```

Controls how the waiting party's continuation is scheduled when the exchange completes.

## Methods

### ExchangeAsync

```csharp
public ValueTask<T> ExchangeAsync(T value, CancellationToken cancellationToken = default)
```

Offers `value` and returns the counterpart's value.

**Behavior**:

- If a counterpart is already waiting, both complete immediately and the returned `ValueTask<T>` is already completed
- Otherwise this caller occupies the slot and suspends until a counterpart arrives

**Throws**:

- `OperationCanceledException` — the token was cancelled while waiting. The slot is cleared, so a later counterpart is not paired with a cancelled party.

### ExchangeAsync (timeout)

```csharp
public ValueTask<T> ExchangeAsync(T value, TimeSpan timeout, CancellationToken cancellationToken = default)
```

The same, bounded by `timeout`.

**Parameters**:

- `timeout` — `Timeout.InfiniteTimeSpan` waits indefinitely and allocates no timer. `TimeSpan.Zero` makes the call a **try-exchange**: it pairs with a counterpart that is already waiting, and throws `TimeoutException` otherwise without ever occupying the slot.

**Throws**: additionally `TimeoutException`, and `ArgumentOutOfRangeException` if `timeout` is negative and not `Timeout.InfiniteTimeSpan`.

**Allocation notes**:

| Scenario | Timer allocated? |
|---|---|
| A counterpart is already waiting | No |
| `Timeout.InfiniteTimeSpan` | No |
| `TimeSpan.Zero` with no counterpart | No (immediate exception) |
| Finite positive timeout, no counterpart | Yes — one instance, disposed on await |

### TryReset

```csharp
public bool TryReset()
```

Implements `IResettable` so the instance can be returned to a `DefaultObjectPool<AsyncExchange<T>>`.

**Behavior**:

- Returns `false` if the internal spin lock is held, if a party is waiting, or if a completed party has not observed its result yet
- Otherwise resets the local waiter, restores `RunContinuationAsynchronously` to its default and returns `true`

## Pairing semantics

The exchange holds exactly one slot. With an even number of calls every party is paired: a call either finds the slot occupied and pairs, or finds it empty and occupies it, so occupancy alternates and the final call always pairs.

With more than two concurrent parties the pairs are arbitrary — the exchange guarantees that each party receives exactly one counterpart's value, not *which* counterpart. An odd number of calls leaves the last one waiting for the next arrival, which is the same behaviour as `Exchanger<V>`.

## Usage Example

```csharp
private readonly AsyncExchange<byte[]> _bufferSwap = new();

// Filler: hands a full buffer over and gets an empty one back.
public async Task FillAsync(CancellationToken ct)
{
    byte[] buffer = new byte[4096];
    while (!ct.IsCancellationRequested)
    {
        Fill(buffer);
        buffer = await _bufferSwap.ExchangeAsync(buffer, ct);
    }
}

// Drainer: hands an empty buffer over and gets a full one back.
public async Task DrainAsync(CancellationToken ct)
{
    byte[] buffer = new byte[4096];
    while (!ct.IsCancellationRequested)
    {
        buffer = await _bufferSwap.ExchangeAsync(buffer, ct);
        Drain(buffer);
    }
}
```

A try-exchange, for a party that must not block:

```csharp
try
{
    T theirs = await _exchange.ExchangeAsync(mine, TimeSpan.Zero);
    // paired with a counterpart that was already waiting
}
catch (TimeoutException)
{
    // nobody was waiting; carry on with our own value
}
```

## Best Practices

### ✓ DO: Await the returned `ValueTask<T>` exactly once

Reading `IsCompleted` after the await throws `InvalidOperationException` — the source has already been recycled. Capture it once if the outcome matters:

```csharp
ValueTask<T> pending = _exchange.ExchangeAsync(mine);
bool paired = pending.IsCompleted;   // read before awaiting
T theirs = await pending;
```

### ✓ DO: Pass a cancellation token to a party that may be left waiting

An unpaired party waits forever otherwise, and its pooled waiter is never returned.

### ✓ DO: Use `TimeSpan.Zero` for an opportunistic exchange

It never occupies the slot, so a rejected try-exchange leaves nothing behind for a later party to pair with.

### ✗ DON'T: Use it as a queue

The exchange is a rendezvous of exactly two parties with no buffering. Use `System.Threading.Channels` when values need to be buffered.

## See Also

- [Threading Package Overview](index.md)
- [AsyncConditionVariable](asyncconditionvariable.md) - Wait-until-condition paired with a lock
- [AsyncBarrier](asyncbarrier.md) - Multi-party phase synchronization
- [AsyncSemaphore](asyncsemaphore.md) - Async semaphore primitive
- [AsyncLock](asynclock.md) - Async mutual exclusion lock
- [Benchmarks](benchmarks.md) - Benchmark description

---

© 2026 The Keepers of the CryptoHives
