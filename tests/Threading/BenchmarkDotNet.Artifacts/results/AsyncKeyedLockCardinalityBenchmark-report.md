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
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    33.06 ns |  0.70 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    35.69 ns |  0.76 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    47.21 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    56.82 ns |  1.20 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    72.48 ns |  1.54 |      48 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    77.62 ns |  1.64 |     256 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    89.50 ns |  1.90 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   115.82 ns |  2.45 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |   111.18 ns |  0.67 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   122.58 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   165.72 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   207.79 ns |  1.25 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   262.49 ns |  1.58 |     192 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   287.62 ns |  1.74 |    1024 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   333.02 ns |  2.01 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   451.55 ns |  2.72 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   414.59 ns |  0.68 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   454.33 ns |  0.75 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   609.54 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   782.27 ns |  1.28 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       | 1,019.77 ns |  1.67 |     768 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       | 1,141.90 ns |  1.87 |    4096 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,256.92 ns |  2.06 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,649.63 ns |  2.71 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,702.27 ns |  0.71 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,766.14 ns |  0.73 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 2,410.58 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 3,142.39 ns |  1.30 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 4,056.37 ns |  1.68 |    3072 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 4,580.70 ns |  1.90 |   16384 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 5,215.24 ns |  2.16 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 6,481.44 ns |  2.69 |   33280 B | 
