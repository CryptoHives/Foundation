## 🛡️ CryptoHives Open Source Initiative 🐝

An open, community-driven cryptography and performance library collection for the .NET ecosystem,
developed and maintained by **The Keepers of the CryptoHives**.

---

## CryptoHives.Foundation.Security.Cryptography

[![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Security.Cryptography.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Security.Cryptography)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)

Fully managed, OS-independent implementations of cryptographic hash, MAC, KDF, and cipher algorithms for .NET —
written from NIST/RFC/ISO specifications and verified against official test vectors.

No OS crypto dependency — deterministic results on every platform. Hardware acceleration via AES-NI, PCLMULQDQ, VPCLMULQDQ, SSE2, SSSE3, and AVX2 intrinsics is automatically enabled on supported hardware.

---

## 📦 Installation

```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

---

## ✨ Key Features

- **OS-independent** — identical results on Windows, Linux, macOS, and any .NET-supported platform
- **Standards-based** — implemented from NIST, RFC, and ISO specifications; validated against official test vectors
- **Hardware-accelerated** — automatic AES-NI, AVX2, SSSE3 dispatch; scalar fallback always available
- **Allocation-free hot paths** — `Span<byte>`-based APIs, `stackalloc`-friendly
- **XOF streaming** — `IExtendableOutput` interface (`Absorb` / `Squeeze` / `Reset`) on all XOF algorithms
- **`HashAlgorithm` compatible** — drop-in for any existing `System.Security.Cryptography.HashAlgorithm` consumer
- **Comprehensive algorithm coverage** — SHA-2/3, Keccak, SHAKE, BLAKE2/3, Ascon, regional ciphers, and more

---

## 🔐 Supported Algorithms

| Family | Algorithms |
|--------|-----------|
| SHA-2 | SHA-224, SHA-256, SHA-384, SHA-512, SHA-512/224, SHA-512/256 |
| SHA-3 | SHA3-224, SHA3-256, SHA3-384, SHA3-512 |
| Keccak | Keccak-256, Keccak-384, Keccak-512 (Ethereum-compatible) |
| SHAKE / cSHAKE | SHAKE128, SHAKE256, cSHAKE128, cSHAKE256 |
| TurboSHAKE / KT | TurboSHAKE128, TurboSHAKE256, KT128, KT256 |
| ParallelHash (SP 800-185) | ParallelHash128, ParallelHash256 |
| BLAKE | BLAKE2b, BLAKE2s (SIMD-accelerated), BLAKE3 |
| Ascon | Ascon-Hash256, Ascon-XOF128 (NIST SP 800-232 lightweight) |
| Regional hash | SM3, Streebog, Kupyna, LSH, Whirlpool, RIPEMD-160 |
| Legacy | SHA-1, MD5 (backward compatibility only) |
| MAC | HMAC-SHA-256/384/512, HMAC-SHA3-256, AES-CMAC, AES-GMAC, Poly1305, KMAC128/256, BLAKE2/3 keyed |
| Cipher (AEAD) | AES-GCM (128/192/256), AES-CCM (128/192/256), ChaCha20-Poly1305, XChaCha20-Poly1305, Ascon-AEAD128 |
| Cipher (block/stream) | AES-128/192/256 (ECB/CBC/CTR), ChaCha20 |
| Cipher (regional) | SM4, ARIA, Camellia, Kuznyechik, Kalyna, SEED |
| KDF | HKDF, KBKDF, ConcatKDF, PBKDF2 |

---

## 🚀 Quick Examples

### Allocation-Free Hash (`Blake3`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

using var blake3 = Blake3.Create();
Span<byte> hash = stackalloc byte[32];
blake3.TryComputeHash(data, hash, out _);
```

### XOF Streaming (`Shake256`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

// Variable-length output via IExtendableOutput
using var shake = Shake256.Create(outputLength: 64);
shake.Absorb(context);
shake.Absorb(message);

Span<byte> output = stackalloc byte[64];
shake.Squeeze(output);
shake.Reset(); // Reuse the instance
```

### Keyed Hash / MAC (`HMAC-SHA-256`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Mac;

using var hmac = new HmacSha256(key);
Span<byte> tag = stackalloc byte[32];
hmac.TryComputeHash(message, tag, out _);
```

### Authenticated Encryption (`AES-GCM`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Cipher;

using var aesGcm = new AesGcm256(key);

// Encrypt
Span<byte> ciphertext = new byte[plaintext.Length];
Span<byte> tag        = stackalloc byte[16];
aesGcm.Encrypt(nonce, plaintext, ciphertext, tag, associatedData);

// Decrypt — throws if tag verification fails
Span<byte> recovered = new byte[ciphertext.Length];
aesGcm.Decrypt(nonce, ciphertext, tag, recovered, associatedData);
```

### cSHAKE — Domain-Separated XOF

```csharp
using CryptoHives.Foundation.Security.Cryptography.Hash;

using var cshake = CShake128.Create(
    functionName: "MyApp"u8,
    customization: "v1"u8,
    outputLength: 32);

cshake.Absorb(input);
Span<byte> derived = stackalloc byte[32];
cshake.Squeeze(derived);
```

---

## 📚 Documentation

| Resource | Link |
|----------|------|
| Full package documentation | [cryptohives.github.io/Foundation/packages/security/cryptography](https://cryptohives.github.io/Foundation/packages/security/cryptography/index.html) |
| Hash algorithms guide | [cryptohives.github.io/…/hash-algorithms](https://cryptohives.github.io/Foundation/packages/security/cryptography/hash-algorithms.html) |
| Cipher algorithms guide | [cryptohives.github.io/…/cipher-algorithms](https://cryptohives.github.io/Foundation/packages/security/cryptography/cipher-algorithms.html) |
| XOF mode guide | [cryptohives.github.io/…/xof-mode](https://cryptohives.github.io/Foundation/packages/security/cryptography/xof-mode.html) |
| Hash benchmarks | [cryptohives.github.io/…/benchmarks-hash](https://cryptohives.github.io/Foundation/packages/security/cryptography/benchmarks-hash.html) |
| Cipher benchmarks | [cryptohives.github.io/…/benchmarks-cipher](https://cryptohives.github.io/Foundation/packages/security/cryptography/benchmarks-cipher.html) |
| API reference | [cryptohives.github.io/Foundation/api](https://cryptohives.github.io/Foundation/api/index.html) |
| Source repository | [github.com/CryptoHives/Foundation](https://github.com/CryptoHives/Foundation) |

---

## 🔐 Security Policy

Standards-based implementations, validated against official test vectors. Threat-modeled by design — all public APIs assume hostile input.

If you discover a vulnerability, **please do not open a public issue.**
Follow the guidelines on the [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md).

---

## ⚖️ License

MIT — © 2026 The Keepers of the CryptoHives
