// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// Camellia-128 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// Camellia-128 uses a 128-bit (16-byte) key with 18 rounds of encryption.
/// It is specified in RFC 3713 and ISO/IEC 18033-3.
/// </para>
/// <para>
/// <b>Security level:</b> 128 bits (quantum: 64 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var camellia = Camellia128.Create();
/// camellia.GenerateKey();
/// camellia.GenerateIV();
///
/// byte[] ciphertext = camellia.Encrypt(plaintext);
/// byte[] decrypted = camellia.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class Camellia128 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for Camellia-128.
    /// </summary>
    public const int KeySizeBits = 128;

    /// <summary>
    /// Key size in bytes for Camellia-128.
    /// </summary>
    public const int KeySizeBytes = 16;

    /// <summary>
    /// Initializes a new instance of the <see cref="Camellia128"/> class.
    /// </summary>
    public Camellia128()
    {
        BlockSizeValue = CamelliaCore.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(128, 128, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Camellia-128";

    /// <inheritdoc/>
    public override int IVSize => CamelliaCore.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Camellia128"/> cipher.
    /// </summary>
    /// <returns>A new Camellia-128 cipher instance.</returns>
    public static new Camellia128 Create() => new();

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
