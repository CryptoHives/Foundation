# SHA-3 Test Vectors

## Source

NIST FIPS 202: SHA-3 Standard: Permutation-Based Hash and Extendable-Output Functions
- https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-256_Msg0.pdf
- https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-512_Msg0.pdf

---

# SHA3-256

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 256 bits (32 bytes) |
| Rate | 1088 bits (136 bytes) |
| Capacity | 512 bits (64 bytes) |
| Rounds (Keccak-f) | 24 |
| Domain Separator | 0x06 |

## Test Vectors

### Vector 1: Empty String (0 bits)

```
Message: "" (empty string, 0 bits)
Message (hex): (empty)
SHA3-256: a7ffc6f8bf1ed76651c14756a061d662f580ff4de43b49fa82d80a4b80f8434a
```

### Vector 2: "abc" (24 bits)

```
Message: "abc"
Message (hex): 616263
SHA3-256: 3a985da74fe225b2045c172d6bd390bd855f086e3e9d525b46bfe24511431532
```

### Vector 3: 5-bit Message

```
Message (bits): 11001
Message (hex): 13 (with bit padding)
SHA3-256: 7b0047cf5a456882363cbf0fb05322cf65f4b7059a46365e830132e3b5d957af
```

### Vector 4: 30-bit Message

```
Message (bits): 110010100001101011011110100110
Message (hex): 53 58 7b c8 (with bit padding)
SHA3-256: c8242fef409e5ae9d1f1c857ae4dc624b92b19809f62aa8c07411c54a078b1d0
```

### Vector 5: 1600-bit Message (200 bytes)

```
Message: 200 bytes of 0xa3
SHA3-256: 79f38adec5c20307a98ef76e8324afbfd46cfd81b22e3973c65fa1bd9de31787
```

### Vector 6: Two Block Message

```
Message: "abcdefghbcdefghicdefghijdefghijkefghijklfghijklmghijklmn
          hijklmnoijklmnopjklmnopqklmnopqrlmnopqrsmnopqrstnopqrstu"
SHA3-256: 916f6061fe879741ca6469b43971dfdb28b1a32dc36cb3254e812be27aad1d18
```

### Vector 7: Long Message (1,000,000 'a' characters)

```
Message: 1,000,000 repetitions of 'a'
SHA3-256: 5c8875ae474a3634ba4fd55ec85bffd661f32aca75c6d699d0cdcb6c115891c1
```

---

# SHA3-512

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 512 bits (64 bytes) |
| Rate | 576 bits (72 bytes) |
| Capacity | 1024 bits (128 bytes) |
| Rounds (Keccak-f) | 24 |
| Domain Separator | 0x06 |

## Test Vectors

### Vector 1: Empty String (0 bits)

```
Message: "" (empty string, 0 bits)
Message (hex): (empty)
SHA3-512: a69f73cca23a9ac5c8b567dc185a756e97c982164fe25859e0d1dcc1475c80a6
          15b2123af1f5f94c11e3e9402c3ac558f500199d95b6d3e301758586281dcd26
```

### Vector 2: "abc" (24 bits)

```
Message: "abc"
Message (hex): 616263
SHA3-512: b751850b1a57168a5693cd924b6b096e08f621827444f70d884f5d0240d2712e
          10e116e9192af3c91a7ec57647e3934057340b4cf408d5a56592f8274eec53f0
```

### Vector 3: 5-bit Message

```
Message (bits): 11001
SHA3-512: a13e01494114c09800622a70288c432121ce70039d753cadd2e006e4d961cb27
          544c1e4e7e3fec2a8c54a74dbd01d9f78f16c02815f52a1e4d8e7a07e4c44a7b
```

### Vector 4: 30-bit Message

```
Message (bits): 110010100001101011011110100110
SHA3-512: 9834c05a11e1c5d3da9c740e1c106d9e590a0e530b6f6aaa7830525d075ca5db
          1bd8a6aa981a28613ac334934a01823cd45f45e49b6d7e6917f2f16778067bab
```

