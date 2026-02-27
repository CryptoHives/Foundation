// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

/// <summary>
/// Ascon-AEAD128 authenticated encryption as specified in NIST SP 800-232.
/// </summary>
/// <remarks>
/// <para>
/// Ascon-AEAD128 is the primary AEAD algorithm from the NIST Lightweight Cryptography
/// standard (SP 800-232). It provides authenticated encryption with associated data
/// using a 128-bit key, 128-bit nonce, and 128-bit authentication tag.
/// </para>
/// <para>
/// Ascon was the winner of the NIST Lightweight Cryptography competition (2023),
/// designed for constrained environments while maintaining strong security guarantees.
/// </para>
/// <para>
/// <b>Security properties:</b>
/// <list type="bullet">
///   <item><description>128-bit security level</description></item>
///   <item><description>128-bit authentication tag</description></item>
///   <item><description>Sponge-based construction with 320-bit state</description></item>
///   <item><description>Resistant to timing attacks (no table lookups)</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Important:</b> Never reuse a (key, nonce) pair. Each encryption must use
/// a unique 128-bit (16-byte) nonce.
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var aead = AsconAead128.Create(key);
///
/// // Encrypt with associated data
/// byte[] ciphertext = aead.Encrypt(nonce, plaintext, associatedData);
///
/// // Decrypt and verify
/// byte[] plaintext = aead.Decrypt(nonce, ciphertext, associatedData);
/// </code>
/// </para>
/// <para>
/// References:
/// <list type="bullet">
/// <item><see href="https://csrc.nist.gov/pubs/sp/800/232/final">NIST SP 800-232</see></item>
/// <item><see href="https://github.com/ascon/ascon-c">Reference Implementation</see></item>
/// <item><see href="https://ascon.iaik.tugraz.at/">Ascon Homepage</see></item>
/// </list>
/// </para>
/// </remarks>
public sealed class AsconAead128 : IAeadCipher
{
    /// <summary>
    /// The IV constant for Ascon-AEAD128 per NIST SP 800-232.
    /// Encodes: key_size=128, rate=128, pa_rounds=12, pb_rounds=8, variant=1.
    /// </summary>
    private const ulong AsconIV = 0x00001000808c0001UL;

    /// <summary>
    /// Rate in bytes (128 bits = 16 bytes) for the AEAD construction.
    /// </summary>
    private const int RateBytes = 16;

    private const int KeySizeBits = 128;
    private const int NonceSizeBits = 128;
    private const int TagSizeBits = 128;

    /// <summary>
    /// Key size in bytes (128 bits).
    /// </summary>
    public const int KeySizeBytesConst = KeySizeBits / 8;

    /// <summary>
    /// Nonce size in bytes (128 bits).
    /// </summary>
    public const int NonceSizeBytesConst = NonceSizeBits / 8;

    /// <summary>
    /// Tag size in bytes (128 bits).
    /// </summary>
    public const int TagSizeBytesConst = TagSizeBits / 8;

    private readonly ulong _k0;
    private readonly ulong _k1;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsconAead128"/> class.
    /// </summary>
    /// <param name="key">The 16-byte key.</param>
    /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
    /// <exception cref="ArgumentException"><paramref name="key"/> is not 16 bytes.</exception>
    public AsconAead128(byte[] key)
    {
        if (key == null) throw new ArgumentNullException(nameof(key));
        if (key.Length != KeySizeBytesConst)
            throw new ArgumentException($"Key must be {KeySizeBytesConst} bytes.", nameof(key));

        _k0 = BinaryPrimitives.ReadUInt64LittleEndian(key.AsSpan(0));
        _k1 = BinaryPrimitives.ReadUInt64LittleEndian(key.AsSpan(8));
    }

    /// <inheritdoc/>
    public string AlgorithmName => "Ascon-AEAD128";

    /// <inheritdoc/>
    public int KeySizeBytes => KeySizeBytesConst;

    /// <inheritdoc/>
    public int NonceSizeBytes => NonceSizeBytesConst;

    /// <inheritdoc/>
    public int TagSizeBytes => TagSizeBytesConst;

