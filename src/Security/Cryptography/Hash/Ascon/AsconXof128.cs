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
public sealed class AsconXof128 : AsconHashAlgorithm
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
                AsconCore.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
            }
        }
    }
}
