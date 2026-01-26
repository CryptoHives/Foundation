// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Security.Cryptography;

/// <summary>
/// AES cipher transform for encryption or decryption operations.
/// </summary>
/// <remarks>
/// <para>
/// This class implements <see cref="ICipherTransform"/> for AES block cipher operations.
/// It supports ECB, CBC, and CTR modes with PKCS#7 padding.
/// </para>
/// </remarks>
internal sealed class AesCipherTransform : ICipherTransform
{
    private readonly uint[] _roundKeys;
    private readonly int _rounds;
    private readonly bool _encrypting;
    private readonly CipherMode _mode;
    private readonly PaddingMode _padding;
    private readonly byte[] _iv;
    private readonly byte[] _counter;
    private readonly byte[] _feedbackBlock;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCipherTransform"/> class.
    /// </summary>
    /// <param name="key">The cipher key.</param>
    /// <param name="iv">The initialization vector.</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    public AesCipherTransform(byte[] key, byte[] iv, bool encrypting, CipherMode mode, PaddingMode padding)
    {
        _encrypting = encrypting;
        _mode = mode;
        _padding = padding;

        // Expand key
        int keyWords = key.Length / 4;
        int totalWords = 4 * (keyWords + 7); // 44, 52, or 60 words
        var encRoundKeys = new uint[totalWords];
        _rounds = AesCore.ExpandKey(key, encRoundKeys);

        // CTR and Stream modes always use encryption (we encrypt the counter/nonce)
        // ECB and CBC use encryption keys for encrypting, decryption keys for decrypting
        if (encrypting || mode == CipherMode.Ctr || mode == CipherMode.Stream)
        {
            _roundKeys = encRoundKeys;
        }
        else
        {
            _roundKeys = new uint[totalWords];
            AesCore.CreateDecryptionKeys(encRoundKeys, _roundKeys, _rounds);
        }

        // Copy IV
        _iv = new byte[AesCore.BlockSizeBytes];
        if (iv != null && iv.Length >= AesCore.BlockSizeBytes)
        {
            Buffer.BlockCopy(iv, 0, _iv, 0, AesCore.BlockSizeBytes);
        }

        // Initialize feedback block and counter for CBC/CTR modes
        _feedbackBlock = new byte[AesCore.BlockSizeBytes];
        _counter = new byte[AesCore.BlockSizeBytes];
        Buffer.BlockCopy(_iv, 0, _feedbackBlock, 0, AesCore.BlockSizeBytes);
        Buffer.BlockCopy(_iv, 0, _counter, 0, AesCore.BlockSizeBytes);
    }

    /// <inheritdoc/>
    public int BlockSize => AesCore.BlockSizeBytes;

    /// <inheritdoc/>
    public bool CanTransformMultipleBlocks => true;

    /// <inheritdoc/>
    public bool CanReuseTransform => true;

    /// <inheritdoc/>
    public int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (input.Length < BlockSize)
            throw new ArgumentException("Input must be at least one block.", nameof(input));
        if (output.Length < BlockSize)
            throw new ArgumentException("Output buffer too small.", nameof(output));

        int blocks = input.Length / BlockSize;
        int bytesProcessed = 0;

        for (int i = 0; i < blocks; i++)
        {
            var inBlock = input.Slice(i * BlockSize, BlockSize);
            var outBlock = output.Slice(i * BlockSize, BlockSize);

            switch (_mode)
            {
                case CipherMode.Ecb:
                    TransformBlockEcb(inBlock, outBlock);
                    break;
                case CipherMode.Cbc:
                    TransformBlockCbc(inBlock, outBlock);
                    break;
                case CipherMode.Ctr:
                    TransformBlockCtr(inBlock, outBlock);
                    break;
                default:
                    throw new NotSupportedException($"Cipher mode {_mode} is not supported.");
            }

            bytesProcessed += BlockSize;
        }

        return bytesProcessed;
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
        int fullBlocks = input.Length / BlockSize;
        int remainder = input.Length % BlockSize;
        int written = 0;

        // Process all full blocks
        if (fullBlocks > 0)
        {
            written = TransformBlock(input.Slice(0, fullBlocks * BlockSize), output);
        }

