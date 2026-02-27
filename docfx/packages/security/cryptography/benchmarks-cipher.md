# Cipher Algorithm Benchmarks

BenchmarkDotNet measurements for all cipher algorithm implementations in `CryptoHives.Foundation.Security.Cryptography`. Each algorithm is benchmarked across representative payload sizes (17 bytes through 128 KiB) to capture both latency and throughput characteristics.

## Implementation Variants

Each cipher family exposes multiple acceleration tiers. The runtime automatically selects the fastest tier supported by the host CPU via `SimdSupport` detection. Callers can also force a specific tier through the `Create(SimdSupport)` factory for testing or compatibility.

### AES Family

| Variant | Instructions | .NET Target | When Selected | Description |
|---------|-------------|-------------|---------------|-------------|
| **Managed** | Scalar | All | No AES-NI support | T-table AES (`AESENC`/`AESDEC` emulated via lookup tables). Fully portable, zero-allocation. ~3–16× slower than AES-NI depending on mode and payload size. |
| **AES-NI** | AES-NI | .NET 8+ | `Aes.IsSupported` | Hardware AES round instructions (`AESENC`, `AESDEC`, `AESIMC`). For CBC, uses 8-block interleaved decrypt for maximum instruction-level parallelism. For GCM/CCM, accelerates counter-mode encryption and CBC-MAC. |
| **AES-NI+PClMul** | AES-NI, PCLMULQDQ | .NET 8+ | `Pclmulqdq.IsSupported` | Adds carry-less multiplication for hardware-accelerated GHASH (GCM authentication). Uses an 8-block stitched pipeline that interleaves AES rounds with GHASH CLMUL operations across alternating CPU ports. Modular reduction uses a 2-CLMUL approach (SymCrypt-style `MODREDUCE`), replacing 26 shift/XOR operations with 2 carry-less multiplies + 6 vector ops. Pre-computes Karatsuba cross-term halves for H¹–H⁸ powers. |
| **AES-NI+PClMulV256** | AES-NI, VPCLMULQDQ, AVX2 | .NET 10+ | `Pclmulqdq.V256.IsSupported` | Extends PClMul with 256-bit carry-less multiply (`VPCLMULQDQ`) and AVX2 256-bit loads/stores. Processes two 128-bit GHASH blocks per CLMUL instruction. Counter blocks are generated in batches of 8 using `Vector256` increments. Best path for payloads ≥256 bytes on CPUs with VPCLMULQDQ support (Ice Lake+). |

### ChaCha20 Family

| Variant | Instructions | .NET Target | When Selected | Description |
|---------|-------------|-------------|---------------|-------------|
| **Managed** | Scalar | All | No SSSE3 support | Quarter-round operations using scalar `uint` arithmetic. Fully portable. ~3–6× slower than SIMD paths. |
| **SSSE3** | SSSE3 | .NET 8+ | `Ssse3.IsSupported` | Maps the 4×4 ChaCha state to four `Vector128<uint>` rows. Uses `Ssse3.Shuffle` byte masks for 16-bit and 8-bit rotations (1 instruction vs 3 for shift+or). Diagonal rounds use `Sse2.Shuffle` to rotate rows. Processes one 64-byte block per iteration. |
| **AVX2** | AVX2, SSSE3 | .NET 8+ | `Avx2.IsSupported` | Dual-block processing: encrypts two 64-byte blocks per iteration using `Vector256<uint>`. Falls back to SSSE3 for a remaining single block. ~1.9× faster than SSSE3 at 128 KiB. |

### When to Use Each Variant

- **Small messages (≤128 B)**: AES-GCM with AES-NI is ~2× faster than OS due to zero P/Invoke overhead and no kernel transition. ChaCha20-Poly1305 AVX2 is competitive with OS at these sizes.
- **Medium messages (256 B–1 KB)**: AES-GCM V256 stitched pipeline engages at >=256 B (>=16 blocks), providing the best throughput. This range covers QUIC (~1.4 KB), WireGuard (~1.4 KB), and IPsec packets.
- **Large messages (8 KB–128 KB)**: AES-GCM V256 decrypt stays within 1.24× of OS. ChaCha20-Poly1305 AVX2 is ~1.7× faster than OS. This range covers TLS records (1–16 KB) and OPC UA chunks (8 KB default).
- **No hardware AES**: Use ChaCha20-Poly1305 — it is designed for software-only execution and outperforms managed AES-GCM by 10–20×.
- **IoT / constrained devices**: AES-CCM with AES-NI provides ~3× speedup over managed. Supports variable nonce (7–13 bytes) and tag sizes.

