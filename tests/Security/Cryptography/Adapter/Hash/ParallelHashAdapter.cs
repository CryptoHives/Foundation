// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Hash;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
#if NET6_0_OR_GREATER
using HA = CryptoHives.Foundation.Security.Cryptography.Hash;
#else
using HA = System.Security.Cryptography;
#endif

/// <summary>
/// Wraps <see cref="IncrementalParallelHash"/> as a <see cref="HashAlgorithm"/> for benchmarking
/// and comparison purposes.
/// </summary>
internal sealed class ParallelHashAdapter : HA.HashAlgorithm
{
    private readonly IncrementalParallelHash _hash;
    private readonly IncrementalParallelHash.ShakeType _type;
    private readonly int _blockSizeBytes;
    private readonly byte[] _customization;
    private readonly int _outputBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="ParallelHashAdapter"/> class.
    /// </summary>
    /// <param name="type">The SHAKE variant used for the ParallelHash construction.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="blockSizeBytes">The block size in bytes.</param>
    /// <param name="customization">Optional customization string S.</param>
    public ParallelHashAdapter(
        IncrementalParallelHash.ShakeType type,
        int outputBytes,
        int blockSizeBytes = IncrementalParallelHash.DefaultBlockSizeBytes,
        ReadOnlySpan<byte> customization = default)
    {
        _type = type;
        _outputBytes = outputBytes;
        _blockSizeBytes = blockSizeBytes;
        _customization = customization.IsEmpty ? Array.Empty<byte>() : customization.ToArray();
        _hash = new IncrementalParallelHash(type, blockSizeBytes, _customization);
        HashSizeValue = outputBytes * 8;
    }

#if NET6_0_OR_GREATER
    /// <inheritdoc/>
    public override string AlgorithmName => _type == IncrementalParallelHash.ShakeType.Shake256 ? "ParallelHash256" : "ParallelHash128";

    /// <inheritdoc/>
    public override int BlockSize => _blockSizeBytes;

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source) => _hash.Absorb(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        _hash.Squeeze(destination[.._outputBytes]);
        bytesWritten = _outputBytes;
        return true;
    }
#else
    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _hash.Absorb(array.AsSpan(ibStart, cbSize));
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        byte[] hash = new byte[_outputBytes];
        _hash.Squeeze(hash);
        return hash;
    }
#endif

    /// <inheritdoc/>
    public override void Initialize() => _hash.Reset();

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _hash.Dispose();
        }
        base.Dispose(disposing);
    }
}
