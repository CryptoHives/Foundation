```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                  | TestDataSize | Mean           | Error       | StdDev      | Allocated |
|--------------------------------------------- |------------- |---------------:|------------:|------------:|----------:|
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128B         |       615.2 ns |     3.95 ns |     3.30 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128B         |     1,247.1 ns |     5.63 ns |     5.27 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 137B         |       693.5 ns |     3.43 ns |     2.86 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 137B         |     1,920.6 ns |     4.82 ns |     4.27 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1KB          |     1,723.1 ns |     5.75 ns |     5.10 ns |     112 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1KB          |     9,515.7 ns |    45.07 ns |    37.64 ns |     112 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 1025B        |     1,991.2 ns |     8.09 ns |     7.17 ns |     224 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 1025B        |    10,842.4 ns |    42.42 ns |    37.60 ns |     168 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 8KB          |    13,884.5 ns |    37.29 ns |    31.14 ns |     896 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 8KB          |    81,879.6 ns |   216.21 ns |   191.66 ns |     504 B |
|                                              |              |                |             |             |           |
| ComputeHash · BLAKE3 · BLAKE3 (Managed)      | 128KB        |   228,447.0 ns |   837.46 ns |   742.39 ns |   14336 B |
| ComputeHash · BLAKE3 · BLAKE3 (BouncyCastle) | 128KB        | 1,264,102.7 ns | 6,701.59 ns | 5,940.79 ns |    7224 B |
