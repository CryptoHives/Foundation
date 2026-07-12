// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Threading.Tests.Pools;

using CryptoHives.Foundation.Threading.Async.Pooled;
using CryptoHives.Foundation.Threading.Pools;
using NUnit.Framework;
using System;
using System.Reflection;
using System.Threading;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ResettableTests
{
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
