# Cryptography Benchmarks

This page collects the BenchmarkDotNet measurements for every hash implementation that ships with `CryptoHives.Foundation.Security.Cryptography`. Each algorithm family has its own benchmark, measuring performance across representative payload sizes (128 bytes through 128 KiB) to capture both latency and throughput characteristics.

## Updating benchmark documentation

1. Run the cryptography benchmarks (either via the helper script or directly through BenchmarkSwitcher):
   ```powershell
   # Run a specific algorithm family
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family BLAKE

   # Run a single algorithm
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family SHA256

   # Direct invocation
   cd tests/Security/Cryptography
   dotnet run -c Release --framework net10.0 -- --filter *SHA256*
   ```
2. Mirror the freshly generated markdown into the documentation folder:
   ```powershell
   .\scripts\update-benchmark-docs.ps1 -Package Cryptography
   ```
   The script trims the machine header from the BenchmarkDotNet export, writes it once to `benchmarks/machine-spec.md`, and stores each algorithm's benchmark table in its own file.

## Machine profile

[!INCLUDE[](benchmarks/machine-spec.md)]

## Highlights by algorithm family

| Family | Leader | Key Insight |
|--------|--------|-------------|
| **SHA-2** | OS (SHA-NI) | Hardware SHA-NI gives OS ~4–6× advantage; managed beats BouncyCastle by ~5% |
| **SHA-3/Keccak** | Managed | Scalar Keccak outperforms OS and SIMD variants by 15–35% |
| **BLAKE2b/2s** | BouncyCastle | Native optimizations give BouncyCastle ~20% edge; managed SIMD competitive |
| **BLAKE3** | Native (Rust) | Rust interop ~3× faster; managed beats BouncyCastle by ~7× |
| **Streebog** | Managed | 1.4–1.9× faster than OpenGost/BouncyCastle |
| **KMAC** | .NET 9+ | OS KMAC fastest; managed beats BouncyCastle at larger sizes |
| **Ascon** | Managed | Slightly faster than BouncyCastle (~2–3%) |

## Benchmark results by algorithm family

### SHA-2 Family

The OS SHA-256/SHA-512 implementations leverage **SHA-NI hardware instructions** (available on AMD Zen+ and Intel Ice Lake+), providing 4–6× speedup over any software implementation. For pure managed code, CryptoHives outperforms BouncyCastle by approximately 5–6% through loop unrolling and hardcoded round constants.

**Key observations:**
- **OS** (129 ns @ 128B): Uses SHA-NI hardware acceleration
- **Managed** (542 ns @ 128B): Optimized scalar with unrolled rounds
- **BouncyCastle** (572 ns @ 128B): Reference scalar implementation

#### SHA-224
[!INCLUDE[](benchmarks/sha224.md)]

#### SHA-256
[!INCLUDE[](benchmarks/sha256.md)]

#### SHA-384
[!INCLUDE[](benchmarks/sha384.md)]

#### SHA-512
[!INCLUDE[](benchmarks/sha512.md)]

#### SHA-512/224
[!INCLUDE[](benchmarks/sha512-224.md)]

#### SHA-512/256
[!INCLUDE[](benchmarks/sha512-256.md)]

### Keccak-derived Families

The managed Keccak core uses an optimized **scalar implementation** that outperforms both the OS-provided SHA-3 and SIMD variants (AVX2/AVX-512F). This is unusual—typically SIMD accelerates cryptographic operations—but Keccak's irregular permutation structure doesn't map efficiently to SIMD lanes.

**Key observations:**
- **Managed scalar** is 15–20% faster than OS SHA-3 and 25–35% faster than SIMD variants
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

### BLAKE2 Family

BouncyCastle leads the BLAKE2 benchmarks due to highly optimized native code. The managed AVX2/SSSE3/SSE2 SIMD implementations are competitive (within 15–25% of BouncyCastle), while the scalar fallback is significantly slower (~3× for BLAKE2b, ~5× for BLAKE2s).

**Key observations:**
- **BouncyCastle** (137 ns @ 128B for BLAKE2b-256): Highly optimized reference
- **Managed AVX2** (146 ns @ 128B): Competitive SIMD implementation
- **Managed scalar** (399 ns @ 128B): Fallback for non-SIMD platforms

#### BLAKE2b-256
[!INCLUDE[](benchmarks/blake2b256.md)]

#### BLAKE2b-512
[!INCLUDE[](benchmarks/blake2b512.md)]

#### BLAKE2s-128
[!INCLUDE[](benchmarks/blake2s128.md)]

#### BLAKE2s-256
[!INCLUDE[](benchmarks/blake2s256.md)]

### BLAKE3

BLAKE3 is a modern hash function designed for extreme parallelism and speed. It can leverage tree hashing to process multiple chunks simultaneously, making it ideal for hashing large files. The **Native (Rust)** variant uses `blake3-dotnet`, which wraps the official Rust implementation via P/Invoke—this is the fastest option and recommended when native dependencies are acceptable.

The managed CryptoHives implementation uses SSSE3 SIMD instructions and significantly outperforms BouncyCastle (3–7×), but trails the native Rust version by ~3× because the managed implementation does not yet parallelize chunk processing across threads. Tree finalization and counter-mode XOF output are fully implemented. For most use cases, the managed version provides excellent performance without native dependencies.

[!INCLUDE[](benchmarks/blake3.md)]

