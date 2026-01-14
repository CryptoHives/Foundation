// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using System;
using System.Security.Cryptography;
using NUnit.Framework;

using CryptoHivesHash = CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Tests for <see cref="CryptoHivesHash.HashAlgorithm"/> factory method.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CryptoHivesHashAlgorithmTests
{
    /// <summary>
    /// Test that Create returns correct types for SHA-2 family.
    /// </summary>
    [TestCase("SHA256", typeof(CryptoHivesHash.SHA256))]
    [TestCase("SHA-256", typeof(CryptoHivesHash.SHA256))]
    [TestCase("SHA384", typeof(CryptoHivesHash.SHA384))]
    [TestCase("SHA-384", typeof(CryptoHivesHash.SHA384))]
    [TestCase("SHA512", typeof(CryptoHivesHash.SHA512))]
    [TestCase("SHA-512", typeof(CryptoHivesHash.SHA512))]
    public void CreateReturnsSHA2Types(string name, Type expectedType)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for SHA-3 family.
    /// </summary>
    [TestCase("SHA3-256", typeof(CryptoHivesHash.SHA3_256))]
    [TestCase("SHA3256", typeof(CryptoHivesHash.SHA3_256))]
    [TestCase("SHA3-512", typeof(CryptoHivesHash.SHA3_512))]
    [TestCase("SHA3512", typeof(CryptoHivesHash.SHA3_512))]
    public void CreateReturnsSHA3Types(string name, Type expectedType)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for SHAKE XOFs.
    /// </summary>
    [TestCase("SHAKE128", typeof(CryptoHivesHash.Shake128))]
    [TestCase("SHAKE256", typeof(CryptoHivesHash.Shake256))]
    public void CreateReturnsShakeTypes(string name, Type expectedType)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for cSHAKE XOFs.
    /// </summary>
    [TestCase("CSHAKE128", typeof(CryptoHivesHash.CShake128))]
    [TestCase("CSHAKE256", typeof(CryptoHivesHash.CShake256))]
    public void CreateReturnsCShakeTypes(string name, Type expectedType)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for Keccak.
    /// </summary>
    [TestCase("KECCAK-256", typeof(CryptoHivesHash.Keccak256))]
    [TestCase("KECCAK256", typeof(CryptoHivesHash.Keccak256))]
    public void CreateReturnsKeccakTypes(string name, Type expectedType)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for BLAKE family.
    /// </summary>
    [TestCase("BLAKE2B", typeof(CryptoHivesHash.Blake2b))]
    [TestCase("BLAKE2B-512", typeof(CryptoHivesHash.Blake2b))]
    [TestCase("BLAKE2S", typeof(CryptoHivesHash.Blake2s))]
    [TestCase("BLAKE2S-256", typeof(CryptoHivesHash.Blake2s))]
    [TestCase("BLAKE3", typeof(CryptoHivesHash.Blake3))]
    public void CreateReturnsBlakeTypes(string name, Type expectedType)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for RIPEMD-160.
    /// </summary>
    [TestCase("RIPEMD-160", typeof(CryptoHivesHash.Ripemd160))]
    [TestCase("RIPEMD160", typeof(CryptoHivesHash.Ripemd160))]
    public void CreateReturnsRipemdTypes(string name, Type expectedType)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for SM3.
    /// </summary>
    [Test]
    public void CreateReturnsSM3Type()
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create("SM3");
        Assert.That(hash, Is.InstanceOf<CryptoHivesHash.SM3>());
    }

    /// <summary>
    /// Test that Create returns correct types for Whirlpool.
    /// </summary>
    [Test]
    public void CreateReturnsWhirlpoolType()
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create("WHIRLPOOL");
        Assert.That(hash, Is.InstanceOf<CryptoHivesHash.Whirlpool>());
    }

    /// <summary>
    /// Test that Create returns correct types for Streebog.
    /// </summary>
    [TestCase("STREEBOG-256", 32)]
    [TestCase("STREEBOG256", 32)]
    [TestCase("GOST3411-2012-256", 32)]
    [TestCase("STREEBOG-512", 64)]
    [TestCase("STREEBOG512", 64)]
    [TestCase("GOST3411-2012-512", 64)]
    [TestCase("STREEBOG", 64)]
    public void CreateReturnsStreebogTypes(string name, int expectedHashSizeBytes)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf<CryptoHivesHash.Streebog>());
        Assert.That(hash.HashSize, Is.EqualTo(expectedHashSizeBytes * 8));
    }

    /// <summary>
    /// Test that Create returns correct types for legacy algorithms.
    /// </summary>
    [TestCase("SHA1")]
    [TestCase("SHA-1")]
#pragma warning disable CS0618 // Type or member is obsolete
    public void CreateReturnsSHA1ForLegacy(string name)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf<CryptoHivesHash.SHA1>());
    }

    /// <summary>
    /// Test that Create returns MD5 for legacy support.
    /// </summary>
    [Test]
    public void CreateReturnsMD5ForLegacy()
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create("MD5");
        Assert.That(hash, Is.InstanceOf<CryptoHivesHash.MD5>());
    }
#pragma warning restore CS0618

    /// <summary>
    /// Test that Create throws for unknown algorithms.
    /// </summary>
    [TestCase("UNKNOWN")]
    [TestCase("")]
    public void CreateThrowsForUnknownAlgorithm(string name)
    {
        Assert.Throws<ArgumentException>(() => CryptoHivesHash.HashAlgorithm.Create(name));
    }

    /// <summary>
    /// Test that Create handles null input.
    /// </summary>
    [Test]
    public void CreateThrowsForNullInput()
    {
        Assert.Throws<ArgumentException>(() => CryptoHivesHash.HashAlgorithm.Create(null!));
    }

    /// <summary>
    /// Test case-insensitivity.
    /// </summary>
    [TestCase("sha256")]
    [TestCase("Sha256")]
    [TestCase("SHA256")]
    public void CreateIsCaseInsensitive(string name)
    {
        using HashAlgorithm hash = CryptoHivesHash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf<CryptoHivesHash.SHA256>());
    }
}


