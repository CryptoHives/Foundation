// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using NUnit.Framework;
using System;
using System.Buffers;
using System.Linq;

/// <summary>
/// Covers the reference-type <see cref="ISequenceOwner{T}"/> implementations: the null-object
/// sentinel and the adapter over <see cref="ISegmentOwner{T}"/>. The struct implementation that the
/// producers hand out is covered by <c>SequenceLeaseTests</c>.
/// </summary>
[Parallelizable(ParallelScope.All)]
public class SequenceOwnerTests
{
    private static byte[] Payload(int length, int seed = 1)
    {
        var data = new byte[length];
        new Random(seed).NextBytes(data);
        return data;
    }

    /// <summary>Tracks whether the owner it wraps was disposed, to prove ownership really transfers.</summary>
    private sealed class TrackingSegmentOwner : ISegmentOwner<byte>
    {
        private readonly ISegmentOwner<byte> _inner;

        public TrackingSegmentOwner(ISegmentOwner<byte> inner) => _inner = inner;

        public bool Disposed { get; private set; }

        public ArraySegment<byte> Segment => _inner.Segment;

        public byte this[int i]
        {
            get => _inner[i];
            set => _inner[i] = value;
        }

        public bool TrySetSegment(int offset, int length) => _inner.TrySetSegment(offset, length);

        public void Dispose()
        {
            Disposed = true;
            _inner.Dispose();
        }
    }

    // ------------------------------------------------------------ EmptySequence

    [Test]
    public void EmptySequenceIsEmptyAndSafeToDisposeRepeatedly()
    {
        ISequenceOwner<byte> owner = EmptySequence<byte>.Instance;

        owner.Dispose();
        owner.Dispose();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(owner.IsEmpty, Is.True);
            Assert.That(owner.Length, Is.Zero);
            Assert.That(owner.Sequence.IsEmpty, Is.True);
        }
    }

    [Test]
    public void EmptySequenceInstanceIsShared()
    {
        // The sentinel must not allocate per call.
        ISequenceOwner<byte> first = EmptySequence<byte>.Instance;
        ISequenceOwner<byte> second = EmptySequence<byte>.Instance;

        Assert.That(first, Is.SameAs(second));
    }

    // ---------------------------------------------------------- SegmentSequence

    [Test]
    public void SegmentSequenceExposesAPooledSegmentAsASequence()
    {
        ISegmentOwner<byte> segment = PooledSegment<byte>.Rent(128);
        for (int i = 0; i < 128; i++)
        {
            segment[i] = (byte)i;
        }

        using ISequenceOwner<byte> owner = SegmentSequence<byte>.Create(segment);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(owner.Length, Is.EqualTo(128));
            Assert.That(owner.IsEmpty, Is.False);
            Assert.That(owner.Sequence.ToArray(), Is.EqualTo(Enumerable.Range(0, 128).Select(i => (byte)i).ToArray()));
        }
    }

    [Test]
    public void SegmentSequenceExposesAnAllocatedSegmentAsASequence()
    {
        byte[] data = Payload(64);

        // CA2000 does not model the ownership transfer into SegmentSequence; disposing the wrapper
        // disposes the segment owner, which the test below asserts directly.
#pragma warning disable CA2000
        using ISequenceOwner<byte> owner = SegmentSequence<byte>.Create(AllocatedSegment<byte>.Create(data));
#pragma warning restore CA2000

        Assert.That(owner.Sequence.ToArray(), Is.EqualTo(data));
    }

    [Test]
    public void SegmentSequenceOverAnEmptySegmentIsEmpty()
    {
        using ISequenceOwner<byte> owner = SegmentSequence<byte>.Create(EmptySegment<byte>.Instance);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(owner.IsEmpty, Is.True);
            Assert.That(owner.Length, Is.Zero);
            Assert.That(owner.Sequence.IsEmpty, Is.True);
        }
    }

    [Test]
    public void DisposingASegmentSequenceDisposesTheAdoptedOwner()
    {
        // Ownership transfers into the wrapper, which is disposed below; CA2000 cannot see that.
#pragma warning disable CA2000
        var tracking = new TrackingSegmentOwner(PooledSegment<byte>.Rent(32));
#pragma warning restore CA2000
        ISequenceOwner<byte> owner = SegmentSequence<byte>.Create(tracking);

        Assert.That(tracking.Disposed, Is.False);

        owner.Dispose();
        owner.Dispose();

        Assert.That(tracking.Disposed, Is.True, "ownership must transfer into the sequence owner");
    }

    [Test]
    public void SegmentSequenceReflectsARewindowOfTheInnerOwner()
    {
        ISegmentOwner<byte> segment = PooledSegment<byte>.Rent(128);
        for (int i = 0; i < 128; i++)
        {
            segment[i] = (byte)i;
        }

        using ISequenceOwner<byte> owner = SegmentSequence<byte>.Create(segment);
        Assert.That(owner.Length, Is.EqualTo(128));

        Assert.That(segment.TrySetSegment(16, 32), Is.True);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(owner.Length, Is.EqualTo(32));
            Assert.That(owner.Sequence.ToArray(), Is.EqualTo(Enumerable.Range(16, 32).Select(i => (byte)i).ToArray()));
        }
    }

    [Test]
    public void SegmentSequenceRejectsANullOwner()
    {
        Assert.That(() => SegmentSequence<byte>.Create(null!), Throws.TypeOf<ArgumentNullException>());
    }

}
