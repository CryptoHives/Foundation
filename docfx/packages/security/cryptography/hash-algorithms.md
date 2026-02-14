# Hash Algorithms Reference

This page provides detailed documentation for all hash algorithms implemented in the CryptoHives.Foundation.Security.Cryptography package.

## Namespace

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;
```

## Best Practices: Zero-Allocation Hashing

All hash algorithms in this package inherit from `System.Security.Cryptography.HashAlgorithm`, which provides two APIs for computing hashes:

| API | Allocations | Availability |
|-----|-------------|--------------|
| `ComputeHash(byte[])` | Allocates a new `byte[]` for the result on every call | All frameworks |
| `TryComputeHash(ReadOnlySpan<byte>, Span<byte>, out int)` | **Zero allocations** — writes directly into a caller-provided buffer | All frameworks (polyfilled) |

For **performance-critical code**, prefer `TryComputeHash` with a stack-allocated or reusable buffer:

```csharp
using var sha256 = SHA256.Create();

ReadOnlySpan<byte> input = data;
Span<byte> hash = stackalloc byte[sha256.HashSize / 8]; // 32 bytes for SHA-256

if (sha256.TryComputeHash(input, hash, out int bytesWritten))
{
    // 'hash' contains the result — no heap allocation occurred
}
```

The `ComputeHash(byte[])` method internally allocates a new `byte[]` of `HashSize / 8` bytes for each call. In tight loops or high-throughput pipelines (network packet processing, file integrity checking, blockchain validation), these allocations add GC pressure and reduce performance. The `TryComputeHash` span-based API avoids this entirely by letting the caller control the output buffer.

> **Note:** The CryptoHives `HashAlgorithm` base class provides a `TryComputeHash` polyfill for .NET Framework 4.x and .NET Standard 2.0 targets, where the BCL does not include this method. All CryptoHives hash algorithms support the zero-allocation code path on every target framework.

All usage examples below use the zero-allocation `TryComputeHash` API.

---

## SHA-2 Family

The SHA-2 family of hash functions defined in NIST FIPS 180-4.

### SHA-224

```csharp
public sealed class SHA224 : HashAlgorithm
```

**Properties:**
- Hash Size: 224 bits (28 bytes)
- Block Size: 64 bytes
- Based on: SHA-256 with different IV and truncated output

**Usage:**
```csharp
using var sha224 = SHA224.Create();
Span<byte> hash = stackalloc byte[28];
sha224.TryComputeHash(data, hash, out _);
```

### SHA-256

```csharp
public sealed class SHA256 : HashAlgorithm
```

**Properties:**
- Hash Size: 256 bits (32 bytes)
- Block Size: 64 bytes
- Most widely used hash algorithm

**Usage:**
```csharp
using var sha256 = SHA256.Create();
Span<byte> hash = stackalloc byte[32];
sha256.TryComputeHash(data, hash, out _);
```

### SHA-384

```csharp
public sealed class SHA384 : HashAlgorithm
```

**Properties:**
- Hash Size: 384 bits (48 bytes)
- Block Size: 128 bytes
- Based on: SHA-512 with different IV and truncated output

**Usage:**
```csharp
using var sha384 = SHA384.Create();
Span<byte> hash = stackalloc byte[48];
sha384.TryComputeHash(data, hash, out _);
```

### SHA-512

```csharp
public sealed class SHA512 : HashAlgorithm
```

**Properties:**
- Hash Size: 512 bits (64 bytes)
- Block Size: 128 bytes
- Faster than SHA-256 on 64-bit systems

**Usage:**
```csharp
using var sha512 = SHA512.Create();
Span<byte> hash = stackalloc byte[64];
sha512.TryComputeHash(data, hash, out _);
```

### SHA-512/224

```csharp
public sealed class SHA512_224 : HashAlgorithm
```

**Properties:**
- Hash Size: 224 bits (28 bytes)
- Block Size: 128 bytes
- SHA-512 with truncated output, faster on 64-bit systems

**Usage:**
```csharp
using var sha512_224 = SHA512_224.Create();
Span<byte> hash = stackalloc byte[28];
sha512_224.TryComputeHash(data, hash, out _);
```

### SHA-512/256

```csharp
public sealed class SHA512_256 : HashAlgorithm
```

**Properties:**
- Hash Size: 256 bits (32 bytes)
- Block Size: 128 bytes
- SHA-512 with truncated output, faster on 64-bit systems

**Usage:**
```csharp
using var sha512_256 = SHA512_256.Create();
Span<byte> hash = stackalloc byte[32];
sha512_256.TryComputeHash(data, hash, out _);
```

---

## SHA-3 Family

The SHA-3 family of hash functions defined in NIST FIPS 202.

### SHA3-224

```csharp
public sealed class SHA3_224 : HashAlgorithm
```

**Properties:**
- Hash Size: 224 bits (28 bytes)
- Block Size: 144 bytes (rate)
- Capacity: 448 bits

**Usage:**
```csharp
using var sha3 = SHA3_224.Create();
Span<byte> hash = stackalloc byte[28];
sha3.TryComputeHash(data, hash, out _);
```

### SHA3-256

```csharp
public sealed class SHA3_256 : HashAlgorithm
```

**Properties:**
- Hash Size: 256 bits (32 bytes)
- Block Size: 136 bytes (rate)
- Capacity: 512 bits

**Usage:**
```csharp
using var sha3 = SHA3_256.Create();
Span<byte> hash = stackalloc byte[32];
sha3.TryComputeHash(data, hash, out _);
```

### SHA3-384

```csharp
public sealed class SHA3_384 : HashAlgorithm
```

**Properties:**
- Hash Size: 384 bits (48 bytes)
- Block Size: 104 bytes (rate)
- Capacity: 768 bits

**Usage:**
```csharp
using var sha3 = SHA3_384.Create();
Span<byte> hash = stackalloc byte[48];
sha3.TryComputeHash(data, hash, out _);
```

### SHA3-512

```csharp
public sealed class SHA3_512 : HashAlgorithm
```

**Properties:**
- Hash Size: 512 bits (64 bytes)
- Block Size: 72 bytes (rate)
- Capacity: 1024 bits

**Usage:**
```csharp
using var sha3 = SHA3_512.Create();
Span<byte> hash = stackalloc byte[64];
sha3.TryComputeHash(data, hash, out _);
```

---

## SHAKE XOF

Extendable-Output Functions (XOF) from NIST FIPS 202.

### Shake128

```csharp
public sealed class Shake128 : HashAlgorithm
```

**Properties:**
- Output Size: Variable (specify at creation)
- Security: 128 bits
- Block Size: 168 bytes (rate)

**Usage:**
```csharp
// Default 32-byte output
using var shake = Shake128.Create();
Span<byte> hash = stackalloc byte[32];
shake.TryComputeHash(data, hash, out _);

