```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                                 | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|------------------------------------------------------------ |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 128B         |     386.9 ns |   1.76 ns |   1.47 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 128B         |     421.3 ns |   2.47 ns |   2.06 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 137B         |     372.4 ns |   1.30 ns |   1.09 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 137B         |     405.0 ns |   1.26 ns |   1.05 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 1KB          |   1,779.7 ns |   4.19 ns |   3.50 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 1KB          |   2,062.1 ns |   7.08 ns |   6.28 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 1025B        |   1,777.2 ns |   7.22 ns |   6.40 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 1025B        |   2,049.9 ns |   4.34 ns |   3.39 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 8KB          |   9,550.1 ns |  36.04 ns |  28.14 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 8KB          |  11,937.8 ns |  45.93 ns |  42.97 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (Managed) | 128KB        | 148,718.3 ns | 658.58 ns | 616.04 ns |     112 B |
| ComputeHash · TurboSHAKE128-32 · TurboSHAKE128-32 (AVX2)    | 128KB        | 187,437.1 ns | 507.01 ns | 474.26 ns |     112 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 128B         |     442.0 ns |   2.72 ns |   2.41 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 128B         |     466.8 ns |   1.85 ns |   1.54 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 137B         |     423.5 ns |   1.69 ns |   1.58 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 137B         |     450.7 ns |   2.28 ns |   1.90 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 1KB          |   1,829.0 ns |   9.21 ns |   7.69 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 1KB          |   2,097.5 ns |   5.65 ns |   4.72 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 1025B        |   1,822.3 ns |   4.19 ns |   3.50 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 1025B        |   2,122.5 ns |  40.56 ns |  46.71 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 8KB          |   9,610.4 ns |  41.01 ns |  36.35 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 8KB          |  12,086.7 ns |  44.92 ns |  39.82 ns |     176 B |
|                                                             |              |              |           |           |           |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (Managed) | 128KB        | 148,179.0 ns | 775.79 ns | 647.82 ns |     176 B |
| ComputeHash · TurboSHAKE128-64 · TurboSHAKE128-64 (AVX2)    | 128KB        | 187,165.4 ns | 265.91 ns | 222.05 ns |     176 B |
