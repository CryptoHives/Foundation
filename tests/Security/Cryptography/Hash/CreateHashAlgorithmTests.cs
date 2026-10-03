// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

#pragma warning disable CS0618 // Type or member is obsolete

namespace Cryptography.Tests.Hash;

using NUnit.Framework;
using System;
using CH = CryptoHives.Foundation.Security.Cryptography;
using OS = System.Security.Cryptography;

/// <summary>
/// Tests for <see cref="CH.Hash.HashAlgorithm"/> factory method.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CreateHashAlgorithmTests
{
    /// <summary>
    /// Test that Create returns correct types for SHA-2 family.
    /// </summary>
    [TestCase("SHA256", typeof(CH.Hash.SHA256))]
    [TestCase("SHA-256", typeof(CH.Hash.SHA256))]
    [TestCase("SHA384", typeof(CH.Hash.SHA384))]
    [TestCase("SHA-384", typeof(CH.Hash.SHA384))]
    [TestCase("SHA512", typeof(CH.Hash.SHA512))]
    [TestCase("SHA-512", typeof(CH.Hash.SHA512))]
    public void CreateReturnsSHA2Types(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for SHA-3 family.
    /// </summary>
    [TestCase("SHA3-256", typeof(CH.Hash.SHA3_256))]
    [TestCase("SHA3256", typeof(CH.Hash.SHA3_256))]
    [TestCase("SHA3-512", typeof(CH.Hash.SHA3_512))]
    [TestCase("SHA3512", typeof(CH.Hash.SHA3_512))]
    public void CreateReturnsSHA3Types(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for SHAKE XOFs.
    /// </summary>
    [TestCase("SHAKE128", typeof(CH.Hash.Shake128))]
    [TestCase("SHAKE256", typeof(CH.Hash.Shake256))]
    public void CreateReturnsShakeTypes(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for cSHAKE XOFs.
    /// </summary>
    [TestCase("CSHAKE128", typeof(CH.Hash.CShake128))]
    [TestCase("CSHAKE256", typeof(CH.Hash.CShake256))]
    public void CreateReturnsCShakeTypes(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for Keccak.
    /// </summary>
    [TestCase("KECCAK-256", typeof(CH.Hash.Keccak256))]
    [TestCase("KECCAK256", typeof(CH.Hash.Keccak256))]
    public void CreateReturnsKeccakTypes(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for BLAKE family.
    /// </summary>
    [TestCase("BLAKE2B", typeof(CH.Hash.Blake2b))]
    [TestCase("BLAKE2B-512", typeof(CH.Hash.Blake2b))]
    [TestCase("BLAKE2S", typeof(CH.Hash.Blake2s))]
    [TestCase("BLAKE2S-256", typeof(CH.Hash.Blake2s))]
    [TestCase("BLAKE3", typeof(CH.Hash.Blake3))]
    public void CreateReturnsBlakeTypes(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for RIPEMD-160.
    /// </summary>
    [TestCase("RIPEMD-160", typeof(CH.Hash.Ripemd160))]
    [TestCase("RIPEMD160", typeof(CH.Hash.Ripemd160))]
    public void CreateReturnsRipemdTypes(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for SM3.
    /// </summary>
    [TestCase("SM3", typeof(CH.Hash.SM3))]
    public void CreateReturnsSM3Types(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for Whirlpool.
    /// </summary>
    [TestCase("WHIRLPOOL", typeof(CH.Hash.Whirlpool))]
    public void CreateReturnsWhirlpoolTypes(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
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
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf<CH.Hash.Streebog>());
        Assert.That(hash.HashSize, Is.EqualTo(expectedHashSizeBytes * 8));
    }

    /// <summary>
    /// Test that Create returns correct types for legacy algorithms.
    /// </summary>
    [TestCase("SHA1", typeof(CH.Hash.SHA1))]
    [TestCase("SHA-1", typeof(CH.Hash.SHA1))]
    [TestCase("MD5", typeof(CH.Hash.MD5))]
    public void CreateReturnsLegacyTypes(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correct types for Ascon.
    /// </summary>
    [TestCase("ASCON-HASH256", typeof(CH.Hash.AsconHash256))]
    [TestCase("ASCONHASH256", typeof(CH.Hash.AsconHash256))]
    [TestCase("ASCON-XOF128", typeof(CH.Hash.AsconXof128))]
    [TestCase("ASCONXOF128", typeof(CH.Hash.AsconXof128))]
    public void CreateReturnsAsconTypes(string name, Type expectedType)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
    }

    /// <summary>
    /// Test that Create returns correctly sized instances for LSH.
    /// </summary>
    [TestCase("LSH-256-224", typeof(CH.Hash.Lsh256), 28)]
    [TestCase("LSH-256-256", typeof(CH.Hash.Lsh256), 32)]
    [TestCase("LSH-256", typeof(CH.Hash.Lsh256), 32)]
    [TestCase("LSH-512-224", typeof(CH.Hash.Lsh512), 28)]
    [TestCase("LSH-512-256", typeof(CH.Hash.Lsh512), 32)]
    [TestCase("LSH-512-384", typeof(CH.Hash.Lsh512), 48)]
    [TestCase("LSH-512-512", typeof(CH.Hash.Lsh512), 64)]
    [TestCase("LSH-512", typeof(CH.Hash.Lsh512), 64)]
    public void CreateReturnsLshTypes(string name, Type expectedType, int expectedHashSizeBytes)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf(expectedType));
        Assert.That(hash.HashSize, Is.EqualTo(expectedHashSizeBytes * 8));
    }

    /// <summary>
    /// Test that Create throws for unknown algorithms.
    /// </summary>
    [TestCase("UNKNOWN")]
    [TestCase("")]
    public void CreateThrowsForUnknownAlgorithm(string name)
    {
        Assert.Throws<ArgumentException>(() => CH.Hash.HashAlgorithm.Create(name));
    }

    /// <summary>
    /// Test that Create handles null input.
    /// </summary>
    [Test]
    public void CreateThrowsForNullInput()
    {
        Assert.Throws<ArgumentException>(() => CH.Hash.HashAlgorithm.Create(null!));
    }

    /// <summary>
    /// Test case-insensitivity.
    /// </summary>
    [TestCase("sha256")]
    [TestCase("Sha256")]
    [TestCase("SHA256")]
    public void CreateIsCaseInsensitive(string name)
    {
        using OS.HashAlgorithm hash = CH.Hash.HashAlgorithm.Create(name);
        Assert.That(hash, Is.InstanceOf<CH.Hash.SHA256>());
    }
}


