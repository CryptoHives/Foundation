# CryptoHives Namespace & Package Layout

This layout ensures consistency, modularity, and easy migration from `System.Security.Cryptography`.  
Each subpackage can be delivered as its own NuGet package, but also bundled in a meta-package (`CryptoHives.All`).

---

## Root
- **`CryptoHives.Cryptography`**
  - Common utilities, constants, exceptions, and base interfaces.  
  - Example: `ICryptoAlgorithm`, `CryptoRandom`, error codes, algorithm registry.

---

## Symmetric Cryptography
- **`CryptoHives.Cryptography.Symmetric`**
  - `AesManaged` (AES in all modes: CBC, GCM, etc.)
  - `ChaCha20`, `ChaCha20Poly1305`
  - `Serpent`, `Camellia`, `Blowfish` (legacy/optional)
  - `CipherMode`, `PaddingMode`, etc.

---

## Hashing & MACs
- **`CryptoHives.Cryptography.Hashing`**
  - `Sha256Managed`, `Sha512Managed`
  - `Sha3_256`, `Sha3_512`
  - `Blake2b`, `Blake3`
  - `Shake128`, `Shake256`
- **`CryptoHives.MACs`**
  - `HMAC`, `CMAC`, `Poly1305`, `KMAC`

---

## Key Derivation & Password Hashing
- **`CryptoHives.Cryptography.KeyDerivation`**
  - `HKDF`
  - `PBKDF2`
  - `scrypt`
  - `Argon2`

---

## Random Number Generators
- **`CryptoHives.Cryptography.Random`**
  - Managed DRBGs (Hash/HMAC/CTR-DRBG)
  - OS entropy providers (`WindowsEntropy`, `LinuxEntropy`, `MacOSEntropy`)
  - Unified `CryptoRandom` interface

---

## Public-Key Cryptography — Classical
- **`CryptoHives.Cryptography.Asymmetric`**
  - `RsaManaged`
  - `EcdsaManaged` (P-256, P-384, P-521)
  - `EcdhManaged`
  - `Ed25519`, `Ed448`
  - `X25519`

---

## Public-Key Cryptography — Post-Quantum
- **`CryptoHives.Cryptography.PQC`**
  - **KEMs**
    - `Kyber` (ML-KEM)
    - `HQC`
  - **Signatures**
    - `Dilithium` (ML-DSA)
    - `Falcon`
    - `SphincsPlus`

---

## Certificates & PKI
- **`CryptoHives.Certificates`**
  - `X509Certificate` (replacement for `X509Certificate2`)
  - Certificate parsing (PEM/DER)
  - Chain validation
  - CRL & OCSP support
  - Hybrid certificates (Classical + PQC)

---

## Formats & Key Storage
- **`CryptoHives.Cryptography.Formats`**
  - PEM, DER, ASN.1 encoders/decoders
  - PKCS#1, PKCS#8, PKCS#12
  - JWK, OpenSSH key formats
  - Secure key containers

---

## Protocol Primitives
- **`CryptoHives.Cryptography.Protocols`**
  - TLS cipher suites (1.2, 1.3)
  - SSH crypto
  - CMS/PKCS#7
  - JWT/JWS/JWE bindings
  - S/MIME support

---

## Hybrid Crypto
- **`CryptoHives.Cryptography.Hybrid`**
  - Classical + PQC hybrids
  - HKDF integrations
  - Hybrid TLS handshake support

---

## Side-Channel & Security Tools
- **`CryptoHives.Cryptography.Utils`**
  - Constant-time comparison utilities
  - Memory zeroization
  - Timing attack mitigations

---

## Test Vectors & Validation
- **`CryptoHives.Cryptography.TestVectors`**
  - NIST vectors
  - Wycheproof suite
  - RFC conformance
  - Cross-platform interop tests

---

## Meta-Packages
- `CryptoHives.Cryptography.Core` → Base utilities, randomness, hashing, symmetric ciphers  
- `CryptoHives.Cryptography.Asymmetric` → Classical public-key crypto  
- `CryptoHives.Cryptography.PQC` → Post-quantum crypto  
- `CryptoHives.Certificates` → Certificates & PKI  
- `CryptoHives.Cryptography.All` → Aggregates all above  

---

### Migration Mapping from .NET

| Existing .NET class           | CryptoHives replacement             |
|-------------------------------|-------------------------------------|
| `System.Security.Cryptography.Aes` | `CryptoHives.Cryptography.Symmetric.Aes` |
| `System.Security.Cryptography.RSA` | `CryptoHives.Cryptography.Asymmetric.Rsa` |
| `System.Security.Cryptography.ECDsa` | `CryptoHives.Cryptography.Asymmetric.Ecdsa` |
| `System.Security.Cryptography.X509Certificate2` | `CryptoHives.Certificates.X509Certificate` |
| `RandomNumberGenerator`       | `CryptoHives.Cryptography.Random.CryptoRandom`   |

---

📌 This structure ensures **clean separation**, allows **NuGet modularization**, and keeps **migration friction minimal**.  


