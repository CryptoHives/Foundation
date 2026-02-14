// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Security.Cryptography;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Wraps a BouncyCastle <see cref="IXof"/> as an <see cref="IExtendableOutput"/> for XOF benchmarking.
/// </summary>
/// <remarks>
/// Uses <see cref="IXof.OutputFinal(Span{byte})"/> which combines squeeze and reset in a single call.
/// Works for <c>ShakeDigest</c>, <c>CShakeDigest</c>, <c>Blake3Digest</c>, <c>AsconXof128</c>,
/// and any other BouncyCastle type implementing <see cref="IXof"/>.
/// </remarks>
internal sealed class BouncyCastleIXofAdapter : CH.Hash.IExtendableOutput, IDisposable
{
    private readonly IXof _xof;

    public BouncyCastleIXofAdapter(IXof xof) => _xof = xof ?? throw new ArgumentNullException(nameof(xof));

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input)
    {
#if NET6_0_OR_GREATER
        _xof.BlockUpdate(input);
#else
        var arr = input.ToArray();
        _xof.BlockUpdate(arr, 0, arr.Length);
#endif
    }

    /// <inheritdoc/>
    public void Squeeze(Span<byte> output)
    {
#if NET6_0_OR_GREATER
        _xof.OutputFinal(output);
#else
        var arr = new byte[output.Length];
        _xof.OutputFinal(arr, 0, arr.Length);
        arr.AsSpan().CopyTo(output);
#endif
    }

    /// <inheritdoc/>
    public void Reset() { }

    /// <inheritdoc/>
    public void Dispose() => _xof.Reset();
}

/// <summary>
/// Wraps a BouncyCastle <see cref="KMac"/> as an <see cref="IExtendableOutput"/> for XOF benchmarking.
/// </summary>
/// <remarks>
/// Requires key initialization via constructor. Casts <see cref="KMac"/> to <see cref="IXof"/>
/// for squeeze output.
/// </remarks>
internal sealed class BouncyCastleKMacXofAdapter : CH.Hash.IExtendableOutput, IDisposable
{
    private readonly KMac _kmac;

    public BouncyCastleKMacXofAdapter(int bitStrength, byte[] key, byte[] customization)
    {
        _kmac = new KMac(bitStrength, customization);
        _kmac.Init(new KeyParameter(key));
    }

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input)
    {
#if NET6_0_OR_GREATER
        _kmac.BlockUpdate(input);
#else
        var arr = input.ToArray();
        _kmac.BlockUpdate(arr, 0, arr.Length);
#endif
    }

    /// <inheritdoc/>
    public void Squeeze(Span<byte> output)
    {
#if NET6_0_OR_GREATER
        _kmac.OutputFinal(output);
#else
        var arr = new byte[output.Length];
        _kmac.OutputFinal(arr, 0, arr.Length);
        arr.AsSpan().CopyTo(output);
#endif
    }

    /// <inheritdoc/>
    public void Reset() { }

    /// <inheritdoc/>
    public void Dispose() => _kmac.Reset();
}

#if NET8_0_OR_GREATER
/// <summary>
/// Wraps .NET <see cref="Shake128"/> or
/// <see cref="Shake256"/> static one-shot API
/// as an <see cref="IExtendableOutput"/> for XOF benchmarking.
/// </summary>
/// <remarks>
/// Buffers absorbed input and calls the static <c>HashData</c> method during squeeze.
/// The buffer is allocated once during warmup and reused across benchmark iterations.
/// </remarks>
internal sealed class OsShakeXofAdapter : CH.Hash.IExtendableOutput, IDisposable
{
    private readonly int _bitStrength;
    private byte[] _buffer;
    private int _absorbed;

    public OsShakeXofAdapter(int bitStrength)
    {
        _bitStrength = bitStrength;
        _buffer = new byte[8192];
    }

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input)
    {
        int required = _absorbed + input.Length;
        if (_buffer.Length < required)
        {
            Array.Resize(ref _buffer, required);
        }

        input.CopyTo(_buffer.AsSpan(_absorbed));
        _absorbed += input.Length;
    }

    /// <inheritdoc/>
    public void Squeeze(Span<byte> output)
    {
        var input = _buffer.AsSpan(0, _absorbed);
        if (_bitStrength == 128)
        {
            Shake128.HashData(input, output);
        }
        else
        {
            Shake256.HashData(input, output);
        }
    }

    /// <inheritdoc/>
    public void Reset() => _absorbed = 0;

    /// <inheritdoc/>
    public void Dispose() { }
}
#endif

#if NET9_0_OR_GREATER
/// <summary>
/// Wraps .NET <see cref="Kmac128"/> or
/// <see cref="Kmac256"/> static one-shot API
/// as an <see cref="IExtendableOutput"/> for XOF benchmarking.
/// </summary>
/// <remarks>
/// Buffers absorbed input and calls the static <c>HashData</c> method during squeeze.
/// The buffer is allocated once during warmup and reused across benchmark iterations.
/// </remarks>
internal sealed class OsKmacXofAdapter : CH.Hash.IExtendableOutput, IDisposable
{
    private readonly int _bitStrength;
    private readonly byte[] _key;
    private readonly byte[] _customization;
    private byte[] _buffer;
    private int _absorbed;

    public OsKmacXofAdapter(int bitStrength, byte[] key, byte[] customization)
    {
        _bitStrength = bitStrength;
        _key = key;
        _customization = customization;
        _buffer = new byte[8192];
    }

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input)
    {
        int required = _absorbed + input.Length;
        if (_buffer.Length < required)
        {
            Array.Resize(ref _buffer, required);
        }

        input.CopyTo(_buffer.AsSpan(_absorbed));
        _absorbed += input.Length;
    }

    /// <inheritdoc/>
    public void Squeeze(Span<byte> output)
    {
        var input = _buffer.AsSpan(0, _absorbed);
        if (_bitStrength == 128)
        {
            Kmac128.HashData(_key, input, output, _customization);
        }
        else
        {
            Kmac256.HashData(_key, input, output, _customization);
        }
    }

    /// <inheritdoc/>
    public void Reset() => _absorbed = 0;

    /// <inheritdoc/>
    public void Dispose() { }
}
#endif

#if BLAKE3_NATIVE
/// <summary>
/// Wraps the Blake3.NET native Rust implementation as an <see cref="IExtendableOutput"/>
/// for XOF benchmarking.
/// </summary>
/// <remarks>
/// Uses <c>Blake3.Hasher.Update</c> for absorb and <c>Blake3.Hasher.Finalize</c> for
/// variable-length squeeze output. The Rust backend supports arbitrary output length natively.
/// </remarks>
internal sealed class Blake3NativeXofAdapter : CH.Hash.IExtendableOutput, IDisposable
{
    private Blake3.Hasher _hasher;

    public Blake3NativeXofAdapter() => _hasher = Blake3.Hasher.New();

    /// <inheritdoc/>
    public void Absorb(ReadOnlySpan<byte> input) => _hasher.Update(input);

    /// <inheritdoc/>
    public void Squeeze(Span<byte> output) => _hasher.Finalize(output);

    /// <inheritdoc/>
    public void Reset() => _hasher.Reset();

    /// <inheritdoc/>
    public void Dispose() => _hasher.Reset();
}
#endif
