// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace Cryptography.Tests.Asymmetric.Rsa;

using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class RsaManagedTests
{
    // ========================================================================
    // PKCS#1 v1.5 Signature
    // ========================================================================

    [Test]
    [TestCase("SHA256")]
    [TestCase("SHA384")]
    [TestCase("SHA512")]
    public void Pkcs1SignVerifyRoundTrip(string hashName)
    {
        var hashAlg = new HashAlgorithmName(hashName);
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Test data for PKCS1 signature"u8.ToArray();
        byte[] hash = ComputeHash(data, hashAlg);

        byte[] signature = managed.SignHash(hash, hashAlg, RSASignaturePadding.Pkcs1);
        bool valid = managed.VerifyHash(hash, signature, hashAlg, RSASignaturePadding.Pkcs1);

        Assert.That(valid, Is.True);
    }

    [Test]
    public void Pkcs1SignatureVerifiableByBcl()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Cross validate PKCS1"u8.ToArray();
        byte[] hash = SHA256.HashData(data);

        // Sign with managed
        byte[] signature = managed.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        // Verify with BCL
        bool valid = bclRsa.VerifyHash(hash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        Assert.That(valid, Is.True);
    }

    [Test]
    public void BclSignatureVerifiableByManaged()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] data = "BCL signs, managed verifies"u8.ToArray();
        byte[] hash = SHA256.HashData(data);

        // Sign with BCL
        byte[] signature = bclRsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        // Verify with managed
        bool valid = managed.VerifyHash(hash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        Assert.That(valid, Is.True);
    }

    [Test]
    public void Pkcs1WrongHashFails()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Original data"u8.ToArray();
        byte[] hash = SHA256.HashData(data);
        byte[] wrongHash = SHA256.HashData("Wrong data"u8.ToArray());

        byte[] signature = managed.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        bool valid = managed.VerifyHash(wrongHash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

        Assert.That(valid, Is.False);
    }

    // ========================================================================
    // PSS Signature
    // ========================================================================

    [Test]
    [TestCase("SHA256")]
    [TestCase("SHA384")]
    [TestCase("SHA512")]
    public void PssSignVerifyRoundTrip(string hashName)
    {
        var hashAlg = new HashAlgorithmName(hashName);
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Test data for PSS signature"u8.ToArray();
        byte[] hash = ComputeHash(data, hashAlg);

        byte[] signature = managed.SignHash(hash, hashAlg, RSASignaturePadding.Pss);
        bool valid = managed.VerifyHash(hash, signature, hashAlg, RSASignaturePadding.Pss);

        Assert.That(valid, Is.True);
    }

    [Test]
    public void PssSignatureVerifiableByBcl()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Cross validate PSS"u8.ToArray();
        byte[] hash = SHA256.HashData(data);

        // Sign with managed
        byte[] signature = managed.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);

        // Verify with BCL
        bool valid = bclRsa.VerifyHash(hash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        Assert.That(valid, Is.True);
    }

    [Test]
    public void BclPssSignatureVerifiableByManaged()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] data = "BCL PSS signs, managed verifies"u8.ToArray();
        byte[] hash = SHA256.HashData(data);

        // Sign with BCL
        byte[] signature = bclRsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);

        // Verify with managed
        bool valid = managed.VerifyHash(hash, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pss);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // PKCS#1 v1.5 Encryption
    // ========================================================================

    [Test]
    public void Pkcs1EncryptDecryptRoundTrip()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] plaintext = "Hello PKCS1 encryption!"u8.ToArray();
        byte[] ciphertext = managed.Encrypt(plaintext, RSAEncryptionPadding.Pkcs1);
        byte[] decrypted = managed.Decrypt(ciphertext, RSAEncryptionPadding.Pkcs1);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void Pkcs1ManagedEncryptBclDecrypt()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] plaintext = "Managed encrypts, BCL decrypts"u8.ToArray();
        byte[] ciphertext = managed.Encrypt(plaintext, RSAEncryptionPadding.Pkcs1);
        byte[] decrypted = bclRsa.Decrypt(ciphertext, RSAEncryptionPadding.Pkcs1);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void Pkcs1BclEncryptManagedDecrypt()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] plaintext = "BCL encrypts, managed decrypts"u8.ToArray();
        byte[] ciphertext = bclRsa.Encrypt(plaintext, RSAEncryptionPadding.Pkcs1);
        byte[] decrypted = managed.Decrypt(ciphertext, RSAEncryptionPadding.Pkcs1);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // OAEP Encryption
    // ========================================================================

    [Test]
    [TestCase("OaepSHA1")]
    [TestCase("OaepSHA256")]
    [TestCase("OaepSHA384")]
    [TestCase("OaepSHA512")]
    public void OaepEncryptDecryptRoundTrip(string paddingName)
    {
        var padding = GetPadding(paddingName);
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] plaintext = "Hello OAEP!"u8.ToArray();
        byte[] ciphertext = managed.Encrypt(plaintext, padding);
        byte[] decrypted = managed.Decrypt(ciphertext, padding);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void OaepManagedEncryptBclDecrypt()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] plaintext = "OAEP cross-validation"u8.ToArray();
        byte[] ciphertext = managed.Encrypt(plaintext, RSAEncryptionPadding.OaepSHA256);
        byte[] decrypted = bclRsa.Decrypt(ciphertext, RSAEncryptionPadding.OaepSHA256);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    [Test]
    public void OaepBclEncryptManagedDecrypt()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);

        byte[] plaintext = "BCL OAEP to managed"u8.ToArray();
        byte[] ciphertext = bclRsa.Encrypt(plaintext, RSAEncryptionPadding.OaepSHA256);
        byte[] decrypted = managed.Decrypt(ciphertext, RSAEncryptionPadding.OaepSHA256);

        Assert.That(decrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Key Import/Export
    // ========================================================================

    [Test]
    public void ExportImportRoundTrip()
    {
        using var bclRsa = RSA.Create(2048);
        var original = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(original);
        var exported = managed.ExportParameters(true);

        Assert.That(exported.Modulus, Is.EqualTo(original.Modulus));
        Assert.That(exported.Exponent, Is.EqualTo(original.Exponent));
        Assert.That(exported.D, Is.EqualTo(original.D));
        Assert.That(exported.P, Is.EqualTo(original.P));
        Assert.That(exported.Q, Is.EqualTo(original.Q));
        Assert.That(exported.DP, Is.EqualTo(original.DP));
        Assert.That(exported.DQ, Is.EqualTo(original.DQ));
        Assert.That(exported.InverseQ, Is.EqualTo(original.InverseQ));
    }

    [Test]
    public void PublicOnlyExportOmitsPrivate()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);

        using var managed = new RsaManaged();
        managed.ImportParameters(p);
        var pubOnly = managed.ExportParameters(false);

        Assert.That(pubOnly.Modulus, Is.Not.Null);
        Assert.That(pubOnly.Exponent, Is.Not.Null);
        Assert.That(pubOnly.D, Is.Null);
        Assert.That(pubOnly.P, Is.Null);
    }

    // ========================================================================
    // Helpers
    // ========================================================================

    private static byte[] ComputeHash(byte[] data, HashAlgorithmName hashAlgorithm)
    {
        using var hasher = IncrementalHash.CreateHash(hashAlgorithm);
        hasher.AppendData(data);
        return hasher.GetHashAndReset();
    }

    private static RSAEncryptionPadding GetPadding(string name)
    {
        return name switch
        {
            "OaepSHA1" => RSAEncryptionPadding.OaepSHA1,
            "OaepSHA256" => RSAEncryptionPadding.OaepSHA256,
            "OaepSHA384" => RSAEncryptionPadding.OaepSHA384,
            "OaepSHA512" => RSAEncryptionPadding.OaepSHA512,
            _ => throw new System.ArgumentException($"Unknown padding: {name}")
        };
    }
}

#endif
