# Cipher Algorithm Benchmarks

BenchmarkDotNet measurements for all cipher algorithm implementations in `CryptoHives.Foundation.Security.Cryptography`. Each algorithm is benchmarked across representative payload sizes (128 bytes through 128 KiB) to capture both latency and throughput characteristics.

Implementations are compared against:
- **OS** — .NET's built-in `System.Security.Cryptography` (backed by CNG/OpenSSL with AES-NI/CLMUL)
- **BouncyCastle** — BouncyCastle C# library
- **Managed** — CryptoHives managed implementation (scalar)
- **SSE2** — CryptoHives SSE2 SIMD variant

## Machine profile

[!INCLUDE[](benchmarks/machine-spec.md)]

## Highlights

| Family | Leader | Key Insight |
|--------|--------|-------------|
| **ChaCha20** | Managed SSE2 | SSE2 is 2.2× faster than BouncyCastle; zero allocation |
| **ChaCha20-Poly1305** | Managed SSE2 | Beats both OS and BouncyCastle at 128 KiB; zero allocation |
| **XChaCha20-Poly1305** | Managed SSE2 | Same core as ChaCha20-Poly1305; negligible overhead for extended nonce |
| **AES-CBC** | OS (AES-NI) | Managed beats BouncyCastle by ~22%; OS wins with hardware AES-NI |
| **AES-GCM** | OS (AES-NI+CLMUL) | Hardware AES-NI + PCLMULQDQ gives OS significant advantage |
| **AES-CCM** | Managed | Beats BouncyCastle by ~20%; no OS adapter available |

---

## Stream Ciphers

### ChaCha20

ChaCha20 is a stream cipher designed by Daniel J. Bernstein. The CryptoHives SSE2 implementation processes four state rows as `Vector128<uint>` vectors, yielding ~1 GB/s throughput on modern x86 CPUs. The scalar fallback path is ~3.4× slower but fully portable.

**Key observations:**
- **SSE2** is the fastest at all sizes, ~2.2× faster than BouncyCastle
- **BouncyCastle** allocates ~2× the input size per call
- **Managed** and **SSE2** paths are zero-allocation

[!INCLUDE[](benchmarks/chacha20.md)]

---

## Block Ciphers

### AES-128-CBC

AES-CBC (Cipher Block Chaining) is the most widely deployed AES mode. The OS implementation uses **AES-NI** hardware instructions for significant acceleration. The managed CryptoHives implementation uses T-table AES, which outperforms BouncyCastle by ~22% while remaining fully portable.

**Key observations:**
- **OS**: Fastest with AES-NI hardware acceleration
- **Managed**: Zero-allocation, beats BouncyCastle by ~22%
- **BouncyCastle**: Allocates ~2× input size per call

[!INCLUDE[](benchmarks/aes-cbc-128.md)]

### AES-256-CBC

AES-256-CBC uses 14 rounds (vs 10 for AES-128), adding ~25-30% overhead. The relative performance ranking remains the same across all implementations.

[!INCLUDE[](benchmarks/aes-cbc-256.md)]

---

## AEAD Ciphers (Authenticated Encryption)

Authenticated Encryption with Associated Data (AEAD) ciphers provide both confidentiality and authenticity in a single operation. All CryptoHives AEAD implementations are zero-allocation.

### AES-128-GCM

AES-GCM combines the AES block cipher with Galois/Counter Mode authentication. The OS implementation leverages **AES-NI** and **PCLMULQDQ** hardware instructions for GHASH, giving it a significant advantage over software implementations.

**Key observations:**
- **OS**: 10–70× faster than managed due to AES-NI + CLMUL hardware
- **Managed**: Zero-allocation, uses 4-bit Shoup table GHASH
- **BouncyCastle**: Similar performance to managed but allocates ~2× input size

[!INCLUDE[](benchmarks/aes-gcm-128.md)]

### AES-192-GCM

[!INCLUDE[](benchmarks/aes-gcm-192.md)]

### AES-256-GCM

AES-256-GCM uses 14 rounds, adding ~40% overhead versus AES-128-GCM.

[!INCLUDE[](benchmarks/aes-gcm-256.md)]

### AES-128-CCM

AES-CCM (Counter with CBC-MAC) combines CTR mode encryption with CBC-MAC authentication. It is widely used in IoT protocols (Bluetooth LE, ZigBee, Thread). No OS adapter is available for comparison.

**Key observations:**
- **Managed**: Beats BouncyCastle by ~20%, zero allocation
- **BouncyCastle**: Allocates ~2× input size per call

[!INCLUDE[](benchmarks/aes-ccm-128.md)]

### AES-256-CCM

[!INCLUDE[](benchmarks/aes-ccm-256.md)]

### ChaCha20-Poly1305

ChaCha20-Poly1305 is a software-friendly AEAD cipher (RFC 8439) that excels without hardware acceleration. The CryptoHives SSE2 implementation **beats both the OS (.NET) and BouncyCastle** at 128 KiB, making it the fastest option for software-only authenticated encryption.

**Key observations:**
- **SSE2** beats OS by ~10% and BouncyCastle by ~9% at 128 KiB
- At smaller sizes (128B–1KB), OS and BouncyCastle are competitive due to lower per-call overhead
- **Managed** and **SSE2** paths are zero-allocation
- BouncyCastle allocates ~2× input size per call

[!INCLUDE[](benchmarks/chacha20-poly1305.md)]

### XChaCha20-Poly1305

XChaCha20-Poly1305 extends ChaCha20-Poly1305 with a 24-byte nonce (vs 12 bytes), making random nonce generation safe. The performance overhead for the HChaCha20 key derivation step is negligible.

**Key observations:**
- Performance nearly identical to ChaCha20-Poly1305
- No OS or BouncyCastle implementations available for comparison
- Zero-allocation in both SSE2 and Managed paths

[!INCLUDE[](benchmarks/xchacha20-poly1305.md)]

---

## Allocation Summary

All CryptoHives cipher implementations achieve **zero heap allocation** for both encrypt and decrypt operations across all payload sizes.

| Implementation | 128B | 1KB | 8KB | 128KB |
|----------------|------|-----|-----|-------|
| **CryptoHives (Managed/SSE2)** | 0 B | 0 B | 0 B | 0 B |
| **OS (.NET)** | 0 B | 0 B | 0 B | 0 B |
| **BouncyCastle** | ~1–3 KB | ~2–5 KB | ~17–19 KB | ~262–265 KB |

---

## See also

- [Hash Benchmarks](benchmarks-hash.md)
- [Cipher Algorithms Reference](cipher-algorithms.md)
- [Hash Algorithms Reference](hash-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
