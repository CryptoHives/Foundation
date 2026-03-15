// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1508 // Avoid dead conditional code

namespace CryptoHives.Foundation.Threading.Async.Pooled;

using CryptoHives.Foundation.Threading.Pools;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

/// <summary>
/// An async reader-writer lock which uses a pooled approach to implement waiters
/// for <see cref="ValueTask"/> to reduce memory allocations.
/// </summary>
/// <remarks>
/// <para>
/// This implementation uses <see cref="ValueTask"/> for waiters and provides allocation-free
/// async signaling by reusing pooled <see cref="IValueTaskSource{TResult}"/> instances to avoid allocations
/// of <see cref="TaskCompletionSource{TResult}"/> and <see cref="Task"/>.
/// </para>
/// <para>
/// The lock supports multiple concurrent readers,
/// concurrent readers and one single upgradeable reader,
/// a single exclusive writer or a single upgraded exclusive writer.
/// Writer and upgraded writer requests are prioritized over new reader requests
/// to prevent writer starvation.
/// </para>
/// <para>
/// <b>Important Usage Note:</b> Awaiting on <see cref="ValueTask"/> has its own caveats, as it
/// is a struct that can only be awaited or converted with AsTask() ONE single time.
/// Additional attempts to await after the first await or additional conversions to AsTask() will throw
/// an <see cref="InvalidOperationException"/>.
/// </para>
/// <para>
/// <b>Continuation Scheduling:</b> The <see cref="RunContinuationAsynchronously"/> property
/// controls how continuations are executed when the lock is released. When set to <see langword="true"/>
/// (default), continuations are forced to queue to the thread pool.
/// </para>
/// <example>
/// <code>
/// private readonly AsyncReaderWriterLock _rwLock = new AsyncReaderWriterLock();
///
/// public async Task ReadAsync(CancellationToken ct)
/// {
///     using (await _rwLock.ReaderLockAsync(ct))
///     {
///         // Multiple readers can hold the lock concurrently
///         await ReadDataAsync();
///     }
/// }
///
/// public async Task WriteAsync(CancellationToken ct)
/// {
///     using (await _rwLock.WriterLockAsync(ct))
///     {
///         // Exclusive access - no other readers or writers
///         await WriteDataAsync();
///     }
/// }
///
/// public async Task UpgradeableReadWriteAsync(CancellationToken ct)
/// {
///     using (var upgr = await _rwLock.UpgradeableReaderLockAsync(ct))
///     {
///         // Multiple readers and one upgradeable reader can hold the lock concurrently
///         await ReadDataAsync();
///
///         // upgrade the reader to perform a write operation
///         using (await upgr.UpgradeToWriterLockAsync(ct))
///         {
///             // Exclusive access - no other readers or writers
///             await WriteDataAsync();
///         }
///     }
/// }
/// 
/// </code>
/// </example>
/// </remarks>
public sealed class AsyncReaderWriterLock
{
    /// <summary>
    /// Represents the maximum number of concurrent readers allowed by the lock.
    /// </summary>
    /// <remarks>
    /// This constant is used to limit the number of simultaneous readers incl. the upgradeable reader.
    /// The value is set to a reasonable count to prevent too many active tasks.
    /// More readers are queued and released in batches to prevent excessive spinning and CPU usage
    /// when there are many waiting readers.
    /// </remarks>
    private const int MaxReaderCount = 1000;

    /// <summary>
    /// The internal fixed states used by the lock status.
    /// </summary>
    /// <remarks>
    /// A positive value in the range of 1..n indicates the number of active concurrent readers,
    /// where n is limited by MaxReaderCount.
    /// A positive value greater or equal than <see cref="UpgradeableReader"/> indicates the number
    /// of concurrent readers including an upgradeable reader by subtracting <see cref="MaxReaderCount"/>.
    /// Only a single upgradeable reader can be active at a time, and its presence is indicated
    /// by a status value greater or equal than <see cref="UpgradeableReader"/>.
    /// Other states are exclusive states for uncontested, writer and upgraded writer.
    /// The status is protected by atomic interlocked operations and a lock to ensure thread safety
    /// and correct transitions.
    /// The fast path transitions are only supported out of the uncontested state, while all other
    /// transitions require acquiring the lock to ensure correct handling of waiting queues and cancellation.
    /// </remarks>
    private enum LockState : int
    {
        Uncontested = 0,
        Reader = 1,
        Writer = -1,
        UpgradedWriter = -2,
        UpgradedWriterWithoutReader = -3,
        UpgradeableReader = 0x40000000
    }

