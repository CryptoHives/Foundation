// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for BLAKE2b-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE2b", "BLAKE2b256")]
[NonParallelizable]
public class Blake2b256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake2b256();

    public Blake2b256Benchmark() { }
    public Blake2b256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for BLAKE2b-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE2b", "BLAKE2b512")]
[NonParallelizable]
public class Blake2b512Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake2b512();

    public Blake2b512Benchmark() { }
    public Blake2b512Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for BLAKE2s-128 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE2s", "BLAKE2s128")]
[NonParallelizable]
public class Blake2s128Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake2s128();

    public Blake2s128Benchmark() { }
    public Blake2s128Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for BLAKE2s-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE2s", "BLAKE2s256")]
[NonParallelizable]
public class Blake2s256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake2s256();

    public Blake2s256Benchmark() { }
    public Blake2s256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for BLAKE3 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "BLAKE3", "BLAKE3")]
[NonParallelizable]
public class Blake3Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Blake3();

    public Blake3Benchmark() { }
    public Blake3Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}
