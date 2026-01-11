## Getting Started with CryptoHives.Foundation libraries

Welcome to the CryptoHives .NET Foundation libraries! This guide will help you get started with the Memory and Threading packages.

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

## Next Steps

- Browse the [API documentation](api/index.md)
- Review [package documentation](packages/memory/index.md)

## Support

For issues and questions:
- [GitHub Issues](https://github.com/CryptoHives/Foundation/issues)
- [Security Policy](https://github.com/CryptoHives/Foundation/SECURITY.md)

---

© 2026 The Keepers of the CryptoHives
