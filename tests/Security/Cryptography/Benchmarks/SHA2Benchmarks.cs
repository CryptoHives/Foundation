// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for SHA-224 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA224")]
[NonParallelizable]
public class SHA224Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA224();

    public SHA224Benchmark() => TestDataSize = DataSize.K8;
    public SHA224Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHA-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA256")]
[NonParallelizable]
public class SHA256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA256();

    public SHA256Benchmark() => TestDataSize = DataSize.K8;
    public SHA256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHA-384 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA384")]
[NonParallelizable]
public class SHA384Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA384();

    public SHA384Benchmark() => TestDataSize = DataSize.K8;
    public SHA384Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHA-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA512")]
[NonParallelizable]
public class SHA512Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA512();

    public SHA512Benchmark() => TestDataSize = DataSize.K8;
    public SHA512Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHA-512/224 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA512_224")]
[NonParallelizable]
public class SHA512_224Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA512_224();

    public SHA512_224Benchmark() => TestDataSize = DataSize.K8;
    public SHA512_224Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHA-512/256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA512_256")]
[NonParallelizable]
public class SHA512_256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA512_256();

    public SHA512_256Benchmark() => TestDataSize = DataSize.K8;
    public SHA512_256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
