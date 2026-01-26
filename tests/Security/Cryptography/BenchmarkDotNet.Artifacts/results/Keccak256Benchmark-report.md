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
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 128B         |     451.8 ns |     1.39 ns |     1.24 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 128B         |     533.3 ns |     1.91 ns |     1.60 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 128B         |     607.8 ns |     1.92 ns |     1.50 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 137B         |   1,010.4 ns |     4.63 ns |     4.11 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 137B         |   1,074.0 ns |     3.12 ns |     2.76 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 137B         |   1,179.9 ns |     4.37 ns |     4.08 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 1KB          |   3,042.7 ns |     9.59 ns |     8.50 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 1KB          |   3,776.9 ns |     8.00 ns |     6.68 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 1KB          |   4,022.7 ns |    12.62 ns |    11.18 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 1025B        |   3,058.8 ns |    13.67 ns |    11.41 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 1025B        |   3,773.3 ns |     9.08 ns |     8.49 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 1025B        |   4,027.9 ns |    18.50 ns |    17.30 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 8KB          |  21,495.3 ns |    86.95 ns |    77.08 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 8KB          |  27,707.3 ns |    62.27 ns |    58.24 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 8KB          |  29,431.0 ns |   114.80 ns |    95.86 ns |     112 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-256 · Keccak-256 (Managed)      | 128KB        | 334,497.5 ns | 1,310.65 ns | 1,225.98 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (AVX2)         | 128KB        | 433,398.3 ns | 1,352.91 ns | 1,199.32 ns |     112 B |
| ComputeHash · Keccak-256 · Keccak-256 (BouncyCastle) | 128KB        | 461,526.1 ns | 1,831.58 ns | 1,623.65 ns |     112 B |
