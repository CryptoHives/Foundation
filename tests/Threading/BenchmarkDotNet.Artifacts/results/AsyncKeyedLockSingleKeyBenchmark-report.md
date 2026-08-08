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
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  28.63 ns |  0.71 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  33.15 ns |  0.83 |         - | 
| LockAsync · AsyncKeyedLock · Pooled                    |  40.05 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  56.77 ns |  1.42 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  64.90 ns |  1.62 |      48 B | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  71.78 ns |  1.79 |     256 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  83.44 ns |  2.08 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 107.96 ns |  2.70 |     520 B | 
