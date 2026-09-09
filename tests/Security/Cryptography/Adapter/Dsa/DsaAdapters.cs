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
/// Uniform surface over the ML-DSA implementations under comparison, so tests and benchmarks
/// can drive all of them through one shape.
/// </summary>
/// <remarks>
/// <para>
/// The signature counterpart of <c>IKemRunner</c>, and it follows the same two rules:
/// </para>
/// <list type="bullet">
///   <item><description>
///     All buffers are <c>byte[]</c>. BouncyCastle's signer only accepts <c>byte[]</c> with
///     offsets, so exposing spans would force a per-call copy on one competitor and distort
///     the result.
///   </description></item>
///   <item><description>
///     Everything an implementation can legitimately hoist out of the operation — importing a
///     key, constructing a signer — happens in <see cref="IDsaRunner.Prepare"/>. Work an
///     implementation genuinely repeats per call stays inside the measured method. That is
///     deliberate: the stateless <see cref="CH.IDsa"/> path re-validates the private key on
///     every <c>Sign</c>, and a benchmark should show that rather than hide it.
///   </description></item>
/// </list>
/// <para>
/// One asymmetry is unavoidable and is BouncyCastle's own API cost rather than an artifact of
/// this harness: its <c>GenerateSignature</c> returns a fresh array, so
/// <see cref="BouncyCastleDsaAdapter"/> copies into the caller's destination. The managed and
/// in-box implementations write into that destination directly.
/// </para>
/// <para>
/// Signing is variable-cost by construction — the FIPS 204 rejection loop runs a
/// data-dependent number of iterations — so every runner is handed the same key and the same
/// message, and per-operation variance is expected in the results.
/// </para>
/// </remarks>
public interface IDsaRunner : IDisposable
{
    /// <summary>Gets the public key size in bytes.</summary>
    int PublicKeySizeBytes { get; }

    /// <summary>Gets the expanded private key size in bytes.</summary>
    int PrivateKeySizeBytes { get; }

    /// <summary>Gets the signature size in bytes.</summary>
    int SignatureSizeBytes { get; }

    /// <summary>
    /// Imports the key material the <see cref="Sign"/> and <see cref="Verify"/> methods
    /// operate on. Called once from setup.
    /// </summary>
    /// <param name="publicKey">The public key.</param>
    /// <param name="privateKey">The expanded private key.</param>
    void Prepare(byte[] publicKey, byte[] privateKey);

    /// <summary>
    /// Produces a fresh key pair using the implementation's own natural API and returns the
    /// result so the work cannot be optimized away.
    /// </summary>
    /// <returns>The generated key pair, in whatever form the implementation produces.</returns>
    /// <remarks>
    /// The allocation profiles differ by design: the stateless path writes into caller-owned
    /// buffers, while the key-holding APIs allocate a key object per call.
    /// </remarks>
    object GenerateKeyPair();

    /// <summary>Signs a message into a caller-owned buffer using the hedged variant.</summary>
    /// <param name="message">The message to sign.</param>
    /// <param name="signature">Receives the signature.</param>
    void Sign(byte[] message, byte[] signature);

    /// <summary>Verifies a signature over a message.</summary>
    /// <param name="message">The signed message.</param>
    /// <param name="signature">The signature.</param>
    /// <returns>True when the signature is valid.</returns>
    bool Verify(byte[] message, byte[] signature);
}

