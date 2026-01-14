// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using System;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using CHKmac128 = CryptoHives.Foundation.Security.Cryptography.Mac.Kmac128;
using CHKmac256 = CryptoHives.Foundation.Security.Cryptography.Mac.Kmac256;

/// <summary>
/// Benchmarks for KMAC128 and KMAC256 implementations.
/// Compares CryptoHives managed implementation against BouncyCastle and .NET 9+ native.
/// </summary>
[MemoryDiagnoser]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class KmacBenchmark
{
    private static readonly Random RandomInstance = new(42);

    private byte[] _key = null!;
    private byte[] _data = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;

    [Params(64, 1024, 4096, 65536)]
    public int DataSize { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _data = new byte[DataSize];
        RandomInstance.NextBytes(_data);

        _customizationString = "Benchmark";
        _customization = Encoding.UTF8.GetBytes(_customizationString);
    }

    #region KMAC128 Benchmarks

    [Benchmark(Description = "KMAC128 CryptoHives")]
    [BenchmarkCategory("KMAC128")]
    public byte[] Kmac128_CryptoHives()
    {
        using var kmac = CHKmac128.Create(_key, 32, _customizationString);
        return kmac.ComputeHash(_data);
    }

    [Benchmark(Description = "KMAC128 BouncyCastle")]
    [BenchmarkCategory("KMAC128")]
    public byte[] Kmac128_BouncyCastle()
    {
        var kmac = new KMac(128, _customization);
        kmac.Init(new KeyParameter(_key));
        kmac.BlockUpdate(_data, 0, _data.Length);
        byte[] result = new byte[32];
        kmac.DoFinal(result, 0);
        return result;
    }

#if NET9_0_OR_GREATER
    [Benchmark(Description = "KMAC128 .NET")]
    [BenchmarkCategory("KMAC128")]
    public byte[] Kmac128_DotNet()
    {
        return System.Security.Cryptography.Kmac128.HashData(_key, _data, 32, _customization);
    }
#endif

    #endregion

    #region KMAC256 Benchmarks

    [Benchmark(Description = "KMAC256 CryptoHives")]
    [BenchmarkCategory("KMAC256")]
    public byte[] Kmac256_CryptoHives()
    {
        using var kmac = CHKmac256.Create(_key, 64, _customizationString);
        return kmac.ComputeHash(_data);
    }

    [Benchmark(Description = "KMAC256 BouncyCastle")]
    [BenchmarkCategory("KMAC256")]
    public byte[] Kmac256_BouncyCastle()
    {
        var kmac = new KMac(256, _customization);
        kmac.Init(new KeyParameter(_key));
        kmac.BlockUpdate(_data, 0, _data.Length);
        byte[] result = new byte[64];
        kmac.DoFinal(result, 0);
        return result;
    }

#if NET9_0_OR_GREATER
    [Benchmark(Description = "KMAC256 .NET")]
    [BenchmarkCategory("KMAC256")]
    public byte[] Kmac256_DotNet()
    {
        return System.Security.Cryptography.Kmac256.HashData(_key, _data, 64, _customization);
    }
#endif

    #endregion
}

/// <summary>
/// Benchmarks for KMAC with varying output sizes.
/// </summary>
[MemoryDiagnoser]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class KmacOutputSizeBenchmark
{
    private static readonly Random RandomInstance = new(42);

    private byte[] _key = null!;
    private byte[] _data = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;

    [Params(16, 32, 64, 128)]
    public int OutputSize { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _data = new byte[1024];
        RandomInstance.NextBytes(_data);

        _customizationString = "OutputTest";
        _customization = Encoding.UTF8.GetBytes(_customizationString);
    }

    [Benchmark(Description = "KMAC128 CryptoHives")]
    [BenchmarkCategory("KMAC128")]
    public byte[] Kmac128_CryptoHives()
    {
        using var kmac = CHKmac128.Create(_key, OutputSize, _customizationString);
        return kmac.ComputeHash(_data);
    }

    [Benchmark(Description = "KMAC128 BouncyCastle")]
    [BenchmarkCategory("KMAC128")]
    public byte[] Kmac128_BouncyCastle()
    {
        var kmac = new KMac(128, _customization);
        kmac.Init(new KeyParameter(_key));
        kmac.BlockUpdate(_data, 0, _data.Length);
        byte[] result = new byte[OutputSize];
        kmac.DoFinal(result, 0);
        return result;
    }

#if NET9_0_OR_GREATER
    [Benchmark(Description = "KMAC128 .NET")]
    [BenchmarkCategory("KMAC128")]
    public byte[] Kmac128_DotNet()
    {
        return System.Security.Cryptography.Kmac128.HashData(_key, _data, OutputSize, _customization);
    }
#endif

    [Benchmark(Description = "KMAC256 CryptoHives")]
    [BenchmarkCategory("KMAC256")]
    public byte[] Kmac256_CryptoHives()
    {
        using var kmac = CHKmac256.Create(_key, OutputSize, _customizationString);
        return kmac.ComputeHash(_data);
    }

    [Benchmark(Description = "KMAC256 BouncyCastle")]
    [BenchmarkCategory("KMAC256")]
    public byte[] Kmac256_BouncyCastle()
    {
        var kmac = new KMac(256, _customization);
        kmac.Init(new KeyParameter(_key));
        kmac.BlockUpdate(_data, 0, _data.Length);
        byte[] result = new byte[OutputSize];
        kmac.DoFinal(result, 0);
        return result;
    }

#if NET9_0_OR_GREATER
    [Benchmark(Description = "KMAC256 .NET")]
    [BenchmarkCategory("KMAC256")]
    public byte[] Kmac256_DotNet()
    {
        return System.Security.Cryptography.Kmac256.HashData(_key, _data, OutputSize, _customization);
    }
#endif
}

