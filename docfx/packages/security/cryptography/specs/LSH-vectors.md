# LSH (KS X 3262) Test Vectors

## Overview

LSH is the Korean national cryptographic hash standard defined in KS X 3262, designed by KISA
(Korea Internet & Security Agency). It comes in two families: LSH-256 (32-bit words) and
LSH-512 (64-bit words), each supporting multiple output sizes.

## Specification

- **Standard:** KS X 3262 (South Korea), approved by KCMVP
- **Families:** LSH-256 (32-bit words) and LSH-512 (64-bit words)
- **Output Sizes:**
  - LSH-256: 224 or 256 bits
  - LSH-512: 224, 256, 384, or 512 bits
- **Block Size:** 128 bytes (LSH-256) or 256 bytes (LSH-512)
- **Steps:** 26 (LSH-256) or 28 (LSH-512)
- **Structure:** Wide-pipe Merkle-Damgård with 16-word chaining variable split into left/right halves

## Official Reference

- KS X 3262 — Korean national standard for hash functions
- KISA (Korea Internet & Security Agency): https://seed.kisa.or.kr/kisa/algorithm/EgovLSHInfo.do

## Test Vectors

Test vectors sourced from the [Wikipedia LSH hash function article](https://en.wikipedia.org/wiki/LSH_(hash_function)).

### LSH-256

#### Vector 1: "abc" — LSH-256-224

```
Input:  "abc" (ASCII)
Length: 3 bytes

Output (LSH-256-224):
F7C53BA4034E708E74FBA42E55997CA5126BB7623688F85342F73732
```

#### Vector 2: "abc" — LSH-256-256

```
Input:  "abc" (ASCII)
Length: 3 bytes

Output (LSH-256-256):
5FBF365DAEA5446A7053C52B57404D77A07A5F48A1F7C1963A0898BA1B714741
```

### LSH-512

#### Vector 1: "abc" — LSH-512-224

```
Input:  "abc" (ASCII)
Length: 3 bytes

Output (LSH-512-224):
D1683234513EC5698394571EAD128A8CD5373E97661BA20DCF89E489
```

#### Vector 2: "abc" — LSH-512-256

```
Input:  "abc" (ASCII)
Length: 3 bytes

Output (LSH-512-256):
CD892310532602332B613F1EC11A6962FCA61EA09ECFFCD4BCF75858D802EDEC
```

#### Vector 3: "abc" — LSH-512-384

```
Input:  "abc" (ASCII)
Length: 3 bytes

Output (LSH-512-384):
5F344EFAA0E43CCD2E5E194D6039794B4FB431F10FB4B65FD45E9DA4ECDE0F27
B66E8DBDFA47252E0D0B741BFD91F9FE
```

#### Vector 4: "abc" — LSH-512-512

```
Input:  "abc" (ASCII)
Length: 3 bytes

Output (LSH-512-512):
A3D93CFE60DC1AACDD3BD4BEF0A6985381A396C7D49D9FD177795697C3535208
B5C57224BEF21084D42083E95A4BD8EB33E869812B65031C428819A1E7CE596D
```

## Algorithm Details

### Chaining Variable

Both families use a 16-word chaining variable (CV) split into left and right halves of 8 words:

```
LSH-256: CV = 16 × 32-bit words = 512 bits (wide-pipe for ≤256-bit output)
LSH-512: CV = 16 × 64-bit words = 1024 bits (wide-pipe for ≤512-bit output)
```

### Step Function

Each step applies three operations in sequence:

1. **Message Addition** — XOR sub-message words into the chaining variable
2. **Mixing Function** — Rotation-based diffusion with alternating constants:
   - LSH-256: α=29, β=1 (even steps); α=5, β=17 (odd steps); γ = [0, 8, 16, 24, 24, 16, 8, 0]
   - LSH-512: α=23, β=59 (even steps); α=7, β=3 (odd steps); γ = [0, 16, 32, 48, 8, 24, 40, 56]
3. **Word Permutation** — Fixed permutation τ applied to the chaining variable words

### Finalization

After all steps:

```
H[l] = cv_L[l] ⊕ cv_R[l]    (for l = 0..7)
```

The hash is taken from the first `hashSize` bytes of H.

### Padding

LSH uses standard one-zeros padding: append `0x80`, then zero bytes to fill the block.

## Compliance Requirements

LSH is required for:
- Korean government cryptographic applications
- Products certified under KCMVP (Korea Cryptographic Module Validation Program)
- Systems requiring compliance with KS X 3262
