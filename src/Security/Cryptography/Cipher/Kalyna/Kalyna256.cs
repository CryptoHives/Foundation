// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// Kalyna-256 symmetric cipher implementation (DSTU 7624:2014) with 128-bit block.
/// </summary>
/// <remarks>
/// <para>
/// Kalyna-256 uses a 128-bit block with a 256-bit key (14 rounds).
/// This provides a higher security margin than Kalyna-128.
/// </para>
/// </remarks>
public sealed class Kalyna256 : SymmetricCipher
{
    /// <summary>Key size in bits.</summary>
    public const int KeySizeBits = 256;

    /// <summary>Key size in bytes.</summary>
    public const int KeySizeBytes = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="Kalyna256"/> class.
    /// </summary>
    public Kalyna256()
    {
        BlockSizeValue = 128;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(256, 256, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Kalyna-256";

    /// <inheritdoc/>
    public override int IVSize => 16;

    /// <summary>Creates a new instance of the <see cref="Kalyna256"/> cipher.</summary>
    public static new Kalyna256 Create() => new();

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
