// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// Provides ECDSA signature generation and verification using RFC 6979 deterministic k.
/// </summary>
internal static class EcDsaCore
{
    /// <summary>
    /// Signs a hash using ECDSA with deterministic k (RFC 6979).
    /// </summary>
    /// <param name="hash">The hash to sign.</param>
    /// <param name="privateKey">The private key d (big-endian).</param>
    /// <param name="curve">The elliptic curve.</param>
    /// <param name="hashAlgorithm">The hash algorithm used to produce <paramref name="hash"/>.</param>
    /// <returns>The signature (r, s) as big-endian byte arrays.</returns>
    public static (byte[] r, byte[] s) Sign(
        ReadOnlySpan<byte> hash,
        ReadOnlySpan<byte> privateKey,
        WeierstrassCurve curve,
        HashAlgorithmName hashAlgorithm)
    {
        var ec = new EcMath(curve);
        int n = curve.LimbCount;
        int fs = curve.FieldSize;

        Span<ulong> order = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(curve.N, order);

        Span<ulong> d = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(privateKey, d);

        // Truncate hash to curve order bit length
        byte[] truncHash = TruncateHash(hash, curve);

        Span<ulong> z = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(truncHash, z);

        // Generate deterministic k using RFC 6979
        byte[] kBytes = Rfc6979K(privateKey, truncHash, curve, hashAlgorithm);
        Span<ulong> k = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(kBytes, k);

        // Compute R = k·G
        byte[] rxBytes = new byte[fs];
        byte[] ryBytes = new byte[fs];
        ec.ScalarMulBase(k, rxBytes, ryBytes);

        // r = Rx mod n
        Span<ulong> rxLimbs = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(rxBytes, rxLimbs);

        // Reduce r mod n if needed
        Span<ulong> r = stackalloc ulong[n];
        rxLimbs.CopyTo(r);
        Span<ulong> temp = stackalloc ulong[n];
        ulong borrow = BigUInt.Sub(r, order, temp);
        BigUInt.ConditionalCopy(1 - borrow, r, temp);

        // s = k⁻¹ · (z + r·d) mod n
        var nCtx = new MontgomeryContext(order);

        Span<ulong> rd = stackalloc ulong[n];
        Span<ulong> rMont = stackalloc ulong[n];
        Span<ulong> dMont = stackalloc ulong[n];
        Span<ulong> rdMont = stackalloc ulong[n];

        nCtx.ToMontgomery(r, rMont);
        nCtx.ToMontgomery(d, dMont);
        nCtx.MontMul(rMont, dMont, rdMont);
        nCtx.FromMontgomery(rdMont, rd);

        // z + r·d mod n
        Span<ulong> zrd = stackalloc ulong[n];
        nCtx.ModAdd(z, rd, zrd);

        // k⁻¹ mod n via Fermat: k^(n-2) mod n
        Span<ulong> nMinus2 = stackalloc ulong[n];
        BigUInt.SubWord(order, 2, nMinus2);

        Span<ulong> kInv = stackalloc ulong[n];
        nCtx.ModExp(k, nMinus2, kInv);

        // s = k⁻¹ · (z + r·d) mod n
        Span<ulong> s = stackalloc ulong[n];
        Span<ulong> kInvMont = stackalloc ulong[n];
        Span<ulong> zrdMont = stackalloc ulong[n];
        Span<ulong> sMont = stackalloc ulong[n];

        nCtx.ToMontgomery(kInv, kInvMont);
        nCtx.ToMontgomery(zrd, zrdMont);
        nCtx.MontMul(kInvMont, zrdMont, sMont);
        nCtx.FromMontgomery(sMont, s);

        byte[] rResult = new byte[fs];
        byte[] sResult = new byte[fs];
        BigUInt.ToBigEndianBytes(r, rResult);
        BigUInt.ToBigEndianBytes(s, sResult);

        return (rResult, sResult);
    }

