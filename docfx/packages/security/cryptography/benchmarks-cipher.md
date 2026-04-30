# Cipher Algorithm Benchmarks

This page is the cipher benchmark run selector. Each published run is isolated by platform so numbers from different CPUs/OS combinations are not mixed in one table.

## Continuous Benchmark Trends

CI benchmark results are tracked on [Bencher](https://bencher.dev/perf/cryptohives-foundation-project). Use the testbed and benchmark filters on the Bencher dashboard to compare cipher latencies (including AEAD throughput per data size) across `linux-x64` and `macos-arm64` over time. Regression alerts are raised automatically when a run exceeds the configured threshold.

## Published Runs

| Platform ID | Host | Page |
|-------------|------|------|
| `macos-arm64-apple-m4` | macOS Tahoe, Apple M4, Arm64 | [Open Cipher Results](benchmarks/macos-arm64-apple-m4/cipher.md) |
| `windows-x64-amd-ryzen-5-7600x` | Windows 11, AMD Ryzen 5 7600X, X64 | [Open Cipher Results](benchmarks/windows-x64-amd-ryzen-5-7600x/cipher.md) |

## Recommended UI Structure

For scalable multi-platform benchmark navigation in docfx:

1. Keep this page as a compact run index (platform, CPU, date, link).
2. Keep one platform-specific page per family (`hash.md` / `cipher.md`) under each platform folder.
3. Add a short "comparison matrix" table here (selected algorithms only) for quick cross-platform glance.
4. Keep full raw algorithm tables in platform pages only.

This keeps navigation fast on mobile and desktop and avoids deeply nested docfx TOC noise.


---

## See also

- [Hash Benchmarks](benchmarks-hash.md)
- [Cipher Algorithms Reference](cipher-algorithms.md)
- [Hash Algorithms Reference](hash-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
