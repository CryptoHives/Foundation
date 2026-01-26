```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                            | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 128B         |       281.6 ns |     1.34 ns |     1.25 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 128B         |       285.1 ns |     2.31 ns |     1.93 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 128B         |       312.5 ns |     1.69 ns |     1.50 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 128B         |       323.9 ns |     2.21 ns |     2.07 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 128B         |     1,106.8 ns |     3.39 ns |     2.83 ns |     112 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 137B         |       364.4 ns |     2.00 ns |     1.77 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 137B         |       384.9 ns |     1.29 ns |     1.07 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 137B         |       426.1 ns |     2.33 ns |     2.06 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 137B         |       442.4 ns |     2.28 ns |     2.13 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 137B         |     1,625.7 ns |     5.30 ns |     4.70 ns |     112 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 1KB          |     1,528.7 ns |     6.38 ns |     5.33 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 1KB          |     1,774.5 ns |     9.52 ns |     8.91 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 1KB          |     1,865.3 ns |     6.19 ns |     5.17 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 1KB          |     1,961.1 ns |     5.12 ns |     4.27 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 1KB          |     8,151.7 ns |    27.30 ns |    22.79 ns |     112 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 1025B        |     1,621.8 ns |     3.99 ns |     3.54 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 1025B        |     1,889.5 ns |    11.38 ns |    10.65 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 1025B        |     1,983.0 ns |     6.37 ns |     5.32 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 1025B        |     2,078.0 ns |     7.34 ns |     6.13 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 1025B        |     8,645.7 ns |    17.29 ns |    14.44 ns |     112 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 8KB          |    11,466.7 ns |    47.66 ns |    39.80 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 8KB          |    13,083.1 ns |    67.25 ns |    56.16 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 8KB          |    14,211.1 ns |    81.55 ns |    72.29 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 8KB          |    14,905.5 ns |    54.72 ns |    45.70 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 8KB          |    64,433.2 ns |   214.77 ns |   179.34 ns |     112 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (BouncyCastle) | 128KB        |   181,229.3 ns |   770.24 ns |   682.80 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (AVX2)         | 128KB        |   208,292.4 ns |   909.55 ns |   850.80 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSSE3)        | 128KB        |   225,411.7 ns |   568.55 ns |   504.01 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (SSE2)         | 128KB        |   237,481.7 ns |   754.33 ns |   705.60 ns |     112 B |
| ComputeHash · BLAKE2s-256 · BLAKE2s-256 (Managed)      | 128KB        | 1,036,099.3 ns | 3,338.75 ns | 2,788.01 ns |     112 B |
