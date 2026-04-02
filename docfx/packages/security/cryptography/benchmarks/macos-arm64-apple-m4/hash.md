# macOS Arm64 Apple M4 Hash Benchmarks

## Machine Profile

[!INCLUDE[](machine-spec.md)]

BenchmarkDotNet measurements for all hash algorithm implementations in `CryptoHives.Foundation.Security.Cryptography`. Each algorithm is benchmarked across representative payload sizes (128 bytes through 128 KiB) to capture both latency and throughput characteristics.

Implementations are compared against:
- **OS** — .NET's built-in `System.Security.Cryptography` (backed by Apple CommonCrypto on macOS)
- **BouncyCastle** — BouncyCastle C# library
- **Native** — Platform-specific native libraries (e.g., blake3-dotnet)
- **Managed** — CryptoHives managed implementation (scalar)
- **SIMD** — CryptoHives SIMD variants (ArmSha256, Neon)

## Highlights

| Family | Leader | Key Insight |
|--------|--------|-------------|
| **SHA-2** | OS (ArmSha256) | Apple CommonCrypto leads: ~2× faster at 128 B, ~13% at 128 KiB; ArmSha256 managed path matches scalar Managed speed |
| **SHA-3/Keccak** | BouncyCastle | BouncyCastle slightly faster than Managed (~6% at bulk sizes); **opposite pattern to x86** where scalar Managed leads |
| **BLAKE2b/2s** | BouncyCastle | BouncyCastle ~2× faster than Neon at 128 KiB; Neon ~1.75× faster than Managed |
| **BLAKE3** | Native (Rust) | Rust ~5.4× faster than BouncyCastle at 128 KiB; Neon ~2.5× faster than BouncyCastle |
| **Streebog** | Managed | ~1.7× faster than OpenGost; ~2.1× faster than BouncyCastle |
| **Kupyna** | Managed | ~1.5× faster than BouncyCastle at all sizes |
| **KMAC** | Managed | ~1.9× faster than BouncyCastle at 128 B; competitive at bulk sizes |
| **Ascon** | Managed | ~42% faster than BouncyCastle across all input sizes |
| **Whirlpool** | Managed | ~4.9× faster than BouncyCastle; ~2.2× faster than Hashify .NET |

---

## SHA-2 Family

On Apple M4, `System.Security.Cryptography` is backed by Apple CommonCrypto which uses the Apple Silicon hardware SHA acceleration. The `ArmSha256` managed variant maps to the ARM Cryptography Extension `SHA256H`/`SHA256H2`/`SHA256SU0`/`SHA256SU1` instructions — but at these sizes the overhead difference mainly stems from the OS call path being highly optimized. The managed `ArmSha256` path provides essentially the same throughput as the scalar `Managed` path (within 1%), suggesting the JIT already eliminates most overhead once SHA-round dispatch is optimized.

**Key observations:**
- **OS**: Apple Silicon hardware SHA — ~2× faster at 128 B; ~13% faster at 128 KiB
- **ArmSha256 / Managed**: Identical throughput; ArmSha256 does not currently provide additional speedup over the scalar path in this .NET version
- **BouncyCastle**: ~3.3× slower than OS at 128 B; slower than Managed by ~9.4× at 128 KiB

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

On Apple M4, BouncyCastle is slightly faster than the CryptoHives managed Keccak core across all payload sizes — the reverse of the x86 Windows result. On x86, the scalar CryptoHives path is ~30% faster than OS SHA-3 due to loop-unrolling and constant elimination that matches well with x86 out-of-order execution. On Apple M4, BouncyCastle's JIT-optimized Keccak permutation is ~6% faster at bulk sizes. Both implementations use scalar arithmetic; neither has an ARM SIMD path yet.

**Key observations:**
- **BouncyCastle**: ~3% faster than Managed at 128 B for SHA3-256; ~6% faster at bulk (1 KiB–128 KiB)
- No OS SHA-3 comparison available (macOS CommonCrypto does not expose SHA-3 via .NET in current releases)
- All Keccak variants (SHA-3, SHA-3/SHAKE, cSHAKE, TurboSHAKE, KT) share the same optimized core

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

BLAKE3 is a modern hash function designed for extreme parallelism. At 128 KiB, the **Native (Rust)** variant via `blake3-dotnet` is **~5.4× faster than BouncyCastle** and **~2.6× faster than the NEON path**. The gap is smaller than on x86 (where the Rust build uses AVX-512 `hash_many` for ~12× advantage) because the ARM Rust build uses a single-threaded NEON path that is comparable in architecture to the CryptoHives Neon path — the key difference is that the Rust build also enables tree-hash parallelism via NEON-based chunk merging at 128 KiB, while the CryptoHives implementation processes chunks sequentially.

The CryptoHives `Neon` path uses `Vector128<uint>` for the BLAKE3 compression function (same G-function as ChaCha20), yielding ~2.5× speedup over BouncyCastle at 128 KiB. The scalar `Managed` path is ~1.4× faster than BouncyCastle at 128 B and ~1.3× at 128 KiB.

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

---

## Regional Standards

