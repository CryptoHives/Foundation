// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Buffers.Binary;

/// <summary>
/// Computes the Poly1305 message authentication code for the input data.
/// </summary>
/// <remarks>
/// <para>
/// Poly1305 is a fast one-time authenticator designed by Daniel J. Bernstein,
/// defined in RFC 8439. It is commonly used with ChaCha20 for authenticated encryption.
/// </para>
/// <para>
/// <strong>Important:</strong> Poly1305 is a one-time authenticator. The key must
/// never be reused for different messages. Each message requires a unique key.
/// </para>
/// <para>
/// The 32-byte key is split into two parts:
/// <list type="bullet">
/// <item><description>r (first 16 bytes): The secret multiplier, clamped to specific bit patterns</description></item>
/// <item><description>s (last 16 bytes): The secret addend for the final tag</description></item>
/// </list>
/// </para>
/// <para>
/// The output is always 128 bits (16 bytes).
/// </para>
/// </remarks>
public sealed class Poly1305 : HashAlgorithm
{
    private const int KeySizeBytes = 32;
    private const int TagSizeBytes = 16;
    private const int TagSizeBits = 128;
    private const int BlockSizeBytes = 16;

    private readonly byte[] _key;
    private readonly ulong _r0, _r1;
    private readonly ulong _s0, _s1;
    private readonly byte[] _buffer;
    private ulong _h0, _h1, _h2;
    private int _bufferLength;
    private bool _initialized;

    /// <summary>
    /// Initializes a new instance of the <see cref="Poly1305"/> class.
    /// </summary>
    /// <param name="key">The 32-byte secret key (must be unique per message).</param>
    /// <exception cref="ArgumentNullException">Thrown when key is null.</exception>
    /// <exception cref="ArgumentException">Thrown when key is not exactly 32 bytes.</exception>
    public Poly1305(byte[] key)
    {
        if (key is null) throw new ArgumentNullException(nameof(key), "Key cannot be null.");
        if (key.Length != KeySizeBytes)
            throw new ArgumentException($"Key must be exactly {KeySizeBytes} bytes.", nameof(key));

        _key = (byte[])key.Clone();
        _buffer = new byte[BlockSizeBytes];

        // Extract and clamp r (first 16 bytes)
        ulong t0 = BinaryPrimitives.ReadUInt64LittleEndian(key.AsSpan(0, 8));
        ulong t1 = BinaryPrimitives.ReadUInt64LittleEndian(key.AsSpan(8, 8));

        // Clamp r: clear bits 4, 8, 12, 16... and bits 64, 68, 72...
        // r[3], r[7], r[11], r[15] have their top 4 bits cleared
        // r[4], r[8], r[12] have their bottom 2 bits cleared
        _r0 = t0 & 0x0FFFFFFC0FFFFFFF;
        _r1 = t1 & 0x0FFFFFFC0FFFFFFC;

        // Extract s (last 16 bytes)
        _s0 = BinaryPrimitives.ReadUInt64LittleEndian(key.AsSpan(16, 8));
        _s1 = BinaryPrimitives.ReadUInt64LittleEndian(key.AsSpan(24, 8));

        HashSizeValue = TagSizeBits;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Poly1305";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets a copy of the secret key.
    /// </summary>
    public byte[] Key => (byte[])_key.Clone();

    /// <summary>
    /// Creates a new Poly1305 instance.
    /// </summary>
    /// <param name="key">The 32-byte secret key.</param>
    /// <returns>A new Poly1305 instance.</returns>
    public static Poly1305 Create(byte[] key) => new(key);

    /// <inheritdoc/>
    public override void Initialize()
    {
        _h0 = 0;
        _h1 = 0;
        _h2 = 0;
        _bufferLength = 0;
        Array.Clear(_buffer, 0, BlockSizeBytes);
        _initialized = true;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (!_initialized)
        {
            Initialize();
        }

        int offset = 0;

        // Process any buffered data first
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(BlockSizeBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == BlockSizeBytes)
            {
                ProcessBlock(_buffer, isFinal: false);
                _bufferLength = 0;
            }
        }

        // Process complete blocks
        while (offset + BlockSizeBytes <= source.Length)
        {
            ProcessBlock(source.Slice(offset, BlockSizeBytes), isFinal: false);
            offset += BlockSizeBytes;
        }

        // Buffer remaining data
        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += source.Length - offset;
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < TagSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Process final partial block if any
        if (_bufferLength > 0)
        {
            // Pad with zeros and set the final bit
            Array.Clear(_buffer, _bufferLength, BlockSizeBytes - _bufferLength);
            ProcessBlock(_buffer.AsSpan(0, _bufferLength), isFinal: true);
        }

        // Compute tag = (h + s) mod 2^128
        Finalize(destination);

        bytesWritten = TagSizeBytes;
        _initialized = false;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_key);
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Processes a single block of data.
    /// </summary>
    /// <param name="block">The block to process.</param>
    /// <param name="isFinal">True if this is a partial final block.</param>
    private void ProcessBlock(ReadOnlySpan<byte> block, bool isFinal)
    {
        // Read block as little-endian integers
        ulong t0, t1;
        byte hibit;

        if (isFinal && block.Length < BlockSizeBytes)
        {
            // Partial block: pad and add 0x01 after the data
            Span<byte> padded = stackalloc byte[BlockSizeBytes + 1];
            padded.Clear();
            block.CopyTo(padded);
            padded[block.Length] = 0x01;

            t0 = BinaryPrimitives.ReadUInt64LittleEndian(padded.Slice(0, 8));
            t1 = BinaryPrimitives.ReadUInt64LittleEndian(padded.Slice(8, 8));
            hibit = 0; // No high bit for partial blocks
        }
        else
        {
            t0 = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(0, 8));
            t1 = BinaryPrimitives.ReadUInt64LittleEndian(block.Slice(8, 8));
            hibit = 1; // Full block gets high bit
        }

