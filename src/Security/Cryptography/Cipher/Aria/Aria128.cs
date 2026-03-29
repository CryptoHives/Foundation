// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// ARIA-128 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// ARIA-128 is the Korean national standard block cipher (KS X 1213)
/// using a 128-bit key with 12 rounds of encryption.
/// </para>
/// </remarks>
public sealed class Aria128 : SymmetricCipher
{
    /// <summary>Key size in bits for ARIA-128.</summary>
    public const int KeySizeBits = 128;

    /// <summary>Key size in bytes for ARIA-128.</summary>
    public const int KeySizeBytes = 16;

    /// <summary>
    /// Initializes a new instance of the <see cref="Aria128"/> class.
    /// </summary>
    public Aria128()
    {
        BlockSizeValue = 128;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(128, 128, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "ARIA-128";

    /// <inheritdoc/>
    public override int IVSize => 16;

    /// <summary>Creates a new instance of the <see cref="Aria128"/> cipher.</summary>
    /// <returns>A new ARIA-128 cipher instance.</returns>
    public static new Aria128 Create() => new();

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AriaCipherTransform(key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AriaCipherTransform(key, iv, encrypting: false, Mode, Padding);
    }
}
