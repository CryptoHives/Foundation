// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

#pragma warning disable NUnit1032 // Both fields ARE disposed, in [OneTimeTearDown]/[GlobalCleanup] — matches AeadBenchmarkBase/AesKeyWrapBenchmark precedent; the analyzer doesn't recognize the dual-attribute BenchmarkDotNet+NUnit teardown shape here.

namespace Cryptography.Tests.Benchmarks.Mac;

using BenchmarkDotNet.Attributes;
using Cryptography.Tests.Adapter.Cipher;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using System;
using System.Collections.Generic;

/// <summary>
/// Benchmark for AES-GMAC (NIST SP 800-38D).
/// </summary>
/// <remarks>
/// AES-GMAC has a fundamentally different shape from HMAC/CMAC/Poly1305: it's a one-shot,
/// nonce-per-call API (<c>ComputeTag(nonce, associatedData)</c>), not an incremental
/// Update/Finalize <see cref="IMac"/> — GMAC is literally AES-GCM with an empty plaintext,
/// so it doesn't fit <see cref="ParameterizedMacBenchmark"/>. The BouncyCastle comparison
/// reuses <see cref="BouncyCastleAeadAdapter"/> (already used by the Cipher AEAD benchmarks)
/// against an empty plaintext span, which is exactly what GMAC is.
/// </remarks>
[TestFixture]
[Config(typeof(MacConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Mac", "GMAC", "AES-GMAC")]
[NonParallelizable]
public class AesGmacBenchmark
{
    private const int RandomSeed = 0x43727970;

    private byte[] _key = null!;
    private byte[] _nonce = null!;
    private byte[] _aad = null!;
    private byte[] _tag = null!;
    private AesGmac _gmac = null!;
    private BouncyCastleAeadAdapter _bcGmac = null!;

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(RandomSeed);

        _key = new byte[32];
        random.NextBytes(_key);

        _nonce = new byte[AesGmac.NonceSizeBytes];
        random.NextBytes(_nonce);

        _aad = new byte[TestDataSize.Bytes];
        random.NextBytes(_aad);

        _tag = new byte[AesGmac.TagSizeBytes];

        _gmac = AesGmac.Create(_key);
        _bcGmac = new BouncyCastleAeadAdapter(new GcmBlockCipher(new AesEngine()), _key);

        // BenchmarkDotNet runs each [Benchmark] method in its own isolated process, so a process
        // that only exercises CryptoHivesComputeTag never calls _bcGmac.Encrypt — leaving its
        // underlying GcmBlockCipher un-Init()'d. GcmBlockCipher.Reset() (called from Dispose via
        // BouncyCastleAeadAdapter.Dispose) then throws on uninitialized state, crashing
        // GlobalCleanup and losing that process's results. One throwaway call here guarantees the
        // cipher is always in a valid, disposable state regardless of which benchmark method runs.
        IncrementNonce();
        _bcGmac.Encrypt(_nonce, [], [], _tag, _aad);
    }

    [OneTimeTearDown]
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _gmac?.Dispose();
        _bcGmac?.Dispose();
    }

    /// <summary>
    /// Increments the nonce before each call — GMAC/GCM implementations (including BouncyCastle)
    /// require a unique nonce per invocation with the same key.
    /// </summary>
    private void IncrementNonce()
    {
        unchecked
        {
            for (int i = _nonce.Length - 1; i >= 0; i--)
            {
                if (++_nonce[i] != 0) break;
            }
        }
    }

    [Test, Repeat(5)]
    [TestCaseSource(typeof(DataSize), nameof(DataSize.AllSizes))]
    public void TestComputeTag(DataSize dataSize)
    {
        TestDataSize = dataSize;
        GlobalSetup();
        IncrementNonce();
        _gmac.ComputeTag(_nonce, _aad, _tag);
        Assert.That(_tag, Has.Length.EqualTo(AesGmac.TagSizeBytes));

        bool allZeros = true;
        foreach (byte b in _tag)
        {
            if (b != 0) { allZeros = false; break; }
        }
        Assert.That(allZeros, Is.False, "GMAC tag should not be all zeros.");

        // Cross-validate against BouncyCastle (GMAC = AES-GCM with empty plaintext) using the
        // same nonce, and also exercises _bcGmac so Dispose()'s Reset() doesn't hit uninitialized state.
        byte[] bcTag = new byte[AesGmac.TagSizeBytes];
        _bcGmac.Encrypt(_nonce, [], [], bcTag, _aad);
        Assert.That(bcTag, Is.EqualTo(_tag), "CryptoHives and BouncyCastle GMAC tags must match.");
    }

    [Benchmark(Description = "ComputeTag · AES-GMAC · CryptoHives-Scalar")]
    public void CryptoHivesComputeTag()
    {
        IncrementNonce();
        _gmac.ComputeTag(_nonce, _aad, _tag);
    }

    [Benchmark(Description = "ComputeTag · AES-GMAC · BouncyCastle")]
    public void BouncyCastleComputeTag()
    {
        IncrementNonce();
        _bcGmac.Encrypt(_nonce, [], [], _tag, _aad);
    }
}
