| Description                                              | KeyCount | Mean        | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |------------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    34.64 ns |  0.77 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    38.00 ns |  0.84 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    45.00 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    63.00 ns |  1.40 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    75.33 ns |  1.67 |      48 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    77.74 ns |  1.73 |     144 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    89.36 ns |  1.99 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   119.09 ns |  2.65 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |   116.98 ns |  0.72 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   131.04 ns |  0.81 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   162.12 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   235.45 ns |  1.45 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   277.09 ns |  1.71 |     192 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   279.19 ns |  1.72 |     576 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   347.84 ns |  2.15 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   425.58 ns |  2.63 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   438.63 ns |  0.74 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   509.83 ns |  0.86 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   594.65 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   951.31 ns |  1.60 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       | 1,058.72 ns |  1.78 |    2304 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       | 1,089.93 ns |  1.83 |     768 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,335.28 ns |  2.25 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,748.43 ns |  2.94 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,769.94 ns |  0.76 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,885.00 ns |  0.81 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 2,335.08 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 4,221.75 ns |  1.81 |    3072 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 4,295.42 ns |  1.84 |    9216 B | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 4,345.61 ns |  1.86 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 5,410.16 ns |  2.32 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 6,741.31 ns |  2.89 |   33280 B |