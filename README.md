## 🛡️ CryptoHives Open Source Initiative 🐝

An open, community-driven collection of cryptography and performance libraries for the .NET ecosystem.

.NET is a solid platform for building secure, high-performance applications across almost any target, but two gaps keep showing up: high-performance patterns rarely get packaged as simple, drop-in libraries, and cryptography still leans heavily on whatever the underlying OS happens to provide, with all the inconsistency in features and performance that brings. 

CryptoHives exist to close both gaps, one package at a time.

The **CryptoHives Open Source Initiative** is maintained by **The Keepers of the CryptoHives** and is currently addressing three areas:

- **Threading** — async synchronization primitives built for low/no allocation and high throughput, using `ValueTask`-based waiters backed by pooled resources
- **Memory** — buffer management on top of `ArrayPool<T>` and the modern .NET memory APIs, meant to keep GC pressure out of transformation pipelines and crypto workloads
- **Cryptography** — OS-independent implementations for a wide range of cryptographic algorithms, usable as drop-in replacement for `System.Security.Cryptography`

---

## 📚 Documentation

- 📖 **[Full Documentation](https://cryptohives.github.io/Foundation/)** — guides, API reference, examples
- 🚀 [Getting Started Guide](https://cryptohives.github.io/Foundation/getting-started.html)
- 📦 [Package Documentation](https://cryptohives.github.io/Foundation/packages/index.html)
- 📚 [API Reference](https://cryptohives.github.io/Foundation/api/index.html)

---

## 🐝 Available CryptoHives

### 📦 Nuget Packages

| Package | Description | NuGet | Documentation |
|----------|--------------|--------|---------------|
| `Memory` | Pooled buffers and streams | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Memory) | [Docs](https://cryptohives.github.io/Foundation/packages/memory/index.html) |
| `Threading` | Pooled async synchronization | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) | [Docs](https://cryptohives.github.io/Foundation/packages/threading/index.html) |
| `Threading.Analyzers` | Analyzer for pooled async synchronization | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.Analyzers.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading.Analyzers) | [Docs](https://cryptohives.github.io/Foundation/packages/threading/index.html) |
| `Security.Cryptography` | Cryptographic algorithms | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Security.Cryptography.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Security.Cryptography) | [Docs](https://cryptohives.github.io/Foundation/packages/security/cryptography/index.html) |

All packages are published under the `CryptoHives.Foundation` prefix and namespace — see [CryptoHives on NuGet](https://www.nuget.org/packages?q=CryptoHives) for the full list.

### 🩺 Health

[![Azure DevOps](https://dev.azure.com/cryptohives/Foundation/_apis/build/status%2FCryptoHives.Foundation?branchName=main)](https://dev.azure.com/cryptohives/Foundation/_build/latest?definitionId=6&branchName=main)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)
[![codecov](https://codecov.io/github/CryptoHives/Foundation/graph/badge.svg?token=02RZ43EVOB)](https://codecov.io/github/CryptoHives/Foundation)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation?ref=badge_shield)

### 🧠 Buffer Pools (Memory)
Pooled buffer management for transformation pipelines and high-frequency I/O:

- `ArrayPoolMemoryStream` — drop-in `MemoryStream` replacement backed by `ArrayPool<byte>`, with `ReadOnlySequence` handoff support
- `ReadOnlySequenceMemoryStream` — reads a `ReadOnlySequence<byte>` as a `MemoryStream` without copying
- `ArrayPoolBufferWriter<T>` — `IBufferWriter<T>` over pooled arrays, e.g. for `Utf8JsonWriter`
- `ISegmentOwner<T>` — ownership contract for `ArraySegment<T>` with three built-in strategies:
  - `PooledSegment<T>` — rents from `ArrayPool<T>.Shared`, returns on dispose
  - `AllocatedSegment<T>` — wraps a GC-managed `T[]`, no pool lifecycle
  - `EmptySegment<T>` — zero-allocation null-object sentinel

### 🧵 Concurrency Tools (Threading)
Async-compatible synchronization primitives built on `ObjectPool` and `ValueTask<T>`, designed to keep `Task` / `TaskCompletionSource<T>` allocations off the hot path.

- `AsyncLock` — mutual exclusion
- `AsyncSemaphore` — counting semaphore
- `AsyncAutoResetEvent` / `AsyncManualResetEvent`
- `AsyncReaderWriterLock`
- `AsyncBarrier` / `AsyncCountdownEvent`

All primitives support `CancellationToken` and `ConfigureAwait(false)` without extra allocations. New in 0.6: timeout support via `TimeProvider` (an `ITimer` is only allocated once there's actual contention).

A Roslyn analyzer that catches common `ValueTask` usage mistakes ships as a standalone package.

⏱️ [Async primitive benchmarks](https://cryptohives.github.io/Foundation/packages/threading/benchmarks.html) — contested and uncontested scenarios, pooled `ValueTask` vs. existing `Task`-based alternatives.

### 🔐 Managed Code Cryptography (Security.Cryptography)
Fully managed hash, MAC, and cipher implementations, written from NIST/RFC/ISO specifications and checked against official test vectors. 
No OS crypto dependency, so results are deterministic on every platform. Where the hardware supports it, AES-NI, PCLMULQDQ, VPCLMULQDQ, SSE2, SSSE3, and AVX2 intrinsics kick in 
automatically — in some cases outperforming the OS-provided implementation.

**Algorithms:**

| Family | Algorithms |
|--------|-----------|
| SHA-2 | SHA-224, SHA-256, SHA-384, SHA-512, SHA-512/224, SHA-512/256 |
| SHA-3 | SHA3-224, SHA3-256, SHA3-384, SHA3-512 |
| Keccak | Keccak-256, Keccak-384, Keccak-512 (Ethereum compatible) |
| SHAKE / cSHAKE | SHAKE128, SHAKE256, cSHAKE128, cSHAKE256 |
| ParallelHash (SP 800-185) | ParallelHash128, ParallelHash256 |
| TurboSHAKE / KT | TurboSHAKE128, TurboSHAKE256, KT128, KT256 |
| BLAKE | BLAKE2b, BLAKE2s (SIMD-accelerated), BLAKE3 |
| Ascon | Ascon-Hash256, Ascon-XOF128 (NIST SP 800-232 lightweight) |
| MAC | HMAC-SHA-256/384/512, HMAC-SHA3-256, AES-CMAC, AES-GMAC, Poly1305, KMAC128, KMAC256, BLAKE2 keyed, BLAKE3 keyed |
| Cipher (AEAD) | AES-GCM (128/192/256), AES-CCM (128/192/256), ChaCha20-Poly1305, XChaCha20-Poly1305, Ascon-AEAD128 |
| Cipher (Block) | AES-128, AES-192, AES-256 (ECB/CBC/CTR), ChaCha20 |
| Cipher (Regional) | SM4, ARIA (128/192/256), Camellia (128/192/256), Kuznyechik, Kalyna (128/256/512), SEED |
| Regional | SM3, Streebog, Kupyna, LSH, Whirlpool, RIPEMD-160 |
| Legacy | SHA-1, MD5 (kept for backward compatibility only) |

All XOF algorithms implement `IExtendableOutput` for streaming variable-length output via `Absorb` / `Squeeze` / `Reset`.

**⏱️ Benchmarks**

Measured with BenchmarkDotNet across a range of payload sizes, comparing our managed implementations against reference libraries and the OS-provided versions.
- [Hash algorithms](https://cryptohives.github.io/Foundation/packages/security/cryptography/benchmarks-hash.html)
- [Cipher algorithms](https://cryptohives.github.io/Foundation/packages/security/cryptography/benchmarks-cipher.html)

---

## 🏗️ Architecture Overview

```
┌─────────────────────────────────────────────────────────────────────────────────┐
│                        CryptoHives .NET Foundation                              │
│                    CryptoHives Open Source Initiative                           │
└─────────────────────────────────────────────────────────────────────────────────┘
                                     │
         ┌───────────────────────────┼────────────────────────────┐
         │                           │                            │
         ▼                           ▼                            ▼
┌────────────────────┐   ┌───────────────────────┐   ┌────────────────────────────┐
│     Memory         │   │      Threading        │   │  Security.Cryptography     │
├────────────────────┤   ├───────────────────────┤   ├────────────────────────────┤
│ ArrayPool-         │   │ AsyncLock             │   │ Hash                       │
│    MemoryStream    │   │ AsyncSemaphore        │   │  SHA-2 · SHA-3             │
│ ArrayPool-         │   │ AsyncAutoResetEvent   │   │  SHAKE · cSHAKE            │
│    BufferWriter<T> │   │ AsyncManualResetEvent │   │  TurboSHAKE · KT128/256    │
│ ReadOnlySequence-  │   │ AsyncReaderWriterLock │   │  ParallelHash (SP 800-185) │
│    MemoryStream    │   │ AsyncBarrier          │   │  KMAC128 · KMAC256         │
│ ISegmentOwner<T>   │   │ AsyncCountdownEvent   │   │  Keccak · BLAKE2 · BLAKE3  │
│  PooledSegment     │   │                       │   │  Ascon · Regional · Legacy │
│  AllocatedSegment  │   │ IValueTaskSource<T>   │   │                            │
│  EmptySegment      │   │    backed by          │   │ MAC                        │
│                    │   │   ObjectPool<T>       │   │  HMAC · KMAC               │
│                    │   │                       │   │  AES-CMAC · AES-GMAC       │
│                    │   │                       │   │  Poly1305 · BLAKE2/3       │
│                    │   │                       │   │                            │
│                    │   │                       │   │ Cipher                     │
│                    │   ├───────────────────────┤   │  AES-GCM/CCM (AEAD)        │
│                    │   │ Threading.Analyzers   │   │  ChaCha20-Poly1305         │
│                    │   │   ValueTask Roslyn    │   │  XChaCha20-Poly1305        │
│                    │   │   analyzers           │   │  Ascon-AEAD128             │
└────────────────────┘   └───────────────────────┘   │  AES-128/192/256           │
                                                     │  ChaCha20 (stream)         │
                                                     │  SM4 · ARIA · Camellia     │
                                                     │  Kuznyechik · Kalyna       │
                                                     │  SEED                      │
                                                     │                            │
                                                     │ Key Derivation             │
                                                     │  HKDF · KBKDF              │
                                                     │  ConcatKDF · PBKDF2        │
                                                     └────────────────────────────┘

Keccak class hierarchy (Security.Cryptography):

  HashAlgorithm
  └── KeccakCore  (Keccak-p[1600] sponge, AVX2/SSSE3/scalar dispatch)
      ├── KeccakHashCore  (fixed-length)
      │   ├── SHA3_{224,256,384,512}
      │   └── Keccak{256,384,512}  (Ethereum-compatible, domain sep 0x01)
      ├── KeccakXofCore : IExtendableOutput  (variable-length)
      │   ├── Shake{128,256}        (domain sep 0x1F, rate 168/136 bytes)
      │   ├── TurboShake{128,256}   (12-round Keccak, domain sep 0x7F/0x7E)
      │   └── KT{128,256}           (KangarooTwelve tree-hashing XOF)
      └── CShake{128,256} : IExtendableOutput  (bytepad prefix, domain sep 0x04)

  ParallelHash  (static, NIST SP 800-185)
    per-block inner hash ─── Shake{128,256}
    finalization         ─── CShake{128,256}  (N="ParallelHash", S=user)

  IncrementalParallelHash  (streaming wrapper, buffers input until Squeeze)
```

---

## 🧬 Development Policy

Development may use AI-assisted tooling; no guarantee of clean-room provenance is claimed.

### 🧱 Orthogonal by design
- Everything is built with free and open-source tooling — the .NET SDK, Visual Studio Community, VS Code, GitHub, Azure DevOps.
- Packages are meant to stand on their own; we try hard to avoid deep cross-dependencies between them.
- Dependencies on anything outside CryptoHives are kept minimal and limited to widely adopted, well-maintained libraries (e.g. `Microsoft.Extensions.*`).
- OS and hardware dependencies are avoided where possible, so behavior stays deterministic across platforms and runtimes — this matters especially for the crypto implementations.
- None of this is meant to replace or compete with the existing .NET class library. It's meant to complement it.

### ⚡ Built for performance
- Every package targets high throughput with no steady-state allocations, for both transformation pipelines and crypto workloads.
- Where it helps, algorithms use managed SIMD intrinsics with a scalar fallback for platforms that don't support them.
- Performance and memory usage are benchmarked against reference implementations, not just asserted.

### 🛡️ Secure development policy
- Implementations are written directly from public specifications (NIST, RFC, ISO) rather than ported from other codebases.
- Every algorithm is checked against official test vectors from its specification.
- Reviews include validation against independent reference implementations.
- Public APIs and anything touching the network are treated as hostile-input surfaces by default.
- Defaults favor a minimal attack surface: explicit configuration, strict input validation, bounded resource use.
- Dependencies are kept minimal and vetted; reproducible, signed releases are on the roadmap.
- Fuzzing is planned; static analysis and defensive error handling are already in place to limit misuse and information leaks.

### 🤖 AI Usage in This Project
AI coding assistants (such as Claude and GitHub Copilot) are used in this project as productivity tools — for drafting boilerplate, tests, and documentation, and for reviewing code. 
Every AI-assisted contribution is reviewed, understood, and validated by a human maintainer before being merged; no code is accepted that the maintainers cannot fully explain and stand behind. 
Given the security-sensitive nature of this library, all cryptographic logic is verified against the relevant specifications and test vectors regardless of how it was authored. 
Contributors are welcome to use AI tools under the same principle: you are responsible for the correctness, licensing, and quality of what you submit, and purely machine-generated PRs without human understanding will be rejected.

---

## 📥 Installation

Via the NuGet CLI:

```bash
dotnet add package CryptoHives.Foundation.Threading
```

Or from the Visual Studio Package Manager:

```powershell
Install-Package CryptoHives.Foundation.Threading
```

---

## 💡 Usage Examples

---

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

// Allocation-free hash
using var blake3 = Blake3.Create();
Span<byte> hash = stackalloc byte[32];
blake3.TryComputeHash(data, hash, out _);

// XOF streaming (variable-length output)
using var shake = Shake256.Create(64);
shake.Absorb(data1);
shake.Absorb(data2);
Span<byte> output = stackalloc byte[128];
shake.Squeeze(output);
```

---

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

// Allocation-free async lock, even with a cancellation token
private readonly AsyncLock _lock = new();

public async Task DoWorkAsync(CancellationToken ct)
{
    using await _lock.LockAsync(ct).ConfigureAwait(false);
    // critical section
}
```

---

## 🚨 Security Policy

Security comes first here. If you find a vulnerability, please don't open a public issue — follow the process described on the [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md) instead.

---

## 🔏 NuGet Package Code Signing

Packages aren't code-signed yet. The Keepers plan to add signing once there's enough demand (and funding) to justify it.

---

## 📝 No-Nonsense License Matters

This project is MIT-licensed because we believe in open collaboration. That said, we're aware MIT code gets sometimes copied, repackaged, and resold without credit — if you use this code, we'd appreciate it if you didn't do that:

- Give visible credit to the **CryptoHives Open Source Initiative** / **The Keepers of the CryptoHives** and link back to the source.
- Send improvements back upstream and report issues rather than silently forking.

None of that is legally required under MIT — it's just what makes open source worth doing.

---

## ⚖️ License

Every component is licensed under MIT. Source files carry the following SPDX header by default:

```csharp
// SPDX-FileCopyrightText: <year> The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT
```

A few inherited components use their original MIT-style headers instead, kept as-is for provenance.

---

## 🐝 About The Keepers of the CryptoHives

The CryptoHives Open Source Initiative is maintained by **The Keepers of the CryptoHives**, a loose collective of developers working on open, verifiable, high-performance cryptography for .NET.

---

## 🤝 Contributing

Issues and pull requests are welcome. Please read the [Contributing Guide](https://github.com/CryptoHives/.github/blob/main/CONTRIBUTING.md) before sending a PR.

---

© 2026 The Keepers of the CryptoHives

