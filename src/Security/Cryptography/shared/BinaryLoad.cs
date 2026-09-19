// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

using System;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Assembles a short final block as zero-padded words, in registers.
/// </summary>
/// <remarks>
/// <para>
/// Staging a partial block through a zeroed buffer makes the read back overlap both a wide
/// zeroing store and a narrower data store, so it cannot be satisfied by store-to-load
/// forwarding and stalls instead. These methods assemble the same value directly.
/// </para>
/// <para>
/// No method reads any byte at or past <c>source + length</c>, so a zero length
/// dereferences nothing and a null source is legal.
/// </para>
/// <para>
/// Every shape exists in both byte orders, and each is assembled in its own order rather
/// than derived from the other, so neither costs a byte swap on the machine that shares its
/// order. The two agree under <see cref="BinaryPrimitives.ReverseEndianness(ulong)"/>,
/// since zero-padding to the full width leaves the same byte sequence either way.
/// </para>
/// </remarks>
internal static partial class BinaryLoad
{
    // ================================================================
    // Little-endian assembly
    // ================================================================

    /// <summary>
    /// Reads a little-endian <see cref="UInt32"/> from the first <paramref name="length"/>
    /// bytes of <paramref name="source"/>, zero-padding the rest.
    /// </summary>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 4.</param>
    /// <returns>The zero-padded word.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static uint ReadUInt32LittleEndianPadded(ref byte source, int length)
    {
        Debug.Assert((uint)length <= sizeof(uint), "length is outside 0..4.");

        if (length >= sizeof(uint))
        {
            return TakeUInt32LittleEndian(ref source, 0, length);
        }

        uint value = 0;
        int at = 0;
        if ((length & 2) != 0)
        {
            value = TakeUInt16LittleEndian(ref source, at, length);
            at = sizeof(ushort);
        }

        if ((length & 1) != 0)
        {
            value |= (uint)TakeByte(ref source, at, length) << (at * 8);
        }

        return value;
    }

    /// <summary>
    /// Reads a little-endian <see cref="UInt64"/> from the first <paramref name="length"/>
    /// bytes of <paramref name="source"/>, zero-padding the rest.
    /// </summary>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 8.</param>
    /// <returns>The zero-padded word.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ulong ReadUInt64LittleEndianPadded(ref byte source, int length)
    {
        Debug.Assert((uint)length <= sizeof(ulong), "length is outside 0..8.");

        if (length >= sizeof(ulong))
        {
            return TakeUInt64LittleEndian(ref source, 0, length);
        }

        // Assembled from the set bits of length, not one byte at a time: three tests on
        // disjoint bits whatever the length.
        ulong value = 0;
        int at = 0;
        if ((length & 4) != 0)
        {
            value = TakeUInt32LittleEndian(ref source, at, length);
            at = sizeof(uint);
        }

        if ((length & 2) != 0)
        {
            value |= (ulong)TakeUInt16LittleEndian(ref source, at, length) << (at * 8);
            at += sizeof(ushort);
        }

        if ((length & 1) != 0)
        {
            value |= (ulong)TakeByte(ref source, at, length) << (at * 8);
        }

        return value;
    }

    /// <summary>
    /// Reads a 16-byte block as two little-endian <see cref="UInt64"/> words from the first
    /// <paramref name="length"/> bytes of <paramref name="source"/>, zero-padding the rest.
    /// </summary>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 16.</param>
    /// <param name="low">The first eight bytes.</param>
    /// <param name="high">The last eight bytes.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64PairLittleEndianPadded(ref byte source, int length, out ulong low, out ulong high)
    {
        Debug.Assert((uint)length <= 2 * sizeof(ulong), "length is outside 0..16.");

        if (length <= sizeof(ulong))
        {
            low = ReadUInt64LittleEndianPadded(ref source, length);
            high = 0;
        }
        else
        {
            low = TakeUInt64LittleEndian(ref source, 0, length);
            high = ReadUInt64LittleEndianPadded(ref Unsafe.Add(ref source, sizeof(ulong)), length - sizeof(ulong));
        }
    }

