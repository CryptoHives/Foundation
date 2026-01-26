// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System.Security.Cryptography;

/// <summary>
/// AES-128 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// AES-128 uses a 128-bit (16-byte) key with 10 rounds of encryption.
/// This is the fastest AES variant and provides adequate security for most applications.
/// </para>
/// <para>
/// <b>Security level:</b> 128 bits (quantum: 64 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var aes = Aes128.Create();
/// aes.GenerateKey();
/// aes.GenerateIV();
///
/// byte[] ciphertext = aes.Encrypt(plaintext);
/// byte[] decrypted = aes.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class Aes128 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for AES-128.
    /// </summary>
    public const int KeySizeBits = 128;

    /// <summary>
    /// Key size in bytes for AES-128.
    /// </summary>
    public const int KeySizeBytes = 16;

    private static readonly KeySizes[] s_legalKeySizes = [new KeySizes(128, 128, 0)];
    private static readonly KeySizes[] s_legalBlockSizes = [new KeySizes(128, 128, 0)];

    /// <summary>
    /// Initializes a new instance of the <see cref="Aes128"/> class.
    /// </summary>
    public Aes128()
    {
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-128";

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
    /// Creates a new instance of the <see cref="Aes128"/> cipher.
    /// </summary>
    /// <returns>A new AES-128 cipher instance.</returns>
    public static Aes128 Create() => new();

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
