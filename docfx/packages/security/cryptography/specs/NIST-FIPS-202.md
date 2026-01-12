# NIST FIPS 202 - SHA-3 Standard

## Overview

Federal Information Processing Standards Publication 202 specifies the SHA-3 family of hash functions based on the Keccak algorithm:

- **SHA3-224** - 224-bit hash
- **SHA3-256** - 256-bit hash
- **SHA3-384** - 384-bit hash
- **SHA3-512** - 512-bit hash
- **SHAKE128** - Extendable-output function (XOF), 128-bit security
- **SHAKE256** - Extendable-output function (XOF), 256-bit security

## Official Reference

- **Document:** NIST FIPS 202
- **Title:** SHA-3 Standard: Permutation-Based Hash and Extendable-Output Functions
- **URL:** https://csrc.nist.gov/pubs/fips/202/final
- **PDF:** https://nvlpubs.nist.gov/nistpubs/FIPS/NIST.FIPS.202.pdf

## Implementation Status

| Algorithm | Output Size | Status | Class |
|-----------|-------------|--------|-------|
| SHA3-224 | 224 bits | ✅ Implemented | `SHA3_224` |
| SHA3-256 | 256 bits | ✅ Implemented | `SHA3_256` |
| SHA3-384 | 384 bits | ✅ Implemented | `SHA3_384` |
| SHA3-512 | 512 bits | ✅ Implemented | `SHA3_512` |
| SHAKE128 | Variable | ✅ Implemented | `Shake128` |
| SHAKE256 | Variable | ✅ Implemented | `Shake256` |

---

## Keccak Sponge Construction

SHA-3 is based on the **sponge construction** with the Keccak-f[1600] permutation.

### State Structure

- **State size:** 1600 bits (5 × 5 × 64)
- **Organized as:** 25 lanes of 64 bits each
- **Permutation:** Keccak-f[1600] with 24 rounds

### Sponge Parameters

| Function | Capacity (c) | Rate (r) | Security | Output |
|----------|--------------|----------|----------|--------|
| SHA3-224 | 448 bits | 1152 bits (144 bytes) | 112 bits | 224 bits |
| SHA3-256 | 512 bits | 1088 bits (136 bytes) | 128 bits | 256 bits |
| SHA3-384 | 768 bits | 832 bits (104 bytes) | 192 bits | 384 bits |
| SHA3-512 | 1024 bits | 576 bits (72 bytes) | 256 bits | 512 bits |
| SHAKE128 | 256 bits | 1344 bits (168 bytes) | 128 bits | Variable |
| SHAKE256 | 512 bits | 1088 bits (136 bytes) | 256 bits | Variable |

### Sponge Operation

```
SPONGE(M, d):
  1. Pad message M to multiple of rate r
  2. ABSORB: XOR padded blocks into state, apply permutation after each
  3. SQUEEZE: Extract d bits from rate portion, apply permutation between extractions
```

---

## Keccak-f[1600] Permutation

The permutation consists of 24 rounds, each with 5 steps:

### θ (Theta) - Column Parity Mixing
```
C[x] = A[x,0] ⊕ A[x,1] ⊕ A[x,2] ⊕ A[x,3] ⊕ A[x,4]
D[x] = C[x-1] ⊕ ROT(C[x+1], 1)
A[x,y] = A[x,y] ⊕ D[x]
```

### ρ (Rho) - Bit Rotation
Each lane is rotated by a fixed offset (0 to 63 bits).

### π (Pi) - Lane Permutation
```
B[y, 2x+3y] = A[x,y]
```

### χ (Chi) - Non-linear Mixing
```
A[x,y] = B[x,y] ⊕ ((NOT B[x+1,y]) AND B[x+2,y])
```

### ι (Iota) - Round Constant Addition
```
A[0,0] = A[0,0] ⊕ RC[round]
```

### Round Constants

```
RC[ 0] = 0x0000000000000001    RC[12] = 0x000000008000808b
RC[ 1] = 0x0000000000008082    RC[13] = 0x800000000000008b
RC[ 2] = 0x800000000000808a    RC[14] = 0x8000000000008089
RC[ 3] = 0x8000000080008000    RC[15] = 0x8000000000008003
RC[ 4] = 0x000000000000808b    RC[16] = 0x8000000000008002
RC[ 5] = 0x0000000080000001    RC[17] = 0x8000000000000080
RC[ 6] = 0x8000000080008081    RC[18] = 0x000000000000800a
RC[ 7] = 0x8000000000008009    RC[19] = 0x800000008000000a
RC[ 8] = 0x000000000000008a    RC[20] = 0x8000000080008081
RC[ 9] = 0x0000000000000088    RC[21] = 0x8000000000008080
RC[10] = 0x0000000080008009    RC[22] = 0x0000000080000001
RC[11] = 0x000000008000000a    RC[23] = 0x8000000080008008
```

---

## Padding

### SHA-3 Padding (pad10*1)

