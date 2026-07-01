// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1508 // Avoid dead conditional code

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

/// <summary>
/// An async condition variable that pairs with <see cref="AsyncLock"/> to provide
/// "wait until condition" semantics without blocking a thread, equivalent to
/// <see cref="Monitor.Wait(object)"/> for async code.
/// </summary>
/// <remarks>
/// <para>
/// A condition variable must always be used in conjunction with an <see cref="AsyncLock"/>.
/// The caller must hold the lock when calling <see cref="WaitAsync"/>.
/// <see cref="WaitAsync"/> atomically releases the lock and suspends the caller until
/// <see cref="Signal"/> or <see cref="SignalAll"/> is called, after which it re-acquires
/// the lock before returning. The caller is guaranteed to hold the lock on any return path,
/// including when an <see cref="OperationCanceledException"/> is thrown.
/// </para>
/// <para>
/// Unlike <see cref="AsyncManualResetEvent"/> and <see cref="AsyncAutoResetEvent"/>,
/// a signal that fires when no waiters are present is <b>not</b> stored — it is lost.
/// Always use a <c>while</c> loop to re-check the predicate after returning from
/// <see cref="WaitAsync"/>:
/// </para>
/// <code>
/// private readonly AsyncLock _lock = new AsyncLock();
/// private readonly AsyncConditionVariable _ready = new AsyncConditionVariable();
/// private bool _hasItem;
///
/// public async Task ProduceAsync(CancellationToken ct)
/// {
///     using (await _lock.LockAsync(ct))
///     {
///         _hasItem = true;
///         _ready.Signal();
///     }
/// }
///
/// public async Task ConsumeAsync(CancellationToken ct)
/// {
///     using (await _lock.LockAsync(ct))
///     {
///         while (!_hasItem)
///             await _ready.WaitAsync(_lock, ct);
///         _hasItem = false;
///     }
/// }
/// </code>
/// <para>
/// <b>Note:</b> <see cref="WaitAsync"/> is implemented as an <see langword="async"/> method,
/// which allocates a state machine. This is intentional for the prototype; a production
/// implementation would use a custom awaitable to avoid the allocation.
/// </para>
/// </remarks>
public sealed class AsyncConditionVariable
{
    private readonly IGetPooledManualResetValueTaskSource<bool> _pool;
    private Internal.SpinLock _spinLock;
    private WaiterQueue<bool> _waiters;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// Constructs a new <see cref="AsyncConditionVariable"/>.
    /// </summary>
    /// <param name="runContinuationAsynchronously">
    /// When <see langword="true"/> (default), continuations are forced to the thread pool
    /// when a signal is received, preventing the signaling thread from being hijacked.
    /// </param>
    /// <param name="pool">Custom pool for waiter instances.</param>
    public AsyncConditionVariable(bool runContinuationAsynchronously = true, IGetPooledManualResetValueTaskSource<bool>? pool = null)
    {
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _spinLock = new();
        _waiters = new();
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolBoolean;
    }

    /// <summary>
    /// Gets or sets whether continuations are forced to run asynchronously after a signal.
    /// </summary>
    public bool RunContinuationAsynchronously
    {
        get => _runContinuationAsynchronously;
        set => _runContinuationAsynchronously = value;
    }

    /// <summary>
    /// Gets the number of tasks currently waiting for a signal.
    /// </summary>
    public int WaiterCount
    {
        get
        {
            _spinLock.Enter();
            try
            {
                return _waiters.Count;
            }
            finally
            {
                _spinLock.Exit();
            }
        }
    }

    /// <summary>
    /// Atomically releases <paramref name="asyncLock"/> and waits for a signal, then
    /// re-acquires <paramref name="asyncLock"/> before returning. The caller must hold
    /// <paramref name="asyncLock"/> on entry and will always hold it on return,
    /// including when an exception is thrown.
    /// </summary>
    /// <param name="asyncLock">The lock to release while waiting and re-acquire after signaling.</param>
    /// <param name="cancellationToken">Token to cancel the wait. The lock is re-acquired before the
    /// resulting <see cref="OperationCanceledException"/> is propagated.</param>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled. The lock is always
    /// re-acquired before this exception propagates.
    /// </exception>
    public async ValueTask WaitAsync(AsyncLock asyncLock, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(asyncLock);

        // Check before enqueuing: don't release the lock if already cancelled.
        if (cancellationToken.IsCancellationRequested)
        {
            cancellationToken.ThrowIfCancellationRequested();
        }

        ValueTask signalTask;

        _spinLock.Enter();
        try
        {
            var waiter = _pool.GetPooledWaiter(this);
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

            _waiters.Enqueue(waiter);
            signalTask = new ValueTask(waiter, waiter.Version);
        }
        finally
        {
            _spinLock.Exit();
        }

        // Release the lock while suspended. The caller must be holding it at this point.
        asyncLock.ReleaseLock();

        try
        {
            await signalTask.ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            // Always re-acquire with None: caller must hold the lock on any return path.
            await asyncLock.LockAsync(CancellationToken.None).ConfigureAwait(false);
            throw;
        }

        // Re-acquire after signal. Use None to guarantee we come back holding the lock
        // even if ct fires between receiving the signal and completing the re-acquisition.
        await asyncLock.LockAsync(CancellationToken.None).ConfigureAwait(false);

        // Propagate cancellation that fired while waiting to re-acquire.
        cancellationToken.ThrowIfCancellationRequested();
    }

    /// <summary>
    /// Wakes one waiting task. If no tasks are waiting, the signal is lost.
    /// </summary>
    public void Signal()
    {
        ManualResetValueTaskSource<bool>? toSignal;

        _spinLock.Enter();
        try
        {
            toSignal = _waiters.Count > 0 ? _waiters.Dequeue() : null;
        }
        finally
        {
            _spinLock.Exit();
        }

        toSignal?.SetResult(true);
    }

    /// <summary>
    /// Wakes all waiting tasks. If no tasks are waiting, the signal is lost.
    /// </summary>
    public void SignalAll()
    {
        ManualResetValueTaskSource<bool>? chain;

        _spinLock.Enter();
        try
        {
            chain = _waiters.DetachAll(out _);
        }
        finally
        {
            _spinLock.Exit();
        }

        chain?.SetChainResult(true);
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _cancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<bool>)state!;
        var context = (AsyncConditionVariable)waiter.Owner!;
        context.CancellationCallback(waiter);
    };

    private void CancellationCallback(ManualResetValueTaskSource<bool> waiter)
    {
#else
    private void CancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<bool> waiter)
        {
            return;
        }
#endif

        ManualResetValueTaskSource<bool>? toCancel = null;

        _spinLock.Enter();
        try
        {
            if (_waiters.Remove(waiter))
            {
                toCancel = waiter;
            }
        }
        finally
        {
            _spinLock.Exit();
        }

        toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
    }
}
