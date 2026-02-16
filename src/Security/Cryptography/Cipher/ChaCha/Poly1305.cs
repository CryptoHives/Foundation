// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Poly1305 message authentication code implementation as specified in RFC 8439.
/// </summary>
/// <remarks>
/// <para>
/// Poly1305 is a high-speed message authentication code designed by Daniel J. Bernstein.
/// It takes a 32-byte one-time key and a message to produce a 16-byte tag.
/// </para>
/// <para>
/// On .NET 8+ this uses 3 × 44-bit radix limbs (donna-64) with widening
/// 64×64→128-bit multiplication, reducing from 25 to 9 multiply-accumulates per block.
/// On older frameworks it falls back to 5 × 26-bit radix limbs (donna-32).
/// Both approaches perform zero-allocation arithmetic modulo p = 2^130 − 5.
/// </para>
/// </remarks>
internal static class Poly1305
{
    /// <summary>
    /// Poly1305 tag size in bytes.
    /// </summary>
    public const int TagSizeBytes = 16;

    /// <summary>
    /// Poly1305 key size in bytes.
    /// </summary>
    public const int KeySizeBytes = 32;

    private const int BlockSize = 16;

    /// <summary>
    /// Computes the Poly1305 MAC for the given message.
    /// </summary>
    /// <param name="key">The 32-byte one-time key (first 16 bytes = r, last 16 bytes = s).</param>
    /// <param name="message">The message to authenticate.</param>
    /// <param name="tag">The 16-byte output tag buffer.</param>
    /// <exception cref="ArgumentException">Thrown when key or tag sizes are invalid.</exception>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ComputeTag(ReadOnlySpan<byte> key, ReadOnlySpan<byte> message, Span<byte> tag)
    {
        if (key.Length != KeySizeBytes)
            throw new ArgumentException($"Key must be {KeySizeBytes} bytes.", nameof(key));
        if (tag.Length < TagSizeBytes)
            throw new ArgumentException($"Tag buffer must be at least {TagSizeBytes} bytes.", nameof(tag));

#if NET8_0_OR_GREATER
        ComputeTag64(key, message, tag);
#else
        ComputeTag32(key, message, tag);
#endif
    }

    /// <summary>
    /// Computes Poly1305 MAC for ChaCha20-Poly1305 AEAD construction.
    /// </summary>
    /// <param name="key">The 32-byte one-time Poly1305 key.</param>
    /// <param name="aad">Additional authenticated data.</param>
    /// <param name="ciphertext">The ciphertext to authenticate.</param>
    /// <param name="tag">The 16-byte output tag buffer.</param>
    /// <remarks>
    /// Processes data in-place without copying into an intermediate buffer.
    /// The AEAD construction feeds: AAD ‖ pad(16) ‖ ciphertext ‖ pad(16) ‖ len(AAD) ‖ len(CT).
    /// All padding zeros align each section to a 16-byte boundary, so every block
    /// is processed as a full block (with hibit set).
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ComputeAeadTag(
        ReadOnlySpan<byte> key,
        ReadOnlySpan<byte> aad,
        ReadOnlySpan<byte> ciphertext,
        Span<byte> tag)
    {
        if (key.Length != KeySizeBytes)
            throw new ArgumentException($"Key must be {KeySizeBytes} bytes.", nameof(key));
        if (tag.Length < TagSizeBytes)
            throw new ArgumentException($"Tag buffer must be at least {TagSizeBytes} bytes.", nameof(tag));

#if NET8_0_OR_GREATER
        ComputeAeadTag64(key, aad, ciphertext, tag);
#else
        ComputeAeadTag32(key, aad, ciphertext, tag);
#endif
    }

