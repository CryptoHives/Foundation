// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System.Buffers.Binary;
using System.Runtime.CompilerServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using ArmAes = System.Runtime.Intrinsics.Arm.Aes;
#endif

/// <summary>
/// 64 × 64 → 128-bit carry-less multiply on PCLMULQDQ, ARM PMULL or a constant-time scalar fallback.
/// </summary>
internal readonly struct CarrylessMultiplier
{
#if NET8_0_OR_GREATER
    private readonly bool _usePclmul;
    private readonly bool _usePmull;
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="CarrylessMultiplier"/> struct.
    /// </summary>
    /// <param name="simdSupport">The instructions to use; flags the platform lacks are ignored.</param>
    public CarrylessMultiplier(SimdSupport simdSupport)
    {
#if NET8_0_OR_GREATER
        simdSupport &= SimdSupport;
        _usePclmul = (simdSupport & SimdSupport.PClMul) != 0;
        _usePmull = (simdSupport & SimdSupport.ArmPmull) != 0;
#endif
    }

    /// <summary>
    /// Gets the carry-less multiply instructions available on the current platform.
    /// </summary>
    public static SimdSupport SimdSupport =>
#if NET8_0_OR_GREATER
        (Pclmulqdq.IsSupported ? SimdSupport.PClMul : SimdSupport.None) |
        (ArmAes.IsSupported ? SimdSupport.ArmPmull : SimdSupport.None);
#else
        SimdSupport.None;
#endif

    /// <summary>
    /// Computes the 128-bit carry-less product of <paramref name="a"/> and <paramref name="b"/>.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public void Multiply(ulong a, ulong b, out ulong hi, out ulong lo)
    {
#if NET8_0_OR_GREATER
        if (_usePclmul && Pclmulqdq.IsSupported)
        {
            Vector128<ulong> product = Pclmulqdq.CarrylessMultiply(Vector128.CreateScalar(a), Vector128.CreateScalar(b), 0x00);
            lo = product.GetElement(0);
            hi = product.GetElement(1);
            return;
        }

        if (_usePmull && ArmAes.IsSupported)
        {
            Vector128<ulong> product = ArmAes.PolynomialMultiplyWideningLower(Vector64.Create(a), Vector64.Create(b));
            lo = product.GetElement(0);
            hi = product.GetElement(1);
            return;
        }
#endif
        lo = MultiplyLow(a, b);
        hi = ReverseBits(MultiplyLow(ReverseBits(a), ReverseBits(b))) >> 1;
    }

    /// <summary>
    /// The low 64 bits of a carry-less product, built from integer multiplies with 3-bit holes
    /// between the data bits so that the carries never reach a bit that is kept.
    /// </summary>
    /// <remarks>
    /// Constant time wherever integer multiplication is, as on every 64-bit CPU .NET supports.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static ulong MultiplyLow(ulong x, ulong y)
    {
        const ulong M0 = 0x1111111111111111, M1 = M0 << 1, M2 = M0 << 2, M3 = M0 << 3;

        ulong x0 = x & M0, x1 = x & M1, x2 = x & M2, x3 = x & M3;
        ulong y0 = y & M0, y1 = y & M1, y2 = y & M2, y3 = y & M3;

        ulong z0 = (x0 * y0) ^ (x1 * y3) ^ (x2 * y2) ^ (x3 * y1);
        ulong z1 = (x0 * y1) ^ (x1 * y0) ^ (x2 * y3) ^ (x3 * y2);
        ulong z2 = (x0 * y2) ^ (x1 * y1) ^ (x2 * y0) ^ (x3 * y3);
        ulong z3 = (x0 * y3) ^ (x1 * y2) ^ (x2 * y1) ^ (x3 * y0);

        return (z0 & M0) | (z1 & M1) | (z2 & M2) | (z3 & M3);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static ulong ReverseBits(ulong x)
    {
        x = ((x >> 1) & 0x5555555555555555) | ((x & 0x5555555555555555) << 1);
        x = ((x >> 2) & 0x3333333333333333) | ((x & 0x3333333333333333) << 2);
        x = ((x >> 4) & 0x0F0F0F0F0F0F0F0F) | ((x & 0x0F0F0F0F0F0F0F0F) << 4);
        return BinaryPrimitives.ReverseEndianness(x);
    }
}
