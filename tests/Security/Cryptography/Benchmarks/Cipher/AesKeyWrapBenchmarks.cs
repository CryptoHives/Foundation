// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Benchmarks.Cipher;

using BenchmarkDotNet.Attributes;
using CryptoHives.Foundation.Security.Cryptography.Cipher;
using NUnit.Framework;
using System;

/// <summary>
/// Benchmarks for AES Key Wrap (RFC 3394) and AES Key Wrap with Padding (RFC 5649).
/// </summary>
[TestFixture]
[Config(typeof(CipherConfig))]
[MemoryDiagnoser(displayGenColumns: false)]
[HideColumns("Namespace")]
[BenchmarkCategory("Cipher", "KeyWrap", "AES-KW-KWP")]
[NonParallelizable]
public sealed class AesKeyWrapBenchmark
{
    private const int RandomSeed = 0x43727970;

    private AesKeyWrapPad _kwp = null!;
    private byte[] _keyMaterialNoPad = null!;
    private byte[] _keyMaterialPad = null!;
    private byte[] _wrappedNoPad = null!;
    private byte[] _wrappedPad = null!;

    /// <summary>
    /// Performs benchmark setup.
    /// </summary>
    [OneTimeSetUp]
    [GlobalSetup]
    public void GlobalSetup()
    {
        var random = new Random(RandomSeed);

        byte[] kek = new byte[32];
        random.NextBytes(kek);

        _keyMaterialNoPad = new byte[32];
        _keyMaterialPad = new byte[37];
        random.NextBytes(_keyMaterialNoPad);
        random.NextBytes(_keyMaterialPad);

        _kwp = new AesKeyWrapPad(kek);
        _wrappedNoPad = _kwp.WrapKeyNoPad(_keyMaterialNoPad);
        _wrappedPad = _kwp.WrapKey(_keyMaterialPad);
    }

    /// <summary>
    /// Performs benchmark cleanup.
    /// </summary>
    [OneTimeTearDown]
    [GlobalCleanup]
    public void GlobalCleanup()
    {
        _kwp.Dispose();
    }

    [Test, Repeat(5)]
    [NonParallelizable]
    public void WrapKeyNoPadTest()
    {
        byte[] wrapped = WrapKeyNoPad();
        Assert.That(wrapped.Length, Is.EqualTo(_wrappedNoPad.Length));
    }

    /// <summary>
    /// Benchmarks RFC 3394 key wrapping without padding.
    /// </summary>
    [Benchmark(Description = "WrapNoPad")]
    public byte[] WrapKeyNoPad() => _kwp.WrapKeyNoPad(_keyMaterialNoPad);

    [Test, Repeat(5)]
    [NonParallelizable]
    public void UnwrapKeyNoPadTest()
    {
        byte[] unwrapped = UnwrapKeyNoPad();
        Assert.That(unwrapped.AsSpan().SequenceEqual(_keyMaterialNoPad), Is.True);
    }

    /// <summary>
    /// Benchmarks RFC 3394 key unwrapping without padding.
    /// </summary>
    [Benchmark(Description = "UnwrapNoPad")]
    public byte[] UnwrapKeyNoPad() => _kwp.UnwrapKeyNoPad(_wrappedNoPad);

    [Test, Repeat(5)]
    [NonParallelizable]
    public void WrapKeyPadTest()
    {
        byte[] wrapped = WrapKeyPad();
        Assert.That(wrapped.Length, Is.EqualTo(_wrappedPad.Length));
    }

    /// <summary>
    /// Benchmarks RFC 5649 key wrapping with padding.
    /// </summary>
    [Benchmark(Description = "WrapPad")]
    public byte[] WrapKeyPad() => _kwp.WrapKey(_keyMaterialPad);

    [Test, Repeat(5)]
    [NonParallelizable]
    public void UnwrapKeyPadTest()
    {
        byte[] unwrapped = UnwrapKeyPad();
        Assert.That(unwrapped.AsSpan().SequenceEqual(_keyMaterialPad), Is.True);
    }

    /// <summary>
    /// Benchmarks RFC 5649 key unwrapping with padding.
    /// </summary>
    [Benchmark(Description = "UnwrapPad")]
    public byte[] UnwrapKeyPad() => _kwp.UnwrapKey(_wrappedPad);
}
