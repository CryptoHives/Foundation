## 🛡️ CryptoHives Open Source Initiative 🐝

An open, community-driven cryptography and performance library collection for the .NET ecosystem.

---

## 🐝 CryptoHives .NET Foundation Packages

The **CryptoHives Open Source Initiative** is a collection of modern, high-assurance libraries for .NET, developed and maintained by **The Keepers of the CryptoHives**. 
Each package is designed for security, interoperability, and clarity — making it easy to build secure systems for high performance transformation pipelines and for cryptography workloads without sacrificing developer experience.

---

## 📚 Documentation

📖 **[Full Documentation](https://cryptohives.github.io/Foundation/)** - Comprehensive guides, API reference, and code samples

- 🚀 [Getting Started Guide](https://cryptohives.github.io/Foundation/getting-started.html)
- 📦 [Package Documentation](https://cryptohives.github.io/Foundation/packages/memory/index.html)
- 📚 [API Reference](https://cryptohives.github.io/Foundation/api/index.html)

---

## 📦 Available Packages

| Package | Description | NuGet | Documentation |
|----------|--------------|--------|---------------|
| `CryptoHives.Foundation.Memory` | High-performance pooled buffers and streams | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Memory) | [Docs](https://cryptohives.github.io/Foundation/packages/memory/index.html) |
| `CryptoHives.Foundation.Threading` | Pooled async synchronization primitives | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) | [Docs](https://cryptohives.github.io/Foundation/packages/threading/index.html) |

More packages will be published under the `CryptoHives.*` namespace — see the Nuget [CryptoHives](https://www.nuget.org/packages?q=CryptoHives) for details.

### 🐝 CryptoHives Health

[![Azure DevOps](https://dev.azure.com/cryptohives/Foundation/_apis/build/status%2FCryptoHives.Foundation?branchName=main)](https://dev.azure.com/cryptohives/Foundation/_build/latest?definitionId=6&branchName=main)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)
[![codecov](https://codecov.io/github/CryptoHives/Foundation/graph/badge.svg?token=02RZ43EVOB)](https://codecov.io/github/CryptoHives/Foundation)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation?ref=badge_shield)

---

## 🧬 Features

### 📚 API Overview and documentation
The API reference with samples is available at the [CryptoHives .NET Foundation Docs](https://cryptohives.github.io/Foundation/).

### 🔐 Clean-Room Cryptography (planned)
- Fully managed implementations of symmetric and asymmetric algorithms
- No dependency on OS or hardware cryptographic APIs
- Deterministic behavior across all platforms and runtimes
- Support for both classical and modern primitives (AES, ChaCha20, SHA-2/3, etc.)
 
### ⚡ High-Performance Primitives
- CryptoHives provides a growing set of utilities designed to optimize high performance transformation pipelines and cryptography workloads.

### 🛠️ Memory Efficiency
- **ArrayPool-based allocators** for common crypto and serialization scenarios
- Pooled implementations of `MemoryStream` and `IBufferWriter<T>` for transformation pipelines
- Primitives to handle ownership of pooled buffers using `ReadOnlySequence<T>` with `ArrayPool<T>`
- Zero-copy, zero-allocation design for high-frequency cryptographic workloads and transformation pipelines

### 🚀 Concurrency Tools
- Lightweight Async-compatible synchronization primitives based on `ObjectPool` and `ValueTask<T>`
- High-performance threading helpers designed to reduce allocations of `Task` and `TaskCompletionSource<T>`

### 🧪 Tests and Benchmarks
- Comprehensive tests and benchmarks are available to evaluate performance across various scenarios.

### 🔒 Fuzzing
- All libraries and public-facing APIs are planned to be fuzzed (wip)

---

## 🚀 Installation

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

Here’s a minimal example using the `CryptoHives.Foundation.Memory` package:

```csharp
using CryptoHives.Foundation.Memory;
using System;

public class Example
{
    public string WritePooledChunk(ReadOnlySpan<byte> chunk)
    {
        // Use a MemoryStream backed by ArrayPool<byte> buffers
        using var writer = new ArrayPoolMemoryStream();
        writer.Write(chunk);
        ReadOnlySequence<byte> sequence = writer.GetReadOnlySequence();
        return Encoding.UTF8.GetString(sequence);
    }
}
```

---

Here’s a minimal example using the `CryptoHives.Foundation.Threading` package:

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;
using System;

public class Example
{
    private AsyncLock _lock = new AsyncLock(); 

    public async Task AccessSharedResourceAsync()
    {
        // Due to the use of ValueTask and ObjectPools, 
        // this mutex is very fast and allocation-efficient
        // Acquire the lock asynchronously
        using await _lock.ConfigureAwait(false);
        // Access shared async resource here
    }
}
```

---

## 🧪 Clean-Room Policy

All code within the **CryptoHives .NET Foundation** is written and validated under **strict clean-room conditions**:

- No reverse engineering or derived code from existing proprietary libraries
- Implementations are verified against public specifications and test vectors  
- Review process includes formal algorithm validation and peer verification  

---

## 🔐 Security Policy

Security is our top priority.

If you discover a vulnerability, **please do not open a public issue.**  
Instead, please follow the guidelines on the [CryptoHives Open Source Initiative Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md).

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

Each component of the CryptoHives Open Source Initiative is licensed under a SPDX-compatible license.  
By default, packages use the following license tags:

```csharp
// SPDX-FileCopyrightText: <year> The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT
```

Some inherited components may use alternative MIT license headers, according to their origin and specific requirements those headers are retained.
<!--
---
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FCryptoHives%2FFoundation?ref=badge_large)
-->
---

## 🐝 About The Keepers of the CryptoHives

The **CryptoHives Open Source Initiative** project is maintained by **The Keepers of the CryptoHives** —  
a collective of developers dedicated to advancing open, verifiable, and high-performance cryptography in .NET.

---

## 🧩 Contributing

Contributions, issue reports, and pull requests are welcome!

Please see the [Contributing Guide](https://github.com/CryptoHives/.github/blob/main/CONTRIBUTING.md) before submitting code.

---

**CryptoHives Open Source Initiative — Secure. Deterministic. Performant.**

© 2025 The Keepers of the CryptoHives. All rights reserved.