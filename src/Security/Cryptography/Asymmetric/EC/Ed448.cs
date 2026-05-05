// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;
using CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Implements Ed448 signatures per RFC 8032 §5.2.
/// </summary>
/// <remarks>
/// <para>
/// Ed448 uses the Edwards curve x² + y² = 1 − 39081·x²·y² over GF(2⁴⁴⁸ − 2²²⁴ − 1),
/// with cofactor 4. The base point B has order L = 2⁴⁴⁶ − 13818066809895115352007386748515426880316871408395898168191144332770916823549.
/// </para>
/// <para>
/// All point arithmetic uses extended Edwards coordinates (X, Y, Z, T)
/// where x = X/Z, y = Y/Z, T = X·Y/Z, using the a=1 (untwisted) formulas.
/// </para>
/// </remarks>
internal static class Ed448
{
    /// <summary>
    /// The size of a private key seed in bytes.
    /// </summary>
    public const int SeedSize = 57;

    /// <summary>
    /// The size of a public key in bytes.
    /// </summary>
    public const int PublicKeySize = 57;

    /// <summary>
    /// The size of a signature in bytes.
    /// </summary>
    public const int SignatureSize = 114;

    private const int N = 7;

    // p = 2^448 - 2^224 - 1
    private static readonly ulong[] PField =
    [
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFEFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL
    ];

    // Group order L = 2^446 − 13818066809895115352007386748515426880336692474882178609894547503885 (little-endian limbs)
    private static readonly ulong[] LOrder =
    [
        0x2378c292ab5844f3UL,
        0x216cc2728dc58f55UL,
        0xc44edb49aed63690UL,
        0xffffffff7cca23e9UL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL,
        0x3FFFFFFFFFFFFFFFUL,
    ];

    // d = -39081 mod p = p - 39081
    private static readonly ulong[] DCoeff =
    [
        0xFFFFFFFFFFFF6756UL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFEFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL
    ];

    // dom4(0, "") = "SigEd448" || 0x00 || 0x00
    private static readonly byte[] Dom4Prefix =
        [0x53, 0x69, 0x67, 0x45, 0x64, 0x34, 0x34, 0x38, 0x00, 0x00];

    // 2·d mod p (precomputed)
    private static readonly ulong[] D2Coeff;

    // Base point coordinates (computed in static constructor)
    private static readonly ulong[] ByCoord;
    private static readonly ulong[] BxCoord;

    private static readonly MontgomeryContext FieldCtx;

    static Ed448()
    {
        FieldCtx = new MontgomeryContext(PField);

        // D2Coeff = 2*d mod p
        D2Coeff = new ulong[N];
        Span<ulong> dMont = stackalloc ulong[N];
        Span<ulong> d2Mont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(DCoeff, dMont);
        FieldCtx.ModAdd(dMont, dMont, d2Mont);
        FieldCtx.FromMontgomery(d2Mont, D2Coeff);

        // Base point B from RFC 8032 §5.2 Table 2 (sourced from RFC 7748 edwards448 base point).
        // X(B) = 224580040295924300187604334099896036246789641632564134246125461686950415467406032909029192869357953282578032075146446173674602635247710
        BxCoord =
        [
            0x2626A82BC70CC05EUL, 0x433B80E18B00938EUL, 0x12AE1AF72AB66511UL,
            0xEA6DE324A3D3A464UL, 0x9E146570470F1767UL, 0x221D15A622BF36DAUL,
            0x4F1970C66BED0DEDUL,
        ];

        // Y(B) = 298819210078481492676017930443930673437544040154080242095928241372331506189835876003536878655418784733982303233503462500531545062832660
        ByCoord =
        [
            0x9808795BF230FA14UL, 0xFDBD132C4ED7C8ADUL, 0x3AD3FF1CE67C39C4UL,
            0x87789C1E05A0C2D7UL, 0x4BEA73736CA39840UL, 0x8876203756C9C762UL,
            0x693F46716EB6BC24UL,
        ];
    }

    // ========================================================================
    // Key Generation
    // ========================================================================

