// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using CryptoHives.Foundation.Security.Cryptography.Kdf;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using System;
using System.Formats.Asn1;
using OS = System.Security.Cryptography;

/// <summary>
/// Reads and writes PKCS#8 <c>EncryptedPrivateKeyInfo</c> (RFC 5958 §3).
/// </summary>
/// <remarks>
/// <para>
/// <code>
/// EncryptedPrivateKeyInfo ::= SEQUENCE {
///     encryptionAlgorithm  AlgorithmIdentifier,
///     encryptedData        OCTET STRING }
/// </code>
/// </para>
/// <para>
/// <b>Writing</b> always produces PBES2 (RFC 8018 §6.2) with PBKDF2 and AES-CBC, which is what
/// .NET 10 emits. <b>Reading</b> additionally accepts the legacy PKCS#12 password-based schemes
/// (RFC 7292 Appendix C), because that is what older OpenSSL and Windows tooling wrote and the
/// in-box readers still open them. Those schemes are reachable only by reading a file that uses
/// one - <see cref="PbeEncryptionAlgorithm"/> does not offer them, so writing one is not something
/// a caller can ask for.
/// </para>
/// <para>
/// Passwords arrive as <see cref="PbePassword"/>, which owns the encoding difference between the
/// two families: PBES2 derives from the UTF-8 form, the PKCS#12 schemes from big-endian UTF-16
/// with a NUL terminator. Mixing them up does not throw - it silently derives a different key and
/// reports a wrong password - so neither path encodes anything itself.
/// </para>
/// </remarks>
internal static class EncryptedPkcs8
{
    private const int SaltLength = 16;
    private const int AesBlockLength = 16;

    /// <summary>
    /// Encrypts a PKCS#8 <c>PrivateKeyInfo</c> into an <c>EncryptedPrivateKeyInfo</c>.
    /// </summary>
    /// <param name="pkcs8">The plaintext PKCS#8 encoding.</param>
    /// <param name="password">The password.</param>
    /// <param name="pbeOptions">Selects the cipher, pseudorandom function and iteration count.</param>
    /// <returns>The DER encoding.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="pbeOptions"/> is null.</exception>
    public static byte[] Write(
        ReadOnlySpan<byte> pkcs8,
        PbePassword password,
        PbeOptions pbeOptions)
    {
        if (pbeOptions is null)
        {
            throw new ArgumentNullException(nameof(pbeOptions));
        }

        // Both switches are total. PbeOptions validates its enums in its constructor, so there is
        // no unrepresentable combination left to reject here.
        (string cipherOid, int keyLength) = pbeOptions.EncryptionAlgorithm switch {
            PbeEncryptionAlgorithm.Aes128Cbc => (PbeOids.Aes128Cbc, 16),
            PbeEncryptionAlgorithm.Aes192Cbc => (PbeOids.Aes192Cbc, 24),
            _ => (PbeOids.Aes256Cbc, 32),
        };

        string prfOid = PrfOidFor(pbeOptions.Prf);

        byte[] salt = new byte[SaltLength];
        byte[] iv = new byte[AesBlockLength];
        // Same helper the key generators use, so the RNG story is identical across the library.
        Dsa.MLDsaCore.GenerateRandomSeed(salt);
        Dsa.MLDsaCore.GenerateRandomSeed(iv);

        byte[] passwordBytes = password.ForPbkdf2();
        byte[] key = new byte[keyLength];

        try
        {
            Pbkdf2.DeriveKey(HmacFactoryFor(prfOid), passwordBytes, salt, pbeOptions.IterationCount, key);
            byte[] ciphertext = AesCbcEncrypt(key, iv, pkcs8);

            var writer = new AsnWriter(AsnEncodingRules.DER);
            using (writer.PushSequence())
            {
                WritePbes2AlgorithmIdentifier(writer, salt, pbeOptions.IterationCount, prfOid, cipherOid, iv);
                writer.WriteOctetString(ciphertext);
            }

            return writer.Encode();
        }
        finally
        {
            CryptographicOperations.ZeroMemory(key);
            CryptographicOperations.ZeroMemory(passwordBytes);
        }
    }

