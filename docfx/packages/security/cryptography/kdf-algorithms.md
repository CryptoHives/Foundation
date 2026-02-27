# Key Derivation Functions (KDF) Reference

This page provides detailed documentation for all Key Derivation Functions (KDFs) implemented in the CryptoHives.Foundation.Security.Cryptography package.

## Namespace

```csharp
using CryptoHives.Foundation.Security.Cryptography.Kdf;
```

---

## Overview

Key Derivation Functions extract cryptographic keys from input keying material (IKM) such as shared secrets from key agreement (e.g., ECDH), pre-shared keys, or other entropy sources. Unlike password-based KDFs (PBKDF2, Argon2), these functions assume the input already has sufficient entropy and focus on uniform key extraction and expansion.

### When to Use a KDF

| Scenario | Recommended KDF | Standard |
|----------|-----------------|----------|
| TLS 1.3 key schedule | HKDF | RFC 5869 |
| HPKE (Hybrid Public Key Encryption) | HKDF | RFC 9180 |
| IKEv2 / IPsec key derivation | HKDF | RFC 7296 |
| Signal / Double Ratchet protocol | HKDF | Signal Spec |
| WireGuard VPN | HKDF / BLAKE3 | WireGuard Spec |
| General key expansion | HKDF | RFC 5869 |
| Application key diversification | HKDF or BLAKE3 | — |

---

## HKDF (HMAC-Based Extract-and-Expand KDF)

