// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1031 // Catch a more specific allowed exception type

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

/// <summary>
/// An async barrier synchronization primitive which uses a pooled approach
/// to implement waiters for <see cref="ValueTask"/> to reduce memory allocations.
/// </summary>
/// <remarks>
/// <para>
/// This implementation uses <see cref="ValueTask"/> for waiters and provides allocation-free
/// async signaling by reusing pooled <see cref="IValueTaskSource{TResult}"/> instances to avoid allocations
/// of <see cref="TaskCompletionSource{TResult}"/> and <see cref="Task"/>.
/// </para>
/// <para>
/// A barrier synchronizes a fixed number of participants, releasing all of them when all have arrived.
/// After release, the barrier automatically resets for the next phase.
/// </para>
/// <para>
/// An optional post-phase action can be provided that is executed after all participants have arrived
/// but before they are released. If the post-phase action throws an exception, all participants will
/// receive a <see cref="BarrierPostPhaseException"/>.
/// </para>
/// <para>
/// <b>Post-phase action contract:</b> the action runs on the thread of the participant that completed
/// the phase - the last to signal, or the caller of <see cref="RemoveParticipants"/> that removed the
/// last outstanding one. It observes <see cref="CurrentPhase"/> as the phase it is completing, and no
/// participant is released until it returns. It runs with no internal lock held, so it may block, do
/// I/O, or take as long as it needs; in particular it may cancel a
/// <see cref="CancellationToken"/> that one of this barrier's own waiters is registered on without
/// deadlocking. It must not reenter the barrier:
/// <see cref="SignalAndWaitAsync(CancellationToken)"/>, <see cref="AddParticipants"/> and
/// <see cref="RemoveParticipants"/> all throw <see cref="InvalidOperationException"/> when called from
/// within it.
/// </para>
/// <para>
/// <b>Optional timeout and cancellation token</b> parameters on
/// <see cref="SignalAndWaitAsync(TimeSpan, CancellationToken)"/>.
/// </para>
/// <para>
/// <b>Important Usage Note:</b> Awaiting on <see cref="ValueTask"/> has its own caveats, as it
/// is a struct that can only be awaited or converted with AsTask() ONE single time.
/// Additional attempts to await after the first await or additional conversions to AsTask() will throw
/// an <see cref="InvalidOperationException"/>.
/// </para>
/// <para>
/// <b>Continuation Scheduling:</b> The <see cref="RunContinuationAsynchronously"/> property
/// controls how continuations are executed when all participants arrive. When set to <see langword="true"/>
/// (default), continuations are forced to queue to the thread pool.
/// </para>
/// <para>
/// <b>Allocation Behavior:</b> Immediate acquisitions are completely allocation-free using atomic 
/// operations. When the barrier is contended, waiting without a timeout is allocation-free on .NET 6.0+ 
/// (using <c>UnsafeRegister</c> for cancellation), while older frameworks may allocate for cancellation 
/// registration. Specifying a finite timeout allocates a timer that is automatically disposed when the 
/// operation completes. Exception and task allocations occur only if a timeout actually elapses or 
/// cancellation is triggered; successful acquisitions are otherwise allocation-free. Pooled 
/// <see cref="IValueTaskSource{TResult}"/> instances are reused to minimize allocation pressure across 
/// repeated lock operations.
/// </para>
/// <example>
/// <code>
/// private readonly AsyncBarrier _barrier = new AsyncBarrier(3, b =>
/// {
///     Console.WriteLine($"Phase {b.CurrentPhase} completed");
/// });
///
/// public async Task ParticipantWorkAsync(CancellationToken ct)
/// {
///     // Do some work
///     await DoPhase1WorkAsync();
///
///     // Wait for all participants to complete phase 1
///     await _barrier.SignalAndWaitAsync(ct);
///
///     // All participants continue together to phase 2
///     await DoPhase2WorkAsync();
/// }
/// </code>
/// </example>
/// </remarks>
public sealed class AsyncBarrier
{
    /// <summary>
    /// Value of <see cref="_phaseTransitionThreadId"/> when no post-phase action is running.
    /// </summary>
    private const int NoPhaseTransition = 0;

