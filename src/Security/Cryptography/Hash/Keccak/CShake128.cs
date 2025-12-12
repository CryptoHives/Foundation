// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Text;

/// <summary>
/// Computes a customizable SHAKE128 (cSHAKE128) output with a clean-room implementation.
/// </summary>
/// <remarks>
/// <para>
/// cSHAKE128 is a customizable variant of SHAKE128 defined in NIST SP 800-185.
/// It supports function name (N) and customization string (S) parameters for domain separation.
/// </para>
/// <para>
/// When both N and S are empty, cSHAKE128 is equivalent to SHAKE128.
/// </para>
/// </remarks>
public sealed class CShake128 : HashAlgorithm
{
    /// <summary>
    /// The default output size in bits.
    /// </summary>
    public const int DefaultOutputBits = 256;

    /// <summary>
    /// The rate in bytes (1344 bits for cSHAKE128).
    /// </summary>
    public const int RateBytes = 168;

    /// <summary>
    /// The capacity in bytes (256 bits for cSHAKE128).
    /// </summary>
    public const int CapacityBytes = 32;

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
    /// Initializes a new instance of the <see cref="CShake128"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name string N (for NIST-defined functions).</param>
    /// <param name="customization">The customization string S.</param>
    public CShake128(int outputBytes = DefaultOutputBits / 8, string functionName = "", string customization = "")
        : this(outputBytes, Encoding.UTF8.GetBytes(functionName ?? ""), Encoding.UTF8.GetBytes(customization ?? ""))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CShake128"/> class with byte array parameters.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name bytes N.</param>
    /// <param name="customization">The customization bytes S.</param>
    public CShake128(int outputBytes, byte[] functionName, byte[] customization)
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
    public override string AlgorithmName => "cSHAKE128";

    /// <inheritdoc/>
    public override int BlockSize => RateBytes;

    /// <summary>
    /// Creates a new instance of the <see cref="CShake128"/> class with default parameters.
    /// </summary>
    public static new CShake128 Create() => new();

    /// <summary>
    /// Creates a new instance of the <see cref="CShake128"/> class with specified parameters.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name N (for NIST-defined functions).</param>
    /// <param name="customization">The customization string S (user-defined).</param>
    public static CShake128 Create(int outputBytes, string functionName = "", string customization = "")
        => new(outputBytes, functionName, customization);

    /// <inheritdoc/>
    public override void Initialize()
    {
        Array.Clear(_state, 0, _state.Length);
        ClearBuffer(_buffer);
        _bufferLength = 0;
        _finalized = false;
        _squeezeOffset = 0;

        // If customized, absorb bytepad(encode_string(N) || encode_string(S), rate)
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
            // Domain separator: 0x04 for cSHAKE (when customized), 0x1F for SHAKE
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
        // bytepad(encode_string(N) || encode_string(S), rate)
        byte[] encodedN = EncodeString(_functionName);
        byte[] encodedS = EncodeString(_customization);

        // left_encode(rate)
        byte[] leftEncodedRate = LeftEncode(RateBytes);

        int totalLen = leftEncodedRate.Length + encodedN.Length + encodedS.Length;
        int padLen = (RateBytes - (totalLen % RateBytes)) % RateBytes;

        byte[] bytePadded = new byte[totalLen + padLen];
        int offset = 0;

        Array.Copy(leftEncodedRate, 0, bytePadded, offset, leftEncodedRate.Length);
        offset += leftEncodedRate.Length;

        Array.Copy(encodedN, 0, bytePadded, offset, encodedN.Length);
        offset += encodedN.Length;

        Array.Copy(encodedS, 0, bytePadded, offset, encodedS.Length);

        // Absorb the bytepad data
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

    /// <summary>
    /// Encodes a byte string with its length prefix (encode_string from SP 800-185).
    /// </summary>
    /// <param name="s">The byte string to encode.</param>
    /// <returns>The encoded byte string.</returns>
    internal static byte[] EncodeString(byte[] s)
    {
        byte[] lenEncoded = LeftEncode(s.Length * 8); // Length in bits
        byte[] result = new byte[lenEncoded.Length + s.Length];
        Array.Copy(lenEncoded, 0, result, 0, lenEncoded.Length);
        Array.Copy(s, 0, result, lenEncoded.Length, s.Length);
        return result;
    }

    /// <summary>
    /// Left-encodes an integer (left_encode from SP 800-185).
    /// </summary>
    /// <param name="x">The value to encode.</param>
    /// <returns>The encoded bytes.</returns>
    internal static byte[] LeftEncode(long x)
    {
        if (x == 0)
        {
            return [1, 0];
        }

        int n = 0;
        long temp = x;
        while (temp > 0)
        {
            n++;
            temp >>= 8;
        }

        byte[] result = new byte[n + 1];
        result[0] = (byte)n;

        for (int i = n; i >= 1; i--)
        {
            result[i] = (byte)x;
            x >>= 8;
        }

        return result;
    }

    /// <summary>
    /// Right-encodes an integer (right_encode from SP 800-185).
    /// </summary>
    /// <param name="x">The value to encode.</param>
    /// <returns>The encoded bytes.</returns>
    internal static byte[] RightEncode(long x)
    {
        if (x == 0)
        {
            return [0, 1];
        }

        int n = 0;
        long temp = x;
        while (temp > 0)
        {
            n++;
            temp >>= 8;
        }

        byte[] result = new byte[n + 1];
        result[n] = (byte)n;

        for (int i = n - 1; i >= 0; i--)
        {
            result[i] = (byte)x;
            x >>= 8;
        }

        return result;
    }
}
