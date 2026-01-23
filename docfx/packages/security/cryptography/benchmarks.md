# Cryptography Benchmarks

This page collects the BenchmarkDotNet measurements for every hash implementation that ships with `CryptoHives.Foundation.Security.Cryptography`. The canonical suite is `AllHashersAllSizesBenchmark`, which runs each algorithm over representative payload sizes (128 bytes through 128 KiB) to capture both latency and throughput characteristics.

## Updating benchmark documentation

1. Run the cryptography benchmarks (either via the helper script or directly through BenchmarkSwitcher):
   ```powershell
   # Run every cryptography benchmark
   .\scripts\run-benchmarks.ps1 -Project Cryptography

   # ...or filter when iterating on a subset
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Filter "*BLAKE3*"

   # Direct invocation
   cd tests/Security/Cryptography
   dotnet run -c Release --framework net10.0 -- --filter "*AllHashersAllSizesBenchmark*"
   ```
2. Mirror the freshly generated markdown into the documentation folder:
   ```powershell
   .\scripts\update-benchmark-docs.ps1 -Package Cryptography
   ```
   The script trims the machine header from the BenchmarkDotNet export, writes it once to `benchmarks/machine-spec.md`, and stores the remaining table in `benchmarks/allhashers-all-sizes.md` for inclusion below.

## Machine profile

[!INCLUDE[](benchmarks/machine-spec.md)]

## Highlights by algorithm family

### BLAKE2/BLAKE3
- BouncyCastle trails Blake2s and Blake2b benchmarks due to a fast SIMD implementation. Only the managed AVX2 version can keep up close.
- Blake3 is trailed by a library that uses a Rust binary for .NET interop; the managed SIMD implementation is still 2xslower but outruns bouncy castle. Also the managed implementation does not process parallel blocks (yet).

### Keccak-derived families (SHA-3, SHAKE, cSHAKE, TurboSHAKE, Keccak-256)
- The managed scalar implementation is faster than both OS-provided and BouncyCastle SHA-3 hashes across the board, SIMD optimizations provide no benefit for keccak and are disabled by default. Similarly, all other managed scalar implementations outperform BouncyCastle by 1.5–2× thanks to strategic unrolling and distributing the CPU instructions.

### KMAC 128/256
- Since the managed KMAC implementations are built on the optimized cSHAKE/keccak core, it outperform both the OS-provided and BouncyCastle variants across every payload size using the scalar implementation.
- Memory allocations are held constant at 824 B for every measurement, highlighting the benefit of the pooled buffer strategy compared to the native APIs, which scale their working-set up for large payloads.

### Legacy and compatibility hashes
- MD5 and SHA-1 are supported for backward compatibility and not optimized. The OS variant is typically the fastest, followed by BouncyCastle and the managed implementation.
- RIPEMD-160 and SM3 is lead by BouncyCastle, followed by the managed implementation.
- Whirlpool is lead by the managed implementation by a 4x margin.
- Streebog-256/512 show a 1.4–1.8× speedup compared to OpenGost’s reference build while consuming a fraction of the memory, which is important for constrained environments.

## Full benchmark table

[!INCLUDE[](benchmarks/allhashers-all-sizes.md)]

## See also

- [Hash algorithms overview](hash-algorithms.md)
- [MAC algorithms overview](mac-algorithms.md)
- [NIST SP 800-185 (cSHAKE/KMAC)](specs/NIST-SP-800-185.md)
