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
Span<byte> mac = stackalloc byte[32];
kmac.TryComputeHash(message, mac, out _);

// With customization string
using var kmacCustom = KMac128.Create(key, outputBytes: 32, customization: "MyApp v1.0");
Span<byte> macCustom = stackalloc byte[32];
kmacCustom.TryComputeHash(message, macCustom, out _);

// Variable output length
using var kmacLong = KMac128.Create(key, outputBytes: 64);
Span<byte> longMac = stackalloc byte[64];
kmacLong.TryComputeHash(message, longMac, out _);
```

### Incremental Usage

```csharp
using var kmac = KMac128.Create(key, outputBytes: 32, customization: "");

// Process data in chunks — zero allocations
kmac.AppendData(chunk1);
kmac.AppendData(chunk2);
kmac.AppendData(chunk3);

Span<byte> mac = stackalloc byte[32];
kmac.TryGetHashAndReset(mac, out _);
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
Span<byte> mac = stackalloc byte[64];
kmac.TryComputeHash(message, mac, out _);

// With customization string for domain separation
using var kmacCustom = KMac256.Create(key, outputBytes: 64, customization: "Session Authentication");
Span<byte> macCustom = stackalloc byte[64];
kmacCustom.TryComputeHash(message, macCustom, out _);
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
Span<byte> mac = stackalloc byte[32];
blake2b.TryComputeHash(message, mac, out _);
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
Span<byte> mac = stackalloc byte[16];
blake2s.TryComputeHash(message, mac, out _);
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
Span<byte> mac = stackalloc byte[32];
blake3.TryComputeHash(message, mac, out _);

// Extended 64-byte MAC
using var blake3Long = Blake3.CreateKeyed(key, outputBytes: 64);
Span<byte> longMac = stackalloc byte[64];
blake3Long.TryComputeHash(message, longMac, out _);
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
Span<byte> derivedKey = stackalloc byte[32];
blake3.TryComputeHash(inputKeyMaterial, derivedKey, out _);
```

---

## Algorithm Comparison

### Security Levels

| Algorithm | Security Strength | Notes |
|-----------|-------------------|-------|
| KMAC256 | 256 bits | Highest security, NIST approved |
| KMAC128 | 128 bits | Good security, NIST approved |
| BLAKE3 keyed | 128 bits | High performance |
| BLAKE2b keyed | Up to 256 bits | Depends on key/output size |
| BLAKE2s keyed | Up to 128 bits | Good for embedded systems |

### Performance

| Algorithm | Relative Speed | Best For |
|-----------|----------------|----------|
| BLAKE3 keyed | Fastest | High-throughput applications |
| BLAKE2b keyed | Very fast | General purpose on 64-bit |
| BLAKE2s keyed | Fast | 32-bit and embedded systems |
| KMAC256 | Moderate | Maximum security |
| KMAC128 | Moderate | NIST compliance |

### Feature Comparison

| Feature | KMAC | BLAKE2 | BLAKE3 |
|---------|------|--------|--------|
| Variable output | ✅ | ✅ | ✅ |
| Customization string | ✅ | ❌ | ❌ |
| NIST approved | ✅ | ❌ | ❌ |
| Key derivation | ❌ | ❌ | ✅ |
| Arbitrary key size | ✅ | ❌ | ❌ |

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
        Span<byte> mac = stackalloc byte[64];
        kmac.TryComputeHash(ciphertext, mac, out _);

        return new AuthenticatedMessage { Ciphertext = ciphertext, Mac = mac.ToArray() };
    }

    public bool Verify(byte[] key)
    {
        using var kmac = KMac256.Create(key, customization: "Auth");
        Span<byte> expectedMac = stackalloc byte[64];
        kmac.TryComputeHash(Ciphertext, expectedMac, out _);
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
    Span<byte> signature = stackalloc byte[32];
    blake3.TryComputeHash(messageBytes, signature, out _);

    return Convert.ToBase64String(signature);
}
```

### Session Token Generation

```csharp
public byte[] GenerateSessionKey(byte[] masterKey, string userId, DateTime expiry)
{
    string context = $"session:{userId}:{expiry:O}";
    using var blake3 = Blake3.CreateDeriveKey(context);
    Span<byte> sessionKey = stackalloc byte[32];
    blake3.TryComputeHash(masterKey, sessionKey, out _);
    return sessionKey.ToArray();
}
```

---

## See Also

- [Hash Algorithms](hash-algorithms.md)
- [Cryptography Package Overview](index.md)
- [KMAC Specifications](specs/NIST-SP-800-185.md)

---

© 2026 The Keepers of the CryptoHives
