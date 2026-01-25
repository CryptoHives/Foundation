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

### BLAKE2/BLAKE3
- BouncyCastle trails Blake2s and Blake2b benchmarks due to a fast SIMD implementation. Only the managed AVX2 version can keep up close.
- Blake3 is trailed by a library that uses a Rust binary for .NET interop; the managed SIMD implementation is still 2× slower but outruns BouncyCastle. Also the managed implementation does not process parallel blocks (yet).

### Keccak-derived families (SHA-3, SHAKE, cSHAKE, TurboSHAKE, Keccak-256)
- The managed scalar implementation is faster than both OS-provided and BouncyCastle SHA-3 hashes across the board, SIMD optimizations provide no benefit for keccak and are disabled by default. Similarly, all other managed scalar implementations outperform BouncyCastle by 1.5–2× thanks to strategic unrolling and distributing the CPU instructions.

### KMAC 128/256
- Since the managed KMAC implementations are built on the optimized cSHAKE/keccak core, it outperform both the OS-provided and BouncyCastle variants across every payload size using the scalar implementation.
- Memory allocations are held constant at 824 B for every measurement, highlighting the benefit of the pooled buffer strategy compared to the native APIs, which scale their working-set up for large payloads.

### Legacy and compatibility hashes
- MD5 and SHA-1 are supported for backward compatibility and not optimized. The OS variant is typically the fastest, followed by BouncyCastle and the managed implementation.
- RIPEMD-160 and SM3 is lead by BouncyCastle, followed by the managed implementation.
- Whirlpool is lead by the managed implementation by a 4× margin.
- Streebog-256/512 show a 1.4–1.8× speedup compared to OpenGost's reference build while consuming a fraction of the memory, which is important for constrained environments.

## Benchmark results by algorithm

### SHA-2 Family

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

#### BLAKE2b-256
[!INCLUDE[](benchmarks/blake2b256.md)]

#### BLAKE2b-512
[!INCLUDE[](benchmarks/blake2b512.md)]

#### BLAKE2s-128
[!INCLUDE[](benchmarks/blake2s128.md)]

#### BLAKE2s-256
[!INCLUDE[](benchmarks/blake2s256.md)]

### BLAKE3

[!INCLUDE[](benchmarks/blake3.md)]

### Legacy Algorithms

#### MD5
[!INCLUDE[](benchmarks/md5.md)]

#### SHA-1
[!INCLUDE[](benchmarks/sha1.md)]

### Regional Standards

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

#### Ascon-Hash256
[!INCLUDE[](benchmarks/asconhash256.md)]

#### Ascon-XOF128
[!INCLUDE[](benchmarks/asconxof128.md)]

### KMAC

#### KMAC128
[!INCLUDE[](benchmarks/kmac128.md)]

#### KMAC256
[!INCLUDE[](benchmarks/kmac256.md)]

## See also

- [Hash algorithms overview](hash-algorithms.md)
- [MAC algorithms overview](mac-algorithms.md)
- [NIST SP 800-185 (cSHAKE/KMAC)](specs/NIST-SP-800-185.md)
