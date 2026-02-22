# MAC Algorithms Reference

This page provides detailed documentation for all Message Authentication Code (MAC) algorithms implemented in the CryptoHives.Foundation.Security.Cryptography package.

## Namespace

```csharp
using CryptoHives.Foundation.Security.Cryptography.Mac;
```

---

## Overview

Message Authentication Codes (MACs) provide both data integrity and authenticity verification. Unlike simple hash functions, MACs require a secret key, ensuring that only parties with the key can generate or verify the authentication tag.

### MAC vs Hash

| Feature | Hash | MAC |
|---------|------|-----|
| Secret key required | No | Yes |
| Data integrity | Yes | Yes |
| Data authenticity | No | Yes |
| Use case | Fingerprinting | Authentication |

---

## KMAC128

KMAC128 is the Keccak Message Authentication Code with 128-bit security, defined in NIST SP 800-185.

### Class Declaration

```csharp
public sealed class KMac128 : HashAlgorithm
```

### Properties

| Property | Value |
|----------|-------|
| Security | 128 bits |
| Output Size | Variable (default 32 bytes) |
| Key Size | Any length |
| Block Size | 168 bytes (rate) |

### Constructor

```csharp
public KMac128(byte[] key, int outputBytes = 32, string customization = "")
```

**Parameters:**
- `key` - The secret key (any length, cannot be empty)
- `outputBytes` - Desired output size in bytes (default: 32)
- `customization` - Optional customization string for domain separation

### Factory Method

```csharp
public static KMac128 Create(byte[] key, int outputBytes = 32, string customization = "")
```

### Usage Examples

```csharp
byte[] key = new byte[32];
RandomNumberGenerator.Fill(key);
byte[] message = Encoding.UTF8.GetBytes("Hello, World!");

// Basic KMAC128
using var kmac = KMac128.Create(key, outputBytes: 32);
byte[] mac = kmac.ComputeHash(message);

// With customization string
using var kmac = KMac128.Create(key, outputBytes: 32, customization: "MyApp v1.0");
byte[] mac = kmac.ComputeHash(message);

// Variable output length
using var kmac = KMac128.Create(key, outputBytes: 64);
byte[] longMac = kmac.ComputeHash(message);
```

### Incremental Usage

```csharp
using var kmac = KMac128.Create(key, outputBytes: 32, customization: "");

// Process data in chunks
kmac.TransformBlock(chunk1, 0, chunk1.Length, null, 0);
kmac.TransformBlock(chunk2, 0, chunk2.Length, null, 0);
kmac.TransformFinalBlock(chunk3, 0, chunk3.Length);

byte[] mac = kmac.Hash;
```

---

## KMAC256

KMAC256 is the Keccak Message Authentication Code with 256-bit security, defined in NIST SP 800-185.

### Class Declaration

```csharp
public sealed class KMac256 : HashAlgorithm
```

### Properties

| Property | Value |
|----------|-------|
| Security | 256 bits |
| Output Size | Variable (default 64 bytes) |
| Key Size | Any length |
| Block Size | 136 bytes (rate) |

### Constructor

```csharp
public KMac256(byte[] key, int outputBytes = 64, string customization = "")
```

**Parameters:**
- `key` - The secret key (any length, cannot be empty)
- `outputBytes` - Desired output size in bytes (default: 64)
- `customization` - Optional customization string for domain separation

### Factory Method

```csharp
public static KMac256 Create(byte[] key, int outputBytes = 64, string customization = "")
```

### Usage Examples

```csharp
byte[] key = new byte[32];
RandomNumberGenerator.Fill(key);
byte[] message = Encoding.UTF8.GetBytes("Hello, World!");

// Basic KMAC256
using var kmac = KMac256.Create(key, outputBytes: 64);
byte[] mac = kmac.ComputeHash(message);

// With customization string for domain separation
using var kmac = KMac256.Create(key, outputBytes: 64, customization: "Session Authentication");
byte[] mac = kmac.ComputeHash(message);
```

