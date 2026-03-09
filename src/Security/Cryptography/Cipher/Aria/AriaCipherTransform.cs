// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// ARIA cipher transform for encryption or decryption operations.
/// </summary>
internal sealed class AriaCipherTransform : BlockCipherTransform
{
    private readonly byte[] _roundKeys;
    private readonly int _rounds;

    /// <summary>
    /// Initializes a new instance of the <see cref="AriaCipherTransform"/> class.
    /// </summary>
    public AriaCipherTransform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding)
        : base(iv, encrypting, mode, padding)
    {
        // Max round keys: (16+1) * 16 = 272 bytes
        byte[] encKeys = new byte[17 * 16];
        _rounds = AriaCore.ExpandKey(key, encKeys);

        if (!encrypting && mode != CipherMode.CTR)
        {
            _roundKeys = new byte[(_rounds + 1) * 16];
            AriaCore.CreateDecryptionKeys(encKeys, _roundKeys, _rounds);
            Array.Clear(encKeys, 0, encKeys.Length);
        }
        else
        {
            _roundKeys = encKeys;
        }
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        AriaCore.EncryptBlock(input, output, _roundKeys, _rounds);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        AriaCore.EncryptBlock(input, output, _roundKeys, _rounds);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        Array.Clear(_roundKeys, 0, _roundKeys.Length);
    }
}
