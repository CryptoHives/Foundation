// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

/// <summary>
/// Generic block cipher transform that provides ECB, CBC, and CTR mode dispatch
/// for any 128-bit block cipher.
/// </summary>
/// <remarks>
/// <para>
/// Subclasses supply block-level encrypt/decrypt via <see cref="EncryptBlock"/>
/// and <see cref="DecryptBlock"/>. This base class handles multi-block processing,
/// mode-of-operation dispatch (ECB/CBC/CTR), padding, and counter management.
/// </para>
/// </remarks>
internal abstract class BlockCipherTransform : ICipherTransform
{
    private const int BlockSizeConst = 16;

    private readonly CipherMode _mode;
    private readonly PaddingMode _padding;
    private readonly bool _encrypting;
    private readonly byte[] _iv;
    private readonly byte[] _counter;
    private readonly byte[] _feedback;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlockCipherTransform"/> class.
    /// </summary>
    /// <param name="iv">The initialization vector (16 bytes).</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    protected BlockCipherTransform(ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding)
    {
        _encrypting = encrypting;
        _mode = mode;
        _padding = padding;

        _iv = new byte[BlockSizeConst];
        _counter = new byte[BlockSizeConst];
        _feedback = new byte[BlockSizeConst];

        if (!iv.IsEmpty)
        {
            iv.Slice(0, BlockSizeConst).CopyTo(_iv);
            iv.Slice(0, BlockSizeConst).CopyTo(_counter);
            iv.Slice(0, BlockSizeConst).CopyTo(_feedback);
        }
    }

    /// <inheritdoc/>
    public int BlockSize => BlockSizeConst;

    /// <inheritdoc/>
    int ICryptoTransform.InputBlockSize => BlockSizeConst;

    /// <inheritdoc/>
    int ICryptoTransform.OutputBlockSize => BlockSizeConst;

    /// <inheritdoc/>
    public bool CanTransformMultipleBlocks => true;

    /// <inheritdoc/>
    public bool CanReuseTransform => true;

