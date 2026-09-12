// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

using System;
using System.Security.Cryptography;

/// <summary>
/// Implements RSAES-OAEP encryption and decryption (RFC 8017 §7.1).
/// </summary>
/// <remarks>
/// OAEP (Optimal Asymmetric Encryption Padding) provides IND-CCA2 security
/// and is preferred over PKCS#1 v1.5 for encryption.
/// </remarks>
internal static class RsaOaep
{
    /// <summary>
    /// Encrypts data using RSAES-OAEP.
    /// </summary>
    /// <param name="plaintext">The data to encrypt.</param>
    /// <param name="key">The RSA public key.</param>
    /// <param name="hashAlgorithm">The hash algorithm for OAEP (e.g., SHA-256).</param>
    /// <param name="label">Optional label (default empty).</param>
    /// <returns>The ciphertext.</returns>
    /// <exception cref="CryptographicException">Thrown if the plaintext is too long.</exception>
    public static byte[] Encrypt(
        ReadOnlySpan<byte> plaintext,
        RsaKeyParameters key,
        HashAlgorithmName hashAlgorithm,
        ReadOnlySpan<byte> label = default)
    {
        int k = key.Modulus.Length;
        int hLen = GetHashLength(hashAlgorithm);

        // mLen <= k - 2hLen - 2
        if (plaintext.Length > k - 2 * hLen - 2)
            throw new CryptographicException("Message too long for OAEP encryption.");

        byte[] em = OaepEncode(plaintext, k, hashAlgorithm, label);
        return RsaCore.PublicOp(em, key);
    }

    /// <summary>
    /// Decrypts data using RSAES-OAEP.
    /// </summary>
    /// <param name="ciphertext">The ciphertext to decrypt.</param>
    /// <param name="key">The RSA private key.</param>
    /// <param name="hashAlgorithm">The hash algorithm for OAEP (must match encryption).</param>
    /// <param name="label">Optional label (default empty, must match encryption).</param>
    /// <returns>The decrypted plaintext.</returns>
    /// <exception cref="CryptographicException">Thrown if decryption or padding validation fails.</exception>
    public static byte[] Decrypt(
        ReadOnlySpan<byte> ciphertext,
        RsaKeyParameters key,
        HashAlgorithmName hashAlgorithm,
        ReadOnlySpan<byte> label = default)
    {
        byte[] em = RsaCore.PrivateOp(ciphertext, key);
        return OaepDecode(em, hashAlgorithm, label);
    }

    /// <summary>
    /// OAEP encoding (EME-OAEP-Encode, RFC 8017 §7.1.1 Step 2).
    /// </summary>
    private static byte[] OaepEncode(
        ReadOnlySpan<byte> message,
        int k,
        HashAlgorithmName hashAlgorithm,
        ReadOnlySpan<byte> label)
    {
        int hLen = GetHashLength(hashAlgorithm);

        // lHash = Hash(L)
        byte[] lHash = HashData(hashAlgorithm, label);

        // DB = lHash || PS || 0x01 || M
        int dbLen = k - hLen - 1;
        byte[] db = new byte[dbLen];
        lHash.CopyTo(db.AsSpan());
        // PS is already zeros (from array init)
        int psLen = dbLen - hLen - message.Length - 1;
        db[hLen + psLen] = 0x01;
        message.CopyTo(db.AsSpan(hLen + psLen + 1));

        // Generate random seed
        byte[] seed = new byte[hLen];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(seed);

        // dbMask = MGF1(seed, dbLen)
        byte[] dbMask = Mgf1(seed, dbLen, hashAlgorithm);

        // maskedDB = DB ⊕ dbMask
        byte[] maskedDb = new byte[dbLen];
        Xor(db, dbMask, maskedDb);

        // seedMask = MGF1(maskedDB, hLen)
        byte[] seedMask = Mgf1(maskedDb, hLen, hashAlgorithm);

        // maskedSeed = seed ⊕ seedMask
        byte[] maskedSeed = new byte[hLen];
        Xor(seed, seedMask, maskedSeed);

        // EM = 0x00 || maskedSeed || maskedDB
        byte[] em = new byte[k];
        em[0] = 0x00;
        maskedSeed.CopyTo(em.AsSpan(1));
        maskedDb.CopyTo(em.AsSpan(1 + hLen));

        return em;
    }

