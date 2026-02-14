// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;

/// <summary>
/// Computes the Ascon-XOF128 (Extendable Output Function) for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of Ascon-XOF128 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// Ascon-XOF128 is defined in NIST SP 800-232.
/// It is based on the Ascon permutation with 12 rounds and produces variable-length output.
/// </para>
/// <para>
/// Ascon was the winner of the NIST Lightweight Cryptography competition (2023).
/// </para>
/// <para>
/// References:
/// <list type="bullet">
/// <item><see href="https://csrc.nist.gov/pubs/sp/800/232/final">NIST SP 800-232</see></item>
/// <item><see href="https://github.com/ascon/ascon-c">Reference Implementation</see></item>
/// <item><see href="https://ascon.iaik.tugraz.at/">Ascon Homepage</see></item>
/// </list>
/// </para>
/// </remarks>
public sealed class AsconXof128 : AsconHashAlgorithm, IExtendableOutput
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputSizeBits = 256;

    /// <summary>
    /// The default output size in bytes.
    /// </summary>
    public const int DefaultOutputSizeBytes = DefaultOutputSizeBits / 8;

    // Pre-computed initial state: P12(0x0000080000cc0003, 0, 0, 0, 0) per NIST SP 800-232
    private const ulong IV0 = 0xda82ce768d9447ebUL;
    private const ulong IV1 = 0xcc7ce6c75f1ef969UL;
    private const ulong IV2 = 0xe7508fd780085631UL;
    private const ulong IV3 = 0x0ee0ea53416b58ccUL;
    private const ulong IV4 = 0xe0547524db6f0bdeUL;

    private readonly int _outputSizeBytes;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsconXof128"/> class with default output size.
    /// </summary>
    public AsconXof128() : this(DefaultOutputSizeBytes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AsconXof128"/> class with the specified output size.
    /// </summary>
    /// <param name="outputSizeBytes">The desired output size in bytes.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when outputSizeBytes is less than 1.</exception>
    public AsconXof128(int outputSizeBytes)
    {
        if (outputSizeBytes < 1) throw new ArgumentOutOfRangeException(nameof(outputSizeBytes), "Output size must be at least 1 byte.");

        _outputSizeBytes = outputSizeBytes;
        HashSizeValue = outputSizeBytes * 8;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Ascon-XOF128";

    /// <inheritdoc/>
    protected override (ulong IV0, ulong IV1, ulong IV2, ulong IV3, ulong IV4) InitializationVector =>
        (IV0, IV1, IV2, IV3, IV4);

    /// <inheritdoc/>
    protected override int OutputSizeBytes => _outputSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="AsconXof128"/> class with default output size.
    /// </summary>
    /// <returns>A new Ascon-XOF128 algorithm instance.</returns>
    public static new AsconXof128 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="AsconXof128"/> class with the specified output size.
    /// </summary>
    /// <param name="outputSizeBytes">The desired output size in bytes.</param>
    /// <returns>A new Ascon-XOF128 algorithm instance.</returns>
    public static AsconXof128 Create(int outputSizeBytes) => new(outputSizeBytes);

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input)
    {
        if (_finalized) throw new InvalidOperationException("Cannot add data after finalization.");
        HashCore(input);
    }

    /// <inheritdoc/>
    public void Reset()
    {
        Initialize();
        _finalized = false;
        _squeezeOffset = 0;
    }

    /// <summary>
    /// Squeezes output bytes from the Ascon-XOF128 state.
    /// </summary>
    /// <remarks>
    /// After the first call, the hash is finalized and no more data can be absorbed.
    /// May be called multiple times for streaming output.
    /// </remarks>
    /// <param name="output">The buffer to receive the output bytes.</param>
    public void Squeeze(Span<byte> output)
    {
        if (!_finalized)
        {
            PadAndAbsorb();
            _finalized = true;
            _squeezeOffset = 0;
        }

        Span<byte> block = stackalloc byte[RateBytes];
        int remaining = output.Length;
        int destOffset = 0;

        // Resume from partial block left by a previous Squeeze call
        if (_squeezeOffset > 0 && remaining > 0)
        {
            int available = RateBytes - _squeezeOffset;
            int toCopy = Math.Min(remaining, available);
            BinaryPrimitives.WriteUInt64LittleEndian(block, _x0);
            block.Slice(_squeezeOffset, toCopy).CopyTo(output.Slice(destOffset));
            destOffset += toCopy;
            remaining -= toCopy;
            _squeezeOffset += toCopy;

            if (_squeezeOffset == RateBytes)
            {
                P12();
                _squeezeOffset = 0;
            }
        }

        // Process full rate blocks
        while (remaining >= RateBytes)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(output.Slice(destOffset), _x0);
            destOffset += RateBytes;
            remaining -= RateBytes;
            P12();
        }

        // Handle trailing partial block
        if (remaining > 0)
        {
            BinaryPrimitives.WriteUInt64LittleEndian(block, _x0);
            block.Slice(0, remaining).CopyTo(output.Slice(destOffset));
            _squeezeOffset = remaining;
        }
    }

    /// <inheritdoc/>
    protected override void SqueezeOutput(Span<byte> destination)
    {
        // Squeeze output
        Span<byte> block = stackalloc byte[RateBytes];
        int remaining = _outputSizeBytes;
        int destOffset = 0;

        while (remaining > 0)
        {
            int toCopy = Math.Min(remaining, RateBytes);
            if (toCopy == RateBytes)
            {
                BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(destOffset), _x0);
            }
            else
            {
                BinaryPrimitives.WriteUInt64LittleEndian(block, _x0);
                block.Slice(0, toCopy).CopyTo(destination.Slice(destOffset));
            }

            remaining -= toCopy;
            destOffset += toCopy;

            if (remaining > 0)
            {
                P12();
            }
        }
    }
}
