# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Repository Overview

**CryptoHives Open Source Initiative .NET Foundation Libraries** — a multi-target NuGet library suite providing cryptography, threading, and memory utilities. Published as `CryptoHives.Foundation.*` packages.

Solution file: `CryptoHives .NET Foundation.sln`

## Build & Test Commands

```powershell
# Build entire solution
dotnet build "CryptoHives .NET Foundation.sln"

# Run all tests
dotnet test "CryptoHives .NET Foundation.sln"

# Run a single test project
dotnet test tests/Threading/Threading.Tests.csproj
dotnet test tests/Security/Cryptography/Cryptography.Tests.csproj
dotnet test tests/Memory/Memory.Tests.csproj

# Run tests for a specific framework
dotnet test tests/Threading/Threading.Tests.csproj --framework net10.0

# Run tests for a legacy target
dotnet test tests/Threading/Threading.Tests.csproj /p:CustomTestTarget=net8.0

# Pack NuGet packages (Release only; pass /p:EnableExperimentalAlgorithms=false for publishing)
dotnet pack src/Threading/Threading.csproj -c Release
dotnet pack src/Security/Cryptography/Cryptography.csproj -c Release
dotnet pack src/Memory/Memory.csproj -c Release

# Test against locally packed NuGet packages
dotnet test /p:UsePackedNuGetPackages=true /p:NuGetPackageVersion=<version>
```

## Multi-Targeting Strategy

Target frameworks are centrally controlled by `targets.props` and vary by IDE/OS:

| Property | Frameworks |
|---|---|
| `LibTargetFrameworks` | `net462;netstandard2.0;netstandard2.1;net8.0;net10.0` |
| `CryptolibTargetFrameworks` | `net462;net472;netstandard2.0;netstandard2.1;net8.0;net10.0` |
| `TestsTargetFrameworks` | `net48;net8.0;net10.0` |

Use `CustomTestTarget` MSBuild property to test a single legacy or preview TFM (e.g., `net6.0`, `net9.0`). On macOS, only `net10.0` is targeted.

## Code Constraints (enforced globally via `common.props`)

- **C# 14**, nullable enabled, `TreatWarningsAsErrors=true`
- `AllowUnsafeBlocks=false` globally — only `Cryptography.csproj` overrides this to `true`
- `CheckForOverflowUnderflow=true` globally — `Cryptography.csproj` disables this (intentional bit-manipulation in crypto operations)
- `IsAotCompatible=true` for .NET 8+ targets
- Strong-name signing is active when `CryptoHives.Foundation.Key.snk` exists in the repo root (not checked in by default; SIGNASSEMBLY compile constant is set when signing)
- Experimental algorithms are compiled in (`#if EXPERIMENTAL`) unless `/p:EnableExperimentalAlgorithms=false` is passed at build time

## Project Structure

```
src/
  Memory/                    # CryptoHives.Foundation.Memory
  Security/Cryptography/     # CryptoHives.Foundation.Security.Cryptography
  Threading/                 # CryptoHives.Foundation.Threading
  Threading.Analyzers/       # CryptoHives.Foundation.Threading.Analyzers (Roslyn, netstandard2.0 only)
tests/
  Memory/
  Security/Cryptography/
  Threading/
  Threading.Analyzers/
```

Package versions are centrally managed in `Directory.Packages.props` (Central Package Management). Per-package READMEs live in each `src/<package>/README.md`.

## Architecture by Package

### `CryptoHives.Foundation.Security.Cryptography`

Self-contained managed implementations of cryptographic algorithms — no OS/hardware dependency for correctness, but hardware intrinsics are used for performance where available (AES-NI, ARM Crypto, AVX2, NEON, SSE/SSSE3). All implementations extend the `System.Security.Cryptography` base types for drop-in compatibility.

**Hash (`src/Security/Cryptography/Hash/`):**
- `HashAlgorithm` (base) → extends `System.Security.Cryptography.HashAlgorithm`
- `KeccakCore` — shared permutation base for SHA-3, SHAKE, cSHAKE, KMAC, Keccak, TurboSHAKE, KT
- `Sha2HashAlgorithm<T>` — generic SHA-2 base
- Concrete types: SHA-1, MD5, SHA-224/256/384/512, SHA-3 variants, SHAKE/cSHAKE, BLAKE2b/s, BLAKE3, RIPEMD-160, Ascon, SM3, Whirlpool, Kupyna, Streebog, LSH, ParallelHash, IncrementalParallelHash

