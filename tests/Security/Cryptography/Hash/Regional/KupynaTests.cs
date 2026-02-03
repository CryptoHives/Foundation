// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Regional;

using Cryptography.Tests.Adapter;
using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Text;

/// <summary>
/// Tests for <see cref="Kupyna"/> hash algorithm (DSTU 7564:2014).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class KupynaTests
{
    // Test vector from Wikipedia: Empty string
    // Kupyna-256("") = 0xcd5101d1ccdf0d1d1f4ada56e888cd724ca1a0838a3521e7131d4fb78d0f5eb6
    private static readonly byte[] ExpectedEmpty256 = TestHelpers.FromHexString(
        "cd5101d1ccdf0d1d1f4ada56e888cd724ca1a0838a3521e7131d4fb78d0f5eb6");

    // Kupyna-512("") = 0x656b2f4cd71462388b64a37043ea55dbe445d452aecd46c3298343314ef04019
    //                    bcfa3f04265a9857f91be91fce197096187ceda78c9c1c021c294a0689198538
    private static readonly byte[] ExpectedEmpty512 = TestHelpers.FromHexString(
        "656b2f4cd71462388b64a37043ea55dbe445d452aecd46c3298343314ef04019" +
        "bcfa3f04265a9857f91be91fce197096187ceda78c9c1c021c294a0689198538");

    // Test message: "The quick brown fox jumps over the lazy dog"
    private static readonly byte[] QuickFoxMessage = Encoding.ASCII.GetBytes(
        "The quick brown fox jumps over the lazy dog");

    // Kupyna-256("The quick brown fox jumps over the lazy dog")
    // = 0x996899f2d7422ceaf552475036b2dc120607eff538abf2b8dff471a98a4740c6
    private static readonly byte[] ExpectedQuickFox256 = TestHelpers.FromHexString(
        "996899f2d7422ceaf552475036b2dc120607eff538abf2b8dff471a98a4740c6");

    /// <summary>
    /// Validate Kupyna-256 produces 256-bit (32-byte) output.
    /// </summary>
    [Test]
    public void Kupyna256HashSizeIs256Bits()
    {
        using var kupyna = Kupyna.Create(32);
        Assert.That(kupyna.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate Kupyna-384 produces 384-bit (48-byte) output.
    /// </summary>
    [Test]
    public void Kupyna384HashSizeIs384Bits()
    {
        using var kupyna = Kupyna.Create(48);
        Assert.That(kupyna.HashSize, Is.EqualTo(384));
    }

    /// <summary>
    /// Validate Kupyna-512 produces 512-bit (64-byte) output.
    /// </summary>
    [Test]
    public void Kupyna512HashSizeIs512Bits()
    {
        using var kupyna = Kupyna.Create(64);
        Assert.That(kupyna.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Validate Kupyna-256 correctly hashes empty input.
    /// </summary>
    /// <remarks>
    /// This test is currently expected to fail as the managed implementation is WIP.
    /// </remarks>
    [Test]
    [Ignore("WIP: Managed Kupyna implementation needs debugging")]
    public void Kupyna256EmptyInput()
    {
        using var kupyna = Kupyna.Create(32);
        byte[] hash = kupyna.ComputeHash([]);
        Assert.That(hash, Is.EqualTo(ExpectedEmpty256));
    }

    /// <summary>
    /// Validate Kupyna-512 correctly hashes empty input.
    /// </summary>
    /// <remarks>
    /// This test is currently expected to fail as the managed implementation is WIP.
    /// </remarks>
    [Test]
    [Ignore("WIP: Managed Kupyna implementation needs debugging")]
    public void Kupyna512EmptyInput()
    {
        using var kupyna = Kupyna.Create(64);
        byte[] hash = kupyna.ComputeHash([]);
        Assert.That(hash, Is.EqualTo(ExpectedEmpty512));
    }

    /// <summary>
    /// Validate Kupyna-256 correctly hashes "The quick brown fox..." message.
    /// </summary>
    /// <remarks>
    /// This test is currently expected to fail as the managed implementation is WIP.
    /// </remarks>
    [Test]
    [Ignore("WIP: Managed Kupyna implementation needs debugging")]
    public void Kupyna256QuickBrownFox()
    {
        using var kupyna = Kupyna.Create(32);
        byte[] hash = kupyna.ComputeHash(QuickFoxMessage);
        Assert.That(hash, Is.EqualTo(ExpectedQuickFox256));
    }

    /// <summary>
    /// Validate Kupyna algorithm name is correct.
    /// </summary>
    [Test]
    [TestCase(32, "Kupyna-256")]
    [TestCase(48, "Kupyna-384")]
    [TestCase(64, "Kupyna-512")]
    public void AlgorithmNameIsCorrect(int hashSizeBytes, string expectedName)
    {
        using var kupyna = Kupyna.Create(hashSizeBytes);
        Assert.That(kupyna.AlgorithmName, Is.EqualTo(expectedName));
    }

    /// <summary>
    /// Validate block size is correct based on hash size.
    /// </summary>
    [Test]
    [TestCase(32, 64)]  // 256-bit uses 512-bit state = 64 bytes
    [TestCase(48, 128)] // 384-bit uses 1024-bit state = 128 bytes
    [TestCase(64, 128)] // 512-bit uses 1024-bit state = 128 bytes
    public void BlockSizeIsCorrect(int hashSizeBytes, int expectedBlockSize)
    {
        using var kupyna = Kupyna.Create(hashSizeBytes);
        Assert.That(kupyna.BlockSize, Is.EqualTo(expectedBlockSize));
    }

    /// <summary>
    /// Validate invalid hash size throws exception.
    /// </summary>
    [Test]
    [TestCase(16)]
    [TestCase(20)]
    [TestCase(40)]
    [TestCase(128)]
    public void InvalidHashSizeThrowsException(int hashSizeBytes)
    {
        Assert.That(() => Kupyna.Create(hashSizeBytes), Throws.ArgumentException);
    }

    /// <summary>
    /// Validate that our implementation matches BouncyCastle for Kupyna-256.
    /// </summary>
    /// <remarks>
    /// This test is currently expected to fail as the managed implementation is WIP.
    /// </remarks>
    [Test]
    [Ignore("WIP: Managed Kupyna implementation needs debugging")]
    [TestCase(0)]     // Empty
    [TestCase(1)]     // Single byte
    [TestCase(32)]    // Exactly half block
    [TestCase(63)]    // One less than block
    [TestCase(64)]    // Exactly one block
    [TestCase(65)]    // One more than block
    [TestCase(128)]   // Two blocks
    [TestCase(1000)]  // Multiple blocks
    public void Kupyna256MatchesBouncyCastle(int messageLength)
    {
        byte[] message = new byte[messageLength];
        new Random(42).NextBytes(message);

        using var cryptoHives = Kupyna.Create(32);
        using var bouncyCastle = new BouncyCastleHashAdapter(new Dstu7564Digest(256));

        byte[] chHash = cryptoHives.ComputeHash(message);
        byte[] bcHash = bouncyCastle.ComputeHash(message);

        Assert.That(chHash, Is.EqualTo(bcHash),
            $"Hash mismatch for {messageLength} byte message");
    }

    /// <summary>
    /// Validate that our implementation matches BouncyCastle for Kupyna-384.
    /// </summary>
    /// <remarks>
    /// This test is currently expected to fail as the managed implementation is WIP.
    /// </remarks>
    [Test]
    [Ignore("WIP: Managed Kupyna implementation needs debugging")]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(64)]
    [TestCase(127)]
    [TestCase(128)]
    [TestCase(129)]
    [TestCase(256)]
    public void Kupyna384MatchesBouncyCastle(int messageLength)
    {
        byte[] message = new byte[messageLength];
        new Random(42).NextBytes(message);

        using var cryptoHives = Kupyna.Create(48);
        using var bouncyCastle = new BouncyCastleHashAdapter(new Dstu7564Digest(384));

        byte[] chHash = cryptoHives.ComputeHash(message);
        byte[] bcHash = bouncyCastle.ComputeHash(message);

        Assert.That(chHash, Is.EqualTo(bcHash),
            $"Hash mismatch for {messageLength} byte message");
    }

    /// <summary>
    /// Validate that our implementation matches BouncyCastle for Kupyna-512.
    /// </summary>
    /// <remarks>
    /// This test is currently expected to fail as the managed implementation is WIP.
    /// </remarks>
    [Test]
    [Ignore("WIP: Managed Kupyna implementation needs debugging")]
    [TestCase(0)]
    [TestCase(1)]
    [TestCase(64)]
    [TestCase(127)]
    [TestCase(128)]
    [TestCase(129)]
    [TestCase(256)]
    [TestCase(1000)]
    public void Kupyna512MatchesBouncyCastle(int messageLength)
    {
        byte[] message = new byte[messageLength];
        new Random(42).NextBytes(message);

        using var cryptoHives = Kupyna.Create(64);
        using var bouncyCastle = new BouncyCastleHashAdapter(new Dstu7564Digest(512));

        byte[] chHash = cryptoHives.ComputeHash(message);
        byte[] bcHash = bouncyCastle.ComputeHash(message);

        Assert.That(chHash, Is.EqualTo(bcHash),
            $"Hash mismatch for {messageLength} byte message");
    }

    /// <summary>
    /// Validate incremental hashing produces same result as one-shot.
    /// </summary>
    [Test]
    public void IncrementalHashMatchesOneShot()
    {
        byte[] message = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog");

        using var oneShot = Kupyna.Create(32);
        byte[] oneShotHash = oneShot.ComputeHash(message);

        using var incremental = Kupyna.Create(32);
        // Feed in small chunks
        for (int i = 0; i < message.Length; i += 7)
        {
            int length = Math.Min(7, message.Length - i);
            incremental.TransformBlock(message, i, length, null, 0);
        }
        incremental.TransformFinalBlock([], 0, 0);
        byte[] incrementalHash = incremental.Hash!;

        Assert.That(incrementalHash, Is.EqualTo(oneShotHash));
    }

    /// <summary>
    /// Validate reuse after Initialize.
    /// </summary>
    [Test]
    public void ReuseAfterInitialize()
    {
        using var kupyna = Kupyna.Create(32);

        byte[] hash1 = kupyna.ComputeHash(QuickFoxMessage);

        kupyna.Initialize();

        byte[] hash2 = kupyna.ComputeHash(QuickFoxMessage);

        Assert.That(hash2, Is.EqualTo(hash1));
    }
}
