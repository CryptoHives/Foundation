// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// SM4 symmetric cipher implementation (GB/T 32907-2016).
/// </summary>
/// <remarks>
/// <para>
/// SM4 is a 128-bit block cipher with a 128-bit key, standardized by the
/// Chinese national standard GB/T 32907-2016. It uses 32 rounds of a
/// Feistel-like nonlinear transformation.
/// </para>
/// <para>
/// <b>Security level:</b> 128 bits (quantum: 64 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var sm4 = Sm4.Create();
/// sm4.GenerateKey();
/// sm4.GenerateIV();
///
/// byte[] ciphertext = sm4.Encrypt(plaintext);
/// byte[] decrypted = sm4.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class Sm4 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for SM4.
    /// </summary>
    public const int KeySizeBits = 128;

    /// <summary>
    /// Key size in bytes for SM4.
    /// </summary>
    public const int KeySizeBytes = 16;

    /// <summary>
    /// Initializes a new instance of the <see cref="Sm4"/> class.
    /// </summary>
    public Sm4()
    {
        BlockSizeValue = Sm4Core.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(128, 128, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SM4";

    /// <inheritdoc/>
    public override int IVSize => Sm4Core.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Sm4"/> cipher.
    /// </summary>
    /// <returns>A new SM4 cipher instance.</returns>
    public static new Sm4 Create() => new();

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new Sm4CipherTransform(key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new Sm4CipherTransform(key, iv, encrypting: false, Mode, Padding);
    }
}
