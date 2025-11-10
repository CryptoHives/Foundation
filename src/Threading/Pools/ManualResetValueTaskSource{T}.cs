// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Threading;
using System.Threading.Tasks.Sources;

/// <summary>
/// Represents a synchronization primitive that can be used to signal the completion of an operation.
/// </summary>
/// <remarks>
/// This class is a sealed implementation of <see cref="IValueTaskSource{T}"/> and provides methods to
/// manage the lifecycle of a task-like operation. It allows resetting and signaling the completion of the operation,
/// and supports querying the status and retrieving the result.
/// The <see cref="IResettable"/> interface is implemented to allow resetting the state of the instance for reuse by an <see cref="ObjectPool"/>.
/// </remarks>
public sealed class ManualResetValueTaskSource<T> : IValueTaskSource<T>, IValueTaskSource, IResettable
{
    private ManualResetValueTaskSourceCore<T> _core = default;
    private ObjectPool<ManualResetValueTaskSource<T>>? _ownerPool;

    /// <summary>
    /// Sets the pool to which the object is returned after it was awaited.
    /// </summary>
    public void SetOwnerPool(ObjectPool<ManualResetValueTaskSource<T>>? ownerPool)
    {
        _ownerPool = ownerPool;
    }

    /// <summary>
    /// Gets the version number of the current instance.
    /// </summary>
    public short Version => _core.Version;

    /// <inheritdoc/>
    /// <remarks>
    /// This method increments the version number to reflect the reset operation.
    /// </remarks>
    public bool TryReset()
    {
        _ownerPool = null;
        _core.Reset();
        return true;
    }

    /// <summary>
    /// Signals the completion of an operation, setting the result to T.
    /// </summary>
    /// <remarks>
    /// This method is typically used to indicate that an asynchronous operation has completed successfully.
    /// </remarks>
    public void SetResult(T result)
        => _core.SetResult(result);

    /// <summary>
    /// Sets the specified exception to be associated with the current operation.
    /// </summary>
    public void SetException(Exception ex)
        => _core.SetException(ex);

    /// <inheritdoc/>
    T IValueTaskSource<T>.GetResult(short token)
    {
        T result = _core.GetResult(token);
        _ownerPool?.Return(this);
        return result;
    }


    /// <inheritdoc/>
    void IValueTaskSource.GetResult(short token)
    {
        _core.GetResult(token);
        _ownerPool?.Return(this);
    }

    /// <inheritdoc/>
    public ValueTaskSourceStatus GetStatus(short token)
        => _core.GetStatus(token);

    /// <inheritdoc/>
    public void OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags)
        => _core.OnCompleted(continuation, state, token, flags);
}
