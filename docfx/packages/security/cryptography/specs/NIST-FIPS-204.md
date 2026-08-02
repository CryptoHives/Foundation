# NIST FIPS 204 - Module-Lattice-Based Digital Signature Algorithm (ML-DSA)

## Overview

NIST FIPS 204 specifies ML-DSA, the module-lattice-based digital signature algorithm standardized as the primary quantum-resistant signature scheme.

- **ML-DSA-44** - Security category 2
- **ML-DSA-65** - Security category 3
- **ML-DSA-87** - Security category 5

## Official Reference

- **Document:** NIST FIPS 204
- **Title:** Module-Lattice-Based Digital Signature Standard
- **URL:** https://csrc.nist.gov/pubs/fips/204/final
- **Status:** Final (August 2024)

## Background

ML-DSA is derived from CRYSTALS-Dilithium, selected in the NIST Post-Quantum Cryptography standardization process (2022). It is a Fiat–Shamir-with-aborts scheme whose security rests on the Module Learning-With-Errors and Module Short-Integer-Solution problems. Together with ML-KEM (FIPS 203) it forms the CNSA 2.0 algorithm pair.

Deployment targets include code signing, firmware signing, X.509 certificates, and protocol signatures (TLS, SSH).

## Implementation Status

| Algorithm | Status | Class |
|-----------|--------|-------|
| ML-DSA-44 | ✅ Implemented | `MlDsa44`, `MlDsa` + `MlDsaAlgorithm.MlDsa44` |
| ML-DSA-65 | ✅ Implemented | `MlDsa65`, `MlDsa` + `MlDsaAlgorithm.MlDsa65` |
| ML-DSA-87 | ✅ Implemented | `MlDsa87`, `MlDsa` + `MlDsaAlgorithm.MlDsa87` |
| HashML-DSA (pre-hash) | ⬜ Not implemented | - |

---

## Construction

ML-DSA signs by committing to w = A·y for a random mask y, deriving a sparse challenge c from the commitment and message, and revealing z = y + c·s₁ only when rejection bounds guarantee z leaks nothing about the secret; otherwise the attempt restarts. Verification recomputes the commitment high bits from z and the public key using a hint vector.

### Parameters (FIPS 204 Table 1)

All parameter sets share the ring R_q = ℤ_q[X]/(X²⁵⁶ + 1) with q = 8380417 = 2²³ − 2¹³ + 1 and d = 13 dropped bits.

| Parameter | ML-DSA-44 | ML-DSA-65 | ML-DSA-87 |
|-----------|----------:|----------:|----------:|
| (k, ℓ) | (4, 4) | (6, 5) | (8, 7) |
| η | 2 | 4 | 2 |
| τ (±1s in c) | 39 | 49 | 60 |
| γ₁ | 2¹⁷ | 2¹⁹ | 2¹⁹ |
| γ₂ | (q−1)/88 | (q−1)/32 | (q−1)/32 |
| ω (max hints) | 80 | 55 | 75 |
| λ (c̃ = λ/4 bytes) | 128 | 192 | 256 |
| Public key | 1,312 B | 1,952 B | 2,592 B |
| Secret key | 2,560 B | 4,032 B | 4,896 B |
| Signature | 2,420 B | 3,309 B | 4,627 B |

### Internal Hash Functions

All symmetric primitives come from the FIPS 202 Keccak family (implemented in the [Hash namespace](../hash-algorithms.md)):

| Function | Instantiation | Purpose |
|----------|---------------|---------|
| H | SHAKE256 (streaming) | Seed expansion, μ, ρ″, tr, commitment hash c̃ |
| G | SHAKE128 (streaming) | Matrix Â rejection sampling (RejNTTPoly) |

### Algorithms

| FIPS 204 | Description | Implementation |
|----------|-------------|----------------|
| Alg. 6 KeyGen_internal | ξ → (pk, sk) | `MlDsaCore.KeyGen` |
| Alg. 7 Sign_internal | Rejection-loop signing, hedged/deterministic | `MlDsaCore.Sign` |
| Alg. 8 Verify_internal | Hint-based verification | `MlDsaCore.Verify` |
| Alg. 16–21 bit/hint packing | SimpleBitPack, BitPack, HintBitPack with strict validation | `Encode` |
| Alg. 22–28 encodings | pkEncode/skEncode/sigEncode/w1Encode + decoders | `Encode` |
| Alg. 29 SampleInBall | Sparse challenge from c̃ | `Sampling.SampleInBall` |
| Alg. 30–34 expansion | RejNTTPoly, RejBoundedPoly, ExpandA/S/Mask | `Sampling` |
| Alg. 35–40 rounding | Power2Round, Decompose, HighBits/LowBits, MakeHint/UseHint | `Poly` |
| Alg. 41/42 NTT | ζ = 1753, Montgomery R = 2³², runtime-derived twiddle table | `Ntt` |

### External Interface (Algorithms 2/3)

The message is domain-separated as M′ = 0x00 ‖ |ctx| ‖ ctx ‖ M with a context string of at most 255 bytes. Hedged signing (fresh 32-byte rnd) is the default; the deterministic variant uses rnd = 0³². HashML-DSA (pre-hash, domain byte 0x01) is not yet implemented.

### Side-Channel Notes

- Infinity-norm checks on secret-dependent vectors (z, r0, c·t0) scan all 256 coefficients without early exit; only the accept/reject decision of a whole candidate — which FIPS 204 sanctions as observable — is branched on.
- Decompose/Power2Round/MakeHint use branch-free multiply-shift arithmetic (no secret-dependent division or lookup).
- Per-iteration secrets are zeroized before resampling; key generation runs a FIPS 140-3 style sign/verify pairwise consistency test.

---

## Test Vectors

Validated against the official NIST ACVP vector sets (keyGen, sigGen deterministic + hedged, sigVer) and cross-checked against BouncyCastle and .NET 10 `MLDsa`. See **[ML-DSA-vectors.md](ML-DSA-vectors.md)** for details and sample vectors.

---

## References

1. **NIST FIPS 204:** https://csrc.nist.gov/pubs/fips/204/final
2. **NIST ACVP test vectors:** https://github.com/usnistgov/ACVP-Server (gen-val/json-files, ML-DSA-*-FIPS204)
3. **CRYSTALS-Dilithium:** https://pq-crystals.org/dilithium/
4. **NIST PQC project:** https://csrc.nist.gov/projects/post-quantum-cryptography
