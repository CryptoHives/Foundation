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
| Key-holding (recommended) | `MLDsa`, `MLDsaAlgorithm` | Application code; mirrors .NET 10's `System.Security.Cryptography.MLDsa` |
| Low-level, stateless | `IDsa`, `MLDsa44`, `MLDsa65`, `MLDsa87` | Protocol implementations managing raw key bytes; allocation-conscious span APIs |

### Key-Holding API (`MLDsa`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Dsa;

// Signer: generate a key pair and publish the public key.
using var signer = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa65);
byte[] publicKey = signer.ExportMLDsaPublicKey();

byte[] signature = signer.SignData(message);

// Verifier:
using var verifier = MLDsa.ImportMLDsaPublicKey(MLDsaAlgorithm.MLDsa65, publicKey);
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
using var key = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa65);
byte[] seed = key.ExportMLDsaPrivateSeed(); // 32 bytes — store this

using var restored = MLDsa.ImportMLDsaPrivateSeed(MLDsaAlgorithm.MLDsa65, seed);
// restored is byte-identical to the original key pair
```

Keys imported from an expanded private key (`ImportMLDsaPrivateKey`) hold no seed; on import the
public key is reconstructed from (ρ, s1, s2) and validated against the embedded hash
tr = H(pk) — a corrupted key is rejected with a `CryptographicException`.

#### Methods

The member names match `System.Security.Cryptography.MLDsa` exactly, so porting code
between the two is a `using` swap.

| Method | Description |
|--------|-------------|
| `IsSupported` | Always `true` — see [Comparison with .NET Built-in](#comparison-with-net-built-in) |
| `GenerateKey(MLDsaAlgorithm)` | Generate a fresh key pair (retains the private seed) |
| `ImportMLDsaPrivateSeed(MLDsaAlgorithm, ReadOnlySpan<byte>)` | Expand a 32-byte seed ξ into a key pair |
| `ImportMLDsaPrivateKey(MLDsaAlgorithm, ReadOnlySpan<byte>)` | Import an expanded private key (reconstructs and validates the public key) |
| `ImportMLDsaPublicKey(MLDsaAlgorithm, ReadOnlySpan<byte>)` | Import a public key (verify-only instance) |
| `SignData(data, context)` / `SignData(data, destination, context)` | Hedged (randomized) signing |
| `VerifyData(data, signature, context)` | Verification; wrong-length signatures return false |
| `ExportMLDsaPrivateSeed()` / `ExportMLDsaPublicKey()` / `ExportMLDsaPrivateKey()` | Key export (span overloads available) |
| `Dispose()` | Zeroize the private seed and private key |

Every import takes a `byte[]` as well as a `ReadOnlySpan<byte>`, and `SignData`/`VerifyData`
have the `byte[]`-based overloads the in-box type provides.

#### Pairwise Consistency Test

Key generation runs a sign/verify round trip on the fresh key pair, as FIPS 140-3 IG 10.3.A
expects of a validated module. It is the dominant cost of key generation, because a sign is
itself a rejection loop that runs several iterations on average. `GenerateKey` and
`ImportMLDsaPrivateSeed` take an optional `pairwiseConsistencyTest` argument to skip it:

```csharp
using var key = MLDsa.ImportMLDsaPrivateSeed(
    MLDsaAlgorithm.MLDsa65, seed, pairwiseConsistencyTest: false);
```

The test guards against a *fault* — bad memory, a bit flip, a miscompiled build — producing a
key pair that does not round-trip. It cannot catch an implementation bug, since both halves of
the test would be wrong in the same way. Disable it only where that trade is understood and key
generation throughput actually matters. Skipping it never changes the key that is produced: the
test message is derived from the seed, so expanding a stored seed stays fully deterministic and
draws no entropy from the OS.

### Low-Level API (`IDsa`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Dsa;

using var dsa = MLDsa65.Create();

byte[] pk = new byte[MLDsa65.PublicKeySizeBytesConst];   // 1952
byte[] sk = new byte[MLDsa65.SecretKeySizeBytesConst];   // 4032
dsa.GenerateKeyPair(pk, sk);

byte[] signature = new byte[MLDsa65.SignatureSizeBytesConst]; // 3309
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
- **Key hygiene** — per-iteration secrets (y, rejected z candidates, c·s products) and decoded key material are zeroed; fresh key pairs run a sign/verify pairwise consistency test (FIPS 140-3); `MLDsa.Dispose()` zeroizes retained key material.

---

## Validation

The implementation is validated on every target framework by three independent means (see [ML-DSA Test Vectors](specs/ML-DSA-vectors.md)):

1. **NIST ACVP known-answer tests** — official vectors for keyGen (seed → byte-exact keys), sigGen (byte-exact signatures for both deterministic and hedged signing, the latter with injected ACVP randomness), and sigVer including modified-commitment/z/hint/message rejection cases — all parameter sets, pure ML-DSA, external interface.
2. **BouncyCastle interop** — same-seed key generation produces byte-identical keys; deterministic signatures match byte-for-byte; hedged sign/verify round-trips in both directions.
3. **.NET 10 `MLDsa` interop** (on supported OS builds) — same-seed keys match the Windows CNG implementation byte-for-byte; cross sign/verify in both directions including context binding.

---

## Comparison with .NET Built-in

| Feature | CryptoHives `MLDsa` | `System.Security.Cryptography.MLDsa` |
|---------|--------------------|--------------------------------------|
| Availability | All TFMs (.NET Framework 4.6.2+) | .NET 10+ only |
| OS requirement | None (fully managed) | Windows CNG (recent builds) / OpenSSL 3.5+ |
| `IsSupported` | Always `true` | Depends on the OS build |
| Member names | Identical — porting is a `using` swap | — |
| Parameter sets | ML-DSA-44/65/87 | ML-DSA-44/65/87 |
| Private seed import/export | ✅ | ✅ |
| Context strings | ✅ | ✅ |
| Deterministic signing | ✅ (`IDsa.SignDeterministic`) | ❌ |
| Pairwise consistency test opt-out | ✅ | ❌ |
| HashML-DSA (pre-hash) | 🔲 Planned | ✅ |
| External-μ signing (`SignMu`/`VerifyMu`) | 🔲 Planned | ✅ |
| PKCS#8 / SPKI / PEM | 🔲 Planned (with X.509 support) | ✅ |

The deferred rows are held back deliberately: pre-hash, external-μ signing and the ASN.1 key
formats land as one batch once the post-quantum algorithm set is complete, so ML-KEM and ML-DSA
gain them together.

---

## Signature Roadmap

| Algorithm | Standard | Status |
|-----------|----------|--------|
| ML-DSA-44/65/87 (pure) | FIPS 204 | ✅ Implemented |
| HashML-DSA (pre-hash variants) | FIPS 204 §5.4 | 🔲 Planned |
| External-μ signing (`SignMu`/`VerifyMu`) | FIPS 204 §6.2 | 🔲 Planned |
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
