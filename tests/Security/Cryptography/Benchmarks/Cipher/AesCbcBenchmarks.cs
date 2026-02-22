// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Cipher;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for AES-128-CBC symmetric encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AES", "AES-128-CBC")]
[NonParallelizable]
public class AesCbc128Benchmark : CipherBenchmarkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AesCbc128Benchmark"/> class.
    /// </summary>
    public AesCbc128Benchmark() => TestDataSize = DataSize.K8;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCbc128Benchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The cipher algorithm to benchmark.</param>
    public AesCbc128Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <summary>
    /// Gets the data sizes for benchmarking.
    /// </summary>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <summary>
    /// Gets the AES-128-CBC implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AesCbc128();

    /// <summary>
    /// NUnit test fixture argument source.
    /// </summary>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
        {
            yield return new object[] { alg };
        }
    }

    /// <summary>
    /// Initializes the benchmark with the specified data size.
    /// </summary>
    [OneTimeSetUp]
    public override void GlobalSetup()
    {
        Bytes = TestDataSize.Bytes;
        CipherAlgorithm = (SymmetricCipher)TestCipherAlgorithm.Create();
        base.GlobalSetup();
    }

    [Test, Repeat(5)]
    [NonParallelizable]
    public void EncryptTest()
    {
        int result = Encrypt();
        Assert.That(result, Is.GreaterThanOrEqualTo(InputData.Length));
    }

    /// <summary>
    /// Benchmarks encryption performance.
    /// </summary>
    [Benchmark(Description = "Encrypt")]
    public int Encrypt()
    {
        Encryptor!.Reset();
        return Encryptor.TransformFinalBlock(InputData, OutputData);
    }

    [Test, Repeat(5)]
    [NonParallelizable]
    public void DecryptTest()
    {
        int result = Decrypt();
        Assert.That(result, Is.EqualTo(InputData.Length));
        var decryptedData = OutputData.AsSpan().Slice(0, result);
        Assert.That(decryptedData.SequenceEqual(InputData), Is.True);
    }

    /// <summary>
    /// Benchmarks decryption performance.
    /// </summary>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}

/// <summary>
/// Benchmarks for AES-256-CBC symmetric encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AES", "AES-256-CBC")]
[NonParallelizable]
public class AesCbc256Benchmark : CipherBenchmarkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AesCbc256Benchmark"/> class.
    /// </summary>
    public AesCbc256Benchmark() => TestDataSize = DataSize.K8;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCbc256Benchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The cipher algorithm to benchmark.</param>
    public AesCbc256Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <summary>
    /// Gets the data sizes for benchmarking.
    /// </summary>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <summary>
    /// Gets the AES-256-CBC implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AesCbc256();

    /// <summary>
    /// NUnit test fixture argument source.
    /// </summary>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
        {
            yield return new object[] { alg };
        }
    }

    /// <summary>
    /// Initializes the benchmark with the specified data size.
    /// </summary>
    [OneTimeSetUp]
    public override void GlobalSetup()
    {
        Bytes = TestDataSize.Bytes;
        CipherAlgorithm = (SymmetricCipher)TestCipherAlgorithm.Create();
        base.GlobalSetup();
    }

    [Test, Repeat(5)]
    [NonParallelizable]
    public void EncryptTest()
    {
        int result = Encrypt();
        Assert.That(result, Is.GreaterThanOrEqualTo(InputData.Length));
    }

    /// <summary>
    /// Benchmarks encryption performance.
    /// </summary>
    [Benchmark(Description = "Encrypt")]
    public int Encrypt()
    {
        Encryptor!.Reset();
        return Encryptor.TransformFinalBlock(InputData, OutputData);
    }

    [Test, Repeat(5)]
    [NonParallelizable]
    public void DecryptTest()
    {
        int result = Decrypt();
        Assert.That(result, Is.EqualTo(InputData.Length));
        var decryptedData = OutputData.AsSpan().Slice(0, result);
        Assert.That(decryptedData.SequenceEqual(InputData), Is.True);
    }

    /// <summary>
    /// Benchmarks decryption performance.
    /// </summary>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}
