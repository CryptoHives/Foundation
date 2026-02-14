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

The Cryptography package provides specification-based implementations of cryptographic hash algorithms and message authentication codes (MACs), all implemented as fully managed code without OS dependencies.

> **Note:** This package is currently in development and yet contains only hash and MAC algorithms.

**Key Features:**
- SHA-1, SHA-2, SHA-3 family implementations with full test vector validation
- SHAKE and cSHAKE extendable-output functions (XOF) for variable-length output
- TurboSHAKE and KangarooTwelve (KT128/KT256) high-performance XOFs
- KMAC (Keccak Message Authentication Code) for authenticated hashing
- Ascon lightweight hashing (NIST FIPS 207) for constrained environments
- BLAKE2b, BLAKE2s, and BLAKE3 high-performance hashing with keyed modes
- Keccak-256, Keccak-384, Keccak-512 for Ethereum compatibility
- International standards: SM3 (Chinese), Streebog/GOST (Russian), Kupyna/DSTU (Ukrainian), LSH/KS (Korean), Whirlpool (ISO)
- Legacy algorithms: MD5, SHA-1, RIPEMD-160 (for compatibility only)
- Cross-platform consistency without OS crypto API dependencies

[Explore Security.Cryptography Package](packages/security/cryptography/index.md)

## Quick Start

Each package page includes installation, quick-start examples, and API documentation:

1. [Memory Package](packages/memory/index.md) — pooled buffers and streams
2. [Threading Package](packages/threading/index.md) — async synchronization primitives
3. [Security.Cryptography Package](packages/security/cryptography/index.md) — hash algorithms and MACs

## Platform Support

- .NET 10.0
- .NET 8.0
- .NET Framework 4.6.2
- .NET Standard 2.1
- .NET Standard 2.0

## Resources

- 🔐 [Cryptographic Specifications](packages/security/cryptography/specs/README.md)
- 🐛 [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- 💬 [Security Policy](https://github.com/CryptoHives/.github/blob/main/SECURITY.md)

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/CryptoHives/Foundation/blob/main/LICENSE) file for details.

---

[Impressum (Legal Notice)](impressum.md)

© 2026 The Keepers of the CryptoHives
