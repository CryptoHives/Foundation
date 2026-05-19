# ParallelHash Test Vectors (NIST SP 800-185)

## Overview

Test vectors for `ParallelHash128` and `ParallelHash256` from NIST SP 800-185 Appendix A.4.

All vectors are verified by the NUnit suite in
`tests/Security/Cryptography/Hash/ParallelHashTests.cs`.

---

## ParallelHash128

Inner block hash: SHAKE128 (256-bit output = 32-byte chaining values)
Finalization: cSHAKE128, N=`"ParallelHash"`, S=user customization string

### Sample #1 — empty customization

```
Input (24 bytes):
  00 01 02 03 04 05 06 07
  10 11 12 13 14 15 16 17
  20 21 22 23 24 25 26 27

Block size B: 8 bytes  (3 blocks)
Customization S: "" (empty)
Output length L: 256 bits (32 bytes)

Output:
  BA 8D C1 D1 D9 79 33 1D 3F 81 36 03 C6 7F 72 60
  9A B5 E4 4B 94 A0 B8 F9 AF 46 51 44 54 A2 B4 F5
```

### Sample #2 — with customization string

```
Input (24 bytes):
  00 01 02 03 04 05 06 07
  10 11 12 13 14 15 16 17
  20 21 22 23 24 25 26 27

Block size B: 8 bytes  (3 blocks)
Customization S: "Parallel Data"
Output length L: 256 bits (32 bytes)

Output:
  FC 48 4D CB 3F 84 DC EE DC 35 34 38 15 1B EE 58
  15 7D 6E FE D0 44 5A 81 F1 65 E4 95 79 5B 72 06
```

### Sample #3 — larger input, different block size

```
Input (72 bytes):
  00 01 02 03 04 05 06 07 08 09 0A 0B
  10 11 12 13 14 15 16 17 18 19 1A 1B
  20 21 22 23 24 25 26 27 28 29 2A 2B
  30 31 32 33 34 35 36 37 38 39 3A 3B
  40 41 42 43 44 45 46 47 48 49 4A 4B
  50 51 52 53 54 55 56 57 58 59 5A 5B
  60 61 62 63 64 65 66 67 68 69 6A 6B
  70 71 72 73 74 75 76 77 78 79 7A 7B

Block size B: 12 bytes  (6 blocks)
Customization S: "Parallel Data"
Output length L: 256 bits (32 bytes)

Output:
  F7 FD 53 12 89 6C 66 85 C8 28 AF 7E 2A DB 97 E3
  93 E7 F8 D5 4E 3C 2E A4 B9 5E 5A CA 37 96 E8 FC
```

---

## ParallelHash256

Inner block hash: SHAKE256 (512-bit output = 64-byte chaining values)
Finalization: cSHAKE256, N=`"ParallelHash"`, S=user customization string

### Sample #1 — empty customization

```
Input (24 bytes):
  00 01 02 03 04 05 06 07
  10 11 12 13 14 15 16 17
  20 21 22 23 24 25 26 27

Block size B: 8 bytes  (3 blocks)
Customization S: "" (empty)
Output length L: 512 bits (64 bytes)

Output:
  BC 1E F1 24 DA 34 49 5E 94 8E AD 20 7D D9 84 22
  35 DA 43 2D 2B BC 54 B4 C1 10 E6 4C 45 11 05 53
  1B 7F 2A 3E 0C E0 55 C0 28 05 E7 C2 DE 1F B7 46
  AF 97 A1 DD 01 F4 3B 82 4E 31 B8 76 12 41 04 29
```

### Sample #2 — with customization string

```
Input (24 bytes):
  00 01 02 03 04 05 06 07
  10 11 12 13 14 15 16 17
  20 21 22 23 24 25 26 27

Block size B: 8 bytes  (3 blocks)
Customization S: "Parallel Data"
Output length L: 512 bits (64 bytes)

Output:
  CD F1 52 89 B5 4F 62 12 B4 BC 27 05 28 B4 95 26
  00 6D D9 B5 4E 2B 6A DD 1E F6 90 0D DA 39 63 BB
  33 A7 24 91 F2 36 96 9C A8 AF AE A2 9C 68 2D 47
  A3 93 C0 65 B3 8E 29 FA E6 51 A2 09 1C 83 31 10
```

### Sample #3 — larger input, different block size

```
Input (72 bytes):
  00 01 02 03 04 05 06 07 08 09 0A 0B
  10 11 12 13 14 15 16 17 18 19 1A 1B
  20 21 22 23 24 25 26 27 28 29 2A 2B
  30 31 32 33 34 35 36 37 38 39 3A 3B
  40 41 42 43 44 45 46 47 48 49 4A 4B
  50 51 52 53 54 55 56 57 58 59 5A 5B
  60 61 62 63 64 65 66 67 68 69 6A 6B
  70 71 72 73 74 75 76 77 78 79 7A 7B

Block size B: 12 bytes  (6 blocks)
Customization S: "Parallel Data"
Output length L: 512 bits (64 bytes)

Output:
  69 D0 FC B7 64 EA 05 5D D0 93 34 BC 60 21 CB 7E
  4B 61 34 8D FF 37 5D A2 62 67 1C DE C3 EF FA 8D
  1B 45 68 A6 CC E1 6B 1C AD 94 6D DD E2 7F 6C E2
  B8 DE E4 CD 1B 24 85 1E BF 00 EB 90 D4 38 13 E9
```

---

## References

- NIST SP 800-185: <https://doi.org/10.6028/NIST.SP.800-185>
- Bouncy Castle C# reference: `ParallelHashTest.cs`

---

© 2026 The Keepers of the CryptoHives
