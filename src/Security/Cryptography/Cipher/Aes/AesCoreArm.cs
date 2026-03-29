// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

#if NET8_0_OR_GREATER

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;

using ArmAes = System.Runtime.Intrinsics.Arm.Aes;

/// <summary>
/// ARM AES cryptographic extension hardware-accelerated AES block cipher operations.
/// </summary>
/// <remarks>
/// <para>
/// Provides AES encryption/decryption using ARM AESE/AESD/AESMC/AESIMC instructions.
/// The ARM AES instructions differ from x86 AES-NI in operation ordering:
/// AESE performs XOR → SubBytes → ShiftRows (key XOR first), while
/// AES-NI AESENC performs SubBytes → ShiftRows → MixColumns → XOR (key XOR last).
/// Despite this difference, the same key schedule is used.
/// </para>
/// <para>
/// Key expansion uses the scalar <see cref="AesCore.ExpandKey"/> implementation, repacked
/// as <see cref="Vector128{T}"/> for the ARM instructions. This is acceptable because key
/// expansion is a one-time operation and not performance-critical.
/// </para>
/// </remarks>
internal static class AesCoreArm
{
    /// <summary>
    /// Gets whether ARM AES hardware acceleration is available on the current platform.
    /// </summary>
    internal static bool IsSupported
    {
        get => ArmAes.IsSupported;
    }

    /// <summary>
    /// Expands a cipher key into the ARM AES encryption key schedule.
    /// </summary>
    /// <param name="key">The cipher key (16, 24, or 32 bytes).</param>
    /// <param name="roundKeys">Output buffer for round keys as <see cref="Vector128{T}"/>.</param>
    /// <returns>The number of rounds (10, 12, or 14).</returns>
    public static int ExpandKey(ReadOnlySpan<byte> key, Span<Vector128<byte>> roundKeys)
    {
        int nr = key.Length switch
        {
            16 => 10,
            24 => 12,
            32 => 14,
            _ => throw new ArgumentException("Key must be 16, 24, or 32 bytes.", nameof(key))
        };

        // Use scalar key expansion, then repack as Vector128<byte>.
        // AesCore stores round keys as big-endian uint32 words; ARM instructions
        // expect native byte order, so we write big-endian to match the existing layout.
        int totalWords = 4 * (key.Length / 4 + 7);
        Span<uint> scalarKeys = stackalloc uint[totalWords];
        AesCore.ExpandKey(key, scalarKeys);

        Span<byte> temp = stackalloc byte[16];
        for (int i = 0; i <= nr; i++)
        {
            BinaryPrimitives.WriteUInt32BigEndian(temp, scalarKeys[i * 4]);
            BinaryPrimitives.WriteUInt32BigEndian(temp.Slice(4), scalarKeys[i * 4 + 1]);
            BinaryPrimitives.WriteUInt32BigEndian(temp.Slice(8), scalarKeys[i * 4 + 2]);
            BinaryPrimitives.WriteUInt32BigEndian(temp.Slice(12), scalarKeys[i * 4 + 3]);
            roundKeys[i] = Vector128.Create(temp);
        }

        return nr;
    }

    /// <summary>
    /// Creates the ARM AES decryption key schedule from the encryption key schedule.
    /// </summary>
    /// <param name="encRoundKeys">The encryption round keys.</param>
    /// <param name="decRoundKeys">Output buffer for decryption round keys.</param>
    /// <param name="nr">Number of rounds.</param>
    public static void CreateDecryptionKeys(
        ReadOnlySpan<Vector128<byte>> encRoundKeys,
        Span<Vector128<byte>> decRoundKeys,
        int nr)
    {
        // First and last round keys are unchanged (reversed)
        decRoundKeys[0] = encRoundKeys[nr];
        decRoundKeys[nr] = encRoundKeys[0];

        // Middle round keys need InverseMixColumns
        for (int i = 1; i < nr; i++)
        {
            decRoundKeys[i] = ArmAes.InverseMixColumns(encRoundKeys[nr - i]);
        }
    }

