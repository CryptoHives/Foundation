// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;

/// <summary>
/// Specifies the mode of operation for BLAKE3.
/// </summary>
public enum Blake3Mode
{
    /// <summary>
    /// Standard hash mode (default).
    /// </summary>
    Hash = 0,

    /// <summary>
    /// Keyed hash mode for message authentication (MAC).
    /// </summary>
    KeyedHash = 1,

    /// <summary>
    /// Key derivation mode for deriving keys from input material.
    /// </summary>
    DeriveKey = 2
}

/// <summary>
/// Computes the BLAKE3 hash for the input data.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of BLAKE3 that does not rely on
/// OS or hardware cryptographic APIs, ensuring deterministic behavior across
/// all platforms and runtimes.
/// </para>
/// <para>
/// BLAKE3 is a cryptographic hash function that is much faster than SHA-256 while
/// maintaining high security. It supports variable output length (XOF mode).
/// </para>
/// <para>
/// BLAKE3 supports three modes: standard hashing, keyed hashing (MAC), and key derivation.
/// </para>
/// </remarks>
public sealed class Blake3 : HashAlgorithm, IExtendableOutput
{
    /// <summary>
    /// The default hash size in bits.
    /// </summary>
    public const int DefaultHashSizeBits = Blake3State.DefaultHashSizeBits;

    /// <summary>
    /// The default hash size in bytes.
    /// </summary>
    public const int DefaultHashSizeBytes = Blake3State.DefaultHashSizeBytes;

    /// <summary>
    /// The required key size in bytes for keyed hash mode.
    /// </summary>
    public const int KeySizeBytes = Blake3State.KeySizeBytes;

    /// <summary>
    /// The block size in bytes.
    /// </summary>
    public const int BlockSizeBytes = Blake3State.BlockSizeBytes;

    /// <summary>
    /// The chunk size in bytes (1024 bytes).
    /// </summary>
    public const int ChunkSizeBytes = Blake3State.ChunkSizeBytes;

    // Blake3 core state
    private Blake3State _core;
    private readonly Blake3Mode _mode;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class with default output size (32 bytes).
    /// </summary>
    public Blake3() : this(SimdSupport.All, DefaultHashSizeBytes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public Blake3(int outputBytes) : this(SimdSupport.All, outputBytes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class with specified output size and SIMD support.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use. Use <see cref="SimdSupport.None"/> for scalar-only.</param>
    internal Blake3(SimdSupport simdSupport, int outputBytes)
    {
        if (outputBytes < 1)
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        HashSizeValue = outputBytes * 8;
        _mode = Blake3Mode.Hash;
        _core = new Blake3State(simdSupport, outputBytes);
        Initialize();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class in keyed hash mode.
    /// </summary>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    private Blake3(ReadOnlySpan<byte> key, int outputBytes) : this(SimdSupport.All, key, outputBytes)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class in keyed hash mode with SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    private Blake3(SimdSupport simdSupport, ReadOnlySpan<byte> key, int outputBytes)
    {
        if (key.Length != KeySizeBytes) throw new ArgumentException($"Key must be exactly {KeySizeBytes} bytes.", nameof(key));
        if (outputBytes < 1) throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        HashSizeValue = outputBytes * 8;
        _mode = Blake3Mode.KeyedHash;
        _core = new Blake3State(simdSupport, outputBytes, key);

        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _mode switch {
        Blake3Mode.KeyedHash => "BLAKE3-Keyed",
        Blake3Mode.DeriveKey => "BLAKE3-DeriveKey",
        _ => "BLAKE3"
    };

    /// <inheritdoc/>
    public override int BlockSize => BlockSizeBytes;

    /// <summary>
    /// Gets the mode of operation for this instance.
    /// </summary>
    public Blake3Mode Mode => _mode;

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class with default output size.
    /// </summary>
    /// <returns>A new BLAKE3 instance.</returns>
    public static new Blake3 Create() => new();

    /// <summary>
    /// Computes the BLAKE3 hash of <paramref name="source"/> using the default output size (32 bytes)
    /// and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="DefaultHashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<Blake3>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the BLAKE3 hash of <paramref name="source"/> using the default output size (32 bytes)
    /// and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the BLAKE3 hash.</returns>
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<Blake3>.HashData(source);

    /// <summary>
    /// Computes the BLAKE3 hash of <paramref name="source"/> using the default output size (32 bytes)
    /// and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <see cref="DefaultHashSizeBytes"/> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(in ReadOnlySequence<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<Blake3>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the BLAKE3 hash of <paramref name="source"/> using the default output size (32 bytes)
    /// and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <returns>A new byte array containing the BLAKE3 hash.</returns>
    public static byte[] HashData(in ReadOnlySequence<byte> source)
        => HashAlgorithmPool<Blake3>.HashData(source);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new BLAKE3 instance.</returns>
    public static Blake3 Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class with specified output size and SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new BLAKE3 instance.</returns>
    internal static Blake3 Create(SimdSupport simdSupport, int outputBytes) => new(simdSupport, outputBytes);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake3"/> class.
    /// </summary>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <returns>A new BLAKE3 instance configured for keyed hashing.</returns>
    public static Blake3 CreateKeyed(ReadOnlySpan<byte> key) => new(key, DefaultHashSizeBytes);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake3"/> class with specified output size.
    /// </summary>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new BLAKE3 instance configured for keyed hashing.</returns>
    public static Blake3 CreateKeyed(ReadOnlySpan<byte> key, int outputBytes) => new(key, outputBytes);

    /// <summary>
    /// Creates a new keyed instance of the <see cref="Blake3"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The 32-byte key for keyed hashing.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new BLAKE3 instance configured for keyed hashing.</returns>
    internal static Blake3 CreateKeyed(SimdSupport simdSupport, ReadOnlySpan<byte> key, int outputBytes) => new(simdSupport, key, outputBytes);

#if NET8_0_OR_GREATER
    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static new SimdSupport SimdSupport => Blake3State.SimdSupport;
#endif

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public override void Initialize()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Blake3));
        _core.Reset(_mode == Blake3Mode.KeyedHash);
    }

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input)
    {
        if (_core.Squeezed) throw new InvalidOperationException("Cannot add data after finalization.");
        HashCore(input);
    }

    /// <inheritdoc/>
    public void Reset()
    {
        Initialize();
    }

    /// <summary>
    /// Finalizes the hash and squeezes output of the specified length.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public void Squeeze(Span<byte> output)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Blake3));
        _core.Squeeze(output);
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Blake3));
        _core.Append(source);
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Blake3));
        return _core.TryGetCurrentHash(destination, out bytesWritten);
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _core.Dispose();
            _disposed = true;
        }
        base.Dispose(disposing);
    }
}

