// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1711 // "Ex" suffix requested explicitly to name this as the reentrant counterpart to AsyncLock during prototyping; revisit before this leaves prototype status

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// An experimental, prototype-quality async lock that permits reentrant acquisition from nested calls
/// on the same logical async flow, without deadlocking - unlike <see cref="AsyncLock"/>, which is not
/// reentrant.
/// </summary>
/// <remarks>
/// <para>
/// <b>Status:</b> this is a design prototype, not a hardened primitive. It has not been through the
/// allocation/pooling optimization pass the rest of this library's primitives have, and its correctness
/// envelope (see below) is narrower than a caller might assume from the name. Read the whole remarks
/// section before using it.
/// </para>
/// <para>
/// <b>Mechanism:</b> an <see cref="AsyncLocal{T}"/> tracks the current ambient "depth" for this
/// instance - how many nested acquisitions of <em>this specific lock</em> are currently held by the
/// logical flow the calling code is running on. Each depth gets its own real, independent
/// <see cref="AsyncLock"/>, created lazily on first use. Acquiring at depth <c>N</c> takes
/// <c>_depthLocks[N]</c>, then bumps the ambient depth to <c>N + 1</c> for the duration of the hold, so a
/// nested call from inside the held region naturally acquires a <em>different</em>, currently-unheld
/// lock instead of trying to re-take the one its own ancestor already holds.
/// </para>
/// <para>
/// <b>Why this is safe against concurrent siblings, unlike a naive "skip if already held" flag:</b> you
/// can only ever be executing at depth <c>N</c> if some ancestor in your own call chain is currently
/// holding depth <c>N - 1</c> - and depth 0 is a single, fully exclusive lock, so only one logical tree
/// can be active system-wide at any moment. That means <c>_depthLocks[N]</c> is never contended by two
/// <em>unrelated</em> trees; it's only ever contended by descendants of whoever currently holds depth
/// <c>N - 1</c>. Concretely: if code holding the lock does
/// <c>await Task.WhenAll(NestedA(), NestedB())</c> and both <c>NestedA</c> and <c>NestedB</c> call
/// <see cref="LockAsync(CancellationToken)"/> again, both inherit ambient depth 1 and both contend for
/// the <em>same</em> <c>_depthLocks[1]</c> - they genuinely serialize against each other instead of both
/// (incorrectly) believing they already hold the lock and racing inside what should be a mutually
/// exclusive region. Every acquisition here is real; nothing is ever skipped.
/// </para>
/// <para>
/// <b>Generation-checked fallback for detached/orphaned callers:</b> the invariant above ("depth N is
/// only ever touched by live descendants of whoever holds depth N-1") breaks if a parent releases before
/// a fire-and-forget child it spawned (e.g. via <c>Task.Run</c>, never awaited) has finished - the child
/// still carries the ambient depth its parent handed it, but the parent it was nested under is gone, and
/// a completely unrelated new acquirer could now be holding depth N-1 instead. Left unhandled, that
/// child would contend for <c>_depthLocks[N]</c> against whatever that unrelated tree's own descendants
/// are doing there - not a data race (the lock still correctly serializes), but a semantically meaningless
/// mixing of two unrelated trees at that depth, and if the orphaned child never completes, it can wedge
/// <c>_depthLocks[N]</c> forever for every future caller, not just its own abandoned tree. To guard
/// against this, each per-depth lock also tracks a generation counter, bumped on every successful
/// acquisition. A caller acquiring depth N remembers the generation it observed depth N-1 to have at
/// that moment. Before actually acquiring depth N, it re-checks: is depth N-1 still held, by that same
/// remembered generation? If yes, the nesting claim is still live - proceed normally. If no - the parent
/// already released, or someone else now holds it - the claim is stale, so instead of trusting it, the
/// call falls back to targeting depth N-1 itself, as an ordinary (possibly waiting) acquisition, rather
/// than skipping ahead on a nesting assumption that no longer holds. Falling back one level like this is
/// always safe: acquiring a lock you don't already hold can never self-deadlock, so no re-validation of
/// earlier ancestors is needed - only the immediate parent's generation matters for this decision.
/// </para>
/// <para>
/// <b>Release-time misuse guard:</b> disposing the releaser for depth N checks whether depth N+1 is still
/// held at that moment - if so, that is a live symptom of a fire-and-forget nesting misuse somewhere,
/// since depth N+1 is only ever supposed to be reachable from a call still nested under a depth-N holder,
/// and nothing else can be validly holding depth N right now except this exact <see cref="Releaser"/>. The
/// lock is still released either way (a throw must never leave anything wedged), but an
/// <see cref="InvalidOperationException"/> is thrown afterward so the misuse surfaces immediately instead
/// of only showing up later as unexplained contention. This check is coarse, not precise: it only asks
/// "is <em>something</em> still held one level deeper," not "was it specifically spawned by me" - it
/// cannot distinguish a descendant this exact acquisition spawned from an unrelated orphan left over from
/// an earlier violation that simply hasn't finished yet. Both are real bugs worth surfacing, but a caller
/// investigating a thrown exception should not assume it necessarily points at code nested directly under
/// <em>this specific</em> acquisition.
/// </para>
/// <para>
/// <b>What this still does NOT protect against:</b> a fire-and-forget call is not guaranteed to observe
/// the fallback before its ambient parent is torn down - if the check happens to run in the narrow window
/// before the parent's release is observable, it can still (rarely) proceed as if genuinely nested. This
/// closes the common, easy-to-hit case (parent returns immediately, long before any child even starts),
/// not a fully airtight guarantee against every interleaving. Calling <see cref="ExecutionContext.SuppressFlow"/>
/// before detaching remains the only fully reliable way to opt fire-and-forget work out of this entirely.
/// </para>
/// <para>
/// <b>Unbounded depth:</b> <c>_depthLocks</c> is a copy-on-write array that grows lazily and without an
/// upper bound, so there is no depth limit and therefore no risk of wrapping around into re-acquiring an
/// ancestor's still-held lock (which would be a genuine, silent self-deadlock). Reads index it directly
/// with no lock and no hashing; growth and first-use slot creation happen under a private lock and are
/// rare. The tradeoff is one extra per-depth entry - never reclaimed - per distinct depth this instance
/// has ever reached.
/// </para>
/// <para>
/// <b>A more fundamental limitation found while prototyping this:</b> an <see cref="AsyncLocal{T}"/>
/// mutation made inside an <see langword="async"/> method is never visible to that method's own caller
/// once it returns - not even on a fully synchronous completion with zero real suspension. Crossing an
/// async method's state machine boundary resets the caller's ambient context on return, unconditionally.
/// That means <see cref="LockAsync(CancellationToken)"/> and
/// <see cref="LockAsync(TimeSpan, CancellationToken)"/> are deliberately written as plain (non-async)
/// methods with an inline fast path specifically so the depth bump for an uncontended acquisition
/// happens in the <em>caller's own frame</em>, never crossing that boundary. This works for the primary
/// case reentrancy exists for - a nested call reaching a depth no other flow currently occupies, which is
/// always uncontended by construction. It does NOT work for a call that had to genuinely wait for its own
/// depth-level lock (e.g. the losing side of two <c>Task.WhenAll</c> siblings racing for the same depth):
/// once that call resumes from a real suspension, its own depth bump is invisible to whatever it does
/// next, so further nesting from inside that specific call is not reliably tracked. This is a real,
/// currently-unresolved gap in the prototype, not just a documentation caveat.
/// </para>
/// </remarks>
public sealed class AsyncLockEx
{
    private readonly AsyncLocal<AmbientState> _ambient = new();

