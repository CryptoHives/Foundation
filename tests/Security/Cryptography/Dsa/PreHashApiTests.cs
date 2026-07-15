// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Dsa;

using CryptoHives.Foundation.Security.Cryptography.Dsa;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using System;
using MlDsaKey = CryptoHives.Foundation.Security.Cryptography.Dsa.MlDsa;
using SlhDsaKey = CryptoHives.Foundation.Security.Cryptography.Dsa.SlhDsa;

/// <summary>
/// API and interop tests for the HashML-DSA / HashSLH-DSA pre-hash variants
/// (<c>SignPreHash</c> / <c>VerifyPreHash</c>).
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class PreHashApiTests
{
    private const string Sha256Oid = "2.16.840.1.101.3.4.2.1";
    private const string Sha512Oid = "2.16.840.1.101.3.4.2.3";
    private const string Shake128Oid = "2.16.840.1.101.3.4.2.11";

    [Test]
    public void MlDsa_PreHash_RoundTrips()
    {
        using var dsa = MlDsaKey.GenerateKey(MlDsaAlgorithm.MlDsa65);

        byte[] message = new byte[300];
        byte[] digest = Digest(SHA512.Create(), 64, message);

        byte[] signature = dsa.SignPreHash(digest, Sha512Oid, "app"u8);

        Assert.That(dsa.VerifyPreHash(digest, signature, Sha512Oid, "app"u8), Is.True);
        Assert.That(dsa.VerifyPreHash(digest, signature, Sha512Oid), Is.False,
            "A pre-hash signature must be bound to its context.");
        Assert.That(dsa.VerifyData(message, signature, "app"u8), Is.False,
            "A pre-hash signature must not verify as a pure signature.");
    }

    [Test]
    public void SlhDsa_PreHash_RoundTrips()
    {
        using var dsa = SlhDsaKey.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);

        byte[] message = new byte[200];
        byte[] digest = Digest(SHA256.Create(), 32, message);

        byte[] signature = dsa.SignPreHash(digest, Sha256Oid);

        Assert.That(dsa.VerifyPreHash(digest, signature, Sha256Oid), Is.True);
        Assert.That(dsa.VerifyPreHash(digest, signature, Shake128Oid), Is.False,
            "A pre-hash signature must be bound to the pre-hash function OID.");
        Assert.That(dsa.VerifyData(message, signature), Is.False,
            "A pre-hash signature must not verify as a pure signature.");
    }

    [Test]
    public void PreHash_InvalidArguments_Throw()
    {
        using var dsa = MlDsaKey.GenerateKey(MlDsaAlgorithm.MlDsa44);
        byte[] digest32 = new byte[32];

        Assert.That(() => dsa.SignPreHash(digest32, "1.2.3.4"), Throws.InstanceOf<ArgumentException>(),
            "An unapproved pre-hash OID must be rejected.");
        Assert.That(() => dsa.SignPreHash(new byte[16], Sha256Oid), Throws.InstanceOf<ArgumentException>(),
            "A digest whose length does not match the OID must be rejected.");
        Assert.That(() => dsa.SignPreHash(digest32, null!), Throws.InstanceOf<ArgumentNullException>());
        Assert.That(() => dsa.SignPreHash(digest32, Sha256Oid, new byte[256]), Throws.InstanceOf<ArgumentException>(),
            "Context longer than 255 bytes must be rejected.");
    }

    [Test]
    public void MlDsa_PreHash_BouncyCastleInterop()
    {
        // BouncyCastle's HashMLDsaSigner hashes the raw message internally with the
        // hash bound to the parameter set (ml_dsa_65_with_sha512).
        using var ours = MlDsaKey.GenerateKey(MlDsaAlgorithm.MlDsa65);

        byte[] message = new byte[150];
        for (int i = 0; i < message.Length; i++) message[i] = (byte)(i & 0xFF);
        byte[] digest = Digest(SHA512.Create(), 64, message);

        byte[] signature = ours.SignPreHash(digest, Sha512Oid);

        var bcVerifier = new HashMLDsaSigner(MLDsaParameters.ml_dsa_65_with_sha512, deterministic: false);
        bcVerifier.Init(forSigning: false, MLDsaPublicKeyParameters.FromEncoding(
            MLDsaParameters.ml_dsa_65_with_sha512, ours.ExportPublicKey()));
        bcVerifier.BlockUpdate(message, 0, message.Length);
        Assert.That(bcVerifier.VerifySignature(signature), Is.True,
            "BouncyCastle must verify our HashML-DSA signature over the raw message.");

        // And the reverse: BouncyCastle signs, we verify the digest.
        var generator = new MLDsaKeyPairGenerator();
        generator.Init(new MLDsaKeyGenerationParameters(new SecureRandom(), MLDsaParameters.ml_dsa_65_with_sha512));
        var keyPair = generator.GenerateKeyPair();

        var bcSigner = new HashMLDsaSigner(MLDsaParameters.ml_dsa_65_with_sha512, deterministic: false);
        bcSigner.Init(forSigning: true, new ParametersWithRandom(keyPair.Private, new SecureRandom()));
        bcSigner.BlockUpdate(message, 0, message.Length);
        byte[] bcSignature = bcSigner.GenerateSignature();

        using var verifier = MlDsaKey.ImportPublicKey(MlDsaAlgorithm.MlDsa65,
            ((MLDsaPublicKeyParameters)keyPair.Public).GetEncoded());
        Assert.That(verifier.VerifyPreHash(digest, bcSignature, Sha512Oid), Is.True,
            "We must verify BouncyCastle's HashML-DSA signature.");
    }

    [Test]
    public void SlhDsa_PreHash_BouncyCastleInterop()
    {
        using var ours = SlhDsaKey.GenerateKey(SlhDsaAlgorithm.SlhDsaSha2_128f);

        byte[] message = new byte[130];
        for (int i = 0; i < message.Length; i++) message[i] = (byte)(0x77 ^ i);
        byte[] digest = Digest(SHA256.Create(), 32, message);

        byte[] signature = ours.SignPreHash(digest, Sha256Oid);

        var bcVerifier = new HashSlhDsaSigner(SlhDsaParameters.slh_dsa_sha2_128f_with_sha256, deterministic: false);
        bcVerifier.Init(forSigning: false, SlhDsaPublicKeyParameters.FromEncoding(
            SlhDsaParameters.slh_dsa_sha2_128f_with_sha256, ours.ExportPublicKey()));
        bcVerifier.BlockUpdate(message, 0, message.Length);
        Assert.That(bcVerifier.VerifySignature(signature), Is.True,
            "BouncyCastle must verify our HashSLH-DSA signature over the raw message.");
    }

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

    [Test]
    public void MlDsa_PreHash_DotnetInterop()
    {
        if (!System.Security.Cryptography.MLDsa.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLDsa is not supported on this platform.");
        }

        using var ours = MlDsaKey.GenerateKey(MlDsaAlgorithm.MlDsa65);

        byte[] message = new byte[90];
        byte[] digest = Digest(SHA512.Create(), 64, message);
        byte[] context = new byte[5];

        // Direction 1: we sign, .NET verifies against our public key.
        byte[] signature = ours.SignPreHash(digest, Sha512Oid, context);
        using var dotnetVerifier = System.Security.Cryptography.MLDsa.ImportMLDsaPublicKey(
            System.Security.Cryptography.MLDsaAlgorithm.MLDsa65, ours.ExportPublicKey());
        Assert.That(dotnetVerifier.VerifyPreHash(digest, signature, Sha512Oid, context), Is.True,
            ".NET MLDsa must verify our HashML-DSA signature.");

        // Direction 2: .NET signs with its own key, we verify against its public key.
        using var dotnetSigner = System.Security.Cryptography.MLDsa.GenerateKey(
            System.Security.Cryptography.MLDsaAlgorithm.MLDsa65);
        byte[] dotnetSignature = dotnetSigner.SignPreHash(digest, Sha512Oid, context);

        using var verifier = MlDsaKey.ImportPublicKey(MlDsaAlgorithm.MlDsa65, dotnetSigner.ExportMLDsaPublicKey());
        Assert.That(verifier.VerifyPreHash(digest, dotnetSignature, Sha512Oid, context), Is.True,
            "We must verify .NET MLDsa's HashML-DSA signature.");
    }

#pragma warning restore SYSLIB5006
#endif

    private static byte[] Digest(HashAlgorithm hash, int size, byte[] message)
    {
        using (hash)
        {
            byte[] digest = new byte[size];
            hash.TryComputeHash(message, digest, out _);
            return digest;
        }
    }
}
