// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Security.Certificates;

using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Utilities to create a Pfx.
/// </summary>
public static class X509PfxUtils
{
    /// <summary>
    /// Internal random number generator.
    /// </summary>
    private static readonly Random _rnd = new Random(0x62541);

    /// <summary>
    /// The size of the block used to test a sign or encrypt operation.
    /// </summary>
    public const int TestBlockSize = 0x20;

    /// <summary>
    /// Return the key usage flags of a certificate.
    /// </summary>
    private static X509KeyUsageFlags GetKeyUsage(X509Certificate2 cert)
    {
        X509KeyUsageFlags allFlags = X509KeyUsageFlags.None;
        foreach (X509KeyUsageExtension ext in cert.Extensions.OfType<X509KeyUsageExtension>())
        {
            allFlags |= ext.KeyUsages;
        }
        return allFlags;
    }

    /// <summary>
    /// Verify RSA key pair of two certificates.
    /// </summary>
    public static bool VerifyRSAKeyPair(
        X509Certificate2 certWithPublicKey,
        X509Certificate2 certWithPrivateKey,
        bool throwOnError = false)
    {
        bool result = false;
        try
        {
            // verify the public and private key match
            using RSA rsaPrivateKey = certWithPrivateKey.GetRSAPrivateKey();
            using RSA rsaPublicKey = certWithPublicKey.GetRSAPublicKey();
            // For non RSA certificates, RSA keys are null
            if (rsaPrivateKey != null && rsaPublicKey != null)
            {
                X509KeyUsageFlags keyUsage = GetKeyUsage(certWithPublicKey);
                if ((keyUsage & X509KeyUsageFlags.DataEncipherment) != 0)
                {
                    result = VerifyRSAKeyPairCrypt(rsaPublicKey, rsaPrivateKey);
                }
                else if ((keyUsage & X509KeyUsageFlags.DigitalSignature) != 0)
                {
                    result = VerifyRSAKeyPairSign(rsaPublicKey, rsaPrivateKey);
                }
                else
                {
                    throw new CryptographicException("Don't know how to verify the public/private key pair.");
                }
            }
            else
            {
                throw new CryptographicException("The certificate does not contain a RSA public/private key pair.");
            }
        }
        catch (Exception)
        {
            if (throwOnError)
            {
                throw;
            }
        }

        if (!result && throwOnError)
        {
            throw new CryptographicException("The public/private key pair in the certificates do not match.");
        }

        return result;
    }

    /// <summary>
    /// Creates a certificate from a PKCS #12 store with a private key.
    /// </summary>
    /// <param name="rawData">The raw PKCS #12 store data.</param>
    /// <param name="password">The password to use to access the store.</param>
    /// <param name="noEphemeralKeySet">Set to true if the key should not use the ephemeral key set.</param>
    /// <returns>The certificate with a private key.</returns>
    public static X509Certificate2 CreateCertificateFromPKCS12(
        byte[] rawData,
        ReadOnlySpan<char> password,
        bool noEphemeralKeySet = false
        )
    {
        Exception ex = null;
        X509Certificate2 certificate = null;

        // By default keys are not persisted
        X509KeyStorageFlags defaultStorageSet = X509KeyStorageFlags.Exportable;
#if NETSTANDARD2_1_OR_GREATER || NET472_OR_GREATER || NET5_0_OR_GREATER
        if (!noEphemeralKeySet && !RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            defaultStorageSet |= X509KeyStorageFlags.EphemeralKeySet;
        }
#endif

        X509KeyStorageFlags[] storageFlags = {
            defaultStorageSet | X509KeyStorageFlags.MachineKeySet,
            defaultStorageSet | X509KeyStorageFlags.UserKeySet
        };

        // try some combinations of storage flags, support is platform dependent
        foreach (X509KeyStorageFlags flag in storageFlags)
        {
            try
            {
                // merge first cert with private key into X509Certificate2
                certificate = X509CertificateLoader.LoadPkcs12(rawData, password, flag);

                // can we really access the private key?
                if (VerifyRSAKeyPair(certificate, certificate, true))
                {
                    return certificate;
                }
            }
            catch (Exception e)
            {
                ex = e;
                certificate?.Dispose();
                certificate = null;
            }
        }

        if (certificate == null)
        {
            throw new NotSupportedException("Creating X509Certificate from PKCS #12 store failed", ex);
        }

        return certificate;
    }

    /// <summary>
    /// Verify a RSA key pair using a encryption.
    /// </summary>
    internal static bool VerifyRSAKeyPairCrypt(RSA rsaPublicKey, RSA rsaPrivateKey)
    {
        byte[] testBlock = new byte[TestBlockSize];
        _rnd.NextBytes(testBlock);
        byte[] encryptedBlock = rsaPublicKey.Encrypt(testBlock, RSAEncryptionPadding.OaepSHA1);
        byte[] decryptedBlock = rsaPrivateKey.Decrypt(encryptedBlock, RSAEncryptionPadding.OaepSHA1);
        if (decryptedBlock != null)
        {
            return testBlock.SequenceEqual(decryptedBlock);
        }

        return false;
    }

    /// <summary>
    /// Verify a RSA key pair using a signature.
    /// </summary>
    internal static bool VerifyRSAKeyPairSign(
        RSA rsaPublicKey,
        RSA rsaPrivateKey)
    {
        byte[] testBlock = new byte[TestBlockSize];
        _rnd.NextBytes(testBlock);
        byte[] signature = rsaPrivateKey.SignData(testBlock, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        return rsaPublicKey.VerifyData(testBlock, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

#if ECC_SUPPORT
    /// <summary>
    /// Verify ECDsa key pair of two certificates.
    /// </summary>
    public static bool VerifyECDsaKeyPair(
        X509Certificate2 certWithPublicKey,
        X509Certificate2 certWithPrivateKey,
        bool throwOnError = false)
    {
        bool result = false;
        using (ECDsa ecdsaPublicKey = certWithPrivateKey.GetECDsaPublicKey())
        using (ECDsa ecdsaPrivateKey = certWithPublicKey.GetECDsaPrivateKey())
        {
            try
            {
                // verify the public and private key match
                X509KeyUsageFlags keyUsage = GetKeyUsage(certWithPublicKey);
                if ((keyUsage & X509KeyUsageFlags.DigitalSignature) != 0)
                {
                    result = VerifyECDsaKeyPairSign(ecdsaPublicKey, ecdsaPrivateKey);
                }
                else
                {
                    if (throwOnError)
                    {
                        throw new CryptographicException("Don't know how to verify the public/private key pair.");
                    }
                }
            }
            catch (Exception)
            {
                if (throwOnError)
                {
                    throwOnError = false;
                    throw;
                }
            }
        }
        if (!result && throwOnError)
        {
            throw new CryptographicException("The public/private key pair in the certificates do not match.");
        }
        return result;
    }

    /// <summary>
    /// Verify a ECDsa key pair using a signature.
    /// </summary>
    internal static bool VerifyECDsaKeyPairSign(
        ECDsa ecdsaPublicKey,
        ECDsa ecdsaPrivateKey)
    {
        byte[] testBlock = new byte[TestBlockSize];
        _rnd.NextBytes(testBlock);
        byte[] signature = ecdsaPrivateKey.SignData(testBlock, HashAlgorithmName.SHA256);
        return ecdsaPublicKey.VerifyData(testBlock, signature, HashAlgorithmName.SHA256);
    }
#endif
}
