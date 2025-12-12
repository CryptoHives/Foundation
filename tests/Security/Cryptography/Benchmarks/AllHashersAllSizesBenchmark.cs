// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides benchmarks and tests for computing hash values using all
/// supported hash algorithms across multiple data sizes.
/// </summary>
/// <remarks>
/// This benchmark runs all hash algorithm groups and compares all
/// available implementations with varying input sizes.
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "AllHashers", "AllSizes")]
[NonParallelizable]
public class AllHashersAllSizesBenchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = AllHashers().Where(s => s != null).Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(AllHashers))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = HashAlgorithmType.SHA256_OS;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    public static IEnumerable<HashAlgorithmType> AllHashers() => HashAlgorithmType.AllHashers();

    public AllHashersAllSizesBenchmark()
    {
        TestDataSize = DataSize.K8;
    }
    /// <summary>
    /// Initializes a new instance for test fixtures.
    /// </summary>
    public AllHashersAllSizesBenchmark(HashAlgorithmType hashAlgorithm)
    {
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
        Assert.That(result.Length, Is.EqualTo(HashAlgorithm.HashSize / 8), "Result Hash has length mismatch.");

        var nextResult = ComputeHash();
        Assert.That(result.Length, Is.EqualTo(nextResult.Length));
        Assert.That(result, Is.EqualTo(nextResult), "Subsequent hash results do not match.");
    }

    [Benchmark]
    public byte[] ComputeHash()
    {
        return this.HashAlgorithm.ComputeHash(this.InputData);
    }
}


