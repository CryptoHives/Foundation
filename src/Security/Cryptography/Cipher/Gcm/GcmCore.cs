// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Core GCM (Galois/Counter Mode) operations as specified in NIST SP 800-38D.
/// </summary>
/// <remarks>
/// <para>
/// GCM provides authenticated encryption with associated data (AEAD).
/// It combines CTR mode encryption with GHASH authentication.
/// </para>
/// <para>
/// <b>Implementation notes:</b>
/// <list type="bullet">
///   <item><description>Uses <see cref="UInt64"/>-based GHASH for reduced allocation overhead</description></item>
///   <item><description>Supports 128-bit authentication tags</description></item>
///   <item><description>96-bit IVs are recommended for best performance</description></item>
/// </list>
/// </para>
/// </remarks>
internal static class GcmCore
{
    /// <summary>
    /// GCM block size in bytes (128 bits).
    /// </summary>
    public const int BlockSizeBytes = 16;

    /// <summary>
    /// Default tag size in bytes (128 bits).
    /// </summary>
    public const int TagSizeBytes = 16;

    /// <summary>
    /// Recommended nonce size in bytes (96 bits).
    /// </summary>
    public const int NonceSizeBytes = 12;

    /// <summary>
    /// Reduction polynomial for GF(2^128): x^128 + x^7 + x^2 + x + 1
    /// Represented as the lower 128 bits: 0xe1 shifted appropriately.
    /// </summary>
    private const ulong R = 0xe100000000000000UL;

    /// <summary>
    /// Number of entries in the 4-bit multiplication table.
    /// </summary>
    private const int ShoupTableSize = 16;

    /// <summary>
    /// 4-bit reduction table for the right-shift-by-4 operation in GF(2^128).
    /// </summary>
    /// <remarks>
    /// When shifting a 128-bit value right by 4, the 4 low bits that fall off
    /// must be folded back via the reduction polynomial. Entry <c>i</c> is the
    /// XOR-reduction of <c>(0, i) &gt;&gt; 4</c> computed bit-by-bit.
    /// </remarks>
    private static readonly ulong[] ReductionTable =
    [
        0x0000000000000000, 0x1c20000000000000, 0x3840000000000000, 0x2460000000000000,
        0x7080000000000000, 0x6ca0000000000000, 0x48c0000000000000, 0x54e0000000000000,
        0xe100000000000000, 0xfd20000000000000, 0xd940000000000000, 0xc560000000000000,
        0x9180000000000000, 0x8da0000000000000, 0xa9c0000000000000, 0xb5e0000000000000
    ];

    /// <summary>
    /// Precomputes the 4-bit Shoup multiplication table for a hash subkey H.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Builds 16 entries where <c>M[i]</c> represents <c>H</c> multiplied by the
    /// 4-bit polynomial encoded in <c>i</c>. The nibble-to-polynomial mapping uses
    /// GCM's MSB-first convention: bit 3 (value 8) → x⁰, bit 2 (value 4) → x¹,
    /// bit 1 (value 2) → x², bit 0 (value 1) → x³.
    /// </para>
    /// <para>
    /// During multiplication, the input is processed one nibble at a time from
    /// LSB to MSB (32 iterations), giving a ~4× speedup over bit-by-bit.
    /// </para>
    /// </remarks>
    /// <param name="h0">High 64 bits of H.</param>
    /// <param name="h1">Low 64 bits of H.</param>
    /// <returns>
    /// An array of 32 ulongs representing 16 entries of (hi, lo) pairs.
    /// </returns>
    public static ulong[] BuildShoupTable(ulong h0, ulong h1)
    {
        var table = new ulong[ShoupTableSize * 2];

        // M[0] = 0 (already zeroed)
        // M[8] = H · x⁰ = H
        table[16] = h0;
        table[17] = h1;

        // M[4] = H · x¹ (right-shift H by 1 with reduction)
        ShiftRight1(h0, h1, out table[8], out table[9]);

        // M[2] = H · x²
        ShiftRight1(table[8], table[9], out table[4], out table[5]);

        // M[1] = H · x³
        ShiftRight1(table[4], table[5], out table[2], out table[3]);

        // Fill remaining entries by linearity: M[a^b] = M[a] ^ M[b]
        for (int i = 3; i < ShoupTableSize; i++)
        {
            if (table[2 * i] == 0 && table[2 * i + 1] == 0)
            {
                // Find highest set bit
                int hb = 1;
                for (int b = 3; b >= 0; b--)
                {
                    if ((i & (1 << b)) != 0) { hb = 1 << b; break; }
                }

                int rest = i ^ hb;
                table[2 * i] = table[2 * hb] ^ table[2 * rest];
                table[2 * i + 1] = table[2 * hb + 1] ^ table[2 * rest + 1];
            }
        }

        return table;
    }

