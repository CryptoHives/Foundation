// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Hash;

using System;
using System.Buffers;
using CH = CryptoHives.Foundation.Security.Cryptography;
using OS = System.Security.Cryptography;

/// <summary>
/// A single-call hash function, shaped like the in-box static one-shots
/// (<c>SHA256.HashData</c>, <c>SHA3_256.HashData</c>, ...).
/// </summary>
/// <param name="source">The input to compute the hash code for.</param>
/// <param name="destination">The buffer to receive the hash value.</param>
/// <returns>The number of bytes written to <paramref name="destination"/>.</returns>
internal delegate int OneShotHash(ReadOnlySpan<byte> source, Span<byte> destination);

/// <summary>
/// Wraps any <see cref="System.Security.Cryptography.HashAlgorithm"/> — an in-box OS
/// implementation, or a third-party one that derives from the in-box base — as a
/// <see cref="CryptoHives.Foundation.Security.Cryptography.Hash.HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// <para>
/// Only <c>CH.Hash.HashAlgorithm</c> declares <c>TryComputeHash</c> virtual, so it is the one
/// type through which every implementation's best single-call path is reachable by plain
/// dispatch. Wrapping the in-box rows in this adapter makes that type universal: a benchmark or
/// test can hold a <c>CH.Hash.HashAlgorithm</c> for every registry row and stop branching on what
/// the factory handed back.
/// </para>
/// <para>
/// The one-shot path forwards straight to the wrapped instance (or to the <c>oneShot</c> delegate
/// when the caller supplies a faster static entry point), so the adapter adds a virtual call and
/// no copy. Only the streaming path costs anything: the in-box type exposes no public span-based
/// append, so <see cref="HashCore(ReadOnlySpan{byte})"/> copies through a pooled array into
/// <c>TransformBlock</c>.
/// </para>
/// </remarks>
internal sealed class HashAlgorithmAdapter : CH.Hash.HashAlgorithm
{
    private static readonly byte[] _emptyBlock = [];

    private readonly OS.HashAlgorithm _inner;
    private readonly OneShotHash? _oneShot;
    private readonly string _algorithmName;
    private readonly int _blockSize;
    private readonly int _hashSizeBytes;
    private bool _appended;

    /// <summary>
    /// Initializes a new instance of the <see cref="HashAlgorithmAdapter"/> class.
    /// </summary>
    /// <param name="inner">The hash algorithm to wrap. The adapter takes ownership and disposes it.</param>
    /// <param name="algorithmName">
    /// Display name to report from <see cref="AlgorithmName"/>. Defaults to the name of the
    /// algorithm type the instance derives from (<c>SHA256</c> for the private implementation
    /// class that <c>SHA256.Create()</c> actually returns).
    /// </param>
    /// <param name="blockSize">
    /// The algorithm's block size in bytes, which the in-box type does not expose. Defaults to
    /// the well-known size for <paramref name="algorithmName"/>.
    /// </param>
    /// <param name="oneShot">
    /// Optional faster single-call entry point — the wrapped algorithm's static <c>HashData</c>,
    /// say — used by <see cref="TryComputeHash"/> in place of the instance path.
    /// </param>
    public HashAlgorithmAdapter(
        OS.HashAlgorithm inner,
        string? algorithmName = null,
        int blockSize = 0,
        OneShotHash? oneShot = null)
    {
        _inner = inner ?? throw new ArgumentNullException(nameof(inner));
        _oneShot = oneShot;
        _hashSizeBytes = inner.HashSize / 8;
        HashSizeValue = inner.HashSize;
        _algorithmName = string.IsNullOrEmpty(algorithmName) ? InferName(inner) : algorithmName!;
        _blockSize = blockSize > 0 ? blockSize : InferBlockSize(_algorithmName, _hashSizeBytes);
    }

    /// <summary>
    /// Gets the wrapped algorithm, for a caller that needs the in-box instance back.
    /// </summary>
    public OS.HashAlgorithm Inner => _inner;

    /// <inheritdoc/>
    public override string AlgorithmName => _algorithmName;

    /// <inheritdoc/>
    public override int BlockSize => _blockSize;

