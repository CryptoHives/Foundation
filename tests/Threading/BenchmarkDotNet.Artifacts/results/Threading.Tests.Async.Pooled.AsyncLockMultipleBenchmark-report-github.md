```

BenchmarkDotNet v0.15.7, Windows 11 (10.0.26200.7171/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                               | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |-------------:|------:|----------:|------------:|
| LockUnlockPooledTaskMultipleAsync    | 0          |     13.57 ns |  0.64 |         - |          NA |
| LockUnlockPooledMultipleAsync        | 0          |     13.68 ns |  0.64 |         - |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 0          |     19.66 ns |  0.92 |         - |          NA |
| LockUnlockRefImplMultipleAsync       | 0          |     21.29 ns |  1.00 |         - |          NA |
| LockUnlockNonKeyedMultipleAsync      | 0          |     23.98 ns |  1.13 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 0          |     42.33 ns |  1.99 |     320 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 0          |     62.68 ns |  2.94 |     208 B |          NA |
|                                      |            |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 1          |     40.94 ns |  0.50 |         - |        0.00 |
| LockUnlockSemaphoreSlimMultipleAsync | 1          |     47.17 ns |  0.57 |      88 B |        0.41 |
| LockUnlockRefImplMultipleAsync       | 1          |     82.71 ns |  1.00 |     216 B |        1.00 |
| LockUnlockNitoMultipleAsync          | 1          |    106.64 ns |  1.29 |     728 B |        3.37 |
| LockUnlockNeoSmartMultipleAsync      | 1          |    126.39 ns |  1.53 |     416 B |        1.93 |
| LockUnlockPooledTaskMultipleAsync    | 1          |    464.20 ns |  5.61 |     264 B |        1.22 |
| LockUnlockNonKeyedMultipleAsync      | 1          |    497.59 ns |  6.02 |     336 B |        1.56 |
|                                      |            |              |       |           |             |
| LockUnlockSemaphoreSlimMultipleAsync | 10         |    289.79 ns |  0.41 |     880 B |        0.41 |
| LockUnlockPooledMultipleAsync        | 10         |    380.25 ns |  0.53 |         - |        0.00 |
| LockUnlockNitoMultipleAsync          | 10         |    582.42 ns |  0.82 |    4400 B |        2.04 |
| LockUnlockNeoSmartMultipleAsync      | 10         |    700.31 ns |  0.99 |    2288 B |        1.06 |
| LockUnlockRefImplMultipleAsync       | 10         |    710.91 ns |  1.00 |    2160 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 10         |  3,070.15 ns |  4.32 |    1344 B |        0.62 |
| LockUnlockNonKeyedMultipleAsync      | 10         |  3,195.60 ns |  4.50 |    2208 B |        1.02 |
|                                      |            |              |       |           |             |
| LockUnlockSemaphoreSlimMultipleAsync | 100        |  2,747.09 ns |  0.42 |    8800 B |        0.41 |
| LockUnlockPooledMultipleAsync        | 100        |  3,364.13 ns |  0.51 |    6432 B |        0.30 |
| LockUnlockNitoMultipleAsync          | 100        |  5,902.79 ns |  0.90 |   41120 B |        1.90 |
| LockUnlockNeoSmartMultipleAsync      | 100        |  6,414.06 ns |  0.97 |   21008 B |        0.97 |
| LockUnlockRefImplMultipleAsync       | 100        |  6,584.20 ns |  1.00 |   21600 B |        1.00 |
| LockUnlockPooledTaskMultipleAsync    | 100        | 31,842.52 ns |  4.84 |   18640 B |        0.86 |
| LockUnlockNonKeyedMultipleAsync      | 100        | 34,731.84 ns |  5.28 |   20992 B |        0.97 |
