// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using Microsoft.Extensions.ObjectPool;
using System;
using System.Threading;
using System.Threading.Tasks.Sources;

/// <summary>
/// An implementation of <see cref="IValueTaskSource{T}"/>.
/// </summary>
/// <remarks>
/// This class is a sealed implementation of <see cref="IValueTaskSource{T}"/> which provides methods to
/// manage the lifecycle of a task-like operation. It allows resetting and signaling the completion of the operation,
/// and supports querying the status and retrieving the result. In addition, the owner pool can be set to return
/// the instance to the pool when it is no longer needed.
/// This class can be directly used with <see cref="WaiterQueue{T}"/> to store the waiters allocation free.
/// The <see cref="IResettable"/> interface is implemented to allow resetting the state of the instance for reuse
/// by an implementation of an <see cref="ObjectPool"/> that uses the <see cref="DefaultObjectPool{T}"/> implementation.
/// </remarks>
public sealed class PooledManualResetValueTaskSource<T> : ManualResetValueTaskSource<T>
{
    private ManualResetValueTaskSourceCore<T> _core;
    private CancellationTokenRegistration _cancellationTokenRegistration;
    private CancellationToken _cancellationToken;
    private ObjectPool<PooledManualResetValueTaskSource<T>>? _ownerPool;
    private object? _owner;

    /// <summary>
    /// Sets the pool to which the object is returned after it was awaited.
    /// Sets the owner of the pooled instance.
    /// </summary>
    public void SetOwnerPool(ObjectPool<PooledManualResetValueTaskSource<T>> ownerPool, object? owner)
    {
        _ownerPool = ownerPool;
        _owner = owner;
    }

    /// <inheritdoc/>
    public override short Version => _core.Version;

    /// <inheritdoc/>
    public override object Owner => _owner!;

    /// <inheritdoc/>
    public override CancellationToken CancellationToken
    {
        get => _cancellationToken;
        set => _cancellationToken = value;
    }

    /// <inheritdoc/>
    public override CancellationTokenRegistration CancellationTokenRegistration
    {
        get => _cancellationTokenRegistration;
        set => _cancellationTokenRegistration = value;
    }

    /// <inheritdoc/>
    public override bool RunContinuationsAsynchronously
    {
        get => _core.RunContinuationsAsynchronously;
        set => _core.RunContinuationsAsynchronously = value;
    }

    /// <inheritdoc/>
    public override void SetResult(T result)
        => _core.SetResult(result);

    /// <inheritdoc/>
    public override void SetException(Exception ex)
        => _core.SetException(ex);

    /// <inheritdoc/>
    /// <remarks>
    /// This method increments the version number to reflect the reset operation.
    /// </remarks>
    public override bool TryReset()
    {
        _ownerPool = null;
        _core.Reset();
        _cancellationTokenRegistration = default;
        Next = null;
        Prev = null;
        return true;
    }

    /// <inheritdoc/>
    public override T GetResult(short token)
    {
        try
        {
            return _core.GetResult(token);
        }
        finally
        {
            _cancellationTokenRegistration.Dispose();
            _ownerPool?.Return(this);
        }
    }

    /// <inheritdoc/>
    public override ValueTaskSourceStatus GetStatus(short token)
        => _core.GetStatus(token);

    /// <inheritdoc/>
    public override void OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags)
        => _core.OnCompleted(continuation, state, token, flags);
}