// Custom output size
using var shake64 = Shake128.Create(outputBytes: 64);
Span<byte> longHash = stackalloc byte[64];
shake64.TryComputeHash(data, longHash, out _);
```

> **XOF Mode:** SHAKE128 implements [`IExtendableOutput`](xof-mode.md) for streaming variable-length output via `Absorb` / `Squeeze`.

### Shake256

```csharp
public sealed class Shake256 : HashAlgorithm
```

**Properties:**
- Output Size: Variable (specify at creation)
- Security: 256 bits
- Block Size: 136 bytes (rate)

**Usage:**
```csharp
// Default 64-byte output
using var shake = Shake256.Create();
Span<byte> hash = stackalloc byte[64];
shake.TryComputeHash(data, hash, out _);

// Custom output size
using var shake128 = Shake256.Create(outputBytes: 128);
Span<byte> longHash = stackalloc byte[128];
shake128.TryComputeHash(data, longHash, out _);
```

> **XOF Mode:** SHAKE256 implements [`IExtendableOutput`](xof-mode.md) for streaming variable-length output via `Absorb` / `Squeeze`.

---

## cSHAKE

Customizable SHAKE functions from NIST SP 800-185.

### CShake128

```csharp
public sealed class CShake128 : HashAlgorithm
```

**Properties:**
- Output Size: Variable
- Security: 128 bits
- Supports: Function name (N) and customization string (S)

**Usage:**
```csharp
// With customization
using var cshake = new CShake128(
    outputBytes: 32,
    functionName: "",
    customization: "My Application");
