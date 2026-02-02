// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using CHKmac128 = CryptoHives.Foundation.Security.Cryptography.Mac.Kmac128;
using CHKmac256 = CryptoHives.Foundation.Security.Cryptography.Mac.Kmac256;

/// <summary>
/// KMAC implementation types for benchmark parameterization.
/// </summary>
public enum KmacImplementation
{
    CryptoHives,
    BouncyCastle,
    DotNet
}

/// <summary>
/// Benchmarks for KMAC128 and KMAC256 implementations.
/// Compares CryptoHives managed implementation against BouncyCastle and .NET 9+ native.
/// </summary>
[TestFixture]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[NonParallelizable]
[BenchmarkCategory("KMac", "KMac128")]
public class Kmac128Benchmark
{
    private static readonly Random RandomInstance = new(42);

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    public Kmac128Benchmark() => TestDataSize = DataSize.K8;

    private byte[] _key = null!;
    private byte[] _data = null!;
    private byte[] _result = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;
    private CHKmac128 _chkmac128 = null!;
    private KMac _bckmac128 = null!;

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _data = new byte[TestDataSize.Bytes];
        RandomInstance.NextBytes(_data);

        _result = new byte[64];

        _customizationString = "Benchmark";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _bckmac128 = new KMac(128, _customization);
        _bckmac128.Init(new KeyParameter(_key));

        _chkmac128 = CHKmac128.Create(_key, 32, _customizationString);
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chkmac128?.Dispose();
    }

    #region KMAC128 Benchmarks

    [Test, Repeat(5)]
    [Benchmark]
    public void Kmac128_CryptoHives()
    {
        _ = _chkmac128.ComputeHash(_data);
    }

    [Test, Repeat(5)]
    [Benchmark]
    public void Kmac128_BouncyCastle()
    {
        _bckmac128.BlockUpdate(_data, 0, _data.Length);
        _bckmac128.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    [Test, Repeat(5)]
    [Benchmark]
    public void Kmac128_DotNet()
    {
        Kmac128.HashData(_key, _data, _result, _customization);
    }
#endif

    #endregion
}

/// <summary>
/// Benchmarks for KMAC256 implementations.
/// Compares CryptoHives managed implementation against BouncyCastle and .NET 9+ native.
/// </summary>
[TestFixture]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[NonParallelizable]
[BenchmarkCategory("KMac", "KMac256")]
public class Kmac256Benchmark
{
    private static readonly Random RandomInstance = new(42);

    // public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    public Kmac256Benchmark() => TestDataSize = DataSize.K8;

    private byte[] _key = null!;
    private byte[] _data = null!;
    private byte[] _result = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;
    private CHKmac256 _chkmac256 = null!;
    private KMac _bckmac256 = null!;

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _data = new byte[TestDataSize.Bytes];
        RandomInstance.NextBytes(_data);

        _result = new byte[64];

        _customizationString = "Benchmark";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _bckmac256 = new KMac(256, _customization);
        _bckmac256.Init(new KeyParameter(_key));

        _chkmac256 = CHKmac256.Create(_key, 64, _customizationString);
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chkmac256?.Dispose();
    }


    [Test, Repeat(5)]
    [Benchmark]
    [BenchmarkCategory("KMAC256")]
    public void Kmac256_CryptoHives()
    {
        _ = _chkmac256.ComputeHash(_data);
    }

    [Test, Repeat(5)]
    [Benchmark]
    [BenchmarkCategory("KMAC", "KMAC256")]
    public void Kmac256_BouncyCastle()
    {
        _bckmac256.BlockUpdate(_data, 0, _data.Length);
        _bckmac256.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    [Test, Repeat(5)]
    [Benchmark]
    [BenchmarkCategory("KMAC", "KMAC256")]
    public void Kmac256_DotNet()
    {
        Kmac256.HashData(_key, _data, _result, _customization);
    }
#endif
}

/// <summary>
/// Benchmarks for KMAC128 with varying output sizes.
/// </summary>
[TestFixture]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("KMac", "KMac128")]
public class Kmac128OutputSizeBenchmark
{
    private static readonly Random RandomInstance = new(42);

    private byte[] _key = null!;
    private byte[] _data = null!;
    private byte[] _result = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;

    private CHKmac128 _chKmac128 = null!;
    private KMac _kmac = null!;
    private Action _computeMac = null!;

    [ParamsSource(nameof(Implementations))]
    public KmacImplementation Implementation { get; set; }

    [Params(16, 32, 64, 128)]
    public int OutputSize { get; set; } = 128;