## Machine Profile

[!INCLUDE[](benchmarks/machine-spec.md)]

## Highlights

| Family | Leader | Key Insight |
|--------|--------|-------------|
| **ChaCha20** | Managed AVX2 | AVX2 ~3× faster than BouncyCastle; SSSE3 ~1.7×; zero allocation |
| **ChaCha20-Poly1305** | Managed AVX2 | ~1.7× faster than OS at 128 KiB; zero allocation |
| **XChaCha20-Poly1305** | Managed AVX2 | Same core as ChaCha20-Poly1305; negligible overhead for extended nonce |
| **AES-CBC** | AES-NI | Decrypt on par with OS at 128 KiB; **~8× faster than OS at 128 B**; zero allocation |
| **AES-GCM** | AES-NI+PClMulV256 | **~2× faster than OS at 128 B encrypt**; V256 decrypt within 1.24× of OS at 128 KiB; 8-block stitched AES+GHASH pipeline |
| **AES-CCM** | AES-NI | ~3× faster than Managed; zero allocation; no OS adapter available |

---

## Stream Ciphers

### ChaCha20

ChaCha20 is a stream cipher designed by Daniel J. Bernstein. Three acceleration tiers are available:

- **AVX2**: Dual-block processing — encrypts two 64-byte keystream blocks per iteration using `Vector256<uint>`. Each block consists of 20 quarter-rounds operating on 8 lanes simultaneously. Falls back to SSSE3 for a remaining single block. Yields ~2 GB/s throughput at 128 KiB.
- **SSSE3**: Single-block processing — maps the 4×4 state matrix to four `Vector128<uint>` rows. Uses `Ssse3.Shuffle` byte masks for 16-bit and 8-bit rotations (1 instruction vs 3 for shift+or). Yields ~1 GB/s throughput.
- **Managed**: Scalar `uint` quarter-round arithmetic. Fully portable across all .NET targets. ~3.4× slower than SSSE3.

**Key observations:**
- **AVX2** is the fastest at all sizes, ~3× faster than BouncyCastle at 128 KiB
- **SSSE3** is ~1.7× faster than BouncyCastle, processes single blocks via `Vector128<uint>`
- **BouncyCastle** allocates 96 B per call; **NaCl.Core** allocates 24 B per call
- **Managed**, **SSSE3**, and **AVX2** paths are zero-allocation

[!INCLUDE[](benchmarks/chacha20.md)]

---

## Block Ciphers

### AES-128-CBC

AES-CBC (Cipher Block Chaining) is the most widely deployed AES mode. Two acceleration tiers are available:

- **AES-NI**: Uses hardware `AESENC`/`AESDEC` instructions. Decrypt uses **8-block interleaving** — 8 ciphertext blocks are loaded and decrypted simultaneously, exploiting the fact that CBC decrypt is embarrassingly parallel (each block decrypts independently using only its predecessor as the XOR mask). This saturates the AES execution unit pipeline (10 rounds × 8 blocks = 80 `AESDEC` instructions in flight). Encrypt remains serial because each plaintext block must be XORed with the previous ciphertext before encryption.
- **Managed**: T-table AES using four 256-entry lookup tables per round. Fully portable, zero-allocation. Outperforms BouncyCastle by ~22%.

**Key observations:**
- **AES-NI**: Fastest overall — on par with OS at 128 KiB decrypt, ~8× faster at 128 B
- **AES-NI Encrypt**: ~2× slower than OS at large sizes (CBC encrypt is inherently serial; OS may use kernel-level optimizations)
- **Managed**: Zero-allocation T-table AES, outperforms BouncyCastle by ~22%
- **OS**: Allocates 128 B per call (P/Invoke marshalling overhead)

[!INCLUDE[](benchmarks/aes-cbc-128.md)]

