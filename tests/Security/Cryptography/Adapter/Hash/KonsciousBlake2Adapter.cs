// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Hash;

using Konscious.Security.Cryptography;
using System;
#if NET6_0_OR_GREATER
using HA = CryptoHives.Foundation.Security.Cryptography.Hash;
#else
using HA = System.Security.Cryptography;
#endif

/// <summary>
/// Wraps Konscious.Security.Cryptography <see cref="HMACBlake2B"/> as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// Konscious's <see cref="HMACBlake2B"/> extends <see cref="System.Security.Cryptography.HMAC"/>
/// which throws <see cref="PlatformNotSupportedException"/> on the span-based
/// <c>HashCore(ReadOnlySpan&lt;byte&gt;)</c> path in .NET 5+. This adapter routes through the
/// array-based API to avoid that issue while enabling span-based benchmarks via the
/// CryptoHives <see cref="HA.HashAlgorithm"/> base class.
/// </remarks>
internal sealed class KonsciousBlake2Adapter : HA.HashAlgorithm
{
    private HMACBlake2B _inner;
    private readonly int _hashSizeBits;

    /// <summary>
    /// Initializes a new instance of the <see cref="KonsciousBlake2Adapter"/> class.
    /// </summary>
    /// <param name="hashSizeBits">The hash output size in bits (e.g. 256, 512).</param>
    public KonsciousBlake2Adapter(int hashSizeBits)
    {
        _hashSizeBits = hashSizeBits;
        _inner = new HMACBlake2B(hashSizeBits);
        HashSizeValue = hashSizeBits;
    }

#if NET6_0_OR_GREATER
    /// <inheritdoc/>
    public override string AlgorithmName => $"BLAKE2b-{_hashSizeBits}";

    /// <inheritdoc/>
    public override int BlockSize => 128;

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        // Konscious HMAC base throws on span path; route through array API.
        byte[] array = source.ToArray();
        _inner.TransformBlock(array, 0, array.Length, null, 0);
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        _inner.TransformFinalBlock([], 0, 0);
        byte[] hash = _inner.Hash!;
        hash.CopyTo(destination);
        bytesWritten = hash.Length;
        return true;
    }
#else
    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _inner.TransformBlock(array, ibStart, cbSize, null, 0);
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        _inner.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
        return _inner.Hash!;
    }
#endif

    /// <inheritdoc/>
    public override void Initialize()
    {
        _inner.Dispose();
        _inner = new HMACBlake2B(_hashSizeBits);
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _inner.Dispose();
        }
        base.Dispose(disposing);
    }
}
