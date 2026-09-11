# CryptoHives.Foundation.Security.Cryptography — Guide for LLM Agents

Machine-readable usage + porting guide for coding assistants. All APIs below are verified
against the shipped source. Do not invent members. Human-oriented docs live in `README.md`.

- **Package:** `CryptoHives.Foundation.Security.Cryptography` (0.x — the API is pre-1.0
  and may still change between minor versions)
- **Root namespace:** `CryptoHives.Foundation.Security.Cryptography` with sub-namespaces
  `.Hash`, `.Mac`, `.Kdf`, `.Cipher`, `.Kem`, `.Dsa`
- **What it is:** fully managed, deterministic, cross-platform implementations of hashes,
  MACs, KDFs, ciphers, and post-quantum KEMs and signatures. Hash and cipher types **extend the
  `System.Security.Cryptography` base types**, and `.Kem` / `.Dsa` **mirror their names and
  signatures**, so they are drop-in where those are expected — with the deliberate exceptions
  listed under *Key formats*, which are compile errors rather than silent behaviour changes.
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

PKCS#8, SubjectPublicKeyInfo and PEM **are** implemented, on every target framework. They have
their own porting rules — see *Key formats* below, which applies equally to `MLDsa` and
`SlhDsa`.

There is also a lower-level stateless API for protocol code that owns its key bytes:
`IKem` with `MLKem512`, `MLKem768`, `MLKem1024` (`MLKem768.Create()`, then
`GenerateKeyPair` / `Encapsulate` / `Decapsulate` taking explicit key spans, plus
deterministic seed overloads). This one has no BCL counterpart.

**KEM hard rules:** the shared secret is *not* a key — run it through a KDF (`Hkdf`) before use.
Decapsulation uses implicit rejection: a tampered ciphertext yields a pseudorandom secret rather
than an error, so never treat "decapsulation succeeded" as authentication.

---

## Post-Quantum Signatures — `…Dsa`

`using CryptoHives.Foundation.Security.Cryptography.Dsa;`

ML-DSA (FIPS 204, three parameter sets) and SLH-DSA (FIPS 205, all twelve). Like `.Kem`, both
**mirror the names and signatures of `System.Security.Cryptography.MLDsa` / `SlhDsa` from
.NET 10**, so porting is a `using` swap. `IsSupported` is always `true` — fully managed, no CNG
or OpenSSL dependency, works down to net462.

```csharp
using var signer = MLDsa.GenerateKey(MLDsaAlgorithm.MLDsa65);
byte[] signature = signer.SignData(message, context: default);

using var verifier = MLDsa.ImportMLDsaPublicKey(MLDsaAlgorithm.MLDsa65, signer.ExportMLDsaPublicKey());
bool valid = verifier.VerifyData(message, signature, context: default);
```

Members, both types (`X` = `MLDsa` or `SlhDsa`):

- `static bool IsSupported` — always `true`; `XAlgorithm Algorithm { get; }`.
- `static X GenerateKey(XAlgorithm)`, plus a `(XAlgorithm, bool pairwiseConsistencyTest)` overload.
- `static X ImportXPublicKey | ImportXPrivateKey(XAlgorithm, ReadOnlySpan<byte>)`, each with a
  `byte[]` overload. **ML-DSA only:** `ImportMLDsaPrivateSeed(...)`, also with a
  `(..., bool pairwiseConsistencyTest)` overload. SLH-DSA has no seed import — FIPS 205 keygen
  takes three n-byte seeds, not one.
- `byte[] ExportXPublicKey() | ExportXPrivateKey()`, each with a `(Span<byte>)` overload.
  **ML-DSA only:** `ExportMLDsaPrivateSeed()`.
- `SignData` / `VerifyData` — span triples plus `byte[]` overloads; the context string is the
  **last** parameter, and on the span-writing overload the destination is **second**.
