// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography;

using System;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Writes a word's encoding to memory: in full, or only its leading bytes for a short final
/// block, the counterpart of <see cref="BinaryLoad"/>.
/// </summary>
/// <remarks>
/// No truncated write touches any byte at or past <c>destination + length</c>, so a zero length
/// dereferences nothing and a null destination is legal.
/// </remarks>
internal static class BinaryStore
{
    // ================================================================
    // Little-endian
    // ================================================================

    /// <summary>
    /// Writes the first <paramref name="length"/> bytes of the little-endian encoding of
    /// <paramref name="value"/> to <paramref name="destination"/>.
    /// </summary>
    /// <param name="value">The word to write.</param>
    /// <param name="destination">The destination bytes. Only the first <paramref name="length"/> are written.</param>
    /// <param name="length">The number of writable bytes, 0 to 4.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt32LittleEndianTruncated(uint value, ref byte destination, int length)
    {
        Debug.Assert((uint)length <= sizeof(uint), "length is outside 0..4.");

        if (length >= sizeof(uint))
        {
            PutUInt32LittleEndian(ref destination, 0, length, value);
            return;
        }

        int at = 0;
        if ((length & 2) != 0)
        {
            PutUInt16LittleEndian(ref destination, at, length, (ushort)value);
            at = sizeof(ushort);
        }

        if ((length & 1) != 0)
        {
            PutByte(ref destination, at, length, (byte)(value >> (at * 8)));
        }
    }

    /// <summary>
    /// Writes the first <paramref name="length"/> bytes of the little-endian encoding of
    /// <paramref name="value"/> to <paramref name="destination"/>.
    /// </summary>
    /// <param name="value">The word to write.</param>
    /// <param name="destination">The destination bytes. Only the first <paramref name="length"/> are written.</param>
    /// <param name="length">The number of writable bytes, 0 to 8.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64LittleEndianTruncated(ulong value, ref byte destination, int length)
    {
        Debug.Assert((uint)length <= sizeof(ulong), "length is outside 0..8.");

        if (length >= sizeof(ulong))
        {
            PutUInt64LittleEndian(ref destination, 0, length, value);
            return;
        }

        int at = 0;
        if ((length & 4) != 0)
        {
            PutUInt32LittleEndian(ref destination, at, length, (uint)value);
            at = sizeof(uint);
        }

        if ((length & 2) != 0)
        {
            PutUInt16LittleEndian(ref destination, at, length, (ushort)(value >> (at * 8)));
            at += sizeof(ushort);
        }

        if ((length & 1) != 0)
        {
            PutByte(ref destination, at, length, (byte)(value >> (at * 8)));
        }
    }

    /// <summary>
    /// Writes the first <paramref name="length"/> bytes of the 16-byte block formed by two
    /// little-endian <see cref="UInt64"/> words to <paramref name="destination"/>.
    /// </summary>
    /// <param name="low">The first eight bytes.</param>
    /// <param name="high">The last eight bytes.</param>
    /// <param name="destination">The destination bytes. Only the first <paramref name="length"/> are written.</param>
    /// <param name="length">The number of writable bytes, 0 to 16.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64PairLittleEndianTruncated(ulong low, ulong high, ref byte destination, int length)
    {
        Debug.Assert((uint)length <= 2 * sizeof(ulong), "length is outside 0..16.");

        if (length <= sizeof(ulong))
        {
            WriteUInt64LittleEndianTruncated(low, ref destination, length);
        }
        else
        {
            PutUInt64LittleEndian(ref destination, 0, length, low);
            WriteUInt64LittleEndianTruncated(high, ref Unsafe.Add(ref destination, sizeof(ulong)), length - sizeof(ulong));
        }
    }

    // ================================================================
    // Big-endian
    // ================================================================

    /// <summary>
    /// Writes the first <paramref name="length"/> bytes of the big-endian encoding of
    /// <paramref name="value"/>, its most significant bytes, to <paramref name="destination"/>.
    /// </summary>
    /// <param name="value">The word to write.</param>
    /// <param name="destination">The destination bytes. Only the first <paramref name="length"/> are written.</param>
    /// <param name="length">The number of writable bytes, 0 to 4.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt32BigEndianTruncated(uint value, ref byte destination, int length)
    {
        Debug.Assert((uint)length <= sizeof(uint), "length is outside 0..4.");

        if (length >= sizeof(uint))
        {
            PutUInt32BigEndian(ref destination, 0, length, value);
            return;
        }

        int at = 0;
        if ((length & 2) != 0)
        {
            PutUInt16BigEndian(ref destination, at, length, (ushort)(value >> ((sizeof(uint) - at - sizeof(ushort)) * 8)));
            at = sizeof(ushort);
        }

        if ((length & 1) != 0)
        {
            PutByte(ref destination, at, length, (byte)(value >> ((sizeof(uint) - at - sizeof(byte)) * 8)));
        }
    }

