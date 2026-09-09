// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Dsa;

using BenchmarkDotNet.Attributes;
using Cryptography.Tests.Adapter.Dsa;
using CryptoHives.Foundation.Security.Cryptography.Dsa;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for ML-DSA (FIPS 204) signing and verification, comparing the managed
/// implementation against BouncyCastle and — on .NET 10 where the platform supports it — the
/// in-box <c>System.Security.Cryptography.MLDsa</c>.
/// </summary>
/// <remarks>
/// <para>
/// Every implementation is measured against the <b>same key material and the same message</b>:
/// the key pair is expanded deterministically from a fixed seed in setup and imported into
/// each runner, so no implementation is handed an easier key, and reruns are comparable across
/// machines and across commits.
/// </para>
/// <para>
/// Key import and signer construction happen in setup, so the measured methods contain only
/// the operation. The one exception is deliberate: the stateless <see cref="IDsa"/> path
/// decodes the private key on every call, and that cost belongs inside its <c>Sign</c>
/// measurement because callers really do pay it.
/// </para>
/// <para>
/// <b>Signing is variable-cost by construction.</b> FIPS 204 signing is a rejection loop that
/// restarts whenever a candidate signature falls outside the norm bounds, so the iteration
/// count depends on the key, the message and — for the hedged variant every implementation
/// here uses — the randomness drawn per attempt. Expect visibly wider distributions than the
/// ML-KEM tables show; the mean is the number to read, not the min. The hedged path also draws
/// 32 bytes from the OS RNG per signature, which is part of what is being measured.
/// </para>
/// <para>
/// Key generation lives in <see cref="MLDsaKeyGenBenchmark"/> rather than here, because it
/// carries a variant the other operations do not: the same implementation with the pairwise
/// consistency test disabled. Splitting the two keeps that variant out of the signing and
/// verification tables, where it would run byte-identical code under a second name.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(DsaAlgorithmTypeArgs))]
[Config(typeof(DsaConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Dsa", "ML-DSA")]
[NonParallelizable]
public class MLDsaBenchmark
{
    /// <summary>
    /// Fixed seed, so the benchmarked key material is identical on every run and machine.
    /// </summary>
    private static readonly byte[] KeySeed = BuildSeed();

    /// <summary>
    /// Fixed message, so every implementation signs and verifies the same input.
    /// </summary>
    private static readonly byte[] Message = BuildMessage();

    private IDsaRunner _runner = null!;
    private byte[] _signature = null!;
    private byte[] _invalidSignature = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="MLDsaBenchmark"/> class for BenchmarkDotNet.
    /// </summary>
    public MLDsaBenchmark()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MLDsaBenchmark"/> class for NUnit.
    /// </summary>
    /// <param name="algorithm">The implementation to exercise.</param>
    public MLDsaBenchmark(DsaAlgorithmType algorithm) => TestDsaAlgorithm = algorithm;

    /// <summary>
    /// Gets or sets the ML-DSA implementation under measurement.
    /// </summary>
    [ParamsSource(nameof(Algorithms))]
    public DsaAlgorithmType TestDsaAlgorithm { get; set; } = null!;

    /// <summary>
    /// Gets every (parameter set, implementation) pair to benchmark.
    /// </summary>
    /// <remarks>
    /// Drawn from <c>DsaAlgorithmRegistry</c>, which already filters out implementations that
    /// are unsupported here or excluded from benchmarking.
    /// </remarks>
    public static IEnumerable<DsaAlgorithmType> Algorithms() => DsaAlgorithmType.MLDsa();

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
        // Expand the shared key pair deterministically with the stateless managed API, so
        // every implementation benchmarks against byte-identical key material.
        using IDsa generator = CreateStatelessDsa(TestDsaAlgorithm.Category);
        byte[] publicKey = new byte[generator.PublicKeySizeBytes];
        byte[] privateKey = new byte[generator.SecretKeySizeBytes];
        generator.GenerateKeyPair(KeySeed, publicKey, privateKey, pairwiseConsistencyTest: false);

        _runner = TestDsaAlgorithm.Create();
        _runner.Prepare(publicKey, privateKey);

        // A valid signature, so Verify measures the success path.
        _signature = new byte[_runner.SignatureSizeBytes];
        _runner.Sign(Message, _signature);

        // The same signature with one bit flipped in the commitment, which drives verification
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
    /// This exists to be compared against <see cref="Verify"/>, not read on its own. Unlike
    /// ML-KEM's implicit rejection, ML-DSA verification is allowed to fail early — a signature
    /// whose encoding is malformed is rejected before any arithmetic — so a gap here is
    /// expected and is not a finding. Verification operates only on public data, so the timing
    /// leaks nothing secret. The measurement is here to show how cheap rejecting a bad
    /// signature is relative to accepting a good one, which is what a server under load cares
    /// about.
    /// </remarks>
    [Benchmark(Description = "Verify (invalid)")]
    public bool VerifyInvalid() => _runner.Verify(Message, _invalidSignature);

    private static IDsa CreateStatelessDsa(string category) => category switch {
        "ML-DSA-44" => MLDsa44.Create(),
        "ML-DSA-65" => MLDsa65.Create(),
        "ML-DSA-87" => MLDsa87.Create(),
        _ => throw new ArgumentException($"Unknown parameter set: {category}", nameof(category)),
    };

    private static byte[] BuildSeed()
    {
        byte[] seed = new byte[32];
        for (int i = 0; i < seed.Length; i++)
        {
            seed[i] = (byte)((i * 17 + 3) & 0xFF);
        }

        return seed;
    }

    private static byte[] BuildMessage()
    {
        // 1 KiB: large enough that the message hash is not free, small enough that the
        // rejection loop still dominates, which is what the comparison is about.
        byte[] message = new byte[1024];
        for (int i = 0; i < message.Length; i++)
        {
            message[i] = (byte)((i * 31 + 7) & 0xFF);
        }

        return message;
    }
}

/// <summary>
/// Benchmarks for ML-DSA (FIPS 204) key generation across every implementation.
/// </summary>
/// <remarks>
/// <para>
/// Separate from <see cref="MLDsaBenchmark"/> because key generation has a variant the other
/// operations do not: the managed implementation with the FIPS 140-3 pairwise consistency test
/// disabled. For ML-DSA that check is not a minor addition — it performs a full signature,
/// itself a rejection loop, so it dominates key generation. Keeping the variant here puts it
/// beside BouncyCastle, which runs no such check, which is the comparison worth making,
/// without adding duplicate rows to the signing and verification tables.
/// </para>
/// <para>
/// Each implementation generates keys with its own RNG rather than from the shared seed the
/// other suite uses: key generation is the one operation where drawing randomness is part of
/// the work being measured.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(DsaAlgorithmTypeArgs))]
[Config(typeof(DsaConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Dsa", "ML-DSA")]
[NonParallelizable]
public class MLDsaKeyGenBenchmark
{
    private IDsaRunner _runner = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="MLDsaKeyGenBenchmark"/> class for BenchmarkDotNet.
    /// </summary>
    public MLDsaKeyGenBenchmark()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MLDsaKeyGenBenchmark"/> class for NUnit.
    /// </summary>
    /// <param name="algorithm">The implementation to exercise.</param>
    public MLDsaKeyGenBenchmark(DsaAlgorithmType algorithm) => TestDsaAlgorithm = algorithm;

    /// <summary>
    /// Gets or sets the ML-DSA implementation under measurement.
    /// </summary>
    [ParamsSource(nameof(Algorithms))]
    public DsaAlgorithmType TestDsaAlgorithm { get; set; } = null!;

    /// <summary>
    /// Gets every implementation to benchmark, including key-generation-only variants.
    /// </summary>
    public static IEnumerable<DsaAlgorithmType> Algorithms() => DsaAlgorithmType.MLDsaKeyGen();

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
