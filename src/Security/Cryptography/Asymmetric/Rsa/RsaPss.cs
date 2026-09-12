// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

using System;
using System.Security.Cryptography;

/// <summary>
/// Implements RSASSA-PSS signature scheme (RFC 8017 §8.1).
/// </summary>
/// <remarks>
/// PSS (Probabilistic Signature Scheme) provides a provably secure signature
/// scheme under the RSA assumption. It is preferred over PKCS#1 v1.5 for new applications.
/// </remarks>
internal static class RsaPss
{
    /// <summary>
    /// Signs a hash using RSASSA-PSS.
    /// </summary>
    /// <param name="hash">The hash value to sign.</param>
    /// <param name="hashAlgorithm">The hash algorithm that produced <paramref name="hash"/>.</param>
    /// <param name="key">The RSA private key.</param>
    /// <param name="saltLength">The salt length in bytes. Use -1 for hash length (default).</param>
    /// <returns>The PSS signature.</returns>
    public static byte[] Sign(
        ReadOnlySpan<byte> hash,
        HashAlgorithmName hashAlgorithm,
        RsaKeyParameters key,
        int saltLength = -1)
    {
        int k = key.Modulus.Length;
        int emBits = (k * 8) - 1; // modBits - 1
        int emLen = (emBits + 7) / 8;

        int hLen = GetHashLength(hashAlgorithm);
        if (saltLength < 0) saltLength = hLen;

        byte[] em = PssEncode(hash, emBits, hashAlgorithm, saltLength);
        return RsaCore.PrivateOp(em, key);
    }

    /// <summary>
    /// Verifies a RSASSA-PSS signature.
    /// </summary>
    /// <param name="hash">The expected hash value.</param>
    /// <param name="signature">The PSS signature to verify.</param>
    /// <param name="hashAlgorithm">The hash algorithm that produced <paramref name="hash"/>.</param>
    /// <param name="key">The RSA public key.</param>
    /// <param name="saltLength">The expected salt length in bytes. Use -1 for hash length (default).</param>
    /// <returns><c>true</c> if the signature is valid; otherwise, <c>false</c>.</returns>
    public static bool Verify(
        ReadOnlySpan<byte> hash,
        ReadOnlySpan<byte> signature,
        HashAlgorithmName hashAlgorithm,
        RsaKeyParameters key,
        int saltLength = -1)
    {
        int k = key.Modulus.Length;
        int emBits = (k * 8) - 1;
        int hLen = GetHashLength(hashAlgorithm);
        if (saltLength < 0) saltLength = hLen;

        byte[] em;
        try
        {
            em = RsaCore.PublicOp(signature, key);
        }
        catch
        {
            return false;
        }

        return PssVerify(hash, em, emBits, hashAlgorithm, saltLength);
    }

