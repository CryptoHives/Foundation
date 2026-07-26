# MAC Algorithm Benchmarks

This page is the MAC benchmark run selector. Each published run is isolated by platform so numbers from different CPUs/OS combinations are not mixed in one table.

## Published Runs

| Platform ID | Host | Page |
|-------------|------|------|
| `macos-arm64-apple-m4` | macOS Tahoe, Apple M4, Arm64 | Not yet published (see note below) |
| `windows-x64-amd-ryzen-5-7600x` | Windows 11, AMD Ryzen 5 7600X, X64 | [Open MAC Results](benchmarks/windows-x64-amd-ryzen-5-7600x/mac.md) |

macOS Arm64 MAC benchmarks have not been run yet — only Hash and Cipher benchmarks are currently published for that platform. KMAC (Keccak-based) is covered on the [Hash Benchmarks](benchmarks-hash.md) page instead, since it shares the Keccak permutation core with SHA-3/SHAKE.

## Recommended UI Structure

Mirrors [Hash Benchmarks](benchmarks-hash.md): this page stays a compact run index, full raw tables live only in platform pages (`mac.md`), and a short comparison summary can be added here once more platforms are published.

---

## See also

- [Hash Algorithm Benchmarks](benchmarks-hash.md)
- [Cipher Algorithm Benchmarks](benchmarks-cipher.md)
- [MAC Algorithms Reference](mac-algorithms.md)
