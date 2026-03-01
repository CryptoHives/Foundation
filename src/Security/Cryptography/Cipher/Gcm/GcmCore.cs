// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using AesNi = System.Runtime.Intrinsics.X86.Aes;
#endif

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
internal readonly struct GcmCore
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
    /// Number of entries in the 4-bit shoup multiplication table.
    /// </summary>
    public const int ShoupTableSize = 16;

    /// <summary>
    /// The full number of entries in the 4-bit shoup multiplication table.
    /// </summary>
    public const int ShoupTableSpanSize = ShoupTableSize * 2;

    /// <summary>
    /// Reduction polynomial for GF(2^128): x^128 + x^7 + x^2 + x + 1
    /// Represented as the lower 128 bits: 0xe1 shifted appropriately.
    /// </summary>
    private const ulong R = 0xe100000000000000UL;

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

#if NET8_0_OR_GREATER
    /// <summary>
    /// PCLMULQDQ reduction constant for reflected GF(2^128) modular reduction.
    /// </summary>
    /// <remarks>
    /// Equals the GCM reduction polynomial (x^7 + x^2 + x + 1 = 0x87) reflected
    /// and left-shifted by 1, placed at bits [63:56]: 0xc200000000000000.
    /// This constant compensates for PCLMULQDQ's reflected bit order, eliminating
    /// the separate left-shift-by-1 step required by the Intel shift-based approach.
    /// Used with two PCLMULQDQ instructions to replace 26 shift/XOR operations.
    /// </remarks>
    private const ulong GcmReductionConstant = 0xc200000000000000UL;

    /// <summary>
    /// Byte-reversal mask for converting between big-endian and little-endian 128-bit values.
    /// </summary>
    private static readonly Vector128<byte> ByteSwapMask = Vector128.Create(
        (byte)15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0);

#if NET10_0_OR_GREATER
    /// <summary>
    /// 256-bit byte-reversal mask for AVX2-based byte-swap of two 128-bit blocks simultaneously.
    /// </summary>
    private static readonly Vector256<byte> ByteSwapMask256 = Vector256.Create(ByteSwapMask, ByteSwapMask);
#endif
#endif

    private readonly uint[] _encRoundKeys; // aliased storage for Vector/uint keys
    private readonly byte[] _h; // Hash subkey
    private readonly ulong[] _shoupTable; // Precomputed 4-bit Shoup multiplication table
    private readonly int _rounds;
#if NET8_0_OR_GREATER
    // selected accelerations by SimdSupport
    private readonly bool _useAesNi;
    private readonly bool _usePclmul;
    private readonly bool _usePipeline;
    private readonly bool _usePclmulV256;
    private readonly Vector128<byte> _hClmul;
    private readonly Vector128<byte>[] _hPowers;
#endif

    /// <summary>
    /// Initializes a new instance of the GcmCore class using the specified encryption key.
    /// </summary>
    /// <remarks>
    /// Ensure that the provided key is securely generated and managed. The key length must comply
    /// with the requirements of the underlying Galois/Counter Mode (GCM) algorithm. Improper key management may
    /// compromise the security of cryptographic operations.
    /// </remarks>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">A read-only span of bytes that contains the encryption key.</param>
    public GcmCore(SimdSupport simdSupport, ReadOnlySpan<byte> key)
    {
        // Expand key — single pinned buffer for both managed and AES-NI paths
        int keyWords = key.Length / 4;
        int totalWords = 4 * (keyWords + 7);
        _encRoundKeys = new uint[totalWords];

        // Compute hash subkey H = AES(K, 0^128)
        _h = new byte[BlockSizeBytes];
        Span<byte> zeroBlock = stackalloc byte[BlockSizeBytes];
        zeroBlock.Clear();

        simdSupport &= SimdSupport;
#if NET8_0_OR_GREATER
        if ((simdSupport & SimdSupport.AesNi) != 0)
        {
            _useAesNi = true;
            _rounds = AesCoreAesNi.ExpandKey(key, AesNiRoundKeys);
            AesCoreAesNi.EncryptBlock(zeroBlock, _h, AesNiRoundKeys, _rounds);
        }
        else
#endif
        {
            _rounds = AesCore.ExpandKey(key, _encRoundKeys);
            AesCore.EncryptBlock(zeroBlock, _h, _encRoundKeys, _rounds);
        }

        // Store H as ulongs for the optimized GHASH path
        ulong h0 = BinaryPrimitives.ReadUInt64BigEndian(_h.AsSpan(0));
        ulong h1 = BinaryPrimitives.ReadUInt64BigEndian(_h.AsSpan(sizeof(UInt64)));

        // Precompute 4-bit Shoup table for fast GF(2^128) multiplication
        _shoupTable = new ulong[ShoupTableSpanSize];
        BuildShoupTable(h0, h1, _shoupTable);

#if NET8_0_OR_GREATER
        _hPowers = null!;
        _usePclmul = (simdSupport & SimdSupport.PClMul) != 0;
        _usePclmulV256 = (simdSupport & SimdSupport.PClMulV256) != 0;
        if (_usePclmul || _usePclmulV256)
        {
            _hClmul = PrepareH(_h);
            if (_useAesNi)
            {
                _usePipeline = true;
                _hPowers = PrepareHPowers(_hClmul);
            }
        }
#endif
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets the round keys reinterpreted as <see cref="Vector128{T}"/> for AES-NI dispatch.
    /// </summary>
    private Span<Vector128<byte>> AesNiRoundKeys
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => MemoryMarshal.Cast<uint, Vector128<byte>>(_encRoundKeys.AsSpan());
    }
#endif

    /// <summary>
    /// Gets the SIMD instruction sets supported by AES-GCM on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport =>
#if NET8_0_OR_GREATER
        (AesCoreAesNi.IsSupported ? SimdSupport.AesNi : SimdSupport.None) |
        (IsPclmulSupported ? SimdSupport.PClMul : SimdSupport.None) |
        (IsPclmulV256Supported ? SimdSupport.PClMulV256 : SimdSupport.None);
#else
        SimdSupport.None;
