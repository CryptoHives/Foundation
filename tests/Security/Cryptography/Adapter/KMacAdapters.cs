// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET9_0_OR_GREATER

using System;

/// <summary>
/// Adapter to wrap .NET 9+ Kmac128 as a HashAlgorithm for testing and benchmarking.
/// </summary>
internal sealed class Kmac128HashAdapter : System.Security.Cryptography.HashAlgorithm
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

    public override void Initialize() => _buffer.SetLength(0);

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
        => _buffer.Write(array, ibStart, cbSize);

    protected override byte[] HashFinal()
    {
        var output = new byte[_outputLength];
        System.Security.Cryptography.Kmac128.HashData(_key, _buffer.ToArray(), output, _customization);
        return output;
    }

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
/// Adapter to wrap .NET 9+ Kmac256 as a HashAlgorithm for testing and benchmarking.
/// </summary>
internal sealed class Kmac256HashAdapter : System.Security.Cryptography.HashAlgorithm
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

    public override void Initialize() => _buffer.SetLength(0);

    protected override void HashCore(byte[] array, int ibStart, int cbSize)
        => _buffer.Write(array, ibStart, cbSize);

    protected override byte[] HashFinal()
    {
        var output = new byte[_outputLength];
        System.Security.Cryptography.Kmac256.HashData(_key, _buffer.ToArray(), output, _customization);
        return output;
    }

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
