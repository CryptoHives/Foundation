| Description                                              | KeyCount | Mean        | Ratio | Allocated | 
|--------------------------------------------------------- |--------- |------------:|------:|----------:|
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 1        |    22.14 ns |  0.82 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 1        |    27.07 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 1        |    30.76 ns |  1.14 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 1        |    32.43 ns |  1.20 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 1        |    61.40 ns |  2.27 |      48 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 1        |    63.72 ns |  2.35 |     144 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 1        |    84.08 ns |  3.11 |     200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 1        |   101.83 ns |  3.76 |     520 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 4        |    92.58 ns |  0.78 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 4        |   113.88 ns |  0.96 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 4        |   118.07 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 4        |   122.65 ns |  1.04 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 4        |   235.05 ns |  1.99 |     192 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 4        |   238.28 ns |  2.02 |     576 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 4        |   320.51 ns |  2.71 |     800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 4        |   378.93 ns |  3.21 |    2080 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 16       |   358.24 ns |  0.96 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 16       |   375.13 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 16       |   461.62 ns |  1.23 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 16       |   498.66 ns |  1.33 |         - | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 16       |   880.11 ns |  2.35 |     768 B | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 16       |   925.53 ns |  2.47 |    2304 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 16       | 1,297.81 ns |  3.46 |    3200 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 16       | 1,474.74 ns |  3.93 |    8320 B | 
|                                                          |          |             |       |           | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock (Striped)  | 64       | 1,409.72 ns |  0.89 |         - | 
| Cardinality · AsyncKeyedLock · Pooled                    | 64       | 1,587.17 ns |  1.00 |         - | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores (Striped) | 64       | 1,652.88 ns |  1.04 |         - | 
| Cardinality · AsyncKeyedLock · AsyncUtilities (Striped)  | 64       | 1,811.52 ns |  1.14 |         - | 
| Cardinality · AsyncKeyedLock · RefImpl                   | 64       | 3,651.68 ns |  2.30 |    9216 B | 
| Cardinality · AsyncKeyedLock · AsyncKeyedLock            | 64       | 3,654.06 ns |  2.30 |    3072 B | 
| Cardinality · AsyncKeyedLock · KeyedSemaphores           | 64       | 4,966.20 ns |  3.13 |   12800 B | 
| Cardinality · AsyncKeyedLock · Dao.IndividualLock        | 64       | 5,855.01 ns |  3.69 |   33280 B |