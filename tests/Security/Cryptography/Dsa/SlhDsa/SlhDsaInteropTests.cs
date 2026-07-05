// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa.SlhDsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using System;
using SlhDsa = CryptoHives.Foundation.Security.Cryptography.Dsa.SlhDsa;

/// <summary>
/// Cross-validation tests for SLH-DSA against independent implementations.
/// </summary>
/// <remarks>
/// Validates interoperability with BouncyCastle on all target frameworks and,
/// on .NET 10+, with the operating-system-backed
/// <c>System.Security.Cryptography.SlhDsa</c> where the platform supports it.
/// The fast (f) parameter sets are used to keep the default runtime reasonable.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class SlhDsaInteropTests
{
    private static readonly object[] ParameterSets =
    [
        new object[] { "SLH-DSA-SHA2-128f", SlhDsaAlgorithm.SlhDsaSha2_128f },
        new object[] { "SLH-DSA-SHAKE-128f", SlhDsaAlgorithm.SlhDsaShake128f },
        new object[] { "SLH-DSA-SHAKE-192f", SlhDsaAlgorithm.SlhDsaShake192f }
    ];

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Sign_BouncyCastleVerifies(string name, SlhDsaAlgorithm algorithm)
    {
        using var dsa = SlhDsa.GenerateKey(algorithm);

        byte[] message = new byte[120];
        for (int i = 0; i < message.Length; i++) message[i] = (byte)(i & 0xFF);
        byte[] signature = dsa.SignData(message);

        var verifier = new SlhDsaSigner(BcParameters(name), deterministic: false);
        verifier.Init(forSigning: false, SlhDsaPublicKeyParameters.FromEncoding(BcParameters(name), dsa.ExportPublicKey()));
        verifier.BlockUpdate(message, 0, message.Length);

        Assert.That(verifier.VerifySignature(signature), Is.True,
            "BouncyCastle must verify our hedged signature.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Verify_BouncyCastleSigns(string name, SlhDsaAlgorithm algorithm)
    {
        var generator = new SlhDsaKeyPairGenerator();
        generator.Init(new SlhDsaKeyGenerationParameters(new SecureRandom(), BcParameters(name)));
        var keyPair = generator.GenerateKeyPair();

        byte[] message = new byte[66];
        for (int i = 0; i < message.Length; i++) message[i] = (byte)(0x55 ^ i);

        var signer = new SlhDsaSigner(BcParameters(name), deterministic: false);
        signer.Init(forSigning: true, new ParametersWithRandom(keyPair.Private, new SecureRandom()));
        signer.BlockUpdate(message, 0, message.Length);
        byte[] signature = signer.GenerateSignature();

        byte[] pk = ((SlhDsaPublicKeyParameters)keyPair.Public).GetEncoded();

        using var verifier = SlhDsa.ImportPublicKey(algorithm, pk);
        Assert.That(verifier.VerifyData(message, signature), Is.True,
            "We must verify BouncyCastle's signature.");

        message[0] ^= 0x01;
        Assert.That(verifier.VerifyData(message, signature), Is.False,
            "A tampered message must not verify.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void ImportSecretKey_BouncyCastleKey_SignaturesInterop(string name, SlhDsaAlgorithm algorithm)
    {
        // Import a BouncyCastle-generated secret key and cross-verify signatures.
        var generator = new SlhDsaKeyPairGenerator();
        generator.Init(new SlhDsaKeyGenerationParameters(new SecureRandom(), BcParameters(name)));
        var keyPair = generator.GenerateKeyPair();
        byte[] sk = ((SlhDsaPrivateKeyParameters)keyPair.Private).GetEncoded();

        using var ours = SlhDsa.ImportSecretKey(algorithm, sk);

        byte[] message = new byte[48];
        byte[] signature = ours.SignData(message);

        var verifier = new SlhDsaSigner(BcParameters(name), deterministic: false);
        verifier.Init(forSigning: false, keyPair.Public);
        verifier.BlockUpdate(message, 0, message.Length);

        Assert.That(verifier.VerifySignature(signature), Is.True,
            "BouncyCastle must verify a signature made with its own imported key.");
    }

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Sign_DotnetVerifies(string name, SlhDsaAlgorithm algorithm)
    {
        if (!System.Security.Cryptography.SlhDsa.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.SlhDsa is not supported on this platform.");
        }

        using var dsa = SlhDsa.GenerateKey(algorithm);

        byte[] message = new byte[95];
        byte[] context = new byte[7];
        for (int i = 0; i < context.Length; i++) context[i] = (byte)(0xB0 + i);
        byte[] signature = dsa.SignData(message, context);

        using var dotnetDsa = System.Security.Cryptography.SlhDsa.ImportSlhDsaPublicKey(
            DotnetAlgorithm(name), dsa.ExportPublicKey());
        Assert.That(dotnetDsa.VerifyData(message, signature, context), Is.True,
            ".NET SlhDsa must verify our signature, including the context binding.");
    }

    [Test]
    [TestCaseSource(nameof(ParameterSets))]
    public void Verify_DotnetSigns(string name, SlhDsaAlgorithm algorithm)
    {
        if (!System.Security.Cryptography.SlhDsa.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.SlhDsa is not supported on this platform.");
        }

        using var dotnetDsa = System.Security.Cryptography.SlhDsa.GenerateKey(DotnetAlgorithm(name));
        byte[] message = new byte[71];
        byte[] signature = dotnetDsa.SignData(message);

        using var verifier = SlhDsa.ImportPublicKey(algorithm, dotnetDsa.ExportSlhDsaPublicKey());
        Assert.That(verifier.VerifyData(message, signature), Is.True,
            "We must verify .NET SlhDsa's signature.");
    }

    private static System.Security.Cryptography.SlhDsaAlgorithm DotnetAlgorithm(string name) => name switch
    {
        "SLH-DSA-SHA2-128f" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaSha2_128f,
        "SLH-DSA-SHAKE-128f" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake128f,
        "SLH-DSA-SHAKE-192f" => System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake192f,
        _ => throw new ArgumentException($"Unknown parameter set: {name}", nameof(name)),
    };

#pragma warning restore SYSLIB5006
#endif

    private static SlhDsaParameters BcParameters(string name) => name switch
    {
        "SLH-DSA-SHA2-128f" => SlhDsaParameters.slh_dsa_sha2_128f,
        "SLH-DSA-SHAKE-128f" => SlhDsaParameters.slh_dsa_shake_128f,
        "SLH-DSA-SHAKE-192f" => SlhDsaParameters.slh_dsa_shake_192f,
        _ => throw new ArgumentException($"Unknown parameter set: {name}", nameof(name)),
    };
}
