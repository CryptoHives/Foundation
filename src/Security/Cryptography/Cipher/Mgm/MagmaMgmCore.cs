// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// MGM (RFC 9058) over the 64-bit Magma block cipher: 32-bit counter halves, the field
/// GF(2^64) modulo w^64 + w^4 + w^3 + w + 1, and 32-bit lengths.
/// </summary>
/// <remarks>
/// Every block is a big-endian <see cref="UInt64"/>, so the whole mode runs in registers. As in
/// <see cref="MgmCore"/>, products are summed unreduced and reduced once.
/// </remarks>
internal struct MagmaMgmCore
{
    /// <summary>The block size in bytes.</summary>
    public const int BlockSizeBytes = MagmaCore.BlockSizeBytes;

    /// <summary>The nonce size in bytes; its top bit must be clear.</summary>
    public const int NonceSizeBytes = BlockSizeBytes;

    /// <summary>The shortest tag RFC 9058 allows, 32 bits.</summary>
    public const int MinTagSizeBytes = 4;

    /// <summary>The longest tag, one block.</summary>
    public const int MaxTagSizeBytes = BlockSizeBytes;

    /// <summary>
    /// RFC 9058 requires |A| + |P| &lt; 2^32 bits for a 64-bit block cipher.
    /// </summary>
    public const long MaxTotalBytes = (1L << 29) - 1;

    private readonly uint[] _roundKeys;
    private readonly CarrylessMultiplier _multiplier;

    /// <summary>
    /// Initializes a new instance of the <see cref="MagmaMgmCore"/> struct.
    /// </summary>
    /// <param name="simdSupport">The carry-less multiply instructions to use.</param>
    /// <param name="key">The 32-byte Magma key.</param>
    public MagmaMgmCore(SimdSupport simdSupport, ReadOnlySpan<byte> key)
    {
        _roundKeys = new uint[MagmaCore.RoundKeyCount];
        MagmaCore.ExpandKey(key, _roundKeys);
        _multiplier = new CarrylessMultiplier(simdSupport);
    }

