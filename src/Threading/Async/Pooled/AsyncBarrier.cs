// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1031 // Catch a more specific allowed exception type

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
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
    private readonly Queue<ManualResetValueTaskSource<bool>> _waiters;
    private readonly IGetPooledManualResetValueTaskSource<bool> _pool;
    private readonly Action<AsyncBarrier>? _postPhaseAction;
#if NET9_0_OR_GREATER
    private readonly Lock _mutex;
#else
    private readonly object _mutex;
#endif
    private int _participantCount;
    private int _participantsRemaining;
    private long _currentPhase;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// Constructs a new AsyncBarrier instance with the specified number of participants.
    /// </summary>
    /// <param name="participantCount">The number of participants required to release the barrier.</param>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    /// <param name="defaultEventQueueSize">The default waiter queue size. Size default is participantCount.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than or equal to zero.</exception>
    public AsyncBarrier(int participantCount, bool runContinuationAsynchronously = true, int defaultEventQueueSize = 0, IGetPooledManualResetValueTaskSource<bool>? pool = null)
        : this(participantCount, postPhaseAction: null, runContinuationAsynchronously, defaultEventQueueSize, pool)
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
    /// <param name="defaultEventQueueSize">The default waiter queue size.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than or equal to zero.</exception>
    public AsyncBarrier(int participantCount, Action<AsyncBarrier>? postPhaseAction, bool runContinuationAsynchronously = true, int defaultEventQueueSize = 0, IGetPooledManualResetValueTaskSource<bool>? pool = null)
    {
        if (participantCount <= 0) throw new ArgumentOutOfRangeException(nameof(participantCount), participantCount, "Participant count must be greater than zero.");

        _participantCount = participantCount;
        _participantsRemaining = participantCount;
        _currentPhase = 0;
        _postPhaseAction = postPhaseAction;
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _mutex = new();
        _waiters = new(defaultEventQueueSize > 0 ? defaultEventQueueSize : participantCount);
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
        get { lock (_mutex) return _participantCount; }
    }

    /// <summary>
    /// Gets the number of participants in the barrier that haven't yet signaled in the current phase.
    /// </summary>
    public int ParticipantsRemaining
    {
        get { lock (_mutex) return _participantsRemaining; }
    }

    /// <summary>
    /// Gets the current phase number. Increments each time the barrier is released.
    /// </summary>
    public long CurrentPhase
    {
        get { lock (_mutex) return _currentPhase; }
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
    {
        int count;
        ManualResetValueTaskSource<bool>[]? toRelease = null;
        Exception? postPhaseException = null;

        lock (_mutex)
        {
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

                PooledManualResetValueTaskSource<bool> waiter;
                waiter = _pool.GetPooledWaiter(this);
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
                return new ValueTask(waiter, waiter.Version);
            }

            // Last participant - execute post-phase action, then release all waiters and advance phase
            if (_postPhaseAction is not null)
            {
                try
                {
                    _postPhaseAction(this);
                }
                catch (Exception ex)
                {
                    postPhaseException = new BarrierPostPhaseException(ex);
                }
            }

            _participantsRemaining = _participantCount;
            _currentPhase++;

            count = _waiters.Count;
            if (count > 0)
            {
                toRelease = ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Rent(count);
                for (int i = 0; i < count; i++)
                {
                    toRelease[i] = _waiters.Dequeue();
                }
                Debug.Assert(_waiters.Count == 0);
            }
        }

        if (toRelease is not null)
        {
            try
            {
                if (postPhaseException is not null)
                {
                    for (int i = 0; i < count; i++)
                    {
                        toRelease[i].SetException(postPhaseException);
                    }
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        toRelease[i].SetResult(true);
                    }
                }
            }
            finally
            {
                ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Return(toRelease);
            }
        }

        // The last participant (caller) also needs to see the exception
        if (postPhaseException is not null)
        {
            return new ValueTask(Task.FromException(postPhaseException));
        }

        return default;
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
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than 1.</exception>
    /// <exception cref="InvalidOperationException">Thrown when adding participants would cause an overflow.</exception>
    public long AddParticipants(int participantCount)
    {
        if (participantCount < 1) throw new ArgumentOutOfRangeException(nameof(participantCount), participantCount, "The participantCount argument must be a positive value.");

        lock (_mutex)
        {
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
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than 1.</exception>
    /// <exception cref="InvalidOperationException">Thrown when there are not enough participants to remove, or when the barrier would have zero participants.</exception>
    public void RemoveParticipants(int participantCount)
    {
        if (participantCount < 1) throw new ArgumentOutOfRangeException(nameof(participantCount), participantCount, "The participantCount argument must be a positive value.");

        int count;
        ManualResetValueTaskSource<bool>[]? toRelease = null;
        Exception? postPhaseException = null;

        lock (_mutex)
        {
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
                // Execute post-phase action
                if (_postPhaseAction is not null)
                {
                    try
                    {
                        _postPhaseAction(this);
                    }
                    catch (Exception ex)
                    {
                        postPhaseException = new BarrierPostPhaseException(ex);
                    }
                }

                _currentPhase++;
                _participantsRemaining = _participantCount;

                count = _waiters.Count;
                if (count > 0)
                {
                    toRelease = ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Rent(count);
                    for (int i = 0; i < count; i++)
                    {
                        toRelease[i] = _waiters.Dequeue();
                    }
                    Debug.Assert(_waiters.Count == 0);
                }
            }
            else if (_participantCount == 0)
            {
                // All participants removed - release any waiters without advancing phase
                count = _waiters.Count;
                if (count > 0)
                {
                    toRelease = ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Rent(count);
                    for (int i = 0; i < count; i++)
                    {
                        toRelease[i] = _waiters.Dequeue();
                    }
                    Debug.Assert(_waiters.Count == 0);
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        if (toRelease is not null)
        {
            try
            {
                if (postPhaseException is not null)
                {
                    for (int i = 0; i < count; i++)
                    {
                        toRelease[i].SetException(postPhaseException);
                    }
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        toRelease[i].SetResult(true);
                    }
                }
            }
            finally
            {
                ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Return(toRelease);
            }
        }

        // Throw for the caller of RemoveParticipants if post-phase action failed
        if (postPhaseException is not null)
        {
            throw postPhaseException;
        }
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _cancellationCallbackAction = static (state, ct) =>
    {
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

        ManualResetValueTaskSource<bool>? toCancel = null;
        lock (_mutex)
        {
            int count = _waiters.Count;
            while (count-- > 0)
            {
                var dequeued = _waiters.Dequeue();
                if (ReferenceEquals(dequeued, waiter))
                {
                    toCancel = waiter;
                    _participantsRemaining++;
                    continue;
                }
                _waiters.Enqueue(dequeued);
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<bool>(waiter.CancellationToken)));
    }
}
