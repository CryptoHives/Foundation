// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Base class for parameterized XOF benchmarks using Absorb/Squeeze/Reset.
/// </summary>
/// <remarks>
/// Derived classes provide algorithm-specific factories via <see cref="XofAlgorithmType"/>.
/// The benchmark absorbs a fixed 2 KB of input (two 1 KB blocks) and squeezes
/// <see cref="TestDataSize"/> bytes of output, isolating squeeze throughput.
/// </remarks>
public abstract class ParameterizedXofBenchmark : XofBenchmarkBase
{
    [ParamsSource(nameof(Sizes))]
    public XofDataSize TestDataSize { get; set; } = XofDataSize.K8;

    [ParamsSource("Algorithms")]
    public XofAlgorithmType TestXofAlgorithm { get; set; } = null!;

    public static IEnumerable<XofDataSize> Sizes() => XofDataSize.AllSizes;

    protected ParameterizedXofBenchmark() => TestDataSize = XofDataSize.K8;

    protected ParameterizedXofBenchmark(XofAlgorithmType xofAlgorithm)
    {
        TestDataSize = XofDataSize.K8;
        TestXofAlgorithm = xofAlgorithm;
    }

    public override void GlobalSetup()
    {
        SqueezeBytes = TestDataSize.Bytes;
        XofInstance = TestXofAlgorithm.Create();
        base.GlobalSetup();
    }

    [Test, Repeat(5)]
    [TestCaseSource(typeof(XofDataSize), nameof(XofDataSize.AllSizes))]
    public void TestAbsorbSqueeze(XofDataSize dataSize)
    {
        TestDataSize = dataSize;
        GlobalSetup();

        AbsorbSqueeze();

        bool allZeros = _outputData.AsSpan().Slice(0, TestDataSize.Bytes).ToArray().All(b => b == 0);
        Assert.That(allZeros, Is.False, "XOF output should not be all zeros.");
    }

    [Benchmark]
    public void AbsorbSqueeze()
    {
        XofInstance.Absorb(_inputData);
        XofInstance.Absorb(_inputData);
        XofInstance.Squeeze(_outputData);
        XofInstance.Reset();
    }
}
