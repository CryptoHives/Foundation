// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT
//
// Reference implementation: TheodorZoulias.cs from the AsyncKeyedLock benchmark suite,
// https://github.com/MarkCiliaVincenti/AsyncKeyedLockBenchmarks/blob/master/AsyncKeyedLockBenchmarks/TheodorZoulias.cs
//
//     MIT License - Copyright (c) 2022 Mark Cilia Vincenti
//
// Upstream is in turn Theodor Zoulias's refinement of the "AsyncDuplicateLock" pattern from
// https://stackoverflow.com/questions/31138179/asynchronous-locking-based-on-a-key. It is the
// baseline the AsyncKeyedLock author benchmarks against, which is why it is the one used here.
//
// Ported faithfully - same ValueTask return, same compare-and-swap release loop - with only the two
// changes the test project forces, both documented on the members that carry them: generic over
// TKey rather than keyed by object, and a hand-written equatable struct where upstream uses a
// record struct.
//
// The file lives in the test project, which common.props marks IsPackable=false, so it is never
// published in a NuGet package.

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
/// A keyed async lock ported from <c>TheodorZoulias.cs</c> in the AsyncKeyedLock benchmark suite -
/// Theodor Zoulias's refinement of the "AsyncDuplicateLock" pattern
/// (https://stackoverflow.com/questions/31138179/asynchronous-locking-based-on-a-key).
/// </summary>
/// <remarks>
/// <para>
/// One <see cref="SemaphoreSlim"/> per key in a <see cref="ConcurrentDictionary{TKey, TValue}"/>,
/// with manual reference counting for cleanup - the design most public writeups on this topic
/// converge on, and the baseline the AsyncKeyedLock author measures against. It is out of contest
/// on features: no timeout support, no cancellation support and no pooling.
/// </para>
/// <para>
/// The reference count lives inside an immutable value and is moved only by compare-and-swap
/// (<see cref="ConcurrentDictionary{TKey, TValue}.TryUpdate"/>, or a value-matched removal at the
/// last release), retrying until one of them wins. That loop is the whole point of this variant:
/// it closes the decrement-then-remove race that the simpler <see cref="Interlocked"/> spelling of
/// the same pattern leaves open, so unlike the plainer writeups this baseline is race-free and is
/// not disqualified at high thread counts.
/// </para>
/// <para>
/// Worth remembering when reading its multi-threaded rows: there is no administrative lock here at
/// all. The key map is reached only through <see cref="ConcurrentDictionary{TKey, TValue}"/>
/// operations, never a monitor or a spin lock, so its bookkeeping does not serialize across threads
/// the way an implementation guarding a shared map with one lock does.
/// </para>
/// </remarks>
/// <typeparam name="TKey">The type of key that operations are serialized by.</typeparam>
public class AsyncKeyedLock<TKey> where TKey : notnull
{
    private readonly ConcurrentDictionary<TKey, Entry> _semaphores = new();

    /// <summary>
    /// A semaphore and the number of outstanding claims on it, as one immutable value.
    /// </summary>
    /// <remarks>
    /// Upstream declares this as a <c>readonly record struct</c>. Spelled out by hand here because
    /// a positional record struct generates <c>init</c> accessors, which need an
    /// <c>IsExternalInit</c> polyfill on this project's .NET Framework target, and
    /// <see cref="IEquatable{T}"/> has to be implemented explicitly regardless: <c>TryUpdate</c>
    /// compares with <see cref="EqualityComparer{T}.Default"/>, and a struct without it would fall
    /// back to reflection-based <see cref="ValueType.Equals(object)"/> on the hot release path.
    /// </remarks>
    private readonly struct Entry : IEquatable<Entry>
    {
        public Entry(SemaphoreSlim semaphore, int refCount)
        {
            Semaphore = semaphore;
            RefCount = refCount;
        }

        public SemaphoreSlim Semaphore { get; }

        public int RefCount { get; }

        public Entry WithRefCount(int refCount) => new(Semaphore, refCount);

        public bool Equals(Entry other) =>
            ReferenceEquals(Semaphore, other.Semaphore) && RefCount == other.RefCount;

        public override bool Equals(object? obj) => obj is Entry other && Equals(other);

        public override int GetHashCode() =>
            unchecked((Semaphore?.GetHashCode() ?? 0) * 397 ^ RefCount);
    }

    public readonly struct Releaser : IDisposable
    {
        private readonly AsyncKeyedLock<TKey> _parent;
        private readonly TKey _key;

        internal Releaser(AsyncKeyedLock<TKey> parent, TKey key)
        {
            _parent = parent;
            _key = key;
        }

        public void Dispose() => _parent.Release(_key);
    }

    public async ValueTask<Releaser> LockAsync(TKey key)
    {
        Entry entry = _semaphores.AddOrUpdate(
            key,
            static _ => new Entry(new SemaphoreSlim(1, 1), 1),
            static (_, entry) => entry.WithRefCount(entry.RefCount + 1));

        await entry.Semaphore.WaitAsync().ConfigureAwait(false);
        return new Releaser(this, key);
    }

    private void Release(TKey key)
    {
        Entry entry;
        while (true)
        {
            if (!_semaphores.TryGetValue(key, out entry))
            {
                throw new InvalidOperationException("Key not found.");
            }

            if (entry.RefCount > 1)
            {
                if (_semaphores.TryUpdate(key, entry.WithRefCount(entry.RefCount - 1), entry))
                {
                    break;
                }
            }
            else
            {
                // Upstream calls TryRemove(KeyValuePair), which does not exist on .NET Framework.
                // The ICollection spelling is the same operation - ConcurrentDictionary implements
                // it as a remove that succeeds only when the current value still matches - so the
                // compare-and-swap semantics this loop depends on are preserved on every target.
                if (((ICollection<KeyValuePair<TKey, Entry>>)_semaphores).Remove(
                        new KeyValuePair<TKey, Entry>(key, entry)))
                {
                    break;
                }
            }
        }

        entry.Semaphore.Release();
    }
}
