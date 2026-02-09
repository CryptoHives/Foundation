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
using CHMac = CryptoHives.Foundation.Security.Cryptography.Mac;

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
    private CHMac.KMac128 _chkmac128 = null!;
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

        _chkmac128 = CHMac.KMac128.Create(_key, 32, _customizationString);
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chkmac128?.Dispose();
    }

    #region KMAC128 Benchmarks

    [Test, Repeat(5)]
    [Benchmark]
#if NET5_0_OR_GREATER
    public void TryComputeHash_CryptoHives()
    {
        _chkmac128.TryComputeHash(_data, _result, out _);
    }
#else
    public void ComputeHash_CryptoHives()
    {
        _ = _chkmac128.ComputeHash(_data);
    }
#endif

    [Test, Repeat(5)]
    [Benchmark]
    public void ComputeHash_BouncyCastle()
    {
        _bckmac128.BlockUpdate(_data, 0, _data.Length);
        _bckmac128.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    [Test, Repeat(5)]
    public void ComputeHashTest_DotNet()
    {
        if (!Kmac128.IsSupported)
        {
            Assert.Ignore("KMac128 is not supported on this platform.");
        }
        ComputeHash_DotNet();
    }

    [Benchmark]
    public void ComputeHash_DotNet()
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

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    public Kmac256Benchmark() => TestDataSize = DataSize.K8;

    private byte[] _key = null!;
    private byte[] _data = null!;
    private byte[] _result = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;
    private CHMac.KMac256 _chkmac256 = null!;
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

        _chkmac256 = CHMac.KMac256.Create(_key, 64, _customizationString);
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chkmac256?.Dispose();
    }


    [Test, Repeat(5)]
    [Benchmark]
#if NET5_0_OR_GREATER
    public void TryComputeHash_CryptoHives()
    {
        _chkmac256.TryComputeHash(_data, _result, out _);
    }
#else
    public void ComputeHash_CryptoHives()
    {
        _ = _chkmac256.ComputeHash(_data);
    }
#endif

    [Test, Repeat(5)]
    [Benchmark]
    public void ComputeHash_BouncyCastle()
    {
        _bckmac256.BlockUpdate(_data, 0, _data.Length);
        _bckmac256.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    [Test, Repeat(5)]
    public void ComputeHashTest_DotNet()
    {
        if (!Kmac256.IsSupported)
        {
            Assert.Ignore("KMac256 is not supported on this platform.");
        }
        ComputeHash_DotNet();
    }

    [Benchmark]
    public void ComputeHash_DotNet()
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
[NonParallelizable]
public class Kmac128OutputSizeBenchmark
{
    private static readonly Random RandomInstance = new(42);

    private byte[] _key = null!;
    private byte[] _data = null!;
    private byte[] _result = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;

    private CHMac.KMac128 _chKmac128 = null!;
    private KMac _kmac = null!;

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;
    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    [Params(16, 32, 64, 128)]
    public int OutputSize { get; set; } = 128;

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _data = new byte[TestDataSize.Bytes];
        RandomInstance.NextBytes(_data);

        _customizationString = "OutputTest";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _chKmac128 = CHMac.KMac128.Create(_key, OutputSize, _customizationString);

        _kmac = new KMac(128, _customization);
        _kmac.Init(new KeyParameter(_key));
        int engineSize = _kmac.GetMacSize();
        _result = new byte[Math.Max(engineSize, OutputSize)];
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chKmac128?.Dispose();
    }

    [Test, Repeat(5)]
    [Benchmark]
#if NET5_0_OR_GREATER
    public void TryComputeSizedHash_CryptoHives()
    {
        _chKmac128.TryComputeHash(_data, _result, out _);
    }
#else
    public void ComputeSizedHash_CryptoHives()
    {
        _ = _chKmac128.ComputeHash(_data);
    }
#endif

    [Test, Repeat(5)]
    [Benchmark]
    public void ComputeSizedHash_BouncyCastle()
    {
        _kmac.Reset();
        _kmac.BlockUpdate(_data, 0, _data.Length);
        _ = _kmac.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    [Test, Repeat(5)]
    public void ComputeSizedHashTest_DotNet()
    {
        if (!Kmac128.IsSupported)
        {
            Assert.Ignore("KMac128 is not supported on this platform.");
        }

        ComputeSizedHash_DotNet();
    }

    [Benchmark]
    public void ComputeSizedHash_DotNet()
    {
        Kmac128.HashData(_key, _data, _result.AsSpan(0, OutputSize), _customization);
    }
#endif
}

/// <summary>
/// Benchmarks for KMAC256 with varying output sizes.
/// </summary>
[TestFixture]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("KMac", "KMac256")]
[NonParallelizable]
public class Kmac256OutputSizeBenchmark
{
    private static readonly Random RandomInstance = new(42);

