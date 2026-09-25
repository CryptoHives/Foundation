// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

/// <summary>
/// Provides low-level RSA operations: raw modular exponentiation with CRT optimization and blinding.
/// </summary>
/// <remarks>
/// <para>
/// This class implements the "textbook" RSA primitive I2OSP/OS2IP and the raw RSAEP/RSADP
/// operations from RFC 8017 §5.1. Padding schemes (PKCS#1, OAEP, PSS) are built on top.
/// </para>
/// <para>
/// Private-key operations use Chinese Remainder Theorem (CRT) for ~4× speedup and
/// RSA blinding to prevent timing side-channel attacks on the private exponent.
/// </para>
/// </remarks>
internal static class RsaCore
{
    /// <summary>
    /// Performs RSA public-key operation: result = message^e mod n.
    /// </summary>
    /// <param name="message">The message as big-endian bytes (must be less than n).</param>
    /// <param name="key">The RSA key parameters (public exponent and modulus required).</param>
    /// <returns>The result as a big-endian byte array of length equal to the modulus.</returns>
    /// <exception cref="ArgumentException">Thrown if the message is not less than the modulus.</exception>
    public static byte[] PublicOp(ReadOnlySpan<byte> message, RsaKeyParameters key)
    {
        int nLen = key.Modulus.Length;
        int limbCount = (nLen + 7) / 8;

        Span<ulong> n = stackalloc ulong[limbCount];
        Span<ulong> m = stackalloc ulong[limbCount];
        Span<ulong> e = stackalloc ulong[(key.PublicExponent.Length + 7) / 8];
        Span<ulong> result = stackalloc ulong[limbCount];

        BigUInt.FromBigEndianBytes(key.Modulus, n);
        BigUInt.FromBigEndianBytes(PadLeft(message, nLen), m);
        BigUInt.FromBigEndianBytes(key.PublicExponent, e);

        // Verify message < modulus
        if (BigUInt.Compare(m, n) >= 0)
            throw new ArgumentException("Message representative out of range.", nameof(message));

        var ctx = new MontgomeryContext(n);
        ctx.ModExp(m, e, result);

        byte[] output = new byte[nLen];
        BigUInt.ToBigEndianBytes(result, output);
        return output;
    }

