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
| ComputeHash · SHA-512/256 · SHA-512/256 (BouncyCastle) | 128B         |     864.8 ns |     2.40 ns |     2.24 ns |     112 B |
| ComputeHash · SHA-512/256 · SHA-512/256 (Managed)      | 128B         |     938.5 ns |     4.46 ns |     4.17 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/256 · SHA-512/256 (BouncyCastle) | 137B         |     868.1 ns |     3.23 ns |     2.70 ns |     112 B |
| ComputeHash · SHA-512/256 · SHA-512/256 (Managed)      | 137B         |     926.5 ns |     3.41 ns |     3.19 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/256 · SHA-512/256 (BouncyCastle) | 1KB          |   3,453.4 ns |    10.65 ns |     9.44 ns |     112 B |
| ComputeHash · SHA-512/256 · SHA-512/256 (Managed)      | 1KB          |   3,757.4 ns |    11.17 ns |     9.33 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/256 · SHA-512/256 (BouncyCastle) | 1025B        |   3,453.3 ns |    13.78 ns |    10.76 ns |     112 B |
| ComputeHash · SHA-512/256 · SHA-512/256 (Managed)      | 1025B        |   3,754.2 ns |    13.67 ns |    12.78 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/256 · SHA-512/256 (BouncyCastle) | 8KB          |  23,934.5 ns |    75.21 ns |    58.72 ns |     112 B |
| ComputeHash · SHA-512/256 · SHA-512/256 (Managed)      | 8KB          |  26,243.1 ns |    93.35 ns |    87.32 ns |     112 B |
|                                                        |              |              |             |             |           |
| ComputeHash · SHA-512/256 · SHA-512/256 (BouncyCastle) | 128KB        | 375,962.5 ns | 1,088.09 ns | 1,017.80 ns |     112 B |
| ComputeHash · SHA-512/256 · SHA-512/256 (Managed)      | 128KB        | 412,923.4 ns | 1,408.84 ns | 1,317.83 ns |     112 B |
