// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Poly1305 message authentication code core as specified in RFC 8439.
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
/// <para>
/// This is a stack-only ref struct for zero-allocation usage. For a heap-based
/// streaming <c>IMac</c> implementation, see
/// <c>CryptoHives.Foundation.Security.Cryptography.Mac.Poly1305Mac</c>.
/// </para>
/// </remarks>
internal ref struct Poly1305Core
{
    /// <summary>
    /// Poly1305 tag size in bytes.
    /// </summary>
    public const int TagSizeBytes = 16;

    /// <summary>
    /// Poly1305 key size in bytes.
    /// </summary>
    public const int KeySizeBytes = 32;

    internal const int BlockSize = 16;

#if NET8_0_OR_GREATER
    // ---- Donna-64: 3 × 44-bit limbs ----
    private const ulong Mask44 = 0xFFFFFFFFFFF;  // (1UL << 44) - 1
    private const ulong Mask42 = 0x3FFFFFFFFFF;  // (1UL << 42) - 1

    private ulong _h0, _h1, _h2;
    private readonly ulong _r0, _r1, _r2, _s1, _s2;
    private readonly ulong _padLo, _padHi;
#else
    // ---- Donna-32: 5 × 26-bit limbs ----
    private uint _h0, _h1, _h2, _h3, _h4;
    private readonly uint _r0, _r1, _r2, _r3, _r4;
    private readonly uint _s1, _s2, _s3, _s4;
    private readonly uint _pad0, _pad1, _pad2, _pad3;
#endif

    /// <summary>
    /// Initializes a new <see cref="Poly1305Core"/> with the given 32-byte one-time key.
    /// </summary>
    /// <param name="key">The 32-byte one-time key (first 16 bytes = r, last 16 bytes = s).</param>
    /// <exception cref="ArgumentException">Thrown when the key is not 32 bytes.</exception>
    public Poly1305Core(ReadOnlySpan<byte> key)
    {
        if (key.Length != KeySizeBytes)
            throw new ArgumentException($"Key must be {KeySizeBytes} bytes.", nameof(key));

#if NET8_0_OR_GREATER
        _h0 = _h1 = _h2 = 0;
        LoadKey64(key, out _r0, out _r1, out _r2, out _s1, out _s2, out _padLo, out _padHi);
#else
        _h0 = _h1 = _h2 = _h3 = _h4 = 0;
        LoadKey32(key,
            out _r0, out _r1, out _r2, out _r3, out _r4,
            out _s1, out _s2, out _s3, out _s4,
            out _pad0, out _pad1, out _pad2, out _pad3);
#endif
    }

    // ================================================================
    // Instance methods — for stack-only callers (ChaCha20Poly1305, etc.)
    // ================================================================

    /// <summary>
    /// Processes full 16-byte blocks from the message, then handles any trailing partial block.
    /// </summary>
    /// <param name="data">The message data to process.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void ProcessBlocks(ReadOnlySpan<byte> data)
    {
        int offset = 0;

        while (offset + BlockSize <= data.Length)
        {
#if NET8_0_OR_GREATER
            AddFullBlock64(data.Slice(offset), ref _h0, ref _h1, ref _h2);
            MulReduce64(ref _h0, ref _h1, ref _h2, _r0, _r1, _r2, _s1, _s2);
#else
            ProcessFullBlock32(data.Slice(offset, BlockSize),
                ref _h0, ref _h1, ref _h2, ref _h3, ref _h4,
                _r0, _r1, _r2, _r3, _r4, _s1, _s2, _s3, _s4);
#endif
            offset += BlockSize;
        }

        int remaining = data.Length - offset;
        if (remaining > 0)
        {
#if NET8_0_OR_GREATER
            AddPartialBlock64(data.Slice(offset), ref _h0, ref _h1, ref _h2);
            MulReduce64(ref _h0, ref _h1, ref _h2, _r0, _r1, _r2, _s1, _s2);
#else
            ProcessPartialBlock32(data.Slice(offset, remaining),
                ref _h0, ref _h1, ref _h2, ref _h3, ref _h4,
                _r0, _r1, _r2, _r3, _r4, _s1, _s2, _s3, _s4);
#endif
        }
    }

    /// <summary>
    /// Processes an AEAD section (AAD or ciphertext) as full blocks with zero-padding.
    /// </summary>
    /// <remarks>
    /// Unlike <see cref="ProcessBlocks"/>, the trailing partial block (if any) is
    /// zero-padded to 16 bytes and processed as a full block with hibit set,
    /// matching the RFC 8439 AEAD padding construction.
    /// </remarks>
    /// <param name="data">The AEAD section data.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public void ProcessAeadSection(ReadOnlySpan<byte> data)
    {
        int offset = 0;

        while (offset + BlockSize <= data.Length)
        {
#if NET8_0_OR_GREATER
            AddFullBlock64(data.Slice(offset), ref _h0, ref _h1, ref _h2);
            MulReduce64(ref _h0, ref _h1, ref _h2, _r0, _r1, _r2, _s1, _s2);
#else
            ProcessFullBlock32(data.Slice(offset, BlockSize),
                ref _h0, ref _h1, ref _h2, ref _h3, ref _h4,
                _r0, _r1, _r2, _r3, _r4, _s1, _s2, _s3, _s4);
#endif
            offset += BlockSize;
        }

        int remaining = data.Length - offset;
        if (remaining > 0)
        {
            Span<byte> padded = stackalloc byte[BlockSize];
            padded.Clear();
            data.Slice(offset, remaining).CopyTo(padded);
#if NET8_0_OR_GREATER
            AddFullBlock64(padded, ref _h0, ref _h1, ref _h2);
            MulReduce64(ref _h0, ref _h1, ref _h2, _r0, _r1, _r2, _s1, _s2);
#else
            ProcessFullBlock32(padded,
                ref _h0, ref _h1, ref _h2, ref _h3, ref _h4,
                _r0, _r1, _r2, _r3, _r4, _s1, _s2, _s3, _s4);
#endif
        }
    }

    /// <summary>
    /// Performs final reduction and adds the pad to produce the 16-byte tag.
    /// </summary>
    /// <param name="tag">The 16-byte output tag buffer.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public void Finalize(Span<byte> tag)
    {
#if NET8_0_OR_GREATER
        Finalize64(_h0, _h1, _h2, _padLo, _padHi, tag);
#else
        Finalize32(ref _h0, ref _h1, ref _h2, ref _h3, ref _h4,
            _pad0, _pad1, _pad2, _pad3, tag);
#endif
    }

    // ================================================================
    // Static one-shot convenience methods
    // ================================================================

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

        var core = new Poly1305Core(key);
        core.ProcessBlocks(message);
        core.Finalize(tag);
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

        var core = new Poly1305Core(key);
        core.ProcessAeadSection(aad);
        core.ProcessAeadSection(ciphertext);

        // Feed lengths block
#if NET8_0_OR_GREATER
        ulong lenLo = (ulong)aad.Length;
        ulong lenHi = (ulong)ciphertext.Length;
        core._h0 += lenLo & Mask44;
        core._h1 += ((lenLo >> 44) | (lenHi << 20)) & Mask44;
        core._h2 += ((lenHi >> 24)) & Mask42;
        core._h2 += 1UL << 40;
        MulReduce64(ref core._h0, ref core._h1, ref core._h2,
            core._r0, core._r1, core._r2, core._s1, core._s2);
#else
        Span<byte> lengths = stackalloc byte[BlockSize];
        BinaryPrimitives.WriteUInt64LittleEndian(lengths, (ulong)aad.Length);
        BinaryPrimitives.WriteUInt64LittleEndian(lengths.Slice(sizeof(ulong)), (ulong)ciphertext.Length);
        ProcessFullBlock32(lengths,
            ref core._h0, ref core._h1, ref core._h2, ref core._h3, ref core._h4,
            core._r0, core._r1, core._r2, core._r3, core._r4,
            core._s1, core._s2, core._s3, core._s4);
#endif

        core.Finalize(tag);
    }

    // ================================================================
    // Internal static helpers — shared with Poly1305Mac
    // ================================================================

    /// <summary>
    /// Loads and clamps the Poly1305 key into 5 × 26-bit limbs.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void LoadKey32(ReadOnlySpan<byte> key,
        out uint r0, out uint r1, out uint r2, out uint r3, out uint r4,
        out uint s1, out uint s2, out uint s3, out uint s4,
        out uint pad0, out uint pad1, out uint pad2, out uint pad3)
    {
        uint t0 = BinaryPrimitives.ReadUInt32LittleEndian(key) & 0x0fffffff;
        uint t1 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(1 * sizeof(uint))) & 0x0ffffffc;
        uint t2 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(2 * sizeof(uint))) & 0x0ffffffc;
        uint t3 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(3 * sizeof(uint))) & 0x0ffffffc;

        r0 = t0 & 0x03ffffff;
        r1 = ((t0 >> 26) | (t1 << 6)) & 0x03ffffff;
        r2 = ((t1 >> 20) | (t2 << 12)) & 0x03ffffff;
        r3 = ((t2 >> 14) | (t3 << 18)) & 0x03ffffff;
        r4 = (t3 >> 8) & 0x03ffffff;

        s1 = r1 * 5;
        s2 = r2 * 5;
        s3 = r3 * 5;
        s4 = r4 * 5;

        pad0 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(4 * sizeof(uint)));
        pad1 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(5 * sizeof(uint)));
        pad2 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(6 * sizeof(uint)));
        pad3 = BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(7 * sizeof(uint)));
    }

    /// <summary>
    /// Accumulates a single full 16-byte block and performs multiply-reduce (donna-32).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void ProcessFullBlock32(
        ReadOnlySpan<byte> block,
        ref uint h0, ref uint h1, ref uint h2, ref uint h3, ref uint h4,
        uint r0, uint r1, uint r2, uint r3, uint r4,
        uint s1, uint s2, uint s3, uint s4)
    {
        uint b0 = BinaryPrimitives.ReadUInt32LittleEndian(block);
        uint b1 = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(1 * sizeof(uint)));
        uint b2 = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(2 * sizeof(uint)));
        uint b3 = BinaryPrimitives.ReadUInt32LittleEndian(block.Slice(3 * sizeof(uint)));

        h0 += b0 & 0x03ffffff;
        h1 += ((b0 >> 26) | (b1 << 6)) & 0x03ffffff;
        h2 += ((b1 >> 20) | (b2 << 12)) & 0x03ffffff;
        h3 += ((b2 >> 14) | (b3 << 18)) & 0x03ffffff;
        h4 += (b3 >> 8) | (1u << 24);

        MultiplyAndReduce32(ref h0, ref h1, ref h2, ref h3, ref h4,
            r0, r1, r2, r3, r4, s1, s2, s3, s4);
    }

    /// <summary>
    /// Accumulates a partial block (&lt;16 bytes) and performs multiply-reduce (donna-32).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void ProcessPartialBlock32(
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
        uint b1 = BinaryPrimitives.ReadUInt32LittleEndian(padded.Slice(1 * sizeof(uint)));
        uint b2 = BinaryPrimitives.ReadUInt32LittleEndian(padded.Slice(2 * sizeof(uint)));
        uint b3 = BinaryPrimitives.ReadUInt32LittleEndian(padded.Slice(3 * sizeof(uint)));

        h0 += b0 & 0x03ffffff;
        h1 += ((b0 >> 26) | (b1 << 6)) & 0x03ffffff;
        h2 += ((b1 >> 20) | (b2 << 12)) & 0x03ffffff;
        h3 += ((b2 >> 14) | (b3 << 18)) & 0x03ffffff;
        h4 += b3 >> 8;

        MultiplyAndReduce32(ref h0, ref h1, ref h2, ref h3, ref h4,
            r0, r1, r2, r3, r4, s1, s2, s3, s4);
    }

    /// <summary>
    /// Multiplies the accumulator by r and performs partial reduction mod 2^130 − 5 (donna-32).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void MultiplyAndReduce32(
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
    /// Performs final reduction and adds the pad to produce the 16-byte tag (donna-32).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void Finalize32(
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
        BinaryPrimitives.WriteUInt32LittleEndian(tag.Slice(1 * sizeof(uint)), (uint)f1);
        BinaryPrimitives.WriteUInt32LittleEndian(tag.Slice(2 * sizeof(uint)), (uint)f2);
        BinaryPrimitives.WriteUInt32LittleEndian(tag.Slice(3 * sizeof(uint)), (uint)f3);
    }

