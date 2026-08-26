// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Provides <see cref="MemoryMarshal"/> members that are not available on every target framework.
/// </summary>
/// <remarks>
/// <para>
/// <c>MemoryMarshal.GetArrayDataReference</c> was introduced in .NET 5 and is absent from
/// net462, net472, netstandard2.0 and netstandard2.1, none of which the
/// <c>System.Memory</c> package fills in.
/// </para>
/// <para>
/// The legacy path returns <c>ref array[0]</c>, which the caller can advance with
/// <see cref="Unsafe.Add{T}(ref T, int)"/> exactly as on .NET 5+. That form costs a single
/// bounds check on entry rather than the per-element checks the table lookups exist to avoid,
/// and unlike a <see langword="fixed"/> pointer it does not pin the array for the duration of
/// the operation.
/// </para>
/// </remarks>
internal static class MemoryMarshalEx
{
    /// <summary>
    /// Returns a reference to the first element of <paramref name="array"/>.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="array">The array. Must not be <see langword="null"/> or empty — every caller
    /// passes a fixed lookup table, so the .NET 5+ overload's empty-array behaviour is never relied on.</param>
    /// <returns>A reference to element zero.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref T GetArrayDataReference<T>(T[] array)
    {
#if NET5_0_OR_GREATER
        return ref MemoryMarshal.GetArrayDataReference(array);
#else
        return ref array[0];
#endif
    }
}
