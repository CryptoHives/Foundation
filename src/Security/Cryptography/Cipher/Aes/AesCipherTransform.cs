// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
#if NET8_0_OR_GREATER
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
#endif

/// <summary>
/// AES cipher transform for encryption or decryption operations.
/// </summary>
/// <remarks>
/// <para>
/// This class implements <see cref="ICipherTransform"/> for AES block cipher operations.
/// It supports ECB, CBC, and CTR modes with PKCS#7 padding.
/// </para>
/// <para>
/// When AES-NI hardware acceleration is available, this transform automatically uses
/// hardware-accelerated AES instructions for CBC decrypt for improved performance.
/// </para>
/// </remarks>
internal sealed unsafe class AesCipherTransform : ICipherTransform
{
    /// <summary>
    /// Maximum number of round key words (AES-256: 4 × (8 + 7) = 60).
    /// </summary>
    private const int MaxRoundKeyWords = 60;

#pragma warning disable CS0414 //The field 'AesCipherTransform._buffers' is assigned but its value is never used
    private AesCipherBuffers _buffers;
#pragma warning restore
    private readonly CipherMode _mode;
    private readonly PaddingMode _padding;
    private readonly int _rounds;
    private readonly bool _encrypting;
    private bool _disposed;
#if NET8_0_OR_GREATER
    private readonly bool _useAesNi;
#endif

    /// <summary>
    /// Inline fixed-size buffer for AES round keys, counter and feedback.
    /// Avoids heap allocation and keeps the cache hits local. Up to 10% perf gain.
    /// </summary>
    private struct AesCipherBuffers
    {
        public fixed uint Keys[MaxRoundKeyWords];
        public fixed byte IV[AesCore.BlockSizeBytes];
        public fixed byte Counter[AesCore.BlockSizeBytes];
        public fixed byte Feedback[AesCore.BlockSizeBytes];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCipherTransform"/> class.
    /// </summary>
    /// <param name="key">The cipher key.</param>
    /// <param name="iv">The initialization vector.</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    public AesCipherTransform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding)
        : this(SimdSupport.All, key, iv, encrypting, mode, padding)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCipherTransform"/> class with specified SIMD support.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The cipher key.</param>
    /// <param name="iv">The initialization vector.</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    internal AesCipherTransform(SimdSupport simdSupport, ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding)
    {
        _encrypting = encrypting;
        _mode = mode;
        _padding = padding;

        fixed (uint* p = _buffers.Keys)
        {
            var roundKeys = new Span<uint>(p, MaxRoundKeyWords);

#if NET8_0_OR_GREATER
            if ((simdSupport & SimdSupport & SimdSupport.AesNi) != 0)
            {
                _useAesNi = true;
                var aesNiView = MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys);
                _rounds = AesCoreAesNi.ExpandKey(key, aesNiView);

                if (!encrypting && mode != CipherMode.CTR && mode != CipherMode.Stream)
                {
                    // Expand enc keys into temp, create dec keys into fixed buffer, clear temp
                    Span<uint> tempEnc = stackalloc uint[MaxRoundKeyWords];
                    roundKeys.CopyTo(tempEnc);
                    var encView = MemoryMarshal.Cast<uint, Vector128<byte>>(tempEnc);
                    AesCoreAesNi.CreateDecryptionKeys(encView, aesNiView, _rounds);
                    tempEnc.Clear();
                }
            }
            else
#endif
            {
                // CTR and Stream modes always use encryption (we encrypt the counter/nonce)
                // ECB and CBC use encryption keys for encrypting, decryption keys for decrypting
                if (encrypting || mode == CipherMode.CTR || mode == CipherMode.Stream)
                {
                    _rounds = AesCore.ExpandKey(key, roundKeys);
                }
                else
                {
                    Span<uint> tempEnc = stackalloc uint[MaxRoundKeyWords];
                    _rounds = AesCore.ExpandKey(key, tempEnc);
                    AesCore.CreateDecryptionKeys(tempEnc, roundKeys, _rounds);
                    tempEnc.Clear();
                }
            }
        }

