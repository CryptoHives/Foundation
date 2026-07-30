// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Specifies which implementation of a hash algorithm to use.
/// </summary>
public enum HashImplementationKind
{
    /// <summary>
    /// Always use the self-contained managed implementation. This is the default: deterministic
    /// and free of any OS or hardware cryptography-provider dependency.
    /// </summary>
    Managed,

    /// <summary>
    /// Always use the OS-native implementation (via the .NET base class library, which in turn
    /// delegates to CNG/OpenSSL/CommonCrypto depending on platform) if one is available for the
    /// requested algorithm; otherwise falls back to the managed implementation.
    /// </summary>
    /// <remarks>
    /// Selecting this relies on the correctness of the underlying OS crypto provider instead of
    /// this library's self-contained managed code - a trust-boundary change, not just a performance
    /// choice. It also requires a functioning OS crypto stack, which may not be available in some
    /// minimal container or FIPS-restricted environments.
    /// </remarks>
    OsNative,

    /// <summary>
    /// Use whichever implementation curated benchmark data indicates is fastest on the current
    /// operating system and architecture for the requested algorithm. Combinations that have not
    /// yet been benchmark-validated fall back to <see cref="Managed"/>. Newly curated preferences
    /// require an <c>EXPERIMENTAL</c> build until validated across the full supported platform matrix.
    /// </summary>
    /// <remarks>
    /// Carries the same trust-boundary caveat as <see cref="OsNative"/> for any platform where the
    /// OS-native implementation is currently preferred.
    /// </remarks>
    Auto
}
