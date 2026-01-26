// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;

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
    /// Generates a 64-byte keystream block.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 12-byte nonce.</param>
    /// <param name="counter">The 32-bit block counter.</param>
    /// <param name="output">The 64-byte output buffer for the keystream.</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
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
            uint result = workingState[i] + state[i];
            StoreLittleEndian(output, i * 4, result);
        }
    }

    /// <summary>
    /// Encrypts or decrypts data using ChaCha20.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 12-byte nonce.</param>
    /// <param name="counter">The initial block counter.</param>
    /// <param name="input">The input data.</param>
    /// <param name="output">The output buffer (must be same size as input).</param>
    public static void Transform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter,
                                  ReadOnlySpan<byte> input, Span<byte> output)
    {
        Span<byte> keystream = stackalloc byte[BlockSizeBytes];
        int offset = 0;

        while (offset < input.Length)
        {
            // Generate keystream block
            Block(key, nonce, counter, keystream);
            counter++;

            // XOR input with keystream
            int remaining = input.Length - offset;
            int bytesToProcess = Math.Min(remaining, BlockSizeBytes);

            for (int i = 0; i < bytesToProcess; i++)
            {
                output[offset + i] = (byte)(input[offset + i] ^ keystream[i]);
            }

            offset += bytesToProcess;
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void InitializeState(ReadOnlySpan<byte> key, ReadOnlySpan<byte> nonce, uint counter, Span<uint> state)
    {
        // Constants (words 0-3)
        state[0] = Sigma[0];
        state[1] = Sigma[1];
        state[2] = Sigma[2];
        state[3] = Sigma[3];

        // Key (words 4-11)
        state[4] = LoadLittleEndian(key, 0);
        state[5] = LoadLittleEndian(key, 4);
        state[6] = LoadLittleEndian(key, 8);
        state[7] = LoadLittleEndian(key, 12);
        state[8] = LoadLittleEndian(key, 16);
        state[9] = LoadLittleEndian(key, 20);
        state[10] = LoadLittleEndian(key, 24);
        state[11] = LoadLittleEndian(key, 28);

        // Counter (word 12)
        state[12] = counter;

        // Nonce (words 13-15)
        state[13] = LoadLittleEndian(nonce, 0);
        state[14] = LoadLittleEndian(nonce, 4);
        state[15] = LoadLittleEndian(nonce, 8);
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
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void QuarterRound(ref uint a, ref uint b, ref uint c, ref uint d)
    {
        a += b; d ^= a; d = RotateLeft(d, 16);
        c += d; b ^= c; b = RotateLeft(b, 12);
        a += b; d ^= a; d = RotateLeft(d, 8);
        c += d; b ^= c; b = RotateLeft(b, 7);
    }

    /// <summary>
    /// Rotates a 32-bit value left by the specified number of bits.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint RotateLeft(uint value, int offset)
    {
        return (value << offset) | (value >> (32 - offset));
    }

    /// <summary>
    /// Loads a 32-bit little-endian value from a byte span.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint LoadLittleEndian(ReadOnlySpan<byte> data, int offset)
    {
        return (uint)data[offset] |
               ((uint)data[offset + 1] << 8) |
               ((uint)data[offset + 2] << 16) |
               ((uint)data[offset + 3] << 24);
    }

    /// <summary>
    /// Stores a 32-bit little-endian value to a byte span.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void StoreLittleEndian(Span<byte> data, int offset, uint value)
    {
        data[offset] = (byte)value;
        data[offset + 1] = (byte)(value >> 8);
        data[offset + 2] = (byte)(value >> 16);
        data[offset + 3] = (byte)(value >> 24);
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
        state[4] = LoadLittleEndian(key, 0);
        state[5] = LoadLittleEndian(key, 4);
        state[6] = LoadLittleEndian(key, 8);
        state[7] = LoadLittleEndian(key, 12);
        state[8] = LoadLittleEndian(key, 16);
        state[9] = LoadLittleEndian(key, 20);
        state[10] = LoadLittleEndian(key, 24);
        state[11] = LoadLittleEndian(key, 28);

        // Nonce (words 12-15, instead of counter + nonce)
        state[12] = LoadLittleEndian(nonce, 0);
        state[13] = LoadLittleEndian(nonce, 4);
        state[14] = LoadLittleEndian(nonce, 8);
        state[15] = LoadLittleEndian(nonce, 12);

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
        StoreLittleEndian(subkey, 0, state[0]);
        StoreLittleEndian(subkey, 4, state[1]);
        StoreLittleEndian(subkey, 8, state[2]);
        StoreLittleEndian(subkey, 12, state[3]);
        StoreLittleEndian(subkey, 16, state[12]);
        StoreLittleEndian(subkey, 20, state[13]);
        StoreLittleEndian(subkey, 24, state[14]);
        StoreLittleEndian(subkey, 28, state[15]);
    }
}
