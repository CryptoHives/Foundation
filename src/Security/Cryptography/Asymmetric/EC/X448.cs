// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// Implements the X448 Diffie-Hellman function per RFC 7748.
/// </summary>
/// <remarks>
/// <para>
/// X448 is an elliptic curve Diffie-Hellman (ECDH) function based on Curve448-Goldilocks
/// (a Montgomery curve over GF(2⁴⁴⁸ − 2²²⁴ − 1)). It computes a shared secret from
/// a private scalar and a peer's public u-coordinate.
/// </para>
/// <para>
/// All operations use the Montgomery ladder for constant-time scalar multiplication
/// with only the x-coordinate, following RFC 7748 section 5.
/// </para>
/// </remarks>
internal static class X448
{
    /// <summary>
    /// The size in bytes of a scalar, public key, or shared secret.
    /// </summary>
    public const int KeySize = 56;

    private const int N = 7;
    private const ulong A24 = 39081; // (A-2)/4 for A = 156326

    /// <summary>
    /// Computes the X448 function: result = clamp(k) · u on Curve448.
    /// </summary>
    /// <param name="k">The 56-byte secret scalar (little-endian).</param>
    /// <param name="u">The 56-byte u-coordinate of the peer's public key (little-endian).</param>
    /// <param name="result">The 56-byte shared secret (little-endian).</param>
    public static void ScalarMult(ReadOnlySpan<byte> k, ReadOnlySpan<byte> u, Span<byte> result)
    {
        // Clamp scalar per RFC 7748 §5
        Span<byte> scalar = stackalloc byte[KeySize];
        k[..KeySize].CopyTo(scalar);
        scalar[0] &= 252;
        scalar[55] |= 128;

        // Decode u-coordinate (no masking needed — 448 bits fills 56 bytes exactly)
        Span<ulong> uLimbs = stackalloc ulong[N];
        X25519.FromLittleEndianBytes(u[..KeySize], uLimbs);

        // Field setup: p = 2⁴⁴⁸ − 2²²⁴ − 1
        Span<ulong> pLimbs = stackalloc ulong[N];
        pLimbs[0] = 0xFFFFFFFFFFFFFFFFUL;
        pLimbs[1] = 0xFFFFFFFFFFFFFFFFUL;
        pLimbs[2] = 0xFFFFFFFFFFFFFFFFUL;
        pLimbs[3] = 0xFFFFFFFEFFFFFFFFUL;
        pLimbs[4] = 0xFFFFFFFFFFFFFFFFUL;
        pLimbs[5] = 0xFFFFFFFFFFFFFFFFUL;
        pLimbs[6] = 0xFFFFFFFFFFFFFFFFUL;

        var field = new MontgomeryContext(pLimbs);

        // Reduce u mod p
        Span<ulong> uReduced = stackalloc ulong[N];
        uLimbs.CopyTo(uReduced);
        if (BigUInt.Compare(uReduced, pLimbs) >= 0)
            BigUInt.Sub(uReduced, pLimbs, uReduced);

        // Convert to Montgomery form
        Span<ulong> uMont = stackalloc ulong[N];
        field.ToMontgomery(uReduced, uMont);

        Span<ulong> oneMont = stackalloc ulong[N];
        Span<ulong> oneNorm = stackalloc ulong[N];
        oneNorm.Clear();
        oneNorm[0] = 1;
        field.ToMontgomery(oneNorm, oneMont);

        // a24 = 39081 in Montgomery form
        Span<ulong> a24Norm = stackalloc ulong[N];
        a24Norm.Clear();
        a24Norm[0] = A24;
        Span<ulong> a24Mont = stackalloc ulong[N];
        field.ToMontgomery(a24Norm, a24Mont);

        // Montgomery ladder state: x2:z2 = 1:0, x3:z3 = u:1
        Span<ulong> x2 = stackalloc ulong[N];
        Span<ulong> z2 = stackalloc ulong[N];
        Span<ulong> x3 = stackalloc ulong[N];
        Span<ulong> z3 = stackalloc ulong[N];

        oneMont.CopyTo(x2);
        z2.Clear();
        uMont.CopyTo(x3);
        oneMont.CopyTo(z3);

        // Temporaries for the ladder step
        Span<ulong> a = stackalloc ulong[N];
        Span<ulong> aa = stackalloc ulong[N];
        Span<ulong> b = stackalloc ulong[N];
        Span<ulong> bb = stackalloc ulong[N];
        Span<ulong> e = stackalloc ulong[N];
        Span<ulong> c = stackalloc ulong[N];
        Span<ulong> d = stackalloc ulong[N];
        Span<ulong> da = stackalloc ulong[N];
        Span<ulong> cb = stackalloc ulong[N];
        Span<ulong> t0 = stackalloc ulong[N];

        ulong swap = 0;

        // Process bits 447 down to 0
        for (int pos = 447; pos >= 0; pos--)
        {
            int byteIdx = pos / 8;
            int bitIdx = pos % 8;
            ulong kBit = (ulong)((scalar[byteIdx] >> bitIdx) & 1);

            swap ^= kBit;
            BigUInt.ConditionalSwap(swap, x2, x3);
            BigUInt.ConditionalSwap(swap, z2, z3);
            swap = kBit;

            // RFC 7748 ladder step
            field.ModAdd(x2, z2, a);      // A = x2 + z2
            field.MontSquare(a, aa);       // AA = A²
            field.ModSub(x2, z2, b);      // B = x2 - z2
            field.MontSquare(b, bb);       // BB = B²
            field.ModSub(aa, bb, e);       // E = AA - BB
            field.ModAdd(x3, z3, c);      // C = x3 + z3
            field.ModSub(x3, z3, d);      // D = x3 - z3
            field.MontMul(d, a, da);       // DA = D · A
            field.MontMul(c, b, cb);       // CB = C · B

            field.ModAdd(da, cb, t0);      // DA + CB
            field.MontSquare(t0, x3);      // x3 = (DA + CB)²

            field.ModSub(da, cb, t0);      // DA - CB
            field.MontSquare(t0, z3);      // (DA - CB)²
            field.MontMul(z3, uMont, z3);  // z3 = u · (DA - CB)²

            field.MontMul(aa, bb, x2);     // x2 = AA · BB

            field.MontMul(a24Mont, e, t0); // a24 · E
            field.ModAdd(aa, t0, t0);      // AA + a24 · E
            field.MontMul(t0, e, z2);      // z2 = E · (AA + a24 · E)
        }

        BigUInt.ConditionalSwap(swap, x2, x3);
        BigUInt.ConditionalSwap(swap, z2, z3);

        // Result = x2 · z2⁻¹ mod p
        Span<ulong> z2Norm = stackalloc ulong[N];
        field.FromMontgomery(z2, z2Norm);

        Span<ulong> pMinus2 = stackalloc ulong[N];
        BigUInt.SubWord(pLimbs, 2, pMinus2);

        Span<ulong> z2Inv = stackalloc ulong[N];
        field.ModExp(z2Norm, pMinus2, z2Inv);

        Span<ulong> z2InvMont = stackalloc ulong[N];
        field.ToMontgomery(z2Inv, z2InvMont);

        Span<ulong> resMont = stackalloc ulong[N];
        field.MontMul(x2, z2InvMont, resMont);

        Span<ulong> resNorm = stackalloc ulong[N];
        field.FromMontgomery(resMont, resNorm);

        X25519.ToLittleEndianBytes(resNorm, result[..KeySize]);
    }

    /// <summary>
    /// Computes the public key from a private scalar: result = clamp(k) · 5.
    /// </summary>
    /// <param name="privateKey">The 56-byte private key (little-endian).</param>
    /// <param name="publicKey">The 56-byte public key (little-endian).</param>
    public static void ScalarMultBase(ReadOnlySpan<byte> privateKey, Span<byte> publicKey)
    {
        Span<byte> basePoint = stackalloc byte[KeySize];
        basePoint.Clear();
        basePoint[0] = 5; // u(G) = 5
        ScalarMult(privateKey, basePoint, publicKey);
    }
}