#endif

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
    /// <param name="table">An array of 32 ulongs representing 16 entries of (hi, lo) pairs.</param>
    /// <returns>
    /// The number of entries written to the table.
    /// </returns>
    public static int BuildShoupTable(ulong h0, ulong h1, Span<ulong> table)
    {
        if (table.Length < ShoupTableSpanSize) throw new ArgumentOutOfRangeException(nameof(table));

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

        return ShoupTableSpanSize;
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
    public static void GHashComplete(
        ReadOnlySpan<ulong> shoupTable, ReadOnlySpan<byte> aad,
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
    public static void GHashComplete(
        ulong h0, ulong h1, ReadOnlySpan<byte> aad,
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
    public static void GHash(
        ReadOnlySpan<byte> h, ReadOnlySpan<byte> data, Span<byte> output)
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
    public static void GHashComplete(
        ReadOnlySpan<byte> h, ReadOnlySpan<byte> aad,
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
    public static void GctrAes(
        ReadOnlySpan<uint> roundKeys, int rounds,
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

#if NET8_0_OR_GREATER
    /// <summary>
    /// Performs GCTR using AES-NI hardware-accelerated AES encryption.
    /// </summary>
    /// <param name="roundKeys">The AES-NI round keys.</param>
    /// <param name="rounds">Number of AES rounds.</param>
    /// <param name="icb">The initial counter block.</param>
    /// <param name="input">The input data.</param>
    /// <param name="output">The output buffer.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    public static void GctrAesNi(
        ReadOnlySpan<Vector128<byte>> roundKeys, int rounds,
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
            AesCoreAesNi.EncryptBlock(counter, keystream, roundKeys, rounds);

            int remaining = input.Length - offset;

            if (remaining >= BlockSizeBytes)
            {
                ReadOnlySpan<ulong> src = MemoryMarshal.Cast<byte, ulong>(input.Slice(offset, BlockSizeBytes));
                ReadOnlySpan<ulong> ks = MemoryMarshal.Cast<byte, ulong>(keystream);
                Span<ulong> dst = MemoryMarshal.Cast<byte, ulong>(output.Slice(offset, BlockSizeBytes));
                dst[0] = src[0] ^ ks[0];
                dst[1] = src[1] ^ ks[1];
            }
            else
            {
                for (int i = 0; i < remaining; i++)
                {
                    output[offset + i] = (byte)(input[offset + i] ^ keystream[i]);
                }
            }

            IncrementCounter(counter);
            offset += BlockSizeBytes;
        }
    }
#endif

    /// <summary>
    /// Computes the initial counter block J0 from nonce.
    /// </summary>
    /// <param name="nonce">The nonce/IV.</param>
    /// <param name="j0">The output J0 buffer (16 bytes).</param>
    public void ComputeJ0(ReadOnlySpan<byte> nonce, Span<byte> j0)
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

                GHash(_h, paddedNonce, j0);
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
    private static void GfMulShoup(ReadOnlySpan<ulong> table, ref ulong y0, ref ulong y1)
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
    private static void ProcessBlocks(
        ReadOnlySpan<ulong> shoupTable, ReadOnlySpan<byte> data, ref ulong y0, ref ulong y1)
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void GctrDispatch(ReadOnlySpan<byte> icb, ReadOnlySpan<byte> input, Span<byte> output)
    {
#if NET8_0_OR_GREATER
        if (_useAesNi)
        {
            GctrAesNi(AesNiRoundKeys, _rounds, icb, input, output);
            return;
        }
#endif
        GctrAes(_encRoundKeys, _rounds, icb, input, output);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void GHashDispatch(ReadOnlySpan<byte> aad, ReadOnlySpan<byte> ciphertext, Span<byte> output)
    {
#if NET8_0_OR_GREATER
        if (_usePclmul)
        {
            GHashCompletePclmul(_hClmul, aad, ciphertext, output);
            return;
        }
#endif
        GHashComplete(_shoupTable, aad, ciphertext, output);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void GEncryptDispatch(
        ReadOnlySpan<byte> icb,
        ReadOnlySpan<byte> aad, ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext, Span<byte> ghash)
    {
#if NET8_0_OR_GREATER
        if (_usePipeline)
        {
            // Fused GCTR+GHASH pipeline: 4-block interleaved AES + aggregated CLMUL
            EncryptPipelined(
                AesNiRoundKeys, _rounds, _hPowers!,
                icb, aad, plaintext, ciphertext, ghash);
        }
        else
#endif
        {
            // Serial path: GCTR then GHASH
            GctrDispatch(icb, plaintext, ciphertext);
            GHashDispatch(aad, ciphertext.Slice(0, plaintext.Length), ghash);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void GDecryptDispatch(
        ReadOnlySpan<byte> icb,
        ReadOnlySpan<byte> aad, ReadOnlySpan<byte> ciphertext,
        Span<byte> plaintext, Span<byte> ghash)
    {
#if NET8_0_OR_GREATER
        if (_usePipeline)
        {
            // Fused GHASH+GCTR pipeline: computes GHASH and decrypts simultaneously
            DecryptPipelined(
                AesNiRoundKeys, _rounds, _hPowers!,
                icb, aad, ciphertext, plaintext, ghash);
        }
        else
#endif
        {
            // Serial path: GHASH → verify → GCTR
            GHashDispatch(aad, ciphertext, ghash);
            GctrDispatch(icb, ciphertext, plaintext);
        }
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets whether PCLMULQDQ hardware acceleration is available.
    /// </summary>
    private static bool IsPclmulSupported
    {
        get => Pclmulqdq.IsSupported && Sse2.IsSupported && Ssse3.IsSupported;
    }

    /// <summary>
    /// Gets whether PCLMULQDQ.V256 hardware acceleration is available.
    /// </summary>
    private static bool IsPclmulV256Supported
    {
#if NET10_0_OR_GREATER
        get => Pclmulqdq.V256.IsSupported && Avx2.IsSupported && Sse2.IsSupported && Ssse3.IsSupported;
#else
        get => false;
#endif
    }

    /// <summary>
    /// Prepares the hash subkey H for use with PCLMULQDQ-based GHASH.
    /// </summary>
    /// <remarks>
    /// Loads H from big-endian byte order and byte-reverses it for CLMUL processing.
    /// The <see cref="GfMulClmul"/> method handles the reflected polynomial internally.
    /// </remarks>
    /// <param name="h">The hash subkey H in big-endian byte order (16 bytes).</param>
    /// <returns>H byte-reversed to little-endian for CLMUL operations.</returns>
    private static Vector128<byte> PrepareH(ReadOnlySpan<byte> h)
    {
        var v = Vector128.Create(h);
        return Ssse3.Shuffle(v, ByteSwapMask);
    }

    /// <summary>
    /// Precomputes powers of H for aggregated GHASH: H¹ through H⁸.
    /// The array order is optimized for 256bit vector loads.
    /// </summary>
    /// <param name="hSwapped">The byte-reversed hash subkey from <see cref="PrepareH"/>.</param>
    /// <returns>Array of [H⁸, H⁷, H⁶, H⁵, H⁴, H³, H², H¹] for use with aggregated reduction.</returns>
    private static Vector128<byte>[] PrepareHPowers(Vector128<byte> hSwapped)
    {
        Vector128<byte> h2 = GfMulClmul(hSwapped, hSwapped);
        Vector128<byte> h3 = GfMulClmul(hSwapped, h2);
        Vector128<byte> h4 = GfMulClmul(hSwapped, h3);
        Vector128<byte> h5 = GfMulClmul(hSwapped, h4);
        Vector128<byte> h6 = GfMulClmul(hSwapped, h5);
        Vector128<byte> h7 = GfMulClmul(hSwapped, h6);
        Vector128<byte> h8 = GfMulClmul(hSwapped, h7);
        return [h8, h7, h6, h5, h4, h3, h2, hSwapped];
    }

    /// <summary>
    /// Performs GF(2^128) multiplication using PCLMULQDQ (carry-less multiply)
    /// with shift-based reduction per Intel's CLMUL whitepaper Algorithm 5.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Implements the reflected GHASH multiplication as specified in NIST SP 800-38D.
    /// Uses 4 carry-less multiplies for the 128×128→256 bit product, then reduces
    /// modulo x^128 + x^7 + x^2 + x + 1 using shift operations.
    /// </para>
    /// <para>
    /// The reduction includes an implicit left-shift by 1 to account for the
    /// reflected bit ordering used in GHASH.
    /// </para>
    /// </remarks>
    /// <param name="a">First operand (byte-reversed H).</param>
    /// <param name="b">Second operand (byte-reversed input block).</param>
    /// <returns>The GF(2^128) product, reduced modulo the GHASH polynomial.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static Vector128<byte> GfMulClmul(Vector128<byte> a, Vector128<byte> b)
    {
        // Carry-less multiply: 128×128 → 256 bits using schoolbook method
        Vector128<ulong> rl = Pclmulqdq.CarrylessMultiply(a.AsUInt64(), b.AsUInt64(), 0x00);
        Vector128<ulong> rm = Sse2.Xor(
            Pclmulqdq.CarrylessMultiply(a.AsUInt64(), b.AsUInt64(), 0x10),
            Pclmulqdq.CarrylessMultiply(a.AsUInt64(), b.AsUInt64(), 0x01));
        Vector128<ulong> rh = Pclmulqdq.CarrylessMultiply(a.AsUInt64(), b.AsUInt64(), 0x11);

        return ModReduceClmul(rl, rm, rh);
    }

    /// <summary>
    /// PCLMULQDQ-based modular reduction of a 256-bit carryless product.
    /// </summary>
    /// <remarks>
    /// Reduces the three 128-bit intermediate results (lo, mid, hi) from a carryless multiply
    /// modulo the GCM polynomial x^128 + x^7 + x^2 + x + 1, including the left-shift-by-1
    /// correction for reflected bit order. Uses 2 PCLMULQDQ instructions instead of 26
    /// shift/XOR operations.
    /// Based on SymCrypt's MODREDUCE (ghash_definitions.h).
    /// </remarks>
    /// <param name="rl">Low 128 bits of the carryless product.</param>
    /// <param name="rm">Middle 128 bits (cross-terms, A0·B1 ⊕ A1·B0).</param>
    /// <param name="rh">High 128 bits of the carryless product.</param>
    /// <returns>The 128-bit reduced result in GF(2^128).</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<byte> ModReduceClmul(
        Vector128<ulong> rl, Vector128<ulong> rm, Vector128<ulong> rh)
    {
        var vMul = Vector128.Create(GcmReductionConstant, 0UL).AsInt64();

        // Fold rl into rm through the reduction polynomial
        var t0 = Pclmulqdq.CarrylessMultiply(rl.AsInt64(), vMul, 0x00).AsUInt64();
        rl = Sse2.Shuffle(rl.AsUInt32(), 0x4E).AsUInt64();
        rm = Sse2.Xor(rm, t0);
        rm = Sse2.Xor(rm, rl);

        // Fold rm into rh with pre-shift for reflected bit order
        t0 = Pclmulqdq.CarrylessMultiply(
            Sse2.ShiftLeftLogical(rm, 1).AsInt64(), vMul, 0x00).AsUInt64();
        rm = Sse2.Shuffle(rm.AsUInt32(), 0x4E).AsUInt64();
        var res = Sse2.Xor(rh, rm);

        // Rotate res left by 1 and accumulate
        var t1 = Sse2.ShiftLeftLogical(res.AsUInt32(), 1).AsUInt64();
        res = Sse2.ShiftRightLogical(res.AsUInt32(), 31).AsUInt64();
        t0 = Sse2.Xor(t0, t1);
        res = Sse2.Shuffle(res.AsUInt32(), 0x93).AsUInt64(); // _MM_SHUFFLE(2,1,0,3)
        res = Sse2.Xor(res, t0);

        return res.AsByte();
    }

    /// <summary>
    /// Computes GHASH over AAD and ciphertext using PCLMULQDQ hardware acceleration.
    /// </summary>
    /// <param name="hSwapped">The byte-reversed hash subkey from <see cref="PrepareH"/>.</param>
    /// <param name="aad">Additional authenticated data.</param>
    /// <param name="ciphertext">The ciphertext.</param>
    /// <param name="output">The 16-byte output buffer for the GHASH result.</param>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    internal static void GHashCompletePclmul(
        Vector128<byte> hSwapped, ReadOnlySpan<byte> aad,
        ReadOnlySpan<byte> ciphertext, Span<byte> output)
    {
        Vector128<byte> y = Vector128<byte>.Zero;

        y = ProcessBlocksClmul(hSwapped, aad, y);
        y = ProcessBlocksClmul(hSwapped, ciphertext, y);

        // Length block: [aadBits || cBits] in big-endian, then byte-reversed
        ulong aadBits = (ulong)aad.Length * 8;
        ulong cBits = (ulong)ciphertext.Length * 8;
        Vector128<byte> lenBlock = Vector128.Create(cBits, aadBits).AsByte();
        y = Sse2.Xor(y, lenBlock);
        y = GfMulClmul(hSwapped, y);

        // Byte-reverse back to big-endian for output
        y = Ssse3.Shuffle(y, ByteSwapMask);
        y.CopyTo(output);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static Vector128<byte> ProcessBlocksClmul(
        Vector128<byte> hSwapped, ReadOnlySpan<byte> data, Vector128<byte> y)
    {
        int offset = 0;

        while (offset + BlockSizeBytes <= data.Length)
        {
            var block = Vector128.Create(data.Slice(offset, BlockSizeBytes));
            block = Ssse3.Shuffle(block, ByteSwapMask);
            y = Sse2.Xor(y, block);
            y = GfMulClmul(hSwapped, y);
            offset += BlockSizeBytes;
        }

        if (offset < data.Length)
        {
            Span<byte> padded = stackalloc byte[BlockSizeBytes];
            data.Slice(offset).CopyTo(padded);
            padded.Slice(data.Length - offset).Clear();
            var block = Vector128.Create(padded);
            block = Ssse3.Shuffle(block, ByteSwapMask);
            y = Sse2.Xor(y, block);
            y = GfMulClmul(hSwapped, y);
        }

        return y;
    }

    /// <summary>
    /// Performs aggregated 4-block GHASH using carry-less multiply with a single reduction.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Computes GHASH for 4 input blocks simultaneously using precomputed H-powers.
    /// Instead of 4 separate multiply+reduce operations, performs 4 multiplies and
    /// accumulates partial products, then reduces once.
    /// </para>
    /// <para>
    /// Based on Intel's CLMUL whitepaper Figure 8 (Jankowski/Laurent aggregated reduction).
    /// </para>
    /// </remarks>
    /// <param name="hPowers">Precomputed [H⁴, H³, H², H¹] from <see cref="PrepareHPowers"/>.</param>
    /// <param name="x0">First input block (multiplied with H⁴).</param>
    /// <param name="x1">Second input block (multiplied with H³).</param>
    /// <param name="x2">Third input block (multiplied with H²).</param>
    /// <param name="x3">Fourth input block (multiplied with H¹).</param>
    /// <returns>The reduced GF(2^128) result.</returns>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static Vector128<byte> GfMulReduce4(
        ReadOnlySpan<Vector128<byte>> hPowers,
        Vector128<byte> x0, Vector128<byte> x1,
        Vector128<byte> x2, Vector128<byte> x3)
    {
        // 4 independent carry-less multiplies (lo, hi, and cross terms)
        Vector128<ulong> h1 = hPowers[7].AsUInt64();
        Vector128<ulong> h4 = hPowers[4].AsUInt64();
        Vector128<ulong> h3 = hPowers[5].AsUInt64();
        Vector128<ulong> h2 = hPowers[6].AsUInt64();
        Vector128<ulong> d0 = x0.AsUInt64(); Vector128<ulong> d1 = x1.AsUInt64();
        Vector128<ulong> d2 = x2.AsUInt64(); Vector128<ulong> d3 = x3.AsUInt64();

        // Low parts
        Vector128<ulong> lo = Pclmulqdq.CarrylessMultiply(h4.AsInt64(), d0.AsInt64(), 0x00).AsUInt64();
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h3.AsInt64(), d1.AsInt64(), 0x00).AsUInt64());
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h2.AsInt64(), d2.AsInt64(), 0x00).AsUInt64());
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h1.AsInt64(), d3.AsInt64(), 0x00).AsUInt64());

        // High parts
        Vector128<ulong> hi = Pclmulqdq.CarrylessMultiply(h4.AsInt64(), d0.AsInt64(), 0x11).AsUInt64();
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h3.AsInt64(), d1.AsInt64(), 0x11).AsUInt64());
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h2.AsInt64(), d2.AsInt64(), 0x11).AsUInt64());
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h1.AsInt64(), d3.AsInt64(), 0x11).AsUInt64());

        // Cross terms using Karatsuba: (a_lo ^ a_hi) * (b_lo ^ b_hi)
        Vector128<ulong> t0 = Sse2.Xor(Sse2.Shuffle(h4.AsUInt32(), 0x4E).AsUInt64(), h4);
        Vector128<ulong> t4 = Sse2.Xor(Sse2.Shuffle(d0.AsUInt32(), 0x4E).AsUInt64(), d0);
        Vector128<ulong> mid = Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64();

        t0 = Sse2.Xor(Sse2.Shuffle(h3.AsUInt32(), 0x4E).AsUInt64(), h3);
        t4 = Sse2.Xor(Sse2.Shuffle(d1.AsUInt32(), 0x4E).AsUInt64(), d1);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        t0 = Sse2.Xor(Sse2.Shuffle(h2.AsUInt32(), 0x4E).AsUInt64(), h2);
        t4 = Sse2.Xor(Sse2.Shuffle(d2.AsUInt32(), 0x4E).AsUInt64(), d2);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        t0 = Sse2.Xor(Sse2.Shuffle(h1.AsUInt32(), 0x4E).AsUInt64(), h1);
        t4 = Sse2.Xor(Sse2.Shuffle(d3.AsUInt32(), 0x4E).AsUInt64(), d3);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        // Fold cross terms: mid ^= lo ^ hi
        mid = Sse2.Xor(mid, lo);
        mid = Sse2.Xor(mid, hi);

        return ModReduceClmul(lo, mid, hi);
    }

    /// <summary>
    /// Performs aggregated 8-block GHASH reduction using PCLMULQDQ.
    /// </summary>
    /// <remarks>
    /// Computes x0·H⁸ ⊕ x1·H⁷ ⊕ x2·H⁶ ⊕ x3·H⁵ ⊕ x4·H⁴ ⊕ x5·H³ ⊕ x6·H² ⊕ x7·H¹
    /// with a single polynomial reduction at the end.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static Vector128<byte> GfMulReduce8(
        ReadOnlySpan<Vector128<byte>> hPowers,
        Vector128<byte> x0, Vector128<byte> x1,
        Vector128<byte> x2, Vector128<byte> x3,
        Vector128<byte> x4, Vector128<byte> x5,
        Vector128<byte> x6, Vector128<byte> x7)
    {
        Vector128<ulong> h8 = hPowers[0].AsUInt64(); Vector128<ulong> h7 = hPowers[1].AsUInt64();
        Vector128<ulong> h6 = hPowers[2].AsUInt64(); Vector128<ulong> h5 = hPowers[3].AsUInt64();
        Vector128<ulong> h4 = hPowers[4].AsUInt64(); Vector128<ulong> h3 = hPowers[5].AsUInt64();
        Vector128<ulong> h2 = hPowers[6].AsUInt64(); Vector128<ulong> h1 = hPowers[7].AsUInt64();
        Vector128<ulong> d0 = x0.AsUInt64(); Vector128<ulong> d1 = x1.AsUInt64();
        Vector128<ulong> d2 = x2.AsUInt64(); Vector128<ulong> d3 = x3.AsUInt64();
        Vector128<ulong> d4 = x4.AsUInt64(); Vector128<ulong> d5 = x5.AsUInt64();
        Vector128<ulong> d6 = x6.AsUInt64(); Vector128<ulong> d7 = x7.AsUInt64();

        // Low parts
        Vector128<ulong> lo = Pclmulqdq.CarrylessMultiply(h8.AsInt64(), d0.AsInt64(), 0x00).AsUInt64();
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h7.AsInt64(), d1.AsInt64(), 0x00).AsUInt64());
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h6.AsInt64(), d2.AsInt64(), 0x00).AsUInt64());
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h5.AsInt64(), d3.AsInt64(), 0x00).AsUInt64());
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h4.AsInt64(), d4.AsInt64(), 0x00).AsUInt64());
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h3.AsInt64(), d5.AsInt64(), 0x00).AsUInt64());
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h2.AsInt64(), d6.AsInt64(), 0x00).AsUInt64());
        lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h1.AsInt64(), d7.AsInt64(), 0x00).AsUInt64());

        // High parts
        Vector128<ulong> hi = Pclmulqdq.CarrylessMultiply(h8.AsInt64(), d0.AsInt64(), 0x11).AsUInt64();
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h7.AsInt64(), d1.AsInt64(), 0x11).AsUInt64());
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h6.AsInt64(), d2.AsInt64(), 0x11).AsUInt64());
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h5.AsInt64(), d3.AsInt64(), 0x11).AsUInt64());
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h4.AsInt64(), d4.AsInt64(), 0x11).AsUInt64());
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h3.AsInt64(), d5.AsInt64(), 0x11).AsUInt64());
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h2.AsInt64(), d6.AsInt64(), 0x11).AsUInt64());
        hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h1.AsInt64(), d7.AsInt64(), 0x11).AsUInt64());

        // Cross terms using Karatsuba
        Vector128<ulong> t0 = Sse2.Xor(Sse2.Shuffle(h8.AsUInt32(), 0x4E).AsUInt64(), h8);
        Vector128<ulong> t4 = Sse2.Xor(Sse2.Shuffle(d0.AsUInt32(), 0x4E).AsUInt64(), d0);
        Vector128<ulong> mid = Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64();

        t0 = Sse2.Xor(Sse2.Shuffle(h7.AsUInt32(), 0x4E).AsUInt64(), h7);
        t4 = Sse2.Xor(Sse2.Shuffle(d1.AsUInt32(), 0x4E).AsUInt64(), d1);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        t0 = Sse2.Xor(Sse2.Shuffle(h6.AsUInt32(), 0x4E).AsUInt64(), h6);
        t4 = Sse2.Xor(Sse2.Shuffle(d2.AsUInt32(), 0x4E).AsUInt64(), d2);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        t0 = Sse2.Xor(Sse2.Shuffle(h5.AsUInt32(), 0x4E).AsUInt64(), h5);
        t4 = Sse2.Xor(Sse2.Shuffle(d3.AsUInt32(), 0x4E).AsUInt64(), d3);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        t0 = Sse2.Xor(Sse2.Shuffle(h4.AsUInt32(), 0x4E).AsUInt64(), h4);
        t4 = Sse2.Xor(Sse2.Shuffle(d4.AsUInt32(), 0x4E).AsUInt64(), d4);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        t0 = Sse2.Xor(Sse2.Shuffle(h3.AsUInt32(), 0x4E).AsUInt64(), h3);
        t4 = Sse2.Xor(Sse2.Shuffle(d5.AsUInt32(), 0x4E).AsUInt64(), d5);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        t0 = Sse2.Xor(Sse2.Shuffle(h2.AsUInt32(), 0x4E).AsUInt64(), h2);
        t4 = Sse2.Xor(Sse2.Shuffle(d6.AsUInt32(), 0x4E).AsUInt64(), d6);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        t0 = Sse2.Xor(Sse2.Shuffle(h1.AsUInt32(), 0x4E).AsUInt64(), h1);
        t4 = Sse2.Xor(Sse2.Shuffle(d7.AsUInt32(), 0x4E).AsUInt64(), d7);
        mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(t0.AsInt64(), t4.AsInt64(), 0x00).AsUInt64());

        // Fold cross terms
        mid = Sse2.Xor(mid, lo);
        mid = Sse2.Xor(mid, hi);

        return ModReduceClmul(lo, mid, hi);
    }