    /// <summary>
    /// Computes the encoded base-point multiple for a raw scalar (for testing).
    /// </summary>
    internal static void ScalarMulBaseEncoded(ReadOnlySpan<ulong> scalar, Span<byte> encoded)
    {
        Span<ulong> ax = stackalloc ulong[N];
        Span<ulong> ay = stackalloc ulong[N];
        Span<ulong> az = stackalloc ulong[N];
        Span<ulong> at = stackalloc ulong[N];
        ScalarMulBase(scalar, ax, ay, az, at);
        EncodePoint(ay, ax, az, encoded);
    }

    /// <summary>
    /// Derives the Ed448 public key from a 57-byte seed.
    /// </summary>
    /// <param name="seed">The 57-byte private key seed.</param>
    /// <param name="publicKey">The 57-byte compressed public key.</param>
    public static void PublicKeyFromSeed(ReadOnlySpan<byte> seed, Span<byte> publicKey)
    {
        Span<byte> h = stackalloc byte[114];
        using (var shake = new Shake256(114))
        {
            shake.AppendData(seed[..SeedSize]);
            shake.TryGetHashAndReset(h, out _);
        }

        ClampScalar(h[..57]);

        Span<ulong> s = stackalloc ulong[N];
        X25519.FromLittleEndianBytes(h[..56], s);

        Span<ulong> ax = stackalloc ulong[N];
        Span<ulong> ay = stackalloc ulong[N];
        Span<ulong> az = stackalloc ulong[N];
        Span<ulong> at = stackalloc ulong[N];
        ScalarMulBase(s, ax, ay, az, at);

        EncodePoint(ay, ax, az, publicKey);
    }

    // ========================================================================
    // Signing
    // ========================================================================

    /// <summary>
    /// Signs a message using Ed448.
    /// </summary>
    /// <param name="seed">The 57-byte private key seed.</param>
    /// <param name="message">The message to sign.</param>
    /// <returns>The 114-byte signature.</returns>
    public static byte[] Sign(ReadOnlySpan<byte> seed, ReadOnlySpan<byte> message)
    {
        Span<byte> h = stackalloc byte[114];
        using (var shake = new Shake256(114))
        {
            shake.AppendData(seed[..SeedSize]);
            shake.TryGetHashAndReset(h, out _);
        }

        ClampScalar(h[..57]);

        Span<ulong> s = stackalloc ulong[N];
        X25519.FromLittleEndianBytes(h[..56], s);

        // A = [s]B
        Span<ulong> ax = stackalloc ulong[N];
        Span<ulong> ay = stackalloc ulong[N];
        Span<ulong> az = stackalloc ulong[N];
        Span<ulong> at = stackalloc ulong[N];
        ScalarMulBase(s, ax, ay, az, at);

        Span<byte> publicKey = stackalloc byte[PublicKeySize];
        EncodePoint(ay, ax, az, publicKey);

        // r = SHAKE256(dom4 || prefix || M, 114) mod L
        Span<byte> rHash = stackalloc byte[114];
        using (var shake = new Shake256(114))
        {
            shake.AppendData(Dom4Prefix);
            shake.AppendData(h[57..114]);
            shake.AppendData(message);
            shake.TryGetHashAndReset(rHash, out _);
        }

        Span<ulong> rReduced = stackalloc ulong[N];
        ReduceModL(rHash, rReduced);

        // R = [r]B
        Span<ulong> rx = stackalloc ulong[N];
        Span<ulong> ry = stackalloc ulong[N];
        Span<ulong> rz = stackalloc ulong[N];
        Span<ulong> rt = stackalloc ulong[N];
        ScalarMulBase(rReduced, rx, ry, rz, rt);

        byte[] signature = new byte[SignatureSize];
        EncodePoint(ry, rx, rz, signature.AsSpan(0, 57));

        // k = SHAKE256(dom4 || R || A || M, 114) mod L
        Span<byte> kHash = stackalloc byte[114];
        using (var shake = new Shake256(114))
        {
            shake.AppendData(Dom4Prefix);
            shake.AppendData(signature.AsSpan(0, 57));
            shake.AppendData(publicKey);
            shake.AppendData(message);
            shake.TryGetHashAndReset(kHash, out _);
        }

        Span<ulong> kReduced = stackalloc ulong[N];
        ReduceModL(kHash, kReduced);

        // S = (r + k*s) mod L
        ComputeS(rReduced, kReduced, s, signature.AsSpan(57, 57));

        return signature;
    }