        // Copy IV
        fixed (byte* ivPtr = _buffers.IV)
        {
            var ivSpan = new Span<byte>(ivPtr, AesCore.BlockSizeBytes);
            ivSpan.Clear();
            if (iv.Length >= AesCore.BlockSizeBytes)
            {
                iv.Slice(0, AesCore.BlockSizeBytes).CopyTo(ivSpan);
            }
        }

        // copies IV to counter and feedback
        Reset();
    }

    /// <summary>
    /// Gets the SIMD instruction sets supported by AES on the current platform.
    /// </summary>
    internal static SimdSupport SimdSupport =>
#if NET8_0_OR_GREATER
        AesCoreAesNi.IsSupported ? SimdSupport.AesNi : SimdSupport.None;
#else
        SimdSupport.None;
#endif

    /// <inheritdoc/>
    public int BlockSize => AesCore.BlockSizeBytes;

    /// <inheritdoc/>
    int ICryptoTransform.InputBlockSize => AesCore.BlockSizeBytes;

    /// <inheritdoc/>
    int ICryptoTransform.OutputBlockSize => AesCore.BlockSizeBytes;

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

#if NET8_0_OR_GREATER
        // Vectorized CBC decrypt: process 8/4 blocks in parallel
        if (_mode == CipherMode.CBC && !_encrypting && _useAesNi)
        {
            return TransformCbcDecryptVectorized(input, output, blocks);
        }
#endif

        int bytesProcessed = 0;
        for (int i = 0; i < blocks; i++)
        {
            var inBlock = input.Slice(i * BlockSize, BlockSize);
            var outBlock = output.Slice(i * BlockSize, BlockSize);

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

            bytesProcessed += BlockSize;
        }

