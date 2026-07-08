// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;

/// <summary>
/// Defines a digital signature algorithm operating on caller-provided key material.
/// </summary>
/// <remarks>
/// <para>
/// This is the low-level, stateless interface: keys are raw byte spans owned by the
/// caller and never retained by the implementation. For a key-holding API that mirrors
/// the .NET 10 built-in types, see <see cref="MlDsa"/>.
/// </para>
/// <para>
/// <b>Implemented algorithms:</b>
/// <list type="bullet">
///   <item><description>ML-DSA-44 (FIPS 204, security category 2)</description></item>
///   <item><description>ML-DSA-65 (FIPS 204, security category 3)</description></item>
///   <item><description>ML-DSA-87 (FIPS 204, security category 5)</description></item>
/// </list>
/// </para>
/// </remarks>
public interface IDsa : IDisposable
{
    /// <summary>
    /// Gets the algorithm name.
    /// </summary>
    string AlgorithmName { get; }

    /// <summary>
    /// Gets the public key size in bytes.
    /// </summary>
    int PublicKeySizeBytes { get; }

    /// <summary>
    /// Gets the secret key size in bytes.
    /// </summary>
    int SecretKeySizeBytes { get; }

    /// <summary>
    /// Gets the signature size in bytes.
    /// </summary>
    int SignatureSizeBytes { get; }

    /// <summary>
    /// Generates a new key pair using the OS random number generator.
    /// </summary>
    /// <param name="publicKey">The buffer to receive the public key.</param>
    /// <param name="secretKey">The buffer to receive the secret key.</param>
    /// <exception cref="ArgumentException">A buffer is too small.</exception>
    void GenerateKeyPair(Span<byte> publicKey, Span<byte> secretKey);

    /// <summary>
    /// Generates a key pair deterministically from the provided 32-byte seed ξ.
    /// </summary>
    /// <param name="seed">The 32-byte key generation seed.</param>
    /// <param name="publicKey">The buffer to receive the public key.</param>
    /// <param name="secretKey">The buffer to receive the secret key.</param>
    /// <exception cref="ArgumentException">A parameter has an invalid size.</exception>
    void GenerateKeyPair(ReadOnlySpan<byte> seed, Span<byte> publicKey, Span<byte> secretKey);

    /// <summary>
    /// Signs a message using the hedged (randomized) variant of ML-DSA.
    /// </summary>
    /// <param name="secretKey">The secret key.</param>
    /// <param name="message">The message to sign.</param>
    /// <param name="context">The optional context string (at most 255 bytes).</param>
    /// <param name="signature">The buffer to receive the signature.</param>
    /// <exception cref="ArgumentException">A parameter has an invalid size.</exception>
    void Sign(ReadOnlySpan<byte> secretKey, ReadOnlySpan<byte> message, ReadOnlySpan<byte> context, Span<byte> signature);

    /// <summary>
    /// Signs a message using the deterministic variant of ML-DSA (rnd = 0³²).
    /// </summary>
    /// <remarks>
    /// Hedged signing (see <see cref="Sign"/>) is the FIPS 204 default and should be
    /// preferred; the deterministic variant exists for reproducibility requirements and
    /// known-answer testing.
    /// </remarks>
    /// <param name="secretKey">The secret key.</param>
    /// <param name="message">The message to sign.</param>
    /// <param name="context">The optional context string (at most 255 bytes).</param>
    /// <param name="signature">The buffer to receive the signature.</param>
    /// <exception cref="ArgumentException">A parameter has an invalid size.</exception>
    void SignDeterministic(ReadOnlySpan<byte> secretKey, ReadOnlySpan<byte> message, ReadOnlySpan<byte> context, Span<byte> signature);

    /// <summary>
    /// Verifies a signature over a message.
    /// </summary>
    /// <param name="publicKey">The public key.</param>
    /// <param name="message">The signed message.</param>
    /// <param name="context">The context string used when signing (at most 255 bytes).</param>
    /// <param name="signature">The signature to verify.</param>
    /// <returns>True when the signature is valid for the message, key, and context.</returns>
    /// <exception cref="ArgumentException">A parameter has an invalid size.</exception>
    bool Verify(ReadOnlySpan<byte> publicKey, ReadOnlySpan<byte> message, ReadOnlySpan<byte> context, ReadOnlySpan<byte> signature);
}
