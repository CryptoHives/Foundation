# Benchmark Results

This directory stores the published BenchmarkDotNet results for the cryptography hash suites.

## File Structure

| File | Description |
|------|-------------|
| `machine-spec.md` | Captured hardware/software profile for the latest run |
| `sha256.md`, `blake3.md`, etc. | Individual algorithm benchmark results |

## Available Benchmark Files

### SHA-2 Family
- `sha224.md`, `sha256.md`, `sha384.md`, `sha512.md`, `sha512-224.md`, `sha512-256.md`

### SHA-3 Family
- `sha3-224.md`, `sha3-256.md`, `sha3-384.md`, `sha3-512.md`

### Keccak Family
- `keccak256.md`, `keccak384.md`, `keccak512.md`

### SHAKE/cSHAKE Family
- `shake128.md`, `shake256.md`, `cshake128.md`, `cshake256.md`

### KT/TurboSHAKE Family
- `kt128.md`, `kt256.md`, `turboshake128.md`, `turboshake256.md`

### BLAKE Family
- `blake2b256.md`, `blake2b512.md`, `blake2s128.md`, `blake2s256.md`, `blake3.md`

### Legacy/Regional
- `md5.md`, `sha1.md`, `sm3.md`, `streebog256.md`, `streebog512.md`, `whirlpool.md`, `ripemd160.md`

### Ascon/KMAC
- `asconhash256.md`, `asconxof128.md`
- `kmac128.md`, `kmac128incremental.md`, `kmac128outputsize.md`
- `kmac256.md`, `kmac256incremental.md`, `kmac256outputsize.md`

## Updating Benchmark Results

1. Run the cryptography benchmarks from the repository root:
   ```powershell
   # Run all algorithm families
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family BLAKE

   # Run a single algorithm
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family SHA256
   ```
   or execute the test harness directly:
   ```powershell
   cd tests/Security/Cryptography
   dotnet run -c Release --framework net10.0 -- --filter *SHA256* *SHA384*
   ```

2. Copy the latest BenchmarkDotNet artifacts into this folder:
   ```powershell
   .\scripts\update-benchmark-docs.ps1 -Package Cryptography
   ```

The helper script:
- Reads the generated markdown under `tests/Security/Cryptography/BenchmarkDotNet.Artifacts/results/`
- Extracts the machine specification into `machine-spec.md`
- Removes the duplicated machine header from each benchmark table

Keep in mind that the measurements are machine-dependent. Re-run the suite on your own hardware to compare against these reference numbers.
