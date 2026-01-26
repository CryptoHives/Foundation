```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                            | TestDataSize | Mean         | Error       | StdDev      | Allocated |
|--------------------------------------- |------------- |-------------:|------------:|------------:|----------:|
| ComputeHash · MD5 · MD5 (OS)           | 128B         |     516.8 ns |     3.01 ns |     2.67 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 128B         |     603.0 ns |     2.41 ns |     2.26 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 128B         |     702.8 ns |     2.56 ns |     2.39 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 137B         |     513.4 ns |     2.77 ns |     2.59 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 137B         |     602.3 ns |     3.32 ns |     2.94 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 137B         |     715.6 ns |     2.73 ns |     2.42 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 1KB          |   2,178.1 ns |    40.30 ns |    37.69 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 1KB          |   3,072.9 ns |    12.31 ns |    10.91 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 1KB          |   3,594.3 ns |     6.68 ns |     5.58 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 1025B        |   2,167.7 ns |     3.91 ns |     3.05 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 1025B        |   3,062.9 ns |     7.55 ns |     6.70 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 1025B        |   3,599.0 ns |    12.54 ns |    11.12 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 8KB          |  14,824.5 ns |    52.70 ns |    44.00 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 8KB          |  22,259.6 ns |    67.68 ns |    63.31 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 8KB          |  26,584.7 ns |    82.52 ns |    77.19 ns |      80 B |
|                                        |              |              |             |             |           |
| ComputeHash · MD5 · MD5 (OS)           | 128KB        | 231,909.6 ns | 1,010.36 ns |   843.70 ns |      80 B |
| ComputeHash · MD5 · MD5 (BouncyCastle) | 128KB        | 354,862.9 ns | 1,029.91 ns |   963.38 ns |      80 B |
| ComputeHash · MD5 · MD5 (Managed)      | 128KB        | 420,609.8 ns | 1,929.41 ns | 1,710.37 ns |      80 B |
