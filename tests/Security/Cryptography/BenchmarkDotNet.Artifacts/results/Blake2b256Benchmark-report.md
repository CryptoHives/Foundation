```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 128B         |     208.4 ns |     0.97 ns |     0.81 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 128B         |     208.6 ns |     1.39 ns |     1.16 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 128B         |     689.6 ns |     2.08 ns |     1.73 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 137B         |     317.9 ns |     1.87 ns |     1.75 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 137B         |     334.8 ns |     0.89 ns |     0.75 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 137B         |   1,308.6 ns |     4.47 ns |     3.73 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 1KB          |     979.4 ns |     5.04 ns |     4.72 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 1KB          |   1,084.5 ns |     3.31 ns |     2.58 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 1KB          |   4,881.2 ns |    27.74 ns |    23.16 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 1025B        |   1,083.4 ns |     7.58 ns |     6.33 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 1025B        |   1,198.6 ns |     6.59 ns |     5.84 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 1025B        |   5,566.7 ns |    18.29 ns |    17.11 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 8KB          |   7,139.3 ns |    25.69 ns |    20.06 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 8KB          |   7,920.7 ns |    25.90 ns |    22.96 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 8KB          |  38,484.9 ns |   193.50 ns |   171.53 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (BouncyCastle) | 128KB        | 113,043.4 ns |   478.77 ns |   447.84 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (AVX2)         | 128KB        | 125,569.6 ns |   434.03 ns |   406.00 ns |     112 B |
| ComputeHash · BLAKE2b-256 · BLAKE2b-256 (Managed)      | 128KB        | 611,058.4 ns | 2,462.32 ns | 2,182.78 ns |     112 B |
