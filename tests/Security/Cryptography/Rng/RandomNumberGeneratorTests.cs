// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Cryptography.Tests.Rng;

using CryptoHives.Foundation.Security.Cryptography.Rng;
using NUnit.Framework;
using System;
using System.Buffers;

/// <summary>
/// Tests for the <see cref="RandomNumberGenerator"/> polyfill.
/// </summary>
[TestFixture]
[NonParallelizable]
public class RandomNumberGeneratorTests
{
    [Test]
    public void GetBytes_FillsRequestedLength()
    {
        Span<byte> buffer = stackalloc byte[32];
        using var rng = RandomNumberGenerator.Create();

        rng.GetBytes(buffer);

        Assert.That(buffer.ToArray(), Is.Not.EqualTo(new byte[32]));
    }

#if !NET6_0_OR_GREATER
    /// <summary>
    /// On frameworks without a span-based OS API, <see cref="RandomNumberGenerator.GetBytes(Span{byte})"/>
    /// rents a scratch buffer from <see cref="ArrayPool{T}.Shared"/> to fill it, then must return the
    /// buffer cleared - otherwise the random bytes it just generated remain in the pooled array and
    /// leak to whichever unrelated caller rents that array next.
    /// </summary>
    [Test]
    public void GetBytes_DoesNotLeakRandomBytesIntoSharedArrayPool()
    {
        const int size = 4096; // Unusual size to avoid collisions with other pool users.

        // Seed the pool bucket with a dirty, sentinel-filled array so we can tell whether
        // it comes back cleared after GetBytes uses and returns it.
        byte[] seed = ArrayPool<byte>.Shared.Rent(size);
        for (int i = 0; i < seed.Length; i++)
        {
            seed[i] = 0xAA;
        }
        ArrayPool<byte>.Shared.Return(seed, clearArray: false);

        Span<byte> buffer = new byte[size];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(buffer);

        // Rent from the same bucket; the default ArrayPool reuses the most recently
        // returned array for a given size class on this thread (LIFO), so this is
        // very likely the same backing array GetBytes just rented and returned.
        byte[] reclaimed = ArrayPool<byte>.Shared.Rent(size);
        try
        {
            Assert.That(reclaimed, Has.None.EqualTo((byte)0xAA), "Sentinel byte survived: array was not cleared on return.");
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(reclaimed);
        }
    }
#endif
}
