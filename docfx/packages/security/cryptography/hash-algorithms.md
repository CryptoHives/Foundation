# Hash Algorithms Reference

This page provides detailed documentation for all hash algorithms implemented in the CryptoHives.Foundation.Security.Cryptography package.

## Namespace

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;
```

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
byte[] hash = sha224.ComputeHash(data);
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
byte[] hash = sha256.ComputeHash(data);
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
byte[] hash = sha384.ComputeHash(data);
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
byte[] hash = sha512.ComputeHash(data);
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
byte[] hash = sha512_224.ComputeHash(data);
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
byte[] hash = sha512_256.ComputeHash(data);
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
byte[] hash = sha3.ComputeHash(data);
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
byte[] hash = sha3.ComputeHash(data);
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
byte[] hash = sha3.ComputeHash(data);
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
byte[] hash = sha3.ComputeHash(data);
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
byte[] hash = shake.ComputeHash(data);

// Custom output size
using var shake = Shake128.Create(outputBytes: 64);
byte[] longHash = shake.ComputeHash(data);
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
byte[] hash = shake.ComputeHash(data);

// Custom output size
using var shake = Shake256.Create(outputBytes: 128);
byte[] longHash = shake.ComputeHash(data);
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
byte[] hash = cshake.ComputeHash(data);
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
byte[] hash = cshake.ComputeHash(data);
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
byte[] hash = ts.ComputeHash(data);

// Custom output and customization
using var ts = new TurboShake128(
    outputBytes: 64, 
    customization: "My App");
byte[] hash = ts.ComputeHash(data);
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
byte[] hash = ts.ComputeHash(data);
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
byte[] hash = kt.ComputeHash(data);
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
byte[] hash = kt.ComputeHash(data);
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
byte[] hash = keccak.ComputeHash(data);
```

**Ethereum Example:**
```csharp
// Compute Ethereum address from public key
byte[] publicKey = ...; // 64-byte uncompressed public key (without 0x04 prefix)
using var keccak = Keccak256.Create();
byte[] hash = keccak.ComputeHash(publicKey);
byte[] address = hash[^20..]; // Last 20 bytes
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
byte[] hash = keccak.ComputeHash(data);
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
byte[] hash = keccak.ComputeHash(data);
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
byte[] hash = blake2b.ComputeHash(data);

// Custom output size (32 bytes)
using var blake2b = Blake2b.Create(hashSize: 32);
byte[] hash = blake2b.ComputeHash(data);

// Keyed hash (MAC)
byte[] key = new byte[32]; // Up to 64 bytes
using var blake2b = Blake2b.Create(key: key, hashSize: 32);
byte[] mac = blake2b.ComputeHash(data);
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
byte[] hash = blake2s.ComputeHash(data);

// Custom output size (16 bytes)
using var blake2s = Blake2s.Create(hashSize: 16);
byte[] hash = blake2s.ComputeHash(data);

// Keyed hash (MAC)
byte[] key = new byte[16]; // Up to 32 bytes
using var blake2s = Blake2s.Create(key: key, hashSize: 16);
byte[] mac = blake2s.ComputeHash(data);
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
byte[] hash = blake3.ComputeHash(data);

// Variable output (64 bytes)
using var blake3 = Blake3.Create(outputBytes: 64);
byte[] longHash = blake3.ComputeHash(data);

// Keyed hash (MAC)
byte[] key = new byte[32]; // Must be exactly 32 bytes
using var blake3 = Blake3.CreateKeyed(key);
byte[] mac = blake3.ComputeHash(data);

// Key derivation
string context = "MyApp 2025 session key";
using var blake3 = Blake3.CreateDeriveKey(context);
byte[] derivedKey = blake3.ComputeHash(inputKeyMaterial);
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
byte[] hash = ripemd.ComputeHash(data);
```

**Bitcoin Address Example:**
```csharp
// Simplified Bitcoin P2PKH address generation
byte[] publicKey = ...; // Compressed public key
using var sha256 = SHA256.Create();
using var ripemd = Ripemd160.Create();

byte[] sha256Hash = sha256.ComputeHash(publicKey);
byte[] pubKeyHash = ripemd.ComputeHash(sha256Hash); // 20-byte hash
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
byte[] hash = sm3.ComputeHash(data);
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
byte[] hash = whirlpool.ComputeHash(data);
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
byte[] hash = streebog.ComputeHash(data);

// Streebog-256
using var streebog256 = Streebog.Create(hashSize: 32);
byte[] hash = streebog256.ComputeHash(data);
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
byte[] hash = kupyna.ComputeHash(data);

// Kupyna-256
using var kupyna256 = Kupyna.Create(hashSizeBytes: 32);
byte[] hash = kupyna256.ComputeHash(data);

// Kupyna-384
using var kupyna384 = Kupyna.Create(hashSizeBytes: 48);
byte[] hash = kupyna384.ComputeHash(data);
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
byte[] hash = lsh.ComputeHash(data);

// LSH-512-256
using var lsh256 = Lsh512.Create(hashSizeBytes: 32);
byte[] hash = lsh256.ComputeHash(data);

// LSH-512-384
using var lsh384 = Lsh512.Create(hashSizeBytes: 48);
byte[] hash = lsh384.ComputeHash(data);
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
byte[] hash = lsh.ComputeHash(data);

// LSH-256-224
using var lsh224 = Lsh256.Create(hashSizeBytes: 28);
byte[] hash = lsh224.ComputeHash(data);
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
byte[] hash = ascon.ComputeHash(data);
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
byte[] hash = ascon.ComputeHash(data);

// Custom output size
using var ascon = AsconXof128.Create(outputBytes: 64);
byte[] longHash = ascon.ComputeHash(data);
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
byte[] hash = sha1.ComputeHash(data);
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
byte[] hash = md5.ComputeHash(data);
#pragma warning restore CS0618
```

---

## Algorithm Factory

You can also create hash algorithms by name:

```csharp
using var algorithm = HashAlgorithm.Create("SHA3-256");
byte[] hash = algorithm.ComputeHash(data);
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
- Others: `RIPEMD-160`, `SM3`, `WHIRLPOOL`, `STREEBOG-256`, `STREEBOG-512`, `MD5`

---

## See Also

- [MAC Algorithms](mac-algorithms.md)
- [Cryptography Package Overview](index.md)
- [Specifications](specs/README.md)

---

© 2026 The Keepers of the CryptoHives
