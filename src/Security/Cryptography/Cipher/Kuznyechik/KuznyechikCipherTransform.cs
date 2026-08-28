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
    private readonly ulong[] _encryptKeys;
    private readonly ulong[] _decryptKeys;

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
        // Both schedules are derived up front rather than per direction: a transform is created
        // for one direction, but deriving the decryption keys costs nine L^(-1) evaluations once,
        // which is far below the cost of branching on direction in the block path.
        _encryptKeys = new ulong[KuznyechikCore.RoundKeyWordCount];
        _decryptKeys = new ulong[KuznyechikCore.RoundKeyWordCount];
        KuznyechikCore.ExpandKeySchedules(key, _encryptKeys, _decryptKeys);
    }

    /// <inheritdoc/>
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        KuznyechikCore.EncryptBlock(input, output, _encryptKeys);
    }

    /// <inheritdoc/>
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        KuznyechikCore.DecryptBlock(input, output, _decryptKeys);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        Array.Clear(_encryptKeys, 0, _encryptKeys.Length);
        Array.Clear(_decryptKeys, 0, _decryptKeys.Length);
    }
}
