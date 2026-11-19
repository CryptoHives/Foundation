// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT OR Apache-2.0

namespace Cryptography.Tests.Benchmarks.Cipher;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Bcl = System.Security.Cryptography;

/// <summary>
/// Benchmarks for AES Key Wrap (RFC 3394) and AES Key Wrap with Padding (RFC 5649).
/// </summary>
/// <remarks>
/// <para>
/// The wrapping mode is a <c>TestCipherAlgorithm</c> parameter rather than a separate
/// benchmark method per mode, so <see cref="CipherConfig"/>'s <c>DescriptionColumn</c>
/// renders the rows as <c>Wrap · AES-KW (CryptoHives)</c> — the same
/// <c>Method · Family (Variant)</c> shape every other cipher benchmark produces, and the
/// shape the trends importer parses. Four separately named methods produced a bare
/// <c>WrapNoPad</c>, which the importer read as the family with a synthesised variant.
/// </para>
/// <para>
/// Unlike the other cipher suites there is no data-size axis: RFC 3394 fixes the key
/// material at a multiple of eight bytes and the interesting comparison is padded versus
/// unpadded, not throughput against length. Rows therefore carry an empty size label, the
/// same way the ML-KEM suites do.
/// </para>
/// </remarks>
[TestFixture]
[TestFixtureSource(nameof(CipherAlgorithmTypeArgs))]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "KeyWrap", "AES-KW-KWP")]
[NonParallelizable]
public class AesKeyWrapBenchmark
{
    /// <summary>
    /// Random seed for deterministic test data generation ("Cryp" as ASCII bytes).
    /// </summary>
    private const int RandomSeed = 0x43727970;

    /// <summary>
    /// Family name for RFC 3394 key wrapping without padding.
    /// </summary>
    private const string NoPadFamily = "AES-KW";

    /// <summary>
    /// Family name for RFC 5649 key wrapping with padding.
    /// </summary>
    private const string PadFamily = "AES-KWP";

    private IDisposable _owner = null!;
    private KeyWrapOperation _wrap = null!;
    private KeyWrapOperation _unwrap = null!;
    private byte[] _keyMaterial = null!;
    private byte[] _wrapped = null!;

    private delegate byte[] KeyWrapOperation(ReadOnlySpan<byte> input);

    /// <summary>
    /// Initializes a new instance of the <see cref="AesKeyWrapBenchmark"/> class.
    /// </summary>
    public AesKeyWrapBenchmark()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AesKeyWrapBenchmark"/> class.
    /// </summary>
    /// <param name="algorithm">The key wrapping mode to benchmark.</param>
    public AesKeyWrapBenchmark(CipherAlgorithmType algorithm)
    {
        TestCipherAlgorithm = algorithm;
    }

    /// <summary>
    /// Gets or sets the key wrapping mode under test.
    /// </summary>
    [ParamsSource(nameof(Algorithms))]
    public CipherAlgorithmType TestCipherAlgorithm { get; set; } = null!;

    /// <summary>
    /// Gets the key wrapping modes for benchmarking.
    /// </summary>
    /// <remarks>
    /// Built here rather than in <c>CipherAlgorithmRegistry</c> because key wrapping is not a
    /// <c>SymmetricCipher</c> mode and has no registry entry. <see cref="Bcl.Aes"/> gained KWP in
    /// .NET 10 and KW in .NET 11, so each OS row appears from that release on.
    /// </remarks>
    public static IEnumerable<CipherAlgorithmType> Algorithms()
    {
        yield return new CipherAlgorithmType(
            NoPadFamily, $"{NoPadFamily} (CryptoHives)", CreateKeyWrap, isAead: false);
        yield return new CipherAlgorithmType(
            PadFamily, $"{PadFamily} (CryptoHives)", CreateKeyWrap, isAead: false);
#if NET11_0_OR_GREATER
        yield return new CipherAlgorithmType(
            NoPadFamily, $"{NoPadFamily} (OS)", CreateOSAes, isAead: false);
#endif
#if NET10_0_OR_GREATER
        yield return new CipherAlgorithmType(
            PadFamily, $"{PadFamily} (OS)", CreateOSAes, isAead: false);
#endif
    }

