// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

// The "Blake3.Managed" package (Dissimilis/Blake3.Managed) is a third, independent
// BLAKE3 implementation: pure C# with AVX2/SSSE3/NEON kernels and multi-threaded
// one-shot hashing for large inputs. Its types live in the "Blake3.Managed"
// namespace, so unlike the xoofx "Blake3" package no extern alias is needed.

#if BLAKE3_DISSIMILIS

namespace Cryptography.Tests.Adapter.Hash;

using System;
using CH = CryptoHives.Foundation.Security.Cryptography;
using DissimilisHasher = Blake3.Managed.Hasher;

/// <summary>
/// Wraps the Blake3.Managed (Dissimilis) implementation as a
/// <see cref="CryptoHives.Foundation.Security.Cryptography.Hash.HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// One-shot hashing goes through the library's static
/// <c>Hasher.Hash(input, output)</c> (see <see cref="IOneShotHash"/>), which uses
/// stack allocation for small inputs and multi-threaded subtree hashing for large
/// ones; streaming uses the incremental <c>Update</c>/<c>Finalize</c> hasher.
/// </remarks>
internal sealed class Blake3DissimilisAdapter : CH.Hash.HashAlgorithm, IOneShotHash
{
    private readonly int _outputBytes;
    private DissimilisHasher _hasher;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3DissimilisAdapter"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes. Default is 32.</param>
    public Blake3DissimilisAdapter(int outputBytes = 32)
    {
        if (outputBytes < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _hasher = DissimilisHasher.New();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "BLAKE3";

    /// <inheritdoc/>
    public override int BlockSize => 64;

    /// <inheritdoc/>
    public override void Initialize() => _hasher.Reset();

    /// <inheritdoc/>
    bool IOneShotHash.TryComputeHash(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        DissimilisHasher.Hash(source, destination[.._outputBytes]);
        bytesWritten = _outputBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source) => _hasher.Update(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        _hasher.Finalize(destination[.._outputBytes]);
        bytesWritten = _outputBytes;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _hasher.Dispose();
        }
        base.Dispose(disposing);
    }
}

/// <summary>
/// Wraps the Blake3.Managed (Dissimilis) implementation as an
/// <see cref="CH.Hash.IExtendableOutput"/> for XOF benchmarking.
/// </summary>
internal sealed class Blake3DissimilisXofAdapter : CH.Hash.IExtendableOutput, IDisposable
{
    private DissimilisHasher _hasher;

    public Blake3DissimilisXofAdapter() => _hasher = DissimilisHasher.New();

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input) => _hasher.Update(input);

    /// <inheritdoc/>
    public void Squeeze(Span<byte> output) => _hasher.Finalize(output);

    /// <inheritdoc/>
    public void Reset() => _hasher.Reset();

    /// <inheritdoc/>
    public void Dispose() => _hasher.Dispose();
}

#endif
