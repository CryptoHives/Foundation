// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// Camellia-192 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// Camellia-192 uses a 192-bit (24-byte) key with 24 rounds of encryption.
/// It is specified in RFC 3713 and ISO/IEC 18033-3.
/// </para>
/// <para>
/// <b>Security level:</b> 192 bits (quantum: 96 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Note:</b> Camellia-192 uses the same 24-round structure as Camellia-256.
/// The 192-bit key is internally expanded to 256 bits by complementing
/// the rightmost 64 bits to form the second 128-bit key half.
/// </para>
/// </remarks>
public sealed class Camellia192 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for Camellia-192.
    /// </summary>
    public const int KeySizeBits = 192;

    /// <summary>
    /// Key size in bytes for Camellia-192.
    /// </summary>
    public const int KeySizeBytes = 24;

    /// <summary>
    /// Initializes a new instance of the <see cref="Camellia192"/> class.
    /// </summary>
    public Camellia192()
    {
        BlockSizeValue = CamelliaCore.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(192, 192, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Camellia-192";

    /// <inheritdoc/>
    public override int IVSize => CamelliaCore.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Camellia192"/> cipher.
    /// </summary>
    /// <returns>A new Camellia-192 cipher instance.</returns>
    public static new Camellia192 Create() => new();

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