#if NET10_0_OR_GREATER
    /// <summary>
    /// 8-block aggregated GHASH reduction using VPCLMULQDQ (256-bit carryless multiply).
    /// </summary>
    /// <remarks>
    /// Packs pairs of H powers and data blocks into <see cref="Vector256{T}"/>,
    /// using <see cref="Pclmulqdq.V256"/> to perform two independent 128-bit
    /// carryless multiplies per instruction. This halves the CLMUL instruction
    /// count compared to <see cref="GfMulReduce8"/>: 12 VPCLMULQDQ vs 24 PCLMULQDQ.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    internal static Vector128<byte> GfMulReduce8Vpclmul(
        ReadOnlySpan<Vector128<byte>> hPowers,
        Vector128<byte> x0, Vector128<byte> x1,
        Vector128<byte> x2, Vector128<byte> x3,
        Vector128<byte> x4, Vector128<byte> x5,
        Vector128<byte> x6, Vector128<byte> x7)
    {
        // Single 256-bit loads from consecutive H power pairs
        var hp256 = MemoryMarshal.Cast<Vector128<byte>, Vector256<ulong>>(hPowers);
        var hp01 = hp256[0]; var hp23 = hp256[1]; var hp45 = hp256[2]; var hp67 = hp256[3];

        var dp01 = Vector256.Create(x0.AsUInt64(), x1.AsUInt64());
        var dp23 = Vector256.Create(x2.AsUInt64(), x3.AsUInt64());
        var dp45 = Vector256.Create(x4.AsUInt64(), x5.AsUInt64());
        var dp67 = Vector256.Create(x6.AsUInt64(), x7.AsUInt64());

        // Lo parts: 4 VPCLMULQDQ (each does 2 lane CLMULs)
        var lo256 = Pclmulqdq.V256.CarrylessMultiply(hp01.AsInt64(), dp01.AsInt64(), 0x00).AsUInt64();
        lo256 = Avx2.Xor(lo256, Pclmulqdq.V256.CarrylessMultiply(hp23.AsInt64(), dp23.AsInt64(), 0x00).AsUInt64());
        lo256 = Avx2.Xor(lo256, Pclmulqdq.V256.CarrylessMultiply(hp45.AsInt64(), dp45.AsInt64(), 0x00).AsUInt64());
        lo256 = Avx2.Xor(lo256, Pclmulqdq.V256.CarrylessMultiply(hp67.AsInt64(), dp67.AsInt64(), 0x00).AsUInt64());

        // Hi parts: 4 VPCLMULQDQ
        var hi256 = Pclmulqdq.V256.CarrylessMultiply(hp01.AsInt64(), dp01.AsInt64(), 0x11).AsUInt64();
        hi256 = Avx2.Xor(hi256, Pclmulqdq.V256.CarrylessMultiply(hp23.AsInt64(), dp23.AsInt64(), 0x11).AsUInt64());
        hi256 = Avx2.Xor(hi256, Pclmulqdq.V256.CarrylessMultiply(hp45.AsInt64(), dp45.AsInt64(), 0x11).AsUInt64());
        hi256 = Avx2.Xor(hi256, Pclmulqdq.V256.CarrylessMultiply(hp67.AsInt64(), dp67.AsInt64(), 0x11).AsUInt64());

        // Cross terms using Karatsuba: (h_lo ^ h_hi) * (d_lo ^ d_hi)
        var ht01 = Avx2.Xor(Avx2.Shuffle(hp01.AsUInt32(), 0x4E).AsUInt64(), hp01);
        var dt01 = Avx2.Xor(Avx2.Shuffle(dp01.AsUInt32(), 0x4E).AsUInt64(), dp01);
        var mid256 = Pclmulqdq.V256.CarrylessMultiply(ht01.AsInt64(), dt01.AsInt64(), 0x00).AsUInt64();

        var ht23 = Avx2.Xor(Avx2.Shuffle(hp23.AsUInt32(), 0x4E).AsUInt64(), hp23);
        var dt23 = Avx2.Xor(Avx2.Shuffle(dp23.AsUInt32(), 0x4E).AsUInt64(), dp23);
        mid256 = Avx2.Xor(mid256, Pclmulqdq.V256.CarrylessMultiply(ht23.AsInt64(), dt23.AsInt64(), 0x00).AsUInt64());

        var ht45 = Avx2.Xor(Avx2.Shuffle(hp45.AsUInt32(), 0x4E).AsUInt64(), hp45);
        var dt45 = Avx2.Xor(Avx2.Shuffle(dp45.AsUInt32(), 0x4E).AsUInt64(), dp45);
        mid256 = Avx2.Xor(mid256, Pclmulqdq.V256.CarrylessMultiply(ht45.AsInt64(), dt45.AsInt64(), 0x00).AsUInt64());

        var ht67 = Avx2.Xor(Avx2.Shuffle(hp67.AsUInt32(), 0x4E).AsUInt64(), hp67);
        var dt67 = Avx2.Xor(Avx2.Shuffle(dp67.AsUInt32(), 0x4E).AsUInt64(), dp67);
        mid256 = Avx2.Xor(mid256, Pclmulqdq.V256.CarrylessMultiply(ht67.AsInt64(), dt67.AsInt64(), 0x00).AsUInt64());

        // Fold 256→128: XOR upper and lower halves
        Vector128<ulong> lo = Sse2.Xor(lo256.GetLower(), lo256.GetUpper());
        Vector128<ulong> hi = Sse2.Xor(hi256.GetLower(), hi256.GetUpper());
        Vector128<ulong> mid = Sse2.Xor(mid256.GetLower(), mid256.GetUpper());

        // Fold cross terms
        mid = Sse2.Xor(mid, lo);
        mid = Sse2.Xor(mid, hi);

        return ModReduceClmul(lo, mid, hi);
    }