        return bytesProcessed;
    }

    /// <inheritdoc/>
    public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        => TransformBlock(inputBuffer.AsSpan(inputOffset, inputCount), outputBuffer.AsSpan(outputOffset));

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
            if (_mode == CipherMode.CTR || _mode == CipherMode.Stream)
            {
                // CTR mode doesn't need padding - just encrypt remaining bytes
                if (remainder > 0)
                {
                    Span<byte> counterOut = stackalloc byte[BlockSize];
                    fixed (byte* counterPtr = _buffers.Counter)
                    {
                        var counter = new Span<byte>(counterPtr, AesCore.BlockSizeBytes);
                        EncryptBlockDispatch(counter, counterOut);
                        IncrementCounter(counter);
                    }

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
            if (_mode == CipherMode.CTR || _mode == CipherMode.Stream)
            {
                // CTR mode - decrypt remaining bytes
                if (remainder > 0)
                {
                    Span<byte> counterOut = stackalloc byte[BlockSize];
                    fixed (byte* counterPtr = _buffers.Counter)
                    {
                        var counter = new Span<byte>(counterPtr, AesCore.BlockSizeBytes);
                        EncryptBlockDispatch(counter, counterOut);
                        IncrementCounter(counter);
                    }

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
        fixed (byte* ivPtr = _buffers.IV)
        {
            var ivSpan = new Span<byte>(ivPtr, AesCore.BlockSizeBytes);
            fixed (byte* counterPtr = _buffers.Counter)
            {
                ivSpan.CopyTo(new Span<byte>(counterPtr, AesCore.BlockSizeBytes));
            }
            fixed (byte* feedbackPtr = _buffers.Feedback)
            {
                ivSpan.CopyTo(new Span<byte>(feedbackPtr, AesCore.BlockSizeBytes));
            }
        }
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        if (!_disposed)
        {
            // Clear sensitive data
            _buffers = default;
            _disposed = true;
        }
    }

#if NET8_0_OR_GREATER
    // ========================================================================
    // Vectorized CBC Decrypt (8/4-block interleaved AES-NI)
    // ========================================================================

    /// <summary>
    /// Processes CBC decrypt using 8/4-block interleaved AES-NI for parallelism.
    /// </summary>
    /// <remarks>
    /// CBC decryption is parallelizable: each ciphertext block is independently
    /// AES-decrypted, then XOR'd with the previous ciphertext block. By decrypting
    /// 8 blocks simultaneously, we saturate the AES pipeline (latency=4, throughput=1).
    /// </remarks>
    [SkipLocalsInit]
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private int TransformCbcDecryptVectorized(ReadOnlySpan<byte> input, Span<byte> output, int blocks)
    {
        int offset = 0;

        fixed (byte* feedbackPtr = _buffers.Feedback)
        {
            var feedbackBlock = new Span<byte>(feedbackPtr, AesCore.BlockSizeBytes);
            var feedback = Vector128.Create(feedbackBlock);

            fixed (uint* p = _buffers.Keys)
            {
                var aesNiKeys = MemoryMarshal.Cast<uint, Vector128<byte>>(new ReadOnlySpan<uint>(p, MaxRoundKeyWords));

                // 8-block loop
                while (offset + 8 * BlockSize <= blocks * BlockSize)
                {
                    var ct0 = Vector128.Create(input.Slice(offset + 0 * BlockSize, BlockSize));
                    var ct1 = Vector128.Create(input.Slice(offset + 1 * BlockSize, BlockSize));
                    var ct2 = Vector128.Create(input.Slice(offset + 2 * BlockSize, BlockSize));
                    var ct3 = Vector128.Create(input.Slice(offset + 3 * BlockSize, BlockSize));
                    var ct4 = Vector128.Create(input.Slice(offset + 4 * BlockSize, BlockSize));
                    var ct5 = Vector128.Create(input.Slice(offset + 5 * BlockSize, BlockSize));
                    var ct6 = Vector128.Create(input.Slice(offset + 6 * BlockSize, BlockSize));
                    var ct7 = Vector128.Create(input.Slice(offset + 7 * BlockSize, BlockSize));

                    var b0 = ct0; var b1 = ct1; var b2 = ct2; var b3 = ct3;
                    var b4 = ct4; var b5 = ct5; var b6 = ct6; var b7 = ct7;

                    AesCoreAesNi.DecryptBlocks8(ref b0, ref b1, ref b2, ref b3,
                                                 ref b4, ref b5, ref b6, ref b7,
                                                 aesNiKeys, _rounds);

                    Sse2.Xor(b0, feedback).CopyTo(output.Slice(offset));
                    Sse2.Xor(b1, ct0).CopyTo(output.Slice(offset + BlockSize));
                    Sse2.Xor(b2, ct1).CopyTo(output.Slice(offset + 2 * BlockSize));
                    Sse2.Xor(b3, ct2).CopyTo(output.Slice(offset + 3 * BlockSize));
                    Sse2.Xor(b4, ct3).CopyTo(output.Slice(offset + 4 * BlockSize));
                    Sse2.Xor(b5, ct4).CopyTo(output.Slice(offset + 5 * BlockSize));
                    Sse2.Xor(b6, ct5).CopyTo(output.Slice(offset + 6 * BlockSize));
                    Sse2.Xor(b7, ct6).CopyTo(output.Slice(offset + 7 * BlockSize));

                    feedback = ct7;
                    offset += 8 * BlockSize;
                }

                // 4-block fallback
                while (offset + 4 * BlockSize <= blocks * BlockSize)
                {
                    var ct0 = Vector128.Create(input.Slice(offset + 0 * BlockSize, BlockSize));
                    var ct1 = Vector128.Create(input.Slice(offset + 1 * BlockSize, BlockSize));
                    var ct2 = Vector128.Create(input.Slice(offset + 2 * BlockSize, BlockSize));
                    var ct3 = Vector128.Create(input.Slice(offset + 3 * BlockSize, BlockSize));

                    var b0 = ct0; var b1 = ct1; var b2 = ct2; var b3 = ct3;

                    AesCoreAesNi.DecryptBlocks4(ref b0, ref b1, ref b2, ref b3,
                                                 aesNiKeys, _rounds);

                    Sse2.Xor(b0, feedback).CopyTo(output.Slice(offset));
                    Sse2.Xor(b1, ct0).CopyTo(output.Slice(offset + BlockSize));
                    Sse2.Xor(b2, ct1).CopyTo(output.Slice(offset + 2 * BlockSize));
                    Sse2.Xor(b3, ct2).CopyTo(output.Slice(offset + 3 * BlockSize));

                    feedback = ct3;
                    offset += 4 * BlockSize;
                }

                // Remaining 1-3 blocks
                while (offset < blocks * BlockSize)
                {
                    var ct = Vector128.Create(input.Slice(offset, BlockSize));

                    AesCoreAesNi.DecryptBlock(input.Slice(offset, BlockSize),
                                               output.Slice(offset, BlockSize),
                                               aesNiKeys, _rounds);
                    var plain = Vector128.Create(output.Slice(offset, BlockSize));
                    Sse2.Xor(plain, feedback).CopyTo(output.Slice(offset));

                    feedback = ct;
                    offset += BlockSize;
                }
            }

            // Save feedback for next call
            feedback.CopyTo(feedbackBlock);
        }

        return offset;
    }
#endif

    // ========================================================================
    // ECB Mode
    // ========================================================================

    private void TransformBlockEcb(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (_encrypting)
        {
            EncryptBlockDispatch(input, output);
        }
        else
        {
            DecryptBlockDispatch(input, output);
        }
    }

    // ========================================================================
    // CBC Mode
    // ========================================================================

    private void TransformBlockCbc(ReadOnlySpan<byte> input, Span<byte> output)
    {
        fixed (byte* feedbackPtr = _buffers.Feedback)
        {
            var feedbackBlock = new Span<byte>(feedbackPtr, AesCore.BlockSizeBytes);

            if (_encrypting)
            {
                // XOR plaintext with previous ciphertext (or IV)
                Span<byte> xored = stackalloc byte[BlockSize];
                for (int i = 0; i < BlockSize; i++)
                {
                    xored[i] = (byte)(input[i] ^ feedbackBlock[i]);
                }

                // Encrypt
                EncryptBlockDispatch(xored, output);

                // Save ciphertext for next block
                output.Slice(0, BlockSize).CopyTo(feedbackBlock);
            }
            else
            {
                // Save input ciphertext for next block's XOR
                Span<byte> savedInput = stackalloc byte[BlockSize];
                input.CopyTo(savedInput);

                // Decrypt
                DecryptBlockDispatch(input, output);

                // XOR with previous ciphertext (or IV)
                for (int i = 0; i < BlockSize; i++)
                {
                    output[i] ^= feedbackBlock[i];
                }

                // Save ciphertext for next block
                savedInput.CopyTo(feedbackBlock);
            }
        }
    }

    // ========================================================================
    // CTR Mode
    // ========================================================================

    private void TransformBlockCtr(ReadOnlySpan<byte> input, Span<byte> output)
    {
        fixed (byte* counterPtr = _buffers.Counter)
        {
            var counter = new Span<byte>(counterPtr, AesCore.BlockSizeBytes);

            // Encrypt counter to get keystream
            Span<byte> keystream = stackalloc byte[BlockSize];
            EncryptBlockDispatch(counter, keystream);

            // XOR with input
            for (int i = 0; i < BlockSize; i++)
            {
                output[i] = (byte)(input[i] ^ keystream[i]);
            }

            // Increment counter
            IncrementCounter(counter);
        }
    }

    /// <summary>
    /// Increments the counter for CTR mode (big-endian increment).
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void IncrementCounter(Span<byte> counter)
    {
        // Increment as big-endian 128-bit integer
        for (int i = BlockSize - 1; i >= 0; i--)
        {
            if (++counter[i] != 0)
            {
                break;
            }
        }
    }

    // ========================================================================
    // AES-NI Dispatch
    // ========================================================================

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void EncryptBlockDispatch(ReadOnlySpan<byte> input, Span<byte> output)
    {
        fixed (uint* p = _buffers.Keys)
        {
            var roundKeys = new ReadOnlySpan<uint>(p, MaxRoundKeyWords);
#if NET8_0_OR_GREATER
            if (_useAesNi)
            {
                AesCoreAesNi.EncryptBlock(input, output,
                    MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), _rounds);
                return;
            }
#endif
            AesCore.EncryptBlock(input, output, roundKeys, _rounds);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void DecryptBlockDispatch(ReadOnlySpan<byte> input, Span<byte> output)
    {
        fixed (uint* p = _buffers.Keys)
        {
            var roundKeys = new ReadOnlySpan<uint>(p, MaxRoundKeyWords);
#if NET8_0_OR_GREATER
            if (_useAesNi)
            {
                AesCoreAesNi.DecryptBlock(input, output,
                    MemoryMarshal.Cast<uint, Vector128<byte>>(roundKeys), _rounds);
                return;
            }
#endif
            AesCore.DecryptBlock(input, output, roundKeys, _rounds);
        }
    }
}
