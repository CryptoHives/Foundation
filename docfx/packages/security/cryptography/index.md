# CryptoHives.Foundation.Security.Cryptography Package

## Overview

The Cryptography package provides specification-based implementations of cryptographic hash algorithms, message authentication codes (MACs), and cipher algorithms for .NET applications. Core implementations are fully managed code with optional hardware acceleration via AES-NI, PCLMULQDQ, VPCLMULQDQ, SSE2, SSSE3, and AVX2 intrinsics, ensuring consistent behavior across all platforms with automatic SIMD dispatch on supported hardware.

## Key Features

- **Specification-Based Implementations**: Written based on official specifications (NIST, RFC, ISO)
- **No OS Dependencies**: Works identically on all platforms without calling OS crypto APIs
- **Hardware Acceleration**: Optional AES-NI, PCLMULQDQ, VPCLMULQDQ, SSE2, SSSE3, and AVX2 intrinsics with automatic fallback
- **Comprehensive Coverage**: SHA-1/2/3, BLAKE2/3, KMAC, AES-GCM/CCM, ChaCha20-Poly1305, and many more
- **AEAD Support**: Authenticated encryption with AES-GCM, AES-CCM, ChaCha20-Poly1305, XChaCha20-Poly1305
- **Variable Output**: XOF support for SHAKE, cSHAKE, KMAC, and BLAKE3
- **Keyed Hashing**: Built-in MAC modes for BLAKE2, BLAKE3, and KMAC
- **Standards Compliant**: Verified against NIST, RFC, and ISO test vectors

## Installation

```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

> Performance optimizations including AES-NI, PCLMULQDQ, VPCLMULQDQ, and SIMD intrinsics are implemented
> for AES-GCM, AES-CCM, AES-CBC, and ChaCha20 families on .NET 8+. VPCLMULQDQ requires .NET 10+.

## Namespaces

### Hash Algorithms

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;
```

### Message Authentication Codes

```csharp
using CryptoHives.Foundation.Security.Cryptography.Mac;
```

### Cipher Algorithms

```csharp
using CryptoHives.Foundation.Security.Cryptography.Cipher;
```

### Key Derivation Functions

