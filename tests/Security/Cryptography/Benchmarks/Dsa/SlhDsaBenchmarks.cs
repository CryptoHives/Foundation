// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Dsa;

using BenchmarkDotNet.Attributes;
using Cryptography.Tests.Adapter.Dsa;
using Cryptography.Tests.Dsa.SlhDsa;
using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for SLH-DSA (FIPS 205) signing and verification, comparing the managed
/// implementation against BouncyCastle and — on .NET 10 where the platform supports it — the
/// in-box <c>System.Security.Cryptography.SlhDsa</c>.
/// </summary>
/// <remarks>
/// <para>
/// Every implementation is measured against the <b>same key material and the same message</b>:
/// the key pair is expanded deterministically from fixed seeds in setup and imported into each
/// runner, so no implementation is handed an easier key, and reruns are comparable across
/// machines and across commits.
/// </para>
/// <para>
/// <b>Only the six <c>f</c> parameter sets appear here.</b> The <c>s</c> sets are registered and
/// correctness-tested but marked <c>ExcludeFromBenchmark</c>: signing with one costs on the order
/// of 10⁶ hash invocations, seconds per operation, which would turn a run into an overnight job
/// to confirm a ranking nobody disputes. FIPS 205 states the trade explicitly, and
/// <c>SlhDsaTests.FullMatrix_SignVerify_RoundTrips</c> keeps the <c>s</c> sets exercised.
/// </para>
/// <para>
/// Unlike ML-DSA, signing here is <b>not</b> a rejection loop — the cost is a fixed walk of the
/// hypertree — so the distributions are tight and the numbers are dominated by the underlying
/// hash. That makes this suite an unusually direct measurement of the SHA-2 and SHAKE cores: the
/// SHA2 and SHAKE rows of the same parameter set differ only in which hash they call.
/// </para>
/// <para>
/// Key generation lives in <see cref="SlhDsaKeyGenBenchmark"/> rather than here, for the reason
/// given there.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(DsaAlgorithmTypeArgs))]
[Config(typeof(DsaConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Dsa", "SLH-DSA")]
[NonParallelizable]
public class SlhDsaBenchmark
{
    /// <summary>
    /// Fixed message, so every implementation signs and verifies the same input.
    /// </summary>
    private static readonly byte[] Message = BuildMessage();

    private IDsaRunner _runner = null!;
    private byte[] _signature = null!;
    private byte[] _invalidSignature = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="SlhDsaBenchmark"/> class for BenchmarkDotNet.
    /// </summary>
    public SlhDsaBenchmark()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SlhDsaBenchmark"/> class for NUnit.
    /// </summary>
    /// <param name="algorithm">The implementation to exercise.</param>
    public SlhDsaBenchmark(DsaAlgorithmType algorithm) => TestDsaAlgorithm = algorithm;

    /// <summary>
    /// Gets or sets the SLH-DSA implementation under measurement.
    /// </summary>
    [ParamsSource(nameof(Algorithms))]
    public DsaAlgorithmType TestDsaAlgorithm { get; set; } = null!;

    /// <summary>
    /// Gets every (parameter set, implementation) pair to benchmark.
    /// </summary>
    public static IEnumerable<DsaAlgorithmType> Algorithms() => DsaAlgorithmType.SlhDsa();

    /// <summary>
    /// Gets the NUnit fixture arguments.
    /// </summary>
    public static IEnumerable<object[]> DsaAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
        {
            yield return new object[] { alg };
        }
    }

    /// <summary>
    /// Expands the shared key pair and hands it to the runner under test.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        ExpandSharedKey(TestDsaAlgorithm.Category, out byte[] publicKey, out byte[] privateKey);

        _runner = TestDsaAlgorithm.Create();
        _runner.Prepare(publicKey, privateKey);

        // A valid signature, so Verify measures the success path.
        _signature = new byte[_runner.SignatureSizeBytes];
        _runner.Sign(Message, _signature);

        // The same signature with one bit flipped in the randomizer R, which drives verification
        // down the rejection path instead. See VerifyInvalid.
        _invalidSignature = (byte[])_signature.Clone();
        _invalidSignature[0] ^= 0x01;
    }

    /// <summary>
    /// Releases the runner.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        _runner?.Dispose();
    }

    [Test, Repeat(5)]
    [NonParallelizable]
    public void SignTest()
    {
        byte[] signature = new byte[_runner.SignatureSizeBytes];
        _runner.Sign(Message, signature);

        Assert.That(signature, Is.Not.All.Zero, "Signing must produce a signature.");
        Assert.That(_runner.Verify(Message, signature), Is.True,
            "A freshly produced signature must verify.");
    }

    /// <summary>
    /// Benchmarks hedged signing against an already-imported private key.
    /// </summary>
    [Benchmark(Description = "Sign")]
    public void Sign() => _runner.Sign(Message, _signature);

    [Test, Repeat(5)]
    [NonParallelizable]
    public void VerifyTest()
    {
        byte[] signature = new byte[_runner.SignatureSizeBytes];
        _runner.Sign(Message, signature);

        Assert.That(_runner.Verify(Message, signature), Is.True,
            "Verification must accept a signature this key produced.");
    }

    /// <summary>
    /// Benchmarks verification of a valid signature.
    /// </summary>
    [Benchmark(Description = "Verify")]
    public bool Verify() => _runner.Verify(Message, _signature);

    [Test, Repeat(5)]
    [NonParallelizable]
    public void VerifyInvalidTest()
    {
        Assert.That(_runner.Verify(Message, _invalidSignature), Is.False,
            "A tampered signature must not verify.");
    }

    /// <summary>
    /// Benchmarks verification of a tampered signature, which is rejected.
    /// </summary>
    /// <remarks>
    /// This exists to be compared against <see cref="Verify"/>, not read on its own. SLH-DSA
    /// verification recomputes the candidate public key and compares it at the end, so a
    /// tampered signature costs very nearly what a valid one does — a near-zero gap here is the
    /// expected result, and a large one would be the surprise. Verification operates only on
    /// public data, so the timing leaks nothing secret either way.
    /// </remarks>
    [Benchmark(Description = "Verify (invalid)")]
    public bool VerifyInvalid() => _runner.Verify(Message, _invalidSignature);

    /// <summary>
    /// Expands a key pair deterministically from fixed seeds, so every runner in a family is
    /// prepared with byte-identical key material.
    /// </summary>
    /// <remarks>
    /// The ML-DSA suite does this through the stateless <c>IDsa</c> interface. SLH-DSA has no
    /// such wrappers — and could not have them unchanged, since <c>IDsa</c> takes a single
    /// 32-byte seed ξ while FIPS 205 key generation consumes SK.seed, SK.prf and PK.seed — so
    /// this goes to <see cref="SlhDsaCore.KeyGenFromSeeds"/> directly.
    /// </remarks>
    /// <param name="category">The parameter set name.</param>
    /// <param name="publicKey">Receives the 2n-byte public key.</param>
    /// <param name="privateKey">Receives the 4n-byte private key.</param>
    internal static void ExpandSharedKey(string category, out byte[] publicKey, out byte[] privateKey)
    {
        SlhDsaParams p = SlhDsaAcvpVectors.AlgorithmFor(category).Parameters;

        // Three n-byte seeds from one fixed pattern, so the material is stable across runs and
        // machines but the three seeds are not equal to each other.
        byte[] seeds = new byte[3 * p.N];
        for (int i = 0; i < seeds.Length; i++)
        {
            seeds[i] = (byte)((i * 17 + 3) & 0xFF);
        }

        publicKey = new byte[p.PublicKeyBytes];
        privateKey = new byte[p.SecretKeyBytes];
        SlhDsaCore.KeyGenFromSeeds(p, seeds.AsSpan(0, p.N), seeds.AsSpan(p.N, p.N),
            seeds.AsSpan(2 * p.N, p.N), publicKey, privateKey);
    }

    private static byte[] BuildMessage()
    {
        // 1 KiB, matching the ML-DSA suite so the two signature tables are read on the same
        // input. Message length barely matters for SLH-DSA — the hypertree walk dwarfs the
        // message hash — but keeping it identical removes one reason for the numbers to differ.
        byte[] message = new byte[1024];
        for (int i = 0; i < message.Length; i++)
        {
            message[i] = (byte)((i * 31 + 7) & 0xFF);
        }

        return message;
    }
}

