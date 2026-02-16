# AES Cipher Test Vectors

## Source

NIST FIPS 197: Advanced Encryption Standard (AES)
- https://csrc.nist.gov/pubs/fips/197/final

NIST SP 800-38D: Recommendation for Block Cipher Modes of Operation: Galois/Counter Mode (GCM)
- https://csrc.nist.gov/pubs/sp/800-38d/final

RFC 3610: Counter with CBC-MAC (CCM)
- https://www.rfc-editor.org/rfc/rfc3610

---

# AES-ECB (FIPS 197)

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Block Size | 128 bits (16 bytes) |
| Key Sizes | 128, 192, 256 bits |
| Rounds | 10 (128-bit), 12 (192-bit), 14 (256-bit) |

## Test Vectors

### FIPS 197 Appendix B: AES-128

```
Key:        2b7e1516 28aed2a6 abf71588 09cf4f3c
Plaintext:  3243f6a8 885a308d 313198a2 e0370734
Ciphertext: 3925841d 02dc09fb dc118597 196a0b32
```

### FIPS 197 Appendix C.1: AES-128

```
Key:        00010203 04050607 08090a0b 0c0d0e0f
Plaintext:  00112233 44556677 8899aabb ccddeeff
Ciphertext: 69c4e0d8 6a7b0430 d8cdb780 70b4c55a
```

### FIPS 197 Appendix C.2: AES-192

```
Key:        00010203 04050607 08090a0b 0c0d0e0f 10111213 14151617
Plaintext:  00112233 44556677 8899aabb ccddeeff
Ciphertext: dda97ca4 864cdfe0 6eaf70a0 ec0d7191
```

### FIPS 197 Appendix C.3: AES-256

```
Key:        00010203 04050607 08090a0b 0c0d0e0f 10111213 14151617 18191a1b 1c1d1e1f
Plaintext:  00112233 44556677 8899aabb ccddeeff
Ciphertext: 8ea2b7ca 516745bf eafc4990 4b496089
```

---

# AES-GCM (NIST SP 800-38D)

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Block Size | 128 bits (16 bytes) |
| Key Sizes | 128, 192, 256 bits |
| Nonce Size | 96 bits (12 bytes) recommended |
| Tag Size | 128 bits (16 bytes) |
| Mode | Authenticated Encryption with Associated Data (AEAD) |

## Test Vectors

### Test Case 1: Empty Plaintext (AES-128-GCM)

```
Key:        00000000 00000000 00000000 00000000
Nonce:      00000000 00000000 00000000
Plaintext:  (empty)
AAD:        (empty)
Ciphertext: (empty)
Tag:        58e2fcce fa7e3061 367f1d57 a4e7455a
```

### Test Case 2: Simple Encryption (AES-128-GCM)

```
Key:        00000000 00000000 00000000 00000000
Nonce:      00000000 00000000 00000000
Plaintext:  00000000 00000000 00000000 00000000
AAD:        (empty)
Ciphertext: 0388dace 60b6a392 f328c2b9 71b2fe78
Tag:        ab6e47d4 2cec13bd f53a67b2 1257bddf
```

### Test Case 3: Multi-block Encryption (AES-128-GCM)

```
Key:        feffe992 8665731c 6d6a8f94 67308308
Nonce:      cafebabe facedbad decaf888
Plaintext:  d9313225 f88406e5 a55909c5 aff5269a
            86a7a953 1534f7da 2e4c303d 8a318a72
            1c3c0c95 95680953 2fcf0e24 49a6b525
            b16aedf5 aa0de657 ba637b39 1aafd255
AAD:        (empty)
Ciphertext: 42831ec2 21777424 4b7221b7 84d0d49c
            e3aa212f 2c02a4e0 35c17e23 29aca12e
            21d514b2 5466931c 7d8f6a5a ac84aa05
            1ba30b39 6a0aac97 3d58e091 473f5985
Tag:        4d5c2af3 27cd64a6 2cf35abd 2ba6fab4
```

### Test Case 4: With Associated Data (AES-128-GCM)

```
Key:        feffe992 8665731c 6d6a8f94 67308308
Nonce:      cafebabe facedbad decaf888
Plaintext:  d9313225 f88406e5 a55909c5 aff5269a
            86a7a953 1534f7da 2e4c303d 8a318a72
            1c3c0c95 95680953 2fcf0e24 49a6b525
            b16aedf5 aa0de657 ba637b39
AAD:        feedface deadbeef feedface deadbeef
            abaddad2
Ciphertext: 42831ec2 21777424 4b7221b7 84d0d49c
            e3aa212f 2c02a4e0 35c17e23 29aca12e
            21d514b2 5466931c 7d8f6a5a ac84aa05
            1ba30b39 6a0aac97 3d58e091
Tag:        5bc94fbc 3221a5db 94fae95a e7121a47
```

---

# AES-CCM (RFC 3610)

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Block Size | 128 bits (16 bytes) |
| Key Sizes | 128, 192, 256 bits |
| Nonce Size | 56-104 bits (7-13 bytes) |
| Tag Size | 32-128 bits (4-16 bytes) |
| Mode | Authenticated Encryption with Associated Data (AEAD) |

## Test Vectors

### RFC 3610 Packet Vector #1

```
Key:        C0C1C2C3 C4C5C6C7 C8C9CACB CCCDCECF
Nonce:      00000003 020100A0 A1A2A3A4 A5
AAD:        00010203 04050607
Plaintext:  08090A0B 0C0D0E0F 10111213 14151617 18191A1B 1C1D1E
Ciphertext: 588C979A 61C663D2 F066D0C2 C0F98980 6D5F6B61 DAC384
Tag:        17E8D12C FDF926E0
```

### RFC 3610 Packet Vector #2

```
Key:        C0C1C2C3 C4C5C6C7 C8C9CACB CCCDCECF
Nonce:      00000004 030201A0 A1A2A3A4 A5
AAD:        00010203 04050607
Plaintext:  08090A0B 0C0D0E0F 10111213 14151617 18191A1B 1C1D1E1F
Ciphertext: 72C91A36 E135F8CF 291CA894 085C87E3 CC15C439 C9E43A3B
Tag:        A091D56E 10400916
```

### RFC 3610 Packet Vector #3

```
Key:        C0C1C2C3 C4C5C6C7 C8C9CACB CCCDCECF
Nonce:      00000005 040302A0 A1A2A3A4 A5
AAD:        00010203 04050607
Plaintext:  08090A0B 0C0D0E0F 10111213 14151617 18191A1B 1C1D1E1F 20
Ciphertext: 51B1E5F4 4A197D1D A46B0F8E 2D282AE8 71E838BB 64DA8596 57
Tag:        4ADAA76F BD9FB0C5
```
