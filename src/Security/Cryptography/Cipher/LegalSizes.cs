// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using OS = System.Security.Cryptography;

/// <summary>
/// Shared legal key and block size tables for the fixed-size ciphers.
/// </summary>
/// <remarks>
/// <see cref="OS.KeySizes"/> is immutable and <see cref="OS.SymmetricAlgorithm"/> only hands out
/// clones of these arrays, so one table backs every cipher instance. Never write into them.
/// </remarks>
internal static class LegalSizes
{
    /// <summary>Exactly 128 bits.</summary>
    public static readonly OS.KeySizes[] Bits128 = [new OS.KeySizes(128, 128, 0)];

    /// <summary>Exactly 192 bits.</summary>
    public static readonly OS.KeySizes[] Bits192 = [new OS.KeySizes(192, 192, 0)];

    /// <summary>Exactly 256 bits.</summary>
    public static readonly OS.KeySizes[] Bits256 = [new OS.KeySizes(256, 256, 0)];

    /// <summary>Exactly 512 bits.</summary>
    public static readonly OS.KeySizes[] Bits512 = [new OS.KeySizes(512, 512, 0)];

    /// <summary>Either 256 or 512 bits.</summary>
    public static readonly OS.KeySizes[] Bits256Or512 = [Bits256[0], Bits512[0]];
}
