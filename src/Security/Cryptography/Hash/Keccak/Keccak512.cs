// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the Keccak-512 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is the original Keccak-512 algorithm, which differs from SHA3-512 in the
/// domain separator byte (0x01 vs 0x06).
/// </para>
/// <para>
/// Keccak-512 produces a 512-bit (64-byte) hash value.
/// </para>
/// </remarks>
public sealed class Keccak512 : KeccakCore
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 512;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// The rate in bytes (576 bits for Keccak-512).
    /// </summary>
    public const int RateBytes = 72;

    /// <summary>
    /// The original Keccak domain separation byte (different from SHA-3).
    /// </summary>
    private const byte DomainSeparator = 0x01;

    /// <summary>
    /// Initializes a new instance of the <see cref="Keccak512"/> class.
    /// </summary>
    public Keccak512() : this(SimdSupport.KeccakDefault)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Keccak512"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Keccak512(SimdSupport simdSupport) : base(RateBytes, simdSupport)
    {
        HashSizeValue = HashSizeBits;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Keccak-512";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Keccak512"/> class.
    /// </summary>
    /// <returns>A new Keccak-512 hash algorithm instance.</returns>
    public static new Keccak512 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Keccak512"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new Keccak-512 hash algorithm instance.</returns>
    internal static Keccak512 Create(SimdSupport simdSupport) => new(simdSupport);

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(RateBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == RateBytes)
            {
                _keccakCore.Absorb(_buffer, RateBytes);
                _bufferLength = 0;
            }
        }

        while (offset + RateBytes <= source.Length)
        {
            _keccakCore.Absorb(source.Slice(offset, RateBytes), RateBytes);
            offset += RateBytes;
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

        // Original Keccak padding: 0x01 (NOT 0x06 as in SHA-3)
        _buffer[_bufferLength++] = DomainSeparator;

        while (_bufferLength < RateBytes - 1)
        {
            _buffer[_bufferLength++] = 0x00;
        }

        _buffer[RateBytes - 1] |= 0x80;

        _keccakCore.Absorb(_buffer, RateBytes);
        _keccakCore.Squeeze(destination, HashSizeBytes);

        bytesWritten = HashSizeBytes;
        return true;
    }
}
