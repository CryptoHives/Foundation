```

BenchmarkDotNet v0.15.7, Windows 11 (10.0.26200.7171/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 10.0.100
  [Host]    : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.0 (10.0.0, 10.0.25.52411), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  

```
| Method                             | Mean       | Ratio | Allocated | Alloc Ratio |
|----------------------------------- |-----------:|------:|----------:|------------:|
| IncrementSingle                    |  0.0020 ns | 0.000 |         - |          NA |
| InterlockedIncrementSingle         |  0.2070 ns | 0.010 |         - |          NA |
| LockEnterScopeSingle               |  3.3850 ns | 0.166 |         - |          NA |
| LockUnlockSingle                   |  3.4422 ns | 0.169 |         - |          NA |
| ObjectLockUnlockSingle             |  4.3128 ns | 0.212 |         - |          NA |
| LockUnlockPooledSingleAsync        | 12.6773 ns | 0.623 |         - |          NA |
| LockUnlockSemaphoreSlimSingleAsync | 19.0709 ns | 0.937 |         - |          NA |
| LockUnlockRefImplSingleAsync       | 20.3435 ns | 1.000 |         - |          NA |
| LockUnlockNonKeyedSingleAsync      | 23.3824 ns | 1.149 |         - |          NA |
| LockUnlockNitoSingleAsync          | 41.5297 ns | 2.041 |     320 B |          NA |
| LockUnlockNeoSmartSingleAsync      | 60.6365 ns | 2.981 |     208 B |          NA |
