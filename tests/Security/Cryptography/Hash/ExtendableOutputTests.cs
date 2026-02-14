// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Hash;

using CryptoHives.Foundation.Security.Cryptography.Hash;
using CryptoHives.Foundation.Security.Cryptography.Mac;
using NUnit.Framework;
using System;

/// <summary>
/// Tests for the <see cref="IExtendableOutput"/> interface across all XOF-capable algorithms.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ExtendableOutputTests
{
    private static readonly object[] XofAlgorithms =
    [
        new object[] { "Shake128", (Func<IExtendableOutput>)(() => Shake128.Create(32)) },
        new object[] { "Shake256", (Func<IExtendableOutput>)(() => Shake256.Create(64)) },
        new object[] { "TurboShake128", (Func<IExtendableOutput>)(() => TurboShake128.Create(32)) },
        new object[] { "TurboShake256", (Func<IExtendableOutput>)(() => TurboShake256.Create(64)) },
        new object[] { "CShake128", (Func<IExtendableOutput>)(() => CShake128.Create()) },
        new object[] { "CShake256", (Func<IExtendableOutput>)(() => CShake256.Create()) },
        new object[] { "KT128", (Func<IExtendableOutput>)(() => KT128.Create()) },
        new object[] { "KT256", (Func<IExtendableOutput>)(() => KT256.Create()) },
        new object[] { "Blake3", (Func<IExtendableOutput>)(() => Blake3.Create()) },
        new object[] { "KMac128", (Func<IExtendableOutput>)(() => KMac128.Create(new byte[] { 0x01, 0x02, 0x03, 0x04 }, 32)) },
        new object[] { "KMac256", (Func<IExtendableOutput>)(() => KMac256.Create(new byte[] { 0x01, 0x02, 0x03, 0x04 }, 64)) },
        new object[] { "AsconXof128", (Func<IExtendableOutput>)(() => AsconXof128.Create()) }
    ];

    [TestCaseSource(nameof(XofAlgorithms))]
    public void ImplementsIExtendableOutput(string name, Func<IExtendableOutput> factory)
    {
        using var algo = (IDisposable)factory();
        Assert.That(algo, Is.InstanceOf<IExtendableOutput>(), $"{name} should implement IExtendableOutput.");
    }

    [TestCaseSource(nameof(XofAlgorithms))]
    public void AbsorbAndSqueezeProducesNonZeroOutput(string name, Func<IExtendableOutput> factory)
    {
        using var algo = (IDisposable)factory();
        var xof = (IExtendableOutput)algo;

        xof.Absorb(new byte[] { 0x01, 0x02, 0x03 });

        byte[] output = new byte[32];
        xof.Squeeze(output);

        Assert.That(output, Is.Not.EqualTo(new byte[32]), $"{name} Squeeze should produce non-zero output.");
    }

    [Test]
    public void Shake128AbsorbSqueezeMatchesComputeHash()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var shake = Shake128.Create(32))
        {
            expected = shake.ComputeHash(input);
        }

        using var xof = Shake128.Create(32);
        xof.Absorb(input);
        byte[] actual = new byte[32];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Shake256AbsorbSqueezeMatchesComputeHash()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var shake = Shake256.Create(64))
        {
            expected = shake.ComputeHash(input);
        }

        using var xof = Shake256.Create(64);
        xof.Absorb(input);
        byte[] actual = new byte[64];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TurboShake128AbsorbSqueezeMatchesComputeHash()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var turbo = TurboShake128.Create(32))
        {
            expected = turbo.ComputeHash(input);
        }

        using var xof = TurboShake128.Create(32);
        xof.Absorb(input);
        byte[] actual = new byte[32];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CShake128AbsorbSqueezeMatchesComputeHash()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var cshake = CShake128.Create())
        {
            expected = cshake.ComputeHash(input);
        }

        using var xof = CShake128.Create();
        xof.Absorb(input);
        byte[] actual = new byte[32];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void CShake256AbsorbSqueezeMatchesComputeHash()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var cshake = CShake256.Create())
        {
            expected = cshake.ComputeHash(input);
        }

        using var xof = CShake256.Create();
        xof.Absorb(input);
        byte[] actual = new byte[64];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void KT128AbsorbSqueezeMatchesComputeHash()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var kt = KT128.Create())
        {
            expected = kt.ComputeHash(input);
        }

        using var xof = KT128.Create();
        xof.Absorb(input);
        byte[] actual = new byte[32];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void KT256AbsorbSqueezeMatchesComputeHash()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var kt = KT256.Create())
        {
            expected = kt.ComputeHash(input);
        }

        using var xof = KT256.Create();
        xof.Absorb(input);
        byte[] actual = new byte[64];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Blake3AbsorbSqueezeMatchesComputeHash()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var blake = Blake3.Create())
        {
            expected = blake.ComputeHash(input);
        }

        using var xof = Blake3.Create();
        xof.Absorb(input);
        byte[] actual = new byte[32];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void KMac128AbsorbSqueezeMatchesComputeHash()
    {
        byte[] key = [0x01, 0x02, 0x03, 0x04];
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var kmac = KMac128.Create(key, 32))
        {
            expected = kmac.ComputeHash(input);
        }

        using var xof = KMac128.Create(key, 32);
        xof.Absorb(input);
        byte[] actual = new byte[32];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void KMac256AbsorbSqueezeMatchesComputeHash()
    {
        byte[] key = [0x01, 0x02, 0x03, 0x04];
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var kmac = KMac256.Create(key, 64))
        {
            expected = kmac.ComputeHash(input);
        }

        using var xof = KMac256.Create(key, 64);
        xof.Absorb(input);
        byte[] actual = new byte[64];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void AsconXof128AbsorbSqueezeMatchesComputeHash()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];
        byte[] expected;
        using (var ascon = AsconXof128.Create())
        {
            expected = ascon.ComputeHash(input);
        }

        using var xof = AsconXof128.Create();
        xof.Absorb(input);
        byte[] actual = new byte[32];
        xof.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void MultipleAbsorbMatchesSingleAbsorb()
    {
        byte[] input1 = [0x01, 0x02, 0x03];
        byte[] input2 = [0x04, 0x05, 0x06];
        byte[] combined = [0x01, 0x02, 0x03, 0x04, 0x05, 0x06];

        using var singleAbsorb = Shake128.Create(32);
        singleAbsorb.Absorb(combined);
        byte[] expected = new byte[32];
        singleAbsorb.Squeeze(expected);

        using var multiAbsorb = Shake128.Create(32);
        multiAbsorb.Absorb(input1);
        multiAbsorb.Absorb(input2);
        byte[] actual = new byte[32];
        multiAbsorb.Squeeze(actual);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(XofAlgorithms))]
    public void ResetAllowsReuse(string name, Func<IExtendableOutput> factory)
    {
        using var algo = (IDisposable)factory();
        var xof = (IExtendableOutput)algo;

        byte[] input = [0x01, 0x02, 0x03];

        xof.Absorb(input);
        byte[] first = new byte[32];
        xof.Squeeze(first);

        xof.Reset();

        xof.Absorb(input);
        byte[] second = new byte[32];
        xof.Squeeze(second);

        Assert.That(second, Is.EqualTo(first), $"{name} Reset should produce identical output for identical input.");
    }

    [Test]
    public void ResetAfterSqueezeAllowsNewAbsorb()
    {
        byte[] input1 = [0xAA, 0xBB];
        byte[] input2 = [0xCC, 0xDD];

        using var xof = Shake256.Create(32);

        xof.Absorb(input1);
        byte[] hash1 = new byte[32];
        xof.Squeeze(hash1);

        xof.Reset();

        xof.Absorb(input2);
        byte[] hash2 = new byte[32];
        xof.Squeeze(hash2);

        Assert.That(hash2, Is.Not.EqualTo(hash1), "Different input after Reset should produce different output.");
    }

    [TestCaseSource(nameof(XofAlgorithms))]
    public void MultiSqueezeMatchesSingleSqueeze(string name, Func<IExtendableOutput> factory)
    {
        byte[] input = [0x01, 0x02, 0x03, 0x04, 0x05];

        // Single squeeze of 64 bytes
        using var single = (IDisposable)factory();
        var singleXof = (IExtendableOutput)single;
        singleXof.Absorb(input);
        byte[] expected = new byte[64];
        singleXof.Squeeze(expected);

        // Two squeezes of 32 bytes each
        using var multi = (IDisposable)factory();
        var multiXof = (IExtendableOutput)multi;
        multiXof.Absorb(input);
        byte[] part1 = new byte[32];
        byte[] part2 = new byte[32];
        multiXof.Squeeze(part1);
        multiXof.Squeeze(part2);

        byte[] actual = new byte[64];
        part1.CopyTo(actual, 0);
        part2.CopyTo(actual, 32);

        Assert.That(actual, Is.EqualTo(expected), $"{name} multi-squeeze should produce same output as single squeeze.");
    }

    [TestCaseSource(nameof(XofAlgorithms))]
    public void MultiSqueezeNonAligned(string name, Func<IExtendableOutput> factory)
    {
        byte[] input = [0xDE, 0xAD];

        // Single squeeze of 37 bytes
        using var single = (IDisposable)factory();
        var singleXof = (IExtendableOutput)single;
        singleXof.Absorb(input);
        byte[] expected = new byte[37];
        singleXof.Squeeze(expected);

        // Three squeezes of 10 + 15 + 12 = 37 bytes
        using var multi = (IDisposable)factory();
        var multiXof = (IExtendableOutput)multi;
        multiXof.Absorb(input);
        byte[] p1 = new byte[10];
        byte[] p2 = new byte[15];
        byte[] p3 = new byte[12];
        multiXof.Squeeze(p1);
        multiXof.Squeeze(p2);
        multiXof.Squeeze(p3);

        byte[] actual = new byte[37];
        p1.CopyTo(actual, 0);
        p2.CopyTo(actual, 10);
        p3.CopyTo(actual, 25);

        Assert.That(actual, Is.EqualTo(expected), $"{name} non-aligned multi-squeeze should match single squeeze.");
    }

    [Test]
    public void Blake3LargeOutputMatchesStreamingSqueeze()
    {
        byte[] input = [0xAB, 0xCD, 0xEF];

        // Single squeeze of 256 bytes (4x64-byte blocks)
        using var single = Blake3.Create(256);
        single.Absorb(input);
        byte[] expected = new byte[256];
        single.Squeeze(expected);

        // Streaming squeeze: 100 + 100 + 56 = 256 bytes
        using var multi = Blake3.Create(256);
        multi.Absorb(input);
        byte[] p1 = new byte[100];
        byte[] p2 = new byte[100];
        byte[] p3 = new byte[56];
        multi.Squeeze(p1);
        multi.Squeeze(p2);
        multi.Squeeze(p3);

        byte[] actual = new byte[256];
        p1.CopyTo(actual, 0);
        p2.CopyTo(actual, 100);
        p3.CopyTo(actual, 200);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCaseSource(nameof(XofAlgorithms))]
    public void SqueezeWithEmptySpanDoesNotThrow(string name, Func<IExtendableOutput> factory)
    {
        using var algo = (IDisposable)factory();
        var xof = (IExtendableOutput)algo;

        xof.Absorb(new byte[] { 0x01, 0x02, 0x03 });
        Assert.DoesNotThrow(() => xof.Squeeze(Span<byte>.Empty), $"{name} Squeeze with empty span should not throw.");
    }

    [TestCaseSource(nameof(XofAlgorithms))]
    public void AbsorbAfterSqueezeThrows(string name, Func<IExtendableOutput> factory)
    {
        using var algo = (IDisposable)factory();
        var xof = (IExtendableOutput)algo;

        xof.Absorb(new byte[] { 0x01, 0x02, 0x03 });
        byte[] output = new byte[32];
        xof.Squeeze(output);

        Assert.Throws<InvalidOperationException>(
            () => xof.Absorb(new byte[] { 0x04 }),
            $"{name} Absorb after Squeeze should throw InvalidOperationException.");
    }

    [TestCaseSource(nameof(XofAlgorithms))]
    public void AbsorbAfterResetDoesNotThrow(string name, Func<IExtendableOutput> factory)
    {
        using var algo = (IDisposable)factory();
        var xof = (IExtendableOutput)algo;

        xof.Absorb(new byte[] { 0x01, 0x02, 0x03 });
        byte[] output = new byte[32];
        xof.Squeeze(output);

        xof.Reset();

        Assert.DoesNotThrow(
            () => xof.Absorb(new byte[] { 0x04 }),
            $"{name} Absorb after Reset should not throw.");
    }

    [TestCaseSource(nameof(XofAlgorithms))]
    public void SqueezeWithEmptyAbsorbProducesOutput(string name, Func<IExtendableOutput> factory)
    {
        using var algo = (IDisposable)factory();
        var xof = (IExtendableOutput)algo;

        byte[] output = new byte[32];
        xof.Squeeze(output);

        Assert.That(output, Is.Not.EqualTo(new byte[32]),
            $"{name} Squeeze without Absorb should still produce non-zero output.");
    }
}
