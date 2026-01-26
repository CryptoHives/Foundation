```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 128B         |     553.1 ns |     2.20 ns |     1.95 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 128B         |     614.2 ns |     3.03 ns |     2.69 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 128B         |     631.7 ns |     2.76 ns |     2.58 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 137B         |   1,094.3 ns |     3.21 ns |     2.85 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 137B         |   1,106.8 ns |     4.36 ns |     4.08 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 137B         |   1,274.2 ns |     5.12 ns |     4.79 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 1KB          |   3,150.3 ns |     8.19 ns |     7.66 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 1KB          |   3,854.3 ns |    11.44 ns |     9.55 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 1KB          |   4,035.2 ns |    14.99 ns |    14.02 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 1025B        |   3,154.0 ns |     8.91 ns |     7.44 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 1025B        |   3,856.5 ns |    15.68 ns |    13.90 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 1025B        |   4,038.3 ns |    11.96 ns |     9.98 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 8KB          |  21,666.3 ns |    81.72 ns |    72.44 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 8KB          |  27,814.7 ns |    96.02 ns |    85.12 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 8KB          |  29,468.2 ns |    72.60 ns |    64.36 ns |     176 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE256 · SHAKE256 (Managed)      | 128KB        | 336,752.4 ns | 1,464.32 ns | 1,222.77 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (AVX2)         | 128KB        | 434,570.9 ns | 1,452.23 ns | 1,287.36 ns |     176 B |
| ComputeHash · SHAKE256 · SHAKE256 (BouncyCastle) | 128KB        | 461,245.9 ns |   935.62 ns |   875.18 ns |     176 B |