    private readonly IGetPooledManualResetValueTaskSource<bool> _pool;
    private readonly Action<AsyncBarrier>? _postPhaseAction;
    private readonly object _lock;
    private WaiterQueue<bool> _waiters;
    private int _participantCount;
    private int _participantsRemaining;
    private long _currentPhase;
    private bool _runContinuationAsynchronously;
    private int _phaseTransitionThreadId;

    /// <summary>
    /// Constructs a new AsyncBarrier instance with the specified number of participants.
    /// </summary>
    /// <param name="participantCount">The number of participants required to release the barrier.</param>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than or equal to zero.</exception>
    public AsyncBarrier(int participantCount, bool runContinuationAsynchronously = true, IGetPooledManualResetValueTaskSource<bool>? pool = null)
        : this(participantCount, postPhaseAction: null, runContinuationAsynchronously, pool)
    {
    }

    /// <summary>
    /// Constructs a new AsyncBarrier instance with the specified number of participants and a post-phase action.
    /// </summary>
    /// <param name="participantCount">The number of participants required to release the barrier.</param>
    /// <param name="postPhaseAction">
    /// An action to execute after each phase when all participants have arrived.
    /// If this action throws an exception, it is wrapped in a <see cref="BarrierPostPhaseException"/>
    /// and thrown to all participants.
    /// </param>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than or equal to zero.</exception>
    public AsyncBarrier(int participantCount, Action<AsyncBarrier>? postPhaseAction, bool runContinuationAsynchronously = true, IGetPooledManualResetValueTaskSource<bool>? pool = null)
    {
        if (participantCount <= 0) throw new ArgumentOutOfRangeException(nameof(participantCount), participantCount, "Participant count must be greater than zero.");

        _participantCount = participantCount;
        _participantsRemaining = participantCount;
        _currentPhase = 0;
        _postPhaseAction = postPhaseAction;
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _phaseTransitionThreadId = NoPhaseTransition;
        _lock = new();
        _waiters = new();
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolBoolean;
    }

    /// <summary>
    /// Gets the total number of participants in the barrier.
    /// </summary>
    /// <remarks>
    /// This value changes when <see cref="AddParticipant"/>, <see cref="AddParticipants"/>,
    /// <see cref="RemoveParticipant"/>, or <see cref="RemoveParticipants"/> is called.
    /// </remarks>
    public int ParticipantCount
    {
        get => Volatile.Read(ref _participantCount);
    }

    /// <summary>
    /// Gets the number of participants in the barrier that haven't yet signaled in the current phase.
    /// </summary>
    public int ParticipantsRemaining
    {
        get => Volatile.Read(ref _participantsRemaining);
    }

    /// <summary>
    /// Gets the current phase number. Increments each time the barrier is released.
    /// </summary>
    public long CurrentPhase
    {
        get => Volatile.Read(ref _currentPhase);
    }

    /// <summary>
    /// Gets or sets whether to force continuations to run asynchronously.
    /// </summary>
    public bool RunContinuationAsynchronously
    {
        get => _runContinuationAsynchronously;
        set => _runContinuationAsynchronously = value;
    }

    /// <summary>
    /// Signals the barrier and waits for all participants to arrive.
    /// </summary>
    /// <remarks>
    /// When the last participant signals, the post-phase action (if any) is executed,
    /// then all waiting participants are released and the barrier resets for the next phase.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when all participants have arrived.</returns>
    /// <exception cref="InvalidOperationException">Thrown when more participants signal than expected.</exception>
    /// <exception cref="BarrierPostPhaseException">Thrown when the post-phase action throws an exception.</exception>
    public ValueTask SignalAndWaitAsync(CancellationToken cancellationToken = default)
        => SignalAndWaitAsync(Timeout.InfiniteTimeSpan, cancellationToken);

