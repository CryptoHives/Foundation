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

#pragma warning disable CS0618 // Type or member is obsolete
    /// <summary>
    /// Verifies that all hash algorithm factories work correctly.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void FactoryMethodWorks(HashAlgorithmFactory factory)
    {
        using var hash = factory.Create();

        Assert.That(hash, Is.Not.Null);
        Assert.That(hash.GetType().Namespace, Does.StartWith("CryptoHives.Foundation.Security.Cryptography"));

        byte[] result = hash.ComputeHash(TestData);
        int expectedLength = hash.HashSize / 8;
        Assert.That(result, Has.Length.EqualTo(expectedLength));
    }
#pragma warning restore CS0618

    /// <summary>
    /// Verifies that XOF algorithms support custom output length.
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
    /// Verifies that HashAlgorithm.Create string factory returns correct types.
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
}


