// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.Poly1305;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Text;
using Poly1305 = CryptoHives.Foundation.Security.Cryptography.Mac.Poly1305;

/// <summary>
/// Tests for <see cref="Poly1305"/> MAC algorithm.
/// </summary>
/// <remarks>
/// Test vectors are from RFC 8439 and other standard sources.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Poly1305Tests
{
    #region Factory Method Tests

    /// <summary>
    /// Validate Poly1305 produces correct output size.
    /// </summary>
    [Test]
    public void Poly1305ProducesCorrectOutputSize()
    {
        byte[] key = new byte[32];
        using var poly = Poly1305.Create(key);
        Assert.That(poly.HashSize, Is.EqualTo(128));
    }

    /// <summary>
    /// Validate Poly1305 block size.
    /// </summary>
    [Test]
    public void Poly1305BlockSize()
    {
        byte[] key = new byte[32];
        using var poly = Poly1305.Create(key);
        Assert.That(poly.BlockSize, Is.EqualTo(16));
    }

    #endregion

    #region Algorithm Name Tests

    /// <summary>
    /// Validate Poly1305 algorithm name.
    /// </summary>
    [Test]
    public void Poly1305AlgorithmName()
    {
        byte[] key = new byte[32];
        using var poly = Poly1305.Create(key);
        Assert.That(poly.AlgorithmName, Is.EqualTo("Poly1305"));
    }

    #endregion

    #region RFC 8439 Test Vectors

    /// <summary>
    /// RFC 8439 Section 2.5.2 Test Vector.
    /// </summary>
    [Test]
    public void Poly1305Rfc8439Section252()
    {
        byte[] key = TestHelpers.FromHexString(
            "85d6be7857556d337f4452fe42d506a8" +
            "0103808afb0db2fd4abff6af4149f51b");

        byte[] message = Encoding.ASCII.GetBytes("Cryptographic Forum Research Group");

        byte[] expected = TestHelpers.FromHexString("a8061dc1305136c6c22b8baf0c0127a9");

        using var poly = Poly1305.Create(key);
        byte[] actual = poly.ComputeHash(message);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test with empty message.
    /// </summary>
    [Test]
    public void Poly1305EmptyMessage()
    {
        // For empty message, the output should be s (the last 16 bytes of the key)
        byte[] key = TestHelpers.FromHexString(
            "00000000000000000000000000000000" +
            "36e5f6b5c5e06070f0efca96227a863e");

        byte[] message = [];

        // With h = 0, the tag is just s
        byte[] expected = TestHelpers.FromHexString("36e5f6b5c5e06070f0efca96227a863e");

        using var poly = Poly1305.Create(key);
        byte[] actual = poly.ComputeHash(message);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Test Vector from NaCl/libsodium - single block.
    /// </summary>
    [Test]
    public void Poly1305SingleBlock()
    {
        byte[] key = TestHelpers.FromHexString(
            "746869732069732033322d6279746520" +
            "6b657920666f7220506f6c7931333035");

        byte[] message = TestHelpers.FromHexString("48656c6c6f20776f726c6421"); // "Hello world!"

        using var poly = Poly1305.Create(key);
        byte[] tag = poly.ComputeHash(message);

        // Verify tag is 16 bytes
        Assert.That(tag.Length, Is.EqualTo(16));
    }

    /// <summary>
    /// Test with exactly one block (16 bytes).
    /// </summary>
    [Test]
    public void Poly1305ExactlyOneBlock()
    {
        byte[] key = new byte[32];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;

        byte[] message = new byte[16];
        for (int i = 0; i < 16; i++) message[i] = (byte)(i + 1);

        using var poly1 = Poly1305.Create(key);
        byte[] tag1 = poly1.ComputeHash(message);

        // Verify deterministic
        using var poly2 = Poly1305.Create(key);
        byte[] tag2 = poly2.ComputeHash(message);

        Assert.That(tag1, Is.EqualTo(tag2));
        Assert.That(tag1.Length, Is.EqualTo(16));
    }

    /// <summary>
    /// Test with multiple blocks.
    /// </summary>
    [Test]
    public void Poly1305MultipleBlocks()
    {
        byte[] key = new byte[32];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;

        // 64 bytes = 4 blocks
        byte[] message = new byte[64];
        for (int i = 0; i < 64; i++) message[i] = (byte)i;

        using var poly = Poly1305.Create(key);
        byte[] tag = poly.ComputeHash(message);

        Assert.That(tag.Length, Is.EqualTo(16));
    }

    /// <summary>
    /// Test with key of all zeros (edge case).
    /// </summary>
    [Test]
    public void Poly1305ZeroKey()
    {
        byte[] key = new byte[32]; // All zeros
        byte[] message = Encoding.ASCII.GetBytes("test message");

        using var poly = Poly1305.Create(key);
        byte[] tag = poly.ComputeHash(message);

        // With r = 0, the accumulator stays 0, so tag = s = 0
        byte[] expected = new byte[16];
        Assert.That(tag, Is.EqualTo(expected));
    }

    #endregion

    #region Validation Tests

    /// <summary>
    /// Validate null key throws ArgumentNullException.
    /// </summary>
    [Test]
    public void NullKeyThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => Poly1305.Create(null!));
    }

    /// <summary>
    /// Validate wrong key size throws ArgumentException.
    /// </summary>
    [TestCase(0)]
    [TestCase(16)]
    [TestCase(31)]
    [TestCase(33)]
    [TestCase(64)]
    public void WrongKeySizeThrowsException(int keySize)
    {
        byte[] key = new byte[keySize];
        Assert.Throws<ArgumentException>(() => Poly1305.Create(key));
    }

    #endregion

    #region Incremental Hashing Tests

    /// <summary>
    /// Validate incremental hashing produces same result as one-shot.
    /// </summary>
    [Test]
    public void IncrementalHashingMatchesOneShot()
    {
        byte[] key = new byte[32];
        unchecked
        {
            for (int i = 0; i < 32; i++) key[i] = (byte)(i * 7);
        }

        byte[] message = new byte[100];
        unchecked
        {
            for (int i = 0; i < 100; i++) message[i] = (byte)(i * 3);
        }

        // One-shot
        byte[] expected;
        using (var poly1 = Poly1305.Create(key))
        {
            expected = poly1.ComputeHash(message);
        }

        // Incremental
        byte[] actual;
        using (var poly2 = Poly1305.Create(key))
        {
            poly2.TransformBlock(message, 0, 16, null, 0);
            poly2.TransformBlock(message, 16, 16, null, 0);
            poly2.TransformBlock(message, 32, 16, null, 0);
            poly2.TransformFinalBlock(message, 48, message.Length - 48);
            actual = poly2.Hash!;
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Validate incremental hashing with odd-sized chunks.
    /// </summary>
    [Test]
    public void IncrementalHashingWithOddChunks()
    {
        byte[] key = new byte[32];
        for (int i = 0; i < 32; i++) key[i] = (byte)(i + 1);

        byte[] message = new byte[50];
        for (int i = 0; i < 50; i++) message[i] = (byte)i;

        // One-shot
        byte[] expected;
        using (var poly1 = Poly1305.Create(key))
        {
            expected = poly1.ComputeHash(message);
        }

        // Incremental with odd chunks
        byte[] actual;
        using (var poly2 = Poly1305.Create(key))
        {
            poly2.TransformBlock(message, 0, 7, null, 0);
            poly2.TransformBlock(message, 7, 13, null, 0);
            poly2.TransformBlock(message, 20, 19, null, 0);
            poly2.TransformFinalBlock(message, 39, message.Length - 39);
            actual = poly2.Hash!;
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Validate incremental hashing one byte at a time.
    /// </summary>
    [Test]
    public void IncrementalHashingByteByByte()
    {
        byte[] key = new byte[32];
        for (int i = 0; i < 32; i++) key[i] = (byte)(i ^ 0xAA);

        byte[] message = Encoding.ASCII.GetBytes("Hello, Poly1305!");

        // One-shot
        byte[] expected;
        using (var poly1 = Poly1305.Create(key))
        {
            expected = poly1.ComputeHash(message);
        }

        // Byte by byte
        byte[] actual;
        using (var poly2 = Poly1305.Create(key))
        {
            for (int i = 0; i < message.Length - 1; i++)
            {
                poly2.TransformBlock(message, i, 1, null, 0);
            }
            poly2.TransformFinalBlock(message, message.Length - 1, 1);
            actual = poly2.Hash!;
        }

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region Key Property Tests

    /// <summary>
    /// Validate Key property returns a copy of the key.
    /// </summary>
    [Test]
    public void KeyPropertyReturnsCopy()
    {
        byte[] key = new byte[32];
        for (int i = 0; i < 32; i++) key[i] = (byte)i;

        using var poly = Poly1305.Create(key);
        byte[] retrievedKey = poly.Key;

        Assert.That(retrievedKey, Is.EqualTo(key));
        Assert.That(retrievedKey, Is.Not.SameAs(key));
    }

    #endregion

    #region Determinism Tests

    /// <summary>
    /// Verify same key and message produces same tag.
    /// </summary>
    [Test]
    public void SameInputProducesSameOutput()
    {
        byte[] key = TestHelpers.FromHexString(
            "85d6be7857556d337f4452fe42d506a8" +
            "0103808afb0db2fd4abff6af4149f51b");

        byte[] message = Encoding.ASCII.GetBytes("Test message for determinism");

        using var poly1 = Poly1305.Create(key);
        byte[] tag1 = poly1.ComputeHash(message);

        using var poly2 = Poly1305.Create(key);
        byte[] tag2 = poly2.ComputeHash(message);

        Assert.That(tag1, Is.EqualTo(tag2));
    }

    /// <summary>
    /// Verify different messages produce different tags.
    /// </summary>
    [Test]
    public void DifferentMessagesProduceDifferentTags()
    {
        byte[] key = new byte[32];
        for (int i = 0; i < 32; i++) key[i] = (byte)(i + 1);

        byte[] message1 = Encoding.ASCII.GetBytes("Message 1");
        byte[] message2 = Encoding.ASCII.GetBytes("Message 2");

        using var poly1 = Poly1305.Create(key);
        byte[] tag1 = poly1.ComputeHash(message1);

        using var poly2 = Poly1305.Create(key);
        byte[] tag2 = poly2.ComputeHash(message2);

        Assert.That(tag1, Is.Not.EqualTo(tag2));
    }

    #endregion
}
