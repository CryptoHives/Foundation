// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.KeyFormats;

using System.Formats.Asn1;
using OS = System.Security.Cryptography;

/// <summary>
/// Shared strictness checks for the key-format readers.
/// </summary>
/// <remarks>
/// These are the rules the in-box types enforce, gathered in one place so that every reader in this
/// folder applies them the same way. Being strict here matters: a decoder that silently ignores
/// trailing data or unexpected algorithm parameters will happily accept a structure that another
/// implementation reads differently, which is how format confusion bugs start.
/// </remarks>
internal static class DerGuard
{
    /// <summary>
    /// Throws when a reader has not been fully consumed.
    /// </summary>
    /// <param name="reader">The reader to check.</param>
    /// <exception cref="OS.CryptographicException">The reader has data left.</exception>
    public static void NoTrailingData(AsnReader reader)
    {
        if (reader.HasData)
        {
            throw new OS.CryptographicException(
                "The ASN.1 structure is followed by unexpected trailing data.");
        }
    }

    /// <summary>
    /// Throws when an <c>AlgorithmIdentifier</c> carries parameters.
    /// </summary>
    /// <param name="algorithmIdentifier">The reader positioned after the OID.</param>
    /// <exception cref="OS.CryptographicException">Parameters are present.</exception>
    public static void NoAlgorithmParameters(AsnReader algorithmIdentifier)
    {
        if (algorithmIdentifier.HasData)
        {
            throw new OS.CryptographicException(
                "The algorithm identifier must not carry parameters for this algorithm.");
        }
    }

    /// <summary>
    /// Throws when a key is not the length its parameter set requires.
    /// </summary>
    /// <param name="actual">The decoded length.</param>
    /// <param name="expected">The required length.</param>
    /// <param name="what">A short description used in the message, e.g. <c>public key</c>.</param>
    /// <param name="parameterSet">The parameter set name.</param>
    /// <exception cref="OS.CryptographicException">The lengths differ.</exception>
    /// <remarks>
    /// This throws <see cref="OS.CryptographicException"/> rather than
    /// <see cref="System.ArgumentException"/> on purpose: the length is a property of the encoded
    /// data, not of an argument the caller passed, and that is what the in-box types throw.
    /// </remarks>
    public static void KeyLength(int actual, int expected, string what, string parameterSet)
    {
        if (actual != expected)
        {
            throw new OS.CryptographicException(
                $"The {what} for {parameterSet} must be {expected} bytes; the encoding contained {actual}.");
        }
    }
}
