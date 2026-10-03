// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable CA5358 // ECB here is a single-block primitive for BouncyCastle's GCM, not a mode of use.

namespace Cryptography.Tests.Adapter.Cipher;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using Grasshopper = OpenGost.Security.Cryptography.Grasshopper;
using OS = System.Security.Cryptography;

/// <summary>
/// OpenGost's Kuznyechik exposed as a BouncyCastle <see cref="IBlockCipher"/>, so BouncyCastle's
/// GCM can serve as the reference for Kuznyechik-GCM. BouncyCastle's C# port has no GOST R
/// 34.12-2015 engine of its own.
/// </summary>
internal sealed class OpenGostKuznyechikEngine : IBlockCipher, IDisposable
{
    private const int BlockSize = 16;

    private Grasshopper? _grasshopper;
    private OS.ICryptoTransform? _transform;

    /// <inheritdoc/>
    public string AlgorithmName => "Kuznyechik";

    /// <inheritdoc/>
    public int GetBlockSize() => BlockSize;

    /// <inheritdoc/>
    public void Init(bool forEncryption, ICipherParameters parameters)
    {
        if (parameters is not KeyParameter keyParameter)
            throw new ArgumentException("Expected a KeyParameter.", nameof(parameters));

        Dispose();
        _grasshopper = Grasshopper.Create();
        _grasshopper.Mode = OS.CipherMode.ECB;
        _grasshopper.Padding = OS.PaddingMode.None;
        _grasshopper.Key = keyParameter.GetKey();
        _transform = forEncryption ? _grasshopper.CreateEncryptor() : _grasshopper.CreateDecryptor();
    }

    /// <inheritdoc/>
    public int ProcessBlock(byte[] inBuf, int inOff, byte[] outBuf, int outOff)
    {
        if (_transform is null)
            throw new InvalidOperationException("Engine not initialised.");

        return _transform.TransformBlock(inBuf, inOff, BlockSize, outBuf, outOff);
    }

#if NET8_0_OR_GREATER
    /// <inheritdoc/>
    public int ProcessBlock(ReadOnlySpan<byte> input, Span<byte> output)
    {
        byte[] inBuf = input.Slice(0, BlockSize).ToArray();
        byte[] outBuf = new byte[BlockSize];
        ProcessBlock(inBuf, 0, outBuf, 0);
        outBuf.CopyTo(output);
        return BlockSize;
    }
#endif

    /// <inheritdoc/>
    public void Dispose()
    {
        _transform?.Dispose();
        _grasshopper?.Dispose();
        _transform = null;
        _grasshopper = null;
    }
}
