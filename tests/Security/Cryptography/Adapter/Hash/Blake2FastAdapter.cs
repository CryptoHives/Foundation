// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Hash;

using Blake2Fast;
using System;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Wraps SauceControl.Blake2Fast BLAKE2b and BLAKE2s implementations as a <see cref="CH.Hash.HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// The common <see cref="IBlake2Incremental"/> interface is used for both BLAKE2b and BLAKE2s,
/// making the adapter variant-agnostic. The underlying struct is boxed once per
/// <see cref="Initialize"/> call; all subsequent <c>Update</c> and <c>TryFinish</c> calls
/// are interface dispatch on the existing boxed instance with no additional allocation.
/// </para>
/// <para>
/// Use <see cref="CreateBlake2b"/> or <see cref="CreateBlake2s"/> to construct instances.
/// </para>
/// </remarks>
internal sealed class Blake2FastAdapter : CH.Hash.HashAlgorithm
{
    private readonly Func<IBlake2Incremental> _factory;
    private readonly string _algorithmName;
    private readonly int _blockSize;
    private IBlake2Incremental _state;

    private Blake2FastAdapter(Func<IBlake2Incremental> factory, string algorithmName, int blockSize, int hashSizeBits)
    {
        _factory = factory;
        _algorithmName = algorithmName;
        _blockSize = blockSize;
        HashSizeValue = hashSizeBits;
        _state = factory();
    }

    /// <summary>Creates a BLAKE2b adapter with the specified output size.</summary>
    /// <param name="hashSizeBits">Output size in bits (e.g. 256, 512).</param>
    public static Blake2FastAdapter CreateBlake2b(int hashSizeBits) => new(
        () => Blake2b.CreateIncrementalHasher(hashSizeBits / 8),
        $"BLAKE2b-{hashSizeBits} (Blake2Fast)", blockSize: 128, hashSizeBits);

    /// <summary>Creates a BLAKE2s adapter with the specified output size.</summary>
    /// <param name="hashSizeBits">Output size in bits (e.g. 128, 256).</param>
    public static Blake2FastAdapter CreateBlake2s(int hashSizeBits) => new(
        () => Blake2s.CreateIncrementalHasher(hashSizeBits / 8),
        $"BLAKE2s-{hashSizeBits} (Blake2Fast)", blockSize: 64, hashSizeBits);

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
    public override void Initialize() => _state = _factory();
}
