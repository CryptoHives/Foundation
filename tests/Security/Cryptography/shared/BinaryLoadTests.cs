// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests;

using NUnit.Framework;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Pins <c>BinaryLoad</c>, which assembles a short final block in registers instead of
/// staging it through a zeroed buffer.
/// </summary>
/// <remarks>
/// <para>
/// Three things are checked, and they are not the same thing. The value is checked against
/// a block built the obvious way. The claim that no byte at or past <c>source + length</c>
/// is read is checked two ways: the surroundings are refilled with fresh random bytes
/// between repetitions, so any dependence on them moves the result; and <c>BinaryLoad</c>
/// asserts every read extent against <c>length</c> in its own code, which a Debug test run
/// makes live. Neither makes an over-read fault — a run against packed Release packages
/// has the asserts compiled out and only the invariance check remains.
/// </para>
/// <para>
/// The oracle is a second implementation of the same decomposition over a span sliced to
/// exactly <c>length</c>, using bounds-checked accessors. It agrees on values and shows the
/// decomposition is expressible in bounds; it does not observe what <c>BinaryLoad</c> read.
/// </para>
/// <para>
/// Both byte orders are swept, but the <c>!BitConverter.IsLittleEndian</c> arms of the piece
/// readers stay unreached: .NET ships no big-endian target, so nothing this repo builds for
/// can execute them. What is covered is that the two assemblers agree under
/// <c>ReverseEndianness</c>, which is the property the callers rely on.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public unsafe class BinaryLoadTests
{
    /// <summary>Source offsets swept within the backing array, covering every alignment.</summary>
    private const int MaxOffset = 16;

    /// <summary>How many times each case is re-run with freshly randomized surroundings.</summary>
    private const int Repetitions = 8;

    /// <summary>Trailing slack after the input: 0 places the last byte at the end of the array.</summary>
    private static readonly int[] Trailers = [0, 16];

    [Test]
    public void ReadUInt32LittleEndianPadded_MatchesAZeroPaddedBlock()
    {
        AssertSweep(sizeof(uint), static (backing, offset, length) =>
        {
            uint word = CH.BinaryLoad.ReadUInt32LittleEndianPadded(ref backing.AsSpan(offset).GetPinnableReference(), length);
            var block = new byte[sizeof(uint)];
            BinaryPrimitives.WriteUInt32LittleEndian(block, word);
            return block;
        });
    }

    [Test]
    public void ReadUInt32LittleEndianPadded_PointerOverloadAgrees()
    {
        AssertSweep(sizeof(uint), static (backing, offset, length) =>
        {
            var block = new byte[sizeof(uint)];
            fixed (byte* source = &backing.AsSpan(offset).GetPinnableReference())
            {
                BinaryPrimitives.WriteUInt32LittleEndian(block, CH.BinaryLoad.ReadUInt32LittleEndianPadded(source, length));
            }

            return block;
        });
    }

    [Test]
    public void ReadUInt64LittleEndianPadded_MatchesAZeroPaddedBlock()
    {
        AssertSweep(sizeof(ulong), static (backing, offset, length) =>
        {
            ulong word = CH.BinaryLoad.ReadUInt64LittleEndianPadded(ref backing.AsSpan(offset).GetPinnableReference(), length);
            var block = new byte[sizeof(ulong)];
            BinaryPrimitives.WriteUInt64LittleEndian(block, word);
            return block;
        });
    }

    [Test]
    public void ReadUInt64LittleEndianPadded_PointerOverloadAgrees()
    {
        AssertSweep(sizeof(ulong), static (backing, offset, length) =>
        {
            var block = new byte[sizeof(ulong)];
            fixed (byte* source = &backing.AsSpan(offset).GetPinnableReference())
            {
                BinaryPrimitives.WriteUInt64LittleEndian(block, CH.BinaryLoad.ReadUInt64LittleEndianPadded(source, length));
            }

            return block;
        });
    }

    [Test]
    public void ReadUInt64PairLittleEndianPadded_MatchesAZeroPaddedBlock()
    {
        AssertSweep(2 * sizeof(ulong), static (backing, offset, length) =>
        {
            CH.BinaryLoad.ReadUInt64PairLittleEndianPadded(
                ref backing.AsSpan(offset).GetPinnableReference(), length, out ulong low, out ulong high);
            return Pair(low, high);
        });
    }

    [Test]
    public void ReadUInt64PairLittleEndianPadded_PointerOverloadAgrees()
    {
        AssertSweep(2 * sizeof(ulong), static (backing, offset, length) =>
        {
            ulong low, high;
            fixed (byte* source = &backing.AsSpan(offset).GetPinnableReference())
            {
                CH.BinaryLoad.ReadUInt64PairLittleEndianPadded(source, length, out low, out high);
            }

            return Pair(low, high);
        });
    }

    /// <summary>
    /// The terminator lands at index <c>length</c> and nowhere else, for every length the
    /// <c>10*</c> padding shape allows.
    /// </summary>
    /// <param name="terminator">The sentinel: <c>0x01</c> is Poly1305, <c>0x80</c> is CMAC.</param>
    [Test]
    public void ReadUInt64PairLittleEndianPadded_PlacesTheTerminatorAtLength([Values((byte)0x01, (byte)0x80)] byte terminator)
    {
        const int Width = 2 * sizeof(ulong);
        var rng = new Random(Seed(Width) ^ terminator);

        for (int length = 0; length < Width; length++)
        {
            byte[] backing = Randomized(rng, length);
            byte[] expected = new byte[Width];
            backing.AsSpan(0, length).CopyTo(expected);
            expected[length] = terminator;

            CH.BinaryLoad.ReadUInt64PairLittleEndianPadded(
                ref backing.AsSpan(0).GetPinnableReference(), length, terminator, out ulong low, out ulong high);

            Assert.That(Pair(low, high), Is.EqualTo(expected), $"length {length}, terminator 0x{terminator:X2}");
        }
    }

    [Test]
    public void ReadUInt32BigEndianPadded_MatchesAZeroPaddedBlock()
    {
        AssertSweep(sizeof(uint), static (backing, offset, length) =>
        {
            uint word = CH.BinaryLoad.ReadUInt32BigEndianPadded(ref backing.AsSpan(offset).GetPinnableReference(), length);
            var block = new byte[sizeof(uint)];
            BinaryPrimitives.WriteUInt32BigEndian(block, word);
            return block;
        });
    }

    [Test]
    public void ReadUInt32BigEndianPadded_PointerOverloadAgrees()
    {
        AssertSweep(sizeof(uint), static (backing, offset, length) =>
        {
            var block = new byte[sizeof(uint)];
            fixed (byte* source = &backing.AsSpan(offset).GetPinnableReference())
            {
                BinaryPrimitives.WriteUInt32BigEndian(block, CH.BinaryLoad.ReadUInt32BigEndianPadded(source, length));
            }

            return block;
        });
    }

    [Test]
    public void ReadUInt64BigEndianPadded_MatchesAZeroPaddedBlock()
    {
        AssertSweep(sizeof(ulong), static (backing, offset, length) =>
        {
            ulong word = CH.BinaryLoad.ReadUInt64BigEndianPadded(ref backing.AsSpan(offset).GetPinnableReference(), length);
            var block = new byte[sizeof(ulong)];
            BinaryPrimitives.WriteUInt64BigEndian(block, word);
            return block;
        });
    }

    [Test]
    public void ReadUInt64BigEndianPadded_PointerOverloadAgrees()
    {
        AssertSweep(sizeof(ulong), static (backing, offset, length) =>
        {
            var block = new byte[sizeof(ulong)];
            fixed (byte* source = &backing.AsSpan(offset).GetPinnableReference())
            {
                BinaryPrimitives.WriteUInt64BigEndian(block, CH.BinaryLoad.ReadUInt64BigEndianPadded(source, length));
            }

            return block;
        });
    }

    [Test]
    public void ReadUInt64PairBigEndianPadded_MatchesAZeroPaddedBlock()
    {
        AssertSweep(2 * sizeof(ulong), static (backing, offset, length) =>
        {
            CH.BinaryLoad.ReadUInt64PairBigEndianPadded(
                ref backing.AsSpan(offset).GetPinnableReference(), length, out ulong first, out ulong second);
            return PairBigEndian(first, second);
        });
    }

    [Test]
    public void ReadUInt64PairBigEndianPadded_PointerOverloadAgrees()
    {
        AssertSweep(2 * sizeof(ulong), static (backing, offset, length) =>
        {
            ulong first, second;
            fixed (byte* source = &backing.AsSpan(offset).GetPinnableReference())
            {
                CH.BinaryLoad.ReadUInt64PairBigEndianPadded(source, length, out first, out second);
            }

            return PairBigEndian(first, second);
        });
    }

    /// <summary>
    /// The terminator lands at index <c>length</c> and nowhere else. The big-endian shift
    /// runs the other way, which is the easiest thing here to get wrong.
    /// </summary>
    /// <param name="terminator">The sentinel: <c>0x01</c> is Poly1305, <c>0x80</c> is CMAC.</param>
    [Test]
    public void ReadUInt64PairBigEndianPadded_PlacesTheTerminatorAtLength([Values((byte)0x01, (byte)0x80)] byte terminator)
    {
        const int Width = 2 * sizeof(ulong);
        var rng = new Random(Seed(Width) ^ terminator);

        for (int length = 0; length < Width; length++)
        {
            byte[] backing = Randomized(rng, length);
            byte[] expected = new byte[Width];
            backing.AsSpan(0, length).CopyTo(expected);
            expected[length] = terminator;

            CH.BinaryLoad.ReadUInt64PairBigEndianPadded(
                ref backing.AsSpan(0).GetPinnableReference(), length, terminator, out ulong first, out ulong second);

            Assert.That(PairBigEndian(first, second), Is.EqualTo(expected), $"length {length}, terminator 0x{terminator:X2}");
        }
    }

    /// <summary>
    /// The two assemblers are written out independently, so pin them against each other:
    /// a zero-padded block is the same byte sequence read either way, so the big-endian
    /// word must be the little-endian one reversed for every length.
    /// </summary>
    /// <remarks>
    /// This is the identity that lets <c>GcmCore</c>'s big-endian GHASH tails consume the
    /// same padded block the little-endian callers do.
    /// </remarks>
    [Test]
    public void BigEndianIsLittleEndianReversed_ForEveryLength()
    {
        var rng = new Random(Seed(0));

        for (int length = 0; length <= sizeof(ulong); length++)
        {
            byte[] exact = Randomized(rng, length);
            ref byte source = ref exact.AsSpan(0).GetPinnableReference();

            Assert.That(
                CH.BinaryLoad.ReadUInt64BigEndianPadded(ref source, length),
                Is.EqualTo(BinaryPrimitives.ReverseEndianness(CH.BinaryLoad.ReadUInt64LittleEndianPadded(ref source, length))),
                $"UInt64, length {length}");

            if (length <= sizeof(uint))
            {
                Assert.That(
                    CH.BinaryLoad.ReadUInt32BigEndianPadded(ref source, length),
                    Is.EqualTo(BinaryPrimitives.ReverseEndianness(CH.BinaryLoad.ReadUInt32LittleEndianPadded(ref source, length))),
                    $"UInt32, length {length}");
            }
        }
    }

    /// <summary>
    /// A zero-length read dereferences nothing, so a null source is legal — the shape
    /// every caller hits when the final block lands exactly on a block boundary.
    /// </summary>
    [Test]
    public void ZeroLength_ReadsNothing()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(CH.BinaryLoad.ReadUInt32LittleEndianPadded((byte*)null, 0), Is.Zero);
            Assert.That(CH.BinaryLoad.ReadUInt64LittleEndianPadded((byte*)null, 0), Is.Zero);
            Assert.That(CH.BinaryLoad.ReadUInt32BigEndianPadded((byte*)null, 0), Is.Zero);
            Assert.That(CH.BinaryLoad.ReadUInt64BigEndianPadded((byte*)null, 0), Is.Zero);
        }

        CH.BinaryLoad.ReadUInt64PairLittleEndianPadded((byte*)null, 0, out ulong low, out ulong high);
        CH.BinaryLoad.ReadUInt64PairBigEndianPadded((byte*)null, 0, out ulong first, out ulong second);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(low, Is.Zero);
            Assert.That(high, Is.Zero);
            Assert.That(first, Is.Zero);
            Assert.That(second, Is.Zero);
        }
    }

    /// <summary>
    /// A second implementation of the same decomposition, over a span sliced to exactly
    /// <c>length</c> and read through bounds-checked accessors, agrees on every value.
    /// </summary>
    [Test]
    public void BoundsCheckedOracle_AgreesForEveryLength()
    {
        var rng = new Random(Seed(sizeof(ulong)));

        for (int length = 0; length <= sizeof(ulong); length++)
        {
            byte[] exact = Randomized(rng, length);
            ref byte source = ref exact.AsSpan(0).GetPinnableReference();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(
                    CH.BinaryLoad.ReadUInt64LittleEndianPadded(ref source, length),
                    Is.EqualTo(OracleUInt64LittleEndian(exact)),
                    $"little-endian, length {length}");

                Assert.That(
                    CH.BinaryLoad.ReadUInt64BigEndianPadded(ref source, length),
                    Is.EqualTo(OracleUInt64BigEndian(exact)),
                    $"big-endian, length {length}");
            }
        }
    }

