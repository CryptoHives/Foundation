// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Cipher;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for ChaCha20 stream cipher (non-AEAD).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Stream", "ChaCha20")]
[NonParallelizable]
public class ChaCha20Benchmark : CipherBenchmarkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ChaCha20Benchmark"/> class.
    /// </summary>
    public ChaCha20Benchmark() => TestDataSize = DataSize.K8;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChaCha20Benchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The cipher algorithm to benchmark.</param>
    public ChaCha20Benchmark(CipherAlgorithmType algorithm)
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
    /// Gets the ChaCha20 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.ChaCha20();

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
