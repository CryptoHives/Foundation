## Machine Specification

The benchmarks were run on the following machine:

```
BenchmarkDotNet v0.15.8, Windows 11 (10.0.26300.9711)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.403
[Host]    : .NET 10.0.14 (10.0.14, 10.0.1426.52326), X64 RyuJIT x86-64-v4
.NET 10.0 : .NET 10.0.14 (10.0.14, 10.0.1426.52326), X64 RyuJIT x86-64-v4
Method=TryComputeHash  Job=.NET 10.0  Affinity=010101010000
Runtime=.NET 10.0  Toolchain=net10.0
```

Run settings: High performance plan, max processor state 99% (boost off, base clock 4.7 GHz)

> **Note:** Results are machine-specific and may vary between systems. Run benchmarks locally for your specific hardware.