---

## HMAC (Hash-based Message Authentication Code)

HMAC is the most widely used MAC construction, defined in RFC 2104 and FIPS 198-1. It works with any cryptographic hash function and is used extensively in TLS, SSH, IPsec, and OAuth.

### IMac Interface

All new MAC types implement the `IMac` interface for consistent API:

```csharp
public interface IMac : IDisposable
{
    string AlgorithmName { get; }
    int MacSize { get; }
    void Update(ReadOnlySpan<byte> input);
    void Finalize(Span<byte> destination);
    void Reset();
}
```

### Available HMAC Variants

| Class | Hash | MAC Size | Security | Status |
|-------|------|----------|----------|--------|
| `HmacSha256` | SHA-256 | 32 bytes | 256 bits | ✅ Recommended |
| `HmacSha384` | SHA-384 | 48 bytes | 384 bits | ✅ Recommended |
| `HmacSha512` | SHA-512 | 64 bytes | 512 bits | ✅ Recommended |
| `HmacSha3_256` | SHA3-256 | 32 bytes | 256 bits | ✅ Cross-platform |
| `HmacSha1` | SHA-1 | 20 bytes | 160 bits | ⚠️ Legacy |
| `HmacMd5` | MD5 | 16 bytes | 128 bits | ⚠️ Legacy |

### Constructor

```csharp
public HmacSha256(byte[] key)
```

**Parameters:**
- `key` - The secret key (any length; keys longer than the hash block size are hashed first)

### Factory Method

```csharp
public static HmacSha256 Create(byte[] key)
```

### Static One-Shot

```csharp
public static byte[] Hash(byte[] key, byte[] data)
```

### Usage Examples

```csharp
byte[] key = new byte[32];
RandomNumberGenerator.Fill(key);
byte[] message = Encoding.UTF8.GetBytes("Hello, World!");

// One-shot API
byte[] tag = HmacSha256.Hash(key, message);

// Instance-based API
using var hmac = HmacSha256.Create(key);
byte[] mac = hmac.ComputeHash(message);

// Streaming API (IMac interface)
using var hmac = HmacSha256.Create(key);
hmac.Update(chunk1);
hmac.Update(chunk2);
byte[] result = new byte[hmac.MacSize];
hmac.Finalize(result);

// Reuse with same key
hmac.Reset();
hmac.Update(newData);
hmac.Finalize(result);
```

### HMAC-SHA3-256 (Cross-Platform)

Unlike .NET's built-in `HMACSHA3_256` which requires Windows 11+ or OpenSSL 1.1.1+, the CryptoHives implementation works on all platforms:

```csharp
using var hmac = HmacSha3_256.Create(key);
byte[] mac = hmac.ComputeHash(message);
```

### Generic HMAC with Any Hash

The `HmacCore` base class works with any `HashAlgorithm` from the library. Create custom HMAC variants by subclassing:

```csharp
public sealed class HmacSm3 : HmacCore
{
    public HmacSm3(byte[] key) : base("HMAC-SM3", SM3.Create(), SM3.Create(), key) { }
}
```

---

## AES-CMAC (Cipher-based MAC)

AES-CMAC is a MAC based on the AES block cipher, defined in NIST SP 800-38B and RFC 4493. Unlike HMAC, it computes the tag in a single pass and does not require a hash function.

> **Note:** .NET does not provide a portable CMAC implementation. This is a CryptoHives differentiator.

### Class Declaration

```csharp
public sealed class AesCmac : IMac
```

### Properties

| Property | Value |
|----------|-------|
| MAC Size | 128 bits (16 bytes) |
| Key Sizes | 128, 192, or 256 bits |
| Block Size | 128 bits (AES) |
| Hardware Accel. | AES-NI when available |

### Constructor