Span<byte> hash = stackalloc byte[32];
cshake.TryComputeHash(data, hash, out _);
```

### CShake256

```csharp
public sealed class CShake256 : HashAlgorithm
```

**Properties:**
- Output Size: Variable
- Security: 256 bits
- Supports: Function name (N) and customization string (S)

**Usage:**
```csharp
// With customization
using var cshake = new CShake256(
    outputBytes: 64,
    functionName: "",
    customization: "My Application");
Span<byte> hash = stackalloc byte[64];
cshake.TryComputeHash(data, hash, out _);
```

**Note:** When both N and S are empty, cSHAKE is equivalent to SHAKE.

> **XOF Mode:** cSHAKE128 and cSHAKE256 implement [`IExtendableOutput`](xof-mode.md) for streaming variable-length output via `Absorb` / `Squeeze`.

---

## TurboSHAKE

High-performance XOFs from RFC 9861 (Reduced-round Keccak).

### TurboShake128

```csharp
public sealed class TurboShake128 : HashAlgorithm
```

**Properties:**
- Output Size: Variable (default 32 bytes)
- Security: 128 bits
- Permutation: Keccak-p[1600,12] (12 rounds)
- Rate: 168 bytes
- Supports: Customization string (D)
- ~2x faster than SHAKE128

**Usage:**
```csharp
// Standard (32 bytes)
using var ts = TurboShake128.Create();
Span<byte> hash = stackalloc byte[32];
ts.TryComputeHash(data, hash, out _);

// Custom output and customization
using var tsCustom = new TurboShake128(
    outputBytes: 64,
    customization: "My App");