- `SignPreHash` / `VerifyPreHash(hash, [signature,] string hashAlgorithmOid, context)` —
  HashML-DSA §5.4 / HashSLH-DSA §10.2. The caller supplies PH(M) and the dotted OID.
- `Dispose()` zeroizes retained key material.
- `MLDsaAlgorithm`: `MLDsa44`, `MLDsa65`, `MLDsa87`; `Name`, `PublicKeySizeInBytes`,
  `PrivateKeySizeInBytes`, `SignatureSizeInBytes`, `PrivateSeedSizeInBytes`, `MuSizeInBytes`.
- `SlhDsaAlgorithm`: `SlhDsaSha2_128s|f`, `SlhDsaShake128s|f` and the 192/256 equivalents (twelve
  in all); `Name`, `PublicKeySizeInBytes`, `PrivateKeySizeInBytes`, `SignatureSizeInBytes`.

**Do not invent these — not implemented:** `SignMu` / `VerifyMu` (external-μ signing).
`MLDsaAlgorithm.MuSizeInBytes` exists, but the operations do not.

**Signature hard rules:** the `'s'` SLH-DSA parameter sets sign slowly *by design* (~10⁶ hash
invocations) — if a port is choosing a set rather than preserving one, prefer `'f'`. ML-DSA signing
is hedged by default; that is not a bug, and a deterministic signature is not required for
verification to succeed.

---

## Key formats — PKCS#8, SPKI, PEM

Applies to **`MLKem`** (`.Kem`), **`MLDsa`** and **`SlhDsa`** (`.Dsa`). All three carry the same
27-member block, on every target framework down to net462. Most of it matches the in-box
signatures exactly and ports as a `using` swap:

```csharp
byte[] spki  = key.ExportSubjectPublicKeyInfo();
byte[] pkcs8 = key.ExportPkcs8PrivateKey();
string pem   = key.ExportSubjectPublicKeyInfoPem();
using var imported = MLDsa.ImportPkcs8PrivateKey(pkcs8);
```

Three things differ, and a port that ignores them will not compile — which is the intent.

### 1. No member takes a password as a `string`

**Do not invent these. They do not exist, and their absence is deliberate:**

| Not available | Use instead |
|---|---|
| `ImportEncryptedPkcs8PrivateKey(string, byte[])` | `(ReadOnlySpan<char>, ReadOnlySpan<byte>)` |
| `ExportEncryptedPkcs8PrivateKey(string, …)` | `(ReadOnlySpan<char>, …)` |
| `ExportEncryptedPkcs8PrivateKeyPem(string, …)` | `(ReadOnlySpan<char>, …)` |
| `TryExportEncryptedPkcs8PrivateKey(string, …)` | `(ReadOnlySpan<char>, …)` |
| `ImportFromEncryptedPem(string, string)` | `(ReadOnlySpan<char>, ReadOnlySpan<char>)` |

A `string` is immutable: once a password is in one, nothing can overwrite it, and it stays on the
managed heap until the collector happens to reuse that memory. Passwords are therefore taken only
as spans, so the caller owns storage they can clear.