#if NET8_0_OR_GREATER
    // ================================================================
    // Donna-64: 3 × 44-bit limbs with Math.BigMul (64×64→128-bit)
    // ================================================================

    /// <summary>
    /// Loads and clamps the Poly1305 key into 3 × 44-bit limbs.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void LoadKey64(ReadOnlySpan<byte> key,
        out ulong r0, out ulong r1, out ulong r2,
        out ulong s1, out ulong s2,
        out ulong padLo, out ulong padHi)
    {
        ulong t0 = BinaryPrimitives.ReadUInt64LittleEndian(key);
        ulong t1 = BinaryPrimitives.ReadUInt64LittleEndian(key.Slice(sizeof(ulong)));
        t0 &= 0x0ffffffc0fffffff;
        t1 &= 0x0ffffffc0ffffffc;

        r0 = t0 & Mask44;
        r1 = ((t0 >> 44) | (t1 << 20)) & Mask44;
        r2 = (t1 >> 24) & Mask42;

        s1 = r1 * 20;
        s2 = r2 * 20;

        padLo = BinaryPrimitives.ReadUInt64LittleEndian(key.Slice(2 * sizeof(ulong)));
        padHi = BinaryPrimitives.ReadUInt64LittleEndian(key.Slice(3 * sizeof(ulong)));
    }

    /// <summary>
    /// Adds a full 16-byte block to the accumulator with hibit set (donna-64).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void AddFullBlock64(ReadOnlySpan<byte> block,
        ref ulong h0, ref ulong h1, ref ulong h2)
    {
        ulong m0 = BinaryPrimitives.ReadUInt64LittleEndian(block);
        ulong m1 = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(sizeof(ulong)));
        h0 += m0 & Mask44;
        h1 += ((m0 >> 44) | (m1 << 20)) & Mask44;
        h2 += ((m1 >> 24) & Mask42) | (1UL << 40);
    }

    /// <summary>
    /// Adds a partial block to the accumulator (0x01 sentinel, no hibit) (donna-64).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void AddPartialBlock64(ReadOnlySpan<byte> block,
        ref ulong h0, ref ulong h1, ref ulong h2)
    {
        Span<byte> padded = stackalloc byte[BlockSize];
        padded.Clear();
        block.CopyTo(padded);
        padded[block.Length] = 0x01;

        ulong m0 = BinaryPrimitives.ReadUInt64LittleEndian(padded);
        ulong m1 = BinaryPrimitives.ReadUInt64LittleEndian(padded.Slice(sizeof(ulong)));
        h0 += m0 & Mask44;
        h1 += ((m0 >> 44) | (m1 << 20)) & Mask44;
        h2 += (m1 >> 24) & Mask42;
    }

    /// <summary>
    /// Multiplies h by r modulo 2¹³⁰ − 5 using 9 widening 64×64→128-bit multiplies (donna-64).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void MulReduce64(
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
    /// Performs final reduction and adds the pad for 3 × 44-bit limbs (donna-64).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static void Finalize64(ulong h0, ulong h1, ulong h2,
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
        BinaryPrimitives.WriteUInt64LittleEndian(tag.Slice(sizeof(ulong)), f1);
    }
#endif
}
