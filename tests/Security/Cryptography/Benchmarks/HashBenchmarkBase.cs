// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

/// <summary>
/// Base class for hash algorithm benchmarks with deterministic test data.
/// </summary>
public abstract class HashBenchmarkBase
{
    private const int RandomSeed = 0x43727970;

    private protected byte[] _inputData;
    private protected byte[] _outputData;
    private protected int _outputSize;

    protected int Bytes { get; set; } = DataSize.K8.Bytes;

    protected HashAlgorithm HashAlgorithm { get; set; }

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

