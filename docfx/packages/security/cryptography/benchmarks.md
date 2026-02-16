# Cryptography Benchmarks

This page collects the BenchmarkDotNet measurements for every cryptographic algorithm implementation that ships with `CryptoHives.Foundation.Security.Cryptography`. Each algorithm family has its own benchmark, measuring performance across representative payload sizes (128 bytes through 128 KiB) to capture both latency and throughput characteristics.

## Benchmark Categories

### [Hash Algorithm Benchmarks](benchmarks-hash.md)

Performance measurements for all hash algorithm implementations including SHA-2, SHA-3, BLAKE2/3, Keccak, KMAC, Ascon, and regional standards (SM3, Streebog, Kupyna, LSH, Whirlpool).

### [Cipher Algorithm Benchmarks](benchmarks-cipher.md)

Performance measurements for all cipher algorithm implementations including AES-CBC, AES-GCM, AES-CCM, ChaCha20, ChaCha20-Poly1305, and XChaCha20-Poly1305.

## Updating benchmark documentation

1. Run the cryptography benchmarks (either via the helper script or directly through BenchmarkSwitcher):
   ```powershell
   # Run a specific algorithm family
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family BLAKE

   # Run a single algorithm
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family SHA256

   # Run cipher benchmarks
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family AesGcm128

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
