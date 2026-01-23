// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using CHH = CryptoHives.Foundation.Security.Cryptography.Hash.HashAlgorithm;

/// <summary>
/// Computes the HMAC (Hash-based Message Authentication Code) for the input data.
/// </summary>
/// <remarks>
/// <para>
/// HMAC is a MAC algorithm defined in RFC 2104 that uses a cryptographic hash function
/// combined with a secret key to provide both data integrity and authenticity verification.
/// </para>
/// <para>
/// This implementation supports any hash algorithm from the CryptoHives library,
/// including SHA-256, SHA-384, SHA-512, SHA-1, MD5, and others.
/// </para>
/// <para>
/// The HMAC computation follows the formula:
/// HMAC(K, m) = H((K' ? opad) || H((K' ? ipad) || m))
/// where K' is the key padded or hashed to the block size.
/// </para>
/// </remarks>
public sealed class Hmac : HashAlgorithm
{
    private const byte InnerPadByte = 0x36;
    private const byte OuterPadByte = 0x5c;

    private readonly CHH _innerHash;
    private readonly CHH _outerHash;
    private readonly byte[] _key;
    private readonly byte[] _innerPadKey;
    private readonly byte[] _outerPadKey;
    private readonly int _blockSize;
    private readonly string _algorithmName;
    private bool _initialized;

