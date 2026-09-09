// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;
using OS = System.Security.Cryptography;

/// <summary>
/// Represents an SLH-DSA key (FIPS 205) and provides signing and verification.
/// </summary>
/// <remarks>
/// <para>
/// The API shape mirrors <c>System.Security.Cryptography.SlhDsa</c> from .NET 10 so code
/// written against the in-box type ports directly to older target frameworks, including
/// .NET Framework and .NET Standard 2.0.
/// </para>
/// <para>
/// SLH-DSA is a stateless hash-based signature scheme: its security rests only on the
/// underlying hash functions, making it the conservative choice for long-lived keys
/// (roots of trust, firmware and code signing). Signing is expensive by design —
/// prefer the <c>f</c> (fast) parameter sets unless minimal signature size matters more
/// than signing time; verification is fast for all sets.
/// </para>
/// <para>
/// An instance holds either a full key pair (via <see cref="GenerateKey(SlhDsaAlgorithm)"/> or
/// <see cref="ImportSlhDsaPrivateKey(SlhDsaAlgorithm, ReadOnlySpan{byte})"/>) or only a public
/// key (via <see cref="ImportSlhDsaPublicKey(SlhDsaAlgorithm, ReadOnlySpan{byte})"/>).
/// The 4n-byte private key is itself the compact storage form (SK.seed ‖ SK.prf ‖ PK.seed ‖
/// PK.root); there is no separate private seed. Private key material is zeroed when the
/// instance is disposed.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var signer = SlhDsa.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);
/// byte[] publicKey = signer.ExportSlhDsaPublicKey();
/// byte[] signature = signer.SignData(message);
///
/// using var verifier = SlhDsa.ImportSlhDsaPublicKey(SlhDsaAlgorithm.SlhDsaShake128f, publicKey);
/// bool valid = verifier.VerifyData(message, signature);
/// </code>
/// </para>
/// </remarks>
public sealed class SlhDsa : IDisposable
{
    private readonly byte[]? _privateKey;
    private readonly byte[] _publicKey;
    private bool _disposed;

    private SlhDsa(SlhDsaAlgorithm algorithm, byte[]? privateKey, byte[] publicKey)
    {
        Algorithm = algorithm;
        _privateKey = privateKey;
        _publicKey = publicKey;
    }

    /// <summary>
    /// Gets a value indicating whether SLH-DSA is supported on the current platform.
    /// </summary>
    /// <remarks>
    /// Always <see langword="true"/>. This is a fully managed implementation, so unlike
    /// <c>System.Security.Cryptography.SlhDsa.IsSupported</c> it never depends on the
    /// operating system providing SLH-DSA.
    /// </remarks>
    public static bool IsSupported => true;

    /// <summary>
    /// Gets the SLH-DSA parameter set of this key.
    /// </summary>
    public SlhDsaAlgorithm Algorithm { get; }

    /// <summary>
    /// Generates a new SLH-DSA key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set to generate a key for.</param>
    /// <returns>A new instance holding the generated key pair.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static SlhDsa GenerateKey(SlhDsaAlgorithm algorithm)
        => GenerateKey(algorithm, pairwiseConsistencyTest: true);

    /// <summary>
    /// Generates a new SLH-DSA key pair, optionally skipping the pairwise consistency test.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The pairwise consistency test verifies a freshly generated key pair by signing and
    /// verifying one message, as FIPS 140-3 IG 10.3.A expects of a validated module.
    /// </para>
    /// <para>
    /// It is disproportionately expensive for SLH-DSA. A signature is on the order of 10⁶
    /// hash invocations for the <c>s</c> parameter sets, so the check does not merely add to
    /// key generation — it costs orders of magnitude more than generating the key did.
    /// </para>
    /// <para>
    /// It guards against a <i>fault</i> — bad memory, a bit flip, a miscompiled build —
    /// producing a key pair that does not round-trip. It cannot catch an implementation bug,
    /// since both halves of the test would be wrong in the same way. Disable it only where
    /// that trade is understood and key generation throughput actually matters; the default
    /// on the BCL-shaped overload keeps it enabled.
    /// </para>
    /// </remarks>
    /// <param name="algorithm">The parameter set to generate a key for.</param>
    /// <param name="pairwiseConsistencyTest">
    /// <see langword="true"/> to verify the generated key pair with a sign/verify round trip;
    /// <see langword="false"/> to skip it.
    /// </param>
    /// <returns>A new instance holding the generated key pair.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static SlhDsa GenerateKey(SlhDsaAlgorithm algorithm, bool pairwiseConsistencyTest)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));