```csharp
using CryptoHives.Foundation.Security.Cryptography.Kdf;
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
| Kupyna | Kupyna-256, Kupyna-384, Kupyna-512 (Ukrainian standard) | [Details](hash-algorithms.md#kupyna) |
| LSH | LSH-256, LSH-512 (Korean standard) | [Details](hash-algorithms.md#lsh-ks-x-3262) |
| Legacy | SHA-1, MD5 (deprecated) | [Details](hash-algorithms.md#legacy) |

### Message Authentication Codes (MAC)

| Algorithm | Security | Documentation |
|-----------|----------|---------------|
| HMAC-SHA-256 | 256 bits | [Details](mac-algorithms.md#hmac-hash-based-message-authentication-code) |
| HMAC-SHA-384 | 384 bits | [Details](mac-algorithms.md#hmac-hash-based-message-authentication-code) |
| HMAC-SHA-512 | 512 bits | [Details](mac-algorithms.md#hmac-hash-based-message-authentication-code) |
| HMAC-SHA3-256 | 256 bits | [Details](mac-algorithms.md#hmac-sha3-256-cross-platform) |
| AES-CMAC | 128 bits | [Details](mac-algorithms.md#aes-cmac-cipher-based-mac) |
| AES-GMAC | 128 bits | [Details](mac-algorithms.md#aes-gmac-galois-mac) |
| Poly1305 | 128 bits | [Details](mac-algorithms.md#poly1305) |
| KMAC128 | 128 bits | [Details](mac-algorithms.md#kmac128) |
| KMAC256 | 256 bits | [Details](mac-algorithms.md#kmac256) |
| BLAKE2b (keyed) | Up to 256 bits | [Details](mac-algorithms.md#blake2-mac) |
| BLAKE2s (keyed) | Up to 128 bits | [Details](mac-algorithms.md#blake2-mac) |
| BLAKE3 (keyed) | 128 bits | [Details](mac-algorithms.md#blake3-mac) |

### Key Derivation Functions (KDF)

| Algorithm | Standard | Documentation |
|-----------|----------|---------------|
| HKDF | RFC 5869 | [Details](kdf-algorithms.md#hkdf-hmac-based-extract-and-expand-kdf) |
| BLAKE3 DeriveKey | BLAKE3 Spec | [Details](hash-algorithms.md#blake3) |

### Cipher Algorithms (Block/Stream)

| Algorithm | Key Sizes | Modes | Documentation |
|-----------|-----------|-------|---------------|
| AES-128 | 128 bits | ECB, CBC, CTR | [Details](cipher-algorithms.md#aes-block-cipher) |
| AES-192 | 192 bits | ECB, CBC, CTR | [Details](cipher-algorithms.md#aes-block-cipher) |
| AES-256 | 256 bits | ECB, CBC, CTR | [Details](cipher-algorithms.md#aes-block-cipher) |
| ChaCha20 | 256 bits | Stream cipher | [Details](cipher-algorithms.md#chacha20) |

### Cipher Algorithms (AEAD)

| Algorithm | Key Sizes | Nonce Size | Tag Size | Documentation |
|-----------|-----------|------------|----------|---------------|
| AES-GCM | 128/192/256 bits | 12 bytes | 16 bytes | [Details](cipher-algorithms.md#aes-gcm-galoiscounter-mode) |
| AES-CCM | 128/192/256 bits | 7-13 bytes | 4-16 bytes | [Details](cipher-algorithms.md#aes-ccm-counter-with-cbc-mac) |
| ChaCha20-Poly1305 | 256 bits | 12 bytes | 16 bytes | [Details](cipher-algorithms.md#chacha20-poly1305) |
| XChaCha20-Poly1305 | 256 bits | 24 bytes | 16 bytes | [Details](cipher-algorithms.md#xchacha20-poly1305) |

## Getting Started

All CryptoHives algorithms inherit from `System.Security.Cryptography.HashAlgorithm` and support two ways of computing a hash.

### Zero-allocation approach (recommended)

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

> **Note:** The `ComputeHash(byte[])` method is also available for convenience but allocates a new `byte[]` on every call, which adds GC pressure in hot paths. Prefer `TryComputeHash` whenever possible.

## More Examples

### Variable-Length Output (XOF)

```csharp
// SHAKE256 with 64-byte output
using var shake = Shake256.Create(outputBytes: 64);
Span<byte> output = stackalloc byte[64];
shake.TryComputeHash(data, output, out _);

// BLAKE3 with 128-byte output
using var blake3 = Blake3.Create(outputBytes: 128);
Span<byte> longHash = stackalloc byte[128];
blake3.TryComputeHash(data, longHash, out _);
```

For allocation-free streaming XOF using `Absorb` / `Squeeze`, see [XOF Mode](xof-mode.md).

### Customizable Hash (cSHAKE)

```csharp
// cSHAKE256 with customization string
using var cshake = new CShake256(
    outputBytes: 64,
    functionName: "",
    customization: "My Application");
Span<byte> customHash = stackalloc byte[64];
cshake.TryComputeHash(data, customHash, out _);
```

### Message Authentication Code (KMAC)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Mac;

byte[] key = new byte[32]; // Your secret key

// KMAC256
using var kmac = KMac256.Create(key, outputBytes: 64, customization: "MyApp");
Span<byte> mac = stackalloc byte[64];
kmac.TryComputeHash(message, mac, out _);
```

### Authenticated Encryption (AEAD)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Cipher;

// AES-256-GCM
byte[] key = new byte[32];
byte[] nonce = new byte[12];
using var aesGcm = AesGcm256.Create(key);

byte[] ciphertext = aesGcm.Encrypt(nonce, plaintext, associatedData);
byte[] decrypted = aesGcm.Decrypt(nonce, ciphertext, associatedData);

