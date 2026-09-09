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

    /// <summary>
    /// Signs a pre-computed digest using the pre-hash variant (HashML-DSA / HashSLH-DSA).
    /// </summary>
    /// <param name="message">The raw message, for implementations that hash it themselves.</param>
    /// <param name="digest">PH(<paramref name="message"/>), for implementations that take a digest.</param>
    /// <param name="signature">Receives the signature.</param>
    /// <remarks>
    /// Both forms of the input are supplied because the libraries disagree about which they
    /// take. Ours and the in-box API accept the digest; BouncyCastle's <c>HashMLDsaSigner</c> and
    /// <c>HashSlhDsaSigner</c> accept the raw message and hash it internally, with no overload
    /// that takes a digest. Its rows therefore include the message-hashing cost — negligible
    /// beside a lattice or hash-based signature at the message size used here, but real, and
    /// unavoidable given its API. See <see cref="DsaPreHash"/> for which pre-hash function each
    /// parameter set uses and why that is not a free choice.
    /// </remarks>
    void SignPreHash(byte[] message, byte[] digest, byte[] signature);

    /// <summary>
    /// Verifies a pre-hash signature.
    /// </summary>
    /// <param name="message">The raw message, for implementations that hash it themselves.</param>
    /// <param name="digest">PH(<paramref name="message"/>), for implementations that take a digest.</param>
    /// <param name="signature">The signature.</param>
    /// <returns>True when the signature is valid.</returns>
    bool VerifyPreHash(byte[] message, byte[] digest, byte[] signature);
}

/// <summary>
/// Picks the pre-hash function each parameter set is benchmarked with, and computes the digest.
/// </summary>
/// <remarks>
/// <para>
/// The choice is not free. FIPS 204 and 205 allow any of the twelve approved pre-hash functions
/// with any parameter set, but BouncyCastle binds exactly one to each — <c>ml_dsa_65_with_sha512</c>,
/// <c>slh_dsa_sha2_128f_with_sha256</c>, <c>slh_dsa_shake_256f_with_shake256</c> and so on —
/// with no way to vary it. Comparing implementations therefore means using the function
/// BouncyCastle would use, which is what this maps.
/// </para>
/// <para>
/// The pattern it encodes is the natural one anyway: a pre-hash function matched to the set's
/// security category, drawn from the same family as the set's own hash instantiation.
/// </para>
/// </remarks>
public static class DsaPreHash
{
    /// <summary>
    /// Returns the ACVP name of the pre-hash function used for a parameter set.
    /// </summary>
    /// <param name="family">The parameter set, e.g. <c>SLH-DSA-SHAKE-192f</c>.</param>
    /// <returns>The ACVP hash algorithm name.</returns>
    /// <exception cref="ArgumentException">The name is not a known parameter set.</exception>
    public static string HashNameFor(string family)
    {
        if (family.StartsWith("ML-DSA", StringComparison.Ordinal))
        {
            return "SHA2-512";
        }

        if (family.StartsWith("SLH-DSA-SHAKE", StringComparison.Ordinal))
        {
            return family.Contains("128") ? "SHAKE-128" : "SHAKE-256";
        }

        if (family.StartsWith("SLH-DSA-SHA2", StringComparison.Ordinal))
        {
            return family.Contains("128") ? "SHA2-256" : "SHA2-512";
        }

        throw new ArgumentException($"Unknown parameter set: {family}", nameof(family));
    }

    /// <summary>
    /// Returns the dotted-decimal OID of the pre-hash function used for a parameter set.
    /// </summary>
    /// <param name="family">The parameter set.</param>
    /// <returns>The OID.</returns>
    public static string OidFor(string family) => HashNameFor(family) switch {
        "SHA2-256" => "2.16.840.1.101.3.4.2.1",
        "SHA2-512" => "2.16.840.1.101.3.4.2.3",
        "SHAKE-128" => "2.16.840.1.101.3.4.2.11",
        "SHAKE-256" => "2.16.840.1.101.3.4.2.12",
        string other => throw new ArgumentException($"No OID for pre-hash function {other}.", nameof(family)),
    };

