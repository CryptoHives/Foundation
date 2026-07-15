// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Cryptographic utility methods.
/// </summary>
internal static class CryptographicOperations
{
    /// <summary>
    /// Fills a span with zeros in a way that's not subject to compiler optimizations.
    /// </summary>
    /// <param name="buffer">The buffer to clear.</param>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static void ZeroMemory(Span<byte> buffer)
    {
        buffer.Clear();
    }

    /// <summary>
    /// Fills an array with zeros in a way that's not subject to compiler optimizations.
    /// </summary>
    /// <param name="buffer">The buffer to clear.</param>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static void ZeroMemory(byte[] buffer)
    {
        if (buffer != null)
        {
            Array.Clear(buffer, 0, buffer.Length);
        }
    }

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

    /// <summary>
    /// Compares two byte spans in constant time and returns an all-ones or all-zeros mask.
    /// </summary>
    /// <param name="left">First span to compare.</param>
    /// <param name="right">Second span to compare. Must have the same length as <paramref name="left"/>.</param>
    /// <returns>-1 (all bits set) if the spans are equal, 0 otherwise.</returns>
    /// <remarks>
    /// Unlike <see cref="FixedTimeEquals"/>, the result is a branchless mask suitable for
    /// constant-time selection without converting to <see cref="bool"/>, which would
    /// reintroduce a secret-dependent branch.
    /// </remarks>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static int FixedTimeEqualsMask(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
    {
        if (left.Length != right.Length)
        {
            return 0;
        }

        int result = 0;
        for (int i = 0; i < left.Length; i++)
        {
            result |= left[i] ^ right[i];
        }

        // result is 0..255; (result - 1) >> 31 arithmetic-shifts to -1 when result == 0, else 0.
        return (result - 1) >> 31;
    }
}
