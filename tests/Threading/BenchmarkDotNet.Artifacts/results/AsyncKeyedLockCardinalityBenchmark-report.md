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
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    33.25 ns |  0.46 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    34.72 ns |  0.48 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    68.68 ns |  0.95 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    72.35 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    73.83 ns |  1.02 |      48 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    77.14 ns |  1.07 |     256 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    82.71 ns |  1.14 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   106.52 ns |  1.47 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |   112.49 ns |  0.45 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   122.57 ns |  0.49 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   199.66 ns |  0.79 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   251.45 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   256.05 ns |  1.02 |     192 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   278.92 ns |  1.11 |    1024 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   310.08 ns |  1.23 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   396.50 ns |  1.58 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   415.20 ns |  0.45 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   506.58 ns |  0.54 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   779.43 ns |  0.84 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   930.59 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       | 1,002.46 ns |  1.08 |     768 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       | 1,157.11 ns |  1.24 |    4096 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,218.77 ns |  1.31 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,619.62 ns |  1.74 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,658.98 ns |  0.45 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,777.97 ns |  0.48 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 2,974.38 ns |  0.80 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 3,721.55 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 4,017.67 ns |  1.08 |    3072 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 4,450.24 ns |  1.20 |   16384 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 4,979.28 ns |  1.34 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 6,269.55 ns |  1.68 |   33280 B | 
