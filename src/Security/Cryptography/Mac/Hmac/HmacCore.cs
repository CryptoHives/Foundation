// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// Implements HMAC (Hash-based Message Authentication Code) as defined in RFC 2104.
/// </summary>
/// <remarks>
/// <para>
/// HMAC uses an underlying hash function to produce a keyed authentication tag.
/// The construction is: HMAC(K, m) = H((K' ⊕ opad) ‖ H((K' ⊕ ipad) ‖ m)),
/// where K' is the key padded or hashed to the hash block size.
/// </para>
/// <para>
/// This is a fully managed implementation that works with any <see cref="HashAlgorithm"/>
/// from the CryptoHives library, providing deterministic behavior across all platforms.
/// </para>
/// </remarks>
public class HmacCore : IMac
{
    private const byte Ipad = 0x36;
    private const byte Opad = 0x5c;

    private readonly HashAlgorithm _innerHash;
    private readonly HashAlgorithm _outerHash;
    private readonly byte[] _ipadKey;
    private readonly byte[] _opadKey;
    private readonly int _macSize;
    private bool _finalized;
    private bool _disposed;

    /// <inheritdoc/>
    public string AlgorithmName { get; }

    /// <inheritdoc/>
    public int MacSize => _macSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="HmacCore"/> class.
    /// </summary>
    /// <param name="algorithmName">The name of the HMAC algorithm (e.g. "HMAC-SHA256").</param>
    /// <param name="innerHash">The hash algorithm instance for the inner hash.</param>
    /// <param name="outerHash">The hash algorithm instance for the outer hash.</param>
    /// <param name="key">The secret key.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="innerHash"/>, <paramref name="outerHash"/>, or <paramref name="key"/> is null.
    /// </exception>
    public HmacCore(string algorithmName, HashAlgorithm innerHash, HashAlgorithm outerHash, ReadOnlySpan<byte> key)
    {
        if (innerHash is null) throw new ArgumentNullException(nameof(innerHash));
        if (outerHash is null) throw new ArgumentNullException(nameof(outerHash));

        AlgorithmName = algorithmName ?? throw new ArgumentNullException(nameof(algorithmName));
        _innerHash = innerHash;
        _outerHash = outerHash;
        _macSize = innerHash.HashSize / 8;

        int blockSize = innerHash.BlockSize;
        _ipadKey = new byte[blockSize];
        _opadKey = new byte[blockSize];

        DeriveKeys(key, blockSize);
        InitializeInner();
    }

    /// <inheritdoc/>
    public void Update(ReadOnlySpan<byte> input)
    {
        if (_finalized) throw new InvalidOperationException("Cannot update after finalization. Call Reset() first.");

        // Feed through the inner hash via TransformBlock
        byte[] temp = input.ToArray();
        _innerHash.TransformBlock(temp, 0, temp.Length, null, 0);
    }

    /// <inheritdoc/>
    public void Finalize(Span<byte> destination)
    {
        if (destination.Length < _macSize) throw new ArgumentException("Destination buffer is too small.", nameof(destination));
        if (_finalized) throw new InvalidOperationException("Already finalized. Call Reset() first.");

        // Complete inner hash: H((K' ⊕ ipad) ‖ m)
        _innerHash.TransformFinalBlock([], 0, 0);
        byte[] innerResult = _innerHash.Hash!;

        // Complete outer hash: H((K' ⊕ opad) ‖ innerResult)
        // The opad key block was already fed in InitializeInner()
        _outerHash.TransformFinalBlock(innerResult, 0, innerResult.Length);
        byte[] outerResult = _outerHash.Hash!;

        outerResult.AsSpan(0, _macSize).CopyTo(destination);
        _finalized = true;
    }

    /// <inheritdoc/>
    public void Reset()
    {
        _finalized = false;
        _innerHash.Initialize();
        _outerHash.Initialize();
        InitializeInner();
    }

    /// <summary>
    /// Computes the HMAC tag for the given data in a single operation.
    /// </summary>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The MAC tag.</returns>
    public byte[] ComputeHash(ReadOnlySpan<byte> data)
    {
        Reset();
        Update(data);
        byte[] result = new byte[_macSize];
        Finalize(result);
        return result;
    }

    /// <summary>
    /// Computes the HMAC tag for the given data in a single operation.
    /// </summary>
    /// <param name="data">The data to authenticate.</param>
    /// <returns>The MAC tag.</returns>
    public byte[] ComputeHash(byte[] data)
    {
        return ComputeHash(data.AsSpan());
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the resources used by this instance.
    /// </summary>
    /// <param name="disposing">True if called from Dispose.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            Array.Clear(_ipadKey, 0, _ipadKey.Length);
            Array.Clear(_opadKey, 0, _opadKey.Length);
            _innerHash.Dispose();
            _outerHash.Dispose();
            _disposed = true;
        }
    }

    private void DeriveKeys(ReadOnlySpan<byte> key, int blockSize)
    {
        Span<byte> keyBlock = stackalloc byte[blockSize];

        if (key.Length > blockSize)
        {
            // Key longer than block size: hash it first
            byte[] hashedKey = _innerHash.ComputeHash(key.ToArray());
            _innerHash.Initialize();
            hashedKey.AsSpan().CopyTo(keyBlock);
        }
        else
        {
            key.CopyTo(keyBlock);
        }

        for (int i = 0; i < blockSize; i++)
        {
            _ipadKey[i] = (byte)(keyBlock[i] ^ Ipad);
            _opadKey[i] = (byte)(keyBlock[i] ^ Opad);
        }

        keyBlock.Clear();
    }

    private void InitializeInner()
    {
        // Start inner hash with ipad key block
        _innerHash.Initialize();
        _innerHash.TransformBlock(_ipadKey, 0, _ipadKey.Length, null, 0);

        // Pre-feed outer hash with opad key block
        _outerHash.Initialize();
        _outerHash.TransformBlock(_opadKey, 0, _opadKey.Length, null, 0);
    }
}
