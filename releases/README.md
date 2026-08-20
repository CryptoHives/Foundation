# Release notes

One file per release, named by the **NuGet package version** — which is what you see on nuget.org
and write in a `csproj`. The git tag carries a fourth version part that NuGet drops
(`0.6.79.4022` → `0.6.79`); both are listed below.

Newest first.

| Version | Tag | Date | Headline |
|---|---|---|---|
| [0.6.79](0.6.79.md) | `0.6.79.4022` | 2026-08-12 | `AsyncKeyedLock<TKey>`, ARM SHA-1, `AsyncBarrier` deadlock fix |
| [0.6.51](0.6.51.md) | `0.6.51.25133` | 2026-07-30 | BLAKE3 on AVX-512/AVX2/SSSE3/NEON, `ISegmentOwner<T>`, porting guides |
| [0.6.21](0.6.21.md) | `0.6.21.58640` | 2026-07-04 | **First stable release.** Timeout support, three concurrency fixes |
| [0.5.34-preview](0.5.34-preview.md) | `0.5.34.36706-preview` | 2026-06-02 | Static `HashData` API, ParallelHash, per-package READMEs |
| [0.5.21-preview](0.5.21-preview.md) | `0.5.21.47953-preview` | 2026-04-28 | `IIncrementalHash`, Keccak on Arm64, BLAKE3 restructure |
| [0.5.13-preview](0.5.13-preview.md) | `0.5.13.21047-preview` | 2026-04-02 | Arm64 NEON, regional ciphers, upgradeable reader lock |
| [0.4.21-preview](0.4.21-preview.md) | `0.4.21.64110-preview` | 2026-02-28 | Symmetric ciphers, HMAC/CMAC/GMAC/Poly1305, KDFs |
| [0.4.11-preview](0.4.11-preview.md) | `0.4.11.4957-preview` | 2026-02-14 | Kupyna, LSH, broad perf work, `WaiterQueue<T>` |
| [0.3.19-preview](0.3.19-preview.md) | `0.3.19.26783-preview` | 2026-01-26 | **Cryptography package debuts** — hash algorithms |
| [0.2.43-preview](0.2.43-preview.md) | `0.2.43.28223-preview` | 2026-01-09 | Semaphore, RW lock, barrier, countdown event |
| [0.2.33-preview](0.2.33-preview.md) | `0.2.33.45035-preview` | 2025-12-09 | CI improvements, analyzer polish |
| [0.2.30-preview](0.2.30-preview.md) | `0.2.30.28431-preview` | 2025-12-08 | Analyzer docs and packaging fix |
| [0.2.28-preview](0.2.28-preview.md) | `0.2.28.48077-preview` | 2025-12-07 | **Analyzers package debuts** — the `CHT0xx` rules |
| [0.2.26-preview](0.2.26-preview.md) | `0.2.26.53860-preview` | 2025-12-06 | Local value-task-source cache, alloc-free CT registration |
| [0.2.22-preview](0.2.22-preview.md) | `0.2.22.44919-preview` | 2025-12-01 | Cancellation support, pool leak detection |
| [0.2.17-preview](0.2.17-preview.md) | `0.2.17.35073-preview` | 2025-11-23 | VS 2026 / .NET 10, `net472` dropped |
| [0.2.17-preview.ga9c29ac5a0](0.2.17-preview.ga9c29ac5a0.md) | `0.2.17-preview+a9c29ac5a0` | 2025-11-22 | Interim non-public build |
| [0.2.13-preview](0.2.13-preview.md) | `0.2.13.51184-preview` | 2025-11-20 | DocFX API documentation |
| [0.2.11-preview](0.2.11-preview.md) | `0.2.11.20784-preview` | 2025-11-19 | **First release** — Memory and Threading packages |

## When each package first shipped

| Package | Since |
|---|---|
| `CryptoHives.Foundation.Memory` | 0.2.11-preview |
| `CryptoHives.Foundation.Threading` | 0.2.11-preview |
| `CryptoHives.Foundation.Threading.Analyzers` | 0.2.28-preview |
| `CryptoHives.Foundation.Security.Cryptography` | 0.3.19-preview |

## The arc, in short

The repository starts in November 2025 as two small packages: pooled `IValueTaskSource<T>`
plumbing with three async primitives on top, and a set of `ArrayPool`-backed buffer types. The
first two months are spent making that foundation correct — cancellation, pool leak detection,
allocation-free token registration — before the primitive set is completed in 0.2.43.

January 2026 changes the character of the project: a cryptography package lands with ~12,000 lines
of managed hash implementations, and over the next four releases grows ciphers, MACs, KDFs and
hardware acceleration for both x86 and Arm64. Meanwhile the threading package turns inward,
replacing allocating structures with intrusive ones and chasing races out of the timeout and
cancellation paths.

0.6.21 is the first stable release. From there the emphasis shifts again — to vectorization depth
(BLAKE3 across four instruction sets), to measurement (benchmark runs move into a trends database
with interactive dashboards), and to keeping the documentation honest about what the code actually
does.
