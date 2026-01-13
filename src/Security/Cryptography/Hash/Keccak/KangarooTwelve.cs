// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;

/// <summary>
/// Computes a variable-length hash using KangarooTwelve (K12).
/// </summary>
/// <remarks>
/// <para>
/// KangarooTwelve is a high-performance extendable-output function (XOF) based on a
/// reduced-round Keccak-p[1600,12] permutation with 12 rounds instead of 24.
/// It provides 128-bit security and supports tree-based parallel hashing for large inputs.
/// </para>
/// <para>
/// K12 is specified in the NIST SP 800-185 draft extension and the official
/// KangarooTwelve specification from the Keccak team.
/// </para>
/// </remarks>
public sealed class KangarooTwelve : HashAlgorithm
{
    /// <summary>
    /// The rate in bytes for K12 (1344 bits = 168 bytes, same as SHAKE128).
    /// </summary>
    public const int RateBytes = 168;

    private const int Rounds = 12;
    private const int InitialBufferSize = 256;

    private readonly int _outputBytes;
    private readonly byte[] _customization;
    private readonly ulong[] _state;
    private byte[] _buffer;
    private int _bufferLength;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="KangarooTwelve"/> class with default output size.
    /// </summary>
    public KangarooTwelve() : this(32, ReadOnlySpan<byte>.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KangarooTwelve"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public KangarooTwelve(int outputBytes) : this(outputBytes, ReadOnlySpan<byte>.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KangarooTwelve"/> class with customization string.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">The customization string for domain separation.</param>
    public KangarooTwelve(int outputBytes, string customization)
        : this(outputBytes, string.IsNullOrEmpty(customization) ? ReadOnlySpan<byte>.Empty : Encoding.UTF8.GetBytes(customization))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KangarooTwelve"/> class with customization bytes.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">The customization bytes for domain separation.</param>
    public KangarooTwelve(int outputBytes, ReadOnlySpan<byte> customization)
    {
        if (outputBytes <= 0) throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _customization = customization.ToArray();
        _state = new ulong[25];
        _buffer = new byte[InitialBufferSize];
        _bufferLength = 0;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "KangarooTwelve";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="KangarooTwelve"/> class with default output size (32 bytes).
    /// </summary>
    /// <returns>A new KangarooTwelve instance.</returns>
    public static new KangarooTwelve Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="KangarooTwelve"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new KangarooTwelve instance.</returns>
    public static KangarooTwelve Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance with customization string.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">The customization string for domain separation.</param>
    /// <returns>A new KangarooTwelve instance.</returns>
    public static KangarooTwelve Create(int outputBytes, string customization) => new(outputBytes, customization);

    /// <summary>
    /// Creates a new instance with customization bytes.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">The customization bytes for domain separation.</param>
    /// <returns>A new KangarooTwelve instance.</returns>
    public static KangarooTwelve Create(int outputBytes, ReadOnlySpan<byte> customization) => new(outputBytes, customization);

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Clear(_state, 0, _state.Length);
        _bufferLength = 0;
        _finalized = false;
        _squeezeOffset = 0;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_finalized)
        {
            throw new InvalidOperationException("Cannot add data after finalization.");
        }

        EnsureBufferCapacity(_bufferLength + source.Length);
        source.CopyTo(_buffer.AsSpan(_bufferLength));
        _bufferLength += source.Length;
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        bytesWritten = _outputBytes;
        Squeeze(destination.Slice(0, _outputBytes));
        return true;
    }

