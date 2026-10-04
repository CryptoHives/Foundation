// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;
using OS = System.Security.Cryptography;

/// <summary>
/// Applies and removes the <see cref="PaddingMode"/> schemes with the same semantics as the
/// in-box <see cref="System.Security.Cryptography.SymmetricAlgorithm"/> implementations.
/// </summary>
internal static class BlockPadding
{
    /// <summary>
    /// Pads the trailing partial unit of a message into <paramref name="unit"/>.
    /// </summary>
    /// <param name="tail">The trailing bytes, shorter than <paramref name="unit"/>.</param>
    /// <param name="unit">Receives the padded unit; its length is the padding unit size.</param>
    /// <param name="padding">The padding mode.</param>
    /// <returns>The number of bytes in <paramref name="unit"/> to encrypt: zero or its full length.</returns>
    /// <exception cref="OS.CryptographicException"><paramref name="padding"/> is <see cref="PaddingMode.None"/> and <paramref name="tail"/> is not empty.</exception>
    public static int Pad(ReadOnlySpan<byte> tail, Span<byte> unit, PaddingMode padding)
    {
        int unitSize = unit.Length;
        int padLength = unitSize - tail.Length;
        tail.CopyTo(unit);

        switch (padding)
        {
            case PaddingMode.None:
                if (!tail.IsEmpty)
                    throw new OS.CryptographicException("Input length must be a multiple of block size when no padding is used.");
                return 0;

            case PaddingMode.Zeros:
                if (tail.IsEmpty)
                    return 0;
                unit.Slice(tail.Length).Clear();
                return unitSize;

            case PaddingMode.PKCS7:
                unit.Slice(tail.Length).Fill((byte)padLength);
                return unitSize;

            case PaddingMode.ANSIX923:
                unit.Slice(tail.Length, padLength - 1).Clear();
                unit[unitSize - 1] = (byte)padLength;
                return unitSize;

            case PaddingMode.ISO10126:
                Rng.RandomNumberGenerator.Fill(unit.Slice(tail.Length, padLength - 1));
                unit[unitSize - 1] = (byte)padLength;
                return unitSize;

            default:
                throw new OS.CryptographicException($"Padding mode {padding} is not supported.");
        }
    }

    /// <summary>
    /// Validates the padding on the last decrypted unit and returns how many bytes to strip.
    /// </summary>
    /// <param name="unit">The last decrypted unit.</param>
    /// <param name="padding">The padding mode.</param>
    /// <returns>The number of trailing padding bytes.</returns>
    /// <exception cref="OS.CryptographicException">The padding is malformed.</exception>
    public static int GetPaddingLength(ReadOnlySpan<byte> unit, PaddingMode padding)
    {
        byte padValue = unit[^1];
        bool valid = padding switch {
            PaddingMode.None or PaddingMode.Zeros => true,
            PaddingMode.PKCS7 => IsPaddingValid(unit, padValue, fill: padValue, checkFill: true),
            PaddingMode.ANSIX923 => IsPaddingValid(unit, padValue, fill: 0, checkFill: true),
            PaddingMode.ISO10126 => IsPaddingValid(unit, padValue, fill: 0, checkFill: false),
            _ => throw new OS.CryptographicException($"Padding mode {padding} is not supported.")
        };

        if (!valid)
            throw new OS.CryptographicException("Invalid padding.");

        return padding is PaddingMode.None or PaddingMode.Zeros ? 0 : padValue;
    }

    /// <summary>
    /// Checks the pad length and, if requested, the fill bytes without an early exit.
    /// </summary>
    /// <remarks>
    /// Timing must not depend on where the first bad pad byte is: a data-dependent exit here is
    /// the classic CBC padding-oracle side channel, exploitable even without a distinct error.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static bool IsPaddingValid(ReadOnlySpan<byte> unit, byte padValue, byte fill, bool checkFill)
    {
        int unitSize = unit.Length;
        int badLength = ((uint)(padValue - 1) > (uint)(unitSize - 1)) ? 1 : 0;

        int mismatch = 0;
        if (checkFill)
        {
            for (int i = 1; i < unitSize; i++)
            {
                byte actual = unit[unitSize - 1 - i];
                byte expected = i < padValue ? fill : actual;
                mismatch |= expected ^ actual;
            }
        }

        return (badLength | mismatch) == 0;
    }
}
