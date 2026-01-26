```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                            | TestDataSize | Mean         | Error        | StdDev       | Median       | Allocated |
|------------------------------------------------------- |------------- |-------------:|-------------:|-------------:|-------------:|----------:|
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 128B         |     211.0 ns |      1.19 ns |      1.11 ns |     210.5 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 128B         |     216.7 ns |      0.67 ns |      0.53 ns |     216.5 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 128B         |     706.8 ns |      7.01 ns |      6.21 ns |     705.1 ns |     176 B |
|                                                        |              |              |              |              |              |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 137B         |     349.9 ns |      7.02 ns |     12.30 ns |     345.9 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 137B         |     390.4 ns |      7.84 ns |     17.69 ns |     386.1 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 137B         |   1,403.3 ns |     27.89 ns |     53.73 ns |   1,397.6 ns |     176 B |
|                                                        |              |              |              |              |              |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 1KB          |   1,136.0 ns |     21.61 ns |     18.04 ns |   1,138.6 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 1KB          |   1,223.8 ns |     22.86 ns |     39.43 ns |   1,237.6 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 1KB          |   5,683.6 ns |    106.74 ns |     99.84 ns |   5,657.7 ns |     176 B |
|                                                        |              |              |              |              |              |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 1025B        |   1,178.4 ns |     23.17 ns |     37.42 ns |   1,185.9 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 1025B        |   1,326.3 ns |     26.49 ns |     64.98 ns |   1,317.8 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 1025B        |   5,896.5 ns |    109.77 ns |    107.81 ns |   5,877.4 ns |     176 B |
|                                                        |              |              |              |              |              |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 8KB          |   7,811.3 ns |    104.96 ns |     93.04 ns |   7,811.2 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 8KB          |   9,072.4 ns |    181.11 ns |    426.90 ns |   8,905.7 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 8KB          |  43,471.4 ns |    804.29 ns |  1,606.26 ns |  42,960.3 ns |     176 B |
|                                                        |              |              |              |              |              |           |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (BouncyCastle) | 128KB        | 117,055.7 ns |  2,338.22 ns |  5,372.46 ns | 113,695.1 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (AVX2)         | 128KB        | 142,227.0 ns |  2,545.98 ns |  2,381.51 ns | 142,703.7 ns |     176 B |
| ComputeHash · BLAKE2b-512 · BLAKE2b-512 (Managed)      | 128KB        | 650,432.4 ns | 12,945.31 ns | 21,269.52 ns | 648,715.0 ns |     176 B |
