// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Cipher;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for Ascon-AEAD128 authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Ascon-AEAD128")]
[NonParallelizable]
public class AsconAead128Benchmark : AeadBenchmarkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AsconAead128Benchmark"/> class.
    /// </summary>
    public AsconAead128Benchmark() => TestDataSize = DataSize.K8;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsconAead128Benchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The cipher algorithm to benchmark.</param>
    public AsconAead128Benchmark(CipherAlgorithmType algorithm)
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
    /// Gets the Ascon-AEAD128 implementations for benchmarking.
    /// </summary>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AsconAead128();

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
