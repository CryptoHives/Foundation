// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// AES-128 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// AES-128 uses a 128-bit (16-byte) key with 10 rounds of encryption.
/// This is the fastest AES variant and provides adequate security for most applications.
/// </para>
/// <para>
/// <b>Security level:</b> 128 bits (quantum: 64 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var aes = Aes128.Create();
/// aes.GenerateKey();
/// aes.GenerateIV();
///
/// byte[] ciphertext = aes.Encrypt(plaintext);
/// byte[] decrypted = aes.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class Aes128 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for AES-128.
    /// </summary>
    public const int KeySizeBits = 128;

    /// <summary>
    /// Key size in bytes for AES-128.
    /// </summary>
    public const int KeySizeBytes = 16;

    private readonly SimdSupport _simdSupport;

    /// <summary>
    /// Initializes a new instance of the <see cref="Aes128"/> class.
    /// </summary>
    public Aes128() : this(SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Aes128"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    internal Aes128(SimdSupport simdSupport)
    {
        _simdSupport = simdSupport & SimdSupport;
        BlockSizeValue = AesCore.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(128, 128, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-128";

    /// <inheritdoc/>
    public override int IVSize => AesCore.BlockSizeBytes;

    /// <summary>
    /// Gets the SIMD instruction sets supported by AES on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => AesCipherTransform.SimdSupport;

    /// <summary>
    /// Creates a new instance of the <see cref="Aes128"/> cipher.
    /// </summary>
    /// <returns>A new AES-128 cipher instance.</returns>
    public static new Aes128 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Aes128"/> cipher with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <returns>A new AES-128 cipher instance.</returns>
    internal static Aes128 Create(SimdSupport simdSupport) => new(simdSupport);

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AesCipherTransform(_simdSupport, key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AesCipherTransform(_simdSupport, key, iv, encrypting: false, Mode, Padding);
    }
}
