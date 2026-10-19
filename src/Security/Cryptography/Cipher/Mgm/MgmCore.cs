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
using ArmAes = System.Runtime.Intrinsics.Arm.Aes;
#endif

/// <summary>
/// MGM, the Multilinear Galois Mode of RFC 9058 (R 1323565.1.026-2019), over a 128-bit block cipher.
/// </summary>
/// <remarks>
/// Unlike GHASH, every block is multiplied by a fresh key-derived H, so nothing can be precomputed,
/// and the field elements are not bit-reflected. Products are summed unreduced and reduced once.
/// </remarks>
internal struct MgmCore
{
    /// <summary>The block size in bytes.</summary>
    public const int BlockSizeBytes = BlockCipher128.BlockSizeBytes;

    /// <summary>The nonce size in bytes; its top bit must be clear.</summary>
    public const int NonceSizeBytes = BlockSizeBytes;

    /// <summary>The shortest tag RFC 9058 allows, 32 bits.</summary>
    public const int MinTagSizeBytes = 4;

    /// <summary>The longest tag, one block.</summary>
    public const int MaxTagSizeBytes = BlockSizeBytes;

    private readonly BlockCipher128 _blockCipher;
#if NET8_0_OR_GREATER
    private readonly bool _usePclmul;
    private readonly bool _usePmull;
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="MgmCore"/> struct.
    /// </summary>
    /// <param name="simdSupport">The carry-less multiply instructions to use.</param>
    /// <param name="blockCipher">The keyed block cipher; <see cref="Clear"/> erases it.</param>
    public MgmCore(SimdSupport simdSupport, BlockCipher128 blockCipher)
    {
        _blockCipher = blockCipher ?? throw new ArgumentNullException(nameof(blockCipher));
#if NET8_0_OR_GREATER
        simdSupport &= SimdSupport;
        _usePclmul = (simdSupport & SimdSupport.PClMul) != 0;
        _usePmull = (simdSupport & SimdSupport.ArmPmull) != 0;
#endif
    }

    /// <summary>
    /// Gets the carry-less multiply instructions MGM can use on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport =>
#if NET8_0_OR_GREATER
        (Pclmulqdq.IsSupported ? SimdSupport.PClMul : SimdSupport.None) |
        (ArmAes.IsSupported ? SimdSupport.ArmPmull : SimdSupport.None);
#else
        SimdSupport.None;
#endif

    /// <summary>
    /// Erases the block cipher's key schedule.
    /// </summary>
    public readonly void Clear() => _blockCipher.Clear();

