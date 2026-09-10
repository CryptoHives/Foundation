// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System;
using System.Buffers;
using System.Text;

/// <summary>
/// A password supplied either as characters or as raw bytes, together with the encoding rule each
/// password-based scheme applies to it.
/// </summary>
/// <remarks>
/// <para>
/// The public API takes passwords both ways, and the two are <b>not</b> interchangeable. A
/// character password is encoded before use — UTF-8 for PBES2 (RFC 8018), big-endian UTF-16 with a
/// NUL terminator for the PKCS#12 schemes (RFC 7292) — while a byte password is fed to the key
/// derivation function exactly as given, which is the whole point of that overload: it lets a
/// caller reproduce a password encoding this library would not otherwise produce.
/// </para>
/// <para>
/// Getting this wrong does not throw. It silently derives a different key and surfaces as "the
/// password is incorrect", so the encoding decision lives here rather than at each call site.
/// </para>
/// </remarks>
internal readonly ref struct PbePassword
{
    private readonly ReadOnlySpan<char> _chars;
    private readonly ReadOnlySpan<byte> _bytes;
    private readonly bool _isBytes;

    private PbePassword(ReadOnlySpan<char> chars, ReadOnlySpan<byte> bytes, bool isBytes)
    {
        _chars = chars;
        _bytes = bytes;
        _isBytes = isBytes;
    }

    /// <summary>
    /// Wraps a character password, which each scheme encodes according to its own rules.
    /// </summary>
    /// <param name="password">The password.</param>
    /// <returns>The wrapper.</returns>
    public static PbePassword FromChars(ReadOnlySpan<char> password)
        => new(password, default, isBytes: false);

    /// <summary>
    /// Wraps a byte password, used verbatim by every scheme.
    /// </summary>
    /// <param name="password">The password bytes.</param>
    /// <returns>The wrapper.</returns>
    public static PbePassword FromBytes(ReadOnlySpan<byte> password)
        => new(default, password, isBytes: true);

    /// <summary>
    /// Produces the bytes PBKDF2 should treat as the password.
    /// </summary>
    /// <returns>A fresh array the caller must zero.</returns>
    public byte[] ForPbkdf2()
    {
        if (_isBytes)
        {
            return _bytes.ToArray();
        }

        if (_chars.IsEmpty)
        {
            return [];
        }

#if NETSTANDARD2_1_OR_GREATER || NET
        byte[] bytes = new byte[Encoding.UTF8.GetByteCount(_chars)];
        Encoding.UTF8.GetBytes(_chars, bytes);
        return bytes;
#else
        // Encoding has no span overloads downlevel, so the password characters have to be an
        // array. Rent it and clear it rather than letting _chars.ToArray() leave an unerasable
        // copy of the password on the heap.
        char[] chars = ArrayPool<char>.Shared.Rent(_chars.Length);

        try
        {
            _chars.CopyTo(chars);
            return Encoding.UTF8.GetBytes(chars, 0, _chars.Length);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(chars.AsSpan(0, _chars.Length));
            ArrayPool<char>.Shared.Return(chars);
        }
#endif
    }

    /// <summary>
    /// Produces the bytes the PKCS#12 KDF should treat as the password: a big-endian UTF-16 string
    /// with a two-byte NUL terminator, or the raw bytes when the caller supplied them.
    /// </summary>
    /// <returns>A fresh array the caller must zero.</returns>
    public byte[] ForPkcs12Kdf()
    {
        if (_isBytes)
        {
            return _bytes.ToArray();
        }

        // RFC 7292 B.1. An empty password is the empty string, not a lone NUL terminator.
        if (_chars.IsEmpty)
        {
            return [];
        }

        byte[] bytes = new byte[(_chars.Length * 2) + 2];
        for (int i = 0; i < _chars.Length; i++)
        {
            bytes[i * 2] = (byte)(_chars[i] >> 8);
            bytes[(i * 2) + 1] = (byte)_chars[i];
        }

        return bytes;
    }
}
