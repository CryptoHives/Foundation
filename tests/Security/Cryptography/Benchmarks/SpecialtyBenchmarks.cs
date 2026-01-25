// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for MD5 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Legacy", "MD5")]
[NonParallelizable]
public class MD5Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.MD5();

    public MD5Benchmark() => TestDataSize = DataSize.K8;
    public MD5Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHA-1 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Legacy", "SHA1")]
[NonParallelizable]
public class SHA1Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA1();

    public SHA1Benchmark() => TestDataSize = DataSize.K8;
    public SHA1Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SM3 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "SM3")]
[NonParallelizable]
public class SM3Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SM3();

    public SM3Benchmark() => TestDataSize = DataSize.K8;
    public SM3Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for Streebog-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "Streebog256")]
[NonParallelizable]
public class Streebog256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Streebog256();

    public Streebog256Benchmark() => TestDataSize = DataSize.K8;
    public Streebog256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for Streebog-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "Streebog512")]
[NonParallelizable]
public class Streebog512Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Streebog512();

    public Streebog512Benchmark() => TestDataSize = DataSize.K8;
    public Streebog512Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for Whirlpool implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "Whirlpool")]
[NonParallelizable]
public class WhirlpoolBenchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Whirlpool();

    public WhirlpoolBenchmark() => TestDataSize = DataSize.K8;
    public WhirlpoolBenchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for RIPEMD-160 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "RIPEMD160")]
[NonParallelizable]
public class Ripemd160Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Ripemd160();

    public Ripemd160Benchmark() => TestDataSize = DataSize.K8;
    public Ripemd160Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for Ascon-Hash256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Ascon", "AsconHash256")]
[NonParallelizable]
public class AsconHash256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.AsconHash256();

    public AsconHash256Benchmark() => TestDataSize = DataSize.K8;
    public AsconHash256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for Ascon-XOF128 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Ascon", "AsconXof128")]
[NonParallelizable]
public class AsconXof128Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.AsconXof128();

    public AsconXof128Benchmark() => TestDataSize = DataSize.K8;
    public AsconXof128Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
