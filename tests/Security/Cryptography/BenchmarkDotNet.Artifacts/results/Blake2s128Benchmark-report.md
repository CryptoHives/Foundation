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
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 128B         |       266.9 ns |     1.42 ns |     1.26 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 128B         |       277.6 ns |     1.30 ns |     1.22 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 128B         |       305.4 ns |     1.34 ns |     1.19 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 128B         |       315.1 ns |     1.57 ns |     1.47 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 128B         |     1,098.3 ns |     6.29 ns |     5.25 ns |      80 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 137B         |       356.9 ns |     1.55 ns |     1.45 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 137B         |       379.5 ns |     1.54 ns |     1.44 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 137B         |       416.9 ns |     1.84 ns |     1.63 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 137B         |       433.5 ns |     2.82 ns |     2.20 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 137B         |     1,601.8 ns |     7.11 ns |     6.65 ns |      80 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 1KB          |     1,521.1 ns |     4.77 ns |     4.23 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 1KB          |     1,747.3 ns |     5.21 ns |     4.35 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 1KB          |     1,862.9 ns |     6.56 ns |     5.82 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 1KB          |     1,955.9 ns |     9.71 ns |     8.61 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 1KB          |     8,171.3 ns |    58.26 ns |    48.65 ns |      80 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 1025B        |     1,600.8 ns |     7.04 ns |     5.50 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 1025B        |     1,840.4 ns |     9.79 ns |     8.68 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 1025B        |     1,983.3 ns |     7.76 ns |     6.48 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 1025B        |     2,070.9 ns |     4.48 ns |     3.74 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 1025B        |     8,677.3 ns |    30.22 ns |    25.23 ns |      80 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 8KB          |    11,369.7 ns |    34.76 ns |    30.82 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 8KB          |    12,908.0 ns |    47.50 ns |    44.43 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 8KB          |    14,200.7 ns |    43.81 ns |    36.59 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 8KB          |    14,911.4 ns |    72.50 ns |    60.54 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 8KB          |    64,531.0 ns |   271.91 ns |   241.04 ns |      80 B |
|                                                        |              |                |             |             |           |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (BouncyCastle) | 128KB        |   182,233.8 ns |   788.83 ns |   737.88 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (AVX2)         | 128KB        |   205,817.3 ns |   996.94 ns |   883.76 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSSE3)        | 128KB        |   225,878.4 ns | 1,173.73 ns |   980.12 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (SSE2)         | 128KB        |   237,619.3 ns |   876.96 ns |   777.40 ns |      80 B |
| ComputeHash · BLAKE2s-128 · BLAKE2s-128 (Managed)      | 128KB        | 1,027,734.3 ns | 4,042.30 ns | 3,583.39 ns |      80 B |