    // ========================================================================
    // Verification
    // ========================================================================

    /// <summary>
    /// Verifies an Ed448 signature.
    /// </summary>
    /// <param name="publicKey">The 57-byte public key.</param>
    /// <param name="message">The message that was signed.</param>
    /// <param name="signature">The 114-byte signature.</param>
    /// <returns><c>true</c> if the signature is valid.</returns>
    public static bool Verify(ReadOnlySpan<byte> publicKey, ReadOnlySpan<byte> message, ReadOnlySpan<byte> signature)
    {
        if (signature.Length != SignatureSize || publicKey.Length != PublicKeySize)
            return false;

        // Decode R (first 57 bytes)
        Span<ulong> rPx = stackalloc ulong[N];
        Span<ulong> rPy = stackalloc ulong[N];
        if (!DecodePoint(signature[..57], rPx, rPy))
            return false;

        // Decode S (bytes 57-113); byte 113 must be 0
        if (signature[113] != 0)
            return false;

        Span<ulong> sVal = stackalloc ulong[N];
        X25519.FromLittleEndianBytes(signature[57..113], sVal);

        if (BigUInt.Compare(sVal, LOrder) >= 0)
            return false;

        // Decode A (public key)
        Span<ulong> aPx = stackalloc ulong[N];
        Span<ulong> aPy = stackalloc ulong[N];
        if (!DecodePoint(publicKey, aPx, aPy))
            return false;

        // k = SHAKE256(dom4 || R || A || M, 114) mod L
        Span<byte> kHash = stackalloc byte[114];
        using (var shake = new Shake256(114))
        {
            shake.AppendData(Dom4Prefix);
            shake.AppendData(signature[..57]);
            shake.AppendData(publicKey);
            shake.AppendData(message);
            shake.TryGetHashAndReset(kHash, out _);
        }

        Span<ulong> kReduced = stackalloc ulong[N];
        ReduceModL(kHash, kReduced);

        // Check [S]B == R + [k]A  →  [S]B + (-[k]A) == R
        Span<ulong> sbX = stackalloc ulong[N];
        Span<ulong> sbY = stackalloc ulong[N];
        Span<ulong> sbZ = stackalloc ulong[N];
        Span<ulong> sbT = stackalloc ulong[N];
        ScalarMulBase(sVal, sbX, sbY, sbZ, sbT);

        Span<ulong> kaX = stackalloc ulong[N];
        Span<ulong> kaY = stackalloc ulong[N];
        Span<ulong> kaZ = stackalloc ulong[N];
        Span<ulong> kaT = stackalloc ulong[N];
        ScalarMulPoint(kReduced, aPx, aPy, kaX, kaY, kaZ, kaT);

        NegatePoint(kaX, kaT);

        Span<ulong> checkX = stackalloc ulong[N];
        Span<ulong> checkY = stackalloc ulong[N];
        Span<ulong> checkZ = stackalloc ulong[N];
        Span<ulong> checkT = stackalloc ulong[N];
        PointAdd(sbX, sbY, sbZ, sbT, kaX, kaY, kaZ, kaT, checkX, checkY, checkZ, checkT);

        Span<byte> checkEncoded = stackalloc byte[PublicKeySize];
        EncodePoint(checkY, checkX, checkZ, checkEncoded);

        return CryptoHelper.FixedTimeEquals(checkEncoded, signature[..57]);
    }

    // ========================================================================
    // Edwards Point Arithmetic (Extended Coordinates, a=1)
    // ========================================================================

