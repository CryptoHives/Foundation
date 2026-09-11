// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System;
using System.Buffers;
using System.Buffers.Text;

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
/// RFC 7468 textual encoding which keeps key material in the original buffer.
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
/// intermediate that cannot be avoided - base64 needs somewhere to go before it is laid out into
/// lines, or stripped of whitespace before it is decoded - is rented and zeroed.
/// </para>
/// <para>
/// For efficiency, the intermediate is a <see cref="byte"/> buffer rather than a <see cref="char"/> one.
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
        byte[] base64 = ArrayPool<byte>.Shared.Rent(Math.Max(base64Length, 1));

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
                Widen(base64.AsSpan(i, take), destination.Slice(written));
                written += take;
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
            // Clear key material before the array goes back.
            CryptographicOperations.ZeroMemory(base64);
            ArrayPool<byte>.Shared.Return(base64);
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
    /// <remarks>
    /// The scratch buffer is bytes, not characters: base64 is ASCII, so narrowing is exact, and the
    /// buffer that holds a private key on its way in is half the size it would otherwise be.
    /// <c>Base64.DecodeFromUtf8InPlace</c> then writes the DER over the encoded form in that same
    /// buffer, so the decode costs no second allocation and leaves one buffer to clear rather than
    /// two.
    /// </remarks>
    public static byte[] Decode(ReadOnlySpan<char> pem, PemBlock block)
    {
        ReadOnlySpan<char> payload = block.Base64(pem);
        byte[] cleaned = ArrayPool<byte>.Shared.Rent(Math.Max(payload.Length, 1));
        int length = 0;

        try
        {
            foreach (char c in payload)
            {
                if (char.IsWhiteSpace(c))
                {
                    continue;
                }

                // Anything outside ASCII cannot be base64, and narrowing it would silently fold it
                // onto a character that is. Reject it here rather than decode something else.
                if (c > 0x7F)
                {
                    throw new FormatException("The PEM payload contains a non-base64 character.");
                }

                cleaned[length++] = (byte)c;
            }

            OperationStatus status = Base64.DecodeFromUtf8InPlace(
                cleaned.AsSpan(0, length), out int decoded);

            if (status != OperationStatus.Done)
            {
                throw new FormatException("The PEM payload is not valid base64.");
            }

            return cleaned.AsSpan(0, decoded).ToArray();
        }
        finally
        {
            CryptographicOperations.ZeroMemory(cleaned.AsSpan(0, length));
            ArrayPool<byte>.Shared.Return(cleaned);
        }
    }

    private static int Append(Span<char> destination, int offset, ReadOnlySpan<char> value)
    {
        value.CopyTo(destination.Slice(offset));
        return value.Length;
    }

    /// <summary>
    /// Base64-encodes the DER into a scratch buffer, as UTF-8 rather than UTF-16.
    /// </summary>
    /// <param name="der">The DER-encoded data.</param>
    /// <param name="destination">The scratch buffer, at least <paramref name="base64Length"/> long.</param>
    /// <param name="base64Length">The expected encoded length.</param>
    /// <remarks>
    /// <para>
    /// Base64 output is ASCII, so a byte per character is exact and can be cleared afterwards.
    /// The caller widens the bytes to characters when laying them out into lines.
    /// Avoids additional allocations by using <c>Base64.EncodeToUtf8</c> which takes a span on every
    /// target framework.
    /// </para>
    /// </remarks>
    private static void EncodeBase64(ReadOnlySpan<byte> der, Span<byte> destination, int base64Length)
    {
        if (base64Length == 0)
        {
            return;
        }

        OperationStatus status = Base64.EncodeToUtf8(der, destination, out _, out int written);

        if (status != OperationStatus.Done || written != base64Length)
        {
            throw new InvalidOperationException("The base64 scratch buffer was too small.");
        }
    }

    /// <summary>
    /// Widens ASCII bytes to characters.
    /// </summary>
    /// <param name="source">The ASCII bytes.</param>
    /// <param name="destination">The buffer to receive the characters.</param>
    /// <remarks>
    /// Only ever called on base64 output, which RFC 4648 confines to the ASCII range, so this is a
    /// straight zero-extension with nothing to validate.
    /// </remarks>
    private static void Widen(ReadOnlySpan<byte> source, Span<char> destination)
    {
        for (int i = 0; i < source.Length; i++)
        {
            destination[i] = (char)source[i];
        }
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
