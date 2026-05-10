// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1872 // Prefer 'System.Convert.ToHexString(byte[])' over call chains based on 'System.BitConverter.ToString(byte[])'

namespace Cryptography.Tests.Asymmetric.EC;

using System;
using System.Numerics;
using Sys = System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Rng;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using NUnit.Framework;
using CH = CryptoHives.Foundation.Security.Cryptography;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Ed25519Tests
{
    // ========================================================================
    // RFC 8032 §7.1 Test Vectors
    // ========================================================================

    [Test]
    public void Rfc8032Vector1PublicKey()
    {
        // TEST 1 — empty message
        byte[] seed = TestHelpers.FromHexString(
            "9d61b19deffd5a60ba844af492ec2cc44449c5697b326919703bac031cae7f60");
        byte[] expectedPub = TestHelpers.FromHexString(
            "d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a");

        byte[] pubKey = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, pubKey);

        Assert.That(pubKey, Is.EqualTo(expectedPub));
    }

    [Test]
    public void Rfc8032Vector1Sign()
    {
        byte[] seed = TestHelpers.FromHexString(
            "9d61b19deffd5a60ba844af492ec2cc44449c5697b326919703bac031cae7f60");
        byte[] message = Array.Empty<byte>();
        byte[] expectedSig = TestHelpers.FromHexString(
            "e5564300c360ac729086e2cc806e828a84877f1eb8e5d974d873e06522490155" +
            "5fb8821590a33bacc61e39701cf9b46bd25bf5f0595bbe24655141438e7a100b");

        byte[] sig = Ed25519.Sign(seed, message);

        Assert.That(sig, Is.EqualTo(expectedSig),
            $"Sig mismatch!\nGot:      {BitConverter.ToString(sig).Replace("-", "").ToLower()}\nExpected: e5564300c360ac729086e2cc806e828a84877f1eb8e5d974d873e065224901555fb8821590a33bacc61e39701cf9b46bd25bf5f0595bbe24655141438e7a100b");
    }

    [Test]
    public void SignAndPublicKeyConsistency()
    {
        byte[] seed = TestHelpers.FromHexString(
            "9d61b19deffd5a60ba844af492ec2cc44449c5697b326919703bac031cae7f60");

        // Get our public key
        byte[] pubKey = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, pubKey);
        string pubKeyHex = BitConverter.ToString(pubKey).Replace("-", "").ToLower();

        // RFC expected
        byte[] rfcPubKey = TestHelpers.FromHexString(
            "d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a");

        // BouncyCastle
        var bcPriv = new Org.BouncyCastle.Crypto.Parameters.Ed25519PrivateKeyParameters(seed);
        byte[] bcPubKey = bcPriv.GeneratePublicKey().GetEncoded();
        string bcPubHex = BitConverter.ToString(bcPubKey).Replace("-", "").ToLower();

        // Triple comparison
        Assert.That(bcPubKey, Is.EqualTo(rfcPubKey),
            $"BC doesn't match RFC!\nBC:  {bcPubHex}\nRFC: d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a");

        Assert.That(pubKey, Is.EqualTo(rfcPubKey),
            $"Our pubKey doesn't match RFC!\nOurs: {pubKeyHex}\nRFC:  d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a\nBC:   {bcPubHex}");
    }

    [Test]
    public void Rfc8032Vector1Verify()
    {
        byte[] pubKey = TestHelpers.FromHexString(
            "d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a");
        byte[] message = Array.Empty<byte>();
        byte[] sig = TestHelpers.FromHexString(
            "e5564300c360ac729086e2cc806e828a84877f1eb8e5d974d873e06522490155" +
            "5fb8821590a33bacc61e39701cf9b46bd25bf5f0595bbe24655141438e7a100b");

        bool valid = Ed25519.Verify(pubKey, message, sig);
        Assert.That(valid, Is.True);
    }

    [Test]
    public void Rfc8032Vector2PublicKey()
    {
        // TEST 2 — single-byte message 0x72
        byte[] seed = TestHelpers.FromHexString(
            "4ccd089b28ff96da9db6c346ec114e0f5b8a319f35aba624da8cf6ed4fb8a6fb");
        byte[] expectedPub = TestHelpers.FromHexString(
            "3d4017c3e843895a92b70aa74d1b7ebc9c982ccf2ec4968cc0cd55f12af4660c");

        byte[] pubKey = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, pubKey);

        Assert.That(pubKey, Is.EqualTo(expectedPub));
    }

    [Test]
    public void Rfc8032Vector2Sign()
    {
        byte[] seed = TestHelpers.FromHexString(
            "4ccd089b28ff96da9db6c346ec114e0f5b8a319f35aba624da8cf6ed4fb8a6fb");
        byte[] message = [0x72];
        byte[] expectedSig = TestHelpers.FromHexString(
            "92a009a9f0d4cab8720e820b5f642540a2b27b5416503f8fb3762223ebdb69da" +
            "085ac1e43e15996e458f3613d0f11d8c387b2eaeb4302aeeb00d291612bb0c00");

        byte[] sig = Ed25519.Sign(seed, message);
        Assert.That(sig, Is.EqualTo(expectedSig),
            $"Sig mismatch!\nGot:      {BitConverter.ToString(sig).Replace("-", "").ToLower()}\nExpected: 92a009a9f0d4cab8720e820b5f642540a2b27b5416503f8fb3762223ebdb69da085ac1e43e15996e458f3613d0f11d8c387b2eaeb4302aeeb00d291612bb0c00");
    }

    [Test]
    public void Rfc8032Vector2Verify()
    {
        byte[] pubKey = TestHelpers.FromHexString(
            "3d4017c3e843895a92b70aa74d1b7ebc9c982ccf2ec4968cc0cd55f12af4660c");
        byte[] message = [0x72];
        byte[] sig = TestHelpers.FromHexString(
            "92a009a9f0d4cab8720e820b5f642540a2b27b5416503f8fb3762223ebdb69da" +
            "085ac1e43e15996e458f3613d0f11d8c387b2eaeb4302aeeb00d291612bb0c00");

        bool valid = Ed25519.Verify(pubKey, message, sig);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Sign / Verify Round-Trip
    // ========================================================================

    [Test]
    public void SignVerifyRoundTrip()
    {
        byte[] seed = new byte[32];
        RandomNumberGenerator.Fill(seed);

        byte[] pubKey = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, pubKey);

        byte[] message = "Hello, Ed25519!"u8.ToArray();
        byte[] sig = Ed25519.Sign(seed, message);

        bool valid = Ed25519.Verify(pubKey, message, sig);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Tampered Message / Signature
    // ========================================================================

    [Test]
    public void TamperedMessageFails()
    {
        byte[] seed = new byte[32];
        RandomNumberGenerator.Fill(seed);

        byte[] pubKey = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, pubKey);

        byte[] message = "Original message"u8.ToArray();
        byte[] sig = Ed25519.Sign(seed, message);

        byte[] tampered = "Tampered message"u8.ToArray();
        bool valid = Ed25519.Verify(pubKey, tampered, sig);
        Assert.That(valid, Is.False);
    }

    [Test]
    public void TamperedSignatureFails()
    {
        byte[] seed = new byte[32];
        RandomNumberGenerator.Fill(seed);

        byte[] pubKey = new byte[32];
        Ed25519.PublicKeyFromSeed(seed, pubKey);

        byte[] message = "Test message"u8.ToArray();
        byte[] sig = Ed25519.Sign(seed, message);

        sig[0] ^= 1;
        bool valid = Ed25519.Verify(pubKey, message, sig);
        Assert.That(valid, Is.False);
    }

    [Test]
    public void ScalarDerivationFromSeed()
    {
        // Verify the SHA-512 hash and clamped scalar for test vector 1
        byte[] seed = TestHelpers.FromHexString(
            "9d61b19deffd5a60ba844af492ec2cc44449c5697b326919703bac031cae7f60");

        using var hasher = CH.Hash.SHA512.Create();
        byte[] hash = hasher.ComputeHash(seed);

        // Clamp
        byte[] scalar = new byte[32];
        Array.Copy(hash, 0, scalar, 0, 32);
        scalar[0] &= 248;
        scalar[31] &= 127;
        scalar[31] |= 64;
        string scalarHex = BitConverter.ToString(scalar).Replace("-", "").ToLower();

        // Expected clamped scalar from prior test
        string expected = "307c83864f2833cb427a2ef1c00a013cfdff2768d980c0a3a520f006904de94f";
        Assert.That(scalarHex, Is.EqualTo(expected),
            $"Clamped scalar mismatch!\nGot:      {scalarHex}\nExpected: {expected}");

        // Cross-validate with BouncyCastle Ed25519
        var bcSigner = new Org.BouncyCastle.Crypto.Signers.Ed25519Signer();
        var bcPrivKey = new Org.BouncyCastle.Crypto.Parameters.Ed25519PrivateKeyParameters(seed);
        byte[] bcPub = bcPrivKey.GeneratePublicKey().GetEncoded();
        string bcPubHex = BitConverter.ToString(bcPub).Replace("-", "").ToLower();

        byte[] rfcExpected = TestHelpers.FromHexString(
            "d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a");
        Assert.That(bcPub, Is.EqualTo(rfcExpected),
            $"BouncyCastle doesn't match RFC (sanity):\n{bcPubHex}");

        // Now check BigInteger reference
        byte[] refResult = BigIntRefScalarMulBase(scalar);
        string refHex = BitConverter.ToString(refResult).Replace("-", "").ToLower();

        Assert.That(refResult, Is.EqualTo(rfcExpected),
            $"BigInt ref doesn't match RFC!\nBigInt:  {refHex}\nRFC:     d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a\nBCastle: {bcPubHex}");
    }

    // ========================================================================
    // Diagnostics: Base Point Multiplication
    // ========================================================================

    [Test]
    public void ScalarMulBaseByOne()
    {
        // [1]*B should encode as the base point
        Span<ulong> k = stackalloc ulong[4];
        k[0] = 1;
        byte[] result = new byte[32];
        Ed25519.ScalarMulBaseEncoded(k, result);

        // By = 0x6666666666666666666666666666666666666666666666666666666666666658
        // In LE: 58 66 66 ... 66 66
        // Bx low bit = 0, so sign bit = 0
        byte[] expected = new byte[32];
        expected[0] = 0x58;
        for (int i = 1; i < 32; i++) expected[i] = 0x66;

        Assert.That(result, Is.EqualTo(expected), $"Got: {BitConverter.ToString(result).Replace("-", "")}");
    }

    [Test]
    public void ScalarMulBaseByTwo()
    {
        // Known encoding of [2]*B on Ed25519:
        // c9a3f86aae465f0e56513864510f3997561fa2c9e85ea21dc2292309f3cd6022
        Span<ulong> k1 = stackalloc ulong[4];
        k1[0] = 2;
        byte[] r1 = new byte[32];
        Ed25519.ScalarMulBaseEncoded(k1, r1);
        string hex = BitConverter.ToString(r1).Replace("-", "").ToLower();

        byte[] expected2B = TestHelpers.FromHexString(
            "c9a3f86aae465f0e56513864510f3997561fa2c9e85ea21dc2292309f3cd6022");
        Assert.That(r1, Is.EqualTo(expected2B),
            $"[2]*B mismatch!\nGot:      {hex}\nExpected: c9a3f86aae465f0e56513864510f3997561fa2c9e85ea21dc2292309f3cd6022");
    }

    [Test]
    public void ScalarMulBaseWithTestVector1Scalar()
    {
        // The clamped scalar for RFC 8032 test vector 1 seed
        byte[] scalarBytes = TestHelpers.FromHexString(
            "307c83864f2833cb427a2ef1c00a013cfdff2768d980c0a3a520f006904de94f");
        Span<ulong> k = stackalloc ulong[4];
        X25519.FromLittleEndianBytes(scalarBytes, k);
        byte[] result = new byte[32];
        Ed25519.ScalarMulBaseEncoded(k, result);

        // Cross-validate with BigInteger reference
        byte[] refResult = BigIntRefScalarMulBase(scalarBytes);
        Assert.That(result, Is.EqualTo(refResult),
            $"Managed: {BitConverter.ToString(result).Replace("-", "").ToLower()}\n" +
            $"BigInt:  {BitConverter.ToString(refResult).Replace("-", "").ToLower()}");

        // Also check against the RFC expected public key
        byte[] rfcExpected = TestHelpers.FromHexString(
            "d75a980182b10ab7d54bfed3c964073a0ee172f3daa62325af021a68f707511a");
        Assert.That(result, Is.EqualTo(rfcExpected),
            $"Managed output doesn't match RFC!\n" +
            $"Got: {BitConverter.ToString(result).Replace("-", "").ToLower()}");
    }

    [Test]
    public void ScalarMulBaseGroupOrderReturnsIdentity()
    {
        // [L]*B should be the identity point (0, 1)
        byte[] orderBytes = TestHelpers.FromHexString(
            "edd3f55c1a631258d69cf7a2def9de1400000000000000000000000000000010");
        Span<ulong> k = stackalloc ulong[4];
        X25519.FromLittleEndianBytes(orderBytes, k);
        byte[] result = new byte[32];
        Ed25519.ScalarMulBaseEncoded(k, result);

        byte[] identity = new byte[32];
        identity[0] = 1;
        Assert.That(result, Is.EqualTo(identity),
            $"[L]*B should be identity!\nGot: {BitConverter.ToString(result).Replace("-", "").ToLower()}");
    }

    [Test]
    public void ScalarMulBaseLMinus1ReturnsNegB()
    {
        // [L-1]*B should be -B = (-Bx, By), encoded as By with sign bit set
        byte[] orderBytes = TestHelpers.FromHexString(
            "edd3f55c1a631258d69cf7a2def9de1400000000000000000000000000000010");
        // L - 1 in LE
        byte[] lMinus1 = (byte[])orderBytes.Clone();
        lMinus1[0] -= 1; // Subtract 1 from LE value (no borrow since lowest byte is 0xED)

        Span<ulong> k = stackalloc ulong[4];
        X25519.FromLittleEndianBytes(lMinus1, k);
        byte[] result = new byte[32];
        Ed25519.ScalarMulBaseEncoded(k, result);

        // -B has same y as B but x sign bit set
        // B encodes as: 5866666666666666666666666666666666666666666666666666666666666666
        // -B encodes as: 58666666666666666666666666666666666666666666666666666666666666e6
        byte[] negB = TestHelpers.FromHexString(
            "58666666666666666666666666666666666666666666666666666666666666e6");
        Assert.That(result, Is.EqualTo(negB),
            $"[L-1]*B should be -B!\nGot: {BitConverter.ToString(result).Replace("-", "").ToLower()}");
    }

    [Test]
    public void BigIntScalarMulBaseGroupOrderReturnsIdentity()
    {
        // Verify BigInteger reference also gives identity for [L]*B
        byte[] orderBytes = TestHelpers.FromHexString(
            "edd3f55c1a631258d69cf7a2def9de1400000000000000000000000000000010");
        byte[] result = BigIntRefScalarMulBase(orderBytes);

        byte[] identity = new byte[32];
        identity[0] = 1;
        Assert.That(result, Is.EqualTo(identity),
            $"BigInt [L]*B should be identity!\nGot: {BitConverter.ToString(result).Replace("-", "").ToLower()}");
    }

    [Test]
    public void ScalarMulBaseSmallScalarsCrossValidate()
    {
        // First verify the base point is on the curve
        BigInteger bx2 = RefBx * RefBx % RefP;
        BigInteger by2 = RefBy * RefBy % RefP;
        BigInteger lhs = ((-bx2 + by2) % RefP + RefP) % RefP;
        BigInteger dxy2 = RefD * bx2 % RefP;
        dxy2 = dxy2 * by2 % RefP;
        BigInteger rhs = (1 + dxy2) % RefP;
        Assert.That(lhs, Is.EqualTo(rhs), "Base point not on curve!");

        // Verify By = 4/5 mod p
        Assert.That((5 * RefBy) % RefP, Is.EqualTo(new BigInteger(4)),
            $"By is not 4/5 mod p! 5*By mod p = {(5 * RefBy) % RefP}");

        // Verify Bx is the positive root (even)
        Assert.That(RefBx.IsEven, Is.True, "Bx should be even (positive root)");

        Span<ulong> k = stackalloc ulong[4];
        foreach (ulong scalar in new ulong[] { 1, 2, 3, 7, 15, 100, 1000 })
        {
            byte[] scalarBytes = new byte[32];
            scalarBytes[0] = (byte)(scalar & 0xFF);
            if (scalar > 255) scalarBytes[1] = (byte)((scalar >> 8) & 0xFF);

            X25519.FromLittleEndianBytes(scalarBytes, k);
            byte[] result = new byte[32];
            Ed25519.ScalarMulBaseEncoded(k, result);

            byte[] refResult = BigIntRefScalarMulBase(scalarBytes);
            Assert.That(result, Is.EqualTo(refResult),
                $"Failed for scalar {scalar}:\n" +
                $"Managed: {BitConverter.ToString(result).Replace("-", "").ToLower()}\n" +
                $"BigInt:  {BitConverter.ToString(refResult).Replace("-", "").ToLower()}");
        }
    }

    // ========================================================================
    // BigInteger Reference Implementation
    // ========================================================================

    private static readonly BigInteger RefP = BigInteger.Pow(2, 255) - 19;

    // d = -121665/121666 mod p
    private static readonly BigInteger RefD = BigIntegerFromLittleEndianUnsigned(
        new byte[]
        {
            0xA3, 0x78, 0x59, 0x13, 0xCA, 0x4D, 0xEB, 0x75,
            0xAB, 0xD8, 0x41, 0x41, 0x4D, 0x0A, 0x70, 0x00,
            0x98, 0xE8, 0x79, 0x77, 0x79, 0x40, 0xC7, 0x8C,
            0x73, 0xFE, 0x6F, 0x2B, 0xEE, 0x6C, 0x03, 0x52
        });

    private static readonly BigInteger RefBx = BigIntegerFromLittleEndianUnsigned(
        new byte[]
        {
            0x1A, 0xD5, 0x25, 0x8F, 0x60, 0x2D, 0x56, 0xC9,
            0xB2, 0xA7, 0x25, 0x95, 0x60, 0xC7, 0x2C, 0x69,
            0x5C, 0xDC, 0xD6, 0xFD, 0x31, 0xE2, 0xA4, 0xC0,
            0xFE, 0x53, 0x6E, 0xCD, 0xD3, 0x36, 0x69, 0x21
        });

    private static readonly BigInteger RefBy = BigIntegerFromLittleEndianUnsigned(
        new byte[]
        {
            0x58, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66,
            0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66,
            0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66,
            0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66, 0x66
        });

    private static byte[] BigIntRefScalarMulBase(byte[] scalarLE)
    {
        BigInteger s = BigIntegerFromLittleEndianUnsigned(scalarLE);
        var (rx, ry) = BigIntScalarMul(s, (RefBx, RefBy));

        byte[] yBytes = BigIntegerToLittleEndianUnsigned(ry);
        byte[] encoded = new byte[32];
        Array.Copy(yBytes, encoded, Math.Min(yBytes.Length, 32));
        if (!rx.IsEven) encoded[31] |= 0x80;
        return encoded;
    }

    private static BigInteger BigIntegerFromLittleEndianUnsigned(byte[] value)
    {
#if NET8_0_OR_GREATER
        return new BigInteger(value, isUnsigned: true, isBigEndian: false);
#else
        byte[] tmp = new byte[value.Length + 1];
        Buffer.BlockCopy(value, 0, tmp, 0, value.Length);
        return new BigInteger(tmp);
#endif
    }

    private static byte[] BigIntegerToLittleEndianUnsigned(BigInteger value)
    {
#if NET8_0_OR_GREATER
        return value.ToByteArray(isUnsigned: true, isBigEndian: false);
#else
        byte[] bytes = value.ToByteArray();
        if (bytes.Length > 1 && bytes[^1] == 0)
        {
            byte[] trimmed = new byte[bytes.Length - 1];
            Buffer.BlockCopy(bytes, 0, trimmed, 0, trimmed.Length);
            return trimmed;
        }

        return bytes;
#endif
    }
    private static (BigInteger x, BigInteger y) BigIntScalarMul(
        BigInteger k, (BigInteger x, BigInteger y) point)
    {
        var result = (x: BigInteger.Zero, y: BigInteger.One); // identity
        var temp = point;
        while (k > 0)
        {
            if (!k.IsEven)
                result = BigIntPointAdd(result, temp);
            temp = BigIntPointAdd(temp, temp);
            k >>= 1;
        }

        return result;
    }

    private static (BigInteger x, BigInteger y) BigIntPointAdd(
        (BigInteger x, BigInteger y) p1, (BigInteger x, BigInteger y) p2)
    {
        // -x² + y² = 1 + dx²y²
        // x3 = (x1y2 + y1x2) / (1 + dx1x2y1y2)
        // y3 = (y1y2 + x1x2) / (1 - dx1x2y1y2)
        BigInteger x1 = p1.x, y1 = p1.y, x2 = p2.x, y2 = p2.y;
        BigInteger x1y2 = BigInteger.Remainder(x1 * y2, RefP);
        BigInteger y1x2 = BigInteger.Remainder(y1 * x2, RefP);
        BigInteger y1y2 = BigInteger.Remainder(y1 * y2, RefP);
        BigInteger x1x2 = BigInteger.Remainder(x1 * x2, RefP);
        BigInteger dxy = BigInteger.Remainder(RefD * x1x2 % RefP * y1y2, RefP);

        BigInteger numX = (x1y2 + y1x2) % RefP;
        BigInteger denX = (1 + dxy + RefP) % RefP;
        BigInteger numY = (y1y2 + x1x2) % RefP;
        BigInteger denY = (1 - dxy + RefP) % RefP;

        BigInteger denXInv = BigInteger.ModPow(denX, RefP - 2, RefP);
        BigInteger denYInv = BigInteger.ModPow(denY, RefP - 2, RefP);

        BigInteger x3 = BigInteger.Remainder(numX * denXInv, RefP);
        BigInteger y3 = BigInteger.Remainder(numY * denYInv, RefP);

        return ((x3 + RefP) % RefP, (y3 + RefP) % RefP);
    }
}

