# Cryptographic Test Vectors

This folder contains test vectors for cryptographic hash algorithms from official sources.

## Implementation Status

### FIPS 180-4 (Secure Hash Standard)

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| SHA-1 | 160 bits | ✅ Implemented | `SHA1` |
| SHA-224 | 224 bits | ✅ Implemented | `SHA224` |
| SHA-256 | 256 bits | ✅ Implemented | `SHA256` |
| SHA-384 | 384 bits | ✅ Implemented | `SHA384` |
| SHA-512 | 512 bits | ✅ Implemented | `SHA512` |
| SHA-512/224 | 224 bits | ✅ Implemented | `SHA512_224` |
| SHA-512/256 | 256 bits | ✅ Implemented | `SHA512_256` |

### FIPS 202 (SHA-3 Standard)

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| SHA3-224 | 224 bits | ✅ Implemented | `SHA3_224` |
| SHA3-256 | 256 bits | ✅ Implemented | `SHA3_256` |
| SHA3-384 | 384 bits | ✅ Implemented | `SHA3_384` |
| SHA3-512 | 512 bits | ✅ Implemented | `SHA3_512` |
| SHAKE128 | Variable | ✅ Implemented | `Shake128` |
| SHAKE256 | Variable | ✅ Implemented | `Shake256` |

### NIST SP 800-185 (SHA-3 Derived Functions)

| Algorithm | Security | Status | Class |
|-----------|----------|--------|-------|
| cSHAKE128 | 128 bits | ✅ Implemented | `CShake128` |
| cSHAKE256 | 256 bits | ✅ Implemented | `CShake256` |
| KMAC128 | 128 bits | ✅ Implemented | `KMac128` |
| KMAC256 | 256 bits | ✅ Implemented | `KMac256` |
| TupleHash128 | 128 bits | ⬜ Not implemented | - |
| TupleHash256 | 256 bits | ⬜ Not implemented | - |
| ParallelHash128 | 128 bits | ⬜ Not implemented | - |
| ParallelHash256 | 256 bits | ⬜ Not implemented | - |

### RFC 9861 (TurboSHAKE and KangarooTwelve)

| Algorithm | Security | Status | Class |
|-----------|----------|--------|-------|
| TurboSHAKE128 | 128 bits | ✅ Implemented | `TurboShake128` |
| TurboSHAKE256 | 256 bits | ✅ Implemented | `TurboShake256` |
| KT128 | 128 bits | ✅ Implemented | `KT128` |
| KT256 | 256 bits | ✅ Implemented | `KT256` |

> **Note:** KT128 and KT256 (formerly KangarooTwelve and MarsupilamiFourteen) are defined in RFC 9861.
> They use reduced-round Keccak (12 rounds) for ~2× faster performance than SHAKE.

### NIST FIPS 207 (Ascon Lightweight Cryptography)

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| Ascon-Hash256 | 256 bits | ✅ Implemented | `AsconHash256` |
| Ascon-XOF128 | Variable | ✅ Implemented | `AsconXof128` |

> **Note:** Ascon was selected as the NIST Lightweight Cryptography standard in 2023.
> It is designed for constrained environments (IoT, embedded systems).

### Keccak (Original Algorithm)

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| Keccak-256 | 256 bits | ✅ Implemented | `Keccak256` |
| Keccak-384 | 384 bits | ✅ Implemented | `Keccak384` |
| Keccak-512 | 512 bits | ✅ Implemented | `Keccak512` |

> **Note:** Keccak uses the original Keccak padding (0x01) as used in Ethereum.
> SHA-3 uses different padding (0x06). Use `SHA3_256` for NIST SHA-3 compliance.

### RFC 7693 (BLAKE2)

| Algorithm | Hash Size | Features | Status | Class |
|-----------|-----------|----------|--------|-------|
| BLAKE2b | 1-64 bytes | Hash, Keyed (MAC) | ✅ Implemented | `Blake2b` |
| BLAKE2s | 1-32 bytes | Hash, Keyed (MAC) | ✅ Implemented | `Blake2s` |

#### BLAKE2 Features

