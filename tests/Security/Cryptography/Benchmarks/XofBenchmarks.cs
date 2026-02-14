// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// XOF benchmark for SHAKE128 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "SHAKE", "Shake128Xof")]
[NonParallelizable]
public class Shake128XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.Shake128();

    public Shake128XofBenchmark() { }
    public Shake128XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for SHAKE256 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "SHAKE", "Shake256Xof")]
[NonParallelizable]
public class Shake256XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.Shake256();

    public Shake256XofBenchmark() { }
    public Shake256XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for cSHAKE128 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "cSHAKE", "CShake128Xof")]
[NonParallelizable]
public class CShake128XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.CShake128();

    public CShake128XofBenchmark() { }
    public CShake128XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for cSHAKE256 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "cSHAKE", "CShake256Xof")]
[NonParallelizable]
public class CShake256XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.CShake256();

    public CShake256XofBenchmark() { }
    public CShake256XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for TurboSHAKE128 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "TurboSHAKE", "TurboShake128Xof")]
[NonParallelizable]
public class TurboShake128XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.TurboShake128();

    public TurboShake128XofBenchmark() { }
    public TurboShake128XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for TurboSHAKE256 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "TurboSHAKE", "TurboShake256Xof")]
[NonParallelizable]
public class TurboShake256XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.TurboShake256();

    public TurboShake256XofBenchmark() { }
    public TurboShake256XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for KT128 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "KT", "KT128Xof")]
[NonParallelizable]
public class KT128XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.KT128();

    public KT128XofBenchmark() { }
    public KT128XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for KT256 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "KT", "KT256Xof")]
[NonParallelizable]
public class KT256XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.KT256();

    public KT256XofBenchmark() { }
    public KT256XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for KMAC128 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "KMAC", "KMac128Xof")]
[NonParallelizable]
public class KMac128XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.KMac128();

    public KMac128XofBenchmark() { }
    public KMac128XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for KMAC256 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "KMAC", "KMac256Xof")]
[NonParallelizable]
public class KMac256XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.KMac256();

    public KMac256XofBenchmark() { }
    public KMac256XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for BLAKE3 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "BLAKE3", "Blake3Xof")]
[NonParallelizable]
public class Blake3XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.Blake3();

    public Blake3XofBenchmark() { }
    public Blake3XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}

/// <summary>
/// XOF benchmark for Ascon-XOF128 (Absorb/Squeeze/Reset cycle).
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(XofAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("XOF", "Ascon", "AsconXof128Xof")]
[NonParallelizable]
public class AsconXof128XofBenchmark : ParameterizedXofBenchmark
{
    public static readonly object[] XofAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<XofAlgorithmType> Algorithms() => XofAlgorithmType.AsconXof128();

    public AsconXof128XofBenchmark() { }
    public AsconXof128XofBenchmark(XofAlgorithmType xofAlgorithm) : base(xofAlgorithm) { }
}