    private readonly IGetPooledManualResetValueTaskSource<Releaser> _pool;

    private WaiterQueue<Releaser> _waitingWriters;
    private readonly LocalManualResetValueTaskSource<Releaser> _localWriterWaiter;

    private WaiterQueue<Releaser> _waitingReaders;
    private readonly LocalManualResetValueTaskSource<Releaser> _localReaderWaiter;

    private WaiterQueue<Releaser> _waitingUpgradeableReaders;
    private readonly LocalManualResetValueTaskSource<Releaser> _localUpgradeableReaderWaiter;

    private WaiterQueue<Releaser> _waitingUpgradedWriters;
    private readonly LocalManualResetValueTaskSource<Releaser> _localUpgradedWriterWaiter;

#if NET9_0_OR_GREATER
    private readonly Lock _mutex;
#else
    private readonly object _mutex;
#endif

    private volatile int _status;
    private bool _runContinuationAsynchronously;

    /// <summary>
    /// A small value type returned by awaiting a lock acquisition.
    /// Disposing the releaser releases the lock.
    /// </summary>
    /// <remarks>
    /// Due to the different usage options for this releaser with the
    /// method to upgrade an upgradeable reader, it had been preferred
    /// to have a dedicated struct instead of using a common struct with
    /// flags to reduce the risk of incorrect usage.
    /// However multiple releaser struct types had resulted in seperate
    /// ObjectPools for each struct type which had reduced the overall
    /// pool efficiency and increased the memory usage, so a single struct
    /// with an enum to distinguish the different usage scenarios had been
    /// chosen as a good balance between usability and performance.
    /// Since any releaser can call the <see cref="UpgradeToWriterLockAsync"/>
    /// method, an <see cref="InvalidOperationException"/> is thrown if the
    /// method is
    /// called on a releaser that is not for the upgradeable reader state.
    /// </remarks>
    public readonly struct Releaser
        : IDisposable, IAsyncDisposable, IEquatable<Releaser>
    {
        /// <summary>
        /// Specifies the releaser type.
        /// </summary>
        public enum ReleaserType
        {
            /// <summary>
            /// A releaser for a reader lock.
            /// </summary>
            Reader,

            /// <summary>
            /// A releaser for a writer lock.
            /// </summary>
            Writer,

            /// <summary>
            /// A releaser for an upgradeable reader lock.
            /// </summary>
            UpgradeableReader,

            /// <summary>
            /// A releaser for an upgraded writer lock.
            /// </summary>
            UpgradedWriter
        }

        private readonly AsyncReaderWriterLock _owner;
        private readonly ReleaserType _releaserType;

        internal Releaser(AsyncReaderWriterLock owner, ReleaserType releaserType)
        {
            _owner = owner;
            _releaserType = releaserType;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            if (_owner is not null)
            {
                if (_releaserType == ReleaserType.Reader)
                {
                    _owner.ReleaseReaderLock();
                }
                else if (_releaserType == ReleaserType.Writer)
                {
                    _owner.ReleaseWriterLock();
                }
                else if (_releaserType == ReleaserType.UpgradeableReader)
                {
                    _owner.ReleaseUpgradeableReaderLock();
                }
                else if (_releaserType == ReleaserType.UpgradedWriter)
                {
                    _owner.ReleaseUpgradedWriterLock();
                }
                else
                {
                    Debug.Assert(false, "Invalid releaser type.");
                }
            }
        }

        /// <inheritdoc/>
        public ValueTask DisposeAsync()
        {
            Dispose();
            return default;
        }

        /// <summary>
        /// Upgrades an upgradable reader to a writer lock.
        /// </summary>
        /// <remarks>
        /// This method must only be called when the Releaser instance is in the upgradeable reader
        /// state. Failing to release the write lock by disposing the returned releaser may result in
        /// deadlocks.
        /// </remarks>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the attempt to upgrade to the write lock.</param>
        /// <exception cref="InvalidOperationException">Thrown if the current instance is not in the upgradeable reader state.</exception>
        public ValueTask<Releaser> UpgradeToWriterLockAsync(CancellationToken cancellationToken = default)
        {
            if (_owner is null)
            {
                throw new InvalidOperationException("Releaser does not have an associated lock.");
            }

            if (_releaserType != ReleaserType.UpgradeableReader)
            {
                throw new InvalidOperationException("Releaser is not in the upgradeable reader state.");
            }

            return _owner.UpgradeToWriterLockAsync(cancellationToken);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
            => obj is Releaser other && Equals(other);

        /// <inheritdoc/>
        public bool Equals(Releaser other)
            => ReferenceEquals(_owner, other._owner) && _releaserType == other._releaserType;

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(_owner, _releaserType);
        }

        /// <summary>
        /// Determines whether two Releaser instances are equal.
        /// </summary>
        public static bool operator ==(Releaser left, Releaser right)
            => left.Equals(right);

        /// <summary>
        /// Determines whether two Releaser instances are not equal.
        /// </summary>
        public static bool operator !=(Releaser left, Releaser right)
            => !left.Equals(right);
    }

