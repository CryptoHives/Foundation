// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// Kalyna-512 symmetric cipher implementation (DSTU 7624:2014).
/// </summary>
/// <remarks>
/// <para>
/// Kalyna-512 uses a 256-bit block with a 512-bit key (18 rounds).
/// This is the widest Kalyna configuration supported by the standard.
/// </para>
/// </remarks>
public sealed class Kalyna512 : SymmetricCipher
{
    /// <summary>Block size in bits.</summary>
    public const int BlockSizeBits = 256;

    /// <summary>Block size in bytes.</summary>
    public const int BlockSizeBytes = 32;

    /// <summary>Key size in bits.</summary>
    public const int KeySizeBits = 512;

    /// <summary>Key size in bytes.</summary>
    public const int KeySizeBytes = 64;

    /// <summary>
    /// Initializes a new instance of the <see cref="Kalyna512"/> class.
    /// </summary>
    public Kalyna512()
    {
        BlockSizeValue = BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(256, 256, 0), new KeySizes(512, 512, 0)];
        LegalBlockSizesValue = [new KeySizes(BlockSizeBits, BlockSizeBits, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Kalyna-512";

    /// <inheritdoc/>
    public override int IVSize => BlockSizeBytes;

    /// <inheritdoc/>
    public override byte[] Key
    {
        get => base.Key;
        set
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            if (value.Length != KeySizeBytes)
                throw new CryptographicException($"Invalid key size: {value.Length * 8} bits. Expected: {KeySizeBits} bits.");

            KeySizeValue = KeySizeBits;
            KeyValue = (byte[])value.Clone();
        }
    }

    /// <summary>Creates a new instance of the <see cref="Kalyna512"/> cipher.</summary>
    public static new Kalyna512 Create() => new();

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new KalynaCipherTransform(key, iv, encrypting: true, Mode, Padding, BlockSizeBytes);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new KalynaCipherTransform(key, iv, encrypting: false, Mode, Padding, BlockSizeBytes);
    }
}
