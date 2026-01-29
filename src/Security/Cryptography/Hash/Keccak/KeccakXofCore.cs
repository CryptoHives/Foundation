// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Base class for Keccak-based extendable-output functions (XOF) with variable-length output.
/// </summary>
/// <remarks>
/// This base class provides common sponge construction logic for all Keccak XOF variants,
/// eliminating code duplication across SHAKE128, SHAKE256, TurboShake128, TurboShake256,
/// cSHAKE128, and cSHAKE256.
/// </remarks>
public abstract class KeccakXofCore : KeccakCore
{
    private protected readonly int _outputBytes;
    private protected readonly byte _domainSeparator;
    private protected bool _finalized;
    private protected int _squeezeOffset;

    /// <summary>
    /// Gets the starting round for the permutation. Override to return 12 for TurboShake variants.
    /// </summary>
    protected virtual int StartRound => 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeccakXofCore"/> class.
    /// </summary>
    /// <param name="rateBytes">The rate in bytes for the sponge construction.</param>
    /// <param name="outputBytes">The output size in bytes for this variant.</param>
    /// <param name="domainSeparator">The domain separation byte for this variant.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    internal KeccakXofCore(int rateBytes, int outputBytes, byte domainSeparator, SimdSupport simdSupport = SimdSupport.KeccakDefault)
        : base(rateBytes, simdSupport)
    {
        _outputBytes = outputBytes;
        _domainSeparator = domainSeparator;
    }

    /// <inheritdoc/>
    public sealed override void Initialize()
    {
        base.Initialize();
        _finalized = false;
        _squeezeOffset = 0;
    }

    /// <inheritdoc/>
    protected sealed override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_finalized)
        {
            throw new InvalidOperationException("Cannot add more data after output has been read.");
        }

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
                _keccakCore.Absorb(_buffer, _rateBytes, StartRound);
                _bufferLength = 0;
            }
        }

        // Process full blocks
        while (offset + _rateBytes <= source.Length)
        {
            _keccakCore.Absorb(source.Slice(offset, _rateBytes), _rateBytes, StartRound);
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
    protected sealed override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        Squeeze(destination.Slice(0, _outputBytes));

        bytesWritten = _outputBytes;
        return true;
    }

    /// <summary>
    /// Squeezes output bytes from the XOF state.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    public void Squeeze(Span<byte> output)
    {
        // Finalize if not already done
        if (!_finalized)
        {
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
            _keccakCore.Absorb(_buffer, _rateBytes, StartRound);
            _finalized = true;
            _squeezeOffset = 0;
        }

        // Squeeze output
        _keccakCore.SqueezeXof(output, _rateBytes, ref _squeezeOffset, StartRound);
    }

    /// <summary>
    /// Absorbs input data into the sponge state (convenience method for XOF usage).
    /// </summary>
    /// <param name="input">The input data to absorb.</param>
    public void TransformBlock(ReadOnlySpan<byte> input)
    {
        HashCore(input);
    }
}