    /// <summary>
    /// Unified point addition on twisted Edwards extended coordinates (add-2008-hwcd).
    /// </summary>
    /// <remarks>
    /// For a=−1: H = B + A (y₃ numerator = y₁y₂ + x₁x₂), D = Z₁Z₂, C = d·T₁T₂.
    /// </remarks>
    private static void PointAdd(
        ReadOnlySpan<ulong> x1, ReadOnlySpan<ulong> y1, ReadOnlySpan<ulong> z1, ReadOnlySpan<ulong> t1,
        ReadOnlySpan<ulong> x2, ReadOnlySpan<ulong> y2, ReadOnlySpan<ulong> z2, ReadOnlySpan<ulong> t2,
        Span<ulong> x3, Span<ulong> y3, Span<ulong> z3, Span<ulong> t3)
    {
        Span<ulong> a = stackalloc ulong[N];
        Span<ulong> b = stackalloc ulong[N];
        Span<ulong> c = stackalloc ulong[N];
        Span<ulong> dd = stackalloc ulong[N];
        Span<ulong> e = stackalloc ulong[N];
        Span<ulong> f = stackalloc ulong[N];
        Span<ulong> g = stackalloc ulong[N];
        Span<ulong> h = stackalloc ulong[N];
        Span<ulong> t0 = stackalloc ulong[N];

        // A = X1*X2, B = Y1*Y2
        FieldCtx.MontMul(x1, x2, a);
        FieldCtx.MontMul(y1, y2, b);

        // C = d*T1*T2  (a=1 Edwards uses d, not 2d; and D = Z1*Z2, not 2*Z1*Z2)
        Span<ulong> dMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(DCoeff, dMont);
        FieldCtx.MontMul(t1, dMont, t0);
        FieldCtx.MontMul(t0, t2, c);

        // D = Z1*Z2
        FieldCtx.MontMul(z1, z2, dd);

        // E = (X1+Y1)*(X2+Y2) - A - B
        Span<ulong> xy1 = stackalloc ulong[N];
        Span<ulong> xy2 = stackalloc ulong[N];
        FieldCtx.ModAdd(x1, y1, xy1);
        FieldCtx.ModAdd(x2, y2, xy2);
        FieldCtx.MontMul(xy1, xy2, e);
        FieldCtx.ModSub(e, a, e);
        FieldCtx.ModSub(e, b, e);

        // F = D - C, G = D + C
        FieldCtx.ModSub(dd, c, f);
        FieldCtx.ModAdd(dd, c, g);

        // H = B − A  (y₃ numerator = y₁y₂ − x₁x₂ for the RFC 8032 Ed448 group law)
        FieldCtx.ModSub(b, a, h);

        FieldCtx.MontMul(e, f, x3);
        FieldCtx.MontMul(g, h, y3);
        FieldCtx.MontMul(e, h, t3);
        FieldCtx.MontMul(f, g, z3);
    }

    /// <summary>
    /// Point doubling on twisted Edwards extended coordinates (dbl-2008-hwcd).
    /// </summary>
    /// <remarks>
    /// For a=−1: D = −A, so G = B−A and H = −(A+B).
    /// </remarks>
    private static void PointDouble(
        ReadOnlySpan<ulong> x1, ReadOnlySpan<ulong> y1, ReadOnlySpan<ulong> z1, ReadOnlySpan<ulong> t1,
        Span<ulong> x3, Span<ulong> y3, Span<ulong> z3, Span<ulong> t3)
    {
        Span<ulong> a = stackalloc ulong[N];
        Span<ulong> b = stackalloc ulong[N];
        Span<ulong> c = stackalloc ulong[N];
        Span<ulong> e = stackalloc ulong[N];
        Span<ulong> f = stackalloc ulong[N];
        Span<ulong> g = stackalloc ulong[N];
        Span<ulong> h = stackalloc ulong[N];
        Span<ulong> t0 = stackalloc ulong[N];

        // A = X1², B = Y1²
        FieldCtx.MontSquare(x1, a);
        FieldCtx.MontSquare(y1, b);

        // C = d·T1²  (d = DCoeff = −39081 mod p; a=1 curve: C = d·t² as in point_add(P,P))
        Span<ulong> dMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(DCoeff, dMont);
        FieldCtx.MontMul(t1, dMont, t0);
        FieldCtx.MontMul(t0, t1, c);

        // D = Z1²
        Span<ulong> dd = stackalloc ulong[N];
        FieldCtx.MontSquare(z1, dd);

        // G = D + C  (denominator for x₃: 1 + d·t² in affine)
        FieldCtx.ModAdd(dd, c, g);

        // E = (X1+Y1)² − A − B  (numerator for x₃: 2·x·y in affine)
        FieldCtx.ModAdd(x1, y1, t0);
        FieldCtx.MontSquare(t0, e);
        FieldCtx.ModSub(e, a, e);
        FieldCtx.ModSub(e, b, e);

        // F = D − C  (denominator for y₃: 1 − d·t² in affine)
        FieldCtx.ModSub(dd, c, f);

        // H = B − A  (numerator for y₃: y² − x² in affine)
        FieldCtx.ModSub(b, a, h);

        FieldCtx.MontMul(e, f, x3);
        FieldCtx.MontMul(g, h, y3);
        FieldCtx.MontMul(e, h, t3);
        FieldCtx.MontMul(f, g, z3);
    }

