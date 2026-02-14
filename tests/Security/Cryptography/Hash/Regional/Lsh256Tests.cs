// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash.Regional;

using Cryptography.Tests.Hash;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System.Text;

/// <summary>
/// Tests for <see cref="Lsh256"/> hash algorithm (KS X 3262).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class Lsh256Tests
{
    // Test vectors from Wikipedia: LSH hash function article
    // Input: "abc" (3 bytes)
    private static readonly byte[] AbcMessage = Encoding.ASCII.GetBytes("abc");

    // LSH-256-224("abc")
    private static readonly byte[] ExpectedAbc224 = TestHelpers.FromHexString(
        "F7C53BA4034E708E74FBA42E55997CA5126BB7623688F85342F73732");

    // LSH-256-256("abc") = 5FBF365DAEA5446A7053C52B57404D77A07A5F48A1F7C1963A0898BA1B714741
    private static readonly byte[] ExpectedAbc256 = TestHelpers.FromHexString(
        "5FBF365DAEA5446A7053C52B57404D77A07A5F48A1F7C1963A0898BA1B714741");

    /// <summary>
    /// Validate LSH-256-224 produces 224-bit (28-byte) output.
    /// </summary>
    [Test]
    public void Lsh256224HashSizeIs224Bits()
    {
        using var lsh = Lsh256.Create(28);
        Assert.That(lsh.HashSize, Is.EqualTo(224));
    }

    /// <summary>
    /// Validate LSH-256-256 produces 256-bit (32-byte) output.
    /// </summary>
    [Test]
    public void Lsh256256HashSizeIs256Bits()
    {
        using var lsh = Lsh256.Create(32);
        Assert.That(lsh.HashSize, Is.EqualTo(256));
    }

    /// <summary>
    /// Validate LSH-256-224("abc") against Wikipedia test vector.
    /// </summary>
    [Test]
    public void Lsh256224AbcVector()
    {
        using var lsh = Lsh256.Create(28);
        byte[] hash = lsh.ComputeHash(AbcMessage);
        Assert.That(hash, Is.EqualTo(ExpectedAbc224));
    }

    /// <summary>
    /// Validate LSH-256-256("abc") against Wikipedia test vector.
    /// </summary>
    [Test]
    public void Lsh256256AbcVector()
    {
        using var lsh = Lsh256.Create(32);
        byte[] hash = lsh.ComputeHash(AbcMessage);
        Assert.That(hash, Is.EqualTo(ExpectedAbc256));
    }

    /// <summary>
    /// Validate LSH-256-256 empty input produces consistent output.
    /// </summary>
    [Test]
    public void Lsh256256EmptyInput()
    {
        using var lsh = Lsh256.Create(32);
        byte[] hash = lsh.ComputeHash([]);
        Assert.That(hash.Length, Is.EqualTo(32));
    }

    /// <summary>
    /// Validate incremental hashing produces same result as single-shot.
    /// </summary>
    [Test]
    public void Lsh256256IncrementalMatchesSingleShot()
    {
        using var single = Lsh256.Create(32);
        byte[] singleHash = single.ComputeHash(AbcMessage);

        using var incremental = Lsh256.Create(32);
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
    public void Lsh256256InitializeResetsState()
    {
        using var lsh = Lsh256.Create(32);
        byte[] hash1 = lsh.ComputeHash(AbcMessage);
        byte[] hash2 = lsh.ComputeHash(AbcMessage);
        Assert.That(hash2, Is.EqualTo(hash1));
    }

    /// <summary>
    /// Validate AlgorithmName returns correct value.
    /// </summary>
    [Test]
    public void Lsh256AlgorithmNameIsCorrect()
    {
        using var lsh = Lsh256.Create(32);
        Assert.That(lsh.AlgorithmName, Is.EqualTo("LSH-256-256"));
    }

    /// <summary>
    /// Validate BlockSize is 128 bytes.
    /// </summary>
    [Test]
    public void Lsh256BlockSizeIs128Bytes()
    {
        using var lsh = Lsh256.Create(32);
        Assert.That(lsh.BlockSize, Is.EqualTo(128));
    }

    /// <summary>
    /// Validate invalid hash size throws ArgumentException.
    /// </summary>
    [Test]
    public void Lsh256InvalidHashSizeThrows()
    {
        Assert.Throws<System.ArgumentException>(() => new Lsh256(64));
    }
}
