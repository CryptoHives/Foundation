// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

#if !NETSTANDARD2_1 && !NET5_0_OR_GREATER

namespace CryptoHives.Security.Certificates;

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;

/// <summary>
/// Helpers to create certificates, CRLs and extensions.
/// </summary>
public static partial class X509Utils
{
    #region Internal Methods
    /// <summary>
    /// Create a Pfx blob with a private key by combining 
    /// a bouncy castle X509Certificate and a private key.
    /// </summary>
    internal static byte[] CreatePfxWithPrivateKey(
        Org.BouncyCastle.X509.X509Certificate certificate,
        string friendlyName,
        AsymmetricKeyParameter privateKey,
        char[] passcode,
        SecureRandom random)
    {
        // create pkcs12 store for cert and private key
        using var pfxData = new MemoryStream();
        var builder = new Pkcs12StoreBuilder();
        builder.SetUseDerEncoding(true);
        Pkcs12Store pkcsStore = builder.Build();
        var chain = new X509CertificateEntry[1];
        chain[0] = new X509CertificateEntry(certificate);
        if (string.IsNullOrEmpty(friendlyName))
        {
            friendlyName = GetCertificateCommonName(certificate);
        }
        pkcsStore.SetKeyEntry(friendlyName, new AsymmetricKeyEntry(privateKey), chain);
        pkcsStore.Save(pfxData, passcode, random);
        return pfxData.ToArray();
    }

    /// <summary>
    /// Helper to get the Bouncy Castle hash algorithm name by .NET name .
    /// </summary>
    internal static string GetRSAHashAlgorithm(HashAlgorithmName hashAlgorithmName)
    {
        if (hashAlgorithmName == HashAlgorithmName.SHA1)
        {
            return "SHA1WITHRSA";
        }
        else if (hashAlgorithmName == HashAlgorithmName.SHA256)
        {
            return "SHA256WITHRSA";
        }
        else if (hashAlgorithmName == HashAlgorithmName.SHA384)
        {
            return "SHA384WITHRSA";
        }
        else if (hashAlgorithmName == HashAlgorithmName.SHA512)
        {
            return "SHA512WITHRSA";
        }
        throw new CryptographicException($"The hash algorithm {hashAlgorithmName} is not supported");
    }

    /// <summary>
    /// Get public key parameters from a X509Certificate2
    /// </summary>
    internal static RsaKeyParameters GetPublicKeyParameter(X509Certificate2 certificate)
    {
        using RSA rsa = certificate.GetRSAPublicKey();
        return GetPublicKeyParameter(rsa);
    }

    /// <summary>
    /// Get public key parameters from a RSA.
    /// </summary>
    internal static RsaKeyParameters GetPublicKeyParameter(RSA rsa)
    {
        RSAParameters rsaParams = rsa.ExportParameters(false);
        return new RsaKeyParameters(
            false,
            new BigInteger(1, rsaParams.Modulus),
            new BigInteger(1, rsaParams.Exponent));
    }

    /// <summary>
    /// Get private key parameters from a X509Certificate2.
    /// The private key must be exportable.
    /// </summary>
    internal static RsaPrivateCrtKeyParameters GetPrivateKeyParameter(X509Certificate2 certificate)
    {
        // try to get signing/private key from certificate passed in
        using RSA rsa = certificate.GetRSAPrivateKey();
        return GetPrivateKeyParameter(rsa);
    }

    /// <summary>
    /// Get private key parameters from a RSA private key.
    /// The private key must be exportable.
    /// </summary>
    internal static RsaPrivateCrtKeyParameters GetPrivateKeyParameter(RSA rsa)
    {
        RSAParameters rsaParams = rsa.ExportParameters(true);
        return new RsaPrivateCrtKeyParameters(
            new BigInteger(1, rsaParams.Modulus),
            new BigInteger(1, rsaParams.Exponent),
            new BigInteger(1, rsaParams.D),
            new BigInteger(1, rsaParams.P),
            new BigInteger(1, rsaParams.Q),
            new BigInteger(1, rsaParams.DP),
            new BigInteger(1, rsaParams.DQ),
            new BigInteger(1, rsaParams.InverseQ));
    }


    /// <summary>
    /// Get the serial number from a certificate as BigInteger.
    /// </summary>
    internal static BigInteger GetSerialNumber(X509Certificate2 certificate)
    {
        byte[] serialNumber = certificate.GetSerialNumber();
        return new BigInteger(1, serialNumber.Reverse().ToArray());
    }

    /// <summary>
    /// Read the Common Name from a certificate.
    /// </summary>
    internal static string GetCertificateCommonName(Org.BouncyCastle.X509.X509Certificate certificate)
    {
        System.Collections.Generic.IList<string> subjectDN = certificate.SubjectDN.GetValueList(X509Name.CN);
        if (subjectDN.Count > 0)
        {
            return subjectDN[0].ToString();
        }
        return string.Empty;
    }

    /// <summary>
    /// Returns a RSA object with an imported public key.
    /// </summary>
    internal static RSA SetRSAPublicKey(byte[] publicKey)
    {
        AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(publicKey);
        var rsaKeyParameters = asymmetricKeyParameter as RsaKeyParameters;
        var parameters = new RSAParameters {
            Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned(),
            Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned()
        };
        var rsaPublicKey = RSA.Create();
        rsaPublicKey.ImportParameters(parameters);
        return rsaPublicKey;
    }
    #endregion
}
#endif
