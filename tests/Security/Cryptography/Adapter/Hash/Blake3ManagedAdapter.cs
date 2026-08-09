// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

// The "Blake3" package (fully managed, xoofx/Blake3.NET) and "Blake3.Native"
// package (Rust FFI) both define Blake3.Hasher, so referencing both at once is
// ambiguous (CS0433). The "Blake3" package is aliased to "Blake3Managed" in
// Cryptography.Tests.csproj; the extern alias below is what makes that alias
// resolvable in source. Blake3.Native keeps the default (global) alias, so it's
// still just `Blake3.Hasher` everywhere else (see Blake3NativeAdapter.cs).
//
// The extern alias only exists when the "Blake3" PackageReference is present
// (net8.0+, unsigned builds), so it must be excluded on other TFMs too — an
// extern alias with no matching reference is a compile error (CS0430).

#if BLAKE3_MANAGED

extern alias Blake3Managed;

namespace Cryptography.Tests.Adapter.Hash;

using System;
using CH = CryptoHives.Foundation.Security.Cryptography;
using ManagedHasher = Blake3Managed::Blake3.Hasher;

/// <summary>
/// Wraps the Blake3.NET managed implementation as a
/// <see cref="CryptoHives.Foundation.Security.Cryptography.Hash.HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// The "Blake3" package (v3.0+) is a pure C# implementation with runtime-selected
/// scalar/SIMD paths and no native library dependency, distinct from the Rust-backed
/// "Blake3.Native" package wrapped by <see cref="Blake3NativeAdapter"/>.
/// </remarks>
internal sealed class Blake3ManagedAdapter : CH.Hash.HashAlgorithm, IOneShotHash
{
    private readonly int _outputBytes;
    private ManagedHasher _hasher;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3ManagedAdapter"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes. Default is 32.</param>
    public Blake3ManagedAdapter(int outputBytes = 32)
    {
        if (outputBytes < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _hasher = ManagedHasher.New();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "BLAKE3";

    /// <inheritdoc/>
    public override int BlockSize => 64;

    /// <inheritdoc/>
    public override void Initialize() => _hasher.Reset();

    /// <inheritdoc/>
    /// <remarks>
    /// Uses the library's static one-shot <c>Hasher.Hash(input, output)</c>, which
    /// hashes via recursive subtree splitting instead of the slower streaming
    /// Update path (see <see cref="IOneShotHash"/>).
    /// </remarks>
    bool IOneShotHash.TryComputeHash(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        ManagedHasher.Hash(source, destination[.._outputBytes]);
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
/// Wraps the Blake3.NET managed implementation as an <see cref="CH.Hash.IExtendableOutput"/>
/// for XOF benchmarking.
/// </summary>
internal sealed class Blake3ManagedXofAdapter : CH.Hash.IExtendableOutput, IDisposable
{
    private ManagedHasher _hasher;

    public Blake3ManagedXofAdapter() => _hasher = ManagedHasher.New();

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