These algorithms serve **regulatory compliance requirements** in specific jurisdictions:

| Algorithm | Region | Use Case |
|-----------|--------|----------|
| **SM3** | China | Required for Chinese government and financial systems (GB/T 32905-2016) |
| **Streebog** | Russia | Russian federal standard GOST R 34.11-2012, required for government communications |
| **Kupyna** | Ukraine | Ukrainian national standard DSTU 7564:2014, required for government systems |
| **LSH** | South Korea | Korean national standard KS X 3262, approved by KCMVP |
| **Whirlpool** | ISO/NESSIE | European cryptographic standard (ISO/IEC 10118-3) |
| **RIPEMD-160** | Europe/Crypto | Used in Bitcoin address generation and some European standards |

On Apple M4, the managed Streebog implementation is **~1.7× faster than OpenGost** and **~2.1× faster than BouncyCastle** — consistent with the x86 advantage. Kupyna is **~1.5× faster than BouncyCastle** (vs ~1.3–1.45× on x86). The Whirlpool implementation is outstanding at **~4.9× faster than BouncyCastle** — the most dominant advantage of any regional algorithm on this platform.

### SM3
[!INCLUDE[](sm3.md)]

### Streebog-256
[!INCLUDE[](streebog256.md)]

### Streebog-512
[!INCLUDE[](streebog512.md)]

### Whirlpool
[!INCLUDE[](whirlpool.md)]

### RIPEMD-160
[!INCLUDE[](ripemd160.md)]

### Kupyna-256 (DSTU 7564)
[!INCLUDE[](kupyna256.md)]

### Kupyna-384 (DSTU 7564)
[!INCLUDE[](kupyna384.md)]

### Kupyna-512 (DSTU 7564)
[!INCLUDE[](kupyna512.md)]

### LSH-256-256 (KS X 3262)
[!INCLUDE[](lsh256-256.md)]

### LSH-512-256 (KS X 3262)
[!INCLUDE[](lsh512-256.md)]

### LSH-512-512 (KS X 3262)
[!INCLUDE[](lsh512-512.md)]

---

## XOF Mode

XOF (Extendable Output Function) benchmarks measure the full absorb-then-squeeze cycle: the input is absorbed and an output of equal size is squeezed. The benchmark method is `AbsorbSqueeze`. All CryptoHives XOF implementations are **zero-allocation** regardless of output size. BouncyCastle's XOF implementations allocate an internal output buffer proportional to the squeezed length (e.g., ~150 KB for a 128 KiB squeeze), making them unsuitable for high-frequency streaming use.

### SHAKE Family

SHAKE128 and SHAKE256 (FIPS 202) are variable-output-length extensions of the SHA-3 permutation with security strengths of 128 and 256 bits respectively. SHAKE128 uses a 1344-bit rate (21 blocks × 64 bytes) while SHAKE256 uses a 1088-bit rate — making SHAKE128 ~14% faster for the same output size due to fewer Keccak permutation calls per byte output.

