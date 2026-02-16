// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Core ChaCha20 operations as specified in RFC 8439.
/// </summary>
/// <remarks>
/// <para>
/// ChaCha20 is a stream cipher designed by Daniel J. Bernstein. It uses a 256-bit key,
/// a 96-bit nonce, and a 32-bit block counter to generate a keystream that is XORed
/// with the plaintext.
/// </para>
/// <para>
/// <b>Implementation notes:</b>
/// <list type="bullet">
///   <item><description>Uses the IETF variant with 96-bit nonce (RFC 8439)</description></item>
///   <item><description>20 rounds (10 double-rounds)</description></item>
///   <item><description>Little-endian byte order</description></item>
/// </list>
/// </para>
/// </remarks>
internal static class ChaChaCore
{
    /// <summary>
    /// ChaCha20 block size in bytes (512 bits = 64 bytes).
    /// </summary>
    public const int BlockSizeBytes = 64;

    /// <summary>
    /// ChaCha20 key size in bytes (256 bits = 32 bytes).
    /// </summary>
    public const int KeySizeBytes = 32;

    /// <summary>
    /// ChaCha20 nonce size in bytes for IETF variant (96 bits = 12 bytes).
    /// </summary>
    public const int NonceSizeBytes = 12;

    /// <summary>
    /// XChaCha20 nonce size in bytes (192 bits = 24 bytes).
    /// </summary>
    public const int XNonceSizeBytes = 24;

    /// <summary>
    /// HChaCha20 nonce size in bytes (128 bits = 16 bytes).
    /// </summary>
    public const int HNonceSizeBytes = 16;

    /// <summary>
    /// Number of rounds (20 for ChaCha20).
    /// </summary>
    public const int Rounds = 20;

    /// <summary>
    /// ChaCha20 state size in 32-bit words.
    /// </summary>
    private const int StateWords = 16;

    /// <summary>
    /// ChaCha constant "expand 32-byte k" as four 32-bit little-endian words.
    /// </summary>
    private static readonly uint[] Sigma =
    [
        0x61707865, // "expa"
        0x3320646e, // "nd 3"
        0x79622d32, // "2-by"
        0x6b206574  // "te k"
    ];

