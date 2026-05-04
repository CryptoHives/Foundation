// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Foundation.Security.Cryptography.Cipher;

using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

/// <summary>
/// Kalyna cipher transform for encryption or decryption operations.
/// </summary>
internal sealed class KalynaCipherTransform : BlockCipherTransform
{
    private KalynaCore _core;

    /// <summary>
    /// Initializes a new instance of the <see cref="KalynaCipherTransform"/> class.
    /// </summary>
    public KalynaCipherTransform(ReadOnlySpan<byte> key, ReadOnlySpan<byte> iv, bool encrypting, CipherMode mode, PaddingMode padding)
        : base(iv, encrypting, mode, padding)
    {
        _core = KalynaCore.Create(key);
    }

    /// <inheritdoc/>
    public override int TransformBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        // Only the hot CBC path is overridden here; all other modes fall through to the base
        // class. This avoids per-block virtual dispatch, per-block stackalloc, and byte-by-byte
        // XOR by operating directly on ulong pairs in little-endian byte order.
        int blocks = input.Length / 16;
        if (CurrentMode != CipherMode.CBC || input.Length < 16 || output.Length < blocks * 16)
            return base.TransformBlock(input, output);
        Span<byte> fb = FeedbackSpan;

        if (IsEncrypting)
        {
            ulong fbk0 = BinaryPrimitives.ReadUInt64LittleEndian(fb);
            ulong fbk1 = BinaryPrimitives.ReadUInt64LittleEndian(fb.Slice(8));
            for (int i = 0; i < blocks; i++)
            {
                ReadOnlySpan<byte> inBlk = input.Slice(i * 16, 16);
                Span<byte> outBlk = output.Slice(i * 16, 16);
                ulong w0 = BinaryPrimitives.ReadUInt64LittleEndian(inBlk) ^ fbk0;
                ulong w1 = BinaryPrimitives.ReadUInt64LittleEndian(inBlk.Slice(8)) ^ fbk1;
                _core.EncryptBlock(ref w0, ref w1);
                BinaryPrimitives.WriteUInt64LittleEndian(outBlk, w0);
                BinaryPrimitives.WriteUInt64LittleEndian(outBlk.Slice(8), w1);
                fbk0 = w0;
                fbk1 = w1;
            }
            BinaryPrimitives.WriteUInt64LittleEndian(fb, fbk0);
            BinaryPrimitives.WriteUInt64LittleEndian(fb.Slice(8), fbk1);
        }
        else
        {
            ulong fbk0 = BinaryPrimitives.ReadUInt64LittleEndian(fb);
            ulong fbk1 = BinaryPrimitives.ReadUInt64LittleEndian(fb.Slice(8));
            for (int i = 0; i < blocks; i++)
            {
                ReadOnlySpan<byte> inBlk = input.Slice(i * 16, 16);
                Span<byte> outBlk = output.Slice(i * 16, 16);
                ulong in0 = BinaryPrimitives.ReadUInt64LittleEndian(inBlk);
                ulong in1 = BinaryPrimitives.ReadUInt64LittleEndian(inBlk.Slice(8));
                ulong w0 = in0, w1 = in1;
                _core.DecryptBlock(ref w0, ref w1);
                BinaryPrimitives.WriteUInt64LittleEndian(outBlk, w0 ^ fbk0);
                BinaryPrimitives.WriteUInt64LittleEndian(outBlk.Slice(8), w1 ^ fbk1);
                fbk0 = in0;
                fbk1 = in1;
            }
            BinaryPrimitives.WriteUInt64LittleEndian(fb, fbk0);
            BinaryPrimitives.WriteUInt64LittleEndian(fb.Slice(8), fbk1);
        }

        return blocks * 16;
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    protected override void EncryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        _core.EncryptBlock(input, output);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptionsEx.HotPath)]
    protected override void DecryptBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        _core.DecryptBlock(input, output);
    }

    /// <inheritdoc/>
    protected override void ClearState()
    {
        _core = default;
    }
}
