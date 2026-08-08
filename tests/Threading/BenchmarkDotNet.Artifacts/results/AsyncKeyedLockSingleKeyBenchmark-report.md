```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                            | Mean      | Ratio | Allocated | 
|------------------------------------------------------- |----------:|------:|----------:|
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  29.00 ns |  0.72 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  33.33 ns |  0.83 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  40.33 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  56.25 ns |  1.39 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  65.81 ns |  1.63 |      48 B | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  70.99 ns |  1.76 |     256 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  80.61 ns |  2.00 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 100.24 ns |  2.49 |     520 B | 
