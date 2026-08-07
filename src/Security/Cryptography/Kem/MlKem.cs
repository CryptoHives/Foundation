// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;
using OS = System.Security.Cryptography;

/// <summary>
/// Represents an ML-KEM key (FIPS 203) and provides encapsulation and decapsulation.
/// </summary>
/// <remarks>
/// <para>
/// The API shape mirrors <c>System.Security.Cryptography.MLKem</c> from .NET 10 so code
/// written against the in-box type ports directly to older target frameworks, including
/// .NET Framework and .NET Standard 2.0.
/// </para>
/// <para>
/// An instance holds either a full key pair (created via <see cref="GenerateKey"/>,
/// <see cref="ImportPrivateSeed"/>, or <see cref="ImportDecapsulationKey"/>) or only an
/// encapsulation key (via <see cref="ImportEncapsulationKey"/>). Keys generated from a
/// seed retain the 64-byte (d ‖ z) seed, the storage format recommended by FIPS 203;
/// keys imported from an expanded decapsulation key cannot export a seed.
/// </para>
/// <para>
/// Imported keys are validated with the FIPS 203 §7.2 modulus check (encapsulation keys)
/// and §7.3 hash check (decapsulation keys). Secret key material is zeroed when the
/// instance is disposed.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var receiver = MlKem.GenerateKey(MlKemAlgorithm.MlKem768);
/// byte[] ek = receiver.ExportEncapsulationKey();
///
/// // Sender:
/// using var sender = MlKem.ImportEncapsulationKey(MlKemAlgorithm.MlKem768, ek);
/// byte[] ciphertext = new byte[sender.Algorithm.CiphertextSizeInBytes];
/// byte[] secret1 = new byte[sender.Algorithm.SharedSecretSizeInBytes];
/// sender.Encapsulate(ciphertext, secret1);
///
/// // Receiver:
/// byte[] secret2 = new byte[receiver.Algorithm.SharedSecretSizeInBytes];
/// receiver.Decapsulate(ciphertext, secret2);
/// // secret1 and secret2 are identical
/// </code>
/// </para>
/// </remarks>
public sealed class MlKem : IDisposable
{
    private readonly byte[]? _seed;
    private readonly byte[]? _decapsulationKey;
    private readonly byte[] _encapsulationKey;
    private bool _disposed;

    private MlKem(MlKemAlgorithm algorithm, byte[]? seed, byte[]? decapsulationKey, byte[] encapsulationKey)
    {
        Algorithm = algorithm;
        _seed = seed;
        _decapsulationKey = decapsulationKey;
        _encapsulationKey = encapsulationKey;
    }

    /// <summary>
    /// Gets the ML-KEM parameter set of this key.
    /// </summary>
    public MlKemAlgorithm Algorithm { get; }

    /// <summary>
    /// Generates a new ML-KEM key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set to generate a key for.</param>
    /// <returns>A new instance holding the generated key pair and its private seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    public static MlKem GenerateKey(MlKemAlgorithm algorithm)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));