### AES-256-CBC

AES-256-CBC uses 14 rounds (vs 10 for AES-128), adding ~25-30% overhead. The same 8-block interleaved decrypt and serial encrypt architecture applies. The AES-NI decrypt path achieves parity with OS at 128 KiB.

[!INCLUDE[](benchmarks/aes-cbc-256.md)]

---

## AEAD Ciphers (Authenticated Encryption)

Authenticated Encryption with Associated Data (AEAD) ciphers provide both confidentiality and authenticity in a single operation. All CryptoHives AEAD implementations are zero-allocation.

### AES-128-GCM

AES-GCM combines counter-mode AES encryption (GCTR) with GHASH polynomial authentication over GF(2¹²⁸). Four acceleration tiers are available:

- **AES-NI+PClMulV256** (.NET 10+): The fastest path on CPUs with VPCLMULQDQ (Ice Lake and later). Uses 256-bit carry-less multiply instructions (`VPCLMULQDQ`) to process two GHASH blocks per CLMUL instruction. Counter blocks are generated in batches of 8 using `Vector256<uint>` increments. The stitched loop interleaves 8 blocks of AES encryption with lagged GHASH of the previous 8 ciphertext blocks — AES rounds execute on port 0 while CLMUL operations execute on port 5, achieving near-full utilization of both execution units. Modular reduction uses a 2-CLMUL SymCrypt-style `MODREDUCE` (constant `0xc200000000000000` compensates for reflected bit order). Pre-computed H¹–H⁸ Karatsuba cross-term halves eliminate redundant XORs in the aggregated multiply. Only engages for payloads >128 B (>8 blocks); smaller payloads use the non-stitched path to avoid method call overhead.
- **AES-NI+PClMul** (.NET 8+): Uses 128-bit `PCLMULQDQ` for GHASH with the same 8-block stitched architecture. Falls back to this path when VPCLMULQDQ is unavailable (Haswell through Cannon Lake). Within 1.67× of OS at 128 KiB.
- **AES-NI** (.NET 8+): Hardware AES round instructions for GCTR without CLMUL-accelerated GHASH. Uses the managed 4-bit Shoup table for authentication. 14–16× faster than fully managed at 128 KiB.
- **Managed**: Scalar T-table AES with 4-bit Shoup table GHASH (16-entry reduction table, byte-by-byte multiplication). Fully portable, zero-allocation.

**Key observations:**
- **AES-NI+PClMulV256**: ~2× faster than OS at 128 B encrypt; within 1.24× of OS at 128 KiB decrypt
- **AES-NI+PClMul**: ~2× faster than OS at 128 B encrypt; within 1.67× of OS at 128 KiB
- **AES-NI**: 14–16× faster than Managed at 128 KiB, zero allocation
- **Managed**: Uses 4-bit Shoup table GHASH, T-table AES
- **BouncyCastle**: Uses AES-NI + PCLMULQDQ internally on .NET Core 3.0+; allocates ~1.6 KB per call

[!INCLUDE[](benchmarks/aes-gcm-128.md)]

### AES-192-GCM

AES-192-GCM uses 12 rounds (vs 10 for AES-128), adding ~15-20% overhead. The same stitched pipeline and SIMD dispatch tiers apply. Performance characteristics fall between AES-128-GCM and AES-256-GCM.

[!INCLUDE[](benchmarks/aes-gcm-192.md)]

### AES-256-GCM

AES-256-GCM uses 14 rounds (vs 10 for AES-128), adding ~20-30% overhead per block. The same 4-tier acceleration architecture (V256 → PClMul → AES-NI → Managed) applies. The V256 stitched decrypt path achieves near-parity with OS at 1 KiB (1.00×) and stays within 1.24× at 128 KiB. Encrypt is ~2× faster than OS at 128 B due to the lagged GHASH pipeline and zero P/Invoke overhead. The remaining gap at large sizes is primarily due to OS/SymCrypt using VAES (256-bit AES round instructions) which CryptoHives does not yet use.

[!INCLUDE[](benchmarks/aes-gcm-256.md)]

### AES-128-CCM

