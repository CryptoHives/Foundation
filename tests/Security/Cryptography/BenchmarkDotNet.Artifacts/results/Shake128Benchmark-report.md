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
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 128B         |     550.5 ns |     1.98 ns |     1.75 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 128B         |     610.4 ns |     1.51 ns |     1.18 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 128B         |     624.4 ns |     1.69 ns |     1.32 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 137B         |     540.6 ns |     2.92 ns |     2.44 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 137B         |     611.7 ns |     1.82 ns |     1.62 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 137B         |     614.5 ns |     2.45 ns |     2.29 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 1KB          |   2,913.2 ns |    10.13 ns |     8.46 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 1KB          |   3,536.6 ns |    16.09 ns |    13.43 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 1KB          |   3,598.5 ns |    15.51 ns |    13.75 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 1025B        |   2,902.9 ns |     5.04 ns |     4.21 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 1025B        |   3,525.6 ns |    14.72 ns |    13.77 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 1025B        |   3,578.8 ns |     8.61 ns |     7.63 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 8KB          |  17,544.2 ns |    95.60 ns |    89.42 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 8KB          |  22,365.4 ns |   104.00 ns |    92.19 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 8KB          |  23,954.4 ns |    75.85 ns |    59.22 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHAKE128 · SHAKE128 (Managed)      | 128KB        | 273,925.8 ns | 1,026.58 ns |   960.26 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (AVX2)         | 128KB        | 352,184.4 ns | 1,104.54 ns |   979.15 ns |     112 B |
| ComputeHash · SHAKE128 · SHAKE128 (BouncyCastle) | 128KB        | 378,005.2 ns | 1,343.55 ns | 1,048.96 ns |     112 B |
