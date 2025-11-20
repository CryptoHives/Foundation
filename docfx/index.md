---
_layout: landing
---

# CryptoHives .NET Foundation

Welcome to the **CryptoHives .NET Foundation** documentation!

## Overview

The CryptoHives .NET Foundation provides high-performance, low-allocation libraries for .NET applications focusing on memory management and threading primitives.

## Available Packages

### ?? [Memory Package](packages/memory/index.md)

High-performance buffer management and memory streams backed by `ArrayPool<T>` for reduced allocations and GC pressure.

**Key Features:**
- `ArrayPoolMemoryStream` - Memory stream using pooled buffers
- `ArrayPoolBufferWriter<T>` - IBufferWriter implementation with pooled buffers
- `ReadOnlySequenceMemoryStream` - Stream wrapper for ReadOnlySequence
- `ObjectOwner<T>` - RAII pattern for object pool management

[Explore Memory Package ?](packages/memory/index.md)

### ?? [Threading Package](packages/threading/index.md)

Pooled async synchronization primitives that reduce allocations in high-throughput scenarios.

**Key Features:**
- `AsyncLock` - Pooled async mutual exclusion
- `AsyncAutoResetEvent` - Pooled async auto-reset event
- `AsyncManualResetEvent` - Pooled async manual-reset event

[Explore Threading Package ?](packages/threading/index.md)

## Quick Start

Get started in minutes:

1. [Install the packages](getting-started.md#installation)
3. [Browse the API documentation](api/index.md)

## Sample Code

### Memory Example

```csharp
using CryptoHives.Foundation.Memory.Buffers;
using System.Buffers;

// Use ArrayPoolMemoryStream for low-allocation I/O
using var stream = new ArrayPoolMemoryStream();
await stream.WriteAsync(data);

// Get zero-copy access to the data
ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();
```

### Threading Example

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

// Pooled async lock reduces allocations
private readonly AsyncLock _lock = new AsyncLock();

public async Task DoWorkAsync()
{
  using (await _lock.LockAsync())
    {
        // Protected critical section
    }
}
```

## Platform Support

- ? .NET 9.0
- ? .NET 8.0
- ? .NET Framework 4.8
- ? .NET Framework 4.6.2
- ? .NET Standard 2.1
- ? .NET Standard 2.0

## Resources

- ?? [Getting Started Guide](getting-started.md)
- ?? [Package Documentation](packages/memory/index.md)
- ?? [Code Samples](samples/memory/index.md)
- ?? [API Reference](api/index.md)
- ?? [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- ?? [Security Policy](../SECURITY.md)

## License

MIT License - © 2025 The Keepers of the CryptoHives

[View License](../LICENSE)