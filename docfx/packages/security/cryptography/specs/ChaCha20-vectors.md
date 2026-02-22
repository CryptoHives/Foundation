# ChaCha20 and Poly1305 Test Vectors

## Source

RFC 8439: ChaCha20 and Poly1305 for IETF Protocols
- https://datatracker.ietf.org/doc/html/rfc8439

---

# ChaCha20 Block Function

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Key Size | 256 bits (32 bytes) |
| Nonce Size | 96 bits (12 bytes) |
| Block Size | 512 bits (64 bytes) |
| Counter | 32 bits |
| Rounds | 20 (10 double-rounds) |

## Test Vectors

### RFC 8439 Section 2.3.2: Block Function

```
Key:     00010203 04050607 08090a0b 0c0d0e0f
         10111213 14151617 18191a1b 1c1d1e1f
Nonce:   00000009 0000004a 00000000
Counter: 1

Keystream Block:
         10f1e7e4 d13b5915 500fdd1f a32071c4
         c7d1f4c7 33c06803 0422aa9a c3d46c4e
         d2826446 079faa09 14c2d705 d98b02a2
         b5129cd1 de164eb9 cbd083e8 a2503c4e
```

---

# ChaCha20 Encryption

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Key Size | 256 bits (32 bytes) |
| Nonce Size | 96 bits (12 bytes) |
| Block Size | 512 bits (64 bytes) |
| Initial Counter | Configurable (typically 0 or 1) |

## Test Vectors

### RFC 8439 Section 2.4.2: Encryption

```
Key:       00010203 04050607 08090a0b 0c0d0e0f
           10111213 14151617 18191a1b 1c1d1e1f
Nonce:     00000000 0000004a 00000000
Counter:   1

Plaintext: "Ladies and Gentlemen of the class of '99: If I could offer you
            only one tip for the future, sunscreen would be it."

Plaintext (hex):
           4c616469 65732061 6e642047 656e746c
           656d656e 206f6620 74686520 636c6173
           73206f66 20273939 3a204966 20492063
           6f756c64 206f6666 65722079 6f75206f
           6e6c7920 6f6e6520 74697020 666f7220
           74686520 66757475 72652c20 73756e73
           63726565 6e20776f 756c6420 62652069
           742e

Ciphertext:
           6e2e359a 2568f980 41ba0728 dd0d6981
           e97e7aec 1d4360c2 0a27afcc fd9fae0b
           f91b65c5 524733ab 8f593dab cd62b357
           1639d624 e65152ab 8f530c35 9f0861d8
           07ca0dbf 500d6a61 56a38e08 8a22b65e
           52bc514d 16ccf806 818ce91a b7793736
           5af90bbf 74a35be6 b40b8eed f2785e42
           874d
```

---

# Poly1305 MAC

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Key Size | 256 bits (32 bytes) |
| Tag Size | 128 bits (16 bytes) |
| Block Size | 128 bits (16 bytes) |

## Test Vectors

### RFC 8439 Section 2.5.2: Poly1305 MAC

```
Key:     85d6be78 57556d33 7f4452fe 42d506a8
         0103808a fb0db2fd 4abff6af 4149f51b
Message: "Cryptographic Forum Research Group"
Tag:     a8061dc1 305136c6 c22b8baf 0c0127a9
```

---

# ChaCha20-Poly1305 AEAD

## Algorithm Parameters

| Parameter | Value |
|-----------|-------|
| Key Size | 256 bits (32 bytes) |
| Nonce Size | 96 bits (12 bytes) |
| Tag Size | 128 bits (16 bytes) |
| Mode | Authenticated Encryption with Associated Data (AEAD) |

## Test Vectors

### RFC 8439 Section 2.8.2: AEAD Encryption

```
Key:        80818283 84858687 88898a8b 8c8d8e8f
            90919293 94959697 98999a9b 9c9d9e9f
Nonce:      07000000 40414243 44454647
AAD:        50515253 c0c1c2c3 c4c5c6c7

Plaintext:  "Ladies and Gentlemen of the class of '99: If I could offer you
             only one tip for the future, sunscreen would be it."

Plaintext (hex):
            4c616469 65732061 6e642047 656e746c
            656d656e 206f6620 74686520 636c6173
            73206f66 20273939 3a204966 20492063
            6f756c64 206f6666 65722079 6f75206f
            6e6c7920 6f6e6520 74697020 666f7220
            74686520 66757475 72652c20 73756e73
            63726565 6e20776f 756c6420 62652069
            742e

Ciphertext:
            d31a8d34 648e60db 7b86afbc 53ef7ec2
            a4aded51 296e08fe a9e2b5a7 36ee62d6
            3dbea45e 8ca96712 82fafb69 da92728b
            1a71de0a 9e060b29 05d6a5b6 7ecd3b36
            92ddbd7f 2d778b8c 9803aee3 28091b58
            fab324e4 fad67594 5585808b 4831d7bc
            3ff4def0 8e4b7a9d e576d265 86cec64b
            6116

Tag:        1ae10b59 4f09e26a 7e902ecb d0600691
```
