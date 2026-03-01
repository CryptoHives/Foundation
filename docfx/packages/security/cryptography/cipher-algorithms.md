# Cipher Algorithms Reference

This page provides detailed documentation for all cipher algorithms implemented in the CryptoHives.Foundation.Security.Cryptography package.

## Namespace

```csharp
using CryptoHives.Foundation.Security.Cryptography.Cipher;
```

---

## AEAD Ciphers (Authenticated Encryption)

AEAD (Authenticated Encryption with Associated Data) ciphers provide both confidentiality and authenticity in a single operation.

### AES-GCM (Galois/Counter Mode)

```csharp
public sealed class AesGcm128 : AesGcm
public sealed class AesGcm192 : AesGcm
public sealed class AesGcm256 : AesGcm
```

**Properties:**
- Key Sizes: 128, 192, or 256 bits
- Nonce Size: 12 bytes (recommended), variable supported
- Tag Size: 16 bytes (default), configurable
- Performance: Very fast with AES-NI + PCLMULQDQ/VPCLMULQDQ hardware support; 8-block stitched pipeline; ~2× faster than OS at small sizes

**Security:**
- ✅ Widely used in TLS 1.3, IPsec, QUIC
- ✅ NIST approved (SP 800-38D)
- ⚠️ Nonce reuse catastrophic - each (key, nonce) pair must be unique

**Usage:**
```csharp
// Create instance with key
byte[] key = new byte[32]; // 256-bit key
using var aesGcm = AesGcm256.Create(key);

// Encrypt with authentication
byte[] nonce = new byte[12];
byte[] plaintext = Encoding.UTF8.GetBytes("Hello, World!");
byte[] aad = Encoding.UTF8.GetBytes("header");

byte[] ciphertext = new byte[plaintext.Length];
byte[] tag = new byte[16];
aesGcm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

// Decrypt and verify
byte[] decrypted = new byte[plaintext.Length];
bool success = aesGcm.Decrypt(nonce, ciphertext, tag, decrypted, aad);
```