    /// <summary>
    /// Reads a 16-byte block as two little-endian <see cref="UInt64"/> words from the first
    /// <paramref name="length"/> bytes of <paramref name="source"/>, placing
    /// <paramref name="terminator"/> at index <paramref name="length"/> and zeros after it.
    /// </summary>
    /// <remarks>
    /// The <c>10*</c> padding shape: <c>0x01</c> for Poly1305, <c>0x80</c> for CMAC.
    /// </remarks>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 15.</param>
    /// <param name="terminator">The byte to place at index <paramref name="length"/>.</param>
    /// <param name="low">The first eight bytes.</param>
    /// <param name="high">The last eight bytes.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64PairLittleEndianPadded(ref byte source, int length, byte terminator, out ulong low, out ulong high)
    {
        Debug.Assert((uint)length < 2 * sizeof(ulong), "length is outside 0..15; the terminator needs a byte.");

        ReadUInt64PairLittleEndianPadded(ref source, length, out low, out high);

        // Byte index i of a little-endian word sits at i * 8.
        if (length < sizeof(ulong))
        {
            low |= (ulong)terminator << (length * 8);
        }
        else
        {
            high |= (ulong)terminator << ((length - sizeof(ulong)) * 8);
        }
    }

    // ================================================================
    // Big-endian assembly
    // ================================================================

    /// <summary>
    /// Reads a big-endian <see cref="UInt32"/> from the first <paramref name="length"/>
    /// bytes of <paramref name="source"/>, zero-padding the rest.
    /// </summary>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 4.</param>
    /// <returns>The zero-padded word.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static uint ReadUInt32BigEndianPadded(ref byte source, int length)
    {
        Debug.Assert((uint)length <= sizeof(uint), "length is outside 0..4.");

        if (length >= sizeof(uint))
        {
            return TakeUInt32BigEndian(ref source, 0, length);
        }

        uint value = 0;
        int at = 0;
        if ((length & 2) != 0)
        {
            value = (uint)TakeUInt16BigEndian(ref source, at, length) << ((sizeof(uint) - at - sizeof(ushort)) * 8);
            at = sizeof(ushort);
        }

        if ((length & 1) != 0)
        {
            value |= (uint)TakeByte(ref source, at, length) << ((sizeof(uint) - at - sizeof(byte)) * 8);
        }

        return value;
    }

    /// <summary>
    /// Reads a big-endian <see cref="UInt64"/> from the first <paramref name="length"/>
    /// bytes of <paramref name="source"/>, zero-padding the rest.
    /// </summary>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 8.</param>
    /// <returns>The zero-padded word.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ulong ReadUInt64BigEndianPadded(ref byte source, int length)
    {
        Debug.Assert((uint)length <= sizeof(ulong), "length is outside 0..8.");

        if (length >= sizeof(ulong))
        {
            return TakeUInt64BigEndian(ref source, 0, length);
        }

        // Same decomposition as the little-endian assembler, but a piece taken at 'at'
        // lands at the far end of the word instead of at 'at'.
        ulong value = 0;
        int at = 0;
        if ((length & 4) != 0)
        {
            value = (ulong)TakeUInt32BigEndian(ref source, at, length) << ((sizeof(ulong) - at - sizeof(uint)) * 8);
            at = sizeof(uint);
        }

        if ((length & 2) != 0)
        {
            value |= (ulong)TakeUInt16BigEndian(ref source, at, length) << ((sizeof(ulong) - at - sizeof(ushort)) * 8);
            at += sizeof(ushort);
        }

        if ((length & 1) != 0)
        {
            value |= (ulong)TakeByte(ref source, at, length) << ((sizeof(ulong) - at - sizeof(byte)) * 8);
        }

        return value;
    }

    /// <summary>
    /// Reads a 16-byte block as two big-endian <see cref="UInt64"/> words from the first
    /// <paramref name="length"/> bytes of <paramref name="source"/>, zero-padding the rest.
    /// </summary>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 16.</param>
    /// <param name="first">The first eight bytes.</param>
    /// <param name="second">The last eight bytes.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64PairBigEndianPadded(ref byte source, int length, out ulong first, out ulong second)
    {
        Debug.Assert((uint)length <= 2 * sizeof(ulong), "length is outside 0..16.");

        if (length <= sizeof(ulong))
        {
            first = ReadUInt64BigEndianPadded(ref source, length);
            second = 0;
        }
        else
        {
            first = TakeUInt64BigEndian(ref source, 0, length);
            second = ReadUInt64BigEndianPadded(ref Unsafe.Add(ref source, sizeof(ulong)), length - sizeof(ulong));
        }
    }

