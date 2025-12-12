# NIST FIPS 180-4 - Secure Hash Standard (SHS)

## Overview

Federal Information Processing Standards Publication 180-4 specifies the Secure Hash Algorithms:

- **SHA-1** - 160-bit hash (legacy, deprecated for security use)
- **SHA-224** - 224-bit hash (truncated SHA-256)
- **SHA-256** - 256-bit hash
- **SHA-384** - 384-bit hash (truncated SHA-512)
- **SHA-512** - 512-bit hash
- **SHA-512/224** - 224-bit hash (truncated SHA-512)
- **SHA-512/256** - 256-bit hash (truncated SHA-512)

## Official Reference

- **Document:** NIST FIPS 180-4
- **Title:** Secure Hash Standard (SHS)
- **URL:** https://csrc.nist.gov/pubs/fips/180-4/upd1/final
- **PDF:** https://nvlpubs.nist.gov/nistpubs/FIPS/NIST.FIPS.180-4.pdf

## Implementation Status

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| SHA-1 | 160 bits | ✅ Implemented (deprecated) | `SHA1Managed` |
| SHA-224 | 224 bits | ✅ Implemented | `SHA224Managed` |
| SHA-256 | 256 bits | ✅ Implemented | `SHA256Managed` |
| SHA-384 | 384 bits | ✅ Implemented | `SHA384Managed` |
| SHA-512 | 512 bits | ✅ Implemented | `SHA512Managed` |
| SHA-512/224 | 224 bits | ✅ Implemented | `SHA512_224Managed` |
| SHA-512/256 | 256 bits | ✅ Implemented | `SHA512_256Managed` |

> **Warning:** SHA-1 is cryptographically weakened and should NOT be used for digital signatures
> or other security-critical applications. It is provided only for legacy compatibility.

---

## SHA-256 Family (32-bit operations)

### Parameters

| Algorithm | Message Block | Word Size | Hash Value | Security |
|-----------|---------------|-----------|------------|----------|
| SHA-224 | 512 bits | 32 bits | 224 bits | 112 bits |
| SHA-256 | 512 bits | 32 bits | 256 bits | 128 bits |

### Initial Hash Values

**SHA-256:**
```
H0 = 6a09e667  H1 = bb67ae85  H2 = 3c6ef372  H3 = a54ff53a
H4 = 510e527f  H5 = 9b05688c  H6 = 1f83d9ab  H7 = 5be0cd19
```

**SHA-224:** (first 32 bits of fractional parts of square roots of 9th through 16th primes)
```
H0 = c1059ed8  H1 = 367cd507  H2 = 3070dd17  H3 = f70e5939
H4 = ffc00b31  H5 = 68581511  H6 = 64f98fa7  H7 = befa4fa4
```

### Round Constants (K)

64 constants derived from the first 64 primes:
```
428a2f98 71374491 b5c0fbcf e9b5dba5 3956c25b 59f111f1 923f82a4 ab1c5ed5
d807aa98 12835b01 243185be 550c7dc3 72be5d74 80deb1fe 9bdc06a7 c19bf174
e49b69c1 efbe4786 0fc19dc6 240ca1cc 2de92c6f 4a7484aa 5cb0a9dc 76f988da
983e5152 a831c66d b00327c8 bf597fc7 c6e00bf3 d5a79147 06ca6351 14292967
27b70a85 2e1b2138 4d2c6dfc 53380d13 650a7354 766a0abb 81c2c92e 92722c85
a2bfe8a1 a81a664b c24b8b70 c76c51a3 d192e819 d6990624 f40e3585 106aa070
19a4c116 1e376c08 2748774c 34b0bcb5 391c0cb3 4ed8aa4a 5b9cca4f 682e6ff3
748f82ee 78a5636f 84c87814 8cc70208 90befffa a4506ceb bef9a3f7 c67178f2
```

### Algorithm

```
For each 512-bit message block:
  1. Prepare message schedule W[0..63]
  2. Initialize working variables a,b,c,d,e,f,g,h from current hash
  3. For t = 0 to 63:
       T1 = h + Σ1(e) + Ch(e,f,g) + K[t] + W[t]
       T2 = Σ0(a) + Maj(a,b,c)
       h=g, g=f, f=e, e=d+T1, d=c, c=b, b=a, a=T1+T2
  4. Add working variables to hash value
```

---

## SHA-512 Family (64-bit operations)

### Parameters

| Algorithm | Message Block | Word Size | Hash Value | Security |
|-----------|---------------|-----------|------------|----------|
| SHA-384 | 1024 bits | 64 bits | 384 bits | 192 bits |
| SHA-512 | 1024 bits | 64 bits | 512 bits | 256 bits |
| SHA-512/224 | 1024 bits | 64 bits | 224 bits | 112 bits |
| SHA-512/256 | 1024 bits | 64 bits | 256 bits | 128 bits |

### Initial Hash Values

**SHA-512:**
```
H0 = 6a09e667f3bcc908  H1 = bb67ae8584caa73b
H2 = 3c6ef372fe94f82b  H3 = a54ff53a5f1d36f1
H4 = 510e527fade682d1  H5 = 9b05688c2b3e6c1f
H6 = 1f83d9abfb41bd6b  H7 = 5be0cd19137e2179
```

