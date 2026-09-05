# CryptoHives.Foundation.Security.Cryptography — Guide for LLM Agents

Machine-readable usage + porting guide for coding assistants. All APIs below are verified
against the shipped source. Do not invent members. Human-oriented docs live in `README.md`.

- **Package:** `CryptoHives.Foundation.Security.Cryptography` (0.x — the API is pre-1.0
  and may still change between minor versions)
- **Root namespace:** `CryptoHives.Foundation.Security.Cryptography` with sub-namespaces
  `.Hash`, `.Mac`, `.Kdf`, `.Cipher`, `.Kem`
- **What it is:** fully managed, deterministic, cross-platform implementations of hashes,
  MACs, KDFs, ciphers, and post-quantum KEMs. Hash and cipher types **extend the
  `System.Security.Cryptography` base types**, and `.Kem` **mirrors their names and
  signatures**, so they are drop-in where those are expected.
  Hardware intrinsics (AES-NI, ARM Crypto, AVX2, NEON, SSE/SSSE3) are used for performance
  where available but are never required for correctness.

Use these to replace BouncyCastle / third-party crypto, or the BCL types, when you need
managed determinism across all target frameworks (including legacy TFMs where the BCL lacks
e.g. SHA-3, KMAC, or Ascon).

> **Never change cryptographic parameters during a port.** Swap the *implementation type*
> only — do not alter algorithm, key size, nonce/IV handling, digest length, or padding. If
> the source uses a weak algorithm (MD5/SHA-1), keep it (the equivalent type exists) and
> flag it; do not silently "upgrade".

---

## Hashing — `…Hash`

`using CryptoHives.Foundation.Security.Cryptography.Hash;`

Concrete types extend `System.Security.Cryptography.HashAlgorithm` and add pooled static
one-shot helpers:

```csharp
byte[] digest = SHA256.HashData(data);                          // ReadOnlySpan<byte> or ReadOnlySequence<byte>
bool ok       = SHA256.TryHashData(data, dest, out int written);

using var sha = SHA256.Create();                                // streaming / incremental
sha.AppendData(chunk1); sha.AppendData(chunk2);
sha.TryGetHashAndReset(dest, out int n);
```

Prefer the static `HashData`/`TryHashData` for one-shot cases (allocation-light, accept
`ReadOnlySequence<byte>` — pairs with `ArrayPoolBufferWriter.GetReadOnlySequence()`).

**Available types (use the exact class name):**
- SHA-2: `SHA224` `SHA256` `SHA384` `SHA512` `SHA512_224` `SHA512_256`
- SHA-3 (FIPS 202): `SHA3_224` `SHA3_256` `SHA3_384` `SHA3_512`
- Keccak (original padding): `Keccak256` `Keccak384` `Keccak512`
- XOF: `Shake128` `Shake256` `CShake128` `CShake256` `TurboShake128` `TurboShake256` `KT128` `KT256`
- BLAKE: `Blake2b` `Blake2s` `Blake3`
- Legacy (kept for compat): `SHA1` `MD5` `Ripemd160`
- Regional/other: `SM3` `Whirlpool` `Kupyna` `Streebog` `Lsh256` `Lsh512` `AsconHash256` `AsconXof128`
- Parallel: `ParallelHash` `IncrementalParallelHash`

**XOF (extendable output)** — `Shake*`, `CShake*`, `TurboShake*`, `KT*`, `Blake3`,
`AsconXof128` implement `IExtendableOutput`:
```csharp
void Absorb(ReadOnlySpan<byte> input);   // absorb ALL input first
void Squeeze(Span<byte> output);         // then squeeze arbitrary length (repeatable)
void Reset();
// After the first Squeeze the state is finalized — no more Absorb.
```

`HashAlgorithm.Create(string hashName, bool osVersion = false)` selects the managed
implementation (default) or the OS one (`osVersion: true`) for algorithms the BCL supports.

---

## MAC — `…Mac`

`using CryptoHives.Foundation.Security.Cryptography.Mac;`

