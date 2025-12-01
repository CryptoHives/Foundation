// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Pools;

using CryptoHives.Foundation.Memory.Pools;
using Microsoft.Extensions.ObjectPool;
using NUnit.Framework;
using System.Text;

[TestFixture]
public class ObjectOwnerTests
{
    [Test]
    public void EqualsWhenStructIsCopiedEqualsAndHashCodeMatch()
    {
        var pool = new DefaultObjectPool<StringBuilder>(new StringBuilderPooledObjectPolicy());
        var owner1 = new ObjectOwner<StringBuilder>(pool);

        try
        {
            // Copy the struct (implicit field copy)
            ObjectOwner<StringBuilder> owner2 = owner1;

            // Assert - copies that reference same pool and same object are equal
            Assert.That(owner1, Is.EqualTo(owner2));
            Assert.That(((object)owner1), Is.EqualTo(owner2), "Equals(object) should recognize a boxed ObjectOwner");
            Assert.That(owner1.GetHashCode(), Is.EqualTo(owner2.GetHashCode()), "Equal instances must have equal hash codes");
        }
        finally
        {
            // Dispose only once to avoid returning the same object twice.
            owner1.Dispose();
        }
    }

    [Test]
    public void EqualsDifferentObjectsFromSamePoolAreNotEqual()
    {
        var pool = new DefaultObjectPool<StringBuilder>(new StringBuilderPooledObjectPolicy());

        using var owner1 = new ObjectOwner<StringBuilder>(pool);
        using var owner2 = new ObjectOwner<StringBuilder>(pool);

        Assert.That(owner1, Is.Not.EqualTo(owner2), "Distinct pooled objects should not be equal even if from same pool");
        Assert.That(((object)owner1), Is.Not.EqualTo(owner2), "Equals(object) should return false for a different ObjectOwner");
    }

    [Test]
    public void EqualsDifferentPoolsAreNotEqual()
    {
        var poolA = new DefaultObjectPool<StringBuilder>(new StringBuilderPooledObjectPolicy());
        var poolB = new DefaultObjectPool<StringBuilder>(new StringBuilderPooledObjectPolicy());

        using var ownerA = new ObjectOwner<StringBuilder>(poolA);
        using var ownerB = new ObjectOwner<StringBuilder>(poolB);

        Assert.That(ownerA, Is.Not.EqualTo(ownerB), "Owners from different pools should not be equal");
    }

    [Test]
    public void EqualsObjectOfDifferentTypeReturnsFalse()
    {
        var pool = new DefaultObjectPool<StringBuilder>(new StringBuilderPooledObjectPolicy());
        using var owner = new ObjectOwner<StringBuilder>(pool);

        Assert.That((object)owner, Is.Not.EqualTo(new object()), "Equals(object) should return false for unrelated types");
    }
}
