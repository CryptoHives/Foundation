// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Byte encoding and decoding of ML-KEM polynomials.
/// </summary>
/// <remarks>
/// Implements FIPS 203 §4.2.1 ByteEncode and ByteDecode functions for
/// packing/unpacking polynomial coefficients into byte arrays with a given bit width d.
/// </remarks>
internal static class Encode
{
    /// <summary>
    /// Encodes a polynomial with 12-bit coefficients to bytes.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteEncode₁₂. Packs 256 coefficients of 12 bits each into 384 bytes.
    /// Used for encoding the public key polynomial vector in NTT domain.
    /// </remarks>
    /// <param name="coeffs">The 256 polynomial coefficients (each in [0, q)).</param>
    /// <param name="output">The 384-byte output buffer.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncode12(ReadOnlySpan<short> coeffs, Span<byte> output)
    {
        for (int i = 0; i < MLKemParams.N / 2; i++)
        {
            ushort a = (ushort)coeffs[2 * i];
            ushort b = (ushort)coeffs[2 * i + 1];
            output[3 * i] = (byte)a;
            output[3 * i + 1] = (byte)((a >> 8) | (b << 4));
            output[3 * i + 2] = (byte)(b >> 4);
        }
    }

    /// <summary>
    /// Decodes bytes to a polynomial with 12-bit coefficients.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteDecode₁₂. Unpacks 384 bytes into 256 coefficients of 12 bits each.
    /// Output coefficients are reduced modulo q = 3329.
    /// </remarks>
    /// <param name="input">The 384-byte input buffer.</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecode12(ReadOnlySpan<byte> input, Span<short> coeffs)
    {
        for (int i = 0; i < MLKemParams.N / 2; i++)
        {
            int b0 = input[3 * i];
            int b1 = input[3 * i + 1];
            int b2 = input[3 * i + 2];
            coeffs[2 * i] = (short)((b0 | (b1 << 8)) & 0xFFF);
            coeffs[2 * i + 1] = (short)(((b1 >> 4) | (b2 << 4)) & 0xFFF);
        }
    }

    /// <summary>
    /// Encodes a polynomial with 1-bit coefficients to bytes.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteEncode₁. Packs 256 single-bit coefficients into 32 bytes.
    /// Used for encoding the message polynomial in K-PKE.
    /// </remarks>
    /// <param name="coeffs">The 256 polynomial coefficients (each 0 or 1).</param>
    /// <param name="output">The 32-byte output buffer.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncode1(ReadOnlySpan<short> coeffs, Span<byte> output)
    {
        for (int i = 0; i < MLKemParams.N / 8; i++)
        {
            byte val = 0;
            for (int j = 0; j < 8; j++)
            {
                val |= (byte)((coeffs[8 * i + j] & 1) << j);
            }

            output[i] = val;
        }
    }

    /// <summary>
    /// Decodes bytes to a polynomial with 1-bit coefficients.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteDecode₁. Unpacks 32 bytes into 256 single-bit coefficients.
    /// </remarks>
    /// <param name="input">The 32-byte input buffer.</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecode1(ReadOnlySpan<byte> input, Span<short> coeffs)
    {
        for (int i = 0; i < MLKemParams.N / 8; i++)
        {
            byte val = input[i];
            for (int j = 0; j < 8; j++)
            {
                coeffs[8 * i + j] = (short)((val >> j) & 1);
            }
        }
    }

    /// <summary>
    /// Encodes a polynomial with d-bit coefficients to bytes.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteEncode_d for arbitrary d ∈ {1, ..., 12}.
    /// Packs 256 coefficients with d bits each into 32·d bytes.
    /// </remarks>
    /// <param name="coeffs">The 256 polynomial coefficients.</param>
    /// <param name="d">The bit width per coefficient.</param>
    /// <param name="output">The output buffer (32·d bytes).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ByteEncodeD(ReadOnlySpan<short> coeffs, int d, Span<byte> output)
    {
        switch (d)
        {
            case 1: ByteEncode1(coeffs, output); return;
            case 4: ByteEncode4(coeffs, output); return;
            case 5: ByteEncode5(coeffs, output); return;
            case 10: ByteEncode10(coeffs, output); return;
            case 11: ByteEncode11(coeffs, output); return;
            case 12: ByteEncode12(coeffs, output); return;
            default: ByteEncodeGeneric(coeffs, d, output); return;
        }
    }

