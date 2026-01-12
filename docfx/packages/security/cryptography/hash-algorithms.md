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

---

## KangarooTwelve

High-performance XOF based on reduced-round Keccak.

### KangarooTwelve

```csharp
public sealed class KangarooTwelve : HashAlgorithm
```

**Properties:**
- Output Size: Variable (default 32 bytes)
- Security: 128 bits
- Permutation: Keccak-p[1600,12] (12 rounds)
- Rate: 168 bytes
- Supports: Customization string, tree hashing for large inputs

**Key Features:**
- ~2x faster than SHAKE128 due to reduced rounds
- Tree hashing for parallel processing of messages > 8KB
- Optional customization string for domain separation

**Usage:**
```csharp
// Standard hash (32 bytes)
using var k12 = KangarooTwelve.Create();
byte[] hash = k12.ComputeHash(data);

// Custom output size (64 bytes)
using var k12 = KangarooTwelve.Create(outputBytes: 64);
byte[] longHash = k12.ComputeHash(data);

// With customization string
using var k12 = new KangarooTwelve(
    outputBytes: 32,
    customization: "My Application v1.0");
byte[] hash = k12.ComputeHash(data);
```

**Customization Example:**
```csharp
// Domain separation for different use cases
using var k12Session = new KangarooTwelve(32, "SessionKey");
using var k12Auth = new KangarooTwelve(32, "AuthToken");

// Same input produces different outputs
byte[] sessionKey = k12Session.ComputeHash(masterSecret);
byte[] authToken = k12Auth.ComputeHash(masterSecret);
```

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
public sealed class Blake3 : HashAlgorithm
```

**Properties:**
- Output Size: Variable (default 32 bytes)
- Designed for parallelism
- Supports: Hash, Keyed Hash, Derive Key modes

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
- K12: `KANGAROOTWELVE`, `K12`
- Keccak: `KECCAK-256`, `KECCAK-384`, `KECCAK-512`
- BLAKE: `BLAKE2B`, `BLAKE2S`, `BLAKE3`
- Others: `RIPEMD-160`, `SM3`, `WHIRLPOOL`, `STREEBOG-256`, `STREEBOG-512`, `MD5`

---

## See Also

- [MAC Algorithms](mac-algorithms.md)
- [Cryptography Package Overview](index.md)
- [Specifications](specs/README.md)

---

© 2025 The Keepers of the CryptoHives