    /// <summary>
    /// Creates a new Ascon-AEAD128 instance.
    /// </summary>
    /// <param name="key">The 16-byte key.</param>
    /// <returns>A new Ascon-AEAD128 instance.</returns>
    public static AsconAead128 Create(byte[] key) => new(key);

    /// <inheritdoc/>
    public void Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
                        Span<byte> ciphertext, Span<byte> tag,
                        ReadOnlySpan<byte> associatedData = default)
    {
        if (nonce.Length != NonceSizeBytesConst)
            throw new ArgumentException($"Nonce must be {NonceSizeBytesConst} bytes.", nameof(nonce));
        if (ciphertext.Length < plaintext.Length)
            throw new ArgumentException("Ciphertext buffer too small.", nameof(ciphertext));
        if (tag.Length < TagSizeBytesConst)
            throw new ArgumentException($"Tag buffer must be at least {TagSizeBytesConst} bytes.", nameof(tag));

        // Initialize state
        ulong s0 = AsconIV;
        ulong s1 = _k0;
        ulong s2 = _k1;
        ulong s3 = BinaryPrimitives.ReadUInt64LittleEndian(nonce);
        ulong s4 = BinaryPrimitives.ReadUInt64LittleEndian(nonce.Slice(8));
        AsconCore.P12(ref s0, ref s1, ref s2, ref s3, ref s4);
        s3 ^= _k0;
        s4 ^= _k1;

        // Process associated data
        ProcessAad(ref s0, ref s1, ref s2, ref s3, ref s4, associatedData);

        // Encrypt plaintext
        EncryptData(ref s0, ref s1, ref s2, ref s3, ref s4, plaintext, ciphertext);

        // Finalize and produce tag
        Finalize(ref s0, ref s1, ref s2, ref s3, ref s4, tag);
    }

    /// <inheritdoc/>
    public bool Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext,
                        ReadOnlySpan<byte> tag, Span<byte> plaintext,
                        ReadOnlySpan<byte> associatedData = default)
    {
        if (nonce.Length != NonceSizeBytesConst)
            throw new ArgumentException($"Nonce must be {NonceSizeBytesConst} bytes.", nameof(nonce));
        if (tag.Length != TagSizeBytesConst)
            throw new ArgumentException($"Tag must be {TagSizeBytesConst} bytes.", nameof(tag));
        if (plaintext.Length < ciphertext.Length)
            throw new ArgumentException("Plaintext buffer too small.", nameof(plaintext));

        // Initialize state
        ulong s0 = AsconIV;
        ulong s1 = _k0;
        ulong s2 = _k1;
        ulong s3 = BinaryPrimitives.ReadUInt64LittleEndian(nonce);
        ulong s4 = BinaryPrimitives.ReadUInt64LittleEndian(nonce.Slice(8));
        AsconCore.P12(ref s0, ref s1, ref s2, ref s3, ref s4);
        s3 ^= _k0;
        s4 ^= _k1;

        // Process associated data
        ProcessAad(ref s0, ref s1, ref s2, ref s3, ref s4, associatedData);

        // Decrypt ciphertext
        DecryptData(ref s0, ref s1, ref s2, ref s3, ref s4, ciphertext, plaintext);

        // Finalize and verify tag
        Span<byte> computedTag = stackalloc byte[TagSizeBytesConst];
        Finalize(ref s0, ref s1, ref s2, ref s3, ref s4, computedTag);

        if (!CryptoUtils.FixedTimeEquals(tag, computedTag))
        {
            plaintext.Slice(0, ciphertext.Length).Clear();
            return false;
        }

        return true;
    }

    /// <inheritdoc/>
    public byte[] Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext,
                          ReadOnlySpan<byte> associatedData = default)
    {
        byte[] result = new byte[plaintext.Length + TagSizeBytesConst];
        Span<byte> ct = result.AsSpan(0, plaintext.Length);
        Span<byte> tag = result.AsSpan(plaintext.Length, TagSizeBytesConst);

        Encrypt(nonce, plaintext, ct, tag, associatedData);

        return result;
    }

    /// <inheritdoc/>
    public byte[] Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertextWithTag,
                          ReadOnlySpan<byte> associatedData = default)
    {
        if (ciphertextWithTag.Length < TagSizeBytesConst)
            throw new CryptographicException("Ciphertext too short.");

        int ciphertextLength = ciphertextWithTag.Length - TagSizeBytesConst;
        ReadOnlySpan<byte> ciphertext = ciphertextWithTag.Slice(0, ciphertextLength);
        ReadOnlySpan<byte> tag = ciphertextWithTag.Slice(ciphertextLength, TagSizeBytesConst);

        byte[] plaintext = new byte[ciphertextLength];

        if (!Decrypt(nonce, ciphertext, tag, plaintext, associatedData))
            throw new CryptographicException("Authentication failed.");

        return plaintext;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        // Key stored as readonly ulong fields; no sensitive arrays to clear.
    }

    /// <summary>
    /// Processes associated data through the sponge.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ProcessAad(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4,
                                   ReadOnlySpan<byte> associatedData)
    {
        if (!associatedData.IsEmpty)
        {
            int offset = 0;

            // Process full rate blocks
            while (offset + RateBytes <= associatedData.Length)
            {
                s0 ^= BinaryPrimitives.ReadUInt64LittleEndian(associatedData.Slice(offset));
                s1 ^= BinaryPrimitives.ReadUInt64LittleEndian(associatedData.Slice(offset + 8));
                AsconCore.P8(ref s0, ref s1, ref s2, ref s3, ref s4);
                offset += RateBytes;
            }

            // Process final partial block with padding
            int remaining = associatedData.Length - offset;
            if (remaining >= 8)
            {
                s0 ^= BinaryPrimitives.ReadUInt64LittleEndian(associatedData.Slice(offset));
                int tail = remaining - 8;
                s1 ^= PadPartialWord(associatedData.Slice(offset + 8, tail), tail);
            }
            else
            {
                s0 ^= PadPartialWord(associatedData.Slice(offset, remaining), remaining);
            }

            AsconCore.P8(ref s0, ref s1, ref s2, ref s3, ref s4);
        }

        // Domain separation
        s4 ^= 0x8000000000000000UL;
    }

    /// <summary>
    /// Encrypts plaintext data through the sponge.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void EncryptData(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4,
                                    ReadOnlySpan<byte> plaintext, Span<byte> ciphertext)
    {
        int offset = 0;

        // Process full rate blocks
        while (offset + RateBytes <= plaintext.Length)
        {
            s0 ^= BinaryPrimitives.ReadUInt64LittleEndian(plaintext.Slice(offset));
            BinaryPrimitives.WriteUInt64LittleEndian(ciphertext.Slice(offset), s0);

            s1 ^= BinaryPrimitives.ReadUInt64LittleEndian(plaintext.Slice(offset + 8));
            BinaryPrimitives.WriteUInt64LittleEndian(ciphertext.Slice(offset + 8), s1);

            AsconCore.P8(ref s0, ref s1, ref s2, ref s3, ref s4);
            offset += RateBytes;
        }

        // Process final partial block
        int remaining = plaintext.Length - offset;
        if (remaining >= 8)
        {
            s0 ^= BinaryPrimitives.ReadUInt64LittleEndian(plaintext.Slice(offset));
            BinaryPrimitives.WriteUInt64LittleEndian(ciphertext.Slice(offset), s0);

            int tail = remaining - 8;
            if (tail > 0)
            {
                EncryptPartialWord(ref s1, plaintext.Slice(offset + 8, tail), ciphertext.Slice(offset + 8, tail));
            }

            s1 ^= Pad(tail);
        }
        else
        {
            if (remaining > 0)
            {
                EncryptPartialWord(ref s0, plaintext.Slice(offset, remaining), ciphertext.Slice(offset, remaining));
            }

            s0 ^= Pad(remaining);
        }
    }

    /// <summary>
    /// Decrypts ciphertext data through the sponge.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void DecryptData(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4,
                                    ReadOnlySpan<byte> ciphertext, Span<byte> plaintext)
    {
        int offset = 0;

        // Process full rate blocks
        while (offset + RateBytes <= ciphertext.Length)
        {
            ulong c0 = BinaryPrimitives.ReadUInt64LittleEndian(ciphertext.Slice(offset));
            BinaryPrimitives.WriteUInt64LittleEndian(plaintext.Slice(offset), s0 ^ c0);
            s0 = c0;

            ulong c1 = BinaryPrimitives.ReadUInt64LittleEndian(ciphertext.Slice(offset + 8));
            BinaryPrimitives.WriteUInt64LittleEndian(plaintext.Slice(offset + 8), s1 ^ c1);
            s1 = c1;

            AsconCore.P8(ref s0, ref s1, ref s2, ref s3, ref s4);
            offset += RateBytes;
        }

        // Process final partial block
        int remaining = ciphertext.Length - offset;
        if (remaining >= 8)
        {
            ulong c0 = BinaryPrimitives.ReadUInt64LittleEndian(ciphertext.Slice(offset));
            BinaryPrimitives.WriteUInt64LittleEndian(plaintext.Slice(offset), s0 ^ c0);
            s0 = c0;

            int tail = remaining - 8;
            if (tail > 0)
            {
                DecryptPartialWord(ref s1, ciphertext.Slice(offset + 8, tail), plaintext.Slice(offset + 8, tail));
            }

            s1 ^= Pad(tail);
        }
        else
        {
            if (remaining > 0)
            {
                DecryptPartialWord(ref s0, ciphertext.Slice(offset, remaining), plaintext.Slice(offset, remaining));
            }

            s0 ^= Pad(remaining);
        }
    }

    /// <summary>
    /// Finalizes the AEAD computation and produces the authentication tag.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Finalize(ref ulong s0, ref ulong s1, ref ulong s2, ref ulong s3, ref ulong s4, Span<byte> tag)
    {
        s2 ^= _k0;
        s3 ^= _k1;
        AsconCore.P12(ref s0, ref s1, ref s2, ref s3, ref s4);
        s3 ^= _k0;
        s4 ^= _k1;

        BinaryPrimitives.WriteUInt64LittleEndian(tag, s3);
        BinaryPrimitives.WriteUInt64LittleEndian(tag.Slice(8), s4);
    }

    /// <summary>
    /// Encrypts a partial word (less than 8 bytes) and XORs into the state word.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void EncryptPartialWord(ref ulong s, ReadOnlySpan<byte> input, Span<byte> output)
    {
        ulong pt = ReadPartialLE(input);
        s ^= pt;
        WritePartialLE(s, output);
    }

    /// <summary>
    /// Decrypts a partial word (less than 8 bytes) and replaces in the state word.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void DecryptPartialWord(ref ulong s, ReadOnlySpan<byte> input, Span<byte> output)
    {
        int len = input.Length;
        ulong ct = ReadPartialLE(input);
        WritePartialLE(s ^ ct, output);
        ulong mask = ulong.MaxValue << (len << 3);
        s = (s & mask) ^ ct;
    }

    /// <summary>
    /// Reads 1–7 bytes as a little-endian partial ulong.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong ReadPartialLE(ReadOnlySpan<byte> data)
    {
        ulong result = 0;
        for (int i = 0; i < data.Length; i++)
        {
            result |= (ulong)data[i] << (i << 3);
        }
        return result;
    }

    /// <summary>
    /// Writes 1–7 bytes from a little-endian ulong.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void WritePartialLE(ulong value, Span<byte> data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = (byte)(value >> (i << 3));
        }
    }

    /// <summary>
    /// Reads a partial word and applies padding.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong PadPartialWord(ReadOnlySpan<byte> data, int len)
    {
        ulong result = ReadPartialLE(data);
        result |= 0x01UL << (len << 3);
        return result;
    }

    /// <summary>
    /// Returns the padding constant: 0x01 shifted to the given byte position.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong Pad(int i) => 0x01UL << (i << 3);
}
