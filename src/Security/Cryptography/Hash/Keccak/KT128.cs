// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
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
public sealed class KT128 : HashAlgorithm
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

    private const int InitialBufferSize = 256;

    private readonly int _outputBytes;
    private readonly byte[] _customization;
    private readonly SimdSupport _simdSupport;
    private byte[] _buffer;
    private int _bufferLength;
    private bool _finalized;

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
    public KT128(int outputBytes, ReadOnlySpan<byte> customization) : this(SimdSupport.Default, outputBytes, customization)
    {
    }

    internal KT128(SimdSupport simdSupport, int outputBytes, ReadOnlySpan<byte> customization)
    {
        if (outputBytes <= 0) throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
        _customization = customization.ToArray();
        _simdSupport = simdSupport;
        _buffer = new byte[InitialBufferSize];
        _bufferLength = 0;
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

    /// <inheritdoc/>
    public override void Initialize()
    {
        _bufferLength = 0;
        _finalized = false;
    }

    /// <summary>
    /// Absorbs a block of input data into the hash state.
    /// </summary>
    /// <param name="data">The data to absorb.</param>
    internal void AbsorbData(ReadOnlySpan<byte> data)
    {
        HashCore(data);
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_finalized)
        {
            throw new InvalidOperationException("Cannot add data after finalization.");
        }

        EnsureBufferCapacity(_bufferLength + source.Length);
        source.CopyTo(_buffer.AsSpan(_bufferLength));
        _bufferLength += source.Length;
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        bytesWritten = _outputBytes;
        Squeeze(destination.Slice(0, _outputBytes));
        return true;
    }

    /// <summary>
    /// Squeezes output bytes from the KT128 state.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    public void Squeeze(Span<byte> output)
    {
        if (!_finalized)
        {
            FinalizeInternal(output);
            _finalized = true;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void EnsureBufferCapacity(int requiredCapacity)
    {
        if (_buffer.Length >= requiredCapacity)
        {
            return;
        }

        int newSize = _buffer.Length;
        while (newSize < requiredCapacity)
        {
            newSize *= 2;
        }

        byte[] newBuffer = new byte[newSize];
        _buffer.AsSpan(0, _bufferLength).CopyTo(newBuffer);
        _buffer = newBuffer;
    }

    private void FinalizeInternal(Span<byte> output)
    {
        // Build S = M || C || length_encode(|C|)
        int custLen = _customization.Length;
        Span<byte> encodedLen = stackalloc byte[9];
        int encLen = LengthEncode(encodedLen, (ulong)custLen);

        int totalLen = _bufferLength + custLen + encLen;
        EnsureBufferCapacity(totalLen);

        // Append customization string
        _customization.AsSpan().CopyTo(_buffer.AsSpan(_bufferLength));
        _bufferLength += custLen;

        // Append length_encode(|C|)
        encodedLen.Slice(0, encLen).CopyTo(_buffer.AsSpan(_bufferLength));
        _bufferLength += encLen;

        ReadOnlySpan<byte> s = _buffer.AsSpan(0, _bufferLength);

        if (_bufferLength <= ChunkSize)
        {
            // Single-node mode: TurboSHAKE128(S, 0x07, L)
            ComputeTurboShake128(s, output, DomainSingleNode);
        }
        else
        {
            // Tree hashing mode
            ComputeTreeHash(s, output);
        }
    }

    private void ComputeTurboShake128(ReadOnlySpan<byte> input, Span<byte> output, byte domainSeparator)
    {
        using var turbo = TurboShake128.Create(_simdSupport, output.Length, domainSeparator);
        turbo.TransformBlock(input);
        turbo.Squeeze(output);
    }

    private void ComputeTreeHash(ReadOnlySpan<byte> s, Span<byte> output)
    {
        // Calculate number of chunks
        int numChunks = (s.Length + ChunkSize - 1) / ChunkSize;

        // Build FinalNode = S_0 || 0x03 || 0x00^7 || CV_1 || ... || CV_(n-1) || length_encode(n-1) || 0xFF || 0xFF
        int finalNodeSize = ChunkSize + 8 + (numChunks - 1) * ChainingValueSize + 9 + 2;
        byte[] finalNode = new byte[finalNodeSize];
        int finalNodeLen = 0;

        // Copy S_0 (first chunk)
        int firstChunkLen = Math.Min(ChunkSize, s.Length);
        s.Slice(0, firstChunkLen).CopyTo(finalNode.AsSpan(finalNodeLen));
        finalNodeLen += firstChunkLen;

        // Append 0x03 || 0x00^7
        finalNode[finalNodeLen++] = 0x03;
        for (int i = 0; i < 7; i++)
        {
            finalNode[finalNodeLen++] = 0x00;
        }

        // Compute and append chaining values CV_1 to CV_(n-1)
        for (int i = 1; i < numChunks; i++)
        {
            int chunkStart = i * ChunkSize;
            int chunkLen = Math.Min(ChunkSize, s.Length - chunkStart);
            ReadOnlySpan<byte> chunk = s.Slice(chunkStart, chunkLen);

            // CV_i = TurboSHAKE128(S_i, 0x0B, 32)
            Span<byte> cv = finalNode.AsSpan(finalNodeLen, ChainingValueSize);
            ComputeTurboShake128(chunk, cv, DomainIntermediateNode);
            finalNodeLen += ChainingValueSize;
        }

        // Append length_encode(n-1)
        Span<byte> encodedNumBlocks = stackalloc byte[9];
        int encLen = LengthEncode(encodedNumBlocks, (ulong)(numChunks - 1));
        encodedNumBlocks.Slice(0, encLen).CopyTo(finalNode.AsSpan(finalNodeLen));
        finalNodeLen += encLen;

        // Append 0xFF || 0xFF
        finalNode[finalNodeLen++] = 0xFF;
        finalNode[finalNodeLen++] = 0xFF;

        // Output = TurboSHAKE128(FinalNode, 0x06, L)
        ComputeTurboShake128(finalNode.AsSpan(0, finalNodeLen), output, DomainFinalNode);
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
            Array.Clear(_buffer, 0, _buffer.Length);
        }
        base.Dispose(disposing);
    }
}