    /// <summary>
    /// NUnit test fixture argument source.
    /// </summary>
    public static IEnumerable<object[]> CipherAlgorithmTypeArgs()
    {
        foreach (var algorithm in Algorithms())
        {
            yield return new object[] { algorithm };
        }
    }

    /// <summary>
    /// Performs benchmark setup.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        bool padded = TestCipherAlgorithm.Category == PadFamily;

        var random = new Random(RandomSeed);

        // RFC 3394 requires key material that is a whole number of 64-bit blocks; RFC 5649
        // exists precisely to lift that, so the padded case uses a length that is not.
        _keyMaterial = new byte[padded ? 37 : 32];
        random.NextBytes(_keyMaterial);

        object implementation = TestCipherAlgorithm.Create();
        _owner = (IDisposable)implementation;
        switch (implementation)
        {
            case AesKeyWrapPad kwp:
                _wrap = padded ? kwp.EncryptKeyWrapPadded : kwp.EncryptKeyWrap;
                _unwrap = padded ? kwp.DecryptKeyWrapPadded : kwp.DecryptKeyWrap;
                break;
#if NET11_0_OR_GREATER
            case Bcl.Aes aes when !padded:
                _wrap = aes.EncryptKeyWrap;
                _unwrap = aes.DecryptKeyWrap;
                break;
#endif
#if NET10_0_OR_GREATER
            case Bcl.Aes aes when padded:
                _wrap = aes.EncryptKeyWrapPadded;
                _unwrap = aes.DecryptKeyWrapPadded;
                break;
#endif
            default:
                throw new NotSupportedException(implementation.GetType().FullName);
        }

        _wrapped = _wrap(_keyMaterial);
    }

    /// <summary>
    /// Performs benchmark cleanup.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _owner.Dispose();
    }

    /// <summary>
    /// Verifies that wrapping round-trips to the expected length.
    /// </summary>
    [Test, Repeat(5)]
    [NonParallelizable]
    public void WrapTest()
    {
        byte[] wrapped = Wrap();
        Assert.That(wrapped.Length, Is.EqualTo(_wrapped.Length));
    }

    /// <summary>
    /// Benchmarks key wrapping.
    /// </summary>
    [Benchmark(Description = "Wrap")]
    public byte[] Wrap() => _wrap(_keyMaterial);

    /// <summary>
    /// Verifies that unwrapping recovers the original key material.
    /// </summary>
    [Test, Repeat(5)]
    [NonParallelizable]
    public void UnwrapTest()
    {
        byte[] unwrapped = Unwrap();
        Assert.That(unwrapped.AsSpan().SequenceEqual(_keyMaterial), Is.True);
    }

    /// <summary>
    /// Benchmarks key unwrapping.
    /// </summary>
    [Benchmark(Description = "Unwrap")]
    public byte[] Unwrap() => _unwrap(_wrapped);

    /// <summary>
    /// Creates a key wrapper under the deterministic key encryption key.
    /// </summary>
    private static AesKeyWrapPad CreateKeyWrap() => new AesKeyWrapPad(CreateKek());

#if NET10_0_OR_GREATER
    /// <summary>
    /// Creates the in-box AES under the same key encryption key as <see cref="CreateKeyWrap"/>.
    /// </summary>
    private static Bcl.Aes CreateOSAes()
    {
        var aes = Bcl.Aes.Create();
        aes.Key = CreateKek();
        return aes;
    }
#endif

    /// <summary>
    /// Creates a deterministic 256-bit key encryption key.
    /// </summary>
    private static byte[] CreateKek()
    {
        var random = new Random(RandomSeed);
        byte[] kek = new byte[32];
        random.NextBytes(kek);
        return kek;
    }
}
