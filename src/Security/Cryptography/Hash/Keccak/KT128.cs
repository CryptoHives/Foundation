// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

/// <summary>
/// Computes a variable-length hash using KT128 (KangarooTwelve) per RFC 9861.
/// </summary>
/// <remarks>
/// <para>
/// KT128 is a high-performance extendable-output function (XOF) that applies tree hashing
/// on top of TurboSHAKE128. It provides 128-bit security and supports parallel hashing
/// for large inputs using Sakura-compatible tree mode.
/// </para>
/// <para>
/// KT128 uses a rate of 168 bytes (same as TurboSHAKE128) and splits input into 8192-byte chunks.
/// For inputs ≤ 8192 bytes, it operates as a single TurboSHAKE128 call with domain separator 0x07.
/// For larger inputs, it uses tree hashing with 32-byte chaining values.
/// </para>
/// <para>
/// This implementation is specified in RFC 9861 Section 3.2.
/// </para>
/// </remarks>
public sealed class KT128 : HashAlgorithm, IExtendableOutput
{
    /// <summary>
    /// The rate in bytes for KT128 (1344 bits = 168 bytes, same as TurboSHAKE128).
    /// </summary>
    public const int RateBytes = 168;

    /// <summary>
    /// The chunk size for tree hashing (8192 bytes).
    /// </summary>
    public const int ChunkSize = 8192;

    /// <summary>
    /// The chaining value size in bytes (32 bytes for KT128).
    /// </summary>
    public const int ChainingValueSize = 32;

    /// <summary>
    /// Domain separator for single-node mode (input ≤ 8192 bytes).
    /// </summary>
    private const byte DomainSingleNode = 0x07;

    /// <summary>
    /// Domain separator for intermediate nodes (chaining values).
    /// </summary>
    private const byte DomainIntermediateNode = 0x0B;

    /// <summary>
    /// Domain separator for final node (tree hashing).
    /// </summary>
    private const byte DomainFinalNode = 0x06;

    private readonly int _outputBytes;
    private readonly byte[] _customization;

    // Two sponges are needed, not one: _outer accumulates the final node across the whole
    // message while _inner is reset per chunk, so neither can serve as scratch for the other.
    private readonly TurboShake128 _inner;
    private readonly TurboShake128 _outer;