    public static IEnumerable<KmacImplementation> Implementations()
    {
        yield return KmacImplementation.CryptoHives;
        yield return KmacImplementation.BouncyCastle;
#if NET9_0_OR_GREATER
        yield return KmacImplementation.DotNet;
#endif
    }

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _data = new byte[1024];
        RandomInstance.NextBytes(_data);

        _customizationString = "OutputTest";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _chKmac128 = CHKmac128.Create(_key, OutputSize, _customizationString);

        _kmac = new KMac(128, _customization);
        _kmac.Init(new KeyParameter(_key));
        int engineSize = _kmac.GetMacSize();
        _result = new byte[Math.Max(engineSize, OutputSize)];

        _computeMac = Implementation switch
        {
            KmacImplementation.CryptoHives => CryptoHivesImpl,
            KmacImplementation.BouncyCastle => BouncyCastleImpl,
#if NET9_0_OR_GREATER
            KmacImplementation.DotNet => DotNetImpl,
#endif
            _ => throw new NotSupportedException($"Implementation {Implementation} not supported")
        };
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chKmac128?.Dispose();
    }

    private void CryptoHivesImpl() => _ = _chKmac128.ComputeHash(_data);

    private void BouncyCastleImpl()
    {
        _kmac.Reset();
        _kmac.BlockUpdate(_data, 0, _data.Length);
        _ = _kmac.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    private void DotNetImpl() => _ = Kmac128.HashData(_key, _data, OutputSize, _customization);
#endif

    [Test, Repeat(5)]
    [Benchmark]
    [BenchmarkCategory("KMAC128")]
    public void ComputeMac() => _computeMac();
}

/// <summary>
/// Benchmarks for KMAC256 with varying output sizes.
/// </summary>
[TestFixture]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("KMac", "KMac256")]
public class Kmac256OutputSizeBenchmark
{
    private static readonly Random RandomInstance = new(42);

    private byte[] _key = null!;
    private byte[] _data = null!;
    private byte[] _result = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;

    private CHKmac256 _chKmac256 = null!;
    private KMac _kmac = null!;
    private Action _computeMac = null!;

    [ParamsSource(nameof(Implementations))]
    public KmacImplementation Implementation { get; set; }

    [Params(16, 32, 64, 128)]
    public int OutputSize { get; set; } = 128;

    public static IEnumerable<KmacImplementation> Implementations()
    {
        yield return KmacImplementation.CryptoHives;
        yield return KmacImplementation.BouncyCastle;
#if NET9_0_OR_GREATER
        yield return KmacImplementation.DotNet;
#endif
    }

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _data = new byte[1024];
        RandomInstance.NextBytes(_data);

        _customizationString = "OutputTest";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _chKmac256 = CHKmac256.Create(_key, OutputSize, _customizationString);

        _kmac = new KMac(256, _customization);
        _kmac.Init(new KeyParameter(_key));
        int engineSize = _kmac.GetMacSize();
        _result = new byte[Math.Max(engineSize, OutputSize)];

        _computeMac = Implementation switch
        {
            KmacImplementation.CryptoHives => CryptoHivesImpl,
            KmacImplementation.BouncyCastle => BouncyCastleImpl,
#if NET9_0_OR_GREATER
            KmacImplementation.DotNet => DotNetImpl,
#endif
            _ => throw new NotSupportedException($"Implementation {Implementation} not supported")
        };
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chKmac256?.Dispose();
    }

    private void CryptoHivesImpl() => _ = _chKmac256.ComputeHash(_data);

    private void BouncyCastleImpl()
    {
        _kmac.Reset();
        _kmac.BlockUpdate(_data, 0, _data.Length);
        _ = _kmac.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    private void DotNetImpl() => _ = Kmac256.HashData(_key, _data, OutputSize, _customization);
#endif

    [Test, Repeat(5)]
    [Benchmark]
    [BenchmarkCategory("KMAC256")]
    public void ComputeMac() => _computeMac();
}

/// <summary>
/// Benchmarks for KMAC128 incremental hashing.
/// </summary>
[TestFixture]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("KMac", "KMac128")]
public class Kmac128IncrementalBenchmark
{
    private static readonly Random RandomInstance = new(42);

    private byte[] _key = null!;
    private byte[] _chunk1 = null!;
    private byte[] _chunk2 = null!;
    private byte[] _chunk3 = null!;
    private byte[] _result = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;
    private CHKmac128 _chKmac128 = null!;
    private KMac _kmac = null!;
    private Action _incrementalHash = null!;

    [ParamsSource(nameof(Implementations))]
    public KmacImplementation Implementation { get; set; }

