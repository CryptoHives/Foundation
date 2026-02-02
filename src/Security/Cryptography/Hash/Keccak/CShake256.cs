// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Buffers;
using System.Text;

/// <summary>
/// Computes a customizable SHAKE256 (cSHAKE256) output.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of cSHAKE256 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// cSHAKE256 is a customizable variant of SHAKE256 defined in NIST SP 800-185.
/// It supports function name (N) and customization string (S) parameters for domain separation.
/// </para>
/// <para>
/// When both N and S are empty, cSHAKE256 is equivalent to SHAKE256.
/// </para>
/// </remarks>
public sealed class CShake256 : KeccakCore
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 512;

    /// <summary>
    /// The rate in bytes (1088 bits for cSHAKE256).
    /// </summary>
    public const int RateBytes = 136;

    /// <summary>
    /// The capacity in bytes (512 bits for cSHAKE256).
    /// </summary>
    public const int CapacityBytes = 64;

    private readonly int _outputBytes;
    private readonly byte[] _encodedFunctionName;
    private readonly byte[] _encodedCustomization;
    private readonly bool _isCustomized;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="CShake256"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name string N (for NIST-defined functions).</param>
    /// <param name="customization">The customization string S.</param>
    public CShake256(int outputBytes = DefaultOutputBits / 8, string? functionName = null, string? customization = null)
        : this(SimdSupport.KeccakDefault, outputBytes,
              functionName == null ? [] : Encoding.UTF8.GetBytes(functionName),
              customization == null ? [] : Encoding.UTF8.GetBytes(customization))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CShake256"/> class with byte array parameters.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name bytes N.</param>
    /// <param name="customization">The customization bytes S.</param>
    public CShake256(int outputBytes, byte[]? functionName, byte[]? customization)
        : this(SimdSupport.KeccakDefault, outputBytes, functionName, customization)
    {
    }

    internal CShake256(SimdSupport simdSupport, int outputBytes, byte[]? functionName, byte[]? customization)
        : base(RateBytes, simdSupport)
    {
        if (outputBytes <= 0) throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        _outputBytes = outputBytes;
        _encodedFunctionName = CShake128.EncodeString(functionName ?? Array.Empty<byte>());
        _encodedCustomization = CShake128.EncodeString(customization ?? Array.Empty<byte>());
        _isCustomized = functionName?.Length > 0 || customization?.Length > 0;

        HashSizeValue = outputBytes * 8;
        Initialize();
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "cSHAKE256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="CShake256"/> class with default parameters.
    /// </summary>
    public static new CShake256 Create() => new();

    /// <summary>
    /// Creates a new instance of the CShake256 hash function with the specified output length, function name, and
    /// customization string.
    /// </summary>
    /// <param name="outputBytes">The desired length, in bytes, of the hash output. Must be a positive integer.</param>
    /// <param name="functionName">An optional function name as a byte array, used to domain-separate the hash function. Can be null if no function
    /// name is required.</param>
    /// <param name="customization">An optional customization string as a byte array, used to further parameterize the hash function. Can be null if
    /// no customization is required.</param>
    /// <returns>A new CShake256 instance configured with the specified output length, function name, and customization string.</returns>
    public static CShake256 Create(int outputBytes, byte[]? functionName = null, byte[]? customization = null)
        => new(SimdSupport.KeccakDefault, outputBytes, functionName, customization);

    /// <summary>
    /// Creates a new instance of the <see cref="CShake256"/> class with specified parameters.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name N (for NIST-defined functions).</param>
    /// <param name="customization">The customization string S (user-defined).</param>
    public static CShake256 Create(int outputBytes, string functionName, string? customization = null)
        => new(outputBytes, functionName, customization);

    internal static CShake256 Create(SimdSupport simdSupport, int outputBytes = DefaultOutputBits / 8, byte[]? functionName = null, byte[]? customization = null)
        => new(simdSupport, outputBytes, functionName, customization);

    internal static CShake256 Create(SimdSupport simdSupport, int outputBytes, string functionName, string? customization = null)
        => new(simdSupport, outputBytes,
            Encoding.UTF8.GetBytes(functionName),
            customization == null ? null : Encoding.UTF8.GetBytes(customization));

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();
        _finalized = false;
        _squeezeOffset = 0;

        if (_isCustomized)
        {
            AbsorbBytePad();
        }
    }

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        if (_finalized)
        {
            throw new InvalidOperationException("Cannot add data after finalization.");
        }

        base.HashCore(source);
    }

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        bytesWritten = _outputBytes;
        Squeeze(destination);
        return true;
    }

    /// <summary>
    /// Squeezes output bytes from the XOF state.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    public void Squeeze(Span<byte> output)
    {
        if (!_finalized)
        {
            byte domainSep = _isCustomized ? (byte)0x04 : (byte)0x1F;
            _buffer[_bufferLength++] = domainSep;

            while (_bufferLength < RateBytes - 1)
            {
                _buffer[_bufferLength++] = 0x00;
            }

            _buffer[RateBytes - 1] |= 0x80;

            _keccakCore.Absorb(_buffer, RateBytes);
            _finalized = true;
            _squeezeOffset = 0;
        }

        _keccakCore.SqueezeXof(output, RateBytes, ref _squeezeOffset);
    }

    private void AbsorbBytePad()
    {
        byte[] encodedN = _encodedFunctionName;
        byte[] encodedS = _encodedCustomization;

        Span<byte> leftEncodedRate = stackalloc byte[CShake128.EncodeBufferLength];
        if (!CShake128.TryLeftEncode(leftEncodedRate, RateBytes, out int leftEncodedBytes))
        {
            throw new InvalidOperationException("Failed to encode left rate.");
        }

        int totalLen = leftEncodedBytes + encodedN.Length + encodedS.Length;
        int padLen = (_rateBytes - (totalLen % _rateBytes)) % _rateBytes;

        // Create a padded buffer
        int paddedLength = totalLen + padLen;
        byte[]? pooledBuffer = null;
        Span<byte> paddedBuffer = paddedLength <= _rateBytes ?
            stackalloc byte[_rateBytes] :
            (pooledBuffer = ArrayPool<byte>.Shared.Rent(paddedLength));

        try
        {
            int offset = 0;
            leftEncodedRate.Slice(0, leftEncodedBytes).CopyTo(paddedBuffer.Slice(offset));
            offset += leftEncodedBytes;

            encodedN.AsSpan(0, encodedN.Length).CopyTo(paddedBuffer.Slice(offset));
            offset += encodedN.Length;

            encodedS.AsSpan(0, encodedS.Length).CopyTo(paddedBuffer.Slice(offset));
            offset += encodedS.Length;

            // Absorb the bytepad data
            for (int i = 0; i < paddedLength; i += RateBytes)
            {
                int blockLen = Math.Min(RateBytes, paddedBuffer.Length - i);
                if (blockLen == RateBytes)
                {
                    _keccakCore.Absorb(paddedBuffer.Slice(i, RateBytes), RateBytes);
                }
                else
                {
                    paddedBuffer.Slice(i, blockLen).CopyTo(_buffer.AsSpan(_bufferLength));
                    _bufferLength += blockLen;
                }
            }
        }
        finally
        {
            if (pooledBuffer != null)
            {
                ArrayPool<byte>.Shared.Return(pooledBuffer, true);
            }
        }
    }
}
