// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// Runs AES through the generic <see cref="BlockCipherTransform"/> mode dispatch, for the modes
/// that have no dedicated path in <see cref="AesCipherTransform"/>.
/// </summary>
internal sealed class AesGenericModeTransform : BlockCipherTransform
{
    private readonly AesCipherTransform _block;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGenericModeTransform"/> class.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction set to use.</param>
    /// <param name="key">The cipher key.</param>
    /// <param name="iv">The initialization vector.</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    /// <param name="feedbackSizeBytes">The CFB feedback size in bytes.</param>
    public AesGenericModeTransform(SimdSupport simdSupport, ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding, int feedbackSizeBytes)
        : base(iv, encrypting, mode, padding, feedbackSizeBytes, AesCore.BlockSizeBytes)
    {
        // An ECB transform holds one key schedule, so it serves only the direction the mode needs.
        _block = new AesCipherTransform(simdSupport, key, default, !NeedsInverseCipher(encrypting, mode), CipherMode.ECB, PaddingMode.None);
    }

    /// <inheritdoc/>
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
        => _block.TransformBlock(input, output);

    /// <inheritdoc/>
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
        => _block.TransformBlock(input, output);

    /// <inheritdoc/>
    protected override void ClearState()
        => _block.Dispose();
}