    /// <summary>
    /// Bit-at-a-time fallback for widths without a specialized packer.
    /// </summary>
    /// <remarks>
    /// ML-KEM only ever uses d ∈ {1, 4, 5, 10, 11, 12}, all of which are handled above, so
    /// this runs only if a new parameter set appears. It is kept because the specialized
    /// packers are tested against it: any disagreement is a packing bug.
    /// </remarks>
    /// <param name="coeffs">The 256 polynomial coefficients.</param>
    /// <param name="d">The bit width per coefficient.</param>
    /// <param name="output">The output buffer (32·d bytes).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncodeGeneric(ReadOnlySpan<short> coeffs, int d, Span<byte> output)
    {
        // Slice to the exact width first: this accumulates with |=, so it needs a zeroed
        // destination, and clearing the caller's whole remaining span would be both wasteful
        // and destructive if anything had already been written past 32·d.
        output = output.Slice(0, 32 * d);
        output.Clear();

        int bitPos = 0;
        for (int i = 0; i < MLKemParams.N; i++)
        {
            uint val = (uint)(ushort)coeffs[i];
            for (int b = 0; b < d; b++)
            {
                int byteIdx = bitPos >> 3;
                int bitIdx = bitPos & 7;
                output[byteIdx] |= (byte)(((val >> b) & 1) << bitIdx);
                bitPos++;
            }
        }
    }

    /// <summary>
    /// Decodes bytes to a polynomial with d-bit coefficients.
    /// </summary>
    /// <remarks>
    /// FIPS 203 ByteDecode_d for arbitrary d ∈ {1, ..., 12}.
    /// Unpacks 32·d bytes into 256 coefficients with d bits each.
    /// </remarks>
    /// <param name="input">The input buffer (32·d bytes).</param>
    /// <param name="d">The bit width per coefficient.</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ByteDecodeD(ReadOnlySpan<byte> input, int d, Span<short> coeffs)
    {
        switch (d)
        {
            case 1: ByteDecode1(input, coeffs); return;
            case 4: ByteDecode4(input, coeffs); return;
            case 5: ByteDecode5(input, coeffs); return;
            case 10: ByteDecode10(input, coeffs); return;
            case 11: ByteDecode11(input, coeffs); return;
            case 12: ByteDecode12(input, coeffs); return;
            default: ByteDecodeGeneric(input, d, coeffs); return;
        }
    }

    /// <summary>
    /// Bit-at-a-time fallback for widths without a specialized unpacker.
    /// </summary>
    /// <param name="input">The input buffer (32·d bytes).</param>
    /// <param name="d">The bit width per coefficient.</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecodeGeneric(ReadOnlySpan<byte> input, int d, Span<short> coeffs)
    {
        int mask = (1 << d) - 1;
        int bitPos = 0;
        for (int i = 0; i < MLKemParams.N; i++)
        {
            uint val = 0;
            for (int b = 0; b < d; b++)
            {
                int byteIdx = bitPos >> 3;
                int bitIdx = bitPos & 7;
                val |= (uint)(((input[byteIdx] >> bitIdx) & 1) << b);
                bitPos++;
            }

            coeffs[i] = (short)(val & mask);
        }
    }

    // ========================================================================
    // Specialized packers
    //
    // FIPS 203 lays coefficients into a little-endian bit stream: coefficient i occupies
    // bits i·d … i·d+d-1, and bit p sits at byte p>>3, bit p&7. Rather than walking that
    // stream one bit at a time, each routine below handles the smallest group of
    // coefficients that lands on a byte boundary — d·n divisible by 8 — using fixed shifts:
    //
    //     d=4  → 2 coefficients per 1 byte      d=10 → 4 coefficients per 5 bytes
    //     d=5  → 8 coefficients per 5 bytes     d=11 → 8 coefficients per 11 bytes
    //
    // Every output byte is written exactly once, so unlike the generic path these need no
    // pre-zeroed destination. All shifts are by constants, and no branch or index depends on
    // a coefficient value, which keeps them constant-time over the secret-derived data that
    // decapsulation re-encrypts.
    // ========================================================================

