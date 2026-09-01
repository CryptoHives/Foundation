// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Buffers;

using CryptoHives.Foundation.Memory.Buffers;
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Covers the chunk budgets being expressed in <b>bytes</b> rather than elements.
/// </summary>
/// <remarks>
/// The point of the byte budget is that a chunk stays off the large object heap whatever
/// <typeparamref name="T"/> is. Element counts do not do that: 65,536 elements is 64 KiB of
/// <see cref="byte"/> but 512 KiB of <see cref="long"/>, and an object reaches the LOH at 85,000
/// bytes. These tests pin the budget against a spread of element widths, including one that is not a
/// power of two, where <see cref="System.Buffers.ArrayPool{T}"/>'s round-up would otherwise push the
/// array over the line.
/// </remarks>
[Parallelizable(ParallelScope.All)]
public class ArrayPoolBufferWriterBudgetTests
{
    /// <summary>The threshold at which the runtime allocates on the large object heap.</summary>
    private const int LargeObjectHeapThreshold = 85_000;

    /// <summary>A deliberately awkward width: 12 bytes does not divide 64 KiB into a power of two.</summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct Awkward
    {
        public int A;
        public int B;
        public int C;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct Wide
    {
        public Guid A;
        public Guid B;
        public Guid C;
        public Guid D;
    }

    /// <summary>Rents the largest chunk a writer will hand out, in elements.</summary>
    private static int LargestChunk<T>()
    {
        using var writer = new ArrayPoolBufferWriter<T>();

        // Ramp to the ceiling: each new chunk doubles until it stops growing.
        int largest = 0;
        for (int i = 0; i < 64; i++)
        {
            int span = writer.GetSpan(1).Length;
            writer.Advance(span);
            if (span == largest)
            {
                break;
            }

            largest = span;
        }

        return largest;
    }

    [Test]
    public void ByteIsUnchangedByTheMoveToByteBudgets()
    {
        // For a one-byte element the two units coincide, so the historical numbers must still hold.
        using (Assert.EnterMultipleScope())
        {
            Assert.That(ArrayPoolBufferWriter<byte>.DefaultChunkBytes, Is.EqualTo(256));
            Assert.That(ArrayPoolBufferWriter<byte>.MaxChunkBytes, Is.EqualTo(65_536));
        }

        using var writer = new ArrayPoolBufferWriter<byte>();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(writer.GetSpan(1).Length, Is.EqualTo(256), "first chunk");
            Assert.That(LargestChunk<byte>(), Is.EqualTo(65_536), "ceiling");
        }
    }

    [Test]
    public void TheFirstChunkHonoursTheByteBudgetForEveryWidth()
    {
        AssertFirstChunkWithinBudget<byte>();
        AssertFirstChunkWithinBudget<short>();
        AssertFirstChunkWithinBudget<int>();
        AssertFirstChunkWithinBudget<long>();
        AssertFirstChunkWithinBudget<Guid>();
        AssertFirstChunkWithinBudget<Awkward>();
        AssertFirstChunkWithinBudget<string>();

        static void AssertFirstChunkWithinBudget<T>()
        {
            using var writer = new ArrayPoolBufferWriter<T>();
            long bytes = (long)writer.GetSpan(1).Length * Unsafe.SizeOf<T>();

            Assert.That(bytes, Is.LessThanOrEqualTo(ArrayPoolBufferWriter<T>.DefaultChunkBytes),
                $"first chunk for {typeof(T).Name} ({Unsafe.SizeOf<T>()} B/element)");
        }
    }

    [Test]
    public void NoChunkEverReachesTheLargeObjectHeap()
    {
        // The regression this whole change exists for: as element counts, the default ceiling put
        // long at 512 KiB and a 64-byte struct at 4 MiB, both squarely on the LOH.
        AssertCeilingOffTheLoh<byte>();
        AssertCeilingOffTheLoh<short>();
        AssertCeilingOffTheLoh<int>();
        AssertCeilingOffTheLoh<long>();
        AssertCeilingOffTheLoh<Guid>();
        AssertCeilingOffTheLoh<Awkward>();
        AssertCeilingOffTheLoh<Wide>();
        AssertCeilingOffTheLoh<string>();

        static void AssertCeilingOffTheLoh<T>()
        {
            int elementSize = Unsafe.SizeOf<T>();
            long bytes = (long)LargestChunk<T>() * elementSize;

            using (Assert.EnterMultipleScope())
            {
                Assert.That(bytes, Is.LessThanOrEqualTo(ArrayPoolBufferWriter<T>.MaxChunkBytes),
                    $"{typeof(T).Name} ({elementSize} B/element) exceeded its budget");
                Assert.That(bytes, Is.LessThan(LargeObjectHeapThreshold),
                    $"{typeof(T).Name} ({elementSize} B/element) would land on the LOH");
            }
        }
    }

    /// <summary>
    /// ArrayPool serves a request from a bucket of 16 x 2^n elements, rounding up. An element count
    /// that is not a power of two therefore yields an array larger than the budget allowed — for a
    /// 12-byte element, 64 KiB divides to 5,461, which ArrayPool would satisfy from the 8,192 bucket
    /// at 98,304 bytes. Rounding the count down keeps the array itself inside the budget.
    /// </summary>
    [Test]
    public void ChunkSizesArePowersOfTwoSoTheBucketMatchesTheBudget()
    {
        AssertPowerOfTwo<byte>();
        AssertPowerOfTwo<long>();
        AssertPowerOfTwo<Awkward>();
        AssertPowerOfTwo<Wide>();

        static void AssertPowerOfTwo<T>()
        {
            int largest = LargestChunk<T>();
            Assert.That(largest & (largest - 1), Is.Zero,
                $"{typeof(T).Name} chunk of {largest} elements is not a power of two");
        }
    }

    [Test]
    public void AnElementWiderThanTheStartingBudgetStillGetsAUsableChunk()
    {
        // Wide is 64 bytes, so the 256-byte starting budget divides to 4 — below ArrayPool's smallest
        // bucket. The floor keeps the writer usable rather than handing out a useless sliver.
        using var writer = new ArrayPoolBufferWriter<Wide>();

        Assert.That(writer.GetSpan(1).Length, Is.GreaterThanOrEqualTo(4));
    }

    [Test]
    public void AWideElementGetsFewerElementsThanAByte()
    {
        // The observable consequence of budgeting in bytes: same budget, proportionally fewer of a
        // wider element.
        using var bytes = new ArrayPoolBufferWriter<byte>();
        using var longs = new ArrayPoolBufferWriter<long>();

        Assert.That(longs.GetSpan(1).Length * 8, Is.EqualTo(bytes.GetSpan(1).Length));
    }
}
