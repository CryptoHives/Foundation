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
using MLDsaKey = CryptoHives.Foundation.Security.Cryptography.Dsa.MLDsa;
using SlhDsaKey = CryptoHives.Foundation.Security.Cryptography.Dsa.SlhDsa;

/// <summary>
/// API and interop tests for the HashML-DSA / HashSLH-DSA pre-hash variants
/// (<c>SignPreHash</c> / <c>VerifyPreHash</c>).
/// </summary>
/// <remarks>
/// The four overloads mirror the in-box <c>MLDsa</c> and <c>SlhDsa</c> exactly — a <c>byte[]</c>
/// pair and a span pair, the latter writing into a caller-owned destination. Both shapes are
/// exercised here; <c>ApiSurface_MatchesTheInBoxType</c> in <c>MLDsaApiTests</c> and
/// <c>SlhDsaApiTests</c> proves the signatures match at compile time.
/// </remarks>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class PreHashApiTests
{
    private const string Sha256Oid = "2.16.840.1.101.3.4.2.1";
    private const string Sha512Oid = "2.16.840.1.101.3.4.2.3";
    private const string Shake128Oid = "2.16.840.1.101.3.4.2.11";

    [Test]
    public void MLDsa_PreHash_RoundTrips()
    {
        using var dsa = MLDsaKey.GenerateKey(MLDsaAlgorithm.MLDsa65);

        byte[] message = new byte[300];
        byte[] digest = Sha512Digest(message);
        byte[] context = "app"u8.ToArray();

        byte[] signature = dsa.SignPreHash(digest, Sha512Oid, context);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dsa.VerifyPreHash(digest, signature, Sha512Oid, context), Is.True);
            Assert.That(dsa.VerifyPreHash(digest, signature, Sha512Oid), Is.False,
                "A pre-hash signature must be bound to its context.");
            Assert.That(dsa.VerifyData(message, signature, context), Is.False,
                "A pre-hash signature must not verify as a pure signature.");
        }
    }

    [Test]
    public void SlhDsa_PreHash_RoundTrips()
    {
        using var dsa = SlhDsaKey.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);

        byte[] message = new byte[200];
        byte[] digest = Sha256Digest(message);

        byte[] signature = dsa.SignPreHash(digest, Sha256Oid);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(dsa.VerifyPreHash(digest, signature, Sha256Oid), Is.True);
            Assert.That(dsa.VerifyPreHash(digest, signature, Shake128Oid), Is.False,
                "A pre-hash signature must be bound to the pre-hash function OID.");
            Assert.That(dsa.VerifyData(message, signature), Is.False,
                "A pre-hash signature must not verify as a pure signature.");
        }
    }

    [Test]
    public void PreHash_SpanOverloads_AgreeWithTheByteArrayOnes()
    {
        using var mlDsa = MLDsaKey.GenerateKey(MLDsaAlgorithm.MLDsa44);
        using var slhDsa = SlhDsaKey.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);

        byte[] message = new byte[64];
        byte[] digest = Sha512Digest(message);
        byte[] context = "ctx"u8.ToArray();

        // The spans are explicit on purpose: the second parameter of the span overload is the
        // destination, while the second parameter of SignData(byte[], byte[]) is the context.
        // That overload pair is the in-box shape this type mirrors, so the hazard is inherited.
        byte[] mlSignature = new byte[MLDsaAlgorithm.MLDsa44.SignatureSizeInBytes];
        mlDsa.SignPreHash(new ReadOnlySpan<byte>(digest), new Span<byte>(mlSignature), Sha512Oid,
                          new ReadOnlySpan<byte>(context));

        byte[] slhSignature = new byte[SlhDsaAlgorithm.SlhDsaShake128f.SignatureSizeInBytes];
        slhDsa.SignPreHash(new ReadOnlySpan<byte>(digest), new Span<byte>(slhSignature), Sha512Oid,
                           new ReadOnlySpan<byte>(context));

        using (Assert.EnterMultipleScope())
        {
            Assert.That(mlDsa.VerifyPreHash(digest, mlSignature, Sha512Oid, context), Is.True,
                "A signature written through the span overload must verify through the array one.");
            Assert.That(slhDsa.VerifyPreHash(digest, slhSignature, Sha512Oid, context), Is.True,
                "A signature written through the span overload must verify through the array one.");

            Assert.That(() => mlDsa.SignPreHash(new ReadOnlySpan<byte>(digest), new Span<byte>(new byte[7]),
                                                Sha512Oid), Throws.InstanceOf<ArgumentException>(),
                "A destination of the wrong length must be rejected.");
        }
    }

    [Test]
    public void PreHash_InvalidArguments_Throw()
    {
        using var dsa = MLDsaKey.GenerateKey(MLDsaAlgorithm.MLDsa44);
        byte[] digest32 = new byte[32];

        using (Assert.EnterMultipleScope())
        {
            Assert.That(() => dsa.SignPreHash(digest32, "1.2.3.4"), Throws.InstanceOf<ArgumentException>(),
                "An unapproved pre-hash OID must be rejected.");
            Assert.That(() => dsa.SignPreHash(new byte[16], Sha256Oid), Throws.InstanceOf<ArgumentException>(),
                "A digest whose length does not match the OID must be rejected.");
            Assert.That(() => dsa.SignPreHash(null!, Sha256Oid), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => dsa.SignPreHash(digest32, null!), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => dsa.SignPreHash(digest32, Sha256Oid, new byte[256]), Throws.InstanceOf<ArgumentException>(),
                "Context longer than 255 bytes must be rejected.");
            Assert.That(() => dsa.VerifyPreHash(null!, new byte[1], Sha256Oid), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => dsa.VerifyPreHash(digest32, null!, Sha256Oid), Throws.InstanceOf<ArgumentNullException>());
        }
    }

    [Test]
    public void PreHash_PublicKeyOnly_CannotSign()
    {
        using var signer = MLDsaKey.GenerateKey(MLDsaAlgorithm.MLDsa44);
        using var verifier = MLDsaKey.ImportMLDsaPublicKey(MLDsaAlgorithm.MLDsa44, signer.ExportMLDsaPublicKey());

        Assert.That(() => verifier.SignPreHash(new byte[32], Sha256Oid),
            Throws.InstanceOf<System.Security.Cryptography.CryptographicException>(),
            "An instance holding only a public key must not sign.");
    }

    [Test]
    public void MLDsa_PreHash_BouncyCastleInterop()
    {
        // BouncyCastle's HashMLDsaSigner hashes the raw message internally with the
        // hash bound to the parameter set (ml_dsa_65_with_sha512).
        using var ours = MLDsaKey.GenerateKey(MLDsaAlgorithm.MLDsa65);

        byte[] message = new byte[150];
        for (int i = 0; i < message.Length; i++)
        {
            message[i] = (byte)(i & 0xFF);
        }

        byte[] digest = Sha512Digest(message);

        byte[] signature = ours.SignPreHash(digest, Sha512Oid);

        var bcVerifier = new HashMLDsaSigner(MLDsaParameters.ml_dsa_65_with_sha512, deterministic: false);
        bcVerifier.Init(forSigning: false, MLDsaPublicKeyParameters.FromEncoding(
            MLDsaParameters.ml_dsa_65_with_sha512, ours.ExportMLDsaPublicKey()));
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

        using var verifier = MLDsaKey.ImportMLDsaPublicKey(MLDsaAlgorithm.MLDsa65,
            ((MLDsaPublicKeyParameters)keyPair.Public).GetEncoded());
        Assert.That(verifier.VerifyPreHash(digest, bcSignature, Sha512Oid), Is.True,
            "We must verify BouncyCastle's HashML-DSA signature.");
    }

    [Test]
    public void SlhDsa_PreHash_BouncyCastleInterop()
    {
        using var ours = SlhDsaKey.GenerateKey(SlhDsaAlgorithm.SlhDsaSha2_128f);

        byte[] message = new byte[130];
        for (int i = 0; i < message.Length; i++)
        {
            message[i] = (byte)(0x77 ^ i);
        }

        byte[] digest = Sha256Digest(message);

        byte[] signature = ours.SignPreHash(digest, Sha256Oid);

        var bcVerifier = new HashSlhDsaSigner(SlhDsaParameters.slh_dsa_sha2_128f_with_sha256, deterministic: false);
        bcVerifier.Init(forSigning: false, SlhDsaPublicKeyParameters.FromEncoding(
            SlhDsaParameters.slh_dsa_sha2_128f_with_sha256, ours.ExportSlhDsaPublicKey()));
        bcVerifier.BlockUpdate(message, 0, message.Length);
        Assert.That(bcVerifier.VerifySignature(signature), Is.True,
            "BouncyCastle must verify our HashSLH-DSA signature over the raw message.");
    }

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

    [Test]
    public void MLDsa_PreHash_DotnetInterop()
    {
        if (!System.Security.Cryptography.MLDsa.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.MLDsa is not supported on this platform.");
        }

        using var ours = MLDsaKey.GenerateKey(MLDsaAlgorithm.MLDsa65);

        byte[] message = new byte[90];
        byte[] digest = Sha512Digest(message);
        byte[] context = new byte[5];

        // Direction 1: we sign, .NET verifies against our public key.
        byte[] signature = ours.SignPreHash(digest, Sha512Oid, context);
        using var dotnetVerifier = System.Security.Cryptography.MLDsa.ImportMLDsaPublicKey(
            System.Security.Cryptography.MLDsaAlgorithm.MLDsa65, ours.ExportMLDsaPublicKey());
        Assert.That(dotnetVerifier.VerifyPreHash(digest, signature, Sha512Oid, context), Is.True,
            ".NET MLDsa must verify our HashML-DSA signature.");

        // Direction 2: .NET signs with its own key, we verify against its public key.
        using var dotnetSigner = System.Security.Cryptography.MLDsa.GenerateKey(
            System.Security.Cryptography.MLDsaAlgorithm.MLDsa65);
        byte[] dotnetSignature = dotnetSigner.SignPreHash(digest, Sha512Oid, context);

        using var verifier = MLDsaKey.ImportMLDsaPublicKey(
            MLDsaAlgorithm.MLDsa65, dotnetSigner.ExportMLDsaPublicKey());
        Assert.That(verifier.VerifyPreHash(digest, dotnetSignature, Sha512Oid, context), Is.True,
            "We must verify .NET MLDsa's HashML-DSA signature.");
    }

    [Test]
    public void SlhDsa_PreHash_DotnetInterop()
    {
        if (!System.Security.Cryptography.SlhDsa.IsSupported)
        {
            Assert.Ignore("System.Security.Cryptography.SlhDsa is not supported on this platform.");
        }

        using var ours = SlhDsaKey.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);

        byte[] message = new byte[90];
        byte[] digest = Sha256Digest(message);
        byte[] context = new byte[5];

        // Direction 1: we sign, .NET verifies against our public key.
        byte[] signature = ours.SignPreHash(digest, Sha256Oid, context);
        using var dotnetVerifier = System.Security.Cryptography.SlhDsa.ImportSlhDsaPublicKey(
            System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake128f, ours.ExportSlhDsaPublicKey());
        Assert.That(dotnetVerifier.VerifyPreHash(digest, signature, Sha256Oid, context), Is.True,
            ".NET SlhDsa must verify our HashSLH-DSA signature.");

        // Direction 2: .NET signs with its own key, we verify against its public key.
        using var dotnetSigner = System.Security.Cryptography.SlhDsa.GenerateKey(
            System.Security.Cryptography.SlhDsaAlgorithm.SlhDsaShake128f);
        byte[] dotnetSignature = dotnetSigner.SignPreHash(digest, Sha256Oid, context);

        using var verifier = SlhDsaKey.ImportSlhDsaPublicKey(
            SlhDsaAlgorithm.SlhDsaShake128f, dotnetSigner.ExportSlhDsaPublicKey());
        Assert.That(verifier.VerifyPreHash(digest, dotnetSignature, Sha256Oid, context), Is.True,
            "We must verify .NET SlhDsa's HashSLH-DSA signature.");
    }

#pragma warning restore SYSLIB5006
#endif

    private static byte[] Sha256Digest(byte[] message)
    {
        using SHA256 hash = SHA256.Create();
        byte[] digest = new byte[32];
        hash.TryComputeHash(message, digest, out _);
        return digest;
    }

    private static byte[] Sha512Digest(byte[] message)
    {
        using SHA512 hash = SHA512.Create();
        byte[] digest = new byte[64];
        hash.TryComputeHash(message, digest, out _);
        return digest;
    }
}
