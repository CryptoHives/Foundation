---
_layout: landing
---

# CryptoHives .NET Foundation

Welcome to the **CryptoHives .NET Foundation** documentation!

## Overview

The CryptoHives .NET Foundation provides libraries for .NET applications focusing on memory management and threading primitives.

## Available Packages

### 💾 [Memory Package](packages/memory/index.md)

The Memory package provides allocation-efficient buffer management utilities that leverage `ArrayPool<T>` and modern .NET memory APIs to minimize garbage collection pressure for transformation pipelines and cryptographic workloads.

**Key Features:**
- `ArrayPoolMemoryStream` and `ArrayPoolBufferWriter<T>` classes backed by `ArrayPool<byte>.Shared`
- Lifetime managed `ReadOnlySequence<byte>` support with pooled storage
- `ReadOnlySequenceMemoryStream` to stream from `ReadOnlySequence<byte>`
- `ObjectPool` backed resource management helpers

[Explore Memory Package](packages/memory/index.md)

### 🔄 [Threading Package](packages/threading/index.md)

The Threading package provides high-performance async synchronization primitives optimized for low allocation and high throughput scenarios.

**Key Features:**
- All waiters implemented as `ValueTask`-based synchronization primitives with zero memory allocation design
- Implementations use `IValueTaskSource<T>` based classes backed by `ObjectPool<T>` to avoid allocations by recycling waiter objects
- Async mutual exclusion with `AsyncLock` and scoped locking via `IDisposable` pattern
- `AsyncAutoResetEvent` and `AsyncManualResetEvent` complementing existing implementations which are `Task` based
- Minimal allocation design for hot-path code
- Fast path optimizations for uncontended scenarios
- Benchmarks comparing performance against existing .NET synchronization primitives and various popular implementations

[Explore Threading Package](packages/threading/index.md)

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

// Get zero-copy access to the data until stream is disposed
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

- .NET 10.0 (planned)
- .NET 9.0
- .NET 8.0
- .NET Framework 4.8
- .NET Framework 4.6.2
- .NET Standard 2.1
- .NET Standard 2.0

## Resources

- 🚀 [Getting Started Guide](getting-started.md)
- 📦 [Package Documentation](packages/index.md)
- 📚 [API Reference](api/index.md)
- 🐛 [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- 💬 [Security Policy](https://github.com/CryptoHives/.github/blob/main/SECURITY.md)

## License

MIT License - © 2025 The Keepers of the CryptoHives

[View License](https://github.com/CryptoHives/Foundation/blob/main/LICENSE)