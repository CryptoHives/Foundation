# CryptoHives.Foundation.Security.Cryptography Package

## Overview

The Cryptography package provides specification-based implementations of cryptographic hash algorithms and message authentication codes (MACs) for .NET applications. All implementations are fully managed code that does not rely on OS or hardware cryptographic APIs, ensuring deterministic and consistent behavior across all platforms.

## Key Features

- **Specification-Based Implementations**: Written based on official specifications (NIST, RFC, ISO)
- **No OS Dependencies**: Works identically on all platforms without calling OS crypto APIs
- **Comprehensive Coverage**: SHA-1/2/3, BLAKE2/3, KMAC, and many more
- **Variable Output**: XOF support for SHAKE, cSHAKE, KMAC, and BLAKE3
- **Keyed Hashing**: Built-in MAC modes for BLAKE2, BLAKE3, and KMAC
- **Standards Compliant**: Verified against NIST, RFC, and ISO test vectors

## Installation

```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

> **Note:** This package is currently in development and not yet published to NuGet.
> The focus is currently on stability and validation of the algorithms against test
> vectors and other implementations.
> Once stabilized, perf improvements and zero allocation support become the next priority.

## Namespaces

### Hash Algorithms

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;
```

### Message Authentication Codes

```csharp
using CryptoHives.Foundation.Security.Cryptography.Mac;
```

## Implemented Algorithms

### Hash Algorithms

