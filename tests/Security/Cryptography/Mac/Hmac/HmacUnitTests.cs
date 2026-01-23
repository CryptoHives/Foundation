// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.Hmac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for <see cref="Hmac"/> MAC algorithm.
/// </summary>
/// <remarks>
/// Test vectors are from RFC 4231 (HMAC-SHA-224/256/384/512) and RFC 2202 (HMAC-SHA1/MD5).
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class HmacTests
{
    /// <summary>
    /// Creates a byte array filled with the specified value.
    /// Replaces Array.Fill for .NET Framework compatibility.
    /// </summary>
    private static byte[] CreateFilledArray(int length, byte value)
    {
        byte[] array = new byte[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = value;
        }
        return array;
    }

    #region Factory Method Tests

    /// <summary>
    /// Validate HMAC-SHA256 produces correct output size.
    /// </summary>
    [Test]
    public void HmacSha256ProducesCorrectOutputSize()
    {
        byte[] key = new byte[32];
        using var hmac = Hmac.CreateSha256(key);
        Assert.That(hmac.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate HMAC-SHA384 produces correct output size.
    /// </summary>
    [Test]
    public void HmacSha384ProducesCorrectOutputSize()
    {
        byte[] key = new byte[32];
        using var hmac = Hmac.CreateSha384(key);
        Assert.That(hmac.HashSize, Is.EqualTo(384));
    }

    /// <summary>
    /// Validate HMAC-SHA512 produces correct output size.
    /// </summary>
    [Test]
    public void HmacSha512ProducesCorrectOutputSize()
    {
        byte[] key = new byte[32];
        using var hmac = Hmac.CreateSha512(key);
        Assert.That(hmac.HashSize, Is.EqualTo(512));
    }

    #endregion

    #region Algorithm Name Tests

    /// <summary>
    /// Validate HMAC-SHA256 algorithm name.
    /// </summary>
    [Test]
    public void HmacSha256AlgorithmName()
    {
        byte[] key = new byte[32];
        using var hmac = Hmac.CreateSha256(key);
        Assert.That(hmac.AlgorithmName, Is.EqualTo("HMAC-SHA-256"));
    }

    /// <summary>
    /// Validate HMAC-SHA512 algorithm name.
    /// </summary>
    [Test]
    public void HmacSha512AlgorithmName()
    {
        byte[] key = new byte[32];
        using var hmac = Hmac.CreateSha512(key);
        Assert.That(hmac.AlgorithmName, Is.EqualTo("HMAC-SHA-512"));
    }

    /// <summary>
    /// Validate HMAC-SHA3-256 algorithm name.
    /// </summary>
    [Test]
    public void HmacSha3_256AlgorithmName()
    {
        byte[] key = new byte[32];
        using var hmac = Hmac.CreateSha3_256(key);
        Assert.That(hmac.AlgorithmName, Is.EqualTo("HMAC-SHA3-256"));
    }

    #endregion

    #region RFC 4231 Test Vectors - HMAC-SHA-256

    /// <summary>
    /// RFC 4231 Test Case 1 - HMAC-SHA-256.
    /// Key = 20 bytes of 0x0b, Data = "Hi There"
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase1()
    {
        byte[] key = CreateFilledArray(20, 0x0b);
        byte[] data = Encoding.ASCII.GetBytes("Hi There");
        byte[] expected = TestHelpers.FromHexString("b0344c61d8db38535ca8afceaf0bf12b881dc200c9833da726e9376c2e32cff7");

        using var hmac = Hmac.CreateSha256(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 2 - HMAC-SHA-256.
    /// Key = "Jefe", Data = "what do ya want for nothing?"
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase2()
    {
        byte[] key = Encoding.ASCII.GetBytes("Jefe");
        byte[] data = Encoding.ASCII.GetBytes("what do ya want for nothing?");
        byte[] expected = TestHelpers.FromHexString("5bdcc146bf60754e6a042426089575c75a003f089d2739839dec58b964ec3843");

        using var hmac = Hmac.CreateSha256(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 3 - HMAC-SHA-256.
    /// Key = 20 bytes of 0xaa, Data = 50 bytes of 0xdd
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase3()
    {
        byte[] key = CreateFilledArray(20, 0xaa);
        byte[] data = CreateFilledArray(50, 0xdd);
        byte[] expected = TestHelpers.FromHexString("773ea91e36800e46854db8ebd09181a72959098b3ef8c122d9635514ced565fe");

        using var hmac = Hmac.CreateSha256(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 4 - HMAC-SHA-256.
    /// Key = 0x0102030405...19 (25 bytes), Data = 50 bytes of 0xcd
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase4()
    {
        byte[] key = TestHelpers.FromHexString("0102030405060708090a0b0c0d0e0f10111213141516171819");
        byte[] data = CreateFilledArray(50, 0xcd);
        byte[] expected = TestHelpers.FromHexString("82558a389a443c0ea4cc819899f2083a85f0faa3e578f8077a2e3ff46729665b");

        using var hmac = Hmac.CreateSha256(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 6 - HMAC-SHA-256 with key larger than block size.
    /// Key = 131 bytes of 0xaa, Data = "Test Using Larger Than Block-Size Key - Hash Key First"
    /// </summary>
    [Test]
    public void HmacSha256Rfc4231TestCase6LongKey()
    {
        byte[] key = CreateFilledArray(131, 0xaa);
        byte[] data = Encoding.ASCII.GetBytes("Test Using Larger Than Block-Size Key - Hash Key First");
        byte[] expected = TestHelpers.FromHexString("60e431591ee0b67f0d8a26aacbf5b77f8e0bc6213728c5140546040f0ee37f54");

        using var hmac = Hmac.CreateSha256(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region RFC 4231 Test Vectors - HMAC-SHA-512

    /// <summary>
    /// RFC 4231 Test Case 1 - HMAC-SHA-512.
    /// Key = 20 bytes of 0x0b, Data = "Hi There"
    /// </summary>
    [Test]
    public void HmacSha512Rfc4231TestCase1()
    {
        byte[] key = CreateFilledArray(20, 0x0b);
        byte[] data = Encoding.ASCII.GetBytes("Hi There");
        byte[] expected = TestHelpers.FromHexString(
            "87aa7cdea5ef619d4ff0b4241a1d6cb02379f4e2ce4ec2787ad0b30545e17cde" +
            "daa833b7d6b8a702038b274eaea3f4e4be9d914eeb61f1702e696c203a126854");

        using var hmac = Hmac.CreateSha512(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 4231 Test Case 2 - HMAC-SHA-512.
    /// Key = "Jefe", Data = "what do ya want for nothing?"
    /// </summary>
    [Test]
    public void HmacSha512Rfc4231TestCase2()
    {
        byte[] key = Encoding.ASCII.GetBytes("Jefe");
        byte[] data = Encoding.ASCII.GetBytes("what do ya want for nothing?");
        byte[] expected = TestHelpers.FromHexString(
            "164b7a7bfcf819e2e395fbe73b56e0a387bd64222e831fd610270cd7ea250554" +
            "9758bf75c05a994a6d034f65f8f0e6fdcaeab1a34d4a6b4b636e070a38bce737");

        using var hmac = Hmac.CreateSha512(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region RFC 4231 Test Vectors - HMAC-SHA-384

    /// <summary>
    /// RFC 4231 Test Case 1 - HMAC-SHA-384.
    /// Key = 20 bytes of 0x0b, Data = "Hi There"
    /// </summary>
    [Test]
    public void HmacSha384Rfc4231TestCase1()
    {
        byte[] key = CreateFilledArray(20, 0x0b);
        byte[] data = Encoding.ASCII.GetBytes("Hi There");
        byte[] expected = TestHelpers.FromHexString(
            "afd03944d84895626b0825f4ab46907f15f9dadbe4101ec682aa034c7cebc59c" +
            "faea9ea9076ede7f4af152e8b2fa9cb6");

        using var hmac = Hmac.CreateSha384(key);
        byte[] actual = hmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region Validation Tests

    /// <summary>
    /// Validate null key throws ArgumentNullException.
    /// </summary>
    [Test]
    public void NullKeyThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => Hmac.CreateSha256(null!));
    }

    /// <summary>
    /// Validate empty key throws ArgumentNullException.
    /// </summary>
    [Test]
    public void EmptyKeyThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => Hmac.CreateSha256([]));
    }

    /// <summary>
    /// Validate null algorithm name throws ArgumentNullException.
    /// </summary>
    [Test]
    public void NullAlgorithmThrowsException()
    {
        byte[] key = new byte[32];
        Assert.Throws<ArgumentNullException>(() => Hmac.Create(null!, key));
    }

    /// <summary>
    /// Validate unknown algorithm name throws ArgumentException.
    /// </summary>
    [Test]
    public void UnknownAlgorithmThrowsException()
    {
        byte[] key = new byte[32];
        Assert.Throws<ArgumentException>(() => Hmac.Create("UNKNOWN-HASH", key));
    }

    #endregion

    #region Incremental Hashing Tests

    /// <summary>
    /// Validate incremental hashing produces same result as one-shot.
    /// </summary>
    [Test]
    public void IncrementalHashingMatchesOneShot()
    {
        byte[] key = Encoding.ASCII.GetBytes("my secret key");
        byte[] data = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog");

        // One-shot
        byte[] expected;
        using (var hmac1 = Hmac.CreateSha256(key))
        {
            expected = hmac1.ComputeHash(data);
        }

        // Incremental
        byte[] actual;
        using (var hmac2 = Hmac.CreateSha256(key))
        {
            hmac2.TransformBlock(data, 0, 10, null, 0);
            hmac2.TransformBlock(data, 10, 20, null, 0);
            hmac2.TransformFinalBlock(data, 30, data.Length - 30);
            actual = hmac2.Hash!;
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region Comparison with .NET Built-in HMAC

    /// <summary>
    /// Compare with .NET built-in HMAC-SHA256 implementation.
    /// </summary>
    [Test]
    public void CompareWithDotNetHmacSha256()
    {
        byte[] key = Encoding.UTF8.GetBytes("SuperSecretKey12345");
        byte[] data = Encoding.UTF8.GetBytes("Hello, World! This is a test message for HMAC.");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA256(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha256(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare with .NET built-in HMAC-SHA512 implementation.
    /// </summary>
    [Test]
    public void CompareWithDotNetHmacSha512()
    {
        byte[] key = Encoding.UTF8.GetBytes("AnotherSecretKeyForTesting");
        byte[] data = Encoding.UTF8.GetBytes("Sample data for SHA-512 HMAC verification.");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA512(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha512(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare with .NET built-in HMAC-SHA384 implementation.
    /// </summary>
    [Test]
    public void CompareWithDotNetHmacSha384()
    {
        byte[] key = Encoding.UTF8.GetBytes("YetAnotherKey");
        byte[] data = Encoding.UTF8.GetBytes("Testing SHA-384 HMAC.");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA384(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha384(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion
}
