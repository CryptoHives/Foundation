// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

#if NET8_0_OR_GREATER

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

using AesNi = System.Runtime.Intrinsics.X86.Aes;

/// <summary>
/// AES-NI hardware-accelerated AES block cipher operations.
/// </summary>
internal static class AesCoreAesNi
{
    /// <summary>
    /// Gets whether AES-NI hardware acceleration is available on the current platform.
    /// </summary>
    internal static bool IsSupported
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => AesNi.IsSupported;
    }

    /// <summary>
    /// Maximum number of round keys (AES-256: 15 round keys).
    /// </summary>
    internal const int MaxRoundKeys = 15;

    /// <summary>
    /// Expands a cipher key into the AES-NI encryption key schedule.
    /// </summary>
    /// <param name="key">The cipher key (16, 24, or 32 bytes).</param>
    /// <param name="roundKeys">Output buffer for round keys.</param>
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

        if (key.Length == 16)
        {
            ExpandKey128(key, roundKeys);
        }
        else if (key.Length == 24)
        {
            ExpandKey192(key, roundKeys);
        }
        else
        {
            ExpandKey256(key, roundKeys);
        }

        return nr;
    }

    /// <summary>
    /// Creates the AES-NI decryption key schedule from the encryption key schedule.
    /// </summary>
    /// <param name="encRoundKeys">The encryption round keys.</param>
    /// <param name="decRoundKeys">Output buffer for decryption round keys.</param>
    /// <param name="nr">Number of rounds.</param>
    public static void CreateDecryptionKeys(
        ReadOnlySpan<Vector128<byte>> encRoundKeys,
        Span<Vector128<byte>> decRoundKeys,
        int nr)
    {
        // First and last round keys are unchanged
        decRoundKeys[0] = encRoundKeys[nr];
        decRoundKeys[nr] = encRoundKeys[0];

        // Middle round keys need InverseMixColumns
        for (int i = 1; i < nr; i++)
        {
            decRoundKeys[i] = AesNi.InverseMixColumns(encRoundKeys[nr - i]);
        }
    }

    /// <summary>
    /// Encrypts a single 16-byte block using AES-NI instructions.
    /// </summary>
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

        state = Sse2.Xor(state, roundKeys[0]);

        // Unrolled main rounds for each key size
        // AES-NI: Encrypt = nr-1 rounds of AesEncrypt + 1 round of AesEncryptLast
        state = AesNi.Encrypt(state, roundKeys[1]);
        state = AesNi.Encrypt(state, roundKeys[2]);
        state = AesNi.Encrypt(state, roundKeys[3]);
        state = AesNi.Encrypt(state, roundKeys[4]);
        state = AesNi.Encrypt(state, roundKeys[5]);
        state = AesNi.Encrypt(state, roundKeys[6]);
        state = AesNi.Encrypt(state, roundKeys[7]);
        state = AesNi.Encrypt(state, roundKeys[8]);
        state = AesNi.Encrypt(state, roundKeys[9]);

        if (nr > 10)
        {
            state = AesNi.Encrypt(state, roundKeys[10]);
            state = AesNi.Encrypt(state, roundKeys[11]);

            if (nr > 12)
            {
                state = AesNi.Encrypt(state, roundKeys[12]);
                state = AesNi.Encrypt(state, roundKeys[13]);
            }
        }

        state = AesNi.EncryptLast(state, roundKeys[nr]);

        state.CopyTo(output);
    }

    /// <summary>
    /// Decrypts a single 16-byte block using AES-NI instructions.
    /// </summary>
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

        state = Sse2.Xor(state, roundKeys[0]);

        state = AesNi.Decrypt(state, roundKeys[1]);
        state = AesNi.Decrypt(state, roundKeys[2]);
        state = AesNi.Decrypt(state, roundKeys[3]);
        state = AesNi.Decrypt(state, roundKeys[4]);
        state = AesNi.Decrypt(state, roundKeys[5]);
        state = AesNi.Decrypt(state, roundKeys[6]);
        state = AesNi.Decrypt(state, roundKeys[7]);
        state = AesNi.Decrypt(state, roundKeys[8]);
        state = AesNi.Decrypt(state, roundKeys[9]);

        if (nr > 10)
        {
            state = AesNi.Decrypt(state, roundKeys[10]);
            state = AesNi.Decrypt(state, roundKeys[11]);

            if (nr > 12)
            {
                state = AesNi.Decrypt(state, roundKeys[12]);
                state = AesNi.Decrypt(state, roundKeys[13]);
            }
        }

        state = AesNi.DecryptLast(state, roundKeys[nr]);

        state.CopyTo(output);
    }

    // ========================================================================
    // AES-128 Key Expansion (10 rounds, 11 round keys)
    // ========================================================================
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ExpandKey128(ReadOnlySpan<byte> key, Span<Vector128<byte>> roundKeys)
    {
        var k = Vector128.Create(key);
        roundKeys[0] = k;

        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x01));
        roundKeys[1] = k;
        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x02));
        roundKeys[2] = k;
        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x04));
        roundKeys[3] = k;
        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x08));
        roundKeys[4] = k;
        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x10));
        roundKeys[5] = k;
        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x20));
        roundKeys[6] = k;
        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x40));
        roundKeys[7] = k;
        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x80));
        roundKeys[8] = k;
        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x1b));
        roundKeys[9] = k;
        k = KeyExpand128(k, AesNi.KeygenAssist(k, 0x36));
        roundKeys[10] = k;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector128<byte> KeyExpand128(Vector128<byte> key, Vector128<byte> keygen)
    {
        // keygen = [_, _, _, rcon^SubWord(RotWord(W3))]
        keygen = Sse2.Shuffle(keygen.AsInt32(), 0xFF).AsByte(); // broadcast dword 3

        key = Sse2.Xor(key, Sse2.ShiftLeftLogical128BitLane(key, 4));
        key = Sse2.Xor(key, Sse2.ShiftLeftLogical128BitLane(key, 4));
        key = Sse2.Xor(key, Sse2.ShiftLeftLogical128BitLane(key, 4));

        return Sse2.Xor(key, keygen);
    }

    // ========================================================================
    // AES-192 Key Expansion (12 rounds, 13 round keys)
    // ========================================================================

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ExpandKey192(ReadOnlySpan<byte> key, Span<Vector128<byte>> roundKeys)
    {
        var k0 = Vector128.Create(key);

        // Load 8 bytes for the high part of the 192-bit key
        var k1 = Vector128.Create(
            MemoryMarshal.Read<long>(key.Slice(16)),
            0L).AsByte();

        roundKeys[0] = k0;

        KeyExpand192(ref k0, ref k1, AesNi.KeygenAssist(k1, 0x01));
        roundKeys[1] = Sse2.Or(
            Sse2.ShiftRightLogical128BitLane(roundKeys[0], 8).AsInt64().AsByte(),
            Sse2.ShiftLeftLogical128BitLane(k0, 8).AsInt64().AsByte());

        // Use scalar key expansion for 192-bit keys, then load as Vector128
        Span<byte> expanded = stackalloc byte[13 * 16];
        ExpandKey192Flat(key, expanded);
        for (int i = 0; i < 13; i++)
        {
            roundKeys[i] = Vector128.Create(expanded.Slice(i * 16, 16));
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ExpandKey192Flat(ReadOnlySpan<byte> key, Span<byte> expanded)
    {
        // Use scalar key expansion for 192-bit keys, then load as Vector128
        Span<uint> w = stackalloc uint[52];
        AesCore.ExpandKey(key, w);

        // Convert uint[] round keys (big-endian) to byte[] round keys (little-endian, as Vector128 expects)
        for (int i = 0; i < 52; i++)
        {
            // AesCore stores keys in big-endian uint32; AES-NI expects native (little-endian) byte order
            System.Buffers.Binary.BinaryPrimitives.WriteUInt32BigEndian(expanded.Slice(i * 4), w[i]);
        }
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void KeyExpand192(
        ref Vector128<byte> k0, ref Vector128<byte> k1, Vector128<byte> keygen)
    {
        keygen = Sse2.Shuffle(keygen.AsInt32(), 0x55).AsByte(); // broadcast dword 1

        var t = Sse2.ShiftLeftLogical128BitLane(k0, 4);
        k0 = Sse2.Xor(k0, t);
        t = Sse2.ShiftLeftLogical128BitLane(t, 4);
        k0 = Sse2.Xor(k0, t);
        t = Sse2.ShiftLeftLogical128BitLane(t, 4);
        k0 = Sse2.Xor(k0, t);
        k0 = Sse2.Xor(k0, keygen);

        // Expand the 64-bit portion
        keygen = Sse2.Shuffle(k0.AsInt32(), 0xFF).AsByte();
        var t1 = Sse2.ShiftLeftLogical128BitLane(k1, 4);
        k1 = Sse2.Xor(k1, t1);
        k1 = Sse2.Xor(k1, keygen);
    }

    // ========================================================================
    // AES-256 Key Expansion (14 rounds, 15 round keys)
    // ========================================================================

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void ExpandKey256(ReadOnlySpan<byte> key, Span<Vector128<byte>> roundKeys)
    {
        var k0 = Vector128.Create(key);
        var k1 = Vector128.Create(key.Slice(16));

        roundKeys[0] = k0;
        roundKeys[1] = k1;

        k0 = KeyExpand256A(k0, AesNi.KeygenAssist(k1, 0x01));
        roundKeys[2] = k0;
        k1 = KeyExpand256B(k1, k0);
        roundKeys[3] = k1;

        k0 = KeyExpand256A(k0, AesNi.KeygenAssist(k1, 0x02));
        roundKeys[4] = k0;
        k1 = KeyExpand256B(k1, k0);
        roundKeys[5] = k1;

        k0 = KeyExpand256A(k0, AesNi.KeygenAssist(k1, 0x04));
        roundKeys[6] = k0;
        k1 = KeyExpand256B(k1, k0);
        roundKeys[7] = k1;

        k0 = KeyExpand256A(k0, AesNi.KeygenAssist(k1, 0x08));
        roundKeys[8] = k0;
        k1 = KeyExpand256B(k1, k0);
        roundKeys[9] = k1;

        k0 = KeyExpand256A(k0, AesNi.KeygenAssist(k1, 0x10));
        roundKeys[10] = k0;
        k1 = KeyExpand256B(k1, k0);
        roundKeys[11] = k1;

        k0 = KeyExpand256A(k0, AesNi.KeygenAssist(k1, 0x20));
        roundKeys[12] = k0;
        k1 = KeyExpand256B(k1, k0);
        roundKeys[13] = k1;

        k0 = KeyExpand256A(k0, AesNi.KeygenAssist(k1, 0x40));
        roundKeys[14] = k0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector128<byte> KeyExpand256A(Vector128<byte> key, Vector128<byte> keygen)
    {
        keygen = Sse2.Shuffle(keygen.AsInt32(), 0xFF).AsByte(); // broadcast dword 3

        key = Sse2.Xor(key, Sse2.ShiftLeftLogical128BitLane(key, 4));
        key = Sse2.Xor(key, Sse2.ShiftLeftLogical128BitLane(key, 4));
        key = Sse2.Xor(key, Sse2.ShiftLeftLogical128BitLane(key, 4));

        return Sse2.Xor(key, keygen);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector128<byte> KeyExpand256B(Vector128<byte> key, Vector128<byte> prevKey)
    {
        // For AES-256 even round: SubWord without RotWord
        var keygen = AesNi.KeygenAssist(prevKey, 0x00);
        keygen = Sse2.Shuffle(keygen.AsInt32(), 0xAA).AsByte(); // broadcast dword 2 (SubWord result without RotWord)

        key = Sse2.Xor(key, Sse2.ShiftLeftLogical128BitLane(key, 4));
        key = Sse2.Xor(key, Sse2.ShiftLeftLogical128BitLane(key, 4));
        key = Sse2.Xor(key, Sse2.ShiftLeftLogical128BitLane(key, 4));

        return Sse2.Xor(key, keygen);
    }

    /// <summary>
    /// Encrypts 4 blocks simultaneously using interleaved AES-NI instructions.
    /// </summary>
    /// <remarks>
    /// Interleaving exploits the CPU's out-of-order execution to overlap the latency
    /// of AESENC instructions across independent blocks, achieving ~4× throughput
    /// compared to sequential single-block encryption.
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
        var rk = roundKeys[0];
        b0 = Sse2.Xor(b0, rk); b1 = Sse2.Xor(b1, rk);
        b2 = Sse2.Xor(b2, rk); b3 = Sse2.Xor(b3, rk);

        for (int i = 1; i < nr; i++)
        {
            rk = roundKeys[i];
            b0 = AesNi.Encrypt(b0, rk); b1 = AesNi.Encrypt(b1, rk);
            b2 = AesNi.Encrypt(b2, rk); b3 = AesNi.Encrypt(b3, rk);
        }

        rk = roundKeys[nr];
        b0 = AesNi.EncryptLast(b0, rk); b1 = AesNi.EncryptLast(b1, rk);
        b2 = AesNi.EncryptLast(b2, rk); b3 = AesNi.EncryptLast(b3, rk);
    }

    /// <summary>
    /// Encrypts 8 blocks simultaneously using interleaved AES-NI instructions.
    /// </summary>
    /// <remarks>
    /// With AESENC latency=4 and throughput=1 on modern CPUs, 8-block interleaving
    /// fully saturates the AES pipeline, achieving near-theoretical throughput.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void EncryptBlocks8(
        ref Vector128<byte> b0, ref Vector128<byte> b1,
        ref Vector128<byte> b2, ref Vector128<byte> b3,
        ref Vector128<byte> b4, ref Vector128<byte> b5,
        ref Vector128<byte> b6, ref Vector128<byte> b7,
        ReadOnlySpan<Vector128<byte>> roundKeys, int nr)
    {
        var rk = roundKeys[0];
        b0 = Sse2.Xor(b0, rk); b1 = Sse2.Xor(b1, rk);
        b2 = Sse2.Xor(b2, rk); b3 = Sse2.Xor(b3, rk);
        b4 = Sse2.Xor(b4, rk); b5 = Sse2.Xor(b5, rk);
        b6 = Sse2.Xor(b6, rk); b7 = Sse2.Xor(b7, rk);

        for (int i = 1; i < nr; i++)
        {
            rk = roundKeys[i];
            b0 = AesNi.Encrypt(b0, rk); b1 = AesNi.Encrypt(b1, rk);
            b2 = AesNi.Encrypt(b2, rk); b3 = AesNi.Encrypt(b3, rk);
            b4 = AesNi.Encrypt(b4, rk); b5 = AesNi.Encrypt(b5, rk);
            b6 = AesNi.Encrypt(b6, rk); b7 = AesNi.Encrypt(b7, rk);
        }

        rk = roundKeys[nr];
        b0 = AesNi.EncryptLast(b0, rk); b1 = AesNi.EncryptLast(b1, rk);
        b2 = AesNi.EncryptLast(b2, rk); b3 = AesNi.EncryptLast(b3, rk);
        b4 = AesNi.EncryptLast(b4, rk); b5 = AesNi.EncryptLast(b5, rk);
        b6 = AesNi.EncryptLast(b6, rk); b7 = AesNi.EncryptLast(b7, rk);
    }

    /// <summary>
    /// Decrypts 4 blocks simultaneously using interleaved AES-NI instructions.
    /// </summary>
    /// <remarks>
    /// Interleaving exploits the CPU's out-of-order execution to overlap the latency
    /// of AESDEC instructions across independent blocks. Particularly effective for
    /// CBC decrypt where all ciphertext blocks are available upfront.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void DecryptBlocks4(
        ref Vector128<byte> b0, ref Vector128<byte> b1,
        ref Vector128<byte> b2, ref Vector128<byte> b3,
        ReadOnlySpan<Vector128<byte>> roundKeys, int nr)
    {
        var rk = roundKeys[0];
        b0 = Sse2.Xor(b0, rk); b1 = Sse2.Xor(b1, rk);
        b2 = Sse2.Xor(b2, rk); b3 = Sse2.Xor(b3, rk);

        for (int i = 1; i < nr; i++)
        {
            rk = roundKeys[i];
            b0 = AesNi.Decrypt(b0, rk); b1 = AesNi.Decrypt(b1, rk);
            b2 = AesNi.Decrypt(b2, rk); b3 = AesNi.Decrypt(b3, rk);
        }

        rk = roundKeys[nr];
        b0 = AesNi.DecryptLast(b0, rk); b1 = AesNi.DecryptLast(b1, rk);
        b2 = AesNi.DecryptLast(b2, rk); b3 = AesNi.DecryptLast(b3, rk);
    }

    /// <summary>
    /// Decrypts 8 blocks simultaneously using interleaved AES-NI instructions.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public static void DecryptBlocks8(
        ref Vector128<byte> b0, ref Vector128<byte> b1,
        ref Vector128<byte> b2, ref Vector128<byte> b3,
        ref Vector128<byte> b4, ref Vector128<byte> b5,
        ref Vector128<byte> b6, ref Vector128<byte> b7,
        ReadOnlySpan<Vector128<byte>> roundKeys, int nr)
    {
        var rk = roundKeys[0];
        b0 = Sse2.Xor(b0, rk); b1 = Sse2.Xor(b1, rk);
        b2 = Sse2.Xor(b2, rk); b3 = Sse2.Xor(b3, rk);
        b4 = Sse2.Xor(b4, rk); b5 = Sse2.Xor(b5, rk);
        b6 = Sse2.Xor(b6, rk); b7 = Sse2.Xor(b7, rk);

        for (int i = 1; i < nr; i++)
        {
            rk = roundKeys[i];
            b0 = AesNi.Decrypt(b0, rk); b1 = AesNi.Decrypt(b1, rk);
            b2 = AesNi.Decrypt(b2, rk); b3 = AesNi.Decrypt(b3, rk);
            b4 = AesNi.Decrypt(b4, rk); b5 = AesNi.Decrypt(b5, rk);
            b6 = AesNi.Decrypt(b6, rk); b7 = AesNi.Decrypt(b7, rk);
        }

        rk = roundKeys[nr];
        b0 = AesNi.DecryptLast(b0, rk); b1 = AesNi.DecryptLast(b1, rk);
        b2 = AesNi.DecryptLast(b2, rk); b3 = AesNi.DecryptLast(b3, rk);
        b4 = AesNi.DecryptLast(b4, rk); b5 = AesNi.DecryptLast(b5, rk);
        b6 = AesNi.DecryptLast(b6, rk); b7 = AesNi.DecryptLast(b7, rk);
    }
}

#endif
