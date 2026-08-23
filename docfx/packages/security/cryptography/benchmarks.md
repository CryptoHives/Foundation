# Cryptography Benchmarks

BenchmarkDotNet measurements for `CryptoHives.Foundation.Security.Cryptography` are published through the
interactive benchmark trends dashboard below rather than static per-platform pages. The dashboard loads a small
SQLite database client-side (no server) and lets you pick platform, category, algorithm family and method,
plotting every matching implementation as its own line — including a size-scaling view and multi-size trend
comparisons. The single-run views — the table and the scaling chart — take any recorded run from the Run picker,
not just the newest. Because `platform` is a free-form value in the database, results from any contributor's
machine can appear side by side, not just a fixed set of CI hosts.

<iframe src="benchmark-trends/index.html" style="width:100%; height:900px; border:1px solid var(--border-color, #ddd); border-radius:6px;" loading="lazy" title="Cryptography benchmark trends dashboard"></iframe>

[Open the dashboard in its own page →](benchmark-trends/index.html)

## Memory Footprint

The following tables show the per-instance memory footprint (internal state + buffers) and any
static lookup tables shared across all instances. These are the raw data sizes measured by walking
each instance's fields on x64 .NET 10; actual managed object overhead adds ~16-40 bytes per object
and ~24 bytes per array on 64-bit runtimes.

Two things are worth knowing before reading the numbers. A block cipher's state lives in the
transform it creates, not in the `SymmetricAlgorithm` object (which is a ~60 B shell), so the cipher
table measures the transform. And a few algorithms buffer their whole input rather than absorbing it
block by block - those are marked *+ input* and are the only ones whose footprint is not constant.

### Hash Algorithms

| Algorithm | Instance State | Block Size | Static Tables | Notes |
|-----------|---------------|-----------|---------------|-------|
| SHA-224 | 128 B | 64 B | 256 B | uint[8] state + byte[64] buffer, both pooled (the state bucket rounds up to 16 words) |
| SHA-256 | 128 B | 64 B | 256 B | uint[8] state + byte[64] buffer, both pooled |
| SHA-384 | 256 B | 128 B | 640 B | ulong[8] state + byte[128] buffer, both pooled |
| SHA-512 | 256 B | 128 B | 640 B | ulong[8] state + byte[128] buffer, both pooled |
| SHA-512/224 | 256 B | 128 B | 640 B | SHA-512 core with truncated output |
| SHA-512/256 | 256 B | 128 B | 640 B | SHA-512 core with truncated output |
| SHA3-224 | 352 B | 144 B | 3.6 KB | 208 B Keccak state + byte[rate] buffer |
| SHA3-256 | 344 B | 136 B | 3.6 KB | 208 B Keccak state + byte[rate] buffer |
| SHA3-384 | 312 B | 104 B | 3.6 KB | 208 B Keccak state + byte[rate] buffer |
| SHA3-512 | 280 B | 72 B | 3.6 KB | 208 B Keccak state + byte[rate] buffer |
| SHAKE128 | 376 B | 168 B | 3.6 KB | Keccak XOF, variable output |
| SHAKE256 | 344 B | 136 B | 3.6 KB | Keccak XOF, variable output |
| cSHAKE128 | 376 B+ | 168 B | 3.6 KB | + encoded function/customization |
| cSHAKE256 | 344 B+ | 136 B | 3.6 KB | + encoded function/customization |
| TurboSHAKE128 | 376 B | 168 B | 3.6 KB | Reduced-round Keccak |
| TurboSHAKE256 | 344 B | 136 B | 3.6 KB | Reduced-round Keccak |
| KT128 | 632 B + input | 168 B | 3.6 KB | KangarooTwelve: a TurboSHAKE128 (376 B) plus a pooled buffer holding the whole message |
| KT256 | 600 B + input | 136 B | 3.6 KB | KangarooTwelve: a TurboSHAKE256 (344 B) plus the same buffer |
| Keccak-256 | 344 B | 136 B | 3.6 KB | Ethereum compatible |
| Keccak-384 | 312 B | 104 B | 3.6 KB | Ethereum compatible |
| Keccak-512 | 280 B | 72 B | 3.6 KB | Ethereum compatible |
| BLAKE2b | 216 B | 128 B | — | ulong[8] state + byte[128] buffer + counters; a key adds up to 64 B |
| BLAKE2s | 120 B | 64 B | 640 B | uint[8] state + byte[64] buffer + counters; tables are SIMD gather indices |
| BLAKE3 | 3,072 B | 64 B | — | Merkle tree: 1 KB chunk buffer + 1.7 KB CV stack + root/squeeze state |
| Ascon-Hash256 | 48 B | 8 B | — | 5 × ulong state + byte[8] buffer |
| Ascon-XOF128 | 48 B | 8 B | — | 5 × ulong state + byte[8] buffer |
| RIPEMD-160 | 84 B | 64 B | 1.25 KB | uint[5] state + byte[64] buffer; 4 × int[80] schedule tables |
| SM3 | 96 B | 64 B | — | 8 × uint state + byte[64] buffer |
| Whirlpool | 128 B | 64 B | 16.3 KB | ulong[8] state + byte[64] buffer; 8 T-tables + S-box + round constants |
| Streebog | 256 B | 64 B | 17.6 KB | 3 × ulong[8] state + byte[64] buffer; 8 T-tables + Pi/A + a Vector512 CV table |
| Kupyna-256 | 320 B | 64 B | 16.1 KB | 4 × ulong[8] (state, two temporaries, scratch) + byte[64]; 8 T-tables |
| Kupyna-512 | 640 B | 128 B | 16.1 KB | 4 × ulong[16] (state, two temporaries, scratch) + byte[128]; 8 T-tables |
| LSH-256 | 384 B | 128 B | 992 B | CV + submsg registers + byte[128] buffer; step constants + IVs |
| LSH-512 | 768 B | 256 B | 2.3 KB | CV + submsg registers + byte[256] buffer; step constants + IVs |
| SHA-1 | 404 B | 64 B | — | uint[5] state + uint[80] W + byte[64] |
| MD5 | 80 B | 64 B | 768 B | uint[4] state + byte[64] buffer; K/S/G tables |
| IncrementalParallelHash | 40 B + input | configurable | 3.6 KB | buffers the message in a `MemoryStream`; the underlying SHAKE is created at finalize |

