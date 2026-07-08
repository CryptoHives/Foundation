// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System.Runtime.CompilerServices;

/// <summary>
/// Number Theoretic Transform (NTT) operations over ℤ_3329 for ML-KEM.
/// </summary>
/// <remarks>
/// Implements the forward and inverse NTT as specified in FIPS 203 §4.3,
/// using Montgomery multiplication for efficient modular arithmetic.
/// </remarks>
internal static class Ntt
{
    /// <summary>q = 3329.</summary>
    private const int Q = MlKemParams.Q;

    /// <summary>
    /// Montgomery parameter: R² mod q, where R = 2^16. Used for converting to Montgomery form.
    /// </summary>
    private const short MontR = 1353;

    /// <summary>
    /// q^(-1) mod 2^16. Used in Montgomery reduction.
    /// </summary>
    private const int QInv = 62209;

    /// <summary>
    /// Precomputed zeta values in Montgomery form (ζ^BitRev(i) · R mod q).
    /// FIPS 203 §4.3: ζ = 17 is a primitive 256th root of unity modulo 3329.
    /// </summary>
    private static readonly short[] Zetas =
    [
        -1044,  -758,  -359, -1517,  1493,  1422,   287,   202,
         -171,   622,  1577,   182,   962, -1202, -1474,  1468,
          573, -1325,   264,   383,  -829,  1458, -1602,  -130,
         -681,  1017,   732,   608, -1542,   411,  -205, -1571,
         1223,   652,  -552,  1015, -1293,  1491,  -282, -1544,
          516,    -8,  -320,  -666, -1618, -1162,   126,  1469,
         -853,   -90,  -271,   830,   107, -1421,  -247,  -951,
         -398,   961, -1508,  -725,   448, -1065,   677, -1275,
        -1103,   430,   555,   843, -1251,   871,  1550,   105,
          422,   587,   177,  -235,  -291,  -460,  1574,  1653,
         -246,   778,  1159,  -147,  -777,  1483,  -602,  1119,
        -1590,   644,  -872,   349,   418,   329,  -156,   -75,
          817,  1097,   603,   610,  1322, -1285, -1465,   384,
        -1215,  -136,  1218, -1335,  -874,   220, -1187, -1659,
        -1185, -1530, -1278,   794, -1510,  -854,  -870,   478,
         -108,  -308,   996,   991,   958, -1460,  1522,  1628
    ];

    /// <summary>
    /// Performs the forward NTT (Number Theoretic Transform) in-place.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 9 (NTT). Converts a polynomial from normal domain
    /// to NTT domain for efficient polynomial multiplication.
    /// </remarks>
    /// <param name="r">The 256 coefficients of the polynomial, modified in-place.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Forward(short[] r)
    {
        int k = 1;
        for (int len = 128; len >= 2; len >>= 1)
        {
            for (int start = 0; start < 256; start += 2 * len)
            {
                short zeta = Zetas[k++];
                for (int j = start; j < start + len; j++)
                {
                    short t = MontgomeryReduce(zeta * r[j + len]);
                    r[j + len] = (short)(r[j] - t);
                    r[j] = (short)(r[j] + t);
                }
            }
        }
    }

    /// <summary>
    /// Performs the inverse NTT in-place.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 10 (NTT⁻¹). Converts a polynomial from NTT domain
    /// back to normal domain.
    /// </remarks>
    /// <param name="r">The 256 coefficients of the polynomial, modified in-place.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Inverse(short[] r)
    {
        int k = 127;
        for (int len = 2; len <= 128; len <<= 1)
        {
            for (int start = 0; start < 256; start += 2 * len)
            {
                short zeta = Zetas[k--];
                for (int j = start; j < start + len; j++)
                {
                    short t = r[j];
                    r[j] = BarrettReduce((short)(t + r[j + len]));
                    r[j + len] = MontgomeryReduce(zeta * (r[j + len] - t));
                }
            }
        }

        // Multiply by n^{-1} = 3303 in Montgomery form (3303 · R mod q)
        const short f = 1441;
        for (int j = 0; j < 256; j++)
        {
            r[j] = MontgomeryReduce(f * r[j]);
        }
    }

    /// <summary>
    /// Multiplies two degree-1 polynomials in ℤ_q[X]/(X² - ζ) and accumulates.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 11 (BaseCaseMultiply). Used for pointwise multiplication
    /// of polynomials in NTT domain.
    /// </remarks>
    /// <param name="r">The output coefficients (2 values), accumulated.</param>
    /// <param name="rOff">Offset into <paramref name="r"/>.</param>
    /// <param name="a">First operand coefficients.</param>
    /// <param name="aOff">Offset into <paramref name="a"/>.</param>
    /// <param name="b">Second operand coefficients.</param>
    /// <param name="bOff">Offset into <paramref name="b"/>.</param>
    /// <param name="zeta">The twist factor ζ for this base case.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void BaseCaseMultiply(short[] r, int rOff, short[] a, int aOff, short[] b, int bOff, short zeta)
    {
        int a0 = a[aOff];
        int a1 = a[aOff + 1];
        int b0 = b[bOff];
        int b1 = b[bOff + 1];

        short t = MontgomeryReduce(a1 * b1);
        t = MontgomeryReduce(t * zeta);
        t += MontgomeryReduce(a0 * b0);
        r[rOff] = (short)(r[rOff] + t);

        r[rOff + 1] = (short)(r[rOff + 1] + MontgomeryReduce(a0 * b1) + MontgomeryReduce(a1 * b0));
    }

    /// <summary>
    /// Barrett reduction: reduces a mod q using Barrett's method.
    /// </summary>
    /// <param name="a">The value to reduce (must be in range [-q, q]).</param>
    /// <returns>The reduced value in [0, q).</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static short BarrettReduce(short a)
    {
        // Barrett constant: ⌊2^26 / q + 0.5⌋ = 20159
        const int v = 20159;
        int t = (v * a + (1 << 25)) >> 26;
        t = a - t * Q;
        return (short)t;
    }

    /// <summary>
    /// Montgomery reduction: given a 32-bit integer, compute a · R^{-1} mod q.
    /// </summary>
    /// <param name="a">The value to reduce.</param>
    /// <returns>The Montgomery-reduced value.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static short MontgomeryReduce(int a)
    {
        short t = (short)(a * QInv);
        return (short)((a - t * Q) >> 16);
    }

    /// <summary>
    /// Conditionally subtracts q to ensure the value is in [0, q).
    /// </summary>
    /// <param name="a">The value to normalize.</param>
    /// <returns>The value in canonical form [0, q).</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static short ConditionalSubQ(short a)
    {
        a += (short)((a >> 15) & Q);
        a -= Q;
        a += (short)((a >> 15) & Q);
        return a;
    }

    /// <summary>
    /// Gets the precomputed zeta value at the given index.
    /// </summary>
    /// <param name="index">The index into the zeta table.</param>
    /// <returns>The zeta value in Montgomery form.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static short GetZeta(int index) => Zetas[index];

    /// <summary>
    /// Converts a value to Montgomery form: a · R mod q.
    /// </summary>
    /// <param name="a">The value to convert.</param>
    /// <returns>The value in Montgomery form.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static short ToMontgomery(short a)
    {
        return MontgomeryReduce(a * (int)MontR);
    }
}
