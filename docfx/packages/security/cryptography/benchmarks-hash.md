# Hash Algorithm Benchmarks

BenchmarkDotNet measurements for all hash algorithm implementations in `CryptoHives.Foundation.Security.Cryptography`. Each algorithm is benchmarked across representative payload sizes (128 bytes through 128 KiB) to capture both latency and throughput characteristics.

Implementations are compared against:
- **OS** — .NET's built-in `System.Security.Cryptography` (backed by CNG/OpenSSL)
- **BouncyCastle** — BouncyCastle C# library
- **Native** — Platform-specific native libraries (e.g., blake3-dotnet)
- **Managed** — CryptoHives managed implementation (scalar)
- **SIMD** — CryptoHives SIMD variants (SSE2, SSSE3, AVX2, AVX-512F)

## Machine profile

[!INCLUDE[](benchmarks/machine-spec.md)]

## Highlights

| Family | Leader | Key Insight |
|--------|--------|-------------|
| **SHA-2** | OS (SHA-NI) | Hardware SHA-NI gives OS ~4.5× advantage; managed beats BouncyCastle by ~13% |
| **SHA-3/Keccak** | Managed | Scalar Keccak outperforms OS by ~30% and SIMD variants by 25–35% |
| **BLAKE2b/2s** | Managed SIMD | BLAKE2s SIMD on parity with BouncyCastle; BLAKE2b AVX2 within ~20% |
| **BLAKE3** | Native (Rust) | Rust interop ~1.4× faster at small inputs, ~12× at large due to multi-chunk parallelism; SSSE3 managed ~4× faster than BouncyCastle |
| **Streebog** | Managed | 1.4–1.8× faster than OpenGost/BouncyCastle |
| **Kupyna** | Managed | T-table optimization beats BouncyCastle by 30–45% |
| **KMAC** | Managed | Managed beats OS by ~30% and BouncyCastle by ~48% at all sizes |
| **Ascon** | Managed | ~33% faster than BouncyCastle across all input sizes |

---

## SHA-2 Family

The OS SHA-256/SHA-512 implementations leverage **SHA-NI hardware instructions** (available on AMD Zen+ and Intel Ice Lake+), providing ~4.5× speedup over any software implementation. For pure managed code, CryptoHives outperforms BouncyCastle by approximately 13% through loop unrolling and hardcoded round constants.

**Key observations:**
- **OS**: Uses SHA-NI hardware acceleration
- **Managed**: Optimized scalar with unrolled rounds
- **BouncyCastle**: Reference scalar implementation

### SHA-224
[!INCLUDE[](benchmarks/sha224.md)]

### SHA-256
[!INCLUDE[](benchmarks/sha256.md)]

### SHA-384
[!INCLUDE[](benchmarks/sha384.md)]

### SHA-512
[!INCLUDE[](benchmarks/sha512.md)]

### SHA-512/224
[!INCLUDE[](benchmarks/sha512-224.md)]

### SHA-512/256
[!INCLUDE[](benchmarks/sha512-256.md)]

---

## Keccak-derived Families

The managed Keccak core uses an optimized **scalar implementation** that outperforms both the OS-provided SHA-3 and SIMD variants (AVX2/AVX-512F). This is unusual—typically SIMD accelerates cryptographic operations—but Keccak's irregular permutation structure doesn't map efficiently to SIMD lanes.

**Key observations:**
- **Managed scalar** is ~30% faster than OS SHA-3 and 25–35% faster than SIMD variants
- SIMD implementations (AVX2/AVX-512F) are provided but disabled by default
- All Keccak-derived algorithms (SHA-3, SHAKE, cSHAKE, TurboSHAKE, KT) share the same optimized core

### SHA-3 Family

#### SHA3-224
[!INCLUDE[](benchmarks/sha3-224.md)]

#### SHA3-256
[!INCLUDE[](benchmarks/sha3-256.md)]

#### SHA3-384
[!INCLUDE[](benchmarks/sha3-384.md)]

#### SHA3-512
[!INCLUDE[](benchmarks/sha3-512.md)]

### Keccak Family

#### Keccak-256
[!INCLUDE[](benchmarks/keccak256.md)]

#### Keccak-384
[!INCLUDE[](benchmarks/keccak384.md)]

#### Keccak-512
[!INCLUDE[](benchmarks/keccak512.md)]

### SHAKE Family

#### SHAKE128
[!INCLUDE[](benchmarks/shake128.md)]

#### SHAKE256
[!INCLUDE[](benchmarks/shake256.md)]

### cSHAKE Family

#### cSHAKE128
[!INCLUDE[](benchmarks/cshake128.md)]

#### cSHAKE256
[!INCLUDE[](benchmarks/cshake256.md)]

### KangarooTwelve Family

#### KT128
[!INCLUDE[](benchmarks/kt128.md)]

#### KT256
[!INCLUDE[](benchmarks/kt256.md)]

### TurboSHAKE Family

#### TurboSHAKE128
[!INCLUDE[](benchmarks/turboshake128.md)]

#### TurboSHAKE256
[!INCLUDE[](benchmarks/turboshake256.md)]

---

## BLAKE2 Family

BouncyCastle leads the BLAKE2 benchmarks due to highly optimized native code. The managed AVX2/SSSE3/SSE2 SIMD implementations are competitive (within ~15% of BouncyCastle or even), while the scalar fallback is significantly slower (~3.5× for BLAKE2b, ~4× for BLAKE2s).

**Key observations:**
- **BouncyCastle**: Highly optimized reference
- **Managed AVX2**: Competitive SIMD implementation
- **Managed scalar**: Fallback for non-SIMD platforms

