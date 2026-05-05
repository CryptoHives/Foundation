// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Certificates;

using System;
using System.Formats.Asn1;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Utils for ASN.1 encoding and decoding.
/// </summary>
public static class AsnUtils
{
    /// <summary>
    /// Converts a buffer to a hexadecimal string.
    /// </summary>
    internal static string ToHexString(this byte[]? buffer, bool invertEndian = false)
    {
        if (buffer == null || buffer.Length == 0)
        {
            return string.Empty;
        }

        return ToHexString(buffer.AsSpan(), invertEndian);
    }

    /// <summary>
    /// Converts a span to a hexadecimal string.
    /// </summary>
    internal static string ToHexString(this ReadOnlySpan<byte> buffer, bool invertEndian = false)
    {
        if (buffer.Length == 0)
        {
            return string.Empty;
        }

#if NET6_0_OR_GREATER
        if (!invertEndian)
        {
            return Convert.ToHexString(buffer);
        }
#endif
        return ToHexStringSlow(buffer, invertEndian);
    }

    /// <summary>
    /// Slow path for hex string conversion when Convert.ToHexString is not available or inversion is needed.
    /// </summary>
    private static string ToHexStringSlow(ReadOnlySpan<byte> buffer, bool invertEndian)
    {
        var builder = new StringBuilder(buffer.Length * 2);

        if (!invertEndian)
        {
            for (int ii = 0; ii < buffer.Length; ii++)
            {
                builder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", buffer[ii]);
            }
        }
        else
        {
            for (int ii = buffer.Length - 1; ii >= 0; ii--)
            {
                builder.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", buffer[ii]);
            }
        }

        return builder.ToString();
    }

    /// <summary>
    /// Converts a hexadecimal string to an array of bytes.
    /// </summary>
    internal static byte[] FromHexString(this string buffer)
    {
        if (string.IsNullOrEmpty(buffer))
        {
            return Array.Empty<byte>();
        }

#if NET6_0_OR_GREATER
        return Convert.FromHexString(buffer);
#else
        return FromHexStringSlow(buffer.AsSpan());
#endif
    }

    /// <summary>
    /// Converts a hexadecimal span to an array of bytes.
    /// </summary>
    internal static byte[] FromHexString(this ReadOnlySpan<char> buffer)
    {
        if (buffer.Length == 0)
        {
            return Array.Empty<byte>();
        }

#if NET6_0_OR_GREATER
        return Convert.FromHexString(buffer);
#else
        return FromHexStringSlow(buffer);
#endif
    }

#if !NET6_0_OR_GREATER
    /// <summary>
    /// Slow path for hex string parsing when Convert.FromHexString is not available.
    /// </summary>
    private static byte[] FromHexStringSlow(ReadOnlySpan<char> buffer)
    {
        const string digits = "0123456789ABCDEF";

        byte[] bytes = new byte[(buffer.Length / 2) + (buffer.Length % 2)];

        int ii = 0;

        while (ii < bytes.Length * 2)
        {
            int index = digits.IndexOf(char.ToUpperInvariant(buffer[ii]));

            if (index == -1)
            {
                break;
            }

            byte b = (byte)index;
            b <<= 4;

            if (ii < buffer.Length - 1)
            {
                index = digits.IndexOf(char.ToUpperInvariant(buffer[ii + 1]));

                if (index == -1)
                {
                    break;
                }

                b += (byte)index;
            }

            bytes[ii / 2] = b;
            ii += 2;
        }

        return bytes;
    }
#endif

    /// <summary>
    /// Writer for Public Key parameters.
    /// </summary>
    /// <remarks>
    /// https://www.itu.int/rec/T-REC-X.690-201508-I/en
    /// section 8.3 (Encoding of an integer value).
    /// </remarks>
    /// <param name="writer">The writer</param>
    /// <param name="integer">The key parameter</param>
    internal static void WriteKeyParameterInteger(this AsnWriter writer, ReadOnlySpan<byte> integer)
    {
        if (integer[0] == 0)
        {
            int newStart = 1;

            while (newStart < integer.Length)
            {
                if (integer[newStart] >= 0x80)
                {
                    newStart--;
                    break;
                }

                if (integer[newStart] != 0)
                {
                    break;
                }

                newStart++;
            }

            if (newStart == integer.Length)
            {
                newStart--;
            }

            integer = integer.Slice(newStart);
        }

        writer.WriteIntegerUnsigned(integer);
    }

    /// <summary>
    /// Parse a X509 Tbs and signature from a byte blob with validation,
    /// return the byte array which contains the X509 blob.
    /// </summary>
    /// <param name="blob">The encoded CRL or certificate sequence.</param>
    public static ReadOnlyMemory<byte> ParseX509Blob(ReadOnlyMemory<byte> blob)
    {
        try
        {
            var x509Reader = new AsnReader(blob, AsnEncodingRules.DER);
            ReadOnlyMemory<byte> peekBlob = blob.Slice(0, x509Reader.PeekContentBytes().Length + 4);
            AsnReader seqReader = x509Reader.ReadSequence(Asn1Tag.Sequence);

            // Tbs encoded data
            ReadOnlyMemory<byte> tbs = seqReader.ReadEncodedValue();

            // Signature Algorithm Identifier
            AsnReader sigOid = seqReader.ReadSequence();
            string signatureAlgorithm = sigOid.ReadObjectIdentifier();
            HashAlgorithmName name = Oids.GetHashAlgorithmName(signatureAlgorithm);

            // Signature
            byte[] signature = seqReader.ReadBitString(out int unusedBitCount);
            if (unusedBitCount != 0)
            {
                throw new AsnContentException("Unexpected data in signature.");
            }
            seqReader.ThrowIfNotEmpty();
            return peekBlob;
        }
        catch (AsnContentException ace)
        {
            throw new CryptographicException("Failed to decode the X509 sequence.", ace);
        }
        throw new CryptographicException("Invalid ASN encoding for the X509 sequence.");
    }
}

