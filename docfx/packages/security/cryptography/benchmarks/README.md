# Benchmark Results

This directory stores published BenchmarkDotNet results for the cryptography hash and cipher suites.

## Layout

Each checked-in benchmark run lives in its own platform directory:

- `windows-x64-amd-ryzen-5-7600x/` — Windows 11, AMD Ryzen 5 7600X, X64
- `macos-arm64-apple-m4/` — macOS Tahoe, Apple M4, Arm64
- future folders such as `linux-arm64-aws-graviton-4/` for additional hosts

The platform identifier format is:

- `<os>-<architecture>-<cpu-slug>`

That keeps operating system, ISA, and CPU model visible in the path and avoids mixing results from incompatible hosts.

## Suggested Docfx UI Structure

Use a three-level navigation model:

1. Overview page: `../benchmarks.md`
2. Family selector pages: `../benchmarks-hash.md` and `../benchmarks-cipher.md`
3. Platform pages: `./<platform-id>/hash.md` and `./<platform-id>/cipher.md`

This keeps the top-level pages short and comparable, while full benchmark tables remain in platform-specific pages.
## File Structure

| File | Description |
|------|-------------|
| `machine-spec.md` | Captured hardware/software profile for the latest run |
| `sha256.md`, `blake3.md`, etc. | Individual hash algorithm benchmark results |
| `aes-gcm-128.md`, `chacha20.md`, etc. | Individual cipher algorithm benchmark results |

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

### Legacy/Regional Hash
- `md5.md`, `sha1.md`, `sm3.md`, `streebog256.md`, `streebog512.md`, `whirlpool.md`, `ripemd160.md`
- `kupyna256.md`, `kupyna384.md`, `kupyna512.md`
- `lsh256-256.md`, `lsh512-256.md`, `lsh512-512.md`

### Ascon/KMAC
- `asconhash256.md`, `asconxof128.md`
- `kmac128.md`, `kmac256.md`

### XOF (Extendable Output)
- `xof-shake128.md`, `xof-shake256.md`
- `xof-cshake128.md`, `xof-cshake256.md`
- `xof-kmac128.md`, `xof-kmac256.md`
- `xof-kt128.md`, `xof-kt256.md`
- `xof-turboshake128.md`, `xof-turboshake256.md`
- `xof-blake3.md`, `xof-asconxof128.md`

### Regional Block Ciphers (CBC)
- `sm4-cbc.md`
- `aria-cbc-128.md`, `aria-cbc-256.md`
- `camellia-cbc-128.md`, `camellia-cbc-192.md`, `camellia-cbc-256.md`
- `kuznyechik-cbc.md`
- `kalyna-cbc-128.md`, `kalyna-cbc-256.md`
- `seed-cbc.md`

### AES-CBC (Block Cipher)
- `aes-cbc-128.md`, `aes-cbc-256.md`

### AES-GCM (AEAD)
- `aes-gcm-128.md`, `aes-gcm-192.md`, `aes-gcm-256.md`

### AES-CCM (AEAD)
- `aes-ccm-128.md`, `aes-ccm-256.md`

### ChaCha20 Family (Stream Cipher / AEAD)
- `chacha20.md`, `chacha20-poly1305.md`, `xchacha20-poly1305.md`

## Updating Benchmark Results

1. Run the cryptography benchmarks from the repository root:
   ```powershell
   # Run all algorithm families
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family BLAKE

   # Run a single algorithm
   .\scripts\run-benchmarks.ps1 -Project Cryptography -Family SHA256
   ```

2. Copy the latest BenchmarkDotNet artifacts into the documentation tree:
   ```powershell
   .\scripts\update-benchmark-docs.ps1 -Project Cryptography
   ```

3. If you want to force the folder name instead of deriving it from the machine spec:
   ```powershell
   .\scripts\update-benchmark-docs.ps1 -Project Cryptography -PlatformId macos-arm64-apple-m4
   ```

The helper script:

- reads the generated markdown under `tests/Security/Cryptography/BenchmarkDotNet.Artifacts/results/`
- derives a platform identifier from the captured machine spec unless `-PlatformId` is supplied
- extracts the machine specification into a platform-local `machine-spec.md`
- removes the duplicated machine header from each benchmark table

If you publish a new platform, add matching docfx entry pages for that folder so it appears from [benchmarks-hash.md](../benchmarks-hash.md) and [benchmarks-cipher.md](../benchmarks-cipher.md).

For a feasible long-term workflow, keep a compact comparison section in selector pages (only a handful of representative algorithms) and keep detailed full tables in platform pages only.
