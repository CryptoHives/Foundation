# 🛡️ CryptoHives Open Source Initiative 🐝

The **CryptoHives Open Source Initiative** brings consistent, portable, and auditable cryptography to .NET — managed code first, OS quirks gone.

# 🐝 CryptoHives Open Source Initiative .NET Packages

The **CryptoHives Open Source Initiative** is a collection of modern, high-assurance cryptographic libraries for .NET, developed and maintained by **The Keepers of the CryptoHives**. 
Each package is designed for security, interoperability, and clarity — making it easy to build secure systems without sacrificing developer experience.
There are also supporting packages which improve memory usage and thread synchronization for high performance transformation pipelines and for cryptography workloads.

---

## ✨ Overview

The **CryptoHives.Foundation** project serves as the first core building block for .NET libraries under the **CryptoHives Open Source Initiative** umbrella.

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
- Zero-copy, zero-allocation design for high-frequency cryptographic workloads and transformation pipelines

### 🛠️ Concurrency Tools
- Lightweight Async-compatible synchronization primitives based on `ObjectPool` and `ValueTask<T>`
- High-performance threading helpers designed to reduce allocations of `Task` and `TaskCompletionSource<T>`

---

## 📦 Available Packages

| Package | Description | NuGet |
|----------|--------------|--------|
| `CryptoHives.Memory` | Memory primitives. | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Memory) |
| `CryptoHives.Threading` | Threading primitives. | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Threading) |
|----------|-------------|

> More packages are available under the `CryptoHives.*` namespace — see the Nuget [CryptoHives](https://www.nuget.org/packages/CryptoHives) for details.

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
    public string WritePooledChunk(ReadOnlySpan<byte> chunk)
    {
        using var writer = new ArrayPoolMemoryStream(defaultBufferSize);
        writer.Write(chunk);
        ReadOnlySequence<byte> sequence = writer.GetReadOnlySequence();
        return Encoding.UTF8.GetString(sequence);
    }
}
```

---

## 🧪 Clean-Room Policy

All code within the **CryptoHives Open Source Initiative** is written and validated under **strict clean-room conditions**:

- No reverse engineering or derived code from existing proprietary libraries  
- Implementations are verified against public specifications and test vectors  
- Review process includes formal algorithm validation and peer verification  

---

## 🔐 Security Policy

Security is our top priority.

If you discover a vulnerability, **please do not open a public issue.**  
Instead, please follow the guidelines on the [CryptoHives Open Source Initiative Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md).

---

## ⚖️ License

Each component of the CryptoHives Open Source Initiative is licensed under a SPDX-compatible license.  
By default, packages use the following license tags:

```csharp
// SPDX-FileCopyrightText: <year> The Keepers of the CryptoHives
// SPDX-License-Identifier: MIT
```

Some inherited components may use alternative MIT license headers, according to their origin and specific requirements those headers are retained.

---

## 📝 No-Nonsense Matters

This project is released under the MIT License because open collaboration matters.  
However, the Keepers are well aware that MIT-licensed code often gets copied, repackaged, or commercialized without giving credit.  

If you use this code, please do so responsibly:
- Give visible credit to the **CryptoHives Open Source Initiative** or **The Keepers of the CryptoHives** and refer to the original source.
- Contribute improvements back and report issues.
- Don’t pretend you wrote it from scratch.

Open source thrives on respect, not just permissive licenses.

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
