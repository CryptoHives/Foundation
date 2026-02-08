// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Adapter;

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;
#if NET6_0_OR_GREATER
using HA = CryptoHives.Foundation.Security.Cryptography.Hash;
#else
using HA = System.Security.Cryptography;
#endif

/// <summary>
/// Wraps a BouncyCastle <see cref="IDigest"/> as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// This adapter allows BouncyCastle digest implementations to be used interchangeably
/// with .NET <see cref="System.Security.Cryptography.HashAlgorithm"/> implementations in tests.
/// On .NET 6.0+ it derives from the CryptoHives base class to enable allocation-free
/// <c>TryComputeHash</c> via Span-based APIs.
/// </remarks>
internal sealed class BouncyCastleHashAdapter : HA.HashAlgorithm
{
    private readonly IDigest _digest;
    private readonly int _hashSizeBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleHashAdapter"/> class.
    /// </summary>
    /// <param name="digest">The BouncyCastle digest to wrap.</param>
    public BouncyCastleHashAdapter(IDigest digest)
    {
        _digest = digest ?? throw new ArgumentNullException(nameof(digest));
        _hashSizeBytes = digest.GetDigestSize();
        HashSizeValue = _hashSizeBytes * 8;
    }

#if NET6_0_OR_GREATER
    /// <inheritdoc/>
    public override string AlgorithmName => _digest.AlgorithmName;

    /// <inheritdoc/>
    public override int BlockSize => _digest.GetByteLength();

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source) => _digest.BlockUpdate(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        bytesWritten = _digest.DoFinal(destination);
        return true;
    }
#else
    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _digest.BlockUpdate(array, ibStart, cbSize);
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        byte[] hash = new byte[_hashSizeBytes];
        _digest.DoFinal(hash, 0);
        return hash;
    }
#endif

    /// <inheritdoc/>
    public override void Initialize() => _digest.Reset();

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _digest.Reset();
        }
        base.Dispose(disposing);
    }
}

/// <summary>
/// Wraps a BouncyCastle <see cref="IXof"/> (extendable output function) as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// This adapter allows BouncyCastle XOF implementations (SHAKE, etc.) to be used interchangeably
/// with .NET <see cref="System.Security.Cryptography.HashAlgorithm"/> implementations in tests.
/// </remarks>
internal sealed class BouncyCastleXofAdapter : HA.HashAlgorithm
{
    private readonly ShakeDigest _digest;
    private readonly int _outputBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleXofAdapter"/> class.
    /// </summary>
    /// <param name="digest">The BouncyCastle SHAKE digest to wrap.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public BouncyCastleXofAdapter(ShakeDigest digest, int outputBytes)
    {
        _digest = digest ?? throw new ArgumentNullException(nameof(digest));
        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
    }

#if NET6_0_OR_GREATER
    /// <inheritdoc/>
    public override string AlgorithmName => _digest.AlgorithmName;

    /// <inheritdoc/>
    public override int BlockSize => _digest.GetByteLength();

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source) => _digest.BlockUpdate(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        _digest.OutputFinal(destination[.._outputBytes]);
        bytesWritten = _outputBytes;
        return true;
    }
#else
    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _digest.BlockUpdate(array, ibStart, cbSize);
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        byte[] hash = new byte[_outputBytes];
        _digest.OutputFinal(hash, 0, _outputBytes);
        return hash;
    }
#endif

    /// <inheritdoc/>
    public override void Initialize() => _digest.Reset();

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _digest.Reset();
        }
        base.Dispose(disposing);
    }
}

/// <summary>
/// Wraps a BouncyCastle cSHAKE digest as a <see cref="HashAlgorithmBase"/>.
/// </summary>
internal sealed class BouncyCastleCShakeAdapter : HA.HashAlgorithm
{
    private readonly CShakeDigest _digest;
    private readonly int _outputBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleCShakeAdapter"/> class.
    /// </summary>
    /// <param name="bitStrength">The bit strength (128 or 256).</param>
    /// <param name="functionName">The function name (N).</param>
    /// <param name="customization">The customization string (S).</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public BouncyCastleCShakeAdapter(int bitStrength, byte[]? functionName, byte[]? customization, int outputBytes)
    {
        _digest = new CShakeDigest(bitStrength, functionName, customization);
        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
    }

#if NET6_0_OR_GREATER
    /// <inheritdoc/>
    public override string AlgorithmName => _digest.AlgorithmName;