    /// <summary>
    /// Verifies an ECDSA signature.
    /// </summary>
    /// <param name="hash">The hash that was signed.</param>
    /// <param name="r">The r component of the signature (big-endian).</param>
    /// <param name="s">The s component of the signature (big-endian).</param>
    /// <param name="publicKeyX">The public key X coordinate (big-endian).</param>
    /// <param name="publicKeyY">The public key Y coordinate (big-endian).</param>
    /// <param name="curve">The elliptic curve.</param>
    /// <returns><c>true</c> if the signature is valid.</returns>
    public static bool Verify(
        ReadOnlySpan<byte> hash,
        ReadOnlySpan<byte> r,
        ReadOnlySpan<byte> s,
        ReadOnlySpan<byte> publicKeyX,
        ReadOnlySpan<byte> publicKeyY,
        WeierstrassCurve curve)
    {
        var ec = new EcMath(curve);
        int n = curve.LimbCount;
        int fs = curve.FieldSize;

        Span<ulong> order = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(curve.N, order);

        Span<ulong> rLimbs = stackalloc ulong[n];
        Span<ulong> sLimbs = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(r, rLimbs);
        BigUInt.FromBigEndianBytes(s, sLimbs);

        // Check 1 <= r, s < n
        if (BigUInt.IsZero(rLimbs) || BigUInt.Compare(rLimbs, order) >= 0) return false;
        if (BigUInt.IsZero(sLimbs) || BigUInt.Compare(sLimbs, order) >= 0) return false;

        var nCtx = new MontgomeryContext(order);

        byte[] truncHash = TruncateHash(hash, curve);
        Span<ulong> z = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(truncHash, z);

        // w = s⁻¹ mod n
        Span<ulong> nMinus2 = stackalloc ulong[n];
        BigUInt.SubWord(order, 2, nMinus2);
        Span<ulong> w = stackalloc ulong[n];
        nCtx.ModExp(sLimbs, nMinus2, w);

        // u1 = z·w mod n
        Span<ulong> u1 = stackalloc ulong[n];
        Span<ulong> wMont = stackalloc ulong[n];
        Span<ulong> zMont = stackalloc ulong[n];
        Span<ulong> u1Mont = stackalloc ulong[n];
        nCtx.ToMontgomery(w, wMont);
        nCtx.ToMontgomery(z, zMont);
        nCtx.MontMul(zMont, wMont, u1Mont);
        nCtx.FromMontgomery(u1Mont, u1);

        // u2 = r·w mod n
        Span<ulong> u2 = stackalloc ulong[n];
        Span<ulong> rMont = stackalloc ulong[n];
        Span<ulong> u2Mont = stackalloc ulong[n];
        nCtx.ToMontgomery(rLimbs, rMont);
        nCtx.MontMul(rMont, wMont, u2Mont);
        nCtx.FromMontgomery(u2Mont, u2);

        // P = u1·G + u2·Q (Shamir's trick simplified: compute separately)
        // u1·G
        Span<ulong> gxMont = stackalloc ulong[n];
        Span<ulong> gyMont = stackalloc ulong[n];
        Span<ulong> gx = stackalloc ulong[n];
        Span<ulong> gy = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(curve.Gx, gx);
        BigUInt.FromBigEndianBytes(curve.Gy, gy);
        ec.Field.ToMontgomery(gx, gxMont);
        ec.Field.ToMontgomery(gy, gyMont);

        Span<ulong> p1x = stackalloc ulong[n];
        Span<ulong> p1y = stackalloc ulong[n];
        ec.ScalarMul(u1, gxMont, gyMont, p1x, p1y);

        // u2·Q
        Span<ulong> qxMont = stackalloc ulong[n];
        Span<ulong> qyMont = stackalloc ulong[n];
        Span<ulong> qxLimbs = stackalloc ulong[n];
        Span<ulong> qyLimbs = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(publicKeyX, qxLimbs);
        BigUInt.FromBigEndianBytes(publicKeyY, qyLimbs);
        ec.Field.ToMontgomery(qxLimbs, qxMont);
        ec.Field.ToMontgomery(qyLimbs, qyMont);

        Span<ulong> p2x = stackalloc ulong[n];
        Span<ulong> p2y = stackalloc ulong[n];
        ec.ScalarMul(u2, qxMont, qyMont, p2x, p2y);

        // Add the two points (both in Montgomery affine form)
        // Convert to Jacobian for addition
        Span<ulong> oneMont = stackalloc ulong[n];
        Span<ulong> oneVal = stackalloc ulong[n];
        oneVal.Clear();
        oneVal[0] = 1;
        ec.Field.ToMontgomery(oneVal, oneMont);

        Span<ulong> sumX = stackalloc ulong[n];
        Span<ulong> sumY = stackalloc ulong[n];
        Span<ulong> sumZ = stackalloc ulong[n];
        ec.PointAddMixed(p1x, p1y, oneMont, p2x, p2y, sumX, sumY, sumZ);

        // Convert result to affine
        Span<ulong> affX = stackalloc ulong[n];
        Span<ulong> affY = stackalloc ulong[n];

        // Get affine X by converting from Montgomery Jacobian
        Span<ulong> zNorm = stackalloc ulong[n];
        ec.Field.FromMontgomery(sumZ, zNorm);
        if (BigUInt.IsZero(zNorm)) return false; // point at infinity

        Span<ulong> pLimbs = stackalloc ulong[n];
        BigUInt.FromBigEndianBytes(curve.P, pLimbs);
        Span<ulong> pMinus2 = stackalloc ulong[n];
        BigUInt.SubWord(pLimbs, 2, pMinus2);

        Span<ulong> zInv = stackalloc ulong[n];
        ec.Field.ModExp(zNorm, pMinus2, zInv);
        Span<ulong> zInvMont = stackalloc ulong[n];
        ec.Field.ToMontgomery(zInv, zInvMont);
        Span<ulong> zInv2 = stackalloc ulong[n];
        ec.Field.MontSquare(zInvMont, zInv2);

        ec.Field.MontMul(sumX, zInv2, affX);
        ec.Field.FromMontgomery(affX, affX);

        // v = affX mod n
        Span<ulong> v = stackalloc ulong[n];
        affX.CopyTo(v);
        Span<ulong> vTemp = stackalloc ulong[n];
        ulong borrow = BigUInt.Sub(v, order, vTemp);
        BigUInt.ConditionalCopy(1 - borrow, v, vTemp);

        return BigUInt.ConstantTimeEqual(v, rLimbs);
    }