    /// <summary>
    /// Performs RSA private-key operation with CRT and blinding: result = ciphertext^d mod n.
    /// </summary>
    /// <param name="ciphertext">The ciphertext as big-endian bytes (must be less than n).</param>
    /// <param name="key">The RSA key parameters (full private key with CRT parameters required).</param>
    /// <returns>The result as a big-endian byte array of length equal to the modulus.</returns>
    /// <exception cref="ArgumentException">Thrown if the key does not contain private components.</exception>
    /// <exception cref="ArgumentException">Thrown if the ciphertext is not less than the modulus.</exception>
    public static byte[] PrivateOp(ReadOnlySpan<byte> ciphertext, RsaKeyParameters key)
    {
        if (!key.HasPrivateKey)
            throw new ArgumentException("Private key components required.", nameof(key));

        int nLen = key.Modulus.Length;
        int nLimbs = (nLen + 7) / 8;

        Span<ulong> n = stackalloc ulong[nLimbs];
        Span<ulong> c = stackalloc ulong[nLimbs];
        Span<ulong> e = stackalloc ulong[(key.PublicExponent.Length + 7) / 8];

        BigUInt.FromBigEndianBytes(key.Modulus, n);
        BigUInt.FromBigEndianBytes(PadLeft(ciphertext, nLen), c);
        BigUInt.FromBigEndianBytes(key.PublicExponent, e);

        if (BigUInt.Compare(c, n) >= 0)
            throw new ArgumentException("Ciphertext representative out of range.", nameof(ciphertext));

        // Apply RSA blinding: c' = c · r^e mod n
        Span<ulong> r = stackalloc ulong[nLimbs];
        Span<ulong> rInv = stackalloc ulong[nLimbs];
        GenerateBlindingFactor(n, e, r, rInv);

        var nCtx = new MontgomeryContext(n);

        // c' = c · r^e mod n (blinded input)
        Span<ulong> reBlind = stackalloc ulong[nLimbs];
        nCtx.ModExp(r, e, reBlind);

        Span<ulong> cBlind = stackalloc ulong[nLimbs];
        Span<ulong> cMont = stackalloc ulong[nLimbs];
        Span<ulong> reMont = stackalloc ulong[nLimbs];
        Span<ulong> cbMont = stackalloc ulong[nLimbs];

        nCtx.ToMontgomery(c, cMont);
        nCtx.ToMontgomery(reBlind, reMont);
        nCtx.MontMul(cMont, reMont, cbMont);
        nCtx.FromMontgomery(cbMont, cBlind);

        // CRT computation on blinded input
        Span<ulong> mBlind = stackalloc ulong[nLimbs];
        CrtPrivateOp(cBlind, key, nLimbs, mBlind);

        // Unblind: m = m' · r^(-1) mod n
        Span<ulong> result = stackalloc ulong[nLimbs];
        Span<ulong> mMont = stackalloc ulong[nLimbs];
        Span<ulong> rInvMont = stackalloc ulong[nLimbs];
        Span<ulong> resMont = stackalloc ulong[nLimbs];

        nCtx.ToMontgomery(mBlind, mMont);
        nCtx.ToMontgomery(rInv, rInvMont);
        nCtx.MontMul(mMont, rInvMont, resMont);
        nCtx.FromMontgomery(resMont, result);

        byte[] output = new byte[nLen];
        BigUInt.ToBigEndianBytes(result, output);
        return output;
    }

    /// <summary>
    /// Performs RSA private-key operation using CRT without blinding. For internal use by <see cref="PrivateOp"/>.
    /// </summary>
    private static void CrtPrivateOp(
        ReadOnlySpan<ulong> c,
        RsaKeyParameters key,
        int nLimbs,
        Span<ulong> result)
    {
        int pLen = key.P!.Length;
        int qLen = key.Q!.Length;
        int pLimbs = (pLen + 7) / 8;
        int qLimbs = (qLen + 7) / 8;

        Span<ulong> p = stackalloc ulong[pLimbs];
        Span<ulong> q = stackalloc ulong[qLimbs];
        Span<ulong> dp = stackalloc ulong[pLimbs];
        Span<ulong> dq = stackalloc ulong[qLimbs];
        Span<ulong> qInv = stackalloc ulong[pLimbs];

        BigUInt.FromBigEndianBytes(key.P, p);
        BigUInt.FromBigEndianBytes(key.Q, q);
        BigUInt.FromBigEndianBytes(PadLeft(key.Dp!, pLen), dp);
        BigUInt.FromBigEndianBytes(PadLeft(key.Dq!, qLen), dq);
        BigUInt.FromBigEndianBytes(PadLeft(key.QInv!, pLen), qInv);

        // m1 = c^dp mod p
        Span<ulong> cModP = stackalloc ulong[pLimbs];
        ModReduce(c, p, cModP);
        var pCtx = new MontgomeryContext(p);
        Span<ulong> m1 = stackalloc ulong[pLimbs];
        pCtx.ModExp(cModP, dp, m1);

        // m2 = c^dq mod q
        Span<ulong> cModQ = stackalloc ulong[qLimbs];
        ModReduce(c, q, cModQ);
        var qCtx = new MontgomeryContext(q);
        Span<ulong> m2 = stackalloc ulong[qLimbs];
        qCtx.ModExp(cModQ, dq, m2);

        // h = qInv · (m1 - m2) mod p
        Span<ulong> m2InP = stackalloc ulong[pLimbs];
        ModReduce(m2, p, m2InP);

        Span<ulong> diff = stackalloc ulong[pLimbs];
        pCtx.ModSub(m1, m2InP, diff);

        // h = qInv * diff mod p (using Montgomery)
        Span<ulong> h = stackalloc ulong[pLimbs];
        Span<ulong> diffMont = stackalloc ulong[pLimbs];
        Span<ulong> qInvMont = stackalloc ulong[pLimbs];
        Span<ulong> hMont = stackalloc ulong[pLimbs];

        pCtx.ToMontgomery(diff, diffMont);
        pCtx.ToMontgomery(qInv, qInvMont);
        pCtx.MontMul(diffMont, qInvMont, hMont);
        pCtx.FromMontgomery(hMont, h);

        // m = m2 + h · q
        // h · q can be nLimbs long
        Span<ulong> hq = stackalloc ulong[pLimbs + qLimbs];
        BigUInt.Mul(h, q, hq);

        // Extend m2 to nLimbs
        Span<ulong> m2Wide = stackalloc ulong[nLimbs];
        m2Wide.Clear();
        m2[..qLimbs].CopyTo(m2Wide);

        // Extend hq to nLimbs and add
        result.Clear();
        int hqCopy = Math.Min(hq.Length, nLimbs);
        hq[..hqCopy].CopyTo(result);
        BigUInt.Add(result, m2Wide, result);
    }

