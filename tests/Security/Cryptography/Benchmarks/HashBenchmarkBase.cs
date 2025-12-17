// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Security.Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Security.Cryptography;

/// <summary>
/// Base class for hash algorithm benchmarks with deterministic test data.
/// </summary>
public abstract class HashBenchmarkBase
{
    private const int RandomSeed = 0x43727970;

    private byte[] _inputData;

    private byte[] _outputData;

    protected int Bytes { get; set; } = DataSize.K8.Bytes;
    protected HashAlgorithm HashAlgorithm { get; set; }

    protected byte[] InputData => _inputData!;
    protected byte[] OutputData => _outputData!;

    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        var random = new Random(RandomSeed);
        HashAlgorithm ??= SHA256.Create();
        _inputData = new byte[Bytes];
        _outputData = new byte[HashAlgorithm.HashSize / 8];
        random.NextBytes(_inputData);
    }

    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        HashAlgorithm?.Dispose();
    }
}