**See Also:**
- [AES-GCM Benchmarks](benchmarks-cipher.md#aes-128-gcm)

### AES-CCM (Counter with CBC-MAC)

```csharp
public sealed class AesCcm128 : AesCcm
public sealed class AesCcm192 : AesCcm
public sealed class AesCcm256 : AesCcm
```

**Properties:**
- Key Sizes: 128, 192, or 256 bits
- Nonce Size: 7-13 bytes (12 bytes recommended)
- Tag Size: 4-16 bytes (must be even)
- Performance: Slower than GCM, 2.8–3× faster with AES-NI, more compact for small messages

**Security:**
- ✅ NIST approved (SP 800-38C)
- ✅ Widely used in IoT, Bluetooth LE, ZigBee, Thread
- ✅ RFC 3610 compliant
- ⚠️ Nonce reuse catastrophic - each (key, nonce) pair must be unique

**Usage:**
```csharp
// Create instance with key
byte[] key = new byte[16]; // 128-bit key
using var aesCcm = AesCcm128.Create(key);

// Encrypt with authentication
byte[] nonce = new byte[12]; // 96-bit nonce
byte[] plaintext = Encoding.UTF8.GetBytes("Sensor data");
byte[] aad = Encoding.UTF8.GetBytes("device-id");

byte[] ciphertext = new byte[plaintext.Length];
byte[] tag = new byte[8]; // 64-bit tag
aesCcm.Encrypt(nonce, plaintext, ciphertext, tag, aad);

// Decrypt and verify
byte[] decrypted = new byte[plaintext.Length];
bool success = aesCcm.Decrypt(nonce, ciphertext, tag, decrypted, aad);
```

**See Also:**
- AES-CCM Test Vectors (Coming soon)

### ChaCha20-Poly1305

```csharp
public sealed class ChaCha20Poly1305 : IAeadCipher
```

**Properties:**
- Key Size: 256 bits (32 bytes)
- Nonce Size: 12 bytes (96 bits)
- Tag Size: 16 bytes (128 bits)
- Performance: Fast on all platforms; SSSE3/AVX2 accelerated, no AES-NI dependency

**Security:**
- ✅ IETF standard (RFC 8439)
- ✅ Used in TLS 1.3, WireGuard, SSH
- ✅ Software-friendly alternative to AES-GCM
- ⚠️ Nonce reuse catastrophic - each (key, nonce) pair must be unique

**Usage:**
```csharp
// Create instance with key
byte[] key = new byte[32]; // 256-bit key
using var chacha = ChaCha20Poly1305.Create(key);

// Encrypt
byte[] nonce = new byte[12];
byte[] plaintext = Encoding.UTF8.GetBytes("Message");
byte[] ciphertext = chacha.Encrypt(nonce, plaintext);

// Decrypt
byte[] decrypted = chacha.Decrypt(nonce, ciphertext);
```

**See Also:**
- [ChaCha20-Poly1305 Benchmarks](benchmarks-cipher.md#chacha20-poly1305)

### XChaCha20-Poly1305

```csharp
public sealed class XChaCha20Poly1305 : IAeadCipher
```

**Properties:**
- Key Size: 256 bits (32 bytes)
- Nonce Size: 24 bytes (192 bits) - larger than ChaCha20
- Tag Size: 16 bytes (128 bits)
- Performance: Same as ChaCha20-Poly1305; SSSE3/AVX2 accelerated

**Security:**
- ✅ Extended nonce version of ChaCha20-Poly1305
- ✅ Safer for random nonces (negligible collision probability)
- ✅ Used in libsodium, age encryption
- ✅ More forgiving of nonce generation mistakes

**Usage:**
```csharp
// Create instance with key
byte[] key = new byte[32];
using var xchacha = XChaCha20Poly1305.Create(key);

// Generate random nonce (safe with 192-bit nonce)
byte[] nonce = new byte[24];
RandomNumberGenerator.Fill(nonce);

// Encrypt
byte[] plaintext = Encoding.UTF8.GetBytes("Secret");
byte[] ciphertext = xchacha.Encrypt(nonce, plaintext);

// Decrypt
byte[] decrypted = xchacha.Decrypt(nonce, ciphertext);
```

**See Also:**
- [XChaCha20-Poly1305 Benchmarks](benchmarks-cipher.md#xchacha20-poly1305)
- [ChaCha20-Poly1305 Benchmarks](benchmarks-cipher.md#chacha20-poly1305)

---

## Block Ciphers

Block ciphers encrypt fixed-size blocks of data. They require a mode of operation (ECB, CBC, CTR) to encrypt data larger than a single block.

All block ciphers extend `SymmetricCipher` (which inherits from `System.Security.Cryptography.SymmetricAlgorithm`) and implement `ICipherTransform` for span-based streaming transformations.

### AES (Advanced Encryption Standard)

```csharp
public sealed class Aes128 : SymmetricCipher
public sealed class Aes192 : SymmetricCipher
public sealed class Aes256 : SymmetricCipher
```

**Properties:**
- Key Sizes: 128, 192, or 256 bits
- Block Size: 128 bits (16 bytes)
- IV Size: 16 bytes (CBC, CTR) or none (ECB)
- Modes: ECB, CBC, CTR
- Padding: PKCS#7, None, Zeros, ANSIX923, ISO10126
- Performance: Hardware accelerated with AES-NI; vectorized CBC decrypt (4/8-block interleaved)

**Security:**
- ✅ NIST approved (FIPS 197)
- ✅ The most widely used symmetric cipher in the world
- ⚠️ ECB mode is insecure for multi-block data — use CBC or CTR
- ⚠️ CBC mode requires unpredictable IVs and is vulnerable to padding oracle attacks without authentication

**Usage — CTR Mode (Recommended):**
```csharp
using CryptoHives.Foundation.Security.Cryptography.Cipher;

// Create AES-256 in CTR mode
using var aes = Aes256.Create();
aes.Mode = CipherMode.CTR;
aes.Padding = PaddingMode.None; // CTR does not require padding

// Set key and IV
aes.Key = new byte[32]; // 256-bit key
aes.IV = new byte[16]; // 128-bit nonce/counter

// Single-operation
byte[] ciphertext = aes.Encrypt(plaintext);
byte[] decrypted = aes.Decrypt(ciphertext);
```

**Usage — CBC Mode:**
```csharp
using var aes = Aes128.Create();
aes.Mode = CipherMode.CBC;
aes.Padding = PaddingMode.PKCS7;
aes.Key = new byte[16]; // 128-bit key
aes.GenerateIV(); // Random IV

byte[] ciphertext = aes.Encrypt(plaintext);
byte[] decrypted = aes.Decrypt(ciphertext);
```

**Usage — Streaming (ICipherTransform):**
```csharp
using var aes = Aes256.Create();
aes.Mode = CipherMode.CTR;
aes.Padding = PaddingMode.None;
aes.Key = new byte[32];
aes.IV = new byte[16];

// Create transform for incremental encryption
using var encryptor = aes.CreateEncryptor();

// Process multiple blocks
Span<byte> output = new byte[inputChunk.Length];
int written = encryptor.TransformBlock(inputChunk, output);

// Final block (handles padding for CBC)
written = encryptor.TransformFinalBlock(lastChunk, output);
```

> [!WARNING]
> **ECB mode** encrypts each block independently. Identical plaintext blocks produce
> identical ciphertext, leaking patterns. Use **CTR** or **CBC** mode instead.
> For authenticated encryption, prefer [AES-GCM](#aes-gcm-galoisscounter-mode) or
> [AES-CCM](#aes-ccm-counter-with-cbc-mac).

---

## Stream Ciphers

Stream ciphers generate a keystream that is XORed with the plaintext. They do not require padding and can process data of any length.

### ChaCha20

```csharp
public sealed class ChaCha20 : SymmetricCipher
```

**Properties:**
- Key Size: 256 bits (32 bytes)
- Nonce Size: 12 bytes (96 bits) — IETF variant (RFC 8439)
- Block Size: 1 byte (stream cipher, processes any length)
- Counter: 32-bit initial block counter (configurable via `InitialCounter`)
- Performance: SSSE3/AVX2 hardware accelerated

**Security:**
- ✅ IETF standard (RFC 8439)
- ✅ Constant-time — no timing side channels
- ✅ Fast in software without dedicated hardware (unlike AES without AES-NI)
- ⚠️ No authentication — use [ChaCha20-Poly1305](#chacha20-poly1305) for authenticated encryption
- ⚠️ Nonce reuse is catastrophic — never reuse a (key, nonce) pair

**Usage:**
```csharp
using CryptoHives.Foundation.Security.Cryptography.Cipher;

// Create ChaCha20 stream cipher
using var chacha = ChaCha20.Create();
chacha.Key = new byte[32]; // 256-bit key
chacha.IV = new byte[12]; // 96-bit nonce

// Single-operation encryption (XOR with keystream)
byte[] ciphertext = chacha.Encrypt(plaintext);

// Decryption is the same operation (XOR is symmetric)
byte[] decrypted = chacha.Decrypt(ciphertext);
```

**Usage — Streaming:**
```csharp
using var chacha = ChaCha20.Create();
chacha.Key = key;
chacha.IV = nonce;

using var encryptor = chacha.CreateEncryptor();

// Stream cipher: process any amount of data
Span<byte> output = new byte[chunk.Length];
encryptor.TransformBlock(chunk, output);

// No padding needed for final block
encryptor.TransformFinalBlock(lastChunk, output);
```

**Usage — Custom Initial Counter:**
```csharp
// RFC 8439 §2.4: AEAD construction uses counter = 1 (block 0 for Poly1305 key)
using var chacha = ChaCha20.Create();
chacha.InitialCounter = 1;
chacha.Key = key;
chacha.IV = nonce;
```

> [!TIP]
> ChaCha20 is the preferred stream cipher when AES-NI hardware is not available.
> It is faster than AES in software and has no timing side channels from table lookups.
> For authenticated encryption, use [ChaCha20-Poly1305](#chacha20-poly1305).

---

## Block/Stream Cipher Comparison

| Algorithm | Type | Key Size | Block/IV | Modes | Hardware Accel | Best For |
|-----------|------|----------|----------|-------|----------------|----------|
| **AES-128** | Block | 128 bits | 16B / 16B | ECB, CBC, CTR | AES-NI | General purpose, compliance |
| **AES-192** | Block | 192 bits | 16B / 16B | ECB, CBC, CTR | AES-NI | Higher security margin |
| **AES-256** | Block | 256 bits | 16B / 16B | ECB, CBC, CTR | AES-NI | Maximum AES security |
| **ChaCha20** | Stream | 256 bits | — / 12B | Stream | SSSE3/AVX2 | Software-only, mobile |

---

## Cipher Modes of Operation

| Mode | Type | Padding | Parallel Encrypt | Parallel Decrypt | Notes |
|------|------|---------|------------------|------------------|-------|
| **ECB** | Block | Required | ✅ | ✅ | ⚠️ Insecure for multi-block |
| **CBC** | Block | Required | ❌ | ✅ | Needs unpredictable IV |
| **CTR** | Stream | None | ✅ | ✅ | Recommended for most uses |
| **Stream** | Stream | None | ✅ | ✅ | ChaCha20 native mode |



| Algorithm | Key Size | Nonce Size | Tag Size | Performance | Hardware Accel | Best For |
|-----------|----------|------------|----------|-------------|----------------|----------|
| **AES-GCM** | 128/192/256 | 12 bytes | 16 bytes | Very fast* | AES-NI + PCLMULQDQ/VPCLMULQDQ | General purpose, high throughput |
| **AES-CCM** | 128/192/256 | 7-13 bytes | 4-16 bytes | Moderate* | AES-NI | IoT, small messages |
| **ChaCha20-Poly1305** | 256 | 12 bytes | 16 bytes | Fast | SSSE3/AVX2 | Software-only, mobile |
| **XChaCha20-Poly1305** | 256 | 24 bytes | 16 bytes | Fast | SSSE3/AVX2 | Random nonces safe |

*With AES-NI hardware acceleration. Without hardware: ChaCha20 is typically faster.

---

## Security Considerations

### Critical: Nonce Uniqueness

**All AEAD ciphers require unique (key, nonce) pairs:**

```csharp
// ❌ WRONG - Nonce reuse destroys security
var aesGcm = AesGcm256.Create(key);
byte[] nonce = new byte[12]; // Same nonce!
aesGcm.Encrypt(nonce, message1, ...); // First use: OK
aesGcm.Encrypt(nonce, message2, ...); // Reuse: CATASTROPHIC FAILURE

// ✅ CORRECT - Unique nonce for each message
var aesGcm = AesGcm256.Create(key);
byte[] nonce1 = GenerateUniqueNonce(); // Method 1: Counter
aesGcm.Encrypt(nonce1, message1, ...);

byte[] nonce2 = GenerateUniqueNonce(); // Method 2: Random (XChaCha20 preferred)
aesGcm.Encrypt(nonce2, message2, ...);
```

### Nonce Generation Strategies

**Method 1: Counter (Recommended for most cases)**
```csharp
private ulong _counter = 0;

byte[] GenerateNonce()
{
    byte[] nonce = new byte[12];
    BinaryPrimitives.WriteUInt64LittleEndian(nonce, _counter++);
    return nonce;
}
```

**Method 2: Random (XChaCha20-Poly1305 only)**
```csharp
// Safe only with 192-bit nonces (XChaCha20)
byte[] nonce = new byte[24];
RandomNumberGenerator.Fill(nonce);
// Collision probability negligible with 192 bits
```

**Method 3: Random + Counter (Hybrid)**
```csharp
// 64-bit random + 32-bit counter
byte[] nonce = new byte[12];
RandomNumberGenerator.Fill(nonce.AsSpan(0, 8)); // Random prefix
BinaryPrimitives.WriteUInt32LittleEndian(nonce.AsSpan(8), counter++);
```

### Additional Authenticated Data (AAD)

AAD is authenticated but not encrypted (useful for headers, metadata):

```csharp
// Encrypt message with authenticated header
byte[] header = Encoding.UTF8.GetBytes("User-ID: 12345");
byte[] message = Encoding.UTF8.GetBytes("Secret message");

aesGcm.Encrypt(nonce, message, ciphertext, tag, header);
// Result: message is encrypted, header is authenticated but plaintext
```

---

## Regional Block Ciphers

Regional block ciphers complement the hash family coverage and provide national standard encryption algorithms. All implementations support ECB, CBC, and CTR modes via the shared `BlockCipherTransform` infrastructure.

### SM4 (China)

```csharp
public sealed class Sm4 : BlockCipherTransform
```

**Properties:**
- Key Size: 128 bits
- Block Size: 128 bits
- Rounds: 32
- Standard: GB/T 32907-2016

**Security:**
- ✅ Chinese national standard, mandatory for commercial use in China
- ✅ Used in Chinese TLS implementations and WAPI (WLAN security)
- ✅ ISO/IEC 18033-3:2010 listed

**Usage:**
```csharp
using var sm4 = Sm4.Create();
sm4.Mode = CipherMode.CBC;
sm4.Padding = PaddingMode.PKCS7;
sm4.Key = key; // 16 bytes
sm4.IV = iv;   // 16 bytes
byte[] ciphertext = sm4.Encrypt(plaintext);
byte[] decrypted = sm4.Decrypt(ciphertext);
```

### ARIA (Korea)

```csharp
public sealed class Aria128 : BlockCipherTransform
public sealed class Aria192 : BlockCipherTransform
public sealed class Aria256 : BlockCipherTransform
```

**Properties:**
- Key Sizes: 128, 192, or 256 bits
- Block Size: 128 bits
- Rounds: 12 (128-bit key), 14 (192-bit key), 16 (256-bit key)
- Standard: KS X 1213, RFC 5794

**Security:**
- ✅ Korean national standard
- ✅ Used in Korean government and financial systems
- ✅ RFC 5794 specification

**Usage:**
```csharp
using var aria = Aria256.Create();
aria.Mode = CipherMode.CBC;
aria.Padding = PaddingMode.PKCS7;
aria.Key = key; // 32 bytes
aria.IV = iv;   // 16 bytes
byte[] ciphertext = aria.Encrypt(plaintext);
```

### Camellia (Japan)

```csharp
public sealed class Camellia128 : BlockCipherTransform
public sealed class Camellia192 : BlockCipherTransform
public sealed class Camellia256 : BlockCipherTransform
```

**Properties:**
- Key Sizes: 128, 192, or 256 bits
- Block Size: 128 bits
- Rounds: 18 (128-bit key), 24 (192/256-bit key)
- Standard: RFC 3713, ISO/IEC 18033-3

**Security:**
- ✅ Japanese CRYPTREC recommended cipher
- ✅ NESSIE selected algorithm (EU)
- ✅ Comparable security level to AES

**Usage:**
```csharp
using var camellia = Camellia128.Create();
camellia.Mode = CipherMode.CBC;
camellia.Padding = PaddingMode.PKCS7;
camellia.Key = key; // 16 bytes
camellia.IV = iv;   // 16 bytes
byte[] ciphertext = camellia.Encrypt(plaintext);
```

### Kuznyechik (Russia)

```csharp
public sealed class Kuznyechik : BlockCipherTransform
```

**Properties:**
- Key Size: 256 bits
- Block Size: 128 bits
- Rounds: 10
- Standard: GOST R 34.12-2015

**Security:**
- ✅ Russian national standard (successor to GOST 28147-89)
- ✅ Used in Russian government and banking systems
- ✅ Paired with Streebog hash family

**Usage:**
```csharp
using var kuz = Kuznyechik.Create();
kuz.Mode = CipherMode.CBC;
kuz.Padding = PaddingMode.PKCS7;
kuz.Key = key; // 32 bytes
kuz.IV = iv;   // 16 bytes
byte[] ciphertext = kuz.Encrypt(plaintext);
```

### Kalyna (Ukraine)

```csharp
public sealed class Kalyna128 : BlockCipherTransform
public sealed class Kalyna256 : BlockCipherTransform
```

**Properties:**
- Key Sizes: 128 or 256 bits
- Block Size: 128 bits
- Rounds: 10 (128-bit key), 14 (256-bit key)
- Standard: DSTU 7624:2014

**Security:**
- ✅ Ukrainian national standard
- ✅ Paired with Kupyna hash family
- ✅ Uses MDS matrix-based diffusion layer

**Usage:**
```csharp
using var kalyna = Kalyna256.Create();
kalyna.Mode = CipherMode.CBC;
kalyna.Padding = PaddingMode.PKCS7;
kalyna.Key = key; // 32 bytes
kalyna.IV = iv;   // 16 bytes
byte[] ciphertext = kalyna.Encrypt(plaintext);
```

### SEED (Korea)

```csharp
public sealed class Seed : BlockCipherTransform
```

**Properties:**
- Key Size: 128 bits
- Block Size: 128 bits
- Rounds: 16
- Standard: RFC 4269, KISA

**Security:**
- ✅ Korean national standard (KISA)
- ✅ Used in Korean financial and government systems
- ✅ 16-round Feistel structure with S-boxes derived from the golden ratio

**Usage:**
```csharp
using var seed = Seed.Create();
seed.Mode = CipherMode.CBC;
seed.Padding = PaddingMode.PKCS7;
seed.Key = key; // 16 bytes
seed.IV = iv;   // 16 bytes
byte[] ciphertext = seed.Encrypt(plaintext);
```

### Regional Cipher Comparison

| Algorithm | Origin | Key Sizes | Block Size | Rounds | Standard |
|-----------|--------|-----------|------------|--------|----------|
| **SM4** | China | 128 | 128 bits | 32 | GB/T 32907-2016 |
| **ARIA** | Korea | 128/192/256 | 128 bits | 12/14/16 | KS X 1213, RFC 5794 |
| **Camellia** | Japan | 128/192/256 | 128 bits | 18/24 | RFC 3713, ISO 18033-3 |
| **Kuznyechik** | Russia | 256 | 128 bits | 10 | GOST R 34.12-2015 |
| **Kalyna** | Ukraine | 128/256 | 128 bits | 10/14 | DSTU 7624:2014 |
| **SEED** | Korea | 128 | 128 bits | 16 | RFC 4269 |

**See Also:**
- [Regional Cipher Benchmarks](benchmarks-cipher.md#regional-block-ciphers)

---

## References

### Standards
- **NIST FIPS 197** - Advanced Encryption Standard (AES)
- **NIST SP 800-38A** - Recommendation for Block Cipher Modes: ECB, CBC, CFB, OFB, CTR
- **NIST SP 800-38C** - Recommendation for Block Cipher Modes: CCM
- **NIST SP 800-38D** - Recommendation for Block Cipher Modes: GCM
- **RFC 3610** - Counter with CBC-MAC (CCM)
- **RFC 8439** - ChaCha20 and Poly1305 for IETF Protocols
- **draft-irtf-cfrg-xchacha** - XChaCha20-Poly1305

### Regional Standards
- **GB/T 32907-2016** - SM4 Block Cipher (China)
- **KS X 1213** - ARIA Block Cipher (Korea)
- **RFC 3713** - Camellia Encryption Algorithm (Japan, CRYPTREC)
- **GOST R 34.12-2015** - Kuznyechik Block Cipher (Russia)
- **DSTU 7624:2014** - Kalyna Block Cipher (Ukraine)
- **RFC 4269** - SEED Encryption Algorithm (Korea, KISA)

### Test Vectors

Test vector documentation is coming soon.

### Benchmarks
- [All Cipher Benchmarks](benchmarks-cipher.md)
- [AES-GCM Performance](benchmarks-cipher.md#aes-128-gcm)
- [ChaCha20-Poly1305 Performance](benchmarks-cipher.md#chacha20-poly1305)
- [XChaCha20-Poly1305 Performance](benchmarks-cipher.md#xchacha20-poly1305)
- [Regional Cipher Benchmarks](benchmarks-cipher.md#regional-block-ciphers)
