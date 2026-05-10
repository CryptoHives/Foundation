// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

using ManagedSha512 = CryptoHives.Foundation.Security.Cryptography.Hash.SHA512;

/// <summary>
/// Implements Ed25519 signatures per RFC 8032 §5.1.
/// </summary>
/// <remarks>
/// <para>
/// Ed25519 uses the twisted Edwards curve −x² + y² = 1 + dx²y² over GF(2²⁵⁵ − 19),
/// with d = −121665/121666 mod p. The base point B has order L = 2²⁵² + 27742317777372353535851937790883648493.
/// </para>
/// <para>
/// All point arithmetic uses extended twisted Edwards coordinates (X, Y, Z, T)
/// where x = X/Z, y = Y/Z, T = X·Y/Z, for efficient constant-time operations.
/// </para>
/// </remarks>
internal static class Ed25519
{
    /// <summary>
    /// The size of a private key seed in bytes.
    /// </summary>
    public const int SeedSize = 32;

    /// <summary>
    /// The size of a public key in bytes.
    /// </summary>
    public const int PublicKeySize = 32;

    /// <summary>
    /// The size of a signature in bytes.
    /// </summary>
    public const int SignatureSize = 64;

    private const int N = 4; // limb count for 256-bit field

    // p = 2²⁵⁵ − 19
    private static readonly ulong[] PField =
    [
        0xFFFFFFFFFFFFFFEDUL,
        0xFFFFFFFFFFFFFFFFUL,
        0xFFFFFFFFFFFFFFFFUL,
        0x7FFFFFFFFFFFFFFFUL
    ];

    // Group order L = 2²⁵² + 27742317777372353535851937790883648493
    private static readonly ulong[] LOrder =
    [
        0x5812631A5CF5D3EDUL,
        0x14DEF9DEA2F79CD6UL,
        0x0000000000000000UL,
        0x1000000000000000UL
    ];

    // d = -121665/121666 mod p
    // = 37095705934669439343138083508754565189542113879843219016388785533085940283555
    private static readonly ulong[] DCoeff =
    [
        0x75EB4DCA135978A3UL,
        0x00700A4D4141D8ABUL,
        0x8CC740797779E898UL,
        0x52036CEE2B6FFE73UL
    ];

    // 2·d mod p (precomputed for point addition)
    private static readonly ulong[] D2Coeff;

    // Base point B
    private static readonly ulong[] ByCoord =
    [
        0x6666666666666658UL,
        0x6666666666666666UL,
        0x6666666666666666UL,
        0x6666666666666666UL
    ];

    private static readonly ulong[] BxCoord =
    [
        0xC9562D608F25D51AUL,
        0x692CC7609525A7B2UL,
        0xC0A4E231FDD6DC5CUL,
        0x216936D3CD6E53FEUL
    ];

    private static readonly MontgomeryContext FieldCtx;

    static Ed25519()
    {
        FieldCtx = new MontgomeryContext(PField);

        // Precompute 2d mod p
        D2Coeff = new ulong[N];
        Span<ulong> dMont = stackalloc ulong[N];
        Span<ulong> d2Mont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(DCoeff, dMont);
        FieldCtx.ModAdd(dMont, dMont, d2Mont);
        FieldCtx.FromMontgomery(d2Mont, D2Coeff);
    }

    // ========================================================================
    // Key Generation
    // ========================================================================

    /// <summary>
    /// Computes the encoded point for a raw scalar (for testing).
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
    /// Derives the Ed25519 public key from a 32-byte seed.
    /// </summary>
    /// <param name="seed">The 32-byte private key seed.</param>
    /// <param name="publicKey">The 32-byte compressed public key.</param>
    public static void PublicKeyFromSeed(ReadOnlySpan<byte> seed, Span<byte> publicKey)
    {
        // h = SHA-512(seed)
        Span<byte> h = stackalloc byte[64];
        using (var sha = new ManagedSha512())
            sha.TryComputeHash(seed[..SeedSize], h, out _);

        // Clamp scalar from first 32 bytes
        ClampScalar(h[..32]);

        // Decode scalar
        Span<ulong> s = stackalloc ulong[N];
        X25519.FromLittleEndianBytes(h[..32], s);

        // A = [s]B
        Span<ulong> ax = stackalloc ulong[N];
        Span<ulong> ay = stackalloc ulong[N];
        Span<ulong> az = stackalloc ulong[N];
        Span<ulong> at = stackalloc ulong[N];
        ScalarMulBase(s, ax, ay, az, at);

        // Encode the public key
        EncodePoint(ay, ax, az, publicKey);
    }

