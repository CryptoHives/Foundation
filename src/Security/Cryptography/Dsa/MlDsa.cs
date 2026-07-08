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
/// An instance holds either a full key pair (created via <see cref="GenerateKey"/>,
/// <see cref="ImportPrivateSeed"/>, or <see cref="ImportSecretKey"/>) or only a public
/// key (via <see cref="ImportPublicKey"/>). Keys generated from a seed retain the
/// 32-byte seed ξ, the compact storage form; keys imported from an expanded secret key
/// cannot export a seed. Secret key material is zeroed when the instance is disposed.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var signer = MlDsa.GenerateKey(MlDsaAlgorithm.MlDsa65);
/// byte[] publicKey = signer.ExportPublicKey();
/// byte[] signature = signer.SignData(message);
///
/// using var verifier = MlDsa.ImportPublicKey(MlDsaAlgorithm.MlDsa65, publicKey);
/// bool valid = verifier.VerifyData(message, signature);
/// </code>
/// </para>
/// </remarks>
public sealed class MlDsa : IDisposable
{
    private readonly byte[]? _seed;
    private readonly byte[]? _secretKey;
    private readonly byte[] _publicKey;
    private bool _disposed;

    private MlDsa(MlDsaAlgorithm algorithm, byte[]? seed, byte[]? secretKey, byte[] publicKey)
    {
        Algorithm = algorithm;
        _seed = seed;
        _secretKey = secretKey;
        _publicKey = publicKey;
    }

    /// <summary>
    /// Gets the ML-DSA parameter set of this key.
    /// </summary>
    public MlDsaAlgorithm Algorithm { get; }

    /// <summary>
    /// Generates a new ML-DSA key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set to generate a key for.</param>
    /// <returns>A new instance holding the generated key pair and its private seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    public static MlDsa GenerateKey(MlDsaAlgorithm algorithm)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));

