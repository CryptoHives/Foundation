// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System;
using System.Buffers;

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
/// One textual PEM block located in a document, as two index ranges into that document.
/// </summary>
/// <remarks>
/// <para>
/// Ranges rather than strings. A block found in a <c>PRIVATE KEY</c> document holds the private key
/// itself, so materializing its label or payload as a <see cref="string"/> would put the key in
/// memory that can never be overwritten. The caller keeps the document it searched and slices it.
/// </para>
/// <para>
/// A plain struct rather than a record struct: <c>record</c> positional members need
/// <c>System.Runtime.CompilerServices.IsExternalInit</c>, which net462, net472 and netstandard2.0
/// do not define.
/// </para>
/// </remarks>
internal readonly struct PemBlock
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PemBlock"/> struct.
    /// </summary>
    /// <param name="labelStart">The index of the first character of the label.</param>
    /// <param name="labelLength">The length of the label.</param>
    /// <param name="base64Start">The index of the first character of the payload.</param>
    /// <param name="base64Length">The length of the payload, whitespace included.</param>
    public PemBlock(int labelStart, int labelLength, int base64Start, int base64Length)
    {
        LabelStart = labelStart;
        LabelLength = labelLength;
        Base64Start = base64Start;
        Base64Length = base64Length;
        Found = true;
    }

    /// <summary>Gets a value indicating whether this instance describes a real block.</summary>
    public bool Found { get; }

    /// <summary>Gets the index of the first character of the label.</summary>
    public int LabelStart { get; }

    /// <summary>Gets the length of the label.</summary>
    public int LabelLength { get; }

    /// <summary>Gets the index of the first character of the payload.</summary>
    public int Base64Start { get; }

    /// <summary>Gets the length of the payload, whitespace included.</summary>
    public int Base64Length { get; }

    /// <summary>Slices the label out of the document this block was found in.</summary>
    /// <param name="pem">The document.</param>
    /// <returns>The label.</returns>
    public ReadOnlySpan<char> Label(ReadOnlySpan<char> pem) => pem.Slice(LabelStart, LabelLength);

    /// <summary>Slices the payload out of the document this block was found in.</summary>
    /// <param name="pem">The document.</param>
    /// <returns>The base64 payload, whitespace included.</returns>
    public ReadOnlySpan<char> Base64(ReadOnlySpan<char> pem) => pem.Slice(Base64Start, Base64Length);

    /// <summary>Tests whether the label equals a known one.</summary>
    /// <param name="pem">The document.</param>
    /// <param name="label">The label to compare against.</param>
    /// <returns><see langword="true"/> when the labels match ordinally.</returns>
    public bool LabelIs(ReadOnlySpan<char> pem, string label)
        => Label(pem).SequenceEqual(label.AsSpan());
}

