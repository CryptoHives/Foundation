// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates.X509Crl;

using System;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Describes the three required fields of a X509 Certificate and CRL.
/// </summary>
public class X509Signature
{
    /// <summary>
    /// The field contains the ASN.1 data to be signed.
    /// </summary>
    public byte[] Tbs { get; private set; }

    /// <summary>
    /// The signature of the data.
    /// </summary>
    public byte[] Signature { get; private set; }

    /// <summary>
    /// The encoded signature algorithm that was used for signing.
    /// </summary>
    public byte[]? SignatureAlgorithmIdentifier { get; private set; }

    /// <summary>
    /// The signature algorithm as Oid string.
    /// </summary>
    public string SignatureAlgorithm { get; private set; }

    /// <summary>
    /// The hash algorithm used for signing.
    /// </summary>
    public HashAlgorithmName Name { get; private set; }

    /// <summary>
    /// Initialize and decode the sequence with binary ASN.1 encoded CRL or certificate.
    /// </summary>
    /// <param name="signedBlob"></param>
    public X509Signature(byte[] signedBlob)
    {
        Tbs = Array.Empty<byte>();
        Signature = Array.Empty<byte>();
        SignatureAlgorithm = string.Empty;
        Decode(signedBlob);
    }

    /// <summary>
    /// Initialize the X509 signature values.
    /// </summary>
    /// <param name="tbs">The data to be signed.</param>
    /// <param name="signature">The signature of the data.</param>
    /// <param name="signatureAlgorithmIdentifier">The algorithm used to create the signature.</param>
    public X509Signature(byte[] tbs, byte[] signature, byte[] signatureAlgorithmIdentifier)
    {
        Tbs = tbs;
        Signature = signature;
        SignatureAlgorithmIdentifier = signatureAlgorithmIdentifier;
        SignatureAlgorithm = DecodeAlgorithm(signatureAlgorithmIdentifier);
        Name = Oids.GetHashAlgorithmName(SignatureAlgorithm);
    }

    /// <summary>
    /// Encode Tbs with a signature in ASN format.
    /// </summary>
    /// <returns>X509 ASN format of EncodedData+SignatureOID+Signature bytes.</returns>
    public byte[] Encode()
    {
        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;

        Asn1Tag tag = Asn1Tag.Sequence;
        writer.PushSequence(tag);

        // write Tbs encoded data
        writer.WriteEncodedValue(Tbs);

        // Signature Algorithm Identifier
        if (SignatureAlgorithmIdentifier != null)
        {
            writer.WriteEncodedValue(SignatureAlgorithmIdentifier);
        }
        else
        {
            writer.PushSequence();
            string signatureAlgorithmIdentifier = Oids.GetRSAOid(Name);
            writer.WriteObjectIdentifier(signatureAlgorithmIdentifier);
            writer.WriteNull();
            writer.PopSequence();
        }

        // Add signature
        writer.WriteBitString(Signature);

        writer.PopSequence(tag);

        return pooledWriter.Encode();
    }

    /// <summary>
    /// Decoder for the signature sequence.
    /// </summary>
    /// <param name="crl">The encoded CRL or certificate sequence.</param>
    private void Decode(byte[] crl)
    {
        try
        {
            var crlReader = new AsnReader(crl, AsnEncodingRules.DER);
            AsnReader seqReader = crlReader.ReadSequence(Asn1Tag.Sequence);
            // Tbs encoded data
            Tbs = seqReader.ReadEncodedValue().ToArray();

            // Signature Algorithm Identifier
            AsnReader sigOid = seqReader.ReadSequence();
            SignatureAlgorithm = sigOid.ReadObjectIdentifier();
            Name = Oids.GetHashAlgorithmName(SignatureAlgorithm);

            // Signature
            Signature = seqReader.ReadBitString(out int unusedBitCount);
            if (unusedBitCount != 0)
            {
                throw new AsnContentException("Unexpected data in signature.");
            }
            seqReader.ThrowIfNotEmpty();
            return;
            throw new CryptographicException("No valid data in the X509 signature.");
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the X509 signature.", ace);
        }
    }

