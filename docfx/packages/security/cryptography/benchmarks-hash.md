# Hash Algorithm Benchmarks

This page is the hash benchmark run selector. Each published run is isolated by platform so numbers from different CPUs/OS combinations are not mixed in one table.

## Published Runs

| Platform ID | Host | Page |
|-------------|------|------|
| `macos-arm64-apple-m4` | macOS Tahoe, Apple M4, Arm64 | [Open Hash Results](benchmarks/macos-arm64-apple-m4/hash.md) |
| `windows-x64-amd-ryzen-5-7600x` | Windows 11, AMD Ryzen 5 7600X, X64 | [Open Hash Results](benchmarks/windows-x64-amd-ryzen-5-7600x/hash.md) |

## Recommended UI Structure

For scalable multi-platform benchmark navigation in docfx:

1. Keep this page as a compact run index (platform, CPU, date, link).
2. Keep one platform-specific page per family (`hash.md` / `cipher.md`) under each platform folder.
3. Add a short "comparison matrix" table here (selected algorithms only) for quick cross-platform glance.
4. Keep full raw algorithm tables in platform pages only.

This avoids one giant page, keeps git diffs readable, and supports growth to many platforms.

---

## See also

- [Cipher Benchmarks](benchmarks-cipher.md)
- [Hash Algorithms Reference](hash-algorithms.md)
- [MAC Algorithms Reference](mac-algorithms.md)
- [XOF Mode (Extendable-Output)](xof-mode.md)
