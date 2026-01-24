// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.Hmac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
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

    /// <summary>
    /// Compare with .NET built-in HMAC-SHA1 implementation.
    /// </summary>
    [Test]
    public void CompareWithDotNetHmacSha1()
    {
        byte[] key = Encoding.UTF8.GetBytes("LegacySha1Key");
        byte[] data = Encoding.UTF8.GetBytes("Testing SHA-1 HMAC for legacy compatibility.");

#pragma warning disable CS0618 // Intentionally testing deprecated algorithm
        using var dotNetHmac = new System.Security.Cryptography.HMACSHA1(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha1(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);
#pragma warning restore CS0618

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare with .NET built-in HMAC-MD5 implementation.
    /// </summary>
    [Test]
    public void CompareWithDotNetHmacMd5()
    {
        byte[] key = Encoding.UTF8.GetBytes("LegacyMd5Key");
        byte[] data = Encoding.UTF8.GetBytes("Testing MD5 HMAC for legacy compatibility.");

#pragma warning disable CS0618 // Intentionally testing deprecated algorithm
        using var dotNetHmac = new System.Security.Cryptography.HMACMD5(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateMd5(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);
#pragma warning restore CS0618

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region Extended .NET Comparison Tests

    /// <summary>
    /// Test data source for parameterized comparison tests.
    /// </summary>
    private static System.Collections.IEnumerable ComparisonTestCases()
    {
        // Various key sizes
        yield return new TestCaseData(new byte[16], Encoding.UTF8.GetBytes("Short key test")).SetName("Key16Bytes");
        yield return new TestCaseData(new byte[32], Encoding.UTF8.GetBytes("Medium key test")).SetName("Key32Bytes");
        yield return new TestCaseData(new byte[64], Encoding.UTF8.GetBytes("Block-size key test")).SetName("Key64Bytes");
        yield return new TestCaseData(new byte[128], Encoding.UTF8.GetBytes("Long key test")).SetName("Key128Bytes");

        // Various data sizes
        byte[] key = Encoding.UTF8.GetBytes("TestKey12345");
        yield return new TestCaseData(key, Array.Empty<byte>()).SetName("EmptyData");
        yield return new TestCaseData(key, new byte[1]).SetName("SingleByteData");
        yield return new TestCaseData(key, new byte[15]).SetName("Data15Bytes");
        yield return new TestCaseData(key, new byte[16]).SetName("Data16Bytes");
        yield return new TestCaseData(key, new byte[17]).SetName("Data17Bytes");
        yield return new TestCaseData(key, new byte[63]).SetName("Data63Bytes");
        yield return new TestCaseData(key, new byte[64]).SetName("Data64Bytes");
        yield return new TestCaseData(key, new byte[65]).SetName("Data65Bytes");
        yield return new TestCaseData(key, new byte[1000]).SetName("Data1000Bytes");
        yield return new TestCaseData(key, new byte[10000]).SetName("Data10000Bytes");
    }

    /// <summary>
    /// Comprehensive HMAC-SHA256 comparison with .NET across various inputs.
    /// </summary>
    [TestCaseSource(nameof(ComparisonTestCases))]
    public void CompareHmacSha256Comprehensive(byte[] key, byte[] data)
    {
        using var dotNetHmac = new System.Security.Cryptography.HMACSHA256(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha256(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Comprehensive HMAC-SHA384 comparison with .NET across various inputs.
    /// </summary>
    [TestCaseSource(nameof(ComparisonTestCases))]
    public void CompareHmacSha384Comprehensive(byte[] key, byte[] data)
    {
        using var dotNetHmac = new System.Security.Cryptography.HMACSHA384(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha384(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Comprehensive HMAC-SHA512 comparison with .NET across various inputs.
    /// </summary>
    [TestCaseSource(nameof(ComparisonTestCases))]
    public void CompareHmacSha512Comprehensive(byte[] key, byte[] data)
    {
        using var dotNetHmac = new System.Security.Cryptography.HMACSHA512(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha512(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare incremental hashing with .NET HMAC.
    /// </summary>
    [Test]
    public void CompareIncrementalHashingWithDotNet()
    {
        byte[] key = Encoding.UTF8.GetBytes("IncrementalTestKey");
        byte[] data = new byte[200];
        for (int i = 0; i < data.Length; i++) data[i] = (byte)(i % 256);

        // .NET one-shot
        using var dotNetHmac = new System.Security.Cryptography.HMACSHA256(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        // CryptoHives incremental
        using var cryptoHivesHmac = Hmac.CreateSha256(key);
        cryptoHivesHmac.TransformBlock(data, 0, 50, null, 0);
        cryptoHivesHmac.TransformBlock(data, 50, 75, null, 0);
        cryptoHivesHmac.TransformFinalBlock(data, 125, 75);
        byte[] actual = cryptoHivesHmac.Hash!;

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare with random data to ensure no edge case failures.
    /// </summary>
    [Test]
    public void CompareWithRandomData()
    {
        var random = new Random(42); // Fixed seed for reproducibility

        for (int trial = 0; trial < 10; trial++)
        {
            // Random key size between 1 and 128 bytes
            int keySize = random.Next(1, 129);
            byte[] key = new byte[keySize];
            random.NextBytes(key);

            // Random data size between 0 and 1000 bytes
            int dataSize = random.Next(0, 1001);
            byte[] data = new byte[dataSize];
            random.NextBytes(data);

            using var dotNetHmac = new System.Security.Cryptography.HMACSHA256(key);
            byte[] expected = dotNetHmac.ComputeHash(data);

            using var cryptoHivesHmac = Hmac.CreateSha256(key);
            byte[] actual = cryptoHivesHmac.ComputeHash(data);

            Assert.That(actual, Is.EqualTo(expected), $"Failed on trial {trial} with keySize={keySize}, dataSize={dataSize}");
        }
    }

    /// <summary>
    /// Compare key longer than block size (triggers key hashing).
    /// </summary>
    [Test]
    public void CompareWithKeyLongerThanBlockSize()
    {
        // SHA-256 block size is 64 bytes, so use a 100-byte key
        byte[] key = new byte[100];
        for (int i = 0; i < key.Length; i++) key[i] = (byte)(i + 1);

        byte[] data = Encoding.UTF8.GetBytes("Testing with key longer than block size");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA256(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha256(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare key exactly equal to block size.
    /// </summary>
    [Test]
    public void CompareWithKeyEqualToBlockSize()
    {
        // SHA-256 block size is 64 bytes
        byte[] key = new byte[64];
        for (int i = 0; i < key.Length; i++) key[i] = (byte)(i + 1);

        byte[] data = Encoding.UTF8.GetBytes("Testing with key equal to block size");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA256(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha256(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare SHA-512 with key longer than its block size (128 bytes).
    /// </summary>
    [Test]
    public void CompareHmacSha512WithLongKey()
    {
        // SHA-512 block size is 128 bytes, so use a 200-byte key
        byte[] key = new byte[200];
        for (int i = 0; i < key.Length; i++) key[i] = (byte)(i + 1);

        byte[] data = Encoding.UTF8.GetBytes("Testing SHA-512 with key longer than 128-byte block size");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA512(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha512(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare multiple sequential computations with same instance (reuse test).
    /// </summary>
    [Test]
    public void CompareMultipleComputationsWithSameKey()
    {
        byte[] key = Encoding.UTF8.GetBytes("ReusableKey");
        byte[] data1 = Encoding.UTF8.GetBytes("First message");
        byte[] data2 = Encoding.UTF8.GetBytes("Second message");
        byte[] data3 = Encoding.UTF8.GetBytes("Third message");

        // .NET computations
        using var dotNetHmac = new System.Security.Cryptography.HMACSHA256(key);
        byte[] expected1 = dotNetHmac.ComputeHash(data1);
        byte[] expected2 = dotNetHmac.ComputeHash(data2);
        byte[] expected3 = dotNetHmac.ComputeHash(data3);

        // CryptoHives computations (new instance for each to match .NET behavior)
        using var cryptoHives1 = Hmac.CreateSha256(key);
        byte[] actual1 = cryptoHives1.ComputeHash(data1);

        using var cryptoHives2 = Hmac.CreateSha256(key);
        byte[] actual2 = cryptoHives2.ComputeHash(data2);

        using var cryptoHives3 = Hmac.CreateSha256(key);
        byte[] actual3 = cryptoHives3.ComputeHash(data3);

        Assert.That(actual1, Is.EqualTo(expected1));
        Assert.That(actual2, Is.EqualTo(expected2));
        Assert.That(actual3, Is.EqualTo(expected3));
    }

    #endregion

#if NET8_0_OR_GREATER
    #region HMAC-SHA3 Comparison Tests (.NET 8+)

    /// <summary>
    /// Compare with .NET built-in HMAC-SHA3-256 implementation.
    /// </summary>
    [Test]
    public void CompareWithDotNetHmacSha3_256()
    {
        byte[] key = Encoding.UTF8.GetBytes("TestKeyForSha3_256");
        byte[] data = Encoding.UTF8.GetBytes("Hello, World! Testing HMAC-SHA3-256.");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_256(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha3_256(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare with .NET built-in HMAC-SHA3-512 implementation.
    /// </summary>
    [Test]
    public void CompareWithDotNetHmacSha3_512()
    {
        byte[] key = Encoding.UTF8.GetBytes("TestKeyForSha3_512");
        byte[] data = Encoding.UTF8.GetBytes("Hello, World! Testing HMAC-SHA3-512.");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_512(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha3_512(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare HMAC-SHA3-256 with empty data.
    /// </summary>
    [Test]
    public void CompareHmacSha3_256EmptyData()
    {
        byte[] key = Encoding.UTF8.GetBytes("KeyForEmptyData");
        byte[] data = Array.Empty<byte>();

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_256(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha3_256(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare HMAC-SHA3-512 with empty data.
    /// </summary>
    [Test]
    public void CompareHmacSha3_512EmptyData()
    {
        byte[] key = Encoding.UTF8.GetBytes("KeyForEmptyData");
        byte[] data = Array.Empty<byte>();

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_512(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha3_512(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare HMAC-SHA3-256 with key longer than block size.
    /// SHA3-256 has a block size of 136 bytes.
    /// </summary>
    [Test]
    public void CompareHmacSha3_256WithLongKey()
    {
        // SHA3-256 block size is 136 bytes, so use a 200-byte key
        byte[] key = new byte[200];
        for (int i = 0; i < key.Length; i++) key[i] = (byte)(i + 1);

        byte[] data = Encoding.UTF8.GetBytes("Testing SHA3-256 with key longer than block size");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_256(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha3_256(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare HMAC-SHA3-512 with key longer than block size.
    /// SHA3-512 has a block size of 72 bytes.
    /// </summary>
    [Test]
    public void CompareHmacSha3_512WithLongKey()
    {
        // SHA3-512 block size is 72 bytes, so use a 100-byte key
        byte[] key = new byte[100];
        for (int i = 0; i < key.Length; i++) key[i] = (byte)(i + 1);

        byte[] data = Encoding.UTF8.GetBytes("Testing SHA3-512 with key longer than block size");

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_512(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha3_512(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Comprehensive HMAC-SHA3-256 comparison with various data sizes.
    /// </summary>
    [TestCase(1)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(135)]
    [TestCase(136)]
    [TestCase(137)]
    [TestCase(1000)]
    public void CompareHmacSha3_256VariousDataSizes(int dataSize)
    {
        byte[] key = Encoding.UTF8.GetBytes("TestKeyForSha3");
        byte[] data = new byte[dataSize];
        for (int i = 0; i < dataSize; i++) data[i] = (byte)(i % 256);

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_256(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha3_256(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Comprehensive HMAC-SHA3-512 comparison with various data sizes.
    /// </summary>
    [TestCase(1)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(71)]
    [TestCase(72)]
    [TestCase(73)]
    [TestCase(1000)]
    public void CompareHmacSha3_512VariousDataSizes(int dataSize)
    {
        byte[] key = Encoding.UTF8.GetBytes("TestKeyForSha3");
        byte[] data = new byte[dataSize];
        for (int i = 0; i < dataSize; i++) data[i] = (byte)(i % 256);

        using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_512(key);
        byte[] expected = dotNetHmac.ComputeHash(data);

        using var cryptoHivesHmac = Hmac.CreateSha3_512(key);
        byte[] actual = cryptoHivesHmac.ComputeHash(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Compare with random data for HMAC-SHA3-256.
    /// </summary>
    [Test]
    public void CompareHmacSha3_256WithRandomData()
    {
        var random = new Random(123); // Fixed seed for reproducibility

        for (int trial = 0; trial < 10; trial++)
        {
            int keySize = random.Next(1, 200);
            byte[] key = new byte[keySize];
            random.NextBytes(key);

            int dataSize = random.Next(0, 500);
            byte[] data = new byte[dataSize];
            random.NextBytes(data);

            using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_256(key);
            byte[] expected = dotNetHmac.ComputeHash(data);

            using var cryptoHivesHmac = Hmac.CreateSha3_256(key);
            byte[] actual = cryptoHivesHmac.ComputeHash(data);

            Assert.That(actual, Is.EqualTo(expected), $"Failed on trial {trial}");
        }
    }

    /// <summary>
    /// Compare with random data for HMAC-SHA3-512.
    /// </summary>
    [Test]
    public void CompareHmacSha3_512WithRandomData()
    {
        var random = new Random(456); // Fixed seed for reproducibility

        for (int trial = 0; trial < 10; trial++)
        {
            int keySize = random.Next(1, 200);
            byte[] key = new byte[keySize];
            random.NextBytes(key);

            int dataSize = random.Next(0, 500);
            byte[] data = new byte[dataSize];
            random.NextBytes(data);

            using var dotNetHmac = new System.Security.Cryptography.HMACSHA3_512(key);
            byte[] expected = dotNetHmac.ComputeHash(data);

            using var cryptoHivesHmac = Hmac.CreateSha3_512(key);
            byte[] actual = cryptoHivesHmac.ComputeHash(data);

            Assert.That(actual, Is.EqualTo(expected), $"Failed on trial {trial}");
        }
    }

    #endregion
#endif
}
