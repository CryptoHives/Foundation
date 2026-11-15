// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests;

using NUnit.Framework;
using System;
using System.Buffers.Binary;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Pins <c>BinaryStore</c>: the written bytes are the leading bytes of the full encoding, and
/// every byte outside <c>[destination, destination + length)</c> is left untouched.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public unsafe class BinaryStoreTests
{
    private const int MaxOffset = 16;

    private static readonly int[] Trailers = [0, 16];

    /// <summary>Decodes the full block <paramref name="encoding"/> and writes it truncated to <paramref name="destination"/>.</summary>
    public delegate void TruncatedWriter(ReadOnlySpan<byte> encoding, Span<byte> destination);

    public static TestCaseData[] Writers() =>
    [
        Case("UInt32LittleEndian_Span", sizeof(uint),
            static (e, d) => CH.BinaryStore.WriteUInt32LittleEndianTruncated(BinaryPrimitives.ReadUInt32LittleEndian(e), d)),
        Case("UInt32LittleEndian_Ref", sizeof(uint),
            static (e, d) => CH.BinaryStore.WriteUInt32LittleEndianTruncated(BinaryPrimitives.ReadUInt32LittleEndian(e), ref d.GetPinnableReference(), d.Length)),
        Case("UInt32LittleEndian_Pointer", sizeof(uint),
            static (e, d) => { fixed (byte* p = d) { CH.BinaryStore.WriteUInt32LittleEndianTruncated(BinaryPrimitives.ReadUInt32LittleEndian(e), p, d.Length); } }),

        Case("UInt64LittleEndian_Span", sizeof(ulong),
            static (e, d) => CH.BinaryStore.WriteUInt64LittleEndianTruncated(BinaryPrimitives.ReadUInt64LittleEndian(e), d)),
        Case("UInt64LittleEndian_Ref", sizeof(ulong),
            static (e, d) => CH.BinaryStore.WriteUInt64LittleEndianTruncated(BinaryPrimitives.ReadUInt64LittleEndian(e), ref d.GetPinnableReference(), d.Length)),
        Case("UInt64LittleEndian_Pointer", sizeof(ulong),
            static (e, d) => { fixed (byte* p = d) { CH.BinaryStore.WriteUInt64LittleEndianTruncated(BinaryPrimitives.ReadUInt64LittleEndian(e), p, d.Length); } }),

        Case("UInt64PairLittleEndian_Span", 2 * sizeof(ulong),
            static (e, d) => CH.BinaryStore.WriteUInt64PairLittleEndianTruncated(BinaryPrimitives.ReadUInt64LittleEndian(e), BinaryPrimitives.ReadUInt64LittleEndian(e.Slice(8)), d)),
        Case("UInt64PairLittleEndian_Ref", 2 * sizeof(ulong),
            static (e, d) => CH.BinaryStore.WriteUInt64PairLittleEndianTruncated(BinaryPrimitives.ReadUInt64LittleEndian(e), BinaryPrimitives.ReadUInt64LittleEndian(e.Slice(8)), ref d.GetPinnableReference(), d.Length)),
        Case("UInt64PairLittleEndian_Pointer", 2 * sizeof(ulong),
            static (e, d) => { fixed (byte* p = d) { CH.BinaryStore.WriteUInt64PairLittleEndianTruncated(BinaryPrimitives.ReadUInt64LittleEndian(e), BinaryPrimitives.ReadUInt64LittleEndian(e.Slice(8)), p, d.Length); } }),

        Case("UInt32BigEndian_Span", sizeof(uint),
            static (e, d) => CH.BinaryStore.WriteUInt32BigEndianTruncated(BinaryPrimitives.ReadUInt32BigEndian(e), d)),
        Case("UInt32BigEndian_Ref", sizeof(uint),
            static (e, d) => CH.BinaryStore.WriteUInt32BigEndianTruncated(BinaryPrimitives.ReadUInt32BigEndian(e), ref d.GetPinnableReference(), d.Length)),
        Case("UInt32BigEndian_Pointer", sizeof(uint),
            static (e, d) => { fixed (byte* p = d) { CH.BinaryStore.WriteUInt32BigEndianTruncated(BinaryPrimitives.ReadUInt32BigEndian(e), p, d.Length); } }),

        Case("UInt64BigEndian_Span", sizeof(ulong),
            static (e, d) => CH.BinaryStore.WriteUInt64BigEndianTruncated(BinaryPrimitives.ReadUInt64BigEndian(e), d)),
        Case("UInt64BigEndian_Ref", sizeof(ulong),
            static (e, d) => CH.BinaryStore.WriteUInt64BigEndianTruncated(BinaryPrimitives.ReadUInt64BigEndian(e), ref d.GetPinnableReference(), d.Length)),
        Case("UInt64BigEndian_Pointer", sizeof(ulong),
            static (e, d) => { fixed (byte* p = d) { CH.BinaryStore.WriteUInt64BigEndianTruncated(BinaryPrimitives.ReadUInt64BigEndian(e), p, d.Length); } }),

        Case("UInt64PairBigEndian_Span", 2 * sizeof(ulong),
            static (e, d) => CH.BinaryStore.WriteUInt64PairBigEndianTruncated(BinaryPrimitives.ReadUInt64BigEndian(e), BinaryPrimitives.ReadUInt64BigEndian(e.Slice(8)), d)),
        Case("UInt64PairBigEndian_Ref", 2 * sizeof(ulong),
            static (e, d) => CH.BinaryStore.WriteUInt64PairBigEndianTruncated(BinaryPrimitives.ReadUInt64BigEndian(e), BinaryPrimitives.ReadUInt64BigEndian(e.Slice(8)), ref d.GetPinnableReference(), d.Length)),
        Case("UInt64PairBigEndian_Pointer", 2 * sizeof(ulong),
            static (e, d) => { fixed (byte* p = d) { CH.BinaryStore.WriteUInt64PairBigEndianTruncated(BinaryPrimitives.ReadUInt64BigEndian(e), BinaryPrimitives.ReadUInt64BigEndian(e.Slice(8)), p, d.Length); } }),
    ];

    private static TestCaseData Case(string name, int size, TruncatedWriter writer) =>
        new TestCaseData(size, writer).SetName($"Write{name}Truncated_WritesTheLeadingBytesOnly");

    [TestCaseSource(nameof(Writers))]
    public void WritesTheLeadingBytesOnly(int size, TruncatedWriter writer)
    {
        var random = new Random(0x5702E + size);
        var encoding = new byte[size];

        for (int length = 0; length <= size; length++)
        {
            for (int offset = 0; offset < MaxOffset; offset++)
            {
                foreach (int trailer in Trailers)
                {
                    random.NextBytes(encoding);

                    var backing = new byte[offset + length + trailer];
                    random.NextBytes(backing);
                    byte[] expected = (byte[])backing.Clone();
                    encoding.AsSpan(0, length).CopyTo(expected.AsSpan(offset));

                    writer(encoding, backing.AsSpan(offset, length));

                    Assert.That(backing, Is.EqualTo(expected), $"length {length}, offset {offset}, trailer {trailer}");
                }
            }
        }
    }

    [Test]
    public void ZeroLength_WritesNothing()
    {
        CH.BinaryStore.WriteUInt32LittleEndianTruncated(uint.MaxValue, (byte*)null, 0);
        CH.BinaryStore.WriteUInt64LittleEndianTruncated(ulong.MaxValue, (byte*)null, 0);
        CH.BinaryStore.WriteUInt64PairLittleEndianTruncated(ulong.MaxValue, ulong.MaxValue, (byte*)null, 0);
        CH.BinaryStore.WriteUInt32BigEndianTruncated(uint.MaxValue, (byte*)null, 0);
        CH.BinaryStore.WriteUInt64BigEndianTruncated(ulong.MaxValue, (byte*)null, 0);
        CH.BinaryStore.WriteUInt64PairBigEndianTruncated(ulong.MaxValue, ulong.MaxValue, (byte*)null, 0);
    }
}
