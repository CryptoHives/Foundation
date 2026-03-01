# NIST SP 800-38B - Recommendation for Block Cipher Modes of Operation: The CMAC Mode for Authentication

## Overview

NIST Special Publication 800-38B specifies the CMAC (Cipher-based Message Authentication Code) mode of operation for block ciphers. CMAC provides data origin authentication and data integrity assurance using a symmetric key block cipher.

## Official Reference

- **Document:** NIST SP 800-38B
- **Title:** Recommendation for Block Cipher Modes of Operation: The CMAC Mode for Authentication
- **URL:** https://csrc.nist.gov/pubs/sp/800-38b/upd1/final
- **PDF:** https://nvlpubs.nist.gov/nistpubs/SpecialPublications/NIST.SP.800-38B.pdf

### Related Standards

- **RFC 4493:** The AES-CMAC Algorithm
  - URL: https://www.rfc-editor.org/rfc/rfc4493
- **RFC 4494:** The AES-CMAC-96 Algorithm and Its Use with IPsec
  - URL: https://www.rfc-editor.org/rfc/rfc4494

## Implementation Status

| Algorithm | Key Size | MAC Size | Status | Class |
|-----------|----------|----------|--------|-------|
| AES-128-CMAC | 128 bits | 128 bits | ✅ Implemented | `AesCmac` |
| AES-192-CMAC | 192 bits | 128 bits | ✅ Implemented | `AesCmac` |
| AES-256-CMAC | 256 bits | 128 bits | ✅ Implemented | `AesCmac` |

## Algorithm

### Subkey Generation

CMAC derives two subkeys (K1, K2) from the cipher key:

```
Step 1:  L = AES-K(0^128)                    // Encrypt a zero block
Step 2:  if MSB(L) = 0                        // Doubling in GF(2^128)
           then K1 = L << 1
           else K1 = (L << 1) ⊕ R_b
Step 3:  if MSB(K1) = 0
           then K2 = K1 << 1
           else K2 = (K1 << 1) ⊕ R_b

Where R_b = 0x00...0087 (the reduction polynomial for GF(2^128))
```

### MAC Generation

```
Step 1:  n = ⌈len(M) / b⌉               // Number of blocks (b = 128 bits)
Step 2:  if n = 0 then n = 1
Step 3:  if len(M) is a multiple of b:
           M_n* = M_n ⊕ K1               // XOR last complete block with K1
         else:
           M_n* = (M_n ‖ 10^j) ⊕ K2      // Pad and XOR with K2
Step 4:  C_0 = 0^128                       // Initial state
Step 5:  for i = 1 to n-1:
           C_i = AES-K(C_{i-1} ⊕ M_i)    // CBC-MAC without K1/K2
Step 6:  T = AES-K(C_{n-1} ⊕ M_n*)       // Final block with subkey
Step 7:  return T
```

### Parameters

| Parameter | Value | Description |
|-----------|-------|-------------|
| b | 128 bits | Block size (AES) |
| R_b | 0x87 | GF(2^128) reduction constant |
| K1, K2 | 128 bits | Derived subkeys |
| T | 128 bits | Authentication tag |

---

## Protocol Usage

CMAC is widely used in:

- **IEEE 802.11i** (WPA2) — Key confirmation and integrity
- **EAP-SIM / EAP-AKA** — Authentication protocols
- **SIP Digest Authentication** — RFC 4474
- **NFC/EMV** — Payment card authentication
- **Bluetooth LE** — Secure connections

---

## AES-GMAC

NIST SP 800-38D defines GCM, and GMAC is the special case of GCM where the plaintext is empty. GMAC is documented here for completeness as it is closely related to CMAC as a cipher-based MAC.

### Definition

```
GMAC(K, IV, AAD) = AES-GCM(K, IV, plaintext = ∅, AAD).Tag
```

### Important Properties

- **Nonce-based:** Unlike CMAC, GMAC requires a unique nonce (IV) per message
- **Hardware accelerated:** Benefits from PCLMULQDQ for GHASH multiplication
- **Tag size:** 128 bits (16 bytes)

### Reference

- **Document:** NIST SP 800-38D
- **Title:** Recommendation for Block Cipher Modes of Operation: Galois/Counter Mode (GCM) and GMAC
- **URL:** https://csrc.nist.gov/pubs/sp/800-38d/final

---

## References

1. NIST SP 800-38B: https://doi.org/10.6028/NIST.SP.800-38B
2. RFC 4493: https://www.rfc-editor.org/rfc/rfc4493
3. NIST SP 800-38D: https://doi.org/10.6028/NIST.SP.800-38D
4. RFC 4494: https://www.rfc-editor.org/rfc/rfc4494
