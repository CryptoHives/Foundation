// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Cipher;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;

/// <summary>
/// Wraps a BouncyCastle block cipher as a CryptoHives <see cref="SymmetricCipher"/>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter allows BouncyCastle symmetric cipher implementations (AES-CBC, ChaCha20)
/// to be used interchangeably with CryptoHives implementations in tests and benchmarks.
/// </para>
/// </remarks>
internal sealed class BouncyCastleCipherAdapter : SymmetricCipher
{
    private readonly Func<IBufferedCipher> _cipherFactory;
    private readonly string _algorithmName;
    private readonly int _ivSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleCipherAdapter"/> class.
    /// </summary>
    /// <param name="algorithmName">Display name for this cipher.</param>
    /// <param name="cipherFactory">Factory that creates a fresh BouncyCastle buffered cipher.</param>
    /// <param name="keySizeBits">Key size in bits.</param>
    /// <param name="blockSizeBits">Block size in bits.</param>
    /// <param name="ivSizeBytes">IV/nonce size in bytes.</param>
    public BouncyCastleCipherAdapter(
        string algorithmName,
        Func<IBufferedCipher> cipherFactory,
        int keySizeBits,
        int blockSizeBits,
        int ivSizeBytes)
    {
        _algorithmName = algorithmName;
        _cipherFactory = cipherFactory;
        _ivSize = ivSizeBytes;
        BlockSizeValue = blockSizeBits;
        KeySizeValue = keySizeBits;
        LegalKeySizesValue = [new System.Security.Cryptography.KeySizes(keySizeBits, keySizeBits, 0)];
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _algorithmName;

    /// <inheritdoc/>
    public override int IVSize => _ivSize;

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(byte[] key, byte[] iv)
        => new BouncyCastleCipherTransform(_cipherFactory(), key, iv, forEncryption: true, initialCounter: InitialCounter);

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(byte[] key, byte[] iv)
        => new BouncyCastleCipherTransform(_cipherFactory(), key, iv, forEncryption: false, initialCounter: InitialCounter);

    /// <summary>
    /// Creates an AES-CBC adapter with PKCS7 padding.
    /// </summary>
    /// <param name="keySizeBytes">Key size in bytes (16, 24, or 32).</param>
    /// <returns>A new <see cref="BouncyCastleCipherAdapter"/> instance.</returns>
    public static BouncyCastleCipherAdapter CreateAesCbc(int keySizeBytes)
    {
        var adapter = new BouncyCastleCipherAdapter(
            $"AES-{keySizeBytes * 8}-CBC (BouncyCastle)",
            () => new PaddedBufferedBlockCipher(
                new CbcBlockCipher(new AesEngine()),
                new Pkcs7Padding()),
            keySizeBits: keySizeBytes * 8,
            blockSizeBits: 128,
            ivSizeBytes: 16);
        adapter.Mode = CipherMode.CBC;
        adapter.Padding = PaddingMode.PKCS7;
        return adapter;
    }

    /// <summary>
    /// Creates a ChaCha20 stream cipher adapter.
    /// </summary>
    /// <returns>A new <see cref="BouncyCastleCipherAdapter"/> instance.</returns>
    public static BouncyCastleCipherAdapter CreateChaCha20()
    {
        var adapter = new BouncyCastleCipherAdapter(
            "ChaCha20 (BouncyCastle)",
            () => new BufferedStreamCipher(new ChaCha7539Engine()),
            keySizeBits: 256,
            blockSizeBits: 8,
            ivSizeBytes: 12);
        adapter.Mode = CipherMode.Stream;
        adapter.Padding = PaddingMode.None;
        return adapter;
    }
}

/// <summary>
/// Wraps a BouncyCastle <see cref="IBufferedCipher"/> as a CryptoHives <see cref="ICipherTransform"/>.
/// </summary>
/// <remarks>
/// <para>
/// On .NET 8+, uses BouncyCastle's span-based <c>ProcessBytes</c> and <c>DoFinal</c>
/// overloads to pass caller buffers directly — zero intermediate copies.
/// </para>
/// <para>
/// On .NET Framework, falls back to pre-allocated reusable byte arrays to minimize
/// per-call allocations.
/// </para>
/// </remarks>
internal sealed class BouncyCastleCipherTransform : ICipherTransform
{
    private readonly IBufferedCipher _cipher;
    private readonly byte[] _key;
    private readonly byte[] _iv;
    private readonly bool _forEncryption;
    private readonly ICipherParameters _parameters;
#if !NET8_0_OR_GREATER
    private byte[] _inputBuffer;
    private byte[] _outputBuffer;
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleCipherTransform"/> class.
    /// </summary>
    public BouncyCastleCipherTransform(IBufferedCipher cipher, byte[] key, byte[] iv, bool forEncryption, uint initialCounter = 0)
    {
        _cipher = cipher;
        _key = (byte[])key.Clone();
        _iv = iv != null ? (byte[])iv.Clone() : Array.Empty<byte>();
        _forEncryption = forEncryption;
#if !NET8_0_OR_GREATER
        _inputBuffer = Array.Empty<byte>();
        _outputBuffer = Array.Empty<byte>();
#endif

        var keyParam = new KeyParameter(_key);
        _parameters = _iv.Length > 0
            ? new ParametersWithIV(keyParam, _iv)
            : keyParam;

        _cipher.Init(_forEncryption, _parameters);

        // Advance the stream cipher past the first initialCounter blocks (64 bytes each).
        if (initialCounter > 0)
        {
            byte[] discard = new byte[64 * initialCounter];
            _cipher.ProcessBytes(discard, 0, discard.Length, discard, 0);
        }
    }