    /// <summary>
    /// Writes the first <paramref name="length"/> bytes of the big-endian encoding of
    /// <paramref name="value"/>, its most significant bytes, to <paramref name="destination"/>.
    /// </summary>
    /// <param name="value">The word to write.</param>
    /// <param name="destination">The destination bytes. Only the first <paramref name="length"/> are written.</param>
    /// <param name="length">The number of writable bytes, 0 to 8.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64BigEndianTruncated(ulong value, ref byte destination, int length)
    {
        Debug.Assert((uint)length <= sizeof(ulong), "length is outside 0..8.");

        if (length >= sizeof(ulong))
        {
            PutUInt64BigEndian(ref destination, 0, length, value);
            return;
        }

        // A piece written at 'at' comes from the far end of the word instead of from 'at'.
        int at = 0;
        if ((length & 4) != 0)
        {
            PutUInt32BigEndian(ref destination, at, length, (uint)(value >> ((sizeof(ulong) - at - sizeof(uint)) * 8)));
            at = sizeof(uint);
        }

        if ((length & 2) != 0)
        {
            PutUInt16BigEndian(ref destination, at, length, (ushort)(value >> ((sizeof(ulong) - at - sizeof(ushort)) * 8)));
            at += sizeof(ushort);
        }

        if ((length & 1) != 0)
        {
            PutByte(ref destination, at, length, (byte)(value >> ((sizeof(ulong) - at - sizeof(byte)) * 8)));
        }
    }

    /// <summary>
    /// Writes the first <paramref name="length"/> bytes of the 16-byte block formed by two
    /// big-endian <see cref="UInt64"/> words to <paramref name="destination"/>.
    /// </summary>
    /// <param name="first">The first eight bytes.</param>
    /// <param name="second">The last eight bytes.</param>
    /// <param name="destination">The destination bytes. Only the first <paramref name="length"/> are written.</param>
    /// <param name="length">The number of writable bytes, 0 to 16.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64PairBigEndianTruncated(ulong first, ulong second, ref byte destination, int length)
    {
        Debug.Assert((uint)length <= 2 * sizeof(ulong), "length is outside 0..16.");

        if (length <= sizeof(ulong))
        {
            WriteUInt64BigEndianTruncated(first, ref destination, length);
        }
        else
        {
            PutUInt64BigEndian(ref destination, 0, length, first);
            WriteUInt64BigEndianTruncated(second, ref Unsafe.Add(ref destination, sizeof(ulong)), length - sizeof(ulong));
        }
    }

    // ================================================================
    // Span forwarders — the span's length is the truncated length
    // ================================================================

    /// <inheritdoc cref="WriteUInt32LittleEndianTruncated(uint, ref byte, int)"/>
    /// <param name="value">The word to write.</param>
    /// <param name="destination">The writable bytes, at most four. Its length is the truncated length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt32LittleEndianTruncated(uint value, Span<byte> destination) =>
        WriteUInt32LittleEndianTruncated(value, ref MemoryMarshal.GetReference(destination), destination.Length);

    /// <inheritdoc cref="WriteUInt64LittleEndianTruncated(ulong, ref byte, int)"/>
    /// <param name="value">The word to write.</param>
    /// <param name="destination">The writable bytes, at most eight. Its length is the truncated length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64LittleEndianTruncated(ulong value, Span<byte> destination) =>
        WriteUInt64LittleEndianTruncated(value, ref MemoryMarshal.GetReference(destination), destination.Length);

    /// <inheritdoc cref="WriteUInt64PairLittleEndianTruncated(ulong, ulong, ref byte, int)"/>
    /// <param name="low">The first eight bytes.</param>
    /// <param name="high">The last eight bytes.</param>
    /// <param name="destination">The writable bytes, at most 16. Its length is the truncated length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64PairLittleEndianTruncated(ulong low, ulong high, Span<byte> destination) =>
        WriteUInt64PairLittleEndianTruncated(low, high, ref MemoryMarshal.GetReference(destination), destination.Length);

    /// <inheritdoc cref="WriteUInt32BigEndianTruncated(uint, ref byte, int)"/>
    /// <param name="value">The word to write.</param>
    /// <param name="destination">The writable bytes, at most four. Its length is the truncated length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt32BigEndianTruncated(uint value, Span<byte> destination) =>
        WriteUInt32BigEndianTruncated(value, ref MemoryMarshal.GetReference(destination), destination.Length);

