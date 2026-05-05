// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Runtime.CompilerServices;

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
/// <para>
/// When a NEON-capable SIMD path is selected, ECB mode uses a 4-block parallel
/// round loop that issues 128-bit XOR instructions across four independent cipher
/// blocks simultaneously, reducing instruction count for the state mixing step.
/// </para>
/// </remarks>
internal sealed class Sm4CipherTransform : BlockCipherTransform
{
    private Sm4Core _core;
    private readonly CipherMode _mode;
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
        _core = new Sm4Core(key);
        _mode = mode;
        _encrypting = encrypting;
    }

    /// <inheritdoc/>
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        _core.EncryptBlock(input, output);
    }

    /// <inheritdoc/>
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        _core.DecryptBlock(input, output);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        _core.Clear();
    }
}
