// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// SEED cipher transform for encryption or decryption operations.
/// </summary>
/// <remarks>
/// <para>
/// This class extends <see cref="BlockCipherTransform"/> to provide SEED block cipher
/// operations. It supports ECB, CBC, and CTR modes with PKCS#7 padding.
/// </para>
/// <para>
/// For decryption, the same round function is used with round keys applied in
/// reverse order.
/// </para>
/// </remarks>
internal sealed class SeedCipherTransform : BlockCipherTransform
{
    private readonly uint[] _roundKeys = new uint[SeedCore.RoundKeyWords];

    /// <summary>
    /// Initializes a new instance of the <see cref="SeedCipherTransform"/> class.
    /// </summary>
    /// <param name="key">The 16-byte cipher key.</param>
    /// <param name="iv">The initialization vector.</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    public SeedCipherTransform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding)
        : base(iv, encrypting, mode, padding)
    {
        SeedCore.ExpandKey(key, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        SeedCore.EncryptBlock(input, output, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        SeedCore.DecryptBlock(input, output, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        Array.Clear(_roundKeys, 0, _roundKeys.Length);
    }
}