Common streaming interface:
```csharp
interface IMac : IDisposable {
    string AlgorithmName { get; }
    int MacSize { get; }
    void Update(ReadOnlySpan<byte> input);
    void Finalize(Span<byte> destination);   // destination >= MacSize
    void Reset();                             // reuse with same key
}
```

HMAC types (`HmacSha256`, `HmacSha1`, `HmacMd5`, `HmacSha384`, `HmacSha512`,
`HmacSha3_256/384/512`) expose:
```csharp
static HmacSha256 Create(byte[] key);
static byte[] Hash(byte[] key, byte[] data);   // one-shot
```

KMAC: `KMac128` / `KMac256`:
```csharp
static KMac128 Create(byte[] key, int outputBytes = 32, string? customization = null);
```
Also available: `AesCmac`, `AesGmac`, `Poly1305Mac`.

---

## KDF — `…Kdf`

`using CryptoHives.Foundation.Security.Cryptography.Kdf;`

KDFs are static classes and take an `HmacFactory` delegate
(`delegate IMac HmacFactory(byte[] key)`), so you choose the underlying PRF explicitly:

```csharp
using CryptoHives.Foundation.Security.Cryptography.Mac;

byte[] okm = Hkdf.DeriveKey(
    key => HmacSha256.Create(key), ikm, outputLength: 32, salt: salt, info: info);
// Also: Hkdf.Extract(factory, ikm, salt) / Hkdf.Expand(factory, prk, outputLength, info)

byte[] dk = Pbkdf2.DeriveKey(
    key => HmacSha256.Create(key), password, salt, iterations, outputLength /* or Span dest */);
```
Also available: `Kbkdf`, `ConcatKdf`.

---

## Cipher — `…Cipher`

`using CryptoHives.Foundation.Security.Cryptography.Cipher;`

**AEAD** implements `IAeadCipher`:
```csharp
interface IAeadCipher : IDisposable {
    int KeySizeBytes, NonceSizeBytes, TagSizeBytes { get; }
    void   Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext, Span<byte> ciphertext, Span<byte> tag, ReadOnlySpan<byte> associatedData = default);
    bool   Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertext, ReadOnlySpan<byte> tag, Span<byte> plaintext, ReadOnlySpan<byte> associatedData = default);
    byte[] Encrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> plaintext, ReadOnlySpan<byte> associatedData = default);            // tag appended
    byte[] Decrypt(ReadOnlySpan<byte> nonce, ReadOnlySpan<byte> ciphertextWithTag, ReadOnlySpan<byte> associatedData = default);    // throws on auth failure
}
```
AEAD types: `AesGcm128/192/256`, `AesCcm128/192/256`, `ChaCha20Poly1305`,
`XChaCha20Poly1305`, `AsconAead128`. Construct via `Create(ReadOnlySpan<byte> key)`, e.g.
`using var gcm = AesGcm256.Create(key);`.

**Block ciphers** extend `SymmetricCipher : System.Security.Cryptography.SymmetricAlgorithm`
(drop-in: set `Key`/`IV`, use `CreateEncryptor()`/`CreateDecryptor()`, or the type's
`Encrypt(plaintext)`/`Decrypt(ciphertext)` convenience methods):
`Aes128/192/256`, `Aria128/192/256`, `Camellia128/192/256`, `Kalyna128/256/512`,
`Kuznyechik`, `Seed`, `Sm4`. Stream cipher: `ChaCha20`.

**Cipher hard rules:** never reuse a `(key, nonce)` pair for AEAD; a `false`/throwing
`Decrypt` means tampering or wrong key — discard the output, never use partial plaintext.
`Dispose()` zeroizes the retained key on every AEAD type, and the operations then throw
`ObjectDisposedException` — so scope the instance with `using` and do not cache one past the
work it was created for.

---

## Post-Quantum KEM — `…Kem`

`using CryptoHives.Foundation.Security.Cryptography.Kem;`

ML-KEM (FIPS 203), all three parameter sets. **`MLKem` and `MLKemAlgorithm` deliberately carry
the same names and signatures as `System.Security.Cryptography.MLKem` / `MLKemAlgorithm` from
.NET 10**, so porting from the in-box type is a `using` swap and nothing else:

```diff
-using System.Security.Cryptography;
+using CryptoHives.Foundation.Security.Cryptography.Kem;
```

Importing both namespaces in one file is `CS0104` on .NET 10 — that is the intended
consequence of matching the names. Alias one side if a file needs both:
`using Bcl = System.Security.Cryptography;`.

`MLKem.IsSupported` is always `true` here: it is a fully managed implementation and never
depends on Windows CNG or OpenSSL, so it works on every target framework down to net462.

```csharp
using var receiver = MLKem.GenerateKey(MLKemAlgorithm.MLKem768);   // MLKem512 / MLKem768 / MLKem1024
byte[] ek = receiver.ExportEncapsulationKey();

using var sender = MLKem.ImportEncapsulationKey(MLKemAlgorithm.MLKem768, ek);
sender.Encapsulate(out byte[] ciphertext, out byte[] senderSecret);

byte[] receiverSecret = receiver.Decapsulate(ciphertext);          // == senderSecret
```

Members (the full in-box surface except the key formats listed below):

- `static bool IsSupported` — always `true`.
- `static MLKem GenerateKey(MLKemAlgorithm)`.
- `static MLKem ImportPrivateSeed | ImportDecapsulationKey | ImportEncapsulationKey(MLKemAlgorithm, ReadOnlySpan<byte>)`,
  each with a `byte[]` overload.
- `void Encapsulate(Span<byte> ciphertext, Span<byte> sharedSecret)` and
  `void Encapsulate(out byte[] ciphertext, out byte[] sharedSecret)`.
- `void Decapsulate(ReadOnlySpan<byte> ciphertext, Span<byte> sharedSecret)` and
  `byte[] Decapsulate(byte[] ciphertext)`.
- `byte[] ExportPrivateSeed() | ExportEncapsulationKey() | ExportDecapsulationKey()`, each with a
  `(Span<byte> destination)` overload.
- `MLKemAlgorithm Algorithm { get; }`; `MLKemAlgorithm` exposes `Name`,
  `EncapsulationKeySizeInBytes`, `DecapsulationKeySizeInBytes`, `CiphertextSizeInBytes`,
  `SharedSecretSizeInBytes`, `PrivateSeedSizeInBytes`, and value equality (`IEquatable<>`, `==`, `!=`).
- `Dispose()` zeroizes the retained seed and decapsulation key.

**Do not invent these — they are not implemented yet:** `ImportPkcs8PrivateKey`,
`ImportSubjectPublicKeyInfo`, `ImportFromPem`, `ImportEncryptedPkcs8PrivateKey`,
`ImportFromEncryptedPem`, `ExportPkcs8PrivateKey[Pem]`, `ExportSubjectPublicKeyInfo[Pem]`,
`ExportEncryptedPkcs8PrivateKey[Pem]`, `TryExport*`. If a port needs PKCS#8/SPKI/PEM key
storage, keep the in-box `MLKem` for that path or store the raw 64-byte seed instead — do not
hand-roll the ASN.1.

There is also a lower-level stateless API for protocol code that owns its key bytes:
`IKem` with `MLKem512`, `MLKem768`, `MLKem1024` (`MLKem768.Create()`, then
`GenerateKeyPair` / `Encapsulate` / `Decapsulate` taking explicit key spans, plus
deterministic seed overloads). This one has no BCL counterpart.

**KEM hard rules:** the shared secret is *not* a key — run it through a KDF (`Hkdf`) before use.
Decapsulation uses implicit rejection: a tampered ciphertext yields a pseudorandom secret rather
than an error, so never treat "decapsulation succeeded" as authentication.

---

## Porting procedure

1. Add `CryptoHives.Foundation.Security.Cryptography`.
2. Swap implementation types only, preserving all crypto parameters (§ note above).
3. Add/keep a known-answer-vector test asserting the new output equals the pre-port output
   for representative inputs.
4. Build clean; run tests.
5. Report: `file:line` → old type → new type; plus any weak algorithm retained for human
   review.

Full cross-package porting guide: <https://cryptohives.github.io/Foundation/porting-to-cryptohives.html>
