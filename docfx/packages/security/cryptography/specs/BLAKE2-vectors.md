# BLAKE2 Test Vectors

## Source

BLAKE2 Official Specification and Reference Implementation
- https://www.blake2.net/
- https://github.com/BLAKE2/BLAKE2
- RFC 7693: The BLAKE2 Cryptographic Hash and Message Authentication Code (MAC)

---

# BLAKE2b

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 1-64 bytes (default 64 bytes / 512 bits) |
| Block Size | 128 bytes (1024 bits) |
| Word Size | 64 bits |
| Rounds | 12 |
| State Size | 8 × 64 bits = 64 bytes |

## Initialization Vector (IV)

```
IV[0] = 0x6a09e667f3bcc908
IV[1] = 0xbb67ae8584caa73b
IV[2] = 0x3c6ef372fe94f82b
IV[3] = 0xa54ff53a5f1d36f1
IV[4] = 0x510e527fade682d1
IV[5] = 0x9b05688c2b3e6c1f
IV[6] = 0x1f83d9abfb41bd6b
IV[7] = 0x5be0cd19137e2179
```

## Sigma Permutations

```
SIGMA[0]  = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }
SIGMA[1]  = { 14, 10, 4, 8, 9, 15, 13, 6, 1, 12, 0, 2, 11, 7, 5, 3 }
SIGMA[2]  = { 11, 8, 12, 0, 5, 2, 15, 13, 10, 14, 3, 6, 7, 1, 9, 4 }
SIGMA[3]  = { 7, 9, 3, 1, 13, 12, 11, 14, 2, 6, 5, 10, 4, 0, 15, 8 }
SIGMA[4]  = { 9, 0, 5, 7, 2, 4, 10, 15, 14, 1, 11, 12, 6, 8, 3, 13 }
SIGMA[5]  = { 2, 12, 6, 10, 0, 11, 8, 3, 4, 13, 7, 5, 15, 14, 1, 9 }
SIGMA[6]  = { 12, 5, 1, 15, 14, 13, 4, 10, 0, 7, 6, 3, 9, 2, 8, 11 }
SIGMA[7]  = { 13, 11, 7, 14, 12, 1, 3, 9, 5, 0, 15, 4, 8, 6, 2, 10 }
SIGMA[8]  = { 6, 15, 14, 9, 11, 3, 0, 8, 12, 2, 13, 7, 1, 4, 10, 5 }
SIGMA[9]  = { 10, 2, 8, 4, 7, 6, 1, 5, 15, 11, 9, 14, 3, 12, 13, 0 }
SIGMA[10] = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }
SIGMA[11] = { 14, 10, 4, 8, 9, 15, 13, 6, 1, 12, 0, 2, 11, 7, 5, 3 }
```

## Test Vectors (64-byte output)

### Vector 1: Empty String

```
Message: "" (empty string, 0 bytes)
Key: (none)
Output Length: 64 bytes
BLAKE2b-512: 786a02f742015903c6c6fd852552d272912f4740e15847618a86e217f71f5419
             d25e1031afee585313896444934eb04b903a685b1448b755d56f701afe9be2ce
```

### Vector 2: "abc"

```
Message: "abc" (3 bytes)
Message (hex): 616263
Key: (none)
Output Length: 64 bytes
BLAKE2b-512: ba80a53f981c4d0d6a2797b69f12f6e94c212f14685ac4b74b12bb6fdbffa2d1
             7d87c5392aab792dc252d5de4533cc9518d38aa8dbf1925ab92386edd4009923
```

### Vector 3: Long Message

```
Message: "The quick brown fox jumps over the lazy dog"
Key: (none)
Output Length: 64 bytes
BLAKE2b-512: a8add4bdddfd93e4877d2746e62817b116364a1fa7bc148d95090bc7333b3673
             f82401cf7aa2e4cb1ecd90296e3f14cb5413f8ed77be73045b13914cdcd6a918
```

### Vector 4: 32-byte Output

```
Message: "abc" (3 bytes)
Key: (none)
Output Length: 32 bytes
BLAKE2b-256: bddd813c634239723171ef3fee98579b94964e3bb1cb3e427262c8c068d52319
```

### Vector 5: With Key (MAC mode)

```
Message: "abc" (3 bytes)
Key: 000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f
     202122232425262728292a2b2c2d2e2f303132333435363738393a3b3c3d3e3f
Key Length: 64 bytes
Output Length: 64 bytes
BLAKE2b-512: (keyed hash output - implementation dependent on exact key)
```

