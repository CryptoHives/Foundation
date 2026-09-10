// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// The PEM labels the PQC key types recognize.
/// </summary>
internal static class PemLabels
{
    /// <summary>SubjectPublicKeyInfo.</summary>
    public const string PublicKey = "PUBLIC KEY";

    /// <summary>PKCS#8 PrivateKeyInfo.</summary>
    public const string Pkcs8PrivateKey = "PRIVATE KEY";

    /// <summary>PKCS#8 EncryptedPrivateKeyInfo.</summary>
    public const string EncryptedPkcs8PrivateKey = "ENCRYPTED PRIVATE KEY";
}

/// <summary>
/// One textual PEM block found in a document.
/// </summary>
/// <remarks>
/// A plain struct rather than a record struct: <c>record</c> positional members need
/// <c>System.Runtime.CompilerServices.IsExternalInit</c>, which net462, net472 and netstandard2.0
/// do not define.
/// </remarks>
internal readonly struct PemBlock
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PemBlock"/> struct.
    /// </summary>
    /// <param name="label">The label between the BEGIN and END markers.</param>
    /// <param name="base64">The base64 payload, whitespace included.</param>
    public PemBlock(string label, string base64)
    {
        Label = label;
        Base64 = base64;
    }

    /// <summary>Gets the label between the BEGIN and END markers.</summary>
    public string Label { get; }

    /// <summary>Gets the base64 payload, whitespace included.</summary>
    public string Base64 { get; }
}

/// <summary>
/// RFC 7468 textual encoding, on every target framework.
/// </summary>
/// <remarks>
/// <para>
/// The output shape was taken from what .NET 10 produces rather than from the RFC's leeway:
/// 64 base64 characters per line, <c>\n</c> line endings (not <c>\r\n</c>), and <b>no</b> trailing
/// newline after the END marker. <c>PemEncodingTests</c> pins this against
/// <c>System.Security.Cryptography.PemEncoding</c> byte for byte on net10.0.
/// </para>
/// <para>
/// The reader is deliberately a scanner rather than a single <c>IndexOf</c> for the first block:
/// <c>ImportFromPem</c> has to see every block in the document so it can skip labels it does not
/// recognize and fail when more than one recognized block is present.
/// </para>
/// </remarks>
internal static class PemFormat
{
    private const int CharsPerLine = 64;
    private const string BeginPrefix = "-----BEGIN ";
    private const string EndPrefix = "-----END ";
    private const string Suffix = "-----";

    /// <summary>
    /// Encodes DER bytes as a PEM block.
    /// </summary>
    /// <param name="der">The DER-encoded data.</param>
    /// <param name="label">The PEM label.</param>
    /// <returns>The PEM text, without a trailing newline.</returns>
    public static string Encode(ReadOnlySpan<byte> der, string label)
    {
#if NETSTANDARD2_1_OR_GREATER || NET
        string base64 = Convert.ToBase64String(der);
#else
        string base64 = Convert.ToBase64String(der.ToArray());
#endif

        var builder = new StringBuilder(base64.Length + (base64.Length / CharsPerLine) + (label.Length * 2) + 32);
        builder.Append(BeginPrefix).Append(label).Append(Suffix).Append('\n');

        for (int i = 0; i < base64.Length; i += CharsPerLine)
        {
            int take = Math.Min(CharsPerLine, base64.Length - i);
#if NETSTANDARD2_1_OR_GREATER || NET
            builder.Append(base64.AsSpan(i, take));
#else
            builder.Append(base64, i, take);
#endif
            builder.Append('\n');
        }

        builder.Append(EndPrefix).Append(label).Append(Suffix);
        return builder.ToString();
    }

    /// <summary>
    /// Produces a PEM block and clears the intermediate DER buffer.
    /// </summary>
    /// <param name="der">The DER-encoded data; zeroed before returning.</param>
    /// <param name="label">The PEM label.</param>
    /// <returns>The PEM text.</returns>
    /// <remarks>
    /// Used for the private-key exports, where the caller has just materialized secret bytes purely
    /// to re-encode them as text and has no further use for them.
    /// </remarks>
    public static string EncodeAndClear(byte[] der, string label)
    {
        try
        {
            return Encode(der, label);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(der);
        }
    }

    /// <summary>
    /// Walks every well-formed PEM block in a document.
    /// </summary>
    /// <param name="pem">The document.</param>
    /// <returns>The blocks, in order.</returns>
    /// <remarks>
    /// Malformed regions are skipped rather than reported: RFC 7468 allows arbitrary explanatory
    /// text around and between blocks, so text that does not parse as a block simply is not one.
    /// </remarks>
    public static IEnumerable<PemBlock> EnumerateBlocks(string pem)
    {
        int position = 0;

        while (position < pem.Length)
        {
            int begin = pem.IndexOf(BeginPrefix, position, StringComparison.Ordinal);
            if (begin < 0)
            {
                yield break;
            }

            int labelStart = begin + BeginPrefix.Length;
            int labelEnd = pem.IndexOf(Suffix, labelStart, StringComparison.Ordinal);
            if (labelEnd < 0)
            {
                yield break;
            }

            string label = pem.Substring(labelStart, labelEnd - labelStart);
            int dataStart = labelEnd + Suffix.Length;

            string endMarker = EndPrefix + label + Suffix;
            int end = pem.IndexOf(endMarker, dataStart, StringComparison.Ordinal);
            if (end < 0)
            {
                // A BEGIN with no matching END is not a block. Resume after this marker so a later
                // well-formed block in the same document is still found.
                position = dataStart;
                continue;
            }

            yield return new PemBlock(label, pem.Substring(dataStart, end - dataStart));
            position = end + endMarker.Length;
        }
    }

    /// <summary>
    /// Decodes a block's base64 payload.
    /// </summary>
    /// <param name="block">The block.</param>
    /// <returns>The DER bytes.</returns>
    /// <exception cref="FormatException">The payload is not valid base64.</exception>
    public static byte[] Decode(PemBlock block)
    {
        string payload = block.Base64;
        var cleaned = new StringBuilder(payload.Length);

        foreach (char c in payload)
        {
            if (!char.IsWhiteSpace(c))
            {
                cleaned.Append(c);
            }
        }

        return Convert.FromBase64String(cleaned.ToString());
    }
}
