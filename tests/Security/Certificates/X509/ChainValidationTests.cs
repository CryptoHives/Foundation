// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Asymmetric.X509;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Certificates.X509;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ChainValidationTests
{
    // ========================================================================
    // Valid Chains
    // ========================================================================

    [Test]
    public void ValidTwoLevelChain()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        var root = CreateCaCert(rootRsa, rootName);

        var leaf = CreateLeafCert(rootRsa, rootName, "CN=leaf.example.com");

        var result = X509ChainValidator.Validate(
            leaf, Array.Empty<X509Certificate>(), [root]);

        Assert.That(result.IsValid, Is.True);
        Assert.That(result.Chain, Has.Count.EqualTo(2));
        Assert.That(result.Chain[0].Subject, Is.EqualTo(leaf.Subject));
        Assert.That(result.Chain[1].Subject, Is.EqualTo(root.Subject));
    }

    [Test]
    public void ValidThreeLevelChain()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        var root = CreateCaCert(rootRsa, rootName, pathLen: 1);

        using var intRsa = RSA.Create(2048);
        var intName = X509Name.FromString("CN=Intermediate CA, C=US");
        var intermediate = CreateSignedCaCert(intRsa, intName, rootRsa, rootName, pathLen: 0);

        var leaf = CreateLeafCert(intRsa, intName, "CN=leaf.example.com");

        var result = X509ChainValidator.Validate(leaf, [intermediate], [root]);

        Assert.That(result.IsValid, Is.True);
        Assert.That(result.Chain, Has.Count.EqualTo(3));
    }

    // ========================================================================
    // Time Validity
    // ========================================================================

    [Test]
    public void ExpiredLeafReturnsNotTimeValid()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        var root = CreateCaCert(rootRsa, rootName);

        var leaf = CreateLeafCert(rootRsa, rootName, "CN=expired.example.com",
            notBefore: DateTimeOffset.UtcNow.AddDays(-365),
            notAfter: DateTimeOffset.UtcNow.AddDays(-1));

        var result = X509ChainValidator.Validate(
            leaf, Array.Empty<X509Certificate>(), [root]);

        Assert.That(result.IsValid, Is.False);
        Assert.That(result.Status.HasFlag(ChainValidationStatus.NotTimeValid), Is.True);
    }

    [Test]
    public void ValidChainWithCustomValidationTime()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        var root = CreateCaCert(rootRsa, rootName);

        var leaf = CreateLeafCert(rootRsa, rootName, "CN=leaf.example.com",
            notBefore: DateTimeOffset.UtcNow.AddDays(-30),
            notAfter: DateTimeOffset.UtcNow.AddDays(30));

        var result = X509ChainValidator.Validate(
            leaf, Array.Empty<X509Certificate>(), [root],
            validationTime: DateTimeOffset.UtcNow);

        Assert.That(result.IsValid, Is.True);
    }

    // ========================================================================
    // Trust Anchor
    // ========================================================================

    [Test]
    public void UntrustedRootReturnsUntrustedRoot()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        CreateCaCert(rootRsa, rootName);

        using var otherRsa = RSA.Create(2048);
        var otherName = X509Name.FromString("CN=Other Root, C=US");
        var untrustedRoot = CreateCaCert(otherRsa, otherName);

        var leaf = CreateLeafCert(rootRsa, rootName, "CN=leaf.example.com");

        var result = X509ChainValidator.Validate(
            leaf, Array.Empty<X509Certificate>(), [untrustedRoot]);

        Assert.That(result.IsValid, Is.False);
        Assert.That(result.Status.HasFlag(ChainValidationStatus.UntrustedRoot), Is.True);
    }

    [Test]
    public void MissingIntermediateReturnsUntrustedRoot()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        var root = CreateCaCert(rootRsa, rootName);

        using var intRsa = RSA.Create(2048);
        var intName = X509Name.FromString("CN=Int CA, C=US");
        var intermediate = CreateSignedCaCert(intRsa, intName, rootRsa, rootName, pathLen: 0);

        var leaf = CreateLeafCert(intRsa, intName, "CN=leaf.example.com");

        // Don't provide the intermediate.
        var result = X509ChainValidator.Validate(
            leaf, Array.Empty<X509Certificate>(), [root]);

        Assert.That(result.IsValid, Is.False);
        Assert.That(result.Status.HasFlag(ChainValidationStatus.UntrustedRoot), Is.True);
    }

    // ========================================================================
    // Basic Constraints
    // ========================================================================

    [Test]
    public void NonCaIntermediateReturnsInvalidBasicConstraints()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        var root = CreateCaCert(rootRsa, rootName);

        using var fakeRsa = RSA.Create(2048);
        var fakeCaName = X509Name.FromString("CN=Fake CA, C=US");
        X509Certificate fakeCa;
        using (var fakeKey = ExportKey(fakeRsa))
        using (var signingKey = ExportKey(rootRsa))
        {
            fakeCa = new X509CertificateBuilder()
                .SetSubject(fakeCaName)
                .SetSerialNumber(2L)
                .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(5))
                .SetPublicKey(fakeKey)
                .AddBasicConstraints(false)
                .BuildSignedRsa(signingKey, rootName);
        }

        using var leafRsa = RSA.Create(2048);
        X509Certificate leaf;
        using (var leafKey = ExportKey(leafRsa))
        using (var fakeSignKey = ExportKey(fakeRsa))
        {
            leaf = new X509CertificateBuilder()
                .SetSubject(X509Name.FromString("CN=leaf.example.com"))
                .SetSerialNumber(3L)
                .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddDays(365))
                .SetPublicKey(leafKey)
                .AddBasicConstraints(false)
                .BuildSignedRsa(fakeSignKey, fakeCaName);
        }

        var result = X509ChainValidator.Validate(leaf, [fakeCa], [root]);

        Assert.That(result.IsValid, Is.False);
        Assert.That(result.Status.HasFlag(ChainValidationStatus.InvalidBasicConstraints), Is.True);
    }

    // ========================================================================
    // Path Length
    // ========================================================================

    [Test]
    public void PathLengthExceeded()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        var root = CreateCaCert(rootRsa, rootName, pathLen: 0);

        using var int1Rsa = RSA.Create(2048);
        var int1Name = X509Name.FromString("CN=Int CA 1, C=US");
        var int1 = CreateSignedCaCert(int1Rsa, int1Name, rootRsa, rootName, pathLen: 0);

        using var int2Rsa = RSA.Create(2048);
        var int2Name = X509Name.FromString("CN=Int CA 2, C=US");
        var int2 = CreateSignedCaCert(int2Rsa, int2Name, int1Rsa, int1Name, pathLen: 0);

        var leaf = CreateLeafCert(int2Rsa, int2Name, "CN=leaf.example.com");

        var result = X509ChainValidator.Validate(leaf, [int1, int2], [root]);

        Assert.That(result.IsValid, Is.False);
        Assert.That(result.Status.HasFlag(ChainValidationStatus.PathLengthExceeded), Is.True);
    }

    // ========================================================================
    // Revocation
    // ========================================================================

    [Test]
    public void RevokedCertReturnsRevoked()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        var root = CreateCaCert(rootRsa, rootName);

        var leaf = CreateLeafCert(rootRsa, rootName, "CN=revoked.example.com");

        var now = DateTimeOffset.UtcNow;
        using var crlKey = ExportKey(rootRsa);
        var crl = new X509CrlBuilder()
            .SetIssuer(rootName)
            .SetThisUpdate(now.AddDays(-1))
            .SetNextUpdate(now.AddDays(30))
            .AddRevokedCertificate(leaf.SerialNumber, now.AddHours(-1), CrlReason.KeyCompromise)
            .BuildSignedRsa(crlKey);

        var result = X509ChainValidator.Validate(
            leaf, Array.Empty<X509Certificate>(), [root], [crl]);

        Assert.That(result.IsValid, Is.False);
        Assert.That(result.Status.HasFlag(ChainValidationStatus.Revoked), Is.True);
    }

    // ========================================================================
    // Error Details
    // ========================================================================

    [Test]
    public void ErrorsContainDescriptiveMessages()
    {
        using var rootRsa = RSA.Create(2048);
        var rootName = X509Name.FromString("CN=Root CA, C=US");
        var root = CreateCaCert(rootRsa, rootName);

        var leaf = CreateLeafCert(rootRsa, rootName, "CN=expired.example.com",
            notBefore: DateTimeOffset.UtcNow.AddDays(-365),
            notAfter: DateTimeOffset.UtcNow.AddDays(-1));

        var result = X509ChainValidator.Validate(
            leaf, Array.Empty<X509Certificate>(), [root]);

        Assert.That(result.Errors, Is.Not.Empty);
        Assert.That(result.Errors[0], Does.Contain("not time-valid"));
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static RsaKeyParameters ExportKey(RSA rsa)
    {
        var p = rsa.ExportParameters(true);
        return new RsaKeyParameters(
            p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);
    }

    private static X509Certificate CreateCaCert(RSA rsa, X509Name name, int pathLen = -1)
    {
        using var key = ExportKey(rsa);
        return new X509CertificateBuilder()
            .SetSubject(name)
            .SetSerialNumber(1L)
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10))
            .SetPublicKey(key)
            .AddBasicConstraints(true, pathLen >= 0 ? pathLen : null)
            .AddKeyUsage(KeyUsage.KeyCertSign | KeyUsage.CrlSign)
            .BuildSelfSigned(key);
    }

    private static X509Certificate CreateSignedCaCert(
        RSA subjectRsa, X509Name subjectName,
        RSA issuerRsa, X509Name issuerName, int pathLen = -1)
    {
        using var subjectKey = ExportKey(subjectRsa);
        using var issuerKey = ExportKey(issuerRsa);
        return new X509CertificateBuilder()
            .SetSubject(subjectName)
            .SetSerialNumber(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
            .SetValidity(DateTimeOffset.UtcNow.AddDays(-1), DateTimeOffset.UtcNow.AddYears(10))
            .SetPublicKey(subjectKey)
            .AddBasicConstraints(true, pathLen >= 0 ? pathLen : null)
            .AddKeyUsage(KeyUsage.KeyCertSign | KeyUsage.CrlSign)
            .BuildSignedRsa(issuerKey, issuerName);
    }

    private static X509Certificate CreateLeafCert(
        RSA issuerRsa, X509Name issuerName, string subjectCn,
        DateTimeOffset? notBefore = null, DateTimeOffset? notAfter = null)
    {
        using var leafRsa = RSA.Create(2048);
        using var leafKey = ExportKey(leafRsa);
        using var issuerKey = ExportKey(issuerRsa);

        return new X509CertificateBuilder()
            .SetSubject(X509Name.FromString(subjectCn))
            .SetSerialNumber(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds())
            .SetValidity(
                notBefore ?? DateTimeOffset.UtcNow.AddDays(-1),
                notAfter ?? DateTimeOffset.UtcNow.AddDays(365))
            .SetPublicKey(leafKey)
            .AddBasicConstraints(false)
            .AddKeyUsage(KeyUsage.DigitalSignature)
            .BuildSignedRsa(issuerKey, issuerName);
    }
}