    /// <summary>
    /// Reduces a value modulo m using bit-by-bit long division.
    /// </summary>
    private static void ModReduce(ReadOnlySpan<ulong> value, ReadOnlySpan<ulong> modulus, Span<ulong> result)
    {
        int mLen = modulus.Length;

        // If value fits in modulus and is less, just copy
        if (value.Length <= mLen)
        {
            result.Clear();
            value.CopyTo(result);

            // May still need reduction if value >= modulus
            Span<ulong> temp = stackalloc ulong[mLen];
            ulong borrow = BigUInt.Sub(result, modulus, temp);

            // If no borrow (result >= modulus), use the subtracted value
            BigUInt.ConditionalCopy(1 - borrow, result, temp);
            return;
        }

        // Reduce via shift-and-subtract (like long division)
        Span<ulong> acc = stackalloc ulong[mLen + 1];
        acc.Clear();

        int valueBits = BigUInt.BitLength(value);

        for (int i = valueBits - 1; i >= 0; i--)
        {
            // Shift acc left by 1
            for (int j = mLen; j > 0; j--)
            {
                acc[j] = (acc[j] << 1) | (acc[j - 1] >> 63);
            }

            acc[0] <<= 1;

            // Bring in the next bit from value
            int limbIdx = i / 64;
            int bitIdx = i % 64;
            acc[0] |= (value[limbIdx] >> bitIdx) & 1;

            // If acc >= m, subtract m
            bool overflow = acc[mLen] != 0;
            int cmp = overflow ? 1 : BigUInt.Compare(acc[..mLen], modulus);

            if (cmp >= 0)
            {
                BigUInt.Sub(acc[..mLen], modulus, acc[..mLen]);
                acc[mLen] = 0;
            }
        }

        acc[..mLen].CopyTo(result);
    }

