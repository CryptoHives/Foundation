# macOS Arm64 Apple M4 Cipher Benchmarks

## Machine Profile

[!INCLUDE[](machine-spec.md)]

BenchmarkDotNet measurements for all cipher algorithm implementations in `CryptoHives.Foundation.Security.Cryptography`. Each algorithm is benchmarked across representative payload sizes (17 bytes through 128 KiB) to capture both latency and throughput characteristics.

## Implementation Variants

Each cipher family exposes multiple acceleration tiers. The runtime automatically selects the fastest tier supported by the host CPU via `SimdSupport` detection. Callers can also force a specific tier through the `Create(SimdSupport)` factory for testing or compatibility.

### AES Family

| Variant | Instructions | .NET Target | When Selected | Description |
|---------|-------------|-------------|---------------|-------------|
| **Managed** | Scalar | All | No ARM Crypto support | T-table AES using scalar `uint` arithmetic. Fully portable, zero-allocation. ~10–16× slower than ArmAes depending on mode and payload size. |
| **ArmAes** | AES (ARM Crypto Ext.) | .NET 8+ | `ArmBase.IsSupported` | Hardware AES round instructions (`AESD`, `AESE`, `AESMC`, `AESIMC`). For CBC, uses 8-block interleaved decrypt for maximum instruction-level parallelism — all 8 plaintext blocks decoded simultaneously via parallel `AESD` dispatch. For GCM/CCM, accelerates counter-mode encryption and CBC-MAC. Decrypt is ~8.5× faster than OS at 128 B; at bulk sizes Apple CommonCrypto leads via Apple Silicon–specific AES pipelining. |
| **ArmAes+ArmPmull** | AES + PMULL (ARM Crypto Ext.) | .NET 8+ | `AdvSimd.Arm64.IsSupported` | Adds carry-less polynomial multiplication (`PMULL`/`PMULL2`) for hardware-accelerated GHASH over GF(2¹²⁸). `PMULL` operates on 64-bit polynomial operands to produce 128-bit products; `PMULL2` reads from the upper halves of 128-bit NEON registers (a free lane-select requiring no additional instruction). Uses the same 8-block stitched AES+GHASH pipeline as the x86 PClMul path. Modular reduction uses a 2-PMULL SymCrypt-style `MODREDUCE`. Pre-computes Karatsuba cross-term halves for H¹–H⁸ powers. **~32× faster than OS at 17 B**; OS leads at ≥8 KiB due to Apple Silicon–specific bulk AES acceleration. |

### ChaCha20 Family

| Variant | Instructions | .NET Target | When Selected | Description |
|---------|-------------|-------------|---------------|-------------|
| **Managed** | Scalar | All | No NEON support | Quarter-round operations using scalar `uint` arithmetic. Fully portable. ~4× slower than Neon at all payload sizes. |
| **Neon** | AdvSIMD (NEON) | .NET 8+ | `AdvSimd.IsSupported` | Maps the 4×4 ChaCha state to four `Vector128<uint>` rows. Uses ARM NEON shift-left, shift-right, and byte-table permute instructions for the 16-bit, 12-bit, 8-bit, and 7-bit rotations. Diagonal rounds use `AdvSimd.ExtractVector128` to rotate rows by one element. Processes one 64-byte keystream block per iteration. ~4× faster than Managed; ~1.24× faster than BouncyCastle at 128 KiB. |

### When to Use Each Variant

- **Small messages (≤256 B)**: AES-GCM with ArmAes+ArmPmull is **~32× faster than OS at 17 B** and ~14× at 128 B — zero P/Invoke overhead eliminates the ~1.7–1.9 μs kernel transition cost entirely. ChaCha20-Poly1305 NEON is ~3× faster than OS at 128 B.
- **Medium messages (256 B–4 KB)**: ArmAes+ArmPmull leads through ~1 KiB. ChaCha20-Poly1305 NEON remains competitive at 1 KiB (~1.25× faster than OS). This range covers QUIC (~1.4 KB), WireGuard (~1.4 KB), and IPsec packets.
- **Large messages (8 KB–128 KB)**: Apple CommonCrypto dominates — OS is ~2× faster for AES-GCM and ~1.7× faster for ChaCha20-Poly1305. This is likely due to Apple Silicon–specific AES/PMULL micro-architectural pipelining that .NET's current ARMv8 paths do not yet fully exploit. This range covers TLS records (1–16 KB) and OPC UA chunks (8 KB default).
- **No hardware AES**: Use ChaCha20-Poly1305 NEON — it outperforms Managed AES-GCM by 3–10× depending on payload size and is always zero-allocation.
- **IoT / constrained devices**: AES-CCM with ArmAes provides ~4× speedup over BouncyCastle at 128 KiB. Supports variable nonce (7–13 bytes) and tag sizes.

