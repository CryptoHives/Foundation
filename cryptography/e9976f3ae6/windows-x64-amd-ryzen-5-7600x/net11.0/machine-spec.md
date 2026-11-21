## Machine Specification

The benchmarks were run on the following machine:

```
BenchmarkDotNet v0.16.0-preview.2, Windows 11 (10.0.26300.9974)
AMD Ryzen 5 7600X 4.69GHz, 1 CPU, 12 logical and 6 physical cores
Memory: 127,14 GB Total, 98,4 GB Available
.NET SDK 11.0.100
[Host]    : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
.NET 11.0 : .NET 11.0.0 (11.0.0, 11.0.26.53018), X64 RyuJIT x86-64-v4
Method=TryComputeHash  Job=.NET 11.0  Affinity=010101010000
Runtime=.NET 11.0  Toolchain=CsProjCore
```

Run settings: AesKeyWrap measured separately on 2026-11-20 at 40f059d1, after its API change; the other classes at a2c51765 on 2026-11-17/18.

> **Note:** Results are machine-specific and may vary between systems. Run benchmarks locally for your specific hardware.