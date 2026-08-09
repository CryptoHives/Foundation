// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Threading;
using System.Threading.Tasks.Sources;

/// <summary>
/// An abstract implementation of <see cref="IValueTaskSource{T}"/>.
/// </summary>
/// <remarks>
/// This class is a sealed implementation of <see cref="IValueTaskSource{T}"/> and provides methods to
/// manage the lifecycle of a task-like operation. It allows resetting and signaling the completion of the operation,
/// and supports querying the status and retrieving the result. In addition, an implementation can set the owner
/// instance to return the instance to the pool when it is no longer needed.
/// This class is designed for direct use with <see cref="WaiterQueue{T}"/> to store the derived waiters allocation free.
/// The <see cref="IResettable"/> interface is implemented to allow resetting the state of the instance for reuse
/// by an implementation of an <see cref="ObjectPool"/> that uses the <see cref="DefaultObjectPool{T}"/> implementation.
/// </remarks>
public abstract class ManualResetValueTaskSource<T> : IValueTaskSource<T>, IValueTaskSource, IResettable
{
    /// <summary>
    /// Link to the next node in the intrusive <see cref="WaiterQueue{T}"/>.
    /// </summary>
    internal ManualResetValueTaskSource<T>? Next { get; set; }

    /// <summary>
    /// Link to the previous node in the intrusive <see cref="WaiterQueue{T}"/>.
    /// </summary>
    internal ManualResetValueTaskSource<T>? Prev { get; set; }

    /// <summary>
    /// Gets the version number of the current instance.
    /// </summary>
    public abstract short Version { get; }

    /// <summary>
    /// Gets or sets the owner associated with this instance.
    /// </summary>
    public abstract object? Owner { get; }

    /// <summary>
    /// Gets or sets whether to force continuations to run asynchronously.
    /// </summary>
    /// <remarks>
    /// Continuations may run asynchronously if this is false, but they'll
    /// never run synchronously if this is true.
    /// </remarks>
    public abstract bool RunContinuationsAsynchronously { get; set; }

    /// <summary>
    /// Gets the <see cref="CancellationToken"/> associated with the current operation.
    /// </summary>
    /// <remarks>
    /// This token may be cancelled during long-running operations.
    /// </remarks>
    public abstract CancellationToken CancellationToken { get; set; }

    /// <summary>
    /// Gets the <see cref="CancellationTokenRegistration"/> associated with the current operation.
    /// </summary>
    /// <remarks>
    /// Use this token to unregister from cancellation requests.
    /// </remarks>
    public abstract CancellationTokenRegistration CancellationTokenRegistration { get; set; }

    /// <summary>
    /// Gets or sets the <see cref="TimeoutTimer"/> used to enforce a timeout on the wait operation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Set to a non-<see langword="null"/> value when the waiter is created with a timeout.
    /// The timer is disposed and cleared by <see cref="TryReset"/> when the waiter is recycled.
    /// </para>
    /// <para>
    /// <b>Assign this after leaving the owner's lock, not inside it.</b> Creating a timer takes the
    /// runtime's process-global timer queue lock and allocates, which is the one cost in those critical
    /// sections that the library cannot bound - and the primitives' spin lock is tuned on the premise
    /// that everything it guards is a few pointer writes.
    /// </para>
    /// <para>
    /// This is safe for the same reason <see cref="CancellationTokenRegistration"/> is already assigned
    /// outside the lock. A waiter is recycled only by <see cref="TryReset"/>, which runs from
    /// <see cref="GetResult"/>, which is reachable only through the <see cref="System.Threading.Tasks.ValueTask"/>
    /// the enqueueing method has not returned yet. So between releasing the lock and returning that
    /// <see cref="System.Threading.Tasks.ValueTask"/>, the waiter is owned exclusively by the enqueueing
    /// thread: another thread may <see cref="SetResult"/> it, but cannot reset it, so
    /// <see cref="Version"/> is stable and the timer cannot be disposed underneath the assignment.
    /// </para>
    /// <para>
    /// A waiter completed inside that window still gets a timer, which fires and finds either a version
    /// mismatch or a waiter no longer in the queue, and does nothing - the stale-callback case
    /// <see cref="TimeoutState{T}"/> already exists to handle.
    /// </para>
    /// </remarks>
    public abstract ITimer? TimeoutTimer { get; set; }

    /// <summary>
    /// Signals the completion of an operation, setting the result to T.
    /// </summary>
    /// <remarks>
    /// This method is typically used to indicate that an asynchronous operation has completed successfully.
    /// </remarks>
    public abstract void SetResult(T result);

    /// <summary>
    /// Signals the completion of an operation, setting the result to T for a chain of operations.
    /// </summary>
    /// <remarks>
    /// This method is typically used to indicate that a chain of asynchronous operations has completed successfully.
    /// </remarks>
    public abstract void SetChainResult(T result);

    /// <summary>
    /// Sets the specified exception to be associated with the current operation.
    /// </summary>
    public abstract void SetException(Exception ex);

    /// <inheritdoc/>
    /// <remarks>
    /// This method increments the version number to reflect the reset operation.
    /// </remarks>
    public abstract bool TryReset();

    /// <inheritdoc/>
    public abstract T GetResult(short token);

    /// <inheritdoc/>
    void IValueTaskSource.GetResult(short token)
        => GetResult(token);

    /// <inheritdoc/>
    public abstract ValueTaskSourceStatus GetStatus(short token);

    /// <inheritdoc/>
    public abstract void OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags);
}
