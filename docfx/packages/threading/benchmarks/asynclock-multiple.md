```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                               | Iterations | cancellationType | Mean         | Ratio | Allocated | Alloc Ratio |
|------------------------------------- |----------- |----------------- |-------------:|------:|----------:|------------:|
| LockUnlockPooledMultipleAsync        | 0          | None             |     13.89 ns |  1.00 |         - |          NA |
| LockUnlockPooledTaskMultipleAsync    | 0          | None             |     15.16 ns |  1.09 |         - |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 0          | None             |     19.86 ns |  1.43 |         - |          NA |
| LockUnlockRefImplMultipleAsync       | 0          | None             |     20.94 ns |  1.51 |         - |          NA |
| LockUnlockNonKeyedMultipleAsync      | 0          | None             |     24.14 ns |  1.74 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 0          | None             |     41.99 ns |  3.02 |     320 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 0          | None             |     63.27 ns |  4.55 |     208 B |          NA |
|                                      |            |                  |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 0          | NotCancelled     |     14.41 ns |  1.00 |         - |          NA |
| LockUnlockPooledTaskMultipleAsync    | 0          | NotCancelled     |     14.67 ns |  1.02 |         - |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 0          | NotCancelled     |     19.94 ns |  1.38 |         - |          NA |
| LockUnlockNonKeyedMultipleAsync      | 0          | NotCancelled     |     24.20 ns |  1.68 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 0          | NotCancelled     |     42.97 ns |  2.98 |     320 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 0          | NotCancelled     |     62.77 ns |  4.36 |     208 B |          NA |
|                                      |            |                  |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 1          | None             |     44.73 ns |  1.00 |         - |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 1          | None             |     46.13 ns |  1.03 |      88 B |          NA |
| LockUnlockRefImplMultipleAsync       | 1          | None             |     84.39 ns |  1.89 |     216 B |          NA |
| LockUnlockNitoMultipleAsync          | 1          | None             |    105.63 ns |  2.36 |     728 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 1          | None             |    128.33 ns |  2.87 |     416 B |          NA |
| LockUnlockPooledTaskMultipleAsync    | 1          | None             |    446.45 ns |  9.98 |     272 B |          NA |
| LockUnlockNonKeyedMultipleAsync      | 1          | None             |    522.64 ns | 11.68 |     352 B |          NA |
|                                      |            |                  |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 1          | NotCancelled     |     59.50 ns |  1.00 |         - |          NA |
| LockUnlockNeoSmartMultipleAsync      | 1          | NotCancelled     |    126.93 ns |  2.13 |     416 B |          NA |
| LockUnlockNitoMultipleAsync          | 1          | NotCancelled     |    425.70 ns |  7.15 |     968 B |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 1          | NotCancelled     |    543.58 ns |  9.14 |     504 B |          NA |
| LockUnlockPooledTaskMultipleAsync    | 1          | NotCancelled     |    568.54 ns |  9.56 |     272 B |          NA |
| LockUnlockNonKeyedMultipleAsync      | 1          | NotCancelled     |    675.11 ns | 11.35 |     640 B |          NA |
|                                      |            |                  |              |       |           |             |
| LockUnlockSemaphoreSlimMultipleAsync | 10         | None             |    301.30 ns |  0.79 |     880 B |          NA |
| LockUnlockPooledMultipleAsync        | 10         | None             |    381.45 ns |  1.00 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 10         | None             |    600.24 ns |  1.57 |    4400 B |          NA |
| LockUnlockRefImplMultipleAsync       | 10         | None             |    688.36 ns |  1.80 |    2160 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 10         | None             |    721.33 ns |  1.89 |    2288 B |          NA |
| LockUnlockPooledTaskMultipleAsync    | 10         | None             |  3,121.59 ns |  8.18 |    1352 B |          NA |
| LockUnlockNonKeyedMultipleAsync      | 10         | None             |  3,276.16 ns |  8.59 |    2296 B |          NA |
|                                      |            |                  |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 10         | NotCancelled     |    544.83 ns |  1.00 |         - |          NA |
| LockUnlockNeoSmartMultipleAsync      | 10         | NotCancelled     |    703.24 ns |  1.29 |    2288 B |          NA |
| LockUnlockNitoMultipleAsync          | 10         | NotCancelled     |  2,791.55 ns |  5.12 |    6800 B |          NA |
| LockUnlockPooledTaskMultipleAsync    | 10         | NotCancelled     |  3,600.68 ns |  6.61 |    1352 B |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 10         | NotCancelled     |  4,302.62 ns |  7.90 |    3888 B |          NA |
| LockUnlockNonKeyedMultipleAsync      | 10         | NotCancelled     |  5,174.97 ns |  9.50 |    5176 B |          NA |
|                                      |            |                  |              |       |           |             |
| LockUnlockSemaphoreSlimMultipleAsync | 100        | None             |  2,786.80 ns |  0.82 |    8800 B |          NA |
| LockUnlockPooledMultipleAsync        | 100        | None             |  3,379.56 ns |  1.00 |         - |          NA |
| LockUnlockNitoMultipleAsync          | 100        | None             |  5,883.34 ns |  1.74 |   41120 B |          NA |
| LockUnlockNeoSmartMultipleAsync      | 100        | None             |  6,359.23 ns |  1.88 |   21008 B |          NA |
| LockUnlockRefImplMultipleAsync       | 100        | None             |  6,504.34 ns |  1.92 |   21600 B |          NA |
| LockUnlockPooledTaskMultipleAsync    | 100        | None             | 32,973.46 ns |  9.76 |   12216 B |          NA |
| LockUnlockNonKeyedMultipleAsync      | 100        | None             | 35,043.55 ns | 10.37 |   21800 B |          NA |
|                                      |            |                  |              |       |           |             |
| LockUnlockPooledMultipleAsync        | 100        | NotCancelled     |  5,108.53 ns |  1.00 |         - |          NA |
| LockUnlockNeoSmartMultipleAsync      | 100        | NotCancelled     |  6,551.25 ns |  1.28 |   21008 B |          NA |
| LockUnlockNitoMultipleAsync          | 100        | NotCancelled     | 29,297.01 ns |  5.73 |   65120 B |          NA |
| LockUnlockPooledTaskMultipleAsync    | 100        | NotCancelled     | 36,446.80 ns |  7.13 |   12216 B |          NA |
| LockUnlockSemaphoreSlimMultipleAsync | 100        | NotCancelled     | 42,887.13 ns |  8.40 |   37792 B |          NA |
| LockUnlockNonKeyedMultipleAsync      | 100        | NotCancelled     | 51,830.33 ns | 10.15 |   50600 B |          NA |