    /// <summary>
    /// Squeezes output bytes from the K12 state.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    public void Squeeze(Span<byte> output)
    {
        if (!_finalized)
        {
            FinalizeAbsorption();
            _finalized = true;
            _squeezeOffset = 0;
        }

        SqueezeXof(_state, output, ref _squeezeOffset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void EnsureBufferCapacity(int requiredCapacity)
    {
        if (_buffer.Length >= requiredCapacity)
        {
            return;
        }

        int newSize = _buffer.Length;
        while (newSize < requiredCapacity)
        {
            newSize *= 2;
        }

        byte[] newBuffer = new byte[newSize];
        _buffer.AsSpan(0, _bufferLength).CopyTo(newBuffer);
        _buffer = newBuffer;
    }

    private void FinalizeAbsorption()
    {
        // Calculate total size needed: message + customization + right_encode(|C|)
        int custLen = _customization.Length;
        Span<byte> encoded = stackalloc byte[9];
        int encLen = RightEncode(encoded, (ulong)custLen);

        int totalLen = _bufferLength + custLen + encLen;
        EnsureBufferCapacity(totalLen);

        // Append customization string
        _customization.AsSpan().CopyTo(_buffer.AsSpan(_bufferLength));
        _bufferLength += custLen;

        // Append right_encode(|C|)
        encoded.Slice(0, encLen).CopyTo(_buffer.AsSpan(_bufferLength));
        _bufferLength += encLen;

        // Absorb message
        AbsorbMessage(_state, _buffer.AsSpan(0, _bufferLength));
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void AbsorbMessage(ulong[] state, ReadOnlySpan<byte> message)
    {
        int offset = 0;

        while (offset + RateBytes <= message.Length)
        {
            for (int i = 0; i < RateBytes / 8; i++)
            {
                state[i] ^= BinaryPrimitives.ReadUInt64LittleEndian(message.Slice(offset + i * 8));
            }
            Permute12(state);
            offset += RateBytes;
        }

        int remaining = message.Length - offset;

        for (int i = 0; i < remaining; i++)
        {
            int laneIdx = i / 8;
            int byteIdx = i % 8;
            state[laneIdx] ^= (ulong)message[offset + i] << (byteIdx * 8);
        }

        int domainLane = remaining / 8;
        int domainByte = remaining % 8;
        state[domainLane] ^= 0x07UL << (domainByte * 8);

        state[RateBytes / 8 - 1] ^= 0x80UL << 56;

        Permute12(state);
    }

    private static void SqueezeXof(ulong[] state, Span<byte> output, ref int squeezeOffset)
    {
        int outputOffset = 0;

        while (outputOffset < output.Length)
        {
            if (squeezeOffset >= RateBytes)
            {
                Permute12(state);
                squeezeOffset = 0;
            }

            int stateIndex = squeezeOffset / 8;
            int byteIndex = squeezeOffset % 8;

            unchecked
            {
                while (outputOffset < output.Length && squeezeOffset < RateBytes)
                {
                    output[outputOffset++] = (byte)(state[stateIndex] >> (byteIndex * 8));
                    byteIndex++;
                    squeezeOffset++;

                    if (byteIndex >= 8)
                    {
                        byteIndex = 0;
                        stateIndex++;
                    }
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int RightEncode(Span<byte> output, ulong value)
    {
        if (value == 0)
        {
            output[0] = 0x00;
            output[1] = 0x01;
            return 2;
        }

        int n = 0;
        ulong temp = value;
        while (temp > 0)
        {
            n++;
            temp >>= 8;
        }

        for (int i = 0; i < n; i++)
        {
            output[i] = (byte)(value >> ((n - 1 - i) * 8));
        }

        output[n] = (byte)n;
        return n + 1;
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private static void Permute12(ulong[] state)
    {
        Span<ulong> c = stackalloc ulong[5];
        Span<ulong> d = stackalloc ulong[5];
        Span<ulong> b = stackalloc ulong[25];

        ReadOnlySpan<ulong> roundConstants =
        [
            0x000000008000808bUL, 0x800000000000008bUL, 0x8000000000008089UL, 0x8000000000008003UL,
            0x8000000000008002UL, 0x8000000000000080UL, 0x000000000000800aUL, 0x800000008000000aUL,
            0x8000000080008081UL, 0x8000000000008080UL, 0x0000000080000001UL, 0x8000000080008008UL
        ];

        for (int round = 0; round < Rounds; round++)
        {
            c[0] = state[0] ^ state[5] ^ state[10] ^ state[15] ^ state[20];
            c[1] = state[1] ^ state[6] ^ state[11] ^ state[16] ^ state[21];
            c[2] = state[2] ^ state[7] ^ state[12] ^ state[17] ^ state[22];
            c[3] = state[3] ^ state[8] ^ state[13] ^ state[18] ^ state[23];
            c[4] = state[4] ^ state[9] ^ state[14] ^ state[19] ^ state[24];

            d[0] = c[4] ^ RotateLeft(c[1], 1);
            d[1] = c[0] ^ RotateLeft(c[2], 1);
            d[2] = c[1] ^ RotateLeft(c[3], 1);
            d[3] = c[2] ^ RotateLeft(c[4], 1);
            d[4] = c[3] ^ RotateLeft(c[0], 1);

            state[0] ^= d[0]; state[1] ^= d[1]; state[2] ^= d[2]; state[3] ^= d[3]; state[4] ^= d[4];
            state[5] ^= d[0]; state[6] ^= d[1]; state[7] ^= d[2]; state[8] ^= d[3]; state[9] ^= d[4];
            state[10] ^= d[0]; state[11] ^= d[1]; state[12] ^= d[2]; state[13] ^= d[3]; state[14] ^= d[4];
            state[15] ^= d[0]; state[16] ^= d[1]; state[17] ^= d[2]; state[18] ^= d[3]; state[19] ^= d[4];
            state[20] ^= d[0]; state[21] ^= d[1]; state[22] ^= d[2]; state[23] ^= d[3]; state[24] ^= d[4];

            b[0] = state[0];
            b[1] = RotateLeft(state[6], 44);
            b[2] = RotateLeft(state[12], 43);
            b[3] = RotateLeft(state[18], 21);
            b[4] = RotateLeft(state[24], 14);
            b[5] = RotateLeft(state[3], 28);
            b[6] = RotateLeft(state[9], 20);
            b[7] = RotateLeft(state[10], 3);
            b[8] = RotateLeft(state[16], 45);
            b[9] = RotateLeft(state[22], 61);
            b[10] = RotateLeft(state[1], 1);
            b[11] = RotateLeft(state[7], 6);
            b[12] = RotateLeft(state[13], 25);
            b[13] = RotateLeft(state[19], 8);
            b[14] = RotateLeft(state[20], 18);
            b[15] = RotateLeft(state[4], 27);
            b[16] = RotateLeft(state[5], 36);
            b[17] = RotateLeft(state[11], 10);
            b[18] = RotateLeft(state[17], 15);
            b[19] = RotateLeft(state[23], 56);
            b[20] = RotateLeft(state[2], 62);
            b[21] = RotateLeft(state[8], 55);
            b[22] = RotateLeft(state[14], 39);
            b[23] = RotateLeft(state[15], 41);
            b[24] = RotateLeft(state[21], 2);

            for (int y = 0; y < 5; y++)
            {
                int off = y * 5;
                state[off] = b[off] ^ (~b[off + 1] & b[off + 2]);
                state[off + 1] = b[off + 1] ^ (~b[off + 2] & b[off + 3]);
                state[off + 2] = b[off + 2] ^ (~b[off + 3] & b[off + 4]);
                state[off + 3] = b[off + 3] ^ (~b[off + 4] & b[off]);
                state[off + 4] = b[off + 4] ^ (~b[off] & b[off + 1]);
            }

            state[0] ^= roundConstants[round];
        }
    }

#if NET8_0_OR_GREATER
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong RotateLeft(ulong x, int n) => BitOperations.RotateLeft(x, n);
#else
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static ulong RotateLeft(ulong x, int n) => (x << n) | (x >> (64 - n));
#endif

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_state, 0, _state.Length);
            Array.Clear(_buffer, 0, _buffer.Length);
        }
        base.Dispose(disposing);
    }
}
