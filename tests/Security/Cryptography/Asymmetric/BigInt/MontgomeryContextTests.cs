// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.BigInt;

using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;
using NUnit.Framework;
using System;
using System.Numerics;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MontgomeryContextTests
{
    // ========================================================================
    // Montgomery Round-Trip (ToMontgomery → FromMontgomery)
    // ========================================================================

    [Test]
    public void RoundTripSmallPrime()
    {
        // m = 17 (small odd prime)
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 7 };
        Span<ulong> aMont = stackalloc ulong[1];
        Span<ulong> aBack = stackalloc ulong[1];

        ctx.ToMontgomery(a, aMont);
        ctx.FromMontgomery(aMont, aBack);

        Assert.That(aBack[0], Is.EqualTo(7UL));
    }

    [Test]
    public void RoundTripLargePrime()
    {
        // m = 2^61 - 1 (Mersenne prime)
        ulong mersenne = (1UL << 61) - 1;
        Span<ulong> m = stackalloc ulong[] { mersenne };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 12345678901234567UL };
        Span<ulong> aMont = stackalloc ulong[1];
        Span<ulong> aBack = stackalloc ulong[1];

        ctx.ToMontgomery(a, aMont);
        ctx.FromMontgomery(aMont, aBack);

        Assert.That(aBack[0], Is.EqualTo(12345678901234567UL));
    }

    [Test]
    public void RoundTripTwoLimbModulus()
    {
        // m = 2^127 - 1 (Mersenne prime)
        Span<ulong> m = stackalloc ulong[] { ulong.MaxValue, long.MaxValue };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 42, 0 };
        Span<ulong> aMont = stackalloc ulong[2];
        Span<ulong> aBack = stackalloc ulong[2];

        ctx.ToMontgomery(a, aMont);
        ctx.FromMontgomery(aMont, aBack);

        Assert.That(aBack[0], Is.EqualTo(42UL));
        Assert.That(aBack[1], Is.EqualTo(0UL));
    }

    // ========================================================================
    // Montgomery Multiplication
    // ========================================================================

    [Test]
    public void MontMulSmall()
    {
        // m = 17, compute 7 * 11 mod 17 = 77 mod 17 = 9
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 7 };
        Span<ulong> b = stackalloc ulong[] { 11 };

        Span<ulong> aMont = stackalloc ulong[1];
        Span<ulong> bMont = stackalloc ulong[1];
        Span<ulong> cMont = stackalloc ulong[1];
        Span<ulong> c = stackalloc ulong[1];

        ctx.ToMontgomery(a, aMont);
        ctx.ToMontgomery(b, bMont);
        ctx.MontMul(aMont, bMont, cMont);
        ctx.FromMontgomery(cMont, c);

        Assert.That(c[0], Is.EqualTo(9UL)); // 7 * 11 mod 17 = 9
    }

    [Test]
    public void MontMulIdentity()
    {
        Span<ulong> m = stackalloc ulong[] { 23 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 15 };
        Span<ulong> one = stackalloc ulong[] { 1 };

        Span<ulong> aMont = stackalloc ulong[1];
        Span<ulong> oneMont = stackalloc ulong[1];
        Span<ulong> cMont = stackalloc ulong[1];
        Span<ulong> c = stackalloc ulong[1];

        ctx.ToMontgomery(a, aMont);
        ctx.ToMontgomery(one, oneMont);
        ctx.MontMul(aMont, oneMont, cMont);
        ctx.FromMontgomery(cMont, c);

        Assert.That(c[0], Is.EqualTo(15UL)); // a * 1 mod m = a
    }

    [Test]
    public void MontMulTwoLimb()
    {
        // m = 2^127 - 1 (Mersenne prime)
        ulong[] mArr = [ulong.MaxValue, long.MaxValue];
        var ctx = new MontgomeryContext(mArr);

        Span<ulong> a = stackalloc ulong[] { 123456789, 0 };
        Span<ulong> b = stackalloc ulong[] { 987654321, 0 };

        Span<ulong> aMont = stackalloc ulong[2];
        Span<ulong> bMont = stackalloc ulong[2];
        Span<ulong> cMont = stackalloc ulong[2];
        Span<ulong> c = stackalloc ulong[2];

        ctx.ToMontgomery(a, aMont);
        ctx.ToMontgomery(b, bMont);
        ctx.MontMul(aMont, bMont, cMont);
        ctx.FromMontgomery(cMont, c);

        BigInteger mBig = ToBigInteger(mArr);
        BigInteger expected = ((BigInteger)123456789 * 987654321) % mBig;
        BigInteger actual = ToBigInteger(c);
        Assert.That(actual, Is.EqualTo(expected));
    }

    // ========================================================================
    // Modular Exponentiation
    // ========================================================================

    [Test]
    public void ModExpSmall()
    {
        // 3^10 mod 17 = 59049 mod 17 = 8
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> baseVal = stackalloc ulong[] { 3 };
        Span<ulong> exp = stackalloc ulong[] { 10 };
        Span<ulong> result = stackalloc ulong[1];

        ctx.ModExp(baseVal, exp, result);

        Assert.That(result[0], Is.EqualTo(8UL));
    }

    [Test]
    public void ModExpZeroExponent()
    {
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> baseVal = stackalloc ulong[] { 5 };
        Span<ulong> exp = stackalloc ulong[] { 0 };
        Span<ulong> result = stackalloc ulong[1];

        ctx.ModExp(baseVal, exp, result);

        Assert.That(result[0], Is.EqualTo(1UL)); // a^0 = 1
    }

    [Test]
    public void ModExpOneExponent()
    {
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> baseVal = stackalloc ulong[] { 13 };
        Span<ulong> exp = stackalloc ulong[] { 1 };
        Span<ulong> result = stackalloc ulong[1];

        ctx.ModExp(baseVal, exp, result);

        Assert.That(result[0], Is.EqualTo(13UL)); // a^1 = a
    }

    [Test]
    public void ModExpFermatsLittleTheorem()
    {
        // For prime p, a^(p-1) ≡ 1 (mod p)
        ulong p = 65537;
        Span<ulong> m = stackalloc ulong[] { p };
        var ctx = new MontgomeryContext(m);

        Span<ulong> baseVal = stackalloc ulong[] { 12345 };
        Span<ulong> exp = stackalloc ulong[] { p - 1 };
        Span<ulong> result = stackalloc ulong[1];

        ctx.ModExp(baseVal, exp, result);

        Assert.That(result[0], Is.EqualTo(1UL));
    }

    [Test]
    public void ModExpLargerValues()
    {
        // Use a 128-bit modulus (2-limb)
        // m = 2^127 - 1
        ulong[] mArr = [ulong.MaxValue, long.MaxValue];
        var ctx = new MontgomeryContext(mArr);

        ulong[] baseArr = [0xDEADBEEFCAFEBABEUL, 0];
        ulong[] expArr = [7, 0];

        Span<ulong> result = stackalloc ulong[2];
        ctx.ModExp(baseArr, expArr, result);

        BigInteger mBig = ToBigInteger(mArr);
        BigInteger expected = BigInteger.ModPow(0xDEADBEEFCAFEBABEUL, 7, mBig);
        Assert.That(ToBigInteger(result), Is.EqualTo(expected));
    }

    [Test]
    public void ModExpCrossValidateWithBigInteger()
    {
        // 4-limb modulus (256-bit) — RSA-like size (small)
        ulong[] mArr = [0xFFFFFFFFFFFFFFC5, 0xFFFFFFFFFFFFFFFF, 0xFFFFFFFFFFFFFFFF, 0x7FFFFFFFFFFFFFFF];
        var ctx = new MontgomeryContext(mArr);

        ulong[] baseArr = [0xA5A5A5A5A5A5A5A5, 0x5A5A5A5A5A5A5A5A, 0, 0];
        ulong[] expArr = [65537, 0, 0, 0];

        Span<ulong> result = stackalloc ulong[4];
        ctx.ModExp(baseArr, expArr, result);

        BigInteger mBig = ToBigInteger(mArr);
        BigInteger baseBig = ToBigInteger(baseArr);
        BigInteger expected = BigInteger.ModPow(baseBig, 65537, mBig);
        Assert.That(ToBigInteger(result), Is.EqualTo(expected));
    }

    // ========================================================================
    // ModAdd / ModSub
    // ========================================================================

    [Test]
    public void ModAddNoWrap()
    {
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 5 };
        Span<ulong> b = stackalloc ulong[] { 7 };
        Span<ulong> r = stackalloc ulong[1];

        ctx.ModAdd(a, b, r);
        Assert.That(r[0], Is.EqualTo(12UL)); // 5 + 7 = 12 < 17
    }

    [Test]
    public void ModAddWithWrap()
    {
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 10 };
        Span<ulong> b = stackalloc ulong[] { 15 };
        Span<ulong> r = stackalloc ulong[1];

        ctx.ModAdd(a, b, r);
        Assert.That(r[0], Is.EqualTo(8UL)); // (10 + 15) mod 17 = 8
    }

    [Test]
    public void ModSubNoWrap()
    {
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 15 };
        Span<ulong> b = stackalloc ulong[] { 10 };
        Span<ulong> r = stackalloc ulong[1];

        ctx.ModSub(a, b, r);
        Assert.That(r[0], Is.EqualTo(5UL));
    }

    [Test]
    public void ModSubWithWrap()
    {
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 3 };
        Span<ulong> b = stackalloc ulong[] { 10 };
        Span<ulong> r = stackalloc ulong[1];

        ctx.ModSub(a, b, r);
        Assert.That(r[0], Is.EqualTo(10UL)); // (3 - 10) mod 17 = -7 mod 17 = 10
    }

    // ========================================================================
    // Edge Cases
    // ========================================================================

    [Test]
    public void EvenModulusThrows()
    {
        ulong[] m = [16];
        Assert.Throws<ArgumentException>(() => _ = new MontgomeryContext(m));
    }

    [Test]
    public void ModExpBaseZero()
    {
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> baseVal = stackalloc ulong[] { 0 };
        Span<ulong> exp = stackalloc ulong[] { 5 };
        Span<ulong> result = stackalloc ulong[1];

        ctx.ModExp(baseVal, exp, result);
        Assert.That(result[0], Is.EqualTo(0UL)); // 0^5 = 0
    }

    [Test]
    public void MontMulByZero()
    {
        Span<ulong> m = stackalloc ulong[] { 17 };
        var ctx = new MontgomeryContext(m);

        Span<ulong> a = stackalloc ulong[] { 7 };
        Span<ulong> zero = stackalloc ulong[] { 0 };

        Span<ulong> aMont = stackalloc ulong[1];
        Span<ulong> zeroMont = stackalloc ulong[1];
        Span<ulong> cMont = stackalloc ulong[1];
        Span<ulong> c = stackalloc ulong[1];

        ctx.ToMontgomery(a, aMont);
        ctx.ToMontgomery(zero, zeroMont);
        ctx.MontMul(aMont, zeroMont, cMont);
        ctx.FromMontgomery(cMont, c);

        Assert.That(c[0], Is.EqualTo(0UL));
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
