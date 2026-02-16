// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
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

    /// <summary>
    /// Benchmarks encryption performance.
    /// </summary>
    [Benchmark(Description = "Encrypt")]
    [Test]
    public void Encrypt()
    {
        Encryptor!.Reset();
        Encryptor.TransformBlock(InputData, OutputData);
    }

    /// <summary>
    /// Benchmarks decryption performance.
    /// </summary>
    [Benchmark(Description = "Decrypt")]
    [Test]
    public void Decrypt()
    {
        Decryptor!.Reset();
        Decryptor.TransformBlock(EncryptedData, OutputData);
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

    /// <summary>
    /// Benchmarks encryption performance.
    /// </summary>
    [Benchmark(Description = "Encrypt")]
    [Test]
    public void Encrypt()
    {
        Encryptor!.Reset();
        Encryptor.TransformBlock(InputData, OutputData);
    }

    /// <summary>
    /// Benchmarks decryption performance.
    /// </summary>
    [Benchmark(Description = "Decrypt")]
    [Test]
    public void Decrypt()
    {
        Decryptor!.Reset();
        Decryptor.TransformBlock(EncryptedData, OutputData);
    }
}
