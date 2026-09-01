# PoolFactory Class

Builds `ObjectPool<T>` instances, including for types this package does not reference.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Pools
```

## Syntax

```csharp
public static class PoolFactory
```

## Overview

Where [`ObjectPools`](objectpools.md) offers ready-made rent helpers for a handful of common types,
`PoolFactory` is the layer beneath: it creates the pools, and exposes a general-purpose
`CreatePool<T>` for anything else.

## Methods

### CreatePool

```csharp
public static ObjectPool<T> CreatePool<T>(
    Func<T> create,
    Func<T, bool> reset,
    int maximumRetained = 0) where T : class;
```

Creates a pool for any reference type from a pair of delegates.

| Parameter | Description |
|-----------|-------------|
| `create` | Produces a new instance when the pool is empty |
| `reset` | Restores an instance on return. Return `true` to keep it, `false` to reject it. |
| `maximumRetained` | Maximum instances to keep. Zero or less uses the default, which scales with the processor count. |

Throws `ArgumentNullException` when either delegate is `null`.

> [!WARNING]
> **A rejected instance is dropped, not disposed.** When `reset` returns `false` the pool simply lets
> the instance go. If `T` holds unmanaged or pooled resources, `reset` must dispose it before
> returning `false`, or those resources are never released.

### CreateBufferWriterPool

```csharp
public static ObjectPool<ArrayPoolBufferWriter<T>> CreateBufferWriterPool<T>(int maximumRetained = 0);
```

Creates a pool of [`ArrayPoolBufferWriter<T>`](arraypoolbufferwriter.md) instances.

The pool takes **no writer settings**: those are applied when a writer is rented, so instances in the
pool are interchangeable. Hand the returned pool to an
[`ArrayPoolBufferWriterProvider<T>`](arraypoolbufferwriterprovider.md) to rent from it.

Most callers do not need this — `SharedBufferWriterPool<T>()` is what every provider uses by default,
and sharing it is the point. Create a separate pool only to isolate a use case deliberately.

### SharedBufferWriterPool

```csharp
public static ObjectPool<ArrayPoolBufferWriter<T>> SharedBufferWriterPool<T>();
```

The shared pool for `T`, one per element type.

### CreateStringBuilderPool

```csharp
public static ObjectPool<StringBuilder> CreateStringBuilderPool(
    int maxCapacity = DefaultStringBuilderCapacity,
    int maxStringBuilderCapacity = DefaultMaxStringBuilderCapacity);
```

### SharedStringBuilderPool

```csharp
public static ObjectPool<StringBuilder> SharedStringBuilderPool { get; }
```

The pool behind [`ObjectPools.GetStringBuilder()`](objectpools.md).

## Constants

| Constant | Value | Description |
|----------|-------|-------------|
| `DefaultStringBuilderCapacity` | 1024 | Instances kept in the string builder pool |
| `DefaultMaxStringBuilderCapacity` | 8192 | Largest builder retained rather than discarded |
| `InitialStringBuilderCapacity` | 128 | Capacity a fresh builder starts with |

## Usage

### Pooling a type from another library

`CreatePool` exists so callers can pool types the Memory package deliberately does not reference.
`Utf8JsonWriter` is the motivating case: it is poolable — a sealed class with `Reset` overloads — but
`System.Text.Json` is a package dependency on this library's older targets, so Memory stays clear of
it.

```csharp
ObjectPool<Utf8JsonWriter> pool = PoolFactory.CreatePool(
    create: () => new Utf8JsonWriter(Stream.Null),
    reset:  writer => { writer.Reset(Stream.Null); return true; });

Utf8JsonWriter json = pool.Get();
try
{
    using var buffer = ObjectPools.RentBufferWriter<byte>();
    json.Reset(buffer);

    json.WriteStartObject();
    json.WriteString("name", "cryptohives");
    json.WriteEndObject();
    json.Flush();

    using SequenceLease<byte> payload = buffer.LeaseSequence();
    Send(payload.Sequence);
}
finally
{
    pool.Return(json);
}
```

Note that `Utf8JsonReader` cannot be pooled at all — it is a `ref struct`, so it is stack-only and
cannot be stored in a field. It needs no pooling either: it allocates nothing on the heap.

### Rejecting an instance that must not be reused

```csharp
ObjectPool<Session> pool = PoolFactory.CreatePool(
    create: () => new Session(),
    reset:  session =>
    {
        if (session.IsFaulted)
        {
            session.Dispose();   // the pool will not do this for you
            return false;
        }

        session.Clear();
        return true;
    });
```

### Pairing a pool with an object owner

```csharp
ObjectPool<MyClass> pool = PoolFactory.CreatePool(
    () => new MyClass(),
    obj => { obj.Clear(); return true; });

using var owner = new ObjectOwner<MyClass>(pool);
MyClass obj = owner.PooledObject;
```

## Thread Safety

**Thread-safe.** The pools returned are safe for concurrent use; the instances they hand out
generally are not.

## See Also

- [ObjectPools](objectpools.md)
- [ObjectOwner&lt;T&gt;](objectowner.md)
- [ArrayPoolBufferWriterProvider&lt;T&gt;](arraypoolbufferwriterprovider.md)
- [ObjectPool&lt;T&gt; Documentation](https://learn.microsoft.com/dotnet/api/microsoft.extensions.objectpool.objectpool-1)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
