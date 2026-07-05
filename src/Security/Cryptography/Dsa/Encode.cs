// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Dsa;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Bit packing and key/signature encodings for ML-DSA (FIPS 204 §7.1/§7.2, Algorithms 16–27).
/// </summary>
/// <remarks>
/// All packing follows the FIPS 204 little-endian bit order (IntegerToBits + BitsToBytes):
/// coefficient bits are appended least-significant-first into a little-endian byte stream.
/// </remarks>
internal static class Encode
{
    // ========================================================================
    // Generic bit packing (Algorithms 16–19)
    // ========================================================================

    /// <summary>
    /// SimpleBitPack (Algorithm 16): packs non-negative coefficients using <paramref name="bits"/> bits each.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void SimpleBitPack(int[] coeffs, int bits, Span<byte> output)
    {
        ulong acc = 0;
        int accBits = 0;
        int pos = 0;
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            acc |= (ulong)(uint)coeffs[i] << accBits;
            accBits += bits;
            while (accBits >= 8)
            {
                output[pos++] = (byte)acc;
                acc >>= 8;
                accBits -= 8;
            }
        }
    }

    /// <summary>
    /// SimpleBitUnpack (Algorithm 18): unpacks non-negative coefficients of <paramref name="bits"/> bits each.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void SimpleBitUnpack(ReadOnlySpan<byte> input, int bits, int[] coeffs)
    {
        ulong acc = 0;
        int accBits = 0;
        int pos = 0;
        uint mask = (1u << bits) - 1;
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            while (accBits < bits)
            {
                acc |= (ulong)input[pos++] << accBits;
                accBits += 8;
            }

            coeffs[i] = (int)((uint)acc & mask);
            acc >>= bits;
            accBits -= bits;
        }
    }

    /// <summary>
    /// BitPack (Algorithm 17): packs each coefficient w as the value b − w using <paramref name="bits"/> bits.
    /// </summary>
    /// <param name="coeffs">Coefficients in [b − 2^bits + 1, b].</param>
    /// <param name="b">The upper bound b of the coefficient range.</param>
    /// <param name="bits">Bits per packed value (bitlen(a + b)).</param>
    /// <param name="output">The output buffer (32 · bits bytes).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void BitPack(int[] coeffs, int b, int bits, Span<byte> output)
    {
        ulong acc = 0;
        int accBits = 0;
        int pos = 0;
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            acc |= (ulong)(uint)(b - coeffs[i]) << accBits;
            accBits += bits;
            while (accBits >= 8)
            {
                output[pos++] = (byte)acc;
                acc >>= 8;
                accBits -= 8;
            }
        }
    }

    /// <summary>
    /// BitUnpack (Algorithm 19): unpacks values of <paramref name="bits"/> bits each and maps them to b − value.
    /// </summary>
    /// <param name="input">The packed input (32 · bits bytes).</param>
    /// <param name="bits">Bits per packed value.</param>
    /// <param name="b">The upper bound b of the coefficient range.</param>
    /// <param name="coeffs">The 256-element output polynomial.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void BitUnpackSigned(ReadOnlySpan<byte> input, int bits, int b, int[] coeffs)
    {
        ulong acc = 0;
        int accBits = 0;
        int pos = 0;
        uint mask = (1u << bits) - 1;
        for (int i = 0; i < MlDsaParams.N; i++)
        {
            while (accBits < bits)
            {
                acc |= (ulong)input[pos++] << accBits;
                accBits += 8;
            }

            coeffs[i] = b - (int)((uint)acc & mask);
            acc >>= bits;
            accBits -= bits;
        }
    }

    // ========================================================================
    // Hint packing (Algorithms 20/21)
    // ========================================================================

    /// <summary>
    /// HintBitPack (Algorithm 20): packs the hint vector into ω + k bytes.
    /// </summary>
    public static void HintBitPack(MlDsaParams p, int[][] hint, Span<byte> output)
    {
        output.Slice(0, p.Omega + p.K).Clear();
        int index = 0;
        for (int i = 0; i < p.K; i++)
        {
            for (int j = 0; j < MlDsaParams.N; j++)
            {
                if (hint[i][j] != 0)
                {
                    output[index++] = (byte)j;
                }
            }

            output[p.Omega + i] = (byte)index;
        }
    }

    /// <summary>
    /// HintBitUnpack (Algorithm 21): unpacks and strictly validates the hint encoding.
    /// </summary>
    /// <returns>False when the encoding is malformed (positions not strictly increasing,
    /// counts inconsistent, or padding bytes non-zero) — the signature must then be rejected.</returns>
    public static bool HintBitUnpack(MlDsaParams p, ReadOnlySpan<byte> input, int[][] hint)
    {
        int index = 0;
        for (int i = 0; i < p.K; i++)
        {
            Array.Clear(hint[i], 0, MlDsaParams.N);
            int end = input[p.Omega + i];
            if (end < index || end > p.Omega)
            {
                return false;
            }

            int first = index;
            while (index < end)
            {
                if (index > first && input[index - 1] >= input[index])
                {
                    return false;
                }

                hint[i][input[index]] = 1;
                index++;
            }
        }

        for (int i = index; i < p.Omega; i++)
        {
            if (input[i] != 0)
            {
                return false;
            }
        }

        return true;
    }

    // ========================================================================
    // Key and signature encodings (Algorithms 22–28)
    // ========================================================================

    /// <summary>
    /// pkEncode (Algorithm 22): pk = ρ ‖ SimpleBitPack₁₀(t1).
    /// </summary>
    public static void PkEncode(MlDsaParams p, ReadOnlySpan<byte> rho, int[][] t1, Span<byte> pk)
    {
        rho.Slice(0, 32).CopyTo(pk);
        for (int i = 0; i < p.K; i++)
        {
            SimpleBitPack(t1[i], 10, pk.Slice(32 + i * 320, 320));
        }
    }

    /// <summary>
    /// pkDecode (Algorithm 23).
    /// </summary>
    public static void PkDecode(MlDsaParams p, ReadOnlySpan<byte> pk, Span<byte> rho, int[][] t1)
    {
        pk.Slice(0, 32).CopyTo(rho);
        for (int i = 0; i < p.K; i++)
        {
            SimpleBitUnpack(pk.Slice(32 + i * 320, 320), 10, t1[i]);
        }
    }

    /// <summary>
    /// skEncode (Algorithm 24): sk = ρ ‖ K ‖ tr ‖ BitPack(s1) ‖ BitPack(s2) ‖ BitPack(t0).
    /// </summary>
    public static void SkEncode(MlDsaParams p, ReadOnlySpan<byte> rho, ReadOnlySpan<byte> key,
                                ReadOnlySpan<byte> tr, int[][] s1, int[][] s2, int[][] t0, Span<byte> sk)
    {
        rho.Slice(0, 32).CopyTo(sk);
        key.Slice(0, 32).CopyTo(sk.Slice(32));
        tr.Slice(0, 64).CopyTo(sk.Slice(64));

        int etaPolyBytes = 32 * p.EtaBits;
        int offset = 128;
        for (int i = 0; i < p.L; i++, offset += etaPolyBytes)
        {
            BitPack(s1[i], p.Eta, p.EtaBits, sk.Slice(offset, etaPolyBytes));
        }

        for (int i = 0; i < p.K; i++, offset += etaPolyBytes)
        {
            BitPack(s2[i], p.Eta, p.EtaBits, sk.Slice(offset, etaPolyBytes));
        }

        const int t0PolyBytes = 32 * MlDsaParams.D;
        for (int i = 0; i < p.K; i++, offset += t0PolyBytes)
        {
            BitPack(t0[i], 1 << (MlDsaParams.D - 1), MlDsaParams.D, sk.Slice(offset, t0PolyBytes));
        }
    }

    /// <summary>
    /// skDecode (Algorithm 25).
    /// </summary>
    public static void SkDecode(MlDsaParams p, ReadOnlySpan<byte> sk, Span<byte> rho, Span<byte> key,
                                Span<byte> tr, int[][] s1, int[][] s2, int[][] t0)
    {
        sk.Slice(0, 32).CopyTo(rho);
        sk.Slice(32, 32).CopyTo(key);
        sk.Slice(64, 64).CopyTo(tr);

        int etaPolyBytes = 32 * p.EtaBits;
        int offset = 128;
        for (int i = 0; i < p.L; i++, offset += etaPolyBytes)
        {
            BitUnpackSigned(sk.Slice(offset, etaPolyBytes), p.EtaBits, p.Eta, s1[i]);
        }

        for (int i = 0; i < p.K; i++, offset += etaPolyBytes)
        {
            BitUnpackSigned(sk.Slice(offset, etaPolyBytes), p.EtaBits, p.Eta, s2[i]);
        }

        const int t0PolyBytes = 32 * MlDsaParams.D;
        for (int i = 0; i < p.K; i++, offset += t0PolyBytes)
        {
            BitUnpackSigned(sk.Slice(offset, t0PolyBytes), MlDsaParams.D, 1 << (MlDsaParams.D - 1), t0[i]);
        }
    }

    /// <summary>
    /// sigEncode (Algorithm 26): σ = c̃ ‖ BitPack(z) ‖ HintBitPack(h).
    /// </summary>
    public static void SigEncode(MlDsaParams p, ReadOnlySpan<byte> cTilde, int[][] z, int[][] hint, Span<byte> sig)
    {
        cTilde.Slice(0, p.CTildeBytes).CopyTo(sig);

        int zPolyBytes = 32 * p.ZBits;
        int offset = p.CTildeBytes;
        for (int i = 0; i < p.L; i++, offset += zPolyBytes)
        {
            BitPack(z[i], p.Gamma1, p.ZBits, sig.Slice(offset, zPolyBytes));
        }

        HintBitPack(p, hint, sig.Slice(offset, p.Omega + p.K));
    }

    /// <summary>
    /// sigDecode (Algorithm 27).
    /// </summary>
    /// <returns>False when the hint encoding is malformed; the signature must then be rejected.</returns>
    public static bool SigDecode(MlDsaParams p, ReadOnlySpan<byte> sig, Span<byte> cTilde, int[][] z, int[][] hint)
    {
        sig.Slice(0, p.CTildeBytes).CopyTo(cTilde);

        int zPolyBytes = 32 * p.ZBits;
        int offset = p.CTildeBytes;
        for (int i = 0; i < p.L; i++, offset += zPolyBytes)
        {
            BitUnpackSigned(sig.Slice(offset, zPolyBytes), p.ZBits, p.Gamma1, z[i]);
        }

        return HintBitUnpack(p, sig.Slice(offset, p.Omega + p.K), hint);
    }

    /// <summary>
    /// w1Encode (Algorithm 28): packs the commitment high bits (6 bits for γ₂ = (q−1)/88, 4 bits otherwise).
    /// </summary>
    public static void W1Encode(MlDsaParams p, int[][] w1, Span<byte> output)
    {
        int polyBytes = 32 * p.W1Bits;
        for (int i = 0; i < p.K; i++)
        {
            SimpleBitPack(w1[i], p.W1Bits, output.Slice(i * polyBytes, polyBytes));
        }
    }
}
