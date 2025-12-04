# CryptoHives .NET Foundation Packages

Welcome to the CryptoHives .NET Foundation package documentation. 

## Available Packages

### Memory Package

**CryptoHives.Foundation.Memory** - Pooled buffers and memory management

High-performance buffer management and memory streams backed by `ArrayPool<T>.Shared` for reduced allocations and GC pressure.

**Key Features:**
- `ArrayPoolMemoryStream` - Memory stream using pooled buffers (read/write)
- `ArrayPoolBufferWriter<T>` - IBufferWriter implementation with pooled buffers
- `ReadOnlySequenceMemoryStream` - Stream wrapper to read from ReadOnlySequence
- `ObjectOwner<T>` - [RAII](https://en.wikipedia.org/wiki/Resource_acquisition_is_initialization) pattern for object pool management

**[Memory Package Documentation](memory/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Memory
```

**Quick Example:**
```csharp
using CryptoHives.Foundation.Memory.Buffers;

// Use lifetime managed pooled memory stream
using var stream = new ArrayPoolMemoryStream();
stream.Write(data);

// sequence becomes invalid when stream is disposed
ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();
```

---

### Threading Package

**CryptoHives.Foundation.Threading** - Pooled async synchronization primitives

Pooled async synchronization primitives that reduce allocations in high-throughput scenarios.

**Key Features:**
- `AsyncLock` - Pooled async mutual exclusion
- `AsyncAutoResetEvent` - Pooled async auto-reset event
- `AsyncManualResetEvent` - Pooled async manual-reset event

**[Threading Package Documentation](threading/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Threading
```

**Quick Example:**
```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

private readonly AsyncLock _lock = new();

public async Task AccessResourceAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct))
    {
        // Thread-safe async access to shared resource
    }
}
```

---

## Target Frameworks

Both packages support:
- .NET 10.0
- .NET 8.0
- .NET Framework 4.6.2
- .NET Standard 2.1
- .NET Standard 2.0

## Getting Help

- 📖 [Full Documentation](https://cryptohives.github.io/Foundation/)
- 🚀 [Getting Started Guide](../getting-started.md)
- 📚 [API Reference](../api/index.md)
- 🐛 [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- 💬 [Discussions](https://github.com/CryptoHives/Foundation/discussions)

## Package Links

| Package | NuGet | Documentation |
|---------|-------|---------------|
| CryptoHives.Foundation.Memory | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Memory) | [Docs](memory/index.md) |
| CryptoHives.Foundation.Threading | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) | [Docs](threading/index.md) |

---

© 2025 The Keepers of the CryptoHives
