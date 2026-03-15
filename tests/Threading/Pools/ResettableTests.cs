// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Pools;
using CryptoHives.Foundation.Threading.Async.Pooled;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Threading;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ResettableTests
{
    [Test]
    public void LocalManualResetValueTaskSource_TryReset_Behaviour()
    {
        var owner = new object();
        var local = new LocalManualResetValueTaskSource<bool>(owner);

        // Acquire the local waiter
        bool acquired = local.TryGetValueTaskSource(out var waiter);
        Assert.That(acquired, Is.True);

        // Reset should succeed since it is currently in use
        bool reset = local.TryReset();
        Assert.That(reset, Is.True);

        // Subsequent reset without re-acquire should return false
        bool resetAgain = local.TryReset();
        Assert.That(resetAgain, Is.False);
    }

    [Test]
    public void PooledManualResetValueTaskSource_TryReset_Behaviour()
    {
        var pooled = new PooledManualResetValueTaskSource<bool>();

        // Reset should succeed
        bool reset = pooled.TryReset();
        Assert.That(reset, Is.True);

        // Subsequent reset should succeed
        bool resetAgain = pooled.TryReset();
        Assert.That(resetAgain, Is.True);
    }
}
