// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

#if NET8_0_OR_GREATER

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

/// <summary>
/// ARM NEON-accelerated ChaCha20 transform using AdvSimd intrinsics.
/// </summary>
/// <remarks>
/// <para>
/// Maps the 4×4 state matrix to four <see cref="Vector128{UInt32}"/> vectors (one per row),
/// mirroring the SSSE3 implementation. Uses <c>AdvSimd.Arm64.VectorTableLookup</c>
/// for byte-aligned rotations (ROL16, ROL8) and shift+or for non-byte-aligned rotations
/// (ROL12, ROL7).
/// </para>
/// <para>
/// Diagonal permutation uses <see cref="AdvSimd.ExtractVector128(Vector128{byte}, Vector128{byte}, byte)"/>
/// for element rotation, following the pattern established in <c>Blake2s.Neon.cs</c>.
/// </para>
/// </remarks>
internal static class ChaChaCore_Neon
{
    // Byte-shuffle masks for NEON VectorTableLookup rotate-left on packed 32-bit words.
    // These are identical to the SSSE3 PSHUFB masks on little-endian systems.

    // ROL16: swap the two 16-bit halves within each 32-bit lane.
    private static readonly Vector128<byte> NeonRotateLeftMask16 = Vector128.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    // ROL8: rotate each 32-bit lane left by 8 bits (move byte 0 to the top).
    private static readonly Vector128<byte> NeonRotateLeftMask8 = Vector128.Create(
        (byte)3, 0, 1, 2, 7, 4, 5, 6, 11, 8, 9, 10, 15, 12, 13, 14);

    // Vector constant for incrementing the block counter without scalar round-trip.
    private static readonly Vector128<uint> NeonCounterIncrement = Vector128.Create(1u, 0u, 0u, 0u);

