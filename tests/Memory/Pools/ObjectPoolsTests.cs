// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace CryptoHives.Memory.Tests.Pools;

using CryptoHives.Memory.Pools;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[TestFixture]
public class ObjectPoolsTests
{
    [Test]
    public void GetStringBuilderReturnsObjectOwnerWithValidStringBuilder()
    {
        // Act
        using ObjectOwner<StringBuilder> owner = ObjectPools.GetStringBuilder();

        // Assert
        Assert.That(owner.Object, Is.Not.Null, "ObjectOwner.Object should not be null");
        Assert.That(owner.Object, Is.InstanceOf<StringBuilder>(), "ObjectOwner.Object should be a StringBuilder");
    }

    [Test]
    public void GetStringBuilderObjectIsReusableAfterDispose()
    {
        StringBuilder sb1;
        using (ObjectOwner<StringBuilder> owner = ObjectPools.GetStringBuilder())
        {
            sb1 = owner.Object;
            sb1.Append("test");
            Assert.That(sb1.ToString(), Is.EqualTo("test"));
        }

        // The pool should clear the StringBuilder on return
        Assert.That(sb1.ToString(), Is.EqualTo(string.Empty));

        // After dispose, the StringBuilder should be returned to the pool and cleared
        StringBuilder sb2;
        using ObjectOwner<StringBuilder> owner2 = ObjectPools.GetStringBuilder();
        sb2 = owner2.Object;

        // The pool should clear the StringBuilder before reusing
        Assert.That(sb2.ToString(), Is.EqualTo(string.Empty));
    }

    [Test]
    public void GetStringBuilderCanBeUsedConcurrently()
    {
        const int concurrency = 32;
        const int iterations = 100;
        var exceptions = new ConcurrentQueue<Exception>();
        int index = 0;
        int GetUniqueIndex() => Interlocked.Increment(ref index);

        Parallel.For(0, concurrency, _ => {
            try
            {
                int myIndex = GetUniqueIndex();
                for (int i = 0; i < iterations; i++)
                {
                    using ObjectOwner<StringBuilder> owner = ObjectPools.GetStringBuilder();
                    StringBuilder sb = owner.Object;
                    sb.AppendFormat("{0}:{1}", myIndex, i);
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

