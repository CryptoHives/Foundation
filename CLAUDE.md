# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Build & Test Commands

```powershell
# Run tests for a legacy or preview target (e.g. net6.0, net9.0)
dotnet test tests/Threading/Threading.Tests.csproj /p:CustomTestTarget=net8.0

# Pack NuGet packages (Release only; pass /p:EnableExperimentalAlgorithms=false for publishing)
dotnet pack src/Security/Cryptography/Cryptography.csproj -c Release

# Test against locally packed NuGet packages
dotnet test /p:UsePackedNuGetPackages=true /p:NuGetPackageVersion=<version>
```

Target frameworks are centrally controlled by `targets.props` and vary by IDE/OS. On macOS, only `net10.0` is targeted.

## Code Constraints (enforced globally via `common.props`)

- **C# 14**, nullable enabled, `TreatWarningsAsErrors=true`
- `AllowUnsafeBlocks=false` globally — only `Cryptography.csproj` overrides this to `true`
- `CheckForOverflowUnderflow=true` globally — `Cryptography.csproj` disables this (intentional bit-manipulation in crypto operations)
- `IsAotCompatible=true` for .NET 8+ targets
- Strong-name signing is active when `CryptoHives.Foundation.Key.snk` exists in the repo root (not checked in by default; SIGNASSEMBLY compile constant is set when signing)
- Experimental algorithms are compiled in (`#if EXPERIMENTAL`) unless `/p:EnableExperimentalAlgorithms=false` is passed at build time

## Code Style

