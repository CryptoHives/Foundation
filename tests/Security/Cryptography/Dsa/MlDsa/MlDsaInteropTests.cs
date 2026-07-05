// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.MlDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using System;
using IDsa = CryptoHives.Foundation.Security.Cryptography.Dsa.IDsa;

/// <summary>
/// Cross-validation tests for ML-DSA against independent implementations.
/// </summary>
/// <remarks>
/// Validates interoperability with BouncyCastle on all target frameworks and,
/// on .NET 10+, with the operating-system-backed
/// <c>System.Security.Cryptography.MLDsa</c> where the platform supports it.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class MlDsaInteropTests
{
    private static readonly object[] ParameterSets =
    [
        new object[] { "ML-DSA-44", new Func<IDsa>(() => MlDsa44.Create()) },
        new object[] { "ML-DSA-65", new Func<IDsa>(() => MlDsa65.Create()) },
        new object[] { "ML-DSA-87", new Func<IDsa>(() => MlDsa87.Create()) }
    ];

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void KeyGen_SameSeed_MatchesBouncyCastle(string name, Func<IDsa> factory)
    {
        using IDsa dsa = factory();

        byte[] seed = new byte[32];
        for (int i = 0; i < 32; i++) seed[i] = (byte)((i * 13 + 7) & 0xFF);

        byte[] pk = new byte[dsa.PublicKeySizeBytes];
        byte[] sk = new byte[dsa.SecretKeySizeBytes];
        dsa.GenerateKeyPair(seed, pk, sk);

        var bcPrivate = MLDsaPrivateKeyParameters.FromSeed(BcParameters(name), seed);
        Assert.That(pk, Is.EqualTo(bcPrivate.GetPublicKeyEncoded()),
            "Public key must match BouncyCastle for the same seed ξ.");
        Assert.That(sk, Is.EqualTo(bcPrivate.GetEncoded()),
            "Expanded secret key must match BouncyCastle for the same seed ξ.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void DeterministicSign_MatchesBouncyCastle(string name, Func<IDsa> factory)
    {
        using IDsa dsa = factory();

        byte[] seed = new byte[32];
        for (int i = 0; i < 32; i++) seed[i] = (byte)((i * 3 + 11) & 0xFF);

        byte[] pk = new byte[dsa.PublicKeySizeBytes];
        byte[] sk = new byte[dsa.SecretKeySizeBytes];
        dsa.GenerateKeyPair(seed, pk, sk);

        byte[] message = new byte[59];
        for (int i = 0; i < message.Length; i++) message[i] = (byte)(0x30 + i);

        byte[] ours = new byte[dsa.SignatureSizeBytes];
        dsa.SignDeterministic(sk, message, context: default, ours);

        var signer = new MLDsaSigner(BcParameters(name), deterministic: true);
        signer.Init(forSigning: true, MLDsaPrivateKeyParameters.FromSeed(BcParameters(name), seed));
        signer.BlockUpdate(message, 0, message.Length);
        byte[] theirs = signer.GenerateSignature();

        Assert.That(ours, Is.EqualTo(theirs),
            "Deterministic signatures must match BouncyCastle byte-for-byte.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Sign_BouncyCastleVerifies(string name, Func<IDsa> factory)
    {
        using IDsa dsa = factory();

        byte[] pk = new byte[dsa.PublicKeySizeBytes];
        byte[] sk = new byte[dsa.SecretKeySizeBytes];
        dsa.GenerateKeyPair(pk, sk);

        byte[] message = new byte[200];
        for (int i = 0; i < message.Length; i++) message[i] = (byte)(i & 0xFF);

        byte[] signature = new byte[dsa.SignatureSizeBytes];
        dsa.Sign(sk, message, context: default, signature);

        var verifier = new MLDsaSigner(BcParameters(name), deterministic: false);
        verifier.Init(forSigning: false, MLDsaPublicKeyParameters.FromEncoding(BcParameters(name), pk));
        verifier.BlockUpdate(message, 0, message.Length);

        Assert.That(verifier.VerifySignature(signature), Is.True,
            "BouncyCastle must verify our hedged signature.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Verify_BouncyCastleSigns(string name, Func<IDsa> factory)
    {
        using IDsa dsa = factory();

        var generator = new MLDsaKeyPairGenerator();
        generator.Init(new MLDsaKeyGenerationParameters(new SecureRandom(), BcParameters(name)));
        var keyPair = generator.GenerateKeyPair();

        byte[] message = new byte[73];
        for (int i = 0; i < message.Length; i++) message[i] = (byte)(0x80 ^ i);

        var signer = new MLDsaSigner(BcParameters(name), deterministic: false);
        signer.Init(forSigning: true, new ParametersWithRandom(keyPair.Private, new SecureRandom()));
        signer.BlockUpdate(message, 0, message.Length);
        byte[] signature = signer.GenerateSignature();

        byte[] pk = ((MLDsaPublicKeyParameters)keyPair.Public).GetEncoded();

        Assert.That(dsa.Verify(pk, message, context: default, signature), Is.True,
            "We must verify BouncyCastle's signature.");

        message[0] ^= 0x01;
        Assert.That(dsa.Verify(pk, message, context: default, signature), Is.False,
            "A tampered message must not verify.");
    }

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void KeyGen_SameSeed_MatchesDotnet(string name, Func<IDsa> factory)
    {
        if (!System.Security.Cryptography.MLDsa.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLDsa is not supported on this platform.");
        }

        using IDsa dsa = factory();

        byte[] seed = new byte[32];
        for (int i = 0; i < 32; i++) seed[i] = (byte)((i * 9 + 2) & 0xFF);

        byte[] pk = new byte[dsa.PublicKeySizeBytes];
        byte[] sk = new byte[dsa.SecretKeySizeBytes];
        dsa.GenerateKeyPair(seed, pk, sk);

        using var dotnetDsa = System.Security.Cryptography.MLDsa.ImportMLDsaPrivateSeed(DotnetAlgorithm(name), seed);
        Assert.That(pk, Is.EqualTo(dotnetDsa.ExportMLDsaPublicKey()),
            "Public key must match .NET MLDsa for the same seed ξ.");
        Assert.That(sk, Is.EqualTo(dotnetDsa.ExportMLDsaPrivateKey()),
            "Expanded secret key must match .NET MLDsa for the same seed ξ.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Sign_DotnetVerifies(string name, Func<IDsa> factory)
    {
        if (!System.Security.Cryptography.MLDsa.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLDsa is not supported on this platform.");
        }

        using IDsa dsa = factory();

        byte[] pk = new byte[dsa.PublicKeySizeBytes];
        byte[] sk = new byte[dsa.SecretKeySizeBytes];
        dsa.GenerateKeyPair(pk, sk);

        byte[] message = new byte[111];
        byte[] context = new byte[9];
        for (int i = 0; i < context.Length; i++) context[i] = (byte)(0xA0 + i);

        byte[] signature = new byte[dsa.SignatureSizeBytes];
        dsa.Sign(sk, message, context, signature);

        using var dotnetDsa = System.Security.Cryptography.MLDsa.ImportMLDsaPublicKey(DotnetAlgorithm(name), pk);
        Assert.That(dotnetDsa.VerifyData(message, signature, context), Is.True,
            ".NET MLDsa must verify our signature, including the context binding.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Verify_DotnetSigns(string name, Func<IDsa> factory)
    {
        if (!System.Security.Cryptography.MLDsa.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLDsa is not supported on this platform.");
        }

        using IDsa dsa = factory();

        using var dotnetDsa = System.Security.Cryptography.MLDsa.GenerateKey(DotnetAlgorithm(name));
        byte[] pk = dotnetDsa.ExportMLDsaPublicKey();

        byte[] message = new byte[85];
        byte[] signature = dotnetDsa.SignData(message);

        Assert.That(dsa.Verify(pk, message, context: default, signature), Is.True,
            "We must verify .NET MLDsa's signature.");
    }

    private static System.Security.Cryptography.MLDsaAlgorithm DotnetAlgorithm(string name) => name switch
    {
        "ML-DSA-44" => System.Security.Cryptography.MLDsaAlgorithm.MLDsa44,
        "ML-DSA-65" => System.Security.Cryptography.MLDsaAlgorithm.MLDsa65,
        "ML-DSA-87" => System.Security.Cryptography.MLDsaAlgorithm.MLDsa87,
        _ => throw new ArgumentException($"Unknown parameter set: {name}", nameof(name)),
    };

#pragma warning restore SYSLIB5006
#endif

    private static MLDsaParameters BcParameters(string name) => name switch
    {
        "ML-DSA-44" => MLDsaParameters.ml_dsa_44,
        "ML-DSA-65" => MLDsaParameters.ml_dsa_65,
        "ML-DSA-87" => MLDsaParameters.ml_dsa_87,
        _ => throw new ArgumentException($"Unknown parameter set: {name}", nameof(name)),
    };
}
