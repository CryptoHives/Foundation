// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric;

using System;
using System.Text;

/// <summary>
/// Provides managed PEM encoding and decoding for all target frameworks.
/// </summary>
internal static class PemHelper
{
    private const int LineLength = 64;

    /// <summary>
    /// Encodes DER-encoded data as a PEM string with the specified label.
    /// </summary>
    /// <param name="der">The DER-encoded data to wrap.</param>
    /// <param name="label">The PEM label (e.g., "PUBLIC KEY").</param>
    /// <returns>The PEM-encoded string.</returns>
    internal static string Encode(ReadOnlySpan<byte> der, string label)
    {
        string base64 = Convert.ToBase64String(der.ToArray());
        var sb = new StringBuilder();
        sb.Append("-----BEGIN ").Append(label).AppendLine("-----");
        for (int i = 0; i < base64.Length; i += LineLength)
            sb.AppendLine(base64.Substring(i, Math.Min(LineLength, base64.Length - i)));
        sb.Append("-----END ").Append(label).Append("-----");
        return sb.ToString();
    }

    /// <summary>
    /// Decodes a PEM string to DER-encoded bytes.
    /// </summary>
    /// <param name="pem">The PEM-encoded string to parse.</param>
    /// <param name="label">When this method returns, contains the PEM label.</param>
    /// <returns>The DER-encoded data extracted from the PEM block.</returns>
    /// <exception cref="ArgumentException">The string does not contain a valid PEM block.</exception>
    internal static byte[] Decode(string pem, out string label)
    {
        const string beginPrefix = "-----BEGIN ";
        const string endPrefix = "-----END ";
        const string suffix = "-----";

        int beginIdx = pem.IndexOf(beginPrefix, StringComparison.Ordinal);
        if (beginIdx < 0) throw new ArgumentException("Invalid PEM: missing BEGIN marker.");

        int labelStart = beginIdx + beginPrefix.Length;
        int labelEnd = pem.IndexOf(suffix, labelStart, StringComparison.Ordinal);
        if (labelEnd < 0) throw new ArgumentException("Invalid PEM: malformed BEGIN marker.");

        label = pem.Substring(labelStart, labelEnd - labelStart);

        int dataStart = labelEnd + suffix.Length;
        string endMarker = endPrefix + label + suffix;
        int endIdx = pem.IndexOf(endMarker, dataStart, StringComparison.Ordinal);
        if (endIdx < 0) throw new ArgumentException("Invalid PEM: missing END marker.");

        string base64 = pem.Substring(dataStart, endIdx - dataStart);

        var cleanBase64 = new StringBuilder(base64.Length);
        foreach (char c in base64)
        {
            if (!char.IsWhiteSpace(c))
                cleanBase64.Append(c);
        }

        return Convert.FromBase64String(cleanBase64.ToString());
    }
}
