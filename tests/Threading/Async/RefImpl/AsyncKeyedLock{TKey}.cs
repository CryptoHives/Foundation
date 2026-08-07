// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1034 // Nested types should not be visible
#pragma warning disable CA1815 // Override equals and operator equals on value types
#pragma warning disable CA1724 // Type names should not match namespaces
#pragma warning disable CA1001 // SemaphoreSlim leaks are acceptable for this process-lifetime benchmark reference implementation

namespace Threading.Tests.Async.RefImpl;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// A keyed async lock based on the well-known "AsyncDuplicateLock" pattern popularized by
/// Stephen Cleary's original StackOverflow answer and Theodor Zoulias's refinements
/// (https://stackoverflow.com/questions/31138179/asynchronous-locking-based-on-a-key).
/// </summary>
/// <remarks>
/// A reference implementation that uses <see cref="SemaphoreSlim"/> per key plus a
/// <see cref="ConcurrentDictionary{TKey, TValue}"/> with manual ref-counting for cleanup -
/// the pattern most blog posts and StackOverflow answers on this topic converge on. Out of
/// contest: no timeout support, no pooling, and the ref-count decrement/removal below isn't
/// fully race-free under extreme contention (the same caveat that pattern's public writeups
/// carry), which is exactly why this is the naive baseline rather than the library's own design.
/// </remarks>
public class AsyncKeyedLock<TKey> where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, RefCountedSemaphore> _semaphores = new();

    internal sealed class RefCountedSemaphore
    {
        public readonly SemaphoreSlim Semaphore = new(1, 1);
        public int RefCount = 1;
    }

    public readonly struct Releaser : IDisposable
    {
        private readonly AsyncKeyedLock<TKey> _owner;
        private readonly TKey _key;
        private readonly RefCountedSemaphore _entry;

        internal Releaser(AsyncKeyedLock<TKey> owner, TKey key, RefCountedSemaphore entry)
        {
            _owner = owner;
            _key = key;
            _entry = entry;
        }

        public void Dispose()
        {
            _entry.Semaphore.Release();
            if (Interlocked.Decrement(ref _entry.RefCount) == 0)
            {
                ((ICollection<KeyValuePair<TKey, RefCountedSemaphore>>)_owner._semaphores).Remove(new(_key, _entry));
            }
        }
    }

    public async Task<Releaser> LockAsync(TKey key)
    {
        RefCountedSemaphore entry = _semaphores.AddOrUpdate(
            key,
            _ => new RefCountedSemaphore(),
            (_, existing) => {
                Interlocked.Increment(ref existing.RefCount);
                return existing;
            });

        await entry.Semaphore.WaitAsync().ConfigureAwait(false);
        return new Releaser(this, key, entry);
    }
}
