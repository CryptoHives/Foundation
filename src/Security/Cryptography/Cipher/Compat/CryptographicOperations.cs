// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher.Compat;

using System;

/// <summary>
/// Compatibility shim for CryptographicOperations
/// which is not available on older .NET Framework and .NET Standard versions.
/// </summary>
internal static class CryptographicOperations
{
    /// <summary>
    /// Fills a span with zeros in a way that's not subject to compiler optimizations.
    /// </summary>
    /// <param name="buffer">The buffer to clear.</param>
    public static void ZeroMemory(Span<byte> buffer)
    {
        buffer.Clear();
    }

    /// <summary>
    /// Fills an array with zeros in a way that's not subject to compiler optimizations.
    /// </summary>
    /// <param name="buffer">The buffer to clear.</param>
    public static void ZeroMemory(byte[] buffer)
    {
        if (buffer != null)
        {
            Array.Clear(buffer, 0, buffer.Length);
        }
    }

    /// <summary>
    /// Compares two byte spans in constant time.
    /// </summary>
    /// <param name="left">The first span to compare.</param>
    /// <param name="right">The second span to compare.</param>
    /// <returns>True if the spans are equal, false otherwise.</returns>
    public static bool FixedTimeEquals(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
    {
        if (left.Length != right.Length)
        {
            return false;
        }

        int diff = 0;
        for (int i = 0; i < left.Length; i++)
        {
            diff |= left[i] ^ right[i];
        }

        return diff == 0;
    }
}
