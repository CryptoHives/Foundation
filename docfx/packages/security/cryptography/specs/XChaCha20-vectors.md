# XChaCha20-Poly1305 Test Vectors

## Source

draft-irtf-cfrg-xchacha-03: XChaCha20 and XChaCha20-Poly1305
- https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-xchacha

---

# HChaCha20

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Key Size | 256 bits (32 bytes) |
| Nonce Size | 128 bits (16 bytes) |
| Output Size | 256 bits (32 bytes) |

## Test Vectors

### draft-irtf-cfrg-xchacha Section 2.2.1: HChaCha20

```
Key:    00010203 04050607 08090a0b 0c0d0e0f
        10111213 14151617 18191a1b 1c1d1e1f
Nonce:  00000009 0000004a 00000000 31415927

Subkey: 82413b42 27b27bfe d30e4250 8a877d73
        a0f9e4d5 8a74a853 c12ec413 26d3ecdc
```

---

# XChaCha20-Poly1305 AEAD

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Key Size | 256 bits (32 bytes) |
| Nonce Size | 192 bits (24 bytes) |
| Tag Size | 128 bits (16 bytes) |
| Mode | Authenticated Encryption with Associated Data (AEAD) |

## Test Vectors

### draft-irtf-cfrg-xchacha Appendix A.1: AEAD Encryption

```
Key:        80818283 84858687 88898a8b 8c8d8e8f
            90919293 94959697 98999a9b 9c9d9e9f
Nonce:      40414243 44454647 48494a4b 4c4d4e4f
            50515253 54555657
AAD:        50515253 c0c1c2c3 c4c5c6c7

Plaintext:  "Ladies and Gentlemen of the class of '99: If I could offer you
             only one tip for the future, sunscreen would be it."

Plaintext (hex):
            4c616469 65732061 6e642047 656e746c
            656d656e 206f6620 74686520 636c6173
            73206f66 20273939 3a204966 204920636f
            756c6420 6f666665 7220796f 75206f6e
            6c79206f 6e652074 69702066 6f722074
            6865206675747572 652c2073 756e7363
            7265656e 20776f75 6c642062 6520
            69742e

Ciphertext:
            bd6d179d 3e83d43b 95765794 93c0e939
            572a1700 252bfacc bed2902c 21396cbb
            731c7f1b 0b4aa644 0bf3a82f 4eda7e39
            ae64c670 8c54c216 cb96b72e 1213b452
            2f8c9ba4 0db5d945 b11b69b9 82c1bb9e
            3f3fac2b c369488f 76b23835 65d3fff9
            21f9664c 97637da9 768812f6 15c68b13
            b52e

Tag:        c0875924 c1c79879 47deafd8 780acf49
```
