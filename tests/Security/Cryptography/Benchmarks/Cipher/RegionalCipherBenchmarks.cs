// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Cipher;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for SM4-CBC symmetric encryption (China, GB/T 32907-2016).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Regional", "SM4-CBC")]
[NonParallelizable]
public class Sm4CbcBenchmark : CipherBenchmarkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sm4CbcBenchmark"/> class.
    /// </summary>
    public Sm4CbcBenchmark() => TestDataSize = DataSize.K8;

    /// <summary>
    /// Initializes a new instance of the <see cref="Sm4CbcBenchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The cipher algorithm to benchmark.</param>
    public Sm4CbcBenchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.Sm4Cbc();

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}

/// <summary>
/// Benchmarks for ARIA-128-CBC symmetric encryption (Korea, KS X 1213).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Regional", "ARIA-128-CBC")]
[NonParallelizable]
public class AriaCbc128Benchmark : CipherBenchmarkBase
{
    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public AriaCbc128Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public AriaCbc128Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AriaCbc128();

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}

/// <summary>
/// Benchmarks for ARIA-256-CBC symmetric encryption (Korea, KS X 1213).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Regional", "ARIA-256-CBC")]
[NonParallelizable]
public class AriaCbc256Benchmark : CipherBenchmarkBase
{
    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public AriaCbc256Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public AriaCbc256Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.AriaCbc256();

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}

/// <summary>
/// Benchmarks for Camellia-128-CBC symmetric encryption (Japan, CRYPTREC).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Regional", "Camellia-128-CBC")]
[NonParallelizable]
public class CamelliaCbc128Benchmark : CipherBenchmarkBase
{
    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public CamelliaCbc128Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public CamelliaCbc128Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.CamelliaCbc128();

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}

/// <summary>
/// Benchmarks for Camellia-256-CBC symmetric encryption (Japan, CRYPTREC).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Regional", "Camellia-256-CBC")]
[NonParallelizable]
public class CamelliaCbc256Benchmark : CipherBenchmarkBase
{
    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public CamelliaCbc256Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public CamelliaCbc256Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.CamelliaCbc256();

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}

/// <summary>
/// Benchmarks for Kuznyechik-CBC symmetric encryption (Russia, GOST R 34.12-2015).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Regional", "Kuznyechik-CBC")]
[NonParallelizable]
public class KuznyechikCbcBenchmark : CipherBenchmarkBase
{
    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public KuznyechikCbcBenchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public KuznyechikCbcBenchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.KuznyechikCbc();

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}

/// <summary>
/// Benchmarks for Kalyna-128-CBC symmetric encryption (Ukraine, DSTU 7624:2014).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Regional", "Kalyna-128-CBC")]
[NonParallelizable]
public class KalynaCbc128Benchmark : CipherBenchmarkBase
{
    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public KalynaCbc128Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public KalynaCbc128Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.KalynaCbc128();

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}

/// <summary>
/// Benchmarks for Kalyna-256-CBC symmetric encryption (Ukraine, DSTU 7624:2014).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Regional", "Kalyna-256-CBC")]
[NonParallelizable]
public class KalynaCbc256Benchmark : CipherBenchmarkBase
{
    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public KalynaCbc256Benchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public KalynaCbc256Benchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.KalynaCbc256();

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}

/// <summary>
/// Benchmarks for SEED-CBC symmetric encryption (Korea, KISA, RFC 4269).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "Regional", "SEED-CBC")]
[NonParallelizable]
public class SeedCbcBenchmark : CipherBenchmarkBase
{
    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public SeedCbcBenchmark() => TestDataSize = DataSize.K8;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public SeedCbcBenchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<DataSize> Sizes() => DataSize.Standard;

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<CipherAlgorithmType> Algorithms() => CipherAlgorithmType.SeedCbc();

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
            yield return new object[] { alg };
    }

    /// <inheritdoc/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
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

    /// <inheritdoc cref="CipherBenchmarkBase"/>
    [Benchmark(Description = "Decrypt")]
    public int Decrypt()
    {
        Decryptor!.Reset();
        return Decryptor.TransformFinalBlock(EncryptedData, OutputData);
    }
}
