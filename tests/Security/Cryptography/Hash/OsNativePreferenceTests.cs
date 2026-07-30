// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System.Text;
using CH = CryptoHives.Foundation.Security.Cryptography.Hash;
using CHRoot = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Tests for the OS-native implementation preference mechanism (<see cref="CHRoot.SimdSupport.Os"/>,
/// <see cref="HashImplementationKind"/>).
/// </summary>
/// <remarks>
/// Digest parity across managed/OS-native/SIMD variants for every input-size boundary is already
/// covered by the NIST-vector <c>[TestCaseSource]</c> tests in each algorithm's own test fixture
/// (e.g. <c>SHA256Tests</c>), since <c>Sha256Implementations.All</c> etc. now include the registry's
/// <c>"CryptoHives-OS"</c> variant. These tests instead cover the OS-native bridge mechanics and the
/// public <see cref="HashImplementationKind"/> API surface that those vector tests don't exercise.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class OsNativePreferenceTests
{
    /// <summary>
    /// Forcing the Os bit and reusing the instance via Initialize() must produce the same digest twice,
    /// verifying the wrapped BCL instance is correctly reset rather than reused stale.
    /// </summary>
    [Test]
    public void ReuseAfterInitializeProducesConsistentDigest()
    {
        using var sha256 = CH.SHA256.Create(CHRoot.SimdSupport.All | CHRoot.SimdSupport.Os);

        byte[] first = sha256.ComputeHash(Encoding.ASCII.GetBytes("abc"));

        sha256.Initialize();
        byte[] second = sha256.ComputeHash(Encoding.ASCII.GetBytes("abc"));

        Assert.That(second, Is.EqualTo(first));
    }

    /// <summary>
    /// Forcing the Os bit must still yield a digest identical to the pure-managed implementation.
    /// </summary>
    [Test]
    public void ForcedOsNativeMatchesManagedDigest()
    {
        byte[] input = Encoding.ASCII.GetBytes("The quick brown fox jumps over the lazy dog");

        using var managed = CH.SHA256.Create(CHRoot.SimdSupport.None);
        using var osNative = CH.SHA256.Create(CHRoot.SimdSupport.All | CHRoot.SimdSupport.Os);

        byte[] managedHash = managed.ComputeHash(input);
        byte[] osHash = osNative.ComputeHash(input);

        Assert.That(osHash, Is.EqualTo(managedHash));
    }

    /// <summary>
    /// The default public constructor (used by <c>HashAlgorithmPool&lt;T&gt;</c>-backed
    /// <c>HashData</c>/<c>TryHashData</c>) must never request the Os bit, regardless of platform.
    /// </summary>
    [Test]
    public void DefaultConstructorNeverUsesOsNative()
    {
        byte[] input = Encoding.ASCII.GetBytes("abc");
        using var managed = CH.SHA256.Create(CHRoot.SimdSupport.None);
        byte[] expected = managed.ComputeHash(input);

        byte[] pooled = CH.SHA256.HashData(input);

        Assert.That(pooled, Is.EqualTo(expected));
    }

    /// <summary>
    /// <see cref="HashImplementationKind.Auto"/> must degrade to the managed implementation for every
    /// algorithm while <see cref="CHRoot.OsNativeDefaults"/> has no curated entries - i.e. never a
    /// silent default, matching release NuGet package behavior.
    /// </summary>
    [TestCase("SHA-256")]
    [TestCase("SHA-384")]
    [TestCase("SHA-512")]
    [TestCase("SHA3-256")]
    [TestCase("SHA3-384")]
    [TestCase("SHA3-512")]
    public void AutoDegradesToManagedWithoutCuration(string hashName)
    {
        using var auto = CH.HashAlgorithm.Create(hashName, HashImplementationKind.Auto);
        using var managed = CH.HashAlgorithm.Create(hashName, HashImplementationKind.Managed);

        Assert.That(auto.GetType(), Is.EqualTo(managed.GetType()));
    }

    /// <summary>
    /// <see cref="HashImplementationKind.OsNative"/> must still return the raw BCL type directly,
    /// matching the pre-existing <c>osVersion: true</c> behavior.
    /// </summary>
    [Test]
    public void OsNativeReturnsRawBclType()
    {
        using var osNative = CH.HashAlgorithm.Create("SHA-256", HashImplementationKind.OsNative);

        Assert.That(osNative, Is.InstanceOf<System.Security.Cryptography.SHA256>());
        Assert.That(osNative, Is.Not.InstanceOf<CH.SHA256>());
    }

    /// <summary>
    /// The legacy <c>bool osVersion</c> overload must forward to the same behavior as the new
    /// <see cref="HashImplementationKind"/> overload, for backward compatibility.
    /// </summary>
    [Test]
    public void LegacyBoolOverloadForwardsToOsNative()
    {
        using var legacy = CH.HashAlgorithm.Create("SHA-256", osVersion: true);

        Assert.That(legacy, Is.InstanceOf<System.Security.Cryptography.SHA256>());
        Assert.That(legacy, Is.Not.InstanceOf<CH.SHA256>());
    }
}
