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
    [Test]
    public void Kupyna256EmptyInput()
    {
        using var kupyna = Kupyna.Create(32);
        byte[] hash = kupyna.ComputeHash([]);
        Assert.That(hash, Is.EqualTo(ExpectedEmpty256));
    }

    /// <summary>
    /// Validate Kupyna-512 correctly hashes empty input.
    /// </summary>
    [Test]
    public void Kupyna512EmptyInput()
    {
        using var kupyna = Kupyna.Create(64);
        byte[] hash = kupyna.ComputeHash([]);
        Assert.That(hash, Is.EqualTo(ExpectedEmpty512));
    }

    /// <summary>
    /// Validate Kupyna-256 correctly hashes "The quick brown fox..." message.
    /// </summary>
    [Test]
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
    [Test]
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
    [Test]
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
    [Test]
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

    // Official reference test vectors from DSTU 7564:2014 (main.c by Kiianchuk, Mordvinov, Oliynykov).
    // Input: sequential bytes 0x00..0xFF (256 bytes total, used at various bit lengths).
    private static byte[] SequentialTestInput()
    {
        byte[] data = new byte[256];
        for (int i = 0; i < 256; i++)
            data[i] = (byte)i;
        return data;
    }

    private static byte[] Take(byte[] source, int count)
    {
        byte[] result = new byte[count];
        Array.Copy(source, result, count);
        return result;
    }

    /// <summary>
    /// Official DSTU 7564 test: Kupyna-256 with 512 bits (64 bytes) of sequential input.
    /// </summary>
    [Test]
    public void Kupyna256OfficialVector512Bits()
    {
        byte[] input = SequentialTestInput();
        byte[] expected = TestHelpers.FromHexString(
            "08F4EE6F1BE6903B324C4E27990CB24EF69DD58DBE84813EE0A52F6631239875");

        using var kupyna = Kupyna.Create(32);
        byte[] hash = kupyna.ComputeHash(Take(input, 64));
        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Official DSTU 7564 test: Kupyna-256 with 1024 bits (128 bytes) of sequential input.
    /// </summary>
    [Test]
    public void Kupyna256OfficialVector1024Bits()
    {
        byte[] input = SequentialTestInput();
        byte[] expected = TestHelpers.FromHexString(
            "0A9474E645A7D25E255E9E89FFF42EC7EB31349007059284F0B182E452BDA882");

        using var kupyna = Kupyna.Create(32);
        byte[] hash = kupyna.ComputeHash(Take(input, 128));
        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Official DSTU 7564 test: Kupyna-256 with 2048 bits (256 bytes) of sequential input.
    /// </summary>
    [Test]
    public void Kupyna256OfficialVector2048Bits()
    {
        byte[] input = SequentialTestInput();
        byte[] expected = TestHelpers.FromHexString(
            "D305A32B963D149DC765F68594505D4077024F836C1BF03806E1624CE176C08F");

        using var kupyna = Kupyna.Create(32);
        byte[] hash = kupyna.ComputeHash(input);
        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Official DSTU 7564 test: Kupyna-512 with 512 bits (64 bytes) of sequential input.
    /// </summary>
    [Test]
    public void Kupyna512OfficialVector512Bits()
    {
        byte[] input = SequentialTestInput();
        byte[] expected = TestHelpers.FromHexString(
            "3813E2109118CDFB5A6D5E72F7208DCCC80A2DFB3AFDFB02F46992B5EDBE536B" +
            "3560DD1D7E29C6F53978AF58B444E37BA685C0DD910533BA5D78EFFFC13DE62A");

        using var kupyna = Kupyna.Create(64);
        byte[] hash = kupyna.ComputeHash(Take(input, 64));
        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Official DSTU 7564 test: Kupyna-512 with 1024 bits (128 bytes) of sequential input.
    /// </summary>
    [Test]
    public void Kupyna512OfficialVector1024Bits()
    {
        byte[] input = SequentialTestInput();
        byte[] expected = TestHelpers.FromHexString(
            "76ED1AC28B1D0143013FFA87213B4090B356441263C13E03FA060A8CADA32B97" +
            "9635657F256B15D5FCA4A174DE029F0B1B4387C878FCC1C00E8705D783FD7FFE");

        using var kupyna = Kupyna.Create(64);
        byte[] hash = kupyna.ComputeHash(Take(input, 128));
        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Official DSTU 7564 test: Kupyna-512 with 2048 bits (256 bytes) of sequential input.
    /// </summary>
    [Test]
    public void Kupyna512OfficialVector2048Bits()
    {
        byte[] input = SequentialTestInput();
        byte[] expected = TestHelpers.FromHexString(
            "0DD03D7350C409CB3C29C25893A0724F6B133FA8B9EB90A64D1A8FA93B565566" +
            "11EB187D715A956B107E3BFC76482298133A9CE8CBC0BD5E1436A5B197284F7E");

        using var kupyna = Kupyna.Create(64);
        byte[] hash = kupyna.ComputeHash(input);
        Assert.That(hash, Is.EqualTo(expected));
    }

    /// <summary>
    /// Official DSTU 7564 test: Kupyna-384 with 760 bits (95 bytes) of sequential input.
    /// </summary>
    [Test]
    public void Kupyna384OfficialVector760Bits()
    {
        byte[] input = SequentialTestInput();
        byte[] expected = TestHelpers.FromHexString(
            "D9021692D84E5175735654846BA751E6D0ED0FAC36DFBC0841287DCB0B5584C7" +
            "5016C3DECC2A6E47C50B2F3811E351B8");

        using var kupyna = Kupyna.Create(48);
        byte[] hash = kupyna.ComputeHash(Take(input, 95));
        Assert.That(hash, Is.EqualTo(expected));
    }
}