AES-CCM (Counter with CBC-MAC) combines CTR mode encryption with CBC-MAC authentication. Unlike GCM, CCM requires two sequential passes (encrypt + MAC or MAC + decrypt), making it inherently less parallelizable. It is widely used in IoT protocols (Bluetooth LE, ZigBee, Thread) and supports variable nonce (7–13 bytes) and tag sizes (4–16 bytes). Two acceleration tiers are available:

- **AES-NI**: Hardware `AESENC` instructions for all block operations — counter-mode encryption, CBC-MAC computation, and AAD processing. Uses `Vector128<byte>` round keys via `MemoryMarshal.Cast` from the shared `uint[]` key schedule. Dispatched via `_useAesNi` bool flag.
- **Managed**: T-table AES for all block operations. Fully portable, zero-allocation.

**Key observations:**
- **AES-NI**: ~3× faster than Managed at 128 KiB, zero allocation
- **Managed**: T-table AES, outperforms BouncyCastle by ~15-20%
- **BouncyCastle**: Allocates ~2.4 KB per call
- No OS adapter available for comparison (System.Security.Cryptography does not expose AES-CCM on all platforms)

[!INCLUDE[](benchmarks/aes-ccm-128.md)]

### AES-256-CCM

AES-256-CCM uses 14 rounds (vs 10 for AES-128). The same AES-NI / Managed dispatch applies. The additional rounds add ~25-30% overhead.

[!INCLUDE[](benchmarks/aes-ccm-256.md)]

### ChaCha20-Poly1305

ChaCha20-Poly1305 is a software-friendly AEAD cipher (RFC 8439) that combines ChaCha20 stream encryption with Poly1305 MAC authentication. It is the recommended AEAD cipher when hardware AES acceleration is unavailable. Three acceleration tiers are available:

- **AVX2**: Dual-block ChaCha20 encryption via `Vector256<uint>`, combined with Poly1305 donna-64 MAC (3×44-bit limbs, 9 multiplications per 16-byte block using `Math.BigMul`). ~1.7× faster than OS at 128 KiB.
- **SSSE3**: Single-block ChaCha20 via `Vector128<uint>` with the same Poly1305 donna-64 MAC. ~12% faster than OS at 128 KiB.
- **Managed**: Scalar ChaCha20 + Poly1305 donna-32 (5×26-bit limbs, 25 multiplications per block on .NET Framework / .NET Standard). Fully portable.

**Key observations:**
- **AVX2** ~40% faster than OS at 128 KiB; **SSSE3** ~12% faster than OS
- At smaller sizes (128 B), OS is competitive due to lower per-call overhead
- **Managed**, **SSSE3**, and **AVX2** paths are zero-allocation
- **BouncyCastle** allocates 336–416 B per call; **NaCl.Core** allocates 48–72 B per call

[!INCLUDE[](benchmarks/chacha20-poly1305.md)]

### XChaCha20-Poly1305

XChaCha20-Poly1305 extends ChaCha20-Poly1305 with a 24-byte nonce (vs 12 bytes), making random nonce generation safe against collisions (2⁹² birthday bound vs 2³² for ChaCha20-Poly1305). The implementation prepends an HChaCha20 key derivation step that derives a subkey from the first 16 bytes of the nonce. The same AVX2 / SSSE3 / Managed acceleration tiers apply to the inner ChaCha20-Poly1305 operation.

**Key observations:**
- Performance nearly identical to ChaCha20-Poly1305 (HChaCha20 adds ~200 ns constant overhead)
- No OS or BouncyCastle implementations available for comparison
- **NaCl.Core** allocates 48–72 B per call
- **Managed**, **SSSE3**, and **AVX2** paths are zero-allocation

[!INCLUDE[](benchmarks/xchacha20-poly1305.md)]

---

## Regional Block Ciphers

Regional block ciphers implement national cryptographic standards. All operate on 128-bit blocks in CBC mode. Benchmarks compare Managed implementations against BouncyCastle where available.

### SM4-CBC (China)

SM4 is the Chinese national block cipher (GB/T 32907-2016). It uses a 128-bit key with 32 rounds of nonlinear key mixing.

- **Managed**: Lookup-table implementation with 32-bit word operations. Zero allocation.

Benchmark results will be published after a full BenchmarkDotNet run.