```csharp
public AesCmac(byte[] key)
public AesCmac(ReadOnlySpan<byte> key)
```

**Parameters:**
- `key` - The secret key (16, 24, or 32 bytes for AES-128/192/256)

### Factory Method

```csharp
public static AesCmac Create(byte[] key)
```

### Static One-Shot

```csharp
public static byte[] Hash(byte[] key, byte[] data)
```

### Usage Examples

```csharp
byte[] key = new byte[16]; // AES-128
RandomNumberGenerator.Fill(key);
byte[] message = Encoding.UTF8.GetBytes("Hello, World!");

// One-shot API
byte[] tag = AesCmac.Hash(key, message);

// Instance-based API
using var cmac = AesCmac.Create(key);
byte[] mac = cmac.ComputeHash(message);

// Streaming API
using var cmac = AesCmac.Create(key);
cmac.Update(chunk1);
cmac.Update(chunk2);
byte[] result = new byte[cmac.MacSize];
cmac.Finalize(result);
```

### AES-256 CMAC

```csharp
byte[] key = new byte[32]; // AES-256
RandomNumberGenerator.Fill(key);

using var cmac = AesCmac.Create(key);
byte[] mac = cmac.ComputeHash(message);
```

---

## AES-GMAC (Galois MAC)

AES-GMAC is the authentication-only mode of AES-GCM, defined in NIST SP 800-38D. It produces a 128-bit tag using the Galois field multiplication (GHASH) used in GCM.

> **Note:** .NET does not provide a standalone GMAC class. This is a CryptoHives differentiator.

### Class Declaration

```csharp
public sealed class AesGmac : IDisposable
```

### Properties

| Property | Value |
|----------|-------|
| MAC Size | 128 bits (16 bytes) |
| Key Sizes | 128, 192, or 256 bits |
| Nonce Size | 96 bits (12 bytes) |
| Hardware Accel. | AES-NI + PCLMULQDQ |

### Constructor

```csharp
public AesGmac(ReadOnlySpan<byte> key)
```

**Parameters:**
- `key` - The secret key (16, 24, or 32 bytes)

### Factory Method

```csharp
public static AesGmac Create(byte[] key)
```

### Usage Examples

```csharp
byte[] key = new byte[16];
RandomNumberGenerator.Fill(key);
byte[] nonce = new byte[12]; // MUST be unique per message
RandomNumberGenerator.Fill(nonce);
byte[] data = Encoding.UTF8.GetBytes("authenticated data");

// Compute tag
using var gmac = AesGmac.Create(key);
byte[] tag = gmac.ComputeTag(nonce, data);

// Verify tag
bool valid = gmac.VerifyTag(nonce, data, tag);
```

### Important: Nonce Requirements

**Never reuse a nonce with the same key.** Each GMAC invocation must use a unique 12-byte nonce. Nonce reuse completely compromises the authentication guarantee.

```csharp
// CORRECT: Generate a fresh nonce for each message
byte[] nonce = new byte[12];
RandomNumberGenerator.Fill(nonce);

// WRONG: Reusing the same nonce with the same key
// byte[] nonce = new byte[12]; // reused - INSECURE!
```

---

## BLAKE2 MAC

BLAKE2b and BLAKE2s support built-in keyed hashing mode for message authentication.

### Blake2b Keyed Mode

```csharp
public static Blake2b Create(byte[]? key = null, int hashSize = 64)
```

**Properties:**
- Security: Up to 256 bits (depends on key and output size)
- Key Size: 1-64 bytes
- Output Size: 1-64 bytes

**Usage:**
```csharp
byte[] key = new byte[32]; // Up to 64 bytes
RandomNumberGenerator.Fill(key);

using var blake2b = Blake2b.Create(key: key, hashSize: 32);
byte[] mac = blake2b.ComputeHash(message);
```

### Blake2s Keyed Mode

```csharp
public static Blake2s Create(byte[]? key = null, int hashSize = 32)
```

