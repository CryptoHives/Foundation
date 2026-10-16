// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;

using System;
using System.Security.Cryptography;

/// <summary>
/// Implements PKCS#1 v1.5 signature and encryption padding (RFC 8017 §§8.2, 7.2).
/// </summary>
internal static class RsaPkcs1
{
    // DigestInfo DER prefixes for common hash algorithms (RFC 8017 §9.2 Notes)
    private static ReadOnlySpan<byte> DigestInfoSha1 =>
    [
        0x30, 0x21, 0x30, 0x09, 0x06, 0x05, 0x2B, 0x0E,
        0x03, 0x02, 0x1A, 0x05, 0x00, 0x04, 0x14
    ];

    private static ReadOnlySpan<byte> DigestInfoSha256 =>
    [
        0x30, 0x31, 0x30, 0x0D, 0x06, 0x09, 0x60, 0x86,
        0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x01, 0x05,
        0x00, 0x04, 0x20
    ];

    private static ReadOnlySpan<byte> DigestInfoSha384 =>
    [
        0x30, 0x41, 0x30, 0x0D, 0x06, 0x09, 0x60, 0x86,
        0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x02, 0x05,
        0x00, 0x04, 0x30
    ];

    private static ReadOnlySpan<byte> DigestInfoSha512 =>
    [
        0x30, 0x51, 0x30, 0x0D, 0x06, 0x09, 0x60, 0x86,
        0x48, 0x01, 0x65, 0x03, 0x04, 0x02, 0x03, 0x05,
        0x00, 0x04, 0x40
    ];

    /// <summary>
    /// Signs a hash using PKCS#1 v1.5 signature padding.
    /// </summary>
    /// <param name="hash">The hash value to sign.</param>
    /// <param name="hashAlgorithm">The hash algorithm that produced <paramref name="hash"/>.</param>
    /// <param name="key">The RSA private key.</param>
    /// <returns>The signature as a big-endian byte array.</returns>
    /// <exception cref="CryptographicException">Thrown if the key is too small for the digest.</exception>
    public static byte[] Sign(ReadOnlySpan<byte> hash, HashAlgorithmName hashAlgorithm, RsaKeyParameters key)
    {
        int k = key.Modulus.Length;
        byte[] em = EncodePkcs1Signature(hash, hashAlgorithm, k);
        return RsaCore.PrivateOp(em, key);
    }

    /// <summary>
    /// Verifies a PKCS#1 v1.5 signature against a hash.
    /// </summary>
    /// <param name="hash">The expected hash value.</param>
    /// <param name="signature">The signature to verify.</param>
    /// <param name="hashAlgorithm">The hash algorithm that produced <paramref name="hash"/>.</param>
    /// <param name="key">The RSA public key.</param>
    /// <returns><c>true</c> if the signature is valid; otherwise, <c>false</c>.</returns>
    public static bool Verify(
        ReadOnlySpan<byte> hash,
        ReadOnlySpan<byte> signature,
        HashAlgorithmName hashAlgorithm,
        RsaKeyParameters key)
    {
        int k = key.Modulus.Length;
        byte[] expected;
        try
        {
            expected = EncodePkcs1Signature(hash, hashAlgorithm, k);
        }
        catch (CryptographicException)
        {
            return false;
        }

        byte[] actual;
        try
        {
            actual = RsaCore.PublicOp(signature, key);
        }
        catch
        {
            return false;
        }

        return CryptoHelper.FixedTimeEquals(expected, actual);
    }

    /// <summary>
    /// Encrypts data using PKCS#1 v1.5 encryption padding (Type 2).
    /// </summary>
    /// <param name="plaintext">The data to encrypt (at most k - 11 bytes).</param>
    /// <param name="key">The RSA public key.</param>
    /// <returns>The ciphertext as a big-endian byte array.</returns>
    /// <exception cref="CryptographicException">Thrown if the plaintext is too long.</exception>
    public static byte[] Encrypt(ReadOnlySpan<byte> plaintext, RsaKeyParameters key)
    {
        int k = key.Modulus.Length;
        if (plaintext.Length > k - 11)
            throw new CryptographicException("Message too long for PKCS#1 v1.5 encryption.");

        // EM = 0x00 || 0x02 || PS || 0x00 || M
        byte[] em = new byte[k];
        em[0] = 0x00;
        em[1] = 0x02;

        int psLen = k - plaintext.Length - 3;

        // PS must be random non-zero bytes
        byte[] singleBuf = new byte[1];
        byte[] psBytes = new byte[psLen];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(psBytes);
        psBytes.CopyTo(em, 2);
        Span<byte> ps = em.AsSpan(2, psLen);
        for (int i = 0; i < ps.Length; i++)
        {
            while (ps[i] == 0)
            {
                rng.GetBytes(singleBuf);
                ps[i] = singleBuf[0];
            }
        }

        em[2 + psLen] = 0x00;
        plaintext.CopyTo(em.AsSpan(3 + psLen));

        return RsaCore.PublicOp(em, key);
    }

