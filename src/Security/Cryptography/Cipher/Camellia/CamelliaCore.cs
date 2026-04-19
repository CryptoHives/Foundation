// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Core Camellia block cipher operations shared by all key sizes.
/// </summary>
/// <remarks>
/// <para>
/// Implements the Camellia block cipher as specified in RFC 3713 and ISO/IEC 18033-3.
/// Camellia is a 128-bit block cipher supporting 128-, 192-, and 256-bit keys.
/// It uses an 18-round Feistel network for 128-bit keys and a 24-round Feistel
/// network for 192- and 256-bit keys, with FL/FL⁻¹ key-dependent functions
/// inserted every 6 rounds.
/// </para>
/// <para>
/// <b>Implementation notes:</b>
/// <list type="bullet">
///   <item><description>
///     The F-function is accelerated with 8 precomputed 256-entry SP-box tables
///     (16 KB total). Each entry folds an S-box lookup together with that byte
///     position's column of the P-function into a single 64-bit value, reducing
///     per-round work to 8 table lookups and 7 XOR operations.
///   </description></item>
/// </list>
/// </para>
/// </remarks>
internal static class CamelliaCore
{
    /// <summary>
    /// Camellia block size in bytes (always 16).
    /// </summary>
    public const int BlockSizeBytes = 16;

    /// <summary>
    /// Camellia block size in bits.
    /// </summary>
    public const int BlockSizeBits = 128;

    /// <summary>
    /// Maximum number of subkeys for any key size (256-bit: 34).
    /// </summary>
    public const int MaxSubkeys = 34;

    /// <summary>
    /// Number of subkeys for a 128-bit key.
    /// </summary>
    public const int Subkeys128 = 26;

    private const ulong Sigma1 = 0xA09E667F3BCC908B;
    private const ulong Sigma2 = 0xB67AE8584CAA73B2;
    private const ulong Sigma3 = 0xC6EF372FE94F82BE;
    private const ulong Sigma4 = 0x54FF53A5F1D36F1C;
    private const ulong Sigma5 = 0x10E527FADE682D1D;
    private const ulong Sigma6 = 0xB05688C2B3E6C1FD;

    // ========================================================================
    // SP-box tables for the F-function
    // ========================================================================
    //
    // Each of the 8 tables has 256 ulong entries. Entry SP_n[b] combines:
    //   - the S-box applied to the raw input byte b for position n, and
    //   - the P-function column contribution for that position.
    //
    // The P-function from RFC 3713 defines which of y1..y8 each t_n feeds:
    //   t1 (SBOX1): y1,y2,y3,y5,y8     → shifts 56,48,40,24, 0
    //   t2 (SBOX2): y2,y3,y4,y5,y6     → shifts 48,40,32,24,16
    //   t3 (SBOX3): y1,y3,y4,y6,y7     → shifts 56,40,32,16, 8
    //   t4 (SBOX4): y1,y2,y4,y7,y8     → shifts 56,48,32, 8, 0
    //   t5 (SBOX2): y2,y3,y4,y6,y7,y8  → shifts 48,40,32,16, 8, 0
    //   t6 (SBOX3): y1,y3,y4,y5,y7,y8  → shifts 56,40,32,24, 8, 0
    //   t7 (SBOX4): y1,y2,y4,y5,y6,y8  → shifts 56,48,32,24,16, 0
    //   t8 (SBOX1): y1,y2,y3,y5,y6,y7  → shifts 56,48,40,24,16, 8
    //
    // S-box variants (RFC 3713, Section 2.4.1):
    //   SBOX1[b] = sbox1[b]
    //   SBOX2[b] = RotL8(sbox1[b], 1)
    //   SBOX3[b] = RotL8(sbox1[b], 7)
    //   SBOX4[b] = sbox1[RotL8(b, 1)]

    private static readonly ulong[] _sp1;
    private static readonly ulong[] _sp2;
    private static readonly ulong[] _sp3;
    private static readonly ulong[] _sp4;
    private static readonly ulong[] _sp5;
    private static readonly ulong[] _sp6;
    private static readonly ulong[] _sp7;
    private static readonly ulong[] _sp8;

