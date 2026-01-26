// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// ChaCha20 stream cipher implementation as specified in RFC 8439.
/// </summary>
/// <remarks>
/// <para>
/// ChaCha20 is a high-speed stream cipher designed by Daniel J. Bernstein.
/// It uses a 256-bit key and a 96-bit nonce (IETF variant).
/// </para>
/// <para>
/// <b>Security properties:</b>
/// <list type="bullet">
///   <item><description>256-bit security level</description></item>
///   <item><description>No weak keys</description></item>
///   <item><description>Resistant to timing attacks (no table lookups)</description></item>
///   <item><description>Efficient in software on all platforms</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair. Each encryption must use
/// a unique nonce with the same key.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var chacha = ChaCha20.Create();
/// chacha.GenerateKey();
/// chacha.GenerateIV(); // Generates 12-byte nonce
///
/// byte[] ciphertext = chacha.Encrypt(plaintext);
/// byte[] decrypted = chacha.Decrypt(ciphertext);
/// </code>
/// </para>
/// </remarks>
public sealed class ChaCha20 : SymmetricCipher
{
    /// <summary>
    /// Key size in bits for ChaCha20 (256 bits).
    /// </summary>
    public const int KeySizeBits = 256;

    /// <summary>
    /// Key size in bytes for ChaCha20 (32 bytes).
    /// </summary>
    public const int KeySizeConst = 32;

    /// <summary>
    /// Nonce size in bytes for ChaCha20 IETF variant (12 bytes).
    /// </summary>
    public const int NonceSizeConst = 12;

    private static readonly KeySizes[] s_legalKeySizes = [new KeySizes(256, 256, 0)];
    private static readonly KeySizes[] s_legalBlockSizes = [new KeySizes(512, 512, 0)];

    private uint _initialCounter;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChaCha20"/> class.
    /// </summary>
    public ChaCha20()
    {
        Mode = CipherMode.Stream;
        Padding = PaddingMode.None;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "ChaCha20";

    /// <inheritdoc/>
    public override int BlockSize => ChaChaCore.BlockSizeBytes * 8; // 512 bits

    /// <inheritdoc/>
    public override int KeySize => KeySizeBits;

    /// <inheritdoc/>
    public override KeySizes[] LegalKeySizes => s_legalKeySizes;

    /// <inheritdoc/>
    public override KeySizes[] LegalBlockSizes => s_legalBlockSizes;

    /// <inheritdoc/>
    public override int IVSize => NonceSizeConst;

    /// <summary>
    /// Gets or sets the initial block counter value.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The default value is 0. Some protocols (like TLS) use 1 as the initial counter.
    /// </para>
    /// <para>
    /// For ChaCha20-Poly1305 AEAD, the counter typically starts at 1 because
    /// counter 0 is used to generate the Poly1305 key.
    /// </para>
    /// </remarks>
    public uint InitialCounter
    {
        get => _initialCounter;
        set => _initialCounter = value;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ChaCha20"/> cipher.
    /// </summary>
    /// <returns>A new ChaCha20 cipher instance.</returns>
    public static ChaCha20 Create() => new();

    /// <inheritdoc/>
    public override ICipherTransform CreateEncryptor(byte[] key, byte[] iv)
    {
        ValidateKeySize(key.Length * 8);
        ValidateIVSize(iv.Length);
        return new ChaCha20CipherTransform(key, iv, _initialCounter);
    }

    /// <inheritdoc/>
    public override ICipherTransform CreateDecryptor(byte[] key, byte[] iv)
    {
        // ChaCha20 is symmetric - encryption and decryption are the same
        return CreateEncryptor(key, iv);
    }

    /// <inheritdoc/>
    protected override void ValidateIVSize(int byteLength)
    {
        if (byteLength != NonceSizeConst)
        {
            throw new CryptographicException($"Invalid nonce size: {byteLength} bytes. Expected: {NonceSizeConst} bytes.");
        }
    }

    /// <inheritdoc/>
    protected override int CalculateOutputSize(int inputLength, bool encrypting)
    {
        // Stream cipher - output size equals input size
        return inputLength;
    }
}
