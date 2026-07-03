---
_layout: landing
---

# CryptoHives .NET Foundation

Welcome to the **CryptoHives .NET Foundation** documentation.

## Overview

CryptoHives .NET Foundation is a set of libraries for .NET applications, covering high-performance memory management, async threading primitives, and cryptographic algorithms.

## Ecosystem

The initiative currently includes three packages:

- [Threading](packages/threading/index.md) — async synchronization primitives built for low/no allocation and high throughput, using `ValueTask`-based waiters backed by pooled resources
- [Memory](packages/memory/index.md) — buffer management on top of `ArrayPool<T>` and the modern .NET memory APIs, for transformation pipelines and crypto workloads that work in terms of `ReadOnlySpan` or `IBufferWriter`
- [Cryptography](packages/security/cryptography/index.md) — OS-independent reimplementations of `System.Security.Cryptography` algorithms, usable as drop-in replacements

## Available Packages

### [Memory Package](packages/memory/index.md)

Buffer management utilities that lean on `ArrayPool<T>` and modern .NET memory APIs to keep GC pressure out of transformation pipelines and cryptographic workloads.

**Key features:**
- `ArrayPoolMemoryStream` and `ArrayPoolBufferWriter<T>`, both backed by `ArrayPool<byte>.Shared`
- Lifetime-managed `ReadOnlySequence<byte>` support over pooled storage
- `ReadOnlySequenceMemoryStream` for streaming from an existing `ReadOnlySequence<byte>`
- `ObjectPool`-backed resource management helpers, e.g. for `StringBuilder`

[Explore the Memory package →](packages/memory/index.md)

### [Threading Package](packages/threading/index.md)

Async synchronization primitives built for low allocation and high throughput.

**Key features:**
- All waiters are `ValueTask`-based synchronization primitives, designed around low memory allocation
- An optional Roslyn analyzer package that catches common `ValueTask` misuse at compile time
- Full `CancellationToken` support across every wait/lock primitive
- `IValueTaskSource<T>`-based implementations backed by `ObjectPool<T>`, so waiter objects get recycled instead of allocated
- `AsyncLock` for async mutual exclusion, with scoped locking via the `IDisposable` pattern
- `AsyncAutoResetEvent` and `AsyncManualResetEvent`, complementing the existing `Task`-based equivalents
- `AsyncBarrier` as an async-aware replacement for the .NET barrier
- Pooled `AsyncReaderWriterLock`, `AsyncSemaphore`, and `AsyncCountdownEvent`, all with async wait support
- Fast-path optimizations for the uncontended case
- No-allocation design for hot-path code and cancellation tokens (see [Benchmarks](packages/threading/benchmarks.md))

[Explore the Threading package →](packages/threading/index.md)

### [Security.Cryptography Package](packages/security/cryptography/index.md)

Specification-based implementations of hash algorithms, MACs, ciphers, and key derivation functions, all fully managed and OS-independent.

**Key features:**
- SHA-1, SHA-2, SHA-3 families, all validated against full test vectors
- SHAKE and cSHAKE extendable-output functions (XOF) for variable-length output
- TurboSHAKE and KangarooTwelve (KT128/KT256), the high-performance XOFs
- KMAC (Keccak Message Authentication Code) for authenticated hashing
- Ascon lightweight hashing and AEAD (NIST SP 800-232) for constrained environments
- BLAKE2b, BLAKE2s, and BLAKE3, with keyed modes
- Keccak-256/384/512 for Ethereum compatibility
- Regional standards: SM3 (China), Streebog/GOST (Russia), Kupyna/DSTU (Ukraine), LSH/KS (Korea), Whirlpool (ISO)
- Legacy algorithms MD5, SHA-1, RIPEMD-160, kept for compatibility only
- AES-CBC, AES-GCM, AES-CCM, ChaCha20, ChaCha20-Poly1305, XChaCha20-Poly1305, and Ascon-AEAD128 ciphers
- Regional block ciphers: SM4, ARIA, Camellia, Kuznyechik, Kalyna, SEED
- Key derivation: HKDF, KBKDF, Concat KDF, PBKDF2, BLAKE3 DeriveKey
- MACs: HMAC, AES-CMAC, AES-GMAC, Poly1305, KMAC, BLAKE2/3 keyed
- AES Key Wrap with Padding (RFC 3394/5649)
- Cross-platform consistency with no dependency on OS crypto APIs

[Explore the Security.Cryptography package →](packages/security/cryptography/index.md)

## Platform Support

- .NET 10.0
- .NET 8.0
- .NET Framework 4.6.2
- .NET Standard 2.1
- .NET Standard 2.0

## Resources

- [Cryptographic Specifications](packages/security/cryptography/specs/README.md)
- [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- [Security Policy](https://github.com/CryptoHives/.github/blob/main/SECURITY.md)

## License

This project is licensed under the MIT License. See the [LICENSE](https://github.com/CryptoHives/Foundation/blob/main/LICENSE) file for details.

---

[Impressum (Legal Notice)](impressum.md)

© 2026 The Keepers of the CryptoHives