    [SuppressMessage("Performance", "CA1810:Initialize reference type static fields inline", Justification = "All 8 SP tables share a single 256-iteration initialization loop for efficiency.")]
    static CamelliaCore()
    {
        _sp1 = new ulong[256];
        _sp2 = new ulong[256];
        _sp3 = new ulong[256];
        _sp4 = new ulong[256];
        _sp5 = new ulong[256];
        _sp6 = new ulong[256];
        _sp7 = new ulong[256];
        _sp8 = new ulong[256];

        ReadOnlySpan<byte> sbox1 =
        [
            112, 130,  44, 236, 179,  39, 192, 229, 228, 133,  87,  53, 234,  12, 174,  65,
             35, 239, 107, 147,  69,  25, 165,  33, 237,  14,  79,  78,  29, 101, 146, 189,
            134, 184, 175, 143, 124, 235,  31, 206,  62,  48, 220,  95,  94, 197,  11,  26,
            166, 225,  57, 202, 213,  71,  93,  61, 217,   1,  90, 214,  81,  86, 108,  77,
            139,  13, 154, 102, 251, 204, 176,  45, 116,  18,  43,  32, 240, 177, 132, 153,
            223,  76, 203, 194,  52, 126, 118,   5, 109, 183, 169,  49, 209,  23,   4, 215,
             20,  88,  58,  97, 222,  27,  17,  28,  50,  15, 156,  22,  83,  24, 242,  34,
            254,  68, 207, 178, 195, 181, 122, 145,  36,   8, 232, 168,  96, 252, 105,  80,
            170, 208, 160, 125, 161, 137,  98, 151,  84,  91,  30, 149, 224, 255, 100, 210,
             16, 196,   0,  72, 163, 247, 117, 219, 138,   3, 230, 218,   9,  63, 221, 148,
            135,  92, 131,   2, 205,  74, 144,  51, 115, 103, 246, 243, 157, 127, 191, 226,
             82, 155, 216,  38, 200,  55, 198,  59, 129, 150, 111,  75,  19, 190,  99,  46,
            233, 121, 167, 140, 159, 110, 188, 142,  41, 245, 249, 182,  47, 253, 180,  89,
            120, 152,   6, 106, 231,  70, 113, 186, 212,  37, 171,  66, 136, 162, 141, 250,
            114,   7, 185,  85, 248, 238, 172,  10,  54,  73,  42, 104,  60,  56, 241, 164,
             64,  40, 211, 123, 187, 201,  67, 193,  21, 227, 173, 244, 119, 199, 128, 158,
        ];

        for (int i = 0; i < 256; i++)
        {
            ulong s1 = sbox1[i];
            ulong s2 = (ulong)((s1 << 1) | (s1 >> 7)) & 0xFF;   // RotL8(s1, 1)
            ulong s3 = (ulong)((s1 << 7) | (s1 >> 1)) & 0xFF;   // RotL8(s1, 7)
            ulong s4 = sbox1[(byte)((i << 1) | (i >> 7))];       // SBOX4: sbox1[RotL8(i,1)]

            _sp1[i] = (s1 << 56) | (s1 << 48) | (s1 << 40) | (s1 << 24) | s1;
            _sp2[i] = (s2 << 48) | (s2 << 40) | (s2 << 32) | (s2 << 24) | (s2 << 16);
            _sp3[i] = (s3 << 56) | (s3 << 40) | (s3 << 32) | (s3 << 16) | (s3 << 8);
            _sp4[i] = (s4 << 56) | (s4 << 48) | (s4 << 32) | (s4 << 8)  | s4;
            _sp5[i] = (s2 << 48) | (s2 << 40) | (s2 << 32) | (s2 << 16) | (s2 << 8) | s2;
            _sp6[i] = (s3 << 56) | (s3 << 40) | (s3 << 32) | (s3 << 24) | (s3 << 8) | s3;
            _sp7[i] = (s4 << 56) | (s4 << 48) | (s4 << 32) | (s4 << 24) | (s4 << 16) | s4;
            _sp8[i] = (s1 << 56) | (s1 << 48) | (s1 << 40) | (s1 << 24) | (s1 << 16) | (s1 << 8);
        }
    }

