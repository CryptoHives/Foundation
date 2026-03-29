// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// Camellia-256 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// Camellia-256 uses a 256-bit (32-byte) key with 24 rounds of encryption.
/// It is specified in RFC 3713 and ISO/IEC 18033-3.
/// </para>
/// <para>
/// <b>Security level:</b> 256 bits (quantum: 128 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Recommendations:</b>
/// <list type="bullet">
///   <item><description>Use Camellia-256 for long-term security requirements.</description></item>
///   <item><description>Recommended for post-quantum resistance (Grover's algorithm halves security).</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var camellia = Camellia256.Create();
/// camellia.Mode = CipherMode.CBC;
/// camellia.Padding = PaddingMode.PKCS7;
/// camellia.GenerateKey();
/// camellia.GenerateIV();
///
/// byte[] ciphertext = camellia.Encrypt(plaintext);
/// byte[] decrypted = camellia.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class Camellia256 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for Camellia-256.
    /// </summary>
    public const int KeySizeBits = 256;

    /// <summary>
    /// Key size in bytes for Camellia-256.
    /// </summary>
    public const int KeySizeBytes = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="Camellia256"/> class.
    /// </summary>
    public Camellia256()
    {
        BlockSizeValue = CamelliaCore.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(256, 256, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Camellia-256";

    /// <inheritdoc/>
    public override int IVSize => CamelliaCore.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Camellia256"/> cipher.
    /// </summary>
    /// <returns>A new Camellia-256 cipher instance.</returns>
    public static new Camellia256 Create() => new();

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new CamelliaCipherTransform(key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new CamelliaCipherTransform(key, iv, encrypting: false, Mode, Padding);
    }
}