This is **not** a divergence from .NET generally. `AsymmetricAlgorithm` — the base `RSA`, `ECDsa`
and `DSA` inherit — has never had a `string` password overload either. The in-box PQC types added
them late, for stated reasons of downlevel ergonomics
([dotnet/runtime#115024](https://github.com/dotnet/runtime/issues/115024)); this library targets
those same downlevel frameworks and declined the trade.

Porting a call is mechanical — `"pw"` becomes `"pw".AsSpan()` and compiles. Porting it *properly*
means the password stops being a literal:

```csharp
char[] password = ReadPassword();       // user input, secret store, ...

try
{
    byte[] encrypted = key.ExportEncryptedPkcs8PrivateKey(password, pbe);
}
finally
{
    CryptographicOperations.ZeroMemory(password);
}
```

**Clear it with `CryptographicOperations.ZeroMemory`, not `Array.Clear`.** A clear on a buffer you
are about to drop is a dead store, and a compiler may delete it; `ZeroMemory` is
`NoInlining | NoOptimization` so it cannot. This package exposes its own because the in-box type
does not exist below netstandard2.1 and has **no character overload** on any .NET version. Importing
both namespaces in one file is `CS0104` — alias one side,
`using Bcl = System.Security.Cryptography;`.

### 2. Character and byte passwords are not interchangeable

Both overloads exist and they mean different things. Getting this wrong does **not** throw — it
derives a different key and surfaces much later as "the password is incorrect".

| | `ReadOnlySpan<char> password` | `ReadOnlySpan<byte> passwordBytes` |
|---|---|---|
| Carries | the password **as text** | the KDF input **as bytes** |
| Under PBES2 (what we write) | encoded UTF-8 before use | used verbatim |
| Under PKCS#12 (legacy, read-only) | encoded big-endian UTF-16, NUL-terminated | used verbatim |

Under **PBES2 the character encoding *is* UTF-8**, so `"pw"u8` and `"pw".AsSpan()` derive the same
key — for any text, including non-ASCII and astral characters. They part company in exactly two
places:

- **Reading a legacy PKCS#12 file**, where characters become big-endian UTF-16 plus a NUL
  terminator, so `"pw"u8` will not open what `"pw".AsSpan()` wrote.
- **Byte inputs that are not valid UTF-8** — `[0x00, 0xFF, 0x10]` is not the encoding of any
  string, so no character password reaches it. That is what the byte overload is *for*.

When a port has a fixed password (a test vector, a derivation input you do not control), a UTF-8
literal is the better spelling — `"pw"u8` never creates a `String`, which `"pw".ToCharArray()`
does. It is still compiled into the assembly, so it is no more erasable than a literal was.

### 3. `PbeOptions`, not `PbeParameters`; and no allocating plaintext-PEM export

```diff
-var pbe = new PbeParameters(PbeEncryptionAlgorithm.Aes256Cbc, HashAlgorithmName.SHA256, 600_000);
+var pbe = new PbeOptions(PbeEncryptionAlgorithm.Aes256Cbc, Pbkdf2Prf.HmacSha256, 600_000);
```

`PbeParameters` does not exist below netstandard2.1, and supplying it would mean declaring a type
in `System.Security.Cryptography` — a hard `CS0433` against `Microsoft.Bcl.Cryptography`. This
package declares nothing outside its own namespace. `Pbkdf2Prf` is a closed enum of the PRFs
RFC 8018 gives an OID, so an unencodable choice fails to compile rather than throwing at export.
Reading is not restricted to that set — a file written elsewhere with, say, HMAC-SHA-224 still
opens.

`string ExportPkcs8PrivateKeyPem()` is also absent: its return value *is* the private key, and a
`string` holding one can never be erased. Use the buffer form, sized exactly:

```csharp
int size = key.GetPkcs8PrivateKeyPemSize();
char[] pem = ArrayPool<char>.Shared.Rent(size);

try
{
    key.TryExportPkcs8PrivateKeyPem(pem, out int charsWritten);
    // ... use pem.AsSpan(0, charsWritten) ...
}
finally
{
    CryptographicOperations.ZeroMemory(pem.AsSpan(0, size));
    ArrayPool<char>.Shared.Return(pem);
}
```

`ImportFromPem` likewise takes only `ReadOnlySpan<char>`. Note a `string` converts implicitly, so
`ImportFromPem(someString)` still compiles — the API no longer *forces* a string, it does not
forbid one.

`string` survives on exactly two members, because their content is public by construction:
`ExportSubjectPublicKeyInfoPem()` (a public key) and `ExportEncryptedPkcs8PrivateKeyPem(...)`
(ciphertext).

Full reference, including the per-member porting table:
<https://cryptohives.github.io/Foundation/packages/security/cryptography/erasable-memory.html>

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
