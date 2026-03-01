// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Mac.Poly1305;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;
using System.Text;

/// <summary>
/// Tests for <see cref="Poly1305Mac"/> using RFC 8439 test vectors,
/// incremental chunking, and cross-validation against <see cref="Poly1305Core"/>.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Poly1305MacTests
{
    #region RFC 8439 Test Vectors

    /// <summary>
    /// RFC 8439 Section 2.5.2 — the canonical Poly1305 test vector.
    /// </summary>
    [Test]
    public void Rfc8439Section252()
    {
        byte[] key = TestHelpers.FromHexString(
            "85d6be7857556d337f4452fe42d506a8" +
            "0103808afb0db2fd4abff6af4149f51b");
        byte[] message = Encoding.ASCII.GetBytes("Cryptographic Forum Research Group");
        byte[] expected = TestHelpers.FromHexString("a8061dc1305136c6c22b8baf0c0127a9");

        using var mac = Poly1305Mac.Create(key);
        byte[] tag = mac.ComputeHash(message);

        Assert.That(tag, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 8439 Section 2.5.2 using the streaming Update/Finalize API.
    /// </summary>
    [Test]
    public void Rfc8439Section252Streaming()
    {
        byte[] key = TestHelpers.FromHexString(
            "85d6be7857556d337f4452fe42d506a8" +
            "0103808afb0db2fd4abff6af4149f51b");
        byte[] message = Encoding.ASCII.GetBytes("Cryptographic Forum Research Group");
        byte[] expected = TestHelpers.FromHexString("a8061dc1305136c6c22b8baf0c0127a9");

        using var mac = Poly1305Mac.Create(key);
        mac.Update(message);
        byte[] tag = new byte[Poly1305Mac.TagSizeBytes];
        mac.Finalize(tag);

        Assert.That(tag, Is.EqualTo(expected));
    }

    /// <summary>
    /// RFC 8439 Appendix A.3 — Test Vector #1 (all-zero key and message).
    /// </summary>
    [Test]
    public void Rfc8439AppendixA3Vector1()
    {
        byte[] key = new byte[32];
        byte[] message = new byte[64];
        byte[] expected = TestHelpers.FromHexString("00000000000000000000000000000000");

        using var mac = Poly1305Mac.Create(key);
        byte[] tag = mac.ComputeHash(message);

        Assert.That(tag, Is.EqualTo(expected));
    }

    #endregion

    #region Cross-Validation Against Poly1305Core

    /// <summary>
    /// Verifies that <see cref="Poly1305Mac.ComputeHash"/> matches
    /// <see cref="Poly1305Core.ComputeTag"/> for various input sizes.
    /// </summary>
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(33)]
    [TestCase(63)]
    [TestCase(64)]
    [TestCase(100)]
    [TestCase(256)]
    [TestCase(1024)]
    [TestCase(4096)]
    public void OneShotMatchesPoly1305Core(int messageSize)
    {
        var rng = new Random(messageSize * 7 + 42);
        byte[] key = new byte[32];
        rng.NextBytes(key);
        // Clamp key r-portion to valid Poly1305 key (done internally, but needed for comparison)
        byte[] message = new byte[messageSize];
        if (messageSize > 0) rng.NextBytes(message);

        byte[] expected = new byte[16];
        Poly1305Core.ComputeTag(key, message, expected);

        using var mac = Poly1305Mac.Create(key);
        byte[] actual = mac.ComputeHash(message);

        Assert.That(actual, Is.EqualTo(expected),
            $"Poly1305Mac mismatch for message size {messageSize}");
    }

    #endregion

    #region Incremental Chunking

    /// <summary>
    /// Verifies that feeding data in random-sized chunks produces the same tag
    /// as one-shot computation.
    /// </summary>
    [TestCase(1)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(31)]
    [TestCase(32)]
    [TestCase(48)]
    [TestCase(64)]
    [TestCase(100)]
    [TestCase(256)]
    [TestCase(1024)]
    public void IncrementalChunksMatchOneShot(int messageSize)
    {
        var rng = new Random(messageSize * 13 + 77);
        byte[] key = new byte[32];
        rng.NextBytes(key);
        byte[] message = new byte[messageSize];
        rng.NextBytes(message);

        using var mac = Poly1305Mac.Create(key);
        byte[] expected = mac.ComputeHash(message);

        mac.Reset();
        int offset = 0;
        while (offset < message.Length)
        {
            int remaining = message.Length - offset;
            int chunkSize = Math.Min(1 + rng.Next(32), remaining);
            mac.Update(message.AsSpan(offset, chunkSize));
            offset += chunkSize;
        }

        byte[] actual = new byte[Poly1305Mac.TagSizeBytes];
        mac.Finalize(actual);

        Assert.That(actual, Is.EqualTo(expected),
            $"Incremental mismatch for message size {messageSize}");
    }

    /// <summary>
    /// Verifies that single-byte incremental updates produce the correct tag.
    /// </summary>
    [Test]
    public void SingleByteUpdatesMatchOneShot()
    {
        byte[] key = TestHelpers.FromHexString(
            "85d6be7857556d337f4452fe42d506a8" +
            "0103808afb0db2fd4abff6af4149f51b");
        byte[] message = Encoding.ASCII.GetBytes("Cryptographic Forum Research Group");
        byte[] expected = TestHelpers.FromHexString("a8061dc1305136c6c22b8baf0c0127a9");

        using var mac = Poly1305Mac.Create(key);
        for (int i = 0; i < message.Length; i++)
        {
            mac.Update(message.AsSpan(i, 1));
        }

        byte[] actual = new byte[Poly1305Mac.TagSizeBytes];
        mac.Finalize(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    #endregion

    #region Reset and Reuse

    /// <summary>
    /// Verifies that <see cref="Poly1305Mac.Reset"/> allows the instance to be
    /// reused with the same key, producing identical results.
    /// </summary>
    [Test]
    public void ResetAllowsReuse()
    {
        var rng = new Random(99);
        byte[] key = new byte[32];
        rng.NextBytes(key);
        byte[] message = new byte[100];
        rng.NextBytes(message);

        using var mac = Poly1305Mac.Create(key);
        byte[] first = mac.ComputeHash(message);

        mac.Reset();
        byte[] second = mac.ComputeHash(message);

        Assert.That(second, Is.EqualTo(first), "Reset did not restore initial state");
    }

    /// <summary>
    /// Verifies that multiple reset/reuse cycles produce consistent results.
    /// </summary>
    [Test]
    public void MultipleResetCyclesProduceConsistentResults()
    {
        var rng = new Random(123);
        byte[] key = new byte[32];
        rng.NextBytes(key);
        byte[] message = new byte[200];
        rng.NextBytes(message);

        using var mac = Poly1305Mac.Create(key);
        byte[] expected = mac.ComputeHash(message);

        for (int i = 0; i < 5; i++)
        {
            mac.Reset();
            byte[] actual = mac.ComputeHash(message);
            Assert.That(actual, Is.EqualTo(expected), $"Mismatch on cycle {i}");
        }
    }

    #endregion

    #region Edge Cases

    /// <summary>
    /// Verifies that computing a tag for an empty message produces a valid result.
    /// </summary>
    [Test]
    public void EmptyMessageProducesValidTag()
    {
        byte[] key = new byte[32];
        new Random(42).NextBytes(key);

        byte[] expected = new byte[16];
        Poly1305Core.ComputeTag(key, [], expected);

        using var mac = Poly1305Mac.Create(key);
        byte[] actual = mac.ComputeHash([]);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Verifies that a message exactly one block (16 bytes) long produces the correct tag.
    /// </summary>
    [Test]
    public void ExactBlockSizeMessage()
    {
        byte[] key = new byte[32];
        new Random(42).NextBytes(key);
        byte[] message = new byte[16];
        new Random(77).NextBytes(message);

        byte[] expected = new byte[16];
        Poly1305Core.ComputeTag(key, message, expected);

        using var mac = Poly1305Mac.Create(key);
        byte[] actual = mac.ComputeHash(message);

        Assert.That(actual, Is.EqualTo(expected));
    }

    /// <summary>
    /// Verifies that different keys produce different tags for the same message.
    /// </summary>
    [Test]
    public void DifferentKeysProduceDifferentTags()
    {
        byte[] key1 = new byte[32];
        byte[] key2 = new byte[32];
        new Random(1).NextBytes(key1);
        new Random(2).NextBytes(key2);
        byte[] message = Encoding.ASCII.GetBytes("test message");

        using var mac1 = Poly1305Mac.Create(key1);
        using var mac2 = Poly1305Mac.Create(key2);

        byte[] tag1 = mac1.ComputeHash(message);
        byte[] tag2 = mac2.ComputeHash(message);

        Assert.That(tag1, Is.Not.EqualTo(tag2));
    }

    #endregion

    #region Property Validation

    /// <summary>
    /// Verifies that <see cref="Poly1305Mac.AlgorithmName"/> returns the expected value.
    /// </summary>
    [Test]
    public void AlgorithmNameIsPoly1305()
    {
        using var mac = Poly1305Mac.Create(new byte[32]);
        Assert.That(mac.AlgorithmName, Is.EqualTo("Poly1305"));
    }

    /// <summary>
    /// Verifies that <see cref="Poly1305Mac.MacSize"/> returns 16.
    /// </summary>
    [Test]
    public void MacSizeIs16()
    {
        using var mac = Poly1305Mac.Create(new byte[32]);
        Assert.That(mac.MacSize, Is.EqualTo(16));
    }

    #endregion

    #region Parameter Validation

    /// <summary>
    /// Verifies that invalid key sizes throw <see cref="ArgumentException"/>.
    /// </summary>
    [TestCase(0)]
    [TestCase(16)]
    [TestCase(31)]
    [TestCase(33)]
    [TestCase(64)]
    public void InvalidKeySizeThrows(int keySize)
    {
        Assert.Throws<ArgumentException>(() => Poly1305Mac.Create(new byte[keySize]));
    }

    /// <summary>
    /// Verifies that <see cref="Poly1305Mac.Finalize"/> throws when the destination is too small.
    /// </summary>
    [Test]
    public void FinalizeTooSmallDestinationThrows()
    {
        using var mac = Poly1305Mac.Create(new byte[32]);
        mac.Update(Encoding.ASCII.GetBytes("test"));
        Assert.Throws<ArgumentException>(() => mac.Finalize(new byte[15]));
    }

    /// <summary>
    /// Verifies that <see cref="Poly1305Mac.Update"/> throws after finalization.
    /// </summary>
    [Test]
    public void UpdateAfterFinalizeThrows()
    {
        using var mac = Poly1305Mac.Create(new byte[32]);
        mac.Update(Encoding.ASCII.GetBytes("test"));
        mac.Finalize(new byte[16]);
        Assert.Throws<InvalidOperationException>(() => mac.Update(Encoding.ASCII.GetBytes("more")));
    }

    /// <summary>
    /// Verifies that <see cref="Poly1305Mac.Finalize"/> throws when called twice.
    /// </summary>
    [Test]
    public void DoubleFinalizeThrows()
    {
        using var mac = Poly1305Mac.Create(new byte[32]);
        mac.Update(Encoding.ASCII.GetBytes("test"));
        mac.Finalize(new byte[16]);
        Assert.Throws<InvalidOperationException>(() => mac.Finalize(new byte[16]));
    }

    #endregion

    #region Static Convenience

    /// <summary>
    /// Verifies that the static <see cref="Poly1305Mac.Hash"/> method produces the
    /// correct tag for the RFC 8439 Section 2.5.2 test vector.
    /// </summary>
    [Test]
    public void StaticHashMatchesRfc8439()
    {
        byte[] key = TestHelpers.FromHexString(
            "85d6be7857556d337f4452fe42d506a8" +
            "0103808afb0db2fd4abff6af4149f51b");
        byte[] message = Encoding.ASCII.GetBytes("Cryptographic Forum Research Group");
        byte[] expected = TestHelpers.FromHexString("a8061dc1305136c6c22b8baf0c0127a9");

        byte[] tag = Poly1305Mac.Hash(key, message);

        Assert.That(tag, Is.EqualTo(expected));
    }

    #endregion
}
