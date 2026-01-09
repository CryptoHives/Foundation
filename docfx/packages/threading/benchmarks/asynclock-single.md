```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.7462/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.101
  [Host]    : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.1 (10.0.1, 10.0.125.57005), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                             | Mean       | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |-----------:|------:|----------:|------------:|
| IncrementSingle                    |  0.0050 ns | 0.000 |         - |          NA |
| InterlockedIncrementSingle         |  0.2035 ns | 0.015 |         - |          NA |
| LockEnterScopeSingle               |  3.3816 ns | 0.257 |         - |          NA |
| LockUnlockSingle                   |  3.4124 ns | 0.260 |         - |          NA |
| ObjectLockUnlockSingle             |  4.1796 ns | 0.318 |         - |          NA |
| LockUnlockPooledSingleAsync        | 13.1516 ns | 1.000 |         - |          NA |
| LockUnlockSemaphoreSlimSingleAsync | 18.8173 ns | 1.431 |         - |          NA |
| LockUnlockRefImplSingleAsync       | 20.2174 ns | 1.537 |         - |          NA |
| LockUnlockNonKeyedSingleAsync      | 23.1732 ns | 1.762 |         - |          NA |
| LockUnlockNitoSingleAsync          | 41.2909 ns | 3.140 |     320 B |          NA |
| LockUnlockNeoSmartSingleAsync      | 60.1140 ns | 4.571 |     208 B |          NA |
