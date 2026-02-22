# AES-CMAC Test Vectors

Test vectors for AES-CMAC from NIST SP 800-38B and RFC 4493.

## Source

- **NIST SP 800-38B:** Recommendation for Block Cipher Modes of Operation: The CMAC Mode for Authentication
- **URL:** https://csrc.nist.gov/pubs/sp/800-38b/upd1/final
- **RFC 4493:** The AES-CMAC Algorithm
- **URL:** https://www.rfc-editor.org/rfc/rfc4493

---

## AES-128-CMAC

**Key:** `2b7e1516 28aed2a6 abf71588 09cf4f3c`

### Subkeys

```
L  = 7df76b0c 1ab899b3 3e42f047 b91b546f
K1 = fbeed618 357133667c85e08f 7236a8de
K2 = f7ddac30 6ae266cc f90bc11e e46d513b
```

### Example 1 — Empty Message

```
Data:    (empty)
CMAC:    bb1d6929 e9593728 7fa37d12 9b756746
```

### Example 2 — 16-byte Message (Complete Block)

```
Data:    6bc1bee2 2e409f96 e93d7e11 7393172a
CMAC:    070a16b4 6b4d4144 f79bdd9d d04a287c
```

### Example 3 — 40-byte Message (Incomplete Final Block)

```
Data:    6bc1bee2 2e409f96 e93d7e11 7393172a
         ae2d8a57 1e03ac9c 9eb76fac 45af8e51
         30c81c46 a35ce411
CMAC:    dfa66747 de9ae630 30ca3261 1497c827
```

### Example 4 — 64-byte Message (4 Complete Blocks)

```
Data:    6bc1bee2 2e409f96 e93d7e11 7393172a
         ae2d8a57 1e03ac9c 9eb76fac 45af8e51
         30c81c46 a35ce411 e5fbc119 1a0a52ef
         f69f2445 df4f9b17 ad2b417b e66c3710
CMAC:    51f0bebf 7e3b9d92 fc497417 79363cfe
```

---

## AES-256-CMAC

**Key:** `603deb10 15ca71be 2b73aef0 857d7781 1f352c07 3b6108d7 2d9810a3 0914dff4`

### Example 1 — Empty Message

```
Data:    (empty)
CMAC:    028962f6 1b7bf89e fc6b551f 4667d983
```

### Example 2 — 16-byte Message

```
Data:    6bc1bee2 2e409f96 e93d7e11 7393172a
CMAC:    28a7023f 452e8f82 bd4bf28d 8c37c35c
```

### Example 3 — 64-byte Message

```
Data:    6bc1bee2 2e409f96 e93d7e11 7393172a
         ae2d8a57 1e03ac9c 9eb76fac 45af8e51
         30c81c46 a35ce411 e5fbc119 1a0a52ef
         f69f2445 df4f9b17 ad2b417b e66c3710
CMAC:    e1992190 549f6ed5 696a2c05 6c315410
```

---

## AES-GMAC

AES-GMAC does not have standalone test vectors in NIST SP 800-38B. Instead, GMAC is validated by comparing against AES-GCM with empty plaintext, using the test vectors from NIST SP 800-38D.

The NUnit test suite cross-validates GMAC against `AesGcm128`, `AesGcm192`, and `AesGcm256` with empty plaintext to ensure consistent results.

---

## Validation

The NUnit test suite in `tests/Security/Cryptography/Mac/Cmac/CmacTests.cs` validates all NIST SP 800-38B test vectors and additionally cross-validates against BouncyCastle `CMac(AesEngine)` for:

- Empty messages
- Short messages
- Messages spanning multiple blocks
- AES-128 and AES-256 key sizes

The GMAC tests in `tests/Security/Cryptography/Mac/Gmac/GmacTests.cs` validate against the CryptoHives AES-GCM implementation with empty plaintext and test tag verification behavior.
