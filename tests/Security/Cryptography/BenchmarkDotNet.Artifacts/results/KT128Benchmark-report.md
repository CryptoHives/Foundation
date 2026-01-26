```

BenchmarkDotNet v0.15.8, Windows 10 (10.0.19045.6456/22H2/2022Update)
Intel Xeon CPU E3-1240 v5 3.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 10.0.102
  [Host]    : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3
  .NET 10.0 : .NET 10.0.2 (10.0.2, 10.0.225.61305), X64 RyuJIT x86-64-v3

Method=ComputeHash  Job=.NET 10.0  Runtime=.NET 10.0  
Toolchain=net10.0  

```
| Description                           | TestDataSize | Mean         | Error     | StdDev    | Allocated |
|-------------------------------------- |------------- |-------------:|----------:|----------:|----------:|
| ComputeHash · KT128 · KT128 (Managed) | 128B         |     447.6 ns |   2.43 ns |   2.27 ns |     584 B |
| ComputeHash · KT128 · KT128 (AVX2)    | 128B         |     481.0 ns |   2.22 ns |   1.97 ns |     584 B |
|                                       |              |              |           |           |           |
| ComputeHash · KT128 · KT128 (Managed) | 137B         |     436.9 ns |   1.81 ns |   1.52 ns |     584 B |
| ComputeHash · KT128 · KT128 (AVX2)    | 137B         |     470.4 ns |   3.11 ns |   2.76 ns |     584 B |
|                                       |              |              |           |           |           |
| ComputeHash · KT128 · KT128 (Managed) | 1KB          |   1,791.4 ns |   6.42 ns |   5.36 ns |     584 B |
| ComputeHash · KT128 · KT128 (AVX2)    | 1KB          |   2,125.4 ns |   8.72 ns |   8.16 ns |     584 B |
|                                       |              |              |           |           |           |
| ComputeHash · KT128 · KT128 (Managed) | 1025B        |   1,797.1 ns |  11.98 ns |  10.62 ns |     584 B |
| ComputeHash · KT128 · KT128 (AVX2)    | 1025B        |   2,131.9 ns |  16.70 ns |  14.80 ns |     584 B |
|                                       |              |              |           |           |           |
| ComputeHash · KT128 · KT128 (Managed) | 8KB          |  11,291.4 ns |  54.75 ns |  45.72 ns |    1056 B |
| ComputeHash · KT128 · KT128 (AVX2)    | 8KB          |  13,929.6 ns |  58.03 ns |  51.44 ns |    1056 B |
|                                       |              |              |           |           |           |
| ComputeHash · KT128 · KT128 (Managed) | 128KB        | 158,661.9 ns | 753.14 ns | 667.64 ns |    8136 B |
| ComputeHash · KT128 · KT128 (AVX2)    | 128KB        | 199,685.6 ns | 511.97 ns | 453.85 ns |    8136 B |
