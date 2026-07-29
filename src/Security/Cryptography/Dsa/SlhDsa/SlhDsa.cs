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
/// An instance holds either a full key pair (via <see cref="GenerateKey"/> or
/// <see cref="ImportSecretKey"/>) or only a public key (via <see cref="ImportPublicKey"/>).
/// The 4n-byte secret key is itself the compact storage form (SK.seed ‖ SK.prf ‖ PK.seed ‖
/// PK.root); there is no separate private seed. Secret key material is zeroed when the
/// instance is disposed.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var signer = SlhDsa.GenerateKey(SlhDsaAlgorithm.SlhDsaShake128f);
/// byte[] publicKey = signer.ExportPublicKey();
/// byte[] signature = signer.SignData(message);
///
/// using var verifier = SlhDsa.ImportPublicKey(SlhDsaAlgorithm.SlhDsaShake128f, publicKey);
/// bool valid = verifier.VerifyData(message, signature);
/// </code>
/// </para>
/// </remarks>
public sealed class SlhDsa : IDisposable
{
    private readonly byte[]? _secretKey;
    private readonly byte[] _publicKey;
    private bool _disposed;

    private SlhDsa(SlhDsaAlgorithm algorithm, byte[]? secretKey, byte[] publicKey)
    {
        Algorithm = algorithm;
        _secretKey = secretKey;
        _publicKey = publicKey;
    }

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
    public static SlhDsa GenerateKey(SlhDsaAlgorithm algorithm)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));

        byte[] publicKey = new byte[algorithm.PublicKeySizeInBytes];
        byte[] secretKey = new byte[algorithm.SecretKeySizeInBytes];
        SlhDsaCore.KeyGen(algorithm.Parameters, publicKey, secretKey);
        return new SlhDsa(algorithm, secretKey, publicKey);
    }

    /// <summary>
    /// Imports an SLH-DSA secret key.
    /// </summary>
    /// <remarks>
    /// The public key (PK.seed ‖ PK.root) is embedded in the secret key and extracted on
    /// import; no expensive consistency recomputation is performed.
    /// </remarks>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 4n-byte secret key.</param>
    /// <returns>A new instance holding the key pair.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static SlhDsa ImportSecretKey(SlhDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.SecretKeySizeInBytes)
            throw new ArgumentException($"Secret key must be exactly {algorithm.SecretKeySizeInBytes} bytes.", nameof(source));

        int n = algorithm.Parameters.N;
        byte[] publicKey = source.Slice(2 * n, 2 * n).ToArray();
        return new SlhDsa(algorithm, source.ToArray(), publicKey);
    }

    /// <summary>
    /// Imports an SLH-DSA public key.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 2n-byte public key.</param>
    /// <returns>A new instance holding only the public key; it can verify but not sign.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static SlhDsa ImportPublicKey(SlhDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.PublicKeySizeInBytes)
            throw new ArgumentException($"Public key must be exactly {algorithm.PublicKeySizeInBytes} bytes.", nameof(source));

        return new SlhDsa(algorithm, secretKey: null, source.ToArray());
    }

    /// <summary>
    /// Signs data using the hedged (randomized) variant of SLH-DSA.
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="context">The optional context string (at most 255 bytes).</param>
    /// <returns>The signature.</returns>
    /// <exception cref="ArgumentException"><paramref name="context"/> is longer than 255 bytes.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no secret key.</exception>
    public byte[] SignData(ReadOnlySpan<byte> data, ReadOnlySpan<byte> context = default)
    {
        byte[] signature = new byte[Algorithm.SignatureSizeInBytes];
        SignData(data, signature, context);
        return signature;
    }

    /// <summary>
    /// Signs data into a caller-provided buffer using the hedged (randomized) variant of SLH-DSA.
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="destination">The buffer to receive the signature; must be exactly <see cref="SlhDsaAlgorithm.SignatureSizeInBytes"/> bytes.</param>
    /// <param name="context">The optional context string (at most 255 bytes).</param>
    /// <exception cref="ArgumentException">A parameter has an invalid size.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no secret key.</exception>
    public void SignData(ReadOnlySpan<byte> data, Span<byte> destination, ReadOnlySpan<byte> context = default)
    {
        ThrowIfDisposed();
        if (_secretKey is null)
            throw new OS.CryptographicException("The instance holds only a public key and cannot sign.");
        if (context.Length > SlhDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {SlhDsaParams.MaxContextBytes} bytes.", nameof(context));
        if (destination.Length != Algorithm.SignatureSizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.SignatureSizeInBytes} bytes.", nameof(destination));

        Span<byte> prefix = stackalloc byte[2 + SlhDsaParams.MaxContextBytes];
        int prefixLength = MlDsaCore.BuildExternalPrefix(context, prefix);

        Span<byte> optRand = stackalloc byte[32];
        Span<byte> rand = optRand.Slice(0, Algorithm.Parameters.N);
        MlDsaCore.GenerateRandomSeed(rand);

        SlhDsaCore.Sign(Algorithm.Parameters, _secretKey, prefix.Slice(0, prefixLength), data, rand, destination);
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
        int prefixLength = MlDsaCore.BuildExternalPrefix(context, prefix);

        return SlhDsaCore.Verify(Algorithm.Parameters, _publicKey, prefix.Slice(0, prefixLength), data, signature);
    }

    /// <summary>
    /// Exports the public key (PK.seed ‖ PK.root).
    /// </summary>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] ExportPublicKey()
    {
        byte[] destination = new byte[Algorithm.PublicKeySizeInBytes];
        ExportPublicKey(destination);
        return destination;
    }

    /// <summary>
    /// Exports the public key into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="SlhDsaAlgorithm.PublicKeySizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void ExportPublicKey(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (destination.Length != Algorithm.PublicKeySizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.PublicKeySizeInBytes} bytes.", nameof(destination));

        _publicKey.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Exports the secret key (SK.seed ‖ SK.prf ‖ PK.seed ‖ PK.root).
    /// </summary>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no secret key.</exception>
    public byte[] ExportSecretKey()
    {
        byte[] destination = new byte[Algorithm.SecretKeySizeInBytes];
        ExportSecretKey(destination);
        return destination;
    }

    /// <summary>
    /// Exports the secret key into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="SlhDsaAlgorithm.SecretKeySizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no secret key.</exception>
    public void ExportSecretKey(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (_secretKey is null)
            throw new OS.CryptographicException("The instance holds only a public key.");
        if (destination.Length != Algorithm.SecretKeySizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.SecretKeySizeInBytes} bytes.", nameof(destination));

        _secretKey.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Zeroizes the secret key and releases the instance.
    /// </summary>
    public void Dispose()
    {
        if (_disposed)
        {
            return;
        }

        _disposed = true;
        if (_secretKey is not null)
        {
            CryptographicOperations.ZeroMemory(_secretKey);
        }
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(SlhDsa));
        }
    }
}