    /// <summary>
    /// Computes PH(message) with the pre-hash function a parameter set is benchmarked with.
    /// </summary>
    /// <param name="family">The parameter set.</param>
    /// <param name="message">The message to hash.</param>
    /// <returns>The digest.</returns>
    public static byte[] Digest(string family, byte[] message)
        => Cryptography.Tests.Dsa.PreHashTestUtil.ComputeDigest(HashNameFor(family), message).Digest;
}

/// <summary>
/// Adapts the key-holding <see cref="CH.MLDsa"/> API — the recommended entry point, and the
/// one that mirrors <c>System.Security.Cryptography.MLDsa</c>.
/// </summary>
public sealed class MLDsaAdapter : IDsaRunner
{
    private readonly CH.MLDsaAlgorithm _algorithm;
    private readonly bool _performPairwiseConsistencyTest;
    private readonly string _preHashOid;
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
        _preHashOid = DsaPreHash.OidFor(algorithm.Name);
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
    /// <remarks>
    /// The spans are explicit for the same reason as on <see cref="Sign"/>, and one more: the
    /// span overload of <c>SignPreHash</c> takes the destination second, so passing two arrays
    /// would bind to the <c>byte[]</c> overload whose second parameter is the OID.
    /// </remarks>
    public void SignPreHash(byte[] message, byte[] digest, byte[] signature)
        => _signer!.SignPreHash(new ReadOnlySpan<byte>(digest), new Span<byte>(signature), _preHashOid);

