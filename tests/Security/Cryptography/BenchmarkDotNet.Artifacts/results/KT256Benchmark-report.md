```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                           | TestDataSize | Mean         | Error       | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|------------:|----------:|----------:|
| ComputeHash · KT256 · KT256 (Managed) | 128B         |     459.4 ns |     2.31 ns |   2.17 ns |     616 B |
| ComputeHash · KT256 · KT256 (AVX2)    | 128B         |     488.5 ns |     2.52 ns |   2.23 ns |     616 B |
|                                       |              |              |             |           |           |
| ComputeHash · KT256 · KT256 (Managed) | 137B         |     858.6 ns |    17.09 ns |  18.99 ns |     616 B |
| ComputeHash · KT256 · KT256 (AVX2)    | 137B         |     914.8 ns |     4.80 ns |   4.49 ns |     616 B |
|                                       |              |              |             |           |           |
| ComputeHash · KT256 · KT256 (Managed) | 1KB          |   1,945.6 ns |     4.81 ns |   4.01 ns |     616 B |
| ComputeHash · KT256 · KT256 (AVX2)    | 1KB          |   2,270.7 ns |     6.71 ns |   5.60 ns |     616 B |
|                                       |              |              |             |           |           |
| ComputeHash · KT256 · KT256 (Managed) | 1025B        |   1,951.9 ns |    12.68 ns |  11.86 ns |     616 B |
| ComputeHash · KT256 · KT256 (AVX2)    | 1025B        |   2,266.5 ns |     7.92 ns |   6.61 ns |     616 B |
|                                       |              |              |             |           |           |
| ComputeHash · KT256 · KT256 (Managed) | 8KB          |  12,987.0 ns |    37.74 ns |  33.45 ns |    1056 B |
| ComputeHash · KT256 · KT256 (AVX2)    | 8KB          |  16,220.8 ns |    70.70 ns |  66.13 ns |    1056 B |
|                                       |              |              |             |           |           |
| ComputeHash · KT256 · KT256 (Managed) | 128KB        | 195,187.1 ns |   630.13 ns | 589.42 ns |    7656 B |
| ComputeHash · KT256 · KT256 (AVX2)    | 128KB        | 247,280.0 ns | 1,068.73 ns | 834.39 ns |    7656 B |
