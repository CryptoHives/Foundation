// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// ARIA-192 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// ARIA-192 is the Korean national standard block cipher (KS X 1213)
/// using a 192-bit key with 14 rounds of encryption.
/// </para>
/// </remarks>
public sealed class Aria192 : SymmetricCipher
{
    /// <summary>Key size in bits for ARIA-192.</summary>
    public const int KeySizeBits = 192;

    /// <summary>Key size in bytes for ARIA-192.</summary>
    public const int KeySizeBytes = 24;

    /// <summary>
    /// Initializes a new instance of the <see cref="Aria192"/> class.
    /// </summary>
    public Aria192()
    {
        BlockSizeValue = 128;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(192, 192, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "ARIA-192";

    /// <inheritdoc/>
    public override int IVSize => 16;

    /// <summary>Creates a new instance of the <see cref="Aria192"/> cipher.</summary>
    /// <returns>A new ARIA-192 cipher instance.</returns>
    public static new Aria192 Create() => new();

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
