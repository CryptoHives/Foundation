// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Dsa;

using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Security;
using System;
using CH = CryptoHives.Foundation.Security.Cryptography.Dsa;

/// <summary>
/// Adapts the key-holding <see cref="CH.SlhDsa"/> API — the recommended entry point, and the one
/// that mirrors <c>System.Security.Cryptography.SlhDsa</c>.
/// </summary>
/// <remarks>
/// There is no stateless counterpart to <c>MLDsaStatelessAdapter</c>, and that is by design:
/// SLH-DSA has no per-parameter-set <see cref="CH.IDsa"/> wrappers. That interface takes a
/// 32-byte seed ξ, whereas SLH-DSA key generation consumes three n-byte seeds
/// (SK.seed ‖ SK.prf ‖ PK.seed), so the shapes do not line up.
/// </remarks>
public sealed class SlhDsaAdapter : IDsaRunner
{
    private readonly CH.SlhDsaAlgorithm _algorithm;
    private readonly bool _performPairwiseConsistencyTest;
    private CH.SlhDsa? _signer;
    private CH.SlhDsa? _verifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="SlhDsaAdapter"/> class.
    /// </summary>
    /// <param name="algorithm">The parameter set.</param>
    /// <param name="pairwiseConsistencyTest">
    /// Whether key generation verifies the new key pair with a sign/verify round trip. Only
    /// <see cref="GenerateKeyPair"/> is affected; signing and verification are identical either
    /// way, so the registry variant that turns this off exists to give the KeyGen block a row
    /// showing what the check costs. For SLH-DSA that cost is not a contribution but the whole
    /// measurement: generating a key builds one XMSS tree, while the check signs, which walks
    /// the entire hypertree.
    /// </param>
    public SlhDsaAdapter(CH.SlhDsaAlgorithm algorithm, bool pairwiseConsistencyTest = true)
    {
        _algorithm = algorithm;
        _performPairwiseConsistencyTest = pairwiseConsistencyTest;
    }

    /// <inheritdoc/>
    public int PublicKeySizeBytes => _algorithm.PublicKeySizeInBytes;

    /// <inheritdoc/>
    public int PrivateKeySizeBytes => _algorithm.PrivateKeySizeInBytes;

    /// <inheritdoc/>
    public int SignatureSizeBytes => _algorithm.SignatureSizeInBytes;

    /// <inheritdoc/>
    public void Prepare(byte[] publicKey, byte[] privateKey)
    {
        _signer = CH.SlhDsa.ImportSlhDsaPrivateKey(_algorithm, privateKey);
        _verifier = CH.SlhDsa.ImportSlhDsaPublicKey(_algorithm, publicKey);
    }

    /// <inheritdoc/>
    public object GenerateKeyPair()
        => CH.SlhDsa.GenerateKey(_algorithm, _performPairwiseConsistencyTest);

    /// <inheritdoc/>
    /// <remarks>
    /// The spans are explicit on purpose. <c>SignData(byte[], byte[])</c> also binds — to the
    /// overload whose second parameter is the <i>context</i>, not a destination — so passing
    /// two arrays would silently sign with the signature buffer as the context string and leave
    /// the destination untouched. That overload pair is the in-box <c>SlhDsa</c>'s own shape,
    /// which this type mirrors deliberately, so the hazard is inherited rather than introduced
    /// here; <see cref="OSSlhDsaAdapter"/> has to spell the spans out for the same reason.
    /// </remarks>
    public void Sign(byte[] message, byte[] signature)
        => _signer!.SignData(new ReadOnlySpan<byte>(message), new Span<byte>(signature));

    /// <inheritdoc/>
    public bool Verify(byte[] message, byte[] signature)
        => _verifier!.VerifyData(new ReadOnlySpan<byte>(message), new ReadOnlySpan<byte>(signature));

    /// <inheritdoc/>
    public void Dispose()
    {
        _signer?.Dispose();
        _verifier?.Dispose();
    }
}

/// <summary>
/// Adapts BouncyCastle's SLH-DSA, available on every target framework.
/// </summary>
/// <remarks>
/// Shaped exactly like <see cref="BouncyCastleDsaAdapter"/>: <c>SlhDsaSigner</c> accumulates the
/// message through <c>BlockUpdate</c> and resets after each operation, and
/// <c>GenerateSignature</c> allocates its result, which this adapter copies into the caller's
/// destination.
/// </remarks>
public sealed class BouncyCastleSlhDsaAdapter : IDsaRunner
{
    private readonly SlhDsaParameters _parameters;
    private readonly SecureRandom _random = new();
    private readonly SlhDsaKeyPairGenerator _generator = new();
    private SlhDsaSigner? _signer;
    private SlhDsaSigner? _verifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleSlhDsaAdapter"/> class.
    /// </summary>
    /// <param name="parameters">The BouncyCastle parameter set.</param>
    /// <param name="publicKeySizeBytes">The FIPS 205 public key size for this parameter set.</param>
    /// <param name="privateKeySizeBytes">The FIPS 205 private key size for this parameter set.</param>
    /// <param name="signatureSizeBytes">The FIPS 205 signature size for this parameter set.</param>
    public BouncyCastleSlhDsaAdapter(SlhDsaParameters parameters, int publicKeySizeBytes,
                                     int privateKeySizeBytes, int signatureSizeBytes)
    {
        _parameters = parameters;
        PublicKeySizeBytes = publicKeySizeBytes;
        PrivateKeySizeBytes = privateKeySizeBytes;
        SignatureSizeBytes = signatureSizeBytes;
        _generator.Init(new SlhDsaKeyGenerationParameters(_random, parameters));
    }

