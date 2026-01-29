// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Base class for fixed-length Keccak-based hash algorithms (SHA3, Keccak).
/// </summary>
/// <remarks>
/// This base class provides common sponge construction logic for all fixed-length
/// Keccak variants, eliminating code duplication across SHA3-224, SHA3-256, SHA3-384,
/// SHA3-512, Keccak-256, Keccak-384, and Keccak-512.
/// </remarks>
public abstract class KeccakFixedHashCore : HashAlgorithm
{
    // KeccakCoreState is a struct and shall never be readonly
    private protected KeccakCoreState _keccakCore;
    private protected readonly byte[] _buffer;
    private protected readonly int _rateBytes;
    private protected readonly int _outputBytes;
    private protected readonly byte _domainSeparator;
    private protected int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeccakFixedHashCore"/> class.
    /// </summary>
    /// <param name="rateBytes">The rate in bytes for the sponge construction.</param>
    /// <param name="outputBytes">The output size of the hash in bytes for this variant.</param>
    /// <param name="domainSeparator">The domain separation byte for this variant.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    internal KeccakFixedHashCore(int rateBytes, int outputBytes, byte domainSeparator, SimdSupport simdSupport = SimdSupport.KeccakDefault)
    {
        _keccakCore = new KeccakCoreState(simdSupport);
        _buffer = new byte[rateBytes];
        _rateBytes = rateBytes;
        _outputBytes = outputBytes;
        _domainSeparator = domainSeparator;
    }

    /// <inheritdoc/>
    public sealed override void Initialize()
    {
        _keccakCore.Reset();
        ClearBuffer(_buffer);
        _bufferLength = 0;
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport => KeccakCoreState.SimdSupport;

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        int offset = 0;

        // If we have data in buffer, fill it first
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(_rateBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == _rateBytes)
            {
                _keccakCore.Absorb(_buffer, _rateBytes);
                _bufferLength = 0;
            }
        }

        // Process full blocks
        while (offset + _rateBytes <= source.Length)
        {
            _keccakCore.Absorb(source.Slice(offset, _rateBytes), _rateBytes);
            offset += _rateBytes;
        }

        // Store remaining bytes
        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan());
            _bufferLength = source.Length - offset;
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Pad with domain separation byte
        _buffer[_bufferLength++] = _domainSeparator;

        // Zero-pad
        while (_bufferLength < _rateBytes - 1)
        {
            _buffer[_bufferLength++] = 0x00;
        }

        // Set last bit
        _buffer[_rateBytes - 1] |= 0x80;

        // Absorb final block
        _keccakCore.Absorb(_buffer, _rateBytes);

        // Squeeze output (fixed-length variants only need one squeeze since output <= rate)
        _keccakCore.Squeeze(destination, _outputBytes);

        bytesWritten = _outputBytes;
        return true;
    }

    /// <inheritdoc/>
    protected sealed override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _keccakCore.Reset();
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }
}