### Legacy Algorithms

MD5 and SHA-1 are provided **exclusively for backward compatibility** with legacy protocols and file formats (e.g., verifying old checksums, interoperability with legacy systems). Both algorithms have known cryptographic weaknesses:

- **MD5**: Vulnerable to collision attacks since 2004; should not be used for security
- **SHA-1**: Collision attacks demonstrated in 2017 (SHAttered); deprecated by NIST

The OS implementations are fastest due to potential hardware acceleration. The managed implementations prioritize correctness and portability over optimization, as these algorithms should only be used for non-security purposes.

#### MD5
[!INCLUDE[](benchmarks/md5.md)]

#### SHA-1
[!INCLUDE[](benchmarks/sha1.md)]

### Regional Standards

These algorithms serve **regulatory compliance requirements** in specific jurisdictions. While not commonly used in Western applications, they are mandatory in their respective regions:

| Algorithm | Region | Use Case |
|-----------|--------|----------|
| **SM3** | China | Required for Chinese government and financial systems (GB/T 32905-2016) |
| **Streebog** | Russia | Russian federal standard GOST R 34.11-2012, required for government communications |
| **Whirlpool** | ISO/NESSIE | European cryptographic standard (ISO/IEC 10118-3) |
| **RIPEMD-160** | Europe/Crypto | Used in Bitcoin address generation and some European standards |

The managed Streebog implementation is notably faster (1.4–1.9×) than reference implementations while using less memory—important for embedded systems in constrained environments.

#### SM3
[!INCLUDE[](benchmarks/sm3.md)]

#### Streebog-256
[!INCLUDE[](benchmarks/streebog256.md)]

#### Streebog-512
[!INCLUDE[](benchmarks/streebog512.md)]

#### Whirlpool
[!INCLUDE[](benchmarks/whirlpool.md)]

#### RIPEMD-160
[!INCLUDE[](benchmarks/ripemd160.md)]

### Ascon Family

Ascon is a lightweight authenticated encryption and hashing family, selected as the **NIST Lightweight Cryptography standard** in 2023. It is designed for constrained environments (IoT, embedded systems) where resources are limited but security is paramount.

The managed implementation performs on par with BouncyCastle, with consistent memory allocation regardless of input size—ideal for memory-constrained environments.

#### Ascon-Hash256
[!INCLUDE[](benchmarks/asconhash256.md)]

#### Ascon-XOF128
[!INCLUDE[](benchmarks/asconxof128.md)]

### KMAC Family

KMAC (Keccak Message Authentication Code) is defined in NIST SP 800-185 and provides a **Keccak-based keyed hash function**. Like SHA-3, SHAKE, and cSHAKE, KMAC shares the same optimized Keccak permutation core, benefiting from the scalar optimizations described in the Keccak section above.

On .NET 9+, the OS provides native KMAC support which is fastest for small inputs due to lower initialization overhead. However, the managed CryptoHives implementation scales better at larger payload sizes (8KB+), where the optimized Keccak core dominates the workload. For throughput-critical applications processing large data, the managed implementation is the best choice.

#### KMAC128
[!INCLUDE[](benchmarks/kmac128.md)]

#### KMAC256
[!INCLUDE[](benchmarks/kmac256.md)]

### XOF Mode Benchmarks

The XOF (extendable-output function) benchmarks measure squeeze throughput via the `IExtendableOutput` interface. Each iteration absorbs a fixed **2 KB** of input (two 1 KB blocks), then squeezes a variable number of output bytes (128 B to 128 KB). This isolates the squeeze permutation cost from absorb overhead, which is the defining performance characteristic of XOF algorithms. The fixed-output hash benchmarks above measure `TryComputeHash` with a small fixed digest; these benchmarks focus on the extendable output path.

Implementations include CryptoHives managed, BouncyCastle, OS native, and native Rust (BLAKE3) where available.

#### SHAKE128 XOF
[!INCLUDE[](benchmarks/xof-shake128.md)]

#### SHAKE256 XOF
[!INCLUDE[](benchmarks/xof-shake256.md)]

#### cSHAKE128 XOF
[!INCLUDE[](benchmarks/xof-cshake128.md)]

#### cSHAKE256 XOF
[!INCLUDE[](benchmarks/xof-cshake256.md)]

#### TurboSHAKE128 XOF
[!INCLUDE[](benchmarks/xof-turboshake128.md)]

#### TurboSHAKE256 XOF
[!INCLUDE[](benchmarks/xof-turboshake256.md)]

#### KT128 XOF
[!INCLUDE[](benchmarks/xof-kt128.md)]

#### KT256 XOF
[!INCLUDE[](benchmarks/xof-kt256.md)]

#### KMAC128 XOF
[!INCLUDE[](benchmarks/xof-kmac128.md)]

#### KMAC256 XOF
[!INCLUDE[](benchmarks/xof-kmac256.md)]

#### BLAKE3 XOF
[!INCLUDE[](benchmarks/xof-blake3.md)]

#### Ascon-XOF128 XOF
[!INCLUDE[](benchmarks/xof-asconxof128.md)]

## See also

- [Hash algorithms overview](hash-algorithms.md)
- [MAC algorithms overview](mac-algorithms.md)
- [XOF Mode (Extendable-Output)](xof-mode.md)
- [NIST SP 800-185 (cSHAKE/KMAC)](specs/NIST-SP-800-185.md)
