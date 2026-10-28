// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Camellia cipher transform for encryption or decryption operations.
/// </summary>
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
    /// <param name="feedbackSizeBytes">The CFB feedback size in bytes.</param>
    public CamelliaCipherTransform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv,
        bool encrypting, CipherMode mode, PaddingMode padding, int feedbackSizeBytes)
        : base(iv, encrypting, mode, padding, feedbackSizeBytes)
    {
        _subkeys = new ulong[CamelliaCore.MaxSubkeys];
        _rounds = CamelliaCore.ExpandKey(key, _subkeys);
    }

    /// <inheritdoc/>
    public override int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        // Only the hot CBC path is overridden here; all other modes fall through to the base
        // class, which handles them correctly. This avoids per-block virtual dispatch,
        // per-block stackalloc, and byte-by-byte XOR by operating directly on ulong pairs.
        int blocks = input.Length / 16;
        if (CurrentMode != CipherMode.CBC || input.Length < 16 || output.Length < blocks * 16)
        {
            return base.TransformBlock(input, output);
        }

        ReadOnlySpan<ulong> sk = _subkeys;
        int rds = _rounds;
        Span<byte> fb = FeedbackSpan;

        if (IsEncrypting)
        {
            BinarySpans.ReadUInt64PairBigEndian(fb, out ulong fbk0, out ulong fbk1);
            for (int i = 0; i < blocks; i++)
            {
                ReadOnlySpan<byte> inBlk = input.Slice(i * 16, 16);
                Span<byte> outBlk = output.Slice(i * 16, 16);
                BinarySpans.ReadUInt64PairBigEndian(inBlk, out ulong d1, out ulong d2);
                d1 ^= fbk0;
                d2 ^= fbk1;
                CamelliaCore.EncryptBlock(d1, d2, out ulong r1, out ulong r2, sk, rds);
                BinarySpans.WriteUInt64PairBigEndian(outBlk, r1, r2);
                fbk0 = r1;
                fbk1 = r2;
            }
            BinarySpans.WriteUInt64PairBigEndian(fb, fbk0, fbk1);
        }
        else
        {
            BinarySpans.ReadUInt64PairBigEndian(fb, out ulong fbk0, out ulong fbk1);
            for (int i = 0; i < blocks; i++)
            {
                ReadOnlySpan<byte> inBlk = input.Slice(i * 16, 16);
                Span<byte> outBlk = output.Slice(i * 16, 16);
                BinarySpans.ReadUInt64PairBigEndian(inBlk, out ulong in0, out ulong in1);
                CamelliaCore.DecryptBlock(in0, in1, out ulong r1, out ulong r2, sk, rds);
                BinarySpans.WriteUInt64PairBigEndian(outBlk, r1 ^ fbk0, r2 ^ fbk1);
                fbk0 = in0;
                fbk1 = in1;
            }
            BinarySpans.WriteUInt64PairBigEndian(fb, fbk0, fbk1);
        }

        return blocks * 16;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        CamelliaCore.EncryptBlock(input, output, _subkeys, _rounds);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.OptimizedLoop)]
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
