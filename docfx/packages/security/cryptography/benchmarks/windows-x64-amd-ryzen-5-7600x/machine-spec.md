## Machine Specification

The benchmarks were run on the following machine:

```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7840/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.103
[Host]    : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v4
.NET 10.0 : .NET 10.0.3 (10.0.3, 10.0.326.7603), X64 RyuJIT x86-64-v4
Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0
```

> **Note:** All benchmarks and SIMD optimizations have been developed and measured on this AMD Ryzen 5 / Windows 11 platform only. No results are available yet for Linux, macOS, or ARM processors (e.g. Apple Silicon, AWS Graviton). Performance characteristics — particularly SIMD dispatch paths and OS-backed implementations (CNG vs OpenSSL) — may differ significantly on other platforms. Run benchmarks locally for your specific hardware.