**SHA-384:**
```
H0 = cbbb9d5dc1059ed8  H1 = 629a292a367cd507
H2 = 9159015a3070dd17  H3 = 152fecd8f70e5939
H4 = 67332667ffc00b31  H5 = 8eb44a8768581511
H6 = db0c2e0d64f98fa7  H7 = 47b5481dbefa4fa4
```

**SHA-512/224:** (SHA-512 IVs XORed with 0xa5a5a5a5a5a5a5a5)
```
H0 = 8c3d37c819544da2  H1 = 73e1996689dcd4d6
H2 = 1dfab7ae32ff9c82  H3 = 679dd514582f9fcf
H4 = 0f6d2b697bd44da8  H5 = 77e36f7304c48942
H6 = 3f9d85a86a1d36c8  H7 = 1112e6ad91d692a1
```

**SHA-512/256:** (SHA-512 IVs XORed with 0xa5a5a5a5a5a5a5a5)
```
H0 = 22312194fc2bf72c  H1 = 9f555fa3c84c64c2
H2 = 2393b86b6f53b151  H3 = 963877195940eabd
H4 = 96283ee2a88effe3  H5 = be5e1e2553863992
H6 = 2b0199fc2c85b8aa  H7 = 0eb72ddc81c52ca2
```

### Round Constants (K)

80 constants derived from the first 80 primes (64-bit values).

---

## SHA-1 (Legacy)

### Parameters

| Algorithm | Message Block | Word Size | Hash Value | Security |
|-----------|---------------|-----------|------------|----------|
| SHA-1 | 512 bits | 32 bits | 160 bits | < 80 bits* |

*SHA-1 collision resistance is broken (practical attacks exist).

### Initial Hash Values

```
H0 = 67452301  H1 = efcdab89  H2 = 98badcfe  H3 = 10325476  H4 = c3d2e1f0
```

---

## Padding

All SHA algorithms use the same padding scheme:

1. Append bit '1' to message
2. Append '0' bits until message length ≡ (block_size - 64 or 128) mod block_size
3. Append original message length as 64-bit (SHA-1/256) or 128-bit (SHA-512) big-endian integer

---

## Test Vectors

### SHA-256

**Empty String:**
- Input: "" (0 bytes)
- Output: `e3b0c442 98fc1c14 9afbf4c8 996fb924 27ae41e4 649b934c a495991b 7852b855`

**"abc":**
- Input: "abc" (3 bytes)
- Output: `ba7816bf 8f01cfea 414140de 5dae2223 b00361a3 96177a9c b410ff61 f20015ad`

**Two-Block Message:**
- Input: "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq" (56 bytes)
- Output: `248d6a61 d20638b8 e5c02693 0c3e6039 a33ce459 64ff2167 f6ecedd4 19db06c1`

### SHA-512

**Empty String:**
- Input: "" (0 bytes)
- Output: `cf83e135 7eefb8bd f1542850 d66d8007 d620e405 0b5715dc 83f4a921 d36ce9ce 47d0d13c 5d85f2b0 ff8318d2 877eec2f 63b931bd 47417a81 a538327a f927da3e`

**"abc":**
- Input: "abc" (3 bytes)
- Output: `ddaf35a1 93617aba cc417349 ae204131 12e6fa4e 89a97ea2 0a9eeee6 4b55d39a 2192992a 274fc1a8 36ba3c23 a3feebbd 454d4423 643ce80e 2a9ac94f a54ca49f`

### SHA-224

**"abc":**
- Input: "abc" (3 bytes)
- Output: `23097d22 3405d822 8642a477 bda255b3 2aadbce4 bda0b3f7 e36c9da7`

### SHA-384

**"abc":**
- Input: "abc" (3 bytes)
- Output: `cb00753f 45a35e8b b5a03d69 9ac65007 272c32ab 0eded163 1a8b605a 43ff5bed 8086072b a1e7cc23 58baeca1 34c825a7`

### SHA-512/256

**"abc":**
- Input: "abc" (3 bytes)
- Output: `53048e26 81941ef9 9b2e29b7 6b4c7dab e4c2d0c6 34fc6d46 e0e2f131 07e7af23`

### SHA-512/224

**"abc":**
- Input: "abc" (3 bytes)
- Output: `4634270f 707b6a54 daae7530 460842e2 0e37ed26 5ceee9a4 3e8924aa`

---

## Security Considerations

| Algorithm | Collision Resistance | Preimage Resistance | Recommended Use |
|-----------|---------------------|---------------------|-----------------|
| SHA-1 | ❌ Broken | ⚠️ Weakened | Legacy only |
| SHA-224 | ✅ 112 bits | ✅ 224 bits | General use |
| SHA-256 | ✅ 128 bits | ✅ 256 bits | **Recommended** |
| SHA-384 | ✅ 192 bits | ✅ 384 bits | High security |
| SHA-512 | ✅ 256 bits | ✅ 512 bits | High security |
| SHA-512/224 | ✅ 112 bits | ✅ 224 bits | 64-bit optimized |
| SHA-512/256 | ✅ 128 bits | ✅ 256 bits | 64-bit optimized |

---

## References

1. NIST FIPS 180-4: https://doi.org/10.6028/NIST.FIPS.180-4
2. SHA-1 Examples: https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA1.pdf
3. SHA-256 Examples: https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA256.pdf
4. SHA-512 Examples: https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA512.pdf