---

# BLAKE2s

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 1-32 bytes (default 32 bytes / 256 bits) |
| Block Size | 64 bytes (512 bits) |
| Word Size | 32 bits |
| Rounds | 10 |
| State Size | 8 × 32 bits = 32 bytes |

## Initialization Vector (IV)

```
IV[0] = 0x6a09e667
IV[1] = 0xbb67ae85
IV[2] = 0x3c6ef372
IV[3] = 0xa54ff53a
IV[4] = 0x510e527f
IV[5] = 0x9b05688c
IV[6] = 0x1f83d9ab
IV[7] = 0x5be0cd19
```

## Test Vectors (32-byte output)

### Vector 1: Empty String

```
Message: "" (empty string, 0 bytes)
Key: (none)
Output Length: 32 bytes
BLAKE2s-256: 69217a3079908094e11121d042354a7c1f55b6482ca1a51e1b250dfd1ed0eef9
```

### Vector 2: "abc"

```
Message: "abc" (3 bytes)
Message (hex): 616263
Key: (none)
Output Length: 32 bytes
BLAKE2s-256: 508c5e8c327c14e2e1a72ba34eeb452f37458b209ed63a294d999b4c86675982
```

### Vector 3: Long Message

```
Message: "The quick brown fox jumps over the lazy dog"
Key: (none)
Output Length: 32 bytes
BLAKE2s-256: 606beeec743ccbeff6cbcdf5d5302aa855c256c29b88c8ed331ea1a6bf3c8812
```

### Vector 4: 16-byte Output

```
Message: "abc" (3 bytes)
Key: (none)
Output Length: 16 bytes
BLAKE2s-128: aa4938119b1dc7b87cbad0ffd200d0ae
```

### Vector 5: With Key (MAC mode)

```
Message: "abc" (3 bytes)
Key: 000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f
Key Length: 32 bytes
Output Length: 32 bytes
BLAKE2s-256: (keyed hash output - implementation dependent on exact key)
```

---

# G Function (Mixing Function)

## BLAKE2b G Function

```
function G(v, a, b, c, d, x, y):
    v[a] = v[a] + v[b] + x
    v[d] = rotr64(v[d] ^ v[a], 32)
    v[c] = v[c] + v[d]
    v[b] = rotr64(v[b] ^ v[c], 24)
    v[a] = v[a] + v[b] + y
    v[d] = rotr64(v[d] ^ v[a], 16)
    v[c] = v[c] + v[d]
    v[b] = rotr64(v[b] ^ v[c], 63)
```

## BLAKE2s G Function

```
function G(v, a, b, c, d, x, y):
    v[a] = v[a] + v[b] + x
    v[d] = rotr32(v[d] ^ v[a], 16)
    v[c] = v[c] + v[d]
    v[b] = rotr32(v[b] ^ v[c], 12)
    v[a] = v[a] + v[b] + y
    v[d] = rotr32(v[d] ^ v[a], 8)
    v[c] = v[c] + v[d]
    v[b] = rotr32(v[b] ^ v[c], 7)
```

---

# Parameter Block

## BLAKE2b Parameter Block (64 bytes)

| Offset | Length | Name | Description |
|--------|--------|------|-------------|
| 0 | 1 | digest_length | 1-64 |
| 1 | 1 | key_length | 0-64 |
| 2 | 1 | fanout | 1 for sequential |
| 3 | 1 | depth | 1 for sequential |
| 4 | 4 | leaf_length | 0 for sequential |
| 8 | 8 | node_offset | 0 for sequential |
| 16 | 1 | node_depth | 0 for sequential |
| 17 | 1 | inner_length | 0 for sequential |
| 18 | 14 | reserved | All zeros |
| 32 | 16 | salt | Optional salt |
| 48 | 16 | personal | Optional personalization |

## BLAKE2s Parameter Block (32 bytes)

| Offset | Length | Name | Description |
|--------|--------|------|-------------|
| 0 | 1 | digest_length | 1-32 |
| 1 | 1 | key_length | 0-32 |
| 2 | 1 | fanout | 1 for sequential |
| 3 | 1 | depth | 1 for sequential |
| 4 | 4 | leaf_length | 0 for sequential |
| 8 | 6 | node_offset | 0 for sequential |
| 14 | 1 | node_depth | 0 for sequential |
| 15 | 1 | inner_length | 0 for sequential |
| 16 | 8 | salt | Optional salt |
| 24 | 8 | personal | Optional personalization |
