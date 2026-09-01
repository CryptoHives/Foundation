// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Pools;

using CryptoHives.Foundation.Memory.Buffers;
using CryptoHives.Foundation.Memory.Pools;
using Microsoft.Extensions.ObjectPool;
using NUnit.Framework;
using System;

/// <summary>
/// Covers <see cref="ArrayPoolBufferWriterProvider{T}"/>: that differently configured providers share
/// one pool, and that a rented writer always carries its own provider's settings rather than whatever
/// the previous renter left behind.
/// </summary>
/// <remarks>
/// <para>
/// Not parallelizable: these tests reason about the identity of instances coming out of the shared
/// pool, so a concurrent test renting from it would make the assertions meaningless.
/// </para>
/// <para>
/// The <c>clearArray</c> ordering — reset under the outgoing renter's setting, reconfigure only after
/// the pool has handed the instance on — is guaranteed by the shape of <c>Dispose</c> and
/// <c>Rent</c> rather than asserted here. Whether <see cref="System.Buffers.ArrayPool{T}"/> actually
/// returned a zeroed array is not observable without renting the very same array again, which is not
/// deterministic, so a test for it would be flaky rather than useful.
/// </para>
/// </remarks>
[NonParallelizable]
public class ArrayPoolBufferWriterProviderTests
{
    /// <summary>Drains the shared pool so a test starts from a known state.</summary>
    private static void DrainSharedPool()
    {
        ObjectPool<ArrayPoolBufferWriter<byte>> pool = PoolFactory.SharedBufferWriterPool<byte>();
        for (int i = 0; i < 64; i++)
        {
            _ = pool.Get();
        }
    }

    [Test]
    public void ProvidersWithDifferentSettingsShareOnePool()
    {
        // The whole point of configuring at rent: two use cases, one set of instances.
        DrainSharedPool();

        var small = new ArrayPoolBufferWriterProvider<byte>(defaultChunkSize: 64, maxChunkSize: 128);
        var large = new ArrayPoolBufferWriterProvider<byte>(defaultChunkSize: 4096, maxChunkSize: 8192);

        ArrayPoolBufferWriter<byte> first = small.Rent();
        first.Dispose();

        ArrayPoolBufferWriter<byte> second = large.Rent();
        try
        {
            Assert.That(second, Is.SameAs(first), "differently configured providers should reuse instances");
        }
        finally
        {
            second.Dispose();
        }
    }

    [Test]
    public void ARentedWriterCarriesItsOwnProvidersSettings()
    {
        DrainSharedPool();

        var large = new ArrayPoolBufferWriterProvider<byte>(defaultChunkSize: 8192, maxChunkSize: 16384);
        var small = new ArrayPoolBufferWriterProvider<byte>(defaultChunkSize: 32, maxChunkSize: 64);

        // Ramp the instance up under the large profile, then hand it back.
        ArrayPoolBufferWriter<byte> big = large.Rent();
        int bigSpan = big.GetSpan(1).Length;
        big.Dispose();

        using ArrayPoolBufferWriter<byte> tiny = small.Rent();
        int tinySpan = tiny.GetSpan(1).Length;

        using (Assert.EnterMultipleScope())
        {
            Assert.That(bigSpan, Is.GreaterThanOrEqualTo(8192));
            Assert.That(tinySpan, Is.GreaterThanOrEqualTo(32).And.LessThan(8192),
                "the recycled writer must take the new provider's chunk size, not the previous renter's");
        }
    }

    [Test]
    public void TheDefaultRentPathIsUnaffectedByAPreviousNonDefaultRenter()
    {
        DrainSharedPool();

        var large = new ArrayPoolBufferWriterProvider<byte>(defaultChunkSize: 8192, maxChunkSize: 16384);
        large.Rent().Dispose();

        using ArrayPoolBufferWriter<byte> plain = ObjectPools.RentBufferWriter<byte>();

        Assert.That(plain.GetSpan(1).Length, Is.LessThan(8192),
            "RentBufferWriter must configure, not inherit whatever was left on the instance");
    }

