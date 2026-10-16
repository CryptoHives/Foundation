---
title: Security Packages
_description: The CryptoHives.Foundation.Security family — fully managed, OS-independent, specification-based cryptographic implementations for .NET, verified against official test vectors.
---

# CryptoHives.Foundation.Security Packages

The Security package family provides specification-based cryptographic implementations for .NET.

## Overview

These packages are fully managed and cross-platform — they don't call into OS or hardware crypto APIs, which keeps behavior deterministic across every platform and runtime. That matters for:

- **Cross-platform consistency** — the same results on Windows, Linux, macOS, and any .NET runtime
- **Embedded systems** — works where OS crypto APIs may not be available
- **Testing and verification** — predictable behavior for cryptographic test suites
- **Learning** — implementations written to be read, not just used

## Available Packages

### Cryptography Package

**CryptoHives.Foundation.Security.Cryptography** — hashes, MACs, ciphers, KDFs and post-quantum algorithms

A broad set of cryptographic algorithms, all fully managed and OS-independent.

**Key features:**
- SHA-1, SHA-2, SHA-3 families
- SHAKE, cSHAKE, TurboSHAKE and KangarooTwelve extendable-output functions (XOF), plus ParallelHash
- Keccak-256/384/512 (Ethereum compatible)
- BLAKE2 and BLAKE3, tuned for high throughput
- Ascon-Hash256, Ascon-XOF128 and Ascon-AEAD128 (NIST SP 800-232)
- MACs: HMAC, KMAC, AES-CMAC, AES-GMAC, Poly1305, keyed BLAKE2/BLAKE3
- AEAD: AES-GCM, AES-CCM, ChaCha20-Poly1305, XChaCha20-Poly1305
- Block and stream ciphers: AES (ECB/CBC/CTR), ChaCha20, and the regional ciphers SM4, ARIA, Camellia, Kuznyechik, Kalyna, SEED
- Key derivation: HKDF, KBKDF, Concat KDF, PBKDF2; AES Key Wrap (RFC 3394/5649)
- Post-quantum: ML-KEM (FIPS 203), ML-DSA (FIPS 204) and SLH-DSA (FIPS 205), mirroring the .NET 10 in-box APIs on every target framework
- PKCS#8, SubjectPublicKeyInfo and PEM import/export for the post-quantum keys, with PBES2-encrypted private keys and an [erasable-memory](cryptography/erasable-memory.md) API that never takes a secret as a `string`
- Regional hash standards (SM3, Streebog, Kupyna, LSH, Whirlpool) and legacy algorithms (MD5, RIPEMD-160)

**[Cryptography Package Documentation](cryptography/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

**Quick example:**
```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

// Compute SHA-256 hash — zero allocations
using var sha256 = SHA256.Create();
Span<byte> hash = stackalloc byte[32];
sha256.TryComputeHash(data, hash, out _);

// Compute BLAKE3 hash with variable output — zero allocations
using var blake3 = Blake3.Create(outputBytes: 64);
Span<byte> longHash = stackalloc byte[64];
blake3.TryComputeHash(data, longHash, out _);
```

---

## Planned Packages

### Certificates (Planned)

**CryptoHives.Foundation.Security.Certificates** — certificate handling and validation

- X.509 certificate building, parsing, and validation
- Certificate chain building and validation
- CRL and OCSP support

### Classical Public-Key Algorithms (Planned)

- RSA, ECDH, ECDSA
- Argon2 password hashing

---

## Design Principles

### Development Policy

- Implementations are written from official public specifications (NIST, RFC, ISO), not ported from other codebases.
- Some development uses AI-assisted tooling — clean-room provenance isn't claimed for every line.
- Every algorithm is checked against official test vectors from its specification.
- Reviews include validation against independent reference implementations.

### No OS Dependencies

Unlike `System.Security.Cryptography`, these implementations:
- Don't call into OS cryptographic APIs (CNG, OpenSSL, etc.)
- Behave identically across platforms and .NET versions
- Produce deterministic output regardless of the host system
- Use hardware intrinsics for speed when available, but always have a pure managed fallback

### Standards Compliance

- NIST FIPS 180-4, FIPS 197, FIPS 202, FIPS 203, FIPS 204, FIPS 205
- NIST SP 800-38B/D, SP 800-108r1, SP 800-56A/C, SP 800-185, SP 800-232
- RFCs (2104 HMAC, 5869 HKDF, 7693 BLAKE2, 8018 PBKDF2, 8439 ChaCha20-Poly1305, 6986 Streebog)
- ISO/IEC standards where applicable

The full list, with the test vectors behind each entry, is on the [Cryptography package page](cryptography/index.md#standards-compliance).

## Target Frameworks

- .NET 10.0
- .NET 8.0
- .NET Framework 4.7.2
- .NET Framework 4.6.2
- .NET Standard 2.0
- .NET Standard 2.1

## Getting Help

- [Full Documentation](https://cryptohives.github.io/Foundation/)
- [Cryptographic Specifications](cryptography/specs/README.md)
- [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- [Discussions](https://github.com/CryptoHives/Foundation/discussions)

## See Also

- [Cryptography Package](cryptography/index.md)
- [Porting Guide](../../porting-to-cryptohives.md)
- [Specifications](cryptography/specs/README.md)

---

© 2026 The Keepers of the CryptoHives
