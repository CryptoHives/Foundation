// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;
using OS = System.Security.Cryptography;

/// <summary>
/// Generic block cipher transform that provides ECB, CBC, CTR, OFB, CFB and CTS mode dispatch
/// for any block cipher.
/// </summary>
/// <remarks>
/// <para>
/// Subclasses supply block-level encrypt/decrypt via <see cref="EncryptBlock"/>
/// and <see cref="DecryptBlock"/>. This base class handles multi-block processing,
/// mode-of-operation dispatch, padding, and counter management.
/// </para>
/// <para>
/// CFB pads to its feedback size, as the in-box implementations do. CTR and OFB are stream modes
/// and ignore the padding mode. CTS is CBC-CS3 (RFC 3962), needs at least one full block of input,
/// and ignores the padding mode; it withholds the last two blocks until the final transform.
/// </para>
/// </remarks>
internal abstract class BlockCipherTransform : ICipherTransform
{
    private readonly int _blockSize;
    private readonly int _unitSize;
    private readonly CipherMode _mode;
    private readonly PaddingMode _padding;
    private readonly bool _encrypting;
    private readonly byte[] _iv;
    private readonly byte[] _counter;
    private readonly byte[] _feedback;
    private readonly byte[] _held;
    private int _heldCount;
    private bool _disposed;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlockCipherTransform"/> class.
    /// </summary>
    /// <param name="iv">The initialization vector (one block).</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    /// <param name="feedbackSizeBytes">The CFB feedback size in bytes; ignored by the other modes.</param>
    /// <param name="blockSizeBytes">The cipher block size in bytes.</param>
    /// <exception cref="NotSupportedException"><paramref name="mode"/> is not a block cipher mode.</exception>
    /// <exception cref="OS.CryptographicException">The CFB feedback size is not between one byte and one block.</exception>
    protected BlockCipherTransform(ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding, int feedbackSizeBytes, int blockSizeBytes = 16)
    {
        if (mode is not (CipherMode.ECB or CipherMode.CBC or CipherMode.CTR or CipherMode.OFB or CipherMode.CFB or CipherMode.CTS))
            throw new NotSupportedException($"Cipher mode {mode} is not supported.");

        if (mode == CipherMode.CFB && (feedbackSizeBytes < 1 || feedbackSizeBytes > blockSizeBytes))
            throw new OS.CryptographicException($"Invalid CFB feedback size: {feedbackSizeBytes * 8} bits.");

        _blockSize = blockSizeBytes;
        _unitSize = mode == CipherMode.CFB ? feedbackSizeBytes : blockSizeBytes;
        _encrypting = encrypting;
        _mode = mode;
        _padding = padding;

        _iv = new byte[_blockSize];
        _counter = new byte[_blockSize];
        _feedback = new byte[_blockSize];
        _held = mode == CipherMode.CTS ? new byte[3 * _blockSize] : [];

        if (!iv.IsEmpty)
        {
            iv.Slice(0, _blockSize).CopyTo(_iv);
            iv.Slice(0, _blockSize).CopyTo(_counter);
            iv.Slice(0, _blockSize).CopyTo(_feedback);
        }
    }

    /// <inheritdoc/>
    public int BlockSize => _blockSize;

    /// <inheritdoc/>
    int OS.ICryptoTransform.InputBlockSize => _unitSize;

    /// <inheritdoc/>
    int OS.ICryptoTransform.OutputBlockSize => _unitSize;

    /// <inheritdoc/>
    public bool CanTransformMultipleBlocks => true;

    /// <inheritdoc/>
    public bool CanReuseTransform => true;

    /// <summary>
    /// Gets a value indicating whether this transform is encrypting (<see langword="true"/>)
    /// or decrypting (<see langword="false"/>).
    /// </summary>
    protected bool IsEncrypting => _encrypting;

    /// <summary>
    /// Gets the current cipher mode of operation.
    /// </summary>
    protected CipherMode CurrentMode => _mode;

    /// <summary>
    /// Gets the block size in bytes.
    /// </summary>
    protected int BlockSizeBytes => _blockSize;

    /// <summary>
    /// Gets a <see cref="Span{T}"/> over the current CBC feedback register.
    /// </summary>
    /// <remarks>
    /// Subclasses may read and update this span directly when implementing a
    /// bulk CBC override of <see cref="TransformBlock(ReadOnlySpan{byte},Span{byte})"/> to avoid per-block
    /// virtual dispatch and intermediate buffer overhead.
    /// </remarks>
    protected Span<byte> FeedbackSpan => _feedback;

    /// <summary>
    /// Returns whether a transform needs the inverse cipher, and therefore the decryption key schedule.
    /// </summary>
    /// <remarks>
    /// CTR, OFB and CFB run the forward cipher in both directions.
    /// </remarks>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    protected static bool NeedsInverseCipher(bool encrypting, CipherMode mode)
        => !encrypting && mode is CipherMode.ECB or CipherMode.CBC or CipherMode.CTS;

