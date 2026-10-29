// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests;

using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Pins <c>BinaryOperations</c> against byte-at-a-time references: the counters carry exactly as
/// big-endian integers do, and the XORs touch only the requested range.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class BinaryOperationsTests
{
    private static readonly int[] CounterLengths = [1, 2, 3, 4, 5, 8, 16];

    private static readonly int[] XorLengths = [0, 1, 7, 8, 9, 15, 16, 17, 31, 32, 33, 64, 100];

    public static TestCaseData[] CounterStarts()
    {
        var cases = new System.Collections.Generic.List<TestCaseData>();
        foreach (int length in CounterLengths)
        {
            // 0x00.., 0x00..FE, 0x00..FF, 0xFF.., and a carry that stops mid-way: ..01 FF FF FF FF.
            cases.Add(new TestCaseData(length, Filled(length, 0x00, 0x00)));
            cases.Add(new TestCaseData(length, Filled(length, 0x00, 0xFE)));
            cases.Add(new TestCaseData(length, Filled(length, 0x00, 0xFF)));
            cases.Add(new TestCaseData(length, Filled(length, 0xFF, 0xFF)));
            cases.Add(new TestCaseData(length, Filled(length, 0x01, 0xFF)));
            if (length > 4)
            {
                byte[] partial = Filled(length, 0x00, 0xFF);
                partial[length - 5] = 0x7F;
                cases.Add(new TestCaseData(length, partial));
            }
        }

        return cases.ToArray();
    }

    /// <summary>Builds a counter whose leading bytes are <paramref name="head"/> and whose last four (or fewer) bytes are <paramref name="tail"/>.</summary>
    private static byte[] Filled(int length, byte head, byte tail)
    {
        byte[] bytes = new byte[length];
        for (int i = 0; i < length; i++)
        {
            bytes[i] = i >= length - 4 ? tail : head;
        }

        return bytes;
    }

    private static byte[] ReferenceIncrement(byte[] counter)
    {
        byte[] result = (byte[])counter.Clone();
        for (int i = result.Length - 1; i >= 0; i--)
        {
            if (unchecked(++result[i]) != 0)
            {
                break;
            }
        }

        return result;
    }

    [TestCaseSource(nameof(CounterStarts))]
    public void IncrementBigEndianCarriesLikeAnInteger(int length, byte[] start)
    {
        byte[] counter = (byte[])start.Clone();
        CH.BinaryOperations.IncrementBigEndian(counter);
        Assert.That(counter, Is.EqualTo(ReferenceIncrement(start)));
    }

    [Test]
    public void IncrementBigEndianWrapsAllOnesToZero()
    {
        byte[] counter = new byte[16];
        counter.AsSpan().Fill(0xFF);
        CH.BinaryOperations.IncrementBigEndian(counter);
        Assert.That(counter, Is.EqualTo(new byte[16]));
    }

    [Test]
    public void IncrementBigEndianOfEmptySpanIsANoOp()
    {
        Assert.DoesNotThrow(() => CH.BinaryOperations.IncrementBigEndian(Span<byte>.Empty));
    }

    [TestCase(0)]
    [TestCase(3)]
    [TestCase(12)]
    public void IncrementUInt32BigEndianWrapsWithinTheWord(int offset)
    {
        byte[] block = new byte[16 + 4];
        block.AsSpan().Fill(0xAA);
        block.AsSpan(offset, 4).Fill(0xFF);
        CH.BinaryOperations.IncrementUInt32BigEndian(block, offset);

        byte[] expected = new byte[block.Length];
        expected.AsSpan().Fill(0xAA);
        expected.AsSpan(offset, 4).Clear();
        Assert.That(block, Is.EqualTo(expected));
    }

    [TestCase(0)]
    [TestCase(12)]
    public void IncrementUInt32BigEndianAddsOneWithCarryInsideTheWord(int offset)
    {
        byte[] block = new byte[16 + 4];
        block[offset + 3] = 0xFF;
        block[offset + 2] = 0x01;
        CH.BinaryOperations.IncrementUInt32BigEndian(block, offset);
        Assert.That(block.AsSpan(offset, 4).ToArray(), Is.EqualTo(new byte[] { 0x00, 0x00, 0x02, 0x00 }));
    }

    [Test]
    public void IncrementUInt32BigEndianRejectsAWordPastTheEnd()
    {
        byte[] block = new byte[16];
        Assert.Throws<ArgumentOutOfRangeException>(() => CH.BinaryOperations.IncrementUInt32BigEndian(block, 13));
    }

    private static byte[] Pattern(int length, int seed)
    {
        byte[] bytes = new byte[length];
        for (int i = 0; i < length; i++)
        {
            bytes[i] = unchecked((byte)(i * 31 + seed));
        }

        return bytes;
    }

    private static byte[] ReferenceXor(byte[] left, byte[] right, int length)
    {
        byte[] result = new byte[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = (byte)(left[i] ^ right[i]);
        }

        return result;
    }

    [TestCaseSource(nameof(XorLengths))]
    public void XorMatchesTheByteLoopAndStopsAtTheLength(int length)
    {
        byte[] left = Pattern(length, 7);
        byte[] right = Pattern(length + 5, 91);
        byte[] destination = new byte[length + 3];
        destination.AsSpan().Fill(0xCC);

        CH.BinaryOperations.Xor(left, right, destination);

        byte[] expected = new byte[length + 3];
        expected.AsSpan().Fill(0xCC);
        ReferenceXor(left, right, length).CopyTo(expected, 0);
        Assert.That(destination, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(XorLengths))]
    public void XorByReferenceMatchesTheSpanForm(int length)
    {
        byte[] left = Pattern(length, 13);
        byte[] right = Pattern(length, 200);
        byte[] destination = new byte[length + 3];
        destination.AsSpan().Fill(0xCC);

        if (length > 0)
        {
            CH.BinaryOperations.Xor(
                ref MemoryMarshal.GetReference<byte>(left),
                ref MemoryMarshal.GetReference<byte>(right),
                ref MemoryMarshal.GetReference<byte>(destination),
                (nuint)length);
        }

        byte[] expected = new byte[length + 3];
        expected.AsSpan().Fill(0xCC);
        ReferenceXor(left, right, length).CopyTo(expected, 0);
        Assert.That(destination, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(XorLengths))]
    public void XorInPlaceOnEitherOperandGivesTheSameResult(int length)
    {
        byte[] left = Pattern(length, 3);
        byte[] right = Pattern(length, 77);
        byte[] expected = ReferenceXor(left, right, length);

        byte[] intoLeft = (byte[])left.Clone();
        CH.BinaryOperations.Xor(intoLeft, right, intoLeft);
        Assert.That(intoLeft, Is.EqualTo(expected));

        byte[] intoRight = (byte[])right.Clone();
        CH.BinaryOperations.Xor(left, intoRight, intoRight);
        Assert.That(intoRight, Is.EqualTo(expected));
    }

    [Test]
    public void XorRejectsAShortSecondOperandOrDestination()
    {
        byte[] left = new byte[16];
        Assert.Throws<ArgumentOutOfRangeException>(() => CH.BinaryOperations.Xor(left, new byte[15], new byte[16]));
        Assert.Throws<ArgumentOutOfRangeException>(() => CH.BinaryOperations.Xor(left, new byte[16], new byte[15]));
    }

    [Test]
    public void Xor128WritesExactlySixteenBytes()
    {
        byte[] left = Pattern(20, 5);
        byte[] right = Pattern(20, 150);
        byte[] destination = new byte[20];
        destination.AsSpan().Fill(0xCC);

        CH.BinaryOperations.Xor128(left, right, destination);

        byte[] expected = new byte[20];
        expected.AsSpan().Fill(0xCC);
        ReferenceXor(left, right, 16).CopyTo(expected, 0);
        Assert.That(destination, Is.EqualTo(expected));
    }

    [Test]
    public void Xor128ByReferenceMatchesTheSpanFormIncludingAliasing()
    {
        byte[] left = Pattern(16, 21);
        byte[] right = Pattern(16, 99);
        byte[] expected = ReferenceXor(left, right, 16);

        byte[] separate = new byte[16];
        CH.BinaryOperations.Xor128(
            ref MemoryMarshal.GetReference<byte>(left),
            ref MemoryMarshal.GetReference<byte>(right),
            ref MemoryMarshal.GetReference<byte>(separate));
        Assert.That(separate, Is.EqualTo(expected));

        byte[] inPlace = (byte[])left.Clone();
        ref byte p = ref MemoryMarshal.GetReference<byte>(inPlace);
        CH.BinaryOperations.Xor128(ref p, ref MemoryMarshal.GetReference<byte>(right), ref p);
        Assert.That(inPlace, Is.EqualTo(expected));
    }

    [Test]
    public void Xor128RejectsShortSpans()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CH.BinaryOperations.Xor128(new byte[15], new byte[16], new byte[16]));
        Assert.Throws<ArgumentOutOfRangeException>(() => CH.BinaryOperations.Xor128(new byte[16], new byte[15], new byte[16]));
        Assert.Throws<ArgumentOutOfRangeException>(() => CH.BinaryOperations.Xor128(new byte[16], new byte[16], new byte[15]));
    }
}