// ChaCha20-Poly1305
using var chacha = ChaCha20Poly1305.Create(key);
byte[] encrypted = chacha.Encrypt(nonce, plaintext);
byte[] decrypted = chacha.Decrypt(nonce, encrypted);
```

### Keyed Hashing with BLAKE3

```csharp
byte[] key = new byte[32]; // Must be exactly 32 bytes

// BLAKE3 keyed mode
using var blake3 = Blake3.CreateKeyed(key);
Span<byte> mac = stackalloc byte[32];
blake3.TryComputeHash(message, mac, out _);
```

### Key Derivation with BLAKE3

```csharp
string context = "MyApp 2025-01-01 session key";

// BLAKE3 derive key mode
using var blake3 = Blake3.CreateDeriveKey(context);
Span<byte> derivedKey = stackalloc byte[32];
blake3.TryComputeHash(inputKeyMaterial, derivedKey, out _);
```

### Key Derivation with HKDF

```csharp
using CryptoHives.Foundation.Security.Cryptography.Kdf;
using CryptoHives.Foundation.Security.Cryptography.Mac;

byte[] sharedSecret = ...; // e.g., from ECDH key agreement
byte[] salt = new byte[32];
RandomNumberGenerator.Fill(salt);
byte[] info = Encoding.UTF8.GetBytes("MyApp session key");

// Derive a 32-byte key using HMAC-SHA-256
byte[] derivedKey = Hkdf.DeriveKey(
    key => new HmacSha256(key),
    sharedSecret, outputLength: 32, salt, info);
```

See [KDF Algorithms](kdf-algorithms.md) for full HKDF documentation and protocol examples.

### Incremental Hashing

```csharp
using var sha256 = SHA256.Create();

// Process data in chunks — zero allocations
sha256.AppendData(chunk1);
sha256.AppendData(chunk2);
sha256.AppendData(chunk3);

Span<byte> hash = stackalloc byte[32];
sha256.TryGetHashAndReset(hash, out _);
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
| Protocol compatibility (TLS, SSH) | HMAC-SHA-256 | HMAC-SHA-384 |
| High performance | BLAKE3 keyed | Poly1305 (one-time) |
| NIST compliance | KMAC128/256 | HMAC-SHA-256 |
| Cipher-based (EAP, 802.11i) | AES-CMAC | AES-GMAC |
| Cross-platform SHA-3 | HMAC-SHA3-256 | KMAC256 |
| Short tags (≤16 bytes) | BLAKE2s keyed | AES-CMAC |

### For Key Derivation

| Use Case | Recommended | Alternative |
|----------|-------------|-------------|
| TLS 1.3 / HPKE / Signal | HKDF (SHA-256) | HKDF (SHA-384) |
| Multiple keys from one secret | HKDF (Extract + Expand) | BLAKE3 DeriveKey |
| High performance | BLAKE3 DeriveKey | HKDF |
| NIST compliance | HKDF (SHA-256/384/512) | — |

### For Authenticated Encryption

| Use Case | Recommended | Alternative |
|----------|-------------|-------------|
| Modern applications | AES-256-GCM or ChaCha20-Poly1305 | XChaCha20-Poly1305 |
| Hardware acceleration | AES-256-GCM | AES-128-GCM |
| Software-only | ChaCha20-Poly1305 | XChaCha20-Poly1305 |
| IoT/constrained | AES-128-CCM | ChaCha20-Poly1305 |
| Random nonces | XChaCha20-Poly1305 | AES-256-GCM |

### For Block/Stream Ciphers

| Use Case | Recommended | Alternative |
|----------|-------------|-------------|
| Disk/sector encryption | AES-256-CTR or AES-256-CBC | AES-128-CTR |
| Stream encryption | ChaCha20 | AES-256-CTR |
| Legacy compatibility | AES-128-CBC | AES-256-CBC |
| Hardware acceleration | AES-256-CTR (AES-NI) | AES-128-CTR |

### For Specific Domains

