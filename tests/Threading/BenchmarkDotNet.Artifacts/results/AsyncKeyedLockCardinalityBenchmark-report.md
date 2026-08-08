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
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    34.13 ns |  0.73 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    35.15 ns |  0.76 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    46.44 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    59.17 ns |  1.27 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    71.38 ns |  1.54 |      48 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    75.80 ns |  1.63 |     256 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    88.59 ns |  1.91 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   105.63 ns |  2.27 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |   108.47 ns |  0.67 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   119.54 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   162.28 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   209.12 ns |  1.29 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   254.45 ns |  1.57 |     192 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   283.84 ns |  1.75 |    1024 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   317.28 ns |  1.96 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   387.61 ns |  2.39 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   413.44 ns |  0.69 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   441.10 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   594.97 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   769.45 ns |  1.29 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       | 1,013.64 ns |  1.70 |     768 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       | 1,126.25 ns |  1.89 |    4096 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,285.57 ns |  2.16 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,604.18 ns |  2.70 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,615.67 ns |  0.68 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,743.31 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 2,358.83 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 3,036.30 ns |  1.29 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 4,058.13 ns |  1.72 |    3072 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 4,510.56 ns |  1.91 |   16384 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 4,989.25 ns |  2.12 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 6,376.89 ns |  2.70 |   33280 B | 