HKDF is the HMAC-based Extract-and-Expand Key Derivation Function defined in [RFC 5869](https://tools.ietf.org/html/rfc5869). It is the most widely used KDF in modern cryptographic protocols.

### Design

HKDF consists of two stages:

1. **Extract** — Concentrates the entropy from potentially non-uniform input keying material (IKM) into a fixed-length pseudorandom key (PRK) using HMAC with an optional salt.
2. **Expand** — Derives one or more output keys of arbitrary length from the PRK using HMAC with optional context information.

```
  IKM ──► [ Extract ] ──► PRK ──► [ Expand ] ──► OKM (output keys)
             ▲                        ▲
            salt                     info
```

### HmacFactory Delegate

All HKDF methods accept an `HmacFactory` delegate that creates `IMac` instances keyed with a given key. This design allows plugging any HMAC variant without changing the KDF logic.

```csharp
public delegate IMac HmacFactory(byte[] key);
```

**Built-in factories:**

```csharp
// SHA-256 (TLS 1.3, Signal, HPKE default)
HmacFactory sha256 = key => new HmacSha256(key);

// SHA-384 (TLS 1.3 with P-384)
HmacFactory sha384 = key => new HmacSha384(key);

// SHA-512 (maximum security)
HmacFactory sha512 = key => new HmacSha512(key);

// SHA3-256 (NIST PQC, cross-platform)
HmacFactory sha3_256 = key => new HmacSha3_256(key);
```

### Class Declaration

```csharp
public static class Hkdf
```

### Methods

| Method | Description |
|--------|-------------|
| `Extract(HmacFactory, ReadOnlySpan<byte>, ReadOnlySpan<byte>, Span<byte>)` | Extract PRK from IKM and salt (span overload) |
| `Extract(HmacFactory, byte[], byte[]?)` | Extract PRK from IKM and salt (array overload) |
| `Expand(HmacFactory, ReadOnlySpan<byte>, Span<byte>, ReadOnlySpan<byte>)` | Expand PRK into output keying material (span overload) |
| `Expand(HmacFactory, byte[], int, byte[]?)` | Expand PRK into output keying material (array overload) |
| `DeriveKey(HmacFactory, ReadOnlySpan<byte>, Span<byte>, ReadOnlySpan<byte>, ReadOnlySpan<byte>)` | Combined Extract-then-Expand (span overload) |
| `DeriveKey(HmacFactory, byte[], int, byte[]?, byte[]?)` | Combined Extract-then-Expand (array overload) |

### Usage Examples

#### Combined Extract-and-Expand (Most Common)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Kdf;
using CryptoHives.Foundation.Security.Cryptography.Mac;

byte[] inputKeyMaterial = ...; // e.g., ECDH shared secret
byte[] salt = new byte[32];
RandomNumberGenerator.Fill(salt);
byte[] info = Encoding.UTF8.GetBytes("TLS 1.3 key");

// Array API (simple)
byte[] derivedKey = Hkdf.DeriveKey(
    key => new HmacSha256(key),
    inputKeyMaterial, outputLength: 32, salt, info);

// Span API (zero extra allocations)
Span<byte> output = stackalloc byte[32];
Hkdf.DeriveKey(
    key => new HmacSha256(key),
    inputKeyMaterial, output, salt, info);
```

#### Separate Extract and Expand

When multiple keys are needed from the same IKM, extract once and expand multiple times:

```csharp
HmacFactory factory = key => new HmacSha256(key);
byte[] sharedSecret = ...; // from ECDH

// Step 1: Extract
byte[] prk = Hkdf.Extract(factory, sharedSecret, salt: null);

// Step 2: Expand for different purposes
byte[] encryptionKey = Hkdf.Expand(factory, prk, outputLength: 32,
    info: Encoding.UTF8.GetBytes("encryption"));

byte[] authKey = Hkdf.Expand(factory, prk, outputLength: 32,
    info: Encoding.UTF8.GetBytes("authentication"));

byte[] ivKey = Hkdf.Expand(factory, prk, outputLength: 12,
    info: Encoding.UTF8.GetBytes("iv"));
```

#### TLS 1.3 Key Schedule Pattern

```csharp
HmacFactory sha256 = key => new HmacSha256(key);

// Early Secret: Extract(salt=0, IKM=PSK or 0)
byte[] earlySecret = Hkdf.Extract(sha256, psk ?? new byte[32], salt: null);

// Handshake Secret: Extract(salt=derived, IKM=ECDHE)
byte[] derivedSalt = Hkdf.Expand(sha256, earlySecret, 32,
    Encoding.UTF8.GetBytes("derived"));
byte[] handshakeSecret = Hkdf.Extract(sha256, ecdhSharedSecret, derivedSalt);

// Traffic keys: Expand with labeled info
byte[] clientKey = Hkdf.Expand(sha256, handshakeSecret, 32,
    Encoding.UTF8.GetBytes("c hs traffic"));
```

#### With SHA-384 or SHA-512

```csharp
// SHA-384 (48-byte output, used with P-384 curves)
byte[] key384 = Hkdf.DeriveKey(
    key => new HmacSha384(key),
    ikm, outputLength: 48, salt, info);

// SHA-512 (64-byte output, maximum security)
byte[] key512 = Hkdf.DeriveKey(
    key => new HmacSha512(key),
    ikm, outputLength: 64, salt, info);
```

### Parameters

#### Salt

Per RFC 5869 §2.2, salt is optional but strongly recommended. If not provided, it defaults to a zero-filled byte array of length `HashLen` (e.g., 32 bytes for HMAC-SHA-256).

- **Best practice:** Use a random salt of at least `HashLen` bytes
- **Acceptable:** Use a fixed application-specific salt
- **Minimum:** Omit salt (uses all-zeros, reduces security margin)

#### Info

The `info` parameter binds the derived key to a specific context, preventing key reuse across different purposes. It should include:

- Protocol identifier (e.g., "TLS 1.3")
- Purpose label (e.g., "encryption", "authentication")
- Session identifiers or nonces where appropriate

#### Output Length

The maximum output length is `255 × HashLen` bytes:

| HMAC Variant | HashLen | Max Output |
|-------------|---------|------------|
| HMAC-SHA-256 | 32 bytes | 8,160 bytes |
| HMAC-SHA-384 | 48 bytes | 12,240 bytes |
| HMAC-SHA-512 | 64 bytes | 16,320 bytes |

### Comparison with .NET Built-in

| Feature | CryptoHives HKDF | System.Security.Cryptography.HKDF |
|---------|------------------|-----------------------------------|
| Availability | All TFMs (.NET Framework 4.6.2+) | .NET Core 3.0+ only |
| HMAC variants | Any `IMac` (SHA-256/384/512, SHA3-256, etc.) | SHA-1, SHA-256, SHA-384, SHA-512 only |
| SHA-3 support | ✅ via HmacSha3_256 | ❌ |
| API style | Instance + static, span + array | Static only, span-based |
| OS dependency | None (fully managed) | Uses CNG/OpenSSL |

### Standards Compliance

- **RFC 5869**: HKDF specification — all 7 Appendix A test vectors verified
- **RFC 8446**: TLS 1.3 key schedule uses HKDF-Extract and HKDF-Expand
- **RFC 9180**: HPKE uses HKDF with labeled Extract/Expand
- **RFC 7296**: IKEv2 uses HKDF for key derivation

---

## KBKDF — Counter Mode (SP 800-108r1)

KBKDF (Key-Based Key Derivation Function) in Counter Mode derives keying material from a key derivation key (KI) using a pseudorandom function iterated with an incrementing counter, as defined in [NIST SP 800-108r1 §4.1](https://csrc.nist.gov/pubs/sp/800/108/r1/upd1/final).

### Design

Counter Mode iterates a PRF (HMAC or CMAC) with a 32-bit counter prepended to fixed input data:

```
K(i) = PRF(KI, [i]₄ ‖ Label ‖ 0x00 ‖ Context ‖ [L]₄)
```

Where:
- `[i]₄` = 32-bit big-endian counter (1-based)
- `Label` = purpose identifier
- `0x00` = separator byte
- `Context` = session/application context
- `[L]₄` = output length in bits (32-bit big-endian)

### Class Declaration

```csharp
public static class Kbkdf
```

### Methods

| Method | Description |
|--------|-------------|
| `DeriveKey(HmacFactory, ReadOnlySpan<byte>, Span<byte>, ReadOnlySpan<byte>, ReadOnlySpan<byte>)` | Derive key with label and context (span overload) |
| `DeriveKey(HmacFactory, byte[], int, byte[]?, byte[]?)` | Derive key with label and context (array overload) |

### Usage Examples

#### Basic Key Derivation

```csharp
using CryptoHives.Foundation.Security.Cryptography.Kdf;
using CryptoHives.Foundation.Security.Cryptography.Mac;

byte[] masterKey = ...; // key derivation key
byte[] label = Encoding.UTF8.GetBytes("encryption");
byte[] context = Encoding.UTF8.GetBytes("session-001");

// Array API (simple)
byte[] derivedKey = Kbkdf.DeriveKey(
    key => new HmacSha256(key),
    masterKey, outputLength: 32, label, context);

// Span API (zero extra allocations)
Span<byte> output = stackalloc byte[32];
Kbkdf.DeriveKey(
    key => new HmacSha256(key),
    masterKey, output, label, context);
```

#### Multiple Keys from Same Master Key

```csharp
HmacFactory sha256 = key => new HmacSha256(key);
byte[] context = Encoding.UTF8.GetBytes("session-001");

// Derive different keys by varying the label
byte[] encKey = Kbkdf.DeriveKey(sha256, masterKey, 32,
    Encoding.UTF8.GetBytes("encryption"), context);

byte[] authKey = Kbkdf.DeriveKey(sha256, masterKey, 32,
    Encoding.UTF8.GetBytes("authentication"), context);

byte[] ivKey = Kbkdf.DeriveKey(sha256, masterKey, 12,
    Encoding.UTF8.GetBytes("iv"), context);
```

#### With AES-CMAC as PRF

```csharp
// AES-128 CMAC produces 16-byte MACs
byte[] aesKey = ...; // 16, 24, or 32 bytes
byte[] derived = Kbkdf.DeriveKey(
    key => AesCmac.Create(key),
    aesKey, outputLength: 32, label, context);
```

### KBKDF vs HKDF

| Aspect | KBKDF (SP 800-108r1) | HKDF (RFC 5869) |
|--------|----------------------|-----------------|
| Design | Single-phase counter loop | Two-phase Extract + Expand |
| Input key | Must be uniformly random | Can be non-uniform (Extract handles it) |
| Salt | No salt parameter | Optional salt for extraction |
| PRF support | HMAC and CMAC | HMAC only |
| Label/Context | Built into the construction | Via `info` parameter |
| Best for | Session key derivation from master key | Key extraction from shared secrets |
| Standards | NIST SP 800-108r1, CNG, DPAPI | RFC 5869, TLS 1.3, HPKE |

### Standards Compliance

- **NIST SP 800-108r1**: Counter Mode KDF — verified against independently computed test vectors
- Compatible with .NET `SP800108DeriveBytes` (same PRF input format)

---

## BLAKE3 Key Derivation

BLAKE3 provides a built-in key derivation mode that uses a context string for domain separation. Unlike HKDF, it does not require a separate HMAC; the KDF is integrated into the hash function.

See [Hash Algorithms — BLAKE3](hash-algorithms.md#blake3) for full documentation.

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

string context = "MyApp 2025-01-01 session key";
byte[] ikm = ...; // input key material

using var blake3 = Blake3.CreateDeriveKey(context);
Span<byte> derivedKey = stackalloc byte[32];
blake3.TryComputeHash(ikm, derivedKey, out _);
```

---

## KDF Selection Guide

### By Protocol

| Protocol | KDF | HMAC Variant | Notes |
|----------|-----|-------------|-------|
| TLS 1.3 | HKDF | SHA-256 or SHA-384 | RFC 8446 key schedule |
| HPKE | HKDF | SHA-256 | RFC 9180 labeled Extract/Expand |
| IKEv2 / IPsec | HKDF or KBKDF | SHA-256 or SHA-512 | RFC 7296 |
| Signal Protocol | HKDF | SHA-256 | Double Ratchet algorithm |
| WireGuard | HKDF / BLAKE3 | SHA-256 | Noise framework |
| SSH | HKDF | SHA-256 or SHA-512 | Key exchange |
| OPC UA | HKDF | SHA-256 | Secure channel key derivation |
| Microsoft CNG / DPAPI | KBKDF | SHA-256 or AES-CMAC | SP 800-108 Counter Mode |
| Kerberos | KBKDF | SHA-256 | Session key derivation |
| 802.11i / EAP | KBKDF | AES-CMAC | Key hierarchy derivation |

### By Use Case

| Use Case | Recommended | Alternative |
|----------|-------------|-------------|
| Extract + expand from shared secret | HKDF | — |
| Multiple keys from one secret | HKDF (Extract once, Expand many) | KBKDF (vary label) |
| Session key from master key | KBKDF | HKDF |
| Context-bound key derivation | HKDF with `info` or KBKDF with label/context | BLAKE3 DeriveKey |
| High-performance key derivation | BLAKE3 DeriveKey | HKDF |
| NIST compliance required | HKDF or KBKDF | — |
| Cross-platform SHA-3 KDF | HKDF with HMAC-SHA3-256 | — |
| CMAC-based PRF needed | KBKDF with AES-CMAC | — |

---

## KDF Roadmap

The following KDFs are commonly used with ECC, asymmetric encryption, and post-quantum cryptography. They are candidates for future implementation:

| KDF | Standard | Used With | Status |
|-----|----------|-----------|--------|
| HKDF | RFC 5869 | TLS 1.3, HPKE, Signal, WireGuard | ✅ Implemented |
| KBKDF Counter Mode | NIST SP 800-108r1 | CNG, DPAPI, IPsec, Kerberos | ✅ Implemented |
| BLAKE3 DeriveKey | BLAKE3 Spec | Custom protocols | ✅ Implemented |
| Concat KDF (One-Step) | NIST SP 800-56C | ECDH key agreement, JOSE/JWE | 🔲 Planned |
| X9.63 KDF | ANSI X9.63 / SEC 1 | Legacy ECC (IEEE P1363) | 🔲 Under review |
| PBKDF2 | RFC 8018 | Password-based key derivation | 🔲 Planned |

---

## Security Best Practices

### Key Material Handling

```csharp
// Clear sensitive key material after use
byte[] prk = Hkdf.Extract(factory, ikm, salt);
try
{
    byte[] derivedKey = Hkdf.Expand(factory, prk, 32, info);
    // Use derivedKey...
}
finally
{
    Array.Clear(prk, 0, prk.Length);
}
```

> **Note:** The span-based `DeriveKey` method automatically clears the intermediate PRK.

### Nonce/Salt Reuse

- **Salt reuse is acceptable** — HKDF tolerates salt reuse without security degradation (it merely reduces the security margin).
- **Info reuse is dangerous** — The same `(PRK, info)` pair always produces the same output. Use unique `info` values for each derived key.

### Domain Separation

Always include distinct `info` values to prevent key reuse across different contexts:

```csharp
// GOOD: Different info for different keys
byte[] encKey = Hkdf.Expand(factory, prk, 32, "enc"u8.ToArray());
byte[] macKey = Hkdf.Expand(factory, prk, 32, "mac"u8.ToArray());

// BAD: Same info reused — produces identical keys!
// byte[] key1 = Hkdf.Expand(factory, prk, 32, info);
// byte[] key2 = Hkdf.Expand(factory, prk, 32, info); // same as key1!
```

---

## See Also

- [MAC Algorithms](mac-algorithms.md) — HMAC variants used as the underlying PRF
- [Hash Algorithms](hash-algorithms.md) — BLAKE3 key derivation mode
- [Cipher Algorithms](cipher-algorithms.md) — Algorithms that consume derived keys
- [Cryptography Package Overview](index.md)
- [HMAC Test Vectors](specs/HMAC-vectors.md)

---

© 2026 The Keepers of the CryptoHives