    // S_0 is the prefix of the final node, so it is the one part of the message that must be
    // kept. Exactly ChunkSize, never grown, and returned once the tree path is committed to.
    private byte[]? _head;
    private int _headLength;
    private int _chunkFill;
    private long _chunkCount;
    private bool _treeMode;
    private bool _squeezeFromOuter;
    private bool _finalized;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="KT128"/> class with default output size.
    /// </summary>
    public KT128() : this(32, ReadOnlySpan<byte>.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KT128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public KT128(int outputBytes) : this(outputBytes, ReadOnlySpan<byte>.Empty)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KT128"/> class with customization string.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">The customization string for domain separation.</param>
    public KT128(int outputBytes, string customization)
        : this(outputBytes, string.IsNullOrEmpty(customization) ? ReadOnlySpan<byte>.Empty : Encoding.UTF8.GetBytes(customization))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KT128"/> class with customization bytes.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">The customization bytes for domain separation.</param>
    public KT128(int outputBytes, ReadOnlySpan<byte> customization) : this(KeccakCore.KeccakDefault, outputBytes, customization)
    {
    }

    internal KT128(SimdSupport simdSupport, int outputBytes, ReadOnlySpan<byte> customization)
    {
        if (outputBytes <= 0) throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _customization = customization.ToArray();
        _inner = new TurboShake128(simdSupport, ChainingValueSize, DomainSingleNode);
        _outer = new TurboShake128(simdSupport, ChainingValueSize, DomainFinalNode);
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "KT128";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="KT128"/> class with default output size (32 bytes).
    /// </summary>
    /// <returns>A new KT128 instance.</returns>
    public static new KT128 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="KT128"/> class with specified output size.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <returns>A new KT128 instance.</returns>
    public static KT128 Create(int outputBytes) => new(outputBytes);

    /// <summary>
    /// Creates a new instance with customization string.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">The customization string for domain separation.</param>
    /// <returns>A new KT128 instance.</returns>
    public static KT128 Create(int outputBytes, string customization) => new(outputBytes, customization);

    /// <summary>
    /// Creates a new instance with customization bytes.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">The customization bytes for domain separation.</param>
    /// <returns>A new KT128 instance.</returns>
    public static KT128 Create(int outputBytes, ReadOnlySpan<byte> customization) => new(outputBytes, customization);

    internal static KT128 Create(SimdSupport simdSupport, int outputBytes) => new(simdSupport, outputBytes, ReadOnlySpan<byte>.Empty);

    internal static new SimdSupport SimdSupport => KeccakCoreState.SimdSupport;

    /// <summary>
    /// Computes the KT128 hash of <paramref name="source"/> using the default output size (32 bytes)
    /// and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <c>32</c> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<KT128>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the KT128 hash of <paramref name="source"/> using the default output size (32 bytes)
    /// and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The input data to hash.</param>
    /// <returns>A new byte array containing the KT128 hash.</returns>
    public static byte[] HashData(ReadOnlySpan<byte> source)
        => HashAlgorithmPool<KT128>.HashData(source);

    /// <summary>
    /// Computes the KT128 hash of <paramref name="source"/> using the default output size (32 bytes)
    /// and writes it into <paramref name="destination"/>.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <param name="destination">The buffer to receive the hash value. Must be at least <c>32</c> bytes.</param>
    /// <param name="bytesWritten">When this method returns, the number of bytes written into <paramref name="destination"/>.</param>
    /// <returns><see langword="true"/> if <paramref name="destination"/> was large enough; otherwise, <see langword="false"/>.</returns>
    public static bool TryHashData(in ReadOnlySequence<byte> source, Span<byte> destination, out int bytesWritten)
        => HashAlgorithmPool<KT128>.TryHashData(source, destination, out bytesWritten);

    /// <summary>
    /// Computes the KT128 hash of <paramref name="source"/> using the default output size (32 bytes)
    /// and returns it as a new byte array.
    /// </summary>
    /// <param name="source">The (possibly multi-segment) input sequence to hash.</param>
    /// <returns>A new byte array containing the KT128 hash.</returns>
    public static byte[] HashData(in ReadOnlySequence<byte> source)
        => HashAlgorithmPool<KT128>.HashData(source);

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public override void Initialize()
    {
        if (_disposed) throw new ObjectDisposedException(nameof(KT128));

        _head ??= ArrayPool<byte>.Shared.Rent(ChunkSize);
        _headLength = 0;
        _chunkFill = 0;
        _chunkCount = 0;
        _treeMode = false;
        _squeezeFromOuter = false;
        _finalized = false;
    }

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input)
    {
        HashCore(input);
    }

    /// <inheritdoc/>
    public void Reset()
    {
        Initialize();
    }

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(KT128));
        if (_finalized)
        {
            throw new InvalidOperationException("Cannot add data after finalization.");
        }

