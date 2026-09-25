// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Provides incremental ParallelHash computation.
/// </summary>
/// <remarks>
/// Absorbing is streaming: each block is fed straight into a reused inner XOF and, once full,
/// collapsed to a chaining value that goes directly into the final cSHAKE. Nothing but the
/// sponge states and a byte counter is retained, so the instance is O(1) in the message length.
/// </remarks>
public sealed class IncrementalParallelHash : IDisposable
{
    /// <summary>
    /// The default block size in bytes (1 MiB).
    /// </summary>
    public const int DefaultBlockSizeBytes = 0x100_000;

    private readonly IExtendableOutput _finalXof;
    private readonly IExtendableOutput _innerXof;
    private readonly int _chainingValueBytes;
    private readonly int _blockSizeBytes;
    private long _blockFill;
    private long _blockCount;
    private bool _finalized;
    private bool _isDisposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="IncrementalParallelHash"/> class.
    /// </summary>
    /// <param name="type">The SHAKE variant used for the ParallelHash construction.</param>
    /// <param name="blockSizeBytes">The block size in bytes.</param>
    /// <param name="customization">Optional customization string S (default: empty).</param>
    public IncrementalParallelHash(ShakeType type = ShakeType.Shake128, int blockSizeBytes = DefaultBlockSizeBytes, ReadOnlySpan<byte> customization = default)
    {
        if (blockSizeBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(blockSizeBytes), "Block size must be positive.");
        }

        _blockSizeBytes = blockSizeBytes;
        byte[] customBytes = customization.IsEmpty ? Array.Empty<byte>() : customization.ToArray();

        if (type == ShakeType.Shake256)
        {
            _chainingValueBytes = ParallelHash.ChainingValue256Bytes;
            _finalXof = CShake256.Create(
                outputBytes: CShake256.DefaultOutputBits / 8,
                functionName: ParallelHash.ParallelHashFunctionName,
                customization: customBytes);
            _innerXof = Shake256.Create(_chainingValueBytes);
        }
        else
        {
            _chainingValueBytes = ParallelHash.ChainingValue128Bytes;
            _finalXof = CShake128.Create(
                outputBytes: CShake128.DefaultOutputBits / 8,
                functionName: ParallelHash.ParallelHashFunctionName,
                customization: customBytes);
            _innerXof = Shake128.Create(_chainingValueBytes);
        }

        AbsorbBlockSize();
    }

    /// <summary>
    /// Absorbs data into the ParallelHash instance.
    /// </summary>
    /// <param name="data">The data to absorb.</param>
    /// <exception cref="InvalidOperationException">Thrown after the hash has been squeezed.</exception>
    public void Absorb(ReadOnlySpan<byte> data)
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(IncrementalParallelHash));
        }

        if (_finalized)
        {
            throw new InvalidOperationException("Cannot add data after finalization.");
        }

        while (!data.IsEmpty)
        {
            int take = (int)Math.Min(_blockSizeBytes - _blockFill, data.Length);
            _innerXof.Absorb(data.Slice(0, take));
            _blockFill += take;
            data = data.Slice(take);

            if (_blockFill == _blockSizeBytes)
            {
                FlushBlock();
            }
        }
    }

    /// <summary>
    /// Squeezes the final hash output.
    /// </summary>
    /// <param name="output">The span to receive the hash value.</param>
    /// <returns>The output span containing the hash value.</returns>
    /// <remarks>
    /// ParallelHash encodes the requested output length into the digest, so this may be called
    /// only once per message; use <see cref="Reset"/> to start another.
    /// </remarks>
    /// <exception cref="InvalidOperationException">Thrown when called more than once.</exception>
    public Span<byte> Squeeze(Span<byte> output)
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(IncrementalParallelHash));
        }

        if (_finalized)
        {
            throw new InvalidOperationException("The hash has already been squeezed; call Reset to start another.");
        }

        // A trailing partial block still counts: blockCount is ceil(n / B).
        if (_blockFill > 0)
        {
            FlushBlock();
        }

        Span<byte> encodeBuffer = stackalloc byte[CShake128.EncodeBufferLength];
        ParallelHash.AbsorbEncodedRight(_finalXof, _blockCount, encodeBuffer);
        ParallelHash.AbsorbEncodedRight(_finalXof, checked((long)output.Length * 8L), encodeBuffer);
        _finalXof.Squeeze(output);
        _finalized = true;
        return output;
    }

    /// <summary>
    /// Resets the instance for reuse.
    /// </summary>
    public void Reset()
    {
        if (_isDisposed)
        {
            throw new ObjectDisposedException(nameof(IncrementalParallelHash));
        }

        _finalXof.Reset();
        _innerXof.Reset();
        _blockFill = 0;
        _blockCount = 0;
        _finalized = false;
        AbsorbBlockSize();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (_isDisposed)
        {
            return;
        }

        (_finalXof as IDisposable)?.Dispose();
        (_innerXof as IDisposable)?.Dispose();
        _isDisposed = true;
    }

    /// <summary>
    /// Collapses the block currently held in the inner XOF straight into the final cSHAKE, so no
    /// chaining value is ever stored.
    /// </summary>
    private void FlushBlock()
    {
        Span<byte> chainingValue = stackalloc byte[_chainingValueBytes];
        _innerXof.Squeeze(chainingValue);
        _finalXof.Absorb(chainingValue);
        _blockCount++;

        _innerXof.Reset();
        _blockFill = 0;
    }

    private void AbsorbBlockSize()
    {
        Span<byte> encodeBuffer = stackalloc byte[CShake128.EncodeBufferLength];
        ParallelHash.AbsorbEncodedLeft(_finalXof, _blockSizeBytes, encodeBuffer);
    }

    /// <summary>
    /// The SHAKE type used for the hash computation.
    /// </summary>
    public enum ShakeType
    {
        /// <summary>
        /// Use SHAKE128 (128-bit security strength).
        /// </summary>
        Shake128,

        /// <summary>
        /// Use SHAKE256 (256-bit security strength).
        /// </summary>
        Shake256
    }
}
