// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

#if !NETSTANDARD2_1 && !NET5_0_OR_GREATER

namespace CryptoHives.Security.Certificates;

using System;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Asn1.Pkcs;

/// <summary>
/// Write certificate data in PEM format.
/// </summary>
public static partial class PEMWriter
{
    #region Public Methods
    /// <summary>
    /// Returns a byte array containing the private key in PEM format.
    /// </summary>
    public static byte[] ExportPrivateKeyAsPEM(
        X509Certificate2 certificate,
        string password = null
        )
    {
        if (!String.IsNullOrEmpty(password)) throw new ArgumentException("Export with password not supported on this platform.", nameof(password));
        RsaPrivateCrtKeyParameters privateKeyParameter = X509Utils.GetPrivateKeyParameter(certificate);
        // write private key as PKCS#8
        PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(privateKeyParameter);
        byte[] serializedPrivateBytes = privateKeyInfo.ToAsn1Object().GetDerEncoded();
        return EncodeAsPEM(serializedPrivateBytes, "PRIVATE KEY");
    }
    #endregion
}

#endif
