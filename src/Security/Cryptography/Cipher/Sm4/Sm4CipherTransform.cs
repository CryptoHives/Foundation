// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// SM4 cipher transform for encryption or decryption operations.
/// </summary>
/// <remarks>
/// <para>
/// This class extends <see cref="BlockCipherTransform"/> to provide SM4 block cipher
/// operations. It supports ECB, CBC, and CTR modes with PKCS#7 padding.
/// </para>
/// <para>
/// For decryption, the same round function is used with round keys applied in
/// reverse order (rk[31] through rk[0]).
/// </para>
/// </remarks>
internal sealed class Sm4CipherTransform : BlockCipherTransform
{
    private readonly uint[] _roundKeys = new uint[Sm4Core.Rounds];
    private readonly bool _encrypting;

    /// <summary>
    /// Initializes a new instance of the <see cref="Sm4CipherTransform"/> class.
    /// </summary>
    /// <param name="key">The 16-byte cipher key.</param>
    /// <param name="iv">The initialization vector.</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    public Sm4CipherTransform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding)
        : base(iv, encrypting, mode, padding)
    {
        _encrypting = encrypting;
        Sm4Core.ExpandKey(key, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        Sm4Core.EncryptBlock(input, output, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        Sm4Core.DecryptBlock(input, output, _roundKeys);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        Array.Clear(_roundKeys, 0, _roundKeys.Length);
    }
}
