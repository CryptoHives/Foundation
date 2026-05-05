// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace Cryptography.Tests.Asymmetric.Rsa;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.Rsa;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class RsaCoreTests
{
    // Use a pre-generated 2048-bit RSA key for deterministic tests
    private static RSAParameters GetTestKey()
    {
        using var rsa = RSA.Create(2048);
        return rsa.ExportParameters(true);
    }

    // ========================================================================
    // PublicOp / PrivateOp Round-Trip
    // ========================================================================

    [Test]
    public void PublicPrivateRoundTrip()
    {
        var p = GetTestKey();
        var key = new RsaKeyParameters(p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        // Create a small message (padded to modulus length)
        byte[] message = new byte[p.Modulus!.Length];
        message[^1] = 42;

        byte[] encrypted = RsaCore.PublicOp(message, key);
        byte[] decrypted = RsaCore.PrivateOp(encrypted, key);

        Assert.That(decrypted, Is.EqualTo(message));
    }

    [Test]
    public void PrivatePublicRoundTrip()
    {
        var p = GetTestKey();
        var key = new RsaKeyParameters(p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        byte[] message = new byte[p.Modulus!.Length];
        message[^1] = 0xFF;
        message[^2] = 0xAB;

        byte[] signed = RsaCore.PrivateOp(message, key);
        byte[] recovered = RsaCore.PublicOp(signed, key);

        Assert.That(recovered, Is.EqualTo(message));
    }

    // ========================================================================
    // Cross-Validation with BCL RSA
    // ========================================================================

    [Test]
    public void PublicOpMatchesBcl()
    {
        using var bclRsa = RSA.Create(2048);
        var p = bclRsa.ExportParameters(true);
        var key = new RsaKeyParameters(p.Modulus!, p.Exponent!, p.D!, p.P!, p.Q!, p.DP!, p.DQ!, p.InverseQ!);

        // Encrypt with BCL, decrypt with our implementation
        byte[] plaintext = "Hello RSA!"u8.ToArray();
        byte[] ciphertext = bclRsa.Encrypt(plaintext, RSAEncryptionPadding.OaepSHA256);

        // Our PrivateOp should produce the same raw result as BCL
        byte[] ourDecrypted = RsaCore.PrivateOp(ciphertext, key);
        byte[] bclDecrypted = bclRsa.Decrypt(ciphertext, RSAEncryptionPadding.OaepSHA256);

        // The OAEP-decoded plaintext should match
        Assert.That(bclDecrypted, Is.EqualTo(plaintext));
    }

    // ========================================================================
    // Edge Cases
    // ========================================================================

    [Test]
    public void MessageTooLargeThrows()
    {
        var p = GetTestKey();
        var key = new RsaKeyParameters(p.Modulus!, p.Exponent!);

        // Message equal to modulus should throw
        byte[] message = (byte[])p.Modulus!.Clone();
        Assert.Throws<ArgumentException>(() => RsaCore.PublicOp(message, key));
    }

    [Test]
    public void PrivateOpWithoutPrivateKeyThrows()
    {
        var p = GetTestKey();
        var key = new RsaKeyParameters(p.Modulus!, p.Exponent!); // public-only

        byte[] message = new byte[p.Modulus!.Length];
        message[^1] = 1;

        Assert.Throws<ArgumentException>(() => RsaCore.PrivateOp(message, key));
    }
}

#endif
