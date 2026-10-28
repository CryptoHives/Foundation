// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


/// <summary>
/// Computes the MD5 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of MD5 based on RFC 1321.
/// It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// <strong>Security Warning:</strong> MD5 is cryptographically broken and should NOT
/// be used for security purposes such as digital signatures, password hashing, or
/// message authentication. It is provided only for legacy compatibility and
/// non-cryptographic uses such as file checksums.
/// </para>
/// </remarks>
[Obsolete("MD5 is cryptographically broken and should not be used for security purposes.")]
public sealed class MD5 : HashAlgorithm
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 128;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = 64;

    // Initial hash values (little-endian)
    private const uint A0 = 0x67452301;
    private const uint B0 = 0xefcdab89;
    private const uint C0 = 0x98badcfe;
    private const uint D0 = 0x10325476;

    private uint _a, _b, _c, _d;
    private readonly byte[] _buffer;
    private int _bufferLength;
    private ulong _totalLength;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="MD5"/> class.
    /// </summary>
    public MD5()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "MD5";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="MD5"/> class.
    /// </summary>
    /// <returns>A new MD5 hash algorithm instance.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    public static new MD5 Create() => new();
#pragma warning restore CS0618

    /// <summary>
    /// Computes the MD5 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="HashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<MD5>.TryHashData(source, destination, out bytesWritten);
#pragma warning restore CS0618

    /// <summary>
    /// Computes the MD5 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the MD5 hash.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<MD5>.HashData(source);
#pragma warning restore CS0618

    /// <summary>
    /// Computes the MD5 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="HashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    public static bool TryHashData(in ReadOnlySequence<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<MD5>.TryHashData(source, destination, out bytesWritten);
#pragma warning restore CS0618

    /// <summary>
    /// Computes the MD5 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <returns>A new byte array containing the MD5 hash.</returns>
#pragma warning disable CS0618 // Type or member is obsolete
    public static byte[] HashData(in ReadOnlySequence<byte> source)
        => HashAlgorithmPool<MD5>.HashData(source);