    /// <summary>
    /// Gets the SIMD instruction sets supported by ChaCha20 on the current platform.
    /// </summary>
    public static SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
            if (AdvSimd.Arm64.IsSupported) support |= SimdSupport.Neon;
            return support;
        }
    }

    /// <summary>
    /// NEON-accelerated ChaCha20 Transform operating on 4 × <see cref="Vector128{T}"/> rows.
    /// </summary>
    /// <remarks>
    /// Uses <c>AdvSimd.Arm64.VectorTableLookup</c> (TBL instruction) for byte-aligned
    /// rotations and <see cref="AdvSimd.ExtractVector128(Vector128{byte}, Vector128{byte}, byte)"/>
    /// (EXT instruction) for diagonal element permutations.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Transform(
        ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter,
        ReadOnlySpan<byte> input, Span<byte> output)
    {
        // Load initial state into 4 Vector128<uint> rows.
        // ARM64 is always little-endian, so we can load key/nonce directly.
        Vector128<uint> row0 = Vector128.LoadUnsafe(
            ref MemoryMarshal.GetArrayDataReference(ChaChaCore.Sigma));

        ref byte keyRef = ref MemoryMarshal.GetReference(key);
        Vector128<uint> row1 = Vector128.LoadUnsafe(ref keyRef).AsUInt32();
        Vector128<uint> row2 = Vector128.LoadUnsafe(ref keyRef, 16).AsUInt32();

        ReadOnlySpan<uint> nonceUInt = MemoryMarshal.Cast<byte, uint>(nonce);
        Vector128<uint> row3Base = Vector128.Create(
            counter, nonceUInt[0], nonceUInt[1], nonceUInt[2]);

        int offset = 0;
        Span<byte> ks = stackalloc byte[ChaChaCore.BlockSizeBytes];
        while (offset < input.Length)
        {
            // Working copy (row3 has per-block counter)
            Vector128<uint> row3 = row3Base;
            Vector128<uint> w0 = row0, w1 = row1, w2 = row2, w3 = row3;

            // 10 double-rounds
            for (int i = 0; i < ChaChaCore.Rounds; i += 2)
            {
                // Column round
                QRoundNeon(ref w0, ref w1, ref w2, ref w3);

                // Diagonal round: rotate rows to align diagonals into columns
                DiagPermuteNeon(ref w1, ref w2, ref w3);
                QRoundNeon(ref w0, ref w1, ref w2, ref w3);

                // Un-rotate rows
                DiagPermuteNeon(ref w3, ref w2, ref w1);
            }

            // Add original state
            w0 = AdvSimd.Add(w0, row0);
            w1 = AdvSimd.Add(w1, row1);
            w2 = AdvSimd.Add(w2, row2);
            w3 = AdvSimd.Add(w3, row3);

            int remaining = input.Length - offset;

            if (remaining >= ChaChaCore.BlockSizeBytes)
            {
                // Full block: XOR keystream with input
                ref byte inRef = ref MemoryMarshal.GetReference(input.Slice(offset));
                ref byte outRef = ref MemoryMarshal.GetReference(output.Slice(offset));

                Vector128<byte> in0 = Vector128.LoadUnsafe(ref inRef);
                Vector128<byte> in1 = Vector128.LoadUnsafe(ref inRef, 16);
                Vector128<byte> in2 = Vector128.LoadUnsafe(ref inRef, 32);
                Vector128<byte> in3 = Vector128.LoadUnsafe(ref inRef, 48);

                (in0 ^ w0.AsByte()).StoreUnsafe(ref outRef);
                (in1 ^ w1.AsByte()).StoreUnsafe(ref outRef, 16);
                (in2 ^ w2.AsByte()).StoreUnsafe(ref outRef, 32);
                (in3 ^ w3.AsByte()).StoreUnsafe(ref outRef, 48);
            }
            else
            {
                // Partial block: serialize to temp buffer, XOR byte-by-byte
                w0.AsByte().CopyTo(ks);
                w1.AsByte().CopyTo(ks.Slice(16));
                w2.AsByte().CopyTo(ks.Slice(32));
                w3.AsByte().CopyTo(ks.Slice(48));

                for (int i = 0; i < remaining; i++)
                {
                    output[offset + i] = (byte)(input[offset + i] ^ ks[i]);
                }
            }

            offset += ChaChaCore.BlockSizeBytes;

            // Increment counter in vector domain (no scalar round-trip)
            row3Base = AdvSimd.Add(row3Base, NeonCounterIncrement);
        }
    }

    /// <summary>
    /// NEON diagonal permutation using EXT (ExtractVector128) for element rotation.
    /// </summary>
    /// <remarks>
    /// <see cref="AdvSimd.ExtractVector128(Vector128{byte}, Vector128{byte}, byte)"/> concatenates
    /// the two source registers and extracts 16 bytes starting at the given byte offset,
    /// providing efficient element-level rotation.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void DiagPermuteNeon(ref Vector128<uint> w1, ref Vector128<uint> w2, ref Vector128<uint> w3)
    {
        // rotate elements left by 1 (byte offset 4)
        w1 = AdvSimd.ExtractVector128(w1.AsByte(), w1.AsByte(), 4).AsUInt32();
        // swap halves (byte offset 8)
        w2 = AdvSimd.ExtractVector128(w2.AsByte(), w2.AsByte(), 8).AsUInt32();
        // rotate elements right by 1 (byte offset 12)
        w3 = AdvSimd.ExtractVector128(w3.AsByte(), w3.AsByte(), 12).AsUInt32();
    }

    /// <summary>
    /// NEON ChaCha quarter-round on four <see cref="Vector128{UInt32}"/> rows simultaneously.
    /// </summary>
    /// <remarks>
    /// Uses <c>AdvSimd.Arm64.VectorTableLookup</c> (TBL instruction) for byte-aligned
    /// rotations (ROL16, ROL8) and AdvSimd shift+or for non-byte-aligned rotations (ROL12, ROL7).
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void QRoundNeon(
        ref Vector128<uint> a, ref Vector128<uint> b,
        ref Vector128<uint> c, ref Vector128<uint> d)
    {
        a = AdvSimd.Add(a, b);
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), NeonRotateLeftMask16).AsUInt32();

        c = AdvSimd.Add(c, d);
        var t = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftLeftLogical(t, 12), AdvSimd.ShiftRightLogical(t, 20));

        a = AdvSimd.Add(a, b);
        d = AdvSimd.Arm64.VectorTableLookup((d ^ a).AsByte(), NeonRotateLeftMask8).AsUInt32();

        c = AdvSimd.Add(c, d);
        t = b ^ c;
        b = AdvSimd.Or(AdvSimd.ShiftLeftLogical(t, 7), AdvSimd.ShiftRightLogical(t, 25));
    }
}

#endif
