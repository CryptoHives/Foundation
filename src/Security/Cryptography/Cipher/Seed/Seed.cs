// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// SEED symmetric cipher implementation (KISA, RFC 4269).
/// </summary>
/// <remarks>
/// <para>
/// SEED is a 128-bit block cipher with a 128-bit key, developed by KISA
/// (Korea Information Security Agency) and standardized as a Korean national
/// standard (TTAS.KO-12.0004). It uses a 16-round Feistel structure.
/// </para>
/// <para>
/// <b>Security level:</b> 128 bits (quantum: 64 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var seed = Seed.Create();
/// seed.GenerateKey();
/// seed.GenerateIV();
///
/// byte[] ciphertext = seed.Encrypt(plaintext);
/// byte[] decrypted = seed.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class Seed : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for SEED.
    /// </summary>
    public const int KeySizeBits = 128;

    /// <summary>
    /// Key size in bytes for SEED.
    /// </summary>
    public const int KeySizeBytes = 16;

    /// <summary>
    /// Initializes a new instance of the <see cref="Seed"/> class.
    /// </summary>
    public Seed()
    {
        BlockSizeValue = SeedCore.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(128, 128, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SEED";

    /// <inheritdoc/>
    public override int IVSize => SeedCore.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Seed"/> cipher.
    /// </summary>
    /// <returns>A new SEED cipher instance.</returns>
    public static new Seed Create() => new();

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new SeedCipherTransform(key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new SeedCipherTransform(key, iv, encrypting: false, Mode, Padding);
    }
}
