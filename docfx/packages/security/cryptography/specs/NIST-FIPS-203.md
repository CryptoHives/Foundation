# NIST FIPS 203 - Module-Lattice-Based Key-Encapsulation Mechanism (ML-KEM)

## Overview

NIST FIPS 203 specifies ML-KEM, the module-lattice-based key encapsulation mechanism standardized as the primary quantum-resistant key-establishment scheme.

- **ML-KEM-512** - Security category 1 (comparable to AES-128)
- **ML-KEM-768** - Security category 3 (comparable to AES-192)
- **ML-KEM-1024** - Security category 5 (comparable to AES-256)

## Official Reference

- **Document:** NIST FIPS 203
- **Title:** Module-Lattice-Based Key-Encapsulation Mechanism Standard
- **URL:** https://csrc.nist.gov/pubs/fips/203/final
- **Status:** Final (August 2024)

## Background

ML-KEM is derived from CRYSTALS-Kyber, the winner of the NIST Post-Quantum Cryptography standardization process (selected 2022). Its security rests on the Module Learning-With-Errors (Module-LWE) problem, which is believed hard for both classical and quantum adversaries.

ML-KEM replaces RSA and (EC)DH key establishment in a post-quantum setting and is deployed in:
- TLS 1.3 hybrid key exchange (X25519MLKEM768)
- Signal PQXDH
- SSH hybrid key exchange
- CNSA 2.0 migration profiles

## Implementation Status

| Algorithm | Status | Class |
|-----------|--------|-------|
| ML-KEM-512 | ✅ Implemented | `MlKem512`, `MlKem` + `MlKemAlgorithm.MlKem512` |
| ML-KEM-768 | ✅ Implemented | `MlKem768`, `MlKem` + `MlKemAlgorithm.MlKem768` |
| ML-KEM-1024 | ✅ Implemented | `MlKem1024`, `MlKem` + `MlKemAlgorithm.MlKem1024` |

---

## Construction

ML-KEM combines an IND-CPA-secure public-key encryption scheme (K-PKE) with the Fujisaki–Okamoto transform using implicit rejection to obtain an IND-CCA2-secure KEM.

### Parameters (FIPS 203 Table 1)

All parameter sets share the ring R_q = ℤ_q[X]/(X²⁵⁶ + 1) with q = 3329 and n = 256.

| Parameter | ML-KEM-512 | ML-KEM-768 | ML-KEM-1024 |
|-----------|-----------:|-----------:|------------:|
| k (module rank) | 2 | 3 | 4 |
| η₁ (secret/error CBD) | 3 | 2 | 2 |
| η₂ (encryption noise CBD) | 2 | 2 | 2 |
| d_u (u compression bits) | 10 | 10 | 11 |
| d_v (v compression bits) | 4 | 4 | 5 |
| Encapsulation key | 800 B | 1,184 B | 1,568 B |
| Decapsulation key | 1,632 B | 2,400 B | 3,168 B |
| Ciphertext | 768 B | 1,088 B | 1,568 B |
| Shared secret | 32 B | 32 B | 32 B |
| Decryption failure rate | 2⁻¹³⁹ | 2⁻¹⁶⁴ | 2⁻¹⁷⁴ |

### Internal Hash Functions (FIPS 203 §4.1)

All symmetric primitives are instantiated from the FIPS 202 Keccak family (implemented in the [Hash namespace](../hash-algorithms.md)):

| Function | Instantiation | Purpose |
|----------|---------------|---------|
| H | SHA3-256 | Key hashing (ek fingerprint in dk) |
| G | SHA3-512 | Seed expansion, (K, r) derivation |
| J | SHAKE256 (32 bytes) | Implicit rejection secret K̄ = J(z ‖ c) |
| PRF | SHAKE256 (64·η bytes) | CBD sampling input |
| XOF | SHAKE128 (streaming) | Matrix Â rejection sampling (SampleNTT) |

### Algorithms

| FIPS 203 | Description | Implementation |
|----------|-------------|----------------|
| Alg. 6 SampleNTT | Uniform rejection sampling from SHAKE128 | `Poly.SampleNtt` (streaming `Absorb`/`Squeeze`) |
| Alg. 8 SamplePolyCBD | Centered binomial distribution η ∈ {2, 3} | `Cbd.Sample` |
| Alg. 9/10 NTT / NTT⁻¹ | Number-theoretic transform, ζ = 17 | `Ntt.Forward` / `Ntt.Inverse` (Montgomery arithmetic) |
| Alg. 11 BaseCaseMultiply | Degree-1 products in ℤ_q[X]/(X² − ζ) | `Ntt.BaseCaseMultiply` |
| Alg. 13–15 K-PKE | Inner PKE KeyGen/Encrypt/Decrypt | `MlKemCore.KPkeKeyGen/KPkeEncrypt/KPkeDecrypt` |
| Alg. 16 ML-KEM.KeyGen | (ek, dk) from 64-byte seed (d ‖ z) | `MlKemCore.KeyGen` |
| Alg. 17 ML-KEM.Encaps | (K, c) from ek and random m | `MlKemCore.Encaps` |
| Alg. 18 ML-KEM.Decaps | K from dk and c, implicit rejection | `MlKemCore.Decaps` |

### Input Checks (FIPS 203 §7)

| Check | Where | Behavior |
|-------|-------|----------|
| §7.2 modulus check on ek | `Encapsulate`, `MlKem.ImportEncapsulationKey` | Every 12-bit coefficient < q, else rejected |
| §7.3 hash check on dk | `Decapsulate`, `MlKem.ImportDecapsulationKey` | Stored H(ekPKE) must match recomputed hash |
| Pairwise consistency test | Key generation | Encaps/decaps round-trip verified (FIPS 140-3) |

### Side-Channel Notes

- Decapsulation compares c with the re-encrypted c′ in constant time and selects K′ or K̄ via a branchless byte mask — the accept/reject decision never surfaces as a branch or a `bool`.
- Modular reduction uses Barrett and Montgomery multiply-shift sequences; no secret-dependent division or lookup.
- Secret intermediates are zeroized before scope exit; disposal of `MlKem` zeroizes retained key material.

---

## Test Vectors

Validated against the official NIST ACVP vector sets and cross-checked against BouncyCastle and .NET 10 `MLKem`. See **[ML-KEM-vectors.md](ML-KEM-vectors.md)** for details and sample vectors.

---

## References

1. **NIST FIPS 203:** https://csrc.nist.gov/pubs/fips/203/final
2. **NIST ACVP test vectors:** https://github.com/usnistgov/ACVP-Server (gen-val/json-files, ML-KEM-*-FIPS203)
3. **CRYSTALS-Kyber:** https://pq-crystals.org/kyber/
4. **NIST PQC project:** https://csrc.nist.gov/projects/post-quantum-cryptography
