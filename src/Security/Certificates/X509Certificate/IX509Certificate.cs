// ------------------------------------------------------------
//  Copyright (c) 2025 The Keepers of the CryptoHives.  All rights reserved.
//  Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// ------------------------------------------------------------

namespace CryptoHives.Security.Certificates;

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Properties of a X.509v3 certificate.
/// </summary>
public interface IX509Certificate
{
    /// <summary>
    /// The subject distinguished name from a certificate.
    /// </summary>
    X500DistinguishedName SubjectName { get; }

    /// <summary>
    /// The distinguished name of the certificate issuer.
    /// </summary>
    X500DistinguishedName IssuerName { get; }

    /// <summary>
    /// The date in UTC time on which a certificate becomes valid.
    /// </summary>
    DateTime NotBefore { get; }

    /// <summary>
    /// The date in UTC time after which a certificate is no longer valid.
    /// </summary>
    DateTime NotAfter { get; }

    /// <summary>
    /// The serial number of the certificate
    /// as a big-endian hexadecimal string.
    /// </summary>
    string SerialNumber { get; }

    /// <summary>
    /// The serial number of the certificate
    /// as an array of bytes in little-endian order.
    /// </summary>
    byte[] GetSerialNumber();

    /// <summary>
    /// The hash algorithm used to create the signature.
    /// </summary>
    HashAlgorithmName HashAlgorithmName { get; }

    /// <summary>
    /// A collection of X509 extensions.
    /// </summary>
    X509ExtensionCollection Extensions { get; }
}

