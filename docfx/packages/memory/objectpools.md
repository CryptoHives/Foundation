# ObjectPools Class

Static helper class for obtaining pooled objects with automatic return to pool.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Pools
```

## Inheritance

`Object` ? **`ObjectPools`**

## Syntax

```csharp
public static class ObjectPools
```

## Overview

`ObjectPools` provides convenient static methods for obtaining commonly-used pooled objects wrapped in `ObjectOwner<T>` for automatic cleanup. This eliminates the need to manually manage object pool instances for standard types.

## Methods

### GetStringBuilder

```csharp
public static ObjectOwner<StringBuilder> GetStringBuilder()
```

Gets a pooled `StringBuilder` instance wrapped in an `ObjectOwner<StringBuilder>`.

**Returns**: An `ObjectOwner<StringBuilder>` that will return the `StringBuilder` to the pool when disposed.

**Remarks**: The returned `StringBuilder` is cleared before being returned to the pool. The initial capacity is 128 characters, and instances up to 1024 characters are retained in the pool.

### RentBufferWriter

```csharp
public static ArrayPoolBufferWriter<T> RentBufferWriter<T>()
```

Rents an [`ArrayPoolBufferWriter<T>`](arraypoolbufferwriter.md) with default settings from the shared
pool for its element type.

**Returns**: A writer in its just-constructed state.

**Remarks**: No `ObjectOwner<T>` wrapper is needed here, unlike `GetStringBuilder`, because the writer
is disposable in its own right — disposing it returns it to the pool. For anything other than the
default settings, declare an [`ArrayPoolBufferWriterProvider<T>`](arraypoolbufferwriterprovider.md)
once and rent from it; it draws from this same pool, so configuring a use case costs no extra
instances.

```csharp
using var writer = ObjectPools.RentBufferWriter<byte>();

data.CopyTo(writer.GetSpan(data.Length));
writer.Advance(data.Length);

Consume(writer.GetReadOnlySequence());   // borrowed, valid in this scope
```

> [!WARNING]
> Do not use the writer after disposing it. A returned instance does not throw
> `ObjectDisposedException`; it silently becomes whatever the next renter is doing.

## Usage Examples

### Basic StringBuilder Usage

```csharp
using CryptoHives.Foundation.Memory.Pools;

using var owner = ObjectPools.GetStringBuilder();
StringBuilder sb = owner.PooledObject;

sb.Append("Hello");
sb.Append(" World");

string result = sb.ToString();
// StringBuilder automatically cleared and returned to pool
```

### String Formatting

```csharp
public string FormatMessage(string name, string email)
{
    using var owner = ObjectPools.GetStringBuilder();
    StringBuilder sb = owner.PooledObject;
    
    sb.Append("Name: ");
    sb.Append(name);
    sb.Append(", Email: ");
    sb.Append(email);
    
    return sb.ToString();
}
```


## Configuration

The shared `StringBuilder` pool uses the following default settings:

- **Initial capacity of a new builder**: 128 characters
- **Largest builder still worth keeping**: 1024 characters — one that has grown past this is discarded on return rather than pooled
- **Builders retained**: up to 1024, a recommendation rather than a hard cap

> [!NOTE]
> Nothing in these pools is released under memory pressure. `DefaultObjectPool<T>` drops an instance
> only when its policy rejects one or the pool is already full on return, so a pool that has filled up
> stays filled for the life of the process. The rented arrays behind
> [`ArrayPoolBufferWriter<T>`](arraypoolbufferwriter.md) are a separate matter — those come from
> `ArrayPool<T>.Shared`, which registers a gen-2 GC callback and trims itself according to memory
> pressure.

## Thread Safety

? **Thread-safe**. The underlying pool is thread-safe, and `ObjectOwner<StringBuilder>` can be used concurrently across threads (each thread gets its own owner instance).

## Best Practices

### DO: Use for Temporary String Building

```csharp
// Good: Temporary string construction
using var owner = ObjectPools.GetStringBuilder();
StringBuilder sb = owner.PooledObject;
sb.Append("Temporary data");
return sb.ToString();
```

### DO: Use in Loops

```csharp
// Good: Reusing pool across iterations
for (int i = 0; i < 1000; i++)
{
    using var owner = ObjectPools.GetStringBuilder();
    StringBuilder sb = owner.PooledObject;
    
    sb.Append("Item ");
    sb.Append(i);
    
    ProcessString(sb.ToString());
}
```

### DON'T: Use for Single Concatenation

```csharp
// Bad: Overhead not worth it
using var owner = ObjectPools.GetStringBuilder();
string result = owner.PooledObject.Append("Hello").ToString();

// Better: Just use string
string result = "Hello";
```

### DON'T: Use for Long-Lived Instances

```csharp
// Bad: Holding pooled object too long
var owner = ObjectPools.GetStringBuilder();
_cachedBuilder = owner.PooledObject; // Don't store pooled objects!
```

## Performance Characteristics

- **Get Operation**: O(1) - retrieves from pool
- **Return Operation**: O(1) - returns to pool (on dispose)
- **Memory**: Zero allocations when pool has available instances

## Comparison with Alternatives

### vs. New Instance Every Time

```csharp
// Without pooling
for (int i = 0; i < 1000; i++)
{
    var sb = new StringBuilder(); // 1000 allocations
    sb.Append("Item ");
    sb.Append(i);
    Process(sb.ToString());
}

// With pooling
for (int i = 0; i < 1000; i++)
{
    using var owner = ObjectPools.GetStringBuilder(); // Reuses instances
    StringBuilder sb = owner.PooledObject;
    sb.Append("Item ");
    sb.Append(i);
    Process(sb.ToString());
}
```

## Extension Points

`ObjectPools` covers a couple of common cases. For anything else, build a pool with
[`PoolFactory.CreatePool<T>`](poolfactory.md) and pair it with an
[`ObjectOwner<T>`](objectowner.md):

```csharp
public static class MyObjectPools
{
    private static readonly ObjectPool<List<int>> _lists = PoolFactory.CreatePool(
        create: () => new List<int>(),
        reset:  list => { list.Clear(); return true; });

    public static ObjectOwner<List<int>> GetList() => new(_lists);
}

using var owner = MyObjectPools.GetList();
List<int> list = owner.PooledObject;
```

`CreatePool` is also how you pool a type this package deliberately does not reference — a
`Utf8JsonWriter`, for instance. See [PoolFactory](poolfactory.md).

## See Also

- [ObjectOwner&lt;T&gt;](objectowner.md)
- [PoolFactory](poolfactory.md)
- [ArrayPoolBufferWriterProvider&lt;T&gt;](arraypoolbufferwriterprovider.md)
- [StringBuilder Documentation](https://learn.microsoft.com/dotnet/api/system.text.stringbuilder)
- [ObjectPool&lt;T&gt; Documentation](https://learn.microsoft.com/dotnet/api/microsoft.extensions.objectpool.objectpool-1)
- [Memory Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