    private byte[] _key = null!;
    private byte[] _data = null!;
    private byte[] _result = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;

    private CHMac.KMac256 _chKmac256 = null!;
    private KMac _kmac = null!;

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;
    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    [Params(16, 32, 64, 128)]
    public int OutputSize { get; set; } = 128;

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _data = new byte[TestDataSize.Bytes];
        RandomInstance.NextBytes(_data);

        _customizationString = "OutputTest";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _chKmac256 = CHMac.KMac256.Create(_key, OutputSize, _customizationString);

        _kmac = new KMac(256, _customization);
        _kmac.Init(new KeyParameter(_key));
        int engineSize = _kmac.GetMacSize();
        _result = new byte[Math.Max(engineSize, OutputSize)];
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chKmac256?.Dispose();
    }

    [Test, Repeat(5)]
    [Benchmark]
#if NET5_0_OR_GREATER
    public void TryComputeSizedHash_CryptoHives()
    {
        _chKmac256.TryComputeHash(_data, _result, out _);
    }
#else
    public void ComputeSizedHash_CryptoHives()
    {
        _ = _chKmac256.ComputeHash(_data);
    }
#endif

    [Test, Repeat(5)]
    [Benchmark]
    public void ComputeSizedHash_BouncyCastle()
    {
        _kmac.Reset();
        _kmac.BlockUpdate(_data, 0, _data.Length);
        _ = _kmac.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    [Test, Repeat(5)]
    public void ComputeSizedHashTest_DotNet()
    {
        if (!Kmac256.IsSupported)
        {
            Assert.Ignore("KMac256 is not supported on this platform.");
        }

        ComputeSizedHash_DotNet();
    }

    [Benchmark]
    public void ComputeSizedHash_DotNet()
    {
        Kmac256.HashData(_key, _data, _result.AsSpan(0, OutputSize), _customization);
    }
#endif
}

/// <summary>
/// Benchmarks for KMAC128 incremental hashing.
/// </summary>
[TestFixture]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("KMac", "KMac128")]
[NonParallelizable]
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
    private CHMac.KMac128 _chKmac128 = null!;
    private KMac _kmac = null!;
#if NET9_0_OR_GREATER
    private Kmac128? _dotnetKmac128;
#endif

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;
    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _result = new byte[32];
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        int bytes = TestDataSize.Bytes;
        _chunk3 = new byte[bytes / 8];
        _chunk2 = new byte[bytes / 3];
        _chunk1 = new byte[bytes - _chunk2.Length - _chunk3.Length];
        RandomInstance.NextBytes(_chunk1);
        RandomInstance.NextBytes(_chunk2);
        RandomInstance.NextBytes(_chunk3);

        _customizationString = "Incremental";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _chKmac128 = CHMac.KMac128.Create(_key, 32, _customizationString);

        _kmac = new KMac(128, _customization);
        _kmac.Init(new KeyParameter(_key));

#if NET9_0_OR_GREATER
        if (Kmac128.IsSupported)
        {
            _dotnetKmac128 = new Kmac128(_key, _customization);
        }
#endif
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chKmac128?.Dispose();
#if NET9_0_OR_GREATER
        _dotnetKmac128?.Dispose();
