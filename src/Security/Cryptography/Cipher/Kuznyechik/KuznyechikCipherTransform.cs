// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// Kuznyechik cipher transform for encryption or decryption operations.
/// </summary>
/// <remarks>
/// <para>
/// This class implements <see cref="BlockCipherTransform"/> for Kuznyechik block cipher operations.
/// It supports ECB, CBC, and CTR modes via the base class dispatch.
/// </para>
/// </remarks>
internal sealed class KuznyechikCipherTransform : BlockCipherTransform
{
    private readonly byte[] _roundKeys;

    /// <summary>
    /// Initializes a new instance of the <see cref="KuznyechikCipherTransform"/> class.
    /// </summary>
    /// <param name="key">The 32-byte cipher key.</param>
    /// <param name="iv">The 16-byte initialization vector.</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    public KuznyechikCipherTransform(
        ReadOnlySpan<byte> key,
        ReadOnlySpan<byte> iv,
        bool encrypting,
        CipherMode mode,
        PaddingMode padding)
        : base(iv, encrypting, mode, padding)
    {
        _roundKeys = new byte[KuznyechikCore.RoundKeysTotalBytes];
        KuznyechikCore.ExpandKey(key, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        KuznyechikCore.EncryptBlock(input, output, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        KuznyechikCore.DecryptBlock(input, output, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        Array.Clear(_roundKeys, 0, _roundKeys.Length);
    }
}
