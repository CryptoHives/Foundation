# Kupyna (DSTU 7564:2014) Test Vectors

## Overview

Kupyna is the Ukrainian national cryptographic hash standard defined in DSTU 7564:2014.
It supports output sizes of 256, 384, and 512 bits.

## Specification

- **Standard:** DSTU 7564:2014 (Ukraine)
- **Output Sizes:** 256, 384, or 512 bits
- **Block Size:** 512 bits (64 bytes) for 256-bit output; 1024 bits (128 bytes) for 384/512-bit output
- **Rounds:** 10 (512-bit state) or 14 (1024-bit state)
- **State Size:** 512 bits (8 columns) for ≤256-bit output; 1024 bits (16 columns) for >256-bit output
- **Structure:** Davies-Meyer compression with two permutations T⊕ (P) and T⁺ (Q)
- **Based on:** Kalyna block cipher (DSTU 7624:2014) round function

## Official Reference

- DSTU 7564:2014 — Ukrainian national standard for hash functions
- IACR ePrint 2015/885: "The Kupyna Hash Function" by Oliynykov et al.
  https://eprint.iacr.org/2015/885.pdf
- Reference implementation by Kiianchuk, Mordvinov, Oliynykov:
  https://github.com/Roman-Oliynykov/Kupyna-reference

## Test Vectors

### Kupyna-256

#### Vector 1: Empty string

```
Input:  "" (empty)
Length: 0 bytes

Output (Kupyna-256):
cd5101d1ccdf0d1d1f4ada56e888cd724ca1a0838a3521e7131d4fb78d0f5eb6
```

#### Vector 2: "The quick brown fox jumps over the lazy dog"

```
Input:  "The quick brown fox jumps over the lazy dog" (ASCII)
Length: 43 bytes

Output (Kupyna-256):
996899f2d7422ceaf552475036b2dc120607eff538abf2b8dff471a98a4740c6
```

#### Vector 3: Official DSTU 7564 — 512 bits (64 bytes) of sequential input

```
Input (hex): 000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f
             202122232425262728292a2b2c2d2e2f303132333435363738393a3b3c3d3e3f
Length: 64 bytes

Output (Kupyna-256):
08F4EE6F1BE6903B324C4E27990CB24EF69DD58DBE84813EE0A52F6631239875
```

#### Vector 4: Official DSTU 7564 — 1024 bits (128 bytes) of sequential input

```
Input (hex): 000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f
             202122232425262728292a2b2c2d2e2f303132333435363738393a3b3c3d3e3f
             404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f
             606162636465666768696a6b6c6d6e6f707172737475767778797a7b7c7d7e7f
Length: 128 bytes

Output (Kupyna-256):
0A9474E645A7D25E255E9E89FFF42EC7EB31349007059284F0B182E452BDA882
```

#### Vector 5: Official DSTU 7564 — 2048 bits (256 bytes) of sequential input

```
Input (hex): 000102030405060708090a0b0c0d0e0f...f0f1f2f3f4f5f6f7f8f9fafbfcfdfeff
             (sequential bytes 0x00 through 0xFF)
Length: 256 bytes

Output (Kupyna-256):
D305A32B963D149DC765F68594505D4077024F836C1BF03806E1624CE176C08F
```

### Kupyna-384

#### Vector 1: Official DSTU 7564 — 760 bits (95 bytes) of sequential input

```
Input (hex): 000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f
             202122232425262728292a2b2c2d2e2f303132333435363738393a3b3c3d3e3f
             404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e
Length: 95 bytes

Output (Kupyna-384):
D9021692D84E5175735654846BA751E6D0ED0FAC36DFBC0841287DCB0B5584C7
5016C3DECC2A6E47C50B2F3811E351B8
```

### Kupyna-512

#### Vector 1: Empty string

```
Input:  "" (empty)
Length: 0 bytes

Output (Kupyna-512):
656b2f4cd71462388b64a37043ea55dbe445d452aecd46c3298343314ef04019
bcfa3f04265a9857f91be91fce197096187ceda78c9c1c021c294a0689198538
```

#### Vector 2: Official DSTU 7564 — 512 bits (64 bytes) of sequential input

