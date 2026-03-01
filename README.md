## 🛡️ CryptoHives Open Source Initiative 🐝

An open, community-driven cryptography and performance library collection for the .NET ecosystem.

---

## 🏛️ CryptoHives .NET Foundation Libraries

The **CryptoHives Open Source Initiative** is a collection of modern, high-assurance libraries for .NET, developed and maintained by **The Keepers of the CryptoHives**. 
Each package is designed for security, interoperability, and clarity — making it easy to build secure systems for high performance transformation pipelines and for cryptography workloads without sacrificing developer experience.

---

## 🧬 Features and Design Principles

### 🧱 Orthogonal Design
- All development is done on free and open-source tools, e.g. .NET SDK, Visual Studio Community Edition, Visual Studio Code, GitHub, Azure DevOps, etc.
- Each package is designed to be orthogonal and composable with other CryptoHives packages to avoid deep cross dependencies
- Dependencies on other packages are kept to a minimum and shall only include widely adopted, well-maintained libraries, e.g. the Microsoft.Extensions
- OS and hardware dependencies are avoided wherever possible to ensure deterministic behavior across all platforms and runtimes, specifically for security implementations
- There is no intention to replace or shadow existing .NET class libraries; instead, CryptoHives packages are designed to complement and extend existing functionality

### ⚡ High-Performance Primitives
- All CryptoHives packages are designed for high performance and no operational allocations to optimize high performance transformation pipelines and cryptography workloads
- Algorithms may use managed SIMD intrinsics with scalar fallback.
- Package performance and memory usage are benchmarked against reference implementations

### 🔐 Secure Development Policy
- Standards-Based Cryptography – Implementations are written from official public specifications and standards (NIST, RFC, ISO)
- All algorithms are verified against official test vectors from specification documents
- Review process includes algorithm validation against reference implementations
- Threat-Modeled by Design – All public APIs and network interfaces assume hostile input
- Secure by Default & Validation – Minimal attack surface, explicit configuration, strict input checks, and resource bounds
- Dependency & Supply-Chain Safety – Minimal, vetted dependencies; reproducible signed (planned) releases.
- Automated Verification – Fuzzing (planned), static analysis, and safe error handling to prevent misuse and information leaks.
- Development may use AI-assisted tooling; no guarantee of clean-room provenance is claimed

---

## 🐝 Available CryptoHives

### 🛠️ Buffer Pools (Memory)
Pooled buffer management for transformation pipelines and high-frequency I/O:

- `ArrayPoolMemoryStream` — drop-in `MemoryStream` replacement backed by `ArrayPool<byte>` with `ReadOnlySequence` handoff support
- `ReadOnlySequenceMemoryStream` — read from `ReadOnlySequence<byte>` as `MemoryStream` without copying
- `ArrayPoolBufferWriter<T>` — `IBufferWriter<T>` over pooled arrays for e.g. `Utf8JsonWriter`
- Ownership primitives for zero-copy handoff of pooled buffers

### 🚀 Concurrency Tools (Threading)
Async-compatible synchronization primitives built on `ObjectPool` and `ValueTask<T>`.
Designed to eliminate `Task` / `TaskCompletionSource<T>` allocations on the hot path.

- `AsyncLock` — mutual exclusion
- `AsyncSemaphore` — counting semaphore
- `AsyncAutoResetEvent` / `AsyncManualResetEvent`
- `AsyncReaderWriterLock`
- `AsyncBarrier` / `AsyncCountdownEvent`

All primitives support `CancellationToken` and `ConfigureAwait(false)` without the need for extra allocations.
Nuget package contains a C# analyzer to avoid common ValueTask usage mistakes. (Also available as standalone package)