On Apple M4, BouncyCastle leads both variants at all tested sizes. For SHAKE128: BC ~12% faster at 128 B; ~1.64× faster at 128 KiB. For SHAKE256: BC ~11% faster at 128 B; ~1.53× faster at 128 KiB. This follows the same pattern as the fixed-output SHAKE hash benchmarks (BouncyCastle's Keccak permutation marginally outperforms the CryptoHives scalar implementation on Apple Silicon).

**Key observations:**
- **BouncyCastle**: Fastest on Apple M4 but allocates output-proportional buffers (~150 KB at 128 KiB squeeze)
- **Managed**: Zero-allocation; ~1.6× slower than BC at 128 KiB
- SHAKE128 is ~12% faster than SHAKE256 at the same size due to wider rate

#### SHAKE128
[!INCLUDE[](xof-shake128.md)]

#### SHAKE256
[!INCLUDE[](xof-shake256.md)]

---

### cSHAKE Family

cSHAKE128 and cSHAKE256 (NIST SP 800-185) extend SHAKE with domain separation via a function-name string `N` and a customization string `S`, enabling distinct hash functions for different applications from the same permutation. When both strings are empty, cSHAKE degenerates exactly to SHAKE.

Performance is essentially identical to the corresponding SHAKE variants — the customization strings add a one-time padding overhead during initialization, negligible in the benchmarked range. BouncyCastle leads by ~12% at 128 B and ~1.63× at 128 KiB; both implementations are zero-allocation at all sizes for the CryptoHives path.

**Key observations:**
- Performance matches SHAKE128/256 within measurement noise
- **BouncyCastle**: Allocates ~150 KB per 128 KiB squeeze
- **Managed**: Zero-allocation; preserves streaming use-case fitness

#### cSHAKE128
[!INCLUDE[](xof-cshake128.md)]

#### cSHAKE256
[!INCLUDE[](xof-cshake256.md)]

---

### KMAC Family (XOF)

KMAC128 XOF and KMAC256 XOF (NIST SP 800-185) are keyed variants of cSHAKE usable as variable-length PRFs. In XOF mode the output length is not encoded into the padding, enabling stream output of arbitrary length. KMAC128 XOF uses the cSHAKE128 rate (1344 bits); KMAC256 XOF uses the cSHAKE256 rate (1088 bits).

At 128 B absorb + 128 B squeeze, Managed and BouncyCastle are nearly equal (BC ~2% faster) — this is a notable difference from the fixed-output KMAC benchmark where Managed was ~1.9× faster. The larger per-call overhead of the XOF API (absorb + pad + squeeze) dominates at small sizes, favouring neither implementation. At 128 KiB, BC leads by ~1.64×, consistent with the Keccak throughput pattern.

**Key observations:**
- Near parity at 128 B between Managed and BC (within ~2%)
- **BouncyCastle**: Allocates ~130 B at small sizes, ~150 KB at 128 KiB squeeze
- **Managed**: Zero-allocation at all sizes

#### KMAC128
[!INCLUDE[](xof-kmac128.md)]

#### KMAC256
[!INCLUDE[](xof-kmac256.md)]

---

### KangarooTwelve Family (XOF)

KangarooTwelve (KT128 / KT256) are tree-hashing XOFs based on the Keccak permutation with 12 rounds (vs 24 for full SHA-3). The reduced-round design yields ~2× throughput over SHAKE128 while maintaining 128-bit security. No external competitor implementations are available for comparison.

On Apple M4, KT128 XOF delivers approximately the same throughput as SHAKE128 XOF at bulk sizes despite the halved round count, suggesting the M4 execution units are not bottlenecked by round count alone. KT256 follows the same architecture with the narrower cSHAKE256 rate and is marginally slower.

**Key observations:**
- **KT128** ~1.3× faster than SHAKE128 at 128 B; near parity at 128 KiB (permutation throughput parity)
- **KT256** slightly slower than KT128 due to narrower rate (1088-bit vs 1344-bit)
- No BouncyCastle or OS comparison available; zero-allocation

#### KT128
[!INCLUDE[](xof-kt128.md)]

#### KT256
[!INCLUDE[](xof-kt256.md)]

---

### TurboSHAKE Family (XOF)

TurboSHAKE128 and TurboSHAKE256 (IETF RFC 9562) use 12 Keccak rounds with a simplified padding scheme and expose a plain XOF interface with no tree-hashing overhead. They are the simplest and fastest Keccak-family XOFs available in this library.

On Apple M4, TurboSHAKE128 XOF is the **fastest Keccak-based XOF** at all sizes: ~1.37× faster than SHAKE128 at bulk sizes and leads KT128 across all payload sizes. No external competitor implementations are available.

**Key observations:**
- Fastest Keccak XOF in this library on Apple M4
- TurboSHAKE128: 1344-bit rate with 12 rounds
- TurboSHAKE256: 1088-bit rate with 12 rounds; slightly slower
- Zero-allocation; no OS or BouncyCastle comparison available

#### TurboSHAKE128
[!INCLUDE[](xof-turboshake128.md)]

#### TurboSHAKE256
[!INCLUDE[](xof-turboshake256.md)]

---

### BLAKE3 (XOF)

BLAKE3 XOF uses the same ChaCha-based compression function but extends the tree hashing mode to produce output of arbitrary length. The output is derived by repeatedly doubling the output chaining value from the root node. This differs from the fixed-output benchmark, which stops at the root hash.

The **Native (Rust)** implementation via `blake3-dotnet` is dramatically faster — ~7× at 128 B and ~5.8× at 128 KiB — because the Rust output-reader uses parallel chunk generation for the extended output, exploiting multiple NEON lanes simultaneously. The CryptoHives `Neon` path squeezed output sequentially. **Managed** is 1.3× faster than BouncyCastle at 128 B and ~1.3× at 128 KiB.

**Key observations:**
- **Native**: ~7× faster than Managed at 128 B XOF; ~5.8× at 128 KiB
- **Managed**: ~1.3× faster than BouncyCastle across all sizes; zero allocation
- **BouncyCastle**: Slowest XOF option; allocates 56 B per call regardless of output size
- BLAKE3 XOF output is deterministic given key and context — suitable for KDF and stream encryption

[!INCLUDE[](xof-blake3.md)]

---

### Ascon-XOF128

Ascon-XOF128 (NIST Lightweight Cryptography standard 2023) is the XOF variant of the Ascon family using the same 320-bit permutation as Ascon-Hash256. It uses a 128-bit rate, requiring a full 12-round permutation call per 16 bytes of input or output — making it inherently slower than SHAKE/BLAKE XOFs for large outputs.

On Apple M4, the CryptoHives Managed implementation is **~43% faster than BouncyCastle** across all sizes — consistent with the fixed-output Ascon-Hash256 advantage. Zero allocation on both paths.

**Key observations:**
- **Managed**: ~43% faster than BouncyCastle at all sizes; zero-allocation
- Throughput ~3× slower than SHAKE128 at 128 KiB due to the narrow rate (128-bit vs 1344-bit)
- Optimized for memory-constrained environments, not bulk throughput

[!INCLUDE[](xof-asconxof128.md)]
