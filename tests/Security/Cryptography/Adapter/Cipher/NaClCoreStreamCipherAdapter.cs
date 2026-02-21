// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Cipher;

using CryptoHives.Foundation.Security.Cryptography.Cipher;
using System;
using NC = NaCl.Core;
using OS = System.Security.Cryptography;

/// <summary>
/// Wraps NaCl.Core's <see cref="NC.ChaCha20"/> as a CryptoHives <see cref="SymmetricCipher"/>.
/// </summary>
/// <remarks>
/// <para>
/// NaCl.Core provides a managed ChaCha20 stream cipher implementation.
/// This adapter bridges the NaCl.Core <see cref="NaCl.Core.Base.Snuffle"/> API to the
/// CryptoHives <see cref="SymmetricCipher"/> contract for cross-validation and benchmarking.
/// </para>
/// <para>
/// A new <see cref="NC.ChaCha20"/> instance is created per transform because
/// NaCl.Core does not expose a re-keying or reset mechanism.
/// </para>
/// </remarks>
internal sealed class NaClCoreStreamCipherAdapter : SymmetricCipher
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NaClCoreStreamCipherAdapter"/> class.
    /// </summary>
    public NaClCoreStreamCipherAdapter()
    {
        KeySizeValue = 256;
        BlockSizeValue = 8;
        LegalKeySizesValue = [new OS.KeySizes(256, 256, 0)];
        Mode = CipherMode.Stream;
        Padding = PaddingMode.None;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "ChaCha20 (NaCl.Core)";

    /// <inheritdoc/>
    public override int IVSize => 12;

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherEncryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
        => new NaClCoreChaCha20Transform(key, iv, (int)InitialCounter);

    /// <inheritdoc/>
    protected override ICipherTransform CreateCipherDecryptor(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv)
        => new NaClCoreChaCha20Transform(key, iv, (int)InitialCounter);

    /// <summary>
    /// Wraps NaCl.Core ChaCha20 encrypt/decrypt as an <see cref="ICipherTransform"/>.
    /// </summary>
    /// <remarks>
    /// ChaCha20 is symmetric — encryption and decryption are the same XOR operation.
    /// </remarks>
    private sealed class NaClCoreChaCha20Transform : ICipherTransform
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;
        private readonly NC.ChaCha20 _cipher;

        public NaClCoreChaCha20Transform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, int initialCounter)
        {
            _key = new byte[key.Length];
            key.CopyTo(_key);
            if (iv.Length > 0)
            {
                _iv = new byte[iv.Length];
                iv.CopyTo(_iv);
            }
            else
            {
                _iv = Array.Empty<byte>();
            }
            _cipher = new NC.ChaCha20(new ReadOnlyMemory<byte>(_key), initialCounter: initialCounter);
        }

        /// <inheritdoc/>
        public int BlockSize => 1;

        /// <inheritdoc/>
        int OS.ICryptoTransform.InputBlockSize => 1;

        /// <inheritdoc/>
        int OS.ICryptoTransform.OutputBlockSize => 1;

        /// <inheritdoc/>
        bool OS.ICryptoTransform.CanTransformMultipleBlocks => true;

        /// <inheritdoc/>
        bool OS.ICryptoTransform.CanReuseTransform => true;

        /// <inheritdoc/>
        public int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
        {
            _cipher.Encrypt(input, _iv, output.Slice(0, input.Length));
            return input.Length;
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
        byte[] OS.ICryptoTransform.TransformFinalBlock(
            byte[] inputBuffer, int inputOffset, int inputCount)
        {
            byte[] output = new byte[inputCount];
            TransformBlock(
                inputBuffer.AsSpan(inputOffset, inputCount),
                output.AsSpan());
            return output;
        }

        /// <inheritdoc/>
        public void Reset() { }

        /// <inheritdoc/>
        public void Dispose()
        {
            Array.Clear(_key, 0, _key.Length);
            Array.Clear(_iv, 0, _iv.Length);
            _cipher.Dispose();
        }
    }
}