    /// <summary>
    /// Expands a cipher key into the subkey array used by encrypt/decrypt.
    /// </summary>
    /// <param name="key">The cipher key (16, 24, or 32 bytes).</param>
    /// <param name="subkeys">
    /// The output subkey buffer. Must be at least <see cref="MaxSubkeys"/> elements.
    /// </param>
    /// <returns>The number of rounds (18 for 128-bit keys, 24 for 192/256-bit keys).</returns>
    /// <exception cref="ArgumentException">The key length is invalid.</exception>
    public static int ExpandKey(ReadOnlySpan<byte> key, Span<ulong> subkeys)
    {
        if (key.Length != 16 && key.Length != 24 && key.Length != 32)
            throw new ArgumentException("Key must be 16, 24, or 32 bytes.", nameof(key));

        ulong klh = BinaryPrimitives.ReadUInt64BigEndian(key);
        ulong kll = BinaryPrimitives.ReadUInt64BigEndian(key.Slice(8));
        ulong krh, krl;

        if (key.Length == 16)
        {
            krh = 0;
            krl = 0;
        }
        else if (key.Length == 24)
        {
            krh = BinaryPrimitives.ReadUInt64BigEndian(key.Slice(16));
            krl = ~krh;
        }
        else
        {
            krh = BinaryPrimitives.ReadUInt64BigEndian(key.Slice(16));
            krl = BinaryPrimitives.ReadUInt64BigEndian(key.Slice(24));
        }

        // Generate KA from KL and KR
        ulong d1 = klh ^ krh;
        ulong d2 = kll ^ krl;
        d2 ^= F(d1, Sigma1);
        d1 ^= F(d2, Sigma2);
        d1 ^= klh;
        d2 ^= kll;
        d2 ^= F(d1, Sigma3);
        d1 ^= F(d2, Sigma4);
        ulong kah = d1;
        ulong kal = d2;

        // Generate KB from KA and KR (used only for 192/256-bit keys)
        d1 = kah ^ krh;
        d2 = kal ^ krl;
        d2 ^= F(d1, Sigma5);
        d1 ^= F(d2, Sigma6);
        ulong kbh = d1;
        ulong kbl = d2;

        if (key.Length == 16)
        {
            return ExpandKey128(klh, kll, kah, kal, subkeys);
        }

        return ExpandKey256(klh, kll, krh, krl, kah, kal, kbh, kbl, subkeys);
    }

