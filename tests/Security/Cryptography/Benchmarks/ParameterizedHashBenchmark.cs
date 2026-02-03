// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;

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

    [Test]
    [TestCaseSource(typeof(DataSize), nameof(DataSize.AllSizes))]
    public void TestComputeHash(DataSize dataSize)
    {
        TestDataSize = dataSize;
        GlobalSetup();
        var result = ComputeHash();
        Assert.That(result, Has.Length.EqualTo(HashAlgorithm.HashSize / 8));
        Assert.That(result, Is.EqualTo(ComputeHash()));
    }

    [Benchmark]
    public byte[] ComputeHash() => HashAlgorithm.ComputeHash(InputData);
}


