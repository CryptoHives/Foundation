# AGENTS.md

Instructions for AI coding agents working in this repository.

**The canonical guidance lives in [`CLAUDE.md`](CLAUDE.md).** Read it first — it covers the
repository overview, build/test commands, multi-targeting strategy, global code constraints
(C# 14, nullable, `TreatWarningsAsErrors`), project structure, per-package architecture, and
CI/versioning. Everything there applies to any agent, not just Claude.

## Quick orientation

- **Build:** `dotnet build "CryptoHives .NET Foundation.sln"`
- **Test:** `dotnet test "CryptoHives .NET Foundation.sln"` (NUnit 4)
- Code must compile clean under `TreatWarningsAsErrors=true`; match surrounding style.

## Guides for *consumers* of the published packages

Each shipped package embeds a `PORTING.md` at its package root — a machine-readable usage +
porting guide for agents adopting the library in a **downstream** project (not for editing
this repo). Sources:

- `src/Threading/PORTING.md` — async synchronization primitives
- `src/Memory/PORTING.md` — ArrayPool-backed buffers/streams/pools
- `src/Security/Cryptography/PORTING.md` — managed hashes, MAC, KDF, ciphers

The cross-package version is `docfx/porting-to-cryptohives.md` (published to the docs site at
<https://cryptohives.github.io/Foundation/porting-to-cryptohives.html>).