        // h += block
        unchecked
        {
            ulong h0 = _h0;
            ulong h1 = _h1;
            ulong h2 = _h2;

            // Add the block to h
            h0 += t0;
            ulong c = h0 < t0 ? 1UL : 0UL;
            h1 += t1 + c;
            c = (h1 < t1 || (c == 1 && h1 == t1)) ? 1UL : 0UL;
            h2 += hibit + c;

            // h *= r (mod 2^130 - 5)
            // We need to compute h * r where h is 130 bits and r is 124 bits
            // Using schoolbook multiplication with 64-bit limbs

            ulong r0 = _r0;
            ulong r1 = _r1;

            // Precompute 5*r for reduction
            ulong s1_5 = (r1 >> 2) + r1; // r1 * 5 / 4, but we handle it properly
            ulong s0_5 = (r0 >> 2) + r0;

            // Multiply and reduce
            // d = h * r
            // d0 = h0*r0 + h1*5*r1 + h2*5*r0
            // d1 = h0*r1 + h1*r0 + h2*5*r1
            // d2 = h2*r0 (partially)

            // For proper 128-bit multiplication, we need to split into 32-bit parts
            // This is a simplified version using the standard Poly1305 approach

            ulong d0, d1, d2, d3, d4;

            // Split r into 26-bit limbs for easier arithmetic
            // Actually, let's use a simpler 64-bit approach

            // h0*r0
            (ulong lo, ulong hi) = Multiply64(h0, r0);
            d0 = lo;
            d1 = hi;

            // h0*r1
            (lo, hi) = Multiply64(h0, r1);
            d1 += lo;
            d2 = hi + (d1 < lo ? 1UL : 0);

            // h1*r0
            (lo, hi) = Multiply64(h1, r0);
            d1 += lo;
            c = d1 < lo ? 1UL : 0;
            d2 += hi + c;
            d3 = d2 < hi + c ? 1UL : 0;

            // h1*r1
            (lo, hi) = Multiply64(h1, r1);
            d2 += lo;
            c = d2 < lo ? 1UL : 0;
            d3 += hi + c;
            d4 = d3 < hi + c ? 1UL : 0;

            // h2*r0 (h2 is only 3 bits max)
            ulong h2r0 = h2 * r0;
            d2 += h2r0;
            c = d2 < h2r0 ? 1UL : 0;
            d3 += c;
            d4 += d3 < c ? 1UL : 0;

            // h2*r1
            ulong h2r1 = h2 * r1;
            d3 += h2r1;
            d4 += d3 < h2r1 ? 1UL : 0;

            // Now reduce mod 2^130 - 5
            // d = d0 + d1*2^64 + d2*2^128 + d3*2^192 + d4*2^256
            // 2^130 ≡ 5 (mod 2^130 - 5)
            // So d2*2^128 = d2*4*2^126 = d2*4 * 2^126
            // We need to reduce the high bits

            // The result h = d mod (2^130 - 5)
            // h = (d0, d1, d2 & 3) + (d2 >> 2, d3, d4) * 5

            ulong carry;

            // Take bits >= 130 and multiply by 5
            ulong excess = (d2 >> 2) | (d3 << 62);
            ulong excess2 = (d3 >> 2) | (d4 << 62);
            ulong excess3 = d4 >> 2;

            d2 &= 3;
            d3 = 0;
            d4 = 0;

            // Add excess * 5 to (d0, d1, d2)
            (lo, hi) = Multiply64(excess, 5);
            d0 += lo;
            carry = d0 < lo ? 1UL : 0;
            d1 += hi + carry;
            carry = (d1 < hi || (carry == 1 && d1 == hi)) ? 1UL : 0;
            d2 += carry;

            // Add excess2 * 5
            (lo, hi) = Multiply64(excess2, 5);
            d1 += lo;
            carry = d1 < lo ? 1UL : 0;
            d2 += hi + carry;

            // excess3 * 5 (excess3 is very small)
            d2 += excess3 * 5;

            // Final reduction if needed
            excess = d2 >> 2;
            d2 &= 3;
            d0 += excess * 5;
            carry = d0 < excess * 5 ? 1UL : 0;
            d1 += carry;
            d2 += d1 < carry ? 1UL : 0;

            _h0 = d0;
            _h1 = d1;
            _h2 = d2;
        }
    }

    /// <summary>
    /// Finalizes the MAC computation and writes the tag.
    /// </summary>
    /// <param name="destination">The destination for the tag.</param>
    private void Finalize(Span<byte> destination)
    {
        unchecked
        {
            ulong h0 = _h0;
            ulong h1 = _h1;
            ulong h2 = _h2;

            // Final reduction: fully reduce h mod 2^130 - 5
            ulong c = h2 >> 2;
            h2 &= 3;
            h0 += c * 5;
            c = h0 < c * 5 ? 1UL : 0;
            h1 += c;
            h2 += h1 < c ? 1UL : 0;

            // Compute h - (2^130 - 5) to check if h >= 2^130 - 5
            c = h0 + 5;
            ulong g0 = c;
            c = c < 5 ? 1UL : 0;
            c = h1 + c;
            ulong g1 = c;
            c = c < h1 ? 1UL : 0;
            ulong g2 = h2 + c - 4; // This will underflow if h < 2^130 - 5

            // Select h or g based on whether there was a borrow
            ulong mask = (g2 >> 63) - 1; // All 1s if no borrow, all 0s if borrow
            g0 &= mask;
            g1 &= mask;
            h0 = (h0 & ~mask) | g0;
            h1 = (h1 & ~mask) | g1;

            // Add s
            h0 += _s0;
            c = h0 < _s0 ? 1UL : 0;
            h1 += _s1 + c;

            // Output the 128-bit tag
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(0, 8), h0);
            BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(8, 8), h1);
        }
    }

    /// <summary>
    /// Multiplies two 64-bit integers and returns the 128-bit result.
    /// </summary>
    private static (ulong lo, ulong hi) Multiply64(ulong a, ulong b)
    {
        unchecked
        {
#if NET5_0_OR_GREATER
            ulong hi = Math.BigMul(a, b, out ulong lo);
            return (lo, hi);
#else
            // Schoolbook multiplication for 64-bit * 64-bit = 128-bit
            ulong a_lo = (uint)a;
            ulong a_hi = a >> 32;
            ulong b_lo = (uint)b;
            ulong b_hi = b >> 32;

            ulong p0 = a_lo * b_lo;
            ulong p1 = a_lo * b_hi;
            ulong p2 = a_hi * b_lo;
            ulong p3 = a_hi * b_hi;

            ulong mid = p1 + (p0 >> 32);
            mid += p2;
            if (mid < p2) p3 += 1UL << 32;

            ulong lo = (p0 & 0xFFFFFFFF) | (mid << 32);
            ulong hi = p3 + (mid >> 32);

            return (lo, hi);
#endif
        }
    }
}