/// <summary>
/// Benchmarks for KMAC incremental hashing.
/// </summary>
[MemoryDiagnoser]
[MinColumn, MaxColumn, MeanColumn, MedianColumn]
public class KmacIncrementalBenchmark
{
    private static readonly Random RandomInstance = new(42);

    private byte[] _key = null!;
    private byte[] _chunk1 = null!;
    private byte[] _chunk2 = null!;
    private byte[] _chunk3 = null!;
    private byte[] _customization = null!;
    private string _customizationString = null!;

    [GlobalSetup]
    public void Setup()
    {
        _key = new byte[32];
        RandomInstance.NextBytes(_key);

        _chunk1 = new byte[1024];
        _chunk2 = new byte[2048];
        _chunk3 = new byte[512];
        RandomInstance.NextBytes(_chunk1);
        RandomInstance.NextBytes(_chunk2);
        RandomInstance.NextBytes(_chunk3);

        _customizationString = "Incremental";
        _customization = Encoding.UTF8.GetBytes(_customizationString);
    }

    [Benchmark(Description = "KMAC128 CryptoHives Incremental")]
    [BenchmarkCategory("KMAC128")]
    public byte[] Kmac128_CryptoHives_Incremental()
    {
        using var kmac = CHKmac128.Create(_key, 32, _customizationString);
        kmac.TransformBlock(_chunk1, 0, _chunk1.Length, null, 0);
        kmac.TransformBlock(_chunk2, 0, _chunk2.Length, null, 0);
        kmac.TransformFinalBlock(_chunk3, 0, _chunk3.Length);
        return kmac.Hash!;
    }

    [Benchmark(Description = "KMAC128 BouncyCastle Incremental")]
    [BenchmarkCategory("KMAC128")]
    public byte[] Kmac128_BouncyCastle_Incremental()
    {
        var kmac = new KMac(128, _customization);
        kmac.Init(new KeyParameter(_key));
        kmac.BlockUpdate(_chunk1, 0, _chunk1.Length);
        kmac.BlockUpdate(_chunk2, 0, _chunk2.Length);
        kmac.BlockUpdate(_chunk3, 0, _chunk3.Length);
        byte[] result = new byte[32];
        kmac.DoFinal(result, 0);
        return result;
    }

    [Benchmark(Description = "KMAC256 CryptoHives Incremental")]
    [BenchmarkCategory("KMAC256")]
    public byte[] Kmac256_CryptoHives_Incremental()
    {
        using var kmac = CHKmac256.Create(_key, 64, _customizationString);
        kmac.TransformBlock(_chunk1, 0, _chunk1.Length, null, 0);
        kmac.TransformBlock(_chunk2, 0, _chunk2.Length, null, 0);
        kmac.TransformFinalBlock(_chunk3, 0, _chunk3.Length);
        return kmac.Hash!;
    }

    [Benchmark(Description = "KMAC256 BouncyCastle Incremental")]
    [BenchmarkCategory("KMAC256")]
    public byte[] Kmac256_BouncyCastle_Incremental()
    {
        var kmac = new KMac(256, _customization);
        kmac.Init(new KeyParameter(_key));
        kmac.BlockUpdate(_chunk1, 0, _chunk1.Length);
        kmac.BlockUpdate(_chunk2, 0, _chunk2.Length);
        kmac.BlockUpdate(_chunk3, 0, _chunk3.Length);
        byte[] result = new byte[64];
        kmac.DoFinal(result, 0);
        return result;
    }
}