    /// <summary>
    /// Right-shifts a 128-bit value by 1 bit with polynomial reduction.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void ShiftRight1(ulong hi, ulong lo, out ulong rhi, out ulong rlo)
    {
        ulong carry = (lo & 1) != 0 ? R : 0UL;
        rlo = (lo >> 1) | (hi << 63);
        rhi = (hi >> 1) ^ carry;
    }

    /// <summary>
    /// Computes GHASH with AAD and ciphertext using a precomputed Shoup table.
    /// </summary>
    /// <param name="shoupTable">The precomputed 4-bit Shoup multiplication table.</param>
    /// <param name="aad">Additional authenticated data.</param>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <param name="output">The 16-byte output buffer.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void GHashComplete(ulong[] shoupTable, ReadOnlySpan<byte> aad,
                                      ReadOnlySpan<byte> ciphertext, Span<byte> output)
    {
        ulong y0 = 0, y1 = 0;

        ProcessBlocks(shoupTable, aad, ref y0, ref y1);
        ProcessBlocks(shoupTable, ciphertext, ref y0, ref y1);

        // Process length block
        ulong aadBits = (ulong)aad.Length * 8;
        ulong cBits = (ulong)ciphertext.Length * 8;
        y0 ^= aadBits;
        y1 ^= cBits;
        GfMulShoup(shoupTable, ref y0, ref y1);

        BinaryPrimitives.WriteUInt64BigEndian(output, y0);
        BinaryPrimitives.WriteUInt64BigEndian(output.Slice(sizeof(UInt64)), y1);
    }

    /// <summary>
    /// Computes GHASH with AAD and ciphertext using H stored as ulongs (avoids byte conversions in hot loop).
    /// </summary>
    /// <param name="h0">High 64 bits of the hash subkey H.</param>
    /// <param name="h1">Low 64 bits of the hash subkey H.</param>
    /// <param name="aad">Additional authenticated data.</param>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <param name="output">The 16-byte output buffer.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void GHashComplete(ulong h0, ulong h1, ReadOnlySpan<byte> aad,
                                      ReadOnlySpan<byte> ciphertext, Span<byte> output)
    {
        ulong y0 = 0, y1 = 0;

        // Process AAD
        ProcessBlocks(h0, h1, aad, ref y0, ref y1);

        // Process ciphertext
        ProcessBlocks(h0, h1, ciphertext, ref y0, ref y1);

        // Process length block
        ulong aadBits = (ulong)aad.Length * 8;
        ulong cBits = (ulong)ciphertext.Length * 8;
        y0 ^= aadBits;
        y1 ^= cBits;
        GfMulUlong(h0, h1, ref y0, ref y1);

        BinaryPrimitives.WriteUInt64BigEndian(output, y0);
        BinaryPrimitives.WriteUInt64BigEndian(output.Slice(sizeof(UInt64)), y1);
    }

    /// <summary>
    /// Computes the GHASH function over the input data.
    /// </summary>
    /// <param name="h">The hash subkey H (encrypted zero block).</param>
    /// <param name="data">The input data to hash.</param>
    /// <param name="output">The 16-byte output buffer.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void GHash(ReadOnlySpan<byte> h, ReadOnlySpan<byte> data, Span<byte> output)
    {
        // Initialize Y to zero
        Span<byte> y = stackalloc byte[BlockSizeBytes];
        y.Clear();

        int offset = 0;
        while (offset < data.Length)
        {
            // XOR with next block
            int blockLen = Math.Min(BlockSizeBytes, data.Length - offset);
            for (int i = 0; i < blockLen; i++)
            {
                y[i] ^= data[offset + i];
            }

            // Multiply by H in GF(2^128)
            GfMul(y, h, y);

            offset += BlockSizeBytes;
        }

        y.CopyTo(output);
    }

    /// <summary>
    /// Computes GHASH with AAD and ciphertext, including length block.
    /// </summary>
    /// <param name="h">The hash subkey H.</param>
    /// <param name="aad">Additional authenticated data.</param>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <param name="output">The 16-byte output buffer.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void GHashComplete(ReadOnlySpan<byte> h, ReadOnlySpan<byte> aad,
                                      ReadOnlySpan<byte> ciphertext, Span<byte> output)
    {
        Span<byte> y = stackalloc byte[BlockSizeBytes];
        y.Clear();

        // Process AAD (padded to block boundary)
        ProcessBlocks(h, aad, y);

        // Process ciphertext (padded to block boundary)
        ProcessBlocks(h, ciphertext, y);

        // Process length block: [len(AAD) in bits | len(C) in bits]
        Span<byte> lenBlock = stackalloc byte[BlockSizeBytes];
        ulong aadBits = (ulong)aad.Length * 8;
        ulong cBits = (ulong)ciphertext.Length * 8;
        BinaryPrimitives.WriteUInt64BigEndian(lenBlock.Slice(0), aadBits);
        BinaryPrimitives.WriteUInt64BigEndian(lenBlock.Slice(sizeof(UInt64)), cBits);

        // XOR and multiply
        for (int i = 0; i < BlockSizeBytes; i++)
        {
            y[i] ^= lenBlock[i];
        }
        GfMul(y, h, y);

        y.CopyTo(output);
    }

    /// <summary>
    /// Performs GCTR (GCM counter mode) encryption/decryption using AES.
    /// </summary>
    /// <param name="roundKeys">The AES round keys.</param>
    /// <param name="rounds">Number of AES rounds.</param>
    /// <param name="icb">The initial counter block.</param>
    /// <param name="input">The input data.</param>
    /// <param name="output">The output buffer.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void GctrAes(ReadOnlySpan<uint> roundKeys, int rounds,
                                ReadOnlySpan<byte> icb, ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (input.Length == 0)
        {
            return;
        }

        Span<byte> counter = stackalloc byte[BlockSizeBytes];
        Span<byte> keystream = stackalloc byte[BlockSizeBytes];
        icb.CopyTo(counter);

        int offset = 0;
        while (offset < input.Length)
        {
            // Encrypt counter to get keystream
            AesCore.EncryptBlock(counter, keystream, roundKeys, rounds);

            int remaining = input.Length - offset;

            if (remaining >= BlockSizeBytes)
            {
                // Full block: XOR using ulong-wide operations
                ReadOnlySpan<ulong> src = MemoryMarshal.Cast<byte, ulong>(input.Slice(offset, BlockSizeBytes));
                ReadOnlySpan<ulong> ks = MemoryMarshal.Cast<byte, ulong>(keystream);
                Span<ulong> dst = MemoryMarshal.Cast<byte, ulong>(output.Slice(offset, BlockSizeBytes));
                dst[0] = src[0] ^ ks[0];
                dst[1] = src[1] ^ ks[1];
            }
            else
            {
                // Partial block: byte-by-byte XOR
                for (int i = 0; i < remaining; i++)
                {
                    output[offset + i] = (byte)(input[offset + i] ^ keystream[i]);
                }
            }

            // Increment counter (32-bit big-endian increment of last 4 bytes)
            IncrementCounter(counter);

            offset += BlockSizeBytes;
        }
    }

    /// <summary>
    /// Computes the initial counter block J0 from nonce.
    /// </summary>
    /// <param name="h">The hash subkey H.</param>
    /// <param name="nonce">The nonce/IV.</param>
    /// <param name="j0">The output J0 buffer (16 bytes).</param>
    public static void ComputeJ0(ReadOnlySpan<byte> h, ReadOnlySpan<byte> nonce, Span<byte> j0)
    {
        if (nonce.Length == NonceSizeBytes)
        {
            // For 96-bit nonce: J0 = nonce || 0^31 || 1
            nonce.CopyTo(j0);
            j0[12] = 0;
            j0[13] = 0;
            j0[14] = 0;
            j0[15] = 1;
        }
        else
        {
            // For other lengths: J0 = GHASH(H, nonce || 0^s || len(nonce))
            // where s is the minimum number of zero bits to make (nonce || 0^s) a multiple of 128 bits
            int s = (BlockSizeBytes - (nonce.Length % BlockSizeBytes)) % BlockSizeBytes;
            int paddedLen = nonce.Length + s + BlockSizeBytes;

            byte[]? paddedArray = null;
            Span<byte> paddedNonce = paddedLen <= 256
                ? stackalloc byte[paddedLen]
                : (paddedArray = ArrayPool<byte>.Shared.Rent(paddedLen)).AsSpan(0, paddedLen);
            try
            {
                paddedNonce.Clear();
                nonce.CopyTo(paddedNonce);
                // Padding zeros are already there from Clear()
                // Add length in bits at the end
                BinaryPrimitives.WriteUInt64BigEndian(paddedNonce.Slice(paddedLen - sizeof(UInt64)), (ulong)nonce.Length * 8);

                GHash(h, paddedNonce, j0);
            }
            finally
            {
                if (paddedArray != null)
                {
                    ArrayPool<byte>.Shared.Return(paddedArray);
                }
            }
        }
    }

    /// <summary>
    /// Multiplies two elements in GF(2^128).
    /// </summary>
    /// <param name="x">First operand (16 bytes).</param>
    /// <param name="y">Second operand (16 bytes).</param>
    /// <param name="result">Result buffer (16 bytes, can be same as x).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void GfMul(ReadOnlySpan<byte> x, ReadOnlySpan<byte> y, Span<byte> result)
    {
        // Convert to 64-bit words (big-endian)
        ulong x0 = BinaryPrimitives.ReadUInt64BigEndian(x.Slice(0));
        ulong x1 = BinaryPrimitives.ReadUInt64BigEndian(x.Slice(sizeof(UInt64)));
        ulong y0 = BinaryPrimitives.ReadUInt64BigEndian(y.Slice(0));
        ulong y1 = BinaryPrimitives.ReadUInt64BigEndian(y.Slice(sizeof(UInt64)));

        ulong z0 = 0, z1 = 0;

        // Multiply using the "left-to-right" method
        for (int i = 0; i < 64; i++)
        {
            // If bit i of y0 is set, XOR x into z
            if (((y0 >> (63 - i)) & 1) == 1)
            {
                z0 ^= x0;
                z1 ^= x1;
            }

            // Reduce x by the polynomial if needed, then shift right
            bool lsb = (x1 & 1) == 1;
            x1 = (x1 >> 1) | (x0 << 63);
            x0 >>= 1;
            if (lsb)
            {
                x0 ^= R;
            }
        }

        for (int i = 0; i < 64; i++)
        {
            if (((y1 >> (63 - i)) & 1) == 1)
            {
                z0 ^= x0;
                z1 ^= x1;
            }

            bool lsb = (x1 & 1) == 1;
            x1 = (x1 >> 1) | (x0 << 63);
            x0 >>= 1;
            if (lsb)
            {
                x0 ^= R;
            }
        }

        BinaryPrimitives.WriteUInt64BigEndian(result.Slice(0), z0);
        BinaryPrimitives.WriteUInt64BigEndian(result.Slice(sizeof(UInt64)), z1);
    }

    /// <summary>
    /// Multiplies y by H in GF(2^128), operating directly on <see cref="UInt64"/> pairs.
    /// </summary>
    /// <remarks>
    /// This avoids repeated byte-to-ulong conversions when H is already stored as ulongs.
    /// The algorithm is identical to <see cref="GfMul"/>.
    /// </remarks>
    /// <param name="h0">High 64 bits of H.</param>
    /// <param name="h1">Low 64 bits of H.</param>
    /// <param name="y0">High 64 bits of y (modified in place with result).</param>
    /// <param name="y1">Low 64 bits of y (modified in place with result).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GfMulUlong(ulong h0, ulong h1, ref ulong y0, ref ulong y1)
    {
        ulong x0 = y0, x1 = y1;
        ulong z0 = 0, z1 = 0;

        for (int i = 0; i < 64; i++)
        {
            if (((h0 >> (63 - i)) & 1) == 1)
            {
                z0 ^= x0;
                z1 ^= x1;
            }

            bool lsb = (x1 & 1) == 1;
            x1 = (x1 >> 1) | (x0 << 63);
            x0 >>= 1;
            if (lsb) x0 ^= R;
        }

        for (int i = 0; i < 64; i++)
        {
            if (((h1 >> (63 - i)) & 1) == 1)
            {
                z0 ^= x0;
                z1 ^= x1;
            }

            bool lsb = (x1 & 1) == 1;
            x1 = (x1 >> 1) | (x0 << 63);
            x0 >>= 1;
            if (lsb) x0 ^= R;
        }

        y0 = z0;
        y1 = z1;
    }

    /// <summary>
    /// Multiplies y by H in GF(2^128) using a precomputed 4-bit Shoup table.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Processes 4 bits at a time (32 iterations instead of 128), using the
    /// precomputed table <c>M[i] = H · i</c> for <c>i = 0..15</c>.
    /// </para>
    /// <para>
    /// For each nibble of y (from low nibble of y1 to high nibble of y0):
    /// <list type="number">
    ///   <item><description>Extract the low 4 bits of the accumulator for reduction</description></item>
    ///   <item><description>Right-shift the accumulator by 4</description></item>
    ///   <item><description>Apply reduction from <see cref="ReductionTable"/></description></item>
    ///   <item><description>XOR with <c>M[nibble]</c> from the Shoup table</description></item>
    /// </list>
    /// </para>
    /// </remarks>
    /// <param name="table">The precomputed Shoup table (32 ulongs = 16 pairs).</param>
    /// <param name="y0">High 64 bits of y (modified in place with result).</param>
    /// <param name="y1">Low 64 bits of y (modified in place with result).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GfMulShoup(ulong[] table, ref ulong y0, ref ulong y1)
    {
        ulong x0 = y0, x1 = y1;
        ulong z0 = 0, z1 = 0;

        // Process nibbles from LSB to MSB: x1 nibbles 0..15, then x0 nibbles 0..15.
        // XOR table entry first, then shift right by 4 with reduction.
        // The final nibble (MSB of x0) does NOT get a trailing shift.
        for (int i = 0; i <= 15; i++)
        {
            int nibble = (int)(x1 >> (i * 4)) & 0xF;
            z0 ^= table[2 * nibble];
            z1 ^= table[2 * nibble + 1];

            ulong dropped = z1 & 0xF;
            z1 = (z1 >> 4) | (z0 << 60);
            z0 = (z0 >> 4) ^ ReductionTable[dropped];
        }

        for (int i = 0; i <= 14; i++)
        {
            int nibble = (int)(x0 >> (i * 4)) & 0xF;
            z0 ^= table[2 * nibble];
            z1 ^= table[2 * nibble + 1];

            ulong dropped = z1 & 0xF;
            z1 = (z1 >> 4) | (z0 << 60);
            z0 = (z0 >> 4) ^ ReductionTable[dropped];
        }

        // Last nibble: XOR only, no shift
        {
            int nibble = (int)(x0 >> 60) & 0xF;
            z0 ^= table[2 * nibble];
            z1 ^= table[2 * nibble + 1];
        }

        y0 = z0;
        y1 = z1;
    }

    /// <summary>
    /// Processes blocks for GHASH using a precomputed Shoup table.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void ProcessBlocks(ulong[] shoupTable, ReadOnlySpan<byte> data, ref ulong y0, ref ulong y1)
    {
        int offset = 0;
        Span<byte> padded = stackalloc byte[BlockSizeBytes];
        while (offset < data.Length)
        {
            int blockLen = Math.Min(BlockSizeBytes, data.Length - offset);

            if (blockLen == BlockSizeBytes)
            {
                y0 ^= BinaryPrimitives.ReadUInt64BigEndian(data.Slice(offset));
                y1 ^= BinaryPrimitives.ReadUInt64BigEndian(data.Slice(offset + sizeof(UInt64)));
            }
            else
            {
                padded.Clear();
                data.Slice(offset, blockLen).CopyTo(padded);
                y0 ^= BinaryPrimitives.ReadUInt64BigEndian(padded);
                y1 ^= BinaryPrimitives.ReadUInt64BigEndian(padded.Slice(sizeof(UInt64)));
            }

            GfMulShoup(shoupTable, ref y0, ref y1);
            offset += BlockSizeBytes;
        }
    }

    /// <summary>
    /// Processes blocks for GHASH using H stored as ulongs.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void ProcessBlocks(ulong h0, ulong h1, ReadOnlySpan<byte> data, ref ulong y0, ref ulong y1)
    {
        int offset = 0;
        Span<byte> padded = stackalloc byte[BlockSizeBytes];
        while (offset < data.Length)
        {
            int blockLen = Math.Min(BlockSizeBytes, data.Length - offset);

            if (blockLen == BlockSizeBytes)
            {
                y0 ^= BinaryPrimitives.ReadUInt64BigEndian(data.Slice(offset));
                y1 ^= BinaryPrimitives.ReadUInt64BigEndian(data.Slice(offset + sizeof(UInt64)));
            }
            else
            {
                padded.Clear();
                data.Slice(offset, blockLen).CopyTo(padded);
                y0 ^= BinaryPrimitives.ReadUInt64BigEndian(padded);
                y1 ^= BinaryPrimitives.ReadUInt64BigEndian(padded.Slice(sizeof(UInt64)));
            }

            GfMulUlong(h0, h1, ref y0, ref y1);
            offset += BlockSizeBytes;
        }
    }

    /// <summary>
    /// Processes blocks for GHASH, padding the last block if necessary.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void ProcessBlocks(ReadOnlySpan<byte> h, ReadOnlySpan<byte> data, Span<byte> y)
    {
        int offset = 0;
        while (offset < data.Length)
        {
            int blockLen = Math.Min(BlockSizeBytes, data.Length - offset);

            // XOR with next block (pad with zeros if partial)
            for (int i = 0; i < blockLen; i++)
            {
                y[i] ^= data[offset + i];
            }

            // Multiply by H
            GfMul(y, h, y);

            offset += BlockSizeBytes;
        }
    }

    /// <summary>
    /// Increments the counter block (last 32 bits, big-endian).
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void IncrementCounter(Span<byte> counter)
    {
        for (int i = 15; i >= 12; i--)
        {
            if (++counter[i] != 0)
                break;
        }
    }
}
