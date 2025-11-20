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

## Usage Examples

### Basic StringBuilder Usage

```csharp
using CryptoHives.Foundation.Memory.Pools;

using var owner = ObjectPools.GetStringBuilder();
StringBuilder sb = owner.Object;

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
    StringBuilder sb = owner.Object;
    
    sb.Append("Name: ");
    sb.Append(name);
    sb.Append(", Email: ");
    sb.Append(email);
    
    return sb.ToString();
}
```

### URL Building

```csharp
public string BuildUrl(string baseUrl, Dictionary<string, string> parameters)
{
    using var owner = ObjectPools.GetStringBuilder();
    StringBuilder sb = owner.Object;
    
    sb.Append(baseUrl);
    
 if (parameters.Count > 0)
    {
        sb.Append('?');
        bool first = true;
        
        foreach (var param in parameters)
        {
         if (!first) sb.Append('&');
            
  sb.Append(Uri.EscapeDataString(param.Key));
    sb.Append('=');
    sb.Append(Uri.EscapeDataString(param.Value));
            
 first = false;
   }
    }
    
    return sb.ToString();
}
```

### Logging

```csharp
public void LogMessage(string category, LogLevel level, string message)
{
    using var owner = ObjectPools.GetStringBuilder();
    StringBuilder sb = owner.Object;
    
    sb.Append('[');
    sb.Append(DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"));
    sb.Append("] ");
    sb.Append(level.ToString());
  sb.Append(" [");
    sb.Append(category);
    sb.Append("]: ");
    sb.Append(message);
    
    Console.WriteLine(sb.ToString());
}
```

## Configuration

The shared `StringBuilder` pool uses the following default settings:

- **Initial Capacity**: 128 characters
- **Maximum Retained Capacity**: 1024 characters
- **Pool Size**: Recommended 1024 instances (may vary based on implementation)

Instances that exceed the maximum retained capacity are not returned to the pool.

## Thread Safety

? **Thread-safe**. The underlying pool is thread-safe, and `ObjectOwner<StringBuilder>` can be used concurrently across threads (each thread gets its own owner instance).

## Best Practices

### ? DO: Use for Temporary String Building

```csharp
// Good: Temporary string construction
using var owner = ObjectPools.GetStringBuilder();
StringBuilder sb = owner.Object;
sb.Append("Temporary data");
return sb.ToString();
```

### ? DO: Use in Loops

```csharp
// Good: Reusing pool across iterations
for (int i = 0; i < 1000; i++)
{
    using var owner = ObjectPools.GetStringBuilder();
    StringBuilder sb = owner.Object;
    
    sb.Append("Item ");
    sb.Append(i);
    
    ProcessString(sb.ToString());
}
```

### ? DON'T: Use for Single Concatenation

```csharp
// Bad: Overhead not worth it
using var owner = ObjectPools.GetStringBuilder();
string result = owner.Object.Append("Hello").ToString();

// Better: Just use string
string result = "Hello";
```

### ? DON'T: Use for Long-Lived Instances

```csharp
// Bad: Holding pooled object too long
var owner = ObjectPools.GetStringBuilder();
_cachedBuilder = owner.Object; // Don't store pooled objects!
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
  StringBuilder sb = owner.Object;
    sb.Append("Item ");
    sb.Append(i);
    Process(sb.ToString());
}
```

### vs. Direct Pool Usage

```csharp
// Direct pool usage (manual)
var pool = new DefaultObjectPool<StringBuilder>(policy);
var sb = pool.Get();
try
{
    sb.Append("Data");
    return sb.ToString();
}
finally
{
    pool.Return(sb);
}

// ObjectPools helper (automatic)
using var owner = ObjectPools.GetStringBuilder();
StringBuilder sb = owner.Object;
sb.Append("Data");
return sb.ToString();
```

## Integration Examples

### ASP.NET Core

```csharp
public class MyController : ControllerBase
{
    [HttpGet]
    public IActionResult FormatResponse(string[] items)
    {
        using var owner = ObjectPools.GetStringBuilder();
        StringBuilder sb = owner.Object;
        
    foreach (var item in items)
 {
      sb.Append(item);
            sb.Append(';');
        }
    
        return Ok(sb.ToString().TrimEnd(';'));
    }
}
```

### Logging Provider

```csharp
public class PooledLogger : ILogger
{
    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception exception,
        Func<TState, Exception, string> formatter)
    {
        using var owner = ObjectPools.GetStringBuilder();
      StringBuilder sb = owner.Object;
        
        sb.Append('[');
        sb.Append(logLevel.ToString());
        sb.Append("] ");
        sb.Append(formatter(state, exception));
   
      if (exception != null)
        {
 sb.AppendLine();
      sb.Append(exception);
        }
  
        Console.WriteLine(sb.ToString());
    }
}
```

## Extension Points

While `ObjectPools` currently only provides `GetStringBuilder()`, the pattern can be extended:

```csharp
// Future extension example
public static class MyObjectPools
{
  public static ObjectOwner<List<T>> GetList<T>() => 
        new ObjectOwner<List<T>>(SharedListPool<T>.Instance);
    
    public static ObjectOwner<Dictionary<TKey, TValue>> GetDictionary<TKey, TValue>() =>
        new ObjectOwner<Dictionary<TKey, TValue>>(SharedDictionaryPool<TKey, TValue>.Instance);
}
```

## See Also

- [ObjectOwner&lt;T&gt;](objectowner.md)
- [StringBuilder Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.text.stringbuilder)
- [ObjectPool&lt;T&gt; Documentation](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.objectpool.objectpool-1)
- [Memory Package Overview](index.md)

---

© 2025 The Keepers of the CryptoHives
