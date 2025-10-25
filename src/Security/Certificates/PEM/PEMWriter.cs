// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Security.Certificates;

using System;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/// <summary>
/// Write certificate/crl data in PEM format.
/// </summary>
public static partial class PEMWriter
{
    #region Public Methods
    /// <summary>
    /// Returns a byte array containing the CRL in PEM format.
    /// </summary>
    public static byte[] ExportCRLAsPEM(byte[] crl)
    {
        return EncodeAsPEM(crl, "X509 CRL");
    }

    /// <summary>
    /// Returns a byte array containing the CSR in PEM format.
    /// </summary>
    public static byte[] ExportCSRAsPEM(byte[] csr)
    {
        return EncodeAsPEM(csr, "CERTIFICATE REQUEST");
    }

    /// <summary>
    /// Returns a byte array containing the cert in PEM format.
    /// </summary>
    public static byte[] ExportCertificateAsPEM(X509Certificate2 certificate)
    {
        return EncodeAsPEM(certificate.RawData, "CERTIFICATE");
    }

#if NETSTANDARD2_1 || NET5_0_OR_GREATER
    /// <summary>
    /// Returns a byte array containing the public key in PEM format.
    /// </summary>
    public static byte[] ExportPublicKeyAsPEM(
        X509Certificate2 certificate
        )
    {
        byte[] exportedPublicKey = null;
        using (RSA rsaPublicKey = certificate.GetRSAPublicKey())
        {
            exportedPublicKey = rsaPublicKey.ExportSubjectPublicKeyInfo();
        }
        return EncodeAsPEM(exportedPublicKey, "PUBLIC KEY");
    }

    /// <summary>
    /// Returns a byte array containing the RSA private key in PEM format.
    /// </summary>
    public static byte[] ExportRSAPrivateKeyAsPEM(
        X509Certificate2 certificate)
    {
        byte[] exportedRSAPrivateKey = null;
        using (RSA rsaPrivateKey = certificate.GetRSAPrivateKey())
        {
            // write private key as PKCS#1
            exportedRSAPrivateKey = rsaPrivateKey.ExportRSAPrivateKey();
        }
        return EncodeAsPEM(exportedRSAPrivateKey, "RSA PRIVATE KEY");
    }

    /// <summary>
    /// Returns a byte array containing the ECDsa private key in PEM format.
    /// </summary>
    public static byte[] ExportECDsaPrivateKeyAsPEM(
        X509Certificate2 certificate)
    {
        byte[] exportedECPrivateKey = null;
        using (ECDsa ecdsaPrivateKey = certificate.GetECDsaPrivateKey())
        {
            // write private key as PKCS#1
            exportedECPrivateKey = ecdsaPrivateKey.ExportECPrivateKey();
        }
        return EncodeAsPEM(exportedECPrivateKey, "EC PRIVATE KEY");
    }

    /// <summary>
    /// Returns a byte array containing the private key in PEM format.
    /// </summary>
    public static byte[] ExportPrivateKeyAsPEM(
        X509Certificate2 certificate,
        string password = null
        )
    {
        byte[] exportedPkcs8PrivateKey = null;
        using (RSA rsaPrivateKey = certificate.GetRSAPrivateKey())
        {
            if (rsaPrivateKey != null)
            {
                // write private key as PKCS#8
                exportedPkcs8PrivateKey = string.IsNullOrEmpty(password) ?
                    rsaPrivateKey.ExportPkcs8PrivateKey() :
                    rsaPrivateKey.ExportEncryptedPkcs8PrivateKey(password.ToCharArray(),
                        new PbeParameters(PbeEncryptionAlgorithm.TripleDes3KeyPkcs12, HashAlgorithmName.SHA1, 2000));
            }
            else
            {
                using ECDsa ecdsaPrivateKey = certificate.GetECDsaPrivateKey();
                if (ecdsaPrivateKey != null)
                {
                    // write private key as PKCS#8
                    exportedPkcs8PrivateKey = string.IsNullOrEmpty(password) ?
                        ecdsaPrivateKey.ExportPkcs8PrivateKey() :
                        ecdsaPrivateKey.ExportEncryptedPkcs8PrivateKey(password.ToCharArray(),
                            new PbeParameters(PbeEncryptionAlgorithm.TripleDes3KeyPkcs12, HashAlgorithmName.SHA1, 2000));
                }
            }
        }

        return EncodeAsPEM(exportedPkcs8PrivateKey,
            string.IsNullOrEmpty(password) ? "PRIVATE KEY" : "ENCRYPTED PRIVATE KEY");
    }
#endif
    #endregion

    #region Private Methods
    private static byte[] EncodeAsPEM(byte[] content, string contentType)
    {
        if (content == null) throw new ArgumentNullException(nameof(content));
        if (string.IsNullOrEmpty(contentType)) throw new ArgumentNullException(nameof(contentType));

        const int lineLength = 64;
        string base64 = Convert.ToBase64String(content);
        using var textWriter = new StringWriter();
        textWriter.WriteLine("-----BEGIN {0}-----", contentType);

        int offset = 0;
        while (base64.Length - offset > lineLength)
        {
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
            textWriter.WriteLine(base64.AsSpan(offset, lineLength));
#else
            textWriter.WriteLine(base64.Substring(offset, lineLength));
#endif
            offset += lineLength;
        }

        int length = base64.Length - offset;
        if (length > 0)
        {
#if NETSTANDARD2_1 || NET5_0_OR_GREATER
            textWriter.WriteLine(base64.AsSpan(offset, length));
#else
            textWriter.WriteLine(base64.Substring(offset, length));
#endif
        }

        textWriter.WriteLine("-----END {0}-----", contentType);
        return Encoding.ASCII.GetBytes(textWriter.ToString());
    }
    #endregion
}
