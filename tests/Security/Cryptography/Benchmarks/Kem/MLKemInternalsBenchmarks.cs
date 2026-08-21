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
    private byte[] _rho = null!;
    private short[] _matrix = null!;
    private byte[] _cbdSeed = null!;
    private byte[] _cbdBuf2 = null!;
    private byte[] _cbdBuf3 = null!;
    private short[] _cbdCoeffs = null!;
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

        // ρ ‖ j ‖ i, the 34-byte XOF seed for one matrix entry. GenerateMatrix appends the
        // two index bytes itself, so it takes the bare 32-byte ρ.
        _matrixSeed = new byte[34];
        for (int i = 0; i < 32; i++)
        {
            _matrixSeed[i] = (byte)((i * 11 + 7) & 0xFF);
        }

        _rho = new byte[32];
        Array.Copy(_matrixSeed, _rho, 32);
        _matrix = new short[PolyVec.MatrixLength(_params.K)];

        // CBD inputs. The PRF emits 64·η bytes per polynomial: 128 for η=2, 192 for η=3.
        // Contents are irrelevant to timing — CBD is data-independent by construction, which
        // is the point — but they are filled so the range assertions in the tests mean something.
        _cbdSeed = new byte[32];
        _cbdBuf2 = new byte[64 * 2];
        _cbdBuf3 = new byte[64 * 3];
        _cbdCoeffs = new short[MLKemParams.N];
        for (int i = 0; i < _cbdSeed.Length; i++)
        {
            _cbdSeed[i] = (byte)((i * 23 + 5) & 0xFF);
        }

        for (int i = 0; i < _cbdBuf3.Length; i++)
        {
            byte value = (byte)((i * 97 + 41) & 0xFF);
            if (i < _cbdBuf2.Length)
            {
                _cbdBuf2[i] = value;
            }

            _cbdBuf3[i] = value;
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
    /// 16 at 1024. See <see cref="GenerateMatrix"/> for the whole thing measured directly.
    /// </remarks>
    [Benchmark(Description = "SampleNtt (one matrix entry)")]
    public void SampleNttEntry() => Poly.SampleNtt(_matrixSeed, _poly);

    [Test]
    [NonParallelizable]
    public void SampleCbdTest()
    {
        SampleCbd();

        int eta = _params.Eta1;
        Assert.That(_cbdCoeffs, Has.All.InRange((short)-eta, (short)eta),
            $"CBD coefficients must lie in [-{eta}, {eta}].");
    }

    /// <summary>
    /// Benchmarks the production CBD sampling path — PRF plus bit extraction — at this
    /// parameter set's η₁.
    /// </summary>
    /// <remarks>
    /// This is the row to read against <see cref="CbdEta2"/> and <see cref="CbdEta3"/>: the
    /// difference is the SHAKE256 PRF, and it decides whether vectorizing the bit extraction
    /// is worth doing at all. The Allocated column is also the per-polynomial <c>byte[64·η]</c>
    /// this method allocates, which is one of the items in the allocation cleanup.
    /// <para>
    /// η₁ is 3 for ML-KEM-512 and 2 for ML-KEM-768/1024, so this row is not comparable
    /// across parameter sets — 512 does strictly more work per call.
    /// </para>
    /// </remarks>
    [Benchmark(Description = "SampleCbd (PRF + CBD)")]
    public void SampleCbd() => MLKemCore.SampleCbd(_cbdSeed, 0, _params.Eta1, _cbdCoeffs);

    [Test]
    [NonParallelizable]
    public void CbdEta2Test()
    {
        CbdEta2();
        Assert.That(_cbdCoeffs, Has.All.InRange((short)-2, (short)2),
            "B₂ coefficients must lie in [-2, 2].");
    }

    /// <summary>
    /// Benchmarks CBD bit extraction alone for η=2, over the 128 bytes the PRF would supply.
    /// </summary>
    /// <remarks>
    /// η=2 is used for every error vector in encryption and for s and e at ML-KEM-768/1024,
    /// so this is the hot one. The work does not vary by parameter set: identical figures
    /// across the three rows are the expected result, and a spread is a noise-floor warning
    /// rather than a finding.
    /// </remarks>
    [Benchmark(Description = "Cbd.Eta2 (bit extraction only)")]
    public void CbdEta2() => Cbd.Eta2(_cbdBuf2, _cbdCoeffs);

    [Test]
    [NonParallelizable]
    public void CbdEta3Test()
    {
        CbdEta3();
        Assert.That(_cbdCoeffs, Has.All.InRange((short)-3, (short)3),
            "B₃ coefficients must lie in [-3, 3].");
    }

    /// <summary>
    /// Benchmarks CBD bit extraction alone for η=3, over the 192 bytes the PRF would supply.
    /// </summary>
    /// <remarks>
    /// η=3 is reached only by ML-KEM-512 key generation. Measured on every parameter set
    /// anyway so it can be compared against <see cref="CbdEta2"/> directly: its 3-bit fields
    /// do not align to nibbles, so it is the harder of the two to vectorize and the less
    /// valuable to.
    /// </remarks>
    [Benchmark(Description = "Cbd.Eta3 (bit extraction only)")]
    public void CbdEta3() => Cbd.Eta3(_cbdBuf3, _cbdCoeffs);

    [Test]
    [NonParallelizable]
    public void GenerateMatrixTest()
    {
        GenerateMatrix();

        Assert.That(_matrix, Has.Length.EqualTo(_params.K * _params.K * MLKemParams.N));
        Assert.That(_matrix, Is.Not.All.Zero, "Every matrix entry must be sampled.");
        Assert.That(_matrix, Has.All.InRange((short)0, (short)(MLKemParams.Q - 1)),
            "SampleNTT coefficients must lie in [0, q).");
    }

    /// <summary>
    /// Benchmarks generation of the whole k × k matrix Â, as every ML-KEM operation does.
    /// </summary>
    /// <remarks>
    /// Measures the production <c>MLKemCore.GenerateMatrix</c> rather than a copy, so it
    /// includes the jagged-array allocation that <see cref="SampleNttEntry"/> alone does
    /// not. Compare directly against the Encapsulate and Decapsulate rows in
    /// <c>MLKemBenchmark</c>: this is work every operation repeats, and every entry is
    /// consumed exactly once, so none of it needs to be materialized up front.
    /// <para>
    /// The destination buffer is allocated once in setup, so this row is the sampling work
    /// alone. Production still allocates one flat <c>short[k²·N]</c> per call — the
    /// Allocated column on the Encapsulate and Decapsulate rows carries that cost.
    /// </para>
    /// </remarks>
    [Benchmark(Description = "GenerateMatrix (k x k)")]
    public void GenerateMatrix() => MLKemCore.GenerateMatrix(_matrix, _params.K, _rho);

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