    /// <summary>
    /// Reads a 16-byte block as two big-endian <see cref="UInt64"/> words from the first
    /// <paramref name="length"/> bytes of <paramref name="source"/>, placing
    /// <paramref name="terminator"/> at index <paramref name="length"/> and zeros after it.
    /// </summary>
    /// <inheritdoc cref="ReadUInt64PairLittleEndianPadded(ref byte, int, byte, out ulong, out ulong)" path="/remarks"/>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 15.</param>
    /// <param name="terminator">The byte to place at index <paramref name="length"/>.</param>
    /// <param name="first">The first eight bytes.</param>
    /// <param name="second">The last eight bytes.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64PairBigEndianPadded(ref byte source, int length, byte terminator, out ulong first, out ulong second)
    {
        Debug.Assert((uint)length < 2 * sizeof(ulong), "length is outside 0..15; the terminator needs a byte.");

        ReadUInt64PairBigEndianPadded(ref source, length, out first, out second);

        // Byte index i of a big-endian word sits at (7 - i) * 8.
        if (length < sizeof(ulong))
        {
            first |= (ulong)terminator << ((sizeof(ulong) - 1 - length) * 8);
        }
        else
        {
            second |= (ulong)terminator << (((2 * sizeof(ulong)) - 1 - length) * 8);
        }
    }

    // ================================================================
    // Bulk word fill
    // ================================================================

    /// <summary>
    /// Fills <paramref name="destination"/> with <paramref name="words"/> little-endian
    /// <see cref="UInt32"/> words taken from the first <paramref name="length"/> bytes of
    /// <paramref name="source"/>, zero-padding the rest.
    /// </summary>
    /// <remarks>
    /// The padded counterpart of <see cref="BinarySpans"/>'s bulk little-endian reader, for
    /// kernels whose message block is a word array rather than a byte block. There is
    /// deliberately no big-endian twin: this is built on the little-endian bulk reader
    /// <see cref="BinarySpans"/> already has, and a big-endian form would have to hand-roll
    /// the whole-word loop for a caller that does not exist.
    /// </remarks>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes.</param>
    /// <param name="destination">Receives <paramref name="words"/> words.</param>
    /// <param name="words">The number of words to write.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void ReadUInt32LittleEndianPadded(byte* source, int length, uint* destination, int words)
    {
        Debug.Assert(length >= 0, "length is negative.");
        Debug.Assert(words >= 0, "words is negative.");

        int full = Math.Min(length / sizeof(uint), words);
        BinarySpans.ReadUInt32LittleEndian(source, destination, full);

        // At most one of these straddles the end; the rest are pure padding.
        for (int i = full; i < words; i++)
        {
            int at = i * sizeof(uint);
            destination[i] = at < length ? ReadUInt32LittleEndianPadded(source + at, length - at) : 0u;
        }
    }

    /// <inheritdoc cref="ReadUInt32LittleEndianPadded(byte*, int, uint*, int)"/>
    /// <param name="source">The readable bytes. Its length is the padded length.</param>
    /// <param name="destination">Receives one word per element.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt32LittleEndianPadded(ReadOnlySpan<byte> source, Span<uint> destination)
    {
        int full = Math.Min(source.Length / sizeof(uint), destination.Length);
        BinarySpans.ReadUInt32LittleEndian(source.Slice(0, full * sizeof(uint)), destination);

        // At most one of these straddles the end; the rest are pure padding.
        for (int i = full; i < destination.Length; i++)
        {
            int at = i * sizeof(uint);
            destination[i] = at < source.Length ? ReadUInt32LittleEndianPadded(source.Slice(at)) : 0u;
        }
    }

    // ================================================================
    // Span forwarders — the span's length is the padded length
    // ================================================================

    /// <inheritdoc cref="ReadUInt32LittleEndianPadded(ref byte, int)"/>
    /// <param name="source">The readable bytes, at most four. Its length is the padded length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static uint ReadUInt32LittleEndianPadded(ReadOnlySpan<byte> source) =>
        ReadUInt32LittleEndianPadded(ref MemoryMarshal.GetReference(source), source.Length);

