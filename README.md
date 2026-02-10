## CryptoHives .NET Foundation

Open-source .NET libraries for cryptography, memory management, and async synchronization.
Built by [The Keepers of the CryptoHives](https://github.com/CryptoHives) — a collective focused on verifiable, high-performance .NET primitives.

[![Azure DevOps](https://dev.azure.com/cryptohives/Foundation/_apis/build/status%2FCryptoHives.Foundation?branchName=main)](https://dev.azure.com/cryptohives/Foundation/_build/latest?definitionId=6&branchName=main)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)
[![codecov](https://codecov.io/github/CryptoHives/Foundation/graph/badge.svg?token=02RZ43EVOB)](https://codecov.io/github/CryptoHives/Foundation)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation?ref=badge_shield)

---

## Packages

| Package | What it does | NuGet | Docs |
|---------|-------------|-------|------|
| `CryptoHives.Foundation.Memory` | Pooled buffers, streams, `IBufferWriter<T>` over `ArrayPool<byte>` | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Memory) | [Docs](https://cryptohives.github.io/Foundation/packages/memory/index.html) |
| `CryptoHives.Foundation.Threading` | Async locks, semaphores, barriers, events — all pooled via `ValueTask` | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) | [Docs](https://cryptohives.github.io/Foundation/packages/threading/index.html) |
| `CryptoHives.Foundation.Security.Cryptography` | 30+ managed hash & MAC algorithms with XOF support | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Security.Cryptography.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Security.Cryptography) | [Docs](https://cryptohives.github.io/Foundation/packages/security/cryptography/index.html) |

More packages ship under the `CryptoHives.*` namespace — see [NuGet](https://www.nuget.org/packages?q=CryptoHives).

---

## Cryptography

Fully managed implementations of cryptographic hash algorithms and MACs, written from NIST/RFC/ISO specifications and verified against official test vectors.
No OS crypto dependency — deterministic results on every platform.

**Algorithms:**

| Family | Algorithms |
|--------|-----------|
| SHA-2 | SHA-224, SHA-256, SHA-384, SHA-512, SHA-512/224, SHA-512/256 |
| SHA-3 | SHA3-224, SHA3-256, SHA3-384, SHA3-512 |
| Keccak | Keccak-256, Keccak-384, Keccak-512 (Ethereum compatible) |
| SHAKE / cSHAKE | SHAKE128, SHAKE256, cSHAKE128, cSHAKE256 |
| TurboSHAKE / KT | TurboSHAKE128, TurboSHAKE256, KT128, KT256 |
| BLAKE | BLAKE2b, BLAKE2s (SIMD-accelerated), BLAKE3 |
| Ascon | Ascon-Hash256, Ascon-XOF128 (NIST lightweight) |
| MAC | KMAC128, KMAC256, BLAKE2 keyed, BLAKE3 keyed |
| Regional | SM3, Streebog-256/512, Whirlpool, RIPEMD-160 |
| Legacy | SHA-1, MD5 (backward compatibility only) |

All XOF algorithms implement `IExtendableOutput` for streaming variable-length output via `Absorb` / `Squeeze` / `Reset`.
BLAKE2b, BLAKE2s, and BLAKE3 use managed SIMD intrinsics (SSE2, SSSE3, AVX2) with scalar fallback.

**Benchmarks:** [Hash algorithm benchmarks](https://cryptohives.github.io/Foundation/packages/security/cryptography/benchmarks.html) — measured with BenchmarkDotNet across 128B–128KB payloads, comparing managed vs. BouncyCastle vs. OS implementations.

---

## Threading

Async-compatible synchronization primitives built on `ObjectPool` and `ValueTask<T>`.
Designed to eliminate `Task` / `TaskCompletionSource<T>` allocations on the hot path.

- `AsyncLock` — mutual exclusion
- `AsyncSemaphore` — counting semaphore
- `AsyncAutoResetEvent` / `AsyncManualResetEvent`
- `AsyncReaderWriterLock`
- `AsyncBarrier` / `AsyncCountdownEvent`

All primitives support `CancellationToken` and `ConfigureAwait(false)`.

**Benchmarks:** [Async primitive benchmarks](https://cryptohives.github.io/Foundation/packages/threading/benchmarks.html) — contested and uncontested scenarios, comparing pooled `ValueTask` vs. `Task`-based alternatives.

---

## Memory

Pooled buffer management for transformation pipelines and high-frequency I/O:

- `ArrayPoolMemoryStream` — drop-in `MemoryStream` replacement backed by `ArrayPool<byte>`
- `ReadOnlySequenceMemoryStream` — read from `ReadOnlySequence<byte>` without copying
- `ArrayPoolBufferWriter<T>` — `IBufferWriter<T>` over pooled arrays
- Ownership primitives for zero-copy handoff of pooled buffers

---

## Quick start

```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

// Allocation-free hash
using var blake3 = Blake3.Create();
Span<byte> hash = stackalloc byte[32];
blake3.TryComputeHash(data, hash, out _);

// XOF streaming (variable-length output)
using var shake = Shake256.Create(64);
shake.Absorb(data);
Span<byte> output = stackalloc byte[128];
shake.Squeeze(output);
```

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

// Allocation-free async lock
private readonly AsyncLock _lock = new();

public async Task DoWorkAsync()
{
    using await _lock.ConfigureAwait(false);
    // critical section
}
```

---

## Documentation

Full docs at **[cryptohives.github.io/Foundation](https://cryptohives.github.io/Foundation/)** — includes API reference, algorithm guides, test vectors, and benchmarks.

---

## Development policy

- Implementations are written from official specifications (NIST, RFC, ISO)
- All algorithms are verified against published test vectors
- Reference implementations (BouncyCastle, OS crypto, native libraries) are used for cross-validation
- Development may use AI-assisted tooling; no guarantee of clean-room provenance is claimed

## Security

If you discover a vulnerability, **do not open a public issue**.
Follow the [Security Policy](https://github.com/CryptoHives/.github/blob/main/SECURITY.md).

## Code signing

NuGet packages are not yet code-signed. Signing will be added when demand and funding allow.

## Contributing

Contributions, bug reports, and pull requests are welcome.
See the [Contributing Guide](https://github.com/CryptoHives/.github/blob/main/CONTRIBUTING.md).

## License

MIT. See individual file headers for details.

```
// SPDX-FileCopyrightText: <year> The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT
```

If you use this code, please give credit to the **CryptoHives Open Source Initiative** and link back to the original repo. Open source works better when people acknowledge each other's work.

---

© 2026 The Keepers of the CryptoHives