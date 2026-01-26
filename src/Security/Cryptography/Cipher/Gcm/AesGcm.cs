// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// AES-GCM (Galois/Counter Mode) authenticated encryption implementation.
/// </summary>
/// <remarks>
/// <para>
/// AES-GCM provides authenticated encryption with associated data (AEAD).
/// It is widely used in TLS 1.3, IPsec, and other security protocols.
/// </para>
/// <para>
/// <b>Security properties:</b>
/// <list type="bullet">
///   <item><description>Confidentiality via AES-CTR mode</description></item>
///   <item><description>Authenticity via GHASH universal hash</description></item>
///   <item><description>Support for additional authenticated data (AAD)</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair. Each encryption must use
/// a unique nonce. For random nonces, 96-bit (12-byte) nonces are recommended.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var aesGcm = AesGcm256.Create(key);
///
/// // Encrypt
/// byte[] ciphertext = aesGcm.Encrypt(nonce, plaintext, associatedData);
///
/// // Decrypt
/// byte[] plaintext = aesGcm.Decrypt(nonce, ciphertext, associatedData);
/// </code>
/// </para>
/// </remarks>
public abstract class AesGcm : IAeadCipher
{
    private readonly byte[] _key;
    private readonly byte[] _h; // Hash subkey
    private readonly uint[] _encRoundKeys;
    private readonly int _rounds;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm"/> class.
    /// </summary>
    /// <param name="key">The AES key (16, 24, or 32 bytes).</param>
    protected AesGcm(byte[] key)
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
        _encRoundKeys = new uint[totalWords];
        _rounds = AesCore.ExpandKey(key, _encRoundKeys);

        // Compute hash subkey H = AES(K, 0^128)
        _h = new byte[GcmCore.BlockSizeBytes];
        Span<byte> zeroBlock = stackalloc byte[GcmCore.BlockSizeBytes];
        zeroBlock.Clear();
        AesCore.EncryptBlock(zeroBlock, _h, _encRoundKeys, _rounds);
    }

    /// <inheritdoc/>
    public abstract string AlgorithmName { get; }

    /// <inheritdoc/>
    public int KeySizeBytes => _key.Length;

    /// <inheritdoc/>
    public int NonceSizeBytes => GcmCore.NonceSizeBytes;

    /// <inheritdoc/>
    public int TagSizeBytes => GcmCore.TagSizeBytes;

    /// <inheritdoc/>
    public void Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
                        Span<byte> ciphertext, Span<byte> tag,
                        ReadOnlySpan<byte> associatedData = default)
    {
        if (nonce.Length == 0)
            throw new ArgumentException("Nonce cannot be empty.", nameof(nonce));
        if (ciphertext.Length < plaintext.Length)
            throw new ArgumentException("Ciphertext buffer too small.", nameof(ciphertext));
        if (tag.Length < TagSizeBytes)
            throw new ArgumentException("Tag buffer too small.", nameof(tag));

        // Compute J0 (initial counter block)
        Span<byte> j0 = stackalloc byte[GcmCore.BlockSizeBytes];
        GcmCore.ComputeJ0(_h, nonce, j0);

        // Compute initial counter for encryption (J0 + 1)
        Span<byte> icb = stackalloc byte[GcmCore.BlockSizeBytes];
        j0.CopyTo(icb);
        IncrementCounter(icb);

        // Encrypt plaintext using GCTR
        GcmCore.GctrAes(_encRoundKeys, _rounds, icb, plaintext, ciphertext);

        // Compute GHASH over AAD and ciphertext
        Span<byte> ghash = stackalloc byte[GcmCore.BlockSizeBytes];
        GcmCore.GHashComplete(_h, associatedData, ciphertext.Slice(0, plaintext.Length), ghash);

        // Compute tag: T = GCTR(J0, GHASH(H, A, C))
        Span<byte> fullTag = stackalloc byte[GcmCore.BlockSizeBytes];
        GcmCore.GctrAes(_encRoundKeys, _rounds, j0, ghash, fullTag);

        // Copy tag to output (truncate if necessary)
        fullTag.Slice(0, tag.Length).CopyTo(tag);
    }

    /// <inheritdoc/>
    public bool Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext,
                        ReadOnlySpan<byte> tag, Span<byte> plaintext,
                        ReadOnlySpan<byte> associatedData = default)
    {
        if (nonce.Length == 0)
            throw new ArgumentException("Nonce cannot be empty.", nameof(nonce));
        if (tag.Length != TagSizeBytes)
            throw new ArgumentException($"Tag must be {TagSizeBytes} bytes.", nameof(tag));
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        // Compute J0
        Span<byte> j0 = stackalloc byte[GcmCore.BlockSizeBytes];
        GcmCore.ComputeJ0(_h, nonce, j0);

        // Compute GHASH over AAD and ciphertext
        Span<byte> ghash = stackalloc byte[GcmCore.BlockSizeBytes];
        GcmCore.GHashComplete(_h, associatedData, ciphertext, ghash);

        // Compute expected tag
        Span<byte> expectedTag = stackalloc byte[GcmCore.BlockSizeBytes];
        GcmCore.GctrAes(_encRoundKeys, _rounds, j0, ghash, expectedTag);

        // Verify tag in constant time
        if (!CryptoUtils.FixedTimeEquals(tag, expectedTag.Slice(0, tag.Length)))
        {
            // Clear plaintext buffer on failure
            plaintext.Slice(0, ciphertext.Length).Clear();
            return false;
        }

        // Decrypt ciphertext
        Span<byte> icb = stackalloc byte[GcmCore.BlockSizeBytes];
        j0.CopyTo(icb);
        IncrementCounter(icb);
        GcmCore.GctrAes(_encRoundKeys, _rounds, icb, ciphertext, plaintext);

        return true;
    }

    /// <inheritdoc/>
    public byte[] Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
                          ReadOnlySpan<byte> associatedData = default)
    {
        byte[] result = new byte[plaintext.Length + TagSizeBytes];
        Span<byte> ciphertext = result.AsSpan(0, plaintext.Length);
        Span<byte> tag = result.AsSpan(plaintext.Length, TagSizeBytes);

        Encrypt(nonce, plaintext, ciphertext, tag, associatedData);

        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertextWithTag,
                          ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertextWithTag.Length < TagSizeBytes)
            throw new CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSizeBytes;
        ReadOnlySpan<byte> ciphertext = ciphertextWithTag.Slice(0, ciphertextLength);
        ReadOnlySpan<byte> tag = ciphertextWithTag.Slice(ciphertextLength, TagSizeBytes);

        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertext, tag, plaintext, associatedData))
        {
            throw new CryptographicException("Authentication failed.");
        }

        return plaintext;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            Array.Clear(_key, 0, _key.Length);
            Array.Clear(_h, 0, _h.Length);
            Array.Clear(_encRoundKeys, 0, _encRoundKeys.Length);
            _disposed = true;
        }
    }

    private static void IncrementCounter(Span<byte> counter)
    {
        for (int i = 15; i >= 12; i--)
        {
            if (++counter[i] != 0)
                break;
        }
    }
}

