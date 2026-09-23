// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

using System;

/// <summary>
/// Specifies the SIMD instruction set support for cryptographic algorithm implementations.
/// </summary>
/// <remarks>
/// This enum is used to control which SIMD optimizations are used by hash algorithms
/// and cipher implementations, and to query which optimizations are available on the
/// current platform.
/// </remarks>
[Flags]
internal enum SimdSupport
{
    /// <summary>
    /// No SIMD acceleration (pure scalar implementation).
    /// </summary>
    None = 0,

    /// <summary>
    /// SSE2 instruction set support (128-bit vectors).
    /// </summary>
    Sse2 = 1 << 0,

    /// <summary>
    /// SSSE3 instruction set support (adds byte shuffle).
    /// </summary>
    Ssse3 = 1 << 1,

    /// <summary>
    /// AVX2 instruction set support (256-bit vectors, gather).
    /// </summary>
    Avx2 = 1 << 2,

    /// <summary>
    /// AVX-512F instruction set support (512-bit vectors).
    /// </summary>
    Avx512F = 1 << 3,

    /// <summary>
    /// ARM NEON instruction set support.
    /// </summary>
    Neon = 1 << 4,

    /// <summary>
    /// AES-NI instruction set support (hardware AES acceleration).
    /// </summary>
    AesNi = 1 << 5,

    /// <summary>
    /// PClMul instruction set support.
    /// </summary>
    PClMul = 1 << 6,

    /// <summary>
    /// PClMul V256 instruction set support.
    /// </summary>
    PClMulV256 = 1 << 7,

    /// <summary>
    /// ARM AES cryptographic extension support (hardware AES acceleration).
    /// </summary>
    ArmAes = 1 << 8,

    /// <summary>
    /// ARM PMULL polynomial multiply extension support (carry-less multiply).
    /// </summary>
    ArmPmull = 1 << 9,

    /// <summary>
    /// ARM SHA-256 cryptographic extension support.
    /// </summary>
    ArmSha256 = 1 << 10,

    /// <summary>
    /// ARM64 specific implementation.
    /// </summary>
    Arm64 = 1 << 11,

    /// <summary>
    /// ARM SHA-1 cryptographic extension support.
    /// </summary>
    ArmSha1 = 1 << 12,

    /// <summary>
    /// All available SIMD optimizations (default behavior).
    /// </summary>
    All = Sse2 | Ssse3 | Avx2 | Avx512F | Neon | AesNi | PClMul | PClMulV256 | ArmAes | ArmPmull | ArmSha256 | Arm64 | ArmSha1,
}

/// <summary>
/// Helper to set implicit SIMD dependencies and hierarchy.
/// </summary>
internal static class SimdSupportExtensions
{
    /// <summary>
    /// Adds every instruction set the ones in <paramref name="input"/> imply, so a caller
    /// selecting one tier gets the same set a CPU offering that tier would.
    /// </summary>
    /// <remarks>
    /// Each step names only the immediate parent and relies on the preceding step having run,
    /// so the order is load-bearing: widest first, and a feature that pulls in a vector width
    /// before the step for that width.
    /// </remarks>
    public static SimdSupport WithImplicit(this SimdSupport input)
    {
        // VPCLMULQDQ is AVX-encoded and architecturally implies PCLMULQDQ.
        if ((input & SimdSupport.PClMulV256) != 0)
        {
            input |= SimdSupport.PClMul | SimdSupport.Avx2;
        }

        if ((input & SimdSupport.Avx512F) != 0)
        {
            input |= SimdSupport.Avx2;
        }

        if ((input & SimdSupport.Avx2) != 0)
        {
            input |= SimdSupport.Ssse3;
        }

        // AES-NI and PCLMULQDQ operate on XMM registers. Both also happen to be Westmere-era,
        // so SSSE3 comes with them on every shipping part, but that is not architectural.
        if ((input & (SimdSupport.Ssse3 | SimdSupport.AesNi | SimdSupport.PClMul)) != 0)
        {
            input |= SimdSupport.Sse2;
        }

        // FEAT_PMULL is the higher value of the same AArch64 feature field as FEAT_AES.
        if ((input & SimdSupport.ArmPmull) != 0)
        {
            input |= SimdSupport.ArmAes;
        }

        // Arm64 pulls in Neon because AArch64 mandates Advanced SIMD, but not the reverse:
        // Arm64 also selects scalar AArch64 paths, which a Neon-tier caller has not asked for.
        if ((input & (SimdSupport.Arm64 | SimdSupport.ArmAes | SimdSupport.ArmSha1 | SimdSupport.ArmSha256)) != 0)
        {
            input |= SimdSupport.Neon;
        }

        return input;
    }
}



