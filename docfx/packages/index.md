# CryptoHives .NET Foundation Packages

Welcome to the CryptoHives .NET Foundation package documentation. 

## Available Packages

### Memory Package

**CryptoHives.Foundation.Memory** - Pooled buffers and memory management

High-performance buffer management and memory streams backed by `ArrayPool<T>.Shared` for reduced allocations and GC pressure.

**Key Features:**
- `ArrayPoolMemoryStream` - Memory stream using pooled buffers (read/write)
- `ArrayPoolBufferWriter<T>` - IBufferWriter implementation with pooled buffers
- `ReadOnlySequenceMemoryStream` - Stream wrapper to read from ReadOnlySequence
- `ObjectOwner<T>` - [RAII](https://en.wikipedia.org/wiki/Resource_acquisition_is_initialization) pattern for object pool management

**[Memory Package Documentation](memory/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Memory
```

**Quick Example:**
```csharp
using CryptoHives.Foundation.Memory.Buffers;

// Use lifetime managed pooled memory stream
using var stream = new ArrayPoolMemoryStream();
stream.Write(data);

// sequence becomes invalid when stream is disposed
ReadOnlySequence<byte> sequence = stream.GetReadOnlySequence();
```

---

### Threading Package

**CryptoHives.Foundation.Threading** - Pooled async synchronization primitives

Pooled async synchronization primitives that reduce allocations in high-throughput scenarios.

**Key Features:**
- `AsyncLock` - Pooled async mutual exclusion
- `AsyncAutoResetEvent` - Pooled async auto-reset event
- `AsyncManualResetEvent` - Pooled async manual-reset event
- **Includes ValueTask analyzers** - Automatically detects common misuse patterns

**[Threading Package Documentation](threading/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Threading
```

**Quick Example:**
```csharp
using CryptoHives.Foundation.Threading.Async.Pooled;

private readonly AsyncLock _lock = new();

public async Task AccessResourceAsync(CancellationToken ct)
{
    using (await _lock.LockAsync(ct))
    {
        // Thread-safe async access to shared resource
    }
}
```

> **Note:** This package includes the Threading Analyzers automatically. The analyzers are transitive, so any project that references a project using this package will also benefit from the ValueTask misuse detection.

---

### Security Packages

**CryptoHives.Foundation.Security.Cryptography** - Specification-based cryptographic implementations

Comprehensive suite of hash algorithms and MACs implemented as fully managed code without OS dependencies.

**Key Features:**
- SHA-1, SHA-2, SHA-3 family implementations
- SHAKE and cSHAKE extendable-output functions
- TurboSHAKE and KangarooTwelve (KT128/KT256) high-performance XOFs
- KMAC (Keccak Message Authentication Code)
- Ascon lightweight hashing (NIST FIPS 207)
- BLAKE2 and BLAKE3 high-performance hashing
- International standards: SM3, Streebog, Whirlpool
- Legacy algorithms: MD5, RIPEMD-160

**[Security Package Documentation](security/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

**Quick Example:**
```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;
using CryptoHives.Foundation.Security.Cryptography.Mac;

// SHA-256 hash
using var sha256 = SHA256.Create();
byte[] hash = sha256.ComputeHash(data);

// BLAKE3 with variable output
using var blake3 = Blake3.Create(outputBytes: 64);
byte[] longHash = blake3.ComputeHash(data);

// KMAC256 authentication
byte[] key = new byte[32];
using var kmac = KMac256.Create(key, outputBytes: 64, customization: "MyApp");
byte[] mac = kmac.ComputeHash(message);
```

---

### Threading Analyzers Package (Standalone)

**CryptoHives.Foundation.Threading.Analyzers** - Roslyn analyzers for ValueTask misuse detection

> **Note:** If you're using `CryptoHives.Foundation.Threading`, the analyzers are already included. This standalone package is for projects that want the analyzers without the Threading library.

Roslyn analyzers that detect common `ValueTask` misuse patterns at compile time. These analyzers help developers avoid subtle bugs and performance issues when working with `ValueTask` and the pooled async primitives.

**Key Features:**
- Detects multiple awaits on the same `ValueTask`
- Warns about blocking calls like `GetAwaiter().GetResult()`
- Identifies unsafe field storage of `ValueTask`
- Includes automatic code fixes

**[Threading Analyzers Documentation](threading.analyzers/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Threading.Analyzers
```

**Quick Example:**
```csharp
// ❌ CHT001: ValueTask awaited multiple times
ValueTask vt = GetValueTask();
await vt;
await vt; // Error!

// ✅ Correct: Use Preserve() for multiple awaits
ValueTask vt = GetValueTask();
ValueTask preserved = vt.Preserve();
await preserved;
await preserved; // Safe!
```

---

## Target Frameworks

All packages support:
- .NET 10.0
- .NET 8.0
- .NET Framework 4.6.2
- .NET Standard 2.1
- .NET Standard 2.0

Analyzers target .NET Standard 2.0 for maximum compatibility with all IDE and build scenarios.

## Getting Help

- 📖 [Full Documentation](https://cryptohives.github.io/Foundation/)
- 🚀 [Getting Started Guide](../getting-started.md)
- 🐛 [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- 💬 [Discussions](https://github.com/CryptoHives/Foundation/discussions)

## Package Links

| Package | NuGet | Documentation | Notes |
|---------|-------|---------------|-------|
| CryptoHives.Foundation.Memory | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Memory.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Memory) | [Docs](memory/index.md) | |
| CryptoHives.Foundation.Threading | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading) | [Docs](threading/index.md) | Includes analyzers |
| CryptoHives.Foundation.Threading.Analyzers | [![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Threading.Analyzers.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Threading.Analyzers) | [Docs](threading.analyzers/index.md) | Standalone |
| CryptoHives.Foundation.Security.Cryptography | *In Development* | [Docs](security/cryptography/index.md) | Hash & MAC |

---

© 2026 The Keepers of the CryptoHives
