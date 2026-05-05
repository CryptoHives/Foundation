// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Asymmetric.BigInt;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Provides modular arithmetic operations and Montgomery multiplication for multi-precision integers.
/// </summary>
/// <remarks>
/// <para>
/// Montgomery multiplication converts modular arithmetic into a form where division by the modulus
/// is replaced by division by a power of 2 (a simple shift), making it much faster for repeated
/// modular multiplications as needed in RSA and ECC.
/// </para>
/// <para>
/// All operations are constant-time to prevent timing side-channel attacks.
/// </para>
/// </remarks>
internal sealed class MontgomeryContext
{
    private readonly ulong[] _modulus;
    private readonly ulong[] _rSquared;   // R² mod m (for converting to Montgomery form)
    private readonly ulong _mPrime;       // -m⁻¹ mod 2⁶⁴ (for REDC)
    private readonly int _limbCount;

    /// <summary>
    /// Initializes a new <see cref="MontgomeryContext"/> for the given odd modulus.
    /// </summary>
    /// <param name="modulus">The modulus (must be odd). Stored as little-endian <see cref="ulong"/> limbs.</param>
    /// <exception cref="ArgumentException">Thrown if the modulus is even or zero.</exception>
    public MontgomeryContext(ReadOnlySpan<ulong> modulus)
    {
        if (modulus.Length == 0 || (modulus[0] & 1) == 0)
            throw new ArgumentException("Modulus must be odd and non-zero.", nameof(modulus));

        _limbCount = modulus.Length;
        _modulus = modulus.ToArray();
        _mPrime = ComputeModInverse64(modulus[0]);

        // Compute R² mod m where R = 2^(64·n)
        _rSquared = ComputeRSquared(modulus);
    }

    /// <summary>
    /// Gets the number of limbs in the modulus.
    /// </summary>
    public int LimbCount => _limbCount;

    /// <summary>
    /// Gets the modulus as a read-only span.
    /// </summary>
    public ReadOnlySpan<ulong> Modulus => _modulus;

    /// <summary>
    /// Converts a value into Montgomery form: aR mod m.
    /// </summary>
    /// <param name="a">Input value (must be less than modulus, little-endian limbs of length <see cref="LimbCount"/>).</param>
    /// <param name="result">Output in Montgomery form (length <see cref="LimbCount"/>).</param>
    public void ToMontgomery(ReadOnlySpan<ulong> a, Span<ulong> result)
    {
        // aR mod m = MontMul(a, R²)
        MontMul(a, _rSquared, result);
    }

    /// <summary>
    /// Converts a value from Montgomery form back to normal: a·R⁻¹ mod m.
    /// </summary>
    /// <param name="aR">Input in Montgomery form (length <see cref="LimbCount"/>).</param>
    /// <param name="result">Output in normal form (length <see cref="LimbCount"/>).</param>
    public void FromMontgomery(ReadOnlySpan<ulong> aR, Span<ulong> result)
    {
        // a = MontMul(aR, 1)
        Span<ulong> one = stackalloc ulong[_limbCount];
        one.Clear();
        one[0] = 1;
        MontMul(aR, one, result);
    }

