```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHA-1 · SHA-1 (OS)           | 128B         |     511.4 ns |     4.43 ns |     3.70 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 128B         |     852.5 ns |     3.09 ns |     2.89 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 128B         |     959.9 ns |     1.84 ns |     1.63 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 137B         |     511.3 ns |     4.23 ns |     3.75 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 137B         |     859.1 ns |     2.91 ns |     2.58 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 137B         |     949.8 ns |     4.63 ns |     4.33 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 1KB          |   2,028.6 ns |     8.94 ns |     8.36 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 1KB          |   4,361.8 ns |    11.74 ns |     9.80 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 1KB          |   4,707.9 ns |    14.59 ns |    12.19 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 1025B        |   2,037.6 ns |     9.49 ns |     7.93 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 1025B        |   4,373.9 ns |    23.22 ns |    19.39 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 1025B        |   4,708.1 ns |     6.91 ns |     5.39 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 8KB          |  13,371.8 ns |    65.21 ns |    61.00 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 8KB          |  32,431.0 ns |   102.66 ns |    85.73 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 8KB          |  34,116.9 ns |   118.93 ns |   111.24 ns |      96 B |
|                                            |              |              |             |             |           |
| ComputeHash · SHA-1 · SHA-1 (OS)           | 128KB        | 207,992.7 ns |   822.84 ns |   769.69 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (BouncyCastle) | 128KB        | 512,697.2 ns | 2,163.37 ns | 2,023.61 ns |      96 B |
| ComputeHash · SHA-1 · SHA-1 (Managed)      | 128KB        | 538,967.7 ns | 3,446.95 ns | 3,055.63 ns |      96 B |
