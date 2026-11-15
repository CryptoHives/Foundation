# API Reference

Generated reference documentation for every public type in the CryptoHives .NET Foundation
packages. The namespaces below mirror the package layout — pick one to browse its types, or use the
search box for a specific type or member.

This page is hand-written and lives at `docfx/api/index.md`; everything else under `api/` is
generated from the XML documentation comments in `src/` when the site is built.

## CryptoHives.Foundation.Memory

| Namespace | Contents |
|-----------|----------|
| [CryptoHives.Foundation.Memory.Buffers](xref:CryptoHives.Foundation.Memory.Buffers) | `ArrayPoolMemoryStream`, `ArrayPoolBufferWriter<T>`, `ReadOnlySequenceMemoryStream`, and the `ISegmentOwner<T>` strategies |
| [CryptoHives.Foundation.Memory.Pools](xref:CryptoHives.Foundation.Memory.Pools) | `ObjectOwner<T>`, `ObjectPools`, `PoolFactory` |

## CryptoHives.Foundation.Threading

| Namespace | Contents |
|-----------|----------|
| [CryptoHives.Foundation.Threading.Async.Pooled](xref:CryptoHives.Foundation.Threading.Async.Pooled) | `AsyncLock`, `AsyncKeyedLock<TKey>`, `AsyncSemaphore`, `AsyncAutoResetEvent`, `AsyncManualResetEvent`, `AsyncCountdownEvent`, `AsyncBarrier`, `AsyncReaderWriterLock` |
| [CryptoHives.Foundation.Threading.Pools](xref:CryptoHives.Foundation.Threading.Pools) | The `IValueTaskSource<T>` pooling infrastructure behind every primitive |
| [CryptoHives.Foundation.Threading.Analyzers](xref:CryptoHives.Foundation.Threading.Analyzers) | The Roslyn analyzers shipped in the separate Analyzers package |

## CryptoHives.Foundation.Security.Cryptography

| Namespace | Contents |
|-----------|----------|
| [CryptoHives.Foundation.Security.Cryptography.Hash](xref:CryptoHives.Foundation.Security.Cryptography.Hash) | SHA-1/2/3, SHAKE and cSHAKE, TurboSHAKE and KT, BLAKE2/3, Ascon, ParallelHash, and the regional and legacy hashes |
| [CryptoHives.Foundation.Security.Cryptography.Cipher](xref:CryptoHives.Foundation.Security.Cryptography.Cipher) | AES and the AEAD modes, ChaCha20 family, Ascon-AEAD128, and the regional block ciphers |
| [CryptoHives.Foundation.Security.Cryptography.Mac](xref:CryptoHives.Foundation.Security.Cryptography.Mac) | HMAC, KMAC, AES-CMAC, AES-GMAC, Poly1305 |
| [CryptoHives.Foundation.Security.Cryptography.Kdf](xref:CryptoHives.Foundation.Security.Cryptography.Kdf) | HKDF, KBKDF, Concat KDF, PBKDF2 |
| [CryptoHives.Foundation.Security.Cryptography.Rng](xref:CryptoHives.Foundation.Security.Cryptography.Rng) | Random number generation over OS entropy |

## See also

- [Package documentation](../packages/index.md) — guides and examples per package
- [Getting Started](../getting-started.md)
- [Porting Guide](../porting-to-cryptohives.md)