    /// <inheritdoc cref="WriteUInt64BigEndianTruncated(ulong, ref byte, int)"/>
    /// <param name="value">The word to write.</param>
    /// <param name="destination">The writable bytes, at most eight. Its length is the truncated length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64BigEndianTruncated(ulong value, Span<byte> destination) =>
        WriteUInt64BigEndianTruncated(value, ref MemoryMarshal.GetReference(destination), destination.Length);

    /// <inheritdoc cref="WriteUInt64PairBigEndianTruncated(ulong, ulong, ref byte, int)"/>
    /// <param name="first">The first eight bytes.</param>
    /// <param name="second">The last eight bytes.</param>
    /// <param name="destination">The writable bytes, at most 16. Its length is the truncated length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void WriteUInt64PairBigEndianTruncated(ulong first, ulong second, Span<byte> destination) =>
        WriteUInt64PairBigEndianTruncated(first, second, ref MemoryMarshal.GetReference(destination), destination.Length);

    // ================================================================
    // Pointer forwarders — a null destination is legal at length 0
    // ================================================================

    /// <inheritdoc cref="WriteUInt32LittleEndianTruncated(uint, ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt32LittleEndianTruncated(uint value, byte* destination, int length) =>
        WriteUInt32LittleEndianTruncated(value, ref Unsafe.AsRef<byte>(destination), length);

    /// <inheritdoc cref="WriteUInt64LittleEndianTruncated(ulong, ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt64LittleEndianTruncated(ulong value, byte* destination, int length) =>
        WriteUInt64LittleEndianTruncated(value, ref Unsafe.AsRef<byte>(destination), length);

    /// <inheritdoc cref="WriteUInt64PairLittleEndianTruncated(ulong, ulong, ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt64PairLittleEndianTruncated(ulong low, ulong high, byte* destination, int length) =>
        WriteUInt64PairLittleEndianTruncated(low, high, ref Unsafe.AsRef<byte>(destination), length);

    /// <inheritdoc cref="WriteUInt32BigEndianTruncated(uint, ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt32BigEndianTruncated(uint value, byte* destination, int length) =>
        WriteUInt32BigEndianTruncated(value, ref Unsafe.AsRef<byte>(destination), length);

    /// <inheritdoc cref="WriteUInt64BigEndianTruncated(ulong, ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt64BigEndianTruncated(ulong value, byte* destination, int length) =>
        WriteUInt64BigEndianTruncated(value, ref Unsafe.AsRef<byte>(destination), length);

    /// <inheritdoc cref="WriteUInt64PairBigEndianTruncated(ulong, ulong, ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void WriteUInt64PairBigEndianTruncated(ulong first, ulong second, byte* destination, int length) =>
        WriteUInt64PairBigEndianTruncated(first, second, ref Unsafe.AsRef<byte>(destination), length);

    // ================================================================
    // Full-width pointer writes
    // ================================================================

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

    // ================================================================
    // Piece writers — every write this class performs goes through one of
    // these seven, so the no-over-write contract is checked in one place.
    // 'writable' is the contract length and exists only for that assert.
    // ================================================================

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PutByte(ref byte destination, int offset, int writable, byte value)
    {
        Debug.Assert(offset + sizeof(byte) <= writable, "write extends past the writable length.");
        Unsafe.Add(ref destination, offset) = value;
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PutUInt16LittleEndian(ref byte destination, int offset, int writable, ushort value)
    {
        Debug.Assert(offset + sizeof(ushort) <= writable, "write extends past the writable length.");
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref destination, offset), BitConverter.IsLittleEndian ? value : BinaryPrimitives.ReverseEndianness(value));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PutUInt32LittleEndian(ref byte destination, int offset, int writable, uint value)
    {
        Debug.Assert(offset + sizeof(uint) <= writable, "write extends past the writable length.");
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref destination, offset), BitConverter.IsLittleEndian ? value : BinaryPrimitives.ReverseEndianness(value));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PutUInt64LittleEndian(ref byte destination, int offset, int writable, ulong value)
    {
        Debug.Assert(offset + sizeof(ulong) <= writable, "write extends past the writable length.");
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref destination, offset), BitConverter.IsLittleEndian ? value : BinaryPrimitives.ReverseEndianness(value));
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PutUInt16BigEndian(ref byte destination, int offset, int writable, ushort value)
    {
        Debug.Assert(offset + sizeof(ushort) <= writable, "write extends past the writable length.");
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref destination, offset), BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(value) : value);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PutUInt32BigEndian(ref byte destination, int offset, int writable, uint value)
    {
        Debug.Assert(offset + sizeof(uint) <= writable, "write extends past the writable length.");
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref destination, offset), BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(value) : value);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void PutUInt64BigEndian(ref byte destination, int offset, int writable, ulong value)
    {
        Debug.Assert(offset + sizeof(ulong) <= writable, "write extends past the writable length.");
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref destination, offset), BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(value) : value);
    }
}
