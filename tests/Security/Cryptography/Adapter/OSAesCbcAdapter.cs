// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

namespace Cryptography.Tests.Adapter;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using System;
using System.Security.Cryptography;
using OSAes = System.Security.Cryptography.Aes;
using CHCipherMode = CryptoHives.Foundation.Security.Cryptography.Cipher.CipherMode;
using CHPaddingMode = CryptoHives.Foundation.Security.Cryptography.Cipher.PaddingMode;

/// <summary>
/// Wraps .NET's OS-provided AES-CBC as a CryptoHives <see cref="SymmetricCipher"/>.
/// </summary>
/// <remarks>
/// <para>
/// Available in .NET 8.0 and later. Uses OS cryptographic primitives for
/// hardware-accelerated AES-CBC operations.
/// </para>
/// </remarks>
internal sealed class OSAesCbcAdapter : SymmetricCipher
{
    private readonly string _algorithmName;

    /// <summary>
    /// Initializes a new instance of the <see cref="OSAesCbcAdapter"/> class.
    /// </summary>
    /// <param name="keySizeBytes">Key size in bytes (16, 24, or 32).</param>
    public OSAesCbcAdapter(int keySizeBytes)
    {
        _algorithmName = $"AES-{keySizeBytes * 8}-CBC (OS)";
        BlockSizeValue = 128;
        KeySizeValue = keySizeBytes * 8;
        LegalKeySizesValue = [new KeySizes(keySizeBytes * 8, keySizeBytes * 8, 0)];
        Mode = CHCipherMode.CBC;
        Padding = CHPaddingMode.PKCS7;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => _algorithmName;

    /// <inheritdoc/>
    public override int IVSize => 16;

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(byte[] key, byte[] iv)
        => new OSAesCbcTransform(key, iv, forEncryption: true);

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(byte[] key, byte[] iv)
        => new OSAesCbcTransform(key, iv, forEncryption: false);
}

/// <summary>
/// Wraps .NET's OS-provided AES-CBC transform as a CryptoHives <see cref="ICipherTransform"/>.
/// </summary>
internal sealed class OSAesCbcTransform : ICipherTransform
{
    private readonly OSAes _aes;
    private readonly byte[] _key;
    private readonly byte[] _iv;
    private readonly bool _forEncryption;
    private ICryptoTransform _transform;

    /// <summary>
    /// Initializes a new instance of the <see cref="OSAesCbcTransform"/> class.
    /// </summary>
    public OSAesCbcTransform(byte[] key, byte[] iv, bool forEncryption)
    {
        _key = (byte[])key.Clone();
        _iv = (byte[])iv.Clone();
        _forEncryption = forEncryption;

        _aes = OSAes.Create();
        _aes.Mode = System.Security.Cryptography.CipherMode.CBC;
        _aes.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
        _aes.Key = _key;
        _aes.IV = _iv;

        _transform = CreateTransform();
    }

    /// <inheritdoc/>
    public int BlockSize => 16;

    /// <inheritdoc/>
    int ICryptoTransform.InputBlockSize => BlockSize;

    /// <inheritdoc/>
    int ICryptoTransform.OutputBlockSize => BlockSize;

    /// <inheritdoc/>
    bool ICryptoTransform.CanTransformMultipleBlocks => true;

    /// <inheritdoc/>
    bool ICryptoTransform.CanReuseTransform => true;

    /// <inheritdoc/>
    public int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        byte[] inputArray = input.ToArray();
        byte[] result = _transform.TransformFinalBlock(inputArray, 0, inputArray.Length);
        result.AsSpan().CopyTo(output);

        // Re-create transform (TransformFinalBlock finalizes state)
        _transform.Dispose();
        _transform = CreateTransform();

        return result.Length;
    }

    /// <inheritdoc/>
    int ICryptoTransform.TransformBlock(
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
    byte[] ICryptoTransform.TransformFinalBlock(
        byte[] inputBuffer, int inputOffset, int inputCount)
    {
        byte[] output = new byte[inputCount + BlockSize];
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
        _transform.Dispose();
        _transform = CreateTransform();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        _transform.Dispose();
        _aes.Dispose();
        Array.Clear(_key, 0, _key.Length);
        Array.Clear(_iv, 0, _iv.Length);
    }

    private ICryptoTransform CreateTransform()
        => _forEncryption ? _aes.CreateEncryptor() : _aes.CreateDecryptor();
}

#endif // NET8_0_OR_GREATER
