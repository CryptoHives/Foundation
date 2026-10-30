// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

#pragma warning disable CA1034 // Nested types should not be visible

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An experimental async lock that a nested call on the same logical async flow can re-acquire without
/// deadlocking, unlike <see cref="AsyncLock"/>.
/// </summary>
/// <remarks>
/// Reentrancy is tracked through <see cref="ExecutionContext"/>, so an <see langword="async"/> method that
/// awaits <see cref="LockAsync(CancellationToken)"/> and returns the releaser hides the hold from its caller,
/// and the caller's next nested acquisition deadlocks. Releasing returns at once, but the lock stays held
/// while nested holders such as fire-and-forget work are still running, until the last of them releases.
/// </remarks>
#if NET8_0_OR_GREATER
[Experimental("CHTEXP001",
    UrlFormat = "https://cryptohives.github.io/Foundation/packages/threading/asyncreentrantlock.html")]
#endif
public sealed class AsyncReentrantLock
{
    /// <summary>
    /// The default initial capacity of the depth table, and the smallest capacity accepted.
    /// </summary>
    public const int DefaultDepthLocksCapacity = 4;

    /// <summary>
    /// The default maximum nesting depth.
    /// </summary>
    public const int MaxDepthLocksCapacity = 32;

    private readonly AsyncLocal<AmbientState?> _ambient;
    private readonly DepthLock _depth0Lock;
    private readonly object _growLock;
    private readonly int _maxDepthLocksCapacity;
    private volatile DepthLock?[] _depthLocks;
    private int _depthsCreated;

    /// <summary>
    /// Constructs a new <see cref="AsyncReentrantLock"/>.
    /// </summary>
    /// <param name="defaultDepthLocksCapacity">The initial capacity of the depth table; it grows on demand up to <paramref name="maxDepthLocksCapacity"/>.</param>
    /// <param name="maxDepthLocksCapacity">The maximum nesting depth; a call that would nest deeper throws <see cref="InvalidOperationException"/>.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when either capacity is below <see cref="DefaultDepthLocksCapacity"/>, or
    /// <paramref name="defaultDepthLocksCapacity"/> exceeds <paramref name="maxDepthLocksCapacity"/>.
    /// </exception>
    public AsyncReentrantLock(
        int defaultDepthLocksCapacity = DefaultDepthLocksCapacity,
        int maxDepthLocksCapacity = MaxDepthLocksCapacity)
    {
        if (defaultDepthLocksCapacity < DefaultDepthLocksCapacity) throw new ArgumentOutOfRangeException(nameof(defaultDepthLocksCapacity));
        if (maxDepthLocksCapacity < DefaultDepthLocksCapacity) throw new ArgumentOutOfRangeException(nameof(maxDepthLocksCapacity));
        if (defaultDepthLocksCapacity > maxDepthLocksCapacity) throw new ArgumentOutOfRangeException(nameof(defaultDepthLocksCapacity));

        _ambient = new();
        _growLock = new();
        _depth0Lock = new DepthLock();
        _depthLocks = new DepthLock?[defaultDepthLocksCapacity];
        _depthLocks[0] = _depth0Lock;
        _depthsCreated = 1;
        _maxDepthLocksCapacity = maxDepthLocksCapacity;
    }

    /// <summary>
    /// Gets the number of distinct nesting depths this instance has reached; at least 1. Diagnostic only.
    /// </summary>
    public int DepthsCreated => Volatile.Read(ref _depthsCreated);

    /// <summary>
    /// The number of nested holds this instance sees for the calling flow.
    /// </summary>
    internal int CurrentDepth => _ambient.Value?.Top is { } top ? top.Depth + 1 : 0;

    /// <summary>
    /// One held level of a flow's ancestry, immutable once published.
    /// </summary>
    internal sealed class Claim
    {
        public Claim(int depth, int generation, Claim? parent)
        {
            Depth = depth;
            Generation = generation;
            Parent = parent;
        }

        public int Depth { get; }

        public int Generation { get; }

        public Claim? Parent { get; }
    }

    /// <summary>
    /// The per-flow slot value. Mutated rather than replaced once acquired, because a slot write made inside
    /// an <see langword="async"/> continuation never reaches the caller.
    /// </summary>
    internal sealed class AmbientState
    {
        private Claim? _top;

        public AmbientState(Claim? top)
        {
            _top = top;
        }

