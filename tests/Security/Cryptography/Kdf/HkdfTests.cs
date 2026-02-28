// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CS0618 // SHA-1 obsolete warning — intentionally tested for RFC 5869 compliance

namespace Cryptography.Tests.Kdf;

using CryptoHives.Foundation.Security.Cryptography.Kdf;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for <see cref="Hkdf"/> using RFC 5869 Appendix A test vectors
/// and cross-validation against <see cref="System.Security.Cryptography.HKDF"/>
/// on supported platforms.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class HkdfTests
{
    private static readonly HmacFactory Sha256Factory = key => new HmacSha256(key);
    private static readonly HmacFactory Sha1Factory = key => new HmacSha1(key);

    #region RFC 5869 Appendix A — Test Case 1 (SHA-256, basic)

    /// <summary>
    /// RFC 5869 Appendix A, Test Case 1: Basic test case with SHA-256.
    /// </summary>
    [Test]
    public void Rfc5869TestCase1Extract()
    {
        byte[] ikm = TestHelpers.FromHexString("0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b");
        byte[] salt = TestHelpers.FromHexString("000102030405060708090a0b0c");
        byte[] expectedPrk = TestHelpers.FromHexString(
            "077709362c2e32df0ddc3f0dc47bba63" +
            "90b6c73bb50f9c3122ec844ad7c2b3e5");

        byte[] prk = Hkdf.Extract(Sha256Factory, ikm, salt);

        Assert.That(prk, Is.EqualTo(expectedPrk));
    }

    /// <summary>
    /// RFC 5869 Appendix A, Test Case 1: Expand with SHA-256.
    /// </summary>
    [Test]
    public void Rfc5869TestCase1Expand()
    {
        byte[] prk = TestHelpers.FromHexString(
            "077709362c2e32df0ddc3f0dc47bba63" +
            "90b6c73bb50f9c3122ec844ad7c2b3e5");
        byte[] info = TestHelpers.FromHexString("f0f1f2f3f4f5f6f7f8f9");
        byte[] expectedOkm = TestHelpers.FromHexString(
            "3cb25f25faacd57a90434f64d0362f2a" +
            "2d2d0a90cf1a5a4c5db02d56ecc4c5bf" +
            "34007208d5b887185865");

        byte[] okm = Hkdf.Expand(Sha256Factory, prk, 42, info);

        Assert.That(okm, Is.EqualTo(expectedOkm));
    }

    /// <summary>
    /// RFC 5869 Appendix A, Test Case 1: Combined DeriveKey with SHA-256.
    /// </summary>
    [Test]
    public void Rfc5869TestCase1DeriveKey()
    {
        byte[] ikm = TestHelpers.FromHexString("0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b");
        byte[] salt = TestHelpers.FromHexString("000102030405060708090a0b0c");
        byte[] info = TestHelpers.FromHexString("f0f1f2f3f4f5f6f7f8f9");
        byte[] expectedOkm = TestHelpers.FromHexString(
            "3cb25f25faacd57a90434f64d0362f2a" +
            "2d2d0a90cf1a5a4c5db02d56ecc4c5bf" +
            "34007208d5b887185865");

        byte[] okm = Hkdf.DeriveKey(Sha256Factory, ikm, 42, salt, info);

        Assert.That(okm, Is.EqualTo(expectedOkm));
    }

    #endregion

    #region RFC 5869 Appendix A — Test Case 2 (SHA-256, longer inputs)

    /// <summary>
    /// RFC 5869 Appendix A, Test Case 2: Longer inputs/outputs with SHA-256.
    /// </summary>
    [Test]
    public void Rfc5869TestCase2DeriveKey()
    {
        byte[] ikm = TestHelpers.FromHexString(
            "000102030405060708090a0b0c0d0e0f" +
            "101112131415161718191a1b1c1d1e1f" +
            "202122232425262728292a2b2c2d2e2f" +
            "303132333435363738393a3b3c3d3e3f" +
            "404142434445464748494a4b4c4d4e4f");
        byte[] salt = TestHelpers.FromHexString(
            "606162636465666768696a6b6c6d6e6f" +
            "707172737475767778797a7b7c7d7e7f" +
            "808182838485868788898a8b8c8d8e8f" +
            "909192939495969798999a9b9c9d9e9f" +
            "a0a1a2a3a4a5a6a7a8a9aaabacadaeaf");
        byte[] info = TestHelpers.FromHexString(
            "b0b1b2b3b4b5b6b7b8b9babbbcbdbebf" +
            "c0c1c2c3c4c5c6c7c8c9cacbcccdcecf" +
            "d0d1d2d3d4d5d6d7d8d9dadbdcdddedf" +
            "e0e1e2e3e4e5e6e7e8e9eaebecedeeef" +
            "f0f1f2f3f4f5f6f7f8f9fafbfcfdfeff");
        byte[] expectedOkm = TestHelpers.FromHexString(
            "b11e398dc80327a1c8e7f78c596a4934" +
            "4f012eda2d4efad8a050cc4c19afa97c" +
            "59045a99cac7827271cb41c65e590e09" +
            "da3275600c2f09b8367793a9aca3db71" +
            "cc30c58179ec3e87c14c01d5c1f3434f" +
            "1d87");

        byte[] okm = Hkdf.DeriveKey(Sha256Factory, ikm, 82, salt, info);

        Assert.That(okm, Is.EqualTo(expectedOkm));
    }

    #endregion

    #region RFC 5869 Appendix A — Test Case 3 (SHA-256, zero-length salt/info)

    /// <summary>
    /// RFC 5869 Appendix A, Test Case 3: SHA-256 with zero-length salt and info.
    /// </summary>
    [Test]
    public void Rfc5869TestCase3DeriveKey()
    {
        byte[] ikm = TestHelpers.FromHexString("0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b");
        byte[] expectedOkm = TestHelpers.FromHexString(
            "8da4e775a563c18f715f802a063c5a31" +
            "b8a11f5c5ee1879ec3454e5f3c738d2d" +
            "9d201395faa4b61a96c8");

        byte[] okm = Hkdf.DeriveKey(Sha256Factory, ikm, 42);

        Assert.That(okm, Is.EqualTo(expectedOkm));
    }

    #endregion

    #region RFC 5869 Appendix A — Test Case 4 (SHA-1, basic)

    /// <summary>
    /// RFC 5869 Appendix A, Test Case 4: Basic test case with SHA-1.
    /// </summary>
    [Test]
    public void Rfc5869TestCase4DeriveKey()
    {
        byte[] ikm = TestHelpers.FromHexString("0b0b0b0b0b0b0b0b0b0b0b");
        byte[] salt = TestHelpers.FromHexString("000102030405060708090a0b0c");
        byte[] info = TestHelpers.FromHexString("f0f1f2f3f4f5f6f7f8f9");
        byte[] expectedOkm = TestHelpers.FromHexString(
            "085a01ea1b10f36933068b56efa5ad81" +
            "a4f14b822f5b091568a9cdd4f155fda2" +
            "c22e422478d305f3f896");

        byte[] okm = Hkdf.DeriveKey(Sha1Factory, ikm, 42, salt, info);

        Assert.That(okm, Is.EqualTo(expectedOkm));
    }

    #endregion

    #region RFC 5869 Appendix A — Test Case 5 (SHA-1, longer inputs)

    /// <summary>
    /// RFC 5869 Appendix A, Test Case 5: SHA-1 with longer inputs.
    /// </summary>
    [Test]
    public void Rfc5869TestCase5DeriveKey()
    {
        byte[] ikm = TestHelpers.FromHexString(
            "000102030405060708090a0b0c0d0e0f" +
            "101112131415161718191a1b1c1d1e1f" +
            "202122232425262728292a2b2c2d2e2f" +
            "303132333435363738393a3b3c3d3e3f" +
            "404142434445464748494a4b4c4d4e4f");
        byte[] salt = TestHelpers.FromHexString(
            "606162636465666768696a6b6c6d6e6f" +
            "707172737475767778797a7b7c7d7e7f" +
            "808182838485868788898a8b8c8d8e8f" +
            "909192939495969798999a9b9c9d9e9f" +
            "a0a1a2a3a4a5a6a7a8a9aaabacadaeaf");
        byte[] info = TestHelpers.FromHexString(
            "b0b1b2b3b4b5b6b7b8b9babbbcbdbebf" +
            "c0c1c2c3c4c5c6c7c8c9cacbcccdcecf" +
            "d0d1d2d3d4d5d6d7d8d9dadbdcdddedf" +
            "e0e1e2e3e4e5e6e7e8e9eaebecedeeef" +
            "f0f1f2f3f4f5f6f7f8f9fafbfcfdfeff");
        byte[] expectedOkm = TestHelpers.FromHexString(
            "0bd770a74d1160f7c9f12cd5912a06eb" +
            "ff6adcae899d92191fe4305673ba2ffe" +
            "8fa3f1a4e5ad79f3f334b3b202b2173c" +
            "486ea37ce3d397ed034c7f9dfeb15c5e" +
            "927336d0441f4c4300e2cff0d0900b52" +
            "d3b4");

        byte[] okm = Hkdf.DeriveKey(Sha1Factory, ikm, 82, salt, info);

        Assert.That(okm, Is.EqualTo(expectedOkm));
    }

    #endregion

    #region RFC 5869 Appendix A — Test Case 6 (SHA-1, zero-length salt/info)

    /// <summary>
    /// RFC 5869 Appendix A, Test Case 6: SHA-1 with zero-length salt and info.
    /// </summary>
    [Test]
    public void Rfc5869TestCase6DeriveKey()
    {
        byte[] ikm = TestHelpers.FromHexString("0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b");
        byte[] expectedOkm = TestHelpers.FromHexString(
            "0ac1af7002b3d761d1e55298da9d0506" +
            "b9ae52057220a306e07b6b87e8df21d0" +
            "ea00033de03984d34918");

        byte[] okm = Hkdf.DeriveKey(Sha1Factory, ikm, 42);

        Assert.That(okm, Is.EqualTo(expectedOkm));
    }

    #endregion

    #region RFC 5869 Appendix A — Test Case 7 (SHA-1, zero-length salt/info/IKM)

    /// <summary>
    /// RFC 5869 Appendix A, Test Case 7: SHA-1 with zero-length IKM, salt, and info.
    /// </summary>
    [Test]
    public void Rfc5869TestCase7DeriveKey()
    {
        byte[] ikm = TestHelpers.FromHexString("0c0c0c0c0c0c0c0c0c0c0c0c0c0c0c0c0c0c0c0c0c0c");
        byte[] expectedOkm = TestHelpers.FromHexString(
            "2c91117204d745f3500d636a62f64f0a" +
            "b3bae548aa53d423b0d1f27ebba6f5e5" +
            "673a081d70cce7acfc48");

        byte[] okm = Hkdf.DeriveKey(Sha1Factory, ikm, 42);

        Assert.That(okm, Is.EqualTo(expectedOkm));
    }

    #endregion

    #region Cross-Validation Against .NET HKDF

#if NET8_0_OR_GREATER
    /// <summary>
    /// Cross-validates CryptoHives HKDF against <see cref="System.Security.Cryptography.HKDF"/>
    /// for various input sizes.
    /// </summary>
    [TestCase(16)]
    [TestCase(32)]
    [TestCase(48)]
    [TestCase(64)]
    [TestCase(128)]
    public void DeriveKeyMatchesDotNetHkdf(int outputLength)
    {
        var rng = new Random(outputLength * 7);
        byte[] ikm = new byte[32];
        rng.NextBytes(ikm);
        byte[] salt = new byte[16];
        rng.NextBytes(salt);
        byte[] info = new byte[10];
        rng.NextBytes(info);

        byte[] expected = System.Security.Cryptography.HKDF.DeriveKey(
            System.Security.Cryptography.HashAlgorithmName.SHA256,
            ikm, outputLength, salt, info);

        byte[] actual = Hkdf.DeriveKey(Sha256Factory, ikm, outputLength, salt, info);

        Assert.That(actual, Is.EqualTo(expected),
            $"HKDF mismatch for output length {outputLength}");
    }

    /// <summary>
    /// Cross-validates Extract against .NET HKDF.
    /// </summary>
    [Test]
    public void ExtractMatchesDotNetHkdf()
    {
        var rng = new Random(42);
        byte[] ikm = new byte[32];
        rng.NextBytes(ikm);
        byte[] salt = new byte[16];
        rng.NextBytes(salt);

        byte[] expected = System.Security.Cryptography.HKDF.Extract(
            System.Security.Cryptography.HashAlgorithmName.SHA256, ikm, salt);

        byte[] actual = Hkdf.Extract(Sha256Factory, ikm, salt);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Cross-validates Expand against .NET HKDF.
    /// </summary>
    [Test]
    public void ExpandMatchesDotNetHkdf()
    {
        var rng = new Random(77);
        byte[] prk = new byte[32];
        rng.NextBytes(prk);
        byte[] info = new byte[12];
        rng.NextBytes(info);

        byte[] expected = System.Security.Cryptography.HKDF.Expand(
            System.Security.Cryptography.HashAlgorithmName.SHA256, prk, 64, info);

        byte[] actual = Hkdf.Expand(Sha256Factory, prk, 64, info);

        Assert.That(actual, Is.EqualTo(expected));
    }
#endif

    #endregion

    #region Edge Cases

    /// <summary>
    /// Verifies that HKDF works with empty info parameter.
    /// </summary>
    [Test]
    public void EmptyInfoProducesValidOutput()
    {
        byte[] ikm = new byte[32];
        new Random(42).NextBytes(ikm);

        byte[] result = Hkdf.DeriveKey(Sha256Factory, ikm, 32);

        Assert.That(result, Has.Length.EqualTo(32));
        Assert.That(result, Is.Not.EqualTo(new byte[32]), "Output should not be all zeros");
    }

    /// <summary>
    /// Verifies that HKDF works with single-byte output.
    /// </summary>
    [Test]
    public void SingleByteOutput()
    {
        byte[] ikm = new byte[32];
        new Random(42).NextBytes(ikm);

        byte[] result = Hkdf.DeriveKey(Sha256Factory, ikm, 1);

        Assert.That(result, Has.Length.EqualTo(1));
    }

    /// <summary>
    /// Verifies that span-based and array-based APIs produce identical results.
    /// </summary>
    [Test]
    public void SpanAndArrayApisProduceSameResult()
    {
        byte[] ikm = new byte[32];
        new Random(42).NextBytes(ikm);
        byte[] salt = new byte[16];
        new Random(77).NextBytes(salt);
        byte[] info = new byte[8];
        new Random(99).NextBytes(info);

        byte[] arrayResult = Hkdf.DeriveKey(Sha256Factory, ikm, 48, salt, info);

        byte[] spanResult = new byte[48];
        Hkdf.DeriveKey(Sha256Factory, ikm, spanResult, salt, info);

        Assert.That(spanResult, Is.EqualTo(arrayResult));
    }

    #endregion

    #region Parameter Validation

    /// <summary>
    /// Verifies that output exceeding 255×MacSize throws ArgumentException.
    /// </summary>
    [Test]
    public void ExpandOutputTooLargeThrows()
    {
        byte[] prk = new byte[32];
        // 255 × 32 (SHA-256 MacSize) = 8160
        Assert.Throws<ArgumentException>(() =>
            Hkdf.Expand(Sha256Factory, prk, 8161));
    }

    /// <summary>
    /// Verifies that zero output length throws ArgumentOutOfRangeException.
    /// </summary>
    [Test]
    public void ZeroOutputLengthThrows()
    {
        byte[] ikm = new byte[32];
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            Hkdf.DeriveKey(Sha256Factory, ikm, 0));
    }

    /// <summary>
    /// Verifies that null factory throws ArgumentNullException.
    /// </summary>
    [Test]
    public void NullFactoryThrows()
    {
        byte[] ikm = new byte[32];
        Assert.Throws<ArgumentNullException>(() =>
            Hkdf.DeriveKey(null!, ikm, 32));
    }

    /// <summary>
    /// Verifies that null IKM throws ArgumentNullException.
    /// </summary>
    [Test]
    public void NullIkmThrows()
    {
        Assert.Throws<ArgumentNullException>(() =>
            Hkdf.DeriveKey(Sha256Factory, null!, 32));
    }

    #endregion

    #region Multiple HMAC Variants

    /// <summary>
    /// Verifies that HKDF works with HMAC-SHA-384.
    /// </summary>
    [Test]
    public void DeriveKeyWithSha384()
    {
        HmacFactory sha384 = key => new HmacSha384(key);
        byte[] ikm = new byte[48];
        new Random(42).NextBytes(ikm);
        byte[] salt = new byte[16];
        new Random(77).NextBytes(salt);

        byte[] result = Hkdf.DeriveKey(sha384, ikm, 64, salt);

        Assert.That(result, Has.Length.EqualTo(64));
        Assert.That(result, Is.Not.EqualTo(new byte[64]));
    }

    /// <summary>
    /// Verifies that HKDF works with HMAC-SHA-512.
    /// </summary>
    [Test]
    public void DeriveKeyWithSha512()
    {
        HmacFactory sha512 = key => new HmacSha512(key);
        byte[] ikm = new byte[64];
        new Random(42).NextBytes(ikm);
        byte[] salt = new byte[16];
        new Random(77).NextBytes(salt);

        byte[] result = Hkdf.DeriveKey(sha512, ikm, 128, salt);

        Assert.That(result, Has.Length.EqualTo(128));
        Assert.That(result, Is.Not.EqualTo(new byte[128]));
    }

    #endregion
}