    /// <summary>
    /// Negates a point in extended coordinates: −(X,Y,Z,T) = (−X,Y,Z,−T).
    /// </summary>
    private static void NegatePoint(Span<ulong> x, Span<ulong> t)
    {
        Span<ulong> zero = stackalloc ulong[N];
        zero.Clear();
        Span<ulong> zeroMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(zero, zeroMont);

        Span<ulong> negX = stackalloc ulong[N];
        Span<ulong> negT = stackalloc ulong[N];
        FieldCtx.ModSub(zeroMont, x, negX);
        FieldCtx.ModSub(zeroMont, t, negT);
        negX.CopyTo(x);
        negT.CopyTo(t);
    }

    // ========================================================================
    // Scalar Multiplication
    // ========================================================================

    /// <summary>
    /// Computes [k]B where B is the Ed448 base point. Returns extended coordinates in Montgomery form.
    /// </summary>
    private static void ScalarMulBase(
        ReadOnlySpan<ulong> k,
        Span<ulong> rx, Span<ulong> ry, Span<ulong> rz, Span<ulong> rt)
    {
        Span<ulong> bxMont = stackalloc ulong[N];
        Span<ulong> byMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(BxCoord, bxMont);
        FieldCtx.ToMontgomery(ByCoord, byMont);
        ScalarMulPoint(k, bxMont, byMont, rx, ry, rz, rt);
    }

    /// <summary>
    /// Computes [k]P where P is given in affine Montgomery form. Returns extended coordinates in Montgomery form.
    /// </summary>
    private static void ScalarMulPoint(
        ReadOnlySpan<ulong> k,
        ReadOnlySpan<ulong> pxMont, ReadOnlySpan<ulong> pyMont,
        Span<ulong> rx, Span<ulong> ry, Span<ulong> rz, Span<ulong> rt)
    {
        Span<ulong> oneMont = stackalloc ulong[N];
        Span<ulong> oneNorm = stackalloc ulong[N];
        oneNorm.Clear();
        oneNorm[0] = 1;
        FieldCtx.ToMontgomery(oneNorm, oneMont);

        Span<ulong> zeroMont = stackalloc ulong[N];
        Span<ulong> zeroNorm = stackalloc ulong[N];
        zeroNorm.Clear();
        FieldCtx.ToMontgomery(zeroNorm, zeroMont);

        // Identity = (0:1:1:0)
        zeroMont.CopyTo(rx);
        oneMont.CopyTo(ry);
        oneMont.CopyTo(rz);
        zeroMont.CopyTo(rt);

        // P in extended: (px, py, 1, px*py)
        Span<ulong> ppx = stackalloc ulong[N];
        Span<ulong> ppy = stackalloc ulong[N];
        Span<ulong> ppz = stackalloc ulong[N];
        Span<ulong> ppt = stackalloc ulong[N];
        pxMont.CopyTo(ppx);
        pyMont.CopyTo(ppy);
        oneMont.CopyTo(ppz);
        FieldCtx.MontMul(pxMont, pyMont, ppt);

        Span<ulong> tmpX = stackalloc ulong[N];
        Span<ulong> tmpY = stackalloc ulong[N];
        Span<ulong> tmpZ = stackalloc ulong[N];
        Span<ulong> tmpT = stackalloc ulong[N];

        int totalBits = BigUInt.BitLength(k);
        if (totalBits == 0) return;

        for (int i = totalBits - 1; i >= 0; i--)
        {
            // Double
            PointDouble(rx, ry, rz, rt, tmpX, tmpY, tmpZ, tmpT);
            tmpX.CopyTo(rx);
            tmpY.CopyTo(ry);
            tmpZ.CopyTo(rz);
            tmpT.CopyTo(rt);

            // Add P (always computed for constant-time)
            PointAdd(rx, ry, rz, rt, ppx, ppy, ppz, ppt, tmpX, tmpY, tmpZ, tmpT);

            int limbIdx = i / 64;
            int bitIdx = i % 64;
            ulong bit = limbIdx < k.Length ? (k[limbIdx] >> bitIdx) & 1 : 0;

            BigUInt.ConditionalCopy(bit, rx, tmpX);
            BigUInt.ConditionalCopy(bit, ry, tmpY);
            BigUInt.ConditionalCopy(bit, rz, tmpZ);
            BigUInt.ConditionalCopy(bit, rt, tmpT);
        }
    }

