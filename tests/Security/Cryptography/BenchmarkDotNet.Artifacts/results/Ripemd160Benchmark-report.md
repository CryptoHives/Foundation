```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                          | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 128B         |     948.1 ns |     3.43 ns |     3.21 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 128B         |   1,414.0 ns |     5.25 ns |     4.91 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 137B         |     947.0 ns |     3.36 ns |     2.98 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 137B         |   1,431.2 ns |     4.24 ns |     3.96 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 1KB          |   5,032.3 ns |     6.36 ns |     5.31 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 1KB          |   7,539.9 ns |    29.87 ns |    26.48 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 1025B        |   5,008.6 ns |    18.60 ns |    16.48 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 1025B        |   7,553.4 ns |    22.04 ns |    19.54 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 8KB          |  37,005.8 ns |   134.07 ns |   125.41 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 8KB          |  56,312.4 ns |   189.90 ns |   177.63 ns |      96 B |
|                                                      |              |              |             |             |           |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (BouncyCastle) | 128KB        | 587,259.0 ns | 1,918.99 ns | 1,795.02 ns |      96 B |
| ComputeHash · RIPEMD-160 · RIPEMD-160 (Managed)      | 128KB        | 898,033.9 ns | 2,124.36 ns | 1,658.56 ns |      96 B |
