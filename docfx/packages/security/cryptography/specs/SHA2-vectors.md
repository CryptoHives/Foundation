# SHA-2 Test Vectors

## Source

NIST FIPS 180-4: Secure Hash Standard (SHS)
- https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA256.pdf
- https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA384.pdf
- https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA512.pdf

---

# SHA-256

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 256 bits (32 bytes) |
| Block Size | 512 bits (64 bytes) |
| Word Size | 32 bits |
| Rounds | 64 |

## Test Vectors

### Vector 1: Empty String

```
Message: "" (empty string, 0 bits)
Message (hex): (empty)
SHA-256: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
```

### Vector 2: "abc"

```
Message: "abc" (24 bits)
Message (hex): 616263
SHA-256: ba7816bf8f01cfea414140de5dae2223b00361a396177a9cb410ff61f20015ad
```

### Vector 3: One Block Message (448 bits)

```
Message: "abcdbcdecdefdefgefghfghighijhijkijkljklmklmnlmnomnopnopq"
Message (hex): 6162636462636465636465666465666765666768666768696768696a68696a6b
              696a6b6c6a6b6c6d6b6c6d6e6c6d6e6f6d6e6f706e6f7071
SHA-256: 248d6a61d20638b8e5c026930c3e6039a33ce45964ff2167f6ecedd419db06c1
```

### Vector 4: Two Block Message (896 bits)

```
Message: "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmn
          hijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu"
Message (hex): 61626364656667686263646566676869636465666768696a6465666768696a6b
              65666768696a6b6c666768696a6b6c6d6768696a6b6c6d6e68696a6b6c6d6e6f
              696a6b6c6d6e6f706a6b6c6d6e6f70716b6c6d6e6f7071726c6d6e6f70717273
              6d6e6f70717273746e6f707172737475
SHA-256: cf5b16a778af8380036ce59e7b0492370b249b11e8f07a51afac45037afee9d1
```

### Vector 5: Long Message (1,000,000 'a' characters)

```
Message: 1,000,000 repetitions of 'a' (8,000,000 bits)
SHA-256: cdc76e5c9914fb9281a1c7e284d73e67f1809a48a497200e046d39ccc7112cd0
```

## Intermediate Values (for "abc")

### Initial Hash Value (H(0))

```
H0 = 6a09e667
H1 = bb67ae85
H2 = 3c6ef372
H3 = a54ff53a
H4 = 510e527f
H5 = 9b05688c
H6 = 1f83d9ab
H7 = 5be0cd19
```

### Round Constants (K)

```
K[ 0..7 ] = 428a2f98 71374491 b5c0fbcf e9b5dba5 3956c25b 59f111f1 923f82a4 ab1c5ed5
K[ 8..15] = d807aa98 12835b01 243185be 550c7dc3 72be5d74 80deb1fe 9bdc06a7 c19bf174
K[16..23] = e49b69c1 efbe4786 0fc19dc6 240ca1cc 2de92c6f 4a7484aa 5cb0a9dc 76f988da
K[24..31] = 983e5152 a831c66d b00327c8 bf597fc7 c6e00bf3 d5a79147 06ca6351 14292967
K[32..39] = 27b70a85 2e1b2138 4d2c6dfc 53380d13 650a7354 766a0abb 81c2c92e 92722c85
K[40..47] = a2bfe8a1 a81a664b c24b8b70 c76c51a3 d192e819 d6990624 f40e3585 106aa070
K[48..55] = 19a4c116 1e376c08 2748774c 34b0bcb5 391c0cb3 4ed8aa4a 5b9cca4f 682e6ff3
K[56..63] = 748f82ee 78a5636f 84c87814 8cc70208 90befffa a4506ceb bef9a3f7 c67178f2
```

---

# SHA-384

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 384 bits (48 bytes) |
| Block Size | 1024 bits (128 bytes) |
| Word Size | 64 bits |
| Rounds | 80 |

## Test Vectors

### Vector 1: Empty String

```
Message: "" (empty string, 0 bits)
Message (hex): (empty)
SHA-384: 38b060a751ac96384cd9327eb1b1e36a21fdb71114be07434c0cc7bf63f6e1da
         274edebfe76f65fbd51ad2f14898b95b
```

### Vector 2: "abc"

```
Message: "abc" (24 bits)
Message (hex): 616263
SHA-384: cb00753f45a35e8bb5a03d699ac65007272c32ab0eded1631a8b605a43ff5bed
         8086072ba1e7cc2358baeca134c825a7
```

### Vector 3: Two Block Message (896 bits)

```
Message: "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmn
          hijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu"
SHA-384: 09330c33f71147e83d192fc782cd1b4753111b173b3b05d22fa08086e3b0f712
         fcc7c71a557e2db966c3e9fa91746039
```