    /// <summary>Packs 256 coefficients of 4 bits into 128 bytes.</summary>
    /// <param name="coeffs">The 256 polynomial coefficients, each in [0, 2^4).</param>
    /// <param name="output">The output buffer (128 bytes).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncode4(ReadOnlySpan<short> coeffs, Span<byte> output)
    {
        output = output.Slice(0, 32 * 4);
        for (int i = 0, o = 0; i < MLKemParams.N; i += 2, o++)
        {
            uint c0 = (ushort)coeffs[i];
            uint c1 = (ushort)coeffs[i + 1];
            output[o] = (byte)(c0 | (c1 << 4));
        }
    }

    /// <summary>Unpacks 128 bytes into 256 coefficients of 4 bits.</summary>
    /// <param name="input">The input buffer (128 bytes).</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecode4(ReadOnlySpan<byte> input, Span<short> coeffs)
    {
        input = input.Slice(0, 32 * 4);
        for (int i = 0, o = 0; i < MLKemParams.N; i += 2, o++)
        {
            uint b0 = input[o];
            coeffs[i] = (short)(b0 & 0x0F);
            coeffs[i + 1] = (short)(b0 >> 4);
        }
    }

    /// <summary>Packs 256 coefficients of 5 bits into 160 bytes.</summary>
    /// <param name="coeffs">The 256 polynomial coefficients, each in [0, 2^5).</param>
    /// <param name="output">The output buffer (160 bytes).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncode5(ReadOnlySpan<short> coeffs, Span<byte> output)
    {
        output = output.Slice(0, 32 * 5);
        for (int i = 0, o = 0; i < MLKemParams.N; i += 8, o += 5)
        {
            uint c0 = (ushort)coeffs[i];
            uint c1 = (ushort)coeffs[i + 1];
            uint c2 = (ushort)coeffs[i + 2];
            uint c3 = (ushort)coeffs[i + 3];
            uint c4 = (ushort)coeffs[i + 4];
            uint c5 = (ushort)coeffs[i + 5];
            uint c6 = (ushort)coeffs[i + 6];
            uint c7 = (ushort)coeffs[i + 7];

            output[o] = (byte)(c0 | (c1 << 5));
            output[o + 1] = (byte)((c1 >> 3) | (c2 << 2) | (c3 << 7));
            output[o + 2] = (byte)((c3 >> 1) | (c4 << 4));
            output[o + 3] = (byte)((c4 >> 4) | (c5 << 1) | (c6 << 6));
            output[o + 4] = (byte)((c6 >> 2) | (c7 << 3));
        }
    }

    /// <summary>Unpacks 160 bytes into 256 coefficients of 5 bits.</summary>
    /// <param name="input">The input buffer (160 bytes).</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecode5(ReadOnlySpan<byte> input, Span<short> coeffs)
    {
        input = input.Slice(0, 32 * 5);
        for (int i = 0, o = 0; i < MLKemParams.N; i += 8, o += 5)
        {
            uint b0 = input[o];
            uint b1 = input[o + 1];
            uint b2 = input[o + 2];
            uint b3 = input[o + 3];
            uint b4 = input[o + 4];

            coeffs[i] = (short)(b0 & 0x1F);
            coeffs[i + 1] = (short)(((b0 >> 5) | (b1 << 3)) & 0x1F);
            coeffs[i + 2] = (short)((b1 >> 2) & 0x1F);
            coeffs[i + 3] = (short)(((b1 >> 7) | (b2 << 1)) & 0x1F);
            coeffs[i + 4] = (short)(((b2 >> 4) | (b3 << 4)) & 0x1F);
            coeffs[i + 5] = (short)((b3 >> 1) & 0x1F);
            coeffs[i + 6] = (short)(((b3 >> 6) | (b4 << 2)) & 0x1F);
            coeffs[i + 7] = (short)((b4 >> 3) & 0x1F);
        }
    }