## Highlights

| Family | Leader | Key Insight |
|--------|--------|-------------|
| **ChaCha20** | Neon | NEON ~4× faster than Managed; ~1.24× faster than BouncyCastle at 128 KiB; zero allocation |
| **ChaCha20-Poly1305** | Neon | **~3× faster than OS at 128 B**; OS leads at ≥8 KiB; zero allocation |
| **XChaCha20-Poly1305** | Neon | ~3.3× faster than Managed at 128 KiB; zero allocation |
| **AES-CBC** | ArmAes | **Decrypt ~8.5× faster than OS at 128 B**; OS leads at ≥8 KiB (Apple Silicon bulk path); zero allocation |
| **AES-GCM** | ArmAes+ArmPmull | **~32× faster than OS at 17 B**; ~14× at 128 B; OS leads at ≥8 KiB; 8-block stitched AES+GHASH pipeline |
| **AES-CCM** | ArmAes | ~4× faster than BouncyCastle at 128 KiB; zero allocation; no OS adapter available |

---

## Stream Ciphers

### ChaCha20

ChaCha20 is a stream cipher designed by Daniel J. Bernstein. Two acceleration tiers are available on ARM:

- **Neon**: Single-block processing — maps the 4×4 ChaCha state matrix to four `Vector128<uint>` rows. Uses ARM NEON `vshl`/`vsri` (shift-and-insert) and `vtbl` (byte-table permute) instructions for the four rotation widths (16-bit, 12-bit, 8-bit, 7-bit). Diagonal rounds use `AdvSimd.ExtractVector128` to rotate rows by one element. Yields ~750 MB/s throughput at 128 KiB; ~1.24× faster than BouncyCastle.
- **Managed**: Scalar `uint` quarter-round arithmetic. Fully portable across all .NET targets. ~4.1× slower than Neon at 128 KiB.

**Key observations:**
- **Neon** is the fastest at all sizes; ~1.24× faster than BouncyCastle at 128 KiB; ~1.35× at 1 KiB
- **BouncyCastle** allocates 96 B per call; **NaCl.Core** allocates 24 B per call
- **Managed** and **Neon** paths are zero-allocation

[!INCLUDE[](chacha20.md)]

---

## Block Ciphers

### AES-128-CBC

AES-CBC (Cipher Block Chaining) is the most widely deployed AES mode. Two acceleration tiers are available on Apple M4:

- **ArmAes**: Uses ARM Cryptography Extension `AESD`/`AESE`/`AESMC`/`AESIMC` instructions. Decrypt uses **8-block interleaving** — 8 ciphertext blocks are loaded and decrypted simultaneously via parallel `AESD` dispatch. Each block decrypts independently, requiring only the preceding ciphertext block as an XOR mask (10 rounds × 8 blocks = 80 `AESD` instructions in flight). Encrypt remains serial because each plaintext block must be XORed with the previous ciphertext before the next `AESE` can proceed.
- **Managed**: T-table AES using four 256-entry lookup tables per round. Fully portable, zero-allocation. Comparable to BouncyCastle at large sizes.

**Key observations:**
- **ArmAes Decrypt**: ~8.5× faster than OS at 128 B; near OS at 4 KiB; OS leads from ~8 KiB (Apple Silicon uses a wider AES pipeline at bulk sizes)
- **ArmAes Encrypt**: ~1.5× faster than OS at 128 B; OS leads from 1 KiB (CBC encrypt is inherently serial; CommonCrypto uses NEON-assisted interleaving for partial parallelism)
- **Managed**: Zero-allocation T-table AES; comparable to BouncyCastle at large sizes
- **OS**: Allocates 72 B per call (P/Invoke marshalling overhead)