Span<byte> longHash = stackalloc byte[64];
tsCustom.TryComputeHash(data, longHash, out _);
```

### TurboShake256

```csharp
public sealed class TurboShake256 : HashAlgorithm
```

**Properties:**
- Output Size: Variable (default 64 bytes)
- Security: 256 bits
- Permutation: Keccak-p[1600,12] (12 rounds)
- Rate: 136 bytes
- Supports: Customization string (D)

**Usage:**
```csharp
using var ts = TurboShake256.Create();
Span<byte> hash = stackalloc byte[64];
ts.TryComputeHash(data, hash, out _);
```

> **XOF Mode:** TurboSHAKE128 and TurboSHAKE256 implement [`IExtendableOutput`](xof-mode.md) for streaming variable-length output via `Absorb` / `Squeeze`.

---

## KangarooTwelve (KT)

Parallelizable high-performance XOFs from RFC 9861.

### KT128

```csharp
public sealed class KT128 : HashAlgorithm
```

**Properties:**
- Output Size: Variable (default 32 bytes)
- Security: 128 bits
- Based on: TurboSHAKE128
- Rate: 168 bytes
- Supports: Customization string, tree hashing for large inputs
- **Formerly known as:** KangarooTwelve

**Key Features:**
- Tree hashing for parallel processing of messages > 8KB
- Same performance as TurboSHAKE128 for short messages

**Usage:**
```csharp
using var kt = KT128.Create();
Span<byte> hash = stackalloc byte[32];
kt.TryComputeHash(data, hash, out _);
```

### KT256

```csharp
public sealed class KT256 : HashAlgorithm
```

**Properties:**
- Output Size: Variable (default 64 bytes)
- Security: 256 bits
- Based on: TurboSHAKE256
- Rate: 136 bytes
- Supports: Customization string, tree hashing for large inputs

**Usage:**
```csharp
using var kt = KT256.Create();
Span<byte> hash = stackalloc byte[64];
kt.TryComputeHash(data, hash, out _);
```

> **XOF Mode:** KT128 and KT256 implement [`IExtendableOutput`](xof-mode.md) for streaming variable-length output via `Absorb` / `Squeeze`.

---

## Keccak

Original Keccak algorithm family (pre-SHA-3 standardization).

### Keccak256

```csharp
public sealed class Keccak256 : HashAlgorithm
```

**Properties:**
- Hash Size: 256 bits (32 bytes)
- Block Size: 136 bytes
- Uses original Keccak padding (0x01)

**Important:** This is NOT the same as SHA3-256. Keccak-256 uses different padding and produces different output. Use this for Ethereum compatibility.

**Usage:**
```csharp
using var keccak = Keccak256.Create();
Span<byte> hash = stackalloc byte[32];
keccak.TryComputeHash(data, hash, out _);
```

**Ethereum Example:**
```csharp
// Compute Ethereum address from public key
byte[] publicKey = ...; // 64-byte uncompressed public key (without 0x04 prefix)
using var keccak = Keccak256.Create();
Span<byte> hash = stackalloc byte[32];
keccak.TryComputeHash(publicKey, hash, out _);
ReadOnlySpan<byte> address = hash[^20..]; // Last 20 bytes
```

### Keccak384

```csharp
public sealed class Keccak384 : HashAlgorithm
```

**Properties:**
- Hash Size: 384 bits (48 bytes)
- Block Size: 104 bytes
- Uses original Keccak padding (0x01)

**Important:** This is NOT the same as SHA3-384. Keccak-384 uses different padding and produces different output.

**Usage:**
```csharp
using var keccak = Keccak384.Create();
Span<byte> hash = stackalloc byte[48];
keccak.TryComputeHash(data, hash, out _);
```

### Keccak512

```csharp
public sealed class Keccak512 : HashAlgorithm
```

**Properties:**
- Hash Size: 512 bits (64 bytes)
- Block Size: 72 bytes
- Uses original Keccak padding (0x01)

**Important:** This is NOT the same as SHA3-512. Keccak-512 uses different padding and produces different output.

**Usage:**
```csharp
using var keccak = Keccak512.Create();
Span<byte> hash = stackalloc byte[64];
keccak.TryComputeHash(data, hash, out _);
```

---

## BLAKE2

High-performance hash functions from RFC 7693.

### Blake2b

```csharp
public sealed class Blake2b : HashAlgorithm
```

**Properties:**
- Output Size: 1-64 bytes (default 64)
- Block Size: 128 bytes
- Supports: Keyed hashing (MAC mode)
- Faster than SHA-256 on 64-bit systems

**Usage:**
```csharp
// Standard hash (64 bytes)
using var blake2b = Blake2b.Create();
Span<byte> hash = stackalloc byte[64];
blake2b.TryComputeHash(data, hash, out _);

// Custom output size (32 bytes)
using var blake2b32 = Blake2b.Create(hashSize: 32);
Span<byte> hash32 = stackalloc byte[32];
blake2b32.TryComputeHash(data, hash32, out _);

// Keyed hash (MAC)
byte[] key = new byte[32]; // Up to 64 bytes
using var blake2bMac = Blake2b.Create(key: key, hashSize: 32);
Span<byte> mac = stackalloc byte[32];
blake2bMac.TryComputeHash(data, mac, out _);
```

### Blake2s

```csharp
public sealed class Blake2s : HashAlgorithm
```

**Properties:**
- Output Size: 1-32 bytes (default 32)
- Block Size: 64 bytes
- Supports: Keyed hashing (MAC mode)
- Optimized for 32-bit and embedded systems

**Usage:**
```csharp
// Standard hash (32 bytes)
using var blake2s = Blake2s.Create();
Span<byte> hash = stackalloc byte[32];
blake2s.TryComputeHash(data, hash, out _);

// Custom output size (16 bytes)
using var blake2s16 = Blake2s.Create(hashSize: 16);
Span<byte> hash16 = stackalloc byte[16];
blake2s16.TryComputeHash(data, hash16, out _);

