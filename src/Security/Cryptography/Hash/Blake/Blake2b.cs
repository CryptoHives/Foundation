// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable IDE1006 // Naming rule violation - IV and Sigma are standard cryptographic constant names per RFC 7693
#pragma warning disable CS0414  // _simdSupport is read inside #if NET8_0_OR_GREATER guard

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;

/// <summary>
/// Computes the BLAKE2b hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of BLAKE2b that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// BLAKE2b is optimized for 64-bit platforms and produces digests from 1 to 64 bytes.
/// The default output size is 64 bytes (512 bits).
/// </para>
/// <para>
/// BLAKE2b supports an optional key for keyed hashing (MAC mode) with keys up to 64 bytes.
/// </para>
/// </remarks>
public sealed class Blake2b : HashAlgorithm
{
    /// <summary>
    /// The maximum hash size in bits.
    /// </summary>
    public const int MaxHashSizeBits = Blake2bState.MaxHashSizeBits;

    /// <summary>
    /// The maximum hash size in bytes.
    /// </summary>
    public const int MaxHashSizeBytes = Blake2bState.MaxHashSizeBytes;

    /// <summary>
    /// The maximum key size in bytes.
    /// </summary>
    public const int MaxKeySizeBytes = Blake2bState.MaxKeySizeBytes;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = Blake2bState.BlockSizeBytes;

    // Blake2b core state
    private Blake2bState _core;
    private readonly byte[]? _key;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with default output size (64 bytes).
    /// </summary>
    public Blake2b() : this(SimdSupport.All, MaxHashSizeBytes, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    public Blake2b(int outputBytes) : this(SimdSupport.All, outputBytes, null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size and key.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-<see cref="MaxKeySizeBytes"/> bytes.</param>
    public Blake2b(int outputBytes, ReadOnlySpan<byte> key) : this(SimdSupport.All, outputBytes, key)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake2b"/> class with specified output size, key, and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The optional key for keyed hashing (MAC mode). Must be 0-<see cref="MaxKeySizeBytes"/> bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Blake2b(SimdSupport simdSupport, int outputBytes, ReadOnlySpan<byte> key)
    {
        if (outputBytes < 1 || outputBytes > MaxHashSizeBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes),
                $"Output size must be between 1 and {MaxHashSizeBytes} bytes.");
        }

        if (!key.IsEmpty && key.Length > MaxKeySizeBytes)
        {
            throw new ArgumentOutOfRangeException(nameof(key),
                $"Key size must be between 0 and {MaxKeySizeBytes} bytes.");
        }

        HashSizeValue = outputBytes * 8;
        _core = new Blake2bState(simdSupport, outputBytes);
        if (!key.IsEmpty)
        {
            _key = new byte[key.Length];
            key.CopyTo(_key);
        }

        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _key != null ? "BLAKE2b-MAC" : "BLAKE2b";

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets a value indicating whether this instance is configured for keyed hashing (MAC mode).
    /// </summary>
    public bool IsKeyed => _key != null;

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with default output size.
    /// </summary>
    /// <returns>A new BLAKE2b instance.</returns>
    public static new Blake2b Create() => new();

    /// <summary>
    /// Computes the BLAKE2b hash of <paramref name="source"/> using the default output size (64 bytes)
    /// and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="MaxHashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<Blake2b>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the BLAKE2b hash of <paramref name="source"/> using the default output size (64 bytes)
    /// and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the BLAKE2b hash.</returns>
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<Blake2b>.HashData(source);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <returns>A new BLAKE2b instance.</returns>
    public static Blake2b Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake2b"/> class with specified output size and SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <returns>A new BLAKE2b instance.</returns>
    internal static Blake2b Create(SimdSupport simdSupport, int outputBytes) => new(simdSupport, outputBytes, null);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The key for keyed hashing (MAC mode). Must be 0-<see cref="MaxKeySizeBytes"/> bytes.</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    public static Blake2b CreateKeyed(int outputBytes, ReadOnlySpan<byte> key) => new(outputBytes, key);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class with default output size.
    /// </summary>
    /// <param name="key">The key for keyed hashing (MAC mode). Must be 0-<see cref="MaxKeySizeBytes"/> bytes.</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    public static Blake2b CreateKeyed(ReadOnlySpan<byte> key) => new(MaxHashSizeBytes, key);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake2b"/> class with specified SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes (1-64).</param>
    /// <param name="key">The key for keyed hashing (up to 64 bytes).</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <returns>A new BLAKE2b instance configured for keyed hashing.</returns>
    internal static Blake2b CreateKeyed(SimdSupport simdSupport, int outputBytes, ReadOnlySpan<byte> key) => new(simdSupport, outputBytes, key);

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static new SimdSupport SimdSupport => Blake2bState.SimdSupport;
#endif

    /// <inheritdoc/>
    public override void Initialize()
    {
        _core.Reset(_key);
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        _core.Append(source);
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        return _core.TryGetCurrentHash(destination, out bytesWritten);
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _core.Dispose();
            ClearBuffer(_key);
        }
        base.Dispose(disposing);
    }
}
