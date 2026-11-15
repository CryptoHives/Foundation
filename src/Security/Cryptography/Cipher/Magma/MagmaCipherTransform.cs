// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.InteropServices;

/// <summary>
/// Magma cipher transform for encryption or decryption operations.
/// </summary>
internal sealed class MagmaCipherTransform : BlockCipherTransform
{
    private readonly uint[] _roundKeys = new uint[MagmaCore.RoundKeyCount];

    /// <summary>
    /// Initializes a new instance of the <see cref="MagmaCipherTransform"/> class.
    /// </summary>
    /// <param name="key">The 32-byte cipher key.</param>
    /// <param name="iv">The 8-byte initialization vector.</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    /// <param name="feedbackSizeBytes">The CFB feedback size in bytes.</param>
    public MagmaCipherTransform(
        ReadOnlySpan<byte> key,
        ReadOnlySpan<byte> iv,
        bool encrypting,
        CipherMode mode,
        PaddingMode padding,
        int feedbackSizeBytes)
        : base(iv, encrypting, mode, padding, feedbackSizeBytes, MagmaCore.BlockSizeBytes)
    {
        MagmaCore.ExpandKey(key, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        MagmaCore.EncryptBlock(input, output, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        MagmaCore.DecryptBlock(input, output, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        CryptographicOperations.ZeroMemory(MemoryMarshal.AsBytes(_roundKeys.AsSpan()));
    }
}
