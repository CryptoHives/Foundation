// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Arithmetic and bitwise operations on byte buffers, written on <c>ref</c> access so the hot loops
/// carry no per-element range check.
/// </summary>
internal static class BinaryOperations
{
    // ================================================================
    // Counters
    // ================================================================

    /// <summary>
    /// Increments the big-endian <see cref="UInt32"/> at <paramref name="offset"/>, wrapping within
    /// those four bytes (the GCM <c>inc32</c> function).
    /// </summary>
    /// <param name="block">The block holding the counter word.</param>
    /// <param name="offset">The offset of the counter word; four bytes must be available from it.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void IncrementUInt32BigEndian(Span<byte> block, int offset)
    {
        ref byte word = ref MemoryMarshal.GetReference(block.Slice(offset, sizeof(uint)));
        uint value = Unsafe.ReadUnaligned<uint>(ref word);
        if (BitConverter.IsLittleEndian)
        {
            value = BinaryPrimitives.ReverseEndianness(value) + 1;
            Unsafe.WriteUnaligned(ref word, BinaryPrimitives.ReverseEndianness(value));
        }
        else
        {
            Unsafe.WriteUnaligned(ref word, value + 1);
        }
    }

    /// <summary>
    /// Increments <paramref name="counter"/> as a big-endian integer of its full length, carrying into
    /// the more significant bytes and wrapping to zero on overflow.
    /// </summary>
    /// <param name="counter">The counter, most significant byte first.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void IncrementBigEndian(Span<byte> counter)
    {
        ref byte start = ref MemoryMarshal.GetReference(counter);
        nuint i = (nuint)counter.Length;

        if (i >= sizeof(uint))
        {
            // The low word overflows once in 2^32 increments; only then does the byte loop run.
            i -= sizeof(uint);
            ref byte word = ref Unsafe.Add(ref start, i);
            uint value = Unsafe.ReadUnaligned<uint>(ref word);
            if (BitConverter.IsLittleEndian)
            {
                value = BinaryPrimitives.ReverseEndianness(value) + 1;
                Unsafe.WriteUnaligned(ref word, BinaryPrimitives.ReverseEndianness(value));
            }
            else
            {
                value += 1;
                Unsafe.WriteUnaligned(ref word, value);
            }

            if (value != 0)
            {
                return;
            }
        }

        while (i > 0)
        {
            i--;
            if (++Unsafe.Add(ref start, i) != 0)
            {
                return;
            }
        }
    }

    // ================================================================
    // XOR
    // ================================================================

    /// <summary>
    /// XORs one 16-byte block of <paramref name="left"/> with <paramref name="right"/> into <paramref name="destination"/>.
    /// </summary>
    /// <param name="left">The first operand (at least 16 bytes).</param>
    /// <param name="right">The second operand (at least 16 bytes).</param>
    /// <param name="destination">The result (at least 16 bytes); may be the same span as either operand.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void Xor128(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right, Span<byte> destination)
    {
        Xor128(
            ref MemoryMarshal.GetReference(left.Slice(0, 2 * sizeof(ulong))),
            ref MemoryMarshal.GetReference(right.Slice(0, 2 * sizeof(ulong))),
            ref MemoryMarshal.GetReference(destination.Slice(0, 2 * sizeof(ulong))));
    }

    /// <summary>
    /// XORs one 16-byte block of <paramref name="left"/> with <paramref name="right"/> into <paramref name="destination"/>,
    /// for loops that already hold references and have checked the bounds once.
    /// </summary>
    /// <param name="left">The first operand; 16 bytes must be readable.</param>
    /// <param name="right">The second operand; 16 bytes must be readable.</param>
    /// <param name="destination">The result; 16 bytes must be writable. May alias either operand.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void Xor128(ref byte left, ref byte right, ref byte destination)
    {
        ulong x0 = Unsafe.ReadUnaligned<ulong>(ref left) ^ Unsafe.ReadUnaligned<ulong>(ref right);
        ulong x1 = Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref left, sizeof(ulong))) ^ Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref right, sizeof(ulong)));
        Unsafe.WriteUnaligned(ref destination, x0);
        Unsafe.WriteUnaligned(ref Unsafe.Add(ref destination, sizeof(ulong)), x1);
    }

    /// <summary>
    /// XORs <paramref name="left"/> with the first <c>left.Length</c> bytes of <paramref name="right"/> into <paramref name="destination"/>.
    /// </summary>
    /// <param name="left">The first operand; its length sets the number of bytes processed.</param>
    /// <param name="right">The second operand (at least as long as <paramref name="left"/>).</param>
    /// <param name="destination">The result (at least as long as <paramref name="left"/>); may be the same span as either operand.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void Xor(ReadOnlySpan<byte> left, ReadOnlySpan<byte> right, Span<byte> destination)
    {
        int length = left.Length;
        Xor(
            ref MemoryMarshal.GetReference(left),
            ref MemoryMarshal.GetReference(right.Slice(0, length)),
            ref MemoryMarshal.GetReference(destination.Slice(0, length)),
            (nuint)length);
    }

    /// <summary>
    /// XORs <paramref name="length"/> bytes of <paramref name="left"/> with <paramref name="right"/> into <paramref name="destination"/>,
    /// for callers that already hold references and have checked the bounds once.
    /// </summary>
    /// <param name="left">The first operand; <paramref name="length"/> bytes must be readable.</param>
    /// <param name="right">The second operand; <paramref name="length"/> bytes must be readable.</param>
    /// <param name="destination">The result; <paramref name="length"/> bytes must be writable. May alias either operand.</param>
    /// <param name="length">The number of bytes to process.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void Xor(ref byte left, ref byte right, ref byte destination, nuint length)
    {
        nuint i = 0;
        for (; i + sizeof(ulong) <= length; i += sizeof(ulong))
        {
            Unsafe.WriteUnaligned(ref Unsafe.Add(ref destination, i),
                Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref left, i)) ^
                Unsafe.ReadUnaligned<ulong>(ref Unsafe.Add(ref right, i)));
        }

        for (; i < length; i++)
        {
            Unsafe.Add(ref destination, i) = (byte)(Unsafe.Add(ref left, i) ^ Unsafe.Add(ref right, i));
        }
    }
}
