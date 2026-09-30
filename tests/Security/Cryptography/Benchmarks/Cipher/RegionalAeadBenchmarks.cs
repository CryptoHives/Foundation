// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Cipher;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for SM4-GCM authenticated encryption (RFC 8998).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "SM4-GCM")]
[NonParallelizable]
public class Sm4GcmBenchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public Sm4GcmBenchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public Sm4GcmBenchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.Sm4Gcm();

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
/// Benchmarks for SM4-CCM authenticated encryption (RFC 8998).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "SM4-CCM")]
[NonParallelizable]
public class Sm4CcmBenchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public Sm4CcmBenchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public Sm4CcmBenchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.Sm4Ccm();

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
/// Benchmarks for ARIA-128-GCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "ARIA-128-GCM")]
[NonParallelizable]
public class AriaGcm128Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AriaGcm128Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AriaGcm128Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AriaGcm128();

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
/// Benchmarks for ARIA-256-GCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "ARIA-256-GCM")]
[NonParallelizable]
public class AriaGcm256Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AriaGcm256Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AriaGcm256Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AriaGcm256();

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
/// Benchmarks for ARIA-128-CCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "ARIA-128-CCM")]
[NonParallelizable]
public class AriaCcm128Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AriaCcm128Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AriaCcm128Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AriaCcm128();

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
/// Benchmarks for ARIA-256-CCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "ARIA-256-CCM")]
[NonParallelizable]
public class AriaCcm256Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AriaCcm256Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public AriaCcm256Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AriaCcm256();

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
/// Benchmarks for Camellia-128-GCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "Camellia-128-GCM")]
[NonParallelizable]
public class CamelliaGcm128Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public CamelliaGcm128Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public CamelliaGcm128Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.CamelliaGcm128();

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
/// Benchmarks for Camellia-256-GCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "Camellia-256-GCM")]
[NonParallelizable]
public class CamelliaGcm256Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public CamelliaGcm256Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public CamelliaGcm256Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.CamelliaGcm256();

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
/// Benchmarks for Camellia-128-CCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "Camellia-128-CCM")]
[NonParallelizable]
public class CamelliaCcm128Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public CamelliaCcm128Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public CamelliaCcm128Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.CamelliaCcm128();

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
/// Benchmarks for Camellia-256-CCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "Camellia-256-CCM")]
[NonParallelizable]
public class CamelliaCcm256Benchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public CamelliaCcm256Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public CamelliaCcm256Benchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.CamelliaCcm256();

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
/// Benchmarks for SEED-GCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "SEED-GCM")]
[NonParallelizable]
public class SeedGcmBenchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public SeedGcmBenchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public SeedGcmBenchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.SeedGcm();

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
/// Benchmarks for Kuznyechik-GCM authenticated encryption.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "AEAD", "Regional", "Kuznyechik-GCM")]
[NonParallelizable]
public class KuznyechikGcmBenchmark : AeadBenchmarkBase
{
    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public KuznyechikGcmBenchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="AeadBenchmarkBase"/>
    public KuznyechikGcmBenchmark(CipherAlgorithmType algorithm)
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
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.KuznyechikGcm();

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
