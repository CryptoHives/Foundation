// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Kem;

using BenchmarkDotNet.Attributes;
using Cryptography.Tests.Adapter.Kem;
using CryptoHives.Foundation.Security.Cryptography.Kem;
using NUnit.Framework;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmarks for ML-KEM (FIPS 203) key generation, encapsulation and decapsulation,
/// comparing the managed implementation against BouncyCastle and — on .NET 10 where the
/// platform supports it — the in-box <c>System.Security.Cryptography.MLKem</c>.
/// </summary>
/// <remarks>
/// <para>
/// Every implementation is measured against the <b>same key material</b>: the key pair is
/// expanded deterministically from a fixed seed in setup and imported into each runner, so
/// no implementation is handed an easier key, and reruns are comparable across machines
/// and across commits.
/// </para>
/// <para>
/// Key import and encapsulator construction happen in setup, so the measured methods
/// contain only the operation. The one exception is deliberate: the stateless
/// <see cref="IKem"/> path re-validates the decapsulation key on every call, and that cost
/// belongs inside its <c>Decapsulate</c> measurement because callers really do pay it.
/// </para>
/// <para>
/// <b>Reading KeyGen:</b> the managed <c>KeyGen</c> figure includes the pairwise
/// consistency test, which runs a full encapsulate and decapsulate of its own. Compare it
/// against <c>MLKemInternalsBenchmark.KPkeKeyGenCore</c> to separate the two.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(KemAlgorithmTypeArgs))]
[Config(typeof(KemConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Kem", "ML-KEM")]
[NonParallelizable]
public class MLKemBenchmark
{
    /// <summary>
    /// Fixed seed, so the benchmarked key material is identical on every run and machine.
    /// </summary>
    private static readonly byte[] KeySeed = BuildSeed();

    private IKemRunner _runner = null!;
    private byte[] _ciphertext = null!;
    private byte[] _rejectedCiphertext = null!;
    private byte[] _sharedSecret = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="MLKemBenchmark"/> class for BenchmarkDotNet.
    /// </summary>
    public MLKemBenchmark()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MLKemBenchmark"/> class for NUnit.
    /// </summary>
    /// <param name="algorithm">The implementation to exercise.</param>
    public MLKemBenchmark(KemAlgorithmType algorithm) => TestKemAlgorithm = algorithm;

    /// <summary>
    /// Gets or sets the ML-KEM implementation under measurement.
    /// </summary>
    [ParamsSource(nameof(Algorithms))]
    public KemAlgorithmType TestKemAlgorithm { get; set; } = null!;

    /// <summary>
    /// Gets every (parameter set, implementation) pair to benchmark.
    /// </summary>
    /// <remarks>
    /// Drawn from <c>KemAlgorithmRegistry</c>, which already filters out implementations
    /// that are unsupported here or excluded from benchmarking.
    /// </remarks>
    public static IEnumerable<KemAlgorithmType> Algorithms() => KemAlgorithmType.MLKem();

    /// <summary>
    /// Gets the NUnit fixture arguments.
    /// </summary>
    public static IEnumerable<object[]> KemAlgorithmTypeArgs()
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
        using IKem generator = CreateStatelessKem(TestKemAlgorithm.Category);
        byte[] encapsulationKey = new byte[generator.EncapsulationKeySizeBytes];
        byte[] decapsulationKey = new byte[generator.DecapsulationKeySizeBytes];
        generator.GenerateKeyPair(KeySeed, encapsulationKey, decapsulationKey);

        _runner = TestKemAlgorithm.Create();
        _runner.Prepare(encapsulationKey, decapsulationKey);

        _ciphertext = new byte[_runner.CiphertextSizeBytes];
        _sharedSecret = new byte[_runner.SharedSecretSizeBytes];

        // A valid ciphertext, so Decapsulate measures the success path.
        _runner.Encapsulate(_ciphertext, _sharedSecret);

        // The same ciphertext with one bit flipped, which drives decapsulation down the
        // implicit-rejection path instead. See DecapsulateRejected.
        _rejectedCiphertext = (byte[])_ciphertext.Clone();
        _rejectedCiphertext[0] ^= 0x01;
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

    [Test, Repeat(5)]
    [NonParallelizable]
    public void EncapsulateTest()
    {
        Encapsulate();
        Assert.That(_sharedSecret, Has.Length.EqualTo(_runner.SharedSecretSizeBytes));
        Assert.That(_sharedSecret, Is.Not.All.Zero, "Encapsulation must produce a shared secret.");
    }

    /// <summary>
    /// Benchmarks encapsulation against an already-imported public key.
    /// </summary>
    [Benchmark(Description = "Encapsulate")]
    public void Encapsulate() => _runner.Encapsulate(_ciphertext, _sharedSecret);

    [Test, Repeat(5)]
    [NonParallelizable]
    public void DecapsulateTest()
    {
        // Re-derive a known-good ciphertext/secret pair, then confirm decapsulation agrees.
        byte[] ciphertext = new byte[_runner.CiphertextSizeBytes];
        byte[] expected = new byte[_runner.SharedSecretSizeBytes];
        _runner.Encapsulate(ciphertext, expected);

        byte[] actual = new byte[_runner.SharedSecretSizeBytes];
        _runner.Decapsulate(ciphertext, actual);

        Assert.That(actual, Is.EqualTo(expected), "Decapsulation must recover the encapsulated secret.");
    }

    /// <summary>
    /// Benchmarks decapsulation of a valid ciphertext.
    /// </summary>
    [Benchmark(Description = "Decapsulate")]
    public void Decapsulate() => _runner.Decapsulate(_ciphertext, _sharedSecret);

    [Test, Repeat(5)]
    [NonParallelizable]
    public void DecapsulateRejectedTest()
    {
        byte[] rejected = new byte[_runner.SharedSecretSizeBytes];
        _runner.Decapsulate(_rejectedCiphertext, rejected);

        byte[] accepted = new byte[_runner.SharedSecretSizeBytes];
        _runner.Decapsulate(_ciphertext, accepted);

        Assert.That(rejected, Is.Not.EqualTo(accepted),
            "A tampered ciphertext must not yield the sender's secret.");
        Assert.That(rejected, Is.Not.All.Zero,
            "Implicit rejection must return a pseudorandom secret, not an error or zeros.");
    }

    /// <summary>
    /// Benchmarks decapsulation of a tampered ciphertext, which takes the FIPS 203 implicit
    /// rejection path.
    /// </summary>
    /// <remarks>
    /// This exists to be compared against <see cref="Decapsulate"/>, not read on its own.
    /// ML-KEM rejects implicitly: rather than reporting an error it re-encrypts and returns
    /// a pseudorandom secret, and the accept/reject choice is a constant-time select. The
    /// two measurements should therefore be indistinguishable. A reliable gap between them
    /// is a timing oracle that tells an attacker whether their ciphertext was well-formed —
    /// so a divergence here is a security finding, not a performance one.
    /// </remarks>
    [Benchmark(Description = "Decapsulate (rejected)")]
    public void DecapsulateRejected() => _runner.Decapsulate(_rejectedCiphertext, _sharedSecret);

    private static IKem CreateStatelessKem(string category) => category switch {
        "ML-KEM-512" => MLKem512.Create(),
        "ML-KEM-768" => MLKem768.Create(),
        "ML-KEM-1024" => MLKem1024.Create(),
        _ => throw new ArgumentException($"Unknown parameter set: {category}", nameof(category)),
    };

    private static byte[] BuildSeed()
    {
        byte[] seed = new byte[64];
        for (int i = 0; i < seed.Length; i++)
        {
            seed[i] = (byte)((i * 17 + 3) & 0xFF);
        }

        return seed;
    }
}