    /// <summary>
    /// Encrypts a single 16-byte block using ARM AES instructions.
    /// </summary>
    /// <remarks>
    /// ARM AESE performs XOR → SubBytes → ShiftRows per round, followed by a separate
    /// AESMC (MixColumns). The last round omits MixColumns and applies a final key XOR.
    /// </remarks>
    /// <param name="input">The 16-byte plaintext block.</param>
    /// <param name="output">The 16-byte ciphertext output.</param>
    /// <param name="roundKeys">The expanded encryption key schedule.</param>
    /// <param name="nr">Number of rounds (10, 12, or 14).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void EncryptBlock(
        ReadOnlySpan<byte> input, Span<byte> output,
        ReadOnlySpan<Vector128<byte>> roundKeys, int nr)
    {
        var state = Vector128.Create(input);

        // Unrolled intermediate rounds: AESE (XOR + SubBytes + ShiftRows) + AESMC (MixColumns)
        state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[0]));
        state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[1]));
        state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[2]));
        state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[3]));
        state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[4]));
        state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[5]));
        state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[6]));
        state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[7]));
        state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[8]));

        if (nr > 10)
        {
            state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[9]));
            state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[10]));

            if (nr > 12)
            {
                state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[11]));
                state = ArmAes.MixColumns(ArmAes.Encrypt(state, roundKeys[12]));
            }
        }

        // Last round: AESE without MixColumns, then XOR final key
        state = ArmAes.Encrypt(state, roundKeys[nr - 1]);
        state ^= roundKeys[nr];

        state.CopyTo(output);
    }

    /// <summary>
    /// Decrypts a single 16-byte block using ARM AES instructions.
    /// </summary>
    /// <remarks>
    /// ARM AESD performs XOR → InvSubBytes → InvShiftRows per round, followed by
    /// AESIMC (InvMixColumns). The last round omits InvMixColumns and applies a final key XOR.
    /// </remarks>
    /// <param name="input">The 16-byte ciphertext block.</param>
    /// <param name="output">The 16-byte plaintext output.</param>
    /// <param name="roundKeys">The expanded decryption key schedule (with InverseMixColumns applied).</param>
    /// <param name="nr">Number of rounds (10, 12, or 14).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void DecryptBlock(
        ReadOnlySpan<byte> input, Span<byte> output,
        ReadOnlySpan<Vector128<byte>> roundKeys, int nr)
    {
        var state = Vector128.Create(input);

        // Unrolled intermediate rounds: AESD (XOR + InvSubBytes + InvShiftRows) + AESIMC (InvMixColumns)
        state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[0]));
        state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[1]));
        state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[2]));
        state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[3]));
        state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[4]));
        state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[5]));
        state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[6]));
        state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[7]));
        state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[8]));

        if (nr > 10)
        {
            state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[9]));
            state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[10]));

            if (nr > 12)
            {
                state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[11]));
                state = ArmAes.InverseMixColumns(ArmAes.Decrypt(state, roundKeys[12]));
            }
        }

        // Last round: AESD without InverseMixColumns, then XOR final key
        state = ArmAes.Decrypt(state, roundKeys[nr - 1]);
        state ^= roundKeys[nr];

        state.CopyTo(output);
    }

    /// <summary>
    /// Encrypts 4 blocks simultaneously using interleaved ARM AES instructions.
    /// </summary>
    /// <remarks>
    /// Interleaving exploits the CPU's out-of-order execution to overlap the latency
    /// of AESE/AESMC instructions across independent blocks.
    /// </remarks>
    /// <param name="b0">First block (modified in place with ciphertext).</param>
    /// <param name="b1">Second block (modified in place with ciphertext).</param>
    /// <param name="b2">Third block (modified in place with ciphertext).</param>
    /// <param name="b3">Fourth block (modified in place with ciphertext).</param>
    /// <param name="roundKeys">The expanded encryption key schedule.</param>
    /// <param name="nr">Number of rounds (10, 12, or 14).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void EncryptBlocks4(
        ref Vector128<byte> b0, ref Vector128<byte> b1,
        ref Vector128<byte> b2, ref Vector128<byte> b3,
        ReadOnlySpan<Vector128<byte>> roundKeys, int nr)
    {
        for (int i = 0; i < nr - 1; i++)
        {
            var rk = roundKeys[i];
            b0 = ArmAes.MixColumns(ArmAes.Encrypt(b0, rk));
            b1 = ArmAes.MixColumns(ArmAes.Encrypt(b1, rk));
            b2 = ArmAes.MixColumns(ArmAes.Encrypt(b2, rk));
            b3 = ArmAes.MixColumns(ArmAes.Encrypt(b3, rk));
        }

        var rkLast = roundKeys[nr - 1];
        var rkFinal = roundKeys[nr];
        b0 = ArmAes.Encrypt(b0, rkLast) ^ rkFinal;
        b1 = ArmAes.Encrypt(b1, rkLast) ^ rkFinal;
        b2 = ArmAes.Encrypt(b2, rkLast) ^ rkFinal;
        b3 = ArmAes.Encrypt(b3, rkLast) ^ rkFinal;
    }

    /// <summary>
    /// Encrypts 8 blocks simultaneously using interleaved ARM AES instructions.
    /// </summary>
    /// <remarks>
    /// On ARM cores with dual AES pipelines (e.g., Apple M-series, Cortex-X),
    /// 8-block interleaving can fully saturate the execution units.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void EncryptBlocks8(
        ref Vector128<byte> b0, ref Vector128<byte> b1,
        ref Vector128<byte> b2, ref Vector128<byte> b3,
        ref Vector128<byte> b4, ref Vector128<byte> b5,
        ref Vector128<byte> b6, ref Vector128<byte> b7,
        ReadOnlySpan<Vector128<byte>> roundKeys, int nr)
    {
        for (int i = 0; i < nr - 1; i++)
        {
            var rk = roundKeys[i];
            b0 = ArmAes.MixColumns(ArmAes.Encrypt(b0, rk));
            b1 = ArmAes.MixColumns(ArmAes.Encrypt(b1, rk));
            b2 = ArmAes.MixColumns(ArmAes.Encrypt(b2, rk));
            b3 = ArmAes.MixColumns(ArmAes.Encrypt(b3, rk));
            b4 = ArmAes.MixColumns(ArmAes.Encrypt(b4, rk));
            b5 = ArmAes.MixColumns(ArmAes.Encrypt(b5, rk));
            b6 = ArmAes.MixColumns(ArmAes.Encrypt(b6, rk));
            b7 = ArmAes.MixColumns(ArmAes.Encrypt(b7, rk));
        }

        var rkLast = roundKeys[nr - 1];
        var rkFinal = roundKeys[nr];
        b0 = ArmAes.Encrypt(b0, rkLast) ^ rkFinal;
        b1 = ArmAes.Encrypt(b1, rkLast) ^ rkFinal;
        b2 = ArmAes.Encrypt(b2, rkLast) ^ rkFinal;
        b3 = ArmAes.Encrypt(b3, rkLast) ^ rkFinal;
        b4 = ArmAes.Encrypt(b4, rkLast) ^ rkFinal;
        b5 = ArmAes.Encrypt(b5, rkLast) ^ rkFinal;
        b6 = ArmAes.Encrypt(b6, rkLast) ^ rkFinal;
        b7 = ArmAes.Encrypt(b7, rkLast) ^ rkFinal;
    }

    /// <summary>
    /// Decrypts 4 blocks simultaneously using interleaved ARM AES instructions.
    /// </summary>
    /// <remarks>
    /// Interleaving exploits the CPU's out-of-order execution to overlap the latency
    /// of AESD/AESIMC instructions across independent blocks. Particularly effective for
    /// CBC decrypt where all ciphertext blocks are available upfront.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void DecryptBlocks4(
        ref Vector128<byte> b0, ref Vector128<byte> b1,
        ref Vector128<byte> b2, ref Vector128<byte> b3,
        ReadOnlySpan<Vector128<byte>> roundKeys, int nr)
    {
        for (int i = 0; i < nr - 1; i++)
        {
            var rk = roundKeys[i];
            b0 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b0, rk));
            b1 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b1, rk));
            b2 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b2, rk));
            b3 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b3, rk));
        }

        var rkLast = roundKeys[nr - 1];
        var rkFinal = roundKeys[nr];
        b0 = ArmAes.Decrypt(b0, rkLast) ^ rkFinal;
        b1 = ArmAes.Decrypt(b1, rkLast) ^ rkFinal;
        b2 = ArmAes.Decrypt(b2, rkLast) ^ rkFinal;
        b3 = ArmAes.Decrypt(b3, rkLast) ^ rkFinal;
    }

    /// <summary>
    /// Decrypts 8 blocks simultaneously using interleaved ARM AES instructions.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void DecryptBlocks8(
        ref Vector128<byte> b0, ref Vector128<byte> b1,
        ref Vector128<byte> b2, ref Vector128<byte> b3,
        ref Vector128<byte> b4, ref Vector128<byte> b5,
        ref Vector128<byte> b6, ref Vector128<byte> b7,
        ReadOnlySpan<Vector128<byte>> roundKeys, int nr)
    {
        for (int i = 0; i < nr - 1; i++)
        {
            var rk = roundKeys[i];
            b0 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b0, rk));
            b1 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b1, rk));
            b2 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b2, rk));
            b3 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b3, rk));
            b4 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b4, rk));
            b5 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b5, rk));
            b6 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b6, rk));
            b7 = ArmAes.InverseMixColumns(ArmAes.Decrypt(b7, rk));
        }

        var rkLast = roundKeys[nr - 1];
        var rkFinal = roundKeys[nr];
        b0 = ArmAes.Decrypt(b0, rkLast) ^ rkFinal;
        b1 = ArmAes.Decrypt(b1, rkLast) ^ rkFinal;
        b2 = ArmAes.Decrypt(b2, rkLast) ^ rkFinal;
        b3 = ArmAes.Decrypt(b3, rkLast) ^ rkFinal;
        b4 = ArmAes.Decrypt(b4, rkLast) ^ rkFinal;
        b5 = ArmAes.Decrypt(b5, rkLast) ^ rkFinal;
        b6 = ArmAes.Decrypt(b6, rkLast) ^ rkFinal;
        b7 = ArmAes.Decrypt(b7, rkLast) ^ rkFinal;
    }
}

#endif
