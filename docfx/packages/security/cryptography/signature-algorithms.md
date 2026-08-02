# Digital Signature Algorithms Reference

This page provides detailed documentation for the digital signature algorithms implemented in the CryptoHives.Foundation.Security.Cryptography package.

## Namespace

```csharp
using CryptoHives.Foundation.Security.Cryptography.Dsa;
```

---

## Overview

| Algorithm | Source | Security Category | Primary Use |
|-----------|--------|-------------------|-------------|
| [ML-DSA-44](#ml-dsa-fips-204) | FIPS 204 | 2 | Constrained environments, high signing volume |
| [ML-DSA-65](#ml-dsa-fips-204) | FIPS 204 | 3 | **Recommended default** |
| [ML-DSA-87](#ml-dsa-fips-204) | FIPS 204 | 5 | Maximum security margin |

### Why Post-Quantum Signatures

ML-DSA (Module-Lattice-Based Digital Signature Algorithm, derived from CRYSTALS-Dilithium) is the NIST-standardized post-quantum replacement for RSA and ECDSA signatures, which are broken by a cryptographically relevant quantum computer. Together with [ML-KEM](kem-algorithms.md) it forms the complete CNSA 2.0 key-establishment + signature pair. Signatures dominate real-world PQC demand: code signing, firmware updates, certificates, and document signing all need them.

This implementation is fully managed and runs identically on every target framework — including **.NET Framework 4.6.2 and .NET Standard 2.0**, where the in-box `System.Security.Cryptography.MLDsa` (.NET 10+, OS-backed) is not available.

---

## ML-DSA (FIPS 204)

ML-DSA is specified in [FIPS 204](https://csrc.nist.gov/pubs/fips/204/final) (final, August 2024). It is a Fiat–Shamir-with-aborts signature scheme over module lattices, strongly unforgeable under chosen-message attack.

### Parameters (FIPS 204 Table 1)

| Parameter | ML-DSA-44 | ML-DSA-65 | ML-DSA-87 |
|-----------|----------:|----------:|----------:|
| Security category | 2 | 3 | 5 |
| Matrix dimensions (k × ℓ) | 4 × 4 | 6 × 5 | 8 × 7 |
| η / τ / γ₁ | 2 / 39 / 2¹⁷ | 4 / 49 / 2¹⁹ | 2 / 60 / 2¹⁹ |
| Public key | 1,312 bytes | 1,952 bytes | 2,592 bytes |
| Secret key (expanded) | 2,560 bytes | 4,032 bytes | 4,896 bytes |
| Private seed ξ | 32 bytes | 32 bytes | 32 bytes |
| Signature | 2,420 bytes | 3,309 bytes | 4,627 bytes |

### Two API Levels

| API | Classes | Best For |
|-----|---------|----------|
| Key-holding (recommended) | `MlDsa`, `MlDsaAlgorithm` | Application code; mirrors .NET 10's `System.Security.Cryptography.MLDsa` |
| Low-level, stateless | `IDsa`, `MlDsa44`, `MlDsa65`, `MlDsa87` | Protocol implementations managing raw key bytes; allocation-conscious span APIs |

### Key-Holding API (`MlDsa`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Dsa;

// Signer: generate a key pair and publish the public key.
using var signer = MlDsa.GenerateKey(MlDsaAlgorithm.MlDsa65);
byte[] publicKey = signer.ExportPublicKey();

byte[] signature = signer.SignData(message);

// Verifier:
using var verifier = MlDsa.ImportPublicKey(MlDsaAlgorithm.MlDsa65, publicKey);
bool valid = verifier.VerifyData(message, signature);
```

#### Context Strings

FIPS 204 binds signatures to an optional context string (≤ 255 bytes) for domain separation. A signature created with a context only verifies with the same context:

```csharp
byte[] signature = signer.SignData(message, "MyApp/v1"u8);
bool valid = verifier.VerifyData(message, signature, "MyApp/v1"u8);
```

#### Key Storage via Private Seed

The 32-byte seed ξ is the compact private-key form; a key created from a seed re-expands deterministically:

```csharp
using var key = MlDsa.GenerateKey(MlDsaAlgorithm.MlDsa65);
byte[] seed = key.ExportPrivateSeed(); // 32 bytes — store this

using var restored = MlDsa.ImportPrivateSeed(MlDsaAlgorithm.MlDsa65, seed);
// restored is byte-identical to the original key pair
```

Keys imported from an expanded secret key (`ImportSecretKey`) hold no seed; on import the
public key is reconstructed from (ρ, s1, s2) and validated against the embedded hash
tr = H(pk) — a corrupted key is rejected with a `CryptographicException`.

#### Methods

| Method | Description |
|--------|-------------|
| `GenerateKey(MlDsaAlgorithm)` | Generate a fresh key pair (retains the private seed) |
| `ImportPrivateSeed(MlDsaAlgorithm, ReadOnlySpan<byte>)` | Expand a 32-byte seed ξ into a key pair |
| `ImportSecretKey(MlDsaAlgorithm, ReadOnlySpan<byte>)` | Import an expanded secret key (reconstructs and validates the public key) |
| `ImportPublicKey(MlDsaAlgorithm, ReadOnlySpan<byte>)` | Import a public key (verify-only instance) |
| `SignData(data, context)` / `SignData(data, destination, context)` | Hedged (randomized) signing |
| `VerifyData(data, signature, context)` | Verification; wrong-length signatures return false |
| `ExportPrivateSeed()` / `ExportPublicKey()` / `ExportSecretKey()` | Key export (span overloads available) |
| `Dispose()` | Zeroize the private seed and secret key |

### Low-Level API (`IDsa`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Dsa;

using var dsa = MlDsa65.Create();

byte[] pk = new byte[MlDsa65.PublicKeySizeBytesConst];   // 1952
byte[] sk = new byte[MlDsa65.SecretKeySizeBytesConst];   // 4032
dsa.GenerateKeyPair(pk, sk);

byte[] signature = new byte[MlDsa65.SignatureSizeBytesConst]; // 3309
dsa.Sign(sk, message, context: default, signature);

bool valid = dsa.Verify(pk, message, context: default, signature);
```

`SignDeterministic` implements the deterministic variant (rnd = 0³²) for reproducibility
requirements and known-answer testing; the hedged `Sign` is the FIPS 204 default and
should be preferred because it protects against fault attacks and randomness reuse.
Deterministic key generation from a seed (`GenerateKeyPair(seed, …)`) exists for test
vectors and derived-key schemes.

---

## Security Properties

- **Hedged signing by default** — each signature mixes fresh randomness into ρ″ per FIPS 204 Algorithm 2.
- **Strong unforgeability** — the hint encoding is strictly validated on decode (positions strictly increasing, counts consistent, padding zero); malformed signatures are rejected before any arithmetic.
- **Constant-time discipline** — infinity-norm checks on secret-dependent vectors scan all coefficients without early exit; the rejection-loop restart itself is spec-sanctioned to be observable. Rounding uses branch-free multiply-shift arithmetic.
- **Key hygiene** — per-iteration secrets (y, rejected z candidates, c·s products) and decoded key material are zeroed; fresh key pairs run a sign/verify pairwise consistency test (FIPS 140-3); `MlDsa.Dispose()` zeroizes retained key material.

---

## Validation

The implementation is validated on every target framework by three independent means (see [ML-DSA Test Vectors](specs/ML-DSA-vectors.md)):

1. **NIST ACVP known-answer tests** — official vectors for keyGen (seed → byte-exact keys), sigGen (byte-exact signatures for both deterministic and hedged signing, the latter with injected ACVP randomness), and sigVer including modified-commitment/z/hint/message rejection cases — all parameter sets, pure ML-DSA, external interface.
2. **BouncyCastle interop** — same-seed key generation produces byte-identical keys; deterministic signatures match byte-for-byte; hedged sign/verify round-trips in both directions.
3. **.NET 10 `MLDsa` interop** (on supported OS builds) — same-seed keys match the Windows CNG implementation byte-for-byte; cross sign/verify in both directions including context binding.

---

## Comparison with .NET Built-in

| Feature | CryptoHives `MlDsa` | `System.Security.Cryptography.MLDsa` |
|---------|--------------------|--------------------------------------|
| Availability | All TFMs (.NET Framework 4.6.2+) | .NET 10+ only |
| OS requirement | None (fully managed) | Windows CNG (recent builds) / OpenSSL 3.5+ |
| Parameter sets | ML-DSA-44/65/87 | ML-DSA-44/65/87 |
| Private seed import/export | ✅ | ✅ |
| Context strings | ✅ | ✅ |
| Deterministic signing | ✅ (`IDsa.SignDeterministic`) | ❌ |
| HashML-DSA (pre-hash) | 🔲 Planned | ✅ |
| PKCS#8 / SPKI / PEM | 🔲 Planned (with X.509 support) | ✅ |

---

## Signature Roadmap

| Algorithm | Standard | Status |
|-----------|----------|--------|
| ML-DSA-44/65/87 (pure) | FIPS 204 | ✅ Implemented |
| HashML-DSA (pre-hash variants) | FIPS 204 §5.4 | 🔲 Planned |
| SLH-DSA (stateless hash-based) | FIPS 205 | 🔲 Planned |
| Ed25519 | RFC 8032 | 🔲 Under review |
| PKCS#8 / SPKI key formats | RFC 5208 / RFC 5280 | 🔲 Planned with X.509 support |

---

## See Also

- [KEM Algorithms](kem-algorithms.md) — ML-KEM, the key-establishment half of the PQC pair
- [Hash Algorithms](hash-algorithms.md) — the SHAKE128/256 XOFs underlying ML-DSA
- [FIPS 204 Reference](specs/NIST-FIPS-204.md)
- [ML-DSA Test Vectors](specs/ML-DSA-vectors.md)
- [Cryptography Package Overview](index.md)

---

© 2026 The Keepers of the CryptoHives
