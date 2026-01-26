```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                        | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128B         |     550.2 ns |     2.80 ns |     2.62 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128B         |     616.5 ns |     3.31 ns |     2.76 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128B         |     629.7 ns |     3.96 ns |     3.30 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 137B         |   1,088.8 ns |     3.71 ns |     3.29 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 137B         |   1,100.0 ns |     3.84 ns |     3.00 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 137B         |   1,270.3 ns |     5.23 ns |     4.89 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1KB          |   3,169.7 ns |    11.11 ns |     9.85 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1KB          |   3,878.8 ns |    20.30 ns |    16.95 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1KB          |   4,033.0 ns |    12.06 ns |    10.69 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 1025B        |   3,138.3 ns |     9.45 ns |     7.89 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 1025B        |   3,851.1 ns |     9.22 ns |     8.17 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 1025B        |   4,038.0 ns |    13.20 ns |    11.70 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 8KB          |  21,552.6 ns |    89.78 ns |    79.58 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 8KB          |  27,682.3 ns |    62.07 ns |    51.83 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 8KB          |  29,471.3 ns |   127.20 ns |   112.76 ns |     176 B |
|                                                    |              |              |             |             |           |
| ComputeHash · cSHAKE256 · cSHAKE256 (Managed)      | 128KB        | 334,146.6 ns | 1,387.49 ns | 1,297.86 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (AVX2)         | 128KB        | 434,701.8 ns | 1,355.32 ns | 1,267.77 ns |     176 B |
| ComputeHash · cSHAKE256 · cSHAKE256 (BouncyCastle) | 128KB        | 460,989.8 ns | 1,732.24 ns | 1,446.50 ns |     176 B |
