// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;
using OS = System.Security.Cryptography;

/// <summary>
/// Represents an ML-DSA key (FIPS 204) and provides signing and verification.
/// </summary>
/// <remarks>
/// <para>
/// The API shape mirrors <c>System.Security.Cryptography.MLDsa</c> from .NET 10 so code
/// written against the in-box type ports directly to older target frameworks, including
/// .NET Framework and .NET Standard 2.0.
/// </para>
/// <para>
/// An instance holds either a full key pair (created via <see cref="GenerateKey(MLDsaAlgorithm)"/>,
/// <see cref="ImportMLDsaPrivateSeed(MLDsaAlgorithm, ReadOnlySpan{byte})"/>, or
/// <see cref="ImportMLDsaPrivateKey(MLDsaAlgorithm, ReadOnlySpan{byte})"/>) or only a public
/// key (via <see cref="ImportMLDsaPublicKey(MLDsaAlgorithm, ReadOnlySpan{byte})"/>). Keys generated
/// from a seed retain the 32-byte seed ξ, the compact storage form; keys imported from an expanded
/// private key cannot export a seed. Private key material is zeroed when the instance is disposed.
/// </para>
/// <para>
/// The FIPS 204 pre-hash variants (<c>SignPreHash</c>/<c>VerifyPreHash</c>), external-μ signing
/// (<c>SignMu</c>/<c>VerifyMu</c>), and the PKCS#8/SPKI/PEM key formats are deliberately not
/// implemented yet — they are planned as one batch once the post-quantum algorithm set is
/// complete, so that ML-KEM and ML-DSA gain them together.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var signer = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa65);
/// byte[] publicKey = signer.ExportMLDsaPublicKey();
/// byte[] signature = signer.SignData(message);
///
/// using var verifier = MLDsa.ImportMLDsaPublicKey(MLDsaAlgorithm.MLDsa65, publicKey);
/// bool valid = verifier.VerifyData(message, signature);
/// </code>
/// </para>
/// </remarks>
public sealed partial class MLDsa : IDisposable
{
    private readonly byte[]? _seed;
    private readonly byte[]? _secretKey;
    private readonly byte[] _publicKey;
    private bool _disposed;

    private MLDsa(MLDsaAlgorithm algorithm, byte[]? seed, byte[]? secretKey, byte[] publicKey)
    {
        Algorithm = algorithm;
        _seed = seed;
        _secretKey = secretKey;
        _publicKey = publicKey;
    }

    /// <summary>
    /// Gets a value indicating whether ML-DSA is supported on the current platform.
    /// </summary>
    /// <remarks>
    /// Always <see langword="true"/>. This is a fully managed implementation, so unlike
    /// <c>System.Security.Cryptography.MLDsa.IsSupported</c> it never depends on the
    /// operating system providing ML-DSA.
    /// </remarks>
    public static bool IsSupported => true;

    /// <summary>
    /// Gets the ML-DSA parameter set of this key.
    /// </summary>
    public MLDsaAlgorithm Algorithm { get; }

    /// <summary>
    /// Generates a new ML-DSA key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set to generate a key for.</param>
    /// <returns>A new instance holding the generated key pair and its private seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static MLDsa GenerateKey(MLDsaAlgorithm algorithm)
        => GenerateKey(algorithm, pairwiseConsistencyTest: true);

    /// <summary>
    /// Generates a new ML-DSA key pair, optionally skipping the pairwise consistency test.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The pairwise consistency test verifies a freshly expanded key pair by signing and
    /// verifying one message, as FIPS 140-3 IG 10.3.A expects of a validated module. It is
    /// the dominant cost of key generation, because a sign is itself a rejection loop that
    /// runs several iterations on average.
    /// </para>
    /// <para>
    /// It guards against a <i>fault</i> — bad memory, a bit flip, a miscompiled build —
    /// producing a key pair that does not round-trip. It cannot catch an implementation bug,
    /// since both halves of the test would be wrong in the same way. Disable it only where
    /// that trade is understood and key generation throughput actually matters; the default
    /// on the BCL-shaped overloads keeps it enabled.
    /// </para>
    /// </remarks>
    /// <param name="algorithm">The parameter set to generate a key for.</param>
    /// <param name="pairwiseConsistencyTest">
    /// <see langword="true"/> to verify the generated key pair with a sign/verify round trip;
    /// <see langword="false"/> to skip it.
    /// </param>
    /// <returns>A new instance holding the generated key pair and its private seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static MLDsa GenerateKey(MLDsaAlgorithm algorithm, bool pairwiseConsistencyTest)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));