    /// <summary>
    /// Encrypts a single block.
    /// </summary>
    /// <param name="input">The plaintext block.</param>
    /// <param name="output">The ciphertext output.</param>
    protected abstract void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output);

    /// <summary>
    /// Decrypts a single block.
    /// </summary>
    /// <param name="input">The ciphertext block.</param>
    /// <param name="output">The plaintext output.</param>
    protected abstract void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output);

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public virtual int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().Name);
        if (input.Length < _unitSize)
            throw new ArgumentException("Input must be at least one block.", nameof(input));

        if (_mode == CipherMode.CTS)
            return TransformBlockCts(input, output);

        if (output.Length < _unitSize)
            throw new ArgumentException("Output buffer too small.", nameof(output));

        int unit = _unitSize;
        int units = input.Length / unit;

        for (int i = 0; i < units; i++)
        {
            var inBlock = input.Slice(i * unit, unit);
            var outBlock = output.Slice(i * unit, unit);

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
                case CipherMode.OFB:
                    TransformBlockOfb(inBlock, outBlock);
                    break;
                case CipherMode.CFB:
                    TransformUnitCfb(inBlock, outBlock);
                    break;
            }
        }

        return units * unit;
    }

    /// <inheritdoc/>
    public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        => TransformBlock(inputBuffer.AsSpan(inputOffset, inputCount), outputBuffer.AsSpan(outputOffset));

    /// <inheritdoc/>
    /// <exception cref="ObjectDisposedException">Thrown when the instance has been disposed.</exception>
    public int TransformFinalBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (_disposed)
            throw new ObjectDisposedException(GetType().Name);

        if (_mode == CipherMode.CTS)
            return TransformFinalBlockCts(input, output);

        int unit = _unitSize;
        int fullUnits = input.Length / unit;
        int remainder = input.Length % unit;
        int written = 0;

        if (fullUnits > 0)
        {
            written = TransformBlock(input.Slice(0, fullUnits * unit), output);
        }

        ReadOnlySpan<byte> tail = input.Slice(fullUnits * unit);

        if (_mode is CipherMode.CTR or CipherMode.OFB)
        {
            if (remainder > 0)
            {
                if (_mode == CipherMode.CTR)
                    TransformBlockCtr(tail, output.Slice(written, remainder));
                else
                    TransformBlockOfb(tail, output.Slice(written, remainder));
                written += remainder;
            }
        }
        else if (_encrypting)
        {
            Span<byte> padded = stackalloc byte[unit];
            if (BlockPadding.Pad(tail, padded, _padding) > 0)
            {
                TransformBlock(padded, output.Slice(written));
                written += unit;
            }
        }
        else
        {
            if (remainder > 0)
                throw new OS.CryptographicException("The input data is not a complete block.");

            if (written > 0)
            {
                written -= BlockPadding.GetPaddingLength(output.Slice(written - unit, unit), _padding);
            }
        }

        return written;
    }

    /// <inheritdoc/>
    public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
    {
        int maxOutput = inputCount + _heldCount + _blockSize;
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
        Array.Clear(_held, 0, _held.Length);
        _heldCount = 0;
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
            Array.Clear(_held, 0, _held.Length);
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
            Span<byte> xored = stackalloc byte[_blockSize];
            for (int i = 0; i < _blockSize; i++)
                xored[i] = (byte)(input[i] ^ _feedback[i]);

            EncryptBlock(xored, output);

            output.Slice(0, _blockSize).CopyTo(_feedback);
        }
        else
        {
            Span<byte> savedInput = stackalloc byte[_blockSize];
            input.CopyTo(savedInput);

            DecryptBlock(input, output);

            for (int i = 0; i < _blockSize; i++)
                output[i] ^= _feedback[i];

            savedInput.CopyTo(_feedback);
        }
    }

    private void TransformBlockCtr(ReadOnlySpan<byte> input, Span<byte> output)
    {
        Span<byte> keystream = stackalloc byte[_blockSize];
        EncryptBlock(_counter, keystream);

        for (int i = 0; i < input.Length; i++)
            output[i] = (byte)(input[i] ^ keystream[i]);

        IncrementCounter(_counter);
    }

    private void TransformBlockOfb(ReadOnlySpan<byte> input, Span<byte> output)
    {
        Span<byte> keystream = stackalloc byte[_blockSize];
        EncryptBlock(_feedback, keystream);
        keystream.CopyTo(_feedback);

        for (int i = 0; i < input.Length; i++)
            output[i] = (byte)(input[i] ^ keystream[i]);
    }

    private void TransformUnitCfb(ReadOnlySpan<byte> input, Span<byte> output)
    {
        int shift = _unitSize;
        Span<byte> keystream = stackalloc byte[_blockSize];
        EncryptBlock(_feedback, keystream);

        Span<byte> register = _feedback;
        register.Slice(shift).CopyTo(register);
        Span<byte> ciphertext = register.Slice(_blockSize - shift);

        for (int i = 0; i < shift; i++)
        {
            byte inByte = input[i];
            byte outByte = (byte)(inByte ^ keystream[i]);
            output[i] = outByte;
            ciphertext[i] = _encrypting ? outByte : inByte;
        }
    }

    /// <summary>
    /// CBC-transforms every block except the last two, which stay in <see cref="_held"/>.
    /// </summary>
    /// <remarks>
    /// Each input block is copied out before any output is written, so in-place buffers are safe.
    /// </remarks>
    private int TransformBlockCts(ReadOnlySpan<byte> input, Span<byte> output)
    {
        int bs = _blockSize;
        if (input.Length % bs != 0)
            throw new ArgumentException("Input must be a whole number of blocks.", nameof(input));

        Span<byte> held = _held;
        int written = 0;

        for (int offset = 0; offset < input.Length; offset += bs)
        {
            input.Slice(offset, bs).CopyTo(held.Slice(_heldCount));
            _heldCount += bs;

            if (_heldCount == 3 * bs)
            {
                TransformBlockCbc(held.Slice(0, bs), output.Slice(written, bs));
                held.Slice(bs, 2 * bs).CopyTo(held);
                _heldCount -= bs;
                written += bs;
            }
        }

        return written;
    }

    private int TransformFinalBlockCts(ReadOnlySpan<byte> input, Span<byte> output)
    {
        int bs = _blockSize;
        int tailLength = input.Length % bs;
        int written = 0;

        if (input.Length >= bs)
        {
            written = TransformBlockCts(input.Slice(0, input.Length - tailLength), output);
        }

        Span<byte> held = _held;
        if (tailLength > 0 && _heldCount == 2 * bs)
        {
            TransformBlockCbc(held.Slice(0, bs), output.Slice(written, bs));
            held.Slice(bs, bs).CopyTo(held);
            _heldCount = bs;
            written += bs;
        }

        if (_heldCount == 0)
            throw new OS.CryptographicException("CTS requires at least one full block of input.");

        if (tailLength == 0 && _heldCount == bs)
        {
            TransformBlockCbc(held.Slice(0, bs), output.Slice(written, bs));
            written += bs;
        }
        else
        {
            Span<byte> last = stackalloc byte[bs];
            int lastLength = tailLength > 0 ? tailLength : bs;
            if (tailLength > 0)
                input.Slice(input.Length - tailLength).CopyTo(last);
            else
                held.Slice(bs, bs).CopyTo(last);

            Span<byte> destination = output.Slice(written, bs + lastLength);
            if (_encrypting)
                EncryptStolenBlocks(held.Slice(0, bs), last, lastLength, destination);
            else
                DecryptStolenBlocks(held.Slice(0, bs), last, lastLength, destination);

            written += bs + lastLength;
        }

        held.Clear();
        _heldCount = 0;
        return written;
    }

    /// <summary>
    /// Encrypts the full block <paramref name="first"/> and the final <paramref name="lastLength"/>
    /// bytes, emitting the last ciphertext block first and the truncated penultimate one after it.
    /// </summary>
    private void EncryptStolenBlocks(ReadOnlySpan<byte> first, ReadOnlySpan<byte> last, int lastLength, Span<byte> output)
    {
        int bs = _blockSize;
        Span<byte> temp = stackalloc byte[bs];
        Span<byte> penultimate = stackalloc byte[bs];

        for (int i = 0; i < bs; i++)
            temp[i] = (byte)(first[i] ^ _feedback[i]);
        EncryptBlock(temp, penultimate);

        for (int i = 0; i < bs; i++)
            temp[i] = (byte)((i < lastLength ? last[i] : 0) ^ penultimate[i]);
        EncryptBlock(temp, output.Slice(0, bs));

        penultimate.Slice(0, lastLength).CopyTo(output.Slice(bs));
    }

    /// <summary>
    /// Inverts <see cref="EncryptStolenBlocks"/>: <paramref name="first"/> is the last ciphertext
    /// block and <paramref name="last"/> the truncated penultimate one.
    /// </summary>
    private void DecryptStolenBlocks(ReadOnlySpan<byte> first, ReadOnlySpan<byte> last, int lastLength, Span<byte> output)
    {
        int bs = _blockSize;
        Span<byte> decrypted = stackalloc byte[bs];
        Span<byte> penultimate = stackalloc byte[bs];

        DecryptBlock(first, decrypted);

        last.Slice(0, lastLength).CopyTo(penultimate);
        decrypted.Slice(lastLength).CopyTo(penultimate.Slice(lastLength));

        for (int i = 0; i < lastLength; i++)
            output[bs + i] = (byte)(decrypted[i] ^ last[i]);

        DecryptBlock(penultimate, output.Slice(0, bs));
        for (int i = 0; i < bs; i++)
            output[i] ^= _feedback[i];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void IncrementCounter(Span<byte> counter)
    {
        for (int i = counter.Length - 1; i >= 0; i--)
        {
            if (++counter[i] != 0)
                break;
        }
    }
}