        public Claim? Top
        {
            get => Volatile.Read(ref _top);
            set => Volatile.Write(ref _top, value);
        }
    }

    internal sealed class DepthLock
    {
        private int _generation;
        private int _releasePending;

        public DepthLock()
        {
            Lock = new AsyncLock();
        }

        public AsyncLock Lock { get; }

        public int Generation => Volatile.Read(ref _generation);

        public void Invalidate() => Interlocked.Increment(ref _generation);

        public void MarkReleasePending() => Interlocked.Exchange(ref _releasePending, 1);

        public bool TryTakeReleasePending() => Interlocked.CompareExchange(ref _releasePending, 0, 1) == 1;
    }

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition. Disposing the releaser releases the
    /// lock at the depth it was acquired at, and restores the calling flow's depth.
    /// </summary>
    public readonly struct Releaser : IDisposable, IAsyncDisposable, IEquatable<Releaser>
    {
        private readonly AsyncReentrantLock _owner;
        private readonly DepthLock _depthLock;
        private readonly AmbientState? _stateBeforeAcquisition;
        private readonly int _depth;
        private readonly bool _leaf;

        internal Releaser(AsyncReentrantLock owner, DepthLock depthLock, AmbientState? stateBeforeAcquisition, int depth, bool leaf)
        {
            _owner = owner;
            _depthLock = depthLock;
            _stateBeforeAcquisition = stateBeforeAcquisition;
            _depth = depth;
            _leaf = leaf;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_owner is null)
            {
#if DEBUG
#pragma warning disable CA1065 // Do not throw exceptions from Dispose, but this is a programming error that should be caught in debug builds.
                throw new InvalidOperationException("The releaser does not represent an acquired lock.");
#pragma warning restore CA1065
#else
                return;
#endif
            }

            // A leaf published no claim, so nothing can be nested under it and it never left its level pending.
            if (_leaf)
            {
                _owner.Free(_depthLock, _depth);
                return;
            }

            _owner._ambient.Value = _stateBeforeAcquisition;
            _owner.Release(_depthLock, _depth);
        }

        /// <inheritdoc/>
        public ValueTask DisposeAsync()
        {
            Dispose();
            return default;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
            => obj is Releaser other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(Releaser other)
            => ReferenceEquals(_depthLock, other._depthLock);

        /// <inheritdoc/>
        public override int GetHashCode()
            => _depthLock?.GetHashCode() ?? 0;

        /// <summary>
        /// Determines whether two <see cref="Releaser"/> instances are equal.
        /// </summary>
        /// <param name="left">The first Releaser to compare.</param>
        /// <param name="right">The second Releaser to compare.</param>
        /// <returns>true if the specified Releaser instances are equal; otherwise, false.</returns>
        public static bool operator ==(Releaser left, Releaser right)
            => left.Equals(right);

        /// <summary>
        /// Determines whether two <see cref="Releaser"/> instances are not equal.
        /// </summary>
        /// <param name="left">The first Releaser to compare.</param>
        /// <param name="right">The second Releaser to compare.</param>
        /// <returns>false if the specified Releaser instances are equal; otherwise, true.</returns>
        public static bool operator !=(Releaser left, Releaser right)
            => !left.Equals(right);
    }

    /// <summary>
    /// Asynchronously acquires the lock. A call nested inside a hold on the same logical flow acquires
    /// the next depth instead of deadlocking; concurrent siblings at the same depth serialize.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A <see cref="ValueTask{Releaser}"/> that completes when the lock is acquired. Dispose the
    /// returned releaser to release the lock.
    /// </returns>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before the lock can be acquired.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the call would nest deeper than the maximum depth set at construction.
    /// </exception>
    public ValueTask<Releaser> LockAsync(CancellationToken cancellationToken = default)
        => Acquire(Timeout.InfiniteTimeSpan, leaf: false, cancellationToken);