    /// <summary>
    /// Initializes a new instance of the <see cref="Hmac"/> class.
    /// </summary>
    /// <param name="hashAlgorithmName">The name of the hash algorithm to use (e.g., "SHA-256", "SHA-512").</param>
    /// <param name="key">The secret key for HMAC computation.</param>
    /// <exception cref="ArgumentNullException">Thrown when key or hashAlgorithmName is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown when the hash algorithm name is unknown.</exception>
    public Hmac(string hashAlgorithmName, byte[] key)
    {
        if (string.IsNullOrEmpty(hashAlgorithmName)) throw new ArgumentNullException(nameof(hashAlgorithmName));
        if (key is null || key.Length == 0) throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");

        _innerHash = (CHH)CHH.Create(hashAlgorithmName);
        _outerHash = (CHH)CHH.Create(hashAlgorithmName);

        _blockSize = _innerHash.BlockSize;
        _algorithmName = $"HMAC-{_innerHash.AlgorithmName}";

        HashSizeValue = _innerHash.HashSize;

        // Process key according to RFC 2104
        _key = ProcessKey(key);
        _innerPadKey = new byte[_blockSize];
        _outerPadKey = new byte[_blockSize];

        Initialize();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Hmac"/> class using provided hash algorithm instances.
    /// </summary>
    /// <param name="innerHash">The hash algorithm instance for inner computation.</param>
    /// <param name="outerHash">The hash algorithm instance for outer computation.</param>
    /// <param name="key">The secret key for HMAC computation.</param>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    /// <exception cref="ArgumentException">Thrown when hash algorithms have different block sizes.</exception>
    internal Hmac(CHH innerHash, CHH outerHash, byte[] key)
    {
        if (innerHash is null) throw new ArgumentNullException(nameof(innerHash));
        if (outerHash is null) throw new ArgumentNullException(nameof(outerHash));
        if (key is null || key.Length == 0) throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");
        if (innerHash.BlockSize != outerHash.BlockSize) throw new ArgumentException("Hash algorithms must have the same block size.");

        _innerHash = innerHash;
        _outerHash = outerHash;

        _blockSize = _innerHash.BlockSize;
        _algorithmName = $"HMAC-{_innerHash.AlgorithmName}";

        HashSizeValue = _innerHash.HashSize;

        // Process key according to RFC 2104
        _key = ProcessKey(key);
        _innerPadKey = new byte[_blockSize];
        _outerPadKey = new byte[_blockSize];

        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _algorithmName;

    /// <inheritdoc/>
    public override int BlockSize => _blockSize;

    /// <summary>
    /// Gets a copy of the secret key used for HMAC computation.
    /// </summary>
    /// <remarks>
    /// Returns a clone of the processed key (padded or hashed to block size).
    /// This property is provided for API compatibility with <see cref="System.Security.Cryptography.HMAC"/>. 
    /// </remarks>
    public byte[] Key => (byte[])_key.Clone();

    /// <summary>
    /// Creates a new HMAC-SHA256 instance.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA256 instance.</returns>
    public static Hmac CreateSha256(byte[] key) => new("SHA-256", key);

    /// <summary>
    /// Creates a new HMAC-SHA384 instance.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA384 instance.</returns>
    public static Hmac CreateSha384(byte[] key) => new("SHA-384", key);

    /// <summary>
    /// Creates a new HMAC-SHA512 instance.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA512 instance.</returns>
    public static Hmac CreateSha512(byte[] key) => new("SHA-512", key);

    /// <summary>
    /// Creates a new HMAC-SHA3-256 instance.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA3-256 instance.</returns>
    public static Hmac CreateSha3_256(byte[] key) => new("SHA3-256", key);

    /// <summary>
    /// Creates a new HMAC-SHA3-512 instance.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA3-512 instance.</returns>
    public static Hmac CreateSha3_512(byte[] key) => new("SHA3-512", key);

    /// <summary>
    /// Creates a new HMAC-BLAKE2b instance.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-BLAKE2b instance.</returns>
    public static Hmac CreateBlake2b(byte[] key) => new("BLAKE2B", key);

    /// <summary>
    /// Creates a new HMAC-BLAKE3 instance.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-BLAKE3 instance.</returns>
    public static Hmac CreateBlake3(byte[] key) => new("BLAKE3", key);

#pragma warning disable CS0618 // SHA-1 and MD5 are intentionally supported for legacy compatibility
    /// <summary>
    /// Creates a new HMAC-SHA1 instance.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-SHA1 instance.</returns>
    /// <remarks>
    /// SHA-1 is considered weak for collision resistance but is still acceptable for HMAC.
    /// Consider using HMAC-SHA256 or stronger for new applications.
    /// </remarks>
    [Obsolete("HMAC-SHA1 is deprecated for new applications. Use HMAC-SHA256 or stronger.")]
    public static Hmac CreateSha1(byte[] key) => new("SHA-1", key);

    /// <summary>
    /// Creates a new HMAC-MD5 instance.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC-MD5 instance.</returns>
    /// <remarks>
    /// MD5 is considered cryptographically broken. Use for legacy compatibility only.
    /// Consider using HMAC-SHA256 or stronger for new applications.
    /// </remarks>
    [Obsolete("HMAC-MD5 is deprecated. Use HMAC-SHA256 or stronger for new applications.")]
    public static Hmac CreateMd5(byte[] key) => new("MD5", key);
#pragma warning restore CS0618

    /// <summary>
    /// Creates a new HMAC instance with the specified hash algorithm.
    /// </summary>
    /// <param name="hashAlgorithmName">The name of the hash algorithm.</param>
    /// <param name="key">The secret key.</param>
    /// <returns>A new HMAC instance.</returns>
    public static Hmac Create(string hashAlgorithmName, byte[] key) => new(hashAlgorithmName, key);

    /// <inheritdoc/>
    public override void Initialize()
    {
        _innerHash.Initialize();
        _outerHash.Initialize();

        // Compute inner and outer padded keys
        for (int i = 0; i < _blockSize; i++)
        {
            _innerPadKey[i] = (byte)(_key[i] ^ InnerPadByte);
            _outerPadKey[i] = (byte)(_key[i] ^ OuterPadByte);
        }

        // Start inner hash with (K' ? ipad)
        _innerHash.TransformBlock(_innerPadKey, 0, _blockSize, null, 0);
        _initialized = true;
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (!_initialized)
        {
            Initialize();
        }

        // Feed data to inner hash
        byte[] temp = source.ToArray();
        _innerHash.TransformBlock(temp, 0, temp.Length, null, 0);
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        int hashBytes = HashSizeValue / 8;

        if (destination.Length < hashBytes)
        {
            bytesWritten = 0;
            return false;
        }

        // Finalize inner hash: H((K' ? ipad) || m)
        _innerHash.TransformFinalBlock([], 0, 0);
        byte[] innerHashResult = _innerHash.Hash!;

        // Compute outer hash: H((K' ? opad) || innerHash)
        _outerHash.Initialize();
        _outerHash.TransformBlock(_outerPadKey, 0, _blockSize, null, 0);
        _outerHash.TransformFinalBlock(innerHashResult, 0, innerHashResult.Length);
        byte[] result = _outerHash.Hash!;

        result.AsSpan(0, hashBytes).CopyTo(destination);
        bytesWritten = hashBytes;
        _initialized = false;

        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_key);
            ClearBuffer(_innerPadKey);
            ClearBuffer(_outerPadKey);
            _innerHash.Dispose();
            _outerHash.Dispose();
        }
        base.Dispose(disposing);
    }

    /// <summary>
    /// Processes the key according to RFC 2104.
    /// If key is longer than block size, it is hashed.
    /// If key is shorter than block size, it is padded with zeros.
    /// </summary>
    /// <param name="key">The input key.</param>
    /// <returns>The processed key of block size length.</returns>
    private byte[] ProcessKey(byte[] key)
    {
        byte[] processedKey = new byte[_blockSize];

        if (key.Length > _blockSize)
        {
            // Hash the key if it's too long
            byte[] hashedKey = _innerHash.ComputeHash(key);
            _innerHash.Initialize();
            Array.Copy(hashedKey, processedKey, hashedKey.Length);
        }
        else
        {
            // Copy key and pad with zeros (array is already zero-initialized)
            Array.Copy(key, processedKey, key.Length);
        }

        return processedKey;
    }
}
