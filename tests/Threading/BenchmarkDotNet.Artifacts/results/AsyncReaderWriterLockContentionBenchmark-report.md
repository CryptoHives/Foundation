```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                             | Iterations | Mean        | Ratio | Allocated | 
|---------------------------------------- |----------- |------------:|------:|----------:|
| Contention · AsyncRWLock · Pooled       | 1          |    99.22 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 1          | 2,085.94 ns | 21.02 |    1440 B | 
|                                         |            |             |       |           | 
| Contention · AsyncRWLock · Pooled       | 5          |   267.34 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 5          | 3,544.04 ns | 13.26 |    2560 B | 
|                                         |            |             |       |           | 
| Contention · AsyncRWLock · Pooled       | 10         |   440.35 ns |  1.00 |         - | 
| Contention · AsyncRWLock · VS.Threading | 10         | 5,579.65 ns | 12.67 |    3960 B | 