### Cipher Algorithms

Measured on the transform, which is where the round keys and chaining state live.

| Algorithm | Instance State | Block Size | Static Tables | Notes |
|-----------|---------------|-----------|---------------|-------|
| AES-128/192/256 (ECB/CBC/CTR) | 288 B | 16 B | 8.5 KB | Fixed uint[60] keys (same buffer for every key size) + IV + counter + feedback; T-tables |
| AES-GCM-128 | 645 B | 16 B | 8.6 KB | uint[44] round keys + H + 256 B Shoup table + 8 H-powers (CLMUL) |
| AES-GCM-192 | 677 B | 16 B | 8.6 KB | uint[52] round keys, otherwise as above |
| AES-GCM-256 | 709 B | 16 B | 8.6 KB | uint[60] round keys, otherwise as above |
| AES-CCM-128/192/256 | 248 B | 16 B | 8.5 KB | Fixed uint[60] round keys for every key size |
| ChaCha20 | 108 B | 64 B | 16 B | byte[32] key + byte[12] nonce + 64 B keystream buffer |
| ChaCha20-Poly1305 | 32 B | 64 B | 16 B | Retains only the key; per-message state is stack-local |
| XChaCha20-Poly1305 | 32 B | 64 B | 16 B | Retains only the key; the HChaCha subkey is derived per message |
| Ascon-AEAD-128 | 16 B | 16 B | — | Retains only the key; the permutation state is per call |
| SM4 (ECB/CBC/CTR) | 176 B | 16 B | 4.4 KB | Fixed uint[32] round keys + IV + counter + feedback; S-box + CK + 4 T-tables |
| ARIA-128/192/256 (ECB/CBC/CTR) | 338 B | 16 B | 1 KB | byte[272] round keys (one size for all key lengths) + IV + counter + feedback; 4 S-boxes |
| Camellia-128/192/256 (ECB/CBC/CTR) | 338 B | 16 B | 16 KB | ulong[34] subkeys (one size for all key lengths) + IV + counter + feedback; 8 SP tables |
| Kuznyechik (ECB/CBC/CTR) | 222 B | 16 B | 1 KB | byte[160] round keys + IV + counter + feedback; Pi/Pi⁻¹ + iteration constants, no precomputed LS tables |
| Kalyna-128/256 (ECB/CBC/CTR) | 1,298 B | 16 B | 35.3 KB | Fixed 1,216 B round-key buffer for every key size + IV + counter + feedback; 8 T-tables + 4 S-boxes and their inverses |
| Kalyna-512 (ECB/CBC/CTR) | 1,346 B | 32 B | 35.3 KB | Same round-key buffer, 32 B chaining state |
| SEED (ECB/CBC/CTR) | 190 B | 16 B | 4.1 KB | uint[32] round keys + IV + counter + feedback; 4 SS-boxes + KC |