    /// <summary>
    /// Signals the barrier and waits for all participants to arrive, or until the specified timeout elapses.
    /// </summary>
    /// <remarks>
    /// If this is the last participant, the barrier is released immediately without any timeout overhead.
    /// A <see cref="CancellationTokenSource"/> is allocated only when this is not the last participant and
    /// a finite positive timeout is requested; it is disposed automatically when the returned
    /// <see cref="ValueTask"/> is awaited.
    /// </remarks>
    /// <param name="timeout">
    /// The maximum time to wait for all participants. Use <see cref="Timeout.InfiniteTimeSpan"/> to wait indefinitely.
    /// </param>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when all participants have arrived.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timeout"/> is negative and not equal to <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </exception>
    /// <exception cref="TimeoutException">
    /// Thrown when the timeout elapses before all participants arrive.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before all participants arrive.
    /// </exception>
    /// <exception cref="InvalidOperationException">Thrown when more participants signal than expected.</exception>
    /// <exception cref="BarrierPostPhaseException">Thrown when the post-phase action throws an exception.</exception>
    public ValueTask SignalAndWaitAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan) throw new ArgumentOutOfRangeException(nameof(timeout));

        ManualResetValueTaskSource<bool>? toReleaseChain = null;
        PooledManualResetValueTaskSource<bool>? waiter = null;
        bool postPhaseActionPending = false;
        short version = 0;

        lock (_lock)
        {
            WaitForStablePhase();

            if (_participantsRemaining <= 0)
            {
                throw new InvalidOperationException("The number of threads using the barrier exceeded the total number of registered participants.");
            }

            _participantsRemaining--;

            if (_participantsRemaining > 0)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    _participantsRemaining++;
                    return new ValueTask(Task.FromCanceled<bool>(cancellationToken));
                }

                if (timeout == TimeSpan.Zero)
                {
                    _participantsRemaining++;
                    return new ValueTask(Task.FromException(new TimeoutException()));
                }

                waiter = _pool.GetPooledWaiter(this);
                waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
                waiter.CancellationToken = cancellationToken;

                version = waiter.Version;
                _waiters.Enqueue(waiter);

                if (timeout != Timeout.InfiniteTimeSpan)
                {
                    waiter.TimeoutTimer = TimeProvider.System.CreateTimer(
                        _timerCallbackAction, new TimeoutState<bool>(waiter), timeout, Timeout.InfiniteTimeSpan);
                }
            }
            else
            {
                // Last participant. Detach the waiters up front, so timeout or cancel callback can finish
                // instead of waiting for the post phase action.
                toReleaseChain = _waiters.DetachAll(out _);

                if (_postPhaseAction is null)
                {
                    AdvancePhase();
                }
                else
                {
                    // Advancing is deferred until the action has run, so that it observes the phase it
                    // is completing rather than the next one.
                    _phaseTransitionThreadId = Environment.CurrentManagedThreadId;
                    postPhaseActionPending = true;
                }
            }
        }

        if (waiter is not null)
        {
            // Registered outside the lock: the callback can fire synchronously on this thread if the
            // token is already cancelled, and it takes the lock itself.
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

        if (postPhaseActionPending)
        {
            Exception? postPhaseException = RunPostPhaseActionAndAdvancePhase();

            if (postPhaseException is not null)
            {
                WaiterQueue<bool>.SetChainException(toReleaseChain, postPhaseException);
                return new ValueTask(Task.FromException(postPhaseException));
            }
        }

        toReleaseChain?.SetChainResult(true);
        return default;
    }

    /// <summary>
    /// Resets the participant count for the next phase and advances the phase number.
    /// </summary>
    /// <remarks>Must be called while holding <see cref="_lock"/>.</remarks>
    private void AdvancePhase()
    {
        _participantsRemaining = _participantCount;
        _currentPhase++;
    }

    /// <summary>
    /// Blocks until no post-phase action is running.
    /// </summary>
    /// <remarks>
    /// Must be called while holding <see cref="_lock"/>. The reentrancy check has to precede the wait:
    /// a monitor is reentrant, so the thread running the action would otherwise re-enter the lock and
    /// then wait for itself to finish.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown when called from the thread currently running the post-phase action.
    /// </exception>
    private void WaitForStablePhase()
    {
        while (_phaseTransitionThreadId != NoPhaseTransition)
        {
            if (_phaseTransitionThreadId == Environment.CurrentManagedThreadId)
            {
                throw new InvalidOperationException(
                    "The barrier cannot be reentered from within its own post-phase action.");
            }

            Monitor.Wait(_lock);
        }
    }

    /// <summary>
    /// Runs the post-phase action outside <see cref="_lock"/>, then advances the phase and ends the
    /// transition under it.
    /// </summary>
    /// <remarks>
    /// The phase is advanced in a <see langword="finally"/> so that an action throwing something outside
    /// the caught set - <see cref="OutOfMemoryException"/> and friends - still leaves the barrier usable
    /// rather than wedged in a transition no other operation can get past.
    /// </remarks>
    /// <returns>
    /// The <see cref="BarrierPostPhaseException"/> wrapping whatever the action threw, or
    /// <see langword="null"/> if it returned normally.
    /// </returns>
    private Exception? RunPostPhaseActionAndAdvancePhase()
    {
        Debug.Assert(_postPhaseAction is not null, "Caller checked for a post-phase action.");

        Exception? postPhaseException = null;

        try
        {
            _postPhaseAction!(this);
        }
        catch (Exception ex) when (ex is not OutOfMemoryException
            && ex is not StackOverflowException
            && ex is not AccessViolationException)
        {
            postPhaseException = new BarrierPostPhaseException(ex);
        }
        finally
        {
            lock (_lock)
            {
                AdvancePhase();
                _phaseTransitionThreadId = NoPhaseTransition;
                Monitor.PulseAll(_lock);
            }
        }

        return postPhaseException;
    }

    /// <summary>
    /// Notifies the <see cref="AsyncBarrier"/> that there will be an additional participant.
    /// </summary>
    /// <returns>The phase number of the barrier when the participant is added.</returns>
    /// <exception cref="InvalidOperationException">Thrown when adding a participant would cause an overflow.</exception>
    public long AddParticipant()
    {
        return AddParticipants(1);
    }

    /// <summary>
    /// Notifies the <see cref="AsyncBarrier"/> that there will be additional participants.
    /// </summary>
    /// <param name="participantCount">The number of additional participants to add.</param>
    /// <returns>The phase number of the barrier when the participants are added.</returns>
    /// <remarks>
    /// If a post-phase action is running on another thread this waits for it to finish first, so the
    /// participant count never changes underneath it.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than 1.</exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when adding participants would cause an overflow, or when called from within the barrier's
    /// own post-phase action.
    /// </exception>
    public long AddParticipants(int participantCount)
    {
        if (participantCount < 1) throw new ArgumentOutOfRangeException(nameof(participantCount), participantCount, "The participantCount argument must be a positive value.");

        lock (_lock)
        {
            WaitForStablePhase();

            // Check for overflow
            if (_participantCount > int.MaxValue - participantCount)
            {
                throw new InvalidOperationException("Adding the specified number of participants would cause the barrier's participant count to exceed int.MaxValue.");
            }

            _participantCount += participantCount;
            _participantsRemaining += participantCount;
            return _currentPhase;
        }
    }

    /// <summary>
    /// Notifies the <see cref="AsyncBarrier"/> that there will be one less participant.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when there are no participants to remove, or when the barrier would have zero participants.</exception>
    public void RemoveParticipant()
    {
        RemoveParticipants(1);
    }

    /// <summary>
    /// Notifies the <see cref="AsyncBarrier"/> that there will be fewer participants.
    /// </summary>
    /// <param name="participantCount">The number of participants to remove.</param>
    /// <remarks>
    /// If a post-phase action is running on another thread this waits for it to finish first, so the
    /// participant count never changes underneath it. Removing the last outstanding participant
    /// completes the phase, and therefore runs the post-phase action on the calling thread.
    /// </remarks>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than 1.</exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when there are not enough participants to remove, when the barrier would have zero
    /// participants, or when called from within the barrier's own post-phase action.
    /// </exception>
    /// <exception cref="BarrierPostPhaseException">
    /// Thrown when removing the last outstanding participant completes the phase and the post-phase
    /// action throws.
    /// </exception>
    public void RemoveParticipants(int participantCount)
    {
        if (participantCount < 1) throw new ArgumentOutOfRangeException(nameof(participantCount), participantCount, "The participantCount argument must be a positive value.");

        ManualResetValueTaskSource<bool>? toRelease = null;
        bool postPhaseActionPending = false;

        lock (_lock)
        {
            WaitForStablePhase();

            if (participantCount > _participantCount)
            {
                throw new InvalidOperationException("The participantCount argument is greater than the number of participants.");
            }

            if (participantCount > _participantsRemaining)
            {
                throw new InvalidOperationException("The participantCount argument is greater than the number of participants that haven't yet signaled.");
            }

            _participantCount -= participantCount;
            _participantsRemaining -= participantCount;

            // If this causes remaining to hit zero, advance the phase
            if (_participantsRemaining == 0 && _participantCount > 0)
            {
                // Detached before the action runs, for the same reason as in SignalAndWaitAsync.
                toRelease = _waiters.DetachAll(out _);

                if (_postPhaseAction is null)
                {
                    AdvancePhase();
                }
                else
                {
                    _phaseTransitionThreadId = Environment.CurrentManagedThreadId;
                    postPhaseActionPending = true;
                }
            }
            else if (_participantCount == 0)
            {
                // All participants removed - release any waiters without advancing phase
                toRelease = _waiters.DetachAll(out int detachedCount);
                if (detachedCount == 0)
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        if (postPhaseActionPending)
        {
            Exception? postPhaseException = RunPostPhaseActionAndAdvancePhase();

            if (postPhaseException is not null)
            {
                WaiterQueue<bool>.SetChainException(toRelease, postPhaseException);
                throw postPhaseException;
            }
        }

        toRelease?.SetChainResult(true);
    }

    /// <summary>
    /// Callback used with <see cref="Timer"/> to trigger timeout.
    /// The stamped version guards against a stale callback observing a recycled waiter.
    /// </summary>
    private static readonly TimerCallback _timerCallbackAction = static state => {
        var timeoutState = (TimeoutState<bool>)state!;
        var context = (AsyncBarrier)timeoutState.Source.Owner!;
        ManualResetValueTaskSource<bool>? toCancel = context.RemoveWaiter(timeoutState.Source, timeoutState.Version);
        toCancel?.SetException(new TimeoutException());
    };

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _cancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<bool>)state!;
        var context = (AsyncBarrier)waiter.Owner!;
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
        ManualResetValueTaskSource<bool>? toCancel = RemoveWaiter(waiter, waiter.Version);
        toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
    }

    /// <summary>
    /// O(1) removal from intrusive linked list.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Deliberately does <b>not</b> call <see cref="WaitForStablePhase"/>. This is the timeout and
    /// cancellation path, and letting it run while a post-phase action is in flight is the entire point
    /// of running that action outside <see cref="_lock"/>. It is safe during a transition because the
    /// queue has already been detached, so the removal simply fails and the waiter is completed by the
    /// detached chain instead.
    /// </para>
    /// <para>
    /// It also runs reentrantly, when a post-phase action cancels a token one of this barrier's own
    /// waiters is registered on - the registration fires synchronously on that thread. A monitor
    /// tolerates that; the library's spin lock would have deadlocked.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ManualResetValueTaskSource<bool>? RemoveWaiter(ManualResetValueTaskSource<bool> waiter, short version)
    {
        lock (_lock)
        {
            // A stale timer callback must not touch a recycled waiter: the version
            // changes when the waiter is reset for reuse, and re-enqueueing requires
            // this lock, so the check and the removal are atomic w.r.t. reuse.
            if (waiter.Version == version && _waiters.Remove(waiter))
            {
                _participantsRemaining++;
                return waiter;
            }
        }

        return null;
    }
}
