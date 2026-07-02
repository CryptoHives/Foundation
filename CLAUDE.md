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

### `CryptoHives.Foundation.Threading`

Allocation-free async synchronization primitives backed by pooled `IValueTaskSource<T>` implementations. Designed to return `ValueTask` instead of `Task` for the hot path.

**Async primitives (`src/Threading/Async/Pooled/`):**
- `AsyncLock` — async exclusive lock (not reentrant), `using (await _lock.LockAsync())` pattern
- `AsyncReaderWriterLock`
- `AsyncSemaphore`
- `AsyncAutoResetEvent`, `AsyncManualResetEvent`
- `AsyncBarrier`, `AsyncCountdownEvent`

**ValueTask source infrastructure (`src/Threading/Pools/`):**
- `ManualResetValueTaskSource<T>` — intrusive doubly-linked list node and `IValueTaskSource<T>` base
- `PooledManualResetValueTaskSource<T>` — automatically returns to pool on completion
- `LocalManualResetValueTaskSource<T>` — stack-local (non-pooled) variant
- `WaiterQueue<T>` — intrusive FIFO queue for waiters
- `ValueTaskSourceObjectPool<T>` / `ValueTaskSourceObjectPools` — pool management

All lock waiters link into `WaiterQueue<T>` without heap allocation per waiter; contended waiters allocate a timer only when a timeout is specified.

### `CryptoHives.Foundation.Threading.Analyzers`

Roslyn analyzer + code-fix provider that ships bundled inside the `Threading` NuGet package (transitive via `analyzers/dotnet/cs`).

Diagnostics:
| ID | Severity | Description |
|---|---|---|
| CHT001 | Error | ValueTask awaited multiple times |
| CHT002 | Warning | `GetAwaiter().GetResult()` on ValueTask (blocking) |
| CHT003 | Warning | ValueTask stored in field |
| CHT004 | Error | `AsTask()` called multiple times |
| CHT005 | Warning | `.Result` accessed directly |
| CHT006 | Warning | ValueTask passed to `WhenAll`/`WhenAny` or similar |
| CHT007 | Info | `AsTask()` stored before signaling (perf) |
| CHT008 | Warning | ValueTask not awaited or consumed |
| CHT009 | Info | `SemaphoreSlim(1,1)` — replace with `AsyncLock` |
| CHT010 | Warning | ValueTask captured in lambda/closure |

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
- Threading tests benchmark against **AsyncKeyedLock**, **Nito.AsyncEx**, **NeoSmart.AsyncLock**, **ProtoPromise**
- `tests/Directory.Build.props` imports the root props and adds shared `GlobalSuppressions.cs`
- Some test-only packages (e.g., `Konscious.Security.Cryptography.Blake2`, `Blake3`) are excluded when strong-name signing is active because they are not signed

## CI / Versioning

- **Nerdbank.GitVersioning** controls package versions (local builds only; CI injects versions separately via `.azurepipelines/set-version.ps1`)
- CI pipelines: `.azurepipelines/test.yml` (test matrix across Windows/Linux/macOS), `azure-pipelines-nuget.yml` (NuGet packaging on main)
- `ContinuousIntegrationBuild=true` is set automatically in CI (enables deterministic builds, source linking); disabled when `CollectCoverage=true`
- Deterministic builds require `CryptoHives.Foundation.Key.snk` to be present for strong-name signing
