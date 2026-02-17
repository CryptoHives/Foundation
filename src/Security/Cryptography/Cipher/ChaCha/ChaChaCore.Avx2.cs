// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// AVX2-accelerated ChaCha20 transform processing two 64-byte blocks in parallel.
/// </summary>
/// <remarks>
/// <para>
/// Each Vector256 register holds the same row from two independent blocks.
/// The lower 128-bit lane contains block N and the upper lane contains block N+1.
/// All quarter-round operations (add, xor, rotate) are element-wise and therefore
/// operate on both blocks simultaneously, yielding ~2× throughput over the SSSE3 path.
/// </para>
/// <para>
/// Uses VPSHUFB (AVX2 byte shuffle) for the
/// byte-aligned rotations (ROL16, ROL8) and AVX2 shift+or for ROL12 and ROL7.
/// </para>
/// </remarks>
internal partial struct ChaChaCore
{
#if NET8_0_OR_GREATER
    /// <summary>
    /// The number of bytes produced per AVX2 iteration (2 × 64 = 128 bytes).
    /// </summary>
    private const int DualBlockSizeBytes = BlockSizeBytes * 2;

    // VPSHUFB masks for AVX2 rotate-left on packed 32-bit words.
    // Same byte pattern in both 128-bit lanes.
    private static readonly Vector256<byte> Avx2RotateLeftMask16 = Vector256.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13,
        2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    private static readonly Vector256<byte> Avx2RotateLeftMask8 = Vector256.Create(
        (byte)3, 0, 1, 2, 7, 4, 5, 6, 11, 8, 9, 10, 15, 12, 13, 14,
        3, 0, 1, 2, 7, 4, 5, 6, 11, 8, 9, 10, 15, 12, 13, 14);

    // Counter increment for the upper lane: lower lane gets counter+0, upper lane gets counter+1.
    private static readonly Vector256<uint> DualCounterIncrement = Vector256.Create(2u, 0u, 0u, 0u, 2u, 0u, 0u, 0u);

