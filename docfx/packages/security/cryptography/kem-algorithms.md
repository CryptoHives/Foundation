# Key Encapsulation Mechanisms (KEM) Reference

This page provides detailed documentation for the Key Encapsulation Mechanisms (KEMs) implemented in the CryptoHives.Foundation.Security.Cryptography package.

## Namespace

```csharp
using CryptoHives.Foundation.Security.Cryptography.Kem;
```

---

## Overview

A Key Encapsulation Mechanism establishes a shared secret between two parties using public-key cryptography. The sender *encapsulates* a fresh shared secret against the receiver's public (encapsulation) key, producing a ciphertext; the receiver *decapsulates* the ciphertext with its private (decapsulation) key to recover the same secret. The shared secret is then typically fed into a KDF (e.g. [HKDF](kdf-algorithms.md#hkdf-hmac-based-extract-and-expand-kdf)) to derive symmetric keys.

| KEM | Source | Security Category | Primary Use |
|-----|--------|-------------------|-------------|
| [ML-KEM-512](#ml-kem-fips-203) | FIPS 203 | 1 (~AES-128) | Constrained environments |
| [ML-KEM-768](#ml-kem-fips-203) | FIPS 203 | 3 (~AES-192) | **Recommended default** |
| [ML-KEM-1024](#ml-kem-fips-203) | FIPS 203 | 5 (~AES-256) | Maximum security margin |

### Why Post-Quantum KEMs

ML-KEM (Module-Lattice-Based KEM, derived from CRYSTALS-Kyber) is the NIST-standardized post-quantum replacement for key establishment based on RSA or elliptic-curve Diffie-Hellman, which are broken by a cryptographically relevant quantum computer. Migration timelines (e.g. CNSA 2.0) require new systems to support quantum-resistant key establishment well before 2030.

This implementation is fully managed and runs identically on every target framework — including **.NET Framework 4.6.2 and .NET Standard 2.0**, where the in-box `System.Security.Cryptography.MLKem` (.NET 10+, OS-backed) is not available.

---

## ML-KEM (FIPS 203)

ML-KEM is specified in [FIPS 203](https://csrc.nist.gov/pubs/fips/203/final) (final, August 2024). It is an IND-CCA2-secure KEM built from the Module-LWE problem, combining the K-PKE public-key encryption scheme with the Fujisaki–Okamoto transform using implicit rejection.

### Parameters (FIPS 203 Table 1)

| Parameter | ML-KEM-512 | ML-KEM-768 | ML-KEM-1024 |
|-----------|-----------:|-----------:|------------:|
| Security category | 1 | 3 | 5 |
| Module rank k | 2 | 3 | 4 |
| η₁ / η₂ | 3 / 2 | 2 / 2 | 2 / 2 |
| d_u / d_v | 10 / 4 | 10 / 4 | 11 / 5 |
| Encapsulation key | 800 bytes | 1,184 bytes | 1,568 bytes |
| Decapsulation key (expanded) | 1,632 bytes | 2,400 bytes | 3,168 bytes |
| Private seed (d ‖ z) | 64 bytes | 64 bytes | 64 bytes |
| Ciphertext | 768 bytes | 1,088 bytes | 1,568 bytes |
| Shared secret | 32 bytes | 32 bytes | 32 bytes |

### Two API Levels

| API | Classes | Best For |
|-----|---------|----------|
| Key-holding (recommended) | `MlKem`, `MlKemAlgorithm` | Application code; mirrors .NET 10's `System.Security.Cryptography.MLKem` |
| Low-level, stateless | `IKem`, `MlKem512`, `MlKem768`, `MlKem1024` | Protocol implementations that manage raw key bytes; allocation-free span APIs |

### Key-Holding API (`MlKem`)

The `MlKem` class mirrors the .NET 10 `MLKem` API shape, so code written against the in-box type ports directly to older target frameworks:

```csharp
using CryptoHives.Foundation.Security.Cryptography.Kem;

// Receiver: generate a key pair and publish the encapsulation key.
using var receiver = MlKem.GenerateKey(MlKemAlgorithm.MlKem768);
byte[] encapsulationKey = receiver.ExportEncapsulationKey();

// Sender: encapsulate a shared secret for the receiver.
using var sender = MlKem.ImportEncapsulationKey(MlKemAlgorithm.MlKem768, encapsulationKey);
byte[] ciphertext   = new byte[sender.Algorithm.CiphertextSizeInBytes];
byte[] senderSecret = new byte[sender.Algorithm.SharedSecretSizeInBytes];
sender.Encapsulate(ciphertext, senderSecret);

// Receiver: recover the same shared secret.
byte[] receiverSecret = new byte[receiver.Algorithm.SharedSecretSizeInBytes];
receiver.Decapsulate(ciphertext, receiverSecret);
// senderSecret and receiverSecret are identical
```

#### Key Storage via Private Seed

FIPS 203 recommends storing the 64-byte private seed (d ‖ z) instead of the expanded decapsulation key. A key created from a seed can always be re-expanded deterministically:

```csharp
using var key = MlKem.GenerateKey(MlKemAlgorithm.MlKem768);
byte[] seed = key.ExportPrivateSeed(); // 64 bytes — store this

// Later / elsewhere:
using var restored = MlKem.ImportPrivateSeed(MlKemAlgorithm.MlKem768, seed);
// restored is byte-identical to the original key pair
```

Keys imported from an expanded decapsulation key (`ImportDecapsulationKey`) hold no seed; `ExportPrivateSeed` throws for them.

#### Methods

| Method | Description |
|--------|-------------|
| `GenerateKey(MlKemAlgorithm)` | Generate a fresh key pair (retains the private seed) |
| `ImportPrivateSeed(MlKemAlgorithm, ReadOnlySpan<byte>)` | Expand a 64-byte (d ‖ z) seed into a key pair |
| `ImportDecapsulationKey(MlKemAlgorithm, ReadOnlySpan<byte>)` | Import an expanded decapsulation key (runs the §7.3 hash check) |
| `ImportEncapsulationKey(MlKemAlgorithm, ReadOnlySpan<byte>)` | Import a public key (runs the §7.2 modulus check) |
| `Encapsulate(Span<byte>, Span<byte>)` | Produce ciphertext + shared secret |
| `Decapsulate(ReadOnlySpan<byte>, Span<byte>)` | Recover the shared secret (implicit rejection on invalid ciphertext) |
| `ExportPrivateSeed()` / `ExportPrivateSeed(Span<byte>)` | Export the 64-byte seed (seed-created keys only) |
| `ExportEncapsulationKey()` / `ExportEncapsulationKey(Span<byte>)` | Export the public key |
| `ExportDecapsulationKey()` / `ExportDecapsulationKey(Span<byte>)` | Export the expanded private key |
| `Dispose()` | Zeroize the private seed and decapsulation key |

### Low-Level API (`IKem`)

The stateless per-parameter-set classes operate directly on caller-provided buffers and never retain key material:

```csharp
using CryptoHives.Foundation.Security.Cryptography.Kem;

using var kem = MlKem768.Create();

// Key generation (random, or deterministic from a 64-byte seed)
byte[] ek = new byte[MlKem768.EncapsulationKeySizeBytesConst];   // 1184
byte[] dk = new byte[MlKem768.DecapsulationKeySizeBytesConst];   // 2400
kem.GenerateKeyPair(ek, dk);

// Encapsulation
byte[] ct  = new byte[MlKem768.CiphertextSizeBytesConst];        // 1088
byte[] ss1 = new byte[MlKem768.SharedSecretSizeBytesConst];      // 32
kem.Encapsulate(ek, ct, ss1);

// Decapsulation
byte[] ss2 = new byte[MlKem768.SharedSecretSizeBytesConst];
kem.Decapsulate(dk, ct, ss2);
```

Deterministic overloads (`GenerateKeyPair(seed, …)`, `Encapsulate(ek, seed, …)`) exist for test vectors and derived-key schemes; do **not** use fixed seeds in production.

---

## Security Properties

### FIPS 203 Input Checks

Both API levels validate externally supplied keys as required by FIPS 203 §7:

- **§7.2 encapsulation key check (modulus check)** — every 12-bit coefficient of the encoded key must be < q = 3329. Rejected keys throw (`ArgumentException` on the low-level API, `CryptographicException` on `MlKem` import).
- **§7.3 decapsulation key check (hash check)** — the stored H(ekPKE) must match a freshly computed hash of the embedded encapsulation key.

### Implicit Rejection

Decapsulating a tampered or invalid ciphertext of the correct length does **not** throw. Per FIPS 203, the result is a pseudorandom secret K̄ = J(z ‖ c) unrelated to the sender's secret, so an attacker learns nothing from the result. Protocols detect mismatch when the subsequently derived keys fail authentication.

### Constant-Time Implementation

- The ciphertext comparison in decapsulation uses a fixed-time comparison that yields an integer mask (never a `bool`), and the final secret selection is branchless.
- Reduction uses Barrett/Montgomery multiply-shift arithmetic; no secret-dependent division, branching, or table indexing.
- Rejection sampling (`SampleNTT`) branches only on public XOF output, as specified.

### Key Hygiene

- Secret intermediates (PRF output, secret/error polynomials, decrypted message, re-encryption buffer) are zeroed before scope exit.
- Fresh key pairs run a pairwise consistency test (encapsulate/decapsulate round-trip) as expected by FIPS 140-3.
- `MlKem.Dispose()` zeroizes the retained seed and decapsulation key.

---

## Validation

The implementation is validated on every target framework by three independent means (see [ML-KEM Test Vectors](specs/ML-KEM-vectors.md) for details):

1. **NIST ACVP known-answer tests** — official vectors from the [NIST ACVP-Server](https://github.com/usnistgov/ACVP-Server) for key generation, encapsulation, decapsulation (including byte-exact implicit-rejection outputs), and both §7 key checks, for all three parameter sets.
2. **BouncyCastle interop** — same-seed key generation produces byte-identical expanded keys; encapsulation/decapsulation round-trips in both directions; implicit-rejection outputs match byte-for-byte.
3. **.NET 10 `MLKem` interop** (on supported OS builds) — same-seed keys match the Windows CNG implementation byte-for-byte; cross-encapsulation and implicit rejection agree in both directions.

---

## Comparison with .NET Built-in

| Feature | CryptoHives `MlKem` | `System.Security.Cryptography.MLKem` |
|---------|--------------------|--------------------------------------|
| Availability | All TFMs (.NET Framework 4.6.2+) | .NET 10+ only |
| OS requirement | None (fully managed) | Windows CNG (recent builds) / OpenSSL 3.5+ |
| Cross-platform consistency | Guaranteed | Depends on OS support |
| Parameter sets | ML-KEM-512/768/1024 | ML-KEM-512/768/1024 |
| Private seed import/export | ✅ | ✅ |
| §7.2 / §7.3 import checks | ✅ | ✅ |
| PKCS#8 / SPKI / PEM | 🔲 Planned (with X.509 support) | ✅ |
| API shape | Mirrors `MLKem` | — |

---

## KEM Roadmap

| Algorithm | Standard | Status |
|-----------|----------|--------|
| ML-KEM-512/768/1024 | FIPS 203 | ✅ Implemented |
| ML-DSA (signatures) | FIPS 204 | 🔲 Planned |
| HPKE | RFC 9180 | 🔲 Under review |
| X-Wing (hybrid X25519 + ML-KEM-768) | draft-connolly-cfrg-xwing-kem | 🔲 Under review |
| PKCS#8 / SPKI key formats | RFC 5208 / RFC 5280 | 🔲 Planned with X.509 support |

---

## See Also

- [KDF Algorithms](kdf-algorithms.md) — derive symmetric keys from the shared secret
- [Cipher Algorithms](cipher-algorithms.md) — AEAD ciphers that consume derived keys
- [FIPS 203 Reference](specs/NIST-FIPS-203.md)
- [ML-KEM Test Vectors](specs/ML-KEM-vectors.md)
- [Cryptography Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
