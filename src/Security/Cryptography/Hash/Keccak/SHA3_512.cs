// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the SHA3-512 hash for the input data using a clean-room implementation.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA3-512 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs.
/// </para>
/// <para>
/// SHA3-512 produces a 512-bit (64-byte) hash value.
/// </para>
/// </remarks>
public sealed class SHA3_512 : HashAlgorithm
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
    /// The rate in bytes (576 bits for SHA3-512).
    /// </summary>
    public const int RateBytes = 72;

    /// <summary>
    /// The capacity in bytes.
    /// </summary>
    public const int CapacityBytes = 128;

    /// <summary>
    /// The SHA-3 domain separation byte.
    /// </summary>
    private const byte DomainSeparator = 0x06;

    private readonly ulong[] _state;
    private readonly byte[] _buffer;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA3_512"/> class.
    /// </summary>
    public SHA3_512()
    {
        HashSizeValue = HashSizeBits;
        _state = new ulong[KeccakCore.StateSize];
        _buffer = new byte[RateBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA3-512";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA3_512"/> class.
    /// </summary>
    /// <returns>A new SHA3-512 hash algorithm instance.</returns>
    public static new SHA3_512 Create() => new();

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Clear(_state, 0, _state.Length);
        ClearBuffer(_buffer);
        _bufferLength = 0;
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
                KeccakCore.Absorb(_state, _buffer, RateBytes);
                _bufferLength = 0;
            }
        }

        while (offset + RateBytes <= source.Length)
        {
            KeccakCore.Absorb(_state, source.Slice(offset, RateBytes), RateBytes);
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

        KeccakCore.Absorb(_state, _buffer, RateBytes);
        KeccakCore.Squeeze(_state, destination, HashSizeBytes);

        bytesWritten = HashSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_state, 0, _state.Length);
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }
}
