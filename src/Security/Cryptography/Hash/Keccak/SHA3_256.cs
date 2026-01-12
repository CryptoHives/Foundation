// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the SHA3-256 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of SHA3-256 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs.
/// </para>
/// <para>
/// SHA3-256 produces a 256-bit (32-byte) hash value.
/// </para>
/// </remarks>
public sealed class SHA3_256 : HashAlgorithm
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
    /// The rate in bytes (1088 bits for SHA3-256).
    /// </summary>
    public const int RateBytes = 136;

    /// <summary>
    /// The capacity in bytes.
    /// </summary>
    public const int CapacityBytes = 64;

    /// <summary>
    /// The SHA-3 domain separation byte.
    /// </summary>
    private const byte DomainSeparator = 0x06;

    private readonly ulong[] _state;
    private readonly byte[] _buffer;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="SHA3_256"/> class.
    /// </summary>
    public SHA3_256()
    {
        HashSizeValue = HashSizeBits;
        _state = new ulong[KeccakCore.StateSize];
        _buffer = new byte[RateBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHA3-256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="SHA3_256"/> class.
    /// </summary>
    /// <returns>A new SHA3-256 hash algorithm instance.</returns>
    public static new SHA3_256 Create() => new();

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

        // If we have data in buffer, fill it first
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

        // Process full blocks
        while (offset + RateBytes <= source.Length)
        {
            KeccakCore.Absorb(_state, source.Slice(offset, RateBytes), RateBytes);
            offset += RateBytes;
        }

        // Store remaining bytes
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

        // Pad with SHA-3 domain separation
        _buffer[_bufferLength++] = DomainSeparator;

        // Zero-pad
        while (_bufferLength < RateBytes - 1)
        {
            _buffer[_bufferLength++] = 0x00;
        }

        // Set last bit
        _buffer[RateBytes - 1] |= 0x80;

        // Absorb final block
        KeccakCore.Absorb(_state, _buffer, RateBytes);

        // Squeeze output (SHA3-256 only needs one squeeze since output <= rate)
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