**Cipher (`src/Security/Cryptography/Cipher/`):**
- `SymmetricCipher` (base) → extends `System.Security.Cryptography.SymmetricAlgorithm`
- `ICipherTransform` / `BlockCipherTransform` — transform abstraction
- `IAeadCipher` — authenticated encryption interface
- Block ciphers: AES (128/192/256), ARIA, Camellia, Kalyna, Kuznyechik, SEED, SM4 (each split into `*Core.cs` and key-size variants)
- AEAD modes: AES-GCM, AES-CCM, ChaCha20-Poly1305, Ascon-AEAD128
- Stream cipher: ChaCha20

**MAC (`src/Security/Cryptography/Mac/`):**
- `IMac` — common interface
- HMAC variants, GMAC, KMAC (128/256), Poly1305

**KDF (`src/Security/Cryptography/Kdf/`):**
- HKDF, KBKDF, ConcatKDF, PBKDF2

**KEM (`src/Security/Cryptography/Kem/`):**
- `IKem` — low-level stateless span-based KEM interface; `MLKem512`/`MLKem768`/`MLKem1024` implement it
- `MLKem` + `MLKemAlgorithm` — key-holding API mirroring .NET 10's `System.Security.Cryptography.MLKem` member-for-member, so it is a drop-in replacement (seed retention, §7.2/§7.3 import checks, zeroization on dispose, `pairwiseConsistencyTest` opt-out overloads). `IsSupported` is always `true` — the implementation is fully managed and never depends on OS support
- `MLKemCore` — FIPS 203 K-PKE and ML-KEM algorithms; `Ntt`/`Poly`/`PolyVec`/`Cbd`/`Compress`/`Encode` are the ML-KEM-specific math layer (q = 3329; do not reuse for ML-DSA, which needs int-based polys)
- Conformance: NIST ACVP vectors in `MLKemAcvpTests.cs` (keyGen, encaps, decaps incl. implicit rejection, key checks), each run through both `IKem` and the `MLKem` API. Vectors live in `tests/Security/Cryptography/TestData/mlkem-acvp-fips203.json.gz` (loaded by `MLKemAcvpVectors`, regenerated with `scripts/fetch-mlkem-acvp-vectors.py`), not in C# literals. Interop vs BouncyCastle and .NET 10 `MLKem` in `MLKemInteropTests.cs`
- Benchmarks/registry: `tests/.../Kem/KemAlgorithmRegistry.cs` + `Adapter/Kem/KemAdapters.cs` (`IKemRunner`) feed `Benchmarks/Kem/`

