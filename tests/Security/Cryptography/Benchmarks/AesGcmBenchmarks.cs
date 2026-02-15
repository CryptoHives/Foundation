// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for AES-128-GCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "AES-GCM", "AES-128-GCM")]
[NonParallelizable]
public class AesGcm128Benchmark : AeadBenchmarkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm128Benchmark"/> class.
    /// </summary>
    public AesGcm128Benchmark() => TestDataSize = DataSize.K8;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm128Benchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The cipher algorithm to benchmark.</param>
    public AesGcm128Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    /// <summary>
    /// Test data sizes for benchmarking.
    /// </summary>
    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    /// <summary>
    /// Cipher algorithm implementations to benchmark.
    /// </summary>
    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <summary>
    /// Gets the data sizes for benchmarking.
    /// </summary>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <summary>
    /// Gets the AES-128-GCM implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AesGcm128();

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
    /// Initializes the benchmark with the specified algorithm and data size.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public override void GlobalSetup()
    {
        Bytes = TestDataSize.Bytes;
        AeadCipher = (IAeadCipher)TestCipherAlgorithm.Create();
        base.GlobalSetup();
    }

    /// <summary>
    /// Benchmarks encryption performance.
    /// </summary>
    [Benchmark(Description = "Encrypt")]
    [Test]
    public void Encrypt()
    {
        IncrementNonce(); // Ensure unique nonce for each invocation
        AeadCipher!.Encrypt(Nonce, InputData, OutputData, Tag, Aad);
    }

    /// <summary>
    /// Benchmarks decryption performance.
    /// </summary>
    [Benchmark(Description = "Decrypt")]
    [Test]
    public void Decrypt()
    {
        IncrementNonce(); // Ensure unique nonce for each invocation
        AeadCipher!.Decrypt(Nonce, EncryptedData, Tag, OutputData, Aad);
    }
}

/// <summary>
/// Benchmarks for AES-256-GCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "AES-GCM", "AES-256-GCM")]
[NonParallelizable]
public class AesGcm256Benchmark : AeadBenchmarkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm256Benchmark"/> class.
    /// </summary>
    public AesGcm256Benchmark() => TestDataSize = DataSize.K8;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesGcm256Benchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The cipher algorithm to benchmark.</param>
    public AesGcm256Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AesGcm256();

    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
        {
            yield return new object[] { alg };
        }
    }

    /// <summary>
    /// Initializes the benchmark with the specified algorithm and data size.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public override void GlobalSetup()
    {
        Bytes = TestDataSize.Bytes;
        AeadCipher = (IAeadCipher)TestCipherAlgorithm.Create();
        base.GlobalSetup();
    }

    /// <summary>
    /// Benchmarks encryption performance.
    /// </summary>
    [Benchmark(Description = "Encrypt")]
    [Test]
    public void Encrypt()
    {
        IncrementNonce(); // Ensure unique nonce for each invocation
        AeadCipher!.Encrypt(Nonce, InputData, OutputData, Tag, Aad);
    }

    /// <summary>
    /// Benchmarks decryption performance.
    /// </summary>
    [Benchmark(Description = "Decrypt")]
    [Test]
    public void Decrypt()
    {
        IncrementNonce(); // Ensure unique nonce for each invocation
        AeadCipher!.Decrypt(Nonce, EncryptedData, Tag, OutputData, Aad);
    }
}
