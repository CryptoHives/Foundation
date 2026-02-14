// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for KMAC-128 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "KMAC", "KMac128")]
[NonParallelizable]
public class KMac128Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.KMac128();

    public KMac128Benchmark() { }
    public KMac128Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for KMAC-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "KMAC", "KMac256")]
[NonParallelizable]
public class KMac256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.KMac256();

    public KMac256Benchmark() { }
    public KMac256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}
