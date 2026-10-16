// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// POLYVAL (RFC 8452 §3): the little-endian GF(2^128) universal hash under AES-GCM-SIV.
/// </summary>
/// <remarks>
/// The scalar path runs POLYVAL through GHASH, using RFC 8452 Appendix A:
/// <c>POLYVAL(H, X) = ByteReverse(GHASH(mulX_GHASH(ByteReverse(H)), ByteReverse(X)))</c>.
/// Reading a block as two little-endian words in swapped order is its byte reversal, so no block is copied.
/// </remarks>
internal static class Polyval
{
    /// <summary>The block and output size in bytes.</summary>
    public const int BlockSizeBytes = 16;

    /// <summary>
    /// Gets whether the carry-less multiply path can run on this machine.
    /// </summary>
    internal static bool IsPclmulSupported =>
#if NET8_0_OR_GREATER
        Pclmulqdq.IsSupported && Sse2.IsSupported && BitConverter.IsLittleEndian;
#else
        false;
#endif

    /// <summary>
    /// Computes POLYVAL over <c>pad(aad) ‖ pad(message) ‖ LE64(|aad|·8) ‖ LE64(|message|·8)</c>,
    /// the input AES-GCM-SIV authenticates.
    /// </summary>
    /// <param name="h">The 16-byte message-authentication key.</param>
    /// <param name="aad">The associated data.</param>
    /// <param name="message">The plaintext.</param>
    /// <param name="output">The 16-byte result.</param>
    /// <param name="usePclmul">Whether to use PCLMULQDQ; ignored where it is unsupported.</param>
    public static void ComputeSiv(
        ReadOnlySpan<byte> h, ReadOnlySpan<byte> aad, ReadOnlySpan<byte> message, Span<byte> output, bool usePclmul)
    {
#if NET8_0_OR_GREATER
        if (IsPclmulSupported && usePclmul)
        {
            ComputeSivPclmul(h, aad, message, output);
            return;
        }
#endif
        ComputeSivScalar(h, aad, message, output);
    }

