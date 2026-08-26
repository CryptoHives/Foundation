// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem.MLKem;

using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;
using OS = System.Security.Cryptography;

/// <summary>
/// Known-answer tests for ML-KEM (FIPS 203) using the official NIST ACVP test vectors.
/// </summary>
/// <remarks>
/// <para>
/// Vectors come from the NIST ACVP-Server validation files
/// (gen-val/json-files/ML-KEM-keyGen-FIPS203 and ML-KEM-encapDecap-FIPS203,
/// https://github.com/usnistgov/ACVP-Server), loaded by <see cref="MLKemAcvpVectors"/> from an
/// embedded data file. The complete set is exercised -- 25 keyGen and 25 encapsulation cases
/// per parameter set, plus 10 each of decapsulation, encapsulation key check and decapsulation
/// key check -- and every test name carries the original tcId.
/// </para>
/// <para>
/// Each vector runs through both public surfaces where the API allows: the stateless
/// span-based <see cref="IKem"/>, and the key-holding <see cref="MLKem"/>. They share a core
/// but not a code path -- <see cref="MLKem"/> adds seed retention, import validation and
/// zeroization -- so a defect in one need not be visible in the other.
/// </para>
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MLKemAcvpTests
{
    /// <summary>
    /// Verifies key generation from an ACVP seed through the stateless API.
    /// </summary>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="dHex">The d half of the seed.</param>
    /// <param name="zHex">The z half of the seed.</param>
    /// <param name="ekHex">The expected encapsulation key.</param>
    /// <param name="dkHex">The expected decapsulation key.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.KeyGen))]
    public void KeyGen_MatchesAcvpVector(string parameterSet, int tcId, string dHex, string zHex, string ekHex, string dkHex)
    {
        using IKem kem = CreateKem(parameterSet);

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(Seed(dHex, zHex), ek, dk);

        Assert.Multiple(() => {
            Assert.That(ek, Is.EqualTo(FromHex(ekHex)), $"{parameterSet} tcId {tcId}: encapsulation key mismatch.");
            Assert.That(dk, Is.EqualTo(FromHex(dkHex)), $"{parameterSet} tcId {tcId}: decapsulation key mismatch.");
        });
    }

    /// <summary>
    /// Verifies key generation from an ACVP seed through the key-holding API.
    /// </summary>
    /// <remarks>
    /// <c>ImportPrivateSeed</c> is documented as deterministic, so expanding an ACVP (d ‖ z)
    /// seed must reproduce the vector's keys exactly, and the seed must survive the round trip
    /// back out through <c>ExportPrivateSeed</c>.
    /// </remarks>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="dHex">The d half of the seed.</param>
    /// <param name="zHex">The z half of the seed.</param>
    /// <param name="ekHex">The expected encapsulation key.</param>
    /// <param name="dkHex">The expected decapsulation key.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.KeyGen))]
    public void KeyGen_MatchesAcvpVector_MLKemApi(string parameterSet, int tcId, string dHex, string zHex, string ekHex, string dkHex)
    {
        byte[] seed = Seed(dHex, zHex);

        using MLKem kem = MLKem.ImportPrivateSeed(Algorithm(parameterSet), seed);

        Assert.Multiple(() => {
            Assert.That(kem.ExportEncapsulationKey(), Is.EqualTo(FromHex(ekHex)), $"{parameterSet} tcId {tcId}: encapsulation key mismatch.");
            Assert.That(kem.ExportDecapsulationKey(), Is.EqualTo(FromHex(dkHex)), $"{parameterSet} tcId {tcId}: decapsulation key mismatch.");
            Assert.That(kem.ExportPrivateSeed(), Is.EqualTo(seed), $"{parameterSet} tcId {tcId}: private seed did not round-trip.");
        });
    }

    /// <summary>
    /// Verifies deterministic encapsulation through the stateless API, then decapsulates the
    /// result back with the vector's decapsulation key.
    /// </summary>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="ekHex">The encapsulation key.</param>
    /// <param name="dkHex">The matching decapsulation key.</param>
    /// <param name="mHex">The encapsulation message.</param>
    /// <param name="cHex">The expected ciphertext.</param>
    /// <param name="kHex">The expected shared secret.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.Encaps))]
    public void Encaps_MatchesAcvpVector(string parameterSet, int tcId, string ekHex, string dkHex, string mHex, string cHex, string kHex)
    {
        using IKem kem = CreateKem(parameterSet);

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(FromHex(ekHex), FromHex(mHex), ct, ss);

        Assert.Multiple(() => {
            Assert.That(ct, Is.EqualTo(FromHex(cHex)), $"{parameterSet} tcId {tcId}: ciphertext mismatch.");
            Assert.That(ss, Is.EqualTo(FromHex(kHex)), $"{parameterSet} tcId {tcId}: shared secret mismatch.");
        });

        // The same vector must decapsulate back to the same shared secret.
        byte[] ss2 = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(FromHex(dkHex), ct, ss2);
        Assert.That(ss2, Is.EqualTo(FromHex(kHex)), $"{parameterSet} tcId {tcId}: decapsulated secret mismatch.");
    }

    /// <summary>
    /// Decapsulates each encapsulation vector's ciphertext through the key-holding API.
    /// </summary>
    /// <remarks>
    /// Encapsulation itself cannot be a known-answer test on this surface:
    /// <c>MLKem.Encapsulate</c> samples its message internally and exposes no
    /// deterministic-seed overload, matching the in-box
    /// <c>System.Security.Cryptography.MLKem</c>. Decapsulation is deterministic, so the
    /// vector's ciphertext and shared secret still pin it; the randomised direction is covered
    /// by <see cref="Encapsulate_RoundTripsThroughMLKemApi"/>.
    /// </remarks>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="ekHex">The encapsulation key. Unused on this path.</param>
    /// <param name="dkHex">The matching decapsulation key.</param>
    /// <param name="mHex">The encapsulation message. Unused on this path.</param>
    /// <param name="cHex">The vector ciphertext.</param>
    /// <param name="kHex">The expected shared secret.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.Encaps))]
    public void Encaps_DecapsulatesThroughMLKemApi(string parameterSet, int tcId, string ekHex, string dkHex, string mHex, string cHex, string kHex)
    {
        _ = ekHex;
        _ = mHex;

        using MLKem kem = MLKem.ImportDecapsulationKey(Algorithm(parameterSet), FromHex(dkHex));

        Assert.That(kem.Decapsulate(FromHex(cHex)), Is.EqualTo(FromHex(kHex)), $"{parameterSet} tcId {tcId}: shared secret mismatch.");
    }

    /// <summary>
    /// Verifies decapsulation, including implicit rejection, through the stateless API.
    /// </summary>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="reason">The ACVP reason string for this case.</param>
    /// <param name="dkHex">The decapsulation key.</param>
    /// <param name="cHex">The ciphertext.</param>
    /// <param name="kHex">The expected shared secret.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.Decaps))]
    public void Decaps_MatchesAcvpVector(string parameterSet, int tcId, string reason, string dkHex, string cHex, string kHex)
    {
        using IKem kem = CreateKem(parameterSet);

        byte[] ss = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(FromHex(dkHex), FromHex(cHex), ss);

        // For "modified ciphertext" vectors the expected k is the implicit-rejection
        // output J(z ‖ c), so this also validates the rejection path byte-exactly.
        Assert.That(ss, Is.EqualTo(FromHex(kHex)), $"{parameterSet} tcId {tcId} ({reason}): shared secret mismatch.");
    }

    /// <summary>
    /// Verifies decapsulation, including implicit rejection, through the key-holding API.
    /// </summary>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="reason">The ACVP reason string for this case.</param>
    /// <param name="dkHex">The decapsulation key.</param>
    /// <param name="cHex">The ciphertext.</param>
    /// <param name="kHex">The expected shared secret.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.Decaps))]
    public void Decaps_MatchesAcvpVector_MLKemApi(string parameterSet, int tcId, string reason, string dkHex, string cHex, string kHex)
    {
        using MLKem kem = MLKem.ImportDecapsulationKey(Algorithm(parameterSet), FromHex(dkHex));

        Assert.That(kem.Decapsulate(FromHex(cHex)), Is.EqualTo(FromHex(kHex)), $"{parameterSet} tcId {tcId} ({reason}): shared secret mismatch.");
    }

    /// <summary>
    /// Verifies the FIPS 203 §7.2 encapsulation key check through the stateless API.
    /// </summary>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="expectedValid">Whether the vector's key is expected to pass.</param>
    /// <param name="reason">The ACVP reason string for this case.</param>
    /// <param name="ekHex">The encapsulation key.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.EncapsulationKeyCheck))]
    public void EncapsulationKeyCheck_MatchesAcvpVector(string parameterSet, int tcId, bool expectedValid, string reason, string ekHex)
    {
        using IKem kem = CreateKem(parameterSet);

        byte[] seed = new byte[32];
        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];

        if (expectedValid)
        {
            Assert.That(() => kem.Encapsulate(FromHex(ekHex), seed, ct, ss), Throws.Nothing,
                $"{parameterSet} tcId {tcId} ({reason}): valid key must pass the §7.2 modulus check.");
        }
        else
        {
            Assert.That(() => kem.Encapsulate(FromHex(ekHex), seed, ct, ss), Throws.InstanceOf<ArgumentException>(),
                $"{parameterSet} tcId {tcId} ({reason}): invalid key must fail the §7.2 modulus check.");
        }
    }

    /// <summary>
    /// Verifies the §7.2 encapsulation key check as enforced at import time by the key-holding
    /// API.
    /// </summary>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="expectedValid">Whether the vector's key is expected to pass.</param>
    /// <param name="reason">The ACVP reason string for this case.</param>
    /// <param name="ekHex">The encapsulation key.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.EncapsulationKeyCheck))]
    public void EncapsulationKeyCheck_MatchesAcvpVector_MLKemApi(string parameterSet, int tcId, bool expectedValid, string reason, string ekHex)
    {
        MLKemAlgorithm algorithm = Algorithm(parameterSet);

        if (expectedValid)
        {
            Assert.That(() => MLKem.ImportEncapsulationKey(algorithm, FromHex(ekHex)).Dispose(), Throws.Nothing,
                $"{parameterSet} tcId {tcId} ({reason}): valid key must import.");
        }
        else
        {
            Assert.That(() => MLKem.ImportEncapsulationKey(algorithm, FromHex(ekHex)).Dispose(),
                Throws.InstanceOf<ArgumentException>().Or.InstanceOf<OS.CryptographicException>(),
                $"{parameterSet} tcId {tcId} ({reason}): invalid key must be rejected at import.");
        }
    }

    /// <summary>
    /// Verifies the FIPS 203 §7.3 decapsulation key check through the stateless API.
    /// </summary>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="expectedValid">Whether the vector's key is expected to pass.</param>
    /// <param name="reason">The ACVP reason string for this case.</param>
    /// <param name="dkHex">The decapsulation key.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.DecapsulationKeyCheck))]
    public void DecapsulationKeyCheck_MatchesAcvpVector(string parameterSet, int tcId, bool expectedValid, string reason, string dkHex)
    {
        using IKem kem = CreateKem(parameterSet);

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];

        if (expectedValid)
        {
            Assert.That(() => kem.Decapsulate(FromHex(dkHex), ct, ss), Throws.Nothing,
                $"{parameterSet} tcId {tcId} ({reason}): valid key must pass the §7.3 hash check.");
        }
        else
        {
            Assert.That(() => kem.Decapsulate(FromHex(dkHex), ct, ss), Throws.InstanceOf<ArgumentException>(),
                $"{parameterSet} tcId {tcId} ({reason}): invalid key must fail the §7.3 hash check.");
        }
    }

    /// <summary>
    /// Verifies the §7.3 decapsulation key check as enforced at import time by the key-holding
    /// API.
    /// </summary>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="expectedValid">Whether the vector's key is expected to pass.</param>
    /// <param name="reason">The ACVP reason string for this case.</param>
    /// <param name="dkHex">The decapsulation key.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.DecapsulationKeyCheck))]
    public void DecapsulationKeyCheck_MatchesAcvpVector_MLKemApi(string parameterSet, int tcId, bool expectedValid, string reason, string dkHex)
    {
        MLKemAlgorithm algorithm = Algorithm(parameterSet);

        if (expectedValid)
        {
            Assert.That(() => MLKem.ImportDecapsulationKey(algorithm, FromHex(dkHex)).Dispose(), Throws.Nothing,
                $"{parameterSet} tcId {tcId} ({reason}): valid key must import.");
        }
        else
        {
            Assert.That(() => MLKem.ImportDecapsulationKey(algorithm, FromHex(dkHex)).Dispose(),
                Throws.InstanceOf<ArgumentException>().Or.InstanceOf<OS.CryptographicException>(),
                $"{parameterSet} tcId {tcId} ({reason}): invalid key must be rejected at import.");
        }
    }

    /// <summary>
    /// Covers the one direction the ACVP vectors cannot pin on the key-holding API:
    /// encapsulation, whose message is sampled internally.
    /// </summary>
    /// <remarks>
    /// The ciphertext is produced by <see cref="MLKem"/> and decapsulated by the independent
    /// stateless path using the vector's own decapsulation key, so agreement means the
    /// randomised path produced a ciphertext that the specification's decapsulation accepts --
    /// not merely one it round-trips with itself.
    /// </remarks>
    /// <param name="parameterSet">The ACVP parameter set name.</param>
    /// <param name="tcId">The ACVP test case id.</param>
    /// <param name="ekHex">The encapsulation key.</param>
    /// <param name="dkHex">The matching decapsulation key.</param>
    /// <param name="mHex">The encapsulation message. Unused on this path.</param>
    /// <param name="cHex">The vector ciphertext. Unused on this path.</param>
    /// <param name="kHex">The vector shared secret. Unused on this path.</param>
    [Test]
    [TestCaseSource(typeof(MLKemAcvpVectors), nameof(MLKemAcvpVectors.Encaps))]
    public void Encapsulate_RoundTripsThroughMLKemApi(string parameterSet, int tcId, string ekHex, string dkHex, string mHex, string cHex, string kHex)
    {
        _ = mHex;
        _ = cHex;
        _ = kHex;

        using MLKem sender = MLKem.ImportEncapsulationKey(Algorithm(parameterSet), FromHex(ekHex));
        sender.Encapsulate(out byte[] ciphertext, out byte[] sharedSecret);

        using IKem receiver = CreateKem(parameterSet);
        byte[] recovered = new byte[receiver.SharedSecretSizeBytes];
        receiver.Decapsulate(FromHex(dkHex), ciphertext, recovered);

        Assert.That(recovered, Is.EqualTo(sharedSecret), $"{parameterSet} tcId {tcId}: round trip did not agree.");
    }

    /// <summary>
    /// Assembles the 64-byte (d ‖ z) seed from an ACVP vector's two halves.
    /// </summary>
    /// <param name="dHex">The d half.</param>
    /// <param name="zHex">The z half.</param>
    /// <returns>The assembled seed.</returns>
    private static byte[] Seed(string dHex, string zHex)
    {
        byte[] seed = new byte[64];
        FromHex(dHex).CopyTo(seed, 0);
        FromHex(zHex).CopyTo(seed, 32);
        return seed;
    }

    private static MLKemAlgorithm Algorithm(string parameterSet) => parameterSet switch {
        "ML-KEM-512" => MLKemAlgorithm.MLKem512,
        "ML-KEM-768" => MLKemAlgorithm.MLKem768,
        "ML-KEM-1024" => MLKemAlgorithm.MLKem1024,
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    private static IKem CreateKem(string parameterSet) => parameterSet switch {
        "ML-KEM-512" => MLKem512.Create(),
        "ML-KEM-768" => MLKem768.Create(),
        "ML-KEM-1024" => MLKem1024.Create(),
        _ => throw new ArgumentException($"Unknown parameter set: {parameterSet}", nameof(parameterSet)),
    };

    private static byte[] FromHex(string hex) => MLKemAcvpVectors.FromHex(hex);
}
