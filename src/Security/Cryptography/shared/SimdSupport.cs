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
    /// All available SIMD optimizations (default behavior).
    /// </summary>
    All = Sse2 | Ssse3 | Avx2 | Avx512F | Neon | AesNi | PClMul | PClMulV256,

    /// <summary>
    /// The default optimization to use for Keccak based algorithms.
    /// Set to None since Keccak is faster with scalar instructions.
    /// </summary>
    KeccakDefault = None
}