    /// <summary>
    /// Computes the Poly1305 MAC using 5 × 26-bit limbs (donna-32).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ComputeTag32(ReadOnlySpan<byte> key, ReadOnlySpan<byte> message, Span<byte> tag)
    {
        uint t0 = BinaryPrimitives.ReadUInt32LittleEndian(key) & 0x0fffffff;
        uint t1 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(4)) & 0x0ffffffc;
        uint t2 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(8)) & 0x0ffffffc;
        uint t3 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(12)) & 0x0ffffffc;

        uint r0 = t0 & 0x03ffffff;
        uint r1 = ((t0 >> 26) | (t1 << 6)) & 0x03ffffff;
        uint r2 = ((t1 >> 20) | (t2 << 12)) & 0x03ffffff;
        uint r3 = ((t2 >> 14) | (t3 << 18)) & 0x03ffffff;
        uint r4 = (t3 >> 8) & 0x03ffffff;

        uint s1 = r1 * 5;
        uint s2 = r2 * 5;
        uint s3 = r3 * 5;
        uint s4 = r4 * 5;

        uint pad0 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(16));
        uint pad1 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(20));
        uint pad2 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(24));
        uint pad3 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(28));

        uint h0 = 0, h1 = 0, h2 = 0, h3 = 0, h4 = 0;

        ProcessBlocks(message, ref h0, ref h1, ref h2, ref h3, ref h4,
                       r0, r1, r2, r3, r4, s1, s2, s3, s4);

        Finalize(ref h0, ref h1, ref h2, ref h3, ref h4,
                 pad0, pad1, pad2, pad3, tag);
    }

    /// <summary>
    /// Computes the AEAD tag using 5 × 26-bit limbs (donna-32).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ComputeAeadTag32(
        ReadOnlySpan<byte> key,
        ReadOnlySpan<byte> aad,
        ReadOnlySpan<byte> ciphertext,
        Span<byte> tag)
    {
        uint t0 = BinaryPrimitives.ReadUInt32LittleEndian(key) & 0x0fffffff;
        uint t1 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(4)) & 0x0ffffffc;
        uint t2 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(8)) & 0x0ffffffc;
        uint t3 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(12)) & 0x0ffffffc;

        uint r0 = t0 & 0x03ffffff;
        uint r1 = ((t0 >> 26) | (t1 << 6)) & 0x03ffffff;
        uint r2 = ((t1 >> 20) | (t2 << 12)) & 0x03ffffff;
        uint r3 = ((t2 >> 14) | (t3 << 18)) & 0x03ffffff;
        uint r4 = (t3 >> 8) & 0x03ffffff;

        uint s1 = r1 * 5;
        uint s2 = r2 * 5;
        uint s3 = r3 * 5;
        uint s4 = r4 * 5;

        uint pad0 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(16));
        uint pad1 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(20));
        uint pad2 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(24));
        uint pad3 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(28));

        uint h0 = 0, h1 = 0, h2 = 0, h3 = 0, h4 = 0;

        ProcessAeadSection(aad, ref h0, ref h1, ref h2, ref h3, ref h4,
                            r0, r1, r2, r3, r4, s1, s2, s3, s4);

        ProcessAeadSection(ciphertext, ref h0, ref h1, ref h2, ref h3, ref h4,
                            r0, r1, r2, r3, r4, s1, s2, s3, s4);

        Span<byte> lengths = stackalloc byte[16];
        BinaryPrimitives.WriteUInt64LittleEndian(lengths, (ulong)aad.Length);
        BinaryPrimitives.WriteUInt64LittleEndian(lengths.Slice(8), (ulong)ciphertext.Length);
        ProcessFullBlock(lengths, ref h0, ref h1, ref h2, ref h3, ref h4,
                          r0, r1, r2, r3, r4, s1, s2, s3, s4);

        Finalize(ref h0, ref h1, ref h2, ref h3, ref h4,
                 pad0, pad1, pad2, pad3, tag);
    }

    /// <summary>
    /// Processes an AEAD section (AAD or ciphertext) as full blocks with zero-padding.
    /// </summary>
    /// <remarks>
    /// Unlike <see cref="ProcessBlocks"/>, the trailing partial block (if any) is
    /// zero-padded to 16 bytes and processed as a full block with hibit set,
    /// matching the RFC 8439 AEAD padding construction.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void ProcessAeadSection(
        ReadOnlySpan<byte> data,
        ref uint h0, ref uint h1, ref uint h2, ref uint h3, ref uint h4,
        uint r0, uint r1, uint r2, uint r3, uint r4,
        uint s1, uint s2, uint s3, uint s4)
    {
        int offset = 0;

        while (offset + BlockSize <= data.Length)
        {
            ProcessFullBlock(data.Slice(offset, BlockSize),
                             ref h0, ref h1, ref h2, ref h3, ref h4,
                             r0, r1, r2, r3, r4, s1, s2, s3, s4);
            offset += BlockSize;
        }

        int remaining = data.Length - offset;
        if (remaining > 0)
        {
            // Zero-pad to 16 bytes and process as a full block (with hibit)
            Span<byte> padded = stackalloc byte[BlockSize];
            padded.Clear();
            data.Slice(offset, remaining).CopyTo(padded);
            ProcessFullBlock(padded,
                             ref h0, ref h1, ref h2, ref h3, ref h4,
                             r0, r1, r2, r3, r4, s1, s2, s3, s4);
        }
    }

    /// <summary>
    /// Processes full 16-byte blocks from the message, then handles any trailing partial block.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ProcessBlocks(
        ReadOnlySpan<byte> data,
        ref uint h0, ref uint h1, ref uint h2, ref uint h3, ref uint h4,
        uint r0, uint r1, uint r2, uint r3, uint r4,
        uint s1, uint s2, uint s3, uint s4)
    {
        int offset = 0;

        while (offset + BlockSize <= data.Length)
        {
            ProcessFullBlock(data.Slice(offset, BlockSize),
                             ref h0, ref h1, ref h2, ref h3, ref h4,
                             r0, r1, r2, r3, r4, s1, s2, s3, s4);
            offset += BlockSize;
        }

        int remaining = data.Length - offset;
        if (remaining > 0)
        {
            ProcessPartialBlock(data.Slice(offset, remaining),
                                ref h0, ref h1, ref h2, ref h3, ref h4,
                                r0, r1, r2, r3, r4, s1, s2, s3, s4);
        }
    }

    /// <summary>
    /// Accumulates a single full 16-byte block into the Poly1305 state.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void ProcessFullBlock(
        ReadOnlySpan<byte> block,
        ref uint h0, ref uint h1, ref uint h2, ref uint h3, ref uint h4,
        uint r0, uint r1, uint r2, uint r3, uint r4,
        uint s1, uint s2, uint s3, uint s4)
    {
        uint b0 = BinaryPrimitives.ReadUInt32LittleEndian(block);
        uint b1 = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(4));
        uint b2 = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(8));
        uint b3 = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(12));

        h0 += b0 & 0x03ffffff;
        h1 += ((b0 >> 26) | (b1 << 6)) & 0x03ffffff;
        h2 += ((b1 >> 20) | (b2 << 12)) & 0x03ffffff;
        h3 += ((b2 >> 14) | (b3 << 18)) & 0x03ffffff;
        h4 += (b3 >> 8) | (1u << 24);

        MultiplyAndReduce(ref h0, ref h1, ref h2, ref h3, ref h4,
                          r0, r1, r2, r3, r4, s1, s2, s3, s4);
    }

    /// <summary>
    /// Accumulates a partial block (&lt;16 bytes) into the Poly1305 state.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void ProcessPartialBlock(
        ReadOnlySpan<byte> block,
        ref uint h0, ref uint h1, ref uint h2, ref uint h3, ref uint h4,
        uint r0, uint r1, uint r2, uint r3, uint r4,
        uint s1, uint s2, uint s3, uint s4)
    {
        Span<byte> padded = stackalloc byte[BlockSize];
        padded.Clear();
        block.CopyTo(padded);
        padded[block.Length] = 0x01;

        uint b0 = BinaryPrimitives.ReadUInt32LittleEndian(padded);
        uint b1 = BinaryPrimitives.ReadUInt32LittleEndian(padded.Slice(4));
        uint b2 = BinaryPrimitives.ReadUInt32LittleEndian(padded.Slice(8));
        uint b3 = BinaryPrimitives.ReadUInt32LittleEndian(padded.Slice(12));

        h0 += b0 & 0x03ffffff;
        h1 += ((b0 >> 26) | (b1 << 6)) & 0x03ffffff;
        h2 += ((b1 >> 20) | (b2 << 12)) & 0x03ffffff;
        h3 += ((b2 >> 14) | (b3 << 18)) & 0x03ffffff;
        h4 += b3 >> 8;

        MultiplyAndReduce(ref h0, ref h1, ref h2, ref h3, ref h4,
                          r0, r1, r2, r3, r4, s1, s2, s3, s4);
    }

    /// <summary>
    /// Multiplies the accumulator by r and performs partial reduction mod 2^130 − 5.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void MultiplyAndReduce(
        ref uint h0, ref uint h1, ref uint h2, ref uint h3, ref uint h4,
        uint r0, uint r1, uint r2, uint r3, uint r4,
        uint s1, uint s2, uint s3, uint s4)
    {
        ulong d0 = (ulong)h0 * r0 + (ulong)h1 * s4 + (ulong)h2 * s3 + (ulong)h3 * s2 + (ulong)h4 * s1;
        ulong d1 = (ulong)h0 * r1 + (ulong)h1 * r0 + (ulong)h2 * s4 + (ulong)h3 * s3 + (ulong)h4 * s2;
        ulong d2 = (ulong)h0 * r2 + (ulong)h1 * r1 + (ulong)h2 * r0 + (ulong)h3 * s4 + (ulong)h4 * s3;
        ulong d3 = (ulong)h0 * r3 + (ulong)h1 * r2 + (ulong)h2 * r1 + (ulong)h3 * r0 + (ulong)h4 * s4;
        ulong d4 = (ulong)h0 * r4 + (ulong)h1 * r3 + (ulong)h2 * r2 + (ulong)h3 * r1 + (ulong)h4 * r0;

        uint c;
        c = (uint)(d0 >> 26); h0 = (uint)d0 & 0x03ffffff; d1 += c;
        c = (uint)(d1 >> 26); h1 = (uint)d1 & 0x03ffffff; d2 += c;
        c = (uint)(d2 >> 26); h2 = (uint)d2 & 0x03ffffff; d3 += c;
        c = (uint)(d3 >> 26); h3 = (uint)d3 & 0x03ffffff; d4 += c;
        c = (uint)(d4 >> 26); h4 = (uint)d4 & 0x03ffffff; h0 += c * 5;
        c = h0 >> 26; h0 &= 0x03ffffff; h1 += c;
    }

    /// <summary>
    /// Performs final reduction and adds the pad to produce the 16-byte tag.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Finalize(
        ref uint h0, ref uint h1, ref uint h2, ref uint h3, ref uint h4,
        uint pad0, uint pad1, uint pad2, uint pad3,
        Span<byte> tag)
    {
        uint c;
        c = h1 >> 26; h1 &= 0x03ffffff; h2 += c;
        c = h2 >> 26; h2 &= 0x03ffffff; h3 += c;
        c = h3 >> 26; h3 &= 0x03ffffff; h4 += c;
        c = h4 >> 26; h4 &= 0x03ffffff; h0 += c * 5;
        c = h0 >> 26; h0 &= 0x03ffffff; h1 += c;

        uint g0 = h0 + 5; c = g0 >> 26; g0 &= 0x03ffffff;
        uint g1 = h1 + c; c = g1 >> 26; g1 &= 0x03ffffff;
        uint g2 = h2 + c; c = g2 >> 26; g2 &= 0x03ffffff;
        uint g3 = h3 + c; c = g3 >> 26; g3 &= 0x03ffffff;
        uint g4 = h4 + c - (1u << 26);

        uint mask = (g4 >> 31) - 1;
        g0 &= mask; g1 &= mask; g2 &= mask; g3 &= mask; g4 &= mask;
        mask = ~mask;
        h0 = (h0 & mask) | g0;
        h1 = (h1 & mask) | g1;
        h2 = (h2 & mask) | g2;
        h3 = (h3 & mask) | g3;
        h4 = (h4 & mask) | g4;

        ulong f0 = ((ulong)h0 | ((ulong)h1 << 26)) & 0xffffffffu;
        ulong f1 = (((ulong)h1 >> 6) | ((ulong)h2 << 20)) & 0xffffffffu;
        ulong f2 = (((ulong)h2 >> 12) | ((ulong)h3 << 14)) & 0xffffffffu;
        ulong f3 = (((ulong)h3 >> 18) | ((ulong)h4 << 8)) & 0xffffffffu;

        f0 += pad0; c = (uint)(f0 >> 32);
        f1 += pad1 + c; c = (uint)(f1 >> 32);
        f2 += pad2 + c; c = (uint)(f2 >> 32);
        f3 += pad3 + c;

        BinaryPrimitives.WriteUInt32LittleEndian(tag, (uint)f0);
        BinaryPrimitives.WriteUInt32LittleEndian(tag.Slice(4), (uint)f1);
        BinaryPrimitives.WriteUInt32LittleEndian(tag.Slice(8), (uint)f2);
        BinaryPrimitives.WriteUInt32LittleEndian(tag.Slice(12), (uint)f3);
    }