    /// <summary>
    /// EMSA-PSS-ENCODE (RFC 8017 §9.1.1).
    /// </summary>
    private static byte[] PssEncode(
        ReadOnlySpan<byte> mHash,
        int emBits,
        HashAlgorithmName hashAlgorithm,
        int sLen)
    {
        int hLen = GetHashLength(hashAlgorithm);
        int emLen = (emBits + 7) / 8;

        if (emLen < hLen + sLen + 2)
            throw new CryptographicException("Encoding error: intended encoded message length too short.");

        // Generate random salt
        byte[] salt = new byte[sLen];
        if (sLen > 0)
        {
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
        }

        // M' = (0x)00 00 00 00 00 00 00 00 || mHash || salt
        byte[] mPrime = new byte[8 + hLen + sLen];
        // First 8 bytes are already zero
        mHash.CopyTo(mPrime.AsSpan(8));
        salt.CopyTo(mPrime.AsSpan(8 + hLen));

        // H = Hash(M')
        byte[] h = HashData(hashAlgorithm, mPrime);

        // DB = PS || 0x01 || salt
        int dbLen = emLen - hLen - 1;
        byte[] db = new byte[dbLen];
        // PS is zero padding (already zeroed)
        db[dbLen - sLen - 1] = 0x01;
        salt.CopyTo(db.AsSpan(dbLen - sLen));

        // dbMask = MGF1(H, dbLen)
        byte[] dbMask = RsaOaep.Mgf1(h, dbLen, hashAlgorithm);

        // maskedDB = DB ⊕ dbMask
        byte[] maskedDb = new byte[dbLen];
        for (int i = 0; i < dbLen; i++)
        {
            maskedDb[i] = (byte)(db[i] ^ dbMask[i]);
        }

        // Set the leftmost 8*emLen - emBits bits to zero
        int zeroBits = 8 * emLen - emBits;
        if (zeroBits > 0)
        {
            maskedDb[0] &= (byte)(0xFF >> zeroBits);
        }

        // EM = maskedDB || H || 0xbc
        byte[] em = new byte[emLen];
        maskedDb.CopyTo(em.AsSpan());
        h.CopyTo(em.AsSpan(dbLen));
        em[emLen - 1] = 0xBC;

        return em;
    }

    /// <summary>
    /// EMSA-PSS-VERIFY (RFC 8017 §9.1.2).
    /// </summary>
    private static bool PssVerify(
        ReadOnlySpan<byte> mHash,
        byte[] em,
        int emBits,
        HashAlgorithmName hashAlgorithm,
        int sLen)
    {
        int hLen = GetHashLength(hashAlgorithm);
        int emLen = (emBits + 7) / 8;

        if (emLen < hLen + sLen + 2)
            return false;

        if (em[emLen - 1] != 0xBC)
            return false;

        int dbLen = emLen - hLen - 1;
        ReadOnlySpan<byte> maskedDb = em.AsSpan(0, dbLen);
        ReadOnlySpan<byte> h = em.AsSpan(dbLen, hLen);

        // Check leftmost bits are zero
        int zeroBits = 8 * emLen - emBits;
        if (zeroBits > 0 && (maskedDb[0] & (0xFF << (8 - zeroBits))) != 0)
            return false;

        // dbMask = MGF1(H, dbLen)
        byte[] dbMask = RsaOaep.Mgf1(h, dbLen, hashAlgorithm);

        // DB = maskedDB ⊕ dbMask
        byte[] db = new byte[dbLen];
        for (int i = 0; i < dbLen; i++)
        {
            db[i] = (byte)(maskedDb[i] ^ dbMask[i]);
        }

        // Set leftmost bits to zero
        if (zeroBits > 0)
        {
            db[0] &= (byte)(0xFF >> zeroBits);
        }

        // Check PS (zeros) and 0x01 separator
        int sepIdx = dbLen - sLen - 1;
        for (int i = 0; i < sepIdx; i++)
        {
            if (db[i] != 0x00)
                return false;
        }

        if (db[sepIdx] != 0x01)
            return false;

        // Extract salt
        ReadOnlySpan<byte> salt = db.AsSpan(dbLen - sLen, sLen);

        // M' = (0x)00 00 00 00 00 00 00 00 || mHash || salt
        byte[] mPrime = new byte[8 + hLen + sLen];
        mHash.CopyTo(mPrime.AsSpan(8));
        salt.CopyTo(mPrime.AsSpan(8 + hLen));

        // H' = Hash(M')
        byte[] hPrime = HashData(hashAlgorithm, mPrime);

        return CryptoHelper.FixedTimeEquals(h, hPrime);
    }

    private static int GetHashLength(HashAlgorithmName hashAlgorithm) =>
        CryptoHelper.GetHashLength(hashAlgorithm);

    private static byte[] HashData(HashAlgorithmName hashAlgorithm, ReadOnlySpan<byte> data) =>
        CryptoHelper.HashData(hashAlgorithm, data);
}
