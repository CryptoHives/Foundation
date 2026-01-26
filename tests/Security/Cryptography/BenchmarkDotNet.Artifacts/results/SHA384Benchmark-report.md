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
| ComputeHash · SHA-384 · SHA-384 (OS)           | 128B         |     807.4 ns |     8.11 ns |     6.77 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (BouncyCastle) | 128B         |     839.0 ns |     2.85 ns |     2.38 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (Managed)      | 128B         |     941.1 ns |     3.63 ns |     3.39 ns |     144 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-384 · SHA-384 (OS)           | 137B         |     811.8 ns |     3.86 ns |     3.43 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (BouncyCastle) | 137B         |     847.7 ns |     4.19 ns |     3.71 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (Managed)      | 137B         |     933.1 ns |     5.31 ns |     4.71 ns |     144 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-384 · SHA-384 (OS)           | 1KB          |   2,975.0 ns |     9.26 ns |     7.23 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (BouncyCastle) | 1KB          |   3,423.8 ns |    13.25 ns |    12.40 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (Managed)      | 1KB          |   3,744.5 ns |    13.09 ns |    10.93 ns |     144 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-384 · SHA-384 (OS)           | 1025B        |   2,972.4 ns |     7.09 ns |     6.29 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (BouncyCastle) | 1025B        |   3,425.9 ns |    15.00 ns |    13.30 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (Managed)      | 1025B        |   3,749.3 ns |    12.19 ns |    10.18 ns |     144 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-384 · SHA-384 (OS)           | 8KB          |  19,677.8 ns |    56.88 ns |    47.50 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (BouncyCastle) | 8KB          |  24,059.6 ns |   112.85 ns |    94.23 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (Managed)      | 8KB          |  26,199.4 ns |    63.55 ns |    56.33 ns |     144 B |
|                                                |              |              |             |             |           |
| ComputeHash · SHA-384 · SHA-384 (OS)           | 128KB        | 306,288.0 ns |   837.75 ns |   699.56 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (BouncyCastle) | 128KB        | 375,504.0 ns | 1,281.96 ns | 1,070.50 ns |     144 B |
| ComputeHash · SHA-384 · SHA-384 (Managed)      | 128KB        | 408,120.1 ns | 1,090.04 ns |   966.29 ns |     144 B |