    /// <summary>
    /// OAEP decoding (EME-OAEP-Decode, RFC 8017 §7.1.2 Step 3).
    /// </summary>
    private static byte[] OaepDecode(
        byte[] em,
        HashAlgorithmName hashAlgorithm,
        ReadOnlySpan<byte> label)
    {
        int k = em.Length;
        int hLen = GetHashLength(hashAlgorithm);

        // Constant-time error accumulator
        int valid = 1;

        if (k < 2 * hLen + 2)
            throw new CryptographicException("Decryption error.");

        // Y || maskedSeed || maskedDB
        valid &= ConstantTimeByteEq(em[0], 0x00);
        ReadOnlySpan<byte> maskedSeed = em.AsSpan(1, hLen);
        ReadOnlySpan<byte> maskedDb = em.AsSpan(1 + hLen);

        // seedMask = MGF1(maskedDB, hLen)
        byte[] seedMask = Mgf1(maskedDb, hLen, hashAlgorithm);

        // seed = maskedSeed ⊕ seedMask
        byte[] seed = new byte[hLen];
        Xor(maskedSeed, seedMask, seed);

        // dbMask = MGF1(seed, k - hLen - 1)
        int dbLen = k - hLen - 1;
        byte[] dbMask = Mgf1(seed, dbLen, hashAlgorithm);

        // DB = maskedDB ⊕ dbMask
        byte[] db = new byte[dbLen];
        Xor(maskedDb, dbMask, db);

        // DB = lHash' || PS || 0x01 || M
        byte[] lHash = HashData(hashAlgorithm, label);

        // Verify lHash' == lHash
        valid &= CryptoHelper.FixedTimeEquals(db.AsSpan(0, hLen), lHash) ? 1 : 0;

        // Find 0x01 separator (constant-time scan)
        int separatorIdx = 0;
        int foundSep = 0;
        for (int i = hLen; i < dbLen; i++)
        {
            int isOne = ConstantTimeByteEq(db[i], 0x01);
            int isZero = ConstantTimeByteEq(db[i], 0x00);
            int isFirst = isOne & (1 - foundSep);
            separatorIdx = ConstantTimeSelect(isFirst, i, separatorIdx);
            foundSep |= isFirst;

            // Any non-zero, non-0x01 byte before separator is invalid
            valid &= isZero | isOne | foundSep;
        }

        valid &= foundSep;

        if (valid == 0)
            throw new CryptographicException("Decryption error.");

        int msgStart = separatorIdx + 1;
        byte[] result = new byte[dbLen - msgStart];
        Buffer.BlockCopy(db, msgStart, result, 0, result.Length);
        return result;
    }

    /// <summary>
    /// MGF1 mask generation function (RFC 8017 §B.2.1).
    /// </summary>
    internal static byte[] Mgf1(ReadOnlySpan<byte> seed, int maskLen, HashAlgorithmName hashAlgorithm)
    {
        int hLen = GetHashLength(hashAlgorithm);
        int iterations = (maskLen + hLen - 1) / hLen;

        byte[] mask = new byte[maskLen];
        byte[] buffer = new byte[seed.Length + 4];
        seed.CopyTo(buffer);

        int offset = 0;
        for (int counter = 0; counter < iterations; counter++)
        {
            // Append counter as big-endian 4 bytes
            buffer[seed.Length] = (byte)(counter >> 24);
            buffer[seed.Length + 1] = (byte)(counter >> 16);
            buffer[seed.Length + 2] = (byte)(counter >> 8);
            buffer[seed.Length + 3] = (byte)counter;

            byte[] hash = HashData(hashAlgorithm, buffer);

            int copyLen = Math.Min(hLen, maskLen - offset);
            Buffer.BlockCopy(hash, 0, mask, offset, copyLen);
            offset += copyLen;
        }

        return mask;
    }

    private static int GetHashLength(HashAlgorithmName hashAlgorithm) =>
        CryptoHelper.GetHashLength(hashAlgorithm);

    private static byte[] HashData(HashAlgorithmName hashAlgorithm, ReadOnlySpan<byte> data) =>
        CryptoHelper.HashData(hashAlgorithm, data);

    private static void Xor(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b, Span<byte> result)
    {
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = (byte)(a[i] ^ b[i]);
        }
    }

    private static int ConstantTimeByteEq(byte a, byte b)
    {
        uint diff = (uint)(a ^ b);
        return (int)(1 - ((diff | (~diff + 1)) >> 31));
    }

    private static int ConstantTimeSelect(int condition, int a, int b)
    {
        int mask = -condition;
        return (a & mask) | (b & ~mask);
    }
}

