```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                          | Mean     | Ratio | Allocated | 
|----------------------------------------------------- |---------:|------:|----------:|
| TryLock · AsyncKeyedLock · Pooled                    | 14.83 ns |  1.00 |         - | 
| TryLock · AsyncKeyedLock · KeyedSemaphores (Striped) | 36.06 ns |  2.43 |         - | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 40.66 ns |  2.74 |      24 B | 
| TryLock · AsyncKeyedLock · AsyncKeyedLock            | 67.78 ns |  4.57 |      48 B | 
| TryLock · AsyncKeyedLock · KeyedSemaphores           | 83.33 ns |  5.62 |     200 B | 
