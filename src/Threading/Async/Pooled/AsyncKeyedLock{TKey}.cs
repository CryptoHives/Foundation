// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

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
/// for a key that already has an active entry. Entries are evicted lazily rather than the moment their last
/// reference is dropped: a released key stays mapped as an <em>idle</em> entry, so locking and releasing the
/// same key repeatedly allocates <b>nothing at all</b> - neither the entry nor the dictionary node. At most
/// <c>maxIdleEntries</c> idle entries are retained; once the cache is full, a key that is not mapped yet
/// takes over the least recently idled entry instead of allocating one, so even a workload cycling through
/// unboundedly many distinct keys only pays for the dictionary node. Every acquisition briefly takes an
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
    /// <summary>
    /// Default number of idle entries retained for reuse when the caller does not specify one.
    /// </summary>
    /// <remarks>
    /// Shares <see cref="ValueTaskSourceObjectPools.DefaultMaxRetainedItems"/> so the library keeps one
    /// retention story across its pools. Sized to span the set of keys that are hot at the same time: a
    /// cache smaller than that set degrades into evicting an entry per acquisition, which is both slower
    /// and no longer allocation free. Retention is bounded by the keys actually used rather than by this
    /// cap, so a generous default costs a lock with few keys nothing.
    /// </remarks>
    public const int DefaultMaxIdleEntries = ValueTaskSourceObjectPools.DefaultMaxRetainedItems;

    private readonly ConcurrentDictionary<TKey, Entry> _entries;
    private readonly IGetPooledManualResetValueTaskSource<Releaser> _pool;
    private readonly int _maxIdleEntries;

    // Guards only entry creation/reference-counting/eviction below - never the actual lock wait/hold,
    // which stays fully parallel across keys via each Entry's own SpinLock and WaiterQueue.
    private Internal.SpinLock _keyLock;

    /// Intrusive LRU list of idle (mapped but unreferenced) entries, threaded through Entry.IdleNext and
    /// Entry.IdlePrev. _idleHead is the least recently idled entry and therefore the next eviction victim.
    /// Guarded by <see cref="_keyLock"/>, which already serializes the entire entry lifecycle.
    private Entry? _idleHead;
    private Entry? _idleTail;
    private int _idleCount;

    // Number of entries with a non-zero reference count, i.e. currently held or awaited. Maintained under
    // _keyLock so Count stays O(1) now that the dictionary also holds idle entries.
    private int _activeCount;

    /// <summary>
    /// Constructs a new AsyncKeyedLock instance with an optional custom key comparer and custom pool.
    /// </summary>
    /// <param name="comparer">Custom equality comparer for keys. Defaults to <see cref="EqualityComparer{TKey}.Default"/>.</param>
    /// <param name="pool">Custom pool for this instance.</param>
    /// <param name="maxIdleEntries">
    /// How many released keys stay cached for reuse before the least recently released one is evicted.
    /// Larger values trade memory - each retained entry keeps its key alive - for fewer allocations on a
    /// large hot key set; a value below the number of keys that are hot at once gives up the allocation-free
    /// path entirely, so err on the generous side. Pass <c>0</c> to evict eagerly for the smallest possible
    /// footprint, at the cost of allocating an entry and a dictionary node on every acquisition - there is
    /// nothing retained to reuse. Defaults to <see cref="DefaultMaxIdleEntries"/>.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="maxIdleEntries"/> is negative.</exception>
    public AsyncKeyedLock(
        IEqualityComparer<TKey>? comparer = null,
        IGetPooledManualResetValueTaskSource<Releaser>? pool = null,
        int maxIdleEntries = DefaultMaxIdleEntries)
    {
        if (maxIdleEntries < 0) throw new ArgumentOutOfRangeException(nameof(maxIdleEntries));

        _entries = comparer is null ? new() : new(comparer);
        _pool = pool ?? ValueTaskSourceObjectPools<TKey>.ValueTaskSourcePoolAsyncKeyedLockReleaser;
        _maxIdleEntries = maxIdleEntries;
        _keyLock = new();
    }

    /// <summary>
    /// Gets the number of keys currently tracked, i.e. either held or awaited.
    /// </summary>
    /// <remarks>
    /// Keys that were released but are still cached for reuse are not counted. This is a best-effort
    /// diagnostic snapshot, not a value that can be relied upon for synchronization - it can change
    /// immediately after being read.
    /// </remarks>
    public int Count => Volatile.Read(ref _activeCount);

    /// <summary>
    /// Gets whether <paramref name="key"/> currently has an active entry, i.e. it is either held or awaited.
    /// </summary>
    /// <remarks>
    /// Returns <see langword="false"/> for a key whose entry is merely cached for reuse. This is a
    /// best-effort diagnostic snapshot, not a value that can be relied upon for synchronization - it can
    /// change immediately after being read.
    /// </remarks>
    /// <param name="key">The key to check.</param>
    public bool IsInUse(TKey key) => _entries.TryGetValue(key, out Entry? entry) && entry.RefCount > 0;

    /// <summary>
    /// Gets whether <paramref name="key"/> has an entry at all, whether active or merely cached for reuse.
    /// </summary>
    internal bool IsCached(TKey key) => _entries.ContainsKey(key);

    /// <summary>
    /// Gets the number of entries retained, counting both active keys and those cached for reuse.
    /// </summary>
    internal int CachedCount => _entries.Count;

    /// <summary>
    /// Gets whether the local (non-pooled) waiter for <paramref name="key"/>'s entry is currently in use.
    /// Returns <see langword="false"/> if <paramref name="key"/> has no entry.
    /// </summary>
    internal bool InternalWaiterInUse(TKey key)
        => _entries.TryGetValue(key, out Entry? entry) && entry.InternalWaiterInUse;

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition. Disposing the releaser releases the lock
    /// for <see cref="Key"/>.
    /// </summary>
    /// <remarks>
    /// A releaser identifies one specific acquisition, not merely the key: because entries are reused across
    /// acquisitions, it carries a generation token stamped when the lock was taken - the same technique
    /// <see cref="ValueTask{TResult}"/> uses to tell a live result apart from a recycled source. Disposing a
    /// releaser whose token no longer matches throws rather than releasing somebody else's hold.
    /// </remarks>
    public readonly struct Releaser : IDisposable, IAsyncDisposable, IEquatable<Releaser>
    {
        private readonly AsyncKeyedLock<TKey> _owner;
        private readonly TKey _key;
        private readonly Entry _entry;
        private readonly short _generation;

        internal Releaser(AsyncKeyedLock<TKey> owner, TKey key, Entry entry, short generation)
        {
            _owner = owner;
            _key = key;
            _entry = entry;
            _generation = generation;
        }

        /// <summary>
        /// Gets the key this releaser will unlock when disposed.
        /// </summary>
        public TKey Key => _key;

        // CA1065 asks that Dispose never throw, on the grounds that a throwing cleanup can mask the
        // exception it is unwinding. That trade is worth taking here: this releaser is a single-use handle
        // to one acquisition, and the alternative to throwing is silently releasing a lock that some other
        // acquisition currently holds - corruption that surfaces arbitrarily far away instead of at the
        // offending Dispose. Same reasoning ValueTask applies when GetResult rejects a stale token.

        /// <inheritdoc/>
        /// <exception cref="InvalidOperationException">
        /// Thrown when this releaser has already been disposed, or otherwise no longer represents the
        /// acquisition that is currently holding the lock for <see cref="Key"/>.
        /// </exception>
        public void Dispose()
        {
            // Validate before releasing, never after: the moment ReleaseLock hands the entry on, another
            // acquisition can take it and stamp a new generation, and the check would race.
            if (_entry is null || _entry.Generation != _generation)
            {
                throw StaleReleaserException();
            }

            _entry.ReleaseLock();
            _owner.ReleaseEntry(_entry);
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
            => ReferenceEquals(_entry, other._entry) && _generation == other._generation;

        /// <inheritdoc/>
        public override int GetHashCode()
            => _entry is null ? 0 : _entry.GetHashCode() ^ _generation;

        private static InvalidOperationException StaleReleaserException()
            => new("The releaser does not represent the current acquisition of this key. A releaser is "
                + "single use and must be disposed exactly once by the acquisition that produced it.");

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
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public ValueTask<Releaser> LockAsync(TKey key, TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));
        if (timeout < TimeSpan.Zero && timeout != Timeout.InfiniteTimeSpan) throw new ArgumentOutOfRangeException(nameof(timeout));

        return LockAsyncImpl(key, timeout, cancellationToken);
    }

    /// <summary>
    /// Attempts to acquire the lock for <paramref name="key"/> immediately, without waiting.
    /// </summary>
    /// <remarks>
    /// Synchronous and non-throwing by design: unlike <see cref="LockAsync(TKey, TimeSpan, CancellationToken)"/>
    /// with a zero timeout, a failed attempt here never allocates an exception or a faulted
    /// <see cref="ValueTask{Releaser}"/> - there is nothing to await in the first place, since this either
    /// succeeds immediately or doesn't.
    /// </remarks>
    /// <param name="key">The key to serialize operations by.</param>
    /// <param name="releaser">
    /// The releaser for the acquired lock, if this method returns <see langword="true"/>. Dispose it to
    /// release the lock. Undefined if this method returns <see langword="false"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the lock for <paramref name="key"/> was acquired immediately;
    /// <see langword="false"/> if it is currently held or awaited by someone else.
    /// </returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="key"/> is <see langword="null"/>.</exception>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public bool TryLock(TKey key, out Releaser releaser)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));

        Entry entry = AcquireEntry(key);
        if (entry.TryTake(out releaser))
        {
            return true;
        }

        // The claim never turned into a hold - release our administrative reference here instead,
        // exactly like LockAsyncImpl's catch block does for a failed timed/cancelled acquisition.
        ReleaseEntry(entry);
        return false;
    }

