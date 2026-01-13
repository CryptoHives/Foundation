// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1814 // Prefer jagged arrays - Sigma is a fixed-size cryptographic constant where multidimensional is clearer
#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the BLAKE2b hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// BLAKE2b is optimized for 64-bit platforms and produces digests from 1 to 64 bytes.
/// The default output size is 64 bytes (512 bits).
/// </para>
/// <para>
/// BLAKE2b supports an optional key for keyed hashing (MAC mode) with keys up to 64 bytes.
/// </para>
/// </remarks>
public sealed class Blake2b : HashAlgorithm
{
    /// <summary>
    /// The maximum hash size in bits.
    /// </summary>
    public const int MaxHashSizeBits = 512;

    /// <summary>
    /// The maximum hash size in bytes.
    /// </summary>
    public const int MaxHashSizeBytes = MaxHashSizeBits / 8;

    /// <summary>
    /// The maximum key size in bytes.
    /// </summary>
    public const int MaxKeySizeBytes = 64;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 128;

    // BLAKE2b IV constants (same as SHA-512)
    private static readonly ulong[] IV =
    [
        0x6a09e667f3bcc908UL,
        0xbb67ae8584caa73bUL,
        0x3c6ef372fe94f82bUL,
        0xa54ff53a5f1d36f1UL,
        0x510e527fade682d1UL,
        0x9b05688c2b3e6c1fUL,
        0x1f83d9abfb41bd6bUL,
        0x5be0cd19137e2179UL
    ];

    // BLAKE2b sigma permutations for message scheduling
    private static readonly byte[,] Sigma = new byte[12, 16]
    {
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 },
        { 14, 10, 4, 8, 9, 15, 13, 6, 1, 12, 0, 2, 11, 7, 5, 3 },
        { 11, 8, 12, 0, 5, 2, 15, 13, 10, 14, 3, 6, 7, 1, 9, 4 },
        { 7, 9, 3, 1, 13, 12, 11, 14, 2, 6, 5, 10, 4, 0, 15, 8 },
        { 9, 0, 5, 7, 2, 4, 10, 15, 14, 1, 11, 12, 6, 8, 3, 13 },
        { 2, 12, 6, 10, 0, 11, 8, 3, 4, 13, 7, 5, 15, 14, 1, 9 },
        { 12, 5, 1, 15, 14, 13, 4, 10, 0, 7, 6, 3, 9, 2, 8, 11 },
        { 13, 11, 7, 14, 12, 1, 3, 9, 5, 0, 15, 4, 8, 6, 2, 10 },
        { 6, 15, 14, 9, 11, 3, 0, 8, 12, 2, 13, 7, 1, 4, 10, 5 },
        { 10, 2, 8, 4, 7, 6, 1, 5, 15, 11, 9, 14, 3, 12, 13, 0 },
        { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 },
        { 14, 10, 4, 8, 9, 15, 13, 6, 1, 12, 0, 2, 11, 7, 5, 3 }
    };

    private readonly ulong[] _state;
    private readonly byte[] _buffer;
    private readonly byte[]? _key;
    private readonly int _outputBytes;
    private ulong _bytesCompressed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with default output size (64 bytes).
    /// </summary>
    public Blake2b() : this(MaxHashSizeBytes, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    public Blake2b(int outputBytes) : this(outputBytes, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size and key.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-64 bytes.</param>
    public Blake2b(int outputBytes, byte[]? key)
    {
        if (outputBytes < 1 || outputBytes > MaxHashSizeBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes),
                $"Output size must be between 1 and {MaxHashSizeBytes} bytes.");
        }

        if (key != null && key.Length > MaxKeySizeBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(key),
                $"Key size must be between 0 and {MaxKeySizeBytes} bytes.");
        }

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _state = new ulong[8];
        _buffer = new byte[BlockSizeBytes];

        if (key != null && key.Length > 0)
        {
            _key = new byte[key.Length];
            Array.Copy(key, _key, key.Length);
        }

        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _key != null ? "BLAKE2b-MAC" : "BLAKE2b";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets a value indicating whether this instance is configured for keyed hashing (MAC mode).
    /// </summary>
    public bool IsKeyed => _key != null;

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with default output size.
    /// </summary>
    /// <returns>A new BLAKE2b instance.</returns>
    public static new Blake2b Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <returns>A new BLAKE2b instance.</returns>
    public static Blake2b Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The key for keyed hashing (up to 64 bytes).</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    public static Blake2b CreateKeyed(int outputBytes, byte[] key) => new(outputBytes, key);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class with default output size.
    /// </summary>
    /// <param name="key">The key for keyed hashing (up to 64 bytes).</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    public static Blake2b CreateKeyed(byte[] key) => new(MaxHashSizeBytes, key);

    /// <inheritdoc/>
    public override void Initialize()
    {
        // Copy IV to state
        Array.Copy(IV, _state, 8);

        // XOR first word with parameter block: 0x01010000 | (kk << 8) | nn
        int keyLength = _key?.Length ?? 0;
        _state[0] ^= 0x01010000UL | ((ulong)keyLength << 8) | (uint)_outputBytes;

        _bytesCompressed = 0;
        _bufferLength = 0;
        ClearBuffer(_buffer);

        // If keyed, the first block is the zero-padded key
        if (_key != null && _key.Length > 0)
        {
            Array.Copy(_key, _buffer, _key.Length);
            _bufferLength = BlockSizeBytes;
        }
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        // If we have data in buffer, fill it first
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            // Only compress if buffer is full AND there's more data coming
            // (we need to keep the last block for finalization)
            if (_bufferLength == BlockSizeBytes && offset < source.Length)
            {
                Compress(_buffer, false);
                _bufferLength = 0;
            }
        }

        // Process full blocks, but always keep at least one block for finalization
        while (offset + BlockSizeBytes < source.Length)
        {
            Compress(source.Slice(offset, BlockSizeBytes), false);
            offset += BlockSizeBytes;
        }

        // Store remaining bytes in buffer
        if (offset < source.Length)
        {
            int remaining = source.Length - offset;
            if (_bufferLength == 0)
            {
                source.Slice(offset, remaining).CopyTo(_buffer.AsSpan());
                _bufferLength = remaining;
            }
            else
            {
                // Buffer already has data, append to it
                source.Slice(offset, remaining).CopyTo(_buffer.AsSpan(_bufferLength));
                _bufferLength += remaining;
            }
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Zero-pad the remaining buffer
        _buffer.AsSpan(_bufferLength).Clear();

        // Compress final block
        Compress(_buffer, true);

        // Extract output (little-endian)
        int fullWords = _outputBytes / 8;
        for (int i = 0; i < fullWords; i++)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(i * 8), _state[i]);
        }

        // Handle partial final word
        int remainingBytes = _outputBytes % 8;
        if (remainingBytes > 0)
        {
            Span<byte> temp = stackalloc byte[8];
            BinaryPrimitives.WriteUInt64LittleEndian(temp, _state[fullWords]);
            temp.Slice(0, remainingBytes).CopyTo(destination.Slice(fullWords * 8));
        }

        bytesWritten = _outputBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_state, 0, _state.Length);
            ClearBuffer(_buffer);
            if (_key != null)
            {
                ClearBuffer(_key);
            }
        }
        base.Dispose(disposing);
    }