    /// <summary>
    /// Decrypts an <c>EncryptedPrivateKeyInfo</c>.
    /// </summary>
    /// <param name="source">The DER encoding.</param>
    /// <param name="password">The password.</param>
    /// <returns>The plaintext PKCS#8 encoding.</returns>
    /// <exception cref="OS.CryptographicException">
    /// The structure is malformed, uses an unsupported scheme, or the password is wrong.
    /// </exception>
    public static byte[] Read(ReadOnlySpan<byte> source, PbePassword password)
    {
        try
        {
            var reader = new AsnReader(source.ToArray(), AsnEncodingRules.DER);
            AsnReader info = reader.ReadSequence();
            DerGuard.NoTrailingData(reader);

            AsnReader algorithm = info.ReadSequence();
            string schemeOid = algorithm.ReadObjectIdentifier();
            byte[] ciphertext = info.ReadOctetString();
            DerGuard.NoTrailingData(info);

            return schemeOid switch {
                PbeOids.Pbes2 => ReadPbes2(algorithm, ciphertext, password),
                PbeOids.PbeWithShaAnd3KeyTripleDesCbc or
                PbeOids.PbeWithShaAnd2KeyTripleDesCbc or
                PbeOids.PbeWithShaAnd128BitRc2Cbc or
                PbeOids.PbeWithShaAnd40BitRc2Cbc =>
                    ReadPkcs12Pbe(schemeOid, algorithm, ciphertext, password),
                _ => throw new OS.CryptographicException(
                    $"Unsupported password-based encryption scheme: {schemeOid}."),
            };
        }
        catch (AsnContentException e)
        {
            throw new OS.CryptographicException(
                "The PKCS#8 EncryptedPrivateKeyInfo structure is malformed.", e);
        }
    }

    /// <summary>
    /// Decrypts one of the legacy PKCS#12 password-based schemes (RFC 7292 Appendix C).
    /// </summary>
    /// <remarks>
    /// <para>
    /// Read-only, and deliberately delegated to the platform's <see cref="OS.TripleDES"/> and
    /// <see cref="OS.RC2"/>. This library implements no deprecated ciphers of its own, and a
    /// compatibility path for opening twenty-year-old files is not the place to start: the point
    /// here is to read what older OpenSSL and Windows tooling wrote, not to offer these schemes
    /// as a choice. Exports are always PBES2.
    /// </para>
    /// <para>
    /// <code>
    /// PBEParameter ::= SEQUENCE { salt OCTET STRING, iterations INTEGER }
    /// </code>
    /// The key and IV both come from the PKCS#12 KDF over the same salt and iteration count,
    /// distinguished only by the ID byte.
    /// </para>
    /// </remarks>
    private static byte[] ReadPkcs12Pbe(
        string schemeOid,
        AsnReader algorithm,
        byte[] ciphertext,
        PbePassword password)
    {
        AsnReader parameters = algorithm.ReadSequence();
        DerGuard.NoTrailingData(algorithm);

        byte[] salt = parameters.ReadOctetString();
        if (!parameters.TryReadInt32(out int iterations) || iterations < 1)
        {
            throw new OS.CryptographicException(
                "The PKCS#12 PBE iteration count is missing or invalid.");
        }

        DerGuard.NoTrailingData(parameters);

        // Key size in bytes, and whether the cipher is TripleDES. The IV is always 8 bytes -
        // both TripleDES and RC2 are 64-bit block ciphers.
        (int keyLength, bool tripleDes) = schemeOid switch {
            PbeOids.PbeWithShaAnd3KeyTripleDesCbc => (24, true),
            PbeOids.PbeWithShaAnd2KeyTripleDesCbc => (16, true),
            PbeOids.PbeWithShaAnd128BitRc2Cbc => (16, false),
            PbeOids.PbeWithShaAnd40BitRc2Cbc => (5, false),
            _ => throw new OS.CryptographicException(
                $"Unsupported PKCS#12 encryption scheme: {schemeOid}."),
        };

        byte[] key = new byte[keyLength];
        byte[] iv = new byte[8];
        byte[] passwordBytes = password.ForPkcs12Kdf();

        try
        {
            Pkcs12Kdf.DeriveKey(passwordBytes, salt, iterations, Pkcs12Kdf.KeyMaterialId, key);
            Pkcs12Kdf.DeriveKey(passwordBytes, salt, iterations, Pkcs12Kdf.IvMaterialId, iv);

            return tripleDes
                ? TripleDesCbcDecrypt(key, iv, ciphertext)
                : Rc2CbcDecrypt(key, iv, ciphertext);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(key);
            CryptographicOperations.ZeroMemory(iv);
            CryptographicOperations.ZeroMemory(passwordBytes);
        }
    }

