// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Kem;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Diagnostic benchmarks for the internals of the managed ML-KEM implementation.
/// </summary>
/// <remarks>
/// <para>
/// Unlike <see cref="MLKemBenchmark"/> these are CryptoHives-only and measure no
/// competitor — they exist to attribute the gap in <see cref="MLKemBenchmark"/> to
/// specific code, so optimization work is directed by measurement rather than by reading.
/// Each pair below answers one open question:
/// </para>
/// <list type="bullet">
///   <item><description>
///     <c>KeyGen</c> versus <c>KPkeKeyGenCore</c> — how much of key generation is the
///     pairwise consistency test, which runs a full encapsulate and decapsulate of its own.
///   </description></item>
///   <item><description>
///     <c>SampleNttEntry</c> — the cost and allocation of one matrix entry. A single
///     operation generates k² of them (16 at ML-KEM-1024), and each currently allocates its
///     own SHAKE128 instance.
///   </description></item>
///   <item><description>
///     <c>ByteEncodeD</c> / <c>ByteDecodeD</c> — the generic bit-at-a-time packers, which
///     loop 256·d times per polynomial.
///   </description></item>
/// </list>
/// <para>
/// These reach into <c>internal</c> types via <c>InternalsVisibleTo</c>, so they are tied
/// to the current shape of the implementation and are expected to be rewritten or dropped
/// as that shape changes. They are not a stable API surface.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(ParameterSetArgs))]
[Config(typeof(KemConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Kem", "ML-KEM", "Internals")]
[NonParallelizable]
public class MLKemInternalsBenchmark
{
    private MLKemParams _params = null!;
    private byte[] _seed = null!;
    private byte[] _encapsulationKey = null!;
    private byte[] _decapsulationKey = null!;
    private byte[] _ekPke = null!;
    private byte[] _dkPke = null!;
    private byte[] _matrixSeed = null!;
    private short[] _poly = null!;
    private short[] _decoded = null!;
    private byte[] _packed = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="MLKemInternalsBenchmark"/> class for BenchmarkDotNet.
    /// </summary>
    public MLKemInternalsBenchmark()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MLKemInternalsBenchmark"/> class for NUnit.
    /// </summary>
    /// <param name="parameterSet">The parameter set to exercise.</param>
    public MLKemInternalsBenchmark(string parameterSet) => ParameterSet = parameterSet;

    /// <summary>
    /// Gets or sets the parameter set under measurement.
    /// </summary>
    [ParamsSource(nameof(ParameterSets))]
    public string ParameterSet { get; set; } = "ML-KEM-768";

    /// <summary>
    /// Gets the parameter sets to benchmark.
    /// </summary>
    public static IEnumerable<string> ParameterSets() => ["ML-KEM-512", "ML-KEM-768", "ML-KEM-1024"];

    /// <summary>
    /// Gets the NUnit fixture arguments.
    /// </summary>
    public static IEnumerable<object[]> ParameterSetArgs()
    {
        foreach (string name in ParameterSets())
        {
            yield return new object[] { name };
        }
    }

    /// <summary>
    /// Allocates the buffers the measured methods write into.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        _params = ParameterSet switch {
            "ML-KEM-512" => MLKemParams.MLKem512,
            "ML-KEM-768" => MLKemParams.MLKem768,
            "ML-KEM-1024" => MLKemParams.MLKem1024,
            _ => throw new ArgumentException($"Unknown parameter set: {ParameterSet}", nameof(ParameterSet)),
        };

        _seed = new byte[MLKemParams.KeyGenSeedBytes];
        for (int i = 0; i < _seed.Length; i++)
        {
            _seed[i] = (byte)((i * 17 + 3) & 0xFF);
        }

        _encapsulationKey = new byte[_params.EncapsulationKeyBytes];
        _decapsulationKey = new byte[_params.DecapsulationKeyBytes];
        _ekPke = new byte[_params.EncapsulationKeyBytes];
        _dkPke = new byte[_params.PolyVecEncodedBytes];

        // ρ ‖ j ‖ i, the 34-byte XOF seed for one matrix entry.
        _matrixSeed = new byte[34];
        for (int i = 0; i < 32; i++)
        {
            _matrixSeed[i] = (byte)((i * 11 + 7) & 0xFF);
        }

        _poly = new short[MLKemParams.N];
        _decoded = new short[MLKemParams.N];
        Poly.SampleNtt(_matrixSeed, _poly);

        // Coefficients must be in [0, 2^du) for the packers, matching what
        // PolyVec.CompressAndEncode hands them after compression.
        int mask = (1 << _params.Du) - 1;
        for (int i = 0; i < _poly.Length; i++)
        {
            _poly[i] = (short)(_poly[i] & mask);
        }

        _packed = new byte[32 * _params.Du];
        Encode.ByteEncodeD(_poly, _params.Du, _packed);
    }

    [Test]
    [NonParallelizable]
    public void KeyGenTest()
    {
        KeyGen();
        Assert.That(_encapsulationKey, Is.Not.All.Zero);
        Assert.That(_decapsulationKey, Is.Not.All.Zero);
    }

    /// <summary>
    /// Benchmarks full ML-KEM key generation, including the pairwise consistency test.
    /// </summary>
    /// <remarks>
    /// This is what a caller of <c>MLKem.GenerateKey</c> or <c>MLKem.ImportPrivateSeed</c>
    /// actually pays. Compare against <see cref="KPkeKeyGenCore"/>.
    /// </remarks>
    [Benchmark(Description = "KeyGen (with PCT)")]
    public void KeyGen() => MLKemCore.KeyGen(_params, _seed, _encapsulationKey, _decapsulationKey);

    [Test]
    [NonParallelizable]
    public void KPkeKeyGenCoreTest()
    {
        KPkeKeyGenCore();
        Assert.That(_ekPke, Is.Not.All.Zero);
        Assert.That(_dkPke, Is.Not.All.Zero);
    }

    /// <summary>
    /// Benchmarks the K-PKE key generation that underlies ML-KEM key generation, without
    /// the pairwise consistency test.
    /// </summary>
    /// <remarks>
    /// The difference against <see cref="KeyGen"/> is the consistency test plus the cheap
    /// hashing and copying that assembles the expanded decapsulation key.
    /// </remarks>
    [Benchmark(Description = "KeyGen (K-PKE core, no PCT)")]
    public void KPkeKeyGenCore()
        => MLKemCore.KPkeKeyGen(_params, _seed.AsSpan(0, 32), _ekPke, _dkPke);

    [Test]
    [NonParallelizable]
    public void SampleNttEntryTest()
    {
        SampleNttEntry();
        Assert.That(_poly, Is.Not.All.Zero);
    }

    /// <summary>
    /// Benchmarks generation of a single matrix entry Â[i][j] = SampleNTT(ρ ‖ j ‖ i).
    /// </summary>
    /// <remarks>
    /// Multiply by k² for the per-operation cost: 4 entries at ML-KEM-512, 9 at 768,
    /// 16 at 1024.
    /// </remarks>
    [Benchmark(Description = "SampleNtt (one matrix entry)")]
    public void SampleNttEntry() => Poly.SampleNtt(_matrixSeed, _poly);

    [Test]
    [NonParallelizable]
    public void ByteEncodeDTest()
    {
        ByteEncodeD();
        Assert.That(_packed, Has.Length.EqualTo(32 * _params.Du));
    }

    /// <summary>
    /// Benchmarks packing one polynomial at the ciphertext's d_u bit width.
    /// </summary>
    [Benchmark(Description = "ByteEncodeD (one polynomial)")]
    public void ByteEncodeD() => Encode.ByteEncodeD(_poly, _params.Du, _packed);

    [Test]
    [NonParallelizable]
    public void ByteDecodeDTest()
    {
        ByteDecodeD();
        Assert.That(_decoded, Is.EqualTo(_poly), "Decode must round-trip the encoded polynomial.");
    }

    /// <summary>
    /// Benchmarks unpacking one polynomial at the ciphertext's d_u bit width.
    /// </summary>
    [Benchmark(Description = "ByteDecodeD (one polynomial)")]
    public void ByteDecodeD() => Encode.ByteDecodeD(_packed, _params.Du, _decoded);
}
