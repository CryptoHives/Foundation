// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

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
/// private readonly AsyncBarrier _barrier = new AsyncBarrier(3);
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
    private readonly LocalManualResetValueTaskSource<bool> _localWaiter;
    private readonly IGetPooledManualResetValueTaskSource<bool> _pool;
#if NET9_0_OR_GREATER
    private readonly Lock _mutex;
#else
    private readonly object _mutex;
#endif
    private readonly int _participantCount;
    private int _remainingParticipants;
    private long _currentPhase;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// Constructs a new AsyncBarrier instance with the specified number of participants.
    /// </summary>
    /// <param name="participantCount">The number of participants required to release the barrier.</param>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    /// <param name="defaultEventQueueSize">The default waiter queue size.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than or equal to zero.</exception>
    public AsyncBarrier(int participantCount, bool runContinuationAsynchronously = true, int defaultEventQueueSize = 0, IGetPooledManualResetValueTaskSource<bool>? pool = null)
    {
        if (participantCount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(participantCount), participantCount, "Participant count must be greater than zero.");
        }

        _participantCount = participantCount;
        _remainingParticipants = participantCount;
        _currentPhase = 0;
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _mutex = new();
        _waiters = new(defaultEventQueueSize > 0 ? defaultEventQueueSize : participantCount);
        _localWaiter = new(this);
        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolBoolean;
    }

    /// <summary>
    /// Gets the total number of participants in the barrier.
    /// </summary>
    public int ParticipantCount => _participantCount;

    /// <summary>
    /// Gets the number of participants still needed to release the current phase.
    /// </summary>
    public int RemainingParticipants
    {
        get { lock (_mutex) return _remainingParticipants; }
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
    /// When the last participant signals, all waiting participants are released and the barrier
    /// resets for the next phase.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask"/> that completes when all participants have arrived.</returns>
    /// <exception cref="InvalidOperationException">Thrown when more participants signal than expected.</exception>
    public ValueTask SignalAndWaitAsync(CancellationToken cancellationToken = default)
    {
        int count;
        ManualResetValueTaskSource<bool>[]? toRelease = null;

        lock (_mutex)
        {
            if (_remainingParticipants <= 0)
            {
                throw new InvalidOperationException("More participants have signaled than the barrier expects.");
            }

            _remainingParticipants--;

            if (_remainingParticipants == 0)
            {
                _remainingParticipants = _participantCount;
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

                if (toRelease is not null)
                {
                    try
                    {
                        for (int i = 0; i < count; i++)
                        {
                            toRelease[i].SetResult(true);
                        }
                    }
                    finally
                    {
                        ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Return(toRelease);
                    }
                }

                return default;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                _remainingParticipants++;
                return new ValueTask(Task.FromCanceled<bool>(cancellationToken));
            }

            if (!_localWaiter.TryGetValueTaskSource(out ManualResetValueTaskSource<bool> waiter))
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

            _waiters.Enqueue(waiter);
            return new ValueTask(waiter, waiter.Version);
        }
    }

    /// <summary>
    /// Adds a new participant to the barrier dynamically.
    /// </summary>
    /// <returns>The phase number after adding the participant.</returns>
    /// <exception cref="InvalidOperationException">Thrown when attempting to add participants to a barrier in an invalid state.</exception>
    public long AddParticipant()
    {
        return AddParticipants(1);
    }

    /// <summary>
    /// Adds the specified number of participants to the barrier dynamically.
    /// </summary>
    /// <param name="participantCount">The number of participants to add.</param>
    /// <returns>The phase number after adding the participants.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than 1.</exception>
    public long AddParticipants(int participantCount)
    {
        if (participantCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(participantCount), participantCount, "Participant count must be at least 1.");
        }

        lock (_mutex)
        {
            _remainingParticipants += participantCount;
            return _currentPhase;
        }
    }

    /// <summary>
    /// Removes a participant from the barrier dynamically.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when there are no remaining participants to remove.</exception>
    public void RemoveParticipant()
    {
        RemoveParticipants(1);
    }

    /// <summary>
    /// Removes the specified number of participants from the barrier dynamically.
    /// </summary>
    /// <param name="participantCount">The number of participants to remove.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="participantCount"/> is less than 1.</exception>
    /// <exception cref="InvalidOperationException">Thrown when there are not enough remaining participants to remove.</exception>
    public void RemoveParticipants(int participantCount)
    {
        if (participantCount < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(participantCount), participantCount, "Participant count must be at least 1.");
        }

        int count;
        ManualResetValueTaskSource<bool>[]? toRelease = null;

        lock (_mutex)
        {
            if (participantCount > _remainingParticipants)
            {
                throw new InvalidOperationException("Cannot remove more participants than are remaining.");
            }

            _remainingParticipants -= participantCount;

            if (_remainingParticipants == 0)
            {
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
            else
            {
                return;
            }
        }

        if (toRelease is not null)
        {
            try
            {
                for (int i = 0; i < count; i++)
                {
                    toRelease[i].SetResult(true);
                }
            }
            finally
            {
                ArrayPool<ManualResetValueTaskSource<bool>>.Shared.Return(toRelease);
            }
        }
    }

    /// <summary>
    /// Gets a value indicating whether the local waiter is currently in use.
    /// </summary>
    internal bool InternalWaiterInUse => _localWaiter.InUse;

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
                    _remainingParticipants++;
                    continue;
                }
                _waiters.Enqueue(dequeued);
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<bool>(waiter.CancellationToken)));
    }
}