    [Test]
    public void ADefaultProviderMatchesTheNoArgumentRentPath()
    {
        // Pins the const defaults and the default provider together, so they cannot drift apart.
        DrainSharedPool();

        var defaults = new ArrayPoolBufferWriterProvider<byte>();

        ArrayPoolBufferWriter<byte> viaProvider = defaults.Rent();
        int providerSpan = viaProvider.GetSpan(1).Length;
        viaProvider.Dispose();

        ArrayPoolBufferWriter<byte> viaObjectPools = ObjectPools.RentBufferWriter<byte>();
        int objectPoolsSpan = viaObjectPools.GetSpan(1).Length;
        viaObjectPools.Dispose();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(providerSpan, Is.EqualTo(objectPoolsSpan));
            Assert.That(providerSpan, Is.GreaterThanOrEqualTo(ArrayPoolBufferWriter<byte>.DefaultChunkSize));
        }
    }

    [Test]
    public void AProviderCanBeGivenAnIsolatedPool()
    {
        DrainSharedPool();

        ObjectPool<ArrayPoolBufferWriter<byte>> isolated = PoolFactory.CreateBufferWriterPool<byte>();
        var provider = new ArrayPoolBufferWriterProvider<byte>(pool: isolated);

        ArrayPoolBufferWriter<byte> fromIsolated = provider.Rent();
        fromIsolated.Dispose();

        // The instance went back to the isolated pool, so the shared pool must not produce it.
        ArrayPoolBufferWriter<byte> fromShared = ObjectPools.RentBufferWriter<byte>();
        try
        {
            Assert.That(fromShared, Is.Not.SameAs(fromIsolated));
        }
        finally
        {
            fromShared.Dispose();
        }
    }

    [Test]
    public void ARentedWriterStillReturnsItselfOnDispose()
    {
        DrainSharedPool();

        var provider = new ArrayPoolBufferWriterProvider<byte>(clearArray: true);

        ArrayPoolBufferWriter<byte> first = provider.Rent();
        first.Dispose();

        ArrayPoolBufferWriter<byte> second = provider.Rent();
        try
        {
            Assert.That(second, Is.SameAs(first));
        }
        finally
        {
            second.Dispose();
        }
    }

    // ---------------------------------------------------------------- validation

    [TestCase(0)]
    [TestCase(-1)]
    public void AProviderRejectsANonPositiveChunkSize(int chunkSize)
    {
        // Zero used to be accepted and left the writer permanently unable to grow, since the ramp is
        // Math.Min(max, chunkSize * 2).
        Assert.That(() => new ArrayPoolBufferWriterProvider<byte>(defaultChunkSize: chunkSize),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(0)]
    [TestCase(-1)]
    public void TheWriterConstructorRejectsANonPositiveChunkSize(int chunkSize)
    {
        Assert.That(() => new ArrayPoolBufferWriter<byte>(false, chunkSize, 4096),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    /// <summary>
    /// A maximum at or below the default is a valid way to say "never grow", not a mistake: the ramp
    /// in CheckAndAllocateBuffer is guarded by chunkSize &lt; maxChunkSize, so it simply never fires.
    /// The existing chunking theory sweeps maxChunkSize over 0 and values below the default, so this
    /// pins the contract those cases depend on.
    /// </summary>
    [TestCase(512, 256)]
    [TestCase(512, 512)]
    [TestCase(512, 0)]
    public void AMaximumAtOrBelowTheDefaultPinsTheChunkSize(int defaultChunkSize, int maxChunkSize)
    {
        DrainSharedPool();

        var provider = new ArrayPoolBufferWriterProvider<byte>(
            defaultChunkSize: defaultChunkSize, maxChunkSize: maxChunkSize);

        using ArrayPoolBufferWriter<byte> writer = provider.Rent();

        // Fill several chunks; without a ramp every one of them stays at the default size.
        for (int i = 0; i < 8; i++)
        {
            int span = writer.GetSpan(1).Length;
            Assert.That(span, Is.GreaterThanOrEqualTo(defaultChunkSize).And.LessThan(defaultChunkSize * 2),
                $"chunk {i} should not have grown");
            writer.Advance(span);
        }
    }
}
