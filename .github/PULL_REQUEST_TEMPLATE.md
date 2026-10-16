
## Description

<!-- What does this PR do and why? -->

Closes #

## Type of change

<!-- Check all that apply. -->

- [ ] 🐛 Bug fix (non-breaking change that fixes an issue)
- [ ] ✨ New feature / algorithm (non-breaking change that adds functionality)
- [ ] 💥 Breaking change (fix or feature that changes existing public API or behavior)
- [ ] 📝 Documentation
- [ ] 🏗️ Build / CI / tooling
- [ ] ♻️ Refactor / performance (no functional change)

## Affected package(s)

- see auto labels

## Checklist

- [ ] The solution builds clean with `TreatWarningsAsErrors=true`.
- [ ] `dotnet format "CryptoHives .NET Foundation.sln"` changes are committed.
- [ ] `dotnet test "CryptoHives .NET Foundation.sln"` passes across the target frameworks.
- [ ] I added or updated tests covering the change.
- [ ] Public API changes are documented (XML docs, package `README.md`, and/or docfx).
- [ ] The code stays AOT-safe for the .NET 8+ targets (no new trim/AOT warnings).
- [ ] Every commit is signed off (`git commit -s`), see [CONTRIBUTING.md](https://github.com/CryptoHives/Foundation/blob/main/CONTRIBUTING.md#sign-off-your-commits).

## Notes for reviewers

<!--
  Cryptography: cross-validated against a reference implementation and known-answer test vectors?
  Threading:    ValueTask contract respected (no CHT00x analyzer violations)?
  Perf-sensitive: benchmark numbers before/after?
-->
