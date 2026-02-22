// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Cipher;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for AES-128-CCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "AES-CCM", "AES-128-CCM")]
[NonParallelizable]
public class AesCcm128Benchmark : AeadBenchmarkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm128Benchmark"/> class.
    /// </summary>
    public AesCcm128Benchmark() => TestDataSize = DataSize.K8;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm128Benchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The cipher algorithm to benchmark.</param>
    public AesCcm128Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AesCcm128();

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

    [Test, Repeat(5)]
    [NonParallelizable]
    public void EncryptTest()
    {
        Encrypt();
        Assert.That(OutputData.AsSpan().Slice(0, InputData.Length).SequenceEqual(
            EncryptedData.AsSpan()), Is.False, "Encrypt should produce different output than cached ciphertext (nonce incremented)");
    }

    /// <summary>
    /// Benchmarks encryption performance.
    /// </summary>
    [Benchmark(Description = "Encrypt")]
    public void Encrypt()
    {
        IncrementNonce();
        AeadCipher!.Encrypt(Nonce, InputData, OutputData, Tag, Aad);
    }

    [Test, Repeat(5)]
    [NonParallelizable]
    public void DecryptTest()
    {
        Decrypt();
        Assert.That(OutputData.AsSpan().Slice(0, InputData.Length).SequenceEqual(InputData), Is.True);
    }

    /// <summary>
    /// Benchmarks decryption performance.
    /// </summary>
    [Benchmark(Description = "Decrypt")]
    public void Decrypt()
    {
        AeadCipher!.Decrypt(DecryptNonce, EncryptedData, Tag, OutputData, Aad);
    }
}

/// <summary>
/// Benchmarks for AES-256-CCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "AES-CCM", "AES-256-CCM")]
[NonParallelizable]
public class AesCcm256Benchmark : AeadBenchmarkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm256Benchmark"/> class.
    /// </summary>
    public AesCcm256Benchmark() => TestDataSize = DataSize.K8;

    /// <summary>
    /// Initializes a new instance of the <see cref="AesCcm256Benchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The cipher algorithm to benchmark.</param>
    public AesCcm256Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AesCcm256();

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

    [Test, Repeat(5)]
    [NonParallelizable]
    public void EncryptTest()
    {
        Encrypt();
        Assert.That(OutputData.AsSpan().Slice(0, InputData.Length).SequenceEqual(
            EncryptedData.AsSpan()), Is.False, "Encrypt should produce different output than cached ciphertext (nonce incremented)");
    }

    /// <summary>
    /// Benchmarks encryption performance.
    /// </summary>
    [Benchmark(Description = "Encrypt")]
    public void Encrypt()
    {
        IncrementNonce();
        AeadCipher!.Encrypt(Nonce, InputData, OutputData, Tag, Aad);
    }

    [Test, Repeat(5)]
    [NonParallelizable]
    public void DecryptTest()
    {
        Decrypt();
        Assert.That(OutputData.AsSpan().Slice(0, InputData.Length).SequenceEqual(InputData), Is.True);
    }

    /// <summary>
    /// Benchmarks decryption performance.
    /// </summary>
    [Benchmark(Description = "Decrypt")]
    public void Decrypt()
    {
        AeadCipher!.Decrypt(DecryptNonce, EncryptedData, Tag, OutputData, Aad);
    }
}
