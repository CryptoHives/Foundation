## Getting Started with CryptoHives.Foundation

Each package below installs independently and comes with its own quick-start examples and API reference.

## Packages

### [Memory Package](packages/memory/index.md)

Allocation-efficient buffer management on top of `ArrayPool<T>` — pooled memory streams, buffer writers, and `ReadOnlySequence<byte>` support.

```bash
dotnet add package CryptoHives.Foundation.Memory
```

### [Threading Package](packages/threading/index.md)

`ValueTask`-based async synchronization primitives with pooled waiter objects: `AsyncLock`, `AsyncAutoResetEvent`, `AsyncManualResetEvent`, `AsyncBarrier`, `AsyncReaderWriterLock`, `AsyncSemaphore`, and `AsyncCountdownEvent`.

```bash
dotnet add package CryptoHives.Foundation.Threading
```

### [Security.Cryptography Package](packages/security/cryptography/index.md)

Specification-based hash algorithms, MACs, ciphers, and key derivation functions — SHA-2, SHA-3, SHAKE, cSHAKE, TurboSHAKE, KangarooTwelve, KMAC, BLAKE2, BLAKE3, Ascon, Keccak, SM3, Streebog, Kupyna, LSH, Whirlpool, RIPEMD-160, AES-CBC/GCM/CCM, ChaCha20, ChaCha20-Poly1305, XChaCha20-Poly1305, Ascon-AEAD128, regional ciphers (SM4, ARIA, Camellia, Kuznyechik, Kalyna, SEED), HKDF/KBKDF/PBKDF2, and legacy MD5/SHA-1.

```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

### [Threading Analyzers (Standalone)](packages/threading.analyzers/index.md)

Roslyn analyzers for `ValueTask` misuse. Install this alongside the Threading package if you want the compile-time checks.

```bash
dotnet add package CryptoHives.Foundation.Threading.Analyzers
```

## Porting existing code

Moving an existing project onto these packages — replacing BCL async primitives, buffer/pool
code, and hashing? See the [Porting Guide](porting-to-cryptohives.md), a step-by-step
playbook (also usable directly by AI coding agents). Each package additionally ships a
`PORTING.md` at its NuGet package root.

## Support

- [GitHub Issues](https://github.com/CryptoHives/Foundation/issues)
- [Security Policy](https://github.com/CryptoHives/Foundation/SECURITY.md)

---

© 2026 The Keepers of the CryptoHives
