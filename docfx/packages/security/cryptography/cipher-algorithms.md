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
- Performance: Very fast with AES-NI hardware support

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
- [AES-GCM Benchmarks](benchmarks/aesgcm128.md)

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
- Performance: Slower than GCM, more compact for small messages

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
- Performance: Fast on all platforms, no hardware dependency

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
- [ChaCha20-Poly1305 Benchmarks](benchmarks/chacha20poly1305.md)

### XChaCha20-Poly1305

```csharp
public sealed class XChaCha20Poly1305 : IAeadCipher
```

**Properties:**
- Key Size: 256 bits (32 bytes)
- Nonce Size: 24 bytes (192 bits) - larger than ChaCha20
- Tag Size: 16 bytes (128 bits)
- Performance: Same as ChaCha20-Poly1305

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
- [XChaCha20-Poly1305 Benchmarks](benchmarks/xchacha20poly1305.md)
- [ChaCha20-Poly1305 Benchmarks](benchmarks/chacha20poly1305.md)

---

## AEAD Cipher Comparison

| Algorithm | Key Size | Nonce Size | Tag Size | Performance | Hardware Accel | Best For |
|-----------|----------|------------|----------|-------------|----------------|----------|
| **AES-GCM** | 128/192/256 | 12 bytes | 16 bytes | Very fast* | AES-NI | General purpose, high throughput |
| **AES-CCM** | 128/192/256 | 7-13 bytes | 4-16 bytes | Moderate | AES-NI | IoT, small messages |
| **ChaCha20-Poly1305** | 256 | 12 bytes | 16 bytes | Fast | None needed | Software-only, mobile |
| **XChaCha20-Poly1305** | 256 | 24 bytes | 16 bytes | Fast | None needed | Random nonces safe |

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

## References

### Standards
- **NIST SP 800-38C** - Recommendation for Block Cipher Modes: CCM
- **NIST SP 800-38D** - Recommendation for Block Cipher Modes: GCM
- **RFC 3610** - Counter with CBC-MAC (CCM)
- **RFC 8439** - ChaCha20-Poly1305 for IETF protocols

### Test Vectors

Test vector documentation is coming soon.

### Benchmarks
- [AES-GCM Performance](benchmarks/aesgcm128.md)
- [ChaCha20-Poly1305 Performance](benchmarks/chacha20poly1305.md)
- [XChaCha20-Poly1305 Performance](benchmarks/xchacha20poly1305.md)
