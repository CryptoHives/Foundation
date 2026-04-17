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
    private readonly SimdSupport _simdSupport;
    private readonly CipherMode _mode;
    private readonly bool _encrypting;

    /// <summary>
    /// Initializes a new instance of the <see cref="Sm4CipherTransform"/> class.
    /// </summary>
    /// <param name="simdSupport">The SIMD instruction sets to use.</param>
    /// <param name="key">The 16-byte cipher key.</param>
    /// <param name="iv">The initialization vector.</param>
    /// <param name="encrypting">True for encryption, false for decryption.</param>
    /// <param name="mode">The cipher mode.</param>
    /// <param name="padding">The padding mode.</param>
    public Sm4CipherTransform(SimdSupport simdSupport, ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding)
        : base(iv, encrypting, mode, padding)
    {
        _core = new Sm4Core(key, simdSupport);
        _simdSupport = simdSupport & Sm4Core.SimdSupport;
        _mode = mode;
        _encrypting = encrypting;
    }

#if NET8_0_OR_GREATER
    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    public override int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        // Use the 4-block parallel NEON path for ECB mode when at least 4 blocks are
        // available and NEON is active. CBC/CTR have sequential feedback dependencies
        // that prevent independent block parallelism at this level; fall through to the
        // base-class sequential dispatch for those modes.
        if (_mode == CipherMode.ECB && (_simdSupport & SimdSupport.Neon) != 0)
            return TransformEcbNeon(input, output);

        return base.TransformBlock(input, output);
    }

    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    private int TransformEcbNeon(ReadOnlySpan<byte> input, Span<byte> output)
    {
        if (input.Length < Sm4Core.BlockSizeBytes)
            throw new ArgumentException("Input must be at least one block.", nameof(input));
        if (output.Length < Sm4Core.BlockSizeBytes)
            throw new ArgumentException("Output buffer too small.", nameof(output));

        int blocks = input.Length / Sm4Core.BlockSizeBytes;
        int offset = 0;

        // Process full 4-block batches with the NEON parallel path.
        int batches = blocks / Sm4Core.NeonParallelBlocks;
        for (int b = 0; b < batches; b++, offset += Sm4Core.NeonParallelBlocks * Sm4Core.BlockSizeBytes)
        {
            var inSlice  = input[offset..];
            var outSlice = output[offset..];
            if (_encrypting)
                _core.EncryptBlocks4(inSlice, outSlice);
            else
                _core.DecryptBlocks4(inSlice, outSlice);
        }

        // Process any remaining blocks (0–3) with the single-block path.
        int remaining = blocks % Sm4Core.NeonParallelBlocks;
        for (int r = 0; r < remaining; r++, offset += Sm4Core.BlockSizeBytes)
        {
            var inBlock  = input.Slice(offset, Sm4Core.BlockSizeBytes);
            var outBlock = output.Slice(offset, Sm4Core.BlockSizeBytes);
            if (_encrypting)
                _core.EncryptBlock(inBlock, outBlock);
            else
                _core.DecryptBlock(inBlock, outBlock);
        }

        return offset;
    }
#endif

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