[!INCLUDE[](aes-cbc-128.md)]

### AES-256-CBC

AES-256-CBC uses 14 rounds (vs 10 for AES-128), adding ~25-30% overhead. The same 8-block interleaved decrypt and serial encrypt architecture applies via `ArmAes`. Decrypt is ~1.65× faster than OS at 128 B; OS leads from ~8 KiB. Encrypt is slower than OS from 1 KiB (serial CBC encrypt bottleneck on Apple Silicon).

[!INCLUDE[](aes-cbc-256.md)]

---

## AEAD Ciphers (Authenticated Encryption)

Authenticated Encryption with Associated Data (AEAD) ciphers provide both confidentiality and authenticity in a single operation. All CryptoHives AEAD implementations are zero-allocation.

### AES-128-GCM

AES-GCM combines counter-mode AES encryption (GCTR) with GHASH polynomial authentication over GF(2¹²⁸). Two acceleration tiers are available on Apple M4:

- **ArmAes+ArmPmull** (.NET 8+): Uses ARM Cryptography Extension `AESD`/`AESE` for counter-mode encryption and `PMULL`/`PMULL2` for GHASH polynomial multiplication. `PMULL` operates on 64-bit polynomial operands to produce 128-bit products; `PMULL2` reads from the upper halves of 128-bit NEON registers (a free lane-select requiring no additional instruction). Uses an 8-block stitched loop that interleaves AES rounds with lagged GHASH of the previous 8 blocks. Modular reduction uses a 2-PMULL SymCrypt-style `MODREDUCE`. Pre-computes Karatsuba cross-term halves for H¹–H⁸ powers. Small payloads use the non-stitched path (≤8 blocks). **~32× faster than OS at 17 B; ~14× at 128 B.** At bulk sizes (≥8 KiB), Apple CommonCrypto leads — likely due to Apple Silicon–specific AES pipelining not yet accessible to the .NET ARM intrinsics layer.
- **Managed**: Scalar T-table AES with 4-bit Shoup table GHASH (16-entry reduction table, byte-by-byte multiplication). Fully portable, zero-allocation.

**Key observations:**
- **ArmAes+ArmPmull**: ~32× faster than OS at 17 B encrypt; ~14× at 128 B; ~2.5× at 1 KiB; OS leads from ~4–8 KiB
- **ArmAes+ArmPmull at 128 KiB**: OS is ~4.8× faster for both encrypt and decrypt
- **Managed**: Uses 4-bit Shoup table GHASH, T-table AES; zero allocation
- **BouncyCastle**: Uses ARM AES + PMULL internally on ARM64; allocates ~1.5 KB per call

[!INCLUDE[](aes-gcm-128.md)]

### AES-192-GCM

AES-192-GCM uses 12 rounds (vs 10 for AES-128), adding ~10-15% overhead. The same ArmAes+ArmPmull pipeline applies. The performance pattern mirrors AES-128-GCM: dominant over OS at small payloads, OS leads at bulk sizes.

[!INCLUDE[](aes-gcm-192.md)]

### AES-256-GCM

AES-256-GCM uses 14 rounds (vs 10 for AES-128), adding ~20-30% overhead per block. The same 2-tier architecture (ArmAes+ArmPmull → Managed) applies. Encrypt is ~14-16× faster than OS at 128 B; OS leads from ~4–8 KiB. The large-payload gap mirrors AES-128-GCM — Apple CommonCrypto likely exploits Apple Silicon–specific AES/PMULL execution units that are not yet accessible through the .NET ARMv8 intrinsics layer.

[!INCLUDE[](aes-gcm-256.md)]

### AES-128-CCM

AES-CCM (Counter with CBC-MAC) combines CTR mode encryption with CBC-MAC authentication. Unlike GCM, CCM requires two sequential passes (encrypt + MAC or MAC + decrypt), making it inherently less parallelizable. It is widely used in IoT protocols (Bluetooth LE, ZigBee, Thread) and supports variable nonce (7–13 bytes) and tag sizes (4–16 bytes). Two acceleration tiers are available:

