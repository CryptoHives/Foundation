// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// Defines a cryptographic transform for symmetric cipher operations.
/// </summary>
/// <remarks>
/// <para>
/// This interface extends <see cref="System.Security.Cryptography.ICryptoTransform"/>
/// to provide full compatibility with <see cref="System.Security.Cryptography.CryptoStream"/> and other .NET
/// cryptographic infrastructure, while also adding span-based overloads for
/// zero-allocation scenarios.
/// </para>
/// <para>
/// Implementations should be created through <see cref="SymmetricCipher.CreateEncryptor()"/>
/// or <see cref="SymmetricCipher.CreateDecryptor()"/> methods.
/// </para>
/// </remarks>
public interface ICipherTransform : System.Security.Cryptography.ICryptoTransform
{
    /// <summary>
    /// Gets the block size in bytes for this transform.
    /// </summary>
    /// <remarks>
    /// For stream ciphers (ChaCha20) this returns 1, indicating byte-level operation.
    /// For block ciphers (AES) this returns the cipher block size (16 bytes).
    /// </remarks>
    int BlockSize { get; }

    /// <summary>
    /// Transforms the specified region of the input buffer and copies the result to the output buffer.
    /// </summary>
    /// <param name="input">The input data to transform.</param>
    /// <param name="output">The buffer to receive the transformed data.</param>
    /// <returns>The number of bytes written to <paramref name="output"/>.</returns>
    /// <exception cref="ArgumentException">
    /// <paramref name="output"/> is too small to hold the transformed data.
    /// </exception>
    int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output);

    /// <summary>
    /// Transforms the final block of data, applying padding if necessary.
    /// </summary>
    /// <param name="input">The final input data to transform.</param>
    /// <param name="output">The buffer to receive the transformed data.</param>
    /// <returns>The number of bytes written to <paramref name="output"/>.</returns>
    /// <remarks>
    /// For encryption with padding modes, this method adds padding.
    /// For decryption, this method validates and removes padding.
    /// For AEAD modes, this method also handles authentication tag processing.
    /// </remarks>
    int TransformFinalBlock(ReadOnlySpan<byte> input, Span<byte> output);

    /// <summary>
    /// Resets the transform to its initial state.
    /// </summary>
    /// <remarks>
    /// This allows reusing the transform for a new encryption/decryption operation
    /// with the same key but potentially different IV/nonce.
    /// </remarks>
    void Reset();
}