| Feature | BLAKE2b | BLAKE2s | Description |
|---------|---------|---------|-------------|
| Variable output | ✅ | ✅ | Output size 1-64 bytes (b) or 1-32 bytes (s) |
| Keyed hashing (MAC) | ✅ | ✅ | Built-in MAC mode with key up to 64/32 bytes |
| Salt | ❌ | ❌ | Optional (not implemented) |
| Personalization | ❌ | ❌ | Optional (not implemented) |
| Tree hashing | ❌ | ❌ | Optional (not implemented) |
| Parallel variants | ❌ | ❌ | BLAKE2bp/BLAKE2sp (not implemented) |

### BLAKE3

| Algorithm | Hash Size | Features | Status | Class |
|-----------|-----------|----------|--------|-------|
| BLAKE3 | Variable | Hash, Keyed, Derive Key | ✅ Implemented | `Blake3` |

#### BLAKE3 Modes

| Mode | Status | Factory Method | Description |
|------|--------|----------------|-------------|
| Hash | ✅ | `Blake3.Create()` | Standard cryptographic hashing |
| Keyed Hash | ✅ | `Blake3.CreateKeyed(key)` | MAC with 32-byte key |
| Derive Key | ✅ | `Blake3.CreateDeriveKey(context)` | Key derivation from context + input |
| XOF | ✅ | `Blake3.Create(outputBytes)` | Extendable output (any length) |

### RIPEMD Family

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| RIPEMD-160 | 160 bits | ✅ Implemented | `Ripemd160` |

> **Note:** RIPEMD-160 is widely used in cryptocurrency systems (Bitcoin address generation).

### SM3 (Chinese National Standard)

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| SM3 | 256 bits | ✅ Implemented | `SM3` |

> **Standard:** GB/T 32905-2016 (China), ISO/IEC 10118-3:2018

### Whirlpool (ISO/IEC 10118-3)

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| Whirlpool | 512 bits | ✅ Implemented | `Whirlpool` |

> **Standard:** ISO/IEC 10118-3:2004, NESSIE recommended

### Streebog / GOST R 34.11-2012 (Russian National Standard)

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| Streebog-256 | 256 bits | ✅ Implemented | `Streebog` |
| Streebog-512 | 512 bits | ✅ Implemented | `Streebog` |

> **Standard:** GOST R 34.11-2012, RFC 6986

### Kupyna / DSTU 7564:2014 (Ukrainian National Standard)

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| Kupyna-256 | 256 bits | ✅ Implemented | `Kupyna` |
| Kupyna-384 | 384 bits | ✅ Implemented | `Kupyna` |
| Kupyna-512 | 512 bits | ✅ Implemented | `Kupyna` |

> **Standard:** DSTU 7564:2014 (Ukraine)

### LSH / KS X 3262 (Korean National Standard)

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| LSH-256-224 | 224 bits | ✅ Implemented | `Lsh256` |
| LSH-256-256 | 256 bits | ✅ Implemented | `Lsh256` |
| LSH-512-256 | 256 bits | ✅ Implemented | `Lsh512` |
| LSH-512-384 | 384 bits | ✅ Implemented | `Lsh512` |
| LSH-512-512 | 512 bits | ✅ Implemented | `Lsh512` |

> **Standard:** KS X 3262 (South Korea), approved by KCMVP

### Legacy Algorithms

| Algorithm | Hash Size | Status | Class |
|-----------|-----------|--------|-------|
| MD5 | 128 bits | ✅ Implemented (deprecated) | `MD5` |

> **Warning:** MD5 is cryptographically broken and should NOT be used for security purposes.
> It is provided only for legacy compatibility and non-cryptographic uses.

---

## Sources

### NIST (National Institute of Standards and Technology)

Official test vectors and examples with intermediate values are available from:

- **NIST Cryptographic Standards and Guidelines Example Values**:
  https://csrc.nist.gov/projects/cryptographic-standards-and-guidelines/example-values

#### SHA-1 and SHA-2 Family (FIPS 180-4)