    /// <summary>
    /// Constructs a new AsyncReaderWriterLock instance.
    /// </summary>
    /// <param name="runContinuationAsynchronously">Indicates if continuations are forced to run asynchronously.</param>
    /// <param name="pool">Custom pool for waiters.</param>
    public AsyncReaderWriterLock(
        bool runContinuationAsynchronously = true,
        IGetPooledManualResetValueTaskSource<Releaser>? pool = null)
    {
        _runContinuationAsynchronously = runContinuationAsynchronously;
        _mutex = new();

        _waitingWriters = new();
        _localWriterWaiter = new(this);

        _waitingReaders = new();
        _localReaderWaiter = new(this);

        _waitingUpgradeableReaders = new();
        _localUpgradeableReaderWaiter = new(this);

        _waitingUpgradedWriters = new();
        _localUpgradedWriterWaiter = new(this);

        _pool = pool ?? ValueTaskSourceObjectPools.ValueTaskSourcePoolAsyncReaderWriterLockReleaser;

        _status = 0;
    }

    /// <summary>
    /// Gets whether the lock is currently held by any readers.
    /// </summary>
    public bool IsReadLockHeld
    {
        get { return _status > 0; }
    }

    /// <summary>
    /// Gets whether the lock is currently held by a writer.
    /// </summary>
    public bool IsWriteLockHeld
    {
        get { return _status < 0; }
    }

    /// <summary>
    /// Gets whether the lock is currently held by an upgradeable reader.
    /// </summary>
    public bool IsUpgradeableReadLockHeld
    {
        get { return _status >= (int)LockState.UpgradeableReader; }
    }

    /// <summary>
    /// Gets whether the lock is currently held by an upgraded writer.
    /// </summary>
    public bool IsUpgradedWriterLockHeld
    {
        get { return _status == (int)LockState.UpgradedWriter; }
    }

    /// <summary>
    /// Gets the current number of readers holding the lock.
    /// May also include an upgradeable reader if present.
    /// </summary>
    public int CurrentReaderCount
    {
        get
        {
            int status = _status;
            return status > 0 ?
                (status >= (int)LockState.UpgradeableReader ?
                    status - (int)LockState.UpgradeableReader + 1 :
                    status)
                : 0;
        }
    }

    /// <summary>
    /// Gets the number of writers waiting for the lock.
    /// </summary>
    public int WaitingWriterCount
    {
        get { lock (_mutex) return _waitingWriters.Count; }
    }

    /// <summary>
    /// Gets the number of readers waiting for the lock.
    /// </summary>
    public int WaitingReaderCount
    {
        get { lock (_mutex) return _waitingReaders.Count; }
    }

    /// <summary>
    /// Gets the number of readers waiting for the lock.
    /// </summary>
    public int WaitingUpgradeableReaderCount
    {
        get { lock (_mutex) return _waitingUpgradeableReaders.Count; }
    }

