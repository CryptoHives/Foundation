// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

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
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt32LittleEndian(ReadOnlySpan<byte> source, Span<uint> destination)
    {
        int count = source.Length / sizeof(UInt32);
        destination = destination.Slice(0, count);
        ref byte src = ref MemoryMarshal.GetReference(source);
        ref uint dst = ref MemoryMarshal.GetReference(destination);
        if (!BitConverter.IsLittleEndian)
        {
            for (nuint i = 0; i < (nuint)count; i++)
            {
                Unsafe.Add(ref dst, i) = BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref src, i * sizeof(UInt32))));
            }
        }
        else
        {
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<uint, byte>(ref dst), ref src, (uint)(count * sizeof(UInt32)));
        }
    }

    /// <summary>
    /// Reads little-endian <see cref="UInt64"/> words from a byte span into a destination word span.
    /// </summary>
    /// <param name="source">The source bytes. The number of words read is <c>source.Length / 8</c>.</param>
    /// <param name="destination">The destination word span (must have room for the words derived from <paramref name="source"/>).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64LittleEndian(ReadOnlySpan<byte> source, Span<ulong> destination)
    {
        int count = source.Length / sizeof(UInt64);
        destination = destination.Slice(0, count);
        ref byte src = ref MemoryMarshal.GetReference(source);
        ref ulong dst = ref MemoryMarshal.GetReference(destination);
        if (!BitConverter.IsLittleEndian)
        {
            for (nuint i = 0; i < (nuint)count; i++)
            {
                Unsafe.Add(ref dst, i) = BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref src, i * sizeof(UInt64))));
            }
        }
        else
        {
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<ulong, byte>(ref dst), ref src, (uint)(count * sizeof(UInt64)));
        }
    }

    /// <summary>
    /// Reads big-endian <see cref="UInt32"/> words from a byte span into a destination word span.
    /// </summary>
    /// <param name="source">The source bytes. The number of words read is <c>source.Length / 4</c>.</param>
    /// <param name="destination">The destination word span (must have room for the words derived from <paramref name="source"/>).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt32BigEndian(ReadOnlySpan<byte> source, Span<uint> destination)
    {
        int count = source.Length / sizeof(UInt32);
        destination = destination.Slice(0, count);
        ref byte src = ref MemoryMarshal.GetReference(source);
        ref uint dst = ref MemoryMarshal.GetReference(destination);
        if (BitConverter.IsLittleEndian)
        {
            for (nuint i = 0; i < (nuint)count; i++)
            {
                Unsafe.Add(ref dst, i) = BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref src, i * sizeof(UInt32))));
            }
        }
        else
        {
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<uint, byte>(ref dst), ref src, (uint)(count * sizeof(UInt32)));
        }
    }

    /// <summary>
    /// Reads big-endian <see cref="UInt64"/> words from a byte span into a destination word span.
    /// </summary>
    /// <param name="source">The source bytes. The number of words read is <c>source.Length / 8</c>.</param>
    /// <param name="destination">The destination word span (must have room for the words derived from <paramref name="source"/>).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64BigEndian(ReadOnlySpan<byte> source, Span<ulong> destination)
    {
        int count = source.Length / sizeof(UInt64);
        destination = destination.Slice(0, count);
        ref byte src = ref MemoryMarshal.GetReference(source);
        ref ulong dst = ref MemoryMarshal.GetReference(destination);
        if (BitConverter.IsLittleEndian)
        {
            for (nuint i = 0; i < (nuint)count; i++)
            {
                Unsafe.Add(ref dst, i) = BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref src, i * sizeof(UInt64))));
            }
        }
        else
        {
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<ulong, byte>(ref dst), ref src, (uint)(count * sizeof(UInt64)));
        }
    }

    /// <summary>
    /// Writes <see cref="UInt32"/> words to a byte span in big-endian order.
    /// </summary>
    /// <param name="source">The source word span.</param>
    /// <param name="destination">The destination bytes (must be at least <paramref name="source"/>.Length × 4 bytes).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt32BigEndian(ReadOnlySpan<uint> source, Span<byte> destination)
    {
        destination = destination.Slice(0, source.Length * sizeof(UInt32));
        ref uint src = ref MemoryMarshal.GetReference(source);
        ref byte dst = ref MemoryMarshal.GetReference(destination);
        if (BitConverter.IsLittleEndian)
        {
            for (nuint i = 0; i < (nuint)source.Length; i++)
            {
                Unsafe.WriteUnaligned(ref Unsafe.Add(ref dst, i * sizeof(UInt32)), BinaryPrimitives.ReverseEndianness(Unsafe.Add(ref src, i)));
            }
        }
        else
        {
            Unsafe.CopyBlockUnaligned(ref dst, ref Unsafe.As<uint, byte>(ref src), (uint)(source.Length * sizeof(UInt32)));
        }
    }

    /// <summary>
    /// Writes <see cref="UInt64"/> words to a byte span in big-endian order.
    /// </summary>
    /// <param name="source">The source word span.</param>
    /// <param name="destination">The destination bytes (must be at least <paramref name="source"/>.Length × 8 bytes).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64BigEndian(ReadOnlySpan<ulong> source, Span<byte> destination)
    {
        destination = destination.Slice(0, source.Length * sizeof(UInt64));
        ref ulong src = ref MemoryMarshal.GetReference(source);
        ref byte dst = ref MemoryMarshal.GetReference(destination);
        if (BitConverter.IsLittleEndian)
        {
            for (nuint i = 0; i < (nuint)source.Length; i++)
            {
                Unsafe.WriteUnaligned(ref Unsafe.Add(ref dst, i * sizeof(UInt64)), BinaryPrimitives.ReverseEndianness(Unsafe.Add(ref src, i)));
            }
        }
        else
        {
            Unsafe.CopyBlockUnaligned(ref dst, ref Unsafe.As<ulong, byte>(ref src), (uint)(source.Length * sizeof(UInt64)));
        }
    }

    /// <summary>
    /// Reads two big-endian <see cref="UInt64"/> words from the first 16 bytes of a span.
    /// </summary>
    /// <param name="source">The source bytes (at least 16).</param>
    /// <param name="first">The word at offset 0.</param>
    /// <param name="second">The word at offset 8.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ReadUInt64PairBigEndian(ReadOnlySpan<byte> source, out ulong first, out ulong second)
    {
        ref byte src = ref MemoryMarshal.GetReference(source.Slice(0, 2 * sizeof(UInt64)));
        first = Unsafe.ReadUnaligned<ulong>(ref src);
        second = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref src, sizeof(UInt64)));
        if (BitConverter.IsLittleEndian)
        {
            first = BinaryPrimitives.ReverseEndianness(first);
            second = BinaryPrimitives.ReverseEndianness(second);
        }
    }

    /// <summary>
    /// Writes two <see cref="UInt64"/> words big-endian into the first 16 bytes of a span.
    /// </summary>
    /// <param name="destination">The destination bytes (at least 16).</param>
    /// <param name="first">The word written at offset 0.</param>
    /// <param name="second">The word written at offset 8.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt64PairBigEndian(Span<byte> destination, ulong first, ulong second)
    {
        ref byte dst = ref MemoryMarshal.GetReference(destination.Slice(0, 2 * sizeof(UInt64)));
        Unsafe.WriteUnaligned(ref dst, BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(first) : first);
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref dst, sizeof(UInt64)), BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(second) : second);
    }

    /// <summary>
    /// Reads four big-endian <see cref="UInt32"/> words from the first 16 bytes of a span.
    /// </summary>
    /// <param name="source">The source bytes (at least 16).</param>
    /// <param name="w0">The word at offset 0.</param>
    /// <param name="w1">The word at offset 4.</param>
    /// <param name="w2">The word at offset 8.</param>
    /// <param name="w3">The word at offset 12.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ReadUInt32QuadBigEndian(ReadOnlySpan<byte> source, out uint w0, out uint w1, out uint w2, out uint w3)
    {
        ref byte src = ref MemoryMarshal.GetReference(source.Slice(0, 4 * sizeof(UInt32)));
        w0 = Unsafe.ReadUnaligned<uint>(ref src);
        w1 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref src, sizeof(UInt32)));
        w2 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref src, 2 * sizeof(UInt32)));
        w3 = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref src, 3 * sizeof(UInt32)));
        if (BitConverter.IsLittleEndian)
        {
            w0 = BinaryPrimitives.ReverseEndianness(w0);
            w1 = BinaryPrimitives.ReverseEndianness(w1);
            w2 = BinaryPrimitives.ReverseEndianness(w2);
            w3 = BinaryPrimitives.ReverseEndianness(w3);
        }
    }

    /// <summary>
    /// Writes four <see cref="UInt32"/> words big-endian into the first 16 bytes of a span.
    /// </summary>
    /// <param name="destination">The destination bytes (at least 16).</param>
    /// <param name="w0">The word written at offset 0.</param>
    /// <param name="w1">The word written at offset 4.</param>
    /// <param name="w2">The word written at offset 8.</param>
    /// <param name="w3">The word written at offset 12.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void WriteUInt32QuadBigEndian(Span<byte> destination, uint w0, uint w1, uint w2, uint w3)
    {
        ref byte dst = ref MemoryMarshal.GetReference(destination.Slice(0, 4 * sizeof(UInt32)));
        Unsafe.WriteUnaligned(ref dst, BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(w0) : w0);
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref dst, sizeof(UInt32)), BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(w1) : w1);
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref dst, 2 * sizeof(UInt32)), BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(w2) : w2);
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref dst, 3 * sizeof(UInt32)), BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(w3) : w3);
    }

    /// <summary>
    /// Reads little-endian <see cref="UInt32"/> words from a byte pointer into a destination pointer.
    /// </summary>
    /// <param name="source">Pointer to the source bytes (at least <paramref name="count"/> × 4 bytes).</param>
    /// <param name="destination">Pointer to the destination words.</param>
    /// <param name="count">The number of words to read.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void ReadUInt32LittleEndian(byte* source, uint* destination, int count)
    {
        if (BitConverter.IsLittleEndian)
        {
            Unsafe.CopyBlockUnaligned(destination, source, (uint)(count * sizeof(uint)));
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                destination[i] = BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<uint>(source + i * sizeof(uint)));
            }
        }
    }

    /// <summary>
    /// Reads little-endian <see cref="UInt64"/> words from a byte pointer into a destination pointer.
    /// </summary>
    /// <param name="source">Pointer to the source bytes (at least <paramref name="count"/> × 8 bytes).</param>
    /// <param name="destination">Pointer to the destination words.</param>
    /// <param name="count">The number of words to read.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void ReadUInt64LittleEndian(byte* source, ulong* destination, int count)
    {
        if (BitConverter.IsLittleEndian)
        {
            Unsafe.CopyBlockUnaligned(destination, source, (uint)(count * sizeof(ulong)));
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                destination[i] = BinaryPrimitives.ReverseEndianness(Unsafe.ReadUnaligned<ulong>(source + i * sizeof(ulong)));
            }
        }
    }

    /// <summary>
    /// Writes <see cref="UInt32"/> words to a byte span in little-endian order.
    /// </summary>
    /// <param name="source">The source word span.</param>
    /// <param name="destination">The destination bytes (must be at least <paramref name="source"/>.Length × 4 bytes).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt32LittleEndian(ReadOnlySpan<uint> source, Span<byte> destination)
    {
        destination = destination.Slice(0, source.Length * sizeof(UInt32));
        ref uint src = ref MemoryMarshal.GetReference(source);
        ref byte dst = ref MemoryMarshal.GetReference(destination);
        if (!BitConverter.IsLittleEndian)
        {
            for (nuint i = 0; i < (nuint)source.Length; i++)
            {
                Unsafe.WriteUnaligned(ref Unsafe.Add(ref dst, i * sizeof(UInt32)), BinaryPrimitives.ReverseEndianness(Unsafe.Add(ref src, i)));
            }
        }
        else
        {
            Unsafe.CopyBlockUnaligned(ref dst, ref Unsafe.As<uint, byte>(ref src), (uint)(source.Length * sizeof(UInt32)));
        }
    }

    /// <summary>
    /// Writes <see cref="UInt64"/> words to a byte span in little-endian order.
    /// </summary>
    /// <param name="source">The source word span.</param>
    /// <param name="destination">The destination bytes (must be at least <paramref name="source"/>.Length × 8 bytes).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64LittleEndian(ReadOnlySpan<ulong> source, Span<byte> destination)
    {
        destination = destination.Slice(0, source.Length * sizeof(UInt64));
        ref ulong src = ref MemoryMarshal.GetReference(source);
        ref byte dst = ref MemoryMarshal.GetReference(destination);
        if (!BitConverter.IsLittleEndian)
        {
            for (nuint i = 0; i < (nuint)source.Length; i++)
            {
                Unsafe.WriteUnaligned(ref Unsafe.Add(ref dst, i * sizeof(UInt64)), BinaryPrimitives.ReverseEndianness(Unsafe.Add(ref src, i)));
            }
        }
        else
        {
            Unsafe.CopyBlockUnaligned(ref dst, ref Unsafe.As<ulong, byte>(ref src), (uint)(source.Length * sizeof(UInt64)));
        }
    }

    /// <summary>
    /// Writes a single <see cref="UInt32"/> to a byte pointer in little-endian order.
    /// </summary>
    /// <param name="destination">The destination bytes (must be at least 4 bytes).</param>
    /// <param name="value">The word to write.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt32LittleEndian(byte* destination, uint value)
    {
        Unsafe.WriteUnaligned(
            destination,
            BitConverter.IsLittleEndian ? value : BinaryPrimitives.ReverseEndianness(value));
    }

    /// <summary>
    /// Writes <see cref="UInt32"/> words to a byte span in little-endian order.
    /// </summary>
    /// <param name="source">The source word span.</param>
    /// <param name="destination">The destination bytes (must be at least <paramref name="count"/> × 4 bytes).</param>
    /// <param name="count">The number of words to write.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt32LittleEndian(uint* source, byte* destination, int count)
    {
        if (BitConverter.IsLittleEndian)
        {
            Unsafe.CopyBlockUnaligned(destination, source, (uint)(count * sizeof(uint)));
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                Unsafe.WriteUnaligned(destination + i * sizeof(uint), BinaryPrimitives.ReverseEndianness(source[i]));
            }
        }
    }

    /// <summary>
    /// Writes a single <see cref="UInt64"/> to a byte pointer in little-endian order.
    /// </summary>
    /// <param name="destination">The destination bytes (must be at least 8 bytes).</param>
    /// <param name="value">The word to write.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt64LittleEndian(byte* destination, ulong value)
    {
        Unsafe.WriteUnaligned(
            destination,
            BitConverter.IsLittleEndian ? value : BinaryPrimitives.ReverseEndianness(value));
    }

    /// <summary>
    /// Writes <see cref="UInt64"/> words to a byte span in little-endian order.
    /// </summary>
    /// <param name="source">The source word span.</param>
    /// <param name="destination">The destination bytes (must be at least <paramref name="source"/>.Length × 8 bytes).</param>
    /// <param name="count">The number of words to write.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt64LittleEndian(ulong* source, byte* destination, int count)
    {
        if (BitConverter.IsLittleEndian)
        {
            Unsafe.CopyBlockUnaligned(destination, source, (uint)(count * sizeof(ulong)));
        }
        else
        {
            for (int i = 0; i < count; i++)
            {
                Unsafe.WriteUnaligned(destination + i * sizeof(ulong), BinaryPrimitives.ReverseEndianness(source[i]));
            }
        }
    }
}
