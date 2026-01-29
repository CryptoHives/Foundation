// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// All algorithms based on the Keccak permutation should derive from this class.
/// Provides the derived implementations with the core Keccak-f[1600] permutation,
/// state variables and a buffer for the rate bytes.
/// </summary>
/// <remarks>
/// <para>
/// This class holds the Keccak state used by SHA-3, SHAKE, cSHAKE, KMAC,
/// and related algorithms. It is designed as a shared primitive to reduce code
/// duplication across Keccak-based implementations.
/// </para>
/// <para>
/// The Keccak state is a 5×5×64 = 1600-bit array organized as 25 64-bit lanes.
/// </para>
/// <para>
/// On platforms with AVX512F support (.NET 8+), an optimized SIMD implementation can be used.
/// </para>
/// </remarks>
public abstract class KeccakCore : HashAlgorithm
{
    // KeccakCoreState is a struct and shall never be readonly
    private protected KeccakCoreState _keccakCore;
    private protected readonly byte[] _buffer;
    private protected readonly int _rateBytes;
    private protected int _bufferLength;

    internal KeccakCore(int rateBytes, SimdSupport simdSupport = SimdSupport.KeccakDefault)
        : this (rateBytes, 0, simdSupport)
    {
    }

    internal KeccakCore(int rateBytes, int startRound, SimdSupport simdSupport = SimdSupport.KeccakDefault)
    {
        _keccakCore = new KeccakCoreState(simdSupport, startRound);
        _buffer = new byte[rateBytes];
        _rateBytes = rateBytes;
    }

    /// <inheritdoc/>
    public override void Initialize()
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
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _keccakCore.Reset();
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }
}