`.editorconfig` is authoritative for formatting (C# files are UTF-8 with BOM, trailing whitespace trimmed). Beyond it:

- Every file starts with the SPDX header, `// SPDX-FileCopyrightText: 2026 The Keepers of the CryptoHives` and `// SPDX-License-Identifier: MIT OR Apache-2.0`. Then any `#pragma`/`#if`, then a file-scoped `namespace` matching the folder (`src/Threading/Async/Pooled` → `CryptoHives.Foundation.Threading.Async.Pooled`), then the `using` directives — after the namespace, not before it
- `_camelCase` private fields, declared at the top of the type
- Argument checks are one-line `if (x is null) throw new ArgumentNullException(nameof(x));` — a deliberate exception to the brace rule in `.editorconfig`
- Public types and members get XML docs (`<summary>`, `<param>`, `<returns>`, `<exception>`); overrides and interface implementations get `<inheritdoc/>` only
- Byte and bit work goes through `BinaryPrimitives`/`BitOperations`; keep it endian-neutral, with a fast path for the common endianness where it pays
- Partial words in Cryptography go through `BinaryLoad` (read 0..n bytes, zero-padded) and `BinaryStore` (write the leading 0..n bytes) in `src/Security/Cryptography/shared/` — `UInt32`, `UInt64` and 16-byte pair shapes, both byte orders, span/`ref byte`/pointer forms. Never stage a word through a `stackalloc` buffer and copy part of it out, or loop over bytes with shifts. To write a value's low `n` bytes big-endian, shift it left by `(8 - n) * 8` and write it truncated
- Framework-specific APIs sit behind `#if NET8_0_OR_GREATER`-style guards rather than in separate files
- Do not edit `NuGet.Config` unless asked

## Comments

Write a comment only where the code does something a reader would **not** expect from reading
it. Otherwise write none. The audience is a consumer of this library, not a reviewer of the
change that introduced it.

- **No history.** Not what a PR changed, not what used to be there, not what was tried and
  reverted. Nobody reading this code later has that context or wants it.
- **No measurement figures.** A percentage nobody can reproduce — different machine, different
  run — is noise. Say only *that* something was measured and which way it came out:
  "showed a measurable improvement", "no measurable difference", "within measurement
  uncertainty". Never the number, the size, or the host.
- **Cap it.** One or two lines inline. A `<remarks>` only for a genuine trap or precondition,
  about three lines. Never multi-paragraph.
- **No narration.** Do not restate what the code does or re-explain a name.
- If a comment is needed to explain *what* a line does, rename things instead.

Benchmark figures belong in the commit message and the PR, where the run that produced them is
identified. But keep these comments also brief and without history. Avoid offensive language like beats, masters etc. 

## Verifying and reporting

Make the check a competent engineer would actually make, and report it the way they would.
Precision that carries no decision is noise, and chasing it wastes the reviewer's time and the
user's.

- **A test suite passes or it does not.** Say which. Do not report how many tests ran, do not
  put test counts in a commit message or PR description, and do not compare counts between
  runs. Counts move whenever a `[TestCase]` list, a data source or a merge changes — a
  difference in them is not a finding and is never worth investigating.
- **Do not re-verify what cannot have changed.** A comment- or documentation-only edit needs no
  build and no test run.
- **Report a direction where the direction is the point.** "Faster on the scalar tier", not a
  figure to three decimal places, unless the figure itself is the deliverable.
- **Do not enumerate what a sentence settles.** One representative example beats a table of
  twenty rows that all say the same thing.
- **Do not manufacture certainty.** If one run says a thing and the next disagrees, that is the
  finding — say so, rather than picking the run that reads better.

## Architecture by Package

### `CryptoHives.Foundation.Security.Cryptography`

Self-contained managed implementations of cryptographic algorithms — no OS/hardware dependency for correctness, but hardware intrinsics are used for performance where available (AES-NI, ARM Crypto, AVX2, NEON, SSE/SSSE3). All implementations extend the `System.Security.Cryptography` base types for drop-in compatibility. PQC (ML-KEM, ML-DSA, SLH-DSA), key formats and pre-hash detail is in `src/Security/Cryptography/CLAUDE.md`.

- `RandomNumberGenerator` (`Rng/`) — wraps the platform generator to give a span-based `Fill` on every TFM; all randomness the library draws itself (keys/IVs, PKCS#8 salt/IV, ISO 10126 padding, PQC seeds below net8) goes through it. Wraps rather than derives from the in-box type, and shares its name (CS0104 for consumers importing both)
- **This package declares nothing outside its own namespace; `grep -rn "^namespace System" src/` must stay empty.** No public member takes a password or returns a plaintext private key as a `string`
- `CryptographicOperations.ZeroMemory` (ours) is **the** way to erase a secret — in library code, tests and doc samples; never `Array.Clear`/`Span<T>.Clear()`. Use `FixedTimeEquals`, not `SequenceEqual`, for any MAC or tag check

### `CryptoHives.Foundation.Threading`

Allocation-free async synchronization primitives backed by pooled `IValueTaskSource<T>` implementations. Designed to return `ValueTask` instead of `Task` for the hot path. All lock waiters link into `WaiterQueue<T>` without heap allocation per waiter; contended waiters allocate a timer only when a timeout is specified. `AsyncReentrantLock` is experimental (`CHTEXP001`) and allocates per acquisition; `AsyncConditionVariable` signals are not stored.

The Roslyn analyzers (`CryptoHives.Foundation.Threading.Analyzers`, added separately) have notes in `src/Threading.Analyzers/CLAUDE.md`.

### `CryptoHives.Foundation.Memory`

- `ObjectOwner<T>` — `readonly struct` RAII wrapper around `ObjectPool<T>`; use with `using var`, never cast to `IDisposable` (avoids boxing)

## Testing Conventions

- Test framework: **NUnit 4**
- Each test project has `OutputType=Exe` and links `tests/Common/Main.cs` (NUnit entry point)
- Fixtures carry `[Parallelizable(ParallelScope.All)]`; prefer `[TestCaseSource]`/`[TestFixtureSource]` over near-duplicate tests, and `[CancelAfter(ms)]` over a hand-made `CancellationTokenSource`. Shared helpers such as `AsyncAssert` live in `tests/Common/Common.cs`
- Async tests return `Task` and drop the `Async` suffix. Name a test after the behaviour it checks, in the style of the file it joins — Threading uses `IsSetReturnsFalseAfterSetReleasesWaiter`, the Cryptography vector suites use `Aes128_Fips197AppendixB_Encrypt`
- Add to an existing test file where one fits; no Arrange/Act/Assert comments
- Cryptography tests use **BouncyCastle**, **NaCl.Core**, **HashifyNET**, and other reference implementations for cross-validation
- Threading tests benchmark against **AsyncKeyedLock**, **Nito.AsyncEx**, **NeoSmart.AsyncLock**, **ProtoPromise**, **KeyedSemaphores**, **Dao.IndividualLock**, **AsyncUtilities**, **Microsoft.VisualStudio.Threading**, and (net10.0 only) **DotNext.Threading**
- Benchmark runs are recorded on the orphan `benchmarks` branch as `<package>/<code-commit>/<platform>/<framework>/`, keyed by the commit measured rather than the commit recording it; the trends database under `docfx/**/benchmark-trends/` is generated from it at build time and is not committed. Each run's `run.json` also records the resolved version of every third-party library it measured against. Record with `update-benchmark-docs.ps1 -DestDir <archive worktree>`, rebuild locally with `build-trends-database.ps1`
- `tests/Directory.Build.props` imports the root props and adds shared `GlobalSuppressions.cs`
- Some test-only packages (e.g., `Konscious.Security.Cryptography.Blake2`, `Blake3`) are excluded when strong-name signing is active because they are not signed

## CI / Versioning

- **Nerdbank.GitVersioning** controls package versions (local builds only; CI injects versions separately via `.azurepipelines/set-version.ps1`)
- CI pipelines: `azure-pipelines.yml` → `.azurepipelines/test.yml` (test matrix across Windows/Linux/macOS), `azure-pipelines-nuget.yml` (NuGet packaging on main). GitHub Actions cover PR validation with Codecov (`buildandtest.yml`), formatting (`format-check.yml`), public API compatibility (`api-compat.yml`) and the docs site (`docfx.yml`); check for overlap with Azure DevOps before adding a pipeline. Weekly/monthly workflows (published packages, Mono runtimes) are described in `.github/CLAUDE.md`
- Docs build locally with `scripts/run-docfx.ps1`
- `ContinuousIntegrationBuild=true` is set automatically in CI (enables deterministic builds, source linking); disabled when `CollectCoverage=true`
- Deterministic builds require `CryptoHives.Foundation.Key.snk` to be present for strong-name signing