    /// <summary>
    /// Encrypts a single 16-byte block.
    /// </summary>
    /// <param name="input">The 16-byte plaintext block.</param>
    /// <param name="output">The 16-byte ciphertext output.</param>
    protected abstract void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output);

    /// <summary>
    /// Decrypts a single 16-byte block.
    /// </summary>
    /// <param name="input">The 16-byte ciphertext block.</param>
    /// <param name="output">The 16-byte plaintext output.</param>
    protected abstract void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output);

    /// <inheritdoc/>
    public int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (input.Length < BlockSizeConst)
            throw new ArgumentException("Input must be at least one block.", nameof(input));
        if (output.Length < BlockSizeConst)
            throw new ArgumentException("Output buffer too small.", nameof(output));

        int blocks = input.Length / BlockSizeConst;
        int bytesProcessed = 0;

        for (int i = 0; i < blocks; i++)
        {
            var inBlock = input.Slice(i * BlockSizeConst, BlockSizeConst);
            var outBlock = output.Slice(i * BlockSizeConst, BlockSizeConst);

            switch (_mode)
            {
                case CipherMode.ECB:
                    TransformBlockEcb(inBlock, outBlock);
                    break;
                case CipherMode.CBC:
                    TransformBlockCbc(inBlock, outBlock);
                    break;
                case CipherMode.CTR:
                    TransformBlockCtr(inBlock, outBlock);
                    break;
                default:
                    throw new NotSupportedException($"Cipher mode {_mode} is not supported.");
            }

            bytesProcessed += BlockSizeConst;
        }

        return bytesProcessed;
    }

    /// <inheritdoc/>
    public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        => TransformBlock(inputBuffer.AsSpan(inputOffset, inputCount), outputBuffer.AsSpan(outputOffset));

    /// <inheritdoc/>
    public int TransformFinalBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        int fullBlocks = input.Length / BlockSizeConst;
        int remainder = input.Length % BlockSizeConst;
        int written = 0;

        if (fullBlocks > 0)
        {
            written = TransformBlock(input.Slice(0, fullBlocks * BlockSizeConst), output);
        }

        if (_encrypting)
        {
            if (_mode == CipherMode.CTR)
            {
                if (remainder > 0)
                {
                    Span<byte> keystream = stackalloc byte[BlockSizeConst];
                    EncryptBlock(_counter, keystream);
                    IncrementCounter(_counter);

                    for (int i = 0; i < remainder; i++)
                    {
                        output[written + i] = (byte)(input[fullBlocks * BlockSizeConst + i] ^ keystream[i]);
                    }
                    written += remainder;
                }
            }
            else if (_padding != PaddingMode.None)
            {
                Span<byte> paddedBlock = stackalloc byte[BlockSizeConst];
                int paddingLength = BlockSizeConst - remainder;

                if (remainder > 0)
                {
                    input.Slice(fullBlocks * BlockSizeConst, remainder).CopyTo(paddedBlock);
                }

                byte padValue = (byte)paddingLength;
                for (int i = remainder; i < BlockSizeConst; i++)
                {
                    paddedBlock[i] = padValue;
                }

                TransformBlock(paddedBlock, output.Slice(written));
                written += BlockSizeConst;
            }
            else if (remainder > 0)
            {
                throw new CryptographicException("Input length must be a multiple of block size when no padding is used.");
            }
        }
        else
        {
            if (_mode == CipherMode.CTR)
            {
                if (remainder > 0)
                {
                    Span<byte> keystream = stackalloc byte[BlockSizeConst];
                    EncryptBlock(_counter, keystream);
                    IncrementCounter(_counter);

                    for (int i = 0; i < remainder; i++)
                    {
                        output[written + i] = (byte)(input[fullBlocks * BlockSizeConst + i] ^ keystream[i]);
                    }
                    written += remainder;
                }
            }
            else if (_padding != PaddingMode.None && written > 0)
            {
                byte padValue = output[written - 1];

                if (padValue < 1 || padValue > BlockSizeConst)
                    throw new CryptographicException("Invalid padding.");

                for (int i = 0; i < padValue; i++)
                {
                    if (output[written - 1 - i] != padValue)
                        throw new CryptographicException("Invalid padding.");
                }

                written -= padValue;
            }
        }

        return written;
    }

    /// <inheritdoc/>
    public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
    {
        int maxOutput = inputCount + BlockSizeConst;
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
        _iv.AsSpan().CopyTo(_counter);
        _iv.AsSpan().CopyTo(_feedback);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            Array.Clear(_iv, 0, _iv.Length);
            Array.Clear(_counter, 0, _counter.Length);
            Array.Clear(_feedback, 0, _feedback.Length);
            ClearState();
        }
    }

    /// <summary>
    /// Clears cipher-specific state (round keys, etc.) on dispose.
    /// </summary>
    protected virtual void ClearState()
    {
    }

    private void TransformBlockEcb(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (_encrypting)
            EncryptBlock(input, output);
        else
            DecryptBlock(input, output);
    }

    private void TransformBlockCbc(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (_encrypting)
        {
            Span<byte> xored = stackalloc byte[BlockSizeConst];
            for (int i = 0; i < BlockSizeConst; i++)
                xored[i] = (byte)(input[i] ^ _feedback[i]);

            EncryptBlock(xored, output);

            output.Slice(0, BlockSizeConst).CopyTo(_feedback);
        }
        else
        {
            Span<byte> savedInput = stackalloc byte[BlockSizeConst];
            input.CopyTo(savedInput);

            DecryptBlock(input, output);

            for (int i = 0; i < BlockSizeConst; i++)
                output[i] ^= _feedback[i];

            savedInput.CopyTo(_feedback);
        }
    }

    private void TransformBlockCtr(ReadOnlySpan<byte> input, Span<byte> output)
    {
        Span<byte> keystream = stackalloc byte[BlockSizeConst];
        EncryptBlock(_counter, keystream);

        for (int i = 0; i < BlockSizeConst; i++)
            output[i] = (byte)(input[i] ^ keystream[i]);

        IncrementCounter(_counter);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void IncrementCounter(Span<byte> counter)
    {
        for (int i = BlockSizeConst - 1; i >= 0; i--)
        {
            if (++counter[i] != 0)
                break;
        }
    }
}
