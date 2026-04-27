// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

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
    public override int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        // Only the hot CBC path is overridden here; all other modes fall through to the base
        // class, which handles them correctly. This avoids per-block virtual dispatch,
        // per-block stackalloc, and byte-by-byte XOR by operating directly on ulong pairs.
        int blocks = input.Length / 16;
        if (CurrentMode != CipherMode.CBC || input.Length < 16 || output.Length < blocks * 16)
            return base.TransformBlock(input, output);
        ReadOnlySpan<ulong> sk = _subkeys;
        int rds = _rounds;
        Span<byte> fb = FeedbackSpan;

        if (IsEncrypting)
        {
            ulong fbk0 = BinaryPrimitives.ReadUInt64BigEndian(fb);
            ulong fbk1 = BinaryPrimitives.ReadUInt64BigEndian(fb.Slice(8));
            for (int i = 0; i < blocks; i++)
            {
                ReadOnlySpan<byte> inBlk = input.Slice(i * 16, 16);
                Span<byte> outBlk = output.Slice(i * 16, 16);
                ulong d1 = BinaryPrimitives.ReadUInt64BigEndian(inBlk) ^ fbk0;
                ulong d2 = BinaryPrimitives.ReadUInt64BigEndian(inBlk.Slice(8)) ^ fbk1;
                CamelliaCore.EncryptBlock(d1, d2, out ulong r1, out ulong r2, sk, rds);
                BinaryPrimitives.WriteUInt64BigEndian(outBlk, r1);
                BinaryPrimitives.WriteUInt64BigEndian(outBlk.Slice(8), r2);
                fbk0 = r1;
                fbk1 = r2;
            }
            BinaryPrimitives.WriteUInt64BigEndian(fb, fbk0);
            BinaryPrimitives.WriteUInt64BigEndian(fb.Slice(8), fbk1);
        }
        else
        {
            ulong fbk0 = BinaryPrimitives.ReadUInt64BigEndian(fb);
            ulong fbk1 = BinaryPrimitives.ReadUInt64BigEndian(fb.Slice(8));
            for (int i = 0; i < blocks; i++)
            {
                ReadOnlySpan<byte> inBlk = input.Slice(i * 16, 16);
                Span<byte> outBlk = output.Slice(i * 16, 16);
                ulong in0 = BinaryPrimitives.ReadUInt64BigEndian(inBlk);
                ulong in1 = BinaryPrimitives.ReadUInt64BigEndian(inBlk.Slice(8));
                CamelliaCore.DecryptBlock(in0, in1, out ulong r1, out ulong r2, sk, rds);
                BinaryPrimitives.WriteUInt64BigEndian(outBlk, r1 ^ fbk0);
                BinaryPrimitives.WriteUInt64BigEndian(outBlk.Slice(8), r2 ^ fbk1);
                fbk0 = in0;
                fbk1 = in1;
            }
            BinaryPrimitives.WriteUInt64BigEndian(fb, fbk0);
            BinaryPrimitives.WriteUInt64BigEndian(fb.Slice(8), fbk1);
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
