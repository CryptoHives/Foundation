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
| **NitoAsyncAutoResetEventWaitSetAsync**    | **1**          | **1.285 μs** | **0.1029 μs** | **0.2919 μs** | **1.300 μs** |  **1.21** |    **0.35** |         **-** |          **NA** |
| PooledAsyncAutoResetEventWaitSetAsync  | 1          | 1.492 μs | 0.1021 μs | 0.2931 μs | 1.400 μs |  1.40 |    0.37 |         - |          NA |
| RefImplAsyncAutoResetEventWaitSetAsync | 1          | 1.094 μs | 0.0571 μs | 0.1657 μs | 1.100 μs |  1.03 |    0.24 |         - |          NA |
| AutoResetEventWaitSet                  | 1          | 2.639 μs | 0.0656 μs | 0.1851 μs | 2.600 μs |  2.48 |    0.46 |         - |          NA |
|                                        |            |          |           |           |          |       |         |           |             |
| **NitoAsyncAutoResetEventWaitSetAsync**    | **10**         | **4.575 μs** | **0.0933 μs** | **0.2218 μs** | **4.600 μs** |  **1.00** |    **0.08** |         **-** |          **NA** |
| PooledAsyncAutoResetEventWaitSetAsync  | 10         | 5.131 μs | 0.1082 μs | 0.3087 μs | 5.100 μs |  1.12 |    0.10 |         - |          NA |
| RefImplAsyncAutoResetEventWaitSetAsync | 10         | 4.600 μs | 0.1122 μs | 0.3108 μs | 4.500 μs |  1.00 |    0.09 |         - |          NA |
| AutoResetEventWaitSet                  | 10         | 2.761 μs | 0.0579 μs | 0.1420 μs | 2.750 μs |  0.60 |    0.05 |         - |          NA |