    // ========================================================================
    // RFC 6979 Deterministic K
    // ========================================================================

    /// <summary>
    /// Generates a deterministic nonce k per RFC 6979.
    /// </summary>
    private static byte[] Rfc6979K(
        ReadOnlySpan<byte> privateKey,
        ReadOnlySpan<byte> hash,
        WeierstrassCurve curve,
        HashAlgorithmName hashAlgorithm)
    {
        int qLen = curve.FieldSize;

        // Step a: h1 = hash (already provided)
        // Step b: V = 0x01 01 01 ... (qLen bytes)
        int hLen = GetHashLength(hashAlgorithm);
        byte[] v = new byte[hLen];
        v.AsSpan().Fill(0x01);

        // Step c: K = 0x00 00 00 ... (hLen bytes)
        byte[] kHmac = new byte[hLen];

        // Step d: K = HMAC_K(V || 0x00 || int2octets(x) || bits2octets(h1))
        byte[] payload = BuildRfc6979Payload(v, 0x00, privateKey, hash, qLen);
        kHmac = HmacCompute(hashAlgorithm, kHmac, payload);

        // Step e: V = HMAC_K(V)
        v = HmacCompute(hashAlgorithm, kHmac, v);

        // Step f: K = HMAC_K(V || 0x01 || int2octets(x) || bits2octets(h1))
        payload = BuildRfc6979Payload(v, 0x01, privateKey, hash, qLen);
        kHmac = HmacCompute(hashAlgorithm, kHmac, payload);

        // Step g: V = HMAC_K(V)
        v = HmacCompute(hashAlgorithm, kHmac, v);

        // Step h: Generate k
        int limbCount = curve.LimbCount;
        Span<ulong> order = stackalloc ulong[limbCount];
        BigUInt.FromBigEndianBytes(curve.N, order);
        int orderBits = BigUInt.BitLength(order);
        Span<ulong> kLimbs = stackalloc ulong[limbCount];

        while (true)
        {
            // Generate T
            byte[] t = Array.Empty<byte>();
            while (t.Length < qLen)
            {
                v = HmacCompute(hashAlgorithm, kHmac, v);
                byte[] newT = new byte[t.Length + v.Length];
                Buffer.BlockCopy(t, 0, newT, 0, t.Length);
                Buffer.BlockCopy(v, 0, newT, t.Length, v.Length);
                t = newT;
            }

            byte[] candidate = new byte[qLen];
            Buffer.BlockCopy(t, 0, candidate, 0, qLen);

            // Clear excess bits for curves where order bit length < qLen * 8
            int excessBits = qLen * 8 - orderBits;
            if (excessBits > 0)
            {
                candidate[0] &= (byte)(0xFF >> excessBits);
            }

            BigUInt.FromBigEndianBytes(candidate, kLimbs);

            // Check 1 <= k < n
            if (!BigUInt.IsZero(kLimbs) && BigUInt.Compare(kLimbs, order) < 0)
            {
                return candidate;
            }

            // K = HMAC_K(V || 0x00)
            byte[] vWith00 = new byte[v.Length + 1];
            Buffer.BlockCopy(v, 0, vWith00, 0, v.Length);
            kHmac = HmacCompute(hashAlgorithm, kHmac, vWith00);

            // V = HMAC_K(V)
            v = HmacCompute(hashAlgorithm, kHmac, v);
        }
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static byte[] TruncateHash(ReadOnlySpan<byte> hash, WeierstrassCurve curve)
    {
        int fs = curve.FieldSize;
        Span<ulong> order = stackalloc ulong[curve.LimbCount];
        BigUInt.FromBigEndianBytes(curve.N, order);
        int orderBits = BigUInt.BitLength(order);

        byte[] result;
        if (hash.Length > fs)
        {
            result = hash[..fs].ToArray();
        }
        else
        {
            result = new byte[fs];
            hash.CopyTo(result.AsSpan(fs - hash.Length));
        }

        // Clear excess bits
        int excessBits = fs * 8 - orderBits;
        if (excessBits > 0)
        {
            result[0] &= (byte)(0xFF >> excessBits);
        }

        return result;
    }

    private static byte[] BuildRfc6979Payload(
        byte[] v, byte separator, ReadOnlySpan<byte> privateKey, ReadOnlySpan<byte> hash, int qLen)
    {
        byte[] payload = new byte[v.Length + 1 + qLen + hash.Length];
        Buffer.BlockCopy(v, 0, payload, 0, v.Length);
        payload[v.Length] = separator;

        // int2octets(x): pad private key to qLen
        byte[] paddedKey = new byte[qLen];
        if (privateKey.Length <= qLen)
            privateKey.CopyTo(paddedKey.AsSpan(qLen - privateKey.Length));
        else
            privateKey[..qLen].CopyTo(paddedKey);

        Buffer.BlockCopy(paddedKey, 0, payload, v.Length + 1, qLen);
        hash.CopyTo(payload.AsSpan(v.Length + 1 + qLen));
        return payload;
    }

    private static byte[] HmacCompute(HashAlgorithmName hashAlgorithm, byte[] key, byte[] data) =>
        CryptoHelper.HmacCompute(hashAlgorithm, key, data);

    private static int GetHashLength(HashAlgorithmName hashAlgorithm) =>
        CryptoHelper.GetHashLength(hashAlgorithm);
}