#endif

    /// <summary>
    /// Increments a big-endian 32-bit counter in bytes [12..15] of a <see cref="Vector128{T}"/>.
    /// </summary>
    /// <param name="counter">The counter block as a Vector128 (in original BE byte order).</param>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void IncrementCounterVec(ref Vector128<byte> counter)
    {
        uint ctr = BinaryPrimitives.ReverseEndianness(counter.AsUInt32().GetElement(3));
        counter = counter.AsUInt32().WithElement(3, BinaryPrimitives.ReverseEndianness(++ctr)).AsByte();
    }

    /// <summary>
    /// Generates 8 consecutive counter blocks and advances the counter by 8.
    /// </summary>
    /// <remarks>
    /// Extracts the scalar BE counter once, computes 8 values, and inserts each back.
    /// Saves 7 <c>GetElement</c> + 14 <c>ReverseEndianness</c> calls vs 8 individual increments.
    /// </remarks>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GenerateCounterBlocks8(
        ref Vector128<byte> counter,
        out Vector128<byte> c0, out Vector128<byte> c1,
        out Vector128<byte> c2, out Vector128<byte> c3,
        out Vector128<byte> c4, out Vector128<byte> c5,
        out Vector128<byte> c6, out Vector128<byte> c7)
    {
        uint ctr = BinaryPrimitives.ReverseEndianness(counter.AsUInt32().GetElement(3));
        Vector128<uint> nonce = counter.AsUInt32().WithElement(3, 0u);
        c0 = counter;
        c1 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 1)).AsByte();
        c2 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 2)).AsByte();
        c3 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 3)).AsByte();
        c4 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 4)).AsByte();
        c5 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 5)).AsByte();
        c6 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 6)).AsByte();
        c7 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 7)).AsByte();
        counter = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 8)).AsByte();
    }

    /// <summary>
    /// Generates 4 consecutive counter blocks and advances the counter by 4.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void GenerateCounterBlocks4(
        ref Vector128<byte> counter,
        out Vector128<byte> c0, out Vector128<byte> c1,
        out Vector128<byte> c2, out Vector128<byte> c3)
    {
        uint ctr = BinaryPrimitives.ReverseEndianness(counter.AsUInt32().GetElement(3));
        Vector128<uint> nonce = counter.AsUInt32().WithElement(3, 0u);
        c0 = counter;
        c1 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 1)).AsByte();
        c2 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 2)).AsByte();
        c3 = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 3)).AsByte();
        counter = nonce.WithElement(3, BinaryPrimitives.ReverseEndianness(ctr + 4)).AsByte();
    }

    /// <summary>
    /// Performs pipelined AES-GCM encryption: fused GCTR + GHASH with 8-block interleaving.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Processes 8 AES-CTR blocks in parallel via interleaved AES-NI, then feeds the
    /// resulting ciphertext into an 8-block aggregated GHASH reduction. Falls back to
    /// 4-block and single-block loops for remaining data.
    /// </para>
    /// <para>
    /// For the AAD, uses standard per-block GHASH before entering the pipelined loop.
    /// The length block is appended after all data blocks are processed.
    /// </para>
    /// </remarks>
    /// <param name="roundKeys">The AES-NI round keys.</param>
    /// <param name="rounds">Number of AES rounds.</param>
    /// <param name="hPowers">Precomputed [H⁸, H⁷, H⁶, H⁵, H⁴, H³, H², H¹].</param>
    /// <param name="icb">The initial counter block (J0 + 1).</param>
    /// <param name="aad">Additional authenticated data.</param>
    /// <param name="plaintext">The plaintext input.</param>
    /// <param name="ciphertext">The ciphertext output buffer.</param>
    /// <param name="ghashOut">The 16-byte GHASH output buffer.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void EncryptPipelined(
        ReadOnlySpan<Vector128<byte>> roundKeys, int rounds,
        ReadOnlySpan<Vector128<byte>> hPowers,
        ReadOnlySpan<byte> icb,
        ReadOnlySpan<byte> aad,
        ReadOnlySpan<byte> plaintext,
        Span<byte> ciphertext,
        Span<byte> ghashOut)
    {
        Vector128<byte> y = Vector128<byte>.Zero;

        Span<byte> ctrBuf = stackalloc byte[BlockSizeBytes];
        Span<byte> ksBuf = stackalloc byte[BlockSizeBytes];

        // Process AAD with single-block GHASH
        y = ProcessBlocksClmul(_hClmul, aad, y);

        // Pipelined GCTR+GHASH for plaintext
        var counter = Vector128.Create(icb);
        int offset = 0;
        int len = plaintext.Length;

        // 8-block pipelined loop
        while (offset + 8 * BlockSizeBytes <= len)
        {
            GenerateCounterBlocks8(ref counter,
                out var c0, out var c1, out var c2, out var c3,
                out var c4, out var c5, out var c6, out var c7);

            AesCoreAesNi.EncryptBlocks8(
                ref c0, ref c1, ref c2, ref c3,
                ref c4, ref c5, ref c6, ref c7, roundKeys, rounds);

            c0 = Sse2.Xor(c0, Vector128.Create(plaintext.Slice(offset, BlockSizeBytes)));
            c1 = Sse2.Xor(c1, Vector128.Create(plaintext.Slice(offset + BlockSizeBytes, BlockSizeBytes)));
            c2 = Sse2.Xor(c2, Vector128.Create(plaintext.Slice(offset + 2 * BlockSizeBytes, BlockSizeBytes)));
            c3 = Sse2.Xor(c3, Vector128.Create(plaintext.Slice(offset + 3 * BlockSizeBytes, BlockSizeBytes)));
            c4 = Sse2.Xor(c4, Vector128.Create(plaintext.Slice(offset + 4 * BlockSizeBytes, BlockSizeBytes)));
            c5 = Sse2.Xor(c5, Vector128.Create(plaintext.Slice(offset + 5 * BlockSizeBytes, BlockSizeBytes)));
            c6 = Sse2.Xor(c6, Vector128.Create(plaintext.Slice(offset + 6 * BlockSizeBytes, BlockSizeBytes)));
            c7 = Sse2.Xor(c7, Vector128.Create(plaintext.Slice(offset + 7 * BlockSizeBytes, BlockSizeBytes)));

            c0.CopyTo(ciphertext.Slice(offset));
            c1.CopyTo(ciphertext.Slice(offset + BlockSizeBytes));
            c2.CopyTo(ciphertext.Slice(offset + 2 * BlockSizeBytes));
            c3.CopyTo(ciphertext.Slice(offset + 3 * BlockSizeBytes));
            c4.CopyTo(ciphertext.Slice(offset + 4 * BlockSizeBytes));
            c5.CopyTo(ciphertext.Slice(offset + 5 * BlockSizeBytes));
            c6.CopyTo(ciphertext.Slice(offset + 6 * BlockSizeBytes));
            c7.CopyTo(ciphertext.Slice(offset + 7 * BlockSizeBytes));

            Vector128<byte> g0 = Sse2.Xor(y, Ssse3.Shuffle(c0, ByteSwapMask));
            Vector128<byte> g1 = Ssse3.Shuffle(c1, ByteSwapMask);
            Vector128<byte> g2 = Ssse3.Shuffle(c2, ByteSwapMask);
            Vector128<byte> g3 = Ssse3.Shuffle(c3, ByteSwapMask);
            Vector128<byte> g4 = Ssse3.Shuffle(c4, ByteSwapMask);
            Vector128<byte> g5 = Ssse3.Shuffle(c5, ByteSwapMask);
            Vector128<byte> g6 = Ssse3.Shuffle(c6, ByteSwapMask);
            Vector128<byte> g7 = Ssse3.Shuffle(c7, ByteSwapMask);

#if NET10_0_OR_GREATER
            y = _usePclmulV256 ?
                GfMulReduce8Vpclmul(hPowers, g0, g1, g2, g3, g4, g5, g6, g7) :
                GfMulReduce8(hPowers, g0, g1, g2, g3, g4, g5, g6, g7);
#else
            y = GfMulReduce8(hPowers, g0, g1, g2, g3, g4, g5, g6, g7);
#endif

            offset += 8 * BlockSizeBytes;
        }

        // 4-block fallback
        while (offset + 4 * BlockSizeBytes <= len)
        {
            // Generate 4 countref er blocks
            GenerateCounterBlocks4(ref counter,
                out var c0, out var c1, out var c2, out var c3);

            // Encrypt 4 counter blocks in parallel
            AesCoreAesNi.EncryptBlocks4(ref c0, ref c1, ref c2, ref c3, roundKeys, rounds);

            // XOR with plaintext to produce ciphertext
            var p0 = Vector128.Create(plaintext.Slice(offset, BlockSizeBytes));
            var p1 = Vector128.Create(plaintext.Slice(offset + BlockSizeBytes, BlockSizeBytes));
            var p2 = Vector128.Create(plaintext.Slice(offset + 2 * BlockSizeBytes, BlockSizeBytes));
            var p3 = Vector128.Create(plaintext.Slice(offset + 3 * BlockSizeBytes, BlockSizeBytes));

            c0 = Sse2.Xor(c0, p0);
            c1 = Sse2.Xor(c1, p1);
            c2 = Sse2.Xor(c2, p2);
            c3 = Sse2.Xor(c3, p3);

            // Store ciphertext
            c0.CopyTo(ciphertext.Slice(offset));
            c1.CopyTo(ciphertext.Slice(offset + BlockSizeBytes));
            c2.CopyTo(ciphertext.Slice(offset + 2 * BlockSizeBytes));
            c3.CopyTo(ciphertext.Slice(offset + 3 * BlockSizeBytes));

            // GHASH 4 ciphertext blocks with aggregated reduction
            // Byte-swap for GHASH (big-endian → little-endian)
            Vector128<byte> g0 = Sse2.Xor(y, Ssse3.Shuffle(c0, ByteSwapMask));
            Vector128<byte> g1 = Ssse3.Shuffle(c1, ByteSwapMask);
            Vector128<byte> g2 = Ssse3.Shuffle(c2, ByteSwapMask);
            Vector128<byte> g3 = Ssse3.Shuffle(c3, ByteSwapMask);

            y = GfMulReduce4(hPowers, g0, g1, g2, g3);

            offset += 4 * BlockSizeBytes;
        }

        // Remaining full blocks (1-3)
        while (offset + BlockSizeBytes <= len)
        {
            Vector128<byte> c = counter;
            IncrementCounterVec(ref counter);
            c.CopyTo(ctrBuf);
            AesCoreAesNi.EncryptBlock(ctrBuf, ksBuf, roundKeys, rounds);

            var ks = Vector128.Create(ksBuf);
            var pt = Vector128.Create(plaintext.Slice(offset, BlockSizeBytes));
            Vector128<byte> ct = Sse2.Xor(pt, ks);
            ct.CopyTo(ciphertext.Slice(offset));

            y = Sse2.Xor(y, Ssse3.Shuffle(ct, ByteSwapMask));
            y = GfMulClmul(_hClmul, y);
            offset += BlockSizeBytes;
        }

        // Partial final block
        if (offset < len)
        {
            int remaining = len - offset;
            counter.CopyTo(ctrBuf);
            AesCoreAesNi.EncryptBlock(ctrBuf, ksBuf, roundKeys, rounds);

            for (int i = 0; i < remaining; i++)
                ciphertext[offset + i] = (byte)(plaintext[offset + i] ^ ksBuf[i]);

            Span<byte> padded = stackalloc byte[BlockSizeBytes];
            padded.Clear();
            ciphertext.Slice(offset, remaining).CopyTo(padded);
            Vector128<byte> block = Ssse3.Shuffle(Vector128.Create(padded), ByteSwapMask);
            y = Sse2.Xor(y, block);
            y = GfMulClmul(_hClmul, y);
        }

        // Length block
        ulong aadBits = (ulong)aad.Length * 8;
        ulong cBits = (ulong)plaintext.Length * 8;
        Vector128<byte> lenBlock = Vector128.Create(cBits, aadBits).AsByte();
        y = Sse2.Xor(y, lenBlock);
        y = GfMulClmul(_hClmul, y);

        Ssse3.Shuffle(y, ByteSwapMask).CopyTo(ghashOut);
    }

    /// <summary>
    /// Performs pipelined AES-GCM decryption: fused GHASH + GCTR with 8-block interleaving.
    /// </summary>
    /// <remarks>
    /// For decryption, GHASH runs on the ciphertext input (available immediately), while
    /// AES-CTR generates keystream blocks in parallel. Both can execute simultaneously
    /// on different CPU execution ports.
    /// </remarks>
    /// <param name="roundKeys">The AES-NI round keys.</param>
    /// <param name="rounds">Number of AES rounds.</param>
    /// <param name="hPowers">Precomputed [H⁸, H⁷, H⁶, H⁵, H⁴, H³, H², H¹].</param>
    /// <param name="icb">The initial counter block (J0 + 1).</param>
    /// <param name="aad">Additional authenticated data.</param>
    /// <param name="ciphertext">The ciphertext input.</param>
    /// <param name="plaintext">The plaintext output buffer.</param>
    /// <param name="ghashOut">The 16-byte GHASH output buffer.</param>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void DecryptPipelined(
        ReadOnlySpan<Vector128<byte>> roundKeys, int rounds,
        ReadOnlySpan<Vector128<byte>> hPowers,
        ReadOnlySpan<byte> icb,
        ReadOnlySpan<byte> aad, ReadOnlySpan<byte> ciphertext,
        Span<byte> plaintext, Span<byte> ghashOut)
    {
        Vector128<byte> y = Vector128<byte>.Zero;
        Span<byte> ctrBuf = stackalloc byte[BlockSizeBytes];
        Span<byte> ksBuf = stackalloc byte[BlockSizeBytes];

        // Process AAD with single-block GHASH
        y = ProcessBlocksClmul(_hClmul, aad, y);

        // Pipelined GHASH+GCTR for ciphertext
        var counter = Vector128.Create(icb);
        int offset = 0;
        int len = ciphertext.Length;

        // stitched loop overhead pays off with at least two rounds
        if (len >= 2 * 8 * BlockSizeBytes)
        {
            // 8-block stitched loops: inline AES rounds + GHASH CLMUL interleaved
            // for maximum CPU port overlap (AES on port 0/1, CLMUL on port 0)
            // use non inlined functions which can be better
#if NET10_0_OR_GREATER
            if (_usePclmulV256)
            {
                offset = DecryptStitchedPclmulV256Loop(roundKeys, rounds, hPowers,
                    ref counter, ref y, ciphertext, plaintext, offset, len);
            }
            else
#endif
            {
                offset = DecryptStitchedPclmul128Loop(roundKeys, rounds, hPowers,
                    ref counter, ref y, ciphertext, plaintext, offset, len);
            }
        }

        // 4-block fallback
        while (offset + 4 * BlockSizeBytes <= len)
        {
            // Load 4 ciphertext blocks and GHASH them
            var ct0 = Vector128.Create(ciphertext.Slice(offset, BlockSizeBytes));
            var ct1 = Vector128.Create(ciphertext.Slice(offset + BlockSizeBytes, BlockSizeBytes));
            var ct2 = Vector128.Create(ciphertext.Slice(offset + 2 * BlockSizeBytes, BlockSizeBytes));
            var ct3 = Vector128.Create(ciphertext.Slice(offset + 3 * BlockSizeBytes, BlockSizeBytes));

            Vector128<byte> g0 = Sse2.Xor(y, Ssse3.Shuffle(ct0, ByteSwapMask));
            Vector128<byte> g1 = Ssse3.Shuffle(ct1, ByteSwapMask);
            Vector128<byte> g2 = Ssse3.Shuffle(ct2, ByteSwapMask);
            Vector128<byte> g3 = Ssse3.Shuffle(ct3, ByteSwapMask);

            // Generate 4 counter blocks
            GenerateCounterBlocks4(ref counter,
                out var c0, out var c1, out var c2, out var c3);

            // GHASH and AES can overlap on different execution ports
            y = GfMulReduce4(hPowers, g0, g1, g2, g3);
            AesCoreAesNi.EncryptBlocks4(ref c0, ref c1, ref c2, ref c3, roundKeys, rounds);

            // XOR keystream with ciphertext to produce plaintext
            Sse2.Xor(ct0, c0).CopyTo(plaintext.Slice(offset));
            Sse2.Xor(ct1, c1).CopyTo(plaintext.Slice(offset + BlockSizeBytes));
            Sse2.Xor(ct2, c2).CopyTo(plaintext.Slice(offset + 2 * BlockSizeBytes));
            Sse2.Xor(ct3, c3).CopyTo(plaintext.Slice(offset + 3 * BlockSizeBytes));

            offset += 4 * BlockSizeBytes;
        }

        // Remaining full blocks (1-3)
        while (offset + BlockSizeBytes <= len)
        {
            var ct = Vector128.Create(ciphertext.Slice(offset, BlockSizeBytes));
            y = Sse2.Xor(y, Ssse3.Shuffle(ct, ByteSwapMask));
            y = GfMulClmul(_hClmul, y);

            Vector128<byte> c = counter;
            IncrementCounterVec(ref counter);
            c.CopyTo(ctrBuf);
            AesCoreAesNi.EncryptBlock(ctrBuf, ksBuf, roundKeys, rounds);

            var ksVec = Vector128.Create(ksBuf);
            Sse2.Xor(ct, ksVec).CopyTo(plaintext.Slice(offset));
            offset += BlockSizeBytes;
        }

        // Partial final block
        if (offset < len)
        {
            int remaining = len - offset;

            Span<byte> padded = stackalloc byte[BlockSizeBytes];
            padded.Clear();
            ciphertext.Slice(offset, remaining).CopyTo(padded);
            Vector128<byte> block = Ssse3.Shuffle(Vector128.Create(padded), ByteSwapMask);
            y = Sse2.Xor(y, block);
            y = GfMulClmul(_hClmul, y);

            counter.CopyTo(ctrBuf);
            AesCoreAesNi.EncryptBlock(ctrBuf, ksBuf, roundKeys, rounds);
            for (int i = 0; i < remaining; i++)
            {
                plaintext[offset + i] = (byte)(ciphertext[offset + i] ^ ksBuf[i]);
            }
        }

        // Length block
        ulong aadBits = (ulong)aad.Length * 8;
        ulong cBits = (ulong)ciphertext.Length * 8;
        Vector128<byte> lenBlock = Vector128.Create(cBits, aadBits).AsByte();
        y = Sse2.Xor(y, lenBlock);
        y = GfMulClmul(_hClmul, y);

        Ssse3.Shuffle(y, ByteSwapMask).CopyTo(ghashOut);
    }

