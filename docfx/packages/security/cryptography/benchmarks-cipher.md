# Cipher Algorithm Benchmarks

BenchmarkDotNet measurements for all cipher algorithm implementations in `CryptoHives.Foundation.Security.Cryptography`. Each algorithm is benchmarked across representative payload sizes (128 bytes through 128 KiB) to capture both latency and throughput characteristics.

Implementations are compared against:
- **OS** — .NET's built-in `System.Security.Cryptography` (backed by CNG/OpenSSL/SymCrypt)
- **BouncyCastle** — BouncyCastle C# library
- **Managed** — CryptoHives managed implementation (scalar T-table AES, 4-bit Shoup GHASH)
- **AES-NI** — CryptoHives hardware-accelerated implementation (AES-NI + PCLMULQDQ intrinsics)
- **SSE2** / **SSSE3** / **AVX2** — CryptoHives SIMD variants for ChaCha20 family

## Machine profile

[!INCLUDE[](benchmarks/machine-spec.md)]

## Highlights

| Family | Leader | Key Insight |
|--------|--------|-------------|
| **ChaCha20** | Managed AVX2 | AVX2 ~3× faster than BouncyCastle; SSSE3 ~1.7×; zero allocation |
| **ChaCha20-Poly1305** | Managed AVX2 | ~1.7× faster than OS at 128 KiB; zero allocation |
| **XChaCha20-Poly1305** | Managed AVX2 | Same core as ChaCha20-Poly1305; negligible overhead for extended nonce |
| **AES-CBC** | AES-NI | Decrypt on par with OS at 128 KiB; **~9× faster than OS at 128 B**; zero allocation |
| **AES-GCM** | AES-NI | Faster than OS at 128 B (~1.6×); 14–16× faster than Managed; PCLMULQDQ GHASH |
| **AES-CCM** | AES-NI | ~3× faster than Managed; zero allocation; no OS adapter available |

---

## Stream Ciphers

### ChaCha20

ChaCha20 is a stream cipher designed by Daniel J. Bernstein. The CryptoHives SSSE3 implementation processes four state rows as `Vector128<uint>` vectors, yielding ~1 GB/s throughput on modern x86 CPUs. The AVX2 path processes two blocks in parallel using `Vector256<uint>`. The scalar fallback path is ~3.4× slower but fully portable.

**Key observations:**
- **AVX2** is the fastest at all sizes, ~3× faster than BouncyCastle at 128 KiB
- **SSSE3** is ~1.7× faster than BouncyCastle, processes single blocks via `Vector128<uint>`
- **BouncyCastle** allocates ~2× the input size per call
- **Managed**, **SSSE3**, and **AVX2** paths are zero-allocation

[!INCLUDE[](benchmarks/chacha20.md)]

---

## Block Ciphers

### AES-128-CBC

AES-CBC (Cipher Block Chaining) is the most widely deployed AES mode. The CryptoHives **AES-NI** implementation uses hardware `AESENC`/`AESDEC` instructions with 8-block interleaved decrypt for maximum throughput. CBC decrypt is parallelizable (each ciphertext block decrypts independently), enabling the AES-NI path to match OS performance at large sizes and significantly outperform OS at small sizes due to zero-allocation and no P/Invoke overhead.

**Key observations:**
- **AES-NI**: Fastest overall — on par with OS at 128 KiB decrypt, ~9× faster at 128 B
- **AES-NI Encrypt**: ~2× slower than OS at large sizes (CBC encrypt is inherently serial)
- **Managed**: Zero-allocation T-table AES, outperforms BouncyCastle by ~22%
- **OS**: Allocates 128 bytes per call (P/Invoke overhead)

[!INCLUDE[](benchmarks/aes-cbc-128.md)]

### AES-256-CBC

AES-256-CBC uses 14 rounds (vs 10 for AES-128), adding ~25-30% overhead. The AES-NI decrypt path achieves parity with OS at 128 KiB.

[!INCLUDE[](benchmarks/aes-cbc-256.md)]

---

## AEAD Ciphers (Authenticated Encryption)

Authenticated Encryption with Associated Data (AEAD) ciphers provide both confidentiality and authenticity in a single operation. All CryptoHives AEAD implementations are zero-allocation.