    // ========================================================================
    // Point Encoding / Decoding
    // ========================================================================

    /// <summary>
    /// Encodes a point in extended Montgomery form to 57 bytes (RFC 8032 §5.2.2).
    /// y in 56 LE bytes; bit 7 of byte 56 carries the sign of x.
    /// </summary>
    private static void EncodePoint(
        ReadOnlySpan<ulong> yMont, ReadOnlySpan<ulong> xMont, ReadOnlySpan<ulong> zMont,
        Span<byte> encoded)
    {
        Span<ulong> zNorm = stackalloc ulong[N];
        FieldCtx.FromMontgomery(zMont, zNorm);

        Span<ulong> pMinus2 = stackalloc ulong[N];
        BigUInt.SubWord(PField, 2, pMinus2);

        Span<ulong> zInv = stackalloc ulong[N];
        FieldCtx.ModExp(zNorm, pMinus2, zInv);

        Span<ulong> zInvMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(zInv, zInvMont);

        Span<ulong> xAff = stackalloc ulong[N];
        Span<ulong> yAff = stackalloc ulong[N];
        FieldCtx.MontMul(xMont, zInvMont, xAff);
        FieldCtx.MontMul(yMont, zInvMont, yAff);

        Span<ulong> xNorm = stackalloc ulong[N];
        Span<ulong> yNorm = stackalloc ulong[N];
        FieldCtx.FromMontgomery(xAff, xNorm);
        FieldCtx.FromMontgomery(yAff, yNorm);

        X25519.ToLittleEndianBytes(yNorm, encoded[..56]);
        encoded[56] = (byte)((xNorm[0] & 1) << 7);
    }

