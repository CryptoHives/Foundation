// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for BLAKE2b-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE2b", "BLAKE2b256")]
[NonParallelizable]
public class Blake2b256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake2b256();

    public Blake2b256Benchmark() => TestDataSize = DataSize.K8;
    public Blake2b256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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

/// <summary>
/// Benchmark for BLAKE2b-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE2b", "BLAKE2b512")]
[NonParallelizable]
public class Blake2b512Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake2b512();

    public Blake2b512Benchmark() => TestDataSize = DataSize.K8;
    public Blake2b512Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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

/// <summary>
/// Benchmark for BLAKE2s-128 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE2s", "BLAKE2s128")]
[NonParallelizable]
public class Blake2s128Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake2s128();

    public Blake2s128Benchmark() => TestDataSize = DataSize.K8;
    public Blake2s128Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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

/// <summary>
/// Benchmark for BLAKE2s-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE2s", "BLAKE2s256")]
[NonParallelizable]
public class Blake2s256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake2s256();

    public Blake2s256Benchmark() => TestDataSize = DataSize.K8;
    public Blake2s256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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

/// <summary>
/// Benchmark for BLAKE3 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE3")]
[NonParallelizable]
public class Blake3Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake3();

    public Blake3Benchmark() => TestDataSize = DataSize.K8;
    public Blake3Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
