// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the Ascon-XOF128 (Extendable Output Function) for the input data.
/// </summary>
/// <remarks>
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
public sealed class AsconXof128 : HashAlgorithm
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputSizeBits = 256;

    /// <summary>
    /// The default output size in bytes.
    /// </summary>
    public const int DefaultOutputSizeBytes = DefaultOutputSizeBits / 8;

    /// <summary>
    /// The rate in bytes (64 bits = 8 bytes).
    /// </summary>
    public const int RateBytes = 8;

    // Pre-computed initial state: P12(0x0000080000cc0003, 0, 0, 0, 0)
    // per NIST SP 800-232
    private const ulong IV0 = 0xda82ce768d9447ebUL;
    private const ulong IV1 = 0xcc7ce6c75f1ef969UL;
    private const ulong IV2 = 0xe7508fd780085631UL;
    private const ulong IV3 = 0x0ee0ea53416b58ccUL;
    private const ulong IV4 = 0xe0547524db6f0bdeUL;

    // State: 5 x 64-bit words = 320 bits
    private ulong _x0, _x1, _x2, _x3, _x4;
    private readonly byte[] _buffer;
    private int _bufferLength;
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
        _buffer = new byte[RateBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Ascon-XOF128";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

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
    public override void Initialize()
    {
        // Initialize state with pre-computed IV
        _x0 = IV0;
        _x1 = IV1;
        _x2 = IV2;
        _x3 = IV3;
        _x4 = IV4;

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
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Pad and absorb final block (NIST SP 800-232 padding)
        PadAndAbsorb();

        // Squeeze output
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
                Span<byte> block = stackalloc byte[RateBytes];
                BinaryPrimitives.WriteUInt64LittleEndian(block, _x0);
                block.Slice(0, toCopy).CopyTo(destination.Slice(destOffset));
            }

            destOffset += toCopy;
            remaining -= toCopy;

            if (remaining > 0)
            {
                Ascon800232Core.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
            }
        }

        bytesWritten = _outputSizeBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
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
        Ascon800232Core.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
    }

    private void PadAndAbsorb()
    {
        // NIST SP 800-232 padding: pad with 0x01 at bit position
        int finalBits = _bufferLength << 3;
        ulong paddedBlock = BinaryPrimitives.ReadUInt64LittleEndian(_buffer);
        paddedBlock &= 0x00FFFFFFFFFFFFFFUL >> (56 - finalBits);
        paddedBlock ^= 0x01UL << finalBits;

        _x0 ^= paddedBlock;
        Ascon800232Core.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
    }
}
