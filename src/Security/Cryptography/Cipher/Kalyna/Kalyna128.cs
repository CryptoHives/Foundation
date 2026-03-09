// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// Kalyna-128 symmetric cipher implementation (DSTU 7624:2014).
/// </summary>
/// <remarks>
/// <para>
/// Kalyna-128 is the Ukrainian national standard block cipher using a
/// 128-bit block with a 128-bit key (10 rounds).
/// </para>
/// </remarks>
public sealed class Kalyna128 : SymmetricCipher
{
    /// <summary>Key size in bits.</summary>
    public const int KeySizeBits = 128;

    /// <summary>Key size in bytes.</summary>
    public const int KeySizeBytes = 16;

    /// <summary>
    /// Initializes a new instance of the <see cref="Kalyna128"/> class.
    /// </summary>
    public Kalyna128()
    {
        BlockSizeValue = 128;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(128, 128, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Kalyna-128";

    /// <inheritdoc/>
    public override int IVSize => 16;

    /// <summary>Creates a new instance of the <see cref="Kalyna128"/> cipher.</summary>
    public static new Kalyna128 Create() => new();

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new KalynaCipherTransform(key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new KalynaCipherTransform(key, iv, encrypting: false, Mode, Padding);
    }
}
