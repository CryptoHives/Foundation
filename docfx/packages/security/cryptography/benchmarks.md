# Cryptography Benchmarks

This page collects the BenchmarkDotNet measurements for every cryptographic algorithm implementation that ships with `CryptoHives.Foundation.Security.Cryptography`. Each algorithm family has its own benchmark, measuring performance across representative payload sizes (128 bytes through 128 KiB) to capture both latency and throughput characteristics.

## Benchmark Categories

### [Hash Algorithm Benchmarks](benchmarks-hash.md)

Performance measurements for all hash algorithm implementations including SHA-2, SHA-3, BLAKE2/3, Keccak, KMAC, Ascon, and regional standards (SM3, Streebog, Kupyna, LSH, Whirlpool).

### [Cipher Algorithm Benchmarks](benchmarks-cipher.md)

Performance measurements for all cipher algorithm implementations including AES-CBC, AES-GCM, AES-CCM, ChaCha20, ChaCha20-Poly1305, XChaCha20-Poly1305, and regional block ciphers (SM4, ARIA, Camellia, Kuznyechik, Kalyna, SEED).

## Memory Footprint

The following tables show the per-instance memory footprint (internal state + buffers) and any static lookup tables shared across all instances. These are the raw data sizes; actual managed object overhead adds ~16–40 bytes per object and ~24 bytes per array on 64-bit runtimes.

### Hash Algorithms

| Algorithm | Instance State | Block Size | Static Tables | Notes |
|-----------|---------------|-----------|---------------|-------|
| SHA-224 | 96 B | 64 B | 256 B | uint[8] state + byte[64] buffer |
| SHA-256 | 96 B | 64 B | 256 B | uint[8] state + byte[64] buffer |
| SHA-384 | 192 B | 128 B | 640 B | ulong[8] state + byte[128] buffer |
| SHA-512 | 192 B | 128 B | 640 B | ulong[8] state + byte[128] buffer |
| SHA-512/224 | 192 B | 128 B | 640 B | SHA-512 core with truncated output |
| SHA-512/256 | 192 B | 128 B | 640 B | SHA-512 core with truncated output |
| SHA3-224 | 336 B | 144 B | 192 B | 200 B Keccak state + byte[rate] buffer |
| SHA3-256 | 336 B | 136 B | 192 B | 200 B Keccak state + byte[rate] buffer |
| SHA3-384 | 304 B | 104 B | 192 B | 200 B Keccak state + byte[rate] buffer |
| SHA3-512 | 272 B | 72 B | 192 B | 200 B Keccak state + byte[rate] buffer |
| SHAKE128 | 368 B | 168 B | 192 B | Keccak XOF, variable output |
| SHAKE256 | 336 B | 136 B | 192 B | Keccak XOF, variable output |
| cSHAKE128 | 368 B+ | 168 B | 192 B | + encoded function/customization |
| cSHAKE256 | 336 B+ | 136 B | 192 B | + encoded function/customization |
| TurboSHAKE128 | 368 B | 168 B | 192 B | Reduced-round Keccak |
| TurboSHAKE256 | 336 B | 136 B | 192 B | Reduced-round Keccak |
| KT128 | 368 B | 168 B | 192 B | KangarooTwelve |
| KT256 | 336 B | 136 B | 192 B | KangarooTwelve |
| Keccak-256 | 336 B | 136 B | 192 B | Ethereum compatible |
| Keccak-384 | 304 B | 104 B | 192 B | Ethereum compatible |
| Keccak-512 | 272 B | 72 B | 192 B | Ethereum compatible |
| BLAKE2b | 192 B+ | 128 B | 256 B | ulong[8] state + byte[128] buffer + key |
| BLAKE2s | 96 B+ | 64 B | 192 B | uint[8] state + byte[64] buffer + key |
| BLAKE3 | 2,816 B | 64 B | — | Merkle tree: 1 KB chunk buffer + 1.7 KB CV stack |
| Ascon-Hash256 | 48 B | 8 B | — | 5 × ulong state + byte[8] buffer |
| Ascon-XOF128 | 48 B | 8 B | — | 5 × ulong state + byte[8] buffer |
| RIPEMD-160 | 84 B | 64 B | — | uint[5] state + byte[64] buffer |
| SM3 | 96 B | 64 B | — | 8 × uint state + byte[64] buffer |
| Whirlpool | 128 B | 64 B | 16.3 KB | ulong[8] state + byte[64] buffer; 8 T-tables |
| Streebog | 256 B | 64 B | 16.5 KB | 3 × ulong[8] state + byte[64] buffer; 8 T-tables |
| Kupyna-256 | 192 B | 64 B | 16 KB | ulong[8] state + scratch + byte[64]; 8 T-tables |
| Kupyna-512 | 384 B | 128 B | 16 KB | ulong[16] state + scratch + byte[128]; 8 T-tables |
| LSH-256 | 384 B | 128 B | 832 B | CV + submsg registers + byte[128] buffer |
| LSH-512 | 768 B | 256 B | 1.8 KB | CV + submsg registers + byte[256] buffer |
| SHA-1 | 404 B | 64 B | — | uint[5] state + uint[80] W + byte[64] |
| MD5 | 80 B | 64 B | 512 B | uint[4] state + byte[64] buffer |