    /// <inheritdoc/>
    public bool VerifyPreHash(byte[] message, byte[] digest, byte[] signature)
        => _verifier!.VerifyPreHash(new ReadOnlySpan<byte>(digest), new ReadOnlySpan<byte>(signature), _preHashOid);

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
    private readonly CH.MLDsaParams _parameters;
    private readonly string _preHashOid;
    private readonly byte[] _prefix = new byte[CH.PreHash.MaxPrefixBytes];
    private readonly byte[] _signSeed = new byte[CH.MLDsaParams.SignSeedBytes];
    private byte[] _publicKey = [];
    private byte[] _privateKey = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="MLDsaStatelessAdapter"/> class.
    /// </summary>
    /// <param name="dsa">The stateless signature instance.</param>
    /// <param name="family">The parameter set name, e.g. <c>ML-DSA-65</c>.</param>
    /// <param name="pairwiseConsistencyTest">Whether key generation runs the consistency check.</param>
    public MLDsaStatelessAdapter(CH.IDsa dsa, string family, bool pairwiseConsistencyTest = true)
    {
        _dsa = dsa;
        _performPairwiseConsistencyTest = pairwiseConsistencyTest;
        _keyGenPublicKey = new byte[dsa.PublicKeySizeBytes];
        _keyGenPrivateKey = new byte[dsa.SecretKeySizeBytes];
        _parameters = Cryptography.Tests.Dsa.PreHashTestUtil.MLDsaParamsFor(family);
        _preHashOid = DsaPreHash.OidFor(family);
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
    /// <remarks>
    /// One level below <see cref="CH.IDsa"/>, deliberately: that interface has no pre-hash
    /// member, because the pre-hash prefix (0x01 ‖ |ctx| ‖ ctx ‖ OID) is a different prefix from
    /// the pure one (0x00 ‖ |ctx| ‖ ctx) and <c>IDsa.Sign</c> builds the pure one internally. The
    /// row still measures what it claims to — the caller-owned-buffer path, with no key object
    /// allocated per call.
    /// </remarks>
    public void SignPreHash(byte[] message, byte[] digest, byte[] signature)
    {
        int prefixLength = CH.PreHash.BuildPrefix(default, _preHashOid, _prefix);

        // Fresh randomness per call, so this measures the hedged variant the Sign row above
        // measures rather than the cheaper deterministic one.
        CH.MLDsaCore.GenerateRandomSeed(_signSeed);
        CH.MLDsaCore.Sign(_parameters, _privateKey, _prefix.AsSpan(0, prefixLength), digest,
                          _signSeed, signature);
    }

    /// <inheritdoc/>
    public bool VerifyPreHash(byte[] message, byte[] digest, byte[] signature)
    {
        int prefixLength = CH.PreHash.BuildPrefix(default, _preHashOid, _prefix);
        return CH.MLDsaCore.Verify(_parameters, _publicKey, _prefix.AsSpan(0, prefixLength), digest, signature);
    }

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
    private readonly MLDsaParameters _preHashParameters;
    private readonly SecureRandom _random = new();
    private readonly MLDsaKeyPairGenerator _generator = new();
    private MLDsaSigner? _signer;
    private MLDsaSigner? _verifier;
    private HashMLDsaSigner? _preHashSigner;
    private HashMLDsaSigner? _preHashVerifier;

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
    public BouncyCastleDsaAdapter(MLDsaParameters parameters, MLDsaParameters preHashParameters,
                                  int publicKeySizeBytes,
                                  int privateKeySizeBytes, int signatureSizeBytes)
    {
        _parameters = parameters;
        _preHashParameters = preHashParameters;
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

        // The pre-hash signers take the parameter set with the hash bound into it, and the key
        // has to be re-encoded under that set: BouncyCastle treats ml_dsa_65 and
        // ml_dsa_65_with_sha512 as different parameter objects.
        _preHashSigner = new HashMLDsaSigner(_preHashParameters, deterministic: false);
        _preHashSigner.Init(forSigning: true,
            MLDsaPrivateKeyParameters.FromEncoding(_preHashParameters, privateKey));

        _preHashVerifier = new HashMLDsaSigner(_preHashParameters, deterministic: false);
        _preHashVerifier.Init(forSigning: false,
            MLDsaPublicKeyParameters.FromEncoding(_preHashParameters, publicKey));
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
    /// <remarks>
    /// Takes the raw message, not the digest: <c>HashMLDsaSigner</c> hashes internally and has
    /// no digest-input overload, so this row carries the message-hashing cost the others do not.
    /// </remarks>
    public void SignPreHash(byte[] message, byte[] digest, byte[] signature)
    {
        _preHashSigner!.BlockUpdate(message, 0, message.Length);
        byte[] produced = _preHashSigner.GenerateSignature();
        produced.CopyTo(signature, 0);
    }

    /// <inheritdoc/>
    public bool VerifyPreHash(byte[] message, byte[] digest, byte[] signature)
    {
        _preHashVerifier!.BlockUpdate(message, 0, message.Length);
        return _preHashVerifier.VerifySignature(signature);
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
    private readonly string _preHashOid;
    private System.Security.Cryptography.MLDsa? _signer;
    private System.Security.Cryptography.MLDsa? _verifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="OSDsaAdapter"/> class.
    /// </summary>
    /// <param name="algorithm">The parameter set.</param>
    public OSDsaAdapter(System.Security.Cryptography.MLDsaAlgorithm algorithm)
    {
        _algorithm = algorithm;
        _preHashOid = DsaPreHash.OidFor(algorithm.Name);
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
    public void SignPreHash(byte[] message, byte[] digest, byte[] signature)
        => _signer!.SignPreHash(new ReadOnlySpan<byte>(digest), new Span<byte>(signature), _preHashOid);

    /// <inheritdoc/>
    public bool VerifyPreHash(byte[] message, byte[] digest, byte[] signature)
        => _verifier!.VerifyPreHash(new ReadOnlySpan<byte>(digest), new ReadOnlySpan<byte>(signature), _preHashOid);

    /// <inheritdoc/>
    public void Dispose()
    {
        _signer?.Dispose();
        _verifier?.Dispose();
    }
}

#pragma warning restore SYSLIB5006
#endif