// Keyed hash (MAC)
byte[] key = new byte[16]; // Up to 32 bytes
using var blake2sMac = Blake2s.Create(key: key, hashSize: 16);
Span<byte> mac = stackalloc byte[16];
blake2sMac.TryComputeHash(data, mac, out _);
```

---

## BLAKE3

Modern, high-performance hash function.

### Blake3

```csharp
public sealed partial class Blake3 : HashAlgorithm, IExtendableOutput
```

**Properties:**
- Output Size: Variable (default 32 bytes)
- Designed for parallelism
- Supports: Hash, Keyed Hash, Derive Key modes
- Implements [`IExtendableOutput`](xof-mode.md) for streaming XOF output

**Modes:**

| Mode | Factory Method | Key Size | Description |
|------|----------------|----------|-------------|
| Hash | `Create()` | - | Standard cryptographic hash |
| Keyed | `CreateKeyed(key)` | 32 bytes | MAC mode |
| Derive Key | `CreateDeriveKey(context)` | - | Key derivation |

**Usage:**
```csharp
// Standard hash
using var blake3 = Blake3.Create();
Span<byte> hash = stackalloc byte[32];
blake3.TryComputeHash(data, hash, out _);

// Variable output (64 bytes)
using var blake3Long = Blake3.Create(outputBytes: 64);
Span<byte> longHash = stackalloc byte[64];
blake3Long.TryComputeHash(data, longHash, out _);

// Keyed hash (MAC)
byte[] key = new byte[32]; // Must be exactly 32 bytes
using var blake3Mac = Blake3.CreateKeyed(key);
Span<byte> mac = stackalloc byte[32];
blake3Mac.TryComputeHash(data, mac, out _);

// Key derivation
string context = "MyApp 2025 session key";
using var blake3Kdf = Blake3.CreateDeriveKey(context);
Span<byte> derivedKey = stackalloc byte[32];
blake3Kdf.TryComputeHash(inputKeyMaterial, derivedKey, out _);
```

> **XOF Mode:** BLAKE3 implements [`IExtendableOutput`](xof-mode.md) using counter-mode output expansion for streaming variable-length output via `Absorb` / `Squeeze`.

---

## RIPEMD

RIPEMD family hash functions.

### Ripemd160

```csharp
public sealed class Ripemd160 : HashAlgorithm
```

**Properties:**
- Hash Size: 160 bits (20 bytes)
- Block Size: 64 bytes
- Widely used in cryptocurrency (Bitcoin addresses)

**Usage:**
```csharp
using var ripemd = Ripemd160.Create();
Span<byte> hash = stackalloc byte[20];
ripemd.TryComputeHash(data, hash, out _);
```

**Bitcoin Address Example:**
```csharp
// Simplified Bitcoin P2PKH address generation
byte[] publicKey = ...; // Compressed public key
using var sha256 = SHA256.Create();
using var ripemd = Ripemd160.Create();

Span<byte> sha256Hash = stackalloc byte[32];
sha256.TryComputeHash(publicKey, sha256Hash, out _);

Span<byte> pubKeyHash = stackalloc byte[20];
ripemd.TryComputeHash(sha256Hash, pubKeyHash, out _); // 20-byte hash
```

---

## SM3

Chinese national standard hash function (GB/T 32905-2016).

### SM3

```csharp
public sealed class SM3 : HashAlgorithm
```

**Properties:**
- Hash Size: 256 bits (32 bytes)
- Block Size: 64 bytes
- Standard: GB/T 32905-2016, ISO/IEC 10118-3:2018

**Usage:**
```csharp
using var sm3 = SM3.Create();
Span<byte> hash = stackalloc byte[32];
sm3.TryComputeHash(data, hash, out _);
```

---

## Whirlpool

ISO/IEC 10118-3 hash function.

### Whirlpool

```csharp
public sealed class Whirlpool : HashAlgorithm
```

**Properties:**
- Hash Size: 512 bits (64 bytes)
- Block Size: 64 bytes
- Standard: ISO/IEC 10118-3:2004, NESSIE recommended

**Usage:**
```csharp
using var whirlpool = Whirlpool.Create();
Span<byte> hash = stackalloc byte[64];
whirlpool.TryComputeHash(data, hash, out _);
```

---

## Streebog

Russian national standard hash function (GOST R 34.11-2012).

### Streebog

```csharp
public sealed class Streebog : HashAlgorithm
```

**Properties:**
- Output Size: 256 or 512 bits
- Block Size: 64 bytes
- Standard: GOST R 34.11-2012, RFC 6986

**Usage:**
```csharp
// Streebog-512 (default)
using var streebog = Streebog.Create();
Span<byte> hash = stackalloc byte[64];
streebog.TryComputeHash(data, hash, out _);

