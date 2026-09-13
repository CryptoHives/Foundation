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
/// <para>
/// <b>This row is multi-threaded above roughly 72 KiB</b> and every other row in the
/// BLAKE3 comparison, ours included, is single-threaded — so its large-input results are
/// wall-clock latency across differing core counts, not a kernel comparison. Read
/// <see cref="Blake3DissimilisSerialAdapter"/>'s row for the like-for-like one.
/// </para>
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

        // Written per call, not once at construction: MaxDegreeOfParallelism is a
        // process-wide static that the library reads on every call, and the paired
        // Blake3DissimilisSerialAdapter writes it too. Setting it here makes each row
        // measure what it says it measures regardless of what else exists in the process.
        DissimilisHasher.MaxDegreeOfParallelism = -1;
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
/// Wraps the Blake3.Managed (Dissimilis) implementation with its thread fan-out capped
/// at one thread, so its kernel can be compared against ours without a core-count
/// difference standing in for an implementation difference.
/// </summary>
/// <remarks>
/// <para>
/// The unconstrained <see cref="Blake3DissimilisAdapter"/> row is not a like-for-like
/// comparison above roughly 72 KiB: <c>Hasher.Hash</c> splits the input into subtrees and
/// hashes them on the thread pool, while every CryptoHives row — and every other library
/// in the BLAKE3 comparison — is single-threaded. This row keeps that library's own
/// one-shot API and its wide-frontier serial tree, and only removes the extra cores.
/// </para>
/// <para>
/// It must stay on <c>Hasher.Hash(input, output)</c> rather than
/// <c>New()</c>/<c>Update</c>/<c>Finalize</c>: the incremental path does not use the
/// wide-frontier serial tree, so measuring it would understate the library instead of
/// levelling the comparison.
/// </para>
/// <para>
/// <c>MaxDegreeOfParallelism</c> is a process-wide static that the library reads on every
/// call, so the cap is written per call rather than once at construction. BenchmarkDotNet
/// runs each case in its own process, but the NUnit fixture path does not, and both
/// adapters can be alive at once there; writing per call means neither row can be turned
/// into the other by the order the adapters happen to be created in.
/// </para>
/// </remarks>
internal sealed class Blake3DissimilisSerialAdapter : CH.Hash.HashAlgorithm, IOneShotHash
{
    private readonly int _outputBytes;
    private DissimilisHasher _hasher;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3DissimilisSerialAdapter"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes. Default is 32.</param>
    public Blake3DissimilisSerialAdapter(int outputBytes = 32)
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

        DissimilisHasher.MaxDegreeOfParallelism = 1;
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
/// <remarks>
/// No serial counterpart exists for this one: the library's XOF path is single-threaded
/// at every output length, so the XOF comparison is already like-for-like.
/// </remarks>
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
