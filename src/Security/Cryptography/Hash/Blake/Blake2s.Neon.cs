// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

#if NET8_0_OR_GREATER && EXPERIMENTAL

using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

/// <summary>
/// BLAKE2s ARM NEON-accelerated compression with fully unrolled rounds.
/// </summary>
/// <remarks>
/// State is loaded from and stored back to the shared <c>_state[]</c> array via pointers.
/// Uses <c>VectorTableLookup</c> for byte-aligned rotations (16, 8) and shift+or for
/// non-byte-aligned rotations (12, 7).
/// </remarks>
public sealed partial class Blake2s
{
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static unsafe void CompressNeon(byte* msgPtr, uint* state, ulong bytesCompressed, bool isFinal)
    {
        var row0 = AdvSimd.LoadVector128(state);
        var row1 = AdvSimd.LoadVector128(state + 4);
        var row2 = IVLow;
        var counterVec = Vector128.Create((uint)bytesCompressed, (uint)(bytesCompressed >> 32), 0U, 0U);
        var row3 = IVHigh ^ counterVec;
        if (isFinal) row3 ^= FinalMask;

        var orig0 = row0;
        var orig1 = row1;

        uint* mr = (uint*)msgPtr;
        uint w0  = mr[0],  w1  = mr[1],  w2  = mr[2],  w3  = mr[3],
             w4  = mr[4],  w5  = mr[5],  w6  = mr[6],  w7  = mr[7],
             w8  = mr[8],  w9  = mr[9],  w10 = mr[10], w11 = mr[11],
             w12 = mr[12], w13 = mr[13], w14 = mr[14], w15 = mr[15];

        // Round 0 — sigma: 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w0, w2, w4, w6));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w1, w3, w5, w7));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w8, w10, w12, w14));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w9, w11, w13, w15));
        PermuteNeon(ref row3, ref row2, ref row1);

        // Round 1 — sigma: 14,10,4,8,9,15,13,6,1,12,0,2,11,7,5,3
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w14, w4, w9, w13));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w10, w8, w15, w6));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w1, w0, w11, w5));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w12, w2, w7, w3));
        PermuteNeon(ref row3, ref row2, ref row1);

        // Round 2 — sigma: 11,8,12,0,5,2,15,13,10,14,3,6,7,1,9,4
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w11, w12, w5, w15));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w8, w0, w2, w13));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w10, w3, w7, w9));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w14, w6, w1, w4));
        PermuteNeon(ref row3, ref row2, ref row1);

        // Round 3 — sigma: 7,9,3,1,13,12,11,14,2,6,5,10,4,0,15,8
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w7, w3, w13, w11));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w9, w1, w12, w14));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w2, w5, w4, w15));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w6, w10, w0, w8));
        PermuteNeon(ref row3, ref row2, ref row1);

        // Round 4 — sigma: 9,0,5,7,2,4,10,15,14,1,11,12,6,8,3,13
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w9, w5, w2, w10));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w0, w7, w4, w15));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w14, w11, w6, w3));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w1, w12, w8, w13));
        PermuteNeon(ref row3, ref row2, ref row1);

        // Round 5 — sigma: 2,12,6,10,0,11,8,3,4,13,7,5,15,14,1,9
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w2, w6, w0, w8));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w12, w10, w11, w3));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w4, w7, w15, w1));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w13, w5, w14, w9));
        PermuteNeon(ref row3, ref row2, ref row1);

        // Round 6 — sigma: 12,5,1,15,14,13,4,10,0,7,6,3,9,2,8,11
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w12, w1, w14, w4));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w5, w15, w13, w10));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w0, w6, w9, w8));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w7, w3, w2, w11));
        PermuteNeon(ref row3, ref row2, ref row1);

        // Round 7 — sigma: 13,11,7,14,12,1,3,9,5,0,15,4,8,6,2,10
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w13, w7, w12, w3));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w11, w14, w1, w9));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w5, w15, w8, w2));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w0, w4, w6, w10));
        PermuteNeon(ref row3, ref row2, ref row1);

        // Round 8 — sigma: 6,15,14,9,11,3,0,8,12,2,13,7,1,4,10,5
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w6, w14, w11, w0));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w15, w9, w3, w8));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w12, w13, w1, w10));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w2, w7, w4, w5));
        PermuteNeon(ref row3, ref row2, ref row1);

        // Round 9 — sigma: 10,2,8,4,7,6,1,5,15,11,9,14,3,12,13,0
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w10, w8, w7, w1));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w2, w4, w6, w5));
        PermuteNeon(ref row1, ref row2, ref row3);
        GRoundXNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w15, w9, w3, w13));
        GRoundYNeon(ref row0, ref row1, ref row2, ref row3, Vector128.Create(w11, w14, w12, w0));
        PermuteNeon(ref row3, ref row2, ref row1);

        row0 = AdvSimd.Xor(AdvSimd.Xor(row0, row2), orig0);
        row1 = AdvSimd.Xor(AdvSimd.Xor(row1, row3), orig1);

        AdvSimd.Store(state, row0);
        AdvSimd.Store(state + 4, row1);
    }

    /// <summary>
    /// Performs one Gx half-round: <c>a += b + x; d = ror(d^a, 16); c += d; b = ror(b^c, 12)</c>.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundXNeon(
        ref Vector128<uint> a, ref Vector128<uint> b,
        ref Vector128<uint> c, ref Vector128<uint> d,
        Vector128<uint> x)
    {
        a = AdvSimd.Add(a, AdvSimd.Add(b, x));
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), RotateMask16).AsUInt32();
        c = AdvSimd.Add(c, d);
        var t = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftRightLogical(t, 12), AdvSimd.ShiftLeftLogical(t, 20));
    }

    /// <summary>
    /// Performs one Gy half-round: <c>a += b + y; d = ror(d^a, 8); c += d; b = ror(b^c, 7)</c>.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GRoundYNeon(
        ref Vector128<uint> a, ref Vector128<uint> b,
        ref Vector128<uint> c, ref Vector128<uint> d,
        Vector128<uint> y)
    {
        a = AdvSimd.Add(a, AdvSimd.Add(b, y));
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), RotateMask8).AsUInt32();
        c = AdvSimd.Add(c, d);
        var t = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftRightLogical(t, 7), AdvSimd.ShiftLeftLogical(t, 25));
    }

    /// <summary>
    /// Diagonal permutation. Call as <c>PermuteNeon(ref row1, ref row2, ref row3)</c> to
    /// diagonalize and <c>PermuteNeon(ref row3, ref row2, ref row1)</c> to un-diagonalize.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PermuteNeon(
        ref Vector128<uint> a, ref Vector128<uint> b, ref Vector128<uint> c)
    {
        a = AdvSimd.ExtractVector128(a.AsByte(), a.AsByte(), 4).AsUInt32();
        b = AdvSimd.ExtractVector128(b.AsByte(), b.AsByte(), 8).AsUInt32();
        c = AdvSimd.ExtractVector128(c.AsByte(), c.AsByte(), 12).AsUInt32();
    }
}

#endif
