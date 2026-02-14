# Extendable-Output Functions (XOF)

## Overview

An **Extendable-Output Function (XOF)** is a hash function that can produce an arbitrarily long output. Unlike traditional hash algorithms with a fixed digest size, XOFs allow callers to request as many output bytes as needed.

The CryptoHives Cryptography package exposes XOF functionality through the `IExtendableOutput` interface, providing a unified, allocation-free API across all supported algorithms.

## The `IExtendableOutput` Interface

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

public interface IExtendableOutput
{
    void Absorb(ReadOnlySpan<byte> input);
    void Squeeze(Span<byte> output);
    void Reset();
}
```

| Method | Description |
|--------|-------------|
| `Absorb` | Feeds input data into the XOF state. May be called multiple times before squeezing. |
| `Squeeze` | Extracts output bytes. The first call finalizes the hash; subsequent calls continue the output stream. |
| `Reset` | Resets the XOF state so the instance can be reused for a new computation. |

## Supported Algorithms

### Hash Algorithms

| Algorithm | Class | XOF Mechanism |
|-----------|-------|---------------|
| SHAKE128 | `Shake128` | Keccak sponge (rate 168) |
| SHAKE256 | `Shake256` | Keccak sponge (rate 136) |
| TurboSHAKE128 | `TurboShake128` | Keccak sponge (rate 168, reduced rounds) |
| TurboSHAKE256 | `TurboShake256` | Keccak sponge (rate 136, reduced rounds) |
| cSHAKE128 | `CShake128` | Keccak sponge with customization |
| cSHAKE256 | `CShake256` | Keccak sponge with customization |
| KT128 | `KT128` | KangarooTwelve (TurboSHAKE128-based) |
| KT256 | `KT256` | KangarooTwelve (TurboSHAKE256-based) |
| BLAKE3 | `Blake3` | Counter-mode output expansion |
| Ascon-XOF128 | `AsconXof128` | Ascon permutation sponge |

### MAC Algorithms

| Algorithm | Class | XOF Mechanism |
|-----------|-------|---------------|
| KMAC128 | `KMac128` | Keccak sponge with key (NIST SP 800-185) |
| KMAC256 | `KMac256` | Keccak sponge with key (NIST SP 800-185) |

## Usage

### Basic Absorb / Squeeze

```csharp
using var shake = Shake256.Create(64);

// Absorb input data
shake.Absorb(new byte[] { 0x01, 0x02, 0x03 });

// Squeeze output into a stack-allocated buffer
Span<byte> output = stackalloc byte[64];
shake.Squeeze(output);
```

### Multi-Absorb (Incremental Input)

Data can be absorbed in multiple calls before squeezing. The result is identical to absorbing all data at once:

```csharp
using var xof = TurboShake128.Create(32);

xof.Absorb(header);
xof.Absorb(payload);
xof.Absorb(footer);

Span<byte> digest = stackalloc byte[32];
xof.Squeeze(digest);
```

### Streaming Squeeze (Multi-Squeeze)

After the first `Squeeze` call finalizes the hash, subsequent calls continue the output stream. This is useful for producing large or incremental output without allocating a single large buffer:

```csharp
using var blake3 = Blake3.Create();
blake3.Absorb(data);

// Squeeze 256 bytes in 64-byte chunks
Span<byte> chunk = stackalloc byte[64];
for (int i = 0; i < 4; i++)
{
    blake3.Squeeze(chunk);
    ProcessChunk(chunk);
}
```

The output from multiple `Squeeze` calls is identical to a single call requesting the same total length:

```csharp
// These produce the same output:

// Option A: single call
xof.Squeeze(new byte[128]);

// Option B: two calls
xof.Squeeze(new byte[64]);
xof.Squeeze(new byte[64]);
```

### Reuse with Reset

The `Reset` method allows reusing an instance for a new computation without allocating a new object:

```csharp
using var xof = CShake256.Create(
    outputBytes: 32,
    functionName: "",
    customization: "session-key");

// First computation
xof.Absorb(input1);
Span<byte> hash1 = stackalloc byte[32];
xof.Squeeze(hash1);

// Reset and compute again
xof.Reset();
xof.Absorb(input2);
Span<byte> hash2 = stackalloc byte[32];
xof.Squeeze(hash2);
```

### Runtime Detection

Use pattern matching to detect XOF support on any hash algorithm:

```csharp
using System.Security.Cryptography;

HashAlgorithm algo = GetAlgorithm();

if (algo is IExtendableOutput xof)
{
    xof.Absorb(data);
    Span<byte> output = stackalloc byte[128];
    xof.Squeeze(output);
}
else
{
    byte[] hash = algo.ComputeHash(data);
}
```

### KMAC in XOF Mode

KMAC supports XOF output through the same interface, combining keyed authentication with variable-length output:

```csharp
using CryptoHives.Foundation.Security.Cryptography.Mac;

byte[] key = GetSecretKey();
using var kmac = KMac256.Create(key, outputBytes: 64, customization: "MyApp");

kmac.Absorb(message);

Span<byte> tag = stackalloc byte[64];
kmac.Squeeze(tag);
```

## Fixed-Output vs XOF Mode

All XOF algorithms also support the standard `HashAlgorithm` API with a fixed output size specified at construction:

```csharp
// Fixed-output mode (standard HashAlgorithm API)
using var shake = Shake256.Create(outputBytes: 32);
byte[] hash = shake.ComputeHash(data);           // Always 32 bytes

// XOF mode (IExtendableOutput API)
using var xof = Shake256.Create(outputBytes: 32);
xof.Absorb(data);
Span<byte> output = stackalloc byte[128];         // Any length
xof.Squeeze(output);
```

The `outputBytes` constructor parameter controls the size returned by `ComputeHash` and `TryHashFinal`. The `Squeeze` method ignores this parameter and fills the entire output span.

## Important Notes

- **No absorb after squeeze**: Once `Squeeze` is called, the hash is finalized. Further `Absorb` calls are not supported without calling `Reset` first.
- **Deterministic streaming**: Multiple `Squeeze` calls produce the same byte stream as a single large call. The output is fully deterministic.
- **Thread safety**: Like all hash algorithm instances, XOF instances are not thread-safe. Create separate instances for concurrent use.

## See Also

- [Hash Algorithms Reference](hash-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
- [SHAKE Test Vectors](specs/SHAKE-vectors.md)

---

© 2026 The Keepers of the CryptoHives