### Vector 4: Long Message (1,000,000 'a' characters)

```
Message: 1,000,000 repetitions of 'a' (8,000,000 bits)
SHA-384: 9d0e1809716474cb086e834e310a4a1ced149e9c00f248527972cec5704c2a5b
         07b8b3dc38ecc4ebae97ddd87f3d8985
```

## Intermediate Values (for "abc")

### Initial Hash Value (H(0))

```
H0 = cbbb9d5dc1059ed8
H1 = 629a292a367cd507
H2 = 9159015a3070dd17
H3 = 152fecd8f70e5939
H4 = 67332667ffc00b31
H5 = 8eb44a8768581511
H6 = db0c2e0d64f98fa7
H7 = 47b5481dbefa4fa4
```

---

# SHA-512

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 512 bits (64 bytes) |
| Block Size | 1024 bits (128 bytes) |
| Word Size | 64 bits |
| Rounds | 80 |

## Test Vectors

### Vector 1: Empty String

```
Message: "" (empty string, 0 bits)
Message (hex): (empty)
SHA-512: cf83e1357eefb8bdf1542850d66d8007d620e4050b5715dc83f4a921d36ce9ce
         47d0d13c5d85f2b0ff8318d2877eec2f63b931bd47417a81a538327af927da3e
```

### Vector 2: "abc"

```
Message: "abc" (24 bits)
Message (hex): 616263
SHA-512: ddaf35a193617abacc417349ae20413112e6fa4e89a97ea20a9eeee64b55d39a
         2192992a274fc1a836ba3c23a3feebbd454d4423643ce80e2a9ac94fa54ca49f
```

### Vector 3: Two Block Message (896 bits)

```
Message: "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmn
          hijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu"
SHA-512: 8e959b75dae313da8cf4f72814fc143f8f7779c6eb9f7fa17299aeadb6889018
         501d289e4900f7e4331b99dec4b5433ac7d329eeb6dd26545e96e55b874be909
```

### Vector 4: Long Message (1,000,000 'a' characters)

```
Message: 1,000,000 repetitions of 'a' (8,000,000 bits)
SHA-512: e718483d0ce769644e2e42c7bc15b4638e1f98b13b2044285632a803afa973eb
         de0ff244877ea60a4cb0432ce577c31beb009c5c2c49aa2e4eadb217ad8cc09b
```

## Intermediate Values (for "abc")

### Initial Hash Value (H(0))

```
H0 = 6a09e667f3bcc908
H1 = bb67ae8584caa73b
H2 = 3c6ef372fe94f82b
H3 = a54ff53a5f1d36f1
H4 = 510e527fade682d1
H5 = 9b05688c2b3e6c1f
H6 = 1f83d9abfb41bd6b
H7 = 5be0cd19137e2179
```

### Round Constants (K) - First 16

```
K[ 0] = 428a2f98d728ae22    K[ 1] = 7137449123ef65cd
K[ 2] = b5c0fbcfec4d3b2f    K[ 3] = e9b5dba58189dbbc
K[ 4] = 3956c25bf348b538    K[ 5] = 59f111f1b605d019
K[ 6] = 923f82a4af194f9b    K[ 7] = ab1c5ed5da6d8118
K[ 8] = d807aa98a3030242    K[ 9] = 12835b0145706fbe
K[10] = 243185be4ee4b28c    K[11] = 550c7dc3d5ffb4e2
K[12] = 72be5d74f27b896f    K[13] = 80deb1fe3b1696b1
K[14] = 9bdc06a725c71235    K[15] = c19bf174cf692694
```

---

# SHA-512/224

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 224 bits (28 bytes) |
| Block Size | 1024 bits (128 bytes) |
| Word Size | 64 bits |
| Rounds | 80 |

## Test Vectors

### Vector 1: Empty String

```
Message: "" (empty string, 0 bits)
SHA-512/224: 6ed0dd02806fa89e25de060c19d3ac86cabb87d6a0ddd05c333b84f4
```

### Vector 2: "abc"

```
Message: "abc" (24 bits)
SHA-512/224: 4634270f707b6a54daae7530460842e20e37ed265ceee9a43e8924aa
```

---

# SHA-512/256

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 256 bits (32 bytes) |
| Block Size | 1024 bits (128 bytes) |
| Word Size | 64 bits |
| Rounds | 80 |

## Test Vectors

### Vector 1: Empty String

```
Message: "" (empty string, 0 bits)
SHA-512/256: c672b8d1ef56ed28ab87c3622c5114069bdd3ad7b8f9737498d0c01ecef0967a
```

### Vector 2: "abc"

```
Message: "abc" (24 bits)
SHA-512/256: 53048e2681941ef99b2e29b76b4c7dabe4c2d0c634fc6d46e0e2f13107e7af23
```