#if NET8_0_OR_GREATER
    [Test]
    public void LoadPadded128_MatchesAZeroPaddedBlock()
    {
        AssertSweep(Vector128<byte>.Count, static (backing, offset, length) =>
        {
            var block = new byte[Vector128<byte>.Count];
            CH.BinaryLoad.LoadPadded128(ref backing.AsSpan(offset).GetPinnableReference(), length).CopyTo(block);
            return block;
        });
    }

    [Test]
    public void LoadPadded128_PointerOverloadAgrees()
    {
        AssertSweep(Vector128<byte>.Count, static (backing, offset, length) =>
        {
            var block = new byte[Vector128<byte>.Count];
            fixed (byte* source = &backing.AsSpan(offset).GetPinnableReference())
            {
                CH.BinaryLoad.LoadPadded128(source, length).CopyTo(block);
            }

            return block;
        });
    }

    [Test]
    public void LoadPaddedBlock128x4_MatchesAZeroPaddedBlock()
    {
        AssertSweep(4 * Vector128<byte>.Count, static (backing, offset, length) =>
        {
            CH.BinaryLoad.LoadPaddedBlock128x4(
                ref backing.AsSpan(offset).GetPinnableReference(), length,
                out var m0, out var m1, out var m2, out var m3);
            return Block(m0, m1, m2, m3);
        });
    }

    [Test]
    public void LoadPaddedBlock128x4_PointerOverloadAgrees()
    {
        AssertSweep(4 * Vector128<byte>.Count, static (backing, offset, length) =>
        {
            Vector128<uint> m0, m1, m2, m3;
            fixed (byte* source = &backing.AsSpan(offset).GetPinnableReference())
            {
                CH.BinaryLoad.LoadPaddedBlock128x4(source, length, out m0, out m1, out m2, out m3);
            }

            return Block(m0, m1, m2, m3);
        });
    }

    /// <summary>
    /// The tail loader agrees with a zero-padded block for every split of every buffer
    /// length, which straddles both of its paths: buffers below a vector compose word by
    /// word, the rest realign an overlapping load of the last 16 bytes.
    /// </summary>
    [Test]
    public void LoadTailPadded128_MatchesAZeroPaddedBlockForEverySplit()
    {
        int width = Vector128<byte>.Count;
        var rng = new Random(Seed(width));

        for (int dataLength = 0; dataLength <= 2 * width; dataLength++)
        {
            for (int offset = 0; offset <= dataLength; offset++)
            {
                int length = Math.Min(dataLength - offset, width);
                byte[] data = Randomized(rng, dataLength);

                byte[] expected = new byte[width];
                data.AsSpan(offset, length).CopyTo(expected);

                var actual = new byte[width];
                CH.BinaryLoad.LoadTailPadded128(data, offset).CopyTo(actual);
                Assert.That(actual, Is.EqualTo(expected), $"dataLength {dataLength}, offset {offset}");

                fixed (byte* source = &data.AsSpan(0).GetPinnableReference())
                {
                    CH.BinaryLoad.LoadTailPadded128(source, dataLength, offset).CopyTo(actual);
                }

                Assert.That(actual, Is.EqualTo(expected), $"pointer overload, dataLength {dataLength}, offset {offset}");
            }
        }
    }

    private static byte[] Block(Vector128<uint> m0, Vector128<uint> m1, Vector128<uint> m2, Vector128<uint> m3)
    {
        var block = new byte[4 * Vector128<byte>.Count];
        m0.AsByte().CopyTo(block.AsSpan(0));
        m1.AsByte().CopyTo(block.AsSpan(Vector128<byte>.Count));
        m2.AsByte().CopyTo(block.AsSpan(2 * Vector128<byte>.Count));
        m3.AsByte().CopyTo(block.AsSpan(3 * Vector128<byte>.Count));
        return block;
    }