    // Depths are small, dense, non-negative ints, so a copy-on-write array indexed directly by depth
    // beats a ConcurrentDictionary's hashing and bucket walk on the hot path. Reads take the array
    // reference via this volatile field and index it without any lock; growth and per-slot creation are
    // rare (only when a depth is reached for the very first time) and happen under _growLock.
    private volatile DepthLock?[] _depthLocks;

    // Depth 0 is by far the most common target - every non-nested acquisition - so it is created up
    // front and cached here, letting the common case skip the array bounds check and load entirely.
    private readonly DepthLock _depth0Lock;

    private readonly object _growLock = new();
    private int _depthsCreated;

    /// <summary>
    /// Constructs a new <see cref="AsyncLockEx"/>.
    /// </summary>
    public AsyncLockEx()
    {
        _depth0Lock = new DepthLock();
        _depthLocks = new DepthLock?[4];
        _depthLocks[0] = _depth0Lock;
        _depthsCreated = 1;
    }

    /// <summary>
    /// Ambient per-flow state: how deep the current logical flow believes it is nested, and the
    /// generation it observed its immediate parent depth to have at the moment it was (believed to be)
    /// validly acquired. Depth 0 has no parent to validate against.
    /// </summary>
    internal readonly struct AmbientState
    {
        public readonly int Depth;
        public readonly int ParentGeneration;

        public AmbientState(int depth, int parentGeneration)
        {
            Depth = depth;
            ParentGeneration = parentGeneration;
        }
    }

    /// <summary>
    /// A single depth level's real lock plus a generation counter bumped on every successful
    /// acquisition, used to detect whether a caller's remembered "my parent is still holding depth N-1"
    /// claim is still true.
    /// </summary>
    private sealed class DepthLock
    {
        public readonly AsyncLock Lock = new();
        private int _generation;

