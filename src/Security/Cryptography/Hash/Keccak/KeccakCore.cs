// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;

/// <summary>
/// All algorithms based on the Keccak permutation should derive from this class.
/// Provides the derived implementations with the core Keccak-f[1600] permutation,
/// state variables and a buffer for the rate bytes.
/// </summary>
/// <remarks>
/// <para>
/// This class holds the Keccak state used by SHA-3, SHAKE, cSHAKE, KMAC,
/// and related algorithms. It is designed as a shared primitive to reduce code
/// duplication across Keccak-based implementations.
/// </para>
/// <para>
/// The Keccak state is a 5×5×64 = 1600-bit array organized as 25 64-bit lanes.
/// </para>
/// </remarks>
public abstract class KeccakCore : HashAlgorithm
{
    // KeccakCoreState is a struct and shall never be readonly
    private protected KeccakCoreState _keccakCore;
    private protected readonly byte[] _buffer;
    private protected readonly int _rateBytes;
    private protected int _bufferLength;
    private protected bool _disposed;
    private protected bool _useOsNative;
    private protected System.Security.Cryptography.HashAlgorithm? _osImpl;

    /// <summary>
    /// The maximum chunk size copied into a pooled buffer when feeding data to an OS-native implementation.
    /// </summary>
    private const int OsNativeChunkSizeBytes = 8192;

    internal KeccakCore(int rateBytes, SimdSupport simdSupport = SimdSupport.KeccakDefault, bool useOsNative = false)
        : this(rateBytes, 0, simdSupport, useOsNative)
    {
    }

    internal KeccakCore(int rateBytes, int startRound, SimdSupport simdSupport = SimdSupport.KeccakDefault, bool useOsNative = false)
    {
        _keccakCore = new KeccakCoreState(simdSupport, startRound);
        _buffer = new byte[rateBytes];
        _rateBytes = rateBytes;
        _useOsNative = useOsNative;
    }

    /// <summary>
    /// When OS-native use is requested, creates the OS-native <see cref="System.Security.Cryptography.HashAlgorithm"/>
    /// instance to delegate hashing to. Returns <see langword="null"/> if this algorithm has no known OS-native
    /// equivalent, in which case the managed implementation is used instead.
    /// </summary>
    protected virtual System.Security.Cryptography.HashAlgorithm? CreateOsNativeInstance() => null;

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public override void Initialize()
    {
        if (_disposed) throw new ObjectDisposedException(GetType().Name);

        _keccakCore.Reset();
        ClearBuffer(_buffer);
        _bufferLength = 0;

        if (_useOsNative)
        {
            _osImpl ??= CreateOsNativeInstance();
            if (_osImpl is not null)
            {
                _osImpl.Initialize();
                return;
            }

            // Defensive fallback: OS-native use was requested but no OS-native instance is available.
            _useOsNative = false;
        }
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by this algorithm on the current platform.
    /// </summary>
    internal static new SimdSupport SimdSupport => KeccakCoreState.SimdSupport;

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_disposed) throw new ObjectDisposedException(GetType().Name);

        if (_useOsNative)
        {
            HashCoreOsNative(source);
            return;
        }

        int offset = 0;

        // If we have data in buffer, fill it first
        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(_rateBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == _rateBytes)
            {
                _keccakCore.Absorb(_buffer, _rateBytes);
                _bufferLength = 0;
            }
        }

        // Process full blocks
        while (offset + _rateBytes <= source.Length)
        {
            _keccakCore.Absorb(source.Slice(offset, _rateBytes), _rateBytes);
            offset += _rateBytes;
        }

        // Store remaining bytes
        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan());
            _bufferLength = source.Length - offset;
        }
    }

    /// <summary>
    /// Feeds <paramref name="source"/> into <see cref="_osImpl"/> via a pooled chunk buffer, since
    /// <see cref="System.Security.Cryptography.HashAlgorithm.TransformBlock"/> requires an array.
    /// </summary>
    private void HashCoreOsNative(ReadOnlySpan<byte> source)
    {
        if (source.IsEmpty) return;

        int chunkSize = Math.Min(source.Length, OsNativeChunkSizeBytes);
        byte[] chunk = ArrayPool<byte>.Shared.Rent(chunkSize);
        try
        {
            int offset = 0;
            while (offset < source.Length)
            {
                int length = Math.Min(chunkSize, source.Length - offset);
                source.Slice(offset, length).CopyTo(chunk);
                _osImpl!.TransformBlock(chunk, 0, length, chunk, 0);
                offset += length;
            }
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(chunk, clearArray: true);
        }
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _keccakCore.Reset();
            ClearBuffer(_buffer);
            _disposed = true;
            _osImpl?.Dispose();
            _osImpl = null;
        }
        base.Dispose(disposing);
    }
}