// Streebog-256
using var streebog256 = Streebog.Create(hashSize: 32);
Span<byte> hash256 = stackalloc byte[32];
streebog256.TryComputeHash(data, hash256, out _);
```

---

## Kupyna

Ukrainian national standard hash function (DSTU 7564:2014).

### Kupyna

```csharp
public sealed class Kupyna : HashAlgorithm
```

**Properties:**
- Output Size: 256, 384, or 512 bits
- Block Size: 64 bytes (256-bit) or 128 bytes (384/512-bit)
- Standard: DSTU 7564:2014

**Usage:**
```csharp
// Kupyna-512 (default)
using var kupyna = Kupyna.Create();
Span<byte> hash = stackalloc byte[64];
kupyna.TryComputeHash(data, hash, out _);

// Kupyna-256
using var kupyna256 = Kupyna.Create(hashSizeBytes: 32);
Span<byte> hash256 = stackalloc byte[32];
kupyna256.TryComputeHash(data, hash256, out _);

// Kupyna-384
using var kupyna384 = Kupyna.Create(hashSizeBytes: 48);
Span<byte> hash384 = stackalloc byte[48];
kupyna384.TryComputeHash(data, hash384, out _);
```

---

## LSH (KS X 3262)

Korean national standard hash function designed by KISA (Korea Internet & Security Agency).

### Lsh512 

```csharp
public sealed class Lsh512 : HashAlgorithm
```

**Properties:**
- Output Size: 224, 256, 384, or 512 bits
- Block Size: 256 bytes
- Word Size: 64 bits
- Steps: 28
- Standard: KS X 3262

**Usage:**
```csharp
// LSH-512-512 (default)
using var lsh = Lsh512.Create();
Span<byte> hash = stackalloc byte[64];
lsh.TryComputeHash(data, hash, out _);

// LSH-512-256
using var lsh256 = Lsh512.Create(hashSizeBytes: 32);
Span<byte> hash256 = stackalloc byte[32];
lsh256.TryComputeHash(data, hash256, out _);

// LSH-512-384
using var lsh384 = Lsh512.Create(hashSizeBytes: 48);
Span<byte> hash384 = stackalloc byte[48];
lsh384.TryComputeHash(data, hash384, out _);
```

### Lsh256

```csharp
public sealed class Lsh256 : HashAlgorithm
```

**Properties:**
- Output Size: 224 or 256 bits
- Block Size: 128 bytes
- Word Size: 32 bits
- Steps: 26
- Standard: KS X 3262

**Usage:**
```csharp
// LSH-256-256 (default)
using var lsh = Lsh256.Create();
Span<byte> hash = stackalloc byte[32];
lsh.TryComputeHash(data, hash, out _);

