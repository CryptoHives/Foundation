// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// Computes the SHA-1 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA-1 based on FIPS 180-4.
/// It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// <strong>Security Warning:</strong> SHA-1 is cryptographically weak and should NOT
/// be used for security purposes such as digital signatures or certificate verification.
/// It is provided only for legacy compatibility.
/// </para>
/// </remarks>
[Obsolete("SHA-1 is cryptographically weak and should not be used for security purposes.")]
public sealed partial class SHA1 : HashAlgorithm
{
    /// <summary>
    /// The default optimization to use for Blake3 based algorithms.
    /// </summary>
    internal const SimdSupport Sha1Default = SimdSupport.All;

    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 160;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 64;

    private readonly byte[] _buffer;
    private readonly uint[] _state;
    private readonly uint[] _w;
#if NET8_0_OR_GREATER
    private readonly SimdSupport _simdSupport;
#endif
    private long _bytesProcessed;
    private int _bufferLength;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA1"/> class.
    /// </summary>
    public SHA1() : this(Sha1Default)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA1"/> class with forced SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    internal SHA1(SimdSupport simdSupport)
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        _state = new uint[5];
        _w = new uint[80];
#if NET8_0_OR_GREATER
        _simdSupport = simdSupport & SimdSupport;
#endif
        Initialize();
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by SHA-1 on the current platform.
    /// </summary>
    internal new static SimdSupport SimdSupport
    {
        get
        {
            var support = SimdSupport.None;
#if NET8_0_OR_GREATER
            if (IsArmSha1Supported) support |= SimdSupport.ArmSha1;
#endif
            return support;
        }
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA-1";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA1"/> class.
    /// </summary>
    /// <returns>A new SHA-1 hash algorithm instance.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    public static new SHA1 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="SHA1"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new SHA-1 hash algorithm instance.</returns>
    internal static SHA1 Create(SimdSupport simdSupport) => new(simdSupport);
#pragma warning restore CS0618

    /// <summary>
    /// Computes the SHA-1 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="HashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<SHA1>.TryHashData(source, destination, out bytesWritten);
#pragma warning restore CS0618

    /// <summary>
    /// Computes the SHA-1 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the SHA-1 hash.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<SHA1>.HashData(source);
#pragma warning restore CS0618

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public override void Initialize()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(SHA1));

        // SHA-1 initialization constants
        _state[0] = 0x67452301;
        _state[1] = 0xefcdab89;
        _state[2] = 0x98badcfe;
        _state[3] = 0x10325476;
        _state[4] = 0xc3d2e1f0;

        _bytesProcessed = 0;
        _bufferLength = 0;
        ClearBuffer(_buffer);
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(SHA1));

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
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(SHA1));
        if (destination.Length < HashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        PadAndFinalize();

        // Output 5 words (20 bytes) in big-endian
        for (int i = 0; i < 5; i++)
        {
            BinaryPrimitives.WriteUInt32BigEndian(destination.Slice(i * sizeof(UInt32)), _state[i]);
        }

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
            Array.Clear(_w, 0, _w.Length);
            _disposed = true;
        }
        base.Dispose(disposing);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        // The schedule and the chaining value are both fixed-size readonly arrays
        // allocated in the constructor; take the references once so the 80-round
        // expansion does not re-check a length the JIT cannot see behind a field load.
        Debug.Assert(_state.Length >= 5, "chaining value must hold the full state");
        Debug.Assert(_w.Length >= 80, "message schedule must hold 80 words");
        ref uint sPtr = ref MemoryMarshalEx.GetArrayDataReference(_state);
        ref uint wPtr = ref MemoryMarshalEx.GetArrayDataReference(_w);

#if NET8_0_OR_GREATER
        if ((_simdSupport & SimdSupport.ArmSha1) != 0)
        {
            ProcessBlockArm(block, _state);
            return;
        }
#endif
        unchecked
        {
            // Parse block into 16 32-bit words (big-endian)
            for (int i = 0; i < 16; i++)
            {
                Unsafe.Add(ref wPtr, i) = BinaryPrimitives.ReadUInt32BigEndian(block.Slice(i * sizeof(UInt32)));
            }

            // Extend 16 words to 80 words
            for (int i = 16; i < 80; i++)
            {
                Unsafe.Add(ref wPtr, i) = BitOperations.RotateLeft(Unsafe.Add(ref wPtr, i - 3) ^ Unsafe.Add(ref wPtr, i - 8) ^ Unsafe.Add(ref wPtr, i - 14) ^ Unsafe.Add(ref wPtr, i - 16), 1);
            }

            uint a = Unsafe.Add(ref sPtr, 0);
            uint b = Unsafe.Add(ref sPtr, 1);
            uint c = Unsafe.Add(ref sPtr, 2);
            uint d = Unsafe.Add(ref sPtr, 3);
            uint e = Unsafe.Add(ref sPtr, 4);

            // Round 1: 0-19
            for (int i = 0; i < 20; i++)
            {
                uint f = (b & c) | (~b & d);
                uint temp = BitOperations.RotateLeft(a, 5) + f + e + 0x5a827999 + Unsafe.Add(ref wPtr, i);
                e = d;
                d = c;
                c = BitOperations.RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            // Round 2: 20-39
            for (int i = 20; i < 40; i++)
            {
                uint f = b ^ c ^ d;
                uint temp = BitOperations.RotateLeft(a, 5) + f + e + 0x6ed9eba1 + Unsafe.Add(ref wPtr, i);
                e = d;
                d = c;
                c = BitOperations.RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            // Round 3: 40-59
            for (int i = 40; i < 60; i++)
            {
                uint f = (b & c) | (b & d) | (c & d);
                uint temp = BitOperations.RotateLeft(a, 5) + f + e + 0x8f1bbcdc + Unsafe.Add(ref wPtr, i);
                e = d;
                d = c;
                c = BitOperations.RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            // Round 4: 60-79
            for (int i = 60; i < 80; i++)
            {
                uint f = b ^ c ^ d;
                uint temp = BitOperations.RotateLeft(a, 5) + f + e + 0xca62c1d6 + Unsafe.Add(ref wPtr, i);
                e = d;
                d = c;
                c = BitOperations.RotateLeft(b, 30);
                b = a;
                a = temp;
            }

            Unsafe.Add(ref sPtr, 0) += a;
            Unsafe.Add(ref sPtr, 1) += b;
            Unsafe.Add(ref sPtr, 2) += c;
            Unsafe.Add(ref sPtr, 3) += d;
            Unsafe.Add(ref sPtr, 4) += e;
        }
    }

    private void PadAndFinalize()
    {
        unchecked
        {
            long totalBits = (_bytesProcessed + _bufferLength) * 8;

            _buffer[_bufferLength++] = 0x80;

            if (_bufferLength > 56)
            {
                while (_bufferLength < BlockSizeBytes)
                {
                    _buffer[_bufferLength++] = 0x00;
                }
                ProcessBlock(_buffer);
                _bufferLength = 0;
            }

            while (_bufferLength < 56)
            {
                _buffer[_bufferLength++] = 0x00;
            }

            BinaryPrimitives.WriteInt64BigEndian(_buffer.AsSpan(56), totalBits);

            ProcessBlock(_buffer);
        }
    }
}
