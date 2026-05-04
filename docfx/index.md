---
_layout: landing
---

# CryptoHives .NET Foundation

Welcome to the **CryptoHives .NET Foundation** documentation!

## Overview

The CryptoHives .NET Foundation provides libraries for .NET applications focusing on high performance memory management, threading primitives, and cryptographic algorithms.

## Ecosystem

The initiative currently includes:
- [Threading](packages/threading/index.md) — high-performance async synchronization primitives optimized for no/low allocation and high throughput scenarios using ValueTask-based waiters and ObjectPool-backed resource management
- [Memory](packages/memory/index.md) — pooled buffer management utilities leveraging ArrayPool<T> and modern .NET memory APIs to minimize GC pressure for transformation pipelines and cryptographic workloads which use ReadOnlySpan or IBufferWriter
- [Cryptography](packages/security/cryptography/index.md) — OS independent implementation of all .NET cryptography as a plug in replacement

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

The Cryptography package provides specification-based implementations of cryptographic hash algorithms, message authentication codes (MACs), cipher algorithms, and key derivation functions, all implemented as fully managed code without OS dependencies.

**Key Features:**
- SHA-1, SHA-2, SHA-3 family implementations with full test vector validation
- SHAKE and cSHAKE extendable-output functions (XOF) for variable-length output
- TurboSHAKE and KangarooTwelve (KT128/KT256) high-performance XOFs
- KMAC (Keccak Message Authentication Code) for authenticated hashing
- Ascon lightweight hashing and AEAD (NIST SP 800-232) for constrained environments
- BLAKE2b, BLAKE2s, and BLAKE3 high-performance hashing with keyed modes
- Keccak-256, Keccak-384, Keccak-512 for Ethereum compatibility
- International standards: SM3 (Chinese), Streebog/GOST (Russian), Kupyna/DSTU (Ukrainian), LSH/KS (Korean), Whirlpool (ISO)
- Legacy algorithms: MD5, SHA-1, RIPEMD-160 (for compatibility only)
- AES-CBC, AES-GCM, AES-CCM, ChaCha20, ChaCha20-Poly1305, XChaCha20-Poly1305, and Ascon-AEAD128 cipher implementations
- Regional block ciphers: SM4, ARIA, Camellia, Kuznyechik, Kalyna, SEED
- Key derivation: HKDF, KBKDF, Concat KDF, PBKDF2, BLAKE3 DeriveKey
- MACs: HMAC, AES-CMAC, AES-GMAC, Poly1305, KMAC, BLAKE2/3 keyed
- AES Key Wrap with Padding (RFC 3394/5649)
- Cross-platform consistency without OS crypto API dependencies

[Explore Security.Cryptography Package](packages/security/cryptography/index.md)

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