#if NET6_0_OR_GREATER
    [AsyncMethodBuilder(typeof(PoolingAsyncValueTaskMethodBuilder<>))]
#endif
    [MethodImpl(MethodImplOptionsEx.HotPath)]
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
            ReleaseEntry(entry);
            throw;
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private Entry AcquireEntry(TKey key)
    {
        _keyLock.Enter();
        try
        {
            if (_entries.TryGetValue(key, out Entry? entry))
            {
                // A cached entry is waking up: take it off the idle list before it gains a reference.
                // Being mapped with no references and being on the idle list are the same state - an entry
                // is linked the moment its count reaches zero and unmapped when it is evicted.
                Debug.Assert((entry.RefCount == 0) == (entry.IdleNext is not null || entry.IdlePrev is not null || ReferenceEquals(_idleHead, entry)),
                    "A mapped, unreferenced entry must be on the idle list.");

                if (entry.RefCount == 0)
                {
                    UnlinkIdle(entry);
                    _activeCount++;
                }
            }
            else
            {
                entry = RentEntry(key);
                _entries[key] = entry;
                _activeCount++;
            }

            entry.RefCount++;
            return entry;
        }
        finally
        {
            _keyLock.Exit();
        }
    }

    private void ReleaseEntry(Entry entry)
    {
        _keyLock.Enter();
        try
        {
            Debug.Assert(entry.RefCount > 0, "Entry released more often than it was acquired - most likely a Releaser disposed twice.");

            if (--entry.RefCount == 0)
            {
                _activeCount--;

                // Lazy eviction: the entry keeps its mapping so the next acquisition of this key finds it
                // ready to use, allocating neither an entry nor a dictionary node.
                LinkIdle(entry);

                // Only trims a cache that shrank past its cap - in steady state a miss repurposes the
                // oldest idle entry, leaving the list one below the cap, so the release that follows lands
                // exactly at it and never gets here.
                while (_idleCount > _maxIdleEntries)
                {
                    DropOldestIdle();
                }
            }
        }
        finally
        {
            _keyLock.Exit();
        }
    }

    /// <summary>
    /// Appends a newly idle entry to the most-recently-used end of the idle list.
    /// Caller holds <see cref="_keyLock"/>.
    /// </summary>
    private void LinkIdle(Entry entry)
    {
        Debug.Assert(entry.IdleNext is null && entry.IdlePrev is null, "Entry is already on the idle list.");

        entry.IdlePrev = _idleTail;
        entry.IdleNext = null;

        if (_idleTail is not null)
        {
            _idleTail.IdleNext = entry;
        }
        else
        {
            _idleHead = entry;
        }

        _idleTail = entry;
        _idleCount++;
    }

    /// <summary>
    /// Removes an entry from the idle list in O(1) - the reason the list is doubly linked, since a key can
    /// be re-acquired from anywhere in it. Caller holds <see cref="_keyLock"/>.
    /// </summary>
    private void UnlinkIdle(Entry entry)
    {
        if (ReferenceEquals(_idleHead, entry))
        {
            _idleHead = entry.IdleNext;
        }

        if (ReferenceEquals(_idleTail, entry))
        {
            _idleTail = entry.IdlePrev;
        }

        if (entry.IdlePrev is not null)
        {
            entry.IdlePrev.IdleNext = entry.IdleNext;
        }

        if (entry.IdleNext is not null)
        {
            entry.IdleNext.IdlePrev = entry.IdlePrev;
        }

        entry.IdleNext = null;
        entry.IdlePrev = null;
        _idleCount--;

        Debug.Assert(_idleCount >= 0);
    }

    /// <summary>
    /// Produces an entry for a key that is not mapped yet, reusing the least recently idled entry once the
    /// cache is full rather than allocating. Caller holds <see cref="_keyLock"/>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Eviction and allocation are the same event, so they are done as one step: the entry the cache was
    /// about to give up is exactly the entry the new key needs. That keeps an evicted entry - and its
    /// <see cref="LocalManualResetValueTaskSource{T}"/>, the larger half of what an entry costs - in
    /// continuous use, with no pool to park it in between and no second retention bound to reason about.
    /// </para>
    /// <para>
    /// Reuse is safe precisely because an idle entry reached a reference count of zero: a waiter handed the
    /// lock by <see cref="Entry.ReleaseLock"/> still holds the reference it took in
    /// <see cref="AcquireEntry"/>, so a count of zero means the entry is unheld, its waiter queue is empty
    /// and its local waiter has been reset. A stale timeout or cancellation callback may still reach the
    /// reused entry, but it is rejected by the same waiter version check that already guards a recycled
    /// waiter.
    /// </para>
    /// </remarks>
    private Entry RentEntry(TKey key)
    {
        // Below the cap the cache is still growing, so add an entry rather than cannibalizing one.
        Entry entry;
        if (_idleCount == 0 || _idleCount < _maxIdleEntries)
        {
            entry = new Entry(this);
        }
        else
        {
            entry = _idleHead!;
            DetachIdleHead(entry);
        }

        entry.Bind(key);
        return entry;
    }

    /// <summary>
    /// Drops the least recently idled entry, letting it be collected. Only reached when the cache has
    /// shrunk past its cap. Caller holds <see cref="_keyLock"/>.
    /// </summary>
    private void DropOldestIdle()
    {
        Entry victim = _idleHead!;
        DetachIdleHead(victim);
        victim.Unbind();
    }

    /// <summary>
    /// Removes the least recently idled entry from both the idle list and the key map.
    /// Caller holds <see cref="_keyLock"/>.
    /// </summary>
    private void DetachIdleHead(Entry victim)
    {
        Debug.Assert(_idleCount > 0 && _idleHead is not null, "Idle list is empty but the idle count is positive.");
        Debug.Assert(ReferenceEquals(_idleHead, victim));

        bool removed = _entries.TryRemove(victim.Key, out Entry? removedEntry);
        Debug.Assert(removed && ReferenceEquals(removedEntry, victim));

        UnlinkIdle(victim);
    }

    /// <summary>
    /// Per-key lock state. Structurally identical to <see cref="AsyncLock"/>'s internals (local waiter,
    /// shared pool, spin lock, intrusive <see cref="WaiterQueue{T}"/>), plus the reference count that
    /// the owning <see cref="AsyncKeyedLock{TKey}"/> uses to decide when the entry falls idle and becomes
    /// a candidate for eviction and reuse.
    /// </summary>
    /// <remarks>
    /// Visible only as <c>internal</c> because it appears as a parameter type on the public
    /// <see cref="Releaser"/> constructor; it is otherwise unreachable from outside this class.
    /// </remarks>
    internal sealed class Entry
    {
        private readonly AsyncKeyedLock<TKey> _owner;
        private readonly LocalManualResetValueTaskSource<Releaser> _localWaiter;
        private TKey _key;
        private Internal.SpinLock _spinLock;
        private WaiterQueue<Releaser> _waiters;
        private volatile int _taken;
        private short _generation;

        /// <summary>
        /// Number of outstanding claims (held or awaited) on this entry. Guarded exclusively by
        /// <see cref="AsyncKeyedLock{TKey}._keyLock"/> - never touched by the wait/release path below.
        /// </summary>
        public int RefCount;

        /// <summary>
        /// Links into the owner's intrusive LRU list of idle entries while this entry is mapped but
        /// unreferenced; both are <see langword="null"/> while the entry is active or pooled. Guarded by
        /// <see cref="AsyncKeyedLock{TKey}._keyLock"/>.
        /// </summary>
        public Entry? IdleNext;

        /// <inheritdoc cref="IdleNext"/>
        public Entry? IdlePrev;

        public Entry(AsyncKeyedLock<TKey> owner)
        {
            _owner = owner;
            _key = default!;
            _waiters = new();
            _spinLock = new();
            _localWaiter = new(this) {
                RunContinuationsAsynchronously = true
            };
        }

        /// <summary>
        /// Gets the key this entry is currently mapped to. Meaningful only while the entry is mapped.
        /// </summary>
        public TKey Key => _key;

        /// <summary>
        /// Gets the token identifying the acquisition currently holding this entry. Stamped into the
        /// <see cref="Releaser"/> handed to that acquisition, so a stale handle can be told apart from a
        /// live one once entries start being reused.
        /// </summary>
        public short Generation => _generation;

        /// <summary>
        /// Binds a pooled entry to a key. Caller holds <see cref="AsyncKeyedLock{TKey}._keyLock"/>.
        /// </summary>
        /// <remarks>
        /// Only the key is restored: the spin lock, the (empty) waiter queue and the local waiter are
        /// reusable as-is, and the local waiter deliberately keeps its identity, since it is constructed
        /// with this entry as its <see cref="ManualResetValueTaskSource{T}.Owner"/> and that relationship
        /// survives recycling. <c>RunContinuationsAsynchronously</c> likewise survives, as
        /// <c>ManualResetValueTaskSourceCore.Reset</c> does not clear it. The generation deliberately keeps
        /// counting up across rebinds so a releaser stranded by an eviction stays distinguishable.
        /// </remarks>
        public void Bind(TKey key)
        {
            Debug.Assert(RefCount == 0 && _taken == 0 && _waiters.Count == 0 && !_localWaiter.InUse,
                "Recycled entry is not idle.");

            _key = key;
        }

        /// <summary>
        /// Drops the key reference when the entry is evicted, so a pooled entry does not keep an otherwise
        /// unreachable key alive. Caller holds <see cref="AsyncKeyedLock{TKey}._keyLock"/>.
        /// </summary>
        public void Unbind() => _key = default!;

        /// <summary>
        /// Stamps a fresh acquisition token. Called only by the thread that just took the lock, which owns
        /// the entry exclusively until it releases, so no interlocked operation is needed.
        /// </summary>
        private short NextGeneration() => unchecked(++_generation);

        /// <summary>
        /// Attempts to take the lock immediately via a single atomic exchange, with no queueing,
        /// no allocation, and no waiting - the building block behind <see cref="AsyncKeyedLock{TKey}.TryLock"/>.
        /// </summary>
        [MethodImpl(MethodImplOptionsEx.HotPath)]
        internal bool TryTake(out Releaser releaser)
        {
            if (Interlocked.Exchange(ref _taken, 1) == 0)
            {
                releaser = new Releaser(_owner, _key, this, NextGeneration());
                return true;
            }

            releaser = default;
            return false;
        }

        [MethodImpl(MethodImplOptionsEx.HotPath)]
        public ValueTask<Releaser> LockAsync(TimeSpan timeout, CancellationToken cancellationToken)
        {
            if (Interlocked.Exchange(ref _taken, 1) == 0)
            {
                return new ValueTask<Releaser>(new Releaser(_owner, _key, this, NextGeneration()));
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
                    return new ValueTask<Releaser>(new Releaser(_owner, _key, this, NextGeneration()));
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
            }
            finally
            {
                _spinLock.Exit();
            }

            if (timeout != Timeout.InfiniteTimeSpan)
            {
                waiter.TimeoutTimer = TimeProvider.System.CreateTimer(
                    _timerCallbackAction, new TimeoutState<Releaser>(waiter), timeout, Timeout.InfiniteTimeSpan);
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
                    // Retire the caller's token before the entry becomes takeable, so a second dispose of
                    // the same releaser is rejected rather than releasing whoever acquires next. Ordered
                    // ahead of the volatile _taken write, and safe because _taken is still set here.
                    NextGeneration();
                    _taken = 0;
                    return;
                }

                toRelease = _waiters.Dequeue();
            }
            finally
            {
                _spinLock.Exit();
            }

            // Handing the lock straight to the next waiter is a new acquisition, so it gets a new token -
            // which also retires the releaser the caller just used. Safe outside the spin lock: _taken stays
            // set across the handoff, so no other thread can be stamping a generation concurrently.
            toRelease.SetResult(new Releaser(_owner, _key, this, NextGeneration()));
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
        [MethodImpl(MethodImplOptionsEx.HotPath)]
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
