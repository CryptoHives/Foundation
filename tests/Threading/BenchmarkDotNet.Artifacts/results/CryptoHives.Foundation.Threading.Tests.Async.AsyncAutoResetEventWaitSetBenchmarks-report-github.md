```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.6899)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  .NET 8.0 : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4

Job=.NET 8.0  Runtime=.NET 8.0  Toolchain=net8.0  
InvocationCount=1  UnrollFactor=1  

```
| Method                                 | Iterations | Mean     | Error     | StdDev    | Median   | Ratio | RatioSD | Allocated | Alloc Ratio |
|--------------------------------------- |----------- |---------:|----------:|----------:|---------:|------:|--------:|----------:|------------:|
| **NitoAsyncAutoResetEventWaitSetAsync**    | **1**          | **1.437 μs** | **0.1003 μs** | **0.2909 μs** | **1.400 μs** |  **1.34** |    **0.35** |         **-** |          **NA** |
| PooledAsyncAutoResetEventWaitSetAsync  | 1          | 1.468 μs | 0.1117 μs | 0.3187 μs | 1.500 μs |  1.37 |    0.37 |         - |          NA |
| RefImplAsyncAutoResetEventWaitSetAsync | 1          | 1.095 μs | 0.0581 μs | 0.1657 μs | 1.050 μs |  1.02 |    0.22 |         - |          NA |
| AutoResetEventWaitSet                  | 1          | 2.689 μs | 0.0614 μs | 0.1741 μs | 2.700 μs |  2.51 |    0.43 |         - |          NA |
|                                        |            |          |           |           |          |       |         |           |             |
| **NitoAsyncAutoResetEventWaitSetAsync**    | **10**         | **4.641 μs** | **0.1093 μs** | **0.3066 μs** | **4.600 μs** |  **1.02** |    **0.10** |         **-** |          **NA** |
| PooledAsyncAutoResetEventWaitSetAsync  | 10         | 5.240 μs | 0.1390 μs | 0.4056 μs | 5.100 μs |  1.16 |    0.12 |         - |          NA |
| RefImplAsyncAutoResetEventWaitSetAsync | 10         | 4.557 μs | 0.1184 μs | 0.3320 μs | 4.500 μs |  1.01 |    0.10 |         - |          NA |
| AutoResetEventWaitSet                  | 10         | 2.830 μs | 0.0696 μs | 0.1905 μs | 2.800 μs |  0.62 |    0.06 |         - |          NA |
