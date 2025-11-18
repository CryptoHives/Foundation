```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.7171)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4
  .NET 9.0 : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

Job=.NET 9.0  Runtime=.NET 9.0  Toolchain=net9.0  

```
| Method                            | Iterations | Mean         | Ratio | Allocated | Alloc Ratio |
|---------------------------------- |----------- |-------------:|------:|----------:|------------:|
| **LockUnlockPooledMultipleAsync**     | **0**          |     **15.03 ns** |  **0.67** |         **-** |          **NA** |
| LockUnlockPooledTaskMultipleAsync | 0          |     15.37 ns |  0.68 |         - |          NA |
| LockUnlockNitoMultipleAsync       | 0          |     51.43 ns |  2.28 |     320 B |          NA |
| LockUnlockRefImplMultipleAsync    | 0          |     22.55 ns |  1.00 |         - |          NA |
| LockUnlockNonKeyedMultipleAsync   | 0          |     31.81 ns |  1.41 |         - |          NA |
|                                   |            |              |       |           |             |
| **LockUnlockPooledMultipleAsync**     | **1**          |     **49.13 ns** |  **0.49** |         **-** |        **0.00** |
| LockUnlockPooledTaskMultipleAsync | 1          |    470.88 ns |  4.67 |     264 B |        1.22 |
| LockUnlockNitoMultipleAsync       | 1          |    131.13 ns |  1.30 |     728 B |        3.37 |
| LockUnlockRefImplMultipleAsync    | 1          |    100.90 ns |  1.00 |     216 B |        1.00 |
| LockUnlockNonKeyedMultipleAsync   | 1          |    515.28 ns |  5.11 |     336 B |        1.56 |
|                                   |            |              |       |           |             |
| **LockUnlockPooledMultipleAsync**     | **10**         |    **390.93 ns** |  **0.47** |         **-** |        **0.00** |
| LockUnlockPooledTaskMultipleAsync | 10         |  3,283.17 ns |  3.93 |    1344 B |        0.62 |
| LockUnlockNitoMultipleAsync       | 10         |    798.95 ns |  0.96 |    4400 B |        2.04 |
| LockUnlockRefImplMultipleAsync    | 10         |    838.86 ns |  1.00 |    2160 B |        1.00 |
| LockUnlockNonKeyedMultipleAsync   | 10         |  3,484.41 ns |  4.17 |    2208 B |        1.02 |
|                                   |            |              |       |           |             |
| **LockUnlockPooledMultipleAsync**     | **100**        |  **3,949.47 ns** |  **0.50** |    **4824 B** |        **0.22** |
| LockUnlockPooledTaskMultipleAsync | 100        | 34,435.51 ns |  4.36 |   17031 B |        0.79 |
| LockUnlockNitoMultipleAsync       | 100        |  7,774.08 ns |  0.99 |   41120 B |        1.90 |
| LockUnlockRefImplMultipleAsync    | 100        |  7,909.11 ns |  1.00 |   21600 B |        1.00 |
| LockUnlockNonKeyedMultipleAsync   | 100        | 37,044.14 ns |  4.70 |   20992 B |        0.97 |