### Cipher Algorithms

| Algorithm | Instance State | Block Size | Static Tables | Notes |
|-----------|---------------|-----------|---------------|-------|
| AES-128 (ECB/CBC/CTR) | 288 B | 16 B | 10.5 KB | Fixed: uint[44] keys + IV + counter + feedback; T-tables |
| AES-192 (ECB/CBC/CTR) | 288 B | 16 B | 10.5 KB | Fixed: uint[52] keys (shared fixed buffer) |
| AES-256 (ECB/CBC/CTR) | 288 B | 16 B | 10.5 KB | Fixed: uint[60] keys (shared fixed buffer) |
| AES-GCM-128 | ~640 B | 16 B | 10.6 KB | Round keys + H + Shoup table + H-powers (CLMUL) |
| AES-GCM-192 | ~680 B | 16 B | 10.6 KB | Larger round key schedule |
| AES-GCM-256 | ~720 B | 16 B | 10.6 KB | Largest round key schedule |
| AES-CCM-128 | 240 B | 16 B | 10.5 KB | Fixed: uint[44] round keys |
| AES-CCM-256 | 240 B | 16 B | 10.5 KB | Fixed: uint[60] round keys |
| ChaCha20 | ~128 B | 64 B | 16 B | uint[16] state + keystream buffer |
| ChaCha20-Poly1305 | ~192 B | 64 B | 16 B | ChaCha20 state + Poly1305 accumulator |
| XChaCha20-Poly1305 | ~192 B | 64 B | 16 B | Same as ChaCha20-Poly1305 (HChaCha subkey) |
| Ascon-AEAD-128 | 56 B | 16 B | — | 5 × ulong state + nonce; permutation-based |
| SM4 (ECB/CBC/CTR) | 176 B | 16 B | 4 KB | uint[32] round keys + IV + feedback; S-box + CK table |
| ARIA-128 (ECB/CBC/CTR) | 288 B | 16 B | 1 KB | byte[16×17] round keys + IV + feedback; 4 S-boxes |
| ARIA-192 (ECB/CBC/CTR) | 288 B | 16 B | 1 KB | byte[16×15] round keys (shared buffer) |
| ARIA-256 (ECB/CBC/CTR) | 288 B | 16 B | 1 KB | byte[16×17] round keys (shared buffer) |
| Camellia-128 (ECB/CBC/CTR) | 320 B | 16 B | 4.5 KB | uint[52] subkeys + IV + feedback; 6 SP-boxes |
| Camellia-192 (ECB/CBC/CTR) | 400 B | 16 B | 4.5 KB | uint[68] subkeys (shared SP-boxes) |
| Camellia-256 (ECB/CBC/CTR) | 400 B | 16 B | 4.5 KB | uint[68] subkeys (shared SP-boxes) |
| Kuznyechik (ECB/CBC/CTR) | 320 B | 16 B | 8 KB | byte[10×16] round keys + IV + feedback; LS/IL tables |
| Kalyna-128 (ECB/CBC/CTR) | 320 B | 16 B | 5 KB | ulong[22] round keys + IV + feedback; 4 S-boxes + MDS |
| Kalyna-256 (ECB/CBC/CTR) | 400 B | 16 B | 5 KB | ulong[30] round keys (shared S-boxes/MDS) |
| SEED (ECB/CBC/CTR) | 192 B | 16 B | 4 KB | uint[32] round keys + IV + feedback; 4 SS-boxes |

### Message Authentication Codes (MAC)

| Algorithm | Instance State | Block Size | Static Tables | Notes |
|-----------|---------------|-----------|---------------|-------|
| KMAC128 | 368 B+ | 168 B | 192 B | Keccak state + buffer + encoded key/customization |
| KMAC256 | 336 B+ | 136 B | 192 B | Keccak state + buffer + encoded key/customization |
| BLAKE2b (keyed) | 192 B+ | 128 B | 256 B | Same as BLAKE2b + key material |
| BLAKE2s (keyed) | 96 B+ | 64 B | 192 B | Same as BLAKE2s + key material |
| BLAKE3 (keyed) | 2,816 B | 64 B | — | Same as BLAKE3 with key words |

> **Static tables** are shared across all instances of algorithms in the same family and are loaded once into memory. AES T-tables (10.5 KB) are shared by all AES-based algorithms (ECB, CBC, CTR, GCM, CCM). Keccak round constants (192 B) are shared by all SHA-3, SHAKE, cSHAKE, TurboSHAKE, KT, and KMAC instances. Algorithms marked "—" use no static lookup tables (permutation-based or constant-time by design).


## Updating benchmark documentation

1. Run the cryptography benchmarks (either via the helper script or directly through BenchmarkSwitcher):
   ```powershell
   # Run a specific algorithm family
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family BLAKE

   # Run a single algorithm
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family SHA256

   # Run cipher benchmarks
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family AesGcm128

   # Run all regional cipher benchmarks
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family RegionalCipher

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

## See also

- [Hash Algorithms Reference](hash-algorithms.md)
- [Cipher Algorithms Reference](cipher-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
- [XOF Mode (Extendable-Output)](xof-mode.md)
