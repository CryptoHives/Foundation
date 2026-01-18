# SM3 Test Vectors

## Overview

SM3 is the Chinese national cryptographic hash function standard, defined in
GB/T 32905-2016. It produces a 256-bit hash value and is structurally similar
to SHA-256 but with different constants and operations.

## Specification

- **Standard:** GB/T 32905-2016 (China), ISO/IEC 10118-3:2018
- **Output Size:** 256 bits (32 bytes)
- **Block Size:** 512 bits (64 bytes)
- **Rounds:** 64
- **Word Size:** 32 bits

## Official Reference

- GB/T 32905-2016: "Information security techniques — SM3 cryptographic hash algorithm"
- ISO/IEC 10118-3:2018 (includes SM3)
- https://www.oscca.gov.cn/ (State Cryptography Administration of China)

## Test Vectors

### Vector 1: Standard test message

```
Input:  "abc"
Length: 3 bytes (24 bits)
Hex:    616263

Output: 66c7f0f462eeedd9d1f2d46bdc10e4e24167c4875cf2f7a2297da02b8f4ba8e0
```

### Vector 2: Extended test message

```
Input:  "abcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcdabcd"
Length: 64 bytes (512 bits, exactly one block)

Output: debe9ff92275b8a138604889c18e5a4d6fdb70e5387e5765293dcba39c0c5732
```

### Vector 3: Empty string

```
Input:  "" (empty)
Length: 0 bytes

Output: 1ab21d8355cfa17f8e61194831e81a8f22bec8c728fefb747ed035eb5082aa2b
```

### Vector 4: Single byte

```
Input:  "a"
Length: 1 byte
Hex:    61

Output: 623476ac18f65a2909e43c7fec61b49c7e764a91a18ccb82f1917a29c86c5e88
```

### Vector 5: 55 bytes (padding boundary)

```
Input:  "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcde"
Length: 55 bytes

Output: (implementation dependent - verify with reference)
```

### Vector 6: 56 bytes (requires extra block)

```
Input:  "abcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdef"
Length: 56 bytes

Output: (implementation dependent - verify with reference)
```

### Vector 7: Binary test data

```
Input (hex): 0090414C494345313233405941484F4F2E434F4D787968B4FA32C3FD2417842E73BBFEFF2F3C848B6831D7E0EC65228B3937E49863E4C6D3B23B0C849CF84241484BFE48F61D59A5B16BA06E6E12D1DA27C5249A421DEBD61B62EAB6746434EBC3CC315E32220B3BADD50BDC4C4E6C147FEDD43D0680512BCBB42C07D47349D2153B70C4E5D7FDFCBFA36EA1A85841B9E46E09A20AE4C7798AA0F119471BEE11825BE46202BB79E81A8B36F9C2F50F2A8B2E00A0
Length: 152 bytes

Output: F4A38489E32B45B6F876E3AC2168CA392362DC8F23459C1D1146FC3DBFB7BC9A
```

## Algorithm Details

### Initial Vector (IV)

```
IV0 = 0x7380166F
IV1 = 0x4914B2B9
IV2 = 0x172442D7
IV3 = 0xDA8A0600
IV4 = 0xA96F30BC
IV5 = 0x163138AA
IV6 = 0xE38DEE4D
IV7 = 0xB0FB0E4E
```

### Constants T_j

```
T_j = 0x79CC4519 for j = 0..15
T_j = 0x7A879D8A for j = 16..63
```

### Boolean Functions

```
FF_j(X, Y, Z) = X XOR Y XOR Z                    (j = 0..15)
FF_j(X, Y, Z) = (X AND Y) OR (X AND Z) OR (Y AND Z)  (j = 16..63)

GG_j(X, Y, Z) = X XOR Y XOR Z                    (j = 0..15)
GG_j(X, Y, Z) = (X AND Y) OR (NOT X AND Z)       (j = 16..63)
```

### Permutation Functions

```
P0(X) = X XOR (X <<< 9) XOR (X <<< 17)
P1(X) = X XOR (X <<< 15) XOR (X <<< 23)
```

## Compliance Requirements

SM3 is required for:
- Chinese government cryptographic applications
- Chinese banking and financial systems
- Products certified under Chinese commercial cryptography regulations

## Implementation Notes

- Uses big-endian byte order
- Similar structure to SHA-256 (Merkle-Damgård)
- Message expansion uses P1 permutation
- Compression function has unique structure with SS1/SS2 computation