        byte[] publicKey = new byte[algorithm.PublicKeySizeInBytes];
        byte[] privateKey = new byte[algorithm.PrivateKeySizeInBytes];
        SlhDsaCore.KeyGen(algorithm.Parameters, publicKey, privateKey, pairwiseConsistencyTest);
        return new SlhDsa(algorithm, privateKey, publicKey);
    }

    /// <summary>
    /// Imports an SLH-DSA private key in the FIPS 205 private key format.
    /// </summary>
    /// <remarks>
    /// The public key (PK.seed ‖ PK.root) is embedded in the private key and extracted on
    /// import; no expensive consistency recomputation is performed.
    /// </remarks>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 4n-byte private key.</param>
    /// <returns>A new instance holding the key pair.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static SlhDsa ImportSlhDsaPrivateKey(SlhDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.PrivateKeySizeInBytes)
            throw new ArgumentException($"Private key must be exactly {algorithm.PrivateKeySizeInBytes} bytes.", nameof(source));

        int n = algorithm.Parameters.N;
        byte[] publicKey = source.Slice(2 * n, 2 * n).ToArray();
        return new SlhDsa(algorithm, source.ToArray(), publicKey);
    }

    /// <summary>
    /// Imports an SLH-DSA private key in the FIPS 205 private key format.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 4n-byte private key.</param>
    /// <returns>A new instance holding the key pair.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> or <paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static SlhDsa ImportSlhDsaPrivateKey(SlhDsaAlgorithm algorithm, byte[] source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return ImportSlhDsaPrivateKey(algorithm, new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Imports an SLH-DSA public key in the FIPS 205 public key format.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 2n-byte public key.</param>
    /// <returns>A new instance holding only the public key; it can verify but not sign.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static SlhDsa ImportSlhDsaPublicKey(SlhDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.PublicKeySizeInBytes)
            throw new ArgumentException($"Public key must be exactly {algorithm.PublicKeySizeInBytes} bytes.", nameof(source));

        return new SlhDsa(algorithm, privateKey: null, source.ToArray());
    }

    /// <summary>
    /// Imports an SLH-DSA public key in the FIPS 205 public key format.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 2n-byte public key.</param>
    /// <returns>A new instance holding only the public key; it can verify but not sign.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> or <paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static SlhDsa ImportSlhDsaPublicKey(SlhDsaAlgorithm algorithm, byte[] source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return ImportSlhDsaPublicKey(algorithm, new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Signs data using the hedged (randomized) variant of SLH-DSA.
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
    /// Signs data using the hedged (randomized) variant of SLH-DSA.
    /// </summary>
    /// <remarks>
    /// Mirrors the in-box overload, and inherits its shape: the second parameter is the
    /// <b>context</b>, not a destination buffer. Callers holding a pre-allocated signature
    /// buffer want the span overload and must say so explicitly — passing two arrays binds
    /// here and silently treats the signature buffer as a context string.
    /// </remarks>
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
    /// Signs data into a caller-provided buffer using the hedged (randomized) variant of SLH-DSA.
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="destination">The buffer to receive the signature; must be exactly <see cref="SlhDsaAlgorithm.SignatureSizeInBytes"/> bytes.</param>
    /// <param name="context">The optional context string (at most 255 bytes).</param>
    /// <exception cref="ArgumentException">A parameter has an invalid size.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public void SignData(ReadOnlySpan<byte> data, Span<byte> destination, ReadOnlySpan<byte> context = default)
    {
        ThrowIfDisposed();
        if (_privateKey is null)
            throw new OS.CryptographicException("The instance holds only a public key and cannot sign.");
        if (context.Length > SlhDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {SlhDsaParams.MaxContextBytes} bytes.", nameof(context));
        if (destination.Length != Algorithm.SignatureSizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.SignatureSizeInBytes} bytes.", nameof(destination));

        Span<byte> prefix = stackalloc byte[2 + SlhDsaParams.MaxContextBytes];
        int prefixLength = MLDsaCore.BuildExternalPrefix(context, prefix);

        Span<byte> optRand = stackalloc byte[32];
        Span<byte> rand = optRand.Slice(0, Algorithm.Parameters.N);
        MLDsaCore.GenerateRandomSeed(rand);

        SlhDsaCore.Sign(Algorithm.Parameters, _privateKey, prefix.Slice(0, prefixLength), data, rand, destination);
        CryptographicOperations.ZeroMemory(optRand);
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
        if (context.Length > SlhDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {SlhDsaParams.MaxContextBytes} bytes.", nameof(context));

        if (signature.Length != Algorithm.SignatureSizeInBytes)
        {
            return false;
        }

        Span<byte> prefix = stackalloc byte[2 + SlhDsaParams.MaxContextBytes];
        int prefixLength = MLDsaCore.BuildExternalPrefix(context, prefix);

        return SlhDsaCore.Verify(Algorithm.Parameters, _publicKey, prefix.Slice(0, prefixLength), data, signature);
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
    /// Signs a pre-computed message digest using HashSLH-DSA (FIPS 205 §10.2).
    /// </summary>
    /// <remarks>
    /// The caller computes PH(M) with an approved hash or XOF and passes the digest with its
    /// OID; the signature binds the pre-hash function via M′ = 0x01 ‖ |ctx| ‖ ctx ‖ OID ‖ PH(M).
    /// Pre-hash signatures are never interchangeable with pure SLH-DSA signatures over the same
    /// message.
    /// </remarks>
    /// <param name="hash">The pre-computed digest PH(M).</param>
    /// <param name="hashAlgorithmOid">The dotted-decimal OID of the pre-hash function, e.g. <c>2.16.840.1.101.3.4.2.1</c> for SHA-256.</param>
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
    /// Signs a pre-computed message digest into a caller-provided buffer using HashSLH-DSA
    /// (FIPS 205 §10.2).
    /// </summary>
    /// <remarks>
    /// Note the parameter order, which this type inherits from the in-box <c>SlhDsa</c>: the
    /// <i>second</i> parameter is the destination buffer, whereas on <see cref="SignData(byte[], byte[])"/>
    /// the second parameter is the context. Call sites that pass arrays should spell out
    /// <c>new ReadOnlySpan&lt;byte&gt;(…)</c> and <c>new Span&lt;byte&gt;(…)</c> so the intended
    /// overload is unambiguous.
    /// </remarks>
    /// <param name="hash">The pre-computed digest PH(M).</param>
    /// <param name="destination">The buffer to receive the signature; must be exactly <see cref="SlhDsaAlgorithm.SignatureSizeInBytes"/> bytes.</param>
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
        if (_privateKey is null)
            throw new OS.CryptographicException("The instance holds only a public key and cannot sign.");
        if (destination.Length != Algorithm.SignatureSizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.SignatureSizeInBytes} bytes.", nameof(destination));
        if (context.Length > SlhDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {SlhDsaParams.MaxContextBytes} bytes.", nameof(context));
        PreHash.ValidateHash(hashAlgorithmOid, hash.Length);

        Span<byte> prefix = stackalloc byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(context, hashAlgorithmOid, prefix);

        Span<byte> optRand = stackalloc byte[32];
        Span<byte> rand = optRand.Slice(0, Algorithm.Parameters.N);
        MLDsaCore.GenerateRandomSeed(rand);

        SlhDsaCore.Sign(Algorithm.Parameters, _privateKey, prefix.Slice(0, prefixLength), hash, rand, destination);
        CryptographicOperations.ZeroMemory(optRand);
    }

    /// <summary>
    /// Verifies a HashSLH-DSA signature over a pre-computed message digest (FIPS 205 §10.2).
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
    /// Verifies a HashSLH-DSA signature over a pre-computed message digest (FIPS 205 §10.2).
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
        if (context.Length > SlhDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {SlhDsaParams.MaxContextBytes} bytes.", nameof(context));
        PreHash.ValidateHash(hashAlgorithmOid, hash.Length);

        if (signature.Length != Algorithm.SignatureSizeInBytes)
        {
            return false;
        }

        Span<byte> prefix = stackalloc byte[PreHash.MaxPrefixBytes];
        int prefixLength = PreHash.BuildPrefix(context, hashAlgorithmOid, prefix);

        return SlhDsaCore.Verify(Algorithm.Parameters, _publicKey, prefix.Slice(0, prefixLength), hash, signature);
    }

    /// <summary>
    /// Exports the public-key portion of the current key in the FIPS 205 public key format
    /// (PK.seed ‖ PK.root).
    /// </summary>
    /// <returns>The public key.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] ExportSlhDsaPublicKey()
    {
        byte[] destination = new byte[Algorithm.PublicKeySizeInBytes];
        ExportSlhDsaPublicKey(destination);
        return destination;
    }

    /// <summary>
    /// Exports the public-key portion of the current key into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="SlhDsaAlgorithm.PublicKeySizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void ExportSlhDsaPublicKey(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (destination.Length != Algorithm.PublicKeySizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.PublicKeySizeInBytes} bytes.", nameof(destination));

        _publicKey.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Exports the current key in the FIPS 205 private key format
    /// (SK.seed ‖ SK.prf ‖ PK.seed ‖ PK.root).
    /// </summary>
    /// <returns>The private key.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public byte[] ExportSlhDsaPrivateKey()
    {
        byte[] destination = new byte[Algorithm.PrivateKeySizeInBytes];
        ExportSlhDsaPrivateKey(destination);
        return destination;
    }

    /// <summary>
    /// Exports the current key in the FIPS 205 private key format into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="SlhDsaAlgorithm.PrivateKeySizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no private key.</exception>
    public void ExportSlhDsaPrivateKey(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (_privateKey is null)
            throw new OS.CryptographicException("The instance holds only a public key.");
        if (destination.Length != Algorithm.PrivateKeySizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.PrivateKeySizeInBytes} bytes.", nameof(destination));

        _privateKey.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Zeroizes the private key and releases the instance.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        if (_privateKey is not null)
        {
            CryptographicOperations.ZeroMemory(_privateKey);
        }
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(typeof(SlhDsa).FullName);
        }
    }
}