        byte[] seed = new byte[MlDsaParams.KeyGenSeedBytes];
        MlDsaCore.GenerateRandomSeed(seed);
        return FromSeed(algorithm, seed);
    }

    /// <summary>
    /// Imports an ML-DSA private seed ξ and expands it into a key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 32-byte private seed.</param>
    /// <returns>A new instance holding the key pair and the seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static MlDsa ImportPrivateSeed(MlDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != MlDsaParams.KeyGenSeedBytes)
            throw new ArgumentException($"Private seed must be exactly {MlDsaParams.KeyGenSeedBytes} bytes.", nameof(source));

        return FromSeed(algorithm, source.ToArray());
    }

    /// <summary>
    /// Imports an expanded ML-DSA secret key.
    /// </summary>
    /// <remarks>
    /// A key imported this way holds no private seed, so <see cref="ExportPrivateSeed()"/>
    /// is unavailable. The public key is reconstructed from the secret key and validated
    /// against the embedded hash tr = H(pk); a mismatch rejects the import.
    /// </remarks>
    /// <exception cref="OS.CryptographicException">The embedded public key hash does not match the reconstructed public key.</exception>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The expanded secret key.</param>
    /// <returns>A new instance holding the key pair.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static MlDsa ImportSecretKey(MlDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.SecretKeySizeInBytes)
            throw new ArgumentException($"Secret key must be exactly {algorithm.SecretKeySizeInBytes} bytes.", nameof(source));

        // The expanded secret key does not embed the public key, only tr = H(pk).
        // Reconstruct pk from (ρ, s1, s2): t = A·s1 + s2, t1 = Power2Round high bits.
        byte[] publicKey = ReconstructPublicKey(algorithm.Parameters, source);
        return new MlDsa(algorithm, seed: null, source.ToArray(), publicKey);
    }

    /// <summary>
    /// Imports an ML-DSA public key.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The public key.</param>
    /// <returns>A new instance holding only the public key; it can verify but not sign.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static MlDsa ImportPublicKey(MlDsaAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.PublicKeySizeInBytes)
            throw new ArgumentException($"Public key must be exactly {algorithm.PublicKeySizeInBytes} bytes.", nameof(source));

        return new MlDsa(algorithm, seed: null, secretKey: null, source.ToArray());
    }

    /// <summary>
    /// Signs data using the hedged (randomized) variant of ML-DSA.
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
    /// Signs data into a caller-provided buffer using the hedged (randomized) variant of ML-DSA.
    /// </summary>
    /// <param name="data">The data to sign.</param>
    /// <param name="destination">The buffer to receive the signature; must be exactly <see cref="MlDsaAlgorithm.SignatureSizeInBytes"/> bytes.</param>
    /// <param name="context">The optional context string (at most 255 bytes).</param>
    /// <exception cref="ArgumentException">A parameter has an invalid size.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no secret key.</exception>
    public void SignData(ReadOnlySpan<byte> data, Span<byte> destination, ReadOnlySpan<byte> context = default)
    {
        ThrowIfDisposed();
        if (_secretKey is null)
            throw new OS.CryptographicException("The instance holds only a public key and cannot sign.");
        if (destination.Length != Algorithm.SignatureSizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.SignatureSizeInBytes} bytes.", nameof(destination));

        MlDsaEngine.Sign(Algorithm.Parameters, _secretKey, data, context, deterministic: false, destination);
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
        if (context.Length > MlDsaParams.MaxContextBytes)
            throw new ArgumentException($"Context must be at most {MlDsaParams.MaxContextBytes} bytes.", nameof(context));

        if (signature.Length != Algorithm.SignatureSizeInBytes)
        {
            return false;
        }

        return MlDsaEngine.Verify(Algorithm.Parameters, _publicKey, data, context, signature);
    }

    /// <summary>
    /// Exports the 32-byte private seed ξ.
    /// </summary>
    /// <returns>The private seed.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The key was not created from a seed.</exception>
    public byte[] ExportPrivateSeed()
    {
        byte[] destination = new byte[MlDsaParams.KeyGenSeedBytes];
        ExportPrivateSeed(destination);
        return destination;
    }

    /// <summary>
    /// Exports the 32-byte private seed ξ into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the seed; must be exactly <see cref="MlDsaAlgorithm.PrivateSeedSizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The key was not created from a seed.</exception>
    public void ExportPrivateSeed(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (_seed is null)
            throw new OS.CryptographicException("The key was not created from a private seed.");
        if (destination.Length != MlDsaParams.KeyGenSeedBytes)
            throw new ArgumentException($"Destination must be exactly {MlDsaParams.KeyGenSeedBytes} bytes.", nameof(destination));

        _seed.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Exports the public key.
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
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="MlDsaAlgorithm.PublicKeySizeInBytes"/> bytes.</param>
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
    /// Exports the expanded secret key.
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
    /// Exports the expanded secret key into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="MlDsaAlgorithm.SecretKeySizeInBytes"/> bytes.</param>
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
    /// Zeroizes the private seed and secret key and releases the instance.
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

    private static MlDsa FromSeed(MlDsaAlgorithm algorithm, byte[] seed)
    {
        byte[] publicKey = new byte[algorithm.PublicKeySizeInBytes];
        byte[] secretKey = new byte[algorithm.SecretKeySizeInBytes];
        MlDsaCore.KeyGen(algorithm.Parameters, seed, publicKey, secretKey);
        return new MlDsa(algorithm, seed, secretKey, publicKey);
    }

    private static byte[] ReconstructPublicKey(MlDsaParams p, ReadOnlySpan<byte> sk)
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

        // The reconstructed pk must hash to the tr stored in the secret key.
        Span<byte> computedTr = stackalloc byte[64];
        using (var shake = Hash.Shake256.Create(64))
        {
            shake.Absorb(publicKey);
            shake.Squeeze(computedTr);
        }

        bool valid = CryptographicOperations.FixedTimeEquals(computedTr, tr);

        CryptographicOperations.ZeroMemory(key);
        MlDsaCore.Zero(s1);
        MlDsaCore.Zero(s2);
        MlDsaCore.Zero(t0);
        MlDsaCore.Zero(discardedT0);
        MlDsaCore.Zero(t);

        if (!valid)
        {
            throw new OS.CryptographicException("Secret key is inconsistent: the embedded public key hash does not match.");
        }

        return publicKey;
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(MlDsa));
        }
    }
}