⏱️ [Async primitive benchmarks](https://cryptohives.github.io/Foundation/packages/threading/benchmarks.html) — contested and uncontested scenarios, comparing pooled `ValueTask` vs. existing `Task`-based alternatives.

### 🔐 Managed Code Cryptography (Security.Cryptography)
Fully managed implementations of cryptographic hash algorithms, MACs, and cipher algorithms, written from NIST/RFC/ISO specifications and verified against official test vectors.
No OS crypto dependency — deterministic results on every platform. Hardware acceleration via AES-NI, PCLMULQDQ, VPCLMULQDQ, SSE2, SSSE3, and AVX2 intrinsics is automatically enabled on supported hardware, in some cases even outperforming OS implementations.

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
| Cipher (AEAD) | AES-GCM (128/192/256), AES-CCM (128/256), ChaCha20-Poly1305, XChaCha20-Poly1305 |
| Cipher (Block) | AES-128, AES-192, AES-256 (ECB/CBC/CTR), ChaCha20 |
| Regional | SM3, Streebog, Kupyna, LSH, Whirlpool, RIPEMD-160 |
| Legacy | SHA-1, MD5 (backward compatibility only) |

All XOF algorithms implement `IExtendableOutput` for streaming variable-length output via `Absorb` / `Squeeze` / `Reset`.

**⏱️ Cryptography Benchmarks**

Measured with BenchmarkDotNet across various payloads, comparing managed vs. reference vs. OS implementations.
- [Hash algorithms](https://cryptohives.github.io/Foundation/packages/security/cryptography/benchmarks-hash.html)
- [Cipher algorithms](https://cryptohives.github.io/Foundation/packages/security/cryptography/benchmarks-cipher.html)

---

### 📦 Nuget Packages

| Package | Description | NuGet | Documentation |
|----------|--------------|--------|---------------|
| `Memory` | Pooled buffers and streams | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Memory) | [Docs](https://cryptohives.github.io/Foundation/packages/memory/index.html) |
| `Threading` | Pooled async synchronization | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) | [Docs](https://cryptohives.github.io/Foundation/packages/threading/index.html) |
| `Security.Cryptography` | Hash, MAC & cipher algorithms | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Security.Cryptography.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Security.Cryptography) | [Docs](https://cryptohives.github.io/Foundation/packages/security/cryptography/index.html) |

All packages are published under the `CryptoHives.Foundation` prefix and namespace — see the Nuget [CryptoHives](https://www.nuget.org/packages?q=CryptoHives) for details.

### 🩺 CryptoHives Health

[![Azure DevOps](https://dev.azure.com/cryptohives/Foundation/_apis/build/status%2FCryptoHives.Foundation?branchName=main)](https://dev.azure.com/cryptohives/Foundation/_build/latest?definitionId=6&branchName=main)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)
[![codecov](https://codecov.io/github/CryptoHives/Foundation/graph/badge.svg?token=02RZ43EVOB)](https://codecov.io/github/CryptoHives/Foundation)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation?ref=badge_shield)

---

## 📚 Documentation

- 📖 **[Full Documentation](https://cryptohives.github.io/Foundation/)** - Comprehensive guides, API reference, and examples
- 🚀 [Getting Started Guide](https://cryptohives.github.io/Foundation/getting-started.html)
- 📦 [Package Documentation](https://cryptohives.github.io/Foundation/packages/index.html)
- 📚 [API Reference](https://cryptohives.github.io/Foundation/api/index.html)

---

## 🧩 Installation

Install via NuGet CLI:

```bash
dotnet add package CryptoHives.Foundation.Threading
```

Or using the Visual Studio Package Manager:

```powershell
Install-Package CryptoHives.Foundation.Threading
```

---

## 🧠 Usage Examples

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

// Allocation-free async lock, even with cancellation token
private readonly AsyncLock _lock = new();

public async Task DoWorkAsync(CancellationToken ct)
{
    using await _lock.LockAsync(ct).ConfigureAwait(false);
    // critical section
}
```

---

## 🔐 Security Policy

Security is our top priority.

If you discover a vulnerability, **please do not open a public issue.**  
Instead, please follow the guidelines on the [CryptoHives Open Source Initiative Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md).

---

## 🔏 Nuget Package Assembly Code Signing

Assemblies in our Nuget packages are currently not code signed. Once there is sufficient demand and funding available, the Keepers plan to implement code signing for all released packages.

---

## 📝 No-Nonsense Matters

This project is released under the MIT License because open collaboration matters.  
However, the Keepers are well aware that MIT-licensed code often gets copied, repackaged, or commercialized without giving credit.  

If you use this code, please do so responsibly:
- Give visible credit to the **CryptoHives Open Source Initiative** or **The Keepers of the CryptoHives** and refer to the original source.
- Contribute improvements back and report issues.

Open source thrives on respect, not just permissive licenses.

---

## ⚖️ License

Each component of the CryptoHives Open Source Initiative is licensed under a SPDX-compatible MIT license.  
By default, packages use the following license tags:

```csharp
// SPDX-FileCopyrightText: <year> The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT
```

Some inherited components may use alternative MIT license headers, according to their origin and specific requirements those headers are retained.

---

## 🐝 About The Keepers of the CryptoHives

The **CryptoHives Open Source Initiative** project is maintained by **The Keepers of the CryptoHives** —  
a collective of developers dedicated to advancing open, verifiable, and high-performance cryptography in .NET.

---

## 🧩 Contributing

Contributions, issue reports, and pull requests are welcome!

Please see the [Contributing Guide](https://github.com/CryptoHives/.github/blob/main/CONTRIBUTING.md) before submitting code.

---

© 2026 The Keepers of the CryptoHives
