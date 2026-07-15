// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;

/// <summary>
/// Defines a Key Encapsulation Mechanism (KEM).
/// </summary>
/// <remarks>
/// <para>
/// A KEM provides three operations: key generation, encapsulation, and decapsulation.
/// Encapsulation produces a shared secret and a ciphertext that can be sent to the
/// holder of the corresponding decapsulation key, who can recover the same shared secret.
/// </para>
/// <para>
/// <b>Common KEM algorithms:</b>
/// <list type="bullet">
///   <item><description>ML-KEM-512 (FIPS 203, security category 1)</description></item>
///   <item><description>ML-KEM-768 (FIPS 203, security category 3)</description></item>
///   <item><description>ML-KEM-1024 (FIPS 203, security category 5)</description></item>
/// </list>
/// </para>
/// </remarks>
public interface IKem : IDisposable
{
    /// <summary>
    /// Gets the algorithm name.
    /// </summary>
    string AlgorithmName { get; }

    /// <summary>
    /// Gets the shared secret size in bytes.
    /// </summary>
    int SharedSecretSizeBytes { get; }

    /// <summary>
    /// Gets the encapsulation key size in bytes.
    /// </summary>
    int EncapsulationKeySizeBytes { get; }

    /// <summary>
    /// Gets the decapsulation key size in bytes.
    /// </summary>
    int DecapsulationKeySizeBytes { get; }

    /// <summary>
    /// Gets the ciphertext size in bytes.
    /// </summary>
    int CiphertextSizeBytes { get; }

    /// <summary>
    /// Generates an encapsulation key and a decapsulation key.
    /// </summary>
    /// <param name="encapsulationKey">The buffer to receive the encapsulation (public) key.</param>
    /// <param name="decapsulationKey">The buffer to receive the decapsulation (private) key.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="encapsulationKey"/> or <paramref name="decapsulationKey"/> is too small.
    /// </exception>
    void GenerateKeyPair(Span<byte> encapsulationKey, Span<byte> decapsulationKey);

    /// <summary>
    /// Generates an encapsulation key and a decapsulation key using the provided seed.
    /// </summary>
    /// <param name="seed">The deterministic seed (d ‖ z) for key generation.</param>
    /// <param name="encapsulationKey">The buffer to receive the encapsulation (public) key.</param>
    /// <param name="decapsulationKey">The buffer to receive the decapsulation (private) key.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="seed"/>, <paramref name="encapsulationKey"/>, or
    /// <paramref name="decapsulationKey"/> has an invalid size.
    /// </exception>
    void GenerateKeyPair(ReadOnlySpan<byte> seed, Span<byte> encapsulationKey, Span<byte> decapsulationKey);

    /// <summary>
    /// Encapsulates a shared secret using the encapsulation key.
    /// </summary>
    /// <param name="encapsulationKey">The encapsulation (public) key.</param>
    /// <param name="ciphertext">The buffer to receive the ciphertext.</param>
    /// <param name="sharedSecret">The buffer to receive the shared secret.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="encapsulationKey"/> has an invalid size, or
    /// <paramref name="ciphertext"/> or <paramref name="sharedSecret"/> is too small.
    /// </exception>
    void Encapsulate(ReadOnlySpan<byte> encapsulationKey, Span<byte> ciphertext, Span<byte> sharedSecret);

    /// <summary>
    /// Encapsulates a shared secret using the encapsulation key with a deterministic seed.
    /// </summary>
    /// <param name="encapsulationKey">The encapsulation (public) key.</param>
    /// <param name="seed">The 32-byte random seed (m) for deterministic encapsulation.</param>
    /// <param name="ciphertext">The buffer to receive the ciphertext.</param>
    /// <param name="sharedSecret">The buffer to receive the shared secret.</param>
    /// <exception cref="ArgumentException">
    /// Any parameter has an invalid size.
    /// </exception>
    void Encapsulate(ReadOnlySpan<byte> encapsulationKey, ReadOnlySpan<byte> seed,
                     Span<byte> ciphertext, Span<byte> sharedSecret);

    /// <summary>
    /// Decapsulates the shared secret from the ciphertext using the decapsulation key.
    /// </summary>
    /// <remarks>
    /// ML-KEM uses implicit rejection: if decapsulation fails, a pseudorandom value
    /// derived from the ciphertext and a secret value is returned instead of an error.
    /// </remarks>
    /// <param name="decapsulationKey">The decapsulation (private) key.</param>
    /// <param name="ciphertext">The ciphertext produced by encapsulation.</param>
    /// <param name="sharedSecret">The buffer to receive the shared secret.</param>
    /// <exception cref="ArgumentException">
    /// <paramref name="decapsulationKey"/>, <paramref name="ciphertext"/>, or
    /// <paramref name="sharedSecret"/> has an invalid size.
    /// </exception>
    void Decapsulate(ReadOnlySpan<byte> decapsulationKey, ReadOnlySpan<byte> ciphertext,
                     Span<byte> sharedSecret);
}