    /// <inheritdoc cref="ReadUInt64LittleEndianPadded(ref byte, int)"/>
    /// <param name="source">The readable bytes, at most eight. Its length is the padded length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ulong ReadUInt64LittleEndianPadded(ReadOnlySpan<byte> source) =>
        ReadUInt64LittleEndianPadded(ref MemoryMarshal.GetReference(source), source.Length);

    /// <inheritdoc cref="ReadUInt64PairLittleEndianPadded(ref byte, int, out ulong, out ulong)"/>
    /// <param name="source">The readable bytes, at most 16. Its length is the padded length.</param>
    /// <param name="low">The first eight bytes.</param>
    /// <param name="high">The last eight bytes.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64PairLittleEndianPadded(ReadOnlySpan<byte> source, out ulong low, out ulong high) =>
        ReadUInt64PairLittleEndianPadded(ref MemoryMarshal.GetReference(source), source.Length, out low, out high);

    /// <inheritdoc cref="ReadUInt64PairLittleEndianPadded(ref byte, int, byte, out ulong, out ulong)"/>
    /// <param name="source">The readable bytes, at most 15. Its length is the padded length.</param>
    /// <param name="terminator">The byte to place just past <paramref name="source"/>.</param>
    /// <param name="low">The first eight bytes.</param>
    /// <param name="high">The last eight bytes.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64PairLittleEndianPadded(ReadOnlySpan<byte> source, byte terminator, out ulong low, out ulong high) =>
        ReadUInt64PairLittleEndianPadded(ref MemoryMarshal.GetReference(source), source.Length, terminator, out low, out high);

    /// <inheritdoc cref="ReadUInt32BigEndianPadded(ref byte, int)"/>
    /// <param name="source">The readable bytes, at most four. Its length is the padded length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static uint ReadUInt32BigEndianPadded(ReadOnlySpan<byte> source) =>
        ReadUInt32BigEndianPadded(ref MemoryMarshal.GetReference(source), source.Length);

    /// <inheritdoc cref="ReadUInt64BigEndianPadded(ref byte, int)"/>
    /// <param name="source">The readable bytes, at most eight. Its length is the padded length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static ulong ReadUInt64BigEndianPadded(ReadOnlySpan<byte> source) =>
        ReadUInt64BigEndianPadded(ref MemoryMarshal.GetReference(source), source.Length);

    /// <inheritdoc cref="ReadUInt64PairBigEndianPadded(ref byte, int, out ulong, out ulong)"/>
    /// <param name="source">The readable bytes, at most 16. Its length is the padded length.</param>
    /// <param name="first">The first eight bytes.</param>
    /// <param name="second">The last eight bytes.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64PairBigEndianPadded(ReadOnlySpan<byte> source, out ulong first, out ulong second) =>
        ReadUInt64PairBigEndianPadded(ref MemoryMarshal.GetReference(source), source.Length, out first, out second);

    /// <inheritdoc cref="ReadUInt64PairBigEndianPadded(ref byte, int, byte, out ulong, out ulong)"/>
    /// <param name="source">The readable bytes, at most 15. Its length is the padded length.</param>
    /// <param name="terminator">The byte to place just past <paramref name="source"/>.</param>
    /// <param name="first">The first eight bytes.</param>
    /// <param name="second">The last eight bytes.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void ReadUInt64PairBigEndianPadded(ReadOnlySpan<byte> source, byte terminator, out ulong first, out ulong second) =>
        ReadUInt64PairBigEndianPadded(ref MemoryMarshal.GetReference(source), source.Length, terminator, out first, out second);

    // ================================================================
    // Pointer forwarders — a null source is legal at length 0
    // ================================================================

    /// <inheritdoc cref="ReadUInt32LittleEndianPadded(ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe uint ReadUInt32LittleEndianPadded(byte* source, int length) =>
        ReadUInt32LittleEndianPadded(ref Unsafe.AsRef<byte>(source), length);

    /// <inheritdoc cref="ReadUInt64LittleEndianPadded(ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe ulong ReadUInt64LittleEndianPadded(byte* source, int length) =>
        ReadUInt64LittleEndianPadded(ref Unsafe.AsRef<byte>(source), length);

