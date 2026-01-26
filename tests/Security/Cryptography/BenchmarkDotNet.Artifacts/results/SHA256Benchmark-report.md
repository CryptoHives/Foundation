```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                    | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|----------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHA-256 · SHA-256 (Managed)      | 128B         |     963.5 ns |     6.61 ns |     5.86 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (BouncyCastle) | 128B         |   1,022.8 ns |     4.05 ns |     3.78 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (OS)           | 128B         |   1,025.5 ns |     7.33 ns |     6.85 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-256 · SHA-256 (Managed)      | 137B         |     960.8 ns |     3.72 ns |     3.30 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (BouncyCastle) | 137B         |   1,027.0 ns |     3.17 ns |     2.64 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (OS)           | 137B         |   1,031.9 ns |     3.83 ns |     3.19 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-256 · SHA-256 (OS)           | 1KB          |   4,821.8 ns |    16.92 ns |    14.13 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (Managed)      | 1KB          |   5,005.7 ns |    20.61 ns |    18.27 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (BouncyCastle) | 1KB          |   5,292.4 ns |    25.16 ns |    23.54 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-256 · SHA-256 (OS)           | 1025B        |   4,821.1 ns |    29.22 ns |    25.90 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (Managed)      | 1025B        |   5,080.1 ns |    13.05 ns |    10.19 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (BouncyCastle) | 1025B        |   5,285.6 ns |    12.91 ns |    12.08 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-256 · SHA-256 (OS)           | 8KB          |  34,284.5 ns |    63.73 ns |    53.21 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (Managed)      | 8KB          |  36,541.5 ns |   102.07 ns |    95.48 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (BouncyCastle) | 8KB          |  39,274.0 ns |    76.85 ns |    60.00 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-256 · SHA-256 (OS)           | 128KB        | 538,284.4 ns | 1,552.89 ns | 1,376.60 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (Managed)      | 128KB        | 576,708.8 ns | 1,969.16 ns | 1,745.61 ns |     112 B |
| ComputeHash · SHA-256 · SHA-256 (BouncyCastle) | 128KB        | 620,136.0 ns | 2,427.74 ns | 2,270.91 ns |     112 B |