    /// <summary>
    /// Decodes a compressed point (57 bytes) to affine coordinates in Montgomery form.
    /// </summary>
    /// <returns><c>true</c> if the encoded point is valid.</returns>
    private static bool DecodePoint(ReadOnlySpan<byte> encoded, Span<ulong> xMont, Span<ulong> yMont)
    {
        int xSign = (encoded[56] >> 7) & 1;

        Span<byte> yBytes = stackalloc byte[56];
        encoded[..56].CopyTo(yBytes);

        Span<ulong> yNorm = stackalloc ulong[N];
        X25519.FromLittleEndianBytes(yBytes, yNorm);

        if (BigUInt.Compare(yNorm, PField) >= 0)
            return false;

        Span<ulong> yMontLocal = stackalloc ulong[N];
        FieldCtx.ToMontgomery(yNorm, yMontLocal);

        Span<ulong> y2 = stackalloc ulong[N];
        FieldCtx.MontSquare(yMontLocal, y2);

        Span<ulong> oneMont = stackalloc ulong[N];
        Span<ulong> oneNorm = stackalloc ulong[N];
        oneNorm.Clear();
        oneNorm[0] = 1;
        FieldCtx.ToMontgomery(oneNorm, oneMont);

        // x² = (1 − y²) / (1 + 39081·y²)
        Span<ulong> num = stackalloc ulong[N];
        FieldCtx.ModSub(oneMont, y2, num);

        Span<ulong> c39081 = stackalloc ulong[N];
        c39081.Clear();
        c39081[0] = 39081;
        Span<ulong> c39081Mont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(c39081, c39081Mont);
        Span<ulong> c39081y2 = stackalloc ulong[N];
        FieldCtx.MontMul(c39081Mont, y2, c39081y2);
        Span<ulong> den = stackalloc ulong[N];
        FieldCtx.ModAdd(oneMont, c39081y2, den);  // den = 1 + 39081·y²  (x² = (1−y²) / (1+39081·y²))

        Span<ulong> denNorm = stackalloc ulong[N];
        FieldCtx.FromMontgomery(den, denNorm);

        Span<ulong> pMinus2 = stackalloc ulong[N];
        BigUInt.SubWord(PField, 2, pMinus2);

        Span<ulong> denInv = stackalloc ulong[N];
        FieldCtx.ModExp(denNorm, pMinus2, denInv);

        Span<ulong> denInvMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(denInv, denInvMont);

        Span<ulong> uVal = stackalloc ulong[N];
        FieldCtx.MontMul(num, denInvMont, uVal);

        // sqrt: x = u^((p+1)/4) mod p
        Span<ulong> uNorm = stackalloc ulong[N];
        FieldCtx.FromMontgomery(uVal, uNorm);

        Span<ulong> sqrtExp = stackalloc ulong[N];
        sqrtExp[0] = 0x0000000000000000UL;
        sqrtExp[1] = 0x0000000000000000UL;
        sqrtExp[2] = 0x0000000000000000UL;
        sqrtExp[3] = 0xFFFFFFFFC0000000UL;
        sqrtExp[4] = 0xFFFFFFFFFFFFFFFFUL;
        sqrtExp[5] = 0xFFFFFFFFFFFFFFFFUL;
        sqrtExp[6] = 0x3FFFFFFFFFFFFFFFUL;

        Span<ulong> candidate = stackalloc ulong[N];
        FieldCtx.ModExp(uNorm, sqrtExp, candidate);

        // Verify candidate² == u (ensures u is a quadratic residue)
        Span<ulong> candidateMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(candidate, candidateMont);
        Span<ulong> check = stackalloc ulong[N];
        FieldCtx.MontSquare(candidateMont, check);
        Span<ulong> checkNorm = stackalloc ulong[N];
        FieldCtx.FromMontgomery(check, checkNorm);

        if (!BigUInt.ConstantTimeEqual(checkNorm, uNorm))
            return false;

        // Fix sign
        if (((int)candidate[0] & 1) != xSign)
        {
            Span<ulong> negated = stackalloc ulong[N];
            BigUInt.Sub(PField, candidate, negated);
            negated.CopyTo(candidate);
            FieldCtx.ToMontgomery(candidate, candidateMont);
        }

        candidateMont.CopyTo(xMont);
        yMontLocal.CopyTo(yMont);
        return true;
    }

    // ========================================================================
    // Scalar Reduction mod L
    // ========================================================================

    /// <summary>
    /// Reduces a 114-byte hash to a scalar mod L (group order).
    /// </summary>
    private static void ReduceModL(ReadOnlySpan<byte> hash114, Span<ulong> result)
    {
        // 114 bytes → 15 limbs (last limb uses only 2 bytes)
        Span<ulong> wide = stackalloc ulong[15];
        X25519.FromLittleEndianBytes(hash114[..114], wide);
        ReduceWideMod(wide, LOrder, result);
    }

    /// <summary>
    /// Reduces a wide value mod a smaller modulus using schoolbook shift-subtract.
    /// </summary>
    private static void ReduceWideMod(ReadOnlySpan<ulong> wide, ReadOnlySpan<ulong> modulus, Span<ulong> result)
    {
        int wideLimbs = wide.Length;
        int modLimbs = modulus.Length;

        Span<ulong> rem = stackalloc ulong[wideLimbs];
        wide.CopyTo(rem);

        int wideBits = 0;
        for (int i = wideLimbs - 1; i >= 0; i--)
        {
            if (rem[i] != 0)
            {
                wideBits = i * 64 + (64 - LeadingZeroCount(rem[i]));
                break;
            }
        }

        int modBits = BigUInt.BitLength(modulus);

        for (int shift = wideBits - modBits; shift >= 0; shift--)
        {
            Span<ulong> shifted = stackalloc ulong[wideLimbs];
            shifted.Clear();

            int limbShift = shift / 64;
            int bitShift = shift % 64;

            for (int j = 0; j < modLimbs && (j + limbShift) < wideLimbs; j++)
            {
                shifted[j + limbShift] |= modulus[j] << bitShift;
                if (bitShift > 0 && (j + limbShift + 1) < wideLimbs)
                    shifted[j + limbShift + 1] |= modulus[j] >> (64 - bitShift);
            }

            ulong borrow = 0;
            Span<ulong> temp = stackalloc ulong[wideLimbs];
            for (int j = 0; j < wideLimbs; j++)
            {
                ulong diff = rem[j] - shifted[j] - borrow;
                borrow = ((~rem[j] & shifted[j]) | (~(rem[j] ^ shifted[j]) & diff)) >> 63;
                temp[j] = diff;
            }

            if (borrow == 0)
                temp.CopyTo(rem);
        }

        rem[..modLimbs].CopyTo(result);
    }

