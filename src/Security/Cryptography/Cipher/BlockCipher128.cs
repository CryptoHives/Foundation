// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.InteropServices;

/// <summary>
/// The forward direction of a keyed 128-bit block cipher, which is all that GCM and CCM need.
/// </summary>
internal abstract class BlockCipher128
{
    /// <summary>The block size in bytes.</summary>
    public const int BlockSizeBytes = 16;

    /// <summary>Gets the algorithm name used to compose mode names, e.g. <c>SM4</c>.</summary>
    public abstract string Name { get; }

    /// <summary>Encrypts one 16-byte block. <paramref name="input"/> and <paramref name="output"/> must not overlap.</summary>
    public abstract void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output);

    /// <summary>Erases the key schedule.</summary>
    public abstract void Clear();

    /// <summary>Returns the forward cipher for <paramref name="algorithm"/> keyed with <paramref name="key"/>.</summary>
    public static BlockCipher128 Create(BlockCipher128Algorithm algorithm, ReadOnlySpan<byte> key) => algorithm switch
    {
        BlockCipher128Algorithm.Aria => new AriaBlockCipher(key),
        BlockCipher128Algorithm.Camellia => new CamelliaBlockCipher(key),
        BlockCipher128Algorithm.Kuznyechik => new KuznyechikBlockCipher(key),
        BlockCipher128Algorithm.Seed => new SeedBlockCipher(key),
        BlockCipher128Algorithm.Sm4 => new Sm4BlockCipher(key),
        _ => throw new ArgumentOutOfRangeException(nameof(algorithm)),
    };

    private sealed class AriaBlockCipher : BlockCipher128
    {
        private readonly byte[] _roundKeys = new byte[17 * BlockSizeBytes];
        private readonly int _rounds;

        public AriaBlockCipher(ReadOnlySpan<byte> key)
        {
            RequireKeySize(key, 16, 24, 32);
            _rounds = AriaCore.ExpandKey(key, _roundKeys);
        }

        public override string Name => "ARIA";

        public override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
            => AriaCore.EncryptBlock(input, output, _roundKeys, _rounds);

        public override void Clear() => CryptographicOperations.ZeroMemory(_roundKeys);
    }

    private sealed class CamelliaBlockCipher : BlockCipher128
    {
        private readonly ulong[] _subkeys = new ulong[CamelliaCore.MaxSubkeys];
        private readonly int _rounds;

        public CamelliaBlockCipher(ReadOnlySpan<byte> key)
        {
            RequireKeySize(key, 16, 24, 32);
            _rounds = CamelliaCore.ExpandKey(key, _subkeys);
        }

        public override string Name => "Camellia";

        public override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
            => CamelliaCore.EncryptBlock(input, output, _subkeys, _rounds);

        public override void Clear() => CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(_subkeys.AsSpan()));
    }

    private sealed class KuznyechikBlockCipher : BlockCipher128
    {
        private readonly ulong[] _encryptKeys = new ulong[KuznyechikCore.RoundKeyWordCount];

        public KuznyechikBlockCipher(ReadOnlySpan<byte> key)
        {
            RequireKeySize(key, KuznyechikCore.KeySizeBytes);
            Span<ulong> decryptKeys = stackalloc ulong[KuznyechikCore.RoundKeyWordCount];
            KuznyechikCore.ExpandKeySchedules(key, _encryptKeys, decryptKeys);
            CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(decryptKeys));
        }

        public override string Name => "Kuznyechik";

        public override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
            => KuznyechikCore.EncryptBlock(input, output, _encryptKeys);

        public override void Clear() => CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(_encryptKeys.AsSpan()));
    }

    private sealed class SeedBlockCipher : BlockCipher128
    {
        private readonly uint[] _roundKeys = new uint[SeedCore.RoundKeyWords];

        public SeedBlockCipher(ReadOnlySpan<byte> key)
        {
            RequireKeySize(key, 16);
            SeedCore.ExpandKey(key, _roundKeys);
        }

        public override string Name => "SEED";

        public override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
            => SeedCore.EncryptBlock(input, output, _roundKeys);

        public override void Clear() => CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(_roundKeys.AsSpan()));
    }

    private sealed class Sm4BlockCipher : BlockCipher128
    {
        // Sm4Core is a mutable struct holding a fixed buffer; it must not be readonly.
        private Sm4Core _core;

        public Sm4BlockCipher(ReadOnlySpan<byte> key)
        {
            RequireKeySize(key, 16);
            _core = new Sm4Core(key);
        }

        public override string Name => "SM4";

        public override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
            => _core.EncryptBlock(input, output);

        public override void Clear() => _core.Clear();
    }

    private static void RequireKeySize(ReadOnlySpan<byte> key, params int[] validSizes)
    {
        if (Array.IndexOf(validSizes, key.Length) < 0)
        {
            throw new ArgumentException(
                $"Key must be {string.Join(", ", validSizes)} bytes.", nameof(key));
        }
    }
}

/// <summary>
/// The 128-bit block ciphers that can run under <see cref="GcmCipher"/> and <see cref="CcmCipher"/>.
/// </summary>
internal enum BlockCipher128Algorithm
{
    Aria,
    Camellia,
    Kuznyechik,
    Seed,
    Sm4,
}
