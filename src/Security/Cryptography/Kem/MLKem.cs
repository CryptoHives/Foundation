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
/// An instance holds either a full key pair (created via <see cref="GenerateKey(MLKemAlgorithm)"/>,
/// <see cref="ImportPrivateSeed(MLKemAlgorithm, ReadOnlySpan{byte})"/>, or
/// <see cref="ImportDecapsulationKey(MLKemAlgorithm, ReadOnlySpan{byte})"/>) or only an
/// encapsulation key (via <see cref="ImportEncapsulationKey(MLKemAlgorithm, ReadOnlySpan{byte})"/>). Keys generated from a
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
/// using var receiver = MLKem.GenerateKey(MLKemAlgorithm.MLKem768);
/// byte[] ek = receiver.ExportEncapsulationKey();
///
/// // Sender:
/// using var sender = MLKem.ImportEncapsulationKey(MLKemAlgorithm.MLKem768, ek);
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
public sealed class MLKem : IDisposable
{
    private readonly byte[]? _seed;
    private readonly byte[]? _decapsulationKey;
    private readonly byte[] _encapsulationKey;
    private bool _disposed;

    private MLKem(MLKemAlgorithm algorithm, byte[]? seed, byte[]? decapsulationKey, byte[] encapsulationKey)
    {
        Algorithm = algorithm;
        _seed = seed;
        _decapsulationKey = decapsulationKey;
        _encapsulationKey = encapsulationKey;
    }

    /// <summary>
    /// Gets a value indicating whether ML-KEM is supported on the current platform.
    /// </summary>
    /// <remarks>
    /// Always <see langword="true"/>. This is a fully managed implementation, so unlike
    /// <c>System.Security.Cryptography.MLKem.IsSupported</c> it never depends on the
    /// operating system providing ML-KEM.
    /// </remarks>
    public static bool IsSupported => true;

    /// <summary>
    /// Gets the ML-KEM parameter set of this key.
    /// </summary>
    public MLKemAlgorithm Algorithm { get; }

    /// <summary>
    /// Generates a new ML-KEM key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set to generate a key for.</param>
    /// <returns>A new instance holding the generated key pair and its private seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    public static MLKem GenerateKey(MLKemAlgorithm algorithm)
        => GenerateKey(algorithm, performPairwiseConsistencyTest: true);

    /// <summary>
    /// Generates a new ML-KEM key pair, optionally skipping the pairwise consistency test.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The pairwise consistency test verifies a freshly expanded key pair by running one
    /// encapsulate/decapsulate round trip, as FIPS 140-3 IG 10.3.A expects of a validated
    /// module. It costs roughly four fifths of key generation, because that round trip is a
    /// full encapsulation plus a full decapsulation.
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
    /// <param name="performPairwiseConsistencyTest">
    /// <see langword="true"/> to verify the generated key pair with an encapsulate/decapsulate
    /// round trip; <see langword="false"/> to skip it.
    /// </param>
    /// <returns>A new instance holding the generated key pair and its private seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static MLKem GenerateKey(MLKemAlgorithm algorithm, bool performPairwiseConsistencyTest)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));