/// <summary>
/// RFC 7468 textual encoding, on every target framework, without putting key material in a
/// <see cref="string"/>.
/// </summary>
/// <remarks>
/// <para>
/// The output shape was taken from what .NET 10 produces rather than from the RFC's leeway:
/// 64 base64 characters per line, <c>\n</c> line endings (not <c>\r\n</c>), and <b>no</b> trailing
/// newline after the END marker. <c>PemEncodingTests</c> pins this against
/// <c>System.Security.Cryptography.PemEncoding</c> byte for byte on net10.0.
/// </para>
/// <para>
/// Everything here works in spans. The encoder writes into a caller-owned buffer and the reader
/// returns index ranges into the caller's document, so a private key never passes through an
/// immutable <see cref="string"/>, a <c>StringBuilder</c> or a <c>Substring</c>. The one
/// intermediate that cannot be avoided - base64 needs somewhere to put its output before it is
/// laid out into lines - is rented and zeroed.
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
    /// Computes the exact number of characters <see cref="TryEncode"/> writes.
    /// </summary>
    /// <param name="derLength">The number of DER bytes to encode.</param>
    /// <param name="label">The PEM label.</param>
    /// <returns>The encoded length in characters.</returns>
    /// <remarks>
    /// The counterpart of <c>System.Security.Cryptography.PemEncoding.GetEncodedSize</c>, which
    /// only exists on .NET Core 3.0 and later. Without it a <c>TryExport</c> caller has no way to
    /// size a buffer other than guessing and growing - and the guess most people would make, 4096,
    /// is too small for an ML-DSA-87 expanded key.
    /// </remarks>
    public static int GetEncodedSize(int derLength, string label)
    {
        checked
        {
            int base64Length = ((derLength + 2) / 3) * 4;
            int lines = (base64Length + CharsPerLine - 1) / CharsPerLine;

            // "-----BEGIN " + label + "-----" + "\n"   = 17 + label
            // the payload, one "\n" after each line    = base64Length + lines
            // "-----END " + label + "-----"            = 14 + label, no trailing newline
            return 17 + label.Length + base64Length + lines + 14 + label.Length;
        }
    }

    /// <summary>
    /// Encodes DER bytes as a PEM block directly into a caller-owned buffer.
    /// </summary>
    /// <param name="der">The DER-encoded data.</param>
    /// <param name="label">The PEM label.</param>
    /// <param name="destination">The buffer to receive the text.</param>
    /// <param name="charsWritten">The number of characters written.</param>
    /// <returns><see langword="true"/> when the buffer was large enough.</returns>
    /// <remarks>
    /// When the buffer is too small nothing is written and <paramref name="charsWritten"/> is zero,
    /// matching the <c>TryExport</c> contract used throughout the key-format surface.
    /// </remarks>
    public static bool TryEncode(
        ReadOnlySpan<byte> der,
        string label,
        Span<char> destination,
        out int charsWritten)
    {
        int required = GetEncodedSize(der.Length, label);

        if (destination.Length < required)
        {
            charsWritten = 0;
            return false;
        }

        int base64Length = ((der.Length + 2) / 3) * 4;
        char[] base64 = ArrayPool<char>.Shared.Rent(Math.Max(base64Length, 1));

        try
        {
            EncodeBase64(der, base64, base64Length);

            int written = 0;
            written += Append(destination, written, BeginPrefix.AsSpan());
            written += Append(destination, written, label.AsSpan());
            written += Append(destination, written, Suffix.AsSpan());
            destination[written++] = '\n';

            for (int i = 0; i < base64Length; i += CharsPerLine)
            {
                int take = Math.Min(CharsPerLine, base64Length - i);
                written += Append(destination, written, base64.AsSpan(i, take));
                destination[written++] = '\n';
            }

            written += Append(destination, written, EndPrefix.AsSpan());
            written += Append(destination, written, label.AsSpan());
            written += Append(destination, written, Suffix.AsSpan());

            charsWritten = written;
            return true;
        }
        finally
        {
            // The payload is the private key in base64. Clear it before the array goes back.
            CryptographicOperations.ZeroMemory(base64.AsSpan(0, Math.Min(base64Length, base64.Length)));
            ArrayPool<char>.Shared.Return(base64);
        }
    }

    /// <summary>
    /// Encodes DER bytes that are known not to be secret as a PEM string.
    /// </summary>
    /// <param name="der">The DER-encoded data.</param>
    /// <param name="label">The PEM label.</param>
    /// <returns>The PEM text, without a trailing newline.</returns>
    /// <remarks>
    /// A <see cref="string"/> cannot be erased, so this overload is reachable only from the two
    /// exports whose content is public by construction: a SubjectPublicKeyInfo, and an
    /// EncryptedPrivateKeyInfo, which is ciphertext. Every plaintext private-key export goes
    /// through <see cref="TryEncode"/> instead.
    /// </remarks>
    public static string EncodePublic(ReadOnlySpan<byte> der, string label)
    {
        int required = GetEncodedSize(der.Length, label);
        char[] buffer = new char[required];

        if (!TryEncode(der, label, buffer, out int written))
        {
            throw new InvalidOperationException("The computed PEM size was too small.");
        }

        return new string(buffer, 0, written);
    }

    // Dropped from the shipping surface: clearing the DER accomplishes nothing while the string
    // this returns still holds the same bytes in base64 and can never be overwritten.
    // Retained unbuilt for review; see docfx/packages/security/cryptography/erasable-memory.md.
#if SECURITY_REVIEW
    /// <summary>
    /// Produces a PEM block as a string and clears the intermediate DER buffer.
    /// </summary>
    /// <param name="der">The DER-encoded data; zeroed before returning.</param>
    /// <param name="label">The PEM label.</param>
    /// <returns>The PEM text.</returns>
    /// <remarks>
    /// The string this returns holds the private key in base64 and can never be erased, which is
    /// why it is not in the shipping surface.
    /// </remarks>
    public static string EncodeAndClear(byte[] der, string label)
    {
        try
        {
            return EncodePublic(der, label);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(der);
        }
    }
