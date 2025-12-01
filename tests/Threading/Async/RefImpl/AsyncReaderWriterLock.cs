// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1815 // Override equals and operator equals on value types
#pragma warning disable CA1724 // Type names shuld not match namespaces

namespace Threading.Tests.Async.RefImpl;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// An async reader writer lock reference implementation based on
/// https://devblogs.microsoft.com/dotnet/building-async-coordination-primitives-part-7-asyncreaderwriterlock/.
/// </summary>
/// <remarks>
/// A reference implementation that uses <see cref="TaskCompletionSource{Releaser}"/> and Task.
/// </remarks>
public class AsyncReaderWriterLock
{
    private readonly Task<Releaser> _readerReleaser;
    private readonly Task<Releaser> _writerReleaser;
    private readonly Queue<TaskCompletionSource<Releaser>> _waitingWriters;
    private TaskCompletionSource<Releaser> _waitingReader;
    private int _readersWaiting;
    private int _status;

    public readonly struct Releaser : IDisposable, IAsyncDisposable
    {
        private readonly AsyncReaderWriterLock _toRelease;
        private readonly bool _writer;

        internal Releaser(AsyncReaderWriterLock toRelease, bool writer)
        {
            _toRelease = toRelease;
            _writer = writer;
        }

        public readonly void Dispose()
        {
            if (_toRelease != null)
            {
                if (_writer)
                {
                    _toRelease.WriterRelease();
                }
                else
                {
                    _toRelease.ReaderRelease();
                }
            }
        }

        public ValueTask DisposeAsync()
        {
            Dispose();
            return default;
        }
    }

    public AsyncReaderWriterLock()
    {
        _waitingWriters = new Queue<TaskCompletionSource<Releaser>>();
        _waitingReader = new TaskCompletionSource<Releaser>();
        _readerReleaser = Task.FromResult(new Releaser(this, false));
        _writerReleaser = Task.FromResult(new Releaser(this, true));
    }

    public Task<Releaser> ReaderLockAsync()
    {
        lock (_waitingWriters)
        {
            if (_status >= 0 && _waitingWriters.Count == 0)
            {
                _status++;
                return _readerReleaser;
            }
            else
            {
                _readersWaiting++;
                return _waitingReader.Task.ContinueWith(t => t.Result, TaskScheduler.Current);
            }
        }
    }

    public Task<Releaser> WriterLockAsync()
    {
        lock (_waitingWriters)
        {
            if (_status == 0)
            {
                _status = -1;
                return _writerReleaser;
            }
            else
            {
                var waiter = new TaskCompletionSource<Releaser>();
                _waitingWriters.Enqueue(waiter);
                return waiter.Task;
            }
        }
    }

    private void ReaderRelease()
    {
        TaskCompletionSource<Releaser>? toWake = null;

        lock (_waitingWriters)
        {
            _status--;
            if (_status == 0 && _waitingWriters.Count > 0)
            {
                _status = -1;
                toWake = _waitingWriters.Dequeue();
            }
        }

        toWake?.SetResult(new Releaser(this, true));
    }

    private void WriterRelease()
    {
        TaskCompletionSource<Releaser>? toWake = null;
        bool toWakeIsWriter = false;

        lock (_waitingWriters)
        {
            if (_waitingWriters.Count > 0)
            {
                toWake = _waitingWriters.Dequeue();
                toWakeIsWriter = true;
            }
            else if (_readersWaiting > 0)
            {
                toWake = _waitingReader;
                _status = _readersWaiting;
                _readersWaiting = 0;
                _waitingReader = new TaskCompletionSource<Releaser>();
            }
            else
            {
                _status = 0;
            }
        }

        toWake?.SetResult(new Releaser(this, toWakeIsWriter));
    }
}
