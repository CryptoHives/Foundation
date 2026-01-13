// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

using System.Runtime.CompilerServices;

/// <summary>
/// Provides extended <see cref="MethodImplOptions"/> constants for cross-platform optimization hints.
/// </summary>
/// <remarks>
/// <para>
/// <c>MethodImplOptions.AggressiveOptimization</c> is only available on .NET 5+.
/// This helper provides constants that apply the appropriate flags based on the target framework.
/// </para>
/// </remarks>
internal static class MethodImplOptionsEx
{
    /// <summary>
    /// Optimization hint for hot-path methods that benefit from both inlining and aggressive optimization.
    /// </summary>
    /// <remarks>
    /// On .NET 8+: <c>AggressiveInlining | AggressiveOptimization</c>.
    /// On older frameworks: <see cref="MethodImplOptions.AggressiveInlining"/> only.
    /// </remarks>
#if NET8_0_OR_GREATER
    public const MethodImplOptions HotPath = MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization;
#else
    public const MethodImplOptions HotPath = MethodImplOptions.AggressiveInlining;
#endif

    /// <summary>
    /// Optimization hint for methods with loops or complex logic that benefit from aggressive optimization
    /// but are too large to inline.
    /// </summary>
    /// <remarks>
    /// On .NET 8+: <c>AggressiveOptimization</c>.
    /// On older frameworks: <see cref="MethodImplOptions.NoInlining"/> (best available hint).
    /// </remarks>
#if NET8_0_OR_GREATER
    public const MethodImplOptions OptimizedLoop = MethodImplOptions.AggressiveOptimization;
#else
    public const MethodImplOptions OptimizedLoop = MethodImplOptions.NoInlining;
#endif
}