/// <summary>
/// Adapts the key-holding <see cref="CH.MLDsa"/> API — the recommended entry point, and the
/// one that mirrors <c>System.Security.Cryptography.MLDsa</c>.
/// </summary>
public sealed class MLDsaAdapter : IDsaRunner
{
    private readonly CH.MLDsaAlgorithm _algorithm;
    private readonly bool _performPairwiseConsistencyTest;
    private CH.MLDsa? _signer;
    private CH.MLDsa? _verifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="MLDsaAdapter"/> class.
    /// </summary>
    /// <param name="algorithm">The parameter set.</param>
    /// <param name="pairwiseConsistencyTest">
    /// Whether key generation verifies the new key pair with a sign/verify round trip. Only
    /// <see cref="GenerateKeyPair"/> is affected; signing and verification are identical either
    /// way, so the registry variant that turns this off exists to give the KeyGen block a row
    /// showing what the check costs. For ML-DSA that cost dominates: the check performs a full
    /// signature, itself a rejection loop.
    /// </param>
    public MLDsaAdapter(CH.MLDsaAlgorithm algorithm, bool pairwiseConsistencyTest = true)
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
        _signer = CH.MLDsa.ImportMLDsaPrivateKey(_algorithm, privateKey);
        _verifier = CH.MLDsa.ImportMLDsaPublicKey(_algorithm, publicKey);
    }

    /// <inheritdoc/>
    public object GenerateKeyPair()
        => CH.MLDsa.GenerateKey(_algorithm, _performPairwiseConsistencyTest);

    /// <inheritdoc/>
    /// <remarks>
    /// The spans are explicit on purpose. <c>SignData(byte[], byte[])</c> also binds — to the
    /// overload whose second parameter is the <i>context</i>, not a destination — so passing
    /// two arrays would silently sign with the signature buffer as the context string and
    /// leave the destination untouched. That overload pair is the in-box <c>MLDsa</c>'s own
    /// shape, which this type mirrors deliberately, so the hazard is inherited rather than
    /// introduced here; <see cref="OSDsaAdapter"/> has to spell the spans out for the same
    /// reason.
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
/// Adapts the stateless <see cref="CH.IDsa"/> API, where the caller owns the raw key bytes.
/// </summary>
public sealed class MLDsaStatelessAdapter : IDsaRunner
{
    private readonly CH.IDsa _dsa;
    private readonly bool _performPairwiseConsistencyTest;
    private readonly byte[] _keyGenPublicKey;
    private readonly byte[] _keyGenPrivateKey;
    private byte[] _publicKey = [];
    private byte[] _privateKey = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="MLDsaStatelessAdapter"/> class.
    /// </summary>
    /// <param name="dsa">The stateless signature instance.</param>
    /// <param name="pairwiseConsistencyTest">Whether key generation runs the consistency check.</param>
    public MLDsaStatelessAdapter(CH.IDsa dsa, bool pairwiseConsistencyTest = true)
    {
        _dsa = dsa;
        _performPairwiseConsistencyTest = pairwiseConsistencyTest;
        _keyGenPublicKey = new byte[dsa.PublicKeySizeBytes];
        _keyGenPrivateKey = new byte[dsa.SecretKeySizeBytes];
    }

    /// <inheritdoc/>
    public int PublicKeySizeBytes => _dsa.PublicKeySizeBytes;

    /// <inheritdoc/>
    public int PrivateKeySizeBytes => _dsa.SecretKeySizeBytes;

    /// <inheritdoc/>
    public int SignatureSizeBytes => _dsa.SignatureSizeBytes;

    /// <inheritdoc/>
    public void Prepare(byte[] publicKey, byte[] privateKey)
    {
        _publicKey = publicKey;
        _privateKey = privateKey;
    }

    /// <inheritdoc/>
    /// <remarks>Writes into buffers owned by this adapter, so it allocates nothing per call.</remarks>
    public object GenerateKeyPair()
    {
        _dsa.GenerateKeyPair(_keyGenPublicKey, _keyGenPrivateKey, _performPairwiseConsistencyTest);
        return _keyGenPublicKey;
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Re-validates the private key's length and decodes it on every call, by design of the
    /// stateless API — there is no imported key to attach that work to.
    /// </remarks>
    public void Sign(byte[] message, byte[] signature)
        => _dsa.Sign(_privateKey, message, context: default, signature);

    /// <inheritdoc/>
    public bool Verify(byte[] message, byte[] signature)
        => _dsa.Verify(_publicKey, message, context: default, signature);

