# macOS Arm64 Apple M4 Hash Benchmarks

## Machine Profile

[!INCLUDE[](machine-spec.md)]

BenchmarkDotNet measurements for all hash algorithm implementations in `CryptoHives.Foundation.Security.Cryptography`. Each algorithm is benchmarked across representative payload sizes (128 bytes through 128 KiB) to capture both latency and throughput characteristics.

Implementations are compared against:
- **OS** — .NET's built-in `System.Security.Cryptography` (backed by Apple CommonCrypto on macOS)
- **BouncyCastle** — BouncyCastle C# library
- **Native** — Platform-specific native libraries (e.g., blake3-dotnet)
- **Managed** — CryptoHives managed implementation (scalar)
- **SIMD** — CryptoHives SIMD variants (ArmSha256, Neon, Arm64)

## Highlights

| Family | Leader | Key Insight |
|--------|--------|-------------|
| **SHA-2** | OS (CommonCrypto) | Apple Silicon SHA hardware ~2.2× faster than ArmSha256 at 128 B; ArmSha256 is ~2.6× faster than Scalar at 128 B and ~7.3× faster at 128 KiB |
| **SHA-3/Keccak** | CryptoHives Arm64 | Arm64 variant beats BouncyCastle at all sizes; Scalar on parity with BouncyCastle at bulk |
| **BLAKE2b/2s** | BouncyCastle | BouncyCastle ~2× faster than Neon at 128 KiB; Neon ~1.75× faster than Managed |
| **BLAKE3** | Native (Rust) | Rust ~5.4× faster than BouncyCastle at 128 KiB; Neon ~2.6× faster than BouncyCastle |
| **Streebog** | Managed | ~1.7× faster than OpenGost; ~2.1× faster than BouncyCastle |
| **Kupyna** | Managed | ~1.5× faster than BouncyCastle at all sizes |
| **KMAC** | Managed | ~1.9× faster than BouncyCastle at 128 B; competitive at bulk sizes |
| **Ascon** | Managed | ~42% faster than BouncyCastle across all input sizes |
| **Whirlpool** | Managed | ~4.9× faster than BouncyCastle; ~2.2× faster than Hashify .NET |

---

## SHA-2 Family

On Apple M4, `System.Security.Cryptography` is backed by Apple CommonCrypto which uses Apple Silicon hardware SHA acceleration. At 128 B, OS (83 ns) is ~2.2× faster than `ArmSha256` (182 ns). The `ArmSha256` managed variant maps directly to the ARM Cryptography Extension `SHA256H`/`SHA256H2`/`SHA256SU0`/`SHA256SU1` instructions and is **2.6× faster than the scalar `Managed` path** (182 ns vs 473 ns at 128 B) and **7.3× faster at 128 KiB** (44 μs vs 321 μs). The remaining gap to OS is due to Apple's proprietary SHA pipelining inside CommonCrypto, which is not accessible via the standard ARM intrinsics.

CryptoHives-Scalar outperforms BouncyCastle by ~20–24% across all sizes — consistent with the x86 result.

**Key observations:**
- **OS**: Apple Silicon hardware SHA — ~2.2× faster than ArmSha256 at 128 B; ~12% faster at 128 KiB
- **ArmSha256**: Uses `SHA256H`/`SHA256H2` ARM Crypto Extension instructions; ~2.6× faster than Scalar at 128 B; ~7.3× faster at 128 KiB
- **CryptoHives-Scalar**: ~20–24% faster than BouncyCastle across all sizes
- **BouncyCastle**: ~7× slower than OS at 128 B (590 ns vs 83 ns); ~31% slower than Scalar at 128 KiB

### SHA-224
[!INCLUDE[](sha224.md)]

### SHA-256
[!INCLUDE[](sha256.md)]

### SHA-384
[!INCLUDE[](sha384.md)]

### SHA-512
[!INCLUDE[](sha512.md)]

### SHA-512/224
[!INCLUDE[](sha512-224.md)]

### SHA-512/256
[!INCLUDE[](sha512-256.md)]

---

## Keccak-derived Families

On Apple M4, the CryptoHives **Arm64** Keccak variant is the fastest managed implementation, beating BouncyCastle at all payload sizes (e.g., 147 μs vs 151 μs at 128 KiB for SHA3-256). The scalar `Managed` path is on parity with BouncyCastle at bulk sizes (~2% difference), while the Arm64 path stays ~2–3% ahead. This is the reverse of the x86 pattern — on x86, the scalar path is ~30% faster than OS SHA-3; here there is no OS SHA-3 reference and both managed paths operate at similar throughput.

**Key observations:**
- **CryptoHives Arm64**: Fastest managed option — beats BouncyCastle at all sizes (~6% at 128 B, ~2.4% at 128 KiB for SHA3-256)
- **CryptoHives Scalar**: On parity with BouncyCastle at bulk sizes; ~6% behind at 128 B
- No OS SHA-3 comparison available (macOS CommonCrypto does not expose SHA-3 via .NET in current releases)
- All Keccak variants (SHA-3, SHAKE, cSHAKE, TurboSHAKE, KT) share the same optimized core

### SHA-3 Family

#### SHA3-224
[!INCLUDE[](sha3-224.md)]

#### SHA3-256
[!INCLUDE[](sha3-256.md)]

#### SHA3-384
[!INCLUDE[](sha3-384.md)]

