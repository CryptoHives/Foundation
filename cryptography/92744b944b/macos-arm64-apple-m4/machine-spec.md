## Machine Specification

The benchmarks were run on the following machine:

```
BenchmarkDotNet v0.15.8, macOS Tahoe 26.4.1 (25E253) [Darwin 25.4.0]
Apple M4, 1 CPU, 10 logical and 10 physical cores
.NET SDK 10.0.201
[Host]    : .NET 10.0.5 (10.0.5, 10.0.526.15411), Arm64 RyuJIT armv8.0-a
.NET 10.0 : .NET 10.0.5 (10.0.5, 10.0.526.15411), Arm64 RyuJIT armv8.0-a
Method=TryComputeHash  Job=.NET 10.0  Runtime=.NET 10.0
Toolchain=net10.0
```

> **Note:** Results are machine-specific and may vary between systems. Run benchmarks locally for your specific hardware.