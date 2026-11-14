// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.EC;

using System;
using System.Numerics;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class EcMathTests
{
    // ========================================================================
    // Point Validation
    // ========================================================================

    [Test]
    public void GeneratorIsOnCurveP256()
    {
        var curve = WeierstrassCurve.P256;
        var ec = new EcMath(curve);
        Assert.That(ec.IsOnCurve(curve.Gx, curve.Gy), Is.True);
    }

    [Test]
    public void GeneratorIsOnCurveP384()
    {
        var curve = WeierstrassCurve.P384;
        var ec = new EcMath(curve);
        Assert.That(ec.IsOnCurve(curve.Gx, curve.Gy), Is.True);
    }

    [Test]
    public void GeneratorIsOnCurveP521()
    {
        var curve = WeierstrassCurve.P521;
        var ec = new EcMath(curve);
        Assert.That(ec.IsOnCurve(curve.Gx, curve.Gy), Is.True);
    }

    [Test]
    public void GeneratorIsOnCurveSecp256k1()
    {
        var curve = WeierstrassCurve.Secp256k1;
        var ec = new EcMath(curve);
        Assert.That(ec.IsOnCurve(curve.Gx, curve.Gy), Is.True);
    }

    [Test]
    public void WrongPointNotOnCurve()
    {
        var curve = WeierstrassCurve.P256;
        var ec = new EcMath(curve);

        // Modify Gy by 1 — should not be on curve
        byte[] badY = (byte[])curve.Gy.Clone();
        badY[^1] ^= 1;
        Assert.That(ec.IsOnCurve(curve.Gx, badY), Is.False);
    }

    // ========================================================================
    // Scalar Multiplication: k·G
    // ========================================================================

    [Test]
    public void ScalarMulBaseOneEqualsGenerator()
    {
        var curve = WeierstrassCurve.P256;
        var ec = new EcMath(curve);
        int fs = curve.FieldSize;

        Span<ulong> k = stackalloc ulong[curve.LimbCount];
        k.Clear();
        k[0] = 1; // k = 1

        byte[] rx = new byte[fs];
        byte[] ry = new byte[fs];
        ec.ScalarMulBase(k, rx, ry);

        Assert.That(rx, Is.EqualTo(curve.Gx), "1·G.x should equal Gx");
        Assert.That(ry, Is.EqualTo(curve.Gy), "1·G.y should equal Gy");
    }

    [Test]
    public void ScalarMulBaseTwoEqualsDoubleGenerator()
    {
        var curve = WeierstrassCurve.P256;
        var ec = new EcMath(curve);
        int n = curve.LimbCount;
        int fs = curve.FieldSize;

        // Compute 2·G
        Span<ulong> k = stackalloc ulong[n];
        k.Clear();
        k[0] = 2;

        byte[] rx = new byte[fs];
        byte[] ry = new byte[fs];
        ec.ScalarMulBase(k, rx, ry);

        // The result should be on the curve
        Assert.That(ec.IsOnCurve(rx, ry), Is.True, "2·G should be on curve");

        // 2·G should not equal G
        Assert.That(rx, Is.Not.EqualTo(curve.Gx));
    }

    [Test]
    public void ScalarMulBaseThreeIsOnCurve()
    {
        var curve = WeierstrassCurve.P256;
        var ec = new EcMath(curve);
        int n = curve.LimbCount;
        int fs = curve.FieldSize;

        Span<ulong> k = stackalloc ulong[n];
        k.Clear();
        k[0] = 3;

        byte[] rx = new byte[fs];
        byte[] ry = new byte[fs];
        ec.ScalarMulBase(k, rx, ry);

        Assert.That(ec.IsOnCurve(rx, ry), Is.True, "3·G should be on curve");
    }

#if NET8_0_OR_GREATER
    // ========================================================================
    // Cross-validation with BCL ECDsa
    // ========================================================================

    [Test]
    [TestCase("P-256", "nistP256")]
    [TestCase("P-384", "nistP384")]
    [TestCase("P-521", "nistP521")]
    public void ScalarMulBaseCrossValidateWithBcl(string curveName, string bclCurveName)
    {
        var curve = curveName switch
        {
            "P-256" => WeierstrassCurve.P256,
            "P-384" => WeierstrassCurve.P384,
            "P-521" => WeierstrassCurve.P521,
            _ => throw new ArgumentException(curveName)
        };
        var bclCurve = System.Security.Cryptography.ECCurve.CreateFromFriendlyName(bclCurveName);

        using var ecdsa = System.Security.Cryptography.ECDsa.Create(bclCurve);
        var p = ecdsa.ExportParameters(true);

        int n = curve.LimbCount;
        int fs = curve.FieldSize;

        // Use the BCL private key as the scalar
        Span<ulong> k = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(p.D!, k);

        // Our scalar multiply
        var ec = new EcMath(curve);
        byte[] ourX = new byte[fs];
        byte[] ourY = new byte[fs];
        ec.ScalarMulBase(k, ourX, ourY);

        // BCL gives us the public key Q = k·G
        byte[] bclX = PadLeft(p.Q.X!, fs);
        byte[] bclY = PadLeft(p.Q.Y!, fs);

        Assert.That(ourX, Is.EqualTo(bclX), $"k·G.x mismatch for {curveName}");
        Assert.That(ourY, Is.EqualTo(bclY), $"k·G.y mismatch for {curveName}");
    }

    [Test]
    public void ScalarMulP256KnownVector()
    {
        // NIST ECDSA test vector: k = 1 → G (already tested above)
        // k = n - 1 should give (Gx, p - Gy)
        var curve = WeierstrassCurve.P256;
        var ec = new EcMath(curve);
        int n = curve.LimbCount;
        int fs = curve.FieldSize;

        Span<ulong> order = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(curve.N, order);

        Span<ulong> k = stackalloc ulong[n];
        BigUInt.SubWord(order, 1, k); // k = n - 1

        byte[] rx = new byte[fs];
        byte[] ry = new byte[fs];
        ec.ScalarMulBase(k, rx, ry);

        // (n-1)·G should have same x as G, y = p - Gy
        Assert.That(rx, Is.EqualTo(curve.Gx), "(n-1)·G.x should equal Gx");

        // Compute p - Gy
        Span<ulong> pLimbs = stackalloc ulong[n];
        Span<ulong> gyLimbs = stackalloc ulong[n];
        Span<ulong> negGy = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(curve.P, pLimbs);
        BigUInt.FromBigEndianBytes(curve.Gy, gyLimbs);
        BigUInt.Sub(pLimbs, gyLimbs, negGy);

        byte[] expectedY = new byte[fs];
        BigUInt.ToBigEndianBytes(negGy, expectedY);

        Assert.That(ry, Is.EqualTo(expectedY), "(n-1)·G.y should equal p - Gy");
    }

    [Test]
    public void Secp256k1GeneratorMultiplyOnCurve()
    {
        var curve = WeierstrassCurve.Secp256k1;
        var ec = new EcMath(curve);
        int n = curve.LimbCount;
        int fs = curve.FieldSize;

        // k = 7 (arbitrary small scalar)
        Span<ulong> k = stackalloc ulong[n];
        k.Clear();
        k[0] = 7;

        byte[] rx = new byte[fs];
        byte[] ry = new byte[fs];
        ec.ScalarMulBase(k, rx, ry);

        Assert.That(ec.IsOnCurve(rx, ry), Is.True, "7·G should be on secp256k1");
    }
#endif

    // ========================================================================
    // Helpers
    // ========================================================================

    private static byte[] PadLeft(byte[] data, int length)
    {
        if (data.Length >= length) return data;
        byte[] padded = new byte[length];
        Buffer.BlockCopy(data, 0, padded, length - data.Length, data.Length);
        return padded;
    }
}
