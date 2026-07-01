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
/// This implementation uses <see cref="ValueTask{TResult}"/> for waiters and provides
/// allocation-free exchange by reusing a per-instance <see cref="LocalManualResetValueTaskSource{T}"/>
/// for the common single-waiter case and falling back to a pooled
/// <see cref="IGetPooledManualResetValueTaskSource{T}"/> for concurrent contention.
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

    // Per-T lazy default pool; avoids the need for a named entry in ValueTaskSourceObjectPools.
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
            if (_pendingWaiter is not null)
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
    {
        // Fast path: a counterpart is already waiting — grab their value and complete them.
        if (_pendingWaiter is not null)
        {
            return ExchangeWithWaiterFastPath(value);
        }

        return ExchangeAsyncImpl(value, cancellationToken);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private ValueTask<T> ExchangeWithWaiterFastPath(T value)
    {
        ManualResetValueTaskSource<T>? toComplete;
        T theirValue;

        _spinLock.Enter();
        try
        {
            if (_pendingWaiter is null)
            {
                // Race: waiter was cancelled or taken between the check and the lock.
                // Fall through to the slow path.
                return ExchangeAsyncImpl(value, CancellationToken.None);
            }

            toComplete = _pendingWaiter;
            theirValue = _pendingValue;
            _pendingWaiter = null;
            _pendingValue = default!;
        }
        finally
        {
            _spinLock.Exit();
        }

        toComplete.SetResult(value);
        return new ValueTask<T>(theirValue);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private ValueTask<T> ExchangeAsyncImpl(T value, CancellationToken cancellationToken)
    {
        ManualResetValueTaskSource<T>? toComplete = null;
        T theirValue = default!;

        _spinLock.Enter();
        try
        {
            if (_pendingWaiter is not null)
            {
                // A waiter arrived between our check and the lock — pair with them.
                toComplete = _pendingWaiter;
                theirValue = _pendingValue;
                _pendingWaiter = null;
                _pendingValue = default!;
            }
            else
            {
                // No counterpart — become the pending waiter.
                if (cancellationToken.IsCancellationRequested)
                {
                    return new ValueTask<T>(Task.FromCanceled<T>(cancellationToken));
                }

                ManualResetValueTaskSource<T> waiter;
                if (!_localWaiter.TryGetValueTaskSource(out waiter))
                {
                    waiter = _pool.GetPooledWaiter(this);
                }
                waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
                waiter.CancellationToken = cancellationToken;

                if (cancellationToken.CanBeCanceled)
                {
#if NET6_0_OR_GREATER
                    waiter.CancellationTokenRegistration =
                        cancellationToken.UnsafeRegister(_cancellationCallbackAction, waiter);
#else
                    waiter.CancellationTokenRegistration =
                        cancellationToken.Register(CancellationCallback, waiter, useSynchronizationContext: false);
#endif
                }
                else
                {
                    Debug.Assert(waiter.CancellationTokenRegistration == default);
                }

                _pendingWaiter = waiter;
                _pendingValue = value;
                return new ValueTask<T>(waiter, waiter.Version);
            }
        }
        finally
        {
            _spinLock.Exit();
        }

        toComplete.SetResult(value);
        return new ValueTask<T>(theirValue);
    }

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

        ManualResetValueTaskSource<T>? toCancel = null;

        _spinLock.Enter();
        try
        {
            // Only cancel if this waiter is still the pending one — the arriving party
            // might have already taken and completed it between the CT firing and here.
            if (ReferenceEquals(_pendingWaiter, waiter))
            {
                toCancel = _pendingWaiter;
                _pendingWaiter = null;
                _pendingValue = default!;
            }
        }
        finally
        {
            _spinLock.Exit();
        }

        toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
    }
}