    /// <summary>
    /// Computes Montgomery multiplication: (a · b · R⁻¹) mod m, where both a and b are in Montgomery form.
    /// </summary>
    /// <param name="a">First operand in Montgomery form (length <see cref="LimbCount"/>).</param>
    /// <param name="b">Second operand in Montgomery form (length <see cref="LimbCount"/>).</param>
    /// <param name="result">Product in Montgomery form (length <see cref="LimbCount"/>). Must not alias <paramref name="a"/> or <paramref name="b"/>.</param>
    public void MontMul(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b, Span<ulong> result)
    {
        int n = _limbCount;
        ReadOnlySpan<ulong> m = _modulus;

        // CIOS (Coarsely Integrated Operand Scanning) Montgomery multiplication
        // T has n+2 limbs to handle intermediate overflow
        Span<ulong> t = stackalloc ulong[n + 2];
        t.Clear();

        for (int i = 0; i < n; i++)
        {
            // Step 1: t = t + a[i] * b
            ulong carry = 0;
            ulong ai = a[i];
            for (int j = 0; j < n; j++)
            {
                ulong hi = BigUInt.Mul128(ai, b[j], out ulong lo);
                ulong sum = t[j] + lo;
                ulong c1 = sum < lo ? 1UL : 0UL;
                ulong sum2 = sum + carry;
                ulong c2 = sum2 < sum ? 1UL : 0UL;
                t[j] = sum2;
                carry = hi + c1 + c2;
            }

            ulong addCarry = t[n] + carry;
            ulong ac = addCarry < carry ? 1UL : 0UL;
            t[n] = addCarry;
            t[n + 1] += ac;

            // Step 2: Reduction — u = t[0] * m' mod 2^64, then t = (t + u*m) / 2^64
            ulong u = t[0] * _mPrime;
            carry = 0;

            // First limb: we know (t[0] + u*m[0]) ≡ 0 (mod 2^64)
            ulong mhi = BigUInt.Mul128(u, m[0], out ulong mlo);
            ulong s = t[0] + mlo;
            carry = mhi + (s < mlo ? 1UL : 0UL);

            // Remaining limbs: shift down by one position
            for (int j = 1; j < n; j++)
            {
                mhi = BigUInt.Mul128(u, m[j], out mlo);
                s = t[j] + mlo;
                ulong c1 = s < mlo ? 1UL : 0UL;
                ulong s2 = s + carry;
                ulong c2 = s2 < s ? 1UL : 0UL;
                t[j - 1] = s2;
                carry = mhi + c1 + c2;
            }

            s = t[n] + carry;
            ulong sc = s < carry ? 1UL : 0UL;
            t[n - 1] = s;
            t[n] = t[n + 1] + sc;
            t[n + 1] = 0;
        }

        // Final conditional subtraction: if t >= m, then t = t - m
        // t may have t[n] = 1, meaning t = 2^(64n) + t[..n] > m
        ulong borrow = BigUInt.Sub(t[..n], m, result);

        // Subtraction is invalid (need to restore t[..n]) only when borrow > t[n]:
        // borrow=1,t[n]=0 → t[..n] < m and no overflow → underflow, restore t
        // borrow=1,t[n]=1 → borrow compensated by t[n], subtraction valid
        // borrow=0 → t[..n] >= m, subtraction valid
        ulong underflow = borrow & (1 - t[n]);
        BigUInt.ConditionalCopy(underflow, result, t[..n]);
    }

    /// <summary>
    /// Computes Montgomery squaring: (a² · R⁻¹) mod m.
    /// </summary>
    /// <param name="a">Operand in Montgomery form (length <see cref="LimbCount"/>).</param>
    /// <param name="result">Square in Montgomery form (length <see cref="LimbCount"/>). Must not alias <paramref name="a"/>.</param>
    public void MontSquare(ReadOnlySpan<ulong> a, Span<ulong> result)
    {
        // For now, reuse MontMul. A dedicated squaring CIOS can be added later.
        MontMul(a, a, result);
    }

    /// <summary>
    /// Computes modular exponentiation: base^exp mod m, using Montgomery form internally.
    /// </summary>
    /// <param name="baseValue">Base value in normal form (less than modulus).</param>
    /// <param name="exponent">Exponent in normal form (little-endian limbs).</param>
    /// <param name="result">Result in normal form (length <see cref="LimbCount"/>).</param>
    /// <remarks>
    /// Uses a constant-time fixed-window method (window size 1, i.e., square-and-multiply-always)
    /// to prevent timing leaks from the exponent.
    /// </remarks>
    public void ModExp(ReadOnlySpan<ulong> baseValue, ReadOnlySpan<ulong> exponent, Span<ulong> result)
    {
        int n = _limbCount;

        // Convert base to Montgomery form
        Span<ulong> baseMont = stackalloc ulong[n];
        ToMontgomery(baseValue, baseMont);

        // result = 1 in Montgomery form (= R mod m)
        Span<ulong> accMont = stackalloc ulong[n];
        Span<ulong> one = stackalloc ulong[n];
        one.Clear();
        one[0] = 1;
        ToMontgomery(one, accMont);

        Span<ulong> temp = stackalloc ulong[n];

        // Square-and-multiply-always (constant-time)
        int totalBits = BigUInt.BitLength(exponent);
        if (totalBits == 0) totalBits = 1;

        for (int i = totalBits - 1; i >= 0; i--)
        {
            // Always square
            MontMul(accMont, accMont, temp);
            temp.CopyTo(accMont);

            // Always multiply, but conditionally use the result
            MontMul(accMont, baseMont, temp);

            int limbIdx = i / 64;
            int bitIdx = i % 64;
            ulong bit = limbIdx < exponent.Length ? (exponent[limbIdx] >> bitIdx) & 1 : 0;

            BigUInt.ConditionalCopy(bit, accMont, temp);
        }

        // Convert back from Montgomery form
        FromMontgomery(accMont, result);
    }