        /// <remarks>
        /// Deliberately an <see cref="int"/> rather than a <see cref="long"/>: 32-bit reads and writes
        /// are atomic on every platform this library targets (including 32-bit net462), so the check
        /// path can use a plain acquire read instead of the read-modify-write <c>Interlocked.Read</c> a
        /// 64-bit counter would require there. Wrapping after 2^32 acquisitions of a single depth would
        /// need an exact collision with a remembered value to matter, and the consequence would only be
        /// the same narrow stale-claim race already documented at the type level.
        /// </remarks>
        public int Generation => Volatile.Read(ref _generation);

        public int BumpGeneration() => Interlocked.Increment(ref _generation);
    }

    /// <summary>
    /// Returns the lock for <paramref name="depth"/>, creating it if this is the first time that depth
    /// has ever been reached.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private DepthLock GetDepthLock(int depth)
    {
        if (depth == 0)
        {
            return _depth0Lock;
        }

        DepthLock?[] locks = _depthLocks;
        if ((uint)depth < (uint)locks.Length)
        {
            DepthLock? existing = Volatile.Read(ref locks[depth]);
            if (existing is not null)
            {
                return existing;
            }
        }

        return CreateDepthLock(depth);
    }

    /// <summary>
    /// Returns the lock for <paramref name="depth"/>, or <see langword="null"/> if that depth has never
    /// been reached - i.e. a lookup that must not itself create anything.
    /// </summary>
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

                var grown = new DepthLock?[newLength];
                Array.Copy(current, grown, current.Length);

