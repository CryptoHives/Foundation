// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509;

using System;
using System.Collections.Generic;

/// <summary>
/// CRL revocation reason codes per RFC 5280 §5.3.1.
/// </summary>
public enum CrlReason
{
    /// <summary>No specific reason given.</summary>
    Unspecified = 0,

    /// <summary>The certificate's private key was compromised.</summary>
    KeyCompromise = 1,

    /// <summary>The CA's private key was compromised.</summary>
    CaCompromise = 2,

    /// <summary>The subject's affiliation has changed.</summary>
    AffiliationChanged = 3,

    /// <summary>The certificate has been superseded.</summary>
    Superseded = 4,

    /// <summary>The certificate is no longer needed.</summary>
    CessationOfOperation = 5,

    /// <summary>The certificate is on hold.</summary>
    CertificateHold = 6,

    /// <summary>The certificate should be removed from the CRL.</summary>
    RemoveFromCrl = 8,

    /// <summary>A privilege granted by the certificate has been withdrawn.</summary>
    PrivilegeWithdrawn = 9,

    /// <summary>The AA's key was compromised.</summary>
    AaCompromise = 10,
}

/// <summary>
/// Represents a revoked certificate entry in a CRL.
/// </summary>
public sealed class RevokedCertificate
{
    /// <summary>
    /// Gets the serial number of the revoked certificate.
    /// </summary>
    public byte[] SerialNumber { get; }

    /// <summary>
    /// Gets the date and time the certificate was revoked.
    /// </summary>
    public DateTimeOffset RevocationDate { get; }

    /// <summary>
    /// Gets the reason for revocation.
    /// </summary>
    public CrlReason Reason { get; }

    /// <summary>
    /// Initializes a new <see cref="RevokedCertificate"/>.
    /// </summary>
    /// <param name="serialNumber">The serial number of the revoked certificate.</param>
    /// <param name="revocationDate">The date and time of revocation.</param>
    /// <param name="reason">The revocation reason code.</param>
    /// <exception cref="ArgumentNullException"><paramref name="serialNumber"/> is <c>null</c>.</exception>
    public RevokedCertificate(byte[] serialNumber, DateTimeOffset revocationDate, CrlReason reason = CrlReason.Unspecified)
    {
        SerialNumber = serialNumber ?? throw new ArgumentNullException(nameof(serialNumber));
        RevocationDate = revocationDate;
        Reason = reason;
    }
}

/// <summary>
/// Represents an X.509 v2 Certificate Revocation List (CRL) per RFC 5280 §5.
/// </summary>
/// <remarks>
/// <para>
/// Instances are immutable and created by <see cref="X509CrlParser"/>
/// or <see cref="X509CrlBuilder"/>.
/// </para>
/// <para>
/// The raw DER bytes and TBS CertList bytes are retained for
/// signature verification via <see cref="X509CrlValidator"/>.
/// </para>
/// </remarks>
public sealed class X509Crl
{
    /// <summary>
    /// Gets the CRL version (1 or 2).
    /// </summary>
    public int Version { get; }

    /// <summary>
    /// Gets the CRL issuer name.
    /// </summary>
    public X509Name Issuer { get; }

    /// <summary>
    /// Gets the date and time this CRL was issued.
    /// </summary>
    public DateTimeOffset ThisUpdate { get; }

    /// <summary>
    /// Gets the date and time the next CRL is expected, or <c>null</c> if not specified.
    /// </summary>
    public DateTimeOffset? NextUpdate { get; }

    /// <summary>
    /// Gets the list of revoked certificate entries.
    /// </summary>
    public IReadOnlyList<RevokedCertificate> RevokedCertificates { get; }

    /// <summary>
    /// Gets the CRL extensions collection.
    /// </summary>
    public X509ExtensionCollection Extensions { get; }

    /// <summary>
    /// Gets the signature algorithm OID.
    /// </summary>
    public string SignatureAlgorithmOid { get; }