    /// <summary>
    /// Generates a random blinding factor r and its modular inverse r⁻¹ mod n.
    /// </summary>
    private static void GenerateBlindingFactor(
        ReadOnlySpan<ulong> n,
        ReadOnlySpan<ulong> e,
        Span<ulong> r,
        Span<ulong> rInv)
    {
        int nLimbs = n.Length;
        int nBytes = nLimbs * 8;

        // Generate random r < n
        byte[] rBytes = new byte[nBytes];
        using var rng = RandomNumberGenerator.Create();

        // Keep trying until we get a valid r that is coprime with n
        // (overwhelming probability for typical RSA moduli)
        Span<ulong> rTemp = stackalloc ulong[nLimbs];
        do
        {
            rng.GetBytes(rBytes);
            BigUInt.FromBigEndianBytes(rBytes, rTemp);

            // Ensure r < n by clearing top bits
            int nBits = BigUInt.BitLength(n);
            int topLimb = nLimbs - 1;
            int bitsInTopLimb = ((nBits - 1) % 64) + 1;
            if (bitsInTopLimb < 64)
                rTemp[topLimb] &= (1UL << bitsInTopLimb) - 1;
        }
        while (BigUInt.Compare(rTemp, n) >= 0 || BigUInt.IsZero(rTemp));

        rTemp.CopyTo(r);

        // r⁻¹ = r^(φ(n)-1) mod n, but we don't have φ(n) easily
        // Instead, use r⁻¹ = r^(n-2) mod n (works when n is product of two primes and gcd(r,n)=1)
        // Actually for blinding we only need: if m' = (c · r^e)^d mod n = m · r mod n,
        // then m = m' · r^(-1) mod n. We compute r^(-1) via extended GCD.
        // For simplicity and since this is not constant-time-critical (r is random),
        // we use Fermat/Euler approach: r^(-1) mod n
        // Since n = p·q, Euler totient φ(n) = (p-1)(q-1), and r^φ(n) ≡ 1 mod n
        // But we don't have p,q here in this function. Use extended Euclidean algorithm.
        ModInverse(r, n, rInv);
    }

    /// <summary>
    /// Computes the modular inverse a⁻¹ mod m using the extended Euclidean algorithm.
    /// </summary>
    /// <remarks>
    /// This is not constant-time, but is only used for the random blinding factor
    /// which does not leak information about the private key.
    /// </remarks>
    private static void ModInverse(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> m, Span<ulong> result)
    {
        int n = m.Length;

        // Extended Euclidean Algorithm using BigInteger for simplicity
        // (the blinding factor is random, so this is not a side-channel concern)
        System.Numerics.BigInteger aBig = SpanToBigInteger(a);
        System.Numerics.BigInteger mBig = SpanToBigInteger(m);

        // Extended Euclidean: find x such that a·x ≡ 1 (mod m)
        System.Numerics.BigInteger x = ModInverseBigInt(aBig, mBig);

        // Convert back to limbs
        BigIntegerToSpan(x, result);
    }

    private static System.Numerics.BigInteger ModInverseBigInt(
        System.Numerics.BigInteger a,
        System.Numerics.BigInteger m)
    {
        var (g, x, _) = ExtendedGcd(a, m);
        if (g != 1)
            throw new InvalidOperationException("Modular inverse does not exist.");

        return ((x % m) + m) % m;
    }

    private static (System.Numerics.BigInteger g, System.Numerics.BigInteger x, System.Numerics.BigInteger y)
        ExtendedGcd(System.Numerics.BigInteger a, System.Numerics.BigInteger b)
    {
        if (a == 0)
            return (b, 0, 1);

        var (g, x, y) = ExtendedGcd(b % a, a);
        return (g, y - (b / a) * x, x);
    }

    private static System.Numerics.BigInteger SpanToBigInteger(ReadOnlySpan<ulong> limbs)
    {
        System.Numerics.BigInteger result = 0;
        for (int i = limbs.Length - 1; i >= 0; i--)
        {
            result = (result << 64) | limbs[i];
        }

        return result;
    }

    private static void BigIntegerToSpan(System.Numerics.BigInteger value, Span<ulong> result)
    {
        result.Clear();
        for (int i = 0; i < result.Length && value > 0; i++)
        {
            result[i] = (ulong)(value & ulong.MaxValue);
            value >>= 64;
        }
    }

    /// <summary>
    /// Left-pads a byte span to the specified length.
    /// </summary>
    private static byte[] PadLeft(ReadOnlySpan<byte> data, int length)
    {
        if (data.Length >= length)
        {
            return data[..length].ToArray();
        }

        byte[] padded = new byte[length];
        data.CopyTo(padded.AsSpan(length - data.Length));
        return padded;
    }
}