    /// <summary>
    /// Gets the number of upgraded writers waiting for the lock.
    /// </summary>
    public int WaitingUpgradedWritersCount
    {
        get { lock (_mutex) return _waitingUpgradedWriters.Count; }
    }

    /// <summary>
    /// Gets or sets whether to force continuations to run asynchronously.
    /// </summary>
    public bool RunContinuationAsynchronously
    {
        get => _runContinuationAsynchronously;
        set => _runContinuationAsynchronously = value;
    }

    /// <summary>
    /// Asynchronously acquires a reader lock.
    /// </summary>
    /// <remarks>
    /// Multiple readers can hold the lock concurrently. If a writer is waiting,
    /// new readers will be queued behind the writer to prevent writer starvation.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask{Releaser}"/> that completes when the reader lock is acquired.</returns>
    public ValueTask<Releaser> ReaderLockAsync(CancellationToken cancellationToken = default)
    {
        // fast path for uncontested reader lock acquisition
        if (Interlocked.CompareExchange(ref _status, (int)LockState.Reader, (int)LockState.Uncontested) == (int)LockState.Uncontested)
        {
            return new ValueTask<Releaser>(new Releaser(this, Releaser.ReleaserType.Reader));
        }

        lock (_mutex)
        {
            if (_waitingWriters.Count == 0 && _waitingUpgradedWriters.Count == 0)
            {
                int status = Interlocked.CompareExchange(ref _status, (int)LockState.Reader, (int)LockState.Uncontested);
                if (status is >= ((int)LockState.Uncontested) and < MaxReaderCount or
                    >= ((int)LockState.UpgradeableReader) and < ((int)LockState.UpgradeableReader + MaxReaderCount))
                {
                    if (status > (int)LockState.Uncontested)
                    {
                        Interlocked.Increment(ref _status);
                    }
                    return new ValueTask<Releaser>(new Releaser(this, Releaser.ReleaserType.Reader));
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask<Releaser>(Task.FromCanceled<Releaser>(cancellationToken));
            }

            if (!_localReaderWaiter.TryGetValueTaskSource(out ManualResetValueTaskSource<Releaser> waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
            }
            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
            waiter.CancellationToken = cancellationToken;

            if (cancellationToken.CanBeCanceled)
            {
#if NET6_0_OR_GREATER
                waiter.CancellationTokenRegistration =
                    cancellationToken.UnsafeRegister(_readerCancellationCallbackAction, waiter);
#else
                waiter.CancellationTokenRegistration =
                    cancellationToken.Register(ReaderCancellationCallback, waiter, useSynchronizationContext: false);
#endif
            }
            else
            {
                Debug.Assert(waiter.CancellationTokenRegistration == default);
            }

            _waitingReaders.Enqueue(waiter);
            return new ValueTask<Releaser>(waiter, waiter.Version);
        }
    }

    /// <summary>
    /// Asynchronously acquires an upgradeable reader lock.
    /// </summary>
    /// <remarks>
    /// One upgradeable reader can hold the lock, allowing multiple readers to
    /// concurrently execute as well. If the upgradeable reader decides to upgrade
    /// to a writer lock, it will wait until all other readers have released the lock.
    /// If a writer is waiting, new readers will be queued behind the writer to prevent
    /// writer starvation.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask{Releaser}"/> that completes when the upgradeable reader lock is acquired.</returns>
    public ValueTask<Releaser> UpgradeableReaderLockAsync(CancellationToken cancellationToken = default)
    {
        // fast path for uncontested upgradeable reader lock acquisition
        if (Interlocked.CompareExchange(ref _status, (int)LockState.UpgradeableReader, (int)LockState.Uncontested) == (int)LockState.Uncontested)
        {
            return new ValueTask<Releaser>(new Releaser(this, Releaser.ReleaserType.UpgradeableReader));
        }

        lock (_mutex)
        {
            if (_waitingWriters.Count == 0 && _waitingUpgradedWriters.Count == 0)
            {
                int status = Interlocked.CompareExchange(ref _status, (int)LockState.UpgradeableReader, (int)LockState.Uncontested);
                if (status is >= ((int)LockState.Uncontested) and < MaxReaderCount)
                {
                    if (status > (int)LockState.Uncontested)
                    {
                        Interlocked.Add(ref _status, (int)LockState.UpgradeableReader);
                    }
                    return new ValueTask<Releaser>(new Releaser(this, Releaser.ReleaserType.UpgradeableReader));
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask<Releaser>(Task.FromCanceled<Releaser>(cancellationToken));
            }

            if (!_localUpgradeableReaderWaiter.TryGetValueTaskSource(out ManualResetValueTaskSource<Releaser> waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
            }
            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
            waiter.CancellationToken = cancellationToken;

            if (cancellationToken.CanBeCanceled)
            {
#if NET6_0_OR_GREATER
                waiter.CancellationTokenRegistration =
                    cancellationToken.UnsafeRegister(_upgradeableReaderCancellationCallbackAction, waiter);
#else
                waiter.CancellationTokenRegistration =
                    cancellationToken.Register(UpgradeableReaderCancellationCallback, waiter, useSynchronizationContext: false);
#endif
            }
            else
            {
                Debug.Assert(waiter.CancellationTokenRegistration == default);
            }

            _waitingUpgradeableReaders.Enqueue(waiter);
            return new ValueTask<Releaser>(waiter, waiter.Version);
        }
    }

    /// <summary>
    /// Asynchronously acquires a writer lock.
    /// </summary>
    /// <remarks>
    /// Only one writer can hold the lock at a time, and no readers can hold the lock
    /// while a writer has it. Writers are prioritized over new readers.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask{Releaser}"/> that completes when the writer lock is acquired.</returns>
    public ValueTask<Releaser> WriterLockAsync(CancellationToken cancellationToken = default)
    {
        // fast path for uncontested writer lock acquisition
        if (Interlocked.CompareExchange(ref _status, (int)LockState.Writer, (int)LockState.Uncontested) == (int)LockState.Uncontested)
        {
            return new ValueTask<Releaser>(new Releaser(this, Releaser.ReleaserType.Writer));
        }

        lock (_mutex)
        {
            // double check for race conditions
            if (Interlocked.CompareExchange(ref _status, (int)LockState.Writer, (int)LockState.Uncontested) == (int)LockState.Uncontested)
            {
                return new ValueTask<Releaser>(new Releaser(this, Releaser.ReleaserType.Writer));
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask<Releaser>(Task.FromCanceled<Releaser>(cancellationToken));
            }

            if (!_localWriterWaiter.TryGetValueTaskSource(out ManualResetValueTaskSource<Releaser> waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
            }
            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
            waiter.CancellationToken = cancellationToken;

            if (cancellationToken.CanBeCanceled)
            {
#if NET6_0_OR_GREATER
                waiter.CancellationTokenRegistration =
                    cancellationToken.UnsafeRegister(_writerCancellationCallbackAction, waiter);
#else
                waiter.CancellationTokenRegistration =
                    cancellationToken.Register(WriterCancellationCallback, waiter, useSynchronizationContext: false);
#endif
            }
            else
            {
                Debug.Assert(waiter.CancellationTokenRegistration == default);
            }

            _waitingWriters.Enqueue(waiter);
            return new ValueTask<Releaser>(waiter, waiter.Version);
        }
    }

    /// <summary>
    /// Asynchronously upgrades to a writer lock.
    /// </summary>
    /// <remarks>
    /// Only a reader holding an upgradeable reader lock can call this method to upgrade to a writer lock.
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token used to cancel the wait.</param>
    /// <returns>A <see cref="ValueTask{Releaser}"/> that completes when the writer lock is acquired.</returns>
    private ValueTask<Releaser> UpgradeToWriterLockAsync(CancellationToken cancellationToken = default)
    {
        // no fast path because the upgrade always transitions from a contested state

        lock (_mutex)
        {
            // upgrade only if only the upgradeable reader is active
            if (Interlocked.CompareExchange(ref _status, (int)LockState.UpgradedWriter, (int)LockState.UpgradeableReader) == (int)LockState.UpgradeableReader)
            {
                return new ValueTask<Releaser>(new Releaser(this, Releaser.ReleaserType.UpgradedWriter));
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return new ValueTask<Releaser>(Task.FromCanceled<Releaser>(cancellationToken));
            }

            if (!_localUpgradedWriterWaiter.TryGetValueTaskSource(out ManualResetValueTaskSource<Releaser> waiter))
            {
                waiter = _pool.GetPooledWaiter(this);
            }
            waiter.RunContinuationsAsynchronously = _runContinuationAsynchronously;
            waiter.CancellationToken = cancellationToken;

            if (cancellationToken.CanBeCanceled)
            {
#if NET6_0_OR_GREATER
                waiter.CancellationTokenRegistration =
                    cancellationToken.UnsafeRegister(_upgradedWriterCancellationCallbackAction, waiter);
#else
                waiter.CancellationTokenRegistration =
                    cancellationToken.Register(UpgradedWriterCancellationCallback, waiter, useSynchronizationContext: false);
#endif
            }
            else
            {
                Debug.Assert(waiter.CancellationTokenRegistration == default);
            }

            _waitingUpgradedWriters.Enqueue(waiter);
            return new ValueTask<Releaser>(waiter, waiter.Version);
        }
    }

    internal bool InternalReaderWaiterInUse => _localReaderWaiter.InUse;

    internal bool InternalUpgradeableReaderWaiterInUse => _localUpgradeableReaderWaiter.InUse;

    internal bool InternalUpgradedWriterWaiterInUse => _localUpgradedWriterWaiter.InUse;

    internal bool InternalWriterWaiterInUse => _localWriterWaiter.InUse;

    private void ReleaseReaderLock()
    {
        ManualResetValueTaskSource<Releaser>? toWake = null;
        Releaser releaser = default;

        lock (_mutex)
        {
            Debug.Assert(_status >= (int)LockState.Reader, "Reader lock should be held.");

            // A reader or writer could steal the status here if we first transition to uncontested state.
            // Check first if there is a waiting writer or upgraded writer and directly transition to
            // a writer lock.
            if (_waitingUpgradedWriters.Count > 0)
            {
                if (Interlocked.CompareExchange(ref _status, (int)LockState.UpgradedWriter, (int)LockState.UpgradeableReader + 1) == ((int)LockState.UpgradeableReader + 1) ||
                    Interlocked.CompareExchange(ref _status, (int)LockState.UpgradedWriterWithoutReader, (int)LockState.Reader) == ((int)LockState.Reader))
                {
                    toWake = _waitingUpgradedWriters.Dequeue();
                    releaser = new Releaser(this, Releaser.ReleaserType.UpgradedWriter);
                }
            }

            // if there were upgraded writers, the lock needs to process them first, hence only check in else case
            else if (_waitingWriters.Count > 0)
            {
                if (Interlocked.CompareExchange(ref _status, (int)LockState.Writer, (int)LockState.Reader) == (int)LockState.Reader)
                {
                    toWake = _waitingWriters.Dequeue();
                    releaser = new Releaser(this, Releaser.ReleaserType.Writer);
                }
            }

            // activate a waiting reader
            else if (_waitingReaders.Count > 0)
            {
                toWake = _waitingReaders.Dequeue();
                releaser = new Releaser(this, Releaser.ReleaserType.Reader);
            }

            if (toWake is null)
            {
                int status = Interlocked.Decrement(ref _status);
                Debug.Assert(status >= (int)LockState.Uncontested, "Reader lock should be held.");
            }
        }

        toWake?.SetResult(releaser);
    }

    private void ReleaseUpgradeableReaderLock()
    {
        ManualResetValueTaskSource<Releaser>? toWake = null;
        Releaser releaser = default;

        lock (_mutex)
        {
            if (_status == (int)LockState.UpgradedWriter)
            {
                Interlocked.Exchange(ref _status, (int)LockState.UpgradedWriterWithoutReader);
                return;
            }

            Debug.Assert(_status >= (int)LockState.UpgradeableReader, "Upgradeable reader lock should be held.");

            // a reader or writer could steal the status here, check first if there is a waiting
            // writer and transition directly to writer lock
            if (_waitingUpgradedWriters.Count > 0)
            {
                if (Interlocked.CompareExchange(ref _status, (int)LockState.UpgradedWriterWithoutReader, (int)LockState.UpgradeableReader) == ((int)LockState.UpgradeableReader))
                {
                    toWake = _waitingUpgradedWriters.Dequeue();
                    releaser = new Releaser(this, Releaser.ReleaserType.UpgradedWriter);
                }
                else
                {
                    // intentionally no action in this case, let the state transition happen
                    // since there are still upgraded writers waiting, no (upgradeable) reader can be
                    // activated until all upgraded writers are served
                }
            }

            // if there were upgraded writers, the lock needs to process them first, hence only check in else case
            else if (_waitingWriters.Count > 0)
            {
                if (Interlocked.CompareExchange(ref _status, (int)LockState.Writer, (int)LockState.UpgradeableReader) == (int)LockState.UpgradeableReader)
                {
                    toWake = _waitingWriters.Dequeue();
                    releaser = new Releaser(this, Releaser.ReleaserType.Writer);
                }
            }

            else if (_waitingUpgradeableReaders.Count > 0)
            {
                toWake = _waitingUpgradeableReaders.Dequeue();
                releaser = new Releaser(this, Releaser.ReleaserType.UpgradeableReader);
            }

            else if (_waitingReaders.Count > 0)
            {
                toWake = _waitingReaders.Dequeue();
                releaser = new Releaser(this, Releaser.ReleaserType.Reader);
                int status = Interlocked.Add(ref _status, 1 - (int)LockState.UpgradeableReader);
                Debug.Assert(status >= 0, "Upgradeable Reader lock should be held.");
            }

            if (toWake is null)
            {
                int status = Interlocked.Add(ref _status, -(int)LockState.UpgradeableReader);
                Debug.Assert(status >= 0, "Upgradeable Reader lock should be held.");
            }
        }

        toWake?.SetResult(releaser);
    }

    private void ReleaseWriterLock()
    {
        ManualResetValueTaskSource<Releaser>? readerChain = null;
        ManualResetValueTaskSource<Releaser>? toWake = null;
        Releaser releaser = default;
        int readerCount = 0;

        lock (_mutex)
        {
            Debug.Assert(_status == (int)LockState.Writer, "Writer lock should be held.");

            if (_waitingWriters.Count > 0)
            {
                toWake = _waitingWriters.Dequeue();
                releaser = new Releaser(this, Releaser.ReleaserType.Writer);
            }
            else
            {
                int newStatus = 0;

                if (_waitingUpgradeableReaders.Count > 0)
                {
                    toWake = _waitingUpgradeableReaders.Dequeue();
                    releaser = new Releaser(this, Releaser.ReleaserType.UpgradeableReader);
                    newStatus = (int)LockState.UpgradeableReader;
                }

                if (_waitingReaders.Count > 0)
                {
                    readerChain = _waitingReaders.DetachUpTo(MaxReaderCount, out readerCount);
                    newStatus += readerCount;
                }

                Interlocked.Exchange(ref _status, newStatus);
            }
        }

        toWake?.SetResult(releaser);
        readerChain?.SetChainResult(new Releaser(this, Releaser.ReleaserType.Reader));
    }

    private void ReleaseUpgradedWriterLock()
    {
        ManualResetValueTaskSource<Releaser>? readerChain = null;
        ManualResetValueTaskSource<Releaser>? toWake = null;
        Releaser releaser = default;

        lock (_mutex)
        {
            Debug.Assert(_status is
                ((int)LockState.UpgradedWriter) or
                ((int)LockState.UpgradedWriterWithoutReader),
                "Upgraded writer lock should be held.");

            // another instance of an upgraded writer might be waiting
            if (_waitingUpgradedWriters.Count > 0)
            {
                toWake = _waitingUpgradedWriters.Dequeue();
                releaser = new Releaser(this, Releaser.ReleaserType.UpgradedWriter);
            }
            else
            {
                // Only wake up waiting readers when no writers are waiting
                int readerCount = 0;
                if (_waitingWriters.Count == 0)
                {
                    if (_waitingReaders.Count > 0)
                    {
                        readerChain = _waitingReaders.DetachUpTo(MaxReaderCount, out readerCount);
                    }

                    if (_status == (int)LockState.UpgradedWriterWithoutReader)
                    {
                        if (_waitingUpgradeableReaders.Count > 0)
                        {
                            toWake = _waitingUpgradeableReaders.Dequeue();
                            releaser = new Releaser(this, Releaser.ReleaserType.UpgradeableReader);
                            readerCount += (int)LockState.UpgradeableReader;
                        }
                    }
                    else
                    {
                        readerCount += (int)LockState.UpgradeableReader;
                    }
                }
                else if (_status == (int)LockState.UpgradedWriterWithoutReader)
                {
                    toWake = _waitingWriters.Dequeue();
                    releaser = new Releaser(this, Releaser.ReleaserType.Writer);
                    readerCount = (int)LockState.Writer;
                }
                else
                {
                    readerCount = (int)LockState.UpgradeableReader;
                }

                Interlocked.Exchange(ref _status, readerCount);
            }
        }

        toWake?.SetResult(releaser);
        readerChain?.SetChainResult(new Releaser(this, Releaser.ReleaserType.Reader));
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _readerCancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<Releaser>)state!;
        var context = (AsyncReaderWriterLock)waiter.Owner!;
        context.ReaderCancellationCallback(waiter);
    };

    private void ReaderCancellationCallback(ManualResetValueTaskSource<Releaser> waiter)
    {
#else
    private void ReaderCancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<Releaser> waiter)
        {
            return;
        }
#endif

        ManualResetValueTaskSource<Releaser>? toCancel = null;
        lock (_mutex)
        {
            if (_waitingReaders.Remove(waiter))
            {
                toCancel = waiter;
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<Releaser>(waiter.CancellationToken)));
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _upgradeableReaderCancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<Releaser>)state!;
        var context = (AsyncReaderWriterLock)waiter.Owner!;
        context.UpgradeableReaderCancellationCallback(waiter);
    };

    private void UpgradeableReaderCancellationCallback(ManualResetValueTaskSource<Releaser> waiter)
    {
#else
    private void UpgradeableReaderCancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<Releaser> waiter)
        {
            return;
        }
#endif

        ManualResetValueTaskSource<Releaser>? toCancel = null;
        lock (_mutex)
        {
            if (_waitingUpgradeableReaders.Remove(waiter))
            {
                toCancel = waiter;
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<Releaser>(waiter.CancellationToken)));
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _writerCancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<Releaser>)state!;
        var context = (AsyncReaderWriterLock)waiter.Owner!;
        context.WriterCancellationCallback(waiter);
    };

