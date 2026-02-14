// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using NUnit.Framework;
using System;
using System.Text;
using CryptoHivesHash = CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Tests that <c>TryComputeHash</c> returns <see langword="false"/> when the destination span
/// is too small, for all registered CryptoHives hash and MAC algorithms.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ComputeHashTests
{
    private static readonly byte[] TestData = Encoding.UTF8.GetBytes("Hello, World!");

    /// <summary>
    /// Verifies that <c>TryComputeHash</c> returns <see langword="false"/> and sets
    /// <c>bytesWritten</c> to zero when the destination is one byte too small.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void TryComputeHashReturnsFalseWhenDestinationTooSmall(HashAlgorithmFactory factory)
    {
        using var hash = (CryptoHivesHash.HashAlgorithm)factory.Create();
        int hashSizeBytes = hash.HashSize / 8;

        Span<byte> tooSmall = stackalloc byte[hashSizeBytes - 1];
        bool result = hash.TryComputeHash(TestData, tooSmall, out int bytesWritten);

        Assert.That(result, Is.False, $"{factory.Name}: TryComputeHash should return false for undersized destination");
        Assert.That(bytesWritten, Is.EqualTo(0), $"{factory.Name}: bytesWritten should be 0 for undersized destination");
    }

    /// <summary>
    /// Verifies that <c>TryComputeHash</c> returns <see langword="false"/> when the destination
    /// is empty.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void TryComputeHashReturnsFalseWhenDestinationEmpty(HashAlgorithmFactory factory)
    {
        using var hash = (CryptoHivesHash.HashAlgorithm)factory.Create();

        bool result = hash.TryComputeHash(TestData, Span<byte>.Empty, out int bytesWritten);

        Assert.That(result, Is.False, $"{factory.Name}: TryComputeHash should return false for empty destination");
        Assert.That(bytesWritten, Is.EqualTo(0), $"{factory.Name}: bytesWritten should be 0 for empty destination");
    }

    /// <summary>
    /// Verifies that <c>TryComputeHash</c> succeeds when the destination is exactly the right size.
    /// </summary>
    /// <param name="factory">The hash algorithm factory.</param>
    [Test]
    [TestCaseSource(typeof(CryptoHivesManagedImplementations), nameof(CryptoHivesManagedImplementations.All))]
    public void TryComputeHashSucceedsWhenDestinationExactSize(HashAlgorithmFactory factory)
    {
        using var hash = (CryptoHivesHash.HashAlgorithm)factory.Create();
        int hashSizeBytes = hash.HashSize / 8;

        Span<byte> destination = stackalloc byte[hashSizeBytes];
        bool result = hash.TryComputeHash(TestData, destination, out int bytesWritten);

        Assert.That(result, Is.True, $"{factory.Name}: TryComputeHash should succeed for exact-size destination");
        Assert.That(bytesWritten, Is.EqualTo(hashSizeBytes), $"{factory.Name}: bytesWritten should equal hash size");
    }
}