    /// <summary>Packs 256 coefficients of 10 bits into 320 bytes.</summary>
    /// <param name="coeffs">The 256 polynomial coefficients, each in [0, 2^10).</param>
    /// <param name="output">The output buffer (320 bytes).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncode10(ReadOnlySpan<short> coeffs, Span<byte> output)
    {
        output = output.Slice(0, 32 * 10);

        // The slice above is the length check; both subscripts below then run off
        // references so the packing loop does not repeat it per element.
        Debug.Assert(coeffs.Length >= MLKemParams.N, "polynomial must have N coefficients");
        ref short rc = ref MemoryMarshal.GetReference(coeffs);
        ref byte ro = ref MemoryMarshal.GetReference(output);

        for (int i = 0, o = 0; i < MLKemParams.N; i += 4, o += 5)
        {
            uint c0 = (ushort)Unsafe.Add(ref rc, i);
            uint c1 = (ushort)Unsafe.Add(ref rc, i + 1);
            uint c2 = (ushort)Unsafe.Add(ref rc, i + 2);
            uint c3 = (ushort)Unsafe.Add(ref rc, i + 3);

            Unsafe.Add(ref ro, o) = (byte)c0;
            Unsafe.Add(ref ro, o + 1) = (byte)((c0 >> 8) | (c1 << 2));
            Unsafe.Add(ref ro, o + 2) = (byte)((c1 >> 6) | (c2 << 4));
            Unsafe.Add(ref ro, o + 3) = (byte)((c2 >> 4) | (c3 << 6));
            Unsafe.Add(ref ro, o + 4) = (byte)(c3 >> 2);
        }
    }

    /// <summary>Unpacks 320 bytes into 256 coefficients of 10 bits.</summary>
    /// <param name="input">The input buffer (320 bytes).</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecode10(ReadOnlySpan<byte> input, Span<short> coeffs)
    {
        input = input.Slice(0, 32 * 10);

        // The slice above is the length check; both subscripts below then run off
        // references so the packing loop does not repeat it per element.
        Debug.Assert(coeffs.Length >= MLKemParams.N, "polynomial must have N coefficients");
        ref byte ri = ref MemoryMarshal.GetReference(input);
        ref short rc = ref MemoryMarshal.GetReference(coeffs);

        for (int i = 0, o = 0; i < MLKemParams.N; i += 4, o += 5)
        {
            uint b0 = Unsafe.Add(ref ri, o);
            uint b1 = Unsafe.Add(ref ri, o + 1);
            uint b2 = Unsafe.Add(ref ri, o + 2);
            uint b3 = Unsafe.Add(ref ri, o + 3);
            uint b4 = Unsafe.Add(ref ri, o + 4);

            Unsafe.Add(ref rc, i) = (short)((b0 | (b1 << 8)) & 0x3FF);
            Unsafe.Add(ref rc, i + 1) = (short)(((b1 >> 2) | (b2 << 6)) & 0x3FF);
            Unsafe.Add(ref rc, i + 2) = (short)(((b2 >> 4) | (b3 << 4)) & 0x3FF);
            Unsafe.Add(ref rc, i + 3) = (short)(((b3 >> 6) | (b4 << 2)) & 0x3FF);
        }
    }

