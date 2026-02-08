// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET9_0_OR_GREATER

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// Adapter to wrap .NET 9+ Kmac128 as a <see cref="HashAlgorithm"/> for testing and benchmarking.
/// </summary>
internal sealed class Kmac128HashAdapter : HashAlgorithm
{
    private readonly byte[] _key;
    private readonly byte[] _customization;
    private readonly int _outputLength;
    private readonly System.IO.MemoryStream _buffer = new();

    public Kmac128HashAdapter(byte[] key, int outputLength, string customization = "")
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _customization = System.Text.Encoding.UTF8.GetBytes(customization ?? "");
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    public Kmac128HashAdapter(byte[] key, int outputLength, byte[] customization)
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _customization = customization ?? [];
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "KMAC128";

    /// <inheritdoc/>
    public override int BlockSize => 168;

    /// <inheritdoc/>
    public override void Initialize() => _buffer.SetLength(0);

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
        => _buffer.Write(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        System.Security.Cryptography.Kmac128.HashData(_key, _buffer.ToArray(), destination[.._outputLength], _customization);
        bytesWritten = _outputLength;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }

        base.Dispose(disposing);
    }
}

/// <summary>
/// Adapter to wrap .NET 9+ Kmac256 as a <see cref="HashAlgorithm"/> for testing and benchmarking.
/// </summary>
internal sealed class Kmac256HashAdapter : HashAlgorithm
{
    private readonly byte[] _key;
    private readonly byte[] _customization;
    private readonly int _outputLength;
    private readonly System.IO.MemoryStream _buffer = new();

    public Kmac256HashAdapter(byte[] key, int outputLength, string customization = "")
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _customization = System.Text.Encoding.UTF8.GetBytes(customization ?? "");
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    public Kmac256HashAdapter(byte[] key, int outputLength, byte[] customization)
    {
        _key = key ?? throw new ArgumentNullException(nameof(key));
        _customization = customization ?? [];
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
    }

    /// <inheritdoc/>
    public override string AlgorithmName => "KMAC256";

    /// <inheritdoc/>
    public override int BlockSize => 136;

    /// <inheritdoc/>
    public override void Initialize() => _buffer.SetLength(0);

    /// <inheritdoc/>
    protected override void HashCore(ReadOnlySpan<byte> source)
        => _buffer.Write(source);

    /// <inheritdoc/>
    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        System.Security.Cryptography.Kmac256.HashData(_key, _buffer.ToArray(), destination[.._outputLength], _customization);
        bytesWritten = _outputLength;
        return true;
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _buffer.Dispose();
        }

        base.Dispose(disposing);
    }
}
#endif
