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

**CryptoHives.Foundation.Security.Cryptography** — hash and MAC implementations

A broad set of cryptographic hash algorithms and message authentication codes, all fully managed and OS-independent.

**Key features:**
- SHA-1, SHA-2, SHA-3 families
- SHAKE and cSHAKE extendable-output functions (XOF)
- KMAC (Keccak Message Authentication Code)
- Keccak (Ethereum), TurboShake, and KangarooTwelve
- Ascon hashing and MAC
- BLAKE2 and BLAKE3, tuned for high throughput
- Legacy algorithms (MD5, RIPEMD-160)
- Regional standards (SM3, Streebog, Kupyna, LSH, Whirlpool)

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

### Encryption (Planned)

**CryptoHives.Foundation.Security.Encryption** — symmetric and asymmetric encryption

- AES, ChaCha20-Poly1305
- RSA, ECDH, ECDSA
- Key derivation functions (HKDF, PBKDF2, Argon2)

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

- NIST FIPS 180-4, FIPS 202, SP 800-185
- RFCs (7693 for BLAKE2, 6986 for Streebog)
- ISO/IEC standards where applicable

## Target Frameworks

- .NET 10.0
- .NET 8.0
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
- [Specifications](cryptography/specs/README.md)

---

© 2026 The Keepers of the CryptoHives
