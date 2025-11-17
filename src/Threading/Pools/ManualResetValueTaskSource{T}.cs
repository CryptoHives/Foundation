// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Threading.Tasks.Sources;

/// <summary>
/// An abstract implementation of <see cref="IValueTaskSource{T}"/>.
/// </summary>
/// <remarks>
/// This class is a sealed implementation of <see cref="IValueTaskSource{T}"/> and provides methods to
/// manage the lifecycle of a task-like operation. It allows resetting and signaling the completion of the operation,
/// and supports querying the status and retrieving the result. In addition, an implementation can set the owner
/// instance to return the instance to the pool when it is no longer needed.
/// The <see cref="IResettable"/> interface is implemented to allow resetting the state of the instance for reuse
/// by an implementation of an <see cref="ObjectPool"/> that uses the <see cref="DefaultObjectPool{T}"/> implementation.
/// </remarks>
internal abstract class ManualResetValueTaskSource<T> : IValueTaskSource<T>, IValueTaskSource, IResettable
{
    /// <summary>
    /// Gets the version number of the current instance.
    /// </summary>
    public abstract short Version { get; }

    /// <summary>
    /// Gets or sets whether to force continuations to run asynchronously.
    /// </summary>
    /// <remarks>
    /// Continuations may run asynchronously if this is false, but they'll
    /// never run synchronously if this is true.
    /// </remarks>
    public abstract bool RunContinuationsAsynchronously { get; set; }

    /// <summary>
    /// Signals the completion of an operation, setting the result to T.
    /// </summary>
    /// <remarks>
    /// This method is typically used to indicate that an asynchronous operation has completed successfully.
    /// </remarks>
    public abstract void SetResult(T result);

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
