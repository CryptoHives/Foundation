// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Text;

/// <summary>
/// Computes a customizable SHAKE256 (cSHAKE256) output with a clean-room implementation.
/// </summary>
/// <remarks>
/// <para>
/// cSHAKE256 is a customizable variant of SHAKE256 defined in NIST SP 800-185.
/// It supports function name (N) and customization string (S) parameters for domain separation.
/// </para>
/// <para>
/// When both N and S are empty, cSHAKE256 is equivalent to SHAKE256.
/// </para>
/// </remarks>
public sealed class CShake256 : HashAlgorithm
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

    private readonly ulong[] _state;
    private readonly byte[] _buffer;
    private readonly int _outputBytes;
    private readonly byte[] _functionName;
    private readonly byte[] _customization;
    private readonly bool _isCustomized;
    private int _bufferLength;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="CShake256"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name string N (for NIST-defined functions).</param>
    /// <param name="customization">The customization string S.</param>
    public CShake256(int outputBytes = DefaultOutputBits / 8, string functionName = "", string customization = "")
        : this(outputBytes, Encoding.UTF8.GetBytes(functionName ?? ""), Encoding.UTF8.GetBytes(customization ?? ""))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CShake256"/> class with byte array parameters.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name bytes N.</param>
    /// <param name="customization">The customization bytes S.</param>
    public CShake256(int outputBytes, byte[] functionName, byte[] customization)
    {
        if (outputBytes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");
        }

        _outputBytes = outputBytes;
        _functionName = functionName ?? [];
        _customization = customization ?? [];
        _isCustomized = _functionName.Length > 0 || _customization.Length > 0;

        HashSizeValue = outputBytes * 8;
        _state = new ulong[KeccakCore.StateSize];
        _buffer = new byte[RateBytes];
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
    /// Creates a new instance of the <see cref="CShake256"/> class with specified parameters.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name N (for NIST-defined functions).</param>
    /// <param name="customization">The customization string S (user-defined).</param>
    public static CShake256 Create(int outputBytes, string functionName = "", string customization = "")
        => new(outputBytes, functionName, customization);

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Clear(_state, 0, _state.Length);
        ClearBuffer(_buffer);
        _bufferLength = 0;
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

        int offset = 0;

        if (_bufferLength > 0)
        {
            int toCopy = Math.Min(RateBytes - _bufferLength, source.Length);
            source.Slice(0, toCopy).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += toCopy;
            offset += toCopy;

            if (_bufferLength == RateBytes)
            {
                KeccakCore.Absorb(_state, _buffer, RateBytes);
                _bufferLength = 0;
            }
        }

        while (offset + RateBytes <= source.Length)
        {
            KeccakCore.Absorb(_state, source.Slice(offset, RateBytes), RateBytes);
            offset += RateBytes;
        }

        if (offset < source.Length)
        {
            source.Slice(offset).CopyTo(_buffer.AsSpan(_bufferLength));
            _bufferLength += source.Length - offset;
        }
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        byte[] output = new byte[_outputBytes];
        Squeeze(output);
        return output;
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

            KeccakCore.Absorb(_state, _buffer, RateBytes);
            _finalized = true;
            _squeezeOffset = 0;
        }

        KeccakCore.SqueezeXof(_state, output, RateBytes, ref _squeezeOffset);
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Array.Clear(_state, 0, _state.Length);
            ClearBuffer(_buffer);
        }
        base.Dispose(disposing);
    }

    private void AbsorbBytePad()
    {
        byte[] encodedN = CShake128.EncodeString(_functionName);
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
            int blockLen = Math.Min(RateBytes, bytePadded.Length - i);
            if (blockLen == RateBytes)
            {
                KeccakCore.Absorb(_state, bytePadded.AsSpan(i, RateBytes), RateBytes);
            }
            else
            {
                bytePadded.AsSpan(i, blockLen).CopyTo(_buffer.AsSpan(_bufferLength));
                _bufferLength += blockLen;
            }
        }
    }
}