**Properties:**
- Security: Up to 128 bits (depends on key and output size)
- Key Size: 1-32 bytes
- Output Size: 1-32 bytes

**Usage:**
```csharp
byte[] key = new byte[16]; // Up to 32 bytes
RandomNumberGenerator.Fill(key);

using var blake2s = Blake2s.Create(key: key, hashSize: 16);
byte[] mac = blake2s.ComputeHash(message);
```

---

## BLAKE3 MAC

BLAKE3 provides a dedicated keyed hashing mode for message authentication.

### Blake3 Keyed Mode

```csharp
public static Blake3 CreateKeyed(byte[] key, int outputBytes = 32)
```

**Properties:**
- Security: 128 bits
- Key Size: Exactly 32 bytes
- Output Size: Variable (default 32 bytes)

**Usage:**
```csharp
byte[] key = new byte[32]; // Must be exactly 32 bytes
RandomNumberGenerator.Fill(key);

// Standard 32-byte MAC
using var blake3 = Blake3.CreateKeyed(key);
byte[] mac = blake3.ComputeHash(message);

// Extended 64-byte MAC
using var blake3 = Blake3.CreateKeyed(key, outputBytes: 64);
byte[] longMac = blake3.ComputeHash(message);
```

### BLAKE3 Key Derivation

BLAKE3 also supports key derivation from a context string and input key material:

```csharp
public static Blake3 CreateDeriveKey(string context, int outputBytes = 32)
```

**Usage:**
```csharp
string context = "MyApp 2025-01-01 encryption key";
byte[] inputKeyMaterial = ...; // Your master key or password-derived key

using var blake3 = Blake3.CreateDeriveKey(context);
byte[] derivedKey = blake3.ComputeHash(inputKeyMaterial);
```

---

## Algorithm Comparison

### Security Levels

| Algorithm | Security Strength | Notes |
|-----------|-------------------|-------|
| HMAC-SHA-512 | 512 bits | Maximum HMAC security |
| HMAC-SHA-256 | 256 bits | Most widely used, recommended |
| KMAC256 | 256 bits | Highest security, NIST approved |
| HMAC-SHA3-256 | 256 bits | Cross-platform SHA-3 HMAC |
| AES-CMAC | 128 bits | Cipher-based, single-pass |
| AES-GMAC | 128 bits | Galois field, nonce-required |
| KMAC128 | 128 bits | Good security, NIST approved |
| BLAKE3 keyed | 128 bits | High performance |
| BLAKE2b keyed | Up to 256 bits | Depends on key/output size |
| BLAKE2s keyed | Up to 128 bits | Good for embedded systems |

### Performance

| Algorithm | Relative Speed | Best For |
|-----------|----------------|----------|
| BLAKE3 keyed | Fastest | High-throughput applications |
| BLAKE2b keyed | Very fast | General purpose on 64-bit |
| AES-GMAC | Very fast (AES-NI) | When nonce management is feasible |
| AES-CMAC | Fast (AES-NI) | Protocol compliance (EAP, 802.11i) |
| HMAC-SHA-256 | Moderate | General purpose, widest compatibility |
| HMAC-SHA-512 | Moderate | Maximum security on 64-bit |
| HMAC-SHA3-256 | Moderate | Cross-platform SHA-3 |
| BLAKE2s keyed | Fast | 32-bit and embedded systems |
| KMAC256 | Moderate | Maximum security |
| KMAC128 | Moderate | NIST compliance |

### Feature Comparison

