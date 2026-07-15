# NIST FIPS 205 - Stateless Hash-Based Digital Signature Algorithm (SLH-DSA)

## Overview

NIST FIPS 205 specifies SLH-DSA, the stateless hash-based digital signature algorithm standardized as the conservative quantum-resistant signature scheme.

Twelve parameter sets: SLH-DSA-{SHA2, SHAKE}-{128, 192, 256}{s, f} — two hash instantiations × three security categories × a small-signature (s) / fast-signing (f) trade-off.

## Official Reference

- **Document:** NIST FIPS 205
- **Title:** Stateless Hash-Based Digital Signature Standard
- **URL:** https://csrc.nist.gov/pubs/fips/205/final
- **Status:** Final (August 2024)

## Background

SLH-DSA is derived from SPHINCS+, selected in the NIST Post-Quantum Cryptography standardization process (2022). Unlike lattice-based ML-DSA, its security rests **only** on the collision and preimage resistance of the underlying hash functions — the most conservative security assumption available. This makes it the preferred choice for long-lived roots of trust, firmware and code signing, and CA keys, at the cost of large signatures and slow signing.

Being *stateless*, it avoids the dangerous key-state management of LMS/XMSS (SP 800-208) while providing the same hash-based assurance.

## Implementation Status

| Variant | Status | Class |
|---------|--------|-------|
| SLH-DSA (pure), all 12 parameter sets | ✅ Implemented | `SlhDsa` + `SlhDsaAlgorithm` |
| HashSLH-DSA (pre-hash, §10.2) | ✅ Implemented | `SlhDsa.SignPreHash` / `SlhDsa.VerifyPreHash` |

---

## Construction

SLH-DSA signs a randomized message digest with a FORS few-time signature, whose public key is in turn signed by a hypertree: d layers of XMSS Merkle trees whose leaves are WOTS+ one-time keys. The huge virtual key space (2^h leaves) makes deliberate state management unnecessary.

### Parameters (FIPS 205 Table 2)

| Parameter | 128s | 128f | 192s | 192f | 256s | 256f |
|-----------|-----:|-----:|-----:|-----:|-----:|-----:|
| n (bytes) | 16 | 16 | 24 | 24 | 32 | 32 |
| h / d / h′ | 63 / 7 / 9 | 66 / 22 / 3 | 63 / 7 / 9 | 66 / 22 / 3 | 64 / 8 / 8 | 68 / 17 / 4 |
| a / k (FORS) | 12 / 14 | 6 / 33 | 14 / 17 | 8 / 33 | 14 / 22 | 9 / 35 |
| Public key | 32 B | 32 B | 48 B | 48 B | 64 B | 64 B |
| Secret key | 64 B | 64 B | 96 B | 96 B | 128 B | 128 B |
| Signature | 7,856 B | 17,088 B | 16,224 B | 35,664 B | 29,792 B | 49,856 B |

All sets use the Winternitz parameter lg_w = 4 (w = 16).

### Hash Instantiations (FIPS 205 §11)

| Function | SHAKE (§11.1) | SHA-2, category 1 (§11.2.1) | SHA-2, categories 3/5 (§11.2.2) |
|----------|---------------|------------------------------|----------------------------------|
| H_msg | SHAKE256 | MGF1-SHA-256 ∘ SHA-256 | MGF1-SHA-512 ∘ SHA-512 |
| PRF_msg | SHAKE256 | HMAC-SHA-256 | HMAC-SHA-512 |
| PRF, F | SHAKE256 | SHA-256 (compressed ADRS) | SHA-256 (compressed ADRS) |
| H, T_ℓ | SHAKE256 | SHA-256 (compressed ADRS) | SHA-512 (compressed ADRS) |

The SHA-2 instantiation pads PK.seed to the hash block size and uses the 22-byte compressed address form; the SHAKE instantiation uses the full 32-byte ADRS.

### Algorithms

| FIPS 205 | Description | Implementation |
|----------|-------------|----------------|
| Alg. 4 base_2b | Bit-string splitting | `Fors.Base2b` |
| Alg. 5–8 WOTS+ | chain, pkGen, sign, pkFromSig | `Wots` |
| Alg. 9–11 XMSS | treehash node, sign, pkFromSig | `XmssTree` |
| Alg. 12/13 hypertree | ht_sign, ht_verify | `Hypertree` |
| Alg. 14–17 FORS | skGen, node, sign, pkFromSig | `Fors` |
| Alg. 18–20 SLH-DSA internal | keygen, sign, verify | `SlhDsaCore` |
| §4.2 ADRS | 32-byte address + 22-byte compressed form | `Adrs` |

### External Interface

The message is domain-separated as M′ = 0x00 ‖ |ctx| ‖ ctx ‖ M with a context string of at most 255 bytes (same prefix scheme as ML-DSA). Hedged signing (fresh n-byte opt_rand) is the default; the deterministic variant uses opt_rand = PK.seed. HashSLH-DSA (§10.2, domain byte 0x01, M′ = 0x01 ‖ |ctx| ‖ ctx ‖ OID ‖ PH(M)) is available via `SignPreHash`/`VerifyPreHash` for all twelve approved pre-hash functions.

### Performance Characteristics

Hash-based signing is expensive by design — an SLH-DSA-128s signature requires on the order of 10⁶ hash invocations. The **f** sets sign roughly an order of magnitude faster at ~2× the signature size; verification is fast for every set. Key generation for the **s** sets is also noticeably slower (larger top trees) and includes a sign/verify pairwise consistency test (FIPS 140-3).

---

## Test Vectors

Validated against the official NIST ACVP vector sets (keyGen for all 12 sets; sigGen deterministic + hedged; sigVer including modified R/SIGFORS/SIGHT/message and wrong-length cases) and cross-checked against BouncyCastle and .NET 10 `SlhDsa`. See **[SLH-DSA-vectors.md](SLH-DSA-vectors.md)**.

---

## References

1. **NIST FIPS 205:** https://csrc.nist.gov/pubs/fips/205/final
2. **NIST ACVP test vectors:** https://github.com/usnistgov/ACVP-Server (gen-val/json-files, SLH-DSA-*-FIPS205)
3. **SPHINCS+:** https://sphincs.org/
4. **NIST PQC project:** https://csrc.nist.gov/projects/post-quantum-cryptography
