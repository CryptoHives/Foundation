// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using NUnit.Framework;
using System;
using System.Buffers;
using System.Collections.Generic;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Verifies that hashing a <see cref="ReadOnlySequence{T}"/> produces the same digest as
/// hashing the equivalent contiguous span, for every managed implementation.
/// </summary>
/// <remarks>
/// <para>
/// Two distinct code paths are covered. A multi-segment sequence walks
/// <c>HashAlgorithm.AppendData(in ReadOnlySequence{byte})</c>, which feeds each segment to
/// <c>HashCore</c> separately; a single-segment one is routed to <c>TryComputeHash</c> so it
/// reaches whatever one-shot fast path the algorithm overrides that with. Both must agree
/// with the span overload, and neither is exercised by <c>ChunkedHashTests</c>, which drives
/// <c>AppendData(ReadOnlySpan{byte})</c> instead.
/// </para>
/// <para>
/// Segment sizes are chosen relative to each algorithm's own <c>BlockSize</c>, because a
/// segment boundary landing exactly on — or one byte either side of — a block boundary is
/// where a segment-loop or carry-over bug would hide.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SequenceHashTests
{
    /// <summary>
    /// Segment-size strategies, expressed relative to the algorithm's block size.
    /// </summary>
    private enum SegmentStrategy
    {
        /// <summary>One byte per segment — maximum number of segment transitions.</summary>
        SingleByte,

        /// <summary>Segments exactly one block long — every boundary is a block boundary.</summary>
        ExactBlock,

        /// <summary>One byte short of a block — boundaries straddle, drifting by one each time.</summary>
        BlockMinusOne,

        /// <summary>One byte past a block — the mirror of <see cref="BlockMinusOne"/>.</summary>
        BlockPlusOne,

        /// <summary>Two blocks per segment — exercises multi-block segments.</summary>
        DoubleBlock,

        /// <summary>Random sizes between 1 and twice the block size.</summary>
        Random,

        /// <summary>The whole buffer as one segment — the single-segment fast path.</summary>
        WholeBuffer,
    }

    /// <summary>
    /// Listed explicitly rather than via <c>Enum.GetValues</c>, which is not AOT-safe.
    /// </summary>
    private static readonly SegmentStrategy[] Strategies =
    [
        SegmentStrategy.SingleByte,
        SegmentStrategy.ExactBlock,
        SegmentStrategy.BlockMinusOne,
        SegmentStrategy.BlockPlusOne,
        SegmentStrategy.DoubleBlock,
        SegmentStrategy.Random,
        SegmentStrategy.WholeBuffer,
    ];

    private static readonly int[] InputSizes =
        [0, 1, 31, 63, 64, 65, 127, 128, 129, 255, 256, 1023, 1024, 1025, 4096];

    /// <summary>
    /// The digest of a sequence must equal the digest of the same bytes as one span,
    /// for every segmentation and every input size.
    /// </summary>
    /// <param name="factory">The hash algorithm factory under test.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void SequenceHashMatchesSpanHash(HashAlgorithmFactory factory)
    {
        int blockSize = GetBlockSize(factory);
        var dataRng = new Random(20260913);

        foreach (int inputSize in InputSizes)
        {
            byte[] input = new byte[inputSize];
            if (inputSize > 0)
            {
                dataRng.NextBytes(input);
            }

            byte[] expected;
            using (var oneShot = (CH.Hash.HashAlgorithm)factory.Create())
            {
                expected = oneShot.ComputeHash(input);
            }

            foreach (SegmentStrategy strategy in Strategies)
            {
                // Fixed seed per case so a failure reproduces exactly.
                ReadOnlySequence<byte> sequence =
                    BuildSequence(input, blockSize, strategy, new Random((inputSize * 31) + (int)strategy));

                Assert.That(
                    sequence.Length,
                    Is.EqualTo(inputSize),
                    $"{factory.Name}/{strategy}/{inputSize}: sequence did not preserve the input length");

                using var algo = (CH.Hash.HashAlgorithm)factory.Create();
                algo.AppendData(sequence);

                byte[] actual = new byte[algo.HashSize / 8];
                Assert.That(
                    algo.TryGetHashAndReset(actual, out int bytesWritten),
                    Is.True,
                    $"{factory.Name}/{strategy}/{inputSize}: TryGetHashAndReset returned false");
                Assert.That(bytesWritten, Is.EqualTo(expected.Length));
                Assert.That(
                    actual,
                    Is.EqualTo(expected),
                    $"{factory.Name}/{strategy}/{inputSize}: sequence digest differs from span digest");
            }
        }
    }

    /// <summary>
    /// A single-segment sequence is just a span, and must reach the same result through the
    /// one-shot path <c>TryComputeHash</c> dispatches to. The instance must also be left
    /// reusable, since the pooled static entry points rent and return.
    /// </summary>
    /// <param name="factory">The hash algorithm factory under test.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void SingleSegmentSequenceMatchesSpanAndLeavesInstanceReusable(HashAlgorithmFactory factory)
    {
        var rng = new Random(4242);
        byte[] input = new byte[2053];
        rng.NextBytes(input);

        using var algo = (CH.Hash.HashAlgorithm)factory.Create();
        byte[] expected = new byte[algo.HashSize / 8];
        Assert.That(algo.TryComputeHash(input, expected, out _), Is.True);

        // Same bytes, wrapped as a one-segment sequence.
        var sequence = new ReadOnlySequence<byte>(input);
        Assert.That(sequence.IsSingleSegment, Is.True, "test precondition");

        byte[] actual = new byte[algo.HashSize / 8];
        algo.AppendData(sequence);
        Assert.That(algo.TryGetHashAndReset(actual, out _), Is.True);
        Assert.That(actual, Is.EqualTo(expected), $"{factory.Name}: single-segment sequence differs from span");

        // Reuse without an explicit Initialize, twice, to catch state left behind.
        for (int i = 0; i < 2; i++)
        {
            byte[] again = new byte[algo.HashSize / 8];
            Assert.That(algo.TryComputeHash(input, again, out _), Is.True);
            Assert.That(again, Is.EqualTo(expected), $"{factory.Name}: instance not reusable after sequence hash");
        }
    }

    /// <summary>
    /// An empty sequence and an empty span must agree, including the
    /// <see cref="ReadOnlySequence{T}.Empty"/> singleton, which reports a single segment.
    /// </summary>
    /// <param name="factory">The hash algorithm factory under test.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void EmptySequenceMatchesEmptySpan(HashAlgorithmFactory factory)
    {
        using var algo = (CH.Hash.HashAlgorithm)factory.Create();
        byte[] expected = new byte[algo.HashSize / 8];
        Assert.That(algo.TryComputeHash(ReadOnlySpan<byte>.Empty, expected, out _), Is.True);

        byte[] actual = new byte[algo.HashSize / 8];
        algo.AppendData(ReadOnlySequence<byte>.Empty);
        Assert.That(algo.TryGetHashAndReset(actual, out _), Is.True);
        Assert.That(actual, Is.EqualTo(expected), $"{factory.Name}: empty sequence differs from empty span");
    }

    private static int GetBlockSize(HashAlgorithmFactory factory)
    {
        using var algo = (CH.Hash.HashAlgorithm)factory.Create();
        return algo.BlockSize;
    }

    private static ReadOnlySequence<byte> BuildSequence(
        byte[] data, int blockSize, SegmentStrategy strategy, Random rng)
    {
        if (data.Length == 0)
        {
            return ReadOnlySequence<byte>.Empty;
        }

        if (strategy == SegmentStrategy.WholeBuffer)
        {
            return new ReadOnlySequence<byte>(data);
        }

        List<int> sizes = [];
        int remaining = data.Length;
        while (remaining > 0)
        {
            int size = strategy switch
            {
                SegmentStrategy.SingleByte => 1,
                SegmentStrategy.ExactBlock => blockSize,
                SegmentStrategy.BlockMinusOne => Math.Max(1, blockSize - 1),
                SegmentStrategy.BlockPlusOne => blockSize + 1,
                SegmentStrategy.DoubleBlock => blockSize * 2,
                SegmentStrategy.Random => rng.Next(1, (blockSize * 2) + 1),
                _ => throw new ArgumentOutOfRangeException(nameof(strategy)),
            };

            size = Math.Min(size, remaining);
            sizes.Add(size);
            remaining -= size;
        }

        BufferSegment? first = null;
        BufferSegment? last = null;
        int offset = 0;
        foreach (int size in sizes)
        {
            var segment = new BufferSegment(data.AsMemory(offset, size));
            if (first is null)
            {
                first = last = segment;
            }
            else
            {
                last = last!.Append(segment);
            }

            offset += size;
        }

        return new ReadOnlySequence<byte>(first!, 0, last!, last!.Memory.Length);
    }

    private sealed class BufferSegment : ReadOnlySequenceSegment<byte>
    {
        public BufferSegment(ReadOnlyMemory<byte> memory) => Memory = memory;

        public BufferSegment Append(BufferSegment next)
        {
            next.RunningIndex = RunningIndex + Memory.Length;
            Next = next;
            return next;
        }
    }
}
