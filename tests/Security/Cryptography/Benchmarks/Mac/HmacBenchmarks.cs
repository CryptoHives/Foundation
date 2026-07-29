// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Mac;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for HMAC-MD5 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "HMAC", "HMAC-MD5")]
[NonParallelizable]
public class HmacMd5Benchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.HmacMd5();

    public HmacMd5Benchmark() { }
    public HmacMd5Benchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}

/// <summary>
/// Benchmark for HMAC-SHA1 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "HMAC", "HMAC-SHA1")]
[NonParallelizable]
public class HmacSha1Benchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.HmacSha1();

    public HmacSha1Benchmark() { }
    public HmacSha1Benchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}

/// <summary>
/// Benchmark for HMAC-SHA256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "HMAC", "HMAC-SHA256")]
[NonParallelizable]
public class HmacSha256Benchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.HmacSha256();

    public HmacSha256Benchmark() { }
    public HmacSha256Benchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}

/// <summary>
/// Benchmark for HMAC-SHA384 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "HMAC", "HMAC-SHA384")]
[NonParallelizable]
public class HmacSha384Benchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.HmacSha384();

    public HmacSha384Benchmark() { }
    public HmacSha384Benchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}

/// <summary>
/// Benchmark for HMAC-SHA512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "HMAC", "HMAC-SHA512")]
[NonParallelizable]
public class HmacSha512Benchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.HmacSha512();

    public HmacSha512Benchmark() { }
    public HmacSha512Benchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}

/// <summary>
/// Benchmark for HMAC-SHA3-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "HMAC", "HMAC-SHA3-256")]
[NonParallelizable]
public class HmacSha3_256Benchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.HmacSha3_256();

    public HmacSha3_256Benchmark() { }
    public HmacSha3_256Benchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}

/// <summary>
/// Benchmark for HMAC-SHA3-384 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "HMAC", "HMAC-SHA3-384")]
[NonParallelizable]
public class HmacSha3_384Benchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.HmacSha3_384();

    public HmacSha3_384Benchmark() { }
    public HmacSha3_384Benchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}

/// <summary>
/// Benchmark for HMAC-SHA3-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "HMAC", "HMAC-SHA3-512")]
[NonParallelizable]
public class HmacSha3_512Benchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.HmacSha3_512();

    public HmacSha3_512Benchmark() { }
    public HmacSha3_512Benchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}