#endif
    }

    [Test, Repeat(5)]
    [Benchmark]
    public void IncrementalHash_CryptoHives()
    {
#if !NET8_0_OR_GREATER
        _chKmac128.Initialize();
#endif
        _chKmac128.TransformBlock(_chunk1, 0, _chunk1.Length, null, 0);
        _chKmac128.TransformBlock(_chunk2, 0, _chunk2.Length, null, 0);
        _chKmac128.TransformFinalBlock(_chunk3, 0, _chunk3.Length);
        _ = _chKmac128.Hash!;
    }

    [Test, Repeat(5)]
    [Benchmark]
    public void IncrementalHash_BouncyCastle()
    {
        _kmac.Reset();
        _kmac.BlockUpdate(_chunk1, 0, _chunk1.Length);
        _kmac.BlockUpdate(_chunk2, 0, _chunk2.Length);
        _kmac.BlockUpdate(_chunk3, 0, _chunk3.Length);
        _ = _kmac.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    [Test, Repeat(5)]
    public void IncrementalHashTest_DotNet()
    {
        if (!Kmac128.IsSupported)
        {
            Assert.Ignore("KMAC128 is not supported on this platform.");
        }

        IncrementalHash_DotNet();
    }

    [Benchmark]
    public void IncrementalHash_DotNet()
    {
        if (_dotnetKmac128 != null)
        {
            _dotnetKmac128.AppendData(_chunk1);
            _dotnetKmac128.AppendData(_chunk2);
            _dotnetKmac128.AppendData(_chunk3);
            _dotnetKmac128.GetHashAndReset(_result);
        }
    }
#endif
}

/// <summary>
/// Benchmarks for KMAC256 incremental hashing.
/// </summary>
[TestFixture]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("KMac", "KMac256")]
[NonParallelizable]
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
    private CHMac.KMac256 _chKmac256 = null!;
    private KMac _kmac = null!;

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;
    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

#if NET9_0_OR_GREATER
    private Kmac256? _dotnetKmac256;
#endif

    [GlobalSetup, OneTimeSetUp]
    public void Setup()
    {
        _result = new byte[64];
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        int bytes = TestDataSize.Bytes;
        _chunk3 = new byte[bytes / 8];
        _chunk2 = new byte[bytes / 3];
        _chunk1 = new byte[bytes - _chunk2.Length - _chunk3.Length];

        RandomInstance.NextBytes(_chunk1);
        RandomInstance.NextBytes(_chunk2);
        RandomInstance.NextBytes(_chunk3);

        _customizationString = "Incremental";
        _customization = Encoding.UTF8.GetBytes(_customizationString);

        _chKmac256 = CHMac.KMac256.Create(_key, 32, _customizationString);
        _kmac = new KMac(256, _customization);
        _kmac.Init(new KeyParameter(_key));

#if NET9_0_OR_GREATER
        if (Kmac256.IsSupported)
        {
            _dotnetKmac256 = new Kmac256(_key, _customization);
        }
#endif
    }

    [GlobalCleanup, OneTimeTearDown]
    public void Teardown()
    {
        _chKmac256?.Dispose();
#if NET9_0_OR_GREATER
        _dotnetKmac256?.Dispose();
#endif
    }

    [Test, Repeat(5)]
    [Benchmark]
    public void IncrementalHash_CryptoHives()
    {
#if !NET8_0_OR_GREATER
        _chKmac256.Initialize();
#endif
        _chKmac256.TransformBlock(_chunk1, 0, _chunk1.Length, null, 0);
        _chKmac256.TransformBlock(_chunk2, 0, _chunk2.Length, null, 0);
        _chKmac256.TransformFinalBlock(_chunk3, 0, _chunk3.Length);
        _ = _chKmac256.Hash!;
    }

    [Test, Repeat(5)]
    [Benchmark]
    public void IncrementalHash_BouncyCastle()
    {
        _kmac.Reset();
        _kmac.BlockUpdate(_chunk1, 0, _chunk1.Length);
        _kmac.BlockUpdate(_chunk2, 0, _chunk2.Length);
        _kmac.BlockUpdate(_chunk3, 0, _chunk3.Length);
        _ = _kmac.DoFinal(_result, 0);
    }

#if NET9_0_OR_GREATER
    [Test, Repeat(5)]
    public void IncrementalHashTest_DotNet()
    {
        if (!Kmac256.IsSupported)
        {
            Assert.Ignore("KMAC256 is not supported on this platform.");
        }

        IncrementalHash_DotNet();
    }

    [Benchmark]
    public void IncrementalHash_DotNet()
    {
        if (_dotnetKmac256 != null)
        {
            _dotnetKmac256.AppendData(_chunk1);
            _dotnetKmac256.AppendData(_chunk2);
            _dotnetKmac256.AppendData(_chunk3);
            _dotnetKmac256.GetHashAndReset(_result);
        }
    }
#endif
}