    private static byte[] TripleDesCbcDecrypt(byte[] key, byte[] iv, byte[] ciphertext)
    {
        // The two-key variant is K1 ‖ K2; TripleDES wants the three-key form K1 ‖ K2 ‖ K1.
        byte[] fullKey = key.Length == 16 ? new byte[24] : key;
        if (key.Length == 16)
        {
            Buffer.BlockCopy(key, 0, fullKey, 0, 16);
            Buffer.BlockCopy(key, 0, fullKey, 16, 8);
        }

        try
        {
#pragma warning disable CA5350 // TripleDES is read-only legacy compatibility, never written.
            using OS.TripleDES cipher = OS.TripleDES.Create();
            cipher.Mode = OS.CipherMode.CBC;
            cipher.Padding = OS.PaddingMode.PKCS7;
            cipher.Key = fullKey;
            cipher.IV = iv;
#pragma warning restore CA5350

            using OS.ICryptoTransform transform = cipher.CreateDecryptor();
            return transform.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
        }
        catch (OS.CryptographicException e)
        {
            throw new OS.CryptographicException(
                "The password is incorrect, or the encrypted key is corrupt.", e);
        }
        finally
        {
            if (!ReferenceEquals(fullKey, key))
            {
                CryptographicOperations.ZeroMemory(fullKey);
            }
        }
    }

    private static byte[] Rc2CbcDecrypt(byte[] key, byte[] iv, byte[] ciphertext)
    {
        try
        {
#pragma warning disable SYSLIB0022, CA5351 // RC2 is read-only legacy compatibility, never written.
            using OS.RC2 cipher = OS.RC2.Create();
            cipher.Mode = OS.CipherMode.CBC;
            cipher.Padding = OS.PaddingMode.PKCS7;

            // RFC 7292 App. C pairs the 40-bit key with an effective key length of 40 bits; the
            // 128-bit variant uses 128. EffectiveKeySize must be set before Key.
            cipher.EffectiveKeySize = key.Length * 8;
            cipher.Key = key;
            cipher.IV = iv;
#pragma warning restore SYSLIB0022, CA5351

            using OS.ICryptoTransform transform = cipher.CreateDecryptor();
            return transform.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
        }
        catch (PlatformNotSupportedException e)
        {
            // RC2 is Windows-only on modern .NET. Say so plainly rather than surfacing a bare
            // platform exception from inside a key import.
            throw new OS.CryptographicException(
                "This key uses the legacy RC2-based PKCS#12 encryption scheme, which the current "
                + "platform does not provide.", e);
        }
        catch (OS.CryptographicException e)
        {
            throw new OS.CryptographicException(
                "The password is incorrect, or the encrypted key is corrupt.", e);
        }
    }

    private static byte[] ReadPbes2(
        AsnReader algorithm,
        byte[] ciphertext,
        PbePassword password)
    {
        AsnReader parameters = algorithm.ReadSequence();
        DerGuard.NoTrailingData(algorithm);

        // keyDerivationFunc
        AsnReader kdf = parameters.ReadSequence();
        string kdfOid = kdf.ReadObjectIdentifier();
        if (kdfOid != PbeOids.Pbkdf2)
        {
            throw new OS.CryptographicException(
                $"Unsupported PBES2 key derivation function: {kdfOid}.");
        }

        AsnReader pbkdf2 = kdf.ReadSequence();
        byte[] salt = pbkdf2.ReadOctetString();

        if (!pbkdf2.TryReadInt32(out int iterations) || iterations < 1)
        {
            throw new OS.CryptographicException("The PBKDF2 iteration count is missing or invalid.");
        }

        int? keyLengthHint = null;
        string prfOid = PbeOids.HmacWithSha1;

        while (pbkdf2.HasData)
        {
            Asn1Tag next = pbkdf2.PeekTag();
            if (next.TagClass == TagClass.Universal && next.TagValue == (int)UniversalTagNumber.Integer)
            {
                if (!pbkdf2.TryReadInt32(out int declaredKeyLength))
                {
                    throw new OS.CryptographicException("The PBKDF2 key length is invalid.");
                }

                keyLengthHint = declaredKeyLength;
            }
            else
            {
                AsnReader prf = pbkdf2.ReadSequence();
                prfOid = prf.ReadObjectIdentifier();

                // The PRF AlgorithmIdentifier conventionally carries an explicit NULL here.
                while (prf.HasData)
                {
                    prf.ReadEncodedValue();
                }
            }
        }

        // encryptionScheme
        AsnReader scheme = parameters.ReadSequence();
        string cipherOid = scheme.ReadObjectIdentifier();
        byte[] iv = scheme.ReadOctetString();

        int keyLength = cipherOid switch {
            PbeOids.Aes128Cbc => 16,
            PbeOids.Aes192Cbc => 24,
            PbeOids.Aes256Cbc => 32,
            _ => throw new OS.CryptographicException(
                $"Unsupported PBES2 encryption scheme: {cipherOid}."),
        };

        if (keyLengthHint is int hint && hint != keyLength)
        {
            throw new OS.CryptographicException(
                "The PBKDF2 key length does not match the encryption scheme.");
        }

        byte[] passwordBytes = password.ForPbkdf2();
        byte[] key = new byte[keyLength];

        try
        {
            Pbkdf2.DeriveKey(HmacFactoryFor(prfOid), passwordBytes, salt, iterations, key);
            return AesCbcDecrypt(key, iv, ciphertext);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(key);
            CryptographicOperations.ZeroMemory(passwordBytes);
        }
    }