### Vector 5: 1600-bit Message (200 bytes)

```
Message: 200 bytes of 0xa3
SHA3-512: e76dfad22084a8b1467fcf2ffa58361bec7628edf5f3fdc0e4805dc48caeeca8
          1b7c13c30adf52a3659584739a2df46be589c51ca1a4a8416df6545a1ce8ba00
```

### Vector 6: Long Message (1,000,000 'a' characters)

```
Message: 1,000,000 repetitions of 'a'
SHA3-512: 3c3a876da14034ab60627c077bb98f7e120a2a5370212dffb3385a18d4f38859
          ed311d0a9d5141ce9cc5c66ee689b266a8aa18ace8282a0e0db596c90b0a7b87
```

---

# SHA3-224

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 224 bits (28 bytes) |
| Rate | 1152 bits (144 bytes) |
| Capacity | 448 bits (56 bytes) |

## Test Vectors

### Vector 1: Empty String

```
Message: "" (empty string, 0 bits)
SHA3-224: 6b4e03423667dbb73b6e15454f0eb1abd4597f9a1b078e3f5b5a6bc7
```

### Vector 2: "abc"

```
Message: "abc"
SHA3-224: e642824c3f8cf24ad09234ee7d3c766fc9a3a5168d0c94ad73b46fdf
```

---

# SHA3-384

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Hash Size | 384 bits (48 bytes) |
| Rate | 832 bits (104 bytes) |
| Capacity | 768 bits (96 bytes) |

## Test Vectors

### Vector 1: Empty String

```
Message: "" (empty string, 0 bits)
SHA3-384: 0c63a75b845e4f7d01107d852e4c2485c51a50aaaa94fc61995e71bbee983a2a
          c3713831264adb47fb6bd1e058d5f004
```

### Vector 2: "abc"

```
Message: "abc"
SHA3-384: ec01498288516fc926459f58e2c6ad8df9b473cb0fc08c2596da7cf0e49be4b2
          98d88cea927ac7f539f1edf228376d25
```

---

# Keccak Permutation Constants

## Round Constants (RC)

```
RC[ 0] = 0x0000000000000001    RC[ 1] = 0x0000000000008082
RC[ 2] = 0x800000000000808a    RC[ 3] = 0x8000000080008000
RC[ 4] = 0x000000000000808b    RC[ 5] = 0x0000000080000001
RC[ 6] = 0x8000000080008081    RC[ 7] = 0x8000000000008009
RC[ 8] = 0x000000000000008a    RC[ 9] = 0x0000000000000088
RC[10] = 0x0000000080008009    RC[11] = 0x000000008000000a
RC[12] = 0x000000008000808b    RC[13] = 0x800000000000008b
RC[14] = 0x8000000000008089    RC[15] = 0x8000000000008003
RC[16] = 0x8000000000008002    RC[17] = 0x8000000000000080
RC[18] = 0x000000000000800a    RC[19] = 0x800000008000000a
RC[20] = 0x8000000080008081    RC[21] = 0x8000000000008080
RC[22] = 0x0000000080000001    RC[23] = 0x8000000080008008
```

## Rotation Offsets

```
r[0][0] =  0    r[0][1] = 36    r[0][2] =  3    r[0][3] = 41    r[0][4] = 18
r[1][0] =  1    r[1][1] = 44    r[1][2] = 10    r[1][3] = 45    r[1][4] =  2
r[2][0] = 62    r[2][1] =  6    r[2][2] = 43    r[2][3] = 15    r[2][4] = 61
r[3][0] = 28    r[3][1] = 55    r[3][2] = 25    r[3][3] = 21    r[3][4] = 56
r[4][0] = 27    r[4][1] = 20    r[4][2] = 39    r[4][3] =  8    r[4][4] = 14
```