    /// <inheritdoc/>
    public int BlockSize => _cipher.GetBlockSize() > 0 ? _cipher.GetBlockSize() : 1;

    /// <inheritdoc/>
    int System.Security.Cryptography.ICryptoTransform.InputBlockSize => BlockSize;

    /// <inheritdoc/>
    int System.Security.Cryptography.ICryptoTransform.OutputBlockSize => BlockSize;

    /// <inheritdoc/>
    bool System.Security.Cryptography.ICryptoTransform.CanTransformMultipleBlocks => true;

    /// <inheritdoc/>
    bool System.Security.Cryptography.ICryptoTransform.CanReuseTransform => true;

    /// <inheritdoc/>
    public int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
#if NET8_0_OR_GREATER
        int len = _cipher.ProcessBytes(input, output);
        len += _cipher.DoFinal(output.Slice(len));
        return len;
#else
        EnsureBufferSize(ref _inputBuffer, input.Length);
        input.CopyTo(_inputBuffer);

        int outputSize = _cipher.GetOutputSize(input.Length);
        EnsureBufferSize(ref _outputBuffer, outputSize);

        int len = _cipher.ProcessBytes(_inputBuffer, 0, input.Length, _outputBuffer, 0);
        len += _cipher.DoFinal(_outputBuffer, len);
        _outputBuffer.AsSpan(0, len).CopyTo(output);
        return len;
#endif
    }

    /// <inheritdoc/>
    int System.Security.Cryptography.ICryptoTransform.TransformBlock(
        byte[] inputBuffer, int inputOffset, int inputCount,
        byte[] outputBuffer, int outputOffset)
    {
        return TransformBlock(
            inputBuffer.AsSpan(inputOffset, inputCount),
            outputBuffer.AsSpan(outputOffset));
    }

    /// <inheritdoc/>
    public int TransformFinalBlock(ReadOnlySpan<byte> input, Span<byte> output)
        => TransformBlock(input, output);

    /// <inheritdoc/>
    byte[] System.Security.Cryptography.ICryptoTransform.TransformFinalBlock(
        byte[] inputBuffer, int inputOffset, int inputCount)
    {
        byte[] output = new byte[_cipher.GetOutputSize(inputCount)];
        int len = TransformBlock(
            inputBuffer.AsSpan(inputOffset, inputCount),
            output.AsSpan());
        if (len != output.Length)
            Array.Resize(ref output, len);
        return output;
    }

    /// <inheritdoc/>
    public void Reset()
    {
        _cipher.Init(_forEncryption, _parameters);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _cipher.Reset();
        Array.Clear(_key, 0, _key.Length);
        if (_iv.Length > 0) Array.Clear(_iv, 0, _iv.Length);
    }

#if !NET8_0_OR_GREATER
    private static void EnsureBufferSize(ref byte[] buffer, int requiredSize)
    {
        if (buffer.Length < requiredSize)
            buffer = new byte[requiredSize];
    }
#endif
}

