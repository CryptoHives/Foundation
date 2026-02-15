// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

/// <summary>
/// Specifies the block cipher mode of operation.
/// </summary>
/// <remarks>
/// <para>
/// Block cipher modes determine how blocks of plaintext are processed
/// and how they relate to each other during encryption/decryption.
/// </para>
/// <para>
/// Values for ECB, CBC, OFB, and CFB match
/// <see cref="System.Security.Cryptography.CipherMode"/> for compatibility.
/// Additional modes (CTR, GCM, CCM, Stream) extend beyond the system enum.
/// </para>
/// <para>
/// <b>Security guidance:</b>
/// <list type="bullet">
///   <item><description><see cref="ECB"/> should be avoided for most use cases due to lack of diffusion.</description></item>
///   <item><description><see cref="GCM"/> and <see cref="CCM"/> provide authenticated encryption (AEAD).</description></item>
///   <item><description><see cref="CTR"/> is suitable for streaming but requires unique nonces.</description></item>
/// </list>
/// </para>
/// </remarks>
public enum CipherMode
{
    /// <summary>
    /// Cipher Block Chaining mode. Each plaintext block is XORed with the
    /// previous ciphertext block before encryption.
    /// </summary>
    /// <remarks>
    /// Requires an initialization vector (IV) for the first block.
    /// Provides better diffusion than ECB but is not parallelizable for encryption.
    /// Value matches <see cref="System.Security.Cryptography.CipherMode.CBC"/>.
    /// </remarks>
    CBC = 1,

    /// <summary>
    /// Electronic Codebook mode. Each block is encrypted independently.
    /// </summary>
    /// <remarks>
    /// <b>Warning:</b> ECB mode does not provide semantic security and should
    /// generally be avoided. Identical plaintext blocks produce identical
    /// ciphertext blocks, revealing patterns in the data.
    /// Value matches <see cref="System.Security.Cryptography.CipherMode.ECB"/>.
    /// </remarks>
    ECB = 2,

    /// <summary>
    /// Output Feedback mode. Converts a block cipher into a synchronous stream cipher.
    /// </summary>
    /// <remarks>
    /// Value matches <see cref="System.Security.Cryptography.CipherMode.OFB"/>.
    /// </remarks>
    OFB = 3,

    /// <summary>
    /// Cipher Feedback mode. Converts a block cipher into a self-synchronizing stream cipher.
    /// </summary>
    /// <remarks>
    /// Value matches <see cref="System.Security.Cryptography.CipherMode.CFB"/>.
    /// </remarks>
    CFB = 4,

    /// <summary>
    /// Cipher Text Stealing mode. Handles plaintext that is not a multiple of the block size.
    /// </summary>
    /// <remarks>
    /// Value matches <see cref="System.Security.Cryptography.CipherMode.CTS"/>.
    /// </remarks>
    CTS = 5,

    /// <summary>
    /// Counter mode. Converts a block cipher into a stream cipher by encrypting
    /// successive counter values and XORing with plaintext.
    /// </summary>
    /// <remarks>
    /// <para>
    /// CTR mode is parallelizable and allows random access to encrypted data.
    /// The nonce/counter combination must never repeat for the same key.
    /// </para>
    /// </remarks>
    CTR = 100,

    /// <summary>
    /// Galois/Counter Mode. Provides authenticated encryption with associated data (AEAD).
    /// </summary>
    /// <remarks>
    /// <para>
    /// GCM combines CTR mode encryption with Galois field multiplication for
    /// authentication. It produces both ciphertext and an authentication tag.
    /// </para>
    /// <para>
    /// <b>Important:</b> Nonce reuse completely breaks GCM security.
    /// Each (key, nonce) pair must be unique.
    /// </para>
    /// </remarks>
    GCM = 101,

    /// <summary>
    /// Counter with CBC-MAC mode. Provides authenticated encryption with associated data (AEAD).
    /// </summary>
    /// <remarks>
    /// <para>
    /// CCM is designed for constrained environments (IoT, embedded systems).
    /// It combines CTR mode encryption with CBC-MAC authentication.
    /// </para>
    /// </remarks>
    CCM = 102,

    /// <summary>
    /// Stream cipher mode. Used for ciphers like ChaCha20 that are natively stream ciphers.
    /// </summary>
    /// <remarks>
    /// Stream mode indicates the cipher operates on arbitrary-length data
    /// without block padding requirements.
    /// </remarks>
    Stream = 200
}

/// <summary>
/// Specifies the padding mode for block cipher operations.
/// </summary>
/// <remarks>
/// <para>
/// Padding is required when the plaintext length is not a multiple of the block size.
/// AEAD modes (GCM, CCM) and stream modes (CTR, Stream) do not require padding.
/// </para>
/// <para>
/// Values match <see cref="System.Security.Cryptography.PaddingMode"/> for compatibility.
/// </para>
/// </remarks>
public enum PaddingMode
{
    /// <summary>
    /// No padding. The plaintext must be an exact multiple of the block size.
    /// </summary>
    None = 1,

    /// <summary>
    /// PKCS#7 padding. Each padding byte contains the number of padding bytes added.
    /// </summary>
    /// <remarks>
    /// This is the most common padding mode and is compatible with PKCS#5.
    /// For a block size of 16 bytes, valid padding values are 0x01 through 0x10.
    /// </remarks>
    PKCS7 = 2,

    /// <summary>
    /// Zero padding. Pads with zero bytes.
    /// </summary>
    /// <remarks>
    /// <b>Warning:</b> Zero padding is ambiguous if the plaintext can end with
    /// zero bytes. Use PKCS#7 for unambiguous padding.
    /// </remarks>
    Zeros = 3,

    /// <summary>
    /// ANSI X.923 padding. Pads with zeros, with the last byte indicating padding length.
    /// </summary>
    ANSIX923 = 4,

    /// <summary>
    /// ISO 10126 padding. Pads with random bytes, with the last byte indicating padding length.
    /// </summary>
    ISO10126 = 5
}
