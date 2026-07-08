// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Kem;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Centered Binomial Distribution (CBD) sampling for ML-KEM.
/// </summary>
/// <remarks>
/// Implements FIPS 203 Algorithm 8 (SamplePolyCBD). Given a byte array of pseudorandom
/// data, produces polynomial coefficients sampled from the centered binomial distribution
/// Bη for η ∈ {2, 3}.
/// </remarks>
internal static class Cbd
{
    /// <summary>
    /// Samples a polynomial from the centered binomial distribution B₂.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 8 with η = 2. Requires 128 bytes (64·η) of input.
    /// Each coefficient is in the range [−2, 2].
    /// </remarks>
    /// <param name="buf">The 128-byte pseudorandom input buffer.</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Eta2(ReadOnlySpan<byte> buf, short[] coeffs)
    {
        for (int i = 0; i < MlKemParams.N / 8; i++)
        {
            uint t = (uint)buf[4 * i]
                   | ((uint)buf[4 * i + 1] << 8)
                   | ((uint)buf[4 * i + 2] << 16)
                   | ((uint)buf[4 * i + 3] << 24);

            uint d = t & 0x55555555u;
            d += (t >> 1) & 0x55555555u;

            for (int j = 0; j < 8; j++)
            {
                short a = (short)((d >> (4 * j)) & 0x3);
                short b = (short)((d >> (4 * j + 2)) & 0x3);
                coeffs[8 * i + j] = (short)(a - b);
            }
        }
    }

    /// <summary>
    /// Samples a polynomial from the centered binomial distribution B₃.
    /// </summary>
    /// <remarks>
    /// FIPS 203 Algorithm 8 with η = 3. Requires 192 bytes (64·η) of input.
    /// Each coefficient is in the range [−3, 3].
    /// </remarks>
    /// <param name="buf">The 192-byte pseudorandom input buffer.</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Eta3(ReadOnlySpan<byte> buf, short[] coeffs)
    {
        for (int i = 0; i < MlKemParams.N / 4; i++)
        {
            uint t = (uint)buf[3 * i]
                   | ((uint)buf[3 * i + 1] << 8)
                   | ((uint)buf[3 * i + 2] << 16);

            uint d = t & 0x00249249u;
            d += (t >> 1) & 0x00249249u;
            d += (t >> 2) & 0x00249249u;

            for (int j = 0; j < 4; j++)
            {
                short a = (short)((d >> (6 * j)) & 0x7);
                short b = (short)((d >> (6 * j + 3)) & 0x7);
                coeffs[4 * i + j] = (short)(a - b);
            }
        }
    }

    /// <summary>
    /// Samples a polynomial using the appropriate CBD for the given η value.
    /// </summary>
    /// <param name="buf">The pseudorandom input buffer (64·η bytes).</param>
    /// <param name="eta">The CBD parameter (2 or 3).</param>
    /// <param name="coeffs">The 256-element output polynomial array.</param>
    /// <exception cref="ArgumentException"><paramref name="eta"/> is not 2 or 3.</exception>
    public static void Sample(ReadOnlySpan<byte> buf, int eta, short[] coeffs)
    {
        switch (eta)
        {
            case 2:
                Eta2(buf, coeffs);
                break;
            case 3:
                Eta3(buf, coeffs);
                break;
            default:
                throw new ArgumentException($"Unsupported CBD parameter η = {eta}.", nameof(eta));
        }
    }
}
