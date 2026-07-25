// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Hash;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

/// <summary>
/// Base class for parameterized hash algorithm benchmarks.
/// </summary>
/// <remarks>
/// Eliminates code duplication across benchmark classes by providing common setup and benchmark methods.
/// Derived classes only need to provide:
/// <list type="bullet">
/// <item><c>Algorithms()</c> static method returning algorithm variants</item>
/// <item><c>HashAlgorithmTypeArgs</c> for NUnit test fixture sources</item>
/// <item>BenchmarkCategory attributes for categorization</item>
/// </list>
/// </remarks>
public abstract class ParameterizedHashBenchmark : HashBenchmarkBase
{
    // Set when the adapter exposes a faster library-specific one-shot API; the
    // TryComputeHash benchmark prefers it so third-party libraries compete with
    // their best single-call path (see IOneShotHash).
    private Cryptography.Tests.Adapter.Hash.IOneShotHash? _oneShotHash;

    // CH.Blake3's own one-shot fast path (see Blake3.TryHashOneShot) is a public
    // instance method on the concrete production type, not an interface — the
    // registry must keep returning genuine CH.Blake3 instances (not a wrapper)
    // so correctness tests can verify the "CryptoHives-*" rows really exercise
    // the production type (see HashAlgorithmFactoryTests.FactoryMethodWorks).
    // A direct type check here is the equivalent of IOneShotHash for this one
    // production type without needing a wrapper.
    private CryptoHives.Foundation.Security.Cryptography.Hash.Blake3? _blake3OneShot;

    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource("Algorithms")]
    public HashAlgorithmType TestHashAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    protected ParameterizedHashBenchmark() => TestDataSize = DataSize.K8;

    protected ParameterizedHashBenchmark(HashAlgorithmType hashAlgorithm)
    {
        TestDataSize = DataSize.K8;
        TestHashAlgorithm = hashAlgorithm;
    }

    public override void GlobalSetup()
    {
        Bytes = TestDataSize.Bytes;
        HashAlgorithm = TestHashAlgorithm.Create();
        _oneShotHash = HashAlgorithm as Cryptography.Tests.Adapter.Hash.IOneShotHash;
        _blake3OneShot = HashAlgorithm as CryptoHives.Foundation.Security.Cryptography.Hash.Blake3;
        base.GlobalSetup();
    }

    [Test, Repeat(5)]
    [TestCaseSource(typeof(DataSize), nameof(DataSize.AllSizes))]
    public void TestComputeHash(DataSize dataSize)
    {
        TestDataSize = dataSize;
        GlobalSetup();
#if NET5_0_OR_GREATER
        _outputSize = -1;
        TryComputeHash();
        Assert.That(_outputSize, Is.GreaterThan(0), "Hash output should not be empty.");
        var result = _outputData.AsSpan().Slice(0, _outputSize).ToArray();
        Assert.That(_outputSize, Is.EqualTo(HashAlgorithm.HashSize / 8));
#else
        var result = ComputeHash();
        Assert.That(result, Is.Not.Null, "Hash output should not be null.");
        Assert.That(result.Length, Is.GreaterThan(0), "Hash output should not be empty.");
        Assert.That(result, Has.Length.EqualTo(HashAlgorithm.HashSize / 8));
#endif
        bool allZeros = result.All(b => b == 0);
        Assert.That(allZeros, Is.False, "Hash output should not be all zeros.");
    }

    [Benchmark]
#if NET5_0_OR_GREATER
    public void TryComputeHash()
    {
        if (_blake3OneShot is not null)
        {
            if (_blake3OneShot.TryHashOneShot(_inputData, _outputData, out int blake3BytesWritten))
            {
                _outputSize = blake3BytesWritten;
            }

            return;
        }

        if (_oneShotHash is not null)
        {
            if (_oneShotHash.TryComputeHash(_inputData, _outputData, out int oneShotBytesWritten))
            {
                _outputSize = oneShotBytesWritten;
            }

            return;
        }

        if (HashAlgorithm.TryComputeHash(_inputData, _outputData, out int bytesWritten))
        {
            _outputSize = bytesWritten;
        }
    }
#else
    public byte[] ComputeHash() => HashAlgorithm.ComputeHash(_inputData);
#endif
}