/// <summary>
/// AES-128-GCM authenticated encryption.
/// </summary>
public sealed class AesGcm128 : AesGcm
{
    /// <summary>
    /// Key size in bytes for AES-128-GCM.
    /// </summary>
    public const int KeySize = 16;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm128"/> class.
    /// </summary>
    /// <param name="key">The 16-byte AES key.</param>
    public AesGcm128(byte[] key) : base(key)
    {
        if (key.Length != KeySize)
            throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-128-GCM";

    /// <summary>
    /// Creates a new AES-128-GCM instance.
    /// </summary>
    /// <param name="key">The 16-byte key.</param>
    /// <returns>A new AES-128-GCM instance.</returns>
    public static AesGcm128 Create(byte[] key) => new(key);
}

/// <summary>
/// AES-192-GCM authenticated encryption.
/// </summary>
public sealed class AesGcm192 : AesGcm
{
    /// <summary>
    /// Key size in bytes for AES-192-GCM.
    /// </summary>
    public const int KeySize = 24;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm192"/> class.
    /// </summary>
    /// <param name="key">The 24-byte AES key.</param>
    public AesGcm192(byte[] key) : base(key)
    {
        if (key.Length != KeySize)
            throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-192-GCM";

    /// <summary>
    /// Creates a new AES-192-GCM instance.
    /// </summary>
    /// <param name="key">The 24-byte key.</param>
    /// <returns>A new AES-192-GCM instance.</returns>
    public static AesGcm192 Create(byte[] key) => new(key);
}

/// <summary>
/// AES-256-GCM authenticated encryption.
/// </summary>
public sealed class AesGcm256 : AesGcm
{
    /// <summary>
    /// Key size in bytes for AES-256-GCM.
    /// </summary>
    public const int KeySize = 32;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm256"/> class.
    /// </summary>
    /// <param name="key">The 32-byte AES key.</param>
    public AesGcm256(byte[] key) : base(key)
    {
        if (key.Length != KeySize)
            throw new ArgumentException($"Key must be {KeySize} bytes.", nameof(key));
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "AES-256-GCM";

    /// <summary>
    /// Creates a new AES-256-GCM instance.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <returns>A new AES-256-GCM instance.</returns>
    public static AesGcm256 Create(byte[] key) => new(key);
}