### Message Authentication Codes (MAC)

| Algorithm | Instance State | Block Size | Static Tables | Notes |
|-----------|---------------|-----------|---------------|-------|
| KMAC128 | 376 B+ | 168 B | 3.6 KB | Keccak state + buffer + encoded key/customization (440 B with a 32-byte key) |
| KMAC256 | 344 B+ | 136 B | 3.6 KB | Keccak state + buffer + encoded key/customization (408 B with a 32-byte key) |
| HMAC-SHA-256 | 448 B | 64 B | 256 B | Two SHA-256 instances + ipad/opad key blocks |
| HMAC-SHA-512 | 824 B | 128 B | 640 B | Two SHA-512 instances + ipad/opad key blocks |
| HMAC-SHA3-256 | 1,018 B | 136 B | 3.6 KB | Two SHA3-256 instances + ipad/opad key blocks |
| Poly1305 | ~100 B | 16 B | — | 16 B block buffer + accumulator, r and s registers |
| AES-CMAC | 316 B | 16 B | 8.5 KB | K1/K2 subkeys + MAC + buffer + 15 round-key vectors |
| AES-GMAC | 646 B | 16 B | 8.6 KB | Same state as AES-GCM-128 |
| BLAKE2b (keyed) | 216 B | 128 B | — | Same as BLAKE2b + key material |
| BLAKE2s (keyed) | 120 B | 64 B | 640 B | Same as BLAKE2s + key material |
| BLAKE3 (keyed) | 3,072 B | 64 B | — | Same as BLAKE3 with key words |

### Post-Quantum KEM

Unlike the tables above, an ML-KEM object holds key material rather than absorbing state, so its
footprint is fixed by the parameter set and does not depend on any input. The three arrays it retains
are the seed (`d ‖ z`), the decapsulation key and the encapsulation key; all three are zeroed on
`Dispose`.

| Algorithm | Instance State | Encapsulation Key | Decapsulation Key | Ciphertext | Static Tables |
|-----------|---------------|-------------------|-------------------|-----------|---------------|
| ML-KEM-512 | 2,496 B | 800 B | 1,632 B | 768 B | 256 B + 3.6 KB |
| ML-KEM-768 | 3,648 B | 1,184 B | 2,400 B | 1,088 B | 256 B + 3.6 KB |
| ML-KEM-1024 | 4,800 B | 1,568 B | 3,168 B | 1,568 B | 256 B + 3.6 KB |

> Instance state is seed + decapsulation key + encapsulation key. A key imported from a
> decapsulation key rather than generated from a seed keeps no seed and is 64 B smaller; an
> encapsulation-key-only object keeps just that array. The 256 B of static tables are the 128
> NTT zetas; the 3.6 KB is the Keccak constant block shared with every SHA-3/SHAKE instance,
> which ML-KEM uses for G, H, J and the XOF — it is not a second copy.
>
> `Encapsulate` and `Decapsulate` allocate nothing on the managed heap: their working polynomials
> come from `ArrayPool<short>`, the hash and XOF objects from the shared `HashAlgorithmPool`, and
> the small fixed-size buffers from the stack.