    /// <inheritdoc/>
    public override int BlockSize => _digest.GetByteLength();

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source) => _digest.BlockUpdate(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        _digest.OutputFinal(destination[.._outputBytes]);
        bytesWritten = _outputBytes;
        return true;
    }
#else
    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _digest.BlockUpdate(array, ibStart, cbSize);
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        byte[] hash = new byte[_outputBytes];
        _digest.OutputFinal(hash, 0, _outputBytes);
        return hash;
    }
#endif

    /// <inheritdoc/>
    public override void Initialize() => _digest.Reset();

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _digest.Reset();
        }
        base.Dispose(disposing);
    }
}

/// <summary>
/// Wraps a BouncyCastle KMAC as a keyed hash algorithm adapter.
/// </summary>
internal sealed class BouncyCastleKMacAdapter : HA.HashAlgorithm
{
    private readonly KMac _kmac;
    private readonly int _outputBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleKMacAdapter"/> class.
    /// </summary>
    /// <param name="bitStrength">The bit strength (128 or 256).</param>
    /// <param name="key">The key.</param>
    /// <param name="customization">The customization string (S).</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public BouncyCastleKMacAdapter(int bitStrength, byte[] key, byte[]? customization, int outputBytes)
    {
        _kmac = new KMac(bitStrength, customization ?? []);
        _kmac.Init(new KeyParameter(key));
        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
    }

#if NET6_0_OR_GREATER
    /// <inheritdoc/>
    public override string AlgorithmName => _kmac.AlgorithmName;

    /// <inheritdoc/>
    public override int BlockSize => _kmac.GetByteLength();

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source) => _kmac.BlockUpdate(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        _kmac.DoFinal(destination[.._outputBytes]);
        bytesWritten = _outputBytes;
        return true;
    }
#else
    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _kmac.BlockUpdate(array, ibStart, cbSize);
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        byte[] hash = new byte[_outputBytes];
        _kmac.DoFinal(hash, 0);
        return hash;
    }
#endif

    /// <inheritdoc/>
    public override void Initialize() => _kmac.Reset();

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _kmac.Reset();
        }
        base.Dispose(disposing);
    }
}

/// <summary>
/// Wraps a BouncyCastle <see cref="IXof"/> (extendable output function) as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// This adapter allows any BouncyCastle XOF implementations (Ascon-Xof, etc.) to be used interchangeably
/// with .NET <see cref="System.Security.Cryptography.HashAlgorithm"/> implementations in tests.
/// </remarks>
internal sealed class BouncyCastleGenericXofAdapter : HA.HashAlgorithm
{
    private readonly IXof _xof;
    private readonly int _outputBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleGenericXofAdapter"/> class.
    /// </summary>
    /// <param name="xof">The BouncyCastle XOF to wrap.</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public BouncyCastleGenericXofAdapter(IXof xof, int outputBytes)
    {
        _xof = xof ?? throw new ArgumentNullException(nameof(xof));
        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
    }

#if NET6_0_OR_GREATER
    /// <inheritdoc/>
    public override string AlgorithmName => _xof.AlgorithmName;

    /// <inheritdoc/>
    public override int BlockSize => _xof.GetByteLength();

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source) => _xof.BlockUpdate(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        _xof.OutputFinal(destination[.._outputBytes]);
        bytesWritten = _outputBytes;
        return true;
    }
#else
    /// <inheritdoc/>
    protected override void HashCore(byte[] array, int ibStart, int cbSize)
    {
        _xof.BlockUpdate(array, ibStart, cbSize);
    }

    /// <inheritdoc/>
    protected override byte[] HashFinal()
    {
        byte[] hash = new byte[_outputBytes];
        _xof.OutputFinal(hash, 0, _outputBytes);
        return hash;
    }
#endif

    /// <inheritdoc/>
    public override void Initialize() => _xof.Reset();

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _xof.Reset();
        }
        base.Dispose(disposing);
    }
}

