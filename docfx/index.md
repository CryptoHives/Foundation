---
_layout: landing
---

# CryptoHives .NET Foundation

Welcome to the **CryptoHives .NET Foundation** documentation!

## Overview

The CryptoHives .NET Foundation provides libraries for .NET applications focusing on high performance memory management, threading primitives, and cryptographic algorithms.

## Available Packages

### 💾 [Memory Package](packages/memory/index.md)

The Memory package provides allocation-efficient buffer management utilities that leverage `ArrayPool<T>` and modern .NET memory APIs to minimize garbage collection pressure for transformation pipelines and cryptographic workloads.

**Key Features:**
- `ArrayPoolMemoryStream` and `ArrayPoolBufferWriter<T>` classes backed by `ArrayPool<byte>.Shared`
- Lifetime managed `ReadOnlySequence<byte>` support with pooled storage
- `ReadOnlySequenceMemoryStream` to stream from `ReadOnlySequence<byte>`
- `ObjectPool` backed resource management helpers, e.g. for `StringBuilder`

[Explore Memory Package](packages/memory/index.md)

### 🔄 [Threading Package](packages/threading/index.md)

The Threading package provides high-performance async synchronization primitives optimized for low allocation and high throughput scenarios.

**Key Features:**
- All waiters implemented as `ValueTask`-based synchronization primitives with low memory allocation design
- Built-in Roslyn analyzers to detect common `ValueTask` misuse patterns at compile time
- Full `CancellationToken` support in all Wait/Lock primitives 
- Implementations use `IValueTaskSource<T>` based classes backed by `ObjectPool<T>` to avoid allocations by recycling waiter objects
- Async mutual exclusion with `AsyncLock` and scoped locking via `IDisposable` pattern
- `AsyncAutoResetEvent` and `AsyncManualResetEvent` complementing existing implementations which are `Task` based
- Replacement for .NET barriers with `AsyncBarrier` supporting async waits
- Pooled implementations of `AsyncReaderWriterLock`, `AsyncSemaphore` and `AsyncCountdownEvent` with async wait support
- Fast path optimizations for uncontended scenarios
- No allocation design for hot-path code and cancellation tokens (see [Benchmarks](packages/threading/benchmarks.md))
- [Benchmarks](packages/threading/benchmarks.md) comparing performance against existing .NET synchronization primitives and various other popular implementations

[Explore Threading Package](packages/threading/index.md)

### 🔐 [Security.Cryptography Package](packages/security/cryptography/index.md)

The Cryptography package provides clean-room implementations of cryptographic hash algorithms and message authentication codes (MACs), all implemented as fully managed code without OS dependencies.

> **Note:** This package is currently in development and not yet published to NuGet.

**Key Features:**
- SHA-1, SHA-2, SHA-3 family implementations with full test vector validation
- SHAKE and cSHAKE extendable-output functions (XOF) for variable-length output
- KMAC (Keccak Message Authentication Code) for authenticated hashing
- BLAKE2b, BLAKE2s, and BLAKE3 high-performance hashing with keyed modes
- Keccak-256 for Ethereum compatibility
- International standards: SM3 (Chinese), Streebog/GOST (Russian), Whirlpool (ISO)
- Legacy algorithms: MD5, SHA-1, RIPEMD-160 (for compatibility only)
- Cross-platform consistency without OS crypto API dependencies

[Explore Security.Cryptography Package](packages/security/cryptography/index.md)

## Quick Start

Get started in minutes:

1. [Install the packages](getting-started.md#installation)
2. [Browse the Package Documentation](packages/index.md)

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

public async Task DoWorkAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct))
    {
        // Protected critical section
    }
}
```

### Cryptography Example

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;
using CryptoHives.Foundation.Security.Cryptography.Mac;

// SHA-256 hash (drop-in replacement for System.Security.Cryptography)
using var sha256 = SHA256.Create();
byte[] hash = sha256.ComputeHash(data);

// SHA3-256 hash
using var sha3 = SHA3_256.Create();
byte[] sha3Hash = sha3.ComputeHash(data);

// BLAKE3 with variable output length
using var blake3 = Blake3.Create(outputBytes: 64);
byte[] longHash = blake3.ComputeHash(data);

// KMAC256 for authenticated hashing
byte[] key = new byte[32];
using var kmac = Kmac256.Create(key, outputBytes: 64, customization: "MyApp");
byte[] mac = kmac.ComputeHash(message);
```

## Platform Support

- .NET 10.0
- .NET 8.0
- .NET Framework 4.6.2
- .NET Framework 4.8
- .NET Standard 2.1
- .NET Standard 2.0

## Resources

- 🚀 [Getting Started Guide](getting-started.md)
- 📦 [Package Documentation](packages/index.md)
- 🔐 [Cryptographic Specifications](packages/security/cryptography/specs/README.md)
- 🐛 [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- 💬 [Security Policy](https://github.com/CryptoHives/.github/blob/main/SECURITY.md)

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/CryptoHives/Foundation/blob/main/LICENSE) file for details.

---

[Impressum (Legal Notice)](impressum.md)

© 2026 The Keepers of the CryptoHives
