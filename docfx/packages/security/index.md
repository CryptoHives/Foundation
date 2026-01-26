# CryptoHives.Foundation.Security Packages

The Security package family provides clean-room cryptographic implementations for .NET applications.

## Overview

The CryptoHives Security packages deliver fully managed, cross-platform cryptographic primitives that do not rely on OS or hardware cryptographic APIs. This ensures deterministic behavior across all platforms and runtimes, making them ideal for:

- **Cross-platform consistency** - Same results on Windows, Linux, macOS, and any .NET runtime
- **Embedded systems** - Works where OS crypto APIs may not be available
- **Testing and verification** - Predictable behavior for cryptographic testing
- **Educational purposes** - Clear, readable implementations for learning

## Available Packages

### Cryptography Package

**CryptoHives.Foundation.Security.Cryptography** - Hash and MAC implementations

Comprehensive suite of cryptographic hash algorithms and message authentication codes (MACs), all implemented as fully managed code without OS dependencies.

**Key Features:**
- SHA-1, SHA-2, SHA-3 family implementations
- SHAKE and cSHAKE extendable-output functions (XOF)
- KMAC (Keccak Message Authentication Code)
- Keccak (Ethereum), TurboShake and KangarooTwelve
- Ascon hashing and MAC
- BLAKE2 and BLAKE3 high-performance hashing
- Legacy algorithms (MD5, RIPEMD-160)
- International standards (SM3, Streebog, Whirlpool)

**[Cryptography Package Documentation](cryptography/index.md)**

**Installation:**
```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

**Quick Example:**
```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

// Compute SHA-256 hash
using var sha256 = SHA256.Create();
byte[] hash = sha256.ComputeHash(data);

// Compute BLAKE3 hash with variable output
using var blake3 = Blake3.Create(outputBytes: 64);
byte[] longHash = blake3.ComputeHash(data);
```

---

## Planned Packages

The following packages are planned for future development:

### Certificates (Planned)

**CryptoHives.Foundation.Security.Certificates** - Certificate handling and validation

- X.509 certificate building, parsing and validation
- Certificate chain building and validation
- CRL and OCSP support

### Encryption (Planned)

**CryptoHives.Foundation.Security.Encryption** - Symmetric and asymmetric encryption

- AES, ChaCha20-Poly1305
- RSA, ECDH, ECDSA
- Key derivation functions (HKDF, PBKDF2, Argon2)

---

## Design Principles

### Clean-Room Implementation

All cryptographic code is written from scratch based on official specifications:
- No reverse engineering or derived code from existing proprietary libraries
- Implementations verified against public test vectors and reference implementations
- Peer review and formal algorithm validation

### No OS Dependencies

Unlike `System.Security.Cryptography`, these implementations:
- Do not call into OS cryptographic APIs (CNG, OpenSSL, etc.)
- Work identically across all platforms and .NET versions
- Produce deterministic output regardless of the host system
- Are optimized with hardware acceleration when available, but can always fall back to pure managed code

### Standards Compliance

All implementations follow official standards:
- NIST FIPS 180-4, FIPS 202, SP 800-185
- RFCs (7693 for BLAKE2, 6986 for Streebog)
- ISO/IEC standards where applicable

## Target Frameworks

All Security packages support:
- .NET 10.0
- .NET 8.0
- .NET Framework 4.6.2
- .NET Standard 2.0
- .NET Standard 2.1

## Getting Help

- 📖 [Full Documentation](https://cryptohives.github.io/Foundation/)
- 📋 [Cryptographic Specifications](cryptography/specs/README.md)
- 🐛 [Report Issues](https://github.com/CryptoHives/Foundation/issues)
- 💬 [Discussions](https://github.com/CryptoHives/Foundation/discussions)

## See Also

- [Cryptography Package](cryptography/index.md)
- [Specifications](cryptography/specs/README.md)

---

© 2026 The Keepers of the CryptoHives
