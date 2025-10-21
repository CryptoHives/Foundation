using CryptoHives.Memory.Pools;
using NUnit.Framework;
using System;
using System.Collections.Concurrent;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoHives.Memory.Tests.Pools
{
    [TestFixture]
    public class ObjectPoolsTests
    {
        [Test]
        public void GetStringBuilder_Returns_ObjectOwner_With_Valid_StringBuilder()
        {
            // Act
            using var owner = ObjectPools.GetStringBuilder();

            // Assert
            Assert.That(owner.Object, Is.Not.Null, "ObjectOwner.Object should not be null");
            Assert.That(owner.Object, Is.InstanceOf<StringBuilder>(), "ObjectOwner.Object should be a StringBuilder");
        }

        [Test]
        public void GetStringBuilder_Object_Is_Reusable_After_Dispose()
        {
            StringBuilder sb1;
            using (var owner = ObjectPools.GetStringBuilder())
            {
                sb1 = owner.Object;
                sb1.Append("test");
                Assert.That(sb1.ToString(), Is.EqualTo("test"));
            }

            // After dispose, the StringBuilder should be returned to the pool and cleared
            StringBuilder sb2;
            using var owner2 = ObjectPools.GetStringBuilder();
            sb2 = owner2.Object;

            // The pool should clear the StringBuilder before reusing
            Assert.That(sb2.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void GetStringBuilder_CanBeUsedConcurrently()
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
                        using var owner = ObjectPools.GetStringBuilder();
                        var sb = owner.Object;
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
}
