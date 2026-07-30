// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Curated, per-algorithm, per-platform defaults for whether the OS-native implementation of a
/// hash algorithm is known to outperform this library's managed implementation.
/// </summary>
/// <remarks>
/// <para>
/// Consulted only by <see cref="Hash.HashAlgorithm.Create(string, Hash.HashImplementationKind)"/> when
/// <see cref="Hash.HashImplementationKind.Auto"/> is requested, to decide whether to request the
/// <see cref="SimdSupport.Os"/> bit at all. It does not gate whether an algorithm's OS-native
/// implementation is available in the first place (each algorithm's static <c>SimdSupport</c>
/// capability property reports that independently) - an explicit <see cref="SimdSupport.Os"/> request
/// or <see cref="Hash.HashImplementationKind.OsNative"/> always honors OS-native if available,
/// bypassing this curation entirely.
/// </para>
/// <para>
/// Each property is sourced from benchmark runs recorded in
/// <c>docfx/packages/security/cryptography/benchmark-trends/benchmark-history.sqlite</c>
/// (see <c>scripts/cryptography-benchmark-trends/schema.sql</c>), comparing the <c>'OS'</c> variant
/// against the best <c>'CryptoHives-*'</c> variant for a given algorithm/platform pair. A property
/// only returns <see langword="true"/> once OS-native is a confirmed, repeatable win on that
/// specific OS+architecture combination.
/// </para>
/// <para>
/// Every case here is gated by <c>EXPERIMENTAL</c> until it has been benchmark-validated across
/// the full target matrix (Windows/Linux/macOS x x64/Arm64) for that algorithm - mirroring the
/// existing precedent for the Keccak AVX2/AVX-512 permutation paths, which remain
/// <c>EXPERIMENTAL</c>-gated because they benchmarked slower than scalar. This keeps release NuGet
/// packages (built with <c>/p:EnableExperimentalAlgorithms=false</c>) fully deterministic and
/// self-contained by default, regardless of what preference an application requests.
/// </para>
/// </remarks>
internal static class OsNativeDefaults
{
    /// <summary>Whether OS-native SHA-256 is preferred on the current platform.</summary>
    internal static bool Sha256 =>
#if EXPERIMENTAL
        false; // No curated data yet.
#else
        false;
#endif

    /// <summary>Whether OS-native SHA-384 is preferred on the current platform.</summary>
    internal static bool Sha384 =>
#if EXPERIMENTAL
        false; // No curated data yet.
#else
        false;
#endif

    /// <summary>Whether OS-native SHA-512 is preferred on the current platform.</summary>
    internal static bool Sha512 =>
#if EXPERIMENTAL
        false; // No curated data yet.
#else
        false;
#endif

    /// <summary>Whether OS-native SHA3-256 is preferred on the current platform.</summary>
    internal static bool Sha3_256 =>
#if EXPERIMENTAL
        false; // No curated data yet.
#else
        false;
#endif

    /// <summary>Whether OS-native SHA3-384 is preferred on the current platform.</summary>
    internal static bool Sha3_384 =>
#if EXPERIMENTAL
        false; // No curated data yet.
#else
        false;
#endif

    /// <summary>Whether OS-native SHA3-512 is preferred on the current platform.</summary>
    internal static bool Sha3_512 =>
#if EXPERIMENTAL
        false; // No curated data yet.
#else
        false;
#endif
}
