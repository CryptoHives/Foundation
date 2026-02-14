// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER

using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// Computes the BLAKE3 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of BLAKE3 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// BLAKE3 is a cryptographic hash function that is much faster than SHA-256 while
/// maintaining high security. It supports variable output length (XOF mode).
/// </para>
/// <para>
/// BLAKE3 supports three modes: standard hashing, keyed hashing (MAC), and key derivation.
/// </para>
/// </remarks>
public sealed partial class Blake3 : HashAlgorithm
{
    // Pre-computed shuffle masks for byte-aligned rotations on 32-bit words
    // Rotate right by 16 bits
    private static readonly Vector128<byte> RotateMask16 = Vector128.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    // Rotate right by 8 bits
    private static readonly Vector128<byte> RotateMask8 = Vector128.Create(
        (byte)1, 2, 3, 0, 5, 6, 7, 4, 9, 10, 11, 8, 13, 14, 15, 12);

    // Pre-computed IV vectors
    private static readonly Vector128<uint> IVLow = Vector128.Create(
        0x6a09e667U, 0xbb67ae85U, 0x3c6ef372U, 0xa54ff53aU);

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    /// <returns>Flags indicating which SIMD instruction sets are available.</returns>
    internal static new SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
            if (Ssse3.IsSupported) support |= SimdSupport.Ssse3;
            return support;
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void CompressBlockSsse3(ReadOnlySpan<byte> block, uint blockLen, ulong counter, uint flags)
    {
        // On x86 (always little-endian), cast directly — no copy needed
        ReadOnlySpan<uint> m = MemoryMarshal.Cast<byte, uint>(block);

        // Initialize rows
        var row0 = Vector128.Create<uint>(_cv.AsSpan(0, 4));
        var row1 = Vector128.Create<uint>(_cv.AsSpan(4, 4));
        var row2 = IVLow;
        var row3 = Vector128.Create((uint)counter, (uint)(counter >> 32), blockLen, flags);

        GRounds(m, ref row0, ref row1, ref row2, ref row3);

        // Finalize: cv = row0 ^ row2, cv = row1 ^ row3
        row0 = Sse2.Xor(row0, row2);
        row0.CopyTo(_cv.AsSpan(0, 4));
        row1 = Sse2.Xor(row1, row3);
        row1.CopyTo(_cv.AsSpan(4, 4));
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void SqueezeRootBlockSsse3(ulong counter, Span<byte> destination)
    {
        ReadOnlySpan<uint> m = _rootBlock;
        var row0 = Vector128.Create<uint>(_rootCv.AsSpan(0, 4));
        var row1 = Vector128.Create<uint>(_rootCv.AsSpan(4, 4));
        var row2 = IVLow;
        var row3 = Vector128.Create((uint)counter, (uint)(counter >> 32), _rootBlockLen, _rootFlags);

        GRounds(m, ref row0, ref row1, ref row2, ref row3);

        // Full 16-word output (x86 is always little-endian)
        Sse2.Xor(row0, row2).AsByte().CopyTo(destination);
        Sse2.Xor(row1, row3).AsByte().CopyTo(destination.Slice(16));
        Sse2.Xor(row2, Vector128.Create<uint>(_rootCv.AsSpan(0, 4))).AsByte().CopyTo(destination.Slice(32));
        Sse2.Xor(row3, Vector128.Create<uint>(_rootCv.AsSpan(4, 4))).AsByte().CopyTo(destination.Slice(48));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private void GRounds(
        ReadOnlySpan<uint> m,
        ref Vector128<uint> row0,
        ref Vector128<uint> row1,
        ref Vector128<uint> row2,
        ref Vector128<uint> row3)
    {
        // 7 rounds of mixing with BLAKE3's fixed message schedule
        // Round 1: 0,1,2,3,4,5,6,7 | 8,9,10,11,12,13,14,15
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[0], m[2], m[4], m[6]),
            Vector128.Create(m[1], m[3], m[5], m[7]));
        DiagPermute(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[8], m[10], m[12], m[14]),
            Vector128.Create(m[9], m[11], m[13], m[15]));
        DiagPermute(ref row3, ref row2, ref row1);