SHA-3 hash functions use domain separator `0x06`:
```
M || 0x06 || 0x00...0x00 || 0x80
```

The padding ensures the message ends with `...0110...0001` in bit notation.

### SHAKE Padding

SHAKE XOFs use domain separator `0x1F`:
```
M || 0x1F || 0x00...0x00 || 0x80
```

---

## SHA-3 vs Keccak

> **Important:** SHA-3 (FIPS 202) uses different padding than the original Keccak submission.

| Aspect | Keccak (Original) | SHA-3 (FIPS 202) |
|--------|-------------------|------------------|
| Domain separator | `0x01` | `0x06` |
| Usage | Ethereum, pre-NIST | NIST standard |
| Implementation | `Keccak256` | `SHA3_256` |

For Ethereum compatibility, use `Keccak256`. For NIST compliance, use `SHA3_256`.

---

## Extendable-Output Functions (XOFs)

SHAKE128 and SHAKE256 can produce arbitrary-length output:

```csharp
// Request 64 bytes of output
using var shake = Shake256.Create(outputBytes: 64);
byte[] hash = shake.ComputeHash(data);
```

### Use Cases

- **Key derivation:** Generate keys of any length
- **Stream cipher:** Use as keystream generator
- **Variable-length hashing:** When output size isn't fixed

---

## Test Vectors

### SHA3-256

**Empty String:**
- Input: "" (0 bytes)
- Output: `a7ffc6f8bf1ed76651c14756a061d662f580ff4de43b49fa82d80a4b80f8434a`

**"abc":**
- Input: "abc" (3 bytes)
- Output: `3a985da74fe225b2045c172d6bd390bd855f086e3e9d525b46bfe24511431532`

### SHA3-512

**Empty String:**
- Input: "" (0 bytes)
- Output: `a69f73cca23a9ac5c8b567dc185a756e97c982164fe25859e0d1dcc1475c80a6 15b2123af1f5f94c11e3e9402c3ac558f500199d95b6d3e301758586281dcd26`

**"abc":**
- Input: "abc" (3 bytes)
- Output: `b751850b1a57168a5693cd924b6b096e08f621827444f70d884f5d0240d2712e 10e116e9192af3c91a7ec57647e3934057340b4cf408d5a56592f8274eec53f0`

### SHA3-224

**"abc":**
- Input: "abc" (3 bytes)
- Output: `e642824c3f8cf24ad09234ee7d3c766fc9a3a5168d0c94ad73b46fdf`

### SHA3-384

**"abc":**
- Input: "abc" (3 bytes)
- Output: `ec01498288516fc926459f58e2c6ad8df9b473cb0fc08c2596da7cf0e49be4b2 98d88cea927ac7f539f1edf228376d25`

### SHAKE128

**Empty String (256-bit output):**
- Input: "" (0 bytes)
- Output: `7f9c2ba4e88f827d616045507605853ed73b8093f6efbc88eb1a6eacfa66ef26`

### SHAKE256

**Empty String (512-bit output):**
- Input: "" (0 bytes)
- Output: `46b9dd2b0ba88d13233b3feb743eeb243fcd52ea62b81b82b50c27646ed5762f d75dc4ddd8c0f200cb05019d67b592f6fc821c49479ab48640292eacb3b7c4be`

---

## Security Properties

| Algorithm | Collision | Preimage | 2nd Preimage |
|-----------|-----------|----------|--------------|
| SHA3-224 | 112 bits | 224 bits | 224 bits |
| SHA3-256 | 128 bits | 256 bits | 256 bits |
| SHA3-384 | 192 bits | 384 bits | 384 bits |
| SHA3-512 | 256 bits | 512 bits | 512 bits |
| SHAKE128 | min(d/2, 128) | min(d, 128) | min(d, 128) |
| SHAKE256 | min(d/2, 256) | min(d, 256) | min(d, 256) |

Where `d` is the output length in bits for XOFs.

---

## Comparison: SHA-2 vs SHA-3

| Aspect | SHA-2 | SHA-3 |
|--------|-------|-------|
| Construction | Merkle–Damgård | Sponge |
| Internal state | Compression function | Permutation |
| Parallelism | Limited | Better |
| Length extension | Vulnerable | Resistant |
| Hardware efficiency | Good | Excellent |
| Side-channel resistance | Moderate | Better |

SHA-3 provides defense-in-depth as an alternative to SHA-2, using a completely different design.

---

## Related Standards

- **NIST SP 800-185** - cSHAKE, KMAC, TupleHash, ParallelHash (SHA-3 derived functions)
- **NIST FIPS 180-4** - SHA-1 and SHA-2 family

---

## References

1. NIST FIPS 202: https://doi.org/10.6028/NIST.FIPS.202
2. Keccak Team: https://keccak.team/
3. SHA-3 Examples: https://csrc.nist.gov/projects/cryptographic-standards-and-guidelines/example-values
4. Keccak Reference: https://keccak.team/keccak_specs_summary.html