    /// <summary>
    /// Gets the raw signature value bytes.
    /// </summary>
    public byte[] SignatureValue { get; }

    /// <summary>
    /// Gets the raw DER-encoded TBS (To Be Signed) CertList.
    /// </summary>
    public byte[] TbsCertListDer { get; }

    /// <summary>
    /// Gets the complete raw DER-encoded CRL.
    /// </summary>
    public byte[] RawDer { get; }

    internal X509Crl(
        int version,
        X509Name issuer,
        DateTimeOffset thisUpdate,
        DateTimeOffset? nextUpdate,
        IReadOnlyList<RevokedCertificate> revokedCertificates,
        X509ExtensionCollection extensions,
        string signatureAlgorithmOid,
        byte[] signatureValue,
        byte[] tbsCertListDer,
        byte[] rawDer)
    {
        Version = version;
        Issuer = issuer;
        ThisUpdate = thisUpdate;
        NextUpdate = nextUpdate;
        RevokedCertificates = revokedCertificates;
        Extensions = extensions;
        SignatureAlgorithmOid = signatureAlgorithmOid;
        SignatureValue = signatureValue;
        TbsCertListDer = tbsCertListDer;
        RawDer = rawDer;
    }

    /// <summary>
    /// Exports the CRL as a DER-encoded byte array.
    /// </summary>
    /// <returns>A copy of the raw DER-encoded CRL.</returns>
    public byte[] ExportDer() => (byte[])RawDer.Clone();

    /// <summary>
    /// Exports the CRL as a PEM-encoded string with the "X509 CRL" label.
    /// </summary>
    /// <returns>The PEM-encoded CRL string.</returns>
    public string ExportPem() => PemHelper.Encode(RawDer, "X509 CRL");

    /// <summary>
    /// Checks whether the specified certificate serial number is in the revocation list.
    /// </summary>
    /// <param name="serialNumber">The serial number to check.</param>
    /// <returns><c>true</c> if the serial number is revoked; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="serialNumber"/> is <c>null</c>.</exception>
    public bool IsRevoked(byte[] serialNumber)
    {
        if (serialNumber is null) throw new ArgumentNullException(nameof(serialNumber));

        foreach (var entry in RevokedCertificates)
        {
            if (SerialNumbersEqual(entry.SerialNumber, serialNumber))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Checks whether the specified certificate is in the revocation list.
    /// </summary>
    /// <param name="certificate">The certificate to check.</param>
    /// <returns><c>true</c> if the certificate is revoked; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="certificate"/> is <c>null</c>.</exception>
    public bool IsRevoked(X509Certificate certificate)
    {
        if (certificate is null) throw new ArgumentNullException(nameof(certificate));
        return IsRevoked(certificate.SerialNumber);
    }

    /// <summary>
    /// Gets the revocation entry for the specified serial number, or <c>null</c> if not revoked.
    /// </summary>
    /// <param name="serialNumber">The serial number to look up.</param>
    /// <returns>The matching <see cref="RevokedCertificate"/>, or <c>null</c>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="serialNumber"/> is <c>null</c>.</exception>
    public RevokedCertificate? GetRevocationEntry(byte[] serialNumber)
    {
        if (serialNumber is null) throw new ArgumentNullException(nameof(serialNumber));

        foreach (var entry in RevokedCertificates)
        {
            if (SerialNumbersEqual(entry.SerialNumber, serialNumber))
            {
                return entry;
            }
        }
        return null;
    }

    private static bool SerialNumbersEqual(byte[] a, byte[] b)
    {
        ReadOnlySpan<byte> sa = TrimLeadingZeros(a);
        ReadOnlySpan<byte> sb = TrimLeadingZeros(b);
        return sa.SequenceEqual(sb);
    }

    private static ReadOnlySpan<byte> TrimLeadingZeros(byte[] data)
    {
        int i = 0;
        while (i < data.Length - 1 && data[i] == 0)
        {
            i++;
        }

        return data.AsSpan(i);
    }
}
