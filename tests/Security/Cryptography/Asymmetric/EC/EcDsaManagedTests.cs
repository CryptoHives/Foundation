// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if !NET462 && !NETSTANDARD2_0
namespace Cryptography.Tests.Asymmetric.EC;

using System;
using System.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Asymmetric.EC;
using NUnit.Framework;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class EcDsaManagedTests
{
    // ========================================================================
    // ECDSA Sign / Verify Round-Trip
    // ========================================================================

    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    [TestCase("nistP521")]
    public void SignVerifyRoundTrip(string curveName)
    {
        var bclCurve = ECCurve.CreateFromFriendlyName(curveName);
        using var bclEcdsa = ECDsa.Create(bclCurve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Test ECDSA sign/verify"u8.ToArray();
        byte[] hash = ComputeSha256(data);

        byte[] signature = managed.SignHash(hash);
        bool valid = managed.VerifyHash(hash, signature);

        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Cross-Validation: Managed signs, BCL verifies
    // ========================================================================

    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    [TestCase("nistP521")]
    public void ManagedSignBclVerify(string curveName)
    {
        var bclCurve = ECCurve.CreateFromFriendlyName(curveName);
        using var bclEcdsa = ECDsa.Create(bclCurve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Cross-validation managed→BCL"u8.ToArray();
        byte[] hash = ComputeSha256(data);

        byte[] signature = managed.SignHash(hash);

        bool valid = VerifyHashP1363(bclEcdsa, hash, signature);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Cross-Validation: BCL signs, Managed verifies
    // ========================================================================

    [Test]
    [TestCase("nistP256")]
    [TestCase("nistP384")]
    [TestCase("nistP521")]
    public void BclSignManagedVerify(string curveName)
    {
        var bclCurve = ECCurve.CreateFromFriendlyName(curveName);
        using var bclEcdsa = ECDsa.Create(bclCurve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] data = "Cross-validation BCL→managed"u8.ToArray();
        byte[] hash = ComputeSha256(data);

        byte[] signature = SignHashP1363(bclEcdsa, hash);

        bool valid = managed.VerifyHash(hash, signature);
        Assert.That(valid, Is.True);
    }

    // ========================================================================
    // Tampered signature fails
    // ========================================================================

    [Test]
    public void TamperedSignatureFails()
    {
        using var bclEcdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash = ComputeSha256("Original"u8.ToArray());
        byte[] signature = managed.SignHash(hash);

        signature[0] ^= 1;
        bool valid = managed.VerifyHash(hash, signature);

        Assert.That(valid, Is.False);
    }

    [Test]
    public void WrongHashFails()
    {
        using var bclEcdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash1 = ComputeSha256("Message 1"u8.ToArray());
        byte[] hash2 = ComputeSha256("Message 2"u8.ToArray());

        byte[] signature = managed.SignHash(hash1);
        bool valid = managed.VerifyHash(hash2, signature);

        Assert.That(valid, Is.False);
    }

    // ========================================================================
    // Key Import/Export
    // ========================================================================

    [Test]
    public void ExportImportRoundTrip()
    {
        using var bclEcdsa = ECDsa.Create(ECCurve.NamedCurves.nistP256);
        var original = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(original);
        var exported = managed.ExportParameters(true);

        Assert.That(exported.Q.X, Is.EqualTo(original.Q.X));
        Assert.That(exported.Q.Y, Is.EqualTo(original.Q.Y));
        Assert.That(exported.D, Is.EqualTo(original.D));
    }
    // ========================================================================
    // Brainpool Curves
    // ========================================================================

    [Test]
    [TestCase("1.3.36.3.3.2.8.1.1.7", "brainpoolP256r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.11", "brainpoolP384r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.13", "brainpoolP512r1")]
    public void BrainpoolSignVerifyRoundTrip(string oid, string name)
    {
        var curve = ECCurve.CreateFromValue(oid);
        using var bclEcdsa = ECDsa.Create(curve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash = ComputeSha256("Brainpool test"u8.ToArray());
        byte[] signature = managed.SignHash(hash);
        bool valid = managed.VerifyHash(hash, signature);

        Assert.That(valid, Is.True, $"Round-trip failed for {name}");
    }

    [Test]
    [TestCase("1.3.36.3.3.2.8.1.1.7", "brainpoolP256r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.11", "brainpoolP384r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.13", "brainpoolP512r1")]
    public void BrainpoolManagedSignBclVerify(string oid, string name)
    {
        var curve = ECCurve.CreateFromValue(oid);
        using var bclEcdsa = ECDsa.Create(curve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash = ComputeSha256("Brainpool cross-validation"u8.ToArray());
        byte[] signature = managed.SignHash(hash);

        bool valid = VerifyHashP1363(bclEcdsa, hash, signature);
        Assert.That(valid, Is.True, $"Managed→BCL failed for {name}");
    }

    [Test]
    [TestCase("1.3.36.3.3.2.8.1.1.7", "brainpoolP256r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.11", "brainpoolP384r1")]
    [TestCase("1.3.36.3.3.2.8.1.1.13", "brainpoolP512r1")]
    public void BrainpoolBclSignManagedVerify(string oid, string name)
    {
        var curve = ECCurve.CreateFromValue(oid);
        using var bclEcdsa = ECDsa.Create(curve);
        var p = bclEcdsa.ExportParameters(true);

        using var managed = new EcDsaManaged();
        managed.ImportParameters(p);

        byte[] hash = ComputeSha256("Brainpool cross-validation BCL→managed"u8.ToArray());
        byte[] signature = SignHashP1363(bclEcdsa, hash);

        bool valid = managed.VerifyHash(hash, signature);
        Assert.That(valid, Is.True, $"BCL→Managed failed for {name}");
    }

    private static byte[] ComputeSha256(byte[] data)
    {
#if NET8_0_OR_GREATER
        return SHA256.HashData(data);
#else
        using var sha = SHA256.Create();
        return sha.ComputeHash(data);
#endif
    }

    private static byte[] SignHashP1363(ECDsa ecdsa, byte[] hash)
    {
#if NET8_0_OR_GREATER
        return ecdsa.SignHash(hash, DSASignatureFormat.IeeeP1363FixedFieldConcatenation);
#else
        return DerToP1363(ecdsa.SignHash(hash), ecdsa.KeySize);
#endif
    }

    private static bool VerifyHashP1363(ECDsa ecdsa, byte[] hash, byte[] signature)
    {
#if NET8_0_OR_GREATER
        return ecdsa.VerifyHash(hash, signature, DSASignatureFormat.IeeeP1363FixedFieldConcatenation);
#else
        return ecdsa.VerifyHash(hash, P1363ToDer(signature));
#endif
    }

    private static byte[] DerToP1363(byte[] derSignature, int keySizeBits)
    {
        int fieldSize = (keySizeBits + 7) / 8;
        int offset = 0;

        if (derSignature[offset++] != 0x30) throw new CryptographicException("Invalid DER signature.");
        int seqLength = ReadDerLength(derSignature, ref offset);
        if (offset + seqLength != derSignature.Length) throw new CryptographicException("Invalid DER sequence length.");

        byte[] r = ReadDerInteger(derSignature, ref offset);
        byte[] s = ReadDerInteger(derSignature, ref offset);

        byte[] p1363 = new byte[fieldSize * 2];
        CopyIntToFixed(r, p1363, 0, fieldSize);
        CopyIntToFixed(s, p1363, fieldSize, fieldSize);
        return p1363;
    }

    private static byte[] P1363ToDer(byte[] p1363Signature)
    {
        if ((p1363Signature.Length & 1) != 0) throw new CryptographicException("Invalid P1363 signature length.");

        int fieldSize = p1363Signature.Length / 2;
        byte[] r = new byte[fieldSize];
        byte[] s = new byte[fieldSize];
        Buffer.BlockCopy(p1363Signature, 0, r, 0, fieldSize);
        Buffer.BlockCopy(p1363Signature, fieldSize, s, 0, fieldSize);

        byte[] derR = EncodeDerInteger(r);
        byte[] derS = EncodeDerInteger(s);
        int contentLength = derR.Length + derS.Length;

        byte[] lengthEncoding = EncodeDerLength(contentLength);
        byte[] result = new byte[1 + lengthEncoding.Length + contentLength];
        int offset = 0;
        result[offset++] = 0x30;
        Buffer.BlockCopy(lengthEncoding, 0, result, offset, lengthEncoding.Length);
        offset += lengthEncoding.Length;
        Buffer.BlockCopy(derR, 0, result, offset, derR.Length);
        offset += derR.Length;
        Buffer.BlockCopy(derS, 0, result, offset, derS.Length);
        return result;
    }

    private static byte[] ReadDerInteger(byte[] data, ref int offset)
    {
        if (data[offset++] != 0x02) throw new CryptographicException("Invalid DER integer.");
        int length = ReadDerLength(data, ref offset);
        byte[] value = new byte[length];
        Buffer.BlockCopy(data, offset, value, 0, length);
        offset += length;
        return value;
    }

    private static int ReadDerLength(byte[] data, ref int offset)
    {
        int first = data[offset++];
        if ((first & 0x80) == 0)
        {
            return first;
        }

        int byteCount = first & 0x7F;
        if (byteCount == 0 || byteCount > 4) throw new CryptographicException("Invalid DER length.");

        int length = 0;
        for (int i = 0; i < byteCount; i++)
        {
            length = (length << 8) | data[offset++];
        }

        return length;
    }

    private static byte[] EncodeDerInteger(byte[] value)
    {
        int firstNonZero = 0;
        while (firstNonZero < value.Length - 1 && value[firstNonZero] == 0)
        {
            firstNonZero++;
        }

        int length = value.Length - firstNonZero;
        bool needsLeadingZero = (value[firstNonZero] & 0x80) != 0;
        int integerLength = length + (needsLeadingZero ? 1 : 0);

        byte[] lengthEncoding = EncodeDerLength(integerLength);
        byte[] result = new byte[1 + lengthEncoding.Length + integerLength];

        int offset = 0;
        result[offset++] = 0x02;
        Buffer.BlockCopy(lengthEncoding, 0, result, offset, lengthEncoding.Length);
        offset += lengthEncoding.Length;

        if (needsLeadingZero)
        {
            result[offset++] = 0x00;
        }

        Buffer.BlockCopy(value, firstNonZero, result, offset, length);
        return result;
    }

    private static byte[] EncodeDerLength(int length)
    {
        if (length < 0x80)
        {
            return new[] { (byte)length };
        }

        if (length <= 0xFF)
        {
            return new[] { (byte)0x81, (byte)length };
        }

        return new[] { (byte)0x82, (byte)(length >> 8), (byte)length };
    }

    private static void CopyIntToFixed(byte[] integerBytes, byte[] destination, int destinationOffset, int fieldSize)
    {
        int sourceOffset = 0;
        while (sourceOffset < integerBytes.Length - 1 && integerBytes[sourceOffset] == 0)
        {
            sourceOffset++;
        }

        int length = integerBytes.Length - sourceOffset;
        if (length > fieldSize)
        {
            sourceOffset += length - fieldSize;
            length = fieldSize;
        }

        Buffer.BlockCopy(integerBytes, sourceOffset, destination, destinationOffset + fieldSize - length, length);
    }
}
#endif
