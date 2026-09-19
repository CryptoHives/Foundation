// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography;

#if NET8_0_OR_GREATER

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

internal static partial class BinaryLoad
{
    /// <summary>
    /// Byte indices for realigning a right-aligned tail down to lane 0.
    /// </summary>
    /// <remarks>
    /// Read 16 bytes at offset <c>16 - rem</c>: the in-range lanes carry their source index
    /// and the rest carry <c>0x80</c>, which both <c>pshufb</c> and <c>tbl</c> turn into zero.
    /// </remarks>
    private static ReadOnlySpan<byte> RealignIndices =>
    [
        0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
        0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
        0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80,
        0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80,
    ];

    /// <summary>
    /// Gets a value indicating whether <see cref="LoadTailPadded128(ReadOnlySpan{byte}, int)"/>
    /// has a native byte-shuffle to realign with.
    /// </summary>
    private static bool IsRealignSupported =>
        (Ssse3.IsSupported || AdvSimd.Arm64.IsSupported) && BitConverter.IsLittleEndian;

    /// <summary>
    /// Loads the first <paramref name="length"/> bytes of <paramref name="source"/> into a
    /// vector, zero-padding the rest.
    /// </summary>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 16.</param>
    /// <returns>The zero-padded block.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static Vector128<byte> LoadPadded128(ref byte source, int length)
    {
        Debug.Assert(BitConverter.IsLittleEndian, "The composed halves are laid out native-endian.");
        Debug.Assert((uint)length <= Vector128<byte>.Count, "length is outside 0..16.");

        if (length >= Vector128<byte>.Count)
        {
            return Vector128.LoadUnsafe(ref source);
        }

        if (length <= 0)
        {
            return Vector128<byte>.Zero;
        }

        ReadUInt64PairLittleEndianPadded(ref source, length, out ulong low, out ulong high);
        return Vector128.Create(low, high).AsByte();
    }

    /// <summary>
    /// Loads the tail of <paramref name="data"/> starting at <paramref name="offset"/> into a
    /// vector, zero-padding the rest.
    /// </summary>
    /// <remarks>
    /// Where the buffer holds at least a whole vector, the tail is realigned out of an
    /// overlapping load of its last 16 bytes rather than composed word by word. That load
    /// is entirely inside <paramref name="data"/>, so the no-over-read contract still holds.
    /// </remarks>
    /// <param name="data">The buffer whose tail is loaded.</param>
    /// <param name="offset">Where the tail starts. Bytes before it are not read.</param>
    /// <returns>The zero-padded block.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static Vector128<byte> LoadTailPadded128(ReadOnlySpan<byte> data, int offset)
    {
        Debug.Assert((uint)offset <= (uint)data.Length, "offset is outside the buffer.");

        int remaining = data.Length - offset;
        ref byte first = ref MemoryMarshal.GetReference(data);

        if (remaining <= 0)
        {
            return Vector128<byte>.Zero;
        }

        if (remaining >= Vector128<byte>.Count)
        {
            return Vector128.LoadUnsafe(ref first, (nuint)offset);
        }

        if (data.Length < Vector128<byte>.Count || !IsRealignSupported)
        {
            return LoadPadded128(ref Unsafe.Add(ref first, offset), remaining);
        }

        Debug.Assert(data.Length - Vector128<byte>.Count >= 0, "the overlapping load starts before the buffer.");
        var block = Vector128.LoadUnsafe(ref first, (nuint)(data.Length - Vector128<byte>.Count));
        var indices = Vector128.LoadUnsafe(
            ref MemoryMarshal.GetReference(RealignIndices),
            (nuint)(Vector128<byte>.Count - remaining));

        return Ssse3.IsSupported
            ? Ssse3.Shuffle(block, indices)
            : AdvSimd.Arm64.VectorTableLookup(block, indices);
    }

