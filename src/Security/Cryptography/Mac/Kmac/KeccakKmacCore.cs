// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;
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
public abstract class KeccakKmacCore : KeccakCore
{
    private static readonly byte[] KmacFunctionName = Encoding.ASCII.GetBytes("KMAC");

    private readonly int _outputBytes;
    private readonly byte[] _key;
    private readonly byte[] _customization;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="KeccakKmacCore"/> class.
    /// </summary>
    /// <param name="rateBytes">The rate in bytes for this variant.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization string S.</param>
    internal KeccakKmacCore(int rateBytes, SimdSupport simdSupport, byte[] key, int outputBytes, string customization)
        : this(rateBytes, simdSupport, key, outputBytes, Encoding.UTF8.GetBytes(customization ?? ""))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KeccakKmacCore"/> class.
    /// </summary>
    /// <param name="rateBytes">The rate in bytes for this variant.</param>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization bytes S.</param>
    internal KeccakKmacCore(int rateBytes, SimdSupport simdSupport, byte[] key, int outputBytes, byte[] customization)
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

        _key = (byte[])key.Clone();
        _outputBytes = outputBytes;
        _customization = customization ?? [];

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
        FinalizeAndSqueeze(destination);
        return true;
    }

    /// <summary>
    /// Finalizes the MAC computation and squeezes output bytes.
    /// </summary>
    /// <param name="output">The buffer to receive the output.</param>
    public void FinalizeAndSqueeze(Span<byte> output)
    {
        if (!_finalized)
        {
            // Append right_encode(L) where L is output length in bits
            byte[] rightEncodedL = CShake128.RightEncode(_outputBytes * 8L);
            foreach (byte b in rightEncodedL)
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
            ClearBuffer(_key);
        }
        base.Dispose(disposing);
    }

    private void AbsorbCShakePreamble()
    {
        // bytepad(encode_string(N) || encode_string(S), rate) where N = "KMAC"
        byte[] encodedN = CShake128.EncodeString(KmacFunctionName);
        byte[] encodedS = CShake128.EncodeString(_customization);
        byte[] leftEncodedRate = CShake128.LeftEncode(_rateBytes);

        int totalLen = leftEncodedRate.Length + encodedN.Length + encodedS.Length;
        int padLen = (_rateBytes - (totalLen % _rateBytes)) % _rateBytes;

        byte[] bytePadded = new byte[totalLen + padLen];
        int offset = 0;

        Array.Copy(leftEncodedRate, 0, bytePadded, offset, leftEncodedRate.Length);
        offset += leftEncodedRate.Length;

        Array.Copy(encodedN, 0, bytePadded, offset, encodedN.Length);
        offset += encodedN.Length;

        Array.Copy(encodedS, 0, bytePadded, offset, encodedS.Length);

        for (int i = 0; i < bytePadded.Length; i += _rateBytes)
        {
            _keccakCore.Absorb(bytePadded.AsSpan(i, _rateBytes), _rateBytes);
        }
    }

    private void AbsorbKeyPad()
    {
        // bytepad(encode_string(K), rate)
        byte[] encodedK = CShake128.EncodeString(_key);
        byte[] leftEncodedRate = CShake128.LeftEncode(_rateBytes);

        int totalLen = leftEncodedRate.Length + encodedK.Length;
        int padLen = (_rateBytes - (totalLen % _rateBytes)) % _rateBytes;

        byte[] bytePadded = new byte[totalLen + padLen];
        int offset = 0;

        Array.Copy(leftEncodedRate, 0, bytePadded, offset, leftEncodedRate.Length);
        offset += leftEncodedRate.Length;

        Array.Copy(encodedK, 0, bytePadded, offset, encodedK.Length);

        for (int i = 0; i < bytePadded.Length; i += _rateBytes)
        {
            _keccakCore.Absorb(bytePadded.AsSpan(i, _rateBytes), _rateBytes);
        }
    }
}
