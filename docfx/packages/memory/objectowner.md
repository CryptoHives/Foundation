# ObjectOwner&lt;T&gt; Struct

A RAII (Resource Acquisition Is Initialization) wrapper for objects obtained from `ObjectPool<T>`.

**Namespace:** `CryptoHives.Foundation.Memory.Pools` · [API reference](xref:CryptoHives.Foundation.Memory.Pools.ObjectOwner%601)

## Overview

The constructor rents an object from the pool, `PooledObject` exposes it, and `Dispose` gives it back. Declare it with `using var` and keep it local: it is a struct, so casting it to `IDisposable` boxes it, and a copy that is also disposed returns the same object to the pool twice.

## Usage Examples

### Basic Usage

```csharp
using Microsoft.Extensions.ObjectPool;

var pool = new DefaultObjectPool<StringBuilder>(
    new DefaultPooledObjectPolicy<StringBuilder>()
);

using var owner = new ObjectOwner<StringBuilder>(pool);
StringBuilder sb = owner.PooledObject;

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
StringBuilder sb = owner.PooledObject;
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
    List<int> list = owner.PooledObject;
    
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

**Thread-safe** when used correctly (one owner per instance). The pool itself handles thread-safety.

## Best Practices

### Use with `using` statement

```csharp
using var owner = new ObjectOwner<StringBuilder>(pool);
StringBuilder sb = owner.PooledObject;
// Use sb...
// Automatically returned to pool
```

### Keep scope minimal

```csharp
string result;

using (var owner = new ObjectOwner<StringBuilder>(pool))
{
    StringBuilder sb = owner.PooledObject;
    sb.Append("Data");
    result = sb.ToString();
} // Pool object returned here

return result;
```

### Don't store in fields

```csharp
// Wrong!
public class BadExample
{
    private ObjectOwner<StringBuilder> _owner; // Don't do this!
}
```

### Don't return the pooled object

```csharp
// Wrong!
public StringBuilder GetStringBuilder()
{
    using var owner = new ObjectOwner<StringBuilder>(pool);
    return owner.PooledObject; // Object will be returned to pool!
}

// Correct: Return the result
public string GetString()
{
    using var owner = new ObjectOwner<StringBuilder>(pool);
    return owner.PooledObject.ToString();
}
```

### Don't box the struct

```csharp
// Wrong!
IDisposable disposable = new ObjectOwner<StringBuilder>(pool); // Boxing!

// Correct:
using var owner = new ObjectOwner<StringBuilder>(pool);
```

### Don't copy the struct

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
    StringBuilder sb = owner.PooledObject;
    
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
    List<int> list = owner.PooledObject;
    
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
    MemoryStream stream = owner.PooledObject;
    
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
T obj = owner.PooledObject;
// Use obj...
```

## See Also

- [ObjectPools](objectpools.md)
- [ObjectPool&lt;T&gt; Documentation](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.objectpool.objectpool-1)
- [Memory Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
