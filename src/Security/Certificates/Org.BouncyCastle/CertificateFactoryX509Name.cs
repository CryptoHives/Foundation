// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NETSTANDARD2_1 && !NET472_OR_GREATER && !NET5_0_OR_GREATER

namespace CryptoHives.Security.Certificates.BouncyCastle;

using System;
using System.Security.Cryptography.X509Certificates;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;

/// <summary>
/// A converter class to create a X509Name object 
/// from a X509Certificate subject.
/// </summary>
/// <remarks>
/// Handles subtle differences in the string representation
/// of the .NET and the Bouncy Castle implementation.
/// </remarks>
public class CertificateFactoryX509Name : X509Name
{
    /// <summary>
    /// Create the X509Name from a X500DistinguishedName
    /// ASN.1 encoded distinguished name.
    /// </summary>
    /// <param name="distinguishedName">The distinguished name.</param>
    public CertificateFactoryX509Name(X500DistinguishedName distinguishedName) :
        base((Asn1Sequence)Asn1Object.FromByteArray(distinguishedName.RawData))
    {
    }
}

#endif

