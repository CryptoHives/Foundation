// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NETSTANDARD2_1 && !NET472_OR_GREATER && !NET5_0_OR_GREATER

namespace CryptoHives.Security.Certificates.BouncyCastle;

using System;
using System.Collections.Generic;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using X509Extension = System.Security.Cryptography.X509Certificates.X509Extension;

/// <summary>
/// Helper functions for X509 extensions using Org.BouncyCastle.
/// </summary>
public static class X509Extensions
{
    /// <summary>
    /// Build the Subject Alternate Name.
    /// </summary>
    public static X509Extension BuildSubjectAltNameExtension(IList<string> uris, IList<string> domainNames, IList<string> ipAddresses)
    {
        // subject alternate name
        var generalNames = new List<GeneralName>();
        foreach (string uri in uris)
        {
            generalNames.Add(new GeneralName(GeneralName.UniformResourceIdentifier, uri));
        }
        generalNames.AddRange(CreateSubjectAlternateNameDomains(domainNames));
        generalNames.AddRange(CreateSubjectAlternateNameDomains(ipAddresses));
        byte[] rawData = new DerOctetString(new GeneralNames(generalNames.ToArray()).GetDerEncoded()).GetOctets();
        return new X509Extension(Org.BouncyCastle.Asn1.X509.X509Extensions.SubjectAlternativeName.Id, rawData, false);
    }

    /// <summary>
    /// helper to build alternate name domains list for certs.
    /// </summary>
    public static List<GeneralName> CreateSubjectAlternateNameDomains(IList<String> domainNames)
    {
        // subject alternate name
        var generalNames = new List<GeneralName>();
        for (int i = 0; i < domainNames.Count; i++)
        {
            int domainType = GeneralName.OtherName;
            switch (Uri.CheckHostName(domainNames[i]))
            {
                case UriHostNameType.Dns: domainType = GeneralName.DnsName; break;
                case UriHostNameType.IPv4:
                case UriHostNameType.IPv6: domainType = GeneralName.IPAddress; break;
                default: continue;
            }
            generalNames.Add(new GeneralName(domainType, domainNames[i]));
        }
        return generalNames;
    }
}

#endif

