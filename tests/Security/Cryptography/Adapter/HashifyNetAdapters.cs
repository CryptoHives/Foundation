// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests;

using System;
using System.IO;
using System.Security.Cryptography;
using HashifyNet;
using HashifyNet.Algorithms.Blake2;
// using HashifyNet.Algorithms.Blake3; // Commented out - has known bug at 1024-byte chunk boundary
using HashifyNet.Algorithms.Gost;
using HashifyNet.Algorithms.Keccak;
using HashifyNet.Algorithms.SM3;
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
    private readonly int _hashSizeBits;
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

        _hashSizeBits = hashSizeBits;
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
        // Create a fresh hasher for each computation to ensure clean state
        using var config = new Blake2BConfig { HashSizeInBits = _hashSizeBits };
        using var hasher = HashFactory<IBlake2B>.Create(config);
        var result = hasher.ComputeHash(_buffer);
        return [.. result.Hash];
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
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
    private MemoryStream _buffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashifyNetWhirlpoolAdapter"/> class.
    /// </summary>
    public HashifyNetWhirlpoolAdapter()
    {
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
        // Create a fresh hasher for each computation to ensure clean state
        using var config = new WhirlpoolConfig();
        using var hasher = HashFactory<IWhirlpool>.Create(config);
        var result = hasher.ComputeHash(_buffer);
        return [.. result.Hash];
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }
        base.Dispose(disposing);
    }
}

/// <summary>
/// Wraps a HashifyNET SM3 implementation as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows the HashifyNET SM3 implementation to be used
/// interchangeably with .NET <see cref="HashAlgorithm"/> implementations in tests.
/// </para>
/// <para>
/// SM3 is the Chinese national standard hash function (GB/T 32905-2016).
/// It produces a 256-bit hash value.
/// </para>
/// </remarks>
internal sealed class HashifyNetSM3Adapter : HashAlgorithm
{
    private MemoryStream _buffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashifyNetSM3Adapter"/> class.
    /// </summary>
    public HashifyNetSM3Adapter()
    {
        HashSizeValue = 256;
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
        // Create a fresh hasher for each computation to ensure clean state
        using var config = new SM3Config();
        using var hasher = HashFactory<ISM3>.Create(config);
        var result = hasher.ComputeHash(_buffer);
        return [.. result.Hash];
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }
        base.Dispose(disposing);
    }
}

/// <summary>
/// Wraps a HashifyNET Keccak implementation as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows the HashifyNET Keccak implementation to be used
/// interchangeably with .NET <see cref="HashAlgorithm"/> implementations in tests.
/// </para>
/// <para>
/// Keccak is the original submission to the SHA-3 competition. It uses different
/// padding than SHA-3 (0x01 vs 0x06) and produces different output for the same input.
/// This implementation is useful for Ethereum compatibility testing.
/// </para>
/// </remarks>
internal sealed class HashifyNetKeccakAdapter : HashAlgorithm
{
    private readonly int _hashSizeBits;
    private readonly bool _useSha3Padding;
    private MemoryStream _buffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashifyNetKeccakAdapter"/> class.
    /// </summary>
    /// <param name="hashSizeBits">The desired output size in bits (224, 256, 384, or 512).</param>
    /// <param name="useSha3Padding">If true, use SHA-3 padding; if false, use original Keccak padding.</param>
    public HashifyNetKeccakAdapter(int hashSizeBits = 256, bool useSha3Padding = false)
    {
        if (hashSizeBits != 224 && hashSizeBits != 256 && hashSizeBits != 384 && hashSizeBits != 512)
        {
            throw new ArgumentOutOfRangeException(nameof(hashSizeBits), "Hash size must be 224, 256, 384, or 512 bits.");
        }

        _hashSizeBits = hashSizeBits;
        _useSha3Padding = useSha3Padding;
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
        // Create a fresh hasher for each computation to ensure clean state
        var config = new KeccakConfig { HashSizeInBits = _hashSizeBits, UseSha3Padding = _useSha3Padding };
        using var hasher = HashFactory<IKeccak>.Create(config);
        var result = hasher.ComputeHash(_buffer);
        return [.. result.Hash];
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }
        base.Dispose(disposing);
    }
}

/// <summary>
/// Wraps a HashifyNET GOST (Streebog) implementation as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows the HashifyNET GOST/Streebog implementation to be used
/// interchangeably with .NET <see cref="HashAlgorithm"/> implementations in tests.
/// </para>
/// <para>
/// Streebog (GOST R 34.11-2012) is the Russian national standard hash function.
/// It supports 256-bit and 512-bit output sizes.
/// </para>
/// </remarks>
internal sealed class HashifyNetStreebogAdapter : HashAlgorithm
{
    private readonly int _hashSizeBits;
    private MemoryStream _buffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashifyNetStreebogAdapter"/> class.
    /// </summary>
    /// <param name="hashSizeBits">The desired output size in bits (256 or 512).</param>
    public HashifyNetStreebogAdapter(int hashSizeBits = 512)
    {
        if (hashSizeBits != 256 && hashSizeBits != 512)
        {
            throw new ArgumentOutOfRangeException(nameof(hashSizeBits), "Hash size must be 256 or 512 bits.");
        }

        _hashSizeBits = hashSizeBits;
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
        // Create a fresh hasher for each computation to ensure clean state
        var config = new GostConfig { HashSizeInBits = _hashSizeBits };
        using var hasher = HashFactory<IGost>.Create(config);
        var result = hasher.ComputeHash(_buffer);
        return [.. result.Hash];
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }
        base.Dispose(disposing);
    }
}

#if false
// HashifyNET Blake3 has a known bug at the 1024-byte chunk boundary.
// See: https://github.com/Deskasoft/HashifyNET/issues/XXX
// TODO: Enable this adapter once the bug is fixed.

/// <summary>
/// Wraps a HashifyNET BLAKE3 implementation as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows the HashifyNET BLAKE3 implementation to be used
/// interchangeably with .NET <see cref="HashAlgorithm"/> implementations in tests.
/// </para>
/// <para>
/// BLAKE3 is a modern cryptographic hash function that is very fast and supports
/// variable output length.
/// </para>
/// <para>
/// WARNING: HashifyNET's Blake3 implementation has a known bug at the 1024-byte chunk
/// boundary and should not be used as a reference until fixed.
/// </para>
/// </remarks>
internal sealed class HashifyNetBlake3Adapter : HashAlgorithm
{
    private readonly int _hashSizeBytes;
    private MemoryStream _buffer;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashifyNetBlake3Adapter"/> class.
    /// </summary>
    /// <param name="hashSizeBytes">The desired output size in bytes (default 32).</param>
    public HashifyNetBlake3Adapter(int hashSizeBytes = 32)
    {
        if (hashSizeBytes < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(hashSizeBytes), "Hash size must be positive.");
        }

        _hashSizeBytes = hashSizeBytes;
        HashSizeValue = hashSizeBytes * 8;
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
        // Create a fresh hasher for each computation to ensure clean state
        var config = new Blake3Config { HashSizeInBytes = _hashSizeBytes };
        using var hasher = HashFactory<IBlake3>.Create(config);
        var result = hasher.ComputeHash(_buffer);
        return [.. result.Hash];
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }
        base.Dispose(disposing);
    }
}
#endif


