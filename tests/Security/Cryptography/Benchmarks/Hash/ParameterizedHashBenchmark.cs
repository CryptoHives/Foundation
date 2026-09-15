// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Hash;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CH = CryptoHives.Foundation.Security.Cryptography;

/// <summary>
/// Base class for parameterized hash algorithm benchmarks.
/// </summary>
/// <remarks>
/// Eliminates code duplication across benchmark classes by providing common setup and benchmark methods.
/// Derived classes only need to provide:
/// <list type="bullet">
/// <item><c>Algorithms()</c> static method returning algorithm variants</item>
/// <item><c>HashAlgorithmTypeArgs</c> for NUnit test fixture sources</item>
/// <item>BenchmarkCategory attributes for categorization</item>
/// </list>
/// </remarks>
public abstract class ParameterizedHashBenchmark : HashBenchmarkBase
{
    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource("Algorithms")]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    protected ParameterizedHashBenchmark() => TestDataSize = DataSize.K8;

    protected ParameterizedHashBenchmark(HashAlgorithmType hashAlgorithm)
    {
        TestDataSize = DataSize.K8;
        TestHashAlgorithm = hashAlgorithm;
    }

    public override void GlobalSetup()
    {
        Bytes = TestDataSize.Bytes;
        HashAlgorithm = TestHashAlgorithm.Create();
        base.GlobalSetup();
    }

    [Test, Repeat(5)]
    [FixtureDataSizeSource(nameof(Sizes))]
    public void TestComputeHash(DataSize dataSize)
    {
        TestDataSize = dataSize;
        GlobalSetup();
#if NET5_0_OR_GREATER
        _outputSize = -1;
        Array.Clear(_outputData);
        TryComputeHash();
        Assert.That(_outputSize, Is.GreaterThan(0), "Hash output should not be empty.");
        var result = _outputData.AsSpan().Slice(0, _outputSize).ToArray();
        Assert.That(_outputSize, Is.EqualTo(HashAlgorithm.HashSize / 8));
        var previousOutputData = new byte[_outputSize];
        Array.Copy(_outputData, previousOutputData, _outputSize);
        _outputSize = -1;
        Array.Clear(_outputData);
        TryComputeHash();
        Assert.That(_outputData, Is.EqualTo(previousOutputData));
#else
        var result = ComputeHash();
        Assert.That(result, Is.Not.Null, "Hash output should not be null.");
        Assert.That(result.Length, Is.GreaterThan(0), "Hash output should not be empty.");
        Assert.That(result, Has.Length.EqualTo(HashAlgorithm.HashSize / 8));
#endif
        bool allZeros = result.All(b => b == 0);
        Assert.That(allZeros, Is.False, "Hash output should not be all zeros.");
    }

    // TryComputeHash is virtual on CH.Hash.HashAlgorithm, so an implementation with a
    // faster single-call path (CH.Blake3's tree hashing, each third-party Blake3
    // adapter's native one-shot) overrides it and is reached by plain dispatch.
    [Benchmark]
#if NET5_0_OR_GREATER
    public void TryComputeHash()
    {
        if (HashAlgorithm.TryComputeHash(_inputData, _outputData, out int bytesWritten))
        {
            _outputSize = bytesWritten;
        }
    }
#else
    public byte[] ComputeHash() => HashAlgorithm.ComputeHash(_inputData);
#endif
}


