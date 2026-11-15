// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides constant-time multi-precision unsigned integer arithmetic on <see cref="Span{T}"/> of <see cref="ulong"/> limbs.
/// </summary>
/// <remarks>
/// <para>
/// All operations are designed to execute in constant time regardless of operand values,
/// preventing timing side-channel attacks. No data-dependent branches or memory accesses are used.
/// </para>
/// <para>
/// Numbers are stored in little-endian limb order: limb[0] contains the least significant 64 bits.
/// </para>
/// </remarks>
internal static class BigUInt
{
    // ========================================================================
    // Widening Multiply (64×64 → 128-bit)
    // ========================================================================

    /// <summary>
    /// Computes the full 128-bit product of two 64-bit unsigned integers.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <param name="low">The low 64 bits of the product.</param>
    /// <returns>The high 64 bits of the product.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static ulong Mul128(ulong a, ulong b, out ulong low)
    {
#if NET8_0_OR_GREATER
        return Math.BigMul(a, b, out low);
#else
        // Split each 64-bit operand into two 32-bit halves and use
        // four 32×32→64 multiplies to compute the full 128-bit product.
        ulong aLo = (uint)a;
        ulong aHi = a >> 32;
        ulong bLo = (uint)b;
        ulong bHi = b >> 32;

        ulong ll = aLo * bLo;
        ulong lh = aLo * bHi;
        ulong hl = aHi * bLo;
        ulong hh = aHi * bHi;

        ulong mid = lh + (ll >> 32);
        ulong carry = (uint)mid;
        carry += (uint)hl;

        low = (carry << 32) | (uint)ll;
        ulong high = hh + (mid >> 32) + (hl >> 32) + (carry >> 32);
        return high;
#endif
    }

    // ========================================================================
    // Addition
    // ========================================================================

    /// <summary>
    /// Computes <paramref name="a"/> + <paramref name="b"/>, storing the result in <paramref name="result"/>.
    /// </summary>
    /// <param name="a">First operand (little-endian limbs).</param>
    /// <param name="b">Second operand (same length as <paramref name="a"/>).</param>
    /// <param name="result">Destination (same length as <paramref name="a"/>). May alias <paramref name="a"/> or <paramref name="b"/>.</param>
    /// <returns>The carry out (0 or 1).</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Add(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b, Span<ulong> result)
    {
        int n = result.Length;
        ulong carry = 0;
        for (int i = 0; i < n; i++)
        {
            ulong sum = a[i] + carry;
            carry = sum < carry ? 1UL : 0UL;
            ulong sum2 = sum + b[i];
            carry += sum2 < sum ? 1UL : 0UL;
            result[i] = sum2;
        }

        return carry;
    }

    /// <summary>
    /// Computes <paramref name="a"/> + <paramref name="word"/>, storing the result in <paramref name="result"/>.
    /// </summary>
    /// <param name="a">Operand (little-endian limbs).</param>
    /// <param name="word">Single-limb value to add.</param>
    /// <param name="result">Destination (same length as <paramref name="a"/>). May alias <paramref name="a"/>.</param>
    /// <returns>The carry out (0 or 1).</returns>
    public static ulong AddWord(ReadOnlySpan<ulong> a, ulong word, Span<ulong> result)
    {
        int n = result.Length;
        ulong carry = word;
        for (int i = 0; i < n; i++)
        {
            ulong sum = a[i] + carry;
            carry = sum < carry ? 1UL : 0UL;
            result[i] = sum;
        }

        return carry;
    }

    // ========================================================================
    // Subtraction
    // ========================================================================

    /// <summary>
    /// Computes <paramref name="a"/> - <paramref name="b"/>, storing the result in <paramref name="result"/>.
    /// </summary>
    /// <param name="a">Minuend (little-endian limbs).</param>
    /// <param name="b">Subtrahend (same length as <paramref name="a"/>).</param>
    /// <param name="result">Destination (same length as <paramref name="a"/>). May alias <paramref name="a"/> or <paramref name="b"/>.</param>
    /// <returns>The borrow out (0 if a &gt;= b, 1 if a &lt; b).</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ulong Sub(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b, Span<ulong> result)
    {
        int n = result.Length;
        ulong borrow = 0;
        for (int i = 0; i < n; i++)
        {
            ulong diff = a[i] - borrow;
            borrow = diff > a[i] ? 1UL : 0UL;
            ulong diff2 = diff - b[i];
            borrow += diff2 > diff ? 1UL : 0UL;
            result[i] = diff2;
        }

        return borrow;
    }