    /// <summary>
    /// Loads the first <paramref name="length"/> bytes of <paramref name="source"/> as a
    /// 64-byte block of four vectors, zero-padding the rest.
    /// </summary>
    /// <param name="source">The source bytes. Only the first <paramref name="length"/> are read.</param>
    /// <param name="length">The number of readable bytes, 0 to 64.</param>
    /// <param name="m0">Bytes 0 to 15.</param>
    /// <param name="m1">Bytes 16 to 31.</param>
    /// <param name="m2">Bytes 32 to 47.</param>
    /// <param name="m3">Bytes 48 to 63.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void LoadPaddedBlock128x4(
        ref byte source,
        int length,
        out Vector128<uint> m0,
        out Vector128<uint> m1,
        out Vector128<uint> m2,
        out Vector128<uint> m3)
    {
        Debug.Assert((uint)length <= 4 * Vector128<byte>.Count, "length is outside 0..64.");

        m0 = LoadPaddedLane(ref source, length, 0);
        m1 = LoadPaddedLane(ref source, length, Vector128<byte>.Count);
        m2 = LoadPaddedLane(ref source, length, 2 * Vector128<byte>.Count);
        m3 = LoadPaddedLane(ref source, length, 3 * Vector128<byte>.Count);
    }

    /// <summary>
    /// Loads the 64-byte block of <paramref name="data"/> starting at
    /// <paramref name="offset"/> as four vectors, zero-padding whatever runs past the end.
    /// </summary>
    /// <remarks>
    /// Differs from <see cref="LoadPaddedBlock128x4(ref byte, int, out Vector128{uint}, out Vector128{uint}, out Vector128{uint}, out Vector128{uint})"/>
    /// in seeing the whole buffer rather than just the block, which is what lets the
    /// straddling lane realign an overlapping load instead of composing word by word.
    /// </remarks>
    /// <param name="data">The buffer the block is taken from.</param>
    /// <param name="dataLength">The length of <paramref name="data"/>.</param>
    /// <param name="offset">Where the block starts. Bytes before it are not read.</param>
    /// <param name="m0">Bytes 0 to 15 of the block.</param>
    /// <param name="m1">Bytes 16 to 31 of the block.</param>
    /// <param name="m2">Bytes 32 to 47 of the block.</param>
    /// <param name="m3">Bytes 48 to 63 of the block.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void LoadPaddedTailBlock128x4(
        byte* data,
        int dataLength,
        int offset,
        out Vector128<uint> m0,
        out Vector128<uint> m1,
        out Vector128<uint> m2,
        out Vector128<uint> m3)
    {
        Debug.Assert((uint)offset <= (uint)dataLength, "offset is outside the buffer.");
        Debug.Assert(dataLength - offset <= 4 * Vector128<byte>.Count, "the block runs past 64 bytes.");

        m0 = LoadPaddedTailLane(data, dataLength, offset);
        m1 = LoadPaddedTailLane(data, dataLength, offset + Vector128<byte>.Count);
        m2 = LoadPaddedTailLane(data, dataLength, offset + (2 * Vector128<byte>.Count));
        m3 = LoadPaddedTailLane(data, dataLength, offset + (3 * Vector128<byte>.Count));
    }

    /// <inheritdoc cref="LoadPadded128(ref byte, int)"/>
    /// <param name="source">The readable bytes, at most 16. Its length is the padded length.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static Vector128<byte> LoadPadded128(ReadOnlySpan<byte> source) =>
        LoadPadded128(ref MemoryMarshal.GetReference(source), source.Length);

    /// <inheritdoc cref="LoadPadded128(ref byte, int)"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe Vector128<byte> LoadPadded128(byte* source, int length) =>
        LoadPadded128(ref Unsafe.AsRef<byte>(source), length);

    /// <inheritdoc cref="LoadTailPadded128(ReadOnlySpan{byte}, int)"/>
    /// <param name="data">The buffer whose tail is loaded.</param>
    /// <param name="dataLength">The length of <paramref name="data"/>.</param>
    /// <param name="offset">Where the tail starts. Bytes before it are not read.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe Vector128<byte> LoadTailPadded128(byte* data, int dataLength, int offset) =>
        LoadTailPadded128(new ReadOnlySpan<byte>(data, dataLength), offset);

    /// <inheritdoc cref="LoadPaddedBlock128x4(ref byte, int, out Vector128{uint}, out Vector128{uint}, out Vector128{uint}, out Vector128{uint})"/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static unsafe void LoadPaddedBlock128x4(
        byte* source,
        int length,
        out Vector128<uint> m0,
        out Vector128<uint> m1,
        out Vector128<uint> m2,
        out Vector128<uint> m3) =>
        LoadPaddedBlock128x4(ref Unsafe.AsRef<byte>(source), length, out m0, out m1, out m2, out m3);

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static unsafe Vector128<uint> LoadPaddedTailLane(byte* data, int dataLength, int offset)
    {
        if (offset + Vector128<byte>.Count <= dataLength)
        {
            return Vector128.LoadUnsafe(ref Unsafe.AsRef<byte>(data), (nuint)offset).AsUInt32();
        }

        if (offset >= dataLength)
        {
            return Vector128<uint>.Zero;
        }

        return LoadTailPadded128(data, dataLength, offset).AsUInt32();
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<uint> LoadPaddedLane(ref byte source, int length, int offset)
    {
        if (offset + Vector128<byte>.Count <= length)
        {
            return Vector128.LoadUnsafe(ref source, (nuint)offset).AsUInt32();
        }

        if (offset >= length)
        {
            return Vector128<uint>.Zero;
        }

        return LoadPadded128(ref Unsafe.Add(ref source, offset), length - offset).AsUInt32();
    }
}

#endif
