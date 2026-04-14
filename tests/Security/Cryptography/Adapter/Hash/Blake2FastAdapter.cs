// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Hash;

using Blake2Fast;
using Blake2Fast.Implementation;
using System;
using System.Runtime.CompilerServices;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Wraps SauceControl.Blake2Fast BLAKE2b and BLAKE2s implementations as a <see cref="CH.Hash.HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// The underlying hash state struct is boxed once at construction and stored as
/// <see cref="IBlake2Incremental"/>. On <see cref="Initialize"/>, <see cref="Unsafe.Unbox{T}"/>
/// returns a managed reference directly into the existing boxed object, allowing the struct to be
/// overwritten in-place — zero allocation per benchmark iteration on .NET 6+.
/// On older frameworks the box is recreated (benchmarks target .NET 8+).
/// </para>
/// <para>
/// Use <see cref="CreateBlake2b"/> or <see cref="CreateBlake2s"/> to construct instances.
/// </para>
/// </remarks>
internal sealed class Blake2FastAdapter : CH.Hash.HashAlgorithm
{
    private readonly string _algorithmName;
    private readonly int _blockSize;
    private readonly int _outputBytes;
    private readonly bool _isBlake2b;
    private IBlake2Incremental _state;

    private Blake2FastAdapter(bool isBlake2b, int hashSizeBits)
    {
        _isBlake2b = isBlake2b;
        _outputBytes = hashSizeBits / 8;
        _algorithmName = $"BLAKE2{(isBlake2b ? 'b' : 's')}-{hashSizeBits} (Blake2Fast)";
        _blockSize = isBlake2b ? 128 : 64;
        HashSizeValue = hashSizeBits;
        _state = isBlake2b
            ? (IBlake2Incremental)Blake2b.CreateIncrementalHasher(_outputBytes)
            : (IBlake2Incremental)Blake2s.CreateIncrementalHasher(_outputBytes);
    }

    /// <summary>Creates a BLAKE2b adapter with the specified output size.</summary>
    /// <param name="hashSizeBits">Output size in bits (e.g. 256, 512).</param>
    public static Blake2FastAdapter CreateBlake2b(int hashSizeBits) => new(isBlake2b: true, hashSizeBits);

    /// <summary>Creates a BLAKE2s adapter with the specified output size.</summary>
    /// <param name="hashSizeBits">Output size in bits (e.g. 128, 256).</param>
    public static Blake2FastAdapter CreateBlake2s(int hashSizeBits) => new(isBlake2b: false, hashSizeBits);

    /// <inheritdoc/>
    public override string AlgorithmName => _algorithmName;

    /// <inheritdoc/>
    public override int BlockSize => _blockSize;

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source) => _state.Update(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten) =>
        _state.TryFinish(destination, out bytesWritten);

    /// <inheritdoc/>
    public override void Initialize()
    {
#if NET6_0_OR_GREATER
        // Overwrite the already-boxed struct in-place via a managed interior ref — no allocation.
        if (_isBlake2b)
        {
            Unsafe.Unbox<Blake2bHashState>(_state) = Blake2b.CreateIncrementalHasher(_outputBytes);
        }
        else
        {
            Unsafe.Unbox<Blake2sHashState>(_state) = Blake2s.CreateIncrementalHasher(_outputBytes);
        }
#else
        // Benchmarks target < .NET 6+; re-boxing is acceptable on legacy frameworks.
        _state = _isBlake2b
            ? (IBlake2Incremental)Blake2b.CreateIncrementalHasher(_outputBytes)
            : (IBlake2Incremental)Blake2s.CreateIncrementalHasher(_outputBytes);
#endif
    }
}