    /// <summary>
    /// AVX2-accelerated ChaCha20 Transform operating on 4 × Vector256 rows,
    /// processing two blocks per iteration.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void TransformAvx2(
        ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter,
        ReadOnlySpan<byte> input, Span<byte> output)
    {
        // small blocks: delegate to SSSE3 single-block path.
        if (DualBlockSizeBytes > input.Length)
        {
            TransformSsse3(key, nonce, counter, input, output);
            return;
        }

        // Load initial 128-bit state rows.
        Vector128<uint> row0_128 = Vector128.LoadUnsafe(
            ref MemoryMarshal.GetArrayDataReference(Sigma));
        Vector128<uint> row1_128 = Vector128.LoadUnsafe(
            ref MemoryMarshal.GetReference(key)).AsUInt32();
        Vector128<uint> row2_128 = Vector128.LoadUnsafe(
            ref MemoryMarshal.GetReference(key), 16).AsUInt32();

        // Broadcast rows 0-2 into both lanes (identical for both blocks).
        Vector256<uint> row0 = Vector256.Create(row0_128, row0_128);
        Vector256<uint> row1 = Vector256.Create(row1_128, row1_128);
        Vector256<uint> row2 = Vector256.Create(row2_128, row2_128);

        // Row 3: lower lane gets counter, upper lane gets counter+1.
        uint n0 = MemoryMarshal.Cast<byte, uint>(nonce)[0];
        uint n1 = MemoryMarshal.Cast<byte, uint>(nonce)[1];
        uint n2 = MemoryMarshal.Cast<byte, uint>(nonce)[2];

        Vector256<uint> row3Base = Vector256.Create(counter, n0, n1, n2, counter + 1, n0, n1, n2);

        // Main loop: process 2 blocks (128 bytes) per iteration.
        int offset = 0;
        while (offset + DualBlockSizeBytes <= input.Length)
        {
            Vector256<uint> row3 = row3Base;
            Vector256<uint> w0 = row0, w1 = row1, w2 = row2, w3 = row3;

            for (int i = 0; i < Rounds; i += 2)
            {
                // Column round
                QRoundAvx2(ref w0, ref w1, ref w2, ref w3);

                // Diagonal round: rotate rows to align diagonals into columns
                DiagPermuteAvx2(ref w1, ref w2, ref w3);
                QRoundAvx2(ref w0, ref w1, ref w2, ref w3);

                // Un-rotate rows
                DiagPermuteAvx2(ref w3, ref w2, ref w1);
            }

            // Add original state
            w0 = Avx2.Add(w0, row0);
            w1 = Avx2.Add(w1, row1);
            w2 = Avx2.Add(w2, row2);
            w3 = Avx2.Add(w3, row3);

            // Extract lower and upper 128-bit lanes, then XOR with input.
            // Block N (lower lane): rows w0..w3 lower halves → bytes [offset .. offset+63]
            // Block N+1 (upper lane): rows w0..w3 upper halves → bytes [offset+64 .. offset+127]
            ref byte inRef = ref MemoryMarshal.GetReference(input.Slice(offset));
            ref byte outRef = ref MemoryMarshal.GetReference(output.Slice(offset));

            // Block N (lower lanes)
            Vector128<byte> in0 = Vector128.LoadUnsafe(ref inRef);
            Vector128<byte> in1 = Vector128.LoadUnsafe(ref inRef, 16);
            Vector128<byte> in2 = Vector128.LoadUnsafe(ref inRef, 32);
            Vector128<byte> in3 = Vector128.LoadUnsafe(ref inRef, 48);

            Sse2.Xor(in0, w0.GetLower().AsByte()).StoreUnsafe(ref outRef);
            Sse2.Xor(in1, w1.GetLower().AsByte()).StoreUnsafe(ref outRef, 16);
            Sse2.Xor(in2, w2.GetLower().AsByte()).StoreUnsafe(ref outRef, 32);
            Sse2.Xor(in3, w3.GetLower().AsByte()).StoreUnsafe(ref outRef, 48);

            // Block N+1 (upper lanes)
            Vector128<byte> in4 = Vector128.LoadUnsafe(ref inRef, 64);
            Vector128<byte> in5 = Vector128.LoadUnsafe(ref inRef, 80);
            Vector128<byte> in6 = Vector128.LoadUnsafe(ref inRef, 96);
            Vector128<byte> in7 = Vector128.LoadUnsafe(ref inRef, 112);
            Sse2.Xor(in4, w0.GetUpper().AsByte()).StoreUnsafe(ref outRef, 64);
            Sse2.Xor(in5, w1.GetUpper().AsByte()).StoreUnsafe(ref outRef, 80);
            Sse2.Xor(in6, w2.GetUpper().AsByte()).StoreUnsafe(ref outRef, 96);
            Sse2.Xor(in7, w3.GetUpper().AsByte()).StoreUnsafe(ref outRef, 112);

            offset += DualBlockSizeBytes;
            row3Base = Avx2.Add(row3Base, DualCounterIncrement);
        }

        // Remaining data: delegate to SSSE3 single-block path.
        if (offset < input.Length)
        {
            // Recover the current counter from the lower lane of row3Base.
            uint currentCounter = row3Base.GetElement(0);
            TransformSsse3(key, nonce, currentCounter, input.Slice(offset), output.Slice(offset));
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void DiagPermuteAvx2(ref Vector256<uint> w1, ref Vector256<uint> w2, ref Vector256<uint> w3)
    {
        w1 = Avx2.Shuffle(w1, 0b_00_11_10_01);
        w2 = Avx2.Shuffle(w2, 0b_01_00_11_10);
        w3 = Avx2.Shuffle(w3, 0b_10_01_00_11);
    }

    /// <summary>
    /// AVX2 ChaCha quarter-round on four Vector256 rows simultaneously,
    /// operating on two blocks in parallel across the lower and upper 128-bit lanes.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void QRoundAvx2(
        ref Vector256<uint> a, ref Vector256<uint> b,
        ref Vector256<uint> c, ref Vector256<uint> d)
    {
        a = Avx2.Add(a, b);
        d = Avx2.Shuffle(Avx2.Xor(d, a).AsByte(), Avx2RotateLeftMask16).AsUInt32();

        c = Avx2.Add(c, d);
        b = Avx2.Xor(b, c);
        b = Avx2.Or(Avx2.ShiftLeftLogical(b, 12), Avx2.ShiftRightLogical(b, 20));

        a = Avx2.Add(a, b);
        d = Avx2.Shuffle(Avx2.Xor(d, a).AsByte(), Avx2RotateLeftMask8).AsUInt32();

        c = Avx2.Add(c, d);
        b = Avx2.Xor(b, c);
        b = Avx2.Or(Avx2.ShiftLeftLogical(b, 7), Avx2.ShiftRightLogical(b, 25));
    }
#endif
}
