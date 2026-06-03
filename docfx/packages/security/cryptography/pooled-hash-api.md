# Pooled Static Hash API

This page documents the static `HashData` and `TryHashData` one-shot methods available on every hash algorithm in this package, explains the pooling strategy behind them, and shows expected allocation savings compared to creating a new instance for each call.

## Motivation

Every hash algorithm in this package extends `System.Security.Cryptography.HashAlgorithm`. Creating a new instance for each hash operation allocates the full internal state on the managed heap — from 72 bytes for the compact SHA-2 variants up to ~2.9 KB for BLAKE3. In high-throughput scenarios (network request validation, file integrity pipelines, blockchain transaction processing) this results in measurable GC pressure.

The standard solution for .NET's built-in algorithms (e.g. `System.Security.Cryptography.SHA256.HashData(...)`) is a static one-shot method backed by a thread-local or pooled instance. This package provides the same pattern for every supported algorithm.

## API

Each algorithm exposes two static methods:

```csharp
// Write result into a caller-provided buffer — zero heap allocation on the hot path
public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten);

// Allocate and return a new byte[] — convenience overload
public static byte[] HashData(ReadOnlySpan<byte> source);
```

Algorithms with configurable output sizes (Streebog, Kupyna, LSH-256, LSH-512) expose an additional `hashSizeBytes` parameter:

```csharp
public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, int hashSizeBytes, out int bytesWritten);
public static byte[]  HashData(ReadOnlySpan<byte> source, int hashSizeBytes);
```

### Example — zero-allocation path

```csharp
Span<byte> hash = stackalloc byte[32];

if (SHA256.TryHashData(data, hash, out int written))
{
    // 'hash' contains the SHA-256 result — no heap allocation occurred
}
```

### Example — convenience allocating overload

```csharp
byte[] digest = Blake3.HashData(data);
```

### Example — parameterised output size

```csharp
// Compute a Streebog-256 digest (32-byte output)
byte[] digest256 = Streebog.HashData(data, hashSizeBytes: 32);

// Compute a Kupyna-384 digest (48-byte output)
Span<byte> buf = stackalloc byte[48];
Kupyna.TryHashData(data, buf, hashSizeBytes: 48, out _);
```

## Pooling Implementation

### `IResettable` on the base class

`HashAlgorithm` implements `Microsoft.Extensions.ObjectPool.IResettable`. `TryReset()` delegates to the existing `Initialize()` method, which every concrete hash already overrides to return the algorithm state to its initial value. This means pooled reuse is safe with no additional work in the concrete classes.

```csharp
// HashAlgorithm base class
public bool TryReset()
{
    Initialize();
    return true;
}
```

### Generic pool — `HashAlgorithmPool<T>`

Algorithms with a parameter-free default constructor (everything except the size-parameterised regional algorithms) use a `DefaultObjectPool<T>` backed by the `IResettable` contract:

```csharp
// Equivalent internal implementation
private static readonly ObjectPool<SHA256> _pool = new DefaultObjectPool<SHA256>(
    new DefaultPooledObjectPolicy<SHA256>());

public static bool TryHashData(ReadOnlySpan<byte> source, Span<byte> destination, out int bytesWritten)
{
    var hasher = _pool.Get();
    try
    {
        return hasher.TryComputeHash(source, destination, out bytesWritten);
    }
    finally
    {
        _pool.Return(hasher);   // calls TryReset() → Initialize()
    }
}
```

The pool is a static field on `HashAlgorithmPool<T>`, so it is initialised once per concrete type and shared across all threads for the lifetime of the application.

### Delegate pool — `HashAlgorithmPool.CreatePool<T>(Func<T>)`

Algorithms that require constructor arguments to select an output size (Streebog, Kupyna, Lsh256, Lsh512) maintain one pool per supported variant. A lightweight `DelegatePoolPolicy<T>` wraps the factory delegate:

```csharp
// Internal initialisation in e.g. Streebog
private static readonly ObjectPool<Streebog> _pool256 =
    HashAlgorithmPool.CreatePool(() => new Streebog(32));

private static readonly ObjectPool<Streebog> _pool512 =
    HashAlgorithmPool.CreatePool(() => new Streebog(64));
```

`Return` calls `TryReset()` via the same `IResettable` path, so the pooled instance is ready for the next caller.

### Exclusions

The following variants are intentionally excluded from pooling because their per-call state (key material, customisation string, or output size) cannot be expressed through a parameter-free reset:

| Variant | Reason |
|---------|--------|
| `Blake2b.CreateKeyed(...)` | Key is baked into the IV during `Initialize()` |
| `Blake2s.CreateKeyed(...)` | Same as above |
| `Blake3.CreateKeyed(...)` | Key material stored in the algorithm state |
| `Blake3` derive-key mode | Different mode flag changes the IV entirely |
| `cSHAKE128 / cSHAKE256` | Function-name and customisation-string bytes prepended at `Initialize()` |
| `TurboSHAKE128/256` with custom domain | Domain separator is a constructor parameter |

For these variants, create instances explicitly with `using` and reuse them per-scope where appropriate.

---

## Allocation Savings

The following table shows the allocation avoided per `HashData` call by reusing a pooled instance instead of creating a new one. Values are **managed heap bytes**, derived from the object state and buffer sizes listed in the [benchmarks page](benchmarks.md#hash-algorithms). Managed object overhead (~24 bytes per object header + method-table pointer on 64-bit) is included in the _Instance overhead_ column.

> Actual saving equals **Instance state + Internal arrays + Object overhead**. Static lookup tables are not included because they are shared across all instances and loaded only once.

### SHA-2 Family

| Algorithm | Output | Instance state | Internal arrays | Object overhead | **Saving per call** |
|-----------|--------|---------------|-----------------|-----------------|---------------------|
| SHA-224   | 28 B   | 32 B (uint[8]) | 64 B (byte[64] buffer) | 24 B | **120 B** |
| SHA-256   | 32 B   | 32 B (uint[8]) | 64 B (byte[64] buffer) | 24 B | **120 B** |
| SHA-384   | 48 B   | 64 B (ulong[8]) | 128 B (byte[128] buffer) | 24 B | **216 B** |
| SHA-512   | 64 B   | 64 B (ulong[8]) | 128 B (byte[128] buffer) | 24 B | **216 B** |
| SHA-512/224 | 28 B | 64 B (ulong[8]) | 128 B (byte[128] buffer) | 24 B | **216 B** |
| SHA-512/256 | 32 B | 64 B (ulong[8]) | 128 B (byte[128] buffer) | 24 B | **216 B** |

### SHA-3 / Keccak / SHAKE Family

| Algorithm | Output | Instance state | Internal arrays | Object overhead | **Saving per call** |
|-----------|--------|---------------|-----------------|-----------------|---------------------|
| SHA3-224  | 28 B   | 200 B (Keccak state) | 144 B (byte[rate]) | 24 B | **368 B** |
| SHA3-256  | 32 B   | 200 B | 136 B | 24 B | **360 B** |
| SHA3-384  | 48 B   | 200 B | 104 B | 24 B | **328 B** |
| SHA3-512  | 64 B   | 200 B | 72 B | 24 B | **296 B** |
| SHAKE128 (default 32 B) | 32 B | 200 B | 168 B | 24 B | **392 B** |
| SHAKE256 (default 64 B) | 64 B | 200 B | 136 B | 24 B | **360 B** |
| TurboSHAKE128 (default 32 B) | 32 B | 200 B | 168 B | 24 B | **392 B** |
| TurboSHAKE256 (default 64 B) | 64 B | 200 B | 136 B | 24 B | **360 B** |
| KT128 (default 32 B) | 32 B | 200 B | 168 B | 24 B | **392 B** |
| KT256 (default 64 B) | 64 B | 200 B | 136 B | 24 B | **360 B** |
| Keccak-256 | 32 B | 200 B | 136 B | 24 B | **360 B** |
| Keccak-384 | 48 B | 200 B | 104 B | 24 B | **328 B** |
| Keccak-512 | 64 B | 200 B | 72 B | 24 B | **296 B** |

### BLAKE Family

| Algorithm | Output | Instance state | Internal arrays | Object overhead | **Saving per call** |
|-----------|--------|---------------|-----------------|-----------------|---------------------|
| BLAKE2b (unkeyed, default 64 B) | 64 B | 64 B (ulong[8]) | 128 B (byte[128]) | 24 B | **216 B** |
| BLAKE2s (unkeyed, default 32 B) | 32 B | 32 B (uint[8]) | 64 B (byte[64]) | 24 B | **120 B** |
| BLAKE3 (default 32 B) | 32 B | ~1 KB (CV stack) + ~1 KB (chunk) | 768 B | 24 B | **~2,840 B** |

BLAKE3 benefits the most from pooling due to its large Merkle-tree internal state.

### Ascon Family

| Algorithm | Output | Instance state | Internal arrays | Object overhead | **Saving per call** |
|-----------|--------|---------------|-----------------|-----------------|---------------------|
| Ascon-Hash256 | 32 B | 40 B (ulong[5]) | 8 B (byte[8]) | 24 B | **72 B** |
| Ascon-XOF128 (default 32 B) | 32 B | 40 B (ulong[5]) | 8 B (byte[8]) | 24 B | **72 B** |

### Regional Algorithms

| Algorithm | Output | Instance state | Internal arrays | Object overhead | **Saving per call** |
|-----------|--------|---------------|-----------------|-----------------|---------------------|
| RIPEMD-160 | 20 B | 20 B (uint[5]) | 64 B (byte[64]) | 24 B | **108 B** |
| SM3 | 32 B | 32 B (uint[8]) | 64 B (byte[64]) | 24 B | **120 B** |
| Whirlpool | 64 B | 64 B (ulong[8]) | 64 B (byte[64]) | 24 B | **152 B** |
| Streebog-256 | 32 B | 192 B (3 × ulong[8]) | 64 B (byte[64]) | 24 B | **280 B** |
| Streebog-512 | 64 B | 192 B (3 × ulong[8]) | 64 B (byte[64]) | 24 B | **280 B** |
| Kupyna-256 | 32 B | 64 B (ulong[8] state) + 64 B (scratch) | 64 B (byte[64]) | 24 B | **216 B** |
| Kupyna-384 | 48 B | 128 B (ulong[16] state) + 128 B (scratch) | 128 B (byte[128]) | 24 B | **408 B** |
| Kupyna-512 | 64 B | 128 B (ulong[16] state) + 128 B (scratch) | 128 B (byte[128]) | 24 B | **408 B** |
| LSH-256/224 | 28 B | 256 B (CV + submsg) | 128 B (byte[128]) | 24 B | **408 B** |
| LSH-256/256 | 32 B | 256 B (CV + submsg) | 128 B (byte[128]) | 24 B | **408 B** |
| LSH-512/224 | 28 B | 512 B (CV + submsg) | 256 B (byte[256]) | 24 B | **792 B** |
| LSH-512/256 | 32 B | 512 B (CV + submsg) | 256 B (byte[256]) | 24 B | **792 B** |
| LSH-512/384 | 48 B | 512 B (CV + submsg) | 256 B (byte[256]) | 24 B | **792 B** |
| LSH-512/512 | 64 B | 512 B (CV + submsg) | 256 B (byte[256]) | 24 B | **792 B** |

### Legacy Algorithms

| Algorithm | Output | Instance state | Internal arrays | Object overhead | **Saving per call** |
|-----------|--------|---------------|-----------------|-----------------|---------------------|
| SHA-1 _(obsolete)_ | 20 B | 20 B (uint[5]) + 320 B (uint[80] W) | 64 B (byte[64]) | 24 B | **428 B** |
| MD5 _(obsolete)_ | 16 B | 16 B (uint[4]) | 64 B (byte[64]) | 24 B | **104 B** |

> SHA-1 and MD5 are marked `[Obsolete]` and included for legacy interoperability only. The static `HashData` and `TryHashData` methods on these classes preserve the same `[Obsolete]` attribute so that callers receive the same compiler warning at the call site.

---

## Usage Recommendations

| Scenario | Recommended API |
|----------|----------------|
| Single call, result as byte array | `byte[] d = SHA256.HashData(data)` |
| Single call, zero allocation | `SHA256.TryHashData(data, dest, out _)` |
| Multiple calls in a loop | `SHA256.TryHashData(...)` — pool shared across all iterations |
| Streaming / chunked input | Create instance with `SHA256.Create()`, call `AppendData` / `GetHashAndReset` |
| Keyed hash (MAC mode) | `Blake2b.CreateKeyed(...)` or `KMAC128` — pooling not applicable |
| Custom output length | `Streebog.HashData(data, 32)` / `Kupyna.TryHashData(data, dest, 64, out _)` |

---

## See also

- [Hash Algorithms Reference](hash-algorithms.md)
- [XOF Mode (Extendable-Output)](xof-mode.md)
- [Benchmarks — Memory Footprint](benchmarks.md#hash-algorithms)
- [MAC Algorithms Reference](mac-algorithms.md)
