```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                      | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHA3-256 · SHA3-256 (Managed)      | 128B         |     464.2 ns |     1.57 ns |     1.39 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (AVX2)         | 128B         |     537.5 ns |     3.06 ns |     2.56 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (BouncyCastle) | 128B         |     609.5 ns |     1.93 ns |     1.71 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-256 · SHA3-256 (Managed)      | 137B         |   1,007.7 ns |     4.84 ns |     4.53 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (BouncyCastle) | 137B         |   1,087.6 ns |     4.45 ns |     4.17 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (AVX2)         | 137B         |   1,183.5 ns |     3.45 ns |     2.88 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-256 · SHA3-256 (Managed)      | 1KB          |   3,048.3 ns |    11.66 ns |    10.91 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (AVX2)         | 1KB          |   3,803.4 ns |    10.27 ns |     9.61 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (BouncyCastle) | 1KB          |   4,037.9 ns |    18.55 ns |    17.35 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-256 · SHA3-256 (Managed)      | 1025B        |   3,057.6 ns |     9.92 ns |     8.80 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (AVX2)         | 1025B        |   3,806.8 ns |    12.39 ns |    11.59 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (BouncyCastle) | 1025B        |   4,025.1 ns |    11.13 ns |     9.29 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-256 · SHA3-256 (Managed)      | 8KB          |  21,650.7 ns |    85.08 ns |    75.42 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (AVX2)         | 8KB          |  27,936.4 ns |    81.69 ns |    76.41 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (BouncyCastle) | 8KB          |  29,393.0 ns |    97.81 ns |    86.70 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-256 · SHA3-256 (Managed)      | 128KB        | 333,839.5 ns |   940.75 ns |   785.57 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (AVX2)         | 128KB        | 434,753.2 ns | 1,556.32 ns | 1,379.64 ns |     112 B |
| ComputeHash · SHA3-256 · SHA3-256 (BouncyCastle) | 128KB        | 461,271.1 ns | 1,334.01 ns | 1,182.57 ns |     112 B |
