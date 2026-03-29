// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

/// <summary>
/// AES Key Wrap with Padding as specified in RFC 5649 (and AES Key Wrap per RFC 3394).
/// </summary>
/// <remarks>
/// <para>
/// AES Key Wrap with Padding (KWP) extends RFC 3394 AES Key Wrap to support
/// arbitrary-length key material (1 byte minimum), adding zero-padding and a
/// message length indicator to the integrity check value.
/// </para>
/// <para>
/// <b>Algorithm overview:</b>
/// <list type="bullet">
///   <item><description>Uses AES ECB as the underlying block cipher</description></item>
///   <item><description>Supports 128, 192, and 256-bit key encryption keys (KEKs)</description></item>
///   <item><description>Wrap output is input length rounded up to 8-byte boundary + 8 bytes overhead</description></item>
///   <item><description>Deterministic: same input always produces the same output</description></item>
/// </list>
/// </para>
/// <para>
/// <b>Example usage:</b>
/// <code>
/// using var kwp = new AesKeyWrapPad(kek);
///
/// // Wrap a key
/// byte[] wrapped = kwp.WrapKey(keyToProtect);
///
/// // Unwrap a key
/// byte[] unwrapped = kwp.UnwrapKey(wrapped);
/// </code>
/// </para>
/// <para>
/// References:
/// <list type="bullet">
/// <item><see href="https://www.rfc-editor.org/rfc/rfc5649">RFC 5649 — AES Key Wrap with Padding</see></item>
/// <item><see href="https://www.rfc-editor.org/rfc/rfc3394">RFC 3394 — AES Key Wrap</see></item>
/// <item><see href="https://csrc.nist.gov/pubs/sp/800/38/f/final">NIST SP 800-38F</see></item>
/// </list>
/// </para>
/// </remarks>
public sealed unsafe class AesKeyWrapPad : IDisposable
{
    /// <summary>
    /// Default Initial Value for RFC 3394 AES Key Wrap.
    /// </summary>
    private const ulong DefaultIv = 0xA6A6A6A6_A6A6A6A6UL;

    /// <summary>
    /// Alternative Initial Value prefix for RFC 5649 AES Key Wrap with Padding.
    /// </summary>
    private const uint AivPrefix = 0xA65959A6U;

    /// <summary>
    /// AES block size in bytes.
    /// </summary>
    private const int BlockSize = 16;

    /// <summary>
    /// Half-block (semiblock) size in bytes.
    /// </summary>
    private const int SemiblockSize = 8;

    /// <summary>
    /// Maximum number of round key words (AES-256: 4 × 15 = 60).
    /// </summary>
    private const int MaxRoundKeyWords = 60;

#pragma warning disable CS0169 // The field '_buffers' is never used
    private KeyWrapBuffers _buffers;
#pragma warning restore CS0169
    private readonly int _rounds;
    private bool _disposed;
#if NET8_0_OR_GREATER
    private readonly bool _useAesNi;
#endif