- **ArmAes**: ARM Cryptography Extension `AESD`/`AESE` instructions for all block operations — counter-mode encryption, CBC-MAC computation, and AAD processing. Uses `Vector128<byte>` round keys via `MemoryMarshal.Cast` from the shared `uint[]` key schedule. Dispatched via `_useAesNi` bool flag (shared with x86 dispatch; indicates hardware AES availability on any ISA).
- **Managed**: T-table AES for all block operations. Fully portable, zero-allocation.

**Key observations:**
- **ArmAes**: ~4× faster than Managed at 128 KiB; ~4.3× faster than BouncyCastle; zero allocation
- **Managed**: T-table AES; comparable to BouncyCastle at large sizes
- **BouncyCastle**: Allocates ~2.4–2.5 KB per call
- No OS adapter available for comparison (System.Security.Cryptography does not expose AES-CCM on all platforms)

[!INCLUDE[](aes-ccm-128.md)]

### AES-256-CCM

AES-256-CCM uses 14 rounds (vs 10 for AES-128). The same ArmAes / Managed dispatch applies. The additional rounds add ~10-15% overhead on the Apple M4.

[!INCLUDE[](aes-ccm-256.md)]

### ChaCha20-Poly1305

ChaCha20-Poly1305 is a software-friendly AEAD cipher (RFC 8439) that combines ChaCha20 stream encryption with Poly1305 MAC authentication. It is the recommended AEAD cipher when hardware AES acceleration is unavailable. Two acceleration tiers are available on ARM:

- **Neon**: Single-block ChaCha20 via `Vector128<uint>` combined with Poly1305 donna-64 MAC (3×44-bit limbs, 9 multiplications per 16-byte block using `Math.BigMul`). **~3× faster than OS at 128 B**; competitive with OS at 1 KiB; OS leads at ≥8 KiB.
- **Managed**: Scalar ChaCha20 + Poly1305 donna-32 (5×26-bit limbs, 25 multiplications per block on .NET Framework / .NET Standard). Fully portable.

**Key observations:**
- **Neon** ~3× faster than OS at 128 B encrypt; ~1.25× at 1 KiB; OS ~1.45× faster from 8 KiB; OS ~1.67× faster at 128 KiB
- BouncyCastle is slightly faster than NEON at very small payloads (128 B) due to lower NEON setup overhead at that granularity
- **Managed** and **Neon** paths are zero-allocation
- **BouncyCastle** allocates 336–416 B per call; **NaCl.Core** allocates 48–72 B per call

[!INCLUDE[](chacha20-poly1305.md)]

### XChaCha20-Poly1305

XChaCha20-Poly1305 extends ChaCha20-Poly1305 with a 24-byte nonce (vs 12 bytes), making random nonce generation safe against collisions (2⁹² birthday bound vs 2³² for ChaCha20-Poly1305). The implementation prepends an HChaCha20 key derivation step that derives a subkey from the first 16 bytes of the nonce. The same Neon / Managed acceleration tiers apply to the inner ChaCha20-Poly1305 operation.

**Key observations:**
- Performance nearly identical to ChaCha20-Poly1305 (HChaCha20 adds ~400 ns constant overhead)
- **Neon** ~3.3× faster than Managed at 128 KiB; ~3.3× faster than NaCl.Core at 128 KiB
- No OS or BouncyCastle implementations available for comparison
- **NaCl.Core** allocates 48–72 B per call
- **Managed** and **Neon** paths are zero-allocation

[!INCLUDE[](xchacha20-poly1305.md)]

---

## Regional Block Ciphers

Regional block ciphers implement national cryptographic standards. All operate on 128-bit blocks in CBC mode. Benchmarks compare Managed implementations against BouncyCastle where available.

### SM4-CBC (China)

SM4 is the Chinese national block cipher (GB/T 32907-2016). It uses a 128-bit key with 32 rounds of nonlinear key mixing.

