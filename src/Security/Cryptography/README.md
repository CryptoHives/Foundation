## CryptoHives Open Source Initiative 🐝

An open, community-driven collection of cryptography and performance libraries for the .NET ecosystem, maintained by **The Keepers of the CryptoHives**.

---

## CryptoHives.Foundation.Security.Cryptography

[![NuGet](https://img.shields.io/nuget/v/CryptoHives.Foundation.Security.Cryptography.svg)](https://www.nuget.org/packages/CryptoHives.Foundation.Security.Cryptography)
[![Tests](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml/badge.svg)](https://github.com/CryptoHives/Foundation/actions/workflows/buildandtest.yml)

Fully managed, OS-independent implementations of hash, MAC, KDF, cipher, and post-quantum KEM and signature algorithms for .NET, written directly from NIST/RFC/ISO specifications and checked against official test vectors.

No OS crypto dependency means deterministic results on every platform. Where the hardware supports it, AES-NI, PCLMULQDQ, VPCLMULQDQ, SSE2, SSSE3, and AVX2 intrinsics are used automatically.

---

## Installation

```bash
dotnet add package CryptoHives.Foundation.Security.Cryptography
```

---

## Key Features

- **OS-independent** — identical results on Windows, Linux, macOS, and anywhere else .NET runs
- **Standards-based** — implemented from NIST, RFC, and ISO specifications; validated against official test vectors
- **Hardware-accelerated** — automatic AES-NI, AVX2, SSSE3 dispatch, with a scalar fallback always available
- **Allocation-free hot paths** — `Span<byte>`-based APIs, friendly to `stackalloc`
- **XOF streaming** — `IExtendableOutput` (`Absorb` / `Squeeze` / `Reset`) on all XOF algorithms
- **`HashAlgorithm` compatible** — drop-in for anything consuming `System.Security.Cryptography.HashAlgorithm`
- **Broad algorithm coverage** — SHA-2/3, Keccak, SHAKE, BLAKE2/3, Ascon, regional ciphers, and more

---

## Supported Algorithms

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
| Legacy | SHA-1, MD5, HMAC-SHA-1, HMAC-MD5 (backward compatibility only) |
| MAC | HMAC-SHA-256/384/512, HMAC-SHA3-256/384/512, AES-CMAC, AES-GMAC, Poly1305, KMAC128/256, BLAKE2/3 keyed |
| Cipher (AEAD) | AES-GCM (128/192/256), AES-CCM (128/192/256), ChaCha20-Poly1305, XChaCha20-Poly1305, Ascon-AEAD128 |
| Cipher (block/stream) | AES-128/192/256 (ECB/CBC/CTR), ChaCha20 |
| Cipher (regional) | SM4, ARIA, Camellia, Kuznyechik, Kalyna (128/256/512), SEED |
| KDF | HKDF, KBKDF, ConcatKDF, PBKDF2 |
| Post-quantum KEM | ML-KEM-512, ML-KEM-768, ML-KEM-1024 (FIPS 203) |
| Post-quantum signatures | ML-DSA-44, ML-DSA-65, ML-DSA-87 (FIPS 204) |

---

## Quick Examples

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

// Decrypt — returns false (and clears `recovered`) if tag verification fails;
// it does not throw. Always check the result before trusting the output.
Span<byte> recovered = new byte[ciphertext.Length];
if (!aesGcm.Decrypt(nonce, ciphertext, tag, recovered, associatedData))
{
    throw new CryptographicException("Authentication failed.");
}
```

### Post-Quantum Key Encapsulation (`ML-KEM`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Kem;

// The API mirrors System.Security.Cryptography.MLKem from .NET 10,
// but runs fully managed on every target framework down to net462.
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
```

Keys are validated on import per FIPS 203 §7.2/§7.3, decapsulation uses constant-time
implicit rejection, and all three parameter sets are verified against the official
NIST ACVP test vectors plus BouncyCastle and .NET 10 `MLKem` interop tests.

### Post-Quantum Signatures (`ML-DSA`)

```csharp
using CryptoHives.Foundation.Security.Cryptography.Dsa;

// The API mirrors System.Security.Cryptography.MLDsa from .NET 10,
// but runs fully managed on every target framework down to net462.
using var signer = MlDsa.GenerateKey(MlDsaAlgorithm.MlDsa65);
byte[] publicKey = signer.ExportPublicKey();
byte[] signature = signer.SignData(message);

// Verifier:
using var verifier = MlDsa.ImportPublicKey(MlDsaAlgorithm.MlDsa65, publicKey);
bool valid = verifier.VerifyData(message, signature);
```

Hedged signing per FIPS 204 with optional context strings and deterministic variant;
all three parameter sets are verified against the official NIST ACVP test vectors
(byte-exact signatures) plus BouncyCastle and .NET 10 `MLDsa` interop tests.

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

## Documentation

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

## Security Policy

Every algorithm is implemented from its published specification and validated against official test vectors. Public APIs are designed assuming hostile input.

If you discover a vulnerability, please don't open a public issue — follow the process on the [CryptoHives Security Page](https://github.com/CryptoHives/.github/blob/main/SECURITY.md) instead.

---

## License

MIT — © 2026 The Keepers of the CryptoHives