#endif

    /// <summary>
    /// Sweeps every length, every source alignment and both trailing placements, and for
    /// each re-runs the loader with the surrounding bytes refilled afresh.
    /// </summary>
    /// <param name="width">The block width the loader produces.</param>
    /// <param name="load">Invokes the member under test and returns the block it produced.</param>
    private static void AssertSweep(int width, Func<byte[], int, int, byte[]> load)
    {
        var rng = new Random(Seed(width));

        foreach (int trailer in Trailers)
        {
            for (int length = 0; length <= width; length++)
            {
                for (int offset = 0; offset <= MaxOffset; offset++)
                {
                    byte[] backing = Randomized(rng, offset + length + trailer);

                    byte[] expected = new byte[width];
                    backing.AsSpan(offset, length).CopyTo(expected);

                    for (int repetition = 0; repetition < Repetitions; repetition++)
                    {
                        Scramble(rng, backing, offset, length);

                        Assert.That(
                            load(backing, offset, length),
                            Is.EqualTo(expected),
                            $"width {width}, trailer {trailer}, length {length}, offset {offset}, repetition {repetition}");
                    }
                }
            }
        }
    }

    /// <summary>
    /// Refills everything outside <c>[offset, offset + length)</c>. A fixed filler only
    /// catches a byte that survives into the result; a fresh one per repetition catches any
    /// dependence on out-of-range memory at all.
    /// </summary>
    private static void Scramble(Random rng, byte[] backing, int offset, int length)
    {
        for (int i = 0; i < backing.Length; i++)
        {
            if (i < offset || i >= offset + length)
            {
                backing[i] = (byte)rng.Next(256);
            }
        }
    }

    private static byte[] Randomized(Random rng, int count)
    {
        var bytes = new byte[count];
        for (int i = 0; i < count; i++)
        {
            bytes[i] = (byte)rng.Next(256);
        }

        return bytes;
    }

    private static byte[] Pair(ulong low, ulong high)
    {
        var block = new byte[2 * sizeof(ulong)];
        BinaryPrimitives.WriteUInt64LittleEndian(block, low);
        BinaryPrimitives.WriteUInt64LittleEndian(block.AsSpan(sizeof(ulong)), high);
        return block;
    }

    private static byte[] PairBigEndian(ulong first, ulong second)
    {
        var block = new byte[2 * sizeof(ulong)];
        BinaryPrimitives.WriteUInt64BigEndian(block, first);
        BinaryPrimitives.WriteUInt64BigEndian(block.AsSpan(sizeof(ulong)), second);
        return block;
    }

    /// <summary>
    /// Mirrors the tier decomposition through accessors that bounds-check, over a span that
    /// is exactly as long as the readable input.
    /// </summary>
    private static ulong OracleUInt64LittleEndian(ReadOnlySpan<byte> exact)
    {
        if (exact.Length >= sizeof(ulong))
        {
            return BinaryPrimitives.ReadUInt64LittleEndian(exact);
        }

        ulong value = 0;
        int at = 0;
        if ((exact.Length & 4) != 0)
        {
            value = BinaryPrimitives.ReadUInt32LittleEndian(exact.Slice(at));
            at = 4;
        }

        if ((exact.Length & 2) != 0)
        {
            value |= (ulong)BinaryPrimitives.ReadUInt16LittleEndian(exact.Slice(at)) << (at * 8);
            at += 2;
        }

        if ((exact.Length & 1) != 0)
        {
            value |= (ulong)exact[at] << (at * 8);
        }

        return value;
    }

    /// <inheritdoc cref="OracleUInt64LittleEndian"/>
    private static ulong OracleUInt64BigEndian(ReadOnlySpan<byte> exact)
    {
        if (exact.Length >= sizeof(ulong))
        {
            return BinaryPrimitives.ReadUInt64BigEndian(exact);
        }

        ulong value = 0;
        int at = 0;
        if ((exact.Length & 4) != 0)
        {
            value = (ulong)BinaryPrimitives.ReadUInt32BigEndian(exact.Slice(at)) << 32;
            at = 4;
        }

        if ((exact.Length & 2) != 0)
        {
            value |= (ulong)BinaryPrimitives.ReadUInt16BigEndian(exact.Slice(at)) << ((8 - at - 2) * 8);
            at += 2;
        }

        if ((exact.Length & 1) != 0)
        {
            value |= (ulong)exact[at] << ((8 - at - 1) * 8);
        }

        return value;
    }

    /// <summary>A per-width seed, so a failure reproduces.</summary>
    private static int Seed(int width) => 0x5AFE_10AD ^ width;
}
