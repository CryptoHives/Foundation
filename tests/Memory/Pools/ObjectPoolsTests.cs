// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Pools;

using CryptoHives.Foundation.Memory.Pools;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// Tests for <see cref="ObjectPools"/>.
/// </summary>
[TestFixture]
[Parallelizable(ParallelScope.All)]
public class ObjectPoolsTests
{
    [Test]
    public void GetStringBuilderReturnsObjectOwnerWithValidStringBuilder()
    {
        using ObjectOwner<StringBuilder> owner = ObjectPools.GetStringBuilder();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(owner.PooledObject, Is.Not.Null);
            Assert.That(owner.PooledObject, Is.InstanceOf<StringBuilder>());
        }
    }

    [Test]
    public void GetStringBuilderObjectIsReusableAfterDispose()
    {
        StringBuilder sb1;
        using (ObjectOwner<StringBuilder> owner = ObjectPools.GetStringBuilder())
        {
            sb1 = owner.PooledObject;
            sb1.Append("test");
            Assert.That(sb1.ToString(), Is.EqualTo("test"));
        }

        Assert.That(sb1.ToString(), Is.EqualTo(string.Empty), "Pool should clear the StringBuilder on return");

        using ObjectOwner<StringBuilder> owner2 = ObjectPools.GetStringBuilder();
        Assert.That(owner2.PooledObject.ToString(), Is.EqualTo(string.Empty), "Reused StringBuilder should be empty");
    }

    [Test]
    public void GetStringBuilderCanBeUsedConcurrently()
    {
        const int concurrency = 32;
        const int iterations = 100;
        var exceptions = new ConcurrentQueue<Exception>();
        int index = 0;
        int GetUniqueIndex() => Interlocked.Increment(ref index);

        _ = Parallel.For(0, concurrency, _ => {
            try
            {
                int myIndex = GetUniqueIndex();
                for (int i = 0; i < iterations; i++)
                {
                    using ObjectOwner<StringBuilder> owner = ObjectPools.GetStringBuilder();
                    StringBuilder sb = owner.PooledObject;
                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0}:{1}", myIndex, i);
                    Assert.That(sb.ToString(), Is.EqualTo($"{myIndex}:{i}"));
                }
            }
            catch (Exception ex)
            {
                exceptions.Enqueue(ex);
            }
        });

        Assert.That(exceptions, Is.Empty, "No exceptions should be thrown during concurrent use.");
    }
}