    /// <summary>
    /// Erases the key schedule.
    /// </summary>
    public readonly void Clear() => CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(_roundKeys.AsSpan()));

    /// <summary>
    /// Encrypts <paramref name="plaintext"/> and computes a tag the length of <paramref name="tag"/>.
    /// </summary>
    public readonly void Encrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext, ReadOnlySpan<byte> associatedData,
        Span<byte> ciphertext, Span<byte> tag)
    {
        ulong icn = BinaryPrimitives.ReadUInt64BigEndian(nonce);
        ApplyKeystream(icn, plaintext, ciphertext);
        ulong fullTag = ComputeTag(icn, associatedData, ciphertext.Slice(0, plaintext.Length));
        BinaryStore.WriteUInt64BigEndianTruncated(fullTag, tag);
    }

    /// <summary>
    /// Verifies <paramref name="tag"/> over the ciphertext and, only if it matches, decrypts it.
    /// </summary>
    /// <returns><see langword="true"/> if the tag matched; otherwise <paramref name="plaintext"/> is left untouched.</returns>
    [SkipLocalsInit]
    public readonly bool Decrypt(
        ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext, ReadOnlySpan<byte> tag,
        ReadOnlySpan<byte> associatedData, Span<byte> plaintext)
    {
        ulong icn = BinaryPrimitives.ReadUInt64BigEndian(nonce);
        Span<byte> expectedTag = stackalloc byte[BlockSizeBytes];
        BinaryPrimitives.WriteUInt64BigEndian(expectedTag, ComputeTag(icn, associatedData, ciphertext));
        bool valid = CryptographicOperations.FixedTimeEquals(tag, expectedTag.Slice(0, tag.Length));
        CryptographicOperations.ZeroMemory(expectedTag);

        if (valid)
        {
            ApplyKeystream(icn, ciphertext, plaintext);
        }

        return valid;
    }

    /// <summary>
    /// XORs the keystream E(Y_1), E(Y_2), ... into <paramref name="output"/>, with Y_1 = E(0 || ICN)
    /// and the right half of Y counting up.
    /// </summary>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private readonly void ApplyKeystream(ulong icn, ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (input.Length == 0)
        {
            return;
        }

        ulong y = MagmaCore.Encrypt(icn, _roundKeys);
        int offset = 0;
        for (; offset + BlockSizeBytes <= input.Length; offset += BlockSizeBytes)
        {
            ulong keystream = MagmaCore.Encrypt(y, _roundKeys);
            BinaryPrimitives.WriteUInt64BigEndian(
                output.Slice(offset),
                BinaryPrimitives.ReadUInt64BigEndian(input.Slice(offset)) ^ keystream);
            y = IncrementRight(y);
        }

        if (offset < input.Length)
        {
            ulong keystream = MagmaCore.Encrypt(y, _roundKeys);
            BinaryStore.WriteUInt64BigEndianTruncated(
                BinaryLoad.ReadUInt64BigEndianPadded(input.Slice(offset)) ^ keystream,
                output.Slice(offset, input.Length - offset));
        }
    }

    /// <summary>
    /// Computes the full-block tag, with Z_1 = E(1 || ICN), H_i = E(Z_i) and the left half of Z counting up.
    /// </summary>
    private readonly ulong ComputeTag(ulong icn, ReadOnlySpan<byte> associatedData, ReadOnlySpan<byte> ciphertext)
    {
        ulong z = MagmaCore.Encrypt(icn | (1UL << 63), _roundKeys);
        ulong sumHi = 0, sumLo = 0;

        Absorb(associatedData, ref z, ref sumHi, ref sumLo);
        Absorb(ciphertext, ref z, ref sumHi, ref sumLo);
        AbsorbBlock(((ulong)associatedData.Length * 8 << 32) | ((ulong)ciphertext.Length * 8), ref z, ref sumHi, ref sumLo);

        return MagmaCore.Encrypt(Reduce(sumHi, sumLo), _roundKeys);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private readonly void Absorb(ReadOnlySpan<byte> data, ref ulong z, ref ulong sumHi, ref ulong sumLo)
    {
        int offset = 0;
        for (; offset + BlockSizeBytes <= data.Length; offset += BlockSizeBytes)
        {
            AbsorbBlock(BinaryPrimitives.ReadUInt64BigEndian(data.Slice(offset)), ref z, ref sumHi, ref sumLo);
        }

        if (offset < data.Length)
        {
            AbsorbBlock(BinaryLoad.ReadUInt64BigEndianPadded(data.Slice(offset)), ref z, ref sumHi, ref sumLo);
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private readonly void AbsorbBlock(ulong block, ref ulong z, ref ulong sumHi, ref ulong sumLo)
    {
        _multiplier.Multiply(MagmaCore.Encrypt(z, _roundKeys), block, out ulong hi, out ulong lo);
        sumHi ^= hi;
        sumLo ^= lo;
        z = IncrementLeft(z);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static ulong IncrementRight(ulong value) => (value & 0xFFFFFFFF00000000) | (uint)((uint)value + 1);

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static ulong IncrementLeft(ulong value) => ((ulong)((uint)(value >> 32) + 1) << 32) | (uint)value;

    /// <summary>
    /// Reduces a 128-bit polynomial modulo w^64 + w^4 + w^3 + w + 1.
    /// </summary>
    private static ulong Reduce(ulong hi, ulong lo)
    {
        // w^64 ≡ w^4 + w^3 + w + 1; the bits that fold past w^63 fold once more.
        ulong overflow = (hi >> 60) ^ (hi >> 61) ^ (hi >> 63);
        return lo ^ hi ^ (hi << 1) ^ (hi << 3) ^ (hi << 4)
            ^ overflow ^ (overflow << 1) ^ (overflow << 3) ^ (overflow << 4);
    }
}
