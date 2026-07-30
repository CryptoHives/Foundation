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
    /// Prefer the OS-native (BCL/CNG/OpenSSL/CommonCrypto) implementation over the managed one, for
    /// algorithms that have one available.
    /// </summary>
    /// <remarks>
    /// Unlike every other bit in this enum, this is not a CPU-ISA capability - an algorithm's static
    /// capability property reports it as supported whenever an OS-native implementation actually exists
    /// for that algorithm on the current runtime (see each algorithm's <c>CreateOsNativeInstance</c>
    /// override), independent of whether it is known to be faster. Whether it is *recommended* by
    /// default (i.e. requested automatically via <c>HashImplementationKind.Auto</c>) is a separate,
    /// curated, per-platform decision made by <see cref="OsNativeDefaults"/> based on benchmark data -
    /// requesting this bit directly always honors it if available, bypassing that curation. Selecting it
    /// changes the correctness-trust boundary (the OS crypto provider is relied on instead of this
    /// library's self-contained managed code), not just performance, so it is deliberately excluded from
    /// <see cref="All"/> and must always be requested explicitly.
    /// </remarks>
    Os = 1 << 12,

    /// <summary>
    /// All available SIMD optimizations (default behavior).
    /// </summary>
    All = Sse2 | Ssse3 | Avx2 | Avx512F | Neon | AesNi | PClMul | PClMulV256 | ArmAes | ArmPmull | ArmSha256 | Arm64,

    /// <summary>
    /// The default optimization to use for Keccak based algorithms.
    /// Enables the ARM64 scalar path (<see cref="Arm64"/>) which is automatically
    /// masked to <see cref="None"/> on non-ARM64 platforms.
    /// </summary>
    KeccakDefault = Arm64
}
