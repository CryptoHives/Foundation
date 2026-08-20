// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Mac;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;

/// <summary>
/// Base class for MAC algorithm benchmarks with deterministic test data.
/// </summary>
public abstract class MacBenchmarkBase
{
    private const int RandomSeed = 0x43727970;

    private protected byte[] _inputData = null!;
    private protected byte[] _outputData = null!;

    protected int Bytes { get; set; } = DataSize.K8.Bytes;

    protected IMac Mac { get; set; } = null!;

    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        var random = new Random(RandomSeed);
        _inputData = new byte[Bytes];
        _outputData = new byte[Mac.MacSize];
        random.NextBytes(_inputData);
    }

    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        Mac?.Dispose();
    }
}