#### SHA3-512
[!INCLUDE[](sha3-512.md)]

### Keccak Family

#### Keccak-256
[!INCLUDE[](keccak256.md)]

#### Keccak-384
[!INCLUDE[](keccak384.md)]

#### Keccak-512
[!INCLUDE[](keccak512.md)]

### SHAKE Family

#### SHAKE128
[!INCLUDE[](shake128.md)]

#### SHAKE256
[!INCLUDE[](shake256.md)]

### cSHAKE Family

#### cSHAKE128
[!INCLUDE[](cshake128.md)]

#### cSHAKE256
[!INCLUDE[](cshake256.md)]

### KangarooTwelve Family

#### KT128
[!INCLUDE[](kt128.md)]

#### KT256
[!INCLUDE[](kt256.md)]

### TurboSHAKE Family

#### TurboSHAKE128
[!INCLUDE[](turboshake128.md)]

#### TurboSHAKE256
[!INCLUDE[](turboshake256.md)]

---

## BLAKE2 Family

BouncyCastle leads the BLAKE2 benchmarks on Apple M4 — its JIT-compiled implementation is ~2× faster than the CryptoHives NEON path at 128 KiB. The CryptoHives NEON variant uses `Vector128<ulong>` G-function mixing with `AdvSimd` rotate-and-shift sequences, providing ~1.75× speedup over the scalar Managed path. The `Konscious` reference library is the slowest across most sizes and allocates heavily (~130 KB per 128 KiB hash call).

**Key observations:**
- **BouncyCastle**: ~2× faster than Neon at 128 KiB; ~56% faster at 128 B
- **Neon**: ~1.75× faster than Managed scalar at 128 KiB; zero allocation
- **Managed**: Scalar fallback for non-SIMD platforms; zero allocation
- **Konscious**: Allocates ~130 KB per 128 KiB call; slowest option

### BLAKE2b-256
[!INCLUDE[](blake2b256.md)]

### BLAKE2b-512
[!INCLUDE[](blake2b512.md)]

### BLAKE2s-128
[!INCLUDE[](blake2s128.md)]

### BLAKE2s-256
[!INCLUDE[](blake2s256.md)]

---

## BLAKE3

BLAKE3 is a modern hash function designed for extreme parallelism. At 128 KiB, the **Native (Rust)** variant via `blake3-dotnet` is **~5.4× faster than BouncyCastle** and **~2.6× faster than the NEON path** (52.6 μs vs 283 μs). The gap is smaller than on x86 (where the Rust build uses AVX-512 `hash_many` for ~12× advantage) because the ARM Rust build uses a single-threaded NEON path comparable in architecture to the CryptoHives Neon path — the key difference is that the Rust build also enables tree-hash parallelism via NEON-based chunk merging at 128 KiB, while the CryptoHives implementation processes chunks sequentially.

The CryptoHives `Neon` path uses `Vector128<uint>` for the BLAKE3 compression function, yielding **~2.6× speedup over BouncyCastle at 128 KiB** (283 μs vs 729 μs). The scalar `Managed` path is ~1.4× faster than BouncyCastle at 128 B and ~1.3× at 128 KiB.

> ⚠️ **Note**: The macOS benchmarks in this run were produced before the `Reset(bool)` allocation fix landed. The `Neon` and `Scalar` rows currently report 24 B allocated per call. This is a known stale artifact — the fix is confirmed zero-allocation on Windows. These benchmarks will be updated after the next macOS run.

[!INCLUDE[](blake3.md)]

---

## Ascon Family

Ascon is a lightweight NIST standard (2023) designed for constrained environments. The CryptoHives managed implementation is **~42% faster than BouncyCastle** at all input sizes (128 B through 128 KiB) — a stronger margin than on x86 Windows (~33%). This appears to be due to Apple M4's efficient branch prediction and low-latency ALU pipeline fitting Ascon's simple 5-word permutation structure very well.

### Ascon-Hash256
[!INCLUDE[](asconhash256.md)]

### Ascon-XOF128
[!INCLUDE[](asconxof128.md)]

---

## KMAC Family

KMAC (NIST SP 800-185) is a Keccak-based keyed hash function. On Apple M4, the Managed CryptoHives implementation is **~1.9× faster than BouncyCastle at 128 B** and leads up to ~1 KiB. At larger sizes (128 KiB), the gap narrows to near parity (~BouncyCastle 1.7% faster). This differs from x86 where Managed leads at all sizes. The convergence at bulk sizes reflects the Keccak permutation throughput being similar after the per-call overhead is amortized.

### KMAC128
[!INCLUDE[](kmac128.md)]

### KMAC256
[!INCLUDE[](kmac256.md)]

---

## Legacy Algorithms

MD5 and SHA-1 are provided **exclusively for backward compatibility** with legacy protocols and file formats. Both algorithms have known cryptographic weaknesses:

- **MD5**: Vulnerable to collision attacks since 2004; should not be used for security
- **SHA-1**: Collision attacks demonstrated in 2017 (SHAttered); deprecated by NIST

On Apple M4, BouncyCastle leads MD5 at small sizes (~20% faster than OS at 128 B). For SHA-1, OS leads clearly (~45% faster than BouncyCastle and Managed at 128 B). The OS CommonCrypto benefits from Apple's hardware AES-based SHA-1 acceleration.

### MD5
[!INCLUDE[](md5.md)]

### SHA-1
[!INCLUDE[](sha1.md)]
