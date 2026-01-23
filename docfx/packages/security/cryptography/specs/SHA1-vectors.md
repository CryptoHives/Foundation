# SHA-1 Test Vectors

> **WARNING**: SHA-1 is cryptographically broken and should NOT be used for security-sensitive applications.
> These test vectors are provided only for legacy compatibility and verification of existing data.

## Source

NIST FIPS 180-4: Secure Hash Standard (SHS)
- https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA1.pdf

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 160 bits (20 bytes) |
| Block Size | 512 bits (64 bytes) |
| Word Size | 32 bits |
| Rounds | 80 |

## Test Vectors

### Vector 1: Empty String

```
Message: "" (empty string, 0 bits)
Message (hex): (empty)
SHA-1: da39a3ee5e6b4b0d3255bfef95601890afd80709
```

### Vector 2: "abc"

```
Message: "abc" (24 bits)
Message (hex): 616263
SHA-1: a9993e364706816aba3e25717850c26c9cd0d89d
```

### Vector 3: One Block Message

```
Message: "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq" (448 bits)
Message (hex): 6162636462636465636465666465666765666768666768696768696a68696a6b
              696a6b6c6a6b6c6d6b6c6d6e6c6d6e6f6d6e6f706e6f7071
SHA-1: 84983e441c3bd26ebaae4aa1f95129e5e54670f1
```

### Vector 4: Two Block Message

```
Message: "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmn
          hijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu" (896 bits)
Message (hex): 61626364656667686263646566676869636465666768696a6465666768696a6b
              65666768696a6b6c666768696a6b6c6d6768696a6b6c6d6e68696a6b6c6d6e6f
              696a6b6c6d6e6f706a6b6c6d6e6f70716b6c6d6e6f7071726c6d6e6f70717273
              6d6e6f70717273746e6f707172737475
SHA-1: a49b2446a02c645bf419f995b67091253a04a259
```

### Vector 5: Long Message (1,000,000 'a' characters)

```
Message: 1,000,000 repetitions of 'a' (8,000,000 bits)
SHA-1: 34aa973cd4c4daa4f61eeb2bdbad27316534016f
```

### Vector 6: The Quick Brown Fox

```
Message: "The quick brown fox jumps over the lazy dog" (344 bits)
Message (hex): 54686520717569636b2062726f776e20666f78206a756d7073206f76657220746865206c617a7920646f67
SHA-1: 2fd4e1c67a2d28fced849ee1bb76e7391b93eb12
```

### Vector 7: The Quick Brown Fox (with period)

```
Message: "The quick brown fox jumps over the lazy cog" (344 bits)
Message (hex): 54686520717569636b2062726f776e20666f78206a756d7073206f76657220746865206c617a7920636f67
SHA-1: de9f2c7fd25e1b3afad3e85a0bd17d9b100db4b3
```

## Intermediate Values (for "abc")

### Initial Hash Value (H(0))

```
H0 = 67452301
H1 = efcdab89
H2 = 98badcfe
H3 = 10325476
H4 = c3d2e1f0
```

### Message Block (after padding)

```
Block 0:
W[ 0] = 61626380
W[ 1] = 00000000
W[ 2] = 00000000
W[ 3] = 00000000
W[ 4] = 00000000
W[ 5] = 00000000
W[ 6] = 00000000
W[ 7] = 00000000
W[ 8] = 00000000
W[ 9] = 00000000
W[10] = 00000000
W[11] = 00000000
W[12] = 00000000
W[13] = 00000000
W[14] = 00000000
W[15] = 00000018
```

### Final Hash Value

```
H0 = a9993e36
H1 = 4706816a
H2 = ba3e2571
H3 = 7850c26c
H4 = 9cd0d89d

Digest = a9993e364706816aba3e25717850c26c9cd0d89d
```
