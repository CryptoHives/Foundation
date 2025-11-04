// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Security.Certificates.Tests;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CryptoHives.Security.Certificates.X509Crl;

#region KeyHashPair Helper
public class KeyHashPair : IFormattable
{
    public KeyHashPair(ushort keySize, HashAlgorithmName hashAlgorithmName)
    {
        KeySize = keySize;
        HashAlgorithmName = hashAlgorithmName;
        if (hashAlgorithmName == HashAlgorithmName.SHA1)
        {
            HashSize = 160;
        }
        else if (hashAlgorithmName == HashAlgorithmName.SHA256)
        {
            HashSize = 256;
        }
        else if (hashAlgorithmName == HashAlgorithmName.SHA384)
        {
            HashSize = 384;
        }
        else if (hashAlgorithmName == HashAlgorithmName.SHA512)
        {
            HashSize = 512;
        }
    }

    public ushort KeySize;
    public ushort HashSize;
    public HashAlgorithmName HashAlgorithmName;

    public string ToString(string format, IFormatProvider formatProvider)
    {
        return $"{KeySize}-{HashAlgorithmName}";
    }
}

public class KeyHashPairCollection : List<KeyHashPair>
{
    public KeyHashPairCollection() { }
    public KeyHashPairCollection(IEnumerable<KeyHashPair> collection) : base(collection) { }
    public KeyHashPairCollection(int capacity) : base(capacity) { }
    public static KeyHashPairCollection ToJsonValidationDataCollection(KeyHashPair[] values)
    {
        return values != null ? new KeyHashPairCollection(values) : new KeyHashPairCollection();
    }

    public void Add(ushort keySize, HashAlgorithmName hashAlgorithmName)
    {
        Add(new KeyHashPair(keySize, hashAlgorithmName));
    }
}
#endregion

#if ECC_SUPPORT
#region ECCurveHashPair Helper
public class ECCurveHashPair : IFormattable
{
    public ECCurveHashPair(ECCurve curve, HashAlgorithmName hashAlgorithmName)
    {
        Curve = curve;
        HashAlgorithmName = hashAlgorithmName;
        if (hashAlgorithmName == HashAlgorithmName.SHA1)
        {
            HashSize = 160;
        }
        else if (hashAlgorithmName == HashAlgorithmName.SHA256)
        {
            HashSize = 256;
        }
        else if (hashAlgorithmName == HashAlgorithmName.SHA384)
        {
            HashSize = 384;
        }
        else if (hashAlgorithmName == HashAlgorithmName.SHA512)
        {
            HashSize = 512;
        }
    }

    public ECCurve Curve { get; private set; }
    public ushort HashSize { get; private set; }
    public HashAlgorithmName HashAlgorithmName { get; private set; }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        try
        {
            string friendlyName = Curve.Oid?.FriendlyName ?? "Unknown";
            return $"{friendlyName}-{HashAlgorithmName}";
        }
        catch
        {
            return $"unknown-{HashAlgorithmName}";
        }
    }
}

public class ECCurveHashPairCollection : List<ECCurveHashPair>
{
    public ECCurveHashPairCollection() { }
    public ECCurveHashPairCollection(IEnumerable<ECCurveHashPair> collection) : base(collection) { }
    public ECCurveHashPairCollection(int capacity) : base(capacity) { }
    public static ECCurveHashPairCollection ToJsonValidationDataCollection(ECCurveHashPair[] values)
    {
        return values != null ? new ECCurveHashPairCollection(values) : new ECCurveHashPairCollection();
    }

    public void Add(ECCurve curve, HashAlgorithmName hashAlgorithmName)
    {
        Add(new ECCurveHashPair(curve, hashAlgorithmName));
    }
}
#endregion
#endif

#region CRL Asset Helpers
/// <summary>
/// A CRL as test asset.
/// </summary>
public class CRLAsset : IAsset, IFormattable
{
    public CRLAsset() { }

    public string Path { get; private set; }
    public byte[] Crl { get; private set; }

    public void Initialize(byte[] blob, string path)
    {
        Path = path;
        Crl = blob;
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        string file = System.IO.Path.GetFileName(Path);
        return $"{file}";
    }
}

/// <summary>
/// A Certificate as test asset.
/// </summary>
public class CertificateAsset : IAsset, IFormattable
{
    public CertificateAsset() { }

    public string Path { get; private set; }
    public byte[] Cert { get; private set; }
    public X509Certificate2 X509Certificate { get; private set; }

    public void Initialize(byte[] blob, string path)
    {
        Path = path;
        Cert = blob;
        try
        {
            X509Certificate = X509CertificateLoader.LoadCertificateFromFile(path);
        }
        catch
        { }
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        string file = System.IO.Path.GetFileName(Path);
        return $"{file}";
    }
}
#endregion

#region TestUtils
/// <summary>
/// Test helpers.
/// </summary>
public static class CertificateTestUtils
{
    public static string WriteCRL(X509CRL x509Crl)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append("Issuer:     ").AppendLine(x509Crl.Issuer);
        stringBuilder.Append("ThisUpdate: ").Append(x509Crl.ThisUpdate).AppendLine();
        stringBuilder.Append("NextUpdate: ").Append(x509Crl.NextUpdate).AppendLine();
        stringBuilder.AppendLine("RevokedCertificates:");
        foreach (RevokedCertificate revokedCert in x509Crl.RevokedCertificates)
        {
            stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0:20}", revokedCert.SerialNumber).Append(", ").Append(revokedCert.RevocationDate).Append(", ");
            foreach (X509Extension entryExt in revokedCert.CrlEntryExtensions)
            {
                stringBuilder.Append(entryExt.Format(false)).Append(' ');
            }
            stringBuilder.AppendLine("");
        }
        stringBuilder.AppendLine("Extensions:");
        foreach (X509Extension extension in x509Crl.CrlExtensions)
        {
            stringBuilder.AppendLine(extension.Format(false));
        }
        return stringBuilder.ToString();
    }
}
#endregion


