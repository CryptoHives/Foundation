# CryptoHives.Foundation Packages

Welcome to the CryptoHives.Foundation package documentation. This collection provides high-performance, allocation-efficient utilities for .NET applications.

## Available Packages

### Memory Package

**CryptoHives.Foundation.Memory** - High-performance pooled buffers and memory management

The Memory package provides allocation-efficient buffer management utilities that leverage `ArrayPool<T>` and modern .NET memory APIs to minimize garbage collection pressure.

**Key Features:**
- Pooled memory streams backed by `ArrayPool<byte>.Shared`
- Zero-copy APIs with `ReadOnlySequence<T>` and `Span<T>`
- `IBufferWriter<T>` implementations with pooled storage
- RAII pattern for safe object pool resource management

**[?? Memory Package Documentation](memory/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Memory
```

**Quick Example:**
```csharp
using CryptoHives.Foundation.Memory.Buffers;

// Use pooled memory stream
using var stream = new ArrayPoolMemoryStream();
stream.Write(data);
ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();
```

---

### Threading Package

**CryptoHives.Foundation.Threading** - Pooled async synchronization primitives

The Threading package provides high-performance async synchronization primitives optimized for low allocation and high throughput scenarios.

**Key Features:**
- Pooled `ValueTask`-based synchronization primitives
- Async mutual exclusion with `AsyncLock`
- Auto-reset and manual-reset async events
- Minimal allocation design for hot-path code

**[?? Threading Package Documentation](threading/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Threading
```

**Quick Example:**
```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

private readonly AsyncLock _lock = new();

public async Task AccessResourceAsync()
{
    using (await _lock.LockAsync())
    {
        // Thread-safe access to shared resource
    }
}
```

---

## Package Comparison

| Feature | Memory | Threading |
|---------|--------|-----------|
| **Focus** | Buffer management | Async coordination |
| **Key Benefit** | Reduced allocations | Low-latency synchronization |
| **Primary Use Case** | I/O, serialization, data processing | Concurrent async operations |
| **Pooling Strategy** | `ArrayPool<T>` | `ObjectPool<T>` with `ValueTask` |

## Target Frameworks

Both packages support:
- .NET 9.0
- .NET 8.0
- .NET Framework 4.8
- .NET Framework 4.6.2
- .NET Standard 2.1
- .NET Standard 2.0

## Common Use Cases

### High-Throughput Data Processing
Combine **Memory** for buffer management with **Threading** for coordinating concurrent processing:

```csharp
using CryptoHives.Foundation.Memory.Buffers;
using CryptoHives.Foundation.Threading.Async.Pooled;

public class DataProcessor
{
    private readonly AsyncLock _lock = new();
    
  public async Task<byte[]> ProcessAsync(Stream input)
    {
        using (await _lock.LockAsync())
        {
            using var buffer = new ArrayPoolMemoryStream();
            await input.CopyToAsync(buffer);
            return buffer.ToArray();
        }
    }
}
```

### Producer-Consumer Pipeline

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

public class Pipeline<T>
{
    private readonly AsyncAutoResetEvent _itemAvailable = new(false);
    private readonly Queue<T> _queue = new();
    
    public void Produce(T item)
    {
        _queue.Enqueue(item);
     _itemAvailable.Set();
    }
    
    public async Task<T> ConsumeAsync()
    {
        await _itemAvailable.WaitAsync();
        return _queue.Dequeue();
    }
}
```

## Getting Help

- ?? [Full Documentation](https://cryptohives.github.io/Foundation/)
- ?? [Getting Started Guide](../getting-started.md)
- ?? [API Reference](../api/index.md)
- ?? [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- ?? [Discussions](https://github.com/CryptoHives/Foundation/discussions)

## Package Links

| Package | NuGet | Documentation |
|---------|-------|---------------|
| CryptoHives.Foundation.Memory | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Memory) | [Docs](memory/index.md) |
| CryptoHives.Foundation.Threading | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) | [Docs](threading/index.md) |

---

© 2025 The Keepers of the CryptoHives
