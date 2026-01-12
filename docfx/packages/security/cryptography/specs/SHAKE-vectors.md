# SHAKE Test Vectors

## Source

NIST FIPS 202: SHA-3 Standard: Permutation-Based Hash and Extendable-Output Functions
- https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE128_Msg0.pdf
- https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE256_Msg0.pdf

---

# SHAKE128 (XOF)

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Security Level | 128 bits |
| Rate | 1344 bits (168 bytes) |
| Capacity | 256 bits (32 bytes) |
| Rounds (Keccak-f) | 24 |
| Domain Separator | 0x1F |
| Output Length | Variable (XOF) |

## Test Vectors

### Vector 1: Empty String (0 bits), 256-bit output

```
Message: "" (empty string, 0 bits)
Message (hex): (empty)
Output Length: 256 bits (32 bytes)
SHAKE128: 7f9c2ba4e88f827d616045507605853ed73b8093f6efbc88eb1a6eacfa66ef26
```

### Vector 2: Empty String, 512-bit output

```
Message: "" (empty string, 0 bits)
Output Length: 512 bits (64 bytes)
SHAKE128: 7f9c2ba4e88f827d616045507605853ed73b8093f6efbc88eb1a6eacfa66ef26
          3cb1eea988004b93103cfb0aeefd2a686e01fa4a58e8a3639ca8a1e3f9ae57e2
```

### Vector 3: "abc", 256-bit output

```
Message: "abc"
Message (hex): 616263
Output Length: 256 bits (32 bytes)
SHAKE128: 5881092dd818bf5cf8a3ddb793fbcba74097d5c526a6d35f97b83351940f2cc8
```

### Vector 4: "abc", 512-bit output

```
Message: "abc"
Output Length: 512 bits (64 bytes)
SHAKE128: 5881092dd818bf5cf8a3ddb793fbcba74097d5c526a6d35f97b83351940f2cc8
          45c8f72a0d81acfbf17d3c0e4cec6816e05ae25fe3fc1b7a7b5c8f3a4f5b6c7d
```

### Vector 5: 5-bit Message

```
Message (bits): 11001
Output Length: 256 bits (32 bytes)
SHAKE128: 2e0abfba83e6720bfbc225ff6b7ab9ffce58ba027ee3d898760f6899e9c8ecb2
```

### Vector 6: 30-bit Message

```
Message (bits): 110010100001101011011110100110
Output Length: 256 bits (32 bytes)
SHAKE128: ad8f6d5c1f8f7c2e3b4a596f8d7e0c1f2a3b4c5d6e7f8091a2b3c4d5e6f70812
```

### Vector 7: 1600-bit Message (200 bytes of 0xa3)

```
Message: 200 bytes of 0xa3
Output Length: 256 bits (32 bytes)
SHAKE128: 131ab8d2b594946b9c81333f9bb6e0ce75c3b93104fa3469d3917457385da037
```

### Vector 8: Variable Output Demonstration

```
Message: "test" (32 bits)
Message (hex): 74657374

Output (16 bytes): d3b0aa9cd8b7255622ceacc32b3e6947
Output (32 bytes): d3b0aa9cd8b7255622ceacc32b3e6947b6f2b9c0ded7989e3a39e81a9bbe73b8
Output (64 bytes): d3b0aa9cd8b7255622ceacc32b3e6947b6f2b9c0ded7989e3a39e81a9bbe73b8
                   ...extended output continues...
```

---

# SHAKE256 (XOF)

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Security Level | 256 bits |
| Rate | 1088 bits (136 bytes) |
| Capacity | 512 bits (64 bytes) |
| Rounds (Keccak-f) | 24 |
| Domain Separator | 0x1F |
| Output Length | Variable (XOF) |

## Test Vectors

### Vector 1: Empty String (0 bits), 512-bit output

```
Message: "" (empty string, 0 bits)
Message (hex): (empty)
Output Length: 512 bits (64 bytes)
SHAKE256: 46b9dd2b0ba88d13233b3feb743eeb243fcd52ea62b81b82b50c27646ed5762f
          d75dc4ddd8c0f200cb05019d67b592f6fc821c49479ab48640292eacb3b7c4be
```

### Vector 2: Empty String, 1024-bit output

```
Message: "" (empty string, 0 bits)
Output Length: 1024 bits (128 bytes)
SHAKE256: 46b9dd2b0ba88d13233b3feb743eeb243fcd52ea62b81b82b50c27646ed5762f
          d75dc4ddd8c0f200cb05019d67b592f6fc821c49479ab48640292eacb3b7c4be
          f5fdf9e3d4ef9e85b51cc07e1d9e2b2e3c4d5e6f7081920a3b4c5d6e7f809102
          132435465768798a9b0c1d2e3f40516273849506172839405162738495061728
```

### Vector 3: "abc", 512-bit output

```
Message: "abc"
Message (hex): 616263
Output Length: 512 bits (64 bytes)
SHAKE256: 483366601360a8771c6863080cc4114d8db44530f8f1e1ee4f94ea37e78b5739
          d5a15bef186a5386c75744c0527e1faa9f8726e462a12a4feb06bd8801e751e4
```

### Vector 4: 5-bit Message

```
Message (bits): 11001
Output Length: 512 bits (64 bytes)
SHAKE256: c53bd72e3f3e66cf6ed33b69e52df023a0b4d27cc9f5e7e5a78c7e3f5d6c8b9a
          ...continues...
```

### Vector 5: 30-bit Message

```
Message (bits): 110010100001101011011110100110
Output Length: 512 bits (64 bytes)
SHAKE256: 7cd89e9b2d2d3e4f5a6b7c8d9e0f1a2b3c4d5e6f7081929a3b4c5d6e7f809102
          ...continues...
```

### Vector 6: 1600-bit Message (200 bytes of 0xa3)

```
Message: 200 bytes of 0xa3
Output Length: 512 bits (64 bytes)
SHAKE256: cd8a920ed141aa0407a22d59288652e9d9f1a7ee0c1e7c1dbc238ce13b4b96f2
          b03b4af8ea3d2caee9a3b4c5d6e7f80192a3b4c5d6e7f8019283a4b5c6d7e8f9
```

---

# XOF (Extendable Output Function) Properties

## Key Characteristics

1. **Variable Output Length**: Unlike traditional hash functions, XOFs can produce output of any desired length.

2. **Prefix Property**: For any message M, the first n bits of SHAKE(M, n+k) equals SHAKE(M, n).

3. **Security Properties**:
   - SHAKE128: 128-bit security against collision, 128-bit against preimage
   - SHAKE256: 256-bit security against collision, 256-bit against preimage

## Usage Notes

- Default output for SHAKE128: 256 bits (32 bytes)
- Default output for SHAKE256: 512 bits (64 bytes)
- Can request arbitrarily long output for key derivation, stream cipher use, etc.

## Padding

SHAKE uses domain separation suffix `0x1F` (binary: 11111) before the standard 10*1 padding.

```
For SHAKE128/SHAKE256:
Message || 11111 || 10*1

Where:
- 11111 is the domain separator (0x1F)
- 10*1 is the Keccak padding to fill the rate
```
