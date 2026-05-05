// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509Crl;

using System;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Represents a revoked certificate in the
/// revoked certificates sequence of a CRL.
/// </summary>
/// <remarks>
/// CRL fields -- https://tools.ietf.org/html/rfc5280#section-5.1
/// 
///    ...
///    revokedCertificates     SEQUENCE OF SEQUENCE  {
///        userCertificate         CertificateSerialNumber,
///        revocationDate          Time,
///        crlEntryExtensions      Extensions OPTIONAL
///                              -- if present, version MUST be v2
///                            }  OPTIONAL,
///   ...
///</remarks>
public class RevokedCertificate
{
    /// <summary>
    /// Construct revoked certificate with serialnumber,
    /// actual UTC time and the CRL reason.
    /// </summary>
    /// <param name="serialNumber">The serial number</param>
    /// <param name="crlReason">The reason for revocation</param>
    public RevokedCertificate(string serialNumber, CRLReason crlReason)
        : this(serialNumber)
    {
        CrlEntryExtensions.Add(X509Extensions.BuildX509CRLReason(crlReason));
    }

    /// <summary>
    /// Construct revoked certificate with serialnumber,
    /// actual UTC time and the CRL reason.
    /// </summary>
    /// <param name="serialNumber">The serial number</param>
    /// <param name="crlReason">The reason for revocation</param>
    public RevokedCertificate(byte[] serialNumber, CRLReason crlReason)
        : this(serialNumber)
    {
        if (crlReason != CRLReason.Unspecified)
        {
            CrlEntryExtensions.Add(X509Extensions.BuildX509CRLReason(crlReason));
        }
    }

    /// <summary>
    /// Construct minimal revoked certificate
    /// with serialnumber and actual UTC time.
    /// </summary>
    /// <param name="serialNumber"></param>
    public RevokedCertificate(string serialNumber)
    {
        var serialNumberAsSpan = serialNumber.FromHexString().AsSpan();
        serialNumberAsSpan.Reverse();
        UserCertificate = serialNumberAsSpan.ToArray();
        RevocationDate = DateTime.UtcNow;
        CrlEntryExtensions = new X509ExtensionCollection();
    }

    /// <summary>
    /// Construct minimal revoked certificate
    /// with serialnumber and actual UTC time.
    /// </summary>
    /// <param name="serialNumber"></param>
    public RevokedCertificate(byte[] serialNumber)
    {
        UserCertificate = serialNumber;
        RevocationDate = DateTime.UtcNow;
        CrlEntryExtensions = new X509ExtensionCollection();
    }

    /// <summary>
    /// The serial number of the revoked certificate as
    /// big endian hex string.
    /// </summary>
    public string SerialNumber => UserCertificate.ToHexString(true);

    /// <summary>
    /// The serial number of the revoked user certificate
    /// as a little endian byte array.
    /// </summary>
    public byte[] UserCertificate { get; }

    /// <summary>
    /// The UTC time of the revocation event.
    /// </summary>
    public DateTime RevocationDate { get; set; }

    /// <summary>
    /// The list of crl entry extensions.
    /// </summary>
    public X509ExtensionCollection CrlEntryExtensions { get; }
}

