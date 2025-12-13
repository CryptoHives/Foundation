// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests;

using System;
using System.IO;
using System.Security.Cryptography;
using HashifyNet;
using HashifyNet.Algorithms.Blake2;
using HashifyNet.Algorithms.Whirlpool;

/// <summary>
/// Wraps a HashifyNET BLAKE2b implementation as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows the HashifyNET BLAKE2b implementation to be used
/// interchangeably with .NET <see cref="HashAlgorithm"/> implementations in tests.
/// </para>
/// <para>
/// HashifyNET provides independent implementations of hash algorithms (not wrappers
/// around .NET APIs), making them suitable as reference implementations for verification.
/// </para>
/// <para>
/// Note: HashifyNET's SHA-1/2/3 and MD5 implementations are wrappers around .NET
/// and should NOT be used as reference implementations. Only use HashifyNET for
/// algorithms with their own implementations: Blake2b, Tiger, Whirlpool, etc.
/// </para>
/// <para>
/// HashifyNET's Blake3 implementation has a known bug at the 1024-byte chunk boundary
/// and should not be used as a reference until fixed.
/// </para>
/// <para>
/// Note: HashifyNET does not provide BLAKE2s implementation, only BLAKE2b.
/// </para>
/// </remarks>
internal sealed class HashifyNetBlake2bAdapter : HashAlgorithm
{
    private readonly IBlake2B _hasher;
    private readonly int _hashSizeBytes;
    private MemoryStream _buffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashifyNetBlake2bAdapter"/> class.
    /// </summary>
    /// <param name="hashSizeBits">The desired output size in bits (e.g., 256, 512).</param>
    public HashifyNetBlake2bAdapter(int hashSizeBits = 512)
    {
        if (hashSizeBits < 8 || hashSizeBits > 512 || hashSizeBits % 8 != 0)
        {
            throw new ArgumentOutOfRangeException(nameof(hashSizeBits), "Hash size must be between 8 and 512 bits, and a multiple of 8.");
        }

        using var config = new Blake2BConfig { HashSizeInBits = hashSizeBits };
        _hasher = HashFactory<IBlake2B>.Create(config);
        _hashSizeBytes = hashSizeBits / 8;
        HashSizeValue = hashSizeBits;
        _buffer = new MemoryStream();
    }

    /// <inheritdoc/>
    public override void Initialize()
    {
        _buffer.Dispose();
        _buffer = new MemoryStream();
    }

    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _buffer.Write(array, ibStart, cbSize);
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        _buffer.Position = 0;
        var result = _hasher.ComputeHash(_buffer);
        // HashifyNET returns ImmutableArray<byte>, convert to byte[]
        return [.. result.Hash];
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _hasher.Dispose();
            _buffer.Dispose();
        }
        base.Dispose(disposing);
    }
}

/// <summary>
/// Wraps a HashifyNET Whirlpool implementation as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows the HashifyNET Whirlpool implementation to be used
/// interchangeably with .NET <see cref="HashAlgorithm"/> implementations in tests.
/// </para>
/// <para>
/// Whirlpool produces a 512-bit hash and was designed by Vincent Rijmen and Paulo S. L. M. Barreto.
/// It is included in ISO/IEC 10118-3:2004.
/// </para>
/// </remarks>
internal sealed class HashifyNetWhirlpoolAdapter : HashAlgorithm
{
    private readonly IWhirlpool _hasher;
    private MemoryStream _buffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashifyNetWhirlpoolAdapter"/> class.
    /// </summary>
    public HashifyNetWhirlpoolAdapter()
    {
        using var config = new WhirlpoolConfig();
        _hasher = HashFactory<IWhirlpool>.Create(config);
        HashSizeValue = 512;
        _buffer = new MemoryStream();
    }

    /// <inheritdoc/>
    public override void Initialize()
    {
        _buffer.Dispose();
        _buffer = new MemoryStream();
    }

    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _buffer.Write(array, ibStart, cbSize);
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        _buffer.Position = 0;
        var result = _hasher.ComputeHash(_buffer);
        // HashifyNET returns ImmutableArray<byte>, convert to byte[]
        return [.. result.Hash];
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _hasher.Dispose();
            _buffer.Dispose();
        }
        base.Dispose(disposing);
    }
}