    /// <inheritdoc cref="ReadUInt64PairLittleEndianPadded(ref byte, int, out ulong, out ulong)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void ReadUInt64PairLittleEndianPadded(byte* source, int length, out ulong low, out ulong high) =>
        ReadUInt64PairLittleEndianPadded(ref Unsafe.AsRef<byte>(source), length, out low, out high);

    /// <inheritdoc cref="ReadUInt64PairLittleEndianPadded(ref byte, int, byte, out ulong, out ulong)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void ReadUInt64PairLittleEndianPadded(byte* source, int length, byte terminator, out ulong low, out ulong high) =>
        ReadUInt64PairLittleEndianPadded(ref Unsafe.AsRef<byte>(source), length, terminator, out low, out high);

    /// <inheritdoc cref="ReadUInt32BigEndianPadded(ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe uint ReadUInt32BigEndianPadded(byte* source, int length) =>
        ReadUInt32BigEndianPadded(ref Unsafe.AsRef<byte>(source), length);

    /// <inheritdoc cref="ReadUInt64BigEndianPadded(ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe ulong ReadUInt64BigEndianPadded(byte* source, int length) =>
        ReadUInt64BigEndianPadded(ref Unsafe.AsRef<byte>(source), length);

    /// <inheritdoc cref="ReadUInt64PairBigEndianPadded(ref byte, int, out ulong, out ulong)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void ReadUInt64PairBigEndianPadded(byte* source, int length, out ulong first, out ulong second) =>
        ReadUInt64PairBigEndianPadded(ref Unsafe.AsRef<byte>(source), length, out first, out second);

    /// <inheritdoc cref="ReadUInt64PairBigEndianPadded(ref byte, int, byte, out ulong, out ulong)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void ReadUInt64PairBigEndianPadded(byte* source, int length, byte terminator, out ulong first, out ulong second) =>
        ReadUInt64PairBigEndianPadded(ref Unsafe.AsRef<byte>(source), length, terminator, out first, out second);

    // ================================================================
    // Piece readers — every read this class performs goes through one of
    // these seven, so the no-over-read contract is checked in one place.
    // 'readable' is the contract length and exists only for that assert.
    // ================================================================

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static byte TakeByte(ref byte source, int offset, int readable)
    {
        Debug.Assert(offset + sizeof(byte) <= readable, "read extends past the readable length.");
        return Unsafe.Add(ref source, offset);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static ushort TakeUInt16LittleEndian(ref byte source, int offset, int readable)
    {
        Debug.Assert(offset + sizeof(ushort) <= readable, "read extends past the readable length.");
        ushort value = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref source, offset));
        return BitConverter.IsLittleEndian ? value : BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static uint TakeUInt32LittleEndian(ref byte source, int offset, int readable)
    {
        Debug.Assert(offset + sizeof(uint) <= readable, "read extends past the readable length.");
        uint value = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref source, offset));
        return BitConverter.IsLittleEndian ? value : BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static ulong TakeUInt64LittleEndian(ref byte source, int offset, int readable)
    {
        Debug.Assert(offset + sizeof(ulong) <= readable, "read extends past the readable length.");
        ulong value = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref source, offset));
        return BitConverter.IsLittleEndian ? value : BinaryPrimitives.ReverseEndianness(value);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static ushort TakeUInt16BigEndian(ref byte source, int offset, int readable)
    {
        Debug.Assert(offset + sizeof(ushort) <= readable, "read extends past the readable length.");
        ushort value = Unsafe.ReadUnaligned<ushort>(ref Unsafe.Add(ref source, offset));
        return BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(value) : value;
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static uint TakeUInt32BigEndian(ref byte source, int offset, int readable)
    {
        Debug.Assert(offset + sizeof(uint) <= readable, "read extends past the readable length.");
        uint value = Unsafe.ReadUnaligned<uint>(ref Unsafe.Add(ref source, offset));
        return BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(value) : value;
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static ulong TakeUInt64BigEndian(ref byte source, int offset, int readable)
    {
        Debug.Assert(offset + sizeof(ulong) <= readable, "read extends past the readable length.");
        ulong value = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref source, offset));
        return BitConverter.IsLittleEndian ? BinaryPrimitives.ReverseEndianness(value) : value;
    }
}
