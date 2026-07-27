# Windows X64 AMD Ryzen 5 7600X MAC Benchmarks

## Machine Profile

[!INCLUDE[](machine-spec.md)]

BenchmarkDotNet measurements for all MAC (Message Authentication Code) algorithm implementations in `CryptoHives.Foundation.Security.Cryptography`. Each algorithm is benchmarked across representative payload sizes (128 bytes through 128 KiB). KMAC is covered on the [Hash Benchmarks](hash.md) page instead, since it shares the Keccak permutation core with SHA-3/SHAKE and is registered there.

Implementations are compared against:
- **OS** — .NET's built-in `System.Security.Cryptography.HMAC*` (backed by CNG/OpenSSL, hardware-accelerated where available). Not available for the SHA-3 HMAC variants — see below.
- **BouncyCastle** — BouncyCastle C# library
- **CryptoHives-Scalar** — CryptoHives managed implementation

## Highlights

| Family | Leader | Key Insight |
|--------|--------|-------------|
| **HMAC (SHA-2/MD5/SHA-1)** | OS (SHA-NI/hardware) | OS ~2–5× faster than CryptoHives at small inputs; CryptoHives beats BouncyCastle at bulk sizes for every variant, and even beats OS at 128 KiB for HMAC-MD5 |
| **HMAC-SHA3** | CryptoHives-Scalar | No OS comparison available (`HMACSHA3_*` isn't reliably present across this repo's TFM matrix); CryptoHives ~1.1–1.5× faster than BouncyCastle at small inputs, ~1.5× faster at 128 KiB |
| **AES-CMAC** | CryptoHives-Scalar | ~3.6–4.0× faster than BouncyCastle across all sizes |
| **AES-GMAC** | CryptoHives-Scalar | ~9.4× faster than BouncyCastle at 128 B, ~4× faster at 128 KiB |
| **Poly1305** | Mixed | BouncyCastle ~1.2× faster at 128 B (fixed-overhead-dominated); CryptoHives ~1.13× faster at 128 KiB |

---

## HMAC Family

HMAC (RFC 2104) is a generic keyed-hash construction built on top of any CryptoHives `HashAlgorithm`. All 8 variants below share the same `HmacCore` implementation, differing only in the inner/outer hash function.

At small inputs, OS implementations dominate where hardware acceleration exists (SHA-NI for SHA-2, dedicated MD5/SHA-1 hardware paths) — e.g. HMAC-SHA256 at 128 B is 219 ns on OS vs 1,031 ns on CryptoHives, a ~4.7× gap driven almost entirely by the underlying hash, not the HMAC construction itself. At bulk sizes (128 KiB) the picture shifts: CryptoHives consistently beats BouncyCastle (e.g. HMAC-SHA256: 327 μs vs 374 μs), and for HMAC-MD5 specifically, CryptoHives even edges out the OS implementation (195 μs vs 201 μs).

The SHA-3 HMAC variants have no OS comparison row — `System.Security.Cryptography.HMACSHA3_*` availability isn't reliable across this repo's TFM matrix (net48/net8.0/net10.0), matching the precedent already established in `HmacTests.cs`. Here CryptoHives is consistently faster than BouncyCastle: ~1.1–1.5× at small sizes, ~1.5× at 128 KiB.

### HMAC-MD5
[!INCLUDE[](hmac-md5.md)]

### HMAC-SHA1
[!INCLUDE[](hmac-sha1.md)]

### HMAC-SHA256
[!INCLUDE[](hmac-sha256.md)]

### HMAC-SHA384
[!INCLUDE[](hmac-sha384.md)]

### HMAC-SHA512
[!INCLUDE[](hmac-sha512.md)]

### HMAC-SHA3-256
[!INCLUDE[](hmac-sha3-256.md)]

### HMAC-SHA3-384
[!INCLUDE[](hmac-sha3-384.md)]

### HMAC-SHA3-512
[!INCLUDE[](hmac-sha3-512.md)]

---

## AES-CMAC

AES-CMAC (NIST SP 800-38B / RFC 4493) derives a MAC from AES-128 in CBC-MAC mode with subkey derivation to avoid length-extension issues. CryptoHives is **~3.6–4.0× faster than BouncyCastle** across every size tested (166 ns vs 590 ns at 128 B; 145 μs vs 571 μs at 128 KiB) — the gap widens slightly at bulk sizes since BouncyCastle's generic `CMac` wrapper carries more per-block overhead than CryptoHives' AES-NI-backed fast path.

[!INCLUDE[](aes-cmac.md)]

---

## AES-GMAC

AES-GMAC (NIST SP 800-38D) is AES-GCM with an empty plaintext — the tag authenticates associated data only, with no ciphertext produced. It requires a unique nonce per invocation, same as GCM. CryptoHives is **~9.4× faster than BouncyCastle at 128 B** (79 ns vs 747 ns) and **~4.0× faster at 128 KiB** (35.5 μs vs 143 μs), reflecting CryptoHives' AES-NI/PCLMULQDQ-accelerated GHASH versus BouncyCastle's software GCM implementation.

[!INCLUDE[](aes-gmac.md)]

---

## Poly1305

Poly1305 (RFC 8439) is a standalone one-time-key MAC, most commonly paired with ChaCha20 (see the [ChaCha20-Poly1305](cipher.md) AEAD benchmarks for that combination). Benchmarked here standalone with a fixed key. This is the one MAC family where BouncyCastle wins at small inputs — **~1.2× faster at 128 B** (85 ns vs 101 ns), since Poly1305's per-call overhead is tiny enough that fixed constant-factor differences dominate. At bulk sizes the ordering flips: CryptoHives is **~1.13× faster at 128 KiB** (64.0 μs vs 72.4 μs) as raw field-arithmetic throughput starts to matter more than per-call overhead.

[!INCLUDE[](poly1305.md)]

---

## See also

- [Hash Algorithm Benchmarks](hash.md)
- [Cipher Algorithm Benchmarks](cipher.md)
- [MAC Algorithms Reference](../../mac-algorithms.md)
