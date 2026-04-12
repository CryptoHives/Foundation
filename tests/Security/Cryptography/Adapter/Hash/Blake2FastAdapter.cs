// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Hash;

using Blake2Fast;
using Blake2Fast.Implementation;
using System;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Wraps <see cref="Blake2b"/> from SauceControl.Blake2Fast as a <see cref="CH.Hash.HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// The incremental <see cref="Blake2bHashState"/> struct is held directly as a field,
/// avoiding interface-dispatch boxing on every <c>Update</c> call.
/// <see cref="HA.HashAlgorithm.Initialize"/> recreates the struct to reset the hasher state.
/// </remarks>
internal sealed class Blake2FastAdapter : CH.Hash.HashAlgorithm
{
    private readonly int _outputBytes;
    private readonly string _algorithmName;
    private Blake2bHashState _state;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2FastAdapter"/> class.
    /// </summary>
    /// <param name="hashSizeBits">The hash output size in bits (e.g. 256, 512).</param>
    public Blake2FastAdapter(int hashSizeBits)
    {
        _outputBytes = hashSizeBits / 8;
        _algorithmName = $"BLAKE2b-{hashSizeBits} (Blake2Fast)";
        _state = Blake2b.CreateIncrementalHasher(_outputBytes);
        HashSizeValue = hashSizeBits;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _algorithmName;

    /// <inheritdoc/>
    public override int BlockSize => 128;

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source) => _state.Update(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten) =>
        _state.TryFinish(destination, out bytesWritten);

    /// <inheritdoc/>
    public override void Initialize() =>
        _state = Blake2b.CreateIncrementalHasher(_outputBytes);
}