    /// <inheritdoc/>
    public void Dispose() => _dsa.Dispose();
}

/// <summary>
/// Adapts BouncyCastle's ML-DSA, available on every target framework.
/// </summary>
/// <remarks>
/// <c>MLDsaSigner</c> accumulates the message through <c>BlockUpdate</c> and resets itself
/// after each <c>GenerateSignature</c>/<c>VerifySignature</c>, so one initialized signer serves
/// every call. <c>GenerateSignature</c> allocates its result, which this adapter copies into
/// the caller's destination — BouncyCastle's own API cost, not one this harness introduces.
/// </remarks>
public sealed class BouncyCastleDsaAdapter : IDsaRunner
{
    private readonly MLDsaParameters _parameters;
    private readonly SecureRandom _random = new();
    private readonly MLDsaKeyPairGenerator _generator = new();
    private MLDsaSigner? _signer;
    private MLDsaSigner? _verifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleDsaAdapter"/> class.
    /// </summary>
    /// <param name="parameters">The BouncyCastle parameter set.</param>
    /// <param name="publicKeySizeBytes">The FIPS 204 public key size for this parameter set.</param>
    /// <param name="privateKeySizeBytes">The FIPS 204 private key size for this parameter set.</param>
    /// <param name="signatureSizeBytes">The FIPS 204 signature size for this parameter set.</param>
    /// <remarks>
    /// The sizes are supplied by the registry rather than discovered, because BouncyCastle
    /// exposes them only on a constructed key or a produced signature — and generating a
    /// throwaway signature just to measure its length is a strange thing for a benchmark
    /// harness to do in setup. They are fixed by the parameter set in any case.
    /// </remarks>
    public BouncyCastleDsaAdapter(MLDsaParameters parameters, int publicKeySizeBytes,
                                  int privateKeySizeBytes, int signatureSizeBytes)
    {
        _parameters = parameters;
        PublicKeySizeBytes = publicKeySizeBytes;
        PrivateKeySizeBytes = privateKeySizeBytes;
        SignatureSizeBytes = signatureSizeBytes;
        _generator.Init(new MLDsaKeyGenerationParameters(_random, parameters));
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
        _signer = new MLDsaSigner(_parameters, deterministic: false);
        _signer.Init(forSigning: true, MLDsaPrivateKeyParameters.FromEncoding(_parameters, privateKey));

        _verifier = new MLDsaSigner(_parameters, deterministic: false);
        _verifier.Init(forSigning: false, MLDsaPublicKeyParameters.FromEncoding(_parameters, publicKey));
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
/// Adapts the in-box <c>System.Security.Cryptography.MLDsa</c>, present on .NET 10 where the
/// platform provides ML-DSA.
/// </summary>
public sealed class OSDsaAdapter : IDsaRunner
{
    private readonly System.Security.Cryptography.MLDsaAlgorithm _algorithm;
    private System.Security.Cryptography.MLDsa? _signer;
    private System.Security.Cryptography.MLDsa? _verifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="OSDsaAdapter"/> class.
    /// </summary>
    /// <param name="algorithm">The parameter set.</param>
    public OSDsaAdapter(System.Security.Cryptography.MLDsaAlgorithm algorithm) => _algorithm = algorithm;

    /// <inheritdoc/>
    public int PublicKeySizeBytes => _algorithm.PublicKeySizeInBytes;

    /// <inheritdoc/>
    public int PrivateKeySizeBytes => _algorithm.PrivateKeySizeInBytes;

    /// <inheritdoc/>
    public int SignatureSizeBytes => _algorithm.SignatureSizeInBytes;

    /// <inheritdoc/>
    public void Prepare(byte[] publicKey, byte[] privateKey)
    {
        _signer = System.Security.Cryptography.MLDsa.ImportMLDsaPrivateKey(_algorithm, privateKey);
        _verifier = System.Security.Cryptography.MLDsa.ImportMLDsaPublicKey(_algorithm, publicKey);
    }

    /// <inheritdoc/>
    public object GenerateKeyPair() => System.Security.Cryptography.MLDsa.GenerateKey(_algorithm);

    /// <inheritdoc/>
    /// <remarks>
    /// Spans are explicit here for the reason described on <see cref="MLDsaAdapter.Sign"/>:
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
