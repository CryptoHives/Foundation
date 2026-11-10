## Machine Specification

The benchmarks were run on the following machine:

```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26300.9818)
Intel Xeon E-2136 CPU 3.30GHz (Max: 3.31GHz), 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.403
[Host]    : .NET 10.0.14 (10.0.14, 10.0.1426.52326), X64 RyuJIT x86-64-v3
.NET 10.0 : .NET 10.0.14 (10.0.14, 10.0.1426.52326), X64 RyuJIT x86-64-v3
Job=.NET 10.0  Affinity=010101010000  Runtime=.NET 10.0
Toolchain=net10.0  Alloc Ratio=NA
```

Run settings: High performance plan, max processor state 99% (boost off, base clock 3.3 Ghz)

> **Note:** Results are machine-specific and may vary between systems. Run benchmarks locally for your specific hardware.