    private void WriterCancellationCallback(ManualResetValueTaskSource<Releaser> waiter)
    {
#else
    private void WriterCancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<Releaser> waiter)
        {
            return;
        }
#endif

        ManualResetValueTaskSource<Releaser>? toCancel = null;
        lock (_mutex)
        {
            if (_waitingWriters.Remove(waiter))
            {
                toCancel = waiter;
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<Releaser>(waiter.CancellationToken)));
    }

#if NET6_0_OR_GREATER
    private static readonly Action<object?, CancellationToken> _upgradedWriterCancellationCallbackAction = static (state, ct) => {
        var waiter = (ManualResetValueTaskSource<Releaser>)state!;
        var context = (AsyncReaderWriterLock)waiter.Owner!;
        context.UpgradedWriterCancellationCallback(waiter);
    };

    private void UpgradedWriterCancellationCallback(ManualResetValueTaskSource<Releaser> waiter)
    {
#else
    private void UpgradedWriterCancellationCallback(object? state)
    {
        if (state is not ManualResetValueTaskSource<Releaser> waiter)
        {
            return;
        }
#endif

        ManualResetValueTaskSource<Releaser>? toCancel = null;
        lock (_mutex)
        {
            if (_waitingUpgradedWriters.Remove(waiter))
            {
                toCancel = waiter;
            }
        }

        toCancel?.SetException(new TaskCanceledException(Task.FromCanceled<Releaser>(waiter.CancellationToken)));
    }
}