    /// <summary>
    /// Computes S = (r + k·s) mod L for the signature scalar.
    /// </summary>
    private static void ComputeS(
        ReadOnlySpan<ulong> r, ReadOnlySpan<ulong> k, ReadOnlySpan<ulong> s, Span<byte> sEncoded)
    {
        // k·s: both < L (< 2^446), product fits in 14 limbs
        Span<ulong> ks = stackalloc ulong[14];
        ks.Clear();

        for (int i = 0; i < N; i++)
        {
            ulong carry = 0;
            ulong carryHi = 0;
            for (int j = 0; j < N; j++)
            {
                ulong hi = BigUInt.Mul128(k[i], s[j], out ulong lo);
                ulong sum = ks[i + j] + lo;
                ulong c1 = sum < lo ? 1UL : 0UL;
                sum += carry;
                ulong c2 = sum < carry ? 1UL : 0UL;
                ks[i + j] = sum;

                carry = hi + c1;
                carryHi = carry < hi ? 1UL : 0UL;
                carry += c2;
                carryHi += carry < c2 ? 1UL : 0UL;
            }

            int pos = i + N;
            if (pos < 14)
            {
                ulong sum = ks[pos] + carry;
                ulong c = sum < carry ? 1UL : 0UL;
                ks[pos] = sum;
                carryHi += c;
                if (carryHi != 0 && pos + 1 < 14)
                    ks[pos + 1] += carryHi;
            }
        }

        // Add r to ks
        ulong addCarry = 0;
        for (int i = 0; i < N; i++)
        {
            ulong temp = ks[i] + r[i];
            ulong c1 = ((ks[i] & r[i]) | ((ks[i] | r[i]) & ~temp)) >> 63;
            ulong sum = temp + addCarry;
            ulong c2 = ((temp & addCarry) | ((temp | addCarry) & ~sum)) >> 63;
            ks[i] = sum;
            addCarry = c1 | c2;
        }

        for (int i = N; i < 14 && addCarry != 0; i++)
        {
            ulong sum = ks[i] + addCarry;
            addCarry = sum < addCarry ? 1UL : 0UL;
            ks[i] = sum;
        }

        // Reduce mod L
        Span<ulong> result = stackalloc ulong[N];
        ReduceWideMod(ks, LOrder, result);

        X25519.ToLittleEndianBytes(result, sEncoded[..56]);
        sEncoded[56] = 0;
    }

    /// <summary>
    /// Clamps a 57-byte scalar per Ed448 rules (RFC 8032 §5.2.5).
    /// </summary>
    private static void ClampScalar(Span<byte> scalar)
    {
        scalar[0] &= 252;
        scalar[55] |= 128;
        scalar[56] = 0;
    }

    private static int LeadingZeroCount(ulong value)
    {
#if NET8_0_OR_GREATER
        return System.Numerics.BitOperations.LeadingZeroCount(value);
#else
        if (value == 0) return 64;
        int count = 0;
        if ((value & 0xFFFFFFFF00000000UL) == 0) { count += 32; value <<= 32; }
        if ((value & 0xFFFF000000000000UL) == 0) { count += 16; value <<= 16; }
        if ((value & 0xFF00000000000000UL) == 0) { count += 8; value <<= 8; }
        if ((value & 0xF000000000000000UL) == 0) { count += 4; value <<= 4; }
        if ((value & 0xC000000000000000UL) == 0) { count += 2; value <<= 2; }
        if ((value & 0x8000000000000000UL) == 0) { count += 1; }
        return count;
#endif
    }
}