// LSH-256-224
using var lsh224 = Lsh256.Create(hashSizeBytes: 28);
Span<byte> hash224 = stackalloc byte[28];
lsh224.TryComputeHash(data, hash224, out _);
```

---

## Ascon

Lightweight cryptographic hash and XOF from NIST Lightweight Cryptography Standardization (FIPS 207).

### AsconHash256

```csharp
public sealed class AsconHash256 : HashAlgorithm
```

**Properties:**
- Hash Size: 256 bits (32 bytes)
- Security: 128 bits
- Rate: 8 bytes
- Standard: NIST FIPS 207

**Key Features:**
- Designed for constrained environments (IoT, embedded systems)
- Low memory footprint
- Efficient in software and hardware implementations

**Usage:**
```csharp
using var ascon = AsconHash256.Create();
Span<byte> hash = stackalloc byte[32];
ascon.TryComputeHash(data, hash, out _);
```

### AsconXof128

```csharp
public sealed class AsconXof128 : HashAlgorithm
```

**Properties:**
- Output Size: Variable (specify at creation)
- Security: 128 bits
- Rate: 8 bytes
- Standard: NIST FIPS 207

**Key Features:**
- Extendable-output function (XOF)
- Lightweight and suitable for constrained environments
- Arbitrary-length output

**Usage:**
```csharp
// Default 32-byte output
using var ascon = AsconXof128.Create();
Span<byte> hash = stackalloc byte[32];
ascon.TryComputeHash(data, hash, out _);

// Custom output size
using var ascon64 = AsconXof128.Create(outputBytes: 64);
Span<byte> longHash = stackalloc byte[64];
ascon64.TryComputeHash(data, longHash, out _);
```

> **XOF Mode:** Ascon-XOF128 implements [`IExtendableOutput`](xof-mode.md) for streaming variable-length output via `Absorb` / `Squeeze`.

---

## Legacy

?? **Warning:** These algorithms are cryptographically broken and should NOT be used for security purposes.

### SHA1

```csharp
[Obsolete("SHA-1 is cryptographically broken.")]
public sealed class SHA1 : HashAlgorithm
```

**Properties:**
- Hash Size: 160 bits (20 bytes)
- Block Size: 64 bytes
- **Status:** Deprecated - collision attacks exist

**Usage (legacy only):**
```csharp
#pragma warning disable CS0618
using var sha1 = SHA1.Create();
Span<byte> hash = stackalloc byte[20];
sha1.TryComputeHash(data, hash, out _);
#pragma warning restore CS0618
```

### MD5

```csharp
[Obsolete("MD5 is cryptographically broken.")]
public sealed class MD5 : HashAlgorithm
```

**Properties:**
- Hash Size: 128 bits (16 bytes)
- Block Size: 64 bytes
- **Status:** Deprecated - collision attacks exist

**Usage (legacy only):**
```csharp
#pragma warning disable CS0618
using var md5 = MD5.Create();
Span<byte> hash = stackalloc byte[16];
md5.TryComputeHash(data, hash, out _);
#pragma warning restore CS0618
```

---

## Algorithm Factory

You can also create hash algorithms by name:

```csharp
using var algorithm = HashAlgorithm.Create("SHA3-256");
Span<byte> hash = stackalloc byte[algorithm.HashSize / 8];
algorithm.TryComputeHash(data, hash, out _);
```

Supported names:
- SHA-1/2: `SHA1`, `SHA224`, `SHA256`, `SHA384`, `SHA512`, `SHA512/224`, `SHA512/256`
- SHA-3: `SHA3-224`, `SHA3-256`, `SHA3-384`, `SHA3-512`
- SHAKE: `SHAKE128`, `SHAKE256`
- cSHAKE: `CSHAKE128`, `CSHAKE256`
- TurboSHAKE: `TURBOSHAKE128`, `TURBOSHAKE256`
- KT (RFC 9861): `KT128` (formerly `KANGAROOTWELVE`), `KT256`
- Keccak: `KECCAK-256`, `KECCAK-384`, `KECCAK-512`
- Ascon: `ASCON-HASH256`, `ASCON-XOF128`
- BLAKE: `BLAKE2B`, `BLAKE2S`, `BLAKE3`
- Others: `RIPEMD-160`, `SM3`, `WHIRLPOOL`, `STREEBOG-256`, `STREEBOG-512`, `KUPYNA-256`, `KUPYNA-384`, `KUPYNA-512`, `LSH-256-224`, `LSH-256-256`, `LSH-512-256`, `LSH-512-384`, `LSH-512-512`, `MD5`

---

## See Also

- [MAC Algorithms](mac-algorithms.md)
- [Cryptography Package Overview](index.md)
- [Specifications](specs/README.md)

---

© 2026 The Keepers of the CryptoHives
