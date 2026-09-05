// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1508 // Avoid dead conditional code

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

/// <summary>
/// A two-party rendezvous that lets two tasks atomically swap values without allocations,
/// equivalent to Java's <c>Exchanger&lt;V&gt;</c> for async code.
/// </summary>
/// <typeparam name="T">The type of value exchanged.</typeparam>
/// <remarks>
/// <para>
/// Each caller supplies a value and receives the counterpart's value.
/// The first caller to arrive suspends until a second caller arrives;
/// the second caller completes the first immediately and both return synchronously
/// with each other's value.
/// </para>
/// <para>
/// Exactly one "slot" is maintained at a time. If multiple callers arrive while
/// a waiter is already pending, each new caller pairs with and wakes the pending waiter;
/// the next caller then becomes the new pending waiter.
/// </para>
/// <example>
/// <code>
/// private readonly AsyncExchange&lt;int&gt; _exchange = new();
///
/// // Task A
/// int fromB = await _exchange.ExchangeAsync(42, ct);
///
/// // Task B (concurrent with A)
/// int fromA = await _exchange.ExchangeAsync(99, ct);
/// // fromA == 42, fromB == 99
/// </code>
/// </example>
/// <para>
/// <b>Optional timeout and cancellation token</b> parameters on
/// <see cref="ExchangeAsync(T, TimeSpan, CancellationToken)"/>. A timeout of
/// <see cref="TimeSpan.Zero"/> turns the call into a try-exchange: it pairs with a counterpart
/// that is already waiting and throws <see cref="TimeoutException"/> otherwise, without ever
/// occupying the slot. <see cref="TryExchange(T, out T)"/> answers the same question
/// synchronously, without the exception or the <see cref="ValueTask{T}"/> allocation a failed
/// zero-timeout attempt would otherwise need.
/// </para>
/// <para>
/// This implementation uses <see cref="ValueTask{TResult}"/> for waiters and provides
/// allocation-free exchange by reusing a per-instance <see cref="LocalManualResetValueTaskSource{T}"/>
/// for the common single-waiter case and falling back to a pooled
/// <see cref="IGetPooledManualResetValueTaskSource{T}"/> for concurrent contention.
/// </para>
/// <para>
/// <b>Important Usage Note:</b> awaiting a <see cref="ValueTask{TResult}"/> has its own caveats, as
/// it is a struct that can only be awaited or converted with AsTask() ONE single time. Additional
/// attempts to await, to convert, or even to read <c>IsCompleted</c> after the first await throw an
/// <see cref="InvalidOperationException"/>.
/// </para>
/// <para>
/// The <see cref="IResettable"/> interface is implemented to allow resetting the state of the instance
/// for reuse by an <see cref="ObjectPool{T}"/> using the <see cref="DefaultObjectPool{T}"/> implementation.
/// </para>
/// </remarks>
public sealed class AsyncExchange<T> : IResettable
{
    private readonly LocalManualResetValueTaskSource<T> _localWaiter;
    private readonly IGetPooledManualResetValueTaskSource<T> _pool;
    private Internal.SpinLock _spinLock;
    private ManualResetValueTaskSource<T>? _pendingWaiter;
    private T _pendingValue;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// Holds the shared per-<typeparamref name="T"/> waiter pool.
    /// </summary>
    /// <remarks>
    /// <see cref="ValueTaskSourceObjectPools"/> cannot hold this pool because the exchanged type is
    /// generic. Declaring it in a nested generic class instead means the CLR creates one shared
    /// static pool per closed <typeparamref name="T"/>, the same technique
    /// <see cref="System.Buffers.ArrayPool{T}.Shared"/> and
    /// <see cref="ValueTaskSourceObjectPools{TKey}"/> use.
    /// </remarks>
    private static class DefaultPool
    {
        internal static readonly ValueTaskSourceObjectPool<T> Instance =
            new(new PooledValueTaskSourceObjectPolicy<T>(), ValueTaskSourceObjectPools.DefaultMaxRetainedItems);
    }

    /// <summary>
    /// Constructs a new <see cref="AsyncExchange{T}"/> instance.
    /// </summary>
    /// <param name="runContinuationAsynchronously">
    /// When <see langword="true"/> (default), the waiting party's continuation is forced to the thread
    /// pool when the exchange completes, preventing the arriving party's thread from being hijacked.
    /// </param>
    /// <param name="pool">Custom pool for waiter instances; uses a shared per-<typeparamref name="T"/> pool if omitted.</param>
    public AsyncExchange(bool runContinuationAsynchronously = true, IGetPooledManualResetValueTaskSource<T>? pool = null)
    {
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _spinLock = new();
        _pendingValue = default!;
        _localWaiter = new(this);
        _pool = pool ?? DefaultPool.Instance;
    }

