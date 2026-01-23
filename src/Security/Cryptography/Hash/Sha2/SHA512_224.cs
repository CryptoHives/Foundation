// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - K and IV are standard cryptographic constant names per FIPS 180-4
#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the SHA-512/224 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-512/224 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// SHA-512/224 produces a 224-bit (28-byte) hash value using SHA-512 with
/// different initial values and truncated output.
/// </para>
/// </remarks>
public sealed class SHA512_224 : HashAlgorithm
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 224;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 128;

    // SHA-512 round constants (shared with all SHA-512 variants)
    private static readonly ulong[] K =
    [
        0x428a2f98d728ae22, 0x7137449123ef65cd, 0xb5c0fbcfec4d3b2f, 0xe9b5dba58189dbbc,
        0x3956c25bf348b538, 0x59f111f1b605d019, 0x923f82a4af194f9b, 0xab1c5ed5da6d8118,
        0xd807aa98a3030242, 0x12835b0145706fbe, 0x243185be4ee4b28c, 0x550c7dc3d5ffb4e2,
        0x72be5d74f27b896f, 0x80deb1fe3b1696b1, 0x9bdc06a725c71235, 0xc19bf174cf692694,
        0xe49b69c19ef14ad2, 0xefbe4786384f25e3, 0x0fc19dc68b8cd5b5, 0x240ca1cc77ac9c65,
        0x2de92c6f592b0275, 0x4a7484aa6ea6e483, 0x5cb0a9dcbd41fbd4, 0x76f988da831153b5,
        0x983e5152ee66dfab, 0xa831c66d2db43210, 0xb00327c898fb213f, 0xbf597fc7beef0ee4,
        0xc6e00bf33da88fc2, 0xd5a79147930aa725, 0x06ca6351e003826f, 0x142929670a0e6e70,
        0x27b70a8546d22ffc, 0x2e1b21385c26c926, 0x4d2c6dfc5ac42aed, 0x53380d139d95b3df,
        0x650a73548baf63de, 0x766a0abb3c77b2a8, 0x81c2c92e47edaee6, 0x92722c851482353b,
        0xa2bfe8a14cf10364, 0xa81a664bbc423001, 0xc24b8b70d0f89791, 0xc76c51a30654be30,
        0xd192e819d6ef5218, 0xd69906245565a910, 0xf40e35855771202a, 0x106aa07032bbd1b8,
        0x19a4c116b8d2d0c8, 0x1e376c085141ab53, 0x2748774cdf8eeb99, 0x34b0bcb5e19b48a8,
        0x391c0cb3c5c95a63, 0x4ed8aa4ae3418acb, 0x5b9cca4f7763e373, 0x682e6ff3d6b2b8a3,
        0x748f82ee5defb2fc, 0x78a5636f43172f60, 0x84c87814a1f0ab72, 0x8cc702081a6439ec,
        0x90befffa23631e28, 0xa4506cebde82bde9, 0xbef9a3f7b2c67915, 0xc67178f2e372532b,
        0xca273eceea26619c, 0xd186b8c721c0c207, 0xeada7dd6cde0eb1e, 0xf57d4f7fee6ed178,
        0x06f067aa72176fba, 0x0a637dc5a2c898a6, 0x113f9804bef90dae, 0x1b710b35131c471b,
        0x28db77f523047d84, 0x32caab7b40c72493, 0x3c9ebe0a15c9bebc, 0x431d67c49c100d4c,
        0x4cc5d4becb3e42b6, 0x597f299cfc657e2a, 0x5fcb6fab3ad6faec, 0x6c44198c4a475817
    ];

    private readonly byte[] _buffer;
    private readonly ulong[] _state;
    private long _bytesProcessed;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA512_224"/> class.
    /// </summary>
    public SHA512_224()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        _state = new ulong[8];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-512/224";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA512_224"/> class.
    /// </summary>
    /// <returns>A new SHA-512/224 hash algorithm instance.</returns>
    public static new SHA512_224 Create() => new();

    /// <inheritdoc/>
    public override void Initialize()
    {
        // SHA-512/224 uses different IV (generated per FIPS 180-4)
        _state[0] = 0x8c3d37c819544da2;
        _state[1] = 0x73e1996689dcd4d6;
        _state[2] = 0x1dfab7ae32ff9c82;
        _state[3] = 0x679dd514582f9fcf;
        _state[4] = 0x0f6d2b697bd44da8;
        _state[5] = 0x77e36f7304c48942;
        _state[6] = 0x3f9d85a86a1d36c8;
        _state[7] = 0x1112e6ad91d692a1;

        _bytesProcessed = 0;
        _bufferLength = 0;
        ClearBuffer(_buffer);
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == BlockSizeBytes)
            {
                ProcessBlock(_buffer);
                _bytesProcessed += BlockSizeBytes;
                _bufferLength = 0;
            }
        }

        while (offset + BlockSizeBytes <= source.Length)
        {
            ProcessBlock(source.Slice(offset, BlockSizeBytes));
            _bytesProcessed += BlockSizeBytes;
            offset += BlockSizeBytes;
        }

        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += source.Length - offset;
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < HashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        PadAndFinalize();

        // Output first 3 full words (24 bytes) + 4 bytes from 4th word = 28 bytes
        for (int i = 0; i < 3; i++)
        {
            BinaryPrimitives.WriteUInt64BigEndian(destination.Slice(i * 8), _state[i]);
        }
        // Last 4 bytes from word 3 (high 32 bits)
        BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(24), (uint)(_state[3] >> 32));

        bytesWritten = HashSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_buffer);
            Array.Clear(_state, 0, _state.Length);
        }
        base.Dispose(disposing);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        Span<ulong> w = stackalloc ulong[80];

        unchecked
        {
            for (int i = 0; i < 16; i++)
            {
                w[i] = BinaryPrimitives.ReadUInt64BigEndian(block.Slice(i * 8));
            }

            for (int i = 16; i < 80; i++)
            {
                ulong s0 = BitOperations.RotateRight(w[i - 15], 1) ^ BitOperations.RotateRight(w[i - 15], 8) ^ (w[i - 15] >> 7);
                ulong s1 = BitOperations.RotateRight(w[i - 2], 19) ^ BitOperations.RotateRight(w[i - 2], 61) ^ (w[i - 2] >> 6);
                w[i] = w[i - 16] + s0 + w[i - 7] + s1;
            }

            ulong a = _state[0];
            ulong b = _state[1];
            ulong c = _state[2];
            ulong d = _state[3];
            ulong e = _state[4];
            ulong f = _state[5];
            ulong g = _state[6];
            ulong h = _state[7];

            for (int i = 0; i < 80; i++)
            {
                ulong S1 = BitOperations.RotateRight(e, 14) ^ BitOperations.RotateRight(e, 18) ^ BitOperations.RotateRight(e, 41);
                ulong ch = (e & f) ^ (~e & g);
                ulong temp1 = h + S1 + ch + K[i] + w[i];
                ulong S0 = BitOperations.RotateRight(a, 28) ^ BitOperations.RotateRight(a, 34) ^ BitOperations.RotateRight(a, 39);
                ulong maj = (a & b) ^ (a & c) ^ (b & c);
                ulong temp2 = S0 + maj;

                h = g;
                g = f;
                f = e;
                e = d + temp1;
                d = c;
                c = b;
                b = a;
                a = temp1 + temp2;
            }

            _state[0] += a;
            _state[1] += b;
            _state[2] += c;
            _state[3] += d;
            _state[4] += e;
            _state[5] += f;
            _state[6] += g;
            _state[7] += h;
        }
    }

    private void PadAndFinalize()
    {
        unchecked
        {
            long totalBits = (_bytesProcessed + _bufferLength) * 8;

            _buffer[_bufferLength++] = 0x80;

            if (_bufferLength > 112)
            {
                while (_bufferLength < BlockSizeBytes)
                {
                    _buffer[_bufferLength++] = 0x00;
                }
                ProcessBlock(_buffer);
                _bufferLength = 0;
            }

            while (_bufferLength < 112)
            {
                _buffer[_bufferLength++] = 0x00;
            }

            BinaryPrimitives.WriteInt64BigEndian(_buffer.AsSpan(112), 0L);
            BinaryPrimitives.WriteInt64BigEndian(_buffer.AsSpan(120), totalBits);

            ProcessBlock(_buffer);
        }
    }
}
