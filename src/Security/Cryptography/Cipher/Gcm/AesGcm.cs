// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Security.Cryptography;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif

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
    private readonly ulong _h0; // High 64 bits of H (avoids byte→ulong conversion in hot path)
    private readonly ulong _h1; // Low 64 bits of H
    private readonly ulong[] _shoupTable; // Precomputed 4-bit Shoup multiplication table
    private readonly uint[] _encRoundKeys;
    private readonly int _rounds;
    private bool _disposed;
#if NET8_0_OR_GREATER
    private readonly Vector128<byte>[]? _niEncRoundKeys;
    private readonly bool _useAesNi;
    private readonly Vector128<byte> _hClmul;
    private readonly bool _useClmul;
    private readonly Vector128<byte>[]? _hPowers;
    private readonly bool _usePipeline;
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm"/> class.
    /// </summary>
    /// <param name="key">The AES key (16, 24, or 32 bytes).</param>
    protected AesGcm(byte[] key) : this(SimdSupport.All, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The AES key (16, 24, or 32 bytes).</param>
    internal AesGcm(SimdSupport simdSupport, byte[] key)
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

#if NET8_0_OR_GREATER
        if ((simdSupport & SimdSupport.AesNi) != 0 && AesCoreAesNi.IsSupported)
        {
            _useAesNi = true;
            _niEncRoundKeys = new Vector128<byte>[AesCoreAesNi.MaxRoundKeys];
            AesCoreAesNi.ExpandKey(key, _niEncRoundKeys);
            AesCoreAesNi.EncryptBlock(zeroBlock, _h, _niEncRoundKeys, _rounds);
        }
        else
#endif
        {
            AesCore.EncryptBlock(zeroBlock, _h, _encRoundKeys, _rounds);
        }

        // Store H as ulongs for the optimized GHASH path
        _h0 = BinaryPrimitives.ReadUInt64BigEndian(_h.AsSpan(0));
        _h1 = BinaryPrimitives.ReadUInt64BigEndian(_h.AsSpan(sizeof(UInt64)));

        // Precompute 4-bit Shoup table for fast GF(2^128) multiplication
        _shoupTable = GcmCore.BuildShoupTable(_h0, _h1);

#if NET8_0_OR_GREATER
        if (GcmCore.IsClmulSupported)
        {
            _useClmul = true;
            _hClmul = GcmCore.PrepareH(_h);

            if (GcmCore.IsPipelineSupported && _useAesNi)
            {
                _usePipeline = true;
                _hPowers = GcmCore.PrepareHPowers(_hClmul);
            }
        }
#endif
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

        Span<byte> ghash = stackalloc byte[GcmCore.BlockSizeBytes];

#if NET8_0_OR_GREATER
        if (_usePipeline)
        {
            // Fused GCTR+GHASH pipeline: 4-block interleaved AES + aggregated CLMUL
            GcmCore.EncryptPipelined(
                _niEncRoundKeys!, _rounds, _hPowers!, _hClmul,
                icb, associatedData, plaintext, ciphertext, ghash);
        }
        else
#endif
        {
            // Serial path: GCTR then GHASH
            GctrDispatch(icb, plaintext, ciphertext);
            GHashDispatch(associatedData, ciphertext.Slice(0, plaintext.Length), ghash);
        }

        // Compute tag: T = GCTR(J0, GHASH(H, A, C))
        Span<byte> fullTag = stackalloc byte[GcmCore.BlockSizeBytes];
        GctrDispatch(j0, ghash, fullTag);

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

        Span<byte> ghash = stackalloc byte[GcmCore.BlockSizeBytes];

        Span<byte> icb = stackalloc byte[GcmCore.BlockSizeBytes];
        j0.CopyTo(icb);
        IncrementCounter(icb);

#if NET8_0_OR_GREATER
        if (_usePipeline)
        {
            // Fused GHASH+GCTR pipeline: computes GHASH and decrypts simultaneously
            GcmCore.DecryptPipelined(
                _niEncRoundKeys!, _rounds, _hPowers!, _hClmul,
                icb, associatedData, ciphertext, plaintext, ghash);

            // Compute expected tag
            Span<byte> expectedTag = stackalloc byte[GcmCore.BlockSizeBytes];
            GctrDispatch(j0, ghash, expectedTag);

            if (!CryptoUtils.FixedTimeEquals(tag, expectedTag.Slice(0, tag.Length)))
            {
                plaintext.Slice(0, ciphertext.Length).Clear();
                return false;
            }

            return true;
        }
#endif

        // Serial path: GHASH → verify → GCTR
        GHashDispatch(associatedData, ciphertext, ghash);

        {
            Span<byte> expectedTag = stackalloc byte[GcmCore.BlockSizeBytes];
            GctrDispatch(j0, ghash, expectedTag);

            if (!CryptoUtils.FixedTimeEquals(tag, expectedTag.Slice(0, tag.Length)))
            {
                plaintext.Slice(0, ciphertext.Length).Clear();
                return false;
            }
        }

        GctrDispatch(icb, ciphertext, plaintext);

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
                Array.Clear(_h, 0, _h.Length);
                Array.Clear(_encRoundKeys, 0, _encRoundKeys.Length);
                Array.Clear(_shoupTable, 0, _shoupTable.Length);
            }

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

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    private void GctrDispatch(ReadOnlySpan<byte> icb, ReadOnlySpan<byte> input, Span<byte> output)
    {
#if NET8_0_OR_GREATER
        if (_useAesNi)
        {
            GcmCore.GctrAesNi(_niEncRoundKeys!, _rounds, icb, input, output);
            return;
        }
#endif
        GcmCore.GctrAes(_encRoundKeys, _rounds, icb, input, output);
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    private void GHashDispatch(ReadOnlySpan<byte> aad, ReadOnlySpan<byte> ciphertext, Span<byte> output)
    {
#if NET8_0_OR_GREATER
        if (_useClmul)
        {
            GcmCore.GHashCompleteClmul(_hClmul, aad, ciphertext, output);
            return;
        }
#endif
        GcmCore.GHashComplete(_shoupTable, aad, ciphertext, output);
    }
}
