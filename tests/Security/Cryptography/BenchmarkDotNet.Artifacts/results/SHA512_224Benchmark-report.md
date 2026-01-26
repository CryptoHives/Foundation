```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|------------------------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · SHA-512/224 · SHA-512/224 (BouncyCastle) | 128B         |     861.0 ns |     3.65 ns |     2.85 ns |     112 B |
| ComputeHash · SHA-512/224 · SHA-512/224 (Managed)      | 128B         |     926.8 ns |     4.91 ns |     4.59 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/224 · SHA-512/224 (BouncyCastle) | 137B         |     877.7 ns |     8.62 ns |     8.06 ns |     112 B |
| ComputeHash · SHA-512/224 · SHA-512/224 (Managed)      | 137B         |     927.6 ns |     2.80 ns |     2.34 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/224 · SHA-512/224 (BouncyCastle) | 1KB          |   3,450.9 ns |    11.70 ns |    10.94 ns |     112 B |
| ComputeHash · SHA-512/224 · SHA-512/224 (Managed)      | 1KB          |   3,831.6 ns |    74.37 ns |    69.56 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/224 · SHA-512/224 (BouncyCastle) | 1025B        |   3,447.6 ns |    14.79 ns |    13.11 ns |     112 B |
| ComputeHash · SHA-512/224 · SHA-512/224 (Managed)      | 1025B        |   3,759.9 ns |    22.17 ns |    20.74 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/224 · SHA-512/224 (BouncyCastle) | 8KB          |  23,977.4 ns |    72.09 ns |    67.44 ns |     112 B |
| ComputeHash · SHA-512/224 · SHA-512/224 (Managed)      | 8KB          |  26,249.4 ns |    67.75 ns |    60.06 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/224 · SHA-512/224 (BouncyCastle) | 128KB        | 376,378.3 ns | 1,280.16 ns | 1,134.83 ns |     112 B |
| ComputeHash · SHA-512/224 · SHA-512/224 (Managed)      | 128KB        | 411,626.3 ns | 1,288.98 ns | 1,142.64 ns |     112 B |
