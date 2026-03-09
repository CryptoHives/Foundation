// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;

/// <summary>
/// Kalyna cipher transform for encryption or decryption operations.
/// </summary>
internal sealed class KalynaCipherTransform : BlockCipherTransform
{
    private readonly byte[] _roundKeys;
    private readonly int _rounds;
    private readonly bool _encrypting;

    /// <summary>
    /// Initializes a new instance of the <see cref="KalynaCipherTransform"/> class.
    /// </summary>
    public KalynaCipherTransform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding)
        : base(iv, encrypting, mode, padding)
    {
        _encrypting = encrypting;
        _roundKeys = new byte[15 * 16]; // Max: 14 rounds + 1 = 15 round keys
        _rounds = KalynaCore.ExpandKey(key, _roundKeys);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        KalynaCore.EncryptBlock(input, output, _roundKeys, _rounds);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        KalynaCore.DecryptBlock(input, output, _roundKeys, _rounds);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        Array.Clear(_roundKeys, 0, _roundKeys.Length);
    }
}