### AES-128-GCM

AES-GCM combines the AES block cipher with Galois/Counter Mode authentication. The CryptoHives **AES-NI** implementation uses hardware `AESENC` instructions with 4-block interleaved counter encryption, combined with **PCLMULQDQ**-based GHASH (carry-less multiplication) for hardware-accelerated authentication. This achieves 14–16× speedup over the managed path and outperforms OS at small payload sizes.

**Key observations:**
- **AES-NI**: ~1.2–1.6× faster than OS at 128 B; ~2–3× slower than OS at 128 KiB
- **AES-NI**: 14–16× faster than Managed at 128 KiB, zero allocation
- **Managed**: Uses 4-bit Shoup table GHASH, T-table AES
- **BouncyCastle**: Similar performance to managed, allocates ~1.6 KB per call

[!INCLUDE[](benchmarks/aes-gcm-128.md)]

### AES-192-GCM

[!INCLUDE[](benchmarks/aes-gcm-192.md)]

### AES-256-GCM

AES-256-GCM uses 14 rounds, adding ~20-30% overhead versus AES-128-GCM. The AES-NI path remains faster than OS at small payload sizes.

[!INCLUDE[](benchmarks/aes-gcm-256.md)]

### AES-128-CCM

AES-CCM (Counter with CBC-MAC) combines CTR mode encryption with CBC-MAC authentication. It is widely used in IoT protocols (Bluetooth LE, ZigBee, Thread). The CryptoHives **AES-NI** implementation uses hardware `AESENC` instructions for all block encryption operations (CTR, CBC-MAC, and AAD processing), achieving ~3× speedup over the managed T-table path. No OS adapter is available for comparison.

**Key observations:**
- **AES-NI**: ~3× faster than Managed at 128 KiB, zero allocation
- **Managed**: T-table AES, outperforms BouncyCastle by ~15-20%
- **BouncyCastle**: Allocates ~2.4 KB per call

[!INCLUDE[](benchmarks/aes-ccm-128.md)]

### AES-256-CCM

[!INCLUDE[](benchmarks/aes-ccm-256.md)]

### ChaCha20-Poly1305

ChaCha20-Poly1305 is a software-friendly AEAD cipher (RFC 8439) that excels without hardware acceleration. The CryptoHives SSSE3 implementation outperforms OS (.NET) at 128 KiB, and the AVX2 path is ~1.7× faster than OS, making it the fastest option for software-only authenticated encryption.

**Key observations:**
- **AVX2** ~40% faster than OS at 128 KiB; **SSSE3** ~12% faster than OS
- At smaller sizes (128B), OS is competitive due to lower per-call overhead
- **Managed**, **SSSE3**, and **AVX2** paths are zero-allocation
- BouncyCastle allocates ~2× input size per call

[!INCLUDE[](benchmarks/chacha20-poly1305.md)]

### XChaCha20-Poly1305

XChaCha20-Poly1305 extends ChaCha20-Poly1305 with a 24-byte nonce (vs 12 bytes), making random nonce generation safe. The performance overhead for the HChaCha20 key derivation step is negligible.

**Key observations:**
- Performance nearly identical to ChaCha20-Poly1305
- No OS or BouncyCastle implementations available for comparison
- Zero-allocation in both SSSE3 and Managed paths

[!INCLUDE[](benchmarks/xchacha20-poly1305.md)]

---

## Allocation Summary

All CryptoHives cipher implementations achieve **zero heap allocation** for both encrypt and decrypt operations across all payload sizes.

| Implementation | 128B | 1KB | 8KB | 128KB |
|----------------|------|-----|-----|-------|
| **CryptoHives (AES-NI/SSSE3/Managed)** | 0 B | 0 B | 0 B | 0 B |
| **OS (.NET) — GCM** | 0 B | 0 B | 0 B | 0 B |
| **OS (.NET) — CBC** | 128 B | 128 B | 128 B | 128 B |
| **BouncyCastle** | ~1–3 KB | ~2–5 KB | ~17–19 KB | ~262–265 KB |

---

## See also

- [Hash Benchmarks](benchmarks-hash.md)
- [Cipher Algorithms Reference](cipher-algorithms.md)
- [Hash Algorithms Reference](hash-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