    /// <summary>
    /// Asynchronously acquires the lock, or throws if it cannot be acquired before the timeout elapses.
    /// </summary>
    /// <param name="timeout">
    /// The maximum time to wait. Use <see cref="Timeout.InfiniteTimeSpan"/> to wait indefinitely.
    /// </param>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>
    /// A <see cref="ValueTask{Releaser}"/> that completes when the lock is acquired. Dispose the
    /// returned releaser to release the lock.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timeout"/> is negative and not equal to <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </exception>
    /// <exception cref="TimeoutException">Thrown when the timeout elapses before the lock can be acquired.</exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before the lock can be acquired.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the call would nest deeper than the maximum depth set at construction.
    /// </exception>
    public ValueTask<Releaser> LockAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan) throw new ArgumentOutOfRangeException(nameof(timeout));

        return Acquire(timeout, leaf: false, cancellationToken);
    }

    /// <summary>
    /// Asynchronously acquires the lock at the same depth as <see cref="LockAsync(CancellationToken)"/>, but
    /// without recording the hold for further nesting, which makes it cheaper.
    /// </summary>
    /// <remarks>
    /// Use it only for innermost regions that never call back into this lock: a <see cref="LockAsync(CancellationToken)"/>
    /// or <see cref="LockLeafAsync(CancellationToken)"/> call made inside the hold deadlocks, as with <see cref="AsyncLock"/>.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A <see cref="ValueTask{Releaser}"/> that completes when the lock is acquired. Dispose the
    /// returned releaser to release the lock.
    /// </returns>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before the lock can be acquired.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the call would nest deeper than the maximum depth set at construction.
    /// </exception>
    public ValueTask<Releaser> LockLeafAsync(CancellationToken cancellationToken = default)
        => Acquire(Timeout.InfiniteTimeSpan, leaf: true, cancellationToken);

    /// <summary>
    /// Asynchronously acquires the lock like <see cref="LockLeafAsync(CancellationToken)"/>, or throws if it
    /// cannot be acquired before the timeout elapses.
    /// </summary>
    /// <remarks>
    /// Use it only for innermost regions that never call back into this lock: a <see cref="LockAsync(CancellationToken)"/>
    /// or <see cref="LockLeafAsync(CancellationToken)"/> call made inside the hold deadlocks, as with <see cref="AsyncLock"/>.
    /// </remarks>
    /// <param name="timeout">
    /// The maximum time to wait. Use <see cref="Timeout.InfiniteTimeSpan"/> to wait indefinitely.
    /// </param>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>
    /// A <see cref="ValueTask{Releaser}"/> that completes when the lock is acquired. Dispose the
    /// returned releaser to release the lock.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timeout"/> is negative and not equal to <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </exception>
    /// <exception cref="TimeoutException">Thrown when the timeout elapses before the lock can be acquired.</exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before the lock can be acquired.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the call would nest deeper than the maximum depth set at construction.
    /// </exception>
    public ValueTask<Releaser> LockLeafAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan) throw new ArgumentOutOfRangeException(nameof(timeout));

        return Acquire(timeout, leaf: true, cancellationToken);
    }

    // Idea: a RunAsync(Func<ValueTask> body) overload that holds the lock around the body cannot hide the hold from
    // its caller the way an async wrapper returning a Releaser does; see asherman.io/projects/csharp-async-reentrant-locks.html.
    // Must stay non-async, like all callers: the slot write has to land in the caller's ExecutionContext.
    private ValueTask<Releaser> Acquire(TimeSpan timeout, bool leaf, CancellationToken cancellationToken)
    {
        AmbientState? inherited = _ambient.Value;
        Claim? top = inherited?.Top;
        int depth = ResolveTargetDepth(top);
        if (depth >= _maxDepthLocksCapacity)
        {
            throw new InvalidOperationException($"Nesting exceeds the maximum depth of {_maxDepthLocksCapacity} for this AsyncReentrantLock.");
        }

        AmbientState? state = null;
        if (!leaf)
        {
            state = new AmbientState(top);

            // safe, _ambient is AsyncLocal, it only modifies the current execution context
            _ambient.Value = state;
        }

        while (true)
        {
            DepthLock depthLock = GetDepthLock(depth);
            ValueTask<AsyncLock.Releaser> pending = depthLock.Lock.LockAsync(timeout, cancellationToken);
            if (!pending.IsCompletedSuccessfully)
            {
                return AcquireSlowAsync(pending, depthLock, depth, top, state, inherited, timeout, cancellationToken);
            }

            // synchronous completion case
            _ = pending.GetAwaiter().GetResult();
            if (TryCommit(depthLock, depth, top, state))
            {
                return new ValueTask<Releaser>(new Releaser(this, depthLock, inherited, depth, leaf));
            }

            Free(depthLock, depth);
            depth = ResolveTargetDepth(top);
        }
    }

    private async ValueTask<Releaser> AcquireSlowAsync(
        ValueTask<AsyncLock.Releaser> pending,
        DepthLock depthLock,
        int depth,
        Claim? top,
        AmbientState? state,
        AmbientState? inherited,
        TimeSpan timeout,
        CancellationToken cancellationToken)
    {
        while (true)
        {
            await pending.ConfigureAwait(false);
            if (TryCommit(depthLock, depth, top, state))
            {
                return new Releaser(this, depthLock, inherited, depth, leaf: state is null);
            }

            Free(depthLock, depth);
            depth = ResolveTargetDepth(top);
            depthLock = GetDepthLock(depth);

            // A retry restarts the timeout; it only happens when an ancestor released during the wait.
            pending = depthLock.Lock.LockAsync(timeout, cancellationToken);
        }
    }

    /// <summary>
    /// Ends the owner's hold at <paramref name="depth"/>. Claims on it go stale at once, but the level is
    /// freed only when no nested holder remains; otherwise the last one out frees it.
    /// </summary>
    private void Release(DepthLock depthLock, int depth)
    {
        depthLock.Invalidate();

        // Marked before the next level is inspected and inspected after it is freed in Free, so one side always sees the other.
        depthLock.MarkReleasePending();
        if (TryGetDepthLock(depth + 1)?.Lock.IsTaken == true)
        {
            return;
        }

        if (depthLock.TryTakeReleasePending())
        {
            Free(depthLock, depth);
        }
    }

    /// <summary>
    /// Frees <paramref name="depth"/>, then each level below it whose owner already released and was
    /// waiting on it.
    /// </summary>
    private void Free(DepthLock depthLock, int depth)
    {
        while (true)
        {
            depthLock.Lock.ReleaseLock();
            if (depth == 0 || depthLock.Lock.IsTaken)
            {
                return;
            }

            depthLock = TryGetDepthLock(--depth)!;
            if (!depthLock.TryTakeReleasePending())
            {
                return;
            }
        }
    }

    /// <summary>
    /// Publishes the hold at <paramref name="depth"/> if the claim it nests under is still held,
    /// rechecked now that the level is taken. A leaf passes no state and publishes nothing.
    /// </summary>
    private bool TryCommit(DepthLock depthLock, int depth, Claim? top, AmbientState? state)
    {
        Claim? parent = top;
        while (parent is not null && parent.Depth >= depth)
        {
            parent = parent.Parent;
        }

        if (parent is not null && !IsLive(parent))
        {
            return false;
        }

        if (state is not null)
        {
            state.Top = new Claim(depth, depthLock.Generation, parent);
        }

        return true;
    }

    /// <summary>
    /// The level above the flow's deepest claim that is still held, or 0 if none is.
    /// </summary>
    /// <remarks>
    /// A live claim implies every level below it is still taken, because a level is only freed once the
    /// level above it is free, so released ancestors below a live claim do not matter.
    /// </remarks>
    private int ResolveTargetDepth(Claim? top)
    {
        for (Claim? c = top; c is not null; c = c.Parent)
        {
            if (IsLive(c))
            {
                return c.Depth + 1;
            }
        }

        return 0;
    }

    private bool IsLive(Claim claim)
    {
        DepthLock? depthLock = TryGetDepthLock(claim.Depth);
        return depthLock is not null && depthLock.Lock.IsTaken && depthLock.Generation == claim.Generation;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private DepthLock GetDepthLock(int depth)
        => TryGetDepthLock(depth) ?? CreateDepthLock(depth);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private DepthLock? TryGetDepthLock(int depth)
    {
        if (depth == 0)
        {
            return _depth0Lock;
        }

        DepthLock?[] locks = _depthLocks;
        return (uint)depth < (uint)locks.Length ? Volatile.Read(ref locks[depth]) : null;
    }

    private DepthLock CreateDepthLock(int depth)
    {
        lock (_growLock)
        {
            DepthLock?[] current = _depthLocks;
            if ((uint)depth >= (uint)current.Length)
            {
                int newLength = current.Length * 2;
                while (newLength <= depth)
                {
                    newLength *= 2;
                }

                newLength = Math.Min(newLength, _maxDepthLocksCapacity);

                var grown = new DepthLock?[newLength];
                Array.Copy(current, grown, current.Length);
                _depthLocks = grown;
                current = grown;
            }

            DepthLock? existing = current[depth];
            if (existing is null)
            {
                existing = new DepthLock();
                Volatile.Write(ref current[depth], existing);
                _depthsCreated++;
            }

            return existing;
        }
    }
}
