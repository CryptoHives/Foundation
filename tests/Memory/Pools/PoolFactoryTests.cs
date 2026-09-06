// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT

namespace Memory.Tests.Pools;

using CryptoHives.Foundation.Memory.Pools;
using Microsoft.Extensions.ObjectPool;
using NUnit.Framework;
using System;
#if NET6_0_OR_GREATER
using CryptoHives.Foundation.Memory.Buffers;
using System.Buffers;
using System.IO;
using System.Text;
using System.Text.Json;
#endif

/// <summary>
/// Covers <see cref="PoolFactory.CreatePool{T}"/>, the delegate-driven factory that lets callers pool
/// types this package does not reference.
/// </summary>
[NonParallelizable]
public class PoolFactoryTests
{
    private sealed class Widget
    {
        public int ResetCount { get; set; }

        public string? Payload { get; set; }
    }

    [Test]
    public void CreatePoolRecyclesInstancesAndRunsReset()
    {
        int created = 0;
        ObjectPool<Widget> pool = PoolFactory.CreatePool(
            () => { created++; return new Widget(); },
            widget => { widget.ResetCount++; widget.Payload = null; return true; });

        Widget first = pool.Get();
        first.Payload = "in use";
        pool.Return(first);

        Widget second = pool.Get();

        using (Assert.EnterMultipleScope())
        {
            Assert.That(second, Is.SameAs(first), "the instance should be recycled");
            Assert.That(created, Is.EqualTo(1), "create should not run again for a recycled instance");
            Assert.That(second.ResetCount, Is.EqualTo(1));
            Assert.That(second.Payload, Is.Null, "reset should have cleared the payload");
        }
    }

    [Test]
    public void AnInstanceRejectedByResetIsDropped()
    {
        ObjectPool<Widget> pool = PoolFactory.CreatePool(
            () => new Widget(),
            static _ => false);

        Widget first = pool.Get();
        pool.Return(first);

        Widget second = pool.Get();

        Assert.That(second, Is.Not.SameAs(first), "a rejected instance must not come back out");
    }

    [Test]
    public void MaximumRetainedOfZeroStillPools()
    {
        // Zero means "use the default retention", not "retain nothing" — a zero-capacity pool would
        // silently disable pooling for every caller who left the argument off.
        ObjectPool<Widget> pool = PoolFactory.CreatePool(
            () => new Widget(),
            static _ => true,
            maximumRetained: 0);

        Widget first = pool.Get();
        pool.Return(first);

        Assert.That(pool.Get(), Is.SameAs(first));
    }

    [Test]
    public void MaximumRetainedIsHonoured()
    {
        ObjectPool<Widget> pool = PoolFactory.CreatePool(
            () => new Widget(),
            static _ => true,
            maximumRetained: 1);

        Widget a = pool.Get();
        Widget b = pool.Get();
        pool.Return(a);
        pool.Return(b);

        // Only one can have been retained, so a third rent must produce something new.
        Widget first = pool.Get();
        Widget second = pool.Get();

        Assert.That(second, Is.Not.SameAs(first));
    }

    [Test]
    public void CreatePoolRejectsNullDelegates()
    {
        using (Assert.EnterMultipleScope())
        {
            Assert.That(() => PoolFactory.CreatePool<Widget>(null!, static _ => true),
                Throws.TypeOf<ArgumentNullException>());
            Assert.That(() => PoolFactory.CreatePool(() => new Widget(), null!),
                Throws.TypeOf<ArgumentNullException>());
        }
    }

#if NET6_0_OR_GREATER
    /// <summary>
    /// The case the factory exists for. Utf8JsonWriter is poolable — it is a sealed class with Reset
    /// overloads — but System.Text.Json is a package dependency on this library's older targets, so
    /// Memory must not reference it. Pooling one here, from the test assembly, is what shows the
    /// delegate form covers the scenario without that dependency.
    /// </summary>
    [Test]
    public void AUtf8JsonWriterCanBePooledWithoutMemoryReferencingSystemTextJson()
    {
        using var scratch = new ArrayPoolBufferWriter<byte>();

        ObjectPool<Utf8JsonWriter> pool = PoolFactory.CreatePool(
            () => new Utf8JsonWriter(scratch),
            writer => { writer.Reset(scratch); return true; });

        Utf8JsonWriter first = pool.Get();
        pool.Return(first);

        Utf8JsonWriter second = pool.Get();

        Assert.That(second, Is.SameAs(first), "the writer should be recycled across Reset");
    }

    /// <summary>
    /// End to end: a pooled JSON writer serialising into a pooled buffer writer, the payload leased
    /// so it outlives the scope, and read back with Utf8JsonReader straight off the sequence.
    /// </summary>
    [Test]
    public void PooledJsonWriterIntoPooledBufferWriterRoundTrips()
    {
        ObjectPool<Utf8JsonWriter> jsonPool = PoolFactory.CreatePool(
            () => new Utf8JsonWriter(Stream.Null),
            static writer => { writer.Reset(Stream.Null); return true; });

        SequenceLease<byte> payload;
        Utf8JsonWriter json = jsonPool.Get();
        try
        {
            // Deliberately not `using`: the lease takes over the writer's lifetime, and disposing it
            // here would release the very buffers the payload is made of.
            ArrayPoolBufferWriter<byte> buffer = ObjectPools.RentBufferWriter<byte>();
            json.Reset(buffer);

            json.WriteStartObject();
            json.WriteString("name", "cryptohives");
            json.WriteNumber("answer", 42);
            json.WriteEndObject();
            json.Flush();

            payload = buffer.LeaseSequence();
        }
        finally
        {
            jsonPool.Return(json);
        }

        using (payload)
        {
            var reader = new Utf8JsonReader(payload.Sequence);
            string text = Encoding.UTF8.GetString(payload.Sequence.ToArray());

            using (Assert.EnterMultipleScope())
            {
                Assert.That(text, Is.EqualTo("{\"name\":\"cryptohives\",\"answer\":42}"));
                Assert.That(reader.Read(), Is.True);
                Assert.That(reader.TokenType, Is.EqualTo(JsonTokenType.StartObject));
            }
        }
    }
#endif
}