    /// <summary>
    /// Computes POLYVAL(H, X₁, …, Xₙ) over whole 16-byte blocks, as RFC 8452 Appendix A states it.
    /// </summary>
    /// <param name="h">The 16-byte key.</param>
    /// <param name="blocks">The input; its length must be a multiple of 16.</param>
    /// <param name="output">The 16-byte result.</param>
    /// <param name="usePclmul">Whether to use PCLMULQDQ; ignored where it is unsupported.</param>
    internal static void Compute(ReadOnlySpan<byte> h, ReadOnlySpan<byte> blocks, Span<byte> output, bool usePclmul)
    {
        if (blocks.Length % BlockSizeBytes != 0)
            throw new ArgumentException("Input must be whole 16-byte blocks.", nameof(blocks));

#if NET8_0_OR_GREATER
        if (IsPclmulSupported && usePclmul)
        {
            AbsorbPclmul(Vector128.Create(h).AsUInt64(), Vector128<ulong>.Zero, blocks).AsByte().CopyTo(output);
            return;
        }
#endif
        Span<ulong> table = stackalloc ulong[GcmCore.ShoupTableSpanSize];
        BuildTable(h, table);
        ulong y0 = 0, y1 = 0;
        AbsorbScalar(table, blocks, ref y0, ref y1);
        WriteScalar(y0, y1, output);
        CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(table));
    }

    [SkipLocalsInit]
    private static void ComputeSivScalar(
        ReadOnlySpan<byte> h, ReadOnlySpan<byte> aad, ReadOnlySpan<byte> message, Span<byte> output)
    {
        Span<ulong> table = stackalloc ulong[GcmCore.ShoupTableSpanSize];
        BuildTable(h, table);

        ulong y0 = 0, y1 = 0;
        AbsorbScalar(table, aad, ref y0, ref y1);
        AbsorbScalar(table, message, ref y0, ref y1);

        // Length block LE64(aad bits) ‖ LE64(message bits), read in swapped order like every block.
        y0 ^= (ulong)message.Length * 8;
        y1 ^= (ulong)aad.Length * 8;
        GcmCore.GfMulShoup(table, ref y0, ref y1);

        WriteScalar(y0, y1, output);
        CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(table));
    }

    private static void BuildTable(ReadOnlySpan<byte> h, Span<ulong> table)
    {
        // H' = mulX_GHASH(ByteReverse(H)): in GHASH's reflected order, multiplying by x is a right
        // shift by one that folds the dropped bit back through R. Branch-free, as H is secret.
        ulong hi = BinaryPrimitives.ReadUInt64LittleEndian(h.Slice(8));
        ulong lo = BinaryPrimitives.ReadUInt64LittleEndian(h);
        ulong reduce = 0xe100000000000000UL & (0UL - (lo & 1));

        // BuildShoupTable fills only the non-zero entries, and finds them by testing for zero.
        table.Clear();
        GcmCore.BuildShoupTable((hi >> 1) ^ reduce, (lo >> 1) | (hi << 63), table);
    }

    private static void WriteScalar(ulong y0, ulong y1, Span<byte> output)
    {
        BinaryPrimitives.WriteUInt64LittleEndian(output, y1);
        BinaryPrimitives.WriteUInt64LittleEndian(output.Slice(8), y0);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void AbsorbScalar(ReadOnlySpan<ulong> table, ReadOnlySpan<byte> data, ref ulong y0, ref ulong y1)
    {
        int offset = 0;
        for (; offset + BlockSizeBytes <= data.Length; offset += BlockSizeBytes)
        {
            y0 ^= BinaryPrimitives.ReadUInt64LittleEndian(data.Slice(offset + 8));
            y1 ^= BinaryPrimitives.ReadUInt64LittleEndian(data.Slice(offset));
            GcmCore.GfMulShoup(table, ref y0, ref y1);
        }

        if (offset < data.Length)
        {
            BinaryLoad.ReadUInt64PairLittleEndianPadded(data.Slice(offset), out ulong low, out ulong high);
            y0 ^= high;
            y1 ^= low;
            GcmCore.GfMulShoup(table, ref y0, ref y1);
        }
    }

#if NET8_0_OR_GREATER
    private static void ComputeSivPclmul(
        ReadOnlySpan<byte> h, ReadOnlySpan<byte> aad, ReadOnlySpan<byte> message, Span<byte> output)
    {
        Vector128<ulong> key = Vector128.Create(h).AsUInt64();

        Vector128<ulong> acc = AbsorbPclmul(key, Vector128<ulong>.Zero, aad);
        acc = AbsorbPclmul(key, acc, message);
        acc = Dot(Sse2.Xor(acc, Vector128.Create((ulong)aad.Length * 8, (ulong)message.Length * 8)), key);

        acc.AsByte().CopyTo(output);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<ulong> AbsorbPclmul(Vector128<ulong> key, Vector128<ulong> acc, ReadOnlySpan<byte> data)
    {
        int offset = 0;
        for (; offset + BlockSizeBytes <= data.Length; offset += BlockSizeBytes)
        {
            acc = Dot(Sse2.Xor(acc, Vector128.Create(data.Slice(offset, BlockSizeBytes)).AsUInt64()), key);
        }

        if (offset < data.Length)
        {
            BinaryLoad.ReadUInt64PairLittleEndianPadded(data.Slice(offset), out ulong low, out ulong high);
            acc = Dot(Sse2.Xor(acc, Vector128.Create(low, high)), key);
        }

        return acc;
    }

    /// <summary>
    /// dot(a, b) = a · b · x^-128 in POLYVAL's field: a schoolbook carry-less multiply, then two
    /// Montgomery folds by x^128 + x^127 + x^126 + x^121 + 1.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector128<ulong> Dot(Vector128<ulong> a, Vector128<ulong> b)
    {
        Vector128<ulong> poly = Vector128.Create(1UL, 0xc200000000000000UL);

        Vector128<ulong> lo = Pclmulqdq.CarrylessMultiply(a, b, 0x00);
        Vector128<ulong> hi = Pclmulqdq.CarrylessMultiply(a, b, 0x11);
        Vector128<ulong> mid = Sse2.Xor(
            Pclmulqdq.CarrylessMultiply(a, b, 0x10),
            Pclmulqdq.CarrylessMultiply(a, b, 0x01));

        lo = Sse2.Xor(lo, Sse2.ShiftLeftLogical128BitLane(mid, 8));
        hi = Sse2.Xor(hi, Sse2.ShiftRightLogical128BitLane(mid, 8));

        Vector128<ulong> fold = Pclmulqdq.CarrylessMultiply(lo, poly, 0x10);
        lo = Sse2.Xor(fold, Sse2.Shuffle(lo.AsUInt32(), 0x4E).AsUInt64());
        fold = Pclmulqdq.CarrylessMultiply(lo, poly, 0x10);
        lo = Sse2.Xor(fold, Sse2.Shuffle(lo.AsUInt32(), 0x4E).AsUInt64());

        return Sse2.Xor(hi, lo);
    }
#endif
}
