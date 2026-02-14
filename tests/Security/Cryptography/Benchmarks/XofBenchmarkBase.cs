// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Hash;
using NUnit.Framework;
using System;

/// <summary>
/// Base class for XOF (extendable-output function) benchmarks with deterministic test data.
/// </summary>
/// <remarks>
/// Uses a fixed 1 KB absorb buffer (absorbed twice per iteration = 2 KB input) and a variable
/// squeeze buffer sized by <see cref="SqueezeBytes"/>. This isolates squeeze throughput from
/// absorb overhead, which is the primary differentiator of XOF algorithms.
/// </remarks>
public abstract class XofBenchmarkBase
{
    private const int RandomSeed = 0x43727970;

    /// <summary>
    /// Fixed absorb block size: 1 KB absorbed twice per iteration.
    /// </summary>
    private const int AbsorbBlockBytes = 1024;

    private protected byte[] _inputData = null!;
    private protected byte[] _outputData = null!;

    /// <summary>
    /// Gets or sets the number of bytes to squeeze as output.
    /// </summary>
    protected int SqueezeBytes { get; set; } = XofDataSize.K8.Bytes;

    /// <summary>
    /// Gets or sets the XOF instance under test.
    /// </summary>
    protected IExtendableOutput XofInstance { get; set; } = null!;

    /// <inheritdoc/>
    [OneTimeSetUp]
    [GlobalSetup]
    public virtual void GlobalSetup()
    {
        var random = new Random(RandomSeed);
        _inputData = new byte[AbsorbBlockBytes];
        _outputData = new byte[SqueezeBytes];
        random.NextBytes(_inputData);
    }

    /// <inheritdoc/>
    [OneTimeTearDown]
    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
        (XofInstance as IDisposable)?.Dispose();
    }
}
