// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Computes the Ascon-Hash256 for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of Ascon-Hash256 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// Ascon-Hash256 is defined in NIST SP 800-232.
/// It is based on the Ascon permutation with 12 rounds and produces a 256-bit hash.
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
public sealed class AsconHash256 : HashAlgorithm
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 256;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    /// <summary>
    /// The rate in bytes (64 bits = 8 bytes).
    /// </summary>
    public const int RateBytes = 8;

    // Pre-computed initial state: P12(0x0000080100cc0002, 0, 0, 0, 0)
    // per NIST SP 800-232
    private const ulong IV0 = 0x9b1e5494e934d681UL;
    private const ulong IV1 = 0x4bc3a01e333751d2UL;
    private const ulong IV2 = 0xae65396c6b34b81aUL;
    private const ulong IV3 = 0x3c7fd4a4d56a4db3UL;
    private const ulong IV4 = 0x1a5c464906c5976dUL;

    // State: 5 x 64-bit words = 320 bits
    private ulong _x0, _x1, _x2, _x3, _x4;
    private readonly byte[] _buffer;
    private int _bufferLength;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsconHash256"/> class.
    /// </summary>
    public AsconHash256()
    {
        HashSizeValue = HashSizeBits;
        _buffer = new byte[RateBytes];
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Ascon-Hash256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="AsconHash256"/> class.
    /// </summary>
    /// <returns>A new Ascon-Hash256 algorithm instance.</returns>
    public static new AsconHash256 Create() => new();

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
        if (destination.Length < HashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Pad and absorb final block (NIST SP 800-232 padding)
        PadAndAbsorb();

        // Squeeze output: 4 blocks of 64 bits = 256 bits
        BinaryPrimitives.WriteUInt64LittleEndian(destination, _x0);
        Ascon800232Core.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
        BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(8), _x0);
        Ascon800232Core.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
        BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(16), _x0);
        Ascon800232Core.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
        BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(24), _x0);

        bytesWritten = HashSizeBytes;
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
