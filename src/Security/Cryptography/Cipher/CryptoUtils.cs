// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Cryptographic utility methods.
/// </summary>
internal static class CryptoUtils
{
    /// <summary>
    /// Compares two byte spans in constant time to prevent timing attacks.
    /// </summary>
    /// <param name="left">First span to compare.</param>
    /// <param name="right">Second span to compare.</param>
    /// <returns>True if the spans are equal, false otherwise.</returns>
    /// <remarks>
    /// This method always compares all bytes regardless of where differences occur,
    /// preventing timing-based side-channel attacks.
    /// </remarks>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static bool FixedTimeEquals(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
    {
        if (left.Length != right.Length)
        {
            return false;
        }

        int result = 0;
        for (int i = 0; i < left.Length; i++)
        {
            result |= left[i] ^ right[i];
        }

        return result == 0;
    }
}