```
Input (hex): 000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f
             202122232425262728292a2b2c2d2e2f303132333435363738393a3b3c3d3e3f
Length: 64 bytes

Output (Kupyna-512):
3813E2109118CDFB5A6D5E72F7208DCCC80A2DFB3AFDFB02F46992B5EDBE536B
3560DD1D7E29C6F53978AF58B444E37BA685C0DD910533BA5D78EFFFC13DE62A
```

#### Vector 3: Official DSTU 7564 — 1024 bits (128 bytes) of sequential input

```
Input (hex): 000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f
             202122232425262728292a2b2c2d2e2f303132333435363738393a3b3c3d3e3f
             404142434445464748494a4b4c4d4e4f505152535455565758595a5b5c5d5e5f
             606162636465666768696a6b6c6d6e6f707172737475767778797a7b7c7d7e7f
Length: 128 bytes

Output (Kupyna-512):
76ED1AC28B1D0143013FFA87213B4090B356441263C13E03FA060A8CADA32B97
9635657F256B15D5FCA4A174DE029F0B1B4387C878FCC1C00E8705D783FD7FFE
```

#### Vector 4: Official DSTU 7564 — 2048 bits (256 bytes) of sequential input

```
Input (hex): 000102030405060708090a0b0c0d0e0f...f0f1f2f3f4f5f6f7f8f9fafbfcfdfeff
             (sequential bytes 0x00 through 0xFF)
Length: 256 bytes

Output (Kupyna-512):
0DD03D7350C409CB3C29C25893A0724F6B133FA8B9EB90A64D1A8FA93B565566
11EB187D715A956B107E3BFC76482298133A9CE8CBC0BD5E1436A5B197284F7E
```

## Algorithm Details

### Initial Vector (IV)

```
Kupyna-256: state[0] = 0x40 (64), all other columns zero  (block size = 64 bytes)
Kupyna-384: state[0] = 0x80 (128), all other columns zero (block size = 128 bytes)
Kupyna-512: state[0] = 0x80 (128), all other columns zero (block size = 128 bytes)
```

### Compression Function

The compression function uses Davies-Meyer mode:
```
h = P(h ⊕ m) ⊕ Q(m) ⊕ h
```

Where P (T⊕) and Q (T⁺) are fixed permutations using the same round structure
but different round constant addition methods (XOR for P, modular addition for Q).

### Round Structure

Each round applies four operations in sequence:
1. **AddRoundConstant** — XOR-based (P) or addition-based (Q)
2. **SubBytes** — Four cyclic S-boxes: row `i` uses `S[i mod 4]`
3. **ShiftBytes** — Cyclic left shift per row (shift amounts depend on state size)
4. **MixColumns** — Circulant MDS matrix [1, 1, 5, 1, 8, 6, 7, 4] over GF(2^8) with polynomial 0x11D

### ShiftBytes Offsets

| State Size | Row 0 | Row 1 | Row 2 | Row 3 | Row 4 | Row 5 | Row 6 | Row 7 |
|------------|-------|-------|-------|-------|-------|-------|-------|-------|
| 512-bit    | 0     | 1     | 2     | 3     | 4     | 5     | 6     | 7     |
| 1024-bit   | 0     | 1     | 2     | 3     | 4     | 5     | 6     | 11    |

### Padding

DSTU 7564 padding appends:
1. A single `0x80` byte
2. Zero bytes as needed
3. A 96-bit little-endian message length in bits (in the last 12 bytes of the block)

### Output Transformation

After processing all blocks:
```
state = state ⊕ P(state)
```
The hash is taken from the last `hashSize` bytes of the state.

## Compliance Requirements

Kupyna is required for:
- Ukrainian government cryptographic applications
- Ukrainian electronic signatures (together with DSTU 4145 elliptic curves)
- Products certified under Ukrainian cryptography regulations

## Implementation Notes

- State is organized as an array of 64-bit columns in little-endian byte order
- The algorithm uses four distinct S-boxes (S0, S1, S2, S3) applied cyclically by row
- The MDS matrix is circulant, enabling efficient implementation via T-table precomputation
- Reduction polynomial for GF(2^8): x⁸ + x⁴ + x³ + x² + 1 (0x11D)
