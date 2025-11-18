```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.7171)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4
  .NET 9.0 : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

Job=.NET 9.0  Runtime=.NET 9.0  Toolchain=net9.0  

```
| Method                                                       | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| **NitoAsyncAutoResetEventWaitThenSetAsync**                      | **1**          |     **52.35 ns** |  **1.39** |     **160 B** |        **1.67** |
| PooledAsTaskContSync                                         | 1          |     48.98 ns |  1.31 |      80 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 1          |    365.86 ns |  9.75 |     224 B |        2.33 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 1          |     32.80 ns |  0.87 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 1          |     41.13 ns |  1.10 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 1          |     32.44 ns |  0.86 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 1          |     33.05 ns |  0.88 |         - |        0.00 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 1          |     37.54 ns |  1.00 |      96 B |        1.00 |
|                                                              |            |              |       |           |             |
| **NitoAsyncAutoResetEventWaitThenSetAsync**                      | **2**          |     **94.75 ns** |  **1.28** |     **320 B** |        **1.67** |
| PooledAsTaskContSync                                         | 2          |     99.85 ns |  1.34 |     160 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 2          |    828.16 ns | 11.15 |     336 B |        1.75 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 2          |     68.61 ns |  0.92 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 2          |     67.91 ns |  0.91 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 2          |     73.12 ns |  0.98 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 2          |     71.02 ns |  0.96 |         - |        0.00 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 2          |     74.39 ns |  1.00 |     192 B |        1.00 |
|                                                              |            |              |       |           |             |
| **NitoAsyncAutoResetEventWaitThenSetAsync**                      | **10**         |    **448.07 ns** |  **1.22** |    **1600 B** |        **1.67** |
| PooledAsTaskContSync                                         | 10         |    553.08 ns |  1.51 |     800 B |        0.83 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 10         |  2,480.53 ns |  6.77 |    1232 B |        1.28 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 10         |    355.25 ns |  0.97 |         - |        0.00 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 10         |    365.99 ns |  1.00 |         - |        0.00 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 10         |    388.64 ns |  1.06 |         - |        0.00 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 10         |    381.95 ns |  1.04 |         - |        0.00 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 10         |    367.15 ns |  1.00 |     960 B |        1.00 |
|                                                              |            |              |       |           |             |
| **NitoAsyncAutoResetEventWaitThenSetAsync**                      | **100**        |  **4,418.22 ns** |  **1.25** |   **16000 B** |        **1.67** |
| PooledAsTaskContSync                                         | 100        |  5,227.19 ns |  1.48 |   12288 B |        1.28 |
| PooledAsTaskAutoResetEventWaitThenSetAsync                   | 100        | 14,375.84 ns |  4.07 |   15600 B |        1.62 |
| PooledAsValueTaskContSyncAsyncAutoResetEventWaitThenSetAsync | 100        |  4,081.95 ns |  1.16 |    4288 B |        0.45 |
| PooledAsValueTaskAsyncAutoResetEventWaitThenSetAsync         | 100        |  3,866.11 ns |  1.09 |    4288 B |        0.45 |
| PooledContSyncAsyncAutoResetEventWaitThenSetAsync            | 100        |  4,255.85 ns |  1.20 |    4288 B |        0.45 |
| PooledAsyncAutoResetEventWaitThenSetAsync                    | 100        |  4,167.12 ns |  1.18 |    4288 B |        0.45 |
| RefImplAsyncAutoResetEventWaitThenSetAsync                   | 100        |  3,532.98 ns |  1.00 |    9600 B |        1.00 |