        byte[] seed = new byte[MLKemParams.KeyGenSeedBytes];
        MLKemCore.GenerateRandomSeed(seed);
        return FromSeed(algorithm, seed, performPairwiseConsistencyTest);
    }

    /// <summary>
    /// Imports an ML-KEM private seed (d ‖ z) and expands it into a key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 64-byte private seed.</param>
    /// <returns>A new instance holding the key pair and the seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static MLKem ImportPrivateSeed(MLKemAlgorithm algorithm, ReadOnlySpan<byte> source)
        => ImportPrivateSeed(algorithm, source, performPairwiseConsistencyTest: true);

    /// <summary>
    /// Imports an ML-KEM private seed (d ‖ z) and expands it into a key pair, optionally
    /// skipping the pairwise consistency test.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The pairwise consistency test verifies a freshly expanded key pair by running one
    /// encapsulate/decapsulate round trip, as FIPS 140-3 IG 10.3.A expects of a validated
    /// module. It costs roughly four fifths of key generation, because that round trip is a
    /// full encapsulation plus a full decapsulation.
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
    /// <param name="source">The 64-byte private seed.</param>
    /// <param name="performPairwiseConsistencyTest">
    /// <see langword="true"/> to verify the expanded key pair; <see langword="false"/> to skip it.
    /// </param>
    /// <returns>A new instance holding the key pair and the seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The key pair failed the consistency test.</exception>
    public static MLKem ImportPrivateSeed(MLKemAlgorithm algorithm, ReadOnlySpan<byte> source,
                                          bool performPairwiseConsistencyTest)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != MLKemParams.KeyGenSeedBytes)
            throw new ArgumentException($"Private seed must be exactly {MLKemParams.KeyGenSeedBytes} bytes.", nameof(source));

        return FromSeed(algorithm, source.ToArray(), performPairwiseConsistencyTest);
    }

    /// <summary>
    /// Imports an ML-KEM private seed (d ‖ z) and expands it into a key pair.
    /// </summary>
    /// <param name="algorithm">The parameter set of the key.</param>
    /// <param name="source">The 64-byte private seed.</param>
    /// <returns>A new instance holding the key pair and the seed.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> or <paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    public static MLKem ImportPrivateSeed(MLKemAlgorithm algorithm, byte[] source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return ImportPrivateSeed(algorithm, new ReadOnlySpan<byte>(source));
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
    public static MLKem ImportDecapsulationKey(MLKemAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.DecapsulationKeySizeInBytes)
            throw new ArgumentException($"Decapsulation key must be exactly {algorithm.DecapsulationKeySizeInBytes} bytes.", nameof(source));
        if (!MLKemCore.IsValidDecapsulationKey(algorithm.Parameters, source))
            throw new OS.CryptographicException("Decapsulation key failed the FIPS 203 §7.3 hash check.");

        // dk = dkPKE ‖ ekPKE ‖ H(ekPKE) ‖ z — extract the embedded encapsulation key.
        MLKemParams p = algorithm.Parameters;
        byte[] encapsulationKey = source.Slice(p.PolyVecEncodedBytes, p.EncapsulationKeyBytes).ToArray();
        return new MLKem(algorithm, seed: null, source.ToArray(), encapsulationKey);
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
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> or <paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The key failed the FIPS 203 §7.3 hash check.</exception>
    public static MLKem ImportDecapsulationKey(MLKemAlgorithm algorithm, byte[] source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return ImportDecapsulationKey(algorithm, new ReadOnlySpan<byte>(source));
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
    public static MLKem ImportEncapsulationKey(MLKemAlgorithm algorithm, ReadOnlySpan<byte> source)
    {
        if (algorithm is null)
            throw new ArgumentNullException(nameof(algorithm));
        if (source.Length != algorithm.EncapsulationKeySizeInBytes)
            throw new ArgumentException($"Encapsulation key must be exactly {algorithm.EncapsulationKeySizeInBytes} bytes.", nameof(source));
        if (!MLKemCore.IsValidEncapsulationKey(algorithm.Parameters, source))
            throw new OS.CryptographicException("Encapsulation key failed the FIPS 203 §7.2 modulus check.");

        return new MLKem(algorithm, seed: null, decapsulationKey: null, source.ToArray());
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
    /// <exception cref="ArgumentNullException"><paramref name="algorithm"/> or <paramref name="source"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="source"/> has an invalid length.</exception>
    /// <exception cref="OS.CryptographicException">The key failed the FIPS 203 §7.2 modulus check.</exception>
    public static MLKem ImportEncapsulationKey(MLKemAlgorithm algorithm, byte[] source)
    {
        if (source is null)
            throw new ArgumentNullException(nameof(source));

        return ImportEncapsulationKey(algorithm, new ReadOnlySpan<byte>(source));
    }

    /// <summary>
    /// Creates a ciphertext and shared secret for the holder of this key's decapsulation key.
    /// </summary>
    /// <param name="ciphertext">The buffer to receive the ciphertext; must be exactly <see cref="MLKemAlgorithm.CiphertextSizeInBytes"/> bytes.</param>
    /// <param name="sharedSecret">The buffer to receive the shared secret; must be exactly <see cref="MLKemAlgorithm.SharedSecretSizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException">A buffer has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The buffers overlap.</exception>
    public void Encapsulate(Span<byte> ciphertext, Span<byte> sharedSecret)
    {
        ThrowIfDisposed();
        if (ciphertext.Length != Algorithm.CiphertextSizeInBytes)
            throw new ArgumentException($"Ciphertext buffer must be exactly {Algorithm.CiphertextSizeInBytes} bytes.", nameof(ciphertext));
        if (sharedSecret.Length != Algorithm.SharedSecretSizeInBytes)
            throw new ArgumentException($"Shared secret buffer must be exactly {Algorithm.SharedSecretSizeInBytes} bytes.", nameof(sharedSecret));
        if (ciphertext.Overlaps(sharedSecret))
            throw new OS.CryptographicException("The ciphertext and shared secret buffers must not overlap.");

        Span<byte> m = stackalloc byte[MLKemParams.EncapsSeedBytes];
        MLKemCore.GenerateRandomSeed(m);
        MLKemCore.Encaps(Algorithm.Parameters, _encapsulationKey, m, ciphertext, sharedSecret);
        CryptographicOperations.ZeroMemory(m);
    }

    /// <summary>
    /// Creates a ciphertext and shared secret for the holder of this key's decapsulation key,
    /// returning both as new arrays.
    /// </summary>
    /// <param name="ciphertext">When this method returns, the ciphertext.</param>
    /// <param name="sharedSecret">When this method returns, the shared secret.</param>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    public void Encapsulate(out byte[] ciphertext, out byte[] sharedSecret)
    {
        ThrowIfDisposed();

        byte[] localCiphertext = new byte[Algorithm.CiphertextSizeInBytes];
        byte[] localSharedSecret = new byte[Algorithm.SharedSecretSizeInBytes];

        Encapsulate(localCiphertext, localSharedSecret);

        ciphertext = localCiphertext;
        sharedSecret = localSharedSecret;
    }

    /// <summary>
    /// Recovers the shared secret from a ciphertext using this key's decapsulation key.
    /// </summary>
    /// <remarks>
    /// ML-KEM uses implicit rejection: an invalid ciphertext of the correct length does not
    /// throw, but yields a pseudorandom secret unrelated to the sender's.
    /// </remarks>
    /// <param name="ciphertext">The ciphertext; must be exactly <see cref="MLKemAlgorithm.CiphertextSizeInBytes"/> bytes.</param>
    /// <param name="sharedSecret">The buffer to receive the shared secret; must be exactly <see cref="MLKemAlgorithm.SharedSecretSizeInBytes"/> bytes.</param>
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

        MLKemCore.Decaps(Algorithm.Parameters, _decapsulationKey, ciphertext, sharedSecret);
    }

    /// <summary>
    /// Recovers the shared secret from a ciphertext using this key's decapsulation key,
    /// returning it as a new array.
    /// </summary>
    /// <remarks>
    /// ML-KEM uses implicit rejection: an invalid ciphertext of the correct length does not
    /// throw, but yields a pseudorandom secret unrelated to the sender's.
    /// </remarks>
    /// <param name="ciphertext">The ciphertext; must be exactly <see cref="MLKemAlgorithm.CiphertextSizeInBytes"/> bytes.</param>
    /// <returns>The shared secret.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="ciphertext"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="ciphertext"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The instance holds no decapsulation key.</exception>
    public byte[] Decapsulate(byte[] ciphertext)
    {
        if (ciphertext is null)
            throw new ArgumentNullException(nameof(ciphertext));
        if (ciphertext.Length != Algorithm.CiphertextSizeInBytes)
            throw new ArgumentException($"Ciphertext must be exactly {Algorithm.CiphertextSizeInBytes} bytes.", nameof(ciphertext));

        ThrowIfDisposed();

        byte[] sharedSecret = new byte[Algorithm.SharedSecretSizeInBytes];
        Decapsulate(ciphertext, sharedSecret);
        return sharedSecret;
    }

    /// <summary>
    /// Exports the 64-byte private seed (d ‖ z).
    /// </summary>
    /// <returns>The private seed.</returns>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The key was not created from a seed.</exception>
    public byte[] ExportPrivateSeed()
    {
        byte[] destination = new byte[MLKemParams.KeyGenSeedBytes];
        ExportPrivateSeed(destination);
        return destination;
    }

    /// <summary>
    /// Exports the 64-byte private seed (d ‖ z) into a buffer.
    /// </summary>
    /// <param name="destination">The buffer to receive the seed; must be exactly <see cref="MLKemAlgorithm.PrivateSeedSizeInBytes"/> bytes.</param>
    /// <exception cref="ArgumentException"><paramref name="destination"/> has an incorrect length.</exception>
    /// <exception cref="ObjectDisposedException">The instance has been disposed.</exception>
    /// <exception cref="OS.CryptographicException">The key was not created from a seed.</exception>
    public void ExportPrivateSeed(Span<byte> destination)
    {
        ThrowIfDisposed();
        if (_seed is null)
            throw new OS.CryptographicException("The key was not created from a private seed.");
        if (destination.Length != MLKemParams.KeyGenSeedBytes)
            throw new ArgumentException($"Destination must be exactly {MLKemParams.KeyGenSeedBytes} bytes.", nameof(destination));

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
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="MLKemAlgorithm.EncapsulationKeySizeInBytes"/> bytes.</param>
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
    /// <param name="destination">The buffer to receive the key; must be exactly <see cref="MLKemAlgorithm.DecapsulationKeySizeInBytes"/> bytes.</param>
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

    private static MLKem FromSeed(MLKemAlgorithm algorithm, byte[] seed, bool performPairwiseConsistencyTest)
    {
        byte[] encapsulationKey = new byte[algorithm.EncapsulationKeySizeInBytes];
        byte[] decapsulationKey = new byte[algorithm.DecapsulationKeySizeInBytes];
        MLKemCore.KeyGen(algorithm.Parameters, seed, encapsulationKey, decapsulationKey,
            performPairwiseConsistencyTest);
        return new MLKem(algorithm, seed, decapsulationKey, encapsulationKey);
    }

    private void ThrowIfDisposed()
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(typeof(MLKem).FullName);
        }
    }
}
