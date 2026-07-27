// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Mac;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Base class for parameterized MAC algorithm benchmarks.
/// </summary>
/// <remarks>
/// Mirrors <c>ParameterizedHashBenchmark</c> but exercises the <see cref="CryptoHives.Foundation.Security.Cryptography.Mac.IMac"/>
/// Update/Finalize/Reset contract instead of <c>HashAlgorithm.TryComputeHash</c>.
/// </remarks>
public abstract class ParameterizedMacBenchmark : MacBenchmarkBase
{
    [ParamsSource(nameof(Sizes))]
    public DataSize TestDataSize { get; set; } = DataSize.K8;

    [ParamsSource("Algorithms")]
    public MacAlgorithmType TestMacAlgorithm { get; set; } = null!;

    public static IEnumerable<DataSize> Sizes() => DataSize.AllSizes;

    protected ParameterizedMacBenchmark() { }

    protected ParameterizedMacBenchmark(MacAlgorithmType macAlgorithm) => TestMacAlgorithm = macAlgorithm;

    public override void GlobalSetup()
    {
        Bytes = TestDataSize.Bytes;
        Mac = TestMacAlgorithm.Create();
        base.GlobalSetup();
    }

    [Test, Repeat(5)]
    [TestCaseSource(typeof(DataSize), nameof(DataSize.AllSizes))]
    public void TestComputeMac(DataSize dataSize)
    {
        TestDataSize = dataSize;
        GlobalSetup();
        Mac.Reset();
        Mac.Update(_inputData);
        Mac.Finalize(_outputData);
        Assert.That(_outputData, Has.Length.EqualTo(Mac.MacSize));
        bool allZeros = _outputData.All(b => b == 0);
        Assert.That(allZeros, Is.False, "MAC output should not be all zeros.");
    }

    [Benchmark]
    public void ComputeMac()
    {
        Mac.Reset();
        Mac.Update(_inputData);
        Mac.Finalize(_outputData);
    }
}