The official FIPS 180-4 specification is available from NIST:
- **[NIST-FIPS-180-4.md](NIST-FIPS-180-4.md)** - Local reference with algorithm details and test vectors
- [NIST FIPS 180-4](https://csrc.nist.gov/pubs/fips/180-4/upd1/final) - Secure Hash Standard (SHS): SHA-1, SHA-224, SHA-256, SHA-384, SHA-512, SHA-512/224, SHA-512/256

##### SHA-1 (Legacy Only)
- [SHA-1 Examples](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA1.pdf)

##### SHA-2 Family
- [SHA-224 Examples](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA224.pdf)
- [SHA-256 Examples](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA256.pdf)
- [SHA-384 Examples](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA384.pdf)
- [SHA-512 Examples](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA512.pdf)
- [SHA-512/224 Examples](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA512_224.pdf)
- [SHA-512/256 Examples](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA512_256.pdf)
- [All SHA-2 Examples](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA_All.pdf)
- [Additional SHA-2 Data](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA2_Additional.pdf)

#### SHA-3 and SHAKE (FIPS 202)

The official FIPS 202 specification is available from NIST:
- **[NIST-FIPS-202.md](NIST-FIPS-202.md)** - Local reference with algorithm details and test vectors
- [NIST FIPS 202](https://csrc.nist.gov/pubs/fips/202/final) - SHA-3 Standard: Permutation-Based Hash and Extendable-Output Functions

| Algorithm | 0-bit | 5-bit | 30-bit | 1600-bit | 1605-bit | 1630-bit |
|-----------|-------|-------|--------|----------|----------|----------|
| SHA3-224 | [Msg0](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-224_Msg0.pdf) | [Msg5](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-224_Msg5.pdf) | [Msg30](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-224_Msg30.pdf) | [1600](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-224_1600.pdf) | [1605](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-224_1605.pdf) | [1630](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-224_1630.pdf) |
| SHA3-256 | [Msg0](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-256_Msg0.pdf) | [Msg5](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-256_Msg5.pdf) | [Msg30](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-256_Msg30.pdf) | [1600](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-256_1600.pdf) | [1605](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-256_1605.pdf) | [1630](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-256_1630.pdf) |
| SHA3-384 | [Msg0](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-384_Msg0.pdf) | [Msg5](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-384_Msg5.pdf) | [Msg30](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-384_Msg30.pdf) | [1600](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-384_1600.pdf) | [1605](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-384_1605.pdf) | [1630](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-384_1630.pdf) |
| SHA3-512 | [Msg0](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-512_Msg0.pdf) | [Msg5](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-512_Msg5.pdf) | [Msg30](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-512_Msg30.pdf) | [1600](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-512_1600.pdf) | [1605](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-512_1605.pdf) | [1630](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHA3-512_1630.pdf) |

#### SHAKE XOF (FIPS 202)

| Algorithm | 0-bit | 5-bit | 30-bit | 1600-bit | 1605-bit | 1630-bit |
|-----------|-------|-------|--------|----------|----------|----------|
| SHAKE128 | [Msg0](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE128_Msg0.pdf) | [Msg5](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE128_Msg5.pdf) | [Msg30](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE128_Msg30.pdf) | [1600](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE128_Msg1600.pdf) | [1605](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE128_Msg1605.pdf) | [1630](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE128_Msg1630.pdf) |
| SHAKE256 | [Msg0](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE256_Msg0.pdf) | [Msg5](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE256_Msg5.pdf) | [Msg30](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE256_Msg30.pdf) | [1600](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE256_Msg1600.pdf) | [1605](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE256_Msg1605.pdf) | [1630](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/SHAKE256_Msg1630.pdf) |

- [SHAKE Truncation Examples](https://csrc.nist.gov/CSRC/media/Projects/Cryptographic-Standards-and-Guidelines/documents/examples/ShakeTruncation.pdf)

#### NIST SP 800-185 (SHA-3 Derived Functions)

Reference documentation for cSHAKE, KMAC, TupleHash, and ParallelHash:
- **[NIST-SP-800-185.md](NIST-SP-800-185.md)** - Local reference with test vectors
- [NIST SP 800-185 PDF](https://nvlpubs.nist.gov/nistpubs/SpecialPublications/NIST.SP.800-185.pdf)

### BLAKE2 (RFC 7693)

The official RFC 7693 specification is available from IETF:
- [RFC 7693](https://www.rfc-editor.org/rfc/rfc7693) - The BLAKE2 Cryptographic Hash and Message Authentication Code (MAC)

Additional BLAKE2 resources:
- https://www.blake2.net/
- https://github.com/BLAKE2/BLAKE2

### BLAKE3

BLAKE3 test vectors are from the official BLAKE3 specification:
- https://github.com/BLAKE3-team/BLAKE3

### RIPEMD-160

- **[RIPEMD-160-vectors.md](RIPEMD-160-vectors.md)** - Test vectors
- Original specification: https://homes.esat.kuleuven.be/~bosselae/ripemd160.html

### SM3 (GB/T 32905-2016)

- **[SM3-vectors.md](SM3-vectors.md)** - Test vectors
- GB/T 32905-2016 (Chinese national standard)
- ISO/IEC 10118-3:2018

### Whirlpool

- **[Whirlpool-vectors.md](Whirlpool-vectors.md)** - Test vectors
- ISO/IEC 10118-3:2004
- https://www.larc.usp.br/~pbarreto/WhirlpoolPage.html

### Streebog (GOST R 34.11-2012)

- **[Streebog-vectors.md](Streebog-vectors.md)** - Test vectors
- RFC 6986: https://www.rfc-editor.org/rfc/rfc6986

### Kupyna (DSTU 7564:2014)

- **[Kupyna-vectors.md](Kupyna-vectors.md)** - Test vectors
- IACR ePrint 2015/885: https://eprint.iacr.org/2015/885.pdf
- Reference implementation: https://github.com/Roman-Oliynykov/Kupyna-reference

### LSH (KS X 3262)

- KS X 3262 specification (Korean standard)
- Reference implementation: https://seed.kisa.or.kr/kisa/algorithm/EgovLSHInfo.do

### MD5 (RFC 1321)

MD5 is defined in RFC 1321:
- https://www.ietf.org/rfc/rfc1321.txt

## File Organization

```
specs/
├── README.md              # This file
├── toc.yml                # DocFX table of contents
├── NIST-FIPS-180-4.md     # NIST FIPS 180-4 - SHA-1, SHA-2 reference
├── NIST-FIPS-202.md       # NIST FIPS 202 - SHA-3, SHAKE reference
├── NIST-SP-800-185.md     # NIST SP 800-185 - cSHAKE, KMAC reference
├── SHA1-vectors.md        # SHA-1 test vectors (legacy)
├── SHA2-vectors.md        # SHA-2 family test vectors
├── SHA3-vectors.md        # SHA-3 family test vectors
├── SHAKE-vectors.md       # SHAKE128, SHAKE256 test vectors
├── Keccak-vectors.md      # Keccak-256, Keccak-384, Keccak-512 test vectors
├── KT-vectors.md          # KT128, KT256 (KangarooTwelve) test vectors
├── TurboSHAKE-vectors.md  # TurboSHAKE128, TurboSHAKE256 test vectors
├── BLAKE2-vectors.md      # BLAKE2b, BLAKE2s test vectors
├── BLAKE3-vectors.md      # BLAKE3 test vectors
├── RIPEMD-160-vectors.md  # RIPEMD-160 test vectors
├── SM3-vectors.md         # SM3 test vectors
├── Whirlpool-vectors.md   # Whirlpool test vectors
├── Streebog-vectors.md    # Streebog (GOST) test vectors
├── Kupyna-vectors.md      # Kupyna (DSTU 7564) test vectors
├── LSH-vectors.md         # LSH (KS X 3262) test vectors
└── MD5-vectors.md         # MD5 test vectors (legacy)
```

## Usage

These test vectors are used by the unit tests in `tests/Security/Cryptography/` to verify
the correctness of our hash implementations against known good values from official sources.

## License

The test vectors themselves are derived from public standards and specifications.
See individual specification documents for their respective terms.