    /// <summary>
    /// Encrypts a single 16-byte block using the Camellia cipher.
    /// </summary>
    /// <param name="input">The 16-byte plaintext block.</param>
    /// <param name="output">The 16-byte ciphertext output.</param>
    /// <param name="subkeys">The expanded encryption subkeys.</param>
    /// <param name="rounds">The number of rounds (18 or 24).</param>
    public static void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output,
        ReadOnlySpan<ulong> subkeys, int rounds)
    {
        ulong d1 = BinaryPrimitives.ReadUInt64BigEndian(input);
        ulong d2 = BinaryPrimitives.ReadUInt64BigEndian(input.Slice(8));
        EncryptBlock(d1, d2, out ulong r1, out ulong r2, subkeys, rounds);
        BinaryPrimitives.WriteUInt64BigEndian(output, r1);
        BinaryPrimitives.WriteUInt64BigEndian(output.Slice(8), r2);
    }

    /// <summary>
    /// Encrypts a block supplied as two 64-bit halves, producing two 64-bit halves.
    /// </summary>
    /// <param name="d1">High 64 bits of plaintext (big-endian byte order).</param>
    /// <param name="d2">Low 64 bits of plaintext (big-endian byte order).</param>
    /// <param name="r1">High 64 bits of ciphertext (big-endian byte order).</param>
    /// <param name="r2">Low 64 bits of ciphertext (big-endian byte order).</param>
    /// <param name="subkeys">The expanded encryption subkeys.</param>
    /// <param name="rounds">The number of rounds (18 or 24).</param>
    internal static void EncryptBlock(ulong d1, ulong d2, out ulong r1, out ulong r2,
        ReadOnlySpan<ulong> subkeys, int rounds)
    {
        // Pre-whitening
        d1 ^= subkeys[0];
        d2 ^= subkeys[1];

        // Rounds 1–6
        SixRounds(ref d1, ref d2, subkeys, 2);

        // FL / FLINV
        d1 = FL(d1, subkeys[8]);
        d2 = FLINV(d2, subkeys[9]);

        // Rounds 7–12
        SixRounds(ref d1, ref d2, subkeys, 10);

        // FL / FLINV
        d1 = FL(d1, subkeys[16]);
        d2 = FLINV(d2, subkeys[17]);

        // Rounds 13–18
        SixRounds(ref d1, ref d2, subkeys, 18);

        if (rounds == 24)
        {
            // FL / FLINV
            d1 = FL(d1, subkeys[24]);
            d2 = FLINV(d2, subkeys[25]);

            // Rounds 19–24
            SixRounds(ref d1, ref d2, subkeys, 26);

            // Post-whitening
            d2 ^= subkeys[32];
            d1 ^= subkeys[33];
        }
        else
        {
            // Post-whitening (18-round)
            d2 ^= subkeys[24];
            d1 ^= subkeys[25];
        }

        // Output D2 || D1
        r1 = d2;
        r2 = d1;
    }

    /// <summary>
    /// Decrypts a single 16-byte block using the Camellia cipher.
    /// </summary>
    /// <param name="input">The 16-byte ciphertext block.</param>
    /// <param name="output">The 16-byte plaintext output.</param>
    /// <param name="subkeys">The expanded encryption subkeys (same array as for encryption).</param>
    /// <param name="rounds">The number of rounds (18 or 24).</param>
    public static void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output,
        ReadOnlySpan<ulong> subkeys, int rounds)
    {
        ulong d1 = BinaryPrimitives.ReadUInt64BigEndian(input);
        ulong d2 = BinaryPrimitives.ReadUInt64BigEndian(input.Slice(8));
        DecryptBlock(d1, d2, out ulong r1, out ulong r2, subkeys, rounds);
        BinaryPrimitives.WriteUInt64BigEndian(output, r1);
        BinaryPrimitives.WriteUInt64BigEndian(output.Slice(8), r2);
    }

    /// <summary>
    /// Decrypts a block supplied as two 64-bit halves, producing two 64-bit halves.
    /// </summary>
    /// <param name="d1">High 64 bits of ciphertext (big-endian byte order).</param>
    /// <param name="d2">Low 64 bits of ciphertext (big-endian byte order).</param>
    /// <param name="r1">High 64 bits of plaintext (big-endian byte order).</param>
    /// <param name="r2">Low 64 bits of plaintext (big-endian byte order).</param>
    /// <param name="subkeys">The expanded encryption subkeys (same array as for encryption).</param>
    /// <param name="rounds">The number of rounds (18 or 24).</param>
    internal static void DecryptBlock(ulong d1, ulong d2, out ulong r1, out ulong r2,
        ReadOnlySpan<ulong> subkeys, int rounds)
    {
        if (rounds == 24)
        {
            // Pre-whitening with kw3, kw4
            d1 ^= subkeys[32];
            d2 ^= subkeys[33];

            // Rounds 24–19
            SixRoundsReverse(ref d1, ref d2, subkeys, 26);

            // FL / FLINV with ke6, ke5
            d1 = FL(d1, subkeys[25]);
            d2 = FLINV(d2, subkeys[24]);

            // Rounds 18–13
            SixRoundsReverse(ref d1, ref d2, subkeys, 18);

            // FL / FLINV with ke4, ke3
            d1 = FL(d1, subkeys[17]);
            d2 = FLINV(d2, subkeys[16]);

            // Rounds 12–7
            SixRoundsReverse(ref d1, ref d2, subkeys, 10);

            // FL / FLINV with ke2, ke1
            d1 = FL(d1, subkeys[9]);
            d2 = FLINV(d2, subkeys[8]);

            // Rounds 6–1
            SixRoundsReverse(ref d1, ref d2, subkeys, 2);

            // Post-whitening with kw1, kw2
            d2 ^= subkeys[0];
            d1 ^= subkeys[1];
        }
        else
        {
            // Pre-whitening with kw3, kw4
            d1 ^= subkeys[24];
            d2 ^= subkeys[25];

            // Rounds 18–13
            SixRoundsReverse(ref d1, ref d2, subkeys, 18);

            // FL / FLINV with ke4, ke3
            d1 = FL(d1, subkeys[17]);
            d2 = FLINV(d2, subkeys[16]);

            // Rounds 12–7
            SixRoundsReverse(ref d1, ref d2, subkeys, 10);

            // FL / FLINV with ke2, ke1
            d1 = FL(d1, subkeys[9]);
            d2 = FLINV(d2, subkeys[8]);

            // Rounds 6–1
            SixRoundsReverse(ref d1, ref d2, subkeys, 2);

            // Post-whitening with kw1, kw2
            d2 ^= subkeys[0];
            d1 ^= subkeys[1];
        }

        // Output D2 || D1
        r1 = d2;
        r2 = d1;
    }

    /// <summary>
    /// Performs six Feistel rounds in forward (encryption) order.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SixRounds(ref ulong d1, ref ulong d2,
        ReadOnlySpan<ulong> k, int offset)
    {
        d2 ^= F(d1, k[offset]);
        d1 ^= F(d2, k[offset + 1]);
        d2 ^= F(d1, k[offset + 2]);
        d1 ^= F(d2, k[offset + 3]);
        d2 ^= F(d1, k[offset + 4]);
        d1 ^= F(d2, k[offset + 5]);
    }

    /// <summary>
    /// Performs six Feistel rounds in reverse (decryption) order.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void SixRoundsReverse(ref ulong d1, ref ulong d2,
        ReadOnlySpan<ulong> k, int offset)
    {
        d2 ^= F(d1, k[offset + 5]);
        d1 ^= F(d2, k[offset + 4]);
        d2 ^= F(d1, k[offset + 3]);
        d1 ^= F(d2, k[offset + 2]);
        d2 ^= F(d1, k[offset + 1]);
        d1 ^= F(d2, k[offset]);
    }

    /// <summary>
    /// Camellia F-function: applies S-boxes and the P-function mixing layer.
    /// </summary>
    /// <remarks>
    /// Each byte of <c>input ^ key</c> is looked up in a precomputed SP-box table
    /// that combines the S-box and the P-function column for that byte position.
    /// The eight 64-bit table values are XOR-folded to produce the F-function output.
    /// <see cref="MemoryMarshal.GetArrayDataReference"/> combined with
    /// <see cref="Unsafe.Add{T}(ref T, int)"/> is used to bypass redundant JIT bounds checks,
    /// since the index is always a <see cref="byte"/> in [0, 255] and each table has exactly 256 entries.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong F(ulong input, ulong key)
    {
        ulong x = input ^ key;
        ref ulong r1 = ref MemoryMarshal.GetArrayDataReference(_sp1);
        ref ulong r2 = ref MemoryMarshal.GetArrayDataReference(_sp2);
        ref ulong r3 = ref MemoryMarshal.GetArrayDataReference(_sp3);
        ref ulong r4 = ref MemoryMarshal.GetArrayDataReference(_sp4);
        ref ulong r5 = ref MemoryMarshal.GetArrayDataReference(_sp5);
        ref ulong r6 = ref MemoryMarshal.GetArrayDataReference(_sp6);
        ref ulong r7 = ref MemoryMarshal.GetArrayDataReference(_sp7);
        ref ulong r8 = ref MemoryMarshal.GetArrayDataReference(_sp8);
        return Unsafe.Add(ref r1, (byte)(x >> 56))
             ^ Unsafe.Add(ref r2, (byte)(x >> 48))
             ^ Unsafe.Add(ref r3, (byte)(x >> 40))
             ^ Unsafe.Add(ref r4, (byte)(x >> 32))
             ^ Unsafe.Add(ref r5, (byte)(x >> 24))
             ^ Unsafe.Add(ref r6, (byte)(x >> 16))
             ^ Unsafe.Add(ref r7, (byte)(x >>  8))
             ^ Unsafe.Add(ref r8, (byte)x);
    }

    /// <summary>
    /// FL-function: key-dependent linear mixing applied every 6 rounds.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong FL(ulong x, ulong k)
    {
        uint x1 = (uint)(x >> 32);
        uint x2 = (uint)x;
        uint k1 = (uint)(k >> 32);
        uint k2 = (uint)k;

        x2 ^= RotateLeft32(x1 & k1, 1);
        x1 ^= (x2 | k2);

        return ((ulong)x1 << 32) | x2;
    }

    /// <summary>
    /// FLINV-function: inverse of <see cref="FL"/>.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong FLINV(ulong y, ulong k)
    {
        uint y1 = (uint)(y >> 32);
        uint y2 = (uint)y;
        uint k1 = (uint)(k >> 32);
        uint k2 = (uint)k;

        y1 ^= (y2 | k2);
        y2 ^= RotateLeft32(y1 & k1, 1);

        return ((ulong)y1 << 32) | y2;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint RotateLeft32(uint value, int shift)
    {
        return (value << shift) | (value >> (32 - shift));
    }

    /// <summary>
    /// Left-rotates a 128-bit value represented as two 64-bit halves.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void RotateLeft128(ulong high, ulong low, int n,
        out ulong rh, out ulong rl)
    {
        if (n == 0)
        {
            rh = high;
            rl = low;
        }
        else if (n < 64)
        {
            rh = (high << n) | (low >> (64 - n));
            rl = (low << n) | (high >> (64 - n));
        }
        else if (n == 64)
        {
            rh = low;
            rl = high;
        }
        else
        {
            int m = n - 64;
            rh = (low << m) | (high >> (64 - m));
            rl = (high << m) | (low >> (64 - m));
        }
    }

    /// <summary>
    /// Expands a 128-bit key into 26 subkeys (18 rounds).
    /// </summary>
    private static int ExpandKey128(ulong klh, ulong kll, ulong kah, ulong kal,
        Span<ulong> sk)
    {
        // kw1, kw2 = KL <<< 0
        sk[0] = klh;
        sk[1] = kll;

        // k1, k2 = KA <<< 0
        sk[2] = kah;
        sk[3] = kal;

        // k3, k4 = KL <<< 15
        RotateLeft128(klh, kll, 15, out sk[4], out sk[5]);

        // k5, k6 = KA <<< 15
        RotateLeft128(kah, kal, 15, out sk[6], out sk[7]);

        // ke1, ke2 = KA <<< 30
        RotateLeft128(kah, kal, 30, out sk[8], out sk[9]);

        // k7, k8 = KL <<< 45
        RotateLeft128(klh, kll, 45, out sk[10], out sk[11]);

        // k9 = (KA <<< 45) >> 64
        RotateLeft128(kah, kal, 45, out sk[12], out _);

        // k10 = (KL <<< 60) & MASK64
        RotateLeft128(klh, kll, 60, out _, out sk[13]);

        // k11, k12 = KA <<< 60
        RotateLeft128(kah, kal, 60, out sk[14], out sk[15]);

        // ke3, ke4 = KL <<< 77
        RotateLeft128(klh, kll, 77, out sk[16], out sk[17]);

        // k13, k14 = KL <<< 94
        RotateLeft128(klh, kll, 94, out sk[18], out sk[19]);

        // k15, k16 = KA <<< 94
        RotateLeft128(kah, kal, 94, out sk[20], out sk[21]);

        // k17, k18 = KL <<< 111
        RotateLeft128(klh, kll, 111, out sk[22], out sk[23]);

        // kw3, kw4 = KA <<< 111
        RotateLeft128(kah, kal, 111, out sk[24], out sk[25]);

        return 18;
    }

    /// <summary>
    /// Expands a 192- or 256-bit key into 34 subkeys (24 rounds).
    /// </summary>
    private static int ExpandKey256(ulong klh, ulong kll, ulong krh, ulong krl,
        ulong kah, ulong kal, ulong kbh, ulong kbl, Span<ulong> sk)
    {
        // kw1, kw2 = KL <<< 0
        sk[0] = klh;
        sk[1] = kll;

        // k1, k2 = KB <<< 0
        sk[2] = kbh;
        sk[3] = kbl;

        // k3, k4 = KR <<< 15
        RotateLeft128(krh, krl, 15, out sk[4], out sk[5]);

        // k5, k6 = KA <<< 15
        RotateLeft128(kah, kal, 15, out sk[6], out sk[7]);

        // ke1, ke2 = KR <<< 30
        RotateLeft128(krh, krl, 30, out sk[8], out sk[9]);

        // k7, k8 = KB <<< 30
        RotateLeft128(kbh, kbl, 30, out sk[10], out sk[11]);

        // k9, k10 = KL <<< 45
        RotateLeft128(klh, kll, 45, out sk[12], out sk[13]);

        // k11, k12 = KA <<< 45
        RotateLeft128(kah, kal, 45, out sk[14], out sk[15]);

        // ke3, ke4 = KL <<< 60
        RotateLeft128(klh, kll, 60, out sk[16], out sk[17]);

        // k13, k14 = KR <<< 60
        RotateLeft128(krh, krl, 60, out sk[18], out sk[19]);

        // k15, k16 = KB <<< 60
        RotateLeft128(kbh, kbl, 60, out sk[20], out sk[21]);

        // k17, k18 = KL <<< 77
        RotateLeft128(klh, kll, 77, out sk[22], out sk[23]);

        // ke5, ke6 = KA <<< 77
        RotateLeft128(kah, kal, 77, out sk[24], out sk[25]);

        // k19, k20 = KR <<< 94
        RotateLeft128(krh, krl, 94, out sk[26], out sk[27]);

        // k21, k22 = KA <<< 94
        RotateLeft128(kah, kal, 94, out sk[28], out sk[29]);

        // k23, k24 = KL <<< 111
        RotateLeft128(klh, kll, 111, out sk[30], out sk[31]);

        // kw3, kw4 = KB <<< 111
        RotateLeft128(kbh, kbl, 111, out sk[32], out sk[33]);

        return 24;
    }
}
