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
/// Computes the RIPEMD-160 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// RIPEMD-160 is a 160-bit cryptographic hash function designed by Hans Dobbertin,
/// Antoon Bosselaers, and Bart Preneel. It is widely used in cryptocurrency systems,
/// particularly Bitcoin for address generation (in combination with SHA-256).
/// </para>
/// <para>
/// This is a fully managed implementation that does not rely on OS or hardware
/// cryptographic APIs, ensuring deterministic behavior across all platforms.
/// </para>
/// <para>
/// <strong>Note:</strong> While RIPEMD-160 is still considered secure for its design goals,
/// SHA-256 or SHA-3 are recommended for new applications requiring 128+ bit security.
/// </para>
/// </remarks>
public sealed class Ripemd160 : HashAlgorithm
{
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

    // Initial hash values
    private const uint H0 = 0x67452301;
    private const uint H1 = 0xEFCDAB89;
    private const uint H2 = 0x98BADCFE;
    private const uint H3 = 0x10325476;
    private const uint H4 = 0xC3D2E1F0;

    private uint _h0, _h1, _h2, _h3, _h4;
    private readonly byte[] _buffer;
    private int _bufferLength;
    private ulong _totalLength;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="Ripemd160"/> class.
    /// </summary>
    public Ripemd160()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[BlockSizeBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "RIPEMD-160";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Ripemd160"/> class.
    /// </summary>
    /// <returns>A new RIPEMD-160 hash algorithm instance.</returns>
    public static new Ripemd160 Create() => new();

    /// <summary>
    /// Computes the RIPEMD-160 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="HashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<Ripemd160>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the RIPEMD-160 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the RIPEMD-160 hash.</returns>
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<Ripemd160>.HashData(source);

    /// <summary>
    /// Computes the RIPEMD-160 hash of <paramref name="source"/> and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="HashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(in ReadOnlySequence<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<Ripemd160>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the RIPEMD-160 hash of <paramref name="source"/> and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <returns>A new byte array containing the RIPEMD-160 hash.</returns>
    public static byte[] HashData(in ReadOnlySequence<byte> source)
        => HashAlgorithmPool<Ripemd160>.HashData(source);

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public override void Initialize()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Ripemd160));
        _h0 = H0;
        _h1 = H1;
        _h2 = H2;
        _h3 = H3;
        _h4 = H4;
        ClearBuffer(_buffer);
        _bufferLength = 0;
        _totalLength = 0;
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Ripemd160));
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

        ulong bitLength = _totalLength * 8;
        int padLength = (_bufferLength < 56) ? (56 - _bufferLength) : (120 - _bufferLength);

        Span<byte> padding = stackalloc byte[padLength + 8];
        padding[0] = 0x80;
        padding.Slice(1, padLength - 1).Clear();

        // Append length in bits as little-endian 64-bit
        BinaryPrimitives.WriteUInt64LittleEndian(padding.Slice(padLength), bitLength);

        HashCore(padding);

        // Output hash (little-endian)
        BinaryPrimitives.WriteUInt32LittleEndian(destination, _h0);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(sizeof(UInt32)), _h1);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(2 * sizeof(UInt32)), _h2);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(3 * sizeof(UInt32)), _h3);
        BinaryPrimitives.WriteUInt32LittleEndian(destination.Slice(4 * sizeof(UInt32)), _h4);

        bytesWritten = HashSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_buffer);
            _h0 = _h1 = _h2 = _h3 = _h4 = 0;
            _disposed = true;
        }
        base.Dispose(disposing);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private void ProcessBlock(ReadOnlySpan<byte> block)
    {
        Span<uint> x = stackalloc uint[16];

        unchecked
        {
            BinarySpans.ReadUInt32LittleEndian(block.Slice(0, BlockSizeBytes), x);
            ref uint xPtr = ref MemoryMarshal.GetReference(x);

            uint al = _h0, bl = _h1, cl = _h2, dl = _h3, el = _h4;
            uint ar = _h0, br = _h1, cr = _h2, dr = _h3, er = _h4;

            // Round 0
            Step(ref al, F1(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 0), 0x00000000, 11);
            Step(ref ar, F5(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 5), 0x50A28BE6, 8);
            Step(ref el, F1(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 1), 0x00000000, 14);
            Step(ref er, F5(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 14), 0x50A28BE6, 9);
            Step(ref dl, F1(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 2), 0x00000000, 15);
            Step(ref dr, F5(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 7), 0x50A28BE6, 9);
            Step(ref cl, F1(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 3), 0x00000000, 12);
            Step(ref cr, F5(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 0), 0x50A28BE6, 11);
            Step(ref bl, F1(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 4), 0x00000000, 5);
            Step(ref br, F5(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 9), 0x50A28BE6, 13);
            Step(ref al, F1(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 5), 0x00000000, 8);
            Step(ref ar, F5(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 2), 0x50A28BE6, 15);
            Step(ref el, F1(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 6), 0x00000000, 7);
            Step(ref er, F5(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 11), 0x50A28BE6, 15);
            Step(ref dl, F1(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 7), 0x00000000, 9);
            Step(ref dr, F5(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 4), 0x50A28BE6, 5);
            Step(ref cl, F1(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 8), 0x00000000, 11);
            Step(ref cr, F5(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 13), 0x50A28BE6, 7);
            Step(ref bl, F1(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 9), 0x00000000, 13);
            Step(ref br, F5(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 6), 0x50A28BE6, 7);
            Step(ref al, F1(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 10), 0x00000000, 14);
            Step(ref ar, F5(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 15), 0x50A28BE6, 8);
            Step(ref el, F1(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 11), 0x00000000, 15);
            Step(ref er, F5(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 8), 0x50A28BE6, 11);
            Step(ref dl, F1(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 12), 0x00000000, 6);
            Step(ref dr, F5(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 1), 0x50A28BE6, 14);
            Step(ref cl, F1(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 13), 0x00000000, 7);
            Step(ref cr, F5(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 10), 0x50A28BE6, 14);
            Step(ref bl, F1(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 14), 0x00000000, 9);
            Step(ref br, F5(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 3), 0x50A28BE6, 12);
            Step(ref al, F1(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 15), 0x00000000, 8);
            Step(ref ar, F5(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 12), 0x50A28BE6, 6);
            // Round 1
            Step(ref el, F2(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 7), 0x5A827999, 7);
            Step(ref er, F4(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 6), 0x5C4DD124, 9);
            Step(ref dl, F2(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 4), 0x5A827999, 6);
            Step(ref dr, F4(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 11), 0x5C4DD124, 13);
            Step(ref cl, F2(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 13), 0x5A827999, 8);
            Step(ref cr, F4(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 3), 0x5C4DD124, 15);
            Step(ref bl, F2(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 1), 0x5A827999, 13);
            Step(ref br, F4(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 7), 0x5C4DD124, 7);
            Step(ref al, F2(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 10), 0x5A827999, 11);
            Step(ref ar, F4(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 0), 0x5C4DD124, 12);
            Step(ref el, F2(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 6), 0x5A827999, 9);
            Step(ref er, F4(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 13), 0x5C4DD124, 8);
            Step(ref dl, F2(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 15), 0x5A827999, 7);
            Step(ref dr, F4(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 5), 0x5C4DD124, 9);
            Step(ref cl, F2(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 3), 0x5A827999, 15);
            Step(ref cr, F4(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 10), 0x5C4DD124, 11);
            Step(ref bl, F2(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 12), 0x5A827999, 7);
            Step(ref br, F4(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 14), 0x5C4DD124, 7);
            Step(ref al, F2(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 0), 0x5A827999, 12);
            Step(ref ar, F4(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 15), 0x5C4DD124, 7);
            Step(ref el, F2(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 9), 0x5A827999, 15);
            Step(ref er, F4(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 8), 0x5C4DD124, 12);
            Step(ref dl, F2(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 5), 0x5A827999, 9);
            Step(ref dr, F4(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 12), 0x5C4DD124, 7);
            Step(ref cl, F2(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 2), 0x5A827999, 11);
            Step(ref cr, F4(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 4), 0x5C4DD124, 6);
            Step(ref bl, F2(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 14), 0x5A827999, 7);
            Step(ref br, F4(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 9), 0x5C4DD124, 15);
            Step(ref al, F2(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 11), 0x5A827999, 13);
            Step(ref ar, F4(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 1), 0x5C4DD124, 13);
            Step(ref el, F2(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 8), 0x5A827999, 12);
            Step(ref er, F4(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 2), 0x5C4DD124, 11);
            // Round 2
            Step(ref dl, F3(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 3), 0x6ED9EBA1, 11);
            Step(ref dr, F3(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 15), 0x6D703EF3, 9);
            Step(ref cl, F3(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 10), 0x6ED9EBA1, 13);
            Step(ref cr, F3(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 5), 0x6D703EF3, 7);
            Step(ref bl, F3(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 14), 0x6ED9EBA1, 6);
            Step(ref br, F3(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 1), 0x6D703EF3, 15);
            Step(ref al, F3(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 4), 0x6ED9EBA1, 7);
            Step(ref ar, F3(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 3), 0x6D703EF3, 11);
            Step(ref el, F3(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 9), 0x6ED9EBA1, 14);
            Step(ref er, F3(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 7), 0x6D703EF3, 8);
            Step(ref dl, F3(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 15), 0x6ED9EBA1, 9);
            Step(ref dr, F3(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 14), 0x6D703EF3, 6);
            Step(ref cl, F3(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 8), 0x6ED9EBA1, 13);
            Step(ref cr, F3(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 6), 0x6D703EF3, 6);
            Step(ref bl, F3(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 1), 0x6ED9EBA1, 15);
            Step(ref br, F3(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 9), 0x6D703EF3, 14);
            Step(ref al, F3(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 2), 0x6ED9EBA1, 14);
            Step(ref ar, F3(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 11), 0x6D703EF3, 12);
            Step(ref el, F3(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 7), 0x6ED9EBA1, 8);
            Step(ref er, F3(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 8), 0x6D703EF3, 13);
            Step(ref dl, F3(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 0), 0x6ED9EBA1, 13);
            Step(ref dr, F3(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 12), 0x6D703EF3, 5);
            Step(ref cl, F3(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 6), 0x6ED9EBA1, 6);
            Step(ref cr, F3(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 2), 0x6D703EF3, 14);
            Step(ref bl, F3(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 13), 0x6ED9EBA1, 5);
            Step(ref br, F3(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 10), 0x6D703EF3, 13);
            Step(ref al, F3(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 11), 0x6ED9EBA1, 12);
            Step(ref ar, F3(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 0), 0x6D703EF3, 13);
            Step(ref el, F3(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 5), 0x6ED9EBA1, 7);
            Step(ref er, F3(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 4), 0x6D703EF3, 7);
            Step(ref dl, F3(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 12), 0x6ED9EBA1, 5);
            Step(ref dr, F3(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 13), 0x6D703EF3, 5);
            // Round 3
            Step(ref cl, F4(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 1), 0x8F1BBCDC, 11);
            Step(ref cr, F2(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 8), 0x7A6D76E9, 15);
            Step(ref bl, F4(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 9), 0x8F1BBCDC, 12);
            Step(ref br, F2(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 6), 0x7A6D76E9, 5);
            Step(ref al, F4(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 11), 0x8F1BBCDC, 14);
            Step(ref ar, F2(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 4), 0x7A6D76E9, 8);
            Step(ref el, F4(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 10), 0x8F1BBCDC, 15);
            Step(ref er, F2(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 1), 0x7A6D76E9, 11);
            Step(ref dl, F4(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 0), 0x8F1BBCDC, 14);
            Step(ref dr, F2(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 3), 0x7A6D76E9, 14);
            Step(ref cl, F4(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 8), 0x8F1BBCDC, 15);
            Step(ref cr, F2(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 11), 0x7A6D76E9, 14);
            Step(ref bl, F4(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 12), 0x8F1BBCDC, 9);
            Step(ref br, F2(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 15), 0x7A6D76E9, 6);
            Step(ref al, F4(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 4), 0x8F1BBCDC, 8);
            Step(ref ar, F2(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 0), 0x7A6D76E9, 14);
            Step(ref el, F4(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 13), 0x8F1BBCDC, 9);
            Step(ref er, F2(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 5), 0x7A6D76E9, 6);
            Step(ref dl, F4(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 3), 0x8F1BBCDC, 14);
            Step(ref dr, F2(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 12), 0x7A6D76E9, 9);
            Step(ref cl, F4(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 7), 0x8F1BBCDC, 5);
            Step(ref cr, F2(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 2), 0x7A6D76E9, 12);
            Step(ref bl, F4(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 15), 0x8F1BBCDC, 6);
            Step(ref br, F2(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 13), 0x7A6D76E9, 9);
            Step(ref al, F4(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 14), 0x8F1BBCDC, 8);
            Step(ref ar, F2(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 9), 0x7A6D76E9, 12);
            Step(ref el, F4(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 5), 0x8F1BBCDC, 6);
            Step(ref er, F2(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 7), 0x7A6D76E9, 5);
            Step(ref dl, F4(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 6), 0x8F1BBCDC, 5);
            Step(ref dr, F2(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 10), 0x7A6D76E9, 15);
            Step(ref cl, F4(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 2), 0x8F1BBCDC, 12);
            Step(ref cr, F2(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 14), 0x7A6D76E9, 8);
            // Round 4
            Step(ref bl, F5(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 4), 0xA953FD4E, 9);
            Step(ref br, F1(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 12), 0x00000000, 8);
            Step(ref al, F5(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 0), 0xA953FD4E, 15);
            Step(ref ar, F1(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 15), 0x00000000, 5);
            Step(ref el, F5(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 5), 0xA953FD4E, 5);
            Step(ref er, F1(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 10), 0x00000000, 12);
            Step(ref dl, F5(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 9), 0xA953FD4E, 11);
            Step(ref dr, F1(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 4), 0x00000000, 9);
            Step(ref cl, F5(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 7), 0xA953FD4E, 6);
            Step(ref cr, F1(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 1), 0x00000000, 12);
            Step(ref bl, F5(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 12), 0xA953FD4E, 8);
            Step(ref br, F1(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 5), 0x00000000, 5);
            Step(ref al, F5(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 2), 0xA953FD4E, 13);
            Step(ref ar, F1(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 8), 0x00000000, 14);
            Step(ref el, F5(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 10), 0xA953FD4E, 12);
            Step(ref er, F1(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 7), 0x00000000, 6);
            Step(ref dl, F5(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 14), 0xA953FD4E, 5);
            Step(ref dr, F1(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 6), 0x00000000, 8);
            Step(ref cl, F5(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 1), 0xA953FD4E, 12);
            Step(ref cr, F1(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 2), 0x00000000, 13);
            Step(ref bl, F5(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 3), 0xA953FD4E, 13);
            Step(ref br, F1(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 13), 0x00000000, 6);
            Step(ref al, F5(bl, cl, dl), ref cl, el, Unsafe.Add(ref xPtr, 8), 0xA953FD4E, 14);
            Step(ref ar, F1(br, cr, dr), ref cr, er, Unsafe.Add(ref xPtr, 14), 0x00000000, 5);
            Step(ref el, F5(al, bl, cl), ref bl, dl, Unsafe.Add(ref xPtr, 11), 0xA953FD4E, 11);
            Step(ref er, F1(ar, br, cr), ref br, dr, Unsafe.Add(ref xPtr, 0), 0x00000000, 15);
            Step(ref dl, F5(el, al, bl), ref al, cl, Unsafe.Add(ref xPtr, 6), 0xA953FD4E, 8);
            Step(ref dr, F1(er, ar, br), ref ar, cr, Unsafe.Add(ref xPtr, 3), 0x00000000, 13);
            Step(ref cl, F5(dl, el, al), ref el, bl, Unsafe.Add(ref xPtr, 15), 0xA953FD4E, 5);
            Step(ref cr, F1(dr, er, ar), ref er, br, Unsafe.Add(ref xPtr, 9), 0x00000000, 11);
            Step(ref bl, F5(cl, dl, el), ref dl, al, Unsafe.Add(ref xPtr, 13), 0xA953FD4E, 6);
            Step(ref br, F1(cr, dr, er), ref dr, ar, Unsafe.Add(ref xPtr, 11), 0x00000000, 11);

            uint t = _h1 + cl + dr;
            _h1 = _h2 + dl + er;
            _h2 = _h3 + el + ar;
            _h3 = _h4 + al + br;
            _h4 = _h0 + bl + cr;
            _h0 = t;
        }
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static void Step(ref uint a, uint f, ref uint c, uint e, uint x, uint k, int s)
    {
        a = BitOperations.RotateLeft(a + f + x + k, s) + e;
        c = BitOperations.RotateLeft(c, 10);
    }

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static uint F1(uint x, uint y, uint z) => x ^ y ^ z;

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static uint F2(uint x, uint y, uint z) => (x & y) | (~x & z);

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static uint F3(uint x, uint y, uint z) => (x | ~y) ^ z;

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static uint F4(uint x, uint y, uint z) => (x & z) | (y & ~z);

    [MethodImpl(MethodImplOptionsEx.HotPath)]
    private static uint F5(uint x, uint y, uint z) => x ^ (y | ~z);
}
