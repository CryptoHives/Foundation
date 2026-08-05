// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.BigInt;

using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;
using NUnit.Framework;
using System;
using System.Numerics;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class BigUIntTests
{
    // ========================================================================
    // Mul128
    // ========================================================================

    [Test]
    public void Mul128ZeroTimesAnything()
    {
        ulong hi = BigUInt.Mul128(0, 0xFFFFFFFFFFFFFFFF, out ulong lo);
        Assert.That(lo, Is.EqualTo(0UL));
        Assert.That(hi, Is.EqualTo(0UL));
    }

    [Test]
    public void Mul128OneTimesValue()
    {
        ulong hi = BigUInt.Mul128(1, 0xDEADBEEFCAFEBABE, out ulong lo);
        Assert.That(lo, Is.EqualTo(0xDEADBEEFCAFEBABEUL));
        Assert.That(hi, Is.EqualTo(0UL));
    }

    [Test]
    public void Mul128MaxTimesMax()
    {
        // (2^64-1)^2 = 2^128 - 2^65 + 1
        // hi = 0xFFFFFFFFFFFFFFFE, lo = 0x0000000000000001
        ulong hi = BigUInt.Mul128(ulong.MaxValue, ulong.MaxValue, out ulong lo);
        Assert.That(lo, Is.EqualTo(1UL));
        Assert.That(hi, Is.EqualTo(0xFFFFFFFFFFFFFFFEUL));
    }

    [Test]
    public void Mul128KnownProduct()
    {
        // 0x100000000 * 0x100000000 = 0x10000000000000000 (2^64)
        ulong a = 0x100000000UL;
        ulong hi = BigUInt.Mul128(a, a, out ulong lo);
        Assert.That(lo, Is.EqualTo(0UL));
        Assert.That(hi, Is.EqualTo(1UL));
    }

    [Test]
    public void Mul128CrossValidateWithBigInteger()
    {
        ulong a = 0xA5A5A5A5A5A5A5A5UL;
        ulong b = 0x5A5A5A5A5A5A5A5AUL;

        ulong hi = BigUInt.Mul128(a, b, out ulong lo);

        var expected = (BigInteger)a * b;
        var actual = ((BigInteger)hi << 64) | lo;
        Assert.That(actual, Is.EqualTo(expected));
    }

    // ========================================================================
    // Add / Sub
    // ========================================================================

    [Test]
    public void AddTwoLimbs()
    {
        Span<ulong> a = stackalloc ulong[] { ulong.MaxValue, 0 };
        Span<ulong> b = stackalloc ulong[] { 1, 0 };
        Span<ulong> r = stackalloc ulong[2];

        ulong carry = BigUInt.Add(a, b, r);
        Assert.That(r[0], Is.EqualTo(0UL));
        Assert.That(r[1], Is.EqualTo(1UL));
        Assert.That(carry, Is.EqualTo(0UL));
    }

    [Test]
    public void AddCarryOut()
    {
        Span<ulong> a = stackalloc ulong[] { ulong.MaxValue, ulong.MaxValue };
        Span<ulong> b = stackalloc ulong[] { 1, 0 };
        Span<ulong> r = stackalloc ulong[2];

        ulong carry = BigUInt.Add(a, b, r);
        Assert.That(r[0], Is.EqualTo(0UL));
        Assert.That(r[1], Is.EqualTo(0UL));
        Assert.That(carry, Is.EqualTo(1UL));
    }

    [Test]
    public void SubNoBorrow()
    {
        Span<ulong> a = stackalloc ulong[] { 10, 5 };
        Span<ulong> b = stackalloc ulong[] { 3, 2 };
        Span<ulong> r = stackalloc ulong[2];

        ulong borrow = BigUInt.Sub(a, b, r);
        Assert.That(r[0], Is.EqualTo(7UL));
        Assert.That(r[1], Is.EqualTo(3UL));
        Assert.That(borrow, Is.EqualTo(0UL));
    }

    [Test]
    public void SubWithBorrow()
    {
        Span<ulong> a = stackalloc ulong[] { 0, 1 };
        Span<ulong> b = stackalloc ulong[] { 1, 0 };
        Span<ulong> r = stackalloc ulong[2];

        ulong borrow = BigUInt.Sub(a, b, r);
        Assert.That(r[0], Is.EqualTo(ulong.MaxValue));
        Assert.That(r[1], Is.EqualTo(0UL));
        Assert.That(borrow, Is.EqualTo(0UL));
    }

    [Test]
    public void SubUnderflow()
    {
        Span<ulong> a = stackalloc ulong[] { 0, 0 };
        Span<ulong> b = stackalloc ulong[] { 1, 0 };
        Span<ulong> r = stackalloc ulong[2];

        ulong borrow = BigUInt.Sub(a, b, r);
        Assert.That(borrow, Is.EqualTo(1UL));
    }

    [Test]
    public void AddWordCarryPropagation()
    {
        Span<ulong> a = stackalloc ulong[] { ulong.MaxValue, ulong.MaxValue, 0 };
        Span<ulong> r = stackalloc ulong[3];

        ulong carry = BigUInt.AddWord(a, 2, r);
        Assert.That(r[0], Is.EqualTo(1UL));
        Assert.That(r[1], Is.EqualTo(0UL));
        Assert.That(r[2], Is.EqualTo(1UL));
        Assert.That(carry, Is.EqualTo(0UL));
    }

    // ========================================================================
    // Compare (constant-time)
    // ========================================================================

    [Test]
    public void CompareEqual()
    {
        Span<ulong> a = stackalloc ulong[] { 42, 100 };
        int cmp = BigUInt.Compare(a, a);
        Assert.That(cmp, Is.EqualTo(0));
    }

    [Test]
    public void CompareGreaterLowLimb()
    {
        Span<ulong> a = stackalloc ulong[] { 10, 5 };
        Span<ulong> b = stackalloc ulong[] { 9, 5 };
        Assert.That(BigUInt.Compare(a, b), Is.EqualTo(1));
        Assert.That(BigUInt.Compare(b, a), Is.EqualTo(-1));
    }

    [Test]
    public void CompareGreaterHighLimb()
    {
        Span<ulong> a = stackalloc ulong[] { 0, 6 };
        Span<ulong> b = stackalloc ulong[] { ulong.MaxValue, 5 };
        Assert.That(BigUInt.Compare(a, b), Is.EqualTo(1));
    }

    [Test]
    public void ConstantTimeEqualTrue()
    {
        Span<ulong> a = stackalloc ulong[] { 0xDEADBEEF, 0xCAFEBABE };
        Span<ulong> b = stackalloc ulong[] { 0xDEADBEEF, 0xCAFEBABE };
        Assert.That(BigUInt.ConstantTimeEqual(a, b), Is.True);
    }

    [Test]
    public void ConstantTimeEqualFalse()
    {
        Span<ulong> a = stackalloc ulong[] { 0xDEADBEEF, 0xCAFEBABE };
        Span<ulong> b = stackalloc ulong[] { 0xDEADBEEF, 0xCAFEBABF };
        Assert.That(BigUInt.ConstantTimeEqual(a, b), Is.False);
    }

    [Test]
    public void IsZeroTrue()
    {
        Span<ulong> a = stackalloc ulong[] { 0, 0, 0 };
        Assert.That(BigUInt.IsZero(a), Is.True);
    }

    [Test]
    public void IsZeroFalse()
    {
        Span<ulong> a = stackalloc ulong[] { 0, 0, 1 };
        Assert.That(BigUInt.IsZero(a), Is.False);
    }

    // ========================================================================
    // Shifts
    // ========================================================================

    [Test]
    public void ShiftLeftByOne()
    {
        Span<ulong> a = stackalloc ulong[] { 0x8000000000000000UL, 0 };
        Span<ulong> r = stackalloc ulong[2];

        ulong overflow = BigUInt.ShiftLeft(a, 1, r);
        Assert.That(r[0], Is.EqualTo(0UL));
        Assert.That(r[1], Is.EqualTo(1UL));
        Assert.That(overflow, Is.EqualTo(0UL));
    }

    [Test]
    public void ShiftLeftOverflow()
    {
        Span<ulong> a = stackalloc ulong[] { 0, 0x8000000000000000UL };
        Span<ulong> r = stackalloc ulong[2];

        ulong overflow = BigUInt.ShiftLeft(a, 1, r);
        Assert.That(r[1], Is.EqualTo(0UL));
        Assert.That(overflow, Is.EqualTo(1UL));
    }

    [Test]
    public void ShiftRightByOne()
    {
        Span<ulong> a = stackalloc ulong[] { 0, 1 };
        Span<ulong> r = stackalloc ulong[2];

        BigUInt.ShiftRight(a, 1, r);
        Assert.That(r[0], Is.EqualTo(0x8000000000000000UL));
        Assert.That(r[1], Is.EqualTo(0UL));
    }

    [Test]
    public void ShiftLeftLimbsByOne()
    {
        Span<ulong> a = stackalloc ulong[] { 0xAA, 0xBB, 0 };
        Span<ulong> r = stackalloc ulong[3];

        BigUInt.ShiftLeftLimbs(a, 1, r);
        Assert.That(r[0], Is.EqualTo(0UL));
        Assert.That(r[1], Is.EqualTo(0xAAUL));
        Assert.That(r[2], Is.EqualTo(0xBBUL));
    }

    // ========================================================================
    // Multiplication
    // ========================================================================

    [Test]
    public void MulSingleLimbs()
    {
        Span<ulong> a = stackalloc ulong[] { 0xFFFFFFFFUL };
        Span<ulong> b = stackalloc ulong[] { 0xFFFFFFFFUL };
        Span<ulong> r = stackalloc ulong[2];
        r.Clear();

        BigUInt.Mul(a, b, r);

        var expected = (BigInteger)0xFFFFFFFF * 0xFFFFFFFF;
        var actual = ToBigInteger(r);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MulTwoLimbs()
    {
        Span<ulong> a = stackalloc ulong[] { ulong.MaxValue, ulong.MaxValue };
        Span<ulong> b = stackalloc ulong[] { ulong.MaxValue, ulong.MaxValue };
        Span<ulong> r = stackalloc ulong[4];
        r.Clear();

        BigUInt.Mul(a, b, r);

        var aBig = ToBigInteger(a);
        var expected = aBig * aBig;
        var actual = ToBigInteger(r);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MulCrossValidateLarger()
    {
        // 4-limb × 4-limb (256-bit × 256-bit)
        ulong[] aArr = [0xA5A5A5A5A5A5A5A5, 0x5A5A5A5A5A5A5A5A, 0x1234567890ABCDEF, 0xFEDCBA0987654321];
        ulong[] bArr = [0x0123456789ABCDEF, 0xFEDCBA9876543210, 0xAAAAAAAAAAAAAAAA, 0x5555555555555555];

        Span<ulong> a = aArr;
        Span<ulong> b = bArr;
        Span<ulong> r = stackalloc ulong[8];
        r.Clear();

        BigUInt.Mul(a, b, r);

        var expected = ToBigInteger(a) * ToBigInteger(b);
        var actual = ToBigInteger(r);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MulWordTest()
    {
        Span<ulong> a = stackalloc ulong[] { ulong.MaxValue, ulong.MaxValue };
        Span<ulong> r = stackalloc ulong[2];

        ulong carry = BigUInt.MulWord(a, 3, r);

        var expected = ToBigInteger(a) * 3;
        var actual = ((BigInteger)carry << 128) | ToBigInteger(r);
        Assert.That(actual, Is.EqualTo(expected));
    }

    // ========================================================================
    // Squaring
    // ========================================================================

    [Test]
    public void SquareSingleLimb()
    {
        Span<ulong> a = stackalloc ulong[] { 0xDEADBEEFUL };
        Span<ulong> r = stackalloc ulong[2];
        r.Clear();

        BigUInt.Square(a, r);

        var expected = (BigInteger)0xDEADBEEF * 0xDEADBEEF;
        Assert.That(ToBigInteger(r), Is.EqualTo(expected));
    }

    [Test]
    public void SquareMaxSingleLimb()
    {
        Span<ulong> a = stackalloc ulong[] { ulong.MaxValue };
        Span<ulong> r = stackalloc ulong[2];
        r.Clear();

        BigUInt.Square(a, r);

        var expected = (BigInteger)ulong.MaxValue * ulong.MaxValue;
        Assert.That(ToBigInteger(r), Is.EqualTo(expected));
    }

    [Test]
    public void SquareFourLimbsCrossValidate()
    {
        ulong[] aArr = [0xA5A5A5A5A5A5A5A5, 0x5A5A5A5A5A5A5A5A, 0x1234567890ABCDEF, 0xFEDCBA0987654321];
        Span<ulong> a = aArr;
        Span<ulong> rMul = stackalloc ulong[8];
        Span<ulong> rSqr = stackalloc ulong[8];
        rMul.Clear();
        rSqr.Clear();

        BigUInt.Mul(a, a, rMul);
        BigUInt.Square(a, rSqr);

        Assert.That(ToBigInteger(rSqr), Is.EqualTo(ToBigInteger(rMul)));
    }

    // ========================================================================
    // Conditional Operations
    // ========================================================================

    [Test]
    public void ConditionalCopyWhenTrue()
    {
        Span<ulong> dst = stackalloc ulong[] { 0, 0 };
        Span<ulong> src = stackalloc ulong[] { 42, 99 };

        BigUInt.ConditionalCopy(1, dst, src);
        Assert.That(dst[0], Is.EqualTo(42UL));
        Assert.That(dst[1], Is.EqualTo(99UL));
    }

    [Test]
    public void ConditionalCopyWhenFalse()
    {
        Span<ulong> dst = stackalloc ulong[] { 7, 8 };
        Span<ulong> src = stackalloc ulong[] { 42, 99 };

        BigUInt.ConditionalCopy(0, dst, src);
        Assert.That(dst[0], Is.EqualTo(7UL));
        Assert.That(dst[1], Is.EqualTo(8UL));
    }

    [Test]
    public void ConditionalSwapWhenTrue()
    {
        Span<ulong> a = stackalloc ulong[] { 1, 2 };
        Span<ulong> b = stackalloc ulong[] { 3, 4 };

        BigUInt.ConditionalSwap(1, a, b);
        Assert.That(a[0], Is.EqualTo(3UL));
        Assert.That(b[0], Is.EqualTo(1UL));
    }

    [Test]
    public void ConditionalSwapWhenFalse()
    {
        Span<ulong> a = stackalloc ulong[] { 1, 2 };
        Span<ulong> b = stackalloc ulong[] { 3, 4 };

        BigUInt.ConditionalSwap(0, a, b);
        Assert.That(a[0], Is.EqualTo(1UL));
        Assert.That(b[0], Is.EqualTo(3UL));
    }

    // ========================================================================
    // Byte Conversion
    // ========================================================================

    [Test]
    public void BigEndianRoundTrip()
    {
        byte[] input = [0x01, 0x23, 0x45, 0x67, 0x89, 0xAB, 0xCD, 0xEF,
                        0xFE, 0xDC, 0xBA, 0x98, 0x76, 0x54, 0x32, 0x10];

        Span<ulong> limbs = stackalloc ulong[2];
        BigUInt.FromBigEndianBytes(input, limbs);

        byte[] output = new byte[16];
        BigUInt.ToBigEndianBytes(limbs, output);

        Assert.That(output, Is.EqualTo(input));
    }

    [Test]
    public void FromBigEndianBytesKnownValue()
    {
        // 0x0100000000000000_00 = 2^64
        byte[] input = [0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00];
        Span<ulong> limbs = stackalloc ulong[2];

        BigUInt.FromBigEndianBytes(input, limbs);
        Assert.That(limbs[0], Is.EqualTo(0UL));
        Assert.That(limbs[1], Is.EqualTo(1UL));
    }

    // ========================================================================
    // BitLength
    // ========================================================================

    [Test]
    public void BitLengthZero()
    {
        Span<ulong> a = stackalloc ulong[] { 0, 0 };
        Assert.That(BigUInt.BitLength(a), Is.EqualTo(0));
    }

    [Test]
    public void BitLengthOne()
    {
        Span<ulong> a = stackalloc ulong[] { 1, 0 };
        Assert.That(BigUInt.BitLength(a), Is.EqualTo(1));
    }

    [Test]
    public void BitLengthMax()
    {
        Span<ulong> a = stackalloc ulong[] { 0, ulong.MaxValue };
        Assert.That(BigUInt.BitLength(a), Is.EqualTo(128));
    }

    [Test]
    public void BitLength65()
    {
        Span<ulong> a = stackalloc ulong[] { 0, 1 };
        Assert.That(BigUInt.BitLength(a), Is.EqualTo(65));
    }

    // ========================================================================
    // Add + Sub identity: (a + b) - b == a
    // ========================================================================

    [Test]
    public void AddSubRoundTrip()
    {
        ulong[] aArr = [0xA5A5A5A5A5A5A5A5, 0x5A5A5A5A5A5A5A5A, 0x1234567890ABCDEF, 0xFEDCBA0987654321];
        ulong[] bArr = [0x0123456789ABCDEF, 0xFEDCBA9876543210, 0xAAAAAAAAAAAAAAAA, 0x5555555555555555];

        Span<ulong> a = aArr;
        Span<ulong> b = bArr;
        Span<ulong> sum = stackalloc ulong[4];
        Span<ulong> diff = stackalloc ulong[4];

        BigUInt.Add(a, b, sum);
        BigUInt.Sub(sum, b, diff);

        Assert.That(BigUInt.ConstantTimeEqual(diff, a), Is.True);
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static BigInteger ToBigInteger(ReadOnlySpan<ulong> limbs)
    {
        BigInteger result = 0;
        for (int i = limbs.Length - 1; i >= 0; i--)
        {
            result = (result << 64) | limbs[i];
        }

        return result;
    }
}