    public static IEnumerable<KmacImplementation> Implementations()
    {
        yield return KmacImplementation.CryptoHives;
        yield return KmacImplementation.BouncyCastle;
    }

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _chunk1 = new byte[1024];
        _chunk2 = new byte[2048];
        _chunk3 = new byte[512];
        _result = new byte[32];
        RandomInstance.NextBytes(_chunk1);
        RandomInstance.NextBytes(_chunk2);
        RandomInstance.NextBytes(_chunk3);

        _customizationString = "Incremental";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _chKmac128 = CHKmac128.Create(_key, 32, _customizationString);

        _kmac = new KMac(128, _customization);
        _kmac.Init(new KeyParameter(_key));

        _incrementalHash = Implementation switch
        {
            KmacImplementation.CryptoHives => CryptoHivesImpl,
            KmacImplementation.BouncyCastle => BouncyCastleImpl,
            _ => throw new NotSupportedException($"Implementation {Implementation} not supported")
        };
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chKmac128?.Dispose();
    }

    private void CryptoHivesImpl()
    {
#if !NET8_0_OR_GREATER
        _chKmac128.Initialize();
#endif
        _chKmac128.TransformBlock(_chunk1, 0, _chunk1.Length, null, 0);
        _chKmac128.TransformBlock(_chunk2, 0, _chunk2.Length, null, 0);
        _chKmac128.TransformFinalBlock(_chunk3, 0, _chunk3.Length);
        _ = _chKmac128.Hash!;
    }

    private void BouncyCastleImpl()
    {
        _kmac.Reset();
        _kmac.BlockUpdate(_chunk1, 0, _chunk1.Length);
        _kmac.BlockUpdate(_chunk2, 0, _chunk2.Length);
        _kmac.BlockUpdate(_chunk3, 0, _chunk3.Length);
        _ = _kmac.DoFinal(_result, 0);
    }

    [Test, Repeat(5)]
    [Benchmark]
    [BenchmarkCategory("KMAC128")]
    public void IncrementalHash() => _incrementalHash();
}

/// <summary>
/// Benchmarks for KMAC256 incremental hashing.
/// </summary>
[TestFixture]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("KMac", "KMac256")]
public class Kmac256IncrementalBenchmark
{
    private static readonly Random RandomInstance = new(42);

    private byte[] _key = null!;
    private byte[] _chunk1 = null!;
    private byte[] _chunk2 = null!;
    private byte[] _chunk3 = null!;
    private byte[] _result = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;
    private CHKmac256 _chKmac256 = null!;
    private KMac _kmac = null!;
    private Action _incrementalHash = null!;

    [ParamsSource(nameof(Implementations))]
    public KmacImplementation Implementation { get; set; }

    public static IEnumerable<KmacImplementation> Implementations()
    {
        yield return KmacImplementation.CryptoHives;
        yield return KmacImplementation.BouncyCastle;
    }

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _chunk1 = new byte[1024];
        _chunk2 = new byte[2048];
        _chunk3 = new byte[512];
        _result = new byte[64];
        RandomInstance.NextBytes(_chunk1);
        RandomInstance.NextBytes(_chunk2);
        RandomInstance.NextBytes(_chunk3);

        _customizationString = "Incremental";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _chKmac256 = CHKmac256.Create(_key, 32, _customizationString);
        _kmac = new KMac(256, _customization);
        _kmac.Init(new KeyParameter(_key));

        _incrementalHash = Implementation switch
        {
            KmacImplementation.CryptoHives => CryptoHivesImpl,
            KmacImplementation.BouncyCastle => BouncyCastleImpl,
            _ => throw new NotSupportedException($"Implementation {Implementation} not supported")
        };
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chKmac256?.Dispose();
    }

    private void CryptoHivesImpl()
    {
#if !NET8_0_OR_GREATER
        _chKmac256.Initialize();
#endif
        _chKmac256.TransformBlock(_chunk1, 0, _chunk1.Length, null, 0);
        _chKmac256.TransformBlock(_chunk2, 0, _chunk2.Length, null, 0);
        _chKmac256.TransformFinalBlock(_chunk3, 0, _chunk3.Length);
        _ = _chKmac256.Hash!;
    }

    private void BouncyCastleImpl()
    {
        _kmac.Reset();
        _kmac.BlockUpdate(_chunk1, 0, _chunk1.Length);
        _kmac.BlockUpdate(_chunk2, 0, _chunk2.Length);
        _kmac.BlockUpdate(_chunk3, 0, _chunk3.Length);
        _ = _kmac.DoFinal(_result, 0);
    }

    [Test, Repeat(5)]
    [Benchmark]
    [BenchmarkCategory("KMAC256")]
    public void IncrementalHash() => _incrementalHash();
}
