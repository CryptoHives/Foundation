// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the SHA3-224 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA3-224 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs.
/// </para>
/// <para>
/// SHA3-224 produces a 224-bit (28-byte) hash value.
/// </para>
/// </remarks>
public sealed class SHA3_224 : KeccakCore
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
    /// The rate in bytes (1152 bits for SHA3-224).
    /// </summary>
    public const int RateBytes = 144;

    /// <summary>
    /// The capacity in bytes.
    /// </summary>
    public const int CapacityBytes = 56;

    /// <summary>
    /// The SHA-3 domain separation byte.
    /// </summary>
    private const byte DomainSeparator = 0x06;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA3_224"/> class.
    /// </summary>
    public SHA3_224() : this(SimdSupport.Default)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA3_224"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal SHA3_224(SimdSupport simdSupport) : base(RateBytes, simdSupport)
    {
        HashSizeValue = HashSizeBits;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA3-224";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA3_224"/> class.
    /// </summary>
    /// <returns>A new SHA3-224 hash algorithm instance.</returns>
    public static new SHA3_224 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="SHA3_224"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new SHA3-224 hash algorithm instance.</returns>
    internal static SHA3_224 Create(SimdSupport simdSupport) => new(simdSupport);

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
