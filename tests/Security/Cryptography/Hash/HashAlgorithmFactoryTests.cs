// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using NUnit.Framework;
using System.Security.Cryptography;
using System.Text;
using CryptoHivesHash = CryptoHives.Foundation.Security.Cryptography.Hash;
using CryptoHivesMac = CryptoHives.Foundation.Security.Cryptography.Mac;

/// <summary>
/// Tests for hash algorithm factory and instantiation.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class HashAlgorithmFactoryTests
{
    private static readonly byte[] TestData = Encoding.UTF8.GetBytes("Hello, World!");

    /// <summary>
    /// Verifies that SHA256.Create() returns the correct type.
    /// </summary>
    [Test]
    public void SHA256CreateReturnsCorrectType()
    {
        using var hash = CryptoHivesHash.SHA256.Create();
        Assert.That(hash, Is.InstanceOf<CryptoHivesHash.SHA256>());
        Assert.That(hash.GetType().Namespace, Is.EqualTo("CryptoHives.Foundation.Security.Cryptography.Hash"));
    }

    /// <summary>
    /// Verifies that Blake2b properly forwards constructor parameters.
    /// </summary>
    [Test]
    public void Blake2bForwardsConstructorParameters()
    {
        using var hash32 = new CryptoHivesHash.Blake2b(32);
        using var hash64 = new CryptoHivesHash.Blake2b(64);

        Assert.That(hash32.HashSize, Is.EqualTo(256)); // 32 bytes = 256 bits
        Assert.That(hash64.HashSize, Is.EqualTo(512)); // 64 bytes = 512 bits
    }

    /// <summary>
    /// Verifies that Shake128 supports variable output length.
    /// </summary>
    [Test]
    public void Shake128SupportsVariableOutput()
    {
        using var shake32 = CryptoHivesHash.Shake128.Create(32);
        using var shake64 = CryptoHivesHash.Shake128.Create(64);

        byte[] result32 = shake32.ComputeHash(TestData);
        byte[] result64 = shake64.ComputeHash(TestData);

        Assert.That(result32, Has.Length.EqualTo(32));
        Assert.That(result64, Has.Length.EqualTo(64));
    }

    /// <summary>
    /// Verifies that HashAlgorithm.Create returns correct types.
    /// </summary>
    [TestCase("SHA256")]
    [TestCase("SHA3-256")]
    [TestCase("BLAKE2B")]
    [TestCase("SHAKE128")]
    public void FactoryCreateReturnsCorrectTypes(string algorithmName)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(algorithmName);
        Assert.That(hash.GetType().Namespace, Is.EqualTo("CryptoHives.Foundation.Security.Cryptography.Hash"));
    }

    /// <summary>
    /// Verifies that KMAC properly forwards constructor parameters.
    /// </summary>
    [Test]
    public void Kmac128ForwardsConstructorParameters()
    {
        byte[] key = Encoding.UTF8.GetBytes("test-key-12345678");
        using var kmac = CryptoHivesMac.Kmac128.Create(key, 64, "custom");

        Assert.That(kmac.HashSize, Is.EqualTo(512)); // 64 bytes = 512 bits
    }

    /// <summary>
    /// Verifies that Streebog supports both output sizes.
    /// </summary>
    [Test]
    public void StreebogSupportsVariableOutput()
    {
        using var streebog256 = CryptoHivesHash.Streebog.Create(32);
        using var streebog512 = CryptoHivesHash.Streebog.Create(64);

        Assert.That(streebog256.HashSize, Is.EqualTo(256));
        Assert.That(streebog512.HashSize, Is.EqualTo(512));
    }

    /// <summary>
    /// Verifies SHA-224 works correctly.
    /// </summary>
    [Test]
    public void SHA224ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA224.Create();
        Assert.That(hash.HashSize, Is.EqualTo(224));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(28));
    }

    /// <summary>
    /// Verifies SHA-256 works correctly.
    /// </summary>
    [Test]
    public void SHA256ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA256.Create();
        Assert.That(hash.HashSize, Is.EqualTo(256));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(32));
    }

    /// <summary>
    /// Verifies SHA-384 works correctly.
    /// </summary>
    [Test]
    public void SHA384ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA384.Create();
        Assert.That(hash.HashSize, Is.EqualTo(384));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(48));
    }

    /// <summary>
    /// Verifies SHA-512 works correctly.
    /// </summary>
    [Test]
    public void SHA512ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA512.Create();
        Assert.That(hash.HashSize, Is.EqualTo(512));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(64));
    }

    /// <summary>
    /// Verifies SHA-512/224 works correctly.
    /// </summary>
    [Test]
    public void SHA512_224ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA512_224.Create();
        Assert.That(hash.HashSize, Is.EqualTo(224));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(28));
    }

    /// <summary>
    /// Verifies SHA-512/256 works correctly.
    /// </summary>
    [Test]
    public void SHA512_256ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA512_256.Create();
        Assert.That(hash.HashSize, Is.EqualTo(256));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(32));
    }

    /// <summary>
    /// Verifies SHA3-224 works correctly.
    /// </summary>
    [Test]
    public void SHA3_224ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA3_224.Create();
        Assert.That(hash.HashSize, Is.EqualTo(224));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(28));
    }

    /// <summary>
    /// Verifies SHA3-256 works correctly.
    /// </summary>
    [Test]
    public void SHA3_256ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA3_256.Create();
        Assert.That(hash.HashSize, Is.EqualTo(256));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(32));
    }

    /// <summary>
    /// Verifies SHA3-384 works correctly.
    /// </summary>
    [Test]
    public void SHA3_384ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA3_384.Create();
        Assert.That(hash.HashSize, Is.EqualTo(384));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(48));
    }

    /// <summary>
    /// Verifies SHA3-512 works correctly.
    /// </summary>
    [Test]
    public void SHA3_512ProducesCorrectHashSize()
    {
        using var hash = CryptoHivesHash.SHA3_512.Create();
        Assert.That(hash.HashSize, Is.EqualTo(512));
        Assert.That(hash.ComputeHash(TestData), Has.Length.EqualTo(64));
    }

#pragma warning disable CS0618 // Type or member is obsolete
    /// <summary>
    /// Verifies that legacy algorithms work correctly.
    /// </summary>
    [Test]
    public void LegacyAlgorithmsWork()
    {
        using var md5 = CryptoHivesHash.MD5.Create();
        using var sha1 = CryptoHivesHash.SHA1.Create();

        Assert.That(md5.HashSize, Is.EqualTo(128));
        Assert.That(sha1.HashSize, Is.EqualTo(160));
    }
#pragma warning restore CS0618
}


