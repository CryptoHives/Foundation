```

BenchmarkDotNet v0.15.6, Windows 11 (10.0.26200.7171)
AMD Ryzen 9 8945HS w/ Radeon 780M Graphics 4.00GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.306
  [Host]   : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4
  .NET 9.0 : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

Job=.NET 9.0  Runtime=.NET 9.0  Toolchain=net9.0  

```
| Method                        | Mean      | Ratio | Allocated | Alloc Ratio |
|------------------------------ |----------:|------:|----------:|------------:|
| LockUnlockSingle              |  3.498 ns |  0.18 |         - |          NA |
| LockEnterScopeSingle          |  3.490 ns |  0.18 |         - |          NA |
| ObjectLockUnlockSingle        |  4.899 ns |  0.25 |         - |          NA |
| LockUnlockPooledSingleAsync   | 14.128 ns |  0.74 |         - |          NA |
| LockUnlockNitoSingleAsync     | 47.775 ns |  2.49 |     320 B |          NA |
| LockUnlockNonKeyedSingleAsync | 29.469 ns |  1.53 |         - |          NA |
| LockUnlockRefImplSingleAsync  | 19.221 ns |  1.00 |         - |          NA |
