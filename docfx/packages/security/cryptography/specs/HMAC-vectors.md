# HMAC Test Vectors

Test vectors for HMAC-SHA-256, HMAC-SHA-384, and HMAC-SHA-512 from RFC 4231.

## Source

- **RFC 4231:** Identifiers and Test Vectors for HMAC-SHA-224, HMAC-SHA-256, HMAC-SHA-384, and HMAC-SHA-512
- **URL:** https://www.rfc-editor.org/rfc/rfc4231

---

## HMAC-SHA-256

### Test Case 1

```
Key:     0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b (20 bytes)
Data:    "Hi There" (ASCII)
HMAC:    b0344c61d8db38535ca8afceaf0bf12b881dc200c9833da726e9376c2e32cff7
```

### Test Case 2

```
Key:     "Jefe" (ASCII)
Data:    "what do ya want for nothing?" (ASCII)
HMAC:    5bdcc146bf60754e6a042426089575c75a003f089d2739839dec58b964ec3843
```

### Test Case 3

```
Key:     aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa (20 bytes of 0xaa)
Data:    50 bytes of 0xdd
HMAC:    773ea91e36800e46854db8ebd09181a72959098b3ef8c122d9635514ced565fe
```

### Test Case 4

```
Key:     0102030405060708090a0b0c0d0e0f10111213141516171819 (25 bytes)
Data:    50 bytes of 0xcd
HMAC:    82558a389a443c0ea4cc819899f2083a85f0faa3e578f8077a2e3ff46729665b
```

### Test Case 6 (Key > Block Size)

```
Key:     131 bytes of 0xaa
Data:    "Test Using Larger Than Block-Size Key - Hash Key First" (ASCII)
HMAC:    60e431591ee0b67f0d8a26aacbf5b77f8e0bc6213728c5140546040f0ee37f54
```

### Test Case 7 (Key > Block Size, Long Data)

```
Key:     131 bytes of 0xaa
Data:    "This is a test using a larger than block-size key and a larger than
         block-size data. The key needs to be hashed before being used by the
         HMAC algorithm." (ASCII)
HMAC:    9b09ffa71b942fcb27635fbcd5b0e944bfdc63644f0713938a7f51535c3a35e2
```

---

## HMAC-SHA-384

### Test Case 1

```
Key:     0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b (20 bytes)
Data:    "Hi There" (ASCII)
HMAC:    afd03944d84895626b0825f4ab46907f15f9dadbe4101ec682aa034c7cebc59c
         faea9ea9076ede7f4af152e8b2fa9cb6
```

### Test Case 2

```
Key:     "Jefe" (ASCII)
Data:    "what do ya want for nothing?" (ASCII)
HMAC:    af45d2e376484031617f78d2b58a6b1b9c7ef464f5a01b47e42ec3736322445e
         8e2240ca5e69e2c78b3239ecfab21649
```

---

## HMAC-SHA-512

### Test Case 1

```
Key:     0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b0b (20 bytes)
Data:    "Hi There" (ASCII)
HMAC:    87aa7cdea5ef619d4ff0b4241a1d6cb02379f4e2ce4ec2787ad0b30545e17cde
         daa833b7d6b8a702038b274eaea3f4e4be9d914eeb61f1702e696c203a126854
```

### Test Case 2

```
Key:     "Jefe" (ASCII)
Data:    "what do ya want for nothing?" (ASCII)
HMAC:    164b7a7bfcf819e2e395fbe73b56e0a387bd64222e831fd610270cd7ea250554
         9758bf75c05a994a6d034f65f8f0e6fdcaeab1a34d4a6b4b636e070a38bce737
```

---

## Validation

The NUnit test suite in `tests/Security/Cryptography/Mac/Hmac/HmacTests.cs` validates all RFC 4231 test vectors and additionally cross-validates against:

- .NET built-in `HMACSHA256`, `HMACSHA384`, `HMACSHA512`, `HMACSHA1`, `HMACMD5`
- BouncyCastle `HMac` with `Sha3Digest(256)` for HMAC-SHA3-256
- Various input sizes (0 to 1024 bytes) to test block boundary behavior