#if NET10_0_OR_GREATER
    /// <summary>
    /// V256 stitched 8-block decrypt loop: VPCLMULQDQ GHASH interleaved with AES-NI rounds.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static int DecryptStitchedPclmulV256Loop(
        ReadOnlySpan<Vector128<byte>> roundKeys, int rounds,
        ReadOnlySpan<Vector128<byte>> hPowers,
        ref Vector128<byte> counter,
        ref Vector128<byte> y,
        ReadOnlySpan<byte> ciphertext,
        Span<byte> plaintext,
        int offset,
        int len)
    {
        // Single 256-bit loads from consecutive H power pairs
        var hp256 = MemoryMarshal.Cast<Vector128<byte>, Vector256<ulong>>(hPowers);
        var hp01 = hp256[0]; var hp23 = hp256[1]; var hp45 = hp256[2]; var hp67 = hp256[3];

        while (offset + 8 * BlockSizeBytes <= len)
        {
            // Load 8 ciphertext blocks as 256-bit pairs (single vmovdqu per pair)
            var raw01 = Vector256.Create(ciphertext.Slice(offset, 2 * BlockSizeBytes));
            var raw23 = Vector256.Create(ciphertext.Slice(offset + 2 * BlockSizeBytes, 2 * BlockSizeBytes));
            var raw45 = Vector256.Create(ciphertext.Slice(offset + 4 * BlockSizeBytes, 2 * BlockSizeBytes));
            var raw67 = Vector256.Create(ciphertext.Slice(offset + 6 * BlockSizeBytes, 2 * BlockSizeBytes));

            // Extract individual 128-bit blocks for final XOR with keystream
            var ct0 = raw01.GetLower(); var ct1 = raw01.GetUpper();
            var ct2 = raw23.GetLower(); var ct3 = raw23.GetUpper();
            var ct4 = raw45.GetLower(); var ct5 = raw45.GetUpper();
            var ct6 = raw67.GetLower(); var ct7 = raw67.GetUpper();

            // AVX2 byte-swap for GHASH inputs (vpshufb ymm, 2 blocks per op)
            var dp01 = Avx2.Shuffle(raw01, ByteSwapMask256).AsUInt64();
            var dp23 = Avx2.Shuffle(raw23, ByteSwapMask256).AsUInt64();
            var dp45 = Avx2.Shuffle(raw45, ByteSwapMask256).AsUInt64();
            var dp67 = Avx2.Shuffle(raw67, ByteSwapMask256).AsUInt64();

            // XOR y into first GHASH data block (lower lane only)
            dp01 = Avx2.Xor(dp01, y.AsUInt64().ToVector256());

            // Generate 8 counter blocks
            GenerateCounterBlocks8(ref counter,
                out var c0, out var c1, out var c2, out var c3,
                out var c4, out var c5, out var c6, out var c7);

            // AES whitening (round 0)
            var rk = roundKeys[0];
            c0 = Sse2.Xor(c0, rk); c1 = Sse2.Xor(c1, rk);
            c2 = Sse2.Xor(c2, rk); c3 = Sse2.Xor(c3, rk);
            c4 = Sse2.Xor(c4, rk); c5 = Sse2.Xor(c5, rk);
            c6 = Sse2.Xor(c6, rk); c7 = Sse2.Xor(c7, rk);

            // AES round 1 + GHASH lo
            rk = roundKeys[1];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            var lo256 = Pclmulqdq.V256.CarrylessMultiply(hp01.AsInt64(), dp01.AsInt64(), 0x00).AsUInt64();
            lo256 = Avx2.Xor(lo256, Pclmulqdq.V256.CarrylessMultiply(hp23.AsInt64(), dp23.AsInt64(), 0x00).AsUInt64());

            // AES round 2 + GHASH lo continued
            rk = roundKeys[2];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            lo256 = Avx2.Xor(lo256, Pclmulqdq.V256.CarrylessMultiply(hp45.AsInt64(), dp45.AsInt64(), 0x00).AsUInt64());
            lo256 = Avx2.Xor(lo256, Pclmulqdq.V256.CarrylessMultiply(hp67.AsInt64(), dp67.AsInt64(), 0x00).AsUInt64());

            // AES round 3 + GHASH hi
            rk = roundKeys[3];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            var hi256 = Pclmulqdq.V256.CarrylessMultiply(hp01.AsInt64(), dp01.AsInt64(), 0x11).AsUInt64();
            hi256 = Avx2.Xor(hi256, Pclmulqdq.V256.CarrylessMultiply(hp23.AsInt64(), dp23.AsInt64(), 0x11).AsUInt64());

            // AES round 4 + GHASH hi continued
            rk = roundKeys[4];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            hi256 = Avx2.Xor(hi256, Pclmulqdq.V256.CarrylessMultiply(hp45.AsInt64(), dp45.AsInt64(), 0x11).AsUInt64());
            hi256 = Avx2.Xor(hi256, Pclmulqdq.V256.CarrylessMultiply(hp67.AsInt64(), dp67.AsInt64(), 0x11).AsUInt64());

            // AES round 5 + GHASH cross (Karatsuba prep + multiply)
            rk = roundKeys[5];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            var ht01 = Avx2.Xor(Avx2.Shuffle(hp01.AsUInt32(), 0x4E).AsUInt64(), hp01);
            var dt01 = Avx2.Xor(Avx2.Shuffle(dp01.AsUInt32(), 0x4E).AsUInt64(), dp01);
            var mid256 = Pclmulqdq.V256.CarrylessMultiply(ht01.AsInt64(), dt01.AsInt64(), 0x00).AsUInt64();
            var ht23 = Avx2.Xor(Avx2.Shuffle(hp23.AsUInt32(), 0x4E).AsUInt64(), hp23);
            var dt23 = Avx2.Xor(Avx2.Shuffle(dp23.AsUInt32(), 0x4E).AsUInt64(), dp23);
            mid256 = Avx2.Xor(mid256, Pclmulqdq.V256.CarrylessMultiply(ht23.AsInt64(), dt23.AsInt64(), 0x00).AsUInt64());

            // AES round 6 + GHASH cross continued
            rk = roundKeys[6];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            var ht45 = Avx2.Xor(Avx2.Shuffle(hp45.AsUInt32(), 0x4E).AsUInt64(), hp45);
            var dt45 = Avx2.Xor(Avx2.Shuffle(dp45.AsUInt32(), 0x4E).AsUInt64(), dp45);
            mid256 = Avx2.Xor(mid256, Pclmulqdq.V256.CarrylessMultiply(ht45.AsInt64(), dt45.AsInt64(), 0x00).AsUInt64());
            var ht67 = Avx2.Xor(Avx2.Shuffle(hp67.AsUInt32(), 0x4E).AsUInt64(), hp67);
            var dt67 = Avx2.Xor(Avx2.Shuffle(dp67.AsUInt32(), 0x4E).AsUInt64(), dp67);
            mid256 = Avx2.Xor(mid256, Pclmulqdq.V256.CarrylessMultiply(ht67.AsInt64(), dt67.AsInt64(), 0x00).AsUInt64());

            // AES round 7 + GHASH fold 256→128 using AVX2
            rk = roundKeys[7];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            lo256 = Avx2.Xor(lo256, Avx2.Permute2x128(lo256, lo256, 0x01));
            hi256 = Avx2.Xor(hi256, Avx2.Permute2x128(hi256, hi256, 0x01));
            mid256 = Avx2.Xor(mid256, Avx2.Permute2x128(mid256, mid256, 0x01));
            mid256 = Avx2.Xor(mid256, Avx2.Xor(lo256, hi256));

            // AES round 8 + extract to 128-bit for MODREDUCE
            rk = roundKeys[8];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            Vector128<ulong> lo = lo256.GetLower();
            Vector128<ulong> mid = mid256.GetLower();
            Vector128<ulong> hi = hi256.GetLower();

            // AES round 9 + GHASH MODREDUCE (2 CLMUL)
            rk = roundKeys[9];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            y = ModReduceClmul(lo, mid, hi);

            // AES remaining rounds for 192/256 key sizes
            for (int i = 10; i < rounds; i++)
            {
                rk = roundKeys[i];
                c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
                c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
                c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
                c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            }

            // AES last round
            rk = roundKeys[rounds];
            c0 = AesNi.EncryptLast(c0, rk); c1 = AesNi.EncryptLast(c1, rk);
            c2 = AesNi.EncryptLast(c2, rk); c3 = AesNi.EncryptLast(c3, rk);
            c4 = AesNi.EncryptLast(c4, rk); c5 = AesNi.EncryptLast(c5, rk);
            c6 = AesNi.EncryptLast(c6, rk); c7 = AesNi.EncryptLast(c7, rk);

            // XOR keystream with ciphertext to produce plaintext
            Sse2.Xor(ct0, c0).CopyTo(plaintext.Slice(offset));
            Sse2.Xor(ct1, c1).CopyTo(plaintext.Slice(offset + BlockSizeBytes));
            Sse2.Xor(ct2, c2).CopyTo(plaintext.Slice(offset + 2 * BlockSizeBytes));
            Sse2.Xor(ct3, c3).CopyTo(plaintext.Slice(offset + 3 * BlockSizeBytes));
            Sse2.Xor(ct4, c4).CopyTo(plaintext.Slice(offset + 4 * BlockSizeBytes));
            Sse2.Xor(ct5, c5).CopyTo(plaintext.Slice(offset + 5 * BlockSizeBytes));
            Sse2.Xor(ct6, c6).CopyTo(plaintext.Slice(offset + 6 * BlockSizeBytes));
            Sse2.Xor(ct7, c7).CopyTo(plaintext.Slice(offset + 7 * BlockSizeBytes));

            offset += 8 * BlockSizeBytes;
        }
        return offset;
    }
