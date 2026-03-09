// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;

/// <summary>
/// Camellia cipher transform for encryption or decryption operations.
/// </summary>
/// <remarks>
/// <para>
/// This class extends <see cref="BlockCipherTransform"/> to provide Camellia block
/// cipher operations. It supports ECB, CBC, and CTR modes with PKCS#7 padding.
/// </para>
/// </remarks>
internal sealed class CamelliaCipherTransform : BlockCipherTransform
{
    private readonly ulong[] _subkeys;
    private readonly int _rounds;

    /// <summary>
    /// Initializes a new instance of the <see cref="CamelliaCipherTransform"/> class.
    /// </summary>
    /// <param name="key">The cipher key (16, 24, or 32 bytes).</param>
    /// <param name="iv">The initialization vector (16 bytes).</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    public CamelliaCipherTransform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv,
        bool encrypting, CipherMode mode, PaddingMode padding)
        : base(iv, encrypting, mode, padding)
    {
        _subkeys = new ulong[CamelliaCore.MaxSubkeys];
        _rounds = CamelliaCore.ExpandKey(key, _subkeys);
    }

    /// <inheritdoc/>
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        CamelliaCore.EncryptBlock(input, output, _subkeys, _rounds);
    }

    /// <inheritdoc/>
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        CamelliaCore.DecryptBlock(input, output, _subkeys, _rounds);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        Array.Clear(_subkeys, 0, _subkeys.Length);
    }
}
