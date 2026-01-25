// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for SHA3-224 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA3", "SHA3_224")]
[NonParallelizable]
public class SHA3_224Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA3_224();

    public SHA3_224Benchmark() => TestDataSize = DataSize.K8;
    public SHA3_224Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHA3-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA3", "SHA3_256")]
[NonParallelizable]
public class SHA3_256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA3_256();

    public SHA3_256Benchmark() => TestDataSize = DataSize.K8;
    public SHA3_256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHA3-384 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA3", "SHA3_384")]
[NonParallelizable]
public class SHA3_384Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA3_384();

    public SHA3_384Benchmark() => TestDataSize = DataSize.K8;
    public SHA3_384Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHA3-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA3", "SHA3_512")]
[NonParallelizable]
public class SHA3_512Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA3_512();

    public SHA3_512Benchmark() => TestDataSize = DataSize.K8;
    public SHA3_512Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for Keccak-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Keccak", "Keccak256")]
[NonParallelizable]
public class Keccak256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Keccak256();

    public Keccak256Benchmark() => TestDataSize = DataSize.K8;
    public Keccak256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for Keccak-384 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Keccak", "Keccak384")]
[NonParallelizable]
public class Keccak384Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Keccak384();

    public Keccak384Benchmark() => TestDataSize = DataSize.K8;
    public Keccak384Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for Keccak-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Keccak", "Keccak512")]
[NonParallelizable]
public class Keccak512Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Keccak512();

    public Keccak512Benchmark() => TestDataSize = DataSize.K8;
    public Keccak512Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHAKE128 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHAKE", "SHAKE128")]
[NonParallelizable]
public class Shake128Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Shake128();

    public Shake128Benchmark() => TestDataSize = DataSize.K8;
    public Shake128Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for SHAKE256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHAKE", "SHAKE256")]
[NonParallelizable]
public class Shake256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Shake256();

    public Shake256Benchmark() => TestDataSize = DataSize.K8;
    public Shake256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for cSHAKE128 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "cSHAKE", "cSHAKE128")]
[NonParallelizable]
public class CShake128Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.CShake128();

    public CShake128Benchmark() => TestDataSize = DataSize.K8;
    public CShake128Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for cSHAKE256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "cSHAKE", "cSHAKE256")]
[NonParallelizable]
public class CShake256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.CShake256();

    public CShake256Benchmark() => TestDataSize = DataSize.K8;
    public CShake256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for KT128 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "KT", "KT128")]
[NonParallelizable]
public class KT128Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.KT128();

    public KT128Benchmark() => TestDataSize = DataSize.K8;
    public KT128Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for KT256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "KT", "KT256")]
[NonParallelizable]
public class KT256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.KT256();

    public KT256Benchmark() => TestDataSize = DataSize.K8;
    public KT256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for TurboSHAKE128 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "TurboSHAKE", "TurboSHAKE128")]
[NonParallelizable]
public class TurboShake128Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.TurboShake128();

    public TurboShake128Benchmark() => TestDataSize = DataSize.K8;
    public TurboShake128Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
/// Benchmark for TurboSHAKE256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "TurboSHAKE", "TurboSHAKE256")]
[NonParallelizable]
public class TurboShake256Benchmark : HashBenchmarkBase
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.TurboShake256();

    public TurboShake256Benchmark() => TestDataSize = DataSize.K8;
    public TurboShake256Benchmark(HashAlgorithmType hashAlgorithm) => TestHashAlgorithm = hashAlgorithm;

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