- **Managed**: Lookup-table implementation with 32-bit word operations. Zero allocation.

[!INCLUDE[](sm4-cbc.md)]

### ARIA-128-CBC (Korea)

ARIA is a Korean national cipher (KS X 1213) with an involutional SPN structure. ARIA-128 uses 12 rounds.

- **Managed**: S-box substitution with byte-level diffusion layer. Zero allocation.

[!INCLUDE[](aria-cbc-128.md)]

### ARIA-256-CBC (Korea)

ARIA-256 uses 16 rounds for 256-bit key security. The same SPN structure applies with additional rounds.

[!INCLUDE[](aria-cbc-256.md)]

### Camellia-128-CBC (Japan)

Camellia is a Japanese CRYPTREC/NESSIE cipher (RFC 3713) with a Feistel structure and FL/FL⁻¹ key-dependent layers.

- **Managed**: Pre-computed SP-box tables with 6 S-boxes. Zero allocation.

[!INCLUDE[](camellia-cbc-128.md)]

### Camellia-256-CBC (Japan)

Camellia-256 uses 24 rounds (vs 18 for 128-bit). The additional FL/FL⁻¹ layers add minimal overhead.

[!INCLUDE[](camellia-cbc-256.md)]

### Kuznyechik-CBC (Russia)

Kuznyechik (GOST R 34.12-2015) is the modern Russian cipher with a 256-bit key and 10 rounds. It replaces the older GOST 28147-89.

- **Managed**: Pre-computed S-box and linear transformation tables. Zero allocation.

[!INCLUDE[](kuznyechik-cbc.md)]

### Kalyna-128-CBC (Ukraine)

Kalyna (DSTU 7624:2014) is the Ukrainian national cipher paired with the Kupyna hash family. Uses MDS matrix diffusion.

- **Managed**: S-box substitution with MDS matrix multiplication. Zero allocation.

[!INCLUDE[](kalyna-cbc-128.md)]

### Kalyna-256-CBC (Ukraine)

Kalyna-256 uses 14 rounds (vs 10 for 128-bit key). The same MDS-based architecture applies.

[!INCLUDE[](kalyna-cbc-256.md)]

### SEED-CBC (Korea)

SEED is a Korean cipher (RFC 4269, KISA) with a 128-bit key and 16-round Feistel structure. S-boxes are derived from the golden ratio.

- **Managed**: Pre-computed 32-bit SS-boxes (SS0–SS3). Zero allocation.

[!INCLUDE[](seed-cbc.md)]

---

## Allocation Summary

All CryptoHives cipher implementations achieve **zero heap allocation** for both encrypt and decrypt operations across all payload sizes. This is critical for high-throughput scenarios such as network packet processing, where GC pressure directly impacts tail latency.

| Implementation | Allocation | Notes |
|----------------|------------|-------|
| **CryptoHives (all variants)** | **0 B** | All tiers (Managed, ArmAes, ArmAes+ArmPmull, Neon) are zero-allocation at all payload sizes |
| **OS (.NET) — GCM / ChaCha20-Poly1305** | 0 B | OS AEAD implementations are zero-allocation |
| **OS (.NET) — CBC** | 72 B | Fixed P/Invoke marshalling overhead per call, independent of payload size |
| **BouncyCastle — CBC** | 832–1,024 B | Fixed per-call allocation (832 B for AES-128, 1,024 B for AES-256) |
| **BouncyCastle — GCM** | 1,520–1,744 B | Fixed per-call allocation (1,520 B for AES-128 encrypt, 1,744 B for AES-256 decrypt) |
| **BouncyCastle — CCM** | 2,424–2,848 B | Fixed per-call allocation (2,424 B for AES-128 decrypt, 2,848 B for AES-256 encrypt) |
| **BouncyCastle — ChaCha20-Poly1305** | 336–416 B | Varies slightly by payload size |
| **BouncyCastle — ChaCha20** | 96 B | Fixed per-call allocation |
| **NaCl.Core — ChaCha20** | 24 B | Small fixed allocation |
| **NaCl.Core — ChaCha20-Poly1305 / XChaCha20** | 48–72 B | Small allocation, varies by payload size |