    /// <summary>
    /// Gets the SIMD instruction sets supported by ChaCha20 on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
#if NET8_0_OR_GREATER
            if (Sse2.IsSupported) support |= SimdSupport.Sse2;
#endif
            return support;
        }
    }

    /// <summary>
    /// Generates a 64-byte keystream block.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 12-byte nonce.</param>
    /// <param name="counter">The 32-bit block counter.</param>
    /// <param name="output">The 64-byte output buffer for the keystream.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Block(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter, Span<byte> output)
    {
        Span<uint> state = stackalloc uint[StateWords];
        Span<uint> workingState = stackalloc uint[StateWords];

        // Initialize state
        InitializeState(key, nonce, counter, state);

        // Copy state to working state
        state.CopyTo(workingState);

        // Perform 20 rounds (10 double-rounds)
        for (int i = 0; i < Rounds; i += 2)
        {
            // Odd round (column round)
            QuarterRound(ref workingState[0], ref workingState[4], ref workingState[8], ref workingState[12]);
            QuarterRound(ref workingState[1], ref workingState[5], ref workingState[9], ref workingState[13]);
            QuarterRound(ref workingState[2], ref workingState[6], ref workingState[10], ref workingState[14]);
            QuarterRound(ref workingState[3], ref workingState[7], ref workingState[11], ref workingState[15]);

            // Even round (diagonal round)
            QuarterRound(ref workingState[0], ref workingState[5], ref workingState[10], ref workingState[15]);
            QuarterRound(ref workingState[1], ref workingState[6], ref workingState[11], ref workingState[12]);
            QuarterRound(ref workingState[2], ref workingState[7], ref workingState[8], ref workingState[13]);
            QuarterRound(ref workingState[3], ref workingState[4], ref workingState[9], ref workingState[14]);
        }

        // Add original state to working state and serialize to output
        for (int i = 0; i < StateWords; i++)
        {
            workingState[i] += state[i];
        }

        BinarySpans.WriteUInt32LittleEndian(workingState.Slice(0, StateWords), output);
    }

    /// <summary>
    /// Encrypts or decrypts data using ChaCha20.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 12-byte nonce.</param>
    /// <param name="counter">The initial block counter.</param>
    /// <param name="input">The input data.</param>
    /// <param name="output">The output buffer (must be same size as input).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void Transform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter,
                                  ReadOnlySpan<byte> input, Span<byte> output)
    {
#if NET8_0_OR_GREATER
        if (Sse2.IsSupported)
        {
            TransformSse2(key, nonce, counter, input, output);
            return;
        }
#endif
        TransformScalar(key, nonce, counter, input, output);
    }

    /// <summary>
    /// Encrypts or decrypts data using ChaCha20 with forced SIMD support level.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 12-byte nonce.</param>
    /// <param name="counter">The initial block counter.</param>
    /// <param name="input">The input data.</param>
    /// <param name="output">The output buffer (must be same size as input).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    internal static void Transform(SimdSupport simdSupport, ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce,
                                    uint counter, ReadOnlySpan<byte> input, Span<byte> output)
    {
#if NET8_0_OR_GREATER
        if ((simdSupport & SimdSupport.Sse2) != 0 && Sse2.IsSupported)
        {
            TransformSse2(key, nonce, counter, input, output);
            return;
        }
#endif
        TransformScalar(key, nonce, counter, input, output);
    }

    /// <summary>
    /// Scalar fallback for <see cref="Transform(ReadOnlySpan{byte}, ReadOnlySpan{byte}, uint, ReadOnlySpan{byte}, Span{byte})"/>.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void TransformScalar(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter,
                                         ReadOnlySpan<byte> input, Span<byte> output)
    {
        Span<uint> state = stackalloc uint[StateWords];
        Span<uint> workingState = stackalloc uint[StateWords];

        // Initialize base state once (counter updated per block)
        InitializeState(key, nonce, counter, state);

        int offset = 0;

        while (offset < input.Length)
        {
            // Copy state to working state
            state.CopyTo(workingState);

            // Perform 20 rounds (10 double-rounds)
            for (int i = 0; i < Rounds; i += 2)
            {
                QuarterRound(ref workingState[0], ref workingState[4], ref workingState[8], ref workingState[12]);
                QuarterRound(ref workingState[1], ref workingState[5], ref workingState[9], ref workingState[13]);
                QuarterRound(ref workingState[2], ref workingState[6], ref workingState[10], ref workingState[14]);
                QuarterRound(ref workingState[3], ref workingState[7], ref workingState[11], ref workingState[15]);

                QuarterRound(ref workingState[0], ref workingState[5], ref workingState[10], ref workingState[15]);
                QuarterRound(ref workingState[1], ref workingState[6], ref workingState[11], ref workingState[12]);
                QuarterRound(ref workingState[2], ref workingState[7], ref workingState[8], ref workingState[13]);
                QuarterRound(ref workingState[3], ref workingState[4], ref workingState[9], ref workingState[14]);
            }

            // Add original state
            for (int i = 0; i < StateWords; i++)
            {
                workingState[i] += state[i];
            }

            int remaining = input.Length - offset;

            if (remaining >= BlockSizeBytes)
            {
                // Full block: XOR keystream with input using widened operations
                XorBlock(
                    input.Slice(offset, BlockSizeBytes),
                    MemoryMarshal.AsBytes(workingState),
                    output.Slice(offset, BlockSizeBytes));
            }
            else
            {
                // Partial block: serialize keystream then XOR byte-by-byte
                Span<byte> keystream = MemoryMarshal.AsBytes(workingState);
                if (!BitConverter.IsLittleEndian)
                {
                    Span<byte> ks = stackalloc byte[BlockSizeBytes];
                    BinarySpans.WriteUInt32LittleEndian(workingState.Slice(0, StateWords), ks);
                    keystream = ks;
                }

                for (int i = 0; i < remaining; i++)
                {
                    output[offset + i] = (byte)(input[offset + i] ^ keystream[i]);
                }
            }

            offset += BlockSizeBytes;

            // Increment counter in the base state
            state[12]++;
        }
    }

    /// <summary>
    /// XORs a full 64-byte block using ulong-sized operations for throughput.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void XorBlock(ReadOnlySpan<byte> input, ReadOnlySpan<byte> keystream, Span<byte> output)
    {
        if (BitConverter.IsLittleEndian)
        {
            // Fast path: keystream is already in memory-native order
            ReadOnlySpan<ulong> src = MemoryMarshal.Cast<byte, ulong>(input);
            ReadOnlySpan<ulong> ks = MemoryMarshal.Cast<byte, ulong>(keystream);
            Span<ulong> dst = MemoryMarshal.Cast<byte, ulong>(output);

            // 64 bytes / 8 = 8 ulongs
            dst[0] = src[0] ^ ks[0];
            dst[1] = src[1] ^ ks[1];
            dst[2] = src[2] ^ ks[2];
            dst[3] = src[3] ^ ks[3];
            dst[4] = src[4] ^ ks[4];
            dst[5] = src[5] ^ ks[5];
            dst[6] = src[6] ^ ks[6];
            dst[7] = src[7] ^ ks[7];
        }
        else
        {
            // Big-endian: serialize keystream to LE bytes, then XOR
            Span<byte> ks = stackalloc byte[BlockSizeBytes];
            ReadOnlySpan<uint> ksWords = MemoryMarshal.Cast<byte, uint>(keystream);
            BinarySpans.WriteUInt32LittleEndian(ksWords.Slice(0, StateWords), ks);

            for (int i = 0; i < BlockSizeBytes; i++)
            {
                output[i] = (byte)(input[i] ^ ks[i]);
            }
        }
    }

    /// <summary>
    /// Initializes the ChaCha20 state from key, nonce, and counter.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 12-byte nonce.</param>
    /// <param name="counter">The block counter.</param>
    /// <param name="state">The 16-word state to initialize.</param>
    /// <remarks>
    /// State layout (RFC 8439):
    /// <code>
    /// cccccccc  cccccccc  cccccccc  cccccccc
    /// kkkkkkkk  kkkkkkkk  kkkkkkkk  kkkkkkkk
    /// kkkkkkkk  kkkkkkkk  kkkkkkkk  kkkkkkkk
    /// bbbbbbbb  nnnnnnnn  nnnnnnnn  nnnnnnnn
    /// </code>
    /// Where c = constant, k = key, b = block counter, n = nonce.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void InitializeState(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter, Span<uint> state)
    {
        // Constants (words 0-3)
        state[0] = Sigma[0];
        state[1] = Sigma[1];
        state[2] = Sigma[2];
        state[3] = Sigma[3];

        // Key (words 4-11)
        BinarySpans.ReadUInt32LittleEndian(key, state.Slice(4));

        // Counter (word 12)
        state[12] = counter;

        // Nonce (words 13-15)
        BinarySpans.ReadUInt32LittleEndian(nonce, state.Slice(13));
    }

    /// <summary>
    /// The ChaCha quarter-round operation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The quarter-round operates on four 32-bit words:
    /// <code>
    /// a += b; d ^= a; d &lt;&lt;&lt;= 16;
    /// c += d; b ^= c; b &lt;&lt;&lt;= 12;
    /// a += b; d ^= a; d &lt;&lt;&lt;= 8;
    /// c += d; b ^= c; b &lt;&lt;&lt;= 7;
    /// </code>
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void QuarterRound(ref uint a, ref uint b, ref uint c, ref uint d)
    {
        a += b; d ^= a; d = BitOperations.RotateLeft(d, 16);
        c += d; b ^= c; b = BitOperations.RotateLeft(b, 12);
        a += b; d ^= a; d = BitOperations.RotateLeft(d, 8);
        c += d; b ^= c; b = BitOperations.RotateLeft(b, 7);
    }

    /// <summary>
    /// HChaCha20 is used for key derivation in XChaCha20.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 16-byte nonce.</param>
    /// <param name="subkey">The 32-byte output subkey.</param>
    /// <remarks>
    /// <para>
    /// HChaCha20 performs the ChaCha20 operations but returns only the first
    /// and last rows of the state (256 bits total) as the subkey.
    /// </para>
    /// <para>
    /// State layout for HChaCha20:
    /// <code>
    /// cccccccc  cccccccc  cccccccc  cccccccc
    /// kkkkkkkk  kkkkkkkk  kkkkkkkk  kkkkkkkk
    /// kkkkkkkk  kkkkkkkk  kkkkkkkk  kkkkkkkk
    /// nnnnnnnn  nnnnnnnn  nnnnnnnn  nnnnnnnn
    /// </code>
    /// Where c = constant, k = key, n = nonce (no counter).
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void HChaCha20(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, Span<byte> subkey)
    {
        if (key.Length != KeySizeBytes)
            throw new ArgumentException($"Key must be {KeySizeBytes} bytes.", nameof(key));
        if (nonce.Length != HNonceSizeBytes)
            throw new ArgumentException($"Nonce must be {HNonceSizeBytes} bytes.", nameof(nonce));
        if (subkey.Length < KeySizeBytes)
            throw new ArgumentException($"Subkey buffer must be at least {KeySizeBytes} bytes.", nameof(subkey));

        Span<uint> state = stackalloc uint[StateWords];

        // Initialize state (no counter, nonce is 16 bytes)
        state[0] = Sigma[0];
        state[1] = Sigma[1];
        state[2] = Sigma[2];
        state[3] = Sigma[3];

        // Key (words 4-11)
        BinarySpans.ReadUInt32LittleEndian(key, state.Slice(4));

        // Nonce (words 12-15, instead of counter + nonce)
        BinarySpans.ReadUInt32LittleEndian(nonce, state.Slice(12));

        // Perform 20 rounds (10 double-rounds)
        for (int i = 0; i < Rounds; i += 2)
        {
            // Odd round (column round)
            QuarterRound(ref state[0], ref state[4], ref state[8], ref state[12]);
            QuarterRound(ref state[1], ref state[5], ref state[9], ref state[13]);
            QuarterRound(ref state[2], ref state[6], ref state[10], ref state[14]);
            QuarterRound(ref state[3], ref state[7], ref state[11], ref state[15]);

            // Even round (diagonal round)
            QuarterRound(ref state[0], ref state[5], ref state[10], ref state[15]);
            QuarterRound(ref state[1], ref state[6], ref state[11], ref state[12]);
            QuarterRound(ref state[2], ref state[7], ref state[8], ref state[13]);
            QuarterRound(ref state[3], ref state[4], ref state[9], ref state[14]);
        }

        // Return first and last rows (words 0-3 and 12-15)
        BinarySpans.WriteUInt32LittleEndian(state.Slice(0, 4), subkey);
        BinarySpans.WriteUInt32LittleEndian(state.Slice(12, 4), subkey.Slice(4 * sizeof(UInt32)));
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// SSE2-accelerated ChaCha20 Transform operating on 4 × <see cref="Vector128{T}"/> rows.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Maps the 4×4 state matrix to four <see cref="Vector128{UInt32}"/> vectors (one per row).
    /// The column round operates on the four rows directly. The diagonal round is implemented
    /// by shuffling rows 1, 2, 3 left by 1, 2, 3 positions respectively, performing the column
    /// round, then unshuffling.
    /// </para>
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void TransformSse2(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter,
                                       ReadOnlySpan<byte> input, Span<byte> output)
    {
        // Load initial state into 4 Vector128<uint> rows
        Vector128<uint> row0 = Vector128.Create(Sigma[0], Sigma[1], Sigma[2], Sigma[3]);
        Vector128<uint> row1 = Vector128.Create(
            BinaryPrimitives.ReadUInt32LittleEndian(key),
            BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(4)),
            BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(8)),
            BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(12)));
        Vector128<uint> row2 = Vector128.Create(
            BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(16)),
            BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(20)),
            BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(24)),
            BinaryPrimitives.ReadUInt32LittleEndian(key.Slice(28)));
        Vector128<uint> row3Base = Vector128.Create(
            counter,
            BinaryPrimitives.ReadUInt32LittleEndian(nonce),
            BinaryPrimitives.ReadUInt32LittleEndian(nonce.Slice(4)),
            BinaryPrimitives.ReadUInt32LittleEndian(nonce.Slice(8)));

        int offset = 0;

        while (offset < input.Length)
        {
            // Working copy (row3 has per-block counter)
            Vector128<uint> row3 = row3Base;
            Vector128<uint> w0 = row0, w1 = row1, w2 = row2, w3 = row3;

            // 10 double-rounds
            for (int i = 0; i < Rounds; i += 2)
            {
                // Column round
                Sse2QuarterRound(ref w0, ref w1, ref w2, ref w3);

                // Diagonal round: rotate rows to align diagonals into columns
                w1 = Sse2.Shuffle(w1, 0b_00_11_10_01); // <<< 1
                w2 = Sse2.Shuffle(w2, 0b_01_00_11_10); // <<< 2
                w3 = Sse2.Shuffle(w3, 0b_10_01_00_11); // <<< 3

                Sse2QuarterRound(ref w0, ref w1, ref w2, ref w3);

                // Un-rotate rows
                w1 = Sse2.Shuffle(w1, 0b_10_01_00_11); // >>> 1
                w2 = Sse2.Shuffle(w2, 0b_01_00_11_10); // >>> 2
                w3 = Sse2.Shuffle(w3, 0b_00_11_10_01); // >>> 3
            }

            // Add original state
            w0 = Sse2.Add(w0, row0);
            w1 = Sse2.Add(w1, row1);
            w2 = Sse2.Add(w2, row2);
            w3 = Sse2.Add(w3, row3);

            int remaining = input.Length - offset;

            if (remaining >= BlockSizeBytes)
            {
                // Full block: XOR keystream with input
                ref byte inRef = ref MemoryMarshal.GetReference(input.Slice(offset));
                ref byte outRef = ref MemoryMarshal.GetReference(output.Slice(offset));

                Vector128<byte> in0 = Vector128.LoadUnsafe(ref inRef);
                Vector128<byte> in1 = Vector128.LoadUnsafe(ref inRef, 16);
                Vector128<byte> in2 = Vector128.LoadUnsafe(ref inRef, 32);
                Vector128<byte> in3 = Vector128.LoadUnsafe(ref inRef, 48);

                Vector128<byte> out0 = Sse2.Xor(in0, w0.AsByte());
                Vector128<byte> out1 = Sse2.Xor(in1, w1.AsByte());
                Vector128<byte> out2 = Sse2.Xor(in2, w2.AsByte());
                Vector128<byte> out3 = Sse2.Xor(in3, w3.AsByte());

                out0.StoreUnsafe(ref outRef);
                out1.StoreUnsafe(ref outRef, 16);
                out2.StoreUnsafe(ref outRef, 32);
                out3.StoreUnsafe(ref outRef, 48);
            }
            else
            {
                // Partial block: serialize to temp buffer, XOR byte-by-byte
                Span<byte> ks = stackalloc byte[BlockSizeBytes];
                w0.AsByte().CopyTo(ks);
                w1.AsByte().CopyTo(ks.Slice(16));
                w2.AsByte().CopyTo(ks.Slice(32));
                w3.AsByte().CopyTo(ks.Slice(48));

                for (int i = 0; i < remaining; i++)
                {
                    output[offset + i] = (byte)(input[offset + i] ^ ks[i]);
                }
            }

            offset += BlockSizeBytes;

            // Increment counter
            row3Base = row3Base.WithElement(0, row3Base.GetElement(0) + 1);
        }
    }

    /// <summary>
    /// SSE2 ChaCha quarter-round on four <see cref="Vector128{UInt32}"/> rows simultaneously.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Sse2QuarterRound(
        ref Vector128<uint> a, ref Vector128<uint> b,
        ref Vector128<uint> c, ref Vector128<uint> d)
    {
        a = Sse2.Add(a, b);
        d = Sse2.Xor(d, a);
        d = Sse2.Or(Sse2.ShiftLeftLogical(d, 16), Sse2.ShiftRightLogical(d, 16));

        c = Sse2.Add(c, d);
        b = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftLeftLogical(b, 12), Sse2.ShiftRightLogical(b, 20));

        a = Sse2.Add(a, b);
        d = Sse2.Xor(d, a);
        d = Sse2.Or(Sse2.ShiftLeftLogical(d, 8), Sse2.ShiftRightLogical(d, 24));

        c = Sse2.Add(c, d);
        b = Sse2.Xor(b, c);
        b = Sse2.Or(Sse2.ShiftLeftLogical(b, 7), Sse2.ShiftRightLogical(b, 25));
    }
#endif
}