        // Round 2: 2,6,3,10,7,0,4,13 | 1,11,12,5,9,14,15,8
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[2], m[3], m[7], m[4]),
            Vector128.Create(m[6], m[10], m[0], m[13]));
        DiagPermute(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[1], m[12], m[9], m[15]),
            Vector128.Create(m[11], m[5], m[14], m[8]));
        DiagPermute(ref row3, ref row2, ref row1);

        // Round 3: 3,4,10,12,13,2,7,14 | 6,5,9,0,11,15,8,1
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[3], m[10], m[13], m[7]),
            Vector128.Create(m[4], m[12], m[2], m[14]));
        DiagPermute(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[6], m[9], m[11], m[8]),
            Vector128.Create(m[5], m[0], m[15], m[1]));
        DiagPermute(ref row3, ref row2, ref row1);

        // Round 4: 10,7,12,9,14,3,13,15 | 4,0,11,2,5,8,1,6
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[10], m[12], m[14], m[13]),
            Vector128.Create(m[7], m[9], m[3], m[15]));
        DiagPermute(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[4], m[11], m[5], m[1]),
            Vector128.Create(m[0], m[2], m[8], m[6]));
        DiagPermute(ref row3, ref row2, ref row1);

        // Round 5: 12,13,9,11,15,10,14,8 | 7,2,5,3,0,1,6,4
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[12], m[9], m[15], m[14]),
            Vector128.Create(m[13], m[11], m[10], m[8]));
        DiagPermute(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[7], m[5], m[0], m[6]),
            Vector128.Create(m[2], m[3], m[1], m[4]));
        DiagPermute(ref row3, ref row2, ref row1);

        // Round 6: 9,14,11,5,8,12,15,1 | 13,3,0,10,2,6,4,7
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[9], m[11], m[8], m[15]),
            Vector128.Create(m[14], m[5], m[12], m[1]));
        DiagPermute(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[13], m[0], m[2], m[4]),
            Vector128.Create(m[3], m[10], m[6], m[7]));
        DiagPermute(ref row3, ref row2, ref row1);

        // Round 7: 11,15,5,0,1,9,8,6 | 14,10,2,12,3,4,7,13
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[11], m[5], m[1], m[8]),
            Vector128.Create(m[15], m[0], m[9], m[6]));
        DiagPermute(ref row1, ref row2, ref row3);
        GRound(ref row0, ref row1, ref row2, ref row3,
            Vector128.Create(m[14], m[2], m[3], m[7]),
            Vector128.Create(m[10], m[12], m[4], m[13]));
        DiagPermute(ref row3, ref row2, ref row1);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void DiagPermute(ref Vector128<uint> row1, ref Vector128<uint> row2, ref Vector128<uint> row3)
    {
        row1 = Sse2.Shuffle(row1, 0b00_11_10_01); // 1,2,3,0
        row2 = Sse2.Shuffle(row2, 0b01_00_11_10); // 2,3,0,1
        row3 = Sse2.Shuffle(row3, 0b10_01_00_11); // 3,0,1,2
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRound(
        ref Vector128<uint> a,
        ref Vector128<uint> b,
        ref Vector128<uint> c,
        ref Vector128<uint> d,
        Vector128<uint> x,
        Vector128<uint> y)
    {
        // a = a + b + x
        a = Sse2.Add(a, Sse2.Add(b, x));
        // d = ror(d ^ a, 16)
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask16).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 12)
        var t1 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t1, 12), Sse2.ShiftLeftLogical(t1, 20));
        // a = a + b + y
        a = Sse2.Add(a, Sse2.Add(b, y));
        // d = ror(d ^ a, 8)
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), RotateMask8).AsUInt32();
        // c = c + d
        c = Sse2.Add(c, d);
        // b = ror(b ^ c, 7)
        var t2 = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftRightLogical(t2, 7), Sse2.ShiftLeftLogical(t2, 25));
    }
}
#endif
