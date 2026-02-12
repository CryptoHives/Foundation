// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Benchmark for MD5 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Legacy", "MD5")]
[NonParallelizable]
public class MD5Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.MD5();

    public MD5Benchmark() { }
    public MD5Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for SHA-1 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Legacy", "SHA1")]
[NonParallelizable]
public class SHA1Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SHA1();

    public SHA1Benchmark() { }
    public SHA1Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for SM3 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "SM3")]
[NonParallelizable]
public class SM3Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.SM3();

    public SM3Benchmark() { }
    public SM3Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for Streebog-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "Streebog256")]
[NonParallelizable]
public class Streebog256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Streebog256();

    public Streebog256Benchmark() { }
    public Streebog256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for Streebog-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "Streebog512")]
[NonParallelizable]
public class Streebog512Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Streebog512();

    public Streebog512Benchmark() { }
    public Streebog512Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for Whirlpool implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "Whirlpool")]
[NonParallelizable]
public class WhirlpoolBenchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Whirlpool();

    public WhirlpoolBenchmark() { }
    public WhirlpoolBenchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for RIPEMD-160 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "RIPEMD", "RIPEMD160")]
[NonParallelizable]
public class Ripemd160Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Ripemd160();

    public Ripemd160Benchmark() { }
    public Ripemd160Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for Ascon-Hash256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Ascon", "AsconHash256")]
[NonParallelizable]
public class AsconHash256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.AsconHash256();

    public AsconHash256Benchmark() { }
    public AsconHash256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for Ascon-XOF128 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Ascon", "AsconXof128")]
[NonParallelizable]
public class AsconXof128Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.AsconXof128();

    public AsconXof128Benchmark() { }
    public AsconXof128Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for Kupyna-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "Kupyna256")]
[NonParallelizable]
public class Kupyna256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Kupyna256();

    public Kupyna256Benchmark() { }
    public Kupyna256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for Kupyna-384 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "Kupyna384")]
[NonParallelizable]
public class Kupyna384Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Kupyna384();

    public Kupyna384Benchmark() { }
    public Kupyna384Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for Kupyna-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "Kupyna512")]
[NonParallelizable]
public class Kupyna512Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Kupyna512();

    public Kupyna512Benchmark() { }
    public Kupyna512Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for LSH-256-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "LSH-256-256")]
[NonParallelizable]
public class Lsh256_256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Lsh256_256();

    public Lsh256_256Benchmark() { }
    public Lsh256_256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for LSH-512-256 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "LSH-512-256")]
[NonParallelizable]
public class Lsh512_256Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Lsh512_256();

    public Lsh512_256Benchmark() { }
    public Lsh512_256Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}

/// <summary>
/// Benchmark for LSH-512-512 implementations.
/// </summary>
[TestFixture]
[TestFixtureSource(nameof(HashAlgorithmTypeArgs))]
[Config(typeof(HashConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Regional", "LSH-512-512")]
[NonParallelizable]
public class Lsh512_512Benchmark : ParameterizedHashBenchmark
{
    public static readonly object[] HashAlgorithmTypeArgs = Algorithms().Select(s => new object[] { s }).ToArray();
    public static IEnumerable<HashAlgorithmType> Algorithms() => HashAlgorithmType.Lsh512_512();

    public Lsh512_512Benchmark() { }
    public Lsh512_512Benchmark(HashAlgorithmType hashAlgorithm) : base(hashAlgorithm) { }
}
