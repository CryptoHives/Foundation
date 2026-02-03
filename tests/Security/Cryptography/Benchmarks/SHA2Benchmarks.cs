// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for SHA-224 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA224")]
[NonParallelizable]
public class SHA224Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA224();

    public SHA224Benchmark() { }
    public SHA224Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for SHA-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA256")]
[NonParallelizable]
public class SHA256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA256();

    public SHA256Benchmark() { }
    public SHA256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for SHA-384 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA384")]
[NonParallelizable]
public class SHA384Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA384();

    public SHA384Benchmark() { }
    public SHA384Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for SHA-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA512")]
[NonParallelizable]
public class SHA512Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA512();

    public SHA512Benchmark() { }
    public SHA512Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for SHA-512/224 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA512_224")]
[NonParallelizable]
public class SHA512_224Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA512_224();

    public SHA512_224Benchmark() { }
    public SHA512_224Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for SHA-512/256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "SHA2", "SHA512_256")]
[NonParallelizable]
public class SHA512_256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA512_256();

    public SHA512_256Benchmark() { }
    public SHA512_256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}
