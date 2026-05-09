// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509;

using System;

/// <summary>
/// Provides pre-configured <see cref="X509CertificateBuilder"/> instances
/// for common certificate profiles.
/// </summary>
/// <remarks>
/// Each method returns a builder with the appropriate extensions pre-set
/// for the profile. The caller can further customize the builder before
/// calling a Build method.
/// </remarks>
public static class CertificateProfiles
{
    /// <summary>
    /// Creates a builder pre-configured for a TLS server certificate.
    /// </summary>
    /// <remarks>
    /// <para>Sets the following extensions:</para>
    /// <list type="bullet">
    /// <item><description>Basic Constraints: CA=false</description></item>
    /// <item><description>Key Usage: DigitalSignature, KeyEncipherment (critical)</description></item>
    /// <item><description>Extended Key Usage: ServerAuth</description></item>
    /// <item><description>Subject Alternative Name: DNS names from <paramref name="dnsNames"/></description></item>
    /// </list>
    /// </remarks>
    /// <param name="subject">The certificate subject (e.g., "CN=example.com, O=Acme, C=US").</param>
    /// <param name="dnsNames">DNS names for the Subject Alternative Name extension.</param>
    /// <param name="keySizeBits">The RSA key size in bits (default: 2048).</param>
    /// <returns>A pre-configured builder.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/> or <paramref name="dnsNames"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="dnsNames"/> is empty.</exception>
    public static X509CertificateBuilder CreateTlsServerForRSA(
        string subject,
        string[] dnsNames,
        int keySizeBits = 2048)
    {
        if (subject is null) throw new ArgumentNullException(nameof(subject));
        if (dnsNames is null) throw new ArgumentNullException(nameof(dnsNames));
        if (dnsNames.Length == 0) throw new ArgumentException("At least one DNS name is required.", nameof(dnsNames));

        var sanEntries = new (SanType, string)[dnsNames.Length];
        for (int i = 0; i < dnsNames.Length; i++)
            sanEntries[i] = (SanType.DnsName, dnsNames[i]);

        return X509CertificateBuilder.CreateForRsa(keySizeBits)
            .SetSubject(X509Name.FromString(subject))
            .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(1))
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsageFlags.DigitalSignature | KeyUsageFlags.KeyEncipherment)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidServerAuth)
            .AddSubjectAlternativeName(sanEntries);
    }

    /// <summary>
    /// Creates a builder pre-configured for a TLS server certificate using ECDSA.
    /// </summary>
    /// <param name="subject">The certificate subject.</param>
    /// <param name="dnsNames">DNS names for the SAN extension.</param>
    /// <param name="curveName">The EC curve name (default: "nistP256").</param>
    /// <returns>A pre-configured builder.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/> or <paramref name="dnsNames"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException"><paramref name="dnsNames"/> is empty.</exception>
    public static X509CertificateBuilder CreateTlsServerForEcDsa(
        string subject,
        string[] dnsNames,
        string curveName = "nistP256")
    {
        if (subject is null) throw new ArgumentNullException(nameof(subject));
        if (dnsNames is null) throw new ArgumentNullException(nameof(dnsNames));
        if (dnsNames.Length == 0) throw new ArgumentException("At least one DNS name is required.", nameof(dnsNames));

        var sanEntries = new (SanType, string)[dnsNames.Length];
        for (int i = 0; i < dnsNames.Length; i++)
            sanEntries[i] = (SanType.DnsName, dnsNames[i]);

        return X509CertificateBuilder.CreateForEcDsa(curveName)
            .SetSubject(X509Name.FromString(subject))
            .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(1))
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsageFlags.DigitalSignature)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidServerAuth)
            .AddSubjectAlternativeName(sanEntries);
    }

    /// <summary>
    /// Creates a builder pre-configured for a TLS client certificate.
    /// </summary>
    /// <remarks>
    /// <para>Sets the following extensions:</para>
    /// <list type="bullet">
    /// <item><description>Basic Constraints: CA=false</description></item>
    /// <item><description>Key Usage: DigitalSignature (critical)</description></item>
    /// <item><description>Extended Key Usage: ClientAuth</description></item>
    /// </list>
    /// </remarks>
    /// <param name="subject">The certificate subject (e.g., "CN=client@example.com").</param>
    /// <param name="keySizeBits">The RSA key size in bits (default: 2048).</param>
    /// <returns>A pre-configured builder.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/> is <see langword="null"/>.</exception>
    public static X509CertificateBuilder CreateTlsClientForRSA(
        string subject,
        int keySizeBits = 2048)
    {
        if (subject is null) throw new ArgumentNullException(nameof(subject));

        return X509CertificateBuilder.CreateForRsa(keySizeBits)
            .SetSubject(X509Name.FromString(subject))
            .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(1))
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsageFlags.DigitalSignature)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidClientAuth);
    }

    /// <summary>
    /// Creates a builder pre-configured for a TLS client certificate using ECDSA.
    /// </summary>
    /// <param name="subject">The certificate subject.</param>
    /// <param name="curveName">The EC curve name (default: "nistP256").</param>
    /// <returns>A pre-configured builder.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/> is <see langword="null"/>.</exception>
    public static X509CertificateBuilder CreateTlsClientForEcDsa(
        string subject,
        string curveName = "nistP256")
    {
        if (subject is null) throw new ArgumentNullException(nameof(subject));

        return X509CertificateBuilder.CreateForEcDsa(curveName)
            .SetSubject(X509Name.FromString(subject))
            .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(1))
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsageFlags.DigitalSignature)
            .AddExtendedKeyUsage(ExtensionParsers.ExtendedKeyUsage.OidClientAuth);
    }

    /// <summary>
    /// Creates a builder pre-configured for a CA certificate.
    /// </summary>
    /// <remarks>
    /// <para>Sets the following extensions:</para>
    /// <list type="bullet">
    /// <item><description>Basic Constraints: CA=true with optional path length (critical)</description></item>
    /// <item><description>Key Usage: KeyCertSign, CrlSign (critical)</description></item>
    /// </list>
    /// <para>SKI is auto-computed by the builder when BasicConstraints CA=true.</para>
    /// </remarks>
    /// <param name="subject">The CA subject (e.g., "CN=My Root CA, O=Acme, C=US").</param>
    /// <param name="pathLengthConstraint">Optional path length constraint (null for unlimited).</param>
    /// <param name="keySizeBits">The RSA key size in bits (default: 4096).</param>
    /// <returns>A pre-configured builder.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/> is <see langword="null"/>.</exception>
    public static X509CertificateBuilder CreateCaCertificate(
        string subject,
        int? pathLengthConstraint = null,
        int keySizeBits = 4096)
    {
        if (subject is null) throw new ArgumentNullException(nameof(subject));

        return X509CertificateBuilder.CreateForRsa(keySizeBits)
            .SetSubject(X509Name.FromString(subject))
            .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(10))
            .AddBasicConstraints(true, pathLengthConstraint)
            .AddKeyUsage(KeyUsageFlags.KeyCertSign | KeyUsageFlags.CrlSign);
    }

    /// <summary>
    /// Creates a builder pre-configured for a CA certificate using ECDSA.
    /// </summary>
    /// <param name="subject">The CA subject.</param>
    /// <param name="pathLengthConstraint">Optional path length constraint.</param>
    /// <param name="curveName">The EC curve name (default: "nistP384").</param>
    /// <returns>A pre-configured builder.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/> is <see langword="null"/>.</exception>
    public static X509CertificateBuilder CreateCaCertificateEcDsa(
        string subject,
        int? pathLengthConstraint = null,
        string curveName = "nistP384")
    {
        if (subject is null) throw new ArgumentNullException(nameof(subject));

        return X509CertificateBuilder.CreateForEcDsa(curveName)
            .SetSubject(X509Name.FromString(subject))
            .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(10))
            .AddBasicConstraints(true, pathLengthConstraint)
            .AddKeyUsage(KeyUsageFlags.KeyCertSign | KeyUsageFlags.CrlSign);
    }

    /// <summary>
    /// Creates a builder pre-configured for an OPC UA application certificate
    /// per OPC UA specification Part 6 §6.2.2.
    /// </summary>
    /// <remarks>
    /// <para>Sets the following extensions:</para>
    /// <list type="bullet">
    /// <item><description>Basic Constraints: CA=false</description></item>
    /// <item><description>Key Usage: DigitalSignature, NonRepudiation, KeyEncipherment, DataEncipherment (critical)</description></item>
    /// <item><description>Extended Key Usage: ServerAuth, ClientAuth</description></item>
    /// <item><description>Subject Alternative Name: application URI + DNS names</description></item>
    /// </list>
    /// </remarks>
    /// <param name="subject">The certificate subject (e.g., "CN=MyApp, O=MyOrg, C=US").</param>
    /// <param name="applicationUri">The OPC UA application URI (e.g., "urn:myhost:MyApp").</param>
    /// <param name="dnsNames">DNS names for the SAN extension (typically the hostname).</param>
    /// <param name="keySizeBits">The RSA key size in bits (default: 2048).</param>
    /// <returns>A pre-configured builder.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/>, <paramref name="applicationUri"/>, or <paramref name="dnsNames"/> is <see langword="null"/>.</exception>
    public static X509CertificateBuilder CreateOpcUa(
        string subject,
        string applicationUri,
        string[] dnsNames,
        int keySizeBits = 2048)
    {
        if (subject is null) throw new ArgumentNullException(nameof(subject));
        if (applicationUri is null) throw new ArgumentNullException(nameof(applicationUri));
        if (dnsNames is null) throw new ArgumentNullException(nameof(dnsNames));

        var sanEntries = new (SanType, string)[1 + dnsNames.Length];
        sanEntries[0] = (SanType.Uri, applicationUri);
        for (int i = 0; i < dnsNames.Length; i++)
            sanEntries[i + 1] = (SanType.DnsName, dnsNames[i]);

        return X509CertificateBuilder.CreateForRsa(keySizeBits)
            .SetSubject(X509Name.FromString(subject))
            .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(2))
            .AddBasicConstraints(false)
            .AddKeyUsage(
                KeyUsageFlags.DigitalSignature |
                KeyUsageFlags.NonRepudiation |
                KeyUsageFlags.KeyEncipherment |
                KeyUsageFlags.DataEncipherment)
            .AddExtendedKeyUsage(
                ExtensionParsers.ExtendedKeyUsage.OidServerAuth,
                ExtensionParsers.ExtendedKeyUsage.OidClientAuth)
            .AddSubjectAlternativeName(sanEntries);
    }

    /// <summary>
    /// Creates a builder pre-configured for an OPC UA application certificate using ECDSA.
    /// </summary>
    /// <param name="subject">The certificate subject.</param>
    /// <param name="applicationUri">The OPC UA application URI.</param>
    /// <param name="dnsNames">DNS names for the SAN extension.</param>
    /// <param name="curveName">The EC curve name (default: "nistP256").</param>
    /// <returns>A pre-configured builder.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="subject"/>, <paramref name="applicationUri"/>, or <paramref name="dnsNames"/> is <see langword="null"/>.</exception>
    public static X509CertificateBuilder CreateOpcUaEcDsa(
        string subject,
        string applicationUri,
        string[] dnsNames,
        string curveName = "nistP256")
    {
        if (subject is null) throw new ArgumentNullException(nameof(subject));
        if (applicationUri is null) throw new ArgumentNullException(nameof(applicationUri));
        if (dnsNames is null) throw new ArgumentNullException(nameof(dnsNames));

        var sanEntries = new (SanType, string)[1 + dnsNames.Length];
        sanEntries[0] = (SanType.Uri, applicationUri);
        for (int i = 0; i < dnsNames.Length; i++)
            sanEntries[i + 1] = (SanType.DnsName, dnsNames[i]);

        return X509CertificateBuilder.CreateForEcDsa(curveName)
            .SetSubject(X509Name.FromString(subject))
            .SetValidity(DateTimeOffset.UtcNow, DateTimeOffset.UtcNow.AddYears(2))
            .AddBasicConstraints(false)
            .AddKeyUsage(
                KeyUsageFlags.DigitalSignature |
                KeyUsageFlags.NonRepudiation |
                KeyUsageFlags.KeyEncipherment |
                KeyUsageFlags.DataEncipherment)
            .AddExtendedKeyUsage(
                ExtensionParsers.ExtendedKeyUsage.OidServerAuth,
                ExtensionParsers.ExtendedKeyUsage.OidClientAuth)
            .AddSubjectAlternativeName(sanEntries);
    }
}
