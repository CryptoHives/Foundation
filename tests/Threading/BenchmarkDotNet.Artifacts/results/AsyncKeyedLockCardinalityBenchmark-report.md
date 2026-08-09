```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8875/25H2/2025Update/HudsonValley2)
AMD Ryzen 5 7600X 4.70GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 11.0.100-preview.5.26302.115
  [Host]    : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4
  .NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v4

Job=.NET 10.0  Runtime=.NET 10.0  Toolchain=net10.0  
Alloc Ratio=NA  

```
| Description                                              | KeyCount | Mean        | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |------------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    32.40 ns |  0.70 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    34.31 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    46.15 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    55.62 ns |  1.21 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    69.12 ns |  1.50 |      48 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    72.42 ns |  1.57 |     256 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    80.72 ns |  1.75 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   104.94 ns |  2.27 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |   107.91 ns |  0.67 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   117.12 ns |  0.73 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   160.72 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   196.68 ns |  1.22 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   252.82 ns |  1.57 |     192 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   271.34 ns |  1.69 |    1024 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   321.01 ns |  2.00 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   390.13 ns |  2.43 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   403.33 ns |  0.70 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   449.93 ns |  0.78 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   577.12 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   939.48 ns |  1.63 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       |   983.52 ns |  1.70 |     768 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       | 1,080.98 ns |  1.87 |    4096 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,251.01 ns |  2.17 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,543.49 ns |  2.67 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,597.28 ns |  0.66 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,682.66 ns |  0.70 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 2,413.15 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 2,936.88 ns |  1.22 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 3,873.49 ns |  1.61 |    3072 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 5,031.22 ns |  2.08 |   12800 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 5,607.52 ns |  2.32 |   16384 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 6,180.39 ns |  2.56 |   33280 B | 
