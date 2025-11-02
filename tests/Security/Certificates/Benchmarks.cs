// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates.Tests;

using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using BenchmarkDotNet.Attributes;
using CryptoHives.Security.Certificates;
using CryptoHives.Security.Certificates.X509Crl;

/// <summary>
/// Benchmarks for the CertificateFactory class.
/// </summary>
[MemoryDiagnoser]
public class Benchmarks
{
    X509Certificate2 _issuerCert;
    IX509CRL _issuerCrl;
    X509CRL _x509Crl;
    X509Certificate2 _certificate;
    byte[] _randomByteArray;
    byte[] _encryptedByteArray;
    byte[] _signature;
    RSA _rsaPrivateKey;
    RSA _rsaPublicKey;

    /// <summary>
    /// Setup variables for running benchmarks.
    /// </summary>
    [GlobalSetup]
    public void GlobalSetup()
    {
        _issuerCert = CertificateBuilder.Create("CN=Root CA")
                        .SetCAConstraint()
                        .CreateForRSA();
        _certificate = CertificateBuilder.Create("CN=TestCert")
            .SetNotBefore(DateTime.Today.AddDays(-1))
            .AddExtension(
                new X509SubjectAltNameExtension("urn:cryptohives.org:mypc",
                new string[] { "mypc", "mypc.cryptohives.org", "192.168.1.100" }))
            .CreateForRSA();

        var crlBuilder = CrlBuilder.Create(_issuerCert.SubjectName, HashAlgorithmName.SHA256)
                       .SetThisUpdate(DateTime.UtcNow.Date)
                       .SetNextUpdate(DateTime.UtcNow.Date.AddDays(30));
        var revokedarray = new RevokedCertificate(_certificate.SerialNumber);
        crlBuilder.RevokedCertificates.Add(revokedarray);
        crlBuilder.CrlExtensions.Add(X509Extensions.BuildCRLNumber(1));
        crlBuilder.CrlExtensions.Add(X509Extensions.BuildAuthorityKeyIdentifier(_issuerCert));
        _issuerCrl = crlBuilder.CreateForRSA(_issuerCert);
        _x509Crl = new X509CRL(_issuerCrl.RawData);

        var random = new Random();
        _rsaPrivateKey = _certificate.GetRSAPrivateKey();
        _rsaPublicKey = _certificate.GetRSAPublicKey();

        // blob size for RSA padding OaepSHA256
        int blobSize = _rsaPublicKey.KeySize / 8 - 66;
        _randomByteArray = new byte[blobSize];
        random.NextBytes(_randomByteArray);

        _encryptedByteArray = _rsaPublicKey.Encrypt(_randomByteArray, RSAEncryptionPadding.OaepSHA256);
        _signature = _rsaPrivateKey.SignData(_randomByteArray, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

    /// <summary>
    /// Cleanup variables used in benchmarks.
    /// </summary>
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _issuerCert?.Dispose();
        _certificate?.Dispose();
        _rsaPrivateKey?.Dispose();
        _rsaPublicKey?.Dispose();
    }


    /// <summary>
    /// Create a certificate and dispose.
    /// </summary>
    [Benchmark]
    public void CreateCertificate()
    {
        using X509Certificate2 cert = CertificateBuilder.Create("CN=Create").CreateForRSA();
    }

    /// <summary>
    /// Get the private key from a certificate and dispose it.
    /// </summary>
    [Benchmark]
    public void GetPrivateKey()
    {
        using var privateKey = _certificate.GetRSAPrivateKey();
    }

    /// <summary>
    /// Get the private key from a certificate, export parameters and dispose it.
    /// </summary>
    [Benchmark]
    public void GetPrivateKeyAndExport()
    {
        using var privateKey = _certificate.GetRSAPrivateKey();
        privateKey.ExportParameters(true);
    }

    /// <summary>
    /// Get the public key from a certificate and dispose it.
    /// </summary>
    [Benchmark]
    public void GetPublicKey()
    {
        using var publicKey = _certificate.GetRSAPublicKey();
    }

    /// <summary>
    /// Get the public key from a certificate, export parameters and dispose it.
    /// </summary>
    [Benchmark]
    public void GetPublicKeyAndExport()
    {
        using var publicKey = _certificate.GetRSAPublicKey();
        publicKey.ExportParameters(false);
    }

    /// <summary>
    /// Encrypt one blob with padding OAEP SHA256.
    /// </summary>
    [Benchmark]
    public void EncryptOAEPSHA256()
    {
        _ = _rsaPublicKey.Encrypt(_randomByteArray, RSAEncryptionPadding.OaepSHA256);
    }

    /// <summary>
    /// Decrypt one blob with padding OAEP SHA256.
    /// </summary>
    [Benchmark]
    public void DecryptOAEPSHA256()
    {
        _ = _rsaPrivateKey.Decrypt(_encryptedByteArray, RSAEncryptionPadding.OaepSHA256);
    }

    /// <summary>
    /// Verify signature of a random byte blob using SHA256 / PKCS#1.
    /// </summary>
    [Benchmark]
    public void VerifySHA256PKCS1()
    {
        _ = _rsaPublicKey.VerifyData(_randomByteArray, _signature,
            HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

    /// <summary>
    /// Sign a random byte blob using SHA256 / PKCS#1.
    /// </summary>
    [Benchmark]
    public void SignSHA256PKCS1()
    {
        _ = _rsaPrivateKey.SignData(_randomByteArray,
            HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

    /// <summary>
    /// Verify a self signed signature.
    /// </summary>
    [Benchmark]
    public void VerifySignature()
    {
        var signature = new X509Signature(_certificate.RawData);
        _ = signature.Verify(_certificate);
    }

    /// <summary>
    /// Create a CRL.
    /// </summary>
    [Benchmark]
    public void CreateCRL()
    {
        // little endian byte array as serial number?
        byte[] serial = new byte[] { 1, 2, 3 };
        var revokedarray = new RevokedCertificate(serial);

        var crlBuilder = CrlBuilder.Create(_issuerCert.SubjectName, HashAlgorithmName.SHA256)
            .SetThisUpdate(DateTime.UtcNow.Date)
            .SetNextUpdate(DateTime.UtcNow.Date.AddDays(30));
        crlBuilder.RevokedCertificates.Add(revokedarray);
        crlBuilder.CrlExtensions.Add(X509Extensions.BuildCRLNumber(1));
        crlBuilder.CrlExtensions.Add(X509Extensions.BuildAuthorityKeyIdentifier(_issuerCert));
        _ = crlBuilder.CreateForRSA(_issuerCert);
    }

    /// <summary>
    /// Decode a CRL.
    /// </summary>
    [Benchmark]
    public void DecodeCRLSignature()
    {
        _ = new X509CRL(_issuerCrl.RawData);
    }

    /// <summary>
    /// Verify signature of a CRL.
    /// </summary>
    [Benchmark]
    public void VerifyCRLSignature()
    {
        _ = _x509Crl.VerifySignature(_issuerCert, true);
    }

    /// <summary>
    /// Find a specific cert extension.
    /// </summary>
    [Benchmark]
    public void FindExtension()
    {
        _ = X509Extensions.FindExtension<X509BasicConstraintsExtension>(_certificate.Extensions);
    }

    /// <summary>
    /// Export certificate as PEM.
    /// </summary>
    [Benchmark]
    public void ExportCertificateAsPEM()
    {
        _ = PEMWriter.ExportCertificateAsPEM(_certificate);
    }

    /// <summary>
    /// Export private key as PEM.
    /// </summary>
    [Benchmark]
    public void ExportPrivateKeyAsPEM()
    {
        _ = PEMWriter.ExportPrivateKeyAsPEM(_certificate);
    }
}