#pragma warning restore CS0618

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public override void Initialize()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(MD5));

        _a = A0;
        _b = B0;
        _c = C0;
        _d = D0;
        ClearBuffer(_buffer);
        _bufferLength = 0;
        _totalLength = 0;
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_disposed)
        {
            throw new ObjectDisposedException(nameof(MD5));
        }

        _totalLength += (ulong)source.Length;
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
                _bufferLength = 0;
            }
        }

        while (offset + BlockSizeBytes <= source.Length)
        {
            ProcessBlock(source.Slice(offset, BlockSizeBytes));
            offset += BlockSizeBytes;
        }

        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += source.Length - offset;
        }
    }

    /// <inheritdoc/>
    [SkipLocalsInit]
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < HashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Padding
        ulong bitLength = _totalLength * 8;
        int padLength = (_bufferLength < 56) ? (56 - _bufferLength) : (120 - _bufferLength);

        Span<byte> padding = stackalloc byte[padLength + 8];
        padding[0] = 0x80;
        padding.Slice(1, padLength - 1).Clear();

        // Append length in bits as little-endian 64-bit
        BinaryPrimitives.WriteUInt64LittleEndian(padding.Slice(padLength), bitLength);

        HashCore(padding);

        // Output hash (little-endian)
        BinaryPrimitives.WriteUInt32LittleEndian(destination, _a);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(sizeof(UInt32)), _b);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(2 * sizeof(UInt32)), _c);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(3 * sizeof(UInt32)), _d);

        bytesWritten = HashSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_buffer);
            _a = _b = _c = _d = 0;
            _disposed = true;
        }
        base.Dispose(disposing);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        Span<uint> m = stackalloc uint[16];

        unchecked
        {
            // Parse block into 16 little-endian 32-bit words
            BinarySpans.ReadUInt32LittleEndian(block.Slice(0, BlockSizeBytes), m);

            uint a = _a;
            uint b = _b;
            uint c = _c;
            uint d = _d;

            ref uint mPtr = ref MemoryMarshal.GetReference(m);

            // Round 1
            F(ref a, b, c, d, Unsafe.Add(ref mPtr, 0), 0xd76aa478, 7);
            F(ref d, a, b, c, Unsafe.Add(ref mPtr, 1), 0xe8c7b756, 12);
            F(ref c, d, a, b, Unsafe.Add(ref mPtr, 2), 0x242070db, 17);
            F(ref b, c, d, a, Unsafe.Add(ref mPtr, 3), 0xc1bdceee, 22);
            F(ref a, b, c, d, Unsafe.Add(ref mPtr, 4), 0xf57c0faf, 7);
            F(ref d, a, b, c, Unsafe.Add(ref mPtr, 5), 0x4787c62a, 12);
            F(ref c, d, a, b, Unsafe.Add(ref mPtr, 6), 0xa8304613, 17);
            F(ref b, c, d, a, Unsafe.Add(ref mPtr, 7), 0xfd469501, 22);
            F(ref a, b, c, d, Unsafe.Add(ref mPtr, 8), 0x698098d8, 7);
            F(ref d, a, b, c, Unsafe.Add(ref mPtr, 9), 0x8b44f7af, 12);
            F(ref c, d, a, b, Unsafe.Add(ref mPtr, 10), 0xffff5bb1, 17);
            F(ref b, c, d, a, Unsafe.Add(ref mPtr, 11), 0x895cd7be, 22);
            F(ref a, b, c, d, Unsafe.Add(ref mPtr, 12), 0x6b901122, 7);
            F(ref d, a, b, c, Unsafe.Add(ref mPtr, 13), 0xfd987193, 12);
            F(ref c, d, a, b, Unsafe.Add(ref mPtr, 14), 0xa679438e, 17);
            F(ref b, c, d, a, Unsafe.Add(ref mPtr, 15), 0x49b40821, 22);
            // Round 2
            G(ref a, b, c, d, Unsafe.Add(ref mPtr, 1), 0xf61e2562, 5);
            G(ref d, a, b, c, Unsafe.Add(ref mPtr, 6), 0xc040b340, 9);
            G(ref c, d, a, b, Unsafe.Add(ref mPtr, 11), 0x265e5a51, 14);
            G(ref b, c, d, a, Unsafe.Add(ref mPtr, 0), 0xe9b6c7aa, 20);
            G(ref a, b, c, d, Unsafe.Add(ref mPtr, 5), 0xd62f105d, 5);
            G(ref d, a, b, c, Unsafe.Add(ref mPtr, 10), 0x02441453, 9);
            G(ref c, d, a, b, Unsafe.Add(ref mPtr, 15), 0xd8a1e681, 14);
            G(ref b, c, d, a, Unsafe.Add(ref mPtr, 4), 0xe7d3fbc8, 20);
            G(ref a, b, c, d, Unsafe.Add(ref mPtr, 9), 0x21e1cde6, 5);
            G(ref d, a, b, c, Unsafe.Add(ref mPtr, 14), 0xc33707d6, 9);
            G(ref c, d, a, b, Unsafe.Add(ref mPtr, 3), 0xf4d50d87, 14);
            G(ref b, c, d, a, Unsafe.Add(ref mPtr, 8), 0x455a14ed, 20);
            G(ref a, b, c, d, Unsafe.Add(ref mPtr, 13), 0xa9e3e905, 5);
            G(ref d, a, b, c, Unsafe.Add(ref mPtr, 2), 0xfcefa3f8, 9);
            G(ref c, d, a, b, Unsafe.Add(ref mPtr, 7), 0x676f02d9, 14);
            G(ref b, c, d, a, Unsafe.Add(ref mPtr, 12), 0x8d2a4c8a, 20);
            // Round 3
            H(ref a, b, c, d, Unsafe.Add(ref mPtr, 5), 0xfffa3942, 4);
            H(ref d, a, b, c, Unsafe.Add(ref mPtr, 8), 0x8771f681, 11);
            H(ref c, d, a, b, Unsafe.Add(ref mPtr, 11), 0x6d9d6122, 16);
            H(ref b, c, d, a, Unsafe.Add(ref mPtr, 14), 0xfde5380c, 23);
            H(ref a, b, c, d, Unsafe.Add(ref mPtr, 1), 0xa4beea44, 4);
            H(ref d, a, b, c, Unsafe.Add(ref mPtr, 4), 0x4bdecfa9, 11);
            H(ref c, d, a, b, Unsafe.Add(ref mPtr, 7), 0xf6bb4b60, 16);
            H(ref b, c, d, a, Unsafe.Add(ref mPtr, 10), 0xbebfbc70, 23);
            H(ref a, b, c, d, Unsafe.Add(ref mPtr, 13), 0x289b7ec6, 4);
            H(ref d, a, b, c, Unsafe.Add(ref mPtr, 0), 0xeaa127fa, 11);
            H(ref c, d, a, b, Unsafe.Add(ref mPtr, 3), 0xd4ef3085, 16);
            H(ref b, c, d, a, Unsafe.Add(ref mPtr, 6), 0x04881d05, 23);
            H(ref a, b, c, d, Unsafe.Add(ref mPtr, 9), 0xd9d4d039, 4);
            H(ref d, a, b, c, Unsafe.Add(ref mPtr, 12), 0xe6db99e5, 11);
            H(ref c, d, a, b, Unsafe.Add(ref mPtr, 15), 0x1fa27cf8, 16);
            H(ref b, c, d, a, Unsafe.Add(ref mPtr, 2), 0xc4ac5665, 23);
            // Round 4
            I(ref a, b, c, d, Unsafe.Add(ref mPtr, 0), 0xf4292244, 6);
            I(ref d, a, b, c, Unsafe.Add(ref mPtr, 7), 0x432aff97, 10);
            I(ref c, d, a, b, Unsafe.Add(ref mPtr, 14), 0xab9423a7, 15);
            I(ref b, c, d, a, Unsafe.Add(ref mPtr, 5), 0xfc93a039, 21);
            I(ref a, b, c, d, Unsafe.Add(ref mPtr, 12), 0x655b59c3, 6);
            I(ref d, a, b, c, Unsafe.Add(ref mPtr, 3), 0x8f0ccc92, 10);
            I(ref c, d, a, b, Unsafe.Add(ref mPtr, 10), 0xffeff47d, 15);
            I(ref b, c, d, a, Unsafe.Add(ref mPtr, 1), 0x85845dd1, 21);
            I(ref a, b, c, d, Unsafe.Add(ref mPtr, 8), 0x6fa87e4f, 6);
            I(ref d, a, b, c, Unsafe.Add(ref mPtr, 15), 0xfe2ce6e0, 10);
            I(ref c, d, a, b, Unsafe.Add(ref mPtr, 6), 0xa3014314, 15);
            I(ref b, c, d, a, Unsafe.Add(ref mPtr, 13), 0x4e0811a1, 21);
            I(ref a, b, c, d, Unsafe.Add(ref mPtr, 4), 0xf7537e82, 6);
            I(ref d, a, b, c, Unsafe.Add(ref mPtr, 11), 0xbd3af235, 10);
            I(ref c, d, a, b, Unsafe.Add(ref mPtr, 2), 0x2ad7d2bb, 15);
            I(ref b, c, d, a, Unsafe.Add(ref mPtr, 9), 0xeb86d391, 21);

            _a += a;
            _b += b;
            _c += c;
            _d += d;
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void F(ref uint a, uint b, uint c, uint d, uint m, uint k, int s)
        => a = b + BitOperations.RotateLeft(a + ((b & c) | (~b & d)) + m + k, s);

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void G(ref uint a, uint b, uint c, uint d, uint m, uint k, int s)
        => a = b + BitOperations.RotateLeft(a + ((d & b) | (~d & c)) + m + k, s);

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void H(ref uint a, uint b, uint c, uint d, uint m, uint k, int s)
        => a = b + BitOperations.RotateLeft(a + (b ^ c ^ d) + m + k, s);

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void I(ref uint a, uint b, uint c, uint d, uint m, uint k, int s)
        => a = b + BitOperations.RotateLeft(a + (c ^ (b | ~d)) + m + k, s);
}