/// <summary>
/// Benchmarks for SLH-DSA (FIPS 205) key generation across every implementation.
/// </summary>
/// <remarks>
/// <para>
/// Separate from <see cref="SlhDsaBenchmark"/> because key generation has a variant the other
/// operations do not: the managed implementation with the FIPS 140-3 pairwise consistency test
/// disabled. For SLH-DSA the two are barely the same operation — generating a key builds the
/// single top-layer XMSS tree, while the consistency check signs, which walks the entire
/// hypertree. Expect the two rows to differ by orders of magnitude, and read the NoPct row as
/// the one comparable to BouncyCastle, which runs no such check.
/// </para>
/// <para>
/// Each implementation generates keys with its own RNG rather than from fixed seeds: key
/// generation is the one operation where drawing randomness is part of the work being measured.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(DsaAlgorithmTypeArgs))]
[Config(typeof(DsaConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Dsa", "SLH-DSA")]
[NonParallelizable]
public class SlhDsaKeyGenBenchmark
{
    private IDsaRunner _runner = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="SlhDsaKeyGenBenchmark"/> class for BenchmarkDotNet.
    /// </summary>
    public SlhDsaKeyGenBenchmark()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SlhDsaKeyGenBenchmark"/> class for NUnit.
    /// </summary>
    /// <param name="algorithm">The implementation to exercise.</param>
    public SlhDsaKeyGenBenchmark(DsaAlgorithmType algorithm) => TestDsaAlgorithm = algorithm;

    /// <summary>
    /// Gets or sets the SLH-DSA implementation under measurement.
    /// </summary>
    [ParamsSource(nameof(Algorithms))]
    public DsaAlgorithmType TestDsaAlgorithm { get; set; } = null!;

    /// <summary>
    /// Gets every implementation to benchmark, including key-generation-only variants.
    /// </summary>
    public static IEnumerable<DsaAlgorithmType> Algorithms() => DsaAlgorithmType.SlhDsaKeyGen();

    /// <summary>
    /// Gets the NUnit fixture arguments.
    /// </summary>
    public static IEnumerable<object[]> DsaAlgorithmTypeArgs()
    {
        foreach (var alg in Algorithms())
        {
            yield return new object[] { alg };
        }
    }

    /// <summary>
    /// Creates the runner under test.
    /// </summary>
    /// <remarks>
    /// No key material is imported: key generation must not depend on <c>Prepare</c> having
    /// run, and the test below would fail if an adapter ever made it so.
    /// </remarks>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup() => _runner = TestDsaAlgorithm.Create();

    /// <summary>
    /// Releases the runner.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup() => _runner?.Dispose();

    [Test]
    [NonParallelizable]
    public void GenerateKeyPairTest()
    {
        object keyPair = GenerateKeyPair();
        Assert.That(keyPair, Is.Not.Null);
        (keyPair as IDisposable)?.Dispose();
    }

    /// <summary>
    /// Benchmarks key pair generation.
    /// </summary>
    /// <returns>The generated key pair, returned so the work is not elided.</returns>
    [Benchmark(Description = "KeyGen")]
    public object GenerateKeyPair() => _runner.GenerateKeyPair();
}