        if (_encrypting)
        {
            // Apply padding and encrypt final block
            if (_mode == CipherMode.Ctr || _mode == CipherMode.Stream)
            {
                // CTR mode doesn't need padding - just encrypt remaining bytes
                if (remainder > 0)
                {
                    Span<byte> keystream = stackalloc byte[BlockSize];
                    Span<byte> counterOut = stackalloc byte[BlockSize];
                    AesCore.EncryptBlock(_counter, counterOut, _roundKeys, _rounds);
                    IncrementCounter();

                    for (int i = 0; i < remainder; i++)
                    {
                        output[written + i] = (byte)(input[fullBlocks * BlockSize + i] ^ counterOut[i]);
                    }
                    written += remainder;
                }
            }
            else if (_padding != PaddingMode.None)
            {
                // Apply PKCS#7 padding
                Span<byte> paddedBlock = stackalloc byte[BlockSize];
                int paddingLength = BlockSize - remainder;

                // Copy remaining plaintext
                if (remainder > 0)
                {
                    input.Slice(fullBlocks * BlockSize, remainder).CopyTo(paddedBlock);
                }

                // Add padding bytes
                byte padValue = (byte)paddingLength;
                for (int i = remainder; i < BlockSize; i++)
                {
                    paddedBlock[i] = padValue;
                }

                // Encrypt padded block
                TransformBlock(paddedBlock, output.Slice(written));
                written += BlockSize;
            }
            else if (remainder > 0)
            {
                throw new CryptographicException("Input length must be a multiple of block size when no padding is used.");
            }
        }
        else
        {
            // Decryption - remove padding from last block
            if (_mode == CipherMode.Ctr || _mode == CipherMode.Stream)
            {
                // CTR mode - decrypt remaining bytes
                if (remainder > 0)
                {
                    Span<byte> counterOut = stackalloc byte[BlockSize];
                    AesCore.EncryptBlock(_counter, counterOut, _roundKeys, _rounds);
                    IncrementCounter();

                    for (int i = 0; i < remainder; i++)
                    {
                        output[written + i] = (byte)(input[fullBlocks * BlockSize + i] ^ counterOut[i]);
                    }
                    written += remainder;
                }
            }
            else if (_padding != PaddingMode.None && written > 0)
            {
                // Validate and remove PKCS#7 padding
                int lastBlockStart = written - BlockSize;
                byte padValue = output[written - 1];

                if (padValue < 1 || padValue > BlockSize)
                {
                    throw new CryptographicException("Invalid padding.");
                }

                // Validate all padding bytes
                for (int i = 0; i < padValue; i++)
                {
                    if (output[written - 1 - i] != padValue)
                    {
                        throw new CryptographicException("Invalid padding.");
                    }
                }

                written -= padValue;
            }
        }

        return written;
    }

    /// <inheritdoc/>
    public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
    {
        // Calculate max output size
        int maxOutput = inputCount + BlockSize; // Room for padding
        byte[] output = new byte[maxOutput];

        int written = TransformFinalBlock(
            inputBuffer.AsSpan(inputOffset, inputCount),
            output.AsSpan());

        if (written != output.Length)
        {
            Array.Resize(ref output, written);
        }

        return output;
    }

    /// <inheritdoc/>
    public void Reset()
    {
        // Reset feedback block and counter to initial IV
        Buffer.BlockCopy(_iv, 0, _feedbackBlock, 0, AesCore.BlockSizeBytes);
        Buffer.BlockCopy(_iv, 0, _counter, 0, AesCore.BlockSizeBytes);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            // Clear sensitive data
            Array.Clear(_roundKeys, 0, _roundKeys.Length);
            Array.Clear(_iv, 0, _iv.Length);
            Array.Clear(_feedbackBlock, 0, _feedbackBlock.Length);
            Array.Clear(_counter, 0, _counter.Length);
            _disposed = true;
        }
    }

    // ========================================================================
    // ECB Mode
    // ========================================================================

    private void TransformBlockEcb(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (_encrypting)
        {
            AesCore.EncryptBlock(input, output, _roundKeys, _rounds);
        }
        else
        {
            AesCore.DecryptBlock(input, output, _roundKeys, _rounds);
        }
    }

    // ========================================================================
    // CBC Mode
    // ========================================================================

    private void TransformBlockCbc(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (_encrypting)
        {
            // XOR plaintext with previous ciphertext (or IV)
            Span<byte> xored = stackalloc byte[BlockSize];
            for (int i = 0; i < BlockSize; i++)
            {
                xored[i] = (byte)(input[i] ^ _feedbackBlock[i]);
            }

            // Encrypt
            AesCore.EncryptBlock(xored, output, _roundKeys, _rounds);

            // Save ciphertext for next block
            output.Slice(0, BlockSize).CopyTo(_feedbackBlock);
        }
        else
        {
            // Save input ciphertext for next block's XOR
            Span<byte> savedInput = stackalloc byte[BlockSize];
            input.CopyTo(savedInput);

            // Decrypt
            AesCore.DecryptBlock(input, output, _roundKeys, _rounds);

            // XOR with previous ciphertext (or IV)
            for (int i = 0; i < BlockSize; i++)
            {
                output[i] ^= _feedbackBlock[i];
            }

            // Save ciphertext for next block
            savedInput.CopyTo(_feedbackBlock);
        }
    }

    // ========================================================================
    // CTR Mode
    // ========================================================================

    private void TransformBlockCtr(ReadOnlySpan<byte> input, Span<byte> output)
    {
        // Encrypt counter to get keystream
        Span<byte> keystream = stackalloc byte[BlockSize];
        AesCore.EncryptBlock(_counter, keystream, _roundKeys, _rounds);

        // XOR with input
        for (int i = 0; i < BlockSize; i++)
        {
            output[i] = (byte)(input[i] ^ keystream[i]);
        }

        // Increment counter
        IncrementCounter();
    }

    /// <summary>
    /// Increments the counter for CTR mode (big-endian increment).
    /// </summary>
    private void IncrementCounter()
    {
        // Increment as big-endian 128-bit integer
        for (int i = BlockSize - 1; i >= 0; i--)
        {
            if (++_counter[i] != 0)
                break;
        }
    }
}