    /// <summary>
    /// Computes <paramref name="a"/> - <paramref name="word"/>, storing the result in <paramref name="result"/>.
    /// </summary>
    /// <param name="a">Minuend (little-endian limbs).</param>
    /// <param name="word">Single-limb value to subtract.</param>
    /// <param name="result">Destination (same length as <paramref name="a"/>). May alias <paramref name="a"/>.</param>
    /// <returns>The borrow out (0 or 1).</returns>
    public static ulong SubWord(ReadOnlySpan<ulong> a, ulong word, Span<ulong> result)
    {
        int n = result.Length;
        ulong borrow = word;
        for (int i = 0; i < n; i++)
        {
            ulong diff = a[i] - borrow;
            borrow = diff > a[i] ? 1UL : 0UL;
            result[i] = diff;
        }

        return borrow;
    }

    // ========================================================================
    // Comparison (constant-time)
    // ========================================================================

    /// <summary>
    /// Compares two multi-precision integers in constant time.
    /// </summary>
    /// <param name="a">First operand (little-endian limbs).</param>
    /// <param name="b">Second operand (same length as <paramref name="a"/>).</param>
    /// <returns>
    /// 1 if <paramref name="a"/> &gt; <paramref name="b"/>,
    /// -1 if <paramref name="a"/> &lt; <paramref name="b"/>,
    /// 0 if equal.
    /// </returns>
    /// <remarks>
    /// Uses bitmask accumulation to avoid data-dependent branches.
    /// </remarks>
    public static int Compare(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b)
    {
        int n = a.Length;

        // gt and lt are bitmasks: all-ones if any higher limb proved the relationship
        ulong gt = 0;
        ulong lt = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            // eq mask: all-ones if no relationship determined yet
            ulong eq = ~(gt | lt);
            // this limb's comparison (only matters if all higher limbs were equal)
            gt |= ConstantTimeGt(a[i], b[i]) & eq;
            lt |= ConstantTimeGt(b[i], a[i]) & eq;
        }

