// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the Keccak-256 hash for the input data using a clean-room implementation.
/// </summary>
/// <remarks>
/// <para>
/// This is the original Keccak-256 algorithm as used by Ethereum, which differs from
/// SHA3-256 in the domain separator byte (0x01 vs 0x06).
/// </para>
/// <para>
/// Keccak-256 produces a 256-bit (32-byte) hash value.
/// </para>
/// </remarks>
public sealed class Keccak256 : HashAlgorithm
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 256;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// The rate in bytes (1088 bits for Keccak-256).
    /// </summary>
    public const int RateBytes = 136;

    /// <summary>
    /// The original Keccak domain separation byte (different from SHA-3).
    /// </summary>
    private const byte DomainSeparator = 0x01;

    private readonly ulong[] _state;
    private readonly byte[] _buffer;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="Keccak256"/> class.
    /// </summary>
    public Keccak256()
    {
        HashSizeValue = HashSizeBits;
        _state = new ulong[KeccakCore.StateSize];
        _buffer = new byte[RateBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Keccak-256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Keccak256"/> class.
    /// </summary>
    /// <returns>A new Keccak-256 hash algorithm instance.</returns>
    public static new Keccak256 Create() => new();

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

        // Original Keccak padding: 0x01 (NOT 0x06 as in SHA-3)
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
