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
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 128B         |     907.7 ns |     4.17 ns |     3.90 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 128B         |   1,073.0 ns |     5.25 ns |     4.66 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 128B         |   1,083.8 ns |     5.40 ns |     4.79 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 137B         |     893.8 ns |     2.58 ns |     2.28 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 137B         |   1,073.0 ns |     3.58 ns |     2.99 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 137B         |   1,078.1 ns |     3.36 ns |     2.62 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 1KB          |   3,641.2 ns |    10.17 ns |     9.01 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 1KB          |   4,569.2 ns |    11.75 ns |     9.81 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 1KB          |   4,946.8 ns |    18.38 ns |    16.29 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 1025B        |   3,636.4 ns |     8.42 ns |     7.47 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 1025B        |   4,562.1 ns |    11.42 ns |     9.54 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 1025B        |   4,973.0 ns |    15.17 ns |    13.45 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 8KB          |  27,390.7 ns |   116.30 ns |   103.10 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 8KB          |  35,370.4 ns |   104.80 ns |    87.51 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 8KB          |  38,172.3 ns |   103.82 ns |    86.70 ns |     144 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-384 · Keccak-384 (Managed)      | 128KB        | 437,608.9 ns | 1,521.49 ns | 1,348.77 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (AVX2)         | 128KB        | 562,103.7 ns | 1,939.70 ns | 1,814.40 ns |     144 B |
| ComputeHash · Keccak-384 · Keccak-384 (BouncyCastle) | 128KB        | 597,726.8 ns | 2,359.73 ns | 2,207.29 ns |     144 B |
