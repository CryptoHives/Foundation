// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes a variable-length output using SHAKE128 (XOF) with a clean-room implementation.
/// </summary>
/// <remarks>
/// <para>
/// SHAKE128 is an extendable-output function (XOF) based on the Keccak sponge construction.
/// Unlike traditional hash functions, XOFs can produce output of arbitrary length.
/// </para>
/// <para>
/// SHAKE128 provides 128-bit security strength against all attacks.
/// </para>
/// </remarks>
public sealed class Shake128 : HashAlgorithm
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 256;

    /// <summary>
    /// The rate in bytes (1344 bits for SHAKE128).
    /// </summary>
    public const int RateBytes = 168;

    /// <summary>
    /// The capacity in bytes (256 bits for SHAKE128).
    /// </summary>
    public const int CapacityBytes = 32;

    /// <summary>
    /// The SHAKE domain separation byte.
    /// </summary>
    private const byte DomainSeparator = 0x1F;

    private readonly ulong[] _state;
    private readonly byte[] _buffer;
    private readonly int _outputBytes;
    private int _bufferLength;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="Shake128"/> class with default output size.
    /// </summary>
    public Shake128() : this(DefaultOutputBits / 8)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Shake128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public Shake128(int outputBytes)
    {
        if (outputBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _state = new ulong[KeccakCore.StateSize];
        _buffer = new byte[RateBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "SHAKE128";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Shake128"/> class with default output size.
    /// </summary>
    /// <returns>A new SHAKE128 instance.</returns>
    public static new Shake128 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="Shake128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new SHAKE128 instance.</returns>
    public static Shake128 Create(int outputBytes) => new(outputBytes);

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Clear(_state, 0, _state.Length);
        ClearBuffer(_buffer);
        _bufferLength = 0;
        _finalized = false;
        _squeezeOffset = 0;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_finalized)
        {
            throw new InvalidOperationException("Cannot add data after finalization.");
        }

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
        bytesWritten = _outputBytes;
        Squeeze(destination);
        return true;
    }

    /// <summary>
    /// Squeezes output bytes from the XOF state.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    public void Squeeze(Span<byte> output)
    {
        if (!_finalized)
        {
            // Pad with SHAKE domain separation
            _buffer[_bufferLength++] = DomainSeparator;

            while (_bufferLength < RateBytes - 1)
            {
                _buffer[_bufferLength++] = 0x00;
            }

            _buffer[RateBytes - 1] |= 0x80;

            KeccakCore.Absorb(_state, _buffer, RateBytes);
            _finalized = true;
            _squeezeOffset = 0;
        }

        KeccakCore.SqueezeXof(_state, output, RateBytes, ref _squeezeOffset);
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
