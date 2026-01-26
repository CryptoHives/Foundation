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
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 128B         |     814.5 ns |     1.48 ns |     1.24 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 128B         |     991.0 ns |     5.27 ns |     4.40 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 128B         |   1,076.7 ns |     5.03 ns |     4.71 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 137B         |     798.6 ns |     1.14 ns |     0.95 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 137B         |     975.1 ns |     3.02 ns |     2.52 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 137B         |   1,080.2 ns |     4.64 ns |     4.12 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 1KB          |   5,406.7 ns |    20.33 ns |    18.02 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 1KB          |   6,853.8 ns |    30.38 ns |    25.37 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 1KB          |   7,249.6 ns |    19.00 ns |    17.78 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 1025B        |   5,371.2 ns |    14.27 ns |    13.35 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 1025B        |   6,814.0 ns |    26.44 ns |    23.44 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 1025B        |   7,227.8 ns |    23.88 ns |    21.17 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 8KB          |  39,003.2 ns |   145.75 ns |   121.71 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 8KB          |  50,653.0 ns |   206.78 ns |   172.67 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 8KB          |  53,726.8 ns |   216.19 ns |   180.53 ns |     176 B |
|                                                      |              |              |             |             |           |
| ComputeHash · Keccak-512 · Keccak-512 (Managed)      | 128KB        | 620,808.9 ns | 3,082.67 ns | 2,732.71 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (AVX2)         | 128KB        | 806,981.7 ns | 2,545.12 ns | 2,380.71 ns |     176 B |
| ComputeHash · Keccak-512 · Keccak-512 (BouncyCastle) | 128KB        | 854,772.2 ns | 2,461.59 ns | 2,182.13 ns |     176 B |
