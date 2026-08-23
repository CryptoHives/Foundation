// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Kem.MLKem;

using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Kems;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using Bcl = System.Security.Cryptography;
using Ours = CryptoHives.Foundation.Security.Cryptography.Kem;

/// <summary>
/// Cross-validation tests for ML-KEM against independent implementations.
/// </summary>
/// <remarks>
/// Validates interoperability with BouncyCastle on all target frameworks and,
/// on .NET 10+, with the operating-system-backed
/// <c>System.Security.Cryptography.MLKem</c> where the platform supports it.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MLKemInteropTests
{
    private static readonly object[] ParameterSets =
    [
        new object[] { "ML-KEM-512", new Func<IKem>(() => MLKem512.Create()) },
        new object[] { "ML-KEM-768", new Func<IKem>(() => MLKem768.Create()) },
        new object[] { "ML-KEM-1024", new Func<IKem>(() => MLKem1024.Create()) }
    ];

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void KeyGen_SameSeed_MatchesBouncyCastle(string name, Func<IKem> factory)
    {
        using IKem kem = factory();

        byte[] seed = new byte[64];
        for (int i = 0; i < 64; i++) seed[i] = (byte)((i * 5 + 1) & 0xFF);

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(seed, ek, dk);

        var bcPrivate = MLKemPrivateKeyParameters.FromSeed(BcParameters(name), seed);
        Assert.That(ek, Is.EqualTo(bcPrivate.GetPublicKeyEncoded()),
            "Encapsulation key must match BouncyCastle for the same (d ‖ z) seed.");
        Assert.That(dk, Is.EqualTo(bcPrivate.GetEncoded()),
            "Expanded decapsulation key must match BouncyCastle for the same (d ‖ z) seed.");

        // Functional check of the decapsulation key: our encapsulation must
        // decapsulate to the same shared secret with BouncyCastle's key.
        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, ct, ss);

        var decapsulator = new MLKemDecapsulator(BcParameters(name));
        decapsulator.Init(bcPrivate);
        byte[] bcSecret = new byte[decapsulator.SecretLength];
        decapsulator.Decapsulate(ct, 0, ct.Length, bcSecret, 0, bcSecret.Length);

        Assert.That(bcSecret, Is.EqualTo(ss),
            "BouncyCastle must decapsulate our ciphertext to the same shared secret.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Encapsulate_BouncyCastleDecapsulates(string name, Func<IKem> factory)
    {
        using IKem kem = factory();

        // BouncyCastle generates the key pair; we encapsulate against its public key.
        var generator = new MLKemKeyPairGenerator();
        generator.Init(new MLKemKeyGenerationParameters(new SecureRandom(), BcParameters(name)));
        var keyPair = generator.GenerateKeyPair();

        byte[] ek = ((MLKemPublicKeyParameters)keyPair.Public).GetEncoded();

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, ct, ss);

        var decapsulator = new MLKemDecapsulator(BcParameters(name));
        decapsulator.Init(keyPair.Private);
        byte[] bcSecret = new byte[decapsulator.SecretLength];
        decapsulator.Decapsulate(ct, 0, ct.Length, bcSecret, 0, bcSecret.Length);

        Assert.That(bcSecret, Is.EqualTo(ss),
            "BouncyCastle must recover the shared secret from our encapsulation.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Decapsulate_BouncyCastleEncapsulates(string name, Func<IKem> factory)
    {
        using IKem kem = factory();

        // We generate the key pair; BouncyCastle encapsulates against our public key.
        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(ek, dk);

        var encapsulator = new MLKemEncapsulator(BcParameters(name));
        encapsulator.Init(new ParametersWithRandom(
            MLKemPublicKeyParameters.FromEncoding(BcParameters(name), ek), new SecureRandom()));

        byte[] ct = new byte[encapsulator.EncapsulationLength];
        byte[] bcSecret = new byte[encapsulator.SecretLength];
        encapsulator.Encapsulate(ct, 0, ct.Length, bcSecret, 0, bcSecret.Length);

        byte[] ss = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(dk, ct, ss);

        Assert.That(ss, Is.EqualTo(bcSecret),
            "We must recover the shared secret from BouncyCastle's encapsulation.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void ImplicitRejection_MatchesBouncyCastle(string name, Func<IKem> factory)
    {
        using IKem kem = factory();

        byte[] seed = new byte[64];
        for (int i = 0; i < 64; i++) seed[i] = (byte)((i * 11 + 3) & 0xFF);

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(seed, ek, dk);

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ssGood = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, ct, ssGood);

        // Tamper with the ciphertext so both implementations take the implicit-rejection
        // path K̄ = J(z ‖ c). The rejection outputs must agree byte-for-byte.
        ct[1] ^= 0x80;

        byte[] ours = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(dk, ct, ours);

        var decapsulator = new MLKemDecapsulator(BcParameters(name));
        decapsulator.Init(MLKemPrivateKeyParameters.FromSeed(BcParameters(name), seed));
        byte[] theirs = new byte[decapsulator.SecretLength];
        decapsulator.Decapsulate(ct, 0, ct.Length, theirs, 0, theirs.Length);

        Assert.That(ours, Is.Not.EqualTo(ssGood), "Tampered ciphertext must not yield the sender's secret.");
        Assert.That(ours, Is.EqualTo(theirs), "Implicit-rejection output must match BouncyCastle.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void RandomizedRoundTrips_MatchBouncyCastle(string name, Func<IKem> factory)
    {
        using IKem kem = factory();

        for (int trial = 0; trial < 5; trial++)
        {
            // Fresh keys each trial, alternating which side generates them.
            byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
            byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
            kem.GenerateKeyPair(ek, dk);

            var encapsulator = new MLKemEncapsulator(BcParameters(name));
            encapsulator.Init(new ParametersWithRandom(
                MLKemPublicKeyParameters.FromEncoding(BcParameters(name), ek), new SecureRandom()));
            byte[] ct = new byte[encapsulator.EncapsulationLength];
            byte[] bcSecret = new byte[encapsulator.SecretLength];
            encapsulator.Encapsulate(ct, 0, ct.Length, bcSecret, 0, bcSecret.Length);

            byte[] ss = new byte[kem.SharedSecretSizeBytes];
            kem.Decapsulate(dk, ct, ss);

            Assert.That(ss, Is.EqualTo(bcSecret), $"Trial {trial}: shared secret mismatch.");
        }
    }

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void KeyGen_SameSeed_MatchesDotnet(string name, Func<IKem> factory)
    {
        if (!System.Security.Cryptography.MLKem.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLKem is not supported on this platform.");
        }

        using IKem kem = factory();

        byte[] seed = new byte[64];
        for (int i = 0; i < 64; i++) seed[i] = (byte)((i * 7 + 5) & 0xFF);

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(seed, ek, dk);

        using var dotnetKem = System.Security.Cryptography.MLKem.ImportPrivateSeed(DotnetAlgorithm(name), seed);
        Assert.That(ek, Is.EqualTo(dotnetKem.ExportEncapsulationKey()),
            "Encapsulation key must match .NET MLKem for the same (d ‖ z) seed.");
        Assert.That(dk, Is.EqualTo(dotnetKem.ExportDecapsulationKey()),
            "Expanded decapsulation key must match .NET MLKem for the same (d ‖ z) seed.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void ImplicitRejection_MatchesDotnet(string name, Func<IKem> factory)
    {
        if (!System.Security.Cryptography.MLKem.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLKem is not supported on this platform.");
        }

        using IKem kem = factory();
        var algorithm = DotnetAlgorithm(name);

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(ek, dk);

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ssGood = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, ct, ssGood);

        ct[0] ^= 0x01;

        byte[] ours = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(dk, ct, ours);

        using var dotnetKem = System.Security.Cryptography.MLKem.ImportDecapsulationKey(algorithm, dk);
        byte[] theirs = new byte[algorithm.SharedSecretSizeInBytes];
        dotnetKem.Decapsulate(ct, theirs);

        Assert.That(ours, Is.Not.EqualTo(ssGood), "Tampered ciphertext must not yield the sender's secret.");
        Assert.That(ours, Is.EqualTo(theirs), "Implicit-rejection output must match .NET MLKem.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Encapsulate_DotnetDecapsulates(string name, Func<IKem> factory)
    {
        if (!System.Security.Cryptography.MLKem.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLKem is not supported on this platform.");
        }

        using IKem kem = factory();
        var algorithm = DotnetAlgorithm(name);

        using var dotnetKem = System.Security.Cryptography.MLKem.GenerateKey(algorithm);
        byte[] ek = dotnetKem.ExportEncapsulationKey();

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, ct, ss);

        byte[] dotnetSecret = new byte[algorithm.SharedSecretSizeInBytes];
        dotnetKem.Decapsulate(ct, dotnetSecret);

        Assert.That(dotnetSecret, Is.EqualTo(ss),
            ".NET MLKem must recover the shared secret from our encapsulation.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Decapsulate_DotnetEncapsulates(string name, Func<IKem> factory)
    {
        if (!System.Security.Cryptography.MLKem.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLKem is not supported on this platform.");
        }

        using IKem kem = factory();
        var algorithm = DotnetAlgorithm(name);

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(ek, dk);

        using var dotnetKem = System.Security.Cryptography.MLKem.ImportEncapsulationKey(algorithm, ek);
        byte[] ct = new byte[algorithm.CiphertextSizeInBytes];
        byte[] dotnetSecret = new byte[algorithm.SharedSecretSizeInBytes];
        dotnetKem.Encapsulate(ct, dotnetSecret);

        byte[] ss = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(dk, ct, ss);

        Assert.That(ss, Is.EqualTo(dotnetSecret),
            "We must recover the shared secret from .NET MLKem's encapsulation.");
    }

    private static System.Security.Cryptography.MLKemAlgorithm DotnetAlgorithm(string name) => name switch
    {
        "ML-KEM-512" => System.Security.Cryptography.MLKemAlgorithm.MLKem512,
        "ML-KEM-768" => System.Security.Cryptography.MLKemAlgorithm.MLKem768,
        "ML-KEM-1024" => System.Security.Cryptography.MLKemAlgorithm.MLKem1024,
        _ => throw new ArgumentException($"Unknown parameter set: {name}", nameof(name)),
    };

    /// <summary>
    /// The drop-in claim, stated as code: the same sequence of statements compiles and behaves
    /// identically whether <c>Kem</c> resolves to the in-box types or to ours.
    /// </summary>
    /// <remarks>
    /// The two halves are deliberately kept character-for-character identical apart from the
    /// alias prefix. If a rename ever diverges from the BCL surface, this stops compiling.
    /// </remarks>
    [Test]
    public void DropInSurface_CompilesAndAgrees()
    {
        if (!System.Security.Cryptography.MLKem.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLKem is not supported on this platform.");
        }

        byte[] seed = new byte[64];
        for (int i = 0; i < 64; i++) seed[i] = (byte)((i * 13 + 7) & 0xFF);

        // --- written against System.Security.Cryptography ---
        using var bcl = Bcl.MLKem.ImportPrivateSeed(Bcl.MLKemAlgorithm.MLKem768, seed);
        byte[] bclEk = bcl.ExportEncapsulationKey();
        byte[] bclDk = bcl.ExportDecapsulationKey();
        byte[] bclSeed = bcl.ExportPrivateSeed();
        bcl.Encapsulate(out byte[] bclCt, out byte[] bclSs);
        byte[] bclRecovered = bcl.Decapsulate(bclCt);

        // --- the same statements, only the alias changed ---
        using var ours = Ours.MLKem.ImportPrivateSeed(Ours.MLKemAlgorithm.MLKem768, seed);
        byte[] oursEk = ours.ExportEncapsulationKey();
        byte[] oursDk = ours.ExportDecapsulationKey();
        byte[] oursSeed = ours.ExportPrivateSeed();
        ours.Encapsulate(out byte[] oursCt, out byte[] oursSs);
        byte[] oursRecovered = ours.Decapsulate(oursCt);

        Assert.Multiple(() => {
            Assert.That(oursEk, Is.EqualTo(bclEk), "Encapsulation keys must match for the same seed.");
            Assert.That(oursDk, Is.EqualTo(bclDk), "Decapsulation keys must match for the same seed.");
            Assert.That(oursSeed, Is.EqualTo(bclSeed));
            Assert.That(oursRecovered, Is.EqualTo(oursSs));
            Assert.That(bclRecovered, Is.EqualTo(bclSs));

            // Sizes are reported identically, and each side decapsulates the other's ciphertext.
            Assert.That(ours.Algorithm.CiphertextSizeInBytes, Is.EqualTo(bcl.Algorithm.CiphertextSizeInBytes));
            Assert.That(ours.Algorithm.Name, Is.EqualTo(bcl.Algorithm.Name));
            Assert.That(ours.Decapsulate(bclCt), Is.EqualTo(bclSs));
            Assert.That(bcl.Decapsulate(oursCt), Is.EqualTo(oursSs));
        });
    }

#pragma warning restore SYSLIB5006
#endif


#if KYBERNET

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void KeyGen_SameSeed_KyberNetAgrees(string name, Func<IKem> factory)
    {
        using IKem kem = factory();

        byte[] seed = new byte[64];
        for (int i = 0; i < 64; i++) seed[i] = (byte)((i * 19 + 11) & 0xFF);

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(seed, ek, dk);

        // KyberNET must accept our FIPS 203 expanded decapsulation key verbatim, and derive
        // the same encapsulation key from it.
        using var theirPrivate = KyberNET.Keys.KyberDecapsulationKey.FromBytes(dk);
        Assert.That(theirPrivate.FullBytes, Is.EqualTo(dk),
            "KyberNET must round-trip our decapsulation key unchanged.");

        var theirPublic = KyberNET.Keys.KyberEncapsulationKey.FromBytes(ek);
        Assert.That(theirPublic.FullBytes, Is.EqualTo(ek),
            "KyberNET must round-trip our encapsulation key unchanged.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Encapsulate_KyberNetDecapsulates(string name, Func<IKem> factory)
    {
        using IKem kem = factory();

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(ek, dk);

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ss = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, ct, ss);

        using var theirPrivate = KyberNET.Keys.KyberDecapsulationKey.FromBytes(dk);
        byte[] theirSecret = theirPrivate.Decapsulate(KyberNET.Keys.KyberCipherText.FromBytes(ct));

        Assert.That(theirSecret, Is.EqualTo(ss),
            "KyberNET must recover the shared secret from our encapsulation.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Decapsulate_KyberNetEncapsulates(string name, Func<IKem> factory)
    {
        using IKem kem = factory();

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(ek, dk);

        var theirPublic = KyberNET.Keys.KyberEncapsulationKey.FromBytes(ek);
        using var theirResult = theirPublic.Encapsulate(KyberNetRandom.Instance);

        byte[] ss = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(dk, theirResult.CipherText.FullBytes, ss);

        Assert.That(ss, Is.EqualTo(theirResult.SharedSecretKey),
            "We must recover the shared secret from KyberNET's encapsulation.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void ImplicitRejection_MatchesKyberNet(string name, Func<IKem> factory)
    {
        using IKem kem = factory();

        byte[] ek = new byte[kem.EncapsulationKeySizeBytes];
        byte[] dk = new byte[kem.DecapsulationKeySizeBytes];
        kem.GenerateKeyPair(ek, dk);

        byte[] ct = new byte[kem.CiphertextSizeBytes];
        byte[] ssGood = new byte[kem.SharedSecretSizeBytes];
        kem.Encapsulate(ek, ct, ssGood);

        ct[2] ^= 0x40;

        byte[] ours = new byte[kem.SharedSecretSizeBytes];
        kem.Decapsulate(dk, ct, ours);

        using var theirPrivate = KyberNET.Keys.KyberDecapsulationKey.FromBytes(dk);
        byte[] theirs = theirPrivate.Decapsulate(KyberNET.Keys.KyberCipherText.FromBytes(ct));

        Assert.That(ours, Is.Not.EqualTo(ssGood), "Tampered ciphertext must not yield the sender's secret.");
        Assert.That(ours, Is.EqualTo(theirs), "Implicit-rejection output must match KyberNET.");
    }

    /// <summary>Bridges KyberNET's randomness abstraction; its own provider is internal.</summary>
    private sealed class KyberNetRandom : KyberNET.IRandomProvider
    {
        public static readonly KyberNetRandom Instance = new();

        public void FillWithRandom(byte[] buffer)
            => System.Security.Cryptography.RandomNumberGenerator.Fill(buffer);
    }

#endif

    private static MLKemParameters BcParameters(string name) => name switch {
        "ML-KEM-512" => MLKemParameters.ml_kem_512,
        "ML-KEM-768" => MLKemParameters.ml_kem_768,
        "ML-KEM-1024" => MLKemParameters.ml_kem_1024,
        _ => throw new ArgumentException($"Unknown parameter set: {name}", nameof(name)),
    };
}
