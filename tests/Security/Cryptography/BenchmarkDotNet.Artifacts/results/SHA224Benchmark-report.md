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
| ComputeHash · SHA-224 · SHA-224 (Managed)      | 128B         |     962.7 ns |     2.42 ns |     1.89 ns |     112 B |
| ComputeHash · SHA-224 · SHA-224 (BouncyCastle) | 128B         |   1,074.3 ns |     3.95 ns |     3.50 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-224 · SHA-224 (Managed)      | 137B         |     958.0 ns |     4.48 ns |     3.74 ns |     112 B |
| ComputeHash · SHA-224 · SHA-224 (BouncyCastle) | 137B         |   1,070.0 ns |     4.34 ns |     4.06 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-224 · SHA-224 (Managed)      | 1KB          |   5,003.2 ns |    15.44 ns |    13.69 ns |     112 B |
| ComputeHash · SHA-224 · SHA-224 (BouncyCastle) | 1KB          |   5,462.9 ns |    16.37 ns |    14.51 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-224 · SHA-224 (Managed)      | 1025B        |   5,085.6 ns |    20.91 ns |    17.46 ns |     112 B |
| ComputeHash · SHA-224 · SHA-224 (BouncyCastle) | 1025B        |   5,463.2 ns |    15.92 ns |    14.11 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-224 · SHA-224 (Managed)      | 8KB          |  36,544.1 ns |    64.56 ns |    57.23 ns |     112 B |
| ComputeHash · SHA-224 · SHA-224 (BouncyCastle) | 8KB          |  41,060.7 ns |   120.24 ns |   100.41 ns |     112 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-224 · SHA-224 (Managed)      | 128KB        | 577,304.2 ns | 1,961.96 ns | 1,739.23 ns |     112 B |
| ComputeHash · SHA-224 · SHA-224 (BouncyCastle) | 128KB        | 641,372.0 ns | 1,941.80 ns | 1,621.49 ns |     112 B |
