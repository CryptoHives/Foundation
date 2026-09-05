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
/// An async condition variable that pairs with <see cref="AsyncLock"/> to provide
/// "wait until condition" semantics without blocking a thread, equivalent to
/// <see cref="Monitor.Wait(object)"/> for async code.
/// </summary>
/// <remarks>
/// <para>
/// A condition variable must always be used in conjunction with an <see cref="AsyncLock"/>.
/// The caller must hold the lock when calling <see cref="WaitAsync(AsyncLock, CancellationToken)"/>.
/// The wait atomically releases the lock and suspends the caller until <see cref="Signal"/> or
/// <see cref="SignalAll"/> is called, after which it re-acquires the lock before returning.
/// The caller is guaranteed to hold the lock on every return path, including when an exception
/// is thrown.
/// </para>
/// <para>
/// An instance binds to the first <see cref="AsyncLock"/> it is used with. Passing a different
/// lock to a later wait throws an <see cref="InvalidOperationException"/>: a condition variable
/// shared across two locks cannot make the atomic release/re-acquire guarantee, and the resulting
/// corruption is otherwise silent. The binding is cleared by <see cref="TryReset"/>.
/// </para>
/// <para>
/// Unlike <see cref="AsyncManualResetEvent"/> and <see cref="AsyncAutoResetEvent"/>,
/// a signal that fires when no waiters are present is <b>not</b> stored - it is lost.
/// Always use a <c>while</c> loop to re-check the predicate after returning from a wait:
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
/// <b>Cancellation and timeout bound the wait for a signal, not the re-acquisition of the lock.</b>
/// Once a waiter has consumed a signal it always completes successfully, even if the token is
/// cancelled or the timeout elapses while it is queued behind the lock. Reporting cancellation at
/// that point would swallow the signal the waiter has already taken and the next waiter would
/// never be woken. Cancelling therefore only fails a wait that has <em>not</em> been signalled; a
/// caller that must observe cancellation promptly does so in its own predicate loop, which is
/// where the token belongs anyway.
/// </para>
/// <para>
/// <b>Allocation behaviour:</b> the first concurrent waiter uses an instance-local
/// <see cref="IValueTaskSource{T}"/> and further concurrent waiters are served from a pool, so
/// waiting allocates nothing on .NET 6.0+ beyond the state machine described below. Specifying a
/// finite timeout allocates a timer that is disposed when the wait completes.
/// </para>
/// <para>
/// <b>Note:</b> the wait is an <see langword="async"/> method, so it boxes a state machine when it
/// suspends: it awaits two things in sequence, the signal and then the re-acquisition of the lock.
/// Removing that allocation means transferring a signalled waiter directly into the lock's own
/// wait queue instead of completing it and re-acquiring - a deliberate future change rather than
/// an oversight.
/// </para>
/// <para>
/// The <see cref="IResettable"/> interface is implemented to allow resetting the state of the
/// instance for reuse by an <see cref="ObjectPool{T}"/> using the
/// <see cref="DefaultObjectPool{T}"/> implementation.
/// </para>
/// </remarks>
public sealed class AsyncConditionVariable : IResettable
{
    private readonly LocalManualResetValueTaskSource<bool> _localWaiter;
    private readonly IGetPooledManualResetValueTaskSource<bool> _pool;
    private Internal.SpinLock _spinLock;
    private WaiterQueue<bool> _waiters;
    private AsyncLock? _boundLock;
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
        _localWaiter = new(this);
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolBoolean;
    }

    /// <inheritdoc/>
    public bool TryReset()
    {
        // check if the condition variable is not in use before recycling the instance
        if (!_spinLock.TryEnter())
        {
            return false;
        }

        try
        {
            // If waiters are queued, or a completed waiter has not observed its result yet,
            // the instance is still in active use; decline the reset.
            if (_waiters.Count != 0 || _localWaiter.InUse)
            {
                return false;
            }

            _localWaiter.TryReset();
            _boundLock = null;
            _runContinuationAsynchronously = true;
            return true;
        }
        finally
        {
            _spinLock.Exit();
        }
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
    /// Gets a value indicating whether the local waiter is currently in use.
    /// </summary>
    internal bool InternalWaiterInUse => _localWaiter.InUse;

    /// <summary>
    /// Atomically releases <paramref name="asyncLock"/> and waits for a signal, then
    /// re-acquires <paramref name="asyncLock"/> before returning. The caller must hold
    /// <paramref name="asyncLock"/> on entry and will always hold it on return,
    /// including when an exception is thrown.
    /// </summary>
    /// <param name="asyncLock">The lock to release while waiting and re-acquire after signaling.</param>
    /// <param name="cancellationToken">
    /// Token to cancel the wait. A wait that has already consumed a signal completes successfully;
    /// see the type remarks. The lock is re-acquired before the resulting
    /// <see cref="OperationCanceledException"/> is propagated.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> that completes when the caller has been signalled and holds the lock again.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="asyncLock"/> is <see langword="null"/>.</exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when this instance has already been used with a different <see cref="AsyncLock"/>.
    /// </exception>
    /// <exception cref="SynchronizationLockException">
    /// Thrown when <paramref name="asyncLock"/> is not held on entry.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before a signal is received.
    /// The lock is always re-acquired before this exception propagates.
    /// </exception>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask WaitAsync(AsyncLock asyncLock, CancellationToken cancellationToken = default)
        => WaitAsync(asyncLock, Timeout.InfiniteTimeSpan, cancellationToken);

    /// <summary>
    /// Atomically releases <paramref name="asyncLock"/> and waits for a signal or for
    /// <paramref name="timeout"/> to elapse, then re-acquires <paramref name="asyncLock"/> before
    /// returning. The caller must hold <paramref name="asyncLock"/> on entry and will always hold
    /// it on return, including when an exception is thrown.
    /// </summary>
    /// <param name="asyncLock">The lock to release while waiting and re-acquire after signaling.</param>
    /// <param name="timeout">
    /// The maximum time to wait for a signal. Use <see cref="Timeout.InfiniteTimeSpan"/> to wait
    /// indefinitely. The timeout bounds the wait for the signal only, not the re-acquisition of
    /// the lock. <see cref="TimeSpan.Zero"/> always times out: a condition variable holds no state
    /// that a zero-length wait could observe.
    /// </param>
    /// <param name="cancellationToken">
    /// Token to cancel the wait. A wait that has already consumed a signal completes successfully;
    /// see the type remarks.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> that completes when the caller has been signalled and holds the lock again.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="asyncLock"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timeout"/> is negative and not equal to <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when this instance has already been used with a different <see cref="AsyncLock"/>.
    /// </exception>
    /// <exception cref="SynchronizationLockException">
    /// Thrown when <paramref name="asyncLock"/> is not held on entry.
    /// </exception>
    /// <exception cref="TimeoutException">
    /// Thrown when <paramref name="timeout"/> elapses before a signal is received. The lock is
    /// always re-acquired before this exception propagates.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before a signal is received.
    /// The lock is always re-acquired before this exception propagates.
    /// </exception>
    public async ValueTask WaitAsync(AsyncLock asyncLock, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        // Everything that can reject the wait runs before the lock is released, so a rejected
        // wait leaves the caller holding the lock exactly as it found it.
        ValueTask signalTask = EnqueueWaiter(asyncLock, timeout, cancellationToken);

        // Release the lock while suspended. The caller is holding it at this point.
        asyncLock.ReleaseLock();

        try
        {
            await signalTask.ConfigureAwait(false);
        }
        finally
        {
            // Re-acquire on every path - normal completion, cancellation and timeout alike -
            // with CancellationToken.None. The caller must come back holding the lock even when
            // the wait itself failed, otherwise its enclosing using block would release a lock
            // it does not own.
            await asyncLock.LockAsync(CancellationToken.None).ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Validates the wait, enqueues a waiter and arms its timeout and cancellation.
    /// </summary>
    /// <remarks>
    /// The timer and the cancellation registration are armed after the spin lock is released.
    /// Both callbacks take that same lock, and registering an already-cancelled token runs the
    /// callback synchronously on this thread, which would deadlock against the non-reentrant
    /// spin lock. Arming after the waiter is queued also means a callback that does fire
    /// immediately finds the waiter it is supposed to remove.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private ValueTask EnqueueWaiter(AsyncLock asyncLock, TimeSpan timeout, CancellationToken cancellationToken)
    {
        if (asyncLock is null) throw new ArgumentNullException(nameof(asyncLock));
        if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan) throw new ArgumentOutOfRangeException(nameof(timeout));

        AsyncLock? bound = Interlocked.CompareExchange(ref _boundLock, asyncLock, null);
        if (bound is not null && !ReferenceEquals(bound, asyncLock))
        {
            throw new InvalidOperationException(
                "This AsyncConditionVariable is already paired with a different AsyncLock. A condition variable must be used with exactly one lock.");
        }

        // The lock has to be held: releasing a lock this caller does not own would hand it to
        // an unrelated waiter, and the corruption would only surface much later.
        if (!asyncLock.IsTaken)
        {
            throw new SynchronizationLockException(
                "The AsyncLock must be held when waiting on an AsyncConditionVariable.");
        }

        // Check before enqueuing: don't release the lock if the wait cannot succeed anyway.
        cancellationToken.ThrowIfCancellationRequested();

        if (timeout == TimeSpan.Zero)
        {
            throw new TimeoutException();
        }

        ManualResetValueTaskSource<bool> waiter;
        short version;

        _spinLock.Enter();
        try
        {
            if (!_localWaiter.TryGetValueTaskSource(out waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
            }
            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
            waiter.CancellationToken = cancellationToken;

            version = waiter.Version;
            _waiters.Enqueue(waiter);
        }
        finally
        {
            _spinLock.Exit();
        }

        if (timeout != Timeout.InfiniteTimeSpan)
        {
            waiter.TimeoutTimer = TimeProvider.System.CreateTimer(
                _timerCallbackAction, new TimeoutState<bool>(waiter), timeout, Timeout.InfiniteTimeSpan);
        }

        if (cancellationToken.CanBeCanceled)
        {
#if NET6_0_OR_GREATER
            // Use UnsafeRegister on .NET 6+ for allocation free registration
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

        return new ValueTask(waiter, version);
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

    /// <summary>
    /// Callback used with <see cref="TimeProvider"/> to trigger timeout.
    /// The stamped version guards against a stale callback observing a recycled waiter.
    /// </summary>
    private static readonly TimerCallback _timerCallbackAction = static state => {
        var timeoutState = (TimeoutState<bool>)state!;
        var context = (AsyncConditionVariable)timeoutState.Source.Owner!;
        ManualResetValueTaskSource<bool>? toCancel = context.RemoveWaiter(timeoutState.Source, timeoutState.Version);
        toCancel?.SetException(new TimeoutException());
    };

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
        // The version is stable here: GetResult disposes the registration before the
        // waiter is recycled, and disposal waits for an in-flight callback.
        // A waiter that has already been signalled is no longer queued, so RemoveWaiter
        // returns null and the wait completes successfully: the signal it took must not
        // be swallowed.
        ManualResetValueTaskSource<bool>? toCancel = RemoveWaiter(waiter, waiter.Version);
        toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
    }

    /// <summary>
    /// O(1) removal from intrusive linked list.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ManualResetValueTaskSource<bool>? RemoveWaiter(ManualResetValueTaskSource<bool> waiter, short version)
    {
        _spinLock.Enter();
        try
        {
            // A stale timer callback must not touch a recycled waiter: the version
            // changes when the waiter is reset for reuse, and re-enqueueing requires
            // this spin lock, so the check and the removal are atomic w.r.t. reuse.
            if (waiter.Version == version && _waiters.Remove(waiter))
            {
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
