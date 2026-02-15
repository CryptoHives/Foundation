// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

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
///   <item><description>Uses table-based GHASH for performance</description></item>
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
    /// Computes the GHASH function over the input data.
    /// </summary>
    /// <param name="h">The hash subkey H (encrypted zero block).</param>
    /// <param name="data">The input data to hash.</param>
    /// <param name="output">The 16-byte output buffer.</param>
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
    public static void GctrAes(ReadOnlySpan<uint> roundKeys, int rounds,
                                ReadOnlySpan<byte> icb, ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (input.Length == 0)
            return;

        Span<byte> counter = stackalloc byte[BlockSizeBytes];
        Span<byte> keystream = stackalloc byte[BlockSizeBytes];
        icb.CopyTo(counter);

        int offset = 0;
        while (offset < input.Length)
        {
            // Encrypt counter to get keystream
            AesCore.EncryptBlock(counter, keystream, roundKeys, rounds);

            // XOR with input
            int blockLen = Math.Min(BlockSizeBytes, input.Length - offset);
            for (int i = 0; i < blockLen; i++)
            {
                output[offset + i] = (byte)(input[offset + i] ^ keystream[i]);
            }

            // Increment counter (32-bit big-endian increment of last 4 bytes)
            IncrementCounter(counter);

            offset += blockLen;
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
    /// Increments the counter block (last 32 bits, big-endian).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void IncrementCounter(Span<byte> counter)
    {
        // Increment last 4 bytes as big-endian 32-bit integer
        for (int i = 15; i >= 12; i--)
        {
            if (++counter[i] != 0)
                break;
        }
    }

    /// <summary>
    /// Processes blocks for GHASH, padding the last block if necessary.
    /// </summary>
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
}
