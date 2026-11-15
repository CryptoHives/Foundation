// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// Magma (GOST R 34.12-2015, RFC 8891) symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// Magma is a 64-bit block cipher with a 256-bit key: the GOST 28147-89 Feistel network with the
/// S-boxes fixed to id-tc26-gost-28147-param-Z and big-endian block and key order. It is not
/// interchangeable with GOST 28147-89 implementations that use other S-boxes or byte orders.
/// </para>
/// <para>
/// <b>Block size:</b> with 64-bit blocks, ciphertext blocks start to collide after about 2^32 of
/// them (32 GiB), so one key should protect far less data than that.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var magma = Magma.Create();
/// magma.Mode = CipherMode.CBC;
/// magma.Padding = PaddingMode.PKCS7;
/// magma.GenerateKey();
/// magma.GenerateIV();
///
/// byte[] ciphertext = magma.Encrypt(plaintext);
/// byte[] decrypted = magma.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class Magma : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for Magma.
    /// </summary>
    public const int KeySizeBits = 256;

    /// <summary>
    /// Key size in bytes for Magma.
    /// </summary>
    public const int KeySizeBytes = MagmaCore.KeySizeBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="Magma"/> class.
    /// </summary>
    public Magma()
    {
        BlockSizeValue = MagmaCore.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = LegalSizes.Bits256;
        LegalBlockSizesValue = LegalSizes.Bits64;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Magma";

    /// <inheritdoc/>
    public override int IVSize => MagmaCore.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Magma"/> cipher.
    /// </summary>
    /// <returns>A new Magma cipher instance.</returns>
    public static new Magma Create() => new();

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new MagmaCipherTransform(key, iv, encrypting: true, Mode, Padding, FeedbackSize / 8);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new MagmaCipherTransform(key, iv, encrypting: false, Mode, Padding, FeedbackSize / 8);
    }
}
