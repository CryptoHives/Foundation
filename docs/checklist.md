# CryptoHives Foundation Cryptography Coverage Checklist

This document tracks the algorithms and primitives targeted by the CryptoHives Foundation project.  
The goal is to provide **managed .NET implementations** of cryptography and security features, ensuring consistent behavior across all platforms, independent of OS-provided libraries.  

Some items are **required for compatibility** (e.g. `X509Certificate2` replacement), others for **modern security**, and others for **future-proofing with post-quantum cryptography (PQC)**.

---

## ✅ Legend
- [x] Completed
- [ ] Not yet started
- [~] In progress / partial
- (opt) Optional or legacy support

---

## 1. Symmetric Ciphers
- [ ] AES-128 / AES-192 / AES-256
  - [ ] ECB (testing only)
  - [ ] CBC
  - [ ] CTR
  - [ ] GCM (AEAD)
  - [ ] CCM
  - [ ] XTS
  - [ ] OCB (if licensing allows)
- [ ] ChaCha20
  - [ ] ChaCha20-Poly1305
  - [ ] XChaCha20-Poly1305
- [ ] Legacy (opt)
  - [ ] 3DES
  - [ ] Camellia
  - [ ] Serpent
  - [ ] Blowfish

---

## 2. Hash Functions
- [ ] SHA-2 family (SHA-256, SHA-384, SHA-512)
- [ ] SHA-3 family (SHA3-256, SHA3-512)
- [ ] SHAKE128 / SHAKE256 (XOFs)
- [ ] BLAKE2b / BLAKE2s
- [ ] (opt) BLAKE3
- [ ] Legacy SHA-1 (read-only, deprecated)

---

## 3. MACs (Message Authentication Codes)
- [ ] HMAC (SHA-2, SHA-3)
- [ ] CMAC (AES)
- [ ] Poly1305
- [ ] (opt) KMAC (SHA-3)

---

## 4. Key Derivation & Password Hashing
- [ ] HKDF
- [ ] PBKDF2
- [ ] scrypt
- [ ] Argon2 (Argon2id preferred)

---

## 5. Random Number Generation
- [ ] Managed DRBGs
  - [ ] Hash-DRBG
  - [ ] HMAC-DRBG
  - [ ] CTR-DRBG
- [ ] OS entropy integration
  - [ ] Windows (CNG / BCryptGenRandom)
  - [ ] Linux (getrandom / /dev/urandom)
  - [ ] macOS (SecRandomCopyBytes)

---

## 6. Public-Key Crypto — Classical
- [ ] RSA
  - [ ] PKCS#1 v2.1
  - [ ] RSA-OAEP
  - [ ] RSA-PSS
- [ ] Diffie-Hellman (finite-field)
- [ ] ECC
  - [ ] ECDSA (P-256, P-384, P-521)
  - [ ] ECDH (P-256, P-384, P-521)
  - [ ] X25519
  - [ ] Ed25519
  - [ ] Ed448

---

## 7. Public-Key Crypto — Post-Quantum (PQC)
- **KEMs**
  - [ ] CRYSTALS-Kyber (ML-KEM)  
  - [ ] HQC (backup KEM)
- **Signatures**
  - [ ] CRYSTALS-Dilithium (ML-DSA)
  - [ ] FALCON
  - [ ] SPHINCS+

---

## 8. Digital Signatures & Formats
- [ ] RSA-PSS
- [ ] ECDSA
- [ ] EdDSA (Ed25519, Ed448)
- [ ] PQC signatures (Dilithium, Falcon, SPHINCS+)
- [ ] PKCS#1 v2.1 padding
- [ ] CMS/PKCS#7 signatures
- [ ] XMLDSIG support (opt)

---

## 9. Certificates & PKI
- [ ] X.509 v3 parser/constructor
- [ ] Certificate chain validation
- [ ] PEM/DER support
- [ ] PKCS#7 (SignedData)
- [ ] PKCS#12 (PFX)
- [ ] CRL validation
- [ ] OCSP validation + stapling
- [ ] Hybrid (classical + PQC) certificate support

---

## 10. Key Storage & Formats
- [ ] PKCS#8
- [ ] PKCS#12
- [ ] JWK
- [ ] OpenSSH key formats
- [ ] PEM/DER import/export
- [ ] Secure memory / zeroization

---

## 11. Higher-Level Protocol Primitives
- [ ] TLS cipher suites (1.2 & 1.3)
- [ ] JWT (JWS/JWE) crypto bindings
- [ ] SSH crypto primitives
- [ ] S/MIME / CMS primitives

---

## 12. Hybrid Key Agreement
- [ ] Classical + PQC KEM hybrids
- [ ] HKDF integration

---

## 13. Side-Channel Resistance
- [ ] Constant-time operations
- [ ] Memory wiping / zeroization
- [ ] Timing/cache attack mitigations

---

## 14. Testing & Interop
- [ ] NIST test vectors
- [ ] RFC test vectors
- [ ] Wycheproof test suite
- [ ] Cross-platform interoperability harness

---

## 15. Administrative
- [ ] Algorithm agility (runtime selection)
- [ ] FIPS-compliant subset
- [ ] Deprecation strategy
- [ ] Migration guide from `X509Certificate2`

---

### 📌 Priorities for First Release
1. SHA-2, HMAC, HKDF  
2. AES-GCM, ChaCha20-Poly1305  
3. RSA-PSS, RSA-OAEP  
4. ECDSA (P-256) and Ed25519  
5. X.509 certificate creation/parsing/validation  
6. X.509 CSR, CRL and OCSP support
7. X.509 chain validation
8. PKI (Public Key Infrastructure)
9. PQC: Kyber + Dilithium (hybrid support)  

---

© 2025 The Keepers of the CryptoHives