    /// <summary>
    /// Computes (a + b) mod m in constant time.
    /// </summary>
    /// <param name="a">First operand (less than modulus).</param>
    /// <param name="b">Second operand (less than modulus).</param>
    /// <param name="result">Sum mod m.</param>
    public void ModAdd(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b, Span<ulong> result)
    {
        int n = _limbCount;
        ulong carry = BigUInt.Add(a, b, result);

        // Conditionally subtract modulus if result >= m
        Span<ulong> temp = stackalloc ulong[n];
        ulong borrow = BigUInt.Sub(result, _modulus, temp);

        // subtract if: carry == 1 (overflow) or borrow == 0 (result >= m)
        // keep subtraction if carry | ~borrow's MSB... simpler: subtract succeeded (no borrow) or we had carry
        ulong doSub = carry | (1 - borrow);
        BigUInt.ConditionalCopy(doSub, result, temp);
    }

    /// <summary>
    /// Computes (a - b) mod m in constant time.
    /// </summary>
    /// <param name="a">First operand (less than modulus).</param>
    /// <param name="b">Second operand (less than modulus).</param>
    /// <param name="result">Difference mod m.</param>
    public void ModSub(ReadOnlySpan<ulong> a, ReadOnlySpan<ulong> b, Span<ulong> result)
    {
        int n = _limbCount;
        ulong borrow = BigUInt.Sub(a, b, result);

        // If borrow, add modulus back
        Span<ulong> temp = stackalloc ulong[n];
        BigUInt.Add(result, _modulus, temp);
        BigUInt.ConditionalCopy(borrow, result, temp);
    }

    // ========================================================================
    // Private Helpers
    // ========================================================================

    /// <summary>
    /// Computes -m⁻¹ mod 2⁶⁴ using the Newton's method (Hensel lifting).
    /// </summary>
    /// <param name="m0">The least significant limb of the modulus (must be odd).</param>
    /// <returns>The value m' such that m0 · m' ≡ -1 (mod 2⁶⁴).</returns>
    private static ulong ComputeModInverse64(ulong m0)
    {
        // Newton's method: x_{n+1} = x_n(2 - m0·x_n) mod 2^{2^n}
        // Converges to m0⁻¹ mod 2⁶⁴ in 6 iterations (starting from mod 2)
        ulong x = 1; // m0⁻¹ mod 2 = 1 (since m0 is odd)
        for (int i = 0; i < 6; i++)
        {
            x *= 2 - m0 * x;
        }

        // Return -m⁻¹ mod 2⁶⁴
        return 0UL - x;
    }

    /// <summary>
    /// Computes R² mod m where R = 2^(64·n), used for converting to Montgomery form.
    /// </summary>
    private static ulong[] ComputeRSquared(ReadOnlySpan<ulong> modulus)
    {
        int n = modulus.Length;

        // Start with R mod m = 2^(64n) mod m
        // We compute this by repeated doubling: start with 1, double 64*n*2 times
        // (since we need R² = 2^(128n) mod m)

        ulong[] result = new ulong[n];
        result[0] = 1;

        // Double 2*64*n times to get R² mod m
        int totalBits = 2 * 64 * n;
        ulong[] temp = new ulong[n];
        for (int i = 0; i < totalBits; i++)
        {
            // result = result * 2 mod m
            ulong carry = BigUInt.ShiftLeft(result, 1, temp);

            // If carry or temp >= m, subtract m
            ulong borrow = BigUInt.Sub(temp, modulus, result);

            // If borrow and no carry, the subtraction underflowed — use temp instead
            ulong useSub = carry | (1 - borrow);
            BigUInt.ConditionalCopy(1 - useSub, result, temp);
        }

        return result;
    }
}
