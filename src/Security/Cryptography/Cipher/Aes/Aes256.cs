// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System.Security.Cryptography;

/// <summary>
/// AES-256 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// AES-256 uses a 256-bit (32-byte) key with 14 rounds of encryption.
/// It provides the highest security level of all AES variants.
/// </para>
/// <para>
/// <b>Security level:</b> 256 bits (quantum: 128 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Recommendations:</b>
/// <list type="bullet">
///   <item><description>Use AES-256 for long-term security requirements</description></item>
///   <item><description>Required for TOP SECRET data per NSA Suite B</description></item>
///   <item><description>Recommended for post-quantum resistance (Grover's algorithm halves security)</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var aes = Aes256.Create();
/// aes.Mode = CipherMode.CBC;
/// aes.Padding = PaddingMode.PKCS7;
/// aes.GenerateKey();
/// aes.GenerateIV();
///
/// byte[] ciphertext = aes.Encrypt(plaintext);
/// byte[] decrypted = aes.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class Aes256 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for AES-256.
    /// </summary>
    public const int KeySizeBits = 256;

    /// <summary>
    /// Key size in bytes for AES-256.
    /// </summary>
    public const int KeySizeBytes = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="Aes256"/> class.
    /// </summary>
    public Aes256()
    {
        BlockSizeValue = AesCore.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(256, 256, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-256";

    /// <inheritdoc/>
    public override int IVSize => AesCore.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Aes256"/> cipher.
    /// </summary>
    /// <returns>A new AES-256 cipher instance.</returns>
    public static new Aes256 Create() => new();

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(byte[] key, byte[] iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AesCipherTransform(key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(byte[] key, byte[] iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AesCipherTransform(key, iv, encrypting: false, Mode, Padding);
    }
}