    /// <summary>
    /// Verify the signature with the public key of the signer.
    /// </summary>
    /// <param name="certificate"></param>
    /// <returns>true if the signature is valid.</returns>
    public bool Verify(X509Certificate2 certificate)
    {
        switch (SignatureAlgorithm)
        {
            case Oids.RsaPkcs1Sha1:
            case Oids.RsaPkcs1Sha256:
            case Oids.RsaPkcs1Sha384:
            case Oids.RsaPkcs1Sha512:
                return VerifyForRSA(certificate, RSASignaturePadding.Pkcs1);

            case Oids.ECDsaWithSha1:
            case Oids.ECDsaWithSha256:
            case Oids.ECDsaWithSha384:
            case Oids.ECDsaWithSha512:
                return VerifyForECDsa(certificate);

            default:
                throw new CryptographicException("Failed to verify signature due to unknown signature algorithm.");
        }
    }

    /// <summary>
    /// Verify the signature with the RSA public key of the signer.
    /// </summary>
    private bool VerifyForRSA(X509Certificate2 certificate, RSASignaturePadding padding)
    {
        using RSA? rsa = certificate.GetRSAPublicKey();
        if (rsa == null)
        {
            throw new CryptographicException("Certificate does not contain an RSA public key.");
        }
        return rsa.VerifyData(Tbs, Signature, Name, padding);
    }

    /// <summary>
    /// Verify the signature with the ECC public key of the signer.
    /// </summary>
    private bool VerifyForECDsa(X509Certificate2 certificate)
    {
        using ECDsa? key = certificate.GetECDsaPublicKey();
        if (key == null)
        {
            throw new CryptographicException("Certificate does not contain an ECDsa public key.");
        }
        byte[] decodedSignature = DecodeECDsa(Signature, key.KeySize);
        return key.VerifyData(Tbs, decodedSignature, Name);
    }

    /// <summary>
    /// Decode the algorithm that was used for encoding.
    /// </summary>
    /// <param name="oid">The ASN.1 encoded algorithm oid.</param>
    /// <returns></returns>
    private static string DecodeAlgorithm(byte[] oid)
    {
        var seqReader = new AsnReader(oid, AsnEncodingRules.DER);
        AsnReader sigOid = seqReader.ReadSequence();
        seqReader.ThrowIfNotEmpty();
        string result = sigOid.ReadObjectIdentifier();
        if (sigOid.HasData)
        {
            sigOid.ReadNull();
        }
        sigOid.ThrowIfNotEmpty();
        return result;
    }

    /// <summary>
    /// Encode a ECDSA signature as ASN.1.
    /// </summary>
    /// <param name="signature">The signature to encode as ASN.1</param>
    private static byte[] EncodeECDsa(byte[] signature)
    {
        // Encode from IEEE signature format to ASN1 DER encoded 
        // signature format for ecdsa certificates.
        // ECDSA-Sig-Value ::= SEQUENCE { r INTEGER, s INTEGER }
        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;
        Asn1Tag tag = Asn1Tag.Sequence;
        writer.PushSequence(tag);

        int segmentLength = signature.Length / 2;
        writer.WriteIntegerUnsigned(new ReadOnlySpan<byte>(signature, 0, segmentLength));
        writer.WriteIntegerUnsigned(new ReadOnlySpan<byte>(signature, segmentLength, segmentLength));

        writer.PopSequence(tag);

        return pooledWriter.Encode();
    }

    /// <summary>
    /// Decode a ECDSA signature from ASN.1.
    /// </summary>
    /// <param name="signature">The signature to decode from ASN.1</param>
    /// <param name="keySize">The keySize in bits.</param>
    private static byte[] DecodeECDsa(ReadOnlyMemory<byte> signature, int keySize)
    {
        var reader = new AsnReader(signature, AsnEncodingRules.DER);
        AsnReader seqReader = reader.ReadSequence();
        reader.ThrowIfNotEmpty();
        ReadOnlyMemory<byte> r = seqReader.ReadIntegerBytes();
        ReadOnlyMemory<byte> s = seqReader.ReadIntegerBytes();
        seqReader.ThrowIfNotEmpty();
        keySize >>= 3;
        if (r.Span[0] == 0 && r.Length > keySize)
        {
            r = r.Slice(1);
        }
        if (s.Span[0] == 0 && s.Length > keySize)
        {
            s = s.Slice(1);
        }
        byte[] result = new byte[2 * keySize];
        int offset = keySize - r.Length;
        r.CopyTo(new Memory<byte>(result, offset, r.Length));
        offset = 2 * keySize - s.Length;
        s.CopyTo(new Memory<byte>(result, offset, s.Length));
        return result;
    }
}