| Family | Algorithms | Documentation |
|--------|------------|---------------|
| SHA-2 | SHA-224, SHA-256, SHA-384, SHA-512, SHA-512/224, SHA-512/256 | [Details](hash-algorithms.md#sha-2-family) |
| SHA-3 | SHA3-224, SHA3-256, SHA3-384, SHA3-512 | [Details](hash-algorithms.md#sha-3-family) |
| SHAKE | SHAKE128, SHAKE256 (XOF) | [Details](hash-algorithms.md#shake-xof) |
| cSHAKE | cSHAKE128, cSHAKE256 (Customizable XOF) | [Details](hash-algorithms.md#cshake) |
| TurboSHAKE | TurboSHAKE128, TurboSHAKE256 (High-performance XOF) | [Details](hash-algorithms.md#turboshake) |
| KangarooTwelve | KT128, KT256 (Parallelizable XOF) | [Details](hash-algorithms.md#kangarootwelve-kt) |
| Keccak | Keccak-256, Keccak-384, Keccak-512 (Ethereum compatible) | [Details](hash-algorithms.md#keccak) |
| Ascon | Ascon-Hash256, Ascon-XOF128 (Lightweight) | [Details](hash-algorithms.md#ascon) |
| BLAKE2 | BLAKE2b (1-64 bytes), BLAKE2s (1-32 bytes) | [Details](hash-algorithms.md#blake2) |
| BLAKE3 | BLAKE3 (variable output, keyed, derive key) | [Details](hash-algorithms.md#blake3) |
| RIPEMD | RIPEMD-160 | [Details](hash-algorithms.md#ripemd) |
| SM3 | SM3 (Chinese standard) | [Details](hash-algorithms.md#sm3) |
| Whirlpool | Whirlpool (ISO standard) | [Details](hash-algorithms.md#whirlpool) |
| Streebog | Streebog-256, Streebog-512 (Russian standard) | [Details](hash-algorithms.md#streebog) |
| Legacy | SHA-1, MD5 (deprecated) | [Details](hash-algorithms.md#legacy) |

### Message Authentication Codes (MAC)

| Algorithm | Security | Documentation |
|-----------|----------|---------------|
| KMAC128 | 128 bits | [Details](mac-algorithms.md#kmac128) |
| KMAC256 | 256 bits | [Details](mac-algorithms.md#kmac256) |
| BLAKE2b (keyed) | Up to 256 bits | [Details](mac-algorithms.md#blake2-mac) |
| BLAKE2s (keyed) | Up to 128 bits | [Details](mac-algorithms.md#blake2-mac) |
| BLAKE3 (keyed) | 128 bits | [Details](mac-algorithms.md#blake3-mac) |

## Quick Examples

### Basic Hashing

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

// SHA-256
using var sha256 = SHA256.Create();
byte[] hash = sha256.ComputeHash(data);

// SHA3-256
using var sha3 = SHA3_256.Create();
byte[] sha3Hash = sha3.ComputeHash(data);

// BLAKE3
using var blake3 = Blake3.Create();
byte[] blake3Hash = blake3.ComputeHash(data);
```

### Variable-Length Output (XOF)

```csharp
// SHAKE256 with 64-byte output
using var shake = Shake256.Create(outputBytes: 64);
byte[] output = shake.ComputeHash(data);

// BLAKE3 with 128-byte output
using var blake3 = Blake3.Create(outputBytes: 128);
byte[] longHash = blake3.ComputeHash(data);
```

### Customizable Hash (cSHAKE)

```csharp
// cSHAKE256 with customization string
using var cshake = new CShake256(
    outputBytes: 64,
    functionName: "",
    customization: "My Application");
byte[] customHash = cshake.ComputeHash(data);
```

### Message Authentication Code (KMAC)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Mac;

byte[] key = new byte[32]; // Your secret key

// KMAC256
using var kmac = Kmac256.Create(key, outputBytes: 64, customization: "MyApp");
byte[] mac = kmac.ComputeHash(message);
```

### Keyed Hashing with BLAKE3

```csharp
byte[] key = new byte[32]; // Must be exactly 32 bytes

// BLAKE3 keyed mode
using var blake3 = Blake3.CreateKeyed(key);
byte[] mac = blake3.ComputeHash(message);
```

### Key Derivation with BLAKE3

```csharp
string context = "MyApp 2025-01-01 session key";

// BLAKE3 derive key mode
using var blake3 = Blake3.CreateDeriveKey(context);
byte[] derivedKey = blake3.ComputeHash(inputKeyMaterial);
```

### Incremental Hashing

```csharp
using var sha256 = SHA256.Create();

// Process data in chunks
sha256.TransformBlock(chunk1, 0, chunk1.Length, null, 0);
sha256.TransformBlock(chunk2, 0, chunk2.Length, null, 0);
sha256.TransformFinalBlock(chunk3, 0, chunk3.Length);

byte[] hash = sha256.Hash;
```

## Algorithm Selection Guide

### For General Purpose Hashing

| Use Case | Recommended | Alternative |
|----------|-------------|-------------|
| Modern applications | SHA3-256 or BLAKE3 | SHA-256 |
| High performance needed | BLAKE3 | BLAKE2b |
| Memory constrained | BLAKE2s | SHA-256 |
| Variable output needed | SHAKE256 or BLAKE3 | - |
| NIST compliance required | SHA-256 or SHA3-256 | SHA-384, SHA-512 |

### For Message Authentication

| Use Case | Recommended | Alternative |
|----------|-------------|-------------|
| Modern applications | KMAC256 | BLAKE3 keyed |
| High performance | BLAKE3 keyed | BLAKE2b keyed |
| NIST compliance | KMAC128/256 | - |
| Short tags (≤16 bytes) | BLAKE2s keyed | KMAC128 |

### For Specific Domains

| Domain | Algorithm | Notes |
|--------|-----------|-------|
| Ethereum/Blockchain | Keccak-256 | Uses original Keccak padding |
| Bitcoin addresses | RIPEMD-160 | Combined with SHA-256 |
| Chinese systems | SM3 | GB/T 32905-2016 |
| Russian systems | Streebog | GOST R 34.11-2012 |

## Standards Compliance

All implementations are verified against official test vectors:

- **NIST FIPS 180-4**: SHA-1, SHA-2 family
- **NIST FIPS 202**: SHA-3, SHAKE
- **NIST SP 800-185**: cSHAKE, KMAC
- **RFC 7693**: BLAKE2
- **BLAKE3 Specification**: BLAKE3
- **GB/T 32905-2016**: SM3
- **GOST R 34.11-2012 / RFC 6986**: Streebog
- **ISO/IEC 10118-3**: Whirlpool

See the [Cryptographic Specifications](specs/README.md) for detailed test vectors and implementation status.

## Performance Considerations

### Allocation-Free Operations

All hash algorithms support `Span<T>`-based APIs for zero-allocation hashing:

```csharp
Span<byte> destination = stackalloc byte[32];
using var sha256 = SHA256.Create();
sha256.TryComputeHash(data, destination, out int bytesWritten);
```

### Recommended for High Throughput

- **BLAKE3**: Designed for parallel processing, fastest on modern CPUs
- **BLAKE2b**: Faster than SHA-256 on 64-bit systems
- **BLAKE2s**: Faster than SHA-256 on 32-bit systems

### Memory Usage

All implementations use fixed-size internal buffers based on their block size. No dynamic allocations occur during hashing operations.

## Comparison with System.Security.Cryptography

| Feature | CryptoHives | System.Security.Cryptography |
|---------|-------------|------------------------------|
| OS dependency | None | Uses CNG/OpenSSL |
| Cross-platform consistency | Guaranteed | May vary |
| Hardware acceleration | No | Yes (when available) |
| SHA-3 support | Full | .NET 8+ only |
| BLAKE2/3 support | Yes | No |
| Keccak-256 (Ethereum) | Yes | No |
| KMAC support | Yes | .NET 9+ only |
| SM3/Streebog/Whirlpool | Yes | No |

## Thread Safety

All hash algorithm instances are **not thread-safe**. Create separate instances for concurrent operations or use synchronization.

```csharp
// Thread-safe pattern
public byte[] ComputeHashThreadSafe(byte[] data)
{
    using var sha256 = SHA256.Create(); // New instance per call
    return sha256.ComputeHash(data);
}
```

## See Also

- [Hash Algorithms Reference](hash-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
- [Cryptographic Specifications](specs/README.md)
- [Security Package Overview](../index.md)

---

© 2026 The Keepers of the CryptoHives