    /// <summary>
    /// Decrypts data using PKCS#1 v1.5 encryption padding (Type 2).
    /// </summary>
    /// <param name="ciphertext">The ciphertext to decrypt.</param>
    /// <param name="key">The RSA private key.</param>
    /// <returns>The decrypted plaintext.</returns>
    /// <exception cref="CryptographicException">Thrown if the padding is invalid.</exception>
    public static byte[] Decrypt(ReadOnlySpan<byte> ciphertext, RsaKeyParameters key)
    {
        byte[] em = RsaCore.PrivateOp(ciphertext, key);
        int k = em.Length;

        // Validate: EM = 0x00 || 0x02 || PS || 0x00 || M
        // Constant-time validation to prevent Bleichenbacher attack
        int valid = 1;
        valid &= ConstantTimeByteEq(em[0], 0x00);
        valid &= ConstantTimeByteEq(em[1], 0x02);

        // Find the 0x00 separator after PS (PS must be at least 8 bytes)
        int separatorIdx = 0;
        int foundSep = 0;
        for (int i = 2; i < k; i++)
        {
            int isZero = ConstantTimeByteEq(em[i], 0x00);
            int isFirst = isZero & (1 - foundSep) & (i >= 10 ? 1 : 0);
            separatorIdx = ConstantTimeSelect(isFirst, i, separatorIdx);
            foundSep |= isFirst;
        }

        valid &= foundSep;

        if (valid == 0)
            throw new CryptographicException("Invalid PKCS#1 v1.5 encryption padding.");

        int msgStart = separatorIdx + 1;
        byte[] result = new byte[k - msgStart];
        Buffer.BlockCopy(em, msgStart, result, 0, result.Length);
        return result;
    }

    /// <summary>
    /// Creates the EMSA-PKCS1-v1_5 encoded message for signature operations.
    /// </summary>
    private static byte[] EncodePkcs1Signature(ReadOnlySpan<byte> hash, HashAlgorithmName hashAlgorithm, int emLen)
    {
        ReadOnlySpan<byte> digestInfo = GetDigestInfoPrefix(hashAlgorithm);
        int tLen = digestInfo.Length + hash.Length;

        if (emLen < tLen + 11)
            throw new CryptographicException("Intended encoded message length too short.");

        // EM = 0x00 || 0x01 || PS || 0x00 || T
        byte[] em = new byte[emLen];
        em[0] = 0x00;
        em[1] = 0x01;

        int psLen = emLen - tLen - 3;
        em.AsSpan(2, psLen).Fill(0xFF);
        em[2 + psLen] = 0x00;

        digestInfo.CopyTo(em.AsSpan(3 + psLen));
        hash.CopyTo(em.AsSpan(3 + psLen + digestInfo.Length));

        return em;
    }

    private static ReadOnlySpan<byte> GetDigestInfoPrefix(HashAlgorithmName hashAlgorithm)
    {
        if (hashAlgorithm == HashAlgorithmName.SHA1) return DigestInfoSha1;
        if (hashAlgorithm == HashAlgorithmName.SHA256) return DigestInfoSha256;
        if (hashAlgorithm == HashAlgorithmName.SHA384) return DigestInfoSha384;
        if (hashAlgorithm == HashAlgorithmName.SHA512) return DigestInfoSha512;
        throw new CryptographicException($"Unsupported hash algorithm: {hashAlgorithm.Name}");
    }

    private static int ConstantTimeByteEq(byte a, byte b)
    {
        uint diff = (uint)(a ^ b);
        return (int)(1 - ((diff | (~diff + 1)) >> 31));
    }

    private static int ConstantTimeSelect(int condition, int a, int b)
    {
        int mask = -condition; // 0 or 0xFFFFFFFF
        return (a & mask) | (b & ~mask);
    }
}

