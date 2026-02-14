## Getting Started with CryptoHives.Foundation libraries

Welcome to the CryptoHives .NET Foundation libraries! Each package includes installation instructions, quick-start examples, and detailed API documentation.

## Packages

### 💾 [Memory Package](packages/memory/index.md)

Allocation-efficient buffer management using `ArrayPool<T>` — pooled memory streams, buffer writers, and `ReadOnlySequence<byte>` support.

```bash
dotnet add package CryptoHives.Foundation.Memory
```

### 🔄 [Threading Package](packages/threading/index.md)

`ValueTask`-based async synchronization primitives with pooled waiter objects — includes `AsyncLock`, `AsyncAutoResetEvent`, `AsyncManualResetEvent`, `AsyncBarrier`, `AsyncReaderWriterLock`, `AsyncSemaphore`, and `AsyncCountdownEvent`.

```bash
dotnet add package CryptoHives.Foundation.Threading
```

### 🔐 [Security.Cryptography Package](packages/security/cryptography/index.md)

Specification-based cryptographic hash algorithms and MACs — SHA-2, SHA-3, SHAKE, cSHAKE, TurboSHAKE, KangarooTwelve, KMAC, BLAKE2, BLAKE3, Ascon, Keccak, SM3, Streebog, Kupyna, LSH, Whirlpool, RIPEMD-160, and legacy MD5/SHA-1.

```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

### 🔍 [Threading Analyzers (Standalone)](packages/threading.analyzers/index.md)

Roslyn analyzers for `ValueTask` misuse detection. Already included in the Threading package — this standalone package is for projects that want analyzers without the Threading library.

```bash
dotnet add package CryptoHives.Foundation.Threading.Analyzers
```

## Support

For issues and questions:
- [GitHub Issues](https://github.com/CryptoHives/Foundation/issues)
- [Security Policy](https://github.com/CryptoHives/Foundation/SECURITY.md)

---

© 2026 The Keepers of the CryptoHives
