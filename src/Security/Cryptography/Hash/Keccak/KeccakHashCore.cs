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
public abstract class KeccakHashCore : KeccakCore
{
    private protected readonly int _outputBytes;
    private protected readonly byte _domainSeparator;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeccakHashCore"/> class.
    /// </summary>
    /// <param name="rateBytes">The rate in bytes for the sponge construction.</param>
    /// <param name="outputBytes">The output size of the hash in bytes for this variant.</param>
    /// <param name="domainSeparator">The domain separation byte for this variant.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    internal KeccakHashCore(int rateBytes, int outputBytes, byte domainSeparator, SimdSupport simdSupport = SimdSupport.KeccakDefault)
        : base(rateBytes, simdSupport)
    {
        _outputBytes = outputBytes;
        _domainSeparator = domainSeparator;
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Clear the last byte to prevent stale buffer data from leaking into the
        // padding when the buffer was previously absorbed but not zeroed.
        _buffer[_rateBytes - 1] = 0x00;

        // Pad with domain separation byte
        _buffer[_bufferLength++] = _domainSeparator;

        // Zero-pad
        while (_bufferLength < _rateBytes - 1)
        {
            _buffer[_bufferLength++] = 0x00;
        }

        // Set last bit (OR preserves domain separator if it landed at this position)
        _buffer[_rateBytes - 1] |= 0x80;

        // Absorb final block
        _keccakCore.Absorb(_buffer, _rateBytes);

        // Squeeze output (fixed-length variants only need one squeeze since output <= rate)
        _keccakCore.Squeeze(destination, _outputBytes);

        bytesWritten = _outputBytes;
        return true;
    }
}