#endif

    /// <summary>
    /// Scans forward for the next well-formed PEM block.
    /// </summary>
    /// <param name="pem">The document.</param>
    /// <param name="position">
    /// On entry, where to resume scanning; on return, where the next scan should resume.
    /// </param>
    /// <param name="block">Receives the block that was found.</param>
    /// <returns><see langword="true"/> when a block was found.</returns>
    /// <remarks>
    /// <para>
    /// A cursor rather than an <c>IEnumerable</c>: an iterator method cannot take a
    /// <see cref="ReadOnlySpan{T}"/> parameter, and the whole point of this rewrite is that the
    /// document is never copied out of the caller's span.
    /// </para>
    /// <para>
    /// Malformed regions are skipped rather than reported: RFC 7468 allows arbitrary explanatory
    /// text around and between blocks, so text that does not parse as a block simply is not one.
    /// </para>
    /// </remarks>
    public static bool TryFindBlock(ReadOnlySpan<char> pem, ref int position, out PemBlock block)
    {
        while (position < pem.Length)
        {
            int begin = IndexOf(pem, position, BeginPrefix);
            if (begin < 0)
            {
                break;
            }

            int labelStart = begin + BeginPrefix.Length;
            int labelEnd = IndexOf(pem, labelStart, Suffix);
            if (labelEnd < 0)
            {
                break;
            }

            int labelLength = labelEnd - labelStart;
            int dataStart = labelEnd + Suffix.Length;

            int end = IndexOfEndMarker(pem, dataStart, pem.Slice(labelStart, labelLength));
            if (end < 0)
            {
                // A BEGIN with no matching END is not a block. Resume after this marker so a later
                // well-formed block in the same document is still found.
                position = dataStart;
                continue;
            }

            block = new PemBlock(labelStart, labelLength, dataStart, end - dataStart);
            position = end + EndPrefix.Length + labelLength + Suffix.Length;
            return true;
        }

        position = pem.Length;
        block = default;
        return false;
    }

    /// <summary>
    /// Decodes a block's base64 payload.
    /// </summary>
    /// <param name="pem">The document the block was found in.</param>
    /// <param name="block">The block.</param>
    /// <returns>The DER bytes.</returns>
    /// <exception cref="FormatException">The payload is not valid base64.</exception>
    public static byte[] Decode(ReadOnlySpan<char> pem, PemBlock block)
    {
        ReadOnlySpan<char> payload = block.Base64(pem);
        char[] cleaned = ArrayPool<char>.Shared.Rent(Math.Max(payload.Length, 1));
        int length = 0;

        try
        {
            foreach (char c in payload)
            {
                if (!char.IsWhiteSpace(c))
                {
                    cleaned[length++] = c;
                }
            }

            return Convert.FromBase64CharArray(cleaned, 0, length);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(cleaned.AsSpan(0, length));
            ArrayPool<char>.Shared.Return(cleaned);
        }
    }

    private static int Append(Span<char> destination, int offset, ReadOnlySpan<char> value)
    {
        value.CopyTo(destination.Slice(offset));
        return value.Length;
    }

    private static void EncodeBase64(ReadOnlySpan<byte> der, char[] destination, int base64Length)
    {
        if (base64Length == 0)
        {
            return;
        }

#if NETSTANDARD2_1_OR_GREATER || NET
        if (!Convert.TryToBase64Chars(der, destination, out _))
        {
            throw new InvalidOperationException("The base64 scratch buffer was too small.");
        }
#else
        // Convert has no span-based encoder downlevel, so the DER has to be an array. It carries
        // the private key, so it is rented and cleared rather than left to the collector.
        byte[] bytes = ArrayPool<byte>.Shared.Rent(der.Length);

        try
        {
            der.CopyTo(bytes);
            Convert.ToBase64CharArray(bytes, 0, der.Length, destination, 0);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(bytes.AsSpan(0, der.Length));
            ArrayPool<byte>.Shared.Return(bytes);
        }
#endif
    }

    private static int IndexOf(ReadOnlySpan<char> pem, int start, string value)
    {
        if (start >= pem.Length)
        {
            return -1;
        }

        int index = pem.Slice(start).IndexOf(value.AsSpan());
        return index < 0 ? -1 : start + index;
    }

    /// <summary>
    /// Finds the <c>-----END &lt;label&gt;-----</c> that closes a block, without concatenating the
    /// marker into a temporary string.
    /// </summary>
    private static int IndexOfEndMarker(ReadOnlySpan<char> pem, int start, ReadOnlySpan<char> label)
    {
        int position = start;

        while (true)
        {
            int candidate = IndexOf(pem, position, EndPrefix);
            if (candidate < 0)
            {
                return -1;
            }

            int labelStart = candidate + EndPrefix.Length;
            int suffixStart = labelStart + label.Length;

            if (suffixStart + Suffix.Length <= pem.Length
                && pem.Slice(labelStart, label.Length).SequenceEqual(label)
                && pem.Slice(suffixStart, Suffix.Length).SequenceEqual(Suffix.AsSpan()))
            {
                return candidate;
            }

            position = candidate + EndPrefix.Length;
        }
    }
}
