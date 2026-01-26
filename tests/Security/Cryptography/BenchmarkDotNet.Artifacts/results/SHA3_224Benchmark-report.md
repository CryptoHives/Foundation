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
| ComputeHash · SHA3-224 · SHA3-224 (Managed)      | 128B         |     465.8 ns |     1.75 ns |     1.64 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (AVX2)         | 128B         |     551.1 ns |     3.62 ns |     3.21 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (BouncyCastle) | 128B         |     608.7 ns |     0.93 ns |     0.78 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-224 · SHA3-224 (Managed)      | 137B         |     453.5 ns |     1.75 ns |     1.37 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (AVX2)         | 137B         |     535.8 ns |     1.78 ns |     1.67 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (BouncyCastle) | 137B         |     611.2 ns |     2.22 ns |     2.08 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-224 · SHA3-224 (Managed)      | 1KB          |   3,155.4 ns |    14.72 ns |    13.77 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (AVX2)         | 1KB          |   3,908.5 ns |     9.54 ns |     8.46 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (BouncyCastle) | 1KB          |   4,023.4 ns |    20.44 ns |    17.07 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-224 · SHA3-224 (Managed)      | 1025B        |   3,154.4 ns |    10.31 ns |     8.61 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (AVX2)         | 1025B        |   3,889.5 ns |    15.30 ns |    13.56 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (BouncyCastle) | 1025B        |   4,014.3 ns |    13.40 ns |    11.88 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-224 · SHA3-224 (Managed)      | 8KB          |  20,023.3 ns |    43.79 ns |    36.57 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (AVX2)         | 8KB          |  26,155.1 ns |   107.57 ns |    95.36 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (BouncyCastle) | 8KB          |  27,652.5 ns |   102.37 ns |    95.76 ns |     112 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-224 · SHA3-224 (Managed)      | 128KB        | 317,093.7 ns | 1,135.02 ns | 1,006.17 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (AVX2)         | 128KB        | 410,885.9 ns | 1,661.57 ns | 1,472.94 ns |     112 B |
| ComputeHash · SHA3-224 · SHA3-224 (BouncyCastle) | 128KB        | 437,367.7 ns | 1,466.81 ns | 1,372.05 ns |     112 B |