> **Static tables** are shared across all instances of algorithms in the same family and are loaded
> once into memory. AES T-tables (8.5 KB) are shared by all AES-based algorithms (ECB, CBC, CTR, GCM,
> CCM, CMAC, GMAC). The Keccak figure is 192 B of round constants plus ~3.5 KB of SIMD constant
> vectors, built unconditionally when the type initializes — even on hardware with no AVX2 or
> AVX-512 — and shared by all SHA-3, SHAKE, cSHAKE, TurboSHAKE, KT, ParallelHash and KMAC instances.
> Tables declared as `ReadOnlySpan<byte>` (SM4, ARIA and Kalyna's S-boxes) live in the assembly image
> rather than on the heap, but are counted here all the same. Algorithms marked "—" use no lookup
> tables at all.

## Updating benchmark documentation

1. Run the cryptography benchmarks (either via the helper script or directly through BenchmarkSwitcher). This
   always produces both the markdown table (for quick local before/after comparison) and a full JSON export
   (for the trends database) — no extra flags needed:
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
2. Recorded runs live on the orphan **`benchmarks`** branch, one directory per run:
   ```
   cryptography/<code-commit>/<platform>/<framework>/
       run.json          what the numbers measure, and against which library versions
       machine-spec.md   the machine and runtime they were measured on
       <scenario>.md     one report per benchmark class
   ```
   A run is keyed by the commit its binaries were built from, not by the commit that records it, so two
   machines measuring the same build land in one run directory as two platform directories.

   The framework level below that does the same job for target frameworks: the same commit on the same
   machine under net10.0 and net8.0 is two runs, so the Table view can put them side by side exactly as
   it does two platforms. Pass `-Framework` to `run-benchmarks.ps1` and the matching `-TargetFramework`
   to `update-benchmark-docs.ps1`. A single run covering several runtimes at once
   (`-Runtimes "net8.0, net10.0"`) works too and needs neither: BenchmarkDotNet emits a `Runtime` column
   when the runtime varies, and each row is recorded against its own framework.

   Write the reports into a worktree of that branch:
   ```powershell
   git worktree add ../foundation-bench benchmarks
   .\scripts\update-benchmark-docs.ps1 -Project Cryptography -DestDir ../foundation-bench/cryptography
   ```
   The script derives a platform id from the report's machine-spec preamble (override with `-PlatformId`
   for self-reported machines) and writes `run.json`, defaulting the code commit to `HEAD` — pass
   `-CodeCommit` when recording after the fact. It never commits or pushes: review the result and commit
   in that worktree when the run is worth keeping.

   A new benchmark class also needs an entry in `scripts/update-benchmark-docs.ps1`, which maps report
   file names onto the archive's scenario names. The script copies what its mapping lists, so a report
   with no entry is silently skipped and never reaches the archive, the database or the dashboard; it
   warns about each unmapped report it finds, but the warning does not stop the run. The archive name
   matters beyond being a label — the trends importer derives the category from its prefix, which is why
   the KEM reports are recorded as `ml-kem-*.md`. Pushing the branch does not republish the site on
   its own — GitHub only runs workflows that exist in the pushed branch, and the orphan archive branch
   carries no `.github/`. Publish a new run deliberately with `gh workflow run docfx.yml`, or let the
   next push to `main` pick it up.

   It also records the version of every reference implementation the run measured against, read from
   the benchmark project's resolved NuGet graph. The dashboard shows that version in each point's
   tooltip, and marks any compared row whose library differs between the two runs — a series can step
   because the library it measures shipped a release, independently of any change here. Pass
   `-TargetFramework` if the benchmarks did not run on the default `net10.0`.
3. The dashboard database is a derived artifact, not a tracked file — SQLite rewrites pages throughout on
   every change, so committing it added a fresh multi-megabyte blob per rebuild for data that is fully
   reproducible from the archive. The docs workflow builds it, and so can you:
   ```powershell
   .\scripts\build-trends-database.ps1 -Project Cryptography
   ```
   `.\scripts\run-docfx.ps1` does this for both packages before building.

## See also

- [Hash Algorithms Reference](hash-algorithms.md)
- [Pooled Hash API](pooled-hash-api.md)
- [Cipher Algorithms Reference](cipher-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
- [XOF Mode (Extendable-Output)](xof-mode.md)
