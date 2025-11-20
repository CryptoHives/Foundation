# ObjectOwner&lt;T&gt; Struct

A RAII (Resource Acquisition Is Initialization) wrapper for objects obtained from `ObjectPool<T>`.

## Namespace

```csharp
CryptoHives.Foundation.Memory.Pools
```

## Inheritance

`ValueType` ? **`ObjectOwner<T>`**

## Implements

- `IDisposable`

## Syntax

```csharp
public readonly struct ObjectOwner<T> : IDisposable where T : class
```

## Type Parameters

**`T`** - The type of object being pooled. Must be a reference type.

## Overview

`ObjectOwner<T>` provides automatic return of pooled objects to their pool using the RAII pattern. When disposed, it automatically returns the object to the pool. This struct should be used with the `using` statement to ensure proper disposal.

## ?? Important Warnings

- **This is a struct** - Avoid boxing by not casting to `IDisposable`
- **Use with `using`** - Always use in a `using` statement or block
- **Don't store in fields** - Keep in local scope only
- **Don't copy** - The struct will be copied, causing double-returns to pool

## Properties

| Property | Type | Description |
|----------|------|-------------|
| `Object` | `T` | The pooled object obtained from the pool |

## Constructors

| Constructor | Description |
|-------------|-------------|
| `ObjectOwner(ObjectPool<T> objectPool)` | Creates an owner by getting an object from the specified pool |

## Methods

```csharp
public void Dispose()
```
Returns the object to the pool. Called automatically when used with `using`.

## Usage Examples

### Basic Usage

```csharp
using Microsoft.Extensions.ObjectPool;

var pool = new DefaultObjectPool<StringBuilder>(
    new DefaultPooledObjectPolicy<StringBuilder>()
);

using var owner = new ObjectOwner<StringBuilder>(pool);
StringBuilder sb = owner.Object;

sb.Append("Hello");
sb.Append(" World");

Console.WriteLine(sb.ToString());
// StringBuilder automatically returned to pool when owner disposes
```

### With Custom Pool Policy

```csharp
public class StringBuilderPolicy : IPooledObjectPolicy<StringBuilder>
{
    public StringBuilder Create() => new StringBuilder();
    
    public bool Return(StringBuilder obj)
    {
        obj.Clear();
        return true;
    }
}

var pool = new DefaultObjectPool<StringBuilder>(new StringBuilderPolicy());

using var owner = new ObjectOwner<StringBuilder>(pool);
StringBuilder sb = owner.Object;
// Use sb...
```

### Processing Collections

```csharp
public List<int> ProcessData(IEnumerable<int> items)
{
    var pool = new DefaultObjectPool<List<int>>(
        new ListPolicy<int>()
    );
    
    using var owner = new ObjectOwner<List<int>>(pool);
    List<int> list = owner.Object;
    
    foreach (int item in items)
    {
        if (item > 0)
        {
      list.Add(item);
        }
    }
    
    return new List<int>(list); // Return a copy, not the pooled list
}
```

## Thread Safety

? **Thread-safe** when used correctly (one owner per thread). The pool itself handles thread-safety.

## Best Practices

### ? DO: Use with `using` Statement

```csharp
using var owner = new ObjectOwner<StringBuilder>(pool);
StringBuilder sb = owner.Object;
// Use sb...
// Automatically returned to pool
```

### ? DO: Keep Scope Minimal

```csharp
string result;

using (var owner = new ObjectOwner<StringBuilder>(pool))
{
    StringBuilder sb = owner.Object;
    sb.Append("Data");
    result = sb.ToString();
} // Pool object returned here

return result;
```

### ? DON'T: Store in Fields

```csharp
// Wrong!
public class BadExample
{
    private ObjectOwner<StringBuilder> _owner; // Don't do this!
}
```

### ? DON'T: Return the Pooled Object

```csharp
// Wrong!
public StringBuilder GetStringBuilder()
{
    using var owner = new ObjectOwner<StringBuilder>(pool);
    return owner.Object; // Object will be returned to pool!
}

// Correct: Return the result
public string GetString()
{
    using var owner = new ObjectOwner<StringBuilder>(pool);
    return owner.Object.ToString();
}
```

### ? DON'T: Box the Struct

```csharp
// Wrong!
IDisposable disposable = new ObjectOwner<StringBuilder>(pool); // Boxing!

// Correct:
using var owner = new ObjectOwner<StringBuilder>(pool);
```

### ? DON'T: Copy the Struct

```csharp
// Wrong!
var owner1 = new ObjectOwner<StringBuilder>(pool);
var owner2 = owner1; // Copy! Both will try to return to pool
owner1.Dispose();
owner2.Dispose(); // Double return!

// Correct: Use once
using var owner = new ObjectOwner<StringBuilder>(pool);
```

## Common Use Cases

### Temporary String Building

```csharp
public string FormatData(params object[] values)
{
    using var owner = new ObjectOwner<StringBuilder>(stringBuilderPool);
    StringBuilder sb = owner.Object;
    
    foreach (var value in values)
    {
        sb.Append(value);
      sb.Append(' ');
    }
    
    return sb.ToString().TrimEnd();
}
```

### Temporary Collections

```csharp
public int[] FilterPositive(int[] values)
{
    using var owner = new ObjectOwner<List<int>>(listPool);
    List<int> list = owner.Object;
    
    foreach (int value in values)
  {
        if (value > 0)
        {
            list.Add(value);
        }
    }
    
    return list.ToArray();
}
```

### Temporary Buffers

```csharp
public byte[] ProcessData(byte[] input)
{
    using var owner = new ObjectOwner<MemoryStream>(streamPool);
    MemoryStream stream = owner.Object;
    
    stream.Write(input, 0, input.Length);
    // Process stream...
    
 return stream.ToArray();
}
```

## Performance Characteristics

- **Construction**: O(1) - gets object from pool
- **Disposal**: O(1) - returns object to pool
- **Memory**: No heap allocation (struct, no boxing)

## Remarks

### Why a Struct?

`ObjectOwner<T>` is a struct to avoid heap allocation. When used correctly with `using`, it provides zero-allocation resource management.

### Comparison with Direct Pool Usage

```csharp
// Without ObjectOwner (error-prone)
var obj = pool.Get();
try
{
    // Use obj...
}
finally
{
    pool.Return(obj);
}

// With ObjectOwner (safer, cleaner)
using var owner = new ObjectOwner<T>(pool);
T obj = owner.Object;
// Use obj...
```

## See Also

- [ObjectPools](objectpools.md)
- [ObjectPool&lt;T&gt; Documentation](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.objectpool.objectpool-1)
- [Memory Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