### BLAKE2b-256
[!INCLUDE[](benchmarks/blake2b256.md)]

### BLAKE2b-512
[!INCLUDE[](benchmarks/blake2b512.md)]

### BLAKE2s-128
[!INCLUDE[](benchmarks/blake2s128.md)]

### BLAKE2s-256
[!INCLUDE[](benchmarks/blake2s256.md)]

---

## BLAKE3

BLAKE3 is a modern hash function designed for extreme parallelism and speed. It can leverage tree hashing to process multiple chunks simultaneously, making it ideal for hashing large files. The **Native (Rust)** variant uses `blake3-dotnet`, which wraps the official Rust implementation via P/Invoke—this is the fastest option and recommended when native dependencies are acceptable.

The managed CryptoHives implementation uses SSSE3 SIMD instructions with optimized state management. At small inputs (128B-1kb), the SSSE3 path is ~1.4× slower than the native Rust implementation and ~9× faster than BouncyCastle. At large inputs (128KB), the gap widens to ~12× because the native implementation parallelizes chunk compression across SIMD lanes (AVX2/AVX-512 `hash_many`), while the managed version processes chunks sequentially.

[!INCLUDE[](benchmarks/blake3.md)]

---

## Ascon Family

Ascon is a lightweight authenticated encryption and hashing family, selected as the **NIST Lightweight Cryptography standard** in 2023. It is designed for constrained environments (IoT, embedded systems) where resources are limited but security is paramount.

The managed implementation is approximately **33% faster** than BouncyCastle across all input sizes, with consistent zero-allocation behavior regardless of input size—ideal for memory-constrained environments.

### Ascon-Hash256
[!INCLUDE[](benchmarks/asconhash256.md)]

### Ascon-XOF128
[!INCLUDE[](benchmarks/asconxof128.md)]

---

## KMAC Family

KMAC (Keccak Message Authentication Code) is defined in NIST SP 800-185 and provides a **Keccak-based keyed hash function**. Like SHA-3, SHAKE, and cSHAKE, KMAC shares the same optimized Keccak permutation core, benefiting from the scalar optimizations described in the Keccak section above.

The managed CryptoHives implementation is the **fastest at all input sizes**, outperforming the OS-provided KMAC by ~30% and BouncyCastle by ~48%. This advantage comes from the highly optimized scalar Keccak core that benefits both the hash computation and the KMAC-specific cSHAKE encoding overhead.

### KMAC128
[!INCLUDE[](benchmarks/kmac128.md)]

### KMAC256
[!INCLUDE[](benchmarks/kmac256.md)]

---

## Legacy Algorithms

MD5 and SHA-1 are provided **exclusively for backward compatibility** with legacy protocols and file formats (e.g., verifying old checksums, interoperability with legacy systems). Both algorithms have known cryptographic weaknesses:

- **MD5**: Vulnerable to collision attacks since 2004; should not be used for security
- **SHA-1**: Collision attacks demonstrated in 2017 (SHAttered); deprecated by NIST

The OS implementations are fastest due to potential hardware acceleration. The managed implementations prioritize correctness and portability over optimization, as these algorithms should only be used for non-security purposes.

### MD5
[!INCLUDE[](benchmarks/md5.md)]

### SHA-1
[!INCLUDE[](benchmarks/sha1.md)]

---

## Regional Standards

These algorithms serve **regulatory compliance requirements** in specific jurisdictions. While not commonly used in Western applications, they are mandatory in their respective regions:

| Algorithm | Region | Use Case |
|-----------|--------|----------|
| **SM3** | China | Required for Chinese government and financial systems (GB/T 32905-2016) |
| **Streebog** | Russia | Russian federal standard GOST R 34.11-2012, required for government communications |
| **Kupyna** | Ukraine | Ukrainian national standard DSTU 7564:2014, required for government systems |
| **LSH** | South Korea | Korean national standard KS X 3262, approved by KCMVP |
| **Whirlpool** | ISO/NESSIE | European cryptographic standard (ISO/IEC 10118-3) |
| **RIPEMD-160** | Europe/Crypto | Used in Bitcoin address generation and some European standards |

The managed Streebog implementation is notably faster (1.4–1.8×) than reference implementations while using less memory—important for embedded systems in constrained environments. The managed Kupyna implementation uses T-table optimization (combining SubBytes, ShiftBytes, and MixColumns) to outperform BouncyCastle by 30–45%.

### SM3
[!INCLUDE[](benchmarks/sm3.md)]

### Streebog-256
[!INCLUDE[](benchmarks/streebog256.md)]

### Streebog-512
[!INCLUDE[](benchmarks/streebog512.md)]

### Whirlpool
[!INCLUDE[](benchmarks/whirlpool.md)]

### RIPEMD-160
[!INCLUDE[](benchmarks/ripemd160.md)]

### Kupyna-256 (DSTU 7564)
[!INCLUDE[](benchmarks/kupyna256.md)]

### Kupyna-384 (DSTU 7564)
[!INCLUDE[](benchmarks/kupyna384.md)]

### Kupyna-512 (DSTU 7564)
[!INCLUDE[](benchmarks/kupyna512.md)]

### LSH-256-256 (KS X 3262)
[!INCLUDE[](benchmarks/lsh256-256.md)]

### LSH-512-256 (KS X 3262)
[!INCLUDE[](benchmarks/lsh512-256.md)]

### LSH-512-512 (KS X 3262)
[!INCLUDE[](benchmarks/lsh512-512.md)]

---

## See also

- [Cipher Benchmarks](benchmarks-cipher.md)
- [Hash Algorithms Reference](hash-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
- [XOF Mode (Extendable-Output)](xof-mode.md)