                // Volatile write publishes the fully-populated copy: a concurrent reader sees either the
                // old array or this one, both internally consistent. Existing DepthLock instances are
                // carried over by reference, so identities and generations survive the growth untouched.
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

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition. Disposing the releaser releases the
    /// lock at the depth it was acquired at, and restores the ambient depth for this instance to what it
    /// was before the acquisition.
    /// </summary>
    public readonly struct Releaser : IDisposable, IAsyncDisposable, IEquatable<Releaser>
    {
        private readonly AsyncLockEx _owner;
        private readonly AsyncLock.Releaser _inner;
        private readonly AmbientState _stateBeforeAcquisition;
        private readonly int _depth;

        internal Releaser(AsyncLockEx owner, AsyncLock.Releaser inner, AmbientState stateBeforeAcquisition, int depth)
        {
            _owner = owner;
            _inner = inner;
            _stateBeforeAcquisition = stateBeforeAcquisition;
            _depth = depth;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            // Restored explicitly rather than relied upon to unwind automatically: AsyncLocal mutations
            // are only guaranteed to be scoped back on return through a genuine await suspension
            // boundary, not through an ordinary synchronous method return (e.g. the uncontended fast
            // path below, which never actually suspends). Explicit push/pop, exactly like the classic
            // ambient-context-scope pattern (e.g. TransactionScope), is correct regardless of which path
            // was taken to get here.
            _owner._ambient.Value = _stateBeforeAcquisition;
            _inner.Dispose();

            // Release-time misuse guard: only one flow can ever hold _depth at a time, so anything still
            // live at _depth + 1 right now can only be a fire-and-forget descendant this exact holder
            // spawned but never awaited. Always release above before checking, so a violation never
            // leaves anything wedged - this only makes the bug loud, it doesn't try to fix it.
            // CA1065 is intentionally not followed here: throwing from Dispose is normally an
            // anti-pattern because it can mask the real error during cleanup, but this Dispose has
            // already fully released above by this point - the throw exists specifically to surface a
            // caller bug (fire-and-forget nesting) as loudly as possible, not to report a cleanup failure.
#pragma warning disable CA1065
            DepthLock? deeper = _owner.TryGetDepthLock(_depth + 1);
            if (deeper is not null && deeper.Lock.IsTaken)
            {
                throw new InvalidOperationException(
                    $"AsyncLockEx: depth {_depth} was released while depth {_depth + 1} was still held. " +
                    "This means a fire-and-forget call (e.g. an unawaited Task.Run) nested under this " +
                    "acquisition outlived it - the lock was still released cleanly, but that descendant " +
                    "is now orphaned and no longer safely tracked. See the type-level remarks.");
            }
#pragma warning restore CA1065
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
            => _inner.Equals(other._inner);

        /// <inheritdoc/>
        public override int GetHashCode()
            => _inner.GetHashCode();

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
    /// Asynchronously acquires the lock, with a cancellation token. If the current logical flow already
    /// holds this lock (directly or via an ancestor call), this acquires a separate, depth-specific
    /// lock instead of re-entering the one already held, so it cannot self-deadlock - see the type-level
    /// remarks for the exact correctness envelope this provides.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A <see cref="ValueTask{Releaser}"/> that completes when the lock is acquired. Dispose the
    /// returned releaser to release the lock.
    /// </returns>
    public ValueTask<Releaser> LockAsync(CancellationToken cancellationToken = default)
    {
        AmbientState state = _ambient.Value;
        int targetDepth = ResolveTargetDepth(state);
        DepthLock depthLock = GetDepthLock(targetDepth);
        ValueTask<AsyncLock.Releaser> innerTask = depthLock.Lock.LockAsync(cancellationToken);

        if (innerTask.IsCompletedSuccessfully)
        {
            // Deliberately NOT an `async` method: crossing an async method's own state machine
            // boundary resets AsyncLocal mutations for its caller on return, even on a fully
            // synchronous completion with no real suspension - see AsyncLockExTests.
            // DepthBumpIsVisibleToCallerAfterUncontendedAcquisition for a direct empirical proof.
            // Staying in the caller's own frame for this fast, uncontended path is what makes the
            // depth bump below actually visible to whatever runs next in the caller.
            int myGeneration = depthLock.BumpGeneration();
            _ambient.Value = new AmbientState(targetDepth + 1, myGeneration);
            return new ValueTask<Releaser>(new Releaser(this, innerTask.Result, state, targetDepth));
        }

        return AwaitAndBumpDepth(innerTask, depthLock, state, targetDepth);
    }

    private async ValueTask<Releaser> AwaitAndBumpDepth(ValueTask<AsyncLock.Releaser> innerTask, DepthLock depthLock, AmbientState stateBeforeAcquisition, int depth)
    {
        AsyncLock.Releaser inner = await innerTask.ConfigureAwait(false);

        // This mutation is scoped to whatever runs after this point within THIS call's own
        // continuation - it will NOT be visible to the code that originally called LockAsync once
        // this method returns to it, for the same AsyncLocal-scoping reason the fast path above has
        // to avoid `async` entirely. Practically: a call that had to genuinely wait for its own
        // depth-level lock (e.g. the losing side of two Task.WhenAll siblings racing for the same
        // depth) will not correctly track further nesting after it resumes. See the type-level
        // remarks.
        int myGeneration = depthLock.BumpGeneration();
        _ambient.Value = new AmbientState(depth + 1, myGeneration);
        return new Releaser(this, inner, stateBeforeAcquisition, depth);
    }

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
    /// <exception cref="TimeoutException">Thrown when the timeout elapses before the lock can be acquired.</exception>
    public ValueTask<Releaser> LockAsync(TimeSpan timeout, CancellationToken cancellationToken = default)
    {
        AmbientState state = _ambient.Value;
        int targetDepth = ResolveTargetDepth(state);
        DepthLock depthLock = GetDepthLock(targetDepth);
        ValueTask<AsyncLock.Releaser> innerTask = depthLock.Lock.LockAsync(timeout, cancellationToken);

        if (innerTask.IsCompletedSuccessfully)
        {
            int myGeneration = depthLock.BumpGeneration();
            _ambient.Value = new AmbientState(targetDepth + 1, myGeneration);
            return new ValueTask<Releaser>(new Releaser(this, innerTask.Result, state, targetDepth));
        }

        return AwaitAndBumpDepth(innerTask, depthLock, state, targetDepth);
    }

    /// <summary>
    /// Decides which depth to actually target for this acquisition: the ambient depth, if the immediate
    /// parent depth is still held by the exact generation this flow remembers observing - or one level
    /// back, as an ordinary (not assumed-nested) acquisition, if that claim no longer holds. See the
    /// type-level remarks for why a single-level fallback is sufficient and always safe.
    /// </summary>
    private int ResolveTargetDepth(AmbientState state)
    {
        if (state.Depth == 0)
        {
            return 0;
        }

        int parentDepth = state.Depth - 1;
        DepthLock? parent = TryGetDepthLock(parentDepth);
        if (parent is not null
            && parent.Lock.IsTaken
            && parent.Generation == state.ParentGeneration)
        {
            return state.Depth;
        }

        return parentDepth;
    }

    /// <summary>
    /// Gets the number of distinct depths this instance has ever reached, i.e. the number of internal
    /// per-depth lock entries that have been created so far. Always at least 1, since depth 0 is created
    /// up front. A best-effort diagnostic, not a value that can be relied upon for synchronization.
    /// </summary>
    public int DepthsCreated => Volatile.Read(ref _depthsCreated);

    /// <summary>
    /// Diagnostic-only: the ambient depth this instance currently sees for the calling flow.
    /// </summary>
    internal int CurrentDepth => _ambient.Value.Depth;
}
