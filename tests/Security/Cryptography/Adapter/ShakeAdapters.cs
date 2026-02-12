// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#if NET8_0_OR_GREATER

using CryptoHives.Foundation.Security.Cryptography.Hash;
using System;

/// <summary>
/// Adapter to wrap .NET Shake128 XOF as a HashAlgorithm for testing.
/// </summary>
internal sealed class Shake128HashAdapter : HashAlgorithm
{
    private int _outputLength;
    private byte[] _output;

    public Shake128HashAdapter(int outputLength)
    {
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
        _output = new byte[outputLength];
    }

    public override string AlgorithmName => "SHAKE128";

    public override int BlockSize => 1;

    public override void Initialize() => Array.Clear(_output);

    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        Span<byte> destination = _output;
        System.Security.Cryptography.Shake128.HashData(source, destination);
        _outputLength = destination.Length;
    }

    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputLength)
        {
            bytesWritten = 0;
            return false;
        }

        bytesWritten = _outputLength;
        _output.AsSpan().Slice(0, _outputLength).CopyTo(destination);
        return true;
    }
}

/// <summary>
/// Adapter to wrap .NET Shake128 XOF as a HashAlgorithm for testing.
/// </summary>
internal sealed class Shake256HashAdapter : HashAlgorithm
{
    private int _outputLength;
    private byte[] _output;

    public Shake256HashAdapter(int outputLength)
    {
        _outputLength = outputLength;
        HashSizeValue = outputLength * 8;
        _output = new byte[outputLength];
    }

    public override string AlgorithmName => "SHAKE256";

    public override int BlockSize => 1;

    public override void Initialize() => Array.Clear(_output);

    protected override void HashCore(ReadOnlySpan<byte> source)
    {
        Span<byte> destination = _output;
        System.Security.Cryptography.Shake256.HashData(source, destination);
        _outputLength = destination.Length;
    }

    protected override bool TryHashFinal(Span<byte> destination, out int bytesWritten)
    {
        if (destination.Length < _outputLength)
        {
            bytesWritten = 0;
            return false;
        }

        bytesWritten = _outputLength;
        _output.AsSpan().Slice(0, _outputLength).CopyTo(destination);
        return true;
    }
}
#endif