| Domain | Algorithm | Notes |
|--------|-----------|-------|
| Ethereum/Blockchain | Keccak-256 | Uses original Keccak padding |
| Bitcoin addresses | RIPEMD-160 | Combined with SHA-256 |
| Chinese systems | SM3 | GB/T 32905-2016 |
| Russian systems | Streebog | GOST R 34.11-2012 |
| Ukrainian systems | Kupyna | DSTU 7564:2014 |
| Korean systems | LSH | KS X 3262 |

## Standards Compliance

All implementations are verified against official test vectors:

- **NIST FIPS 180-4**: SHA-1, SHA-2 family
- **NIST FIPS 197**: AES (128/192/256)
- **NIST FIPS 202**: SHA-3, SHAKE
- **NIST SP 800-38B**: AES-CMAC
- **NIST SP 800-38D**: AES-GCM
- **NIST SP 800-185**: cSHAKE, KMAC
- **NIST SP 800-232**: Ascon-Hash256, Ascon-XOF128
- **RFC 2104**: HMAC
- **RFC 3610**: AES-CCM
- **RFC 4231**: HMAC-SHA-2 test vectors
- **RFC 5869**: HKDF (HMAC-based Key Derivation)
- **RFC 7693**: BLAKE2
- **RFC 8439**: ChaCha20, Poly1305, ChaCha20-Poly1305
- **draft-irtf-cfrg-xchacha**: XChaCha20-Poly1305
- **BLAKE3 Specification**: BLAKE3
- **GB/T 32905-2016**: SM3
- **GOST R 34.11-2012 / RFC 6986**: Streebog
- **DSTU 7564:2014**: Kupyna
- **KS X 3262**: LSH
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
| Hardware acceleration | Managed SIMD (AES-NI/PCLMULQDQ/VPCLMULQDQ/SSE2/SSSE3/AVX2) | OS-level (CNG/OpenSSL/SymCrypt) |
| SHA-3 support | Full | .NET 8+ only |
| BLAKE2/3 support | Yes | No |
| Keccak-256 (Ethereum) | Yes | No |
| KMAC support | Yes | .NET 9+ only |
| HMAC (SHA-2/SHA-3) | Yes (all TFMs, cross-platform) | Yes (OS-dependent) |
| AES-CMAC | Yes (managed + AES-NI) | No |
| Poly1305 (standalone) | Yes | No |
| AES-GCM/CCM | Yes (managed + AES-NI) | Yes (OS-dependent) |
| ChaCha20-Poly1305 | Yes (managed + SSSE3/AVX2) | .NET 8+ only (OS-dependent) |
| XChaCha20-Poly1305 | Yes | No |
| AES block modes (ECB/CBC/CTR) | Yes (managed + AES-NI) | Yes (OS-dependent) |
| ChaCha20 stream cipher | Yes (managed + SSSE3/AVX2) | No |
| HKDF | Yes (all TFMs, pluggable HMAC) | .NET Core 3.0+ only |
| XOF (SHAKE/cSHAKE/TurboSHAKE/BLAKE3) | Yes (Absorb/Squeeze API) | SHAKE only (.NET 9+) |
| SM3/Streebog/Kupyna/LSH/Whirlpool | Yes | No |

## Thread Safety

All hash algorithm instances are **not thread-safe**. Create separate instances for concurrent operations or use synchronization.

```csharp
// Thread-safe pattern
public bool ComputeHashThreadSafe(ReadOnlySpan<byte> data, Span<byte> destination)
{
    using var sha256 = SHA256.Create(); // New instance per call
    return sha256.TryComputeHash(data, destination, out _);
}
```

## See Also

- [Hash Algorithms Reference](hash-algorithms.md)
- [Cipher Algorithms Reference](cipher-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
- [KDF Algorithms Reference](kdf-algorithms.md)
- [XOF Mode (Extendable-Output)](xof-mode.md)
- [Hash Benchmarks](benchmarks-hash.md)
- [Cipher Benchmarks](benchmarks-cipher.md)
- [Cryptographic Specifications](specs/README.md)
- [Security Package Overview](../index.md)

---

© 2026 The Keepers of the CryptoHives
