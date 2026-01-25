// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes a variable-length output using TurboSHAKE128 (XOF) per RFC 9861.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of TurboSHAKE128 based on the reduced-round
/// Keccak permutation. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// TurboSHAKE128 is an extendable-output function (XOF) based on a reduced-round
/// Keccak-p[1600, n_r=12] permutation with 12 rounds instead of 24 used in SHAKE.
/// It provides 128-bit security strength and is approximately twice as fast as SHAKE128.
/// </para>
/// <para>
/// TurboSHAKE128 uses a rate of 168 bytes (1344 bits) and a capacity of 32 bytes (256 bits).
/// </para>
/// <para>
/// The domain separation byte D must be in the range [0x01, 0x7F]. The default value is 0x1F.
/// </para>
/// </remarks>
public sealed class TurboShake128 : KeccakCore
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 256;

    /// <summary>
    /// The rate in bytes (1344 bits for TurboSHAKE128).
    /// </summary>
    public const int RateBytes = 168;

    /// <summary>
    /// The capacity in bytes (256 bits for TurboSHAKE128).
    /// </summary>
    public const int CapacityBytes = 32;

    /// <summary>
    /// The number of rounds for TurboSHAKE (12 rounds).
    /// </summary>
    public const int Rounds = 12;

    /// <summary>
    /// The default domain separation byte.
    /// </summary>
    public const byte DefaultDomainSeparator = 0x1F;

    private readonly int _outputBytes;
    private readonly byte _domainSeparator;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="TurboShake128"/> class with default output size.
    /// </summary>
    public TurboShake128() : this(DefaultOutputBits / 8, DefaultDomainSeparator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TurboShake128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public TurboShake128(int outputBytes) : this(outputBytes, DefaultDomainSeparator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TurboShake128"/> class with specified output size and domain separator.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="domainSeparator">The domain separation byte (must be in range [0x01, 0x7F]).</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="outputBytes"/> is not positive or
    /// <paramref name="domainSeparator"/> is not in range [0x01, 0x7F].
    /// </exception>
    public TurboShake128(int outputBytes, byte domainSeparator) : this(SimdSupport.KeccakDefault, outputBytes, domainSeparator)
    {
    }

    internal TurboShake128(SimdSupport simdSupport, int outputBytes, byte domainSeparator) : base(RateBytes, simdSupport)
    {
        if (outputBytes <= 0) throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        if (domainSeparator < 0x01 || domainSeparator > 0x7F) throw new ArgumentOutOfRangeException(nameof(domainSeparator), "Domain separator must be in range [0x01, 0x7F].");

        _outputBytes = outputBytes;
        _domainSeparator = domainSeparator;
        HashSizeValue = outputBytes * 8;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "TurboSHAKE128";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Gets the domain separation byte used by this instance.
    /// </summary>
    public byte DomainSeparator => _domainSeparator;

    /// <summary>
    /// Creates a new instance of the <see cref="TurboShake128"/> class with default output size.
    /// </summary>
    /// <returns>A new TurboSHAKE128 instance.</returns>
    public static new TurboShake128 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="TurboShake128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new TurboSHAKE128 instance.</returns>
    public static TurboShake128 Create(int outputBytes) => new(outputBytes);

    internal static TurboShake128 Create(SimdSupport simdSupport, int outputBytes) => new(simdSupport, outputBytes, DefaultDomainSeparator);

    /// <summary>
    /// Creates a new instance of the <see cref="TurboShake128"/> class with specified output size and domain separator.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="domainSeparator">The domain separation byte (must be in range [0x01, 0x7F]).</param>
    /// <returns>A new TurboSHAKE128 instance.</returns>
    public static TurboShake128 Create(int outputBytes, byte domainSeparator) => new(outputBytes, domainSeparator);

    internal static TurboShake128 Create(SimdSupport simdSupport, int outputBytes, byte domainSeparator)
        => new(simdSupport, outputBytes, domainSeparator);

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();
        _finalized = false;
        _squeezeOffset = 0;
    }

    /// <summary>
    /// Absorbs a block of input data into the hash state.
    /// </summary>
    /// <param name="data">The data to absorb.</param>
    public void TransformBlock(ReadOnlySpan<byte> data)
    {
        HashCore(data);
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
                _keccakCore.Absorb(_buffer, RateBytes, startRound: 12);
                _bufferLength = 0;
            }
        }

        while (offset + RateBytes <= source.Length)
        {
            _keccakCore.Absorb(source.Slice(offset, RateBytes), RateBytes, startRound: 12);
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
        Squeeze(destination.Slice(0, _outputBytes));
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
            // TurboSHAKE padding per RFC 9861:
            // Append domain separator D, then zeros, then XOR 0x80 to last byte
            _buffer[_bufferLength++] = _domainSeparator;

            while (_bufferLength < RateBytes - 1)
            {
                _buffer[_bufferLength++] = 0x00;
            }

            _buffer[RateBytes - 1] |= 0x80;

            _keccakCore.Absorb(_buffer, RateBytes, startRound: 12);
            _finalized = true;
            _squeezeOffset = 0;
        }

        _keccakCore.SqueezeXof(output, RateBytes, ref _squeezeOffset, startRound: 12);
    }
}