#if NET8_0_OR_GREATER
    // ----------------------------------------------------------------
    // Donna-64: 3 × 44-bit limbs with Math.BigMul (64×64→128-bit)
    // ----------------------------------------------------------------
    // Accumulator: h = h0 + h1·2⁴⁴ + h2·2⁸⁸, where h0,h1 ≤ 44 bits, h2 ≤ 42 bits.
    // Key r:       r = r0 + r1·2⁴⁴ + r2·2⁸⁸, each clamped ≤ 44/42 bits.
    // Precomputed: s1 = 20·r1, s2 = 20·r2 (because 2¹³² = 4·2¹³⁰ ≡ 20 mod p).
    // Per-block multiply uses 9 widening multiplies vs 25 in the 5×26-bit version.

    private const ulong Mask44 = 0xFFFFFFFFFFF;  // (1UL << 44) - 1
    private const ulong Mask42 = 0x3FFFFFFFFFF;  // (1UL << 42) - 1

    /// <summary>
    /// Computes the Poly1305 MAC using 3 × 44-bit limbs (donna-64).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ComputeTag64(ReadOnlySpan<byte> key, ReadOnlySpan<byte> message, Span<byte> tag)
    {
        LoadKey64(key, out ulong r0, out ulong r1, out ulong r2,
                  out ulong s1, out ulong s2, out ulong padLo, out ulong padHi);

        ulong h0 = 0, h1 = 0, h2 = 0;

        int off = 0;
        while (off + BlockSize <= message.Length)
        {
            AddFullBlock64(message.Slice(off), ref h0, ref h1, ref h2);
            MulReduce64(ref h0, ref h1, ref h2, r0, r1, r2, s1, s2);
            off += BlockSize;
        }

        if (off < message.Length)
        {
            AddPartialBlock64(message.Slice(off), ref h0, ref h1, ref h2);
            MulReduce64(ref h0, ref h1, ref h2, r0, r1, r2, s1, s2);
        }

        Finalize64(h0, h1, h2, padLo, padHi, tag);
    }

    /// <summary>
    /// Computes the AEAD tag using 3 × 44-bit limbs (donna-64).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ComputeAeadTag64(
        ReadOnlySpan<byte> key,
        ReadOnlySpan<byte> aad,
        ReadOnlySpan<byte> ciphertext,
        Span<byte> tag)
    {
        LoadKey64(key, out ulong r0, out ulong r1, out ulong r2,
                  out ulong s1, out ulong s2, out ulong padLo, out ulong padHi);

        ulong h0 = 0, h1 = 0, h2 = 0;

        ProcessAeadSection64(aad, ref h0, ref h1, ref h2, r0, r1, r2, s1, s2);
        ProcessAeadSection64(ciphertext, ref h0, ref h1, ref h2, r0, r1, r2, s1, s2);

        // Feed lengths block
        ulong lenLo = (ulong)aad.Length;
        ulong lenHi = (ulong)ciphertext.Length;
        h0 += lenLo & Mask44;
        h1 += ((lenLo >> 44) | (lenHi << 20)) & Mask44;
        h2 += ((lenHi >> 24)) & Mask42;
        h2 += 1UL << 40;
        MulReduce64(ref h0, ref h1, ref h2, r0, r1, r2, s1, s2);

        Finalize64(h0, h1, h2, padLo, padHi, tag);
    }

    /// <summary>
    /// Loads and clamps the Poly1305 key into 3 × 44-bit limbs.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void LoadKey64(ReadOnlySpan<byte> key,
        out ulong r0, out ulong r1, out ulong r2,
        out ulong s1, out ulong s2,
        out ulong padLo, out ulong padHi)
    {
        ulong t0 = BinaryPrimitives.ReadUInt64LittleEndian(key);
        ulong t1 = BinaryPrimitives.ReadUInt64LittleEndian(key.Slice(8));
        t0 &= 0x0ffffffc0fffffff;
        t1 &= 0x0ffffffc0ffffffc;

        r0 = t0 & Mask44;
        r1 = ((t0 >> 44) | (t1 << 20)) & Mask44;
        r2 = (t1 >> 24) & Mask42;

        s1 = r1 * 20;
        s2 = r2 * 20;

        padLo = BinaryPrimitives.ReadUInt64LittleEndian(key.Slice(16));
        padHi = BinaryPrimitives.ReadUInt64LittleEndian(key.Slice(24));
    }

    /// <summary>
    /// Processes an AEAD section using 3 × 44-bit limbs.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void ProcessAeadSection64(
        ReadOnlySpan<byte> data,
        ref ulong h0, ref ulong h1, ref ulong h2,
        ulong r0, ulong r1, ulong r2, ulong s1, ulong s2)
    {
        int off = 0;
        while (off + BlockSize <= data.Length)
        {
            AddFullBlock64(data.Slice(off), ref h0, ref h1, ref h2);
            MulReduce64(ref h0, ref h1, ref h2, r0, r1, r2, s1, s2);
            off += BlockSize;
        }

        int remaining = data.Length - off;
        if (remaining > 0)
        {
            Span<byte> padded = stackalloc byte[BlockSize];
            padded.Clear();
            data.Slice(off, remaining).CopyTo(padded);
            AddFullBlock64(padded, ref h0, ref h1, ref h2);
            MulReduce64(ref h0, ref h1, ref h2, r0, r1, r2, s1, s2);
        }
    }

    /// <summary>
    /// Adds a full 16-byte block to the accumulator with hibit set.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void AddFullBlock64(ReadOnlySpan<byte> block,
        ref ulong h0, ref ulong h1, ref ulong h2)
    {
        ulong m0 = BinaryPrimitives.ReadUInt64LittleEndian(block);
        ulong m1 = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(8));
        h0 += m0 & Mask44;
        h1 += ((m0 >> 44) | (m1 << 20)) & Mask44;
        h2 += ((m1 >> 24) & Mask42) | (1UL << 40);
    }

    /// <summary>
    /// Adds a partial block to the accumulator (0x01 sentinel, no hibit).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void AddPartialBlock64(ReadOnlySpan<byte> block,
        ref ulong h0, ref ulong h1, ref ulong h2)
    {
        Span<byte> padded = stackalloc byte[BlockSize];
        padded.Clear();
        block.CopyTo(padded);
        padded[block.Length] = 0x01;

        ulong m0 = BinaryPrimitives.ReadUInt64LittleEndian(padded);
        ulong m1 = BinaryPrimitives.ReadUInt64LittleEndian(padded.Slice(8));
        h0 += m0 & Mask44;
        h1 += ((m0 >> 44) | (m1 << 20)) & Mask44;
        h2 += (m1 >> 24) & Mask42;
    }

    /// <summary>
    /// Multiplies h by r modulo 2¹³⁰ − 5 using 9 widening 64×64→128-bit multiplies.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void MulReduce64(
        ref ulong h0, ref ulong h1, ref ulong h2,
        ulong r0, ulong r1, ulong r2,
        ulong s1, ulong s2)
    {
        // d0 = h0·r0 + h1·(20·r2) + h2·(20·r1)
        ulong d0hi = Math.BigMul(h0, r0, out ulong d0lo);
        ulong hi = Math.BigMul(h1, s2, out ulong lo);
        d0lo += lo; d0hi += hi + (d0lo < lo ? 1UL : 0UL);
        hi = Math.BigMul(h2, s1, out lo);
        d0lo += lo; d0hi += hi + (d0lo < lo ? 1UL : 0UL);

        // d1 = h0·r1 + h1·r0 + h2·(20·r2)
        ulong d1hi = Math.BigMul(h0, r1, out ulong d1lo);
        hi = Math.BigMul(h1, r0, out lo);
        d1lo += lo; d1hi += hi + (d1lo < lo ? 1UL : 0UL);
        hi = Math.BigMul(h2, s2, out lo);
        d1lo += lo; d1hi += hi + (d1lo < lo ? 1UL : 0UL);

        // d2 = h0·r2 + h1·r1 + h2·r0
        ulong d2hi = Math.BigMul(h0, r2, out ulong d2lo);
        hi = Math.BigMul(h1, r1, out lo);
        d2lo += lo; d2hi += hi + (d2lo < lo ? 1UL : 0UL);
        hi = Math.BigMul(h2, r0, out lo);
        d2lo += lo; d2hi += hi + (d2lo < lo ? 1UL : 0UL);

        // Carry propagation: extract 44+44+42 bit limbs
        ulong c;
        c = (d0lo >> 44) | (d0hi << 20); h0 = d0lo & Mask44;
        d1lo += c; d1hi += (d1lo < c ? 1UL : 0UL);
        c = (d1lo >> 44) | (d1hi << 20); h1 = d1lo & Mask44;
        d2lo += c; d2hi += (d2lo < c ? 1UL : 0UL);
        c = (d2lo >> 42) | (d2hi << 22); h2 = d2lo & Mask42;
        h0 += c * 5;
        c = h0 >> 44; h0 &= Mask44; h1 += c;
    }

    /// <summary>
    /// Performs final reduction and adds the pad for 3 × 44-bit limbs.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Finalize64(ulong h0, ulong h1, ulong h2,
        ulong padLo, ulong padHi, Span<byte> tag)
    {
        // Full carry
        ulong c;
        c = h1 >> 44; h1 &= Mask44; h2 += c;
        c = h2 >> 42; h2 &= Mask42; h0 += c * 5;
        c = h0 >> 44; h0 &= Mask44; h1 += c;

        // Conditional subtraction of p = 2¹³⁰ − 5
        ulong g0 = h0 + 5; c = g0 >> 44; g0 &= Mask44;
        ulong g1 = h1 + c; c = g1 >> 44; g1 &= Mask44;
        ulong g2 = h2 + c - (1UL << 42);

        // If h >= p: g2 bit 63 is 0, mask = all-1s → use g
        // If h <  p: g2 bit 63 is 1, mask = 0       → use h
        ulong mask = (g2 >> 63) - 1;
        h0 = (h0 & ~mask) | (g0 & mask);
        h1 = (h1 & ~mask) | (g1 & mask);
        h2 = (h2 & ~mask) | (g2 & mask);

        // Convert to 2 × 64-bit and add pad
        ulong f0 = h0 | (h1 << 44);
        ulong f1 = (h1 >> 20) | (h2 << 24);

        f0 += padLo;
        f1 += padHi + (f0 < padLo ? 1UL : 0UL);

        BinaryPrimitives.WriteUInt64LittleEndian(tag, f0);
        BinaryPrimitives.WriteUInt64LittleEndian(tag.Slice(8), f1);
    }
#endif
}
