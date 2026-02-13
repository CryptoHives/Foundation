## Getting Started with CryptoHives.Foundation libraries

Welcome to the CryptoHives .NET Foundation libraries! This guide will help you get started with the Memory, Threading, and Security.Cryptography packages.

## Installation

### CryptoHives.Foundation.Memory

Install via NuGet Package Manager:

```bash
dotnet add package CryptoHives.Foundation.Memory
```

Or via Package Manager Console:

```powershell
Install-Package CryptoHives.Foundation.Memory
```

### CryptoHives.Foundation.Threading

Install via NuGet Package Manager:

```bash
dotnet add package CryptoHives.Foundation.Threading
```

Or via Package Manager Console:

```powershell
Install-Package CryptoHives.Foundation.Threading
```

### CryptoHives.Foundation.Threading.Analyzers

The analyzers standalone package provides Roslyn analyzers to help detect common `ValueTask` misuse patterns at compile time.
The package is only needed for use cases where the consuming project does not already reference the Threading package.

Install via NuGet Package Manager:

```bash
dotnet add package CryptoHives.Foundation.Threading.Analyzers
```

Or via Package Manager Console:

```powershell
Install-Package CryptoHives.Foundation.Threading.Analyzers
```

### CryptoHives.Foundation.Security.Cryptography

The Cryptography package provides specification-based implementations of cryptographic hash algorithms and MACs.

Install via NuGet Package Manager (when available):

```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

Or via Package Manager Console:

```powershell
Install-Package CryptoHives.Foundation.Security.Cryptography
```

## Quick Start

### Memory Package

The Memory package provides high-performance, pool based buffer management utilities:

```csharp
using CryptoHives.Foundation.Memory.Buffers;

// Create a memory stream backed by array pool
using var stream = new ArrayPoolMemoryStream();
stream.Write(data);

// Get a zero-copy ReadOnlySequence
ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();
```

[Learn more about the Memory package](packages/memory/index.md)

### Threading Package

The Threading package provides pooled async synchronization primitives:

```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

// Use pooled async lock
using var lockInstance = new AsyncLock();
using (await lockInstance.LockAsync())
{
    // Critical section
}
```

[Learn more about the Threading package](packages/threading/index.md)

### Security.Cryptography Package

The Cryptography package provides specification-based hash algorithm and MAC implementations.
All CryptoHives algorithms inherit from `System.Security.Cryptography.HashAlgorithm` and support two ways of computing a hash:

#### Zero-allocation approach (recommended)

Use `TryComputeHash` with a stack-allocated or reusable buffer to avoid heap allocations entirely.
This is the preferred approach for performance-critical code such as tight loops, network packet processing, or blockchain validation.
CryptoHives provides a polyfill so this API works on every target framework, including .NET Framework 4.x.

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;
using CryptoHives.Foundation.Security.Cryptography.Mac;

// SHA-256 — zero allocations
using var sha256 = SHA256.Create();
Span<byte> hash = stackalloc byte[32];
sha256.TryComputeHash(data, hash, out _);

// SHA3-256 — zero allocations
using var sha3 = SHA3_256.Create();
Span<byte> sha3Hash = stackalloc byte[32];
sha3.TryComputeHash(data, sha3Hash, out _);

// BLAKE3 with variable output — zero allocations
using var blake3 = Blake3.Create(outputBytes: 64);
Span<byte> longHash = stackalloc byte[64];
blake3.TryComputeHash(data, longHash, out _);

// KMAC256 authentication — zero allocations
byte[] key = new byte[32];
using var kmac = KMac256.Create(key, outputBytes: 64, customization: "MyApp");
Span<byte> mac = stackalloc byte[64];
kmac.TryComputeHash(message, mac, out _);
```

#### Simple approach

Use `ComputeHash` when convenience matters more than performance.
This allocates a new `byte[]` for every call, which adds GC pressure in hot paths.

```csharp
using var sha256 = SHA256.Create();
byte[] hash = sha256.ComputeHash(data);
```

[Learn more about the Security.Cryptography package](packages/security/cryptography/index.md)

## Next Steps

- Browse the [Package Documentation](packages/index.md)
- Review [Memory Package](packages/memory/index.md)
- Review [Threading Package](packages/threading/index.md)
- Review [Security.Cryptography Package](packages/security/cryptography/index.md)

## Support

For issues and questions:
- [GitHub Issues](https://github.com/CryptoHives/Foundation/issues)
- [Security Policy](https://github.com/CryptoHives/Foundation/SECURITY.md)

---

© 2026 The Keepers of the CryptoHives
