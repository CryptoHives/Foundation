// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

/// <summary>
/// An allocation-light async-compatible per-key exclusive lock implemented with pooled ValueTask sources.
/// Operations on different keys run fully concurrently; operations on the same key are serialized.
/// Note that this lock is <b>not</b> recursive!
/// </summary>
/// <remarks>
/// <para>
/// <b>Optional timeout and cancellation token</b> parameters on <see cref="LockAsync(TKey, TimeSpan, CancellationToken)"/>.
/// </para>
/// <para>
/// <b>Allocation behavior:</b> Per-key lock state (<see cref="ManualResetValueTaskSource{T}"/> waiters,
/// internal spin lock, waiter queue) is exactly as allocation-free as <see cref="AsyncLock"/>
/// for a key that already has an active entry. The first acquisition for a key additionally allocates the
/// entry itself (evicted again once nobody references the key), and every acquisition briefly takes an
/// internal administrative spin lock to look up or create that entry and update its reference count -
/// an O(1) dictionary operation, not the actual lock wait. Because acquiring and releasing a key both
/// require an <see langword="await"/> boundary to reliably clean up a failed acquisition, this type
/// exposes <see cref="ValueTask{Releaser}"/> via an <see langword="async"/> method rather than the fully
/// manual state machine used by <see cref="AsyncLock"/>; a synchronously completing acquisition still does
/// not allocate, since the ValueTask async method builder never boxes a state machine that never suspends.
/// </para>
/// <example>
/// <code>
/// private readonly AsyncKeyedLock&lt;string&gt; _locksByAccount = new();
///
/// public async Task TransferAsync(string accountId, CancellationToken ct)
/// {
///     using (await _locksByAccount.LockAsync(accountId, ct).ConfigureAwait(false))
///     {
///         // Only one concurrent operation per accountId; other accounts proceed in parallel.
///         await ApplyTransferAsync(accountId).ConfigureAwait(false);
///     }
/// }
/// </code>
/// </example>
/// </remarks>
/// <typeparam name="TKey">The type of key that operations are serialized by.</typeparam>
public sealed class AsyncKeyedLock<TKey> where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, Entry> _entries;
    private readonly Func<TKey, Entry> _entryFactory;
    private readonly IGetPooledManualResetValueTaskSource<Releaser> _pool;

    // Guards only entry creation/reference-counting/eviction below - never the actual lock wait/hold,
    // which stays fully parallel across keys via each Entry's own SpinLock and WaiterQueue.
    private Internal.SpinLock _adminLock;

    /// <summary>
    /// Constructs a new AsyncKeyedLock instance with an optional custom key comparer and custom pool.
    /// </summary>
    /// <param name="comparer">Custom equality comparer for keys. Defaults to <see cref="EqualityComparer{TKey}.Default"/>.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    public AsyncKeyedLock(IEqualityComparer<TKey>? comparer = null, IGetPooledManualResetValueTaskSource<Releaser>? pool = null)
    {
        _entries = comparer is null ? new() : new(comparer);
        _entryFactory = key => new Entry(this, key);
        _pool = pool ?? ValueTaskSourceObjectPools<TKey>.ValueTaskSourcePoolAsyncKeyedLockReleaser;
        _adminLock = new();
    }

    /// <summary>
    /// Gets the number of keys currently tracked, i.e. either held or awaited.
    /// </summary>
    /// <remarks>
    /// This is a best-effort diagnostic snapshot, not a value that can be relied upon for synchronization -
    /// it can change immediately after being read.
    /// </remarks>
    public int Count => _entries.Count;

    /// <summary>
    /// Gets whether <paramref name="key"/> currently has an active entry, i.e. it is either held or awaited.
    /// </summary>
    /// <remarks>
    /// This is a best-effort diagnostic snapshot, not a value that can be relied upon for synchronization -
    /// it can change immediately after being read.
    /// </remarks>
    /// <param name="key">The key to check.</param>
    public bool IsInUse(TKey key) => _entries.ContainsKey(key);

    /// <summary>
    /// Gets whether the local (non-pooled) waiter for <paramref name="key"/>'s entry is currently in use.
    /// Returns <see langword="false"/> if <paramref name="key"/> has no active entry.
    /// </summary>
    internal bool InternalWaiterInUse(TKey key)
        => _entries.TryGetValue(key, out Entry? entry) && entry.InternalWaiterInUse;

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition. Disposing the releaser releases the lock
    /// for <see cref="Key"/>.
    /// </summary>
    public readonly struct Releaser : IDisposable, IAsyncDisposable, IEquatable<Releaser>
    {
        private readonly AsyncKeyedLock<TKey> _owner;
        private readonly TKey _key;
        private readonly Entry _entry;

        internal Releaser(AsyncKeyedLock<TKey> owner, TKey key, Entry entry)
        {
            _owner = owner;
            _key = key;
            _entry = entry;
        }

        /// <summary>
        /// Gets the key this releaser will unlock when disposed.
        /// </summary>
        public TKey Key => _key;

        /// <inheritdoc/>
        public void Dispose()
        {
            _entry.ReleaseLock();
            _owner.ReleaseEntry(_key, _entry);
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
            => ReferenceEquals(_entry, other._entry);

        /// <inheritdoc/>
        public override int GetHashCode()
            => _entry is null ? 0 : _entry.GetHashCode();

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
    /// Asynchronously acquires the lock for <paramref name="key"/>, with a cancellation token.
    /// The cancellation token is only observed if the lock can not be acquired immediately.
    /// </summary>
    /// <remarks>
    /// Note that this lock is <b>not</b> recursive!
    /// The returned ValueTask must be disposed to release the lock.
    /// Use the following pattern to synchronize async Tasks.
    /// <code>
    /// private readonly var _locks = new AsyncKeyedLock&lt;string&gt;();
    /// public async Task DoStuffAsync(string key, CancellationToken ct)
    /// {
    ///     using (await _locks.LockAsync(key, ct))
    ///     {
    ///         await Task.Delay(TimeSpan.FromSeconds(1));
    ///     }
    /// }
    /// </code>
    /// </remarks>
    /// <param name="key">The key to serialize operations by.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A <see cref="ValueTask{Releaser}"/> that completes when the lock for <paramref name="key"/> is acquired.
    /// Dispose the returned releaser to release the lock.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is <see langword="null"/>.</exception>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask<Releaser> LockAsync(TKey key, CancellationToken cancellationToken = default)
        => LockAsync(key, Timeout.InfiniteTimeSpan, cancellationToken);

    /// <summary>
    /// Asynchronously acquires the lock for <paramref name="key"/>, or throws if the lock cannot be
    /// acquired before the timeout elapses.
    /// </summary>
    /// <param name="key">The key to serialize operations by.</param>
    /// <param name="timeout">
    /// The maximum time to wait. Use <see cref="Timeout.InfiniteTimeSpan"/> to wait indefinitely.
    /// </param>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>
    /// A <see cref="ValueTask{Releaser}"/> that completes when the lock for <paramref name="key"/> is acquired.
    /// Dispose the returned releaser to release the lock.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="timeout"/> is negative and not equal to <see cref="Timeout.InfiniteTimeSpan"/>.
    /// </exception>
    /// <exception cref="TimeoutException">
    /// Thrown when the timeout elapses before the lock can be acquired.
    /// </exception>
    /// <exception cref="OperationCanceledException">
    /// Thrown when <paramref name="cancellationToken"/> is cancelled before the lock can be acquired.
    /// </exception>
    public ValueTask<Releaser> LockAsync(TKey key, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        // Validated synchronously, before any entry is acquired, so invalid arguments throw
        // directly from the call frame instead of being captured into the returned ValueTask -
        // matching AsyncLock's behavior.
        if (key is null) throw new ArgumentNullException(nameof(key));
        if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan) throw new ArgumentOutOfRangeException(nameof(timeout));

        return LockAsyncImpl(key, timeout, cancellationToken);
    }

    private async ValueTask<Releaser> LockAsyncImpl(TKey key, TimeSpan timeout, CancellationToken cancellationToken)
    {
        Entry entry = AcquireEntry(key);
        try
        {
            return await entry.LockAsync(timeout, cancellationToken).ConfigureAwait(false);
        }
        catch
        {
            // The claim never turned into a hold (timeout/cancellation/pre-cancelled token), so
            // the Releaser that would normally drive cleanup was never produced. Release our
            // administrative reference here instead, so the entry can still be evicted when idle.
            ReleaseEntry(key, entry);
            throw;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Entry AcquireEntry(TKey key)
    {
        _adminLock.Enter();
        try
        {
            Entry entry = _entries.GetOrAdd(key, _entryFactory);
            entry.RefCount++;
            return entry;
        }
        finally
        {
            _adminLock.Exit();
        }
    }

    private void ReleaseEntry(TKey key, Entry entry)
    {
        _adminLock.Enter();
        try
        {
            if (--entry.RefCount == 0)
            {
                // Identity-checked removal: only evicts if `entry` is still the mapped instance for
                // `key`. Since creation, ref-counting and eviction are all serialized under
                // _adminLock, this can never race with a concurrent AcquireEntry for the same key.
                ((ICollection<KeyValuePair<TKey, Entry>>)_entries).Remove(new(key, entry));
            }
        }
        finally
        {
            _adminLock.Exit();
        }
    }

    /// <summary>
    /// Per-key lock state. Structurally identical to <see cref="AsyncLock"/>'s internals (local waiter,
    /// shared pool, spin lock, intrusive <see cref="WaiterQueue{T}"/>), plus the reference count that
    /// the owning <see cref="AsyncKeyedLock{TKey}"/> uses to decide when the entry can be evicted.
    /// </summary>
    /// <remarks>
    /// Visible only as <c>internal</c> because it appears as a parameter type on the public
    /// <see cref="Releaser"/> constructor; it is otherwise unreachable from outside this class.
    /// </remarks>
    internal sealed class Entry
    {
        private readonly AsyncKeyedLock<TKey> _owner;
        private readonly TKey _key;
        private readonly LocalManualResetValueTaskSource<Releaser> _localWaiter;
        private Internal.SpinLock _spinLock;
        private WaiterQueue<Releaser> _waiters;
        private volatile int _taken;

        /// <summary>
        /// Number of outstanding claims (held or awaited) on this entry. Guarded exclusively by
        /// <see cref="AsyncKeyedLock{TKey}._adminLock"/> - never touched by the wait/release path below.
        /// </summary>
        public int RefCount;

        public Entry(AsyncKeyedLock<TKey> owner, TKey key)
        {
            _owner = owner;
            _key = key;
            _waiters = new();
            _spinLock = new();
            _localWaiter = new(this) {
                RunContinuationsAsynchronously = true
            };
        }

        [MethodImpl(MethodImplOptionsEx.HotPath)]
        public ValueTask<Releaser> LockAsync(TimeSpan timeout, CancellationToken cancellationToken)
        {
            if (Interlocked.Exchange(ref _taken, 1) == 0)
            {
                return new ValueTask<Releaser>(new Releaser(_owner, _key, this));
            }

            if (timeout == TimeSpan.Zero)
            {
                return new ValueTask<Releaser>(Task.FromException<Releaser>(new TimeoutException()));
            }

            return LockAsyncImpl(timeout, cancellationToken);
        }

        [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
        private ValueTask<Releaser> LockAsyncImpl(TimeSpan timeout, CancellationToken cancellationToken)
        {
            ManualResetValueTaskSource<Releaser> waiter;
            short version;

            _spinLock.Enter();
            try
            {
                if (Interlocked.Exchange(ref _taken, 1) == 0)
                {
                    return new ValueTask<Releaser>(new Releaser(_owner, _key, this));
                }

                if (cancellationToken.IsCancellationRequested)
                {
                    return new ValueTask<Releaser>(Task.FromCanceled<Releaser>(cancellationToken));
                }

                if (!_localWaiter.TryGetValueTaskSource(out waiter))
                {
                    waiter = _owner._pool.GetPooledWaiter(this);
                    waiter.RunContinuationsAsynchronously = true;
                }

                waiter.CancellationToken = cancellationToken;

                version = waiter.Version;
                _waiters.Enqueue(waiter);

                if (timeout != Timeout.InfiniteTimeSpan)
                {
                    waiter.TimeoutTimer = TimeProvider.System.CreateTimer(
                        _timerCallbackAction, new TimeoutState<Releaser>(waiter), timeout, Timeout.InfiniteTimeSpan);
                }
            }
            finally
            {
                _spinLock.Exit();
            }

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

            return new ValueTask<Releaser>(waiter, version);
        }

        /// <summary>
        /// Whether the lock for this key is currently held.
        /// </summary>
        public bool IsTaken => _taken != 0;

        /// <summary>
        /// Gets a value indicating whether the local waiter is currently in use.
        /// </summary>
        internal bool InternalWaiterInUse => _localWaiter.InUse;

        /// <summary>
        /// Releases the lock. If any waiters are queued, the next waiter acquires the lock.
        /// </summary>
        public void ReleaseLock()
        {
            ManualResetValueTaskSource<Releaser> toRelease;

            _spinLock.Enter();
            try
            {
                if (_waiters.Count == 0)
                {
                    _taken = 0;
                    return;
                }

                toRelease = _waiters.Dequeue();
            }
            finally
            {
                _spinLock.Exit();
            }

            toRelease.SetResult(new Releaser(_owner, _key, this));
        }

        /// <summary>
        /// Callback used with <see cref="Timer"/> to trigger timeout.
        /// The stamped version guards against a stale callback observing a recycled waiter.
        /// </summary>
        private static readonly TimerCallback _timerCallbackAction = static state => {
            var timeoutState = (TimeoutState<Releaser>)state!;
            var entry = (Entry)timeoutState.Source.Owner!;
            ManualResetValueTaskSource<Releaser>? toCancel = entry.RemoveWaiter(timeoutState.Source, timeoutState.Version);
            toCancel?.SetException(new TimeoutException());
        };

#if NET6_0_OR_GREATER
        private static readonly Action<object?, CancellationToken> _cancellationCallbackAction = static (state, ct) => {
            var waiter = (ManualResetValueTaskSource<Releaser>)state!;
            var entry = (Entry)waiter.Owner!;
            entry.CancellationCallback(waiter);
        };

        private void CancellationCallback(ManualResetValueTaskSource<Releaser> waiter)
        {
#else
        private void CancellationCallback(object? state)
        {
            if (state is not ManualResetValueTaskSource<Releaser> waiter)
            {
                return;
            }
#endif

            // The version is stable here: GetResult disposes the registration before the
            // waiter is recycled, and disposal waits for an in-flight callback.
            ManualResetValueTaskSource<Releaser>? toCancel = RemoveWaiter(waiter, waiter.Version);
            toCancel?.SetException(new OperationCanceledException(waiter.CancellationToken));
        }

        /// <summary>
        /// O(1) removal from intrusive linked list.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ManualResetValueTaskSource<Releaser>? RemoveWaiter(ManualResetValueTaskSource<Releaser> waiter, short version)
        {
            _spinLock.Enter();
            try
            {
                // A stale timer callback must not touch a recycled waiter: the version
                // changes when the waiter is reset for reuse, and re-enqueueing requires
                // this spin lock, so the check and the removal are atomic w.r.t. reuse.
                if (waiter.Version == version && _waiters.Remove(waiter))
                {
                    return waiter;
                }
            }
            finally
            {
                _spinLock.Exit();
            }

            return null;
        }
    }
}
