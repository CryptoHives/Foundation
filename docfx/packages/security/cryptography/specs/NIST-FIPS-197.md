# NIST FIPS 197 - Advanced Encryption Standard (AES)

## Overview

Federal Information Processing Standards Publication 197 specifies the Advanced Encryption Standard (AES), a symmetric block cipher:

- **AES-128** - 128-bit key, 10 rounds
- **AES-192** - 192-bit key, 12 rounds
- **AES-256** - 256-bit key, 14 rounds

All variants operate on a fixed block size of 128 bits (16 bytes).

## Official Reference

- **Document:** NIST FIPS 197
- **Title:** Advanced Encryption Standard (AES)
- **URL:** https://csrc.nist.gov/pubs/fips/197/final
- **PDF:** https://nvlpubs.nist.gov/nistpubs/FIPS/NIST.FIPS.197.pdf

## Implementation Status

| Algorithm | Key Size | Rounds | Status | Class |
|-----------|----------|--------|--------|-------|
| AES-128 ECB | 128 bits | 10 | ✅ Implemented | `Aes128` |
| AES-192 ECB | 192 bits | 12 | ✅ Implemented | `Aes192` |
| AES-256 ECB | 256 bits | 14 | ✅ Implemented | `Aes256` |
| AES-128 CBC | 128 bits | 10 | ✅ Implemented | `Aes128` |
| AES-192 CBC | 192 bits | 12 | ✅ Implemented | `Aes192` |
| AES-256 CBC | 256 bits | 14 | ✅ Implemented | `Aes256` |
| AES-128 CTR | 128 bits | 10 | ✅ Implemented | `Aes128` |
| AES-192 CTR | 192 bits | 12 | ✅ Implemented | `Aes192` |
| AES-256 CTR | 256 bits | 14 | ✅ Implemented | `Aes256` |
| AES-128-GCM | 128 bits | 10 | ✅ Implemented | `AesGcm128` |
| AES-192-GCM | 192 bits | 12 | ✅ Implemented | `AesGcm192` |
| AES-256-GCM | 256 bits | 14 | ✅ Implemented | `AesGcm256` |
| AES-128-CCM | 128 bits | 10 | ✅ Implemented | `AesCcm128` |
| AES-256-CCM | 256 bits | 14 | ✅ Implemented | `AesCcm256` |

---

## Block Cipher Parameters

| Parameter | AES-128 | AES-192 | AES-256 |
|-----------|---------|---------|---------|
| Key Length (Nk words) | 4 | 6 | 8 |
| Block Size (Nb words) | 4 | 4 | 4 |
| Number of Rounds (Nr) | 10 | 12 | 14 |
| Key Schedule Words | 44 | 52 | 60 |

---

## Modes of Operation

### ECB (Electronic Codebook) - FIPS 197

Each block is encrypted independently. No IV required. Suitable only for single-block encryption.

### CBC (Cipher Block Chaining) - SP 800-38A

Each plaintext block is XORed with the previous ciphertext block before encryption.

| Parameter | Value |
|-----------|-------|
| IV Size | 128 bits (16 bytes) |
| Padding | Required (PKCS7) |

### CTR (Counter) - SP 800-38A

Turns a block cipher into a stream cipher using an incrementing counter.

| Parameter | Value |
|-----------|-------|
| IV/Nonce Size | 128 bits (16 bytes) |
| Padding | Not required |

### GCM (Galois/Counter Mode) - SP 800-38D

Authenticated encryption with associated data (AEAD).

| Parameter | Value |
|-----------|-------|
| Nonce Size | 96 bits (12 bytes) recommended |
| Tag Size | 128 bits (16 bytes) |
| AEAD | Yes |

### CCM (Counter with CBC-MAC) - SP 800-38C / RFC 3610

Authenticated encryption with associated data (AEAD).

| Parameter | Value |
|-----------|-------|
| Nonce Size | 56-104 bits (7-13 bytes) |
| Tag Size | 32-128 bits (4-16 bytes) |
| AEAD | Yes |

---

## Test Vectors

### AES-128 (FIPS 197 Appendix B)

```
Key:        2b7e1516 28aed2a6 abf71588 09cf4f3c
Plaintext:  3243f6a8 885a308d 313198a2 e0370734
Ciphertext: 3925841d 02dc09fb dc118597 196a0b32
```

### AES-128 (FIPS 197 Appendix C.1)

```
Key:        00010203 04050607 08090a0b 0c0d0e0f
Plaintext:  00112233 44556677 8899aabb ccddeeff
Ciphertext: 69c4e0d8 6a7b0430 d8cdb780 70b4c55a
```

### AES-192 (FIPS 197 Appendix C.2)

```
Key:        00010203 04050607 08090a0b 0c0d0e0f 10111213 14151617
Plaintext:  00112233 44556677 8899aabb ccddeeff
Ciphertext: dda97ca4 864cdfe0 6eaf70a0 ec0d7191
```

### AES-256 (FIPS 197 Appendix C.3)

```
Key:        00010203 04050607 08090a0b 0c0d0e0f 10111213 14151617 18191a1b 1c1d1e1f
Plaintext:  00112233 44556677 8899aabb ccddeeff
Ciphertext: 8ea2b7ca 516745bf eafc4990 4b496089
```

---

## Related Specifications

| Specification | Title | Modes |
|---------------|-------|-------|
| [SP 800-38A](https://csrc.nist.gov/pubs/sp/800-38a/final) | Recommendation for Block Cipher Modes of Operation | ECB, CBC, CFB, OFB, CTR |
| [SP 800-38C](https://csrc.nist.gov/pubs/sp/800-38c/upd1/final) | Recommendation for Block Cipher Modes of Operation: CCM | CCM |
| [SP 800-38D](https://csrc.nist.gov/pubs/sp/800-38d/final) | Recommendation for Block Cipher Modes of Operation: GCM | GCM |
| [RFC 3610](https://www.rfc-editor.org/rfc/rfc3610) | Counter with CBC-MAC (CCM) | CCM |

---

## Security Considerations

| Algorithm | Key Size | Security Level | Recommended Use |
|-----------|----------|----------------|-----------------|
| AES-128 | 128 bits | 128 bits | General use |
| AES-192 | 192 bits | 192 bits | High security |
| AES-256 | 256 bits | 256 bits | **Recommended** |

> **Note:** ECB mode should not be used for encrypting more than one block of data, as identical
> plaintext blocks produce identical ciphertext blocks. Use CBC, CTR, GCM, or CCM for multi-block encryption.

---

## References

1. NIST FIPS 197: https://doi.org/10.6028/NIST.FIPS.197-upd1
2. NIST SP 800-38A: https://csrc.nist.gov/pubs/sp/800-38a/final
3. NIST SP 800-38C: https://csrc.nist.gov/pubs/sp/800-38c/upd1/final
4. NIST SP 800-38D: https://csrc.nist.gov/pubs/sp/800-38d/final
5. RFC 3610: https://www.rfc-editor.org/rfc/rfc3610
