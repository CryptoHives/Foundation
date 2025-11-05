# 🛡️ CryptoHives Foundation 🐝

*CryptoHives Foundation* brings consistent, portable, and auditable cryptography to .NET — managed code first, OS quirks gone.

# 🐝 CryptoHives Foundation .NET Packages

*CryptoHives Foundation* is a collection of modern, high-assurance cryptographic libraries for .NET, developed and maintained by *The Keepers of the CryptoHives*. 
Each package is designed for security, interoperability, and clarity — making it easy to build secure systems without sacrificing developer experience.
There are also supporting packages which optimize memory allocations for streaming and thread synchronization for high performance transformation pipelines and for cryptography workloads.

---

## ✨ Overview

The CryptoHives.Foundation project serves as the core building block for projects under the **CryptoHives Foundation** umbrella.

All implementations are developed **from first principles**, without reliance on operating system or native platform crypto providers, ensuring:

- 🔒 **Security Transparency** — all algorithms are clean-room verified and auditable  
- ⚙️ **Predictable Performance** — optimized memory usage and allocation-free APIs 
- 🧱 **Composable Architecture** — designed for integration in modern .NET applications, from libraries to microservices  

---

## 🧬 Features

### 🔐 Clean-Room Cryptography
- Fully managed implementations of symmetric and asymmetric algorithms
- No dependency on OS or hardware cryptographic APIs
- Deterministic behavior across all platforms and runtimes
- Support for both classical and modern primitives (AES, ChaCha20, SHA-2/3, etc.)

### ⚡ High-Performance Primitives
CryptoHives provides a growing set of utilities designed to optimize high performance transformation pipelines and cryptography workloads:

### 🛠️ Memory Efficiency
- **ArrayPool-based allocators** for common crypto and serialization scenarios
- Pooled implementations of `MemoryStream` and `IBufferWriter<T>` for transformation pipelines
- Primitives to handle ownership of pooled buffers using `ReadOnlySequence<T>` with `ArrayPool<T>`
- Zero-copy, zero-allocation design for high-frequency read/write operations

### 🛠️ Concurrency Tools
- Lightweight Async-compatible synchronization primitives based on `ObjectPool` and `ValueTask<T>`
- High-performance threading helpers designed to reduce allocations of `Task` and `TaskCompletionSource<T>`

---

## 📦 Available Packages

| Package | Description | NuGet |
|----------|--------------|--------|
| `CryptoHives.Memory` | Memory primitives not only for CryptoHives components. | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Memory) |
| `CryptoHives.Threading` | Threading primitives not only for CryptoHives components. | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Threading) |
| `CryptoHives.Cryptography` | Security algorithms and clean-room implementations | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Cryptography.svg)](https://www.nuget.org/packages/CryptoHives.Cryptography) |
| `CryptoHives.Certificates` | Certificate management and validation utilities | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Certificates.svg)](https://www.nuget.org/packages/CryptoHives.Certificates) |
|----------|-------------|

> More packages are available under the `CryptoHives.*` namespace — see the Nuget [CryptoHives Foundation](https://www.nuget.org/packages/CryptoHives) for details.

---

## 🚀 Installation

Install via NuGet CLI:

```bash
dotnet add package CryptoHives.Memory
```

Or using the Visual Studio Package Manager:

```powershell
Install-Package CryptoHives.Memory
```

---

## 🧠 Usage Example

Here’s a minimal example using the `CryptoHives.Memory` package:

```csharp
using CryptoHives.Memory;
using System;

public class Example
{
    public void WriteChunk(ReadOnlySpan<byte> chunk)
    {
        using var writer = new ArrayPoolMemoryStream(defaultBufferSize);
        writer.Write(chunk);
        ReadOnlySequence<byte> sequence = writer.GetReadOnlySequence();
        var result = Encoding.UTF8.GetString(sequence);
    }
}
```

---

## 🧪 Clean-Room Policy

All code within CryptoHives Foundation is written and validated under **strict clean-room conditions**:

- No reverse engineering or derived code from existing proprietary libraries  
- Implementations are verified against public specifications and test vectors  
- Review process includes formal algorithm validation and peer verification  

---

## 🔐 Security Policy

Security is our top priority.

If you discover a vulnerability, **please do not open a public issue.**  
Instead, please follow the guidelines on the [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md).

---

## ⚖️ License

Each CryptoHives component is licensed under a SPDX-compatible license.  
By default, packages use the following license tags:

```csharp
// SPDX-FileCopyrightText: <year> The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT
```

Some inherited components may use alternative MIT license headers, according to their origin and specific requirements.

---

## 🐝 Maintained by

**The Keepers of the CryptoHives**  
> Secure foundations for open cryptography.  
[https://cryptohives.org](https://cryptohives.org)

---

## 🐝 About The Keepers of the CryptoHives

The CryptoHives project is maintained by *The Keepers of the CryptoHives* —  
a collective of developers dedicated to advancing open, verifiable, and high-performance cryptography in .NET.

> _“We don’t wrap APIs. We reimagine them — securely and efficiently.”_

---

## 🧩 Contributing

Contributions, issue reports, and pull requests are welcome!

Please see the [Contributing Guide](https://github.com/CryptoHives/.github/blob/main/CONTRIBUTING.md) before submitting code.

---

**CryptoHives Foundation — Secure. Deterministic. Performant.**

© 2025 The Keepers of the CryptoHives. All rights reserved.