    /// <summary>
    /// Inline fixed-size buffers for encryption and decryption round keys.
    /// </summary>
    private struct KeyWrapBuffers
    {
        public fixed uint EncKeys[MaxRoundKeyWords];
        public fixed uint DecKeys[MaxRoundKeyWords];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesKeyWrapPad"/> class.
    /// </summary>
    /// <param name="kek">The key encryption key (16, 24, or 32 bytes).</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="kek"/> is not 16, 24, or 32 bytes.</exception>
    public AesKeyWrapPad(ReadOnlySpan<byte> kek) : this(SimdSupport.All, kek)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesKeyWrapPad"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="kek">The key encryption key (16, 24, or 32 bytes).</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="kek"/> is not 16, 24, or 32 bytes.</exception>
    internal AesKeyWrapPad(SimdSupport simdSupport, ReadOnlySpan<byte> kek)
    {
        if (kek.Length != 16 && kek.Length != 24 && kek.Length != 32)
            throw new ArgumentException("Key must be 16, 24, or 32 bytes.", nameof(kek));

        fixed (uint* encP = _buffers.EncKeys)
        fixed (uint* decP = _buffers.DecKeys)
        {
            var encKeys = new Span<uint>(encP, MaxRoundKeyWords);
            var decKeys = new Span<uint>(decP, MaxRoundKeyWords);

#if NET8_0_OR_GREATER
            if ((simdSupport & SimdSupport & SimdSupport.AesNi) != 0)
            {
                _useAesNi = true;
                var encView = MemoryMarshal.Cast<uint, Vector128<byte>>(encKeys);
                _rounds = AesCoreAesNi.ExpandKey(kek, encView);

                var decView = MemoryMarshal.Cast<uint, Vector128<byte>>(decKeys);
                AesCoreAesNi.CreateDecryptionKeys(encView, decView, _rounds);
            }
            else
#endif
            {
                _rounds = AesCore.ExpandKey(kek, encKeys);
                AesCore.CreateDecryptionKeys(encKeys, decKeys, _rounds);
            }
        }
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by AES Key Wrap on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => AesCipherTransform.SimdSupport;

    /// <summary>
    /// Wraps key material using AES Key Wrap with Padding (RFC 5649).
    /// </summary>
    /// <param name="keyToWrap">The key material to wrap (1 or more bytes).</param>
    /// <returns>The wrapped key. Length is input length rounded up to 8-byte boundary + 8 bytes.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="keyToWrap"/> is empty.</exception>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public byte[] WrapKey(ReadOnlySpan<byte> keyToWrap)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(AesKeyWrapPad));
        if (keyToWrap.IsEmpty)
            throw new ArgumentException("Key material must not be empty.", nameof(keyToWrap));

        int mli = keyToWrap.Length;
        int padLen = (SemiblockSize - (mli % SemiblockSize)) % SemiblockSize;
        int paddedLen = mli + padLen;

        // Build AIV: A65959A6 || MLI (big-endian)
        Span<byte> aiv = stackalloc byte[SemiblockSize];
        BinaryPrimitives.WriteUInt32BigEndian(aiv, AivPrefix);
        BinaryPrimitives.WriteUInt32BigEndian(aiv.Slice(4), (uint)mli);

        if (paddedLen == SemiblockSize)
        {
            // Special case: single semiblock — use single AES ECB encrypt
            byte[] result = new byte[BlockSize];
            Span<byte> block = stackalloc byte[BlockSize];
            aiv.CopyTo(block);
            keyToWrap.CopyTo(block.Slice(SemiblockSize));
            // Zero-pad remaining bytes (already zeroed by stackalloc)

            EncryptBlockDispatch(block, result);
            return result;
        }

        // General case: pad and apply RFC 3394 wrap with AIV
        int n = paddedLen / SemiblockSize;
        byte[] output = new byte[(n + 1) * SemiblockSize];

        // Copy padded plaintext into R[1..n] (output[8..])
        keyToWrap.CopyTo(output.AsSpan(SemiblockSize));
        // Padding bytes are already zero from array allocation

        WrapCore(aiv, output.AsSpan(), n);
        return output;
    }

    /// <summary>
    /// Unwraps key material using AES Key Wrap with Padding (RFC 5649).
    /// </summary>
    /// <param name="wrappedKey">The wrapped key to unwrap (minimum 16 bytes, multiple of 8).</param>
    /// <returns>The original key material.</returns>
    /// <exception cref="ArgumentException">Thrown when <paramref name="wrappedKey"/> has invalid length.</exception>
    /// <exception cref="CryptographicException">Thrown when integrity check fails.</exception>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public byte[] UnwrapKey(ReadOnlySpan<byte> wrappedKey)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(AesKeyWrapPad));
        if (wrappedKey.Length < BlockSize || wrappedKey.Length % SemiblockSize != 0)
            throw new ArgumentException("Wrapped key must be at least 16 bytes and a multiple of 8.", nameof(wrappedKey));

        int n = (wrappedKey.Length / SemiblockSize) - 1;
        Span<byte> a = stackalloc byte[SemiblockSize];

        if (n == 1)
        {
            // Special case: single semiblock — use single AES ECB decrypt
            Span<byte> block = stackalloc byte[BlockSize];
            DecryptBlockDispatch(wrappedKey, block);
            block.Slice(0, SemiblockSize).CopyTo(a);
            Span<byte> plaintext = block.Slice(SemiblockSize);

            VerifyAiv(a, plaintext, n);
            int mli = (int)BinaryPrimitives.ReadUInt32BigEndian(a.Slice(4));
            return plaintext.Slice(0, mli).ToArray();
        }

        // General case: RFC 3394 unwrap
        byte[] buffer = new byte[wrappedKey.Length];
        wrappedKey.CopyTo(buffer);

        UnwrapCore(a, buffer.AsSpan(), n);

        Span<byte> data = buffer.AsSpan(SemiblockSize);
        VerifyAiv(a, data, n);
        int msgLen = (int)BinaryPrimitives.ReadUInt32BigEndian(a.Slice(4));
        return data.Slice(0, msgLen).ToArray();
    }