        // Convert to -1/0/+1 using arithmetic on the LSBs
        return (int)(gt & 1) - (int)(lt & 1);
    }

    /// <summary>
    /// Checks whether two multi-precision integers are equal in constant time.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand (same length).</param>
    /// <returns><see langword="true"/> if all limbs are equal.</returns>
    public static bool ConstantTimeEqual(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b)
    {
        ulong diff = 0;
        for (int i = 0; i < a.Length; i++)
        {
            diff |= a[i] ^ b[i];
        }

        return diff == 0;
    }

    /// <summary>
    /// Returns whether the value is zero in constant time.
    /// </summary>
    /// <param name="a">The value to check.</param>
    /// <returns><see langword="true"/> if all limbs are zero.</returns>
    public static bool IsZero(ReadOnlySpan<ulong> a)
    {
        ulong acc = 0;
        for (int i = 0; i < a.Length; i++)
        {
            acc |= a[i];
        }

        return acc == 0;
    }

    // ========================================================================
    // Shifts
    // ========================================================================

    /// <summary>
    /// Shifts <paramref name="a"/> left by <paramref name="bits"/> positions, storing the result in <paramref name="result"/>.
    /// </summary>
    /// <param name="a">Operand (little-endian limbs).</param>
    /// <param name="bits">Number of bits to shift (0 to 63).</param>
    /// <param name="result">Destination (same length as <paramref name="a"/>). May alias <paramref name="a"/>.</param>
    /// <returns>The bits shifted out from the most significant limb.</returns>
    public static ulong ShiftLeft(ReadOnlySpan<ulong> a, int bits, Span<ulong> result)
    {
        if (bits == 0)
        {
            a.CopyTo(result);
            return 0;
        }

        int n = a.Length;
        int rShift = 64 - bits;
        ulong carry = 0;
        for (int i = 0; i < n; i++)
        {
            ulong cur = a[i];
            result[i] = (cur << bits) | carry;
            carry = cur >> rShift;
        }

        return carry;
    }

    /// <summary>
    /// Shifts <paramref name="a"/> right by <paramref name="bits"/> positions, storing the result in <paramref name="result"/>.
    /// </summary>
    /// <param name="a">Operand (little-endian limbs).</param>
    /// <param name="bits">Number of bits to shift (0 to 63).</param>
    /// <param name="result">Destination (same length as <paramref name="a"/>). May alias <paramref name="a"/>.</param>
    /// <returns>The bits shifted out from the least significant limb.</returns>
    public static ulong ShiftRight(ReadOnlySpan<ulong> a, int bits, Span<ulong> result)
    {
        if (bits == 0)
        {
            a.CopyTo(result);
            return 0;
        }

        int n = a.Length;
        int lShift = 64 - bits;
        ulong carry = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            ulong cur = a[i];
            result[i] = (cur >> bits) | carry;
            carry = cur << lShift;
        }

        return carry;
    }

    /// <summary>
    /// Shifts <paramref name="a"/> left by whole limbs (multiples of 64 bits).
    /// </summary>
    /// <param name="a">Operand (little-endian limbs).</param>
    /// <param name="limbCount">Number of limbs to shift.</param>
    /// <param name="result">Destination (same length as <paramref name="a"/>). Must not alias <paramref name="a"/>.</param>
    public static void ShiftLeftLimbs(ReadOnlySpan<ulong> a, int limbCount, Span<ulong> result)
    {
        result.Clear();
        int n = a.Length;
        if (limbCount >= n) return;
        a[..(n - limbCount)].CopyTo(result[limbCount..]);
    }

    // ========================================================================
    // Multiplication
    // ========================================================================

    /// <summary>
    /// Computes the full product <paramref name="a"/> × <paramref name="b"/>.
    /// </summary>
    /// <param name="a">First operand (little-endian limbs, length n).</param>
    /// <param name="b">Second operand (little-endian limbs, length m).</param>
    /// <param name="result">Destination (length n + m). Must be zeroed before call. Must not alias <paramref name="a"/> or <paramref name="b"/>.</param>
    /// <remarks>
    /// Uses schoolbook (grade-school) O(n·m) multiplication.
    /// For RSA-sized operands, this is sufficient; Karatsuba can be added later for large key sizes.
    /// </remarks>
    public static void Mul(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b, Span<ulong> result)
    {
        int n = a.Length;
        int m = b.Length;

        for (int i = 0; i < n; i++)
        {
            ulong carry = 0;
            ulong ai = a[i];
            for (int j = 0; j < m; j++)
            {
                ulong hi = Mul128(ai, b[j], out ulong lo);

                // Add lo to result[i+j]
                ulong sum = result[i + j] + lo;
                ulong c1 = sum < lo ? 1UL : 0UL;

                // Add carry
                ulong sum2 = sum + carry;
                ulong c2 = sum2 < sum ? 1UL : 0UL;

                result[i + j] = sum2;
                carry = hi + c1 + c2;
            }

            result[i + m] = carry;
        }
    }

    /// <summary>
    /// Computes <paramref name="a"/> × <paramref name="word"/>, storing the result in <paramref name="result"/>.
    /// </summary>
    /// <param name="a">Operand (little-endian limbs, length n).</param>
    /// <param name="word">Single-limb multiplier.</param>
    /// <param name="result">Destination (length n + 1 or n if overflow is ignored). Must not alias <paramref name="a"/>.</param>
    /// <returns>The carry out (the extra limb).</returns>
    public static ulong MulWord(ReadOnlySpan<ulong> a, ulong word, Span<ulong> result)
    {
        int n = a.Length;
        ulong carry = 0;
        for (int i = 0; i < n; i++)
        {
            ulong hi = Mul128(a[i], word, out ulong lo);
            ulong sum = lo + carry;
            carry = hi + (sum < lo ? 1UL : 0UL);
            result[i] = sum;
        }

        return carry;
    }

    /// <summary>
    /// Computes <paramref name="a"/>², storing the result in <paramref name="result"/>.
    /// </summary>
    /// <param name="a">Operand (little-endian limbs, length n).</param>
    /// <param name="result">Destination (length 2n). Must be zeroed before call. Must not alias <paramref name="a"/>.</param>
    /// <remarks>
    /// Optimized squaring uses the symmetry a[i]×a[j] = a[j]×a[i], computing
    /// off-diagonal products once and doubling, then adding diagonal products.
    /// This saves ~25% of multiplications compared to generic <see cref="Mul"/>.
    /// </remarks>
    public static void Square(ReadOnlySpan<ulong> a, Span<ulong> result)
    {
        int n = a.Length;

        // Step 1: Compute off-diagonal products (i < j) and add once
        for (int i = 0; i < n; i++)
        {
            ulong carry = 0;
            ulong ai = a[i];
            for (int j = i + 1; j < n; j++)
            {
                ulong hi = Mul128(ai, a[j], out ulong lo);

                ulong sum = result[i + j] + lo;
                ulong c1 = sum < lo ? 1UL : 0UL;
                ulong sum2 = sum + carry;
                ulong c2 = sum2 < sum ? 1UL : 0UL;

                result[i + j] = sum2;
                carry = hi + c1 + c2;
            }

            result[i + n] += carry;
        }

        // Step 2: Double the off-diagonal sum (shift left by 1 bit)
        ulong shiftCarry = ShiftLeft(result, 1, result);
        _ = shiftCarry; // top bit should be zero for properly-sized result

        // Step 3: Add diagonal products a[i]×a[i]
        ulong diagCarry = 0;
        for (int i = 0; i < n; i++)
        {
            ulong hi = Mul128(a[i], a[i], out ulong lo);

            ulong sum = result[2 * i] + lo;
            ulong c1 = sum < lo ? 1UL : 0UL;
            ulong sum2 = sum + diagCarry;
            ulong c2 = sum2 < sum ? 1UL : 0UL;

            result[2 * i] = sum2;

            ulong sum3 = result[2 * i + 1] + hi;
            ulong c3 = sum3 < hi ? 1UL : 0UL;
            ulong sum4 = sum3 + c1 + c2;
            ulong c4 = sum4 < sum3 ? 1UL : 0UL;

            result[2 * i + 1] = sum4;
            diagCarry = c3 + c4;
        }
    }

    // ========================================================================
    // Conditional Operations (constant-time)
    // ========================================================================

    /// <summary>
    /// Conditionally copies <paramref name="src"/> into <paramref name="dst"/> based on <paramref name="condition"/>.
    /// </summary>
    /// <param name="condition">If 1, copies; if 0, does nothing. Must be 0 or 1.</param>
    /// <param name="dst">Destination buffer.</param>
    /// <param name="src">Source buffer (same length as <paramref name="dst"/>).</param>
    /// <remarks>
    /// Executes in constant time regardless of <paramref name="condition"/>.
    /// </remarks>
    public static void ConditionalCopy(ulong condition, Span<ulong> dst, ReadOnlySpan<ulong> src)
    {
        ulong mask = 0UL - condition; // 0 → 0x0, 1 → 0xFFFF...
        for (int i = 0; i < dst.Length; i++)
        {
            dst[i] = dst[i] ^ (mask & (dst[i] ^ src[i]));
        }
    }

    /// <summary>
    /// Conditionally swaps <paramref name="a"/> and <paramref name="b"/> based on <paramref name="condition"/>.
    /// </summary>
    /// <param name="condition">If 1, swaps; if 0, does nothing. Must be 0 or 1.</param>
    /// <param name="a">First buffer.</param>
    /// <param name="b">Second buffer (same length as <paramref name="a"/>).</param>
    public static void ConditionalSwap(ulong condition, Span<ulong> a, Span<ulong> b)
    {
        ulong mask = 0UL - condition;
        for (int i = 0; i < a.Length; i++)
        {
            ulong diff = mask & (a[i] ^ b[i]);
            a[i] ^= diff;
            b[i] ^= diff;
        }
    }

    // ========================================================================
    // Utility
    // ========================================================================

    /// <summary>
    /// Returns the number of significant bits in the multi-precision integer.
    /// </summary>
    /// <param name="a">The value (little-endian limbs).</param>
    /// <returns>The bit length, or 0 if the value is zero.</returns>
    public static int BitLength(ReadOnlySpan<ulong> a)
    {
        for (int i = a.Length - 1; i >= 0; i--)
        {
            if (a[i] != 0)
            {
                return i * 64 + (64 - LeadingZeroCount(a[i]));
            }
        }

        return 0;
    }

    /// <summary>
    /// Sets a multi-precision integer from a single <see cref="ulong"/> word.
    /// </summary>
    /// <param name="result">Destination buffer. All limbs beyond the first are zeroed.</param>
    /// <param name="value">The value to set.</param>
    public static void SetWord(Span<ulong> result, ulong value)
    {
        result.Clear();
        if (result.Length > 0)
        {
            result[0] = value;
        }
    }

    /// <summary>
    /// Copies a big-endian byte array into a little-endian limb span.
    /// </summary>
    /// <param name="bigEndianBytes">Source bytes in big-endian order (MSB first).</param>
    /// <param name="result">Destination limb span (little-endian, sufficient size).</param>
    public static void FromBigEndianBytes(ReadOnlySpan<byte> bigEndianBytes, Span<ulong> result)
    {
        result.Clear();
        int byteLen = bigEndianBytes.Length;
        for (int i = 0; i < byteLen; i++)
        {
            int limbIndex = (byteLen - 1 - i) / 8;
            int bitOffset = ((byteLen - 1 - i) % 8) * 8;
            if (limbIndex < result.Length)
            {
                result[limbIndex] |= (ulong)bigEndianBytes[i] << bitOffset;
            }
        }
    }

    /// <summary>
    /// Exports a little-endian limb span to a big-endian byte array.
    /// </summary>
    /// <param name="a">Source limbs (little-endian).</param>
    /// <param name="bigEndianBytes">Destination bytes in big-endian order. Length determines output size (left-padded with zeros).</param>
    public static void ToBigEndianBytes(ReadOnlySpan<ulong> a, Span<byte> bigEndianBytes)
    {
        bigEndianBytes.Clear();
        int byteLen = bigEndianBytes.Length;
        for (int i = 0; i < byteLen; i++)
        {
            int limbIndex = (byteLen - 1 - i) / 8;
            int bitOffset = ((byteLen - 1 - i) % 8) * 8;
            if (limbIndex < a.Length)
            {
                bigEndianBytes[i] = (byte)(a[limbIndex] >> bitOffset);
            }
        }
    }

    // ========================================================================
    // Internal Helpers
    // ========================================================================

    /// <summary>
    /// Returns 1 if <paramref name="a"/> &gt; <paramref name="b"/>, 0 otherwise.
    /// Constant-time.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong ConstantTimeGt(ulong a, ulong b)
    {
        // Detect borrow in (b - a): borrow occurs iff a > b.
        ulong diff = b - a;
        ulong borrow = ((~b & a) | (~(b ^ a) & diff)) >> 63;
        return borrow;
    }

    /// <summary>
    /// Counts leading zero bits in a 64-bit value.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int LeadingZeroCount(ulong value)
    {
#if NET8_0_OR_GREATER
        return System.Numerics.BitOperations.LeadingZeroCount(value);
#else
        if (value == 0) return 64;
        int n = 0;
        if (value <= 0x00000000FFFFFFFFUL) { n += 32; value <<= 32; }
        if (value <= 0x0000FFFFFFFFFFFFUL) { n += 16; value <<= 16; }
        if (value <= 0x00FFFFFFFFFFFFFFUL) { n += 8; value <<= 8; }
        if (value <= 0x0FFFFFFFFFFFFFFFUL) { n += 4; value <<= 4; }
        if (value <= 0x3FFFFFFFFFFFFFFFUL) { n += 2; value <<= 2; }
        if (value <= 0x7FFFFFFFFFFFFFFFUL) { n += 1; }
        return n;
#endif
    }
}