        byte[] seed = new byte[MlKemParams.KeyGenSeedBytes];
        MlKemCore.GenerateRandomSeed(seed);
        return FromSeed(algorithm, seed);
    }

    /// <summary>
    /// Imports an ML-KEM private seed (d ‖ z) and expands it into a key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 64-byte private seed.</param>
    /// <returns>A new instance holding the key pair and the seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static MlKem ImportPrivateSeed(MlKemAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != MlKemParams.KeyGenSeedBytes)
            throw new ArgumentException($"Private seed must be exactly {MlKemParams.KeyGenSeedBytes} bytes.", nameof(source));

        return FromSeed(algorithm, source.ToArray());
    }

    /// <summary>
    /// Imports an expanded ML-KEM decapsulation key.
    /// </summary>
    /// <remarks>
    /// The key is validated with the FIPS 203 §7.3 hash check. A key imported this way
    /// holds no private seed, so <see cref="ExportPrivateSeed()"/> is unavailable.
    /// </remarks>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The expanded decapsulation key.</param>
    /// <returns>A new instance holding the key pair.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The key failed the FIPS 203 §7.3 hash check.</exception>
    public static MlKem ImportDecapsulationKey(MlKemAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.DecapsulationKeySizeInBytes)
            throw new ArgumentException($"Decapsulation key must be exactly {algorithm.DecapsulationKeySizeInBytes} bytes.", nameof(source));
        if (!MlKemCore.IsValidDecapsulationKey(algorithm.Parameters, source))
            throw new OS.CryptographicException("Decapsulation key failed the FIPS 203 §7.3 hash check.");

        // dk = dkPKE ‖ ekPKE ‖ H(ekPKE) ‖ z — extract the embedded encapsulation key.
        MlKemParams p = algorithm.Parameters;
        byte[] encapsulationKey = source.Slice(p.PolyVecEncodedBytes, p.EncapsulationKeyBytes).ToArray();
        return new MlKem(algorithm, seed: null, source.ToArray(), encapsulationKey);
    }

    /// <summary>
    /// Imports an ML-KEM encapsulation (public) key.
    /// </summary>
    /// <remarks>
    /// The key is validated with the FIPS 203 §7.2 modulus check. The resulting instance
    /// can encapsulate but not decapsulate.
    /// </remarks>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The encapsulation key.</param>
    /// <returns>A new instance holding only the public key.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The key failed the FIPS 203 §7.2 modulus check.</exception>
    public static MlKem ImportEncapsulationKey(MlKemAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.EncapsulationKeySizeInBytes)
            throw new ArgumentException($"Encapsulation key must be exactly {algorithm.EncapsulationKeySizeInBytes} bytes.", nameof(source));
        if (!MlKemCore.IsValidEncapsulationKey(algorithm.Parameters, source))
            throw new OS.CryptographicException("Encapsulation key failed the FIPS 203 §7.2 modulus check.");

        return new MlKem(algorithm, seed: null, decapsulationKey: null, source.ToArray());
    }

    /// <summary>
    /// Creates a ciphertext and shared secret for the holder of this key's decapsulation key.
    /// </summary>
    /// <param name="ciphertext">The buffer to receive the ciphertext; must be exactly <see cref="MlKemAlgorithm.CiphertextSizeInBytes"/> bytes.</param>
    /// <param name="sharedSecret">The buffer to receive the shared secret; must be exactly <see cref="MlKemAlgorithm.SharedSecretSizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException">A buffer has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void Encapsulate(Span<byte> ciphertext, Span<byte> sharedSecret)
    {
        ThrowIfDisposed();
        if (ciphertext.Length != Algorithm.CiphertextSizeInBytes)
            throw new ArgumentException($"Ciphertext buffer must be exactly {Algorithm.CiphertextSizeInBytes} bytes.", nameof(ciphertext));
        if (sharedSecret.Length != Algorithm.SharedSecretSizeInBytes)
            throw new ArgumentException($"Shared secret buffer must be exactly {Algorithm.SharedSecretSizeInBytes} bytes.", nameof(sharedSecret));

        Span<byte> m = stackalloc byte[MlKemParams.EncapsSeedBytes];
        MlKemCore.GenerateRandomSeed(m);
        MlKemCore.Encaps(Algorithm.Parameters, _encapsulationKey, m, ciphertext, sharedSecret);
        CryptographicOperations.ZeroMemory(m);
    }

    /// <summary>
    /// Recovers the shared secret from a ciphertext using this key's decapsulation key.
    /// </summary>
    /// <remarks>
    /// ML-KEM uses implicit rejection: an invalid ciphertext of the correct length does not
    /// throw, but yields a pseudorandom secret unrelated to the sender's.
    /// </remarks>
    /// <param name="ciphertext">The ciphertext; must be exactly <see cref="MlKemAlgorithm.CiphertextSizeInBytes"/> bytes.</param>
    /// <param name="sharedSecret">The buffer to receive the shared secret; must be exactly <see cref="MlKemAlgorithm.SharedSecretSizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException">A buffer has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no decapsulation key.</exception>
    public void Decapsulate(ReadOnlySpan<byte> ciphertext, Span<byte> sharedSecret)
    {
        ThrowIfDisposed();
        if (_decapsulationKey is null)
            throw new OS.CryptographicException("The instance holds only an encapsulation key and cannot decapsulate.");
        if (ciphertext.Length != Algorithm.CiphertextSizeInBytes)
            throw new ArgumentException($"Ciphertext must be exactly {Algorithm.CiphertextSizeInBytes} bytes.", nameof(ciphertext));
        if (sharedSecret.Length != Algorithm.SharedSecretSizeInBytes)
            throw new ArgumentException($"Shared secret buffer must be exactly {Algorithm.SharedSecretSizeInBytes} bytes.", nameof(sharedSecret));

        MlKemCore.Decaps(Algorithm.Parameters, _decapsulationKey, ciphertext, sharedSecret);
    }

    /// <summary>
    /// Exports the 64-byte private seed (d ‖ z).
    /// </summary>
    /// <returns>The private seed.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The key was not created from a seed.</exception>
    public byte[] ExportPrivateSeed()
    {
        byte[] destination = new byte[MlKemParams.KeyGenSeedBytes];
        ExportPrivateSeed(destination);
        return destination;
    }

    /// <summary>
    /// Exports the 64-byte private seed (d ‖ z) into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the seed; must be exactly <see cref="MlKemAlgorithm.PrivateSeedSizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The key was not created from a seed.</exception>
    public void ExportPrivateSeed(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (_seed is null)
            throw new OS.CryptographicException("The key was not created from a private seed.");
        if (destination.Length != MlKemParams.KeyGenSeedBytes)
            throw new ArgumentException($"Destination must be exactly {MlKemParams.KeyGenSeedBytes} bytes.", nameof(destination));

        _seed.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Exports the encapsulation (public) key.
    /// </summary>
    /// <returns>The encapsulation key.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public byte[] ExportEncapsulationKey()
    {
        byte[] destination = new byte[Algorithm.EncapsulationKeySizeInBytes];
        ExportEncapsulationKey(destination);
        return destination;
    }

    /// <summary>
    /// Exports the encapsulation (public) key into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="MlKemAlgorithm.EncapsulationKeySizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void ExportEncapsulationKey(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (destination.Length != Algorithm.EncapsulationKeySizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.EncapsulationKeySizeInBytes} bytes.", nameof(destination));

        _encapsulationKey.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Exports the expanded decapsulation (private) key.
    /// </summary>
    /// <returns>The expanded decapsulation key.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no decapsulation key.</exception>
    public byte[] ExportDecapsulationKey()
    {
        byte[] destination = new byte[Algorithm.DecapsulationKeySizeInBytes];
        ExportDecapsulationKey(destination);
        return destination;
    }

    /// <summary>
    /// Exports the expanded decapsulation (private) key into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="MlKemAlgorithm.DecapsulationKeySizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no decapsulation key.</exception>
    public void ExportDecapsulationKey(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (_decapsulationKey is null)
            throw new OS.CryptographicException("The instance holds only an encapsulation key.");
        if (destination.Length != Algorithm.DecapsulationKeySizeInBytes)
            throw new ArgumentException($"Destination must be exactly {Algorithm.DecapsulationKeySizeInBytes} bytes.", nameof(destination));

        _decapsulationKey.AsSpan().CopyTo(destination);
    }

    /// <summary>
    /// Zeroizes the private seed and decapsulation key and releases the instance.
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

        if (_decapsulationKey is not null)
        {
            CryptographicOperations.ZeroMemory(_decapsulationKey);
        }
    }

    private static MlKem FromSeed(MlKemAlgorithm algorithm, byte[] seed)
    {
        byte[] encapsulationKey = new byte[algorithm.EncapsulationKeySizeInBytes];
        byte[] decapsulationKey = new byte[algorithm.DecapsulationKeySizeInBytes];
        MlKemCore.KeyGen(algorithm.Parameters, seed, encapsulationKey, decapsulationKey);
        return new MlKem(algorithm, seed, decapsulationKey, encapsulationKey);
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(MlKem));
        }
    }
}
