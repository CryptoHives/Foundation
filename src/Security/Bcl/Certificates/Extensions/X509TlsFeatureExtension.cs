// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Bcl.Certificates;

using CryptoHives.Foundation.Security.Certificates;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

/// <summary>
/// The TLS Feature extension.
/// </summary>
public sealed class X509TlsFeatureExtension : X509Extension
{
    private const string kFriendlyName = "TLS Feature";

    /// <summary>
    /// The OID for TLS Feature extension.
    /// </summary>
    public const string TlsFeatureOid = Oids.TlsFeature;

    /// <summary>
    /// RFC feature id for status_request.
    /// </summary>
    public const int StatusRequest = 5;

    /// <summary>
    /// RFC feature id for status_request_v2.
    /// </summary>
    public const int StatusRequestV2 = 17;

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509TlsFeatureExtension(AsnEncodedData encodedExtension, bool critical)
        : this(encodedExtension.Oid ?? throw new ArgumentException("Oid cannot be null.", nameof(encodedExtension)), encodedExtension.RawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from an OID and ASN.1 encoded raw data.
    /// </summary>
    public X509TlsFeatureExtension(string oid, byte[] rawData, bool critical)
        : this(new Oid(oid, kFriendlyName), rawData, critical)
    {
    }

    /// <summary>
    /// Creates an extension from ASN.1 encoded data.
    /// </summary>
    public X509TlsFeatureExtension(Oid oid, byte[] rawData, bool critical)
        : base(oid, rawData, critical)
    {
        Decode(rawData);
    }

    /// <summary>
    /// Builds a TLS Feature extension.
    /// </summary>
    /// <param name="featureIds">TLS feature identifiers.</param>
    public X509TlsFeatureExtension(IEnumerable<int> featureIds)
    {
        if (featureIds == null)
        {
            throw new ArgumentNullException(nameof(featureIds));
        }

        Oid = new Oid(TlsFeatureOid, kFriendlyName);
        Critical = false;

        foreach (int featureId in featureIds)
        {
            if (featureId < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(featureIds));
            }

            _featureIds.Add(featureId);
        }

        if (_featureIds.Count == 0)
        {
            throw new ArgumentException("At least one TLS feature id is required.", nameof(featureIds));
        }

        RawData = Encode();
    }

    /// <summary>
    /// Gets TLS feature ids.
    /// </summary>
    public IReadOnlyList<int> FeatureIds => _featureIds.AsReadOnly();

    /// <inheritdoc />
    public override string Format(bool multiLine)
    {
        var buffer = new StringBuilder();
        for (int i = 0; i < _featureIds.Count; i++)
        {
            if (buffer.Length > 0)
            {
                if (multiLine)
                {
                    buffer.AppendLine();
                }
                else
                {
                    buffer.Append(", ");
                }
            }

            buffer.Append("Feature=");
            buffer.Append(_featureIds[i]);
        }

        return buffer.ToString();
    }

    /// <inheritdoc />
    public override void CopyFrom(AsnEncodedData asnEncodedData)
    {
        if (asnEncodedData == null)
        {
            throw new ArgumentNullException(nameof(asnEncodedData));
        }

        Oid = asnEncodedData.Oid;
        RawData = asnEncodedData.RawData;
        Decode(RawData);
    }

    private byte[] Encode()
    {
        using var pooledWriter = PooledAsnWriterDer.Get();
        AsnWriter writer = pooledWriter.Writer;

        writer.PushSequence();
        foreach (int featureId in _featureIds)
        {
            writer.WriteInteger(featureId);
        }
        writer.PopSequence();

        return pooledWriter.Encode();
    }

    private void Decode(byte[] data)
    {
        string? oidValue = Oid?.Value;
        if (oidValue != TlsFeatureOid)
        {
            throw new CryptographicException("Invalid TlsFeatureOid.");
        }

        _featureIds.Clear();

        try
        {
            var reader = new AsnReader(data, AsnEncodingRules.DER);
            var sequence = reader.ReadSequence();
            reader.ThrowIfNotEmpty();

            while (sequence.HasData)
            {
                _featureIds.Add((int)sequence.ReadInteger());
            }
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the TLS Feature extension.", ace);
        }
    }

    private readonly List<int> _featureIds = [];
}
