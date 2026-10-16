// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Benchmarks.Cipher;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for AES-128-GCM-SIV nonce-misuse-resistant authenticated encryption (RFC 8452).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "AES-GCM-SIV", "AES-128-GCM-SIV")]
[NonParallelizable]
public class AesGcmSiv128Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AesGcmSiv128Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AesGcmSiv128Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AesGcmSiv128();

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="AeadBenchmarkBase"/>
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

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public void Decrypt()
    {
        AeadCipher!.Decrypt(DecryptNonce, EncryptedData, Tag, OutputData, Aad);
    }
}

/// <summary>
/// Benchmarks for AES-256-GCM-SIV nonce-misuse-resistant authenticated encryption (RFC 8452).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "AES-GCM-SIV", "AES-256-GCM-SIV")]
[NonParallelizable]
public class AesGcmSiv256Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AesGcmSiv256Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AesGcmSiv256Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AesGcmSiv256();

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="AeadBenchmarkBase"/>
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

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public void Decrypt()
    {
        AeadCipher!.Decrypt(DecryptNonce, EncryptedData, Tag, OutputData, Aad);
    }
}
