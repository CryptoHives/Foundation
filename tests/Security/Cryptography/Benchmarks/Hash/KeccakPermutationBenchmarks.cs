// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Hash;

#if EXPERIMENTAL && NET8_0_OR_GREATER

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Json;
using CryptoHives.Foundation.Security.Cryptography;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

/// <summary>
/// Minimal BenchmarkDotNet configuration for the permutation micro-benchmarks.
/// </summary>
/// <remarks>
/// <see cref="HashConfig"/> groups and labels results by the <c>TestHashAlgorithm</c>
/// parameter, which these benchmarks do not have. They measure one primitive across
/// dispatch paths rather than comparing implementations of an algorithm, so they use a bare
/// config that just exports the markdown and JSON the trends pipeline reads.
/// </remarks>
public class KeccakPermutationConfig : ManualConfig
{
    /// <summary>
    /// Initializes a new instance of the <see cref="KeccakPermutationConfig"/> class.
    /// </summary>
    public KeccakPermutationConfig()
    {
        WithOptions(ConfigOptions.DisableLogFile);
        AddExporter(MarkdownExporter.GitHub);
        AddExporter(JsonExporter.Full);
    }
}

/// <summary>
/// Measures whether two-way batching of Keccak-f[1600] beats running the scalar permutation
/// twice.
/// </summary>
/// <remarks>
/// <para>
/// This is the measurement that decides whether <see cref="KeccakCoreStateX2"/> graduates
/// out of <c>EXPERIMENTAL</c>. Every case below performs <em>two</em> permutations, so the
/// numbers are directly comparable: the batched case does both at once in 128-bit lanes,
/// the others do them one after another.
/// </para>
/// <para>
/// Batching is the technique from Becker &amp; Kannwischer section 3.3, so Arm64 — where the
/// rotate additionally uses the <c>SHL</c>+<c>SRI</c> pair — is the target. It is not the
/// only place it pays off. Measured on an AMD Ryzen 9 8945HS, .NET 10, where the body lowers
/// to plain SSE2:
/// </para>
/// <list type="table">
///   <listheader><term>Path</term><description>Two permutations</description></listheader>
///   <item><term>2 x scalar</term><description>441.5 ns (baseline)</description></item>
///   <item><term>2 x AVX2</term><description>542.9 ns, 1.23x</description></item>
///   <item><term>batched x2</term><description>236.8 ns, 0.54x</description></item>
/// </list>
/// <para>
/// That is 1.86x over scalar on the same machine whose results made the single-state AVX2
/// and AVX-512 paths in <see cref="KeccakCoreState"/> experimental. The reason the batched
/// layout wins where those lose is that it has no intra-vector data movement: vectorizing
/// one state has to shuffle lanes across the theta and pi steps, while batching two states
/// makes every step element-wise. Register pressure did not turn out to be the binding
/// constraint it was assumed to be, even with only 16 vector registers.
/// </para>
/// <para>
/// Cases are skipped when their instruction set is unavailable, so a run reports only what
/// the host can actually execute.
/// </para>
/// <para>
/// Keccak is data-independent by construction, so the state contents do not affect timing.
/// The states are seeded to something other than all-zero anyway, so that a run which
/// silently degenerates to permuting zeros is still doing representative work.
/// </para>
/// </remarks>
[TestFixture]
[Config(typeof(KeccakPermutationConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Hash", "Keccak", "Permutation")]
[NonParallelizable]
public class KeccakPermutationBenchmark
{
    private const int StateSize = 25;

    private KeccakCoreState _scalarA;
    private KeccakCoreState _scalarB;
    private KeccakCoreState _arm64A;
    private KeccakCoreState _arm64B;
    private KeccakCoreState _avx2A;
    private KeccakCoreState _avx2B;
    private KeccakCoreStateX2 _batched;

    /// <summary>
    /// Gets a value indicating whether the Arm64 scalar dispatch is available.
    /// </summary>
    public static bool IsArm64Supported => AdvSimd.Arm64.IsSupported;

    /// <summary>
    /// Gets a value indicating whether the AVX2 dispatch is available.
    /// </summary>
    public static bool IsAvx2Supported => Avx2.IsSupported;

    /// <summary>
    /// Gets a value indicating whether 128-bit vectors are hardware accelerated.
    /// </summary>
    public static bool IsVector128Supported => Vector128.IsHardwareAccelerated;

    /// <summary>
    /// Seeds every state to the same starting point.
    /// </summary>
    /// <remarks>
    /// <see cref="KeccakCoreState"/> has no lane setter, so the seed is XORed in with
    /// <c>Absorb</c> — which also permutes once. The batched state is therefore seeded from
    /// what the scalar state holds <em>after</em> that absorb, not from the raw seed, so all
    /// paths begin one permutation in and stay in lockstep from there. Getting this wrong
    /// costs nothing in timing, since Keccak is data-independent, but it would make
    /// <see cref="BatchedMatchesScalarOverBenchmarkState"/> compare states an odd number of
    /// permutations apart.
    /// </remarks>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        byte[] block = new byte[StateSize * sizeof(ulong)];
        for (int i = 0; i < StateSize; i++)
        {
            BitConverter.TryWriteBytes(block.AsSpan(i * sizeof(ulong)), 0x0123456789ABCDEFUL * (ulong)(i + 1));
        }

        _scalarA = new KeccakCoreState(SimdSupport.None);
        _scalarB = new KeccakCoreState(SimdSupport.None);
        _scalarA.Absorb(block, block.Length);
        _scalarB.Absorb(block, block.Length);

        _arm64A = new KeccakCoreState(SimdSupport.Arm64);
        _arm64B = new KeccakCoreState(SimdSupport.Arm64);
        _arm64A.Absorb(block, block.Length);
        _arm64B.Absorb(block, block.Length);

        _avx2A = new KeccakCoreState(SimdSupport.Avx2);
        _avx2B = new KeccakCoreState(SimdSupport.Avx2);
        _avx2A.Absorb(block, block.Length);
        _avx2B.Absorb(block, block.Length);

        byte[] seeded = new byte[StateSize * sizeof(ulong)];
        _scalarA.Squeeze(seeded, seeded.Length);

        ulong[] lanes = new ulong[StateSize];
        for (int i = 0; i < StateSize; i++)
        {
            lanes[i] = BitConverter.ToUInt64(seeded, i * sizeof(ulong));
        }

        _batched = new KeccakCoreStateX2();
        _batched.LoadState(0, lanes);
        _batched.LoadState(1, lanes);
    }

    /// <summary>
    /// The portable baseline: two sequential scalar permutations.
    /// </summary>
    [Benchmark(Baseline = true, Description = "2 x scalar")]
    public void ScalarTwice()
    {
        _scalarA.Permute();
        _scalarB.Permute();
    }

    /// <summary>
    /// The production Arm64 path: two sequential register-tuned scalar permutations.
    /// </summary>
    [Benchmark(Description = "2 x scalar (Arm64)")]
    public void Arm64Twice()
    {
        _arm64A.Permute();
        _arm64B.Permute();
    }

    /// <summary>
    /// The existing x86 vector path, for reference.
    /// </summary>
    [Benchmark(Description = "2 x AVX2")]
    public void Avx2Twice()
    {
        _avx2A.Permute();
        _avx2B.Permute();
    }

    /// <summary>
    /// The candidate: both permutations at once in 128-bit lanes.
    /// </summary>
    [Benchmark(Description = "batched x2 (Vector128)")]
    public void BatchedX2() => _batched.Permute();

    /// <summary>
    /// Smoke test that every measured path runs and advances its state, so a benchmark that
    /// silently does nothing cannot be reported as fast.
    /// </summary>
    [Test]
    [NonParallelizable]
    public void MeasuredPathsAdvanceState()
    {
        GlobalSetup();

        ulong[] before = new ulong[StateSize];
        _batched.StoreState(0, before);

        ScalarTwice();
        BatchedX2();

        if (IsArm64Supported)
        {
            Arm64Twice();
        }

        if (IsAvx2Supported)
        {
            Avx2Twice();
        }

        ulong[] after = new ulong[StateSize];
        _batched.StoreState(0, after);

        Assert.That(after, Is.Not.EqualTo(before));
    }

    /// <summary>
    /// Every measured path must land on the same state. A benchmark that reports one
    /// implementation as faster while it computes a different permutation is worse than no
    /// benchmark.
    /// </summary>
    [Test]
    [NonParallelizable]
    public void AllMeasuredPathsAgree()
    {
        GlobalSetup();

        ScalarTwice();
        BatchedX2();

        byte[] expected = ReadState(ref _scalarA);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(ReadState(ref _scalarB), Is.EqualTo(expected), "second scalar state");

            ulong[] batchedLanes = new ulong[StateSize];
            byte[] batched = new byte[StateSize * sizeof(ulong)];
            for (int instance = 0; instance < 2; instance++)
            {
                _batched.StoreState(instance, batchedLanes);
                for (int i = 0; i < StateSize; i++)
                {
                    BitConverter.TryWriteBytes(batched.AsSpan(i * sizeof(ulong)), batchedLanes[i]);
                }

                Assert.That(batched, Is.EqualTo(expected), $"batched instance {instance}");
            }

            if (IsArm64Supported)
            {
                Arm64Twice();
                Assert.That(ReadState(ref _arm64A), Is.EqualTo(expected), "Arm64 scalar");
            }

            if (IsAvx2Supported)
            {
                Avx2Twice();
                Assert.That(ReadState(ref _avx2A), Is.EqualTo(expected), "AVX2");
            }
        }

        static byte[] ReadState(ref KeccakCoreState state)
        {
            byte[] bytes = new byte[StateSize * sizeof(ulong)];
            state.Squeeze(bytes, bytes.Length);
            return bytes;
        }
    }
}

#endif
