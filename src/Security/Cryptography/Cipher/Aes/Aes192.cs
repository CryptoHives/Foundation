// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System.Security.Cryptography;

/// <summary>
/// AES-192 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// AES-192 uses a 192-bit (24-byte) key with 12 rounds of encryption.
/// It provides a balance between security and performance.
/// </para>
/// <para>
/// <b>Security level:</b> 192 bits (quantum: 96 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Note:</b> AES-192 is less commonly used than AES-128 or AES-256.
/// Some standards and implementations do not support it.
/// </para>
/// </remarks>
public sealed class Aes192 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for AES-192.
    /// </summary>
    public const int KeySizeBits = 192;

    /// <summary>
    /// Key size in bytes for AES-192.
    /// </summary>
    public const int KeySizeBytes = 24;

    private static readonly KeySizes[] s_legalKeySizes = [new KeySizes(192, 192, 0)];
    private static readonly KeySizes[] s_legalBlockSizes = [new KeySizes(128, 128, 0)];

    /// <summary>
    /// Initializes a new instance of the <see cref="Aes192"/> class.
    /// </summary>
    public Aes192()
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-192";

    /// <inheritdoc/>
    public override int BlockSize => AesCore.BlockSizeBits;

    /// <inheritdoc/>
    public override int KeySize => KeySizeBits;

    /// <inheritdoc/>
    public override KeySizes[] LegalKeySizes => s_legalKeySizes;

    /// <inheritdoc/>
    public override KeySizes[] LegalBlockSizes => s_legalBlockSizes;

    /// <inheritdoc/>
    public override int IVSize => AesCore.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Aes192"/> cipher.
    /// </summary>
    /// <returns>A new AES-192 cipher instance.</returns>
    public static Aes192 Create() => new();

    /// <inheritdoc/>
    public override ICipherTransform CreateEncryptor(byte[] key, byte[] iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AesCipherTransform(key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    public override ICipherTransform CreateDecryptor(byte[] key, byte[] iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AesCipherTransform(key, iv, encrypting: false, Mode, Padding);
    }
}
