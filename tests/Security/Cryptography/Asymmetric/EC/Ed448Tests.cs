// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace Cryptography.Tests.Asymmetric.EC;

using System;
using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Ed448Tests
{
    // ========================================================================
    // RFC 8032 §7.4 Test Vectors
    // ========================================================================

    [Test]
    public void Rfc8032Vector1PublicKey()
    {
        byte[] seed = HexToBytes(
            "6c82a562cb808d10d632be89c8513ebf6c929f34ddfa8c9f63c9960ef6e348a" +
            "3528c8a3fcc2f044e39a3fc5b94492f8f032e7549a20098f95b");
        byte[] expectedPub = HexToBytes(
            "5fd7449b59b461fd2ce787ec616ad46a1da1342485a70e1f8a0ea75d80e96778" +
            "edf124769b46c7061bd6783df1e50f6cd1fa1abeafe8256180");

        byte[] pubKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, pubKey);

        Assert.That(pubKey, Is.EqualTo(expectedPub),
            $"PubKey mismatch!\nGot:      {BitConverter.ToString(pubKey).Replace("-","").ToLower()}\nExpected: 5fd7449b59b461fd2ce787ec616ad46a1da1342485a70e1f8a0ea75d80e96778edf124769b46c7061bd6783df1e50f6cd1fa1abeafe8256180");
    }

    [Test]
    public void Rfc8032Vector1Sign()
    {
        byte[] seed = HexToBytes(
            "6c82a562cb808d10d632be89c8513ebf6c929f34ddfa8c9f63c9960ef6e348a" +
            "3528c8a3fcc2f044e39a3fc5b94492f8f032e7549a20098f95b");
        byte[] message = Array.Empty<byte>();
        byte[] expectedSig = HexToBytes(
            "533a37f6bbe457251f023c0d88f976ae2dfb504a843e34d2074fd823d41a591f" +
            "2b233f034f628281f2fd7a22ddd47d7828c59bd0a21bfd3980ff0d2028d4b18a" +
            "9df63e006c5d1c2d345b925d8dc00b4104852db99ac5c7cdda8530a113a0f4db" +
            "b61149f05a7363268c71d95808ff2e652600");

        byte[] sig = Ed448.Sign(seed, message);

        Assert.That(sig, Is.EqualTo(expectedSig),
            $"Sig mismatch!\nGot:      {BitConverter.ToString(sig).Replace("-","").ToLower()}\nExpected: 533a37f6bbe457251f023c0d88f976ae2dfb504a843e34d2074fd823d41a591f2b233f034f628281f2fd7a22ddd47d7828c59bd0a21bfd3980ff0d2028d4b18a9df63e006c5d1c2d345b925d8dc00b4104852db99ac5c7cdda8530a113a0f4dbb61149f05a7363268c71d95808ff2e652600");
    }

    [Test]
    public void Rfc8032Vector1Verify()
    {
        byte[] pubKey = HexToBytes(
            "5fd7449b59b461fd2ce787ec616ad46a1da1342485a70e1f8a0ea75d80e96778" +
            "edf124769b46c7061bd6783df1e50f6cd1fa1abeafe8256180");
        byte[] message = Array.Empty<byte>();
        byte[] sig = HexToBytes(
            "533a37f6bbe457251f023c0d88f976ae2dfb504a843e34d2074fd823d41a591f" +
            "2b233f034f628281f2fd7a22ddd47d7828c59bd0a21bfd3980ff0d2028d4b18a" +
            "9df63e006c5d1c2d345b925d8dc00b4104852db99ac5c7cdda8530a113a0f4db" +
            "b61149f05a7363268c71d95808ff2e652600");

        bool valid = Ed448.Verify(pubKey, message, sig);
        Assert.That(valid, Is.True);
    }

    [Test]
    public void Rfc8032Vector2PublicKey()
    {
        byte[] seed = HexToBytes(
            "c4eab05d357007c632f3dbb48489924d552b08fe0c353a0d4a1f00acda2c463a" +
            "fbea67c5e8d2877c5e3bc397a659949ef8021e954e0a12274e");
        byte[] expectedPub = HexToBytes(
            "43ba28f430cdff456ae531545f7ecd0ac834a55d9358c0372bfa0c6c6798c086" +
            "6aea01eb00742802b8438ea4cb82169c235160627b4c3a9480");

        byte[] pubKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, pubKey);

        Assert.That(pubKey, Is.EqualTo(expectedPub),
            $"PubKey mismatch!\nGot:      {BitConverter.ToString(pubKey).Replace("-","").ToLower()}\nExpected: 43ba28f430cdff456ae531545f7ecd0ac834a55d9358c0372bfa0c6c6798c0866aea01eb00742802b8438ea4cb82169c235160627b4c3a9480");
    }

    [Test]
    public void Rfc8032Vector2Sign()
    {
        byte[] seed = HexToBytes(
            "c4eab05d357007c632f3dbb48489924d552b08fe0c353a0d4a1f00acda2c463a" +
            "fbea67c5e8d2877c5e3bc397a659949ef8021e954e0a12274e");
        byte[] message = [0x03];
        byte[] expectedSig = HexToBytes(
            "26b8f91727bd62897af15e41eb43c377efb9c610d48f2335cb0bd0087810f435" +
            "2541b143c4b981b7e18f62de8ccdf633fc1bf037ab7cd779805e0dbcc0aae1cb" +
            "cee1afb2e027df36bc04dcecbf154336c19f0af7e0a6472905e799f1953d2a0f" +
            "f3348ab21aa4adafd1d234441cf807c03a00");

        byte[] sig = Ed448.Sign(seed, message);

        Assert.That(sig, Is.EqualTo(expectedSig),
            $"Sig mismatch!\nGot:      {BitConverter.ToString(sig).Replace("-","").ToLower()}\nExpected: 26b8f91727bd62897af15e41eb43c377efb9c610d48f2335cb0bd0087810f4352541b143c4b981b7e18f62de8ccdf633fc1bf037ab7cd779805e0dbcc0aae1cbcee1afb2e027df36bc04dcecbf154336c19f0af7e0a6472905e799f1953d2a0ff3348ab21aa4adafd1d234441cf807c03a00");
    }

    [Test]
    public void Rfc8032Vector2Verify()
    {
        byte[] pubKey = HexToBytes(
            "43ba28f430cdff456ae531545f7ecd0ac834a55d9358c0372bfa0c6c6798c086" +
            "6aea01eb00742802b8438ea4cb82169c235160627b4c3a9480");
        byte[] message = [0x03];
        byte[] sig = HexToBytes(
            "26b8f91727bd62897af15e41eb43c377efb9c610d48f2335cb0bd0087810f435" +
            "2541b143c4b981b7e18f62de8ccdf633fc1bf037ab7cd779805e0dbcc0aae1cb" +
            "cee1afb2e027df36bc04dcecbf154336c19f0af7e0a6472905e799f1953d2a0f" +
            "f3348ab21aa4adafd1d234441cf807c03a00");

        bool valid = Ed448.Verify(pubKey, message, sig);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // BouncyCastle Cross-Validation
    // ========================================================================

    [Test]
    public void BouncyCastlePublicKeyCrossValidation()
    {
        byte[] seed = HexToBytes(
            "6c82a562cb808d10d632be89c8513ebf6c929f34ddfa8c9f63c9960ef6e348a" +
            "3528c8a3fcc2f044e39a3fc5b94492f8f032e7549a20098f95b");

        byte[] ourPubKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, ourPubKey);

        var bcPriv = new Org.BouncyCastle.Crypto.Parameters.Ed448PrivateKeyParameters(seed);
        byte[] bcPubKey = bcPriv.GeneratePublicKey().GetEncoded();

        Assert.That(ourPubKey, Is.EqualTo(bcPubKey),
            $"Public key mismatch vs BouncyCastle!\nOurs: {BitConverter.ToString(ourPubKey).Replace("-","").ToLower()}\nBC:   {BitConverter.ToString(bcPubKey).Replace("-","").ToLower()}");
    }

    [Test]
    public void BouncyCastleSignCrossValidation()
    {
        byte[] seed = HexToBytes(
            "6c82a562cb808d10d632be89c8513ebf6c929f34ddfa8c9f63c9960ef6e348a" +
            "3528c8a3fcc2f044e39a3fc5b94492f8f032e7549a20098f95b");
        byte[] message = "Hello, Ed448!"u8.ToArray();

        byte[] ourSig = Ed448.Sign(seed, message);

        // Verify our signature with BouncyCastle
        var bcPriv = new Org.BouncyCastle.Crypto.Parameters.Ed448PrivateKeyParameters(seed);
        var bcPub = bcPriv.GeneratePublicKey();
        var bcSigner = new Org.BouncyCastle.Crypto.Signers.Ed448Signer(Array.Empty<byte>());
        bcSigner.Init(false, bcPub);
        bcSigner.BlockUpdate(message, 0, message.Length);
        bool bcValid = bcSigner.VerifySignature(ourSig);

        Assert.That(bcValid, Is.True,
            $"BouncyCastle rejected our signature!\nSig: {BitConverter.ToString(ourSig).Replace("-","").ToLower()}");
    }

    [Test]
    public void BouncyCastleVerifyCrossValidation()
    {
        byte[] seed = HexToBytes(
            "c4eab05d357007c632f3dbb48489924d552b08fe0c353a0d4a1f00acda2c463a" +
            "fbea67c5e8d2877c5e3bc397a659949ef8021e954e0a12274e");
        byte[] message = "Cross-validation test"u8.ToArray();

        // Sign with BouncyCastle
        var bcPriv = new Org.BouncyCastle.Crypto.Parameters.Ed448PrivateKeyParameters(seed);
        var bcSigner = new Org.BouncyCastle.Crypto.Signers.Ed448Signer(Array.Empty<byte>());
        bcSigner.Init(true, bcPriv);
        bcSigner.BlockUpdate(message, 0, message.Length);
        byte[] bcSig = bcSigner.GenerateSignature();

        // Verify with our implementation
        byte[] pubKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, pubKey);
        bool valid = Ed448.Verify(pubKey, message, bcSig);

        Assert.That(valid, Is.True,
            $"Our Verify rejected BouncyCastle's signature!\nSig: {BitConverter.ToString(bcSig).Replace("-","").ToLower()}");
    }

    // ========================================================================
    // Sign / Verify Round-Trip
    // ========================================================================

    [Test]
    public void SignVerifyRoundTrip()
    {
        byte[] seed = new byte[57];
        RandomNumberGenerator.Fill(seed);

        byte[] pubKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, pubKey);

        byte[] message = "Hello, Ed448!"u8.ToArray();
        byte[] sig = Ed448.Sign(seed, message);

        bool valid = Ed448.Verify(pubKey, message, sig);
        Assert.That(valid, Is.True);
    }

    [Test]
    public void SignVerifyRoundTripEmptyMessage()
    {
        byte[] seed = new byte[57];
        RandomNumberGenerator.Fill(seed);

        byte[] pubKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, pubKey);

        byte[] sig = Ed448.Sign(seed, Array.Empty<byte>());
        bool valid = Ed448.Verify(pubKey, Array.Empty<byte>(), sig);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Tampered Message / Signature
    // ========================================================================

    [Test]
    public void TamperedMessageFails()
    {
        byte[] seed = new byte[57];
        RandomNumberGenerator.Fill(seed);

        byte[] pubKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, pubKey);

        byte[] message = "Original message"u8.ToArray();
        byte[] sig = Ed448.Sign(seed, message);

        byte[] tampered = "Tampered message"u8.ToArray();
        bool valid = Ed448.Verify(pubKey, tampered, sig);
        Assert.That(valid, Is.False);
    }

    [Test]
    public void TamperedSignatureFails()
    {
        byte[] seed = new byte[57];
        RandomNumberGenerator.Fill(seed);

        byte[] pubKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, pubKey);

        byte[] message = "Test message"u8.ToArray();
        byte[] sig = Ed448.Sign(seed, message);

        sig[0] ^= 1;
        bool valid = Ed448.Verify(pubKey, message, sig);
        Assert.That(valid, Is.False);
    }

    [Test]
    public void TamperedPublicKeyFails()
    {
        byte[] seed = new byte[57];
        RandomNumberGenerator.Fill(seed);

        byte[] pubKey = new byte[57];
        Ed448.PublicKeyFromSeed(seed, pubKey);

        byte[] message = "Test message"u8.ToArray();
        byte[] sig = Ed448.Sign(seed, message);

        pubKey[0] ^= 1;
        bool valid = Ed448.Verify(pubKey, message, sig);
        Assert.That(valid, Is.False);
    }

    // ========================================================================
    // Base Point Tests
    // ========================================================================

    [Test]
    public void ScalarMulBaseByOne()
    {
        // [1]*B should encode as the base point B
        Span<ulong> k = stackalloc ulong[7];
        k[0] = 1;
        byte[] result = new byte[57];
        Ed448.ScalarMulBaseEncoded(k, result);

        // Cross-validate with BigInteger reference
        byte[] scalarBytes = new byte[56];
        scalarBytes[0] = 1;
        byte[] refResult = BigIntRefScalarMulBase(scalarBytes);

        Assert.That(result, Is.EqualTo(refResult),
            $"[1]*B mismatch!\nGot:    {BitConverter.ToString(result).Replace("-","").ToLower()}\nBigInt: {BitConverter.ToString(refResult).Replace("-","").ToLower()}");
    }

    [Test]
    public void ScalarMulBaseByTwo()
    {
        Span<ulong> k = stackalloc ulong[7];
        k[0] = 2;
        byte[] result = new byte[57];
        Ed448.ScalarMulBaseEncoded(k, result);

        byte[] scalarBytes = new byte[56];
        scalarBytes[0] = 2;
        byte[] refResult = BigIntRefScalarMulBase(scalarBytes);

        Assert.That(result, Is.EqualTo(refResult),
            $"[2]*B mismatch!\nGot:    {BitConverter.ToString(result).Replace("-","").ToLower()}\nBigInt: {BitConverter.ToString(refResult).Replace("-","").ToLower()}");
    }

    [Test]
    public void ScalarMulBaseGroupOrderReturnsIdentity()
    {
        // [L]*B should be the identity (0:1)
        // L = 2^446 − 13818066809895115352007386748515426880336692474882178609894547503885 (LE 56 bytes)
        byte[] lBytes = new byte[57];
        byte[] lHex = HexToBytes("f34458ab92c27823558fc58d72c26c219036d6ae49db4ec4e923ca7cffffffffffffffffffffffffffffffffffffffffffffffffffffff3f");
        Array.Copy(lHex, lBytes, 56);

        Span<ulong> k = stackalloc ulong[7];
        X25519.FromLittleEndianBytes(lBytes.AsSpan(0, 56), k);
        byte[] result = new byte[57];
        Ed448.ScalarMulBaseEncoded(k, result);

        // Identity encodes as y=1, x=0: byte[0]=1, rest 0
        byte[] identity = new byte[57];
        identity[0] = 1;
        Assert.That(result, Is.EqualTo(identity),
            $"[L]*B should be identity!\nGot: {BitConverter.ToString(result).Replace("-","").ToLower()}");
    }

    [Test]
    public void ScalarMulBaseSmallScalarsCrossValidate()
    {
        // Verify base point is on curve: x^2 + y^2 = 1 - 39081*x^2*y^2
        BigInteger bx2 = RefBx * RefBx % RefP;
        BigInteger by2 = RefBy * RefBy % RefP;
        BigInteger lhs = (bx2 + by2) % RefP;
        BigInteger dxy2 = (RefP - 39081) * bx2 % RefP * by2 % RefP;
        BigInteger rhs = (1 + dxy2) % RefP;
        Assert.That(lhs, Is.EqualTo(rhs), "Base point not on curve!");

        // Verify Bx is even (RFC 8032 Table 2: X(B) has bit 0 = 0)
        Assert.That(RefBx.IsEven, Is.True, "Bx should be even (positive root)");

        Span<ulong> k = stackalloc ulong[7];
        foreach (ulong scalar in new ulong[] { 1, 2, 3, 7, 15, 100, 1000 })
        {
            byte[] scalarBytes = new byte[56];
            scalarBytes[0] = (byte)(scalar & 0xFF);
            if (scalar > 255) scalarBytes[1] = (byte)((scalar >> 8) & 0xFF);

            X25519.FromLittleEndianBytes(scalarBytes, k);
            byte[] result = new byte[57];
            Ed448.ScalarMulBaseEncoded(k, result);

            byte[] refResult = BigIntRefScalarMulBase(scalarBytes);
            Assert.That(result, Is.EqualTo(refResult),
                $"Failed for scalar {scalar}:\nManaged: {BitConverter.ToString(result).Replace("-","").ToLower()}\nBigInt:  {BitConverter.ToString(refResult).Replace("-","").ToLower()}");
        }
    }

    // ========================================================================
    // BigInteger Reference Implementation (a=1 Edwards)
    // ========================================================================

    private static readonly BigInteger RefP = BigInteger.Pow(2, 448) - BigInteger.Pow(2, 224) - 1;

    // d = -39081 mod p
    private static readonly BigInteger RefD = RefP - 39081;

    // Base point B from RFC 8032 §5.2 Table 2 (sourced from RFC 7748 edwards448 base point).
    // X(B) = 224580040295924300187604334099896036246789641632564134246125461686950415467406032909029192869357953282578032075146446173674602635247710
    private static readonly BigInteger RefBx = BigInteger.Parse(
        "224580040295924300187604334099896036246789641632564134246125461686950415467406032909029192869357953282578032075146446173674602635247710", CultureInfo.InvariantCulture);

    // Y(B) = 298819210078481492676017930443930673437544040154080242095928241372331506189835876003536878655418784733982303233503462500531545062832660
    private static readonly BigInteger RefBy = BigInteger.Parse(
        "298819210078481492676017930443930673437544040154080242095928241372331506189835876003536878655418784733982303233503462500531545062832660", CultureInfo.InvariantCulture);

    private static byte[] BigIntRefScalarMulBase(byte[] scalarLE)
    {
        BigInteger s = new BigInteger(scalarLE, isUnsigned: true, isBigEndian: false);
        var (rx, ry) = BigIntScalarMul(s, (RefBx, RefBy));

        byte[] yBytes = ry.ToByteArray(isUnsigned: true, isBigEndian: false);
        byte[] encoded = new byte[57];
        Array.Copy(yBytes, encoded, Math.Min(yBytes.Length, 56));
        if (!rx.IsEven) encoded[56] = 0x80;
        return encoded;
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
        // a=1 Edwards: x^2 + y^2 = 1 + d*x^2*y^2, d = -39081 mod p
        // x3 = (x1y2 + x2y1) / (1 + d*x1x2y1y2)
        // y3 = (y1y2 - x1x2) / (1 - d*x1x2y1y2)
        BigInteger x1 = p1.x, y1 = p1.y, x2 = p2.x, y2 = p2.y;
        BigInteger dxy = RefD * x1 % RefP * x2 % RefP * y1 % RefP * y2 % RefP;

        BigInteger numX = (x1 * y2 + x2 * y1) % RefP;
        BigInteger numY = ((y1 * y2 - x1 * x2) % RefP + RefP) % RefP;
        BigInteger denX = (1 + dxy) % RefP;
        BigInteger denY = (1 - dxy + RefP) % RefP;

        BigInteger x3 = numX * BigInteger.ModPow(denX, RefP - 2, RefP) % RefP;
        BigInteger y3 = numY * BigInteger.ModPow(denY, RefP - 2, RefP) % RefP;

        return ((x3 + RefP) % RefP, (y3 + RefP) % RefP);
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static byte[] HexToBytes(string hex)
    {
        hex = hex.Replace(" ", "").Replace("\n", "").Replace("\r", "");
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
            bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        return bytes;
    }
}

#endif
