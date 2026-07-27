// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter.Mac;

using CryptoHives.Foundation.Security.Cryptography.Mac;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Security.Cryptography;
using BcMac = Org.BouncyCastle.Crypto.IMac;

/// <summary>
/// Wraps a .NET built-in <see cref="HMAC"/> as an <see cref="IMac"/> for comparison
/// against CryptoHives HMAC implementations.
/// </summary>
internal sealed class SystemHmacAdapter : IMac
{
    private readonly HMAC _hmac;

    /// <summary>
    /// Initializes a new instance of the <see cref="SystemHmacAdapter"/> class.
    /// </summary>
    /// <param name="hmac">The .NET built-in HMAC instance to wrap.</param>
    public SystemHmacAdapter(HMAC hmac) => _hmac = hmac ?? throw new ArgumentNullException(nameof(hmac));

    /// <inheritdoc/>
    public string AlgorithmName => _hmac.GetType().Name;

    /// <inheritdoc/>
    public int MacSize => _hmac.HashSize / 8;

    /// <inheritdoc/>
    public void Update(ReadOnlySpan<byte> input)
    {
        byte[] buffer = input.ToArray();
        _hmac.TransformBlock(buffer, 0, buffer.Length, null, 0);
    }

    /// <inheritdoc/>
    public void Finalize(Span<byte> destination)
    {
        _hmac.TransformFinalBlock([], 0, 0);
        _hmac.Hash.CopyTo(destination);
    }

    /// <inheritdoc/>
    public void Reset() => _hmac.Initialize();

    /// <inheritdoc/>
    public void Dispose() => _hmac.Dispose();
}

/// <summary>
/// Wraps a BouncyCastle <see cref="BcMac"/> as an <see cref="IMac"/> for comparison
/// against CryptoHives MAC implementations.
/// </summary>
internal sealed class BouncyCastleMacAdapter : IMac
{
    private readonly BcMac _mac;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleMacAdapter"/> class.
    /// </summary>
    /// <param name="mac">The BouncyCastle MAC instance to wrap.</param>
    /// <param name="key">The secret key.</param>
    public BouncyCastleMacAdapter(BcMac mac, byte[] key)
    {
        _mac = mac ?? throw new ArgumentNullException(nameof(mac));
        _mac.Init(new KeyParameter(key));
    }

    /// <inheritdoc/>
    public string AlgorithmName => _mac.AlgorithmName;

    /// <inheritdoc/>
    public int MacSize => _mac.GetMacSize();

    /// <inheritdoc/>
    public void Update(ReadOnlySpan<byte> input)
    {
#if NET6_0_OR_GREATER
        _mac.BlockUpdate(input);
#else
        byte[] buffer = input.ToArray();
        _mac.BlockUpdate(buffer, 0, buffer.Length);
#endif
    }

    /// <inheritdoc/>
    public void Finalize(Span<byte> destination)
    {
#if NET6_0_OR_GREATER
        _mac.DoFinal(destination);
#else
        byte[] result = new byte[MacSize];
        _mac.DoFinal(result, 0);
        result.CopyTo(destination);
#endif
    }

    /// <inheritdoc/>
    public void Reset() => _mac.Reset();

    /// <inheritdoc/>
    public void Dispose() { }
}
