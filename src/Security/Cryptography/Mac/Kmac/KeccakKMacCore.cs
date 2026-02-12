// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
using System.Buffers;
using System.Text;

/// <summary>
/// Base class for KMAC (Keccak Message Authentication Code) variants.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of KMAC based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// KMAC is a MAC function based on Keccak (cSHAKE) defined in NIST SP 800-185.
/// It supports variable-length output and can be used as both a traditional MAC
/// (fixed output length) or as a pseudorandom function (XOF mode with arbitrary
/// output length).
/// </para>
/// </remarks>
public abstract class KeccakKMacCore : KeccakCore, IExtendableOutput
{
    private static readonly byte[] _kmacFunctionName = Encoding.ASCII.GetBytes("KMAC");
    private static readonly byte[] _encodedKMacFunctionName = CShake128.EncodeString(_kmacFunctionName);

    private readonly int _outputBytes;
    private readonly byte[] _encodedKey;
    private readonly byte[] _encodedCustomization;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeccakKMacCore"/> class.
    /// </summary>
    /// <param name="rateBytes">The rate in bytes for this variant.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization string S.</param>
    internal KeccakKMacCore(int rateBytes, SimdSupport simdSupport, byte[] key, int outputBytes, string? customization)
        : this(rateBytes, simdSupport, key, outputBytes, string.IsNullOrEmpty(customization) ? Array.Empty<byte>() : Encoding.UTF8.GetBytes(customization))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KeccakKMacCore"/> class.
    /// </summary>
    /// <param name="rateBytes">The rate in bytes for this variant.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization bytes S.</param>
    internal KeccakKMacCore(int rateBytes, SimdSupport simdSupport, byte[] key, int outputBytes, byte[]? customization)
        : base(rateBytes, simdSupport)
    {
        if (key is null || key.Length == 0)
        {
            throw new ArgumentNullException(nameof(key), "Key cannot be null or empty.");
        }

        if (outputBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        _outputBytes = outputBytes;
        _encodedKey = CShake128.EncodeString(key);
        _encodedCustomization = CShake128.EncodeString(customization ?? Array.Empty<byte>());

        HashSizeValue = outputBytes * 8;
        Initialize();
    }

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();
        _finalized = false;
        _squeezeOffset = 0;

        // KMAC(K, X, L, S) = cSHAKE(bytepad(encode_string(K), rate) || X || right_encode(L), L, "KMAC", S)

        // First absorb: bytepad(encode_string(N) || encode_string(S), rate) where N = "KMAC"
        AbsorbCShakePreamble();

        // Then absorb: bytepad(encode_string(K), rate)
        AbsorbKeyPad();
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
    /// Finalizes the MAC computation and squeezes output bytes.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    public void Squeeze(Span<byte> output)
    {
        if (!_finalized)
        {
            Span<byte> rightEncodedL = stackalloc byte[CShake128.EncodeBufferLength];

            // Append right_encode(L) where L is output length in bits
            if (!CShake128.TryRightEncode(rightEncodedL, _outputBytes * 8L, out int rightEncodedBytes))
            {
                throw new InvalidOperationException("Failed to encode output length.");
            }

            foreach (byte b in rightEncodedL.Slice(0, rightEncodedBytes))
            {
                _buffer[_bufferLength++] = b;
                if (_bufferLength == _rateBytes)
                {
                    _keccakCore.Absorb(_buffer, _rateBytes);
                    _bufferLength = 0;
                }
            }

            // cSHAKE domain separator (0x04 for customized)
            _buffer[_bufferLength++] = 0x04;

            while (_bufferLength < _rateBytes - 1)
            {
                _buffer[_bufferLength++] = 0x00;
            }

            _buffer[_rateBytes - 1] |= 0x80;

            _keccakCore.Absorb(_buffer, _rateBytes);
            _finalized = true;
            _squeezeOffset = 0;
        }

        _keccakCore.SqueezeXof(output, _rateBytes, ref _squeezeOffset);
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            ClearBuffer(_encodedKey);
        }
        base.Dispose(disposing);
    }

    private void AbsorbCShakePreamble()
    {
        // bytepad(encode_string(N) || encode_string(S), rate) where N = "KMAC"
        byte[] encodedN = _encodedKMacFunctionName;
        byte[] encodedS = _encodedCustomization;
        Span<byte> leftEncodedRate = stackalloc byte[CShake128.EncodeBufferLength];
        if (!CShake128.TryLeftEncode(leftEncodedRate, _rateBytes, out int leftEncodedBytes))
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

            for (int i = 0; i < paddedLength; i += _rateBytes)
            {
                _keccakCore.Absorb(paddedBuffer.Slice(i, _rateBytes), _rateBytes);
            }
        }
        finally
        {
            if (pooledBuffer is not null)
            {
                ArrayPool<byte>.Shared.Return(pooledBuffer);
            }
        }
    }

    private void AbsorbKeyPad()
    {
        // bytepad(encode_string(K), rate)
        byte[] encodedK = _encodedKey;
        Span<byte> leftEncodedRate = stackalloc byte[CShake128.EncodeBufferLength];
        if (!CShake128.TryLeftEncode(leftEncodedRate, _rateBytes, out int leftEncodedBytes))
        {
            throw new InvalidOperationException("Failed to encode left rate.");
        }

        int totalLen = leftEncodedBytes + encodedK.Length;
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

            encodedK.AsSpan(0, encodedK.Length).CopyTo(paddedBuffer.Slice(offset));

            for (int i = 0; i < paddedLength; i += _rateBytes)
            {
                _keccakCore.Absorb(paddedBuffer.Slice(i, _rateBytes), _rateBytes);
            }
        }
        finally
        {
            if (pooledBuffer is not null)
            {
                ArrayPool<byte>.Shared.Return(pooledBuffer);
            }
        }
    }
}
