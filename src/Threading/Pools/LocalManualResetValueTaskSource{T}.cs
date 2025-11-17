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
/// This class is a sealed implementation of <see cref="IValueTaskSource{T}"/> and provides methods to
/// manage the lifecycle of a task-like operation. It allows resetting and signaling the completion of the operation,
/// and supports querying the status and retrieving the result. In addition, the owner pool can be set to return
/// the instance to the pool when it is no longer needed.
/// The <see cref="IResettable"/> interface is implemented to allow resetting the state of the instance for reuse
/// by an implementation of an <see cref="ObjectPool"/> that uses the <see cref="DefaultObjectPool{T}"/> implementation.
/// </remarks>
internal sealed class LocalManualResetValueTaskSource<T> : ManualResetValueTaskSource<T>
{
    private ManualResetValueTaskSourceCore<T> _core;
    private int _inUse;

    /// <summary>
    /// Tries to get ownership of the local value task source.
    /// </summary>
    /// <returns>Returns <c>true</c> if ownership was acquired; otherwise, <c>false</c>.</returns>
    public bool TryGetValueTaskSource(out ManualResetValueTaskSource<T> waiter)
    {
        waiter = this;
        return Interlocked.Exchange(ref _inUse, 1) == 0;
    }

    /// <inheritdoc/>
    public override short Version { get => _core.Version; }

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
    public override bool TryReset()
    {
        _core.Reset();
        return Interlocked.Exchange(ref _inUse, 0) == 1;
    }

    /// <inheritdoc/>
    public override T GetResult(short token)
    {
        T result = _core.GetResult(token);
        TryReset();
        return result;
    }

    /// <inheritdoc/>
    public override ValueTaskSourceStatus GetStatus(short token)
        => _core.GetStatus(token);

    /// <inheritdoc/>
    public override void OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags)
        => _core.OnCompleted(continuation, state, token, flags);
}