**Signatures (`src/Security/Cryptography/Dsa/`):**
- `IDsa` — low-level stateless span-based signature interface; `MLDsa44`/`MLDsa65`/`MLDsa87` implement it via shared `MLDsaEngine` validation
- `MLDsa` + `MLDsaAlgorithm` — key-holding API mirroring .NET 10's `System.Security.Cryptography.MLDsa` member-for-member (`ImportMLDsaPrivateSeed`/`ImportMLDsaPrivateKey`/`ImportMLDsaPublicKey` and the matching exports), so it is a drop-in replacement (seed retention, hedged signing with context strings, zeroization on dispose, `pairwiseConsistencyTest` opt-out overloads). `IsSupported` is always `true` — the implementation is fully managed and never depends on OS support. `SignMu`/`VerifyMu` remain deferred
- `MLDsaCore` — FIPS 204 KeyGen/Sign/Verify (rejection loop, hedged + deterministic); `Ntt` (q = 8380417, int-based, runtime-computed zeta table)/`Poly`/`PolyVec`/`Sampling`/`Encode` are the ML-DSA-specific math layer — independent of the ML-KEM layer by design
- Conformance: NIST ACVP vectors in `MLDsaAcvpTests.cs` (keyGen, sigGen deterministic + hedged with injected rnd, sigVer incl. modified commitment/z/hint/message), each run through both `IDsa` and the `MLDsa` API. Vectors live in `tests/Security/Cryptography/TestData/mldsa-acvp-fips204.json.gz` (loaded by `MLDsaAcvpVectors`, regenerated with `scripts/fetch-mldsa-acvp-vectors.py`), not in C# literals. Interop vs BouncyCastle and .NET 10 `MLDsa` in `MLDsaInteropTests.cs`
- Benchmarks/registry: `tests/.../Dsa/DsaAlgorithmRegistry.cs` + `Adapter/Dsa/DsaAdapters.cs` (`IDsaRunner`) feed `Benchmarks/Dsa/` (`MLDsaBenchmark` sign/verify/pre-hash, `MLDsaKeyGenBenchmark` incl. the no-PCT variant). The benchmark classes double as NUnit fixtures, so `dotnet test` exercises every benchmarkable registry entry
- SLH-DSA (FIPS 205) in `Dsa/SlhDsa/`: key-holding `SlhDsa` + `SlhDsaAlgorithm` mirroring .NET 10's `System.Security.Cryptography.SlhDsa` member-for-member (`ImportSlhDsaPrivateKey`/`ImportSlhDsaPublicKey` and matching exports, `byte[]` overloads beside the span ones, `IsSupported => true`, `GenerateKey(algorithm, pairwiseConsistencyTest)`; `SlhDsaAlgorithm` is `IEquatable<>` with `PrivateKeySizeInBytes`). 12 sets, deliberately no per-set `IDsa` wrappers — `IDsa` takes a 32-byte seed ξ while FIPS 205 keygen takes three n-byte seeds. `SlhDsaHash` abstracts the SHAKE256 vs SHA-2 instantiations (compressed ADRS, MGF1, HMAC, SHA-512 split for cat 3/5); `Wots`/`XmssTree`/`Hypertree`/`Fors` are pure hash plumbing over the existing SHA-2/SHAKE cores. The 's' sets sign slowly by design — round-trip tests default to 'f' sets, full matrix is `[Explicit]`
- SLH-DSA conformance: NIST ACVP vectors in `SlhDsaAcvpTests.cs`, each op through both `SlhDsaCore` and the `SlhDsa` API. Vectors in `tests/.../TestData/slhdsa-acvp-fips205.json.gz` (loaded by `SlhDsaAcvpVectors`, regenerated with `scripts/fetch-slhdsa-acvp-vectors.py`). **Unlike ML-KEM/ML-DSA this file is a stratified 180-case selection (~2.15 MB), not everything runnable** — signatures are 7.8–48.7 KB each, so the full 456-case set is 11.8 MB. `--profile full` writes a gitignored `*.full.json.gz` that `SlhDsaAcvpVectors` prefers automatically (or via `CRYPTOHIVES_SLHDSA_ACVP_VECTORS`); `.github/workflows/acvp-full-vectors.yml` runs it weekly. Interop vs BouncyCastle and .NET 10 `SlhDsa` in `SlhDsaInteropTests.cs`; drop-in surface proven at compile time by `SlhDsaApiTests.ApiSurface_MatchesTheInBoxType`
- SLH-DSA benchmarks/registry: all 12 sets live in the shared `DsaAlgorithmRegistry` (`SlhDsaFamilies`) with `SlhDsaAdapter`/`BouncyCastleSlhDsaAdapter`/`OSSlhDsaAdapter` in `Adapter/Dsa/SlhDsaAdapters.cs`, feeding `Benchmarks/Dsa/SlhDsaBenchmarks.cs`. **The six 's' sets are `excludeFromBenchmark: true`** — signing one is ~10⁶ hash invocations — so `-Family SlhDsa` measures the 'f' sets only
- Key formats (`src/Security/Cryptography/KeyFormats/`): the 27-member PKCS#8 / SubjectPublicKeyInfo / PEM block that all three PQC types expose is implemented **once** here and forwarded to from `MLKem.KeyFormats.cs`, `MLDsa.KeyFormats.cs` and `SlhDsa.KeyFormats.cs` — C# has no mixins, so the members are still declared per type, but none of them implements anything. DER goes through `System.Formats.Asn1`, which has a lib/ for every TFM including net462 and netstandard2.0, so **no DER is hand-rolled**
- ML-KEM and ML-DSA private keys are a `CHOICE { seed [0] IMPLICIT OCTET STRING, expandedKey OCTET STRING, both SEQUENCE }`; we write the **seed arm when the key has a seed** and the expanded arm otherwise, matching .NET 10 byte for byte. **SLH-DSA has no CHOICE and no seed** — its `privateKey` OCTET STRING is the raw 4n bytes. The 18 OIDs are in `PqcKeyOids.cs`; note the SLH-DSA arc is *not* in the usual set order (SHA2 = .20–.25, SHAKE = .26–.31)
- Encrypted PKCS#8 **writes PBES2 only** (PBKDF2 + AES-CBC) but **reads the legacy PKCS#12 schemes too**, since that is what older OpenSSL and Windows wrote. Those need TripleDES/RC2, which this library does not implement, so that path alone delegates to the platform. They are readable but not selectable — the enum does not offer them
- The six encrypted-export members take **`PbeOptions`** (`src/Security/Cryptography/Pbe/`, our namespace, all six TFMs) rather than the in-box `PbeParameters`, and this is **the only place the key-format surface diverges on purpose**. Two reasons: `PbeParameters` does not exist below netstandard2.1, and supplying it would mean declaring a type in `System.Security.Cryptography` — which hard-collides (CS0433) with `Microsoft.Bcl.Cryptography`. **This package declares nothing outside its own namespace; `grep -rn "^namespace System" src/` must stay empty.** Its `Pbkdf2Prf` is a closed enum of the PRFs RFC 8018 gives an OID, so an unencodable choice fails to compile rather than throwing at export — consistent with `Pbkdf2.cs`, which already avoids `HashAlgorithmName`
- **Why the in-box PQC types take `string` passwords — on the record.** The original `MLKem` proposal ([dotnet/runtime#113508](https://github.com/dotnet/runtime/issues/113508)) had **no** `string` password parameter; the overloads were added by [#115024](https://github.com/dotnet/runtime/issues/115024), whose stated reason is that "the string overloads for password exist **purely for ease-of-use for other downlevel platforms**" — i.e. .NET Framework / netstandard2.0 via `Microsoft.Bcl.Cryptography`, where spans are awkward. We target those same downlevel platforms and deliberately declined the trade. **Don't 'restore' them for parity** — it was considered and rejected. ML-KEM's API is settled; the two open sub-issues (#116304 Windows CNG, #116454 CryptoKit) are platform backends, now milestoned .NET 12
- **A `string` cannot be erased, and "just overwrite it" is not a workaround.** `MemoryMarshal.AsMemory(s.AsMemory()).Span` gives a writable view with no `unsafe`, but literals are interned — clearing one corrupts every other holder of that instance while `Length` still reads correct. And the KDF input is encoded from the characters before any wipe, so a copy has already escaped. `SecureString` is documented as not recommended and doesn't encrypt off-Windows; `System.Text.Utf8String` was prototyped for .NET Core 3.0 and never shipped
- **We match `AsymmetricAlgorithm`, not the in-box PQC types.** `AsymmetricAlgorithm` (the base `RSA`/`ECDsa`/`DSA` inherit) has **no** `string` password overload and **does** have `TryExportPkcs8PrivateKeyPem`/`TryExportSubjectPublicKeyInfoPem`/`TryExportEncryptedPkcs8PrivateKeyPem` taking a `Span<char>`. The in-box `MLDsa`/`MLKem`/`SlhDsa` invert both: 5 `string` password params and none of the three `Span<char>` exports. They are standalone classes (they cannot inherit `AsymmetricAlgorithm` — `KeySize`/`LegalKeySizes`/`SignatureAlgorithm`/XML formats are meaningless for a KEM or a fixed-parameter-set signature), so their key-format block was written fresh and drifted. Ours is standalone for the same reason and deliberately follows the older shape — **when in doubt about a key-format signature, copy `AsymmetricAlgorithm`, not the in-box PQC type**
- **Character and byte passwords are not interchangeable, but the rule is narrower than it looks.** Under **PBES2** (the only scheme we write) the character encoding *is* UTF-8, so `"pw"u8` and `"pw".AsSpan()` derive the same key for **any** text — non-ASCII and astral planes included; verified, not assumed. They diverge only on (a) legacy **PKCS#12** reads, where characters become BE-UTF16 + NUL, and (b) byte inputs that are not valid UTF-8, which no character password can reach — that is what the byte overload is for. `ErasableMemoryTests.Utf8LiteralAndCharacterPasswordsAgreeUnderPbes2` and `ABytePasswordThatIsNotValidUtf8IsUnreachableFromAnyCharacterPassword` pin both halves
- **Erasable memory only, on the key-format surface.** No public member takes a password, or returns a plaintext private key, as a `string` — a `string` cannot be overwritten, so a secret in one lives on the heap until the collector reuses the memory. Passwords are `ReadOnlySpan<char>`/`ReadOnlySpan<byte>`; the plaintext PEM export is `TryExportPkcs8PrivateKeyPem(Span<char>, out int)` sized by `GetPkcs8PrivateKeyPemSize()`, with **no allocating counterpart**; `ImportFromPem` takes only a span. `string` survives on exactly two members, whose content is public by construction: `ExportSubjectPublicKeyInfoPem` and `ExportEncryptedPkcs8PrivateKeyPem`. `ErasableMemoryTests` enforces this by reflection — adding a `string` password overload for convenience will fail the build's test run. The 21 members this replaced are **not deleted**: they are in the tree under `#if SECURITY_REVIEW`, which no shipping build defines (opt in with `-p:EnableSecurityReviewApi=true`), so a reviewer can diff them against what replaced them. `docfx/packages/security/cryptography/erasable-memory.md` is the porting table. One residual is documented rather than fixed: `AsnWriter` keeps an unclearable internal copy of everything written to it, and closing that would mean hand-rolling the two private-key DER structures
- Pre-hash variants (HashML-DSA FIPS 204 §5.4 / HashSLH-DSA FIPS 205 §10.2): `SignPreHash`/`VerifyPreHash` on both `MLDsa` and `SlhDsa`, in the exact in-box shape — a `byte[]` pair plus a span pair whose **second** parameter is the destination (`SignData(byte[], byte[])` takes the context second; spell the spans out). `PreHash.cs` holds the 12-OID table, the DER encoder and the 0x01-prefix builder. Vectors live in their own `mldsa-prehash-acvp-fips204.json.gz` (57 cases) and `slhdsa-prehash-acvp-fips205.json.gz` (37 cases), **kept separate from the pure files so regenerating one does not rewrite the other's multi-megabyte blob**; both are stratified to cover all 12 pre-hash functions and every parameter set, with `--profile prehash-full` and the weekly workflow for the complete 135- and 456-case sets. `PreHashApiTests.cs` carries the BouncyCastle `HashMLDsaSigner`/`HashSlhDsaSigner` and .NET 10 interop
- Pre-hash benchmarks live in the existing `MLDsaBenchmark`/`SlhDsaBenchmark` as `Sign (pre-hash)`/`Verify (pre-hash)` rows rather than separate classes, so each sits beside its pure counterpart. **The pre-hash function is not a free choice**: BouncyCastle binds one into each parameter set (`ml_dsa_65_with_sha512`, `slh_dsa_shake_256f_with_shake256`, …), so `DsaPreHash` makes the same choice for every implementation, and BouncyCastle's rows include the message-hashing cost because its signers take the message, not a digest


### `CryptoHives.Foundation.Threading`

Allocation-free async synchronization primitives backed by pooled `IValueTaskSource<T>` implementations. Designed to return `ValueTask` instead of `Task` for the hot path.

**Async primitives (`src/Threading/Async/Pooled/`):**
- `AsyncLock` — async exclusive lock (not reentrant), `using (await _lock.LockAsync())` pattern
- `AsyncKeyedLock<TKey>` — per-key exclusive lock; distinct keys never block each other
- `AsyncReaderWriterLock`
- `AsyncSemaphore`
- `AsyncAutoResetEvent`, `AsyncManualResetEvent`
- `AsyncBarrier`, `AsyncCountdownEvent`
- `AsyncConditionVariable` — "wait until condition" paired with an `AsyncLock`; signals are not stored
- `AsyncExchange<T>` — two-party rendezvous (async counterpart of Java's `Exchanger<V>`)

**ValueTask source infrastructure (`src/Threading/Pools/`):**
- `ManualResetValueTaskSource<T>` — intrusive doubly-linked list node and `IValueTaskSource<T>` base
- `PooledManualResetValueTaskSource<T>` — automatically returns to pool on completion
- `LocalManualResetValueTaskSource<T>` — stack-local (non-pooled) variant
- `WaiterQueue<T>` — intrusive FIFO queue for waiters
- `ValueTaskSourceObjectPool<T>` / `ValueTaskSourceObjectPools` — pool management

All lock waiters link into `WaiterQueue<T>` without heap allocation per waiter; contended waiters allocate a timer only when a timeout is specified.

### `CryptoHives.Foundation.Threading.Analyzers`

Roslyn analyzer + code-fix provider for the `Threading` NuGet package. Needs to be added separately.

Diagnostics:
| ID | Severity | Description |
|---|---|---|
| CHT001 | Error | ValueTask consumed multiple times (await, AsTask, Preserve, GetResult) |
| CHT002 | Warning | `GetAwaiter().GetResult()` on ValueTask (blocking) |
| CHT003 | Warning | ValueTask stored in field |
| CHT005 | Warning | `.Result` accessed directly |
| CHT007 | Info | `AsTask()` stored before signaling (perf) |
| CHT008 | Warning | ValueTask not awaited or consumed |
| CHT009 | Info | `SemaphoreSlim(1,1)` — replace with `AsyncLock` |
| CHT010 | Warning | ValueTask captured in lambda/closure |
| CHT011 | Warning | `async` method only forwards an awaited ValueTask; return it directly |
| CHT012 | Info | `async` ValueTask wrapper boxes a state machine when it suspends |

### `CryptoHives.Foundation.Memory`

**Buffers (`src/Memory/Buffers/`):**
- `ArrayPoolBufferWriter<T>` — `IBufferWriter<T>` that builds a `ReadOnlySequence<T>` from pooled chunks
- `ArrayPoolMemoryStream` — `MemoryStream` backed by `ArrayPool<byte>` segments
- `ReadOnlySequenceMemoryStream` — read-only `MemoryStream` over an existing `ReadOnlySequence<byte>`

**Pools (`src/Memory/Pools/`):**
- `ObjectOwner<T>` — `readonly struct` RAII wrapper around `ObjectPool<T>`; use with `using var`, never cast to `IDisposable` (avoids boxing)

## Testing Conventions

- Test framework: **NUnit 4**
- Each test project has `OutputType=Exe` and links `tests/Common/Main.cs` (NUnit entry point)
- Cryptography tests use **BouncyCastle**, **NaCl.Core**, **HashifyNET**, and other reference implementations for cross-validation
- Threading tests benchmark against **AsyncKeyedLock**, **Nito.AsyncEx**, **NeoSmart.AsyncLock**, **ProtoPromise**, **KeyedSemaphores**, **Dao.IndividualLock**, **AsyncUtilities**, **Microsoft.VisualStudio.Threading**, and (net10.0 only) **DotNext.Threading**
- Benchmark runs are recorded on the orphan `benchmarks` branch as `<package>/<code-commit>/<platform>/<framework>/`, keyed by the commit measured rather than the commit recording it; the trends database under `docfx/**/benchmark-trends/` is generated from it at build time and is not committed. Each run's `run.json` also records the resolved version of every third-party library it measured against. Record with `update-benchmark-docs.ps1 -DestDir <archive worktree>`, rebuild locally with `build-trends-database.ps1`
- `tests/Directory.Build.props` imports the root props and adds shared `GlobalSuppressions.cs`
- Some test-only packages (e.g., `Konscious.Security.Cryptography.Blake2`, `Blake3`) are excluded when strong-name signing is active because they are not signed

## CI / Versioning

- **Nerdbank.GitVersioning** controls package versions (local builds only; CI injects versions separately via `.azurepipelines/set-version.ps1`)
- CI pipelines: `.azurepipelines/test.yml` (test matrix across Windows/Linux/macOS), `azure-pipelines-nuget.yml` (NuGet packaging on main)
- `.github/workflows/test-published-packages.yml` runs weekly (and on demand) against the packages published on nuget.org: `scripts/get-published-version.ps1` resolves the newest version all four packages share, the run checks out that version's release tag, and the tests build with `/p:UsePackedNuGetPackages=true` so they consume the published artifacts. The Threading and Cryptography suites need the `STRONG_NAME_KEY` secret (base64 of the signing key) because the published assemblies grant `InternalsVisibleTo` to a signed test assembly; without it the run narrows to Memory
- `ContinuousIntegrationBuild=true` is set automatically in CI (enables deterministic builds, source linking); disabled when `CollectCoverage=true`
- Deterministic builds require `CryptoHives.Foundation.Key.snk` to be present for strong-name signing
