// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Hash;

using System;
using System.Text;

/// <summary>
/// Computes a customizable SHAKE128 (cSHAKE128) output.
/// </summary>
/// <remarks>
/// <para>
/// This is a fully managed implementation of cSHAKE128 based on the Keccak sponge
/// construction. It does not rely on OS or hardware cryptographic APIs, ensuring
/// deterministic behavior across all platforms and runtimes.
/// </para>
/// <para>
/// cSHAKE128 is a customizable variant of SHAKE128 defined in NIST SP 800-185.
/// It supports function name (N) and customization string (S) parameters for domain separation.
/// </para>
/// <para>
/// When both N and S are empty, cSHAKE128 is equivalent to SHAKE128.
/// </para>
/// </remarks>
public sealed class CShake128 : KeccakCore
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

    private readonly int _outputBytes;
    private readonly byte[] _functionName;
    private readonly byte[] _customization;
    private readonly bool _isCustomized;
    private bool _finalized;
    private int _squeezeOffset;

    /// <summary>
    /// Initializes a new instance of the <see cref="CShake128"/> class.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name string N (for NIST-defined functions).</param>
    /// <param name="customization">The customization string S.</param>
    public CShake128(int outputBytes = DefaultOutputBits / 8, string? functionName = null, string? customization = null)
        : this(SimdSupport.KeccakDefault, outputBytes, functionName == null ? [] : Encoding.UTF8.GetBytes(functionName), customization == null ? [] : Encoding.UTF8.GetBytes(customization))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CShake128"/> class with byte array parameters.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name bytes N.</param>
    /// <param name="customization">The customization bytes S.</param>
    public CShake128(int outputBytes, byte[] functionName, byte[] customization)
        : this(SimdSupport.KeccakDefault, outputBytes, functionName, customization)
    {
    }

    internal CShake128(SimdSupport simdSupport, int outputBytes, byte[]? functionName, byte[]? customization)
        : base(RateBytes, simdSupport)
    {
        if (outputBytes <= 0) throw new ArgumentOutOfRangeException(nameof(outputBytes), "Output size must be positive.");

        _outputBytes = outputBytes;
        _functionName = functionName ?? [];
        _customization = customization ?? [];
        _isCustomized = _functionName.Length > 0 || _customization.Length > 0;

        HashSizeValue = outputBytes * 8;
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
    /// Creates a new instance of the CShake128 hash function with the specified output length, function name, and
    /// customization string.
    /// </summary>
    /// <param name="outputBytes">The desired length, in bytes, of the hash output. Must be a positive integer.</param>
    /// <param name="functionName">An optional function name as a byte array, used to domain-separate the hash function. Can be null if no function
    /// name is required.</param>
    /// <param name="customization">An optional customization string as a byte array, used to further parameterize the hash function. Can be null if
    /// no customization is required.</param>
    /// <returns>A new CShake128 instance configured with the specified output length, function name, and customization string.</returns>
    public static CShake128 Create(int outputBytes, byte[]? functionName = null, byte[]? customization = null)
        => new(SimdSupport.KeccakDefault, outputBytes, functionName, customization);

    internal static CShake128 Create(SimdSupport simdSupport, int outputBytes = DefaultOutputBits / 8, byte[]? functionName = null, byte[]? customization = null)
        => new(simdSupport, outputBytes, functionName, customization);

    /// <summary>
    /// Creates a new instance of the <see cref="CShake128"/> class with specified parameters.
    /// </summary>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    /// <param name="functionName">The function name N (for NIST-defined functions).</param>
    /// <param name="customization">The customization string S (user-defined).</param>
    public static CShake128 Create(int outputBytes, string functionName, string? customization = null)
        => new(outputBytes, functionName, customization);

    internal static CShake128 Create(SimdSupport simdSupport, int outputBytes)
        => new(simdSupport, outputBytes, [], []);

    internal static CShake128 Create(SimdSupport simdSupport, int outputBytes, string functionName, string? customization = null)
        => new(simdSupport, outputBytes, functionName == null ? [] : Encoding.UTF8.GetBytes(functionName), customization == null ? [] : Encoding.UTF8.GetBytes(customization));

    /// <inheritdoc/>
    public override void Initialize()
    {
        base.Initialize();
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
        if (_finalized) throw new InvalidOperationException("Cannot add data after finalization.");
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
            // Domain separator: 0x04 for cSHAKE (when customized), 0x1F for SHAKE
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
                _keccakCore.Absorb(bytePadded.AsSpan(i, RateBytes), RateBytes);
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
        // Length in bits - use long to avoid overflow
        long lengthInBits = (long)s.Length * 8L;
        byte[] lenEncoded = LeftEncode(lengthInBits);
        byte[] result = new byte[lenEncoded.Length + s.Length];
        Array.Copy(lenEncoded, 0, result, 0, lenEncoded.Length);
        Array.Copy(s, 0, result, lenEncoded.Length, s.Length);
        return result;
    }

    /// <summary>
    /// Left-encodes an integer (left_encode from SP 800-185).
    /// </summary>
    /// <param name="x">The value to encode (must be non-negative).</param>
    /// <returns>The encoded bytes.</returns>
    internal static byte[] LeftEncode(long x)
    {
        if (x < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(x), "Value must be non-negative.");
        }

        if (x == 0)
        {
            return [1, 0];
        }

        // Count how many bytes we need
        int n = 0;
        long temp = x;
        while (temp > 0)
        {
            n++;
            temp >>= 8;
        }

        byte[] result = new byte[n + 1];
        result[0] = unchecked((byte)n);

        // Fill bytes in big-endian order
        for (int i = n; i >= 1; i--)
        {
            result[i] = unchecked((byte)x);
            x >>= 8;
        }

        return result;
    }

    /// <summary>
    /// Right-encodes an integer (right_encode from SP 800-185).
    /// </summary>
    /// <param name="x">The value to encode (must be non-negative).</param>
    /// <returns>The encoded bytes.</returns>
    internal static byte[] RightEncode(long x)
    {
        if (x < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(x), "Value must be non-negative.");
        }

        if (x == 0)
        {
            return [0, 1];
        }

        // Count how many bytes we need
        int n = 0;
        long temp = x;
        while (temp > 0)
        {
            n++;
            temp >>= 8;
        }

        byte[] result = new byte[n + 1];
        result[n] = unchecked((byte)n);

        // Fill bytes in big-endian order
        for (int i = n - 1; i >= 0; i--)
        {
            result[i] = unchecked((byte)x);
            x >>= 8;
        }

        return result;
    }
}
