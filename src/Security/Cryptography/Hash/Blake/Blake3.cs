// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using CryptoHives.Foundation.Security.Cryptography;
using System;
using System.Buffers;
using System.Diagnostics;
using System.Text;

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

    /// <summary>
    /// Initializes a new instance of the <see cref="Blake3"/> class in derive-key mode.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="contextUtf8">The UTF-8 encoded context string.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="deriveKey">Unused; disambiguates this overload from the keyed constructor.</param>
    private Blake3(SimdSupport simdSupport, ReadOnlySpan<byte> contextUtf8, int outputBytes, bool deriveKey)
    {
        Debug.Assert(deriveKey, "this overload exists only to disambiguate the derive-key case");

        if (contextUtf8.IsEmpty) throw new ArgumentException("Context must not be empty.", nameof(contextUtf8));
        if (outputBytes < 1) throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        HashSizeValue = outputBytes * 8;
        _mode = Blake3Mode.DeriveKey;

        Span<byte> contextKey = stackalloc byte[KeySizeBytes];
        try
        {
            Blake3State.DeriveContextKey(simdSupport, contextUtf8, contextKey);
            _core = new Blake3State(simdSupport, outputBytes, contextKey, Blake3State.FlagDeriveKeyMaterial);
        }
        finally
        {
            CryptographicOperations.ZeroMemory(contextKey);
        }

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
    /// <remarks>
    /// Uses the dedicated one-shot path (see <see cref="TryHashOneShot"/>) instead of
    /// the generic streaming pool, so the entire call — including small inputs — skips
    /// the incremental chunk-buffer bookkeeping.
    /// </remarks>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
    {
        Blake3 hasher = HashAlgorithmPool<Blake3>.Shared.Get();
        try
        {
            return hasher.TryHashOneShot(source, destination, out bytesWritten);
        }
        finally
        {
            HashAlgorithmPool<Blake3>.Shared.Return(hasher);
        }
    }

    /// <summary>
    /// Computes the BLAKE3 hash of <paramref name="source"/> using the default output size (32 bytes)
    /// and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the BLAKE3 hash.</returns>
    /// <remarks>
    /// Uses the dedicated one-shot path (see <see cref="TryHashOneShot"/>) instead of
    /// the generic streaming pool, so the entire call — including small inputs — skips
    /// the incremental chunk-buffer bookkeeping.
    /// </remarks>
    public static byte[] HashData(ReadOnlySpan<byte> source)
    {
        Blake3 hasher = HashAlgorithmPool<Blake3>.Shared.Get();
        try
        {
            byte[] result = new byte[DefaultHashSizeBytes];
            hasher.TryHashOneShot(source, result, out _);
            return result;
        }
        finally
        {
            HashAlgorithmPool<Blake3>.Shared.Return(hasher);
        }
    }

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

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class in derive-key mode.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The context string is domain separation, not a secret and not an input: the BLAKE3 spec
    /// requires it to be a hard-coded, application-specific, globally unique constant. It must
    /// never be user input, attacker-controlled, or varied per call -- put the varying material
    /// in the key material hashed by the returned instance instead. A good context embeds the
    /// application name, a date and the purpose, e.g. "MyApp 2026-01-01 session key".
    /// </para>
    /// <para>
    /// The returned instance derives from the key material written to it, so callers hash the
    /// input key material and read out the derived key -- optionally longer than 32 bytes,
    /// since derive-key mode is a full XOF.
    /// </para>
    /// </remarks>
    /// <param name="context">The context string. Must not be empty.</param>
    /// <returns>A new BLAKE3 instance configured for key derivation.</returns>
    public static Blake3 CreateDeriveKey(string context) => CreateDeriveKey(context, DefaultHashSizeBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class in derive-key mode with a
    /// specified output size.
    /// </summary>
    /// <param name="context">The context string. Must not be empty. See <see cref="CreateDeriveKey(string)"/>.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new BLAKE3 instance configured for key derivation.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="context"/> is <see langword="null"/>.</exception>
    public static Blake3 CreateDeriveKey(string context, int outputBytes)
    {
        if (context is null) throw new ArgumentNullException(nameof(context));

        // Encoded to an array rather than the stack because Encoding.UTF8.GetBytes(string,
        // Span<byte>) does not exist on net462/netstandard2.0. This is a one-off construction
        // cost, and matches how cSHAKE and KT already encode their customisation strings.
        byte[] contextUtf8 = Encoding.UTF8.GetBytes(context);
        if (contextUtf8.Length == 0) throw new ArgumentException("Context must not be empty.", nameof(context));

        return CreateDeriveKey(contextUtf8, outputBytes);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class in derive-key mode from a
    /// pre-encoded context string.
    /// </summary>
    /// <remarks>
    /// Use this overload when the context is already available as UTF-8 bytes -- a
    /// <c>u8</c> literal, for instance -- to skip the string encoding entirely.
    /// </remarks>
    /// <param name="contextUtf8">The UTF-8 encoded context string. Must not be empty. See <see cref="CreateDeriveKey(string)"/>.</param>
    /// <returns>A new BLAKE3 instance configured for key derivation.</returns>
    public static Blake3 CreateDeriveKey(ReadOnlySpan<byte> contextUtf8)
        => CreateDeriveKey(contextUtf8, DefaultHashSizeBytes);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class in derive-key mode from a
    /// pre-encoded context string, with a specified output size.
    /// </summary>
    /// <param name="contextUtf8">The UTF-8 encoded context string. Must not be empty. See <see cref="CreateDeriveKey(string)"/>.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new BLAKE3 instance configured for key derivation.</returns>
    public static Blake3 CreateDeriveKey(ReadOnlySpan<byte> contextUtf8, int outputBytes)
        => new(SimdSupport.All, contextUtf8, outputBytes, deriveKey: true);

    /// <summary>
    /// Creates a new instance of the <see cref="Blake3"/> class in derive-key mode with
    /// specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="contextUtf8">The UTF-8 encoded context string.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new BLAKE3 instance configured for key derivation.</returns>
    internal static Blake3 CreateDeriveKey(SimdSupport simdSupport, ReadOnlySpan<byte> contextUtf8, int outputBytes)
        => new(simdSupport, contextUtf8, outputBytes, deriveKey: true);

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

        // Anything other than plain Hash carries key words that must survive the reset.
        // Reset(false) runs InitializeHash(), which overwrites _keyWords with the BLAKE3 IV --
        // for a derive-key instance that would discard the context key, and since the
        // constructor calls Initialize() on its last line it would do so before the caller ever
        // touched the instance.
        _core.Reset(_mode != Blake3Mode.Hash);
    }

    /// <inheritdoc/>
    /// <remarks>
    /// A keyed or derive-key instance carries caller-supplied secret material in its
    /// state, so it must never be recycled into a shared pool for an unrelated caller: this
    /// returns <see langword="false"/> for any non-<see cref="Blake3Mode.Hash"/> mode, which
    /// makes the pool's policy <c>Dispose()</c> the instance instead — zeroing the key —
    /// rather than resetting and returning it.
    /// </remarks>
    public override bool TryReset()
    {
        if (_mode != Blake3Mode.Hash)
        {
            // We can only cache non-keyed Blake3 instances. Erase the key the
            // instant TryReset is called — Reset(keyedMode: false) runs
            // InitializeHash(), which unconditionally overwrites _keyWords (not
            // just _cv) with the BLAKE3 IV — regardless of what the caller's
            // pool does with the false return below. The standard pool policy
            // also calls Dispose() on a false return, which zeroes everything
            // again, but this doesn't rely on that happening.
            _core.Reset(false);
            return false;
        }

        return base.TryReset();
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

    /// <summary>
    /// Computes the BLAKE3 hash of <paramref name="source"/> in a single call using
    /// this instance's SIMD tier, without incremental-hashing bookkeeping.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <c>HashSize</c>/8 bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    /// <remarks>
    /// <para>
    /// Unlike <c>TryComputeHash(ReadOnlySpan{byte}, Span{byte}, out int)</c>,
    /// which always routes through the streaming <c>HashCore</c>/<c>TryHashFinal</c>
    /// pair, this calls a dedicated one-shot path directly — see
    /// <see cref="Blake3State.TryHashOneShot"/> for what it skips.
    /// </para>
    /// <para>
    /// The instance must be freshly constructed or freshly <see cref="Initialize"/>d;
    /// calling this after <see cref="Absorb"/> or any streaming write produces
    /// incorrect results.
    /// </para>
    /// </remarks>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public bool TryHashOneShot(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(Blake3));
        bool result = _core.TryHashOneShot(source, destination, out bytesWritten);
        Initialize();
        return result;
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

