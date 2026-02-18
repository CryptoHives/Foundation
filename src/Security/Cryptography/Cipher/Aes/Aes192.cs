// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System.Security.Cryptography;

/// <summary>
/// AES-192 symmetric cipher implementation.
/// </summary>
/// <remarks>
/// <para>
/// AES-192 uses a 192-bit (24-byte) key with 12 rounds of encryption.
/// It provides a balance between security and performance.
/// </para>
/// <para>
/// <b>Security level:</b> 192 bits (quantum: 96 bits with Grover's algorithm)
/// </para>
/// <para>
/// <b>Note:</b> AES-192 is less commonly used than AES-128 or AES-256.
/// Some standards and implementations do not support it.
/// </para>
/// </remarks>
public sealed class Aes192 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for AES-192.
    /// </summary>
    public const int KeySizeBits = 192;

    /// <summary>
    /// Key size in bytes for AES-192.
    /// </summary>
    public const int KeySizeBytes = 24;

    private readonly SimdSupport _simdSupport;

    /// <summary>
    /// Initializes a new instance of the <see cref="Aes192"/> class.
    /// </summary>
    public Aes192() : this(SimdSupport.All)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Aes192"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    internal Aes192(SimdSupport simdSupport)
    {
        _simdSupport = simdSupport & SimdSupport;
        BlockSizeValue = AesCore.BlockSizeBits;
        KeySizeValue = KeySizeBits;
        LegalKeySizesValue = [new KeySizes(192, 192, 0)];
        LegalBlockSizesValue = [new KeySizes(128, 128, 0)];
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by AES on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => AesCipherTransform.SimdSupport;

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-192";

    /// <inheritdoc/>
    public override int IVSize => AesCore.BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Aes192"/> cipher.
    /// </summary>
    /// <returns>A new AES-192 cipher instance.</returns>
    public static new Aes192 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Aes192"/> cipher with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <returns>A new AES-192 cipher instance.</returns>
    internal static Aes192 Create(SimdSupport simdSupport) => new(simdSupport);

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(byte[] key, byte[] iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AesCipherTransform(_simdSupport, key, iv, encrypting: true, Mode, Padding);
    }

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(byte[] key, byte[] iv)
    {
        ValidateKeySize(key.Length * 8);
        return new AesCipherTransform(_simdSupport, key, iv, encrypting: false, Mode, Padding);
    }
}
