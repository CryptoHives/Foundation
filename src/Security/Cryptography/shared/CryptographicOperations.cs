// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Operations on secret data that a compiler is not permitted to optimize: erasing a buffer,
/// and comparing two in constant time.
/// </summary>
/// <remarks>
/// <para>
/// <b>Prefer <see cref="ZeroMemory(Span{byte})"/> over <see cref="Array.Clear(Array, int, int)"/>
/// or <c>Span&lt;T&gt;.Clear()</c> for anything secret.</b> Clearing a buffer you are about to
/// discard is a <i>dead store</i>: nothing reads the zeros back, so a compiler or JIT is entitled
/// to delete the write entirely and leave the key, password or plaintext sitting in memory.
/// Likewise prefer <see cref="FixedTimeEquals(ReadOnlySpan{byte}, ReadOnlySpan{byte})"/> over <c>SequenceEqual</c> when checking a MAC or
/// a tag, so the comparison cannot leak how many leading bytes matched.
/// </para>
/// </remarks>
public static class CryptographicOperations
{
    /// <summary>
    /// The number of bytes <see cref="ScrubStack"/> clears when no size is given.
    /// </summary>
    internal const int StackScrubBytes = 64;

    /// <summary>
    /// The most <see cref="ScrubStack"/> will clear, however large a size it is asked for.
    /// </summary>
    internal const int MaxStackScrubBytes = 2048;

    /// <summary>
    /// Erases the stack region just below the caller's frame, where the frames of the methods it
    /// has already called kept their locals and spills.
    /// </summary>
    /// <param name="length">The number of bytes to clear, limited to <see cref="MaxStackScrubBytes"/>.</param>
    /// <remarks>
    /// Best effort: call it last from the outermost method, after the work has returned. It reaches
    /// only <paramref name="length"/> bytes, so a callee chain with larger frames leaves its
    /// deepest part behind.
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.NoInlining)]
    internal static void ScrubStack(int length = StackScrubBytes)
    {
        if (length > MaxStackScrubBytes) length = MaxStackScrubBytes;

        Span<byte> scratch = stackalloc byte[length];
        ZeroMemory(scratch);
    }

    /// <summary>
    /// Fills a span with zeros in a way that is not subject to compiler optimizations.
    /// </summary>
    /// <param name="buffer">The buffer to clear.</param>
    // NoInlining keeps the init-block out of the caller, where a buffer nothing reads again
    // could have it removed as a dead store.
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ZeroMemory(Span<byte> buffer)
    {
        Unsafe.InitBlockUnaligned(ref MemoryMarshal.GetReference(buffer), 0, (uint)buffer.Length);
    }

    /// <summary>
    /// Fills an array with zeros in a way that is not subject to compiler optimizations.
    /// </summary>
    /// <param name="buffer">The buffer to clear. A <see langword="null"/> array is ignored.</param>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ZeroMemory(byte[] buffer)
    {
        if (buffer != null)
        {
            Unsafe.InitBlockUnaligned(ref MemoryMarshal.GetReference(buffer.AsSpan()), 0, (uint)buffer.Length);
        }
    }

    /// <summary>
    /// Fills a character span with zeros in a way that is not subject to compiler optimizations.
    /// </summary>
    /// <param name="buffer">The buffer to clear.</param>
    /// <remarks>
    /// Character buffers reach cryptographic code as passwords and as PEM text carrying private
    /// keys. Both are secret, and both are erasable only because they are <see langword="char"/>
    /// storage rather than a <see cref="string"/>.
    /// </remarks>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ZeroMemory(Span<char> buffer)
    {
        Span<byte> bytes = MemoryMarshal.AsBytes(buffer);
        Unsafe.InitBlockUnaligned(ref MemoryMarshal.GetReference(bytes), 0, (uint)bytes.Length);
    }

    /// <summary>
    /// Fills a character array with zeros in a way that is not subject to compiler optimizations.
    /// </summary>
    /// <param name="buffer">The buffer to clear. A <see langword="null"/> array is ignored.</param>
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ZeroMemory(char[] buffer)
    {
        if (buffer != null)
        {
            Span<byte> bytes = MemoryMarshal.AsBytes(buffer.AsSpan());
            Unsafe.InitBlockUnaligned(ref MemoryMarshal.GetReference(bytes), 0, (uint)bytes.Length);
        }
    }

    /// <summary>
    /// Compares two byte spans in constant time, to prevent timing attacks.
    /// </summary>
    /// <param name="left">First span to compare.</param>
    /// <param name="right">Second span to compare.</param>
    /// <returns><see langword="true"/> if the spans are equal, <see langword="false"/> otherwise.</returns>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static bool FixedTimeEquals(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
    {
        if (left.Length != right.Length)
        {
            return false;
        }

        int result = 0;
        for (int i = 0; i < left.Length; i++)
        {
            result |= left[i] ^ right[i];
        }

        return result == 0;
    }

    /// <summary>
    /// Determines in constant time whether every byte of a span equals a given value.
    /// </summary>
    /// <param name="source">The span to check.</param>
    /// <param name="value">The value every byte must equal.</param>
    /// <returns>
    /// <see langword="true"/> if every byte of <paramref name="source"/> equals <paramref name="value"/>
    /// or the span is empty, <see langword="false"/> otherwise.
    /// </returns>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static bool FixedTimeEquals(ReadOnlySpan<byte> source, byte value)
    {
        int result = 0;
        for (int i = 0; i < source.Length; i++)
        {
            result |= source[i] ^ value;
        }

        return result == 0;
    }

    /// <summary>
    /// Compares two byte spans in constant time and returns an all-ones or all-zeros mask.
    /// </summary>
    /// <param name="left">First span to compare.</param>
    /// <param name="right">Second span to compare. Must have the same length as <paramref name="left"/>.</param>
    /// <returns>-1 (all bits set) if the spans are equal, 0 otherwise.</returns>
    /// <remarks>
    /// <para>
    /// Unlike <see cref="FixedTimeEquals(ReadOnlySpan{byte}, ReadOnlySpan{byte})"/>, the result is a branchless mask suitable for
    /// constant-time selection without converting to <see cref="bool"/>, which would
    /// reintroduce a secret-dependent branch.
    /// </para>
    /// <para>
    /// Internal on purpose: it exists for ML-KEM implicit rejection and similar
    /// select-without-branching needs inside this library. A caller who wants "are these equal"
    /// wants <see cref="FixedTimeEquals(ReadOnlySpan{byte}, ReadOnlySpan{byte})"/>, which is public.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    internal static int FixedTimeEqualsMask(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right)
    {
        if (left.Length != right.Length)
        {
            return 0;
        }

        int result = 0;
        for (int i = 0; i < left.Length; i++)
        {
            result |= left[i] ^ right[i];
        }

        // result is 0..255; (result - 1) >> 31 arithmetic-shifts to -1 when result == 0, else 0.
        return (result - 1) >> 31;
    }
}
