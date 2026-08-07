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
| LockAsync · AsyncKeyedLock · AsyncKeyedLock (Striped)  |  28.71 ns |  0.40 |         - | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores (Striped) |  33.81 ns |  0.47 |         - | 
| LockAsync · AsyncKeyedLock · AsyncUtilities (Striped)  |  56.58 ns |  0.79 |         - | 
| LockAsync · AsyncKeyedLock · AsyncKeyedLock            |  66.75 ns |  0.93 |      48 B | 
| LockAsync · AsyncKeyedLock · Pooled                    |  71.84 ns |  1.00 |         - | 
| LockAsync · AsyncKeyedLock · RefImpl                   |  72.54 ns |  1.01 |     256 B | 
| LockAsync · AsyncKeyedLock · KeyedSemaphores           |  82.68 ns |  1.15 |     200 B | 
| LockAsync · AsyncKeyedLock · Dao.IndividualLock        | 102.46 ns |  1.43 |     520 B | 
