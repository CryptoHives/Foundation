// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using System.Buffers.Binary;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// Implements the X25519 Diffie-Hellman function per RFC 7748.
/// </summary>
/// <remarks>
/// <para>
/// X25519 is an elliptic curve Diffie-Hellman (ECDH) function based on Curve25519
/// (a Montgomery curve over GF(2²⁵⁵ − 19)). It computes a shared secret from
/// a private scalar and a peer's public u-coordinate.
/// </para>
/// <para>
/// All operations use the Montgomery ladder for constant-time scalar multiplication
/// with only the x-coordinate, following RFC 7748 section 5.
/// </para>
/// </remarks>
internal static class X25519
{
    /// <summary>
    /// The size in bytes of a scalar, public key, or shared secret.
    /// </summary>
    public const int KeySize = 32;

    private const int LimbCount = 4;
    private const ulong A24 = 121665; // (A-2)/4 for A = 486662, used with AA in the ladder step

    /// <summary>
    /// Computes the X25519 function: result = clamp(k) · u on Curve25519.
    /// </summary>
    /// <param name="k">The 32-byte secret scalar (little-endian).</param>
    /// <param name="u">The 32-byte u-coordinate of the peer's public key (little-endian).</param>
    /// <param name="result">The 32-byte shared secret (little-endian).</param>
    public static void ScalarMult(ReadOnlySpan<byte> k, ReadOnlySpan<byte> u, Span<byte> result)
    {
        const int n = LimbCount;

        // Clamp scalar per RFC 7748 §5
        Span<byte> scalar = stackalloc byte[KeySize];
        k[..KeySize].CopyTo(scalar);
        scalar[0] &= 248;
        scalar[31] &= 127;
        scalar[31] |= 64;

        // Decode u-coordinate (mask high bit per RFC 7748)
        Span<byte> uBytes = stackalloc byte[KeySize];
        u[..KeySize].CopyTo(uBytes);
        uBytes[31] &= 127;

        Span<ulong> uLimbs = stackalloc ulong[n];
        FromLittleEndianBytes(uBytes, uLimbs);

        // Field setup: p = 2²⁵⁵ − 19
        Span<ulong> pLimbs = stackalloc ulong[n];
        pLimbs[0] = 0xFFFFFFFFFFFFFFEDUL;
        pLimbs[1] = 0xFFFFFFFFFFFFFFFFUL;
        pLimbs[2] = 0xFFFFFFFFFFFFFFFFUL;
        pLimbs[3] = 0x7FFFFFFFFFFFFFFFUL;

        var field = new MontgomeryContext(pLimbs);

        // Convert to Montgomery form
        Span<ulong> uMont = stackalloc ulong[n];
        field.ToMontgomery(uLimbs, uMont);

        Span<ulong> oneMont = stackalloc ulong[n];
        Span<ulong> oneNorm = stackalloc ulong[n];
        oneNorm.Clear();
        oneNorm[0] = 1;
        field.ToMontgomery(oneNorm, oneMont);

        // a24 = (A+2)/4 = 121666 in Montgomery form
        Span<ulong> a24Norm = stackalloc ulong[n];
        a24Norm.Clear();
        a24Norm[0] = A24;
        Span<ulong> a24Mont = stackalloc ulong[n];
        field.ToMontgomery(a24Norm, a24Mont);

        // Montgomery ladder state: x2:z2 = 1:0, x3:z3 = u:1
        Span<ulong> x2 = stackalloc ulong[n];
        Span<ulong> z2 = stackalloc ulong[n];
        Span<ulong> x3 = stackalloc ulong[n];
        Span<ulong> z3 = stackalloc ulong[n];

        oneMont.CopyTo(x2);
        z2.Clear();
        uMont.CopyTo(x3);
        oneMont.CopyTo(z3);

        // Temporaries for the ladder step
        Span<ulong> a = stackalloc ulong[n];
        Span<ulong> aa = stackalloc ulong[n];
        Span<ulong> b = stackalloc ulong[n];
        Span<ulong> bb = stackalloc ulong[n];
        Span<ulong> e = stackalloc ulong[n];
        Span<ulong> c = stackalloc ulong[n];
        Span<ulong> d = stackalloc ulong[n];
        Span<ulong> da = stackalloc ulong[n];
        Span<ulong> cb = stackalloc ulong[n];
        Span<ulong> t0 = stackalloc ulong[n];

        ulong swap = 0;

        // Process bits 254 down to 0
        for (int pos = 254; pos >= 0; pos--)
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
        Span<ulong> z2Norm = stackalloc ulong[n];
        field.FromMontgomery(z2, z2Norm);

        Span<ulong> pMinus2 = stackalloc ulong[n];
        BigUInt.SubWord(pLimbs, 2, pMinus2);

        Span<ulong> z2Inv = stackalloc ulong[n];
        field.ModExp(z2Norm, pMinus2, z2Inv);

        Span<ulong> z2InvMont = stackalloc ulong[n];
        field.ToMontgomery(z2Inv, z2InvMont);

        Span<ulong> resMont = stackalloc ulong[n];
        field.MontMul(x2, z2InvMont, resMont);

        Span<ulong> resNorm = stackalloc ulong[n];
        field.FromMontgomery(resMont, resNorm);

        ToLittleEndianBytes(resNorm, result[..KeySize]);
    }

    /// <summary>
    /// Computes the public key from a private scalar: result = clamp(k) · 9.
    /// </summary>
    /// <param name="privateKey">The 32-byte private key (little-endian).</param>
    /// <param name="publicKey">The 32-byte public key (little-endian).</param>
    public static void ScalarMultBase(ReadOnlySpan<byte> privateKey, Span<byte> publicKey)
    {
        Span<byte> basePoint = stackalloc byte[KeySize];
        basePoint.Clear();
        basePoint[0] = 9; // u(G) = 9
        ScalarMult(privateKey, basePoint, publicKey);
    }

    // ========================================================================
    // Little-Endian Byte Helpers
    // ========================================================================

    internal static void FromLittleEndianBytes(ReadOnlySpan<byte> bytes, Span<ulong> limbs)
    {
        limbs.Clear();
        int limbCount = Math.Min(limbs.Length, (bytes.Length + 7) / 8);
        for (int i = 0; i < limbCount; i++)
        {
            int offset = i * 8;
            int remaining = bytes.Length - offset;
            if (remaining >= 8)
            {
                limbs[i] = BinaryPrimitives.ReadUInt64LittleEndian(bytes.Slice(offset, 8));
            }
            else
            {
                ulong val = 0;
                for (int j = 0; j < remaining; j++)
                    val |= (ulong)bytes[offset + j] << (j * 8);
                limbs[i] = val;
            }
        }
    }

    internal static void ToLittleEndianBytes(ReadOnlySpan<ulong> limbs, Span<byte> bytes)
    {
        bytes.Clear();
        int limbCount = Math.Min(limbs.Length, (bytes.Length + 7) / 8);
        for (int i = 0; i < limbCount; i++)
        {
            int offset = i * 8;
            int remaining = bytes.Length - offset;
            if (remaining >= 8)
            {
                BinaryPrimitives.WriteUInt64LittleEndian(bytes.Slice(offset, 8), limbs[i]);
            }
            else
            {
                ulong val = limbs[i];
                for (int j = 0; j < remaining; j++)
                    bytes[offset + j] = (byte)(val >> (j * 8));
            }
        }
    }
}