    /// <summary>Packs 256 coefficients of 11 bits into 352 bytes.</summary>
    /// <param name="coeffs">The 256 polynomial coefficients, each in [0, 2^11).</param>
    /// <param name="output">The output buffer (352 bytes).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteEncode11(ReadOnlySpan<short> coeffs, Span<byte> output)
    {
        output = output.Slice(0, 32 * 11);

        // The slice above is the length check; both subscripts below then run off
        // references so the packing loop does not repeat it per element.
        Debug.Assert(coeffs.Length >= MLKemParams.N, "polynomial must have N coefficients");
        ref short rc = ref MemoryMarshal.GetReference(coeffs);
        ref byte ro = ref MemoryMarshal.GetReference(output);

        for (int i = 0, o = 0; i < MLKemParams.N; i += 8, o += 11)
        {
            uint c0 = (ushort)Unsafe.Add(ref rc, i);
            uint c1 = (ushort)Unsafe.Add(ref rc, i + 1);
            uint c2 = (ushort)Unsafe.Add(ref rc, i + 2);
            uint c3 = (ushort)Unsafe.Add(ref rc, i + 3);
            uint c4 = (ushort)Unsafe.Add(ref rc, i + 4);
            uint c5 = (ushort)Unsafe.Add(ref rc, i + 5);
            uint c6 = (ushort)Unsafe.Add(ref rc, i + 6);
            uint c7 = (ushort)Unsafe.Add(ref rc, i + 7);

            Unsafe.Add(ref ro, o) = (byte)c0;
            Unsafe.Add(ref ro, o + 1) = (byte)((c0 >> 8) | (c1 << 3));
            Unsafe.Add(ref ro, o + 2) = (byte)((c1 >> 5) | (c2 << 6));
            Unsafe.Add(ref ro, o + 3) = (byte)(c2 >> 2);
            Unsafe.Add(ref ro, o + 4) = (byte)((c2 >> 10) | (c3 << 1));
            Unsafe.Add(ref ro, o + 5) = (byte)((c3 >> 7) | (c4 << 4));
            Unsafe.Add(ref ro, o + 6) = (byte)((c4 >> 4) | (c5 << 7));
            Unsafe.Add(ref ro, o + 7) = (byte)(c5 >> 1);
            Unsafe.Add(ref ro, o + 8) = (byte)((c5 >> 9) | (c6 << 2));
            Unsafe.Add(ref ro, o + 9) = (byte)((c6 >> 6) | (c7 << 5));
            Unsafe.Add(ref ro, o + 10) = (byte)(c7 >> 3);
        }
    }

    /// <summary>Unpacks 352 bytes into 256 coefficients of 11 bits.</summary>
    /// <param name="input">The input buffer (352 bytes).</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void ByteDecode11(ReadOnlySpan<byte> input, Span<short> coeffs)
    {
        input = input.Slice(0, 32 * 11);

        // The slice above is the length check; both subscripts below then run off
        // references so the packing loop does not repeat it per element.
        Debug.Assert(coeffs.Length >= MLKemParams.N, "polynomial must have N coefficients");
        ref byte ri = ref MemoryMarshal.GetReference(input);
        ref short rc = ref MemoryMarshal.GetReference(coeffs);

        for (int i = 0, o = 0; i < MLKemParams.N; i += 8, o += 11)
        {
            uint b0 = Unsafe.Add(ref ri, o);
            uint b1 = Unsafe.Add(ref ri, o + 1);
            uint b2 = Unsafe.Add(ref ri, o + 2);
            uint b3 = Unsafe.Add(ref ri, o + 3);
            uint b4 = Unsafe.Add(ref ri, o + 4);
            uint b5 = Unsafe.Add(ref ri, o + 5);
            uint b6 = Unsafe.Add(ref ri, o + 6);
            uint b7 = Unsafe.Add(ref ri, o + 7);
            uint b8 = Unsafe.Add(ref ri, o + 8);
            uint b9 = Unsafe.Add(ref ri, o + 9);
            uint b10 = Unsafe.Add(ref ri, o + 10);

            Unsafe.Add(ref rc, i) = (short)((b0 | (b1 << 8)) & 0x7FF);
            Unsafe.Add(ref rc, i + 1) = (short)(((b1 >> 3) | (b2 << 5)) & 0x7FF);
            Unsafe.Add(ref rc, i + 2) = (short)(((b2 >> 6) | (b3 << 2) | (b4 << 10)) & 0x7FF);
            Unsafe.Add(ref rc, i + 3) = (short)(((b4 >> 1) | (b5 << 7)) & 0x7FF);
            Unsafe.Add(ref rc, i + 4) = (short)(((b5 >> 4) | (b6 << 4)) & 0x7FF);
            Unsafe.Add(ref rc, i + 5) = (short)(((b6 >> 7) | (b7 << 1) | (b8 << 9)) & 0x7FF);
            Unsafe.Add(ref rc, i + 6) = (short)(((b8 >> 2) | (b9 << 6)) & 0x7FF);
            Unsafe.Add(ref rc, i + 7) = (short)(((b9 >> 5) | (b10 << 3)) & 0x7FF);
        }
    }
}
