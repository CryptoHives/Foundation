// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Provides endian-aware bulk copy between byte spans and typed word spans.
/// </summary>
/// <remarks>
/// <para>
/// On little-endian systems (the common case), these methods use
/// <see cref="MemoryMarshal"/> to perform a direct memory copy, avoiding
/// per-element <see cref="BinaryPrimitives"/> calls.
/// </para>
/// <para>
/// On big-endian systems, each element is converted individually via
/// <see cref="BinaryPrimitives"/>.
/// </para>
/// </remarks>
internal static class BinarySpans
{
    /// <summary>
    /// Reads little-endian <see cref="UInt32"/> words from a byte span into a destination word span.
    /// </summary>
    /// <param name="source">The source bytes. The number of words read is <c>source.Length / 4</c>.</param>
    /// <param name="destination">The destination word span (must have room for the words derived from <paramref name="source"/>).</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ReadUInt32LittleEndian(ReadOnlySpan<byte> source, Span<uint> destination)
    {
        int count = source.Length / sizeof(UInt32);

        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Cast<byte, uint>(source).Slice(0, count).CopyTo(destination);
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                destination[i] = BinaryPrimitives.ReadUInt32LittleEndian(source.Slice(i * sizeof(UInt32)));
            }
        }
    }

    /// <summary>
    /// Reads little-endian <see cref="UInt64"/> words from a byte span into a destination word span.
    /// </summary>
    /// <param name="source">The source bytes. The number of words read is <c>source.Length / 8</c>.</param>
    /// <param name="destination">The destination word span (must have room for the words derived from <paramref name="source"/>).</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ReadUInt64LittleEndian(ReadOnlySpan<byte> source, Span<ulong> destination)
    {
        int count = source.Length / sizeof(UInt64);

        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.Cast<byte, ulong>(source).Slice(0, count).CopyTo(destination);
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                destination[i] = BinaryPrimitives.ReadUInt64LittleEndian(source.Slice(i * sizeof(UInt64)));
            }
        }
    }

    /// <summary>
    /// Writes <see cref="UInt32"/> words to a byte span in little-endian order.
    /// </summary>
    /// <param name="source">The source word span.</param>
    /// <param name="destination">The destination bytes (must be at least <paramref name="source"/>.Length × 4 bytes).</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt32LittleEndian(ReadOnlySpan<uint> source, Span<byte> destination)
    {
        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.AsBytes(source).CopyTo(destination);
        }
        else
        {
            for (int i = 0; i < source.Length; i++)
            {
                BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(i * sizeof(UInt32)), source[i]);
            }
        }
    }

    /// <summary>
    /// Writes <see cref="UInt64"/> words to a byte span in little-endian order.
    /// </summary>
    /// <param name="source">The source word span.</param>
    /// <param name="destination">The destination bytes (must be at least <paramref name="source"/>.Length × 8 bytes).</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt64LittleEndian(ReadOnlySpan<ulong> source, Span<byte> destination)
    {
        if (BitConverter.IsLittleEndian)
        {
            MemoryMarshal.AsBytes(source).CopyTo(destination);
        }
        else
        {
            for (int i = 0; i < source.Length; i++)
            {
                BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(i * sizeof(UInt64)), source[i]);
            }
        }
    }
}