    private static void WritePbes2AlgorithmIdentifier(
        AsnWriter writer,
        byte[] salt,
        int iterations,
        string prfOid,
        string cipherOid,
        byte[] iv)
    {
        using (writer.PushSequence())
        {
            writer.WriteObjectIdentifier(PbeOids.Pbes2);

            using (writer.PushSequence())
            {
                // keyDerivationFunc
                using (writer.PushSequence())
                {
                    writer.WriteObjectIdentifier(PbeOids.Pbkdf2);

                    using (writer.PushSequence())
                    {
                        writer.WriteOctetString(salt);
                        writer.WriteInteger(iterations);

                        // The PRF is optional and defaults to HMAC-SHA-1. Write it explicitly for
                        // anything else; omitting it for SHA-1 keeps the encoding canonical.
                        if (prfOid != PbeOids.HmacWithSha1)
                        {
                            using (writer.PushSequence())
                            {
                                writer.WriteObjectIdentifier(prfOid);
                                writer.WriteNull();
                            }
                        }
                    }
                }

                // encryptionScheme
                using (writer.PushSequence())
                {
                    writer.WriteObjectIdentifier(cipherOid);
                    writer.WriteOctetString(iv);
                }
            }
        }
    }

    /// <summary>
    /// Maps a pseudorandom function to the OID PBES2 records for it.
    /// </summary>
    /// <remarks>
    /// Total by construction: <see cref="PbeOptions"/> only admits values that have an OID, which
    /// is the whole reason it takes an enum rather than a hash name.
    /// </remarks>
    private static string PrfOidFor(Pbkdf2Prf prf) => prf switch {
        Pbkdf2Prf.HmacSha1 => PbeOids.HmacWithSha1,
        Pbkdf2Prf.HmacSha384 => PbeOids.HmacWithSha384,
        Pbkdf2Prf.HmacSha512 => PbeOids.HmacWithSha512,
        _ => PbeOids.HmacWithSha256,
    };

    private static HmacFactory HmacFactoryFor(string prfOid) => prfOid switch {
#pragma warning disable CS0618 // HMAC-SHA-1 is the RFC 8018 default PRF; legacy files rely on it.
        PbeOids.HmacWithSha256 => static key => new HmacSha256(key),
        PbeOids.HmacWithSha384 => static key => new HmacSha384(key),
        PbeOids.HmacWithSha512 => static key => new HmacSha512(key),
        PbeOids.HmacWithSha1 => static key => new HmacSha1(key),
        _ => throw new OS.CryptographicException(
            $"Unsupported PBKDF2 pseudorandom function: {prfOid}."),
#pragma warning restore CS0618
    };

    private static byte[] AesCbcEncrypt(byte[] key, byte[] iv, ReadOnlySpan<byte> plaintext)
    {
        using SymmetricCipher aes = CreateAes(key.Length);
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;
        return aes.Encrypt(plaintext);
    }

    private static byte[] AesCbcDecrypt(byte[] key, byte[] iv, ReadOnlySpan<byte> ciphertext)
    {
        if (iv.Length != AesBlockLength)
        {
            throw new OS.CryptographicException("The AES-CBC initialization vector must be 16 bytes.");
        }

        using SymmetricCipher aes = CreateAes(key.Length);
        aes.Key = key;
        aes.IV = iv;
        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        try
        {
            return aes.Decrypt(ciphertext);
        }
        catch (OS.CryptographicException e)
        {
            // A padding failure here almost always means a wrong password. Say so, and do not let
            // the underlying message hint at how far the decryption got.
            throw new OS.CryptographicException(
                "The password is incorrect, or the encrypted key is corrupt.", e);
        }
    }

    private static SymmetricCipher CreateAes(int keyLength) => keyLength switch {
        16 => Aes128.Create(),
        24 => Aes192.Create(),
        32 => Aes256.Create(),
        _ => throw new OS.CryptographicException($"Unsupported AES key length: {keyLength}."),
    };

}