    /// <inheritdoc/>
    public bool TryReset()
    {
        if (!_spinLock.TryEnter())
        {
            return false;
        }

        try
        {
            // A pending waiter means the exchange is mid-flight. A local waiter that is still
            // in use means a party has been handed its result but has not observed it yet:
            // resetting now would bump the version underneath that ValueTask and make the
            // await throw. Both cases decline the reset.
            if (_pendingWaiter is not null || _localWaiter.InUse)
            {
                return false;
            }

            _localWaiter.TryReset();
            _runContinuationAsynchronously = true;
            return true;
        }
        finally
        {
            _spinLock.Exit();
        }
    }

    /// <summary>
    /// Gets or sets whether the waiting party's continuation is forced to run asynchronously
    /// when the exchange is completed by the arriving party.
    /// </summary>
    public bool RunContinuationAsynchronously
    {
        get => _runContinuationAsynchronously;
        set => _runContinuationAsynchronously = value;
    }

    /// <summary>
    /// Gets whether a task is currently waiting for an exchange partner.
    /// </summary>
    public bool HasWaiter
    {
        get
        {
            _spinLock.Enter();
            try
            {
                return _pendingWaiter is not null;
            }
            finally
            {
                _spinLock.Exit();
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the local waiter is currently in use.
    /// </summary>
    internal bool InternalWaiterInUse => _localWaiter.InUse;

    /// <summary>
    /// Exchanges <paramref name="value"/> with a counterpart task and returns that task's value.
    /// If no counterpart is waiting, suspends until one arrives or <paramref name="cancellationToken"/> fires.
    /// If a counterpart is already waiting, completes both tasks immediately without suspending.
    /// </summary>
    /// <param name="value">The value to offer to the counterpart.</param>
    /// <param name="cancellationToken">Token to cancel the wait.</param>
    /// <returns>
    /// A <see cref="ValueTask{T}"/> that completes with the counterpart's offered value.
    /// </returns>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled while waiting.
    /// </exception>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask<T> ExchangeAsync(T value, CancellationToken cancellationToken = default)
        => ExchangeAsyncImpl(value, Timeout.InfiniteTimeSpan, cancellationToken);

    /// <summary>
    /// Exchanges <paramref name="value"/> with a counterpart task and returns that task's value,
    /// or fails once <paramref name="timeout"/> has elapsed.
    /// </summary>
    /// <remarks>
    /// If a counterpart is already waiting the exchange completes immediately without allocating
    /// any timeout infrastructure. A timer is allocated only when this caller has to wait and a
    /// finite positive timeout is requested; it is disposed automatically when the returned
    /// <see cref="ValueTask{T}"/> is awaited.
    /// </remarks>
    /// <param name="value">The value to offer to the counterpart.</param>
    /// <param name="timeout">
    /// The maximum time to wait for a counterpart. Use <see cref="Timeout.InfiniteTimeSpan"/> to
    /// wait indefinitely, or <see cref="TimeSpan.Zero"/> to pair only with a counterpart that is
    /// already waiting - <see cref="TryExchange(T, out T)"/> does the same synchronously, without
    /// throwing on a miss.
    /// </param>
    /// <param name="cancellationToken">Token to cancel the wait.</param>
    /// <returns>
    /// A <see cref="ValueTask{T}"/> that completes with the counterpart's offered value.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timeout"/> is negative and not equal to <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </exception>
    /// <exception cref="TimeoutException">
    /// Thrown when the timeout elapses before a counterpart arrives.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled while waiting.
    /// </exception>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask<T> ExchangeAsync(T value, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan) throw new ArgumentOutOfRangeException(nameof(timeout));

        return ExchangeAsyncImpl(value, timeout, cancellationToken);
    }

    /// <summary>
    /// Attempts to exchange <paramref name="value"/> immediately, without waiting.
    /// </summary>
    /// <remarks>
    /// Synchronous and non-throwing by design: unlike <see cref="ExchangeAsync(T, TimeSpan, CancellationToken)"/>
    /// with a zero timeout, a failed attempt here never allocates an exception or a faulted
    /// <see cref="ValueTask{T}"/> - there is nothing to await in the first place, since this either
    /// pairs immediately or doesn't. A failed attempt never occupies the slot, exactly like the
    /// zero-timeout try-exchange.
    /// </remarks>
    /// <param name="value">The value to offer to the counterpart.</param>
    /// <param name="result">
    /// The counterpart's value, if this method returns <see langword="true"/>. Undefined if this
    /// method returns <see langword="false"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if a counterpart was already waiting and the exchange completed;
    /// <see langword="false"/> if nobody was waiting.
    /// </returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public bool TryExchange(T value, out T result)
    {
        ManualResetValueTaskSource<T>? toComplete;
        T theirValue;

        _spinLock.Enter();
        try
        {
            if (_pendingWaiter is null)
            {
                toComplete = null;
                theirValue = default!;
            }
            else
            {
                // A counterpart is waiting - take their value and hand them ours, exactly like
                // the pairing branch of ExchangeAsyncImpl.
                toComplete = _pendingWaiter;
                theirValue = _pendingValue;
                _pendingWaiter = null;
                _pendingValue = default!;
            }
        }
        finally
        {
            _spinLock.Exit();
        }

        if (toComplete is null)
        {
            result = default!;
            return false;
        }

        // SetResult runs outside the lock - it may synchronously invoke the waiting party's
        // continuation when RunContinuationAsynchronously is false.
        toComplete.SetResult(value);
        result = theirValue;
        return true;
    }

    /// <remarks>
    /// Both outcomes - pairing with a waiting counterpart and becoming the pending waiter - are
    /// decided under the spin lock in one pass. There is deliberately no lock-free pre-check that
    /// falls back into this method: the fallback would have to re-enter the non-reentrant spin
    /// lock, and the slot can empty between any such check and the acquisition.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private ValueTask<T> ExchangeAsyncImpl(T value, TimeSpan timeout, CancellationToken cancellationToken)
    {
        ManualResetValueTaskSource<T>? toComplete = null;
        ManualResetValueTaskSource<T>? pending = null;
        T theirValue = default!;
        short version = 0;

        _spinLock.Enter();
        try
        {
            if (_pendingWaiter is not null)
            {
                // A counterpart is waiting - take their value and hand them ours.
                toComplete = _pendingWaiter;
                theirValue = _pendingValue;
                _pendingWaiter = null;
                _pendingValue = default!;
            }
            else
            {
                // No counterpart - become the pending waiter.
                if (cancellationToken.IsCancellationRequested)
                {
                    return new ValueTask<T>(Task.FromCanceled<T>(cancellationToken));
                }

                if (timeout == TimeSpan.Zero)
                {
                    return new ValueTask<T>(Task.FromException<T>(new TimeoutException()));
                }

                if (!_localWaiter.TryGetValueTaskSource(out ManualResetValueTaskSource<T> waiter))
                {
                    waiter = _pool.GetPooledWaiter(this);
                }
                waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
                waiter.CancellationToken = cancellationToken;

                version = waiter.Version;
                _pendingWaiter = waiter;
                _pendingValue = value;
                pending = waiter;
            }
        }
        finally
        {
            _spinLock.Exit();
        }

        if (pending is null)
        {
            toComplete!.SetResult(value);
            return new ValueTask<T>(theirValue);
        }

        // The timer and the cancellation registration are armed after the spin lock is released.
        // Both callbacks take that same lock, and registering an already-cancelled token runs the
        // callback synchronously on this thread, which would deadlock against the non-reentrant
        // spin lock. Arming after the waiter is published also means a callback that does fire
        // immediately finds the waiter it is supposed to remove.
        if (timeout != Timeout.InfiniteTimeSpan)
        {
            pending.TimeoutTimer = TimeProvider.System.CreateTimer(
                _timerCallbackAction, new TimeoutState<T>(pending), timeout, Timeout.InfiniteTimeSpan);
        }

        if (cancellationToken.CanBeCanceled)
        {
#if NET6_0_OR_GREATER
            // Use UnsafeRegister on .NET 6+ for allocation free registration
            pending.CancellationTokenRegistration =
                cancellationToken.UnsafeRegister(_cancellationCallbackAction, pending);
#else
            pending.CancellationTokenRegistration =
                cancellationToken.Register(CancellationCallback, pending, useSynchronizationContext: false);
#endif
        }
        else
        {
            Debug.Assert(pending.CancellationTokenRegistration == default);
        }

        return new ValueTask<T>(pending, version);
    }

    /// <summary>
    /// Callback used with <see cref="TimeProvider"/> to trigger timeout.
    /// The stamped version guards against a stale callback observing a recycled waiter.
    /// </summary>
    private static readonly TimerCallback _timerCallbackAction = static state => {
        var timeoutState = (TimeoutState<T>)state!;
        var context = (AsyncExchange<T>)timeoutState.Source.Owner!;
        ManualResetValueTaskSource<T>? toCancel = context.RemoveWaiter(timeoutState.Source, timeoutState.Version);
        toCancel?.SetException(new TimeoutException());
    };

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _cancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<T>)state!;
        var context = (AsyncExchange<T>)waiter.Owner!;
        context.CancellationCallback(waiter);
    };

    private void CancellationCallback(ManualResetValueTaskSource<T> waiter)
    {
#else
    private void CancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<T> waiter)
        {
            return;
        }
#endif
        // The version is stable here: GetResult disposes the registration before the
        // waiter is recycled, and disposal waits for an in-flight callback.
        ManualResetValueTaskSource<T>? toCancel = RemoveWaiter(waiter, waiter.Version);
        toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
    }

    /// <summary>
    /// Clears the slot if <paramref name="waiter"/> is still the pending one.
    /// </summary>
    /// <remarks>
    /// The arriving party may have taken and completed the waiter between the callback firing and
    /// this call, and the local waiter may since have been recycled into a new exchange, so both
    /// the identity and the version have to match before the slot is cleared.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ManualResetValueTaskSource<T>? RemoveWaiter(ManualResetValueTaskSource<T> waiter, short version)
    {
        _spinLock.Enter();
        try
        {
            if (ReferenceEquals(_pendingWaiter, waiter) && waiter.Version == version)
            {
                _pendingWaiter = null;
                _pendingValue = default!;
                return waiter;
            }
        }
        finally
        {
            _spinLock.Exit();
        }

        return null;
    }
}
