// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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
internal partial struct ChaChaCore
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
    /// The SimD instruction sets to use for this instance.
    /// </summary>
    private readonly SimdSupport _simdSupport;

    /// <summary>
    /// Initializes a new instance of the ChaChaCore class with the specified SIMD support settings.
    /// </summary>
    public ChaChaCore(SimdSupport simdSupport = SimdSupport.All)
    {
        _simdSupport = simdSupport & SimdSupport;
    }

    /// <summary>
    /// Generates a 64-byte keystream block.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 12-byte nonce.</param>
    /// <param name="counter">The 32-bit block counter.</param>
    /// <param name="output">The 64-byte output buffer for the keystream.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void Block(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter, Span<byte> output)
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
    /// Encrypts or decrypts data using ChaCha20 with forced SIMD support level.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 12-byte nonce.</param>
    /// <param name="counter">The initial block counter.</param>
    /// <param name="input">The input data.</param>
    /// <param name="output">The output buffer (must be same size as input).</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void Transform(
        ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter,
        ReadOnlySpan<byte> input, Span<byte> output)
    {
#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.Ssse3) != 0)
        {
            TransformSsse3(key, nonce, counter, input, output);
            return;
        }
#endif
        TransformScalar(key, nonce, counter, input, output);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void TransformScalar(
        ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter,
        ReadOnlySpan<byte> input, Span<byte> output)
    {
        Span<uint> state = stackalloc uint[StateWords];
        Span<uint> workingState = stackalloc uint[StateWords];

        // Initialize base state once (counter updated per block)
        InitializeState(key, nonce, counter, state);

        int offset = 0;
        Span<byte> ks = stackalloc byte[BlockSizeBytes];
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
        Sigma.AsSpan().CopyTo(state);

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
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public void HChaCha20(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, Span<byte> subkey)
    {
        if (key.Length != KeySizeBytes)
            throw new ArgumentException($"Key must be {KeySizeBytes} bytes.", nameof(key));
        if (nonce.Length != HNonceSizeBytes)
            throw new ArgumentException($"Nonce must be {HNonceSizeBytes} bytes.", nameof(nonce));
        if (subkey.Length < KeySizeBytes)
            throw new ArgumentException($"Subkey buffer must be at least {KeySizeBytes} bytes.", nameof(subkey));

        Span<uint> state = stackalloc uint[StateWords];

        // Initialize state (no counter, nonce is 16 bytes)
        Sigma.AsSpan().CopyTo(state);

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
}
