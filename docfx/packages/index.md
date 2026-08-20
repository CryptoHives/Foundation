# Packages

The CryptoHives .NET Foundation is a set of independent NuGet packages — take only the one you need.
All of them target `net462`, `netstandard2.0`, `netstandard2.1`, `net8.0` and `net10.0`
(the cryptography package adds `net472`), and none of them depend on each other.

| Package | What it gives you | NuGet |
|---------|-------------------|-------|
| [Memory](memory/index.md) | Pooled buffers and streams on top of `ArrayPool<T>`: `ArrayPoolMemoryStream`, `ArrayPoolBufferWriter<T>`, `ReadOnlySequenceMemoryStream`, and RAII ownership helpers | [CryptoHives.Foundation.Memory](https://www.nuget.org/packages/CryptoHives.Foundation.Memory) |
| [Threading](threading/index.md) | `ValueTask`-based async synchronization primitives with pooled waiters: `AsyncLock`, `AsyncKeyedLock<TKey>`, `AsyncSemaphore`, the events, the barrier, the countdown, and the reader-writer lock | [CryptoHives.Foundation.Threading](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) |
| [Threading.Analyzers](threading.analyzers/index.md) | Roslyn analyzers that catch `ValueTask` misuse at compile time. Ships separately — install it alongside the Threading package | [CryptoHives.Foundation.Threading.Analyzers](https://www.nuget.org/packages/CryptoHives.Foundation.Threading.Analyzers) |
| [Security.Cryptography](security/cryptography/index.md) | Fully managed hash, MAC, KDF and cipher implementations written from the specifications, with no OS crypto dependency | [CryptoHives.Foundation.Security.Cryptography](https://www.nuget.org/packages/CryptoHives.Foundation.Security.Cryptography) |

## Where to start

- New here? The [Getting Started guide](../getting-started.md) installs each package and shows a first example.
- Migrating existing code? The [Porting Guide](../porting-to-cryptohives.md) maps BCL types onto these ones step by step.
- Looking for a specific type? The [API reference](../api/index.md) lists every public namespace.
- Wondering how fast it is? The benchmark dashboards for
  [Threading](threading/benchmarks.md) and [Cryptography](security/cryptography/benchmarks.md)
  publish every recorded run, measured against the reference implementations.

## See also

- [Cryptographic specifications and test vectors](security/cryptography/specs/README.md)
- [Source repository](https://github.com/CryptoHives/Foundation)
