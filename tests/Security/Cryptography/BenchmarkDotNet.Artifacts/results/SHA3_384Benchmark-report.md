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
| ComputeHash · SHA3-384 · SHA3-384 (Managed)      | 128B         |     910.1 ns |     3.20 ns |     2.67 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (BouncyCastle) | 128B         |   1,076.0 ns |     7.04 ns |     5.88 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (AVX2)         | 128B         |   1,092.7 ns |     4.82 ns |     4.27 ns |     144 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-384 · SHA3-384 (Managed)      | 137B         |     895.5 ns |     3.61 ns |     3.20 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (BouncyCastle) | 137B         |   1,078.1 ns |     4.53 ns |     4.24 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (AVX2)         | 137B         |   1,079.6 ns |     4.72 ns |     4.18 ns |     144 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-384 · SHA3-384 (Managed)      | 1KB          |   3,660.2 ns |     7.84 ns |     6.95 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (AVX2)         | 1KB          |   4,604.3 ns |    24.44 ns |    22.86 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (BouncyCastle) | 1KB          |   4,953.7 ns |    17.17 ns |    14.34 ns |     144 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-384 · SHA3-384 (Managed)      | 1025B        |   3,643.7 ns |    11.97 ns |    11.20 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (AVX2)         | 1025B        |   4,613.6 ns |    24.88 ns |    20.77 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (BouncyCastle) | 1025B        |   4,950.2 ns |    19.82 ns |    17.57 ns |     144 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-384 · SHA3-384 (Managed)      | 8KB          |  27,511.4 ns |   359.69 ns |   300.36 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (AVX2)         | 8KB          |  35,680.1 ns |   126.58 ns |   105.70 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (BouncyCastle) | 8KB          |  37,737.4 ns |   128.47 ns |   113.88 ns |     144 B |
|                                                  |              |              |             |             |           |
| ComputeHash · SHA3-384 · SHA3-384 (Managed)      | 128KB        | 433,372.7 ns | 1,655.57 ns | 1,467.62 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (AVX2)         | 128KB        | 564,120.7 ns | 1,647.46 ns | 1,375.70 ns |     144 B |
| ComputeHash · SHA3-384 · SHA3-384 (BouncyCastle) | 128KB        | 596,878.7 ns | 2,433.34 ns | 2,157.09 ns |     144 B |
