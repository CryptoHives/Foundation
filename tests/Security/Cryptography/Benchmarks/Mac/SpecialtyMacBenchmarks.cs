// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Mac;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for AES-CMAC implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "CMAC", "AES-CMAC")]
[NonParallelizable]
public class AesCmacBenchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.AesCmac();

    public AesCmacBenchmark() { }
    public AesCmacBenchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}

/// <summary>
/// Benchmark for Poly1305 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(MacAlgorithmTypeArgs))]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "Poly1305")]
[NonParallelizable]
public class Poly1305Benchmark : ParameterizedMacBenchmark
{
    public static readonly object[] MacAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<MacAlgorithmType> Algorithms() => MacAlgorithmType.Poly1305();

    public Poly1305Benchmark() { }
    public Poly1305Benchmark(MacAlgorithmType macAlgorithm) : base(macAlgorithm) { }
}
