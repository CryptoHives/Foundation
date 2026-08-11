// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Cipher;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using System;
using CH = CryptoHives.Foundation.Security.Cryptography;
using OS = System.Security.Cryptography;

/// <summary>
/// Wraps an OpenGost <see cref="OS.SymmetricAlgorithm"/> in CBC mode as a CryptoHives
/// <see cref="SymmetricCipher"/>.
/// </summary>
/// <remarks>
/// <para>
/// OpenGost exposes its ciphers through the framework's <see cref="OS.SymmetricAlgorithm"/>
/// contract rather than this library's, and the benchmark base requires the latter. Unlike
/// <see cref="OSAesCbcAdapter"/> this adapter goes through
/// <see cref="OS.ICryptoTransform"/> instead of the span-based one-shots, because those exist
/// only on <see cref="OS.Aes"/> and friends, not on the general base type.
/// </para>
/// <para>
/// Written against the base type rather than <c>Grasshopper</c> specifically, so OpenGost's other
/// ciphers can reuse it.
/// </para>
/// </remarks>
internal sealed class OpenGostCbcAdapter : SymmetricCipher
{
    private readonly Func<OS.SymmetricAlgorithm> _factory;
    private readonly string _algorithmName;
    private readonly int _blockSizeBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenGostCbcAdapter"/> class.
    /// </summary>
    /// <param name="factory">Creates the underlying OpenGost algorithm.</param>
    /// <param name="algorithmName">Display name, without the source suffix.</param>
    /// <param name="keySizeBytes">Key size in bytes.</param>
    /// <param name="blockSizeBytes">Block size in bytes.</param>
    public OpenGostCbcAdapter(
        Func<OS.SymmetricAlgorithm> factory,
        string algorithmName,
        int keySizeBytes,
        int blockSizeBytes)
    {
        _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        _algorithmName = $"{algorithmName} (OpenGost)";
        _blockSizeBytes = blockSizeBytes;

        BlockSizeValue = blockSizeBytes * 8;
        KeySizeValue = keySizeBytes * 8;
        LegalKeySizesValue = [new OS.KeySizes(keySizeBytes * 8, keySizeBytes * 8, 0)];
        Mode = CH.Cipher.CipherMode.CBC;
        Padding = CH.Cipher.PaddingMode.PKCS7;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _algorithmName;

    /// <inheritdoc/>
    public override int IVSize => _blockSizeBytes;

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
        => new OpenGostCbcTransform(_factory(), key, iv, forEncryption: true, _blockSizeBytes);

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
        => new OpenGostCbcTransform(_factory(), key, iv, forEncryption: false, _blockSizeBytes);
}

/// <summary>
/// Wraps an OpenGost CBC transform as a CryptoHives <see cref="ICipherTransform"/>.
/// </summary>
internal sealed class OpenGostCbcTransform : ICipherTransform
{
    private readonly OS.SymmetricAlgorithm _algorithm;
    private readonly bool _forEncryption;
    private readonly int _blockSize;
    private readonly byte[] _key;
    private readonly byte[] _iv;
    private OS.ICryptoTransform? _transform;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenGostCbcTransform"/> class.
    /// </summary>
    public OpenGostCbcTransform(
        OS.SymmetricAlgorithm algorithm,
        ReadOnlySpan<byte> key,
        ReadOnlySpan<byte> iv,
        bool forEncryption,
        int blockSize)
    {
        _algorithm = algorithm;
        _forEncryption = forEncryption;
        _blockSize = blockSize;

        _key = key.ToArray();
        _iv = iv.IsEmpty ? new byte[blockSize] : iv.ToArray();

        _algorithm.Mode = OS.CipherMode.CBC;
        _algorithm.Padding = OS.PaddingMode.PKCS7;
        _algorithm.Key = _key;
        _algorithm.IV = _iv;

        // Held across calls when the implementation allows it, so the key schedule is paid once
        // rather than per measured operation - the same treatment the BouncyCastle adapter gives
        // its engine. Implementations that forbid reuse get a fresh transform each call instead.
        OS.ICryptoTransform created = Create();
        _transform = created.CanReuseTransform ? created : null;
        if (_transform is null)
        {
            created.Dispose();
        }
    }

    /// <inheritdoc/>
    public int BlockSize => _blockSize;

    /// <inheritdoc/>
    int OS.ICryptoTransform.InputBlockSize => _blockSize;

    /// <inheritdoc/>
    int OS.ICryptoTransform.OutputBlockSize => _blockSize;

    /// <inheritdoc/>
    bool OS.ICryptoTransform.CanTransformMultipleBlocks => true;

    /// <inheritdoc/>
    bool OS.ICryptoTransform.CanReuseTransform => true;

    /// <inheritdoc/>
    public int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        OS.ICryptoTransform transform = _transform ?? Create();

        try
        {
            byte[] result = transform.TransformFinalBlock(input.ToArray(), 0, input.Length);
            result.CopyTo(output);
            return result.Length;
        }
        finally
        {
            if (_transform is null)
            {
                transform.Dispose();
            }
        }
    }

    /// <inheritdoc/>
    int OS.ICryptoTransform.TransformBlock(
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
    byte[] OS.ICryptoTransform.TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
    {
        byte[] output = new byte[inputCount + _blockSize];
        int length = TransformBlock(
            inputBuffer.AsSpan(inputOffset, inputCount),
            output.AsSpan());
        if (length != output.Length)
        {
            Array.Resize(ref output, length);
        }

        return output;
    }

    /// <inheritdoc/>
    public void Reset()
    {
        _transform?.Dispose();
        OS.ICryptoTransform created = Create();
        _transform = created.CanReuseTransform ? created : null;
        if (_transform is null)
        {
            created.Dispose();
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _transform?.Dispose();
        _transform = null;
        _algorithm.Dispose();
        Array.Clear(_key, 0, _key.Length);
        Array.Clear(_iv, 0, _iv.Length);
    }

    private OS.ICryptoTransform Create()
        => _forEncryption ? _algorithm.CreateEncryptor() : _algorithm.CreateDecryptor();
}
