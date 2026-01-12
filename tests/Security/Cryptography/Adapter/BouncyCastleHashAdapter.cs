// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests;

using System;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

/// <summary>
/// Wraps a BouncyCastle <see cref="IDigest"/> as a <see cref="HashAlgorithm"/>.
/// </summary>
/// <remarks>
/// This adapter allows BouncyCastle digest implementations to be used interchangeably
/// with .NET <see cref="HashAlgorithm"/> implementations in tests.
/// </remarks>
internal sealed class BouncyCastleHashAdapter : HashAlgorithm
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

    /// <inheritdoc/>
    public override void Initialize()
    {
        _digest.Reset();
    }

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
/// with .NET <see cref="HashAlgorithm"/> implementations in tests.
/// </remarks>
internal sealed class BouncyCastleXofAdapter : HashAlgorithm
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

    /// <inheritdoc/>
    public override void Initialize()
    {
        _digest.Reset();
    }

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
/// Wraps a BouncyCastle cSHAKE digest as a <see cref="HashAlgorithm"/>.
/// </summary>
internal sealed class BouncyCastleCShakeAdapter : HashAlgorithm
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

    /// <inheritdoc/>
    public override void Initialize()
    {
        _digest.Reset();
    }

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
internal sealed class BouncyCastleKmacAdapter : HashAlgorithm
{
    private readonly KMac _kmac;
    private readonly int _outputBytes;

    /// <summary>
    /// Initializes a new instance of the <see cref="BouncyCastleKmacAdapter"/> class.
    /// </summary>
    /// <param name="bitStrength">The bit strength (128 or 256).</param>
    /// <param name="key">The key.</param>
    /// <param name="customization">The customization string (S).</param>
    /// <param name="outputBytes">The desired output size in bytes.</param>
    public BouncyCastleKmacAdapter(int bitStrength, byte[] key, byte[]? customization, int outputBytes)
    {
        _kmac = new KMac(bitStrength, customization ?? []);
        _kmac.Init(new KeyParameter(key));
        _outputBytes = outputBytes;
        HashSizeValue = outputBytes * 8;
    }

    /// <inheritdoc/>
    public override void Initialize()
    {
        _kmac.Reset();
    }

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

// Note: BouncyCastle 2.6.2 does not include KangarooTwelve (K12).
// Tests use XKCP reference test vectors for verification.