        AbsorbCore(source);
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputBytes)
        {
            bytesWritten = 0;
            return false;
        }

        bytesWritten = _outputBytes;
        Squeeze(destination.Slice(0, _outputBytes));
        return true;
    }

    /// <summary>
    /// Squeezes output bytes from the KT128 state.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public void Squeeze(Span<byte> output)
    {
        if (_disposed) throw new ObjectDisposedException(nameof(KT128));
        if (!_finalized)
        {
            FinalizeInternal(output);
            _finalized = true;
            return;
        }

        (_squeezeFromOuter ? _outer : _inner).Squeeze(output);
    }

    /// <summary>
    /// Absorbs message bytes, emitting a chaining value every time a chunk completes.
    /// </summary>
    /// <remarks>
    /// Also used at finalization for <c>C || length_encode(|C|)</c>, because those bytes are part
    /// of S and can themselves carry a short message over the chunk boundary.
    /// </remarks>
    private void AbsorbCore(ReadOnlySpan<byte> input)
    {
        if (!_treeMode)
        {
            int take = Math.Min(ChunkSize - _headLength, input.Length);
            input.Slice(0, take).CopyTo(_head!.AsSpan(_headLength));
            _headLength += take;
            input = input.Slice(take);

            if (input.IsEmpty)
            {
                return;
            }

            // Bytes remain with S_0 already full, so S cannot be a single node.
            EnterTreeMode();
        }

        while (!input.IsEmpty)
        {
            int take = Math.Min(ChunkSize - _chunkFill, input.Length);
            _inner.Absorb(input.Slice(0, take));
            _chunkFill += take;
            input = input.Slice(take);

            if (_chunkFill == ChunkSize)
            {
                FlushChunk();
            }
        }
    }

    /// <summary>
    /// Commits to the tree path: absorbs <c>S_0 || 0x03 || 0x00^7</c> into the final-node sponge
    /// and releases the head buffer, which is dead from here on.
    /// </summary>
    private void EnterTreeMode()
    {
        Debug.Assert(_headLength == ChunkSize, "the tree path is only reachable once S_0 is full");

        _outer.ResetWithDomainSeparator(DomainFinalNode);
        _outer.Absorb(_head!.AsSpan(0, ChunkSize));

        Span<byte> interiorMarker = stackalloc byte[8];
        interiorMarker.Clear();
        interiorMarker[0] = 0x03;
        _outer.Absorb(interiorMarker);

        ArrayPool<byte>.Shared.Return(_head!, clearArray: true);
        _head = null;
        _headLength = 0;

        _inner.ResetWithDomainSeparator(DomainIntermediateNode);
        _chunkFill = 0;
        _treeMode = true;
    }

    /// <summary>
    /// Squeezes the chaining value for the chunk currently in <c>_inner</c> straight into the
    /// final-node sponge, so no chaining value is ever stored.
    /// </summary>
    private void FlushChunk()
    {
        Span<byte> chainingValue = stackalloc byte[ChainingValueSize];
        _inner.Squeeze(chainingValue);
        _outer.Absorb(chainingValue);
        _chunkCount++;

        _inner.ResetWithDomainSeparator(DomainIntermediateNode);
        _chunkFill = 0;
    }

    private void FinalizeInternal(Span<byte> output)
    {
        // S = M || C || length_encode(|C|)
        Span<byte> encodedLen = stackalloc byte[9];
        int encLen = LengthEncode(encodedLen, (ulong)_customization.Length);
        AbsorbCore(_customization);
        AbsorbCore(encodedLen.Slice(0, encLen));

        if (!_treeMode)
        {
            _inner.ResetWithDomainSeparator(DomainSingleNode);
            _inner.Absorb(_head!.AsSpan(0, _headLength));
            _inner.Squeeze(output);
            _squeezeFromOuter = false;
            return;
        }

        if (_chunkFill > 0)
        {
            FlushChunk();
        }

        Span<byte> trailer = stackalloc byte[11];
        int trailerLen = LengthEncode(trailer, (ulong)_chunkCount);
        trailer[trailerLen++] = 0xFF;
        trailer[trailerLen++] = 0xFF;
        _outer.Absorb(trailer.Slice(0, trailerLen));
        _outer.Squeeze(output);
        _squeezeFromOuter = true;
    }

    /// <summary>
    /// Encodes a length value per RFC 9861 Section 3.3.
    /// </summary>
    /// <remarks>
    /// The function outputs x in big-endian byte representation followed by the byte count.
    /// For example: length_encode(0) = 0x00, length_encode(12) = 0x0C 0x01,
    /// length_encode(65538) = 0x01 0x00 0x02 0x03.
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int LengthEncode(Span<byte> output, ulong value)
    {
        if (value == 0)
        {
            output[0] = 0x00;
            return 1;
        }

        // Count bytes needed
        int n = 0;
        ulong temp = value;
        while (temp > 0)
        {
            n++;
            temp >>= 8;
        }

        // Write value bytes in big-endian order
        for (int i = 0; i < n; i++)
        {
            output[i] = (byte)(value >> ((n - 1 - i) * 8));
        }

        // Append byte count
        output[n] = (byte)n;
        return n + 1;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _inner.Dispose();
            _outer.Dispose();

            if (_head != null)
            {
                // Clear and return to pool to avoid leaking sensitive data
                ArrayPool<byte>.Shared.Return(_head, clearArray: true);
                _head = null;
            }

            _disposed = true;
        }
        base.Dispose(disposing);
    }
}