    // ========================================================================
    // Signing
    // ========================================================================

    /// <summary>
    /// Signs a message using Ed25519.
    /// </summary>
    /// <param name="seed">The 32-byte private key seed.</param>
    /// <param name="message">The message to sign.</param>
    /// <returns>The 64-byte signature.</returns>
    public static byte[] Sign(ReadOnlySpan<byte> seed, ReadOnlySpan<byte> message)
    {
        // h = SHA-512(seed)
        Span<byte> h = stackalloc byte[64];
        using (var sha = new ManagedSha512())
            sha.TryComputeHash(seed[..SeedSize], h, out _);

        ClampScalar(h[..32]);

        Span<ulong> s = stackalloc ulong[N];
        X25519.FromLittleEndianBytes(h[..32], s);

        // Compute public key A = [s]B
        Span<ulong> ax = stackalloc ulong[N];
        Span<ulong> ay = stackalloc ulong[N];
        Span<ulong> az = stackalloc ulong[N];
        Span<ulong> at = stackalloc ulong[N];
        ScalarMulBase(s, ax, ay, az, at);

        Span<byte> publicKey = stackalloc byte[PublicKeySize];
        EncodePoint(ay, ax, az, publicKey);

        // r = SHA-512(h[32..64] || message) mod L
        byte[] rHash = new byte[64];
        using (var sha = new ManagedSha512())
        {
            sha.AppendData(h[32..64]);
            sha.AppendData(message);
            sha.TryGetHashAndReset(rHash, out _);
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
        EncodePoint(ry, rx, rz, signature.AsSpan(0, 32));

        // k = SHA-512(R_encoded || A_encoded || message) mod L
        byte[] kHash = new byte[64];
        using (var sha = new ManagedSha512())
        {
            sha.AppendData(signature.AsSpan(0, 32));
            sha.AppendData(publicKey);
            sha.AppendData(message);
            sha.TryGetHashAndReset(kHash, out _);
        }

        Span<ulong> kReduced = stackalloc ulong[N];
        ReduceModL(kHash, kReduced);

        // S = (r + k·s) mod L
        ComputeS(rReduced, kReduced, s, signature.AsSpan(32, 32));

        return signature;
    }

    // ========================================================================
    // Verification
    // ========================================================================

    /// <summary>
    /// Verifies an Ed25519 signature.
    /// </summary>
    /// <param name="publicKey">The 32-byte public key.</param>
    /// <param name="message">The message that was signed.</param>
    /// <param name="signature">The 64-byte signature.</param>
    /// <returns><c>true</c> if the signature is valid.</returns>
    public static bool Verify(ReadOnlySpan<byte> publicKey, ReadOnlySpan<byte> message, ReadOnlySpan<byte> signature)
    {
        if (signature.Length != SignatureSize || publicKey.Length != PublicKeySize)
            return false;

        // Decode R from first 32 bytes of signature
        Span<ulong> rPx = stackalloc ulong[N];
        Span<ulong> rPy = stackalloc ulong[N];
        if (!DecodePoint(signature[..32], rPx, rPy))
            return false;

        // Decode S from last 32 bytes of signature
        Span<ulong> sVal = stackalloc ulong[N];
        X25519.FromLittleEndianBytes(signature[32..64], sVal);

        // Check S < L
        if (BigUInt.Compare(sVal, LOrder) >= 0)
            return false;

        // Decode A (public key)
        Span<ulong> aPx = stackalloc ulong[N];
        Span<ulong> aPy = stackalloc ulong[N];
        if (!DecodePoint(publicKey, aPx, aPy))
            return false;

        // k = SHA-512(R_encoded || A_encoded || message) mod L
        byte[] kHash = new byte[64];
        using (var sha = new ManagedSha512())
        {
            sha.AppendData(signature[..32]);
            sha.AppendData(publicKey);
            sha.AppendData(message);
            sha.TryGetHashAndReset(kHash, out _);
        }

        Span<ulong> kReduced = stackalloc ulong[N];
        ReduceModL(kHash, kReduced);

        // Check: [S]B == R + [k]A
        // Equivalently: [S]B - [k]A == R

        // Compute [S]B
        Span<ulong> sbX = stackalloc ulong[N];
        Span<ulong> sbY = stackalloc ulong[N];
        Span<ulong> sbZ = stackalloc ulong[N];
        Span<ulong> sbT = stackalloc ulong[N];
        ScalarMulBase(sVal, sbX, sbY, sbZ, sbT);

        // Compute [k]A
        Span<ulong> kaX = stackalloc ulong[N];
        Span<ulong> kaY = stackalloc ulong[N];
        Span<ulong> kaZ = stackalloc ulong[N];
        Span<ulong> kaT = stackalloc ulong[N];
        ScalarMulPoint(kReduced, aPx, aPy, kaX, kaY, kaZ, kaT);

        // Negate [k]A: negate X and T coordinates (Edwards negation: -(x,y) = (-x, y))
        NegatePoint(kaX, kaT);

        // Add [S]B + (-[k]A)
        Span<ulong> checkX = stackalloc ulong[N];
        Span<ulong> checkY = stackalloc ulong[N];
        Span<ulong> checkZ = stackalloc ulong[N];
        Span<ulong> checkT = stackalloc ulong[N];
        PointAdd(sbX, sbY, sbZ, sbT, kaX, kaY, kaZ, kaT, checkX, checkY, checkZ, checkT);

        // Encode the result and compare with R
        Span<byte> checkEncoded = stackalloc byte[PublicKeySize];
        EncodePoint(checkY, checkX, checkZ, checkEncoded);

        return CryptoHelper.FixedTimeEquals(checkEncoded, signature[..32]);
    }

    // ========================================================================
    // Edwards Point Arithmetic (Extended Coordinates)
    // ========================================================================

    /// <summary>
    /// Point addition on extended twisted Edwards coordinates.
    /// </summary>
    private static void PointAdd(
        ReadOnlySpan<ulong> x1, ReadOnlySpan<ulong> y1, ReadOnlySpan<ulong> z1, ReadOnlySpan<ulong> t1,
        ReadOnlySpan<ulong> x2, ReadOnlySpan<ulong> y2, ReadOnlySpan<ulong> z2, ReadOnlySpan<ulong> t2,
        Span<ulong> x3, Span<ulong> y3, Span<ulong> z3, Span<ulong> t3)
    {
        // Extended twisted Edwards unified addition (add-2008-hwcd-4)
        // a = -1 for Ed25519
        Span<ulong> a = stackalloc ulong[N];
        Span<ulong> b = stackalloc ulong[N];
        Span<ulong> c = stackalloc ulong[N];
        Span<ulong> dd = stackalloc ulong[N];
        Span<ulong> e = stackalloc ulong[N];
        Span<ulong> f = stackalloc ulong[N];
        Span<ulong> g = stackalloc ulong[N];
        Span<ulong> h = stackalloc ulong[N];

        Span<ulong> d2Mont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(D2Coeff, d2Mont);

        // A = (Y1-X1)·(Y2-X2)
        Span<ulong> t0 = stackalloc ulong[N];
        Span<ulong> t1r = stackalloc ulong[N];
        FieldCtx.ModSub(y1, x1, t0);
        FieldCtx.ModSub(y2, x2, t1r);
        FieldCtx.MontMul(t0, t1r, a);

        // B = (Y1+X1)·(Y2+X2)
        FieldCtx.ModAdd(y1, x1, t0);
        FieldCtx.ModAdd(y2, x2, t1r);
        FieldCtx.MontMul(t0, t1r, b);

        // C = T1·2d·T2
        FieldCtx.MontMul(t1, d2Mont, t0);
        FieldCtx.MontMul(t0, t2, c);

        // D = Z1·2·Z2
        FieldCtx.MontMul(z1, z2, t0);
        FieldCtx.ModAdd(t0, t0, dd);

        // E = B - A
        FieldCtx.ModSub(b, a, e);

        // F = D - C
        FieldCtx.ModSub(dd, c, f);

        // G = D + C
        FieldCtx.ModAdd(dd, c, g);

        // H = B + A
        FieldCtx.ModAdd(b, a, h);

        // X3 = E·F, Y3 = G·H, T3 = E·H, Z3 = F·G
        FieldCtx.MontMul(e, f, x3);
        FieldCtx.MontMul(g, h, y3);
        FieldCtx.MontMul(e, h, t3);
        FieldCtx.MontMul(f, g, z3);
    }

    /// <summary>
    /// Point doubling on extended twisted Edwards coordinates.
    /// </summary>
    private static void PointDouble(
        ReadOnlySpan<ulong> x1, ReadOnlySpan<ulong> y1, ReadOnlySpan<ulong> z1, ReadOnlySpan<ulong> t1,
        Span<ulong> x3, Span<ulong> y3, Span<ulong> z3, Span<ulong> t3)
    {
        // Extended twisted Edwards doubling (dbl-2008-hwcd)
        // a = -1 for Ed25519
        Span<ulong> a = stackalloc ulong[N];
        Span<ulong> b = stackalloc ulong[N];
        Span<ulong> c = stackalloc ulong[N];
        Span<ulong> dd = stackalloc ulong[N];
        Span<ulong> e = stackalloc ulong[N];
        Span<ulong> g = stackalloc ulong[N];
        Span<ulong> f = stackalloc ulong[N];
        Span<ulong> h = stackalloc ulong[N];
        Span<ulong> t0 = stackalloc ulong[N];

        // A = X1²
        FieldCtx.MontSquare(x1, a);

        // B = Y1²
        FieldCtx.MontSquare(y1, b);

        // C = 2·Z1²
        FieldCtx.MontSquare(z1, t0);
        FieldCtx.ModAdd(t0, t0, c);

        // D = a·A = -A (since a = -1)
        Span<ulong> zero = stackalloc ulong[N];
        zero.Clear();
        Span<ulong> zeroMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(zero, zeroMont);
        FieldCtx.ModSub(zeroMont, a, dd);

        // E = (X1+Y1)² - A - B
        FieldCtx.ModAdd(x1, y1, t0);
        FieldCtx.MontSquare(t0, e);
        FieldCtx.ModSub(e, a, e);
        FieldCtx.ModSub(e, b, e);

        // G = D + B
        FieldCtx.ModAdd(dd, b, g);

        // F = G - C
        FieldCtx.ModSub(g, c, f);

        // H = D - B
        FieldCtx.ModSub(dd, b, h);

        // X3 = E·F, Y3 = G·H, T3 = E·H, Z3 = F·G
        FieldCtx.MontMul(e, f, x3);
        FieldCtx.MontMul(g, h, y3);
        FieldCtx.MontMul(e, h, t3);
        FieldCtx.MontMul(f, g, z3);
    }

    /// <summary>
    /// Negates a point in extended coordinates: -(X,Y,Z,T) = (-X,Y,Z,-T).
    /// </summary>
    private static void NegatePoint(Span<ulong> x, Span<ulong> t)
    {
        Span<ulong> negX = stackalloc ulong[N];
        Span<ulong> negT = stackalloc ulong[N];
        Span<ulong> zero = stackalloc ulong[N];
        zero.Clear();
        Span<ulong> zeroMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(zero, zeroMont);

        FieldCtx.ModSub(zeroMont, x, negX);
        FieldCtx.ModSub(zeroMont, t, negT);
        negX.CopyTo(x);
        negT.CopyTo(t);
    }

    // ========================================================================
    // Scalar Multiplication (constant-time double-and-add)
    // ========================================================================

    /// <summary>
    /// Computes [k]B where B is the Ed25519 base point. Returns extended coordinates in Montgomery form.
    /// </summary>
    private static void ScalarMulBase(
        ReadOnlySpan<ulong> k,
        Span<ulong> rx, Span<ulong> ry, Span<ulong> rz, Span<ulong> rt)
    {
        // Convert base point to Montgomery form
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
        // Identity = (0, 1, 1, 0) in extended coordinates
        Span<ulong> oneMont = stackalloc ulong[N];
        Span<ulong> oneNorm = stackalloc ulong[N];
        oneNorm.Clear();
        oneNorm[0] = 1;
        FieldCtx.ToMontgomery(oneNorm, oneMont);

        Span<ulong> zeroMont = stackalloc ulong[N];
        Span<ulong> zeroNorm = stackalloc ulong[N];
        zeroNorm.Clear();
        FieldCtx.ToMontgomery(zeroNorm, zeroMont);

        // acc = identity (0, 1, 1, 0) in Montgomery form
        zeroMont.CopyTo(rx);
        oneMont.CopyTo(ry);
        oneMont.CopyTo(rz);
        zeroMont.CopyTo(rt);

        // P in extended: (px, py, 1, px·py)
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
        if (totalBits == 0) return; // identity

        for (int i = totalBits - 1; i >= 0; i--)
        {
            // Double
            PointDouble(rx, ry, rz, rt, tmpX, tmpY, tmpZ, tmpT);
            tmpX.CopyTo(rx);
            tmpY.CopyTo(ry);
            tmpZ.CopyTo(rz);
            tmpT.CopyTo(rt);

            // Add P (always computed)
            PointAdd(rx, ry, rz, rt, ppx, ppy, ppz, ppt, tmpX, tmpY, tmpZ, tmpT);

            // Conditionally use addition result
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
    /// Encodes a point in extended Montgomery form to 32 bytes (RFC 8032 §5.1.2).
    /// y coordinate with sign of x in the high bit.
    /// </summary>
    private static void EncodePoint(
        ReadOnlySpan<ulong> yMont, ReadOnlySpan<ulong> xMont, ReadOnlySpan<ulong> zMont,
        Span<byte> encoded)
    {
        // Convert to affine: x = X/Z, y = Y/Z
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

        // Encode y in little-endian, set high bit to sign of x (bit 0 of x)
        X25519.ToLittleEndianBytes(yNorm, encoded[..32]);
        encoded[31] |= (byte)((xNorm[0] & 1) << 7);
    }

    /// <summary>
    /// Decodes a compressed point (32 bytes) to affine coordinates in Montgomery form.
    /// </summary>
    /// <returns><c>true</c> if the point is valid.</returns>
    private static bool DecodePoint(ReadOnlySpan<byte> encoded, Span<ulong> xMont, Span<ulong> yMont)
    {
        // Extract sign bit of x
        int xSign = (encoded[31] >> 7) & 1;

        // Decode y
        Span<byte> yBytes = stackalloc byte[32];
        encoded[..32].CopyTo(yBytes);
        yBytes[31] &= 127; // clear sign bit

        Span<ulong> yNorm = stackalloc ulong[N];
        X25519.FromLittleEndianBytes(yBytes, yNorm);

        // Check y < p
        if (BigUInt.Compare(yNorm, PField) >= 0)
            return false;

        // Compute x² = (y² − 1) / (d·y² + 1) mod p
        Span<ulong> yMontLocal = stackalloc ulong[N];
        FieldCtx.ToMontgomery(yNorm, yMontLocal);

        Span<ulong> y2 = stackalloc ulong[N];
        FieldCtx.MontSquare(yMontLocal, y2);

        Span<ulong> oneMont = stackalloc ulong[N];
        Span<ulong> oneNorm = stackalloc ulong[N];
        oneNorm.Clear();
        oneNorm[0] = 1;
        FieldCtx.ToMontgomery(oneNorm, oneMont);

        // numerator = y² − 1
        Span<ulong> num = stackalloc ulong[N];
        FieldCtx.ModSub(y2, oneMont, num);

        // denominator = d·y² + 1
        Span<ulong> dMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(DCoeff, dMont);
        Span<ulong> dy2 = stackalloc ulong[N];
        FieldCtx.MontMul(dMont, y2, dy2);
        Span<ulong> den = stackalloc ulong[N];
        FieldCtx.ModAdd(dy2, oneMont, den);

        // Compute den⁻¹ mod p
        Span<ulong> denNorm = stackalloc ulong[N];
        FieldCtx.FromMontgomery(den, denNorm);

        Span<ulong> pMinus2 = stackalloc ulong[N];
        BigUInt.SubWord(PField, 2, pMinus2);
        Span<ulong> denInv = stackalloc ulong[N];
        FieldCtx.ModExp(denNorm, pMinus2, denInv);
        Span<ulong> denInvMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(denInv, denInvMont);

        // u = num · den⁻¹ (this is x² in Montgomery form)
        Span<ulong> uVal = stackalloc ulong[N];
        FieldCtx.MontMul(num, denInvMont, uVal);

        // Square root: x = u^((p+3)/8) mod p
        // (p+3)/8 = (2²⁵⁵ - 19 + 3) / 8 = (2²⁵⁵ - 16) / 8 = 2²⁵² - 2
        Span<ulong> uNorm = stackalloc ulong[N];
        FieldCtx.FromMontgomery(uVal, uNorm);

        Span<ulong> exp = stackalloc ulong[N];
        exp[0] = 0xFFFFFFFFFFFFFFFEUL;
        exp[1] = 0xFFFFFFFFFFFFFFFFUL;
        exp[2] = 0xFFFFFFFFFFFFFFFFUL;
        exp[3] = 0x0FFFFFFFFFFFFFFFUL;

        Span<ulong> candidate = stackalloc ulong[N];
        FieldCtx.ModExp(uNorm, exp, candidate);

        // Check: candidate² == u
        Span<ulong> candidateMont = stackalloc ulong[N];
        FieldCtx.ToMontgomery(candidate, candidateMont);
        Span<ulong> check = stackalloc ulong[N];
        FieldCtx.MontSquare(candidateMont, check);

        Span<ulong> checkNorm = stackalloc ulong[N];
        FieldCtx.FromMontgomery(check, checkNorm);

        if (!BigUInt.ConstantTimeEqual(checkNorm, uNorm))
        {
            // Try candidate * sqrt(-1) where sqrt(-1) = 2^((p-1)/4) mod p
            Span<ulong> sqrtM1Exp = stackalloc ulong[N];
            sqrtM1Exp[0] = 0xFFFFFFFFFFFFFFFBUL;
            sqrtM1Exp[1] = 0xFFFFFFFFFFFFFFFFUL;
            sqrtM1Exp[2] = 0xFFFFFFFFFFFFFFFFUL;
            sqrtM1Exp[3] = 0x1FFFFFFFFFFFFFFFUL;

            Span<ulong> twoNorm = stackalloc ulong[N];
            twoNorm.Clear();
            twoNorm[0] = 2;
            Span<ulong> sqrtM1 = stackalloc ulong[N];
            FieldCtx.ModExp(twoNorm, sqrtM1Exp, sqrtM1);

            Span<ulong> sqrtM1Mont = stackalloc ulong[N];
            FieldCtx.ToMontgomery(sqrtM1, sqrtM1Mont);
            Span<ulong> candidate2Mont = stackalloc ulong[N];
            FieldCtx.MontMul(candidateMont, sqrtM1Mont, candidate2Mont);

            // Verify this new candidate
            FieldCtx.MontSquare(candidate2Mont, check);
            FieldCtx.FromMontgomery(check, checkNorm);

            if (!BigUInt.ConstantTimeEqual(checkNorm, uNorm))
                return false;

            // Use the corrected candidate
            FieldCtx.FromMontgomery(candidate2Mont, candidate);
            candidate2Mont.CopyTo(candidateMont);
        }

        // Fix sign: if candidate[0] & 1 != xSign, negate
        if (((int)candidate[0] & 1) != xSign)
        {
            // negate: candidate = p - candidate
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
    /// Reduces a 64-byte hash to a scalar mod L (group order).
    /// </summary>
    private static void ReduceModL(ReadOnlySpan<byte> hash64, Span<ulong> result)
    {
        // Convert 64 little-endian bytes to 8 limbs
        Span<ulong> wide = stackalloc ulong[8];
        X25519.FromLittleEndianBytes(hash64[..64], wide);

        // Barrett-like reduction: compute wide mod L
        // For simplicity, use repeated subtraction approach with BigInteger-like division
        // Since we only do this a few times per sign/verify, perf is not critical
        ReduceWideMod(wide, LOrder, result);
    }

    /// <summary>
    /// Reduces a wide value (up to 8 limbs) mod a 4-limb modulus.
    /// Uses schoolbook bit-by-bit reduction.
    /// </summary>
    private static void ReduceWideMod(ReadOnlySpan<ulong> wide, ReadOnlySpan<ulong> modulus, Span<ulong> result)
    {
        int wideLimbs = wide.Length;
        int modLimbs = modulus.Length;

        // Work with a copy
        Span<ulong> rem = stackalloc ulong[wideLimbs];
        wide.CopyTo(rem);

        // Find the highest bit in wide
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
        Span<ulong> shifted = stackalloc ulong[wideLimbs];
        Span<ulong> temp = stackalloc ulong[wideLimbs];

        // Shift modulus left to align with the top of wide, then shift-subtract
        for (int shift = wideBits - modBits; shift >= 0; shift--)
        {
            // Check if rem >= (modulus << shift) by trial subtraction
            shifted.Clear();

            // Shift modulus left by 'shift' bits
            int limbShift = shift / 64;
            int bitShift = shift % 64;

            for (int j = 0; j < modLimbs && (j + limbShift) < wideLimbs; j++)
            {
                shifted[j + limbShift] |= modulus[j] << bitShift;
                if (bitShift > 0 && (j + limbShift + 1) < wideLimbs)
                    shifted[j + limbShift + 1] |= modulus[j] >> (64 - bitShift);
            }

            // Try subtraction
            ulong borrow = 0;
            for (int j = 0; j < wideLimbs; j++)
            {
                ulong diff = rem[j] - shifted[j] - borrow;
                borrow = ((~rem[j] & shifted[j]) | (~(rem[j] ^ shifted[j]) & diff)) >> 63;
                temp[j] = diff;
            }

            // If no borrow, use the subtracted result
            if (borrow == 0)
            {
                temp.CopyTo(rem);
            }
        }

        // Copy result (first modLimbs limbs)
        rem[..modLimbs].CopyTo(result);
    }

    /// <summary>
    /// Computes S = (r + k·s) mod L for the signature.
    /// </summary>
    private static void ComputeS(
        ReadOnlySpan<ulong> r, ReadOnlySpan<ulong> k, ReadOnlySpan<ulong> s, Span<byte> sEncoded)
    {
        // k·s: both are < L (< 2²⁵³), product fits in 8 limbs
        Span<ulong> ks = stackalloc ulong[8];
        ks.Clear();

        // Schoolbook multiplication
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
            if (pos < 8)
            {
                ulong sum = ks[pos] + carry;
                ulong c = sum < carry ? 1UL : 0UL;
                ks[pos] = sum;
                carryHi += c;
                if (carryHi != 0 && pos + 1 < 8)
                    ks[pos + 1] += carryHi;
            }
        }

        // Add r: ks += r
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

        for (int i = N; i < 8 && addCarry != 0; i++)
        {
            ulong sum = ks[i] + addCarry;
            addCarry = sum < addCarry ? 1UL : 0UL;
            ks[i] = sum;
        }

        // Reduce mod L
        Span<ulong> result = stackalloc ulong[N];
        ReduceWideMod(ks, LOrder, result);

        X25519.ToLittleEndianBytes(result, sEncoded[..32]);
    }

    /// <summary>
    /// Clamps a 32-byte scalar per Ed25519 rules (RFC 8032 §5.1.5).
    /// </summary>
    private static void ClampScalar(Span<byte> scalar)
    {
        scalar[0] &= 248;
        scalar[31] &= 127;
        scalar[31] |= 64;
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