#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
    private void Compress(ReadOnlySpan<byte> block, bool isFinal)
    {
        // Update counter
        _bytesCompressed += (ulong)_bufferLength;

        // Use stackalloc for working vectors to avoid heap allocations
        Span<ulong> v = stackalloc ulong[16];
        Span<ulong> m = stackalloc ulong[16];

        // Parse message block into 16 64-bit words (little-endian)
        for (int i = 0; i < 16; i++)
        {
            m[i] = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(i * 8));
        }

        // Initialize working vector
        v[0] = _state[0];
        v[1] = _state[1];
        v[2] = _state[2];
        v[3] = _state[3];
        v[4] = _state[4];
        v[5] = _state[5];
        v[6] = _state[6];
        v[7] = _state[7];
        v[8] = IV[0];
        v[9] = IV[1];
        v[10] = IV[2];
        v[11] = IV[3];
        v[12] = IV[4] ^ _bytesCompressed;           // XOR with low 64 bits of counter
        v[13] = IV[5];                              // XOR with high 64 bits (always 0 for us)
        v[14] = isFinal ? ~IV[6] : IV[6];           // Invert if final block
        v[15] = IV[7];

        // 12 rounds of mixing
        for (int round = 0; round < 12; round++)
        {
            // Column step
            G(ref v[0], ref v[4], ref v[8], ref v[12], m[Sigma[round, 0]], m[Sigma[round, 1]]);
            G(ref v[1], ref v[5], ref v[9], ref v[13], m[Sigma[round, 2]], m[Sigma[round, 3]]);
            G(ref v[2], ref v[6], ref v[10], ref v[14], m[Sigma[round, 4]], m[Sigma[round, 5]]);
            G(ref v[3], ref v[7], ref v[11], ref v[15], m[Sigma[round, 6]], m[Sigma[round, 7]]);

            // Diagonal step
            G(ref v[0], ref v[5], ref v[10], ref v[15], m[Sigma[round, 8]], m[Sigma[round, 9]]);
            G(ref v[1], ref v[6], ref v[11], ref v[12], m[Sigma[round, 10]], m[Sigma[round, 11]]);
            G(ref v[2], ref v[7], ref v[8], ref v[13], m[Sigma[round, 12]], m[Sigma[round, 13]]);
            G(ref v[3], ref v[4], ref v[9], ref v[14], m[Sigma[round, 14]], m[Sigma[round, 15]]);
        }

        // Finalize state
        _state[0] ^= v[0] ^ v[8];
        _state[1] ^= v[1] ^ v[9];
        _state[2] ^= v[2] ^ v[10];
        _state[3] ^= v[3] ^ v[11];
        _state[4] ^= v[4] ^ v[12];
        _state[5] ^= v[5] ^ v[13];
        _state[6] ^= v[6] ^ v[14];
        _state[7] ^= v[7] ^ v[15];
    }

    /// <summary>
    /// BLAKE2b mixing function G.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void G(ref ulong a, ref ulong b, ref ulong c, ref ulong d, ulong x, ulong y)
    {
        unchecked
        {
            a = a + b + x;
            d = RotateRight(d ^ a, 32);
            c = c + d;
            b = RotateRight(b ^ c, 24);
            a = a + b + y;
            d = RotateRight(d ^ a, 16);
            c = c + d;
            b = RotateRight(b ^ c, 63);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong RotateRight(ulong x, int n) => BitOperations.RotateRight(x, n);
}