    /// <inheritdoc/>
    /// <remarks>
    /// Forwards to the wrapped algorithm's own one-shot, which honours anything already appended
    /// to this instance and resets it afterwards — the contract the base class documents. On a
    /// target where the in-box type has no span one-shot (.NET Framework) this falls back to the
    /// base streaming implementation.
    /// </remarks>
    public override bool TryComputeHash(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _hashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // A static one-shot cannot see state this instance is already carrying, so it is only
        // valid from a freshly initialized state.
        if (_oneShot is not null && !_appended)
        {
            bytesWritten = _oneShot(source, destination);
            return true;
        }

#if NETSTANDARD2_1_OR_GREATER || NET5_0_OR_GREATER
        if (_inner.TryComputeHash(source, destination, out bytesWritten))
        {
            _appended = false;
            return true;
        }

        return false;
#else
        return base.TryComputeHash(source, destination, out bytesWritten);
#endif
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        _appended = true;

        byte[] buffer = ArrayPool<byte>.Shared.Rent(Math.Max(source.Length, 1));
        try
        {
            source.CopyTo(buffer);
            _inner.TransformBlock(buffer, 0, source.Length, null, 0);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _hashSizeBytes)
        {
            bytesWritten = 0;
            return false;
        }

        _inner.TransformFinalBlock(_emptyBlock, 0, 0);
        byte[] hash = _inner.Hash!;
        hash.AsSpan(0, _hashSizeBytes).CopyTo(destination);
        bytesWritten = _hashSizeBytes;
        _appended = false;
        return true;
    }

    /// <inheritdoc/>
    public override void Initialize()
    {
        _inner.Initialize();
        _appended = false;
    }

    /// <inheritdoc/>
    protected override bool IsInitialized => !_appended;

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _inner.Dispose();
        }

        base.Dispose(disposing);
    }

    /// <summary>
    /// Names the algorithm from its type: <c>SHA256.Create()</c> returns a private implementation
    /// class, so the abstract algorithm type it derives from is the name worth reporting.
    /// </summary>
    private static string InferName(OS.HashAlgorithm inner)
    {
        Type concrete = inner.GetType();

        for (Type? type = concrete; type is not null && type != typeof(OS.HashAlgorithm); type = type.BaseType)
        {
            if (!type.IsAbstract)
            {
                continue;
            }

            // Keyed algorithms bottom out in shared bases that name nothing; keep the concrete name.
            if (type == typeof(System.Security.Cryptography.KeyedHashAlgorithm) ||
                type == typeof(System.Security.Cryptography.HMAC))
            {
                break;
            }

            return type.Name;
        }

        return concrete.Name;
    }

    /// <summary>
    /// Maps a name to the algorithm's block size, which the in-box type does not expose
    /// (<c>InputBlockSize</c> is 1 for every hash algorithm in the BCL).
    /// </summary>
    private static int InferBlockSize(string algorithmName, int hashSizeBytes)
    {
        Span<char> normalized = stackalloc char[algorithmName.Length];
        int length = 0;
        foreach (char c in algorithmName)
        {
            if (c is '-' or '_' or '/' or ' ')
            {
                continue;
            }

            normalized[length++] = char.ToUpperInvariant(c);
        }

        ReadOnlySpan<char> key = normalized.Slice(0, length);
        if (key.StartsWith("HMAC".AsSpan(), StringComparison.Ordinal))
        {
            key = key.Slice(4);
        }

        return key.ToString() switch {
            "MD5" or "SHA1" or "SHA224" or "SHA256" or "SM3" or "RIPEMD160" => 64,
            "SHA384" or "SHA512" or "SHA512224" or "SHA512256" => 128,
            "SHA3224" => 144,
            "SHA3256" => 136,
            "SHA3384" => 104,
            "SHA3512" => 72,
            "SHAKE128" => 168,
            "SHAKE256" => 136,
            "BLAKE3" or "BLAKE2S" or "BLAKE2S128" or "BLAKE2S256" => 64,
            "BLAKE2B" or "BLAKE2B256" or "BLAKE2B512" => 128,
            // Anything else: the SHA-2 rule of thumb, a 64-byte block below 384 bits of output.
            _ => hashSizeBytes <= 32 ? 64 : 128
        };
    }
}
