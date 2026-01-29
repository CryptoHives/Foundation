// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers.Binary;

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
public sealed class AsconHash256 : AsconHashAlgorithm
{
    /// <summary>
    /// The hash size in bits.
    /// </summary>
    public const int HashSizeBits = 256;

    /// <summary>
    /// The hash size in bytes.
    /// </summary>
    public const int HashSizeBytes = HashSizeBits / 8;

    // Pre-computed initial state: P12(0x0000080100cc0002, 0, 0, 0, 0) per NIST SP 800-232
    private const ulong IV0 = 0x9b1e5494e934d681UL;
    private const ulong IV1 = 0x4bc3a01e333751d2UL;
    private const ulong IV2 = 0xae65396c6b34b81aUL;
    private const ulong IV3 = 0x3c7fd4a4d56a4db3UL;
    private const ulong IV4 = 0x1a5c464906c5976dUL;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsconHash256"/> class.
    /// </summary>
    public AsconHash256()
    {
        HashSizeValue = HashSizeBits;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "Ascon-Hash256";

    /// <inheritdoc/>
    protected override (ulong IV0, ulong IV1, ulong IV2, ulong IV3, ulong IV4) InitializationVector =>
        (IV0, IV1, IV2, IV3, IV4);

    /// <inheritdoc/>
    protected override int OutputSizeBytes => HashSizeBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="AsconHash256"/> class.
    /// </summary>
    /// <returns>A new Ascon-Hash256 algorithm instance.</returns>
    public static new AsconHash256 Create() => new();

    /// <inheritdoc/>
    protected override void SqueezeOutput(Span<byte> destination)
    {
        // Squeeze output: 4 blocks of 64 bits = 256 bits
        BinaryPrimitives.WriteUInt64LittleEndian(destination, _x0);
        AsconCore.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
        BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(8), _x0);
        AsconCore.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
        BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(16), _x0);
        AsconCore.P12(ref _x0, ref _x1, ref _x2, ref _x3, ref _x4);
        BinaryPrimitives.WriteUInt64LittleEndian(destination.Slice(24), _x0);
    }
}
