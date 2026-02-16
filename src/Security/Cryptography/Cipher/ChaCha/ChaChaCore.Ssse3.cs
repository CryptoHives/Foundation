// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// Core ChaCha20 operations as specified in RFC 8439.
/// </summary>
/// <remarks>
/// <para>
/// ChaCha20 is a stream cipher designed by Daniel J. Bernstein. It uses a 256-bit key,
/// a 96-bit nonce, and a 32-bit block counter to generate a keystream that is XORed
/// with the plaintext.
/// </para>
/// <para>
/// <b>Implementation notes:</b>
/// <list type="bullet">
///   <item><description>Uses the IETF variant with 96-bit nonce (RFC 8439)</description></item>
///   <item><description>20 rounds (10 double-rounds)</description></item>
///   <item><description>Little-endian byte order</description></item>
/// </list>
/// </para>
/// </remarks>
internal partial struct ChaChaCore
{
    /// <summary>
    /// Gets the SIMD instruction sets supported by ChaCha20 on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
#if NET8_0_OR_GREATER
            if (Ssse3.IsSupported) support |= SimdSupport.Ssse3;
#endif
            return support;
        }
    }

#if NET8_0_OR_GREATER
    // Byte-shuffle masks for SSSE3 rotate-left on packed 32-bit words.
    // ROL16: swap the two 16-bit halves within each 32-bit lane.
    private static readonly Vector128<byte> RotateLeftMask16 = Vector128.Create(
        (byte)2, 3, 0, 1, 6, 7, 4, 5, 10, 11, 8, 9, 14, 15, 12, 13);

    // ROL8: rotate each 32-bit lane left by 8 bits (move byte 0 to the top).
    private static readonly Vector128<byte> RotateLeftMask8 = Vector128.Create(
        (byte)3, 0, 1, 2, 7, 4, 5, 6, 11, 8, 9, 10, 15, 12, 13, 14);

    // Vector constant for incrementing the block counter without scalar round-trip.
    private static readonly Vector128<uint> CounterIncrement = Vector128.Create(1u, 0u, 0u, 0u);

    /// <summary>
    /// SSSE3-accelerated ChaCha20 Transform operating on 4 × <see cref="Vector128{T}"/> rows.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Maps the 4×4 state matrix to four <see cref="Vector128{UInt32}"/> vectors (one per row).
    /// The column round operates on the four rows directly. The diagonal round is implemented
    /// by shuffling rows 1, 2, 3 left by 1, 2, 3 positions respectively, performing the column
    /// round, then unshuffling.
    /// </para>
    /// <para>
    /// Uses SSSE3 byte-shuffle (<see cref="Ssse3.Shuffle(Vector128{byte}, Vector128{byte})"/>)
    /// for the byte-aligned rotations (ROL16, ROL8), reducing each from 3 instructions
    /// (shift, shift, or) to 1 instruction. Non-byte-aligned rotations (ROL12, ROL7) still use
    /// the SSE2 shift+or pattern.
    /// </para>
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void TransformSsse3(
        ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter,
        ReadOnlySpan<byte> input, Span<byte> output)
    {
        // Load initial state into 4 Vector128<uint> rows.
        // SSSE3 implies x86 (always little-endian), so we can load key/nonce directly.
        Vector128<uint> row0 = Vector128.LoadUnsafe(
            ref MemoryMarshal.GetArrayDataReference(Sigma));
        Vector128<uint> row1 = Vector128.LoadUnsafe(
            ref MemoryMarshal.GetReference(key)).AsUInt32();
        Vector128<uint> row2 = Vector128.LoadUnsafe(
            ref MemoryMarshal.GetReference(key), 16).AsUInt32();
        Vector128<uint> row3Base = Vector128.Create(
            counter,
            MemoryMarshal.Cast<byte, uint>(nonce)[0],
            MemoryMarshal.Cast<byte, uint>(nonce)[1],
            MemoryMarshal.Cast<byte, uint>(nonce)[2]);

        // Cache shuffle masks in locals for the inner loop.
        Vector128<byte> rol16 = RotateLeftMask16;
        Vector128<byte> rol8 = RotateLeftMask8;

        int offset = 0;
        Span<byte> ks = stackalloc byte[BlockSizeBytes];
        while (offset < input.Length)
        {
            // Working copy (row3 has per-block counter)
            Vector128<uint> row3 = row3Base;
            Vector128<uint> w0 = row0, w1 = row1, w2 = row2, w3 = row3;

            // 10 double-rounds
            for (int i = 0; i < Rounds; i += 2)
            {
                // Column round
                Ssse3QuarterRound(ref w0, ref w1, ref w2, ref w3, rol16, rol8);

                // Diagonal round: rotate rows to align diagonals into columns
                w1 = Sse2.Shuffle(w1, 0b_00_11_10_01); // <<< 1
                w2 = Sse2.Shuffle(w2, 0b_01_00_11_10); // <<< 2
                w3 = Sse2.Shuffle(w3, 0b_10_01_00_11); // <<< 3

                Ssse3QuarterRound(ref w0, ref w1, ref w2, ref w3, rol16, rol8);

                // Un-rotate rows
                w1 = Sse2.Shuffle(w1, 0b_10_01_00_11); // >>> 1
                w2 = Sse2.Shuffle(w2, 0b_01_00_11_10); // >>> 2
                w3 = Sse2.Shuffle(w3, 0b_00_11_10_01); // >>> 3
            }

            // Add original state
            w0 = Sse2.Add(w0, row0);
            w1 = Sse2.Add(w1, row1);
            w2 = Sse2.Add(w2, row2);
            w3 = Sse2.Add(w3, row3);

            int remaining = input.Length - offset;

            if (remaining >= BlockSizeBytes)
            {
                // Full block: XOR keystream with input
                ref byte inRef = ref MemoryMarshal.GetReference(input.Slice(offset));
                ref byte outRef = ref MemoryMarshal.GetReference(output.Slice(offset));

                Vector128<byte> in0 = Vector128.LoadUnsafe(ref inRef);
                Vector128<byte> in1 = Vector128.LoadUnsafe(ref inRef, 16);
                Vector128<byte> in2 = Vector128.LoadUnsafe(ref inRef, 32);
                Vector128<byte> in3 = Vector128.LoadUnsafe(ref inRef, 48);

                Vector128<byte> out0 = Sse2.Xor(in0, w0.AsByte());
                Vector128<byte> out1 = Sse2.Xor(in1, w1.AsByte());
                Vector128<byte> out2 = Sse2.Xor(in2, w2.AsByte());
                Vector128<byte> out3 = Sse2.Xor(in3, w3.AsByte());

                out0.StoreUnsafe(ref outRef);
                out1.StoreUnsafe(ref outRef, 16);
                out2.StoreUnsafe(ref outRef, 32);
                out3.StoreUnsafe(ref outRef, 48);
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

            offset += BlockSizeBytes;

            // Increment counter in vector domain (no scalar round-trip)
            row3Base = Sse2.Add(row3Base, CounterIncrement);
        }
    }

    /// <summary>
    /// SSSE3 ChaCha quarter-round on four <see cref="Vector128{UInt32}"/> rows simultaneously.
    /// </summary>
    /// <remarks>
    /// Uses <see cref="Ssse3.Shuffle(Vector128{byte}, Vector128{byte})"/> for byte-aligned
    /// rotations (ROL16, ROL8) and SSE2 shift+or for non-byte-aligned rotations (ROL12, ROL7).
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Ssse3QuarterRound(
        ref Vector128<uint> a, ref Vector128<uint> b,
        ref Vector128<uint> c, ref Vector128<uint> d,
        Vector128<byte> rol16, Vector128<byte> rol8)
    {
        a = Sse2.Add(a, b);
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), rol16).AsUInt32();

        c = Sse2.Add(c, d);
        b = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftLeftLogical(b, 12), Sse2.ShiftRightLogical(b, 20));

        a = Sse2.Add(a, b);
        d = Ssse3.Shuffle(Sse2.Xor(d, a).AsByte(), rol8).AsUInt32();

        c = Sse2.Add(c, d);
        b = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftLeftLogical(b, 7), Sse2.ShiftRightLogical(b, 25));
    }
#endif
}
