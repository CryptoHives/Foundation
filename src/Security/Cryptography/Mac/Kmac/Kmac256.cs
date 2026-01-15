// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Mac;

using System;
using System.Text;
using CryptoHives.Foundation.Security.Cryptography.Hash;

/// <summary>
/// Computes the KMAC256 (Keccak Message Authentication Code) for the input data.
/// </summary>
/// <remarks>
/// <para>
/// KMAC256 is a MAC function based on Keccak (cSHAKE256) defined in NIST SP 800-185.
/// It provides 256-bit security strength and supports variable-length output.
/// </para>
/// <para>
/// KMAC can be used as both a traditional MAC (fixed output length) or as a
/// pseudorandom function (XOF mode with arbitrary output length).
/// </para>
/// </remarks>
public sealed class Kmac256 : KeccakCore
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 512;

    /// <summary>
    /// The rate in bytes (1088 bits for KMAC256).
    /// </summary>
    public const int RateBytes = 136;

    private static readonly byte[] KmacFunctionName = Encoding.ASCII.GetBytes("KMAC");

    // Removed: _state, _buffer, _bufferLength
    private readonly int _outputBytes;
    private readonly byte[] _key;
    private readonly byte[] _customization;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="Kmac256"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization string S.</param>
    public Kmac256(byte[] key, int outputBytes = DefaultOutputBits / 8, string customization = "")
        : this(SimdSupport.Default, key, outputBytes, Encoding.UTF8.GetBytes(customization ?? ""))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Kmac256"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization bytes S.</param>
    public Kmac256(byte[] key, int outputBytes, byte[] customization)
        : this(SimdSupport.Default, key, outputBytes, customization)
    {
    }

    internal Kmac256(SimdSupport simdSupport, byte[] key, int outputBytes, byte[] customization)
        : base(RateBytes, simdSupport)
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
    public override string AlgorithmName => "KMAC256";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="Kmac256"/> class.
    /// </summary>
    /// <param name="key">The secret key.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="customization">Optional customization string S.</param>
    /// <returns>A new KMAC256 instance.</returns>
    public static Kmac256 Create(byte[] key, int outputBytes = DefaultOutputBits / 8, string customization = "")
        => new(key, outputBytes, customization);

    internal static Kmac256 Create(SimdSupport simdSupport, byte[] key, int outputBytes, string customization)
        => new(simdSupport, key, outputBytes, Encoding.UTF8.GetBytes(customization ?? ""));

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

        int offset = 0;

        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(RateBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == RateBytes)
            {
                _keccakCore.Absorb(_buffer, RateBytes);
                _bufferLength = 0;
            }
        }

        while (offset + RateBytes <= source.Length)
        {
            _keccakCore.Absorb(source.Slice(offset, RateBytes), RateBytes);
            offset += RateBytes;
        }

        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += source.Length - offset;
        }
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
                if (_bufferLength == RateBytes)
                {
                    _keccakCore.Absorb(_buffer, RateBytes);
                    _bufferLength = 0;
                }
            }

            // cSHAKE domain separator (0x04 for customized)
            _buffer[_bufferLength++] = 0x04;

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
        byte[] leftEncodedRate = CShake128.LeftEncode(RateBytes);

        int totalLen = leftEncodedRate.Length + encodedN.Length + encodedS.Length;
        int padLen = (RateBytes - (totalLen % RateBytes)) % RateBytes;

        byte[] bytePadded = new byte[totalLen + padLen];
        int offset = 0;

        Array.Copy(leftEncodedRate, 0, bytePadded, offset, leftEncodedRate.Length);
        offset += leftEncodedRate.Length;

        Array.Copy(encodedN, 0, bytePadded, offset, encodedN.Length);
        offset += encodedN.Length;

        Array.Copy(encodedS, 0, bytePadded, offset, encodedS.Length);

        for (int i = 0; i < bytePadded.Length; i += RateBytes)
        {
            _keccakCore.Absorb(bytePadded.AsSpan(i, RateBytes), RateBytes);
        }
    }

    private void AbsorbKeyPad()
    {
        // bytepad(encode_string(K), rate)
        byte[] encodedK = CShake128.EncodeString(_key);
        byte[] leftEncodedRate = CShake128.LeftEncode(RateBytes);

        int totalLen = leftEncodedRate.Length + encodedK.Length;
        int padLen = (RateBytes - (totalLen % RateBytes)) % RateBytes;

        byte[] bytePadded = new byte[totalLen + padLen];
        int offset = 0;

        Array.Copy(leftEncodedRate, 0, bytePadded, offset, leftEncodedRate.Length);
        offset += leftEncodedRate.Length;

        Array.Copy(encodedK, 0, bytePadded, offset, encodedK.Length);

        for (int i = 0; i < bytePadded.Length; i += RateBytes)
        {
            _keccakCore.Absorb(bytePadded.AsSpan(i, RateBytes), RateBytes);
        }
    }
}