### ARIA-128-CBC (Korea)

ARIA is a Korean national cipher (KS X 1213) with an involutional SPN structure. ARIA-128 uses 12 rounds.

- **Managed**: S-box substitution with byte-level diffusion layer. Zero allocation.

Benchmark results will be published after a full BenchmarkDotNet run.

### ARIA-256-CBC (Korea)

ARIA-256 uses 16 rounds for 256-bit key security. The same SPN structure applies with additional rounds.

Benchmark results will be published after a full BenchmarkDotNet run.

### Camellia-128-CBC (Japan)

Camellia is a Japanese CRYPTREC/NESSIE cipher (RFC 3713) with a Feistel structure and FL/FL⁻¹ key-dependent layers.

- **Managed**: Pre-computed SP-box tables with 6 S-boxes. Zero allocation.

Benchmark results will be published after a full BenchmarkDotNet run.

### Camellia-256-CBC (Japan)

Camellia-256 uses 24 rounds (vs 18 for 128-bit). The additional FL/FL⁻¹ layers add minimal overhead.

Benchmark results will be published after a full BenchmarkDotNet run.

### Kuznyechik-CBC (Russia)

Kuznyechik (GOST R 34.12-2015) is the modern Russian cipher with a 256-bit key and 10 rounds. It replaces the older GOST 28147-89.

- **Managed**: Pre-computed S-box and linear transformation tables. Zero allocation.

Benchmark results will be published after a full BenchmarkDotNet run.

### Kalyna-128-CBC (Ukraine)

Kalyna (DSTU 7624:2014) is the Ukrainian national cipher paired with the Kupyna hash family. Uses MDS matrix diffusion.

- **Managed**: S-box substitution with MDS matrix multiplication. Zero allocation.

Benchmark results will be published after a full BenchmarkDotNet run.

### Kalyna-256-CBC (Ukraine)

Kalyna-256 uses 14 rounds (vs 10 for 128-bit key). The same MDS-based architecture applies.

Benchmark results will be published after a full BenchmarkDotNet run.

### SEED-CBC (Korea)

SEED is a Korean cipher (RFC 4269, KISA) with a 128-bit key and 16-round Feistel structure. S-boxes are derived from the golden ratio.

- **Managed**: Pre-computed 32-bit SS-boxes (SS0–SS3). Zero allocation.

Benchmark results will be published after a full BenchmarkDotNet run.

---

## Allocation Summary

All CryptoHives cipher implementations achieve **zero heap allocation** for both encrypt and decrypt operations across all payload sizes. This is critical for high-throughput scenarios such as network packet processing, where GC pressure directly impacts tail latency.

| Implementation | Allocation | Notes |
|----------------|------------|-------|
| **CryptoHives (all variants)** | **0 B** | All tiers (Managed, AES-NI, PClMul, V256, SSSE3, AVX2) are zero-allocation at all payload sizes |
| **OS (.NET) — GCM / ChaCha20-Poly1305** | 0 B | OS AEAD implementations are zero-allocation |
| **OS (.NET) — CBC** | 128 B | Fixed P/Invoke marshalling overhead per call, independent of payload size |
| **BouncyCastle — CBC** | 832–1,024 B | Fixed per-call allocation (832 B for AES-128, 1,024 B for AES-256) |
| **BouncyCastle — GCM** | 1,608–1,832 B | Fixed per-call allocation (1,608 B for AES-128, 1,832 B for AES-256) |
| **BouncyCastle — CCM** | 2,424–2,848 B | Fixed per-call allocation (2,424 B for AES-128, 2,848 B for AES-256) |
| **BouncyCastle — ChaCha20-Poly1305** | 336–416 B | Varies slightly by payload size |
| **BouncyCastle — ChaCha20** | 96 B | Fixed per-call allocation |
| **NaCl.Core — ChaCha20** | 24 B | Small fixed allocation |
| **NaCl.Core — ChaCha20-Poly1305 / XChaCha20** | 48–72 B | Small allocation, varies by payload size |

---

## See also

- [Hash Benchmarks](benchmarks-hash.md)
- [Cipher Algorithms Reference](cipher-algorithms.md)
- [Hash Algorithms Reference](hash-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
