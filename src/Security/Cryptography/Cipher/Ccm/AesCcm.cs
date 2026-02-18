// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif

/// <summary>
/// AES-CCM (Counter with CBC-MAC) authenticated encryption implementation.
/// </summary>
/// <remarks>
/// <para>
/// AES-CCM provides authenticated encryption with associated data (AEAD) by combining
/// CBC-MAC for authentication with CTR mode for encryption. It is widely used in
/// wireless protocols (802.11i, Bluetooth LE), IoT, and constrained environments.
/// </para>
/// <para>
/// <b>Specification:</b> RFC 3610, NIST SP 800-38C
/// </para>
/// <para>
/// <b>Security properties:</b>
/// <list type="bullet">
///   <item><description>Authenticated encryption with associated data (AEAD)</description></item>
///   <item><description>Authenticate-then-encrypt construction</description></item>
///   <item><description>Variable tag length (4-16 bytes, even values)</description></item>
///   <item><description>Variable nonce length (7-13 bytes)</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair. Each encryption must use
/// a unique nonce. For typical usage, 12-byte nonces are recommended.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var ccm = AesCcm128.Create(key);
///
/// byte[] nonce = new byte[12];
/// RandomNumberGenerator.Fill(nonce);
///
/// // Encrypt with 16-byte tag
/// byte[] ciphertext = new byte[plaintext.Length];
/// byte[] tag = new byte[16];
/// ccm.Encrypt(nonce, plaintext, ciphertext, tag, associatedData);
///
/// // Decrypt and verify
/// if (ccm.Decrypt(nonce, ciphertext, tag, plaintext, associatedData))
/// {
///     // Authentication successful, plaintext is valid
/// }
/// </code>
/// </para>
/// </remarks>
public abstract class AesCcm : IAeadCipher
{
    private readonly byte[] _key;
    private readonly uint[] _roundKeys;
    private readonly int _rounds;
    private bool _disposed;
#if NET8_0_OR_GREATER
    private readonly Vector128<byte>[]? _niEncRoundKeys;
    private readonly bool _useAesNi;
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm"/> class.
    /// </summary>
    /// <param name="key">The AES key (16, 24, or 32 bytes).</param>
    protected AesCcm(byte[] key) : this(SimdSupport.All, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The AES key (16, 24, or 32 bytes).</param>
    internal AesCcm(SimdSupport simdSupport, byte[] key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));
        if (key.Length != 16 && key.Length != 24 && key.Length != 32)
            throw new ArgumentException("Key must be 16, 24, or 32 bytes.", nameof(key));

        _key = new byte[key.Length];
        Buffer.BlockCopy(key, 0, _key, 0, key.Length);

        // Expand key for AES
        int keyWords = key.Length / 4;
        int totalWords = 4 * (keyWords + 7);
        _roundKeys = new uint[totalWords];
        _rounds = AesCore.ExpandKey(key, _roundKeys);

#if NET8_0_OR_GREATER
        if ((simdSupport & SimdSupport.AesNi) != 0 && AesCoreAesNi.IsSupported)
        {
            _useAesNi = true;
            _niEncRoundKeys = new Vector128<byte>[AesCoreAesNi.MaxRoundKeys];
            AesCoreAesNi.ExpandKey(key, _niEncRoundKeys);
        }
#endif
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by AES-CCM on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport =>
#if NET8_0_OR_GREATER
        AesCoreAesNi.IsSupported ? SimdSupport.AesNi : SimdSupport.None;
#else
        SimdSupport.None;
#endif

    /// <inheritdoc/>
    public abstract string AlgorithmName { get; }

    /// <inheritdoc/>
    public abstract int KeySizeBytes { get; }

    /// <inheritdoc/>
    public int NonceSizeBytes => 12; // Recommended default

    /// <inheritdoc/>
    public int TagSizeBytes => 16; // Default to maximum

    /// <summary>
    /// Encrypts plaintext and computes authentication tag.
    /// </summary>
    /// <param name="nonce">The nonce (7-13 bytes, typically 12).</param>
    /// <param name="plaintext">The plaintext to encrypt.</param>
    /// <param name="ciphertext">Output buffer for ciphertext (must be same size as plaintext).</param>
    /// <param name="tag">Output buffer for authentication tag (4-16 bytes, even).</param>
    /// <param name="associatedData">Additional authenticated data (optional).</param>
    public void Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext,
        Span<byte> tag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertext.Length < plaintext.Length)
            throw new ArgumentException("Ciphertext buffer too small.", nameof(ciphertext));

        CcmCore.Encrypt(
            nonce,
            plaintext,
            associatedData,
            ciphertext.Slice(0, plaintext.Length),
            tag,
            _roundKeys,
            _rounds
#if NET8_0_OR_GREATER
            , _useAesNi, _niEncRoundKeys
#endif
            );
    }

    /// <summary>
    /// Decrypts ciphertext and verifies authentication tag.
    /// </summary>
    /// <param name="nonce">The nonce (7-13 bytes, typically 12).</param>
    /// <param name="ciphertext">The ciphertext to decrypt.</param>
    /// <param name="tag">The authentication tag to verify (4-16 bytes, even).</param>
    /// <param name="plaintext">Output buffer for plaintext (must be same size as ciphertext).</param>
    /// <param name="associatedData">Additional authenticated data (optional).</param>
    /// <returns>True if authentication succeeded; otherwise false.</returns>
    public bool Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertext,
        ReadOnlySpan<byte> tag,
        Span<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        bool success = CcmCore.Decrypt(
            nonce,
            ciphertext,
            tag,
            associatedData,
            plaintext.Slice(0, ciphertext.Length),
            _roundKeys,
            _rounds
#if NET8_0_OR_GREATER
            , _useAesNi, _niEncRoundKeys
#endif
            );

        if (!success)
        {
            plaintext.Slice(0, ciphertext.Length).Clear();
        }

        return success;
    }

    /// <inheritdoc/>
    public byte[] Encrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> plaintext,
        ReadOnlySpan<byte> associatedData = default)
    {
        byte[] result = new byte[plaintext.Length + TagSizeBytes];
        Encrypt(nonce, plaintext, result.AsSpan(0, plaintext.Length),
                result.AsSpan(plaintext.Length, TagSizeBytes), associatedData);
        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(
        ReadOnlySpan<byte> nonce,
        ReadOnlySpan<byte> ciphertextWithTag,
        ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertextWithTag.Length < TagSizeBytes)
            throw new CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSizeBytes;
        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertextWithTag.Slice(0, ciphertextLength),
                    ciphertextWithTag.Slice(ciphertextLength, TagSizeBytes),
                    plaintext, associatedData))
        {
            throw new CryptographicException("Authentication tag mismatch.");
        }

        return plaintext;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases resources used by this instance.
    /// </summary>
    /// <param name="disposing">True if called from <see cref="Dispose()"/>, false if from finalizer.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                Array.Clear(_key, 0, _key.Length);
            }

            _disposed = true;
        }
    }
}