| Feature | HMAC | AES-CMAC | AES-GMAC | KMAC | BLAKE2 | BLAKE3 |
|---------|------|----------|----------|------|--------|--------|
| Variable output | ❌ | ❌ | ❌ | ✅ | ✅ | ✅ |
| Customization string | ❌ | ❌ | ❌ | ✅ | ❌ | ❌ |
| Nonce required | ❌ | ❌ | ✅ | ❌ | ❌ | ❌ |
| NIST approved | ✅ | ✅ | ✅ | ✅ | ❌ | ❌ |
| .NET built-in | ✅ | ❌ | ❌ | Partial | ❌ | ❌ |
| Key derivation | ❌ | ❌ | ❌ | ❌ | ❌ | ✅ |
| Arbitrary key size | ✅ | ❌ | ❌ | ✅ | ❌ | ❌ |
| Hardware accelerated | ❌ | ✅ | ✅ | ❌ | ✅ | ✅ |

---

## Best Practices

### Key Generation

Always use cryptographically secure random number generators for key generation:

```csharp
byte[] key = new byte[32];
RandomNumberGenerator.Fill(key);
```

### Key Storage

- Never hardcode keys in source code
- Use secure key storage (Azure Key Vault, AWS KMS, etc.)
- Rotate keys periodically

### Domain Separation

Use customization strings (KMAC) or different contexts (BLAKE3) to separate different uses of the same key:

```csharp
// Authentication for different message types
using var kmacAuth = KMac256.Create(key, customization: "Auth");
using var kmacEncrypt = KMac256.Create(key, customization: "Encrypt");

// BLAKE3 key derivation with context
using var authKey = Blake3.CreateDeriveKey("MyApp Auth Key");
using var encKey = Blake3.CreateDeriveKey("MyApp Encryption Key");
```

### Verification

When verifying MACs, use constant-time comparison to prevent timing attacks:

```csharp
using System.Security.Cryptography;

bool VerifyMac(byte[] expected, byte[] actual)
{
    return CryptographicOperations.FixedTimeEquals(expected, actual);
}
```

---

## Common Patterns

### Authenticated Encryption

```csharp
public class AuthenticatedMessage
{
    public byte[] Ciphertext { get; set; }
    public byte[] Mac { get; set; }
    
    public static AuthenticatedMessage Create(byte[] key, byte[] plaintext)
    {
        // Encrypt (using your preferred cipher)
        byte[] ciphertext = Encrypt(plaintext);
        
        // Authenticate
        using var kmac = KMac256.Create(key, customization: "Auth");
        byte[] mac = kmac.ComputeHash(ciphertext);
        
        return new AuthenticatedMessage { Ciphertext = ciphertext, Mac = mac };
    }
    
    public bool Verify(byte[] key)
    {
        using var kmac = KMac256.Create(key, customization: "Auth");
        byte[] expectedMac = kmac.ComputeHash(Ciphertext);
        return CryptographicOperations.FixedTimeEquals(Mac, expectedMac);
    }
}
```

### API Request Signing

```csharp
public string SignRequest(byte[] key, string method, string path, string timestamp)
{
    string message = $"{method}:{path}:{timestamp}";
    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
    
    using var blake3 = Blake3.CreateKeyed(key);
    byte[] signature = blake3.ComputeHash(messageBytes);
    
    return Convert.ToBase64String(signature);
}
```

### Session Token Generation

```csharp
public byte[] GenerateSessionKey(byte[] masterKey, string userId, DateTime expiry)
{
    string context = $"session:{userId}:{expiry:O}";
    using var blake3 = Blake3.CreateDeriveKey(context);
    return blake3.ComputeHash(masterKey);
}
```

---

## See Also

- [Hash Algorithms](hash-algorithms.md)
- [Cipher Algorithms](cipher-algorithms.md)
- [Cryptography Package Overview](index.md)
- [KMAC Specifications](specs/NIST-SP-800-185.md)
- [HMAC Specification (RFC 2104)](specs/RFC-2104.md)
- [CMAC Specification (SP 800-38B)](specs/NIST-SP-800-38B.md)
- [HMAC Test Vectors](specs/HMAC-vectors.md)
- [CMAC Test Vectors](specs/CMAC-vectors.md)

---

© 2026 The Keepers of the CryptoHives