    /// <summary>
    /// Encrypts <paramref name="plaintext"/> and computes a tag the length of <paramref name="tag"/>.
    /// </summary>
    public readonly void Encrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext, ReadOnlySpan<byte> associatedData,
        Span<byte> ciphertext, Span<byte> tag)
    {
        ApplyKeystream(nonce, plaintext, ciphertext);

        Span<byte> fullTag = stackalloc byte[BlockSizeBytes];
        ComputeTag(nonce, associatedData, ciphertext.Slice(0, plaintext.Length), fullTag);
        fullTag.Slice(0, tag.Length).CopyTo(tag);
        CryptographicOperations.ZeroMemory(fullTag);
    }

    /// <summary>
    /// Verifies <paramref name="tag"/> over the ciphertext and, only if it matches, decrypts it.
    /// </summary>
    /// <returns><see langword="true"/> if the tag matched; otherwise <paramref name="plaintext"/> is left untouched.</returns>
    public readonly bool Decrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext, ReadOnlySpan<byte> tag,
        ReadOnlySpan<byte> associatedData, Span<byte> plaintext)
    {
        Span<byte> expectedTag = stackalloc byte[BlockSizeBytes];
        ComputeTag(nonce, associatedData, ciphertext, expectedTag);
        bool valid = CryptographicOperations.FixedTimeEquals(tag, expectedTag.Slice(0, tag.Length));
        CryptographicOperations.ZeroMemory(expectedTag);

        if (valid)
        {
            ApplyKeystream(nonce, ciphertext, plaintext);
        }

        return valid;
    }

    /// <summary>
    /// XORs the keystream E(Y_1), E(Y_2), ... into <paramref name="output"/>, with Y_1 = E(0 || ICN)
    /// and the right half of Y counting up.
    /// </summary>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private readonly void ApplyKeystream(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (input.Length == 0)
        {
            return;
        }

        Span<byte> counter = stackalloc byte[BlockSizeBytes];
        Span<byte> keystream = stackalloc byte[BlockSizeBytes];

        _blockCipher.EncryptBlock(nonce, counter);
        ulong left = BinaryPrimitives.ReadUInt64BigEndian(counter);
        ulong right = BinaryPrimitives.ReadUInt64BigEndian(counter.Slice(sizeof(ulong)));

        int offset = 0;
        while (offset < input.Length)
        {
            BinaryPrimitives.WriteUInt64BigEndian(counter, left);
            BinaryPrimitives.WriteUInt64BigEndian(counter.Slice(sizeof(ulong)), right++);
            _blockCipher.EncryptBlock(counter, keystream);

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

            offset += BlockSizeBytes;
        }

        CryptographicOperations.ZeroMemory(keystream);
    }

    /// <summary>
    /// Computes the full-block tag E(Σ H_i ⊗ A_i ⊕ Σ H_j ⊗ C_j ⊕ H ⊗ (len(A) || len(C))), with
    /// Z_1 = E(1 || ICN), H_i = E(Z_i) and the left half of Z counting up.
    /// </summary>
    [SkipLocalsInit]
    private readonly void ComputeTag(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> associatedData, ReadOnlySpan<byte> ciphertext, Span<byte> tag)
    {
        Span<byte> block = stackalloc byte[BlockSizeBytes];
        Span<byte> h = stackalloc byte[BlockSizeBytes];

        nonce.CopyTo(block);
        block[0] |= 0x80;
        _blockCipher.EncryptBlock(block, h);
        var state = new TagState(
            BinaryPrimitives.ReadUInt64BigEndian(h),
            BinaryPrimitives.ReadUInt64BigEndian(h.Slice(sizeof(ulong))));

        Absorb(ref state, associatedData, block, h);
        Absorb(ref state, ciphertext, block, h);
        AbsorbBlock(ref state, (ulong)associatedData.Length * 8, (ulong)ciphertext.Length * 8, block, h);

        Reduce(state.A3, state.A2, state.A1, state.A0, out ulong sumLeft, out ulong sumRight);
        BinaryPrimitives.WriteUInt64BigEndian(block, sumLeft);
        BinaryPrimitives.WriteUInt64BigEndian(block.Slice(sizeof(ulong)), sumRight);
        _blockCipher.EncryptBlock(block, tag);

        CryptographicOperations.ZeroMemory(h);
        CryptographicOperations.ZeroMemory(block);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private readonly void Absorb(ref TagState state, ReadOnlySpan<byte> data, Span<byte> block, Span<byte> h)
    {
        int offset = 0;
        for (; offset + BlockSizeBytes <= data.Length; offset += BlockSizeBytes)
        {
            AbsorbBlock(
                ref state,
                BinaryPrimitives.ReadUInt64BigEndian(data.Slice(offset)),
                BinaryPrimitives.ReadUInt64BigEndian(data.Slice(offset + sizeof(ulong))),
                block, h);
        }

        if (offset < data.Length)
        {
            BinaryLoad.ReadUInt64PairBigEndianPadded(data.Slice(offset), out ulong left, out ulong right);
            AbsorbBlock(ref state, left, right, block, h);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly void AbsorbBlock(ref TagState state, ulong left, ulong right, Span<byte> block, Span<byte> h)
    {
        BinaryPrimitives.WriteUInt64BigEndian(block, state.ZLeft++);
        BinaryPrimitives.WriteUInt64BigEndian(block.Slice(sizeof(ulong)), state.ZRight);
        _blockCipher.EncryptBlock(block, h);

        MultiplyAccumulate(
            BinaryPrimitives.ReadUInt64BigEndian(h),
            BinaryPrimitives.ReadUInt64BigEndian(h.Slice(sizeof(ulong))),
            left, right, ref state);
    }

    /// <summary>
    /// Adds the unreduced 256-bit product of two field elements to the running sum (Karatsuba).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly void MultiplyAccumulate(ulong xHi, ulong xLo, ulong yHi, ulong yLo, ref TagState state)
    {
        CarrylessMultiply(xLo, yLo, out ulong lo1, out ulong lo0);
        CarrylessMultiply(xHi, yHi, out ulong hi1, out ulong hi0);
        CarrylessMultiply(xHi ^ xLo, yHi ^ yLo, out ulong mid1, out ulong mid0);
        mid1 ^= lo1 ^ hi1;
        mid0 ^= lo0 ^ hi0;

        state.A0 ^= lo0;
        state.A1 ^= lo1 ^ mid0;
        state.A2 ^= hi0 ^ mid1;
        state.A3 ^= hi1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly void CarrylessMultiply(ulong a, ulong b, out ulong hi, out ulong lo)
    {
#if NET8_0_OR_GREATER
        if (_usePclmul && Pclmulqdq.IsSupported)
        {
            Vector128<ulong> product = Pclmulqdq.CarrylessMultiply(Vector128.CreateScalar(a), Vector128.CreateScalar(b), 0x00);
            lo = product.GetElement(0);
            hi = product.GetElement(1);
            return;
        }

        if (_usePmull && ArmAes.IsSupported)
        {
            Vector128<ulong> product = ArmAes.PolynomialMultiplyWideningLower(Vector64.Create(a), Vector64.Create(b));
            lo = product.GetElement(0);
            hi = product.GetElement(1);
            return;
        }
#endif
        lo = CarrylessMultiplyLow(a, b);
        hi = ReverseBits(CarrylessMultiplyLow(ReverseBits(a), ReverseBits(b))) >> 1;
    }

    /// <summary>
    /// The low 64 bits of a carry-less product, built from integer multiplies with 3-bit holes
    /// between the data bits so that the carries never reach a bit that is kept.
    /// </summary>
    /// <remarks>
    /// Constant time wherever integer multiplication is, as on every 64-bit CPU .NET supports.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong CarrylessMultiplyLow(ulong x, ulong y)
    {
        const ulong M0 = 0x1111111111111111, M1 = M0 << 1, M2 = M0 << 2, M3 = M0 << 3;

        ulong x0 = x & M0, x1 = x & M1, x2 = x & M2, x3 = x & M3;
        ulong y0 = y & M0, y1 = y & M1, y2 = y & M2, y3 = y & M3;

        ulong z0 = (x0 * y0) ^ (x1 * y3) ^ (x2 * y2) ^ (x3 * y1);
        ulong z1 = (x0 * y1) ^ (x1 * y0) ^ (x2 * y3) ^ (x3 * y2);
        ulong z2 = (x0 * y2) ^ (x1 * y1) ^ (x2 * y0) ^ (x3 * y3);
        ulong z3 = (x0 * y3) ^ (x1 * y2) ^ (x2 * y1) ^ (x3 * y0);

        return (z0 & M0) | (z1 & M1) | (z2 & M2) | (z3 & M3);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong ReverseBits(ulong x)
    {
        x = ((x >> 1) & 0x5555555555555555) | ((x & 0x5555555555555555) << 1);
        x = ((x >> 2) & 0x3333333333333333) | ((x & 0x3333333333333333) << 2);
        x = ((x >> 4) & 0x0F0F0F0F0F0F0F0F) | ((x & 0x0F0F0F0F0F0F0F0F) << 4);
        return BinaryPrimitives.ReverseEndianness(x);
    }

    /// <summary>
    /// Reduces a 256-bit polynomial modulo w^128 + w^7 + w^2 + w + 1.
    /// </summary>
    private static void Reduce(ulong a3, ulong a2, ulong a1, ulong a0, out ulong hi, out ulong lo)
    {
        // w^128 ≡ w^7 + w^2 + w + 1; the bits that fold past w^127 fold once more.
        ulong overflow = (a3 >> 57) ^ (a3 >> 62) ^ (a3 >> 63);
        hi = a1 ^ a3 ^ ((a3 << 1) | (a2 >> 63)) ^ ((a3 << 2) | (a2 >> 62)) ^ ((a3 << 7) | (a2 >> 57));
        lo = a0 ^ a2 ^ (a2 << 1) ^ (a2 << 2) ^ (a2 << 7)
            ^ overflow ^ (overflow << 1) ^ (overflow << 2) ^ (overflow << 7);
    }

    private struct TagState(ulong zLeft, ulong zRight)
    {
        public ulong ZLeft = zLeft;
        public readonly ulong ZRight = zRight;
        public ulong A3;
        public ulong A2;
        public ulong A1;
        public ulong A0;
    }
}