    /// <inheritdoc/>
    public int PublicKeySizeBytes { get; }

    /// <inheritdoc/>
    public int PrivateKeySizeBytes { get; }

    /// <inheritdoc/>
    public int SignatureSizeBytes { get; }

    /// <inheritdoc/>
    public void Prepare(byte[] publicKey, byte[] privateKey)
    {
        _signer = new SlhDsaSigner(_parameters, deterministic: false);
        _signer.Init(forSigning: true, SlhDsaPrivateKeyParameters.FromEncoding(_parameters, privateKey));

        _verifier = new SlhDsaSigner(_parameters, deterministic: false);
        _verifier.Init(forSigning: false, SlhDsaPublicKeyParameters.FromEncoding(_parameters, publicKey));
    }

    /// <inheritdoc/>
    public object GenerateKeyPair() => _generator.GenerateKeyPair();

    /// <inheritdoc/>
    public void Sign(byte[] message, byte[] signature)
    {
        _signer!.BlockUpdate(message, 0, message.Length);
        byte[] produced = _signer.GenerateSignature();
        produced.CopyTo(signature, 0);
    }

    /// <inheritdoc/>
    public bool Verify(byte[] message, byte[] signature)
    {
        _verifier!.BlockUpdate(message, 0, message.Length);
        return _verifier.VerifySignature(signature);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        // Nothing unmanaged; BouncyCastle types are plain managed objects.
    }
}

#if NET10_0_OR_GREATER
#pragma warning disable SYSLIB5006 // Post-quantum cryptography APIs may be experimental.

/// <summary>
/// Adapts the in-box <c>System.Security.Cryptography.SlhDsa</c>, present on .NET 10 where the
/// platform provides SLH-DSA.
/// </summary>
/// <remarks>
/// Platform support is narrower than for ML-DSA — the in-box type needs SLH-DSA from CNG or
/// OpenSSL — so the registry gates this variant on <c>SlhDsa.IsSupported</c> and it simply does
/// not appear where the OS has nothing to offer.
/// </remarks>
public sealed class OSSlhDsaAdapter : IDsaRunner
{
    private readonly System.Security.Cryptography.SlhDsaAlgorithm _algorithm;
    private System.Security.Cryptography.SlhDsa? _signer;
    private System.Security.Cryptography.SlhDsa? _verifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="OSSlhDsaAdapter"/> class.
    /// </summary>
    /// <param name="algorithm">The parameter set.</param>
    public OSSlhDsaAdapter(System.Security.Cryptography.SlhDsaAlgorithm algorithm) => _algorithm = algorithm;

    /// <inheritdoc/>
    public int PublicKeySizeBytes => _algorithm.PublicKeySizeInBytes;

    /// <inheritdoc/>
    public int PrivateKeySizeBytes => _algorithm.PrivateKeySizeInBytes;

    /// <inheritdoc/>
    public int SignatureSizeBytes => _algorithm.SignatureSizeInBytes;

    /// <inheritdoc/>
    public void Prepare(byte[] publicKey, byte[] privateKey)
    {
        _signer = System.Security.Cryptography.SlhDsa.ImportSlhDsaPrivateKey(_algorithm, privateKey);
        _verifier = System.Security.Cryptography.SlhDsa.ImportSlhDsaPublicKey(_algorithm, publicKey);
    }

    /// <inheritdoc/>
    public object GenerateKeyPair() => System.Security.Cryptography.SlhDsa.GenerateKey(_algorithm);

    /// <inheritdoc/>
    /// <remarks>
    /// Spans are explicit here for the reason described on <see cref="SlhDsaAdapter.Sign"/>:
    /// <c>SignData(byte[], byte[])</c> binds to the overload that takes a context string.
    /// </remarks>
    public void Sign(byte[] message, byte[] signature)
        => _signer!.SignData(new ReadOnlySpan<byte>(message), new Span<byte>(signature));

    /// <inheritdoc/>
    public bool Verify(byte[] message, byte[] signature)
        => _verifier!.VerifyData(new ReadOnlySpan<byte>(message), new ReadOnlySpan<byte>(signature));

    /// <inheritdoc/>
    public void Dispose()
    {
        _signer?.Dispose();
        _verifier?.Dispose();
    }
}

#pragma warning restore SYSLIB5006
#endif
