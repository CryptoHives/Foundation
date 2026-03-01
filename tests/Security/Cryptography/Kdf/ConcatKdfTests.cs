// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kdf;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public sealed class ConcatKdfTests
{
    // -------------------------------------------------------------------
    // BouncyCastle-compatible test vectors (patrickfav NIST SP 800-56C)
    // Hash-based: Hash(counter ‖ Z ‖ OtherInfo)
    // -------------------------------------------------------------------

    [Test]
    public void HashBasedSha256MatchesBouncyCastle()
    {
        byte[] z = TestHelpers.FromHexString("3f892bd8b84dae64a782a35f6eaa8f00");
        byte[] otherInfo = TestHelpers.FromHexString("ec3f1cd873d28858a58cc39e");
        byte[] expected = TestHelpers.FromHexString(
            "A7C0665298252531E0DB37737A374651B368275F2048284D16A166C6D8A90A91" +
            "A491C16F49641B9F516A03D9D6D0F4FE7B81FFDF1C816F40ECD74AED8EDA2B8A" +
            "3C714FA0");

        using var sha256 = SHA256.Create();
        byte[] result = ConcatKdf.DeriveKey(sha256, z, expected.Length, otherInfo);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void HashBasedSha512MatchesBouncyCastle()
    {
        byte[] z = TestHelpers.FromHexString("e65b1905878b95f68b5535bd3b2b1013");
        byte[] otherInfo = TestHelpers.FromHexString("830221b1730d9176f807d407");
        byte[] expected = TestHelpers.FromHexString(
            "B8C44BDF0B85A64B6A51C12A06710E373D829BB1FDA5B4E1A20795C6199594F6" +
            "FA65198A721257F7D58CB2F6F6DB9BB5699F73863045909054B2389E06EC00FE" +
            "318CABD9");

        using var sha512 = SHA512.Create();
        byte[] result = ConcatKdf.DeriveKey(sha512, z, expected.Length, otherInfo);

        Assert.That(result, Is.EqualTo(expected));
    }

    // -------------------------------------------------------------------
    // Known-answer tests (generated via .NET IncrementalHash)
    // -------------------------------------------------------------------

    private static readonly byte[] TestKey = CreateSequentialKey(32);
    private static readonly byte[] TestOtherInfo = TestHelpers.FromHexString("ABCDEF0123456789");

    private static byte[] CreateSequentialKey(int length)
    {
        byte[] key = new byte[length];
        for (int i = 0; i < length; i++)
            key[i] = (byte)(i + 1);
        return key;
    }

    [Test]
    public void Sha256With32ByteOutput()
    {
        byte[] expected = TestHelpers.FromHexString(
            "B9075DD4A7092B0104A28230C632528DD3C998933B08747D7A5282F145BE593F");

        using var sha256 = SHA256.Create();
        byte[] result = ConcatKdf.DeriveKey(sha256, TestKey, 32, TestOtherInfo);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha256With64ByteOutputTwoIterations()
    {
        byte[] expected = TestHelpers.FromHexString(
            "B9075DD4A7092B0104A28230C632528DD3C998933B08747D7A5282F145BE593F" +
            "BEF7747AA05C975276F3B945C4382006F14AFC98D48CDDB7878FB2FC98A5BDF6");

        using var sha256 = SHA256.Create();
        byte[] result = ConcatKdf.DeriveKey(sha256, TestKey, 64, TestOtherInfo);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha256With16BytePartialBlock()
    {
        byte[] expected = TestHelpers.FromHexString(
            "B9075DD4A7092B0104A28230C632528D");

        using var sha256 = SHA256.Create();
        byte[] result = ConcatKdf.DeriveKey(sha256, TestKey, 16, TestOtherInfo);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha256EmptyOtherInfo()
    {
        byte[] expected = TestHelpers.FromHexString(
            "893D4D0D7D5D07B62132A837BD661E06E32C2A08C23AA4F4C08ED86037B2BD9C");

        using var sha256 = SHA256.Create();
        byte[] result = ConcatKdf.DeriveKey(sha256, TestKey, 32);

        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Sha256SingleByteOutput()
    {
        byte[] expected = TestHelpers.FromHexString("B9");

        using var sha256 = SHA256.Create();
        byte[] result = ConcatKdf.DeriveKey(sha256, TestKey, 1, TestOtherInfo);

        Assert.That(result, Is.EqualTo(expected));
    }

    // -------------------------------------------------------------------
    // Partial block prefix consistency
    // -------------------------------------------------------------------

    [Test]
    public void PartialOutputIsPrefixOfFullBlock()
    {
        using var sha256 = SHA256.Create();
        byte[] full = ConcatKdf.DeriveKey(sha256, TestKey, 32, TestOtherInfo);
        byte[] partial = ConcatKdf.DeriveKey(sha256, TestKey, 16, TestOtherInfo);

        Assert.That(partial, Is.EqualTo(full.AsSpan(0, 16).ToArray()));
    }

    [Test]
    public void LongerOutputExtendsShorter()
    {
        using var sha256 = SHA256.Create();
        byte[] short32 = ConcatKdf.DeriveKey(sha256, TestKey, 32, TestOtherInfo);
        byte[] long64 = ConcatKdf.DeriveKey(sha256, TestKey, 64, TestOtherInfo);

        // First 32 bytes should match (output length not part of hash input)
        Assert.That(long64.AsSpan(0, 32).ToArray(), Is.EqualTo(short32));
    }

    // -------------------------------------------------------------------
    // HMAC-based variant (SP 800-56C rev2 Option 1)
    // -------------------------------------------------------------------

    [Test]
    public void HmacBasedDeriveKeyProducesOutput()
    {
        byte[] salt = new byte[32];
        for (int i = 0; i < 32; i++) salt[i] = (byte)(0xA0 + i);

        byte[] result = ConcatKdf.DeriveKey(
            key => new HmacSha256(key),
            TestKey, 32, TestOtherInfo, salt);

        Assert.That(result, Has.Length.EqualTo(32));
        Assert.That(result, Is.Not.EqualTo(new byte[32]));
    }

    [Test]
    public void HmacBasedIsDeterministic()
    {
        byte[] salt = new byte[32];

        byte[] r1 = ConcatKdf.DeriveKey(
            key => new HmacSha256(key),
            TestKey, 32, TestOtherInfo, salt);
        byte[] r2 = ConcatKdf.DeriveKey(
            key => new HmacSha256(key),
            TestKey, 32, TestOtherInfo, salt);

        Assert.That(r1, Is.EqualTo(r2));
    }

    [Test]
    public void HmacBasedDifferentSaltProducesDifferentOutput()
    {
        byte[] salt1 = new byte[32];
        byte[] salt2 = new byte[32];
        salt2[0] = 0x01;

        byte[] r1 = ConcatKdf.DeriveKey(
            key => new HmacSha256(key), TestKey, 32, TestOtherInfo, salt1);
        byte[] r2 = ConcatKdf.DeriveKey(
            key => new HmacSha256(key), TestKey, 32, TestOtherInfo, salt2);

        Assert.That(r1, Is.Not.EqualTo(r2));
    }

    [Test]
    public void HmacBasedDiffersFromHashBased()
    {
        using var sha256 = SHA256.Create();
        byte[] hashResult = ConcatKdf.DeriveKey(sha256, TestKey, 32, TestOtherInfo);
        byte[] hmacResult = ConcatKdf.DeriveKey(
            key => new HmacSha256(key), TestKey, 32, TestOtherInfo);

        Assert.That(hashResult, Is.Not.EqualTo(hmacResult));
    }

    [Test]
    public void HmacBasedWithSha512()
    {
        byte[] result = ConcatKdf.DeriveKey(
            key => new HmacSha512(key), TestKey, 64, TestOtherInfo);

        Assert.That(result, Has.Length.EqualTo(64));

        // Verify deterministic
        byte[] result2 = ConcatKdf.DeriveKey(
            key => new HmacSha512(key), TestKey, 64, TestOtherInfo);
        Assert.That(result2, Is.EqualTo(result));
    }

    // -------------------------------------------------------------------
    // Span and array API consistency
    // -------------------------------------------------------------------

    [Test]
    public void HashBasedSpanAndArrayMatch()
    {
        using var sha256 = SHA256.Create();
        byte[] arrayResult = ConcatKdf.DeriveKey(sha256, TestKey, 32, TestOtherInfo);

        Span<byte> spanResult = stackalloc byte[32];
        ConcatKdf.DeriveKey(sha256, TestKey, spanResult, TestOtherInfo);

        Assert.That(spanResult.ToArray(), Is.EqualTo(arrayResult));
    }

    [Test]
    public void HmacBasedSpanAndArrayMatch()
    {
        HmacFactory factory = key => new HmacSha256(key);
        byte[] arrayResult = ConcatKdf.DeriveKey(factory, TestKey, 32, TestOtherInfo);

        Span<byte> spanResult = stackalloc byte[32];
        ConcatKdf.DeriveKey(factory, TestKey, spanResult, TestOtherInfo, []);

        Assert.That(spanResult.ToArray(), Is.EqualTo(arrayResult));
    }

    // -------------------------------------------------------------------
    // Different shared secrets produce different output
    // -------------------------------------------------------------------

    [Test]
    public void DifferentSharedSecretsProduceDifferentKeys()
    {
        using var sha256 = SHA256.Create();
        byte[] z1 = new byte[32]; z1[0] = 1;
        byte[] z2 = new byte[32]; z2[0] = 2;

        byte[] r1 = ConcatKdf.DeriveKey(sha256, z1, 32, TestOtherInfo);
        byte[] r2 = ConcatKdf.DeriveKey(sha256, z2, 32, TestOtherInfo);

        Assert.That(r1, Is.Not.EqualTo(r2));
    }

    [Test]
    public void DifferentOtherInfoProducesDifferentKeys()
    {
        using var sha256 = SHA256.Create();
        byte[] info1 = [0x01, 0x02];
        byte[] info2 = [0x03, 0x04];

        byte[] r1 = ConcatKdf.DeriveKey(sha256, TestKey, 32, info1);
        byte[] r2 = ConcatKdf.DeriveKey(sha256, TestKey, 32, info2);

        Assert.That(r1, Is.Not.EqualTo(r2));
    }

    // -------------------------------------------------------------------
    // Parameter validation
    // -------------------------------------------------------------------

    [Test]
    public void HashNullThrows()
    {
        Assert.Throws<ArgumentNullException>(
            () => ConcatKdf.DeriveKey((System.Security.Cryptography.HashAlgorithm)null!, TestKey, 32));
    }

    [Test]
    public void HashSharedSecretNullThrows()
    {
        using var sha256 = SHA256.Create();
        Assert.Throws<ArgumentNullException>(
            () => ConcatKdf.DeriveKey(sha256, null!, 32));
    }

    [Test]
    public void HashZeroOutputThrows()
    {
        using var sha256 = SHA256.Create();
        Assert.Throws<ArgumentOutOfRangeException>(
            () => ConcatKdf.DeriveKey(sha256, TestKey, 0));
    }

    [Test]
    public void HmacFactoryNullThrows()
    {
        Assert.Throws<ArgumentNullException>(
            () => ConcatKdf.DeriveKey((HmacFactory)null!, TestKey, 32));
    }

    [Test]
    public void HmacSharedSecretNullThrows()
    {
        Assert.Throws<ArgumentNullException>(
            () => ConcatKdf.DeriveKey(key => new HmacSha256(key), null!, 32));
    }

    [Test]
    public void HmacZeroOutputThrows()
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => ConcatKdf.DeriveKey(key => new HmacSha256(key), TestKey, 0));
    }

    [Test]
    public void EmptyOutputSpanThrows()
    {
        using var sha256 = SHA256.Create();
        Assert.Throws<ArgumentException>(
            () => ConcatKdf.DeriveKey(sha256, TestKey, Span<byte>.Empty, []));
    }
}

