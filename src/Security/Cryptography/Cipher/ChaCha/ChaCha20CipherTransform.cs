// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// ChaCha20 cipher transform for encryption or decryption operations.
/// </summary>
/// <remarks>
/// <para>
/// ChaCha20 is a stream cipher, so encryption and decryption are identical operations
/// (XOR with keystream). The same transform can be used for both.
/// </para>
/// </remarks>
internal sealed class ChaCha20CipherTransform : ICipherTransform
{
    private readonly byte[] _key;
    private readonly byte[] _nonce;
    private uint _counter;
    private readonly uint _initialCounter;
    private readonly byte[] _keystreamBuffer;
    private int _keystreamPosition;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChaCha20CipherTransform"/> class.
    /// </summary>
    /// <param name="key">The 32-byte key.</param>
    /// <param name="nonce">The 12-byte nonce.</param>
    /// <param name="initialCounter">The initial block counter (usually 0 or 1).</param>
    public ChaCha20CipherTransform(byte[] key, byte[] nonce, uint initialCounter = 0)
    {
        if (key == null || key.Length != ChaChaCore.KeySizeBytes)
            throw new ArgumentException($"Key must be {ChaChaCore.KeySizeBytes} bytes.", nameof(key));
        if (nonce == null || nonce.Length != ChaChaCore.NonceSizeBytes)
            throw new ArgumentException($"Nonce must be {ChaChaCore.NonceSizeBytes} bytes.", nameof(nonce));

        _key = new byte[ChaChaCore.KeySizeBytes];
        _nonce = new byte[ChaChaCore.NonceSizeBytes];
        Buffer.BlockCopy(key, 0, _key, 0, ChaChaCore.KeySizeBytes);
        Buffer.BlockCopy(nonce, 0, _nonce, 0, ChaChaCore.NonceSizeBytes);

        _counter = initialCounter;
        _initialCounter = initialCounter;
        _keystreamBuffer = new byte[ChaChaCore.BlockSizeBytes];
        _keystreamPosition = ChaChaCore.BlockSizeBytes; // Force generation on first use
    }

    /// <inheritdoc/>
    public int BlockSize => 1; // Stream cipher - can process any byte count

    /// <inheritdoc/>
    int ICryptoTransform.InputBlockSize => 1;

    /// <inheritdoc/>
    int ICryptoTransform.OutputBlockSize => 1;

    /// <inheritdoc/>
    public bool CanTransformMultipleBlocks => true;

    /// <inheritdoc/>
    public bool CanReuseTransform => true;

    /// <inheritdoc/>
    public int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (output.Length < input.Length)
            throw new ArgumentException("Output buffer too small.", nameof(output));

        int processed = 0;

        while (processed < input.Length)
        {
            // Generate new keystream block if needed
            if (_keystreamPosition >= ChaChaCore.BlockSizeBytes)
            {
                ChaChaCore.Block(_key, _nonce, _counter, _keystreamBuffer);
                _counter++;
                _keystreamPosition = 0;
            }

            // XOR input with keystream
            int available = ChaChaCore.BlockSizeBytes - _keystreamPosition;
            int toProcess = Math.Min(available, input.Length - processed);

            for (int i = 0; i < toProcess; i++)
            {
                output[processed + i] = (byte)(input[processed + i] ^ _keystreamBuffer[_keystreamPosition + i]);
            }

            processed += toProcess;
            _keystreamPosition += toProcess;
        }

        return processed;
    }

    /// <inheritdoc/>
    public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
    {
        return TransformBlock(
            inputBuffer.AsSpan(inputOffset, inputCount),
            outputBuffer.AsSpan(outputOffset));
    }

    /// <inheritdoc/>
    public int TransformFinalBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        // For stream ciphers, final block is the same as regular transform
        return TransformBlock(input, output);
    }

    /// <inheritdoc/>
    public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
    {
        byte[] output = new byte[inputCount];
        TransformFinalBlock(inputBuffer.AsSpan(inputOffset, inputCount), output);
        return output;
    }

    /// <inheritdoc/>
    public void Reset()
    {
        _counter = _initialCounter;
        _keystreamPosition = ChaChaCore.BlockSizeBytes; // Force regeneration
        Array.Clear(_keystreamBuffer, 0, _keystreamBuffer.Length);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            Array.Clear(_key, 0, _key.Length);
            Array.Clear(_nonce, 0, _nonce.Length);
            Array.Clear(_keystreamBuffer, 0, _keystreamBuffer.Length);
            _disposed = true;
        }
    }
}
