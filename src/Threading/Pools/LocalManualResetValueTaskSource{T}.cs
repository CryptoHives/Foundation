// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Threading.Pools;

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks.Sources;

/// <summary>
/// An implementation of <see cref="IValueTaskSource{T}"/>.
/// </summary>
/// <remarks>
/// This class is a sealed implementation of <see cref="IValueTaskSource{T}"/> and provides methods to
/// manage the lifecycle of a task-like operation. It allows resetting and signaling the completion of the operation,
/// and supports querying the status and retrieving the result. It is used as a local reusable value task source to
/// minimize allocations.
/// </remarks>
public sealed class LocalManualResetValueTaskSource<T> : ManualResetValueTaskSource<T>
{
    private ManualResetValueTaskSourceCore<T> _core;
    private CancellationToken _cancellationToken;
    private CancellationTokenRegistration _cancellationTokenRegistration;
    private int _inUse;

    /// <summary>
    /// Initializes a new instance of the LocalManualResetValueTaskSource class and
    /// associates it with the specified owner class.
    /// The owner is typically the class which contains the reference to this ValueTaskSource.
    /// </summary>
    /// <param name="owner">The object to associate with this instance.</param>
    public LocalManualResetValueTaskSource(object owner)
    {
        Owner = owner;
    }

    /// <summary>
    /// Tries to get ownership of the local value task source.
    /// </summary>
    /// <returns>Returns <c>true</c> if ownership was acquired; otherwise, <c>false</c>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryGetValueTaskSource(out ManualResetValueTaskSource<T> waiter)
    {
        waiter = this;
        return Interlocked.Exchange(ref _inUse, 1) == 0;
    }

    /// <inheritdoc/>
    public override short Version { get => _core.Version; }

    /// <inheritdoc/>
    public override object Owner { get; }

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
    public override bool TryReset()
    {
        _core.Reset();
        _cancellationTokenRegistration = default;
        Next = null;
        Prev = null;
        return Interlocked.Exchange(ref _inUse, 0) == 1;
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
            TryReset();
        }
    }

    /// <inheritdoc/>
    public override ValueTaskSourceStatus GetStatus(short token)
        => _core.GetStatus(token);

    /// <inheritdoc/>
    public override void OnCompleted(Action<object?> continuation, object? state, short token, ValueTaskSourceOnCompletedFlags flags)
        => _core.OnCompleted(continuation, state, token, flags);

    /// <summary>
    /// Gets whether the value task source is currently in use.
    /// </summary>
    public bool InUse => _inUse == 1;
}