#endif

    /// <summary>
    /// PCLMUL128 stitched 8-block decrypt loop: 24 CLMUL + MODREDUCE interleaved with AES-NI rounds.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static int DecryptStitchedPclmul128Loop(
        ReadOnlySpan<Vector128<byte>> roundKeys, int rounds,
        ReadOnlySpan<Vector128<byte>> hPowers,
        ref Vector128<byte> counter, ref Vector128<byte> y,
        ReadOnlySpan<byte> ciphertext, Span<byte> plaintext,
        int offset, int len)
    {
        Vector128<ulong> h8 = hPowers[0].AsUInt64(); Vector128<ulong> h7 = hPowers[1].AsUInt64();
        Vector128<ulong> h6 = hPowers[2].AsUInt64(); Vector128<ulong> h5 = hPowers[3].AsUInt64();
        Vector128<ulong> h4 = hPowers[4].AsUInt64(); Vector128<ulong> h3 = hPowers[5].AsUInt64();
        Vector128<ulong> h2 = hPowers[6].AsUInt64(); Vector128<ulong> h1 = hPowers[7].AsUInt64();

        while (offset + 8 * BlockSizeBytes <= len)
        {
            var ct0 = Vector128.Create(ciphertext.Slice(offset, BlockSizeBytes));
            var ct1 = Vector128.Create(ciphertext.Slice(offset + BlockSizeBytes, BlockSizeBytes));
            var ct2 = Vector128.Create(ciphertext.Slice(offset + 2 * BlockSizeBytes, BlockSizeBytes));
            var ct3 = Vector128.Create(ciphertext.Slice(offset + 3 * BlockSizeBytes, BlockSizeBytes));
            var ct4 = Vector128.Create(ciphertext.Slice(offset + 4 * BlockSizeBytes, BlockSizeBytes));
            var ct5 = Vector128.Create(ciphertext.Slice(offset + 5 * BlockSizeBytes, BlockSizeBytes));
            var ct6 = Vector128.Create(ciphertext.Slice(offset + 6 * BlockSizeBytes, BlockSizeBytes));
            var ct7 = Vector128.Create(ciphertext.Slice(offset + 7 * BlockSizeBytes, BlockSizeBytes));

            Vector128<ulong> d0 = Sse2.Xor(y, Ssse3.Shuffle(ct0, ByteSwapMask)).AsUInt64();
            Vector128<ulong> d1 = Ssse3.Shuffle(ct1, ByteSwapMask).AsUInt64();
            Vector128<ulong> d2 = Ssse3.Shuffle(ct2, ByteSwapMask).AsUInt64();
            Vector128<ulong> d3 = Ssse3.Shuffle(ct3, ByteSwapMask).AsUInt64();
            Vector128<ulong> d4 = Ssse3.Shuffle(ct4, ByteSwapMask).AsUInt64();
            Vector128<ulong> d5 = Ssse3.Shuffle(ct5, ByteSwapMask).AsUInt64();
            Vector128<ulong> d6 = Ssse3.Shuffle(ct6, ByteSwapMask).AsUInt64();
            Vector128<ulong> d7 = Ssse3.Shuffle(ct7, ByteSwapMask).AsUInt64();

            GenerateCounterBlocks8(ref counter,
                out var c0, out var c1, out var c2, out var c3,
                out var c4, out var c5, out var c6, out var c7);

            // AES whitening (round 0)
            var rk = roundKeys[0];
            c0 = Sse2.Xor(c0, rk); c1 = Sse2.Xor(c1, rk);
            c2 = Sse2.Xor(c2, rk); c3 = Sse2.Xor(c3, rk);
            c4 = Sse2.Xor(c4, rk); c5 = Sse2.Xor(c5, rk);
            c6 = Sse2.Xor(c6, rk); c7 = Sse2.Xor(c7, rk);

            // AES round 1 + GHASH lo (blocks 0-3)
            rk = roundKeys[1];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            var lo = Pclmulqdq.CarrylessMultiply(h8.AsInt64(), d0.AsInt64(), 0x00).AsUInt64();
            lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h7.AsInt64(), d1.AsInt64(), 0x00).AsUInt64());
            lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h6.AsInt64(), d2.AsInt64(), 0x00).AsUInt64());
            lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h5.AsInt64(), d3.AsInt64(), 0x00).AsUInt64());

            // AES round 2 + GHASH lo (blocks 4-7)
            rk = roundKeys[2];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h4.AsInt64(), d4.AsInt64(), 0x00).AsUInt64());
            lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h3.AsInt64(), d5.AsInt64(), 0x00).AsUInt64());
            lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h2.AsInt64(), d6.AsInt64(), 0x00).AsUInt64());
            lo = Sse2.Xor(lo, Pclmulqdq.CarrylessMultiply(h1.AsInt64(), d7.AsInt64(), 0x00).AsUInt64());

            // AES round 3 + GHASH hi (blocks 0-3)
            rk = roundKeys[3];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            var hi = Pclmulqdq.CarrylessMultiply(h8.AsInt64(), d0.AsInt64(), 0x11).AsUInt64();
            hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h7.AsInt64(), d1.AsInt64(), 0x11).AsUInt64());
            hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h6.AsInt64(), d2.AsInt64(), 0x11).AsUInt64());
            hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h5.AsInt64(), d3.AsInt64(), 0x11).AsUInt64());

            // AES round 4 + GHASH hi (blocks 4-7)
            rk = roundKeys[4];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h4.AsInt64(), d4.AsInt64(), 0x11).AsUInt64());
            hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h3.AsInt64(), d5.AsInt64(), 0x11).AsUInt64());
            hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h2.AsInt64(), d6.AsInt64(), 0x11).AsUInt64());
            hi = Sse2.Xor(hi, Pclmulqdq.CarrylessMultiply(h1.AsInt64(), d7.AsInt64(), 0x11).AsUInt64());

            // AES round 5 + GHASH cross (Karatsuba, blocks 0-3)
            rk = roundKeys[5];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            Vector128<ulong> ht, dt;
            ht = Sse2.Xor(Sse2.Shuffle(h8.AsUInt32(), 0x4E).AsUInt64(), h8);
            dt = Sse2.Xor(Sse2.Shuffle(d0.AsUInt32(), 0x4E).AsUInt64(), d0);
            var mid = Pclmulqdq.CarrylessMultiply(ht.AsInt64(), dt.AsInt64(), 0x00).AsUInt64();
            ht = Sse2.Xor(Sse2.Shuffle(h7.AsUInt32(), 0x4E).AsUInt64(), h7);
            dt = Sse2.Xor(Sse2.Shuffle(d1.AsUInt32(), 0x4E).AsUInt64(), d1);
            mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(ht.AsInt64(), dt.AsInt64(), 0x00).AsUInt64());
            ht = Sse2.Xor(Sse2.Shuffle(h6.AsUInt32(), 0x4E).AsUInt64(), h6);
            dt = Sse2.Xor(Sse2.Shuffle(d2.AsUInt32(), 0x4E).AsUInt64(), d2);
            mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(ht.AsInt64(), dt.AsInt64(), 0x00).AsUInt64());
            ht = Sse2.Xor(Sse2.Shuffle(h5.AsUInt32(), 0x4E).AsUInt64(), h5);
            dt = Sse2.Xor(Sse2.Shuffle(d3.AsUInt32(), 0x4E).AsUInt64(), d3);
            mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(ht.AsInt64(), dt.AsInt64(), 0x00).AsUInt64());

            // AES round 6 + GHASH cross (blocks 4-7)
            rk = roundKeys[6];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            ht = Sse2.Xor(Sse2.Shuffle(h4.AsUInt32(), 0x4E).AsUInt64(), h4);
            dt = Sse2.Xor(Sse2.Shuffle(d4.AsUInt32(), 0x4E).AsUInt64(), d4);
            mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(ht.AsInt64(), dt.AsInt64(), 0x00).AsUInt64());
            ht = Sse2.Xor(Sse2.Shuffle(h3.AsUInt32(), 0x4E).AsUInt64(), h3);
            dt = Sse2.Xor(Sse2.Shuffle(d5.AsUInt32(), 0x4E).AsUInt64(), d5);
            mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(ht.AsInt64(), dt.AsInt64(), 0x00).AsUInt64());
            ht = Sse2.Xor(Sse2.Shuffle(h2.AsUInt32(), 0x4E).AsUInt64(), h2);
            dt = Sse2.Xor(Sse2.Shuffle(d6.AsUInt32(), 0x4E).AsUInt64(), d6);
            mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(ht.AsInt64(), dt.AsInt64(), 0x00).AsUInt64());
            ht = Sse2.Xor(Sse2.Shuffle(h1.AsUInt32(), 0x4E).AsUInt64(), h1);
            dt = Sse2.Xor(Sse2.Shuffle(d7.AsUInt32(), 0x4E).AsUInt64(), d7);
            mid = Sse2.Xor(mid, Pclmulqdq.CarrylessMultiply(ht.AsInt64(), dt.AsInt64(), 0x00).AsUInt64());

            // AES round 7 + GHASH fold cross terms (CLMUL_3_POST)
            rk = roundKeys[7];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            mid = Sse2.Xor(mid, lo);
            mid = Sse2.Xor(mid, hi);

            // AES round 8 + GHASH MODREDUCE step 1
            rk = roundKeys[8];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            var vMul = Vector128.Create(GcmReductionConstant, 0UL).AsInt64();
            var t0 = Pclmulqdq.CarrylessMultiply(lo.AsInt64(), vMul, 0x00).AsUInt64();
            lo = Sse2.Shuffle(lo.AsUInt32(), 0x4E).AsUInt64();
            mid = Sse2.Xor(mid, t0);
            mid = Sse2.Xor(mid, lo);

            // AES round 9 + GHASH MODREDUCE step 2
            rk = roundKeys[9];
            c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
            c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
            c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
            c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            t0 = Pclmulqdq.CarrylessMultiply(
                Sse2.ShiftLeftLogical(mid, 1).AsInt64(), vMul, 0x00).AsUInt64();
            mid = Sse2.Shuffle(mid.AsUInt32(), 0x4E).AsUInt64();
            var res = Sse2.Xor(hi, mid);

            // AES remaining rounds for 192/256 key sizes
            for (int i = 10; i < rounds; i++)
            {
                rk = roundKeys[i];
                c0 = AesNi.Encrypt(c0, rk); c1 = AesNi.Encrypt(c1, rk);
                c2 = AesNi.Encrypt(c2, rk); c3 = AesNi.Encrypt(c3, rk);
                c4 = AesNi.Encrypt(c4, rk); c5 = AesNi.Encrypt(c5, rk);
                c6 = AesNi.Encrypt(c6, rk); c7 = AesNi.Encrypt(c7, rk);
            }

            // AES last round + GHASH final reduction (rotate left by 1)
            rk = roundKeys[rounds];
            c0 = AesNi.EncryptLast(c0, rk); c1 = AesNi.EncryptLast(c1, rk);
            c2 = AesNi.EncryptLast(c2, rk); c3 = AesNi.EncryptLast(c3, rk);
            c4 = AesNi.EncryptLast(c4, rk); c5 = AesNi.EncryptLast(c5, rk);
            c6 = AesNi.EncryptLast(c6, rk); c7 = AesNi.EncryptLast(c7, rk);
            var t1 = Sse2.ShiftLeftLogical(res.AsUInt32(), 1).AsUInt64();
            res = Sse2.ShiftRightLogical(res.AsUInt32(), 31).AsUInt64();
            t0 = Sse2.Xor(t0, t1);
            res = Sse2.Shuffle(res.AsUInt32(), 0x93).AsUInt64();
            y = Sse2.Xor(res, t0).AsByte();

            // XOR keystream with ciphertext to produce plaintext
            Sse2.Xor(ct0, c0).CopyTo(plaintext.Slice(offset));
            Sse2.Xor(ct1, c1).CopyTo(plaintext.Slice(offset + BlockSizeBytes));
            Sse2.Xor(ct2, c2).CopyTo(plaintext.Slice(offset + 2 * BlockSizeBytes));
            Sse2.Xor(ct3, c3).CopyTo(plaintext.Slice(offset + 3 * BlockSizeBytes));
            Sse2.Xor(ct4, c4).CopyTo(plaintext.Slice(offset + 4 * BlockSizeBytes));
            Sse2.Xor(ct5, c5).CopyTo(plaintext.Slice(offset + 5 * BlockSizeBytes));
            Sse2.Xor(ct6, c6).CopyTo(plaintext.Slice(offset + 6 * BlockSizeBytes));
            Sse2.Xor(ct7, c7).CopyTo(plaintext.Slice(offset + 7 * BlockSizeBytes));

            offset += 8 * BlockSizeBytes;
        }
        return offset;
    }
#endif
}
