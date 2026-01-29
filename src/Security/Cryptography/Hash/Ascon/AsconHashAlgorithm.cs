// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Base class for Ascon family hash algorithms, providing common sponge construction logic.
/// </summary>
/// <remarks>
/// This base class eliminates code duplication across Ascon variants (AsconHash256, AsconXof128)
/// by providing common implementations of HashCore, Initialize, and Dispose.
/// Derived classes only need to provide IV constants and output squeezing logic.
/// </remarks>
public abstract class AsconHashAlgorithm : HashAlgorithm
{
    /// <summary>
    /// The rate in bytes (64 bits = 8 bytes) for all Ascon variants.
    /// </summary>
    public const int RateBytes = 8;

    /// <summary>
    /// The internal state (5 x 64-bit words).
    /// </summary>
    private protected ulong _x0, _x1, _x2, _x3, _x4;
    private readonly byte[] _buffer;
    private int _bufferLength;

    /// <summary>
    /// Gets the initialization vector values for this variant.
    /// </summary>
    protected abstract (ulong IV0, ulong IV1, ulong IV2, ulong IV3, ulong IV4) InitializationVector { get; }

    /// <summary>
    /// Gets the output size in bytes for this variant.
    /// </summary>
    protected abstract int OutputSizeBytes { get; }

    /// <summary>
    /// Squeezes the output from the internal state.
    /// </summary>
    /// <param name="destination">The destination span for the output.</param>
    protected abstract void SqueezeOutput(Span<byte> destination);

    /// <summary>
    /// Initializes a new instance of the <see cref="AsconHashAlgorithm"/> class.
    /// </summary>
    protected AsconHashAlgorithm()
    {
        _buffer = new byte[RateBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <inheritdoc/>
    public sealed override void Initialize()
    {
        // Initialize state with variant-specific IV
        var iv = InitializationVector;
        _x0 = iv.IV0;
        _x1 = iv.IV1;
        _x2 = iv.IV2;
        _x3 = iv.IV3;
        _x4 = iv.IV4;

        ClearBuffer(_buffer);
        _bufferLength = 0;
    }

    /// <inheritdoc/>
    protected sealed override void HashCore(ReadOnlySpan<byte> source)
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
                AbsorbBlock(_buffer);
                _bufferLength = 0;
            }
        }

        // Process full blocks directly from source
        while (offset + RateBytes <= source.Length)
        {
            AbsorbBlock(source.Slice(offset, RateBytes));
            offset += RateBytes;
        }

        // Buffer remaining bytes
        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan());
            _bufferLength = source.Length - offset;
        }
    }

    /// <inheritdoc/>
    protected sealed override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < OutputSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Pad and absorb final block (NIST SP 800-232 padding)
        PadAndAbsorb();

        // Squeeze output (variant-specific)
        SqueezeOutput(destination);

        bytesWritten = OutputSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected sealed override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_buffer);
            _x0 = _x1 = _x2 = _x3 = _x4 = 0;
        }
        base.Dispose(disposing);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void AbsorbBlock(ReadOnlySpan<byte> block)
    {
        // XOR block into x0 (rate portion) - little-endian
        _x0 ^= BinaryPrimitives.ReadUInt64LittleEndian(block);

        // Apply permutation p^12
        AsconCore.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
    }

    private void PadAndAbsorb()
    {
        // NIST SP 800-232 padding: pad with 0x01 at bit position
        int finalBits = _bufferLength << 3;
        ulong paddedBlock = BinaryPrimitives.ReadUInt64LittleEndian(_buffer);
        paddedBlock &= 0x00FFFFFFFFFFFFFFUL >> (56 - finalBits);
        paddedBlock ^= 0x01UL << finalBits;

        _x0 ^= paddedBlock;
        AsconCore.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
    }
}
