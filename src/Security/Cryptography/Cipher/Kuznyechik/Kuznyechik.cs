// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// Kuznyechik (GOST R 34.12-2015) symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// Kuznyechik is a 128-bit block cipher with a 256-bit key, specified in the
/// Russian Federal standard GOST R 34.12-2015 and documented in RFC 7801.
/// It uses a Substitution-Permutation Network (SPN) structure with 10 rounds.
/// </para>
/// <para>
/// <b>Security level:</b> 256 bits (quantum: 128 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var kuz = Kuznyechik.Create();
/// kuz.Mode = CipherMode.CBC;
/// kuz.Padding = PaddingMode.PKCS7;
/// kuz.GenerateKey();
/// kuz.GenerateIV();
///
/// byte[] ciphertext = kuz.Encrypt(plaintext);
/// byte[] decrypted = kuz.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class Kuznyechik : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for Kuznyechik.
    /// </summary>
    public const int KeySizeBits = 256;

    /// <summary>
    /// Key size in bytes for Kuznyechik.
    /// </summary>
    public const int KeySizeBytes = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="Kuznyechik"/> class.
    /// </summary>
    public Kuznyechik()
    {
        BlockSizeValue = KuznyechikCore.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(256, 256, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Kuznyechik";

    /// <inheritdoc/>
    public override int IVSize => KuznyechikCore.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Kuznyechik"/> cipher.
    /// </summary>
    /// <returns>A new Kuznyechik cipher instance.</returns>
    public static new Kuznyechik Create() => new();

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new KuznyechikCipherTransform(key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new KuznyechikCipherTransform(key, iv, encrypting: false, Mode, Padding);
    }
}