    /// <summary>
    /// Wraps key material using AES Key Wrap (RFC 3394) without padding.
    /// </summary>
    /// <param name="keyToWrap">
    /// The key material to wrap. Must be a multiple of 8 bytes and at least 16 bytes.
    /// </param>
    /// <returns>The wrapped key (input length + 8 bytes).</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="keyToWrap"/> is less than 16 bytes or not a multiple of 8.
    /// </exception>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public byte[] WrapKeyNoPad(ReadOnlySpan<byte> keyToWrap)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(AesKeyWrapPad));
        if (keyToWrap.Length < 2 * SemiblockSize || keyToWrap.Length % SemiblockSize != 0)
            throw new ArgumentException("Key material must be at least 16 bytes and a multiple of 8.", nameof(keyToWrap));

        int n = keyToWrap.Length / SemiblockSize;
        byte[] output = new byte[(n + 1) * SemiblockSize];

        // Set default IV
        Span<byte> iv = stackalloc byte[SemiblockSize];
        BinaryPrimitives.WriteUInt64BigEndian(iv, DefaultIv);

        // Copy plaintext into R[1..n]
        keyToWrap.CopyTo(output.AsSpan(SemiblockSize));

        WrapCore(iv, output.AsSpan(), n);
        return output;
    }

    /// <summary>
    /// Unwraps key material using AES Key Wrap (RFC 3394) without padding.
    /// </summary>
    /// <param name="wrappedKey">
    /// The wrapped key to unwrap. Must be a multiple of 8 bytes and at least 24 bytes.
    /// </param>
    /// <returns>The original key material (wrapped key length - 8 bytes).</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="wrappedKey"/> has invalid length.
    /// </exception>
    /// <exception cref="CryptographicException">Thrown when integrity check fails.</exception>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public byte[] UnwrapKeyNoPad(ReadOnlySpan<byte> wrappedKey)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(AesKeyWrapPad));
        if (wrappedKey.Length < 3 * SemiblockSize || wrappedKey.Length % SemiblockSize != 0)
            throw new ArgumentException("Wrapped key must be at least 24 bytes and a multiple of 8.", nameof(wrappedKey));

        int n = (wrappedKey.Length / SemiblockSize) - 1;
        byte[] buffer = new byte[wrappedKey.Length];
        wrappedKey.CopyTo(buffer);

        Span<byte> a = stackalloc byte[SemiblockSize];
        UnwrapCore(a, buffer.AsSpan(), n);

        // Verify default IV
        ulong recovered = BinaryPrimitives.ReadUInt64BigEndian(a);
        if (recovered != DefaultIv)
            throw new CryptographicException("AES Key Wrap integrity check failed.");

        return buffer.AsSpan(SemiblockSize, n * SemiblockSize).ToArray();
    }

    /// <summary>
    /// RFC 3394 Section 2.2.1 — Key Wrap core algorithm.
    /// On entry, output[0..8) holds A (will be overwritten), output[8..] holds R[1..n].
    /// On exit, output[0..8) holds final A, output[8..] holds final R[1..n].
    /// </summary>
    /// <param name="iv">The 8-byte initial value (A₀).</param>
    /// <param name="output">The output buffer: [A || R1 || R2 || ... || Rn].</param>
    /// <param name="n">Number of 64-bit semiblocks of plaintext.</param>
    private void WrapCore(ReadOnlySpan<byte> iv, Span<byte> output, int n)
    {
        Span<byte> block = stackalloc byte[BlockSize];
        Span<byte> b = stackalloc byte[BlockSize];

        // A = IV
        Span<byte> a = block.Slice(0, SemiblockSize);
        iv.CopyTo(a);

        for (int j = 0; j < 6; j++)
        {
            for (int i = 1; i <= n; i++)
            {
                // B = AES(K, A || R[i])
                output.Slice(i * SemiblockSize, SemiblockSize).CopyTo(block.Slice(SemiblockSize));
                EncryptBlockDispatch(block, b);

                // A = MSB(64, B) ^ t where t = n*j + i
                ulong msb = BinaryPrimitives.ReadUInt64BigEndian(b);
                ulong t = (ulong)(n * j + i);
                BinaryPrimitives.WriteUInt64BigEndian(a, msb ^ t);

                // R[i] = LSB(64, B)
                b.Slice(SemiblockSize).CopyTo(output.Slice(i * SemiblockSize));
            }
        }

        // Write final A to output[0..8)
        a.CopyTo(output);
    }

    /// <summary>
    /// RFC 3394 Section 2.2.2 — Key Unwrap core algorithm.
    /// On entry, buffer contains [C0 || C1 || ... || Cn].
    /// On exit, <paramref name="a"/> holds recovered A, buffer[8..] holds R[1..n].
    /// </summary>
    /// <param name="a">Output buffer for the recovered 8-byte integrity value.</param>
    /// <param name="buffer">The ciphertext buffer: [C0 || C1 || ... || Cn].</param>
    /// <param name="n">Number of 64-bit ciphertext semiblocks (excluding A).</param>
    private void UnwrapCore(Span<byte> a, Span<byte> buffer, int n)
    {
        Span<byte> block = stackalloc byte[BlockSize];
        Span<byte> b = stackalloc byte[BlockSize];

        // A = C[0]
        buffer.Slice(0, SemiblockSize).CopyTo(a);

        for (int j = 5; j >= 0; j--)
        {
            for (int i = n; i >= 1; i--)
            {
                // B = AES-1(K, (A ^ t) || R[i]) where t = n*j + i
                ulong aVal = BinaryPrimitives.ReadUInt64BigEndian(a);
                ulong t = (ulong)(n * j + i);
                BinaryPrimitives.WriteUInt64BigEndian(block, aVal ^ t);
                buffer.Slice(i * SemiblockSize, SemiblockSize).CopyTo(block.Slice(SemiblockSize));

                DecryptBlockDispatch(block, b);

                // A = MSB(64, B)
                b.Slice(0, SemiblockSize).CopyTo(a);

                // R[i] = LSB(64, B)
                b.Slice(SemiblockSize).CopyTo(buffer.Slice(i * SemiblockSize));
            }
        }
    }

    /// <summary>
    /// Verifies the Alternative Initial Value (AIV) per RFC 5649 Section 3.
    /// </summary>
    /// <param name="a">The recovered 8-byte AIV.</param>
    /// <param name="data">The padded plaintext data.</param>
    /// <param name="n">Number of 64-bit semiblocks of padded data.</param>
    /// <exception cref="CryptographicException">Thrown when AIV verification fails.</exception>
    private static void VerifyAiv(ReadOnlySpan<byte> a, ReadOnlySpan<byte> data, int n)
    {
        // Check AIV prefix
        uint prefix = BinaryPrimitives.ReadUInt32BigEndian(a);
        if (prefix != AivPrefix)
            throw new CryptographicException("AES Key Wrap with Padding integrity check failed.");

        // Check MLI range: n*8 - 7 <= m <= n*8
        uint mli = BinaryPrimitives.ReadUInt32BigEndian(a.Slice(4));
        uint maxLen = (uint)(n * SemiblockSize);
        uint minLen = maxLen - 7;
        if (mli < minLen || mli > maxLen)
            throw new CryptographicException("AES Key Wrap with Padding integrity check failed.");

        // Check padding bytes are all zero
        for (int i = (int)mli; i < (int)maxLen; i++)
        {
            if (data[i] != 0)
                throw new CryptographicException("AES Key Wrap with Padding integrity check failed.");
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void EncryptBlockDispatch(ReadOnlySpan<byte> input, Span<byte> output)
    {
        fixed (uint* p = _buffers.EncKeys)
        {
            var roundKeys = new ReadOnlySpan<uint>(p, MaxRoundKeyWords);
#if NET8_0_OR_GREATER
            if (_useAesNi)
            {
                AesCoreAesNi.EncryptBlock(input, output,
                    MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), _rounds);
                return;
            }
#endif
            AesCore.EncryptBlock(input, output, roundKeys, _rounds);
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void DecryptBlockDispatch(ReadOnlySpan<byte> input, Span<byte> output)
    {
        fixed (uint* p = _buffers.DecKeys)
        {
            var roundKeys = new ReadOnlySpan<uint>(p, MaxRoundKeyWords);
#if NET8_0_OR_GREATER
            if (_useAesNi)
            {
                AesCoreAesNi.DecryptBlock(input, output,
                    MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), _rounds);
                return;
            }
#endif
            AesCore.DecryptBlock(input, output, roundKeys, _rounds);
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;

        // Securely clear the round keys
        fixed (uint* encP = _buffers.EncKeys)
        fixed (uint* decP = _buffers.DecKeys)
        {
            new Span<uint>(encP, MaxRoundKeyWords).Clear();
            new Span<uint>(decP, MaxRoundKeyWords).Clear();
        }
    }
}
