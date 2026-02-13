// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Regional;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System.Text;

/// <summary>
/// Tests for <see cref="Lsh512"/> hash algorithm (KS X 3262).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Lsh512Tests
{
    // Test vectors from Wikipedia: LSH hash function article
    // Input: "abc" (3 bytes)
    private static readonly byte[] AbcMessage = Encoding.ASCII.GetBytes("abc");

    // LSH-512-224("abc") = D1683234513EC56983 94571EAD128A8CD5373E97661BA20DCF89E489
    private static readonly byte[] ExpectedAbc224 = TestHelpers.FromHexString(
        "D1683234513EC5698394571EAD128A8CD5373E97661BA20DCF89E489");

    // LSH-512-256("abc") = CD892310532602332B613F1EC11A6962FCA61EA09ECFFCD4BCF75858D802EDEC
    private static readonly byte[] ExpectedAbc256 = TestHelpers.FromHexString(
        "CD892310532602332B613F1EC11A6962FCA61EA09ECFFCD4BCF75858D802EDEC");

    // LSH-512-384("abc")
    private static readonly byte[] ExpectedAbc384 = TestHelpers.FromHexString(
        "5F344EFAA0E43CCD2E5E194D6039794B4FB431F10FB4B65FD45E9DA4ECDE0F27B66E8DBDFA47252E0D0B741BFD91F9FE");

    // LSH-512-512("abc")
    private static readonly byte[] ExpectedAbc512 = TestHelpers.FromHexString(
        "A3D93CFE60DC1AACDD3BD4BEF0A6985381A396C7D49D9FD177795697C3535208" +
        "B5C57224BEF21084D42083E95A4BD8EB33E869812B65031C428819A1E7CE596D");

    /// <summary>
    /// Validate LSH-512-224 produces 224-bit (28-byte) output.
    /// </summary>
    [Test]
    public void Lsh512224HashSizeIs224Bits()
    {
        using var lsh = Lsh512.Create(28);
        Assert.That(lsh.HashSize, Is.EqualTo(224));
    }

    /// <summary>
    /// Validate LSH-512-256 produces 256-bit (32-byte) output.
    /// </summary>
    [Test]
    public void Lsh512256HashSizeIs256Bits()
    {
        using var lsh = Lsh512.Create(32);
        Assert.That(lsh.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate LSH-512-384 produces 384-bit (48-byte) output.
    /// </summary>
    [Test]
    public void Lsh512384HashSizeIs384Bits()
    {
        using var lsh = Lsh512.Create(48);
        Assert.That(lsh.HashSize, Is.EqualTo(384));
    }

    /// <summary>
    /// Validate LSH-512-512 produces 512-bit (64-byte) output.
    /// </summary>
    [Test]
    public void Lsh512512HashSizeIs512Bits()
    {
        using var lsh = Lsh512.Create(64);
        Assert.That(lsh.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Validate LSH-512-224("abc") against Wikipedia test vector.
    /// </summary>
    [Test]
    public void Lsh512224AbcVector()
    {
        using var lsh = Lsh512.Create(28);
        byte[] hash = lsh.ComputeHash(AbcMessage);
        Assert.That(hash, Is.EqualTo(ExpectedAbc224));
    }

    /// <summary>
    /// Validate LSH-512-256("abc") against Wikipedia test vector.
    /// </summary>
    [Test]
    public void Lsh512256AbcVector()
    {
        using var lsh = Lsh512.Create(32);
        byte[] hash = lsh.ComputeHash(AbcMessage);
        Assert.That(hash, Is.EqualTo(ExpectedAbc256));
    }

    /// <summary>
    /// Validate LSH-512-384("abc") against Wikipedia test vector.
    /// </summary>
    [Test]
    public void Lsh512384AbcVector()
    {
        using var lsh = Lsh512.Create(48);
        byte[] hash = lsh.ComputeHash(AbcMessage);
        Assert.That(hash, Is.EqualTo(ExpectedAbc384));
    }

    /// <summary>
    /// Validate LSH-512-512("abc") against Wikipedia test vector.
    /// </summary>
    [Test]
    public void Lsh512512AbcVector()
    {
        using var lsh = Lsh512.Create(64);
        byte[] hash = lsh.ComputeHash(AbcMessage);
        Assert.That(hash, Is.EqualTo(ExpectedAbc512));
    }

    /// <summary>
    /// Validate LSH-512-512 empty input produces consistent output.
    /// </summary>
    [Test]
    public void Lsh512512EmptyInput()
    {
        using var lsh = Lsh512.Create(64);
        byte[] hash = lsh.ComputeHash([]);
        Assert.That(hash.Length, Is.EqualTo(64));
    }

    /// <summary>
    /// Validate incremental hashing produces same result as single-shot.
    /// </summary>
    [Test]
    public void Lsh512512IncrementalMatchesSingleShot()
    {
        using var single = Lsh512.Create(64);
        byte[] singleHash = single.ComputeHash(AbcMessage);

        using var incremental = Lsh512.Create(64);
        incremental.TransformBlock(AbcMessage, 0, 1, null, 0);
        incremental.TransformBlock(AbcMessage, 1, 1, null, 0);
        incremental.TransformFinalBlock(AbcMessage, 2, 1);
        byte[] incrementalHash = incremental.Hash!;

        Assert.That(incrementalHash, Is.EqualTo(singleHash));
    }

    /// <summary>
    /// Validate that Initialize resets state for reuse.
    /// </summary>
    [Test]
    public void Lsh512512InitializeResetsState()
    {
        using var lsh = Lsh512.Create(64);
        byte[] hash1 = lsh.ComputeHash(AbcMessage);
        byte[] hash2 = lsh.ComputeHash(AbcMessage);
        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Validate AlgorithmName returns correct value.
    /// </summary>
    [Test]
    public void Lsh512AlgorithmNameIsCorrect()
    {
        using var lsh = Lsh512.Create(32);
        Assert.That(lsh.AlgorithmName, Is.EqualTo("LSH-512-256"));
    }

    /// <summary>
    /// Validate BlockSize is 256 bytes.
    /// </summary>
    [Test]
    public void Lsh512BlockSizeIs256Bytes()
    {
        using var lsh = Lsh512.Create(64);
        Assert.That(lsh.BlockSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate invalid hash size throws ArgumentException.
    /// </summary>
    [Test]
    public void Lsh512InvalidHashSizeThrows()
    {
        Assert.Throws<System.ArgumentException>(() => new Lsh512(16));
    }
}