        byte[] seed = new byte[MLDsaParams.KeyGenSeedBytes];
        MLDsaCore.GenerateRandomSeed(seed);
        return FromSeed(algorithm, seed, pairwiseConsistencyTest);
    }

    /// <summary>
    /// Imports an ML-DSA private seed ξ and expands it into a key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 32-byte private seed.</param>
    /// <returns>A new instance holding the key pair and the seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static MLDsa ImportMLDsaPrivateSeed(MLDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
        => ImportMLDsaPrivateSeed(algorithm, source, pairwiseConsistencyTest: true);

    /// <summary>
    /// Imports an ML-DSA private seed ξ and expands it into a key pair, optionally skipping
    /// the pairwise consistency test.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The pairwise consistency test verifies a freshly expanded key pair by signing and
    /// verifying one message, as FIPS 140-3 IG 10.3.A expects of a validated module. It is
    /// the dominant cost of key generation, because a sign is itself a rejection loop that
    /// runs several iterations on average.
    /// </para>
    /// <para>
    /// It guards against a <i>fault</i> — bad memory, a bit flip, a miscompiled build —
    /// producing a key pair that does not round-trip. It cannot catch an implementation bug,
    /// since both halves of the test would be wrong in the same way. Disable it only where
    /// that trade is understood and key generation throughput actually matters; the default
    /// on the BCL-shaped overloads keeps it enabled.
    /// </para>
    /// </remarks>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 32-byte private seed.</param>
    /// <param name="pairwiseConsistencyTest">
    /// <see langword="true"/> to verify the expanded key pair; <see langword="false"/> to skip it.
    /// </param>
    /// <returns>A new instance holding the key pair and the seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static MLDsa ImportMLDsaPrivateSeed(MLDsaAlgorithm algorithm, ReadOnlySpan<byte> source,
                                               bool pairwiseConsistencyTest)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != MLDsaParams.KeyGenSeedBytes)
            throw new ArgumentException($"Private seed must be exactly {MLDsaParams.KeyGenSeedBytes} bytes.", nameof(source));

        return FromSeed(algorithm, source.ToArray(), pairwiseConsistencyTest);
    }

    /// <summary>
    /// Imports an ML-DSA private seed ξ and expands it into a key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 32-byte private seed.</param>
    /// <returns>A new instance holding the key pair and the seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> or <paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static MLDsa ImportMLDsaPrivateSeed(MLDsaAlgorithm algorithm, byte[] source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return ImportMLDsaPrivateSeed(algorithm, new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Imports an expanded ML-DSA private key.
    /// </summary>
    /// <remarks>
    /// A key imported this way holds no private seed, so <see cref="ExportMLDsaPrivateSeed()"/>
    /// is unavailable. The public key is reconstructed from the private key and validated
    /// against the embedded hash tr = H(pk); a mismatch rejects the import.
    /// </remarks>
    /// <exception cref="OS.CryptographicException">The embedded public key hash does not match the reconstructed public key.</exception>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The expanded private key.</param>
    /// <returns>A new instance holding the key pair.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static MLDsa ImportMLDsaPrivateKey(MLDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.PrivateKeySizeInBytes)
            throw new ArgumentException($"Private key must be exactly {algorithm.PrivateKeySizeInBytes} bytes.", nameof(source));

        // The expanded private key does not embed the public key, only tr = H(pk).
        // Reconstruct pk from (ρ, s1, s2): t = A·s1 + s2, t1 = Power2Round high bits.
        byte[] publicKey = ReconstructPublicKey(algorithm.Parameters, source);
        return new MLDsa(algorithm, seed: null, source.ToArray(), publicKey);
    }

    /// <summary>
    /// Imports an expanded ML-DSA private key.
    /// </summary>
    /// <remarks>
    /// A key imported this way holds no private seed, so <see cref="ExportMLDsaPrivateSeed()"/>
    /// is unavailable. The public key is reconstructed from the private key and validated
    /// against the embedded hash tr = H(pk); a mismatch rejects the import.
    /// </remarks>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The expanded private key.</param>
    /// <returns>A new instance holding the key pair.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> or <paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The embedded public key hash does not match the reconstructed public key.</exception>
    public static MLDsa ImportMLDsaPrivateKey(MLDsaAlgorithm algorithm, byte[] source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return ImportMLDsaPrivateKey(algorithm, new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Imports an ML-DSA public key.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The public key.</param>
    /// <returns>A new instance holding only the public key; it can verify but not sign.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static MLDsa ImportMLDsaPublicKey(MLDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.PublicKeySizeInBytes)
            throw new ArgumentException($"Public key must be exactly {algorithm.PublicKeySizeInBytes} bytes.", nameof(source));

        return new MLDsa(algorithm, seed: null, secretKey: null, source.ToArray());
    }

    /// <summary>
    /// Imports an ML-DSA public key.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The public key.</param>
    /// <returns>A new instance holding only the public key; it can verify but not sign.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> or <paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static MLDsa ImportMLDsaPublicKey(MLDsaAlgorithm algorithm, byte[] source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return ImportMLDsaPublicKey(algorithm, new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Signs data using the hedged (randomized) variant of ML-DSA.
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="context">The optional context string (at most 255 bytes).</param>
    /// <returns>The signature.</returns>
    /// <exception cref="ArgumentException"><paramref name="context"/> is longer than 255 bytes.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public byte[] SignData(ReadOnlySpan<byte> data, ReadOnlySpan<byte> context = default)
    {
        byte[] signature = new byte[Algorithm.SignatureSizeInBytes];
        SignData(data, signature, context);
        return signature;
    }

    /// <summary>
    /// Signs data using the hedged (randomized) variant of ML-DSA.
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="context">The optional context string (at most 255 bytes), or <see langword="null"/>.</param>
    /// <returns>The signature.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="data"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="context"/> is longer than 255 bytes.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public byte[] SignData(byte[] data, byte[]? context = null)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));

        return SignData(new ReadOnlySpan<byte>(data), new ReadOnlySpan<byte>(context));
    }

    /// <summary>
    /// Signs data into a caller-provided buffer using the hedged (randomized) variant of ML-DSA.
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="destination">The buffer to receive the signature; must be exactly <see cref="MLDsaAlgorithm.SignatureSizeInBytes"/> bytes.</param>
    /// <param name="context">The optional context string (at most 255 bytes).</param>
    /// <exception cref="ArgumentException">A parameter has an invalid size.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public void SignData(ReadOnlySpan<byte> data, Span<byte> destination, ReadOnlySpan<byte> context = default)
    {
        ThrowIfDisposed();
        if (_secretKey is null)
            throw new OS.CryptographicException("The instance holds only a public key and cannot sign.");
        if (destination.Length != Algorithm.SignatureSizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.SignatureSizeInBytes} bytes.", nameof(destination));

        MLDsaEngine.Sign(Algorithm.Parameters, _secretKey, data, context, deterministic: false, destination);
    }

    /// <summary>
    /// Verifies a signature over data.
    /// </summary>
    /// <param name="data">The signed data.</param>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="context">The context string used when signing (at most 255 bytes).</param>
    /// <returns>True when the signature is valid; false for invalid signatures, including malformed lengths.</returns>
    /// <exception cref="ArgumentException"><paramref name="context"/> is longer than 255 bytes.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public bool VerifyData(ReadOnlySpan<byte> data, ReadOnlySpan<byte> signature, ReadOnlySpan<byte> context = default)
    {
        ThrowIfDisposed();
        if (context.Length > MLDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {MLDsaParams.MaxContextBytes} bytes.", nameof(context));

        if (signature.Length != Algorithm.SignatureSizeInBytes)
        {
            return false;
        }

        return MLDsaEngine.Verify(Algorithm.Parameters, _publicKey, data, context, signature);
    }

    /// <summary>
    /// Verifies a signature over data.
    /// </summary>
    /// <param name="data">The signed data.</param>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="context">The context string used when signing (at most 255 bytes), or <see langword="null"/>.</param>
    /// <returns>True when the signature is valid; false for invalid signatures, including malformed lengths.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="data"/> or <paramref name="signature"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="context"/> is longer than 255 bytes.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public bool VerifyData(byte[] data, byte[] signature, byte[]? context = null)
    {
        if (data is null)
            throw new ArgumentNullException(nameof(data));
        if (signature is null)
            throw new ArgumentNullException(nameof(signature));

        return VerifyData(new ReadOnlySpan<byte>(data), new ReadOnlySpan<byte>(signature),
                          new ReadOnlySpan<byte>(context));
    }

    /// <summary>
    /// Signs a pre-computed message digest using HashML-DSA (FIPS 204 §5.4).
    /// </summary>
    /// <remarks>
    /// The caller computes PH(M) with an approved hash or XOF and passes the digest with its
    /// OID; the signature binds the pre-hash function via M′ = 0x01 ‖ |ctx| ‖ ctx ‖ OID ‖ PH(M).
    /// Pre-hash signatures are never interchangeable with pure ML-DSA signatures over the same
    /// message.
    /// </remarks>
    /// <param name="hash">The pre-computed digest PH(M).</param>
    /// <param name="hashAlgorithmOid">The dotted-decimal OID of the pre-hash function, e.g. <c>2.16.840.1.101.3.4.2.3</c> for SHA-512.</param>
    /// <param name="context">The optional context string (at most 255 bytes), or <see langword="null"/>.</param>
    /// <returns>The signature.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="hash"/> or <paramref name="hashAlgorithmOid"/> is null.</exception>
    /// <exception cref="ArgumentException">The OID is not approved, the digest length does not match it, or <paramref name="context"/> is longer than 255 bytes.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public byte[] SignPreHash(byte[] hash, string hashAlgorithmOid, byte[]? context = null)
    {
        if (hash is null)
            throw new ArgumentNullException(nameof(hash));

        byte[] signature = new byte[Algorithm.SignatureSizeInBytes];
        SignPreHash(new ReadOnlySpan<byte>(hash), new Span<byte>(signature), hashAlgorithmOid,
                    new ReadOnlySpan<byte>(context));
        return signature;
    }

    /// <summary>
    /// Signs a pre-computed message digest into a caller-provided buffer using HashML-DSA
    /// (FIPS 204 §5.4).
    /// </summary>
    /// <remarks>
    /// Note the parameter order, which this type inherits from the in-box <c>MLDsa</c>: the
    /// <i>second</i> parameter is the destination buffer, whereas on <see cref="SignData(byte[], byte[])"/>
    /// the second parameter is the context. Call sites that pass arrays should spell out
    /// <c>new ReadOnlySpan&lt;byte&gt;(…)</c> and <c>new Span&lt;byte&gt;(…)</c> so the intended
    /// overload is unambiguous.
    /// </remarks>
    /// <param name="hash">The pre-computed digest PH(M).</param>
    /// <param name="destination">The buffer to receive the signature; must be exactly <see cref="MLDsaAlgorithm.SignatureSizeInBytes"/> bytes.</param>
    /// <param name="hashAlgorithmOid">The dotted-decimal OID of the pre-hash function.</param>
    /// <param name="context">The optional context string (at most 255 bytes).</param>
    /// <exception cref="ArgumentNullException"><paramref name="hashAlgorithmOid"/> is null.</exception>
    /// <exception cref="ArgumentException">A parameter has an invalid size, or the OID is not an approved pre-hash function.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public void SignPreHash(ReadOnlySpan<byte> hash, Span<byte> destination, string hashAlgorithmOid,
                            ReadOnlySpan<byte> context = default)
    {
        ThrowIfDisposed();
        if (_secretKey is null)
            throw new OS.CryptographicException("The instance holds only a public key and cannot sign.");
        if (destination.Length != Algorithm.SignatureSizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.SignatureSizeInBytes} bytes.", nameof(destination));
        if (context.Length > MLDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {MLDsaParams.MaxContextBytes} bytes.", nameof(context));
        PreHash.ValidateHash(hashAlgorithmOid, hash.Length);

        Span<byte> prefix = stackalloc byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(context, hashAlgorithmOid, prefix);

        Span<byte> rnd = stackalloc byte[MLDsaParams.SignSeedBytes];
        MLDsaCore.GenerateRandomSeed(rnd);

        MLDsaCore.Sign(Algorithm.Parameters, _secretKey, prefix.Slice(0, prefixLength), hash, rnd, destination);
        CryptographicOperations.ZeroMemory(rnd);
    }

    /// <summary>
    /// Verifies a HashML-DSA signature over a pre-computed message digest (FIPS 204 §5.4).
    /// </summary>
    /// <param name="hash">The pre-computed digest PH(M).</param>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="hashAlgorithmOid">The dotted-decimal OID of the pre-hash function used when signing.</param>
    /// <param name="context">The context string used when signing (at most 255 bytes), or <see langword="null"/>.</param>
    /// <returns>True when the signature is valid; false for invalid signatures, including malformed lengths.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="hash"/>, <paramref name="signature"/> or <paramref name="hashAlgorithmOid"/> is null.</exception>
    /// <exception cref="ArgumentException">The OID is not approved, the digest length does not match it, or <paramref name="context"/> is longer than 255 bytes.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public bool VerifyPreHash(byte[] hash, byte[] signature, string hashAlgorithmOid, byte[]? context = null)
    {
        if (hash is null)
            throw new ArgumentNullException(nameof(hash));
        if (signature is null)
            throw new ArgumentNullException(nameof(signature));

        return VerifyPreHash(new ReadOnlySpan<byte>(hash), new ReadOnlySpan<byte>(signature),
                             hashAlgorithmOid, new ReadOnlySpan<byte>(context));
    }

    /// <summary>
    /// Verifies a HashML-DSA signature over a pre-computed message digest (FIPS 204 §5.4).
    /// </summary>
    /// <param name="hash">The pre-computed digest PH(M).</param>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="hashAlgorithmOid">The dotted-decimal OID of the pre-hash function used when signing.</param>
    /// <param name="context">The context string used when signing (at most 255 bytes).</param>
    /// <returns>True when the signature is valid; false for invalid signatures, including malformed lengths.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="hashAlgorithmOid"/> is null.</exception>
    /// <exception cref="ArgumentException">The OID is not approved, the digest length does not match it, or <paramref name="context"/> is longer than 255 bytes.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public bool VerifyPreHash(ReadOnlySpan<byte> hash, ReadOnlySpan<byte> signature, string hashAlgorithmOid,
                              ReadOnlySpan<byte> context = default)
    {
        ThrowIfDisposed();
        if (context.Length > MLDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {MLDsaParams.MaxContextBytes} bytes.", nameof(context));
        PreHash.ValidateHash(hashAlgorithmOid, hash.Length);

        if (signature.Length != Algorithm.SignatureSizeInBytes)
        {
            return false;
        }

        Span<byte> prefix = stackalloc byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(context, hashAlgorithmOid, prefix);

        return MLDsaCore.Verify(Algorithm.Parameters, _publicKey, prefix.Slice(0, prefixLength), hash, signature);
    }

    /// <summary>
    /// Exports the 32-byte private seed ξ.
    /// </summary>
    /// <returns>The private seed.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The key was not created from a seed.</exception>
    public byte[] ExportMLDsaPrivateSeed()
    {
        byte[] destination = new byte[MLDsaParams.KeyGenSeedBytes];
        ExportMLDsaPrivateSeed(destination);
        return destination;
    }

    /// <summary>
    /// Exports the 32-byte private seed ξ into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the seed; must be exactly <see cref="MLDsaAlgorithm.PrivateSeedSizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The key was not created from a seed.</exception>
    public void ExportMLDsaPrivateSeed(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (_seed is null)
            throw new OS.CryptographicException("The key was not created from a private seed.");
        if (destination.Length != MLDsaParams.KeyGenSeedBytes)
            throw new ArgumentException($"Destination must be exactly {MLDsaParams.KeyGenSeedBytes} bytes.", nameof(destination));

        _seed.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Exports the public key.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] ExportMLDsaPublicKey()
    {
        byte[] destination = new byte[Algorithm.PublicKeySizeInBytes];
        ExportMLDsaPublicKey(destination);
        return destination;
    }

    /// <summary>
    /// Exports the public key into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="MLDsaAlgorithm.PublicKeySizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void ExportMLDsaPublicKey(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (destination.Length != Algorithm.PublicKeySizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.PublicKeySizeInBytes} bytes.", nameof(destination));

        _publicKey.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Exports the expanded private key.
    /// </summary>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public byte[] ExportMLDsaPrivateKey()
    {
        byte[] destination = new byte[Algorithm.PrivateKeySizeInBytes];
        ExportMLDsaPrivateKey(destination);
        return destination;
    }

    /// <summary>
    /// Exports the expanded private key into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="MLDsaAlgorithm.PrivateKeySizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public void ExportMLDsaPrivateKey(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (_secretKey is null)
            throw new OS.CryptographicException("The instance holds only a public key.");
        if (destination.Length != Algorithm.PrivateKeySizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.PrivateKeySizeInBytes} bytes.", nameof(destination));

        _secretKey.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Zeroizes the private seed and private key and releases the instance.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        if (_seed is not null)
        {
            CryptographicOperations.ZeroMemory(_seed);
        }

        if (_secretKey is not null)
        {
            CryptographicOperations.ZeroMemory(_secretKey);
        }
    }

    private static MLDsa FromSeed(MLDsaAlgorithm algorithm, byte[] seed, bool pairwiseConsistencyTest)
    {
        byte[] publicKey = new byte[algorithm.PublicKeySizeInBytes];
        byte[] secretKey = new byte[algorithm.PrivateKeySizeInBytes];
        MLDsaCore.KeyGen(algorithm.Parameters, seed, publicKey, secretKey, pairwiseConsistencyTest);
        return new MLDsa(algorithm, seed, secretKey, publicKey);
    }

    private static byte[] ReconstructPublicKey(MLDsaParams p, ReadOnlySpan<byte> sk)
    {
        Span<byte> rho = stackalloc byte[32];
        Span<byte> key = stackalloc byte[32];
        Span<byte> tr = stackalloc byte[64];
        int[][] s1 = PolyVec.Create(p.L);
        int[][] s2 = PolyVec.Create(p.K);
        int[][] t0 = PolyVec.Create(p.K);
        Encode.SkDecode(p, sk, rho, key, tr, s1, s2, t0);

        int[][][] matrix = Sampling.ExpandA(p, rho);
        PolyVec.Ntt(s1);

        int[][] t = PolyVec.Create(p.K);
        PolyVec.MatrixPointwiseMontgomery(t, matrix, s1);
        PolyVec.Reduce(t);
        PolyVec.InverseNtt(t);
        PolyVec.Add(t, t, s2);
        PolyVec.ConditionalAddQ(t);

        int[][] t1 = PolyVec.Create(p.K);
        int[][] discardedT0 = PolyVec.Create(p.K);
        for (int i = 0; i < p.K; i++)
        {
            Poly.Power2Round(t1[i], discardedT0[i], t[i]);
        }

        byte[] publicKey = new byte[p.PublicKeyBytes];
        Encode.PkEncode(p, rho, t1, publicKey);

        // The reconstructed pk must hash to the tr stored in the private key.
        Span<byte> computedTr = stackalloc byte[64];
        using (var shake = Hash.Shake256.Create(64))
        {
            shake.Absorb(publicKey);
            shake.Squeeze(computedTr);
        }

        bool valid = CryptographicOperations.FixedTimeEquals(computedTr, tr);

        CryptographicOperations.ZeroMemory(key);
        MLDsaCore.Zero(s1);
        MLDsaCore.Zero(s2);
        MLDsaCore.Zero(t0);
        MLDsaCore.Zero(discardedT0);
        MLDsaCore.Zero(t);

        if (!valid)
        {
            throw new OS.CryptographicException("Private key is inconsistent: the embedded public key hash does not match.");
        }

        return publicKey;
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(typeof(MLDsa).FullName);
        }
    }
}
