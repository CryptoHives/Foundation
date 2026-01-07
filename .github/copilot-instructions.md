# Copilot Instructions for CryptoHives .NET Foundation

## Purpose

This file documents how GitHub Copilot (or any automated editing agent) should add or modify code in this repository while following the project coding style and conventions.

## Repository Overview

The CryptoHives Open Source Initiative develops secure high-performance .NET libraries and tools for cryptography workloads and transformation pipelines.

**Repository Characteristics:**
- **Size:** Medium-scale codebase with less than 10 C# projects
- **Language:** C# with .NET 8.0/10.0 target framework, legacy .NET Standard 2.0/2.1 and .NET Framework 4.6.2/4.8 support
- **Architecture:** Modular design with projects for memory management, threading, and security
- **Type:** High-performance security focused class libraries and console applications
- **License:** MIT License

## Project Structure

Use the following structure when adding new projects, tests and analyzers:

```
src/
├── Threading/           # Threading utilities (ValueTask pooling, async primitives)
├── Threading.Analyzers/ # Roslyn analyzers for ValueTask misuse detection
└── Memory/              # Memory utilities (pooling, buffers, streams)

tests/
├── Threading/           # Runtime tests for Threading library
├── Threading.Analyzers/ # Analyzer unit tests (Roslyn testing framework)
└── Memory/              # Runtime tests for Memory library
```

## General rules

- Make only high confidence suggestions when reviewing code changes.
- Always use the latest version C#, currently C# 14 features.
- Never change global.json unless explicitly asked to.
- Never change package.json or package-lock.json files unless explicitly asked to.
- Never change NuGet.Config files unless explicitly asked to.
- Always trim trailing whitespace, and do not have whitespace on otherwise empty lines.
- Always save files as UTF8 with BOM.
- Always preserve the SPDX file header found at the top of source files. Example: `// SPDX-FileCopyrightText: 2025 The Keepers of the CryptoHives` followed by `// SPDX-License-Identifier: MIT`.
- Follow the existing file layout: preprocessor directives (e.g. `#if ...`) come first, then the `namespace` declaration, then `using` directives. Keep a single blank line between these regions as in existing files.
- Try to use `namespace` declarations that match the file path, unless a package works otherwise described. For example, files under `src/Threading/Async` use `namespace CryptoHives.Foundation.Threading.Async;`.
- Use PascalCase for public types and members, camelCase for local variables, and `_underscore` prefix for private fields (example: `_mutex`).
- Add XML documentation (`/// <summary>...`) for public types and public members following existing style and punctuation.
- Use XML remarks for properties and methods which may need explanation.
- Use XML `<param>` and `<returns>` tags for public methods.
- Use XML `<exception>` tags for public methods which may throw exceptions.
- Use XML `<code>` snippets for code examples.
- Add only XML `<inheritdoc/>` tags when overriding or implementing interface members.
- Keep methods short and focused. Prefer small helper methods when needed.
- Prefer `ValueTask` over `Task` for low-allocation hot-path async primitives when the project already uses `ValueTask` (see `Pooled.Async*` types).
- Use `Microsoft.Extensions.ObjectPool` and the existing pool policy types when adding pooled objects.
- Follow the project pattern for multi-targeting: code may include `#if` guards for framework-specific APIs (see `ReadOnlySequenceMemoryStream` for `NET8_0_OR_GREATER` checks).

## Analyzer Development

When working with the `*.Analyzers` projects:

- Target `netstandard2.0` only for maximum IDE/compiler compatibility
- Use `PrivateAssets="all"` on all analyzer package references
- Use `BuildOutputTargetFolder=analyzers/dotnet/cs` for proper NuGet packaging
- The following warnings are intentionally suppressed:
  - RS1007: Localization not required for this project
  - RS1038: CodeFix requires Workspaces reference (works in IDE scenarios)
- Include entries in `AnalyzerReleases.Shipped.md` and `AnalyzerReleases.Unshipped.md`
- Test analyzers using `AnalyzerTestBase<TAnalyzer>` with diagnostic location markers `{|#0:code|}`

## Formatting and ordering

- Follow all code-formatting and naming conventions defined in [`.editorconfig`](/.editorconfig).
- Keep `using` directives after the `namespace` (this repository places them inside the namespace block). Use one blank line between `using` groups and top-level members.
- Keep `private readonly` fields declared at the top of the type, before constructors.
- Place public constructors and properties before private helpers when possible.
- As an exception, for function argument checks use one line `if (condition) throw` statements, in contrary to the .editorconfig definition.

## Testing conventions

- Tests use NUnit. Test classes live under `tests/*` with corresponding project names which end in `.Tests`. File names end in `UnitTests.cs` or `Benchmark.cs`.
- Use `[TestFixture]` on classes and `[Test]` or `[Theory]` on methods. Async tests should return `Task` and use `async/await`.
- Try to use `[TestCaseSource]` and `[TestFixtureSource]` to increase the number of tests with a smaller code base.
- Prefer `[Parallelizable(ParallelScope.All)]` on test fixtures for parallel execution.
- Prefer `[CancelAfter(milliseconds)]` for async tests with timeouts instead of manual CancellationTokenSource.
- Follow existing test helpers and patterns (for example `AsyncAssert` helper used in other tests). Use `ConfigureAwait(false)` in library code where appropriate; tests often call it when awaiting.
- Name tests clearly to describe behavior (example: `WaitAsyncUnsetIsNotCompleted`).
- Do not use underscores in test method names.
- Prefer adding new tests to existing test files when possible.
- Do not add comments in test code with Act/Arrange/Assert sections unless necessary for clarity.
- Do not add the `Async` suffix to the method names of async tests.

## CI/CD Architecture

| Platform | File | Purpose |
|----------|------|---------|
| Azure DevOps | `azure-pipelines.yml` | Main CI - all frameworks, all platforms, scheduled builds |
| Azure DevOps | `azure-pipelines-nuget.yml` | NuGet packaging & code signing |
| GitHub Actions | `buildandtest.yml` | PR validation with Codecov integration |
| GitHub Actions | `weekly.yml` | Weekly comprehensive cross-platform build |

When modifying CI pipelines:
- Check for overlap between Azure DevOps and GitHub Actions to avoid redundancy
- The main `azure-pipelines.yml` already provides comprehensive coverage

## Safety checks before committing

- Run a build: `dotnet build` or use existing CI commands. Ensure no compilation warnings or errors were introduced.
- Run unit tests locally if appropriate: `dotnet test` for the relevant test project.
- Run docfx locally if documentation changes were made: `docfx docfx.json --serve`
- Keep changes minimal and follow the repository patterns. If introducing an API surface change, add or update unit tests to cover the behavior. Check docfx and readme for inconsistencies and fix them.

## When in doubt

- Search for a similar implementation in the repository and copy the style and structure used there (e.g., `AsyncAutoResetEvent`, `ReadOnlySequenceMemoryStream`).
- Prefer consistency with existing code over personal preference.
- Check the existing analyzer tests in `ValueTaskMisuseAnalyzerTests.cs` for patterns.

## Contact

- If the change is non-trivial or touches public API, open an issue or PR and request review from repository maintainers.
