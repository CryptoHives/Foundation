// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA5350 // Do Not Use Weak Cryptographic Algorithms
#pragma warning disable CA5351 // Do Not Use Broken Cryptographic Algorithms

namespace Cryptography.Tests.Mac.Hmac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for HMAC implementations using RFC 4231 test vectors and cross-validation
/// against .NET built-in HMAC classes.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class HmacTests
{
    #region RFC 4231 Test Vectors — HMAC-SHA-256

    /// <summary>
    /// RFC 4231 Test Case 1: HMAC-SHA-256 with 20-byte key.
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase1()
    {
        byte[] key = TestHelpers.FromHexString("0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b");
        byte[] data = Encoding.ASCII.GetBytes("Hi There");
        byte[] expected = TestHelpers.FromHexString("b0344c61d8db38535ca8afceaf0bf12b881dc200c9833da726e9376c2e32cff7");

        using var hmac = HmacSha256.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 2: HMAC-SHA-256 with "Jefe" key.
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase2()
    {
        byte[] key = Encoding.ASCII.GetBytes("Jefe");
        byte[] data = Encoding.ASCII.GetBytes("what do ya want for nothing?");
        byte[] expected = TestHelpers.FromHexString("5bdcc146bf60754e6a042426089575c75a003f089d2739839dec58b964ec3843");

        using var hmac = HmacSha256.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 3: HMAC-SHA-256 with 20-byte 0xaa key.
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase3()
    {
        byte[] key = TestHelpers.FromHexString("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        byte[] data = TestHelpers.FromHexString("dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
        byte[] expected = TestHelpers.FromHexString("773ea91e36800e46854db8ebd09181a72959098b3ef8c122d9635514ced565fe");

        using var hmac = HmacSha256.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 4: HMAC-SHA-256 with 25-byte key.
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase4()
    {
        byte[] key = TestHelpers.FromHexString("0102030405060708090a0b0c0d0e0f10111213141516171819");
        byte[] data = TestHelpers.FromHexString("cdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcdcd");
        byte[] expected = TestHelpers.FromHexString("82558a389a443c0ea4cc819899f2083a85f0faa3e578f8077a2e3ff46729665b");

        using var hmac = HmacSha256.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 6: HMAC-SHA-256 with 131-byte key (longer than block size).
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase6()
    {
        byte[] key = new byte[131];
        for (int i = 0; i < key.Length; i++) key[i] = 0xaa;
        byte[] data = Encoding.ASCII.GetBytes("Test Using Larger Than Block-Size Key - Hash Key First");
        byte[] expected = TestHelpers.FromHexString("60e431591ee0b67f0d8a26aacbf5b77f8e0bc6213728c5140546040f0ee37f54");

        using var hmac = HmacSha256.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 7: HMAC-SHA-256 with 131-byte key and longer data.
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase7()
    {
        byte[] key = new byte[131];
        for (int i = 0; i < key.Length; i++) key[i] = 0xaa;
        byte[] data = Encoding.ASCII.GetBytes("This is a test using a larger than block-size key and a larger than block-size data. The key needs to be hashed before being used by the HMAC algorithm.");
        byte[] expected = TestHelpers.FromHexString("9b09ffa71b942fcb27635fbcd5b0e944bfdc63644f0713938a7f51535c3a35e2");

        using var hmac = HmacSha256.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region RFC 4231 Test Vectors — HMAC-SHA-384

    /// <summary>
    /// RFC 4231 Test Case 1: HMAC-SHA-384.
    /// </summary>
    [Test]
    public void HmacSha384Rfc4231TestCase1()
    {
        byte[] key = TestHelpers.FromHexString("0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b");
        byte[] data = Encoding.ASCII.GetBytes("Hi There");
        byte[] expected = TestHelpers.FromHexString("afd03944d84895626b0825f4ab46907f15f9dadbe4101ec682aa034c7cebc59cfaea9ea9076ede7f4af152e8b2fa9cb6");

        using var hmac = HmacSha384.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 2: HMAC-SHA-384 with "Jefe" key.
    /// </summary>
    [Test]
    public void HmacSha384Rfc4231TestCase2()
    {
        byte[] key = Encoding.ASCII.GetBytes("Jefe");
        byte[] data = Encoding.ASCII.GetBytes("what do ya want for nothing?");
        byte[] expected = TestHelpers.FromHexString("af45d2e376484031617f78d2b58a6b1b9c7ef464f5a01b47e42ec3736322445e8e2240ca5e69e2c78b3239ecfab21649");

        using var hmac = HmacSha384.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region RFC 4231 Test Vectors — HMAC-SHA-512

    /// <summary>
    /// RFC 4231 Test Case 1: HMAC-SHA-512.
    /// </summary>
    [Test]
    public void HmacSha512Rfc4231TestCase1()
    {
        byte[] key = TestHelpers.FromHexString("0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b");
        byte[] data = Encoding.ASCII.GetBytes("Hi There");
        byte[] expected = TestHelpers.FromHexString("87aa7cdea5ef619d4ff0b4241a1d6cb02379f4e2ce4ec2787ad0b30545e17cdedaa833b7d6b8a702038b274eaea3f4e4be9d914eeb61f1702e696c203a126854");

        using var hmac = HmacSha512.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 2: HMAC-SHA-512 with "Jefe" key.
    /// </summary>
    [Test]
    public void HmacSha512Rfc4231TestCase2()
    {
        byte[] key = Encoding.ASCII.GetBytes("Jefe");
        byte[] data = Encoding.ASCII.GetBytes("what do ya want for nothing?");
        byte[] expected = TestHelpers.FromHexString("164b7a7bfcf819e2e395fbe73b56e0a387bd64222e831fd610270cd7ea2505549758bf75c05a994a6d034f65f8f0e6fdcaeab1a34d4a6b4b636e070a38bce737");

        using var hmac = HmacSha512.Create(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region .NET Cross-Validation

    /// <summary>
    /// Validate HMAC-SHA-256 against .NET built-in HMACSHA256.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void HmacSha256MatchesDotNet(string message)
    {
        byte[] key = TestHelpers.FromHexString("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] input = Encoding.UTF8.GetBytes(message);

        using var dotNet = new System.Security.Cryptography.HMACSHA256(key);
        byte[] netHash = dotNet.ComputeHash(input);

        using var ours = HmacSha256.Create(key);
        byte[] ourHash = ours.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"HMAC-SHA256 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate HMAC-SHA-384 against .NET built-in HMACSHA384.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void HmacSha384MatchesDotNet(string message)
    {
        byte[] key = TestHelpers.FromHexString("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] input = Encoding.UTF8.GetBytes(message);

        using var dotNet = new System.Security.Cryptography.HMACSHA384(key);
        byte[] netHash = dotNet.ComputeHash(input);

        using var ours = HmacSha384.Create(key);
        byte[] ourHash = ours.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"HMAC-SHA384 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate HMAC-SHA-512 against .NET built-in HMACSHA512.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void HmacSha512MatchesDotNet(string message)
    {
        byte[] key = TestHelpers.FromHexString("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] input = Encoding.UTF8.GetBytes(message);

        using var dotNet = new System.Security.Cryptography.HMACSHA512(key);
        byte[] netHash = dotNet.ComputeHash(input);

        using var ours = HmacSha512.Create(key);
        byte[] ourHash = ours.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"HMAC-SHA512 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate HMAC-SHA-256 with various input sizes against .NET.
    /// </summary>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(65)]
    [TestCase(128)]
    [TestCase(1024)]
    public void HmacSha256VariousInputSizesMatchDotNet(int inputLength)
    {
        byte[] key = new byte[32];
        byte[] input = GenerateTestInput(inputLength);

        using var dotNet = new System.Security.Cryptography.HMACSHA256(key);
        byte[] netHash = dotNet.ComputeHash(input);

        using var ours = HmacSha256.Create(key);
        byte[] ourHash = ours.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"HMAC-SHA256 mismatch for input length {inputLength}");
    }

    #endregion

    #region HMAC-SHA3-256 Tests

    /// <summary>
    /// Validate HMAC-SHA3-256 against BouncyCastle.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void HmacSha3_256MatchesBouncyCastle(string message)
    {
        byte[] key = TestHelpers.FromHexString("000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f");
        byte[] input = Encoding.UTF8.GetBytes(message);

        // BouncyCastle reference
        var bcHmac = new Org.BouncyCastle.Crypto.Macs.HMac(new Org.BouncyCastle.Crypto.Digests.Sha3Digest(256));
        bcHmac.Init(new Org.BouncyCastle.Crypto.Parameters.KeyParameter(key));
        bcHmac.BlockUpdate(input, 0, input.Length);
        byte[] bcResult = new byte[bcHmac.GetMacSize()];
        bcHmac.DoFinal(bcResult, 0);

        using var ours = HmacSha3_256.Create(key);
        byte[] ourHash = ours.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(bcResult), $"HMAC-SHA3-256 mismatch for: \"{message}\"");
    }

    #endregion

    #region Legacy HMAC Tests

    /// <summary>
    /// Validate HMAC-SHA-1 against .NET built-in HMACSHA1.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
#pragma warning disable CS0618 // Obsolete warning - testing legacy HMAC intentionally
    public void HmacSha1MatchesDotNet(string message)
    {
        byte[] key = TestHelpers.FromHexString("000102030405060708090a0b0c0d0e0f10111213");
        byte[] input = Encoding.UTF8.GetBytes(message);

        using var dotNet = new System.Security.Cryptography.HMACSHA1(key);
        byte[] netHash = dotNet.ComputeHash(input);

        using var ours = HmacSha1.Create(key);
        byte[] ourHash = ours.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"HMAC-SHA1 mismatch for: \"{message}\"");
    }

    /// <summary>
    /// Validate HMAC-MD5 against .NET built-in HMACMD5.
    /// </summary>
    [TestCase("")]
    [TestCase("test")]
    [TestCase("The quick brown fox jumps over the lazy dog")]
    public void HmacMd5MatchesDotNet(string message)
    {
        byte[] key = TestHelpers.FromHexString("000102030405060708090a0b0c0d0e0f");
        byte[] input = Encoding.UTF8.GetBytes(message);

        using var dotNet = new System.Security.Cryptography.HMACMD5(key);
        byte[] netHash = dotNet.ComputeHash(input);

        using var ours = HmacMd5.Create(key);
        byte[] ourHash = ours.ComputeHash(input);

        Assert.That(ourHash, Is.EqualTo(netHash), $"HMAC-MD5 mismatch for: \"{message}\"");
    }
#pragma warning restore CS0618

    #endregion

    #region Behavioral Tests

    /// <summary>
    /// Different keys produce different HMAC outputs.
    /// </summary>
    [Test]
    public void DifferentKeysProduceDifferentOutputs()
    {
        byte[] key1 = new byte[32];
        byte[] key2 = new byte[32];
        key2[0] = 1;
        byte[] input = Encoding.UTF8.GetBytes("test");

        using var hmac1 = HmacSha256.Create(key1);
        using var hmac2 = HmacSha256.Create(key2);

        Assert.That(hmac1.ComputeHash(input), Is.Not.EqualTo(hmac2.ComputeHash(input)));
    }

    /// <summary>
    /// Test that Reset allows reuse.
    /// </summary>
    [Test]
    public void ResetAllowsReuse()
    {
        byte[] key = new byte[32];
        byte[] input = Encoding.UTF8.GetBytes("test");

        using var hmac = HmacSha256.Create(key);
        byte[] hash1 = hmac.ComputeHash(input);
        byte[] hash2 = hmac.ComputeHash(input);

        Assert.That(hash1, Is.EqualTo(hash2));
    }

    /// <summary>
    /// Test static Hash convenience method.
    /// </summary>
    [Test]
    public void StaticHashMethod()
    {
        byte[] key = new byte[32];
        byte[] input = Encoding.UTF8.GetBytes("test");

        byte[] hash1 = HmacSha256.Hash(key, input);

        using var hmac = HmacSha256.Create(key);
        byte[] hash2 = hmac.ComputeHash(input);

        Assert.That(hash1, Is.EqualTo(hash2));
    }

    /// <summary>
    /// Test incremental updates produce same result as single call.
    /// </summary>
    [Test]
    public void IncrementalUpdateProducesSameResult()
    {
        byte[] key = new byte[32];
        byte[] input = Encoding.UTF8.GetBytes("Hello, World!");

        using var hmac1 = HmacSha256.Create(key);
        byte[] hash1 = hmac1.ComputeHash(input);

        using var hmac2 = HmacSha256.Create(key);
        hmac2.Update(input.AsSpan(0, 7));
        hmac2.Update(input.AsSpan(7));
        byte[] result = new byte[hmac2.MacSize];
        hmac2.Finalize(result);

        Assert.That(result, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Test algorithm name property.
    /// </summary>
    [Test]
    public void AlgorithmNames()
    {
        byte[] key = new byte[32];

        using var sha256 = HmacSha256.Create(key);
        Assert.That(sha256.AlgorithmName, Is.EqualTo("HMAC-SHA256"));

        using var sha384 = HmacSha384.Create(key);
        Assert.That(sha384.AlgorithmName, Is.EqualTo("HMAC-SHA384"));

        using var sha512 = HmacSha512.Create(key);
        Assert.That(sha512.AlgorithmName, Is.EqualTo("HMAC-SHA512"));

        using var sha3 = HmacSha3_256.Create(key);
        Assert.That(sha3.AlgorithmName, Is.EqualTo("HMAC-SHA3-256"));
    }

    /// <summary>
    /// Test MacSize property.
    /// </summary>
    [Test]
    public void MacSizeProperties()
    {
        byte[] key = new byte[32];

        using var sha256 = HmacSha256.Create(key);
        Assert.That(sha256.MacSize, Is.EqualTo(32));

        using var sha384 = HmacSha384.Create(key);
        Assert.That(sha384.MacSize, Is.EqualTo(48));

        using var sha512 = HmacSha512.Create(key);
        Assert.That(sha512.MacSize, Is.EqualTo(64));
    }

    #endregion

    #region Helper Methods

    private static byte[] GenerateTestInput(int length)
    {
        byte[] input = new byte[length];
        for (int i = 0; i < length; i++)
        {
            input[i] = (byte)(i % 251);
        }
        return input;
    }

    #endregion
}
